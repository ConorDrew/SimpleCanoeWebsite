Namespace Entity

    Namespace Sys

        Public Class SystemData

            Private Const _DataBaseServerType As Enums.DatabaseSystems = Enums.DatabaseSystems.Microsoft_SQL_Server

            Public ReadOnly Property DataBaseServerType() As Enums.DatabaseSystems
                Get
                    Return _DataBaseServerType
                End Get
            End Property

            Private _Configuration As New Configuration

            Public ReadOnly Property Configuration() As Configuration
                Get
                    Return _Configuration
                End Get
            End Property

            Private Const _DeletedPostfix As String = " (Deleted)"

            Public ReadOnly Property DeletedPostfix() As String
                Get
                    Return _DeletedPostfix
                End Get
            End Property

            Private Const _Title As String = "Field Service Manager - Beta"

            Public ReadOnly Property Title() As String
                Get
                    Return _Title
                End Get
            End Property

            Private Const _Description As String = "Field Management System"

            Public ReadOnly Property Description() As String
                Get
                    Return _Description
                End Get
            End Property

            Private Const _Company As String = "Gasway Services Ltd"

            Public ReadOnly Property Company() As String
                Get
                    Return _Company
                End Get
            End Property

            Private Const _Product As String = "FSM"

            Public ReadOnly Property Product() As String
                Get
                    Return _Product
                End Get
            End Property

            Private Const _Copyright As String = "FSM"

            Public ReadOnly Property Copyright() As String
                Get
                    Return _Copyright
                End Get
            End Property

            Private Const _Trademark As String = "FSM"

            Public ReadOnly Property Trademark() As String
                Get
                    Return _Trademark
                End Get
            End Property

            Public ReadOnly Property DLLInformation() As DataTable
                Get
                    Dim dt As New DataTable
                    dt.Columns.Add("Name")
                    dt.Columns.Add("Version")
                    For Each assem As System.Reflection.AssemblyName In Me.GetType().Assembly.GetReferencedAssemblies
                        dt.Rows.Add(New String() {assem.Name, assem.Version.ToString()})
                    Next
                    dt.TableName = Enums.TableNames.NOT_IN_DATABASE_DLLs.ToString
                    Return dt
                End Get
            End Property

            Private Const _Address As String = "Exel Computer Systems plc" & vbCrLf & vbCrLf & "Bothe Hall" & vbCrLf & "Sawley" & vbCrLf & "Nottingham" & vbCrLf & "NG10 3XL"

            Public ReadOnly Property Address() As String
                Get
                    Return _Address
                End Get
            End Property

            Private Const _Telephone As String = "0115 946 0101"

            Public ReadOnly Property Telephone() As String
                Get
                    Return _Telephone
                End Get
            End Property

            Private Const _Fax As String = "0115 946 0101"""

            Public ReadOnly Property Fax() As String
                Get
                    Return _Fax
                End Get
            End Property

            Public ReadOnly Property ContactUs() As String
                Get
                    Return Address & vbCrLf & vbCrLf & vbCrLf & "Tel : " & Telephone & vbCrLf & vbCrLf & vbCrLf
                End Get
            End Property

        End Class

    End Namespace

End Namespace