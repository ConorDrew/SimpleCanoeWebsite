using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMChangePaymentTerms : FRMBaseForm, IForm
    {
        public FRMChangePaymentTerms()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            // txtInvoicedTotal.Text = Entity.Sys.Helper.MakeDoubleValid(GetParameter(1))
            LoadForm(sender, e, this);
            var argc = cboPaymentTerm;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboPaidBy;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
            ID = newID;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMChangeInvoicedTotal_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentTerm)) > 0)
            {
                int PaidBy = 0;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaidBy)) > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentTerm)) == 69491)
                {
                    PaidBy = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaidBy));
                }

                App.DB.InvoicedLines.Invoiced_ChangeTerm(ID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentTerm)), PaidBy);
                DialogResult = DialogResult.OK;
            }
            else
            {
                App.ShowMessage("Please Select a Term", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword_Service ?? ""))
            {
                cboPaymentTerm.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                cboPaymentTerm.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private void cboPaymentTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentTerm)) == (double)Entity.Sys.Enums.QuoteJobOfWorkTypes.Reciept)
            {
                lblPaidBy.Visible = true;
                cboPaidBy.Visible = true;
            }
            else
            {
                lblPaidBy.Visible = false;
                cboPaidBy.Visible = false;
            }
        }
    }
}