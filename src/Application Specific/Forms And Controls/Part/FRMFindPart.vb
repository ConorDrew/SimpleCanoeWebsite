Public Class FRMFindPart : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal trans As SqlClient.SqlTransaction)

        MyBase.New()

        Me.Trans = trans

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
    Friend WithEvents lblFilter As System.Windows.Forms.Label

    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPreferredSupplier As System.Windows.Forms.Label
    Friend WithEvents pnlGreen As System.Windows.Forms.Panel
    Friend WithEvents dgvParts As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.dgvParts = New System.Windows.Forms.DataGridView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblPreferredSupplier = New System.Windows.Forms.Label()
        Me.pnlGreen = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.grpResults.SuspendLayout()
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFilter
        '
        Me.lblFilter.Location = New System.Drawing.Point(8, 40)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(100, 24)
        Me.lblFilter.TabIndex = 2
        Me.lblFilter.Text = "Filter By Name"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(104, 40)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(562, 21)
        Me.txtFilter.TabIndex = 1
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.dgvParts)
        Me.grpResults.Location = New System.Drawing.Point(8, 68)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(793, 377)
        Me.grpResults.TabIndex = 4
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Select record and click OK"
        '
        'dgvParts
        '
        Me.dgvParts.AllowUserToAddRows = False
        Me.dgvParts.AllowUserToDeleteRows = False
        Me.dgvParts.AllowUserToOrderColumns = True
        Me.dgvParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParts.Location = New System.Drawing.Point(8, 20)
        Me.dgvParts.Name = "dgvParts"
        Me.dgvParts.ReadOnly = True
        Me.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvParts.Size = New System.Drawing.Size(777, 351)
        Me.dgvParts.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(745, 451)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 451)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'lblPreferredSupplier
        '
        Me.lblPreferredSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPreferredSupplier.Location = New System.Drawing.Point(95, 456)
        Me.lblPreferredSupplier.Name = "lblPreferredSupplier"
        Me.lblPreferredSupplier.Size = New System.Drawing.Size(175, 24)
        Me.lblPreferredSupplier.TabIndex = 7
        Me.lblPreferredSupplier.Text = "Preferred Supplier"
        '
        'pnlGreen
        '
        Me.pnlGreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlGreen.BackColor = System.Drawing.Color.LightGreen
        Me.pnlGreen.Location = New System.Drawing.Point(70, 454)
        Me.pnlGreen.Name = "pnlGreen"
        Me.pnlGreen.Size = New System.Drawing.Size(19, 20)
        Me.pnlGreen.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(673, 39)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(128, 23)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'FRMFindPart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(809, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.pnlGreen)
        Me.Controls.Add(Me.lblPreferredSupplier)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lblFilter)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(704, 392)
        Me.Name = "FRMFindPart"
        Me.Text = "Find {0}"
        Me.Controls.SetChildIndex(Me.lblFilter, 0)
        Me.Controls.SetChildIndex(Me.txtFilter, 0)
        Me.Controls.SetChildIndex(Me.grpResults, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblPreferredSupplier, 0)
        Me.Controls.SetChildIndex(Me.pnlGreen, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.grpResults.ResumeLayout(False)
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Me.ActiveControl = Me.txtFilter
        Me.txtFilter.Focus()
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

    Private _Trans As SqlClient.SqlTransaction

    Public Property Trans() As SqlClient.SqlTransaction
        Get
            Return _Trans
        End Get
        Set(ByVal value As SqlClient.SqlTransaction)
            _Trans = value
        End Set
    End Property

    Public Datarows As DataRow() = Nothing

    Private _TableToSearch As Entity.Sys.Enums.TableNames = Entity.Sys.Enums.TableNames.NO_TABLE

    Public Property TableToSearch() As Entity.Sys.Enums.TableNames
        Get
            Return _TableToSearch
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)

            Me.MinimumSize = New Size(New Point(704, 392))

            _TableToSearch = Value

            If TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then

                Entity.Sys.Helper.SetUpDataGridView(Me.dgvParts)
                dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvParts.AutoGenerateColumns = False
                dgvParts.Columns.Clear()
                dgvParts.EditMode = DataGridViewEditMode.EditOnEnter

                Dim Qty As New DataGridViewTextBoxColumn
                Qty.HeaderText = "Qty"
                Qty.DataPropertyName = "Qty"
                Qty.FillWeight = 30
                Qty.ReadOnly = False
                Qty.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(Qty)

                Dim PartName As New DataGridViewTextBoxColumn
                PartName.FillWeight = 60
                PartName.HeaderText = "Part Name"
                PartName.DataPropertyName = "Name"
                PartName.ReadOnly = True
                PartName.Visible = True
                PartName.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(PartName)

                Dim PartNumber As New DataGridViewTextBoxColumn
                PartNumber.HeaderText = "Part Number"
                PartNumber.DataPropertyName = "Number"
                PartNumber.FillWeight = 50
                PartNumber.ReadOnly = True
                PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(PartNumber)

                Dim Reference As New DataGridViewTextBoxColumn
                Reference.HeaderText = "Reference"
                Reference.DataPropertyName = "Reference"
                Reference.FillWeight = 50
                Reference.ReadOnly = True
                Reference.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(Reference)

                Records = DB.Part.Part_Search(txtFilter.Text, "")

            ElseIf TableToSearch = Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty Then

                Entity.Sys.Helper.SetUpDataGridView(Me.dgvParts)
                dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvParts.AutoGenerateColumns = False
                dgvParts.Columns.Clear()
                dgvParts.EditMode = DataGridViewEditMode.EditOnEnter

                Dim Qty As New DataGridViewTextBoxColumn
                Qty.HeaderText = "Qty"
                Qty.DataPropertyName = "Qty"
                Qty.FillWeight = 30
                Qty.ReadOnly = False
                Qty.SortMode = DataGridViewColumnSortMode.Automatic
                dgvParts.Columns.Add(Qty)

                Dim PartName As New DataGridViewTextBoxColumn
                PartName.FillWeight = 60
                PartName.HeaderText = "Part Name"
                PartName.DataPropertyName = "PartName"
                PartName.ReadOnly = True
                PartName.Visible = True
                PartName.SortMode = DataGridViewColumnSortMode.Automatic
                dgvParts.Columns.Add(PartName)

                Dim PartNumber As New DataGridViewTextBoxColumn
                PartNumber.HeaderText = "Part Number"
                PartNumber.DataPropertyName = "PartNumber"
                PartNumber.FillWeight = 50
                PartNumber.ReadOnly = True
                PartNumber.SortMode = DataGridViewColumnSortMode.Automatic
                dgvParts.Columns.Add(PartNumber)

                Dim Reference As New DataGridViewTextBoxColumn
                Reference.HeaderText = "Reference"
                Reference.DataPropertyName = "Reference"
                Reference.FillWeight = 50
                Reference.ReadOnly = True
                Reference.SortMode = DataGridViewColumnSortMode.Automatic
                dgvParts.Columns.Add(Reference)

                Dim SPN As New DataGridViewTextBoxColumn
                SPN.HeaderText = "SPN"
                SPN.DataPropertyName = "PartCode"
                SPN.FillWeight = 50
                SPN.ReadOnly = True
                SPN.SortMode = DataGridViewColumnSortMode.Automatic
                dgvParts.Columns.Add(SPN)

                Dim Supplier As New DataGridViewTextBoxColumn
                Supplier.HeaderText = "Supplier Name"
                Supplier.DataPropertyName = "SupplierName"
                Supplier.FillWeight = 60
                Supplier.ReadOnly = True
                Supplier.SortMode = DataGridViewColumnSortMode.Automatic
                Supplier.Visible = True
                dgvParts.Columns.Add(Supplier)

                Dim Price As New DataGridViewTextBoxColumn
                Price.HeaderText = "Price"
                Price.DataPropertyName = "Price"
                Price.FillWeight = 60
                Price.ReadOnly = True
                Price.SortMode = DataGridViewColumnSortMode.Automatic
                Price.Visible = True
                dgvParts.Columns.Add(Price)

                Records = DB.PartSupplier.PartSupplier_Search(txtFilter.Text)
            Else

                Entity.Sys.Helper.SetUpDataGridView(Me.dgvParts)
                dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvParts.AutoGenerateColumns = False
                dgvParts.Columns.Clear()
                dgvParts.EditMode = DataGridViewEditMode.EditOnEnter

                Dim Tick As New DataGridViewCheckBoxColumn
                Tick.FillWeight = 30
                Tick.HeaderText = "Include"
                Tick.DataPropertyName = "Tick"
                Tick.ReadOnly = False
                Tick.Visible = True
                Tick.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(Tick)

                Dim PartName As New DataGridViewTextBoxColumn
                PartName.FillWeight = 60
                PartName.HeaderText = "Part Name"
                PartName.DataPropertyName = "PartName"
                PartName.ReadOnly = True
                PartName.Visible = True
                PartName.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(PartName)

                Dim PartNumber As New DataGridViewTextBoxColumn
                PartNumber.HeaderText = "Part Number"
                PartNumber.DataPropertyName = "PartNumber"
                PartNumber.FillWeight = 50
                PartNumber.ReadOnly = True
                PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(PartNumber)

                Dim SPN As New DataGridViewTextBoxColumn
                SPN.HeaderText = "SPN"
                SPN.DataPropertyName = "PartCode"
                SPN.FillWeight = 50
                SPN.ReadOnly = True
                SPN.SortMode = DataGridViewColumnSortMode.Programmatic
                dgvParts.Columns.Add(SPN)

                Dim Supplier As New DataGridViewTextBoxColumn
                Supplier.HeaderText = "Supplier Name"
                Supplier.DataPropertyName = "SupplierName"
                Supplier.FillWeight = 60
                Supplier.ReadOnly = True
                Supplier.SortMode = DataGridViewColumnSortMode.Programmatic
                Supplier.Visible = True
                dgvParts.Columns.Add(Supplier)

                dgvParts.Sort(Supplier, System.ComponentModel.ListSortDirection.Descending)

                Records = DB.PartSupplier.PartSupplier_Search(txtFilter.Text)

            End If

        End Set
    End Property

    Private _foreignKeyFilter As Integer

    Public Property ForeignKeyFilter() As Integer
        Get
            Return _foreignKeyFilter
        End Get
        Set(ByVal Value As Integer)
            _foreignKeyFilter = Value
        End Set
    End Property

    Private _PartNumber As String

    Public Property PartNumber() As String
        Get
            Return _PartNumber
        End Get
        Set(ByVal Value As String)
            _PartNumber = Value
        End Set
    End Property

    Private _ForMassPartEntry As Boolean = False

    Public Property ForMassPartEntry() As Boolean
        Get
            Return _ForMassPartEntry
        End Get
        Set(ByVal Value As Boolean)
            _ForMassPartEntry = Value
        End Set
    End Property

    Private _dvRecords As DataView

    Private Property Records() As DataView
        Get
            Return _dvRecords
        End Get
        Set(ByVal value As DataView)
            _dvRecords = value
            Me.dgvParts.DataSource = Records
        End Set
    End Property

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _2ndID As Integer = 0

    Public Property SecondID() As Integer
        Get
            Return _2ndID
        End Get
        Set(ByVal Value As Integer)
            _2ndID = Value
        End Set
    End Property

    Private _PartsToAdd As ArrayList = Nothing

    Public Property PartsToAdd() As ArrayList
        Get
            Return _PartsToAdd
        End Get
        Set(ByVal Value As ArrayList)
            _PartsToAdd = Value
        End Set
    End Property

    Private _PartID As Integer = 0

    Public Property PartID() As Integer
        Get
            Return _PartID
        End Get
        Set(ByVal Value As Integer)
            _PartID = Value
        End Set
    End Property

    Private _PartSupplierID As Integer = 0

    Public Property PartSupplierID() As Integer
        Get
            Return _PartSupplierID
        End Get
        Set(ByVal Value As Integer)
            _PartSupplierID = Value
        End Set
    End Property

    Dim old As DataGridViewSelectedRowCollection

