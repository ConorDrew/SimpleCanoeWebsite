// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisits.EngineerVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Assets;
using FSM.Entity.EngineerVisitsPartsAndProducts;
using FSM.Entity.EngineerVisitTimeSheets;
using FSM.Entity.JobAssets;
using FSM.Entity.JobAudits;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.OrderParts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM.Entity.EngineerVisits
{
    public class EngineerVisitSQL
    {
        private Database _database;

        public EngineerVisitSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.ExecuteSP_NO_Return("EngineerVisit_Delete", true);
            App.DB.JobAudit.Insert(new JobAudit()
            {
                SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID).JobID,
                SetActionChange = (object)("Visit Deleted (Unique Visit ID: " + Conversions.ToString(EngineerVisitID) + ")")
            });
        }

        public void Delete(int EngineerVisitID, SqlTransaction trans)
        {
            new SqlCommand()
            {
                CommandText = "EngineerVisit_Delete",
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection,
                Parameters = {
          new SqlParameter("@EngineerVisitID", (object) EngineerVisitID)
        }
            }.ExecuteNonQuery();
            App.DB.JobAudit.Insert(new JobAudit()
            {
                SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, trans).JobID,
                SetActionChange = (object)("Visit Deleted: (" + Conversions.ToString(EngineerVisitID) + ")")
            }, trans);
        }

        public EngineerVisit Insert(
          EngineerVisit oEngineerVisit,
          int JobID,
          SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "EngineerVisit_Insert";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.Add(new SqlParameter("@JobOfWorkID", (object)oEngineerVisit.JobOfWorkID));
            sqlCommand.Parameters.Add(new SqlParameter("@EngineerID", (object)oEngineerVisit.EngineerID));
            sqlCommand.Parameters.Add(new SqlParameter("@Deleted", (object)oEngineerVisit.Deleted));
            if ((uint)DateTime.Compare(oEngineerVisit.StartDateTime, DateTime.MinValue) > 0U)
                sqlCommand.Parameters.Add(new SqlParameter("@StartDateTime", (object)oEngineerVisit.StartDateTime));
            else
                sqlCommand.Parameters.Add(new SqlParameter("@StartDateTime", (object)DBNull.Value));
            if ((uint)DateTime.Compare(oEngineerVisit.EndDateTime, DateTime.MinValue) > 0U)
                sqlCommand.Parameters.Add(new SqlParameter("@EndDateTime", (object)oEngineerVisit.EndDateTime));
            else
                sqlCommand.Parameters.Add(new SqlParameter("@EndDateTime", (object)DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@StatusEnumID", (object)oEngineerVisit.StatusEnumID));
            sqlCommand.Parameters.Add(new SqlParameter("@NotesToEngineer", (object)oEngineerVisit.NotesToEngineer));
            sqlCommand.Parameters.Add(new SqlParameter("@PartsToFit", (object)oEngineerVisit.PartsToFit));
            sqlCommand.Parameters.Add(new SqlParameter("@ExpectedEngineerID", (object)oEngineerVisit.ExpectedEngineerID));
            sqlCommand.Parameters.Add(new SqlParameter("@AMPM", (object)oEngineerVisit.AMPM));
            sqlCommand.Parameters.Add(new SqlParameter("@VisitNumber", (object)oEngineerVisit.VisitNumber));
            if (DateTime.Compare(oEngineerVisit.DueDate, DateTime.MinValue) == 0)
                sqlCommand.Parameters.Add(new SqlParameter("@DueDate", (object)DBNull.Value));
            else
                sqlCommand.Parameters.Add(new SqlParameter("@DueDate", (object)oEngineerVisit.DueDate));
            sqlCommand.Parameters.Add(new SqlParameter("@Recharge", (object)oEngineerVisit.Recharge));
            sqlCommand.Parameters.Add(new SqlParameter("@ExcludeFromTextMessage", (object)oEngineerVisit.ExcludeFromTextMessage));
            sqlCommand.Parameters.Add(new SqlParameter("@RechargeType", (object)oEngineerVisit.RechargeTypeID));
            sqlCommand.Parameters.Add(new SqlParameter("@NccRadID", (object)oEngineerVisit.NccRadID));
            sqlCommand.Parameters.Add(new SqlParameter("@MeterLocationID", (object)oEngineerVisit.MeterLocationID));
            sqlCommand.Parameters.Add(new SqlParameter("@MeterCappedID", (object)oEngineerVisit.MeterCappedID));
            sqlCommand.Parameters.Add(new SqlParameter("@ExpectedDepartment", (object)oEngineerVisit.ExpectedDepartment));
            sqlCommand.Parameters.Add(new SqlParameter("@FuelID", (object)oEngineerVisit.FuelID));
            oEngineerVisit.SetEngineerVisitID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oEngineerVisit.Exists = true;
            App.DB.JobAudit.Insert(new JobAudit()
            {
                SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID,
                SetActionChange = (object)("New Visit Inserted - Status: " + Microsoft.VisualBasic.Strings.Replace(((Enums.VisitStatus)oEngineerVisit.StatusEnumID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")")
            }, trans);
            App.DB.EngineerVisitPartProductAllocated.NewInsert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID, trans);
            return oEngineerVisit;
        }

        public EngineerVisit Insert(
          EngineerVisit oEngineerVisit,
          int JobID,
          int appointmentID = 0,
          int oldVisitId = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object)oEngineerVisit.JobOfWorkID, true);
            this._database.AddParameter("@EngineerID", (object)oEngineerVisit.EngineerID, true);
            this._database.AddParameter("@Deleted", (object)oEngineerVisit.Deleted, true);
            this._database.AddParameter("@StartDateTime", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oEngineerVisit.StartDateTime)), true);
            this._database.AddParameter("@EndDateTime", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oEngineerVisit.EndDateTime)), true);
            this._database.AddParameter("@StatusEnumID", (object)oEngineerVisit.StatusEnumID, true);
            this._database.AddParameter("@NotesToEngineer", (object)oEngineerVisit.NotesToEngineer, true);
            this._database.AddParameter("@PartsToFit", (object)oEngineerVisit.PartsToFit, true);
            this._database.AddParameter("@ExpectedEngineerID", (object)oEngineerVisit.ExpectedEngineerID, true);
            this._database.AddParameter("@AMPM", (object)oEngineerVisit.AMPM, true);
            this._database.AddParameter("@VisitNumber", (object)oEngineerVisit.VisitNumber, false);
            this._database.AddParameter("@DueDate", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oEngineerVisit.DueDate)), true);
            this._database.AddParameter("@Recharge", (object)oEngineerVisit.Recharge, false);
            this._database.AddParameter("@RechargeType", (object)oEngineerVisit.RechargeTypeID, false);
            this._database.AddParameter("@NccRadID", (object)oEngineerVisit.NccRadID, false);
            this._database.AddParameter("@MeterCappedID", (object)oEngineerVisit.MeterCappedID, false);
            this._database.AddParameter("@MeterLocationID", (object)oEngineerVisit.MeterLocationID, false);
            if (oEngineerVisit.AppointmentID > 0)
                this._database.AddParameter("@AppointmentID", (object)oEngineerVisit.AppointmentID, true);
            else
                this._database.AddParameter("@AppointmentID", (object)appointmentID, true);
            this._database.AddParameter("@ExpectedDepartment", (object)oEngineerVisit.ExpectedDepartment, true);
            this._database.AddParameter("@FuelID", (object)oEngineerVisit.FuelID, true);
            this._database.AddParameter("@OldVisitId", (object)oldVisitId, true);
            oEngineerVisit.SetEngineerVisitID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisit_Insert", true)));
            oEngineerVisit.Exists = true;
            JobAudit oJobAudit = new JobAudit()
            {
                SetJobID = (object)JobID
            };
            if (oEngineerVisit.StatusEnumID == 5)
                oJobAudit.SetActionChange = (object)("New Visit Inserted - Status: Scheduled, to Engineer: " + App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)?.Name + " For " + Microsoft.VisualBasic.Strings.Format((object)oEngineerVisit.StartDateTime, "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")");
            else
                oJobAudit.SetActionChange = (object)("New Visit Inserted - Status: " + Microsoft.VisualBasic.Strings.Replace(((Enums.VisitStatus)oEngineerVisit.StatusEnumID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")");
            App.DB.JobAudit.Insert(oJobAudit);
            App.DB.EngineerVisitPartProductAllocated.Insert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID);
            return oEngineerVisit;
        }

        public bool EngineerVisits_UpdateStatus(
          int engineerVisitID,
          int statusEnumID,
          int outcomeEnumID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)engineerVisitID, true);
            this._database.AddParameter("@VisitStatusID", (object)statusEnumID, true);
            this._database.AddParameter("@OutcomeID", (object)outcomeEnumID, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(EngineerVisits_UpdateStatus)) == 1;
        }

        public bool EngineerVisit_ManualUpload(EngineerVisit engineerVisit)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)engineerVisit.EngineerVisitID, true);
            this._database.AddParameter("@StatusEnumID", (object)engineerVisit.StatusEnumID, true);
            this._database.AddParameter("@OutcomeEnumID", (object)engineerVisit.OutcomeEnumID, true);
            this._database.AddParameter("@NotesFromEngineer", (object)engineerVisit.NotesFromEngineer, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(EngineerVisit_ManualUpload)) == 1;
        }

        public EngineerVisit Update(
          EngineerVisit oEngineerVisit,
          int JobID,
          bool justStatus)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StatusEnumID", (object)oEngineerVisit.StatusEnumID, true);
            this._database.AddParameter("@NotesToEngineer", (object)oEngineerVisit.NotesToEngineer, true);
            this._database.AddParameter("@EngineerVisitID", (object)oEngineerVisit.EngineerVisitID, true);
            this._database.AddParameter("@PartsToFit", (object)oEngineerVisit.PartsToFit, true);
            this._database.AddParameter("@ExpectedEngineerID", (object)oEngineerVisit.ExpectedEngineerID, true);
            this._database.AddParameter("@Recharge", (object)oEngineerVisit.Recharge, true);
            this._database.AddParameter("@RechargeType", (object)oEngineerVisit.RechargeTypeID, true);
            this._database.AddParameter("@NccRadID", (object)oEngineerVisit.NccRadID, true);
            this._database.AddParameter("@MeterCappedID", (object)oEngineerVisit.MeterCappedID, true);
            this._database.AddParameter("@MeterLocationID", (object)oEngineerVisit.MeterLocationID, true);
            this._database.AddParameter("@VisitLocked", (object)oEngineerVisit.VisitLocked, true);
            this._database.AddParameter("@ExcludeFromTextMessage", (object)oEngineerVisit.ExcludeFromTextMessage, true);
            this._database.AddParameter("@EngineerID", (object)oEngineerVisit.EngineerID, true);
            if ((uint)DateTime.Compare(oEngineerVisit.StartDateTime, DateTime.MinValue) > 0U | (uint)DateTime.Compare(oEngineerVisit.StartDateTime, DateTime.MinValue) > 0U)
                this._database.AddParameter("@StartDateTime", (object)oEngineerVisit.StartDateTime, true);
            else
                this._database.AddParameter("@StartDateTime", (object)DBNull.Value, true);
            if ((uint)DateTime.Compare(oEngineerVisit.EndDateTime, DateTime.MinValue) > 0U | (uint)DateTime.Compare(oEngineerVisit.EndDateTime, DateTime.MinValue) > 0U)
                this._database.AddParameter("@EndDateTime", (object)oEngineerVisit.EndDateTime, true);
            else
                this._database.AddParameter("@EndDateTime", (object)DBNull.Value, true);
            this._database.AddParameter("@ExpectedDepartment", (object)oEngineerVisit.ExpectedDepartment, false);
            this._database.AddParameter("@FuelID", (object)oEngineerVisit.FuelID, false);
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisit_Update", true))))
                App.DB.JobAudit.Insert(new JobAudit()
                {
                    SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID,
                    SetActionChange = (object)("Visit Status changed to " + Microsoft.VisualBasic.Strings.Replace(((Enums.VisitStatus)oEngineerVisit.StatusEnumID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")")
                });
            string str = "";
            if (!justStatus)
            {
                foreach (DataRow current in oEngineerVisit.PartsAndProductsAllocated.Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderItemID"], (object)0, false))
                        str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object)str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)" * ", current["Name"]), (object)", "), current["Number"]), (object)", "), current["Quantity"]), (object)"\r\n")));
                }

                DataTable dataTable = new DataTable();
                DataTable table = oEngineerVisit.PartsAndProductsAllocated.Table.Clone();
                DataRow[] dataRowArray1 = oEngineerVisit.PartsAndProductsAllocated.Table.Select("OrderItemID = 0 OR  QuantityOrdered  < Quantity ");
                int index1 = 0;
                while (index1 < dataRowArray1.Length)
                {
                    DataRow dataRow = dataRowArray1[index1];
                    table.Rows.Add(dataRow.ItemArray);
                    checked { ++index1; }
                }
                if (str.Length > 0 && MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: \r\n" + str + "\r\n Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    App.ShowForm(typeof(FRMConvertToAnOrder), true, new object[5]
                    {
            (object) 4,
            (object) JobID,
            (object) new DataView(table),
            (object) 0,
            (object) oEngineerVisit.EngineerVisitID
                    }, false);
                    foreach (DataRow current in table.Rows)
                    {
                        current.AcceptChanges();
                        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Quantity"])))
                            current["Quantity"] = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
                        App.DB.EngineerVisitPartProductAllocated.UpdateOne(Conversions.ToInteger(current["ID"]), oEngineerVisit.EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"])));
                    }
                }
                DataRow[] dataRowArray2 = table.Select("ID IS NULL OR ID = 0");
                int index2 = 0;
                while (index2 < dataRowArray2.Length)
                {
                    DataRow dataRow = dataRowArray2[index2];
                    App.DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, Conversions.ToString(dataRow["Type"]), Conversions.ToInteger(dataRow["Quantity"]), Conversions.ToInteger(dataRow["OrderItemID"]), Conversions.ToInteger(dataRow["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["OrderLocationTypeID"])));
                    checked { ++index2; }
                }
            }
            return oEngineerVisit;
        }

        public EngineerVisit Update(
          EngineerVisit oEngineerVisit,
          int JobID,
          bool justStatus,
          SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "EngineerVisit_Update";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@StatusEnumID", (object)oEngineerVisit.StatusEnumID);
            sqlCommand.Parameters.AddWithValue("@NotesToEngineer", (object)oEngineerVisit.NotesToEngineer);
            sqlCommand.Parameters.AddWithValue("@EngineerVisitID", (object)oEngineerVisit.EngineerVisitID);
            sqlCommand.Parameters.AddWithValue("@PartsToFit", (object)oEngineerVisit.PartsToFit);
            sqlCommand.Parameters.AddWithValue("@ExpectedEngineerID", (object)oEngineerVisit.ExpectedEngineerID);
            sqlCommand.Parameters.AddWithValue("@Recharge", (object)oEngineerVisit.Recharge);
            sqlCommand.Parameters.AddWithValue("@RechargeType", (object)oEngineerVisit.RechargeTypeID);
            sqlCommand.Parameters.AddWithValue("@NccRadID", (object)oEngineerVisit.NccRadID);
            sqlCommand.Parameters.AddWithValue("@MeterCappedID", (object)oEngineerVisit.MeterCappedID);
            sqlCommand.Parameters.AddWithValue("@MeterLocationID", (object)oEngineerVisit.MeterLocationID);
            sqlCommand.Parameters.AddWithValue("@ExpectedDepartment", (object)oEngineerVisit.MeterLocationID);
            sqlCommand.Parameters.AddWithValue("@FuelID", (object)oEngineerVisit.FuelID);
            sqlCommand.Parameters.AddWithValue("@ExcludeFromTextMessage ", (object)oEngineerVisit.ExcludeFromTextMessage);
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())))
                App.DB.JobAudit.Insert(new JobAudit()
                {
                    SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID,
                    SetActionChange = (object)("Visit Status changed to " + Microsoft.VisualBasic.Strings.Replace(((Enums.VisitStatus)oEngineerVisit.StatusEnumID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")")
                }, trans);
            foreach (DataRow current in oEngineerVisit.PartsAndProductsAllocated.Table.Rows)
            {
                if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ID"])) == 0)
                    App.DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderItemID"])), Conversions.ToInteger(current["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"])), trans);
            }

            oEngineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID, trans);
            if (oEngineerVisit.Change)
                App.DB.JobAudit.Insert(new JobAudit()
                {
                    SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID,
                    SetActionChange = (object)("Engineer Notes have been altered  (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")")
                });
            return oEngineerVisit;
        }

        public DataView EngineerVisits_Get_All_JobID(int jobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@jobID", (object)jobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_All_JobID), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_All_JobNumber_Light(string jobNumber)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobNumber", (object)jobNumber, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_All_JobNumber_Light), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_All_JobID(int jobID, SqlTransaction trans)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = nameof(EngineerVisits_Get_All_JobID),
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection,
                Parameters = {
          new SqlParameter("@jobID", (object) jobID)
        }
            });
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_ForVal(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_ForVal), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitSymptom_GetForVisit(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitSymptom_GetForVisit), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get(int EngineerVisitID, SqlTransaction trans)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = nameof(EngineerVisits_Get),
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection,
                Parameters = {
          new SqlParameter("@EngineerVisitID", (object) EngineerVisitID)
        }
            });
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisit_GetUpdate(int Where)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)Enums.InvoiceType.Visit, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)Enums.VisitStatus.Invoiced, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)Enums.VisitStatus.Ready_To_Be_Invoiced, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)Enums.VisitStatus.Not_To_Be_Invoiced, true);
            this._database.AddParameter("@Where", (object)Where, true);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisits_GetUpdate", true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_All(string Where)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)Enums.InvoiceType.Visit, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)Enums.VisitStatus.Invoiced, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)Enums.VisitStatus.Ready_To_Be_Invoiced, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)Enums.VisitStatus.Not_To_Be_Invoiced, true);
            this._database.AddParameter("@Where", (object)Where, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_All), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Manager_Get_ByWhere(string Where, string addtionalWhere = "")
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)Enums.InvoiceType.Visit, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)Enums.VisitStatus.Invoiced, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)Enums.VisitStatus.Ready_To_Be_Invoiced, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)Enums.VisitStatus.Not_To_Be_Invoiced, true);
            this._database.AddParameter("@Where", (object)Where, true);
            this._database.AddParameter("@Where2", (object)addtionalWhere, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Manager_Get_ByWhere), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerPerformance_Get(
          int Dept,
          int EngineerID,
          DateTime StartDate,
          DateTime EndDate,
          string performanceType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Dept", (object)Dept, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@EndDate", (object)EndDate, true);
            this._database.AddParameter("@PerType", (object)performanceType, true);
            DataTable table = this._database.ExecuteSP_DataTable("Engineer_Get_Performance", true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Appliances_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Appliances_GetAll), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataTable EngineerVisits_VisitManager_New(
          int CustomerID,
          int SiteID,
          int EngineerID,
          int JobDefinitionEnumID,
          int JobTypeID,
          int VisitEnumID,
          int OutcomeEnumID,
          string JobNumber,
          string PONumber,
          string Postcode,
          DateTime? DateFrom,
          DateTime? DateTo,
          int RegionID,
          int ContractTypeID,
          string LetterType,
          DateTime? DueDateFrom,
          DateTime? DueDateTo,
          int ChargeInProgress,
          string CostsTo)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@totalRowCount", (object)0, true);
            this._database.AddParameter("@sortBy", (object)"1", true);
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)260, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)10, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)9, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)8, true);
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.AddParameter("@JobDefinitionEnumID", (object)JobDefinitionEnumID, true);
            this._database.AddParameter("@JobTypeID", (object)JobTypeID, true);
            this._database.AddParameter("@VisitEnumID", (object)VisitEnumID, true);
            this._database.AddParameter("@OutcomeEnumID", (object)OutcomeEnumID, true);
            this._database.AddParameter("@JobNumber", (object)JobNumber, true);
            this._database.AddParameter("@PONumber", (object)PONumber, true);
            this._database.AddParameter("@Postcode", (object)Postcode, true);
            this._database.AddParameter("@DateFrom", (object)DateFrom, true);
            this._database.AddParameter("@DateTo", (object)DateTo, true);
            this._database.AddParameter("@RegionID", (object)RegionID, true);
            this._database.AddParameter("@ContractTypeID", (object)ContractTypeID, true);
            this._database.AddParameter("@LetterType", (object)LetterType, true);
            this._database.AddParameter("@DueDateFrom", (object)DueDateFrom, true);
            this._database.AddParameter("@DueDateTo", (object)DueDateTo, true);
            this._database.AddParameter("@ChargeInProgress", (object)ChargeInProgress, true);
            this._database.AddParameter("@CostsTo", (object)CostsTo, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Manager_Search_NEW", true);
            dataTable.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return dataTable;
        }

        public DataView EngineerVisits_Get_All_ForSite(string Where)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)Enums.InvoiceType.Visit, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)Enums.VisitStatus.Invoiced, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)Enums.VisitStatus.Ready_To_Be_Invoiced, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)Enums.VisitStatus.Not_To_Be_Invoiced, true);
            this._database.AddParameter("@Where", (object)Where, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_All_ForSite), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_AllReady_ForSite(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_AllReady_ForSite), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Search(string Criteria, bool HideCompleted = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)Criteria, true);
            if (HideCompleted)
                this._database.AddParameter("@MaximumStatusID", (object)6, true);
            else
                this._database.AddParameter("@MaximumStatusID", (object)7, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Search), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_For_Job_Of_Work(
          int JobOfWorkID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(EngineerVisits_Get_For_Job_Of_Work);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@JobOfWorkID", (object)JobOfWorkID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_For_Job_Of_Work(int JobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object)JobOfWorkID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_For_Job_Of_Work), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisits_Get_For_Job_Of_Work_Light(int JobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object)JobOfWorkID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisits_Get_For_Job_Of_Work_Light), true);
            table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
            return new DataView(table);
        }

        public EngineerVisit EngineerVisits_Get_As_Object(
          int EngineerVisitID,
          bool getFull = true)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get", true);
            if (dataTable.Rows.Count <= 0)
                return (EngineerVisit)null;
            DataRow row = dataTable.Rows[0];
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.Exists = true;
            engineerVisit.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(row[nameof(EngineerVisitID)]);
            engineerVisit.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOfWorkID"]);
            engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(row["EngineerID"]);
            engineerVisit.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["StartDateTime"]));
            engineerVisit.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["EndDateTime"]));
            engineerVisit.SetStatusEnumID = RuntimeHelpers.GetObjectValue(row["StatusEnumID"]);
            engineerVisit.SetVisitStatus = RuntimeHelpers.GetObjectValue(row["VisitStatus"]);
            engineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(row["NotesToEngineer"]);
            engineerVisit.SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(row["NotesFromEngineer"]);
            engineerVisit.SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(row["OutcomeEnumID"]);
            engineerVisit.SetOutcomeDetails = RuntimeHelpers.GetObjectValue(row["OutcomeDetails"]);
            engineerVisit.SetCustomerName = RuntimeHelpers.GetObjectValue(row["CustomerName"]);
            engineerVisit.SetVisitOutcome = RuntimeHelpers.GetObjectValue(row["VisitOutcome"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["CustomerSignature"])))
                engineerVisit.CustomerSignature = (byte[])row["CustomerSignature"];
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["EngineerSignature"])))
                engineerVisit.EngineerSignature = (byte[])row["EngineerSignature"];
            engineerVisit.Downloading = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Downloading"])) ? Conversions.ToDate(row["Downloading"]) : DateTime.MinValue;
            engineerVisit.SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(row["ManualEntryByUserID"]);
            engineerVisit.ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["ManualEntryOn"]));
            engineerVisit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
            engineerVisit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
            engineerVisit.SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(row["GasInstallationTightnessTestID"]);
            engineerVisit.SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(row["EmergencyControlAccessibleID"]);
            engineerVisit.SetBondingID = RuntimeHelpers.GetObjectValue(row["BondingID"]);
            engineerVisit.SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(row["ExpectedEngineerID"]);
            engineerVisit.SetPropertyRented = RuntimeHelpers.GetObjectValue(row["PropertyRented"]);
            engineerVisit.SetPaymentMethodID = RuntimeHelpers.GetObjectValue(row["PaymentMethodID"]);
            engineerVisit.SetAmountCollected = RuntimeHelpers.GetObjectValue(row["AmountCollected"]);
            engineerVisit.SetSignatureSelectedID = RuntimeHelpers.GetObjectValue(row["SignatureSelectedID"]);
            engineerVisit.SetPartsToFit = RuntimeHelpers.GetObjectValue(row["PartsToFit"]);
            engineerVisit.SetGasServiceCompleted = RuntimeHelpers.GetObjectValue(row["GasServiceCompleted"]);
            engineerVisit.SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["EmailReceipt"]));
            engineerVisit.DueDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["DueDate"]));
            engineerVisit.SetAMPM = RuntimeHelpers.GetObjectValue(row["AMPM"]);
            engineerVisit.SetVisitNumber = RuntimeHelpers.GetObjectValue(row["VisitNumber"]);
            engineerVisit.SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["Recharge"]));
            engineerVisit.SetCostsTo = RuntimeHelpers.GetObjectValue(row["CostsTo"]);
            engineerVisit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
            engineerVisit.setRechargeTypeID = RuntimeHelpers.GetObjectValue(row["RechargeType"]);
            engineerVisit.setNccRadID = RuntimeHelpers.GetObjectValue(row["NccRadID"]);
            engineerVisit.SetUseSORDescription = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["UseSORDescription"]));
            engineerVisit.SetMeterCappedID = RuntimeHelpers.GetObjectValue(row["MeterCappedID"]);
            engineerVisit.SetMeterLocationID = RuntimeHelpers.GetObjectValue(row["MeterLocationID"]);
            if (row.Table.Columns.Contains("FuelID"))
                engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(row["FuelID"]);
            if (row.Table.Columns.Contains("ExcludeFromTextMessage"))
                engineerVisit.SetExcludeFromTextMessage = RuntimeHelpers.GetObjectValue(row["ExcludeFromTextMessage"]);
            if (getFull)
            {
                engineerVisit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID);
                engineerVisit.TimeSheets = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
                engineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(engineerVisit.EngineerVisitID);
                engineerVisit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(engineerVisit.EngineerVisitID);
                engineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID);
            }
            return engineerVisit;
        }

        public EngineerVisit EngineerVisits_Get_New_As_Object(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get_New", true);
            if (dataTable.Rows.Count <= 0)
                return (EngineerVisit)null;
            DataRow row = dataTable.Rows[0];
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.Exists = true;
            engineerVisit.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(row[nameof(EngineerVisitID)]);
            engineerVisit.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOfWorkID"]);
            engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(row["EngineerID"]);
            engineerVisit.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["StartDateTime"]));
            engineerVisit.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["EndDateTime"]));
            engineerVisit.SetStatusEnumID = RuntimeHelpers.GetObjectValue(row["StatusEnumID"]);
            engineerVisit.SetVisitStatus = RuntimeHelpers.GetObjectValue(row["VisitStatus"]);
            engineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(row["NotesToEngineer"]);
            engineerVisit.SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(row["NotesFromEngineer"]);
            engineerVisit.SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(row["OutcomeEnumID"]);
            engineerVisit.SetOutcomeDetails = RuntimeHelpers.GetObjectValue(row["OutcomeDetails"]);
            engineerVisit.SetCustomerName = RuntimeHelpers.GetObjectValue(row["CustomerName"]);
            engineerVisit.SetVisitOutcome = RuntimeHelpers.GetObjectValue(row["VisitOutcome"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["CustomerSignature"])))
                engineerVisit.CustomerSignature = (byte[])row["CustomerSignature"];
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["EngineerSignature"])))
                engineerVisit.EngineerSignature = (byte[])row["EngineerSignature"];
            engineerVisit.Downloading = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Downloading"])) ? Conversions.ToDate(row["Downloading"]) : DateTime.MinValue;
            engineerVisit.SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(row["ManualEntryByUserID"]);
            engineerVisit.ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["ManualEntryOn"]));
            engineerVisit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
            engineerVisit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
            engineerVisit.SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(row["GasInstallationTightnessTestID"]);
            engineerVisit.SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(row["EmergencyControlAccessibleID"]);
            engineerVisit.SetBondingID = RuntimeHelpers.GetObjectValue(row["BondingID"]);
            engineerVisit.SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(row["ExpectedEngineerID"]);
            engineerVisit.SetPropertyRented = RuntimeHelpers.GetObjectValue(row["PropertyRented"]);
            engineerVisit.SetPaymentMethodID = RuntimeHelpers.GetObjectValue(row["PaymentMethodID"]);
            engineerVisit.SetAmountCollected = RuntimeHelpers.GetObjectValue(row["AmountCollected"]);
            engineerVisit.SetSignatureSelectedID = RuntimeHelpers.GetObjectValue(row["SignatureSelectedID"]);
            engineerVisit.SetPartsToFit = RuntimeHelpers.GetObjectValue(row["PartsToFit"]);
            engineerVisit.SetGasServiceCompleted = RuntimeHelpers.GetObjectValue(row["GasServiceCompleted"]);
            engineerVisit.SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["EmailReceipt"]));
            engineerVisit.DueDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["DueDate"]));
            engineerVisit.SetAMPM = RuntimeHelpers.GetObjectValue(row["AMPM"]);
            engineerVisit.SetVisitNumber = RuntimeHelpers.GetObjectValue(row["VisitNumber"]);
            engineerVisit.SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["Recharge"]));
            engineerVisit.SetCostsTo = RuntimeHelpers.GetObjectValue(row["CostsTo"]);
            engineerVisit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
            engineerVisit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID);
            engineerVisit.TimeSheets = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
            engineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(engineerVisit.EngineerVisitID);
            engineerVisit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(engineerVisit.EngineerVisitID);
            engineerVisit.setRechargeTypeID = RuntimeHelpers.GetObjectValue(row["RechargeType"]);
            engineerVisit.setNccRadID = RuntimeHelpers.GetObjectValue(row["NccRadID"]);
            engineerVisit.SetUseSORDescription = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["UseSORDescription"]));
            engineerVisit.SetMeterCappedID = RuntimeHelpers.GetObjectValue(row["MeterCappedID"]);
            engineerVisit.SetMeterLocationID = RuntimeHelpers.GetObjectValue(row["MeterLocationID"]);
            engineerVisit.SetExpectedDepartment = RuntimeHelpers.GetObjectValue(row["ExpectedDepartment"]);
            if (row.Table.Columns.Contains("FuelID"))
                engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(row["FuelID"]);
            return engineerVisit;
        }

        public EngineerVisit EngineerVisits_Get_LastForJob_Light(int jobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)jobID, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID_Light", true);
            if (dataTable.Rows.Count <= 0)
                return (EngineerVisit)null;
            DataRow row = dataTable.Rows[0];
            return new EngineerVisit()
            {
                IgnoreExceptionsOnSetMethods = true,
                Exists = true,
                SetEngineerVisitID = RuntimeHelpers.GetObjectValue(row["EngineerVisitID"]),
                SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOfWorkID"]),
                SetEngineerID = RuntimeHelpers.GetObjectValue(row["EngineerID"]),
                StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["StartDateTime"])),
                EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["EndDateTime"])),
                SetStatusEnumID = RuntimeHelpers.GetObjectValue(row["StatusEnumID"]),
                SetNotesToEngineer = RuntimeHelpers.GetObjectValue(row["NotesToEngineer"]),
                SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(row["NotesFromEngineer"]),
                SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(row["OutcomeEnumID"]),
                SetOutcomeDetails = RuntimeHelpers.GetObjectValue(row["OutcomeDetails"]),
                SetCustomerName = RuntimeHelpers.GetObjectValue(row["CustomerName"]),
                SetVisitOutcome = RuntimeHelpers.GetObjectValue(row["VisitOutcome"]),
                SetDeleted = Conversions.ToBoolean(row["Deleted"])
            };
        }

        public EngineerVisit EngineerVisits_Get_As_Object(
          int EngineerVisitID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = "EngineerVisits_Get";
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@EngineerVisitID", (object)EngineerVisitID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table.Rows.Count <= 0)
                return (EngineerVisit)null;
            DataRow row = table.Rows[0];
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.Exists = true;
            engineerVisit.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(row[nameof(EngineerVisitID)]);
            engineerVisit.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOfWorkID"]);
            engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(row["EngineerID"]);
            engineerVisit.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["StartDateTime"]));
            engineerVisit.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["EndDateTime"]));
            engineerVisit.SetStatusEnumID = RuntimeHelpers.GetObjectValue(row["StatusEnumID"]);
            engineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(row["NotesToEngineer"]);
            engineerVisit.SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(row["NotesFromEngineer"]);
            engineerVisit.SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(row["OutcomeEnumID"]);
            engineerVisit.SetOutcomeDetails = RuntimeHelpers.GetObjectValue(row["OutcomeDetails"]);
            engineerVisit.SetCustomerName = RuntimeHelpers.GetObjectValue(row["CustomerName"]);
            engineerVisit.SetVisitOutcome = RuntimeHelpers.GetObjectValue(row["VisitOutcome"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["CustomerSignature"])))
                engineerVisit.CustomerSignature = (byte[])row["CustomerSignature"];
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["EngineerSignature"])))
                engineerVisit.EngineerSignature = (byte[])row["EngineerSignature"];
            engineerVisit.Downloading = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Downloading"])) ? Conversions.ToDate(row["Downloading"]) : DateTime.MinValue;
            engineerVisit.SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(row["ManualEntryByUserID"]);
            engineerVisit.ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["ManualEntryOn"]));
            engineerVisit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
            engineerVisit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
            engineerVisit.SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(row["GasInstallationTightnessTestID"]);
            engineerVisit.SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(row["EmergencyControlAccessibleID"]);
            engineerVisit.SetBondingID = RuntimeHelpers.GetObjectValue(row["BondingID"]);
            engineerVisit.SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(row["ExpectedEngineerID"]);
            engineerVisit.SetPropertyRented = RuntimeHelpers.GetObjectValue(row["PropertyRented"]);
            engineerVisit.SetPaymentMethodID = RuntimeHelpers.GetObjectValue(row["PaymentMethodID"]);
            engineerVisit.SetAmountCollected = RuntimeHelpers.GetObjectValue(row["AmountCollected"]);
            engineerVisit.SetSignatureSelectedID = RuntimeHelpers.GetObjectValue(row["SignatureSelectedID"]);
            engineerVisit.SetPartsToFit = RuntimeHelpers.GetObjectValue(row["PartsToFit"]);
            engineerVisit.SetGasServiceCompleted = RuntimeHelpers.GetObjectValue(row["GasServiceCompleted"]);
            engineerVisit.SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["EmailReceipt"]));
            engineerVisit.SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["Recharge"]));
            engineerVisit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(engineerVisit.EngineerVisitID);
            engineerVisit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
            engineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID);
            engineerVisit.setRechargeTypeID = RuntimeHelpers.GetObjectValue(row["RechargeType"]);
            engineerVisit.setNccRadID = RuntimeHelpers.GetObjectValue(row["NccRadID"]);
            engineerVisit.SetMeterCappedID = RuntimeHelpers.GetObjectValue(row["MeterCappedID"]);
            engineerVisit.SetMeterLocationID = RuntimeHelpers.GetObjectValue(row["MeterLocationID"]);
            engineerVisit.SetExpectedDepartment = RuntimeHelpers.GetObjectValue(row["ExpectedDepartment"]);
            if (row.Table.Columns.Contains("FuelID"))
                engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(row["FuelID"]);
            return engineerVisit;
        }

        public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow current in this.EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows)
            {
                EngineerVisit engineerVisit = new EngineerVisit()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    Exists = true,
                    SetEngineerVisitID = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]),
                    SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof(JobOfWorkID)]),
                    SetEngineerID = RuntimeHelpers.GetObjectValue(current["EngineerID"]),
                    StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"])),
                    EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"])),
                    SetStatusEnumID = RuntimeHelpers.GetObjectValue(current["StatusEnumID"]),
                    SetNotesToEngineer = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]),
                    SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(current["NotesFromEngineer"]),
                    SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(current["OutcomeEnumID"]),
                    SetOutcomeDetails = RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]),
                    SetCustomerName = RuntimeHelpers.GetObjectValue(current["CustomerName"]),
                    Downloading = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Downloading"])) ? Conversions.ToDate(current["Downloading"]) : DateTime.MinValue,
                    SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(current["ManualEntryByUserID"]),
                    ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["ManualEntryOn"])),
                    SetVisitLocked = Conversions.ToBoolean(current["VisitLocked"]),
                    SetDeleted = Conversions.ToBoolean(current["Deleted"]),
                    SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(current["GasInstallationTightnessTestID"]),
                    SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(current["EmergencyControlAccessibleID"]),
                    SetPaymentMethodID = RuntimeHelpers.GetObjectValue(current["PaymentMethodID"]),
                    SetAmountCollected = RuntimeHelpers.GetObjectValue(current["AmountCollected"]),
                    SetBondingID = RuntimeHelpers.GetObjectValue(current["BondingID"]),
                    SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(current["ExpectedEngineerID"]),
                    SetPropertyRented = RuntimeHelpers.GetObjectValue(current["PropertyRented"]),
                    SetSignatureSelectedID = RuntimeHelpers.GetObjectValue(current["SignatureSelectedID"]),
                    SetPartsToFit = RuntimeHelpers.GetObjectValue(current["PartsToFit"]),
                    SetGasServiceCompleted = RuntimeHelpers.GetObjectValue(current["GasServiceCompleted"]),
                    SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["EmailReceipt"])),
                    SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Recharge"]))
                };
                engineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(engineerVisit.EngineerVisitID);
                engineerVisit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(engineerVisit.EngineerVisitID);
                engineerVisit.EstimatedDate = Conversions.ToDate(current["EstimatedVisitDate"]);
                engineerVisit.setRechargeTypeID = RuntimeHelpers.GetObjectValue(current["RechargeType"]);
                engineerVisit.setNccRadID = RuntimeHelpers.GetObjectValue(current["NccRadID"]);
                engineerVisit.SetVisitNumber = RuntimeHelpers.GetObjectValue(current["VisitNumber"]);
                engineerVisit.SetUseSORDescription = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["UseSORDescription"]));
                engineerVisit.SetMeterCappedID = RuntimeHelpers.GetObjectValue(current["MeterCappedID"]);
                engineerVisit.SetMeterLocationID = RuntimeHelpers.GetObjectValue(current["MeterLocationID"]);
                engineerVisit.SetExpectedDepartment = RuntimeHelpers.GetObjectValue(current["ExpectedDepartment"]);
                if (current.Table.Columns.Contains("FuelID"))
                    engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(current["FuelID"]);
                arrayList.Add((object)engineerVisit);
            }

            return arrayList;
        }

        public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(int JobOfWorkID)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow current in this.EngineerVisits_Get_For_Job_Of_Work_Light(JobOfWorkID).Table.Rows)
            {
                EngineerVisit engineerVisit = new EngineerVisit()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    Exists = true,
                    SetEngineerVisitID = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]),
                    SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof(JobOfWorkID)]),
                    SetEngineerID = RuntimeHelpers.GetObjectValue(current["EngineerID"]),
                    StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"])),
                    EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"])),
                    SetStatusEnumID = RuntimeHelpers.GetObjectValue(current["StatusEnumID"]),
                    SetNotesToEngineer = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]),
                    SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(current["NotesFromEngineer"]),
                    SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(current["OutcomeEnumID"]),
                    SetOutcomeDetails = RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]),
                    SetCustomerName = RuntimeHelpers.GetObjectValue(current["CustomerName"]),
                    SetAMPM = RuntimeHelpers.GetObjectValue(current["AMPM"]),
                    SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Recharge"])),
                    SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(current["ManualEntryByUserID"]),
                    ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["ManualEntryOn"])),
                    SetDeleted = Conversions.ToBoolean(current["Deleted"]),
                    SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(current["ExpectedEngineerID"]),
                    SetPartsToFit = RuntimeHelpers.GetObjectValue(current["PartsToFit"])
                };
                engineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(engineerVisit.EngineerVisitID);
                engineerVisit.EstimatedDate = Conversions.ToDate(current["EstimatedVisitDate"]);
                engineerVisit.SetVisitNumber = RuntimeHelpers.GetObjectValue(current["VisitNumber"]);
                if (current.Table.Columns.Contains("FuelID"))
                    engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(current["FuelID"]);
                arrayList.Add((object)engineerVisit);
            }

            return arrayList;
        }

        public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects(
          int JobOfWorkID,
          SqlTransaction trans)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow current in this.EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows)
            {
                EngineerVisit engineerVisit = new EngineerVisit();
                engineerVisit.IgnoreExceptionsOnSetMethods = true;
                engineerVisit.Exists = true;
                engineerVisit.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]);
                engineerVisit.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof(JobOfWorkID)]);
                engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(current["EngineerID"]);
                engineerVisit.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"]));
                engineerVisit.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"]));
                engineerVisit.SetStatusEnumID = RuntimeHelpers.GetObjectValue(current["StatusEnumID"]);
                engineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]);
                engineerVisit.SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(current["NotesFromEngineer"]);
                engineerVisit.SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(current["OutcomeEnumID"]);
                engineerVisit.SetOutcomeDetails = RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]);
                engineerVisit.SetCustomerName = RuntimeHelpers.GetObjectValue(current["CustomerName"]);
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["CustomerSignature"])))
                    engineerVisit.CustomerSignature = (byte[])current["CustomerSignature"];
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["EngineerSignature"])))
                    engineerVisit.EngineerSignature = (byte[])current["EngineerSignature"];
                engineerVisit.Downloading = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Downloading"])) ? Conversions.ToDate(current["Downloading"]) : DateTime.MinValue;
                engineerVisit.SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(current["ManualEntryByUserID"]);
                engineerVisit.ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["ManualEntryOn"]));
                engineerVisit.SetVisitLocked = Conversions.ToBoolean(current["VisitLocked"]);
                engineerVisit.SetDeleted = Conversions.ToBoolean(current["Deleted"]);
                engineerVisit.SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(current["GasInstallationTightnessTestID"]);
                engineerVisit.SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(current["EmergencyControlAccessibleID"]);
                engineerVisit.SetPaymentMethodID = RuntimeHelpers.GetObjectValue(current["PaymentMethodID"]);
                engineerVisit.SetAmountCollected = RuntimeHelpers.GetObjectValue(current["AmountCollected"]);
                engineerVisit.SetBondingID = RuntimeHelpers.GetObjectValue(current["BondingID"]);
                engineerVisit.SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(current["ExpectedEngineerID"]);
                engineerVisit.SetPropertyRented = RuntimeHelpers.GetObjectValue(current["PropertyRented"]);
                engineerVisit.SetSignatureSelectedID = RuntimeHelpers.GetObjectValue(current["SignatureSelectedID"]);
                engineerVisit.SetPartsToFit = RuntimeHelpers.GetObjectValue(current["PartsToFit"]);
                engineerVisit.SetGasServiceCompleted = RuntimeHelpers.GetObjectValue(current["GasServiceCompleted"]);
                engineerVisit.SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["EmailReceipt"]));
                engineerVisit.SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Recharge"]));
                engineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(engineerVisit.EngineerVisitID, trans);
                engineerVisit.EstimatedDate = Conversions.ToDate(current["EstimatedVisitDate"]);
                engineerVisit.setRechargeTypeID = RuntimeHelpers.GetObjectValue(current["RechargeType"]);
                engineerVisit.setNccRadID = RuntimeHelpers.GetObjectValue(current["NccRadID"]);
                engineerVisit.SetMeterCappedID = RuntimeHelpers.GetObjectValue(current["MeterCappedID"]);
                engineerVisit.SetMeterLocationID = RuntimeHelpers.GetObjectValue(current["MeterLocationID"]);
                engineerVisit.SetExpectedDepartment = RuntimeHelpers.GetObjectValue(current["ExpectedDepartment"]);
                if (current.Table.Columns.Contains("FuelID"))
                    engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(current["FuelID"]);
                arrayList.Add((object)engineerVisit);
            }

            return arrayList;
        }

        public EngineerVisit ManuallyComplete(
          EngineerVisit oEngineerVisit,
          DataView JobItemsDataview,
          DataView PartsAndProductsDistribution)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)oEngineerVisit.EngineerID, true);
            this._database.AddParameter("@StatusEnumID", (object)7, true);
            this._database.AddParameter("@NotesFromEngineer", (object)oEngineerVisit.NotesFromEngineer, true);
            this._database.AddParameter("@OutcomeEnumID", (object)oEngineerVisit.OutcomeEnumID, true);
            this._database.AddParameter("@OutcomeDetails", (object)oEngineerVisit.OutcomeDetails, true);
            this._database.AddParameter("@CustomerName", (object)oEngineerVisit.CustomerName, true);
            this._database.AddParameter("@ManualEntryByUserID", (object)App.loggedInUser.UserID, true);
            this._database.AddParameter("@EngineerVisitID", (object)oEngineerVisit.EngineerVisitID, true);
            this._database.AddParameter("@VisitLocked", (object)oEngineerVisit.VisitLocked, true);
            this._database.AddParameter("@GasInstallationTightnessTestID", (object)oEngineerVisit.GasInstallationTightnessTestID, true);
            this._database.AddParameter("@EmergencyControlAccessibleID", (object)oEngineerVisit.EmergencyControlAccessibleID, true);
            this._database.AddParameter("@BondingID", (object)oEngineerVisit.BondingID, true);
            this._database.AddParameter("@PropertyRented", (object)oEngineerVisit.PropertyRented, true);
            this._database.AddParameter("@SignatureSelectedID", (object)oEngineerVisit.SignatureSelectedID, true);
            this._database.AddParameter("@PaymentMethodID", (object)oEngineerVisit.PaymentMethodID, true);
            this._database.AddParameter("@AmountCollected", (object)oEngineerVisit.AmountCollected, true);
            this._database.AddParameter("@GasServiceCompleted", (object)oEngineerVisit.GasServiceCompleted, true);
            this._database.AddParameter("@EmailReceipt", (object)oEngineerVisit.EmailReceipt, true);
            this._database.AddParameter("@Recharge", (object)oEngineerVisit.Recharge, true);
            this._database.AddParameter("@RechargeType", (object)oEngineerVisit.RechargeTypeID, true);
            this._database.AddParameter("@NccRadID", (object)oEngineerVisit.NccRadID, true);
            this._database.AddParameter("@MeterCappedID", (object)oEngineerVisit.MeterCappedID, true);
            this._database.AddParameter("@MeterLocationID", (object)oEngineerVisit.MeterLocationID, true);
            this._database.AddParameter("@CostsTo", (object)oEngineerVisit.CostsTo, true);
            this._database.AddParameter("@UseSORDescription", (object)oEngineerVisit.UseSORDescription, true);
            this._database.AddParameter("@FuelID", (object)oEngineerVisit.FuelID, true);
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisit_ManuallyComplete_CheckChange", true))))
                App.DB.JobAudit.Insert(new JobAudit()
                {
                    SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID,
                    SetActionChange = (object)("Visit Status changed to " + Enums.VisitStatus.Uploaded.ToString() + ", Outcome: " + Microsoft.VisualBasic.Strings.Replace(((Enums.EngineerVisitOutcomes)oEngineerVisit.OutcomeEnumID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + ", GasServiceComplete: " + oEngineerVisit.GasServiceCompleted.ToString() + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")")
                });
            foreach (DataRow current in oEngineerVisit.PartsAndProductsUsed.Table.Rows)
            {
                EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts = new EngineerVisitPartsAndProducts();
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object)"Part", false))
                {
                    if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["UniqueID"])) == 0)
                    {
                        oEngineerVisitPartsAndProducts.SetEngineerVisitID = (object)oEngineerVisit.EngineerVisitID;
                        oEngineerVisitPartsAndProducts.SetAssetID = (object)0;
                        oEngineerVisitPartsAndProducts.SetPartOrProductID = RuntimeHelpers.GetObjectValue(current["ID"]);
                        oEngineerVisitPartsAndProducts.SetQuantity = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                        oEngineerVisitPartsAndProducts.SetAllocatedID = RuntimeHelpers.GetObjectValue(current["AllocatedID"]);
                        oEngineerVisitPartsAndProducts.SetSpecialDescription = RuntimeHelpers.GetObjectValue(current["SpecialDescription"]);
                        oEngineerVisitPartsAndProducts.SetSpecialPartNumber = RuntimeHelpers.GetObjectValue(current["SpecialPartNumber"]);
                        oEngineerVisitPartsAndProducts.SetSpecialPrice = RuntimeHelpers.GetObjectValue(current["SpecialPrice"]);
                        this._database.EngineerVisitsPartsAndProducts.PartsUsed_Insert(oEngineerVisitPartsAndProducts);
                    }
                    else
                        this._database.EngineerVisitsPartsAndProducts.PartsUsed_Update(Conversions.ToInteger(current["UniqueID"]), Conversions.ToInteger(current["Quantity"]));
                }
                else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["UniqueID"])) == 0)
                {
                    oEngineerVisitPartsAndProducts.SetEngineerVisitID = (object)oEngineerVisit.EngineerVisitID;
                    oEngineerVisitPartsAndProducts.SetPartOrProductID = RuntimeHelpers.GetObjectValue(current["ID"]);
                    oEngineerVisitPartsAndProducts.SetQuantity = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                    this._database.EngineerVisitsPartsAndProducts.ProductsUsed_Insert(oEngineerVisitPartsAndProducts);
                    if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["UniqueID"])) == 0)
                    {
                        int num1 = checked(Conversions.ToInteger(current["Quantity"]) - 1);
                        int num2 = 0;
                        while (num2 <= num1)
                        {
                            if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)"Would you like to add Product: '", current["Name"]), (object)"' as an Asset for this Site?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                App.ShowForm(typeof(FRMAsset), true, new object[3]
                                {
                    (object) 0,
                    current["ID"],
                    (object) App.DB.Sites.Get((object) oEngineerVisit.EngineerVisitID, SiteSQL.GetBy.EngineerVisitId, (object) null).SiteID
                                }, false);
                            checked { ++num2; }
                        }
                    }
                }
                else
                    this._database.EngineerVisitsPartsAndProducts.ProductsUsed_Update(Conversions.ToInteger(current["UniqueID"]), Conversions.ToInteger(current["Quantity"]));
            }

            this.AllocatedDistributions(PartsAndProductsDistribution);
            Job job = new Job();
            Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
            if (oEngineerVisit.StatusEnumID < 7)
            {
                if (!App.DB.Job.Job_WasGeneratedByLetter(anEngineerVisitId.JobID))
                {
                    switch (oEngineerVisit.OutcomeEnumID)
                    {
                        case 2:
                            if (oEngineerVisit.VisitNumber <= 0)
                            {
                                JobOfWork oJobOfWork = new JobOfWork();
                                oJobOfWork.SetJobID = (object)anEngineerVisitId.JobID;
                                DataTable table = App.DB.JobOfWorks.JobOfWork_Get_For_Job(oJobOfWork.JobID).Table;
                                oJobOfWork.SetPONumber = RuntimeHelpers.GetObjectValue(table.Rows[checked(table.Rows.Count - 1)]["PONumber"]);
                                JobOfWork jobOfWork = App.DB.JobOfWorks.Insert(oJobOfWork);
                                EngineerVisit engineerVisit = this.Insert(new EngineerVisit()
                                {
                                    SetJobOfWorkID = (object)jobOfWork.JobOfWorkID,
                                    SetStatusEnumID = (object)4,
                                    SetNotesToEngineer = (object)("(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)\r\nPREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + "\r\n"),
                                    SetPartsToFit = (object)oEngineerVisit.PartsToFit,
                                    DueDate = DateTime.MinValue,
                                    SetAMPM = (object)"",
                                    SetFuelID = (object)Helper.MakeIntegerValid((object)oEngineerVisit.FuelID)
                                }, App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID, 0, 0);
                                App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, engineerVisit.EngineerVisitID);
                                DataView forJobOfWork = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                                bool flag = true;

                                foreach (DataRow current in forJobOfWork.Table.Rows)
                                {
                                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["StatusEnumID"], (object)7, false))
                                        flag = false;
                                }

                                if (flag)
                                {
                                    App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, 3);
                                    break;
                                }
                                break;
                            }
                            break;

                        case 4:
                            this.Insert(new EngineerVisit()
                            {
                                SetJobOfWorkID = (object)oEngineerVisit.JobOfWorkID,
                                SetStatusEnumID = (object)4,
                                SetNotesToEngineer = (object)("(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)\r\nPREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + "\r\n"),
                                SetPartsToFit = (object)oEngineerVisit.PartsToFit,
                                DueDate = DateTime.MinValue,
                                SetAMPM = (object)"",
                                SetFuelID = (object)Helper.MakeIntegerValid((object)oEngineerVisit.FuelID)
                            }, anEngineerVisitId.JobID, 0, 0);
                            break;

                        case 5:
                            EngineerVisit engineerVisit1 = new EngineerVisit();
                            engineerVisit1.SetStatusEnumID = (object)1;
                            engineerVisit1.SetNotesToEngineer = (object)("(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)\r\nPREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + "\r\n");
                            engineerVisit1.SetPartsToFit = (object)oEngineerVisit.PartsToFit;
                            engineerVisit1.SetFuelID = (object)Helper.MakeIntegerValid((object)oEngineerVisit.FuelID);
                            JobOfWork oJobOfWork1 = new JobOfWork();
                            oJobOfWork1.SetJobID = (object)App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID;
                            DataTable table1 = App.DB.JobOfWorks.JobOfWork_Get_For_Job(oJobOfWork1.JobID).Table;
                            oJobOfWork1.SetPONumber = RuntimeHelpers.GetObjectValue(table1.Rows[checked(table1.Rows.Count - 1)]["PONumber"]);
                            DataRow[] dataRowArray = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table.Select("Name = 'P1 - 5 Days'");
                            if (dataRowArray.Length > 0)
                                oJobOfWork1.SetPriority = (object)Conversions.ToInteger(dataRowArray[0]["ManagerID"]);
                            oJobOfWork1.EngineerVisits.Add((object)engineerVisit1);
                            App.DB.JobOfWorks.Insert(oJobOfWork1);
                            App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, engineerVisit1.EngineerVisitID);
                            DataView forJobOfWork1 = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                            bool flag1 = true;
                            foreach (DataRow current in forJobOfWork1.Table.Rows)
                            {
                                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["StatusEnumID"], (object)7, false))
                                    flag1 = false;
                            }

                            if (flag1)
                            {
                                App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, 3);
                                break;
                            }
                            break;
                    }
                }
                else if (oEngineerVisit.OutcomeEnumID == 4)
                    this.Insert(new EngineerVisit()
                    {
                        SetJobOfWorkID = (object)oEngineerVisit.JobOfWorkID,
                        SetStatusEnumID = (object)4,
                        SetNotesToEngineer = (object)("(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)\r\nPREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + "\r\n"),
                        SetPartsToFit = (object)oEngineerVisit.PartsToFit,
                        SetVisitNumber = (object)oEngineerVisit.VisitNumber,
                        DueDate = oEngineerVisit.DueDate,
                        SetAMPM = (object)oEngineerVisit.AMPM,
                        SetFuelID = (object)Helper.MakeIntegerValid((object)oEngineerVisit.FuelID)
                    }, anEngineerVisitId.JobID, 0, 0);
                if (oEngineerVisit.OutcomeEnumID == 3)
                {
                    DataView forJobOfWork2 = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                    bool flag2 = true;
                    foreach (DataRow current in forJobOfWork2.Table.Rows)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["StatusEnumID"], (object)7, false))
                            flag2 = false;
                    }

                    if (flag2)
                        App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, 2);
                }
                else if (oEngineerVisit.OutcomeEnumID == 1)
                {
                    DataView forJobOfWork2 = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                    bool flag2 = true;

                    foreach (DataRow current in forJobOfWork2.Table.Rows)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["StatusEnumID"], (object)7, false))
                            flag2 = false;
                    }

                    if (flag2)
                        App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, 3);
                }
            }
            this._database.EngineerVisitsPartsAndProducts.PartsNeeded_Delete(oEngineerVisit.EngineerVisitID);
            this._database.EngineerVisitsPartsAndProducts.ProductsNeeded_Delete(oEngineerVisit.EngineerVisitID);
            this._database.EngineerVisitsTimeSheet.Delete(oEngineerVisit.EngineerVisitID);

            foreach (DataRow current in oEngineerVisit.TimeSheets.Table.Rows)
            {
                this._database.EngineerVisitsTimeSheet.Insert(new EngineerVisitTimeSheet()
                {
                    SetEngineerVisitID = (object)oEngineerVisit.EngineerVisitID,
                    StartDateTime = Conversions.ToDate(current["StartDateTime"]),
                    EndDateTime = Conversions.ToDate(current["EndDateTime"]),
                    SetComments = RuntimeHelpers.GetObjectValue(current["Comments"]),
                    SetTimeSheetTypeID = RuntimeHelpers.GetObjectValue(current["TimesheetTypeID"])
                });
            }
            if (anEngineerVisitId.JobDefinitionEnumID == 2 | oEngineerVisit.GasServiceCompleted)
            {
                foreach (DataRow current in anEngineerVisitId.Assets)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(current);
                    Asset asset = new Asset();
                    Asset oAsset = App.DB.Asset.Asset_Get(((JobAsset)objectValue).AssetID);
                    oAsset.LastServicedDate = DateAndTime.Now;
                    App.DB.Asset.Update(oAsset);
                }
            }

            if (anEngineerVisitId.JobTypeID == 4702 | anEngineerVisitId.JobTypeID == 71443 | anEngineerVisitId.JobTypeID == 519 && oEngineerVisit.GasServiceCompleted & oEngineerVisit.OutcomeEnumID == 1)
            {
                FSM.Entity.Customers.Customer forSiteId = App.DB.Customer.Customer_Get_ForSiteID(anEngineerVisitId.PropertyID);
                bool flag1 = false;
                if (forSiteId != null && forSiteId.MOTStyleService)
                    flag1 = true;
                bool flag2 = false;
                if (oEngineerVisit.EngineerVisitNCCGSR != null && oEngineerVisit.EngineerVisitNCCGSR.CertificateTypeID == 67007)
                    flag2 = true;
                DateTime dateTime1 = DateTime.Compare(oEngineerVisit.StartDateTime, DateTime.MinValue) != 0 ? oEngineerVisit.StartDateTime : (oEngineerVisit.TimeSheets.Table.Rows.Count <= 0 ? DateAndTime.Now : Conversions.ToDate(oEngineerVisit.TimeSheets.Table.Rows[0]["StartDateTime"]));
                DateTime minValue = DateTime.MinValue;
                DateTime dateTime2 = DateTime.MinValue;
                DataRow[] dataRowArray1 = oEngineerVisit.FuelID != 0 ? App.DB.Sites.SiteFuel_GetAll_ForSite(anEngineerVisitId.PropertyID).Table.Select("FuelID = " + Conversions.ToString(oEngineerVisit.FuelID)) : App.DB.Sites.SiteFuel_GetAll_ForSite(anEngineerVisitId.PropertyID).Table.Select();
                if (dataRowArray1.Length > 0)
                {
                    DataRow[] dataRowArray2 = dataRowArray1;
                    int index = 0;
                    while (index < dataRowArray2.Length)
                    {
                        DataRow dataRow = dataRowArray2[index];
                        DateTime dateTime3 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["LastServiceDate"]));
                        int num = checked((int)DateAndTime.DateDiff(DateInterval.Month, dateTime1, dateTime3.AddYears(1), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
                        dateTime2 = !(DateTime.Compare(dateTime3.AddYears(1), dateTime1) > 0 & num >= 0 & num <= 2 & flag1 & Conversions.ToInteger(dataRow["FuelID"]) == 377 & !flag2) ? dateTime1 : dateTime3.AddYears(1);
                        DateTime dateTime4 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["LastServiceDate"]));
                        if ((uint)DateTime.Compare(dateTime4.Date, dateTime2) > 0U)
                        {
                            string[] strArray = new string[6]
                            {
                "Service Completed: Updated ",
                App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(dataRow["FuelID"])).Name,
                ", changed last service date from ",
                null,
                null,
                null
                            };
                            dateTime4 = Conversions.ToDate(dataRow["LastServiceDate"]);
                            strArray[3] = Conversions.ToString(dateTime4.Date);
                            strArray[4] = " to ";
                            strArray[5] = Conversions.ToString(dateTime2);
                            string actionChange = string.Concat(strArray);
                            App.DB.Sites.SiteFuel_Update_LastServiceDate(anEngineerVisitId.PropertyID, Conversions.ToInteger(dataRow["FuelID"]), dateTime2, dateTime1);
                            if (!string.IsNullOrEmpty(actionChange))
                                App.DB.Sites.SiteFuelAudit_Insert(anEngineerVisitId.PropertyID, actionChange);
                        }
                        checked { ++index; }
                    }
                }
                if (DateTime.Compare(dateTime2, DateTime.MinValue) == 0)
                    dateTime2 = dateTime1;
                App.DB.Sites.Site_UpdateLastServiceDate(anEngineerVisitId.PropertyID, dateTime2, dateTime1, false);
            }
            this.EngineerVisitUnitsUsed_Delete(oEngineerVisit.EngineerVisitID);
            if (JobItemsDataview != null)
            {
                foreach (DataRow current in JobItemsDataview.Table.Rows)
                {
                    this.EngineerVisitUnitsUsed_Insert(oEngineerVisit.EngineerVisitID, Conversions.ToInteger(current["JobItemID"]), Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["NumUnitsUsed"])));
                }
            }

            if (oEngineerVisit.EngineerVisitNCCGSR != null)
            {
                if (oEngineerVisit.EngineerVisitNCCGSR.Exists)
                    App.DB.EngineerVisitNCCGSR.Update(oEngineerVisit.EngineerVisitNCCGSR);
                else
                    App.DB.EngineerVisitNCCGSR.Insert(oEngineerVisit.EngineerVisitNCCGSR);
            }
            return this.EngineerVisits_Get_New_As_Object(oEngineerVisit.EngineerVisitID);
        }

        private void AllocatedDistributions(DataView PartsAndProductsDistribution)
        {
            foreach (DataRow dr in PartsAndProductsDistribution.Table.Rows)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["DistributedID"], (object)0, false))
                {
                    this._database.ClearParameter();
                    this._database.AddParameter("@LocationID", RuntimeHelpers.GetObjectValue(dr["LocationID"]), true);
                    this._database.AddParameter("@AllocatedID", RuntimeHelpers.GetObjectValue(dr["AllocatedID"]), true);
                    this._database.AddParameter("@Other", RuntimeHelpers.GetObjectValue(dr["Other"]), true);
                    this._database.AddParameter("@Quantity", RuntimeHelpers.GetObjectValue(dr["Quantity"]), true);
                    this._database.AddParameter("@PartProductID", RuntimeHelpers.GetObjectValue(dr["PartProductID"]), true);
                    this._database.AddParameter("@OrderPartProductID", RuntimeHelpers.GetObjectValue(dr["OrderPartProductID"]), true);
                    string Left1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"]));
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Part", false) != 0)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Product", false) == 0)
                            this._database.ExecuteSP_NO_Return("EngineerVisitProductDistributed_Insert", true);
                    }
                    else
                        this._database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert", true);
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["StockTransactionType"], (object)-1, false))
                    {
                        PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited();
                        oPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                        OrderPart orderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(dr["OrderPartProductID"]));
                        PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(orderPart.PartSupplierID);
                        oPartsToBeCredited.SetOrderID = (object)orderPart.OrderID;
                        oPartsToBeCredited.SetSupplierID = (object)partSupplier.SupplierID;
                        oPartsToBeCredited.SetPartOrderID = RuntimeHelpers.GetObjectValue(dr["OrderPartProductID"]);
                        oPartsToBeCredited.SetPartID = RuntimeHelpers.GetObjectValue(dr["PartProductID"]);
                        oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(dr["Quantity"]);
                        oPartsToBeCredited.SetStatusID = (object)1;
                        oPartsToBeCredited.SetManuallyAdded = (object)false;
                        oPartsToBeCredited.SetOrderReference = (object)App.DB.Order.Order_Get(orderPart.OrderID).OrderReference;
                        App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
                    }
                    if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(dr["LocationID"], (object)0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(dr["StockTransactionType"], (object)0, false))))
                    {
                        string Left2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"]));
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Part", false) != 0)
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Product", false) == 0)
                                App.DB.ProductTransaction.Insert(new ProductTransaction()
                                {
                                    SetLocationID = RuntimeHelpers.GetObjectValue(dr["LocationID"]),
                                    SetProductID = RuntimeHelpers.GetObjectValue(dr["PartProductID"]),
                                    SetOrderProductID = RuntimeHelpers.GetObjectValue(dr["OrderPartProductID"]),
                                    SetAmount = Conversions.ToInteger(dr["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(dr["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(dr["Quantity"], (object)-1),
                                    SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dr["StockTransactionType"])
                                });
                        }
                        else
                            App.DB.PartTransaction.Insert(new PartTransaction()
                            {
                                SetLocationID = RuntimeHelpers.GetObjectValue(dr["LocationID"]),
                                SetPartID = RuntimeHelpers.GetObjectValue(dr["PartProductID"]),
                                SetOrderPartID = RuntimeHelpers.GetObjectValue(dr["OrderPartProductID"]),
                                SetAmount = Conversions.ToInteger(dr["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(dr["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(dr["Quantity"], (object)-1),
                                SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dr["StockTransactionType"])
                            });
                    }
                }
            }
        }

        public DataView EngineerVisitUnitsUsed_Get_For_EngineerVisitID(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitUnitsUsed_Get_For_EngineerVisitID), true);
            table.TableName = Enums.TableNames.tblJobItem.ToString();
            return new DataView(table);
        }

        public void EngineerVisitUnitsUsed_Delete(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitUnitsUsed_Delete), true);
        }

        public int EngineerVisitUnitsUsed_Insert(
          int EngineerVisitID,
          int JobItemID,
          double NumUnitsUsed)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitUnitsUsedParametersToCommand(EngineerVisitID, JobItemID, NumUnitsUsed);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitUnitsUsed_Insert), true)));
        }

        private void AddEngineerVisitUnitsUsedParametersToCommand(
          int EngineerVisitID,
          int JobItemID,
          double NumUnitsUsed)
        {
            Database database = this._database;
            database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            database.AddParameter("@JobItemID", (object)JobItemID, true);
            database.AddParameter("@NumUnitsUsed", (object)NumUnitsUsed, true);
        }

        public int EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID), true)));
        }

        public double EngineerCharge_VAT_Amount(
          int EngineerChargeID,
          DateTime VisitDate,
          double Amount)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerChargeID", (object)EngineerChargeID, true);
            this._database.AddParameter("@TypeID", (object)260, true);
            this._database.AddParameter("@VisitDate", (object)VisitDate, true);
            this._database.AddParameter("@Amount", (object)Amount, true);
            return Conversions.ToDouble(this._database.ExecuteSP_OBJECT(nameof(EngineerCharge_VAT_Amount), true));
        }

        public DataTable EngineerVisitLiveCostReport()
        {
            this._database.ClearParameter();
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get_All_REPORT_Yesterday", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public void AlterEstimatedDate(int JobWorkID, DateTime EstDate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object)JobWorkID, true);
            this._database.AddParameter("@Date", (object)EstDate, true);
            this._database.ExecuteSP_NO_Return("EngineerVisit_AlterEstimated", true);
        }

        public DataTable GetFutureVisits(int EngineerID, bool includeCurrentVisit)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerID, true);
            this._database.AddParameter("@IncludeCurrentVisit", (object)includeCurrentVisit, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerVisit_GetFutureVisits", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable Get_Appointments_Main(
          DateTime StartDate,
          int TimeReq,
          int days = 14,
          int TimeLimit = 240)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@timereq", (object)TimeReq, true);
            this._database.AddParameter("@Days", (object)days, true);
            this._database.AddParameter("@TimeLimit", (object)TimeLimit, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Get_Appointments_Main), true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable Get_Appointments_Multi(
          string StartDate,
          int TimeReq,
          int days = 14,
          int TimeLimit = 240)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@timereq", (object)TimeReq, true);
            this._database.AddParameter("@Days", (object)days, true);
            this._database.AddParameter("@TimeLimit", (object)TimeLimit, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("Get_Appointments_Multi_Appoint", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable Get_Appointments_ForEngineer(
          string StartDate,
          int TimeReq,
          int EngineerID,
          int days = 14,
          int TimeLimit = 240)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@timereq", (object)TimeReq, true);
            this._database.AddParameter("@Days", (object)days, true);
            this._database.AddParameter("@TimeLimit", (object)TimeLimit, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("Get_Appointments_For_SingleEngineerID", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable Get_Appointments_Scheduler(string StartDate, int TimeReq)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@timereq", (object)TimeReq, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("Get_Appointments_Schedulers", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable Find_The_Gap(string datein, int Engid, string Period)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@datein", (object)datein, true);
            this._database.AddParameter("@EngineerID", (object)Engid, true);
            this._database.AddParameter("@Period", (object)Period, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable("Visits_Find_Gap", true);
            dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
            return dataTable;
        }

        public DataTable GetLastVisit(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            return this._database.ExecuteSP_DataTable("EngineerVisit_GetLastVisit", true);
        }

        public DataTable GetSymptoms(int EngineervisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            return this._database.ExecuteSP_DataTable("EngineerVisit_GetSymptoms", true);
        }

        public void DeleteSymptoms(int EngineervisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            this._database.ExecuteSP_DataTable("EngineerVisit_DeleteSymptoms_ForEngineerVisitID", true);
        }

        public DataView InsertSymptom(int EngineervisitID, int SymptomID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            this._database.AddParameter("@SymptomID", (object)SymptomID, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerVisit_InsertSymptom", true));
        }

        public DataTable GetExtendedProperties(int EngineervisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            return this._database.ExecuteSP_DataTable("EngineerVisit_GetExtendedProperties", true);
        }

        public DataTable InsertAdditionalText(int EngineervisitID, string AdditionalText)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            this._database.AddParameter("@AdditionalText", (object)AdditionalText, true);
            return this._database.ExecuteSP_DataTable("EngineerVisit_InsertAdditionalText", true);
        }

        public void DeleteExtendedProperties(int EngineervisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineervisitID, true);
            this._database.ExecuteSP_DataTable("EngineerVisit_DeleteExtendedProperties_ForEngineerVisitID", true);
        }

        public bool MoveParts(int FromID, int ToID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OldEngineerVisitID", (object)FromID, true);
            this._database.AddParameter("@NewEngineerVisitID", (object)ToID, true);
            return this._database.ExecuteSP_DataTable("EngineerVisitPartAllocated_MoveVisit", true).Rows.Count > 0;
        }

        public EngineerVisit EngineerVisits_Get_LastForJob(int jobID, string jobNumber = "")
        {
            this._database.ClearParameter();
            DataTable dataTable;
            if (!Helper.IsStringEmpty((object)jobNumber))
            {
                this._database.AddParameter("@JobNumber", (object)jobNumber, true);
                dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobNumber", true);
            }
            else
            {
                this._database.AddParameter("@JobID", (object)jobID, true);
                dataTable = this._database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID", true);
            }
            if (dataTable.Rows.Count <= 0)
                return (EngineerVisit)null;
            DataRow row = dataTable.Rows[0];
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.Exists = true;
            engineerVisit.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(row["EngineerVisitID"]);
            engineerVisit.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOfWorkID"]);
            engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(row["EngineerID"]);
            engineerVisit.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["StartDateTime"]));
            engineerVisit.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["EndDateTime"]));
            engineerVisit.SetStatusEnumID = RuntimeHelpers.GetObjectValue(row["StatusEnumID"]);
            engineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(row["NotesToEngineer"]);
            engineerVisit.SetNotesFromEngineer = RuntimeHelpers.GetObjectValue(row["NotesFromEngineer"]);
            engineerVisit.SetOutcomeEnumID = RuntimeHelpers.GetObjectValue(row["OutcomeEnumID"]);
            engineerVisit.SetOutcomeDetails = RuntimeHelpers.GetObjectValue(row["OutcomeDetails"]);
            engineerVisit.SetCustomerName = RuntimeHelpers.GetObjectValue(row["CustomerName"]);
            engineerVisit.SetVisitOutcome = RuntimeHelpers.GetObjectValue(row["VisitOutcome"]);
            engineerVisit.SetManualEntryByUserID = RuntimeHelpers.GetObjectValue(row["ManualEntryByUserID"]);
            engineerVisit.ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["ManualEntryOn"]));
            engineerVisit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
            engineerVisit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
            engineerVisit.SetGasInstallationTightnessTestID = RuntimeHelpers.GetObjectValue(row["GasInstallationTightnessTestID"]);
            engineerVisit.SetEmergencyControlAccessibleID = RuntimeHelpers.GetObjectValue(row["EmergencyControlAccessibleID"]);
            engineerVisit.SetBondingID = RuntimeHelpers.GetObjectValue(row["BondingID"]);
            engineerVisit.SetExpectedEngineerID = RuntimeHelpers.GetObjectValue(row["ExpectedEngineerID"]);
            engineerVisit.SetPropertyRented = RuntimeHelpers.GetObjectValue(row["PropertyRented"]);
            engineerVisit.SetPaymentMethodID = RuntimeHelpers.GetObjectValue(row["PaymentMethodID"]);
            engineerVisit.SetAmountCollected = RuntimeHelpers.GetObjectValue(row["AmountCollected"]);
            engineerVisit.SetAMPM = RuntimeHelpers.GetObjectValue(row["AMPM"]);
            engineerVisit.SetVisitNumber = RuntimeHelpers.GetObjectValue(row["VisitNumber"]);
            engineerVisit.SetVisitStatus = RuntimeHelpers.GetObjectValue(row["VisitStatus"]);
            engineerVisit.SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["Recharge"]));
            if (row.Table.Columns.Contains("FuelID"))
                engineerVisit.SetFuelID = RuntimeHelpers.GetObjectValue(row["FuelID"]);
            return engineerVisit;
        }

        public int EngineerVisit_GetActionID(int EVID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EVID, true);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT(nameof(EngineerVisit_GetActionID), true));
        }

        public DataView Get_SiteHistory(int siteId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)siteId, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerVisit_Get_SiteHistory", true));
        }

        public DataView Get_ByEngineerIdAndStatusEnumId(int engineerId, int statusEnumId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)engineerId, true);
            this._database.AddParameter("@StatusEnumID", (object)statusEnumId, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerVisit_Get_ByEngineerIdAndStatusEnumId", true));
        }

        public List<EngineerVisit> Get_ByJobId(int jobId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)jobId, true);
            DataTable source1 = this._database.ExecuteSP_DataTable("EngineerVisit_Get_ByJobId", true);
            if (source1 == null || source1.Rows.Count <= 0)
                return (List<EngineerVisit>)null;

            List<EngineerVisit> engineerVisits = (from x in source1.AsEnumerable()
                                                  select new EngineerVisit()
                                                  {
                                                      Exists = true,
                                                      SetEngineerVisitID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["EngineerVisitId"])),
                                                      SetJobOfWorkID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["JobOfWorkId"])),
                                                      SetEngineerID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["EngineerId"])),
                                                      StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(x["StartDateTime"])),
                                                      EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(x["EndDateTime"])),
                                                      SetStatusEnumID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["StatusEnumId"])),
                                                      SetNotesToEngineer = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["NotesToEngineer"])),
                                                      SetNotesFromEngineer = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["NotesFromEngineer"])),
                                                      SetOutcomeEnumID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["OutcomeEnumId"])),
                                                      SetOutcomeDetails = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["OutcomeDetails"])),
                                                      SetCustomerName = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["CustomerName"])),
                                                      SetManualEntryByUserID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["ManualEntryByUserId"])),
                                                      ManualEntryOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(x["ManualEntryOn"])),
                                                      SetVisitLocked = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["VisitLocked"])),
                                                      SetDeleted = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["Deleted"])),
                                                      SetPaymentMethodID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["PaymentMethodId"])),
                                                      SetAmountCollected = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(x["AmountCollected"])),
                                                      SetGasInstallationTightnessTestID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["GasInstallationTightnessTestId"])),
                                                      SetEmergencyControlAccessibleID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["EmergencyControlAccessibleId"])),
                                                      SetBondingID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["BondingId"])),
                                                      SetPropertyRented = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["PropertyRented"])),
                                                      SetSignatureSelectedID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["SignatureSelectedId"])),
                                                      SetPartsToFit = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["PartsToFit"])),
                                                      SetGasServiceCompleted = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["GasServiceCompleted"])),
                                                      SetEmailReceipt = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["EmailReceipt"])),
                                                      Downloading = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(x["Downloading"])),
                                                      SetExpectedEngineerID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["ExpectedEngineerId"])),
                                                      SetAMPM = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["AMPM"])),
                                                      SetVisitNumber = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["VisitNumber"])),
                                                      SetRecharge = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["Recharge"])),
                                                      SetCostsTo = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["CostsTo"])),
                                                      setNccRadID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["NccRadId"])),
                                                      SetMeterCappedID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["MeterCappedId"])),
                                                      SetUseSORDescription = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["UseSORdescription"])),
                                                      SetAppointmentID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["AppointmentId"])),
                                                      SetMeterLocationID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["MeterLocationId"])),
                                                      SetExpectedDepartment = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["ExpectedDepartment"])),
                                                      SetFuelID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["FuelId"])),
                                                      SetExcludeFromTextMessage = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["ExcludeFromTextMessage"]))
                                                  }).ToList();

            return engineerVisits;
        }
    }
}