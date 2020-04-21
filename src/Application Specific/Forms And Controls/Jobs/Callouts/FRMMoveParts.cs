using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMMoveParts
    {
        public FRMMoveParts()
        {
            InitializeComponent();
        }

        private int _EngineerVisitId;

        public int EngineerVisitId
        {
            get
            {
                return _EngineerVisitId;
            }

            set
            {
                _EngineerVisitId = value;
            }
        }

        private string _jobNumber;

        public string JobNumber
        {
            get
            {
                return _jobNumber;
            }

            set
            {
                _jobNumber = value;
            }
        }

        private bool changeJob = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVisit)) == 0)
            {
                App.ShowMessage("Please select a Visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var argcombo = cboVisit;
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

        private void FRMMoveParts_Load(object sender, EventArgs e)
        {
            txtJobNumber.Text = JobNumber;
            UpdateVisitList(EngineerVisitId, false);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (changeJob)
            {
                string jobNo = Helper.MakeStringValid(txtJobNumber.Text).Trim();
                var visit = App.DB.EngineerVisits.EngineerVisits_Get_LastForJob(0, jobNo);
                if (visit is null)
                {
                    App.ShowMessage("No Job Found!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    UpdateVisitList(visit.EngineerVisitID, true);
                }
            }
            else
            {
                changeJob = true;
                txtJobNumber.Enabled = true;
                btnChange.Text = "Search";
                cboVisit.Enabled = false;
            }
        }

        private void UpdateVisitList(int visitId, bool includeCurrentVisit)
        {
            var dt = App.DB.EngineerVisits.GetFutureVisits(visitId, includeCurrentVisit);
            var newDt = new DataTable();
            newDt.Columns.Add("ManagerID");
            newDt.Columns.Add("Name");
            DataRow nr;
            foreach (DataRow r in dt.Rows)
            {
                nr = newDt.NewRow();
                nr["ManagerID"] = r["EngineerVisitID"];
                nr["Name"] = Conversions.ToString(Conversions.ToString(Conversions.ToString(r["EngineerVisitID"] + " - ") + r["Engineer"] + " - ") + r["DateTime"] + " - ") + r["Notes"];
                newDt.Rows.Add(nr);
            }

            var argc = cboVisit;
            Combo.SetUpCombo(ref argc, newDt, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            txtJobNumber.Enabled = false;
            cboVisit.Enabled = true;
            btnChange.Text = "Change";
            changeJob = false;
        }
    }
}