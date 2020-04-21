using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace FSM.Entity
{
    namespace Sys
    {
        public class Configuration
        {
            public Configuration()
            {
                var ConfigurationDetails = new DataSet();
                int configRow = 0;

                // Select config file for release type
                if (IsRFT)
                {
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings_RFT.config");
                }
                else if (IsRFTTEST)
                {
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings_RFTTEST.config");
                }
                else if (IsBlueflame)
                {
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings_Blueflame.config");
                }
                else if (IsBlueflameTest)
                {
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings_BlueflameTest.config");
                }
                else if (IsGasway | IsRelease)
                {
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings.config");
                }
                else
                {
                    // if were in beta, we have access to all configs
                    ConfigurationDetails.ReadXml(Application.StartupPath + @"\ApplicationSettings_Beta.config");
                    var dbs = new DataTable();
                    dbs.Columns.Add("ValueMember");
                    dbs.Columns.Add(new DataColumn("DisplayMember"));
                    dbs.Columns.Add(new DataColumn("Deleted"));
                    int index = 1;
                    foreach (DataRow config in ConfigurationDetails.Tables[0].Rows)
                    {
                        // if we can connect to db then add it to selection
                        if (TestConnection(Conversions.ToString(config["DatabaseServer"]), Conversions.ToString(config["DatabaseName"]), Conversions.ToString(config["DatabaseUsername"]), Conversions.ToString(config["DatabasePassword"])))
                        {
                            dbs.Rows.Add(new string[] { index.ToString(), config["DatabaseFriendlyName"].ToString(), "0" });
                        }

                        index += 1;
                    }

                    // if we have more than one connection then we default display selection window
                    if (dbs.Rows.Count > 1)
                    {
                        var f = new FRMSelectDatabase(dbs);
                        f.ShowDialog();
                        configRow = f.SelectedDb;
                    }
                }

                // set system configuration properties
                string value = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabaseName"]);
                try
                {
                    DBName = (Enums.DataBaseName)Enum.Parse(typeof(Enums.DataBaseName), value);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Enum for database missing", (MsgBoxStyle)MessageBoxButtons.OK, MessageBoxIcon.Error);
                    App.CloseApplication();
                }

                DatabaseServer = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabaseServer"]);
                DatabaseUsername = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabaseUsername"]);
                DatabasePassword = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabasePassword"]);
                DatabaseName = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabaseName"]);
                DocumentsLocation = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DocumentsLocation"]);
                DatabaseFriendlyName = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabaseFriendlyName"]);
                TemplateLocation = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["TemplateLocation"]);
                DatabasePort = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["DatabasePort"]);
                SuperAdminID = Conversions.ToInteger(ConfigurationDetails.Tables[0].Rows[configRow]["SuperAdminID"]);
                SupportEmailFrom = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SupportEmailFrom"]);
                SupportEmailTo = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SupportEmailTo"]);
                SalesEmailFrom = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SalesEmailFrom"]);
                InfoEmail = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["FeedbackEmailFrom"]);
                SMTPServer = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SMTPServer"]);
                SMTPServerUsername = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SMTPServerUsername"]);
                SMTPServerPassword = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["SMTPServerPassword"]);
                VATNO = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["VATNO"]);
                CompanyName = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyName"]);
                CompanyAddres1 = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyAddres1"]);
                CompanyAddres2 = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyAddres2"]);
                CompanyAddres3 = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyAddres3"]);
                CompanyAddres4 = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyAddres4"]);
                CompanyAddres5 = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyAddres5"]);
                CompanyPostcode = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyPostcode"]);
                CompanyTelephoneNumber = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyTelephoneNumber"]);
                CompanyWebsite = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyWebsite"]);
                CompanyDomain = Conversions.ToString(ConfigurationDetails.Tables[0].Rows[configRow]["CompanyDomain"]);
                CompanyFullAddress = CompanyName + ", " + CompanyAddres1 + ", " + CompanyAddres2 + ", " + CompanyAddres3 + ", " + CompanyPostcode;
            }

            private bool TestConnection(string dbServer, string dbName, string dbUsername, string dbPass)
            {
                // set up connection string
                string str = "";
                if (dbServer.Contains(@".\"))
                {
                    str = "Data Source=" + dbServer + ";Initial Catalog=" + dbName + ";Integrated Security=True";
                }
                else
                {
                    str = "Server=tcp:" + dbServer + ";";
                    str += "User Id=" + dbUsername + ";";
                    if (dbPass.Trim().Length > 0)
                    {
                        str += "Password=" + dbPass + ";";
                    }

                    str += "Database=" + dbName + ";";
                }

                // TEST CONNECTION
                try
                {
                    using (var conn = new System.Data.SqlClient.SqlConnection(str))
                    {
                        try
                        {
                            conn.Open();
                            return true;
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                return default;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private bool _isDebug = false;

            public bool IsDebug
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia */
                    _isDebug = true;
                    /* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isDebug;
                }
            }

            private bool _isRelease = false;

            public bool IsRelease
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isRelease;
                }
            }

            private bool _isGasway = false;

            public bool IsGasway
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isGasway;
                }
            }

            private bool _isRFT = false;

            public bool IsRFT
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isRFT;
                }
            }

            private bool _isRFTTEST = false;

            public bool IsRFTTEST
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isRFTTEST;
                }
            }

            private bool _isBlueflame = false;

            public bool IsBlueflame
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isBlueflame;
                }
            }

            private bool _isBlueflameTest = false;

            public bool IsBlueflameTest
            {
                get
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return _isBlueflameTest;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private string _DatabaseServer = string.Empty;

            public string DatabaseServer
            {
                get
                {
                    return _DatabaseServer;
                }

                set
                {
                    _DatabaseServer = value;
                }
            }

            private string _DatabaseFriendlyName = string.Empty;

            public string DatabaseFriendlyName
            {
                get
                {
                    return _DatabaseFriendlyName;
                }

                set
                {
                    _DatabaseFriendlyName = value;
                }
            }

            private Enums.DataBaseName _DBName;

            public Enums.DataBaseName DBName
            {
                get
                {
                    return _DBName;
                }

                set
                {
                    _DBName = value;
                }
            }

            private string _DatabaseUsername = string.Empty;

            public string DatabaseUsername
            {
                get
                {
                    return _DatabaseUsername;
                }

                set
                {
                    _DatabaseUsername = value;
                }
            }

            private string _DatabasePassword = string.Empty;

            public string DatabasePassword
            {
                get
                {
                    return _DatabasePassword;
                }

                set
                {
                    _DatabasePassword = value;
                }
            }

            private string _DatabaseName = string.Empty;

            public string DatabaseName
            {
                get
                {
                    return _DatabaseName;
                }

                set
                {
                    _DatabaseName = value;
                }
            }

            private string _DatabasePort = string.Empty;

            public string DatabasePort
            {
                get
                {
                    return _DatabasePort;
                }

                set
                {
                    _DatabasePort = value;
                }
            }

            public string ConnectionString
            {
                get
                {
                    string str = "";
                    var switchExpr = App.TheSystem.DataBaseServerType;
                    switch (switchExpr)
                    {
                        case Enums.DatabaseSystems.MySQL:
                            {
                                str += "server=" + DatabaseServer + ";";
                                str += "user id=" + DatabaseUsername + ";";
                                if (DatabasePassword.Trim().Length > 0)
                                {
                                    str += "password=" + DatabasePassword + ";";
                                }

                                str += "database=" + DatabaseName + ";";
                                str += "port=" + DatabasePort + ";";
                                break;
                            }

                        case Enums.DatabaseSystems.Microsoft_SQL_Server:
                            {
                                if (DatabaseServer.Contains(@".\"))
                                {
                                    str = "Data Source=" + DatabaseServer + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";
                                }
                                else
                                {
                                    str = "Server=tcp:" + DatabaseServer + ";";
                                    str += "User Id=" + DatabaseUsername + ";";
                                    if (DatabasePassword.Trim().Length > 0)
                                    {
                                        str += "Password=" + DatabasePassword + ";";
                                    }

                                    str += "Database=" + DatabaseName + ";";
                                }

                                break;
                            }
                    }

                    return str;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public string SystemVersion
            {
                get
                {
                    return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
                }
            }

            private int _SuperAdminID = 0;

            public int SuperAdminID
            {
                get
                {
                    return _SuperAdminID;
                }

                set
                {
                    _SuperAdminID = value;
                }
            }

            private string _SupportEmailFrom = string.Empty;

            public string SupportEmailFrom
            {
                get
                {
                    return _SupportEmailFrom;
                }

                set
                {
                    _SupportEmailFrom = value;
                }
            }

            private string _SupportEmailTo = string.Empty;

            public string SupportEmailTo
            {
                get
                {
                    return _SupportEmailTo;
                }

                set
                {
                    _SupportEmailTo = value;
                }
            }

            private string _SalesEmailFrom = string.Empty;

            public string SalesEmailFrom
            {
                get
                {
                    return _SalesEmailFrom;
                }

                set
                {
                    _SalesEmailFrom = value;
                }
            }

            public string InfoEmail { get; set; }

            private string _SMTPServer = string.Empty;

            public string SMTPServer
            {
                get
                {
                    return _SMTPServer;
                }

                set
                {
                    _SMTPServer = value;
                }
            }

            private string _SMTPServerUsername = string.Empty;

            public string SMTPServerUsername
            {
                get
                {
                    return _SMTPServerUsername;
                }

                set
                {
                    _SMTPServerUsername = value;
                }
            }

            private string _SMTPServerPassword = string.Empty;

            public string SMTPServerPassword
            {
                get
                {
                    return _SMTPServerPassword;
                }

                set
                {
                    _SMTPServerPassword = value;
                }
            }

            private string _DocumentsLocation = string.Empty;

            public string DocumentsLocation
            {
                get
                {
                    return _DocumentsLocation;
                }

                set
                {
                    _DocumentsLocation = value;
                }
            }

            private string _TemplateLocation = string.Empty;

            public string TemplateLocation
            {
                get
                {
                    return _TemplateLocation;
                }

                set
                {
                    _TemplateLocation = value;
                }
            }

            private string _VATNO = string.Empty;

            public string VATNO
            {
                get
                {
                    return _VATNO;
                }

                set
                {
                    _VATNO = value;
                }
            }

            public string CompanyName;
            public string CompanyAddres1;
            public string CompanyAddres2;
            public string CompanyAddres3;
            public string CompanyAddres4;
            public string CompanyAddres5;
            public string CompanyPostcode;
            public string CompanyTelephoneNumber;
            public string CompanyWebsite;
            public string CompanyDomain;
            public string CompanyFullAddress;

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}