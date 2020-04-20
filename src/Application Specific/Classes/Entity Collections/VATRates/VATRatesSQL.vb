Imports System.Data.SqlClient

Namespace Entity

    Namespace VATRatess

        Public Class VATRatesSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Function [VATRates_Get](ByVal VATRateID As Integer) As VATRates
                _database.ClearParameter()
                _database.AddParameter("@VATRateID", VATRateID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VATRates_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVATRates As New VATRates
                        With oVATRates
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVATRateID = dt.Rows(0).Item("VATRateID")
                            .SetVATRate = dt.Rows(0).Item("VATRate")
                            .DateIntroduced = CDate(dt.Rows(0).Item("DateIntroduced"))
                            .SetVATRateCode = dt.Rows(0).Item("VATRateCode")

                        End With
                        oVATRates.Exists = True
                        Return oVATRates
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [VATRates_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VATRates_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
                Return New DataView(dt)
            End Function

            Public Function [VATRates_GetAll_InputOrOutput](ByVal inputOrOutput As Char) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InputOrOutput", inputOrOutput)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VATRates_GetAll_InputOrOutput")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
                Return New DataView(dt)
            End Function

            Public Function [VATRates_GetAll_Valid]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VATRates_GetAll_Valid")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
                Return New DataView(dt)
            End Function

            Public Function VATRates_Get_ByDate(ByVal InvoiceDate As DateTime) As Integer
                _database.ClearParameter()
                _database.AddParameter("@InvoiceDate", InvoiceDate, True)
                Dim VatRateID As Integer = Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("VATRates_Get_ByDate"))
                Return VATRateID
            End Function

            Public Function [Insert](ByVal oVATRates As VATRates) As VATRates
                _database.ClearParameter()
                AddVATRatesParametersToCommand(oVATRates)

                oVATRates.SetVATRateID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("VATRates_Insert"))
                oVATRates.Exists = True
                Return oVATRates
            End Function

            Public Sub [Update](ByVal oVATRates As VATRates)
                _database.ClearParameter()
                _database.AddParameter("@VATRateID", oVATRates.VATRateID, True)
                AddVATRatesParametersToCommand(oVATRates)
                _database.ExecuteSP_NO_Return("VATRates_Update")
            End Sub

            Private Sub AddVATRatesParametersToCommand(ByRef oVATRates As VATRates)
                With _database
                    .AddParameter("@VATRate", oVATRates.VATRate, True)
                    .AddParameter("@DateIntroduced", oVATRates.DateIntroduced, True)
                    .AddParameter("@VATRateCode", oVATRates.VATRateCode, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


