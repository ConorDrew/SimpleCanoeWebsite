using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMChangePriority
    {
        public FRMChangePriority()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)
            {
                App.ShowMessage("Please select a priority", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var dt = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JOWPriority).Table;
            var dr = dt.Select("Name<>'RC - Recall'");
            var newDt = dt.Clone();
            DataRow nr;
            foreach (DataRow r in dr)
            {
                nr = newDt.NewRow();
                nr["ManagerID"] = r["ManagerID"];
                nr["Name"] = r["Name"];
                newDt.Rows.Add(nr);
            }

            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, newDt, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }
    }
}