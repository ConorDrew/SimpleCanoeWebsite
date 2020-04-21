using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMPartsUsed : FRMBaseForm, IForm
    {
        public FRMPartsUsed()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboEngineer;
            Combo.SetUpCombo(ref argc, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.No_Filter);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc1 = cboDepartment;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc2 = cboDepartment;
                        Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            SetupPartsUsedDataGrid();
            ResetFilters();
            // PopulateDatagrid()
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
        private DataView _PartsDataview;

        private DataView PartsDataview
        {
            get
            {
                return _PartsDataview;
            }

            set
            {
                _PartsDataview = value;
                _PartsDataview.AllowNew = false;
                _PartsDataview.AllowEdit = false;
                _PartsDataview.AllowDelete = false;
                _PartsDataview.Table.TableName = Enums.TableNames.tblPart.ToString();
                dgPartsUsed.DataSource = PartsDataview;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                if (!(dgPartsUsed.CurrentRowIndex == -1))
                {
                    return PartsDataview[dgPartsUsed.CurrentRowIndex].Row;
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
                    theSite = null;
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSite.Text = theSite.Name + ", " + theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                }
                else
                {
                    txtSite.Text = "";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupPartsUsedDataGrid()
        {
            var tbStyle = dgPartsUsed.TableStyles[0];
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Ref";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 70;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job No";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 60;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO No";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 70;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Site";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 90;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 90;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 70;
            Supplier.NullText = "";
            tbStyle.GridColumnStyles.Add(Supplier);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 90;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Buy Price";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 70;
            BuyPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(BuyPrice);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "SellPrice";
            SellPrice.MappingName = "SellPrice";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 70;
            SellPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(SellPrice);
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Part Name";
            PartName.MappingName = "Name";
            PartName.ReadOnly = true;
            PartName.Width = 70;
            PartName.NullText = "";
            tbStyle.GridColumnStyles.Add(PartName);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "PartNumber";
            PartNumber.MappingName = "Number";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 70;
            PartNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PartNumber);
            var Quantity = new DataGridLabelColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Qty";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 35;
            Quantity.NullText = "";
            tbStyle.GridColumnStyles.Add(Quantity);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 70;
            StartDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var JobType = new DataGridLabelColumn();
            JobType.Format = "";
            JobType.FormatInfo = null;
            JobType.HeaderText = "Job Type";
            JobType.MappingName = "JobType";
            JobType.ReadOnly = true;
            JobType.Width = 70;
            JobType.NullText = "";
            tbStyle.GridColumnStyles.Add(JobType);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblPart.ToString();
            dgPartsUsed.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            // PopulateDatagrid()
            // RunFilter()
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            // PopulateDatagrid()
            // RunFilter()
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int customerID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (customerID > 0)
            {
                theCustomer = App.DB.Customer.Customer_Get(customerID);
            }

            RunFilter();
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int siteID = 0;
            if (theCustomer is null)
            {
                siteID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            }
            else
            {
                siteID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, theCustomer.CustomerID));
            }

            if (siteID > 0)
            {
                theSite = App.DB.Sites.Get(siteID);
            }

            RunFilter();
        }

        private void txtJobPONo_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtPartNameOrNumber_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboEngineer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateDatagrid()
        {
            try
            {
                PartsDataview = App.DB.EngineerVisitsPartsAndProducts.Parts_Used_Report(Conversions.ToDate(Strings.Format(dtpFrom.Value, "dd-MMM-yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format(dtpTo.Value, "dd-MMM-yyyy") + " 23:59:59"));
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            dtpFrom.Value = DateAndTime.Today.AddMonths(-1);
            dtpTo.Value = DateAndTime.Today;
            theCustomer = null;
            theSite = null;
            txtJobPONo.Text = "";
            txtPartNameOrNumber.Text = "";
            var argcombo = cboEngineer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            PopulateDatagrid();
            RunFilter();
        }

        private void RunFilter()
        {
            if (PartsDataview is null)
            {
                return;
            }

            string whereClause = "1=1 ";
            if (theCustomer is object)
            {
                whereClause += " AND CustomerID = " + theCustomer.CustomerID + "";
            }

            if (theSite is object)
            {
                whereClause += " AND SiteID = " + theSite.SiteID + "";
            }

            if (txtJobPONo.Text.Length > 0)
            {
                whereClause += " AND PONumber LIKE '" + txtJobPONo.Text + "%'";
            }

            if (txtPartNameOrNumber.Text.Length > 0)
            {
                whereClause += " AND (Name LIKE '" + txtPartNameOrNumber.Text + "%' OR Number LIKE'" + txtPartNameOrNumber.Text + "%')";
            }

            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEngineer)) > 0)
            {
                whereClause += " AND EngineerID =" + Combo.get_GetSelectedItemValue(cboEngineer);
            }

            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
            if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
            {
                whereClause += " AND Department = '" + department + "'";
            }
            else if (!Information.IsNumeric(department))
            {
                whereClause += " AND Department = '" + department + "'";
            }

            PartsDataview.RowFilter = whereClause;
        }

        public void Export()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("OrderReference"));
            dt.Columns.Add(new DataColumn("JobNumber"));
            dt.Columns.Add(new DataColumn("PONumber"));
            dt.Columns.Add(new DataColumn("Site"));
            dt.Columns.Add(new DataColumn("Customer"));
            dt.Columns.Add(new DataColumn("Supplier"));
            dt.Columns.Add(new DataColumn("Engineer"));
            dt.Columns.Add(new DataColumn("BuyPrice"));
            dt.Columns.Add(new DataColumn("SellPrice"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Number"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("StartDateTime"));
            dt.Columns.Add(new DataColumn("UPRN"));
            for (int itm = 0, loopTo = ((DataView)dgPartsUsed.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgPartsUsed.CurrentRowIndex = itm;
                var r = dt.NewRow();
                r["OrderReference"] = SelectedPartDataRow["OrderReference"];
                r["JobNumber"] = SelectedPartDataRow["JobNumber"];
                r["PONumber"] = SelectedPartDataRow["PONumber"];
                r["Site"] = SelectedPartDataRow["Site"];
                r["Customer"] = SelectedPartDataRow["Customer"];
                r["Supplier"] = SelectedPartDataRow["Supplier"];
                r["Engineer"] = SelectedPartDataRow["Engineer"];
                r["BuyPrice"] = SelectedPartDataRow["BuyPrice"];
                r["SellPrice"] = SelectedPartDataRow["SellPrice"];
                r["Name"] = SelectedPartDataRow["Name"];
                r["Number"] = SelectedPartDataRow["Number"];
                r["Quantity"] = SelectedPartDataRow["Quantity"];
                r["StartDateTime"] = SelectedPartDataRow["StartDateTime"];
                r["UPRN"] = SelectedPartDataRow["UPRN"];
                dt.Rows.Add(r);
                dgPartsUsed.UnSelect(itm);
            }

            ExportHelper.Export(dt, "Parts Used Report", Enums.ExportType.XLS);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private void Button1_Click(object sender, EventArgs e)
        {
            PopulateDatagrid();
            RunFilter();
        }
    }
}