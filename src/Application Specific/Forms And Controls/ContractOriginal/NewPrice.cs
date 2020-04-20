using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public partial class FRMNewPrice
    {
        public FRMNewPrice()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtPrice.Text) & txtPrice.Text.Length < 1)
            {
                App.ShowMessage("Please enter a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Modal)
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtPrice.Text = "0";
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