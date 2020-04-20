using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMPaidBy
    {
        public FRMPaidBy()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDDPaid)) == 0)
            {
                App.ShowMessage("Please enter a valid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var argc = cboDDPaid;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PaymentMethods).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cboDDPaid;
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