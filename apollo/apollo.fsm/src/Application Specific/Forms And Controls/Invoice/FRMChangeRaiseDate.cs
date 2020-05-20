using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMChangeRaiseDate : FRMBaseForm, IForm
    {
        public FRMChangeRaiseDate()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            dtpTaxDate.Enabled = false;
            btnSave.Enabled = false;
        }

        private int typeID;

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (Entity.Sys.Helper.HashPassword("boiler123") ?? ""))
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

        
    }
}