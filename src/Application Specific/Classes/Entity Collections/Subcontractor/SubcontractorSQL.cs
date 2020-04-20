using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Subcontractors
    {
        public class SubcontractorSQL
        {
            private Sys.Database _database;

            public SubcontractorSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int SubcontractorID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubcontractorID", SubcontractorID, true);
                _database.ExecuteSP_NO_Return("Subcontractor_Delete");
            }

            public Subcontractor Subcontractor_Get(int SubcontractorID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubcontractorID", SubcontractorID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Subcontractor_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSubcontractor = new Subcontractor();
                        oSubcontractor.IgnoreExceptionsOnSetMethods = true;
                        oSubcontractor.SetSubcontractorID = dt.Rows[0]["SubcontractorID"];
                        oSubcontractor.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oSubcontractor.SetName = dt.Rows[0]["Name"];
                        oSubcontractor.SetAddress1 = dt.Rows[0]["Address1"];
                        oSubcontractor.SetAddress2 = dt.Rows[0]["Address2"];
                        oSubcontractor.SetAddress3 = dt.Rows[0]["Address3"];
                        oSubcontractor.SetAddress4 = dt.Rows[0]["Address4"];
                        oSubcontractor.SetAddress5 = dt.Rows[0]["Address5"];
                        oSubcontractor.SetPostcode = dt.Rows[0]["Postcode"];
                        oSubcontractor.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oSubcontractor.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oSubcontractor.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oSubcontractor.SetNotes = dt.Rows[0]["Notes"];
                        oSubcontractor.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSubcontractor.SetLinkToSupplierID = dt.Rows[0]["LinkToSupplierID"];
                        if (dt.Rows[0].Table.Columns.Contains("TaxRate"))
                            oSubcontractor.SetTaxRate = dt.Rows[0]["TaxRate"];
                        oSubcontractor.Exists = true;
                        return oSubcontractor;
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

            public DataView Subcontractor_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Subcontractor_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSubcontractor.ToString();
                return new DataView(dt);
            }

            public Subcontractor Insert(Subcontractor oSubcontractor)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", oSubcontractor.EngineerID, true);
                AddSubcontractorParametersToCommand(ref oSubcontractor);
                oSubcontractor.SetSubcontractorID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Subcontractor_Insert"));
                oSubcontractor.Exists = true;
                return oSubcontractor;
            }

            public DataView Subcontractor_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                var dt = _database.ExecuteSP_DataTable("Subcontractor_Search");
                dt.TableName = Sys.Enums.TableNames.tblSubcontractor.ToString();
                return new DataView(dt);
            }

            public void Update(Subcontractor oSubcontractor)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubcontractorID", oSubcontractor.SubcontractorID, true);
                AddSubcontractorParametersToCommand(ref oSubcontractor);
                _database.ExecuteSP_NO_Return("Subcontractor_Update");
            }

            private void AddSubcontractorParametersToCommand(ref Subcontractor oSubcontractor)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Name", oSubcontractor.Name, true);
                    withBlock.AddParameter("@Address1", oSubcontractor.Address1, true);
                    withBlock.AddParameter("@Address2", oSubcontractor.Address2, true);
                    withBlock.AddParameter("@Address3", oSubcontractor.Address3, true);
                    withBlock.AddParameter("@Address4", oSubcontractor.Address4, true);
                    withBlock.AddParameter("@Address5", oSubcontractor.Address5, true);
                    withBlock.AddParameter("@Postcode", oSubcontractor.Postcode, true);
                    withBlock.AddParameter("@TelephoneNum", oSubcontractor.TelephoneNum, true);
                    withBlock.AddParameter("@FaxNum", oSubcontractor.FaxNum, true);
                    withBlock.AddParameter("@EmailAddress", oSubcontractor.EmailAddress, true);
                    withBlock.AddParameter("@Notes", oSubcontractor.Notes, true);
                    withBlock.AddParameter("@LinkToSupplierID", oSubcontractor.LinkToSupplierID, true);
                    withBlock.AddParameter("@TaxRate", oSubcontractor.TaxRate, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}