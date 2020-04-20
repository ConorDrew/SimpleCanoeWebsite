Imports System.Collections.Generic

''Imports System.Linq
Imports FSM.Entity.Sys

Namespace Entity.EngineerRoles

    Public Class EngineerRoleSql
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

        Public Function [GetAll]() As List(Of EngineerRole)
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRole_GetAll")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim engineerRoles As List(Of EngineerRole) = ObjectMap.DataTableToList(Of EngineerRole)(dt)
                Return engineerRoles
            Else : Return Nothing
            End If
        End Function

        Public Function [GetEngineersAssignedToRole]() As List(Of EngineerAssignedToRole)
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRole_GetEngineersAssignedToRole")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim engineerToRoleList As List(Of EngineerAssignedToRole) = ObjectMap.DataTableToList(Of EngineerAssignedToRole)(dt)
                Return engineerToRoleList
            Else : Return Nothing
            End If
        End Function

        Public Function [GetLookupData]() As DataView
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRole_GetAll")
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerRole.ToString
            Return New DataView(dt)
        End Function

        Public Function [GetEngineersNotAssignedToRole]() As DataView
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRole_GetEngineersNotAssignedToRole")
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerRole.ToString
            Return New DataView(dt)
        End Function

        Public Function [Insert](ByVal engineerRole As Entity.EngineerRoles.EngineerRole) As EngineerRole
            _database.ClearParameter()
            _database.AddParameter("@Name", engineerRole.Name)
            _database.AddParameter("@Description", engineerRole.Description)
            _database.AddParameter("@HourlyCostToCompany", engineerRole.HourlyCostToCompany)
            engineerRole.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Insert"))
            Return engineerRole
        End Function

        Public Function [Update](ByVal engineerRole As EngineerRole) As Integer
            _database.ClearParameter()
            _database.AddParameter("@Id", engineerRole.Id, True)
            _database.AddParameter("@Name", engineerRole.Name)
            _database.AddParameter("@Description", engineerRole.Description)
            _database.AddParameter("@HourlyCostToCompany", engineerRole.HourlyCostToCompany)
            Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Update"))
        End Function

        Public Function [Delete](ByVal Id As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@Id", Id)
            Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Delete"))
        End Function

        Public Function [AssignEngineerToRole](ByVal engineerId As Integer, ByVal engineerRoleId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@EngineerID", engineerId)
            _database.AddParameter("@EngineerRoleId", engineerRoleId)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("EngineerRole_AssignEngineer") = 1)
        End Function

        Public Function [GetEngineerRoleId](ByVal engineerId As Integer) As EngineerRole
            Dim engineerRole As New EngineerRole()
            engineerRole.Id = -1
            _database.ClearParameter()
            _database.AddParameter("@EngineerID", engineerId)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRole_GetEngineerRoleId")
            If ((Not IsNothing(dt)) And (dt.Rows.Count > 0)) Then
                engineerRole.Id = dt.Rows(0).Item("EngineerRoleId")
                engineerRole.Name = dt.Rows(0).Item("Name")
            End If
            Return engineerRole
        End Function

    End Class

End Namespace