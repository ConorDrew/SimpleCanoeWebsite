using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMLastServiceDate : FRMBaseForm, IForm
    {
        public FRMLastServiceDate()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
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

        
        

        private void FRMLastServiceDate_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            var oSite = App.DB.Sites.Get(ID);
            if (oSite is object && oSite.Exists)
            {
                if (oSite.LastServiceDate != default)
                {
                    dtpLastServiceDate.Value = oSite.LastServiceDate.AddYears(1);
                    dtpActualServiceDate.Value = oSite.LastServiceDate;
                }

                if (oSite.ActualServiceDate != default)
                {
                    dtpActualServiceDate.Value = oSite.ActualServiceDate;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            App.DB.Sites.Site_UpdateLastServiceDate(ID, dtpLastServiceDate.Value.AddYears(-1), dtpActualServiceDate.Value, true);
            DialogResult = DialogResult.OK;
        }

        
    }
}