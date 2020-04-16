// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Users.UserSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Users
{
    public class UserSQL
    {
        private Database _database;

        public UserSQL(Database databaseIn)
        {
            this._database = databaseIn;
        }

        public bool Authenticate(string UserName, string Password)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserName", (object)UserName, false);
            this._database.AddParameter("@Password", (object)Helper.HashPassword(Password), false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("User_Login_Mk1", true);
            if (dataTable.Rows.Count > 0)
            {
                App.loggedInUser = this.Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"])), false);
                return true;
            }
            App.loggedInUser = (User)null;
            return false;
        }

        public int IsUserActive(string UserName = "", int UserID = 0, bool SetProperty = false)
        {
            this._database.ClearParameter();
            if (!string.IsNullOrEmpty(UserName))
                this._database.AddParameter("@UserName", (object)UserName, false);
            if (UserID > 0)
                this._database.AddParameter("@UserID", (object)UserID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("User_IsActive_Mk1", true);
            if (dataTable.Rows.Count <= 0)
                return 0;
            if (SetProperty)
                App.loggedInUser = this.Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(UserID)])), true);
            return -1;
        }

        public bool Check_Unique_Username(string username, int ID)
        {
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(Userid) as 'NumberOfUsers' FROM tbluser WHERE deleted = 0 AND username = '" + username + "' AND userid <> " + Conversions.ToString(ID), false, false))) == 0;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("User_GetAll_Mk1", true);
            table.TableName = Enums.TableNames.tblUser.ToString();
            return new DataView(table);
        }

        public DataView GetAll_NoEngineers()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("User_GetAll_NoEngineers", true);
            table.TableName = Enums.TableNames.tblUser.ToString();
            return new DataView(table);
        }

        public User Get(int UserID, bool passExpired = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("User_Get_Mk1", true);
            if (dataTable.Rows.Count <= 0)
                return (User)null;
            return new User()
            {
                SetUserID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(UserID)])),
                SetFullname = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Fullname"])),
                SetUsername = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Username"])),
                SetPassword = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Password"])),
                SetEnabled = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Enabled"])),
                SetDeleted = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Deleted"])),
                SetAdmin = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Admin"])),
                SetSchedulerDayView = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SchedulerDayView"])),
                SetDefaultEngineerGroup = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DefaultSchedulerEngineerGroup"])) ? (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DefaultSchedulerEngineerGroup"])) : (object)0,
                SetSchedulerTextSize = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SchedulerTextSize"])),
                SetEmailAddress = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"])),
                PasswordExpiryDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExpiryDate"])),
                SetUpdateAtLogon = passExpired || Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UpdateAtLogon"])),
                SecurityUserModules = this.GetSecurityUserModules(UserID),
                UserRegions = App.DB.User.UserRegions_Get(UserID),
                Exists = true
            };
        }

        public User GetAsync(int UserID)
        {
            DataTable dataTable = new DataTable();
            SqlCommand Command = new SqlCommand("User_Get_Mk1", new SqlConnection(this._database.ServerConnectionString));
            try
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UserID", (object)UserID);
                dataTable = this._database.ExecuteCommand_DataTable(Command);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            finally
            {
                Command.Connection.Close();
            }
            if (dataTable.Rows.Count <= 0)
                return (User)null;
            User user = new User()
            {
                SetUserID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(UserID)])),
                SetFullname = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Fullname"])),
                SetUsername = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Username"])),
                SetPassword = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Password"])),
                SetEnabled = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Enabled"])),
                SetDeleted = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Deleted"])),
                SetAdmin = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Admin"])),
                SetSchedulerDayView = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SchedulerDayView"])),
                SetDefaultEngineerGroup = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DefaultSchedulerEngineerGroup"])),
                SetSchedulerTextSize = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SchedulerTextSize"])),
                SetEmailAddress = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"])),
                PasswordExpiryDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExpiryDate"])),
                SetUpdateAtLogon = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UpdateAtLogon"]))
            };
            user.SecurityUserModules = this.GetSecurityUserModules(UserID);
            user.UserRegions = App.DB.User.UserRegions_Get(UserID);
            user.Exists = true;
            return user;
        }

        public DataView Get_Passwords(int UserID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, false);
            return new DataView(this._database.ExecuteSP_DataTable("UserPassword_Get_ForUser_Mk1", true));
        }

        public bool UpdatePassword(int UserID, string Password, bool updateAtLogon = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, false);
            this._database.AddParameter("@Password", (object)Helper.HashPassword(Password), false);
            this._database.AddParameter("@UpdateAtLogon", (object)updateAtLogon, false);
            this._database.AddParameter("@ExpiryDate", (object)DateAndTime.Now.AddMonths(3), true);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("UserPassword_InsertUpdate_Mk1", true), (object)1, false);
        }

        public string LastLogon(int UserID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, false);
            string str;
            try
            {
                str = "Last logon : " + Strings.Format((object)Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("User_LastLogon_Mk1", true))), "dd/MMM/yyyy HH:mm:ss") + ".";
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                str = "This is your first logon.";
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public int Insert(User userAndEngineer)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Fullname", (object)userAndEngineer.Fullname, false);
            this._database.AddParameter("@Username", (object)userAndEngineer.Username, false);
            this._database.AddParameter("@Password", (object)Helper.HashPassword(userAndEngineer.Password), false);
            this._database.AddParameter("@DefaultSchedulerEngineerGroup", (object)userAndEngineer.DefaultEngineerGroup, false);
            this._database.AddParameter("@EmailAddress", (object)userAndEngineer.EmailAddress, false);
            this._database.AddParameter("@Enabled", (object)userAndEngineer.Enabled, true);
            this._database.AddParameter("@Admin", (object)userAndEngineer.Admin, true);
            this._database.AddParameter("@SchedulerDayView", (object)userAndEngineer.SchedulerDayView, true);
            int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("User_Insert_Mk1", true)));
            userAndEngineer.SetUserID = (object)num;
            this.SaveSecurityUserModules(userAndEngineer);
            return num;
        }

        public void Update(User userAndEngineer)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userAndEngineer.UserID, false);
            this._database.AddParameter("@Fullname", (object)userAndEngineer.Fullname, false);
            this._database.AddParameter("@Username", (object)userAndEngineer.Username, false);
            this._database.AddParameter("@Password", (object)Helper.HashPassword(userAndEngineer.Password), false);
            this._database.AddParameter("@DefaultSchedulerEngineerGroup", (object)userAndEngineer.DefaultEngineerGroup, false);
            this._database.AddParameter("@EmailAddress", (object)userAndEngineer.EmailAddress, false);
            this._database.AddParameter("@Enabled", (object)userAndEngineer.Enabled, true);
            this._database.AddParameter("@Admin", (object)userAndEngineer.Admin, true);
            this._database.AddParameter("@SchedulerDayView", (object)userAndEngineer.SchedulerDayView, true);
            this._database.ExecuteSP_OBJECT("User_Update_Mk1", true);
            this.SaveSecurityUserModules(userAndEngineer);
        }

        public void Delete(int UserID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, false);
            this._database.ExecuteSP_OBJECT("User_Delete_Mk1", true);
        }

        public DataView User_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable("User_SearchList_Mk1", true);
            table.TableName = Enums.TableNames.tblUser.ToString();
            return new DataView(table);
        }

        public void User_Update_TextSize(int UserID, int TextSize)
        {
            this._database.ClearParameter();
            this._database.ExecuteScalar("UPDATE tblUser Set SchedulerTextSize = " + Conversions.ToString(TextSize) + " Where UserID = " + Conversions.ToString(UserID), true, false);
        }

        public DataView GetSecurityUserModulesDefaults()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("SecurityUserModulesDefault_Get", true);
            table.TableName = Enums.TableNames.tblUser.ToString();
            return new DataView(table);
        }

        public DataView GetUserRegions(int userId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userId, true);
            DataTable table = this._database.ExecuteSP_DataTable("UserRegions_Get_ForUserID", true);
            table.TableName = Enums.TableNames.tblRegion.ToString();
            return new DataView(table);
        }

        public DataView GetUserRegionsDefaults()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("UserRegions_Get_Defaults", true);
            table.TableName = Enums.TableNames.tblRegion.ToString();
            return new DataView(table);
        }

        public DataView GetSecurityUserModules(int userID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userID, true);
            DataTable table = this._database.ExecuteSP_DataTable("SecurityUserModules_Get", true);
            table.TableName = Enums.TableNames.tblSecurityUserModules.ToString();
            return new DataView(table);
        }

        private User SaveSecurityUserModules(User u)
        {
            if (u.SecurityUserModules != null)
            {
                DataTable table = u.SecurityUserModules.Table;
                DataTable changes = table.GetChanges();
                if (changes != null)
                {
                    string actionChange = string.Empty;
                    bool flag = false;
                    IEnumerator enumerator;
                    try
                    {
                        enumerator = changes.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            if (flag)
                                actionChange += " and ";
                            actionChange = actionChange + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["ModuleName"])) + " set to " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["AccessPermitted"]));
                            flag = true;
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                            (enumerator as IDisposable).Dispose();
                    }
                    if (!string.IsNullOrEmpty(actionChange))
                        this.UserAccessAudit_Insert(u.UserID, actionChange);
                }
                IEnumerator enumerator1;
                try
                {
                    enumerator1 = table.Rows.GetEnumerator();
                    while (enumerator1.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator1.Current;
                        this._database.ClearParameter();
                        this._database.AddParameter("@UserID", (object)u.UserID, true);
                        this._database.AddParameter("@SystemModuleID", (object)Conversions.ToInteger(current["SystemModuleID"]), true);
                        this._database.AddParameter("@AccessPermitted", (object)Conversions.ToBoolean(current["AccessPermitted"]), true);
                        if (Conversions.ToInteger(current["UserModuleID"]) == 0)
                            this._database.ExecuteSP_NO_Return("SecurityUserModules_Insert", true);
                        else
                            this._database.ExecuteSP_NO_Return("SecurityUserModules_Update", true);
                    }
                }
                finally
                {
                    if (enumerator1 is IDisposable)
                        (enumerator1 as IDisposable).Dispose();
                }
                u.SecurityUserModules = this.GetSecurityUserModules(u.UserID);
            }
            return u;
        }

        public void InsertNewSecurityUserModules(int UserID, int SystemModuleID, bool AccessPermitted)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)UserID, true);
            this._database.AddParameter("@SystemModuleID", (object)SystemModuleID, true);
            this._database.AddParameter("@AccessPermitted", (object)AccessPermitted, true);
            this._database.ExecuteSP_NO_Return("SecurityUserModules_Insert", true);
        }

        public DataView UserRegions_Get(int userID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userID, true);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(UserRegions_Get), true));
        }

        public void UserRegions_Insert(int userID, int managerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userID, true);
            this._database.AddParameter("@RegionID", (object)managerID, true);
            this._database.ExecuteSP_OBJECT("UserRegion_Insert", true);
        }

        public void UserRegions_Delete(int userID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("DELETE FROM tblUserRegion Where UserID = " + Conversions.ToString(userID), true, false);
        }

        public void UserAccessAudit_Insert(int userId, string actionChange)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userId, true);
            this._database.AddParameter("@ActionChange", (object)actionChange, true);
            this._database.AddParameter("@ActionDateTime", (object)DateTime.Now, true);
            this._database.AddParameter("@AuthUserID", (object)App.loggedInUser.UserID, true);
            this._database.ExecuteSP_NO_Return(nameof(UserAccessAudit_Insert), true);
        }
    }
}