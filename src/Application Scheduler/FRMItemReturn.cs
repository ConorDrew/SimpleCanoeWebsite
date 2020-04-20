using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMItemReturn
    {
        public FRMItemReturn()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)
            {
                App.ShowMessage("Please select an option", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 2 & TextBox2.Text.Length < 2)
            {
                App.ShowMessage("Please enter a location to return / collect from", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            nr = newDt.NewRow();
            nr["ManagerID"] = 0;
            nr["Name"] = " - Please Select - ";
            newDt.Rows.Add(nr);
            nr = newDt.NewRow();
            nr["ManagerID"] = 1;
            nr["Name"] = " Original Engineer To return Parts to supplier as not needed ";
            newDt.Rows.Add(nr);
            nr = newDt.NewRow();
            nr["ManagerID"] = 2;
            nr["Name"] = " Original Engineer to Return Parts to the below location ready for the next engineer to pick up. ";
            newDt.Rows.Add(nr);
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, newDt, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
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