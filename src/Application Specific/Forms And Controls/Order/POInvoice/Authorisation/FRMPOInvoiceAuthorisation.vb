Public Class FRMPOInvoiceAuthorisation : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboValidateType, DynamicDataTables.POInvoiceAuthorisation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
        End Select

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents grpExcelFile As System.Windows.Forms.GroupBox

    Friend WithEvents tcData As System.Windows.Forms.TabControl
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents btnExportResults As System.Windows.Forms.Button
    Friend WithEvents cboValidateType As System.Windows.Forms.ComboBox
    Friend WithEvents grpCatImport As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.btnExportResults = New System.Windows.Forms.Button()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.cboValidateType = New System.Windows.Forms.ComboBox()
        Me.grpCatImport = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.grpExcelFile.SuspendLayout()
        Me.grpCatImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Controls.Add(Me.btnExportResults)
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(231, 57)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Initial Import"
        '
        'btnExportResults
        '
        Me.btnExportResults.Location = New System.Drawing.Point(6, 19)
        Me.btnExportResults.Name = "btnExportResults"
        Me.btnExportResults.Size = New System.Drawing.Size(106, 23)
        Me.btnExportResults.TabIndex = 5
        Me.btnExportResults.Text = "Export Results"
        Me.btnExportResults.UseVisualStyleBackColor = True
        '
        'tcData
        '
        Me.tcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcData.Location = New System.Drawing.Point(8, 103)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(1053, 483)
        Me.tcData.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1005, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(8, 621)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(941, 23)
        Me.pbStatus.Step = 1
        Me.pbStatus.TabIndex = 10
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(957, 624)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(40, 16)
        Me.lblProgress.TabIndex = 11
        Me.lblProgress.Text = "0%"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessages
        '
        Me.lblMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessages.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessages.ForeColor = System.Drawing.Color.Red
        Me.lblMessages.Location = New System.Drawing.Point(5, 594)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(1057, 19)
        Me.lblMessages.TabIndex = 12
        Me.lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessages.Visible = False
        '
        'cboValidateType
        '
        Me.cboValidateType.FormattingEnabled = True
        Me.cboValidateType.Location = New System.Drawing.Point(6, 21)
        Me.cboValidateType.Name = "cboValidateType"
        Me.cboValidateType.Size = New System.Drawing.Size(365, 21)
        Me.cboValidateType.TabIndex = 1
        '
        'grpCatImport
        '
        Me.grpCatImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCatImport.Controls.Add(Me.Label1)
        Me.grpCatImport.Controls.Add(Me.cboDepartment)
        Me.grpCatImport.Controls.Add(Me.cboValidateType)
        Me.grpCatImport.Location = New System.Drawing.Point(245, 40)
        Me.grpCatImport.Name = "grpCatImport"
        Me.grpCatImport.Size = New System.Drawing.Size(816, 57)
        Me.grpCatImport.TabIndex = 6
        Me.grpCatImport.TabStop = False
        Me.grpCatImport.Text = "Category Processing"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(377, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cost Centre :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDepartment
        '
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cboDepartment.Location = New System.Drawing.Point(467, 21)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(199, 21)
        Me.cboDepartment.TabIndex = 2
        '
        'FRMPOInvoiceAuthorisation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1101, 654)
        Me.Controls.Add(Me.grpCatImport)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tcData)
        Me.Controls.Add(Me.grpExcelFile)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMPOInvoiceAuthorisation"
        Me.Text = "PO Invoice Authorisation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.tcData, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.grpCatImport, 0)
        Me.grpExcelFile.ResumeLayout(False)
        Me.grpCatImport.ResumeLayout(False)
        Me.grpCatImport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnExportResults_Click(sender As System.Object, e As System.EventArgs) Handles btnExportResults.Click

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            Dim data As DataView
            Dim sheetName As String = ""

            Dim sql As String = ""
            If Combo.GetSelectedItemDescription(cboDepartment) = "" Then
                sql = "EXEC POInvoiceImport_ExportResultsAuthorisation " & Combo.GetSelectedItemValue(cboValidateType)
            Else
                sql = "EXEC POInvoiceImport_ExportResultsAuthorisation " & Combo.GetSelectedItemValue(cboValidateType) & ", " & Combo.GetSelectedItemValue(cboDepartment)
            End If

            data = New DataView(DB.ExecuteWithReturn(sql))

            If data.Count = 0 Then
                ShowMessage("No Data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            For Each col As DataColumn In data.Table.Columns
                If col.DataType Is System.Type.GetType("System.String") Then
                    For Each row As DataRow In data.Table.Rows
                        row.Item(col.ColumnName) = "'" & row.Item(col.ColumnName)
                    Next
                End If
            Next

            sheetName = "POInvoiceAuthExport" & CStr(Today).Replace("/", "")

            Dim exporter As New Entity.Sys.Exporting(data.Table, sheetName)
        Catch ex As Exception
            ShowMessage("Error exporting : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged, cboValidateType.SelectedIndexChanged
        Dim Department As String
        If Combo.GetSelectedItemDescription(cboDepartment) = "" Then
            Department = "%"
        Else
            If IsGasway Then
                Department = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(Me.cboDepartment))
            Else
                Department = Combo.GetSelectedItemValue(Me.cboDepartment)
            End If
        End If

        ShowData(Combo.GetSelectedItemValue(cboValidateType), Department)
    End Sub

#End Region

#Region "Functions"

    Public Sub ShowData(Optional ByVal ValidateType As Integer = 0, Optional ByVal Department As String = Nothing)
        Me.tcData.TabPages.Clear()

        Dim tp As New TabPage

        Dim data As New UCDataPOInvoiceAuthorisation
        data.Dock = DockStyle.Fill
        data.Data = DB.POInvoice.POInvoiceImport_RefreshData(ValidateType, Department)
        data.ValidateType = Combo.GetSelectedItemValue(cboValidateType)
        data.Department = Combo.GetSelectedItemValue(cboDepartment)
        tp.Text = "PO Invoice Authorisation Data (" & data.Data.Count & " Records)"

        tp.Controls.Add(data)
        Me.tcData.TabPages.Add(tp)
        Me.tcData.SelectedIndex = 0

        MoveProgressOn(True)
    End Sub

    Public Sub MoveProgressOn(Optional ByVal toMaximum As Boolean = False)
        If toMaximum Then
            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.lblProgress.Text = "100%"
        Else
            Me.pbStatus.Value += 1
            Me.lblProgress.Text = Math.Floor((Me.pbStatus.Value / Me.pbStatus.Maximum) * 100) & "%"
        End If
        Application.DoEvents()
    End Sub

#End Region

End Class