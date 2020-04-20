Imports System.IO
Imports System.Xml.Serialization

Public Class XmlPersister

#Region " accessors "

    Private Shared _defaultfolder As String = String.Empty

    Public Shared Property DefaultFolder() As String
        Get
            Return _defaultfolder
        End Get
        Set(ByVal Value As String)
            If Value.EndsWith("\bin") Then
                Value = Value.Remove(Value.Length - 3, 3)
            End If
            If Not Value.EndsWith("\") Then Value += "\"
            _defaultfolder = Value
        End Set
    End Property

#End Region

#Region " shared serialise methods "

    Public Shared Function DefaultListExits(ByVal objectType As Type) As Boolean
        Dim myName As String
        myName = String.Format("{0}{1}.xml", XmlPersister.DefaultFolder, objectType.Name)
        Return XmlPersister.Exists(myName)
    End Function

    Public Shared Function Exists(ByVal persistName As String)

        Try
            Dim myIO As New System.IO.FileStream(persistName, FileMode.Open)
            myIO.Close()
            Return True
        Catch ex As Exception
            If ex.GetType.Name = "FileNotFoundException" Then
                Return False
            End If
        End Try

    End Function

    Public Shared Function GetDefaultList(ByVal objectType As Type) As IPersistable
        Dim myName As String
        myName = String.Format("{0}{1}.xml", XmlPersister.DefaultFolder, objectType.Name)
        Return XmlPersister.Read(myName, objectType)
    End Function

    Public Shared Function Read(ByVal persistName As String, _
                                ByVal objectType As Type) As IPersistable

        Dim myObject As IPersistable

        Try

            Dim mySerializer As XmlSerializer = New XmlSerializer([objectType])
            Dim myStream As FileStream = New FileStream(persistName, FileMode.Open)

            Try

                myObject = mySerializer.Deserialize(myStream)
                myStream.Close()

                myObject.HasBeenPersisted = True
                myObject.PersistName = persistName

            Catch ex As Exception

                System.Diagnostics.Debug.Assert(False, ex.Message)

            End Try

        Catch ex As Exception

            System.Diagnostics.Debug.Assert(False, ex.Message)

        End Try

        Return myObject

    End Function

    Public Shared Function Write(ByVal persistableObject As IPersistable)

        Dim myObject As Object = persistableObject

        If persistableObject.PersistName = persistableObject.CurrentLocation Then

            persistableObject.PersistName = persistableObject.CurrentLocation + _
                                            persistableObject.DefaultName

        End If


        Dim mySerializer As XmlSerializer = New XmlSerializer(myObject.GetType())
        Dim myStream As StreamWriter = New StreamWriter(persistableObject.PersistName)

        Try

            mySerializer.Serialize(myStream, myObject)
            persistableObject.HasBeenPersisted = True

        Catch ex As Exception

            System.Diagnostics.Debug.Assert(False, ex.Message)

        End Try

        myStream.Close()

    End Function

#End Region

End Class
