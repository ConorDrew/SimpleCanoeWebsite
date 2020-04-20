using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sections
    {
        public class SectionSQL
        {
            private Sys.Database _database;

            public SectionSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID, true);
                _database.ExecuteSP_NO_Return("Section_Delete");
            }

            public Section Section_Get(int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Section_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSection = new Section();
                        oSection.IgnoreExceptionsOnSetMethods = true;
                        oSection.SetSectionID = dt.Rows[0]["SectionID"];
                        oSection.SetDescription = dt.Rows[0]["Description"];
                        oSection.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSection.Exists = true;
                        return oSection;
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

            public DataView Section_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Section_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSection.ToString();
                return new DataView(dt);
            }

            public Section Insert(Section oSection)
            {
                _database.ClearParameter();
                AddSectionParametersToCommand(ref oSection);
                oSection.SetSectionID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Section_Insert"));
                oSection.Exists = true;
                return oSection;
            }

            public void Update(Section oSection)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", oSection.SectionID, true);
                AddSectionParametersToCommand(ref oSection);
                _database.ExecuteSP_NO_Return("Section_Update");
            }

            private void AddSectionParametersToCommand(ref Section oSection)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Description", oSection.Description, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}