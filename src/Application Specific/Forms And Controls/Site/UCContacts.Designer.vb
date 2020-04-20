<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCContacts


    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpSiteContacts = New System.Windows.Forms.GroupBox()
        Me.grpContacts = New System.Windows.Forms.GroupBox()
        Me.dgSiteContacts = New System.Windows.Forms.DataGrid()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblRelationship = New System.Windows.Forms.Label()
        Me.cboRelationship = New System.Windows.Forms.ComboBox()
        Me.chkIsPOC = New System.Windows.Forms.CheckBox()
        Me.chkOnContract = New System.Windows.Forms.CheckBox()
        Me.btnNewContact = New System.Windows.Forms.Button()
        Me.btnDeleteContact = New System.Windows.Forms.Button()
        Me.btnSaveContact = New System.Windows.Forms.Button()
        Me.chkNoMarketing = New System.Windows.Forms.CheckBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblMobileNumber = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstname = New System.Windows.Forms.Label()
        Me.txtMobileNumber = New System.Windows.Forms.TextBox()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cboTitle = New System.Windows.Forms.ComboBox()
        Me.grpSiteContacts.SuspendLayout()
        Me.grpContacts.SuspendLayout()
        CType(Me.dgSiteContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSiteContacts
        '
        Me.grpSiteContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteContacts.AutoSize = True
        Me.grpSiteContacts.Controls.Add(Me.grpContacts)
        Me.grpSiteContacts.Controls.Add(Me.grpContact)
        Me.grpSiteContacts.Location = New System.Drawing.Point(0, 0)
        Me.grpSiteContacts.Margin = New System.Windows.Forms.Padding(0)
        Me.grpSiteContacts.Name = "grpSiteContacts"
        Me.grpSiteContacts.Padding = New System.Windows.Forms.Padding(0)
        Me.grpSiteContacts.Size = New System.Drawing.Size(1401, 670)
        Me.grpSiteContacts.TabIndex = 15
        Me.grpSiteContacts.TabStop = False
        Me.grpSiteContacts.Text = "Site Contacts"
        '
        'grpContacts
        '
        Me.grpContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContacts.Controls.Add(Me.dgSiteContacts)
        Me.grpContacts.Location = New System.Drawing.Point(13, 183)
        Me.grpContacts.Name = "grpContacts"
        Me.grpContacts.Size = New System.Drawing.Size(1381, 471)
        Me.grpContacts.TabIndex = 149
        Me.grpContacts.TabStop = False
        Me.grpContacts.Text = "Contacts"
        '
        'dgSiteContacts
        '
        Me.dgSiteContacts.DataMember = ""
        Me.dgSiteContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSiteContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteContacts.Location = New System.Drawing.Point(3, 17)
        Me.dgSiteContacts.Name = "dgSiteContacts"
        Me.dgSiteContacts.Size = New System.Drawing.Size(1375, 451)
        Me.dgSiteContacts.TabIndex = 11
        '
        'grpContact
        '
        Me.grpContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContact.Controls.Add(Me.lblPostcode)
        Me.grpContact.Controls.Add(Me.txtPostcode)
        Me.grpContact.Controls.Add(Me.lblAddress3)
        Me.grpContact.Controls.Add(Me.txtAddress3)
        Me.grpContact.Controls.Add(Me.lblAddress2)
        Me.grpContact.Controls.Add(Me.txtAddress2)
        Me.grpContact.Controls.Add(Me.lblAddress1)
        Me.grpContact.Controls.Add(Me.txtAddress1)
        Me.grpContact.Controls.Add(Me.lblRelationship)
        Me.grpContact.Controls.Add(Me.cboRelationship)
        Me.grpContact.Controls.Add(Me.chkIsPOC)
        Me.grpContact.Controls.Add(Me.chkOnContract)
        Me.grpContact.Controls.Add(Me.btnNewContact)
        Me.grpContact.Controls.Add(Me.btnDeleteContact)
        Me.grpContact.Controls.Add(Me.btnSaveContact)
        Me.grpContact.Controls.Add(Me.chkNoMarketing)
        Me.grpContact.Controls.Add(Me.lblEmailAddress)
        Me.grpContact.Controls.Add(Me.txtEmailAddress)
        Me.grpContact.Controls.Add(Me.lblMobileNumber)
        Me.grpContact.Controls.Add(Me.lblLastName)
        Me.grpContact.Controls.Add(Me.lblFirstname)
        Me.grpContact.Controls.Add(Me.txtMobileNumber)
        Me.grpContact.Controls.Add(Me.txtLastname)
        Me.grpContact.Controls.Add(Me.txtFirstName)
        Me.grpContact.Controls.Add(Me.lblTitle)
        Me.grpContact.Controls.Add(Me.cboTitle)
        Me.grpContact.Location = New System.Drawing.Point(13, 17)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(1381, 160)
        Me.grpContact.TabIndex = 115
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Contact"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(545, 93)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(82, 21)
        Me.lblPostcode.TabIndex = 161
        Me.lblPostcode.Text = "Postcode"
        Me.lblPostcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(633, 93)
        Me.txtPostcode.MaxLength = 255
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(170, 21)
        Me.txtPostcode.TabIndex = 148
        Me.txtPostcode.Tag = ""
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(545, 58)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(82, 21)
        Me.lblAddress3.TabIndex = 159
        Me.lblAddress3.Text = "Address 3"
        Me.lblAddress3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(633, 58)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(170, 21)
        Me.txtAddress3.TabIndex = 147
        Me.txtAddress3.Tag = ""
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(545, 22)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(82, 21)
        Me.lblAddress2.TabIndex = 157
        Me.lblAddress2.Text = "Address 2"
        Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(633, 22)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(170, 21)
        Me.txtAddress2.TabIndex = 146
        Me.txtAddress2.Tag = ""
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(265, 93)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(82, 21)
        Me.lblAddress1.TabIndex = 155
        Me.lblAddress1.Text = "Address 1"
        Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(353, 93)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(170, 21)
        Me.txtAddress1.TabIndex = 145
        Me.txtAddress1.Tag = ""
        '
        'lblRelationship
        '
        Me.lblRelationship.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRelationship.Location = New System.Drawing.Point(823, 23)
        Me.lblRelationship.Name = "lblRelationship"
        Me.lblRelationship.Size = New System.Drawing.Size(152, 21)
        Me.lblRelationship.TabIndex = 153
        Me.lblRelationship.Text = "Relationship To Tennent"
        Me.lblRelationship.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRelationship
        '
        Me.cboRelationship.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRelationship.FormattingEnabled = True
        Me.cboRelationship.Location = New System.Drawing.Point(981, 23)
        Me.cboRelationship.Name = "cboRelationship"
        Me.cboRelationship.Size = New System.Drawing.Size(170, 21)
        Me.cboRelationship.TabIndex = 149
        '
        'chkIsPOC
        '
        Me.chkIsPOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsPOC.Location = New System.Drawing.Point(1179, 88)
        Me.chkIsPOC.Name = "chkIsPOC"
        Me.chkIsPOC.Size = New System.Drawing.Size(120, 24)
        Me.chkIsPOC.TabIndex = 152
        Me.chkIsPOC.Text = "Point Of Contact"
        '
        'chkOnContract
        '
        Me.chkOnContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOnContract.Location = New System.Drawing.Point(1179, 54)
        Me.chkOnContract.Name = "chkOnContract"
        Me.chkOnContract.Size = New System.Drawing.Size(120, 24)
        Me.chkOnContract.TabIndex = 151
        Me.chkOnContract.Text = "On Contract"
        '
        'btnNewContact
        '
        Me.btnNewContact.Location = New System.Drawing.Point(15, 131)
        Me.btnNewContact.Name = "btnNewContact"
        Me.btnNewContact.Size = New System.Drawing.Size(75, 23)
        Me.btnNewContact.TabIndex = 149
        Me.btnNewContact.Text = "Clear"
        Me.btnNewContact.UseVisualStyleBackColor = True
        '
        'btnDeleteContact
        '
        Me.btnDeleteContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteContact.Location = New System.Drawing.Point(1179, 131)
        Me.btnDeleteContact.Name = "btnDeleteContact"
        Me.btnDeleteContact.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteContact.TabIndex = 148
        Me.btnDeleteContact.Text = "Delete"
        '
        'btnSaveContact
        '
        Me.btnSaveContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveContact.Location = New System.Drawing.Point(1300, 131)
        Me.btnSaveContact.Name = "btnSaveContact"
        Me.btnSaveContact.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveContact.TabIndex = 147
        Me.btnSaveContact.Text = "Save"
        '
        'chkNoMarketing
        '
        Me.chkNoMarketing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNoMarketing.Location = New System.Drawing.Point(1179, 20)
        Me.chkNoMarketing.Name = "chkNoMarketing"
        Me.chkNoMarketing.Size = New System.Drawing.Size(120, 24)
        Me.chkNoMarketing.TabIndex = 150
        Me.chkNoMarketing.Text = "No Marketing"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(297, 58)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(50, 21)
        Me.lblEmailAddress.TabIndex = 145
        Me.lblEmailAddress.Text = "Email"
        Me.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(353, 58)
        Me.txtEmailAddress.MaxLength = 255
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(170, 21)
        Me.txtEmailAddress.TabIndex = 144
        Me.txtEmailAddress.Tag = ""
        '
        'lblMobileNumber
        '
        Me.lblMobileNumber.Location = New System.Drawing.Point(297, 19)
        Me.lblMobileNumber.Name = "lblMobileNumber"
        Me.lblMobileNumber.Size = New System.Drawing.Size(50, 21)
        Me.lblMobileNumber.TabIndex = 141
        Me.lblMobileNumber.Text = "Mobile"
        Me.lblMobileNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(15, 92)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(68, 21)
        Me.lblLastName.TabIndex = 140
        Me.lblLastName.Text = "Last Name"
        Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFirstname
        '
        Me.lblFirstname.Location = New System.Drawing.Point(15, 57)
        Me.lblFirstname.Name = "lblFirstname"
        Me.lblFirstname.Size = New System.Drawing.Size(68, 21)
        Me.lblFirstname.TabIndex = 139
        Me.lblFirstname.Text = "First Name"
        Me.lblFirstname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMobileNumber
        '
        Me.txtMobileNumber.Location = New System.Drawing.Point(353, 20)
        Me.txtMobileNumber.MaxLength = 255
        Me.txtMobileNumber.Name = "txtMobileNumber"
        Me.txtMobileNumber.Size = New System.Drawing.Size(170, 21)
        Me.txtMobileNumber.TabIndex = 138
        Me.txtMobileNumber.Tag = ""
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(89, 92)
        Me.txtLastname.MaxLength = 255
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(170, 21)
        Me.txtLastname.TabIndex = 137
        Me.txtLastname.Tag = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(89, 58)
        Me.txtFirstName.MaxLength = 255
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(170, 21)
        Me.txtFirstName.TabIndex = 136
        Me.txtFirstName.Tag = ""
        '
        'lblTitle
        '
        Me.lblTitle.Location = New System.Drawing.Point(15, 21)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(68, 20)
        Me.lblTitle.TabIndex = 135
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTitle
        '
        Me.cboTitle.FormattingEnabled = True
        Me.cboTitle.Location = New System.Drawing.Point(89, 20)
        Me.cboTitle.Name = "cboTitle"
        Me.cboTitle.Size = New System.Drawing.Size(170, 21)
        Me.cboTitle.TabIndex = 134
        '
        'UCContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.grpSiteContacts)
        Me.Name = "UCContacts"
        Me.Size = New System.Drawing.Size(1403, 672)
        Me.grpSiteContacts.ResumeLayout(False)
        Me.grpContacts.ResumeLayout(False)
        CType(Me.dgSiteContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpSiteContacts As GroupBox
    Friend WithEvents grpContacts As GroupBox
    Friend WithEvents dgSiteContacts As DataGrid
    Friend WithEvents grpContact As GroupBox
    Friend WithEvents chkOnContract As CheckBox
    Friend WithEvents btnNewContact As Button
    Friend WithEvents btnDeleteContact As Button
    Friend WithEvents btnSaveContact As Button
    Friend WithEvents chkNoMarketing As CheckBox
    Friend WithEvents lblEmailAddress As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents lblMobileNumber As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstname As Label
    Friend WithEvents txtMobileNumber As TextBox
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents cboTitle As ComboBox
    Friend WithEvents chkIsPOC As CheckBox
    Friend WithEvents lblRelationship As Label
    Friend WithEvents cboRelationship As ComboBox
    Friend WithEvents lblPostcode As Label
    Friend WithEvents txtPostcode As TextBox
    Friend WithEvents lblAddress3 As Label
    Friend WithEvents txtAddress3 As TextBox
    Friend WithEvents lblAddress2 As Label
    Friend WithEvents txtAddress2 As TextBox
    Friend WithEvents lblAddress1 As Label
    Friend WithEvents txtAddress1 As TextBox
End Class
