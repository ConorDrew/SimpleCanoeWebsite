using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMAddPartToBeCredited : FRMBaseForm, IForm
    {
        public FRMAddPartToBeCredited()
        {
            InitializeComponent();
        }

        public FRMAddPartToBeCredited(int qty) : base()
        {
            InitializeComponent();
            txtQtyAvailable.Text = qty.ToString();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
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
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Entity.Sys.Helper.MakeIntegerValid(txtQtyAvailable.Text) < Entity.Sys.Helper.MakeIntegerValid(txtQtyToReturn.Text))
            {
                App.ShowMessage("Cannot return more than was allocated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}