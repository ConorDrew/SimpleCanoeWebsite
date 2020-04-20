using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMInvoiceExtraDetail
    {
        public FRMInvoiceExtraDetail()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbo)) == 0)
            {
                App.ShowMessage("Please enter a valid VAT Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
            var argc = cbo;
            Combo.SetUpCombo(ref argc, App.DB.VATRatesSQL.VATRates_GetAll_Valid().Table, "VATRATEID", "Description", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cbo;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }
    }
}