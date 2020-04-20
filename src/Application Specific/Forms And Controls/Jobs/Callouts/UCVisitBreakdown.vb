Imports FSM.Entity.Sys

Public Class UCVisitBreakdown : Inherits UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents Label1 As Label

    Friend WithEvents txtNotesToEngineer As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDate As TextBox
    Friend WithEvents txtOutcome As TextBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnView As Button
    Friend WithEvents lblDate As Label
    Friend WithEvents lblOutcome As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpVisitDetails As TabPage
    Friend WithEvents tpParts As TabPage
    Friend WithEvents dgPartsAndProducts As DataGrid
    Friend WithEvents cbxPartsToFit As CheckBox
    Friend WithEvents cboExpected As ComboBox
    Friend WithEvents chkRecharge As CheckBox
    Friend WithEvents btnGetOrderRef As Button
    Friend WithEvents EstVisitDate As TabPage
    Friend WithEvents BtnEstSave As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpEstimateVisitDate As DateTimePicker
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnMoveParts As Button
    Friend WithEvents cmsPrint As ContextMenuStrip
    Friend WithEvents EngineerJobSheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProForrmaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPrintInstall As ToolStripMenuItem
    Friend WithEvents BtnPrintServiceLetter As ToolStripMenuItem
    Friend WithEvents lblAuthCode As Label
    Friend WithEvents btnGenerateAuthCode As Button
    Friend WithEvents btnPrintJobLetter As ToolStripMenuItem
    Friend WithEvents chkSendText As CheckBox
    Friend WithEvents btnUploadVisit As Button
    Friend WithEvents PrintSolarInstall As ToolStripMenuItem
    Friend WithEvents PrintElectricalAppointment As ToolStripMenuItem
    Friend WithEvents btnPrint As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtNotesToEngineer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtOutcome = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpVisitDetails = New System.Windows.Forms.TabPage()
        Me.btnUploadVisit = New System.Windows.Forms.Button()
        Me.chkSendText = New System.Windows.Forms.CheckBox()
        Me.chkRecharge = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cbxPartsToFit = New System.Windows.Forms.CheckBox()
        Me.cboExpected = New System.Windows.Forms.ComboBox()
        Me.tpParts = New System.Windows.Forms.TabPage()
        Me.lblAuthCode = New System.Windows.Forms.Label()
        Me.btnGenerateAuthCode = New System.Windows.Forms.Button()
        Me.btnMoveParts = New System.Windows.Forms.Button()
        Me.btnGetOrderRef = New System.Windows.Forms.Button()
        Me.dgPartsAndProducts = New System.Windows.Forms.DataGrid()
        Me.EstVisitDate = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpEstimateVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnEstSave = New System.Windows.Forms.Button()
        Me.cmsPrint = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EngineerJobSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProForrmaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrintInstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnPrintServiceLetter = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrintJobLetter = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSolarInstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintElectricalAppointment = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.tpVisitDetails.SuspendLayout()
        Me.tpParts.SuspendLayout()
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EstVisitDate.SuspendLayout()
        Me.cmsPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNotesToEngineer
        '
        Me.txtNotesToEngineer.AcceptsReturn = True
        Me.txtNotesToEngineer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotesToEngineer.Location = New System.Drawing.Point(78, 8)
        Me.txtNotesToEngineer.Multiline = True
        Me.txtNotesToEngineer.Name = "txtNotesToEngineer"
        Me.txtNotesToEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotesToEngineer.Size = New System.Drawing.Size(406, 89)
        Me.txtNotesToEngineer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 51)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Notes To Engineer"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(8, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status"
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Location = New System.Drawing.Point(8, 128)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(56, 16)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Date"
        '
        'lblOutcome
        '
        Me.lblOutcome.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOutcome.Location = New System.Drawing.Point(8, 157)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(64, 16)
        Me.lblOutcome.TabIndex = 4
        Me.lblOutcome.Text = "Outcome"
        '
        'txtDate
        '
        Me.txtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDate.Location = New System.Drawing.Point(78, 128)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(283, 21)
        Me.txtDate.TabIndex = 4
        '
        'txtOutcome
        '
        Me.txtOutcome.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOutcome.Location = New System.Drawing.Point(78, 152)
        Me.txtOutcome.Name = "txtOutcome"
        Me.txtOutcome.ReadOnly = True
        Me.txtOutcome.Size = New System.Drawing.Size(207, 21)
        Me.txtOutcome.TabIndex = 5
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(78, 101)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(283, 21)
        Me.cboStatus.TabIndex = 1
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(388, 184)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(96, 23)
        Me.btnView.TabIndex = 8
        Me.btnView.Text = "View Results"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpVisitDetails)
        Me.TabControl1.Controls.Add(Me.tpParts)
        Me.TabControl1.Controls.Add(Me.EstVisitDate)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(500, 240)
        Me.TabControl1.TabIndex = 7
        '
        'tpVisitDetails
        '
        Me.tpVisitDetails.Controls.Add(Me.btnUploadVisit)
        Me.tpVisitDetails.Controls.Add(Me.chkSendText)
        Me.tpVisitDetails.Controls.Add(Me.chkRecharge)
        Me.tpVisitDetails.Controls.Add(Me.btnPrint)
        Me.tpVisitDetails.Controls.Add(Me.Label1)
        Me.tpVisitDetails.Controls.Add(Me.Label2)
        Me.tpVisitDetails.Controls.Add(Me.lblDate)
        Me.tpVisitDetails.Controls.Add(Me.txtDate)
        Me.tpVisitDetails.Controls.Add(Me.txtOutcome)
        Me.tpVisitDetails.Controls.Add(Me.cboStatus)
        Me.tpVisitDetails.Controls.Add(Me.btnView)
        Me.tpVisitDetails.Controls.Add(Me.txtNotesToEngineer)
        Me.tpVisitDetails.Controls.Add(Me.cbxPartsToFit)
        Me.tpVisitDetails.Controls.Add(Me.cboExpected)
        Me.tpVisitDetails.Controls.Add(Me.lblOutcome)
        Me.tpVisitDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpVisitDetails.Name = "tpVisitDetails"
        Me.tpVisitDetails.Size = New System.Drawing.Size(492, 214)
        Me.tpVisitDetails.TabIndex = 0
        Me.tpVisitDetails.Text = "Visit Details"
        '
        'btnUploadVisit
        '
        Me.btnUploadVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUploadVisit.Location = New System.Drawing.Point(11, 184)
        Me.btnUploadVisit.Name = "btnUploadVisit"
        Me.btnUploadVisit.Size = New System.Drawing.Size(104, 23)
        Me.btnUploadVisit.TabIndex = 13
        Me.btnUploadVisit.Text = "Upload Visit"
        '
        'chkSendText
        '
        Me.chkSendText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSendText.AutoSize = True
        Me.chkSendText.Location = New System.Drawing.Point(297, 156)
        Me.chkSendText.Name = "chkSendText"
        Me.chkSendText.Size = New System.Drawing.Size(187, 17)
        Me.chkSendText.TabIndex = 12
        Me.chkSendText.Text = "Exclude From Auto-Message"
        Me.chkSendText.UseVisualStyleBackColor = True
        '
        'chkRecharge
        '
        Me.chkRecharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkRecharge.AutoSize = True
        Me.chkRecharge.Location = New System.Drawing.Point(395, 130)
        Me.chkRecharge.Name = "chkRecharge"
        Me.chkRecharge.Size = New System.Drawing.Size(80, 17)
        Me.chkRecharge.TabIndex = 11
        Me.chkRecharge.Text = "Recharge"
        Me.chkRecharge.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(288, 184)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(96, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print..."
        '
        'cbxPartsToFit
        '
        Me.cbxPartsToFit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxPartsToFit.AutoSize = True
        Me.cbxPartsToFit.Location = New System.Drawing.Point(395, 105)
        Me.cbxPartsToFit.Name = "cbxPartsToFit"
        Me.cbxPartsToFit.Size = New System.Drawing.Size(89, 17)
        Me.cbxPartsToFit.TabIndex = 2
        Me.cbxPartsToFit.Text = "Parts To Fit"
        Me.cbxPartsToFit.UseVisualStyleBackColor = True
        '
        'cboExpected
        '
        Me.cboExpected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExpected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpected.Location = New System.Drawing.Point(78, 64)
        Me.cboExpected.Name = "cboExpected"
        Me.cboExpected.Size = New System.Drawing.Size(364, 21)
        Me.cboExpected.TabIndex = 3
        Me.cboExpected.Visible = False
        '
        'tpParts
        '
        Me.tpParts.Controls.Add(Me.lblAuthCode)
        Me.tpParts.Controls.Add(Me.btnGenerateAuthCode)
        Me.tpParts.Controls.Add(Me.btnMoveParts)
        Me.tpParts.Controls.Add(Me.btnGetOrderRef)
        Me.tpParts.Controls.Add(Me.dgPartsAndProducts)
        Me.tpParts.Location = New System.Drawing.Point(4, 22)
        Me.tpParts.Name = "tpParts"
        Me.tpParts.Size = New System.Drawing.Size(492, 214)
        Me.tpParts.TabIndex = 1
        Me.tpParts.Text = "Parts && Products Allocated"
        '
        'lblAuthCode
        '
        Me.lblAuthCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAuthCode.AutoSize = True
        Me.lblAuthCode.Location = New System.Drawing.Point(111, 187)
        Me.lblAuthCode.Name = "lblAuthCode"
        Me.lblAuthCode.Size = New System.Drawing.Size(0, 13)
        Me.lblAuthCode.TabIndex = 28
        '
        'btnGenerateAuthCode
        '
        Me.btnGenerateAuthCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateAuthCode.Location = New System.Drawing.Point(12, 182)
        Me.btnGenerateAuthCode.Name = "btnGenerateAuthCode"
        Me.btnGenerateAuthCode.Size = New System.Drawing.Size(93, 23)
        Me.btnGenerateAuthCode.TabIndex = 27
        Me.btnGenerateAuthCode.Text = "Auth Code"
        Me.btnGenerateAuthCode.UseVisualStyleBackColor = True
        '
        'btnMoveParts
        '
        Me.btnMoveParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveParts.Location = New System.Drawing.Point(340, 6)
        Me.btnMoveParts.Name = "btnMoveParts"
        Me.btnMoveParts.Size = New System.Drawing.Size(144, 23)
        Me.btnMoveParts.TabIndex = 26
        Me.btnMoveParts.Text = "Reallocate Parts"
        Me.btnMoveParts.UseVisualStyleBackColor = True
        '
        'btnGetOrderRef
        '
        Me.btnGetOrderRef.Location = New System.Drawing.Point(9, 6)
        Me.btnGetOrderRef.Name = "btnGetOrderRef"
        Me.btnGetOrderRef.Size = New System.Drawing.Size(145, 23)
        Me.btnGetOrderRef.TabIndex = 25
        Me.btnGetOrderRef.Text = "Create Quick PO"
        Me.btnGetOrderRef.UseVisualStyleBackColor = True
        '
        'dgPartsAndProducts
        '
        Me.dgPartsAndProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsAndProducts.DataMember = ""
        Me.dgPartsAndProducts.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dgPartsAndProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsAndProducts.Location = New System.Drawing.Point(8, 33)
        Me.dgPartsAndProducts.Name = "dgPartsAndProducts"
        Me.dgPartsAndProducts.Size = New System.Drawing.Size(476, 143)
        Me.dgPartsAndProducts.TabIndex = 1
        '
        'EstVisitDate
        '
        Me.EstVisitDate.Controls.Add(Me.Label6)
        Me.EstVisitDate.Controls.Add(Me.dtpEstimateVisitDate)
        Me.EstVisitDate.Controls.Add(Me.txtPassword)
        Me.EstVisitDate.Controls.Add(Me.Label7)
        Me.EstVisitDate.Controls.Add(Me.BtnEstSave)
        Me.EstVisitDate.Location = New System.Drawing.Point(4, 22)
        Me.EstVisitDate.Name = "EstVisitDate"
        Me.EstVisitDate.Size = New System.Drawing.Size(492, 214)
        Me.EstVisitDate.TabIndex = 2
        Me.EstVisitDate.Text = "Est Visit Date"
        Me.EstVisitDate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Estimated Visit Date"
        '
        'dtpEstimateVisitDate
        '
        Me.dtpEstimateVisitDate.Enabled = False
        Me.dtpEstimateVisitDate.Location = New System.Drawing.Point(199, 50)
        Me.dtpEstimateVisitDate.Name = "dtpEstimateVisitDate"
        Me.dtpEstimateVisitDate.Size = New System.Drawing.Size(176, 21)
        Me.dtpEstimateVisitDate.TabIndex = 11
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(199, 22)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(176, 21)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Enter the override password"
        '
        'BtnEstSave
        '
        Me.BtnEstSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEstSave.Location = New System.Drawing.Point(98, 84)
        Me.BtnEstSave.Name = "BtnEstSave"
        Me.BtnEstSave.Size = New System.Drawing.Size(96, 23)
        Me.BtnEstSave.TabIndex = 8
        Me.BtnEstSave.Text = "Save"
        '
        'cmsPrint
        '
        Me.cmsPrint.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EngineerJobSheetToolStripMenuItem, Me.ProForrmaToolStripMenuItem, Me.btnPrintInstall, Me.BtnPrintServiceLetter, Me.btnPrintJobLetter, Me.PrintSolarInstall, Me.PrintElectricalAppointment})
        Me.cmsPrint.Name = "cmsPrint"
        Me.cmsPrint.Size = New System.Drawing.Size(224, 158)
        '
        'EngineerJobSheetToolStripMenuItem
        '
        Me.EngineerJobSheetToolStripMenuItem.Name = "EngineerJobSheetToolStripMenuItem"
        Me.EngineerJobSheetToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.EngineerJobSheetToolStripMenuItem.Text = "Engineer Job Sheet"
        '
        'ProForrmaToolStripMenuItem
        '
        Me.ProForrmaToolStripMenuItem.Name = "ProForrmaToolStripMenuItem"
        Me.ProForrmaToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ProForrmaToolStripMenuItem.Text = "Pro-Forma"
        '
        'btnPrintInstall
        '
        Me.btnPrintInstall.Name = "btnPrintInstall"
        Me.btnPrintInstall.Size = New System.Drawing.Size(223, 22)
        Me.btnPrintInstall.Text = "Print Install Sheet"
        '
        'BtnPrintServiceLetter
        '
        Me.BtnPrintServiceLetter.Name = "BtnPrintServiceLetter"
        Me.BtnPrintServiceLetter.Size = New System.Drawing.Size(223, 22)
        Me.BtnPrintServiceLetter.Text = "Print Service Letter"
        Me.BtnPrintServiceLetter.Visible = False
        '
        'btnPrintJobLetter
        '
        Me.btnPrintJobLetter.Name = "btnPrintJobLetter"
        Me.btnPrintJobLetter.Size = New System.Drawing.Size(223, 22)
        Me.btnPrintJobLetter.Text = "Print Appointment Letter"
        '
        'PrintSolarInstall
        '
        Me.PrintSolarInstall.Name = "PrintSolarInstall"
        Me.PrintSolarInstall.Size = New System.Drawing.Size(223, 22)
        Me.PrintSolarInstall.Text = "Print Solar Installation "
        Me.PrintSolarInstall.Visible = False
        '
        'PrintElectricalAppointment
        '
        Me.PrintElectricalAppointment.Name = "PrintElectricalAppointment"
        Me.PrintElectricalAppointment.Size = New System.Drawing.Size(223, 22)
        Me.PrintElectricalAppointment.Text = "Print Electrical Appointment"
        Me.PrintElectricalAppointment.Visible = False
        '
        'UCVisitBreakdown
        '
        Me.AutoScroll = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCVisitBreakdown"
        Me.Size = New System.Drawing.Size(500, 240)
        Me.TabControl1.ResumeLayout(False)
        Me.tpVisitDetails.ResumeLayout(False)
        Me.tpVisitDetails.PerformLayout()
        Me.tpParts.ResumeLayout(False)
        Me.tpParts.PerformLayout()
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EstVisitDate.ResumeLayout(False)
        Me.EstVisitDate.PerformLayout()
        Me.cmsPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupDG()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return EngineerVisit
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _onControl As UCCalloutBreakdown = Nothing

    Public Property OnControl() As UCCalloutBreakdown
        Get
            Return _onControl
        End Get
        Set(ByVal Value As UCCalloutBreakdown)
            _onControl = Value
        End Set
    End Property

    Private _engineerVisit As Entity.EngineerVisits.EngineerVisit = Nothing

    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _engineerVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _engineerVisit = Value

            If _engineerVisit Is Nothing Then
                _engineerVisit = New Entity.EngineerVisits.EngineerVisit
            End If

        End Set
    End Property

    Private _PartsAndProducts As DataView = Nothing

    Public Property PartsAndProducts() As DataView
        Get
            Return _PartsAndProducts
        End Get
        Set(ByVal Value As DataView)
            _PartsAndProducts = Value

            _PartsAndProducts.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
            _PartsAndProducts.AllowNew = False
            _PartsAndProducts.AllowEdit = False
            _PartsAndProducts.AllowDelete = False
            Me.dgPartsAndProducts.DataSource = PartsAndProducts
        End Set
    End Property

    Private ReadOnly Property SelectedPartProductDataRow() As DataRow
        Get
            If Not Me.dgPartsAndProducts.CurrentRowIndex = -1 Then
                Return PartsAndProducts(Me.dgPartsAndProducts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PartProductID As Integer = 0

    Public Property PartProductID() As Integer
        Get
            Return _PartProductID
        End Get
        Set(ByVal Value As Integer)
            _PartProductID = Value
        End Set
    End Property

    Private _Type As String = String.Empty

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal Value As String)
            _Type = Value
        End Set
    End Property

    Private _PartsProductsToRemoveFromOrder As New ArrayList

    Public Property PartsProductsToRemoveFromOrder() As ArrayList
        Get
            Return _PartsProductsToRemoveFromOrder
        End Get
        Set(ByVal Value As ArrayList)
            _PartsProductsToRemoveFromOrder = Value
        End Set
    End Property

    Private _PartsProductsToReallocated As New ArrayList

    Public Property PartsProductsToReallocated() As ArrayList
        Get
            Return _PartsProductsToReallocated
        End Get
        Set(ByVal Value As ArrayList)
            _PartsProductsToReallocated = Value
        End Set
    End Property

    Private _change As Boolean = False

    Public Property change() As Boolean
        Get
            Return _change
        End Get
        Set(ByVal Value As Boolean)
            _change = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCVisitBreakdown_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnGetOrderRef_Click(sender As Object, e As EventArgs) Handles btnGetOrderRef.Click

        If EngineerVisit.EngineerVisitID = 0 Then
            ShowMessage("Please save visit before creating order!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dialogue As TabletOrder
        dialogue = checkIfExists(GetType(TabletOrder).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(TabletOrder))
        End If
        dialogue.EngineerID = EngineerVisit.EngineerID
        dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID
        dialogue.ShowInTaskbar = False
        dialogue.ShowDialog()
        If Not CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).ParentForm Is Nothing Then
            CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).Populate()
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnView.Click
        Dim [continue] As Boolean = False

        Select Case EngineerVisit.StatusEnumID
            Case CInt(Enums.VisitStatus.NOT_SET)
                ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Enums.VisitStatus.Parts_Need_Ordering)
                ShowMessage("Parts Need Ordering for this visit, once ordered and received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Enums.VisitStatus.Waiting_For_Parts)
                ShowMessage("This visit is waiting for parts, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Enums.VisitStatus.Parts_Despatched)
                ShowMessage("This visit is waiting for parts to be received by engineer, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Enums.VisitStatus.Ready_For_Schedule)
                If ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Enums.VisitStatus.Scheduled)
                If ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Enums.VisitStatus.Downloaded)
                ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case Else
                [continue] = True
        End Select

        If [continue] Then
            ShowForm(GetType(FRMEngineerVisit), True, New Object() {EngineerVisit.EngineerVisitID, Me})

            If Not CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).ParentForm Is Nothing Then
                CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).Populate()
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cmsPrint.Show(btnPrint, New Point(0, 0)) 'Show new ContextStrip instead of a single button click
    End Sub

    Private Sub PrintEngjob(sender As Object, e As EventArgs) Handles EngineerJobSheetToolStripMenuItem.Click
        Dim details As New ArrayList
        details.Add(EngineerVisit)
        Dim oPrint As New Printing(details, "Engineer Jobsheet ", Enums.SystemDocumentType.SVR)
    End Sub

    Private Sub btnPrintInstall_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPrintInstall.Click
        Dim details As New ArrayList
        details.Add(EngineerVisit)
        Dim oPrint As New Printing(details, "Install ", Enums.SystemDocumentType.Install)
    End Sub

