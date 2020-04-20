using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace FSM
{
    public class UCSite : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCSite() : base()
        {
            base.Load += UCSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboDefinition;
            Combo.SetUpCombo(ref argc, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cboRegionID;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = cboSourceOfCustomer;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.SourceOfCustomer).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboReasonForContact;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.ReasonsForContact).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboAccomType;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.AccomType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboSalutation;
            Combo.SetUpCombo(ref argc5, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            dtpBuildDate.Value = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
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
        private TabControl _tcSites;

        internal TabControl tcSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcSites != null)
                {
                }

                _tcSites = value;
                if (_tcSites != null)
                {
                }
            }
        }

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

        private GroupBox _grpSite;

        internal GroupBox grpSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSite != null)
                {
                }

                _grpSite = value;
                if (_grpSite != null)
                {
                }
            }
        }

        private CheckBox _chkHeadOffice;

        internal CheckBox chkHeadOffice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHeadOffice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHeadOffice != null)
                {
                    _chkHeadOffice.Click -= chkHeadOffice_Click;
                }

                _chkHeadOffice = value;
                if (_chkHeadOffice != null)
                {
                    _chkHeadOffice.Click += chkHeadOffice_Click;
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

        private Panel _pnlDocuments;

        internal Panel pnlDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlDocuments != null)
                {
                }

                _pnlDocuments = value;
                if (_pnlDocuments != null)
                {
                }
            }
        }

        private TabPage _tabContacts;

        internal TabPage tabContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabContacts != null)
                {
                }

                _tabContacts = value;
                if (_tabContacts != null)
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

        private Button _btnAddContact;

        internal Button btnAddContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddContact != null)
                {
                    _btnAddContact.Click -= btnAddContact_Click;
                }

                _btnAddContact = value;
                if (_btnAddContact != null)
                {
                    _btnAddContact.Click += btnAddContact_Click;
                }
            }
        }

        private Button _btnDeleteContact;

        internal Button btnDeleteContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteContact != null)
                {
                    _btnDeleteContact.Click -= btnDeleteContact_Click;
                }

                _btnDeleteContact = value;
                if (_btnDeleteContact != null)
                {
                    _btnDeleteContact.Click += btnDeleteContact_Click;
                }
            }
        }

        private DataGrid _dgContacts;

        internal DataGrid dgContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgContacts != null)
                {
                    _dgContacts.DoubleClick -= dgContacts_DoubleClick;
                }

                _dgContacts = value;
                if (_dgContacts != null)
                {
                    _dgContacts.DoubleClick += dgContacts_DoubleClick;
                }
            }
        }

        private TabPage _tabInvoiceAddress;

        internal TabPage tabInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabInvoiceAddress != null)
                {
                }

                _tabInvoiceAddress = value;
                if (_tabInvoiceAddress != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private DataGrid _dgInvoiceAddresses;

        internal DataGrid dgInvoiceAddresses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoiceAddresses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoiceAddresses != null)
                {
                    _dgInvoiceAddresses.DoubleClick -= dgInvoiceAddresses_DoubleClick;
                }

                _dgInvoiceAddresses = value;
                if (_dgInvoiceAddresses != null)
                {
                    _dgInvoiceAddresses.DoubleClick += dgInvoiceAddresses_DoubleClick;
                }
            }
        }

        private Button _btnDeleteAddress;

        internal Button btnDeleteAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteAddress != null)
                {
                    _btnDeleteAddress.Click -= btnDeleteAddress_Click;
                }

                _btnDeleteAddress = value;
                if (_btnDeleteAddress != null)
                {
                    _btnDeleteAddress.Click += btnDeleteAddress_Click;
                }
            }
        }

        private Button _btnAddAddress;

        internal Button btnAddAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAddress != null)
                {
                    _btnAddAddress.Click -= btnAddAddress_Click;
                }

                _btnAddAddress = value;
                if (_btnAddAddress != null)
                {
                    _btnAddAddress.Click += btnAddAddress_Click;
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

        private TabPage _tabQuotes;

        internal TabPage tabQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabQuotes != null)
                {
                }

                _tabQuotes = value;
                if (_tabQuotes != null)
                {
                }
            }
        }

        private Panel _pnlQuotes;

        internal Panel pnlQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlQuotes != null)
                {
                }

                _pnlQuotes = value;
                if (_pnlQuotes != null)
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

        private TextBox _txtRatesMarkup;

        internal TextBox txtRatesMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRatesMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRatesMarkup != null)
                {
                }

                _txtRatesMarkup = value;
                if (_txtRatesMarkup != null)
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

        private TextBox _txtMileageRate;

        internal TextBox txtMileageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMileageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMileageRate != null)
                {
                }

                _txtMileageRate = value;
                if (_txtMileageRate != null)
                {
                }
            }
        }

        private TextBox _txtPartsMarkup;

        internal TextBox txtPartsMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsMarkup != null)
                {
                }

                _txtPartsMarkup = value;
                if (_txtPartsMarkup != null)
                {
                }
            }
        }

        private GroupBox _gpbCharges;

        internal GroupBox gpbCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbCharges != null)
                {
                }

                _gpbCharges = value;
                if (_gpbCharges != null)
                {
                }
            }
        }

        private TabPage _tabCharges;

        internal TabPage tabCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabCharges != null)
                {
                }

                _tabCharges = value;
                if (_tabCharges != null)
                {
                }
            }
        }

        private Panel _pnlCharges;

        internal Panel pnlCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlCharges != null)
                {
                }

                _pnlCharges = value;
                if (_pnlCharges != null)
                {
                }
            }
        }

        private CheckBox _chbAcceptChargeChanges;

        internal CheckBox chbAcceptChargeChanges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chbAcceptChargeChanges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chbAcceptChargeChanges != null)
                {
                }

                _chbAcceptChargeChanges = value;
                if (_chbAcceptChargeChanges != null)
                {
                }
            }
        }

        private Button _btnEmail;

        internal Button btnEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmail != null)
                {
                    _btnEmail.Click -= btnEmail_Click;
                }

                _btnEmail = value;
                if (_btnEmail != null)
                {
                    _btnEmail.Click += btnEmail_Click;
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

        private GroupBox _GroupBox4;

        internal GroupBox GroupBox4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox4 != null)
                {
                }

                _GroupBox4 = value;
                if (_GroupBox4 != null)
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
                    _cboDefinition.SelectedIndexChanged -= cboDefinition_SelectedIndexChanged;
                }

                _cboDefinition = value;
                if (_cboDefinition != null)
                {
                    _cboDefinition.SelectedIndexChanged += cboDefinition_SelectedIndexChanged;
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
                    _txtJobNumber.TextChanged -= txtJobNumber_TextChanged;
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
                {
                    _txtJobNumber.TextChanged += txtJobNumber_TextChanged;
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
                    _dtpTo.ValueChanged -= dtpTo_ValueChanged;
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged += dtpTo_ValueChanged;
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
                    _dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged += dtpFrom_ValueChanged;
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

        private DataGrid _dgJobs;

        internal DataGrid dgJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobs != null)
                {
                    _dgJobs.Click -= dgJobs_Click;
                    _dgJobs.DoubleClick -= dgJobs_DoubleClick;
                }

                _dgJobs = value;
                if (_dgJobs != null)
                {
                    _dgJobs.Click += dgJobs_Click;
                    _dgJobs.DoubleClick += dgJobs_DoubleClick;
                }
            }
        }

        private Button _btnAddJob;

        internal Button btnAddJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddJob != null)
                {
                    _btnAddJob.Click -= btnAddJob_Click;
                }

                _btnAddJob = value;
                if (_btnAddJob != null)
                {
                    _btnAddJob.Click += btnAddJob_Click;
                }
            }
        }

        private Button _btnShowAllJobs;

        internal Button btnShowAllJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShowAllJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShowAllJobs != null)
                {
                    _btnShowAllJobs.Click -= btnShowAllJobs_Click;
                }

                _btnShowAllJobs = value;
                if (_btnShowAllJobs != null)
                {
                    _btnShowAllJobs.Click += btnShowAllJobs_Click;
                }
            }
        }

        private Button _btnRemoveJob;

        internal Button btnRemoveJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveJob != null)
                {
                    _btnRemoveJob.Click -= btnRemoveJob_Click;
                }

                _btnRemoveJob = value;
                if (_btnRemoveJob != null)
                {
                    _btnRemoveJob.Click += btnRemoveJob_Click;
                }
            }
        }

        private Button _btnFindCustomer;

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

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

        private Button _btnDomestic;

        internal Button btnDomestic
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDomestic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDomestic != null)
                {
                    _btnDomestic.Click -= btnDomestic_Click;
                }

                _btnDomestic = value;
                if (_btnDomestic != null)
                {
                    _btnDomestic.Click += btnDomestic_Click;
                }
            }
        }

        private TabPage _tabContracts;

        internal TabPage tabContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabContracts != null)
                {
                }

                _tabContracts = value;
                if (_tabContracts != null)
                {
                }
            }
        }

        private GroupBox _gpbContracts;

        internal GroupBox gpbContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbContracts != null)
                {
                }

                _gpbContracts = value;
                if (_gpbContracts != null)
                {
                }
            }
        }

        private Button _btnDeleteContract;

        internal Button btnDeleteContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteContract != null)
                {
                    _btnDeleteContract.Click -= btnDeleteContract_Click;
                }

                _btnDeleteContract = value;
                if (_btnDeleteContract != null)
                {
                    _btnDeleteContract.Click += btnDeleteContract_Click;
                }
            }
        }

        private DataGrid _dgContracts;

        internal DataGrid dgContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick -= dgContracts_DoubleClick;
                }

                _dgContracts = value;
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick += dgContracts_DoubleClick;
                }
            }
        }

        private Button _btnAddContract;

        internal Button btnAddContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddContract != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnAddContract.Click -= btnAddContract_Click;
                }

                _btnAddContract = value;
                if (_btnAddContract != null)
                {
                    _btnAddContract.Click += btnAddContract_Click;
                }
            }
        }

        private Button _btnCustomerAudit;

        internal Button btnCustomerAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCustomerAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCustomerAudit != null)
                {
                    _btnCustomerAudit.Click -= btnCustomerAudit_Click;
                }

                _btnCustomerAudit = value;
                if (_btnCustomerAudit != null)
                {
                    _btnCustomerAudit.Click += btnCustomerAudit_Click;
                }
            }
        }

        private Button _btnSendEmailToSite;

        internal Button btnSendEmailToSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSendEmailToSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSendEmailToSite != null)
                {
                    _btnSendEmailToSite.Click -= btnSendEmailToSite_Click;
                }

                _btnSendEmailToSite = value;
                if (_btnSendEmailToSite != null)
                {
                    _btnSendEmailToSite.Click += btnSendEmailToSite_Click;
                }
            }
        }

        private CheckBox _chkNoMarketing;

        internal CheckBox chkNoMarketing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNoMarketing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNoMarketing != null)
                {
                }

                _chkNoMarketing = value;
                if (_chkNoMarketing != null)
                {
                }
            }
        }

        private TextBox _txtContractStatus;

        internal TextBox txtContractStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractStatus != null)
                {
                }

                _txtContractStatus = value;
                if (_txtContractStatus != null)
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

        private Button _btnPrintLetters;

        internal Button btnPrintLetters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintLetters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintLetters != null)
                {
                    _btnPrintLetters.Click -= btnPrintLetters_Click;
                }

                _btnPrintLetters = value;
                if (_btnPrintLetters != null)
                {
                    _btnPrintLetters.Click += btnPrintLetters_Click;
                }
            }
        }

        private Button _btnShowVisits;

        internal Button btnShowVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShowVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShowVisits != null)
                {
                    _btnShowVisits.Click -= btnShowVisits_Click;
                }

                _btnShowVisits = value;
                if (_btnShowVisits != null)
                {
                    _btnShowVisits.Click += btnShowVisits_Click;
                }
            }
        }

        private CheckBox _chkOnStop;

        internal CheckBox chkOnStop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkOnStop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkOnStop != null)
                {
                    _chkOnStop.Click -= chkOnStop_Click;
                }

                _chkOnStop = value;
                if (_chkOnStop != null)
                {
                    _chkOnStop.Click += chkOnStop_Click;
                }
            }
        }

        private TabPage _tpNotes;

        internal TabPage tpNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpNotes != null)
                {
                }

                _tpNotes = value;
                if (_tpNotes != null)
                {
                }
            }
        }

        private GroupBox _gpbNotes;

        internal GroupBox gpbNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbNotes != null)
                {
                }

                _gpbNotes = value;
                if (_gpbNotes != null)
                {
                }
            }
        }

        private Button _btnDeleteNote;

        internal Button btnDeleteNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click -= btnDeleteNote_Click;
                }

                _btnDeleteNote = value;
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click += btnDeleteNote_Click;
                }
            }
        }

        private DataGrid _dgNotes;

        internal DataGrid dgNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgNotes != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _dgNotes.Click -= dgNotes_Click;
                    _dgNotes.CurrentCellChanged -= dgNotes_Click;
                }

                _dgNotes = value;
                if (_dgNotes != null)
                {
                    _dgNotes.Click += dgNotes_Click;
                    _dgNotes.CurrentCellChanged += dgNotes_Click;
                }
            }
        }

        private Button _btnAddNote;

        internal Button btnAddNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click -= btnAddNote_Click;
                }

                _btnAddNote = value;
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click += btnAddNote_Click;
                }
            }
        }

        private GroupBox _gpbNotesDetails;

        internal GroupBox gpbNotesDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbNotesDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbNotesDetails != null)
                {
                }

                _gpbNotesDetails = value;
                if (_gpbNotesDetails != null)
                {
                }
            }
        }

        private TextBox _txtNoteID;

        internal TextBox txtNoteID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNoteID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNoteID != null)
                {
                }

                _txtNoteID = value;
                if (_txtNoteID != null)
                {
                }
            }
        }

        private Button _btnSaveNote;

        internal Button btnSaveNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveNote != null)
                {
                    _btnSaveNote.Click -= btnSaveNote_Click;
                }

                _btnSaveNote = value;
                if (_btnSaveNote != null)
                {
                    _btnSaveNote.Click += btnSaveNote_Click;
                }
            }
        }

        private TextBox _txtNote;

        internal TextBox txtNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNote != null)
                {
                }

                _txtNote = value;
                if (_txtNote != null)
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

        private CheckBox _chkLeaseHolder;

        internal CheckBox chkLeaseHolder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLeaseHolder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLeaseHolder != null)
                {
                }

                _chkLeaseHolder = value;
                if (_chkLeaseHolder != null)
                {
                }
            }
        }

        private CheckBox _chkNoService;

        internal CheckBox chkNoService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNoService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNoService != null)
                {
                    _chkNoService.Click -= chkNoService_Click;
                }

                _chkNoService = value;
                if (_chkNoService != null)
                {
                    _chkNoService.Click += chkNoService_Click;
                }
            }
        }

        private CheckBox _chkSolidFuel;

        internal CheckBox chkSolidFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSolidFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSolidFuel != null)
                {
                }

                _chkSolidFuel = value;
                if (_chkSolidFuel != null)
                {
                }
            }
        }

        private CheckBox _chkCommercialDistrict;

        internal CheckBox chkCommercialDistrict
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCommercialDistrict;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCommercialDistrict != null)
                {
                }

                _chkCommercialDistrict = value;
                if (_chkCommercialDistrict != null)
                {
                }
            }
        }

        private Button _btnAddModifyPlan;

        private Button btnAddModifyPlan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddModifyPlan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddModifyPlan != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnAddModifyPlan.Click -= btnAddModifyPlan_Click;
                }

                _btnAddModifyPlan = value;
                if (_btnAddModifyPlan != null)
                {
                    _btnAddModifyPlan.Click += btnAddModifyPlan_Click;
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

        private TextBox _txtFirstName;

        internal TextBox txtFirstName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFirstName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFirstName != null)
                {
                }

                _txtFirstName = value;
                if (_txtFirstName != null)
                {
                }
            }
        }

        private ComboBox _cboSalutation;

        internal ComboBox cboSalutation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSalutation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSalutation != null)
                {
                }

                _cboSalutation = value;
                if (_cboSalutation != null)
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

        private TextBox _txtSurname;

        internal TextBox txtSurname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSurname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSurname != null)
                {
                }

                _txtSurname = value;
                if (_txtSurname != null)
                {
                }
            }
        }

        private ComboBox _cboRegionID;

        internal ComboBox cboRegionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegionID != null)
                {
                }

                _cboRegionID = value;
                if (_cboRegionID != null)
                {
                }
            }
        }

        private Label _lblRegionID;

        internal Label lblRegionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegionID != null)
                {
                }

                _lblRegionID = value;
                if (_lblRegionID != null)
                {
                }
            }
        }

        private TextBox _txtPolicyNumber;

        internal TextBox txtPolicyNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPolicyNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPolicyNumber != null)
                {
                }

                _txtPolicyNumber = value;
                if (_txtPolicyNumber != null)
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

        private Button _btnConvCust;

        internal Button btnConvCust
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnConvCust;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnConvCust != null)
                {
                    _btnConvCust.Click -= btnConvCust_Click;
                }

                _btnConvCust = value;
                if (_btnConvCust != null)
                {
                    _btnConvCust.Click += btnConvCust_Click;
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

        private TextBox _txtAsbestos;

        internal TextBox txtAsbestos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAsbestos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAsbestos != null)
                {
                }

                _txtAsbestos = value;
                if (_txtAsbestos != null)
                {
                }
            }
        }

        private TextBox _txtAlert;

        internal TextBox txtAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAlert != null)
                {
                }

                _txtAlert = value;
                if (_txtAlert != null)
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

        private GroupBox _grpSiteFuel;

        internal GroupBox grpSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteFuel != null)
                {
                }

                _grpSiteFuel = value;
                if (_grpSiteFuel != null)
                {
                }
            }
        }

        private DataGrid _dgSiteFuel;

        internal DataGrid dgSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.MouseUp -= dgSiteFuel_MouseUp;
                    _dgSiteFuel.Leave -= dgSiteFuel_Leave;
                }

                _dgSiteFuel = value;
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.MouseUp += dgSiteFuel_MouseUp;
                    _dgSiteFuel.Leave += dgSiteFuel_Leave;
                }
            }
        }

        private ToolTip _ttSiteFuel;

        internal ToolTip ttSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ttSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ttSiteFuel != null)
                {
                }

                _ttSiteFuel = value;
                if (_ttSiteFuel != null)
                {
                }
            }
        }

        private Button _btnMoreInfo;

        internal Button btnMoreInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoreInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoreInfo != null)
                {
                    _btnMoreInfo.Click -= SiteFuelMoreInfo;
                }

                _btnMoreInfo = value;
                if (_btnMoreInfo != null)
                {
                    _btnMoreInfo.Click += SiteFuelMoreInfo;
                }
            }
        }

        private CheckBox _chkVoid;

        internal CheckBox chkVoid
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVoid;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVoid != null)
                {
                    _chkVoid.Click -= ChkVoid_Click;
                }

                _chkVoid = value;
                if (_chkVoid != null)
                {
                    _chkVoid.Click += ChkVoid_Click;
                }
            }
        }

        private TextBox _txtLastServiceDate;

        internal TextBox txtLastServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLastServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLastServiceDate != null)
                {
                }

                _txtLastServiceDate = value;
                if (_txtLastServiceDate != null)
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

        private ContextMenuStrip _cmsJobs;

        internal ContextMenuStrip cmsJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsJobs != null)
                {
                }

                _cmsJobs = value;
                if (_cmsJobs != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiMoveJob;

        internal ToolStripMenuItem tsmiMoveJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiMoveJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiMoveJob != null)
                {
                    _tsmiMoveJob.Click -= tsmiMoveJob_Click;
                }

                _tsmiMoveJob = value;
                if (_tsmiMoveJob != null)
                {
                    _tsmiMoveJob.Click += tsmiMoveJob_Click;
                }
            }
        }

        private TextBox _txtActualServiceDate;

        internal TextBox txtActualServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActualServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActualServiceDate != null)
                {
                }

                _txtActualServiceDate = value;
                if (_txtActualServiceDate != null)
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

        private TabPage _tabAuthority;

        internal TabPage tabAuthority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAuthority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAuthority != null)
                {
                }

                _tabAuthority = value;
                if (_tabAuthority != null)
                {
                }
            }
        }

        private GroupBox _gpCustAuth;

        internal GroupBox gpCustAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpCustAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpCustAuth != null)
                {
                }

                _gpCustAuth = value;
                if (_gpCustAuth != null)
                {
                }
            }
        }

        private TextBox _txtCustAuthority;

        internal TextBox txtCustAuthority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustAuthority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustAuthority != null)
                {
                }

                _txtCustAuthority = value;
                if (_txtCustAuthority != null)
                {
                }
            }
        }

        private GroupBox _grpAudit;

        internal GroupBox grpAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAudit != null)
                {
                }

                _grpAudit = value;
                if (_grpAudit != null)
                {
                }
            }
        }

        private DataGrid _dgAuthorityAudit;

        internal DataGrid dgAuthorityAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAuthorityAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAuthorityAudit != null)
                {
                }

                _dgAuthorityAudit = value;
                if (_dgAuthorityAudit != null)
                {
                }
            }
        }

        private GroupBox _grpSiteAuth;

        internal GroupBox grpSiteAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteAuth != null)
                {
                }

                _grpSiteAuth = value;
                if (_grpSiteAuth != null)
                {
                }
            }
        }

        private Button _btnSaveAuth;

        internal Button btnSaveAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveAuth != null)
                {
                    _btnSaveAuth.Click -= btnSaveAuth_Click;
                }

                _btnSaveAuth = value;
                if (_btnSaveAuth != null)
                {
                    _btnSaveAuth.Click += btnSaveAuth_Click;
                }
            }
        }

        private TextBox _txtSiteAuth;

        internal TextBox txtSiteAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteAuth != null)
                {
                }

                _txtSiteAuth = value;
                if (_txtSiteAuth != null)
                {
                }
            }
        }

        private Button _btnSiteReport;

        internal Button btnSiteReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSiteReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSiteReport != null)
                {
                    _btnSiteReport.Click -= btnSiteReport_Click;
                }

                _btnSiteReport = value;
                if (_btnSiteReport != null)
                {
                    _btnSiteReport.Click += btnSiteReport_Click;
                }
            }
        }

        private TabPage _tpAdditionalDetails;

        internal TabPage tpAdditionalDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpAdditionalDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpAdditionalDetails != null)
                {
                }

                _tpAdditionalDetails = value;
                if (_tpAdditionalDetails != null)
                {
                }
            }
        }

        private GroupBox _grpAdditionalDetails;

        internal GroupBox grpAdditionalDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAdditionalDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAdditionalDetails != null)
                {
                }

                _grpAdditionalDetails = value;
                if (_grpAdditionalDetails != null)
                {
                }
            }
        }

        private Label _lblBuildDate;

        internal Label lblBuildDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuildDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuildDate != null)
                {
                }

                _lblBuildDate = value;
                if (_lblBuildDate != null)
                {
                }
            }
        }

        private TextBox _txtWarrantyPeriod;

        internal TextBox txtWarrantyPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWarrantyPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWarrantyPeriod != null)
                {
                }

                _txtWarrantyPeriod = value;
                if (_txtWarrantyPeriod != null)
                {
                }
            }
        }

        private Label _lblWarrantyPeriod;

        internal Label lblWarrantyPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWarrantyPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWarrantyPeriod != null)
                {
                }

                _lblWarrantyPeriod = value;
                if (_lblWarrantyPeriod != null)
                {
                }
            }
        }

        private DateTimePicker _dtpBuildDate;

        internal DateTimePicker dtpBuildDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpBuildDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpBuildDate != null)
                {
                }

                _dtpBuildDate = value;
                if (_dtpBuildDate != null)
                {
                }
            }
        }

        private TextBox _txtPropertyVoidDate;

        internal TextBox txtPropertyVoidDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPropertyVoidDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPropertyVoidDate != null)
                {
                }

                _txtPropertyVoidDate = value;
                if (_txtPropertyVoidDate != null)
                {
                }
            }
        }

        private Label _lblPropertyVoidDate;

        internal Label lblPropertyVoidDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPropertyVoidDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPropertyVoidDate != null)
                {
                }

                _lblPropertyVoidDate = value;
                if (_lblPropertyVoidDate != null)
                {
                }
            }
        }

        private TextBox _txtSiteDefects;

        internal TextBox txtSiteDefects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteDefects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteDefects != null)
                {
                }

                _txtSiteDefects = value;
                if (_txtSiteDefects != null)
                {
                }
            }
        }

        private Label _lblSiteDefects;

        internal Label lblSiteDefects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSiteDefects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSiteDefects != null)
                {
                }

                _lblSiteDefects = value;
                if (_lblSiteDefects != null)
                {
                }
            }
        }

        private Label _lblHousingOfficer;

        internal Label lblHousingOfficer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHousingOfficer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHousingOfficer != null)
                {
                }

                _lblHousingOfficer = value;
                if (_lblHousingOfficer != null)
                {
                }
            }
        }

        private TextBox _txtHousingOfficer;

        internal TextBox txtHousingOfficer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHousingOfficer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHousingOfficer != null)
                {
                }

                _txtHousingOfficer = value;
                if (_txtHousingOfficer != null)
                {
                }
            }
        }

        private TextBox _txtEstateOfficer;

        internal TextBox txtEstateOfficer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEstateOfficer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEstateOfficer != null)
                {
                }

                _txtEstateOfficer = value;
                if (_txtEstateOfficer != null)
                {
                }
            }
        }

        private Label _lblEstateOfficer;

        internal Label lblEstateOfficer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEstateOfficer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEstateOfficer != null)
                {
                }

                _lblEstateOfficer = value;
                if (_lblEstateOfficer != null)
                {
                }
            }
        }

        private TextBox _txtHousingManager;

        internal TextBox txtHousingManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHousingManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHousingManager != null)
                {
                }

                _txtHousingManager = value;
                if (_txtHousingManager != null)
                {
                }
            }
        }

        private Label _lblHousingManager;

        internal Label lblHousingManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHousingManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHousingManager != null)
                {
                }

                _lblHousingManager = value;
                if (_lblHousingManager != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDefectEndDate;

        internal DateTimePicker dtpDefectEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDefectEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDefectEndDate != null)
                {
                }

                _dtpDefectEndDate = value;
                if (_dtpDefectEndDate != null)
                {
                }
            }
        }

        private Label _lblDefectEndDate;

        internal Label lblDefectEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDefectEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDefectEndDate != null)
                {
                }

                _lblDefectEndDate = value;
                if (_lblDefectEndDate != null)
                {
                }
            }
        }

        private Label _lblAccomType;

        protected Label lblAccomType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccomType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccomType != null)
                {
                }

                _lblAccomType = value;
                if (_lblAccomType != null)
                {
                }
            }
        }

        private ComboBox _cboAccomType;

        internal ComboBox cboAccomType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAccomType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAccomType != null)
                {
                }

                _cboAccomType = value;
                if (_cboAccomType != null)
                {
                }
            }
        }

        private TextBox _txtDDRef;

        internal TextBox txtDDRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDDRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDDRef != null)
                {
                }

                _txtDDRef = value;
                if (_txtDDRef != null)
                {
                }
            }
        }

        private Label _lblDDRef;

        internal Label lblDDRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDDRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDDRef != null)
                {
                }

                _lblDDRef = value;
                if (_lblDDRef != null)
                {
                }
            }
        }

        private Button _btnLetterReport;

        internal Button btnLetterReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnLetterReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnLetterReport != null)
                {
                    _btnLetterReport.Click -= btnLetterReport_Click;
                }

                _btnLetterReport = value;
                if (_btnLetterReport != null)
                {
                    _btnLetterReport.Click += btnLetterReport_Click;
                }
            }
        }

        private ComboBox _cboReasonForContact;

        internal ComboBox cboReasonForContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReasonForContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReasonForContact != null)
                {
                }

                _cboReasonForContact = value;
                if (_cboReasonForContact != null)
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

        private ComboBox _cboSourceOfCustomer;

        internal ComboBox cboSourceOfCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSourceOfCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSourceOfCustomer != null)
                {
                }

                _cboSourceOfCustomer = value;
                if (_cboSourceOfCustomer != null)
                {
                }
            }
        }

        private TabPage _TabNewContacts;

        internal TabPage TabNewContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabNewContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabNewContacts != null)
                {
                }

                _TabNewContacts = value;
                if (_TabNewContacts != null)
                {
                }
            }
        }

        private FlowLayoutPanel _pnlContactsMain;

        internal FlowLayoutPanel pnlContactsMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlContactsMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlContactsMain != null)
                {
                }

                _pnlContactsMain = value;
                if (_pnlContactsMain != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _tcSites = new TabControl();
            _tabDetails = new TabPage();
            _grpSiteFuel = new GroupBox();
            _btnMoreInfo = new Button();
            _btnMoreInfo.Click += new EventHandler(SiteFuelMoreInfo);
            _dgSiteFuel = new DataGrid();
            _dgSiteFuel.MouseUp += new MouseEventHandler(dgSiteFuel_MouseUp);
            _dgSiteFuel.Leave += new EventHandler(dgSiteFuel_Leave);
            _grpSite = new GroupBox();
            _txtDDRef = new TextBox();
            _lblDDRef = new Label();
            _cboAccomType = new ComboBox();
            _lblAccomType = new Label();
            _dtpDefectEndDate = new DateTimePicker();
            _lblDefectEndDate = new Label();
            _txtSiteDefects = new TextBox();
            _lblSiteDefects = new Label();
            _txtPropertyVoidDate = new TextBox();
            _lblPropertyVoidDate = new Label();
            _txtActualServiceDate = new TextBox();
            _Label17 = new Label();
            _txtLastServiceDate = new TextBox();
            _Label16 = new Label();
            _chkVoid = new CheckBox();
            _chkVoid.Click += new EventHandler(ChkVoid_Click);
            _txtFirstName = new TextBox();
            _txtAlert = new TextBox();
            _Label21 = new Label();
            _Label20 = new Label();
            _txtAsbestos = new TextBox();
            _btnConvCust = new Button();
            _btnConvCust.Click += new EventHandler(btnConvCust_Click);
            _Label19 = new Label();
            _txtSurname = new TextBox();
            _cboRegionID = new ComboBox();
            _txtPolicyNumber = new TextBox();
            _Label12 = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtAddress4 = new TextBox();
            _lblTown = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _cboSalutation = new ComboBox();
            _Label18 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress2 = new Label();
            _btnAddModifyPlan = new Button();
            _btnAddModifyPlan.Click += new EventHandler(btnAddModifyPlan_Click);
            _chkCommercialDistrict = new CheckBox();
            _chkLeaseHolder = new CheckBox();
            _chkNoService = new CheckBox();
            _chkNoService.Click += new EventHandler(chkNoService_Click);
            _chkSolidFuel = new CheckBox();
            _chkOnStop = new CheckBox();
            _chkOnStop.Click += new EventHandler(chkOnStop_Click);
            _txtContractStatus = new TextBox();
            _lblNotes = new Label();
            _chkNoMarketing = new CheckBox();
            _btnSendEmailToSite = new Button();
            _btnSendEmailToSite.Click += new EventHandler(btnSendEmailToSite_Click);
            _btnCustomerAudit = new Button();
            _btnCustomerAudit.Click += new EventHandler(btnCustomerAudit_Click);
            _btnDomestic = new Button();
            _btnDomestic.Click += new EventHandler(btnDomestic_Click);
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label10 = new Label();
            _txtName = new TextBox();
            _Label3 = new Label();
            _chkHeadOffice = new CheckBox();
            _chkHeadOffice.Click += new EventHandler(chkHeadOffice_Click);
            _txtNotes = new TextBox();
            _txtAddress1 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress5 = new TextBox();
            _lblCounty = new Label();
            _txtPostcode = new TextBox();
            _lblPostcode = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _lblContractInactive = new Label();
            _Label14 = new Label();
            _lblRegionID = new Label();
            _GroupBox4 = new GroupBox();
            _btnSiteReport = new Button();
            _btnSiteReport.Click += new EventHandler(btnSiteReport_Click);
            _btnShowVisits = new Button();
            _btnShowVisits.Click += new EventHandler(btnShowVisits_Click);
            _cboDefinition = new ComboBox();
            _cboDefinition.SelectedIndexChanged += new EventHandler(cboDefinition_SelectedIndexChanged);
            _Label9 = new Label();
            _txtJobNumber = new TextBox();
            _txtJobNumber.TextChanged += new EventHandler(txtJobNumber_TextChanged);
            _Label7 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _Label6 = new Label();
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _Label5 = new Label();
            _dgJobs = new DataGrid();
            _dgJobs.Click += new EventHandler(dgJobs_Click);
            _dgJobs.DoubleClick += new EventHandler(dgJobs_DoubleClick);
            _btnAddJob = new Button();
            _btnAddJob.Click += new EventHandler(btnAddJob_Click);
            _btnShowAllJobs = new Button();
            _btnShowAllJobs.Click += new EventHandler(btnShowAllJobs_Click);
            _btnRemoveJob = new Button();
            _btnRemoveJob.Click += new EventHandler(btnRemoveJob_Click);
            _TabNewContacts = new TabPage();
            _pnlContactsMain = new FlowLayoutPanel();
            _tabCharges = new TabPage();
            _gpbCharges = new GroupBox();
            _chbAcceptChargeChanges = new CheckBox();
            _pnlCharges = new Panel();
            _Label2 = new Label();
            _txtRatesMarkup = new TextBox();
            _Label4 = new Label();
            _Label8 = new Label();
            _txtMileageRate = new TextBox();
            _txtPartsMarkup = new TextBox();
            _tabContacts = new TabPage();
            _btnPrintLetters = new Button();
            _btnPrintLetters.Click += new EventHandler(btnPrintLetters_Click);
            _btnEmail = new Button();
            _btnEmail.Click += new EventHandler(btnEmail_Click);
            _GroupBox1 = new GroupBox();
            _dgContacts = new DataGrid();
            _dgContacts.DoubleClick += new EventHandler(dgContacts_DoubleClick);
            _btnDeleteContact = new Button();
            _btnDeleteContact.Click += new EventHandler(btnDeleteContact_Click);
            _btnAddContact = new Button();
            _btnAddContact.Click += new EventHandler(btnAddContact_Click);
            _tabInvoiceAddress = new TabPage();
            _GroupBox2 = new GroupBox();
            _dgInvoiceAddresses = new DataGrid();
            _dgInvoiceAddresses.DoubleClick += new EventHandler(dgInvoiceAddresses_DoubleClick);
            _btnDeleteAddress = new Button();
            _btnDeleteAddress.Click += new EventHandler(btnDeleteAddress_Click);
            _btnAddAddress = new Button();
            _btnAddAddress.Click += new EventHandler(btnAddAddress_Click);
            _tabDocuments = new TabPage();
            _pnlDocuments = new Panel();
            _tabQuotes = new TabPage();
            _pnlQuotes = new Panel();
            _tabContracts = new TabPage();
            _gpbContracts = new GroupBox();
            _btnDeleteContract = new Button();
            _btnDeleteContract.Click += new EventHandler(btnDeleteContract_Click);
            _dgContracts = new DataGrid();
            _dgContracts.DoubleClick += new EventHandler(dgContracts_DoubleClick);
            _btnAddContract = new Button();
            _btnAddContract.Click += new EventHandler(btnAddContract_Click);
            _tpNotes = new TabPage();
            _gpbNotesDetails = new GroupBox();
            _txtNoteID = new TextBox();
            _btnSaveNote = new Button();
            _btnSaveNote.Click += new EventHandler(btnSaveNote_Click);
            _txtNote = new TextBox();
            _Label15 = new Label();
            _gpbNotes = new GroupBox();
            _btnDeleteNote = new Button();
            _btnDeleteNote.Click += new EventHandler(btnDeleteNote_Click);
            _dgNotes = new DataGrid();
            _dgNotes.Click += new EventHandler(dgNotes_Click);
            _dgNotes.CurrentCellChanged += new EventHandler(dgNotes_Click);
            _dgNotes.Click += new EventHandler(dgNotes_Click);
            _dgNotes.CurrentCellChanged += new EventHandler(dgNotes_Click);
            _btnAddNote = new Button();
            _btnAddNote.Click += new EventHandler(btnAddNote_Click);
            _tabAuthority = new TabPage();
            _grpSiteAuth = new GroupBox();
            _btnSaveAuth = new Button();
            _btnSaveAuth.Click += new EventHandler(btnSaveAuth_Click);
            _txtSiteAuth = new TextBox();
            _gpCustAuth = new GroupBox();
            _txtCustAuthority = new TextBox();
            _grpAudit = new GroupBox();
            _dgAuthorityAudit = new DataGrid();
            _tpAdditionalDetails = new TabPage();
            _grpAdditionalDetails = new GroupBox();
            _btnLetterReport = new Button();
            _btnLetterReport.Click += new EventHandler(btnLetterReport_Click);
            _cboReasonForContact = new ComboBox();
            _Label11 = new Label();
            _Label13 = new Label();
            _cboSourceOfCustomer = new ComboBox();
            _txtEstateOfficer = new TextBox();
            _lblEstateOfficer = new Label();
            _txtHousingManager = new TextBox();
            _lblHousingManager = new Label();
            _txtHousingOfficer = new TextBox();
            _lblHousingOfficer = new Label();
            _dtpBuildDate = new DateTimePicker();
            _lblBuildDate = new Label();
            _txtWarrantyPeriod = new TextBox();
            _lblWarrantyPeriod = new Label();
            _ttSiteFuel = new ToolTip(components);
            _cmsJobs = new ContextMenuStrip(components);
            _tsmiMoveJob = new ToolStripMenuItem();
            _tsmiMoveJob.Click += new EventHandler(tsmiMoveJob_Click);
            _tcSites.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpSiteFuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).BeginInit();
            _grpSite.SuspendLayout();
            _GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).BeginInit();
            _TabNewContacts.SuspendLayout();
            _tabCharges.SuspendLayout();
            _gpbCharges.SuspendLayout();
            _tabContacts.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgContacts).BeginInit();
            _tabInvoiceAddress.SuspendLayout();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).BeginInit();
            _tabDocuments.SuspendLayout();
            _tabQuotes.SuspendLayout();
            _tabContracts.SuspendLayout();
            _gpbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgContracts).BeginInit();
            _tpNotes.SuspendLayout();
            _gpbNotesDetails.SuspendLayout();
            _gpbNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgNotes).BeginInit();
            _tabAuthority.SuspendLayout();
            _grpSiteAuth.SuspendLayout();
            _gpCustAuth.SuspendLayout();
            _grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAuthorityAudit).BeginInit();
            _tpAdditionalDetails.SuspendLayout();
            _grpAdditionalDetails.SuspendLayout();
            _cmsJobs.SuspendLayout();
            SuspendLayout();
            // 
            // tcSites
            // 
            _tcSites.Controls.Add(_tabDetails);
            _tcSites.Controls.Add(_TabNewContacts);
            _tcSites.Controls.Add(_tabCharges);
            _tcSites.Controls.Add(_tabContacts);
            _tcSites.Controls.Add(_tabInvoiceAddress);
            _tcSites.Controls.Add(_tabDocuments);
            _tcSites.Controls.Add(_tabQuotes);
            _tcSites.Controls.Add(_tabContracts);
            _tcSites.Controls.Add(_tpNotes);
            _tcSites.Controls.Add(_tabAuthority);
            _tcSites.Controls.Add(_tpAdditionalDetails);
            _tcSites.Dock = DockStyle.Fill;
            _tcSites.Location = new Point(0, 0);
            _tcSites.Name = "tcSites";
            _tcSites.SelectedIndex = 0;
            _tcSites.Size = new Size(1080, 666);
            _tcSites.TabIndex = 0;
            // 
            // tabDetails
            // 
            _tabDetails.Controls.Add(_grpSiteFuel);
            _tabDetails.Controls.Add(_grpSite);
            _tabDetails.Controls.Add(_GroupBox4);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(1072, 640);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            // 
            // grpSiteFuel
            // 
            _grpSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSiteFuel.Controls.Add(_btnMoreInfo);
            _grpSiteFuel.Controls.Add(_dgSiteFuel);
            _grpSiteFuel.Location = new Point(588, 421);
            _grpSiteFuel.Margin = new Padding(0);
            _grpSiteFuel.Name = "grpSiteFuel";
            _grpSiteFuel.Padding = new Padding(0);
            _grpSiteFuel.Size = new Size(476, 219);
            _grpSiteFuel.TabIndex = 13;
            _grpSiteFuel.TabStop = false;
            _grpSiteFuel.Text = "Site Fuel";
            // 
            // btnMoreInfo
            // 
            _btnMoreInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnMoreInfo.Location = new Point(371, 19);
            _btnMoreInfo.Name = "btnMoreInfo";
            _btnMoreInfo.Size = new Size(96, 23);
            _btnMoreInfo.TabIndex = 12;
            _btnMoreInfo.Text = "Update Fuels";
            // 
            // dgSiteFuel
            // 
            _dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSiteFuel.DataMember = "";
            _dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
            _dgSiteFuel.Location = new Point(5, 19);
            _dgSiteFuel.Name = "dgSiteFuel";
            _dgSiteFuel.Size = new Size(360, 195);
            _dgSiteFuel.TabIndex = 11;
            // 
            // grpSite
            // 
            _grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpSite.Controls.Add(_txtDDRef);
            _grpSite.Controls.Add(_lblDDRef);
            _grpSite.Controls.Add(_cboAccomType);
            _grpSite.Controls.Add(_lblAccomType);
            _grpSite.Controls.Add(_dtpDefectEndDate);
            _grpSite.Controls.Add(_lblDefectEndDate);
            _grpSite.Controls.Add(_txtSiteDefects);
            _grpSite.Controls.Add(_lblSiteDefects);
            _grpSite.Controls.Add(_txtPropertyVoidDate);
            _grpSite.Controls.Add(_lblPropertyVoidDate);
            _grpSite.Controls.Add(_txtActualServiceDate);
            _grpSite.Controls.Add(_Label17);
            _grpSite.Controls.Add(_txtLastServiceDate);
            _grpSite.Controls.Add(_Label16);
            _grpSite.Controls.Add(_chkVoid);
            _grpSite.Controls.Add(_txtFirstName);
            _grpSite.Controls.Add(_txtAlert);
            _grpSite.Controls.Add(_Label21);
            _grpSite.Controls.Add(_Label20);
            _grpSite.Controls.Add(_txtAsbestos);
            _grpSite.Controls.Add(_btnConvCust);
            _grpSite.Controls.Add(_Label19);
            _grpSite.Controls.Add(_txtSurname);
            _grpSite.Controls.Add(_cboRegionID);
            _grpSite.Controls.Add(_txtPolicyNumber);
            _grpSite.Controls.Add(_Label12);
            _grpSite.Controls.Add(_txtTelephoneNum);
            _grpSite.Controls.Add(_lblTelephoneNum);
            _grpSite.Controls.Add(_txtAddress4);
            _grpSite.Controls.Add(_lblTown);
            _grpSite.Controls.Add(_txtEmailAddress);
            _grpSite.Controls.Add(_lblEmailAddress);
            _grpSite.Controls.Add(_cboSalutation);
            _grpSite.Controls.Add(_Label18);
            _grpSite.Controls.Add(_txtAddress2);
            _grpSite.Controls.Add(_lblAddress2);
            _grpSite.Controls.Add(_btnAddModifyPlan);
            _grpSite.Controls.Add(_chkCommercialDistrict);
            _grpSite.Controls.Add(_chkLeaseHolder);
            _grpSite.Controls.Add(_chkNoService);
            _grpSite.Controls.Add(_chkSolidFuel);
            _grpSite.Controls.Add(_chkOnStop);
            _grpSite.Controls.Add(_txtContractStatus);
            _grpSite.Controls.Add(_lblNotes);
            _grpSite.Controls.Add(_chkNoMarketing);
            _grpSite.Controls.Add(_btnSendEmailToSite);
            _grpSite.Controls.Add(_btnCustomerAudit);
            _grpSite.Controls.Add(_btnDomestic);
            _grpSite.Controls.Add(_btnFindCustomer);
            _grpSite.Controls.Add(_txtCustomer);
            _grpSite.Controls.Add(_Label10);
            _grpSite.Controls.Add(_txtName);
            _grpSite.Controls.Add(_Label3);
            _grpSite.Controls.Add(_chkHeadOffice);
            _grpSite.Controls.Add(_txtNotes);
            _grpSite.Controls.Add(_txtAddress1);
            _grpSite.Controls.Add(_lblAddress1);
            _grpSite.Controls.Add(_txtAddress3);
            _grpSite.Controls.Add(_lblAddress3);
            _grpSite.Controls.Add(_txtAddress5);
            _grpSite.Controls.Add(_lblCounty);
            _grpSite.Controls.Add(_txtPostcode);
            _grpSite.Controls.Add(_lblPostcode);
            _grpSite.Controls.Add(_txtFaxNum);
            _grpSite.Controls.Add(_lblFaxNum);
            _grpSite.Controls.Add(_lblContractInactive);
            _grpSite.Controls.Add(_Label14);
            _grpSite.Controls.Add(_lblRegionID);
            _grpSite.Location = new Point(3, 2);
            _grpSite.Name = "grpSite";
            _grpSite.Size = new Size(1061, 416);
            _grpSite.TabIndex = 0;
            _grpSite.TabStop = false;
            _grpSite.Text = "Main Details";
            // 
            // txtDDRef
            // 
            _txtDDRef.Location = new Point(855, 195);
            _txtDDRef.MaxLength = 100;
            _txtDDRef.Name = "txtDDRef";
            _txtDDRef.Size = new Size(145, 21);
            _txtDDRef.TabIndex = 128;
            _txtDDRef.Tag = "";
            // 
            // lblDDRef
            // 
            _lblDDRef.Location = new Point(792, 199);
            _lblDDRef.Name = "lblDDRef";
            _lblDDRef.Size = new Size(61, 20);
            _lblDDRef.TabIndex = 129;
            _lblDDRef.Text = "DD Ref";
            _lblDDRef.UseMnemonic = false;
            // 
            // cboAccomType
            // 
            _cboAccomType.Cursor = Cursors.Hand;
            _cboAccomType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAccomType.Location = new Point(789, 225);
            _cboAccomType.Name = "cboAccomType";
            _cboAccomType.Size = new Size(145, 21);
            _cboAccomType.TabIndex = 122;
            _cboAccomType.Tag = "Site.RegionID";
            // 
            // lblAccomType
            // 
            _lblAccomType.Location = new Point(643, 229);
            _lblAccomType.Name = "lblAccomType";
            _lblAccomType.Size = new Size(140, 23);
            _lblAccomType.TabIndex = 121;
            _lblAccomType.Text = "Accommodation Type";
            // 
            // dtpDefectEndDate
            // 
            _dtpDefectEndDate.Location = new Point(855, 383);
            _dtpDefectEndDate.Name = "dtpDefectEndDate";
            _dtpDefectEndDate.Size = new Size(151, 21);
            _dtpDefectEndDate.TabIndex = 120;
            // 
            // lblDefectEndDate
            // 
            _lblDefectEndDate.Location = new Point(730, 386);
            _lblDefectEndDate.Name = "lblDefectEndDate";
            _lblDefectEndDate.Size = new Size(119, 20);
            _lblDefectEndDate.TabIndex = 119;
            _lblDefectEndDate.Text = "Defect End Date";
            // 
            // txtSiteDefects
            // 
            _txtSiteDefects.Location = new Point(534, 383);
            _txtSiteDefects.MaxLength = 100;
            _txtSiteDefects.Name = "txtSiteDefects";
            _txtSiteDefects.RightToLeft = RightToLeft.No;
            _txtSiteDefects.Size = new Size(181, 21);
            _txtSiteDefects.TabIndex = 118;
            _txtSiteDefects.Tag = "";
            // 
            // lblSiteDefects
            // 
            _lblSiteDefects.Location = new Point(419, 386);
            _lblSiteDefects.Name = "lblSiteDefects";
            _lblSiteDefects.Size = new Size(119, 20);
            _lblSiteDefects.TabIndex = 117;
            _lblSiteDefects.Text = "Defect Contractor";
            // 
            // txtPropertyVoidDate
            // 
            _txtPropertyVoidDate.BackColor = SystemColors.Control;
            _txtPropertyVoidDate.Location = new Point(534, 225);
            _txtPropertyVoidDate.Name = "txtPropertyVoidDate";
            _txtPropertyVoidDate.ReadOnly = true;
            _txtPropertyVoidDate.Size = new Size(89, 21);
            _txtPropertyVoidDate.TabIndex = 116;
            _txtPropertyVoidDate.Visible = false;
            // 
            // lblPropertyVoidDate
            // 
            _lblPropertyVoidDate.AutoSize = true;
            _lblPropertyVoidDate.Location = new Point(466, 228);
            _lblPropertyVoidDate.Name = "lblPropertyVoidDate";
            _lblPropertyVoidDate.Size = new Size(62, 13);
            _lblPropertyVoidDate.TabIndex = 115;
            _lblPropertyVoidDate.Text = "Void Date";
            _lblPropertyVoidDate.Visible = false;
            // 
            // txtActualServiceDate
            // 
            _txtActualServiceDate.Location = new Point(328, 225);
            _txtActualServiceDate.MaxLength = 100;
            _txtActualServiceDate.Name = "txtActualServiceDate";
            _txtActualServiceDate.ReadOnly = true;
            _txtActualServiceDate.Size = new Size(123, 21);
            _txtActualServiceDate.TabIndex = 112;
            _txtActualServiceDate.Tag = "";
            // 
            // Label17
            // 
            _Label17.Location = new Point(244, 229);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(128, 20);
            _Label17.TabIndex = 111;
            _Label17.Text = "Service Date";
            // 
            // txtLastServiceDate
            // 
            _txtLastServiceDate.Location = new Point(115, 225);
            _txtLastServiceDate.MaxLength = 100;
            _txtLastServiceDate.Name = "txtLastServiceDate";
            _txtLastServiceDate.ReadOnly = true;
            _txtLastServiceDate.Size = new Size(123, 21);
            _txtLastServiceDate.TabIndex = 110;
            _txtLastServiceDate.Tag = "";
            // 
            // Label16
            // 
            _Label16.Location = new Point(3, 229);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(128, 20);
            _Label16.TabIndex = 109;
            _Label16.Text = "Service Due";
            // 
            // chkVoid
            // 
            _chkVoid.AutoCheck = false;
            _chkVoid.AutoSize = true;
            _chkVoid.Location = new Point(630, 199);
            _chkVoid.Name = "chkVoid";
            _chkVoid.Size = new Size(103, 17);
            _chkVoid.TabIndex = 108;
            _chkVoid.Text = "Void Property";
            _chkVoid.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            _txtFirstName.Location = new Point(328, 42);
            _txtFirstName.MaxLength = 255;
            _txtFirstName.Name = "txtFirstName";
            _txtFirstName.Size = new Size(146, 21);
            _txtFirstName.TabIndex = 5;
            _txtFirstName.Tag = "";
            // 
            // txtAlert
            // 
            _txtAlert.Location = new Point(115, 383);
            _txtAlert.MaxLength = 100;
            _txtAlert.Name = "txtAlert";
            _txtAlert.RightToLeft = RightToLeft.No;
            _txtAlert.Size = new Size(298, 21);
            _txtAlert.TabIndex = 105;
            _txtAlert.Tag = "";
            // 
            // Label21
            // 
            _Label21.Location = new Point(7, 386);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(102, 20);
            _Label21.TabIndex = 104;
            _Label21.Text = "Contact Alerts";
            // 
            // Label20
            // 
            _Label20.Location = new Point(7, 335);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(102, 20);
            _Label20.TabIndex = 103;
            _Label20.Text = "Asbestos Details";
            // 
            // txtAsbestos
            // 
            _txtAsbestos.AcceptsReturn = true;
            _txtAsbestos.Location = new Point(115, 333);
            _txtAsbestos.Multiline = true;
            _txtAsbestos.Name = "txtAsbestos";
            _txtAsbestos.ReadOnly = true;
            _txtAsbestos.ScrollBars = ScrollBars.Vertical;
            _txtAsbestos.Size = new Size(891, 45);
            _txtAsbestos.TabIndex = 102;
            _txtAsbestos.Tag = "Site.Notes";
            // 
            // btnConvCust
            // 
            _btnConvCust.Location = new Point(632, 15);
            _btnConvCust.Name = "btnConvCust";
            _btnConvCust.Size = new Size(146, 23);
            _btnConvCust.TabIndex = 101;
            _btnConvCust.Text = "Convert to Customer";
            _btnConvCust.UseVisualStyleBackColor = true;
            // 
            // Label19
            // 
            _Label19.Location = new Point(8, 72);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(77, 20);
            _Label19.TabIndex = 84;
            _Label19.Text = "Surname";
            // 
            // txtSurname
            // 
            _txtSurname.Location = new Point(115, 67);
            _txtSurname.MaxLength = 255;
            _txtSurname.Name = "txtSurname";
            _txtSurname.Size = new Size(359, 21);
            _txtSurname.TabIndex = 6;
            _txtSurname.Tag = "";
            // 
            // cboRegionID
            // 
            _cboRegionID.Cursor = Cursors.Hand;
            _cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegionID.Location = new Point(328, 166);
            _cboRegionID.Name = "cboRegionID";
            _cboRegionID.Size = new Size(146, 21);
            _cboRegionID.TabIndex = 64;
            _cboRegionID.Tag = "Site.RegionID";
            // 
            // txtPolicyNumber
            // 
            _txtPolicyNumber.Location = new Point(632, 122);
            _txtPolicyNumber.MaxLength = 100;
            _txtPolicyNumber.Name = "txtPolicyNumber";
            _txtPolicyNumber.Size = new Size(223, 21);
            _txtPolicyNumber.TabIndex = 16;
            _txtPolicyNumber.Tag = "";
            // 
            // Label12
            // 
            _Label12.Location = new Point(509, 125);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(112, 20);
            _Label12.TabIndex = 81;
            _Label12.Text = "Policy No/UPRN";
            // 
            // txtTelephoneNum
            // 
            _txtTelephoneNum.Location = new Point(632, 69);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(146, 21);
            _txtTelephoneNum.TabIndex = 13;
            _txtTelephoneNum.Tag = "Site.TelephoneNum";
            // 
            // lblTelephoneNum
            // 
            _lblTelephoneNum.Location = new Point(509, 71);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(107, 20);
            _lblTelephoneNum.TabIndex = 79;
            _lblTelephoneNum.Text = "Tel";
            // 
            // txtAddress4
            // 
            _txtAddress4.Location = new Point(115, 141);
            _txtAddress4.MaxLength = 100;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.Size = new Size(146, 21);
            _txtAddress4.TabIndex = 10;
            _txtAddress4.Tag = "Site.Town";
            // 
            // lblTown
            // 
            _lblTown.Location = new Point(8, 143);
            _lblTown.Name = "lblTown";
            _lblTown.Size = new Size(72, 20);
            _lblTown.TabIndex = 73;
            _lblTown.Text = "Address 4";
            // 
            // txtEmailAddress
            // 
            _txtEmailAddress.Location = new Point(632, 95);
            _txtEmailAddress.MaxLength = 100;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(223, 21);
            _txtEmailAddress.TabIndex = 15;
            _txtEmailAddress.Tag = "Site.EmailAddress";
            // 
            // lblEmailAddress
            // 
            _lblEmailAddress.Location = new Point(510, 98);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(99, 20);
            _lblEmailAddress.TabIndex = 71;
            _lblEmailAddress.Text = "Email Address";
            // 
            // cboSalutation
            // 
            _cboSalutation.Cursor = Cursors.Hand;
            _cboSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSalutation.Location = new Point(116, 42);
            _cboSalutation.Name = "cboSalutation";
            _cboSalutation.Size = new Size(145, 21);
            _cboSalutation.TabIndex = 54;
            _cboSalutation.Tag = "Site.RegionID";
            // 
            // Label18
            // 
            _Label18.Location = new Point(260, 45);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(72, 20);
            _Label18.TabIndex = 59;
            _Label18.Text = "First Name";
            // 
            // txtAddress2
            // 
            _txtAddress2.Location = new Point(115, 117);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(146, 21);
            _txtAddress2.TabIndex = 8;
            _txtAddress2.Tag = "Site.Address2";
            // 
            // lblAddress2
            // 
            _lblAddress2.Location = new Point(8, 120);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(94, 20);
            _lblAddress2.TabIndex = 57;
            _lblAddress2.Text = "Address 2";
            // 
            // btnAddModifyPlan
            // 
            _btnAddModifyPlan.BackColor = Color.LightGoldenrodYellow;
            _btnAddModifyPlan.Cursor = Cursors.Hand;
            _btnAddModifyPlan.Location = new Point(814, 254);
            _btnAddModifyPlan.Margin = new Padding(0);
            _btnAddModifyPlan.Name = "btnAddModifyPlan";
            _btnAddModifyPlan.Size = new Size(192, 23);
            _btnAddModifyPlan.TabIndex = 68;
            _btnAddModifyPlan.Text = "Add / Modify Coverplan";
            _btnAddModifyPlan.UseVisualStyleBackColor = false;
            // 
            // chkCommercialDistrict
            // 
            _chkCommercialDistrict.AutoSize = true;
            _chkCommercialDistrict.Enabled = false;
            _chkCommercialDistrict.Location = new Point(457, 199);
            _chkCommercialDistrict.Name = "chkCommercialDistrict";
            _chkCommercialDistrict.Size = new Size(140, 17);
            _chkCommercialDistrict.TabIndex = 46;
            _chkCommercialDistrict.Text = "Commercial/District";
            _chkCommercialDistrict.UseVisualStyleBackColor = true;
            // 
            // chkLeaseHolder
            // 
            _chkLeaseHolder.AutoSize = true;
            _chkLeaseHolder.Enabled = false;
            _chkLeaseHolder.Location = new Point(328, 199);
            _chkLeaseHolder.Name = "chkLeaseHolder";
            _chkLeaseHolder.Size = new Size(100, 17);
            _chkLeaseHolder.TabIndex = 45;
            _chkLeaseHolder.Text = "Lease Holder";
            _chkLeaseHolder.UseVisualStyleBackColor = true;
            // 
            // chkNoService
            // 
            _chkNoService.AutoCheck = false;
            _chkNoService.AutoSize = true;
            _chkNoService.Location = new Point(216, 199);
            _chkNoService.Name = "chkNoService";
            _chkNoService.Size = new Size(88, 17);
            _chkNoService.TabIndex = 44;
            _chkNoService.Text = "No Service";
            _chkNoService.UseVisualStyleBackColor = true;
            // 
            // chkSolidFuel
            // 
            _chkSolidFuel.AutoSize = true;
            _chkSolidFuel.Enabled = false;
            _chkSolidFuel.Location = new Point(115, 199);
            _chkSolidFuel.Name = "chkSolidFuel";
            _chkSolidFuel.Size = new Size(81, 17);
            _chkSolidFuel.TabIndex = 43;
            _chkSolidFuel.Text = "Solid Fuel";
            _chkSolidFuel.UseVisualStyleBackColor = true;
            // 
            // chkOnStop
            // 
            _chkOnStop.AutoCheck = false;
            _chkOnStop.Font = new Font("Verdana", 8.0F);
            _chkOnStop.Location = new Point(751, 148);
            _chkOnStop.Name = "chkOnStop";
            _chkOnStop.Size = new Size(82, 20);
            _chkOnStop.TabIndex = 42;
            _chkOnStop.Tag = "Site.HeadOffice";
            _chkOnStop.Text = "On Stop";
            // 
            // txtContractStatus
            // 
            _txtContractStatus.Location = new Point(116, 255);
            _txtContractStatus.MaxLength = 100;
            _txtContractStatus.Name = "txtContractStatus";
            _txtContractStatus.ReadOnly = true;
            _txtContractStatus.Size = new Size(667, 21);
            _txtContractStatus.TabIndex = 38;
            _txtContractStatus.Tag = "";
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(3, 285);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(59, 20);
            _lblNotes.TabIndex = 39;
            _lblNotes.Text = "Notes";
            // 
            // chkNoMarketing
            // 
            _chkNoMarketing.Location = new Point(847, 146);
            _chkNoMarketing.Name = "chkNoMarketing";
            _chkNoMarketing.Size = new Size(103, 24);
            _chkNoMarketing.TabIndex = 32;
            _chkNoMarketing.Text = "No Marketing";
            // 
            // btnSendEmailToSite
            // 
            _btnSendEmailToSite.Location = new Point(861, 94);
            _btnSendEmailToSite.Name = "btnSendEmailToSite";
            _btnSendEmailToSite.Size = new Size(145, 23);
            _btnSendEmailToSite.TabIndex = 25;
            _btnSendEmailToSite.Text = "Email";
            // 
            // btnCustomerAudit
            // 
            _btnCustomerAudit.Location = new Point(861, 14);
            _btnCustomerAudit.Name = "btnCustomerAudit";
            _btnCustomerAudit.Size = new Size(145, 23);
            _btnCustomerAudit.TabIndex = 4;
            _btnCustomerAudit.Text = "Audit";
            // 
            // btnDomestic
            // 
            _btnDomestic.BackColor = SystemColors.Control;
            _btnDomestic.Location = new Point(341, 15);
            _btnDomestic.Name = "btnDomestic";
            _btnDomestic.Size = new Size(72, 23);
            _btnDomestic.TabIndex = 2;
            _btnDomestic.Text = "Domestic";
            _btnDomestic.UseVisualStyleBackColor = false;
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(419, 15);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(55, 23);
            _btnFindCustomer.TabIndex = 3;
            _btnFindCustomer.Text = "Search";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomer
            // 
            _txtCustomer.Enabled = false;
            _txtCustomer.Location = new Point(115, 16);
            _txtCustomer.MaxLength = 255;
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.Size = new Size(210, 21);
            _txtCustomer.TabIndex = 1;
            _txtCustomer.Tag = "";
            // 
            // Label10
            // 
            _Label10.Location = new Point(8, 19);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(64, 20);
            _Label10.TabIndex = 0;
            _Label10.Text = "Customer";
            // 
            // txtName
            // 
            _txtName.Location = new Point(632, 43);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(374, 21);
            _txtName.TabIndex = 100;
            _txtName.Tag = "";
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 46);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(122, 20);
            _Label3.TabIndex = 5;
            _Label3.Text = "Primary Contact";
            // 
            // chkHeadOffice
            // 
            _chkHeadOffice.AutoCheck = false;
            _chkHeadOffice.Font = new Font("Verdana", 8.0F);
            _chkHeadOffice.Location = new Point(630, 148);
            _chkHeadOffice.Name = "chkHeadOffice";
            _chkHeadOffice.Size = new Size(104, 20);
            _chkHeadOffice.TabIndex = 30;
            _chkHeadOffice.Tag = "Site.HeadOffice";
            _chkHeadOffice.Text = "Head Office";
            // 
            // txtNotes
            // 
            _txtNotes.Location = new Point(116, 282);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(890, 45);
            _txtNotes.TabIndex = 37;
            _txtNotes.Tag = "Site.Notes";
            // 
            // txtAddress1
            // 
            _txtAddress1.Location = new Point(115, 93);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(359, 21);
            _txtAddress1.TabIndex = 7;
            _txtAddress1.Tag = "Site.Address1";
            // 
            // lblAddress1
            // 
            _lblAddress1.Location = new Point(8, 96);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(67, 20);
            _lblAddress1.TabIndex = 7;
            _lblAddress1.Text = "Address 1";
            // 
            // txtAddress3
            // 
            _txtAddress3.Location = new Point(328, 117);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(146, 21);
            _txtAddress3.TabIndex = 9;
            _txtAddress3.Tag = "Site.Address3";
            // 
            // lblAddress3
            // 
            _lblAddress3.Location = new Point(261, 120);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(64, 20);
            _lblAddress3.TabIndex = 11;
            _lblAddress3.Text = "Address 3";
            // 
            // txtAddress5
            // 
            _txtAddress5.Location = new Point(328, 141);
            _txtAddress5.MaxLength = 100;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.Size = new Size(146, 21);
            _txtAddress5.TabIndex = 11;
            _txtAddress5.Tag = "Site.County";
            // 
            // lblCounty
            // 
            _lblCounty.Location = new Point(262, 143);
            _lblCounty.Name = "lblCounty";
            _lblCounty.Size = new Size(64, 20);
            _lblCounty.TabIndex = 15;
            _lblCounty.Text = "Address 5";
            // 
            // txtPostcode
            // 
            _txtPostcode.Location = new Point(115, 167);
            _txtPostcode.MaxLength = 10;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(146, 21);
            _txtPostcode.TabIndex = 12;
            _txtPostcode.Tag = "Site.Postcode";
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(8, 167);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(73, 20);
            _lblPostcode.TabIndex = 17;
            _lblPostcode.Text = "Postcode";
            // 
            // txtFaxNum
            // 
            _txtFaxNum.Location = new Point(861, 68);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(145, 21);
            _txtFaxNum.TabIndex = 14;
            _txtFaxNum.Tag = "Site.FaxNum";
            // 
            // lblFaxNum
            // 
            _lblFaxNum.Location = new Point(799, 72);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(50, 20);
            _lblFaxNum.TabIndex = 21;
            _lblFaxNum.Text = "Mobile";
            // 
            // lblContractInactive
            // 
            _lblContractInactive.BackColor = Color.Red;
            _lblContractInactive.Location = new Point(109, 252);
            _lblContractInactive.Name = "lblContractInactive";
            _lblContractInactive.Size = new Size(682, 27);
            _lblContractInactive.TabIndex = 31;
            _lblContractInactive.Visible = false;
            // 
            // Label14
            // 
            _Label14.Location = new Point(3, 257);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(93, 20);
            _Label14.TabIndex = 37;
            _Label14.Text = "Contract";
            // 
            // lblRegionID
            // 
            _lblRegionID.Location = new Point(261, 166);
            _lblRegionID.Name = "lblRegionID";
            _lblRegionID.Size = new Size(62, 20);
            _lblRegionID.TabIndex = 63;
            _lblRegionID.Text = "Region";
            // 
            // GroupBox4
            // 
            _GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _GroupBox4.Controls.Add(_btnSiteReport);
            _GroupBox4.Controls.Add(_btnShowVisits);
            _GroupBox4.Controls.Add(_cboDefinition);
            _GroupBox4.Controls.Add(_Label9);
            _GroupBox4.Controls.Add(_txtJobNumber);
            _GroupBox4.Controls.Add(_Label7);
            _GroupBox4.Controls.Add(_dtpTo);
            _GroupBox4.Controls.Add(_Label6);
            _GroupBox4.Controls.Add(_dtpFrom);
            _GroupBox4.Controls.Add(_Label5);
            _GroupBox4.Controls.Add(_dgJobs);
            _GroupBox4.Controls.Add(_btnAddJob);
            _GroupBox4.Controls.Add(_btnShowAllJobs);
            _GroupBox4.Controls.Add(_btnRemoveJob);
            _GroupBox4.Location = new Point(3, 421);
            _GroupBox4.Margin = new Padding(0);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Padding = new Padding(0);
            _GroupBox4.Size = new Size(575, 219);
            _GroupBox4.TabIndex = 1;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Jobs";
            // 
            // btnSiteReport
            // 
            _btnSiteReport.Location = new Point(457, 161);
            _btnSiteReport.Name = "btnSiteReport";
            _btnSiteReport.Size = new Size(96, 23);
            _btnSiteReport.TabIndex = 13;
            _btnSiteReport.Text = "Site Report";
            _btnSiteReport.UseVisualStyleBackColor = true;
            // 
            // btnShowVisits
            // 
            _btnShowVisits.Location = new Point(457, 132);
            _btnShowVisits.Name = "btnShowVisits";
            _btnShowVisits.Size = new Size(96, 23);
            _btnShowVisits.TabIndex = 12;
            _btnShowVisits.Text = "Show History";
            _btnShowVisits.UseVisualStyleBackColor = true;
            // 
            // cboDefinition
            // 
            _cboDefinition.Location = new Point(200, 40);
            _cboDefinition.Name = "cboDefinition";
            _cboDefinition.Size = new Size(104, 21);
            _cboDefinition.TabIndex = 7;
            _cboDefinition.Visible = false;
            // 
            // Label9
            // 
            _Label9.Location = new Point(152, 40);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(40, 23);
            _Label9.TabIndex = 6;
            _Label9.Text = "Def.:";
            _Label9.Visible = false;
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Location = new Point(350, 16);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(84, 21);
            _txtJobNumber.TabIndex = 3;
            // 
            // Label7
            // 
            _Label7.Location = new Point(298, 19);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(67, 23);
            _Label7.TabIndex = 2;
            _Label7.Text = "Job No:";
            // 
            // dtpTo
            // 
            _dtpTo.Checked = false;
            _dtpTo.Format = DateTimePickerFormat.Short;
            _dtpTo.Location = new Point(186, 16);
            _dtpTo.Name = "dtpTo";
            _dtpTo.ShowCheckBox = true;
            _dtpTo.Size = new Size(104, 21);
            _dtpTo.TabIndex = 5;
            // 
            // Label6
            // 
            _Label6.Location = new Point(156, 19);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(24, 23);
            _Label6.TabIndex = 4;
            _Label6.Text = "To:";
            // 
            // dtpFrom
            // 
            _dtpFrom.Checked = false;
            _dtpFrom.Format = DateTimePickerFormat.Short;
            _dtpFrom.Location = new Point(48, 16);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.ShowCheckBox = true;
            _dtpFrom.Size = new Size(104, 21);
            _dtpFrom.TabIndex = 1;
            // 
            // Label5
            // 
            _Label5.Location = new Point(8, 19);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(40, 23);
            _Label5.TabIndex = 0;
            _Label5.Text = "From:";
            // 
            // dgJobs
            // 
            _dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgJobs.DataMember = "";
            _dgJobs.HeaderForeColor = SystemColors.ControlText;
            _dgJobs.Location = new Point(5, 45);
            _dgJobs.Name = "dgJobs";
            _dgJobs.Size = new Size(431, 169);
            _dgJobs.TabIndex = 11;
            // 
            // btnAddJob
            // 
            _btnAddJob.Location = new Point(457, 45);
            _btnAddJob.Name = "btnAddJob";
            _btnAddJob.Size = new Size(96, 23);
            _btnAddJob.TabIndex = 9;
            _btnAddJob.Text = "Add";
            // 
            // btnShowAllJobs
            // 
            _btnShowAllJobs.Location = new Point(457, 103);
            _btnShowAllJobs.Name = "btnShowAllJobs";
            _btnShowAllJobs.Size = new Size(96, 23);
            _btnShowAllJobs.TabIndex = 8;
            _btnShowAllJobs.Text = "Show All";
            // 
            // btnRemoveJob
            // 
            _btnRemoveJob.Location = new Point(457, 74);
            _btnRemoveJob.Name = "btnRemoveJob";
            _btnRemoveJob.Size = new Size(96, 23);
            _btnRemoveJob.TabIndex = 10;
            _btnRemoveJob.Text = "Delete";
            // 
            // TabNewContacts
            // 
            _TabNewContacts.Controls.Add(_pnlContactsMain);
            _TabNewContacts.Location = new Point(4, 22);
            _TabNewContacts.Name = "TabNewContacts";
            _TabNewContacts.Padding = new Padding(3);
            _TabNewContacts.Size = new Size(1072, 640);
            _TabNewContacts.TabIndex = 13;
            _TabNewContacts.Text = "Contacts";
            _TabNewContacts.UseVisualStyleBackColor = true;
            // 
            // pnlContactsMain
            // 
            _pnlContactsMain.Dock = DockStyle.Fill;
            _pnlContactsMain.Location = new Point(3, 3);
            _pnlContactsMain.Name = "pnlContactsMain";
            _pnlContactsMain.Size = new Size(1066, 634);
            _pnlContactsMain.TabIndex = 0;
            // 
            // tabCharges
            // 
            _tabCharges.Controls.Add(_gpbCharges);
            _tabCharges.Location = new Point(4, 22);
            _tabCharges.Name = "tabCharges";
            _tabCharges.Size = new Size(1072, 640);
            _tabCharges.TabIndex = 8;
            _tabCharges.Text = "Charges";
            // 
            // gpbCharges
            // 
            _gpbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbCharges.Controls.Add(_chbAcceptChargeChanges);
            _gpbCharges.Controls.Add(_pnlCharges);
            _gpbCharges.Controls.Add(_Label2);
            _gpbCharges.Controls.Add(_txtRatesMarkup);
            _gpbCharges.Controls.Add(_Label4);
            _gpbCharges.Controls.Add(_Label8);
            _gpbCharges.Controls.Add(_txtMileageRate);
            _gpbCharges.Controls.Add(_txtPartsMarkup);
            _gpbCharges.Location = new Point(8, 8);
            _gpbCharges.Name = "gpbCharges";
            _gpbCharges.Size = new Size(1056, 626);
            _gpbCharges.TabIndex = 60;
            _gpbCharges.TabStop = false;
            _gpbCharges.Text = "Charges";
            // 
            // chbAcceptChargeChanges
            // 
            _chbAcceptChargeChanges.BackColor = SystemColors.Info;
            _chbAcceptChargeChanges.Location = new Point(8, 16);
            _chbAcceptChargeChanges.Name = "chbAcceptChargeChanges";
            _chbAcceptChargeChanges.Size = new Size(480, 24);
            _chbAcceptChargeChanges.TabIndex = 61;
            _chbAcceptChargeChanges.Text = "Always accept changes to default charges made at customer level";
            _chbAcceptChargeChanges.UseVisualStyleBackColor = false;
            // 
            // pnlCharges
            // 
            _pnlCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlCharges.Location = new Point(8, 88);
            _pnlCharges.Name = "pnlCharges";
            _pnlCharges.Size = new Size(1040, 530);
            _pnlCharges.TabIndex = 59;
            // 
            // Label2
            // 
            _Label2.Location = new Point(296, 48);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(88, 23);
            _Label2.TabIndex = 58;
            _Label2.Text = "Rates Markup";
            // 
            // txtRatesMarkup
            // 
            _txtRatesMarkup.Location = new Point(384, 48);
            _txtRatesMarkup.Name = "txtRatesMarkup";
            _txtRatesMarkup.Size = new Size(48, 21);
            _txtRatesMarkup.TabIndex = 5;
            // 
            // Label4
            // 
            _Label4.Location = new Point(8, 48);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(95, 23);
            _Label4.TabIndex = 48;
            _Label4.Text = "Labour Markup";
            // 
            // Label8
            // 
            _Label8.Location = new Point(155, 48);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(88, 23);
            _Label8.TabIndex = 56;
            _Label8.Text = "Parts Markup";
            // 
            // txtMileageRate
            // 
            _txtMileageRate.Location = new Point(104, 48);
            _txtMileageRate.Name = "txtMileageRate";
            _txtMileageRate.Size = new Size(48, 21);
            _txtMileageRate.TabIndex = 0;
            // 
            // txtPartsMarkup
            // 
            _txtPartsMarkup.Location = new Point(244, 48);
            _txtPartsMarkup.Name = "txtPartsMarkup";
            _txtPartsMarkup.Size = new Size(48, 21);
            _txtPartsMarkup.TabIndex = 4;
            // 
            // tabContacts
            // 
            _tabContacts.Controls.Add(_btnPrintLetters);
            _tabContacts.Controls.Add(_btnEmail);
            _tabContacts.Controls.Add(_GroupBox1);
            _tabContacts.Controls.Add(_btnDeleteContact);
            _tabContacts.Controls.Add(_btnAddContact);
            _tabContacts.Location = new Point(4, 22);
            _tabContacts.Name = "tabContacts";
            _tabContacts.Size = new Size(1072, 640);
            _tabContacts.TabIndex = 3;
            _tabContacts.Text = "Associated Contacts";
            // 
            // btnPrintLetters
            // 
            _btnPrintLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnPrintLetters.Location = new Point(136, 612);
            _btnPrintLetters.Name = "btnPrintLetters";
            _btnPrintLetters.Size = new Size(112, 25);
            _btnPrintLetters.TabIndex = 6;
            _btnPrintLetters.Text = "Print Letters";
            // 
            // btnEmail
            // 
            _btnEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnEmail.Location = new Point(72, 612);
            _btnEmail.Name = "btnEmail";
            _btnEmail.Size = new Size(56, 25);
            _btnEmail.TabIndex = 5;
            _btnEmail.Text = "Email";
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgContacts);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(1056, 596);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Contacts";
            // 
            // dgContacts
            // 
            _dgContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgContacts.DataMember = "";
            _dgContacts.HeaderForeColor = SystemColors.ControlText;
            _dgContacts.Location = new Point(6, 20);
            _dgContacts.Name = "dgContacts";
            _dgContacts.Size = new Size(1045, 568);
            _dgContacts.TabIndex = 1;
            // 
            // btnDeleteContact
            // 
            _btnDeleteContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteContact.Location = new Point(1008, 612);
            _btnDeleteContact.Name = "btnDeleteContact";
            _btnDeleteContact.Size = new Size(56, 25);
            _btnDeleteContact.TabIndex = 3;
            _btnDeleteContact.Text = "Delete";
            // 
            // btnAddContact
            // 
            _btnAddContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddContact.Location = new Point(8, 612);
            _btnAddContact.Name = "btnAddContact";
            _btnAddContact.Size = new Size(56, 25);
            _btnAddContact.TabIndex = 2;
            _btnAddContact.Text = "Add";
            // 
            // tabInvoiceAddress
            // 
            _tabInvoiceAddress.Controls.Add(_GroupBox2);
            _tabInvoiceAddress.Controls.Add(_btnDeleteAddress);
            _tabInvoiceAddress.Controls.Add(_btnAddAddress);
            _tabInvoiceAddress.Location = new Point(4, 22);
            _tabInvoiceAddress.Name = "tabInvoiceAddress";
            _tabInvoiceAddress.Size = new Size(1072, 640);
            _tabInvoiceAddress.TabIndex = 4;
            _tabInvoiceAddress.Text = "Invoice Addresses";
            // 
            // GroupBox2
            // 
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_dgInvoiceAddresses);
            _GroupBox2.Location = new Point(8, 8);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(1056, 594);
            _GroupBox2.TabIndex = 6;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Invoice Addresses";
            // 
            // dgInvoiceAddresses
            // 
            _dgInvoiceAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoiceAddresses.DataMember = "";
            _dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddresses.Location = new Point(6, 20);
            _dgInvoiceAddresses.Name = "dgInvoiceAddresses";
            _dgInvoiceAddresses.Size = new Size(1045, 569);
            _dgInvoiceAddresses.TabIndex = 1;
            // 
            // btnDeleteAddress
            // 
            _btnDeleteAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteAddress.Location = new Point(1000, 610);
            _btnDeleteAddress.Name = "btnDeleteAddress";
            _btnDeleteAddress.Size = new Size(64, 23);
            _btnDeleteAddress.TabIndex = 3;
            _btnDeleteAddress.Text = "Delete";
            // 
            // btnAddAddress
            // 
            _btnAddAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddAddress.Location = new Point(8, 610);
            _btnAddAddress.Name = "btnAddAddress";
            _btnAddAddress.Size = new Size(58, 23);
            _btnAddAddress.TabIndex = 2;
            _btnAddAddress.Text = "Add";
            // 
            // tabDocuments
            // 
            _tabDocuments.Controls.Add(_pnlDocuments);
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(1072, 640);
            _tabDocuments.TabIndex = 2;
            _tabDocuments.Text = "Documents";
            // 
            // pnlDocuments
            // 
            _pnlDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlDocuments.Location = new Point(0, 0);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(1072, 642);
            _pnlDocuments.TabIndex = 1;
            // 
            // tabQuotes
            // 
            _tabQuotes.Controls.Add(_pnlQuotes);
            _tabQuotes.Location = new Point(4, 22);
            _tabQuotes.Name = "tabQuotes";
            _tabQuotes.Size = new Size(1072, 640);
            _tabQuotes.TabIndex = 7;
            _tabQuotes.Text = "Quotes";
            // 
            // pnlQuotes
            // 
            _pnlQuotes.Dock = DockStyle.Fill;
            _pnlQuotes.Location = new Point(0, 0);
            _pnlQuotes.Name = "pnlQuotes";
            _pnlQuotes.Size = new Size(1072, 640);
            _pnlQuotes.TabIndex = 1;
            // 
            // tabContracts
            // 
            _tabContracts.Controls.Add(_gpbContracts);
            _tabContracts.Location = new Point(4, 22);
            _tabContracts.Name = "tabContracts";
            _tabContracts.Size = new Size(1072, 640);
            _tabContracts.TabIndex = 9;
            _tabContracts.Text = "Contracts";
            // 
            // gpbContracts
            // 
            _gpbContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbContracts.Controls.Add(_btnDeleteContract);
            _gpbContracts.Controls.Add(_dgContracts);
            _gpbContracts.Controls.Add(_btnAddContract);
            _gpbContracts.Location = new Point(8, 8);
            _gpbContracts.Name = "gpbContracts";
            _gpbContracts.Size = new Size(1056, 626);
            _gpbContracts.TabIndex = 1;
            _gpbContracts.TabStop = false;
            _gpbContracts.Text = "Contract - Double click to view";
            // 
            // btnDeleteContract
            // 
            _btnDeleteContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteContract.Location = new Point(973, 594);
            _btnDeleteContract.Name = "btnDeleteContract";
            _btnDeleteContract.Size = new Size(75, 23);
            _btnDeleteContract.TabIndex = 2;
            _btnDeleteContract.Text = "Delete";
            // 
            // dgContracts
            // 
            _dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgContracts.DataMember = "";
            _dgContracts.HeaderForeColor = SystemColors.ControlText;
            _dgContracts.Location = new Point(8, 20);
            _dgContracts.Name = "dgContracts";
            _dgContracts.Size = new Size(1040, 566);
            _dgContracts.TabIndex = 1;
            // 
            // btnAddContract
            // 
            _btnAddContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddContract.Location = new Point(8, 594);
            _btnAddContract.Name = "btnAddContract";
            _btnAddContract.Size = new Size(75, 23);
            _btnAddContract.TabIndex = 0;
            _btnAddContract.Text = "Add";
            _btnAddContract.UseVisualStyleBackColor = true;
            // 
            // tpNotes
            // 
            _tpNotes.Controls.Add(_gpbNotesDetails);
            _tpNotes.Controls.Add(_gpbNotes);
            _tpNotes.Location = new Point(4, 22);
            _tpNotes.Name = "tpNotes";
            _tpNotes.Padding = new Padding(3);
            _tpNotes.Size = new Size(1072, 640);
            _tpNotes.TabIndex = 10;
            _tpNotes.Text = "Notes";
            // 
            // gpbNotesDetails
            // 
            _gpbNotesDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _gpbNotesDetails.Controls.Add(_txtNoteID);
            _gpbNotesDetails.Controls.Add(_btnSaveNote);
            _gpbNotesDetails.Controls.Add(_txtNote);
            _gpbNotesDetails.Controls.Add(_Label15);
            _gpbNotesDetails.Location = new Point(6, 451);
            _gpbNotesDetails.Name = "gpbNotesDetails";
            _gpbNotesDetails.Size = new Size(1060, 183);
            _gpbNotesDetails.TabIndex = 34;
            _gpbNotesDetails.TabStop = false;
            _gpbNotesDetails.Text = "Details";
            // 
            // txtNoteID
            // 
            _txtNoteID.Location = new Point(66, 14);
            _txtNoteID.Name = "txtNoteID";
            _txtNoteID.Size = new Size(100, 21);
            _txtNoteID.TabIndex = 36;
            _txtNoteID.TabStop = false;
            _txtNoteID.Visible = false;
            // 
            // btnSaveNote
            // 
            _btnSaveNote.AccessibleDescription = "";
            _btnSaveNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveNote.Location = new Point(975, 154);
            _btnSaveNote.Name = "btnSaveNote";
            _btnSaveNote.Size = new Size(79, 23);
            _btnSaveNote.TabIndex = 1;
            _btnSaveNote.Text = "Save";
            // 
            // txtNote
            // 
            _txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNote.Location = new Point(6, 37);
            _txtNote.Multiline = true;
            _txtNote.Name = "txtNote";
            _txtNote.ScrollBars = ScrollBars.Both;
            _txtNote.Size = new Size(1048, 111);
            _txtNote.TabIndex = 0;
            // 
            // Label15
            // 
            _Label15.Location = new Point(3, 20);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(88, 23);
            _Label15.TabIndex = 34;
            _Label15.Text = "Note:";
            // 
            // gpbNotes
            // 
            _gpbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbNotes.Controls.Add(_btnDeleteNote);
            _gpbNotes.Controls.Add(_dgNotes);
            _gpbNotes.Controls.Add(_btnAddNote);
            _gpbNotes.Location = new Point(6, 6);
            _gpbNotes.Name = "gpbNotes";
            _gpbNotes.Size = new Size(1060, 439);
            _gpbNotes.TabIndex = 31;
            _gpbNotes.TabStop = false;
            _gpbNotes.Text = "Notes";
            // 
            // btnDeleteNote
            // 
            _btnDeleteNote.AccessibleDescription = "";
            _btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteNote.Location = new Point(969, 410);
            _btnDeleteNote.Name = "btnDeleteNote";
            _btnDeleteNote.Size = new Size(85, 23);
            _btnDeleteNote.TabIndex = 3;
            _btnDeleteNote.Text = "Delete";
            _btnDeleteNote.Visible = false;
            // 
            // dgNotes
            // 
            _dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgNotes.DataMember = "";
            _dgNotes.HeaderForeColor = SystemColors.ControlText;
            _dgNotes.Location = new Point(6, 20);
            _dgNotes.Name = "dgNotes";
            _dgNotes.Size = new Size(1048, 384);
            _dgNotes.TabIndex = 1;
            // 
            // btnAddNote
            // 
            _btnAddNote.AccessibleDescription = "";
            _btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddNote.Location = new Point(6, 410);
            _btnAddNote.Name = "btnAddNote";
            _btnAddNote.Size = new Size(85, 23);
            _btnAddNote.TabIndex = 2;
            _btnAddNote.Text = "Add";
            // 
            // tabAuthority
            // 
            _tabAuthority.Controls.Add(_grpSiteAuth);
            _tabAuthority.Controls.Add(_gpCustAuth);
            _tabAuthority.Controls.Add(_grpAudit);
            _tabAuthority.Location = new Point(4, 22);
            _tabAuthority.Name = "tabAuthority";
            _tabAuthority.Size = new Size(1072, 640);
            _tabAuthority.TabIndex = 11;
            _tabAuthority.Text = "Authority";
            _tabAuthority.UseVisualStyleBackColor = true;
            // 
            // grpSiteAuth
            // 
            _grpSiteAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpSiteAuth.Controls.Add(_btnSaveAuth);
            _grpSiteAuth.Controls.Add(_txtSiteAuth);
            _grpSiteAuth.Location = new Point(3, 117);
            _grpSiteAuth.Name = "grpSiteAuth";
            _grpSiteAuth.Size = new Size(1060, 207);
            _grpSiteAuth.TabIndex = 37;
            _grpSiteAuth.TabStop = false;
            _grpSiteAuth.Text = "Site";
            // 
            // btnSaveAuth
            // 
            _btnSaveAuth.AccessibleDescription = "";
            _btnSaveAuth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveAuth.Location = new Point(969, 178);
            _btnSaveAuth.Name = "btnSaveAuth";
            _btnSaveAuth.Size = new Size(85, 23);
            _btnSaveAuth.TabIndex = 3;
            _btnSaveAuth.Text = "Save";
            // 
            // txtSiteAuth
            // 
            _txtSiteAuth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtSiteAuth.Location = new Point(6, 20);
            _txtSiteAuth.Multiline = true;
            _txtSiteAuth.Name = "txtSiteAuth";
            _txtSiteAuth.ScrollBars = ScrollBars.Both;
            _txtSiteAuth.Size = new Size(1048, 152);
            _txtSiteAuth.TabIndex = 0;
            // 
            // gpCustAuth
            // 
            _gpCustAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpCustAuth.Controls.Add(_txtCustAuthority);
            _gpCustAuth.Location = new Point(3, 3);
            _gpCustAuth.Name = "gpCustAuth";
            _gpCustAuth.Size = new Size(1060, 108);
            _gpCustAuth.TabIndex = 36;
            _gpCustAuth.TabStop = false;
            _gpCustAuth.Text = "Customer";
            // 
            // txtCustAuthority
            // 
            _txtCustAuthority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCustAuthority.Location = new Point(6, 20);
            _txtCustAuthority.Multiline = true;
            _txtCustAuthority.Name = "txtCustAuthority";
            _txtCustAuthority.ReadOnly = true;
            _txtCustAuthority.ScrollBars = ScrollBars.Both;
            _txtCustAuthority.Size = new Size(1048, 82);
            _txtCustAuthority.TabIndex = 0;
            // 
            // grpAudit
            // 
            _grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAudit.Controls.Add(_dgAuthorityAudit);
            _grpAudit.Location = new Point(3, 330);
            _grpAudit.Name = "grpAudit";
            _grpAudit.Size = new Size(1060, 307);
            _grpAudit.TabIndex = 35;
            _grpAudit.TabStop = false;
            _grpAudit.Text = "Audit";
            // 
            // dgAuthorityAudit
            // 
            _dgAuthorityAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAuthorityAudit.DataMember = "";
            _dgAuthorityAudit.HeaderForeColor = SystemColors.ControlText;
            _dgAuthorityAudit.Location = new Point(6, 20);
            _dgAuthorityAudit.Name = "dgAuthorityAudit";
            _dgAuthorityAudit.Size = new Size(1048, 281);
            _dgAuthorityAudit.TabIndex = 1;
            // 
            // tpAdditionalDetails
            // 
            _tpAdditionalDetails.BackColor = SystemColors.Control;
            _tpAdditionalDetails.Controls.Add(_grpAdditionalDetails);
            _tpAdditionalDetails.Location = new Point(4, 22);
            _tpAdditionalDetails.Name = "tpAdditionalDetails";
            _tpAdditionalDetails.Padding = new Padding(3);
            _tpAdditionalDetails.Size = new Size(1072, 640);
            _tpAdditionalDetails.TabIndex = 12;
            _tpAdditionalDetails.Text = "Additional Details";
            // 
            // grpAdditionalDetails
            // 
            _grpAdditionalDetails.Controls.Add(_btnLetterReport);
            _grpAdditionalDetails.Controls.Add(_cboReasonForContact);
            _grpAdditionalDetails.Controls.Add(_Label11);
            _grpAdditionalDetails.Controls.Add(_Label13);
            _grpAdditionalDetails.Controls.Add(_cboSourceOfCustomer);
            _grpAdditionalDetails.Controls.Add(_txtEstateOfficer);
            _grpAdditionalDetails.Controls.Add(_lblEstateOfficer);
            _grpAdditionalDetails.Controls.Add(_txtHousingManager);
            _grpAdditionalDetails.Controls.Add(_lblHousingManager);
            _grpAdditionalDetails.Controls.Add(_txtHousingOfficer);
            _grpAdditionalDetails.Controls.Add(_lblHousingOfficer);
            _grpAdditionalDetails.Controls.Add(_dtpBuildDate);
            _grpAdditionalDetails.Controls.Add(_lblBuildDate);
            _grpAdditionalDetails.Controls.Add(_txtWarrantyPeriod);
            _grpAdditionalDetails.Controls.Add(_lblWarrantyPeriod);
            _grpAdditionalDetails.Dock = DockStyle.Fill;
            _grpAdditionalDetails.Location = new Point(3, 3);
            _grpAdditionalDetails.Name = "grpAdditionalDetails";
            _grpAdditionalDetails.Size = new Size(1066, 634);
            _grpAdditionalDetails.TabIndex = 0;
            _grpAdditionalDetails.TabStop = false;
            _grpAdditionalDetails.Text = "Additional Details";
            // 
            // btnLetterReport
            // 
            _btnLetterReport.Location = new Point(586, 29);
            _btnLetterReport.Name = "btnLetterReport";
            _btnLetterReport.Size = new Size(145, 23);
            _btnLetterReport.TabIndex = 132;
            _btnLetterReport.Text = "Letter Report";
            // 
            // cboReasonForContact
            // 
            _cboReasonForContact.Cursor = Cursors.Hand;
            _cboReasonForContact.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboReasonForContact.Location = new Point(136, 31);
            _cboReasonForContact.Name = "cboReasonForContact";
            _cboReasonForContact.Size = new Size(149, 21);
            _cboReasonForContact.TabIndex = 131;
            _cboReasonForContact.Tag = "Site.RegionID";
            // 
            // Label11
            // 
            _Label11.Location = new Point(315, 34);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(71, 23);
            _Label11.TabIndex = 128;
            _Label11.Text = "Source";
            // 
            // Label13
            // 
            _Label13.Location = new Point(16, 34);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(129, 23);
            _Label13.TabIndex = 130;
            _Label13.Text = "Reason For Contact";
            // 
            // cboSourceOfCustomer
            // 
            _cboSourceOfCustomer.Cursor = Cursors.Hand;
            _cboSourceOfCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSourceOfCustomer.Location = new Point(404, 31);
            _cboSourceOfCustomer.Name = "cboSourceOfCustomer";
            _cboSourceOfCustomer.Size = new Size(145, 21);
            _cboSourceOfCustomer.TabIndex = 129;
            _cboSourceOfCustomer.Tag = "Site.RegionID";
            // 
            // txtEstateOfficer
            // 
            _txtEstateOfficer.Location = new Point(404, 114);
            _txtEstateOfficer.MaxLength = 100;
            _txtEstateOfficer.Name = "txtEstateOfficer";
            _txtEstateOfficer.Size = new Size(145, 21);
            _txtEstateOfficer.TabIndex = 124;
            _txtEstateOfficer.Tag = "";
            // 
            // lblEstateOfficer
            // 
            _lblEstateOfficer.Location = new Point(315, 117);
            _lblEstateOfficer.Name = "lblEstateOfficer";
            _lblEstateOfficer.Size = new Size(99, 20);
            _lblEstateOfficer.TabIndex = 123;
            _lblEstateOfficer.Text = "Estate Officer";
            // 
            // txtHousingManager
            // 
            _txtHousingManager.Location = new Point(136, 154);
            _txtHousingManager.MaxLength = 100;
            _txtHousingManager.Name = "txtHousingManager";
            _txtHousingManager.Size = new Size(149, 21);
            _txtHousingManager.TabIndex = 122;
            _txtHousingManager.Tag = "";
            // 
            // lblHousingManager
            // 
            _lblHousingManager.Location = new Point(16, 157);
            _lblHousingManager.Name = "lblHousingManager";
            _lblHousingManager.Size = new Size(110, 20);
            _lblHousingManager.TabIndex = 121;
            _lblHousingManager.Text = "Housing Manager";
            // 
            // txtHousingOfficer
            // 
            _txtHousingOfficer.Location = new Point(136, 114);
            _txtHousingOfficer.MaxLength = 100;
            _txtHousingOfficer.Name = "txtHousingOfficer";
            _txtHousingOfficer.Size = new Size(149, 21);
            _txtHousingOfficer.TabIndex = 118;
            _txtHousingOfficer.Tag = "";
            // 
            // lblHousingOfficer
            // 
            _lblHousingOfficer.Location = new Point(16, 117);
            _lblHousingOfficer.Name = "lblHousingOfficer";
            _lblHousingOfficer.Size = new Size(99, 20);
            _lblHousingOfficer.TabIndex = 117;
            _lblHousingOfficer.Text = "Housing Officer";
            // 
            // dtpBuildDate
            // 
            _dtpBuildDate.Location = new Point(136, 71);
            _dtpBuildDate.Name = "dtpBuildDate";
            _dtpBuildDate.Size = new Size(149, 21);
            _dtpBuildDate.TabIndex = 116;
            _dtpBuildDate.Value = new DateTime(2019, 5, 22, 14, 54, 59, 0);
            // 
            // lblBuildDate
            // 
            _lblBuildDate.Location = new Point(16, 77);
            _lblBuildDate.Name = "lblBuildDate";
            _lblBuildDate.Size = new Size(88, 20);
            _lblBuildDate.TabIndex = 115;
            _lblBuildDate.Text = "Build Date";
            // 
            // txtWarrantyPeriod
            // 
            _txtWarrantyPeriod.Location = new Point(477, 74);
            _txtWarrantyPeriod.MaxLength = 100;
            _txtWarrantyPeriod.Name = "txtWarrantyPeriod";
            _txtWarrantyPeriod.Size = new Size(72, 21);
            _txtWarrantyPeriod.TabIndex = 114;
            _txtWarrantyPeriod.Tag = "";
            // 
            // lblWarrantyPeriod
            // 
            _lblWarrantyPeriod.Location = new Point(315, 77);
            _lblWarrantyPeriod.Name = "lblWarrantyPeriod";
            _lblWarrantyPeriod.Size = new Size(141, 20);
            _lblWarrantyPeriod.TabIndex = 113;
            _lblWarrantyPeriod.Text = "Warranty Period (mths)";
            // 
            // cmsJobs
            // 
            _cmsJobs.Items.AddRange(new ToolStripItem[] { _tsmiMoveJob });
            _cmsJobs.Name = "cmsJobs";
            _cmsJobs.Size = new Size(126, 26);
            // 
            // tsmiMoveJob
            // 
            _tsmiMoveJob.Name = "tsmiMoveJob";
            _tsmiMoveJob.Size = new Size(125, 22);
            _tsmiMoveJob.Text = "Move Job";
            // 
            // UCSite
            // 
            Controls.Add(_tcSites);
            Name = "UCSite";
            Size = new Size(1080, 666);
            _tcSites.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpSiteFuel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).EndInit();
            _grpSite.ResumeLayout(false);
            _grpSite.PerformLayout();
            _GroupBox4.ResumeLayout(false);
            _GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).EndInit();
            _TabNewContacts.ResumeLayout(false);
            _tabCharges.ResumeLayout(false);
            _gpbCharges.ResumeLayout(false);
            _gpbCharges.PerformLayout();
            _tabContacts.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgContacts).EndInit();
            _tabInvoiceAddress.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).EndInit();
            _tabDocuments.ResumeLayout(false);
            _tabQuotes.ResumeLayout(false);
            _tabContracts.ResumeLayout(false);
            _gpbContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgContracts).EndInit();
            _tpNotes.ResumeLayout(false);
            _gpbNotesDetails.ResumeLayout(false);
            _gpbNotesDetails.PerformLayout();
            _gpbNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgNotes).EndInit();
            _tabAuthority.ResumeLayout(false);
            _grpSiteAuth.ResumeLayout(false);
            _grpSiteAuth.PerformLayout();
            _gpCustAuth.ResumeLayout(false);
            _gpCustAuth.PerformLayout();
            _grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAuthorityAudit).EndInit();
            _tpAdditionalDetails.ResumeLayout(false);
            _grpAdditionalDetails.ResumeLayout(false);
            _grpAdditionalDetails.PerformLayout();
            _cmsJobs.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            tcSites.TabPages.Clear();
            tcSites.TabPages.Add(tabDetails);
            if (App.IsGasway)
            {
                tcSites.TabPages.Add(tabContracts);
                tcSites.TabPages.Add(tabQuotes);
                tcSites.TabPages.Add(tabCharges);
            }

            tcSites.TabPages.Add(TabNewContacts);
            tcSites.TabPages.Add(tabContacts);
            tcSites.TabPages.Add(tabInvoiceAddress);
            tcSites.TabPages.Add(tabDocuments);
            tcSites.TabPages.Add(tpNotes);
            tcSites.TabPages.Add(tabAuthority);
            tcSites.TabPages.Add(tpAdditionalDetails);
            ContactControl = new UCContacts(CurrentSite);
            pnlContactsMain.Controls.Add(ContactControl);
            SetupContactDataGrid();
            SetupInvoiceAddressDataGrid();
            SetupJobsDataGrid();
            SetupSiteFuelDataGrid();
            SetupContractsDataGrid();
            SetupNotesDataGrid();
            SetupSiteAuthorityAuditDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentSite;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private UCDocumentsList DocumentsControl;
        private UCQuotesList QuotesControl;
        private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
        private UCContacts ContactControl;

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Form _FromForm;

        public Form FromForm
        {
            get
            {
                return _FromForm;
            }

            set
            {
                _FromForm = value;
            }
        }

        private Entity.Customers.Customer _currentCustomer;

        public Entity.Customers.Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }

            set
            {
                _currentCustomer = value;
                if (_currentCustomer is null)
                {
                    _currentCustomer = new Entity.Customers.Customer();
                    _currentCustomer.Exists = false;
                    var settings = new Entity.Management.Settings();
                    settings = App.DB.Manager.Get();
                    _currentCustomer.SetAcceptChargesChanges = true;
                }

                if (_currentCustomer.Exists)
                {
                }
                else
                {
                    gpbContracts.Enabled = false;
                }
            }
        }

        private Entity.Sites.Site _currentSite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _currentSite;
            }

            set
            {
                _currentSite = value;
                if (App.IsRFT)
                {
                    btnDomestic.Visible = false;
                    btnConvCust.Visible = false;
                    btnLetterReport.Visible = false;
                    chkSolidFuel.Visible = false;
                    btnAddModifyPlan.Visible = false;
                    tcSites.TabPages.Remove(tabQuotes);
                }

                if (CurrentSite is null)
                {
                    _currentSite = new Entity.Sites.Site();
                    _currentSite.Exists = false;
                    var customerCharges = new Entity.CustomerCharges.CustomerCharge();
                    customerCharges = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(App.CurrentCustomerID);
                    if (customerCharges is object)
                    {
                        txtMileageRate.Text = customerCharges.MileageRate.ToString();
                        txtPartsMarkup.Text = customerCharges.PartsMarkup.ToString();
                        txtRatesMarkup.Text = customerCharges.RatesMarkup.ToString();
                    }
                    else
                    {
                        var sysCharges = new Entity.Management.Settings();
                        sysCharges = App.DB.Manager.Get();
                        txtMileageRate.Text = sysCharges.MileageRate.ToString();
                        txtPartsMarkup.Text = sysCharges.PartsMarkup.ToString();
                        txtRatesMarkup.Text = sysCharges.RatesMarkup.ToString();
                    }

                    btnAddAddress.Enabled = false;
                    btnDeleteAddress.Enabled = false;
                    btnAddContact.Enabled = false;
                    btnDeleteContact.Enabled = false;
                    btnAddJob.Enabled = false;
                    btnRemoveJob.Enabled = false;
                    chbAcceptChargeChanges.Checked = true;
                    if (App.CurrentCustomerID > 0)
                    {
                        CurrentSite.SetCustomerID = App.CurrentCustomerID;
                        PopulateCustomerField();
                    }
                }

                if (CurrentSite.Exists)
                {
                    CurrentCustomer = App.DB.Customer.Customer_Get(CurrentSite.CustomerID);
                    Populate();
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblSite, CurrentSite.SiteID);
                    pnlDocuments.Controls.Add(DocumentsControl);
                    pnlQuotes.Controls.Clear();
                    QuotesControl = new UCQuotesList(Enums.TableNames.tblSite, CurrentSite.CustomerID, CurrentSite.SiteID);
                    QuotesControl.RefreshJobs += PopulateJobs;
                    pnlQuotes.Controls.Add(QuotesControl);
                    pnlCharges.Controls.Clear();
                    CustomerScheduleOfRateControl = new UCCustomerScheduleOfRate(Enums.TableNames.tblCustomer, CurrentSite.CustomerID, true);
                    pnlCharges.Controls.Add(CustomerScheduleOfRateControl);
                    Contracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
                    gpbContracts.Enabled = true;
                    btnAddAddress.Enabled = true;
                    btnDeleteAddress.Enabled = true;
                    btnAddContact.Enabled = true;
                    btnDeleteContact.Enabled = true;
                    btnAddJob.Enabled = true;
                    btnRemoveJob.Enabled = true;
                    cboSourceOfCustomer.Enabled = false;
                    cboReasonForContact.Enabled = false;
                    PopulateSiteNotes();
                    gpbNotes.Enabled = true;
                    gpbNotesDetails.Enabled = true;
                    btnSaveNote.Enabled = true;
                    btnAddNote.Enabled = true;
                    btnDeleteNote.Enabled = true;
                    btnLetterReport.Enabled = true;
                }
                else
                {
                    cboSourceOfCustomer.Enabled = true;
                    cboReasonForContact.Enabled = true;
                    gpbNotes.Enabled = false;
                    gpbNotesDetails.Enabled = false;
                    btnSaveNote.Enabled = false;
                    btnAddNote.Enabled = false;
                    btnDeleteNote.Enabled = false;
                    btnLetterReport.Enabled = false;
                }

                PopulateContacts();
                PopulateInvoiceAddresses();
                PopulateJobs();
            }
        }

        private DataView _dInvoiceTable = null;

        public DataView InvoiceAddressDataView
        {
            get
            {
                return _dInvoiceTable;
            }

            set
            {
                _dInvoiceTable = value;
                _dInvoiceTable.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
                _dInvoiceTable.AllowNew = false;
                _dInvoiceTable.AllowEdit = false;
                _dInvoiceTable.AllowDelete = false;
                dgInvoiceAddresses.DataSource = InvoiceAddressDataView;
            }
        }

        private DataRow SelectedInvoiceAddressDataRow
        {
            get
            {
                if (!(dgInvoiceAddresses.CurrentRowIndex == -1))
                {
                    return InvoiceAddressDataView[dgInvoiceAddresses.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dcontactTable = null;

        public DataView ContactsDataView
        {
            get
            {
                return _dcontactTable;
            }

            set
            {
                _dcontactTable = value;
                _dcontactTable.Table.TableName = Enums.TableNames.tblContact.ToString();
                _dcontactTable.AllowNew = false;
                _dcontactTable.AllowEdit = false;
                _dcontactTable.AllowDelete = false;
                dgContacts.DataSource = ContactsDataView;
            }
        }

        private DataRow SelectedContactDataRow
        {
            get
            {
                if (!(dgContacts.CurrentRowIndex == -1))
                {
                    return ContactsDataView[dgContacts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _jobsTable = null;

        public DataView JobsDataView
        {
            get
            {
                return _jobsTable;
            }

            set
            {
                _jobsTable = value;
                _jobsTable.Table.TableName = Enums.TableNames.tblJob.ToString();
                _jobsTable.AllowNew = false;
                _jobsTable.AllowEdit = false;
                _jobsTable.AllowDelete = false;
                dgJobs.DataSource = JobsDataView;
            }
        }

        private DataRow SelectedJobDataRow
        {
            get
            {
                if (!(dgJobs.CurrentRowIndex == -1))
                {
                    return JobsDataView[dgJobs.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        private Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
            }
        }

        private DataView _dvContracts;

        public DataView Contracts
        {
            get
            {
                return _dvContracts;
            }

            set
            {
                _dvContracts = value;
                _dvContracts.Table.TableName = Enums.TableNames.tblContract.ToString();
                _dvContracts.AllowNew = false;
                _dvContracts.AllowEdit = false;
                _dvContracts.AllowDelete = false;
                dgContracts.DataSource = Contracts;
            }
        }

        private DataRow SelectedContractDataRow
        {
            get
            {
                if (!(dgContracts.CurrentRowIndex == -1))
                {
                    return Contracts[dgContracts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _SelectedCustomerID = 0;

        private int SelectedCustomerID
        {
            get
            {
                return _SelectedCustomerID;
            }

            set
            {
                _SelectedCustomerID = value;
            }
        }

        private Entity.Authority.Authority _oSiteAuthority;

        public Entity.Authority.Authority SiteAuthority
        {
            get
            {
                return _oSiteAuthority;
            }

            set
            {
                _oSiteAuthority = value;
            }
        }

        private bool FlagShown = false;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupContactDataGrid()
        {
            Helper.SetUpDataGrid(dgContacts);
            var tStyle = dgContacts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var FirstName = new DataGridLabelColumn();
            FirstName.Format = "";
            FirstName.FormatInfo = null;
            FirstName.HeaderText = "First Name";
            FirstName.MappingName = "FirstName";
            FirstName.ReadOnly = true;
            FirstName.Width = 160;
            FirstName.NullText = "";
            tStyle.GridColumnStyles.Add(FirstName);
            var Surname = new DataGridLabelColumn();
            Surname.Format = "";
            Surname.FormatInfo = null;
            Surname.HeaderText = "Surname";
            Surname.MappingName = "Surname";
            Surname.ReadOnly = true;
            Surname.Width = 160;
            Surname.NullText = "";
            tStyle.GridColumnStyles.Add(Surname);
            var Email = new DataGridLabelColumn();
            Email.Format = "";
            Email.FormatInfo = null;
            Email.HeaderText = "Email";
            Email.MappingName = "EmailAddress";
            Email.ReadOnly = true;
            Email.Width = 120;
            Email.NullText = "";
            tStyle.GridColumnStyles.Add(Email);
            var TelephoneNum = new DataGridLabelColumn();
            TelephoneNum.Format = "";
            TelephoneNum.FormatInfo = null;
            TelephoneNum.HeaderText = "Telephone Number";
            TelephoneNum.MappingName = "TelephoneNum";
            TelephoneNum.ReadOnly = true;
            TelephoneNum.Width = 100;
            TelephoneNum.NullText = "";
            tStyle.GridColumnStyles.Add(TelephoneNum);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContact.ToString();
            dgContacts.TableStyles.Add(tStyle);
        }

        public void SetupInvoiceAddressDataGrid()
        {
            Helper.SetUpDataGrid(dgInvoiceAddresses);
            var tStyle = dgInvoiceAddresses.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 100;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 100;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 100;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 100;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 100;
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
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddresses.TableStyles.Add(tStyle);
        }

        public void SetupJobsDataGrid()
        {
            Helper.SetUpDataGrid(dgJobs);
            var tStyle = dgJobs.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MM/yyyy";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 75;
            DateCreated.NullText = "";
            tStyle.GridColumnStyles.Add(DateCreated);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job No";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Visit Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 75;
            VisitStatus.NullText = "";
            tStyle.GridColumnStyles.Add(VisitStatus);
            var LastVisitDate = new DataGridLabelColumn();
            LastVisitDate.Format = "dd/MM/yyyy";
            LastVisitDate.FormatInfo = null;
            LastVisitDate.HeaderText = "Last Visit's Date";
            LastVisitDate.MappingName = "LastVisitDate";
            LastVisitDate.ReadOnly = true;
            LastVisitDate.Width = 100;
            LastVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(LastVisitDate);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblJob.ToString();
            dgJobs.TableStyles.Add(tStyle);
        }

        public void SetupSiteFuelDataGrid()
        {
            Helper.SetUpDataGrid(dgSiteFuel);
            var tStyle = dgSiteFuel.TableStyles[0];
            var fuelType = new DataGridSiteFuelColumn();
            fuelType.Format = "";
            fuelType.FormatInfo = null;
            fuelType.HeaderText = "Fuel Type";
            fuelType.MappingName = "FuelType";
            fuelType.ReadOnly = true;
            fuelType.Width = 100;
            fuelType.NullText = "";
            tStyle.GridColumnStyles.Add(fuelType);
            var serviceDue = new DataGridSiteFuelColumn();
            serviceDue.Format = "dd/MM/yyyy";
            serviceDue.FormatInfo = null;
            serviceDue.HeaderText = "Service Due";
            serviceDue.MappingName = "ServiceDue";
            serviceDue.ReadOnly = true;
            serviceDue.Width = 105;
            serviceDue.NullText = "N/A";
            tStyle.GridColumnStyles.Add(serviceDue);
            var lastServiceDate = new DataGridSiteFuelColumn();
            lastServiceDate.Format = "dd/MM/yyyy";
            lastServiceDate.FormatInfo = null;
            lastServiceDate.HeaderText = "Service Date";
            lastServiceDate.MappingName = "ActualServiceDate";
            lastServiceDate.ReadOnly = true;
            lastServiceDate.Width = 105;
            lastServiceDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(lastServiceDate);
            var FuelChargeType = new DataGridSiteFuelColumn();
            FuelChargeType.Format = "dd/MM/yyyy";
            FuelChargeType.FormatInfo = null;
            FuelChargeType.HeaderText = "Charge Type";
            FuelChargeType.MappingName = "FuelChargeType";
            FuelChargeType.ReadOnly = true;
            FuelChargeType.Width = 170;
            FuelChargeType.NullText = "";
            tStyle.GridColumnStyles.Add(FuelChargeType);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblSiteFuel.ToString();
            dgSiteFuel.TableStyles.Add(tStyle);
        }

        public void SetupContractsDataGrid()
        {
            var tStyle = dgContracts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ContractType = new DataGridLabelColumn();
            ContractType.Format = "";
            ContractType.FormatInfo = null;
            ContractType.HeaderText = "Contract Type";
            ContractType.MappingName = "Type";
            ContractType.ReadOnly = true;
            ContractType.Width = 100;
            ContractType.NullText = "";
            tStyle.GridColumnStyles.Add(ContractType);
            var ContractReference = new DataGridLabelColumn();
            ContractReference.Format = "";
            ContractReference.FormatInfo = null;
            ContractReference.HeaderText = "Contract Reference";
            ContractReference.MappingName = "ContractReference";
            ContractReference.ReadOnly = true;
            ContractReference.Width = 150;
            ContractReference.NullText = "";
            tStyle.GridColumnStyles.Add(ContractReference);
            var ContractStatus = new DataGridLabelColumn();
            ContractStatus.Format = "";
            ContractStatus.FormatInfo = null;
            ContractStatus.HeaderText = "Contract Status";
            ContractStatus.MappingName = "ContractStatus";
            ContractStatus.ReadOnly = true;
            ContractStatus.Width = 100;
            ContractStatus.NullText = "";
            tStyle.GridColumnStyles.Add(ContractStatus);
            var ContractStartDate = new DataGridLabelColumn();
            ContractStartDate.Format = "dd/MM/yyyy";
            ContractStartDate.FormatInfo = null;
            ContractStartDate.HeaderText = "Start Date";
            ContractStartDate.MappingName = "ContractStartDate";
            ContractStartDate.ReadOnly = true;
            ContractStartDate.Width = 100;
            ContractStartDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ContractStartDate);
            var ContractEndDate = new DataGridLabelColumn();
            ContractEndDate.Format = "dd/MM/yyyy";
            ContractEndDate.FormatInfo = null;
            ContractEndDate.HeaderText = "End Date";
            ContractEndDate.MappingName = "ContractEndDate";
            ContractEndDate.ReadOnly = true;
            ContractEndDate.Width = 100;
            ContractEndDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ContractEndDate);
            var ContractPrice = new DataGridLabelColumn();
            ContractPrice.Format = "C";
            ContractPrice.FormatInfo = null;
            ContractPrice.HeaderText = "Contract Price";
            ContractPrice.MappingName = "ContractPrice";
            ContractPrice.ReadOnly = true;
            ContractPrice.Width = 100;
            ContractPrice.NullText = "";
            tStyle.GridColumnStyles.Add(ContractPrice);
            var PartCosts = new DataGridLabelColumn();
            PartCosts.Format = "C";
            PartCosts.FormatInfo = null;
            PartCosts.HeaderText = "Material Costs";
            PartCosts.MappingName = "PartCosts";
            PartCosts.ReadOnly = true;
            PartCosts.Width = 100;
            PartCosts.NullText = "";
            tStyle.GridColumnStyles.Add(PartCosts);
            var LabourCosts = new DataGridLabelColumn();
            LabourCosts.Format = "C";
            LabourCosts.FormatInfo = null;
            LabourCosts.HeaderText = "Labour Costs";
            LabourCosts.MappingName = "LabourCosts";
            LabourCosts.ReadOnly = true;
            LabourCosts.Width = 100;
            LabourCosts.NullText = "";
            tStyle.GridColumnStyles.Add(LabourCosts);
            var ContractPaymentIncome = new DataGridLabelColumn();
            ContractPaymentIncome.Format = "C";
            ContractPaymentIncome.FormatInfo = null;
            ContractPaymentIncome.HeaderText = "Contract Payment Income";
            ContractPaymentIncome.MappingName = "ContractPaymentIncome";
            ContractPaymentIncome.ReadOnly = true;
            ContractPaymentIncome.Width = 120;
            ContractPaymentIncome.NullText = "";
            tStyle.GridColumnStyles.Add(ContractPaymentIncome);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContract.ToString();
            dgContracts.TableStyles.Add(tStyle);
        }

        public void CheckServiceDate()
        {
            if (FlagShown == false)
            {
                if (SiteFuelsDataView is object & !CurrentSite.CommercialDistrict)
                {
                    string message = string.Empty;
                    foreach (DataRow fuel in SiteFuelsDataView.Table.Rows)
                        message += GenerateServiceMessage(Helper.MakeDateTimeValid(fuel["LastServiceDate"]), Helper.MakeStringValid(fuel["FuelType"]), message);
                    if (Helper.IsStringEmpty(message))
                    {
                        message += GenerateServiceMessage(Helper.MakeDateTimeValid(CurrentSite.LastServiceDate), Helper.MakeStringValid(CurrentSite.SiteFuel), message);
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        App.ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FlagShown = true;
                    }
                }
            }
        }

        private string GenerateServiceMessage(DateTime serviceDate, string fuel, string message)
        {
            var nowdate = DateAndTime.Today;
            var duedate = nowdate.AddMonths(3);
            serviceDate = serviceDate.AddYears(1);
            fuel = Helper.IsStringEmpty(fuel) ? "N/A" : fuel;
            if (serviceDate >= nowdate & serviceDate <= duedate)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message += Constants.vbCrLf + Constants.vbCrLf;
                }

                message += fuel + " is due for service within the next 3 months";
            }
            else if (!(serviceDate == DateTime.MinValue.AddYears(1)) && DateHelper.IsBetweenDates(Conversions.ToString(DateAndTime.Now.AddYears(-3)), Conversions.ToString(DateAndTime.Now), Conversions.ToString(serviceDate)))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message += Constants.vbCrLf + Constants.vbCrLf;
                }

                message += fuel + " is Overdue";
            }

            return message;
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { 0, Helper.MakeIntegerValid(CurrentSite.CustomerID), Helper.MakeIntegerValid(CurrentSite.SiteID) });
            Contracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is null)
            {
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool deleteContract = true;
            deleteContract = DeleteOption1();
            if (deleteContract)
            {
                Contracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
            }
            else
            {
                App.ShowMessage("Cannot delete the contract - there are active jobs on properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgContracts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]), Helper.MakeIntegerValid(CurrentSite.CustomerID) });
            Contracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
        }

        private void cboDefinition_SelectedIndexChanged(object sender, EventArgs e)
        {
            runFilters();
        }

        private void txtJobNumber_TextChanged(object sender, EventArgs e)
        {
            runFilters();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            runFilters();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            runFilters();
        }

        private void btnShowAllJobs_Click(object sender, EventArgs e)
        {
            JobsDataView = App.DB.Job.Job_GetTop_For_Site(CurrentSite.SiteID, CurrentSite.CustomerID, 1000);
        }

        private void UCSite_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgContacts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedContactDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMContact), true, new object[] { Helper.MakeIntegerValid(SelectedContactDataRow["ContactID"]), CurrentSite.SiteID, this });
        }

        private void dgInvoiceAddresses_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedInvoiceAddressDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMInvoiceAddress), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceAddressDataRow["InvoiceAddressID"]), CurrentSite.SiteID, this });
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMContact), true, new object[] { 0, CurrentSite.SiteID, this });
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMInvoiceAddress), true, new object[] { 0, CurrentSite.SiteID, this });
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (SelectedContactDataRow is null)
            {
                App.ShowMessage("Please select a contact to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.Contact.Delete(Helper.MakeIntegerValid(SelectedContactDataRow["ContactID"]));
            ContactsDataView = App.DB.Contact.Contact_GetForSite(CurrentSite.SiteID);
        }

        private void btnDeleteAddress_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceAddressDataRow is null)
            {
                App.ShowMessage("Please select an invoice address to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.InvoiceAddress.Delete(Helper.MakeIntegerValid(SelectedInvoiceAddressDataRow["InvoiceAddressID"]));
            InvoiceAddressDataView = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(CurrentSite.SiteID);
        }

        private void dgJobs_Click(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                btnRemoveJob.Enabled = false;
                return;
            }

            var switchExpr = Conversions.ToInteger(SelectedJobDataRow["JobDefinitionEnumID"]);
            switch (switchExpr)
            {
                case Conversions.ToInteger(Enums.JobDefinition.Quoted):
                    {
                        btnRemoveJob.Enabled = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.JobDefinition.Contract):
                    {
                        btnRemoveJob.Enabled = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.JobDefinition.Callout):
                    {
                        btnRemoveJob.Enabled = true;
                        break;
                    }

                case Conversions.ToInteger(Enums.JobDefinition.Misc):
                    {
                        btnRemoveJob.Enabled = true;
                        break;
                    }

                default:
                    {
                        btnRemoveJob.Enabled = false;
                        break;
                    }
            }
        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {
            int customerStatus = App.DB.Customer.Customer_Get(CurrentSite.CustomerID).Status;
            Enums.SecuritySystemModules ssm;
            ssm = Enums.SecuritySystemModules.Finance;
            if (chkOnStop.Checked & !App.loggedInUser.HasAccessToModule(ssm))
            {
                string msg = "This property is on stop and you do not have the necessary security permissions to change this." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
            else if (customerStatus == Conversions.ToInteger(Enums.CustomerStatus.OnHold) & !App.loggedInUser.HasAccessToModule(ssm))
            {
                string msg = "The customer is on hold and you do not have the necessary security permissions to change this." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
            else if (chkOnStop.Checked)
            {
                if (App.ShowMessage("This property is on stop. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else if (customerStatus == Conversions.ToInteger(Enums.CustomerStatus.OnHold))
            {
                if (App.ShowMessage("The customer is on hold. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
            }

            if (App.loggedInUser.UserRegions.Count > 0)
            {
                if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + CurrentSite.RegionID).Length < 1)
                {
                    string msg = "You do not have the necessary security permissions to add a job." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            else if (CurrentSite.RegionID != App.loggedInUser.UserID)
            {
                string msg = "You do not have the necessary security permissions to add a job." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (string.IsNullOrEmpty(CurrentSite.TelephoneNum) & string.IsNullOrEmpty(CurrentSite.FaxNum) & string.IsNullOrEmpty(CurrentSite.EmailAddress))
            {
                if (App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            if ((chkLeaseHolder.Checked | dtpDefectEndDate.Value >= DateAndTime.Now) & !App.IsGasway)
            {
                if (App.ShowMessage("There are warnings against the site!" + Constants.vbCrLf + Constants.vbCrLf + "Please refer to the notes." + Constants.vbCrLf + Constants.vbCrLf + "Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { 0, CurrentSite.SiteID, this });
        }

        private void dgJobs_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedJobDataRow["JobID"], CurrentSite.SiteID, this });
        }

        private void btnRemoveJob_Click(object sender, EventArgs e)
        {
            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) == false)
            {
                string msg = "You do not have the necessary security permissions to delete a job." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (App.loggedInUser.UserRegions.Count > 0)
            {
                if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + CurrentSite.RegionID).Length < 1)
                {
                    string msg = "You do not have the necessary security permissions to delete a job." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            else if (CurrentSite.RegionID != App.loggedInUser.UserID)
            {
                string msg = "You do not have the necessary security permissions to delete a job." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedJobDataRow is null)
            {
                App.ShowMessage("Please select a job to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin) == false)
            {
                if (!(Conversions.ToInteger(SelectedJobDataRow["StatusEnumID"]) == Conversions.ToInteger(Enums.JobStatus.Open)))
                {
                    App.ShowMessage("Job has progressed passed 'Open' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!App.DB.Job.Job_Check_Before_Delete(Conversions.ToInteger(SelectedJobDataRow["JobID"])))
                {
                    App.ShowMessage("At least 1 visit has progressed passed 'Ready' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (App.ShowMessage("Are you sure you want to remove this job from the system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.Job.Job_Delete(Conversions.ToInteger(SelectedJobDataRow["JobID"]));
            PopulateJobs();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (SelectedContactDataRow is object)
            {
                var myProcess = new Process();
                myProcess.StartInfo.FileName = Conversions.ToString("mailto:" + SelectedContactDataRow["EmailAddress"]);
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.RedirectStandardOutput = false;
                myProcess.Start();
                myProcess.Dispose();
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            if (CurrentSite is null || !CurrentSite.Exists)
            {
            }
            else
            {
                int customerType = App.DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID;
                if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) == false & customerType == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
                {
                    string msg = "You do not have the necessary security permissions to change site to customer." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }

            SelectedCustomerID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (SelectedCustomerID == 0)
                return;
            var custCheck = App.DB.Customer.Customer_Get(SelectedCustomerID);
            if (custCheck is object)
            {
                if (custCheck.Status == (int)Enums.CustomerStatus.OnHold)
                {
                    if (!(App.ShowMessage("Customer On Hold. Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        return;
                    }
                }
            }

            if (CurrentSite is null || !CurrentSite.Exists)
            {
                PopulateCustomerField();
            }
            else
            {
                if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) == false & custCheck.CustomerTypeID == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
                {
                    string msg = "You do not have the necessary security permissions to change site to customer." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }

                if (App.ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    App.DB.Sites.Update_Customer(CurrentSite.SiteID, CurrentSite.CustomerID, SelectedCustomerID);
                    CurrentSite = App.DB.Sites.Get(CurrentSite.SiteID);
                }
            }
        }

        private void btnDomestic_Click(object sender, EventArgs e)
        {
            if (CurrentSite is null || !CurrentSite.Exists)
            {
                SelectedCustomerID = (int)Enums.Customer.Domestic;
                PopulateCustomerField();
            }
            else
            {
                int customerType = App.DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID;
                if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) == false & customerType == Conversions.ToInteger(Enums.CustomerType.SocialHousing)) // social housing
                {
                    string msg = "You do not have the necessary security permissions to change site to customer." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }

                SelectedCustomerID = (int)Enums.Customer.Domestic;
                if (App.ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    App.DB.Sites.Update_Customer(CurrentSite.SiteID, CurrentSite.CustomerID, SelectedCustomerID);
                    CurrentSite = App.DB.Sites.Get(CurrentSite.SiteID);
                }
            }
        }

        private void btnCustomerAudit_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSiteCustomerAudit), true, new object[] { CurrentSite.SiteID });
        }

        private void btnSendEmailToSite_Click(object sender, EventArgs e)
        {
            var myProcess = new Process();
            myProcess.StartInfo.FileName = "mailto:" + CurrentSite.EmailAddress;
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.RedirectStandardOutput = false;
            myProcess.Start();
            myProcess.Dispose();
        }

        private void btnPrintLetters_Click(object sender, EventArgs e)
        {
            int contactID = 0;
            if (SelectedContactDataRow is null)
            {
            }
            // ShowMessage("Select a contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
            // Exit Sub
            else
            {
                contactID = Conversions.ToInteger(SelectedContactDataRow["ContactID"]);
            }

            var details = new ArrayList();
            details.Add(contactID);
            details.Add(CurrentSite.SiteID);
            var oPrint = new Printing(details, "SiteLetter", Enums.SystemDocumentType.SiteLetter);
            // Refresh documents
            pnlDocuments.Controls.Clear();
            DocumentsControl = new UCDocumentsList(Enums.TableNames.tblSite, CurrentSite.SiteID);
            pnlDocuments.Controls.Add(DocumentsControl);
        }

        private void btnShowVisits_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSiteVisitManager), true, new object[] { CurrentSite.SiteID });
        }

        private void btnSiteReport_Click(object sender, EventArgs e)
        {
            PdfFactory.GenerateSiteHistoryReport(CurrentSite);
        }

        private void chkOnStop_Click(object sender, EventArgs e)
        {
            if (App.ControlLoading == false)
            {
                App.ControlLoading = true;
                Enums.SecuritySystemModules ssm;
                ssm = Enums.SecuritySystemModules.Finance;
                if (App.loggedInUser.HasAccessToModule(ssm) == false)
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    App.ControlLoading = false;
                    throw new System.Security.SecurityException(msg);
                }
                else if (chkOnStop.Checked)
                {
                    chkOnStop.Checked = false;
                }
                else
                {
                    chkOnStop.Checked = true;
                }

                App.ControlLoading = false;
            }
        }

        private void chkNoService_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing))
            {
                string msg = "You do not have the necessary security permissions to adjust this setting." + Constants.vbCrLf + "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (chkNoService.Checked)
            {
                chkNoService.Checked = false;
            }
            else
            {
                chkNoService.Checked = true;
            }
        }

        private void ChkVoid_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Voids))
            {
                string msg = "You do not have the necessary security permissions to adjust this setting." + Constants.vbCrLf + "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (CurrentSite.Exists)
            {
                if (chkVoid.Checked == true)
                {
                    if (App.ShowMessage("This property is void. " + Constants.vbCrLf + "Do you want to reinstate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    if (App.ShowMessage("Would you like to use the previous contact information?. ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var dvSiteContacts = App.DB.Contact.Contacts_GetAll_ForLink(Conversions.ToInteger(Enums.TableNames.tblSite), CurrentSite.SiteID, true);
                        if (dvSiteContacts.Count > 0)
                        {
                            var drSiteContact = (from row in dvSiteContacts.Table.AsEnumerable()
                                                 orderby row.Field<int>("ContactID") descending
                                                 select row).FirstOrDefault();
                            if (drSiteContact.Table.Rows.Count > 0)
                            {
                                txtTelephoneNum.Text = Helper.MakeStringValid(drSiteContact["TelephoneNo"]);
                                txtFaxNum.Text = Helper.MakeStringValid(drSiteContact["MobileNo"]);
                                txtEmailAddress.Text = Helper.MakeStringValid(drSiteContact["EmailAddress"]);
                                txtName.Text = Helper.MakeStringValid(drSiteContact["ContactID"]);
                                var argcombo = cboSalutation;
                                Combo.SetSelectedComboItem_By_Description(ref argcombo, Helper.MakeStringValid(drSiteContact["Title"]));
                                txtFirstName.Text = Helper.MakeStringValid(drSiteContact["FirstName"]);
                                txtSurname.Text = Helper.MakeStringValid(drSiteContact["LastName"]);
                            }
                        }
                    }

                    chkVoid.Checked = false;
                    lblPropertyVoidDate.Visible = false;
                    txtPropertyVoidDate.Visible = false;
                    CurrentSite.PropertyVoidDate = default;
                    Save();
                    App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid(txtNoteID.Text), "Site reinstated", App.loggedInUser.UserID, CurrentSite.SiteID, App.loggedInUser.UserID);
                }
                else
                {
                    try
                    {
                        if (App.ShowMessage("All contact information will be wiped.".ToUpper() + Constants.vbCrLf + Constants.vbCrLf + "Do you want to mark this property as void?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }

                        DateTime voidDate = default;
                        var f = new FRMContractUpgradeDowngrade();
                        f.Text = "Select Date";
                        f.lblText.Text = "Please select void date";
                        f.ShowDialog();
                        if (f.DialogResult == DialogResult.OK)
                        {
                            voidDate = f.EffDate;
                        }
                        else
                        {
                            return;
                        }

                        var currentContact = new Entity.Contacts.Contact()
                        {
                            SetSalutation = Combo.get_GetSelectedItemDescription(cboSalutation),
                            SetFirstName = Helper.MakeStringValid(txtFirstName.Text),
                            SetSurname = Helper.MakeStringValid(txtSurname.Text),
                            SetMobileNo = Helper.MakeStringValid(txtFaxNum.Text),
                            SetTelephoneNum = Helper.MakeStringValid(txtTelephoneNum.Text),
                            SetEmailAddress = Helper.MakeStringValid(txtEmailAddress.Text),
                            SetNoMarketing = chkNoMarketing.Checked,
                            SetLinkID = Conversions.ToInteger(Enums.TableNames.tblSite),
                            SetLinkRef = CurrentSite.SiteID
                        };
                        currentContact.SetContactID = App.DB.Contact.Contacts_Update(currentContact);
                        var dvSiteContacts = App.DB.Contact.Contacts_GetAll_ForLink(Conversions.ToInteger(Enums.TableNames.tblSite), CurrentSite.SiteID);
                        foreach (DataRow drSiteContact in dvSiteContacts.Table.Rows)
                        {
                            if (!App.DB.Contact.Contacts_Delete(Helper.MakeIntegerValid(drSiteContact["ContactID"])))
                                throw new Exception("Failed to delete!");
                        }

                        ClearContactForVoid();
                        chkVoid.Checked = true;
                        lblPropertyVoidDate.Visible = true;
                        txtPropertyVoidDate.Visible = true;
                        txtPropertyVoidDate.Text = voidDate.ToString("dd/MM/yyyy");
                        CurrentSite.PropertyVoidDate = voidDate;
                        Save();
                        App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid(txtNoteID.Text), "Site marked as void", App.loggedInUser.UserID, CurrentSite.SiteID, App.loggedInUser.UserID);
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (chkVoid.Checked)
            {
                chkVoid.Checked = false;
            }
            else
            {
                chkVoid.Checked = true;
            }
        }

        private void btnLetterReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var dtLetters = App.DB.LetterManager.LetterReport(CurrentSite.SiteID);
                if (dtLetters.Rows.Count < 3)
                {
                    App.ShowMessage("This site has had less than 3 letter visits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    var details = new ArrayList();
                    details.Add(dtLetters);
                    // Public Sub New(detailsToPrintIn,documentNameIn, printTypeIn,multipleDocs, Optional ByVal OrderID As Integer = 0, Optional ByVal isEmail As Boolean = False, Optional ByVal ApptsPerDay As Integer = 13, Optional ByVal CustomerID As Integer = Nothing, Optional ByVal LetterCreationDate As DateTime = Nothing)
                    var oPrint = new Printing(details, "Letter Report", Enums.SystemDocumentType.ServiceLetterReport, true, CustomerID: CurrentSite.CustomerID);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void runFilters()
        {
            if (JobsDataView is object)
            {
                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDefinition)) == 0))
                {
                    JobsDataView.RowFilter = "JobDefinitionEnumID = '" + Combo.get_GetSelectedItemValue(cboDefinition) + "'";
                }

                if (JobsDataView.RowFilter.Length > 0)
                {
                    JobsDataView.RowFilter += " AND JobNumber LIKE '%" + txtJobNumber.Text + "%'";
                }
                else
                {
                    JobsDataView.RowFilter += "JobNumber LIKE '%" + txtJobNumber.Text + "%'";
                }

                if (dtpFrom.Checked == true)
                {
                    if (JobsDataView.RowFilter.Length > 0)
                    {
                        JobsDataView.RowFilter += " AND DateCreated >= '" + dtpFrom.Value.Date + "'";
                    }
                    else
                    {
                        JobsDataView.RowFilter += "DateCreated >= '" + dtpFrom.Value.Date + "'";
                    }
                }

                if (dtpTo.Checked == true)
                {
                    if (JobsDataView.RowFilter.Length > 0)
                    {
                        JobsDataView.RowFilter += " AND DateCreated <= '" + dtpTo.Value.Date + "'";
                    }
                    else
                    {
                        JobsDataView.RowFilter += "DateCreated <= '" + dtpTo.Value.Date + "'";
                    }
                }
            }
        }

        private void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentSite = App.DB.Sites.Get(ID);
            }

            var currentContract = App.DB.ContractOriginal.Get_Current_ForSite(CurrentSite.SiteID);
            if (currentContract is null)
            {
                txtContractStatus.Text = "Not on contract";
                var allContracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
                if (allContracts.Table.Rows.Count > 0)
                {
                    lblContractInactive.Visible = true;
                }
                else
                {
                    lblContractInactive.Visible = false;
                }
            }
            else
            {
                txtContractStatus.Text = currentContract.ContractType + " ";
                if (currentContract.GasSupplyPipework == true | currentContract.PlumbingDrainage == true | currentContract.WindowLockPest == true)
                {
                    if (currentContract.GasSupplyPipework == true & currentContract.PlumbingDrainage == true & currentContract.WindowLockPest == true)
                    {
                        txtContractStatus.Text += " + Complete Home Emergency Cover ";
                    }
                    else
                    {
                        if (currentContract.GasSupplyPipework == true)
                        {
                            txtContractStatus.Text += " + Gas Supply Pipework ";
                        }

                        if (currentContract.PlumbingDrainage == true)
                        {
                            txtContractStatus.Text += " + Plumbing, Drainage and Electrical ";
                        }

                        if (currentContract.WindowLockPest == true)
                        {
                            txtContractStatus.Text += " + Window and Pest ";
                        }
                    }
                }

                txtContractStatus.Text += ", " + ((Enums.ContractStatus)Conversions.ToInteger(currentContract.ContractStatusID)).ToString() + ", " + Strings.Format(currentContract.ContractStartDate, "dd/MM/yyyy") + "-" + Strings.Format(currentContract.ContractEndDate, "dd/MM/yyyy");
                if (currentContract.ContractStatusID == Conversions.ToInteger(Enums.ContractStatus.Inactive) | currentContract.ContractStatusID == Conversions.ToInteger(Enums.ContractStatus.Cancelled) | Conversions.ToDate(Strings.Format(currentContract.ContractEndDate, "dd-MMM-yyyy") + " 23:59:59") < DateAndTime.Now)
                {
                    lblContractInactive.Visible = true;
                }
                else
                {
                    lblContractInactive.Visible = false;
                }

                var dvContractSite = App.DB.ContractOriginalSite.GetAll_ContractID2(currentContract.ContractID, 0);
                if (dvContractSite.Count > 0)
                {
                    var dvMainApp = App.DB.ContractOriginal.GetAssetsForContract(Conversions.ToInteger(dvContractSite.Table.Rows[0]["ContractSiteID"]), true);
                    if (dvMainApp.Count > 0)
                    {
                        txtContractStatus.Text += ", Main Apps: " + string.Join(", ", dvMainApp.Table.AsEnumerable().Select(r => r.Field<string>("Product")).ToArray());
                    }

                    var dvSecondApp = App.DB.ContractOriginal.GetAssetsForContract(Conversions.ToInteger(dvContractSite.Table.Rows[0]["ContractSiteID"]), false);
                    if (dvSecondApp.Count > 0)
                    {
                        txtContractStatus.Text += ", Second Apps: " + string.Join(", ", dvSecondApp.Table.AsEnumerable().Select(r => r.Field<string>("Product")).ToArray());
                    }
                }
            }

            var argcombo = cboRegionID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentSite.RegionID.ToString());
            if (!CurrentSite.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
            {
                cboRegionID.Enabled = false;
            }

            if ((CurrentCustomer?.CustomerTypeID == Conversions.ToInteger(Enums.CustomerType.SocialHousing) & !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.SocialHousingSecurity)) == true)
            {
                chkHeadOffice.Enabled = false;
            }

            chkHeadOffice.Checked = CurrentSite.HeadOffice;
            txtNotes.Text = CurrentSite.Notes;
            txtAsbestos.Text = CurrentSite.Asbestos;
            txtAddress1.Text = CurrentSite.Address1;
            txtAddress2.Text = CurrentSite.Address2;
            txtAddress3.Text = CurrentSite.Address3;
            txtAddress4.Text = CurrentSite.Address4;
            txtAddress5.Text = CurrentSite.Address5;
            txtPostcode.Text = CurrentSite.Postcode;
            if (CurrentCustomer?.CustomerTypeID == (int?)Enums.CustomerType.SocialHousing == true)
            {
                txtAddress1.ReadOnly = true;
                txtAddress2.ReadOnly = true;
                txtAddress3.ReadOnly = true;
                txtAddress4.ReadOnly = true;
                txtAddress5.ReadOnly = true;
                txtPostcode.ReadOnly = true;
            }

            txtPolicyNumber.Text = CurrentSite.PolicyNumber;
            txtDDRef.Text = CurrentSite.DirectDebitRef;
            txtTelephoneNum.Text = CurrentSite.TelephoneNum;
            txtFaxNum.Text = CurrentSite.FaxNum;
            txtEmailAddress.Text = CurrentSite.EmailAddress;
            txtName.Text = CurrentSite.Name;
            var argcombo1 = cboSalutation;
            Combo.SetSelectedComboItem_By_Description(ref argcombo1, CurrentSite.Salutation);
            txtFirstName.Text = CurrentSite.FirstName;
            txtSurname.Text = CurrentSite.Surname;
            chbAcceptChargeChanges.Checked = CurrentSite.AcceptChargesChanges;
            var argcombo2 = cboSourceOfCustomer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentSite.SourceOfCustomerID.ToString());
            var argcombo3 = cboReasonForContact;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentSite.ReasonForContactID.ToString());
            var argcombo4 = cboAccomType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentSite.AccomTypeID.ToString());
            chkNoMarketing.Checked = CurrentSite.NoMarketing;
            chkOnStop.Checked = CurrentSite.OnStop;
            chkVoid.Checked = CurrentSite.PropertyVoid;
            if (CurrentSite.PropertyVoid)
            {
                lblPropertyVoidDate.Visible = true;
                txtPropertyVoidDate.Visible = true;
                if (!Information.IsNothing(CurrentSite.PropertyVoidDate))
                {
                    txtPropertyVoidDate.Text = Strings.Format(CurrentSite.PropertyVoidDate, "dd/MM/yyyy");
                }
            }

            txtAlert.Text = CurrentSite.ContactAlerts;
            if (Strings.Trim(txtAlert.Text).Length > 0)
            {
                txtAlert.BackColor = Color.Orange;
            }

            txtSiteDefects.Text = CurrentSite.Defects;
            if (Strings.Trim(txtSiteDefects.Text).Length > 0)
            {
                txtSiteDefects.BackColor = Color.Yellow;
                dtpDefectEndDate.Enabled = false;
            }

            if (CurrentSite.DefectEndDate != default)
                dtpDefectEndDate.Value = CurrentSite.DefectEndDate;
            chkSolidFuel.Checked = CurrentSite.SolidFuel;
            chkNoService.Checked = CurrentSite.NoService;
            chkLeaseHolder.Checked = CurrentSite.LeaseHold;
            chkCommercialDistrict.Checked = CurrentSite.CommercialDistrict;
            if (CurrentSite.LastServiceDate != default)
            {
                txtLastServiceDate.Text = Strings.Format(CurrentSite.LastServiceDate.AddYears(1), "dd/MM/yyyy");
                txtActualServiceDate.Text = Strings.Format(CurrentSite.LastServiceDate, "dd/MM/yyyy");
            }

            if (CurrentSite.ActualServiceDate != default)
            {
                txtActualServiceDate.Text = Strings.Format(CurrentSite.ActualServiceDate, "dd/MM/yyyy");
            }

            if (CurrentSite.BuildDate != default)
                dtpBuildDate.Value = CurrentSite.BuildDate;
            txtWarrantyPeriod.Text = CurrentSite.WarrantyPeriodInMonths.ToString();
            dtpBuildDate.Enabled = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
            txtWarrantyPeriod.ReadOnly = !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
            txtHousingOfficer.Text = string.IsNullOrEmpty(CurrentSite.HousingOfficer) ? "No Housing Officer Set" : CurrentSite.HousingOfficer;
            txtEstateOfficer.Text = string.IsNullOrEmpty(CurrentSite.EstateOfficer) ? "No Estate Officer Set" : CurrentSite.EstateOfficer;
            txtHousingManager.Text = string.IsNullOrEmpty(CurrentSite.HousingManager) ? "No Housing Manager Set" : CurrentSite.HousingManager;
            PopulateSiteFuels();
            PopulateSiteAuthority();
            CheckServiceDate();
            SelectedCustomerID = CurrentSite.CustomerID;
            PopulateCustomerField();
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
            if (chkHeadOffice.Checked)
            {
                btnConvCust.Enabled = false;
            }

            if (App.IsRFT && CurrentSite.LeaseHold)
            {
                btnAddJob.Enabled = false;
            }
        }

        private void PopulateCustomerField()
        {
            theCustomer = App.DB.Customer.Customer_Get(SelectedCustomerID);
            if (theCustomer is object)
            {
                txtCustomer.Text = theCustomer.Name;
            }
            else
            {
                txtCustomer.Text = "";
            }
        }

        public void PopulateContacts()
        {
            ContactsDataView = App.DB.Contact.Contact_GetForSite(CurrentSite.SiteID);
        }

        public void PopulateInvoiceAddresses()
        {
            InvoiceAddressDataView = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(CurrentSite.SiteID);
        }

        public void PopulateJobs()
        {
            JobsDataView = App.DB.Job.Job_GetTop100_For_Site(CurrentSite.SiteID, CurrentSite.CustomerID);
            if (JobsDataView.Count > 0)
                dgJobs.ContextMenuStrip = cmsJobs;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentSite.IgnoreExceptionsOnSetMethods = true;
                if (chkHeadOffice.Checked)
                {
                    var HO = App.DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
                    if (HO is object && HO.SiteID != CurrentSite.SiteID)
                    {
                        string msg = theCustomer.Name + " has already got a head office against it. '" + HO.Address1 + " " + HO.Postcode + "'" + Constants.vbCrLf + Constants.vbCrLf + "Please remove the current head office before assigning this site.";
                        throw new System.Security.SecurityException(msg);
                    }
                }

                if (!CurrentSite.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
                {
                    CurrentSite.SetRegionID = Combo.get_GetSelectedItemValue(cboRegionID);
                }

                CurrentSite.SetHeadOffice = chkHeadOffice.Checked;
                CurrentSite.SetNotes = txtNotes.Text.Trim();
                CurrentSite.SetAddress1 = txtAddress1.Text.Trim();
                CurrentSite.SetAddress2 = txtAddress2.Text.Trim();
                CurrentSite.SetAddress3 = txtAddress3.Text.Trim();
                CurrentSite.SetAddress4 = txtAddress4.Text.Trim();
                CurrentSite.SetAddress5 = txtAddress5.Text.Trim();
                CurrentSite.SetPostcode = txtPostcode.Text.Trim();
                CurrentSite.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentSite.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentSite.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentSite.SetAcceptChargesChanges = chbAcceptChargeChanges.Checked;
                CurrentSite.SetSourceOfCustomerID = Combo.get_GetSelectedItemValue(cboSourceOfCustomer);
                CurrentSite.SetPolicyNumber = txtPolicyNumber.Text;
                CurrentSite.SetDirectDebitRef = txtDDRef.Text;
                CurrentSite.SetReasonForContactID = Combo.get_GetSelectedItemValue(cboReasonForContact);
                CurrentSite.SetAccomTypeID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboAccomType));
                CurrentSite.SetNoMarketing = chkNoMarketing.Checked;
                CurrentSite.SetOnStop = chkOnStop.Checked;
                CurrentSite.SetNoService = chkNoService.Checked;
                CurrentSite.SetPropertyVoid = chkVoid.Checked;
                if (chkVoid.Checked)
                {
                    CurrentSite.PropertyVoidDate = Helper.MakeDateTimeValid(txtPropertyVoidDate.Text);
                }
                else
                {
                    CurrentSite.PropertyVoidDate = default;
                }

                if ((bool)(dtpBuildDate.Value > System.Data.SqlTypes.SqlDateTime.MinValue))
                    CurrentSite.BuildDate = dtpBuildDate.Value;
                CurrentSite.SetWarrantyPeriodInMonths = Helper.MakeIntegerValid(txtWarrantyPeriod.Text);
                try
                {
                    var ls = new LocationServices.LocationServices();
                    JObject json = (JObject)ls.GetLongLat(txtPostcode.Text.Trim());
                    CurrentSite.SetLongitude = Conversions.ToDecimal(json.SelectToken("result.longitude").ToString());
                    CurrentSite.SetLatitude = Conversions.ToDecimal(json.SelectToken("result.latitude").ToString());
                }
                catch (Exception ex)
                {
                }

                string siteName = "";
                if ((Combo.get_GetSelectedItemValue(cboSalutation) ?? "") != "0")
                    siteName += Combo.get_GetSelectedItemDescription(cboSalutation);
                if (txtFirstName.Text.Length > 0)
                {
                    if (siteName.Length > 0)
                        siteName += " ";
                    siteName += txtFirstName.Text.Trim();
                }

                if (txtSurname.Text.Length > 0)
                {
                    if (siteName.Length > 0)
                        siteName += " ";
                    siteName += txtSurname.Text.Trim();
                }

                if (siteName.Length > 0)
                {
                    CurrentSite.SetName = siteName;
                }

                if ((Combo.get_GetSelectedItemValue(cboSalutation) ?? "") == "Company Name")
                {
                    CurrentSite.SetName = txtSurname.Text;
                }

                CurrentSite.SetSalutation = Combo.get_GetSelectedItemDescription(cboSalutation);
                CurrentSite.SetFirstName = txtFirstName.Text.Trim();
                CurrentSite.SetSurname = txtSurname.Text.Trim();

                // CHECK FOR CUSTOMER CHANGE
                int oldCustomerID = 0;
                if (SelectedCustomerID != CurrentSite.CustomerID)
                {
                    oldCustomerID = CurrentSite.CustomerID;
                }

                CurrentSite.SetCustomerID = SelectedCustomerID;
                if (string.IsNullOrEmpty(CurrentSite.TelephoneNum) & string.IsNullOrEmpty(CurrentSite.FaxNum) & string.IsNullOrEmpty(CurrentSite.EmailAddress) & !CurrentSite.PropertyVoid)
                {
                    if (App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }

                CurrentSite.SetContactAlerts = txtAlert.Text.Trim();
                CurrentSite.SetDefects = txtSiteDefects.Text.Trim();
                CurrentSite.DefectEndDate = dtpDefectEndDate.Value;
                var cV = new Entity.Sites.SiteValidator();
                cV.Validate(CurrentSite);
                if (CurrentSite.Exists)
                {
                    App.DB.Sites.Update(CurrentSite);
                }
                else
                {
                    CurrentSite = App.DB.Sites.Insert(CurrentSite);
                }

                if (FromForm is null)
                {
                    App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + theCustomer.Name + ", Acc: " + theCustomer.AccountNumber;
                    if (App.CurrentCustomerID == 0)
                    {
                        if (App.MainForm.SearchText.Length > 0)
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                        else
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                    }
                    else
                    {
                        App.CurrentCustomerID = CurrentSite.CustomerID;
                        Entity.Customers.Customer cust;
                        cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                        if (App.MainForm.SearchText.Length > 0)
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                        else
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, cust.Name);
                        }
                    }

                    StateChanged?.Invoke(CurrentSite.SiteID);
                    App.MainForm.RefreshEntity(CurrentSite.SiteID);
                }
                else if (!((FromForm.Name.ToLower() ?? "") == (typeof(FRMLogCallout).Name.ToLower() ?? "")) & !((FromForm.Name.ToLower() ?? "") == (typeof(FRMJobWizard).Name.ToLower() ?? "")))
                {
                    App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + theCustomer.Name + ", Acc: " + theCustomer.AccountNumber;
                    if (App.CurrentCustomerID == 0)
                    {
                        RecordsChanged?.Invoke(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                    }
                    else
                    {
                        App.CurrentCustomerID = CurrentSite.CustomerID;
                        Entity.Customers.Customer cust;
                        cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                        RecordsChanged?.Invoke(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, cust.Name);
                    }

                    StateChanged?.Invoke(CurrentSite.SiteID);
                    App.MainForm.RefreshEntity(CurrentSite.SiteID);
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

        private bool DeleteOption1()
        {
            // DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
            var sites = new DataView();
            sites = App.DB.ContractOriginalSite.GetAll_ContractID(Conversions.ToInteger(SelectedContractDataRow["ContractID"]), CurrentSite.CustomerID);
            bool DeleteContract = true;
            foreach (DataRow r in sites.Table.Select("Tick=1"))
            {
                if (App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(r["ContractSiteID"])) > 0)
                {
                    DeleteContract = false;
                }
            }

            if (DeleteContract)
            {
                App.DB.ContractOriginal.Delete(Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]));
            }

            return DeleteContract;
        }

        private void ClearContactForVoid()
        {
            txtTelephoneNum.Text = string.Empty;
            txtFaxNum.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtName.Text = "VOID";
            var argc = cboSalutation;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            txtFirstName.Text = "VOID";
            txtSurname.Text = "VOID";
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _siteNotes = null;

        public DataView SiteNotesDataView
        {
            get
            {
                return _siteNotes;
            }

            set
            {
                _siteNotes = value;
                _siteNotes.Table.TableName = Enums.TableNames.tblSiteNotes.ToString();
                _siteNotes.AllowNew = false;
                _siteNotes.AllowEdit = false;
                _siteNotes.AllowDelete = false;
                dgNotes.DataSource = _siteNotes;
                if (_siteNotes is object)
                {
                    if (_siteNotes.Table is object)
                    {
                        if (_siteNotes.Table.Rows.Count > 0)
                        {
                        }
                    }
                }
            }
        }

        private DataRow SelectedSiteNoteDataRow
        {
            get
            {
                if (!(dgNotes.CurrentRowIndex == -1))
                {
                    return SiteNotesDataView[dgNotes.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupNotesDataGrid()
        {
            Helper.SetUpDataGrid(dgNotes);
            var tStyle = dgNotes.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgNotes.ReadOnly = true;
            var Note = new DataGridLabelColumn();
            Note.Format = "";
            Note.FormatInfo = null;
            Note.HeaderText = "Note";
            Note.MappingName = "Note";
            Note.ReadOnly = true;
            Note.Width = 250;
            Note.NullText = "";
            tStyle.GridColumnStyles.Add(Note);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 125;
            CreatedBy.NullText = "";
            tStyle.GridColumnStyles.Add(CreatedBy);
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MMM/yyyy HH:mm:ss";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 135;
            DateCreated.NullText = "";
            tStyle.GridColumnStyles.Add(DateCreated);
            var EditedBy = new DataGridLabelColumn();
            EditedBy.Format = "";
            EditedBy.FormatInfo = null;
            EditedBy.HeaderText = "Edited By";
            EditedBy.MappingName = "EditedBy";
            EditedBy.ReadOnly = true;
            EditedBy.Width = 125;
            EditedBy.NullText = "";
            tStyle.GridColumnStyles.Add(EditedBy);
            var LastEdited = new DataGridLabelColumn();
            LastEdited.Format = "dd/MMM/yyyy HH:mm:ss";
            LastEdited.FormatInfo = null;
            LastEdited.HeaderText = "Last Edited";
            LastEdited.MappingName = "LastEdited";
            LastEdited.ReadOnly = true;
            LastEdited.Width = 135;
            LastEdited.NullText = "";
            tStyle.GridColumnStyles.Add(LastEdited);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblSiteNotes.ToString();
            dgNotes.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgNotes);
        }

        private void dgNotes_Click(object sender, EventArgs e)
        {
            if (SelectedSiteNoteDataRow is null)
            {
                return;
            }
            else
            {
                PopulateSiteNoteFields();
                txtNote.ReadOnly = true;
                btnSaveNote.Enabled = false;
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            ClearNotesFields();
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this note?" + Constants.vbCrLf;
            msg += "You will not be able to undo the delete if you proceed.";
            DataRow r;
            r = SelectedSiteNoteDataRow;
            if (r is object)
            {
                if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    App.DB.Sites.DeleteSiteNote(Conversions.ToInteger(r["SiteNoteID"]));
                    SiteNotesDataView.Table.Rows.Remove(SelectedSiteNoteDataRow);
                    ClearNotesFields();
                }
            }
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (txtNote.Text.Trim().Length > 0)
            {
                SiteNotesDataView = App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid(txtNoteID.Text), txtNote.Text.Trim(), App.loggedInUser.UserID, CurrentSite.SiteID, App.loggedInUser.UserID);
            }

            ClearNotesFields();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void ClearNotesFields()
        {
            txtNoteID.Text = "";
            txtNote.Text = "";
            ActiveControl = txtNote;
            txtNote.ReadOnly = false;
            txtNote.Focus();
            btnSaveNote.Enabled = true;
            tpNotes.Text = "Notes (" + SiteNotesDataView.Table.Rows.Count + ")";
        }

        private void PopulateSiteNoteFields()
        {
            DataRow r;
            r = SelectedSiteNoteDataRow;
            if (r is object)
            {
                txtNoteID.Text = Conversions.ToString(r["SiteNoteID"]);
                txtNote.Text = Conversions.ToString(r["Note"]);
            }

            ActiveControl = txtNote;
            txtNote.Focus();
        }

        private void PopulateSiteNotes()
        {
            SiteNotesDataView = App.DB.Sites.GetSiteNotes(CurrentSite.SiteID);
            tpNotes.Text = "Notes (" + SiteNotesDataView.Table.Rows.Count + ")";
        }

        private void btnAddModifyPlan_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMContractWiz), true, new object[] { 0, Helper.MakeIntegerValid(CurrentSite.CustomerID), Helper.MakeIntegerValid(CurrentSite.SiteID) });
            Contracts = App.DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID);
            PopulateJobs();
        }

        private void btnConvCust_Click(object sender, EventArgs e)
        {
            if (CurrentSite is null || !CurrentSite.Exists)
            {
            }
            else
            {
                int customerType = App.DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID;
                if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) == false & customerType == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
                {
                    string msg = "You do not have the necessary security permissions to change site to customer." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }

            // Stop users creating Customers with no Region
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRegionID)) < 1)
            {
                Interaction.MsgBox("Please ensure the site has a region selected before converting", MsgBoxStyle.OkOnly, "No Region");
                return;
            }

            // Noticed that a customer could be converted with no name!!
            if (txtFirstName.Text.Length == 0 && txtSurname.Text.Length == 0)
            {
                Interaction.MsgBox("Please ensure the site has a Surname or Firstname before converting", MsgBoxStyle.OkOnly, "No Name");
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {

                // If Not EnterOverridePassword() Then Exit Sub

                var domCustomer = App.DB.Customer.Customer_Get(Conversions.ToInteger(Enums.Customer.Domestic));
                var img = Image.FromFile(Application.StartupPath + @"\TEMP\GaswayLogo.bmp");
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.ToArray();
                }

                CurrentCustomer = new Entity.Customers.Customer();
                CurrentCustomer.IgnoreExceptionsOnSetMethods = true;
                string fName = txtFirstName.Text;
                if (fName.Length > 0)
                    fName = fName.Substring(0, 1);
                CurrentCustomer.SetName = txtSurname.Text + " - " + Combo.get_GetSelectedItemDescription(cboSalutation) + " " + fName;
                CurrentCustomer.SetRegionID = Combo.get_GetSelectedItemValue(cboRegionID);
                CurrentCustomer.SetCustomerTypeID = 518;
                CurrentCustomer.SetNotes = "POC ONLY";
                CurrentCustomer.SetAccountNumber = domCustomer?.AccountNumber;
                CurrentCustomer.SetStatus = 1;
                CurrentCustomer.SetAcceptChargesChanges = chbAcceptChargeChanges.Checked;
                CurrentCustomer.SetMainContractorDiscount = 0;
                CurrentCustomer.SetPoNumReqd = false;
                CurrentCustomer.SetJobPriorityMandatory = false;
                CurrentCustomer.SetNominal = 4100;
                CurrentCustomer.Logo = bytes;
                CurrentSite.SetHeadOffice = false;
                var cV = new Entity.Customers.CustomerValidator();
                cV.Validate(CurrentCustomer);
                int count = Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) FROM tblCustomer where Deleted = 0 AND Name = '" + CurrentCustomer.Name + "'"));
                if (count > 0)
                {
                    if (App.ShowMessage("There is already a Customer with the same Name, Do you Still wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CurrentCustomer.SetName = txtSurname.Text + " - " + Combo.get_GetSelectedItemDescription(cboSalutation) + " " + txtFirstName.Text;
                    }
                    else
                    {
                        return;
                    }
                }

                if (CurrentCustomer.Exists)
                {
                    var customerCharges = new Entity.CustomerCharges.CustomerCharge();
                    customerCharges.SetMileageRate = 1;
                    customerCharges.SetPartsMarkup = 1;
                    customerCharges.SetRatesMarkup = 1;
                    customerCharges.SetCustomerID = CurrentCustomer.CustomerID;
                    var ccV = new Entity.CustomerCharges.CustomerChargeValidator();
                    ccV.Validate(customerCharges);
                    App.DB.CustomerCharge.Update(customerCharges);
                    App.DB.Customer.Update(CurrentCustomer);
                }
                else
                {
                    var customerCharges = new Entity.CustomerCharges.CustomerCharge();
                    customerCharges.SetMileageRate = 1;
                    customerCharges.SetPartsMarkup = 1;
                    customerCharges.SetRatesMarkup = 1;
                    customerCharges.SetCustomerID = 0;
                    var ccV = new Entity.CustomerCharges.CustomerChargeValidator();
                    ccV.Validate(customerCharges);
                    CurrentSite.SetHeadOffice = true;
                    CurrentCustomer = App.DB.Customer.Insert(CurrentCustomer);
                    customerCharges.SetCustomerID = CurrentCustomer.CustomerID;
                    App.DB.CustomerCharge.Insert(customerCharges);
                }

                App.CurrentCustomerID = CurrentCustomer.CustomerID;

                // '''SOR
                var dt = App.DB.CustomerScheduleOfRate.GetAll_WithoutDefaults(Conversions.ToInteger(Enums.Customer.Domestic)).Table;
                foreach (DataRow dr in dt.Rows)
                {
                    var CurrentCustomerScheduleofRate = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate();
                    CurrentCustomerScheduleofRate.SetAllowDeleted = 1;
                    CurrentCustomerScheduleofRate.SetCustomerID = App.CurrentCustomerID;
                    CurrentCustomerScheduleofRate.SetCode = dr["Code"];
                    CurrentCustomerScheduleofRate.SetDescription = dr["Description"];
                    CurrentCustomerScheduleofRate.SetPrice = dr["Price"];
                    CurrentCustomerScheduleofRate.SetTimeInMins = dr["TimeInMins"];
                    CurrentCustomerScheduleofRate.SetScheduleOfRatesCategoryID = dr["ScheduleOfRatesCategoryID"];
                    CurrentCustomerScheduleofRate = App.DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleofRate);
                }

                // INSERT AUDIT RECORD
                var scAudit = new Entity.SiteCustomerAudits.SiteCustomerAudit();
                scAudit.DateChanged = DateAndTime.Now;
                scAudit.SetSiteID = CurrentSite.SiteID;
                scAudit.SetPreviousCustomerID = CurrentSite.CustomerID;
                scAudit.SetUserID = App.loggedInUser.UserID;
                App.DB.SiteCustomerAudit.Insert(scAudit);
                CurrentSite.SetCustomerID = App.CurrentCustomerID;
                App.DB.Sites.Update(CurrentSite);
                btnConvCust.Enabled = false;
                if (FromForm is null)
                {
                    App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + theCustomer.Name + ", Acc: " + theCustomer.AccountNumber;
                    if (App.CurrentCustomerID == 0)
                    {
                        if (App.MainForm.SearchText.Length > 0)
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                        else
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                    }
                    else
                    {
                        App.CurrentCustomerID = CurrentSite.CustomerID;
                        Entity.Customers.Customer cust;
                        cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                        if (App.MainForm.SearchText.Length > 0)
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                        }
                        else
                        {
                            RecordsChanged?.Invoke(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, cust.Name);
                        }
                    }

                    StateChanged?.Invoke(CurrentSite.SiteID);
                    App.MainForm.RefreshEntity(CurrentSite.SiteID);
                }
                else if (!((FromForm.Name.ToLower() ?? "") == (typeof(FRMLogCallout).Name.ToLower() ?? "")))
                {
                    App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + theCustomer.Name + ", Acc: " + theCustomer.AccountNumber;
                    if (App.CurrentCustomerID == 0)
                    {
                        RecordsChanged?.Invoke(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
                    }
                    else
                    {
                        App.CurrentCustomerID = CurrentSite.CustomerID;
                        Entity.Customers.Customer cust;
                        cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                        RecordsChanged?.Invoke(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, cust.Name);
                    }

                    StateChanged?.Invoke(CurrentSite.SiteID);
                    App.MainForm.RefreshEntity(CurrentSite.SiteID);
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvSiteFuels = null;

        public DataView SiteFuelsDataView
        {
            get
            {
                return _dvSiteFuels;
            }

            set
            {
                _dvSiteFuels = value;
                _dvSiteFuels.AllowNew = false;
                _dvSiteFuels.AllowEdit = false;
                _dvSiteFuels.AllowDelete = false;
                _dvSiteFuels.Table.TableName = Enums.TableNames.tblSiteFuel.ToString();
                dgSiteFuel.DataSource = SiteFuelsDataView;
            }
        }

        private DataRow SelectedSiteFuelDataRow
        {
            get
            {
                if (!(dgSiteFuel.CurrentRowIndex == -1))
                {
                    return SiteFuelsDataView[dgSiteFuel.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void SiteFuelMoreInfo(object sender, EventArgs e)
        {
            if (CurrentSite is null || !CurrentSite.Exists)
            {
                return;
            }

            var frmSiteFuel = new FRMSiteFuel(CurrentSite);
            frmSiteFuel.ShowDialog();
            CurrentSite = App.DB.Sites.Get(CurrentSite.SiteID);
        }

        private void dgSiteFuel_MouseUp(object sender, MouseEventArgs e)
        {
            ttSiteFuel.Hide(dgSiteFuel);
            if (SelectedSiteFuelDataRow is null)
            {
                return;
            }

            string message = "";
            // check for row before we call it
            if (SelectedSiteFuelDataRow.Table.Columns.Contains("lastservicedate"))
            {
                var lsd = Helper.MakeDateTimeValid(SelectedSiteFuelDataRow["lastservicedate"]);
                if (lsd != default && lsd > System.Data.SqlTypes.SqlDateTime.MinValue.Value.AddYears(1))
                {
                    if (lsd <= DateAndTime.Now.AddDays(-365))
                    {
                        message = "Overdue";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-352) & lsd > DateAndTime.Now.AddDays(-365))
                    {
                        message = "Third letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-330) & lsd > DateAndTime.Now.AddDays(-352))
                    {
                        message = "Second letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-309) & lsd > DateAndTime.Now.AddDays(-330))
                    {
                        message = "First letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-281) & lsd > DateAndTime.Now.AddDays(-309))
                    {
                        message = "Service due soon";
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    message = "No service recorded";
                }
            }

            var hittest = dgSiteFuel.HitTest(e.X, e.Y);
            if (hittest.Type == DataGrid.HitTestType.Cell)
            {
                if (hittest.Row >= 0)
                {
                    ttSiteFuel.Show(message, dgSiteFuel, e.X, e.Y);
                }
            }
        }

        private void PopulateSiteFuels()
        {
            try
            {
                SiteFuelsDataView = App.DB.Sites.SiteFuel_GetAll_ForSite(CurrentSite.SiteID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSiteFuel_Leave(object sender, EventArgs e)
        {
            ttSiteFuel.Hide(dgSiteFuel);
        }

        private void tsmiMoveJob_Click(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                App.ShowMessage("Please select a job", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            if (!(ID == 0))
            {
                var oSite = App.DB.Sites.Get(ID);
                if (oSite is object && oSite.Exists)
                {
                    var switchExpr = App.ShowMessage(Conversions.ToString("Move job '" + SelectedJobDataRow["JobNumber"] + "' to " + oSite.Address1), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (switchExpr)
                    {
                        case DialogResult.Yes:
                            {
                                if (App.DB.Job.Job_MoveSite(Conversions.ToInteger(SelectedJobDataRow["JobID"]), CurrentSite.SiteID, ID))
                                {
                                    var jA = new Entity.JobAudits.JobAudit();
                                    jA.SetJobID = SelectedJobDataRow["JobID"];
                                    jA.SetActionChange = "Job moved from " + CurrentSite.Name + ", " + CurrentSite.Address1 + " to " + oSite.Name + ", " + oSite.Address1;
                                    App.DB.JobAudit.Insert(jA);
                                    App.ShowMessage("Job successfully moved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    PopulateJobs();
                                }

                                break;
                            }

                        default:
                            {
                                return;
                            }
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnUpdateAlert_Click(object sender, EventArgs e)
        {
            string contactAlert = txtAlert.Text;
            if (string.IsNullOrEmpty(contactAlert))
                return;
            if (App.ShowMessage("Do you want to update the alert?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.DB.Sites.Site_Update_ContactAlerts(CurrentSite.SiteID, contactAlert);
                CurrentSite = App.DB.Sites.Get(CurrentSite.SiteID);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupSiteAuthorityAuditDataGrid()
        {
            var tStyle = dgAuthorityAudit.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Action";
            Name.MappingName = "ActionChange";
            Name.ReadOnly = true;
            Name.Width = 350;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Date";
            Site.MappingName = "ActionDateTime";
            Site.ReadOnly = true;
            Site.Width = 100;
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
            tStyle.MappingName = Enums.TableNames.tblAuthority.ToString();
            dgAuthorityAudit.TableStyles.Add(tStyle);
        }

        private DataView _dvSiteAuthorityAudit;

        private DataView SiteAuthorityAuditDataView
        {
            get
            {
                return _dvSiteAuthorityAudit;
            }

            set
            {
                _dvSiteAuthorityAudit = value;
                _dvSiteAuthorityAudit.AllowNew = false;
                _dvSiteAuthorityAudit.AllowEdit = false;
                _dvSiteAuthorityAudit.AllowDelete = false;
                _dvSiteAuthorityAudit.Table.TableName = Enums.TableNames.tblAuthority.ToString();
                dgAuthorityAudit.DataSource = SiteAuthorityAuditDataView;
            }
        }

        private void PopulateSiteAuthority()
        {
            try
            {
                var oCustomerAuthority = App.DB.Authority.Get(CurrentSite.CustomerID, Entity.Authority.AuthoritySQL.GetBy.CustomerId);
                if (oCustomerAuthority is object)
                {
                    txtCustAuthority.Text = oCustomerAuthority.Notes;
                }

                SiteAuthority = App.DB.Authority.Get(CurrentSite.SiteID, Entity.Authority.AuthoritySQL.GetBy.SiteId);
                if (SiteAuthority is object)
                {
                    txtSiteAuth.Text = SiteAuthority.Notes;
                }

                SiteAuthorityAuditDataView = App.DB.Authority.Audit_Get(CurrentSite.SiteID, Entity.Authority.AuthoritySQL.GetBy.SiteId);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSiteAuth.Text))
                return;
            if (SiteAuthority is null)
            {
                SiteAuthority = new Entity.Authority.Authority();
                SiteAuthority.SetNotes = txtSiteAuth.Text;
                App.DB.Authority.Insert_Site(CurrentSite.SiteID, SiteAuthority);
            }
            else
            {
                string changes = string.Empty;
                if ((SiteAuthority.Notes ?? "") != (txtSiteAuth.Text ?? ""))
                {
                    changes += "Changed: " + SiteAuthority.Notes.Replace(Constants.vbCr, " ").Replace(Constants.vbLf, " ");
                }

                SiteAuthority.SetNotes = txtSiteAuth.Text;
                App.DB.Authority.Update(SiteAuthority, changes);
            }

            PopulateSiteAuthority();
        }

        private void chkHeadOffice_Click(object sender, EventArgs e)
        {
            chkHeadOffice.Checked = !chkHeadOffice.Checked;
            if (chkHeadOffice.Checked)
            {
                var HO = App.DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
                if (HO is object && HO.SiteID != CurrentSite.SiteID)
                {
                    string msg = theCustomer.Name + " has already got a head office against it. '" + HO.Address1 + " " + HO.Postcode + "'" + Constants.vbCrLf + Constants.vbCrLf + "Please remove the current head office before assigning this site.";
                    chkHeadOffice.Checked = false;
                    throw new System.Security.SecurityException(msg);
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}