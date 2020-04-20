Public Class FRMPartsForCreditList : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal IDToLinkToIn As Integer, Optional ByVal FromQuoteJobIn As Boolean = False, Optional ByVal FromJobIn As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FromQuoteJob = FromQuoteJobIn
        FromJob = FromJobIn
        IDToLinkTo = IDToLinkToIn

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
        Me.btnDeselectAll.Location = New System.Drawing.Point(112, 360)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnDeselectAll.TabIndex = 36
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(8, 360)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 35
        Me.btnSelectAll.Text = "Select All"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(8, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        '
        'btnAdd
        '
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
        'FRMSiteScheduleOfRateList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(648, 470)
        Me.Controls.Add(Me.grpSystemScheduleOfRate)
        Me.MinimumSize = New System.Drawing.Size(656, 504)
        Me.Name = "FRMSiteScheduleOfRateList"
        Me.Text = "Property Schedule Of Rates List"
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

    Public Property DataviewToLinkTo() As DataView
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

    Public Property RatesDataview() As DataView
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

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Part Number"
        Code.MappingName = "Number"
        Code.ReadOnly = True
        Code.Width = 65
        Code.NullText = ""
        tbStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Name"
        Description.ReadOnly = True
        Description.Width = 170
        Description.NullText = ""
        tbStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "BuyPrice"
        Price.ReadOnly = True
        Price.Width = 75
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        Dim QtyPerVisit As New DataGridLabelColumn
        QtyPerVisit.Format = ""
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Qty Received"
        QtyPerVisit.MappingName = "QuantityReceived"
        QtyPerVisit.ReadOnly = True
        QtyPerVisit.Width = 100
        QtyPerVisit.NullText = ""
        tbStyle.GridColumnStyles.Add(QtyPerVisit)

        Dim QtyPerVisit2 As New DataGridEditableTextBoxColumn
        QtyPerVisit2.Format = ""
        QtyPerVisit2.FormatInfo = Nothing
        QtyPerVisit2.HeaderText = "Qty to credit"
        QtyPerVisit2.MappingName = "QtyToCredit"
        QtyPerVisit2.ReadOnly = False
        QtyPerVisit2.Width = 100
        QtyPerVisit2.NullText = ""
        tbStyle.GridColumnStyles.Add(QtyPerVisit2)

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
        RatesDataview = DB.Order.Order_ItemsGetAll(IDToLinkTo)
    End Sub

    Private Sub Add()

        Dim sucsess As Boolean = False

        For Each dr As DataRow In RatesDataview.Table.Rows
            If dr("tick") = True And dr("QtyToCredit") > 0 Then
                sucsess = True
                Exit For
            End If
        Next
        If sucsess = False Then

            ShowMessage("You need to select at least 1 qty of a Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RatesDataview.Table.Clear()

        End If
    End Sub

#End Region

End Class