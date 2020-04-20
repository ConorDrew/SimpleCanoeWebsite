using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMChangeInvoicedTotal : FRMBaseForm, IForm
    {
        public FRMChangeInvoicedTotal()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            txtInvoicedTotal.Text = Entity.Sys.Helper.MakeDoubleValid(get_GetParameter(1)).ToString();
            txtAccount.Text = Entity.Sys.Helper.MakeStringValid(get_GetParameter(2));
            txtDept.Text = Entity.Sys.Helper.MakeStringValid(get_GetParameter(3));
            txtNominal.Text = Entity.Sys.Helper.MakeStringValid(get_GetParameter(4));
            dtpTaxDate.Value = Entity.Sys.Helper.MakeDateTimeValid(get_GetParameter(5));
            typeID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(6));
            LoadForm(sender, e, this);
            txtInvoicedTotal.Enabled = false;
            txtNominal.Enabled = false;
            txtDept.Enabled = false;
            txtAccount.Enabled = false;
            dtpTaxDate.Enabled = false;
            btnSave.Enabled = false;
        }

        private int typeID;

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
            if (txtInvoicedTotal.Text.Replace("£", "").Length > 0 & Information.IsNumeric(txtInvoicedTotal.Text.Replace("£", "")))
            {
                App.DB.InvoicedLines.InvoicedLinesTotal_Change(ID, Conversions.ToDouble(txtInvoicedTotal.Text.Replace("£", "")));
                App.DB.InvoicedLines.InvoicedLinesTotal_ChangeInvoiceDetails(ID, txtAccount.Text, txtDept.Text, txtNominal.Text, dtpTaxDate.Value, typeID);
                DialogResult = DialogResult.OK;
            }
            else
            {
                App.ShowMessage("Enter An Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword_Service ?? ""))
            {
                txtInvoicedTotal.Enabled = true;
                txtNominal.Enabled = true;
                txtDept.Enabled = true;
                txtAccount.Enabled = true;
                dtpTaxDate.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                txtInvoicedTotal.Enabled = false;
                txtNominal.Enabled = false;
                txtDept.Enabled = false;
                txtAccount.Enabled = false;
                dtpTaxDate.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}