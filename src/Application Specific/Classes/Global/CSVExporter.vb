Imports System.IO

Public Class CSVExporter

    Public Function CreateCSV(ByVal CSVData As DataView) As Boolean

        ' create our stream
        Dim stream As FileStream

        Dim StrFileName As String

        Dim fileBrowser As New SaveFileDialog
        fileBrowser.Title = "Please choose a file name for your CSV Export"
        fileBrowser.Filter = "CSV (Comma Delimited) (*.csv)|*.csv"

        If fileBrowser.ShowDialog() = DialogResult.OK Then
            StrFileName = fileBrowser.FileName
        End If

        If File.Exists(StrFileName) Then
            File.Delete(StrFileName)
        End If

        ' create our file - which conveniently gives us a stream to it.
        stream = File.Create(StrFileName)

        ' create a StreamWriter which lets us write to the file
        Dim writer As New StreamWriter(stream)

        Try

            ' First, we'll create a local CSV line. Then we'll write it. 
            For Each row As DataRow In CSVData.Table.Rows

                Dim str As String = String.Empty

                For Each item As Object In row.ItemArray
                    str += Entity.Sys.Helper.MakeStringValid(item) & ","
                Next

                writer.WriteLine(str)

            Next

            ' by the time we get here we should have everything set. Just close all the streams
            ' and we'll be set.
            writer.Close()
            stream.Close()

            ' Return how many records we processed

            Return True

        Catch ex As Exception

            Return False

        Finally

            ' close the writers
            writer.Close()
            stream.Close()

        End Try

    End Function
End Class


