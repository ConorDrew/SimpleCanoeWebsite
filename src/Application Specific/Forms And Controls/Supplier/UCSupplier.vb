Public Class UCSupplier : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboMainSupplier, DB.Supplier.Supplier_GetAll.Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboMainSupplier.Visible = False
        Label4.Visible = False
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

    Friend WithEvents grpSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents lblTown As System.Windows.Forms.Label
    Friend WithEvents lblCounty As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGaswayAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSupplierBranch As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMainSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents chkReleaseToTablets As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubContractor As System.Windows.Forms.CheckBox
    Friend WithEvents chkSecondaryPrice As CheckBox
    Friend WithEvents txtNominal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSecondAccountNumber As TextBox
    Friend WithEvents lblSecondAccount As Label
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSupplier = New System.Windows.Forms.GroupBox()
        Me.txtNominal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSecondAccountNumber = New System.Windows.Forms.TextBox()
        Me.lblSecondAccount = New System.Windows.Forms.Label()
        Me.chkSecondaryPrice = New System.Windows.Forms.CheckBox()
        Me.chkSubContractor = New System.Windows.Forms.CheckBox()
        Me.chkReleaseToTablets = New System.Windows.Forms.CheckBox()
        Me.chkSupplierBranch = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMainSupplier = New System.Windows.Forms.ComboBox()
        Me.txtGaswayAccount = New System.Windows.Forms.TextBox()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.lblTown = New System.Windows.Forms.Label()
        Me.txtAddress5 = New System.Windows.Forms.TextBox()
        Me.lblCounty = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSupplier.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSupplier
        '
        Me.grpSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSupplier.Controls.Add(Me.txtNominal)
        Me.grpSupplier.Controls.Add(Me.Label3)
        Me.grpSupplier.Controls.Add(Me.txtSecondAccountNumber)
        Me.grpSupplier.Controls.Add(Me.lblSecondAccount)
        Me.grpSupplier.Controls.Add(Me.chkSecondaryPrice)
        Me.grpSupplier.Controls.Add(Me.chkSubContractor)
        Me.grpSupplier.Controls.Add(Me.chkReleaseToTablets)
        Me.grpSupplier.Controls.Add(Me.chkSupplierBranch)
        Me.grpSupplier.Controls.Add(Me.Label4)
        Me.grpSupplier.Controls.Add(Me.cboMainSupplier)
        Me.grpSupplier.Controls.Add(Me.txtGaswayAccount)
        Me.grpSupplier.Controls.Add(Me.txtAccountNumber)
        Me.grpSupplier.Controls.Add(Me.txtName)
        Me.grpSupplier.Controls.Add(Me.lblName)
        Me.grpSupplier.Controls.Add(Me.txtAddress1)
        Me.grpSupplier.Controls.Add(Me.lblAddress1)
        Me.grpSupplier.Controls.Add(Me.txtAddress2)
        Me.grpSupplier.Controls.Add(Me.lblAddress2)
        Me.grpSupplier.Controls.Add(Me.txtAddress3)
        Me.grpSupplier.Controls.Add(Me.lblAddress3)
        Me.grpSupplier.Controls.Add(Me.txtAddress4)
        Me.grpSupplier.Controls.Add(Me.lblTown)
        Me.grpSupplier.Controls.Add(Me.txtAddress5)
        Me.grpSupplier.Controls.Add(Me.lblCounty)
        Me.grpSupplier.Controls.Add(Me.txtPostcode)
        Me.grpSupplier.Controls.Add(Me.lblPostcode)
        Me.grpSupplier.Controls.Add(Me.txtTelephoneNum)
        Me.grpSupplier.Controls.Add(Me.lblTelephoneNum)
        Me.grpSupplier.Controls.Add(Me.txtFaxNum)
        Me.grpSupplier.Controls.Add(Me.lblFaxNum)
        Me.grpSupplier.Controls.Add(Me.txtEmailAddress)
        Me.grpSupplier.Controls.Add(Me.lblEmailAddress)
        Me.grpSupplier.Controls.Add(Me.txtNotes)
        Me.grpSupplier.Controls.Add(Me.lblNotes)
        Me.grpSupplier.Controls.Add(Me.Label2)
        Me.grpSupplier.Controls.Add(Me.Label1)
        Me.grpSupplier.Location = New System.Drawing.Point(8, 8)
        Me.grpSupplier.Name = "grpSupplier"
        Me.grpSupplier.Size = New System.Drawing.Size(567, 665)
        Me.grpSupplier.TabIndex = 1
        Me.grpSupplier.TabStop = False
        Me.grpSupplier.Text = "Main Details"
        '
        'txtNominal
        '
        Me.txtNominal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNominal.Location = New System.Drawing.Point(235, 125)
        Me.txtNominal.MaxLength = 25
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(317, 21)
        Me.txtNominal.TabIndex = 43
        Me.txtNominal.Tag = "Supplier.AccountNumber"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Default Nominal"
        '
        'txtSecondAccountNumber
        '
        Me.txtSecondAccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSecondAccountNumber.Location = New System.Drawing.Point(235, 537)
        Me.txtSecondAccountNumber.MaxLength = 25
        Me.txtSecondAccountNumber.Name = "txtSecondAccountNumber"
        Me.txtSecondAccountNumber.Size = New System.Drawing.Size(317, 21)
        Me.txtSecondAccountNumber.TabIndex = 43
        Me.txtSecondAccountNumber.Tag = "Supplier.AccountNumber"
        Me.txtSecondAccountNumber.Visible = False
        '
        'lblSecondAccount
        '
        Me.lblSecondAccount.Location = New System.Drawing.Point(10, 541)
        Me.lblSecondAccount.Name = "lblSecondAccount"
        Me.lblSecondAccount.Size = New System.Drawing.Size(190, 20)
        Me.lblSecondAccount.TabIndex = 44
        Me.lblSecondAccount.Text = "Second Account Number"
        Me.lblSecondAccount.Visible = False
        '
        'chkSecondaryPrice
        '
        Me.chkSecondaryPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSecondaryPrice.AutoSize = True
        Me.chkSecondaryPrice.Location = New System.Drawing.Point(13, 573)
        Me.chkSecondaryPrice.Name = "chkSecondaryPrice"
        Me.chkSecondaryPrice.Size = New System.Drawing.Size(119, 17)
        Me.chkSecondaryPrice.TabIndex = 42
        Me.chkSecondaryPrice.Text = "Secondary Price"
        Me.chkSecondaryPrice.UseVisualStyleBackColor = True
        '
        'chkSubContractor
        '
        Me.chkSubContractor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSubContractor.AutoSize = True
        Me.chkSubContractor.Location = New System.Drawing.Point(13, 606)
        Me.chkSubContractor.Name = "chkSubContractor"
        Me.chkSubContractor.Size = New System.Drawing.Size(119, 17)
        Me.chkSubContractor.TabIndex = 41
        Me.chkSubContractor.Text = "Sub Contractor?"
        Me.chkSubContractor.UseVisualStyleBackColor = True
        '
        'chkReleaseToTablets
        '
        Me.chkReleaseToTablets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkReleaseToTablets.AutoSize = True
        Me.chkReleaseToTablets.Location = New System.Drawing.Point(13, 640)
        Me.chkReleaseToTablets.Name = "chkReleaseToTablets"
        Me.chkReleaseToTablets.Size = New System.Drawing.Size(187, 17)
        Me.chkReleaseToTablets.TabIndex = 40
        Me.chkReleaseToTablets.Text = "Release Supplier to Tablets?"
        Me.chkReleaseToTablets.UseVisualStyleBackColor = True
        '
        'chkSupplierBranch
        '
        Me.chkSupplierBranch.AutoSize = True
        Me.chkSupplierBranch.Location = New System.Drawing.Point(13, 22)
        Me.chkSupplierBranch.Name = "chkSupplierBranch"
        Me.chkSupplierBranch.Size = New System.Drawing.Size(173, 17)
        Me.chkSupplierBranch.TabIndex = 39
        Me.chkSupplierBranch.Text = "Is this a Supplier Branch?"
        Me.chkSupplierBranch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Main Supplier"
        '
        'cboMainSupplier
        '
        Me.cboMainSupplier.FormattingEnabled = True
        Me.cboMainSupplier.Location = New System.Drawing.Point(235, 45)
        Me.cboMainSupplier.Name = "cboMainSupplier"
        Me.cboMainSupplier.Size = New System.Drawing.Size(317, 21)
        Me.cboMainSupplier.TabIndex = 37
        '
        'txtGaswayAccount
        '
        Me.txtGaswayAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGaswayAccount.Location = New System.Drawing.Point(235, 395)
        Me.txtGaswayAccount.MaxLength = 25
        Me.txtGaswayAccount.Name = "txtGaswayAccount"
        Me.txtGaswayAccount.Size = New System.Drawing.Size(317, 21)
        Me.txtGaswayAccount.TabIndex = 34
        Me.txtGaswayAccount.Tag = ""
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccountNumber.Location = New System.Drawing.Point(235, 99)
        Me.txtAccountNumber.MaxLength = 25
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(317, 21)
        Me.txtAccountNumber.TabIndex = 3
        Me.txtAccountNumber.Tag = "Supplier.AccountNumber"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(235, 72)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(317, 21)
        Me.txtName.TabIndex = 2
        Me.txtName.Tag = "Supplier.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(10, 75)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 20)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Name"
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(235, 152)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(317, 21)
        Me.txtAddress1.TabIndex = 4
        Me.txtAddress1.Tag = "Supplier.Address1"
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(10, 155)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(96, 20)
        Me.lblAddress1.TabIndex = 31
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(235, 179)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(317, 21)
        Me.txtAddress2.TabIndex = 5
        Me.txtAddress2.Tag = "Supplier.Address2"
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(10, 182)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(96, 20)
        Me.lblAddress2.TabIndex = 31
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(235, 206)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(317, 21)
        Me.txtAddress3.TabIndex = 6
        Me.txtAddress3.Tag = "Supplier.Address3"
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(10, 209)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(96, 20)
        Me.lblAddress3.TabIndex = 31
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(235, 233)
        Me.txtAddress4.MaxLength = 255
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(317, 21)
        Me.txtAddress4.TabIndex = 7
        Me.txtAddress4.Tag = "Supplier.Town"
        '
        'lblTown
        '
        Me.lblTown.Location = New System.Drawing.Point(10, 236)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(96, 20)
        Me.lblTown.TabIndex = 31
        Me.lblTown.Text = "Address 4"
        '
        'txtAddress5
        '
        Me.txtAddress5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress5.Location = New System.Drawing.Point(235, 260)
        Me.txtAddress5.MaxLength = 255
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(317, 21)
        Me.txtAddress5.TabIndex = 8
        Me.txtAddress5.Tag = "Supplier.County"
        '
        'lblCounty
        '
        Me.lblCounty.Location = New System.Drawing.Point(10, 263)
        Me.lblCounty.Name = "lblCounty"
        Me.lblCounty.Size = New System.Drawing.Size(96, 20)
        Me.lblCounty.TabIndex = 31
        Me.lblCounty.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Location = New System.Drawing.Point(235, 287)
        Me.txtPostcode.MaxLength = 20
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(317, 21)
        Me.txtPostcode.TabIndex = 9
        Me.txtPostcode.Tag = "Supplier.Postcode"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(10, 290)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(96, 20)
        Me.lblPostcode.TabIndex = 31
        Me.lblPostcode.Text = "Postcode"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(235, 314)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(317, 21)
        Me.txtTelephoneNum.TabIndex = 10
        Me.txtTelephoneNum.Tag = "Supplier.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(10, 317)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(96, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(235, 341)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(317, 21)
        Me.txtFaxNum.TabIndex = 11
        Me.txtFaxNum.Tag = "Supplier.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(10, 344)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(96, 20)
        Me.lblFaxNum.TabIndex = 31
        Me.lblFaxNum.Text = "Fax"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(235, 368)
        Me.txtEmailAddress.MaxLength = 500
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(317, 21)
        Me.txtEmailAddress.TabIndex = 12
        Me.txtEmailAddress.Tag = "Supplier.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(10, 371)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(210, 20)
        Me.lblEmailAddress.TabIndex = 31
        Me.lblEmailAddress.Text = "Email Address (comma seperated)"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(235, 422)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(317, 109)
        Me.txtNotes.TabIndex = 13
        Me.txtNotes.Tag = "Supplier.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(10, 425)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(96, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 398)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Gasway Account"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Account Number"
        '
        'UCSupplier
        '
        Me.Controls.Add(Me.grpSupplier)
        Me.Name = "UCSupplier"
        Me.Size = New System.Drawing.Size(582, 676)
        Me.grpSupplier.ResumeLayout(False)
        Me.grpSupplier.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentSupplier
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentSupplier As Entity.Suppliers.Supplier
    Public Property CurrentSupplier() As Entity.Suppliers.Supplier
        Get
            Return _currentSupplier
        End Get
        Set(ByVal Value As Entity.Suppliers.Supplier)
            _currentSupplier = Value

            If CurrentSupplier Is Nothing Then
                CurrentSupplier = New Entity.Suppliers.Supplier
                CurrentSupplier.Exists = False
            End If

            If CurrentSupplier.Exists Then
                Populate()
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentSupplier = DB.Supplier.Supplier_Get(ID)
        End If

        Me.txtAccountNumber.Text = CurrentSupplier.AccountNumber
        Me.txtSecondAccountNumber.Text = CurrentSupplier.SecondAccountNumber
        Me.txtName.Text = CurrentSupplier.Name
        Me.txtAddress1.Text = CurrentSupplier.Address1
        Me.txtAddress2.Text = CurrentSupplier.Address2
        Me.txtAddress3.Text = CurrentSupplier.Address3
        Me.txtAddress4.Text = CurrentSupplier.Address4
        Me.txtAddress5.Text = CurrentSupplier.Address5
        Me.txtPostcode.Text = CurrentSupplier.Postcode
        Me.txtTelephoneNum.Text = CurrentSupplier.TelephoneNum
        Me.txtFaxNum.Text = CurrentSupplier.FaxNum
        Me.txtEmailAddress.Text = CurrentSupplier.EmailAddress
        Me.txtGaswayAccount.Text = CurrentSupplier.GaswayAccount
        Me.txtNotes.Text = CurrentSupplier.Notes
        Me.txtNominal.Text = CurrentSupplier.DefaultNominal
        If Not CurrentSupplier.MasterSupplierID = 0 Then
            Label4.Visible = True
            chkSupplierBranch.Checked = True
            Combo.SetSelectedComboItem_By_Value(cboMainSupplier, CurrentSupplier.MasterSupplierID)
        End If
        If CurrentSupplier.ReleaseToTablets = True Then
            chkReleaseToTablets.Checked = True
        Else
            chkReleaseToTablets.Checked = False
        End If
        If CurrentSupplier.SecondaryPrice = True Then
            chkSecondaryPrice.Checked = True
        Else
            chkSecondaryPrice.Checked = False
        End If

        chkSubContractor.Checked = CurrentSupplier.SubContractor
        Me.txtNominal.Text = CurrentSupplier.DefaultNominal

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentSupplier.IgnoreExceptionsOnSetMethods = True

            CurrentSupplier.SetAccountNumber = Me.txtAccountNumber.Text.Trim
            CurrentSupplier.SetSecondAccountNumber = Me.txtSecondAccountNumber.Text.Trim
            CurrentSupplier.SetName = Me.txtName.Text.Trim
            CurrentSupplier.SetAddress1 = Me.txtAddress1.Text.Trim
            CurrentSupplier.SetAddress2 = Me.txtAddress2.Text.Trim
            CurrentSupplier.SetAddress3 = Me.txtAddress3.Text.Trim
            CurrentSupplier.SetAddress4 = Me.txtAddress4.Text.Trim
            CurrentSupplier.SetAddress5 = Me.txtAddress5.Text.Trim
            CurrentSupplier.SetPostcode = Me.txtPostcode.Text.Trim
            CurrentSupplier.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentSupplier.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentSupplier.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentSupplier.SetGaswayAccount = Me.txtGaswayAccount.Text
            CurrentSupplier.SetNotes = Me.txtNotes.Text.Trim
            CurrentSupplier.SetDefaultNominal = Me.txtNominal.Text.Trim

            If Not chkSupplierBranch.Checked Then
                CurrentSupplier.SetMasterSupplierID = 0
            Else
                CurrentSupplier.SetMasterSupplierID = Combo.GetSelectedItemValue(cboMainSupplier)
            End If

            If chkReleaseToTablets.Checked Then
                CurrentSupplier.SetReleaseToTablets = True
            Else
                CurrentSupplier.SetReleaseToTablets = False
            End If
            CurrentSupplier.SecondaryPrice = chkSecondaryPrice.Checked
            CurrentSupplier.SetSubContractor = chkSubContractor.Checked

            Dim cV As New Entity.Suppliers.SupplierValidator
            cV.Validate(CurrentSupplier)

            If CurrentSupplier.Exists Then
                DB.Supplier.Update(CurrentSupplier)
            Else
                CurrentSupplier = DB.Supplier.Insert(CurrentSupplier)
            End If
            Populate(CurrentSupplier.SupplierID)

            RaiseEvent RecordsChanged(DB.Supplier.Supplier_GetAll(), Entity.Sys.Enums.PageViewing.Supplier, True, False, "")
            RaiseEvent StateChanged(CurrentSupplier.SupplierID)
            MainForm.RefreshEntity(CurrentSupplier.SupplierID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

#Region "Events"
    Private Sub chkSupplierBranch_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupplierBranch.CheckedChanged
        If chkSupplierBranch.Checked Then
            cboMainSupplier.Visible = True
            Label4.Visible = True
        Else
            cboMainSupplier.Visible = False
            Label4.Visible = False
        End If
    End Sub

    Private Sub chkSecondaryPrice_CheckedChanged(sender As Object, e As EventArgs) Handles chkSecondaryPrice.CheckedChanged
        Me.txtSecondAccountNumber.Visible = chkSecondaryPrice.Checked
        Me.lblSecondAccount.Visible = chkSecondaryPrice.Checked
    End Sub
#End Region
End Class

