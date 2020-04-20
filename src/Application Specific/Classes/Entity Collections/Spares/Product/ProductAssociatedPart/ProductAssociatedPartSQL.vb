Imports System.Data.SqlClient

Namespace Entity

    Namespace ProductAssociatedParts

        Public Class ProductAssociatedPartSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [GetAll_For_ProductID](ByVal ProductID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductAssociatedPart_GetAll_For_ProductID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductAssociatedPart.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Insert](ByVal oProductAssociatedPart As ProductAssociatedPart)
                _database.ClearParameter()
                AddProductAssociatedPartParametersToCommand(oProductAssociatedPart)

                _database.ExecuteSP_NO_Return("ProductAssociatedPart_Insert")

            End Sub

            Public Sub Delete(ByVal ProductID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID, True)
                _database.ExecuteSP_NO_Return("ProductAssociatedPart_Delete")
            End Sub

            Private Sub AddProductAssociatedPartParametersToCommand(ByRef oProductAssociatedPart As ProductAssociatedPart)
                With _database
                    .AddParameter("@ProductID", oProductAssociatedPart.ProductID, True)
                    .AddParameter("@PartID", oProductAssociatedPart.PartID, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


