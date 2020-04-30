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

        internal Button btnPrintJobCosting
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintJobCosting;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintJobCosting != null)
                {
                    
                    
                    _btnPrintJobCosting.Click -= btnPrintJobCosting_Click;
                }

                _btnPrintJobCosting = value;
                if (_btnPrintJobCosting != null)
                {
                    _btnPrintJobCosting.Click += btnPrintJobCosting_Click;
                }
            }
        }

        private TabPage _tpJobCostings;

        internal TabPage tpJobCostings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpJobCostings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpJobCostings != null)
                {
                }

                _tpJobCostings = value;
                if (_tpJobCostings != null)
                {
                }
            }
        }

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

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

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

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

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

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

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

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

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

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

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

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

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

        internal Label Label19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label19 != null)
                {
                }

                _Label19 = value;
                if (_Label19 != null)
                {
                }
            }
        }

        private Label _Label20;

        internal Label Label20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label20 != null)
                {
                }

                _Label20 = value;
                if (_Label20 != null)
                {
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

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

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

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

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

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

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

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

        internal Label lblQuoted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoted != null)
                {
                }

                _lblQuoted = value;
                if (_lblQuoted != null)
                {
                }
            }
        }

        private Label _Label26;

        internal Label Label26
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label26;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label26 != null)
                {
                }

                _Label26 = value;
                if (_Label26 != null)
                {
                }
            }
        }

        private Label _Label25;

        internal Label Label25
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label25;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label25 != null)
                {
                }

                _Label25 = value;
                if (_Label25 != null)
                {
                }
            }
        }

        private Label _Label24;

        internal Label Label24
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label24;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label24 != null)
                {
                }

                _Label24 = value;
                if (_Label24 != null)
                {
                }
            }
        }

        private Label _Label23;

        internal Label Label23
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label23;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label23 != null)
                {
                }

                _Label23 = value;
                if (_Label23 != null)
                {
                }
            }
        }

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

        internal Label Label21
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label21;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label21 != null)
                {
                }

                _Label21 = value;
                if (_Label21 != null)
                {
                }
            }
        }

        private Label _Label22;

        internal Label Label22
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label22;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label22 != null)
                {
                }

                _Label22 = value;
                if (_Label22 != null)
                {
                }
            }
        }

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

        internal Label Label28
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label28;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label28 != null)
                {
                }

                _Label28 = value;
                if (_Label28 != null)
                {
                }
            }
        }

        private Label _Label27;

        internal Label Label27
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label27;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label27 != null)
                {
                }

                _Label27 = value;
                if (_Label27 != null)
                {
                }
            }
        }

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

        internal Label Label31
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label31;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label31 != null)
                {
                }

                _Label31 = value;
                if (_Label31 != null)
                {
                }
            }
        }

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

        internal Label Label29
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label29;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label29 != null)
                {
                }

                _Label29 = value;
                if (_Label29 != null)
                {
                }
            }
        }

        private Label _Label30;

        internal Label Label30
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label30;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label30 != null)
                {
                }

                _Label30 = value;
                if (_Label30 != null)
                {
                }
            }
        }

        private GroupBox _grpTotalCostings;

        internal GroupBox grpTotalCostings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpTotalCostings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpTotalCostings != null)
                {
                }

                _grpTotalCostings = value;
                if (_grpTotalCostings != null)
                {
                }
            }
        }

        private Label _Label32;

        internal Label Label32
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label32;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label32 != null)
                {
                }

                _Label32 = value;
                if (_Label32 != null)
                {
                }
            }
        }

        private Label _Label33;

        internal Label Label33
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label33;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label33 != null)
                {
                }

                _Label33 = value;
                if (_Label33 != null)
                {
                }
            }
        }

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

        internal Label lbl5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbl5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbl5 != null)
                {
                }

                _lbl5 = value;
                if (_lbl5 != null)
                {
                }
            }
        }

        private Label _Label34;

        internal Label Label34
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label34;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label34 != null)
                {
                }

                _Label34 = value;
                if (_Label34 != null)
                {
                }
            }
        }

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

        internal GroupBox grpPartCostings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPartCostings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPartCostings != null)
                {
                }

                _grpPartCostings = value;
                if (_grpPartCostings != null)
                {
                }
            }
        }

        private Label _Label35;

        internal Label Label35
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label35;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label35 != null)
                {
                }

                _Label35 = value;
                if (_Label35 != null)
                {
                }
            }
        }

        private Label _Label36;

        internal Label Label36
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label36;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label36 != null)
                {
                }

                _Label36 = value;
                if (_Label36 != null)
                {
                }
            }
        }

        private Label _Label37;

        internal Label Label37
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label37;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label37 != null)
                {
                }

                _Label37 = value;
                if (_Label37 != null)
                {
                }
            }
        }

        private Label _Label38;

        internal Label Label38
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label38;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label38 != null)
                {
                }

                _Label38 = value;
                if (_Label38 != null)
                {
                }
            }
        }

        private Label _lbl1;

        internal Label lbl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbl1 != null)
                {
                }

                _lbl1 = value;
                if (_lbl1 != null)
                {
                }
            }
        }

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

        internal Label Label41
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label41;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label41 != null)
                {
                }

                _Label41 = value;
                if (_Label41 != null)
                {
                }
            }
        }

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

        internal Label Label40
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label40;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label40 != null)
                {
                }

                _Label40 = value;
                if (_Label40 != null)
                {
                }
            }
        }

        private TextBox _TextBox2;

        internal TextBox TextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox2 != null)
                {
                }

                _TextBox2 = value;
                if (_TextBox2 != null)
                {
                }
            }
        }

        private Label _Label39;

        internal Label Label39
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label39;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label39 != null)
                {
                }

                _Label39 = value;
                if (_Label39 != null)
                {
                }
            }
        }

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

        internal Label Label43
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label43;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label43 != null)
                {
                }

                _Label43 = value;
                if (_Label43 != null)
                {
                }
            }
        }

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

        internal Label Label42
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label42;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label42 != null)
                {
                }

                _Label42 = value;
                if (_Label42 != null)
                {
                }
            }
        }

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
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _TabControl1 = new TabControl();
            _tpJobCostings = new TabPage();
            _grpTotalCostings = new GroupBox();
            _Label41 = new Label();
            _txtSorTotal = new TextBox();
            _Label32 = new Label();
            _Label33 = new Label();
            _txtProfitPerc = new TextBox();
            _TxtProfitPounds = new TextBox();
            _lbl5 = new Label();
            _Label34 = new Label();
            _txtSales = new TextBox();
            _txtCosts = new TextBox();
            _grpPartCostings = new GroupBox();
            _Label43 = new Label();
            _txtPartPerc = new TextBox();
            _Label42 = new Label();
            _txtLabourPerc = new TextBox();
            _dgScheduleOfRateCharges = new DataGrid();
            _dgPartsProductCharging = new DataGrid();
            _Label40 = new Label();
            _TextBox2 = new TextBox();
            _Label39 = new Label();
            _txtSORSales = new TextBox();
            _dgTimesheetCharges = new DataGrid();
            _Label35 = new Label();
            _Label36 = new Label();
            _Label37 = new Label();
            _Label38 = new Label();
            _lbl1 = new Label();
            _txtPartCost = new TextBox();
            _txtLabourCost = new TextBox();
            _tpInstall = new TabPage();
            _GroupBox1 = new GroupBox();
            _txtManual = new TextBox();
            _txtManual.KeyUp += new KeyEventHandler(txtManual_TextChanged);
            _Label31 = new Label();
            _txtEstSub = new TextBox();
            _txtEstSub.TextChanged += new EventHandler(txtEstSub_TextChanged);
            _txtActSub = new TextBox();
            _Label29 = new Label();
            _Label30 = new Label();
            _Label28 = new Label();
            _Label27 = new Label();
            _txtSupplierInv = new TextBox();
            _Label26 = new Label();
            _Label25 = new Label();
            _Label24 = new Label();
            _Label23 = new Label();
            _txtEstElec = new TextBox();
            _txtEstElec.TextChanged += new EventHandler(txtEstElectrical_TextChanged);
            _txtActElec = new TextBox();
            _Label21 = new Label();
            _Label22 = new Label();
            _txtQuotedGross = new TextBox();
            _txtQuotedGross.KeyUp += new KeyEventHandler(txtQuotedGross_TextChanged);
            _txtDepositGross = new TextBox();
            _txtDepositGross.KeyUp += new KeyEventHandler(txtDepositGross_TextChanged);
            _txtQuoted = new TextBox();
            _txtQuoted.KeyUp += new KeyEventHandler(TextBox1_TextChanged);
            _lblQuoted = new Label();
            _txtProfitActPerc = new TextBox();
            _Label18 = new Label();
            _txtProfitEstPerc = new TextBox();
            _Label16 = new Label();
            _txtProfitActMoney = new TextBox();
            _Label15 = new Label();
            _txtProfitEstMoney = new TextBox();
            _Label14 = new Label();
            _txtTotalEst = new TextBox();
            _txtTotalAct = new TextBox();
            _Label12 = new Label();
            _Label13 = new Label();
            _txtEstLabour = new TextBox();
            _txtEstLabour.TextChanged += new EventHandler(txtEstLabour_TextChanged);
            _txtActLabour = new TextBox();
            _Label5 = new Label();
            _Label17 = new Label();
            _txtPartEst = new TextBox();
            _txtPartEst.TextChanged += new EventHandler(txtPartEst_TextChanged);
            _txtPartAct = new TextBox();
            _Label19 = new Label();
            _Label20 = new Label();
            _Label11 = new Label();
            _cboPaperwork = new ComboBox();
            _Label10 = new Label();
            _cboQC = new ComboBox();
            _txtPayment = new TextBox();
            _txtPayment.TextChanged += new EventHandler(txtPayment_TextChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _cboFurtherWorks = new ComboBox();
            _Label7 = new Label();
            _cboExtraLabour = new ComboBox();
            _txtPO = new TextBox();
            _Label6 = new Label();
            _Label4 = new Label();
            _cboCalledSuper = new ComboBox();
            _Label3 = new Label();
            _cboSurveyed = new ComboBox();
            _txtDeposit = new TextBox();
            _txtDeposit.KeyUp += new KeyEventHandler(txtDeposit_TextChanged);
            _Label2 = new Label();
            _btnPrintJobCosting = new Button();
            _btnPrintJobCosting.Click += new EventHandler(btnPrintJobCosting_Click);
            _TabControl1.SuspendLayout();
            _tpJobCostings.SuspendLayout();
            _grpTotalCostings.SuspendLayout();
            _grpPartCostings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRateCharges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductCharging).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheetCharges).BeginInit();
            _tpInstall.SuspendLayout();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(70, 664);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 16;
            _btnClose.Text = "Close";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(8, 664);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 23);
            _btnSave.TabIndex = 15;
            _btnSave.Text = "Save";
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tpJobCostings);
            _TabControl1.Controls.Add(_tpInstall);
            _TabControl1.Location = new Point(0, 31);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(942, 627);
            _TabControl1.TabIndex = 23;
            //
            // tpJobCostings
            //
            _tpJobCostings.Controls.Add(_grpTotalCostings);
            _tpJobCostings.Controls.Add(_grpPartCostings);
            _tpJobCostings.Location = new Point(4, 22);
            _tpJobCostings.Name = "tpJobCostings";
            _tpJobCostings.Padding = new Padding(3);
            _tpJobCostings.Size = new Size(934, 601);
            _tpJobCostings.TabIndex = 5;
            _tpJobCostings.Text = "Job Costings";
            _tpJobCostings.UseVisualStyleBackColor = true;
            //
            // grpTotalCostings
            //
            _grpTotalCostings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpTotalCostings.Controls.Add(_Label41);
            _grpTotalCostings.Controls.Add(_txtSorTotal);
            _grpTotalCostings.Controls.Add(_Label32);
            _grpTotalCostings.Controls.Add(_Label33);
            _grpTotalCostings.Controls.Add(_txtProfitPerc);
            _grpTotalCostings.Controls.Add(_TxtProfitPounds);
            _grpTotalCostings.Controls.Add(_lbl5);
            _grpTotalCostings.Controls.Add(_Label34);
            _grpTotalCostings.Controls.Add(_txtSales);
            _grpTotalCostings.Controls.Add(_txtCosts);
            _grpTotalCostings.Location = new Point(4, 477);
            _grpTotalCostings.Name = "grpTotalCostings";
            _grpTotalCostings.Size = new Size(928, 80);
            _grpTotalCostings.TabIndex = 7;
            _grpTotalCostings.TabStop = false;
            //
            // Label41
            //
            _Label41.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label41.AutoSize = true;
            _Label41.Location = new Point(510, 11);
            _Label41.Name = "Label41";
            _Label41.Size = new Size(67, 13);
            _Label41.TabIndex = 13;
            _Label41.Text = "SOR Sales";
            //
            // txtSorTotal
            //
            _txtSorTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSorTotal.Location = new Point(500, 30);
            _txtSorTotal.Name = "txtSorTotal";
            _txtSorTotal.Size = new Size(100, 21);
            _txtSorTotal.TabIndex = 14;
            //
            // Label32
            //
            _Label32.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label32.AutoSize = true;
            _Label32.Location = new Point(748, 47);
            _Label32.Name = "Label32";
            _Label32.Size = new Size(53, 13);
            _Label32.TabIndex = 11;
            _Label32.Text = "Profit %";
            //
            // Label33
            //
            _Label33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label33.AutoSize = true;
            _Label33.Location = new Point(748, 20);
            _Label33.Name = "Label33";
            _Label33.Size = new Size(48, 13);
            _Label33.TabIndex = 9;
            _Label33.Text = "Profit £";
            //
            // txtProfitPerc
            //
            _txtProfitPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtProfitPerc.Location = new Point(806, 41);
            _txtProfitPerc.Name = "txtProfitPerc";
            _txtProfitPerc.Size = new Size(100, 21);
            _txtProfitPerc.TabIndex = 12;
            //
            // TxtProfitPounds
            //
            _TxtProfitPounds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _TxtProfitPounds.Location = new Point(806, 14);
            _TxtProfitPounds.Name = "TxtProfitPounds";
            _TxtProfitPounds.Size = new Size(100, 21);
            _TxtProfitPounds.TabIndex = 10;
            //
            // lbl5
            //
            _lbl5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbl5.AutoSize = true;
            _lbl5.Location = new Point(632, 11);
            _lbl5.Name = "lbl5";
            _lbl5.Size = new Size(74, 13);
            _lbl5.TabIndex = 7;
            _lbl5.Text = "Other Sales";
            //
            // Label34
            //
            _Label34.AutoSize = true;
            _Label34.Location = new Point(36, 11);
            _Label34.Name = "Label34";
            _Label34.Size = new Size(39, 13);
            _Label34.TabIndex = 3;
            _Label34.Text = "Costs";
            //
            // txtSales
            //
            _txtSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSales.Location = new Point(622, 30);
            _txtSales.Name = "txtSales";
            _txtSales.Size = new Size(100, 21);
            _txtSales.TabIndex = 8;
            //
            // txtCosts
            //
            _txtCosts.Location = new Point(9, 30);
            _txtCosts.Name = "txtCosts";
            _txtCosts.Size = new Size(100, 21);
            _txtCosts.TabIndex = 6;
            //
            // grpPartCostings
            //
            _grpPartCostings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpPartCostings.BackColor = Color.White;
            _grpPartCostings.Controls.Add(_Label43);
            _grpPartCostings.Controls.Add(_txtPartPerc);
            _grpPartCostings.Controls.Add(_Label42);
            _grpPartCostings.Controls.Add(_txtLabourPerc);
            _grpPartCostings.Controls.Add(_dgScheduleOfRateCharges);
            _grpPartCostings.Controls.Add(_dgPartsProductCharging);
            _grpPartCostings.Controls.Add(_Label40);
            _grpPartCostings.Controls.Add(_TextBox2);
            _grpPartCostings.Controls.Add(_Label39);
            _grpPartCostings.Controls.Add(_txtSORSales);
            _grpPartCostings.Controls.Add(_dgTimesheetCharges);
            _grpPartCostings.Controls.Add(_Label35);
            _grpPartCostings.Controls.Add(_Label36);
            _grpPartCostings.Controls.Add(_Label37);
            _grpPartCostings.Controls.Add(_Label38);
            _grpPartCostings.Controls.Add(_lbl1);
            _grpPartCostings.Controls.Add(_txtPartCost);
            _grpPartCostings.Controls.Add(_txtLabourCost);
            _grpPartCostings.Location = new Point(4, 3);
            _grpPartCostings.Name = "grpPartCostings";
            _grpPartCostings.Size = new Size(928, 468);
            _grpPartCostings.TabIndex = 6;
            _grpPartCostings.TabStop = false;
            _grpPartCostings.Text = "Job Profit/Loss";
            //
            // Label43
            //
            _Label43.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label43.AutoSize = true;
            _Label43.Location = new Point(824, 408);
            _Label43.Name = "Label43";
            _Label43.Size = new Size(46, 13);
            _Label43.TabIndex = 24;
            _Label43.Text = "Part %";
            //
            // txtPartPerc
            //
            _txtPartPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartPerc.Location = new Point(806, 427);
            _txtPartPerc.Name = "txtPartPerc";
            _txtPartPerc.Size = new Size(100, 21);
            _txtPartPerc.TabIndex = 23;
            //
            // Label42
            //
            _Label42.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label42.AutoSize = true;
            _Label42.Location = new Point(817, 255);
            _Label42.Name = "Label42";
            _Label42.Size = new Size(62, 13);
            _Label42.TabIndex = 22;
            _Label42.Text = "Labour %";
            //
            // txtLabourPerc
            //
            _txtLabourPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtLabourPerc.Location = new Point(806, 276);
            _txtLabourPerc.Name = "txtLabourPerc";
            _txtLabourPerc.Size = new Size(100, 21);
            _txtLabourPerc.TabIndex = 21;
            //
            // dgScheduleOfRateCharges
            //
            _dgScheduleOfRateCharges.DataMember = "";
            _dgScheduleOfRateCharges.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRateCharges.Location = new Point(9, 35);
            _dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges";
            _dgScheduleOfRateCharges.Size = new Size(779, 118);
            _dgScheduleOfRateCharges.TabIndex = 20;
            //
            // dgPartsProductCharging
            //
            _dgPartsProductCharging.DataMember = "";
            _dgPartsProductCharging.HeaderForeColor = SystemColors.ControlText;
            _dgPartsProductCharging.Location = new Point(9, 348);
            _dgPartsProductCharging.Name = "dgPartsProductCharging";
            _dgPartsProductCharging.Size = new Size(779, 100);
            _dgPartsProductCharging.TabIndex = 19;
            //
            // Label40
            //
            _Label40.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label40.AutoSize = true;
            _Label40.Location = new Point(817, 33);
            _Label40.Name = "Label40";
            _Label40.Size = new Size(53, 13);
            _Label40.TabIndex = 18;
            _Label40.Text = "SOR Est";
            _Label40.Visible = false;
            //
            // TextBox2
            //
            _TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _TextBox2.Location = new Point(806, 54);
            _TextBox2.Name = "TextBox2";
            _TextBox2.Size = new Size(100, 21);
            _TextBox2.TabIndex = 17;
            _TextBox2.Visible = false;
            //
            // Label39
            //
            _Label39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label39.AutoSize = true;
            _Label39.Location = new Point(817, 111);
            _Label39.Name = "Label39";
            _Label39.Size = new Size(67, 13);
            _Label39.TabIndex = 16;
            _Label39.Text = "SOR Sales";
            //
            // txtSORSales
            //
            _txtSORSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSORSales.Location = new Point(806, 132);
            _txtSORSales.Name = "txtSORSales";
            _txtSORSales.Size = new Size(100, 21);
            _txtSORSales.TabIndex = 15;
            //
            // dgTimesheetCharges
            //
            _dgTimesheetCharges.DataMember = "";
            _dgTimesheetCharges.HeaderForeColor = SystemColors.ControlText;
            _dgTimesheetCharges.Location = new Point(9, 205);
            _dgTimesheetCharges.Name = "dgTimesheetCharges";
            _dgTimesheetCharges.Size = new Size(779, 92);
            _dgTimesheetCharges.TabIndex = 14;
            //
            // Label35
            //
            _Label35.AutoSize = true;
            _Label35.Location = new Point(6, 19);
            _Label35.Name = "Label35";
            _Label35.Size = new Size(87, 13);
            _Label35.TabIndex = 13;
            _Label35.Text = "SOR's Applied";
            //
            // Label36
            //
            _Label36.AutoSize = true;
            _Label36.Location = new Point(6, 332);
            _Label36.Name = "Label36";
            _Label36.Size = new Size(72, 13);
            _Label36.TabIndex = 11;
            _Label36.Text = "Parts Costs";
            //
            // Label37
            //
            _Label37.AutoSize = true;
            _Label37.Location = new Point(6, 189);
            _Label37.Name = "Label37";
            _Label37.Size = new Size(82, 13);
            _Label37.TabIndex = 9;
            _Label37.Text = "Labour Costs";
            //
            // Label38
            //
            _Label38.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label38.AutoSize = true;
            _Label38.Location = new Point(824, 353);
            _Label38.Name = "Label38";
            _Label38.Size = new Size(66, 13);
            _Label38.TabIndex = 2;
            _Label38.Text = "Part Costs";
            //
            // lbl1
            //
            _lbl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lbl1.AutoSize = true;
            _lbl1.Location = new Point(817, 205);
            _lbl1.Name = "lbl1";
            _lbl1.Size = new Size(82, 13);
            _lbl1.TabIndex = 1;
            _lbl1.Text = "Labour Costs";
            //
            // txtPartCost
            //
            _txtPartCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartCost.Location = new Point(806, 372);
            _txtPartCost.Name = "txtPartCost";
            _txtPartCost.Size = new Size(100, 21);
            _txtPartCost.TabIndex = 1;
            //
            // txtLabourCost
            //
            _txtLabourCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtLabourCost.Location = new Point(806, 226);
            _txtLabourCost.Name = "txtLabourCost";
            _txtLabourCost.Size = new Size(100, 21);
            _txtLabourCost.TabIndex = 0;
            //
            // tpInstall
            //
            _tpInstall.Controls.Add(_GroupBox1);
            _tpInstall.Location = new Point(4, 22);
            _tpInstall.Name = "tpInstall";
            _tpInstall.Size = new Size(934, 601);
            _tpInstall.TabIndex = 6;
            _tpInstall.Text = "Installation Data";
            _tpInstall.UseVisualStyleBackColor = true;
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_txtManual);
            _GroupBox1.Controls.Add(_Label31);
            _GroupBox1.Controls.Add(_txtEstSub);
            _GroupBox1.Controls.Add(_txtActSub);
            _GroupBox1.Controls.Add(_Label29);
            _GroupBox1.Controls.Add(_Label30);
            _GroupBox1.Controls.Add(_Label28);
            _GroupBox1.Controls.Add(_Label27);
            _GroupBox1.Controls.Add(_txtSupplierInv);
            _GroupBox1.Controls.Add(_Label26);
            _GroupBox1.Controls.Add(_Label25);
            _GroupBox1.Controls.Add(_Label24);
            _GroupBox1.Controls.Add(_Label23);
            _GroupBox1.Controls.Add(_txtEstElec);
            _GroupBox1.Controls.Add(_txtActElec);
            _GroupBox1.Controls.Add(_Label21);
            _GroupBox1.Controls.Add(_Label22);
            _GroupBox1.Controls.Add(_txtQuotedGross);
            _GroupBox1.Controls.Add(_txtDepositGross);
            _GroupBox1.Controls.Add(_txtQuoted);
            _GroupBox1.Controls.Add(_lblQuoted);
            _GroupBox1.Controls.Add(_txtProfitActPerc);
            _GroupBox1.Controls.Add(_Label18);
            _GroupBox1.Controls.Add(_txtProfitEstPerc);
            _GroupBox1.Controls.Add(_Label16);
            _GroupBox1.Controls.Add(_txtProfitActMoney);
            _GroupBox1.Controls.Add(_Label15);
            _GroupBox1.Controls.Add(_txtProfitEstMoney);
            _GroupBox1.Controls.Add(_Label14);
            _GroupBox1.Controls.Add(_txtTotalEst);
            _GroupBox1.Controls.Add(_txtTotalAct);
            _GroupBox1.Controls.Add(_Label12);
            _GroupBox1.Controls.Add(_Label13);
            _GroupBox1.Controls.Add(_txtEstLabour);
            _GroupBox1.Controls.Add(_txtActLabour);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_Label17);
            _GroupBox1.Controls.Add(_txtPartEst);
            _GroupBox1.Controls.Add(_txtPartAct);
            _GroupBox1.Controls.Add(_Label19);
            _GroupBox1.Controls.Add(_Label20);
            _GroupBox1.Controls.Add(_Label11);
            _GroupBox1.Controls.Add(_cboPaperwork);
            _GroupBox1.Controls.Add(_Label10);
            _GroupBox1.Controls.Add(_cboQC);
            _GroupBox1.Controls.Add(_txtPayment);
            _GroupBox1.Controls.Add(_Label9);
            _GroupBox1.Controls.Add(_Label8);
            _GroupBox1.Controls.Add(_cboFurtherWorks);
            _GroupBox1.Controls.Add(_Label7);
            _GroupBox1.Controls.Add(_cboExtraLabour);
            _GroupBox1.Controls.Add(_txtPO);
            _GroupBox1.Controls.Add(_Label6);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_cboCalledSuper);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_cboSurveyed);
            _GroupBox1.Controls.Add(_txtDeposit);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Location = new Point(0, 3);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(926, 599);
            _GroupBox1.TabIndex = 34;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Details";
            //
            // txtManual
            //
            _txtManual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtManual.Location = new Point(668, 353);
            _txtManual.Name = "txtManual";
            _txtManual.Size = new Size(214, 21);
            _txtManual.TabIndex = 112;
            _txtManual.TabStop = false;
            _txtManual.Text = "0";
            _txtManual.TextAlign = HorizontalAlignment.Center;
            //
            // Label31
            //
            _Label31.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label31.Location = new Point(500, 356);
            _Label31.Name = "Label31";
            _Label31.Size = new Size(147, 23);
            _Label31.TabIndex = 111;
            _Label31.Text = "Manual Adjustment";
            //
            // txtEstSub
            //
            _txtEstSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtEstSub.Location = new Point(668, 276);
            _txtEstSub.Name = "txtEstSub";
            _txtEstSub.Size = new Size(214, 21);
            _txtEstSub.TabIndex = 110;
            _txtEstSub.TabStop = false;
            _txtEstSub.Text = "0";
            _txtEstSub.TextAlign = HorizontalAlignment.Center;
            //
            // txtActSub
            //
            _txtActSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtActSub.Location = new Point(668, 306);
            _txtActSub.Name = "txtActSub";
            _txtActSub.ReadOnly = true;
            _txtActSub.Size = new Size(214, 21);
            _txtActSub.TabIndex = 109;
            _txtActSub.TabStop = false;
            _txtActSub.Text = "0";
            _txtActSub.TextAlign = HorizontalAlignment.Center;
            //
            // Label29
            //
            _Label29.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label29.Location = new Point(500, 279);
            _Label29.Name = "Label29";
            _Label29.Size = new Size(147, 23);
            _Label29.TabIndex = 108;
            _Label29.Text = "Est SubContractor Cost";
            //
            // Label30
            //
            _Label30.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label30.Location = new Point(500, 309);
            _Label30.Name = "Label30";
            _Label30.Size = new Size(147, 23);
            _Label30.TabIndex = 107;
            _Label30.Text = "Act SubContractor Cost";
            //
            // Label28
            //
            _Label28.Location = new Point(683, 65);
            _Label28.Name = "Label28";
            _Label28.Size = new Size(86, 19);
            _Label28.TabIndex = 106;
            _Label28.Text = "PO Value";
            //
            // Label27
            //
            _Label27.Location = new Point(796, 62);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(86, 19);
            _Label27.TabIndex = 105;
            _Label27.Text = "Supplier Inv";
            //
            // txtSupplierInv
            //
            _txtSupplierInv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSupplierInv.Location = new Point(781, 84);
            _txtSupplierInv.Name = "txtSupplierInv";
            _txtSupplierInv.ReadOnly = true;
            _txtSupplierInv.Size = new Size(101, 21);
            _txtSupplierInv.TabIndex = 104;
            _txtSupplierInv.TabStop = false;
            _txtSupplierInv.Text = "0";
            _txtSupplierInv.TextAlign = HorizontalAlignment.Center;
            //
            // Label26
            //
            _Label26.Location = new Point(223, 122);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(61, 18);
            _Label26.TabIndex = 103;
            _Label26.Text = "Nett";
            //
            // Label25
            //
            _Label25.Location = new Point(223, 63);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(61, 14);
            _Label25.TabIndex = 102;
            _Label25.Text = "Nett";
            //
            // Label24
            //
            _Label24.Location = new Point(323, 62);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(61, 19);
            _Label24.TabIndex = 101;
            _Label24.Text = "Gross";
            //
            // Label23
            //
            _Label23.Location = new Point(323, 122);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(61, 18);
            _Label23.TabIndex = 100;
            _Label23.Text = "Gross";
            //
            // txtEstElec
            //
            _txtEstElec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtEstElec.Location = new Point(668, 127);
            _txtEstElec.Name = "txtEstElec";
            _txtEstElec.Size = new Size(214, 21);
            _txtEstElec.TabIndex = 99;
            _txtEstElec.TabStop = false;
            _txtEstElec.Text = "0";
            _txtEstElec.TextAlign = HorizontalAlignment.Center;
            //
            // txtActElec
            //
            _txtActElec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtActElec.Location = new Point(668, 157);
            _txtActElec.Name = "txtActElec";
            _txtActElec.ReadOnly = true;
            _txtActElec.Size = new Size(214, 21);
            _txtActElec.TabIndex = 98;
            _txtActElec.TabStop = false;
            _txtActElec.Text = "0";
            _txtActElec.TextAlign = HorizontalAlignment.Center;
            //
            // Label21
            //
            _Label21.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label21.Location = new Point(500, 133);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(116, 23);
            _Label21.TabIndex = 97;
            _Label21.Text = "Est Electrical Cost";
            //
            // Label22
            //
            _Label22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label22.Location = new Point(500, 163);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(131, 23);
            _Label22.TabIndex = 96;
            _Label22.Text = "Act Electrical Cost";
            //
            // txtQuotedGross
            //
            _txtQuotedGross.Location = new Point(304, 84);
            _txtQuotedGross.Name = "txtQuotedGross";
            _txtQuotedGross.Size = new Size(97, 21);
            _txtQuotedGross.TabIndex = 95;
            _txtQuotedGross.TabStop = false;
            _txtQuotedGross.Text = "0";
            _txtQuotedGross.TextAlign = HorizontalAlignment.Center;
            //
            // txtDepositGross
            //
            _txtDepositGross.Location = new Point(304, 141);
            _txtDepositGross.Name = "txtDepositGross";
            _txtDepositGross.Size = new Size(97, 21);
            _txtDepositGross.TabIndex = 94;
            _txtDepositGross.TabStop = false;
            _txtDepositGross.Text = "0";
            _txtDepositGross.TextAlign = HorizontalAlignment.Center;
            //
            // txtQuoted
            //
            _txtQuoted.Location = new Point(187, 84);
            _txtQuoted.Name = "txtQuoted";
            _txtQuoted.Size = new Size(97, 21);
            _txtQuoted.TabIndex = 93;
            _txtQuoted.TabStop = false;
            _txtQuoted.Text = "0";
            _txtQuoted.TextAlign = HorizontalAlignment.Center;
            //
            // lblQuoted
            //
            _lblQuoted.Location = new Point(17, 90);
            _lblQuoted.Name = "lblQuoted";
            _lblQuoted.Size = new Size(121, 23);
            _lblQuoted.TabIndex = 92;
            _lblQuoted.Text = "Amount Quoted";
            //
            // txtProfitActPerc
            //
            _txtProfitActPerc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtProfitActPerc.Location = new Point(670, 551);
            _txtProfitActPerc.Name = "txtProfitActPerc";
            _txtProfitActPerc.ReadOnly = true;
            _txtProfitActPerc.Size = new Size(214, 21);
            _txtProfitActPerc.TabIndex = 91;
            _txtProfitActPerc.TabStop = false;
            _txtProfitActPerc.Text = "0";
            _txtProfitActPerc.TextAlign = HorizontalAlignment.Center;
            //
            // Label18
            //
            _Label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label18.Location = new Point(500, 554);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(116, 23);
            _Label18.TabIndex = 90;
            _Label18.Text = "Act Profit %";
            //
            // txtProfitEstPerc
            //
            _txtProfitEstPerc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtProfitEstPerc.Location = new Point(670, 524);
            _txtProfitEstPerc.Name = "txtProfitEstPerc";
            _txtProfitEstPerc.ReadOnly = true;
            _txtProfitEstPerc.Size = new Size(214, 21);
            _txtProfitEstPerc.TabIndex = 89;
            _txtProfitEstPerc.TabStop = false;
            _txtProfitEstPerc.Text = "0";
            _txtProfitEstPerc.TextAlign = HorizontalAlignment.Center;
            //
            // Label16
            //
            _Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label16.Location = new Point(500, 527);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(116, 23);
            _Label16.TabIndex = 88;
            _Label16.Text = "Est Profit %";
            //
            // txtProfitActMoney
            //
            _txtProfitActMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtProfitActMoney.Location = new Point(670, 485);
            _txtProfitActMoney.Name = "txtProfitActMoney";
            _txtProfitActMoney.ReadOnly = true;
            _txtProfitActMoney.Size = new Size(214, 21);
            _txtProfitActMoney.TabIndex = 87;
            _txtProfitActMoney.TabStop = false;
            _txtProfitActMoney.Text = "0";
            _txtProfitActMoney.TextAlign = HorizontalAlignment.Center;
            //
            // Label15
            //
            _Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label15.Location = new Point(500, 488);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(116, 23);
            _Label15.TabIndex = 86;
            _Label15.Text = "Act Profit £";
            //
            // txtProfitEstMoney
            //
            _txtProfitEstMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtProfitEstMoney.Location = new Point(670, 458);
            _txtProfitEstMoney.Name = "txtProfitEstMoney";
            _txtProfitEstMoney.ReadOnly = true;
            _txtProfitEstMoney.Size = new Size(214, 21);
            _txtProfitEstMoney.TabIndex = 85;
            _txtProfitEstMoney.TabStop = false;
            _txtProfitEstMoney.Text = "0";
            _txtProfitEstMoney.TextAlign = HorizontalAlignment.Center;
            //
            // Label14
            //
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label14.Location = new Point(500, 461);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(116, 23);
            _Label14.TabIndex = 84;
            _Label14.Text = "Est Profit £";
            //
            // txtTotalEst
            //
            _txtTotalEst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtTotalEst.Location = new Point(670, 396);
            _txtTotalEst.Name = "txtTotalEst";
            _txtTotalEst.ReadOnly = true;
            _txtTotalEst.Size = new Size(214, 21);
            _txtTotalEst.TabIndex = 83;
            _txtTotalEst.TabStop = false;
            _txtTotalEst.Text = "0";
            _txtTotalEst.TextAlign = HorizontalAlignment.Center;
            //
            // txtTotalAct
            //
            _txtTotalAct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtTotalAct.Location = new Point(670, 426);
            _txtTotalAct.Name = "txtTotalAct";
            _txtTotalAct.ReadOnly = true;
            _txtTotalAct.Size = new Size(214, 21);
            _txtTotalAct.TabIndex = 82;
            _txtTotalAct.TabStop = false;
            _txtTotalAct.Text = "0";
            _txtTotalAct.TextAlign = HorizontalAlignment.Center;
            //
            // Label12
            //
            _Label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label12.Location = new Point(502, 397);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(116, 23);
            _Label12.TabIndex = 81;
            _Label12.Text = "Est Total Cost";
            //
            // Label13
            //
            _Label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label13.Location = new Point(502, 427);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(116, 23);
            _Label13.TabIndex = 80;
            _Label13.Text = "Act total Cost";
            //
            // txtEstLabour
            //
            _txtEstLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtEstLabour.Location = new Point(668, 201);
            _txtEstLabour.Name = "txtEstLabour";
            _txtEstLabour.Size = new Size(214, 21);
            _txtEstLabour.TabIndex = 79;
            _txtEstLabour.TabStop = false;
            _txtEstLabour.Text = "0";
            _txtEstLabour.TextAlign = HorizontalAlignment.Center;
            //
            // txtActLabour
            //
            _txtActLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtActLabour.Location = new Point(668, 231);
            _txtActLabour.Name = "txtActLabour";
            _txtActLabour.ReadOnly = true;
            _txtActLabour.Size = new Size(214, 21);
            _txtActLabour.TabIndex = 78;
            _txtActLabour.TabStop = false;
            _txtActLabour.Text = "0";
            _txtActLabour.TextAlign = HorizontalAlignment.Center;
            //
            // Label5
            //
            _Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label5.Location = new Point(500, 204);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(116, 23);
            _Label5.TabIndex = 77;
            _Label5.Text = "Est Labour Cost";
            //
            // Label17
            //
            _Label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label17.Location = new Point(500, 234);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(116, 23);
            _Label17.TabIndex = 76;
            _Label17.Text = "Act Labour Cost";
            //
            // txtPartEst
            //
            _txtPartEst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartEst.Location = new Point(670, 37);
            _txtPartEst.Name = "txtPartEst";
            _txtPartEst.Size = new Size(214, 21);
            _txtPartEst.TabIndex = 75;
            _txtPartEst.TabStop = false;
            _txtPartEst.Text = "0";
            _txtPartEst.TextAlign = HorizontalAlignment.Center;
            //
            // txtPartAct
            //
            _txtPartAct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartAct.Location = new Point(670, 84);
            _txtPartAct.Name = "txtPartAct";
            _txtPartAct.ReadOnly = true;
            _txtPartAct.Size = new Size(99, 21);
            _txtPartAct.TabIndex = 64;
            _txtPartAct.TabStop = false;
            _txtPartAct.Text = "0";
            _txtPartAct.TextAlign = HorizontalAlignment.Center;
            //
            // Label19
            //
            _Label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label19.Location = new Point(500, 40);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(88, 23);
            _Label19.TabIndex = 60;
            _Label19.Text = "Est Part Cost";
            //
            // Label20
            //
            _Label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label20.Location = new Point(498, 87);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(88, 23);
            _Label20.TabIndex = 57;
            _Label20.Text = "Act Part Cost";
            //
            // Label11
            //
            _Label11.Location = new Point(17, 342);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(134, 23);
            _Label11.TabIndex = 56;
            _Label11.Text = "Paperwork Returned";
            //
            // cboPaperwork
            //
            _cboPaperwork.FormattingEnabled = true;
            _cboPaperwork.Location = new Point(187, 336);
            _cboPaperwork.Name = "cboPaperwork";
            _cboPaperwork.Size = new Size(214, 21);
            _cboPaperwork.TabIndex = 55;
            //
            // Label10
            //
            _Label10.Location = new Point(17, 307);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(134, 23);
            _Label10.TabIndex = 54;
            _Label10.Text = "QC Carried Out";
            //
            // cboQC
            //
            _cboQC.FormattingEnabled = true;
            _cboQC.Location = new Point(187, 304);
            _cboQC.Name = "cboQC";
            _cboQC.Size = new Size(214, 21);
            _cboQC.TabIndex = 53;
            //
            // txtPayment
            //
            _txtPayment.ImeMode = ImeMode.NoControl;
            _txtPayment.Location = new Point(187, 276);
            _txtPayment.Name = "txtPayment";
            _txtPayment.ReadOnly = true;
            _txtPayment.Size = new Size(214, 21);
            _txtPayment.TabIndex = 51;
            _txtPayment.TabStop = false;
            _txtPayment.Text = "0";
            _txtPayment.TextAlign = HorizontalAlignment.Center;
            //
            // Label9
            //
            _Label9.Location = new Point(17, 282);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(134, 23);
            _Label9.TabIndex = 50;
            _Label9.Text = "Payment Taken";
            //
            // Label8
            //
            _Label8.Location = new Point(17, 255);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(134, 23);
            _Label8.TabIndex = 48;
            _Label8.Text = "Further Works Noted";
            //
            // cboFurtherWorks
            //
            _cboFurtherWorks.FormattingEnabled = true;
            _cboFurtherWorks.Location = new Point(187, 249);
            _cboFurtherWorks.Name = "cboFurtherWorks";
            _cboFurtherWorks.Size = new Size(214, 21);
            _cboFurtherWorks.TabIndex = 47;
            //
            // Label7
            //
            _Label7.Location = new Point(17, 228);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(134, 23);
            _Label7.TabIndex = 46;
            _Label7.Text = "Extra Labour Noted";
            //
            // cboExtraLabour
            //
            _cboExtraLabour.FormattingEnabled = true;
            _cboExtraLabour.Location = new Point(187, 222);
            _cboExtraLabour.Name = "cboExtraLabour";
            _cboExtraLabour.Size = new Size(214, 21);
            _cboExtraLabour.TabIndex = 45;
            //
            // txtPO
            //
            _txtPO.Location = new Point(187, 168);
            _txtPO.Name = "txtPO";
            _txtPO.ReadOnly = true;
            _txtPO.Size = new Size(214, 21);
            _txtPO.TabIndex = 44;
            _txtPO.TabStop = false;
            _txtPO.Text = "0";
            _txtPO.TextAlign = HorizontalAlignment.Center;
            //
            // Label6
            //
            _Label6.Location = new Point(17, 174);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 23);
            _Label6.TabIndex = 43;
            _Label6.Text = "PO Status";
            //
            // Label4
            //
            _Label4.Location = new Point(17, 201);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(134, 23);
            _Label4.TabIndex = 40;
            _Label4.Text = "Eng Called Supervisor";
            //
            // cboCalledSuper
            //
            _cboCalledSuper.FormattingEnabled = true;
            _cboCalledSuper.Location = new Point(187, 195);
            _cboCalledSuper.Name = "cboCalledSuper";
            _cboCalledSuper.Size = new Size(214, 21);
            _cboCalledSuper.TabIndex = 39;
            //
            // Label3
            //
            _Label3.Location = new Point(20, 35);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(88, 23);
            _Label3.TabIndex = 38;
            _Label3.Text = "Surveyed by";
            //
            // cboSurveyed
            //
            _cboSurveyed.FormattingEnabled = true;
            _cboSurveyed.Location = new Point(187, 32);
            _cboSurveyed.Name = "cboSurveyed";
            _cboSurveyed.Size = new Size(214, 21);
            _cboSurveyed.TabIndex = 37;
            //
            // txtDeposit
            //
            _txtDeposit.Location = new Point(187, 141);
            _txtDeposit.Name = "txtDeposit";
            _txtDeposit.Size = new Size(97, 21);
            _txtDeposit.TabIndex = 36;
            _txtDeposit.TabStop = false;
            _txtDeposit.Text = "0";
            _txtDeposit.TextAlign = HorizontalAlignment.Center;
            //
            // Label2
            //
            _Label2.Location = new Point(17, 147);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(88, 23);
            _Label2.TabIndex = 34;
            _Label2.Text = "Deposit Taken";
            //
            // btnPrintJobCosting
            //
            _btnPrintJobCosting.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintJobCosting.Location = new Point(822, 664);
            _btnPrintJobCosting.Name = "btnPrintJobCosting";
            _btnPrintJobCosting.Size = new Size(114, 23);
            _btnPrintJobCosting.TabIndex = 25;
            _btnPrintJobCosting.Text = "Print Job Costing";
            _btnPrintJobCosting.UseVisualStyleBackColor = true;
            //
            // FRMJobCostings
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(942, 690);
            ControlBox = false;
            Controls.Add(_btnPrintJobCosting);
            Controls.Add(_TabControl1);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(950, 724);
            Name = "FRMJobCostings";
            Text = "Job";
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_TabControl1, 0);
            Controls.SetChildIndex(_btnPrintJobCosting, 0);
            _TabControl1.ResumeLayout(false);
            _tpJobCostings.ResumeLayout(false);
            _grpTotalCostings.ResumeLayout(false);
            _grpTotalCostings.PerformLayout();
            _grpPartCostings.ResumeLayout(false);
            _grpPartCostings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRateCharges).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgPartsProductCharging).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheetCharges).EndInit();
            _tpInstall.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ResumeLayout(false);
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