using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMGenDropBox
    {
        public FRMGenDropBox()
        {
            InitializeComponent();
        }

        public bool IncDD = true;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbo1.Visible & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbo1)) == 0)
            {
                App.ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbo2.Visible & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbo2)) == 0)
            {
                App.ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtref.Visible & txtref.Text.Length == 0)
            {
                App.ShowMessage("Please enter a payment reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
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

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
            var argc = cbo1;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cbo1;
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