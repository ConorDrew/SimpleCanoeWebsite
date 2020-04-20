Imports System.Collections.Generic

Namespace Entity

    Namespace Users

        Public Class User

            Private _dataTypeValidator As DataTypeValidator

            Public Sub New()
                _dataTypeValidator = New DataTypeValidator
            End Sub

#Region "Class Properties"

            Public Property IgnoreExceptionsOnSetMethods() As Boolean
                Get
                    Return Me._dataTypeValidator.IgnoreExceptionsOnSetMethods
                End Get
                Set(ByVal Value As Boolean)
                    Me._dataTypeValidator.IgnoreExceptionsOnSetMethods = Value
                End Set
            End Property

            Public ReadOnly Property Errors() As Hashtable
                Get
                    Return _dataTypeValidator.Errors
                End Get
            End Property

            Public ReadOnly Property DTValidator() As DataTypeValidator
                Get
                    Return _dataTypeValidator
                End Get
            End Property

            Private _exists As Boolean = False

            Public Property Exists() As Boolean
                Get
                    Return _exists
                End Get
                Set(ByVal Value As Boolean)
                    _exists = Value
                End Set
            End Property

            Private _deleted As Boolean = False

            Public ReadOnly Property Deleted() As Boolean
                Get
                    Return _deleted
                End Get
            End Property

            Public WriteOnly Property SetDeleted() As Boolean
                Set(ByVal Value As Boolean)
                    _deleted = Value
                End Set
            End Property

#End Region

#Region "User Properties"

            Private _UserID As Integer = 0

            Public ReadOnly Property UserID() As Integer
                Get
                    Return _UserID
                End Get
            End Property

            Public WriteOnly Property SetUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserID", Value)
                End Set
            End Property

            Private _Fullname As String = String.Empty

            Public ReadOnly Property Fullname() As String
                Get
                    Return _Fullname
                End Get
            End Property

            Public WriteOnly Property SetFullname() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Fullname", Value)
                End Set
            End Property

            Private _Username As String = String.Empty

            Public ReadOnly Property Username() As String
                Get
                    Return _Username
                End Get
            End Property

            Public WriteOnly Property SetUsername() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Username", Value)
                End Set
            End Property

            Private _Password As String = String.Empty

            Public ReadOnly Property Password() As String
                Get
                    Return _Password
                End Get
            End Property

            Public WriteOnly Property SetPassword() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Password", Value)
                End Set
            End Property

            Private _Enabled As Boolean = False

            Public ReadOnly Property Enabled() As Boolean
                Get
                    Return _Enabled
                End Get
            End Property

            Public WriteOnly Property SetEnabled() As Boolean
                Set(ByVal Value As Boolean)
                    _Enabled = Value
                End Set
            End Property

            Private _Admin As Boolean = False

            Public ReadOnly Property Admin() As Boolean
                Get
                    Return _Admin
                End Get
            End Property

            Public WriteOnly Property SetAdmin() As Boolean
                Set(ByVal Value As Boolean)
                    _Admin = Value
                End Set
            End Property

            Private _EmailAddress As String = String.Empty

            Public ReadOnly Property EmailAddress() As String
                Get
                    Return _EmailAddress
                End Get
            End Property

            Public WriteOnly Property SetEmailAddress() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmailAddress", Value)
                End Set
            End Property

            Private _SchedulerDayView As Boolean = False

            Public ReadOnly Property SchedulerDayView() As Boolean
                Get
                    Return _SchedulerDayView
                End Get
            End Property

            Public WriteOnly Property SetSchedulerDayView() As Boolean
                Set(ByVal Value As Boolean)
                    _dataTypeValidator.SetValue(Me, "_SchedulerDayView", Value)
                End Set
            End Property

            Private _DefaultEngineerGroup As Integer = False

            Public ReadOnly Property DefaultEngineerGroup() As Integer
                Get
                    Return _DefaultEngineerGroup
                End Get
            End Property

            Public WriteOnly Property SetDefaultEngineerGroup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DefaultEngineerGroup", Value)
                End Set
            End Property

            Private _ManagerUserID As Integer = 0

            Public ReadOnly Property ManagerUserID() As Integer
                Get
                    Return _ManagerUserID
                End Get
            End Property

            Public WriteOnly Property SetManagerUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ManagerUserID", Value)
                End Set
            End Property

            Private _SchedulerTextSize As Integer = 0

            Public ReadOnly Property SchedulerTextSize() As Integer
                Get
                    Return _SchedulerTextSize
                End Get
            End Property

            Public WriteOnly Property SetSchedulerTextSize() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SchedulerTextSize", Value)
                End Set
            End Property

            Private _expiryDate As DateTime = Nothing

            Public Property PasswordExpiryDate() As DateTime
                Get
                    Return _expiryDate
                End Get
                Set(ByVal Value As DateTime)
                    _expiryDate = Value
                End Set
            End Property

            Private _UpdateAtLogon As Boolean = False

            Public ReadOnly Property UpdateAtLogon() As Boolean
                Get
                    Return _UpdateAtLogon
                End Get
            End Property

            Public WriteOnly Property SetUpdateAtLogon() As Boolean
                Set(ByVal Value As Boolean)
                    _dataTypeValidator.SetValue(Me, "_UpdateAtLogon", Value)
                End Set
            End Property

