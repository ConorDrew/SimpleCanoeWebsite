using System;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;

namespace FSM
{
    public partial class FRMCostCentre : FRMBaseForm, IForm
    {
        public FRMCostCentre()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Helper.MakeIntegerValid(get_GetParameter(0));
            LoadForm(sender, e, this);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc = cboContractCode;
                        Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc1 = cboContractCode;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
            ID = newID;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMLastServiceDate_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboContractCode));
            if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) <= 0)
            {
                Interaction.MsgBox("Please Select a Contract Code");
                return;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}