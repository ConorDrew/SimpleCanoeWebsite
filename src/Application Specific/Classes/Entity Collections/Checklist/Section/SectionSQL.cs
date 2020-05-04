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

            public void Delete(int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID, true);
                _database.ExecuteSP_NO_Return("Section_Delete");
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
        }
    }
}