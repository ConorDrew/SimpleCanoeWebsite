using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCLogCallout : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCLogCallout() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCLogCallout_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // UserControl overrides dispose to clean up the component list.
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
        private TextBox _txtJobNumber;

        internal TextBox txtJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobNumber != null)
                {
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
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

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                    _cboJobType.SelectedIndexChanged -= cboJobType_SelectedIndexChanged;
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                    _cboJobType.SelectedIndexChanged += cboJobType_SelectedIndexChanged;
                }
            }
        }

        private Label _label4;

        internal Label label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_label4 != null)
                {
                }

                _label4 = value;
                if (_label4 != null)
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

        private TextBox _txtSiteDetails;

        internal TextBox txtSiteDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteDetails != null)
                {
                }

                _txtSiteDetails = value;
                if (_txtSiteDetails != null)
                {
                }
            }
        }

        private TextBox _txtCustomerName;

        internal TextBox txtCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomerName != null)
                {
                }

                _txtCustomerName = value;
                if (_txtCustomerName != null)
                {
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

        private RadioButton _rdoQuoted;

        internal RadioButton rdoQuoted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoQuoted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoQuoted != null)
                {
                    _rdoQuoted.CheckedChanged -= rdoQuoted_CheckedChanged;
                }

                _rdoQuoted = value;
                if (_rdoQuoted != null)
                {
                    _rdoQuoted.CheckedChanged += rdoQuoted_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoContract;

        internal RadioButton rdoContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoContract != null)
                {
                    _rdoContract.CheckedChanged -= rdoContract_CheckedChanged;
                }

                _rdoContract = value;
                if (_rdoContract != null)
                {
                    _rdoContract.CheckedChanged += rdoContract_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoMisc;

        internal RadioButton rdoMisc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoMisc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoMisc != null)
                {
                    _rdoMisc.CheckedChanged -= rdoMisc_CheckedChanged;
                }

                _rdoMisc = value;
                if (_rdoMisc != null)
                {
                    _rdoMisc.CheckedChanged += rdoMisc_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoCallout;

        internal RadioButton rdoCallout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoCallout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoCallout != null)
                {
                    _rdoCallout.CheckedChanged -= rdoCallout_CheckedChanged;
                }

                _rdoCallout = value;
                if (_rdoCallout != null)
                {
                    _rdoCallout.CheckedChanged += rdoCallout_CheckedChanged;
                }
            }
        }

        private Button _btnRemoveJobOfWork;

        internal Button btnRemoveJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveJobOfWork != null)
                {
                    _btnRemoveJobOfWork.Click -= btnRemoveJobOfWork_Click;
                }

                _btnRemoveJobOfWork = value;
                if (_btnRemoveJobOfWork != null)
                {
                    _btnRemoveJobOfWork.Click += btnRemoveJobOfWork_Click;
                }
            }
        }

        private Button _btnAddJobOfWork;

        internal Button btnAddJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddJobOfWork != null)
                {
                    _btnAddJobOfWork.Click -= btnAddJobOfWork_Click;
                }

                _btnAddJobOfWork = value;
                if (_btnAddJobOfWork != null)
                {
                    _btnAddJobOfWork.Click += btnAddJobOfWork_Click;
                }
            }
        }

        private TabControl _tcJobOfWorks;

        internal TabControl tcJobOfWorks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcJobOfWorks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcJobOfWorks != null)
                {
                }

                _tcJobOfWorks = value;
                if (_tcJobOfWorks != null)
                {
                }
            }
        }

        private Label _lblOnHold;

        internal Label lblOnHold
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOnHold;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOnHold != null)
                {
                }

                _lblOnHold = value;
                if (_lblOnHold != null)
                {
                }
            }
        }

        private CheckBox _cbxToBePartPaid;

        internal CheckBox cbxToBePartPaid
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxToBePartPaid;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxToBePartPaid != null)
                {
                }

                _cbxToBePartPaid = value;
                if (_cbxToBePartPaid != null)
                {
                }
            }
        }

        private TextBox _txtRetention;

        internal TextBox txtRetention
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRetention;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRetention != null)
                {
                }

                _txtRetention = value;
                if (_txtRetention != null)
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

        private TextBox _txtCurrentContract;

        internal TextBox txtCurrentContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCurrentContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCurrentContract != null)
                {
                }

                _txtCurrentContract = value;
                if (_txtCurrentContract != null)
                {
                }
            }
        }

        private CheckBox _chkPOC;

        internal CheckBox chkPOC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPOC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPOC != null)
                {
                }

                _chkPOC = value;
                if (_chkPOC != null)
                {
                }
            }
        }

        private CheckBox _chkOTI;

        internal CheckBox chkOTI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkOTI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkOTI != null)
                {
                }

                _chkOTI = value;
                if (_chkOTI != null)
                {
                }
            }
        }

        private Label _lblCustomerName;

        internal Label lblCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomerName != null)
                {
                }

                _lblCustomerName = value;
                if (_lblCustomerName != null)
                {
                }
            }
        }

        private TextBox _txtSiteName;

        internal TextBox txtSiteName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteName != null)
                {
                }

                _txtSiteName = value;
                if (_txtSiteName != null)
                {
                }
            }
        }

        private CheckBox _chkFoc;

        internal CheckBox chkFoc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkFoc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkFoc != null)
                {
                }

                _chkFoc = value;
                if (_chkFoc != null)
                {
                }
            }
        }

        private Label _lblContractInactive;

        internal Label lblContractInactive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractInactive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractInactive != null)
                {
                }

                _lblContractInactive = value;
                if (_lblContractInactive != null)
                {
                }
            }
        }

        private Button _btnChange;

        internal Button btnChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChange != null)
                {
                    _btnChange.Click -= btnChange_Click;
                }

                _btnChange = value;
                if (_btnChange != null)
                {
                    _btnChange.Click += btnChange_Click;
                }
            }
        }

        private TextBox _txtContact;

        internal TextBox txtContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContact != null)
                {
                }

                _txtContact = value;
                if (_txtContact != null)
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

        private GroupBox _gbPaymentType;

        internal GroupBox gbPaymentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gbPaymentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gbPaymentType != null)
                {
                }

                _gbPaymentType = value;
                if (_gbPaymentType != null)
                {
                }
            }
        }

        private Button _btnfindVan;

        internal Button btnfindVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnfindVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnfindVan != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnfindVan.Click -= btnfindVan_Click;
                }

                _btnfindVan = value;
                if (_btnfindVan != null)
                {
                    _btnfindVan.Click += btnfindVan_Click;
                }
            }
        }

        private TextBox _txtVanReg;

        internal TextBox txtVanReg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVanReg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVanReg != null)
                {
                }

                _txtVanReg = value;
                if (_txtVanReg != null)
                {
                }
            }
        }

        private Button _btnFindUser;

        internal Button btnFindUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindUser != null)
                {
                    _btnFindUser.Click -= btnFindUser_Click;
                }

                _btnFindUser = value;
                if (_btnFindUser != null)
                {
                    _btnFindUser.Click += btnFindUser_Click;
                }
            }
        }

        private TextBox _txtSalesRep;

        internal TextBox txtSalesRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSalesRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSalesRep != null)
                {
                }

                _txtSalesRep = value;
                if (_txtSalesRep != null)
                {
                }
            }
        }

        private Label _lblSalesRep;

        internal Label lblSalesRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSalesRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSalesRep != null)
                {
                }

                _lblSalesRep = value;
                if (_lblSalesRep != null)
                {
                }
            }
        }

        private GroupBox _grpHeadline;

        internal GroupBox grpHeadline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpHeadline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpHeadline != null)
                {
                }

                _grpHeadline = value;
                if (_grpHeadline != null)
                {
                }
            }
        }

        private TextBox _txtHeadline;

        internal TextBox txtHeadline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHeadline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHeadline != null)
                {
                }

                _txtHeadline = value;
                if (_txtHeadline != null)
                {
                }
            }
        }

        private Label _lblLastContactAttempt;

        internal Label lblLastContactAttempt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLastContactAttempt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLastContactAttempt != null)
                {
                }

                _lblLastContactAttempt = value;
                if (_lblLastContactAttempt != null)
                {
                }
            }
        }

        private TextBox _txtLastContact;

        internal TextBox txtLastContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLastContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLastContact != null)
                {
                }

                _txtLastContact = value;
                if (_txtLastContact != null)
                {
                }
            }
        }

        private Button _btnAddContactAttempt;

        internal Button btnAddContactAttempt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddContactAttempt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddContactAttempt != null)
                {
                    _btnAddContactAttempt.Click -= btnAddContactAttempt_Click;
                }

                _btnAddContactAttempt = value;
                if (_btnAddContactAttempt != null)
                {
                    _btnAddContactAttempt.Click += btnAddContactAttempt_Click;
                }
            }
        }

        private ToolTip _tt;

        internal ToolTip tt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tt != null)
                {
                }

                _tt = value;
                if (_tt != null)
                {
                }
            }
        }

        private CheckBox _chkCollectPayment;

        internal CheckBox chkCollectPayment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCollectPayment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCollectPayment != null)
                {
                }

                _chkCollectPayment = value;
                if (_chkCollectPayment != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _btnRemoveJobOfWork = new Button();
            _btnRemoveJobOfWork.Click += new EventHandler(btnRemoveJobOfWork_Click);
            _btnAddJobOfWork = new Button();
            _btnAddJobOfWork.Click += new EventHandler(btnAddJobOfWork_Click);
            _tcJobOfWorks = new TabControl();
            _rdoContract = new RadioButton();
            _rdoContract.CheckedChanged += new EventHandler(rdoContract_CheckedChanged);
            _rdoQuoted = new RadioButton();
            _rdoQuoted.CheckedChanged += new EventHandler(rdoQuoted_CheckedChanged);
            _txtJobNumber = new TextBox();
            _Label5 = new Label();
            _cboJobType = new ComboBox();
            _cboJobType.SelectedIndexChanged += new EventHandler(cboJobType_SelectedIndexChanged);
            _label4 = new Label();
            _rdoMisc = new RadioButton();
            _rdoMisc.CheckedChanged += new EventHandler(rdoMisc_CheckedChanged);
            _rdoCallout = new RadioButton();
            _rdoCallout.CheckedChanged += new EventHandler(rdoCallout_CheckedChanged);
            _Label3 = new Label();
            _txtSiteDetails = new TextBox();
            _txtCustomerName = new TextBox();
            _Label1 = new Label();
            _Label2 = new Label();
            _lblOnHold = new Label();
            _cbxToBePartPaid = new CheckBox();
            _txtRetention = new TextBox();
            _Label7 = new Label();
            _Label8 = new Label();
            _txtCurrentContract = new TextBox();
            _chkCollectPayment = new CheckBox();
            _chkPOC = new CheckBox();
            _chkOTI = new CheckBox();
            _lblCustomerName = new Label();
            _txtSiteName = new TextBox();
            _chkFoc = new CheckBox();
            _lblContractInactive = new Label();
            _btnChange = new Button();
            _btnChange.Click += new EventHandler(btnChange_Click);
            _txtContact = new TextBox();
            _Label10 = new Label();
            _gbPaymentType = new GroupBox();
            _btnfindVan = new Button();
            _btnfindVan.Click += new EventHandler(btnfindVan_Click);
            _txtVanReg = new TextBox();
            _btnFindUser = new Button();
            _btnFindUser.Click += new EventHandler(btnFindUser_Click);
            _txtSalesRep = new TextBox();
            _lblSalesRep = new Label();
            _grpHeadline = new GroupBox();
            _txtHeadline = new TextBox();
            _lblLastContactAttempt = new Label();
            _txtLastContact = new TextBox();
            _btnAddContactAttempt = new Button();
            _btnAddContactAttempt.Click += new EventHandler(btnAddContactAttempt_Click);
            _tt = new ToolTip(components);
            _gbPaymentType.SuspendLayout();
            _grpHeadline.SuspendLayout();
            SuspendLayout();
            //
            // btnRemoveJobOfWork
            //
            _btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work";
            _btnRemoveJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRemoveJobOfWork.Location = new Point(1157, 213);
            _btnRemoveJobOfWork.Name = "btnRemoveJobOfWork";
            _btnRemoveJobOfWork.Size = new Size(24, 23);
            _btnRemoveJobOfWork.TabIndex = 16;
            _btnRemoveJobOfWork.Text = "_";
            //
            // btnAddJobOfWork
            //
            _btnAddJobOfWork.AccessibleDescription = "Add Job Of Work";
            _btnAddJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddJobOfWork.Location = new Point(1127, 213);
            _btnAddJobOfWork.Name = "btnAddJobOfWork";
            _btnAddJobOfWork.Size = new Size(24, 23);
            _btnAddJobOfWork.TabIndex = 15;
            _btnAddJobOfWork.Text = "+";
            //
            // tcJobOfWorks
            //
            _tcJobOfWorks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcJobOfWorks.Location = new Point(8, 232);
            _tcJobOfWorks.Name = "tcJobOfWorks";
            _tcJobOfWorks.SelectedIndex = 0;
            _tcJobOfWorks.Size = new Size(1173, 401);
            _tcJobOfWorks.TabIndex = 17;
            //
            // rdoContract
            //
            _rdoContract.Location = new Point(201, 135);
            _rdoContract.Name = "rdoContract";
            _rdoContract.Size = new Size(72, 24);
            _rdoContract.TabIndex = 10;
            _rdoContract.Text = "Contract";
            _rdoContract.UseVisualStyleBackColor = true;
            _rdoContract.Visible = false;
            //
            // rdoQuoted
            //
            _rdoQuoted.Location = new Point(162, 123);
            _rdoQuoted.Name = "rdoQuoted";
            _rdoQuoted.Size = new Size(64, 24);
            _rdoQuoted.TabIndex = 9;
            _rdoQuoted.Text = "Quoted";
            _rdoQuoted.UseVisualStyleBackColor = true;
            _rdoQuoted.Visible = false;
            //
            // txtJobNumber
            //
            _txtJobNumber.Location = new Point(545, 87);
            _txtJobNumber.MaxLength = 20;
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.ReadOnly = true;
            _txtJobNumber.Size = new Size(117, 21);
            _txtJobNumber.TabIndex = 4;
            //
            // Label5
            //
            _Label5.Location = new Point(461, 90);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(80, 18);
            _Label5.TabIndex = 20;
            _Label5.Text = "Job Number:";
            //
            // cboJobType
            //
            _cboJobType.Location = new Point(307, 185);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(205, 21);
            _cboJobType.TabIndex = 14;
            //
            // label4
            //
            _label4.Location = new Point(307, 161);
            _label4.Name = "label4";
            _label4.Size = new Size(65, 20);
            _label4.TabIndex = 22;
            _label4.Text = "Job Type:";
            //
            // rdoMisc
            //
            _rdoMisc.Cursor = Cursors.Hand;
            _rdoMisc.Location = new Point(242, 58);
            _rdoMisc.Name = "rdoMisc";
            _rdoMisc.Size = new Size(56, 24);
            _rdoMisc.TabIndex = 9;
            _rdoMisc.Text = "Misc.";
            _rdoMisc.UseVisualStyleBackColor = true;
            _rdoMisc.Visible = false;
            //
            // rdoCallout
            //
            _rdoCallout.Cursor = Cursors.Hand;
            _rdoCallout.Location = new Point(98, 124);
            _rdoCallout.Name = "rdoCallout";
            _rdoCallout.Size = new Size(72, 24);
            _rdoCallout.TabIndex = 8;
            _rdoCallout.Text = "Callout";
            _rdoCallout.UseVisualStyleBackColor = true;
            _rdoCallout.Visible = false;
            //
            // Label3
            //
            _Label3.Location = new Point(20, 128);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 23);
            _Label3.TabIndex = 3;
            _Label3.Text = "Definition:";
            _Label3.Visible = false;
            //
            // txtSiteDetails
            //
            _txtSiteDetails.Location = new Point(93, 58);
            _txtSiteDetails.Name = "txtSiteDetails";
            _txtSiteDetails.ReadOnly = true;
            _txtSiteDetails.Size = new Size(569, 21);
            _txtSiteDetails.TabIndex = 3;
            //
            // txtCustomerName
            //
            _txtCustomerName.Location = new Point(93, 0);
            _txtCustomerName.Name = "txtCustomerName";
            _txtCustomerName.ReadOnly = true;
            _txtCustomerName.Size = new Size(569, 21);
            _txtCustomerName.TabIndex = 1;
            //
            // Label1
            //
            _Label1.Location = new Point(6, 0);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(80, 23);
            _Label1.TabIndex = 18;
            _Label1.Text = "Customer:";
            //
            // Label2
            //
            _Label2.Location = new Point(6, 60);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(80, 23);
            _Label2.TabIndex = 19;
            _Label2.Text = "Property:";
            //
            // lblOnHold
            //
            _lblOnHold.Font = new Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOnHold.ForeColor = Color.Red;
            _lblOnHold.Location = new Point(89, 212);
            _lblOnHold.Name = "lblOnHold";
            _lblOnHold.Size = new Size(290, 24);
            _lblOnHold.TabIndex = 14;
            _lblOnHold.Text = "Customer Status: On Hold";
            //
            // cbxToBePartPaid
            //
            _cbxToBePartPaid.Location = new Point(181, 53);
            _cbxToBePartPaid.Name = "cbxToBePartPaid";
            _cbxToBePartPaid.Size = new Size(240, 32);
            _cbxToBePartPaid.TabIndex = 12;
            _cbxToBePartPaid.Text = "Job to be paid in parts (One Invoice, many payment applications)";
            _cbxToBePartPaid.Visible = false;
            //
            // txtRetention
            //
            _txtRetention.Location = new Point(427, 58);
            _txtRetention.MaxLength = 20;
            _txtRetention.Name = "txtRetention";
            _txtRetention.Size = new Size(96, 21);
            _txtRetention.TabIndex = 11;
            _txtRetention.Visible = false;
            //
            // Label7
            //
            _Label7.Location = new Point(424, 29);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(88, 23);
            _Label7.TabIndex = 0;
            _Label7.Text = "Retention %:";
            _Label7.Visible = false;
            //
            // Label8
            //
            _Label8.Location = new Point(7, 121);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(72, 23);
            _Label8.TabIndex = 24;
            _Label8.Text = "Contract:";
            //
            // txtCurrentContract
            //
            _txtCurrentContract.Location = new Point(92, 124);
            _txtCurrentContract.Multiline = true;
            _txtCurrentContract.Name = "txtCurrentContract";
            _txtCurrentContract.ReadOnly = true;
            _txtCurrentContract.ScrollBars = ScrollBars.Vertical;
            _txtCurrentContract.Size = new Size(203, 78);
            _txtCurrentContract.TabIndex = 5;
            //
            // chkCollectPayment
            //
            _chkCollectPayment.Location = new Point(11, 123);
            _chkCollectPayment.Name = "chkCollectPayment";
            _chkCollectPayment.Size = new Size(120, 24);
            _chkCollectPayment.TabIndex = 6;
            _chkCollectPayment.Text = "Collect Payment";
            _chkCollectPayment.Visible = false;
            //
            // chkPOC
            //
            _chkPOC.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkPOC.Location = new Point(81, 21);
            _chkPOC.Name = "chkPOC";
            _chkPOC.RightToLeft = RightToLeft.Yes;
            _chkPOC.Size = new Size(55, 19);
            _chkPOC.TabIndex = 12;
            _chkPOC.Text = "POC";
            //
            // chkOTI
            //
            _chkOTI.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkOTI.Location = new Point(143, 20);
            _chkOTI.Name = "chkOTI";
            _chkOTI.RightToLeft = RightToLeft.Yes;
            _chkOTI.Size = new Size(56, 20);
            _chkOTI.TabIndex = 13;
            _chkOTI.Text = "OTI";
            //
            // lblCustomerName
            //
            _lblCustomerName.Location = new Point(6, 27);
            _lblCustomerName.Name = "lblCustomerName";
            _lblCustomerName.Size = new Size(80, 23);
            _lblCustomerName.TabIndex = 29;
            _lblCustomerName.Text = "Name:";
            //
            // txtSiteName
            //
            _txtSiteName.Location = new Point(94, 29);
            _txtSiteName.Name = "txtSiteName";
            _txtSiteName.ReadOnly = true;
            _txtSiteName.Size = new Size(568, 21);
            _txtSiteName.TabIndex = 2;
            //
            // chkFoc
            //
            _chkFoc.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkFoc.Location = new Point(13, 20);
            _chkFoc.Name = "chkFoc";
            _chkFoc.RightToLeft = RightToLeft.Yes;
            _chkFoc.Size = new Size(56, 20);
            _chkFoc.TabIndex = 11;
            _chkFoc.Text = "FOC";
            //
            // lblContractInactive
            //
            _lblContractInactive.BackColor = Color.Red;
            _lblContractInactive.Location = new Point(89, 117);
            _lblContractInactive.Name = "lblContractInactive";
            _lblContractInactive.Size = new Size(212, 90);
            _lblContractInactive.TabIndex = 30;
            _lblContractInactive.Visible = false;
            //
            // btnChange
            //
            _btnChange.Location = new Point(518, 184);
            _btnChange.Name = "btnChange";
            _btnChange.Size = new Size(82, 22);
            _btnChange.TabIndex = 31;
            _btnChange.Text = "Change";
            _btnChange.UseVisualStyleBackColor = true;
            //
            // txtContact
            //
            _txtContact.Location = new Point(92, 87);
            _txtContact.MaxLength = 20;
            _txtContact.Name = "txtContact";
            _txtContact.ReadOnly = true;
            _txtContact.Size = new Size(363, 21);
            _txtContact.TabIndex = 34;
            //
            // Label10
            //
            _Label10.Location = new Point(6, 90);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(84, 23);
            _Label10.TabIndex = 35;
            _Label10.Text = "Contact Info:";
            //
            // gbPaymentType
            //
            _gbPaymentType.Controls.Add(_chkOTI);
            _gbPaymentType.Controls.Add(_chkPOC);
            _gbPaymentType.Controls.Add(_chkFoc);
            _gbPaymentType.Location = new Point(307, 114);
            _gbPaymentType.Name = "gbPaymentType";
            _gbPaymentType.Size = new Size(205, 44);
            _gbPaymentType.TabIndex = 36;
            _gbPaymentType.TabStop = false;
            _gbPaymentType.Text = "Payment Type";
            //
            // btnfindVan
            //
            _btnfindVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnfindVan.BackColor = Color.White;
            _btnfindVan.Enabled = false;
            _btnfindVan.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindVan.Location = new Point(1149, 179);
            _btnfindVan.Name = "btnfindVan";
            _btnfindVan.Size = new Size(32, 23);
            _btnfindVan.TabIndex = 37;
            _btnfindVan.Text = "...";
            _btnfindVan.UseVisualStyleBackColor = false;
            _btnfindVan.Visible = false;
            //
            // txtVanReg
            //
            _txtVanReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtVanReg.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtVanReg.Location = new Point(895, 179);
            _txtVanReg.Name = "txtVanReg";
            _txtVanReg.ReadOnly = true;
            _txtVanReg.Size = new Size(247, 21);
            _txtVanReg.TabIndex = 36;
            _txtVanReg.Visible = false;
            //
            // btnFindUser
            //
            _btnFindUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindUser.BackColor = Color.White;
            _btnFindUser.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindUser.Location = new Point(1149, 150);
            _btnFindUser.Name = "btnFindUser";
            _btnFindUser.Size = new Size(32, 23);
            _btnFindUser.TabIndex = 39;
            _btnFindUser.Text = "...";
            _btnFindUser.UseVisualStyleBackColor = false;
            //
            // txtSalesRep
            //
            _txtSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSalesRep.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSalesRep.Location = new Point(895, 152);
            _txtSalesRep.Name = "txtSalesRep";
            _txtSalesRep.ReadOnly = true;
            _txtSalesRep.Size = new Size(248, 21);
            _txtSalesRep.TabIndex = 38;
            //
            // lblSalesRep
            //
            _lblSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSalesRep.Location = new Point(813, 155);
            _lblSalesRep.Name = "lblSalesRep";
            _lblSalesRep.Size = new Size(76, 18);
            _lblSalesRep.TabIndex = 40;
            _lblSalesRep.Text = "Sales Rep:";
            //
            // grpHeadline
            //
            _grpHeadline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpHeadline.Controls.Add(_txtHeadline);
            _grpHeadline.Location = new Point(709, 0);
            _grpHeadline.Name = "grpHeadline";
            _grpHeadline.Size = new Size(472, 52);
            _grpHeadline.TabIndex = 43;
            _grpHeadline.TabStop = false;
            _grpHeadline.Text = "Job Headline";
            //
            // txtHeadline
            //
            _txtHeadline.Dock = DockStyle.Fill;
            _txtHeadline.Location = new Point(3, 17);
            _txtHeadline.Multiline = true;
            _txtHeadline.Name = "txtHeadline";
            _txtHeadline.ScrollBars = ScrollBars.Vertical;
            _txtHeadline.Size = new Size(466, 32);
            _txtHeadline.TabIndex = 43;
            //
            // lblLastContactAttempt
            //
            _lblLastContactAttempt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblLastContactAttempt.Location = new Point(683, 60);
            _lblLastContactAttempt.Name = "lblLastContactAttempt";
            _lblLastContactAttempt.Size = new Size(84, 18);
            _lblLastContactAttempt.TabIndex = 44;
            _lblLastContactAttempt.Text = "Last Contact:";
            //
            // txtLastContact
            //
            _txtLastContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtLastContact.Location = new Point(773, 60);
            _txtLastContact.Multiline = true;
            _txtLastContact.Name = "txtLastContact";
            _txtLastContact.ReadOnly = true;
            _txtLastContact.ScrollBars = ScrollBars.Vertical;
            _txtLastContact.Size = new Size(408, 77);
            _txtLastContact.TabIndex = 45;
            //
            // btnAddContactAttempt
            //
            _btnAddContactAttempt.AccessibleDescription = "";
            _btnAddContactAttempt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddContactAttempt.Location = new Point(743, 112);
            _btnAddContactAttempt.Name = "btnAddContactAttempt";
            _btnAddContactAttempt.Size = new Size(24, 23);
            _btnAddContactAttempt.TabIndex = 46;
            _btnAddContactAttempt.Text = "+";
            _tt.SetToolTip(_btnAddContactAttempt, "Add new contact attempt");
            //
            // UCLogCallout
            //
            Controls.Add(_btnAddContactAttempt);
            Controls.Add(_txtLastContact);
            Controls.Add(_lblLastContactAttempt);
            Controls.Add(_grpHeadline);
            Controls.Add(_gbPaymentType);
            Controls.Add(_lblSalesRep);
            Controls.Add(_btnFindUser);
            Controls.Add(_txtSalesRep);
            Controls.Add(_btnfindVan);
            Controls.Add(_txtVanReg);
            Controls.Add(_txtContact);
            Controls.Add(_Label10);
            Controls.Add(_txtCurrentContract);
            Controls.Add(_lblContractInactive);
            Controls.Add(_txtJobNumber);
            Controls.Add(_cboJobType);
            Controls.Add(_btnChange);
            Controls.Add(_txtSiteName);
            Controls.Add(_lblCustomerName);
            Controls.Add(_Label8);
            Controls.Add(_txtCustomerName);
            Controls.Add(_Label5);
            Controls.Add(_Label2);
            Controls.Add(_rdoCallout);
            Controls.Add(_txtSiteDetails);
            Controls.Add(_Label1);
            Controls.Add(_btnRemoveJobOfWork);
            Controls.Add(_btnAddJobOfWork);
            Controls.Add(_tcJobOfWorks);
            Controls.Add(_lblOnHold);
            Controls.Add(_rdoQuoted);
            Controls.Add(_chkCollectPayment);
            Controls.Add(_txtRetention);
            Controls.Add(_Label7);
            Controls.Add(_rdoContract);
            Controls.Add(_cbxToBePartPaid);
            Controls.Add(_Label3);
            Controls.Add(_rdoMisc);
            Controls.Add(_label4);
            Name = "UCLogCallout";
            Size = new Size(1188, 620);
            _gbPaymentType.ResumeLayout(false);
            _grpHeadline.ResumeLayout(false);
            _grpHeadline.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return Job;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private bool IsNewJobOfWork = false;
        private FRMLogCallout _onForm = null;

        public FRMLogCallout OnForm
        {
            get
            {
                return _onForm;
            }

            set
            {
                _onForm = value;
            }
        }

        private int _jobId;

        public int JobId
        {
            get
            {
                return _jobId;
            }

            set
            {
                _jobId = value;
            }
        }

        private int _siteId;

        public int SiteId
        {
            get
            {
                return _siteId;
            }

            set
            {
                _siteId = value;
            }
        }

        private Entity.Jobs.Job _job;

        public Entity.Jobs.Job Job
        {
            get
            {
                return _job;
            }

            set
            {
                _job = value;
                if (_job is null)
                {
                    _job = new Entity.Jobs.Job();
                }
            }
        }

        private Entity.Sites.Site _site;

        public Entity.Sites.Site Site
        {
            get
            {
                return _site;
            }

            set
            {
                _site = value;
                if (_site is null)
                {
                    _site = new Entity.Sites.Site();
                }
            }
        }

        private Entity.Customers.Customer _customer;

        public Entity.Customers.Customer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
            }
        }

        private JobNumber _jobNumber = new JobNumber();

        public JobNumber JobNumber
        {
            get
            {
                return _jobNumber;
            }

            set
            {
                _jobNumber = value;
            }
        }

        private User _salesRep;

        public User SalesRep
        {
            get
            {
                return _salesRep;
            }

            set
            {
                _salesRep = value;
                if (_salesRep is null)
                {
                    _salesRep = new User();
                    _salesRep.Exists = false;
                    txtSalesRep.Text = "N/A";
                }
                else
                {
                    txtSalesRep.Text = _salesRep.Fullname;
                }
            }
        }

        private Entity.FleetVans.FleetVan _fleet;

        public Entity.FleetVans.FleetVan Fleet
        {
            get
            {
                return _fleet;
            }

            set
            {
                _fleet = value;
                if (_fleet is null)
                {
                    _fleet = new Entity.FleetVans.FleetVan();
                    _fleet.Exists = false;
                }
                else
                {
                    txtVanReg.Text = _fleet.Registration;
                }
            }
        }

        private List<Entity.JobOfWorks.JobOfWork> _jobOfWorks;

        public List<Entity.JobOfWorks.JobOfWork> JobOfWorks
        {
            get
            {
                return _jobOfWorks;
            }

            set
            {
                _jobOfWorks = value;
                if (_jobOfWorks is null)
                {
                    _jobOfWorks = new List<Entity.JobOfWorks.JobOfWork>();
                }
            }
        }

        private List<Entity.EngineerVisits.EngineerVisit> _engineerVisits;

        public List<Entity.EngineerVisits.EngineerVisit> EngineerVisits
        {
            get
            {
                return _engineerVisits;
            }

            set
            {
                _engineerVisits = value;
                if (_engineerVisits is null)
                {
                    _engineerVisits = new List<Entity.EngineerVisits.EngineerVisit>();
                }
            }
        }

        private List<Entity.ContactAttempts.ContactAttempt> _contactAttempts;

        public List<Entity.ContactAttempts.ContactAttempt> ContactAttempts
        {
            get
            {
                return _contactAttempts;
            }

            set
            {
                _contactAttempts = value;
                if (_contactAttempts is null)
                {
                    _contactAttempts = new List<Entity.ContactAttempts.ContactAttempt>();
                }
            }
        }

        private DataView _dvAssests;

        public DataView DvAssets
        {
            get
            {
                return _dvAssests;
            }

            set
            {
                _dvAssests = value;
            }
        }

        private DataView _dvEngineerVisitsPartsAllocated;

        public DataView DvEngineerVisitsPartsAllocated
        {
            get
            {
                return _dvEngineerVisitsPartsAllocated;
            }

            set
            {
                _dvEngineerVisitsPartsAllocated = value;
            }
        }

        private DataView _dvSiteAssests;

        public DataView DvSiteAssets
        {
            get
            {
                return _dvSiteAssests;
            }

            set
            {
                _dvSiteAssests = value;
            }
        }

        private DataView _dvJobItems;

        public DataView DvJobItems
        {
            get
            {
                return _dvJobItems;
            }

            set
            {
                _dvJobItems = value;
            }
        }

        private DataView _dvEngineers;

        public DataView DvEngineers
        {
            get
            {
                return _dvEngineers;
            }

            set
            {
                _dvEngineers = value;
            }
        }

        private DataView _dvCustomerPriorities;

        public DataView DvCustomerPriorities
        {
            get
            {
                return _dvCustomerPriorities;
            }

            set
            {
                _dvCustomerPriorities = value;
            }
        }

        private DataView _dvEngineerLevels;

        public DataView DvEngineerLevels
        {
            get
            {
                return _dvEngineerLevels;
            }

            set
            {
                _dvEngineerLevels = value;
            }
        }

        private ArrayList _EngineerVisitsRemoved = new ArrayList();

        public ArrayList EngineerVisitsRemoved
        {
            get
            {
                return _EngineerVisitsRemoved;
            }

            set
            {
                _EngineerVisitsRemoved = value;
            }
        }

        private ArrayList _JobOfWorksRemoved = new ArrayList();

        public ArrayList JobOfWorksRemoved
        {
            get
            {
                return _JobOfWorksRemoved;
            }

            set
            {
                _JobOfWorksRemoved = value;
            }
        }

        private ArrayList _EngineerVisitsOrdersRemoved = new ArrayList();

        public ArrayList EngineerVisitsOrdersRemoved
        {
            get
            {
                return _EngineerVisitsOrdersRemoved;
            }

            set
            {
                _EngineerVisitsOrdersRemoved = value;
            }
        }

        private void UCLogCallout_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void rdoCallout_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.JobID == 0)
                Job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
            PaymentTypeChanged();
        }

        private void rdoMisc_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.JobID == 0)
                Job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Misc);
            PaymentTypeChanged();
        }

        private void rdoContract_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.JobID == 0)
                Job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Contract);
            PaymentTypeChanged();
        }

        private void rdoQuoted_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.JobID == 0)
                Job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Quoted);
            PaymentTypeChanged();
        }

        private void btnAddJobOfWork_Click(object sender, EventArgs e)
        {
            var tp = AddJobOfWork(null);
            IsNewJobOfWork = true;
        }

        private void btnRemoveJobOfWork_Click(object sender, EventArgs e)
        {
            RemoveJobOfWork();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (App.EnterOverridePassword() == true)
            {
                var f = new FRMChangeJobType();
                f.ShowDialog();
                var argcombo = cboJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Combo.get_GetSelectedItemValue(f.cboJobType));
                Save();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                PopulateProperties();
                PopulateSite();
                if (!App.IsRFT)
                    PopulateContract();
                PopulateJobOfWorks();
                PopulateJob();
                PopulateContactAttempts();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot load : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void PopulateProperties()
        {
            tcJobOfWorks.TabPages.Clear();
            Site = App.DB.Sites.Get(JobId, Entity.Sites.SiteSQL.GetBy.JobId);
            if (Site.SiteID == 0)
                Site = App.DB.Sites.Get(SiteId, Entity.Sites.SiteSQL.GetBy.SiteId);
            Customer = App.DB.Customer.Customer_Get(Site.CustomerID);
            DvSiteAssets = App.DB.Asset.Asset_GetForSite(Site.SiteID);
            DvEngineerVisitsPartsAllocated = App.DB.EngineerVisitPartProductAllocated.Get_ByJobId(JobId);
            DvJobItems = App.DB.JobItems.JobItems_Get_For_Job(JobId);
            DvEngineers = App.DB.Engineer.Engineer_GetAll();
            DvAssets = App.DB.JobAsset.JobAsset_Get_For_Job(JobId);
            DvCustomerPriorities = App.DB.Customer.CustomerPriority_Get(Site.CustomerID);
            DvEngineerLevels = App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels);
            Job = App.DB.Job.Get(JobId);
            SalesRep = App.DB.User.Get(Job.SalesRepUserID);
            JobOfWorks = App.DB.JobOfWorks.Get_ByJobId(JobId);
            EngineerVisits = App.DB.EngineerVisits.Get_ByJobId(JobId);
        }

        private void PopulateJob()
        {
            if (Job.JobID == 0)
                Job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
            var switchExpr = (Enums.JobDefinition)Conversions.ToInteger(Job.JobDefinitionEnumID);
            switch (switchExpr)
            {
                case Enums.JobDefinition.Callout:
                    {
                        rdoCallout.Checked = true;
                        rdoMisc.Checked = false;
                        rdoContract.Checked = false;
                        rdoQuoted.Checked = false;
                        break;
                    }

                case Enums.JobDefinition.Misc:
                    {
                        rdoCallout.Checked = false;
                        rdoMisc.Checked = true;
                        rdoContract.Checked = false;
                        rdoQuoted.Checked = false;
                        break;
                    }

                case Enums.JobDefinition.Contract:
                    {
                        rdoCallout.Checked = false;
                        rdoMisc.Checked = false;
                        rdoContract.Checked = true;
                        rdoQuoted.Checked = false;
                        break;
                    }

                case Enums.JobDefinition.Quoted:
                    {
                        rdoCallout.Checked = false;
                        rdoMisc.Checked = false;
                        rdoContract.Checked = false;
                        rdoQuoted.Checked = true;
                        break;
                    }
            }

            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Job.JobTypeID.ToString());
            txtJobNumber.Text = Job.JobNumber;
            cbxToBePartPaid.Checked = Job.ToBePartPaid;
            txtRetention.Text = Job.Retention.ToString();
            chkCollectPayment.Checked = Job.CollectPayment;
            chkPOC.Checked = Job.POC;
            chkOTI.Checked = Job.OTI;
            chkFoc.Checked = Job.FOC;
            txtHeadline.Text = Job.Headline;
            btnAddContactAttempt.Enabled = Job.JobID > 0;
            if (tcJobOfWorks.TabPages.Count > 0)
                tcJobOfWorks.SelectedTab = tcJobOfWorks.TabPages[0];
            rdoCallout.Enabled = false;
            rdoMisc.Enabled = false;
            rdoContract.Enabled = false;
            rdoQuoted.Enabled = false;
            cbxToBePartPaid.Enabled = false;
            txtRetention.Enabled = false;
            chkCollectPayment.Enabled = false;
            if (Job.StatusEnumID >= (int)Enums.JobStatus.Complete)
            {
                btnAddJobOfWork.Enabled = false;
                btnRemoveJobOfWork.Enabled = false;
                OnForm.btnSave.Enabled = false;
                OnForm.btnAddAppliance.Visible = false;
            }

            if (Job.JobCreationType == (int)Enums.JobCreationType.JobManager & !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor))
            {
                btnAddJobOfWork.Visible = false;
                btnRemoveJobOfWork.Visible = false;
                foreach (TabPage page in tcJobOfWorks.TabPages)
                {
                    ((UCCalloutBreakdown)page.Controls[0]).btnAddEngineerVisit.Visible = false;
                    ((UCCalloutBreakdown)page.Controls[0]).btnRemoveEngineerVisit.Visible = false;
                }
            }

            if (Job.JobCreationType == (int)Enums.JobCreationType.LetterManager)
            {
                bool JOWbuttonEnabled = true;
                foreach (Entity.JobOfWorks.JobOfWork jobOfWork in JobOfWorks)
                {
                    if (jobOfWork.Status == (int)Enums.JobOfWorkStatus.Open)
                    {
                        JOWbuttonEnabled = false;
                    }
                }

                btnAddJobOfWork.Visible = JOWbuttonEnabled;
                btnRemoveJobOfWork.Visible = JOWbuttonEnabled;
                foreach (TabPage page in tcJobOfWorks.TabPages)
                {
                    ((UCCalloutBreakdown)page.Controls[0]).btnAddEngineerVisit.Visible = false;
                    ((UCCalloutBreakdown)page.Controls[0]).btnRemoveEngineerVisit.Visible = false;
                }
            }

            if (Customer.CustomerID == (int)Enums.Customer.Vehicle)
            {
                cboJobType.Enabled = true;
                btnChange.Visible = false;
                var argc = cboJobType;
                Combo.SetUpCombo(ref argc, App.DB.Fleet.FleetJobType_GetAll().Table, "JobTypeID", "Name", Enums.ComboValues.Please_Select);
                int vanId = 0;
                if (Job.JobTypeID == (int)Enums.FleetJobTypes.VanFault)
                {
                    var oVanFault = App.DB.FleetVanFault.Get_ByJobID(Job.JobID);
                    if (oVanFault is object)
                    {
                        vanId = oVanFault.VanID;
                    }
                }

                if (Job.JobTypeID == (int)Enums.FleetJobTypes.VanMaintenance)
                {
                    vanId = App.DB.FleetVanService.GetVanId_ByJobId(Job.JobID);
                    btnfindVan.Enabled = true;
                }

                if (vanId > 0)
                {
                    Fleet = App.DB.FleetVan.Get(vanId);
                    txtVanReg.Text = Fleet.Registration;
                }

                txtVanReg.Visible = true;
                btnfindVan.Visible = true;
            }
            else
            {
                var argc1 = cboJobType;
                Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
                txtVanReg.Visible = false;
                btnfindVan.Visible = false;
            }

            var argcombo1 = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Job.JobTypeID.ToString());
            if (DvAssets is object)
            {
                foreach (DataRow row in OnForm.AssetsDataView.Table.Rows)
                {
                    foreach (DataRow dr in DvAssets.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Conversions.ToInteger(row["AssetID"]), dr["AssetID"], false)))
                        {
                            row["Tick"] = true;
                            break;
                        }
                    }
                }
            }

            if (App.IsRFT)
            {
                gbPaymentType.Visible = false;
                chkOTI.Checked = true;
            }

            int jobLockUserId = OnForm?.JobLock?.UserID ?? App.loggedInUser.UserID;
            if (jobLockUserId != App.loggedInUser.UserID)
            {
                OnForm.MakeReadOnly();
            }

            if (Job.JobID == 0)
            {
                if (!Helper.IsStringEmpty(Site.ContactAlerts))
                    ((UCVisitBreakdown)((UCCalloutBreakdown)tcJobOfWorks?.TabPages[0].Controls[0]).tcEngineerVisits.TabPages[0].Controls[0]).txtNotesToEngineer.Text = Site.ContactAlerts + " - ";
            }
        }

        private void PopulateSite()
        {
            txtCustomerName.Text = Customer.Name;
            txtSiteDetails.Text = Site.Address1 + " " + Site.Address2 + ", " + Site.Postcode;
            txtSiteName.Text = Site.Name;
            txtContact.Text = "Tel: " + Site.TelephoneNum + " Mob: " + Site.FaxNum;
            Entity.Sites.Site currentSiteHQ;
            currentSiteHQ = App.DB.Sites.Get(Customer.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
            if (currentSiteHQ is object)
            {
                txtCustomerName.Text += " - " + currentSiteHQ.Address1 + ", " + currentSiteHQ.Address2 + " (Tel: " + currentSiteHQ.TelephoneNum + ")";
            }

            if ((Enums.CustomerStatus)Customer.Status == Enums.CustomerStatus.OnHold)
            {
                lblOnHold.Visible = true;
            }
            else
            {
                lblOnHold.Visible = false;
            }

            if (OnForm.AssetsDataView is null)
            {
                OnForm.AssetsDataView = DvSiteAssets;
            }
        }

        private void PopulateJobOfWorks()
        {
            if (JobOfWorks.Count > 0)
            {
                JobOfWorks.ForEach(x => AddJobOfWork(x));
            }
            else
            {
                AddJobOfWork(null);
            }
        }

        public void PopulateContract()
        {
            var currentContract = App.DB.ContractOriginal.Get_Current_ForSite(Site.SiteID);
            if (currentContract is null)
            {
                txtCurrentContract.Text = "Not on contract";
                lblContractInactive.Visible = false;
            }
            else
            {
                txtCurrentContract.Text = currentContract.ContractType + Environment.NewLine + ((Enums.ContractStatus)currentContract.ContractStatusID).ToString() + Environment.NewLine +
                    "Expires " + currentContract.ContractEndDate.ToString("dd/MM/yyyy");
                if (currentContract.ContractStatusID == Conversions.ToInteger(Enums.ContractStatus.Inactive))
                {
                    lblContractInactive.Visible = true;
                }
                else
                {
                    lblContractInactive.Visible = false;
                }
            }
        }

        private void PopulateContactAttempts()
        {
            ContactAttempts = App.DB.ContactAttempts.GetAll_ForJob(JobId);
            if (ContactAttempts?.Count > 0 == true)
            {
                var contactAttempt = ContactAttempts.OrderByDescending(ca => ca.ContactMade).FirstOrDefault();
                if (contactAttempt is object)
                {
                    txtLastContact.Text = contactAttempt.ContactMade.ToString("dddd, dd MMMM yyyy HH:mm") + ": " + contactAttempt.ContactMethod;
                    if (contactAttempt.Notes.Trim().Length > 0)
                    {
                        txtLastContact.Text += " - " + contactAttempt.Notes;
                    }

                    if (contactAttempt.ContactMadeBy.Trim().Length > 0)
                    {
                        txtLastContact.Text += " by " + contactAttempt.ContactMadeBy;
                    }
                }
            }
        }

        public void PaymentTypeChanged()
        {
            if (Job.JobID == 0)
            {
                App.DB.Job.DeleteReservedOrderNumber(JobNumber.Number, JobNumber.Prefix);
                JobNumber = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)Job.JobDefinitionEnumID);
                Job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                txtJobNumber.Text = Job.JobNumber;
            }
        }

        private TabPage AddJobOfWork(Entity.JobOfWorks.JobOfWork jobOfWork)
        {
            var tp = new TabPage();
            tp.BackColor = Color.White;
            var ctrl = new UCCalloutBreakdown();
            ctrl.OnContol = this;
            if (jobOfWork is null)
            {
                foreach (DataRow a in DvSiteAssets.Table.Rows)
                {
                    if (Helper.MakeDateTimeValid(a["WarrantyStartDate"]) < DateAndTime.Now & Helper.MakeDateTimeValid(a["WarrantyEndDate"]) > DateAndTime.Now)
                    {
                        App.ShowMessage("One or more assets are under warranty.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }

            ctrl.JobOfWork = jobOfWork;
            ctrl.Populate();
            ctrl.Dock = DockStyle.Fill;
            tp.Controls.Add(ctrl);
            tcJobOfWorks.TabPages.Add(tp);
            CheckTabs();
            tcJobOfWorks.SelectedTab = tp;
            return tp;
        }

        private void RemoveJobOfWork()
        {
            if (((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0)
            {
                if (App.ShowMessage("Items of work has been added to this visit, are you sure you want to remove it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            foreach (TabPage tp in ((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages)
            {
                if (((UCVisitBreakdown)tp.Controls[0]).EngineerVisit.StatusEnumID >= Conversions.ToInteger(Enums.VisitStatus.Scheduled))
                {
                    App.ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (((UCVisitBreakdown)tp.Controls[0]).EngineerVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Parts_Need_Ordering))
                {
                    App.ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    bool ordered = false;
                    foreach (TabPage tpev in ((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages)
                    {
                        if (((UCVisitBreakdown)tpev.Controls[0]).EngineerVisit.EngineerVisitID > 0)
                        {
                            var engOrders = App.DB.Order.Orders_GetForEngineerVisit(((UCVisitBreakdown)tpev.Controls[0]).EngineerVisit.EngineerVisitID);
                            if (engOrders.Table.Rows.Count > 0)
                            {
                                foreach (DataRow dr in engOrders.Table.Rows)
                                {
                                    // WHAT STATUS ARE THEY?
                                    if ((Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.AwaitingConfirmation | (Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.Cancelled)
                                    {
                                    }
                                    // IF ARE AWAITING - ADD TO LIST TO REMOVE
                                    // ALL OK
                                    else
                                    {
                                        ordered = true;
                                    }
                                    // ordered = True
                                }
                            }
                        }
                    }

                    if (ordered)
                    {
                        App.ShowMessage("This job of work has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            foreach (TabPage tp in ((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages)
            {
                if (((UCVisitBreakdown)tp.Controls[0]).EngineerVisit.EngineerVisitID > 0)
                {
                    foreach (TabPage tpev in ((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages)
                    {
                        if (((UCVisitBreakdown)tpev.Controls[0]).EngineerVisit.EngineerVisitID > 0)
                        {
                            var engOrders = App.DB.Order.Orders_GetForEngineerVisit(((UCVisitBreakdown)tpev.Controls[0]).EngineerVisit.EngineerVisitID);
                            if (engOrders.Table.Rows.Count > 0)
                            {
                                foreach (DataRow dr in engOrders.Table.Rows)
                                {
                                    // WHAT STATUS ARE THEY?
                                    if ((Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.AwaitingConfirmation | (Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.Cancelled)
                                    {
                                        // IF ARE AWAITING - ADD TO LIST TO REMOVE
                                        EngineerVisitsOrdersRemoved.Add(dr["OrderID"]);
                                    }
                                }
                            }
                        }
                    }

                    EngineerVisitsRemoved.Add(((UCVisitBreakdown)tp.Controls[0]).EngineerVisit.EngineerVisitID);
                }
            }

            if (((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).JobOfWork.JobOfWorkID > 0)
            {
                JobOfWorksRemoved.Add(((UCCalloutBreakdown)tcJobOfWorks.SelectedTab.Controls[0]).JobOfWork.JobOfWorkID);
            }

            tcJobOfWorks.TabPages.Remove(tcJobOfWorks.SelectedTab);
            CheckTabs();
        }

        private void CheckTabs()
        {
            if (tcJobOfWorks.TabPages.Count == 1)
            {
                btnRemoveJobOfWork.Enabled = false;
            }
            else
            {
                btnRemoveJobOfWork.Enabled = true;
            }

            int i = 1;
            foreach (TabPage tab in tcJobOfWorks.TabPages)
            {
                tab.Text = "Job Of Work #" + i;
                i += 1;
            }
        }

        public bool Save()
        {
            int LastVisitStatus = 0;
            int CureentJOWCount = 0;
            int NewJOWCount = 0;
            string JOW3Priority = null;
            foreach (int visitID in EngineerVisitsRemoved)
            {
                var newVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(visitID);
                if (newVisit.StatusEnumID >= Conversions.ToInteger(Enums.VisitStatus.Scheduled))
                {
                    App.ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.  Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnForm.CloseForm();
                }
                else if (newVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Parts_Need_Ordering))
                {
                    App.ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering' so job of work cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnForm.CloseForm();
                }
                else
                {
                    bool ordered = false;
                    if (newVisit.Exists)
                    {
                        var engOrders = App.DB.Order.Orders_GetForEngineerVisit(newVisit.EngineerVisitID);
                        if (engOrders.Table.Rows.Count > 0)
                        {
                            foreach (DataRow dr in engOrders.Table.Rows)
                            {
                                // WHAT STATUS ARE THEY?
                                if ((Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.AwaitingConfirmation | (Enums.OrderStatus)Conversions.ToInteger(dr["OrderStatusID"]) == Enums.OrderStatus.Cancelled)
                                {
                                }
                                // IF ARE AWAITING - ADD TO LIST TO REMOVE
                                // ALL OK
                                else
                                {
                                    ordered = true;
                                }
                            }
                        }
                    }

                    if (ordered)
                    {
                        App.ShowMessage("This job of work has orders that are being processed and therefore cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnForm.CloseForm();
                        return default;
                    }
                }
            }

            System.Data.SqlClient.SqlTransaction trans = null;
            System.Data.SqlClient.SqlConnection con = null;
            try
            {
                con = new System.Data.SqlClient.SqlConnection(App.DB.ServerConnectionString);
                con.Open();
                trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);
                bool PONumberEntered = true;
                foreach (TabPage page in tcJobOfWorks.TabPages)
                {
                    if (((UCCalloutBreakdown)page.Controls[0]).txtPONumber.Text.Length == 0)
                    {
                        PONumberEntered = false;
                    }
                }

                if (PONumberEntered == false & Site.PoNumReqd == true)
                {
                    if (App.ShowMessage("A Purchase Order Number is required for this Property, Would you like to Override?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!App.EnterOverridePassword())
                        {
                            return false;
                            return default;
                        }
                    }
                    else
                    {
                        return default;
                    }
                }

                Cursor = Cursors.WaitCursor;
                var currentJob = new Entity.Jobs.Job()
                {
                    SetJobID = Job.JobID,
                    SetJobTypeID = Job.JobTypeID,
                    SetPropertyID = Site.SiteID
                };
                currentJob.Exists = currentJob.JobID > 0;
                if (currentJob.JobTypeID == (int)Enums.FleetJobTypes.VanMaintenance)
                {
                    if (Fleet is object && Fleet.Exists)
                    {
                        if (App.ShowMessage("Remove service from van?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.DB.FleetVanService.Delete(currentJob.JobID);
                        }
                    }
                }

                currentJob.IgnoreExceptionsOnSetMethods = true;
                if (rdoCallout.Checked)
                {
                    currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Callout);
                }
                else if (rdoMisc.Checked)
                {
                    currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Misc);
                }
                else if (rdoContract.Checked)
                {
                    currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Contract);
                }
                else if (rdoQuoted.Checked)
                {
                    currentJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Quoted);
                }

                currentJob.SetJobTypeID = Combo.get_GetSelectedItemValue(cboJobType);
                currentJob.SetJobNumber = txtJobNumber.Text.Trim();
                currentJob.SetPONumber = ""; // Me.txtPONumber.Text.Trim
                currentJob.SetToBePartPaid = cbxToBePartPaid.Checked;
                currentJob.SetRetention = Helper.MakeDoubleValid(txtRetention.Text);
                currentJob.SetCollectPayment = chkCollectPayment.Checked;
                currentJob.SetPOC = chkPOC.Checked;
                currentJob.SetOTI = chkOTI.Checked;
                currentJob.SetFOC = chkFoc.Checked;
                currentJob.SetSalesRepUserID = SalesRep.UserID;
                currentJob.SetHeadline = txtHeadline.Text;
                currentJob.Assets.Clear();
                foreach (DataRow row in OnForm.AssetsDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        var oJobAsset = new Entity.JobAssets.JobAsset();
                        oJobAsset.SetAssetID = Helper.MakeIntegerValid(row["AssetID"]);
                        currentJob.Assets.Add(oJobAsset);
                    }
                }

                CureentJOWCount = currentJob.JobOfWorks.Count;
                int ValidJOWCount = 0;
                Entity.EngineerVisits.EngineerVisit currentVisit = null;
                int jobPriority = 0;
                currentJob.JobOfWorks.Clear();
                int LoopCount = 0;
                foreach (TabPage page in tcJobOfWorks.TabPages)
                {
                    LoopCount += 1;
                    var jow = new Entity.JobOfWorks.JobOfWork() { SetJobOfWorkID = ((UCCalloutBreakdown)page.Controls[0]).JobOfWork.JobOfWorkID };
                    jow.Exists = jow.JobOfWorkID > 0;
                    jow.SetPONumber = ((UCCalloutBreakdown)page.Controls[0]).txtPONumber.Text;
                    jow.SetQualificationID = Combo.get_GetSelectedItemValue(((UCCalloutBreakdown)page.Controls[0]).cboQualification);
                    jobPriority = Conversions.ToInteger(Combo.get_GetSelectedItemValue(((UCCalloutBreakdown)page.Controls[0]).cboPriority));
                    if (jobPriority > 0)
                    {
                        jow.SetPriority = jobPriority;
                    }
                    else
                    {
                        jobPriority = jow.Priority;
                    }

                    if (LoopCount >= 3)
                        JOW3Priority = jow.Priority.ToString();
                    if (jow.PriorityDateSet == DateTime.MinValue & Conversions.ToDouble(Combo.get_GetSelectedItemValue(((UCCalloutBreakdown)page.Controls[0]).cboPriority)) > 0)
                    {
                        jow.PriorityDateSet = DateAndTime.Now;
                    }

                    jow.IgnoreExceptionsOnSetMethods = true;
                    jow.JobItems.Clear();
                    foreach (DataRow row in ((UCCalloutBreakdown)page.Controls[0]).JobItemsAddedDataView.Table.Rows)
                    {
                        var oJobItem = new Entity.JobItems.JobItem();
                        oJobItem.IgnoreExceptionsOnSetMethods = true;
                        oJobItem.SetJobItemID = Helper.MakeIntegerValid(row["JobItemID"]);
                        oJobItem.SetSummary = Helper.MakeStringValid(row["Summary"]);
                        oJobItem.SetRateID = Helper.MakeIntegerValid(row["RateID"]);
                        oJobItem.SetQty = Helper.MakeDoubleValid(row["Qty"]);
                        oJobItem.SetSystemLinkID = Helper.MakeDoubleValid(row["SystemLinkID"]);
                        jow.JobItems.Add(oJobItem);
                    }

                    jow.EngineerVisits.Clear();
                    int visitcount = ((UCCalloutBreakdown)page.Controls[0]).tcEngineerVisits.TabPages.Count;
                    int visitcounter = 1;
                    foreach (TabPage subpage in ((UCCalloutBreakdown)page.Controls[0]).tcEngineerVisits.TabPages)
                    {
                        var visit = new Entity.EngineerVisits.EngineerVisit() { SetEngineerVisitID = ((UCVisitBreakdown)subpage.Controls[0]).EngineerVisit.EngineerVisitID };
                        visit.Exists = visit.EngineerVisitID > 0;
                        visit.IgnoreExceptionsOnSetMethods = true;
                        visit.SetStatusEnumID = Combo.get_GetSelectedItemValue(((UCVisitBreakdown)subpage.Controls[0]).cboStatus);
                        visit.SetNotesToEngineer = ((UCVisitBreakdown)subpage.Controls[0]).txtNotesToEngineer.Text.Trim();
                        visit.SetPartsToFit = ((UCVisitBreakdown)subpage.Controls[0]).cbxPartsToFit.Checked;
                        visit.PartsAndProductsAllocated = ((UCVisitBreakdown)subpage.Controls[0]).PartsAndProducts;
                        visit.SetExpectedEngineerID = Combo.get_GetSelectedItemValue(((UCVisitBreakdown)subpage.Controls[0]).cboExpected);
                        visit.SetRecharge = ((UCVisitBreakdown)subpage.Controls[0]).chkRecharge.Checked;
                        visit.setChange = ((UCVisitBreakdown)subpage.Controls[0]).change;
                        visit.SetExcludeFromTextMessage = ((UCVisitBreakdown)subpage.Controls[0]).chkSendText.Checked;
                        jow.EngineerVisits.Add(visit);
                        if (LoopCount == 1 & visitcount == 1)
                            currentVisit = visit;
                        CleanUpOrdersForPartProductsAllocated(((UCVisitBreakdown)subpage.Controls[0]).PartsProductsToRemoveFromOrder, ((UCVisitBreakdown)subpage.Controls[0]).PartsProductsToReallocated, trans);
                        ((UCVisitBreakdown)subpage.Controls[0]).PartsProductsToRemoveFromOrder = null;
                        ((UCVisitBreakdown)subpage.Controls[0]).PartsProductsToReallocated = null;
                        LastVisitStatus = visit.OutcomeEnumID;
                        if (visitcounter == visitcount)
                        {
                            if (LastVisitStatus == 1 | LastVisitStatus == 5)
                            {
                                ValidJOWCount += 1;
                            }
                        }

                        visitcounter += 1;
                    }

                    currentJob.JobOfWorks.Add(jow);
                }

                try
                {
                    var jV = new Entity.Jobs.JobValidator();
                    jV.Validate(currentJob);

                    // update van information if necessary
                    if (currentJob.JobTypeID == (int)Enums.FleetJobTypes.VanFault)
                    {
                        // check if job logged against fault already
                        Entity.FleetVans.FleetVanFault currentFault = null;
                        if (currentJob.Exists)
                        {
                            currentFault = App.DB.FleetVanFault.Get_ByJobID(currentJob.JobID);
                        }

                        if (currentFault is null)
                        {
                            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVanFault));
                            if (!(ID == 0))
                            {
                                currentFault = App.DB.FleetVanFault.Get(ID);
                                if (currentFault is object)
                                {
                                    currentFault.SetJobID = currentJob.JobID;
                                    App.DB.FleetVanFault.Update(currentFault);
                                    Fleet = App.DB.FleetVan.Get(currentFault.VanID);
                                }
                            }
                        }
                    }

                    if (!currentJob.Exists)
                    {
                        currentJob = App.DB.Job.Insert(currentJob, trans);
                        trans.Commit();
                        if (currentJob.JobTypeID == (int)Enums.JobTypes.Breakdown)
                            EmailServiceAlertDate();
                        App.ShowMessage("Job added for job number : " + currentJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        App.DB.Job.Update(currentJob, JobOfWorksRemoved, EngineerVisitsRemoved, EngineerVisitsOrdersRemoved, trans);
                        trans.Commit();
                        App.ShowMessage("Job details updated for job number : " + currentJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (currentJob.JobTypeID == (int)Enums.FleetJobTypes.VanMaintenance)
                    {
                        if (Fleet is object && Fleet.Exists)
                        {
                            int jobid = currentJob.JobID;
                            App.DB.FleetVanService.Insert(currentJob.JobID, Fleet.VanID);
                        }
                    }

                    App.CurrentCustomerID = Customer.CustomerID;
                    foreach (Entity.JobOfWorks.JobOfWork oJobOfWork in currentJob.JobOfWorks)
                    {
                        foreach (Entity.EngineerVisits.EngineerVisit oEngineerVisit in oJobOfWork.EngineerVisits)
                            App.DB.EngineerVisitPartProductAllocated.SplitToOrder(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, currentJob.JobID);
                    }

                    NewJOWCount = currentJob.JobOfWorks.Count;
                    if (ValidJOWCount >= 3 & IsNewJobOfWork & currentJob.JobTypeID == (int)Enums.JobTypes.Breakdown)
                    {
                        int custId = 0;
                        List<string> emailAddresses = null;
                        if (Customer.CustomerTypeID != (int)Enums.CustomerType.SocialHousing)
                        {
                            custId = (int)Enums.Customer.Domestic;
                        }
                        else
                        {
                            custId = Customer.CustomerID;
                        }

                        var customerAlerts = App.DB.CustomerAlert.Get_ForCustomer(custId);
                        if (customerAlerts?.Count > 0 == true)
                        {
                            emailAddresses = customerAlerts.Where(x => x.AlertTypeId == (int)Enums.AlertType.Jow).FirstOrDefault().EmailAddress.Split(new char[] { ';' }).ToList();
                        }

                        var cleanEmailList = new List<string>();
                        if (emailAddresses is object)
                        {
                            foreach (string emailAddress in emailAddresses)
                            {
                                if (Helper.IsEmailValid(emailAddress))
                                    cleanEmailList.Add(emailAddress);
                            }
                        }

                        if (cleanEmailList.Count > 0)
                        {
                            string JobNo = currentJob.JobNumber;
                            string Priority = JOW3Priority;
                            int JOWCount = currentJob.JobOfWorks.Count;
                            string SiteAddress = Site.Address1 + " " + Site.Address2 + ", " + Site.Postcode;
                            string Customer = this.Customer.Name;
                            string ContractType = txtCurrentContract.Text;
                            string CurrentUser = App.loggedInUser.Fullname;
                            string LastVisit = "Coming Soon";
                            string PersonName = null;
                            string GreetingPart = null;
                            if (DateAndTime.Now.Hour >= 3 & DateAndTime.Now.Hour < 12)
                            {
                                GreetingPart = "Morning";
                            }
                            else if (DateAndTime.Now.Hour >= 12 & DateAndTime.Now.Hour < 17)
                            {
                                GreetingPart = "Afternoon";
                            }
                            else
                            {
                                GreetingPart = "Evening";
                            }

                            PersonName = "Good " + GreetingPart;
                            var FeedbackEmail = new Emails();
                            FeedbackEmail.From = EmailAddress.Gabriel;
                            foreach (string email in cleanEmailList)
                                FeedbackEmail.ToList.Add(email);
                            FeedbackEmail.Subject = "3rd Job of Works Notification";
                            FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" + "<p>" + PersonName + "</p>" + "<p>A new job of works has been created that exceeds the alerting threshold, details are below:-</p>" + "<p>Job Number - <b>" + JobNo + "</b>" + "<br/> Priority - <b>" + JOW3Priority + "</b>" + "<br/>Customer - <b>" + Customer + "</b>" + "<br/>Site - <b>" + SiteAddress + "</b>" + "<br/>Contract Type - <b>" + ContractType + "</b>" + "<br/>JOW Count - <b>" + JOWCount + "</b>" + "<br/>User - <b>" + CurrentUser + "</b>" + "<br/>Last Visit - <b>" + LastVisit + "</b>" + "<p>" + App.TheSystem.Configuration.CompanyName + "</p>" + "</span>";
                            FeedbackEmail.SendMe = true;
                            FeedbackEmail.Send();
                            IsNewJobOfWork = false;
                        }
                    }

                    JobId = currentJob.JobID;
                    Populate();
                }
                catch (ValidationException vex)
                {
                    string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (trans is object)
                    {
                        trans.Rollback();
                    }

                    if (con is object)
                    {
                        con.Close();
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (trans is object)
                    {
                        trans.Rollback();
                    }

                    if (con is object)
                    {
                        con.Close();
                    }

                    return false;
                }

                StateChanged?.Invoke(currentJob.JobID);
                return true;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (trans is object)
                {
                    trans.Rollback();
                }

                if (con is object)
                {
                    con.Close();
                }

                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CleanUpOrdersForPartProductsAllocated(ArrayList toRemove, ArrayList toReallocate, System.Data.SqlClient.SqlTransaction trans)
        {
            int i = 0;
            if (toRemove is object)
            {
                // REMOVING PARTS/PRODUCTS FROM AN ORDER
                var loopTo = toRemove.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    ArrayList aR = (ArrayList)toRemove[i];
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(aR[0], "Part", false) & Conversions.ToInteger(aR[4]) == Conversions.ToInteger(Enums.LocationType.Supplier)))
                    {
                        App.DB.OrderPart.Delete(Conversions.ToInteger(aR[3]), trans);
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(aR[0], "Product", false) & Conversions.ToInteger(aR[4]) == Conversions.ToInteger(Enums.LocationType.Supplier)))
                    {
                        App.DB.OrderProduct.Delete(Conversions.ToInteger(aR[3]), trans);
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(aR[0], "Part", false) & Conversions.ToInteger(aR[4]) != Conversions.ToInteger(Enums.LocationType.Supplier)))
                    {
                        var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                        oOrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(aR[3]), trans);
                        App.DB.OrderLocationPart.Delete(oOrderLocationPart.OrderLocationPartID, trans);
                        var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                        oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID, trans);
                        if (oPartTransaction is object)
                        {
                            App.DB.PartTransaction.Delete(oPartTransaction.PartTransactionID, trans);
                        }
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(aR[0], "Product", false) & Conversions.ToInteger(aR[4]) != Conversions.ToInteger(Enums.LocationType.Supplier)))
                    {
                        var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                        oOrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(aR[3]), trans);
                        App.DB.OrderLocationProduct.Delete(oOrderLocationProduct.OrderLocationProductID, trans);
                        var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                        oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID, trans);
                        if (oProductTransaction is object)
                        {
                            App.DB.ProductTransaction.Delete(oProductTransaction.ProductTransactionID, trans);
                        }
                    }
                }
            }

            if (toReallocate is object)
            {
                // REALLOCATE
                int ID = 0;
                if (toReallocate.Count > 0)
                {
                    // locationID to move to
                    ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans));
                }

                var loopTo1 = toReallocate.Count - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    ArrayList aA = (ArrayList)toReallocate[i];

                    // is it a part or a product?
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(aA[0], "Part", false)))
                    {
                        var PartTran = new Entity.PartTransactions.PartTransaction();
                        PartTran.SetAmount = aA[1];
                        PartTran.SetLocationID = ID;
                        PartTran.SetOrderLocationPartID = 0;
                        PartTran.SetOrderPartID = 0;
                        PartTran.SetPartID = aA[2];
                        PartTran.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                        PartTran.SetUserID = App.loggedInUser.UserID;
                        PartTran.TransactionDate = DateAndTime.Now;
                        App.DB.PartTransaction.Insert(PartTran, trans);
                    }
                    else
                    {
                        var ProductTran = new Entity.ProductTransactions.ProductTransaction();
                        ProductTran.SetAmount = aA[1];
                        ProductTran.SetLocationID = ID;
                        ProductTran.SetOrderLocationProductID = 0;
                        ProductTran.SetOrderProductID = 0;
                        ProductTran.SetProductID = aA[2];
                        ProductTran.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                        ProductTran.SetUserID = App.loggedInUser.UserID;
                        ProductTran.TransactionDate = DateAndTime.Now;
                        App.DB.ProductTransaction.Insert(ProductTran, trans);
                    }
                }
            }
        }

        private void cboJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Site.CustomerID == (int)Enums.Customer.Vehicle)
            {
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == (double)Enums.FleetJobTypes.VanMaintenance)
                {
                    btnfindVan.Enabled = true;
                }
                else
                {
                    btnfindVan.Enabled = false;
                }
            }
        }

        private void btnfindVan_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVan));
            if (!(ID == 0))
            {
                Fleet = App.DB.FleetVan.Get(ID);
            }
        }

        private void EmailServiceAlertDate()
        {
            if (Site is object && !Site.NoService)
            {
                int custId = 0;
                List<string> emailAddresses = null;
                if (Customer.CustomerTypeID != (int)Enums.CustomerType.SocialHousing)
                {
                    custId = (int)Enums.Customer.Domestic;
                }
                else
                {
                    custId = Customer.CustomerID;
                }

                var customerAlerts = App.DB.CustomerAlert.Get_ForCustomer(custId);
                if (customerAlerts?.Count > 0 == true)
                {
                    emailAddresses = customerAlerts.Where(x => x.AlertTypeId == (int)Enums.AlertType.JobCreation).FirstOrDefault().EmailAddress.Split(new char[] { ';' }).ToList();
                }

                var cleanEmailList = new List<string>();
                if (emailAddresses is object)
                {
                    foreach (string emailAddress in emailAddresses)
                    {
                        if (Helper.IsEmailValid(emailAddress))
                            cleanEmailList.Add(emailAddress);
                    }
                }

                if (cleanEmailList.Count > 0)
                {
                    var servicedate = Site.LastServiceDate;
                    servicedate = servicedate.AddYears(1);
                    if ((!(servicedate == DateTime.MinValue.AddYears(1)) && servicedate <= DateAndTime.Now.Date) & servicedate.AddYears(1) >= DateAndTime.Now.Date)
                    {
                        var email = new Emails();
                        foreach (string cleanEmail in cleanEmailList)
                            email.ToList.Add(cleanEmail);
                        email.From = EmailAddress.FSM;
                        email.Subject = "Job Created on Site Due for Service!";
                        string html = "<table border='1'>";
                        html += "<tr>";
                        html += "<td>Name</td><td>Address1</td><td>Address2</td><td>PostCode</td><td>Job Number</td>";
                        html += "</tr>";
                        html += "<tr>";
                        html += "<td>" + Site.Name + "</td><td>" + Site.Address1 + "</td><td>" + Site.Address2 + "</td><td>" + Site.Postcode + "</td><td>" + Job.JobNumber + "</td>";
                        html += "</tr>";
                        html += "</table>";
                        email.Body = html;
                        email.SendMe = true;
                        email.Send();
                    }
                }
            }
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            if (SalesRep.Exists)
            {
                if (App.EnterOverridePassword() == false)
                {
                    return;
                }
            }

            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblUser));
            if (!(ID == 0))
            {
                SalesRep = App.DB.User.Get(ID);
            }
        }

        private void btnAddContactAttempt_Click(object sender, EventArgs e)
        {
            AddContactAttempt();
        }

        public void AddContactAttempt()
        {
            if (Job is object || Job.JobID > 0)
            {
                var frmContactAttempt = new FRMContactAttempt(Enums.TableNames.tblJob, Job.JobID);
                frmContactAttempt.ShowDialog();
                if (frmContactAttempt.DialogResult == DialogResult.OK)
                {
                    Populate(Job.JobID);
                    OnForm.PopulateContactAttempts();
                }
            }
        }
    }
}