#End Region

#Region "Security"

            Private _securityUserModules As DataView = Nothing

            Public Property SecurityUserModules() As DataView
                Get
                    If _securityUserModules Is Nothing Then
                        'return a valid table structure
                        _securityUserModules = DB.User.GetSecurityUserModulesDefaults()
                        _securityUserModules.AllowEdit = True
                        _securityUserModules.AllowNew = False
                        _securityUserModules.AllowDelete = False
                    End If
                    If Not _securityUserModules Is Nothing Then
                        If _securityUserModules.Table.Rows.Count = 0 Then
                            _securityUserModules = DB.User.GetSecurityUserModulesDefaults()
                            _securityUserModules.AllowEdit = True
                            _securityUserModules.AllowNew = False
                            _securityUserModules.AllowDelete = False
                        End If
                    End If
                    Return _securityUserModules
                End Get
                Set(ByVal Value As DataView)
                    _securityUserModules = Value
                    If Not _securityUserModules Is Nothing Then
                        _securityUserModules.AllowEdit = True
                        _securityUserModules.AllowNew = False
                        _securityUserModules.AllowDelete = False
                    End If
                End Set
            End Property

            Private _userRegions As DataView = Nothing

            Public Property UserRegions() As DataView
                Get
                    Return _userRegions
                End Get
                Set(ByVal Value As DataView)
                    _userRegions = Value
                    If Not _userRegions Is Nothing Then
                        _userRegions.Table.TableName = Entity.Sys.Enums.TableNames.tblRegion.ToString
                        _userRegions.AllowNew = False
                        _userRegions.AllowEdit = False
                        _userRegions.AllowDelete = False
                    End If
                End Set
            End Property

            Public Function HasAccessToModule(Optional ByVal ssm As Sys.Enums.SecuritySystemModules =
                                              Entity.Sys.Enums.SecuritySystemModules.FSMAdmin) As Boolean
                Dim access As Boolean = False

                If ssm = Sys.Enums.SecuritySystemModules.None Then
                    access = True
                Else
                    Dim selectStatement As String =
                        String.Format("SystemModuleID IN ({0}, {1}) and AccessPermitted = 1",
                                      CInt(ssm), CInt(Sys.Enums.SecuritySystemModules.FSMAdmin))

                    Dim rows() As DataRow = SecurityUserModules.Table.Select(selectStatement)
                    If rows.Length >= 1 Then
                        access = True
                    End If
                End If
                Return access
            End Function

            Public Function HasAccessToMulitpleModules(ByVal ssm As List(Of Sys.Enums.SecuritySystemModules)) As Boolean
                Dim access As Boolean = False
                If Not ssm.Contains(Sys.Enums.SecuritySystemModules.FSMAdmin) Then ssm.Add(Sys.Enums.SecuritySystemModules.FSMAdmin)
                If ssm.Contains(Sys.Enums.SecuritySystemModules.None) Then
                    access = True
                Else
                    Dim dvSSM As DataView =
                        (From row In SecurityUserModules.Table.AsEnumerable()
                         Where (ssm.Contains(row.Field(Of Integer)("SystemModuleID")) And
                             row.Field(Of Boolean)("AccessPermitted") = True) Select row).AsDataView()

                    If dvSSM.Count >= 1 Then
                        access = True
                    End If
                End If
                Return access
            End Function

#End Region

        End Class

    End Namespace

End Namespace