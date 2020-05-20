using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Contacts
    {
        public class ContactSQL
        {
            private Sys.Database _database;

            public ContactSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int ContactID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", ContactID, true);
                _database.ExecuteSP_NO_Return("Contact_Delete");
            }

            public Contact Insert(Contact oContact)
            {
                _database.ClearParameter();
                AddContactParametersToCommand(ref oContact);
                oContact.SetContactID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Contact_Insert"));
                oContact.Exists = true;
                return oContact;
            }

            public void Update(Contact oContact)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", oContact.ContactID, true);
                AddContactParametersToCommand(ref oContact);
                _database.ExecuteSP_NO_Return("Contact_Update");
            }

            public DataView Contact_GetForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("Contact_GetForSite");
                dt.TableName = Sys.Enums.TableNames.tblContact.ToString();
                return new DataView(dt);
            }

            public DataView Contact_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Contact_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContact.ToString();
                return new DataView(dt);
            }

            public Contact Contact_Get(int ContactID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", ContactID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Contact_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContact = new Contact();
                        oContact.IgnoreExceptionsOnSetMethods = true;
                        oContact.SetContactID = dt.Rows[0]["ContactID"];
                        oContact.SetSalutation = dt.Rows[0]["Salutation"];
                        oContact.SetFirstName = dt.Rows[0]["FirstName"];
                        oContact.SetSurname = dt.Rows[0]["Surname"];
                        oContact.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oContact.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oContact.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oContact.SetPropertyID = dt.Rows[0]["SiteID"];
                        oContact.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContact.SetMobileNo = dt.Rows[0]["MobileNo"];
                        oContact.SetPortalUserName = dt.Rows[0]["PortalUserName"];
                        oContact.SetPortalPassword = dt.Rows[0]["PortalPassword"];
                        oContact.SetPortalGSRPrint = dt.Rows[0]["PortalGSRPrint"];
                        oContact.SetEID = dt.Rows[0]["EID"];
                        oContact.Exists = true;
                        return oContact;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            private void AddContactParametersToCommand(ref Contact oContact)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@FirstName", oContact.FirstName, true);
                    withBlock.AddParameter("@Salutation", oContact.Salutation, true);
                    withBlock.AddParameter("@Surname", oContact.Surname, true);
                    withBlock.AddParameter("@TelephoneNum", oContact.TelephoneNum, true);
                    withBlock.AddParameter("@EmailAddress", oContact.EmailAddress, true);
                    withBlock.AddParameter("@FaxNum", oContact.FaxNum, true);
                    withBlock.AddParameter("@SiteID", oContact.PropertyID, true);
                    withBlock.AddParameter("@MobileNo", oContact.MobileNo, true);
                    if (!(oContact.PortalUserName.Trim().Length == 0))
                    {
                        withBlock.AddParameter("@PortalUserName", oContact.PortalUserName, true);
                    }

                    if (!(oContact.PortalPassword.Trim().Length == 0))
                    {
                        withBlock.AddParameter("@PortalPassword", oContact.PortalPassword, true);
                    }

                    withBlock.AddParameter("@PortalGSRPrint", oContact.PortalGSRPrint, true);
                    if (!(oContact.EID == 0))
                    {
                        withBlock.AddParameter("@EID", oContact.EID, true);
                    }
                }
            }

            public DataView Contacts_GetAll_ForLink(int linkId, int linkRef, bool deleted = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@LinkRef", linkRef, true);
                _database.AddParameter("@LinkID", linkId, true);
                _database.AddParameter("@Deleted", deleted, true);
                var dt = _database.ExecuteSP_DataTable("Contacts_GetAll_ForLink");
                dt.TableName = Sys.Enums.TableNames.tblContact.ToString();
                return new DataView(dt);
            }

            public Contact Contacts_Get(int contactId)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", contactId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Contacts_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContact = new Contact();
                        oContact.IgnoreExceptionsOnSetMethods = true;
                        if (dt.Columns.Contains("ContactID"))
                            oContact.SetContactID = dt.Rows[0]["ContactID"];
                        if (dt.Columns.Contains("Title"))
                            oContact.SetSalutation = dt.Rows[0]["Title"];
                        if (dt.Columns.Contains("FirstName"))
                            oContact.SetFirstName = dt.Rows[0]["FirstName"];
                        if (dt.Columns.Contains("LastName"))
                            oContact.SetSurname = dt.Rows[0]["LastName"];
                        if (dt.Columns.Contains("Address1"))
                            oContact.SetAddress1 = dt.Rows[0]["Address1"];
                        if (dt.Columns.Contains("Address2"))
                            oContact.SetAddress2 = dt.Rows[0]["Address2"];
                        if (dt.Columns.Contains("Address3"))
                            oContact.SetAddress3 = dt.Rows[0]["Address3"];
                        if (dt.Columns.Contains("Postcode"))
                            oContact.SetPostcode = dt.Rows[0]["Postcode"];
                        if (dt.Columns.Contains("EmailAddress"))
                            oContact.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        if (dt.Columns.Contains("TelephoneNo"))
                            oContact.SetTelephoneNum = dt.Rows[0]["TelephoneNo"];
                        if (dt.Columns.Contains("MobileNo"))
                            oContact.SetMobileNo = dt.Rows[0]["MobileNo"];
                        if (dt.Columns.Contains("LinkID"))
                            oContact.SetLinkID = dt.Rows[0]["LinkID"];
                        if (dt.Columns.Contains("LinkRef"))
                            oContact.SetLinkRef = dt.Rows[0]["LinkRef"];
                        if (dt.Columns.Contains("NoMarketing"))
                            oContact.SetNoMarketing = Conversions.ToBoolean(dt.Rows[0]["NoMarketing"]);
                        if (dt.Columns.Contains("OnContract"))
                            oContact.SetOnContract = Conversions.ToBoolean(dt.Rows[0]["OnContract"]);
                        if (dt.Columns.Contains("RelationshipID"))
                            oContact.SetRelationshipID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["RelationshipID"]);
                        if (dt.Columns.Contains("POC"))
                            oContact.SetPointOfContact = Sys.Helper.MakeBooleanValid(dt.Rows[0]["POC"]);
                        if (dt.Columns.Contains("Relationship"))
                            oContact.SetRelationship = Conversions.ToInteger(Sys.Helper.MakeStringValid(dt.Rows[0]["Relationship"]));
                        if (dt.Columns.Contains("Deleted"))
                            oContact.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContact.Exists = true;
                        return oContact;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public int Contacts_Update(Contact oContact)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", oContact.ContactID, true);
                _database.AddParameter("@Title", oContact.Salutation, true);
                _database.AddParameter("@FirstName", oContact.FirstName, true);
                _database.AddParameter("@LastName", oContact.Surname, true);
                _database.AddParameter("@TelephoneNo", oContact.TelephoneNum, true);
                _database.AddParameter("@MobileNo", oContact.MobileNo, true);
                _database.AddParameter("@Address1", oContact.Address1, true);
                _database.AddParameter("@Address2", oContact.Address2, true);
                _database.AddParameter("@Address3", oContact.Address3, true);
                _database.AddParameter("@Postcode", oContact.Postcode, true);
                _database.AddParameter("@EmailAddress", oContact.EmailAddress, true);
                _database.AddParameter("@NoMarketing", oContact.NoMarketing, true);
                _database.AddParameter("@LinkID", oContact.LinkID, true);
                _database.AddParameter("@LinkRef", oContact.LinkRef, true);
                _database.AddParameter("@OnContract", oContact.OnContract, true);
                _database.AddParameter("@RelationshipID", oContact.RelationshipID, true);
                _database.AddParameter("@POC", oContact.PointOfContact, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Contacts_Update"));
            }

            public bool Contacts_Delete(int contactId)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", contactId, true);
                return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("Contacts_Delete") == 1);
            }
        }
    }
}