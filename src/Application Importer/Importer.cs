using System;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Importer
{
    public class Importer
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Entity.Sys.Database _database;

        public Importer(Entity.Sys.Database database)
        {
            _database = database;
        }

        private ArrayList _DataToImport;
        private ArrayList _arrayList;
        private FRMPartsImport _fRMImportNew;

        public Importer(ArrayList arrayList, FRMPartsImport fRMImportNew)
        {
            // TODO: Complete member initialization
            _arrayList = arrayList;
            _fRMImportNew = fRMImportNew;
        }

        public ArrayList DataToImport
        {
            get
            {
                return _DataToImport;
            }

            set
            {
                _DataToImport = value;
            }
        }

        private static Entity.Sys.TransactionalDatabase _Tdatabase;

        public Entity.Sys.TransactionalDatabase Tdatabase
        {
            get
            {
                return _Tdatabase;
            }

            set
            {
                _Tdatabase = value;
            }
        }

        private static System.Data.SqlClient.SqlTransaction _Trans;

        public System.Data.SqlClient.SqlTransaction Trans
        {
            get
            {
                return _Trans;
            }

            set
            {
                _Trans = value;
            }
        }

        private FRMImport _ImportForm;

        public FRMImport ImportForm
        {
            get
            {
                return _ImportForm;
            }

            set
            {
                _ImportForm = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public Importer(ArrayList DataToImportIn, ref FRMImport ImportFormIn)
        {
            DataToImport = DataToImportIn;
            _Tdatabase = new Entity.Sys.TransactionalDatabase();
            _Trans = null;
            ImportForm = ImportFormIn;
            ImportForm.MoveProgressOn();
        }

        public void Import(int SupplierID, int UnitTypeID, int CustomerID = 0)
        {
            double PartsImportMarkup = App.DB.Manager.Get().PartsImportMarkup;
            Trans = Tdatabase.Transaction_Get();
            try
            {
                for (int dvIndex = 0, loopTo = DataToImport.Count - 1; dvIndex <= loopTo; dvIndex++)
                {
                    DataView dv = (DataView)DataToImport[dvIndex];
                    if (dvIndex == 0 & (dv.Table.TableName ?? "") == "Parts")
                    {
                        ImportParts(dv, SupplierID, PartsImportMarkup, UnitTypeID);
                    }
                    else if (dvIndex == 0 & (dv.Table.TableName ?? "") == "Sites")
                    {
                        // ImportSites(dv, CustomerID, Combo.GetSelectedItemDescription(ImportForm.cboSourceOfCustomer), Combo.GetSelectedItemDescription(ImportForm.cboReasonForContact))
                    }
                }

                Tdatabase.Transaction_Commit(Trans);
            }
            catch (Exception ex)
            {
                Tdatabase.Transaction_Rollback(Trans);
                throw new Exception("Error Importing, all actions have been rolled back." + Constants.vbCrLf + ex.Message);
            }
        }

        public void PreImport(int SupplierID, string PartCode, string Description, string Category, string SupplierPartCode, double SupplierPrice)
        {
            Part_PreImportInsert(SupplierID, PartCode, Description, Category, SupplierPartCode, SupplierPrice);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ImportSites(DataView dvSites, int CustomerID, string SourceOfCustomer, string ReasonForContact)
        {
            var oCustomer = App.DB.Customer.Customer_Get(CustomerID);
            var oSettings = App.DB.Manager.Get();
            int ReasonForContactID = 0;
            var ReasonForContacts = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ReasonsForContact).Table.Select("Name ='" + ReasonForContact + "'");
            if (ReasonForContacts.Length > 0)
            {
                ReasonForContactID = Conversions.ToInteger(ReasonForContacts[0]["ManagerID"]);
            }

            int SourceOfCustomerID = 0;
            var SourceOfCustomers = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.SourceOfCustomer).Table.Select("Name ='" + SourceOfCustomer + "'");
            if (SourceOfCustomers.Length > 0)
            {
                SourceOfCustomerID = Conversions.ToInteger(SourceOfCustomers[0]["ManagerID"]);
            }

            for (int siteIndex = 0, loopTo = dvSites.Count - 1; siteIndex <= loopTo; siteIndex++)
            {
                var site = dvSites[siteIndex];
                var oSite = new Entity.Sites.Site();
                // If site("PolicyNumber") = "" Then
                // Else

                // Dim siteFound As DataView = GetByPolicyNumber(site("PolicyNumber"), CustomerID)
                // If siteFound.Table.Rows.Count = 0 Then
                oSite.SetAcceptChargesChanges = 1;
                oSite.SetCommercialDistrict = 0;
                oSite.SetCustomerID = CustomerID;
                oSite.SetEngineerID = 0;
                oSite.SetHeadOffice = false;
                oSite.SetNoMarketing = false;
                oSite.SetNoService = false;
                oSite.SetOnStop = false;
                oSite.SetPoNumReqd = false;
                oSite.SetReasonForContactID = ReasonForContactID;
                oSite.SetRegionID = oCustomer.RegionID;
                oSite.SetSolidFuel = false;
                oSite.SetSourceOfCustomerID = SourceOfCustomerID;
                oSite.SetCustomerID = CustomerID;
                // Else

                // Dim SiteID As Integer = siteFound.Table.Rows(0).Item("SiteID")
                // oSite = DB.Sites.Get(SiteID)

                // End If

                if (!(site["PolicyNumber"] == DBNull.Value))
                {
                    oSite.SetPolicyNumber = site["PolicyNumber"];
                }

                if (!(site["Tenant"] == DBNull.Value))
                {
                    if (Conversions.ToBoolean((Strings.Trim(Conversions.ToString(site["Tenant"])) ?? "") == "Void" | Operators.ConditionalCompareObjectEqual(site["Tenant"], "V", false)))
                    {
                        oSite.SetPropertyVoid = true;
                    }
                    else
                    {
                        oSite.SetPropertyVoid = false;
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(site["Tenant"], "L", false)))
                    {
                        oSite.SetLeaseHold = true;
                    }
                    else
                    {
                        oSite.SetLeaseHold = false;
                    }
                }

                if (!(site["Address 1"] == DBNull.Value))
                {
                    if (Strings.Len(site["Address 1"]) > 0)
                    {
                        oSite.SetAddress1 = site["Address 1"];
                    }
                    else
                    {
                        oSite.SetAddress1 = null;
                    }
                }

                if (!(site["Address 2"] == DBNull.Value))
                {
                    if (Strings.Len(site["Address 2"]) > 0)
                    {
                        oSite.SetAddress2 = Strings.Trim(Conversions.ToString(site["Address 2"]));
                    }
                    else
                    {
                        oSite.SetAddress2 = null;
                    }
                }

                if (!(site["Address 3"] == DBNull.Value))
                {
                    if (Strings.Len(site["Address 3"]) > 0)
                    {
                        oSite.SetAddress3 = Strings.Trim(Conversions.ToString(site["Address 3"]));
                    }
                    else
                    {
                        oSite.SetAddress3 = null;
                    }
                }

                if (!(site["Address 4"] == DBNull.Value))
                {
                    if (Strings.Len(site["Address 4"]) > 0)
                    {
                        oSite.SetAddress4 = Strings.Trim(Conversions.ToString(site["Address 4"]));
                    }
                    else
                    {
                        oSite.SetAddress4 = null;
                    }
                }

                if (!(site["PostCode"] == DBNull.Value))
                {
                    if (Strings.Len(site["PostCode"]) > 0)
                    {
                        oSite.SetPostcode = Strings.Replace(Entity.Sys.Helper.MakeStringValid(site["PostCode"]), " ", "-");
                        if (oSite.Postcode.Length == 0)
                        {
                            oSite.SetPostcode = "XXX-XXX";
                        }
                    }
                    else
                    {
                        oSite.SetPostcode = "XXX-XXX";
                    }
                }
                else
                {
                    oSite.SetPostcode = "XXX-XXX";
                }

                string siteName = null;
                if (!(site["Tenant"] == DBNull.Value))
                {
                    siteName = Entity.Sys.Helper.MakeStringValid(site["Tenant"]);
                    if ((Strings.Trim(siteName) ?? "") == "Void")
                    {
                        if (!(site["Address 1"] == DBNull.Value))
                        {
                            siteName = Conversions.ToString(site["Address 1"]);
                            oSite.SetName = siteName;
                        }
                    }
                    else
                    {
                        siteName = Strings.Trim(siteName);
                        oSite.SetName = siteName;
                    }
                }
                else if (!(site["Address 1"] == DBNull.Value))
                {
                    siteName = Conversions.ToString(site["Address 1"]);
                    oSite.SetName = siteName;
                }

                // If InStr(siteName, "T2") > 0 Then
                // siteName = Trim(siteName.Substring(0, InStr(siteName, "T2") - 1))
                // End If

                // oSite.SetEmailAddress = Nothing
                if (!(site["EmailAddress"] == DBNull.Value))
                {
                    if (Strings.Len(Strings.Trim(site["EmailAddress"].ToString())) > 0)
                    {
                        oSite.SetEmailAddress = Conversions.ToString(site["EmailAddress"]);
                    }
                    else
                    {
                        oSite.SetEmailAddress = null;
                    }
                }

                if (!(site["FaxNum"] == DBNull.Value))    // this is the mobile number
                {
                    if (Strings.Len(Strings.Trim(site["FaxNum"].ToString())) > 0)
                    {
                        oSite.SetFaxNum = Conversions.ToString(site["FaxNum"]);
                    }
                    else
                    {
                        oSite.SetFaxNum = null;
                    }
                }

                // oSite.SetFaxNum = Nothing
                if (!(site["TelephoneNum"] == DBNull.Value))
                {
                    if (Strings.Len(Strings.Trim(site["TelephoneNum"].ToString())) > 0)
                    {
                        oSite.SetTelephoneNum = Conversions.ToString(site["TelephoneNum"]);
                    }
                    else
                    {
                        oSite.SetTelephoneNum = 0;
                    }
                }

                if (!(site["heating type"] == DBNull.Value))
                {
                    string sitefuel = Strings.Trim(site["heating type"].ToString());
                    oSite.SetSiteFuel = sitefuel;
                }

                if (!(site["Notes"] == DBNull.Value))
                {
                    string tempNotes = Entity.Sys.Helper.MakeStringValid(site["Notes"].ToString()).Trim();
                    if (!(Entity.Sys.Helper.MakeStringValid(site["Notes"].ToString()).Trim().Length == 0))
                    {
                        tempNotes = Entity.Sys.Helper.MakeStringValid(site["Notes"].ToString()).Trim();
                        oSite.SetNotes = Strings.Trim(tempNotes);
                    }
                }

                // tempNotes = Replace(tempNotes, "T2ADVI", vbCrLf & "T2ADVI")
                // tempNotes = Replace(tempNotes, "T1WARN", vbCrLf & "T1WARN")
                // tempNotes = Replace(tempNotes, "T2WARN", vbCrLf & "T2WARN")
                if (!(site["Last Service Date"] == DBNull.Value))
                {
                    if (string.IsNullOrEmpty(site["Last Service Date"].ToString()))
                    {
                    }
                    else
                    {
                        DateTime LSDate = Conversions.ToDate(Conversions.ToString(site["Last Service Date"]));
                        oSite.LastServiceDate = LSDate;
                    }
                }

                if (oSite.Exists)
                {
                    Update_Site(oSite);
                }
                else
                {
                    oSite.SetSiteID = Insert_Site(oSite, oSettings);
                }

                if (!(site["Tenant"] == DBNull.Value))
                {
                    if ((Strings.Trim(Conversions.ToString(site["Tenant"])) ?? "") == "Void")
                    {
                    }
                    else
                    {
                        // CONTACTS
                        var oContact = new Entity.Contacts.Contact();
                        var namestring = Strings.Split(Conversions.ToString(site["Tenant"]), " ");

                        // 'DOES THE CONTACT EXIST
                        // If Entity.Sys.Helper.MakeStringValid(namestring(1)).Length > 0 Then
                        // Dim contactFound As DataView = Contact_Get_ByFirstName(namestring(1), oSite.SiteID)
                        // If contactFound.Table.Rows.Count = 0 Then
                        // oContact.SetFirstName = namestring(1)
                        // oContact.SetPropertyID = oSite.SiteID
                        // Else
                        // Dim contactID As Integer = contactFound.Table.Rows(0).Item("contactID")
                        // oContact = DB.Contact.Contact_Get(contactID)
                        // End If

                        // oContact.SetSurname = namestring(2)
                        // 'oContact.SetTelephoneNum = site("TelephoneNum")
                        // If Not site("TelephoneNum") Is DBNull.Value Then
                        // If Len(Trim(site("TelephoneNum").ToString)) > 0 Then
                        // oContact.SetTelephoneNum = CStr(site("TelephoneNum"))
                        // Else
                        // oContact.SetTelephoneNum = 0
                        // End If
                        // End If

                        // If oContact.Exists Then
                        // InsertUpdate_Contact(oContact, "Update")
                        // Else
                        // InsertUpdate_Contact(oContact, "Insert")
                        // End If
                        // End If
                    }
                }
                // End If
                ImportForm.MoveProgressOn();
                // FRMImport.Label3.Text = CStr(siteIndex)
            }
        }

        private void Part_PreImportInsert(int SupplierID, string PartCode, string Description, string Category, string SupplierPartCode, double SupplierPrice)
        {
            var cmdImportPart = _Tdatabase.CreateStoredProcedure("Part_PreImportInsert", Trans);
            cmdImportPart.Parameters.Clear();
            cmdImportPart.Parameters.AddWithValue("SupplierID", SupplierID);
            cmdImportPart.Parameters.AddWithValue("PartCode", PartCode);
            cmdImportPart.Parameters.AddWithValue("Description", Description);
            cmdImportPart.Parameters.AddWithValue("Category", Category);
            cmdImportPart.Parameters.AddWithValue("SupplierPartCode", SupplierPartCode);
            cmdImportPart.Parameters.AddWithValue("SupplierPrice", SupplierPrice);
        }

        private void ImportParts(DataView dvParts, int SupplierID, double PartsImportMarkup, int UnitTypeID)
        {
            for (int partIndex = 0, loopTo = dvParts.Count - 1; partIndex <= loopTo; partIndex++)
            {
                var row = dvParts[partIndex];
                int CategoryID = App.DB.ImportValidation.CategoryID(Conversions.ToString(row["Category"]), Trans);
                string SupplierPartCode = null;
                if (Information.IsDBNull(row["Supplier Part Code"]) || Conversions.ToString(row["Supplier Part Code"]).Length <= 0)
                {
                    SupplierPartCode = Conversions.ToString(row["Part Code"]);
                }
                else
                {
                    SupplierPartCode = Conversions.ToString(row["Supplier Part Code"]);
                }

                // ImportForm.SetLastPartAttempted(row("Part Code"))

                int partsFound = App.DB.Part.Part_Exists(Conversions.ToString(row["Part Code"]), Conversions.ToString(row["Supplier Part Code"]), Trans);

                // If partsFound.Length = 0 Then
                if (partsFound == 0)
                {
                    double sellPrice = Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Price"]) * (PartsImportMarkup / 100 + 1)), "F"));
                    if (!Information.IsDBNull(row["Sell Price"]))
                    {
                        if (row["Sell Price"].GetType() == typeof(decimal))
                        {
                            sellPrice = Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Sell Price"]), "F"));
                        }
                    }

                    string notes = "";
                    if (!Information.IsDBNull(row["Notes"]))
                    {
                        if (Conversions.ToString(row["Notes"]).Length > 0)
                        {
                            notes = Conversions.ToString(row["Notes"]);
                        }
                    }

                    int PartID = Insert_Part(Conversions.ToString(row["Part Code"]), Conversions.ToString(row["Name/Description"]), CategoryID, UnitTypeID, notes, sellPrice);
                    Insert_Part_Supplier(PartID, SupplierPartCode, SupplierID, Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Price"]), "F")), Entity.Sys.Helper.MakeIntegerValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Qty"]), "F")));
                }
                else
                {
                    bool doUpdate = false;
                    var oPart = App.DB.Part.Part_Get(partsFound, Trans);

                    // If Not IsDBNull(row("Name/Description")) Then
                    // If CStr(row("Name/Description")).Length > 0 Then
                    // oPart.SetName = row("Name/Description")
                    // doUpdate = True
                    // End If
                    // End If

                    if (!Information.IsDBNull(row["Category"]))
                    {
                        if (Conversions.ToString(row["Category"]).Length > 0)
                        {
                            oPart.SetCategoryID = CategoryID;
                            doUpdate = true;
                        }
                    }

                    if (!Information.IsDBNull(row["Notes"]))
                    {
                        if (Conversions.ToString(row["Notes"]).Length > 0)
                        {
                            oPart.SetNotes = row["Notes"];
                            doUpdate = true;
                        }
                    }

                    if (!Information.IsDBNull(row["Sell Price"]))
                    {
                        if (row["Sell Price"].GetType() == typeof(decimal))
                        {
                            oPart.SetSellPrice = Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Sell Price"]), "F"));
                            doUpdate = true;
                        }
                    }

                    if (doUpdate)
                    {
                        Update_Part(oPart);
                    }

                    DataRow[] suppliersFound = App.DB.PartSupplier.Get_ByPartID(oPart.PartID, Trans).Table.Select("SupplierID = " + SupplierID);
                    if (suppliersFound.Length == 0)
                    {
                        Insert_Part_Supplier(oPart.PartID, SupplierPartCode, SupplierID, Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Price"]), "F")), Entity.Sys.Helper.MakeIntegerValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Qty"]), "F")));
                    }
                    else
                    {
                        var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(Conversions.ToInteger((suppliersFound[0])["PartSupplierID"]), Trans);
                        bool doSupplierUpdate = false;
                        if (SupplierPartCode != default)
                        {
                            if (Conversions.ToString(SupplierPartCode).Length > 0)
                            {
                                oPartSupplier.SetPartCode = SupplierPartCode;
                                doSupplierUpdate = true;
                            }
                        }

                        if (!Information.IsDBNull(row["Supplier Qty"]))
                        {
                            if (row["Supplier Qty"].GetType() == typeof(double))
                            {
                                oPartSupplier.SetQuantityInPack = Entity.Sys.Helper.MakeIntegerValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Qty"]), "F"));
                                doSupplierUpdate = true;
                            }
                        }

                        if (!Information.IsDBNull(row["Supplier Price"]))
                        {
                            if (row["Supplier Price"].GetType() == typeof(decimal))
                            {
                                oPartSupplier.SetPrice = Entity.Sys.Helper.MakeDoubleValid(Strings.Format(Entity.Sys.Helper.MakeDoubleValid(row["Supplier Price"]), "F"));
                                doSupplierUpdate = true;
                            }
                        }

                        if (doSupplierUpdate)
                        {
                            Update_Part_Supplier(oPartSupplier);
                        }
                    }
                }

                ImportForm.MoveProgressOn();
            }
        }

        public DataView GetByPolicyNumber(string policyNumber, int customerID)
        {
            var cmdImportSite = _Tdatabase.CreateStoredProcedure("Site_GetByPolicyNumber", Trans);
            cmdImportSite.Parameters.Clear();
            cmdImportSite.Parameters.AddWithValue("@policyNumber", policyNumber);
            cmdImportSite.Parameters.AddWithValue("@customerID", customerID);
            return new DataView(_Tdatabase.ExecuteTableSPTrans(cmdImportSite));
        }

        public int Insert_Site(Entity.Sites.Site oSite, Entity.Management.Settings oSettings)
        {
            var cmdImportSite = _Tdatabase.CreateStoredProcedure("Site_Insert", Trans);
            cmdImportSite.Parameters.Clear();
            cmdImportSite.Parameters.AddWithValue("@SiteAddedByUserID", App.loggedInUser.UserID);
            cmdImportSite.Parameters.AddWithValue("@CustomerID", oSite.CustomerID);
            cmdImportSite.Parameters.AddWithValue("@Name", oSite.Name);
            cmdImportSite.Parameters.AddWithValue("@RegionID", oSite.RegionID);
            cmdImportSite.Parameters.AddWithValue("@HeadOffice", oSite.HeadOffice);
            cmdImportSite.Parameters.AddWithValue("@Notes", oSite.Notes);
            cmdImportSite.Parameters.AddWithValue("@Address1", oSite.Address1);
            cmdImportSite.Parameters.AddWithValue("@Address2", oSite.Address2);
            cmdImportSite.Parameters.AddWithValue("@Address3", oSite.Address3);
            cmdImportSite.Parameters.AddWithValue("@Address4", oSite.Address4);
            cmdImportSite.Parameters.AddWithValue("@Address5", oSite.Address5);
            cmdImportSite.Parameters.AddWithValue("@Postcode", oSite.Postcode);
            cmdImportSite.Parameters.AddWithValue("@TelephoneNum", oSite.TelephoneNum);
            cmdImportSite.Parameters.AddWithValue("@FaxNum", oSite.FaxNum);
            cmdImportSite.Parameters.AddWithValue("@EmailAddress", oSite.EmailAddress);
            cmdImportSite.Parameters.AddWithValue("@EngineerID", oSite.EngineerID);
            cmdImportSite.Parameters.AddWithValue("@PONumReqd", oSite.PoNumReqd);
            cmdImportSite.Parameters.AddWithValue("@PolicyNumber", oSite.PolicyNumber);
            cmdImportSite.Parameters.AddWithValue("@AcceptChargesChanges", oSite.AcceptChargesChanges);
            cmdImportSite.Parameters.AddWithValue("@SourceOfCustomerID", oSite.SourceOfCustomerID);
            cmdImportSite.Parameters.AddWithValue("@NoMarketing", oSite.NoMarketing);
            cmdImportSite.Parameters.AddWithValue("@ReasonForContactID", oSite.ReasonForContactID);
            cmdImportSite.Parameters.AddWithValue("@OnStop", oSite.OnStop);
            cmdImportSite.Parameters.AddWithValue("@LeaseHold", oSite.LeaseHold);
            cmdImportSite.Parameters.AddWithValue("@PropertyVoid", oSite.PropertyVoid);
            cmdImportSite.Parameters.AddWithValue("@SiteFuel", oSite.SiteFuel);
            int SiteID = _Tdatabase.ExecuteScalarSPTrans(cmdImportSite);

            // CHARGES
            var cmdImportSiteCharge = _Tdatabase.CreateStoredProcedure("SiteCharge_Insert", Trans);
            cmdImportSiteCharge.Parameters.Clear();
            cmdImportSiteCharge.Parameters.AddWithValue("@SiteID", SiteID);
            cmdImportSiteCharge.Parameters.AddWithValue("@MileageRate", oSettings.MileageRate);
            cmdImportSiteCharge.Parameters.AddWithValue("@PartsMarkup", oSettings.PartsMarkup);
            cmdImportSiteCharge.Parameters.AddWithValue("@RatesMarkup", oSettings.RatesMarkup);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSiteCharge);

            // SORS
            var cmdImportSiteSORs = _Tdatabase.CreateStoredProcedure("SiteScheduleOfRate_Insert_Defaults", Trans);
            cmdImportSiteSORs.Parameters.Clear();
            cmdImportSiteSORs.Parameters.AddWithValue("@SiteID", SiteID);
            cmdImportSiteSORs.Parameters.AddWithValue("@CustomerID", oSite.CustomerID);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSiteSORs);
            return SiteID;
        }

        public void Update_Site(Entity.Sites.Site oSite)
        {
            var cmdImportSite = _Tdatabase.CreateStoredProcedure("Site_Update", Trans);
            cmdImportSite.Parameters.Clear();
            cmdImportSite.Parameters.AddWithValue("@SiteID", oSite.SiteID);
            cmdImportSite.Parameters.AddWithValue("@CustomerID", oSite.CustomerID);
            cmdImportSite.Parameters.AddWithValue("@Name", oSite.Name);
            cmdImportSite.Parameters.AddWithValue("@RegionID", oSite.RegionID);
            cmdImportSite.Parameters.AddWithValue("@HeadOffice", oSite.HeadOffice);
            cmdImportSite.Parameters.AddWithValue("@Notes", oSite.Notes);
            cmdImportSite.Parameters.AddWithValue("@Address1", oSite.Address1);
            cmdImportSite.Parameters.AddWithValue("@Address2", oSite.Address2);
            cmdImportSite.Parameters.AddWithValue("@Address3", oSite.Address3);
            cmdImportSite.Parameters.AddWithValue("@Address4", oSite.Address4);
            cmdImportSite.Parameters.AddWithValue("@Address5", oSite.Address5);
            cmdImportSite.Parameters.AddWithValue("@Postcode", oSite.Postcode);
            cmdImportSite.Parameters.AddWithValue("@TelephoneNum", oSite.TelephoneNum);
            cmdImportSite.Parameters.AddWithValue("@FaxNum", oSite.FaxNum);
            cmdImportSite.Parameters.AddWithValue("@EmailAddress", oSite.EmailAddress);
            cmdImportSite.Parameters.AddWithValue("@EngineerID", oSite.EngineerID);
            cmdImportSite.Parameters.AddWithValue("@PONumReqd", oSite.PoNumReqd);
            cmdImportSite.Parameters.AddWithValue("@PolicyNumber", oSite.PolicyNumber);
            cmdImportSite.Parameters.AddWithValue("@AcceptChargesChanges", oSite.AcceptChargesChanges);
            cmdImportSite.Parameters.AddWithValue("@SourceOfCustomerID", oSite.SourceOfCustomerID);
            cmdImportSite.Parameters.AddWithValue("@NoMarketing", oSite.NoMarketing);
            cmdImportSite.Parameters.AddWithValue("@ReasonForContactID", oSite.ReasonForContactID);
            cmdImportSite.Parameters.AddWithValue("@OnStop", oSite.OnStop);
            cmdImportSite.Parameters.AddWithValue("@LeaseHold", oSite.LeaseHold);
            cmdImportSite.Parameters.AddWithValue("@PropertyVoid", oSite.PropertyVoid);
            cmdImportSite.Parameters.AddWithValue("@SiteFuel", oSite.SiteFuel);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSite);
        }

        public DataView Contact_Get_ByFirstName(string FirstName, int SiteID)
        {
            var cmdImportSite = _Tdatabase.CreateStoredProcedure("Contact_Get_ByFirstName", Trans);
            cmdImportSite.Parameters.Clear();
            cmdImportSite.Parameters.AddWithValue("@FirstName", FirstName);
            cmdImportSite.Parameters.AddWithValue("@SiteID", SiteID);
            return new DataView(_Tdatabase.ExecuteTableSPTrans(cmdImportSite));
        }

        public int InsertUpdate_Contact(Entity.Contacts.Contact oContact, string InsertUpdate)
        {
            System.Data.SqlClient.SqlCommand cmdImportContact;
            if ((InsertUpdate ?? "") == "Insert")
            {
                cmdImportContact = _Tdatabase.CreateStoredProcedure("Contact_Insert", Trans);
            }
            else
            {
                cmdImportContact = _Tdatabase.CreateStoredProcedure("Contact_Update", Trans);
            }

            cmdImportContact.Parameters.Clear();
            if ((InsertUpdate ?? "") != "Insert")
            {
                cmdImportContact.Parameters.AddWithValue("@ContactID", oContact.ContactID);
            }

            cmdImportContact.Parameters.AddWithValue("@FirstName", oContact.FirstName);
            cmdImportContact.Parameters.AddWithValue("@Surname", oContact.Surname);
            cmdImportContact.Parameters.AddWithValue("@TelephoneNum", oContact.TelephoneNum);
            cmdImportContact.Parameters.AddWithValue("@EmailAddress", oContact.EmailAddress);
            cmdImportContact.Parameters.AddWithValue("@FaxNum", oContact.FaxNum);
            cmdImportContact.Parameters.AddWithValue("@SiteID", oContact.PropertyID);
            cmdImportContact.Parameters.AddWithValue("@MobileNo", oContact.MobileNo);
            if (!(oContact.PortalUserName.Trim().Length == 0))
            {
                cmdImportContact.Parameters.AddWithValue("@PortalUserName", oContact.PortalUserName);
            }

            if (!(oContact.PortalPassword.Trim().Length == 0))
            {
                cmdImportContact.Parameters.AddWithValue("@PortalPassword", oContact.PortalPassword);
            }

            return _Tdatabase.ExecuteScalarSPTrans(cmdImportContact);
        }

        public int Insert_Part(string Number, string Name, int CategoryID, int UnitTypeID, string Notes, double SellPrice)
        {
            var cmdImportPart = _Tdatabase.CreateStoredProcedure("Part_Insert", Trans);
            cmdImportPart.Parameters.Clear();
            cmdImportPart.Parameters.AddWithValue("@Name", Name);
            cmdImportPart.Parameters.AddWithValue("@Number", Number);
            cmdImportPart.Parameters.AddWithValue("@Reference", "");
            cmdImportPart.Parameters.AddWithValue("@Notes", Notes);
            cmdImportPart.Parameters.AddWithValue("@unitTypeID", UnitTypeID);
            cmdImportPart.Parameters.AddWithValue("@sellPrice", SellPrice);
            cmdImportPart.Parameters.AddWithValue("@recommendedQuantity", 0);
            cmdImportPart.Parameters.AddWithValue("@minimumQuantity", 0);
            cmdImportPart.Parameters.AddWithValue("@CategoryID", CategoryID);
            cmdImportPart.Parameters.AddWithValue("@WarehouseID", 0);
            cmdImportPart.Parameters.AddWithValue("@ShelfID", 0);
            cmdImportPart.Parameters.AddWithValue("@BinID", 0);
            cmdImportPart.Parameters.AddWithValue("@WarehouseIDAlternative", 0);
            cmdImportPart.Parameters.AddWithValue("@ShelfIDAlternative", 0);
            cmdImportPart.Parameters.AddWithValue("@BinIDAlternative", 0);
            cmdImportPart.Parameters.AddWithValue("@EndFlagged", false);
            cmdImportPart.Parameters.AddWithValue("@Equipment", false);
            return _Tdatabase.ExecuteScalarSPTrans(cmdImportPart);
        }

        public void Update_Part(Entity.Parts.Part oPart)
        {
            var cmdImportPart = _Tdatabase.CreateStoredProcedure("Part_Update", Trans);
            cmdImportPart.Parameters.Clear();
            cmdImportPart.Parameters.AddWithValue("@PartID", oPart.PartID);
            cmdImportPart.Parameters.AddWithValue("@Name", oPart.Name);
            cmdImportPart.Parameters.AddWithValue("@Number", oPart.Number);
            cmdImportPart.Parameters.AddWithValue("@Reference", oPart.Reference);
            cmdImportPart.Parameters.AddWithValue("@Notes", oPart.Notes);
            cmdImportPart.Parameters.AddWithValue("@unitTypeID", oPart.UnitTypeID);
            cmdImportPart.Parameters.AddWithValue("@sellPrice", oPart.SellPrice);
            cmdImportPart.Parameters.AddWithValue("@recommendedQuantity", oPart.RecommendedQuantity);
            cmdImportPart.Parameters.AddWithValue("@minimumQuantity", oPart.MinimumQuantity);
            cmdImportPart.Parameters.AddWithValue("@CategoryID", oPart.CategoryID);
            cmdImportPart.Parameters.AddWithValue("@WarehouseID", oPart.WarehouseID);
            cmdImportPart.Parameters.AddWithValue("@ShelfID", oPart.ShelfID);
            cmdImportPart.Parameters.AddWithValue("@BinID", oPart.BinID);
            cmdImportPart.Parameters.AddWithValue("@WarehouseIDAlternative", oPart.WarehouseIDAlternative);
            cmdImportPart.Parameters.AddWithValue("@ShelfIDAlternative", oPart.ShelfIDAlternative);
            cmdImportPart.Parameters.AddWithValue("@BinIDAlternative", oPart.BinIDAlternative);
            cmdImportPart.Parameters.AddWithValue("@EndFlagged", oPart.EndFlagged);
            cmdImportPart.Parameters.AddWithValue("@Equipment", oPart.Equipment);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart);
        }

        public void Insert_Part_Supplier(int PartID, string Code, int SupplierID, double Price, int Quantity)
        {
            var cmdImportPart = _Tdatabase.CreateStoredProcedure("PartSupplier_Insert", Trans);
            cmdImportPart.Parameters.Clear();
            cmdImportPart.Parameters.AddWithValue("@PartCode", Code);
            cmdImportPart.Parameters.AddWithValue("@PartID", PartID);
            cmdImportPart.Parameters.AddWithValue("@SupplierID", SupplierID);
            cmdImportPart.Parameters.AddWithValue("@Price", Price);
            cmdImportPart.Parameters.AddWithValue("@quantityInPack", Quantity);
            cmdImportPart.Parameters.AddWithValue("@UserID", App.loggedInUser.UserID);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart);
        }

        public void Update_Part_Supplier(Entity.PartSuppliers.PartSupplier oPartSupplier)
        {
            var cmdImportPart = _Tdatabase.CreateStoredProcedure("PartSupplier_Update", Trans);
            cmdImportPart.Parameters.Clear();
            cmdImportPart.Parameters.AddWithValue("@PartSupplierID", oPartSupplier.PartSupplierID);
            cmdImportPart.Parameters.AddWithValue("@PartCode", oPartSupplier.PartCode);
            cmdImportPart.Parameters.AddWithValue("@PartID", oPartSupplier.PartID);
            cmdImportPart.Parameters.AddWithValue("@SupplierID", oPartSupplier.SupplierID);
            cmdImportPart.Parameters.AddWithValue("@Price", oPartSupplier.Price);
            cmdImportPart.Parameters.AddWithValue("@quantityInPack", oPartSupplier.QuantityInPack);
            cmdImportPart.Parameters.AddWithValue("@UserID", App.loggedInUser.UserID);
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class DuplicateInvoice
    {
        public int SupplierID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string SupplierPartCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double NetAmount { get; set; }
        public double VATAmount { get; set; }
        public double GrossAmount { get; set; }
        public int TotalQtyOfParts { get; set; }
    }
}