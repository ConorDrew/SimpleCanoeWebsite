using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMLetterManagerMK3 : FRMBaseForm, IForm
    {
        public FRMLetterManagerMK3()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboLetterNumber;
            Combo.SetUpCombo(ref argc, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            cboLetterNumber.Items.RemoveAt(0);
            ResetFilters();
            SetupLettersDataGrid();
            WindowState = FormWindowState.Maximized;
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        
        
        private DataTable Avail = new DataTable();
        private DataView AvailView = new DataView();
        private int amtServ = 0; // how many services we need?
        private bool profile = false;
        private bool siteOnly = false;
        private List<string> Postcodes = new List<string>(); // postcode list
        private DataView _dvServiceDue;

        private DataView ServiceDueDataview
        {
            get
            {
                return _dvServiceDue;
            }

            set
            {
                _dvServiceDue = value;
                _dvServiceDue.AllowNew = false;
                _dvServiceDue.AllowEdit = false;
                _dvServiceDue.AllowDelete = false;
                _dvServiceDue.Table.TableName = "ServiceDue";
                dgServicesDue.DataSource = ServiceDueDataview;
            }
        }

        private DataRow SelectedServiceDueDataRow
        {
            get
            {
                if (!(dgServicesDue.CurrentRowIndex == -1))
                {
                    return ServiceDueDataview[dgServicesDue.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        public Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                if (_theCustomer is object)
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + theCustomer.AccountNumber + ")";
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        
        

        private void SetupLettersDataGrid()
        {
            var tbStyle = dgServicesDue.TableStyles[0];
            var SendLetterTick = new DataGridBoolColumn();
            SendLetterTick.HeaderText = "Send Letter";
            SendLetterTick.MappingName = "SendLetterTick";
            SendLetterTick.ReadOnly = true;
            SendLetterTick.Width = 75;
            SendLetterTick.NullText = "";
            tbStyle.GridColumnStyles.Add(SendLetterTick);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 60;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var SiteFuel = new DataGridDistrictColumn();
            SiteFuel.Format = "";
            SiteFuel.FormatInfo = null;
            SiteFuel.HeaderText = "Fuel Type";
            SiteFuel.MappingName = "SiteFuel";
            SiteFuel.ReadOnly = true;
            SiteFuel.Width = 80;
            SiteFuel.NullText = "";
            tbStyle.GridColumnStyles.Add(SiteFuel);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 250;
            Address1.NullText = "";
            tbStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 140;
            Address2.NullText = "";
            tbStyle.GridColumnStyles.Add(Address2);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 80;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var @void = new DataGridVoidColumn();
            @void.Format = "";
            @void.FormatInfo = null;
            @void.HeaderText = "Void";
            @void.MappingName = "PropertyVoid";
            @void.ReadOnly = true;
            @void.Width = 80;
            @void.NullText = "";
            tbStyle.GridColumnStyles.Add(@void);
            var LastServiceDate = new DataGridLabelColumn();
            LastServiceDate.Format = "dd/MM/yyyy";
            LastServiceDate.FormatInfo = null;
            LastServiceDate.HeaderText = "Last Service Date";
            LastServiceDate.MappingName = "LastServiceDate";
            LastServiceDate.ReadOnly = true;
            LastServiceDate.Width = 110;
            LastServiceDate.NullText = "";
            tbStyle.GridColumnStyles.Add(LastServiceDate);
            var NextVisitDate = new DueDateColourColumn();
            NextVisitDate.Format = "dd/MM/yyyy"; // Actually done in column
            NextVisitDate.FormatInfo = null;
            NextVisitDate.HeaderText = "Suggested Visit Date";
            NextVisitDate.MappingName = "NextVisitDate";
            NextVisitDate.ReadOnly = true;
            NextVisitDate.Width = 160;
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
            var NextVisit = new DataGridLabelColumn();
            NextVisit.Format = "dd/MM/yyyy";
            NextVisit.FormatInfo = null;
            NextVisit.HeaderText = "Next Visit";
            NextVisit.MappingName = "NextVisit";
            NextVisit.ReadOnly = true;
            NextVisit.Width = 100;
            NextVisit.NullText = "";
            tbStyle.GridColumnStyles.Add(NextVisit);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "ServiceDue";
            dgServicesDue.TableStyles.Add(tbStyle);
        }

        
        

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(App.FindRecord(Enums.TableNames.tblCustomer));
            if (customerID > 0)
            {
                theCustomer = App.DB.Customer.Customer_Get(customerID);
            }

            btnGenerateLetters.Enabled = false;
        }

        private void FRMLetterManagerMK3_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var theDate = dtpLetterCreateDate.Value;
            bool bankHoliday = false;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 1; i <= 4; i++)
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
            if (chkLettersOnly.Checked == false)
            {
                GetAppointments();
            }

            btnGenerateLetters.Enabled = true;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (ServiceDueDataview is object && ServiceDueDataview.Count > 0)
            {
                ServiceDueDataview.AllowEdit = true;
                foreach (DataRowView r in ServiceDueDataview)
                    r["SendLetterTick"] = true;
                ServiceDueDataview.AllowEdit = false;
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            if (ServiceDueDataview is object && ServiceDueDataview.Count > 0)
            {
                ServiceDueDataview.AllowEdit = true;
                foreach (DataRow r in ServiceDueDataview.Table.Rows)
                    r["SendLetterTick"] = false;
                ServiceDueDataview.AllowEdit = false;
            }
        }

        private void btnGenerateLetters_Click(object sender, EventArgs e)
        {
            if (chkLettersOnly.Checked == false)
            {
                GetAppointments(true);
                if (siteOnly == true)
                {
                    grpServices.Text = "Services Due";
                    ServiceDueDataview = new DataView(new DataTable());
                    siteOnly = false;
                    return;
                }

                PopulateDatagrid();
                GetAppointments();
            }
            else
            {
                var SelectedServiceDueView = new DataView();
                SelectedServiceDueView.Table = ServiceDueDataview.Table;
                SelectedServiceDueView.RowFilter = "SendLetterTick = 1";
                var details = new ArrayList();
                details.Add(SelectedServiceDueView);
                var oPrint = new Printing(details, "NCC Service Letters MK3", Enums.SystemDocumentType.ServiceLettersMK2, true, 0, false, Convert.ToInt32(tbMinsPerDay.Text), theCustomer.CustomerID, Conversions.ToDate(dtpLetterCreateDate.Text));
            }
        }

        private void chkLettersOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (ServiceDueDataview is object && ServiceDueDataview.Count > 0)
            {
                ServiceDueDataview.Table.Clear();
            }
        }

        private void btnReleaseLockedSites_Click(object sender, EventArgs e)
        {
            foreach (DataRowView dr in ServiceDueDataview)
                App.DB.LetterManager.ClearStuckSite(Conversions.ToDate(dr["LastServiceDate"]), Convert.ToInt32(dr["SiteID"]), Conversions.ToString(dr["Type"]));
        }

        private void dgServicesDue_MouseClick(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgServicesDue.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    if (SelectedServiceDueDataRow is null)
                    {
                        return;
                    }

                    bool selected = !Conversions.ToBoolean(dgServicesDue[dgServicesDue.CurrentRowIndex, 0]);
                    dgServicesDue[dgServicesDue.CurrentRowIndex, 0] = selected;
                    if (!SelectedServiceDueDataRow.Table.Columns.Contains("MultipleFuelSite"))
                    {
                        return;
                    }

                    if (Helper.MakeBooleanValid(SelectedServiceDueDataRow["MultipleFuelSite"]))
                    {
                        var mf = ServiceDueDataview.Table.Select("SiteID = " + Helper.MakeIntegerValid(SelectedServiceDueDataRow["SiteID"]) + "AND MultipleFuelSite = True");
                        foreach (DataRow f in mf)
                            f["SendLetterTick"] = SelectedServiceDueDataRow["SendLetterTick"];
                    }
                }
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(App.FindRecord(Enums.TableNames.tblSite));
            if (!(ID == 0))
            {
                var oSite = App.DB.Sites.Get(ID);
                if (oSite is object && oSite.Exists)
                {
                    ServiceDueDataview = App.DB.LetterManager.LetterManagerAddSiteMK3(dtpLetterCreateDate.Value, oSite.SiteID);
                    if (ServiceDueDataview.Count > 0)
                    {
                        CalcAvail();
                        grpServices.Text = "Site";
                        GetAppointments();
                        siteOnly = true;
                        btnGenerateLetters.Enabled = true;
                    }
                    else
                    {
                        App.ShowMessage("Site could not be added to process, please check site or contact IT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        

        public void CalcAvail()
        {
            profile = false;
            bool fake = false;
            if (Avail.Columns.Count == 0)
            {
                Avail.Columns.Add("Day");
                Avail.Columns.Add("Avail");
                Avail.Columns["Avail"].DataType = Type.GetType("System.Int32");
                Avail.TableName = "apps";
            }

            Avail.Clear();
            AvailView.Table = Avail;
            if (theCustomer.WinterServ > 0 & theCustomer.SummerServ > 0)
            {
                var friday2weeks = DateHelper.GetTheFriday(dtpLetterCreateDate.Value.AddDays(14));
                for (int i = -4; i <= 0; i += 1)
                {
                    int workingDaysInMonth = DateHelper.GetWorkingDays(DateHelper.GetFirstDayOfMonth(friday2weeks.AddDays(i)), DateHelper.GetLastDayOfMonth(friday2weeks.AddDays(i)));
                    var nr = AvailView.Table.NewRow();
                    if (DateHelper.GetWorkingDays(friday2weeks.AddDays(i), friday2weeks.AddDays(i)) > 0)
                    {
                        var AlreadyBookedDT = App.DB.LetterManager.GetBucketsL1(friday2weeks.AddDays(i), theCustomer.CustomerID).Table;
                        int Alreadybooked = 0;
                        if (AlreadyBookedDT.Rows.Count > 0)
                        {
                            Alreadybooked = Convert.ToInt32(AlreadyBookedDT.Rows[0]["ServicesBooked"]);
                        }

                        if (DateAndTime.Month(friday2weeks.AddDays(i)) < 4 | DateAndTime.Month(friday2weeks.AddDays(i)) > 9) // winter
                        {
                            nr["Day"] = i + 5;
                            nr["Avail"] = Convert.ToInt32(Conversion.Int(theCustomer.WinterServ / (decimal)workingDaysInMonth - Alreadybooked));
                            AvailView.Table.Rows.Add(nr);
                        }
                        else
                        {
                            nr["Day"] = i + 5;
                            nr["Avail"] = Convert.ToInt32(Conversion.Int(theCustomer.SummerServ / (decimal)workingDaysInMonth - Alreadybooked));
                            AvailView.Table.Rows.Add(nr);
                        }
                    }
                    else
                    {
                        nr["Day"] = i + 5;
                        nr["Avail"] = 0;
                        AvailView.Table.Rows.Add(nr);
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 4; i += 1)
                {
                    var nr = AvailView.Table.NewRow();
                    nr["Day"] = i + 1;
                    nr["Avail"] = 0;
                    AvailView.Table.Rows.Add(nr);
                }

                fake = true;
            }

            foreach (DataRow dr in AvailView.Table.Rows)
                amtServ = Convert.ToInt32(amtServ + (int)dr["Avail"]);
            if (AvailView.Count > 0 & fake == false)
                profile = true;
        }

        public void PopulateDatagrid()
        {
            try
            {
                if (chkLettersOnly.Checked == false)
                {
                    CalcAvail();
                    var switchExpr = Combo.get_GetSelectedItemValue(cboLetterNumber);
                    switch (switchExpr)
                    {
                        case "1":
                            {
                                ServiceDueDataview = App.DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID);
                                if (ServiceDueDataview.Count > 0 & amtServ > 0)
                                    amtServ -= ServiceDueDataview.Count;
                                if (amtServ < 0)
                                    amtServ = 0;
                                ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID, profile, amtServ).Table);
                                break;
                            }

                        case "2":
                            {
                                ServiceDueDataview = App.DB.LetterManager.Get_Letter2Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID);
                                break;
                            }

                        case "3":
                            {
                                var switchExpr1 = theCustomer.CustomerID;
                                switch (switchExpr1)
                                {
                                    case (int)Enums.Customer.NCC:
                                    case (int)Enums.Customer.WDC:
                                    case (int)Enums.Customer.Kier:
                                    case (int)Enums.Customer.CotmanHousing:
                                    case (int)Enums.Customer.Tendring:
                                    case (int)Enums.Customer.Saffron:
                                        {
                                            ServiceDueDataview = App.DB.LetterManager.Get_Letter3Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID);
                                            break;
                                        }
                                }

                                break;
                            }

                        default:
                            {
                                ServiceDueDataview = App.DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID);
                                if (ServiceDueDataview.Count > 0 & amtServ > 0)
                                    amtServ -= ServiceDueDataview.Count;
                                if (amtServ < 0)
                                    amtServ = 0;
                                ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID, profile, amtServ).Table);
                                ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter2Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID).Table);
                                ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter3Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID).Table);
                                break;
                            }
                    }

                    if (!chkVoidProperty.Checked)
                    {
                        ServiceDueDataview.RowFilter = "PropertyVoid = 0";
                    }

                    if (!chkIncludePatchChecks.Checked && ServiceDueDataview.Table.Columns.Contains("PatchCheck"))
                    {
                        ServiceDueDataview.RowFilter = "PatchCheck = 0";
                    }
                }
                else
                {
                    ServiceDueDataview = App.DB.LetterManager.GetLetterScheduledAppointmentsMK3(dtpLetterCreateDate.Value, theCustomer.CustomerID);
                }

                grpServices.Text = "Services Due - " + ServiceDueDataview.Count;
                btnGenerateLetters.Enabled = true;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            var argcombo = cboLetterNumber;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
            dtpLetterCreateDate.Value = DateAndTime.Now;
            theCustomer = App.DB.Customer.Customer_Get(Convert.ToInt32(Enums.Customer.Flagship));
        }

        public DataTable AppointmentStrip(ref DataTable appointments, List<int> levelslist, List<string> Postcodes, DataTable engineerPostcodes, bool keepweekends = false)
        {
            appointments.Columns.Add("SolidQual", typeof(bool));
            appointments.Columns.Add("OilQual", typeof(bool));
            appointments.Columns.Add("GasQual", typeof(bool));
            appointments.Columns.Add("ASHPQual", typeof(bool));
            appointments.Columns.Add("ComQual", typeof(bool));

            List<int> quals = new List<int>();
            quals.Add((int)Enums.EngineerQual.CBUOC);
            quals.Add((int)Enums.EngineerQual.SOLIDFUEL);
            quals.Add((int)Enums.EngineerQual.OILOFTEC);
            quals.Add((int)Enums.EngineerQual.DOMGAS);
            quals.Add((int)Enums.EngineerQual.ASHP);

            var engineerDetails = (from x in appointments.AsEnumerable() select new { EngineerId = x.GetValue<int>("EngineerId"), ServPri = x.GetValue<int>("ServPri") }).Distinct();
            DataTable engineerLevels = App.DB.EngineerLevel.GetAllTicked().Table;

            foreach (var engineer in engineerDetails)
            {
                bool removeengineer = true;
                List<int> qualificationIds = (from x in engineerLevels.AsEnumerable() where x.GetValue<int>("EngineerID") == engineer.EngineerId select x.Field<int>("ManagerID")).Distinct().ToList();
                List<string> commericalQuals = (from x in engineerLevels.AsEnumerable() where x.GetValue<string>("Name").Length > 2 && x.GetValue<string>("Name").Substring(0, 3).Contains("COM") select x.GetValue<string>("Name")).ToList();

                var mandatoryQual = qualificationIds.Where(x => levelslist.Contains(x)).ToList();
                var matchingQuals = qualificationIds.Where(x => quals.Contains(x)).ToList();

                if (mandatoryQual.Count > 0)
                {
                    removeengineer = false;
                }

                if (engineer.ServPri == 10)
                    removeengineer = true;

                if (removeengineer == false)
                {
                    removeengineer = true;

                    List<string> engpostcodes = engineerPostcodes.AsEnumerable().Where(x => x.GetValue<int>("EngineerID") == engineer.EngineerId).Select(x => x.GetValue<string>("Name")).Distinct().ToList();
                    List<string> matchingPostcodes = engpostcodes.Where(x => Postcodes.Contains(x)).ToList();

                    if (matchingPostcodes.Count > 0)
                        removeengineer = false;
                }

                DataRow[] dataToUpdate = appointments.Select("EngineerID = " + engineer.EngineerId);

                if (removeengineer)
                {
                    foreach (var r in dataToUpdate)
                    {
                        r.SetField("remove", true);
                    }
                }
                else
                {
                    foreach (var r in dataToUpdate)
                    {
                        r.SetField("keep", true);
                        r.SetField("OilQual", matchingQuals.Contains((int)Enums.EngineerQual.OILOFTEC));
                        r.SetField("SolidQual", matchingQuals.Contains((int)Enums.EngineerQual.SOLIDFUEL));
                        r.SetField("ASHPQual", matchingQuals.Contains((int)Enums.EngineerQual.ASHP));
                        r.SetField("GasQual", matchingQuals.Contains((int)Enums.EngineerQual.DOMGAS));
                        r.SetField("ComQual", matchingQuals.Count > 0);
                    }
                }
            }

            var dtr = appointments.Select("remove = 1  AND CBUOC = 0");
            foreach (DataRow dr9 in dtr)  // remove the engineers not eligable
                appointments.Rows.Remove(dr9);

            // remove BH and saturdays
            if (keepweekends == false)
            {
                var dtr2 = appointments.Select("1=1");
                foreach (DataRow dr10 in dtr2)
                {
                    DateTime theDate = dr10.GetValue<DateTime>("thedate");

                    if (theDate.DayOfWeek == DayOfWeek.Saturday || theDate.DayOfWeek == DayOfWeek.Sunday || dr10.GetValue<bool>("BH") == true)
                    {
                        appointments.Rows.Remove(dr10);
                    }
                }
            }

            return appointments;
        }

        private bool GetAppointments(bool DoJobs = false)
        {
            Cursor = Cursors.WaitCursor;
            var startProcess = DateAndTime.Now;
            var SelectedServiceDueView = new DataView();
            if (ServiceDueDataview is object && ServiceDueDataview.Count > 0)
            {
                SelectedServiceDueView.Table = SelectedServiceDueDataRow.Table;
                if (!SelectedServiceDueView.Table.Columns.Contains("EngName"))
                    SelectedServiceDueView.Table.Columns.Add("EngName");
                if (DoJobs)
                {
                    SelectedServiceDueView.RowFilter = "SendLetterTick = 1";
                }

                if (SelectedServiceDueView.Count == 0)
                {
                    App.ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return default;
                }

                if (chkLastService.Checked)
                    SelectedServiceDueView.Sort = "LastServiceDate";
                else
                    SelectedServiceDueView.Sort = "Postcode";
                var AppointmentsView = new DataView();
                AppointmentsView.Table = App.DB.LetterManager.Get_Appointments_Main_MK3(DateHelper.GetTheMonday(dtpLetterCreateDate.Value), 15, 31, (int)(Convert.ToInt32(tbMinsPerDay.Text) / (decimal)2));

                List<int> levelsList = new List<int>();

                int co = 0;
                var dd = App.DB.Customer.Requirements_Get_For_CustomerID(theCustomer.CustomerID).Table.Select("tick = 1");
                foreach (DataRow d in dd)
                {
                    levelsList.Add(Convert.ToInt32(d["ManagerID"]));
                    co += 1;
                }

                if (co == 0)
                {
                    levelsList.Add(Convert.ToInt32(Enums.EngineerQual.RETAIL)); // Retail Engineer Skill level
                }

                Postcodes.Clear();
                foreach (DataRowView dr in SelectedServiceDueView)
                    Postcodes.Add(Conversions.ToString(Convert.ToString(dr["Postcode"]).Substring(0, Convert.ToString(dr["Postcode"]).IndexOf("-"))));
                var argappointments = AppointmentsView.Table;

                DataTable engineerPostcodes = App.DB.EngineerPostalRegion.GetAllTicked().Table;
                AppointmentsView.Table = AppointmentStrip(ref argappointments, levelsList, Postcodes, engineerPostcodes); // strip out not postcoded engineers and those who dont work on this work.
                AppointmentsView.Table.Columns.Add("AMCLOSE", typeof(int));
                AppointmentsView.Table.Columns.Add("PMCLOSE", typeof(int));
                AppointmentsView.Table.Columns.Add("AMLatitude", typeof(double));
                AppointmentsView.Table.Columns.Add("AMLongitude", typeof(double));
                AppointmentsView.Table.Columns.Add("PMLatitude", typeof(double));
                AppointmentsView.Table.Columns.Add("PMLongitude", typeof(double));
                AppointmentsView.Sort = "ServPri ASC, EngineerID, daynumber";

                try // Added a try to stop it breaking the app when an error occours
                {
                    int c = -1;
                    do
                    {
                        c = c + 1;
                        DataRow ServiceVisit = SelectedServiceDueView[c].Row;

                        foreach (DataRow dr in AppointmentsView.Table.Rows)
                        {
                            if (!Information.IsDBNull(dr["AMLatitude"]) & !Information.IsDBNull(ServiceVisit["Latitude"]))
                            {
                                double d = Helper.MakeDoubleValid(Helper.Distance(Conversions.ToDouble(dr["AMLatitude"]), Conversions.ToDouble(dr["AMLongitude"]), Conversions.ToDouble(ServiceVisit["Latitude"]), Conversions.ToDouble(ServiceVisit["Longitude"]), 'M'));
                                dr["AMCLOSE"] = d;
                            }
                            else
                            {
                                dr["AMCLOSE"] = DBNull.Value;
                            }

                            if (!Information.IsDBNull(dr["PMLatitude"]) & !Information.IsDBNull(ServiceVisit["Latitude"]))
                            {
                                double d2 = Helper.MakeDoubleValid(Helper.Distance(Conversions.ToDouble(dr["PMLatitude"]), Conversions.ToDouble(dr["PMLongitude"]), Conversions.ToDouble(ServiceVisit["Latitude"]), Conversions.ToDouble(ServiceVisit["Longitude"]), 'M'));
                                dr["PMCLOSE"] = d2;
                            }
                            else
                            {
                                dr["PMCLOSE"] = DBNull.Value;
                            }
                        }

                        if (Information.IsDBNull(ServiceVisit["FuelID"]))
                            ServiceVisit["FuelID"] = 0;
                        if (Information.IsDBNull(ServiceVisit["CommercialDistrict"]))
                            ServiceVisit["CommercialDistrict"] = false;

                        int VisitTime = 40;
                        Enums.FuelTypes fuel = (Enums.FuelTypes)ServiceVisit.GetValue<int>("FuelID");
                        string siteFuel = ServiceVisit.GetValue<string>("SiteFuel");

                        bool patchCheck = Conversions.ToBoolean(ServiceVisit.Table.Columns.Contains("PatchCheck") && Conversions.ToBoolean(ServiceVisit["PatchCheck"]) == true);
                        if (ServiceVisit.GetValue<bool>("CommercialDistrict") == true || patchCheck)
                        {
                            VisitTime = 15;
                        }
                        else if (fuel == Enums.FuelTypes.SolidFuel || ServiceVisit.GetValue<bool>("SolidFuel") == true || siteFuel.Contains("Solid"))
                        {
                            VisitTime = 75;
                        }
                        else if (fuel == Enums.FuelTypes.Oil || siteFuel.Contains("Oil"))
                        {
                            VisitTime = 60;
                        }
                        else
                        {
                            VisitTime = 40;
                        }

                        var suggestedVisit = Helper.MakeDateTimeValid(ServiceVisit["NextVisitDate"]);
                        var switchExpr = ServiceVisit["Type"].ToString();
                        switch (switchExpr)
                        {
                            case "Letter 1":
                                {
                                    AppointmentsView.RowFilter = "DATE <= #" + DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") + "# AND DATE >= #" + DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") + "#";
                                    break;
                                }

                            case "Letter 2":
                                {
                                    suggestedVisit = DateHelper.CheckBankHolidaySatOrSunForward(suggestedVisit);
                                    AppointmentsView.RowFilter = "DATE <= #" + DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") + "# AND DATE >= #" + suggestedVisit.ToString("yyyy-MM-dd") + "#";
                                    break;
                                }

                            case "Letter 3":
                                {
                                    AppointmentsView.RowFilter = "DATE = #" + DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("yyyy-MM-dd") + "#";
                                    break;
                                }
                        }

                        foreach (DataRowView engineer in AppointmentsView)
                        {
                            string sitePostcode = ServiceVisit["Postcode"].ToString().Substring(0, Convert.ToInt32(Convert.ToString(ServiceVisit["Postcode"]).IndexOf("-")));
                            DataRow[] matches = engineerPostcodes.Select("EngineerID = " + (int)engineer["EngineerID"] + " AND Name = '" + sitePostcode + "'");
                            if (matches.Length > 0)
                            {
                                if (Conversions.ToBoolean((Operators.ConditionalCompareObjectEqual(ServiceVisit["FuelID"], Enums.FuelTypes.NatGas, false) | Operators.ConditionalCompareObjectEqual(ServiceVisit["FuelID"], Enums.FuelTypes.LPG, false) | ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("GAS") | ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("LPG")) & Operators.ConditionalCompareObjectEqual(engineer["GasQual"], 0, false) | (Operators.ConditionalCompareObjectEqual(ServiceVisit["FuelID"], Enums.FuelTypes.SolidFuel, false) | Operators.ConditionalCompareObjectEqual(ServiceVisit["SolidFuel"], true, false) | ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("SOLID FUEL")) & Operators.ConditionalCompareObjectEqual(engineer["SolidQual"], 0, false) | (Operators.ConditionalCompareObjectEqual(ServiceVisit["FuelID"], Enums.FuelTypes.Oil, false) | ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("OIL")) & Operators.ConditionalCompareObjectEqual(engineer["OilQual"], 0, false) | (ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("AIR SOURCE") | ServiceVisit["SiteFuel"].ToString().ToUpper().Contains("ASHP")) & Operators.ConditionalCompareObjectEqual(engineer["ASHPQual"], 0, false) | Operators.ConditionalCompareObjectEqual(ServiceVisit["CommercialDistrict"], true, false) & Operators.ConditionalCompareObjectEqual(engineer["ComQual"], 0, false)))
                                {
                                    continue;
                                }

                                bool emptyAm = false;
                                bool emptyPm = false;
                                if (engineer.Row.GetValue<int>("AMCLOSE") == 0 && engineer.Row.GetValue<int>("PMCLOSE") == 0)
                                {
                                    engineer["AMCLOSE"] = -1;
                                    engineer["PMCLOSE"] = -1;
                                }
                                else if (engineer.Row.GetValue<int>("AMCLOSE") == 0)
                                {
                                    engineer["AMCLOSE"] = engineer.Row.GetValue<int>("PMCLOSE") - Convert.ToInt32(txtTravelBetween.Text);
                                    emptyAm = true;
                                }
                                else if (engineer.Row.GetValue<int>("PMCLOSE") == 0)
                                {
                                    engineer["PMCLOSE"] = engineer.Row.GetValue<int>("AMCLOSE") - Convert.ToInt32(txtTravelBetween.Text);
                                    emptyPm = true;
                                }

                                if (engineer.Row.GetValue<decimal>("remainingAM") >= VisitTime && engineer.Row.GetValue<int>("AMCLOSE") < Convert.ToInt32(txtMaxTravel.Text))
                                {
                                    ServiceVisit["EngName"] = engineer["Name"];
                                    ServiceVisit["EngineerID"] = engineer["EngineerID"];
                                    ServiceVisit["BookedDateTime"] = engineer["Date"];
                                    ServiceVisit["NextVisitDate"] = engineer["Date"];
                                    ServiceVisit["AMPM"] = "AM";
                                    engineer["remainingAM"] = (decimal)engineer["remainingAM"] - VisitTime;
                                    AvailView.Table.Rows[(int)Conversions.ToDate(engineer["Date"]).DayOfWeek - 1]["Avail"] = (int)AvailView.Table.Rows[(int)Conversions.ToDate(engineer["Date"]).DayOfWeek - 1]["Avail"] - 1;
                                    if (engineer.Row.GetValue<int>("AMCLOSE") == -1 || emptyAm)
                                    {
                                        var drs = AppointmentsView.Table.Select("EngineerID = " + Convert.ToInt32(ServiceVisit["EngineerID"]) + " AND DATE = #" + suggestedVisit.ToString("yyyy-MM-dd") + "#");
                                        if (drs.Length > -1) // If We got results
                                        {
                                            foreach (DataRow dr in drs)
                                            {
                                                dr["AMLatitude"] = ServiceVisit["Latitude"];
                                                dr["AMLongitude"] = ServiceVisit["Longitude"];
                                            }
                                        }
                                    }
                                    AppointmentsView.Table.AcceptChanges();
                                    break;
                                }
                                else if (engineer.Row.GetValue<decimal>("RemainingPM") >= VisitTime && engineer.Row.GetValue<int>("PMCLOSE") < Convert.ToInt32(txtMaxTravel.Text))
                                {
                                    ServiceVisit["EngName"] = engineer["Name"];
                                    ServiceVisit["EngineerID"] = engineer["EngineerID"];
                                    ServiceVisit["BookedDateTime"] = engineer["Date"];
                                    ServiceVisit["NextVisitDate"] = engineer["Date"];
                                    ServiceVisit["AMPM"] = "PM";
                                    engineer["remainingPM"] = (decimal)engineer["remainingPM"] - VisitTime;
                                    AvailView.Table.Rows[(int)Conversions.ToDate(engineer["Date"]).DayOfWeek - 1]["Avail"] = (int)AvailView.Table.Rows[(int)Conversions.ToDate(engineer["Date"]).DayOfWeek - 1]["Avail"] - 1;
                                    if (engineer.Row.GetValue<int>("PMCLOSE") == -1 | emptyPm) // legacy way was to do the select in one line
                                    {
                                        foreach (DataRow ee in AppointmentsView.Table.Select(Conversions.ToString("EngineerID = '" + ServiceVisit["EngineerID"] + "' AND DATE = #" + suggestedVisit.ToString("yyyy-MM-dd") + "#")))
                                        {
                                            ee["PMLatitude"] = ServiceVisit["Latitude"];
                                            ee["PMLongitude"] = ServiceVisit["Longitude"];
                                        }
                                    }
                                    AppointmentsView.Table.AcceptChanges();
                                    break;
                                }
                            }
                        }

                        if (Helper.MakeBooleanValid(ServiceVisit["MultipleFuelSite"]) & !Information.IsDBNull(ServiceVisit["BookedDateTime"]))
                        {
                            var mf = SelectedServiceDueView.Table.Select("SiteID = " + Helper.MakeIntegerValid(ServiceVisit["SiteID"]));
                            foreach (DataRow f in mf)
                            {
                                if (Helper.MakeBooleanValid(f["MultipleFuelSite"]))
                                    f["NextVisitDate"] = ServiceVisit["NextVisitDate"];
                            }
                        }
                    }
                    while (c < SelectedServiceDueView.Count - 1);
                }
                catch (Exception ex) // show the user
                {
                    App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // different way of catching the change
                var SchedulerAppsView = new DataView();
                SchedulerAppsView.Table = App.DB.EngineerVisits.Get_Appointments_Scheduler(DateTime.Now.ToString("yyyy-MM-dd"), 15);
                var argappointments1 = SchedulerAppsView.Table;
                SchedulerAppsView.Table = AppointmentStrip(ref argappointments1, levelsList, Postcodes, engineerPostcodes, false);
                SchedulerAppsView.Sort = "Daynumber";
                if (SchedulerAppsView.Count == 0)
                {
                    Interaction.MsgBox("Please ensure there is a scheduler which can except " + App.DB.Picklists.Get_One_As_Object(levelsList[0]).Name + " And you are not booking further than 28 days ahead", MsgBoxStyle.Critical);
                    return false;
                    return default;
                }

                AvailView.Sort = "Avail DESC";
                var availdt = AvailView.ToTable();
                SelectedServiceDueView.RowFilter = "EngineerID = 0 OR EngineerID IS NULL or EngName LIKE '%SCHED%'";
                SelectedServiceDueView.Sort = "MultipleFuelSite Desc";
                int c1 = 0;
                foreach (DataRowView ServiceVisit in SelectedServiceDueView)
                {
                    string BookedDate = "";
                    c1 = c1 + 1;
                    var suggestedVisit = Helper.MakeDateTimeValid(ServiceVisit["NextVisitDate"]);
                    var switchExpr1 = ServiceVisit["Type"].ToString();
                    switch (switchExpr1)
                    {
                        case "Letter 1":
                            {
                                SchedulerAppsView.RowFilter = "DATE <= #" + DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") + "# AND DATE >= #" + DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") + "#";
                                BookedDate = Conversions.ToString(DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetTheMonday(dtpLetterCreateDate.Value).AddDays(Conversions.ToDouble(14 + (Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)))));
                                break;
                            }

                        case "Letter 2":
                            {
                                SchedulerAppsView.RowFilter = "DATE <= #" + DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") + "# AND DATE >= #" + DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") + "#";
                                BookedDate = Conversions.ToString(DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetTheMonday(dtpLetterCreateDate.Value).AddDays(Conversions.ToDouble(14 + (Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)))));
                                break;
                            }

                        case "Letter 3":
                            {
                                SchedulerAppsView.RowFilter = "DATE = #" + DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("yyyy-MM-dd") + "#";
                                BookedDate = DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("dd/MM/yyyy");
                                break;
                            }
                    }

                    if (Helper.MakeBooleanValid(ServiceVisit["MultipleFuelSite"]))
                    {
                        BookedDate = Conversions.ToString(suggestedVisit);
                    }

                    foreach (DataRowView Scheduler in SchedulerAppsView)
                    {
                        string sitePostcode = ServiceVisit["Postcode"].ToString().Substring(0, Convert.ToInt32(Convert.ToString(ServiceVisit["Postcode"]).IndexOf("-")));
                        DataRow[] matches = engineerPostcodes.Select("EngineerID = " + Scheduler.Row.GetValue<int>("EngineerID") + " AND Name = '" + sitePostcode + "'");
                        if (matches.Length > 0)
                        {
                            ServiceVisit["EngName"] = Scheduler["Name"];
                            ServiceVisit["EngineerID"] = Scheduler["EngineerID"];
                            ServiceVisit["BookedDateTime"] = BookedDate;
                            ServiceVisit["NextVisitDate"] = BookedDate;
                            if (c1 < 5)
                            {
                                ServiceVisit["AMPM"] = "AM";
                                AvailView.Table.Rows[Convert.ToInt32(Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)]["Avail"] = (int)AvailView.Table.Rows[Convert.ToInt32(Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)]["Avail"] - 1;
                            }
                            else if (c1 > 4)
                            {
                                ServiceVisit["AMPM"] = "PM";
                                AvailView.Table.Rows[Convert.ToInt32(Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)]["Avail"] = (int)AvailView.Table.Rows[Convert.ToInt32(Convert.ToInt32(availdt.Rows[0]["Day"]) - 1)]["Avail"] - 1;
                                if (c1 > 7)
                                {
                                    c1 = 0;
                                    AvailView.Sort = "Avail DESC";
                                    availdt = AvailView.ToTable();
                                }
                            }
                        }
                    }
                }

                try
                {
                    if (DoJobs == true)
                    {
                        SelectedServiceDueView.RowFilter = "SendLetterTick = 1";
                        var details = new ArrayList();
                        details.Add(SelectedServiceDueView);
                        var oPrint = new Printing(details, "NCC Service Letters MK2", Enums.SystemDocumentType.ServiceLettersMK2, true, 0, false, Convert.ToInt32(tbMinsPerDay.Text), theCustomer.CustomerID, Conversions.ToDate(dtpLetterCreateDate.Text));
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

        
    }
}