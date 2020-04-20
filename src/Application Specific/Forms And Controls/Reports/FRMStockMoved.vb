Public Class FRMStockMoved : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grpAudit As System.Windows.Forms.GroupBox
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents radBoth As System.Windows.Forms.RadioButton
    Friend WithEvents radProducts As System.Windows.Forms.RadioButton
    Friend WithEvents radParts As System.Windows.Forms.RadioButton
    Friend WithEvents radFromVan As System.Windows.Forms.RadioButton
    Friend WithEvents radFromWarehouse As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents cboTo As System.Windows.Forms.ComboBox
    Friend WithEvents radToVan As System.Windows.Forms.RadioButton
    Friend WithEvents radToWarehouse As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgIPTAudit As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpAudit = New System.Windows.Forms.GroupBox()
        Me.dgIPTAudit = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radToWarehouse = New System.Windows.Forms.RadioButton()
        Me.radToVan = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.radFromWarehouse = New System.Windows.Forms.RadioButton()
        Me.radFromVan = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radParts = New System.Windows.Forms.RadioButton()
        Me.radProducts = New System.Windows.Forms.RadioButton()
        Me.radBoth = New System.Windows.Forms.RadioButton()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.cboTo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFrom = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpAudit.SuspendLayout()
        CType(Me.dgIPTAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpAudit
        '
        Me.grpAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAudit.Controls.Add(Me.dgIPTAudit)
        Me.grpAudit.Location = New System.Drawing.Point(8, 152)
        Me.grpAudit.Name = "grpAudit"
        Me.grpAudit.Size = New System.Drawing.Size(841, 278)
        Me.grpAudit.TabIndex = 1
        Me.grpAudit.TabStop = False
        Me.grpAudit.Text = "IPT Audit"
        '
        'dgIPTAudit
        '
        Me.dgIPTAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgIPTAudit.DataMember = ""
        Me.dgIPTAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgIPTAudit.Location = New System.Drawing.Point(8, 19)
        Me.dgIPTAudit.Name = "dgIPTAudit"
        Me.dgIPTAudit.Size = New System.Drawing.Size(825, 251)
        Me.dgIPTAudit.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 438)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.Panel3)
        Me.grpFilter.Controls.Add(Me.Panel2)
        Me.grpFilter.Controls.Add(Me.Panel1)
        Me.grpFilter.Controls.Add(Me.btnRun)
        Me.grpFilter.Controls.Add(Me.cboTo)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.cboFrom)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.txtName)
        Me.grpFilter.Controls.Add(Me.txtNumber)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.txtReference)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Location = New System.Drawing.Point(8, 38)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(841, 108)
        Me.grpFilter.TabIndex = 0
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.radToWarehouse)
        Me.Panel3.Controls.Add(Me.radToVan)
        Me.Panel3.Location = New System.Drawing.Point(442, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(196, 28)
        Me.Panel3.TabIndex = 27
        '
        'radToWarehouse
        '
        Me.radToWarehouse.AutoSize = True
        Me.radToWarehouse.Checked = True
        Me.radToWarehouse.Location = New System.Drawing.Point(3, 3)
        Me.radToWarehouse.Name = "radToWarehouse"
        Me.radToWarehouse.Size = New System.Drawing.Size(88, 17)
        Me.radToWarehouse.TabIndex = 9
        Me.radToWarehouse.TabStop = True
        Me.radToWarehouse.Text = "Warehouse"
        Me.radToWarehouse.UseVisualStyleBackColor = True
        '
        'radToVan
        '
        Me.radToVan.AutoSize = True
        Me.radToVan.Location = New System.Drawing.Point(98, 3)
        Me.radToVan.Name = "radToVan"
        Me.radToVan.Size = New System.Drawing.Size(97, 17)
        Me.radToVan.TabIndex = 10
        Me.radToVan.Text = "Stock Profile"
        Me.radToVan.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.radFromWarehouse)
        Me.Panel2.Controls.Add(Me.radFromVan)
        Me.Panel2.Location = New System.Drawing.Point(441, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(197, 26)
        Me.Panel2.TabIndex = 26
        '
        'radFromWarehouse
        '
        Me.radFromWarehouse.AutoSize = True
        Me.radFromWarehouse.Checked = True
        Me.radFromWarehouse.Location = New System.Drawing.Point(3, 3)
        Me.radFromWarehouse.Name = "radFromWarehouse"
        Me.radFromWarehouse.Size = New System.Drawing.Size(88, 17)
        Me.radFromWarehouse.TabIndex = 6
        Me.radFromWarehouse.TabStop = True
        Me.radFromWarehouse.Text = "Warehouse"
        Me.radFromWarehouse.UseVisualStyleBackColor = True
        '
        'radFromVan
        '
        Me.radFromVan.AutoSize = True
        Me.radFromVan.Location = New System.Drawing.Point(100, 3)
        Me.radFromVan.Name = "radFromVan"
        Me.radFromVan.Size = New System.Drawing.Size(97, 17)
        Me.radFromVan.TabIndex = 7
        Me.radFromVan.Text = "Stock Profile"
        Me.radFromVan.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radParts)
        Me.Panel1.Controls.Add(Me.radProducts)
        Me.Panel1.Controls.Add(Me.radBoth)
        Me.Panel1.Location = New System.Drawing.Point(5, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(82, 82)
        Me.Panel1.TabIndex = 25
        '
        'radParts
        '
        Me.radParts.AutoSize = True
        Me.radParts.Location = New System.Drawing.Point(3, 3)
        Me.radParts.Name = "radParts"
        Me.radParts.Size = New System.Drawing.Size(54, 17)
        Me.radParts.TabIndex = 0
        Me.radParts.Text = "Parts"
        Me.radParts.UseVisualStyleBackColor = True
        '
        'radProducts
        '
        Me.radProducts.AutoSize = True
        Me.radProducts.Location = New System.Drawing.Point(3, 33)
        Me.radProducts.Name = "radProducts"
        Me.radProducts.Size = New System.Drawing.Size(74, 17)
        Me.radProducts.TabIndex = 1
        Me.radProducts.Text = "Products"
        Me.radProducts.UseVisualStyleBackColor = True
        '
        'radBoth
        '
        Me.radBoth.AutoSize = True
        Me.radBoth.Checked = True
        Me.radBoth.Location = New System.Drawing.Point(3, 60)
        Me.radBoth.Name = "radBoth"
        Me.radBoth.Size = New System.Drawing.Size(51, 17)
        Me.radBoth.TabIndex = 2
        Me.radBoth.TabStop = True
        Me.radBoth.Text = "Both"
        Me.radBoth.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(781, 78)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(52, 23)
        Me.btnRun.TabIndex = 12
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'cboTo
        '
        Me.cboTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTo.FormattingEnabled = True
        Me.cboTo.Location = New System.Drawing.Point(644, 49)
        Me.cboTo.Name = "cboTo"
        Me.cboTo.Size = New System.Drawing.Size(189, 21)
        Me.cboTo.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(358, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 18)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Moved To"
        '
        'cboFrom
        '
        Me.cboFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFrom.FormattingEnabled = True
        Me.cboFrom.Location = New System.Drawing.Point(644, 22)
        Me.cboFrom.Name = "cboFrom"
        Me.cboFrom.Size = New System.Drawing.Size(189, 21)
        Me.cboFrom.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(358, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Moved From"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(158, 49)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(194, 21)
        Me.txtName.TabIndex = 4
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(158, 22)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(194, 21)
        Me.txtNumber.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(87, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Reference"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(87, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Name"
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(158, 76)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(194, 21)
        Me.txtReference.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(87, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Number"
        '
        'FRMStockMoved
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(857, 468)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpAudit)
        Me.MinimumSize = New System.Drawing.Size(873, 506)
        Me.Name = "FRMStockMoved"
        Me.Text = "Stock Moved Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpAudit, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpAudit.ResumeLayout(False)
        CType(Me.dgIPTAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupDataGrid()

        Combo.SetUpCombo(Me.cboFrom, DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Me.cboFrom.SelectedIndex = 0

        Combo.SetUpCombo(Me.cboTo, DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Me.cboTo.SelectedIndex = 0
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _AuditDataview As DataView
    Private Property AuditDataview() As DataView
        Get
            Return _AuditDataview
        End Get
        Set(ByVal value As DataView)
            _AuditDataview = value
            _AuditDataview.AllowNew = False
            _AuditDataview.AllowEdit = False
            _AuditDataview.AllowDelete = False
            _AuditDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblIPTAudit.ToString
            Me.dgIPTAudit.DataSource = AuditDataview
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgIPTAudit.CurrentRowIndex = -1 Then
                Return AuditDataview(Me.dgIPTAudit.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgIPTAudit.TableStyles(0)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 50
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 150
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim Number As New DataGridLabelColumn
        Number.Format = ""
        Number.FormatInfo = Nothing
        Number.HeaderText = "Number"
        Number.MappingName = "Number"
        Number.ReadOnly = True
        Number.Width = 75
        Number.NullText = ""
        tbStyle.GridColumnStyles.Add(Number)

        Dim Reference As New DataGridLabelColumn
        Reference.Format = ""
        Reference.FormatInfo = Nothing
        Reference.HeaderText = "Reference"
        Reference.MappingName = "Reference"
        Reference.ReadOnly = True
        Reference.Width = 75
        Reference.NullText = ""
        tbStyle.GridColumnStyles.Add(Reference)

        Dim Quantity As New DataGridLabelColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Moved"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Width = 50
        Quantity.NullText = ""
        tbStyle.GridColumnStyles.Add(Quantity)

        Dim MovedFrom As New DataGridLabelColumn
        MovedFrom.Format = ""
        MovedFrom.FormatInfo = Nothing
        MovedFrom.HeaderText = "From"
        MovedFrom.MappingName = "MovedFrom"
        MovedFrom.ReadOnly = True
        MovedFrom.Width = 100
        MovedFrom.NullText = ""
        tbStyle.GridColumnStyles.Add(MovedFrom)

        Dim MovedTo As New DataGridLabelColumn
        MovedTo.Format = ""
        MovedTo.FormatInfo = Nothing
        MovedTo.HeaderText = "To"
        MovedTo.MappingName = "MovedTo"
        MovedTo.ReadOnly = True
        MovedTo.Width = 100
        MovedTo.NullText = ""
        tbStyle.GridColumnStyles.Add(MovedTo)

        Dim MovedBy As New DataGridLabelColumn
        MovedBy.Format = ""
        MovedBy.FormatInfo = Nothing
        MovedBy.HeaderText = "By"
        MovedBy.MappingName = "MovedBy"
        MovedBy.ReadOnly = True
        MovedBy.Width = 100
        MovedBy.NullText = ""
        tbStyle.GridColumnStyles.Add(MovedBy)

        Dim MovedOn As New DataGridLabelColumn
        MovedOn.Format = ""
        MovedOn.FormatInfo = Nothing
        MovedOn.HeaderText = "On"
        MovedOn.MappingName = "MovedOn"
        MovedOn.ReadOnly = True
        MovedOn.Width = 100
        MovedOn.NullText = ""
        tbStyle.GridColumnStyles.Add(MovedOn)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblIPTAudit.ToString

        Me.dgIPTAudit.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockMoved_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub radFromWarehouse_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFromWarehouse.CheckedChanged
        If radFromWarehouse.Checked Then
            Combo.SetUpCombo(Me.cboFrom, DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
            Me.cboFrom.SelectedIndex = 0
        End If
    End Sub

    Private Sub radFromVan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFromVan.CheckedChanged
        If radFromVan.Checked Then
            Combo.SetUpCombo(Me.cboFrom, DB.Van.Van_GetAll(False).Table, "LocationID", "Registration", Entity.Sys.Enums.ComboValues.No_Filter)
            Me.cboFrom.SelectedIndex = 0
        End If
    End Sub

    Private Sub radToWarehouse_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radToWarehouse.CheckedChanged
        If radToWarehouse.Checked Then
            Combo.SetUpCombo(Me.cboTo, DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
            Me.cboTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub radToVan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radToVan.CheckedChanged
        If radToVan.Checked Then
            Combo.SetUpCombo(Me.cboTo, DB.Van.Van_GetAll(False).Table, "LocationID", "Registration", Entity.Sys.Enums.ComboValues.No_Filter)
            Me.cboTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
        PopulateDatagrid()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateDatagrid()
        Try
            Dim type As String = "Both"
            If Me.radParts.Checked Then
                type = "Part"
            Else
                If Me.radProducts.Checked Then
                    type = "Product"
                End If
            End If

            AuditDataview = DB.Location.IPT_Audit_Get(type, Me.txtName.Text.Trim, Me.txtNumber.Text.Trim, Me.txtReference.Text.Trim, Combo.GetSelectedItemValue(Me.cboFrom), Combo.GetSelectedItemValue(Me.cboTo))
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Export()
        If AuditDataview Is Nothing Then
            ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If AuditDataview.Table Is Nothing Then
            ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If AuditDataview.Table.Rows.Count = 0 Then
            ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim exportData As New DataTable
        exportData.Columns.Add("Type")
        exportData.Columns.Add("Name")
        exportData.Columns.Add("Number")
        exportData.Columns.Add("Reference")
        exportData.Columns.Add("Moved")
        exportData.Columns.Add("From")
        exportData.Columns.Add("To")
        exportData.Columns.Add("By")
        exportData.Columns.Add("On")

        For itm As Integer = 0 To CType(dgIPTAudit.DataSource, DataView).Count - 1
            dgIPTAudit.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Type") = SelectedDataRow("Type")
            newRw("Name") = SelectedDataRow("Name")
            newRw("Number") = SelectedDataRow("Number")
            newRw("Reference") = SelectedDataRow("Reference")
            newRw("Moved") = SelectedDataRow("Quantity")
            newRw("From") = SelectedDataRow("MovedFrom")
            newRw("To") = SelectedDataRow("MovedTo")
            newRw("By") = SelectedDataRow("MovedBy")
            newRw("On") = SelectedDataRow("MovedOn")

            exportData.Rows.Add(newRw)

            dgIPTAudit.UnSelect(itm)
        Next itm

        Dim exporter As New Entity.Sys.Exporting(exportData, "Stock Moved Report")
        exporter = Nothing
    End Sub

#End Region

End Class
