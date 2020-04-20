Imports FSM.Entity.Sys

Public Class UCContacts : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal oSite As Entity.Sites.Site)

        ' This call is required by the designer.
        InitializeComponent()

        CurrentSite = oSite
        Combo.SetUpCombo(Me.cboTitle, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRelationship, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Relationship).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "Interface Methods"

    Private Sub UCSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Public Sub LoadForm(sender As Object, e As EventArgs) Implements IUserControl.LoadForm
        SetupSiteContactsDataGrid()
        PopulateSiteContactsDataGrid()
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Throw New NotImplementedException()
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Throw New NotImplementedException()
    End Function

#End Region

#Region "Properties"

    Private _osite As Entity.Sites.Site

    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _osite
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _osite = value
        End Set
    End Property

    Private _oContact As Entity.Contacts.Contact

    Public Property CurrentContact() As Entity.Contacts.Contact
        Get
            Return _oContact
        End Get
        Set(ByVal value As Entity.Contacts.Contact)
            _oContact = value

            If CurrentContact Is Nothing Then
                CurrentContact = New Entity.Contacts.Contact
                CurrentContact.Exists = False
            End If

            If CurrentContact.Exists Then
                Combo.SetSelectedComboItem_By_Value(cboTitle, CurrentContact.Salutation)
                txtFirstName.Text = CurrentContact.FirstName
                txtLastname.Text = CurrentContact.Surname
                txtMobileNumber.Text = CurrentContact.MobileNo
                txtEmailAddress.Text = CurrentContact.EmailAddress
                txtAddress1.Text = CurrentContact.Address1
                txtAddress2.Text = CurrentContact.Address2
                txtAddress3.Text = CurrentContact.Address3
                txtPostcode.Text = CurrentContact.Postcode
                chkNoMarketing.Checked = Helper.MakeBooleanValid(CurrentContact.NoMarketing)
                chkOnContract.Checked = Helper.MakeBooleanValid(CurrentContact.OnContract)
                Combo.SetSelectedComboItem_By_Value(cboRelationship, CurrentContact.RelationshipID)
                chkIsPOC.Checked = Helper.MakeBooleanValid(CurrentContact.PointOfContact)
            End If
        End Set
    End Property

    Private _dvSiteContacts As DataView = Nothing

    Public Event RecordsChanged(dv As DataView, pageIn As Enums.PageViewing, FromASave As Boolean, FromADelete As Boolean, extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(newID As Integer) Implements IUserControl.StateChanged

    Public Property SiteContactsDataView() As DataView
        Get
            Return _dvSiteContacts
        End Get
        Set(ByVal Value As DataView)
            _dvSiteContacts = Value
            _dvSiteContacts.AllowNew = False
            _dvSiteContacts.AllowEdit = False
            _dvSiteContacts.AllowDelete = False
            _dvSiteContacts.Table.TableName = Enums.TableNames.tblContact.ToString
            Me.dgSiteContacts.DataSource = SiteContactsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSiteContactDataRow() As DataRow
        Get
            If Not Me.dgSiteContacts.CurrentRowIndex = -1 Then
                Return SiteContactsDataView(Me.dgSiteContacts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property LoadedItem As Object Implements IUserControl.LoadedItem
        Get
            Throw New NotImplementedException()
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupSiteContactsDataGrid()
        Helper.SetUpDataGrid(Me.dgSiteContacts)
        Dim tStyle As DataGridTableStyle = Me.dgSiteContacts.TableStyles(0)

        Dim title As New DataGridLabelColumn
        title.Format = ""
        title.FormatInfo = Nothing
        title.HeaderText = "Title"
        title.MappingName = "Title"
        title.ReadOnly = True
        title.Width = 60
        title.NullText = ""
        tStyle.GridColumnStyles.Add(title)

        Dim firstname As New DataGridLabelColumn
        firstname.Format = ""
        firstname.FormatInfo = Nothing
        firstname.HeaderText = "First Name"
        firstname.MappingName = "FirstName"
        firstname.ReadOnly = True
        firstname.Width = 100
        firstname.NullText = ""
        tStyle.GridColumnStyles.Add(firstname)

        Dim lastname As New DataGridLabelColumn
        lastname.Format = ""
        lastname.FormatInfo = Nothing
        lastname.HeaderText = "Last Name"
        lastname.MappingName = "LastName"
        lastname.ReadOnly = True
        lastname.Width = 100
        lastname.NullText = ""
        tStyle.GridColumnStyles.Add(lastname)

        Dim Email As New DataGridLabelColumn
        Email.Format = ""
        Email.FormatInfo = Nothing
        Email.HeaderText = "Email"
        Email.MappingName = "EmailAddress"
        Email.ReadOnly = True
        Email.Width = 180
        Email.NullText = ""
        tStyle.GridColumnStyles.Add(Email)

        Dim mobile As New DataGridLabelColumn
        mobile.Format = ""
        mobile.FormatInfo = Nothing
        mobile.HeaderText = "Mobile"
        mobile.MappingName = "mobileNo"
        mobile.ReadOnly = True
        mobile.Width = 100
        mobile.NullText = ""
        tStyle.GridColumnStyles.Add(mobile)

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 100
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 100
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 100
        Address3.NullText = ""
        tStyle.GridColumnStyles.Add(Address3)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 100
        Postcode.NullText = ""
        tStyle.GridColumnStyles.Add(Postcode)

        Dim relationship As New DataGridLabelColumn
        relationship.Format = ""
        relationship.FormatInfo = Nothing
        relationship.HeaderText = "Relationship To Tennent"
        relationship.MappingName = "Relationship"
        relationship.ReadOnly = True
        relationship.Width = 150
        relationship.NullText = ""
        tStyle.GridColumnStyles.Add(relationship)

        Dim noMarketing As New DataGridLabelColumn
        noMarketing.Format = ""
        noMarketing.FormatInfo = Nothing
        noMarketing.HeaderText = "No Marketing"
        noMarketing.MappingName = "NoMarketing"
        noMarketing.ReadOnly = True
        noMarketing.Width = 90
        noMarketing.NullText = ""
        tStyle.GridColumnStyles.Add(noMarketing)

        Dim onContract As New DataGridLabelColumn
        onContract.Format = ""
        onContract.FormatInfo = Nothing
        onContract.HeaderText = "On Contract"
        onContract.MappingName = "OnContract"
        onContract.ReadOnly = True
        onContract.Width = 80
        onContract.NullText = ""
        tStyle.GridColumnStyles.Add(onContract)

        Dim pointOfContact As New DataGridLabelColumn
        pointOfContact.Format = ""
        pointOfContact.FormatInfo = Nothing
        pointOfContact.HeaderText = "Point Of Contact"
        pointOfContact.MappingName = "POC"
        pointOfContact.ReadOnly = True
        pointOfContact.Width = 105
        pointOfContact.NullText = ""
        tStyle.GridColumnStyles.Add(pointOfContact)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblContact.ToString
        Me.dgSiteContacts.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateSiteContactsDataGrid()
        Try
            SiteContactsDataView = DB.Contact.Contacts_GetAll_ForLink(Helper.MakeIntegerValid(Enums.TableNames.tblSite), CurrentSite.SiteID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Clear()
        CurrentContact = Nothing
        Combo.SetSelectedComboItem_By_Value(cboTitle, 0)
        txtFirstName.Text = String.Empty
        txtLastname.Text = String.Empty
        txtMobileNumber.Text = String.Empty
        txtEmailAddress.Text = String.Empty
        txtAddress1.Text = String.Empty
        txtAddress2.Text = String.Empty
        txtAddress3.Text = String.Empty
        txtPostcode.Text = String.Empty
        chkNoMarketing.Checked = False
        chkOnContract.Checked = False
        Combo.SetSelectedComboItem_By_Value(cboRelationship, 0)
        chkIsPOC.Checked = False
        Me.btnSaveContact.Text = "Save"
    End Sub

#End Region

#Region "Events"

    Private Sub btnSaveContact_Click(sender As Object, e As EventArgs) Handles btnSaveContact.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            If CurrentContact Is Nothing Then CurrentContact = New Entity.Contacts.Contact
            If Me.chkIsPOC.Checked Then
                For Each contact As DataRowView In SiteContactsDataView
                    If contact("POC") = True AndAlso contact("ContactID") <> CurrentContact.ContactID Then
                        If ShowMessage("Another contact is currently set as point of contact, do you wish to change it to this contact?",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            Dim tmpContact As Entity.Contacts.Contact = DB.Contact.Contacts_Get(contact("ContactID"))
                            tmpContact.SetPointOfContact = False
                            DB.Contact.Contacts_Update(tmpContact)
                        Else
                            chkIsPOC.Checked = False
                        End If
                    End If
                Next
            End If

            With CurrentContact
                .SetSalutation = Combo.GetSelectedItemDescription(cboTitle)
                .SetFirstName = Helper.MakeStringValid(txtFirstName.Text)
                .SetSurname = Helper.MakeStringValid(txtLastname.Text)
                .SetMobileNo = Helper.MakeStringValid(txtMobileNumber.Text)
                .SetEmailAddress = Helper.MakeStringValid(txtEmailAddress.Text)
                .SetAddress1 = Helper.MakeStringValid(txtAddress1.Text)
                .SetAddress2 = Helper.MakeStringValid(txtAddress2.Text)
                .SetAddress3 = Helper.MakeStringValid(txtAddress3.Text)
                .SetPostcode = Helper.FormatPostcode(txtPostcode.Text)
                .SetNoMarketing = Me.chkNoMarketing.Checked
                .SetLinkID = Helper.MakeIntegerValid(Enums.TableNames.tblSite)
                .SetLinkRef = CurrentSite.SiteID
                .SetOnContract = chkOnContract.Checked
                .SetRelationshipID = Combo.GetSelectedItemValue(cboRelationship)
                .SetPointOfContact = chkIsPOC.Checked
            End With

            Dim cv As New Entity.Contacts.ContactValidator
            cv.Validate(CurrentContact)

            DB.Contact.Contacts_Update(CurrentContact)
            PopulateSiteContactsDataGrid()
            Clear()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDeleteContact_Click(sender As Object, e As EventArgs) Handles btnDeleteContact.Click
        If ShowMessage("Remove " & SelectedSiteContactDataRow("FirstName") & "?" &
               vbCrLf & vbCrLf & "Are you sure?",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim contactId As Integer =
            Helper.MakeIntegerValid(SelectedSiteContactDataRow("ContactID"))

        Try
            DB.Contact.Contacts_Delete(contactId)
            PopulateSiteContactsDataGrid()
            Reset()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgSiteContacts_Click(sender As Object, e As EventArgs) Handles dgSiteContacts.Click
        If SelectedSiteContactDataRow Is Nothing Then
            Exit Sub
        End If
        CurrentContact = DB.Contact.Contacts_Get(SelectedSiteContactDataRow("ContactID"))
        Me.btnSaveContact.Text = "Update"
    End Sub

    Private Sub btnNewContact_Click(sender As Object, e As EventArgs) Handles btnNewContact.Click
        Clear()
    End Sub

#End Region

End Class