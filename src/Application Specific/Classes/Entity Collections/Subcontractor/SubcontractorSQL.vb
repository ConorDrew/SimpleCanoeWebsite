Imports System.Data.SqlClient

Namespace Entity

    Namespace Subcontractors

        Public Class SubcontractorSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal SubcontractorID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SubcontractorID", SubcontractorID, True)
                _database.ExecuteSP_NO_Return("Subcontractor_Delete")
            End Sub

            Public Function [Subcontractor_Get](ByVal SubcontractorID As Integer) As Subcontractor
                _database.ClearParameter()
                _database.AddParameter("@SubcontractorID", SubcontractorID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Subcontractor_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSubcontractor As New Subcontractor
                        With oSubcontractor
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSubcontractorID = dt.Rows(0).Item("SubcontractorID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetLinkToSupplierID = dt.Rows(0).Item("LinkToSupplierID")
                            If dt.Rows(0).Table.Columns.Contains("TaxRate") Then .SetTaxRate = dt.Rows(0).Item("TaxRate")
                        End With
                        oSubcontractor.Exists = True
                        Return oSubcontractor
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Subcontractor_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Subcontractor_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSubcontractor.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSubcontractor As Subcontractor) As Subcontractor
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", oSubcontractor.EngineerID, True)
                AddSubcontractorParametersToCommand(oSubcontractor)

                oSubcontractor.SetSubcontractorID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Subcontractor_Insert"))
                oSubcontractor.Exists = True
                Return oSubcontractor
            End Function

            Public Function [Subcontractor_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Subcontractor_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSubcontractor.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oSubcontractor As Subcontractor)
                _database.ClearParameter()
                _database.AddParameter("@SubcontractorID", oSubcontractor.SubcontractorID, True)
                AddSubcontractorParametersToCommand(oSubcontractor)
                _database.ExecuteSP_NO_Return("Subcontractor_Update")
            End Sub

            Private Sub AddSubcontractorParametersToCommand(ByRef oSubcontractor As Subcontractor)
                With _database
                    .AddParameter("@Name", oSubcontractor.Name, True)
                    .AddParameter("@Address1", oSubcontractor.Address1, True)
                    .AddParameter("@Address2", oSubcontractor.Address2, True)
                    .AddParameter("@Address3", oSubcontractor.Address3, True)
                    .AddParameter("@Address4", oSubcontractor.Address4, True)
                    .AddParameter("@Address5", oSubcontractor.Address5, True)
                    .AddParameter("@Postcode", oSubcontractor.Postcode, True)
                    .AddParameter("@TelephoneNum", oSubcontractor.TelephoneNum, True)
                    .AddParameter("@FaxNum", oSubcontractor.FaxNum, True)
                    .AddParameter("@EmailAddress", oSubcontractor.EmailAddress, True)
                    .AddParameter("@Notes", oSubcontractor.Notes, True)
                    .AddParameter("@LinkToSupplierID", oSubcontractor.LinkToSupplierID, True)
                    .AddParameter("@TaxRate", oSubcontractor.TaxRate, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace