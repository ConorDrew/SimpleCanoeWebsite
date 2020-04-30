using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVans
    {
        public class EngineerVanSQL
        {
            private Sys.Database _database;

            public EngineerVanSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public DataView EngineerVan_GetAll_For_Van(int VanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", VanID);
                var dt = _database.ExecuteSP_DataTable("EngineerVan_GetAll_For_Van");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVan.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVan_GetAll_For_Engineer(int EngineerID, bool Grouped)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", EngineerID);
                if (Grouped)
                {
                    _database.AddParameter("@Grouped", 1);
                }
                else
                {
                    _database.AddParameter("@Grouped", 0);
                }

                var dt = _database.ExecuteSP_DataTable("EngineerVan_GetAll_For_Engineer");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVan.ToString();
                return new DataView(dt);
            }

            public EngineerVan EngineerVan_Get(int EngineerVanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVanID", EngineerVanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVan_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVan = new EngineerVan();
                        oEngineerVan.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVan.SetEngineerVanID = dt.Rows[0]["EngineerVanID"];
                        oEngineerVan.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oEngineerVan.SetVanID = dt.Rows[0]["VanID"];
                        oEngineerVan.StartDateTime = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oEngineerVan.EndDateTime = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oEngineerVan.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVan.Exists = true;
                        return oEngineerVan;
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

            public EngineerVan Insert(EngineerVan oEngineerVan)
            {
                EngineerVan returnVan = null;
                string registration = App.DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split('*')[0].Trim();
                foreach (DataRow row in App.DB.Van.Van_GetAll(false).Table.Rows)
                {
                    if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@EngineerID", oEngineerVan.EngineerID, true);
                        _database.AddParameter("@VanID", row["VanID"], true);
                        _database.AddParameter("@StartDateTime", oEngineerVan.StartDateTime, true);
                        if (oEngineerVan.EndDateTime != default)
                        {
                            _database.AddParameter("@EndDateTime", oEngineerVan.EndDateTime, true);
                        }
                        else
                        {
                            _database.AddParameter("@EndDateTime", DBNull.Value, true);
                        }

                        oEngineerVan.SetEngineerVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVan_Insert"));
                        oEngineerVan.Exists = true;
                        if (returnVan is null)
                        {
                            returnVan = oEngineerVan;
                        }
                    }
                }

                return returnVan;
            }

            public void Update(EngineerVan oEngineerVan)
            {
                string registration = App.DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split('*')[0].Trim();
                var dt = EngineerVan_GetAll_For_Engineer(oEngineerVan.EngineerID, false).Table;
                foreach (DataRow row in App.DB.Van.Van_GetAll(false).Table.Rows)
                {
                    if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                    {
                        foreach (DataRow engineerVanRow in dt.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engineerVanRow["VanID"], row["VanID"], false)))
                            {
                                _database.ClearParameter();
                                _database.AddParameter("@EngineerID", oEngineerVan.EngineerID, true);
                                _database.AddParameter("@StartDateTime", oEngineerVan.StartDateTime, true);
                                if (oEngineerVan.EndDateTime != default)
                                {
                                    _database.AddParameter("@EndDateTime", oEngineerVan.EndDateTime, true);
                                }
                                else
                                {
                                    _database.AddParameter("@EndDateTime", DBNull.Value, true);
                                }

                                _database.AddParameter("@EngineerVanID", engineerVanRow["EngineerVanID"], true);
                                _database.ExecuteSP_NO_Return("EngineerVan_Update");
                            }
                        }
                    }
                }
            }

            public void Delete(int EngineerVanID)
            {
                var oEngineerVan = EngineerVan_Get(EngineerVanID);
                string registration = App.DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split('*')[0].Trim();
                var dt = EngineerVan_GetAll_For_Engineer(oEngineerVan.EngineerID, false).Table;

                // Dim dt2 As DataTable = EngineerVan_GetAll_For_Van(oEngineerVan.VanID).Table

                foreach (DataRow row in App.DB.Van.Van_GetAll_incDeleted(false).Table.Rows)
                {
                    if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                    {
                        foreach (DataRow engineerVanRow in dt.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engineerVanRow["VanID"], row["VanID"], false)))
                            {
                                _database.ClearParameter();
                                _database.AddParameter("@EngineerVanID", engineerVanRow["EngineerVanID"], true);
                                _database.ExecuteSP_NO_Return("EngineerVan_Delete");
                            }
                        }
                    }
                }
            }

            
        }
    }
}