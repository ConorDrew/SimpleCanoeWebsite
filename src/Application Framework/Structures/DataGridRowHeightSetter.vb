Imports System
Imports System.Reflection

Public Class DataGridRowHeightSetter

    Private dg As DataGrid
    Private rowObjects As ArrayList

    Public Sub New(ByVal dg As DataGrid)
        Me.dg = dg
        InitHeights()
    End Sub

    Default Public Property Item(ByVal row As Integer) As Integer
        Get
            Try
                Dim pi As PropertyInfo = rowObjects(row).GetType().GetProperty("Height")
                Return Fix(pi.GetValue(rowObjects(row), Nothing))
            Catch
                Throw New ArgumentException("invalid row index")
            End Try
        End Get
        Set(ByVal Value As Integer)
            Try
                Dim pi As PropertyInfo = rowObjects(row).GetType().GetProperty("Height")
                pi.SetValue(rowObjects(row), Value, Nothing)
            Catch
                Throw New ArgumentException("Invalid row index")
            End Try
        End Set
    End Property

    Private Sub InitHeights()
        Dim mi As MethodInfo = dg.GetType().GetMethod("get_DataGridRows", BindingFlags.FlattenHierarchy Or BindingFlags.IgnoreCase Or BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Static)

        Dim dgra As System.Array = CType(mi.Invoke(Me.dg, Nothing), System.Array)

        rowObjects = New ArrayList
        Dim dgrr As Object
        For Each dgrr In dgra
            If dgrr.ToString().EndsWith("DataGridRelationshipRow") = True Then
                rowObjects.Add(dgrr)
            End If
        Next dgrr
    End Sub

End Class
