using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisits
    {
        public class EngineerVisitSQL
        {
            private Database _database;

            public EngineerVisitSQL(Database database)
            {
                _database = database;
            }

            

            public void Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisit_Delete");
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID).JobID;
                jA.SetActionChange = "Visit Deleted (Unique Visit ID: " + EngineerVisitID + ")";
                App.DB.JobAudit.Insert(jA);
            }

            public void Delete(int EngineerVisitID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisit_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID));
                Command.ExecuteNonQuery();
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, trans).JobID;
                jA.SetActionChange = "Visit Deleted: (" + EngineerVisitID + ")";
                App.DB.JobAudit.Insert(jA, trans);
            }

            public EngineerVisit Insert(EngineerVisit oEngineerVisit, int JobID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisit_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JobOfWorkID", oEngineerVisit.JobOfWorkID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerID", oEngineerVisit.EngineerID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", oEngineerVisit.Deleted));
                if (!(oEngineerVisit.StartDateTime == DateTime.MinValue))
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDateTime", oEngineerVisit.StartDateTime));
                }
                else
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDateTime", DBNull.Value));
                }

                if (!(oEngineerVisit.EndDateTime == DateTime.MinValue))
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDateTime", oEngineerVisit.EndDateTime));
                }
                else
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDateTime", DBNull.Value));
                }

                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StatusEnumID", oEngineerVisit.StatusEnumID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PartsToFit", oEngineerVisit.PartsToFit));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AMPM", oEngineerVisit.AMPM));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VisitNumber", oEngineerVisit.VisitNumber));
                if (oEngineerVisit.DueDate == DateTime.MinValue)
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DueDate", DBNull.Value));
                }
                else
                {
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DueDate", oEngineerVisit.DueDate));
                }

                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Recharge", oEngineerVisit.Recharge));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExcludeFromTextMessage", oEngineerVisit.ExcludeFromTextMessage));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RechargeType", oEngineerVisit.RechargeTypeID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NccRadID", oEngineerVisit.NccRadID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeterLocationID", oEngineerVisit.MeterLocationID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeterCappedID", oEngineerVisit.MeterCappedID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FuelID", oEngineerVisit.FuelID));
                oEngineerVisit.SetEngineerVisitID = Helper.MakeIntegerValid(Command.ExecuteScalar());
                oEngineerVisit.Exists = true;
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID;
                jA.SetActionChange = "New Visit Inserted - Status: " + Strings.Replace(((Enums.VisitStatus)Conversions.ToInteger(oEngineerVisit.StatusEnumID)).ToString(), "_", " ") + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                App.DB.JobAudit.Insert(jA, trans);
                App.DB.EngineerVisitPartProductAllocated.NewInsert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID, trans);
                return oEngineerVisit;
            }

            public EngineerVisit Insert(EngineerVisit oEngineerVisit, int JobID, int appointmentID = 0, int oldVisitId = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", oEngineerVisit.JobOfWorkID, true);
                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, true);
                _database.AddParameter("@Deleted", oEngineerVisit.Deleted, true);
                _database.AddParameter("@StartDateTime", Helper.InsertDateIntoDb(oEngineerVisit.StartDateTime), true);
                _database.AddParameter("@EndDateTime", Helper.InsertDateIntoDb(oEngineerVisit.EndDateTime), true);
                _database.AddParameter("@StatusEnumID", oEngineerVisit.StatusEnumID, true);
                _database.AddParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer, true);
                _database.AddParameter("@PartsToFit", oEngineerVisit.PartsToFit, true);
                _database.AddParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID, true);
                _database.AddParameter("@AMPM", oEngineerVisit.AMPM, true);
                _database.AddParameter("@VisitNumber", oEngineerVisit.VisitNumber);
                _database.AddParameter("@DueDate", Helper.InsertDateIntoDb(oEngineerVisit.DueDate), true);
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge);
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID);
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID);
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID);
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID);
                if (oEngineerVisit.AppointmentID > 0)
                {
                    _database.AddParameter("@AppointmentID", oEngineerVisit.AppointmentID, true);
                }
                else
                {
                    _database.AddParameter("@AppointmentID", appointmentID, true);
                }

                _database.AddParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment, true);
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID, true);
                _database.AddParameter("@OldVisitId", oldVisitId, true);
                oEngineerVisit.SetEngineerVisitID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisit_Insert"));
                oEngineerVisit.Exists = true;
                var jA = new JobAudits.JobAudit() { SetJobID = JobID };
                if (oEngineerVisit.StatusEnumID == (int)Enums.VisitStatus.Scheduled)
                {
                    jA.SetActionChange = "New Visit Inserted - Status: Scheduled, to Engineer: " + App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)?.Name + " For " + Strings.Format(oEngineerVisit.StartDateTime, "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                }
                else
                {
                    jA.SetActionChange = "New Visit Inserted - Status: " + Strings.Replace(((Enums.VisitStatus)Conversions.ToInteger(oEngineerVisit.StatusEnumID)).ToString(), "_", " ") + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                }

                App.DB.JobAudit.Insert(jA);
                App.DB.EngineerVisitPartProductAllocated.Insert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID);
                return oEngineerVisit;
            }

            public bool EngineerVisits_UpdateStatus(int engineerVisitID, int statusEnumID, int outcomeEnumID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", engineerVisitID, true);
                _database.AddParameter("@VisitStatusID", statusEnumID, true);
                _database.AddParameter("@OutcomeID", outcomeEnumID, true);
                return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("EngineerVisits_UpdateStatus") == 1);
            }

            public bool EngineerVisit_ManualUpload(EngineerVisit engineerVisit)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", engineerVisit.EngineerVisitID, true);
                _database.AddParameter("@StatusEnumID", engineerVisit.StatusEnumID, true);
                _database.AddParameter("@OutcomeEnumID", engineerVisit.OutcomeEnumID, true);
                _database.AddParameter("@NotesFromEngineer", engineerVisit.NotesFromEngineer, true);
                return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("EngineerVisit_ManualUpload") == 1);
            }

            public EngineerVisit Update(EngineerVisit oEngineerVisit, int JobID, bool justStatus)
            {
                _database.ClearParameter();
                _database.AddParameter("@StatusEnumID", oEngineerVisit.StatusEnumID, true);
                _database.AddParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer, true);
                _database.AddParameter("@EngineerVisitID", oEngineerVisit.EngineerVisitID, true);
                _database.AddParameter("@PartsToFit", oEngineerVisit.PartsToFit, true);
                _database.AddParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID, true);
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge, true);
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID, true);
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID, true);
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID, true);
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID, true);
                _database.AddParameter("@VisitLocked", oEngineerVisit.VisitLocked, true);
                _database.AddParameter("@ExcludeFromTextMessage", oEngineerVisit.ExcludeFromTextMessage, true);
                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, true);
                if (!(oEngineerVisit.StartDateTime == DateTime.MinValue) | oEngineerVisit.StartDateTime != default)
                {
                    _database.AddParameter("@StartDateTime", oEngineerVisit.StartDateTime, true);
                }
                else
                {
                    _database.AddParameter("@StartDateTime", DBNull.Value, true);
                }

                if (!(oEngineerVisit.EndDateTime == DateTime.MinValue) | oEngineerVisit.EndDateTime != default)
                {
                    _database.AddParameter("@EndDateTime", oEngineerVisit.EndDateTime, true);
                }
                else
                {
                    _database.AddParameter("@EndDateTime", DBNull.Value, true);
                }

                _database.AddParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment);
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID);
                if (Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisit_Update")) == true)
                {
                    // Status Changed enter Job Audit
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID;
                    jA.SetActionChange = "Visit Status changed to " + Strings.Replace(((Enums.VisitStatus)Conversions.ToInteger(oEngineerVisit.StatusEnumID)).ToString(), "_", " ") + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                    App.DB.JobAudit.Insert(jA);
                }

                string msgStr = "";
                if (justStatus == false)
                {
                    foreach (DataRow row in oEngineerVisit.PartsAndProductsAllocated.Table.Rows)
                    {
                        // If IsDBNull(row.Item("ID")) OrElse row.Item("ID") = 0 Then
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderItemID"], 0, false)))
                        {
                            msgStr += Conversions.ToString(Conversions.ToString(" * " + row["Name"] + ", ") + row["Number"] + ", ") + row["Quantity"] + Constants.vbCrLf;
                        }

                        // End If
                    }

                    var dtOrder = new DataTable();
                    dtOrder = oEngineerVisit.PartsAndProductsAllocated.Table.Clone();
                    foreach (DataRow rowOrder in oEngineerVisit.PartsAndProductsAllocated.Table.Select("OrderItemID = 0 OR  QuantityOrdered  < Quantity "))
                        dtOrder.Rows.Add(rowOrder.ItemArray);

                    // DO THEY WANT TO ORDER NOW?
                    if (msgStr.Length > 0)
                    {
                        if (MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " + Constants.vbCrLf + msgStr + Constants.vbCrLf + " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMConvertToAnOrder), true, new object[] { Conversions.ToInteger(Enums.OrderType.Job), JobID, new DataView(dtOrder), 0, oEngineerVisit.EngineerVisitID });
                            foreach (DataRow rowAllocated2 in dtOrder.Rows)
                            {
                                rowAllocated2.AcceptChanges();
                                if (Information.IsDBNull(rowAllocated2["Quantity"]))
                                {
                                    rowAllocated2["Quantity"] = rowAllocated2["QuantityToOrder"];
                                }

                                App.DB.EngineerVisitPartProductAllocated.UpdateOne(Conversions.ToInteger(rowAllocated2["ID"]), oEngineerVisit.EngineerVisitID, Conversions.ToString(rowAllocated2["Type"]), Conversions.ToInteger(rowAllocated2["Quantity"]), Conversions.ToInteger(rowAllocated2["OrderItemID"]), Conversions.ToInteger(rowAllocated2["PartProductID"]), Helper.MakeIntegerValid(rowAllocated2["OrderLocationTypeID"]));
                            }
                        }
                    }

                    // For Each rowAllocated As DataRow In oEngineerVisit.PartsAndProductsAllocated.Table.Select("(ID IS NULL OR ID = 0) AND OrderItemID > 0")
                    foreach (DataRow rowallocated in dtOrder.Select("ID IS NULL OR ID = 0"))
                        App.DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, Conversions.ToString(rowallocated["Type"]), Conversions.ToInteger(rowallocated["Quantity"]), Conversions.ToInteger(rowallocated["OrderItemID"]), Conversions.ToInteger(rowallocated["PartProductID"]), Helper.MakeIntegerValid(rowallocated["OrderLocationTypeID"]));
                    // Next
                }

                return oEngineerVisit;
            }

            public EngineerVisit Update(EngineerVisit oEngineerVisit, int JobID, bool justStatus, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisit_Update";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@StatusEnumID", oEngineerVisit.StatusEnumID);
                Command.Parameters.AddWithValue("@NotesToEngineer", oEngineerVisit.NotesToEngineer);
                Command.Parameters.AddWithValue("@EngineerVisitID", oEngineerVisit.EngineerVisitID);
                Command.Parameters.AddWithValue("@PartsToFit", oEngineerVisit.PartsToFit);
                Command.Parameters.AddWithValue("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID);
                Command.Parameters.AddWithValue("@Recharge", oEngineerVisit.Recharge);
                Command.Parameters.AddWithValue("@RechargeType", oEngineerVisit.RechargeTypeID);
                Command.Parameters.AddWithValue("@NccRadID", oEngineerVisit.NccRadID);
                Command.Parameters.AddWithValue("@MeterCappedID", oEngineerVisit.MeterCappedID);
                Command.Parameters.AddWithValue("@MeterLocationID", oEngineerVisit.MeterLocationID);
                Command.Parameters.AddWithValue("@ExpectedDepartment", oEngineerVisit.MeterLocationID);
                Command.Parameters.AddWithValue("@FuelID", oEngineerVisit.FuelID);
                Command.Parameters.AddWithValue("@ExcludeFromTextMessage ", oEngineerVisit.ExcludeFromTextMessage);
                if (Helper.MakeBooleanValid(Command.ExecuteScalar()) == true)
                {
                    // Status Changed enter Job Audit
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID;
                    jA.SetActionChange = "Visit Status changed to " + Strings.Replace(((Enums.VisitStatus)Conversions.ToInteger(oEngineerVisit.StatusEnumID)).ToString(), "_", " ") + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                    App.DB.JobAudit.Insert(jA, trans);
                }

                if (oEngineerVisit.PartsAndProductsAllocated.Table is object)
                {
                    foreach (DataRow rowAllocated in oEngineerVisit.PartsAndProductsAllocated.Table.Rows)
                    {
                        if (Helper.MakeIntegerValid(rowAllocated["ID"]) == 0)
                        {
                            App.DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, Conversions.ToString(rowAllocated["Type"]), Conversions.ToInteger(rowAllocated["Quantity"]), Helper.MakeIntegerValid(rowAllocated["OrderItemID"]), Conversions.ToInteger(rowAllocated["PartProductID"]), Helper.MakeIntegerValid(rowAllocated["OrderLocationTypeID"]), trans);
                        }
                    }
                }

                oEngineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID, trans);
                if (oEngineerVisit.Change == true)
                {
                    // add audit
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID;
                    jA.SetActionChange = "Engineer Notes have been altered " + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                    App.DB.JobAudit.Insert(jA);
                }

                return oEngineerVisit;
            }

            public DataView EngineerVisits_Get_All_JobID(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@jobID", jobID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_JobID");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_All_JobNumber_Light(string jobNumber)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobNumber", jobNumber, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_JobNumber_Light");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_All_JobID(int jobID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisits_Get_All_JobID";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jobID", jobID));
                var Adapter = new System.Data.SqlClient.SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_ForVal(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_ForVal");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitSymptom_GetForVisit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitSymptom_GetForVisit");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get(int EngineerVisitID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisits_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID));
                var Adapter = new System.Data.SqlClient.SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisit_GetUpdate(int Where)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, true);
                _database.AddParameter("@Where", Where, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_GetUpdate");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_All(string Where)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, true);
                _database.AddParameter("@Where", Where, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_All");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Manager_Get_ByWhere(string Where, string addtionalWhere = "")
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, true);
                _database.AddParameter("@Where", Where, true);
                _database.AddParameter("@Where2", addtionalWhere, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Manager_Get_ByWhere");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerPerformance_Get(int Dept, int EngineerID, DateTime StartDate, DateTime EndDate, string performanceType)
            {
                _database.ClearParameter();
                _database.AddParameter("@Dept", Dept, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@EndDate", EndDate, true);
                _database.AddParameter("@PerType", performanceType, true);
                var dt = _database.ExecuteSP_DataTable("Engineer_Get_Performance");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Appliances_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Appliances_GetAll");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataTable EngineerVisits_VisitManager_New(int CustomerID, int SiteID, int EngineerID, int JobDefinitionEnumID, int JobTypeID, int VisitEnumID, int OutcomeEnumID, string JobNumber, string PONumber, string Postcode, DateTime? DateFrom, DateTime? DateTo, int RegionID, int ContractTypeID, string LetterType, DateTime? DueDateFrom, DateTime? DueDateTo, int ChargeInProgress, string CostsTo)
            {
                _database.ClearParameter();
                _database.AddParameter("@totalRowCount", 0, true);
                _database.AddParameter("@sortBy", "1", true);
                _database.AddParameter("@InvoiceTypeIDEnum", Conversions.ToInteger(Enums.InvoiceType.Visit), true);
                _database.AddParameter("@InvoicedIDEnum", Conversions.ToInteger(Enums.VisitStatus.Invoiced), true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Conversions.ToInteger(Enums.VisitStatus.Ready_To_Be_Invoiced), true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Conversions.ToInteger(Enums.VisitStatus.Not_To_Be_Invoiced), true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@SiteID", SiteID, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@JobDefinitionEnumID", JobDefinitionEnumID, true);
                _database.AddParameter("@JobTypeID", JobTypeID, true);
                _database.AddParameter("@VisitEnumID", VisitEnumID, true);
                _database.AddParameter("@OutcomeEnumID", OutcomeEnumID, true);
                _database.AddParameter("@JobNumber", JobNumber, true);
                _database.AddParameter("@PONumber", PONumber, true);
                _database.AddParameter("@Postcode", Postcode, true);
                _database.AddParameter("@DateFrom", DateFrom, true);
                _database.AddParameter("@DateTo", DateTo, true);
                _database.AddParameter("@RegionID", RegionID, true);
                _database.AddParameter("@ContractTypeID", ContractTypeID, true);
                _database.AddParameter("@LetterType", LetterType, true);
                _database.AddParameter("@DueDateFrom", DueDateFrom, true);
                _database.AddParameter("@DueDateTo", DueDateTo, true);
                _database.AddParameter("@ChargeInProgress", ChargeInProgress, true);
                _database.AddParameter("@CostsTo", CostsTo, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Manager_Search_NEW");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return dt;
            }

            public DataView EngineerVisits_Get_All_ForSite(string Where)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, true);
                _database.AddParameter("@Where", Where, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_ForSite");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_AllReady_ForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_AllReady_ForSite");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Search(string Criteria, bool HideCompleted = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", Criteria, true);
                if (HideCompleted)
                {
                    _database.AddParameter("@MaximumStatusID", Conversions.ToInteger(Enums.VisitStatus.Downloaded), true);
                }
                else
                {
                    _database.AddParameter("@MaximumStatusID", Conversions.ToInteger(Enums.VisitStatus.Uploaded), true);
                }

                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Search");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_For_Job_Of_Work(int JobOfWorkID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisits_Get_For_Job_Of_Work";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@JobOfWorkID", JobOfWorkID);
                var Adapter = new System.Data.SqlClient.SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_For_Job_Of_Work(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_For_Job_Of_Work");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisits_Get_For_Job_Of_Work_Light(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_For_Job_Of_Work_Light");
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                return new DataView(dt);
            }

            public EngineerVisit EngineerVisits_Get_As_Object(int EngineerVisitID, bool getFull = true)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get");
                if (dt.Rows.Count > 0)
                {
                    {
                        var withBlock = dt.Rows[0];
                        var visit = new EngineerVisit();
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.Exists = true;
                        visit.SetEngineerVisitID = withBlock["EngineerVisitID"];
                        visit.SetJobOfWorkID = withBlock["JobOfWorkID"];
                        visit.SetEngineerID = withBlock["EngineerID"];
                        visit.StartDateTime = Helper.MakeDateTimeValid(withBlock["StartDateTime"]);
                        visit.EndDateTime = Helper.MakeDateTimeValid(withBlock["EndDateTime"]);
                        visit.SetStatusEnumID = withBlock["StatusEnumID"];
                        visit.SetVisitStatus = withBlock["VisitStatus"];
                        visit.SetNotesToEngineer = withBlock["NotesToEngineer"];
                        visit.SetNotesFromEngineer = withBlock["NotesFromEngineer"];
                        visit.SetOutcomeEnumID = withBlock["OutcomeEnumID"];
                        visit.SetOutcomeDetails = withBlock["OutcomeDetails"];
                        visit.SetCustomerName = withBlock["CustomerName"];
                        visit.SetVisitOutcome = withBlock["VisitOutcome"];
                        if (!Information.IsDBNull(withBlock["CustomerSignature"]))
                        {
                            visit.CustomerSignature = (byte[])withBlock["CustomerSignature"];
                        }

                        if (!Information.IsDBNull(withBlock["EngineerSignature"]))
                        {
                            visit.EngineerSignature = (byte[])withBlock["EngineerSignature"];
                        }

                        if (Information.IsDBNull(withBlock["Downloading"]))
                        {
                            visit.Downloading = DateTime.MinValue;
                        }
                        else
                        {
                            visit.Downloading = Conversions.ToDate(withBlock["Downloading"]);
                        }

                        visit.SetManualEntryByUserID = withBlock["ManualEntryByUserID"];
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(withBlock["ManualEntryOn"]);
                        visit.SetVisitLocked = Conversions.ToBoolean(withBlock["VisitLocked"]);
                        visit.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        visit.SetGasInstallationTightnessTestID = withBlock["GasInstallationTightnessTestID"];
                        visit.SetEmergencyControlAccessibleID = withBlock["EmergencyControlAccessibleID"];
                        visit.SetBondingID = withBlock["BondingID"];
                        visit.SetExpectedEngineerID = withBlock["ExpectedEngineerID"];
                        visit.SetPropertyRented = withBlock["PropertyRented"];
                        visit.SetPaymentMethodID = withBlock["PaymentMethodID"];
                        visit.SetAmountCollected = withBlock["AmountCollected"];
                        visit.SetSignatureSelectedID = withBlock["SignatureSelectedID"];
                        visit.SetPartsToFit = withBlock["PartsToFit"];
                        visit.SetGasServiceCompleted = withBlock["GasServiceCompleted"];
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(withBlock["EmailReceipt"]);
                        visit.DueDate = Helper.MakeDateTimeValid(withBlock["DueDate"]);
                        visit.SetAMPM = withBlock["AMPM"];
                        visit.SetVisitNumber = withBlock["VisitNumber"];
                        visit.SetRecharge = Helper.MakeBooleanValid(withBlock["Recharge"]);
                        visit.SetCostsTo = withBlock["CostsTo"];
                        visit.EstimatedDate = Conversions.ToDate(withBlock["EstimatedVisitDate"]);
                        visit.setRechargeTypeID = withBlock["RechargeType"];
                        visit.setNccRadID = withBlock["NccRadID"];
                        visit.SetUseSORDescription = Helper.MakeBooleanValid(withBlock["UseSORDescription"]);
                        visit.SetMeterCappedID = withBlock["MeterCappedID"];
                        visit.SetMeterLocationID = withBlock["MeterLocationID"];
                        if (withBlock.Table.Columns.Contains("FuelID"))
                            visit.SetFuelID = withBlock["FuelID"];
                        if (withBlock.Table.Columns.Contains("ExcludeFromTextMessage"))
                            visit.SetExcludeFromTextMessage = withBlock["ExcludeFromTextMessage"];
                        if (getFull)
                        {
                            visit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID);
                            visit.TimeSheets = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
                            visit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID);
                            visit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID);
                            visit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID);
                        }

                        return visit;
                    }
                }
                else
                {
                    return null;
                }
            }

            public EngineerVisit EngineerVisits_Get_New_As_Object(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_New");
                if (dt.Rows.Count > 0)
                {
                    {
                        var withBlock = dt.Rows[0];
                        var visit = new EngineerVisit();
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.Exists = true;
                        visit.SetEngineerVisitID = withBlock["EngineerVisitID"];
                        visit.SetJobOfWorkID = withBlock["JobOfWorkID"];
                        visit.SetEngineerID = withBlock["EngineerID"];
                        visit.StartDateTime = Helper.MakeDateTimeValid(withBlock["StartDateTime"]);
                        visit.EndDateTime = Helper.MakeDateTimeValid(withBlock["EndDateTime"]);
                        visit.SetStatusEnumID = withBlock["StatusEnumID"];
                        visit.SetVisitStatus = withBlock["VisitStatus"];
                        visit.SetNotesToEngineer = withBlock["NotesToEngineer"];
                        visit.SetNotesFromEngineer = withBlock["NotesFromEngineer"];
                        visit.SetOutcomeEnumID = withBlock["OutcomeEnumID"];
                        visit.SetOutcomeDetails = withBlock["OutcomeDetails"];
                        visit.SetCustomerName = withBlock["CustomerName"];
                        visit.SetVisitOutcome = withBlock["VisitOutcome"];
                        if (!Information.IsDBNull(withBlock["CustomerSignature"]))
                        {
                            visit.CustomerSignature = (byte[])withBlock["CustomerSignature"];
                        }

                        if (!Information.IsDBNull(withBlock["EngineerSignature"]))
                        {
                            visit.EngineerSignature = (byte[])withBlock["EngineerSignature"];
                        }

                        if (Information.IsDBNull(withBlock["Downloading"]))
                        {
                            visit.Downloading = DateTime.MinValue;
                        }
                        else
                        {
                            visit.Downloading = Conversions.ToDate(withBlock["Downloading"]);
                        }

                        visit.SetManualEntryByUserID = withBlock["ManualEntryByUserID"];
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(withBlock["ManualEntryOn"]);
                        visit.SetVisitLocked = Conversions.ToBoolean(withBlock["VisitLocked"]);
                        visit.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        visit.SetGasInstallationTightnessTestID = withBlock["GasInstallationTightnessTestID"];
                        visit.SetEmergencyControlAccessibleID = withBlock["EmergencyControlAccessibleID"];
                        visit.SetBondingID = withBlock["BondingID"];
                        visit.SetExpectedEngineerID = withBlock["ExpectedEngineerID"];
                        visit.SetPropertyRented = withBlock["PropertyRented"];
                        visit.SetPaymentMethodID = withBlock["PaymentMethodID"];
                        visit.SetAmountCollected = withBlock["AmountCollected"];
                        visit.SetSignatureSelectedID = withBlock["SignatureSelectedID"];
                        visit.SetPartsToFit = withBlock["PartsToFit"];
                        visit.SetGasServiceCompleted = withBlock["GasServiceCompleted"];
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(withBlock["EmailReceipt"]);
                        visit.DueDate = Helper.MakeDateTimeValid(withBlock["DueDate"]);
                        visit.SetAMPM = withBlock["AMPM"];
                        visit.SetVisitNumber = withBlock["VisitNumber"];
                        visit.SetRecharge = Helper.MakeBooleanValid(withBlock["Recharge"]);
                        visit.SetCostsTo = withBlock["CostsTo"];
                        visit.EstimatedDate = Conversions.ToDate(withBlock["EstimatedVisitDate"]);
                        visit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID);
                        visit.TimeSheets = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
                        visit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID);
                        visit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID);
                        visit.setRechargeTypeID = withBlock["RechargeType"];
                        visit.setNccRadID = withBlock["NccRadID"];
                        visit.SetUseSORDescription = Helper.MakeBooleanValid(withBlock["UseSORDescription"]);
                        visit.SetMeterCappedID = withBlock["MeterCappedID"];
                        visit.SetMeterLocationID = withBlock["MeterLocationID"];
                        visit.SetExpectedDepartment = withBlock["ExpectedDepartment"];
                        if (withBlock.Table.Columns.Contains("FuelID"))
                            visit.SetFuelID = withBlock["FuelID"];
                        return visit;
                    }
                }
                else
                {
                    return null;
                }
            }

            public EngineerVisit EngineerVisits_Get_LastForJob_Light(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID_Light");
                if (dt.Rows.Count > 0)
                {
                    {
                        var withBlock = dt.Rows[0];
                        var visit = new EngineerVisit();
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.Exists = true;
                        visit.SetEngineerVisitID = withBlock["EngineerVisitID"];
                        visit.SetJobOfWorkID = withBlock["JobOfWorkID"];
                        visit.SetEngineerID = withBlock["EngineerID"];
                        visit.StartDateTime = Helper.MakeDateTimeValid(withBlock["StartDateTime"]);
                        visit.EndDateTime = Helper.MakeDateTimeValid(withBlock["EndDateTime"]);
                        visit.SetStatusEnumID = withBlock["StatusEnumID"];
                        visit.SetNotesToEngineer = withBlock["NotesToEngineer"];
                        visit.SetNotesFromEngineer = withBlock["NotesFromEngineer"];
                        visit.SetOutcomeEnumID = withBlock["OutcomeEnumID"];
                        visit.SetOutcomeDetails = withBlock["OutcomeDetails"];
                        visit.SetCustomerName = withBlock["CustomerName"];
                        visit.SetVisitOutcome = withBlock["VisitOutcome"];
                        visit.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        return visit;
                    }
                }
                else
                {
                    return null;
                }
            }

            public EngineerVisit EngineerVisits_Get_As_Object(int EngineerVisitID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisits_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@EngineerVisitID", EngineerVisitID);
                var Adapter = new System.Data.SqlClient.SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    {
                        var withBlock = dt.Rows[0];
                        var visit = new EngineerVisit();
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.Exists = true;
                        visit.SetEngineerVisitID = withBlock["EngineerVisitID"];
                        visit.SetJobOfWorkID = withBlock["JobOfWorkID"];
                        visit.SetEngineerID = withBlock["EngineerID"];
                        visit.StartDateTime = Helper.MakeDateTimeValid(withBlock["StartDateTime"]);
                        visit.EndDateTime = Helper.MakeDateTimeValid(withBlock["EndDateTime"]);
                        visit.SetStatusEnumID = withBlock["StatusEnumID"];
                        visit.SetNotesToEngineer = withBlock["NotesToEngineer"];
                        visit.SetNotesFromEngineer = withBlock["NotesFromEngineer"];
                        visit.SetOutcomeEnumID = withBlock["OutcomeEnumID"];
                        visit.SetOutcomeDetails = withBlock["OutcomeDetails"];
                        visit.SetCustomerName = withBlock["CustomerName"];
                        visit.SetVisitOutcome = withBlock["VisitOutcome"];
                        if (!Information.IsDBNull(withBlock["CustomerSignature"]))
                        {
                            visit.CustomerSignature = (byte[])withBlock["CustomerSignature"];
                        }

                        if (!Information.IsDBNull(withBlock["EngineerSignature"]))
                        {
                            visit.EngineerSignature = (byte[])withBlock["EngineerSignature"];
                        }

                        if (Information.IsDBNull(withBlock["Downloading"]))
                        {
                            visit.Downloading = DateTime.MinValue;
                        }
                        else
                        {
                            visit.Downloading = Conversions.ToDate(withBlock["Downloading"]);
                        }

                        visit.SetManualEntryByUserID = withBlock["ManualEntryByUserID"];
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(withBlock["ManualEntryOn"]);
                        visit.SetVisitLocked = Conversions.ToBoolean(withBlock["VisitLocked"]);
                        visit.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        visit.SetGasInstallationTightnessTestID = withBlock["GasInstallationTightnessTestID"];
                        visit.SetEmergencyControlAccessibleID = withBlock["EmergencyControlAccessibleID"];
                        visit.SetBondingID = withBlock["BondingID"];
                        visit.SetExpectedEngineerID = withBlock["ExpectedEngineerID"];
                        visit.SetPropertyRented = withBlock["PropertyRented"];
                        visit.SetPaymentMethodID = withBlock["PaymentMethodID"];
                        visit.SetAmountCollected = withBlock["AmountCollected"];
                        visit.SetSignatureSelectedID = withBlock["SignatureSelectedID"];
                        visit.SetPartsToFit = withBlock["PartsToFit"];
                        visit.SetGasServiceCompleted = withBlock["GasServiceCompleted"];
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(withBlock["EmailReceipt"]);
                        visit.SetRecharge = Helper.MakeBooleanValid(withBlock["Recharge"]);
                        visit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID);
                        // SMOKE
                        // visit.EngineerVisitSMOKE = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(visit.EngineerVisitID, 68649)
                        // COMO
                        // visit.EngineerVisitCOMO = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(visit.EngineerVisitID, 68650)
                        visit.EstimatedDate = Conversions.ToDate(withBlock["EstimatedVisitDate"]);
                        visit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID);
                        visit.setRechargeTypeID = withBlock["RechargeType"];
                        visit.setNccRadID = withBlock["NccRadID"];
                        visit.SetMeterCappedID = withBlock["MeterCappedID"];
                        visit.SetMeterLocationID = withBlock["MeterLocationID"];
                        visit.SetExpectedDepartment = withBlock["ExpectedDepartment"];
                        if (withBlock.Table.Columns.Contains("FuelID"))
                            visit.SetFuelID = withBlock["FuelID"];
                        return visit;
                    }
                }
                else
                {
                    return null;
                }
            }

            public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID)
            {
                var engineerVisits = new ArrayList();
                foreach (DataRow row in EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows)
                {
                    var visit = new EngineerVisit();
                    visit.IgnoreExceptionsOnSetMethods = true;
                    visit.Exists = true;
                    visit.SetEngineerVisitID = row["EngineerVisitID"];
                    visit.SetJobOfWorkID = row["JobOfWorkID"];
                    visit.SetEngineerID = row["EngineerID"];
                    visit.StartDateTime = Helper.MakeDateTimeValid(row["StartDateTime"]);
                    visit.EndDateTime = Helper.MakeDateTimeValid(row["EndDateTime"]);
                    visit.SetStatusEnumID = row["StatusEnumID"];
                    visit.SetNotesToEngineer = row["NotesToEngineer"];
                    visit.SetNotesFromEngineer = row["NotesFromEngineer"];
                    visit.SetOutcomeEnumID = row["OutcomeEnumID"];
                    visit.SetOutcomeDetails = row["OutcomeDetails"];
                    visit.SetCustomerName = row["CustomerName"];
                    if (Information.IsDBNull(row["Downloading"]))
                    {
                        visit.Downloading = DateTime.MinValue;
                    }
                    else
                    {
                        visit.Downloading = Conversions.ToDate(row["Downloading"]);
                    }

                    visit.SetManualEntryByUserID = row["ManualEntryByUserID"];
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row["ManualEntryOn"]);
                    visit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
                    visit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    visit.SetGasInstallationTightnessTestID = row["GasInstallationTightnessTestID"];
                    visit.SetEmergencyControlAccessibleID = row["EmergencyControlAccessibleID"];
                    visit.SetPaymentMethodID = row["PaymentMethodID"];
                    visit.SetAmountCollected = row["AmountCollected"];
                    visit.SetBondingID = row["BondingID"];
                    visit.SetExpectedEngineerID = row["ExpectedEngineerID"];
                    visit.SetPropertyRented = row["PropertyRented"];
                    visit.SetSignatureSelectedID = row["SignatureSelectedID"];
                    visit.SetPartsToFit = row["PartsToFit"];
                    visit.SetGasServiceCompleted = row["GasServiceCompleted"];
                    visit.SetEmailReceipt = Helper.MakeBooleanValid(row["EmailReceipt"]);
                    visit.SetRecharge = Helper.MakeBooleanValid(row["Recharge"]);
                    visit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID);
                    visit.EngineerVisitNCCGSR = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID);
                    visit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
                    visit.setRechargeTypeID = row["RechargeType"];
                    visit.setNccRadID = row["NccRadID"];
                    visit.SetVisitNumber = row["VisitNumber"];
                    visit.SetUseSORDescription = Helper.MakeBooleanValid(row["UseSORDescription"]);
                    visit.SetMeterCappedID = row["MeterCappedID"];
                    visit.SetMeterLocationID = row["MeterLocationID"];
                    visit.SetExpectedDepartment = row["ExpectedDepartment"];
                    if (row.Table.Columns.Contains("FuelID"))
                        visit.SetFuelID = row["FuelID"];
                    engineerVisits.Add(visit);
                }

                return engineerVisits;
            }

            public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(int JobOfWorkID)
            {
                var engineerVisits = new ArrayList();
                foreach (DataRow row in EngineerVisits_Get_For_Job_Of_Work_Light(JobOfWorkID).Table.Rows)
                {
                    var visit = new EngineerVisit();
                    visit.IgnoreExceptionsOnSetMethods = true;
                    visit.Exists = true;
                    visit.SetEngineerVisitID = row["EngineerVisitID"];
                    visit.SetJobOfWorkID = row["JobOfWorkID"];
                    visit.SetEngineerID = row["EngineerID"];
                    visit.StartDateTime = Helper.MakeDateTimeValid(row["StartDateTime"]);
                    visit.EndDateTime = Helper.MakeDateTimeValid(row["EndDateTime"]);
                    visit.SetStatusEnumID = row["StatusEnumID"];
                    visit.SetNotesToEngineer = row["NotesToEngineer"];
                    visit.SetNotesFromEngineer = row["NotesFromEngineer"];
                    visit.SetOutcomeEnumID = row["OutcomeEnumID"];
                    visit.SetOutcomeDetails = row["OutcomeDetails"];
                    visit.SetCustomerName = row["CustomerName"];
                    visit.SetAMPM = row["AMPM"];
                    visit.SetRecharge = Helper.MakeBooleanValid(row["Recharge"]);
                    visit.SetManualEntryByUserID = row["ManualEntryByUserID"];
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row["ManualEntryOn"]);
                    visit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    visit.SetExpectedEngineerID = row["ExpectedEngineerID"];
                    visit.SetPartsToFit = row["PartsToFit"];
                    visit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID);
                    visit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
                    visit.SetVisitNumber = row["VisitNumber"];
                    if (row.Table.Columns.Contains("FuelID"))
                        visit.SetFuelID = row["FuelID"];
                    engineerVisits.Add(visit);
                }

                return engineerVisits;
            }

            public ArrayList EngineerVisits_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID, System.Data.SqlClient.SqlTransaction trans)
            {
                var engineerVisits = new ArrayList();
                foreach (DataRow row in EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows)
                {
                    var visit = new EngineerVisit();
                    visit.IgnoreExceptionsOnSetMethods = true;
                    visit.Exists = true;
                    visit.SetEngineerVisitID = row["EngineerVisitID"];
                    visit.SetJobOfWorkID = row["JobOfWorkID"];
                    visit.SetEngineerID = row["EngineerID"];
                    visit.StartDateTime = Helper.MakeDateTimeValid(row["StartDateTime"]);
                    visit.EndDateTime = Helper.MakeDateTimeValid(row["EndDateTime"]);
                    visit.SetStatusEnumID = row["StatusEnumID"];
                    visit.SetNotesToEngineer = row["NotesToEngineer"];
                    visit.SetNotesFromEngineer = row["NotesFromEngineer"];
                    visit.SetOutcomeEnumID = row["OutcomeEnumID"];
                    visit.SetOutcomeDetails = row["OutcomeDetails"];
                    visit.SetCustomerName = row["CustomerName"];
                    if (!Information.IsDBNull(row["CustomerSignature"]))
                    {
                        visit.CustomerSignature = (byte[])row["CustomerSignature"];
                    }

                    if (!Information.IsDBNull(row["EngineerSignature"]))
                    {
                        visit.EngineerSignature = (byte[])row["EngineerSignature"];
                    }

                    if (Information.IsDBNull(row["Downloading"]))
                    {
                        visit.Downloading = DateTime.MinValue;
                    }
                    else
                    {
                        visit.Downloading = Conversions.ToDate(row["Downloading"]);
                    }

                    visit.SetManualEntryByUserID = row["ManualEntryByUserID"];
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row["ManualEntryOn"]);
                    visit.SetVisitLocked = Conversions.ToBoolean(row["VisitLocked"]);
                    visit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    visit.SetGasInstallationTightnessTestID = row["GasInstallationTightnessTestID"];
                    visit.SetEmergencyControlAccessibleID = row["EmergencyControlAccessibleID"];
                    visit.SetPaymentMethodID = row["PaymentMethodID"];
                    visit.SetAmountCollected = row["AmountCollected"];
                    visit.SetBondingID = row["BondingID"];
                    visit.SetExpectedEngineerID = row["ExpectedEngineerID"];
                    visit.SetPropertyRented = row["PropertyRented"];
                    visit.SetSignatureSelectedID = row["SignatureSelectedID"];
                    visit.SetPartsToFit = row["PartsToFit"];
                    visit.SetGasServiceCompleted = row["GasServiceCompleted"];
                    visit.SetEmailReceipt = Helper.MakeBooleanValid(row["EmailReceipt"]);
                    visit.SetRecharge = Helper.MakeBooleanValid(row["Recharge"]);
                    visit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID, trans);
                    visit.EstimatedDate = Conversions.ToDate(row["EstimatedVisitDate"]);
                    visit.setRechargeTypeID = row["RechargeType"];
                    visit.setNccRadID = row["NccRadID"];
                    visit.SetMeterCappedID = row["MeterCappedID"];
                    visit.SetMeterLocationID = row["MeterLocationID"];
                    visit.SetExpectedDepartment = row["ExpectedDepartment"];
                    if (row.Table.Columns.Contains("FuelID"))
                        visit.SetFuelID = row["FuelID"];
                    engineerVisits.Add(visit);
                }

                return engineerVisits;
            }

            public EngineerVisit ManuallyComplete(EngineerVisit oEngineerVisit, DataView JobItemsDataview, DataView PartsAndProductsDistribution)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, true);
                _database.AddParameter("@StatusEnumID", Conversions.ToInteger(Enums.VisitStatus.Uploaded), true);
                _database.AddParameter("@NotesFromEngineer", oEngineerVisit.NotesFromEngineer, true);
                _database.AddParameter("@OutcomeEnumID", oEngineerVisit.OutcomeEnumID, true);
                _database.AddParameter("@OutcomeDetails", oEngineerVisit.OutcomeDetails, true);
                _database.AddParameter("@CustomerName", oEngineerVisit.CustomerName, true);
                _database.AddParameter("@ManualEntryByUserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@EngineerVisitID", oEngineerVisit.EngineerVisitID, true);
                _database.AddParameter("@VisitLocked", oEngineerVisit.VisitLocked, true);
                _database.AddParameter("@GasInstallationTightnessTestID", oEngineerVisit.GasInstallationTightnessTestID, true);
                _database.AddParameter("@EmergencyControlAccessibleID", oEngineerVisit.EmergencyControlAccessibleID, true);
                _database.AddParameter("@BondingID", oEngineerVisit.BondingID, true);
                _database.AddParameter("@PropertyRented", oEngineerVisit.PropertyRented, true);
                _database.AddParameter("@SignatureSelectedID", oEngineerVisit.SignatureSelectedID, true);
                _database.AddParameter("@PaymentMethodID", oEngineerVisit.PaymentMethodID, true);
                _database.AddParameter("@AmountCollected", oEngineerVisit.AmountCollected, true);
                _database.AddParameter("@GasServiceCompleted", oEngineerVisit.GasServiceCompleted, true);
                _database.AddParameter("@EmailReceipt", oEngineerVisit.EmailReceipt, true);
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge, true);
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID, true);
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID, true);
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID, true);
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID, true);
                _database.AddParameter("@CostsTo", oEngineerVisit.CostsTo, true);
                _database.AddParameter("@UseSORDescription", oEngineerVisit.UseSORDescription, true);
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID, true);
                if (Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisit_ManuallyComplete_CheckChange")) == true)
                {
                    // Status Changed enter Job Audit
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID;
                    jA.SetActionChange = "Visit Status changed to " + Enums.VisitStatus.Uploaded.ToString() + ", Outcome: " + Strings.Replace(((Enums.EngineerVisitOutcomes)Conversions.ToInteger(oEngineerVisit.OutcomeEnumID)).ToString(), "_", " ") + ", GasServiceComplete: " + oEngineerVisit.GasServiceCompleted.ToString() + " (Unique Visit ID: " + oEngineerVisit.EngineerVisitID + ")";
                    App.DB.JobAudit.Insert(jA);
                }

                foreach (DataRow row in oEngineerVisit.PartsAndProductsUsed.Table.Rows)
                {
                    var oPartOrProduct = new EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProducts();
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Part", false)))
                    {
                        if (Helper.MakeIntegerValid(row["UniqueID"]) == 0)
                        {
                            oPartOrProduct.SetEngineerVisitID = oEngineerVisit.EngineerVisitID;
                            oPartOrProduct.SetAssetID = 0;
                            oPartOrProduct.SetPartOrProductID = row["ID"];
                            oPartOrProduct.SetQuantity = row["Quantity"];
                            oPartOrProduct.SetAllocatedID = row["AllocatedID"];
                            oPartOrProduct.SetSpecialDescription = row["SpecialDescription"];
                            oPartOrProduct.SetSpecialPartNumber = row["SpecialPartNumber"];
                            oPartOrProduct.SetSpecialPrice = row["SpecialPrice"];
                            _database.EngineerVisitsPartsAndProducts.PartsUsed_Insert(oPartOrProduct);
                        }
                        else
                        {
                            _database.EngineerVisitsPartsAndProducts.PartsUsed_Update(Conversions.ToInteger(row["UniqueID"]), Conversions.ToInteger(row["Quantity"]));
                        }
                    }
                    else if (Helper.MakeIntegerValid(row["UniqueID"]) == 0)
                    {
                        oPartOrProduct.SetEngineerVisitID = oEngineerVisit.EngineerVisitID;
                        oPartOrProduct.SetPartOrProductID = row["ID"];
                        oPartOrProduct.SetQuantity = row["Quantity"];
                        _database.EngineerVisitsPartsAndProducts.ProductsUsed_Insert(oPartOrProduct);
                        if (Helper.MakeIntegerValid(row["UniqueID"]) == 0)
                        {
                            for (int x = 0, loopTo = Conversions.ToInteger(row["Quantity"]) - 1; x <= loopTo; x++)
                            {
                                if (App.ShowMessage(Conversions.ToString("Would you like to add Product: '" + row["Name"] + "' as an Asset for this Site?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    App.ShowForm(typeof(FRMAsset), true, new object[] { 0, row["ID"], App.DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId).SiteID });
                                }
                            }
                        }
                    }
                    else
                    {
                        _database.EngineerVisitsPartsAndProducts.ProductsUsed_Update(Conversions.ToInteger(row["UniqueID"]), Conversions.ToInteger(row["Quantity"]));
                    }
                }

                AllocatedDistributions(PartsAndProductsDistribution);
                var oJob = new Jobs.Job();
                oJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);

                // THIS IS TO STOP IT INSERTING EVERY TIME - ALP
                if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Enums.VisitStatus.Uploaded))
                {
                    if (!App.DB.Job.Job_WasGeneratedByLetter(oJob.JobID))
                    {
                        var switchExpr = oEngineerVisit.OutcomeEnumID;
                        switch (switchExpr)
                        {
                            case (int)Enums.EngineerVisitOutcomes.Carded:
                                {
                                    if (oEngineerVisit.VisitNumber > 0)
                                    {
                                        break;
                                    }

                                    var newJOW = new JobOfWorks.JobOfWork();
                                    newJOW.SetJobID = oJob.JobID;
                                    var dt = App.DB.JobOfWorks.JobOfWork_Get_For_Job(newJOW.JobID).Table;
                                    newJOW.SetPONumber = dt.Rows[dt.Rows.Count - 1]["PONumber"];
                                    newJOW = App.DB.JobOfWorks.Insert(newJOW);
                                    var autoNextVisit = new EngineerVisit();
                                    autoNextVisit.SetJobOfWorkID = newJOW.JobOfWorkID;
                                    autoNextVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                                    autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)" + Constants.vbCrLf + "PREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + Constants.vbCrLf;
                                    autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit;
                                    autoNextVisit.DueDate = default;
                                    autoNextVisit.SetAMPM = "";
                                    autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID);
                                    // newJOW.EngineerVisits.Add(autoNextVisit)

                                    autoNextVisit = Insert(autoNextVisit, App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID);

                                    // SEE ABOVE *
                                    var movedOrders = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, autoNextVisit.EngineerVisitID);
                                    var dvVisits = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                                    bool visitsComplete = true;
                                    foreach (DataRow rowVisit in dvVisits.Table.Rows)
                                    {
                                        if (Conversions.ToBoolean((int)rowVisit["StatusEnumID"] < Conversions.ToInteger(Enums.VisitStatus.Uploaded)))
                                        {
                                            visitsComplete = false;
                                        }
                                    }

                                    if (visitsComplete == true)
                                    {
                                        App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, Conversions.ToInteger(Enums.JobOfWorkStatus.Complete));
                                    }

                                    break;
                                }

                            case (int)Enums.EngineerVisitOutcomes.Declined:
                                {
                                    var autoNextVisit = new EngineerVisit();
                                    autoNextVisit.SetJobOfWorkID = oEngineerVisit.JobOfWorkID;
                                    autoNextVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                                    autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)" + Constants.vbCrLf + "PREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + Constants.vbCrLf;
                                    autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit;
                                    autoNextVisit.DueDate = default;
                                    autoNextVisit.SetAMPM = "";
                                    autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID);
                                    autoNextVisit = Insert(autoNextVisit, oJob.JobID);
                                    break;
                                }

                            case (int)Enums.EngineerVisitOutcomes.Further_Works:
                                {
                                    var autoNextVisit = new EngineerVisit();
                                    autoNextVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Parts_Need_Ordering);
                                    autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)" + Constants.vbCrLf + "PREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + Constants.vbCrLf;
                                    autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit;
                                    autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID);
                                    var newJOW = new JobOfWorks.JobOfWork();
                                    newJOW.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID;
                                    var dt = App.DB.JobOfWorks.JobOfWork_Get_For_Job(newJOW.JobID).Table;
                                    newJOW.SetPONumber = dt.Rows[dt.Rows.Count - 1]["PONumber"];
                                    var oPriority = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'P1 - 5 Days'");
                                    if (oPriority.Length > 0)
                                    {
                                        newJOW.SetPriority = Conversions.ToInteger(oPriority[0]["ManagerID"]);
                                    }

                                    newJOW.EngineerVisits.Add(autoNextVisit);
                                    newJOW = App.DB.JobOfWorks.Insert(newJOW);
                                    var movedOrders = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, autoNextVisit.EngineerVisitID);
                                    var dvVisits = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                                    bool visitsComplete = true;
                                    foreach (DataRow rowVisit in dvVisits.Table.Rows)
                                    {
                                        if (Conversions.ToBoolean((int)rowVisit["StatusEnumID"] < Conversions.ToInteger(Enums.VisitStatus.Uploaded)))
                                        {
                                            visitsComplete = false;
                                        }
                                    }

                                    if (visitsComplete == true)
                                    {
                                        App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, Conversions.ToInteger(Enums.JobOfWorkStatus.Complete));
                                    }

                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                                // DO NOTHING
                        }
                    }
                    else if (oEngineerVisit.OutcomeEnumID == (int)Enums.EngineerVisitOutcomes.Declined)
                    {
                        var autoNextVisit = new EngineerVisit();
                        autoNextVisit.SetJobOfWorkID = oEngineerVisit.JobOfWorkID;
                        autoNextVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                        autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " + oEngineerVisit.OutcomeDetails + ".)" + Constants.vbCrLf + "PREVIOUS NOTES : " + oEngineerVisit.NotesToEngineer + Constants.vbCrLf;
                        autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit;
                        autoNextVisit.SetVisitNumber = oEngineerVisit.VisitNumber;
                        autoNextVisit.DueDate = oEngineerVisit.DueDate;
                        autoNextVisit.SetAMPM = oEngineerVisit.AMPM;
                        autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID);
                        autoNextVisit = Insert(autoNextVisit, oJob.JobID);
                    }

                    if (Conversions.ToInteger(oEngineerVisit.OutcomeEnumID) == (int)Enums.EngineerVisitOutcomes.Could_Not_Start)
                    {
                        var dvVisits = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                        bool visitsComplete = true;
                        foreach (DataRow rowVisit in dvVisits.Table.Rows)
                        {
                            if (Conversions.ToBoolean((int)rowVisit["StatusEnumID"] < Conversions.ToInteger(Enums.VisitStatus.Uploaded)))
                            {
                                visitsComplete = false;
                            }
                        }

                        if (visitsComplete == true)
                        {
                            App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, Conversions.ToInteger(Enums.JobOfWorkStatus.Closed));
                        }
                    }
                    else if (Conversions.ToInteger(oEngineerVisit.OutcomeEnumID) == (int)Enums.EngineerVisitOutcomes.Complete)
                    {
                        var dvVisits = App.DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID);
                        bool visitsComplete = true;
                        foreach (DataRow rowVisit in dvVisits.Table.Rows)
                        {
                            if (Conversions.ToBoolean((int)rowVisit["StatusEnumID"] < Conversions.ToInteger(Enums.VisitStatus.Uploaded)))
                            {
                                visitsComplete = false;
                            }
                        }

                        if (visitsComplete == true)
                        {
                            App.DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, Conversions.ToInteger(Enums.JobOfWorkStatus.Complete));
                        }
                    }
                }

                // PART AND PRODUCTS - NEEDED
                _database.EngineerVisitsPartsAndProducts.PartsNeeded_Delete(oEngineerVisit.EngineerVisitID);
                _database.EngineerVisitsPartsAndProducts.ProductsNeeded_Delete(oEngineerVisit.EngineerVisitID);
                _database.EngineerVisitsTimeSheet.Delete(oEngineerVisit.EngineerVisitID);
                foreach (DataRow row in oEngineerVisit.TimeSheets.Table.Rows)
                {
                    var oTimeSheet = new EngineerVisitTimeSheets.EngineerVisitTimeSheet();
                    oTimeSheet.SetEngineerVisitID = oEngineerVisit.EngineerVisitID;
                    oTimeSheet.StartDateTime = Conversions.ToDate(row["StartDateTime"]);
                    oTimeSheet.EndDateTime = Conversions.ToDate(row["EndDateTime"]);
                    oTimeSheet.SetComments = row["Comments"];
                    oTimeSheet.SetTimeSheetTypeID = row["TimesheetTypeID"];
                    _database.EngineerVisitsTimeSheet.Insert(oTimeSheet);
                }

                // UPDATE ASSET SERVICED
                if ((Enums.JobDefinition)Conversions.ToInteger(oJob.JobDefinitionEnumID) == Enums.JobDefinition.Contract | oEngineerVisit.GasServiceCompleted == true)
                {
                    foreach (object oJobAsset in oJob.Assets)
                    {
                        var asset = new Assets.Asset();
                        asset = App.DB.Asset.Asset_Get(((JobAssets.JobAsset)oJobAsset).AssetID);
                        asset.LastServicedDate = DateAndTime.Now;
                        App.DB.Asset.Update(asset);
                    }
                }

                // UPDATE SITE LAST SERVICED DATE
                if (oJob.JobTypeID == Conversions.ToInteger(Enums.JobTypes.ServiceCertificate) | oJob.JobTypeID == Conversions.ToInteger(Enums.JobTypes.Commission) | oJob.JobTypeID == Conversions.ToInteger(Enums.JobTypes.Service))
                {
                    if (oEngineerVisit.GasServiceCompleted == true & oEngineerVisit.OutcomeEnumID == Conversions.ToInteger(Enums.EngineerVisitOutcomes.Complete))
                    {
                        var customer = App.DB.Customer.Customer_Get_ForSiteID(oJob.PropertyID);
                        bool motstyle = false;
                        if (customer is object && customer.MOTStyleService == true)
                            motstyle = true;
                        bool reinstate = false;
                        if (oEngineerVisit.EngineerVisitNCCGSR is object && oEngineerVisit.EngineerVisitNCCGSR.CertificateTypeID == Conversions.ToInteger(Enums.CertificateType.Reinstate))
                        {
                            reinstate = true;
                        }

                        DateTime actualServiceDate;
                        if (oEngineerVisit.StartDateTime == DateTime.MinValue)
                        {
                            if (oEngineerVisit.TimeSheets.Table.Rows.Count > 0)
                            {
                                actualServiceDate = Conversions.ToDate(oEngineerVisit.TimeSheets.Table.Rows[0]["StartDateTime"]);
                            }
                            else
                            {
                                actualServiceDate = DateAndTime.Now;
                            }
                        }
                        else
                        {
                            actualServiceDate = oEngineerVisit.StartDateTime;
                        }

                        DateTime oldLastServiceDate = default;
                        DateTime lastServiceDate = default;
                        // update all
                        DataRow[] siteFuels;
                        if (oEngineerVisit.FuelID == 0)
                        {
                            siteFuels = App.DB.Sites.SiteFuel_GetAll_ForSite(oJob.PropertyID).Table.Select();
                        }
                        else
                        {
                            siteFuels = App.DB.Sites.SiteFuel_GetAll_ForSite(oJob.PropertyID).Table.Select("FuelID = " + oEngineerVisit.FuelID);
                        }

                        if (siteFuels.Length > 0)
                        {
                            foreach (DataRow fuel in siteFuels)
                            {
                                oldLastServiceDate = Helper.MakeDateTimeValid(fuel["LastServiceDate"]);
                                int sfServiceDiff = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Month, actualServiceDate, oldLastServiceDate.AddYears(1)));
                                if (oldLastServiceDate.AddYears(1) > actualServiceDate & sfServiceDiff >= 0 & sfServiceDiff <= 2 & motstyle & Conversions.ToInteger(fuel["FuelID"]) == Conversions.ToInteger(Enums.FuelTypes.NatGas) & !reinstate)
                                {
                                    lastServiceDate = oldLastServiceDate.AddYears(1);
                                }
                                else
                                {
                                    lastServiceDate = actualServiceDate;
                                }

                                if (Helper.MakeDateTimeValid(fuel["LastServiceDate"]).Date != lastServiceDate)
                                {
                                    string change = "Service Completed: Updated " + App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(fuel["FuelID"])).Name + ", changed last service date from " + Conversions.ToDate(fuel["LastServiceDate"]).Date + " to " + lastServiceDate;
                                    App.DB.Sites.SiteFuel_Update_LastServiceDate(oJob.PropertyID, Conversions.ToInteger(fuel["FuelID"]), lastServiceDate, actualServiceDate);
                                    if (!string.IsNullOrEmpty(change))
                                        App.DB.Sites.SiteFuelAudit_Insert(oJob.PropertyID, change);
                                }
                            }
                        }

                        if (lastServiceDate == default)
                            lastServiceDate = actualServiceDate;
                        App.DB.Sites.Site_UpdateLastServiceDate(oJob.PropertyID, lastServiceDate, actualServiceDate);
                    }
                }

                EngineerVisitUnitsUsed_Delete(oEngineerVisit.EngineerVisitID);
                if (JobItemsDataview is object)
                {
                    foreach (DataRow jobItemDR in JobItemsDataview.Table.Rows)
                        EngineerVisitUnitsUsed_Insert(oEngineerVisit.EngineerVisitID, Conversions.ToInteger(jobItemDR["JobItemID"]), Helper.MakeDoubleValid(jobItemDR["NumUnitsUsed"]));
                }

                // NCC FIELDS
                if (oEngineerVisit.EngineerVisitNCCGSR is object)
                {
                    if (oEngineerVisit.EngineerVisitNCCGSR.Exists)
                    {
                        App.DB.EngineerVisitNCCGSR.Update(oEngineerVisit.EngineerVisitNCCGSR);
                    }
                    else
                    {
                        App.DB.EngineerVisitNCCGSR.Insert(oEngineerVisit.EngineerVisitNCCGSR);
                    }
                }

                return EngineerVisits_Get_New_As_Object(oEngineerVisit.EngineerVisitID);
            }

            private void AllocatedDistributions(DataView PartsAndProductsDistribution)
            {
                foreach (DataRow row in PartsAndProductsDistribution.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["DistributedID"], 0, false)))
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@LocationID", row["LocationID"], true);
                        _database.AddParameter("@AllocatedID", row["AllocatedID"], true);
                        _database.AddParameter("@Other", row["Other"], true);
                        _database.AddParameter("@Quantity", row["Quantity"], true);
                        _database.AddParameter("@PartProductID", row["PartProductID"], true);
                        _database.AddParameter("@OrderPartProductID", row["OrderPartProductID"], true);
                        var switchExpr = Helper.MakeStringValid(row["Type"]);
                        switch (switchExpr)
                        {
                            case "Part":
                                {
                                    _database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert");
                                    break;
                                }

                            case "Product":
                                {
                                    _database.ExecuteSP_NO_Return("EngineerVisitProductDistributed_Insert");
                                    break;
                                }
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["StockTransactionType"], -1, false)))
                        {
                            // PART CREDIT
                            var CurrentPartsToBeCredited = new PartsToBeCrediteds.PartsToBeCredited();
                            CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                            var op = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(row["OrderPartProductID"]));
                            var ps = App.DB.PartSupplier.PartSupplier_Get(op.PartSupplierID);
                            CurrentPartsToBeCredited.SetOrderID = op.OrderID;
                            CurrentPartsToBeCredited.SetSupplierID = ps.SupplierID;
                            CurrentPartsToBeCredited.SetPartOrderID = row["OrderPartProductID"];
                            CurrentPartsToBeCredited.SetPartID = row["PartProductID"];
                            CurrentPartsToBeCredited.SetQty = row["Quantity"];
                            CurrentPartsToBeCredited.SetStatusID = Conversions.ToInteger(Enums.PartsToBeCreditedStatus.Awaiting_Part_Return);
                            CurrentPartsToBeCredited.SetManuallyAdded = false;
                            CurrentPartsToBeCredited.SetOrderReference = App.DB.Order.Order_Get(op.OrderID).OrderReference;
                            App.DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited);
                        }

                        if (Conversions.ToBoolean((int)row["LocationID"] > 0 & (int)row["StockTransactionType"] > 0))
                        {
                            var switchExpr1 = Helper.MakeStringValid(row["Type"]);
                            switch (switchExpr1)
                            {
                                case "Part":
                                    {
                                        var oPartTransaction = new PartTransactions.PartTransaction();
                                        oPartTransaction.SetLocationID = row["LocationID"];
                                        oPartTransaction.SetPartID = row["PartProductID"];
                                        oPartTransaction.SetOrderPartID = row["OrderPartProductID"];
                                        if (Conversions.ToInteger(row["StockTransactionType"]) == Conversions.ToInteger(Enums.Transaction.StockOut))
                                        {
                                            oPartTransaction.SetAmount = (int)row["Quantity"] * -1;
                                        }
                                        else
                                        {
                                            oPartTransaction.SetAmount = row["Quantity"];
                                        }

                                        oPartTransaction.SetTransactionTypeID = row["StockTransactionType"];
                                        App.DB.PartTransaction.Insert(oPartTransaction);
                                        break;
                                    }

                                case "Product":
                                    {
                                        var oProductTransaction = new ProductTransactions.ProductTransaction();
                                        oProductTransaction.SetLocationID = row["LocationID"];
                                        oProductTransaction.SetProductID = row["PartProductID"];
                                        oProductTransaction.SetOrderProductID = row["OrderPartProductID"];
                                        if (Conversions.ToInteger(row["StockTransactionType"]) == Conversions.ToInteger(Enums.Transaction.StockOut))
                                        {
                                            oProductTransaction.SetAmount = (int)row["Quantity"] * -1;
                                        }
                                        else
                                        {
                                            oProductTransaction.SetAmount = row["Quantity"];
                                        }

                                        oProductTransaction.SetTransactionTypeID = row["StockTransactionType"];
                                        App.DB.ProductTransaction.Insert(oProductTransaction);
                                        break;
                                    }
                            }
                        }
                    }
                }
            }

            public DataView EngineerVisitUnitsUsed_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitUnitsUsed_Get_For_EngineerVisitID");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitUnitsUsed_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitUnitsUsed_Delete");
            }

            public int EngineerVisitUnitsUsed_Insert(int EngineerVisitID, int JobItemID, double NumUnitsUsed)
            {
                _database.ClearParameter();
                AddEngineerVisitUnitsUsedParametersToCommand(EngineerVisitID, JobItemID, NumUnitsUsed);
                return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitUnitsUsed_Insert"));
            }

            private void AddEngineerVisitUnitsUsedParametersToCommand(int EngineerVisitID, int JobItemID, double NumUnitsUsed)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                    withBlock.AddParameter("@JobItemID", JobItemID, true);
                    withBlock.AddParameter("@NumUnitsUsed", NumUnitsUsed, true);
                }
            }

            public int EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID"));
            }

            public double EngineerCharge_VAT_Amount(int EngineerChargeID, DateTime VisitDate, double Amount)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerChargeID", EngineerChargeID, true);
                _database.AddParameter("@TypeID", Conversions.ToInteger(Enums.InvoiceType.Visit), true);
                _database.AddParameter("@VisitDate", VisitDate, true);
                _database.AddParameter("@Amount", Amount, true);
                return Conversions.ToDouble(_database.ExecuteSP_OBJECT("EngineerCharge_VAT_Amount"));
            }

            public DataTable EngineerVisitLiveCostReport()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_REPORT_Yesterday");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public void AlterEstimatedDate(int JobWorkID, DateTime EstDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobWorkID, true);
                _database.AddParameter("@Date", EstDate, true);
                _database.ExecuteSP_NO_Return("EngineerVisit_AlterEstimated");
            }

            public DataTable GetFutureVisits(int EngineerID, bool includeCurrentVisit)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerID, true);
                _database.AddParameter("@IncludeCurrentVisit", includeCurrentVisit, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_GetFutureVisits");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable Get_Appointments_Main(DateTime StartDate, int TimeReq, int days = 14, int TimeLimit = 240)
            {
                _database.ClearParameter();
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@timereq", TimeReq, true);
                _database.AddParameter("@Days", days, true);
                _database.AddParameter("@TimeLimit", TimeLimit, true);
                var dt = _database.ExecuteSP_DataTable("Get_Appointments_Main");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable Get_Appointments_Multi(string StartDate, int TimeReq, int days = 14, int TimeLimit = 240)
            {
                _database.ClearParameter();
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@timereq", TimeReq, true);
                _database.AddParameter("@Days", days, true);
                _database.AddParameter("@TimeLimit", TimeLimit, true);
                var dt = _database.ExecuteSP_DataTable("Get_Appointments_Multi_Appoint");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable Get_Appointments_ForEngineer(string StartDate, int TimeReq, int EngineerID, int days = 14, int TimeLimit = 240)
            {
                _database.ClearParameter();
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@timereq", TimeReq, true);
                _database.AddParameter("@Days", days, true);
                _database.AddParameter("@TimeLimit", TimeLimit, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                var dt = _database.ExecuteSP_DataTable("Get_Appointments_For_SingleEngineerID");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable Get_Appointments_Scheduler(string StartDate, int TimeReq)
            {
                _database.ClearParameter();
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@timereq", TimeReq, true);
                var dt = _database.ExecuteSP_DataTable("Get_Appointments_Schedulers");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable Find_The_Gap(string datein, int Engid, string Period)
            {
                _database.ClearParameter();
                _database.AddParameter("@datein", datein, true);
                _database.AddParameter("@EngineerID", Engid, true);
                _database.AddParameter("@Period", Period, true);
                var dt = _database.ExecuteSP_DataTable("Visits_Find_Gap");
                dt.TableName = Enums.TableNames.tblJobItem.ToString();
                return dt;
            }

            public DataTable GetLastVisit(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_GetLastVisit");
                return dt;
            }

            public DataTable GetSymptoms(int EngineervisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_GetSymptoms");
                return dt;
            }

            public void DeleteSymptoms(int EngineervisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                _database.ExecuteSP_DataTable("EngineerVisit_DeleteSymptoms_ForEngineerVisitID");
            }

            public DataView InsertSymptom(int EngineervisitID, int SymptomID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                _database.AddParameter("@SymptomID", SymptomID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_InsertSymptom");
                return new DataView(dt);
            }

            public DataTable GetExtendedProperties(int EngineervisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_GetExtendedProperties");
                return dt;
            }

            public DataTable InsertAdditionalText(int EngineervisitID, string AdditionalText)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                _database.AddParameter("@AdditionalText", AdditionalText, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_InsertAdditionalText");
                return dt;
            }

            public void DeleteExtendedProperties(int EngineervisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineervisitID, true);
                _database.ExecuteSP_DataTable("EngineerVisit_DeleteExtendedProperties_ForEngineerVisitID");
            }

            public bool MoveParts(int FromID, int ToID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OldEngineerVisitID", FromID, true);
                _database.AddParameter("@NewEngineerVisitID", ToID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_MoveVisit");
                return dt.Rows.Count > 0;
            }

            public EngineerVisit EngineerVisits_Get_LastForJob(int jobID, string jobNumber = "")
            {
                _database.ClearParameter();
                DataTable dt = null;
                if (!Helper.IsStringEmpty(jobNumber))
                {
                    _database.AddParameter("@JobNumber", jobNumber, true);
                    dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobNumber");
                }
                else
                {
                    _database.AddParameter("@JobID", jobID, true);
                    dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID");
                }

                if (dt.Rows.Count > 0)
                {
                    {
                        var withBlock = dt.Rows[0];
                        var visit = new EngineerVisit();
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.Exists = true;
                        visit.SetEngineerVisitID = withBlock["EngineerVisitID"];
                        visit.SetJobOfWorkID = withBlock["JobOfWorkID"];
                        visit.SetEngineerID = withBlock["EngineerID"];
                        visit.StartDateTime = Helper.MakeDateTimeValid(withBlock["StartDateTime"]);
                        visit.EndDateTime = Helper.MakeDateTimeValid(withBlock["EndDateTime"]);
                        visit.SetStatusEnumID = withBlock["StatusEnumID"];
                        visit.SetNotesToEngineer = withBlock["NotesToEngineer"];
                        visit.SetNotesFromEngineer = withBlock["NotesFromEngineer"];
                        visit.SetOutcomeEnumID = withBlock["OutcomeEnumID"];
                        visit.SetOutcomeDetails = withBlock["OutcomeDetails"];
                        visit.SetCustomerName = withBlock["CustomerName"];
                        visit.SetVisitOutcome = withBlock["VisitOutcome"];
                        visit.SetManualEntryByUserID = withBlock["ManualEntryByUserID"];
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(withBlock["ManualEntryOn"]);
                        visit.SetVisitLocked = Conversions.ToBoolean(withBlock["VisitLocked"]);
                        visit.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        visit.SetGasInstallationTightnessTestID = withBlock["GasInstallationTightnessTestID"];
                        visit.SetEmergencyControlAccessibleID = withBlock["EmergencyControlAccessibleID"];
                        visit.SetBondingID = withBlock["BondingID"];
                        visit.SetExpectedEngineerID = withBlock["ExpectedEngineerID"];
                        visit.SetPropertyRented = withBlock["PropertyRented"];
                        visit.SetPaymentMethodID = withBlock["PaymentMethodID"];
                        visit.SetAmountCollected = withBlock["AmountCollected"];
                        visit.SetAMPM = withBlock["AMPM"];
                        visit.SetVisitNumber = withBlock["VisitNumber"];
                        visit.SetVisitStatus = withBlock["VisitStatus"];
                        visit.SetRecharge = Helper.MakeBooleanValid(withBlock["Recharge"]);
                        if (withBlock.Table.Columns.Contains("FuelID"))
                            visit.SetFuelID = withBlock["FuelID"];
                        return visit;
                    }
                }
                else
                {
                    return null;
                }
            }

            public int EngineerVisit_GetActionID(int EVID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EVID, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("EngineerVisit_GetActionID"));
            }

            public DataView Get_SiteHistory(int siteId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", siteId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_Get_SiteHistory");
                return new DataView(dt);
            }

            public DataView Get_ByEngineerIdAndStatusEnumId(int engineerId, int statusEnumId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerId, true);
                _database.AddParameter("@StatusEnumID", statusEnumId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_Get_ByEngineerIdAndStatusEnumId");
                return new DataView(dt);
            }

            

            public List<EngineerVisit> Get_ByJobId(int jobId)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisit_Get_ByJobId");
                if (dt is object && dt.Rows.Count > 0)
                {
                    var engineerVisits = (from x in dt.AsEnumerable()
                                          select new EngineerVisit()
                                          {
                                              Exists = true,
                                              SetEngineerVisitID = Helper.MakeIntegerValid(x["EngineerVisitId"]),
                                              SetJobOfWorkID = Helper.MakeIntegerValid(x["JobOfWorkId"]),
                                              SetEngineerID = Helper.MakeIntegerValid(x["EngineerId"]),
                                              StartDateTime = Helper.MakeDateTimeValid(x["StartDateTime"]),
                                              EndDateTime = Helper.MakeDateTimeValid(x["EndDateTime"]),
                                              SetStatusEnumID = Helper.MakeIntegerValid(x["StatusEnumId"]),
                                              SetNotesToEngineer = Helper.MakeStringValid(x["NotesToEngineer"]),
                                              SetNotesFromEngineer = Helper.MakeStringValid(x["NotesFromEngineer"]),
                                              SetOutcomeEnumID = Helper.MakeIntegerValid(x["OutcomeEnumId"]),
                                              SetOutcomeDetails = Helper.MakeStringValid(x["OutcomeDetails"]),
                                              SetCustomerName = Helper.MakeStringValid(x["CustomerName"]),
                                              SetManualEntryByUserID = Helper.MakeIntegerValid(x["ManualEntryByUserId"]),
                                              ManualEntryOn = Helper.MakeDateTimeValid(x["ManualEntryOn"]),
                                              SetVisitLocked = Helper.MakeBooleanValid(x["VisitLocked"]),
                                              SetDeleted = Helper.MakeBooleanValid(x["Deleted"]),
                                              SetPaymentMethodID = Helper.MakeIntegerValid(x["PaymentMethodId"]),
                                              SetAmountCollected = Helper.MakeDoubleValid(x["AmountCollected"]),
                                              SetGasInstallationTightnessTestID = Helper.MakeIntegerValid(x["GasInstallationTightnessTestId"]),
                                              SetEmergencyControlAccessibleID = Helper.MakeIntegerValid(x["EmergencyControlAccessibleId"]),
                                              SetBondingID = Helper.MakeIntegerValid(x["BondingId"]),
                                              SetPropertyRented = Helper.MakeIntegerValid(x["PropertyRented"]),
                                              SetSignatureSelectedID = Helper.MakeIntegerValid(x["SignatureSelectedId"]),
                                              SetPartsToFit = Helper.MakeBooleanValid(x["PartsToFit"]),
                                              SetGasServiceCompleted = Helper.MakeBooleanValid(x["GasServiceCompleted"]),
                                              SetEmailReceipt = Helper.MakeBooleanValid(x["EmailReceipt"]),
                                              Downloading = Helper.MakeDateTimeValid(x["Downloading"]),
                                              SetExpectedEngineerID = Helper.MakeIntegerValid(x["ExpectedEngineerId"]),
                                              SetAMPM = Helper.MakeStringValid(x["AMPM"]),
                                              SetVisitNumber = Helper.MakeIntegerValid(x["VisitNumber"]),
                                              SetRecharge = Helper.MakeBooleanValid(x["Recharge"]),
                                              SetCostsTo = Helper.MakeStringValid(x["CostsTo"]),
                                              setNccRadID = Helper.MakeIntegerValid(x["NccRadId"]),
                                              SetMeterCappedID = Helper.MakeIntegerValid(x["MeterCappedId"]),
                                              SetUseSORDescription = Helper.MakeBooleanValid(x["UseSORdescription"]),
                                              SetAppointmentID = Helper.MakeIntegerValid(x["AppointmentId"]),
                                              SetMeterLocationID = Helper.MakeIntegerValid(x["MeterLocationId"]),
                                              SetExpectedDepartment = Helper.MakeStringValid(x["ExpectedDepartment"]),
                                              SetFuelID = Helper.MakeIntegerValid(x["FuelId"]),
                                              SetExcludeFromTextMessage = Helper.MakeIntegerValid(x["ExcludeFromTextMessage"])
                                          }).ToList();
                    return engineerVisits;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}