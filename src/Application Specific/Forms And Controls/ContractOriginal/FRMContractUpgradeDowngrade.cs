using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMContractUpgradeDowngrade
    {
        public FRMContractUpgradeDowngrade()
        {
            InitializeComponent();
        }

        private DateTime _EffDate = DateTime.MinValue;

        public DateTime EffDate
        {
            get
            {
                return _EffDate;
            }

            set
            {
                _EffDate = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EffDate = dtpEffDate.Value;
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

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
            dtpEffDate.Value = DateAndTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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