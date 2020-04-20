Namespace Entity
    Public Class StockTakeAuditSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub
        Private Sub AddStockTakeAuditParametersToCommand(ByVal oStockTakeAudit As StockTakeAudit)
            _database.AddParameter("@PartID", oStockTakeAudit.PartID, True)
            _database.AddParameter("@UserID", loggedInUser.UserID, True)
            _database.AddParameter("@OriginalAmount", oStockTakeAudit.OriginalAmount, True)
            _database.AddParameter("@NewAmount", oStockTakeAudit.NewAmount, True)
            _database.AddParameter("@ReasonChangeID", oStockTakeAudit.ReasonChange, True)
            _database.AddParameter("@LocationID", oStockTakeAudit.LocationID, True)
        End Sub
        Public Function [Insert](ByVal oStockTakeAudit As StockTakeAudit) As StockTakeAudit
            _database.ClearParameter()
            AddStockTakeAuditParametersToCommand(oStockTakeAudit)

            oStockTakeAudit.SetStockTakeAuditID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("StockTakeAudit_Insert"))
            oStockTakeAudit.Exists = True
            Return oStockTakeAudit
        End Function
    End Class
End Namespace
