﻿using System.Data;
using Microsoft.VisualBasic;

namespace FSM.Entity
{
    namespace Sys
    {
        public class SystemData
        {
            private const Enums.DatabaseSystems _DataBaseServerType = Enums.DatabaseSystems.Microsoft_SQL_Server;

            public Enums.DatabaseSystems DataBaseServerType
            {
                get
                {
                    return _DataBaseServerType;
                }
            }

            private Configuration _Configuration = new Configuration();

            public Configuration Configuration
            {
                get
                {
                    return _Configuration;
                }
            }

            private const string _DeletedPostfix = " (Deleted)";

            public string DeletedPostfix
            {
                get
                {
                    return _DeletedPostfix;
                }
            }

            private const string _Title = "Field Service Manager - Beta";

            public string Title
            {
                get
                {
                    return _Title;
                }
            }

            private const string _Description = "Field Management System";

            public string Description
            {
                get
                {
                    return _Description;
                }
            }

            private const string _Company = "Gasway Services Ltd";

            public string Company
            {
                get
                {
                    return _Company;
                }
            }

            private const string _Product = "FSM";

            public string Product
            {
                get
                {
                    return _Product;
                }
            }

            private const string _Copyright = "FSM";

            public string Copyright
            {
                get
                {
                    return _Copyright;
                }
            }

            private const string _Trademark = "FSM";

            public string Trademark
            {
                get
                {
                    return _Trademark;
                }
            }

            public DataTable DLLInformation
            {
                get
                {
                    var dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Version");
                    foreach (System.Reflection.AssemblyName assem in GetType().Assembly.GetReferencedAssemblies())
                        dt.Rows.Add(new string[] { assem.Name, assem.Version.ToString() });
                    dt.TableName = Enums.TableNames.NOT_IN_DATABASE_DLLs.ToString();
                    return dt;
                }
            }

            private const string _Address = "Exel Computer Systems plc" + Constants.vbCrLf + Constants.vbCrLf + "Bothe Hall" + Constants.vbCrLf + "Sawley" + Constants.vbCrLf + "Nottingham" + Constants.vbCrLf + "NG10 3XL";

            public string Address
            {
                get
                {
                    return _Address;
                }
            }

            private const string _Telephone = "0115 946 0101";

            public string Telephone
            {
                get
                {
                    return _Telephone;
                }
            }

            private const string _Fax = "0115 946 0101\"";

            public string Fax
            {
                get
                {
                    return _Fax;
                }
            }

            public string ContactUs
            {
                get
                {
                    return Address + Constants.vbCrLf + Constants.vbCrLf + Constants.vbCrLf + "Tel : " + Telephone + Constants.vbCrLf + Constants.vbCrLf + Constants.vbCrLf;
                }
            }
        }
    }
}