using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public partial class FRMPOInvoiceAuthReasons : FRMBaseForm, IForm
    {
        public FRMPOInvoiceAuthReasons()
        {
            InitializeComponent();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
        }

        public void ResetMe(int newID)
        {
        }
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string _AuthReason;

        public string AuthReason
        {
            get
            {
                string AuthReasonRet = default;
                return AuthReasonRet;
            }

            set
            {

                // Me.MinimumSize = New Size(New Point(704, 392))

                _AuthReason = value;
                // SetupDG()
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

                // Me.MinimumSize = Me.Size
            }
        }

        public string _AuthReasonDetail;

        public string AuthReasonDetail
        {
            get
            {
                string AuthReasonDetailRet = default;
                return AuthReasonDetailRet;
            }

            set
            {

                // Me.MinimumSize = New Size(New Point(704, 392))

                _AuthReasonDetail = value;
                // SetupDG()
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

                // Me.MinimumSize = Me.Size
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (AuthReasonOption3.Checked == true & string.IsNullOrEmpty(txtAuthReasonOther.Text))
            {
                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "When selecting other you must enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void AuthReasonOption1_CheckedChanged(object sender, EventArgs e)
        {
            _AuthReason = AuthReasonOption1.Text;
        }

        private void AuthReasonOption2_CheckedChanged(object sender, EventArgs e)
        {
            _AuthReason = AuthReasonOption2.Text;
        }

        private void AuthReasonOption3_CheckedChanged(object sender, EventArgs e)
        {
            _AuthReason = AuthReasonOption3.Text;
        }

        private void txtAuthReasonOther_TextChanged(object sender, EventArgs e)
        {
            _AuthReasonDetail = txtAuthReasonOther.Text;
        }
    }
}