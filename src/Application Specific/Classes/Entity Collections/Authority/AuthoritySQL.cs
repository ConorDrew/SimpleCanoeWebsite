using System;
using System.Data;

namespace FSM.Entity
{
    namespace Authority
    {
        public class AuthoritySQL
        {
            public enum GetBy
            {
                SiteId = 1,
                CustomerId = 2
            }

            private Sys.Database _database;

            public AuthoritySQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int authorityId)
            {
                _database.ClearParameter();
                _database.AddParameter("@AuthorityId", authorityId, true);
                _database.ExecuteSP_NO_Return("Authority_Delete");
            }

            public Authority Get(object @ref, GetBy getBy = GetBy.SiteId)
            {
                _database.ClearParameter();

                // Get the datatable from the database store in dt
                DataTable dt = null;
                switch (getBy)
                {
                    case GetBy.CustomerId:
                        {
                            _database.AddParameter("@CustomerId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("Authority_Get_ByCustomerId");
                            break;
                        }

                    case GetBy.SiteId:
                        {
                            _database.AddParameter("@SiteId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("Authority_Get_BySiteId");
                            break;
                        }

                    default:
                        {
                            _database.AddParameter("@AuthorityId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("Authority_Get");
                            break;
                        }
                }

                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oAuthority = new Authority();
                        oAuthority.IgnoreExceptionsOnSetMethods = true;
                        if (dt.Columns.Contains("AuthorityId"))
                            oAuthority.SetAuthorityId = Sys.Helper.MakeIntegerValid(dt.Rows[0]["AuthorityId"]);
                        if (dt.Columns.Contains("Notes"))
                            oAuthority.SetNotes = Sys.Helper.MakeStringValid(dt.Rows[0]["Notes"]);
                        if (dt.Columns.Contains("DateAdded"))
                            oAuthority.DateAdded = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateAdded"]);
                        if (dt.Columns.Contains("AddedById"))
                            oAuthority.SetAddedById = Sys.Helper.MakeIntegerValid(dt.Rows[0]["AddedById"]);
                        if (dt.Columns.Contains("LastChanged"))
                            oAuthority.LastChanged = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["LastChanged"]);
                        if (dt.Columns.Contains("LastChangedById"))
                            oAuthority.SetLastChangedById = Sys.Helper.MakeIntegerValid(dt.Rows[0]["LastChangedById"]);
                        oAuthority.Exists = true;
                        return oAuthority;
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

            public Authority Insert(Authority oAuthority)
            {
                _database.ClearParameter();
                _database.AddParameter("@Notes", oAuthority.Notes, true);
                _database.AddParameter("@DateAdded", DateTime.Now, true);
                _database.AddParameter("@AddedById", App.loggedInUser.UserID, true);
                _database.AddParameter("@LastChanged", DateTime.Now, true);
                _database.AddParameter("@LastChangedById", App.loggedInUser.UserID, true);
                oAuthority.SetAuthorityId = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Authority_Insert"));
                oAuthority.Exists = true;

                // INSERT AUDIT RECORD
                string change = "Added: " + oAuthority.Notes;
                Audit_Insert(oAuthority.AuthorityId, change);
                return oAuthority;
            }

            public bool Insert_Site(int siteId, Authority oAuthority)
            {
                try
                {
                    var auth = Insert(oAuthority);
                    _database.ClearParameter();
                    _database.AddParameter("@SiteId", siteId, true);
                    _database.AddParameter("@AuthorityId", auth.AuthorityId, true);
                    _database.ExecuteSP_OBJECT("SiteAuthority_Insert");
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public bool Insert_Customer(int customerId, Authority oAuthority)
            {
                try
                {
                    var auth = Insert(oAuthority);
                    _database.ClearParameter();
                    _database.AddParameter("@CustomerId", customerId, true);
                    _database.AddParameter("@AuthorityId", auth.AuthorityId, true);
                    _database.ExecuteSP_OBJECT("CustomerAuthority_Insert");
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public void Update(Authority oAuthority, string change)
            {
                _database.ClearParameter();
                _database.AddParameter("@AuthorityId", oAuthority.AuthorityId, true);
                _database.AddParameter("@Notes", oAuthority.Notes, true);
                _database.AddParameter("@LastChanged", DateTime.Now, true);
                _database.AddParameter("@LastChangedById", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("Authority_Update");

                // INSERT AUDIT RECORD
                if (string.IsNullOrEmpty(change))
                    return;
                Audit_Insert(oAuthority.AuthorityId, change);
            }

            public void Audit_Insert(int authorityId, string actionChange)
            {
                _database.ClearParameter();
                _database.AddParameter("@AuthorityId", authorityId, true);
                _database.AddParameter("@ActionChange", actionChange, true);
                _database.AddParameter("@ActionDateTime", DateTime.Now, true);
                _database.AddParameter("@UserId", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("AuthorityAudit_Insert");
            }

            public DataView Audit_Get(object @ref, GetBy getBy = GetBy.SiteId)
            {
                _database.ClearParameter();
                DataTable dt = null;
                switch (getBy)
                {
                    case GetBy.CustomerId:
                        {
                            _database.AddParameter("@CustomerId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get_ByCustomerId");
                            break;
                        }

                    case GetBy.SiteId:
                        {
                            _database.AddParameter("@SiteId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get_BySiteId");
                            break;
                        }

                    default:
                        {
                            _database.AddParameter("@AuthorityId", Sys.Helper.MakeIntegerValid(@ref), true);
                            dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get");
                            break;
                        }
                }

                dt.TableName = Sys.Enums.TableNames.tblAuthority.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}