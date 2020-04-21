using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMLetterManager : FRMBaseForm, IForm
    {
        public FRMLetterManager()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboLetterNumber;
            Combo.SetUpCombo(ref argc, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            ResetFilters();
            SetupLettersDataGrid();
            PopulateDatagrid();
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        private Entity.Customers.Customer _customer;

        public Entity.Customers.Customer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
                if (_customer is object)
                {
                    txtCustomer.Text = _customer.Name + " (A/C No : " + _customer.AccountNumber + ")";
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupLettersDataGrid()
        {
            var tbStyle = dgServicesDue.TableStyles[0];
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 80;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var SiteFuel = new DataGridLabelColumn();
            SiteFuel.Format = "";
            SiteFuel.FormatInfo = null;
            SiteFuel.HeaderText = "SiteFuel";
            SiteFuel.MappingName = "SiteFuel";
            SiteFuel.ReadOnly = true;
            SiteFuel.Width = 150;
            SiteFuel.NullText = "";
            tbStyle.GridColumnStyles.Add(SiteFuel);
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
            Address1.HeaderText = "Address1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 150;
            Address1.NullText = "";
            tbStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 150;
            Address2.NullText = "";
            tbStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 150;
            Address3.NullText = "";
            tbStyle.GridColumnStyles.Add(Address3);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 150;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var LastServiceDate = new DataGridLabelColumn();
            LastServiceDate.Format = "dd/MM/yyyy";
            LastServiceDate.FormatInfo = null;
            LastServiceDate.HeaderText = "Last Service Date";
            LastServiceDate.MappingName = "LastServiceDate";
            LastServiceDate.ReadOnly = true;
            LastServiceDate.Width = 150;
            LastServiceDate.NullText = "";
            tbStyle.GridColumnStyles.Add(LastServiceDate);
            var NextVisitDate = new DueDateColourColumn();
            NextVisitDate.Format = "dddd dd/MM/yyyy"; // Actually done in column
            NextVisitDate.FormatInfo = null;
            NextVisitDate.HeaderText = "Due Date";
            NextVisitDate.MappingName = "NextVisitDate";
            NextVisitDate.ReadOnly = true;
            NextVisitDate.Width = 150;
            NextVisitDate.NullText = "";
            tbStyle.GridColumnStyles.Add(NextVisitDate);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "ServiceDue";
            dgServicesDue.TableStyles.Add(tbStyle);
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
            btnGenerateLetters.Enabled = true;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ServiceDueDataview.AllowEdit = true;
            foreach (DataRowView r in ServiceDueDataview)
                r["Tick"] = true;
            ServiceDueDataview.Table.AcceptChanges();
            ServiceDueDataview.AllowEdit = false;
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in ServiceDueDataview.Table.Rows)
                r["Tick"] = false;
        }

        private void btnGenerateLetters_Click(object sender, EventArgs e)
        {
            GenerateLetters();
        }

        private void dgServicesDue_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgServicesDue.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Entity.Sys.Helper.MakeBooleanValid(SelectedServiceDueDataRow["tick"]);
                    SelectedServiceDueDataRow["Tick"] = selected;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateDatagrid()
        {
            try
            {
                var Letter2 = new DataTable();
                if (Customer.CustomerID == -1)  // 5872 ' Victory removed
                {
                    ServiceDueDataview = App.DB.LetterManager.Letter1Manager(Conversions.ToDate(Strings.Format(GetTheFriday(dtpLetterCreateDate.Value), "dd/MM/yyyy")), Customer.CustomerID, -323); // change in days..
                }
                else
                {
                    ServiceDueDataview = App.DB.LetterManager.Letter1Manager(Conversions.ToDate(Strings.Format(GetTheFriday(dtpLetterCreateDate.Value), "dd/MM/yyyy")), Customer.CustomerID);
                }

                if (Customer.CustomerID == -1) // 5872' Victory removed
                {
                    Letter2 = App.DB.LetterManager.Letter2Manager(Conversions.ToDate(Strings.Format(dtpLetterCreateDate.Value, "dd/MM/yyyy")), Customer.CustomerID, -337); // change in days
                }
                else
                {
                    Letter2 = App.DB.LetterManager.Letter2Manager(Conversions.ToDate(Strings.Format(dtpLetterCreateDate.Value, "dd/MM/yyyy")), Customer.CustomerID);
                }

                foreach (DataRow dr2 in Letter2.Rows)
                {
                    var r2 = ServiceDueDataview.Table.NewRow();
                    r2["Tick"] = dr2["Tick"];
                    r2["Type"] = dr2["Type"];
                    r2["Name"] = dr2["Name"];
                    r2["Address1"] = dr2["Address1"];
                    r2["Address2"] = dr2["Address2"];
                    r2["Address3"] = dr2["Address3"];
                    r2["Address4"] = dr2["Address4"];
                    r2["Address5"] = dr2["Address5"];
                    r2["Postcode"] = dr2["Postcode"];
                    r2["SiteID"] = dr2["SiteID"];
                    r2["SolidFuel"] = dr2["SolidFuel"];
                    r2["Notes"] = dr2["Notes"];
                    r2["PropertyVoid"] = dr2["PropertyVoid"];
                    r2["LastServiceDate"] = dr2["LastServiceDate"];
                    r2["NextVisitDate"] = dr2["NextVisitDate"];
                    r2["SiteFuel"] = dr2["SiteFuel"];
                    ServiceDueDataview.Table.Rows.Add(r2);
                }

                var Letter3 = App.DB.LetterManager.Letter3Manager(Conversions.ToDate(Strings.Format(dtpLetterCreateDate.Value, "yyyy-MM-dd")), Customer.CustomerID);
                if (Customer.CustomerID == (int)Entity.Sys.Enums.Customer.NCC) // NCC , WDC , HAS , COT , TEN,  Saff
                {
                    foreach (DataRow dr3 in Letter3.Rows)
                    {
                        var r3 = ServiceDueDataview.Table.NewRow();
                        r3["Tick"] = dr3["Tick"];
                        r3["Type"] = dr3["Type"];
                        r3["Name"] = dr3["Name"];
                        r3["Address1"] = dr3["Address1"];
                        r3["Address2"] = dr3["Address2"];
                        r3["Address3"] = dr3["Address3"];
                        r3["Address4"] = dr3["Address4"];
                        r3["Address5"] = dr3["Address5"];
                        r3["Postcode"] = dr3["Postcode"];
                        r3["SiteID"] = dr3["SiteID"];
                        r3["SolidFuel"] = dr3["SolidFuel"];
                        r3["Notes"] = dr3["Notes"];
                        r3["PropertyVoid"] = dr3["PropertyVoid"];
                        r3["LastServiceDate"] = dr3["LastServiceDate"];
                        r3["NextVisitDate"] = dr3["NextVisitDate"];
                        r3["SiteFuel"] = dr3["SiteFuel"];
                        ServiceDueDataview.Table.Rows.Add(r3);
                    }
                }

                if ((Combo.get_GetSelectedItemValue(cboLetterNumber) ?? "") != "0")
                {
                    ServiceDueDataview.RowFilter = "Type ='" + Combo.get_GetSelectedItemDescription(cboLetterNumber) + "'";
                }

                grpServices.Text = "Services Due - " + ServiceDueDataview.Count;
                btnGenerateLetters.Enabled = true;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime GetTheFriday(DateTime DateIn)
        {
            var switchExpr = DateIn.DayOfWeek;
            switch (switchExpr)
            {
                case DayOfWeek.Monday:
                    {
                        return DateIn.AddDays(4);
                    }

                case DayOfWeek.Tuesday:
                    {
                        return DateIn.AddDays(3);
                    }

                case DayOfWeek.Wednesday:
                    {
                        return DateIn.AddDays(2);
                    }

                case DayOfWeek.Thursday:
                    {
                        return DateIn.AddDays(1);
                    }

                case DayOfWeek.Friday:
                    {
                        return DateIn;
                    }

                case DayOfWeek.Saturday:
                    {
                        return DateIn.AddDays(6);
                    }

                case DayOfWeek.Sunday:
                    {
                        return DateIn.AddDays(5);
                    }
            }

            return default;
        }

        private void ResetFilters()
        {
            var argcombo = cboLetterNumber;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            dtpLetterCreateDate.Value = DateAndTime.Now;
            Customer = App.DB.Customer.Customer_Get((int)Entity.Sys.Enums.Customer.NCC);
        }

        private void GenerateLetters()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var startProcess = DateAndTime.Now;
                DataRow[] filterList;
                filterList = SelectedServiceDueDataRow.Table.Select("Tick=1");
                var details = new ArrayList();
                details.Add(filterList);
                var oPrint = new Entity.Sys.Printing(details, "NCC Service Letters", Entity.Sys.Enums.SystemDocumentType.ServiceLetters, true, 0, false, Conversions.ToInteger(tbMinsPerDay.Text), Customer.CustomerID, Conversions.ToDate(dtpLetterCreateDate.Text));
                PopulateDatagrid();
                var endProcess = DateAndTime.Now;
                Interaction.MsgBox("Start: " + startProcess + Constants.vbCrLf + "End: " + endProcess);
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}