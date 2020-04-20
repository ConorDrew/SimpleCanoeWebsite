Imports FSM.Entity.Sys

Namespace Entity.Vans.Equipments

    Public Class EquipmentSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get](ByVal vanId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@VanId", vanId)

            'Get the datatable from the database store in dt
            Dim dt As DataTable = _database.ExecuteSP_DataTable("VanEquipment_Get")
            dt.TableName = Enums.TableNames.tblVan.ToString
            Return New DataView(dt)
        End Function

        Public Function [Insert](ByVal VanId As Integer, ByVal equipment As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@VanId", VanId)
            _database.AddParameter("@Equipment", equipment)

            Return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("VanEquipment_Insert"))
        End Function

        Public Function [Delete](ByVal Id As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@Id", Id)

            Return Helper.MakeIntegerValid(_database.ExecuteSP_ReturnRowsAffected("VanEquipment_Delete"))
        End Function

    End Class

End Namespace