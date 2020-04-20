using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMSelectDatabase
    {
        public FRMSelectDatabase()
        {
            InitializeComponent();
        }

        private int _selectdDb = 0;
        private Button _btnOk;

        internal Button btnOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOk != null)
                {
                    _btnOk.Click -= btnOk_Click;
                }

                _btnOk = value;
                if (_btnOk != null)
                {
                    _btnOk.Click += btnOk_Click;
                }
            }
        }

        public int SelectedDb
        {
            get
            {
                return _selectdDb;
            }

            set
            {
                _selectdDb = value;
            }
        }

        private void FRMSelectDatabase_Load(object sender, EventArgs e)
        {
            var argc = cboDatabase;
            Combo.SetUpCombo(ref argc, Databases, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDatabase)) == 0) // oppps
            {
                Interaction.MsgBox("Please a database to use", (MsgBoxStyle)MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectedDb = (int)(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDatabase)) - 1); // take care of 0 actually being please select but is row 0 also
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