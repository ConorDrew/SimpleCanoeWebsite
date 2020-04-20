Imports System.Linq
Imports FSM.Entity.CostCentres
Imports FSM.Entity.Customers
Imports FSM.Entity.Jobs
Imports FSM.Entity.Orders
Imports FSM.Entity.Sys

Namespace Business.Orders

    Public Class OrderControl

        Private _order As Order

        Public Sub New(ByVal order As Order)
            _order = order
        End Sub

        Public Function IsWithinJobSpendLimit() As Boolean
            Dim isValid As Boolean = False
            Dim job As Job = DB.Job.Job_Get_ByOrderID(_order.OrderID)

            If job Is Nothing Then
                isValid = True
            Else
                'ask business for the allowance
                Dim spendLimit As Decimal = GetJobSpendLimit(job.JobID)
                If spendLimit = -1 Then
                    isValid = True
                Else
                    If GetCurrentJobCost(job.JobID) > spendLimit Then
                        isValid = False
                    Else
                        isValid = True
                    End If
                End If
            End If

            Return isValid
        End Function

        Private Function GetJobSpendLimit(ByVal jobId As Integer) As Decimal
            Dim spendLimit As Decimal = -1
            Dim costCentre As CostCentre = DB.CostCentre.Get(jobId, Nothing, Entity.CostCentres.Enums.GetBy.JobId)?.FirstOrDefault()
            If costCentre IsNot Nothing AndAlso costCentre.JobSpendLimit > 0 Then
                spendLimit = costCentre.JobSpendLimit
            Else
                Dim customer As Customer = DB.Customer.Customer_Get_ByOrderID(_order.OrderID)
                If customer IsNot Nothing AndAlso customer.JobSpendLimit > 0 Then
                    spendLimit = customer.JobSpendLimit
                End If
            End If
            Return spendLimit
        End Function

        Private Function GetCurrentJobCost(ByVal jobId As Integer) As Decimal
            Dim dvPartsCost As DataView = DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(jobId)
            Dim total As Decimal = 0.0
            For Each row As DataRow In dvPartsCost.Table.Rows
                If Not Helper.MakeStringValid(row("Part")).Contains("IBC") Then
                    total += Helper.MakeDoubleValid(row("Cost"))
                End If
            Next
            Return total
        End Function

    End Class

End Namespace