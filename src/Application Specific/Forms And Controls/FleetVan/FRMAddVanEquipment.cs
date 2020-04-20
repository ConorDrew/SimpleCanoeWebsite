using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMAddVanEquipment
    {
        public FRMAddVanEquipment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEquipment)) == 0)
            {
                App.ShowMessage("Please select equipment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FRMAddVanEquipment_Load(object sender, EventArgs e)
        {
            var argc = cboEquipment;
            Combo.SetUpCombo(ref argc, App.DB.FleetEquipment.GetAll().Table, "EquipmentID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }
    }
}