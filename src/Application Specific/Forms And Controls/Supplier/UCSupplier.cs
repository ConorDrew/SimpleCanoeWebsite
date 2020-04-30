using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCSupplier : UCBase, IUserControl
    {
        

        public UCSupplier() : base()
        {
            
            
            base.Load += UCSupplier_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboMainSupplier;
            Combo.SetUpCombo(ref argc, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            cboMainSupplier.Visible = false;
            Label4.Visible = false;
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

        private GroupBox _grpSupplier;

        internal GroupBox grpSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSupplier != null)
                {
                }

                _grpSupplier = value;
                if (_grpSupplier != null)
                {
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private TextBox _txtAddress1;

        internal TextBox txtAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress1 != null)
                {
                }

                _txtAddress1 = value;
                if (_txtAddress1 != null)
                {
                }
            }
        }

        private Label _lblAddress1;

        internal Label lblAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress1 != null)
                {
                }

                _lblAddress1 = value;
                if (_lblAddress1 != null)
                {
                }
            }
        }

        private TextBox _txtAddress2;

        internal TextBox txtAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress2 != null)
                {
                }

                _txtAddress2 = value;
                if (_txtAddress2 != null)
                {
                }
            }
        }

        private Label _lblAddress2;

        internal Label lblAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress2 != null)
                {
                }

                _lblAddress2 = value;
                if (_lblAddress2 != null)
                {
                }
            }
        }

        private TextBox _txtAddress3;

        internal TextBox txtAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress3 != null)
                {
                }

                _txtAddress3 = value;
                if (_txtAddress3 != null)
                {
                }
            }
        }

        private Label _lblAddress3;

        internal Label lblAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress3 != null)
                {
                }

                _lblAddress3 = value;
                if (_lblAddress3 != null)
                {
                }
            }
        }

        private Label _lblTown;

        internal Label lblTown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTown != null)
                {
                }

                _lblTown = value;
                if (_lblTown != null)
                {
                }
            }
        }

        private Label _lblCounty;

        internal Label lblCounty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCounty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCounty != null)
                {
                }

                _lblCounty = value;
                if (_lblCounty != null)
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

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
                {
                }
            }
        }

        private TextBox _txtTelephoneNum;

        internal TextBox txtTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTelephoneNum != null)
                {
                }

                _txtTelephoneNum = value;
                if (_txtTelephoneNum != null)
                {
                }
            }
        }

        private Label _lblTelephoneNum;

        internal Label lblTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTelephoneNum != null)
                {
                }

                _lblTelephoneNum = value;
                if (_lblTelephoneNum != null)
                {
                }
            }
        }

        private TextBox _txtFaxNum;

        internal TextBox txtFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaxNum != null)
                {
                }

                _txtFaxNum = value;
                if (_txtFaxNum != null)
                {
                }
            }
        }

        private Label _lblFaxNum;

        internal Label lblFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaxNum != null)
                {
                }

                _lblFaxNum = value;
                if (_lblFaxNum != null)
                {
                }
            }
        }

        private TextBox _txtEmailAddress;

        internal TextBox txtEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmailAddress != null)
                {
                }

                _txtEmailAddress = value;
                if (_txtEmailAddress != null)
                {
                }
            }
        }

        private Label _lblEmailAddress;

        internal Label lblEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmailAddress != null)
                {
                }

                _lblEmailAddress = value;
                if (_lblEmailAddress != null)
                {
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private TextBox _txtAddress4;

        internal TextBox txtAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress4 != null)
                {
                }

                _txtAddress4 = value;
                if (_txtAddress4 != null)
                {
                }
            }
        }

        private TextBox _txtAddress5;

        internal TextBox txtAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress5 != null)
                {
                }

                _txtAddress5 = value;
                if (_txtAddress5 != null)
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

        private TextBox _txtGaswayAccount;

        internal TextBox txtGaswayAccount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGaswayAccount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGaswayAccount != null)
                {
                }

                _txtGaswayAccount = value;
                if (_txtGaswayAccount != null)
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

        private CheckBox _chkSupplierBranch;

        internal CheckBox chkSupplierBranch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSupplierBranch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSupplierBranch != null)
                {
                    
                    
                    _chkSupplierBranch.CheckedChanged -= chkSupplierBranch_CheckedChanged;
                }

                _chkSupplierBranch = value;
                if (_chkSupplierBranch != null)
                {
                    _chkSupplierBranch.CheckedChanged += chkSupplierBranch_CheckedChanged;
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

        private ComboBox _cboMainSupplier;

        internal ComboBox cboMainSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMainSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMainSupplier != null)
                {
                }

                _cboMainSupplier = value;
                if (_cboMainSupplier != null)
                {
                }
            }
        }

        private CheckBox _chkReleaseToTablets;

        internal CheckBox chkReleaseToTablets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkReleaseToTablets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkReleaseToTablets != null)
                {
                }

                _chkReleaseToTablets = value;
                if (_chkReleaseToTablets != null)
                {
                }
            }
        }

        private CheckBox _chkSubContractor;

        internal CheckBox chkSubContractor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSubContractor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSubContractor != null)
                {
                }

                _chkSubContractor = value;
                if (_chkSubContractor != null)
                {
                }
            }
        }

        private CheckBox _chkSecondaryPrice;

        internal CheckBox chkSecondaryPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSecondaryPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSecondaryPrice != null)
                {
                    _chkSecondaryPrice.CheckedChanged -= chkSecondaryPrice_CheckedChanged;
                }

                _chkSecondaryPrice = value;
                if (_chkSecondaryPrice != null)
                {
                    _chkSecondaryPrice.CheckedChanged += chkSecondaryPrice_CheckedChanged;
                }
            }
        }

        private TextBox _txtNominal;

        internal TextBox txtNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominal != null)
                {
                }

                _txtNominal = value;
                if (_txtNominal != null)
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

        private TextBox _txtSecondAccountNumber;

        internal TextBox txtSecondAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSecondAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSecondAccountNumber != null)
                {
                }

                _txtSecondAccountNumber = value;
                if (_txtSecondAccountNumber != null)
                {
                }
            }
        }

        private Label _lblSecondAccount;

        internal Label lblSecondAccount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSecondAccount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSecondAccount != null)
                {
                }

                _lblSecondAccount = value;
                if (_lblSecondAccount != null)
                {
                }
            }
        }

        private TextBox _txtAccountNumber;

        internal TextBox txtAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccountNumber != null)
                {
                }

                _txtAccountNumber = value;
                if (_txtAccountNumber != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSupplier = new GroupBox();
            _txtNominal = new TextBox();
            _Label3 = new Label();
            _txtSecondAccountNumber = new TextBox();
            _lblSecondAccount = new Label();
            _chkSecondaryPrice = new CheckBox();
            _chkSecondaryPrice.CheckedChanged += new EventHandler(chkSecondaryPrice_CheckedChanged);
            _chkSubContractor = new CheckBox();
            _chkReleaseToTablets = new CheckBox();
            _chkSupplierBranch = new CheckBox();
            _chkSupplierBranch.CheckedChanged += new EventHandler(chkSupplierBranch_CheckedChanged);
            _Label4 = new Label();
            _cboMainSupplier = new ComboBox();
            _txtGaswayAccount = new TextBox();
            _txtAccountNumber = new TextBox();
            _txtName = new TextBox();
            _lblName = new Label();
            _txtAddress1 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress2 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress4 = new TextBox();
            _lblTown = new Label();
            _txtAddress5 = new TextBox();
            _lblCounty = new Label();
            _txtPostcode = new TextBox();
            _lblPostcode = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _grpSupplier.SuspendLayout();
            SuspendLayout();
            //
            // grpSupplier
            //
            _grpSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSupplier.Controls.Add(_txtNominal);
            _grpSupplier.Controls.Add(_Label3);
            _grpSupplier.Controls.Add(_txtSecondAccountNumber);
            _grpSupplier.Controls.Add(_lblSecondAccount);
            _grpSupplier.Controls.Add(_chkSecondaryPrice);
            _grpSupplier.Controls.Add(_chkSubContractor);
            _grpSupplier.Controls.Add(_chkReleaseToTablets);
            _grpSupplier.Controls.Add(_chkSupplierBranch);
            _grpSupplier.Controls.Add(_Label4);
            _grpSupplier.Controls.Add(_cboMainSupplier);
            _grpSupplier.Controls.Add(_txtGaswayAccount);
            _grpSupplier.Controls.Add(_txtAccountNumber);
            _grpSupplier.Controls.Add(_txtName);
            _grpSupplier.Controls.Add(_lblName);
            _grpSupplier.Controls.Add(_txtAddress1);
            _grpSupplier.Controls.Add(_lblAddress1);
            _grpSupplier.Controls.Add(_txtAddress2);
            _grpSupplier.Controls.Add(_lblAddress2);
            _grpSupplier.Controls.Add(_txtAddress3);
            _grpSupplier.Controls.Add(_lblAddress3);
            _grpSupplier.Controls.Add(_txtAddress4);
            _grpSupplier.Controls.Add(_lblTown);
            _grpSupplier.Controls.Add(_txtAddress5);
            _grpSupplier.Controls.Add(_lblCounty);
            _grpSupplier.Controls.Add(_txtPostcode);
            _grpSupplier.Controls.Add(_lblPostcode);
            _grpSupplier.Controls.Add(_txtTelephoneNum);
            _grpSupplier.Controls.Add(_lblTelephoneNum);
            _grpSupplier.Controls.Add(_txtFaxNum);
            _grpSupplier.Controls.Add(_lblFaxNum);
            _grpSupplier.Controls.Add(_txtEmailAddress);
            _grpSupplier.Controls.Add(_lblEmailAddress);
            _grpSupplier.Controls.Add(_txtNotes);
            _grpSupplier.Controls.Add(_lblNotes);
            _grpSupplier.Controls.Add(_Label2);
            _grpSupplier.Controls.Add(_Label1);
            _grpSupplier.Location = new Point(8, 8);
            _grpSupplier.Name = "grpSupplier";
            _grpSupplier.Size = new Size(567, 665);
            _grpSupplier.TabIndex = 1;
            _grpSupplier.TabStop = false;
            _grpSupplier.Text = "Main Details";
            //
            // txtNominal
            //
            _txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNominal.Location = new Point(235, 125);
            _txtNominal.MaxLength = 25;
            _txtNominal.Name = "txtNominal";
            _txtNominal.Size = new Size(317, 21);
            _txtNominal.TabIndex = 43;
            _txtNominal.Tag = "Supplier.AccountNumber";
            //
            // Label3
            //
            _Label3.Location = new Point(10, 129);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(112, 20);
            _Label3.TabIndex = 44;
            _Label3.Text = "Default Nominal";
            //
            // txtSecondAccountNumber
            //
            _txtSecondAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSecondAccountNumber.Location = new Point(235, 537);
            _txtSecondAccountNumber.MaxLength = 25;
            _txtSecondAccountNumber.Name = "txtSecondAccountNumber";
            _txtSecondAccountNumber.Size = new Size(317, 21);
            _txtSecondAccountNumber.TabIndex = 43;
            _txtSecondAccountNumber.Tag = "Supplier.AccountNumber";
            _txtSecondAccountNumber.Visible = false;
            //
            // lblSecondAccount
            //
            _lblSecondAccount.Location = new Point(10, 541);
            _lblSecondAccount.Name = "lblSecondAccount";
            _lblSecondAccount.Size = new Size(190, 20);
            _lblSecondAccount.TabIndex = 44;
            _lblSecondAccount.Text = "Second Account Number";
            _lblSecondAccount.Visible = false;
            //
            // chkSecondaryPrice
            //
            _chkSecondaryPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkSecondaryPrice.AutoSize = true;
            _chkSecondaryPrice.Location = new Point(13, 573);
            _chkSecondaryPrice.Name = "chkSecondaryPrice";
            _chkSecondaryPrice.Size = new Size(119, 17);
            _chkSecondaryPrice.TabIndex = 42;
            _chkSecondaryPrice.Text = "Secondary Price";
            _chkSecondaryPrice.UseVisualStyleBackColor = true;
            //
            // chkSubContractor
            //
            _chkSubContractor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkSubContractor.AutoSize = true;
            _chkSubContractor.Location = new Point(13, 606);
            _chkSubContractor.Name = "chkSubContractor";
            _chkSubContractor.Size = new Size(119, 17);
            _chkSubContractor.TabIndex = 41;
            _chkSubContractor.Text = "Sub Contractor?";
            _chkSubContractor.UseVisualStyleBackColor = true;
            //
            // chkReleaseToTablets
            //
            _chkReleaseToTablets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkReleaseToTablets.AutoSize = true;
            _chkReleaseToTablets.Location = new Point(13, 640);
            _chkReleaseToTablets.Name = "chkReleaseToTablets";
            _chkReleaseToTablets.Size = new Size(187, 17);
            _chkReleaseToTablets.TabIndex = 40;
            _chkReleaseToTablets.Text = "Release Supplier to Tablets?";
            _chkReleaseToTablets.UseVisualStyleBackColor = true;
            //
            // chkSupplierBranch
            //
            _chkSupplierBranch.AutoSize = true;
            _chkSupplierBranch.Location = new Point(13, 22);
            _chkSupplierBranch.Name = "chkSupplierBranch";
            _chkSupplierBranch.Size = new Size(173, 17);
            _chkSupplierBranch.TabIndex = 39;
            _chkSupplierBranch.Text = "Is this a Supplier Branch?";
            _chkSupplierBranch.UseVisualStyleBackColor = true;
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(10, 50);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(84, 13);
            _Label4.TabIndex = 38;
            _Label4.Text = "Main Supplier";
            //
            // cboMainSupplier
            //
            _cboMainSupplier.FormattingEnabled = true;
            _cboMainSupplier.Location = new Point(235, 45);
            _cboMainSupplier.Name = "cboMainSupplier";
            _cboMainSupplier.Size = new Size(317, 21);
            _cboMainSupplier.TabIndex = 37;
            //
            // txtGaswayAccount
            //
            _txtGaswayAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtGaswayAccount.Location = new Point(235, 395);
            _txtGaswayAccount.MaxLength = 25;
            _txtGaswayAccount.Name = "txtGaswayAccount";
            _txtGaswayAccount.Size = new Size(317, 21);
            _txtGaswayAccount.TabIndex = 34;
            _txtGaswayAccount.Tag = "";
            //
            // txtAccountNumber
            //
            _txtAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAccountNumber.Location = new Point(235, 99);
            _txtAccountNumber.MaxLength = 25;
            _txtAccountNumber.Name = "txtAccountNumber";
            _txtAccountNumber.Size = new Size(317, 21);
            _txtAccountNumber.TabIndex = 3;
            _txtAccountNumber.Tag = "Supplier.AccountNumber";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(235, 72);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(317, 21);
            _txtName.TabIndex = 2;
            _txtName.Tag = "Supplier.Name";
            //
            // lblName
            //
            _lblName.Location = new Point(10, 75);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(96, 20);
            _lblName.TabIndex = 31;
            _lblName.Text = "Name";
            //
            // txtAddress1
            //
            _txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress1.Location = new Point(235, 152);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(317, 21);
            _txtAddress1.TabIndex = 4;
            _txtAddress1.Tag = "Supplier.Address1";
            //
            // lblAddress1
            //
            _lblAddress1.Location = new Point(10, 155);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(96, 20);
            _lblAddress1.TabIndex = 31;
            _lblAddress1.Text = "Address 1";
            //
            // txtAddress2
            //
            _txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress2.Location = new Point(235, 179);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(317, 21);
            _txtAddress2.TabIndex = 5;
            _txtAddress2.Tag = "Supplier.Address2";
            //
            // lblAddress2
            //
            _lblAddress2.Location = new Point(10, 182);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(96, 20);
            _lblAddress2.TabIndex = 31;
            _lblAddress2.Text = "Address 2";
            //
            // txtAddress3
            //
            _txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress3.Location = new Point(235, 206);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(317, 21);
            _txtAddress3.TabIndex = 6;
            _txtAddress3.Tag = "Supplier.Address3";
            //
            // lblAddress3
            //
            _lblAddress3.Location = new Point(10, 209);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(96, 20);
            _lblAddress3.TabIndex = 31;
            _lblAddress3.Text = "Address 3";
            //
            // txtAddress4
            //
            _txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress4.Location = new Point(235, 233);
            _txtAddress4.MaxLength = 255;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.Size = new Size(317, 21);
            _txtAddress4.TabIndex = 7;
            _txtAddress4.Tag = "Supplier.Town";
            //
            // lblTown
            //
            _lblTown.Location = new Point(10, 236);
            _lblTown.Name = "lblTown";
            _lblTown.Size = new Size(96, 20);
            _lblTown.TabIndex = 31;
            _lblTown.Text = "Address 4";
            //
            // txtAddress5
            //
            _txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress5.Location = new Point(235, 260);
            _txtAddress5.MaxLength = 255;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.Size = new Size(317, 21);
            _txtAddress5.TabIndex = 8;
            _txtAddress5.Tag = "Supplier.County";
            //
            // lblCounty
            //
            _lblCounty.Location = new Point(10, 263);
            _lblCounty.Name = "lblCounty";
            _lblCounty.Size = new Size(96, 20);
            _lblCounty.TabIndex = 31;
            _lblCounty.Text = "Address 5";
            //
            // txtPostcode
            //
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Location = new Point(235, 287);
            _txtPostcode.MaxLength = 20;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(317, 21);
            _txtPostcode.TabIndex = 9;
            _txtPostcode.Tag = "Supplier.Postcode";
            //
            // lblPostcode
            //
            _lblPostcode.Location = new Point(10, 290);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(96, 20);
            _lblPostcode.TabIndex = 31;
            _lblPostcode.Text = "Postcode";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(235, 314);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(317, 21);
            _txtTelephoneNum.TabIndex = 10;
            _txtTelephoneNum.Tag = "Supplier.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(10, 317);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(96, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Tel";
            //
            // txtFaxNum
            //
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(235, 341);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(317, 21);
            _txtFaxNum.TabIndex = 11;
            _txtFaxNum.Tag = "Supplier.FaxNum";
            //
            // lblFaxNum
            //
            _lblFaxNum.Location = new Point(10, 344);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(96, 20);
            _lblFaxNum.TabIndex = 31;
            _lblFaxNum.Text = "Fax";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(235, 368);
            _txtEmailAddress.MaxLength = 500;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(317, 21);
            _txtEmailAddress.TabIndex = 12;
            _txtEmailAddress.Tag = "Supplier.EmailAddress";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(10, 371);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(210, 20);
            _lblEmailAddress.TabIndex = 31;
            _lblEmailAddress.Text = "Email Address (comma seperated)";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNotes.Location = new Point(235, 422);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(317, 109);
            _txtNotes.TabIndex = 13;
            _txtNotes.Tag = "Supplier.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(10, 425);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(96, 20);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            //
            // Label2
            //
            _Label2.Location = new Point(10, 398);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(112, 20);
            _Label2.TabIndex = 35;
            _Label2.Text = "Gasway Account";
            //
            // Label1
            //
            _Label1.Location = new Point(10, 103);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(112, 20);
            _Label1.TabIndex = 33;
            _Label1.Text = "Account Number";
            //
            // UCSupplier
            //
            Controls.Add(_grpSupplier);
            Name = "UCSupplier";
            Size = new Size(582, 676);
            _grpSupplier.ResumeLayout(false);
            _grpSupplier.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentSupplier;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Suppliers.Supplier _currentSupplier;

        public Entity.Suppliers.Supplier CurrentSupplier
        {
            get
            {
                return _currentSupplier;
            }

            set
            {
                _currentSupplier = value;
                if (CurrentSupplier is null)
                {
                    CurrentSupplier = new Entity.Suppliers.Supplier();
                    CurrentSupplier.Exists = false;
                }

                if (CurrentSupplier.Exists)
                {
                    Populate();
                }
            }
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        
        

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentSupplier = App.DB.Supplier.Supplier_Get(ID);
            }

            txtAccountNumber.Text = CurrentSupplier.AccountNumber;
            txtSecondAccountNumber.Text = CurrentSupplier.SecondAccountNumber;
            txtName.Text = CurrentSupplier.Name;
            txtAddress1.Text = CurrentSupplier.Address1;
            txtAddress2.Text = CurrentSupplier.Address2;
            txtAddress3.Text = CurrentSupplier.Address3;
            txtAddress4.Text = CurrentSupplier.Address4;
            txtAddress5.Text = CurrentSupplier.Address5;
            txtPostcode.Text = CurrentSupplier.Postcode;
            txtTelephoneNum.Text = CurrentSupplier.TelephoneNum;
            txtFaxNum.Text = CurrentSupplier.FaxNum;
            txtEmailAddress.Text = CurrentSupplier.EmailAddress;
            txtGaswayAccount.Text = CurrentSupplier.GaswayAccount;
            txtNotes.Text = CurrentSupplier.Notes;
            txtNominal.Text = CurrentSupplier.DefaultNominal;
            if (!(Conversions.ToDouble(CurrentSupplier.MasterSupplierID) == 0))
            {
                Label4.Visible = true;
                chkSupplierBranch.Checked = true;
                var argcombo = cboMainSupplier;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentSupplier.MasterSupplierID);
            }

            if (Conversions.ToBoolean(CurrentSupplier.ReleaseToTablets) == true)
            {
                chkReleaseToTablets.Checked = true;
            }
            else
            {
                chkReleaseToTablets.Checked = false;
            }

            if (CurrentSupplier.SecondaryPrice == true)
            {
                chkSecondaryPrice.Checked = true;
            }
            else
            {
                chkSecondaryPrice.Checked = false;
            }

            chkSubContractor.Checked = CurrentSupplier.SubContractor;
            txtNominal.Text = CurrentSupplier.DefaultNominal;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentSupplier.IgnoreExceptionsOnSetMethods = true;
                CurrentSupplier.SetAccountNumber = txtAccountNumber.Text.Trim();
                CurrentSupplier.SetSecondAccountNumber = txtSecondAccountNumber.Text.Trim();
                CurrentSupplier.SetName = txtName.Text.Trim();
                CurrentSupplier.SetAddress1 = txtAddress1.Text.Trim();
                CurrentSupplier.SetAddress2 = txtAddress2.Text.Trim();
                CurrentSupplier.SetAddress3 = txtAddress3.Text.Trim();
                CurrentSupplier.SetAddress4 = txtAddress4.Text.Trim();
                CurrentSupplier.SetAddress5 = txtAddress5.Text.Trim();
                CurrentSupplier.SetPostcode = txtPostcode.Text.Trim();
                CurrentSupplier.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentSupplier.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentSupplier.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentSupplier.SetGaswayAccount = txtGaswayAccount.Text;
                CurrentSupplier.SetNotes = txtNotes.Text.Trim();
                CurrentSupplier.SetDefaultNominal = txtNominal.Text.Trim();
                if (!chkSupplierBranch.Checked)
                {
                    CurrentSupplier.SetMasterSupplierID = 0;
                }
                else
                {
                    CurrentSupplier.SetMasterSupplierID = Combo.get_GetSelectedItemValue(cboMainSupplier);
                }

                if (chkReleaseToTablets.Checked)
                {
                    CurrentSupplier.SetReleaseToTablets = true;
                }
                else
                {
                    CurrentSupplier.SetReleaseToTablets = false;
                }

                CurrentSupplier.SecondaryPrice = chkSecondaryPrice.Checked;
                CurrentSupplier.SetSubContractor = chkSubContractor.Checked;
                var cV = new Entity.Suppliers.SupplierValidator();
                cV.Validate(CurrentSupplier);
                if (CurrentSupplier.Exists)
                {
                    App.DB.Supplier.Update(CurrentSupplier);
                }
                else
                {
                    CurrentSupplier = App.DB.Supplier.Insert(CurrentSupplier);
                }

                Populate(CurrentSupplier.SupplierID);
                RecordsChanged?.Invoke(App.DB.Supplier.Supplier_GetAll(), Entity.Sys.Enums.PageViewing.Supplier, true, false, "");
                StateChanged?.Invoke(CurrentSupplier.SupplierID);
                App.MainForm.RefreshEntity(CurrentSupplier.SupplierID);
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

        private void chkSupplierBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplierBranch.Checked)
            {
                cboMainSupplier.Visible = true;
                Label4.Visible = true;
            }
            else
            {
                cboMainSupplier.Visible = false;
                Label4.Visible = false;
            }
        }

        private void chkSecondaryPrice_CheckedChanged(object sender, EventArgs e)
        {
            txtSecondAccountNumber.Visible = chkSecondaryPrice.Checked;
            lblSecondAccount.Visible = chkSecondaryPrice.Checked;
        }

        
    }
}