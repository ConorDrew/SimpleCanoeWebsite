﻿using FSM.Entity.Sys;
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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMContractRenewal() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Button btnCreateContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateContract != null)
                {
                    _btnCreateContract.Click -= btnCreateContract_Click;
                }

                _btnCreateContract = value;
                if (_btnCreateContract != null)
                {
                    _btnCreateContract.Click += btnCreateContract_Click;
                }
            }
        }

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

        internal GroupBox gpbContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbContract != null)
                {
                }

                _gpbContract = value;
                if (_gpbContract != null)
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

        internal GroupBox gpbSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbSites != null)
                {
                }

                _gpbSites = value;
                if (_gpbSites != null)
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
            _gpbContract = new GroupBox();
            _gpbInvoiceAddress = new GroupBox();
            _dgInvoiceAddress = new DataGrid();
            _cboInvoiceFrequencyID = new ComboBox();
            _cboInvoiceFrequencyID.SelectedIndexChanged += new EventHandler(cboInvoiceFrequencyID_SelectedIndexChanged);
            _lblInvoiceFrequencyID = new Label();
            _Label6 = new Label();
            _Label5 = new Label();
            _dtpInvoiceDate = new DateTimePicker();
            _Label4 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _txtNewPrice = new TextBox();
            _dtpStartDate = new DateTimePicker();
            _dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            _dtpEndDate = new DateTimePicker();
            _txtPercentMarkup = new TextBox();
            _txtPercentMarkup.TextChanged += new EventHandler(txtPercentMarkup_TextChanged);
            _btnCreateContract = new Button();
            _btnCreateContract.Click += new EventHandler(btnCreateContract_Click);
            _dgFirstVisitDates = new DataGrid();
            _gpbSites = new GroupBox();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _gpbContract.SuspendLayout();
            _gpbInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgFirstVisitDates).BeginInit();
            _gpbSites.SuspendLayout();
            SuspendLayout();
            //
            // gpbContract
            //
            _gpbContract.Controls.Add(_gpbInvoiceAddress);
            _gpbContract.Controls.Add(_cboInvoiceFrequencyID);
            _gpbContract.Controls.Add(_lblInvoiceFrequencyID);
            _gpbContract.Controls.Add(_Label6);
            _gpbContract.Controls.Add(_Label5);
            _gpbContract.Controls.Add(_dtpInvoiceDate);
            _gpbContract.Controls.Add(_Label4);
            _gpbContract.Controls.Add(_Label3);
            _gpbContract.Controls.Add(_Label2);
            _gpbContract.Controls.Add(_Label1);
            _gpbContract.Controls.Add(_txtNewPrice);
            _gpbContract.Controls.Add(_dtpStartDate);
            _gpbContract.Controls.Add(_dtpEndDate);
            _gpbContract.Controls.Add(_txtPercentMarkup);
            _gpbContract.Location = new Point(6, 38);
            _gpbContract.Name = "gpbContract";
            _gpbContract.Size = new Size(908, 185);
            _gpbContract.TabIndex = 2;
            _gpbContract.TabStop = false;
            _gpbContract.Text = "Contract";
            //
            // gpbInvoiceAddress
            //
            _gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbInvoiceAddress.Controls.Add(_dgInvoiceAddress);
            _gpbInvoiceAddress.Location = new Point(350, 15);
            _gpbInvoiceAddress.Name = "gpbInvoiceAddress";
            _gpbInvoiceAddress.Size = new Size(539, 162);
            _gpbInvoiceAddress.TabIndex = 16;
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
            _dgInvoiceAddress.Size = new Size(523, 134);
            _dgInvoiceAddress.TabIndex = 0;
            //
            // cboInvoiceFrequencyID
            //
            _cboInvoiceFrequencyID.Cursor = Cursors.Hand;
            _cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceFrequencyID.Location = new Point(123, 154);
            _cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
            _cboInvoiceFrequencyID.Size = new Size(195, 21);
            _cboInvoiceFrequencyID.TabIndex = 15;
            _cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID";
            //
            // lblInvoiceFrequencyID
            //
            _lblInvoiceFrequencyID.Location = new Point(8, 157);
            _lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
            _lblInvoiceFrequencyID.Size = new Size(132, 20);
            _lblInvoiceFrequencyID.TabIndex = 14;
            _lblInvoiceFrequencyID.Text = "Invoice Frequency";
            //
            // Label6
            //
            _Label6.Location = new Point(8, 43);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(80, 23);
            _Label6.TabIndex = 12;
            _Label6.Text = "New Price";
            _Label6.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 125);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(93, 23);
            _Label5.TabIndex = 11;
            _Label5.Text = "Invoice Date";
            _Label5.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpInvoiceDate
            //
            _dtpInvoiceDate.Location = new Point(123, 126);
            _dtpInvoiceDate.Name = "dtpInvoiceDate";
            _dtpInvoiceDate.Size = new Size(195, 21);
            _dtpInvoiceDate.TabIndex = 10;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 98);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 23);
            _Label4.TabIndex = 9;
            _Label4.Text = "End Date";
            _Label4.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 71);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(100, 23);
            _Label3.TabIndex = 8;
            _Label3.Text = "Start Date";
            _Label3.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label2
            //
            _Label2.Location = new Point(324, 15);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(30, 23);
            _Label2.TabIndex = 7;
            _Label2.Text = "%";
            _Label2.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 15);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 23);
            _Label1.TabIndex = 6;
            _Label1.Text = "Markup Amount";
            _Label1.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtNewPrice
            //
            _txtNewPrice.Location = new Point(123, 45);
            _txtNewPrice.Name = "txtNewPrice";
            _txtNewPrice.Size = new Size(195, 21);
            _txtNewPrice.TabIndex = 5;
            //
            // dtpStartDate
            //
            _dtpStartDate.Location = new Point(123, 72);
            _dtpStartDate.Name = "dtpStartDate";
            _dtpStartDate.Size = new Size(195, 21);
            _dtpStartDate.TabIndex = 2;
            //
            // dtpEndDate
            //
            _dtpEndDate.Location = new Point(123, 99);
            _dtpEndDate.Name = "dtpEndDate";
            _dtpEndDate.Size = new Size(195, 21);
            _dtpEndDate.TabIndex = 1;
            //
            // txtPercentMarkup
            //
            _txtPercentMarkup.Location = new Point(123, 17);
            _txtPercentMarkup.Name = "txtPercentMarkup";
            _txtPercentMarkup.Size = new Size(195, 21);
            _txtPercentMarkup.TabIndex = 0;
            //
            // btnCreateContract
            //
            _btnCreateContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreateContract.Location = new Point(790, 251);
            _btnCreateContract.Name = "btnCreateContract";
            _btnCreateContract.Size = new Size(112, 23);
            _btnCreateContract.TabIndex = 4;
            _btnCreateContract.Text = "Create Contract";
            //
            // dgFirstVisitDates
            //
            _dgFirstVisitDates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgFirstVisitDates.DataMember = "";
            _dgFirstVisitDates.HeaderForeColor = SystemColors.ControlText;
            _dgFirstVisitDates.Location = new Point(8, 24);
            _dgFirstVisitDates.Name = "dgFirstVisitDates";
            _dgFirstVisitDates.Size = new Size(894, 221);
            _dgFirstVisitDates.TabIndex = 3;
            //
            // gpbSites
            //
            _gpbSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbSites.Controls.Add(_btnCancel);
            _gpbSites.Controls.Add(_dgFirstVisitDates);
            _gpbSites.Controls.Add(_btnCreateContract);
            _gpbSites.Location = new Point(6, 229);
            _gpbSites.Name = "gpbSites";
            _gpbSites.Size = new Size(908, 281);
            _gpbSites.TabIndex = 3;
            _gpbSites.TabStop = false;
            _gpbSites.Text = "Properties - Enter Dates";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 251);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 5;
            _btnCancel.Text = "Cancel";
            //
            // FRMContractRenewal
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(928, 509);
            ControlBox = false;
            Controls.Add(_gpbSites);
            Controls.Add(_gpbContract);
            MinimumSize = new Size(928, 529);
            Name = "FRMContractRenewal";
            Text = "Contract Renewal";
            Controls.SetChildIndex(_gpbContract, 0);
            Controls.SetChildIndex(_gpbSites, 0);
            _gpbContract.ResumeLayout(false);
            _gpbContract.PerformLayout();
            _gpbInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgFirstVisitDates).EndInit();
            _gpbSites.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        private Entity.ContractsAlternative.ContractAlternative _OldContractTwo;

        private Entity.ContractsAlternative.ContractAlternative OldContractTwo
        {
            get
            {
                return _OldContractTwo;
            }

            set
            {
                _OldContractTwo = value;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

                case Entity.Sys.Enums.QuoteType.Contract_Opt_2:
                    {
                        txtNewPrice.Text = Strings.Format(OldContractTwo.ContractPrice * (percent / 100) + OldContractTwo.ContractPrice, "C");
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

                    case Entity.Sys.Enums.QuoteType.Contract_Opt_2:
                        {
                            PopulateTwo();
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

        private void PopulateTwo()
        {
            OldContractTwo = App.DB.ContractAlternative.Get(ContractID);
            txtPercentMarkup.Text = 0.ToString();
            dtpStartDate.Value = DateAndTime.Now;
            dtpEndDate.Value = DateAndTime.Now.AddYears(1).AddDays(-1);
            dtpInvoiceDate.Value = DateAndTime.Now;
            var argcombo = cboInvoiceFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, OldContractTwo.InvoiceFrequencyID.ToString());
            var newSiteJOWTable = new DataTable();
            newSiteJOWTable.Columns.Add("ContractSiteID");
            newSiteJOWTable.Columns.Add("Site");
            newSiteJOWTable.Columns.Add("SiteID");
            newSiteJOWTable.Columns.Add("VisitFrequency");
            newSiteJOWTable.Columns.Add("FirstVisitDate", typeof(DateTime));
            newSiteJOWTable.Columns.Add("ContractSiteJobOfWorkID");
            DataRow newSiteJOW;
            foreach (DataRow drSiteJOW in App.DB.ContractManager.ContractRenewal_AlternativeSitesJobOfWorks(ContractID).Table.Rows)
            {
                newSiteJOW = newSiteJOWTable.NewRow();
                newSiteJOW["ContractSiteID"] = drSiteJOW["ContractSiteID"];
                newSiteJOW["Site"] = drSiteJOW["Site"];
                newSiteJOW["SiteID"] = drSiteJOW["SiteID"];
                newSiteJOW["VisitFrequency"] = drSiteJOW["VisitFrequency"];
                newSiteJOW["FirstVisitDate"] = dtpStartDate.Value.AddDays(1);
                newSiteJOW["ContractSiteJobOfWorkID"] = drSiteJOW["ContractSiteJobOfWorkID"];
                newSiteJOWTable.Rows.Add(newSiteJOW);
            }

            OldSites = new DataView(newSiteJOWTable);
            // Load Invoice Addresses
            InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(OldContractTwo.CustomerID);
            if (OldContractTwo.InvoiceAddressID > 0)
            {
                int c = 0;
                foreach (DataRow dr in InvoiceAddresses.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AddressID"], OldContractTwo.InvoiceAddressID, false) & Operators.ConditionalCompareObjectEqual(dr["AddressTypeID"], OldContractTwo.InvoiceAddressTypeID, false)))
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

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ScheduleJobContractOne(Entity.ContractsOriginal.ContractOriginal Contract, Entity.ContractOriginalSites.ContractOriginalSite CurrentContractSite)
        {
            try
            {
                // Duration OF Contract In Days
                int contractDuration;
                contractDuration = Contract.ContractEndDate.Subtract(Contract.ContractStartDate).Days;

                // How Visit Should happen in days
                int numOfVisits = 0;
                int visitFreqInDays = 0;
                var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(CurrentContractSite.VisitFrequencyID);
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.VisitFrequency.Annually:
                        {
                            visitFreqInDays = 365;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                        {
                            visitFreqInDays = 182;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Monthly:
                        {
                            visitFreqInDays = 30;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Quarterly:
                        {
                            visitFreqInDays = 91;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Weekly:
                        {
                            visitFreqInDays = 7;
                            break;
                        }
                }

                numOfVisits = Conversions.ToInteger(Math.Floor(contractDuration / (double)visitFreqInDays));
                if (numOfVisits == 0)
                {
                    numOfVisits = 1;
                }

                DateTime estVisitDate = Conversions.ToDate(CurrentContractSite.FirstVisitDate.Date + " 09:00:00");
                for (int i = 1, loopTo = numOfVisits; i <= loopTo; i++)
                {
                    if (Conversions.ToDate(Strings.Format(estVisitDate, "dd/MM/yyyy") + " 00:00:00") >= Conversions.ToDate(Strings.Format(Contract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00") & Conversions.ToDate(Strings.Format(estVisitDate, "dd/MM/yyyy") + " 00:00:00") <= Conversions.ToDate(Strings.Format(Contract.ContractEndDate, "dd/MM/yyyy") + " 00:00:00"))

                    {
                        // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                        if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            estVisitDate = estVisitDate.AddDays(2);
                        }
                        else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            estVisitDate = estVisitDate.AddDays(1);
                        }

                        // CREATE JOB
                        var job = new Entity.Jobs.Job();
                        job.SetPropertyID = CurrentContractSite.PropertyID;
                        job.SetJobDefinitionEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobTypeID = 0;
                        job.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Open);
                        job.SetCreatedByUserID = App.loggedInUser.UserID;
                        var JobNumber = new JobNumber();
                        JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                        job.SetPONumber = "";
                        job.SetQuoteID = 0;
                        job.SetContractID = Contract.ContractID;
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(Contract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            job.SetDeleted = true;
                        }

                        // INSERT ANY ASSETS
                        foreach (DataRow dr in App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, CurrentContractSite.PropertyID).Table.Rows)
                        {
                            if (Entity.Sys.Helper.MakeBooleanValid(dr["Tick"]) == true)
                            {
                                var JobAsset = new Entity.JobAssets.JobAsset();
                                JobAsset.SetAssetID = dr["AssetID"];
                                job.Assets.Add(JobAsset);
                            }
                        }

                        // INSERT JOB ITEM
                        var jobOfWork = new Entity.JobOfWorks.JobOfWork();
                        jobOfWork.IgnoreExceptionsOnSetMethods = true;
                        jobOfWork.SetPONumber = "";
                        jobOfWork.SetDeleted = true;
                        var jobItem = new Entity.JobItems.JobItem();
                        jobItem.IgnoreExceptionsOnSetMethods = true;
                        jobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit");
                        jobOfWork.JobItems.Add(jobItem);

                        // NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                        var match = new ArrayList();
                        int engineerID = 0;
                        DateTime actualVisitDate = default;
                        match = MatchingEngineerContractOne(job, estVisitDate, CurrentContractSite.VisitDuration);
                        if (match is object)
                        {
                            if (match.Count > 0)
                            {
                                actualVisitDate = Conversions.ToDate(match[0]);
                                engineerID = Conversions.ToInteger(match[1]);
                            }
                        }

                        // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                        var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                        engineerVisit.IgnoreExceptionsOnSetMethods = true;
                        engineerVisit.SetEngineerID = engineerID;
                        engineerVisit.SetNotesToEngineer = "PPM Contract Visit";
                        if (engineerID > 0)
                        {
                            engineerVisit.StartDateTime = actualVisitDate;
                            engineerVisit.EndDateTime = actualVisitDate.AddHours(CurrentContractSite.VisitDuration);
                            engineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled);
                        }
                        else
                        {
                            engineerVisit.StartDateTime = DateTime.MinValue;
                            engineerVisit.EndDateTime = DateTime.MinValue;
                            engineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                        }

                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(Contract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            engineerVisit.SetDeleted = true;
                        }

                        jobOfWork.EngineerVisits.Add(engineerVisit);
                        job.JobOfWorks.Add(jobOfWork);
                        job = App.DB.Job.Insert(job);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit();
                        PPM.SetContractSiteID = CurrentContractSite.ContractSiteID;
                        PPM.EstimatedVisitDate = estVisitDate;
                        PPM.SetJobID = job.JobID;
                        App.DB.ContractOriginalPPMVisit.Insert(PPM);
                        estVisitDate = estVisitDate.AddDays(visitFreqInDays);
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ArrayList MatchingEngineerContractOne(Entity.Jobs.Job job, DateTime estVisitDate, double visitDuration)
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

            // 'VISIT DURATION FOR THIS SITE IN HOURS
            // visitDuration = Combo.GetSelectedItemValue(visitDuration)

            // NUM OF SLOTS NEEDED FOR VISIT
            if (visitDuration > 0)
            {
                numOfSlotsNeeded = (int)(visitDuration / slotDuration);
            }
            // ***************************************************************

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(job.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                match = CheckAvailabilityContractOne(estVisitDate, site.EngineerID, numOfSlotsNeeded);
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
                    match = CheckAvailabilityContractOne(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfSlotsNeeded);

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

            return default;
        }

        private ArrayList CheckAvailabilityContractOne(DateTime estimatedVisitDate, int engineerID, int numOfSlotsNeeded)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ScheduleJobContractTwo(DataView JobItemDV, DateTime FirstVisitDate, int ContractSiteJobOfWorkID, Entity.ContractsAlternative.ContractAlternative CurrentContract, Entity.ContractAlternativeSites.ContractAlternativeSite CurrentContractSite)
        {
            try
            {
                // Duration OF Contract In Days
                int ContractDuration;
                ContractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days;

                // How Visit Should happen in days
                int NumOfVisits = 0;
                int VisitFreqInDays = 0;
                var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(JobItemDV.Table.Rows[0]["VisitFrequencyID"]);
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

                NumOfVisits = Conversions.ToInteger(Math.Floor(ContractDuration / (double)VisitFreqInDays));
                if (NumOfVisits == 0)
                {
                    NumOfVisits = 1;
                }

                DateTime EstVisitDate = Conversions.ToDate(FirstVisitDate.Date + " 09:00:00");
                for (int i = 1, loopTo = NumOfVisits; i <= loopTo; i++)
                {
                    if (EstVisitDate >= CurrentContract.ContractStartDate & EstVisitDate <= CurrentContract.ContractEndDate)
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
                        job.SetPropertyID = CurrentContractSite.PropertyID;
                        job.SetJobDefinitionEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobTypeID = 0;
                        job.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Open);
                        job.SetCreatedByUserID = App.loggedInUser.UserID;
                        var JobNumber = new JobNumber();
                        JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                        job.SetPONumber = "";
                        job.SetQuoteID = 0;
                        job.SetContractID = CurrentContract.ContractID;
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            job.SetDeleted = true;
                        }

                        // INSERT JOB ITEM
                        var JobOfWork = new Entity.JobOfWorks.JobOfWork();
                        JobOfWork.IgnoreExceptionsOnSetMethods = true;
                        JobOfWork.SetPONumber = "";
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            JobOfWork.SetDeleted = true;
                        }

                        // Work out how long all the jobitems will take - running tally
                        int JobDuration = 0;
                        foreach (DataRow rw in JobItemDV.Table.Rows)
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
                        match = MatchingEngineerContractTwo(job, EstVisitDate, JobDuration);
                        if (match is object)
                        {
                            if (match.Count > 0)
                            {
                                actualVisitDate = Conversions.ToDate(match[0]);
                                engineerID = Conversions.ToInteger(match[1]);
                            }
                        }

                        // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                        var EngineerVisit = new Entity.EngineerVisits.EngineerVisit();
                        EngineerVisit.IgnoreExceptionsOnSetMethods = true;
                        EngineerVisit.SetEngineerID = engineerID;
                        EngineerVisit.SetNotesToEngineer = "PPM Contract Visit";
                        if (engineerID > 0)
                        {
                            EngineerVisit.StartDateTime = actualVisitDate;
                            EngineerVisit.EndDateTime = actualVisitDate.AddHours(JobDuration);
                            EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled);
                        }
                        else
                        {
                            EngineerVisit.StartDateTime = DateTime.MinValue;
                            EngineerVisit.EndDateTime = DateTime.MinValue;
                            EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                        }

                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            EngineerVisit.SetDeleted = true;
                        }

                        JobOfWork.EngineerVisits.Add(EngineerVisit);
                        job.JobOfWorks.Add(JobOfWork);
                        job = App.DB.Job.Insert(job);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit();
                        PPM.SetContractSiteJobOfWorkID = ContractSiteJobOfWorkID;
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

        private ArrayList MatchingEngineerContractTwo(Entity.Jobs.Job job, DateTime estVisitDate, int visitDuration)
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
                numOfSlotsNeeded = (int)(visitDuration / (double)slotDuration);
            }
            // ***************************************************************

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(job.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                match = CheckAvailabilityContractTwo(estVisitDate, site.EngineerID, numOfSlotsNeeded);
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
                    match = CheckAvailabilityContractTwo(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfSlotsNeeded);

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

            return default;
        }

        private ArrayList CheckAvailabilityContractTwo(DateTime estimatedVisitDate, int engineerID, int numOfSlotsNeeded)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

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