Public Class UCContact : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents grpContact As System.Windows.Forms.GroupBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtMobileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPortalUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPortalPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteNote As System.Windows.Forms.Button
    Friend WithEvents btnAddNote As System.Windows.Forms.Button
    Friend WithEvents dgNotes As System.Windows.Forms.DataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkPortalGSRPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSalutation As System.Windows.Forms.ComboBox
    Friend WithEvents txtEID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.cboSalutation = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkPortalGSRPrint = New System.Windows.Forms.CheckBox()
        Me.txtPortalPassword = New System.Windows.Forms.TextBox()
        Me.txtPortalUsername = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMobileNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDeleteNote = New System.Windows.Forms.Button()
        Me.btnAddNote = New System.Windows.Forms.Button()
        Me.dgNotes = New System.Windows.Forms.DataGrid()
        Me.txtEID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpContact.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContact
        '
        Me.grpContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContact.Controls.Add(Me.txtEID)
        Me.grpContact.Controls.Add(Me.Label7)
        Me.grpContact.Controls.Add(Me.cboSalutation)
        Me.grpContact.Controls.Add(Me.Label6)
        Me.grpContact.Controls.Add(Me.chkPortalGSRPrint)
        Me.grpContact.Controls.Add(Me.txtPortalPassword)
        Me.grpContact.Controls.Add(Me.txtPortalUsername)
        Me.grpContact.Controls.Add(Me.Label3)
        Me.grpContact.Controls.Add(Me.Label2)
        Me.grpContact.Controls.Add(Me.txtMobileNo)
        Me.grpContact.Controls.Add(Me.Label1)
        Me.grpContact.Controls.Add(Me.txtFirstName)
        Me.grpContact.Controls.Add(Me.lblFirstName)
        Me.grpContact.Controls.Add(Me.txtSurname)
        Me.grpContact.Controls.Add(Me.lblSurname)
        Me.grpContact.Controls.Add(Me.txtTelephoneNum)
        Me.grpContact.Controls.Add(Me.lblTelephoneNum)
        Me.grpContact.Controls.Add(Me.txtEmailAddress)
        Me.grpContact.Controls.Add(Me.lblEmailAddress)
        Me.grpContact.Controls.Add(Me.txtFaxNum)
        Me.grpContact.Controls.Add(Me.lblFaxNum)
        Me.grpContact.Location = New System.Drawing.Point(7, 7)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(655, 367)
        Me.grpContact.TabIndex = 1
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Main Details"
        '
        'cboSalutation
        '
        Me.cboSalutation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSalutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalutation.Location = New System.Drawing.Point(112, 29)
        Me.cboSalutation.Name = "cboSalutation"
        Me.cboSalutation.Size = New System.Drawing.Size(83, 21)
        Me.cboSalutation.TabIndex = 55
        Me.cboSalutation.Tag = "Site.RegionID"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Salutation"
        '
        'chkPortalGSRPrint
        '
        Me.chkPortalGSRPrint.AutoSize = True
        Me.chkPortalGSRPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPortalGSRPrint.Location = New System.Drawing.Point(9, 337)
        Me.chkPortalGSRPrint.Name = "chkPortalGSRPrint"
        Me.chkPortalGSRPrint.Size = New System.Drawing.Size(118, 17)
        Me.chkPortalGSRPrint.TabIndex = 37
        Me.chkPortalGSRPrint.Text = "Portal GSR Print"
        Me.chkPortalGSRPrint.UseVisualStyleBackColor = True
        '
        'txtPortalPassword
        '
        Me.txtPortalPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPortalPassword.Location = New System.Drawing.Point(112, 279)
        Me.txtPortalPassword.MaxLength = 20
        Me.txtPortalPassword.Name = "txtPortalPassword"
        Me.txtPortalPassword.Size = New System.Drawing.Size(529, 21)
        Me.txtPortalPassword.TabIndex = 8
        Me.txtPortalPassword.Tag = ""
        '
        'txtPortalUsername
        '
        Me.txtPortalUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPortalUsername.Location = New System.Drawing.Point(112, 250)
        Me.txtPortalUsername.MaxLength = 20
        Me.txtPortalUsername.Name = "txtPortalUsername"
        Me.txtPortalUsername.Size = New System.Drawing.Size(529, 21)
        Me.txtPortalUsername.TabIndex = 7
        Me.txtPortalUsername.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 278)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Portal Password"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Portal Username"
        '
        'txtMobileNo
        '
        Me.txtMobileNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobileNo.Location = New System.Drawing.Point(112, 157)
        Me.txtMobileNo.MaxLength = 20
        Me.txtMobileNo.Name = "txtMobileNo"
        Me.txtMobileNo.Size = New System.Drawing.Size(529, 21)
        Me.txtMobileNo.TabIndex = 4
        Me.txtMobileNo.Tag = "Contact.MobileNo"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Mobile No"
        '
        'txtFirstName
        '
        Me.txtFirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.Location = New System.Drawing.Point(112, 64)
        Me.txtFirstName.MaxLength = 255
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(529, 21)
        Me.txtFirstName.TabIndex = 1
        Me.txtFirstName.Tag = "Contact.FirstName"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(8, 62)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(109, 20)
        Me.lblFirstName.TabIndex = 31
        Me.lblFirstName.Text = "First Name"
        '
        'txtSurname
        '
        Me.txtSurname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSurname.Location = New System.Drawing.Point(112, 95)
        Me.txtSurname.MaxLength = 255
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(529, 21)
        Me.txtSurname.TabIndex = 2
        Me.txtSurname.Tag = "Contact.Surname"
        '
        'lblSurname
        '
        Me.lblSurname.Location = New System.Drawing.Point(8, 93)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(109, 20)
        Me.lblSurname.TabIndex = 31
        Me.lblSurname.Text = "Surname"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(112, 126)
        Me.txtTelephoneNum.MaxLength = 20
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(529, 21)
        Me.txtTelephoneNum.TabIndex = 3
        Me.txtTelephoneNum.Tag = "Contact.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(8, 124)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(109, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(112, 188)
        Me.txtEmailAddress.MaxLength = 50
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(529, 21)
        Me.txtEmailAddress.TabIndex = 5
        Me.txtEmailAddress.Tag = "Contact.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(8, 186)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(109, 20)
        Me.lblEmailAddress.TabIndex = 31
        Me.lblEmailAddress.Text = "Email Address"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(112, 219)
        Me.txtFaxNum.MaxLength = 20
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(529, 21)
        Me.txtFaxNum.TabIndex = 6
        Me.txtFaxNum.Tag = "Contact.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(8, 217)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(109, 20)
        Me.lblFaxNum.TabIndex = 31
        Me.lblFaxNum.Text = "Fax"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnDeleteNote)
        Me.GroupBox1.Controls.Add(Me.btnAddNote)
        Me.GroupBox1.Controls.Add(Me.dgNotes)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 387)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(653, 231)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Notes"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "=Active Reminder Set"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightGreen
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 17)
        Me.Label4.TabIndex = 12
        '
        'btnDeleteNote
        '
        Me.btnDeleteNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteNote.Location = New System.Drawing.Point(584, 196)
        Me.btnDeleteNote.Name = "btnDeleteNote"
        Me.btnDeleteNote.Size = New System.Drawing.Size(56, 23)
        Me.btnDeleteNote.TabIndex = 11
        Me.btnDeleteNote.Text = "Delete"
        '
        'btnAddNote
        '
        Me.btnAddNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNote.Location = New System.Drawing.Point(10, 196)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(54, 23)
        Me.btnAddNote.TabIndex = 10
        Me.btnAddNote.Text = "Add"
        '
        'dgNotes
        '
        Me.dgNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgNotes.DataMember = ""
        Me.dgNotes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNotes.Location = New System.Drawing.Point(8, 32)
        Me.dgNotes.Name = "dgNotes"
        Me.dgNotes.Size = New System.Drawing.Size(637, 164)
        Me.dgNotes.TabIndex = 9
        '
        'txtEID
        '
        Me.txtEID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEID.Location = New System.Drawing.Point(112, 308)
        Me.txtEID.MaxLength = 20
        Me.txtEID.Name = "txtEID"
        Me.txtEID.Size = New System.Drawing.Size(529, 21)
        Me.txtEID.TabIndex = 56
        Me.txtEID.Tag = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Portal EID "
        '
        'UCContact
        '
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpContact)
        Me.Name = "UCContact"
        Me.Size = New System.Drawing.Size(667, 624)
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupNotesDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentContact
        End Get
    End Property

