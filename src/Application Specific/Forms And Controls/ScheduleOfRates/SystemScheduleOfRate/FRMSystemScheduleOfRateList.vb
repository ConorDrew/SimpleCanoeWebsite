Public Class FRMSystemScheduleOfRateList : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal EntityToLinkToIn As Entity.Sys.Enums.TableNames, ByVal IDToLinkToIn As Integer,
                                                             Optional ByVal AdditionalIDIn As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        EntityToLinkTo = EntityToLinkToIn
        IDToLinkTo = IDToLinkToIn
        AdditionalID = AdditionalIDIn
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
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSystemScheduleOfRate = New System.Windows.Forms.GroupBox
        Me.btnDeselectAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.dgRates = New System.Windows.Forms.DataGrid
        Me.grpSystemScheduleOfRate.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSystemScheduleOfRate
        '
        Me.grpSystemScheduleOfRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnDeselectAll)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnSelectAll)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnCancel)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnAdd)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.dgRates)
        Me.grpSystemScheduleOfRate.Location = New System.Drawing.Point(8, 32)
        Me.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate"
        Me.grpSystemScheduleOfRate.Size = New System.Drawing.Size(632, 432)
        Me.grpSystemScheduleOfRate.TabIndex = 2
        Me.grpSystemScheduleOfRate.TabStop = False
        Me.grpSystemScheduleOfRate.Text = "Main Details"
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeselectAll.Location = New System.Drawing.Point(112, 360)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnDeselectAll.TabIndex = 36
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(8, 360)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 35
        Me.btnSelectAll.Text = "Select All"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(544, 400)
        Me.btnAdd.Name = "btnAdd"
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
        Me.dgRates.Location = New System.Drawing.Point(8, 19)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(618, 333)
        Me.dgRates.TabIndex = 32
        '
        'FRMSystemScheduleOfRateList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(648, 470)
        Me.Controls.Add(Me.grpSystemScheduleOfRate)
        Me.MinimumSize = New System.Drawing.Size(656, 504)
        Me.Name = "FRMSystemScheduleOfRateList"
        Me.Text = "System Schedule Of Rates List"
        Me.Controls.SetChildIndex(Me.grpSystemScheduleOfRate, 0)
        Me.grpSystemScheduleOfRate.ResumeLayout(False)
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
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

    Private _EntityToLinkTo As Entity.Sys.Enums.TableNames

    Public Property EntityToLinkTo() As Entity.Sys.Enums.TableNames
        Get
            Return _EntityToLinkTo
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _EntityToLinkTo = Value
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

    Private _AdditionalID As Integer = 0

    Public Property AdditionalID() As Integer
        Get
            Return _AdditionalID
        End Get
        Set(ByVal Value As Integer)
            _AdditionalID = Value
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
        Code.Width = 75
        Code.NullText = ""
        tbStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 200
        Description.NullText = ""
        tbStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 75
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

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
        If EntityToLinkTo = Entity.Sys.Enums.TableNames.tblCustomer Then
            RatesDataview = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll_WithoutDefaults
        Else
            RatesDataview = DB.CustomerScheduleOfRate.GetAll_WithoutDefaults(AdditionalID)
        End If

    End Sub

    Private Sub Add()
        If EntityToLinkTo = Entity.Sys.Enums.TableNames.tblCustomer Then
            For Each dr As DataRow In RatesDataview.Table.Rows
                If dr("tick") = True Then
                    Dim cSoR As New Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
                    cSoR.SetCustomerID = IDToLinkTo
                    cSoR.SetAllowDeleted = dr("AllowDeleted")
                    cSoR.SetScheduleOfRatesCategoryID = dr("ScheduleOfRatesCategoryID")
                    cSoR.SetCode = dr("Code")
                    cSoR.SetDescription = dr("Description")
                    cSoR.SetPrice = dr("Price")
                    cSoR.SetTimeInMins = Entity.Sys.Helper.MakeIntegerValid(dr("TimeInMins"))

                    DB.CustomerScheduleOfRate.Insert(cSoR)
                End If
            Next
        End If

    End Sub

#End Region

End Class