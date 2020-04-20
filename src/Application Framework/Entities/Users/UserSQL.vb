Imports System.Data.SqlClient
Imports FSM.Entity.Sys
Imports DocumentFormat.OpenXml.Drawing.Diagrams

Namespace Entity

    Namespace Users

        Public Class UserSQL

            Private _database As Sys.Database

            Public Sub New(ByVal databaseIn As Sys.Database)
                _database = databaseIn
            End Sub

#Region "Functions"

            Public Function Authenticate(ByVal UserName As String, ByVal Password As String) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@UserName", UserName)
                _database.AddParameter("@Password", Entity.Sys.Helper.HashPassword(Password))
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_Login_Mk1")
                If dt.Rows.Count > 0 Then
                    loggedInUser = [Get](Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("UserID")))
                    Return True
                Else
                    loggedInUser = Nothing
                    Return False
                End If
            End Function

            Public Function IsUserActive(Optional ByVal UserName As String = "",
                                         Optional ByVal UserID As Integer = 0,
                                         Optional ByVal SetProperty As Boolean = False) As Integer
                _database.ClearParameter()

                If Not String.IsNullOrEmpty(UserName) Then _database.AddParameter("@UserName", UserName)
                If UserID > 0 Then _database.AddParameter("@UserID", UserID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_IsActive_Mk1")
                If dt.Rows.Count > 0 Then
                    If SetProperty Then loggedInUser = [Get](Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("UserID")), True)
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function Check_Unique_Username(ByVal username As String, ByVal ID As Integer) As Boolean
                Dim NumberOfUsers As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(Userid) as 'NumberOfUsers' " &
                "FROM tbluser WHERE deleted = 0 AND username = '" & username & "' AND userid <> " & ID, False))

                If NumberOfUsers = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_GetAll_Mk1")
                dt.TableName = Sys.Enums.TableNames.tblUser.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_NoEngineers() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_GetAll_NoEngineers")
                dt.TableName = Sys.Enums.TableNames.tblUser.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal UserID As Integer, Optional ByVal passExpired As Boolean = False) As Entity.Users.User
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_Get_Mk1")

                If dt.Rows.Count > 0 Then
                    Dim userAndEngineer As New Entity.Users.User
                    userAndEngineer.SetUserID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("UserID"))
                    userAndEngineer.SetFullname = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Fullname"))
                    userAndEngineer.SetUsername = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Username"))
                    userAndEngineer.SetPassword = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Password"))
                    userAndEngineer.SetEnabled = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Enabled"))
                    userAndEngineer.SetDeleted = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Deleted"))
                    userAndEngineer.SetAdmin = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Admin"))
                    userAndEngineer.SetSchedulerDayView = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("SchedulerDayView"))
                    If IsDBNull(dt.Rows(0).Item("DefaultSchedulerEngineerGroup")) Then
                        userAndEngineer.SetDefaultEngineerGroup = 0
                    Else
                        userAndEngineer.SetDefaultEngineerGroup = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("DefaultSchedulerEngineerGroup"))
                    End If
                    userAndEngineer.SetSchedulerTextSize = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("SchedulerTextSize"))
                    userAndEngineer.SetEmailAddress = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("EmailAddress"))
                    userAndEngineer.PasswordExpiryDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("ExpiryDate"))
                    userAndEngineer.SetUpdateAtLogon = passExpired OrElse Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("UpdateAtLogon"))
                    userAndEngineer.SecurityUserModules = GetSecurityUserModules(UserID)
                    userAndEngineer.UserRegions = DB.User.UserRegions_Get(UserID)
                    userAndEngineer.Exists = True
                    Return userAndEngineer
                Else
                    Return Nothing
                End If
            End Function

            Public Function [GetAsync](ByVal UserID As Integer) As User
                Dim dt As New DataTable
                Dim command As New SqlCommand("User_Get_Mk1", New SqlConnection(_database.ServerConnectionString))
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)
                    dt = _database.ExecuteCommand_DataTable(command)
                Catch ex As Exception
                Finally
                    command.Connection.Close()
                End Try

                If dt.Rows.Count > 0 Then
                    Dim user As New User With {
                        .SetUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("UserID")),
                        .SetFullname = Helper.MakeStringValid(dt.Rows(0).Item("Fullname")),
                        .SetUsername = Helper.MakeStringValid(dt.Rows(0).Item("Username")),
                        .SetPassword = Helper.MakeStringValid(dt.Rows(0).Item("Password")),
                        .SetEnabled = Helper.MakeBooleanValid(dt.Rows(0).Item("Enabled")),
                        .SetDeleted = Helper.MakeBooleanValid(dt.Rows(0).Item("Deleted")),
                        .SetAdmin = Helper.MakeBooleanValid(dt.Rows(0).Item("Admin")),
                        .SetSchedulerDayView = Helper.MakeBooleanValid(dt.Rows(0).Item("SchedulerDayView")),
                        .SetDefaultEngineerGroup = Helper.MakeIntegerValid(dt.Rows(0).Item("DefaultSchedulerEngineerGroup")),
                        .SetSchedulerTextSize = Helper.MakeIntegerValid(dt.Rows(0).Item("SchedulerTextSize")),
                        .SetEmailAddress = Helper.MakeStringValid(dt.Rows(0).Item("EmailAddress")),
                        .PasswordExpiryDate = Helper.MakeDateTimeValid(dt.Rows(0).Item("ExpiryDate")),
                        .SetUpdateAtLogon = Helper.MakeBooleanValid(dt.Rows(0)("UpdateAtLogon"))
                    }
                    user.SecurityUserModules = GetSecurityUserModules(UserID)
                    user.UserRegions = DB.User.UserRegions_Get(UserID)
                    user.Exists = True
                    Return user
                Else
                    Return Nothing
                End If
            End Function

            Public Function Get_Passwords(ByVal UserID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("UserPassword_Get_ForUser_Mk1")
                Return New DataView(dt)
            End Function

            Public Function UpdatePassword(ByVal UserID As Integer, ByVal Password As String, Optional ByVal updateAtLogon As Boolean = False) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID)
                _database.AddParameter("@Password", Entity.Sys.Helper.HashPassword(Password))
                _database.AddParameter("@UpdateAtLogon", updateAtLogon)
                _database.AddParameter("@ExpiryDate", Now.AddMonths(3), True)

                Return CBool(_database.ExecuteSP_OBJECT("UserPassword_InsertUpdate_Mk1") = 1)
            End Function

            Public Function LastLogon(ByVal UserID As Integer) As String
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID)
                Try
                    Dim datetime As DateTime = Entity.Sys.Helper.MakeDateTimeValid(_database.ExecuteSP_OBJECT("User_LastLogon_Mk1"))
                    Return "Last logon : " & Format(datetime, "dd/MMM/yyyy HH:mm:ss") & "."
                Catch ex As Exception
                    Return "This is your first logon."
                End Try
            End Function

            Public Function Insert(ByVal userAndEngineer As Entity.Users.User) As Integer
                _database.ClearParameter()
                _database.AddParameter("@Fullname", userAndEngineer.Fullname)
                _database.AddParameter("@Username", userAndEngineer.Username)
                _database.AddParameter("@Password", Entity.Sys.Helper.HashPassword(userAndEngineer.Password))
                _database.AddParameter("@DefaultSchedulerEngineerGroup", userAndEngineer.DefaultEngineerGroup)
                _database.AddParameter("@EmailAddress", userAndEngineer.EmailAddress)
                _database.AddParameter("@Enabled", userAndEngineer.Enabled, True)
                _database.AddParameter("@Admin", userAndEngineer.Admin, True)
                _database.AddParameter("@SchedulerDayView", userAndEngineer.SchedulerDayView, True)

                Dim id As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("User_Insert_Mk1"))
                userAndEngineer.SetUserID = id
                SaveSecurityUserModules(userAndEngineer)
                Return id
            End Function

            Public Sub Update(ByVal userAndEngineer As Entity.Users.User)
                _database.ClearParameter()
                _database.AddParameter("@UserID", userAndEngineer.UserID)
                _database.AddParameter("@Fullname", userAndEngineer.Fullname)
                _database.AddParameter("@Username", userAndEngineer.Username)
                _database.AddParameter("@Password", Entity.Sys.Helper.HashPassword(userAndEngineer.Password))
                _database.AddParameter("@DefaultSchedulerEngineerGroup", userAndEngineer.DefaultEngineerGroup)
                _database.AddParameter("@EmailAddress", userAndEngineer.EmailAddress)
                _database.AddParameter("@Enabled", userAndEngineer.Enabled, True)
                _database.AddParameter("@Admin", userAndEngineer.Admin, True)
                _database.AddParameter("@SchedulerDayView", userAndEngineer.SchedulerDayView, True)

                _database.ExecuteSP_OBJECT("User_Update_Mk1")
                SaveSecurityUserModules(userAndEngineer)
            End Sub

            Public Sub Delete(ByVal UserID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID)
                _database.ExecuteSP_OBJECT("User_Delete_Mk1")
            End Sub

            Public Function User_Search(ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_SearchList_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblUser.ToString
                Return New DataView(dt)
            End Function

            Public Sub User_Update_TextSize(ByVal UserID As Integer, ByVal TextSize As Integer)
                _database.ClearParameter()
                _database.ExecuteScalar("UPDATE tblUser Set SchedulerTextSize = " & TextSize & " Where UserID = " & UserID)

            End Sub

#End Region

#Region "Security"

            Public Function GetSecurityUserModulesDefaults() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SecurityUserModulesDefault_Get")
                dt.TableName = Sys.Enums.TableNames.tblUser.ToString
                Return New DataView(dt)
            End Function

            Public Function GetUserRegions(ByVal userId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("UserRegions_Get_ForUserID")
                dt.TableName = Sys.Enums.TableNames.tblRegion.ToString
                Return New DataView(dt)
            End Function

            Public Function GetUserRegionsDefaults() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("UserRegions_Get_Defaults")
                dt.TableName = Sys.Enums.TableNames.tblRegion.ToString
                Return New DataView(dt)
            End Function

            Public Function GetSecurityUserModules(ByVal userID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SecurityUserModules_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSecurityUserModules.ToString()
                Return New DataView(dt)
            End Function

            Private Function SaveSecurityUserModules(ByVal u As User) As User
                If Not u.SecurityUserModules Is Nothing Then
                    Dim t As DataTable = Nothing
                    t = u.SecurityUserModules.Table

                    Dim diff As DataTable = t.GetChanges()
                    If diff IsNot Nothing Then
                        Dim changes As String = String.Empty
                        Dim addAnd As Boolean = False
                        For Each dr As DataRow In diff.Rows
                            If addAnd Then changes += " and "
                            changes += Sys.Helper.MakeStringValid(dr("ModuleName")) & " set to " & Sys.Helper.MakeStringValid(dr("AccessPermitted"))
                            addAnd = True
                        Next
                        If Not String.IsNullOrEmpty(changes) Then UserAccessAudit_Insert(u.UserID, changes)
                    End If

                    For Each r As DataRow In t.Rows
                        _database.ClearParameter()
                        _database.AddParameter("@UserID", u.UserID, True)
                        _database.AddParameter("@SystemModuleID", CInt(r("SystemModuleID")), True)
                        _database.AddParameter("@AccessPermitted", CBool(r("AccessPermitted")), True)
                        If CInt(r("UserModuleID")) = 0 Then
                            _database.ExecuteSP_NO_Return("SecurityUserModules_Insert")
                        Else
                            _database.ExecuteSP_NO_Return("SecurityUserModules_Update")
                        End If
                    Next

                    u.SecurityUserModules = GetSecurityUserModules(u.UserID)
                End If
                Return u
            End Function

            Public Sub InsertNewSecurityUserModules(ByVal UserID As Integer, ByVal SystemModuleID As Integer, ByVal AccessPermitted As Boolean)
                _database.ClearParameter()
                _database.AddParameter("@UserID", UserID, True)
                _database.AddParameter("@SystemModuleID", SystemModuleID, True)
                _database.AddParameter("@AccessPermitted", AccessPermitted, True)
                _database.ExecuteSP_NO_Return("SecurityUserModules_Insert")
            End Sub

            Public Function UserRegions_Get(ByVal userID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("UserRegions_Get")
                Return New DataView(dt)
            End Function

            Public Sub UserRegions_Insert(ByVal userID As Integer, ByVal managerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@UserID", userID, True)
                _database.AddParameter("@RegionID", managerID, True)
                _database.ExecuteSP_OBJECT("UserRegion_Insert")
            End Sub

            Public Sub UserRegions_Delete(ByVal userID As Integer)
                _database.ClearParameter()
                DB.ExecuteScalar("DELETE FROM tblUserRegion Where UserID = " & userID)
            End Sub

            Public Sub [UserAccessAudit_Insert](ByVal userId As Integer, ByVal actionChange As String)
                _database.ClearParameter()

                _database.AddParameter("@UserID", userId, True)
                _database.AddParameter("@ActionChange", actionChange, True)
                _database.AddParameter("@ActionDateTime", DateTime.Now, True)
                _database.AddParameter("@AuthUserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("UserAccessAudit_Insert")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace