Imports System.Collections.Generic
Imports System.Reflection
Imports System.Runtime.CompilerServices

Namespace Entity.Sys

    Public Class ObjectMap

        Public Shared Function DataTableToList(Of T As {Class, New})(ByVal table As DataTable) As List(Of T)
            Try
                Dim list As List(Of T) = New List(Of T)()

                For Each row As DataRow In table.AsEnumerable()
                    Dim obj As T = New T()

                    For Each prop As PropertyInfo In obj.[GetType]().GetProperties()

                        Try
                            Dim propertyInfo As PropertyInfo = obj.[GetType]().GetProperty(prop.Name)
                            propertyInfo.SetValue(obj, Convert.ChangeType(row(prop.Name), propertyInfo.PropertyType), Nothing)
                        Catch
                            Continue For
                        End Try
                    Next

                    list.Add(obj)
                Next

                Return list
            Catch
                Return Nothing
            End Try
        End Function

    End Class

End Namespace