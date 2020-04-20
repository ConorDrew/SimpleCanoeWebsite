using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMManualApp
    {
        public FRMManualApp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInitialPaymentType)) == 0)
            {
                App.ShowMessage("Please select an Appliance type", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var argc = cboInitialPaymentType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ManualApp, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cboInitialPaymentType;
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