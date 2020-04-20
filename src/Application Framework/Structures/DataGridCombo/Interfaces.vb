Public Module Interfaces

    Public Interface IPersistable

        Property CurrentLocation() As String
        ReadOnly Property DefaultName() As String
        Property HasBeenPersisted() As Boolean
        Property PersistName() As String

    End Interface

End Module
