// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Configuration
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class Configuration
    {
        private bool _isDebug;
        private bool _isRelease;
        private bool _isGasway;
        private bool _isRFT;
        private bool _isRFTTEST;
        private bool _isBlueflame;
        private bool _isBlueflameTest;
        private string _DatabaseServer;
        private string _DatabaseFriendlyName;
        private Enums.DataBaseName _DBName;
        private string _DatabaseUsername;
        private string _DatabasePassword;
        private string _DatabaseName;
        private string _DatabasePort;
        private int _SuperAdminID;
        private string _SupportEmailFrom;
        private string _SupportEmailTo;
        private string _SalesEmailFrom;
        private string _SMTPServer;
        private string _SMTPServerUsername;
        private string _SMTPServerPassword;
        private string _DocumentsLocation;
        private string _TemplateLocation;
        private string _VATNO;
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

        public Configuration()
        {
            this._isDebug = false;
            this._isRelease = false;
            this._isGasway = false;
            this._isRFT = false;
            this._isRFTTEST = false;
            this._isBlueflame = false;
            this._isBlueflameTest = false;
            this._DatabaseServer = string.Empty;
            this._DatabaseFriendlyName = string.Empty;
            this._DatabaseUsername = string.Empty;
            this._DatabasePassword = string.Empty;
            this._DatabaseName = string.Empty;
            this._DatabasePort = string.Empty;
            this._SuperAdminID = 0;
            this._SupportEmailFrom = string.Empty;
            this._SupportEmailTo = string.Empty;
            this._SalesEmailFrom = string.Empty;
            this._SMTPServer = string.Empty;
            this._SMTPServerUsername = string.Empty;
            this._SMTPServerPassword = string.Empty;
            this._DocumentsLocation = string.Empty;
            this._TemplateLocation = string.Empty;
            this._VATNO = string.Empty;
            DataSet dataSet = new DataSet();
            int index = 0;
            if (this.IsRFT)
            {
                int num1 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings_RFT.config");
            }
            else if (this.IsRFTTEST)
            {
                int num2 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings_RFTTEST.config");
            }
            else if (this.IsBlueflame)
            {
                int num3 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings_Blueflame.config");
            }
            else if (this.IsBlueflameTest)
            {
                int num4 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings_BlueflameTest.config");
            }
            else if (this.IsGasway | this.IsRelease)
            {
                int num5 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings.config");
            }
            else
            {
                int num6 = (int)dataSet.ReadXml(Application.StartupPath + "\\ApplicationSettings_Beta.config");
                DataTable dbs = new DataTable();
                dbs.Columns.Add("ValueMember");
                dbs.Columns.Add(new DataColumn("DisplayMember"));
                dbs.Columns.Add(new DataColumn("Deleted"));
                int num7 = 1;
                foreach (DataRow current in dataSet.Tables[0].Rows)
                {
                    if (this.TestConnection(Conversions.ToString(current[nameof(DatabaseServer)]), Conversions.ToString(current[nameof(DatabaseName)]), Conversions.ToString(current[nameof(DatabaseUsername)]), Conversions.ToString(current[nameof(DatabasePassword)])))
                        dbs.Rows.Add((object[])new string[3]
                        {
                Conversions.ToString(num7),
                Conversions.ToString(current[nameof (DatabaseFriendlyName)]),
                "0"
                        });
                    checked { ++num7; }
                }

                if (dbs.Rows.Count > 1)
                {
                    FRMSelectDatabase frmSelectDatabase = new FRMSelectDatabase(dbs);
                    int num8 = (int)frmSelectDatabase.ShowDialog();
                    index = frmSelectDatabase.SelectedDb;
                }
            }
            string str = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabaseName)]);
            try
            {
                this.DBName = (Enums.DataBaseName)Conversions.ToInteger(Enum.Parse(typeof(Enums.DataBaseName), str));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num6 = (int)Interaction.MsgBox((object)"Enum for database missing", MsgBoxStyle.OkOnly, (object)MessageBoxIcon.Hand);
                App.CloseApplication();
                ProjectData.ClearProjectError();
            }
            this.DatabaseServer = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabaseServer)]);
            this.DatabaseUsername = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabaseUsername)]);
            this.DatabasePassword = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabasePassword)]);
            this.DatabaseName = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabaseName)]);
            this.DocumentsLocation = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DocumentsLocation)]);
            this.DatabaseFriendlyName = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabaseFriendlyName)]);
            this.TemplateLocation = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(TemplateLocation)]);
            this.DatabasePort = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(DatabasePort)]);
            this.SuperAdminID = Conversions.ToInteger(dataSet.Tables[0].Rows[index][nameof(SuperAdminID)]);
            this.SupportEmailFrom = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SupportEmailFrom)]);
            this.SupportEmailTo = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SupportEmailTo)]);
            this.SalesEmailFrom = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SalesEmailFrom)]);
            this.InfoEmail = Conversions.ToString(dataSet.Tables[0].Rows[index]["FeedbackEmailFrom"]);
            this.SMTPServer = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SMTPServer)]);
            this.SMTPServerUsername = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SMTPServerUsername)]);
            this.SMTPServerPassword = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(SMTPServerPassword)]);
            this.VATNO = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(VATNO)]);
            this.CompanyName = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyName)]);
            this.CompanyAddres1 = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyAddres1)]);
            this.CompanyAddres2 = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyAddres2)]);
            this.CompanyAddres3 = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyAddres3)]);
            this.CompanyAddres4 = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyAddres4)]);
            this.CompanyAddres5 = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyAddres5)]);
            this.CompanyPostcode = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyPostcode)]);
            this.CompanyTelephoneNumber = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyTelephoneNumber)]);
            this.CompanyWebsite = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyWebsite)]);
            this.CompanyDomain = Conversions.ToString(dataSet.Tables[0].Rows[index][nameof(CompanyDomain)]);
            this.CompanyFullAddress = this.CompanyName + ", " + this.CompanyAddres1 + ", " + this.CompanyAddres2 + ", " + this.CompanyAddres3 + ", " + this.CompanyPostcode;
        }

        private bool TestConnection(string dbServer, string dbName, string dbUsername, string dbPass)
        {
            string connectionString;
            if (dbServer.Contains(".\\"))
            {
                connectionString = "Data Source=" + dbServer + ";Initial Catalog=" + dbName + ";Integrated Security=True";
            }
            else
            {
                string str = "Server=tcp:" + dbServer + ";" + "User Id=" + dbUsername + ";";
                if (dbPass.Trim().Length > 0)
                    str = str + "Password=" + dbPass + ";";
                connectionString = str + "Database=" + dbName + ";";
            }
            bool flag = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        flag = true;
                        goto label_17;
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                    }
                    finally
                    {
                        if (sqlConnection.State == ConnectionState.Open)
                            sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            label_17:
            return flag;
        }

        public bool IsDebug
        {
            get
            {
                this._isDebug = true;
                return this._isDebug;
            }
        }

        public bool IsRelease
        {
            get
            {
                return this._isRelease;
            }
        }

        public bool IsGasway
        {
            get
            {
                return this._isGasway;
            }
        }

        public bool IsRFT
        {
            get
            {
                return this._isRFT;
            }
        }

        public bool IsRFTTEST
        {
            get
            {
                return this._isRFTTEST;
            }
        }

        public bool IsBlueflame
        {
            get
            {
                return this._isBlueflame;
            }
        }

        public bool IsBlueflameTest
        {
            get
            {
                return this._isBlueflameTest;
            }
        }

        public string DatabaseServer
        {
            get
            {
                return this._DatabaseServer;
            }
            set
            {
                this._DatabaseServer = value;
            }
        }

        public string DatabaseFriendlyName
        {
            get
            {
                return this._DatabaseFriendlyName;
            }
            set
            {
                this._DatabaseFriendlyName = value;
            }
        }

        public Enums.DataBaseName DBName
        {
            get
            {
                return this._DBName;
            }
            set
            {
                this._DBName = value;
            }
        }

        public string DatabaseUsername
        {
            get
            {
                return this._DatabaseUsername;
            }
            set
            {
                this._DatabaseUsername = value;
            }
        }

        public string DatabasePassword
        {
            get
            {
                return this._DatabasePassword;
            }
            set
            {
                this._DatabasePassword = value;
            }
        }

        public string DatabaseName
        {
            get
            {
                return this._DatabaseName;
            }
            set
            {
                this._DatabaseName = value;
            }
        }

        public string DatabasePort
        {
            get
            {
                return this._DatabasePort;
            }
            set
            {
                this._DatabasePort = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                string str1 = "";
                switch (App.TheSystem.DataBaseServerType)
                {
                    case Enums.DatabaseSystems.MySQL:
                        string str2 = str1 + "server=" + this.DatabaseServer + ";" + "user id=" + this.DatabaseUsername + ";";
                        if (this.DatabasePassword.Trim().Length > 0)
                            str2 = str2 + "password=" + this.DatabasePassword + ";";
                        str1 = str2 + "database=" + this.DatabaseName + ";" + "port=" + this.DatabasePort + ";";
                        break;

                    case Enums.DatabaseSystems.Microsoft_SQL_Server:
                        if (this.DatabaseServer.Contains(".\\"))
                        {
                            str1 = "Data Source=" + this.DatabaseServer + ";Initial Catalog=" + this.DatabaseName + ";Integrated Security=True";
                            break;
                        }
                        string str3 = "Server=tcp:" + this.DatabaseServer + ";" + "User Id=" + this.DatabaseUsername + ";";
                        if (this.DatabasePassword.Trim().Length > 0)
                            str3 = str3 + "Password=" + this.DatabasePassword + ";";
                        str1 = str3 + "Database=" + this.DatabaseName + ";";
                        break;
                }
                return str1;
            }
        }

        public string SystemVersion
        {
            get
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            }
        }

        public int SuperAdminID
        {
            get
            {
                return this._SuperAdminID;
            }
            set
            {
                this._SuperAdminID = value;
            }
        }

        public string SupportEmailFrom
        {
            get
            {
                return this._SupportEmailFrom;
            }
            set
            {
                this._SupportEmailFrom = value;
            }
        }

        public string SupportEmailTo
        {
            get
            {
                return this._SupportEmailTo;
            }
            set
            {
                this._SupportEmailTo = value;
            }
        }

        public string SalesEmailFrom
        {
            get
            {
                return this._SalesEmailFrom;
            }
            set
            {
                this._SalesEmailFrom = value;
            }
        }

        public string InfoEmail { get; set; }

        public string SMTPServer
        {
            get
            {
                return this._SMTPServer;
            }
            set
            {
                this._SMTPServer = value;
            }
        }

        public string SMTPServerUsername
        {
            get
            {
                return this._SMTPServerUsername;
            }
            set
            {
                this._SMTPServerUsername = value;
            }
        }

        public string SMTPServerPassword
        {
            get
            {
                return this._SMTPServerPassword;
            }
            set
            {
                this._SMTPServerPassword = value;
            }
        }

        public string DocumentsLocation
        {
            get
            {
                return this._DocumentsLocation;
            }
            set
            {
                this._DocumentsLocation = value;
            }
        }

        public string TemplateLocation
        {
            get
            {
                return this._TemplateLocation;
            }
            set
            {
                this._TemplateLocation = value;
            }
        }

        public string VATNO
        {
            get
            {
                return this._VATNO;
            }
            set
            {
                this._VATNO = value;
            }
        }
    }
}