#End Region

#Region "Events"

    Private Sub DLGFindRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        RunFilter()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Public Sub DBParts()
        Records = DB.PartSupplier.PartSupplier_Search(txtFilter.Text)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SelectItem()
    End Sub

#End Region

#Region "Functions"

    Private Sub SelectItem()
        If dgvParts.SelectedRows Is Nothing Then
            ShowMessage("No records selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If TableToSearch = Entity.Sys.Enums.TableNames.tblPart Or TableToSearch = Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty Then
            Datarows = CType(dgvParts.DataSource, DataView).Table.Select("Qty > 0")
        Else
            Datarows = CType(dgvParts.DataSource, DataView).Table.Select("Tick = 1")
        End If

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "0 = 0"
        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            Select Case TableToSearch
                Case Entity.Sys.Enums.TableNames.tblJob
                    whereClause += " AND JobNumber LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblContact
                    whereClause += " AND (Firstname LIKE '%" & Me.txtFilter.Text.Trim & "%') OR (Surname LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblSite
                    whereClause += " AND (Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Address1 LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblProduct
                    whereClause += " AND typemakemodel LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPart
                    whereClause += " AND Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPartSupplier
                    whereClause += " AND PartName LIKE '%" & Me.txtFilter.Text.Trim & "%' OR PartCode LIKE '%" & Me.txtFilter.Text.Trim & "%' OR PartNumber LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblOrder
                    whereClause += " AND OrderReference LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Else
                    whereClause += " AND PartName LIKE '%" & Me.txtFilter.Text.Trim & "%' OR PartCode LIKE '%" & Me.txtFilter.Text.Trim & "%' OR PartNumber LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'"
            End Select
        End If

        Records.RowFilter = whereClause
    End Sub

#End Region

#Region "Classes"

    Public Class ColourColumn : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            'set the color required dependant on the column value
            Dim brush As Brush

            brush = Brushes.White

            If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("Preferred")) Then
                brush = Brushes.LightGreen
            End If

            Me.TextBox.Text = ""
            'color the row cell
            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

        End Sub

    End Class

#End Region

    Private Sub btnFilter_Click(sender As Object, e As EventArgs)
        RunFilter()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
            Records = DB.Part.Part_Search(txtFilter.Text, "")
        Else
            Records = DB.PartSupplier.PartSupplier_Search(txtFilter.Text)
        End If

    End Sub

End Class