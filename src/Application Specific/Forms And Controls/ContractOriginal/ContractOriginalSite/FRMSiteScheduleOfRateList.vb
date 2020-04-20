Public Class FRMSiteScheduleOfRateList : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal IDToLinkToIn As Integer, ByRef DataviewToLinkToIn As DataView, Optional ByVal FromQuoteJobIn As Boolean = False, Optional ByVal FromJobIn As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FromQuoteJob = FromQuoteJobIn
        FromJob = FromJobIn
        IDToLinkTo = IDToLinkToIn
        DataviewToLinkTo = DataviewToLinkToIn
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
    Friend WithEvents grpSystemScheduleOfRate As System.Windows.Forms.GroupBox

    Friend WithEvents dgRates As System.Windows.Forms.DataGrid
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSystemScheduleOfRate = New System.Windows.Forms.GroupBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgRates = New System.Windows.Forms.DataGrid()
        Me.grpSystemScheduleOfRate.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSystemScheduleOfRate
        '
        Me.grpSystemScheduleOfRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.cboCategory)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblCategory)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label1)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtSearch)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnDeselectAll)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnSelectAll)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnCancel)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnAdd)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.dgRates)
        Me.grpSystemScheduleOfRate.Location = New System.Drawing.Point(8, 32)
        Me.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate"
        Me.grpSystemScheduleOfRate.Size = New System.Drawing.Size(1147, 569)
        Me.grpSystemScheduleOfRate.TabIndex = 2
        Me.grpSystemScheduleOfRate.TabStop = False
        Me.grpSystemScheduleOfRate.Text = "Main Details"
        '
        'cboCategory
        '
        Me.cboCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Location = New System.Drawing.Point(102, 24)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(1039, 21)
        Me.cboCategory.TabIndex = 40
        Me.cboCategory.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(11, 27)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(60, 13)
        Me.lblCategory.TabIndex = 39
        Me.lblCategory.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(102, 53)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(1039, 21)
        Me.txtSearch.TabIndex = 37
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeselectAll.Location = New System.Drawing.Point(112, 497)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnDeselectAll.TabIndex = 36
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(8, 497)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 35
        Me.btnSelectAll.Text = "Select All"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 537)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(1059, 537)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add"
        '
        'dgRates
        '
        Me.dgRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRates.DataMember = ""
        Me.dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRates.Location = New System.Drawing.Point(14, 84)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(1133, 405)
        Me.dgRates.TabIndex = 32
        '
        'FRMSiteScheduleOfRateList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1163, 607)
        Me.Controls.Add(Me.grpSystemScheduleOfRate)
        Me.MinimumSize = New System.Drawing.Size(656, 504)
        Me.Name = "FRMSiteScheduleOfRateList"
        Me.Text = "Property Schedule Of Rates List"
        Me.Controls.SetChildIndex(Me.grpSystemScheduleOfRate, 0)
        Me.grpSystemScheduleOfRate.ResumeLayout(False)
        Me.grpSystemScheduleOfRate.PerformLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(cboCategory, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        SetupRatesDataGrid()
        Populate()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _fromQuoteJob As Boolean

    Public Property FromQuoteJob() As Boolean
        Get
            Return _fromQuoteJob
        End Get
        Set(ByVal Value As Boolean)
            _fromQuoteJob = Value
        End Set
    End Property

    Private _fromJob As Boolean

    Public Property FromJob() As Boolean
        Get
            Return _fromJob
        End Get
        Set(ByVal Value As Boolean)
            _fromJob = Value
        End Set
    End Property

    Private _DataViewToLinkTo As DataView

    Private Property DataviewToLinkTo() As DataView
        Get
            Return _DataViewToLinkTo
        End Get
        Set(ByVal Value As DataView)
            _DataViewToLinkTo = Value
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
        End Set
    End Property

    Private _dvRates As DataView

    Private Property RatesDataview() As DataView
        Get
            Return _dvRates
        End Get
        Set(ByVal value As DataView)
            _dvRates = value
            _dvRates.AllowNew = False
            _dvRates.AllowEdit = True
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
            Me.dgRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgRates.CurrentRowIndex = -1 Then
                Return RatesDataview(Me.dgRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgRates)
        Dim tbStyle As DataGridTableStyle = Me.dgRates.TableStyles(0)

        Me.dgRates.ReadOnly = False
        tbStyle.AllowSorting = False
        tbStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 100
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 65
        Code.NullText = ""
        tbStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 670
        Description.NullText = ""
        tbStyle.GridColumnStyles.Add(Description)

        Dim TimeInMins As New DataGridLabelColumn
        TimeInMins.Format = ""
        TimeInMins.FormatInfo = Nothing
        TimeInMins.HeaderText = "Time"
        TimeInMins.MappingName = "TimeInMins"
        TimeInMins.ReadOnly = False
        TimeInMins.Width = 50
        TimeInMins.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeInMins)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 75
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        Dim QtyPerVisit As New DataGridEditableTextBoxColumn
        QtyPerVisit.Format = "D" 'Decimal
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Unit Qty Per Visit"
        QtyPerVisit.MappingName = "QtyPerVisit"
        QtyPerVisit.ReadOnly = False
        QtyPerVisit.Width = 110
        QtyPerVisit.NullText = ""
        tbStyle.GridColumnStyles.Add(QtyPerVisit)

        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
        Me.dgRates.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMSystemScheduleOfRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For Each dr As DataRow In RatesDataview.Table.Rows
            dr("tick") = True
        Next
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For Each dr As DataRow In RatesDataview.Table.Rows
            dr("tick") = False
        Next
    End Sub

    Private Sub dgRates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRates.Click
        Try
            If SelectedRatesDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgRates(Me.dgRates.CurrentRowIndex, 0))
            Me.dgRates(Me.dgRates.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        RatesDataview = DB.CustomerScheduleOfRate.GetAll_For_SiteID(IDToLinkTo)
    End Sub

    Private Sub Add()
        If Not DataviewToLinkTo.Table.Columns.Contains("SystemLinkID") Then
            DataviewToLinkTo.Table.Columns.Add(New DataColumn("SystemLinkID"))
        End If

        For Each dr As DataRow In RatesDataview.Table.Rows
            If dr("tick") = True Then
                Dim newRow As DataRow
                newRow = DataviewToLinkTo.Table.NewRow

                If Not FromJob Then
                    newRow("ScheduleOfRatesCategoryID") = dr("ScheduleOfRatesCategoryID")
                    newRow("Category") = dr("Category")
                    newRow("Code") = dr("Code")
                    newRow("Description") = dr("Description")
                    newRow("Price") = dr("Price")
                    If FromQuoteJob = True Then
                        newRow("Quantity") = dr("QtyPerVisit")
                        newRow("Total") = Entity.Sys.Helper.MakeDoubleValid(dr("Price")) * Entity.Sys.Helper.MakeDoubleValid(newRow("Quantity"))
                        newRow.Item("TimeInMins") = dr("TimeInMins")
                    Else
                        newRow("QtyPerVisit") = dr("QtyPerVisit")
                    End If
                Else
                    newRow.Item("Summary") = dr("Description")
                    newRow.Item("Qty") = dr("QtyPerVisit")
                End If

                If dr.Table.Columns.Contains("SiteScheduleOfRateID") Then
                    newRow.Item("RateID") = dr("SiteScheduleOfRateID")
                ElseIf dr.Table.Columns.Contains("CustomerScheduleOfRateID") Then
                    newRow.Item("RateID") = dr("CustomerScheduleOfRateID")
                    newRow.Item("SystemLinkID") = CInt(Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate)
                End If

                DataviewToLinkTo.Table.Rows.Add(newRow)
            End If
        Next

        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.KeyUp
        RunFilter()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        RunFilter()
    End Sub

    Private Sub RunFilter()
        If RatesDataview Is Nothing Then
            Exit Sub
        End If

        Dim filter As String = "(Description LIKE '%" & Me.txtSearch.Text & "%' OR Code LIKE '%" & Me.txtSearch.Text & "%')"
        Dim category As String = Combo.GetSelectedItemDescription(cboCategory)
        If Not String.IsNullOrEmpty(category) Then
            filter += " AND Category = '" & category & "'"
        End If
        RatesDataview.RowFilter = filter
        dgRates.DataSource = RatesDataview
    End Sub

End Class