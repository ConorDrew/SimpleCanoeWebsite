Imports System.Data.SqlClient

Namespace Entity

    Namespace TabletOrders

        Public Class TabletOrderSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [InsertTabletOrderItem](ByVal oTabletOrder As TabletOrderItem) As Integer
                _database.ClearParameter()
                _database.AddParameter("@OrderID", oTabletOrder.TabletOrderID, True)
                _database.AddParameter("@EngineerID", oTabletOrder.EngineerID, True)
                _database.AddParameter("@SupplierID", oTabletOrder.SupplierID, True)
                _database.AddParameter("@SelectedVisitID", oTabletOrder.SelectedVisitID, True)
                _database.AddParameter("@ForNextVisit", oTabletOrder.ForNextVisit, True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("TabletOrderItem_Insert"))
            End Function

            Public Function [InsertTabletOrderPart](ByVal oTabletOrderPart As TabletOrderPart) As Integer
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", oTabletOrderPart.OrderPartID, True)
                _database.AddParameter("@OrderID", oTabletOrderPart.OrderID, True)
                _database.AddParameter("@EngineerID", oTabletOrderPart.EngineerID, True)
                _database.AddParameter("@Quantity", oTabletOrderPart.Quantity, True)
                _database.AddParameter("@PartSupplierID", oTabletOrderPart.PartSupplierID, True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("TabletOrderPart_Insert"))
            End Function

#End Region

        End Class

    End Namespace

End Namespace


