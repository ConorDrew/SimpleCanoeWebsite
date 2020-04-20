using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMCreditReceived : FRMBaseForm, IForm
    {
        public FRMCreditReceived()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboTaxCode;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Dashes);
            PartCreditsID = Conversions.ToInteger(get_GetParameter(0));
            SetupCreditDataGrid();
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _PartCreditsID = 0;

        private int PartCreditsID
        {
            get
            {
                return _PartCreditsID;
            }

            set
            {
                _PartCreditsID = value;
                Populate();
            }
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
                _dvCredits.AllowEdit = true;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupCreditDataGrid()
        {
            var tbStyle = dgCredits.TableStyles[0];
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 140;
            Supplier.NullText = "";
            tbStyle.GridColumnStyles.Add(Supplier);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Reference";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 120;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var Part = new DataGridLabelColumn();
            Part.Format = "";
            Part.FormatInfo = null;
            Part.HeaderText = "Part";
            Part.MappingName = "Part";
            Part.ReadOnly = true;
            Part.Width = 160;
            Part.NullText = "";
            tbStyle.GridColumnStyles.Add(Part);
            var Qty = new DataGridLabelColumn();
            Qty.Format = "";
            Qty.FormatInfo = null;
            Qty.HeaderText = "Qty";
            Qty.MappingName = "Qty";
            Qty.ReadOnly = true;
            Qty.Width = 60;
            Qty.NullText = "";
            tbStyle.GridColumnStyles.Add(Qty);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "Buy Price";
            SellPrice.MappingName = "Price";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 60;
            SellPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(SellPrice);
            var TotalPrice = new DataGridLabelColumn();
            TotalPrice.Format = "C";
            TotalPrice.FormatInfo = null;
            TotalPrice.HeaderText = "Total Price";
            TotalPrice.MappingName = "Total";
            TotalPrice.ReadOnly = true;
            TotalPrice.Width = 60;
            TotalPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(TotalPrice);
            var CreditReceived = new DataGridEditableTextBoxColumn();
            CreditReceived.Format = "C";
            CreditReceived.FormatInfo = null;
            CreditReceived.HeaderText = "Credit Received";
            CreditReceived.MappingName = "CreditReceived";
            CreditReceived.ReadOnly = false;
            CreditReceived.Width = 120;
            CreditReceived.NullText = "";
            CreditReceived.TextBox.TextChanged += CreditReceived_LostFocus;
            tbStyle.GridColumnStyles.Add(CreditReceived);
            tbStyle.ReadOnly = false;
            dgCredits.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
            dgCredits.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void FRMCreditReceived_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgCredits_CurrentCellChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void CreditReceived_LostFocus(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate_Tax();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate()
        {
            string creditReference = "";
            var switchExpr = Conversions.ToString(PartCreditsID).Length;
            switch (switchExpr)
            {
                case 1:
                    {
                        creditReference = "000000" + PartCreditsID;
                        break;
                    }

                case 2:
                    {
                        creditReference = "00000" + PartCreditsID;
                        break;
                    }

                case 3:
                    {
                        creditReference = "0000" + PartCreditsID;
                        break;
                    }

                case 4:
                    {
                        creditReference = "000" + PartCreditsID;
                        break;
                    }

                case 5:
                    {
                        creditReference = "00" + PartCreditsID;
                        break;
                    }

                case 6:
                    {
                        creditReference = "0" + PartCreditsID;
                        break;
                    }

                default:
                    {
                        creditReference = PartCreditsID.ToString();
                        break;
                    }
            }

            txtCreditReference.Text = creditReference;
            txtNominalCode.Text = Conversions.ToString(get_GetParameter(1));
            txtDepartment.Text = Conversions.ToString(get_GetParameter(2));
            CreditsDataview = App.DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(PartCreditsID);
            TotalAmount();
            var argcombo = cboTaxCode;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(get_GetParameter(3)));
            txtExtraRef.Text = Conversions.ToString(get_GetParameter(4));
            if (Conversions.ToBoolean(get_GetParameter(5) == default))
            {
                dtpDateReceived.Value = DateAndTime.Now;
            }
            else
            {
                dtpDateReceived.Value = Conversions.ToDate(get_GetParameter(5));
            }

            txtSupplierCreditRef.Text = Conversions.ToString(get_GetParameter(6));
        }

        private void TotalAmount()
        {
            double totalAmount = 0;
            double orderAmount = 0;
            foreach (DataRow dr in CreditsDataview.Table.Rows)
            {
                totalAmount += Entity.Sys.Helper.MakeDoubleValid(dr["CreditReceived"]);
                orderAmount += Entity.Sys.Helper.MakeDoubleValid(dr["Total"]);
            }

            txtTotalAmount.Text = Strings.Format(totalAmount, "C");
            txtOrignalAmount.Text = Strings.Format(orderAmount, "C");
            Calculate_Tax();
        }

        private void Calculate_Tax()
        {
            double supplierInvoiceAmount = Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", ""));
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTaxCode)) == 0)
            {
                txtVAT.Text = Strings.Format(0, "C");
            }
            else
            {
                try
                {
                    txtVAT.Text = Strings.Format(supplierInvoiceAmount * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboTaxCode))).PercentageRate / 100), "C");
                }
                catch (Exception ex)
                {
                    txtVAT.Text = Strings.Format(0, "C");
                }
            }
        }

        private void Save()
        {
            try
            {
                string err = "";
                if (txtSupplierCreditRef.Text.Length == 0)
                {
                    err += "Suppplier Credit Ref Missing" + Constants.vbCrLf;
                }

                if (txtNominalCode.Text.Length == 0)
                {
                    err += "Nominal Code Missing" + Constants.vbCrLf;
                }

                if (txtDepartment.Text.Length == 0)
                {
                    err += "Department Missing" + Constants.vbCrLf;
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTaxCode)) == 0)
                {
                    err += "Tax Code Missing" + Constants.vbCrLf;
                }

                if (Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", "")) == 0)
                {
                    err += "Amount must be greater than zero" + Constants.vbCrLf;
                }

                if (err.Length > 0)
                {
                    App.ShowMessage(err, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                App.DB.PartsToBeCredited.PartCredits_Update(PartCreditsID, Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", "")), txtnotes.Text, dtpDateReceived.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboTaxCode)), txtNominalCode.Text, txtDepartment.Text, txtExtraRef.Text, txtSupplierCreditRef.Text);






                foreach (DataRow dr in CreditsDataview.Table.Rows)
                {
                    var oPartToCredit = App.DB.PartsToBeCredited.PartsToBeCredited_Get(Conversions.ToInteger(dr["PartsToBeCreditedID"]));
                    oPartToCredit.SetCreditReceived = Entity.Sys.Helper.MakeDoubleValid(dr["CreditReceived"]);
                    oPartToCredit.SetStatusID = Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Received);
                    App.DB.PartsToBeCredited.Update(oPartToCredit);
                }

                App.ShowMessage("Credit Saved ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}