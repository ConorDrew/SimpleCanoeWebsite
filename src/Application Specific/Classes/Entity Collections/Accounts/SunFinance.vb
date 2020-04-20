Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Entity

    Namespace Accounts

        Public Class SSC

            Public Property Payload() As Payload = Nothing

            Public Function SaveToXml() As Boolean
                Try
                    Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)
                    'processing file location
                    Dim folderToSaveTo As New FolderBrowserDialog
                    folderToSaveTo.ShowDialog()

                    If folderToSaveTo.SelectedPath.Trim.Length = 0 Then Exit Function

                    Dim pFilePath As String = folderToSaveTo.SelectedPath & "\" &
                        "S_Legder_Export_" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & "_" & Now.ToString("HHmmss") & ".xml"

                    Dim fileStream As FileStream = New FileStream(pFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                    fileStream.Close()

                    Dim writer As New StreamWriter(pFilePath)
                    x.Serialize(writer, Me)
                    writer.Close()
                    Return True
                Catch ex As Exception
                    ShowMessage("Error converting to xml: " & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Finally
                End Try
            End Function

        End Class

        Public Class Payload
            Public Property Ledger() As New List(Of Line)
        End Class

        <Serializable()>
        Public Class Line
            Implements ICloneable
            Public Property AccountCode() As String = Nothing
            Public Property AccountingPeriod() As String = Nothing
            Public Property AnalysisCode1() As String = "NRS001" 'T1 Georgraphy
            Public Property AnalysisCode2() As String = Nothing 'T2 Department
            Public Property AnalysisCode3() As String = Nothing 'T3 Not used
            Public Property AnalysisCode4() As String = Nothing 'T4 Work Type
            Public Property AnalysisCode5() As String = Nothing 'T5 VAT
            Public Property AnalysisCode6() As String = Nothing 'T6 Debit Type
            Public Property AnalysisCode7() As String = Nothing 'T7 Supplier/Customer Code
            Public Property AnalysisCode8() As String = Nothing 'T8 Not Used
            Public Property AnalysisCode9() As String = Nothing 'T9 Purchase Order No
            Public Property DebitCredit() As String = Nothing
            Public Property Description() As String = Nothing
            Public Property EntryDate() As String = Nothing
            Public Property JournalType() As String = Nothing
            Public Property TransactionAmount() As Double = Nothing
            Public Property TransactionAmountDecimalPlaces() As Integer = "2"
            Public Property TransactionDate() As String = Nothing
            Public Property TransactionReference() As String = Nothing

            Public Function Clone() As Object Implements ICloneable.Clone
                Dim m As New MemoryStream()
                Dim f As New BinaryFormatter()
                f.Serialize(m, Me)
                m.Seek(0, SeekOrigin.Begin)
                Return f.Deserialize(m)
            End Function
        End Class

    End Namespace

End Namespace

