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
    public class UCQuoteContractAlternativeConvert : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCQuoteContractAlternativeConvert() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboInvoiceFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboContractStatusID;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpContract;

        internal GroupBox grpContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContract != null)
                {
                }

                _grpContract = value;
                if (_grpContract != null)
                {
                }
            }
        }

        private TextBox _txtContractReference;

        internal TextBox txtContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractReference != null)
                {
                }

                _txtContractReference = value;
                if (_txtContractReference != null)
                {
                }
            }
        }

        private Label _lblContractReference;

        internal Label lblContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractReference != null)
                {
                }

                _lblContractReference = value;
                if (_lblContractReference != null)
                {
                }
            }
        }

        private ComboBox _cboContractStatusID;

        internal ComboBox cboContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractStatusID != null)
                {
                }

                _cboContractStatusID = value;
                if (_cboContractStatusID != null)
                {
                }
            }
        }

        private Label _lblContractStatusID;

        internal Label lblContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStatusID != null)
                {
                }

                _lblContractStatusID = value;
                if (_lblContractStatusID != null)
                {
                }
            }
        }

        private ComboBox _cboInvoiceFrequencyID;

        internal ComboBox cboInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceFrequencyID != null)
                {
                }

                _cboInvoiceFrequencyID = value;
                if (_cboInvoiceFrequencyID != null)
                {
                }
            }
        }

        private Label _lblInvoiceFrequencyID;

        internal Label lblInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceFrequencyID != null)
                {
                }

                _lblInvoiceFrequencyID = value;
                if (_lblInvoiceFrequencyID != null)
                {
                }
            }
        }

        private GroupBox _grpSites;

        internal GroupBox grpSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSites != null)
                {
                }

                _grpSites = value;
                if (_grpSites != null)
                {
                }
            }
        }

        private DataGrid _dgSites;

        internal DataGrid dgSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSites != null)
                {
                    _dgSites.Click -= dgSites_Click;
                    _dgSites.CurrentCellChanged -= dgSites_Click;
                    _dgSites.MouseUp -= dgSites_MouseUp;
                }

                _dgSites = value;
                if (_dgSites != null)
                {
                    _dgSites.Click += dgSites_Click;
                    _dgSites.CurrentCellChanged += dgSites_Click;
                    _dgSites.MouseUp += dgSites_MouseUp;
                }
            }
        }

        private TextBox _txtQuoteContractPrice;

        internal TextBox txtQuoteContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuoteContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuoteContractPrice != null)
                {
                    _txtQuoteContractPrice.LostFocus -= txtContractPrice_LostFocus;
                }

                _txtQuoteContractPrice = value;
                if (_txtQuoteContractPrice != null)
                {
                    _txtQuoteContractPrice.LostFocus += txtContractPrice_LostFocus;
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

        private GroupBox _grpVisits;

        internal GroupBox grpVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisits != null)
                {
                }

                _grpVisits = value;
                if (_grpVisits != null)
                {
                }
            }
        }

        private TabControl _TCJobsOfWork;

        internal TabControl TCJobsOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TCJobsOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TCJobsOfWork != null)
                {
                }

                _TCJobsOfWork = value;
                if (_TCJobsOfWork != null)
                {
                }
            }
        }

        private Button _btnContractNumber;

        internal Button btnContractNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnContractNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnContractNumber != null)
                {
                    _btnContractNumber.Click -= btnContractNumber_Click;
                }

                _btnContractNumber = value;
                if (_btnContractNumber != null)
                {
                    _btnContractNumber.Click += btnContractNumber_Click;
                }
            }
        }

        private DateTimePicker _dtpContractStartDate;

        internal DateTimePicker dtpContractStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractStartDate != null)
                {
                }

                _dtpContractStartDate = value;
                if (_dtpContractStartDate != null)
                {
                }
            }
        }

        private Label _lblContractStartDate;

        internal Label lblContractStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStartDate != null)
                {
                }

                _lblContractStartDate = value;
                if (_lblContractStartDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractEndDate;

        internal DateTimePicker dtpContractEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractEndDate != null)
                {
                }

                _dtpContractEndDate = value;
                if (_dtpContractEndDate != null)
                {
                }
            }
        }

        private Label _lblContractEndDate;

        internal Label lblContractEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractEndDate != null)
                {
                }

                _lblContractEndDate = value;
                if (_lblContractEndDate != null)
                {
                }
            }
        }

        private GroupBox _gpbInvoiceAddress;

        internal GroupBox gpbInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoiceAddress != null)
                {
                }

                _gpbInvoiceAddress = value;
                if (_gpbInvoiceAddress != null)
                {
                }
            }
        }

        private DataGrid _dgInvoiceAddress;

        internal DataGrid dgInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click -= dgInvoiceAddress_Click;
                }

                _dgInvoiceAddress = value;
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click += dgInvoiceAddress_Click;
                }
            }
        }

        private DateTimePicker _dtpFirstInvoiceDate;

        internal DateTimePicker dtpFirstInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFirstInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFirstInvoiceDate != null)
                {
                }

                _dtpFirstInvoiceDate = value;
                if (_dtpFirstInvoiceDate != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContract = new GroupBox();
            _grpVisits = new GroupBox();
            _TCJobsOfWork = new TabControl();
            _txtQuoteContractPrice = new TextBox();
            _txtQuoteContractPrice.LostFocus += new EventHandler(txtContractPrice_LostFocus);
            _Label6 = new Label();
            _grpSites = new GroupBox();
            _dgSites = new DataGrid();
            _dgSites.Click += new EventHandler(dgSites_Click);
            _dgSites.CurrentCellChanged += new EventHandler(dgSites_Click);
            _dgSites.Click += new EventHandler(dgSites_Click);
            _dgSites.CurrentCellChanged += new EventHandler(dgSites_Click);
            _dgSites.MouseUp += new MouseEventHandler(dgSites_MouseUp);
            _txtContractReference = new TextBox();
            _lblContractReference = new Label();
            _cboContractStatusID = new ComboBox();
            _lblContractStatusID = new Label();
            _cboInvoiceFrequencyID = new ComboBox();
            _lblInvoiceFrequencyID = new Label();
            _lblContractEndDate = new Label();
            _btnContractNumber = new Button();
            _btnContractNumber.Click += new EventHandler(btnContractNumber_Click);
            _dtpContractStartDate = new DateTimePicker();
            _lblContractStartDate = new Label();
            _dtpContractEndDate = new DateTimePicker();
            _gpbInvoiceAddress = new GroupBox();
            _dgInvoiceAddress = new DataGrid();
            _dgInvoiceAddress.Click += new EventHandler(dgInvoiceAddress_Click);
            _dtpFirstInvoiceDate = new DateTimePicker();
            _Label1 = new Label();
            _grpContract.SuspendLayout();
            _grpVisits.SuspendLayout();
            _grpSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            _gpbInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).BeginInit();
            SuspendLayout();
            //
            // grpContract
            //
            _grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContract.Controls.Add(_gpbInvoiceAddress);
            _grpContract.Controls.Add(_dtpFirstInvoiceDate);
            _grpContract.Controls.Add(_Label1);
            _grpContract.Controls.Add(_grpVisits);
            _grpContract.Controls.Add(_txtQuoteContractPrice);
            _grpContract.Controls.Add(_grpSites);
            _grpContract.Controls.Add(_txtContractReference);
            _grpContract.Controls.Add(_lblContractReference);
            _grpContract.Controls.Add(_cboContractStatusID);
            _grpContract.Controls.Add(_lblContractStatusID);
            _grpContract.Controls.Add(_cboInvoiceFrequencyID);
            _grpContract.Controls.Add(_lblInvoiceFrequencyID);
            _grpContract.Controls.Add(_lblContractEndDate);
            _grpContract.Controls.Add(_btnContractNumber);
            _grpContract.Controls.Add(_dtpContractStartDate);
            _grpContract.Controls.Add(_lblContractStartDate);
            _grpContract.Controls.Add(_dtpContractEndDate);
            _grpContract.Controls.Add(_Label6);
            _grpContract.Location = new Point(8, 0);
            _grpContract.Name = "grpContract";
            _grpContract.Size = new Size(968, 664);
            _grpContract.TabIndex = 0;
            _grpContract.TabStop = false;
            _grpContract.Text = "Main Details";
            //
            // grpVisits
            //
            _grpVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVisits.Controls.Add(_TCJobsOfWork);
            _grpVisits.Location = new Point(11, 216);
            _grpVisits.Name = "grpVisits";
            _grpVisits.Size = new Size(949, 432);
            _grpVisits.TabIndex = 8;
            _grpVisits.TabStop = false;
            _grpVisits.Text = "Jobs Of Work";
            //
            // TCJobsOfWork
            //
            _TCJobsOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TCJobsOfWork.Location = new Point(8, 24);
            _TCJobsOfWork.Name = "TCJobsOfWork";
            _TCJobsOfWork.SelectedIndex = 0;
            _TCJobsOfWork.Size = new Size(933, 400);
            _TCJobsOfWork.TabIndex = 44;
            //
            // txtQuoteContractPrice
            //
            _txtQuoteContractPrice.Location = new Point(136, 64);
            _txtQuoteContractPrice.MaxLength = 9;
            _txtQuoteContractPrice.Name = "txtQuoteContractPrice";
            _txtQuoteContractPrice.Size = new Size(170, 21);
            _txtQuoteContractPrice.TabIndex = 7;
            _txtQuoteContractPrice.Tag = "Contract.ContractPrice";
            _txtQuoteContractPrice.Text = "";
            //
            // Label6
            //
            _Label6.Location = new Point(16, 64);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(132, 20);
            _Label6.TabIndex = 62;
            _Label6.Text = "Total Contract Price";
            //
            // grpSites
            //
            _grpSites.Controls.Add(_dgSites);
            _grpSites.Location = new Point(11, 112);
            _grpSites.Name = "grpSites";
            _grpSites.Size = new Size(949, 104);
            _grpSites.TabIndex = 7;
            _grpSites.TabStop = false;
            _grpSites.Text = "Properties";
            //
            // dgSites
            //
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(11, 16);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(929, 80);
            _dgSites.TabIndex = 0;
            //
            // txtContractReference
            //
            _txtContractReference.Location = new Point(136, 16);
            _txtContractReference.MaxLength = 100;
            _txtContractReference.Name = "txtContractReference";
            _txtContractReference.Size = new Size(170, 21);
            _txtContractReference.TabIndex = 1;
            _txtContractReference.Tag = "Contract.ContractReference";
            _txtContractReference.Text = "";
            //
            // lblContractReference
            //
            _lblContractReference.Location = new Point(17, 16);
            _lblContractReference.Name = "lblContractReference";
            _lblContractReference.Size = new Size(139, 20);
            _lblContractReference.TabIndex = 31;
            _lblContractReference.Text = "Contract Reference";
            //
            // cboContractStatusID
            //
            _cboContractStatusID.Cursor = Cursors.Hand;
            _cboContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractStatusID.Location = new Point(136, 40);
            _cboContractStatusID.Name = "cboContractStatusID";
            _cboContractStatusID.Size = new Size(170, 21);
            _cboContractStatusID.TabIndex = 3;
            _cboContractStatusID.Tag = "Contract.ContractStatusID";
            //
            // lblContractStatusID
            //
            _lblContractStatusID.Location = new Point(16, 40);
            _lblContractStatusID.Name = "lblContractStatusID";
            _lblContractStatusID.Size = new Size(139, 20);
            _lblContractStatusID.TabIndex = 31;
            _lblContractStatusID.Text = "Contract Status";
            //
            // cboInvoiceFrequencyID
            //
            _cboInvoiceFrequencyID.Cursor = Cursors.Hand;
            _cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceFrequencyID.Location = new Point(136, 88);
            _cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
            _cboInvoiceFrequencyID.Size = new Size(170, 21);
            _cboInvoiceFrequencyID.TabIndex = 6;
            _cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID";
            //
            // lblInvoiceFrequencyID
            //
            _lblInvoiceFrequencyID.Location = new Point(16, 88);
            _lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
            _lblInvoiceFrequencyID.Size = new Size(139, 20);
            _lblInvoiceFrequencyID.TabIndex = 4;
            _lblInvoiceFrequencyID.Text = "Invoice Frequency";
            //
            // lblContractEndDate
            //
            _lblContractEndDate.Location = new Point(312, 64);
            _lblContractEndDate.Name = "lblContractEndDate";
            _lblContractEndDate.Size = new Size(56, 20);
            _lblContractEndDate.TabIndex = 49;
            _lblContractEndDate.Text = "End Date";
            //
            // btnContractNumber
            //
            _btnContractNumber.UseVisualStyleBackColor = true;
            _btnContractNumber.Location = new Point(312, 15);
            _btnContractNumber.Name = "btnContractNumber";
            _btnContractNumber.Size = new Size(208, 23);
            _btnContractNumber.TabIndex = 2;
            _btnContractNumber.Text = "Next Suggested Contract Number";
            //
            // dtpContractStartDate
            //
            _dtpContractStartDate.Format = DateTimePickerFormat.Short;
            _dtpContractStartDate.Location = new Point(400, 40);
            _dtpContractStartDate.Name = "dtpContractStartDate";
            _dtpContractStartDate.Size = new Size(120, 21);
            _dtpContractStartDate.TabIndex = 4;
            _dtpContractStartDate.Tag = "Contract.ContractStartDate";
            //
            // lblContractStartDate
            //
            _lblContractStartDate.Location = new Point(312, 40);
            _lblContractStartDate.Name = "lblContractStartDate";
            _lblContractStartDate.Size = new Size(64, 20);
            _lblContractStartDate.TabIndex = 46;
            _lblContractStartDate.Text = "Start Date";
            //
            // dtpContractEndDate
            //
            _dtpContractEndDate.Format = DateTimePickerFormat.Short;
            _dtpContractEndDate.Location = new Point(400, 64);
            _dtpContractEndDate.Name = "dtpContractEndDate";
            _dtpContractEndDate.Size = new Size(120, 21);
            _dtpContractEndDate.TabIndex = 5;
            _dtpContractEndDate.Tag = "Contract.ContractEndDate";
            //
            // gpbInvoiceAddress
            //
            _gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbInvoiceAddress.Controls.Add(_dgInvoiceAddress);
            _gpbInvoiceAddress.Location = new Point(528, 8);
            _gpbInvoiceAddress.Name = "gpbInvoiceAddress";
            _gpbInvoiceAddress.Size = new Size(432, 104);
            _gpbInvoiceAddress.TabIndex = 64;
            _gpbInvoiceAddress.TabStop = false;
            _gpbInvoiceAddress.Text = "Invoice Address";
            //
            // dgInvoiceAddress
            //
            _dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoiceAddress.DataMember = "";
            _dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddress.Location = new Point(8, 20);
            _dgInvoiceAddress.Name = "dgInvoiceAddress";
            _dgInvoiceAddress.Size = new Size(416, 76);
            _dgInvoiceAddress.TabIndex = 0;
            //
            // dtpFirstInvoiceDate
            //
            _dtpFirstInvoiceDate.Format = DateTimePickerFormat.Short;
            _dtpFirstInvoiceDate.Location = new Point(400, 88);
            _dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
            _dtpFirstInvoiceDate.Size = new Size(120, 21);
            _dtpFirstInvoiceDate.TabIndex = 63;
            _dtpFirstInvoiceDate.Tag = "";
            //
            // Label1
            //
            _Label1.Location = new Point(312, 88);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(107, 20);
            _Label1.TabIndex = 65;
            _Label1.Text = "First Inv. Date";
            //
            // UCQuoteContractAlternativeConvert
            //
            Controls.Add(_grpContract);
            Name = "UCQuoteContractAlternativeConvert";
            Size = new Size(983, 675);
            _grpContract.ResumeLayout(false);
            _grpVisits.ResumeLayout(false);
            _grpSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSites).EndInit();
            _gpbInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).EndInit();
            ResumeLayout(false);
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
                return CurrentQuoteContract;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.QuoteContractAlternatives.QuoteContractAlternative _currentQuoteContract;

        public Entity.QuoteContractAlternatives.QuoteContractAlternative CurrentQuoteContract
        {
            get
            {
                return _currentQuoteContract;
            }

            set
            {
                _currentQuoteContract = value;
                if (_currentQuoteContract is null)
                {
                    _currentQuoteContract = new Entity.QuoteContractAlternatives.QuoteContractAlternative();
                    _currentQuoteContract.Exists = false;
                }

                Populate();
                Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(_currentQuoteContract.QuoteContractID, _currentQuoteContract.CustomerID);
                // Load Invoice Addresses
                InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(_currentQuoteContract.CustomerID);
                foreach (DataRow site in Sites.Table.Rows)
                    SiteArray.Add(App.DB.QuoteContractAlternativeSite.Get(Conversions.ToInteger(site["QuoteContractSiteID"])));
            }
        }

        private DataView _Sites;

        private DataView Sites
        {
            get
            {
                return _Sites;
            }

            set
            {
                _Sites = value;
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString();
                _Sites.AllowNew = false;
                _Sites.AllowEdit = true;
                _Sites.AllowDelete = false;
                dgSites.DataSource = Sites;
            }
        }

        private DataRow SelectedSiteDataRow
        {
            get
            {
                if (!(dgSites.CurrentRowIndex == -1))
                {
                    return Sites[dgSites.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private ArrayList _SiteArray = new ArrayList();

        public ArrayList SiteArray
        {
            get
            {
                return _SiteArray;
            }

            set
            {
                _SiteArray = value;
            }
        }

        public bool IsLoading = false;
        private DataView _InvoiceAddresses;

        private DataView InvoiceAddresses
        {
            get
            {
                return _InvoiceAddresses;
            }

            set
            {
                _InvoiceAddresses = value;
                _InvoiceAddresses.AllowDelete = false;
                _InvoiceAddresses.AllowEdit = false;
                _InvoiceAddresses.AllowNew = false;
                _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                dgInvoiceAddress.DataSource = InvoiceAddresses;
            }
        }

        private DataRow SelectedInvoiceAddressesDataRow
        {
            get
            {
                if (!(dgInvoiceAddress.CurrentRowIndex == -1))
                {
                    return InvoiceAddresses[dgInvoiceAddress.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupSitesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSites);
            var tStyle = dgSites.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSites.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 40;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 400;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString();
            dgSites.TableStyles.Add(tStyle);
        }

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddress);
            var tStyle = dgInvoiceAddress.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgInvoiceAddress.ReadOnly = false;
            var AddressType = new DataGridLabelColumn();
            AddressType.Format = "";
            AddressType.FormatInfo = null;
            AddressType.HeaderText = "Address Type";
            AddressType.MappingName = "AddressType";
            AddressType.ReadOnly = true;
            AddressType.Width = 95;
            AddressType.NullText = "";
            tStyle.GridColumnStyles.Add(AddressType);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 75;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 75;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 75;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 75;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address 5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 75;
            Address5.NullText = "";
            tStyle.GridColumnStyles.Add(Address5);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddress.TableStyles.Add(tStyle);
        }

        private void UCContract_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void txtContractPrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtQuoteContractPrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtQuoteContractPrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtQuoteContractPrice.Text.Replace("£", "")), "C");
            }

            txtQuoteContractPrice.Text = price;
        }

        private void dgSites_Click(object sender, EventArgs e)
        {
            if (SelectedSiteDataRow is object)
            {
                grpVisits.Text = Conversions.ToString("Jobs Of Work for " + SelectedSiteDataRow["Site"]);
                var CurrentQuoteContractSite = new Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite();
                // CurrentQuoteContractSite = DB.QuoteContractAlternativeSite.Get(SelectedSiteDataRow("QuoteContractSiteID"))
                CurrentQuoteContractSite = (Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite)SiteArray[dgSites.CurrentRowIndex];
                IsLoading = true;
                if (CurrentQuoteContractSite is object)
                {
                    if (CurrentQuoteContractSite.JobOfWorks.Count > 0)
                    {
                        TCJobsOfWork.TabPages.Clear();
                        foreach (Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork jobOfWork in CurrentQuoteContractSite.JobOfWorks)
                        {
                            if (App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(jobOfWork.QuoteContractSiteJobOfWorkID).Table.Rows.Count > 0)
                            {
                                var tp = AddJobOfWork(jobOfWork, CurrentQuoteContractSite);
                            }
                        }

                        TCJobsOfWork.SelectedTab = TCJobsOfWork.TabPages[0];
                    }
                    else
                    {
                        TCJobsOfWork.TabPages.Clear();
                    }
                }
                else
                {
                    TCJobsOfWork.TabPages.Clear();
                }

                IsLoading = false;
            }
        }

        private void dgSites_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgSites.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                dgSites.CurrentRowIndex = HitTestInfo.Row;
            }

            if (HitTestInfo.Column == 0)
            {
                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgSites[dgSites.CurrentRowIndex, 0]);
                Sites.Table.Rows[dgSites.CurrentRowIndex]["Tick"] = selected;
                TCJobsOfWork.Enabled = selected;
            }
        }

        private void btnContractNumber_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMAvailableContractNos), true, new object[] { txtContractReference, this });
        }

        private void dgInvoiceAddress_Click(object sender, EventArgs e)
        {
            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private DataView BuildUpScheduleOfRatesDataview()
        {
            var newTable = new DataTable();
            newTable.Columns.Add("ScheduleOfRatesCategoryID");
            newTable.Columns.Add("Category");
            newTable.Columns.Add("Code");
            newTable.Columns.Add("Description");
            newTable.Columns.Add("Price");
            newTable.Columns.Add("QtyPerVisit");
            newTable.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return new DataView(newTable);
        }

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteContract = App.DB.QuoteContractAlternative.Get(ID);
            }

            txtContractReference.Text = CurrentQuoteContract.QuoteContractReference;
            dtpContractStartDate.Value = CurrentQuoteContract.ContractStart;
            dtpContractEndDate.Value = CurrentQuoteContract.ContractEnd;
            var argcombo = cboContractStatusID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Entity.Sys.Enums.ContractStatus.Active));
            txtQuoteContractPrice.Text = Strings.Format(CurrentQuoteContract.QuoteContractPrice, "C");
            dtpFirstInvoiceDate.Value = CurrentQuoteContract.ContractStart;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var NewContract = new Entity.ContractsAlternative.ContractAlternative();
                NewContract.IgnoreExceptionsOnSetMethods = true;
                NewContract.SetContractReference = txtContractReference.Text.Trim();
                NewContract.ContractStartDate = dtpContractStartDate.Value;
                NewContract.ContractEndDate = dtpContractEndDate.Value;
                NewContract.SetContractStatusID = Combo.get_GetSelectedItemValue(cboContractStatusID);
                NewContract.SetContractPrice = txtQuoteContractPrice.Text.Trim().Replace("£", "");
                NewContract.SetInvoiceFrequencyID = Combo.get_GetSelectedItemValue(cboInvoiceFrequencyID);
                NewContract.SetQuoteContractID = CurrentQuoteContract.QuoteContractID;
                NewContract.SetCustomerID = CurrentQuoteContract.CustomerID;
                NewContract.FirstInvoiceDate = dtpFirstInvoiceDate.Value;
                if (SelectedInvoiceAddressesDataRow is object)
                {
                    NewContract.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow["AddressID"];
                    NewContract.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                }

                var cV = new Entity.ContractsAlternative.ContractAlternativeValidator();
                cV.Validate(NewContract);

                // VALIDATE SITES BEFORE WE CONTINUE
                foreach (DataRow site in Sites.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(site["Tick"], true, false)))
                    {
                        var sV = new Entity.ContractAlternativeSites.ContractAlternativeSiteValidator();
                        var validateSite = new Entity.ContractAlternativeSites.ContractAlternativeSite();
                        validateSite.SetContractID = NewContract.ContractID;
                        validateSite.SetPropertyID = site["SiteID"];
                        sV.Validate(validateSite, NewContract);
                    }
                }

                // INSERT NEW CONTRACT
                NewContract = App.DB.ContractAlternative.Insert(NewContract);
                InsertInvoiceToBeRaiseLines(NewContract);

                // INSERT CONTRACT SITES
                int siteCount = 0;
                foreach (DataRow site in Sites.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(site["Tick"], true, false)))
                    {
                        var newSite = new Entity.ContractAlternativeSites.ContractAlternativeSite();
                        newSite.SetContractID = NewContract.ContractID;
                        newSite.SetPropertyID = site["SiteID"];
                        newSite = App.DB.ContractAlternativeSite.Insert(newSite);
                        int JobOfWorkCount = 0;

                        // INSERT CONTRACT JOBOFWORK
                        foreach (Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork JOW in ((Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite)SiteArray[siteCount]).JobOfWorks)
                        {
                            if (App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(JOW.QuoteContractSiteJobOfWorkID).Table.Rows.Count > 0)
                            {
                                var newConJobOfWork = new Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork();
                                newConJobOfWork.FirstVisitDate = JOW.FirstVisitDate;
                                newConJobOfWork.SetAverageMileage = JOW.AverageMileage;
                                newConJobOfWork.SetIncludeMileagePrice = JOW.IncludeMileagePrice;
                                newConJobOfWork.SetIncludeRates = JOW.IncludeRates;
                                newConJobOfWork.SetPricePerMile = JOW.PricePerMile;
                                newConJobOfWork.SetPricePerVisit = JOW.PricePerVisit;
                                newConJobOfWork.SetTotalSitePrice = JOW.TotalSitePrice;
                                newConJobOfWork.SetContractSiteID = newSite.ContractSiteID;
                                newConJobOfWork = App.DB.ContractAlternativeSiteJobOfWork.Insert(newConJobOfWork);
                                App.DB.ContractAlternativeSiteJobOfWork.SaveRates(JOW.ScheduledOfRates_UsedForConvertOnly, newConJobOfWork.ContractSiteJobOfWorkID);
                                DataView dvJobItems;
                                dvJobItems = App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(((Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork)((Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite)SiteArray[siteCount]).JobOfWorks[JobOfWorkCount]).QuoteContractSiteJobOfWorkID);

                                // INSERT CONTRACT JOB ITEMS
                                foreach (DataRow jobI in dvJobItems.Table.Rows)
                                {
                                    var newConJobI = new Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems();
                                    newConJobI.SetContractSiteID = ((Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite)SiteArray[siteCount]).QuoteContractSiteID;
                                    newConJobI.SetDescription = jobI["Description"];
                                    newConJobI.SetJobOfWorkID = newConJobOfWork.ContractSiteJobOfWorkID;
                                    newConJobI.SetItemPricePerVisit = jobI["itemPricePerVisit"];
                                    newConJobI.SetVisitDuration = jobI["VisitDuration"];
                                    newConJobI.SetVisitFrequencyID = jobI["VisitFrequencyID"];
                                    newConJobI = App.DB.ContractAlternativeSiteJobItems.Insert(newConJobI);

                                    // INSERT CONTRACT ASSETS
                                    var dvAssets = App.DB.QuoteContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(jobI["QuoteContractSiteJobItemID"]));
                                    foreach (DataRow drAsset in dvAssets.Table.Rows)
                                    {
                                        var newConAsset = new Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAsset();
                                        newConAsset.SetAssetID = drAsset["AssetID"];
                                        newConAsset.SetContractSiteJobItemID = newConJobI.ContractSiteJobItemID;
                                        App.DB.ContractAlternativeSiteAsset.Insert(newConAsset);
                                    }
                                }

                                // Plan jobs
                                // START SCHEDULING JOBS************************
                                ScheduleJob(NewContract, newSite, newConJobOfWork, App.DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(newConJobOfWork.ContractSiteJobOfWorkID));
                                // *********************************************
                                JobOfWorkCount = +1;
                            }
                        }
                    }

                    siteCount += 1;
                }

                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ScheduleJob(Entity.ContractsAlternative.ContractAlternative newContract, Entity.ContractAlternativeSites.ContractAlternativeSite newSite, Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork newJobOfWork, DataView newJobItems)
        {
            try
            {
                // Duration OF Contract In Days
                int ContractDuration;
                ContractDuration = newContract.ContractEndDate.Subtract(newContract.ContractStartDate).Days;

                // How Visit Should happen in days
                int NumOfVisits = 0;
                int VisitFreqInDays = 0;
                var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(newJobItems.Table.Rows[0]["VisitFrequencyID"]);
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.VisitFrequency.Annually:
                        {
                            VisitFreqInDays = 365;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                        {
                            VisitFreqInDays = 182;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Monthly:
                        {
                            VisitFreqInDays = 30;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Quarterly:
                        {
                            VisitFreqInDays = 91;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Weekly:
                        {
                            VisitFreqInDays = 7;
                            break;
                        }
                }

                NumOfVisits = Conversions.ToInteger(Math.Floor(ContractDuration / (decimal)VisitFreqInDays));
                if (NumOfVisits == 0)
                {
                    NumOfVisits = 1;
                }

                DateTime EstVisitDate = Conversions.ToDate(newJobOfWork.FirstVisitDate.Date + " 09:00:00");
                for (int i = 1, loopTo = NumOfVisits; i <= loopTo; i++)
                {
                    if (EstVisitDate >= newContract.ContractStartDate & EstVisitDate <= newContract.ContractEndDate)
                    {
                        // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                        if (EstVisitDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            EstVisitDate = EstVisitDate.AddDays(2);
                        }
                        else if (EstVisitDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            EstVisitDate = EstVisitDate.AddDays(1);
                        }

                        // CREATE JOB
                        var job = new Entity.Jobs.Job();
                        job.SetPropertyID = newSite.PropertyID;
                        job.SetJobDefinitionEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobTypeID = 0;
                        job.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Open);
                        job.SetCreatedByUserID = App.loggedInUser.UserID;
                        var JobNumber = new JobNumber();
                        JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                        job.SetPONumber = "";
                        job.SetQuoteID = 0;
                        job.SetContractID = newContract.ContractID;
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(newContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            job.SetDeleted = true;
                        }

                        // INSERT JOB ITEM
                        var JobOfWork = new Entity.JobOfWorks.JobOfWork();
                        JobOfWork.IgnoreExceptionsOnSetMethods = true;
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(newContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            JobOfWork.SetDeleted = true;
                        }

                        // Work out how long all the jobitems will take - running tally
                        int JobDuration = 0;
                        foreach (DataRow rw in newJobItems.Table.Rows)
                        {
                            var JobItem = new Entity.JobItems.JobItem();
                            JobItem.IgnoreExceptionsOnSetMethods = true;
                            JobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit: ") + rw["Description"];
                            JobDuration += (int)rw["VisitDuration"];

                            // INSERT ANY ASSETS
                            var AssetsDV = App.DB.ContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(rw["ContractSiteJobItemID"]));
                            foreach (DataRow dr in AssetsDV.Table.Rows)
                            {
                                var JobAsset = new Entity.JobAssets.JobAsset();
                                JobAsset.SetAssetID = dr["AssetID"];
                                job.Assets.Add(JobAsset);
                            }

                            JobOfWork.JobItems.Add(JobItem);
                        }

                        // NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                        var match = new ArrayList();
                        int engineerID = 0;
                        DateTime actualVisitDate = default;
                        match = MatchingEngineer(job, EstVisitDate, JobDuration);
                        if (match is object)
                        {
                            if (match.Count > 0)
                            {
                                actualVisitDate = Conversions.ToDate(match[0]);
                                engineerID = Conversions.ToInteger(match[1]);
                            }
                        }
                        // 'NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                        // Dim EngineerID As Integer = 0
                        // Dim site As New Entity.Sites.Site
                        // site = DB.Site.Site_Get(job.SiteID)
                        // If site.EngineerID > 0 Then
                        // EngineerID = site.EngineerID
                        // Else
                        // Dim Postcode As String
                        // Postcode = site.Postcode.Replace("-", "")
                        // Postcode = Postcode.Replace(" ", "")
                        // Postcode = Postcode.Substring(0, Postcode.Length - 3)

                        // Dim MatchingEngineers As DataView
                        // MatchingEngineers = DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(Postcode)
                        // If MatchingEngineers.Table.Rows.Count > 0 Then
                        // Dim randomNum As Integer = 0
                        // Randomize()
                        // randomNum = CInt(Int((MatchingEngineers.Table.Rows.Count * Rnd()) + 1)) - 1

                        // EngineerID = MatchingEngineers.Table.Rows(randomNum).Item("EngineerID")
                        // End If
                        // End If

                        // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                        var EngineerVisit = new Entity.EngineerVisits.EngineerVisit();
                        EngineerVisit.IgnoreExceptionsOnSetMethods = true;
                        EngineerVisit.SetEngineerID = engineerID;
                        EngineerVisit.SetNotesToEngineer = "PPM Contract Visit";
                        if (engineerID > 0)
                        {
                            EngineerVisit.StartDateTime = actualVisitDate;
                            EngineerVisit.EndDateTime = actualVisitDate.AddMinutes(JobDuration);
                            EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled);
                        }
                        else
                        {
                            EngineerVisit.StartDateTime = DateTime.MinValue;
                            EngineerVisit.EndDateTime = DateTime.MinValue;
                            EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                        }

                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(newContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            EngineerVisit.SetDeleted = true;
                        }

                        JobOfWork.EngineerVisits.Add(EngineerVisit);
                        job.JobOfWorks.Add(JobOfWork);
                        job = App.DB.Job.Insert(job);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit();
                        PPM.SetContractSiteJobOfWorkID = newJobOfWork.ContractSiteJobOfWorkID;
                        PPM.EstimatedVisitDate = EstVisitDate;
                        PPM.SetJobID = job.JobID;
                        App.DB.ContractAlternativePPMVisit.Insert(PPM);
                        EstVisitDate = EstVisitDate.AddDays(VisitFreqInDays);
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ArrayList MatchingEngineer(Entity.Jobs.Job job, DateTime estVisitDate, int visitDuration)
        {
            var site = new Entity.Sites.Site();
            int engineerID = 0;
            int slotDuration = 0; // MINTUES
                                  // Dim visitDuration As Integer = 0
            int numOfSlotsNeeded = 0;
            var match = new ArrayList();
            string postcode = "";
            DataView postcodeEngineers = null;
            int cntPostcodeEng = 0;
            int randomNum = 0;

            // SYSTEM NUMBER OF MINUTES IN A SLOTS
            slotDuration = App.DB.Manager.Get().TimeSlot;

            // VISIT DURATION FOR THIS SITE IN HOURS - its passed!
            // visitDuration = Combo.GetSelectedItemValue(cboVisitDuration)

            // NUM OF SLOTS NEEDED FOR VISIT
            if (visitDuration > 0)
            {
                numOfSlotsNeeded = (int)(visitDuration / (decimal)slotDuration);
            }
            // ***************************************************************

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(job.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                match = CheckAvailability(estVisitDate, site.EngineerID, numOfSlotsNeeded);
            }
            // IF A ENG & SLOT IS FOUND, RETURN
            if (match.Count > 0)
            {
                return match;
            }

            // NO MATCH FOUND FOR SITE ENGINEER
            // IS THERE A MATCH FOR POSTCODE ENGINEERS
            postcode = site.Postcode.Replace("-", "");
            postcode = postcode.Replace(" ", "");
            postcode = postcode.Substring(0, postcode.Length - 3);

            // GET ALL THE ENGINEERS THAT COVER THAT POSTCODE
            postcodeEngineers = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(postcode);
            cntPostcodeEng = postcodeEngineers.Table.Rows.Count;
            if (cntPostcodeEng > 0)
            {
                for (int i = 0, loopTo = cntPostcodeEng - 1; i <= loopTo; i++)
                {
                    VBMath.Randomize();
                    randomNum = Conversions.ToInteger(Conversion.Int(postcodeEngineers.Table.Rows.Count * VBMath.Rnd() + 1)) - 1;
                    match = CheckAvailability(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfSlotsNeeded);

                    // IF A ENG & SLOT IS FOUND, RETURN
                    if (match.Count > 0)
                    {
                        return match;
                    }
                    else
                    {
                        postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows[randomNum]);
                    }
                }
            }

            return match;
        }

        private ArrayList CheckAvailability(DateTime estimatedVisitDate, int engineerID, int numOfSlotsNeeded)
        {
            DataTable engTimeSlots;
            var numOfSlotsAvailable = new ArrayList();
            var actualVisitDate = estimatedVisitDate;
            var match = new ArrayList();
            string startSlotTime = "";
            for (int day = 0; day <= 4; day++)
            {
                numOfSlotsAvailable.Clear();

                // ADD ON DAYS - UNLESS FIRST TIME IN
                if (day != 0)
                {
                    actualVisitDate = actualVisitDate.AddDays(1);
                }

                // MAKE IT NOT SAT
                if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    actualVisitDate = actualVisitDate.AddDays(2);
                }
                // MAKE IT NOT SUN
                if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    actualVisitDate = actualVisitDate.AddDays(1);
                }

                // GET SLOTS USED
                engTimeSlots = App.DB.Scheduler.Scheduler_DayTimeSlots(actualVisitDate, engineerID.ToString());
                // SLOTS ARE DISPLAY AS COLUMNS IN THIS TABLE THAT WHY WE LOOP THROUGH COLUMNS INSTEAD OF ROWS
                if (engTimeSlots.Rows.Count > 0)
                {
                    for (int colCnt = 0, loopTo = engTimeSlots.Columns.Count - 1; colCnt <= loopTo; colCnt++)
                    {
                        // LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                        // EQUAL TO THE NUMBER OF REQUIRED SLOTS
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engTimeSlots.Rows[0][colCnt], 0, false)))
                        {
                            numOfSlotsAvailable.Add(engTimeSlots.Columns[colCnt].ColumnName);
                            if (numOfSlotsAvailable.Count == numOfSlotsNeeded)
                            {
                                break;
                            }
                        }
                        else
                        {
                            // NOTHING AVAIALABLE
                            numOfSlotsAvailable.Clear();
                        }
                    }
                }
                else
                {
                    // IF NO ROW THEN NOTHING USED FOR THAT DAY SO VISIT CAN GO AT THE BEGINNING
                    numOfSlotsAvailable.Add(App.DB.Manager.Get().WorkingHoursStart);
                }

                if (numOfSlotsAvailable.Count > 0)
                {
                    if (Conversions.ToBoolean(numOfSlotsAvailable.Count == numOfSlotsNeeded | Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
                    {
                        // IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
                        {
                            startSlotTime = Conversions.ToString(numOfSlotsAvailable[0]);
                        }
                        else
                        {
                            startSlotTime = Strings.Replace(Conversions.ToString(numOfSlotsAvailable[0]), "T", "").Insert(2, ":");
                        }

                        actualVisitDate = Conversions.ToDate(Strings.Format(actualVisitDate, "dd/MM/yyyy") + " " + startSlotTime);
                        match.Add(actualVisitDate);
                        match.Add(engineerID);
                        return match;
                    }
                }
            }

            return match;
        }

        private TabPage AddJobOfWork(Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork jobOfWork, Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite CurrentQuoteContractSite)
        {
            var tp = new TabPage();
            tp.BackColor = Color.White;
            var ctrl = new UCConvertJobOfWork();
            ctrl.OnControl = this;
            if (jobOfWork is null)
            {
                jobOfWork = new Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork();
                jobOfWork.SetQuoteContractSiteID = CurrentQuoteContractSite.QuoteContractSiteID;
                jobOfWork.FirstVisitDate = CurrentQuoteContract.ContractStart.AddDays(1);
                jobOfWork = App.DB.QuoteContractAlternativeSiteJobOfWork.Insert(jobOfWork);
            }

            ctrl.CurrentJobOfWork = jobOfWork;
            ctrl.Dock = DockStyle.Fill;
            tp.Controls.Add(ctrl);
            TCJobsOfWork.TabPages.Add(tp);
            CheckTabs();
            TCJobsOfWork.SelectedTab = tp;
            return tp;
        }

        private void CheckTabs()
        {
            int i = 1;
            foreach (TabPage tab in TCJobsOfWork.TabPages)
            {
                tab.Text = "Job Of Work #" + i;
                i += 1;
            }
        }

        private void InsertInvoiceToBeRaiseLines(Entity.ContractsAlternative.ContractAlternative CurrentContract)
        {
            int numberOfInvoicesToRaise = 0;
            var switchExpr = (Entity.Sys.Enums.InvoiceFrequency)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.InvoiceFrequency.Annually:
                    {
                        numberOfInvoicesToRaise = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate));
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) * 2);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Monthly:
                    {
                        numberOfInvoicesToRaise = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate));
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Per_Visit:
                    {
                        break;
                    }
                // Invoice the visit
                case Entity.Sys.Enums.InvoiceFrequency.Quarterly:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) / (decimal)3);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Weekly:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Day, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) / (decimal)7);
                        break;
                    }
            }

            var raiseDate = CurrentContract.FirstInvoiceDate;
            for (int i = 1, loopTo = numberOfInvoicesToRaise; i <= loopTo; i++)
            {
                var invToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID;
                invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID;
                invToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Contract_Option2);
                invToBeRaised.SetLinkID = CurrentContract.ContractID;
                invToBeRaised.RaiseDate = raiseDate;
                App.DB.InvoiceToBeRaised.Insert(invToBeRaised);
                var switchExpr1 = (Entity.Sys.Enums.InvoiceFrequency)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.InvoiceFrequency.Annually:
                        {
                            raiseDate = raiseDate.AddYears(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually:
                        {
                            raiseDate = raiseDate.AddMonths(6);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Monthly:
                        {
                            raiseDate = raiseDate.AddMonths(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Quarterly:
                        {
                            raiseDate = raiseDate.AddMonths(3);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Weekly:
                        {
                            raiseDate = raiseDate.AddDays(7);
                            break;
                        }
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}