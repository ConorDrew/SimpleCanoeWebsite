using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMSmokeComo
    {
        public FRMSmokeComo()
        {
            InitializeComponent();
        }

        public int AdditionalID = 0;
        public int EngineerVisitID = 0;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPower)) == 0)
            {
                App.ShowMessage("Please select a Power Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDateType)) == 0)
            {
                App.ShowMessage("Please select a Date Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDetType)) == 0)
            {
                App.ShowMessage("Please select a Detector Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtLocation.Text.Length == 0)
            {
                App.ShowMessage("Please enter a Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var additional = new Entity.EngineerVisitAdditionals.EngineerVisitAdditional();
                if (chkNA.Checked)
                {
                    additional.SetTest11 = "Not Known";
                }
                else
                {
                    additional.SetTest11 = dtpDate.Value.ToString("d MMM yyyy");
                }

                additional.SetEngineerVisitID = EngineerVisitID;
                additional.SetTest1 = 386;
                additional.SetTestTypeID = Combo.get_GetSelectedItemValue(cboDetType);
                additional.SetTest2 = Combo.get_GetSelectedItemValue(cboPower);
                additional.SetTest12 = Combo.get_GetSelectedItemDescription(cboDateType);
                additional.SetTest13 = txtLocation.Text;
                additional.SetEngineerVisitAdditionalID = AdditionalID;
                if (AdditionalID == 0)
                {
                    App.DB.EngineerVisitAdditional.Insert(additional);
                }
                else
                {
                    App.DB.EngineerVisitAdditional.Update(additional);
                }

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
        }

        private void chkNA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNA.Checked)
            {
                dtpDate.Enabled = false;
            }
            else
            {
                dtpDate.Enabled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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