#End Region

#Region "Setup"

    Public Sub SetupDG()
        Helper.SetUpDataGrid(Me.dgPartsAndProducts)
        Dim tStyle As DataGridTableStyle = Me.dgPartsAndProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim supplier As New DataGridLabelColumn
        supplier.Format = ""
        supplier.FormatInfo = Nothing
        supplier.HeaderText = "Supplier"
        supplier.MappingName = "Supplier"
        supplier.ReadOnly = True
        supplier.Width = 80
        supplier.NullText = ""
        tStyle.GridColumnStyles.Add(supplier)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "type"
        type.ReadOnly = True
        type.Width = 60
        type.NullText = ""
        tStyle.GridColumnStyles.Add(type)

        Dim number As New DataGridLabelColumn
        number.Format = ""
        number.FormatInfo = Nothing
        number.HeaderText = "Number"
        number.MappingName = "number"
        number.ReadOnly = True
        number.Width = 80
        number.NullText = ""
        tStyle.GridColumnStyles.Add(number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 140
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim quantity As New DataGridLabelColumn
        quantity.Format = ""
        quantity.FormatInfo = Nothing
        quantity.HeaderText = "Qty"
        quantity.MappingName = "quantity"
        quantity.ReadOnly = True
        quantity.Width = 50
        quantity.NullText = ""
        tStyle.GridColumnStyles.Add(quantity)

        Dim sellPrice As New DataGridLabelColumn
        sellPrice.Format = "C"
        sellPrice.FormatInfo = Nothing
        sellPrice.HeaderText = "Buy Price"
        sellPrice.MappingName = "sellPrice"
        sellPrice.ReadOnly = True
        sellPrice.Width = 75
        sellPrice.NullText = ""
        tStyle.GridColumnStyles.Add(sellPrice)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Ref."
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 75
        OrderReference.NullText = "N/A"
        tStyle.GridColumnStyles.Add(OrderReference)

        Dim OrderStatus As New DataGridLabelColumn
        OrderStatus.Format = ""
        OrderStatus.FormatInfo = Nothing
        OrderStatus.HeaderText = "Order Status"
        OrderStatus.MappingName = "OrderStatus"
        OrderStatus.ReadOnly = True
        OrderStatus.Width = 75
        OrderStatus.NullText = "N/A"
        tStyle.GridColumnStyles.Add(OrderStatus)

        Dim QuantityOrdered As New DataGridLabelColumn
        QuantityOrdered.Format = ""
        QuantityOrdered.FormatInfo = Nothing
        QuantityOrdered.HeaderText = "Qty Ordered"
        QuantityOrdered.MappingName = "QuantityOrdered"
        QuantityOrdered.ReadOnly = True
        QuantityOrdered.Width = 75
        QuantityOrdered.NullText = "N/A"
        tStyle.GridColumnStyles.Add(QuantityOrdered)

        Dim QuantityReceived As New DataGridLabelColumn
        QuantityReceived.Format = ""
        QuantityReceived.FormatInfo = Nothing
        QuantityReceived.HeaderText = "Order Qty Received"
        QuantityReceived.MappingName = "QuantityReceived"
        QuantityReceived.ReadOnly = True
        QuantityReceived.Width = 75
        QuantityReceived.NullText = "N/A"
        tStyle.GridColumnStyles.Add(QuantityReceived)

        Dim CreditQty As New DataGridLabelColumn
        CreditQty.Format = ""
        CreditQty.FormatInfo = Nothing
        CreditQty.HeaderText = "Qty Credit"
        CreditQty.MappingName = "CreditQty"
        CreditQty.ReadOnly = True
        CreditQty.Width = 75
        CreditQty.NullText = "0"
        tStyle.GridColumnStyles.Add(CreditQty)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
        Me.dgPartsAndProducts.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        Combo.SetUpCombo(Me.cboExpected, CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).DvEngineers.Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable)
        Combo.SetSelectedComboItem_By_Value(Me.cboExpected, EngineerVisit.ExpectedEngineerID)
        If IsDBNull(EngineerVisit.EstimatedDate) Then
            Me.dtpEstimateVisitDate.Value = Today
        Else
            Me.dtpEstimateVisitDate.Value = EngineerVisit.EstimatedDate
        End If

        If EngineerVisit.ExpectedEngineerID = 0 Then
            Me.cboExpected.Enabled = True
        Else
            Me.cboExpected.Enabled = False
        End If

        Select Case EngineerVisit.StatusEnumID
            Case CInt(Enums.VisitStatus.NOT_SET),
                 CInt(Enums.VisitStatus.Parts_Need_Ordering),
                 CInt(Enums.VisitStatus.Waiting_For_Parts),
                 CInt(Enums.VisitStatus.Parts_Despatched)

                Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Selection(), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
                Combo.SetSelectedComboItem_By_Value(Me.cboStatus, EngineerVisit.StatusEnumID)

                Me.cbxPartsToFit.Checked = EngineerVisit.PartsToFit
                Me.chkRecharge.Checked = False

                Me.cboStatus.Enabled = True
                Me.cbxPartsToFit.Enabled = True
                Me.chkRecharge.Enabled = True
                Me.btnMoveParts.Enabled = True

                Me.txtNotesToEngineer.ReadOnly = False

                Me.txtDate.Text = "Not Set"
                Me.txtOutcome.Text = "Not Set"

                Me.txtDate.Visible = False
                Me.txtOutcome.Visible = False
                Me.btnView.Visible = False
                Me.btnPrintInstall.Visible = False
                Me.lblDate.Visible = False
                Me.lblOutcome.Visible = False

            Case CInt(Enums.VisitStatus.Ready_For_Schedule)

                Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Selection(), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
                Combo.SetSelectedComboItem_By_Value(Me.cboStatus, EngineerVisit.StatusEnumID)

                Me.cbxPartsToFit.Checked = EngineerVisit.PartsToFit

                Me.cboStatus.Enabled = True
                Me.cbxPartsToFit.Enabled = True
                Me.chkRecharge.Enabled = True
                Me.btnMoveParts.Enabled = True
                Me.cboExpected.Enabled = False

                Me.txtNotesToEngineer.ReadOnly = False

                Me.txtDate.Text = "Not Set"
                Me.txtOutcome.Text = "Not Set"

                Me.txtDate.Visible = False
                Me.lblDate.Visible = False
                Me.lblOutcome.Visible = False
                Me.txtOutcome.Visible = False
                Me.btnView.Visible = True
                Me.btnPrintInstall.Visible = True

            Case CInt(Enums.VisitStatus.Scheduled),
                 CInt(Enums.VisitStatus.Downloaded)

                Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing(), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
                Combo.SetSelectedComboItem_By_Value(Me.cboStatus, EngineerVisit.StatusEnumID)

                Me.cbxPartsToFit.Checked = EngineerVisit.PartsToFit

                Me.cboStatus.Enabled = False
                Me.cbxPartsToFit.Enabled = False
                Me.chkRecharge.Enabled = False
                Me.btnMoveParts.Enabled = False
                Me.cboExpected.Enabled = False

                Me.txtOutcome.Text = "Not Set"

                Me.txtNotesToEngineer.ReadOnly = False

                Me.txtDate.Visible = True
                Me.lblDate.Visible = True
                Me.lblOutcome.Visible = False
                Me.txtOutcome.Visible = False
                Me.btnView.Visible = True
                Me.btnPrintInstall.Visible = True

                'check if the visit is more than one days
                Dim totalDays As Integer = DateHelper.GetDays(EngineerVisit.StartDateTime, EngineerVisit.EndDateTime)

                If totalDays > 0 Then
                    Me.txtDate.Text =
                        EngineerVisit.StartDateTime.ToShortDateString() & " - " &
                        EngineerVisit.EndDateTime.ToShortDateString() & " - " &
                        DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)?.Name
                Else
                    If EngineerVisit.StartDateTime <> Nothing Then
                        Me.txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() & " - " &
                        DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)?.Name
                    End If
                End If

                If EngineerVisit.VisitNumber > 0 Or OnControl.OnContol.Job?.JobTypeID = CInt(Enums.JobTypes.ServiceCertificate) Or OnControl.OnContol.Job?.JobTypeID = CInt(Enums.JobTypes.Service) Then
                    Me.BtnPrintServiceLetter.Visible = True
                End If

                Me.PrintSolarInstall.Visible = True
                Me.PrintElectricalAppointment.Visible = True

            Case CInt(Enums.VisitStatus.Uploaded),
                 CInt(Enums.VisitStatus.Not_To_Be_Invoiced),
                 CInt(Enums.VisitStatus.Ready_To_Be_Invoiced),
                 CInt(Enums.VisitStatus.Invoiced)

                Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing(), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
                Combo.SetSelectedComboItem_By_Value(Me.cboStatus, EngineerVisit.StatusEnumID)

                Me.cbxPartsToFit.Checked = EngineerVisit.PartsToFit

                Me.cboStatus.Enabled = False
                Me.cbxPartsToFit.Enabled = False
                Me.chkRecharge.Enabled = False
                Me.btnMoveParts.Enabled = True
                Me.btnView.Enabled = True
                Me.cboExpected.Enabled = False
                Me.chkSendText.Visible = False

                Me.txtNotesToEngineer.ReadOnly = True

                Me.txtDate.Visible = True
                Me.txtOutcome.Visible = True
                Me.lblDate.Visible = True
                Me.lblOutcome.Visible = True
                Me.btnPrintInstall.Visible = False

                'check if the visit is more than one days
                Dim totalDays As Integer = DateHelper.GetDays(
                    EngineerVisit.StartDateTime, EngineerVisit.EndDateTime)

                If EngineerVisit.StartDateTime = Nothing Then
                    Me.txtDate.Text = Format(EngineerVisit.ManualEntryOn, "dd/MMM/yyyy") & " (Manually Completed)"

                    If totalDays > 0 Then
                        Me.txtDate.Text =
                            EngineerVisit.StartDateTime.ToShortDateString() & " - " &
                            EngineerVisit.EndDateTime.ToShortDateString() & " - " &
                            "(Manually Completed)"
                    End If
                Else
                    Dim eng As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)
                    If eng Is Nothing Then
                        Me.txtDate.Text = Format(EngineerVisit.StartDateTime, "dd/MMM/yyyy")

                        If totalDays > 0 Then
                            Me.txtDate.Text =
                                EngineerVisit.StartDateTime.ToShortDateString() & " - " &
                                EngineerVisit.EndDateTime.ToShortDateString()
                        End If
                    Else
                        Me.txtDate.Text = Format(EngineerVisit.StartDateTime, "dd/MMM/yyyy") & " - " & eng.Name
                        If totalDays > 0 Then
                            Me.txtDate.Text =
                                EngineerVisit.StartDateTime.ToShortDateString() & " - " &
                                EngineerVisit.EndDateTime.ToShortDateString() & " - " &
                                eng.Name
                        End If
                    End If
                End If

                If EngineerVisit.VisitNumber > 0 Or OnControl.OnContol.Job?.JobTypeID = CInt(Enums.JobTypes.ServiceCertificate) Or
                    OnControl.OnContol.Job?.JobTypeID = CInt(Enums.JobTypes.Service) Then
                    Me.BtnPrintServiceLetter.Visible = True
                End If

                Me.PrintSolarInstall.Visible = True
                Me.PrintElectricalAppointment.Visible = True

                Select Case EngineerVisit.OutcomeEnumID
                    Case CInt(Enums.EngineerVisitOutcomes.NOT_SET)
                        Me.txtOutcome.Text = "Not Set"
                    Case CInt(Enums.EngineerVisitOutcomes.Complete)
                        Me.txtOutcome.Text = "Complete"
                    Case CInt(Enums.EngineerVisitOutcomes.Carded)
                        Me.txtOutcome.Text = "Carded"
                    Case CInt(Enums.EngineerVisitOutcomes.Could_Not_Start)
                        Me.txtOutcome.Text = "Could Not Start"
                    Case CInt(Enums.EngineerVisitOutcomes.Declined)
                        Me.txtOutcome.Text = "Declined"
                    Case CInt(Enums.EngineerVisitOutcomes.Further_Works)
                        Me.txtOutcome.Text = "Further Works"
                    Case CInt(Enums.EngineerVisitOutcomes.Visit_Not_Required)
                        Me.txtOutcome.Text = "Visit Not Required"
                End Select
        End Select

        If EngineerVisit.StatusEnumID = Enums.VisitStatus.Downloaded Then
            Me.btnGenerateAuthCode.Visible = True
            Me.lblAuthCode.Visible = True
            Me.btnUploadVisit.Visible = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT)
        Else
            Me.btnGenerateAuthCode.Visible = False
            Me.lblAuthCode.Visible = False
            Me.btnUploadVisit.Visible = False
        End If

        Me.chkRecharge.Checked = EngineerVisit.Recharge
        Me.chkSendText.Checked = EngineerVisit.ExcludeFromTextMessage
        Me.txtNotesToEngineer.Text = EngineerVisit.NotesToEngineer
        Me.cbxPartsToFit.Visible = True
        If OnControl.OnContol.Job.StatusEnumID >= CInt(Enums.JobStatus.Complete) Then
            Me.cboStatus.Enabled = False
            Me.txtNotesToEngineer.Enabled = False
            Me.cboExpected.Enabled = False
        End If

        Dim drPartsAndProducts As DataRow() = OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Select("EngineerVisitId = " & EngineerVisit.EngineerVisitID)
        Dim dtPartsProducts As DataTable = OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Clone
        If drPartsAndProducts.Length > 0 Then
            dtPartsProducts = drPartsAndProducts.CopyToDataTable()
        End If

        PartsAndProducts = New DataView(dtPartsProducts)
        change = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        'DO NOTHING
    End Function

    Public Sub SendToPrint(Optional ByVal fileName As String = "")
        Dim dr As DataRow = Nothing
        Dim lm As DataView = DB.LetterManager.MakeServiceLetter(EngineerVisit.EngineerVisitID)
        lm.Table.Columns.Add("FileName")
        If lm.Count > 0 And String.IsNullOrEmpty(fileName) Then
            dr = lm.Table.Rows(0)
        Else
            Dim site As Entity.Sites.Site = OnControl.OnContol.Site
            Dim dt As DataTable = lm.Table.Clone
            dr = dt.NewRow()
            dr("Name") = site.Name
            dr("Address1") = site.Address1
            dr("Address2") = site.Address2
            dr("Address3") = site.Address3
            dr("Address4") = site.Address4
            dr("Address5") = site.Address5
            dr("Postcode") = site.Postcode
            dr("SiteID") = site.SiteID
            dr("CustomerID") = site.CustomerID
            dr("SolidFuel") = site.SolidFuel
            dr("PropertyVoid") = site.PropertyVoid
            dr("LastServiceDate") = site.LastServiceDate
            dr("CommercialDistrict") = site.CommercialDistrict
            dr("SiteFuel") = site.SiteFuel
            dr("Type") = "Generic"
            dr("NextVisitDate") = EngineerVisit.StartDateTime
            dr("StartDateTime") = EngineerVisit.StartDateTime
            dr("AMPM") = ""
            dr("JobID") = OnControl.OnContol.Job.JobID
            dr("JobNumber") = OnControl.OnContol.Job.JobNumber
            dr("FileName") = fileName
            dt.Rows.Add(dr)

            dr = dt.Rows(0)
        End If
        Dim details As New ArrayList
        details.Add(dr)

        Dim oPrint As New Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters)
        If dr("Type") = "Letter 2" Then
            dr("Type") = "Letter 2 HAND"
            details.Clear()
            details.Add(dr)

            oPrint = New Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters)

        End If

        If dr("Type") = "Letter 3" Then
            If dr("CommercialDistrict") = "1" Then
                dr("Type") = "Letter 3 COM HAND"
            Else
                dr("Type") = "Letter 3 HAND"
            End If
            details.Clear()
            details.Add(dr)
            oPrint = New Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters)
        End If
    End Sub

