Imports System.Data.SqlClient

Namespace Entity

    Namespace JobInstalls

        Public Class JobInstallSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Function [JobINstall_GetFor_JobID](ByVal JobID As Integer) As JobInstall
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobInstall_GetFor_JobID")
                Dim oJobInstall As New JobInstall
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then

                        With oJobInstall
                            .IgnoreExceptionsOnSetMethods = True
                            .SetJobInstallID = dt.Rows(0).Item("JobInstallID")
                            .SetJobID = dt.Rows(0).Item("JobID")
                            .SetSurveyed = dt.Rows(0).Item("Surveyed")
                            .SetDeposit = dt.Rows(0).Item("Deposit")
                            .SetPOStatus = dt.Rows(0).Item("POStatus")
                            .SetEngCalledSuper = dt.Rows(0).Item("EngCalledSuper")
                            .SetExtraLabour = dt.Rows(0).Item("ExtraLabour")
                            .SetFurtherWorks = dt.Rows(0).Item("FurtherWorks")
                            .SetPaymentTaken = dt.Rows(0).Item("PaymentTaken")
                            .SetQC = dt.Rows(0).Item("QcCarriedOut")
                            .SetPaperWork = dt.Rows(0).Item("PaperWorkReturned")
                            .SetEstPartCost = dt.Rows(0).Item("EstPartCost")
                            .SetactPartCost = dt.Rows(0).Item("ActPartCost")
                            .SetEstLabourCost = dt.Rows(0).Item("EstLabourCost")
                            .SetactLabourCost = dt.Rows(0).Item("ActLabourCost")
                            .SetEstTotalCost = dt.Rows(0).Item("EstTotalCost")
                            .SetactTotalCost = dt.Rows(0).Item("ActTotalCost")
                            .SetEstProfitMoney = dt.Rows(0).Item("EstProfitMoney")
                            .SetActProfitMoney = dt.Rows(0).Item("ActProfitMoney")
                            .SetEstProfitPerc = dt.Rows(0).Item("EstProfitPerc")
                            .SetActProfitPerc = dt.Rows(0).Item("ActProfitPerc")
                            .SetQuotedAmount = dt.Rows(0).Item("QuotedAmount")
                            .SetEstElecCost = dt.Rows(0).Item("EstElectrical")
                            .SetManual = dt.Rows(0).Item("Manual")
                            .SetSubConEst = dt.Rows(0).Item("EstSubCon")

                        End With
                        oJobInstall.Exists = True

                    End If


                    _database.ClearParameter()
                    _database.AddParameter("@JobID", JobID)

                    'Get the datatable from the database store in dt
                    dt = _database.ExecuteSP_DataTable("JobInstall_GetCostsFor_JobID")
                    oJobInstall.SetactPartCost = dt.Rows(0).Item("ActPartCost")
                    oJobInstall.SetactLabourCost = dt.Rows(0).Item("ActLabourCost")
                    oJobInstall.SetSupplierInvoice = dt.Rows(0).Item("SupplierInvoice")
                    oJobInstall.SetactElecCost = dt.Rows(0).Item("ElectricalPO")
                    oJobInstall.SetSubConPO = dt.Rows(0).Item("SubPO")
                    oJobInstall.SetSubConSI = dt.Rows(0).Item("SubSI")
                    oJobInstall.SetPaymentTaken = dt.Rows(0).Item("Charge")


                    If (Not IsDBNull(dt.Rows(0).Item("SupplierInvoice"))) AndAlso dt.Rows(0).Item("SupplierInvoice") > 0 Then
                        oJobInstall.SIExists = True
                    End If

                    Dim Subby As Double = 0

                    If oJobInstall.SubConSI <> 0 Then
                        Subby = oJobInstall.SubConSI
                    Else
                        Subby = oJobInstall.SubConPO
                    End If


                    'Actual Calcs
                    If oJobInstall.SIExists = True Then
                        oJobInstall.SetactTotalCost = oJobInstall.SupplierInvoice + oJobInstall.actLabourCost + oJobInstall.actElecCost + Subby + oJobInstall.Manual
                    Else
                        oJobInstall.SetactTotalCost = oJobInstall.actPartCost + oJobInstall.actLabourCost + oJobInstall.actElecCost + Subby + oJobInstall.Manual
                    End If

                    oJobInstall.SetActProfitMoney = oJobInstall.PaymentTaken - oJobInstall.actTotalCost
                    oJobInstall.SetActProfitPerc = Math.Round(CDbl(oJobInstall.ActProfitMoney) / CDbl(CDbl(oJobInstall.PaymentTaken)), 4) * 100


                    'Estimate calcs
                    oJobInstall.SetEstTotalCost = oJobInstall.EstPartCost + oJobInstall.EstLabourCost + oJobInstall.EstElecCost
                    oJobInstall.SetEstProfitMoney = oJobInstall.QuotedAmount - oJobInstall.EstTotalCost
                    oJobInstall.SetEstProfitPerc = Math.Round(CDbl(oJobInstall.EstProfitMoney) / CDbl(CDbl(oJobInstall.QuotedAmount)), 4) * 100



                    Return oJobInstall
                Else
                    Return Nothing
                End If


                Dim red As Entity.Orders.Order



            End Function









            Public Function [Insert](ByVal oJobInstall As JobInstall) As JobInstall
                _database.ClearParameter()
                AddEngineerVisitQCParametersToCommand(oJobInstall)

                oJobInstall.SetJobInstallID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobInstall_Insert"))
                oJobInstall.Exists = True
                Return oJobInstall
            End Function


            Public Sub [Update](ByVal oJobInstall As JobInstall)
                _database.ClearParameter()

                AddEngineerVisitQCParametersToCommand(oJobInstall)
                _database.ExecuteSP_NO_Return("JobInstall_Update")
            End Sub

            Private Sub AddEngineerVisitQCParametersToCommand(ByRef oJobInstall As JobInstall)
                With _database

                    _database.AddParameter("@JobInstallID", oJobInstall.JobInstallID, True)

                    .AddParameter("@JobID", oJobInstall.JobID, True)
                    .AddParameter("@Surveyed", oJobInstall.Surveyed, True)
                    .AddParameter("@Deposit", oJobInstall.Deposit, True)
                    .AddParameter("@POStatus", oJobInstall.POStatus, True)
                    .AddParameter("@EngCalledSuper", oJobInstall.EngCalledSuper, True)
                    .AddParameter("@ExtraLabour", oJobInstall.ExtraLabour, True)
                    .AddParameter("@FurtherWorks", oJobInstall.FurtherWorks, True)
                    .AddParameter("@PaymentTaken", oJobInstall.PaymentTaken, True)
                    .AddParameter("@QcCarriedOut", oJobInstall.QC, True)
                    .AddParameter("@PaperWorkReturned", oJobInstall.PaperWork, True)
                    .AddParameter("@EstPartCost", oJobInstall.EstPartCost, True)
                    .AddParameter("@ActPartCost", oJobInstall.actPartCost, True)
                    .AddParameter("@EstLabourCost", oJobInstall.EstLabourCost, True)
                    .AddParameter("@ActLabourCost", oJobInstall.actLabourCost, True)
                    .AddParameter("@EstTotalCost", oJobInstall.EstTotalCost, True)
                    .AddParameter("@ActTotalCost", oJobInstall.actTotalCost, True)
                    .AddParameter("@EstProfitMoney", oJobInstall.EstProfitMoney, True)
                    .AddParameter("@ActProfitMoney", oJobInstall.ActProfitMoney, True)
                    .AddParameter("@EstProfitPerc", 0, True) ' RD
                    .AddParameter("@ActProfitPerc", 0, True) 'RD
                    .AddParameter("@QuotedAmount", oJobInstall.QuotedAmount, True)
                    .AddParameter("@EstElectrical", oJobInstall.EstElecCost, True)
                    .AddParameter("@Manual", oJobInstall.Manual, True)
                    .AddParameter("@EstSubCon", oJobInstall.SubConEst, True)

                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


