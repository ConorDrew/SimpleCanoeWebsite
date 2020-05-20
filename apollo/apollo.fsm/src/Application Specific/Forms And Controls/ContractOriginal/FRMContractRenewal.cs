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
    public class FRMContractRenewal : FRMBaseForm, IForm
    {
        public FRMContractRenewal() : base()
        {
            base.Load += FRMContractManager_Load;

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
        private TextBox _txtPercentMarkup;

        internal TextBox txtPercentMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPercentMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPercentMarkup != null)
                {
                    _txtPercentMarkup.TextChanged -= txtPercentMarkup_TextChanged;
                }

                _txtPercentMarkup = value;
                if (_txtPercentMarkup != null)
                {
                    _txtPercentMarkup.TextChanged += txtPercentMarkup_TextChanged;
                }
            }
        }

        private DateTimePicker _dtpEndDate;

        internal DateTimePicker dtpEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEndDate != null)
                {
                }

                _dtpEndDate = value;
                if (_dtpEndDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpStartDate;

        internal DateTimePicker dtpStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpStartDate != null)
                {
                    _dtpStartDate.ValueChanged -= dtpStartDate_ValueChanged;
                }

                _dtpStartDate = value;
                if (_dtpStartDate != null)
                {
                    _dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
                }
            }
        }

        private DataGrid _dgFirstVisitDates;

        internal DataGrid dgFirstVisitDates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgFirstVisitDates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgFirstVisitDates != null)
                {
                }

                _dgFirstVisitDates = value;
                if (_dgFirstVisitDates != null)
                {
                }
            }
        }

        private Button _btnCreateContract;

        private TextBox _txtNewPrice;

        internal TextBox txtNewPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNewPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNewPrice != null)
                {
                }

                _txtNewPrice = value;
                if (_txtNewPrice != null)
                {
                }
            }
        }

        private GroupBox _gpbContract;

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

        private GroupBox _gpbSites;

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

        private DateTimePicker _dtpInvoiceDate;

        internal DateTimePicker dtpInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpInvoiceDate != null)
                {
                }

                _dtpInvoiceDate = value;
                if (_dtpInvoiceDate != null)
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

        private GroupBox _gpbInvoiceAddress;

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
                }

                _dgInvoiceAddress = value;
                if (_dgInvoiceAddress != null)
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
                    _cboInvoiceFrequencyID.SelectedIndexChanged -= cboInvoiceFrequencyID_SelectedIndexChanged;
                }

                _cboInvoiceFrequencyID = value;
                if (_cboInvoiceFrequencyID != null)
                {
                    _cboInvoiceFrequencyID.SelectedIndexChanged += cboInvoiceFrequencyID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblInvoiceFrequencyID;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._gpbContract = new System.Windows.Forms.GroupBox();
            this._gpbInvoiceAddress = new System.Windows.Forms.GroupBox();
            this._dgInvoiceAddress = new System.Windows.Forms.DataGrid();
            this._cboInvoiceFrequencyID = new System.Windows.Forms.ComboBox();
            this._lblInvoiceFrequencyID = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtNewPrice = new System.Windows.Forms.TextBox();
            this._dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this._dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this._txtPercentMarkup = new System.Windows.Forms.TextBox();
            this._btnCreateContract = new System.Windows.Forms.Button();
            this._dgFirstVisitDates = new System.Windows.Forms.DataGrid();
            this._gpbSites = new System.Windows.Forms.GroupBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._gpbContract.SuspendLayout();
            this._gpbInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoiceAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgFirstVisitDates)).BeginInit();
            this._gpbSites.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gpbContract
            // 
            this._gpbContract.Controls.Add(this._gpbInvoiceAddress);
            this._gpbContract.Controls.Add(this._cboInvoiceFrequencyID);
            this._gpbContract.Controls.Add(this._lblInvoiceFrequencyID);
            this._gpbContract.Controls.Add(this._Label6);
            this._gpbContract.Controls.Add(this._Label5);
            this._gpbContract.Controls.Add(this._dtpInvoiceDate);
            this._gpbContract.Controls.Add(this._Label4);
            this._gpbContract.Controls.Add(this._Label3);
            this._gpbContract.Controls.Add(this._Label2);
            this._gpbContract.Controls.Add(this._Label1);
            this._gpbContract.Controls.Add(this._txtNewPrice);
            this._gpbContract.Controls.Add(this._dtpStartDate);
            this._gpbContract.Controls.Add(this._dtpEndDate);
            this._gpbContract.Controls.Add(this._txtPercentMarkup);
            this._gpbContract.Location = new System.Drawing.Point(6, 12);
            this._gpbContract.Name = "_gpbContract";
            this._gpbContract.Size = new System.Drawing.Size(908, 192);
            this._gpbContract.TabIndex = 2;
            this._gpbContract.TabStop = false;
            this._gpbContract.Text = "Contract";
            // 
            // _gpbInvoiceAddress
            // 
            this._gpbInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbInvoiceAddress.Controls.Add(this._dgInvoiceAddress);
            this._gpbInvoiceAddress.Location = new System.Drawing.Point(350, 15);
            this._gpbInvoiceAddress.Name = "_gpbInvoiceAddress";
            this._gpbInvoiceAddress.Size = new System.Drawing.Size(539, 162);
            this._gpbInvoiceAddress.TabIndex = 16;
            this._gpbInvoiceAddress.TabStop = false;
            this._gpbInvoiceAddress.Text = "Invoice Address";
            // 
            // _dgInvoiceAddress
            // 
            this._dgInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgInvoiceAddress.DataMember = "";
            this._dgInvoiceAddress.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgInvoiceAddress.Location = new System.Drawing.Point(8, 20);
            this._dgInvoiceAddress.Name = "_dgInvoiceAddress";
            this._dgInvoiceAddress.Size = new System.Drawing.Size(523, 134);
            this._dgInvoiceAddress.TabIndex = 0;
            // 
            // _cboInvoiceFrequencyID
            // 
            this._cboInvoiceFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboInvoiceFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInvoiceFrequencyID.Location = new System.Drawing.Point(123, 154);
            this._cboInvoiceFrequencyID.Name = "_cboInvoiceFrequencyID";
            this._cboInvoiceFrequencyID.Size = new System.Drawing.Size(195, 21);
            this._cboInvoiceFrequencyID.TabIndex = 15;
            this._cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID";
            this._cboInvoiceFrequencyID.SelectedIndexChanged += new System.EventHandler(this.cboInvoiceFrequencyID_SelectedIndexChanged);
            // 
            // _lblInvoiceFrequencyID
            // 
            this._lblInvoiceFrequencyID.Location = new System.Drawing.Point(8, 157);
            this._lblInvoiceFrequencyID.Name = "_lblInvoiceFrequencyID";
            this._lblInvoiceFrequencyID.Size = new System.Drawing.Size(132, 20);
            this._lblInvoiceFrequencyID.TabIndex = 14;
            this._lblInvoiceFrequencyID.Text = "Invoice Frequency";
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(8, 43);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(80, 23);
            this._Label6.TabIndex = 12;
            this._Label6.Text = "New Price";
            this._Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(8, 125);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(93, 23);
            this._Label5.TabIndex = 11;
            this._Label5.Text = "Invoice Date";
            this._Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _dtpInvoiceDate
            // 
            this._dtpInvoiceDate.Location = new System.Drawing.Point(123, 126);
            this._dtpInvoiceDate.Name = "_dtpInvoiceDate";
            this._dtpInvoiceDate.Size = new System.Drawing.Size(195, 21);
            this._dtpInvoiceDate.TabIndex = 10;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 98);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 23);
            this._Label4.TabIndex = 9;
            this._Label4.Text = "End Date";
            this._Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 71);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(100, 23);
            this._Label3.TabIndex = 8;
            this._Label3.Text = "Start Date";
            this._Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(324, 15);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(30, 23);
            this._Label2.TabIndex = 7;
            this._Label2.Text = "%";
            this._Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 15);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(100, 23);
            this._Label1.TabIndex = 6;
            this._Label1.Text = "Markup Amount";
            this._Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtNewPrice
            // 
            this._txtNewPrice.Location = new System.Drawing.Point(123, 45);
            this._txtNewPrice.Name = "_txtNewPrice";
            this._txtNewPrice.Size = new System.Drawing.Size(195, 21);
            this._txtNewPrice.TabIndex = 5;
            // 
            // _dtpStartDate
            // 
            this._dtpStartDate.Location = new System.Drawing.Point(123, 72);
            this._dtpStartDate.Name = "_dtpStartDate";
            this._dtpStartDate.Size = new System.Drawing.Size(195, 21);
            this._dtpStartDate.TabIndex = 2;
            this._dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // _dtpEndDate
            // 
            this._dtpEndDate.Location = new System.Drawing.Point(123, 99);
            this._dtpEndDate.Name = "_dtpEndDate";
            this._dtpEndDate.Size = new System.Drawing.Size(195, 21);
            this._dtpEndDate.TabIndex = 1;
            // 
            // _txtPercentMarkup
            // 
            this._txtPercentMarkup.Location = new System.Drawing.Point(123, 17);
            this._txtPercentMarkup.Name = "_txtPercentMarkup";
            this._txtPercentMarkup.Size = new System.Drawing.Size(195, 21);
            this._txtPercentMarkup.TabIndex = 0;
            this._txtPercentMarkup.TextChanged += new System.EventHandler(this.txtPercentMarkup_TextChanged);
            // 
            // _btnCreateContract
            // 
            this._btnCreateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreateContract.Location = new System.Drawing.Point(790, 270);
            this._btnCreateContract.Name = "_btnCreateContract";
            this._btnCreateContract.Size = new System.Drawing.Size(112, 23);
            this._btnCreateContract.TabIndex = 4;
            this._btnCreateContract.Text = "Create Contract";
            this._btnCreateContract.Click += new System.EventHandler(this.btnCreateContract_Click);
            // 
            // _dgFirstVisitDates
            // 
            this._dgFirstVisitDates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgFirstVisitDates.DataMember = "";
            this._dgFirstVisitDates.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgFirstVisitDates.Location = new System.Drawing.Point(8, 24);
            this._dgFirstVisitDates.Name = "_dgFirstVisitDates";
            this._dgFirstVisitDates.Size = new System.Drawing.Size(894, 240);
            this._dgFirstVisitDates.TabIndex = 3;
            // 
            // _gpbSites
            // 
            this._gpbSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbSites.Controls.Add(this._btnCancel);
            this._gpbSites.Controls.Add(this._dgFirstVisitDates);
            this._gpbSites.Controls.Add(this._btnCreateContract);
            this._gpbSites.Location = new System.Drawing.Point(6, 210);
            this._gpbSites.Name = "_gpbSites";
            this._gpbSites.Size = new System.Drawing.Size(908, 300);
            this._gpbSites.TabIndex = 3;
            this._gpbSites.TabStop = false;
            this._gpbSites.Text = "Properties - Enter Dates";
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 270);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FRMContractRenewal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 509);
            this.ControlBox = false;
            this.Controls.Add(this._gpbSites);
            this.Controls.Add(this._gpbContract);
            this.MinimumSize = new System.Drawing.Size(928, 529);
            this.Name = "FRMContractRenewal";
            this.Text = "Contract Renewal";
            this._gpbContract.ResumeLayout(false);
            this._gpbContract.PerformLayout();
            this._gpbInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoiceAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgFirstVisitDates)).EndInit();
            this._gpbSites.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var switchExpr = get_GetParameter(0);
            switch (switchExpr)
            {
                case var @case when @case == Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString():
                    {
                        ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_1;
                        break;
                    }

                case var case1 when case1 == Entity.Sys.Enums.QuoteType.Contract_Opt_2.ToString():
                    {
                        ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_2;
                        break;
                    }

                case var case2 when case2 == Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString():
                    {
                        ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_3;
                        break;
                    }
            }

            ContractID = Conversions.ToInteger(get_GetParameter(1));
            var argc = cboInvoiceFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            FormSetUp();
            Populate();
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

        private int _ContractID;

        private int ContractID
        {
            get
            {
                return _ContractID;
            }

            set
            {
                _ContractID = value;
            }
        }

        private Entity.Sys.Enums.QuoteType _ContractType;

        private Entity.Sys.Enums.QuoteType ContractType
        {
            get
            {
                return _ContractType;
            }

            set
            {
                _ContractType = value;
            }
        }

        private Entity.ContractsOriginal.ContractOriginal _OldContractOne;

        private Entity.ContractsOriginal.ContractOriginal OldContractOne
        {
            get
            {
                return _OldContractOne;
            }

            set
            {
                _OldContractOne = value;
            }
        }

        private DataView _OldSites;

        private DataView OldSites
        {
            get
            {
                return _OldSites;
            }

            set
            {
                _OldSites = value;
                _OldSites.AllowDelete = false;
                _OldSites.AllowEdit = true;
                _OldSites.AllowNew = false;
                _OldSites.Table.TableName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString();
                dgFirstVisitDates.DataSource = OldSites;
            }
        }

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

        private void FormSetUp()
        {
            SetupInvoiceAddressDataGrid();
            var switchExpr = ContractType;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteType.Contract_Opt_1:
                    {
                        SetupdgContractOne();
                        break;
                    }

                case Entity.Sys.Enums.QuoteType.Contract_Opt_2:
                    {
                        SetupdgContractTwo();
                        break;
                    }

                case Entity.Sys.Enums.QuoteType.Contract_Opt_3:
                    {
                        SetupContractThree();
                        break;
                    }
            }
        }

        private void SetupdgContractOne()
        {
            var tbStyle = dgFirstVisitDates.TableStyles[0];
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 300;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var FirstVisitDate = new DataGridEditableTextBoxColumn();
            FirstVisitDate.Format = "dd/MM/yyyy";
            FirstVisitDate.FormatInfo = null;
            FirstVisitDate.HeaderText = "First Visit Date";
            FirstVisitDate.MappingName = "FirstVisitDate";
            FirstVisitDate.ReadOnly = false;
            FirstVisitDate.Width = 120;
            FirstVisitDate.NullText = "";
            tbStyle.GridColumnStyles.Add(FirstVisitDate);
            tbStyle.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString();
            dgFirstVisitDates.ReadOnly = false;
            dgFirstVisitDates.TableStyles.Add(tbStyle);
        }

        private void SetupdgContractTwo()
        {
            var tbStyle = dgFirstVisitDates.TableStyles[0];
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 250;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var VisitFrequency = new DataGridLabelColumn();
            VisitFrequency.Format = "";
            VisitFrequency.FormatInfo = null;
            VisitFrequency.HeaderText = "Visit Frequency";
            VisitFrequency.MappingName = "VisitFrequency";
            VisitFrequency.ReadOnly = true;
            VisitFrequency.Width = 100;
            VisitFrequency.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitFrequency);
            var FirstVisitDate = new DataGridEditableTextBoxColumn();
            FirstVisitDate.Format = "dd/MM/yyyy";
            FirstVisitDate.FormatInfo = null;
            FirstVisitDate.HeaderText = "First Visit Date";
            FirstVisitDate.MappingName = "FirstVisitDate";
            FirstVisitDate.ReadOnly = false;
            FirstVisitDate.Width = 100;
            FirstVisitDate.NullText = "";
            tbStyle.GridColumnStyles.Add(FirstVisitDate);
            tbStyle.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString();
            dgFirstVisitDates.ReadOnly = false;
            dgFirstVisitDates.TableStyles.Add(tbStyle);
        }

        private void SetupContractThree()
        {
            var tbStyle = dgFirstVisitDates.TableStyles[0];
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 250;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var StartDate = new DataGridEditableTextBoxColumn();
            StartDate.Format = "dd/MM/yyyy";
            StartDate.FormatInfo = null;
            StartDate.HeaderText = "Start Date";
            StartDate.MappingName = "StartDate";
            StartDate.ReadOnly = false;
            StartDate.Width = 100;
            StartDate.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDate);
            var EndDate = new DataGridEditableTextBoxColumn();
            EndDate.Format = "dd/MM/yyyy";
            EndDate.FormatInfo = null;
            EndDate.HeaderText = "End Date";
            EndDate.MappingName = "EndDate";
            EndDate.ReadOnly = false;
            EndDate.Width = 100;
            EndDate.NullText = "";
            tbStyle.GridColumnStyles.Add(EndDate);
            var FirstVisitDate = new DataGridEditableTextBoxColumn();
            FirstVisitDate.Format = "dd/MM/yyyy";
            FirstVisitDate.FormatInfo = null;
            FirstVisitDate.HeaderText = "First Visit Date";
            FirstVisitDate.MappingName = "FirstVisitDate";
            FirstVisitDate.ReadOnly = false;
            FirstVisitDate.Width = 100;
            FirstVisitDate.NullText = "";
            tbStyle.GridColumnStyles.Add(FirstVisitDate);
            tbStyle.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString();
            dgFirstVisitDates.ReadOnly = false;
            dgFirstVisitDates.TableStyles.Add(tbStyle);
        }

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddress);
            var tStyle = dgInvoiceAddress.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            // tStyle.AllowSorting = False
            // tStyle.ReadOnly = False
            // dgInvoiceAddress.ReadOnly = False

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

        private void FRMContractManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void txtPercentMarkup_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            if (!(txtPercentMarkup.Text.Length == 0))
            {
                if (Information.IsNumeric(txtPercentMarkup.Text))
                {
                    percent = Conversions.ToDouble(txtPercentMarkup.Text);
                }
            }

            var switchExpr = ContractType;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteType.Contract_Opt_1:
                    {
                        txtNewPrice.Text = Strings.Format(Conversions.ToDouble(OldContractOne.ContractPrice) * (percent / 100) + Conversions.ToDouble(OldContractOne.ContractPrice), "C");
                        break;
                    }
            }

            if (percent == 0)
            {
                txtPercentMarkup.Text = percent.ToString();
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value.AddYears(1).AddDays(-1);
            }

            if (OldSites is object)
            {
                foreach (DataRow dr in OldSites.Table.Rows)
                    dr["FirstVisitDate"] = dtpStartDate.Value.AddDays(1);
            }
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            base.Cursor = Cursors.WaitCursor;
            bool saved = false;
            var switchExpr = ContractType;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteType.Contract_Opt_1:
                    {
                        saved = SaveOne();
                        break;
                    }
            }

            if (saved)
            {
                var switchExpr1 = ContractType;
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.QuoteType.Contract_Opt_1:
                        {
                            int newContractID = App.DB.ContractManager.ContractRenewals_GetNewID_ByOldID(ContractID, Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Contract_Opt_1));
                            var dtContracts = App.DB.ContractOriginal.ProcessContract(newContractID);
                            if (dtContracts is null)
                                return;
                            var details = new ArrayList() { dtContracts };
                            var oPrint = new Entity.Sys.Printing(details, "", Entity.Sys.Enums.SystemDocumentType.ContractOption1);
                            break;
                        }
                }

                base.Cursor = Cursors.Default;
                ((FRMContractManager)get_GetParameter(2)).PopulateDatagrid();
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

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void Populate()
        {
            try
            {
                var switchExpr = ContractType;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.QuoteType.Contract_Opt_1:
                        {
                            PopulateOne();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateOne()
        {
            OldContractOne = App.DB.ContractOriginal.Get(ContractID);
            txtPercentMarkup.Text = 0.ToString();
            dtpStartDate.Value = DateAndTime.Now;
            dtpEndDate.Value = DateAndTime.Now.AddYears(1).AddDays(-1);
            dtpInvoiceDate.Value = DateAndTime.Now;
            var argcombo = cboInvoiceFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, OldContractOne.InvoiceFrequencyID.ToString());
            var newSiteOneTable = new DataTable();
            newSiteOneTable.Columns.Add("SiteID");
            newSiteOneTable.Columns.Add("ContractSiteID");
            newSiteOneTable.Columns.Add("Site");
            newSiteOneTable.Columns.Add("FirstVisitDate", typeof(DateTime));
            DataRow newSite;
            foreach (DataRow drSite in App.DB.ContractOriginalSite.GetAll_ContractID(ContractID, OldContractOne.CustomerID).Table.Rows)
            {
                if (Entity.Sys.Helper.MakeBooleanValid(drSite["Tick"]) == true)
                {
                    newSite = newSiteOneTable.NewRow();
                    newSite["SiteID"] = drSite["SiteID"];
                    newSite["ContractSiteID"] = drSite["ContractSiteID"];
                    newSite["Site"] = drSite["Site"];
                    newSite["FirstVisitDate"] = dtpStartDate.Value.AddDays(1);
                    newSiteOneTable.Rows.Add(newSite);
                }
            }

            OldSites = new DataView(newSiteOneTable);

            // Load Invoice Addresses
            InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(OldContractOne.CustomerID);
            if (OldContractOne.InvoiceAddressID > 0)
            {
                int c = 0;
                foreach (DataRow dr in InvoiceAddresses.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AddressID"], OldContractOne.InvoiceAddressID, false) & Operators.ConditionalCompareObjectEqual(dr["AddressTypeID"], OldContractOne.InvoiceAddressTypeID, false)))
                    {
                        dgInvoiceAddress.CurrentRowIndex = c;
                        break;
                    }

                    c += 1;
                }
            }
            else
            {
                dgInvoiceAddress.CurrentRowIndex = 0;
            }

            if (dgInvoiceAddress.CurrentRowIndex < 0)
            {
                dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
            }
        }

        private bool SaveOne()
        {
            try
            {
                var newCon1 = new Entity.ContractsOriginal.ContractOriginal();
                if (SelectedInvoiceAddressesDataRow is object)
                {
                    newCon1.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow["AddressID"];
                    newCon1.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                }

                string err = "";
                if (dtpEndDate.Value <= dtpStartDate.Value)
                {
                    err += "* End Date must be after Start Date" + Constants.vbCrLf;
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInvoiceFrequencyID)) == 0)
                {
                    err += "* Select Invoice Frequency";
                }

                if (newCon1.InvoiceAddressID == 0)
                {
                    err += "* Select Invoice Address";
                }

                foreach (DataRow dr in OldSites.Table.Rows)
                {
                    if (Conversions.ToBoolean(!(Helper.MakeDateTimeValid(dr["FirstVisitDate"]) > dtpStartDate.Value & Helper.MakeDateTimeValid(dr["FirstVisitDate"]) < dtpEndDate.Value)))
                    {
                        err += "* First Visit Dates must be between contract start and end dates." + Constants.vbCrLf;
                    }
                }

                if (err.Length > 0)
                {
                    App.ShowMessage("Please correct the following errors" + Constants.vbCrLf + err, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    // InsertContract

                    newCon1.SetContractPrice = txtNewPrice.Text.Replace("£", "");
                    newCon1.SetContractReference = OldContractOne.ContractReference;
                    newCon1.SetContractStatusID = Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.Active);
                    newCon1.SetCustomerID = OldContractOne.CustomerID;
                    newCon1.SetInvoiceFrequencyID = Combo.get_GetSelectedItemValue(cboInvoiceFrequencyID);
                    newCon1.ContractStartDate = dtpStartDate.Value;
                    newCon1.ContractEndDate = dtpEndDate.Value;
                    newCon1.FirstInvoiceDate = dtpInvoiceDate.Value;
                    newCon1.SetContractTypeID = OldContractOne.ContractTypeID;
                    newCon1.SetGasSupplyPipework = OldContractOne.GasSupplyPipework;
                    newCon1 = App.DB.ContractOriginal.Insert(newCon1);
                    {
                        var withBlock = newCon1;
                        InsertInvoiceToBeRaiseLines(withBlock.InvoiceFrequencyID, withBlock.ContractStartDate, withBlock.ContractEndDate, withBlock.FirstInvoiceDate, withBlock.InvoiceAddressID, withBlock.InvoiceAddressTypeID, withBlock.ContractID, Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Contract_Option1));
                    }

                    foreach (DataRow drSite in OldSites.Table.Rows)
                        App.ShowForm(typeof(FRMContractOriginalSite), true, new object[] { 0, drSite["SiteID"], newCon1, this, drSite["ContractSiteID"] });
                    App.DB.ContractManager.ContractRenewalsInsert(OldContractOne.ContractID, newCon1.ContractID, Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Contract_Opt_1));
                    return true;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void InsertInvoiceToBeRaiseLines(int InvoiceFrequencyID, DateTime StartDate, DateTime EndDate, DateTime FirstInvoiceDate, int InvoiceAddressID, int InvoiceAddressTypeID, int LinkID, int InvoiceType)
        {
            StartDate = Conversions.ToDate(Strings.Format(StartDate, "dd/MM/yyyy") + " 00:00:00");
            EndDate = Conversions.ToDate(Strings.Format(EndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
            int M = Math.Abs(StartDate.Year - EndDate.Year);
            int Numberofmonths = M * 12 + Math.Abs(StartDate.Month - EndDate.Month);
            int days = EndDate.Subtract(StartDate).Days;
            int numberOfInvoicesToRaise = 0;
            var switchExpr = (Entity.Sys.Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(InvoiceFrequencyID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)12);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)6);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)1);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit:
                    {
                        break;
                    }
                // Invoice the visit
                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)3);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)4);
                        break;
                    }
            }

            if (numberOfInvoicesToRaise == 0)
            {
                numberOfInvoicesToRaise = 1;
            }

            var raiseDate = FirstInvoiceDate;
            for (int i = 1, loopTo = numberOfInvoicesToRaise; i <= loopTo; i++)
            {
                var invToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                invToBeRaised.SetAddressLinkID = InvoiceAddressID;
                invToBeRaised.SetAddressTypeID = InvoiceAddressTypeID;
                invToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Contract_Option1);
                invToBeRaised.SetLinkID = LinkID;
                invToBeRaised.RaiseDate = raiseDate;
                App.DB.InvoiceToBeRaised.Insert(invToBeRaised);
                var switchExpr1 = (Entity.Sys.Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(InvoiceFrequencyID);
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually:
                        {
                            raiseDate = raiseDate.AddYears(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                        {
                            raiseDate = raiseDate.AddMonths(6);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly:
                        {
                            raiseDate = raiseDate.AddMonths(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly:
                        {
                            raiseDate = raiseDate.AddMonths(3);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                        {
                            raiseDate = raiseDate.AddMonths(4);
                            break;
                        }
                }
            }
        }

        private void cboInvoiceFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}