using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMJobCostings : FRMBaseForm
    {
        public FRMJobCostings()
        {
            base.Load += LoadMe;
            base.Load += FRMLogCallout_Load;
        }

        public FRMJobCostings(Entity.Jobs.Job oJob) : base()
        {
            base.Load += LoadMe;
            base.Load += FRMLogCallout_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            CurrentJob = oJob;
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
        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
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

        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
                }
            }
        }

        private Button _btnPrintJobCosting;

        private TabPage _tpJobCostings;

        private TabPage _tpInstall;

        internal TabPage tpInstall
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpInstall;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpInstall != null)
                {
                }

                _tpInstall = value;
                if (_tpInstall != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private TextBox _txtDeposit;

        internal TextBox txtDeposit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDeposit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDeposit != null)
                {
                    _txtDeposit.KeyUp -= txtDeposit_TextChanged;
                }

                _txtDeposit = value;
                if (_txtDeposit != null)
                {
                    _txtDeposit.KeyUp += txtDeposit_TextChanged;
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private ComboBox _cboCalledSuper;

        internal ComboBox cboCalledSuper
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCalledSuper;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCalledSuper != null)
                {
                }

                _cboCalledSuper = value;
                if (_cboCalledSuper != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private ComboBox _cboSurveyed;

        internal ComboBox cboSurveyed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSurveyed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSurveyed != null)
                {
                }

                _cboSurveyed = value;
                if (_cboSurveyed != null)
                {
                }
            }
        }

        private TextBox _txtPO;

        internal TextBox txtPO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPO != null)
                {
                }

                _txtPO = value;
                if (_txtPO != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private TextBox _txtProfitActPerc;

        internal TextBox txtProfitActPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitActPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitActPerc != null)
                {
                }

                _txtProfitActPerc = value;
                if (_txtProfitActPerc != null)
                {
                }
            }
        }

        private Label _Label18;

        private TextBox _txtProfitEstPerc;

        internal TextBox txtProfitEstPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitEstPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitEstPerc != null)
                {
                }

                _txtProfitEstPerc = value;
                if (_txtProfitEstPerc != null)
                {
                }
            }
        }

        private Label _Label16;

        private TextBox _txtProfitActMoney;

        internal TextBox txtProfitActMoney
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitActMoney;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitActMoney != null)
                {
                }

                _txtProfitActMoney = value;
                if (_txtProfitActMoney != null)
                {
                }
            }
        }

        private Label _Label15;

        private TextBox _txtProfitEstMoney;

        internal TextBox txtProfitEstMoney
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitEstMoney;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitEstMoney != null)
                {
                }

                _txtProfitEstMoney = value;
                if (_txtProfitEstMoney != null)
                {
                }
            }
        }

        private Label _Label14;

        private TextBox _txtTotalEst;

        internal TextBox txtTotalEst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalEst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalEst != null)
                {
                }

                _txtTotalEst = value;
                if (_txtTotalEst != null)
                {
                }
            }
        }

        private TextBox _txtTotalAct;

        internal TextBox txtTotalAct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalAct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalAct != null)
                {
                }

                _txtTotalAct = value;
                if (_txtTotalAct != null)
                {
                }
            }
        }

        private Label _Label12;

        private Label _Label13;

        private TextBox _txtEstLabour;

        internal TextBox txtEstLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEstLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEstLabour != null)
                {
                    _txtEstLabour.TextChanged -= txtEstLabour_TextChanged;
                }

                _txtEstLabour = value;
                if (_txtEstLabour != null)
                {
                    _txtEstLabour.TextChanged += txtEstLabour_TextChanged;
                }
            }
        }

        private TextBox _txtActLabour;

        internal TextBox txtActLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActLabour != null)
                {
                }

                _txtActLabour = value;
                if (_txtActLabour != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private Label _Label17;

        private TextBox _txtPartEst;

        internal TextBox txtPartEst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartEst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartEst != null)
                {
                    _txtPartEst.TextChanged -= txtPartEst_TextChanged;
                }

                _txtPartEst = value;
                if (_txtPartEst != null)
                {
                    _txtPartEst.TextChanged += txtPartEst_TextChanged;
                }
            }
        }

        private TextBox _txtPartAct;

        internal TextBox txtPartAct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartAct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartAct != null)
                {
                }

                _txtPartAct = value;
                if (_txtPartAct != null)
                {
                }
            }
        }

        private Label _Label19;

        private Label _Label20;

        private Label _Label11;

        private ComboBox _cboPaperwork;

        internal ComboBox cboPaperwork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaperwork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaperwork != null)
                {
                }

                _cboPaperwork = value;
                if (_cboPaperwork != null)
                {
                }
            }
        }

        private Label _Label10;

        private ComboBox _cboQC;

        internal ComboBox cboQC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQC != null)
                {
                }

                _cboQC = value;
                if (_cboQC != null)
                {
                }
            }
        }

        private TextBox _txtPayment;

        internal TextBox txtPayment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPayment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPayment != null)
                {
                    _txtPayment.TextChanged -= txtPayment_TextChanged;
                }

                _txtPayment = value;
                if (_txtPayment != null)
                {
                    _txtPayment.TextChanged += txtPayment_TextChanged;
                }
            }
        }

        private Label _Label9;

        private Label _Label8;

        private ComboBox _cboFurtherWorks;

        internal ComboBox cboFurtherWorks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFurtherWorks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFurtherWorks != null)
                {
                }

                _cboFurtherWorks = value;
                if (_cboFurtherWorks != null)
                {
                }
            }
        }

        private Label _Label7;

        private ComboBox _cboExtraLabour;

        internal ComboBox cboExtraLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExtraLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExtraLabour != null)
                {
                }

                _cboExtraLabour = value;
                if (_cboExtraLabour != null)
                {
                }
            }
        }

        private TextBox _txtQuoted;

        internal TextBox txtQuoted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuoted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuoted != null)
                {
                    _txtQuoted.KeyUp -= TextBox1_TextChanged;
                }

                _txtQuoted = value;
                if (_txtQuoted != null)
                {
                    _txtQuoted.KeyUp += TextBox1_TextChanged;
                }
            }
        }

        private Label _lblQuoted;

        private Label _Label26;

        private Label _Label25;

        private Label _Label24;

        private Label _Label23;

        private TextBox _txtEstElec;

        internal TextBox txtEstElec
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEstElec;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEstElec != null)
                {
                    _txtEstElec.TextChanged -= txtEstElectrical_TextChanged;
                }

                _txtEstElec = value;
                if (_txtEstElec != null)
                {
                    _txtEstElec.TextChanged += txtEstElectrical_TextChanged;
                }
            }
        }

        private TextBox _txtActElec;

        internal TextBox txtActElec
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActElec;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActElec != null)
                {
                }

                _txtActElec = value;
                if (_txtActElec != null)
                {
                }
            }
        }

        private Label _Label21;

        private Label _Label22;

        private TextBox _txtQuotedGross;

        internal TextBox txtQuotedGross
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuotedGross;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuotedGross != null)
                {
                    _txtQuotedGross.KeyUp -= txtQuotedGross_TextChanged;
                }

                _txtQuotedGross = value;
                if (_txtQuotedGross != null)
                {
                    _txtQuotedGross.KeyUp += txtQuotedGross_TextChanged;
                }
            }
        }

        private TextBox _txtDepositGross;

        internal TextBox txtDepositGross
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDepositGross;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDepositGross != null)
                {
                    _txtDepositGross.KeyUp -= txtDepositGross_TextChanged;
                }

                _txtDepositGross = value;
                if (_txtDepositGross != null)
                {
                    _txtDepositGross.KeyUp += txtDepositGross_TextChanged;
                }
            }
        }

        private Label _Label28;

        private Label _Label27;

        private TextBox _txtSupplierInv;

        internal TextBox txtSupplierInv
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierInv;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierInv != null)
                {
                }

                _txtSupplierInv = value;
                if (_txtSupplierInv != null)
                {
                }
            }
        }

        private TextBox _txtManual;

        internal TextBox txtManual
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtManual;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtManual != null)
                {
                    _txtManual.KeyUp -= txtManual_TextChanged;
                }

                _txtManual = value;
                if (_txtManual != null)
                {
                    _txtManual.KeyUp += txtManual_TextChanged;
                }
            }
        }

        private Label _Label31;

        private TextBox _txtEstSub;

        internal TextBox txtEstSub
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEstSub;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEstSub != null)
                {
                    _txtEstSub.TextChanged -= txtEstSub_TextChanged;
                }

                _txtEstSub = value;
                if (_txtEstSub != null)
                {
                    _txtEstSub.TextChanged += txtEstSub_TextChanged;
                }
            }
        }

        private TextBox _txtActSub;

        internal TextBox txtActSub
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActSub;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActSub != null)
                {
                }

                _txtActSub = value;
                if (_txtActSub != null)
                {
                }
            }
        }

        private Label _Label29;

        private Label _Label30;

        private GroupBox _grpTotalCostings;

        private Label _Label32;

        private Label _Label33;

        private TextBox _txtProfitPerc;

        internal TextBox txtProfitPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitPerc != null)
                {
                }

                _txtProfitPerc = value;
                if (_txtProfitPerc != null)
                {
                }
            }
        }

        private TextBox _TxtProfitPounds;

        internal TextBox TxtProfitPounds
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TxtProfitPounds;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TxtProfitPounds != null)
                {
                }

                _TxtProfitPounds = value;
                if (_TxtProfitPounds != null)
                {
                }
            }
        }

        private Label _lbl5;

        private Label _Label34;

        private TextBox _txtSales;

        internal TextBox txtSales
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSales;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSales != null)
                {
                }

                _txtSales = value;
                if (_txtSales != null)
                {
                }
            }
        }

        private TextBox _txtCosts;

        internal TextBox txtCosts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCosts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCosts != null)
                {
                }

                _txtCosts = value;
                if (_txtCosts != null)
                {
                }
            }
        }

        private GroupBox _grpPartCostings;

        private Label _Label35;

        private Label _Label36;

        private Label _Label37;

        private Label _Label38;

        private Label _lbl1;

        private TextBox _txtPartCost;

        internal TextBox txtPartCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartCost != null)
                {
                }

                _txtPartCost = value;
                if (_txtPartCost != null)
                {
                }
            }
        }

        private TextBox _txtLabourCost;

        internal TextBox txtLabourCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLabourCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLabourCost != null)
                {
                }

                _txtLabourCost = value;
                if (_txtLabourCost != null)
                {
                }
            }
        }

        private Label _Label41;

        private TextBox _txtSorTotal;

        internal TextBox txtSorTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSorTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSorTotal != null)
                {
                }

                _txtSorTotal = value;
                if (_txtSorTotal != null)
                {
                }
            }
        }

        private Label _Label40;

        private TextBox _TextBox2;

        private Label _Label39;

        private TextBox _txtSORSales;

        internal TextBox txtSORSales
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSORSales;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSORSales != null)
                {
                }

                _txtSORSales = value;
                if (_txtSORSales != null)
                {
                }
            }
        }

        private DataGrid _dgTimesheetCharges;

        internal DataGrid dgTimesheetCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTimesheetCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTimesheetCharges != null)
                {
                }

                _dgTimesheetCharges = value;
                if (_dgTimesheetCharges != null)
                {
                }
            }
        }

        private DataGrid _dgPartsProductCharging;

        internal DataGrid dgPartsProductCharging
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsProductCharging;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsProductCharging != null)
                {
                }

                _dgPartsProductCharging = value;
                if (_dgPartsProductCharging != null)
                {
                }
            }
        }

        private DataGrid _dgScheduleOfRateCharges;

        internal DataGrid dgScheduleOfRateCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgScheduleOfRateCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgScheduleOfRateCharges != null)
                {
                }

                _dgScheduleOfRateCharges = value;
                if (_dgScheduleOfRateCharges != null)
                {
                }
            }
        }

        private Label _Label43;

        private TextBox _txtPartPerc;

        internal TextBox txtPartPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartPerc != null)
                {
                }

                _txtPartPerc = value;
                if (_txtPartPerc != null)
                {
                }
            }
        }

        private Label _Label42;

        private TextBox _txtLabourPerc;

        internal TextBox txtLabourPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLabourPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLabourPerc != null)
                {
                }

                _txtLabourPerc = value;
                if (_txtLabourPerc != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnClose = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._TabControl1 = new System.Windows.Forms.TabControl();
            this._tpJobCostings = new System.Windows.Forms.TabPage();
            this._grpTotalCostings = new System.Windows.Forms.GroupBox();
            this._Label41 = new System.Windows.Forms.Label();
            this._txtSorTotal = new System.Windows.Forms.TextBox();
            this._Label32 = new System.Windows.Forms.Label();
            this._Label33 = new System.Windows.Forms.Label();
            this._txtProfitPerc = new System.Windows.Forms.TextBox();
            this._TxtProfitPounds = new System.Windows.Forms.TextBox();
            this._lbl5 = new System.Windows.Forms.Label();
            this._Label34 = new System.Windows.Forms.Label();
            this._txtSales = new System.Windows.Forms.TextBox();
            this._txtCosts = new System.Windows.Forms.TextBox();
            this._grpPartCostings = new System.Windows.Forms.GroupBox();
            this._Label43 = new System.Windows.Forms.Label();
            this._txtPartPerc = new System.Windows.Forms.TextBox();
            this._Label42 = new System.Windows.Forms.Label();
            this._txtLabourPerc = new System.Windows.Forms.TextBox();
            this._dgScheduleOfRateCharges = new System.Windows.Forms.DataGrid();
            this._dgPartsProductCharging = new System.Windows.Forms.DataGrid();
            this._Label40 = new System.Windows.Forms.Label();
            this._TextBox2 = new System.Windows.Forms.TextBox();
            this._Label39 = new System.Windows.Forms.Label();
            this._txtSORSales = new System.Windows.Forms.TextBox();
            this._dgTimesheetCharges = new System.Windows.Forms.DataGrid();
            this._Label35 = new System.Windows.Forms.Label();
            this._Label36 = new System.Windows.Forms.Label();
            this._Label37 = new System.Windows.Forms.Label();
            this._Label38 = new System.Windows.Forms.Label();
            this._lbl1 = new System.Windows.Forms.Label();
            this._txtPartCost = new System.Windows.Forms.TextBox();
            this._txtLabourCost = new System.Windows.Forms.TextBox();
            this._tpInstall = new System.Windows.Forms.TabPage();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtManual = new System.Windows.Forms.TextBox();
            this._Label31 = new System.Windows.Forms.Label();
            this._txtEstSub = new System.Windows.Forms.TextBox();
            this._txtActSub = new System.Windows.Forms.TextBox();
            this._Label29 = new System.Windows.Forms.Label();
            this._Label30 = new System.Windows.Forms.Label();
            this._Label28 = new System.Windows.Forms.Label();
            this._Label27 = new System.Windows.Forms.Label();
            this._txtSupplierInv = new System.Windows.Forms.TextBox();
            this._Label26 = new System.Windows.Forms.Label();
            this._Label25 = new System.Windows.Forms.Label();
            this._Label24 = new System.Windows.Forms.Label();
            this._Label23 = new System.Windows.Forms.Label();
            this._txtEstElec = new System.Windows.Forms.TextBox();
            this._txtActElec = new System.Windows.Forms.TextBox();
            this._Label21 = new System.Windows.Forms.Label();
            this._Label22 = new System.Windows.Forms.Label();
            this._txtQuotedGross = new System.Windows.Forms.TextBox();
            this._txtDepositGross = new System.Windows.Forms.TextBox();
            this._txtQuoted = new System.Windows.Forms.TextBox();
            this._lblQuoted = new System.Windows.Forms.Label();
            this._txtProfitActPerc = new System.Windows.Forms.TextBox();
            this._Label18 = new System.Windows.Forms.Label();
            this._txtProfitEstPerc = new System.Windows.Forms.TextBox();
            this._Label16 = new System.Windows.Forms.Label();
            this._txtProfitActMoney = new System.Windows.Forms.TextBox();
            this._Label15 = new System.Windows.Forms.Label();
            this._txtProfitEstMoney = new System.Windows.Forms.TextBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._txtTotalEst = new System.Windows.Forms.TextBox();
            this._txtTotalAct = new System.Windows.Forms.TextBox();
            this._Label12 = new System.Windows.Forms.Label();
            this._Label13 = new System.Windows.Forms.Label();
            this._txtEstLabour = new System.Windows.Forms.TextBox();
            this._txtActLabour = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._Label17 = new System.Windows.Forms.Label();
            this._txtPartEst = new System.Windows.Forms.TextBox();
            this._txtPartAct = new System.Windows.Forms.TextBox();
            this._Label19 = new System.Windows.Forms.Label();
            this._Label20 = new System.Windows.Forms.Label();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboPaperwork = new System.Windows.Forms.ComboBox();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboQC = new System.Windows.Forms.ComboBox();
            this._txtPayment = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._cboFurtherWorks = new System.Windows.Forms.ComboBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._cboExtraLabour = new System.Windows.Forms.ComboBox();
            this._txtPO = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._cboCalledSuper = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboSurveyed = new System.Windows.Forms.ComboBox();
            this._txtDeposit = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnPrintJobCosting = new System.Windows.Forms.Button();
            this._TabControl1.SuspendLayout();
            this._tpJobCostings.SuspendLayout();
            this._grpTotalCostings.SuspendLayout();
            this._grpPartCostings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgScheduleOfRateCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsProductCharging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheetCharges)).BeginInit();
            this._tpInstall.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(70, 664);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 16;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 664);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 23);
            this._btnSave.TabIndex = 15;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _TabControl1
            // 
            this._TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TabControl1.Controls.Add(this._tpJobCostings);
            this._TabControl1.Controls.Add(this._tpInstall);
            this._TabControl1.Location = new System.Drawing.Point(0, 12);
            this._TabControl1.Name = "_TabControl1";
            this._TabControl1.SelectedIndex = 0;
            this._TabControl1.Size = new System.Drawing.Size(942, 646);
            this._TabControl1.TabIndex = 23;
            // 
            // _tpJobCostings
            // 
            this._tpJobCostings.Controls.Add(this._grpTotalCostings);
            this._tpJobCostings.Controls.Add(this._grpPartCostings);
            this._tpJobCostings.Location = new System.Drawing.Point(4, 22);
            this._tpJobCostings.Name = "_tpJobCostings";
            this._tpJobCostings.Padding = new System.Windows.Forms.Padding(3);
            this._tpJobCostings.Size = new System.Drawing.Size(934, 620);
            this._tpJobCostings.TabIndex = 5;
            this._tpJobCostings.Text = "Job Costings";
            this._tpJobCostings.UseVisualStyleBackColor = true;
            // 
            // _grpTotalCostings
            // 
            this._grpTotalCostings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpTotalCostings.Controls.Add(this._Label41);
            this._grpTotalCostings.Controls.Add(this._txtSorTotal);
            this._grpTotalCostings.Controls.Add(this._Label32);
            this._grpTotalCostings.Controls.Add(this._Label33);
            this._grpTotalCostings.Controls.Add(this._txtProfitPerc);
            this._grpTotalCostings.Controls.Add(this._TxtProfitPounds);
            this._grpTotalCostings.Controls.Add(this._lbl5);
            this._grpTotalCostings.Controls.Add(this._Label34);
            this._grpTotalCostings.Controls.Add(this._txtSales);
            this._grpTotalCostings.Controls.Add(this._txtCosts);
            this._grpTotalCostings.Location = new System.Drawing.Point(4, 496);
            this._grpTotalCostings.Name = "_grpTotalCostings";
            this._grpTotalCostings.Size = new System.Drawing.Size(928, 80);
            this._grpTotalCostings.TabIndex = 7;
            this._grpTotalCostings.TabStop = false;
            // 
            // _Label41
            // 
            this._Label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label41.AutoSize = true;
            this._Label41.Location = new System.Drawing.Point(510, 11);
            this._Label41.Name = "_Label41";
            this._Label41.Size = new System.Drawing.Size(67, 13);
            this._Label41.TabIndex = 13;
            this._Label41.Text = "SOR Sales";
            // 
            // _txtSorTotal
            // 
            this._txtSorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSorTotal.Location = new System.Drawing.Point(500, 30);
            this._txtSorTotal.Name = "_txtSorTotal";
            this._txtSorTotal.Size = new System.Drawing.Size(100, 21);
            this._txtSorTotal.TabIndex = 14;
            // 
            // _Label32
            // 
            this._Label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label32.AutoSize = true;
            this._Label32.Location = new System.Drawing.Point(748, 47);
            this._Label32.Name = "_Label32";
            this._Label32.Size = new System.Drawing.Size(53, 13);
            this._Label32.TabIndex = 11;
            this._Label32.Text = "Profit %";
            // 
            // _Label33
            // 
            this._Label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label33.AutoSize = true;
            this._Label33.Location = new System.Drawing.Point(748, 20);
            this._Label33.Name = "_Label33";
            this._Label33.Size = new System.Drawing.Size(48, 13);
            this._Label33.TabIndex = 9;
            this._Label33.Text = "Profit £";
            // 
            // _txtProfitPerc
            // 
            this._txtProfitPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProfitPerc.Location = new System.Drawing.Point(806, 41);
            this._txtProfitPerc.Name = "_txtProfitPerc";
            this._txtProfitPerc.Size = new System.Drawing.Size(100, 21);
            this._txtProfitPerc.TabIndex = 12;
            // 
            // _TxtProfitPounds
            // 
            this._TxtProfitPounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtProfitPounds.Location = new System.Drawing.Point(806, 14);
            this._TxtProfitPounds.Name = "_TxtProfitPounds";
            this._TxtProfitPounds.Size = new System.Drawing.Size(100, 21);
            this._TxtProfitPounds.TabIndex = 10;
            // 
            // _lbl5
            // 
            this._lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lbl5.AutoSize = true;
            this._lbl5.Location = new System.Drawing.Point(632, 11);
            this._lbl5.Name = "_lbl5";
            this._lbl5.Size = new System.Drawing.Size(74, 13);
            this._lbl5.TabIndex = 7;
            this._lbl5.Text = "Other Sales";
            // 
            // _Label34
            // 
            this._Label34.AutoSize = true;
            this._Label34.Location = new System.Drawing.Point(36, 11);
            this._Label34.Name = "_Label34";
            this._Label34.Size = new System.Drawing.Size(39, 13);
            this._Label34.TabIndex = 3;
            this._Label34.Text = "Costs";
            // 
            // _txtSales
            // 
            this._txtSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSales.Location = new System.Drawing.Point(622, 30);
            this._txtSales.Name = "_txtSales";
            this._txtSales.Size = new System.Drawing.Size(100, 21);
            this._txtSales.TabIndex = 8;
            // 
            // _txtCosts
            // 
            this._txtCosts.Location = new System.Drawing.Point(9, 30);
            this._txtCosts.Name = "_txtCosts";
            this._txtCosts.Size = new System.Drawing.Size(100, 21);
            this._txtCosts.TabIndex = 6;
            // 
            // _grpPartCostings
            // 
            this._grpPartCostings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpPartCostings.BackColor = System.Drawing.Color.White;
            this._grpPartCostings.Controls.Add(this._Label43);
            this._grpPartCostings.Controls.Add(this._txtPartPerc);
            this._grpPartCostings.Controls.Add(this._Label42);
            this._grpPartCostings.Controls.Add(this._txtLabourPerc);
            this._grpPartCostings.Controls.Add(this._dgScheduleOfRateCharges);
            this._grpPartCostings.Controls.Add(this._dgPartsProductCharging);
            this._grpPartCostings.Controls.Add(this._Label40);
            this._grpPartCostings.Controls.Add(this._TextBox2);
            this._grpPartCostings.Controls.Add(this._Label39);
            this._grpPartCostings.Controls.Add(this._txtSORSales);
            this._grpPartCostings.Controls.Add(this._dgTimesheetCharges);
            this._grpPartCostings.Controls.Add(this._Label35);
            this._grpPartCostings.Controls.Add(this._Label36);
            this._grpPartCostings.Controls.Add(this._Label37);
            this._grpPartCostings.Controls.Add(this._Label38);
            this._grpPartCostings.Controls.Add(this._lbl1);
            this._grpPartCostings.Controls.Add(this._txtPartCost);
            this._grpPartCostings.Controls.Add(this._txtLabourCost);
            this._grpPartCostings.Location = new System.Drawing.Point(4, 3);
            this._grpPartCostings.Name = "_grpPartCostings";
            this._grpPartCostings.Size = new System.Drawing.Size(928, 468);
            this._grpPartCostings.TabIndex = 6;
            this._grpPartCostings.TabStop = false;
            this._grpPartCostings.Text = "Job Profit/Loss";
            // 
            // _Label43
            // 
            this._Label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label43.AutoSize = true;
            this._Label43.Location = new System.Drawing.Point(824, 408);
            this._Label43.Name = "_Label43";
            this._Label43.Size = new System.Drawing.Size(46, 13);
            this._Label43.TabIndex = 24;
            this._Label43.Text = "Part %";
            // 
            // _txtPartPerc
            // 
            this._txtPartPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartPerc.Location = new System.Drawing.Point(806, 427);
            this._txtPartPerc.Name = "_txtPartPerc";
            this._txtPartPerc.Size = new System.Drawing.Size(100, 21);
            this._txtPartPerc.TabIndex = 23;
            // 
            // _Label42
            // 
            this._Label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label42.AutoSize = true;
            this._Label42.Location = new System.Drawing.Point(817, 255);
            this._Label42.Name = "_Label42";
            this._Label42.Size = new System.Drawing.Size(62, 13);
            this._Label42.TabIndex = 22;
            this._Label42.Text = "Labour %";
            // 
            // _txtLabourPerc
            // 
            this._txtLabourPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLabourPerc.Location = new System.Drawing.Point(806, 276);
            this._txtLabourPerc.Name = "_txtLabourPerc";
            this._txtLabourPerc.Size = new System.Drawing.Size(100, 21);
            this._txtLabourPerc.TabIndex = 21;
            // 
            // _dgScheduleOfRateCharges
            // 
            this._dgScheduleOfRateCharges.DataMember = "";
            this._dgScheduleOfRateCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgScheduleOfRateCharges.Location = new System.Drawing.Point(9, 35);
            this._dgScheduleOfRateCharges.Name = "_dgScheduleOfRateCharges";
            this._dgScheduleOfRateCharges.Size = new System.Drawing.Size(779, 118);
            this._dgScheduleOfRateCharges.TabIndex = 20;
            // 
            // _dgPartsProductCharging
            // 
            this._dgPartsProductCharging.DataMember = "";
            this._dgPartsProductCharging.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsProductCharging.Location = new System.Drawing.Point(9, 348);
            this._dgPartsProductCharging.Name = "_dgPartsProductCharging";
            this._dgPartsProductCharging.Size = new System.Drawing.Size(779, 100);
            this._dgPartsProductCharging.TabIndex = 19;
            // 
            // _Label40
            // 
            this._Label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label40.AutoSize = true;
            this._Label40.Location = new System.Drawing.Point(817, 33);
            this._Label40.Name = "_Label40";
            this._Label40.Size = new System.Drawing.Size(53, 13);
            this._Label40.TabIndex = 18;
            this._Label40.Text = "SOR Est";
            this._Label40.Visible = false;
            // 
            // _TextBox2
            // 
            this._TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._TextBox2.Location = new System.Drawing.Point(806, 54);
            this._TextBox2.Name = "_TextBox2";
            this._TextBox2.Size = new System.Drawing.Size(100, 21);
            this._TextBox2.TabIndex = 17;
            this._TextBox2.Visible = false;
            // 
            // _Label39
            // 
            this._Label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label39.AutoSize = true;
            this._Label39.Location = new System.Drawing.Point(817, 111);
            this._Label39.Name = "_Label39";
            this._Label39.Size = new System.Drawing.Size(67, 13);
            this._Label39.TabIndex = 16;
            this._Label39.Text = "SOR Sales";
            // 
            // _txtSORSales
            // 
            this._txtSORSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSORSales.Location = new System.Drawing.Point(806, 132);
            this._txtSORSales.Name = "_txtSORSales";
            this._txtSORSales.Size = new System.Drawing.Size(100, 21);
            this._txtSORSales.TabIndex = 15;
            // 
            // _dgTimesheetCharges
            // 
            this._dgTimesheetCharges.DataMember = "";
            this._dgTimesheetCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgTimesheetCharges.Location = new System.Drawing.Point(9, 205);
            this._dgTimesheetCharges.Name = "_dgTimesheetCharges";
            this._dgTimesheetCharges.Size = new System.Drawing.Size(779, 92);
            this._dgTimesheetCharges.TabIndex = 14;
            // 
            // _Label35
            // 
            this._Label35.AutoSize = true;
            this._Label35.Location = new System.Drawing.Point(6, 19);
            this._Label35.Name = "_Label35";
            this._Label35.Size = new System.Drawing.Size(87, 13);
            this._Label35.TabIndex = 13;
            this._Label35.Text = "SOR\'s Applied";
            // 
            // _Label36
            // 
            this._Label36.AutoSize = true;
            this._Label36.Location = new System.Drawing.Point(6, 332);
            this._Label36.Name = "_Label36";
            this._Label36.Size = new System.Drawing.Size(72, 13);
            this._Label36.TabIndex = 11;
            this._Label36.Text = "Parts Costs";
            // 
            // _Label37
            // 
            this._Label37.AutoSize = true;
            this._Label37.Location = new System.Drawing.Point(6, 189);
            this._Label37.Name = "_Label37";
            this._Label37.Size = new System.Drawing.Size(82, 13);
            this._Label37.TabIndex = 9;
            this._Label37.Text = "Labour Costs";
            // 
            // _Label38
            // 
            this._Label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label38.AutoSize = true;
            this._Label38.Location = new System.Drawing.Point(824, 353);
            this._Label38.Name = "_Label38";
            this._Label38.Size = new System.Drawing.Size(66, 13);
            this._Label38.TabIndex = 2;
            this._Label38.Text = "Part Costs";
            // 
            // _lbl1
            // 
            this._lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lbl1.AutoSize = true;
            this._lbl1.Location = new System.Drawing.Point(817, 205);
            this._lbl1.Name = "_lbl1";
            this._lbl1.Size = new System.Drawing.Size(82, 13);
            this._lbl1.TabIndex = 1;
            this._lbl1.Text = "Labour Costs";
            // 
            // _txtPartCost
            // 
            this._txtPartCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartCost.Location = new System.Drawing.Point(806, 372);
            this._txtPartCost.Name = "_txtPartCost";
            this._txtPartCost.Size = new System.Drawing.Size(100, 21);
            this._txtPartCost.TabIndex = 1;
            // 
            // _txtLabourCost
            // 
            this._txtLabourCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLabourCost.Location = new System.Drawing.Point(806, 226);
            this._txtLabourCost.Name = "_txtLabourCost";
            this._txtLabourCost.Size = new System.Drawing.Size(100, 21);
            this._txtLabourCost.TabIndex = 0;
            // 
            // _tpInstall
            // 
            this._tpInstall.Controls.Add(this._GroupBox1);
            this._tpInstall.Location = new System.Drawing.Point(4, 22);
            this._tpInstall.Name = "_tpInstall";
            this._tpInstall.Size = new System.Drawing.Size(934, 601);
            this._tpInstall.TabIndex = 6;
            this._tpInstall.Text = "Installation Data";
            this._tpInstall.UseVisualStyleBackColor = true;
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._txtManual);
            this._GroupBox1.Controls.Add(this._Label31);
            this._GroupBox1.Controls.Add(this._txtEstSub);
            this._GroupBox1.Controls.Add(this._txtActSub);
            this._GroupBox1.Controls.Add(this._Label29);
            this._GroupBox1.Controls.Add(this._Label30);
            this._GroupBox1.Controls.Add(this._Label28);
            this._GroupBox1.Controls.Add(this._Label27);
            this._GroupBox1.Controls.Add(this._txtSupplierInv);
            this._GroupBox1.Controls.Add(this._Label26);
            this._GroupBox1.Controls.Add(this._Label25);
            this._GroupBox1.Controls.Add(this._Label24);
            this._GroupBox1.Controls.Add(this._Label23);
            this._GroupBox1.Controls.Add(this._txtEstElec);
            this._GroupBox1.Controls.Add(this._txtActElec);
            this._GroupBox1.Controls.Add(this._Label21);
            this._GroupBox1.Controls.Add(this._Label22);
            this._GroupBox1.Controls.Add(this._txtQuotedGross);
            this._GroupBox1.Controls.Add(this._txtDepositGross);
            this._GroupBox1.Controls.Add(this._txtQuoted);
            this._GroupBox1.Controls.Add(this._lblQuoted);
            this._GroupBox1.Controls.Add(this._txtProfitActPerc);
            this._GroupBox1.Controls.Add(this._Label18);
            this._GroupBox1.Controls.Add(this._txtProfitEstPerc);
            this._GroupBox1.Controls.Add(this._Label16);
            this._GroupBox1.Controls.Add(this._txtProfitActMoney);
            this._GroupBox1.Controls.Add(this._Label15);
            this._GroupBox1.Controls.Add(this._txtProfitEstMoney);
            this._GroupBox1.Controls.Add(this._Label14);
            this._GroupBox1.Controls.Add(this._txtTotalEst);
            this._GroupBox1.Controls.Add(this._txtTotalAct);
            this._GroupBox1.Controls.Add(this._Label12);
            this._GroupBox1.Controls.Add(this._Label13);
            this._GroupBox1.Controls.Add(this._txtEstLabour);
            this._GroupBox1.Controls.Add(this._txtActLabour);
            this._GroupBox1.Controls.Add(this._Label5);
            this._GroupBox1.Controls.Add(this._Label17);
            this._GroupBox1.Controls.Add(this._txtPartEst);
            this._GroupBox1.Controls.Add(this._txtPartAct);
            this._GroupBox1.Controls.Add(this._Label19);
            this._GroupBox1.Controls.Add(this._Label20);
            this._GroupBox1.Controls.Add(this._Label11);
            this._GroupBox1.Controls.Add(this._cboPaperwork);
            this._GroupBox1.Controls.Add(this._Label10);
            this._GroupBox1.Controls.Add(this._cboQC);
            this._GroupBox1.Controls.Add(this._txtPayment);
            this._GroupBox1.Controls.Add(this._Label9);
            this._GroupBox1.Controls.Add(this._Label8);
            this._GroupBox1.Controls.Add(this._cboFurtherWorks);
            this._GroupBox1.Controls.Add(this._Label7);
            this._GroupBox1.Controls.Add(this._cboExtraLabour);
            this._GroupBox1.Controls.Add(this._txtPO);
            this._GroupBox1.Controls.Add(this._Label6);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._cboCalledSuper);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._cboSurveyed);
            this._GroupBox1.Controls.Add(this._txtDeposit);
            this._GroupBox1.Controls.Add(this._Label2);
            this._GroupBox1.Location = new System.Drawing.Point(0, 3);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(926, 599);
            this._GroupBox1.TabIndex = 34;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Details";
            // 
            // _txtManual
            // 
            this._txtManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtManual.Location = new System.Drawing.Point(668, 353);
            this._txtManual.Name = "_txtManual";
            this._txtManual.Size = new System.Drawing.Size(214, 21);
            this._txtManual.TabIndex = 112;
            this._txtManual.TabStop = false;
            this._txtManual.Text = "0";
            this._txtManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtManual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtManual_TextChanged);
            // 
            // _Label31
            // 
            this._Label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label31.Location = new System.Drawing.Point(500, 356);
            this._Label31.Name = "_Label31";
            this._Label31.Size = new System.Drawing.Size(147, 23);
            this._Label31.TabIndex = 111;
            this._Label31.Text = "Manual Adjustment";
            // 
            // _txtEstSub
            // 
            this._txtEstSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEstSub.Location = new System.Drawing.Point(668, 276);
            this._txtEstSub.Name = "_txtEstSub";
            this._txtEstSub.Size = new System.Drawing.Size(214, 21);
            this._txtEstSub.TabIndex = 110;
            this._txtEstSub.TabStop = false;
            this._txtEstSub.Text = "0";
            this._txtEstSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtEstSub.TextChanged += new System.EventHandler(this.txtEstSub_TextChanged);
            // 
            // _txtActSub
            // 
            this._txtActSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtActSub.Location = new System.Drawing.Point(668, 306);
            this._txtActSub.Name = "_txtActSub";
            this._txtActSub.ReadOnly = true;
            this._txtActSub.Size = new System.Drawing.Size(214, 21);
            this._txtActSub.TabIndex = 109;
            this._txtActSub.TabStop = false;
            this._txtActSub.Text = "0";
            this._txtActSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label29
            // 
            this._Label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label29.Location = new System.Drawing.Point(500, 279);
            this._Label29.Name = "_Label29";
            this._Label29.Size = new System.Drawing.Size(147, 23);
            this._Label29.TabIndex = 108;
            this._Label29.Text = "Est SubContractor Cost";
            // 
            // _Label30
            // 
            this._Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label30.Location = new System.Drawing.Point(500, 309);
            this._Label30.Name = "_Label30";
            this._Label30.Size = new System.Drawing.Size(147, 23);
            this._Label30.TabIndex = 107;
            this._Label30.Text = "Act SubContractor Cost";
            // 
            // _Label28
            // 
            this._Label28.Location = new System.Drawing.Point(683, 65);
            this._Label28.Name = "_Label28";
            this._Label28.Size = new System.Drawing.Size(86, 19);
            this._Label28.TabIndex = 106;
            this._Label28.Text = "PO Value";
            // 
            // _Label27
            // 
            this._Label27.Location = new System.Drawing.Point(796, 62);
            this._Label27.Name = "_Label27";
            this._Label27.Size = new System.Drawing.Size(86, 19);
            this._Label27.TabIndex = 105;
            this._Label27.Text = "Supplier Inv";
            // 
            // _txtSupplierInv
            // 
            this._txtSupplierInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplierInv.Location = new System.Drawing.Point(781, 84);
            this._txtSupplierInv.Name = "_txtSupplierInv";
            this._txtSupplierInv.ReadOnly = true;
            this._txtSupplierInv.Size = new System.Drawing.Size(101, 21);
            this._txtSupplierInv.TabIndex = 104;
            this._txtSupplierInv.TabStop = false;
            this._txtSupplierInv.Text = "0";
            this._txtSupplierInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label26
            // 
            this._Label26.Location = new System.Drawing.Point(223, 122);
            this._Label26.Name = "_Label26";
            this._Label26.Size = new System.Drawing.Size(61, 18);
            this._Label26.TabIndex = 103;
            this._Label26.Text = "Nett";
            // 
            // _Label25
            // 
            this._Label25.Location = new System.Drawing.Point(223, 63);
            this._Label25.Name = "_Label25";
            this._Label25.Size = new System.Drawing.Size(61, 14);
            this._Label25.TabIndex = 102;
            this._Label25.Text = "Nett";
            // 
            // _Label24
            // 
            this._Label24.Location = new System.Drawing.Point(323, 62);
            this._Label24.Name = "_Label24";
            this._Label24.Size = new System.Drawing.Size(61, 19);
            this._Label24.TabIndex = 101;
            this._Label24.Text = "Gross";
            // 
            // _Label23
            // 
            this._Label23.Location = new System.Drawing.Point(323, 122);
            this._Label23.Name = "_Label23";
            this._Label23.Size = new System.Drawing.Size(61, 18);
            this._Label23.TabIndex = 100;
            this._Label23.Text = "Gross";
            // 
            // _txtEstElec
            // 
            this._txtEstElec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEstElec.Location = new System.Drawing.Point(668, 127);
            this._txtEstElec.Name = "_txtEstElec";
            this._txtEstElec.Size = new System.Drawing.Size(214, 21);
            this._txtEstElec.TabIndex = 99;
            this._txtEstElec.TabStop = false;
            this._txtEstElec.Text = "0";
            this._txtEstElec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtEstElec.TextChanged += new System.EventHandler(this.txtEstElectrical_TextChanged);
            // 
            // _txtActElec
            // 
            this._txtActElec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtActElec.Location = new System.Drawing.Point(668, 157);
            this._txtActElec.Name = "_txtActElec";
            this._txtActElec.ReadOnly = true;
            this._txtActElec.Size = new System.Drawing.Size(214, 21);
            this._txtActElec.TabIndex = 98;
            this._txtActElec.TabStop = false;
            this._txtActElec.Text = "0";
            this._txtActElec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label21
            // 
            this._Label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label21.Location = new System.Drawing.Point(500, 133);
            this._Label21.Name = "_Label21";
            this._Label21.Size = new System.Drawing.Size(116, 23);
            this._Label21.TabIndex = 97;
            this._Label21.Text = "Est Electrical Cost";
            // 
            // _Label22
            // 
            this._Label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label22.Location = new System.Drawing.Point(500, 163);
            this._Label22.Name = "_Label22";
            this._Label22.Size = new System.Drawing.Size(131, 23);
            this._Label22.TabIndex = 96;
            this._Label22.Text = "Act Electrical Cost";
            // 
            // _txtQuotedGross
            // 
            this._txtQuotedGross.Location = new System.Drawing.Point(304, 84);
            this._txtQuotedGross.Name = "_txtQuotedGross";
            this._txtQuotedGross.Size = new System.Drawing.Size(97, 21);
            this._txtQuotedGross.TabIndex = 95;
            this._txtQuotedGross.TabStop = false;
            this._txtQuotedGross.Text = "0";
            this._txtQuotedGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtQuotedGross.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuotedGross_TextChanged);
            // 
            // _txtDepositGross
            // 
            this._txtDepositGross.Location = new System.Drawing.Point(304, 141);
            this._txtDepositGross.Name = "_txtDepositGross";
            this._txtDepositGross.Size = new System.Drawing.Size(97, 21);
            this._txtDepositGross.TabIndex = 94;
            this._txtDepositGross.TabStop = false;
            this._txtDepositGross.Text = "0";
            this._txtDepositGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtDepositGross.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDepositGross_TextChanged);
            // 
            // _txtQuoted
            // 
            this._txtQuoted.Location = new System.Drawing.Point(187, 84);
            this._txtQuoted.Name = "_txtQuoted";
            this._txtQuoted.Size = new System.Drawing.Size(97, 21);
            this._txtQuoted.TabIndex = 93;
            this._txtQuoted.TabStop = false;
            this._txtQuoted.Text = "0";
            this._txtQuoted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtQuoted.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox1_TextChanged);
            // 
            // _lblQuoted
            // 
            this._lblQuoted.Location = new System.Drawing.Point(17, 90);
            this._lblQuoted.Name = "_lblQuoted";
            this._lblQuoted.Size = new System.Drawing.Size(121, 23);
            this._lblQuoted.TabIndex = 92;
            this._lblQuoted.Text = "Amount Quoted";
            // 
            // _txtProfitActPerc
            // 
            this._txtProfitActPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProfitActPerc.Location = new System.Drawing.Point(670, 551);
            this._txtProfitActPerc.Name = "_txtProfitActPerc";
            this._txtProfitActPerc.ReadOnly = true;
            this._txtProfitActPerc.Size = new System.Drawing.Size(214, 21);
            this._txtProfitActPerc.TabIndex = 91;
            this._txtProfitActPerc.TabStop = false;
            this._txtProfitActPerc.Text = "0";
            this._txtProfitActPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label18
            // 
            this._Label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label18.Location = new System.Drawing.Point(500, 554);
            this._Label18.Name = "_Label18";
            this._Label18.Size = new System.Drawing.Size(116, 23);
            this._Label18.TabIndex = 90;
            this._Label18.Text = "Act Profit %";
            // 
            // _txtProfitEstPerc
            // 
            this._txtProfitEstPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProfitEstPerc.Location = new System.Drawing.Point(670, 524);
            this._txtProfitEstPerc.Name = "_txtProfitEstPerc";
            this._txtProfitEstPerc.ReadOnly = true;
            this._txtProfitEstPerc.Size = new System.Drawing.Size(214, 21);
            this._txtProfitEstPerc.TabIndex = 89;
            this._txtProfitEstPerc.TabStop = false;
            this._txtProfitEstPerc.Text = "0";
            this._txtProfitEstPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label16
            // 
            this._Label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label16.Location = new System.Drawing.Point(500, 527);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(116, 23);
            this._Label16.TabIndex = 88;
            this._Label16.Text = "Est Profit %";
            // 
            // _txtProfitActMoney
            // 
            this._txtProfitActMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProfitActMoney.Location = new System.Drawing.Point(670, 485);
            this._txtProfitActMoney.Name = "_txtProfitActMoney";
            this._txtProfitActMoney.ReadOnly = true;
            this._txtProfitActMoney.Size = new System.Drawing.Size(214, 21);
            this._txtProfitActMoney.TabIndex = 87;
            this._txtProfitActMoney.TabStop = false;
            this._txtProfitActMoney.Text = "0";
            this._txtProfitActMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label15
            // 
            this._Label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label15.Location = new System.Drawing.Point(500, 488);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(116, 23);
            this._Label15.TabIndex = 86;
            this._Label15.Text = "Act Profit £";
            // 
            // _txtProfitEstMoney
            // 
            this._txtProfitEstMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProfitEstMoney.Location = new System.Drawing.Point(670, 458);
            this._txtProfitEstMoney.Name = "_txtProfitEstMoney";
            this._txtProfitEstMoney.ReadOnly = true;
            this._txtProfitEstMoney.Size = new System.Drawing.Size(214, 21);
            this._txtProfitEstMoney.TabIndex = 85;
            this._txtProfitEstMoney.TabStop = false;
            this._txtProfitEstMoney.Text = "0";
            this._txtProfitEstMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label14
            // 
            this._Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label14.Location = new System.Drawing.Point(500, 461);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(116, 23);
            this._Label14.TabIndex = 84;
            this._Label14.Text = "Est Profit £";
            // 
            // _txtTotalEst
            // 
            this._txtTotalEst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTotalEst.Location = new System.Drawing.Point(670, 396);
            this._txtTotalEst.Name = "_txtTotalEst";
            this._txtTotalEst.ReadOnly = true;
            this._txtTotalEst.Size = new System.Drawing.Size(214, 21);
            this._txtTotalEst.TabIndex = 83;
            this._txtTotalEst.TabStop = false;
            this._txtTotalEst.Text = "0";
            this._txtTotalEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtTotalAct
            // 
            this._txtTotalAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTotalAct.Location = new System.Drawing.Point(670, 426);
            this._txtTotalAct.Name = "_txtTotalAct";
            this._txtTotalAct.ReadOnly = true;
            this._txtTotalAct.Size = new System.Drawing.Size(214, 21);
            this._txtTotalAct.TabIndex = 82;
            this._txtTotalAct.TabStop = false;
            this._txtTotalAct.Text = "0";
            this._txtTotalAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label12
            // 
            this._Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label12.Location = new System.Drawing.Point(502, 397);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(116, 23);
            this._Label12.TabIndex = 81;
            this._Label12.Text = "Est Total Cost";
            // 
            // _Label13
            // 
            this._Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label13.Location = new System.Drawing.Point(502, 427);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(116, 23);
            this._Label13.TabIndex = 80;
            this._Label13.Text = "Act total Cost";
            // 
            // _txtEstLabour
            // 
            this._txtEstLabour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEstLabour.Location = new System.Drawing.Point(668, 201);
            this._txtEstLabour.Name = "_txtEstLabour";
            this._txtEstLabour.Size = new System.Drawing.Size(214, 21);
            this._txtEstLabour.TabIndex = 79;
            this._txtEstLabour.TabStop = false;
            this._txtEstLabour.Text = "0";
            this._txtEstLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtEstLabour.TextChanged += new System.EventHandler(this.txtEstLabour_TextChanged);
            // 
            // _txtActLabour
            // 
            this._txtActLabour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtActLabour.Location = new System.Drawing.Point(668, 231);
            this._txtActLabour.Name = "_txtActLabour";
            this._txtActLabour.ReadOnly = true;
            this._txtActLabour.Size = new System.Drawing.Size(214, 21);
            this._txtActLabour.TabIndex = 78;
            this._txtActLabour.TabStop = false;
            this._txtActLabour.Text = "0";
            this._txtActLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label5
            // 
            this._Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label5.Location = new System.Drawing.Point(500, 204);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(116, 23);
            this._Label5.TabIndex = 77;
            this._Label5.Text = "Est Labour Cost";
            // 
            // _Label17
            // 
            this._Label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label17.Location = new System.Drawing.Point(500, 234);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(116, 23);
            this._Label17.TabIndex = 76;
            this._Label17.Text = "Act Labour Cost";
            // 
            // _txtPartEst
            // 
            this._txtPartEst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartEst.Location = new System.Drawing.Point(670, 37);
            this._txtPartEst.Name = "_txtPartEst";
            this._txtPartEst.Size = new System.Drawing.Size(214, 21);
            this._txtPartEst.TabIndex = 75;
            this._txtPartEst.TabStop = false;
            this._txtPartEst.Text = "0";
            this._txtPartEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtPartEst.TextChanged += new System.EventHandler(this.txtPartEst_TextChanged);
            // 
            // _txtPartAct
            // 
            this._txtPartAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartAct.Location = new System.Drawing.Point(670, 84);
            this._txtPartAct.Name = "_txtPartAct";
            this._txtPartAct.ReadOnly = true;
            this._txtPartAct.Size = new System.Drawing.Size(99, 21);
            this._txtPartAct.TabIndex = 64;
            this._txtPartAct.TabStop = false;
            this._txtPartAct.Text = "0";
            this._txtPartAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label19
            // 
            this._Label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label19.Location = new System.Drawing.Point(500, 40);
            this._Label19.Name = "_Label19";
            this._Label19.Size = new System.Drawing.Size(88, 23);
            this._Label19.TabIndex = 60;
            this._Label19.Text = "Est Part Cost";
            // 
            // _Label20
            // 
            this._Label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label20.Location = new System.Drawing.Point(498, 87);
            this._Label20.Name = "_Label20";
            this._Label20.Size = new System.Drawing.Size(88, 23);
            this._Label20.TabIndex = 57;
            this._Label20.Text = "Act Part Cost";
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(17, 342);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(134, 23);
            this._Label11.TabIndex = 56;
            this._Label11.Text = "Paperwork Returned";
            // 
            // _cboPaperwork
            // 
            this._cboPaperwork.FormattingEnabled = true;
            this._cboPaperwork.Location = new System.Drawing.Point(187, 336);
            this._cboPaperwork.Name = "_cboPaperwork";
            this._cboPaperwork.Size = new System.Drawing.Size(214, 21);
            this._cboPaperwork.TabIndex = 55;
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(17, 307);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(134, 23);
            this._Label10.TabIndex = 54;
            this._Label10.Text = "QC Carried Out";
            // 
            // _cboQC
            // 
            this._cboQC.FormattingEnabled = true;
            this._cboQC.Location = new System.Drawing.Point(187, 304);
            this._cboQC.Name = "_cboQC";
            this._cboQC.Size = new System.Drawing.Size(214, 21);
            this._cboQC.TabIndex = 53;
            // 
            // _txtPayment
            // 
            this._txtPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._txtPayment.Location = new System.Drawing.Point(187, 276);
            this._txtPayment.Name = "_txtPayment";
            this._txtPayment.ReadOnly = true;
            this._txtPayment.Size = new System.Drawing.Size(214, 21);
            this._txtPayment.TabIndex = 51;
            this._txtPayment.TabStop = false;
            this._txtPayment.Text = "0";
            this._txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(17, 282);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(134, 23);
            this._Label9.TabIndex = 50;
            this._Label9.Text = "Payment Taken";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(17, 255);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(134, 23);
            this._Label8.TabIndex = 48;
            this._Label8.Text = "Further Works Noted";
            // 
            // _cboFurtherWorks
            // 
            this._cboFurtherWorks.FormattingEnabled = true;
            this._cboFurtherWorks.Location = new System.Drawing.Point(187, 249);
            this._cboFurtherWorks.Name = "_cboFurtherWorks";
            this._cboFurtherWorks.Size = new System.Drawing.Size(214, 21);
            this._cboFurtherWorks.TabIndex = 47;
            // 
            // _Label7
            // 
            this._Label7.Location = new System.Drawing.Point(17, 228);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(134, 23);
            this._Label7.TabIndex = 46;
            this._Label7.Text = "Extra Labour Noted";
            // 
            // _cboExtraLabour
            // 
            this._cboExtraLabour.FormattingEnabled = true;
            this._cboExtraLabour.Location = new System.Drawing.Point(187, 222);
            this._cboExtraLabour.Name = "_cboExtraLabour";
            this._cboExtraLabour.Size = new System.Drawing.Size(214, 21);
            this._cboExtraLabour.TabIndex = 45;
            // 
            // _txtPO
            // 
            this._txtPO.Location = new System.Drawing.Point(187, 168);
            this._txtPO.Name = "_txtPO";
            this._txtPO.ReadOnly = true;
            this._txtPO.Size = new System.Drawing.Size(214, 21);
            this._txtPO.TabIndex = 44;
            this._txtPO.TabStop = false;
            this._txtPO.Text = "0";
            this._txtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(17, 174);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 23);
            this._Label6.TabIndex = 43;
            this._Label6.Text = "PO Status";
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(17, 201);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(134, 23);
            this._Label4.TabIndex = 40;
            this._Label4.Text = "Eng Called Supervisor";
            // 
            // _cboCalledSuper
            // 
            this._cboCalledSuper.FormattingEnabled = true;
            this._cboCalledSuper.Location = new System.Drawing.Point(187, 195);
            this._cboCalledSuper.Name = "_cboCalledSuper";
            this._cboCalledSuper.Size = new System.Drawing.Size(214, 21);
            this._cboCalledSuper.TabIndex = 39;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(20, 35);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(88, 23);
            this._Label3.TabIndex = 38;
            this._Label3.Text = "Surveyed by";
            // 
            // _cboSurveyed
            // 
            this._cboSurveyed.FormattingEnabled = true;
            this._cboSurveyed.Location = new System.Drawing.Point(187, 32);
            this._cboSurveyed.Name = "_cboSurveyed";
            this._cboSurveyed.Size = new System.Drawing.Size(214, 21);
            this._cboSurveyed.TabIndex = 37;
            // 
            // _txtDeposit
            // 
            this._txtDeposit.Location = new System.Drawing.Point(187, 141);
            this._txtDeposit.Name = "_txtDeposit";
            this._txtDeposit.Size = new System.Drawing.Size(97, 21);
            this._txtDeposit.TabIndex = 36;
            this._txtDeposit.TabStop = false;
            this._txtDeposit.Text = "0";
            this._txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtDeposit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDeposit_TextChanged);
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(17, 147);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(88, 23);
            this._Label2.TabIndex = 34;
            this._Label2.Text = "Deposit Taken";
            // 
            // _btnPrintJobCosting
            // 
            this._btnPrintJobCosting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrintJobCosting.Location = new System.Drawing.Point(822, 664);
            this._btnPrintJobCosting.Name = "_btnPrintJobCosting";
            this._btnPrintJobCosting.Size = new System.Drawing.Size(114, 23);
            this._btnPrintJobCosting.TabIndex = 25;
            this._btnPrintJobCosting.Text = "Print Job Costing";
            this._btnPrintJobCosting.UseVisualStyleBackColor = true;
            this._btnPrintJobCosting.Click += new System.EventHandler(this.btnPrintJobCosting_Click);
            // 
            // FRMJobCostings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(942, 690);
            this.ControlBox = false;
            this.Controls.Add(this._btnPrintJobCosting);
            this.Controls.Add(this._TabControl1);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 724);
            this.Name = "FRMJobCostings";
            this.Text = "Job";
            this._TabControl1.ResumeLayout(false);
            this._tpJobCostings.ResumeLayout(false);
            this._grpTotalCostings.ResumeLayout(false);
            this._grpTotalCostings.PerformLayout();
            this._grpPartCostings.ResumeLayout(false);
            this._grpPartCostings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgScheduleOfRateCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsProductCharging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheetCharges)).EndInit();
            this._tpInstall.ResumeLayout(false);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadMe(object sender, EventArgs e)
        {
            if (CurrentJob.JobTypeID != 521)
            {
                TabControl1.TabPages.Remove(tpInstall);
            }

            var argc = cboSurveyed;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Surveyor, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboCalledSuper;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboExtraLabour;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc3 = cboFurtherWorks;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc4 = cboQC;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc5 = cboPaperwork;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            SetupJobInstall();
            CalculatePL();
        }

        private int vatRateID;
        private Entity.VATRatess.VATRates vatRate = new Entity.VATRatess.VATRates();
        private DataView _TimeSheetCharges;

        private DataView TimeSheetCharges
        {
            get
            {
                return _TimeSheetCharges;
            }

            set
            {
                _TimeSheetCharges = value;
                _TimeSheetCharges.AllowNew = false;
                _TimeSheetCharges.AllowEdit = true;
                _TimeSheetCharges.AllowDelete = false;
                _TimeSheetCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
                dgTimesheetCharges.DataSource = TimeSheetCharges;
            }
        }

        private DataView _ScheduleOfRateCharges;

        private DataView ScheduleOfRateCharges
        {
            get
            {
                return _ScheduleOfRateCharges;
            }

            set
            {
                _ScheduleOfRateCharges = value;
                _ScheduleOfRateCharges.AllowNew = false;
                _ScheduleOfRateCharges.AllowEdit = true;
                _ScheduleOfRateCharges.AllowDelete = false;
                _ScheduleOfRateCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
                dgScheduleOfRateCharges.DataSource = ScheduleOfRateCharges;
            }
        }

        private DataView _PartProductsCharges;

        private DataView PartProductsCharges
        {
            get
            {
                return _PartProductsCharges;
            }

            set
            {
                _PartProductsCharges = value;
                _PartProductsCharges.AllowNew = false;
                _PartProductsCharges.AllowEdit = false;
                _PartProductsCharges.AllowDelete = false;
                _PartProductsCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
                dgPartsProductCharging.DataSource = PartProductsCharges;
            }
        }

        private Entity.Jobs.Job _CurrentJob = null;

        public Entity.Jobs.Job CurrentJob
        {
            get
            {
                return _CurrentJob;
            }

            set
            {
                _CurrentJob = value;
                if (_CurrentJob is null)
                {
                    _CurrentJob = new Entity.Jobs.Job();
                    _CurrentJob.Exists = false;
                }
            }
        }

        private Entity.JobInstalls.JobInstall _JI;

        private Entity.JobInstalls.JobInstall JI
        {
            get
            {
                return _JI;
            }

            set
            {
                _JI = value;
            }
        }

        public void SetupTimeSheetChargeDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgTimesheetCharges);
            var tStyle = dgTimesheetCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgTimesheetCharges.ReadOnly = false;
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Start ";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 95;
            StartDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dd/MM/yy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "End";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 95;
            EndDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(EndDateTime);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "C";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "Eng. Cost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 80;
            EngineerCost.NullText = "";
            tStyle.GridColumnStyles.Add(EngineerCost);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 60;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Summary = new DataGridLabelColumn();
            Summary.Format = "";
            Summary.FormatInfo = null;
            Summary.HeaderText = "Summary";
            Summary.MappingName = "Summary";
            Summary.ReadOnly = true;
            Summary.Width = 500;
            Summary.NullText = "";
            tStyle.GridColumnStyles.Add(Summary);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
            dgTimesheetCharges.TableStyles.Add(tStyle);
        }

        public void SetupSoRChargeDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgScheduleOfRateCharges);
            var tStyle = dgScheduleOfRateCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgScheduleOfRateCharges.ReadOnly = false;
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 65;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var category = new DataGridLabelColumn();
            category.Format = "";
            category.FormatInfo = null;
            category.HeaderText = "Category";
            category.MappingName = "category";
            category.ReadOnly = true;
            category.Width = 75;
            category.NullText = "";
            tStyle.GridColumnStyles.Add(category);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Summary";
            Description.ReadOnly = true;
            Description.Width = 85;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var NumUnitsUsed = new DataGridLabelColumn();
            NumUnitsUsed.Format = "";
            NumUnitsUsed.FormatInfo = null;
            NumUnitsUsed.HeaderText = "# Used";
            NumUnitsUsed.MappingName = "NumUnitsUsed";
            NumUnitsUsed.ReadOnly = true;
            NumUnitsUsed.Width = 52;
            NumUnitsUsed.NullText = "0";
            tStyle.GridColumnStyles.Add(NumUnitsUsed);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 60;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Charge = new DataGridLabelColumn();
            Charge.Format = "C";
            Charge.FormatInfo = null;
            Charge.HeaderText = "Charge";
            Charge.MappingName = "Total";
            Charge.ReadOnly = true;
            Charge.Width = 65;
            Charge.NullText = "£0.00";
            tStyle.GridColumnStyles.Add(Charge);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
            dgScheduleOfRateCharges.TableStyles.Add(tStyle);
        }

        public void SetupPartProductDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgPartsProductCharging);
            var tStyle = dgPartsProductCharging.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgScheduleOfRateCharges.ReadOnly = false;
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 40;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var PartProduct = new DataGridLabelColumn();
            PartProduct.Format = "";
            PartProduct.FormatInfo = null;
            PartProduct.HeaderText = "Part/Product";
            PartProduct.MappingName = "Part/Product";
            PartProduct.ReadOnly = true;
            PartProduct.Width = 75;
            PartProduct.NullText = "";
            tStyle.GridColumnStyles.Add(PartProduct);
            var Asset = new DataGridLabelColumn();
            Asset.Format = "";
            Asset.FormatInfo = null;
            Asset.HeaderText = "Appliance (part applied to)";
            Asset.MappingName = "Asset";
            Asset.ReadOnly = true;
            Asset.Width = 60;
            Asset.NullText = "";
            tStyle.GridColumnStyles.Add(Asset);
            var Warranty = new DataGridLabelColumn();
            Warranty.Format = "";
            Warranty.FormatInfo = null;
            Warranty.HeaderText = "Warranty? (Appliance on)";
            Warranty.MappingName = "Warranty";
            Warranty.ReadOnly = true;
            Warranty.Width = 55;
            Warranty.NullText = "";
            tStyle.GridColumnStyles.Add(Warranty);
            var Quantity = new DataGridLabelColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Qty";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 40;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 45;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Charge = new DataGridLabelColumn();
            Charge.Format = "C";
            Charge.FormatInfo = null;
            Charge.HeaderText = "Charge";
            Charge.MappingName = "Total";
            Charge.ReadOnly = true;
            Charge.Width = 65;
            Charge.NullText = "£0.00";
            tStyle.GridColumnStyles.Add(Charge);
            var Cost = new DataGridLabelColumn();
            Cost.Format = "C";
            Cost.FormatInfo = null;
            Cost.HeaderText = "Cost";
            Cost.MappingName = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 45;
            Cost.NullText = "";
            tStyle.GridColumnStyles.Add(Cost);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
            dgPartsProductCharging.TableStyles.Add(tStyle);
        }

        private void btnPrintJobCosting_Click(object sender, EventArgs e)
        {
            var details = new ArrayList();
            details.Add(CurrentJob.JobID);
            var oPrint = new Entity.Sys.Printing(details, "Costing" + CurrentJob.JobNumber + " ", Entity.Sys.Enums.SystemDocumentType.JobCosting);
        }

        private void FRMLogCallout_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            SetupTimeSheetChargeDataGrid();
            SetupSoRChargeDataGrid();
            SetupPartProductDataGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentJob.JobTypeID == 521)
            {
                SaveJI();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void SaveJI()
        {
            try
            {
                JI.SetSurveyed = Combo.get_GetSelectedItemValue(cboSurveyed);
                JI.SetDeposit = cfn(txtDeposit.Text);
                JI.SetQuotedAmount = cfn(txtQuoted.Text);
                JI.SetEngCalledSuper = Combo.get_GetSelectedItemValue(cboCalledSuper);
                JI.SetExtraLabour = Combo.get_GetSelectedItemValue(cboExtraLabour);
                JI.SetFurtherWorks = Combo.get_GetSelectedItemValue(cboFurtherWorks);
                JI.SetPaymentTaken = cfn(txtPayment.Text);
                JI.SetEstElecCost = cfn(txtEstElec.Text);
                JI.SetQC = Combo.get_GetSelectedItemValue(cboQC);
                JI.SetPaperWork = Combo.get_GetSelectedItemValue(cboPaperwork);
                JI.SetEstPartCost = cfn(txtPartEst.Text);
                JI.SetEstLabourCost = cfn(txtEstLabour.Text);
                JI.SetEstTotalCost = cfn(txtTotalEst.Text);
                JI.SetJobID = CurrentJob.JobID;
                JI.SetEstProfitMoney = cfn(txtProfitEstMoney.Text);
                JI.SetManual = cfn(txtManual.Text);
                JI.SetSubConEst = cfn(txtEstSub.Text);
                if (JI.Exists)
                {
                    App.DB.JobInstallSQL.Update(JI);
                }
                else
                {
                    App.DB.JobInstallSQL.Insert(JI);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void SetupJobInstall()
        {
            if (CurrentJob.JobTypeID == 521)
            {
                vatRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(CurrentJob.DateCreated);
                vatRate = App.DB.VATRatesSQL.VATRates_Get(vatRateID);
                JI = new Entity.JobInstalls.JobInstall();
                JI = App.DB.JobInstallSQL.JobINstall_GetFor_JobID(CurrentJob.JobID);
                if (JI is null)
                {
                    JI = new Entity.JobInstalls.JobInstall();
                }

                var argcombo = cboSurveyed;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, JI.Surveyed.ToString());
                txtDeposit.Text = "£" + JI.Deposit;
                txtDepositGross.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(txtDeposit.Text)) * (1 + vatRate.VATRate / 100), "C");
                txtPO.Text = JI.POStatus.ToString();
                var argcombo1 = cboCalledSuper;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, JI.EngCalledSuper.ToString());
                var argcombo2 = cboExtraLabour;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, JI.ExtraLabour.ToString());
                var argcombo3 = cboFurtherWorks;
                Combo.SetSelectedComboItem_By_Value(ref argcombo3, JI.FurtherWorks.ToString());
                txtPayment.Text = "£" + JI.PaymentTaken;
                var argcombo4 = cboQC;
                Combo.SetSelectedComboItem_By_Value(ref argcombo4, JI.QC.ToString());
                var argcombo5 = cboPaperwork;
                Combo.SetSelectedComboItem_By_Value(ref argcombo5, JI.PaperWork.ToString());
                txtPartEst.Text = "£" + JI.EstPartCost;
                txtPartAct.Text = "£" + JI.actPartCost;
                txtEstLabour.Text = "£" + JI.EstLabourCost;
                txtActLabour.Text = "£" + JI.actLabourCost;
                txtEstElec.Text = "£" + JI.EstElecCost;
                txtActElec.Text = "£" + JI.actElecCost;
                txtTotalEst.Text = "£" + JI.EstTotalCost;
                txtTotalAct.Text = "£" + JI.actTotalCost;
                txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(JI.QuotedAmount) - Conversions.ToDouble(JI.EstTotalCost));
                txtProfitActMoney.Text = "£" + JI.ActProfitMoney;
                txtProfitEstPerc.Text = JI.EstProfitPerc + "%";
                txtProfitActPerc.Text = JI.ActProfitPerc + "%";
                txtEstElec.Text = "£" + JI.EstElecCost;
                txtActElec.Text = "£" + JI.actElecCost;
                txtEstSub.Text = "£" + JI.SubConEst;
                if (JI.SubConSI != 0)
                {
                    txtActSub.Text = "£" + JI.SubConSI;
                }
                else
                {
                    txtActSub.Text = "£" + JI.SubConPO;
                }

                txtManual.Text = "£" + JI.Manual;
                txtQuoted.Text = "£" + JI.QuotedAmount;
                txtQuotedGross.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(txtQuoted.Text)) * (1 + vatRate.VATRate / 100), "C");
                txtSupplierInv.Text = "£" + JI.SupplierInvoice;
            }

            CalcTotals();
        }

        private void txtEstLabour_TextChanged(object sender, EventArgs e)
        {
            CalcTotals();
        }

        private void txtEstElectrical_TextChanged(object sender, EventArgs e)
        {
            CalcTotals();
        }

        private void txtPartEst_TextChanged(object sender, EventArgs e)
        {
            CalcTotals();
        }

        private void txtEstSub_TextChanged(object sender, EventArgs e)
        {
            CalcTotals();
        }

        private void CalcTotals()
        {
            txtTotalEst.Text = "£" + (Conversions.ToDouble(cfn(txtPartEst.Text)) + Conversions.ToDouble(cfn(txtEstLabour.Text) + Conversions.ToDouble(cfn(txtEstElec.Text)) + Conversions.ToDouble(cfn(txtEstSub.Text))));
            txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(cfn(txtQuoted.Text)) - Conversions.ToDouble(cfn(txtTotalEst.Text)));
            txtProfitEstPerc.Text = Math.Round(Conversions.ToDouble(txtProfitEstMoney.Text) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtQuoted.Text))), 4) * 100 + "%";
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            txtProfitActMoney.Text = "£" + Conversions.ToDouble(cfn(txtPayment.Text) - cfn(txtTotalAct.Text));
            txtProfitActPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitActMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtPayment.Text))), 4) * 100 + "%";
        }

        private void txtManual_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (JI.SIExists)
                {
                    txtTotalAct.Text = (Conversions.ToDouble(cfn(txtSupplierInv.Text) + cfn(txtActLabour.Text) + cfn(txtActElec.Text) + cfn(txtActSub.Text)) + Conversions.ToDouble(cfn(txtManual.Text))).ToString();
                }
                else
                {
                    txtTotalAct.Text = (Conversions.ToDouble(cfn(txtPartAct.Text) + cfn(txtActLabour.Text) + cfn(txtActElec.Text) + cfn(txtActSub.Text)) + Conversions.ToDouble(cfn(txtManual.Text))).ToString();
                }

                txtProfitActMoney.Text = "£" + Conversions.ToDouble(cfn(txtPayment.Text) - cfn(txtTotalAct.Text));
                txtProfitActPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitActMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtPayment.Text))), 4) * 100 + "%";
            }
            catch (Exception ex)
            {
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtQuotedGross.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(cfn(txtQuoted.Text))) * (1 + vatRate.VATRate / 100), "C");
            txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(cfn(txtQuoted.Text)) - Conversions.ToDouble(cfn(txtTotalEst.Text)));
            txtProfitEstPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitEstMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtQuoted.Text))), 4) * 100 + "%";
        }

        private void txtQuotedGross_TextChanged(object sender, EventArgs e)
        {
            txtQuoted.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(cfn(txtQuotedGross.Text))) / (1 + vatRate.VATRate / 100), "C");
            txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(cfn(txtQuoted.Text)) - Conversions.ToDouble(cfn(txtTotalEst.Text)));
            txtProfitEstPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitEstMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtQuoted.Text))), 4) * 100 + "%";
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
            txtDepositGross.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(cfn(txtDeposit.Text))) * (1 + vatRate.VATRate / 100), "C");
            txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(cfn(txtQuoted.Text)) - Conversions.ToDouble(cfn(txtTotalEst.Text)));
            txtProfitEstPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitEstMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtQuoted.Text))), 4) * 100 + "%";
        }

        private void txtDepositGross_TextChanged(object sender, EventArgs e)
        {
            txtDeposit.Text = Strings.Format(Conversions.ToDouble(Conversions.ToDecimal(cfn(txtDepositGross.Text))) / (1 + vatRate.VATRate / 100), "C");
            txtProfitEstMoney.Text = "£" + (Conversions.ToDouble(cfn(txtQuoted.Text)) - Conversions.ToDouble(cfn(txtTotalEst.Text)));
            txtProfitEstPerc.Text = Math.Round(Conversions.ToDouble(cfn(txtProfitEstMoney.Text)) / Conversions.ToDouble(Conversions.ToDouble(cfn(txtQuoted.Text))), 4) * 100 + "%";
        }

        public double cfn(string text)
        {
            string s;
            // s = System.Text.RegularExpressions.Regex.Replace(text, "[+-]?[^0-9.]", "")
            s = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9.]", "");
            if (string.IsNullOrEmpty(s))
                s = 0.ToString();
            if (text.Contains("-"))
            {
                s = "-" + s;
            }

            return Conversions.ToDouble(s);
        }

        public void CalculatePL()
        {
            var dtTime = new DataTable();
            var dtParts = new DataTable();
            var dtSors = new DataTable();
            int evc = 0;
            foreach (Entity.JobOfWorks.JobOfWork jow in CurrentJob.JobOfWorks)
            {
                foreach (Entity.EngineerVisits.EngineerVisit ev in jow.EngineerVisits)
                {
                    ev.TimeSheets = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(ev.EngineerVisitID);
                    if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(ev.EngineerVisitID) is object)
                    {
                        evc = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(ev.EngineerVisitID).InvoiceReadyID;
                    }

                    if (evc == 2)
                    {
                        dtSors.Merge(App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(ev.EngineerVisitID).Table);
                    }

                    if (ev.TimeSheets.Count > 0)
                    {
                        dtTime.Merge(ev.TimeSheets.Table);
                    }

                    dtParts.Merge(App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(ev.EngineerVisitID).Table);
                }
            }

            txtPartCost.Text = Entity.Sys.Helper.MakeDoubleValid(0).ToString();
            txtLabourCost.Text = Entity.Sys.Helper.MakeDoubleValid(0).ToString();
            txtCosts.Text = Entity.Sys.Helper.MakeDoubleValid(0).ToString();
            txtSORSales.Text = Entity.Sys.Helper.MakeDoubleValid(0).ToString();
            txtSorTotal.Text = Entity.Sys.Helper.MakeDoubleValid(0).ToString();
            TimeSheetCharges = new DataView(dtTime);
            PartProductsCharges = new DataView(dtParts);
            ScheduleOfRateCharges = new DataView(dtSors);
            foreach (DataRow charge in PartProductsCharges.Table.Rows)
            {
                txtPartCost.Text += Entity.Sys.Helper.MakeDoubleValid(charge["Cost"]);
                txtCosts.Text += Entity.Sys.Helper.MakeDoubleValid(charge["Cost"]);
            }

            foreach (DataRow charge in TimeSheetCharges.Table.Rows)
            {
                txtLabourCost.Text += Entity.Sys.Helper.MakeDoubleValid(charge["EngineerCost"]);
                txtCosts.Text += Entity.Sys.Helper.MakeDoubleValid(charge["EngineerCost"]);
            }

            foreach (DataRow charge in ScheduleOfRateCharges.Table.Rows)
            {
                txtSORSales.Text += Entity.Sys.Helper.MakeDoubleValid(charge["Total"]);
                txtSorTotal.Text += Entity.Sys.Helper.MakeDoubleValid(charge["Total"]);
            }

            JI = new Entity.JobInstalls.JobInstall();
            JI = App.DB.JobInstallSQL.JobINstall_GetFor_JobID(CurrentJob.JobID);
            if (JI is object)
            {
                txtSales.Text = Math.Round(JI.PaymentTaken - Conversions.ToDouble(txtSorTotal.Text), 2).ToString();
            }

            TxtProfitPounds.Text = "£" + Math.Round(Conversions.ToDouble(JI.PaymentTaken) - Conversions.ToDouble(txtCosts.Text), 2);
            txtProfitPerc.Text = Math.Round(Conversions.ToDouble(TxtProfitPounds.Text) / JI.PaymentTaken * 100, 2).ToString();
            txtLabourPerc.Text = Math.Round(Conversions.ToDouble(txtLabourCost.Text) / JI.PaymentTaken * 100, 2).ToString();
            txtPartPerc.Text = Math.Round(Conversions.ToDouble(txtPartCost.Text) / JI.PaymentTaken * 100, 2).ToString();
        }
    }
}