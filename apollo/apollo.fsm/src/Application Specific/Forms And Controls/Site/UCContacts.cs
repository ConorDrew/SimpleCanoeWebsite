using System;
using System.Data;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class UCContacts : UCBase, IUserControl
    {
        public UCContacts()
        {
            InitializeComponent();
        }

        public UCContacts(Entity.Sites.Site oSite)
        {
            // This call is required by the designer.
            InitializeComponent();
            CurrentSite = oSite;
            var argc = cboTitle;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cboRelationship;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Relationship).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);

            // Add any initialization after the InitializeComponent() call.
        }

        ~UCContacts()
        {
        }

        

        private void UCSite_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            SetupSiteContactsDataGrid();
            PopulateSiteContactsDataGrid();
        }

        public void Populate(int ID = 0)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        
        
        private Entity.Sites.Site _osite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _osite;
            }

            set
            {
                _osite = value;
            }
        }

        private Entity.Contacts.Contact _oContact;

        public Entity.Contacts.Contact CurrentContact
        {
            get
            {
                return _oContact;
            }

            set
            {
                _oContact = value;
                if (CurrentContact is null)
                {
                    CurrentContact = new Entity.Contacts.Contact();
                    CurrentContact.Exists = false;
                }

                if (CurrentContact.Exists)
                {
                    var argcombo = cboTitle;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContact.Salutation);
                    txtFirstName.Text = CurrentContact.FirstName;
                    txtLastname.Text = CurrentContact.Surname;
                    txtMobileNumber.Text = CurrentContact.MobileNo;
                    txtEmailAddress.Text = CurrentContact.EmailAddress;
                    txtAddress1.Text = CurrentContact.Address1;
                    txtAddress2.Text = CurrentContact.Address2;
                    txtAddress3.Text = CurrentContact.Address3;
                    txtPostcode.Text = CurrentContact.Postcode;
                    chkNoMarketing.Checked = Helper.MakeBooleanValid(CurrentContact.NoMarketing);
                    chkOnContract.Checked = Helper.MakeBooleanValid(CurrentContact.OnContract);
                    var argcombo1 = cboRelationship;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentContact.RelationshipID.ToString());
                    chkIsPOC.Checked = Helper.MakeBooleanValid(CurrentContact.PointOfContact);
                }
            }
        }

        private DataView _dvSiteContacts = null;

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public DataView SiteContactsDataView
        {
            get
            {
                return _dvSiteContacts;
            }

            set
            {
                _dvSiteContacts = value;
                _dvSiteContacts.AllowNew = false;
                _dvSiteContacts.AllowEdit = false;
                _dvSiteContacts.AllowDelete = false;
                _dvSiteContacts.Table.TableName = Enums.TableNames.tblContact.ToString();
                dgSiteContacts.DataSource = SiteContactsDataView;
            }
        }

        private DataRow SelectedSiteContactDataRow
        {
            get
            {
                if (!(dgSiteContacts.CurrentRowIndex == -1))
                {
                    return SiteContactsDataView[dgSiteContacts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public object LoadedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        
        

        public void SetupSiteContactsDataGrid()
        {
            Helper.SetUpDataGrid(dgSiteContacts);
            var tStyle = dgSiteContacts.TableStyles[0];
            var title = new DataGridLabelColumn();
            title.Format = "";
            title.FormatInfo = null;
            title.HeaderText = "Title";
            title.MappingName = "Title";
            title.ReadOnly = true;
            title.Width = 60;
            title.NullText = "";
            tStyle.GridColumnStyles.Add(title);
            var firstname = new DataGridLabelColumn();
            firstname.Format = "";
            firstname.FormatInfo = null;
            firstname.HeaderText = "First Name";
            firstname.MappingName = "FirstName";
            firstname.ReadOnly = true;
            firstname.Width = 100;
            firstname.NullText = "";
            tStyle.GridColumnStyles.Add(firstname);
            var lastname = new DataGridLabelColumn();
            lastname.Format = "";
            lastname.FormatInfo = null;
            lastname.HeaderText = "Last Name";
            lastname.MappingName = "LastName";
            lastname.ReadOnly = true;
            lastname.Width = 100;
            lastname.NullText = "";
            tStyle.GridColumnStyles.Add(lastname);
            var Email = new DataGridLabelColumn();
            Email.Format = "";
            Email.FormatInfo = null;
            Email.HeaderText = "Email";
            Email.MappingName = "EmailAddress";
            Email.ReadOnly = true;
            Email.Width = 180;
            Email.NullText = "";
            tStyle.GridColumnStyles.Add(Email);
            var mobile = new DataGridLabelColumn();
            mobile.Format = "";
            mobile.FormatInfo = null;
            mobile.HeaderText = "Mobile";
            mobile.MappingName = "mobileNo";
            mobile.ReadOnly = true;
            mobile.Width = 100;
            mobile.NullText = "";
            tStyle.GridColumnStyles.Add(mobile);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 100;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 100;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 100;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 100;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            var relationship = new DataGridLabelColumn();
            relationship.Format = "";
            relationship.FormatInfo = null;
            relationship.HeaderText = "Relationship To Tennent";
            relationship.MappingName = "Relationship";
            relationship.ReadOnly = true;
            relationship.Width = 150;
            relationship.NullText = "";
            tStyle.GridColumnStyles.Add(relationship);
            var noMarketing = new DataGridLabelColumn();
            noMarketing.Format = "";
            noMarketing.FormatInfo = null;
            noMarketing.HeaderText = "No Marketing";
            noMarketing.MappingName = "NoMarketing";
            noMarketing.ReadOnly = true;
            noMarketing.Width = 90;
            noMarketing.NullText = "";
            tStyle.GridColumnStyles.Add(noMarketing);
            var onContract = new DataGridLabelColumn();
            onContract.Format = "";
            onContract.FormatInfo = null;
            onContract.HeaderText = "On Contract";
            onContract.MappingName = "OnContract";
            onContract.ReadOnly = true;
            onContract.Width = 80;
            onContract.NullText = "";
            tStyle.GridColumnStyles.Add(onContract);
            var pointOfContact = new DataGridLabelColumn();
            pointOfContact.Format = "";
            pointOfContact.FormatInfo = null;
            pointOfContact.HeaderText = "Point Of Contact";
            pointOfContact.MappingName = "POC";
            pointOfContact.ReadOnly = true;
            pointOfContact.Width = 105;
            pointOfContact.NullText = "";
            tStyle.GridColumnStyles.Add(pointOfContact);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContact.ToString();
            dgSiteContacts.TableStyles.Add(tStyle);
        }

        
        

        private void PopulateSiteContactsDataGrid()
        {
            try
            {
                SiteContactsDataView = App.DB.Contact.Contacts_GetAll_ForLink(Helper.MakeIntegerValid(Enums.TableNames.tblSite), CurrentSite.SiteID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            CurrentContact = null;
            var argcombo = cboTitle;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            txtFirstName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            chkNoMarketing.Checked = false;
            chkOnContract.Checked = false;
            var argcombo1 = cboRelationship;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            chkIsPOC.Checked = false;
            btnSaveContact.Text = "Save";
        }

        
        

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CurrentContact is null)
                    CurrentContact = new Entity.Contacts.Contact();
                if (chkIsPOC.Checked)
                {
                    foreach (DataRowView contact in SiteContactsDataView)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(contact["POC"], true, false)) && Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(contact["ContactID"], CurrentContact.ContactID, false)))
                        {
                            if (App.ShowMessage("Another contact is currently set as point of contact, do you wish to change it to this contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                var tmpContact = App.DB.Contact.Contacts_Get(Conversions.ToInteger(contact["ContactID"]));
                                tmpContact.SetPointOfContact = false;
                                App.DB.Contact.Contacts_Update(tmpContact);
                            }
                            else
                            {
                                chkIsPOC.Checked = false;
                            }
                        }
                    }
                }

                {
                    var withBlock = CurrentContact;
                    withBlock.SetSalutation = Combo.get_GetSelectedItemDescription(cboTitle);
                    withBlock.SetFirstName = Helper.MakeStringValid(txtFirstName.Text);
                    withBlock.SetSurname = Helper.MakeStringValid(txtLastname.Text);
                    withBlock.SetMobileNo = Helper.MakeStringValid(txtMobileNumber.Text);
                    withBlock.SetEmailAddress = Helper.MakeStringValid(txtEmailAddress.Text);
                    withBlock.SetAddress1 = Helper.MakeStringValid(txtAddress1.Text);
                    withBlock.SetAddress2 = Helper.MakeStringValid(txtAddress2.Text);
                    withBlock.SetAddress3 = Helper.MakeStringValid(txtAddress3.Text);
                    withBlock.SetPostcode = Helper.FormatPostcode(txtPostcode.Text);
                    withBlock.SetNoMarketing = chkNoMarketing.Checked;
                    withBlock.SetLinkID = Helper.MakeIntegerValid(Enums.TableNames.tblSite);
                    withBlock.SetLinkRef = CurrentSite.SiteID;
                    withBlock.SetOnContract = chkOnContract.Checked;
                    withBlock.SetRelationshipID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRelationship));
                    withBlock.SetPointOfContact = chkIsPOC.Checked;
                }

                var cv = new Entity.Contacts.ContactValidator();
                cv.Validate(CurrentContact);
                App.DB.Contact.Contacts_Update(CurrentContact);
                PopulateSiteContactsDataGrid();
                Clear();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage(Conversions.ToString("Remove " + SelectedSiteContactDataRow["FirstName"] + "?" + Constants.vbCrLf + Constants.vbCrLf + "Are you sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int contactId = Helper.MakeIntegerValid(SelectedSiteContactDataRow["ContactID"]);
            try
            {
                App.DB.Contact.Contacts_Delete(contactId);
                PopulateSiteContactsDataGrid();
                FileSystem.Reset();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSiteContacts_Click(object sender, EventArgs e)
        {
            if (SelectedSiteContactDataRow is null)
            {
                return;
            }

            CurrentContact = App.DB.Contact.Contacts_Get(Conversions.ToInteger(SelectedSiteContactDataRow["ContactID"]));
            btnSaveContact.Text = "Update";
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            Clear();
        }

        
    }
}