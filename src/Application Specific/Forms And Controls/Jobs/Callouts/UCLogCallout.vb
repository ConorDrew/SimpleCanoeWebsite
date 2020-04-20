Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys
Imports FSM.Entity.Users

Public Class UCLogCallout : Inherits UCBase : Implements IUserControl

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
    Friend WithEvents txtJobNumber As TextBox

    Friend WithEvents Label5 As Label
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSiteDetails As TextBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rdoQuoted As RadioButton
    Friend WithEvents rdoContract As RadioButton
    Friend WithEvents rdoMisc As RadioButton
    Friend WithEvents rdoCallout As RadioButton
    Friend WithEvents btnRemoveJobOfWork As Button
    Friend WithEvents btnAddJobOfWork As Button
    Friend WithEvents tcJobOfWorks As TabControl
    Friend WithEvents lblOnHold As Label
    Friend WithEvents cbxToBePartPaid As CheckBox
    Friend WithEvents txtRetention As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCurrentContract As TextBox
    Friend WithEvents chkPOC As CheckBox
    Friend WithEvents chkOTI As CheckBox
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents txtSiteName As TextBox
    Friend WithEvents chkFoc As CheckBox
    Friend WithEvents lblContractInactive As Label
    Friend WithEvents btnChange As Button
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents gbPaymentType As GroupBox
    Friend WithEvents btnfindVan As Button
    Friend WithEvents txtVanReg As TextBox
    Friend WithEvents btnFindUser As Button
    Friend WithEvents txtSalesRep As TextBox
    Friend WithEvents lblSalesRep As Label
    Friend WithEvents grpHeadline As GroupBox
    Friend WithEvents txtHeadline As TextBox
    Friend WithEvents lblLastContactAttempt As Label
    Friend WithEvents txtLastContact As TextBox
    Friend WithEvents btnAddContactAttempt As Button
    Friend WithEvents tt As ToolTip
    Friend WithEvents chkCollectPayment As CheckBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        Me.btnRemoveJobOfWork = New Button()
        Me.btnAddJobOfWork = New Button()
        Me.tcJobOfWorks = New TabControl()
        Me.rdoContract = New RadioButton()
        Me.rdoQuoted = New RadioButton()
        Me.txtJobNumber = New TextBox()
        Me.Label5 = New Label()
        Me.cboJobType = New ComboBox()
        Me.label4 = New Label()
        Me.rdoMisc = New RadioButton()
        Me.rdoCallout = New RadioButton()
        Me.Label3 = New Label()
        Me.txtSiteDetails = New TextBox()
        Me.txtCustomerName = New TextBox()
        Me.Label1 = New Label()
        Me.Label2 = New Label()
        Me.lblOnHold = New Label()
        Me.cbxToBePartPaid = New CheckBox()
        Me.txtRetention = New TextBox()
        Me.Label7 = New Label()
        Me.Label8 = New Label()
        Me.txtCurrentContract = New TextBox()
        Me.chkCollectPayment = New CheckBox()
        Me.chkPOC = New CheckBox()
        Me.chkOTI = New CheckBox()
        Me.lblCustomerName = New Label()
        Me.txtSiteName = New TextBox()
        Me.chkFoc = New CheckBox()
        Me.lblContractInactive = New Label()
        Me.btnChange = New Button()
        Me.txtContact = New TextBox()
        Me.Label10 = New Label()
        Me.gbPaymentType = New GroupBox()
        Me.btnfindVan = New Button()
        Me.txtVanReg = New TextBox()
        Me.btnFindUser = New Button()
        Me.txtSalesRep = New TextBox()
        Me.lblSalesRep = New Label()
        Me.grpHeadline = New GroupBox()
        Me.txtHeadline = New TextBox()
        Me.lblLastContactAttempt = New Label()
        Me.txtLastContact = New TextBox()
        Me.btnAddContactAttempt = New Button()
        Me.tt = New ToolTip(Me.components)
        Me.gbPaymentType.SuspendLayout()
        Me.grpHeadline.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRemoveJobOfWork
        '
        Me.btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work"
        Me.btnRemoveJobOfWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnRemoveJobOfWork.Location = New Point(1157, 213)
        Me.btnRemoveJobOfWork.Name = "btnRemoveJobOfWork"
        Me.btnRemoveJobOfWork.Size = New Size(24, 23)
        Me.btnRemoveJobOfWork.TabIndex = 16
        Me.btnRemoveJobOfWork.Text = "_"
        '
        'btnAddJobOfWork
        '
        Me.btnAddJobOfWork.AccessibleDescription = "Add Job Of Work"
        Me.btnAddJobOfWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnAddJobOfWork.Location = New Point(1127, 213)
        Me.btnAddJobOfWork.Name = "btnAddJobOfWork"
        Me.btnAddJobOfWork.Size = New Size(24, 23)
        Me.btnAddJobOfWork.TabIndex = 15
        Me.btnAddJobOfWork.Text = "+"
        '
        'tcJobOfWorks
        '
        Me.tcJobOfWorks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.tcJobOfWorks.Location = New Point(8, 232)
        Me.tcJobOfWorks.Name = "tcJobOfWorks"
        Me.tcJobOfWorks.SelectedIndex = 0
        Me.tcJobOfWorks.Size = New Size(1173, 401)
        Me.tcJobOfWorks.TabIndex = 17
        '
        'rdoContract
        '
        Me.rdoContract.Location = New Point(201, 135)
        Me.rdoContract.Name = "rdoContract"
        Me.rdoContract.Size = New Size(72, 24)
        Me.rdoContract.TabIndex = 10
        Me.rdoContract.Text = "Contract"
        Me.rdoContract.UseVisualStyleBackColor = True
        Me.rdoContract.Visible = False
        '
        'rdoQuoted
        '
        Me.rdoQuoted.Location = New Point(162, 123)
        Me.rdoQuoted.Name = "rdoQuoted"
        Me.rdoQuoted.Size = New Size(64, 24)
        Me.rdoQuoted.TabIndex = 9
        Me.rdoQuoted.Text = "Quoted"
        Me.rdoQuoted.UseVisualStyleBackColor = True
        Me.rdoQuoted.Visible = False
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New Point(545, 87)
        Me.txtJobNumber.MaxLength = 20
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.ReadOnly = True
        Me.txtJobNumber.Size = New Size(117, 21)
        Me.txtJobNumber.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Location = New Point(461, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(80, 18)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Job Number:"
        '
        'cboJobType
        '
        Me.cboJobType.Location = New Point(307, 185)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New Size(205, 21)
        Me.cboJobType.TabIndex = 14
        '
        'label4
        '
        Me.label4.Location = New Point(307, 161)
        Me.label4.Name = "label4"
        Me.label4.Size = New Size(65, 20)
        Me.label4.TabIndex = 22
        Me.label4.Text = "Job Type:"
        '
        'rdoMisc
        '
        Me.rdoMisc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoMisc.Location = New Point(242, 58)
        Me.rdoMisc.Name = "rdoMisc"
        Me.rdoMisc.Size = New Size(56, 24)
        Me.rdoMisc.TabIndex = 9
        Me.rdoMisc.Text = "Misc."
        Me.rdoMisc.UseVisualStyleBackColor = True
        Me.rdoMisc.Visible = False
        '
        'rdoCallout
        '
        Me.rdoCallout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoCallout.Location = New Point(98, 124)
        Me.rdoCallout.Name = "rdoCallout"
        Me.rdoCallout.Size = New Size(72, 24)
        Me.rdoCallout.TabIndex = 8
        Me.rdoCallout.Text = "Callout"
        Me.rdoCallout.UseVisualStyleBackColor = True
        Me.rdoCallout.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New Point(20, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(72, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Definition:"
        Me.Label3.Visible = False
        '
        'txtSiteDetails
        '
        Me.txtSiteDetails.Location = New Point(93, 58)
        Me.txtSiteDetails.Name = "txtSiteDetails"
        Me.txtSiteDetails.ReadOnly = True
        Me.txtSiteDetails.Size = New Size(569, 21)
        Me.txtSiteDetails.TabIndex = 3
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New Point(93, 0)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New Size(569, 21)
        Me.txtCustomerName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New Point(6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(80, 23)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Customer:"
        '
        'Label2
        '
        Me.Label2.Location = New Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(80, 23)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Property:"
        '
        'lblOnHold
        '
        Me.lblOnHold.Font = New Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnHold.ForeColor = System.Drawing.Color.Red
        Me.lblOnHold.Location = New Point(89, 212)
        Me.lblOnHold.Name = "lblOnHold"
        Me.lblOnHold.Size = New Size(290, 24)
        Me.lblOnHold.TabIndex = 14
        Me.lblOnHold.Text = "Customer Status: On Hold"
        '
        'cbxToBePartPaid
        '
        Me.cbxToBePartPaid.Location = New Point(181, 53)
        Me.cbxToBePartPaid.Name = "cbxToBePartPaid"
        Me.cbxToBePartPaid.Size = New Size(240, 32)
        Me.cbxToBePartPaid.TabIndex = 12
        Me.cbxToBePartPaid.Text = "Job to be paid in parts (One Invoice, many payment applications)"
        Me.cbxToBePartPaid.Visible = False
        '
        'txtRetention
        '
        Me.txtRetention.Location = New Point(427, 58)
        Me.txtRetention.MaxLength = 20
        Me.txtRetention.Name = "txtRetention"
        Me.txtRetention.Size = New Size(96, 21)
        Me.txtRetention.TabIndex = 11
        Me.txtRetention.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New Point(424, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(88, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Retention %:"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New Point(7, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(72, 23)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Contract:"
        '
        'txtCurrentContract
        '
        Me.txtCurrentContract.Location = New Point(92, 124)
        Me.txtCurrentContract.Multiline = True
        Me.txtCurrentContract.Name = "txtCurrentContract"
        Me.txtCurrentContract.ReadOnly = True
        Me.txtCurrentContract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCurrentContract.Size = New Size(203, 78)
        Me.txtCurrentContract.TabIndex = 5
        '
        'chkCollectPayment
        '
        Me.chkCollectPayment.Location = New Point(11, 123)
        Me.chkCollectPayment.Name = "chkCollectPayment"
        Me.chkCollectPayment.Size = New Size(120, 24)
        Me.chkCollectPayment.TabIndex = 6
        Me.chkCollectPayment.Text = "Collect Payment"
        Me.chkCollectPayment.Visible = False
        '
        'chkPOC
        '
        Me.chkPOC.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPOC.Location = New Point(81, 21)
        Me.chkPOC.Name = "chkPOC"
        Me.chkPOC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPOC.Size = New Size(55, 19)
        Me.chkPOC.TabIndex = 12
        Me.chkPOC.Text = "POC"
        '
        'chkOTI
        '
        Me.chkOTI.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOTI.Location = New Point(143, 20)
        Me.chkOTI.Name = "chkOTI"
        Me.chkOTI.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkOTI.Size = New Size(56, 20)
        Me.chkOTI.TabIndex = 13
        Me.chkOTI.Text = "OTI"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.Location = New Point(6, 27)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New Size(80, 23)
        Me.lblCustomerName.TabIndex = 29
        Me.lblCustomerName.Text = "Name:"
        '
        'txtSiteName
        '
        Me.txtSiteName.Location = New Point(94, 29)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.ReadOnly = True
        Me.txtSiteName.Size = New Size(568, 21)
        Me.txtSiteName.TabIndex = 2
        '
        'chkFoc
        '
        Me.chkFoc.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFoc.Location = New Point(13, 20)
        Me.chkFoc.Name = "chkFoc"
        Me.chkFoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkFoc.Size = New Size(56, 20)
        Me.chkFoc.TabIndex = 11
        Me.chkFoc.Text = "FOC"
        '
        'lblContractInactive
        '
        Me.lblContractInactive.BackColor = System.Drawing.Color.Red
        Me.lblContractInactive.Location = New Point(89, 117)
        Me.lblContractInactive.Name = "lblContractInactive"
        Me.lblContractInactive.Size = New Size(212, 90)
        Me.lblContractInactive.TabIndex = 30
        Me.lblContractInactive.Visible = False
        '
        'btnChange
        '
        Me.btnChange.Location = New Point(518, 184)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New Size(82, 22)
        Me.btnChange.TabIndex = 31
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'txtContact
        '
        Me.txtContact.Location = New Point(92, 87)
        Me.txtContact.MaxLength = 20
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New Size(363, 21)
        Me.txtContact.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.Location = New Point(6, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New Size(84, 23)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Contact Info:"
        '
        'gbPaymentType
        '
        Me.gbPaymentType.Controls.Add(Me.chkOTI)
        Me.gbPaymentType.Controls.Add(Me.chkPOC)
        Me.gbPaymentType.Controls.Add(Me.chkFoc)
        Me.gbPaymentType.Location = New Point(307, 114)
        Me.gbPaymentType.Name = "gbPaymentType"
        Me.gbPaymentType.Size = New Size(205, 44)
        Me.gbPaymentType.TabIndex = 36
        Me.gbPaymentType.TabStop = False
        Me.gbPaymentType.Text = "Payment Type"
        '
        'btnfindVan
        '
        Me.btnfindVan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnfindVan.BackColor = System.Drawing.Color.White
        Me.btnfindVan.Enabled = False
        Me.btnfindVan.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindVan.Location = New Point(1149, 179)
        Me.btnfindVan.Name = "btnfindVan"
        Me.btnfindVan.Size = New Size(32, 23)
        Me.btnfindVan.TabIndex = 37
        Me.btnfindVan.Text = "..."
        Me.btnfindVan.UseVisualStyleBackColor = False
        Me.btnfindVan.Visible = False
        '
        'txtVanReg
        '
        Me.txtVanReg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.txtVanReg.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVanReg.Location = New Point(895, 179)
        Me.txtVanReg.Name = "txtVanReg"
        Me.txtVanReg.ReadOnly = True
        Me.txtVanReg.Size = New Size(247, 21)
        Me.txtVanReg.TabIndex = 36
        Me.txtVanReg.Visible = False
        '
        'btnFindUser
        '
        Me.btnFindUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnFindUser.BackColor = System.Drawing.Color.White
        Me.btnFindUser.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindUser.Location = New Point(1149, 150)
        Me.btnFindUser.Name = "btnFindUser"
        Me.btnFindUser.Size = New Size(32, 23)
        Me.btnFindUser.TabIndex = 39
        Me.btnFindUser.Text = "..."
        Me.btnFindUser.UseVisualStyleBackColor = False
        '
        'txtSalesRep
        '
        Me.txtSalesRep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.txtSalesRep.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesRep.Location = New Point(895, 152)
        Me.txtSalesRep.Name = "txtSalesRep"
        Me.txtSalesRep.ReadOnly = True
        Me.txtSalesRep.Size = New Size(248, 21)
        Me.txtSalesRep.TabIndex = 38
        '
        'lblSalesRep
        '
        Me.lblSalesRep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.lblSalesRep.Location = New Point(813, 155)
        Me.lblSalesRep.Name = "lblSalesRep"
        Me.lblSalesRep.Size = New Size(76, 18)
        Me.lblSalesRep.TabIndex = 40
        Me.lblSalesRep.Text = "Sales Rep:"
        '
        'grpHeadline
        '
        Me.grpHeadline.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.grpHeadline.Controls.Add(Me.txtHeadline)
        Me.grpHeadline.Location = New Point(709, 0)
        Me.grpHeadline.Name = "grpHeadline"
        Me.grpHeadline.Size = New Size(472, 52)
        Me.grpHeadline.TabIndex = 43
        Me.grpHeadline.TabStop = False
        Me.grpHeadline.Text = "Job Headline"
        '
        'txtHeadline
        '
        Me.txtHeadline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHeadline.Location = New Point(3, 17)
        Me.txtHeadline.Multiline = True
        Me.txtHeadline.Name = "txtHeadline"
        Me.txtHeadline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHeadline.Size = New Size(466, 32)
        Me.txtHeadline.TabIndex = 43
        '
        'lblLastContactAttempt
        '
        Me.lblLastContactAttempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.lblLastContactAttempt.Location = New Point(683, 60)
        Me.lblLastContactAttempt.Name = "lblLastContactAttempt"
        Me.lblLastContactAttempt.Size = New Size(84, 18)
        Me.lblLastContactAttempt.TabIndex = 44
        Me.lblLastContactAttempt.Text = "Last Contact:"
        '
        'txtLastContact
        '
        Me.txtLastContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.txtLastContact.Location = New Point(773, 60)
        Me.txtLastContact.Multiline = True
        Me.txtLastContact.Name = "txtLastContact"
        Me.txtLastContact.ReadOnly = True
        Me.txtLastContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLastContact.Size = New Size(408, 77)
        Me.txtLastContact.TabIndex = 45
        '
        'btnAddContactAttempt
        '
        Me.btnAddContactAttempt.AccessibleDescription = ""
        Me.btnAddContactAttempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnAddContactAttempt.Location = New Point(743, 112)
        Me.btnAddContactAttempt.Name = "btnAddContactAttempt"
        Me.btnAddContactAttempt.Size = New Size(24, 23)
        Me.btnAddContactAttempt.TabIndex = 46
        Me.btnAddContactAttempt.Text = "+"
        Me.tt.SetToolTip(Me.btnAddContactAttempt, "Add new contact attempt")
        '
        'UCLogCallout
        '
        Me.Controls.Add(Me.btnAddContactAttempt)
        Me.Controls.Add(Me.txtLastContact)
        Me.Controls.Add(Me.lblLastContactAttempt)
        Me.Controls.Add(Me.grpHeadline)
        Me.Controls.Add(Me.gbPaymentType)
        Me.Controls.Add(Me.lblSalesRep)
        Me.Controls.Add(Me.btnFindUser)
        Me.Controls.Add(Me.txtSalesRep)
        Me.Controls.Add(Me.btnfindVan)
        Me.Controls.Add(Me.txtVanReg)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCurrentContract)
        Me.Controls.Add(Me.lblContractInactive)
        Me.Controls.Add(Me.txtJobNumber)
        Me.Controls.Add(Me.cboJobType)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.txtSiteName)
        Me.Controls.Add(Me.lblCustomerName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rdoCallout)
        Me.Controls.Add(Me.txtSiteDetails)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRemoveJobOfWork)
        Me.Controls.Add(Me.btnAddJobOfWork)
        Me.Controls.Add(Me.tcJobOfWorks)
        Me.Controls.Add(Me.lblOnHold)
        Me.Controls.Add(Me.rdoQuoted)
        Me.Controls.Add(Me.chkCollectPayment)
        Me.Controls.Add(Me.txtRetention)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rdoContract)
        Me.Controls.Add(Me.cbxToBePartPaid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rdoMisc)
        Me.Controls.Add(Me.label4)
        Me.Name = "UCLogCallout"
        Me.Size = New Size(1188, 620)
        Me.gbPaymentType.ResumeLayout(False)
        Me.grpHeadline.ResumeLayout(False)
        Me.grpHeadline.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As EventArgs) Implements IUserControl.LoadForm

        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return Job
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private IsNewJobOfWork As Boolean = False

    Private _onForm As FRMLogCallout = Nothing

    Public Property OnForm() As FRMLogCallout
        Get
            Return _onForm
        End Get
        Set(ByVal Value As FRMLogCallout)
            _onForm = Value
        End Set
    End Property

    Private _jobId As Integer

    Public Property JobId() As Integer
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer)
            _jobId = value
        End Set
    End Property

    Private _siteId As Integer

    Public Property SiteId() As Integer
        Get
            Return _siteId
        End Get
        Set(ByVal value As Integer)
            _siteId = value
        End Set
    End Property

    Private _job As Entity.Jobs.Job

    Public Property Job() As Entity.Jobs.Job
        Get
            Return _job
        End Get
        Set(ByVal value As Entity.Jobs.Job)
            _job = value
            If _job Is Nothing Then
                _job = New Entity.Jobs.Job
            End If
        End Set
    End Property

    Private _site As Entity.Sites.Site

    Public Property Site() As Entity.Sites.Site
        Get
            Return _site
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _site = value
            If _site Is Nothing Then
                _site = New Entity.Sites.Site
            End If
        End Set
    End Property

    Private _customer As Entity.Customers.Customer

    Public Property Customer() As Entity.Customers.Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Entity.Customers.Customer)
            _customer = value
        End Set
    End Property

    Private _jobNumber As New JobNumber

    Public Property JobNumber() As JobNumber
        Get
            Return _jobNumber
        End Get
        Set(ByVal Value As JobNumber)
            _jobNumber = Value
        End Set
    End Property

    Private _salesRep As User

    Public Property SalesRep() As User
        Get
            Return _salesRep
        End Get
        Set(ByVal Value As User)
            _salesRep = Value

            If _salesRep Is Nothing Then
                _salesRep = New User
                _salesRep.Exists = False
                Me.txtSalesRep.Text = "N/A"
            Else
                Me.txtSalesRep.Text = _salesRep.Fullname
            End If
        End Set
    End Property

    Private _fleet As Entity.FleetVans.FleetVan

    Public Property Fleet() As Entity.FleetVans.FleetVan
        Get
            Return _fleet
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVan)
            _fleet = Value

            If _fleet Is Nothing Then
                _fleet = New Entity.FleetVans.FleetVan
                _fleet.Exists = False
            Else
                Me.txtVanReg.Text = _fleet.Registration
            End If
        End Set
    End Property

    Private _jobOfWorks As List(Of Entity.JobOfWorks.JobOfWork)

    Public Property JobOfWorks() As List(Of Entity.JobOfWorks.JobOfWork)
        Get
            Return _jobOfWorks
        End Get
        Set(ByVal value As List(Of Entity.JobOfWorks.JobOfWork))
            _jobOfWorks = value
            If _jobOfWorks Is Nothing Then
                _jobOfWorks = New List(Of Entity.JobOfWorks.JobOfWork)
            End If
        End Set
    End Property

    Private _engineerVisits As List(Of Entity.EngineerVisits.EngineerVisit)

    Public Property EngineerVisits() As List(Of Entity.EngineerVisits.EngineerVisit)
        Get
            Return _engineerVisits
        End Get
        Set(ByVal value As List(Of Entity.EngineerVisits.EngineerVisit))
            _engineerVisits = value
            If _engineerVisits Is Nothing Then
                _engineerVisits = New List(Of Entity.EngineerVisits.EngineerVisit)
            End If
        End Set
    End Property

    Private _contactAttempts As List(Of Entity.ContactAttempts.ContactAttempt)

    Public Property ContactAttempts() As List(Of Entity.ContactAttempts.ContactAttempt)
        Get
            Return _contactAttempts
        End Get
        Set(ByVal value As List(Of Entity.ContactAttempts.ContactAttempt))
            _contactAttempts = value
            If _contactAttempts Is Nothing Then
                _contactAttempts = New List(Of Entity.ContactAttempts.ContactAttempt)
            End If
        End Set
    End Property

    Private _dvAssests As DataView

    Public Property DvAssets() As DataView
        Get
            Return _dvAssests
        End Get
        Set(ByVal value As DataView)
            _dvAssests = value
        End Set
    End Property

    Private _dvEngineerVisitsPartsAllocated As DataView

    Public Property DvEngineerVisitsPartsAllocated() As DataView
        Get
            Return _dvEngineerVisitsPartsAllocated
        End Get
        Set(ByVal value As DataView)
            _dvEngineerVisitsPartsAllocated = value
        End Set
    End Property

    Private _dvSiteAssests As DataView

    Public Property DvSiteAssets() As DataView
        Get
            Return _dvSiteAssests
        End Get
        Set(ByVal value As DataView)
            _dvSiteAssests = value
        End Set
    End Property

    Private _dvJobItems As DataView

    Public Property DvJobItems() As DataView
        Get
            Return _dvJobItems
        End Get
        Set(ByVal value As DataView)
            _dvJobItems = value
        End Set
    End Property

    Private _dvEngineers As DataView

    Public Property DvEngineers() As DataView

        Get
            Return _dvEngineers
        End Get
        Set(ByVal value As DataView
)
            _dvEngineers = value
        End Set
    End Property

    Private _dvCustomerPriorities As DataView

    Public Property DvCustomerPriorities() As DataView

        Get
            Return _dvCustomerPriorities
        End Get
        Set(ByVal value As DataView)
            _dvCustomerPriorities = value
        End Set
    End Property

    Private _dvEngineerLevels As DataView

    Public Property DvEngineerLevels() As DataView

        Get
            Return _dvEngineerLevels
        End Get
        Set(ByVal value As DataView)
            _dvEngineerLevels = value
        End Set
    End Property

    Private _EngineerVisitsRemoved As New ArrayList

    Public Property EngineerVisitsRemoved() As ArrayList
        Get
            Return _EngineerVisitsRemoved
        End Get
        Set(ByVal Value As ArrayList)
            _EngineerVisitsRemoved = Value
        End Set
    End Property

    Private _JobOfWorksRemoved As New ArrayList

    Public Property JobOfWorksRemoved() As ArrayList
        Get
            Return _JobOfWorksRemoved
        End Get
        Set(ByVal Value As ArrayList)
            _JobOfWorksRemoved = Value
        End Set
    End Property

    Private _EngineerVisitsOrdersRemoved As New ArrayList

    Public Property EngineerVisitsOrdersRemoved() As ArrayList
        Get
            Return _EngineerVisitsOrdersRemoved
        End Get
        Set(ByVal Value As ArrayList)
            _EngineerVisitsOrdersRemoved = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCLogCallout_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub rdoCallout_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rdoCallout.CheckedChanged
        If Job.JobID = 0 Then Job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)
        PaymentTypeChanged()
    End Sub

    Private Sub rdoMisc_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rdoMisc.CheckedChanged
        If Job.JobID = 0 Then Job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Misc)
        PaymentTypeChanged()
    End Sub

    Private Sub rdoContract_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoContract.CheckedChanged
        If Job.JobID = 0 Then Job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Contract)
        PaymentTypeChanged()
    End Sub

    Private Sub rdoQuoted_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoQuoted.CheckedChanged
        If Job.JobID = 0 Then Job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Quoted)
        PaymentTypeChanged()
    End Sub

    Private Sub btnAddJobOfWork_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddJobOfWork.Click
        Dim tp As TabPage = AddJobOfWork(Nothing)
        IsNewJobOfWork = True
    End Sub

    Private Sub btnRemoveJobOfWork_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveJobOfWork.Click
        RemoveJobOfWork()
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnChange.Click
        If EnterOverridePassword() = True Then
            Dim f As New FRMChangeJobType
            f.ShowDialog()
            Combo.SetSelectedComboItem_By_Value(cboJobType, Combo.GetSelectedItemValue(f.cboJobType))
            Save()
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        Try
            Me.Cursor = Cursors.WaitCursor
            PopulateProperties()
            PopulateSite()
            If Not IsRFT Then PopulateContract()
            PopulateJobOfWorks()
            PopulateJob()
            PopulateContactAttempts()
        Catch ex As Exception
            ShowMessage("Data cannot load : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PopulateProperties()
        Me.tcJobOfWorks.TabPages.Clear()
        Site = DB.Sites.Get(JobId, Entity.Sites.SiteSQL.GetBy.JobId)
        If Site.SiteID = 0 Then Site = DB.Sites.Get(SiteId, Entity.Sites.SiteSQL.GetBy.SiteId)
        Customer = DB.Customer.Customer_Get(Site.CustomerID)

        DvSiteAssets = DB.Asset.Asset_GetForSite(Site.SiteID)
        DvEngineerVisitsPartsAllocated = DB.EngineerVisitPartProductAllocated.Get_ByJobId(JobId)
        DvJobItems = DB.JobItems.JobItems_Get_For_Job(JobId)
        DvEngineers = DB.Engineer.Engineer_GetAll()
        DvAssets = DB.JobAsset.JobAsset_Get_For_Job(JobId)
        DvCustomerPriorities = DB.Customer.CustomerPriority_Get(Site.CustomerID)
        DvEngineerLevels = DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels)

        Job = DB.Job.Get(JobId)
        SalesRep = DB.User.Get(Job.SalesRepUserID)
        JobOfWorks = DB.JobOfWorks.Get_ByJobId(JobId)
        EngineerVisits = DB.EngineerVisits.Get_ByJobId(JobId)
    End Sub

    Private Sub PopulateJob()

        If Job.JobID = 0 Then Job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)

        Select Case CType(Job.JobDefinitionEnumID, Enums.JobDefinition)
            Case Enums.JobDefinition.Callout
                Me.rdoCallout.Checked = True
                Me.rdoMisc.Checked = False
                Me.rdoContract.Checked = False
                Me.rdoQuoted.Checked = False
            Case Enums.JobDefinition.Misc
                Me.rdoCallout.Checked = False
                Me.rdoMisc.Checked = True
                Me.rdoContract.Checked = False
                Me.rdoQuoted.Checked = False
            Case Enums.JobDefinition.Contract
                Me.rdoCallout.Checked = False
                Me.rdoMisc.Checked = False
                Me.rdoContract.Checked = True
                Me.rdoQuoted.Checked = False
            Case Enums.JobDefinition.Quoted
                Me.rdoCallout.Checked = False
                Me.rdoMisc.Checked = False
                Me.rdoContract.Checked = False
                Me.rdoQuoted.Checked = True
        End Select

        Combo.SetSelectedComboItem_By_Value(Me.cboJobType, Job.JobTypeID)
        Me.txtJobNumber.Text = Job.JobNumber
        Me.cbxToBePartPaid.Checked = Job.ToBePartPaid
        Me.txtRetention.Text = Job.Retention
        Me.chkCollectPayment.Checked = Job.CollectPayment
        Me.chkPOC.Checked = Job.POC
        Me.chkOTI.Checked = Job.OTI
        Me.chkFoc.Checked = Job.FOC
        Me.txtHeadline.Text = Job.Headline
        Me.btnAddContactAttempt.Enabled = Job.JobID > 0

        If Me.tcJobOfWorks.TabPages.Count > 0 Then Me.tcJobOfWorks.SelectedTab = Me.tcJobOfWorks.TabPages(0)

        Me.rdoCallout.Enabled = False
        Me.rdoMisc.Enabled = False
        Me.rdoContract.Enabled = False
        Me.rdoQuoted.Enabled = False
        Me.cbxToBePartPaid.Enabled = False
        Me.txtRetention.Enabled = False
        Me.chkCollectPayment.Enabled = False

        If Job.StatusEnumID >= Enums.JobStatus.Complete Then
            Me.btnAddJobOfWork.Enabled = False
            Me.btnRemoveJobOfWork.Enabled = False
            OnForm.btnSave.Enabled = False
            OnForm.btnAddAppliance.Visible = False
        End If

        If Job.JobCreationType = Enums.JobCreationType.JobManager And Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) Then
            btnAddJobOfWork.Visible = False
            btnRemoveJobOfWork.Visible = False

            For Each page As TabPage In Me.tcJobOfWorks.TabPages
                CType(page.Controls(0), UCCalloutBreakdown).btnAddEngineerVisit.Visible = False
                CType(page.Controls(0), UCCalloutBreakdown).btnRemoveEngineerVisit.Visible = False
            Next
        End If

        If Job.JobCreationType = Enums.JobCreationType.LetterManager Then
            Dim JOWbuttonEnabled As Boolean = True

            For Each jobOfWork As Entity.JobOfWorks.JobOfWork In JobOfWorks
                If jobOfWork.Status = Enums.JobOfWorkStatus.Open Then
                    JOWbuttonEnabled = False
                End If
            Next

            btnAddJobOfWork.Visible = JOWbuttonEnabled
            btnRemoveJobOfWork.Visible = JOWbuttonEnabled
            For Each page As TabPage In Me.tcJobOfWorks.TabPages
                CType(page.Controls(0), UCCalloutBreakdown).btnAddEngineerVisit.Visible = False
                CType(page.Controls(0), UCCalloutBreakdown).btnRemoveEngineerVisit.Visible = False
            Next
        End If

        If Customer.CustomerID = Enums.Customer.Vehicle Then
            Me.cboJobType.Enabled = True
            Me.btnChange.Visible = False

            Combo.SetUpCombo(Me.cboJobType, DB.Fleet.FleetJobType_GetAll().Table, "JobTypeID", "Name", Enums.ComboValues.Please_Select)
            Dim vanId As Integer = 0
            If Job.JobTypeID = Enums.FleetJobTypes.VanFault Then
                Dim oVanFault As Entity.FleetVans.FleetVanFault = DB.FleetVanFault.Get_ByJobID(Job.JobID)
                If oVanFault IsNot Nothing Then
                    vanId = oVanFault.VanID
                End If
            End If
            If Job.JobTypeID = Enums.FleetJobTypes.VanMaintenance Then
                vanId = DB.FleetVanService.GetVanId_ByJobId(Job.JobID)
                btnfindVan.Enabled = True
            End If

            If vanId > 0 Then
                Fleet = DB.FleetVan.Get(vanId)
                Me.txtVanReg.Text = Fleet.Registration
            End If

            Me.txtVanReg.Visible = True
            Me.btnfindVan.Visible = True
        Else
            Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
            Me.txtVanReg.Visible = False
            Me.btnfindVan.Visible = False
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboJobType, Job.JobTypeID)

        If DvAssets IsNot Nothing Then
            For Each row As DataRow In OnForm.AssetsDataView.Table.Rows
                For Each dr As DataRow In DvAssets.Table.Rows
                    If CInt(row.Item("AssetID")) = dr("AssetID") Then
                        row.Item("Tick") = True
                        Exit For
                    End If
                Next
            Next
        End If

        If IsRFT Then
            gbPaymentType.Visible = False
            chkOTI.Checked = True
        End If

        If OnForm?.JobLock?.UserID <> loggedInUser.UserID Then
            OnForm.MakeReadOnly()
        End If

        If Job.JobID = 0 Then
            If Not Helper.IsStringEmpty(Site.ContactAlerts) Then CType(CType(tcJobOfWorks?.TabPages(0).Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages(0).Controls(0), UCVisitBreakdown).txtNotesToEngineer.Text = Site.ContactAlerts & " - "
        End If

    End Sub

    Private Sub PopulateSite()

        Me.txtCustomerName.Text = Customer.Name
        Me.txtSiteDetails.Text = Site.Address1 & " " & Site.Address2 & ", " & Site.Postcode
        Me.txtSiteName.Text = Site.Name
        Me.txtContact.Text = "Tel: " & Site.TelephoneNum & " Mob: " & Site.FaxNum

        Dim currentSiteHQ As Entity.Sites.Site
        currentSiteHQ = DB.Sites.Get(Customer.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)
        If currentSiteHQ IsNot Nothing Then
            With currentSiteHQ
                Me.txtCustomerName.Text += " - " & .Address1 & ", " & .Address2 & " (Tel: " & .TelephoneNum & ")"
            End With
        End If

        If CType(Customer.Status, Enums.CustomerStatus) = Enums.CustomerStatus.OnHold Then
            Me.lblOnHold.Visible = True
        Else
            Me.lblOnHold.Visible = False
        End If

        If OnForm.AssetsDataView Is Nothing Then
            OnForm.AssetsDataView = DvSiteAssets
        End If

    End Sub

    Private Sub PopulateJobOfWorks()
        If JobOfWorks.Count > 0 Then
            JobOfWorks.ForEach(Function(x) AddJobOfWork(x))
        Else
            AddJobOfWork(Nothing)
        End If
    End Sub

    Public Sub PopulateContract()
        Dim currentContract As Entity.ContractsOriginal.ContractOriginal = DB.ContractOriginal.Get_Current_ForSite(Site.SiteID)
        If currentContract Is Nothing Then
            txtCurrentContract.Text = "Not on contract"
            lblContractInactive.Visible = False
        Else
            txtCurrentContract.Text = currentContract.ContractType & vbCrLf & CType(currentContract.ContractStatusID, Enums.ContractStatus).ToString() & vbCrLf & "Expires " & Format(currentContract.ContractEndDate, "dd/MM/yyyy")
            If currentContract.ContractStatusID = CInt(Enums.ContractStatus.Inactive) Then
                lblContractInactive.Visible = True
            Else
                lblContractInactive.Visible = False
            End If
        End If
    End Sub

    Private Sub PopulateContactAttempts()
        ContactAttempts = DB.ContactAttempts.GetAll_ForJob(JobId)
        If ContactAttempts?.Count > 0 Then
            Dim contactAttempt As Entity.ContactAttempts.ContactAttempt = ContactAttempts.OrderByDescending(Function(ca) ca.ContactMade).FirstOrDefault()
            If contactAttempt IsNot Nothing Then
                txtLastContact.Text = contactAttempt.ContactMade.ToString("dddd, dd MMMM yyyy HH:mm") & ": " & contactAttempt.ContactMethod
                If contactAttempt.Notes.Trim.Length > 0 Then
                    txtLastContact.Text += " - " & contactAttempt.Notes
                End If

                If contactAttempt.ContactMadeBy.Trim.Length > 0 Then
                    txtLastContact.Text += " by " & contactAttempt.ContactMadeBy
                End If
            End If
        End If
    End Sub

    Public Sub PaymentTypeChanged()
        If Job.JobID = 0 Then
            DB.Job.DeleteReservedOrderNumber(Me.JobNumber.JobNumber, Me.JobNumber.Prefix)
            JobNumber = DB.Job.GetNextJobNumber(Job.JobDefinitionEnumID)
            Job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
            Me.txtJobNumber.Text = Job.JobNumber
        End If
    End Sub

    Private Function AddJobOfWork(ByVal jobOfWork As Entity.JobOfWorks.JobOfWork) As TabPage
        Dim tp As New TabPage
        tp.BackColor = Color.White

        Dim ctrl As New UCCalloutBreakdown
        ctrl.OnContol = Me

        If jobOfWork Is Nothing Then
            For Each a As DataRow In DvSiteAssets.Table.Rows
                If Helper.MakeDateTimeValid(a("WarrantyStartDate")) < Now And Helper.MakeDateTimeValid(a("WarrantyEndDate")) > Now Then
                    ShowMessage("One or more assets are under warranty.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit For
                End If
            Next
        End If

        ctrl.JobOfWork = jobOfWork
        ctrl.Populate()
        ctrl.Dock = DockStyle.Fill
        tp.Controls.Add(ctrl)
        Me.tcJobOfWorks.TabPages.Add(tp)
        CheckTabs()

        Me.tcJobOfWorks.SelectedTab = tp

        Return tp
    End Function

    Private Sub RemoveJobOfWork()
        If CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).JobItemsAddedDataView.Table.Rows.Count > 0 Then
            If ShowMessage("Items of work has been added to this visit, are you sure you want to remove it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        For Each tp As TabPage In CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
            If CType(tp.Controls(0), UCVisitBreakdown).EngineerVisit.StatusEnumID >= CInt(Enums.VisitStatus.Scheduled) Then
                ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf CType(tp.Controls(0), UCVisitBreakdown).EngineerVisit.StatusEnumID = CInt(Enums.VisitStatus.Parts_Need_Ordering) Then
                ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim ordered As Boolean = False

                For Each tpev As TabPage In CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
                    If CType(tpev.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID > 0 Then
                        Dim engOrders As DataView = DB.Order.Orders_GetForEngineerVisit(CType(tpev.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID)
                        If engOrders.Table.Rows.Count > 0 Then
                            For Each dr As DataRow In engOrders.Table.Rows
                                ' WHAT STATUS ARE THEY?
                                If CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.AwaitingConfirmation Or
                                    CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.Cancelled Then
                                    'IF ARE AWAITING - ADD TO LIST TO REMOVE
                                    'ALL OK
                                Else
                                    ordered = True
                                End If
                                ' ordered = True
                            Next
                        End If
                    End If
                Next

                If ordered Then
                    ShowMessage("This job of work has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Next

        For Each tp As TabPage In CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
            If CType(tp.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID > 0 Then
                For Each tpev As TabPage In CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
                    If CType(tpev.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID > 0 Then
                        Dim engOrders As DataView = DB.Order.Orders_GetForEngineerVisit(CType(tpev.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID)
                        If engOrders.Table.Rows.Count > 0 Then
                            For Each dr As DataRow In engOrders.Table.Rows
                                'WHAT STATUS ARE THEY?
                                If CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.AwaitingConfirmation Or
                                    CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.Cancelled Then
                                    'IF ARE AWAITING - ADD TO LIST TO REMOVE
                                    EngineerVisitsOrdersRemoved.Add(dr("OrderID"))
                                End If
                            Next
                        End If
                    End If
                Next

                EngineerVisitsRemoved.Add(CType(tp.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID)
            End If
        Next
        If CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).JobOfWork.JobOfWorkID > 0 Then
            JobOfWorksRemoved.Add(CType(Me.tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).JobOfWork.JobOfWorkID)
        End If

        Me.tcJobOfWorks.TabPages.Remove(Me.tcJobOfWorks.SelectedTab)

        CheckTabs()
    End Sub

    Private Sub CheckTabs()
        If Me.tcJobOfWorks.TabPages.Count = 1 Then
            Me.btnRemoveJobOfWork.Enabled = False
        Else
            Me.btnRemoveJobOfWork.Enabled = True
        End If

        Dim i As Integer = 1
        For Each tab As TabPage In Me.tcJobOfWorks.TabPages
            tab.Text = "Job Of Work #" & i
            i += 1
        Next
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save

        Dim LastVisitStatus As Integer = 0
        Dim CureentJOWCount As Integer = 0
        Dim NewJOWCount As Integer = 0
        Dim JOW3Priority As String = Nothing

        For Each visitID As Integer In EngineerVisitsRemoved

            Dim newVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(visitID)

            If newVisit.StatusEnumID >= CInt(Enums.VisitStatus.Scheduled) Then
                ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.  Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OnForm.CloseForm()
            ElseIf newVisit.StatusEnumID = CInt(Enums.VisitStatus.Parts_Need_Ordering) Then
                ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering' so job of work cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OnForm.CloseForm()
            Else
                Dim ordered As Boolean = False

                If newVisit.Exists Then
                    Dim engOrders As DataView = DB.Order.Orders_GetForEngineerVisit(newVisit.EngineerVisitID)
                    If engOrders.Table.Rows.Count > 0 Then
                        For Each dr As DataRow In engOrders.Table.Rows
                            'WHAT STATUS ARE THEY?
                            If CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.AwaitingConfirmation Or
                                CType(dr("OrderStatusID"), Enums.OrderStatus) = Enums.OrderStatus.Cancelled Then
                                'IF ARE AWAITING - ADD TO LIST TO REMOVE
                                'ALL OK
                            Else
                                ordered = True
                            End If
                        Next
                    End If
                End If

                If ordered Then
                    ShowMessage("This job of work has orders that are being processed and therefore cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    OnForm.CloseForm()
                    Exit Function
                End If
            End If
        Next

        Dim trans As SqlClient.SqlTransaction = Nothing
        Dim con As SqlClient.SqlConnection = Nothing

        Try

            con = New SqlClient.SqlConnection(DB.ServerConnectionString)
            con.Open()
            trans = con.BeginTransaction(IsolationLevel.ReadUncommitted)

            Dim PONumberEntered As Boolean = True

            For Each page As TabPage In Me.tcJobOfWorks.TabPages
                If CType(page.Controls(0), UCCalloutBreakdown).txtPONumber.Text.Length = 0 Then
                    PONumberEntered = False
                End If
            Next

            If PONumberEntered = False And Site.PoNumReqd = True Then
                If ShowMessage("A Purchase Order Number is required for this Property, Would you like to Override?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Not EnterOverridePassword() Then
                        Return False
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim currentJob As New Entity.Jobs.Job With {
                .SetJobID = Job.JobID,
                .SetJobTypeID = Job.JobTypeID,
                .SetPropertyID = Site.SiteID
                }
            currentJob.Exists = currentJob.JobID > 0

            If currentJob.JobTypeID = Enums.FleetJobTypes.VanMaintenance Then
                If Fleet IsNot Nothing AndAlso Fleet.Exists Then
                    If ShowMessage("Remove service from van?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        DB.FleetVanService.Delete(currentJob.JobID)
                    End If
                End If
            End If

            currentJob.IgnoreExceptionsOnSetMethods = True
            If Me.rdoCallout.Checked Then
                currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Callout)
            ElseIf Me.rdoMisc.Checked Then
                currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Misc)
            ElseIf Me.rdoContract.Checked Then
                currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Contract)
            ElseIf Me.rdoQuoted.Checked Then
                currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Quoted)
            End If

            currentJob.SetJobTypeID = Combo.GetSelectedItemValue(Me.cboJobType)
            currentJob.SetJobNumber = Me.txtJobNumber.Text.Trim
            currentJob.SetPONumber = "" 'Me.txtPONumber.Text.Trim
            currentJob.SetToBePartPaid = Me.cbxToBePartPaid.Checked
            currentJob.SetRetention = Helper.MakeDoubleValid(txtRetention.Text)
            currentJob.SetCollectPayment = Me.chkCollectPayment.Checked
            currentJob.SetPOC = Me.chkPOC.Checked
            currentJob.SetOTI = Me.chkOTI.Checked
            currentJob.SetFOC = chkFoc.Checked
            currentJob.SetSalesRepUserID = SalesRep.UserID
            currentJob.SetHeadline = Me.txtHeadline.Text
            currentJob.Assets.Clear()
            For Each row As DataRow In OnForm.AssetsDataView.Table.Rows
                If row.Item("Tick") Then
                    Dim oJobAsset As New Entity.JobAssets.JobAsset
                    oJobAsset.SetAssetID = Helper.MakeIntegerValid(row.Item("AssetID"))
                    currentJob.Assets.Add(oJobAsset)
                End If
            Next

            CureentJOWCount = currentJob.JobOfWorks.Count

            Dim ValidJOWCount As Integer = 0
            Dim currentVisit As Entity.EngineerVisits.EngineerVisit = Nothing
            Dim jobPriority As Integer = 0
            currentJob.JobOfWorks.Clear()
            Dim LoopCount As Integer = 0
            For Each page As TabPage In Me.tcJobOfWorks.TabPages
                LoopCount += 1
                Dim jow As New Entity.JobOfWorks.JobOfWork With {.SetJobOfWorkID = CType(page.Controls(0), UCCalloutBreakdown).JobOfWork.JobOfWorkID}
                jow.Exists = jow.JobOfWorkID > 0
                jow.SetPONumber = CType(page.Controls(0), UCCalloutBreakdown).txtPONumber.Text
                jow.SetQualificationID = Combo.GetSelectedItemValue(CType(page.Controls(0), UCCalloutBreakdown).cboQualification)

                jobPriority = Combo.GetSelectedItemValue(CType(page.Controls(0), UCCalloutBreakdown).cboPriority)
                If jobPriority > 0 Then
                    jow.SetPriority = jobPriority
                Else
                    jobPriority = jow.Priority
                End If

                If LoopCount >= 3 Then JOW3Priority = jow.Priority

                If jow.PriorityDateSet = Date.MinValue And Combo.GetSelectedItemValue(CType(page.Controls(0), UCCalloutBreakdown).cboPriority) > 0 Then
                    jow.PriorityDateSet = Now()
                End If

                jow.IgnoreExceptionsOnSetMethods = True

                jow.JobItems.Clear()
                For Each row As DataRow In CType(page.Controls(0), UCCalloutBreakdown).JobItemsAddedDataView.Table.Rows
                    Dim oJobItem As New Entity.JobItems.JobItem
                    oJobItem.IgnoreExceptionsOnSetMethods = True
                    oJobItem.SetJobItemID = Helper.MakeIntegerValid(row.Item("JobItemID"))
                    oJobItem.SetSummary = Helper.MakeStringValid(row.Item("Summary"))
                    oJobItem.SetRateID = Helper.MakeIntegerValid(row.Item("RateID"))
                    oJobItem.SetQty = Helper.MakeDoubleValid(row.Item("Qty"))
                    oJobItem.SetSystemLinkID = Helper.MakeDoubleValid(row.Item("SystemLinkID"))
                    jow.JobItems.Add(oJobItem)
                Next

                jow.EngineerVisits.Clear()
                Dim visitcount As Integer = CType(page.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages.Count
                Dim visitcounter As Integer = 1
                For Each subpage As TabPage In CType(page.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
                    Dim visit As New Entity.EngineerVisits.EngineerVisit With {.SetEngineerVisitID = CType(subpage.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID}
                    visit.Exists = visit.EngineerVisitID > 0
                    visit.IgnoreExceptionsOnSetMethods = True
                    visit.SetStatusEnumID = Combo.GetSelectedItemValue(CType(subpage.Controls(0), UCVisitBreakdown).cboStatus)
                    visit.SetNotesToEngineer = CType(subpage.Controls(0), UCVisitBreakdown).txtNotesToEngineer.Text.Trim
                    visit.SetPartsToFit = CType(subpage.Controls(0), UCVisitBreakdown).cbxPartsToFit.Checked
                    visit.PartsAndProductsAllocated = CType(subpage.Controls(0), UCVisitBreakdown).PartsAndProducts
                    visit.SetExpectedEngineerID = Combo.GetSelectedItemValue(CType(subpage.Controls(0), UCVisitBreakdown).cboExpected)
                    visit.SetRecharge = CType(subpage.Controls(0), UCVisitBreakdown).chkRecharge.Checked
                    visit.setChange = CType(subpage.Controls(0), UCVisitBreakdown).change
                    visit.SetExcludeFromTextMessage = CType(subpage.Controls(0), UCVisitBreakdown).chkSendText.Checked

                    jow.EngineerVisits.Add(visit)
                    If LoopCount = 1 And visitcount = 1 Then currentVisit = visit

                    CleanUpOrdersForPartProductsAllocated(CType(subpage.Controls(0), UCVisitBreakdown).PartsProductsToRemoveFromOrder, CType(subpage.Controls(0), UCVisitBreakdown).PartsProductsToReallocated, trans)

                    CType(subpage.Controls(0), UCVisitBreakdown).PartsProductsToRemoveFromOrder = Nothing
                    CType(subpage.Controls(0), UCVisitBreakdown).PartsProductsToReallocated = Nothing

                    LastVisitStatus = visit.OutcomeEnumID
                    If visitcounter = visitcount Then
                        If LastVisitStatus = 1 Or LastVisitStatus = 5 Then
                            ValidJOWCount += 1
                        End If
                    End If
                    visitcounter += 1
                Next

                currentJob.JobOfWorks.Add(jow)
            Next

            Try
                Dim jV As New Entity.Jobs.JobValidator

                jV.Validate(currentJob)

                'update van information if necessary
                If currentJob.JobTypeID = Enums.FleetJobTypes.VanFault Then
                    'check if job logged against fault already
                    Dim currentFault As Entity.FleetVans.FleetVanFault = Nothing
                    If currentJob.Exists Then
                        currentFault = DB.FleetVanFault.Get_ByJobID(currentJob.JobID)
                    End If
                    If currentFault Is Nothing Then
                        Dim ID As Integer = FindRecord(Enums.TableNames.tblFleetVanFault)
                        If Not ID = 0 Then
                            currentFault = DB.FleetVanFault.Get(ID)
                            If currentFault IsNot Nothing Then
                                currentFault.SetJobID = currentJob.JobID
                                DB.FleetVanFault.Update(currentFault)
                                Fleet = DB.FleetVan.Get(currentFault.VanID)
                            End If
                        End If
                    End If
                End If

                If Not currentJob.Exists Then
                    currentJob = DB.Job.Insert(currentJob, trans)
                    trans.Commit()
                    If currentJob.JobTypeID = Enums.JobTypes.Breakdown Then EmailServiceAlertDate()
                    ShowMessage("Job added for job number : " & currentJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    DB.Job.Update(currentJob, JobOfWorksRemoved, EngineerVisitsRemoved, EngineerVisitsOrdersRemoved, trans)
                    trans.Commit()
                    ShowMessage("Job details updated for job number : " & currentJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If currentJob.JobTypeID = Enums.FleetJobTypes.VanMaintenance Then
                    If Fleet IsNot Nothing AndAlso Fleet.Exists Then
                        Dim jobid As Integer = currentJob.JobID
                        DB.FleetVanService.Insert(currentJob.JobID, Fleet.VanID)
                    End If
                End If

                CurrentCustomerID = Customer.CustomerID

                For Each oJobOfWork As Entity.JobOfWorks.JobOfWork In currentJob.JobOfWorks
                    For Each oEngineerVisit As Entity.EngineerVisits.EngineerVisit In oJobOfWork.EngineerVisits
                        DB.EngineerVisitPartProductAllocated.SplitToOrder(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, currentJob.JobID)
                    Next
                Next

                NewJOWCount = currentJob.JobOfWorks.Count
                If (ValidJOWCount >= 3) And IsNewJobOfWork And currentJob.JobTypeID = Enums.JobTypes.Breakdown Then

                    Dim custId As Integer = 0
                    Dim emailAddresses As List(Of String) = Nothing
                    If Customer.CustomerTypeID <> Enums.CustomerType.SocialHousing Then
                        custId = Enums.Customer.Domestic
                    Else
                        custId = Customer.CustomerID
                    End If

                    Dim customerAlerts As List(Of Entity.Customers.CustomerAlert) = DB.CustomerAlert.Get_ForCustomer(custId)
                    If customerAlerts?.Count > 0 Then
                        emailAddresses = customerAlerts.Where(Function(x) x.AlertTypeId = Enums.AlertType.Jow).FirstOrDefault().EmailAddress.Split(New Char() {";"c}).ToList()
                    End If

                    Dim cleanEmailList As New List(Of String)
                    If emailAddresses IsNot Nothing Then
                        For Each emailAddress As String In emailAddresses
                            If Helper.IsEmailValid(emailAddress) Then cleanEmailList.Add(emailAddress)
                        Next
                    End If

                    If cleanEmailList.Count > 0 Then
                        Dim JobNo As String = currentJob.JobNumber
                        Dim Priority As String = JOW3Priority
                        Dim JOWCount As Integer = currentJob.JobOfWorks.Count
                        Dim SiteAddress As String = Site.Address1 & " " & Site.Address2 & ", " & Site.Postcode
                        Dim Customer As String = Me.Customer.Name
                        Dim ContractType As String = txtCurrentContract.Text
                        Dim CurrentUser As String = loggedInUser.Fullname
                        Dim LastVisit As String = "Coming Soon"

                        Dim PersonName As String = Nothing
                        Dim GreetingPart As String = Nothing

                        If Now.Hour >= 3 And Now.Hour < 12 Then
                            GreetingPart = "Morning"
                        ElseIf Now.Hour >= 12 And Now.Hour < 17 Then
                            GreetingPart = "Afternoon"
                        Else
                            GreetingPart = "Evening"
                        End If

                        PersonName = "Good " & GreetingPart

                        Dim FeedbackEmail As New Emails
                        FeedbackEmail.From = EmailAddress.Gabriel
                        For Each email As String In cleanEmailList
                            FeedbackEmail.ToList.Add(email)
                        Next

                        FeedbackEmail.Subject = "3rd Job of Works Notification"
                        FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" &
                    "<p>" & PersonName & "</p>" &
                    "<p>A new job of works has been created that exceeds the alerting threshold, details are below:-</p>" &
                    "<p>Job Number - <b>" & JobNo & "</b>" &
                    "<br/> Priority - <b>" & JOW3Priority & "</b>" &
                    "<br/>Customer - <b>" & Customer & "</b>" &
                    "<br/>Site - <b>" & SiteAddress & "</b>" &
                    "<br/>Contract Type - <b>" & ContractType & "</b>" &
                    "<br/>JOW Count - <b>" & JOWCount & "</b>" &
                    "<br/>User - <b>" & CurrentUser & "</b>" &
                    "<br/>Last Visit - <b>" & LastVisit & "</b>" &
                    "<p>" & TheSystem.Configuration.CompanyName & "</p>" &
                    "</span>"

                        FeedbackEmail.SendMe = True
                        FeedbackEmail.Send()
                        IsNewJobOfWork = False
                    End If
                End If

                JobId = currentJob.JobID
                Populate()
            Catch vex As ValidationException
                Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                If Not trans Is Nothing Then
                    trans.Rollback()
                End If
                If Not con Is Nothing Then
                    con.Close()
                End If

                Return False
            Catch ex As Exception
                ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

                If Not trans Is Nothing Then
                    trans.Rollback()
                End If
                If Not con Is Nothing Then
                    con.Close()
                End If

                Return False
            End Try

            RaiseEvent StateChanged(currentJob.JobID)

            Return True
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not trans Is Nothing Then
                trans.Rollback()
            End If
            If Not con Is Nothing Then
                con.Close()
            End If

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub CleanUpOrdersForPartProductsAllocated(ByVal toRemove As ArrayList, ByVal toReallocate As ArrayList, ByVal trans As SqlClient.SqlTransaction)
        Dim i As Integer = 0
        If Not toRemove Is Nothing Then

            'REMOVING PARTS/PRODUCTS FROM AN ORDER
            For i = 0 To toRemove.Count - 1
                Dim aR As ArrayList = toRemove(i)
                If aR(0) = "Part" And CType(aR(4), Enums.LocationType) = CInt(Enums.LocationType.Supplier) Then
                    DB.OrderPart.Delete(aR(3), trans)
                ElseIf aR(0) = "Product" And CType(aR(4), Enums.LocationType) = CInt(Enums.LocationType.Supplier) Then
                    DB.OrderProduct.Delete(aR(3), trans)
                ElseIf aR(0) = "Part" And CType(aR(4), Enums.LocationType) <> CInt(Enums.LocationType.Supplier) Then
                    Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                    oOrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(aR(3), trans)
                    DB.OrderLocationPart.Delete(oOrderLocationPart.OrderLocationPartID, trans)

                    Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                    oPartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID, trans)
                    If Not oPartTransaction Is Nothing Then
                        DB.PartTransaction.Delete(oPartTransaction.PartTransactionID, trans)
                    End If
                ElseIf aR(0) = "Product" And CType(aR(4), Enums.LocationType) <> CInt(Enums.LocationType.Supplier) Then
                    Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                    oOrderLocationProduct = DB.OrderLocationProduct.OrderLocationProduct_Get(aR(3), trans)
                    DB.OrderLocationProduct.Delete(oOrderLocationProduct.OrderLocationProductID, trans)

                    Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                    oProductTransaction = DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID, trans)
                    If Not oProductTransaction Is Nothing Then
                        DB.ProductTransaction.Delete(oProductTransaction.ProductTransactionID, trans)
                    End If
                End If
            Next i
        End If

        If Not toReallocate Is Nothing Then

            'REALLOCATE
            Dim ID As Integer = 0
            If toReallocate.Count > 0 Then
                'locationID to move to
                ID = FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans)
            End If

            For i = 0 To toReallocate.Count - 1
                Dim aA As ArrayList = toReallocate(i)

                'is it a part or a product?
                If aA(0) = "Part" Then
                    Dim PartTran As New Entity.PartTransactions.PartTransaction
                    PartTran.SetAmount = aA(1)
                    PartTran.SetLocationID = ID
                    PartTran.SetOrderLocationPartID = 0
                    PartTran.SetOrderPartID = 0
                    PartTran.SetPartID = aA(2)
                    PartTran.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                    PartTran.SetUserID = loggedInUser.UserID
                    PartTran.TransactionDate = Now

                    DB.PartTransaction.Insert(PartTran, trans)
                Else
                    Dim ProductTran As New Entity.ProductTransactions.ProductTransaction
                    ProductTran.SetAmount = aA(1)
                    ProductTran.SetLocationID = ID
                    ProductTran.SetOrderLocationProductID = 0
                    ProductTran.SetOrderProductID = 0
                    ProductTran.SetProductID = aA(2)
                    ProductTran.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                    ProductTran.SetUserID = loggedInUser.UserID
                    ProductTran.TransactionDate = Now
                    DB.ProductTransaction.Insert(ProductTran, trans)
                End If

            Next i

        End If
    End Sub

    Private Sub cboJobType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJobType.SelectedIndexChanged
        If Site.CustomerID = Enums.Customer.Vehicle Then
            If Combo.GetSelectedItemValue(cboJobType) = Enums.FleetJobTypes.VanMaintenance Then
                btnfindVan.Enabled = True
            Else
                btnfindVan.Enabled = False
            End If
        End If
    End Sub

#End Region

    Private Sub btnfindVan_Click(sender As Object, e As EventArgs) Handles btnfindVan.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblFleetVan)
        If Not ID = 0 Then
            Fleet = DB.FleetVan.Get(ID)
        End If
    End Sub

    Private Sub EmailServiceAlertDate()
        If Site IsNot Nothing AndAlso Not Site.NoService Then

            Dim custId As Integer = 0
            Dim emailAddresses As List(Of String) = Nothing
            If Customer.CustomerTypeID <> Enums.CustomerType.SocialHousing Then
                custId = Enums.Customer.Domestic
            Else
                custId = Customer.CustomerID
            End If

            Dim customerAlerts As List(Of Entity.Customers.CustomerAlert) = DB.CustomerAlert.Get_ForCustomer(custId)
            If customerAlerts?.Count > 0 Then
                emailAddresses = customerAlerts.Where(Function(x) x.AlertTypeId = Enums.AlertType.JobCreation).FirstOrDefault().EmailAddress.Split(New Char() {";"c}).ToList()
            End If

            Dim cleanEmailList As New List(Of String)
            If emailAddresses IsNot Nothing Then
                For Each emailAddress As String In emailAddresses
                    If Helper.IsEmailValid(emailAddress) Then cleanEmailList.Add(emailAddress)
                Next
            End If

            If cleanEmailList.Count > 0 Then
                Dim servicedate As DateTime = Site.LastServiceDate
                servicedate = servicedate.AddYears(1)
                If (Not servicedate = Date.MinValue.AddYears(1)) AndAlso servicedate <= Now.Date And servicedate.AddYears(1) >= Now.Date Then
                    Dim email As New Emails
                    For Each cleanEmail As String In cleanEmailList
                        email.ToList.Add(cleanEmail)
                    Next
                    email.From = EmailAddress.FSM
                    email.Subject = "Job Created on Site Due for Service!"
                    Dim html As String = "<table border='1'>"
                    html += "<tr>"
                    html += "<td>Name</td><td>Address1</td><td>Address2</td><td>PostCode</td><td>Job Number</td>"
                    html += "</tr>"
                    html += "<tr>"
                    html += "<td>" & Site.Name & "</td><td>" & Site.Address1 & "</td><td>" & Site.Address2 & "</td><td>" & Site.Postcode & "</td><td>" & Job.JobNumber & "</td>"
                    html += "</tr>"
                    html += "</table>"
                    email.Body = html
                    email.SendMe = True
                    email.Send()
                End If
            End If
        End If
    End Sub

    Private Sub btnFindUser_Click(sender As Object, e As EventArgs) Handles btnFindUser.Click
        If SalesRep.Exists Then
            If EnterOverridePassword() = False Then
                Exit Sub
            End If
        End If

        Dim ID As Integer = FindRecord(Enums.TableNames.tblUser)
        If Not ID = 0 Then
            SalesRep = DB.User.Get(ID)
        End If
    End Sub

    Private Sub btnAddContactAttempt_Click(sender As Object, e As EventArgs) Handles btnAddContactAttempt.Click
        AddContactAttempt()
    End Sub

    Public Sub AddContactAttempt()
        If Job IsNot Nothing OrElse Job.JobID > 0 Then
            Dim frmContactAttempt As New FRMContactAttempt(Enums.TableNames.tblJob, Job.JobID)
            frmContactAttempt.ShowDialog()
            If frmContactAttempt.DialogResult = DialogResult.OK Then
                Populate(Job.JobID)
                OnForm.PopulateContactAttempts()
            End If
        End If
    End Sub

End Class