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
    public class UCEquipment : UCBase, IUserControl
    {
        public UCEquipment() : base()
        {
            base.Load += UCEqupment_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboEquipmentType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EquipmentType).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            // Combo.SetUpCombo(Me.cboEquipmentType, DynamicDataTables.EquipmentType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

            var argc1 = cboStatus;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EquipmentStatus).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private TabControl _tcVans;

        private TabPage _tabDetails;

        internal TabPage tabDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDetails != null)
                {
                }

                _tabDetails = value;
                if (_tabDetails != null)
                {
                }
            }
        }

        private GroupBox _grpVan;

        private TextBox _txtDecription;

        internal TextBox txtDecription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDecription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDecription != null)
                {
                }

                _txtDecription = value;
                if (_txtDecription != null)
                {
                }
            }
        }

        private Label _lblRegistration;

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

        private DateTimePicker _dtpCalibrationDate;

        internal DateTimePicker dtpCalibrationDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpCalibrationDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpCalibrationDate != null)
                {
                    _dtpCalibrationDate.ValueChanged -= dtpCalibrationDate_ValueChanged;
                }

                _dtpCalibrationDate = value;
                if (_dtpCalibrationDate != null)
                {
                    _dtpCalibrationDate.ValueChanged += dtpCalibrationDate_ValueChanged;
                }
            }
        }

        private Label _lblInsuranceDue;

        private DateTimePicker _dtpWarrantyExpires;

        internal DateTimePicker dtpWarrantyExpires
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpWarrantyExpires;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpWarrantyExpires != null)
                {
                }

                _dtpWarrantyExpires = value;
                if (_dtpWarrantyExpires != null)
                {
                }
            }
        }

        private Label _lblMOTDue;

        private Label _lblTaxDue;

        private Label _lblAssetId;

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
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
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

        private TextBox _txtCallibrationPeriod;

        internal TextBox txtCallibrationPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCallibrationPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCallibrationPeriod != null)
                {
                }

                _txtCallibrationPeriod = value;
                if (_txtCallibrationPeriod != null)
                {
                }
            }
        }

        private Button _btnfindEngineer;

        private TextBox _txtEngineer;

        internal TextBox txtEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineer != null)
                {
                }

                _txtEngineer = value;
                if (_txtEngineer != null)
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

        private TextBox _txtCalibrationCert;

        internal TextBox txtCalibrationCert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCalibrationCert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCalibrationCert != null)
                {
                }

                _txtCalibrationCert = value;
                if (_txtCalibrationCert != null)
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

        private ComboBox _cboEquipmentType;

        internal ComboBox cboEquipmentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEquipmentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEquipmentType != null)
                {
                }

                _cboEquipmentType = value;
                if (_cboEquipmentType != null)
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

        private TextBox _txtSerialNo;

        internal TextBox txtSerialNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSerialNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSerialNo != null)
                {
                }

                _txtSerialNo = value;
                if (_txtSerialNo != null)
                {
                }
            }
        }

        private TabPage _tabHistory;

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

        private TextBox _txtAssetNumber;

        internal TextBox txtAssetNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAssetNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAssetNumber != null)
                {
                }

                _txtAssetNumber = value;
                if (_txtAssetNumber != null)
                {
                }
            }
        }

        private DataGrid _dgEquipmentAudits;

        internal DataGrid dgEquipmentAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEquipmentAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEquipmentAudits != null)
                {
                }

                _dgEquipmentAudits = value;
                if (_dgEquipmentAudits != null)
                {
                }
            }
        }

        private Label _lblCalibrationStatus;

        internal Label lblCalibrationStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCalibrationStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCalibrationStatus != null)
                {
                }

                _lblCalibrationStatus = value;
                if (_lblCalibrationStatus != null)
                {
                }
            }
        }

        private TabPage _tabDocuments;

        internal TabPage tabDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDocuments != null)
                {
                }

                _tabDocuments = value;
                if (_tabDocuments != null)
                {
                }
            }
        }

        private Button _btnUnassign;

        private TabPage _tabGenerateWO;

        private GroupBox _grpWorkOrder;

        private TextBox _txtFaults;

        internal TextBox txtFaults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaults != null)
                {
                }

                _txtFaults = value;
                if (_txtFaults != null)
                {
                }
            }
        }

        private Label _lblFaults;

        private Button _btnGenerate;

        private TextBox _txtEmail;

        internal TextBox txtEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmail != null)
                {
                }

                _txtEmail = value;
                if (_txtEmail != null)
                {
                }
            }
        }

        private Label _lblEmail;

        private Button _btnGenerateAndEmail;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tcVans = new TabControl();
            _tabDetails = new TabPage();
            _grpVan = new GroupBox();
            _btnUnassign = new Button();
            _btnUnassign.Click += new EventHandler(btnUnassign_Click);
            _lblCalibrationStatus = new Label();
            _txtAssetNumber = new TextBox();
            _txtSerialNo = new TextBox();
            _Label6 = new Label();
            _cboEquipmentType = new ComboBox();
            _Label4 = new Label();
            _txtCalibrationCert = new TextBox();
            _Label3 = new Label();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click_1);
            _txtEngineer = new TextBox();
            _Label5 = new Label();
            _cboStatus = new ComboBox();
            _cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _Label1 = new Label();
            _txtCallibrationPeriod = new TextBox();
            _Label2 = new Label();
            _txtDecription = new TextBox();
            _lblRegistration = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _dtpCalibrationDate = new DateTimePicker();
            _dtpCalibrationDate.ValueChanged += new EventHandler(dtpCalibrationDate_ValueChanged);
            _lblInsuranceDue = new Label();
            _dtpWarrantyExpires = new DateTimePicker();
            _lblMOTDue = new Label();
            _lblTaxDue = new Label();
            _lblAssetId = new Label();
            _tabHistory = new TabPage();
            _GroupBox1 = new GroupBox();
            _dgEquipmentAudits = new DataGrid();
            _tabDocuments = new TabPage();
            _tabGenerateWO = new TabPage();
            _grpWorkOrder = new GroupBox();
            _txtEmail = new TextBox();
            _lblEmail = new Label();
            _btnGenerateAndEmail = new Button();
            _btnGenerateAndEmail.Click += new EventHandler(btnGenerateAndEmail_Click);
            _btnGenerate = new Button();
            _btnGenerate.Click += new EventHandler(btnGenerate_Click);
            _txtFaults = new TextBox();
            _lblFaults = new Label();
            _tcVans.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpVan.SuspendLayout();
            _tabHistory.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipmentAudits).BeginInit();
            _tabGenerateWO.SuspendLayout();
            _grpWorkOrder.SuspendLayout();
            SuspendLayout();
            //
            // tcVans
            //
            _tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcVans.Controls.Add(_tabDetails);
            _tcVans.Controls.Add(_tabHistory);
            _tcVans.Controls.Add(_tabDocuments);
            _tcVans.Controls.Add(_tabGenerateWO);
            _tcVans.Location = new Point(3, 7);
            _tcVans.Name = "tcVans";
            _tcVans.SelectedIndex = 0;
            _tcVans.Size = new Size(683, 670);
            _tcVans.TabIndex = 14;
            //
            // tabDetails
            //
            _tabDetails.Controls.Add(_grpVan);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(675, 644);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            //
            // grpVan
            //
            _grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVan.Controls.Add(_btnUnassign);
            _grpVan.Controls.Add(_lblCalibrationStatus);
            _grpVan.Controls.Add(_txtAssetNumber);
            _grpVan.Controls.Add(_txtSerialNo);
            _grpVan.Controls.Add(_Label6);
            _grpVan.Controls.Add(_cboEquipmentType);
            _grpVan.Controls.Add(_Label4);
            _grpVan.Controls.Add(_txtCalibrationCert);
            _grpVan.Controls.Add(_Label3);
            _grpVan.Controls.Add(_btnfindEngineer);
            _grpVan.Controls.Add(_txtEngineer);
            _grpVan.Controls.Add(_Label5);
            _grpVan.Controls.Add(_cboStatus);
            _grpVan.Controls.Add(_Label1);
            _grpVan.Controls.Add(_txtCallibrationPeriod);
            _grpVan.Controls.Add(_Label2);
            _grpVan.Controls.Add(_txtDecription);
            _grpVan.Controls.Add(_lblRegistration);
            _grpVan.Controls.Add(_txtNotes);
            _grpVan.Controls.Add(_lblNotes);
            _grpVan.Controls.Add(_dtpCalibrationDate);
            _grpVan.Controls.Add(_lblInsuranceDue);
            _grpVan.Controls.Add(_dtpWarrantyExpires);
            _grpVan.Controls.Add(_lblMOTDue);
            _grpVan.Controls.Add(_lblTaxDue);
            _grpVan.Controls.Add(_lblAssetId);
            _grpVan.Location = new Point(8, 8);
            _grpVan.Name = "grpVan";
            _grpVan.Size = new Size(664, 631);
            _grpVan.TabIndex = 200;
            _grpVan.TabStop = false;
            _grpVan.Text = "Details";
            //
            // btnUnassign
            //
            _btnUnassign.BackColor = Color.White;
            _btnUnassign.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnUnassign.Location = new Point(447, 278);
            _btnUnassign.Name = "btnUnassign";
            _btnUnassign.Size = new Size(82, 23);
            _btnUnassign.TabIndex = 472;
            _btnUnassign.Text = "Un-assign";
            _btnUnassign.UseVisualStyleBackColor = false;
            //
            // lblCalibrationStatus
            //
            _lblCalibrationStatus.Location = new Point(382, 118);
            _lblCalibrationStatus.Name = "lblCalibrationStatus";
            _lblCalibrationStatus.Size = new Size(136, 20);
            _lblCalibrationStatus.TabIndex = 471;
            _lblCalibrationStatus.Text = "[Calibration Status]";
            //
            // txtAssetNumber
            //
            _txtAssetNumber.Location = new Point(175, 252);
            _txtAssetNumber.MaxLength = 9;
            _txtAssetNumber.Name = "txtAssetNumber";
            _txtAssetNumber.Size = new Size(201, 21);
            _txtAssetNumber.TabIndex = 9;
            //
            // txtSerialNo
            //
            _txtSerialNo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtSerialNo.Location = new Point(175, 88);
            _txtSerialNo.MaxLength = 20;
            _txtSerialNo.Name = "txtSerialNo";
            _txtSerialNo.Size = new Size(373, 21);
            _txtSerialNo.TabIndex = 3;
            _txtSerialNo.Tag = "Van.Registration";
            //
            // Label6
            //
            _Label6.Location = new Point(8, 90);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(144, 20);
            _Label6.TabIndex = 470;
            _Label6.Text = "Serial No.";
            //
            // cboEquipmentType
            //
            _cboEquipmentType.Cursor = Cursors.Hand;
            _cboEquipmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEquipmentType.FormattingEnabled = true;
            _cboEquipmentType.Location = new Point(175, 33);
            _cboEquipmentType.Name = "cboEquipmentType";
            _cboEquipmentType.Size = new Size(201, 21);
            _cboEquipmentType.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 35);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(136, 20);
            _Label4.TabIndex = 440;
            _Label4.Text = "Type of Equipment";
            //
            // txtCalibrationCert
            //
            _txtCalibrationCert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCalibrationCert.Location = new Point(175, 170);
            _txtCalibrationCert.MaxLength = 20;
            _txtCalibrationCert.Name = "txtCalibrationCert";
            _txtCalibrationCert.Size = new Size(373, 21);
            _txtCalibrationCert.TabIndex = 6;
            _txtCalibrationCert.Tag = "Van.Registration";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 173);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(161, 20);
            _Label3.TabIndex = 43;
            _Label3.Text = "Calibration Certificate";
            //
            // btnfindEngineer
            //
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(409, 278);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 11;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtEngineer
            //
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(175, 279);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(228, 21);
            _txtEngineer.TabIndex = 10;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 282);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(70, 16);
            _Label5.TabIndex = 410;
            _Label5.Text = "Engineer";
            //
            // cboStatus
            //
            _cboStatus.Cursor = Cursors.Hand;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.FormattingEnabled = true;
            _cboStatus.Location = new Point(175, 226);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(201, 21);
            _cboStatus.TabIndex = 8;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 146);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(163, 20);
            _Label1.TabIndex = 370;
            _Label1.Text = "Calibration Period (Months)";
            //
            // txtCallibrationPeriod
            //
            _txtCallibrationPeriod.Location = new Point(175, 142);
            _txtCallibrationPeriod.MaxLength = 9;
            _txtCallibrationPeriod.Name = "txtCallibrationPeriod";
            _txtCallibrationPeriod.Size = new Size(43, 21);
            _txtCallibrationPeriod.TabIndex = 5;
            _txtCallibrationPeriod.Text = "12";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 278);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(136, 20);
            _Label2.TabIndex = 340;
            //
            // txtDecription
            //
            _txtDecription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtDecription.Location = new Point(175, 61);
            _txtDecription.MaxLength = 20;
            _txtDecription.Name = "txtDecription";
            _txtDecription.Size = new Size(373, 21);
            _txtDecription.TabIndex = 2;
            _txtDecription.Tag = "Van.Registration";
            //
            // lblRegistration
            //
            _lblRegistration.Location = new Point(8, 64);
            _lblRegistration.Name = "lblRegistration";
            _lblRegistration.Size = new Size(144, 20);
            _lblRegistration.TabIndex = 310;
            _lblRegistration.Text = "Description";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(175, 321);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(467, 259);
            _txtNotes.TabIndex = 12;
            _txtNotes.Tag = "Van.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(8, 324);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(53, 20);
            _lblNotes.TabIndex = 310;
            _lblNotes.Text = "Notes";
            //
            // dtpCalibrationDate
            //
            _dtpCalibrationDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpCalibrationDate.Location = new Point(175, 115);
            _dtpCalibrationDate.Name = "dtpCalibrationDate";
            _dtpCalibrationDate.Size = new Size(201, 21);
            _dtpCalibrationDate.TabIndex = 4;
            _dtpCalibrationDate.Tag = "Van.InsuranceDue";
            //
            // lblInsuranceDue
            //
            _lblInsuranceDue.Location = new Point(8, 121);
            _lblInsuranceDue.Name = "lblInsuranceDue";
            _lblInsuranceDue.Size = new Size(136, 20);
            _lblInsuranceDue.TabIndex = 31;
            _lblInsuranceDue.Text = "Calibration Date";
            //
            // dtpWarrantyExpires
            //
            _dtpWarrantyExpires.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpWarrantyExpires.Location = new Point(175, 200);
            _dtpWarrantyExpires.Name = "dtpWarrantyExpires";
            _dtpWarrantyExpires.Size = new Size(201, 21);
            _dtpWarrantyExpires.TabIndex = 7;
            _dtpWarrantyExpires.Tag = "Van.MOTDue";
            //
            // lblMOTDue
            //
            _lblMOTDue.Location = new Point(8, 201);
            _lblMOTDue.Name = "lblMOTDue";
            _lblMOTDue.Size = new Size(114, 20);
            _lblMOTDue.TabIndex = 310;
            _lblMOTDue.Text = "Warranty Expires";
            //
            // lblTaxDue
            //
            _lblTaxDue.Location = new Point(8, 228);
            _lblTaxDue.Name = "lblTaxDue";
            _lblTaxDue.Size = new Size(64, 20);
            _lblTaxDue.TabIndex = 31;
            _lblTaxDue.Text = "Status";
            //
            // lblAssetId
            //
            _lblAssetId.Location = new Point(8, 255);
            _lblAssetId.Name = "lblAssetId";
            _lblAssetId.Size = new Size(123, 20);
            _lblAssetId.TabIndex = 310;
            _lblAssetId.Text = "Asset Number";
            //
            // tabHistory
            //
            _tabHistory.BackColor = SystemColors.Control;
            _tabHistory.Controls.Add(_GroupBox1);
            _tabHistory.Location = new Point(4, 22);
            _tabHistory.Name = "tabHistory";
            _tabHistory.Size = new Size(675, 644);
            _tabHistory.TabIndex = 10;
            _tabHistory.Text = "History";
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgEquipmentAudits);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(664, 631);
            _GroupBox1.TabIndex = 3;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Equipment Audit";
            //
            // dgEquipmentAudits
            //
            _dgEquipmentAudits.DataMember = "";
            _dgEquipmentAudits.Dock = DockStyle.Fill;
            _dgEquipmentAudits.HeaderForeColor = SystemColors.ControlText;
            _dgEquipmentAudits.Location = new Point(3, 17);
            _dgEquipmentAudits.Name = "dgEquipmentAudits";
            _dgEquipmentAudits.Size = new Size(658, 611);
            _dgEquipmentAudits.TabIndex = 15;
            //
            // tabDocuments
            //
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(675, 644);
            _tabDocuments.TabIndex = 11;
            _tabDocuments.Text = "Documents";
            _tabDocuments.UseVisualStyleBackColor = true;
            //
            // tabGenerateWO
            //
            _tabGenerateWO.Controls.Add(_grpWorkOrder);
            _tabGenerateWO.Location = new Point(4, 22);
            _tabGenerateWO.Name = "tabGenerateWO";
            _tabGenerateWO.Size = new Size(675, 644);
            _tabGenerateWO.TabIndex = 12;
            _tabGenerateWO.Text = "Generate WO";
            _tabGenerateWO.UseVisualStyleBackColor = true;
            //
            // grpWorkOrder
            //
            _grpWorkOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpWorkOrder.BackColor = SystemColors.Control;
            _grpWorkOrder.Controls.Add(_txtEmail);
            _grpWorkOrder.Controls.Add(_lblEmail);
            _grpWorkOrder.Controls.Add(_btnGenerateAndEmail);
            _grpWorkOrder.Controls.Add(_btnGenerate);
            _grpWorkOrder.Controls.Add(_txtFaults);
            _grpWorkOrder.Controls.Add(_lblFaults);
            _grpWorkOrder.Location = new Point(5, 7);
            _grpWorkOrder.Name = "grpWorkOrder";
            _grpWorkOrder.Size = new Size(664, 262);
            _grpWorkOrder.TabIndex = 4;
            _grpWorkOrder.TabStop = false;
            _grpWorkOrder.Text = "Equipment Work Order";
            //
            // txtEmail
            //
            _txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmail.Location = new Point(105, 164);
            _txtEmail.MaxLength = 256;
            _txtEmail.Name = "txtEmail";
            _txtEmail.Size = new Size(542, 21);
            _txtEmail.TabIndex = 475;
            _txtEmail.Tag = "Van.Registration";
            //
            // lblEmail
            //
            _lblEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblEmail.Location = new Point(6, 167);
            _lblEmail.Name = "lblEmail";
            _lblEmail.Size = new Size(85, 20);
            _lblEmail.TabIndex = 476;
            _lblEmail.Text = "Email";
            //
            // btnGenerateAndEmail
            //
            _btnGenerateAndEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnGenerateAndEmail.BackColor = Color.White;
            _btnGenerateAndEmail.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnGenerateAndEmail.Location = new Point(495, 213);
            _btnGenerateAndEmail.Name = "btnGenerateAndEmail";
            _btnGenerateAndEmail.Size = new Size(152, 33);
            _btnGenerateAndEmail.TabIndex = 474;
            _btnGenerateAndEmail.Text = "Generate And Email";
            _btnGenerateAndEmail.UseVisualStyleBackColor = false;
            //
            // btnGenerate
            //
            _btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnGenerate.BackColor = Color.White;
            _btnGenerate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnGenerate.Location = new Point(6, 213);
            _btnGenerate.Name = "btnGenerate";
            _btnGenerate.Size = new Size(152, 33);
            _btnGenerate.TabIndex = 473;
            _btnGenerate.Text = "Generate";
            _btnGenerate.UseVisualStyleBackColor = false;
            //
            // txtFaults
            //
            _txtFaults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtFaults.Location = new Point(105, 25);
            _txtFaults.Multiline = true;
            _txtFaults.Name = "txtFaults";
            _txtFaults.ScrollBars = ScrollBars.Vertical;
            _txtFaults.Size = new Size(542, 105);
            _txtFaults.TabIndex = 311;
            _txtFaults.Tag = "";
            //
            // lblFaults
            //
            _lblFaults.Location = new Point(6, 28);
            _lblFaults.Name = "lblFaults";
            _lblFaults.Size = new Size(53, 20);
            _lblFaults.TabIndex = 312;
            _lblFaults.Text = "Faults";
            //
            // UCEquipment
            //
            Controls.Add(_tcVans);
            Name = "UCEquipment";
            Size = new Size(693, 680);
            _tcVans.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpVan.ResumeLayout(false);
            _grpVan.PerformLayout();
            _tabHistory.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEquipmentAudits).EndInit();
            _tabGenerateWO.ResumeLayout(false);
            _grpWorkOrder.ResumeLayout(false);
            _grpWorkOrder.PerformLayout();
            ResumeLayout(false);
        }

        private UCDocumentsList DocumentsControl;

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupDataGrid();
            // SetupPartsDatagrid()
            // SetupProductsDatagrid()
            // SetupWarehousesDatagrid()
            // SetupPartsDataGridView()
            // Me.dgParts.ReadOnly = False
        }

        public object LoadedItem
        {
            get
            {
                return CurrentEquipment;
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        // Private _currentVan As Entity.Vans.Van
        // Public Property CurrentVan() As Entity.Vans.Van
        // Get
        // Return _currentVan
        // End Get
        // Set(ByVal Value As Entity.Vans.Van)
        // _currentVan = Value

        // If CurrentVan Is Nothing Then
        // CurrentVan = New Entity.Vans.Van
        // CurrentVan.Exists = False
        // End If

        // If CurrentVan.Exists Then
        // 'Populate()
        // Me.btnEngineerHistory.Enabled = True
        // Else
        // WarehousesDataView = DB.Warehouse.Warehouse_GetAll_For_Van2(0)
        // Me.btnEngineerHistory.Enabled = False
        // End If
        // End Set
        // End Property

        private int CurrentStatus = 0;
        private Entity.Engineers.Equipment _currentEquipment;

        public Entity.Engineers.Equipment CurrentEquipment
        {
            get
            {
                return _currentEquipment;
            }

            set
            {
                _currentEquipment = value;
                if (CurrentEquipment is null)
                {
                    CurrentEquipment = new Entity.Engineers.Equipment();
                    CurrentEquipment.Exists = false;
                }

                if (CurrentEquipment.Exists)
                {
                    Populate();
                    tabDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Entity.Sys.Enums.TableNames.tblEquipment, CurrentEquipment.EquipmentID);
                    tabDocuments.Controls.Add(DocumentsControl);
                }
                else
                {
                }
            }
        }

        private Entity.Engineers.Engineer _theEngineer;

        public Entity.Engineers.Engineer theEngineer
        {
            get
            {
                return _theEngineer;
            }

            set
            {
                _theEngineer = value;
                if (_theEngineer is object)
                {
                    txtEngineer.Text = theEngineer.Name;
                }
                else
                {
                    txtEngineer.Text = "";
                }
            }
        }

        private DataView _dvEquipmentAudits;

        private DataView EquipmentAuditsDataview
        {
            get
            {
                return _dvEquipmentAudits;
            }

            set
            {
                _dvEquipmentAudits = value;
                _dvEquipmentAudits.AllowNew = false;
                _dvEquipmentAudits.AllowEdit = false;
                _dvEquipmentAudits.AllowDelete = false;
                _dvEquipmentAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString();
                dgEquipmentAudits.DataSource = EquipmentAuditsDataview;
            }
        }

        private void SetupDataGrid()
        {
            var tStyle = dgEquipmentAudits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Action";
            Name.MappingName = "ActionChange";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Date";
            Site.MappingName = "ActionDateTime";
            Site.ReadOnly = true;
            Site.Width = 200;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "User";
            Type.MappingName = "Fullname";
            Type.ReadOnly = true;
            Type.Width = 200;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString();
            dgEquipmentAudits.TableStyles.Add(tStyle);
        }

        private void UCEqupment_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        // Private Sub dgParts_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgParts.CurrentCellChanged
        // If SelectedPartDataRow Is Nothing Then
        // Exit Sub
        // End If

        // 'update the row

        // Dim RecordID As Integer = 0
        // RecordID = SelectedPartDataRow.Item("MinMaxID")

        // End Sub

        // Private Sub dgvParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvParts.DoubleClick
        // If Me.dgvParts.CurrentRow Is Nothing Then
        // Exit Sub
        // End If
        // ShowForm(GetType(FRMPart), True, New Object() {Me.dgvParts.CurrentRow.Cells(7).Value, True})
        // PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))
        // End Sub

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                DisableControls();
                CurrentEquipment = App.DB.Engineer.Equipment_Get(ID);
                theEngineer = App.DB.Engineer.Engineer_Get(CurrentEquipment.EngineerID);
                if (theEngineer is null)
                {
                    txtEngineer.Text = "<Not Set>";
                }
                else if (theEngineer.EngineerID == 0)
                {
                    txtEngineer.Text = "<Not Set>";
                }
                else
                {
                    txtEngineer.Text = theEngineer.Name;
                }

                // check if unit is out of calibration
                if (!IsEquipmentCalibrationValid(CurrentEquipment.CalibrationDate, Conversions.ToInteger(CurrentEquipment.CalibrationMonths)) & CurrentEquipment.StatusID != (int)Entity.Sys.Enums.EquipmentStatus.OutOfCalibration)
                {
                    lblCalibrationStatus.Text = "Out of calibration";
                    lblCalibrationStatus.ForeColor = Color.Red;
                }
                else
                {
                    lblCalibrationStatus.Text = "Still in Calibration";
                    lblCalibrationStatus.ForeColor = Color.Green;
                }

                txtNotes.Text = CurrentEquipment.Notes;
                txtAssetNumber.Text = CurrentEquipment.AssetNo;
                txtCallibrationPeriod.Text = CurrentEquipment.CalibrationMonths.ToString();
                txtCalibrationCert.Text = CurrentEquipment.CertificateNumber;
                var argcombo = cboEquipmentType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentEquipment.EquipmentTypeID.ToString());
                dtpCalibrationDate.Value = CurrentEquipment.CalibrationDate;
                dtpWarrantyExpires.Value = CurrentEquipment.WarrantyEndDate;
                txtDecription.Text = CurrentEquipment.Name;
                txtSerialNo.Text = CurrentEquipment.SerialNumber;
                var argcombo1 = cboStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentEquipment.StatusID.ToString());
                CurrentStatus = CurrentEquipment.StatusID;
                PopulateEquipmentAuditDatagrid();
            }
        }

        private void PopulateEquipmentAuditDatagrid()
        {
            try
            {
                EquipmentAuditsDataview = App.DB.Engineer.EquipmentAudit_Get(CurrentEquipment.EquipmentID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisableControls()
        {
            Entity.Sys.Enums.SecuritySystemModules ssm;
            ssm = Entity.Sys.Enums.SecuritySystemModules.Equipment;
            if (App.loggedInUser.HasAccessToModule(ssm) == false)
            {
                cboEquipmentType.Enabled = false;
                txtDecription.Enabled = false;
                txtSerialNo.Enabled = false;
                dtpCalibrationDate.Enabled = false;
                txtCallibrationPeriod.Enabled = false;
                txtCalibrationCert.Enabled = false;
                dtpWarrantyExpires.Enabled = false;
                txtAssetNumber.Enabled = false;
            }
        }

        public bool Save()
        {
            try
            {
                if (txtCallibrationPeriod.Text.Length == 0)
                {
                    App.ShowMessage("Please enter a calibration period", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }

                if (!Information.IsNumeric(txtCallibrationPeriod.Text))
                {
                    App.ShowMessage("The Calibration Period Must be a Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }

                if (txtDecription.Text.Length == 0)
                {
                    App.ShowMessage("You Must give this Equipment a Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEquipmentType)) == 0)
                {
                    App.ShowMessage("Please select a Staus and Equipment Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }

                Cursor = Cursors.WaitCursor;
                CurrentEquipment.IgnoreExceptionsOnSetMethods = true;
                string change = UpdateAudit();
                if (theEngineer is null)
                {
                    CurrentEquipment.SetEngineerID = 0;
                }
                else if (theEngineer.EngineerID == 0)
                {
                    CurrentEquipment.SetEngineerID = 0;
                }
                else
                {
                    CurrentEquipment.SetEngineerID = theEngineer.EngineerID;
                }

                {
                    var withBlock = CurrentEquipment;
                    withBlock.StatusChangeDate = DateTime.Now;
                    withBlock.SetNotes = txtNotes.Text.Trim();
                    withBlock.SetCalibrationMonths = txtCallibrationPeriod.Text;
                    withBlock.SetCertificateNumber = txtCalibrationCert.Text;
                    withBlock.SetEquipmentTypeID = Combo.get_GetSelectedItemValue(cboEquipmentType);
                    withBlock.CalibrationDate = dtpCalibrationDate.Value;
                    withBlock.SetAssetNo = txtAssetNumber.Text;
                    withBlock.WarrantyEndDate = dtpWarrantyExpires.Value;
                    withBlock.SetName = txtDecription.Text;
                    withBlock.SetSerialNumber = txtSerialNo.Text;
                    withBlock.SetStatusID = Combo.get_GetSelectedItemValue(cboStatus);
                }

                if (CurrentEquipment.Exists)
                {
                    App.DB.Engineer.EquipmentUpdate(CurrentEquipment);
                }
                else
                {
                    CurrentEquipment = App.DB.Engineer.EquipmentInsert(CurrentEquipment);
                }

                if (!string.IsNullOrEmpty(change))
                    App.DB.Engineer.EquipmentAudit_Insert(CurrentEquipment.EquipmentID, change);
                RecordsChanged?.Invoke(App.DB.Engineer.Equipment_GetAll(), Entity.Sys.Enums.PageViewing.Equipment, true, false, "");
                StateChanged?.Invoke(CurrentEquipment.EquipmentID);
                App.MainForm.RefreshEntity(CurrentEquipment.EquipmentID);
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

        /// <summary>
        /// Check what has been changed and add it to log
        /// </summary>
        /// <returns></returns>
        private string UpdateAudit()
        {
            // we need to see whats different

            bool update = false;
            string change = "";
            {
                var withBlock = CurrentEquipment;
                if (withBlock.EquipmentID > 0)
                {
                    if (withBlock.EquipmentTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEquipmentType)))
                    {
                        update = true;
                        change += "Equipment type changed from: " + App.DB.Picklists.Get_One_As_Object(withBlock.EquipmentTypeID).Name + " to: " + App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboEquipmentType))).Name;
                    }

                    if ((withBlock.Name ?? "") != (txtDecription.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Name changed from: " + withBlock.Name + " to: " + txtDecription.Text;
                    }

                    if ((withBlock.SerialNumber ?? "") != (txtSerialNo.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Serial number changed from: " + withBlock.SerialNumber + " to: " + txtSerialNo.Text;
                    }

                    if (withBlock.CalibrationDate != dtpCalibrationDate.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Calibration date changed from: " + withBlock.EquipmentTypeID + " to: " + dtpCalibrationDate.Value;
                    }

                    if (withBlock.CalibrationMonths != Conversions.ToDouble(txtCallibrationPeriod.Text))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Calibration period changed from: " + withBlock.CalibrationMonths + " to: " + txtCallibrationPeriod.Text;
                    }

                    if ((withBlock.CertificateNumber ?? "") != (txtCalibrationCert.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Certifcate changed from: " + withBlock.CertificateNumber + " to: " + txtCalibrationCert.Text;
                    }

                    if (withBlock.WarrantyEndDate != dtpWarrantyExpires.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Warranty end date changed from: " + withBlock.WarrantyEndDate + " to: " + dtpWarrantyExpires.Value;
                    }

                    if (withBlock.StatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Status changed from: " + App.DB.Picklists.Get_One_As_Object(withBlock.StatusID).Name + " to: " + App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus))).Name;
                    }

                    if ((withBlock.AssetNo ?? "") != (txtAssetNumber.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Asset number changed from: " + withBlock.AssetNo + " to: " + txtAssetNumber.Text;
                    }

                    if (theEngineer is null & withBlock.EngineerID > 0)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Equipment un-assigned from: " + App.DB.Engineer.Engineer_Get(withBlock.EngineerID).Name;
                    }
                    else if (theEngineer is object)
                    {
                        if (withBlock.EngineerID != theEngineer.EngineerID)
                        {
                            if (update)
                            {
                                change += ", ";
                            }

                            update = true;
                            if (withBlock.EngineerID == 0)
                            {
                                change += "Engineer added: " + theEngineer.Name;
                            }
                            else
                            {
                                change += "Engineer changed from: " + App.DB.Engineer.Engineer_Get(withBlock.EngineerID).Name + " to: " + theEngineer.Name;
                            }
                        }
                    }

                    if ((withBlock.Notes ?? "") != (txtNotes.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Notes were updated";
                    }
                }
            }

            return change;
        }

        private void btnfindEngineer_Click_1(object sender, EventArgs e)
        {
            if (IsEquipmentCalibrationValid(dtpCalibrationDate.Value, Conversions.ToInteger(txtCallibrationPeriod.Text)))
            {
                int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineer));
                if (!(ID == 0))
                {
                    theEngineer = App.DB.Engineer.Engineer_Get(ID);
                    var argcombo = cboStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.EquipmentStatus.IssedToEngineer).ToString());
                }
            }
            else
            {
                App.ShowMessage("Equipment is out calibration, please update date before assigning to engineer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check to see if equipment calibration is still vali
        /// </summary>
        /// <param name="caliDate"></param>
        /// <param name="caliPeriod"></param>
        /// <returns>True if valid</returns>
        public bool IsEquipmentCalibrationValid(DateTime caliDate, int caliMonths)
        {
            if (caliMonths == 0)
                caliMonths = 12; // default to 12 months calibration period
            return caliDate.AddMonths(caliMonths) > DateTime.Now;
        }

        private void dtpCalibrationDate_ValueChanged(object sender, EventArgs e)
        {
            // check if unit is out of calibration
            if (IsEquipmentCalibrationValid(dtpCalibrationDate.Value, Conversions.ToInteger(CurrentEquipment.CalibrationMonths)))
            {
                lblCalibrationStatus.Text = "Still in Calibration";
                lblCalibrationStatus.ForeColor = Color.Green;
            }
            else
            {
                lblCalibrationStatus.Text = "Out of calibration";
                lblCalibrationStatus.ForeColor = Color.Red;
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check if unit is out of calibration
            if (!IsEquipmentCalibrationValid(dtpCalibrationDate.Value, Conversions.ToInteger(txtCallibrationPeriod.Text)))
            {
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == (double)Entity.Sys.Enums.EquipmentStatus.ReadyForIssue | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == (double)Entity.Sys.Enums.EquipmentStatus.IssedToEngineer)
                {
                    App.ShowMessage("Equipment is out calibration, please update date before assigning to engineer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CurrentEquipment.SetStatusID = Conversions.ToInteger(Entity.Sys.Enums.EquipmentStatus.OutOfCalibration);
                    var argcombo = cboStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentEquipment.StatusID.ToString());
                }
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == (double)Entity.Sys.Enums.EquipmentStatus.ReadyForIssue)
            {
                if (theEngineer is object)
                    theEngineer = null;
                txtEngineer.Text = "<Not Set>";
            }
        }

        private void btnUnassign_Click(object sender, EventArgs e)
        {
            if (theEngineer is object)
                theEngineer = null;
            txtEngineer.Text = "<Not Set>";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CurrentEquipment is null)
                return;
            if (!(txtFaults.Text.Length > 0))
            {
                App.ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GenerateWorkOrder();
        }

        private void btnGenerateAndEmail_Click(object sender, EventArgs e)
        {
            if (CurrentEquipment is null)
                return;
            if (!(txtFaults.Text.Length > 0))
            {
                App.ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(txtEmail.Text.Length > 0))
            {
                App.ShowMessage("Please add email address!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GenerateWorkOrder(true);
        }

        public void GenerateWorkOrder(bool email = false)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("EquipmentID"));
            dt.Columns.Add(new DataColumn("SerialNumber"));
            dt.Columns.Add(new DataColumn("Faults"));
            dt.Columns.Add(new DataColumn("EmailAddress"));
            dt.Columns.Add(new DataColumn("SendEmail"));
            DataRow r;
            r = dt.NewRow();
            r["EquipmentID"] = CurrentEquipment.EquipmentID;
            r["SerialNumber"] = CurrentEquipment.SerialNumber;
            r["Faults"] = txtFaults.Text;
            r["EmailAddress"] = txtEmail.Text.Trim();
            r["SendEmail"] = email;
            dt.Rows.Add(r);
            var oPrint = new Entity.Sys.Printing(dt, "Analyser ", Entity.Sys.Enums.SystemDocumentType.Analyser);
        }
    }
}