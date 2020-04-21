using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.Sys
{
    public class TransactionalDatabase
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public SqlTransaction Transaction_Get()
        {
            var c = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
            try
            {
                c.Open();
                return c.BeginTransaction(IsolationLevel.ReadUncommitted);
            }
            catch
            {
                if (!(c.State == ConnectionState.Closed))
                {
                    c.Close();
                }

                c.Dispose();
                throw;
            }
        }

        public SqlCommand CreateStoredProcedure(string spName, SqlTransaction Trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = spName;
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = Trans;
            return Command;
        }

        public void ExecuteNonQuerySPTrans(SqlCommand cmd)
        {
            cmd.Connection = cmd.Transaction.Connection;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable ExecuteTableSPTrans(SqlCommand cmd)
        {
            cmd.Connection = cmd.Transaction.Connection;
            try
            {
                var Adapter = new SqlDataAdapter(cmd);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                return returnDS.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ExecuteScalarSPTrans(SqlCommand cmd)
        {
            cmd.Connection = cmd.Transaction.Connection;
            try
            {
                return Helper.MakeIntegerValid(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Transaction_Commit(SqlTransaction trans)
        {
            var con = trans.Connection;
            trans.Commit();
            con.Close();
        }

        public void Transaction_Rollback(SqlTransaction trans)
        {
            var con = trans.Connection;
            trans.Rollback();
            con.Close();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}