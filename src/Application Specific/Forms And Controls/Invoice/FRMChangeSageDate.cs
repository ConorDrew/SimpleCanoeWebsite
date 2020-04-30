using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMChangeSageDate : FRMBaseForm, IForm
    {
        public FRMChangeSageDate()
        {
            InitializeComponent();
        }

        

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

        
        

        private void FRMChangeInvoicedTotal_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);

            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.AccountPeriod))
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            App.DB.ExecuteScalar("UPDATE tblpicklists SET Name = '" + Strings.Format(dtpTaxDate.Value, "yyyy-MM-dd") + "' where enumtypeid = 69", false, true);
            DialogResult = DialogResult.OK;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        
    }
}