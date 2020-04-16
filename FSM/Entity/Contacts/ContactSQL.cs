// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Contacts.ContactSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Contacts
{
    public class ContactSQL
    {
        private Database _database;

        public ContactSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int ContactID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)ContactID, true);
            this._database.ExecuteSP_NO_Return("Contact_Delete", true);
        }

        public Contact Insert(Contact oContact)
        {
            this._database.ClearParameter();
            this.AddContactParametersToCommand(ref oContact);
            oContact.SetContactID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Contact_Insert", true)));
            oContact.Exists = true;
            return oContact;
        }

        public DataView Contact_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Contact_Search), true);
            table.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(table);
        }

        public void Update(Contact oContact)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)oContact.ContactID, true);
            this.AddContactParametersToCommand(ref oContact);
            this._database.ExecuteSP_NO_Return("Contact_Update", true);
        }

        public DataView Contact_GetForSite(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Contact_GetForSite), true);
            table.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(table);
        }

        public DataView Contact_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Contact_GetAll), true);
            table.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(table);
        }

        public Contact Contact_Get(int ContactID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)ContactID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Contact_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Contact)null;
            Contact contact1 = new Contact();
            Contact contact2 = contact1;
            contact2.IgnoreExceptionsOnSetMethods = true;
            contact2.SetContactID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(ContactID)]);
            contact2.SetSalutation = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Salutation"]);
            contact2.SetFirstName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstName"]);
            contact2.SetSurname = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Surname"]);
            contact2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
            contact2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
            contact2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
            contact2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            contact2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            contact2.SetMobileNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MobileNo"]);
            contact2.SetPortalUserName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PortalUserName"]);
            contact2.SetPortalPassword = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PortalPassword"]);
            contact2.SetPortalGSRPrint = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PortalGSRPrint"]);
            contact2.SetEID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EID"]);
            contact1.Exists = true;
            return contact1;
        }

        public bool Check_Unique_PortalUsername(string username, int ID)
        {
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(Contactid) as 'NumberOfUsers' FROM tblContact WHERE portalusername = '" + username + "' AND contactid <> " + Conversions.ToString(ID) + " AND PortalUserName IS NOT NULL", false, false))) == 0;
        }

        private void AddContactParametersToCommand(ref Contact oContact)
        {
            Database database = this._database;
            database.AddParameter("@FirstName", (object)oContact.FirstName, true);
            database.AddParameter("@Salutation", (object)oContact.Salutation, true);
            database.AddParameter("@Surname", (object)oContact.Surname, true);
            database.AddParameter("@TelephoneNum", (object)oContact.TelephoneNum, true);
            database.AddParameter("@EmailAddress", (object)oContact.EmailAddress, true);
            database.AddParameter("@FaxNum", (object)oContact.FaxNum, true);
            database.AddParameter("@SiteID", (object)oContact.PropertyID, true);
            database.AddParameter("@MobileNo", (object)oContact.MobileNo, true);
            if ((uint)oContact.PortalUserName.Trim().Length > 0U)
                database.AddParameter("@PortalUserName", (object)oContact.PortalUserName, true);
            if ((uint)oContact.PortalPassword.Trim().Length > 0U)
                database.AddParameter("@PortalPassword", (object)oContact.PortalPassword, true);
            database.AddParameter("@PortalGSRPrint", (object)oContact.PortalGSRPrint, true);
            if ((uint)oContact.EID > 0U)
                database.AddParameter("@EID", (object)oContact.EID, true);
        }

        public DataView Contacts_GetAll_ForLink(int linkId, int linkRef, bool deleted = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LinkRef", (object)linkRef, true);
            this._database.AddParameter("@LinkID", (object)linkId, true);
            this._database.AddParameter("@Deleted", (object)deleted, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Contacts_GetAll_ForLink), true);
            table.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(table);
        }

        public Contact Contacts_Get(int contactId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)contactId, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Contacts_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Contact)null;
            Contact contact1 = new Contact();
            Contact contact2 = contact1;
            contact2.IgnoreExceptionsOnSetMethods = true;
            if (dataTable.Columns.Contains("ContactID"))
                contact2.SetContactID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContactID"]);
            if (dataTable.Columns.Contains("Title"))
                contact2.SetSalutation = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Title"]);
            if (dataTable.Columns.Contains("FirstName"))
                contact2.SetFirstName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstName"]);
            if (dataTable.Columns.Contains("LastName"))
                contact2.SetSurname = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastName"]);
            if (dataTable.Columns.Contains("Address1"))
                contact2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
            if (dataTable.Columns.Contains("Address2"))
                contact2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
            if (dataTable.Columns.Contains("Address3"))
                contact2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
            if (dataTable.Columns.Contains("Postcode"))
                contact2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
            if (dataTable.Columns.Contains("EmailAddress"))
                contact2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
            if (dataTable.Columns.Contains("TelephoneNo"))
                contact2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNo"]);
            if (dataTable.Columns.Contains("MobileNo"))
                contact2.SetMobileNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MobileNo"]);
            if (dataTable.Columns.Contains("LinkID"))
                contact2.SetLinkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LinkID"]);
            if (dataTable.Columns.Contains("LinkRef"))
                contact2.SetLinkRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LinkRef"]);
            if (dataTable.Columns.Contains("NoMarketing"))
                contact2.SetNoMarketing = Conversions.ToBoolean(dataTable.Rows[0]["NoMarketing"]);
            if (dataTable.Columns.Contains("OnContract"))
                contact2.SetOnContract = Conversions.ToBoolean(dataTable.Rows[0]["OnContract"]);
            if (dataTable.Columns.Contains("RelationshipID"))
                contact2.SetRelationshipID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RelationshipID"]));
            if (dataTable.Columns.Contains("POC"))
                contact2.SetPointOfContact = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]));
            if (dataTable.Columns.Contains("Relationship"))
                contact2.SetRelationship = Conversions.ToInteger(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Relationship"])));
            if (dataTable.Columns.Contains("Deleted"))
                contact2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            contact1.Exists = true;
            return contact1;
        }

        public int Contacts_Update(Contact oContact)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)oContact.ContactID, true);
            this._database.AddParameter("@Title", (object)oContact.Salutation, true);
            this._database.AddParameter("@FirstName", (object)oContact.FirstName, true);
            this._database.AddParameter("@LastName", (object)oContact.Surname, true);
            this._database.AddParameter("@TelephoneNo", (object)oContact.TelephoneNum, true);
            this._database.AddParameter("@MobileNo", (object)oContact.MobileNo, true);
            this._database.AddParameter("@Address1", (object)oContact.Address1, true);
            this._database.AddParameter("@Address2", (object)oContact.Address2, true);
            this._database.AddParameter("@Address3", (object)oContact.Address3, true);
            this._database.AddParameter("@Postcode", (object)oContact.Postcode, true);
            this._database.AddParameter("@EmailAddress", (object)oContact.EmailAddress, true);
            this._database.AddParameter("@NoMarketing", (object)oContact.NoMarketing, true);
            this._database.AddParameter("@LinkID", (object)oContact.LinkID, true);
            this._database.AddParameter("@LinkRef", (object)oContact.LinkRef, true);
            this._database.AddParameter("@OnContract", (object)oContact.OnContract, true);
            this._database.AddParameter("@RelationshipID", (object)oContact.RelationshipID, true);
            this._database.AddParameter("@POC", (object)oContact.PointOfContact, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(Contacts_Update), true)));
        }

        public bool Contacts_Delete(int contactId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactID", (object)contactId, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(Contacts_Delete)) == 1;
        }
    }
}