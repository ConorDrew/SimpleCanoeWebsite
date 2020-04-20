using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMSelectAMonth
    {
        public FRMSelectAMonth()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}