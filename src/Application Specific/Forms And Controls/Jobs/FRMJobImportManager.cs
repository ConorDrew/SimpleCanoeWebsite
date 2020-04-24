using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMJobImportManager : FRMBaseForm, IForm
    {
        public FRMJobImportManager()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboLetterNumber;
            Combo.SetUpCombo(ref argc, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            cboLetterNumber.Items.RemoveAt(0);
            cboLetterNumber.Items.RemoveAt(2); // Remove letter 3
            var argcombo = cboLetterNumber;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
            var argc1 = cboJobType;
            Combo.SetUpCombo(ref argc1, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
            SetupJobDataGrid();
            WindowState = FormWindowState.Maximized;
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvJobs;
        private int jobsPerWeek = 0;

        private DataView JobsDataView
        {
            get
            {
                return _dvJobs;
            }

            set
            {
                _dvJobs = value;
                _dvJobs.Table.TableName = Enums.TableNames.tblJob.ToString();
                dgJobs.DataSource = JobsDataView;
            }
        }

        private DataRow SelectedJobDataRow
        {
            get
            {
                if (!(dgJobs.CurrentRowIndex == -1))
                {
                    return JobsDataView[dgJobs.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public class MaxAmPmAmounts
        {
            public int amAmount;
            public int pmAmount;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupJobDataGrid()
        {
            var tbStyle = dgJobs.TableStyles[0];
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 150;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 150;
            Address1.NullText = "";
            tbStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 120;
            Address2.NullText = "";
            tbStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 120;
            Address3.NullText = "";
            tbStyle.GridColumnStyles.Add(Address3);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 85;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var TelNo = new DataGridLabelColumn();
            TelNo.Format = "";
            TelNo.FormatInfo = null;
            TelNo.HeaderText = "Tel No.";
            TelNo.MappingName = "TelNo";
            TelNo.ReadOnly = true;
            TelNo.Width = 175;
            TelNo.NullText = "";
            tbStyle.GridColumnStyles.Add(TelNo);
            var uprn = new DataGridLabelColumn();
            uprn.Format = "";
            uprn.FormatInfo = null;
            uprn.HeaderText = "UPRN";
            uprn.MappingName = "UPRN";
            uprn.ReadOnly = true;
            uprn.Width = 100;
            uprn.NullText = "";
            tbStyle.GridColumnStyles.Add(uprn);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "Type";
            type.ReadOnly = true;
            type.Width = 75;
            type.NullText = "";
            tbStyle.GridColumnStyles.Add(type);
            var letter1 = new DataGridLabelColumn();
            letter1.Format = "dd/MM/yyyy";
            letter1.FormatInfo = null;
            letter1.HeaderText = "Letter 1 Date";
            letter1.MappingName = "Letter1";
            letter1.ReadOnly = true;
            letter1.Width = 110;
            letter1.NullText = "";
            tbStyle.GridColumnStyles.Add(letter1);
            var letter2 = new DataGridLabelColumn();
            letter2.Format = "dd/MM/yyyy";
            letter2.FormatInfo = null;
            letter2.HeaderText = "Letter 2 Date";
            letter2.MappingName = "Letter2";
            letter2.ReadOnly = true;
            letter2.Width = 110;
            letter2.NullText = "";
            tbStyle.GridColumnStyles.Add(letter2);
            var NextVisitDate = new DataGridLabelColumn();
            NextVisitDate.Format = "dddd dd/MM/yyyy"; // Actually done in column
            NextVisitDate.FormatInfo = null;
            NextVisitDate.HeaderText = "Suggested Visit Date";
            NextVisitDate.MappingName = "NextVisitDate";
            NextVisitDate.ReadOnly = true;
            NextVisitDate.Width = 130;
            NextVisitDate.NullText = "";
            tbStyle.GridColumnStyles.Add(NextVisitDate);
            var AMPM = new DataGridLabelColumn();
            AMPM.Format = "";
            AMPM.FormatInfo = null;
            AMPM.HeaderText = "AM/PM";
            AMPM.MappingName = "AMPM";
            AMPM.ReadOnly = true;
            AMPM.Width = 50;
            AMPM.NullText = "";
            tbStyle.GridColumnStyles.Add(AMPM);
            var EngName = new DataGridLabelColumn();
            EngName.Format = "";
            EngName.FormatInfo = null;
            EngName.HeaderText = "Engineer";
            EngName.MappingName = "EngName";
            EngName.ReadOnly = true;
            EngName.Width = 180;
            EngName.NullText = "";
            tbStyle.GridColumnStyles.Add(EngName);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblJob.ToString();
            dgJobs.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMJobManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)
            {
                App.ShowMessage("No job type selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var theDate = dtpLetterCreateDate.Value;
            bool bankHoliday = false;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 1; i <= 13; i++)
            {
                theDate = theDate.AddDays(1);
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(theDate, "dd/MM/yyyy")) + "'").Length > 0)
                {
                    bankHoliday = true;
                }
                else if (theDate.DayOfWeek != DayOfWeek.Saturday & theDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    break;
                }
            }

            if (bankHoliday)
            {
                if (App.ShowMessage("Bank Holdiays are due soon, would you like to amended the filter dates before proceeding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return;
                }
            }

            PopulateDatagrid();
            GetAppointments();
            btnGenerateLetters.Enabled = true;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (JobsDataView is object && JobsDataView.Count > 0)
            {
                foreach (DataRow dr in JobsDataView.Table.Select(JobsDataView.RowFilter))
                    dr["Tick"] = true;
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            if (JobsDataView is object && JobsDataView.Count > 0)
            {
                foreach (DataRow dr in JobsDataView.Table.Select(JobsDataView.RowFilter))
                    dr["Tick"] = false;
            }
        }

        private void btnGenerateLetters_Click(object sender, EventArgs e)
        {
            GetAppointments(true);
            PopulateDatagrid();
            GetAppointments();
        }

        private void dgJobs_Click(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                return;
            }

            bool selected = !Conversions.ToBoolean(dgJobs[dgJobs.CurrentRowIndex, 0]);
            dgJobs[dgJobs.CurrentRowIndex, 0] = selected;
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            if (!(ID == 0))
            {
                var oSite = App.DB.Sites.Get(ID);
                if (oSite is object && oSite.Exists)
                {
                    grpJobs.Text = "Sites";
                    JobsDataView = App.DB.JobImports.JobImport_Get_BySiteID(oSite.SiteID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType)));
                    if (JobsDataView.Count > 0)
                    {
                        dgJobs.ContextMenuStrip = cmsAction;
                    }
                    else
                    {
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)
                        {
                            App.ShowMessage("If you want to add site to the process." + Constants.vbCrLf + "Please select a work stream for site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (App.ShowMessage("Add site to " + Combo.get_GetSelectedItemDescription(cboJobType) + " process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var jobImport = new Entity.JobImport.JobImport();
                            {
                                var withBlock = jobImport;
                                withBlock.SetSiteID = oSite.SiteID;
                                withBlock.SetUPRN = oSite.PolicyNumber;
                                withBlock.SetJobImportTypeID = Combo.get_GetSelectedItemValue(cboJobType);
                                withBlock.DateAdded = DateAndTime.Now;
                            }

                            jobImport = App.DB.JobImports.JobImport_Insert(jobImport);
                            if (jobImport.Exists)
                            {
                                if (App.ShowMessage("Create job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    JobsDataView = App.DB.JobImports.JobImport_Get_BySiteID(oSite.SiteID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType)));
                                    dgJobs.ContextMenuStrip = cmsAction;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void tsmiDeleteSite_Click(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                App.ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!Information.IsDBNull(SelectedJobDataRow["JobImportID"]))
                {
                    if (!Information.IsDBNull(SelectedJobDataRow["JobID"]))
                    {
                        if (App.ShowMessage("There is a job against this site!" + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            throw new Exception("Operation cancelled by user!");
                        }
                    }

                    int jobImportId = Helper.MakeIntegerValid(SelectedJobDataRow["JobImportID"]);
                    int jobImportTypeId = Helper.MakeIntegerValid(SelectedJobDataRow["JobImportTypeID"]);
                    App.DB.JobImports.JobImport_Delete_WithJobType(jobImportId, jobImportTypeId);
                    App.ShowMessage("Site has been removed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                grpJobs.Text = "Jobs";
                JobsDataView = new DataView(new DataTable());
                dgJobs.ContextMenuStrip = null;
            }
        }

        private void tsmiCreateJob_Click(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                App.ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var job = new Entity.Jobs.Job();
                job = App.DB.Job.CreateJobImportAdHocVisit(SelectedJobDataRow, false);
                if (job is null)
                    throw new Exception("Failed to generate job");
                int jobImportId = Helper.MakeIntegerValid(SelectedJobDataRow["JobImportID"]);
                App.DB.JobImports.JobImport_Update_Job(jobImportId, job);
                App.ShowMessage("Job Created" + Constants.vbCrLf + Constants.vbCrLf + "Job Number: " + job.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                grpJobs.Text = "Jobs";
                JobsDataView = new DataView(new DataTable());
                dgJobs.ContextMenuStrip = null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateDatagrid()
        {
            try
            {
                if (Helper.MakeIntegerValid(txtJobsPerDay.Text) == 0)
                {
                    App.ShowMessage("Cannot have 0 jobs a day!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int jobsPerDay = Helper.MakeIntegerValid(txtJobsPerDay.Text);
                int jobimportTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType));
                var twoWeeks = dtpLetterCreateDate.Value.AddDays(14);
                int workingDaysInWeek = DateHelper.GetWorkingDays(DateHelper.GetTheMonday(twoWeeks), DateHelper.GetTheFriday(twoWeeks));
                bool letter1 = Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboLetterNumber)) == 1;
                DataTable jobsDt = null;
                if (chkSortPostcode.Checked)
                {
                    jobsDt = letter1 ? App.DB.JobImports.JobImport_Get_L1Jobs(jobimportTypeId).Table : App.DB.JobImports.JobImport_Get_L2Jobs(jobimportTypeId).Table;
                }
                else
                {
                    jobsDt = letter1 ? App.DB.JobImports.JobImport_Get_L1Jobs_NoOrder(jobimportTypeId).Table : App.DB.JobImports.JobImport_Get_L2Jobs(jobimportTypeId).Table;
                }

                jobsDt.Columns.Add("NextVisitDate");
                jobsDt.Columns.Add("LetterDate");
                var dates = DateHelper.GetWorkingDates(DateHelper.GetTheMonday(twoWeeks), DateHelper.GetTheFriday(twoWeeks));
                int amntJobsNeeded = dates.Count * jobsPerDay;
                if (jobsDt?.Rows.Count > 0 == true)
                {
                    foreach (DataRow row in jobsDt?.Rows)
                    {
                        if (row["NextVisitDate"] is null | Information.IsDBNull(row["NextVisitDate"]))
                        {
                            row["NextVisitDate"] = dates.FirstOrDefault();
                        }
                    }
                }

                JobsDataView = new DataView(jobsDt);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            var argcombo = cboLetterNumber;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            txtJobsPerDay.Text = 6.ToString();
            dtpLetterCreateDate.Value = DateAndTime.Now;
        }

        private bool GetAppointments(bool doJobs = false)
        {
            Cursor = Cursors.WaitCursor;
            var startProcess = DateAndTime.Now;
            var selectedJobView = new DataView();
            if (JobsDataView is object && JobsDataView.Count > 0)
            {
                selectedJobView.Table = SelectedJobDataRow.Table;
                if (!selectedJobView.Table.Columns.Contains("EngName"))
                    selectedJobView.Table.Columns.Add("EngName");
                if (!selectedJobView.Table.Columns.Contains("EngineerID"))
                    selectedJobView.Table.Columns.Add("EngineerID");
                if (!selectedJobView.Table.Columns.Contains("AMPM"))
                    selectedJobView.Table.Columns.Add("AMPM");
                if (!selectedJobView.Table.Columns.Contains("ETA"))
                    selectedJobView.Table.Columns.Add("ETA"); // boolean for when visit has been applied
                if (doJobs)
                {
                    selectedJobView.RowFilter = "Tick = 1";
                }

                if (selectedJobView.Count == 0)
                {
                    App.ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return default;
                }

                selectedJobView.Sort = "Postcode";
                var twoWeeks = dtpLetterCreateDate.Value.AddDays(14);
                var startDate = DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetDateZeroTime(DateHelper.GetTheMonday(twoWeeks)));
                var endDate = DateHelper.CheckBankHolidaySatOrSun(DateHelper.GetDateZeroTime(DateHelper.GetTheFriday(twoWeeks))).AddDays(1);
                int jobImportTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType));
                var jobImportType = App.DB.JobImports.JobImportType_Get(jobImportTypeId);
                int jobsPerDay = Helper.MakeIntegerValid(txtJobsPerDay.Text);
                var dvAppointments = App.DB.JobImports.JobImport_Get_EngineerJobs(startDate, endDate, jobImportTypeId);
                int visitTime = 60;
                var dvSOR = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID);
                visitTime = Conversions.ToInteger(dvSOR.Table.Rows[0]["TimeInMins"]);
                var dvEngineerPostcodes = App.DB.EngineerPostalRegion.GetALLTicked();
                try // Added a try to stop it breaking the app when an error occours
                {
                    int c = -1;
                    do
                    {
                        c = c + 1;
                        var job = selectedJobView[c];
                        if (Information.IsDBNull(job["Letter1"])) // letter 1
                        {
                            dvAppointments.RowFilter = "TheDate <= #" + DateHelper.GetTheFriday(Conversions.ToDate(job["NextVisitDate"])).ToString("yyyy-MM-dd") + "# AND TheDate >= #" + DateHelper.GetTheMonday(Conversions.ToDate(job["NextVisitDate"])).ToString("yyyy-MM-dd") + "#";
                        }
                        else if (Information.IsDBNull(job["Letter2"])) // letter2
                        {
                            dvAppointments.RowFilter = "TheDate <= #" + DateHelper.GetTheFriday(Conversions.ToDate(job["NextVisitDate"])).ToString("yyyy-MM-dd") + "# AND TheDate >= #" + Conversions.ToDate(job["NextVisitDate"]).ToString("yyyy-MM-dd") + "#";
                        }
                        else
                        {
                        } // we should generate a report for it

                        foreach (DataRowView appointment in dvAppointments)
                        {
                            int countOfAssignedJobs = (from row in selectedJobView.Table.AsEnumerable()
                                                       where Operators.ConditionalCompareObjectEqual(row["NextVisitDate"], Conversions.ToDate(appointment["TheDate"]).ToString("dd/MM/yyyy"), false) & Helper.MakeBooleanValid(row["ETA"]) == true & Helper.MakeIntegerValid(row["EngineerID"]) == Helper.MakeIntegerValid(appointment["EngineerID"])
                                                       select row).ToArray().Count();
                            if (countOfAssignedJobs == jobsPerDay)
                            {
                                continue;
                            }

                            var maxAmPmAmounts = GetMaxAmPmAmount(Helper.MakeIntegerValid(appointment["MaxSOR"]), visitTime);
                            if (Helper.MakeIntegerValid(appointment["AM"]) < maxAmPmAmounts.amAmount & (Information.IsDBNull(job["BookedVisit"]) | !Information.IsDBNull(job["Letter1"])) & Convert.ToDouble(appointment["RemainingSOR"]) > 0 & Information.IsDBNull(job["ETA"]) & dvEngineerPostcodes.Table.Select(Conversions.ToString(Conversions.ToString("EngineerID = " + appointment["EngineerID"] + " And Name = '") + job["OutwardCode"] + "'")).Length > 0)
                            {
                                job["EngName"] = appointment["Name"];
                                job["EngineerID"] = appointment["EngineerID"];
                                job["NextVisitDate"] = Conversions.ToDate(appointment["TheDate"]).ToString("dd/MM/yyyy");
                                job["AMPM"] = "AM";
                                appointment["AM"] = Helper.MakeIntegerValid(appointment["AM"]) + 1;
                                job["LetterDate"] = dtpLetterCreateDate.Value;
                                job["ETA"] = true;
                                appointment["RemainingSOR"] = Convert.ToInt32(appointment["RemainingSOR"]) - visitTime;
                                continue;
                            }

                            if (Helper.MakeIntegerValid(appointment["PM"]) < maxAmPmAmounts.pmAmount & (Information.IsDBNull(job["BookedVisit"]) | !Information.IsDBNull(job["Letter1"])) & Convert.ToDouble(appointment["RemainingSOR"]) > 0 & Information.IsDBNull(job["ETA"]) & dvEngineerPostcodes.Table.Select(Conversions.ToString(Conversions.ToString("EngineerID = " + appointment["EngineerID"] + " And Name = '") + job["OutwardCode"] + "'")).Length > 0)
                            {
                                job["EngName"] = appointment["Name"];
                                job["EngineerID"] = appointment["EngineerID"];
                                job["NextVisitDate"] = Conversions.ToDate(appointment["TheDate"]).ToString("dd/MM/yyyy");
                                job["AMPM"] = "PM";
                                appointment["PM"] = Helper.MakeIntegerValid(appointment["PM"]) + 1;
                                job["LetterDate"] = dtpLetterCreateDate.Value;
                                job["ETA"] = true;
                                appointment["RemainingSOR"] = Convert.ToInt32(appointment["RemainingSOR"]) - visitTime;
                            } // end of main if
                        }
                    }
                    while (c < selectedJobView.Count - 1);
                    if (chkScheduleJobs.Checked)
                        JobsDataView.RowFilter = "AMPM Is Not Null";
                    JobsDataView.Sort = "NextVisitDate ASC, AMPM ASC";
                }
                catch (Exception ex) // show the user
                {
                    App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (doJobs == true)
                    {
                        selectedJobView.RowFilter = "Tick = 1";
                        var details = new ArrayList();
                        details.Add(selectedJobView);
                        details.Add(chkScheduleJobs.Checked);
                        string letterName = Combo.get_GetSelectedItemDescription(cboJobType);
                        var oPrint = new Printing(details, letterName, Enums.SystemDocumentType.JobImportLetters, true);
                        var endProcess = DateAndTime.Now;
                        Interaction.MsgBox("Start: " + startProcess + Constants.vbCrLf + "End: " + endProcess);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

            Cursor = Cursors.Default;
            return true;
        }

        public MaxAmPmAmounts GetMaxAmPmAmount(int maxSor, int visitMins)
        {
            var maxValues = new MaxAmPmAmounts();
            int amountOfJobs = (int)(maxSor / (double)visitMins);
            int maxAm = Conversions.ToInteger(Math.Round(amountOfJobs / (double)2, 0, MidpointRounding.AwayFromZero));
            int maxPm = Conversions.ToInteger(Math.Floor(amountOfJobs / (double)2));
            maxValues.amAmount = maxAm;
            maxValues.pmAmount = maxPm;
            return maxValues;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}