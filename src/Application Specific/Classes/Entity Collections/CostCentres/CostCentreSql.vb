Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.CostCentres.Enums
Imports FSM.Entity.Sys

Namespace Entity.CostCentres

    Public Class CostCentreSql

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

        Public Function [GetAll]() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("CostCentre_GetAll"))
        End Function

        Public Function [Get](ByVal ref As Integer, ByVal ref2 As Integer, ByVal getBy As GetBy) As List(Of CostCentre)
            _database.ClearParameter()

            'Get the datatable from the database store in dt
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.Id
                    _database.AddParameter("@Id", ref, True)
                    dt = _database.ExecuteSP_DataTable("CostCentre_Get_ById")

                Case GetBy.JobId
                    _database.AddParameter("@JobID", ref, True)
                    dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobId")

                Case GetBy.JobTypeId
                    _database.AddParameter("@JobTypeId", ref, True)
                    dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeId")

                Case GetBy.JobTypeIdAndCutomerId
                    _database.AddParameter("@JobTypeId", ref, True)
                    _database.AddParameter("@CustomerId", ref2, True)
                    dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeIdAndCustomerId")

                Case Else
                    _database.AddParameter("@Id", ref, True)
                    dt = _database.ExecuteSP_DataTable("CostCentre_Get_ById")
            End Select

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim costCentres As List(Of CostCentre) = ObjectMap.DataTableToList(Of CostCentre)(dt)
                Return costCentres
            Else : Return Nothing
            End If
        End Function

        Public Function [Insert](ByVal ccm As CostCentre) As CostCentre
            AddParameters(ccm)
            ccm.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CostCentre_Insert"))
            Return ccm
        End Function

        Private Sub AddParameters(ByVal ccm As CostCentre)
            _database.ClearParameter()
            _database.AddParameter("@CostCentre", ccm.CostCentre)
            _database.AddParameter("@JobTypeId", ccm.JobTypeId)
            _database.AddParameter("@LinkId", ccm.LinkId)
            _database.AddParameter("@LinkTypeId", ccm.LinkTypeId)
            Dim spendLimit As Object = If(ccm.JobSpendLimit > 0, CObj(ccm.JobSpendLimit), DBNull.Value)
            _database.AddParameter("@JobSpendLimit", spendLimit, True)
        End Sub

        Public Function [Update](ByVal ccm As CostCentre) As CostCentre
            AddParameters(ccm)
            _database.AddParameter("@Id", ccm.Id)
            ccm.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CostCentre_Update"))
            Return ccm
        End Function

        Public Function [Delete](ByVal Id As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@Id", Id)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("CostCentre_Delete") = 1)
        End Function

    End Class

End Namespace