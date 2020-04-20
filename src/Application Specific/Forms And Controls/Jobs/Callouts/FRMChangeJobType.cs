using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMChangeJobType
    {
        public FRMChangeJobType()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)
            {
                App.ShowMessage("Please select a job type", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FRMChangeJobType_Load(object sender, EventArgs e)
        {
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }
    }
}