#End Region

    Private Sub btnEstSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnEstSave.Click
        DB.EngineerVisits.AlterEstimatedDate(EngineerVisit.JobOfWorkID, CDate(dtpEstimateVisitDate.Value))
        Me.dtpEstimateVisitDate.Enabled = False
        Me.txtPassword.Text = ""
        Me.BtnEstSave.Enabled = False
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtPassword.TextChanged
        If Helper.HashPassword(Me.txtPassword.Text.Trim) = DB.Manager.Get.OverridePassword Then
            Me.dtpEstimateVisitDate.Enabled = True
            Me.BtnEstSave.Enabled = True
        Else
            Me.dtpEstimateVisitDate.Enabled = False
            Me.BtnEstSave.Enabled = False
        End If
    End Sub

    Private Sub btnMoveParts_Click(sender As Object, e As EventArgs) Handles btnMoveParts.Click
        If EngineerVisit Is Nothing OrElse EngineerVisit.EngineerVisitID = 0 Then Exit Sub

        Dim f As New FRMMoveParts
        f.EngineerVisitId = EngineerVisit.EngineerVisitID
        f.JobNumber = CType(CType(OnControl, UCCalloutBreakdown).OnContol, UCLogCallout).Job.JobNumber
        f.ShowDialog()

        Dim returnValue As Integer = Combo.GetSelectedItemValue(f.cboVisit)
        If returnValue > 0 Then
            If DB.EngineerVisits.MoveParts(EngineerVisit.EngineerVisitID, returnValue) Then
                ShowMessage("Parts have been moved, please refresh window!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ShowMessage("No parts have been moved!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtNotesToEngineer_TextChanged(sender As Object, e As EventArgs) Handles txtNotesToEngineer.TextChanged
        change = True
    End Sub

    Private Sub BtnPrintServiceLetter_Click(sender As Object, e As EventArgs) Handles BtnPrintServiceLetter.Click
        SendToPrint()
    End Sub

    Private Sub ProForrmaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProForrmaToolStripMenuItem.Click

        Dim details As New ArrayList
        Dim Job As Entity.Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID)

        details.Add("JOB")
        details.Add(Job)

        Dim f As New FRMInvoiceExtraDetail

        f.ShowDialog()

        details.Add(f.txtNotes.Text)
        details.Add(CDbl(f.txtCharge.Text))

        details.Add(DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(f.cbo)).VATRate)
        Dim oPrint As New Printing(details, "ProFormaFromVisit", Enums.SystemDocumentType.ProFormaFromVisit, True)

    End Sub

    Private Sub btnGenerateAuthCode_Click(sender As Object, e As EventArgs) Handles btnGenerateAuthCode.Click
        Dim authCode As Integer
        If (Me.EngineerVisit.EngineerVisitID > 0) Or (Me.EngineerVisit.EngineerID > 0) Then
            authCode = Math.Ceiling((Me.EngineerVisit.EngineerVisitID + Me.EngineerVisit.EngineerID) / Now().Hour)
        End If
        Me.lblAuthCode.Text = authCode
    End Sub

    Private Sub btnPrintJobLetter_Click(sender As Object, e As EventArgs) Handles btnPrintJobLetter.Click
        If Me.EngineerVisit IsNot Nothing And Me.EngineerVisit.EngineerVisitID > 0 Then
            Dim Job As Entity.Jobs.Job = OnControl.OnContol.Job
            Dim dvJobImportProcess As DataView = DB.JobImports.JobImport_Get_ByJobNumber(Job.JobNumber)
            If dvJobImportProcess.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor
                Dim details As New ArrayList
                details.Add(dvJobImportProcess.Table)
                Dim print As New Printing(details, dvJobImportProcess.Table.Rows(0)("Type"), Enums.SystemDocumentType.JobImportLetters, False, 0, True)
                Process.Start(print.EmailWP())
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            Dim Site As Entity.Sites.Site = OnControl.OnContol.Site
            If Site IsNot Nothing AndAlso Job.JobTypeID = Enums.JobTypes.Remedial Then
                Select Case Site.CustomerID
                    Case Enums.Customer.Suffolk, Enums.Customer.Flagship, Enums.Customer.Victory, Enums.Customer.NCC
                        Cursor.Current = Cursors.WaitCursor
                        Dim dt As DataTable = dvJobImportProcess.Table.Clone
                        Dim dr As DataRow = dt.NewRow()
                        dr("Name") = Site.Name
                        dr("Address1") = Site.Address1.Trim
                        dr("Address2") = Site.Address2.Trim
                        dr("Address3") = Site.Address3.Trim
                        dr("Postcode") = Site.Postcode.Trim
                        dr("TelNo") = Site.TelephoneNum.Trim
                        dr("JobImportID") = 0
                        dr("SiteID") = Site.SiteID
                        dr("UPRN") = Site.PolicyNumber.Trim
                        dr("JobImportTypeID") = 0
                        Select Case Site.CustomerID
                            Case Enums.Customer.Flagship
                                dr("Type") = "FHG-REMEDIAL"
                            Case Enums.Customer.Victory
                                dr("Type") = "VHT-REMEDIAL"
                            Case Enums.Customer.Suffolk
                                dr("Type") = "SHS-REMEDIAL"
                            Case Enums.Customer.NCC
                                dr("Type") = "NCC-REMEDIAL"
                        End Select
                        dr("Dateadded") = Now
                        dr("JobID") = Job.JobID
                        dr("JobNumber") = Job.JobNumber
                        dr("Status") = 0
                        Dim visitDate As DateTime = If(EngineerVisit.StartDateTime <> Nothing, EngineerVisit.StartDateTime, Job.DateCreated)
                        dr("BookedVisit") = visitDate
                        dr("Letter1") = visitDate
                        dr("Letter2") = visitDate
                        dr("Report") = 0
                        dr("Deleted") = 0
                        dt.Rows.Add(dr)

                        Dim details As New ArrayList
                        details.Add(dt)
                        details.Add(EngineerVisit)
                        Dim print As New Printing(details, dt.Rows(0)("Type"), Enums.SystemDocumentType.JobImportLetters, False, 0, True)

                        Process.Start(print.EmailWP())
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    Case Else

                End Select
            End If
        End If

    End Sub

    Private Sub btnUploadVisit_Click(sender As Object, e As EventArgs) Handles btnUploadVisit.Click
        If EngineerVisit IsNot Nothing Then
            EngineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Uploaded)
            EngineerVisit.SetOutcomeEnumID = CInt(Enums.EngineerVisitOutcomes.Visit_Not_Required)
            EngineerVisit.SetNotesFromEngineer = "Manually Uploaded by " & loggedInUser.Fullname
            DB.EngineerVisits.EngineerVisit_ManualUpload(EngineerVisit)
            Populate()
        End If
    End Sub

    Private Sub PrintSolarInstall_Click(sender As Object, e As EventArgs) Handles PrintSolarInstall.Click
        SendToPrint("\ServiceLetters\SolarAppointment.docx")
    End Sub

    Private Sub PrintElectricalAppointment_Click(sender As Object, e As EventArgs) Handles PrintElectricalAppointment.Click
        SendToPrint("\ServiceLetters\ElectricalTestingLetter.docx")
    End Sub

End Class