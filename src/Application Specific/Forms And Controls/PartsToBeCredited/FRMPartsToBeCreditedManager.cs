using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMPartsToBeCreditedManager : FRMBaseForm, IForm
    {
        public FRMPartsToBeCreditedManager()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            CreatePartsAndProductsDistribution();
            SetupCreditDataGrid();
            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, DynamicDataTables.CreditStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            ResetFilters();
            PopulateDatagrid();
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

        
        
        private DataView _dvCredits;

        private DataView CreditsDataview
        {
            get
            {
                return _dvCredits;
            }

            set
            {
                _dvCredits = value;
                _dvCredits.AllowNew = false;
                _dvCredits.AllowEdit = false;
                _dvCredits.AllowDelete = false;
                _dvCredits.Table.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                dgCredits.DataSource = CreditsDataview;
            }
        }

        private DataRow SelectedCreditDataRow
        {
            get
            {
                if (!(dgCredits.CurrentRowIndex == -1))
                {
                    return CreditsDataview[dgCredits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _PartsDistribution = null;

        public DataView PartsDistribution
        {
            get
            {
                return _PartsDistribution;
            }

            set
            {
                _PartsDistribution = value;
            }
        }

        
        

        private void SetupCreditDataGrid()
        {
            var tbStyle = dgCredits.TableStyles[0];
            var tick = new DataGridBoolColumn();
            tick.HeaderText = "";
            tick.MappingName = "tick";
            tick.ReadOnly = true;
            tick.Width = 25;
            tick.NullText = "";
            tbStyle.GridColumnStyles.Add(tick);
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 180;
            Supplier.NullText = "";
            tbStyle.GridColumnStyles.Add(Supplier);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Ref";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 90;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var Part = new DataGridLabelColumn();
            Part.Format = "";
            Part.FormatInfo = null;
            Part.HeaderText = "Part";
            Part.MappingName = "Part";
            Part.ReadOnly = true;
            Part.Width = 270;
            Part.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Part);
            var Qty = new DataGridLabelColumn();
            Qty.Format = "";
            Qty.FormatInfo = null;
            Qty.HeaderText = "Qty";
            Qty.MappingName = "Qty";
            Qty.ReadOnly = true;
            Qty.Width = 40;
            Qty.NullText = "";
            Qty.Alignment = HorizontalAlignment.Center;
            tbStyle.GridColumnStyles.Add(Qty);
            var Status = new DataGridLabelColumn();
            Status.Format = "";
            Status.FormatInfo = null;
            Status.HeaderText = "Status";
            Status.MappingName = "Status";
            Status.ReadOnly = true;
            Status.Width = 200;
            Status.NullText = "";
            tbStyle.GridColumnStyles.Add(Status);
            var ManuallyAdded = new DataGridLabelColumn();
            ManuallyAdded.Format = "";
            ManuallyAdded.FormatInfo = null;
            ManuallyAdded.HeaderText = "Manually Added";
            ManuallyAdded.MappingName = "ManuallyAdded";
            ManuallyAdded.ReadOnly = true;
            ManuallyAdded.Width = 60;
            ManuallyAdded.NullText = "";
            ManuallyAdded.Alignment = HorizontalAlignment.Center;
            tbStyle.GridColumnStyles.Add(ManuallyAdded);
            var CreditReference = new DataGridLabelColumn();
            CreditReference.Format = "";
            CreditReference.FormatInfo = null;
            CreditReference.HeaderText = "Credit Ref";
            CreditReference.MappingName = "CreditReference";
            CreditReference.ReadOnly = true;
            CreditReference.Width = 90;
            CreditReference.NullText = "";
            tbStyle.GridColumnStyles.Add(CreditReference);
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Date Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 120;
            DateCreated.NullText = "";
            tbStyle.GridColumnStyles.Add(DateCreated);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
            dgCredits.TableStyles.Add(tbStyle);
        }

        
        

        private void FRMOrderManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnGenerateCreditDocument_Click(object sender, EventArgs e)
        {
            try
            {
                int partCreditID = 0;
                int currentSupplierID = 0;
                string creditReference = "";
                int TotalCount = 0;
                int invalidcount = 0;
                var details = new ArrayList();
                string InvalidMessageString = "The following credits could not be generated as incorrect status<br>";
                foreach (DataRowView r in CreditsDataview)
                {
                    if (Conversions.ToBoolean(r["Tick"]) == true & Conversions.ToInteger(r["StatusID"]) == (int)Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier)
                    {
                        TotalCount += 1;
                        if (currentSupplierID == 0)
                        {
                            currentSupplierID = Conversions.ToInteger(r["SupplierID"]);
                        }

                        partCreditID = Entity.Sys.Helper.MakeIntegerValid(r["PartCreditsID"]);
                        creditReference = Entity.Sys.Helper.MakeStringValid(r["creditReference"]);
                        if (partCreditID == 0)
                        {
                            // create the credit items
                            foreach (DataRowView h in CreditsDataview)
                            {
                                if (Conversions.ToBoolean(h["Tick"]) == true)
                                {
                                    if (Conversions.ToBoolean(h["ManuallyAdded"]) == true)
                                    {
                                        if (PartLocation(h.Row) == false)
                                        {
                                            App.ShowMessage("Generation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            }

                            // TAKE THE STOCK QTY AWAY
                            foreach (DataRow distRow in PartsDistribution.Table.Rows)
                            {
                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.SetLocationID = distRow["LocationID"];
                                oPartTransaction.SetPartID = distRow["PartProductID"];
                                oPartTransaction.SetOrderPartID = distRow["OrderPartProductID"];
                                if (Conversions.ToInteger(distRow["StockTransactionType"]) == Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut))
                                {
                                    oPartTransaction.SetAmount = (int)distRow["Quantity"] * -1;
                                }
                                else
                                {
                                    oPartTransaction.SetAmount = distRow["Quantity"];
                                }

                                oPartTransaction.SetTransactionTypeID = distRow["StockTransactionType"];
                                App.DB.PartTransaction.Insert(oPartTransaction);
                            }

                            var switchExpr = Conversions.ToString(partCreditID).Length;
                            switch (switchExpr)
                            {
                                case 1:
                                    {
                                        creditReference = "000000" + partCreditID;
                                        break;
                                    }

                                case 2:
                                    {
                                        creditReference = "00000" + partCreditID;
                                        break;
                                    }

                                case 3:
                                    {
                                        creditReference = "0000" + partCreditID;
                                        break;
                                    }

                                case 4:
                                    {
                                        creditReference = "000" + partCreditID;
                                        break;
                                    }

                                case 5:
                                    {
                                        creditReference = "00" + partCreditID;
                                        break;
                                    }

                                case 6:
                                    {
                                        creditReference = "0" + partCreditID;
                                        break;
                                    }

                                default:
                                    {
                                        creditReference = partCreditID.ToString();
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            details.Add(App.DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(partCreditID).Table);
                        }
                    }
                    else if (Conversions.ToBoolean(r["Tick"]) == true & !(Conversions.ToInteger(r["StatusID"]) == (int)Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier))
                    {
                        invalidcount += 1;
                        InvalidMessageString = Conversions.ToString(InvalidMessageString + r["CreditReference"] + "<br>");
                    }
                    else
                    {
                    }
                }

                if (TotalCount == 0)
                {
                    App.ShowMessage("No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Exit Sub
                else
                {
                    if (currentSupplierID == 24) // Alpha Boilers
                    {
                        var oPrint = new Entity.Sys.Printing(details, "Alpha Part Credit", Entity.Sys.Enums.SystemDocumentType.AlphaPartCredit, true);
                    }
                    else
                    {
                        var oPrint = new Entity.Sys.Printing(details, "Part Credit", Entity.Sys.Enums.SystemDocumentType.PartCredit, true);
                    }

                    DialogResult dialogresult;
                    dialogresult = App.ShowMessage("Do you want to update these to 'Credit Req Sent to Supplier' Status?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogresult == DialogResult.Yes)
                    {
                        foreach (DataRowView r in CreditsDataview)
                        {
                            if (Conversions.ToBoolean(r["Tick"]) == true)
                            {
                                Entity.PartsToBeCrediteds.PartsToBeCredited oPartsToBeCredited;
                                oPartsToBeCredited = App.DB.PartsToBeCredited.PartsToBeCredited_Get(Conversions.ToInteger(r["PartsToBeCreditedID"]));
                                oPartsToBeCredited.SetStatusID = Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier);
                                App.DB.PartsToBeCredited.Update(oPartsToBeCredited);
                            }
                        }

                        PopulateDatagrid();
                    }
                    else
                    {
                        return;
                    }
                }

                if (invalidcount > 1)
                {
                    App.ShowMessage(InvalidMessageString, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Exit Sub
                }
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

        private void btnCreditAmount_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CreditsDataview is object)
                {
                    foreach (DataRow r in CreditsDataview.Table.Rows)
                        r["Tick"] = false;
                }

                if (SelectedCreditDataRow is object)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedCreditDataRow["StatusID"], Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return), false)))
                    {
                        App.ShowMessage("Parts must be returned before credit can be received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedCreditDataRow["StatusID"], Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Sent_To_Sage), false)))
                    {
                        App.ShowMessage("Credit Details sent to Sage.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // OPEN CREDIT
                        App.ShowForm(typeof(FRMCreditReceived), true, new object[] { SelectedCreditDataRow["PartCreditsID"], Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow["NominalCode"]), Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow["DepartmentRef"]), Entity.Sys.Helper.MakeIntegerValid(SelectedCreditDataRow["TaxCodeID"]), Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow["ExtraRef"]), Entity.Sys.Helper.MakeDateTimeValid(SelectedCreditDataRow["DateReceived"]), Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow["SupplierCreditRef"]) });
                    }
                }

                PopulateDatagrid();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMPartsToBeCredited), true, new object[] { 0 });
            PopulateDatagrid();
        }

        private void dgCredits_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedCreditDataRow is object)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedCreditDataRow["ManuallyAdded"], true, false)))
                {
                    if (Conversions.ToBoolean((int)SelectedCreditDataRow["StatusID"] < Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier)))
                    {
                        App.ShowForm(typeof(FRMPartsToBeCredited), true, new object[] { SelectedCreditDataRow["PartsToBeCreditedID"] });
                    }
                    else
                    {
                        App.ShowMessage("This part has been returned and cannot be edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    App.ShowMessage("Only manually added parts can be edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgCredits_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgCredits.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Entity.Sys.Helper.MakeBooleanValid(SelectedCreditDataRow["tick"]);
                    SelectedCreditDataRow["Tick"] = selected;
                }
            }
        }

        private void txtOrderReference_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtPart_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtCreditReference_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        
        

        public void PopulateDatagrid()
        {
            try
            {
                CreditsDataview = App.DB.PartsToBeCredited.PartsToBeCredited_GetAll();
                RunFilter();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            if (CreditsDataview is object)
            {
                foreach (DataRow r in CreditsDataview.Table.Rows)
                    r["Tick"] = false;
            }

            txtOrderReference.Text = "";
            txtSupplier.Text = "";
            txtPart.Text = "";
            txtCreditReference.Text = "";
            var argcombo = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
        }

        private void RunFilter()
        {
            if (CreditsDataview is object)
            {
                foreach (DataRow r in CreditsDataview.Table.Rows)
                    r["Tick"] = false;
                string whereClause = " 1 = 1 ";
                if (txtOrderReference.Text.Length > 0)
                {
                    whereClause += " AND OrderReference LIKE '%" + txtOrderReference.Text + "%'";
                }

                if (txtSupplier.Text.Length > 0)
                {
                    whereClause += " AND Supplier LIKE '" + txtSupplier.Text + "%'";
                }

                if (txtCreditReference.Text.Length > 0)
                {
                    whereClause += " AND CreditReference LIKE '" + txtCreditReference.Text + "%'";
                }

                if (txtPart.Text.Length > 0)
                {
                    whereClause += " AND Part LIKE '%" + txtPart.Text + "%'";
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) > 0)
                {
                    whereClause += " AND StatusID = " + Combo.get_GetSelectedItemValue(cboStatus);
                }

                CreditsDataview.RowFilter = whereClause;
            }
        }

        private void CreatePartsAndProductsDistribution()
        {
            var dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("DistributedID");
            dt.Columns.Add("LocationID");
            dt.Columns.Add("AllocatedID");
            dt.Columns.Add("Other");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("PartProductID");
            dt.Columns.Add("OrderPartProductID");
            dt.Columns.Add("StockTransactionType");
            PartsDistribution = new DataView(dt);
        }

        private bool PartLocation(DataRow dr)
        {
            var frmDistribution = new FRMDistributeAllocated(true, Conversions.ToInteger(dr["Qty"]), Conversions.ToString(dr["Part"]), "Part", Conversions.ToInteger(dr["PartID"]), new ArrayList());
            if (frmDistribution.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                {
                    if (Conversions.ToBoolean((int)row["Quantity"] > 0))
                    {
                        var r = PartsDistribution.Table.NewRow();
                        r["Type"] = "Part";
                        r["DistributedID"] = 0;
                        r["LocationID"] = row["LocationID"];
                        r["AllocatedID"] = row["AllocatedID"];
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false) & Operators.ConditionalCompareObjectEqual(row["AllocatedID"], 0, false)))
                        {
                            r["Other"] = true;
                        }
                        else
                        {
                            r["Other"] = false;
                        }

                        r["Quantity"] = row["Quantity"];
                        r["PartProductID"] = dr["PartID"];
                        r["OrderPartProductID"] = row["OrderPartProductID"];
                        r["StockTransactionType"] = row["StockTransactionType"];
                        PartsDistribution.Table.Rows.Add(r);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}