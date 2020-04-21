using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGVisitAdditionalWorkSheet : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DLGVisitAdditionalWorkSheet() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += DLGVisitAssetWorkSheet_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private Label _lblcbo1;

        internal Label lblcbo1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo1 != null)
                {
                }

                _lblcbo1 = value;
                if (_lblcbo1 != null)
                {
                }
            }
        }

        private Label _lbltxt1;

        internal Label lbltxt1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt1 != null)
                {
                }

                _lbltxt1 = value;
                if (_lbltxt1 != null)
                {
                }
            }
        }

        private TextBox _txt1;

        internal TextBox txt1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt1 != null)
                {
                }

                _txt1 = value;
                if (_txt1 != null)
                {
                }
            }
        }

        private ComboBox _cbo1;

        internal ComboBox cbo1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo1 != null)
                {
                }

                _cbo1 = value;
                if (_cbo1 != null)
                {
                }
            }
        }

        private Label _lbltxt2;

        internal Label lbltxt2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt2 != null)
                {
                }

                _lbltxt2 = value;
                if (_lbltxt2 != null)
                {
                }
            }
        }

        private TextBox _txt2;

        internal TextBox txt2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt2 != null)
                {
                }

                _txt2 = value;
                if (_txt2 != null)
                {
                }
            }
        }

        private ComboBox _cbo2;

        internal ComboBox cbo2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo2 != null)
                {
                }

                _cbo2 = value;
                if (_cbo2 != null)
                {
                }
            }
        }

        private Label _lblcbo2;

        internal Label lblcbo2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo2 != null)
                {
                }

                _lblcbo2 = value;
                if (_lblcbo2 != null)
                {
                }
            }
        }

        private ComboBox _cbo3;

        internal ComboBox cbo3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo3 != null)
                {
                }

                _cbo3 = value;
                if (_cbo3 != null)
                {
                }
            }
        }

        private Label _lblcbo3;

        internal Label lblcbo3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo3 != null)
                {
                }

                _lblcbo3 = value;
                if (_lblcbo3 != null)
                {
                }
            }
        }

        private ComboBox _cbo4;

        internal ComboBox cbo4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo4 != null)
                {
                }

                _cbo4 = value;
                if (_cbo4 != null)
                {
                }
            }
        }

        private Label _lblcbo4;

        internal Label lblcbo4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo4 != null)
                {
                }

                _lblcbo4 = value;
                if (_lblcbo4 != null)
                {
                }
            }
        }

        private ComboBox _cbo5;

        internal ComboBox cbo5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo5 != null)
                {
                }

                _cbo5 = value;
                if (_cbo5 != null)
                {
                }
            }
        }

        private Label _lblcbo5;

        internal Label lblcbo5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo5 != null)
                {
                }

                _lblcbo5 = value;
                if (_lblcbo5 != null)
                {
                }
            }
        }

        private ComboBox _cbo6;

        internal ComboBox cbo6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo6 != null)
                {
                }

                _cbo6 = value;
                if (_cbo6 != null)
                {
                }
            }
        }

        private Label _lblcbo6;

        internal Label lblcbo6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo6 != null)
                {
                }

                _lblcbo6 = value;
                if (_lblcbo6 != null)
                {
                }
            }
        }

        private ComboBox _cbo7;

        internal ComboBox cbo7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo7 != null)
                {
                }

                _cbo7 = value;
                if (_cbo7 != null)
                {
                }
            }
        }

        private Label _lblcbo7;

        internal Label lblcbo7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo7 != null)
                {
                }

                _lblcbo7 = value;
                if (_lblcbo7 != null)
                {
                }
            }
        }

        private ComboBox _cbo8;

        internal ComboBox cbo8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo8 != null)
                {
                }

                _cbo8 = value;
                if (_cbo8 != null)
                {
                }
            }
        }

        private Label _lblcbo8;

        internal Label lblcbo8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo8 != null)
                {
                }

                _lblcbo8 = value;
                if (_lblcbo8 != null)
                {
                }
            }
        }

        private ComboBox _cbo9;

        internal ComboBox cbo9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo9 != null)
                {
                }

                _cbo9 = value;
                if (_cbo9 != null)
                {
                }
            }
        }

        private Label _lblcbo9;

        internal Label lblcbo9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo9 != null)
                {
                }

                _lblcbo9 = value;
                if (_lblcbo9 != null)
                {
                }
            }
        }

        private ComboBox _cbo10;

        internal ComboBox cbo10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo10 != null)
                {
                }

                _cbo10 = value;
                if (_cbo10 != null)
                {
                }
            }
        }

        private Label _lblcbo10;

        internal Label lblcbo10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo10 != null)
                {
                }

                _lblcbo10 = value;
                if (_lblcbo10 != null)
                {
                }
            }
        }

        private ComboBox _cbo11;

        internal ComboBox cbo11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo11 != null)
                {
                }

                _cbo11 = value;
                if (_cbo11 != null)
                {
                }
            }
        }

        private Label _lblcbo11;

        internal Label lblcbo11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo11 != null)
                {
                }

                _lblcbo11 = value;
                if (_lblcbo11 != null)
                {
                }
            }
        }

        private ComboBox _cbo12;

        internal ComboBox cbo12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo12 != null)
                {
                }

                _cbo12 = value;
                if (_cbo12 != null)
                {
                }
            }
        }

        private Label _lblcbo12;

        internal Label lblcbo12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo12 != null)
                {
                }

                _lblcbo12 = value;
                if (_lblcbo12 != null)
                {
                }
            }
        }

        private ComboBox _cbo13;

        internal ComboBox cbo13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo13 != null)
                {
                }

                _cbo13 = value;
                if (_cbo13 != null)
                {
                }
            }
        }

        private Label _lblcbo13;

        internal Label lblcbo13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo13 != null)
                {
                }

                _lblcbo13 = value;
                if (_lblcbo13 != null)
                {
                }
            }
        }

        private ComboBox _cbo14;

        internal ComboBox cbo14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo14 != null)
                {
                }

                _cbo14 = value;
                if (_cbo14 != null)
                {
                }
            }
        }

        private Label _lblcbo14;

        internal Label lblcbo14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo14 != null)
                {
                }

                _lblcbo14 = value;
                if (_lblcbo14 != null)
                {
                }
            }
        }

        private ComboBox _cbo15;

        internal ComboBox cbo15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo15 != null)
                {
                }

                _cbo15 = value;
                if (_cbo15 != null)
                {
                }
            }
        }

        private Label _lblcbo15;

        internal Label lblcbo15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo15 != null)
                {
                }

                _lblcbo15 = value;
                if (_lblcbo15 != null)
                {
                }
            }
        }

        private ComboBox _cbo16;

        internal ComboBox cbo16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo16 != null)
                {
                }

                _cbo16 = value;
                if (_cbo16 != null)
                {
                }
            }
        }

        private Label _lblcbo16;

        internal Label lblcbo16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo16 != null)
                {
                }

                _lblcbo16 = value;
                if (_lblcbo16 != null)
                {
                }
            }
        }

        private ComboBox _cbo17;

        internal ComboBox cbo17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo17 != null)
                {
                }

                _cbo17 = value;
                if (_cbo17 != null)
                {
                }
            }
        }

        private Label _lblcbo17;

        internal Label lblcbo17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo17 != null)
                {
                }

                _lblcbo17 = value;
                if (_lblcbo17 != null)
                {
                }
            }
        }

        private ComboBox _cbo18;

        internal ComboBox cbo18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo18 != null)
                {
                }

                _cbo18 = value;
                if (_cbo18 != null)
                {
                }
            }
        }

        private Label _lblcbo18;

        internal Label lblcbo18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo18 != null)
                {
                }

                _lblcbo18 = value;
                if (_lblcbo18 != null)
                {
                }
            }
        }

        private Label _lbltxt3;

        internal Label lbltxt3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt3 != null)
                {
                }

                _lbltxt3 = value;
                if (_lbltxt3 != null)
                {
                }
            }
        }

        private TextBox _txt3;

        internal TextBox txt3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt3 != null)
                {
                }

                _txt3 = value;
                if (_txt3 != null)
                {
                }
            }
        }

        private Label _lbltxt4;

        internal Label lbltxt4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt4 != null)
                {
                }

                _lbltxt4 = value;
                if (_lbltxt4 != null)
                {
                }
            }
        }

        private TextBox _txt4;

        internal TextBox txt4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt4 != null)
                {
                }

                _txt4 = value;
                if (_txt4 != null)
                {
                }
            }
        }

        private Label _lbltxt5;

        internal Label lbltxt5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt5 != null)
                {
                }

                _lbltxt5 = value;
                if (_lbltxt5 != null)
                {
                }
            }
        }

        private TextBox _txt5;

        internal TextBox txt5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt5 != null)
                {
                }

                _txt5 = value;
                if (_txt5 != null)
                {
                }
            }
        }

        private Label _lbltxt6;

        internal Label lbltxt6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt6 != null)
                {
                }

                _lbltxt6 = value;
                if (_lbltxt6 != null)
                {
                }
            }
        }

        private TextBox _txt6;

        internal TextBox txt6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt6 != null)
                {
                }

                _txt6 = value;
                if (_txt6 != null)
                {
                }
            }
        }

        private Label _lbltxt7;

        internal Label lbltxt7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt7 != null)
                {
                }

                _lbltxt7 = value;
                if (_lbltxt7 != null)
                {
                }
            }
        }

        private TextBox _txt7;

        internal TextBox txt7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt7 != null)
                {
                }

                _txt7 = value;
                if (_txt7 != null)
                {
                }
            }
        }

        private Label _lbltxt8;

        internal Label lbltxt8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt8 != null)
                {
                }

                _lbltxt8 = value;
                if (_lbltxt8 != null)
                {
                }
            }
        }

        private TextBox _txt8;

        internal TextBox txt8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt8 != null)
                {
                }

                _txt8 = value;
                if (_txt8 != null)
                {
                }
            }
        }

        private Label _lbltxt9;

        internal Label lbltxt9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt9 != null)
                {
                }

                _lbltxt9 = value;
                if (_lbltxt9 != null)
                {
                }
            }
        }

        private TextBox _txt9;

        internal TextBox txt9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt9 != null)
                {
                }

                _txt9 = value;
                if (_txt9 != null)
                {
                }
            }
        }

        private Label _lbltxt10;

        internal Label lbltxt10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt10 != null)
                {
                }

                _lbltxt10 = value;
                if (_lbltxt10 != null)
                {
                }
            }
        }

        private TextBox _txt10;

        internal TextBox txt10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt10 != null)
                {
                }

                _txt10 = value;
                if (_txt10 != null)
                {
                }
            }
        }

        private ComboBox _cbo19;

        internal ComboBox cbo19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo19 != null)
                {
                }

                _cbo19 = value;
                if (_cbo19 != null)
                {
                }
            }
        }

        private Label _lblcbo19;

        internal Label lblcbo19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo19 != null)
                {
                }

                _lblcbo19 = value;
                if (_lblcbo19 != null)
                {
                }
            }
        }

        private ComboBox _cbo20;

        internal ComboBox cbo20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo20 != null)
                {
                }

                _cbo20 = value;
                if (_cbo20 != null)
                {
                }
            }
        }

        private Label _lblcbo20;

        internal Label lblcbo20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcbo20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcbo20 != null)
                {
                }

                _lblcbo20 = value;
                if (_lblcbo20 != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
                }

                _cboType = value;
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Label _lbltxt11;

        internal Label lbltxt11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt11 != null)
                {
                }

                _lbltxt11 = value;
                if (_lbltxt11 != null)
                {
                }
            }
        }

        private TextBox _txt11;

        internal TextBox txt11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt11 != null)
                {
                }

                _txt11 = value;
                if (_txt11 != null)
                {
                }
            }
        }

        private Label _lbltxt12;

        internal Label lbltxt12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltxt12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltxt12 != null)
                {
                }

                _lbltxt12 = value;
                if (_lbltxt12 != null)
                {
                }
            }
        }

        private TextBox _txt12;

        internal TextBox txt12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txt12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txt12 != null)
                {
                }

                _txt12 = value;
                if (_txt12 != null)
                {
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _lblcbo1 = new Label();
            _lbltxt1 = new Label();
            _txt1 = new TextBox();
            _cbo1 = new ComboBox();
            _lbltxt2 = new Label();
            _txt2 = new TextBox();
            _cbo2 = new ComboBox();
            _lblcbo2 = new Label();
            _cbo3 = new ComboBox();
            _lblcbo3 = new Label();
            _cbo4 = new ComboBox();
            _lblcbo4 = new Label();
            _cbo5 = new ComboBox();
            _lblcbo5 = new Label();
            _cbo6 = new ComboBox();
            _lblcbo6 = new Label();
            _cbo7 = new ComboBox();
            _lblcbo7 = new Label();
            _cbo8 = new ComboBox();
            _lblcbo8 = new Label();
            _cbo9 = new ComboBox();
            _lblcbo9 = new Label();
            _cbo10 = new ComboBox();
            _lblcbo10 = new Label();
            _cbo11 = new ComboBox();
            _lblcbo11 = new Label();
            _cbo12 = new ComboBox();
            _lblcbo12 = new Label();
            _cbo13 = new ComboBox();
            _lblcbo13 = new Label();
            _cbo14 = new ComboBox();
            _lblcbo14 = new Label();
            _cbo15 = new ComboBox();
            _lblcbo15 = new Label();
            _cbo16 = new ComboBox();
            _lblcbo16 = new Label();
            _cbo17 = new ComboBox();
            _lblcbo17 = new Label();
            _cbo18 = new ComboBox();
            _lblcbo18 = new Label();
            _lbltxt3 = new Label();
            _txt3 = new TextBox();
            _lbltxt4 = new Label();
            _txt4 = new TextBox();
            _lbltxt5 = new Label();
            _txt5 = new TextBox();
            _lbltxt6 = new Label();
            _txt6 = new TextBox();
            _lbltxt7 = new Label();
            _txt7 = new TextBox();
            _lbltxt8 = new Label();
            _txt8 = new TextBox();
            _lbltxt9 = new Label();
            _txt9 = new TextBox();
            _lbltxt10 = new Label();
            _txt10 = new TextBox();
            _cbo19 = new ComboBox();
            _lblcbo19 = new Label();
            _cbo20 = new ComboBox();
            _lblcbo20 = new Label();
            _cboType = new ComboBox();
            _cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _Label1 = new Label();
            _lbltxt11 = new Label();
            _txt11 = new TextBox();
            _lbltxt12 = new Label();
            _txt12 = new TextBox();
            SuspendLayout();
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(12, 526);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 38;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(902, 526);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 39;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // lblcbo1
            //
            _lblcbo1.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo1.Location = new Point(8, 82);
            _lblcbo1.Name = "lblcbo1";
            _lblcbo1.Size = new Size(285, 23);
            _lblcbo1.TabIndex = 22;
            _lblcbo1.Text = "Heat Input KW/h";
            //
            // lbltxt1
            //
            _lbltxt1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt1.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt1.Location = new Point(508, 81);
            _lbltxt1.Name = "lbltxt1";
            _lbltxt1.Size = new Size(272, 23);
            _lbltxt1.TabIndex = 48;
            _lbltxt1.Text = "Fuel";
            //
            // txt1
            //
            _txt1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt1.Location = new Point(786, 78);
            _txt1.Name = "txt1";
            _txt1.Size = new Size(178, 21);
            _txt1.TabIndex = 23;
            //
            // cbo1
            //
            _cbo1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo1.Location = new Point(310, 79);
            _cbo1.Name = "cbo1";
            _cbo1.Size = new Size(178, 21);
            _cbo1.TabIndex = 47;
            //
            // lbltxt2
            //
            _lbltxt2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt2.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt2.Location = new Point(508, 108);
            _lbltxt2.Name = "lbltxt2";
            _lbltxt2.Size = new Size(272, 23);
            _lbltxt2.TabIndex = 50;
            _lbltxt2.Text = "Fuel";
            //
            // txt2
            //
            _txt2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt2.Location = new Point(786, 105);
            _txt2.Name = "txt2";
            _txt2.Size = new Size(178, 21);
            _txt2.TabIndex = 49;
            //
            // cbo2
            //
            _cbo2.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo2.Location = new Point(310, 106);
            _cbo2.Name = "cbo2";
            _cbo2.Size = new Size(178, 21);
            _cbo2.TabIndex = 52;
            //
            // lblcbo2
            //
            _lblcbo2.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo2.Location = new Point(8, 109);
            _lblcbo2.Name = "lblcbo2";
            _lblcbo2.Size = new Size(285, 23);
            _lblcbo2.TabIndex = 51;
            _lblcbo2.Text = "Heat Input KW/h";
            //
            // cbo3
            //
            _cbo3.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo3.Location = new Point(310, 133);
            _cbo3.Name = "cbo3";
            _cbo3.Size = new Size(178, 21);
            _cbo3.TabIndex = 54;
            //
            // lblcbo3
            //
            _lblcbo3.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo3.Location = new Point(8, 136);
            _lblcbo3.Name = "lblcbo3";
            _lblcbo3.Size = new Size(285, 23);
            _lblcbo3.TabIndex = 53;
            _lblcbo3.Text = "Heat Input KW/h";
            //
            // cbo4
            //
            _cbo4.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo4.Location = new Point(310, 160);
            _cbo4.Name = "cbo4";
            _cbo4.Size = new Size(178, 21);
            _cbo4.TabIndex = 56;
            //
            // lblcbo4
            //
            _lblcbo4.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo4.Location = new Point(8, 163);
            _lblcbo4.Name = "lblcbo4";
            _lblcbo4.Size = new Size(285, 23);
            _lblcbo4.TabIndex = 55;
            _lblcbo4.Text = "Heat Input KW/h";
            //
            // cbo5
            //
            _cbo5.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo5.Location = new Point(310, 187);
            _cbo5.Name = "cbo5";
            _cbo5.Size = new Size(178, 21);
            _cbo5.TabIndex = 58;
            //
            // lblcbo5
            //
            _lblcbo5.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo5.Location = new Point(8, 190);
            _lblcbo5.Name = "lblcbo5";
            _lblcbo5.Size = new Size(285, 23);
            _lblcbo5.TabIndex = 57;
            _lblcbo5.Text = "Heat Input KW/h";
            //
            // cbo6
            //
            _cbo6.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo6.Location = new Point(310, 214);
            _cbo6.Name = "cbo6";
            _cbo6.Size = new Size(178, 21);
            _cbo6.TabIndex = 60;
            //
            // lblcbo6
            //
            _lblcbo6.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo6.Location = new Point(8, 217);
            _lblcbo6.Name = "lblcbo6";
            _lblcbo6.Size = new Size(285, 23);
            _lblcbo6.TabIndex = 59;
            _lblcbo6.Text = "Heat Input KW/h";
            //
            // cbo7
            //
            _cbo7.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo7.Location = new Point(310, 241);
            _cbo7.Name = "cbo7";
            _cbo7.Size = new Size(178, 21);
            _cbo7.TabIndex = 62;
            //
            // lblcbo7
            //
            _lblcbo7.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo7.Location = new Point(8, 244);
            _lblcbo7.Name = "lblcbo7";
            _lblcbo7.Size = new Size(285, 23);
            _lblcbo7.TabIndex = 61;
            _lblcbo7.Text = "Heat Input KW/h";
            //
            // cbo8
            //
            _cbo8.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo8.Location = new Point(310, 268);
            _cbo8.Name = "cbo8";
            _cbo8.Size = new Size(178, 21);
            _cbo8.TabIndex = 64;
            //
            // lblcbo8
            //
            _lblcbo8.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo8.Location = new Point(8, 271);
            _lblcbo8.Name = "lblcbo8";
            _lblcbo8.Size = new Size(285, 23);
            _lblcbo8.TabIndex = 63;
            _lblcbo8.Text = "Heat Input KW/h";
            //
            // cbo9
            //
            _cbo9.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo9.Location = new Point(310, 295);
            _cbo9.Name = "cbo9";
            _cbo9.Size = new Size(178, 21);
            _cbo9.TabIndex = 66;
            //
            // lblcbo9
            //
            _lblcbo9.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo9.Location = new Point(8, 298);
            _lblcbo9.Name = "lblcbo9";
            _lblcbo9.Size = new Size(285, 23);
            _lblcbo9.TabIndex = 65;
            _lblcbo9.Text = "Heat Input KW/h";
            //
            // cbo10
            //
            _cbo10.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo10.Location = new Point(310, 322);
            _cbo10.Name = "cbo10";
            _cbo10.Size = new Size(178, 21);
            _cbo10.TabIndex = 68;
            //
            // lblcbo10
            //
            _lblcbo10.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo10.Location = new Point(8, 325);
            _lblcbo10.Name = "lblcbo10";
            _lblcbo10.Size = new Size(285, 23);
            _lblcbo10.TabIndex = 67;
            _lblcbo10.Text = "Heat Input KW/h";
            //
            // cbo11
            //
            _cbo11.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo11.Location = new Point(310, 349);
            _cbo11.Name = "cbo11";
            _cbo11.Size = new Size(178, 21);
            _cbo11.TabIndex = 70;
            //
            // lblcbo11
            //
            _lblcbo11.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo11.Location = new Point(8, 352);
            _lblcbo11.Name = "lblcbo11";
            _lblcbo11.Size = new Size(285, 23);
            _lblcbo11.TabIndex = 69;
            _lblcbo11.Text = "Heat Input KW/h";
            //
            // cbo12
            //
            _cbo12.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo12.Location = new Point(310, 376);
            _cbo12.Name = "cbo12";
            _cbo12.Size = new Size(178, 21);
            _cbo12.TabIndex = 72;
            //
            // lblcbo12
            //
            _lblcbo12.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo12.Location = new Point(8, 379);
            _lblcbo12.Name = "lblcbo12";
            _lblcbo12.Size = new Size(285, 23);
            _lblcbo12.TabIndex = 71;
            _lblcbo12.Text = "Heat Input KW/h";
            //
            // cbo13
            //
            _cbo13.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo13.Location = new Point(310, 403);
            _cbo13.Name = "cbo13";
            _cbo13.Size = new Size(178, 21);
            _cbo13.TabIndex = 74;
            //
            // lblcbo13
            //
            _lblcbo13.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo13.Location = new Point(8, 406);
            _lblcbo13.Name = "lblcbo13";
            _lblcbo13.Size = new Size(285, 23);
            _lblcbo13.TabIndex = 73;
            _lblcbo13.Text = "Heat Input KW/h";
            //
            // cbo14
            //
            _cbo14.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo14.Location = new Point(310, 430);
            _cbo14.Name = "cbo14";
            _cbo14.Size = new Size(178, 21);
            _cbo14.TabIndex = 76;
            //
            // lblcbo14
            //
            _lblcbo14.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo14.Location = new Point(8, 433);
            _lblcbo14.Name = "lblcbo14";
            _lblcbo14.Size = new Size(285, 23);
            _lblcbo14.TabIndex = 75;
            _lblcbo14.Text = "Heat Input KW/h";
            //
            // cbo15
            //
            _cbo15.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo15.Location = new Point(310, 460);
            _cbo15.Name = "cbo15";
            _cbo15.Size = new Size(178, 21);
            _cbo15.TabIndex = 78;
            //
            // lblcbo15
            //
            _lblcbo15.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo15.Location = new Point(8, 463);
            _lblcbo15.Name = "lblcbo15";
            _lblcbo15.Size = new Size(285, 23);
            _lblcbo15.TabIndex = 77;
            _lblcbo15.Text = "Heat Input KW/h";
            //
            // cbo16
            //
            _cbo16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbo16.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo16.Location = new Point(310, 487);
            _cbo16.Name = "cbo16";
            _cbo16.Size = new Size(178, 21);
            _cbo16.TabIndex = 80;
            //
            // lblcbo16
            //
            _lblcbo16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblcbo16.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo16.Location = new Point(8, 491);
            _lblcbo16.Name = "lblcbo16";
            _lblcbo16.Size = new Size(272, 23);
            _lblcbo16.TabIndex = 79;
            _lblcbo16.Text = "Heat Input KW/h";
            //
            // cbo17
            //
            _cbo17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbo17.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo17.Location = new Point(786, 402);
            _cbo17.Name = "cbo17";
            _cbo17.Size = new Size(178, 21);
            _cbo17.TabIndex = 82;
            //
            // lblcbo17
            //
            _lblcbo17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblcbo17.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo17.Location = new Point(508, 406);
            _lblcbo17.Name = "lblcbo17";
            _lblcbo17.Size = new Size(272, 23);
            _lblcbo17.TabIndex = 81;
            _lblcbo17.Text = "Heat Input KW/h";
            //
            // cbo18
            //
            _cbo18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbo18.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo18.Location = new Point(786, 429);
            _cbo18.Name = "cbo18";
            _cbo18.Size = new Size(178, 21);
            _cbo18.TabIndex = 84;
            //
            // lblcbo18
            //
            _lblcbo18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblcbo18.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo18.Location = new Point(508, 433);
            _lblcbo18.Name = "lblcbo18";
            _lblcbo18.Size = new Size(272, 23);
            _lblcbo18.TabIndex = 83;
            _lblcbo18.Text = "Heat Input KW/h";
            //
            // lbltxt3
            //
            _lbltxt3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt3.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt3.Location = new Point(508, 135);
            _lbltxt3.Name = "lbltxt3";
            _lbltxt3.Size = new Size(272, 23);
            _lbltxt3.TabIndex = 86;
            _lbltxt3.Text = "Fuel";
            //
            // txt3
            //
            _txt3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt3.Location = new Point(786, 132);
            _txt3.Name = "txt3";
            _txt3.Size = new Size(178, 21);
            _txt3.TabIndex = 85;
            //
            // lbltxt4
            //
            _lbltxt4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt4.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt4.Location = new Point(508, 162);
            _lbltxt4.Name = "lbltxt4";
            _lbltxt4.Size = new Size(272, 23);
            _lbltxt4.TabIndex = 88;
            _lbltxt4.Text = "Fuel";
            //
            // txt4
            //
            _txt4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt4.Location = new Point(786, 159);
            _txt4.Name = "txt4";
            _txt4.Size = new Size(178, 21);
            _txt4.TabIndex = 87;
            //
            // lbltxt5
            //
            _lbltxt5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt5.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt5.Location = new Point(508, 189);
            _lbltxt5.Name = "lbltxt5";
            _lbltxt5.Size = new Size(272, 23);
            _lbltxt5.TabIndex = 90;
            _lbltxt5.Text = "Fuel";
            //
            // txt5
            //
            _txt5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt5.Location = new Point(786, 186);
            _txt5.Name = "txt5";
            _txt5.Size = new Size(178, 21);
            _txt5.TabIndex = 89;
            //
            // lbltxt6
            //
            _lbltxt6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt6.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt6.Location = new Point(508, 216);
            _lbltxt6.Name = "lbltxt6";
            _lbltxt6.Size = new Size(272, 23);
            _lbltxt6.TabIndex = 92;
            _lbltxt6.Text = "Fuel";
            //
            // txt6
            //
            _txt6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt6.Location = new Point(786, 213);
            _txt6.Name = "txt6";
            _txt6.Size = new Size(178, 21);
            _txt6.TabIndex = 91;
            //
            // lbltxt7
            //
            _lbltxt7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt7.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt7.Location = new Point(508, 243);
            _lbltxt7.Name = "lbltxt7";
            _lbltxt7.Size = new Size(272, 23);
            _lbltxt7.TabIndex = 94;
            _lbltxt7.Text = "Fuel";
            //
            // txt7
            //
            _txt7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt7.Location = new Point(786, 240);
            _txt7.Name = "txt7";
            _txt7.Size = new Size(178, 21);
            _txt7.TabIndex = 93;
            //
            // lbltxt8
            //
            _lbltxt8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt8.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt8.Location = new Point(508, 270);
            _lbltxt8.Name = "lbltxt8";
            _lbltxt8.Size = new Size(272, 23);
            _lbltxt8.TabIndex = 96;
            _lbltxt8.Text = "Fuel";
            //
            // txt8
            //
            _txt8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt8.Location = new Point(786, 267);
            _txt8.Name = "txt8";
            _txt8.Size = new Size(178, 21);
            _txt8.TabIndex = 95;
            //
            // lbltxt9
            //
            _lbltxt9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt9.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt9.Location = new Point(508, 297);
            _lbltxt9.Name = "lbltxt9";
            _lbltxt9.Size = new Size(272, 23);
            _lbltxt9.TabIndex = 98;
            _lbltxt9.Text = "Fuel";
            //
            // txt9
            //
            _txt9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt9.Location = new Point(786, 294);
            _txt9.Name = "txt9";
            _txt9.Size = new Size(178, 21);
            _txt9.TabIndex = 97;
            //
            // lbltxt10
            //
            _lbltxt10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt10.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt10.Location = new Point(508, 324);
            _lbltxt10.Name = "lbltxt10";
            _lbltxt10.Size = new Size(272, 23);
            _lbltxt10.TabIndex = 100;
            _lbltxt10.Text = "Fuel";
            //
            // txt10
            //
            _txt10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt10.Location = new Point(786, 321);
            _txt10.Name = "txt10";
            _txt10.Size = new Size(178, 21);
            _txt10.TabIndex = 99;
            //
            // cbo19
            //
            _cbo19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbo19.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo19.Location = new Point(786, 456);
            _cbo19.Name = "cbo19";
            _cbo19.Size = new Size(178, 21);
            _cbo19.TabIndex = 102;
            //
            // lblcbo19
            //
            _lblcbo19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblcbo19.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo19.Location = new Point(508, 459);
            _lblcbo19.Name = "lblcbo19";
            _lblcbo19.Size = new Size(272, 23);
            _lblcbo19.TabIndex = 101;
            _lblcbo19.Text = "Heat Input KW/h";
            //
            // cbo20
            //
            _cbo20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbo20.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo20.Location = new Point(786, 483);
            _cbo20.Name = "cbo20";
            _cbo20.Size = new Size(178, 21);
            _cbo20.TabIndex = 104;
            //
            // lblcbo20
            //
            _lblcbo20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblcbo20.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblcbo20.Location = new Point(508, 486);
            _lblcbo20.Name = "lblcbo20";
            _lblcbo20.Size = new Size(272, 23);
            _lblcbo20.TabIndex = 103;
            _lblcbo20.Text = "Heat Input KW/h";
            //
            // cboType
            //
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(310, 38);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(654, 21);
            _cboType.TabIndex = 106;
            //
            // Label1
            //
            _Label1.Location = new Point(7, 41);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(136, 23);
            _Label1.TabIndex = 105;
            _Label1.Text = "Worsheet type";
            //
            // lbltxt11
            //
            _lbltxt11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt11.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt11.Location = new Point(508, 352);
            _lbltxt11.Name = "lbltxt11";
            _lbltxt11.Size = new Size(272, 23);
            _lbltxt11.TabIndex = 109;
            _lbltxt11.Text = "Fuel";
            //
            // txt11
            //
            _txt11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt11.Location = new Point(786, 349);
            _txt11.Name = "txt11";
            _txt11.Size = new Size(178, 21);
            _txt11.TabIndex = 108;
            //
            // lbltxt12
            //
            _lbltxt12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbltxt12.Font = new Font("Verdana", 6.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lbltxt12.Location = new Point(508, 379);
            _lbltxt12.Name = "lbltxt12";
            _lbltxt12.Size = new Size(272, 23);
            _lbltxt12.TabIndex = 111;
            _lbltxt12.Text = "Fuel";
            //
            // txt12
            //
            _txt12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txt12.Location = new Point(786, 376);
            _txt12.Name = "txt12";
            _txt12.Size = new Size(178, 21);
            _txt12.TabIndex = 110;
            //
            // DLGVisitAdditionalWorkSheet
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(989, 561);
            ControlBox = false;
            Controls.Add(_lbltxt12);
            Controls.Add(_txt12);
            Controls.Add(_lbltxt11);
            Controls.Add(_txt11);
            Controls.Add(_cboType);
            Controls.Add(_Label1);
            Controls.Add(_cbo20);
            Controls.Add(_lblcbo20);
            Controls.Add(_cbo19);
            Controls.Add(_lblcbo19);
            Controls.Add(_lbltxt10);
            Controls.Add(_txt10);
            Controls.Add(_lbltxt9);
            Controls.Add(_txt9);
            Controls.Add(_lbltxt8);
            Controls.Add(_txt8);
            Controls.Add(_lbltxt7);
            Controls.Add(_txt7);
            Controls.Add(_lbltxt6);
            Controls.Add(_txt6);
            Controls.Add(_lbltxt5);
            Controls.Add(_txt5);
            Controls.Add(_lbltxt4);
            Controls.Add(_txt4);
            Controls.Add(_lbltxt3);
            Controls.Add(_txt3);
            Controls.Add(_cbo18);
            Controls.Add(_lblcbo18);
            Controls.Add(_cbo17);
            Controls.Add(_lblcbo17);
            Controls.Add(_cbo16);
            Controls.Add(_lblcbo16);
            Controls.Add(_cbo15);
            Controls.Add(_lblcbo15);
            Controls.Add(_cbo14);
            Controls.Add(_lblcbo14);
            Controls.Add(_cbo13);
            Controls.Add(_lblcbo13);
            Controls.Add(_cbo12);
            Controls.Add(_lblcbo12);
            Controls.Add(_cbo11);
            Controls.Add(_lblcbo11);
            Controls.Add(_cbo10);
            Controls.Add(_lblcbo10);
            Controls.Add(_cbo9);
            Controls.Add(_lblcbo9);
            Controls.Add(_cbo8);
            Controls.Add(_lblcbo8);
            Controls.Add(_cbo7);
            Controls.Add(_lblcbo7);
            Controls.Add(_cbo6);
            Controls.Add(_lblcbo6);
            Controls.Add(_cbo5);
            Controls.Add(_lblcbo5);
            Controls.Add(_cbo4);
            Controls.Add(_lblcbo4);
            Controls.Add(_cbo3);
            Controls.Add(_lblcbo3);
            Controls.Add(_cbo2);
            Controls.Add(_lblcbo2);
            Controls.Add(_lbltxt2);
            Controls.Add(_txt2);
            Controls.Add(_lbltxt1);
            Controls.Add(_cbo1);
            Controls.Add(_txt1);
            Controls.Add(_lblcbo1);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            MinimumSize = new Size(1000, 600);
            Name = "DLGVisitAdditionalWorkSheet";
            Text = "Appliance Work Sheet";
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_lblcbo1, 0);
            Controls.SetChildIndex(_txt1, 0);
            Controls.SetChildIndex(_cbo1, 0);
            Controls.SetChildIndex(_lbltxt1, 0);
            Controls.SetChildIndex(_txt2, 0);
            Controls.SetChildIndex(_lbltxt2, 0);
            Controls.SetChildIndex(_lblcbo2, 0);
            Controls.SetChildIndex(_cbo2, 0);
            Controls.SetChildIndex(_lblcbo3, 0);
            Controls.SetChildIndex(_cbo3, 0);
            Controls.SetChildIndex(_lblcbo4, 0);
            Controls.SetChildIndex(_cbo4, 0);
            Controls.SetChildIndex(_lblcbo5, 0);
            Controls.SetChildIndex(_cbo5, 0);
            Controls.SetChildIndex(_lblcbo6, 0);
            Controls.SetChildIndex(_cbo6, 0);
            Controls.SetChildIndex(_lblcbo7, 0);
            Controls.SetChildIndex(_cbo7, 0);
            Controls.SetChildIndex(_lblcbo8, 0);
            Controls.SetChildIndex(_cbo8, 0);
            Controls.SetChildIndex(_lblcbo9, 0);
            Controls.SetChildIndex(_cbo9, 0);
            Controls.SetChildIndex(_lblcbo10, 0);
            Controls.SetChildIndex(_cbo10, 0);
            Controls.SetChildIndex(_lblcbo11, 0);
            Controls.SetChildIndex(_cbo11, 0);
            Controls.SetChildIndex(_lblcbo12, 0);
            Controls.SetChildIndex(_cbo12, 0);
            Controls.SetChildIndex(_lblcbo13, 0);
            Controls.SetChildIndex(_cbo13, 0);
            Controls.SetChildIndex(_lblcbo14, 0);
            Controls.SetChildIndex(_cbo14, 0);
            Controls.SetChildIndex(_lblcbo15, 0);
            Controls.SetChildIndex(_cbo15, 0);
            Controls.SetChildIndex(_lblcbo16, 0);
            Controls.SetChildIndex(_cbo16, 0);
            Controls.SetChildIndex(_lblcbo17, 0);
            Controls.SetChildIndex(_cbo17, 0);
            Controls.SetChildIndex(_lblcbo18, 0);
            Controls.SetChildIndex(_cbo18, 0);
            Controls.SetChildIndex(_txt3, 0);
            Controls.SetChildIndex(_lbltxt3, 0);
            Controls.SetChildIndex(_txt4, 0);
            Controls.SetChildIndex(_lbltxt4, 0);
            Controls.SetChildIndex(_txt5, 0);
            Controls.SetChildIndex(_lbltxt5, 0);
            Controls.SetChildIndex(_txt6, 0);
            Controls.SetChildIndex(_lbltxt6, 0);
            Controls.SetChildIndex(_txt7, 0);
            Controls.SetChildIndex(_lbltxt7, 0);
            Controls.SetChildIndex(_txt8, 0);
            Controls.SetChildIndex(_lbltxt8, 0);
            Controls.SetChildIndex(_txt9, 0);
            Controls.SetChildIndex(_lbltxt9, 0);
            Controls.SetChildIndex(_txt10, 0);
            Controls.SetChildIndex(_lbltxt10, 0);
            Controls.SetChildIndex(_lblcbo19, 0);
            Controls.SetChildIndex(_cbo19, 0);
            Controls.SetChildIndex(_lblcbo20, 0);
            Controls.SetChildIndex(_cbo20, 0);
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_cboType, 0);
            Controls.SetChildIndex(_txt11, 0);
            Controls.SetChildIndex(_lbltxt11, 0);
            Controls.SetChildIndex(_txt12, 0);
            Controls.SetChildIndex(_lbltxt12, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _updating = true;

        public bool Updating
        {
            get
            {
                return _updating;
            }

            set
            {
                _updating = value;
            }
        }

        private Entity.EngineerVisitAdditionals.EngineerVisitAdditional _Worksheet;

        public Entity.EngineerVisitAdditionals.EngineerVisitAdditional Worksheet
        {
            get
            {
                return _Worksheet;
            }

            set
            {
                _Worksheet = value;
            }
        }

        private Entity.EngineerVisits.EngineerVisit _EngineerVisit;

        public Entity.EngineerVisits.EngineerVisit EngineerVisit
        {
            get
            {
                return _EngineerVisit;
            }

            set
            {
                _EngineerVisit = value;
            }
        }

        private Entity.Sites.Site _TheSite;

        public Entity.Sites.Site TheSite
        {
            get
            {
                return _TheSite;
            }

            set
            {
                _TheSite = value;
            }
        }

        private int _jobID;

        public int JobID
        {
            get
            {
                return _jobID;
            }

            set
            {
                _jobID = value;
            }
        }

        private void DLGVisitAssetWorkSheet_Load(object sender, EventArgs e)
        {
            if (App.loggedInUser.Admin == false)
            {
                btnSave.Enabled = false;
                cboType.Enabled = false;
                cbo1.Enabled = false;
                cbo2.Enabled = false;
                cbo3.Enabled = false;
                cbo4.Enabled = false;
                cbo5.Enabled = false;
                cbo6.Enabled = false;
                cbo7.Enabled = false;
                cbo8.Enabled = false;
                cbo9.Enabled = false;
                cbo10.Enabled = false;
                cbo11.Enabled = false;
                cbo12.Enabled = false;
                cbo13.Enabled = false;
                cbo14.Enabled = false;
                cbo15.Enabled = false;
                cbo16.Enabled = false;
                cbo17.Enabled = false;
                cbo18.Enabled = false;
                cbo19.Enabled = false;
                cbo20.Enabled = false;
                txt1.ReadOnly = true;
                txt2.ReadOnly = true;
                txt3.ReadOnly = true;
                txt4.ReadOnly = true;
                txt5.ReadOnly = true;
                txt6.ReadOnly = true;
                txt7.ReadOnly = true;
                txt8.ReadOnly = true;
                txt9.ReadOnly = true;
                txt10.ReadOnly = true;
            }

            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TestType).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.TestTypeID.ToString());
            if (Worksheet.Exists == true & Updating == true)
            {
                Loadin();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                this.Worksheet.SetTestTypeID = Combo.get_GetSelectedItemValue(cboType);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                Worksheet.SetTest1 = Combo.get_GetSelectedItemValue(cbo1);
                Worksheet.SetTest2 = Combo.get_GetSelectedItemValue(cbo2);
                Worksheet.SetTest3 = Combo.get_GetSelectedItemValue(cbo3);
                Worksheet.SetTest4 = Combo.get_GetSelectedItemValue(cbo4);
                Worksheet.SetTest5 = Combo.get_GetSelectedItemValue(cbo5);
                Worksheet.SetTest6 = Combo.get_GetSelectedItemValue(cbo6);
                Worksheet.SetTest7 = Combo.get_GetSelectedItemValue(cbo7);
                Worksheet.SetTest8 = Combo.get_GetSelectedItemValue(cbo8);
                Worksheet.SetTest9 = Combo.get_GetSelectedItemValue(cbo9);
                Worksheet.SetTest10 = Combo.get_GetSelectedItemValue(cbo10);
                Worksheet.SetTest111 = Combo.get_GetSelectedItemValue(cbo11);
                Worksheet.SetTest112 = Combo.get_GetSelectedItemValue(cbo12);
                Worksheet.SetTest113 = Combo.get_GetSelectedItemValue(cbo13);
                Worksheet.SetTest114 = Combo.get_GetSelectedItemValue(cbo14);
                Worksheet.SetTest115 = Combo.get_GetSelectedItemValue(cbo15);
                Worksheet.SetTest116 = Combo.get_GetSelectedItemValue(cbo16);
                Worksheet.SetTest117 = Combo.get_GetSelectedItemValue(cbo17);
                Worksheet.SetTest118 = Combo.get_GetSelectedItemValue(cbo18);
                Worksheet.SetTest119 = Combo.get_GetSelectedItemValue(cbo19);
                Worksheet.SetTest120 = Combo.get_GetSelectedItemValue(cbo20);
                Worksheet.SetTest11 = txt1.Text;
                Worksheet.SetTest12 = txt2.Text;
                Worksheet.SetTest13 = txt3.Text;
                Worksheet.SetTest14 = txt4.Text;
                Worksheet.SetTest15 = txt5.Text;
                Worksheet.SetTest216 = txt6.Text;
                Worksheet.SetTest217 = txt7.Text;
                Worksheet.SetTest218 = txt8.Text;
                Worksheet.SetTest219 = txt9.Text;
                Worksheet.SetTest220 = txt10.Text;
                Worksheet.SetTest221 = txt11.Text;
                Worksheet.SetTest222 = txt12.Text;
                if (Updating)
                {
                    App.DB.EngineerVisitAdditional.Update(Worksheet);
                }
                else
                {
                    App.DB.EngineerVisitAdditional.Insert(Worksheet);
                }

                DialogResult = DialogResult.OK;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setQuestions();
        }

        public void setQuestions()
        {
            try
            {
                int testTypeID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
                if (testTypeID == 69108)
                {
                    comSafetyRec();
                }
                else if (testTypeID == 69109)
                {
                    comStrength();
                }
                else if (testTypeID == 69110)
                {
                    comPurge();
                }
                else if (testTypeID == 69111)
                {
                    comTight();
                }
                else
                {
                    hideAll();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Loadin()
        {
            // _worksheetData = EngineerVisitAdditionalChecks.Get(_worksheetID);

            // '

            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.TestTypeID.ToString());
            setQuestions();
            if (_Worksheet.Test1 > 0)
            {
                var argcombo1 = cbo1;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, _Worksheet.Test1.ToString());
            }

            if (_Worksheet.Test2 > 0)
            {
                var argcombo2 = cbo2;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, _Worksheet.Test2.ToString());
            }

            if (_Worksheet.Test3 > 0)
            {
                var argcombo3 = cbo3;
                Combo.SetSelectedComboItem_By_Value(ref argcombo3, _Worksheet.Test3.ToString());
            }

            if (_Worksheet.Test4 > 0)
            {
                var argcombo4 = cbo4;
                Combo.SetSelectedComboItem_By_Value(ref argcombo4, _Worksheet.Test4.ToString());
            }

            if (_Worksheet.Test5 > 0)
            {
                var argcombo5 = cbo5;
                Combo.SetSelectedComboItem_By_Value(ref argcombo5, _Worksheet.Test5.ToString());
            }

            if (_Worksheet.Test6 > 0)
            {
                var argcombo6 = cbo6;
                Combo.SetSelectedComboItem_By_Value(ref argcombo6, _Worksheet.Test6.ToString());
            }

            if (_Worksheet.Test7 > 0)
            {
                var argcombo7 = cbo7;
                Combo.SetSelectedComboItem_By_Value(ref argcombo7, _Worksheet.Test7.ToString());
            }

            if (_Worksheet.Test8 > 0)
            {
                var argcombo8 = cbo8;
                Combo.SetSelectedComboItem_By_Value(ref argcombo8, _Worksheet.Test8.ToString());
            }

            if (_Worksheet.Test9 > 0)
            {
                var argcombo9 = cbo9;
                Combo.SetSelectedComboItem_By_Value(ref argcombo9, _Worksheet.Test9.ToString());
            }

            if (_Worksheet.Test10 > 0)
            {
                var argcombo10 = cbo10;
                Combo.SetSelectedComboItem_By_Value(ref argcombo10, _Worksheet.Test10.ToString());
            }

            if (_Worksheet.Test111 > 0)
            {
                var argcombo11 = cbo11;
                Combo.SetSelectedComboItem_By_Value(ref argcombo11, _Worksheet.Test111.ToString());
            }

            if (_Worksheet.Test112 > 0)
            {
                var argcombo12 = cbo12;
                Combo.SetSelectedComboItem_By_Value(ref argcombo12, _Worksheet.Test112.ToString());
            }

            if (_Worksheet.Test113 > 0)
            {
                var argcombo13 = cbo13;
                Combo.SetSelectedComboItem_By_Value(ref argcombo13, _Worksheet.Test113.ToString());
            }

            if (_Worksheet.Test114 > 0)
            {
                var argcombo14 = cbo14;
                Combo.SetSelectedComboItem_By_Value(ref argcombo14, _Worksheet.Test114.ToString());
            }

            if (_Worksheet.Test115 > 0)
            {
                var argcombo15 = cbo15;
                Combo.SetSelectedComboItem_By_Value(ref argcombo15, _Worksheet.Test115.ToString());
            }

            if (_Worksheet.Test116 > 0)
            {
                var argcombo16 = cbo16;
                Combo.SetSelectedComboItem_By_Value(ref argcombo16, _Worksheet.Test116.ToString());
            }

            if (_Worksheet.Test117 > 0)
            {
                var argcombo17 = cbo17;
                Combo.SetSelectedComboItem_By_Value(ref argcombo17, _Worksheet.Test117.ToString());
            }

            if (_Worksheet.Test118 > 0)
            {
                var argcombo18 = cbo18;
                Combo.SetSelectedComboItem_By_Value(ref argcombo18, _Worksheet.Test118.ToString());
            }

            txt1.Text = _Worksheet.Test11;
            txt2.Text = _Worksheet.Test12;
            txt3.Text = _Worksheet.Test13;
            txt4.Text = _Worksheet.Test14;
            txt5.Text = _Worksheet.Test15;
            txt6.Text = _Worksheet.Test216;
            txt7.Text = _Worksheet.Test217;
            txt8.Text = _Worksheet.Test218;
            txt9.Text = _Worksheet.Test219;
            txt10.Text = _Worksheet.Test220;
            txt11.Text = _Worksheet.Test221;
            txt12.Text = _Worksheet.Test222;
            if (_Worksheet.Test119 > 0)
            {
                var argcombo19 = cbo19;
                Combo.SetSelectedComboItem_By_Value(ref argcombo19, _Worksheet.Test119.ToString());
            }

            if (_Worksheet.Test120 > 0)
            {
                var argcombo20 = cbo20;
                Combo.SetSelectedComboItem_By_Value(ref argcombo20, _Worksheet.Test120.ToString());
            }
        }

        public void hideAll()
        {
            cbo1.Visible = false;
            cbo2.Visible = false;
            cbo3.Visible = false;
            cbo4.Visible = false;
            cbo5.Visible = false;
            cbo6.Visible = false;
            cbo7.Visible = false;
            cbo8.Visible = false;
            cbo9.Visible = false;
            cbo10.Visible = false;
            cbo11.Visible = false;
            cbo12.Visible = false;
            cbo13.Visible = false;
            cbo14.Visible = false;
            cbo15.Visible = false;
            cbo16.Visible = false;
            cbo17.Visible = false;
            cbo18.Visible = false;
            cbo19.Visible = false;
            cbo20.Visible = false;
            lblcbo1.Visible = false;
            lblcbo2.Visible = false;
            lblcbo3.Visible = false;
            lblcbo4.Visible = false;
            lblcbo5.Visible = false;
            lblcbo6.Visible = false;
            lblcbo7.Visible = false;
            lblcbo8.Visible = false;
            lblcbo9.Visible = false;
            lblcbo10.Visible = false;
            lblcbo11.Visible = false;
            lblcbo12.Visible = false;
            lblcbo13.Visible = false;
            lblcbo14.Visible = false;
            lblcbo15.Visible = false;
            lblcbo16.Visible = false;
            lblcbo17.Visible = false;
            lblcbo18.Visible = false;
            lblcbo19.Visible = false;
            lblcbo20.Visible = false;
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
            txt8.Visible = false;
            txt9.Visible = false;
            txt10.Visible = false;
            txt11.Visible = false;
            txt12.Visible = false;
            lbltxt1.Visible = false;
            lbltxt2.Visible = false;
            lbltxt3.Visible = false;
            lbltxt4.Visible = false;
            lbltxt5.Visible = false;
            lbltxt6.Visible = false;
            lbltxt7.Visible = false;
            lbltxt8.Visible = false;
            lbltxt9.Visible = false;
            lbltxt10.Visible = false;
            lbltxt11.Visible = false;
            lbltxt12.Visible = false;
        }

        public void comSafetyRec()
        {
            cbo1.Visible = true;
            cbo2.Visible = true;
            cbo3.Visible = true;
            cbo4.Visible = true;
            cbo5.Visible = true;
            cbo6.Visible = true;
            cbo7.Visible = true;
            cbo8.Visible = true;
            cbo9.Visible = true;
            cbo10.Visible = true;
            cbo11.Visible = true;
            cbo12.Visible = true;
            cbo13.Visible = true;
            cbo14.Visible = true;
            cbo15.Visible = true;
            cbo16.Visible = true;
            cbo17.Visible = true;
            cbo18.Visible = true;
            cbo19.Visible = true;
            cbo20.Visible = false;
            lblcbo1.Visible = true;
            lblcbo2.Visible = true;
            lblcbo3.Visible = true;
            lblcbo4.Visible = true;
            lblcbo5.Visible = true;
            lblcbo6.Visible = true;
            lblcbo7.Visible = true;
            lblcbo8.Visible = true;
            lblcbo9.Visible = true;
            lblcbo10.Visible = true;
            lblcbo11.Visible = true;
            lblcbo12.Visible = true;
            lblcbo13.Visible = true;
            lblcbo14.Visible = true;
            lblcbo15.Visible = true;
            lblcbo16.Visible = true;
            lblcbo17.Visible = true;
            lblcbo18.Visible = true;
            lblcbo19.Visible = true;
            lblcbo20.Visible = false;
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
            txt8.Visible = false;
            txt9.Visible = false;
            txt10.Visible = false;
            txt11.Visible = false;
            txt12.Visible = false;
            lbltxt1.Visible = false;
            lbltxt2.Visible = false;
            lbltxt3.Visible = false;
            lbltxt4.Visible = false;
            lbltxt5.Visible = false;
            lbltxt6.Visible = false;
            lbltxt7.Visible = false;
            lbltxt8.Visible = false;
            lbltxt9.Visible = false;
            lbltxt10.Visible = false;
            lbltxt11.Visible = false;
            lbltxt12.Visible = false;
            lblcbo1.Text = "Is the meter installation accessible?";
            var argc = cbo1;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo2.Text = "Is the meter adequately supported?";
            var argc1 = cbo2;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo3.Text = "Is the ECV accessible?";
            var argc2 = cbo3;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo4.Text = "Is the ECV fitted with a handle?";
            var argc3 = cbo4;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo5.Text = "Is the ECV labeled with direction of operation?";
            var argc4 = cbo5;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo6.Text = "Is the ECV complete with emergency notice?";
            var argc5 = cbo6;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo7.Text = "Is the meter room/compartment/housing adequately Ventilated?";
            var argc6 = cbo7;
            Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo8.Text = "Is the meter room/compartment/housing clear of combustibles etc?";
            var argc7 = cbo8;
            Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo9.Text = "Is a gas installation line diagram fixed near to the primary meter?";
            var argc8 = cbo9;
            Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo10.Text = "Is the gas installation line diagram current/up-to-date?";
            var argc9 = cbo10;
            Combo.SetUpCombo(ref argc9, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo11.Text = "Are emergency/isolation valves fitted?";
            var argc10 = cbo11;
            Combo.SetUpCombo(ref argc10, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo12.Text = "Are emergency/isolation valve handles in place and suitably lablled?";
            var argc11 = cbo12;
            Combo.SetUpCombo(ref argc11, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo13.Text = "Is the gas installation line diagram current/up-to-date?";
            var argc12 = cbo13;
            Combo.SetUpCombo(ref argc12, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo14.Text = "Is the gas pipework adequately supported?";
            var argc13 = cbo14;
            Combo.SetUpCombo(ref argc13, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo15.Text = "Is the gas pipework, where located in ducts, adequately ventilated?";
            var argc14 = cbo15;
            Combo.SetUpCombo(ref argc14, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo16.Text = "Is the gas pipework colour coded/identified?";
            var argc15 = cbo16;
            Combo.SetUpCombo(ref argc15, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo17.Text = "Is the gas installation electrically bonded?";
            var argc16 = cbo17;
            Combo.SetUpCombo(ref argc16, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo18.Text = "Is the pipework suitably sleeved and sealed, as appropriate?";
            var argc17 = cbo18;
            Combo.SetUpCombo(ref argc17, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo19.Text = "Has a gas strength/tightness test been carried out?";
            var argc18 = cbo19;
            Combo.SetUpCombo(ref argc18, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        public void comStrength()
        {
            cbo1.Visible = true;
            cbo2.Visible = true;
            cbo3.Visible = true;
            cbo4.Visible = true;
            cbo5.Visible = false;
            cbo6.Visible = false;
            cbo7.Visible = false;
            cbo8.Visible = false;
            cbo9.Visible = false;
            cbo10.Visible = false;
            cbo11.Visible = false;
            cbo12.Visible = false;
            cbo13.Visible = false;
            cbo14.Visible = false;
            cbo15.Visible = false;
            cbo16.Visible = false;
            cbo17.Visible = false;
            cbo18.Visible = false;
            cbo19.Visible = false;
            cbo20.Visible = true;
            lblcbo1.Visible = true;
            lblcbo2.Visible = true;
            lblcbo3.Visible = true;
            lblcbo4.Visible = true;
            lblcbo5.Visible = false;
            lblcbo6.Visible = false;
            lblcbo7.Visible = false;
            lblcbo8.Visible = false;
            lblcbo9.Visible = false;
            lblcbo10.Visible = false;
            lblcbo11.Visible = false;
            lblcbo12.Visible = false;
            lblcbo13.Visible = false;
            lblcbo14.Visible = false;
            lblcbo15.Visible = false;
            lblcbo16.Visible = false;
            lblcbo17.Visible = false;
            lblcbo18.Visible = false;
            lblcbo19.Visible = false;
            lblcbo20.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt6.Visible = true;
            txt7.Visible = false;
            txt8.Visible = false;
            txt9.Visible = false;
            txt10.Visible = false;
            txt11.Visible = false;
            txt12.Visible = false;
            lbltxt1.Visible = true;
            lbltxt2.Visible = true;
            lbltxt3.Visible = true;
            lbltxt4.Visible = true;
            lbltxt5.Visible = true;
            lbltxt6.Visible = true;
            lbltxt7.Visible = false;
            lbltxt8.Visible = false;
            lbltxt9.Visible = false;
            lbltxt10.Visible = false;
            lbltxt11.Visible = false;
            lbltxt12.Visible = false;
            DataRow dr;
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dr = dt.NewRow();
            dr["Name"] = "- Please Select -";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Pneumatic";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Hydrostatic";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            cbo1.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo1.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo1.DisplayMember = "Description";
            cbo1.ValueMember = "Value";
            cbo1.SelectedIndex = 0;
            //

            lblcbo1.Text = "State test method - ";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("New", 1);
            dt.Rows.Add("New extension", 2);
            dt.Rows.Add("Existing", 3);
            cbo2.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo2.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo2.DisplayMember = "Description";
            cbo2.ValueMember = "Value";
            cbo2.SelectedIndex = 0;
            lblcbo2.Text = "Installation - ";
            var argc = cbo3;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo3.Text = "Have components not suitable for strength testing been removed or isolated from installation as necessary";
            lbltxt1.Text = "Calculated strength test pressure";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("Air", 1);
            dt.Rows.Add("Nitrogen", 2);
            dt.Rows.Add("Water", 3);
            cbo4.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo4.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo4.DisplayMember = "Description";
            cbo4.ValueMember = "Value";
            cbo4.SelectedIndex = 0;
            lblcbo4.Text = "Test medium - air, nitrogen, water etc.";
            lbltxt2.Text = "Stabilisation Period (minutes)";
            lbltxt3.Text = "Strength Test Duration (STD) (minutes)";
            lbltxt4.Text = "Permitted pressure drop (% STP)";
            lbltxt5.Text = "Calculated pressure Drop";
            lbltxt6.Text = "Actual pressure Drop";
            var argc1 = cbo20;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo20.Text = "Strength Test Pass or Fail";
        }

        public void comTight()
        {
            cbo1.Visible = true;
            cbo2.Visible = true;
            cbo3.Visible = true;
            cbo4.Visible = true;
            cbo5.Visible = false;
            cbo6.Visible = true;
            cbo7.Visible = true;
            cbo8.Visible = true;
            cbo9.Visible = true;
            cbo10.Visible = true;
            cbo11.Visible = false;
            cbo12.Visible = false;
            cbo13.Visible = false;
            cbo14.Visible = false;
            cbo15.Visible = false;
            cbo16.Visible = false;
            cbo17.Visible = false;
            cbo18.Visible = false;
            cbo19.Visible = true;
            cbo20.Visible = true;
            lblcbo1.Visible = true;
            lblcbo2.Visible = true;
            lblcbo3.Visible = true;
            lblcbo4.Visible = true;
            lblcbo5.Visible = false;
            lblcbo6.Visible = true;
            lblcbo7.Visible = true;
            lblcbo8.Visible = true;
            lblcbo9.Visible = true;
            lblcbo10.Visible = true;
            lblcbo11.Visible = false;
            lblcbo12.Visible = false;
            lblcbo13.Visible = false;
            lblcbo14.Visible = false;
            lblcbo15.Visible = false;
            lblcbo16.Visible = false;
            lblcbo17.Visible = false;
            lblcbo18.Visible = false;
            lblcbo19.Visible = true;
            lblcbo20.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt6.Visible = true;
            txt7.Visible = true;
            txt8.Visible = true;
            txt9.Visible = true;
            txt10.Visible = true;
            txt11.Visible = true;
            txt12.Visible = false;
            lbltxt1.Visible = true;
            lbltxt2.Visible = true;
            lbltxt3.Visible = true;
            lbltxt4.Visible = true;
            lbltxt5.Visible = true;
            lbltxt6.Visible = true;
            lbltxt7.Visible = true;
            lbltxt8.Visible = true;
            lbltxt9.Visible = true;
            lbltxt10.Visible = true;
            lbltxt11.Visible = true;
            lbltxt12.Visible = false;
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("Natural Gas (NG)", 1);
            dt.Rows.Add("Liquefied Petroleum Gas (LPG)", 2);
            cbo1.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo1.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo1.DisplayMember = "Description";
            cbo1.ValueMember = "Value";
            cbo1.SelectedIndex = 0;
            lblcbo1.Text = "Gas Type - ";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("New", 1);
            dt.Rows.Add("New extension", 2);
            dt.Rows.Add("Existing", 3);
            cbo2.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo2.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo2.DisplayMember = "Description";
            cbo2.ValueMember = "Value";
            cbo2.SelectedIndex = 0;
            lblcbo2.Text = "Installation - ";
            var argc = cbo3;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo3.Text = "Could weather/changes in temperature affect test?";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("Diaphragm", 1);
            dt.Rows.Add("Rotary", 2);
            dt.Rows.Add("Turbine", 3);
            cbo4.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo4.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo4.DisplayMember = "Description";
            cbo4.ValueMember = "Value";
            cbo4.SelectedIndex = 0;
            lblcbo4.Text = "Meter Type - ";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");

            // dt.Rows.Add("- Please Select -", 0)
            // dt.Rows.Add("U16", 1)
            // dt.Rows.Add("U40", 2)
            // dt.Rows.Add("P7", 3)
            // dt.Rows.Add("U25", 4)
            // cbo5.Items.Clear()
            // If Not dt Is Nothing Then
            // For Each DataRow As DataRow In dt.Rows
            // cbo5.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            // Next
            // End If

            // cbo5.DisplayMember = "Description"
            // cbo5.ValueMember = "Value"
            // cbo5.SelectedIndex = 0

            // lblcbo5.Text = ("Meter Design - ")

            var argc1 = cbo6;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo6.Text = "Meter Bypass Installed and Sealed?";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("Fuel gas", 1);
            dt.Rows.Add("Air", 2);
            cbo7.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo7.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo7.DisplayMember = "Description";
            cbo7.ValueMember = "Value";
            cbo7.SelectedIndex = 0;
            lblcbo7.Text = "Test Medium - ";
            dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("- Please Select -", 0);
            dt.Rows.Add("Water", 1);
            dt.Rows.Add("High SG", 2);
            dt.Rows.Add("Electronic", 2);
            cbo8.Items.Clear();
            if (dt is object)
            {
                foreach (DataRow DataRow in dt.Rows)
                    cbo8.Items.Add(new Combo(Conversions.ToString(DataRow["Name"]), Conversions.ToString(DataRow["Value"])));
            }

            cbo8.DisplayMember = "Description";
            cbo8.ValueMember = "Value";
            cbo8.SelectedIndex = 0;
            lblcbo8.Text = "Pressure Gauge Type - ";
            var argc2 = cbo9;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo9.Text = "Any inadequately ventilated areas to check?";
            var argc3 = cbo10;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo10.Text = "Is barometric pressure correction necessary?";
            var argc4 = cbo19;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo19.Text = "Have inadequately ventilated areas been checked?";
            var argc5 = cbo20;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo20.Text = "Tightness test Pass or Fail";
            lbltxt1.Text = "Installation Volume : Gas Meter (m3)";
            lbltxt2.Text = "Installation Volume : Installation pipework and fittings (m3)";
            lbltxt3.Text = "Installation Volume : Total IV (m3)";
            lbltxt4.Text = "Tightness test pressure (TTP) mbar";
            lbltxt5.Text = "MPLR m3/hr (IGE/UP/1) or MAPD mbar (IGE/UP/1A) ";
            lbltxt6.Text = "Let-by test period existing installations (minutes)";
            lbltxt7.Text = "Stabilisation period (minutes)";
            lbltxt8.Text = "Tightness test duration (TTD) (minutes)";
            lbltxt9.Text = "Actual pressure drop (if any) mbar";
            lbltxt10.Text = "Actual leak rate m3/hr";
            lbltxt11.Text = "Meter Designation (U16,U40,Etc.) - ";
        }

        public void comPurge()
        {
            cbo1.Visible = true;
            cbo2.Visible = true;
            cbo3.Visible = true;
            cbo4.Visible = true;
            cbo5.Visible = true;
            cbo6.Visible = true;
            cbo7.Visible = true;
            cbo8.Visible = true;
            cbo9.Visible = true;
            cbo10.Visible = true;
            cbo11.Visible = false;
            cbo12.Visible = false;
            cbo13.Visible = false;
            cbo14.Visible = false;
            cbo15.Visible = false;
            cbo16.Visible = false;
            cbo17.Visible = false;
            cbo18.Visible = false;
            cbo19.Visible = false;
            cbo20.Visible = true;
            lblcbo1.Visible = true;
            lblcbo2.Visible = true;
            lblcbo3.Visible = true;
            lblcbo4.Visible = true;
            lblcbo5.Visible = true;
            lblcbo6.Visible = true;
            lblcbo7.Visible = true;
            lblcbo8.Visible = true;
            lblcbo9.Visible = true;
            lblcbo10.Visible = true;
            lblcbo11.Visible = false;
            lblcbo12.Visible = false;
            lblcbo13.Visible = false;
            lblcbo14.Visible = false;
            lblcbo15.Visible = false;
            lblcbo16.Visible = false;
            lblcbo17.Visible = false;
            lblcbo18.Visible = false;
            lblcbo19.Visible = false;
            lblcbo20.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
            txt8.Visible = false;
            txt9.Visible = false;
            txt10.Visible = false;
            txt11.Visible = false;
            txt12.Visible = false;
            lbltxt1.Visible = true;
            lbltxt2.Visible = true;
            lbltxt3.Visible = true;
            lbltxt4.Visible = true;
            lbltxt5.Visible = false;
            lbltxt6.Visible = false;
            lbltxt7.Visible = false;
            lbltxt8.Visible = false;
            lbltxt9.Visible = false;
            lbltxt10.Visible = false;
            lbltxt11.Visible = false;
            lbltxt12.Visible = false;
            var argc = cbo1;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo1.Text = "Has a risk assessment been carried out?";
            var argc1 = cbo2;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo2.Text = "Has a written procedure for the purge been prepared?";
            var argc2 = cbo3;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo3.Text = "Have 'NO SMOKING' signs etc been displayed as necessary?";
            var argc3 = cbo4;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo4.Text = "Have persons in the vicinity of the purge been advised accordingly?";
            var argc4 = cbo5;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo5.Text = "Have all appropriate valves to and from the section of pipe been labelled?";
            var argc5 = cbo6;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo6.Text = "Where nitrogen gas is being used for an indirect purge, have the gas cylinders been checked/verified for their correct content?";
            var argc6 = cbo7;
            Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo7.Text = "Are suitable extinguishers available in case of an incident?";
            var argc7 = cbo8;
            Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo8.Text = "Are two-way radios (intrinsically safe) available?";
            var argc8 = cbo9;
            Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo9.Text = "Are all electrical bonds fitted as necessary?";
            var argc9 = cbo10;
            Combo.SetUpCombo(ref argc9, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo10.Text = "Is gas detector/oxygen measuring device, as appropriate, intrinsically safe?";
            var argc10 = cbo20;
            Combo.SetUpCombo(ref argc10, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            lblcbo20.Text = "Purge Pass or Fail";
            lbltxt1.Text = "Calculate purge Volume : Gas meter (m3)";
            lbltxt2.Text = "Calculate purge Volume : Installation pipework and fittings (m3)";
            lbltxt3.Text = "Calculate purge Volume : Total purge volume (m3)";
            lbltxt4.Text = "Carry out purge noting final test criteria readings (O2% or LFL%)";
        }
    }
}