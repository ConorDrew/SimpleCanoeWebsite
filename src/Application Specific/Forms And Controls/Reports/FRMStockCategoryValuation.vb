Public Class FRMStockCategoryValuation : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpParts As System.Windows.Forms.GroupBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgParts As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpParts = New System.Windows.Forms.GroupBox
        Me.dgParts = New System.Windows.Forms.DataGrid
        Me.btnExport = New System.Windows.Forms.Button
        Me.grpParts.SuspendLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpParts
        '
        Me.grpParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpParts.Controls.Add(Me.dgParts)
        Me.grpParts.Location = New System.Drawing.Point(8, 38)
        Me.grpParts.Name = "grpParts"
        Me.grpParts.Size = New System.Drawing.Size(510, 260)
        Me.grpParts.TabIndex = 2
        Me.grpParts.TabStop = False
        Me.grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)"
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgParts.Location = New System.Drawing.Point(8, 19)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(494, 233)
        Me.dgParts.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 306)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        '
        'FRMStockCategoryValuation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(526, 336)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpParts)
        Me.MinimumSize = New System.Drawing.Size(534, 370)
        Me.Name = "FRMStockCategoryValuation"
        Me.Text = "Stock Category Valuation Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpParts, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.grpParts.ResumeLayout(False)
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Type = Entity.Sys.Enums.TableNames.tblPickLists
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

    Private selectedCateogryID As Integer = 0
    Private selectedCategoryName As String = ""

    Private _Type As Entity.Sys.Enums.TableNames = Entity.Sys.Enums.TableNames.tblPickLists
    Private Property Type() As Entity.Sys.Enums.TableNames
        Get
            Return _Type
        End Get
        Set(ByVal value As Entity.Sys.Enums.TableNames)
            Try
                _Type = value

                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                Select Case Type
                    Case Entity.Sys.Enums.TableNames.tblPickLists
                        PartsDataview = New DataView(DB.Part.Stock_Valuation(0, 0, 0, "", False).Tables(1))
                        Me.grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)"
                    Case Entity.Sys.Enums.TableNames.tblPart
                        PartsDataview = New DataView(DB.Part.Stock_Valuation(selectedCateogryID, 0, 0, "", False).Tables(2))
                        Me.grpParts.Text = "Part replacement costs based on supplier for category : " & selectedCategoryName.Trim
                End Select

                SetupDataGrid()
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Set
    End Property

    Private _dvParts As DataView
    Private Property PartsDataview() As DataView
        Get
            Return _dvParts
        End Get
        Set(ByVal value As DataView)
            _dvParts = value
            _dvParts.AllowNew = False
            _dvParts.AllowEdit = False
            _dvParts.AllowDelete = False
            _dvParts.Table.TableName = Type.ToString
            Me.dgParts.DataSource = PartsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataview(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()
        Me.dgParts.AllowSorting = False
        tbStyle.AllowSorting = False

        If Type = Entity.Sys.Enums.TableNames.tblPickLists Then
            Dim Name As New DataGridLabelColumn
            Name.Format = ""
            Name.FormatInfo = Nothing
            Name.HeaderText = "Category"
            Name.MappingName = "Name"
            Name.ReadOnly = True
            Name.Width = 200
            Name.NullText = ""
            tbStyle.GridColumnStyles.Add(Name)

            Dim Description As New DataGridLabelColumn
            Description.Format = ""
            Description.FormatInfo = Nothing
            Description.HeaderText = "Description"
            Description.MappingName = "Description"
            Description.ReadOnly = True
            Description.Width = 300
            Description.NullText = ""
            tbStyle.GridColumnStyles.Add(Description)

            Dim ReplacementCost As New DataGridLabelColumn
            ReplacementCost.Format = "C"
            ReplacementCost.FormatInfo = Nothing
            ReplacementCost.HeaderText = "Cost"
            ReplacementCost.MappingName = "ReplacementCost"
            ReplacementCost.ReadOnly = True
            ReplacementCost.Width = 100
            ReplacementCost.NullText = "£0.00"
            tbStyle.GridColumnStyles.Add(ReplacementCost)

            Dim Undistributed As New DataGridLabelColumn
            Undistributed.Format = "C"
            Undistributed.FormatInfo = Nothing
            Undistributed.HeaderText = "Undistributed"
            Undistributed.MappingName = "Undistributed"
            Undistributed.ReadOnly = True
            Undistributed.Width = 100
            Undistributed.NullText = "£0.00"
            tbStyle.GridColumnStyles.Add(Undistributed)

            Dim ClickAction As New DataGridLabelColumn
            ClickAction.Format = ""
            ClickAction.FormatInfo = Nothing
            ClickAction.HeaderText = ""
            ClickAction.MappingName = "ClickAction"
            ClickAction.ReadOnly = True
            ClickAction.Width = 100
            ClickAction.NullText = ""
            tbStyle.GridColumnStyles.Add(ClickAction)

            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
        ElseIf Type = Entity.Sys.Enums.TableNames.tblPart Then
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

            Dim ReplacementCost As New DataGridLabelColumn
            ReplacementCost.Format = "C"
            ReplacementCost.FormatInfo = Nothing
            ReplacementCost.HeaderText = "Cost"
            ReplacementCost.MappingName = "ReplacementCost"
            ReplacementCost.ReadOnly = True
            ReplacementCost.Width = 100
            ReplacementCost.NullText = "£0.00"
            tbStyle.GridColumnStyles.Add(ReplacementCost)

            Dim Undistributed As New DataGridLabelColumn
            Undistributed.Format = "C"
            Undistributed.FormatInfo = Nothing
            Undistributed.HeaderText = "Undistributed"
            Undistributed.MappingName = "Undistributed"
            Undistributed.ReadOnly = True
            Undistributed.Width = 100
            Undistributed.NullText = "£0.00"
            tbStyle.GridColumnStyles.Add(Undistributed)

            Dim Supplier As New DataGridLabelColumn
            Supplier.Format = ""
            Supplier.FormatInfo = Nothing
            Supplier.HeaderText = "Supplier"
            Supplier.MappingName = "Supplier"
            Supplier.ReadOnly = True
            Supplier.Width = 250
            Supplier.NullText = "No Supplier"
            tbStyle.GridColumnStyles.Add(Supplier)

            Dim ClickAction As New DataGridLabelColumn
            ClickAction.Format = ""
            ClickAction.FormatInfo = Nothing
            ClickAction.HeaderText = ""
            ClickAction.MappingName = "ClickAction"
            ClickAction.ReadOnly = True
            ClickAction.Width = 100
            ClickAction.NullText = ""
            tbStyle.GridColumnStyles.Add(ClickAction)

            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString
        End If

        tbStyle.ReadOnly = True

        Me.dgParts.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockCategoryValuation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgParts.DoubleClick
        If Type = Entity.Sys.Enums.TableNames.tblPart Then
            If SelectedPartDataRow Is Nothing Then
                Exit Sub
            End If
            ShowForm(GetType(FRMPart), True, New Object() {SelectedPartDataRow.Item("PartID"), True})
            Type = Entity.Sys.Enums.TableNames.tblPart
        End If
    End Sub
    
    Private Sub dgParts_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgParts.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgParts.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgParts.CurrentRowIndex = HitTestInfo.Row()
            End If

            If HitTestInfo.Column <= 0 Then
                Exit Sub
            End If

            If Not Me.dgParts.TableStyles(0).GridColumnStyles.Item(HitTestInfo.Column).MappingName.ToLower = "clickaction" Then
                Exit Sub
            End If

            If SelectedPartDataRow Is Nothing Then
                Exit Sub
            End If

            Select Case Type
                Case Entity.Sys.Enums.TableNames.tblPickLists
                    selectedCategoryName = SelectedPartDataRow.Item("Name")
                    selectedCateogryID = SelectedPartDataRow.Item("CategoryID")
                    Type = Entity.Sys.Enums.TableNames.tblPart
                Case Entity.Sys.Enums.TableNames.tblPart
                    If Not SelectedPartDataRow.Item("ClickAction") = "Back..." Then
                        Exit Sub
                    End If
                    Type = Entity.Sys.Enums.TableNames.tblPickLists
            End Select

        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

#End Region

#Region "Functions"

    Public Sub Export()
        Dim exportData As New DataTable
        Dim reportName As String = ""

        Select Case Type
            Case Entity.Sys.Enums.TableNames.tblPickLists
                exportData.Columns.Add("Category")
                exportData.Columns.Add("Description")
                exportData.Columns.Add("Cost")
                exportData.Columns.Add("Undistributed")

                For itm As Integer = 0 To CType(dgParts.DataSource, DataView).Count - 1
                    dgParts.CurrentRowIndex = itm
                    Dim newRw As DataRow
                    newRw = exportData.NewRow

                    newRw("Category") = SelectedPartDataRow("Name")
                    newRw("Description") = SelectedPartDataRow("Description")
                    newRw("Cost") = Format(SelectedPartDataRow("ReplacementCost"), "F")
                    newRw("Undistributed") = Format(SelectedPartDataRow("Undistributed"), "F")

                    exportData.Rows.Add(newRw)

                    dgParts.UnSelect(itm)
                Next itm

                reportName = "Stock Category Value Report"
            Case Entity.Sys.Enums.TableNames.tblPart
                exportData.Columns.Add("Category")
                exportData.Columns.Add("Name")
                exportData.Columns.Add("Number")
                exportData.Columns.Add("Reference")
                exportData.Columns.Add("Cost")
                exportData.Columns.Add("Undistributed")
                exportData.Columns.Add("Supplier")

                For itm As Integer = 0 To CType(dgParts.DataSource, DataView).Count - 1
                    dgParts.CurrentRowIndex = itm
                    Dim newRw As DataRow
                    newRw = exportData.NewRow

                    newRw("Category") = SelectedPartDataRow("Category")
                    newRw("Name") = SelectedPartDataRow("Name")
                    newRw("Number") = SelectedPartDataRow("Number")
                    newRw("Reference") = SelectedPartDataRow("Reference")
                    newRw("Cost") = Format(SelectedPartDataRow("ReplacementCost"), "F")
                    newRw("Undistributed") = Format(SelectedPartDataRow("Undistributed"), "F")
                    newRw("Supplier") = SelectedPartDataRow("Supplier")

                    exportData.Rows.Add(newRw)

                    dgParts.UnSelect(itm)
                Next itm

                reportName = "Stock Value Report"
        End Select

        Dim exporter As New Entity.Sys.Exporting(exportData, reportName)
        exporter = Nothing
    End Sub

#End Region

End Class