#End Region

#Region "Properties"

    Private _SiteID As Integer = 0

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentContact As Entity.Contacts.Contact

    Public Property CurrentContact() As Entity.Contacts.Contact
        Get
            Return _currentContact
        End Get
        Set(ByVal Value As Entity.Contacts.Contact)
            _currentContact = Value

            If CurrentContact Is Nothing Then
                CurrentContact = New Entity.Contacts.Contact
                CurrentContact.Exists = False
            End If

            If CurrentContact.Exists Then
                btnAddNote.Enabled = True
                btnDeleteNote.Enabled = True
                Populate()
            Else
                btnAddNote.Enabled = False
                btnDeleteNote.Enabled = False
            End If
        End Set
    End Property

    Private _NotesTable As DataView = Nothing

    Public Property NotesDataView() As DataView
        Get
            Return _NotesTable
        End Get
        Set(ByVal Value As DataView)
            _NotesTable = Value
            _NotesTable.Table.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
            _NotesTable.AllowNew = False
            _NotesTable.AllowEdit = False
            _NotesTable.AllowDelete = False
            Me.dgNotes.DataSource = NotesDataView
        End Set
    End Property

    Private ReadOnly Property SelectedNoteDataRow() As DataRow
        Get
            If Not Me.dgNotes.CurrentRowIndex = -1 Then
                Return NotesDataView(Me.dgNotes.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupNotesDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgNotes)
        Dim tStyle As DataGridTableStyle = Me.dgNotes.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        Dim ReminderSet As New ActiveReminderColourColumn
        ReminderSet.HeaderText = ""
        ReminderSet.MappingName = "ReminderStatusID"
        ReminderSet.ReadOnly = True
        ReminderSet.Width = 20
        ReminderSet.NullText = ""
        tStyle.GridColumnStyles.Add(ReminderSet)

        Dim NoteDate As New DataGridLabelColumn
        NoteDate.Format = "dd/MM/yyyy HH:mm"
        NoteDate.FormatInfo = Nothing
        NoteDate.HeaderText = "Date"
        NoteDate.MappingName = "NoteDate"
        NoteDate.ReadOnly = True
        NoteDate.Width = 110
        NoteDate.NullText = ""
        tStyle.GridColumnStyles.Add(NoteDate)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 120
        Category.NullText = ""
        tStyle.GridColumnStyles.Add(Category)

        Dim Note As New DataGridLabelColumn
        Note.Format = ""
        Note.FormatInfo = Nothing
        Note.HeaderText = "Note"
        Note.MappingName = "Note"
        Note.ReadOnly = True
        Note.Width = 130
        Note.NullText = ""
        tStyle.GridColumnStyles.Add(Note)

        Dim EnteredBy As New DataGridLabelColumn
        EnteredBy.Format = ""
        EnteredBy.FormatInfo = Nothing
        EnteredBy.HeaderText = "Entered By"
        EnteredBy.MappingName = "EnteredBy"
        EnteredBy.ReadOnly = True
        EnteredBy.Width = 150
        EnteredBy.NullText = ""
        tStyle.GridColumnStyles.Add(EnteredBy)

        Dim EnteredOn As New DataGridLabelColumn
        EnteredOn.Format = "dd/MM/yyyy HH:mm"
        EnteredOn.FormatInfo = Nothing
        EnteredOn.HeaderText = "Entered On"
        EnteredOn.MappingName = "DateCreated"
        EnteredOn.ReadOnly = True
        EnteredOn.Width = 110
        EnteredOn.NullText = ""
        tStyle.GridColumnStyles.Add(EnteredOn)

        Dim UserFor As New DataGridLabelColumn
        UserFor.Format = ""
        UserFor.FormatInfo = Nothing
        UserFor.HeaderText = "For User"
        UserFor.MappingName = "UserFor"
        UserFor.ReadOnly = True
        UserFor.Width = 150
        UserFor.NullText = ""
        tStyle.GridColumnStyles.Add(UserFor)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblNotes.ToString
        Me.dgNotes.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCContact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgNotes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgNotes.DoubleClick
        If SelectedNoteDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMNotes), True, New Object() {SelectedNoteDataRow("NoteID"), CurrentContact.ContactID, Me})
    End Sub

    Private Sub btnAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNote.Click
        ShowForm(GetType(FRMNotes), True, New Object() {0, CurrentContact.ContactID, Me})
        NotesDataView = DB.Notes.NotesForContact(CurrentContact.ContactID)
    End Sub

    Private Sub btnDeleteNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteNote.Click
        If SelectedNoteDataRow Is Nothing Then
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.Notes.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedNoteDataRow.Item("NoteID")))
        NotesDataView = DB.Notes.NotesForContact(CurrentContact.ContactID)

    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentContact = DB.Contact.Contact_Get(ID)
        End If

        Combo.SetSelectedComboItem_By_Value(cboSalutation, CurrentContact.Salutation)
        Me.txtFirstName.Text = CurrentContact.FirstName
        Me.txtSurname.Text = CurrentContact.Surname
        Me.txtTelephoneNum.Text = CurrentContact.TelephoneNum
        Me.txtEmailAddress.Text = CurrentContact.EmailAddress
        Me.txtFaxNum.Text = CurrentContact.FaxNum
        Me.txtMobileNo.Text = CurrentContact.MobileNo
        Me.txtPortalUsername.Text = CurrentContact.PortalUserName
        Me.txtPortalPassword.Text = CurrentContact.PortalPassword
        Me.chkPortalGSRPrint.Checked = CurrentContact.PortalGSRPrint
        Me.txtEID.Text = CurrentContact.EID

        NotesDataView = DB.Notes.NotesForContact(CurrentContact.ContactID)
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentContact.IgnoreExceptionsOnSetMethods = True

            CurrentContact.SetPropertyID = SiteID
            CurrentContact.SetSalutation = Combo.GetSelectedItemValue(cboSalutation)
            CurrentContact.SetFirstName = Me.txtFirstName.Text.Trim
            CurrentContact.SetSurname = Me.txtSurname.Text.Trim
            CurrentContact.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentContact.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentContact.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentContact.SetMobileNo = Me.txtMobileNo.Text.Trim
            CurrentContact.SetPortalPassword = Me.txtPortalPassword.Text.Trim
            CurrentContact.SetPortalUserName = Me.txtPortalUsername.Text.Trim
            CurrentContact.SetPortalGSRPrint = Me.chkPortalGSRPrint.Checked

            If Me.txtEID.Text = "" Or Not IsNumeric(Me.txtEID.Text) Then Me.txtEID.Text = 0

            CurrentContact.SetEID = Me.txtEID.Text

            If CurrentContact.Exists Then
                DB.Contact.Update(CurrentContact)
            Else
                CurrentContact = DB.Contact.Insert(CurrentContact)
            End If

            RaiseEvent StateChanged(CurrentContact.ContactID)

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

End Class