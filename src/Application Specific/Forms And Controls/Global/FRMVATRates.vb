Public Class FRMVATRates : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents dgVATRates As System.Windows.Forms.DataGrid
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtVATRate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpVATDate As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.dgVATRates = New System.Windows.Forms.DataGrid
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.dtpVATDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVATRate = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgVATRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAddNew)
        Me.GroupBox1.Controls.Add(Me.dgVATRates)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 328)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "VAT Rates"
        '
        'btnAddNew
        '
        Me.btnAddNew.AccessibleDescription = "Add new item"
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.UseVisualStyleBackColor = True
        Me.btnAddNew.Location = New System.Drawing.Point(8, 16)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(48, 24)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "New"
        '
        'dgVATRates
        '
        Me.dgVATRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVATRates.DataMember = ""
        Me.dgVATRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVATRates.Location = New System.Drawing.Point(8, 52)
        Me.dgVATRates.Name = "dgVATRates"
        Me.dgVATRates.Size = New System.Drawing.Size(496, 268)
        Me.dgVATRates.TabIndex = 1
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.txtCode)
        Me.grpDetails.Controls.Add(Me.Label3)
        Me.grpDetails.Controls.Add(Me.dtpVATDate)
        Me.grpDetails.Controls.Add(Me.Label1)
        Me.grpDetails.Controls.Add(Me.txtVATRate)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.Controls.Add(Me.btnSave)

        Me.grpDetails.Location = New System.Drawing.Point(8, 374)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(512, 106)
        Me.grpDetails.TabIndex = 1
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'dtpVATDate
        '
        Me.dtpVATDate.Location = New System.Drawing.Point(120, 48)
        Me.dtpVATDate.Name = "dtpVATDate"
        Me.dtpVATDate.Size = New System.Drawing.Size(328, 21)
        Me.dtpVATDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From Date"
        '
        'txtVATRate
        '
        Me.txtVATRate.Location = New System.Drawing.Point(120, 24)
        Me.txtVATRate.MaxLength = 255
        Me.txtVATRate.Name = "txtVATRate"
        Me.txtVATRate.Size = New System.Drawing.Size(328, 21)
        Me.txtVATRate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Rate Amount (%)"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save item"
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.ImageIndex = 1
        Me.btnSave.Location = New System.Drawing.Point(456, 74)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(120, 75)
        Me.txtCode.MaxLength = 5
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(328, 21)
        Me.txtCode.TabIndex = 2
        '
        'FRMVATRates
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(528, 486)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpDetails)
        Me.Name = "FRMVATRates"
        Me.Text = "VAT Rates"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpDetails, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgVATRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupRatesDataGrid()
        PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
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

    Private _pageState As Entity.Sys.Enums.FormState
    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
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
            _dvRates.AllowEdit = False
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
            Me.dgVATRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVATRateDataRow() As DataRow
        Get
            If Not Me.dgVATRates.CurrentRowIndex = -1 Then
                Return RatesDataview(Me.dgVATRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "Setup"

    Private Sub SetupRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgVATRates)
        Dim tbStyle As DataGridTableStyle = Me.dgVATRates.TableStyles(0)

        Dim VATRate As New DataGridLabelColumn
        VATRate.Format = ""
        VATRate.FormatInfo = Nothing
        VATRate.HeaderText = "VAT Rate"
        VATRate.MappingName = "VATRate"
        VATRate.ReadOnly = True
        VATRate.Width = 150
        VATRate.NullText = ""
        tbStyle.GridColumnStyles.Add(VATRate)

        Dim DateIntroduced As New DataGridLabelColumn
        DateIntroduced.Format = "dd/MM/yyyy"
        DateIntroduced.FormatInfo = Nothing
        DateIntroduced.HeaderText = "Date Introduced"
        DateIntroduced.MappingName = "DateIntroduced"
        DateIntroduced.ReadOnly = True
        DateIntroduced.Width = 150
        DateIntroduced.NullText = ""
        tbStyle.GridColumnStyles.Add(DateIntroduced)

        Dim VATRateCode As New DataGridLabelColumn
        VATRateCode.Format = ""
        VATRateCode.FormatInfo = Nothing
        VATRateCode.HeaderText = "Code"
        VATRateCode.MappingName = "VATRateCode"
        VATRateCode.ReadOnly = True
        VATRateCode.Width = 75
        VATRateCode.NullText = ""
        tbStyle.GridColumnStyles.Add(VATRateCode)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
        Me.dgVATRates.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.grpDetails)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.grpDetails.Enabled = False
                Me.btnAddNew.Enabled = False
                Me.btnSave.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.grpDetails.Enabled = True
                Me.btnAddNew.Enabled = True
                Me.btnSave.Enabled = True
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.grpDetails.Enabled = True
                Me.btnSave.Enabled = True
        End Select
        PageState = state
    End Sub
#End Region

#Region "Events"

    Private Sub FRMVATRates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgVATRates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVATRates.Click
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If Not SelectedVATRateDataRow Is Nothing Then
                Me.txtVATRate.Text = Entity.Sys.Helper.MakeDoubleValid(SelectedVATRateDataRow("VATRate"))
                Me.dtpVATDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedVATRateDataRow("DateIntroduced"))
                Me.txtCode.Text = Entity.Sys.Helper.MakeStringValid(SelectedVATRateDataRow("VATRateCode"))
            Else
                SetUpPageState(Entity.Sys.Enums.FormState.Insert)
            End If
        Catch ex As Exception
            ShowMessage("Item data cannot load : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        SetUpPageState(Entity.Sys.Enums.FormState.Insert)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateDatagrid(ByVal state As Entity.Sys.Enums.FormState)
        RatesDataview = DB.VATRatesSQL.VATRates_GetAll
        SetUpPageState(state)
    End Sub

    Private Sub Save()
        Dim vatRate As New Entity.VATRatess.VATRates
        vatRate.IgnoreExceptionsOnSetMethods = True
        vatRate.SetVATRate = Me.txtVATRate.Text
        vatRate.DateIntroduced = dtpVATDate.Value
        vatRate.SetVATRateCode = Me.txtCode.Text
        Dim validator As New Entity.VATRatess.VATRatesValidator

        Try
            validator.Validate(vatRate)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.VATRatesSQL.Insert(vatRate)
                Case Entity.Sys.Enums.FormState.Update
                    vatRate.SetVATRateID = SelectedVATRateDataRow.Item("VATRateID")
                    DB.VATRatesSQL.Update(vatRate)
            End Select

            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        Catch ex As ValidationException
            ShowMessage(validator.CriticalMessagesString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class
