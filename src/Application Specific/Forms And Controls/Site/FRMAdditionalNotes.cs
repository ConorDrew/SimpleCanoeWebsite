using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FrmAdditionalNotes : FRMBaseForm, IForm
    {
        public FrmAdditionalNotes()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
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

        private void cboContractCode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}