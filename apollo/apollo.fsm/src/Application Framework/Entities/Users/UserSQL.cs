using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace Users
    {
        public class UserSQL
        {
            private Database _database;

            public UserSQL(Database databaseIn)
            {
                _database = databaseIn;
            }

            

            public bool Authenticate(string UserName, string Password)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserName", UserName);
                _database.AddParameter("@Password", Helper.HashPassword(Password));
                var dt = _database.ExecuteSP_DataTable("User_Login_Mk1");
                if (dt.Rows.Count > 0)
                {
                    App.loggedInUser = Get(Helper.MakeIntegerValid(dt.Rows[0]["UserID"]));
                    return true;
                }
                else
                {
                    App.loggedInUser = null;
                    return false;
                }
            }

            public int IsUserActive(string UserName = "", int UserID = 0, bool SetProperty = false)
            {
                _database.ClearParameter();
                if (!string.IsNullOrEmpty(UserName))
                    _database.AddParameter("@UserName", UserName);
                if (UserID > 0)
                    _database.AddParameter("@UserID", UserID);
                var dt = _database.ExecuteSP_DataTable("User_IsActive_Mk1");
                if (dt.Rows.Count > 0)
                {
                    if (SetProperty)
                        App.loggedInUser = Get(Helper.MakeIntegerValid(dt.Rows[0]["UserID"]), true);
                    return Conversions.ToInteger(true);
                }
                else
                {
                    return Conversions.ToInteger(false);
                }
            }

            public bool Check_Unique_Username(string username, int ID)
            {
                int NumberOfUsers = Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(Userid) as 'NumberOfUsers' " + "FROM tbluser WHERE deleted = 0 AND username = '" + username + "' AND userid <> " + ID, false));
                if (NumberOfUsers == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("User_GetAll_Mk1");
                dt.TableName = Enums.TableNames.tblUser.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_NoEngineers()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("User_GetAll_NoEngineers");
                dt.TableName = Enums.TableNames.tblUser.ToString();
                return new DataView(dt);
            }

            public User Get(int UserID, bool passExpired = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID);
                var dt = _database.ExecuteSP_DataTable("User_Get_Mk1");
                if (dt.Rows.Count > 0)
                {
                    var userAndEngineer = new User();
                    userAndEngineer.SetUserID = Helper.MakeIntegerValid(dt.Rows[0]["UserID"]);
                    userAndEngineer.SetFullname = Helper.MakeStringValid(dt.Rows[0]["Fullname"]);
                    userAndEngineer.SetUsername = Helper.MakeStringValid(dt.Rows[0]["Username"]);
                    userAndEngineer.SetPassword = Helper.MakeStringValid(dt.Rows[0]["Password"]);
                    userAndEngineer.SetEnabled = Helper.MakeBooleanValid(dt.Rows[0]["Enabled"]);
                    userAndEngineer.SetDeleted = Helper.MakeBooleanValid(dt.Rows[0]["Deleted"]);
                    userAndEngineer.SetAdmin = Helper.MakeBooleanValid(dt.Rows[0]["Admin"]);
                    userAndEngineer.SetSchedulerDayView = Helper.MakeBooleanValid(dt.Rows[0]["SchedulerDayView"]);
                    if (Information.IsDBNull(dt.Rows[0]["DefaultSchedulerEngineerGroup"]))
                    {
                        userAndEngineer.SetDefaultEngineerGroup = 0;
                    }
                    else
                    {
                        userAndEngineer.SetDefaultEngineerGroup = Helper.MakeIntegerValid(dt.Rows[0]["DefaultSchedulerEngineerGroup"]);
                    }

                    userAndEngineer.SetSchedulerTextSize = Helper.MakeIntegerValid(dt.Rows[0]["SchedulerTextSize"]);
                    userAndEngineer.SetEmailAddress = Helper.MakeStringValid(dt.Rows[0]["EmailAddress"]);
                    userAndEngineer.PasswordExpiryDate = Helper.MakeDateTimeValid(dt.Rows[0]["ExpiryDate"]);
                    userAndEngineer.SetUpdateAtLogon = passExpired || Helper.MakeBooleanValid(dt.Rows[0]["UpdateAtLogon"]);
                    userAndEngineer.SecurityUserModules = GetSecurityUserModules(UserID);
                    userAndEngineer.UserRegions = App.DB.User.UserRegions_Get(UserID);
                    userAndEngineer.Exists = true;
                    return userAndEngineer;
                }
                else
                {
                    return null;
                }
            }

            public User GetAsync(int UserID)
            {
                var dt = new DataTable();
                var command = new SqlCommand("User_Get_Mk1", new SqlConnection(_database.ServerConnectionString));
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    dt = _database.ExecuteCommand_DataTable(command);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    command.Connection.Close();
                }

                if (dt.Rows.Count > 0)
                {
                    var user = new User()
                    {
                        SetUserID = Helper.MakeIntegerValid(dt.Rows[0]["UserID"]),
                        SetFullname = Helper.MakeStringValid(dt.Rows[0]["Fullname"]),
                        SetUsername = Helper.MakeStringValid(dt.Rows[0]["Username"]),
                        SetPassword = Helper.MakeStringValid(dt.Rows[0]["Password"]),
                        SetEnabled = Helper.MakeBooleanValid(dt.Rows[0]["Enabled"]),
                        SetDeleted = Helper.MakeBooleanValid(dt.Rows[0]["Deleted"]),
                        SetAdmin = Helper.MakeBooleanValid(dt.Rows[0]["Admin"]),
                        SetSchedulerDayView = Helper.MakeBooleanValid(dt.Rows[0]["SchedulerDayView"]),
                        SetDefaultEngineerGroup = Helper.MakeIntegerValid(dt.Rows[0]["DefaultSchedulerEngineerGroup"]),
                        SetSchedulerTextSize = Helper.MakeIntegerValid(dt.Rows[0]["SchedulerTextSize"]),
                        SetEmailAddress = Helper.MakeStringValid(dt.Rows[0]["EmailAddress"]),
                        PasswordExpiryDate = Helper.MakeDateTimeValid(dt.Rows[0]["ExpiryDate"]),
                        SetUpdateAtLogon = Helper.MakeBooleanValid(dt.Rows[0]["UpdateAtLogon"])
                    };
                    user.SecurityUserModules = GetSecurityUserModules(UserID);
                    user.UserRegions = App.DB.User.UserRegions_Get(UserID);
                    user.Exists = true;
                    return user;
                }
                else
                {
                    return null;
                }
            }

            public DataView Get_Passwords(int UserID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID);
                var dt = _database.ExecuteSP_DataTable("UserPassword_Get_ForUser_Mk1");
                return new DataView(dt);
            }

            public bool UpdatePassword(int UserID, string Password, bool updateAtLogon = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID);
                _database.AddParameter("@Password", Helper.HashPassword(Password));
                _database.AddParameter("@UpdateAtLogon", updateAtLogon);
                _database.AddParameter("@ExpiryDate", DateAndTime.Now.AddMonths(3), true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("UserPassword_InsertUpdate_Mk1"), 1, false));
            }

            public string LastLogon(int UserID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID);
                try
                {
                    var datetime = Helper.MakeDateTimeValid(_database.ExecuteSP_OBJECT("User_LastLogon_Mk1"));
                    return "Last logon : " + Strings.Format(datetime, "dd/MMM/yyyy HH:mm:ss") + ".";
                }
                catch (Exception ex)
                {
                    return "This is your first logon.";
                }
            }

            public int Insert(User userAndEngineer)
            {
                _database.ClearParameter();
                _database.AddParameter("@Fullname", userAndEngineer.Fullname);
                _database.AddParameter("@Username", userAndEngineer.Username);
                _database.AddParameter("@Password", Helper.HashPassword(userAndEngineer.Password));
                _database.AddParameter("@DefaultSchedulerEngineerGroup", userAndEngineer.DefaultEngineerGroup);
                _database.AddParameter("@EmailAddress", userAndEngineer.EmailAddress);
                _database.AddParameter("@Enabled", userAndEngineer.Enabled, true);
                _database.AddParameter("@Admin", userAndEngineer.Admin, true);
                _database.AddParameter("@SchedulerDayView", userAndEngineer.SchedulerDayView, true);
                int id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("User_Insert_Mk1"));
                userAndEngineer.SetUserID = id;
                SaveSecurityUserModules(userAndEngineer);
                return id;
            }

            public void Update(User userAndEngineer)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userAndEngineer.UserID);
                _database.AddParameter("@Fullname", userAndEngineer.Fullname);
                _database.AddParameter("@Username", userAndEngineer.Username);
                _database.AddParameter("@Password", Helper.HashPassword(userAndEngineer.Password));
                _database.AddParameter("@DefaultSchedulerEngineerGroup", userAndEngineer.DefaultEngineerGroup);
                _database.AddParameter("@EmailAddress", userAndEngineer.EmailAddress);
                _database.AddParameter("@Enabled", userAndEngineer.Enabled, true);
                _database.AddParameter("@Admin", userAndEngineer.Admin, true);
                _database.AddParameter("@SchedulerDayView", userAndEngineer.SchedulerDayView, true);
                _database.ExecuteSP_OBJECT("User_Update_Mk1");
                SaveSecurityUserModules(userAndEngineer);
            }

            public void Delete(int UserID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID);
                _database.ExecuteSP_OBJECT("User_Delete_Mk1");
            }

            public DataView User_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                var dt = _database.ExecuteSP_DataTable("User_SearchList_Mk1");
                dt.TableName = Enums.TableNames.tblUser.ToString();
                return new DataView(dt);
            }

            public void User_Update_TextSize(int UserID, int TextSize)
            {
                _database.ClearParameter();
                _database.ExecuteScalar("UPDATE tblUser Set SchedulerTextSize = " + TextSize + " Where UserID = " + UserID);
            }

            
            

            public DataView GetSecurityUserModulesDefaults()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("SecurityUserModulesDefault_Get");
                dt.TableName = Enums.TableNames.tblUser.ToString();
                return new DataView(dt);
            }

            public DataView GetUserRegions(int userId)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userId, true);
                var dt = _database.ExecuteSP_DataTable("UserRegions_Get_ForUserID");
                dt.TableName = Enums.TableNames.tblRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetUserRegionsDefaults()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("UserRegions_Get_Defaults");
                dt.TableName = Enums.TableNames.tblRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetSecurityUserModules(int userID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userID, true);
                var dt = _database.ExecuteSP_DataTable("SecurityUserModules_Get");
                dt.TableName = Enums.TableNames.tblSecurityUserModules.ToString();
                return new DataView(dt);
            }

            private User SaveSecurityUserModules(User u)
            {
                if (u.SecurityUserModules is object)
                {
                    DataTable t = null;
                    t = u.SecurityUserModules.Table;
                    var diff = t.GetChanges();
                    if (diff is object)
                    {
                        string changes = string.Empty;
                        bool addAnd = false;
                        foreach (DataRow dr in diff.Rows)
                        {
                            if (addAnd)
                                changes += " and ";
                            changes += Helper.MakeStringValid(dr["ModuleName"]) + " set to " + Helper.MakeStringValid(dr["AccessPermitted"]);
                            addAnd = true;
                        }

                        if (!string.IsNullOrEmpty(changes))
                            UserAccessAudit_Insert(u.UserID, changes);
                    }

                    foreach (DataRow r in t.Rows)
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@UserID", u.UserID, true);
                        _database.AddParameter("@SystemModuleID", Conversions.ToInteger(r["SystemModuleID"]), true);
                        _database.AddParameter("@AccessPermitted", Conversions.ToBoolean(r["AccessPermitted"]), true);
                        if (Conversions.ToInteger(r["UserModuleID"]) == 0)
                        {
                            _database.ExecuteSP_NO_Return("SecurityUserModules_Insert");
                        }
                        else
                        {
                            _database.ExecuteSP_NO_Return("SecurityUserModules_Update");
                        }
                    }

                    u.SecurityUserModules = GetSecurityUserModules(u.UserID);
                }

                return u;
            }

            public void InsertNewSecurityUserModules(int UserID, int SystemModuleID, bool AccessPermitted)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", UserID, true);
                _database.AddParameter("@SystemModuleID", SystemModuleID, true);
                _database.AddParameter("@AccessPermitted", AccessPermitted, true);
                _database.ExecuteSP_NO_Return("SecurityUserModules_Insert");
            }

            public DataView UserRegions_Get(int userID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userID, true);
                var dt = _database.ExecuteSP_DataTable("UserRegions_Get");
                return new DataView(dt);
            }

            public void UserRegions_Insert(int userID, int managerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userID, true);
                _database.AddParameter("@RegionID", managerID, true);
                _database.ExecuteSP_OBJECT("UserRegion_Insert");
            }

            public void UserRegions_Delete(int userID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("DELETE FROM tblUserRegion Where UserID = " + userID);
            }

            public void UserAccessAudit_Insert(int userId, string actionChange)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userId, true);
                _database.AddParameter("@ActionChange", actionChange, true);
                _database.AddParameter("@ActionDateTime", DateTime.Now, true);
                _database.AddParameter("@AuthUserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("UserAccessAudit_Insert");
            }

            
        }
    }
}