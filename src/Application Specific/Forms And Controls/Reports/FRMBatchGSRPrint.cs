using FSM.Entity.Sys;
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
    public class FRMBatchGSRPrint : FRMBaseForm, IForm
    {
        public FRMBatchGSRPrint() : base()
        {
            base.Load += FRMVisitManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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
        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                }
            }
        }

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

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private ComboBox _cboDefinition;

        internal ComboBox cboDefinition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDefinition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDefinition != null)
                {
                }

                _cboDefinition = value;
                if (_cboDefinition != null)
                {
                }
            }
        }

        private Label _Label11;

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
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        private Label _Label10;

        private Label _Label9;

        private Label _Label8;

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

        private CheckBox _chkVisitDate;

        internal CheckBox chkVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged -= chkVisitDate_CheckedChanged;
                }

                _chkVisitDate = value;
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged += chkVisitDate_CheckedChanged;
                }
            }
        }

        private GroupBox _grpEngineerVisits;

        internal GroupBox grpEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerVisits != null)
                {
                }

                _grpEngineerVisits = value;
                if (_grpEngineerVisits != null)
                {
                }
            }
        }

        private DataGrid _dgVisits;

        internal DataGrid dgVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVisits != null)
                {
                    _dgVisits.MouseUp -= dgVisits_MouseUp;
                    _dgVisits.DoubleClick -= dgVisits_DoubleClick;
                }

                _dgVisits = value;
                if (_dgVisits != null)
                {
                    _dgVisits.MouseUp += dgVisits_MouseUp;
                    _dgVisits.DoubleClick += dgVisits_DoubleClick;
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
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

        private Button _btnFindCustomer;

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
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

        private Label _Label13;

        private ComboBox _cboOutcome;

        internal ComboBox cboOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOutcome != null)
                {
                }

                _cboOutcome = value;
                if (_cboOutcome != null)
                {
                }
            }
        }

        private Button _btnUnselect;

        private Button _btnSelectAll;

        private Button _btnPrint;

        private Button _btnExport;

        private CheckBox _chkPrintHdr;

        internal CheckBox chkPrintHdr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPrintHdr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPrintHdr != null)
                {
                }

                _chkPrintHdr = value;
                if (_chkPrintHdr != null)
                {
                }
            }
        }

        private CheckBox _chkExceptionsOnly;

        internal CheckBox chkExceptionsOnly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExceptionsOnly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExceptionsOnly != null)
                {
                }

                _chkExceptionsOnly = value;
                if (_chkExceptionsOnly != null)
                {
                }
            }
        }

        private Button _btnShowdata;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineerVisits = new GroupBox();
            _dgVisits = new DataGrid();
            _dgVisits.MouseUp += new MouseEventHandler(dgVisits_MouseUp);
            _dgVisits.DoubleClick += new EventHandler(dgVisits_DoubleClick);
            _grpFilter = new GroupBox();
            _chkExceptionsOnly = new CheckBox();
            _chkPrintHdr = new CheckBox();
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnShowdata = new Button();
            _btnShowdata.Click += new EventHandler(btnShowdata_Click);
            _cboOutcome = new ComboBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _txtPostcode = new TextBox();
            _Label1 = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtJobNumber = new TextBox();
            _Label9 = new Label();
            _Label8 = new Label();
            _chkVisitDate = new CheckBox();
            _chkVisitDate.CheckedChanged += new EventHandler(chkVisitDate_CheckedChanged);
            _Label6 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _Label11 = new Label();
            _cboDefinition = new ComboBox();
            _cboStatus = new ComboBox();
            _Label13 = new Label();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineerVisits
            //
            _grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerVisits.Controls.Add(_dgVisits);
            _grpEngineerVisits.Location = new Point(8, 256);
            _grpEngineerVisits.Name = "grpEngineerVisits";
            _grpEngineerVisits.Size = new Size(784, 205);
            _grpEngineerVisits.TabIndex = 2;
            _grpEngineerVisits.TabStop = false;
            _grpEngineerVisits.Text = "Double Click To View / Edit";
            //
            // dgVisits
            //
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(8, 18);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(768, 179);
            _dgVisits.TabIndex = 14;
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_chkExceptionsOnly);
            _grpFilter.Controls.Add(_chkPrintHdr);
            _grpFilter.Controls.Add(_btnUnselect);
            _grpFilter.Controls.Add(_btnSelectAll);
            _grpFilter.Controls.Add(_btnShowdata);
            _grpFilter.Controls.Add(_cboOutcome);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_txtPostcode);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkVisitDate);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboDefinition);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_Label13);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(784, 224);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // chkExceptionsOnly
            //
            _chkExceptionsOnly.AutoSize = true;
            _chkExceptionsOnly.Location = new Point(361, 197);
            _chkExceptionsOnly.Name = "chkExceptionsOnly";
            _chkExceptionsOnly.Size = new Size(147, 17);
            _chkExceptionsOnly.TabIndex = 39;
            _chkExceptionsOnly.Text = "Only Print Exceptions";
            _chkExceptionsOnly.UseVisualStyleBackColor = true;
            //
            // chkPrintHdr
            //
            _chkPrintHdr.AutoSize = true;
            _chkPrintHdr.Location = new Point(216, 197);
            _chkPrintHdr.Name = "chkPrintHdr";
            _chkPrintHdr.Size = new Size(129, 17);
            _chkPrintHdr.TabIndex = 38;
            _chkPrintHdr.Text = "Print Header Page";
            _chkPrintHdr.UseVisualStyleBackColor = true;
            //
            // btnUnselect
            //
            _btnUnselect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUnselect.Location = new Point(113, 192);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 37;
            _btnUnselect.Text = "Unselect All";
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Location = new Point(11, 192);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(96, 23);
            _btnSelectAll.TabIndex = 36;
            _btnSelectAll.Text = "Select All";
            //
            // btnShowdata
            //
            _btnShowdata.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnShowdata.Location = new Point(679, 192);
            _btnShowdata.Name = "btnShowdata";
            _btnShowdata.Size = new Size(96, 23);
            _btnShowdata.TabIndex = 35;
            _btnShowdata.Text = "Show Data";
            //
            // cboOutcome
            //
            _cboOutcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOutcome.Location = new Point(600, 115);
            _cboOutcome.Name = "cboOutcome";
            _cboOutcome.Size = new Size(176, 21);
            _cboOutcome.TabIndex = 34;
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(736, 19);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(104, 19);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(624, 21);
            _txtCustomer.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 16);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 27;
            _Label4.Text = "Customer";
            //
            // txtPostcode
            //
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPostcode.Location = new Point(104, 67);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(184, 21);
            _txtPostcode.TabIndex = 5;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 64);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 20;
            _Label1.Text = "Postcode";
            //
            // btnFindSite
            //
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(736, 43);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 4;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            //
            // txtSite
            //
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(104, 43);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(624, 21);
            _txtSite.TabIndex = 3;
            //
            // dtpTo
            //
            _dtpTo.Location = new Point(144, 163);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(144, 21);
            _dtpTo.TabIndex = 13;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(144, 139);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(144, 21);
            _dtpFrom.TabIndex = 12;
            //
            // txtJobNumber
            //
            _txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtJobNumber.Location = new Point(104, 115);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(184, 21);
            _txtJobNumber.TabIndex = 9;
            //
            // Label9
            //
            _Label9.Location = new Point(104, 160);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Location = new Point(104, 136);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // chkVisitDate
            //
            _chkVisitDate.Cursor = Cursors.Hand;
            _chkVisitDate.Location = new Point(8, 136);
            _chkVisitDate.Name = "chkVisitDate";
            _chkVisitDate.Size = new Size(80, 24);
            _chkVisitDate.TabIndex = 11;
            _chkVisitDate.Text = "Visit Date";
            _chkVisitDate.UseVisualStyleBackColor = true;
            //
            // Label6
            //
            _Label6.Location = new Point(8, 112);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Job Number";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 88);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 16);
            _Label3.TabIndex = 3;
            _Label3.Text = "Definition";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 40);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Site";
            //
            // Label10
            //
            _Label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label10.Location = new Point(296, 92);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 16);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(344, 91);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(184, 21);
            _cboType.TabIndex = 7;
            //
            // Label11
            //
            _Label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label11.Location = new Point(536, 95);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 16);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            //
            // cboDefinition
            //
            _cboDefinition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDefinition.Location = new Point(104, 92);
            _cboDefinition.Name = "cboDefinition";
            _cboDefinition.Size = new Size(184, 21);
            _cboDefinition.TabIndex = 6;
            //
            // cboStatus
            //
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(600, 91);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(176, 21);
            _cboStatus.TabIndex = 8;
            //
            // Label13
            //
            _Label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label13.Location = new Point(536, 118);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(64, 16);
            _Label13.TabIndex = 33;
            _Label13.Text = "Outcome";
            //
            // btnPrint
            //
            _btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrint.Location = new Point(692, 467);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(96, 23);
            _btnPrint.TabIndex = 36;
            _btnPrint.Text = "Print GSRs";
            //
            // btnExport
            //
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(16, 467);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(96, 23);
            _btnExport.TabIndex = 37;
            _btnExport.Text = "Export";
            //
            // FRMBatchGSRPrint
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 494);
            Controls.Add(_btnExport);
            Controls.Add(_btnPrint);
            Controls.Add(_grpEngineerVisits);
            Controls.Add(_grpFilter);
            MinimumSize = new Size(808, 528);
            Name = "FRMBatchGSRPrint";
            Text = "Batch GSR Print";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_grpEngineerVisits, 0);
            Controls.SetChildIndex(_btnPrint, 0);
            Controls.SetChildIndex(_btnExport, 0);
            _grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboDefinition;
            Combo.SetUpCombo(ref argc, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc1 = cboType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc2 = cboStatus;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc3 = cboOutcome;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            SetupVisitDataGrid();
            PopulateDatagrid();
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
        }

        private DataView _dvVisits;

        private DataView VisitsDataview
        {
            get
            {
                return _dvVisits;
            }

            set
            {
                _dvVisits = value;
                _dvVisits.AllowNew = false;
                _dvVisits.AllowEdit = false;
                _dvVisits.AllowDelete = false;
                _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
                dgVisits.DataSource = VisitsDataview;
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
                if (!(dgVisits.CurrentRowIndex == -1))
                {
                    return VisitsDataview[dgVisits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        public Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                theSite = null;
                if (_theCustomer is object)
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + theCustomer.AccountNumber + ")";
                    btnFindSite.Enabled = true;
                }
                else
                {
                    txtCustomer.Text = "";
                    btnFindSite.Enabled = false;
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSite.Text = theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                }
                else
                {
                    txtSite.Text = "";
                }
            }
        }

        private void SetupVisitDataGrid()
        {
            var tbStyle = dgVisits.TableStyles[0];
            var tick = new DataGridBoolColumn();
            tick.HeaderText = "";
            tick.MappingName = "tick";
            tick.ReadOnly = true;
            tick.Width = 25;
            tick.NullText = "";
            tbStyle.GridColumnStyles.Add(tick);
            var Emailtick = new DataGridBoolColumn();
            Emailtick.HeaderText = "Sending Email";
            Emailtick.MappingName = "EmailSend";
            Emailtick.ReadOnly = true;
            Emailtick.Width = 75;
            Emailtick.NullText = "";
            tbStyle.GridColumnStyles.Add(Emailtick);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Site";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "SitePostcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 75;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var JobDefinition = new DataGridLabelColumn();
            JobDefinition.Format = "";
            JobDefinition.FormatInfo = null;
            JobDefinition.HeaderText = "Definition";
            JobDefinition.MappingName = "JobDefinition";
            JobDefinition.ReadOnly = true;
            JobDefinition.Width = 75;
            JobDefinition.NullText = "";
            tbStyle.GridColumnStyles.Add(JobDefinition);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 75;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var VisitOutcome = new DataGridLabelColumn();
            VisitOutcome.Format = "";
            VisitOutcome.FormatInfo = null;
            VisitOutcome.HeaderText = "Outcome";
            VisitOutcome.MappingName = "VisitOutcome";
            VisitOutcome.ReadOnly = true;
            VisitOutcome.Width = 75;
            VisitOutcome.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitOutcome);
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MMM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Estimated Visit Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = 100;
            EstimatedVisitDate.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(EstimatedVisitDate);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MMM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Scheduled Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 100;
            StartDateTime.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 75;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var VisitValue = new DataGridLabelColumn();
            VisitValue.Format = "C";
            VisitValue.FormatInfo = null;
            VisitValue.HeaderText = "Visit Value";
            VisitValue.MappingName = "VisitValue";
            VisitValue.ReadOnly = true;
            VisitValue.Width = 75;
            VisitValue.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitValue);
            var VisitCharge = new DataGridLabelColumn();
            VisitCharge.Format = "C";
            VisitCharge.FormatInfo = null;
            VisitCharge.HeaderText = "Visit Charge";
            VisitCharge.MappingName = "VisitCharge";
            VisitCharge.ReadOnly = true;
            VisitCharge.Width = 200;
            VisitCharge.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitCharge);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "C";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "Engineer Cost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 100;
            EngineerCost.NullText = "";
            tbStyle.GridColumnStyles.Add(EngineerCost);
            var PartProductCost = new DataGridLabelColumn();
            PartProductCost.Format = "C";
            PartProductCost.FormatInfo = null;
            PartProductCost.HeaderText = @"Part\Product Cost";
            PartProductCost.MappingName = "PartProductCost";
            PartProductCost.ReadOnly = true;
            PartProductCost.Width = 100;
            PartProductCost.NullText = "";
            tbStyle.GridColumnStyles.Add(PartProductCost);
            var DefectCount = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            DefectCount.FormatInfo = null;
            DefectCount.HeaderText = "DefectCount";
            DefectCount.MappingName = "DefectCount";
            DefectCount.ReadOnly = true;
            DefectCount.Width = 100;
            DefectCount.NullText = "";
            tbStyle.GridColumnStyles.Add(DefectCount);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
            dgVisits.TableStyles.Add(tbStyle);
        }

        private void FRMVisitManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID));
            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void chkVisitDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisitDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today;
                dtpTo.Value = DateAndTime.Today;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void btnShowdata_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void dgVisits_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgVisits.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Entity.Sys.Helper.MakeBooleanValid(SelectedVisitDataRow["tick"]);
                    SelectedVisitDataRow["Tick"] = selected;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (VisitsDataview is object && VisitsDataview.Count > 0)
            {
                foreach (DataRow dr in VisitsDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["EmailSend"], 0, false)))
                    {
                        dr["tick"] = true;
                    }
                }
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            if (VisitsDataview is object && VisitsDataview.Count > 0)
            {
                foreach (DataRow dr in VisitsDataview.Table.Rows)
                    dr["tick"] = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var details = new ArrayList();
            details.Add(VisitsDataview.Table.Select("Tick= true"));
            details.Add(chkPrintHdr.Checked);
            var oPrint = new Entity.Sys.Printing(details, "GSR Batch", Entity.Sys.Enums.SystemDocumentType.GSRBatch, true);
            RunFilter();
            Cursor = Cursors.Default;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dtExport = new DataTable();
            dtExport.Columns.Add("Resident Name");
            dtExport.Columns.Add("Address 1");
            dtExport.Columns.Add("Postcode");
            dtExport.Columns.Add("Sub Area");
            dtExport.Columns.Add("Contact No.");
            dtExport.Columns.Add("PRI Data");
            dtExport.Columns.Add("Works");
            dtExport.Columns.Add("Date Completed");
            dtExport.Columns.Add("Operative");
            DataRow nr;
            foreach (DataRow dr in VisitsDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                {
                    nr = dtExport.NewRow();
                    string name = Entity.Sys.Helper.MakeStringValid(dr["SiteName"]);
                    if (name.Contains("T2"))
                    {
                        name = name.Substring(0, Strings.InStr(name, "T2") - 1);
                    }

                    name = name.Replace("T1 ", "");
                    name = name.Trim();
                    nr["Resident Name"] = name;
                    nr["Address 1"] = Entity.Sys.Helper.MakeStringValid(dr["Address1"]);
                    nr["Postcode"] = Entity.Sys.Helper.MakeStringValid(dr["Postcode"]);
                    nr["Sub Area"] = Entity.Sys.Helper.MakeStringValid(dr["Address2"]);
                    string phoneNum = "";
                    string orginalPhoneNum = Entity.Sys.Helper.MakeStringValid(dr["TelephoneNum"]);
                    for (int i = 0, loopTo = orginalPhoneNum.Length - 1; i <= loopTo; i++)
                    {
                        if (Information.IsNumeric(orginalPhoneNum[i]) | Conversions.ToString(orginalPhoneNum[i]) == " ")
                        {
                            phoneNum += Conversions.ToString(orginalPhoneNum[i]);
                        }
                    }

                    nr["Contact No."] = "'" + phoneNum;
                    nr["PRI Data"] = Entity.Sys.Helper.MakeStringValid(dr["SiteNotes"]);
                    nr["Works"] = dr["Type"];
                    nr["Date Completed"] = Strings.Format(Entity.Sys.Helper.MakeDateTimeValid(dr["StartDateTime"]), "dd/MMM/yyyy");
                    nr["Operative"] = dr["Engineer"];
                    dtExport.Rows.Add(nr);
                }
            }

            ExportHelper.Export(dtExport, "Gas Summary Spec", Enums.ExportType.XLS);
        }

        public void PopulateDatagrid()
        {
            try
            {
                ResetFilters();
                if (get_GetParameter(0) is null)
                {
                }
                else
                {
                    VisitsDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            var argcombo = cboDefinition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 4702.ToString());
            var argcombo2 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argcombo3 = cboOutcome;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 1.ToString());
            txtJobNumber.Text = "";
            txtPostcode.Text = "";
            chkVisitDate.Checked = true;
            if (DateAndTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                dtpFrom.Value = DateAndTime.Today.AddDays(-1);
                dtpTo.Value = DateAndTime.Today.AddDays(-3);
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today.AddDays(-1);
                dtpTo.Value = DateAndTime.Today.AddDays(-1);
            }

            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            grpFilter.Enabled = true;
        }

        private void RunFilter()
        {
            string whereClause = "AND tblEngineerVisit.Deleted = 0 ";
            if (theCustomer is object)
            {
                whereClause += " AND tblCustomer.CustomerID = " + theCustomer.CustomerID + "";
            }

            if (theSite is object)
            {
                whereClause += " AND tblSite.SiteID = " + theSite.SiteID + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDefinition)) == 0))
            {
                whereClause += " AND JobDefinitionEnumID = " + Combo.get_GetSelectedItemValue(cboDefinition) + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
            {
                whereClause += " AND JobTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
            {
                whereClause += " AND (CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0) " + "  WHEN 0 THEN tblEngineerVisit.StatusEnumID " + "  WHEN 1 THEN tblEngineerVisit.StatusEnumID " + "  WHEN 2 THEN  " + " CASE  " + " WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 8 " + " ELSE 7 " + "   End " + " WHEN 3 THEN 6 " + "  End) = " + Combo.get_GetSelectedItemValue(cboStatus);
            }

            if (!(txtJobNumber.Text.Trim().Length == 0))
            {
                whereClause += " AND JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
            }

            if (chkVisitDate.Checked)
            {
                whereClause += " AND StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND StartDateTime <= '" + Strings.Format(dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
            }

            if (!(txtPostcode.Text.Trim().Length == 0))
            {
                whereClause += " AND tblSite.Postcode LIKE '" + txtPostcode.Text.Trim() + "%'";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == 0))
            {
                whereClause += " AND OutcomeEnumID = " + Combo.get_GetSelectedItemValue(cboOutcome) + "";
            }

            if (chkExceptionsOnly.Checked)
            {
                whereClause += " AND DefectCount > 0";
            }

            VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Get_All(whereClause);
            grpEngineerVisits.Text = "Double Click To View / Edit - Visits: " + VisitsDataview.Table.Rows.Count;
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("SitePostcode");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("PONumber");
            exportData.Columns.Add("JobDefinition");
            exportData.Columns.Add("Type");
            exportData.Columns.Add("VisitStatus");
            exportData.Columns.Add("StartDateTime");
            exportData.Columns.Add("Engineer");
            exportData.Columns.Add("VisitValue", typeof(decimal));
            exportData.Columns.Add("VisitCharge");
            exportData.Columns.Add("EngineerCost", typeof(decimal));
            exportData.Columns.Add("PartProductCost", typeof(decimal));
            for (int itm = 0, loopTo = ((DataView)dgVisits.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgVisits.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Customer"] = SelectedVisitDataRow["Customer"];
                newRw["Site"] = SelectedVisitDataRow["Site"];
                newRw["SitePostcode"] = SelectedVisitDataRow["SitePostcode"];
                newRw["JobNumber"] = SelectedVisitDataRow["JobNumber"];
                newRw["PONumber"] = SelectedVisitDataRow["PONumber"];
                newRw["JobDefinition"] = SelectedVisitDataRow["JobDefinition"];
                newRw["Type"] = SelectedVisitDataRow["Type"];
                newRw["VisitStatus"] = SelectedVisitDataRow["VisitStatus"];
                newRw["StartDateTime"] = SelectedVisitDataRow["StartDateTime"];
                newRw["Engineer"] = SelectedVisitDataRow["Engineer"];
                newRw["VisitValue"] = SelectedVisitDataRow["VisitValue"];
                newRw["VisitCharge"] = SelectedVisitDataRow["VisitCharge"];
                newRw["EngineerCost"] = SelectedVisitDataRow["EngineerCost"];
                newRw["PartProductCost"] = SelectedVisitDataRow["PartProductCost"];
                exportData.Rows.Add(newRw);
                dgVisits.UnSelect(itm);
            }
        }

        private void dgVisits_DoubleClick(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { SelectedVisitDataRow["EngineerVisitID"] });
        }
    }
}