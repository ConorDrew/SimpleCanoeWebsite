Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net.Mail
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Namespace Entity

    Namespace Sys

        Public Class Helper

#Region "Formatting and Make Valids"

            Public Shared Function MakeStringValid(ByVal o As Object) As String
                Try
                    If o Is Nothing Then
                        Return ""
                    ElseIf o Is System.DBNull.Value Then
                        Return ""
                    ElseIf o.GetType() Is GetType(String) AndAlso o = "vbcrlf" Then
                        Return ""
                    ElseIf o.GetType() Is GetType(String) AndAlso o = "&nbsp;" Then
                        Return ""
                    Else
                        Return CStr(o).Trim()
                    End If
                Catch
                    Return ""
                End Try
            End Function

            Public Shared Function MakeIntegerValid(ByVal o As Object) As Integer
                Try
                    If o Is Nothing Then
                        Return 0
                    ElseIf o Is System.DBNull.Value Then
                        Return 0
                    ElseIf CStr(o) = "" Then
                        Return 0
                    Else
                        Try
                            Return CInt(o)
                        Catch
                            Return 0
                        End Try
                    End If
                Catch
                    Return 0
                End Try
            End Function

            Public Shared Function IsValidInteger(ByVal o As Object) As Boolean
                Dim value As String = MakeStringValid(o)
                If Not IsNumeric(value) Then
                    Return False
                Else
                    Dim pos As Integer = InStr(value, ".")

                    If pos = 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End Function

            Public Shared Function MakeDoubleValid(ByVal o As Object) As Double
                Try
                    If o Is Nothing Then
                        Return 0.0
                    ElseIf o Is System.DBNull.Value Then
                        Return 0.0
                    ElseIf CStr(o) = "" Then
                        Return 0.0
                    ElseIf Double.IsNaN(o) Then
                        Return 0.0
                    Else
                        Try
                            Return CDbl(o)
                        Catch
                            Return 0.0
                        End Try
                    End If
                Catch
                    Return 0.0
                End Try
            End Function

            Public Shared Function RoundDown(ByVal number As Double, ByVal decimalPlaces As Integer) As Double
                Return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces)
            End Function

            Public Shared Function MakeBooleanValid(ByVal o As Object) As Boolean
                Try
                    Select Case TheSystem.DataBaseServerType
                        Case Entity.Sys.Enums.DatabaseSystems.MySQL
                            If o Is System.DBNull.Value Then
                                Return False
                            Else
                                Return CBool(CType(o, [SByte]).ToString)
                            End If
                        Case Entity.Sys.Enums.DatabaseSystems.Microsoft_SQL_Server
                            If o Is Nothing Then
                                Return False
                            ElseIf o Is System.DBNull.Value Then
                                Return False
                            Else
                                Return CBool(o)
                            End If
                    End Select
                Catch
                    Return False
                End Try
            End Function

            Public Shared Function MakeDateTimeValid(ByVal o As Object) As DateTime
                Try
                    If o Is Nothing Then
                        Return Nothing
                    ElseIf o Is System.DBNull.Value Then
                        Return Nothing
                    Else
                        Return FormatDateTime_Load(CDate(o))
                    End If
                Catch
                    Return Nothing
                End Try
            End Function

            Public Shared Function MakeNullableDateTimeValid(ByVal o As Object) As DateTime?
                If o Is Nothing Then
                    Return Nothing
                ElseIf o Is System.DBNull.Value Then
                    Return Nothing
                Else
                    Return FormatDateTime_Load(CDate(o))
                End If
            End Function

            Public Shared Function MakeTimeValid(ByVal o As Object) As TimeSpan
                If o Is Nothing Then
                    Return Nothing
                ElseIf o Is System.DBNull.Value Then
                    Return Nothing
                ElseIf Not o.GetType() Is GetType(TimeSpan) Then
                    Return Nothing
                Else
                    Return o
                End If
            End Function

            Public Shared Function FormatTime(ByVal o As String) As TimeSpan
                Dim time As String = Format(o, "HH:mm:ss")
                Return TimeSpan.Parse(time)
            End Function

            Public Shared Function FormatDateTime_Load(ByVal DateTime As DateTime) As String
                Return Format(DateTime, "dd/MMM/yyyy HH:mm:ss")
            End Function

            Public Shared Function CleanText(ByVal text As String) As String
                Return text.Replace(vbNewLine, " ").Replace("'", "''").Replace("""", """""").Replace("[", "[[").Replace("]", "]]").Trim
            End Function

            Public Shared Function RemoveSpecialCharacters(ByVal text As String) As String
                Dim removed As String = MakeStringValid(text)
                Return Regex.Replace(removed, "[^A-Za-z0-9\-\s/]", "")
            End Function

            Public Shared Function ToTitleCase(ByVal text As String) As String
                Dim textInfo As TextInfo = New CultureInfo("en-US", False).TextInfo
                text = textInfo.ToTitleCase(text.ToLower())
                Return text
            End Function

            Public Shared Function ToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
                'declare new datatable
                Dim dt As New DataTable()

                'if the list is empty then we return a blank table
                If list Is Nothing OrElse Not list.Any Then
                    Return dt
                End If
                'get all the class properties
                Dim fields() As PropertyInfo = list.First.GetType.GetProperties
                'use the class properties as column name
                For Each field As PropertyInfo In fields
                    dt.Columns.Add(field.Name, field.PropertyType)
                Next
                'populate datatable with values
                For Each item As T In list
                    Dim row As DataRow = dt.NewRow()
                    For Each field As PropertyInfo In fields
                        Dim p As Object = item.GetType.GetProperty(field.Name)
                        row(field.Name) = p.GetValue(item, Nothing)
                    Next
                    dt.Rows.Add(row)
                Next
                Return dt
            End Function

            Public Shared Function ValidatePhoneNumber(ByVal number As String) As Boolean
                Return Regex.Match(number, "^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$", RegexOptions.IgnoreCase).Success
            End Function

            Public Shared Function FormatPostcode(ByVal postcode As Object) As String
                Dim pc As String = MakeStringValid(postcode)
                If pc.Length < 3 Then Return pc
                pc = pc.Replace("-", "")
                pc = pc.ToUpper()
                pc = pc.Insert(pc.Length - 3, " ")
                Return pc
            End Function

            Public Shared Function ConvertToPostcode(ByVal postcode As Object) As String
                Dim pc As String = MakeStringValid(postcode).Trim()
                If pc.Length < 3 Then Return pc
                pc = pc.Replace(" ", "")
                pc = pc.ToUpper()
                pc = pc.Insert(pc.Length - 3, "-")
                Return pc
            End Function

            Public Shared Function IsEmailValid(ByVal email As String) As Boolean
                Try
                    Dim mail As New MailAddress(email)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Shared Function MakeFileNameValid(ByVal fileName As String) As String
                For Each c As Char In Path.GetInvalidFileNameChars()
                    fileName = fileName.Replace(c, "_")
                Next
                Return fileName
            End Function

            Public Shared Function GetNumber(ByVal value As Object) As Integer
                value = MakeStringValid(value)
                Dim number As String = String.Empty
                Dim myChars() As Char = value.ToCharArray()
                For Each ch As Char In myChars
                    If Char.IsDigit(ch) Then
                        number += ch
                    End If
                Next
                Return Convert.ToInt32(number)
            End Function

            Public Shared Function InsertDateIntoDb(ByVal [date] As DateTime) As Object
                If [date] = Nothing OrElse [date] = DateTime.MinValue Then
                    Return DBNull.Value
                End If
                Return [date]
            End Function

            Public Shared Function IsStringEmpty(ByVal value As Object) As Boolean
                value = MakeStringValid(value)
                Return String.IsNullOrEmpty(value) Or String.IsNullOrWhiteSpace(value)
            End Function

#End Region

#Region "Data Grids"

            'Set the format and data
            Public Shared Sub SetUpDataGrid(ByVal dg As DataGrid, Optional ByVal captionIsVisible As Boolean = False)
                dg.TableStyles.Clear()
                dg.TableStyles.Add(DefaultTableStyle)
                dg.AllowNavigation = False
                dg.CaptionVisible = captionIsVisible
                dg.AlternatingBackColor = System.Drawing.Color.White
                dg.BackgroundColor = System.Drawing.Color.White
                dg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                dg.CaptionBackColor = System.Drawing.Color.SteelBlue
                dg.CaptionForeColor = System.Drawing.Color.White
                dg.Font = New System.Drawing.Font("Verdana", 8.0!)
                dg.ForeColor = System.Drawing.Color.Navy
                dg.GridLineColor = System.Drawing.Color.LightSteelBlue
                dg.HeaderBackColor = System.Drawing.Color.SteelBlue
                dg.HeaderFont = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
                dg.HeaderForeColor = System.Drawing.Color.White
                dg.LinkColor = System.Drawing.Color.Navy
                dg.ParentRowsBackColor = System.Drawing.Color.White
                dg.ParentRowsForeColor = System.Drawing.Color.LightSteelBlue
                dg.ParentRowsVisible = False
                dg.RowHeadersVisible = False
                dg.SelectionBackColor = System.Drawing.Color.Gainsboro
                dg.SelectionForeColor = System.Drawing.Color.Navy
                dg.ReadOnly = True
                dg.Cursor = Cursors.Hand

                AddHandler dg.Click, AddressOf dGrid_Multievents
                AddHandler dg.CurrentCellChanged, AddressOf dGrid_Multievents

            End Sub

            'Fire the events required
            Public Shared Sub dGrid_Multievents(ByVal sender As Object, ByVal e As System.EventArgs)
                Dim dg As DataGrid = CType(sender, DataGrid)
                If dg.ReadOnly Then
                    If dg.CurrentCell.ColumnNumber > -1 And dg.CurrentRowIndex > -1 Then
                        dg.CurrentCell = New DataGridCell(dg.CurrentRowIndex, -1)
                        dg.Select(dg.CurrentRowIndex)
                    End If
                End If
            End Sub

            Public Shared Sub RemoveEventHandlers(ByVal dg As DataGrid)
                RemoveHandler dg.Click, AddressOf dGrid_Multievents
                RemoveHandler dg.CurrentCellChanged, AddressOf dGrid_Multievents
            End Sub

            'Set the style
            Public Shared Function DefaultTableStyle() As DataGridTableStyle
                Dim DataGridTableStyle1 As New DataGridTableStyle
                DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.White
                DataGridTableStyle1.BackColor = System.Drawing.Color.White
                DataGridTableStyle1.ForeColor = System.Drawing.Color.Navy
                DataGridTableStyle1.GridLineColor = System.Drawing.Color.LightSteelBlue
                DataGridTableStyle1.HeaderBackColor = System.Drawing.Color.SteelBlue
                DataGridTableStyle1.HeaderForeColor = System.Drawing.Color.White
                DataGridTableStyle1.LinkColor = System.Drawing.Color.Navy
                DataGridTableStyle1.MappingName = ""
                DataGridTableStyle1.ReadOnly = True
                DataGridTableStyle1.RowHeadersVisible = False
                DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
                DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.Navy
                Return DataGridTableStyle1
            End Function

#End Region

#Region "Data Grid Views"

            Public Shared Sub SetUpDataGridView(ByVal dgv As DataGridView, Optional ByVal captionIsVisible As Boolean = False)
                dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White
                dgv.BackgroundColor = System.Drawing.Color.White
                dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                dgv.Font = New System.Drawing.Font("Verdana", 8.0!)
                dgv.ForeColor = System.Drawing.Color.Navy
                dgv.GridColor = System.Drawing.Color.LightSteelBlue
                dgv.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue
                dgv.RowHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
                dgv.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
                dgv.RowHeadersVisible = True
                dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro
                dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy
                dgv.ReadOnly = False
                dgv.Cursor = Cursors.Hand
                dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue
                dgv.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
                dgv.RowHeadersVisible = False
                'AddHandler dgv.Click, AddressOf dGridView_Multievents
                'AddHandler dgv.CurrentCellChanged, AddressOf dGrid_Multievents

            End Sub

#End Region

#Region "GUI"

            Public Shared Sub ClearGroupBox(ByVal grp As GroupBox)
                For Each cntr As Control In grp.Controls
                    If TypeOf (cntr) Is TextBox Then
                        CType(cntr, TextBox).Text = ""
                    ElseIf TypeOf (cntr) Is ComboBox Then
                        Combo.SetSelectedComboItem_By_Value(CType(cntr, ComboBox), 0)
                    ElseIf TypeOf (cntr) Is CheckBox Then
                        CType(cntr, CheckBox).Checked = False
                    ElseIf TypeOf (cntr) Is NumericUpDown Then
                        CType(cntr, NumericUpDown).Value = 1
                    ElseIf TypeOf (cntr) Is RadioButton Then
                        CType(cntr, RadioButton).Checked = False
                    ElseIf TypeOf (cntr) Is DateTimePicker Then
                        CType(cntr, DateTimePicker).Value = Today.Date
                    End If
                Next
            End Sub

            Public Shared Sub ClearTabControl(ByVal tabcontrol As TabControl)
                For Each page As TabPage In tabcontrol.TabPages
                    For Each ctrl As Control In page.Controls
                        If TypeOf (ctrl) Is TextBox Then
                            CType(ctrl, TextBox).Text = ""
                        ElseIf TypeOf (ctrl) Is ComboBox Then
                            Combo.SetSelectedComboItem_By_Value(CType(ctrl, ComboBox), 0)
                        ElseIf TypeOf (ctrl) Is CheckBox Then
                            CType(ctrl, CheckBox).Checked = False
                        ElseIf TypeOf (ctrl) Is NumericUpDown Then
                            CType(ctrl, NumericUpDown).Value = 1
                        ElseIf TypeOf (ctrl) Is RadioButton Then
                            CType(ctrl, RadioButton).Checked = False
                        ElseIf TypeOf (ctrl) Is DateTimePicker Then
                            CType(ctrl, DateTimePicker).Value = Today.Date
                        End If
                    Next
                Next
            End Sub

            Public Shared Sub MakeReadOnly(ByVal grp As GroupBox, ByVal readOnlyState As Boolean)
                For Each cntr As Control In grp.Controls
                    If TypeOf (cntr) Is TextBox Then
                        CType(cntr, TextBox).ReadOnly = readOnlyState
                    ElseIf TypeOf (cntr) Is ComboBox Then
                        CType(cntr, ComboBox).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is CheckBox Then
                        CType(cntr, CheckBox).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is Button Then
                        CType(cntr, Button).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is TabControl Then
                        CType(cntr, TabControl).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is CheckedListBox Then
                        CType(cntr, CheckedListBox).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is DateTimePicker Then
                        CType(cntr, DateTimePicker).Enabled = Not readOnlyState
                    ElseIf TypeOf (cntr) Is DataGrid Then
                        CType(cntr, DataGrid).Enabled = Not readOnlyState
                    End If
                Next
            End Sub

            Public Shared Sub Setup_Button(ByRef btn As Button, ByVal caption As String)
                btn.FlatStyle = FlatStyle.Standard
                btn.ImageList = Nothing
                btn.ImageIndex = Nothing
                btn.Cursor = Cursors.Hand
                Dim hoverToolTip As New ToolTip
                hoverToolTip.SetToolTip(btn, caption)
            End Sub

#End Region

#Region "Functions"

            Public Shared Function HashPassword(ByVal password As String) As String
                Using hasher As MD5 = MD5.Create()
                    Dim dbytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(password))
                    Dim sBuilder As New StringBuilder()
                    For n As Integer = 0 To dbytes.Length - 1
                        sBuilder.Append(dbytes(n).ToString("X2"))
                    Next n
                    Return sBuilder.ToString()
                End Using
            End Function

            Public Shared Function GetTextResource(ByVal FileName As String) As String
                Dim assem As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim resStream As System.IO.Stream = assem.GetManifestResourceStream(TheSystem.Product & "." & FileName)
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(resStream)
                Dim returnText As String = reader.ReadToEnd()
                resStream.Close()
                Return returnText.Trim
            End Function

            Public Shared Function GetStream(ByVal FileName As String) As System.IO.Stream
                Dim assem As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Return assem.GetManifestResourceStream(TheSystem.Product & "." & FileName)
            End Function

            'Start any process on the client machine by filename
            Public Shared Sub StartProcess(ByVal filename As String)
                Cursor.Current = Cursors.WaitCursor
                System.Diagnostics.Process.Start(filename)
                Cursor.Current = Cursors.Default
            End Sub

            Public Shared Function CalculateDays(d1 As DateTime, d2 As DateTime) As Integer
                Return (d2.Date - d1.Date).TotalDays
            End Function

            Public Shared Function Distance(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double, ByVal unit As Char) As Double
                Dim theta As Double = lon1 - lon2
                Dim dist As Double = Math.Sin(DegToRad(lat1)) * Math.Sin(DegToRad(lat2)) + Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) * Math.Cos(DegToRad(theta))
                dist = Math.Acos(dist)
                dist = RadToDeg(dist)
                dist = dist * 60 * 1.1515
                If unit = "K" Then
                    dist = dist * 1.609344
                ElseIf unit = "N" Then
                    dist = dist * 0.8684
                End If
                Return dist
            End Function

            Public Shared Function DegToRad(ByVal deg As Double) As Double
                Return (deg * Math.PI / 180.0)
            End Function

            Public Shared Function RadToDeg(ByVal rad As Double) As Double
                Return rad / Math.PI * 180.0
            End Function

            Private Shared Function GenerateRandomPassword(ByVal length As Integer) As String
                Dim _chars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ[_!23456790"
                Dim randomBytes(length) As Byte
                Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
                rng.GetBytes(randomBytes)
                Dim chars(length) As Char
                Dim count As Integer = _chars.Length

                For i As Integer = 0 To length - 1
                    chars(i) = _chars(CInt(randomBytes(i)) Mod count)
                Next

                Return New String(chars)
            End Function

            Public Shared Function CreateRandomPassword(ByVal length As Integer) As String
                Dim pass As String = String.Empty
                While True
                    pass = GenerateRandomPassword(length)
                    Dim upper As Integer = 0, num As Integer = 0, special As Integer = 0, lower As Integer = 0

                    For Each c As Char In pass
                        If c > "A"c AndAlso c < "Z"c Then
                            upper += 1
                        ElseIf c > "a"c AndAlso c < "z"c Then
                            lower += 1
                        ElseIf c > "0"c AndAlso c < "9"c Then
                            num += 1
                        Else
                            special += 1
                        End If
                    Next

                    If upper >= 2 AndAlso num >= 1 AndAlso 1 >= special Then
                        Exit While
                    End If
                End While
                Return pass
            End Function

            Public Shared Function ContrastColor(ByVal color As Color) As Color
                Dim luma As Double = ((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B)) / 255
                Return If(luma > 0.5, Color.Black, Color.White)
            End Function

#End Region

        End Class

    End Namespace

End Namespace