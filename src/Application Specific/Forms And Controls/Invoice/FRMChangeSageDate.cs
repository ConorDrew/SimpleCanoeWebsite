using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public partial class FRMChangeSageDate : FRMBaseForm, IForm
    {
        public FRMChangeSageDate()
        {
            InitializeComponent();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            dtpTaxDate.Value = Entity.Sys.Helper.MakeDateTimeValid(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69", false, true));
            LoadForm(sender, e, this);
            dtpTaxDate.Enabled = false;
            btnSave.Enabled = false;
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
        private void FRMChangeInvoicedTotal_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            App.DB.ExecuteScalar("UPDATE tblpicklists SET Name = '" + Strings.Format(dtpTaxDate.Value, "yyyy-MM-dd") + "' where enumtypeid = 69", false, true);
            DialogResult = DialogResult.OK;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword_Service ?? ""))
            {
                dtpTaxDate.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                dtpTaxDate.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}