Imports System.IO
Imports DocumentFormat.OpenXml.Packaging

Namespace Entity.Sys

    Public Class TemplateHelper

        Public Shared Function AddTemplate() As Byte()
            Dim dlg As New OpenFileDialog
            Dim doc As Byte() = Nothing
            If dlg.ShowDialog = DialogResult.OK Then
                If Not String.IsNullOrEmpty(dlg.FileName) Then
                    Cursor.Current = Cursors.WaitCursor
                    doc = ReadWordDoc(dlg.FileName)
                    Cursor.Current = Cursors.Default
                End If
            End If
            Return doc
        End Function

        Public Shared Function ReadWordDoc(ByVal file As String) As Byte()
            Cursor.Current = Cursors.WaitCursor
            If Path.GetExtension(file) <> ".docx" Then
                Throw New Exception("Invalid File Extension." & vbCrLf & vbCrLf & ".docx Files Only!")
            End If

            Dim fileStream As New FileStream(file, FileMode.Open)
            Dim binaryReader As New BinaryReader(fileStream)

            Dim doc As Byte() = binaryReader.ReadBytes(fileStream.Length)

            binaryReader.Close()
            fileStream.Close()

            Return doc
            Cursor.Current = Cursors.Default
        End Function

        Private Shared Sub WriteWordDoc(ByVal fileName As String, ByVal data As Byte())
            Dim fs As New FileStream(fileName, FileMode.Create)
            Dim bw As New BinaryWriter(fs)

            bw.Write(data)

            bw.Close()
            fs.Close()
        End Sub

        Public Shared Sub TestTemplate(ByVal template As Byte(), ByVal templateType As Enums.TemplateType)
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim filePath As String = String.Empty
                Dim saveDir As New FolderBrowserDialog
                saveDir.ShowDialog()
                If saveDir.SelectedPath.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Select Case templateType
                        Case Enums.TemplateType.ServiceLetter
                            filePath = saveDir.SelectedPath & "\ServiceLetter_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".docx"
                            TestServiceLetter(template, filePath)
                    End Select
                End If
            Catch ex As Exception
                Debugger.Break()
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End Sub

        Private Shared Sub TestServiceLetter(ByVal template As Byte(), ByVal savePath As String)
            Dim mm As MemoryStream = New MemoryStream()
            Using mm
                mm.Write(template, 0, template.Length)
                Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                Using doc
                    Dim companyDetails As CompanyDetails.CompanyDetails = DB.CompanyDetails.Get()
                    PrintHelper.ReplaceText(doc, "$Customer", companyDetails.Name)
                    PrintHelper.ReplaceText(doc, "$Address1", companyDetails.Address1)
                    PrintHelper.ReplaceText(doc, "$Address2", companyDetails.Address2)
                    PrintHelper.ReplaceText(doc, "$Address3", companyDetails.Address3)
                    PrintHelper.ReplaceText(doc, "$Address4", companyDetails.Address4)
                    PrintHelper.ReplaceText(doc, "$Address5", companyDetails.Address5)
                    PrintHelper.ReplaceText(doc, "$Postcode", Helper.FormatPostcode(companyDetails.Postcode))
                    PrintHelper.ReplaceText(doc, "$TheDate", DateTime.Now.ToString("dd/MM/yyyy"))
                    PrintHelper.ReplaceText(doc, "$Date", DateTime.Now.ToString("dddd, dd/MM/yyyy"))
                    PrintHelper.ReplaceText(doc, "$Expiry", DateTime.Now.AddDays(366).ToString("dd/MM/yyyy"))

                    PrintHelper.ReplaceText(doc, "$Name", companyDetails.Name)
                    If DateTime.Now.Hour > 12 Then
                        PrintHelper.ReplaceText(doc, "$AMPM", "between 12:00pm and 5:30pm")
                    Else
                        PrintHelper.ReplaceText(doc, "$AMPM", "between 8:00am and 1:00pm")
                    End If
                    PrintHelper.ReplaceText(doc, "$GasCharge", "£41.37")
                    PrintHelper.ReplaceText(doc, "$CarpCharge", "£97.76")
                    PrintHelper.ReplaceText(doc, "$JobRef", "C_TestTemplate")
                End Using
                Dim fileStream As FileStream = New FileStream(savePath, FileMode.CreateNew)
                mm.Position = 0
                Using (fileStream)
                    mm.WriteTo(fileStream)
                End Using
                fileStream.Close()

                Process.Start(savePath)
            End Using
        End Sub

        Public Shared Sub DownloadTemplate(ByVal template As Byte())
            Try
                Cursor.Current = Cursors.WaitCursor
                Dim filename As String = "Template_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".docx"
                Dim saveDir As New FolderBrowserDialog
                saveDir.ShowDialog()
                If saveDir.SelectedPath.Trim.Length = 0 Then
                    Exit Sub
                Else
                    WriteWordDoc(saveDir.SelectedPath & "\" & filename, template)
                    Process.Start(saveDir.SelectedPath & "\" & filename)
                End If
            Catch ex As Exception
                Debugger.Break()
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End Sub

    End Class

End Namespace