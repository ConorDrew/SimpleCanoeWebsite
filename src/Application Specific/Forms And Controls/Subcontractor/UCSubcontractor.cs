using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCSubcontractor : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCSubcontractor() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCSubcontractor_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TabControl1.TabPages.Clear();
            TabControl1.TabPages.Add(tpContact);
            TabControl1.TabPages.Add(tpMain);
            TabControl1.TabPages.Add(tabMaxSor);
            TabControl1.TabPages.Add(tpPostalRegions);
            TabControl1.TabPages.Add(tpTrainingQualifications);
            TabControl1.TabPages.Add(tpWages);
            TabControl1.TabPages.Add(tpHolidayAbsences);
            TabControl1.TabPages.Add(tpDisciplinary);
            TabControl1.TabPages.Add(tpKit);
            TabControl1.TabPages.Add(tpDocuments);
            var argc = cboLinkToSupplier;
            Combo.SetUpCombo(ref argc, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.Not_Applicable);
            var argc1 = cboRegion;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = cboPayGrade;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboTaxRate;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.SubTaxRate).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboDisciplinary;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboQualification;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboEngineerGroup;
            Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboPayGrade;
            Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboDisciplinary;
            Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboQualificationType;
            Combo.SetUpCombo(ref argc9, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboQualification;
            Combo.SetUpComboQual(ref argc10, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc11 = cboUser;
            Combo.SetUpCombo(ref argc11, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Not_Applicable);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc12 = cboDepartment;
                        Combo.SetUpCombo(ref argc12, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc13 = cboDepartment;
                        Combo.SetUpCombo(ref argc13, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
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

        private Label _lblAddress4;

        internal Label lblAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress4 != null)
                {
                }

                _lblAddress4 = value;
                if (_lblAddress4 != null)
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

        private Label _lblAddress5;

        internal Label lblAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress5 != null)
                {
                }

                _lblAddress5 = value;
                if (_lblAddress5 != null)
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

        private TabPage _tpMain;

        internal TabPage tpMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpMain != null)
                {
                }

                _tpMain = value;
                if (_tpMain != null)
                {
                }
            }
        }

        private GroupBox _grpEngineer;

        internal GroupBox grpEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineer != null)
                {
                }

                _grpEngineer = value;
                if (_grpEngineer != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDrivingLicenceIssueDate;

        internal DateTimePicker dtpDrivingLicenceIssueDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDrivingLicenceIssueDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDrivingLicenceIssueDate != null)
                {
                }

                _dtpDrivingLicenceIssueDate = value;
                if (_dtpDrivingLicenceIssueDate != null)
                {
                }
            }
        }

        private Label _lblDrivingLicenseDate;

        internal Label lblDrivingLicenseDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDrivingLicenseDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDrivingLicenseDate != null)
                {
                }

                _lblDrivingLicenseDate = value;
                if (_lblDrivingLicenseDate != null)
                {
                }
            }
        }

        private TextBox _txtDrivingLicenceNo;

        internal TextBox txtDrivingLicenceNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDrivingLicenceNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDrivingLicenceNo != null)
                {
                }

                _txtDrivingLicenceNo = value;
                if (_txtDrivingLicenceNo != null)
                {
                }
            }
        }

        private Label _lblDrivingLicense;

        internal Label lblDrivingLicense
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDrivingLicense;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDrivingLicense != null)
                {
                }

                _lblDrivingLicense = value;
                if (_lblDrivingLicense != null)
                {
                }
            }
        }

        private TextBox _txtStartingDetails;

        internal TextBox txtStartingDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartingDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartingDetails != null)
                {
                }

                _txtStartingDetails = value;
                if (_txtStartingDetails != null)
                {
                }
            }
        }

        private Label _lblStartDetails;

        internal Label lblStartDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStartDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStartDetails != null)
                {
                }

                _lblStartDetails = value;
                if (_lblStartDetails != null)
                {
                }
            }
        }

        private TextBox _txtNextOfKinContact;

        internal TextBox txtNextOfKinContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNextOfKinContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNextOfKinContact != null)
                {
                }

                _txtNextOfKinContact = value;
                if (_txtNextOfKinContact != null)
                {
                }
            }
        }

        private Label _lblNextOfKinDetails;

        internal Label lblNextOfKinDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNextOfKinDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNextOfKinDetails != null)
                {
                }

                _lblNextOfKinDetails = value;
                if (_lblNextOfKinDetails != null)
                {
                }
            }
        }

        private TextBox _txtNextOfKinName;

        internal TextBox txtNextOfKinName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNextOfKinName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNextOfKinName != null)
                {
                }

                _txtNextOfKinName = value;
                if (_txtNextOfKinName != null)
                {
                }
            }
        }

        private Label _lblNextOfKin;

        internal Label lblNextOfKin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNextOfKin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNextOfKin != null)
                {
                }

                _lblNextOfKin = value;
                if (_lblNextOfKin != null)
                {
                }
            }
        }

        private Button _btnVanHistory;

        internal Button btnVanHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnVanHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnVanHistory != null)
                {
                    _btnVanHistory.Click -= btnVanHistory_Click;
                }

                _btnVanHistory = value;
                if (_btnVanHistory != null)
                {
                    _btnVanHistory.Click += btnVanHistory_Click;
                }
            }
        }

        private Label _lblRegion;

        internal Label lblRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegion != null)
                {
                }

                _lblRegion = value;
                if (_lblRegion != null)
                {
                }
            }
        }

        private Label _lblPDAID;

        internal Label lblPDAID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPDAID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPDAID != null)
                {
                }

                _lblPDAID = value;
                if (_lblPDAID != null)
                {
                }
            }
        }

        private CheckBox _chkApprentice;

        internal CheckBox chkApprentice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkApprentice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkApprentice != null)
                {
                }

                _chkApprentice = value;
                if (_chkApprentice != null)
                {
                }
            }
        }

        private TabPage _tpWages;

        internal TabPage tpWages
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpWages;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpWages != null)
                {
                }

                _tpWages = value;
                if (_tpWages != null)
                {
                }
            }
        }

        private GroupBox _GroupBox3;

        internal GroupBox GroupBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox3 != null)
                {
                }

                _GroupBox3 = value;
                if (_GroupBox3 != null)
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

        private TextBox _txtCostToCompanyDouble;

        internal TextBox txtCostToCompanyDouble
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCostToCompanyDouble;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCostToCompanyDouble != null)
                {
                }

                _txtCostToCompanyDouble = value;
                if (_txtCostToCompanyDouble != null)
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

        private TextBox _txtCostToCompanyTimeHalf;

        internal TextBox txtCostToCompanyTimeHalf
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCostToCompanyTimeHalf;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCostToCompanyTimeHalf != null)
                {
                }

                _txtCostToCompanyTimeHalf = value;
                if (_txtCostToCompanyTimeHalf != null)
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

        private TextBox _txtCostToCompanyNormal;

        internal TextBox txtCostToCompanyNormal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCostToCompanyNormal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCostToCompanyNormal != null)
                {
                }

                _txtCostToCompanyNormal = value;
                if (_txtCostToCompanyNormal != null)
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

        private TextBox _txtNINumber;

        internal TextBox txtNINumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNINumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNINumber != null)
                {
                }

                _txtNINumber = value;
                if (_txtNINumber != null)
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

        private ComboBox _cboPayGrade;

        internal ComboBox cboPayGrade
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPayGrade;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPayGrade != null)
                {
                }

                _cboPayGrade = value;
                if (_cboPayGrade != null)
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

        private TextBox _txtAnnualSalary;

        internal TextBox txtAnnualSalary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAnnualSalary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAnnualSalary != null)
                {
                }

                _txtAnnualSalary = value;
                if (_txtAnnualSalary != null)
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

        private TabPage _tpTrainingQualifications;

        internal TabPage tpTrainingQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpTrainingQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpTrainingQualifications != null)
                {
                }

                _tpTrainingQualifications = value;
                if (_tpTrainingQualifications != null)
                {
                }
            }
        }

        private GroupBox _GroupBox5;

        internal GroupBox GroupBox5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox5 != null)
                {
                }

                _GroupBox5 = value;
                if (_GroupBox5 != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private ComboBox _cboQualification;

        internal ComboBox cboQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualification != null)
                {
                }

                _cboQualification = value;
                if (_cboQualification != null)
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

        private TextBox _txtQualificatioNote;

        internal TextBox txtQualificatioNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQualificatioNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQualificatioNote != null)
                {
                }

                _txtQualificatioNote = value;
                if (_txtQualificatioNote != null)
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

        private Button _btnSaveQualification;

        internal Button btnSaveQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveQualification != null)
                {
                    _btnSaveQualification.Click -= btnSaveQualification_Click;
                }

                _btnSaveQualification = value;
                if (_btnSaveQualification != null)
                {
                    _btnSaveQualification.Click += btnSaveQualification_Click;
                }
            }
        }

        private DateTimePicker _dtpQualificationExpires;

        internal DateTimePicker dtpQualificationExpires
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationExpires;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationExpires != null)
                {
                }

                _dtpQualificationExpires = value;
                if (_dtpQualificationExpires != null)
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

        private DateTimePicker _dtpQualificationPassed;

        internal DateTimePicker dtpQualificationPassed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationPassed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationPassed != null)
                {
                }

                _dtpQualificationPassed = value;
                if (_dtpQualificationPassed != null)
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

        private Button _btnRemoveTrainingQualifications;

        internal Button btnRemoveTrainingQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveTrainingQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveTrainingQualifications != null)
                {
                    _btnRemoveTrainingQualifications.Click -= btnRemoveTrainingQualifications_Click;
                }

                _btnRemoveTrainingQualifications = value;
                if (_btnRemoveTrainingQualifications != null)
                {
                    _btnRemoveTrainingQualifications.Click += btnRemoveTrainingQualifications_Click;
                }
            }
        }

        private DataGrid _dgTrainingQualifications;

        internal DataGrid dgTrainingQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTrainingQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTrainingQualifications != null)
                {
                    _dgTrainingQualifications.Click -= dgTrainingQualifications_CurrentCellChanged;
                    _dgTrainingQualifications.CurrentCellChanged -= dgTrainingQualifications_CurrentCellChanged;
                }

                _dgTrainingQualifications = value;
                if (_dgTrainingQualifications != null)
                {
                    _dgTrainingQualifications.Click += dgTrainingQualifications_CurrentCellChanged;
                    _dgTrainingQualifications.CurrentCellChanged += dgTrainingQualifications_CurrentCellChanged;
                }
            }
        }

        private TabPage _tpKit;

        internal TabPage tpKit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpKit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpKit != null)
                {
                }

                _tpKit = value;
                if (_tpKit != null)
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

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private TextBox _txtEquipmentTool;

        internal TextBox txtEquipmentTool
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEquipmentTool;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEquipmentTool != null)
                {
                }

                _txtEquipmentTool = value;
                if (_txtEquipmentTool != null)
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

        private Button _btnSaveEquipment;

        internal Button btnSaveEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveEquipment != null)
                {
                    _btnSaveEquipment.Click -= btnSaveEquipment_Click;
                }

                _btnSaveEquipment = value;
                if (_btnSaveEquipment != null)
                {
                    _btnSaveEquipment.Click += btnSaveEquipment_Click;
                }
            }
        }

        private Button _btnRemoveEngineerEquipment;

        internal Button btnRemoveEngineerEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveEngineerEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveEngineerEquipment != null)
                {
                    _btnRemoveEngineerEquipment.Click -= btnRemoveEngineerEquipment_Click;
                }

                _btnRemoveEngineerEquipment = value;
                if (_btnRemoveEngineerEquipment != null)
                {
                    _btnRemoveEngineerEquipment.Click += btnRemoveEngineerEquipment_Click;
                }
            }
        }

        private DataGrid _dgEquipment;

        internal DataGrid dgEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEquipment != null)
                {
                }

                _dgEquipment = value;
                if (_dgEquipment != null)
                {
                }
            }
        }

        private TabPage _tpDisciplinary;

        internal TabPage tpDisciplinary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpDisciplinary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpDisciplinary != null)
                {
                }

                _tpDisciplinary = value;
                if (_tpDisciplinary != null)
                {
                }
            }
        }

        private GroupBox _GroupBox6;

        internal GroupBox GroupBox6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox6 != null)
                {
                }

                _GroupBox6 = value;
                if (_GroupBox6 != null)
                {
                }
            }
        }

        private Button _btnAddDisciplinaries;

        internal Button btnAddDisciplinaries
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddDisciplinaries;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddDisciplinaries != null)
                {
                    _btnAddDisciplinaries.Click -= btnAddDisciplinaries_Click;
                }

                _btnAddDisciplinaries = value;
                if (_btnAddDisciplinaries != null)
                {
                    _btnAddDisciplinaries.Click += btnAddDisciplinaries_Click;
                }
            }
        }

        private Panel _Panel3;

        internal Panel Panel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel3 != null)
                {
                }

                _Panel3 = value;
                if (_Panel3 != null)
                {
                }
            }
        }

        private TextBox _txtDisciplinaryID;

        internal TextBox txtDisciplinaryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDisciplinaryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDisciplinaryID != null)
                {
                }

                _txtDisciplinaryID = value;
                if (_txtDisciplinaryID != null)
                {
                }
            }
        }

        private ComboBox _cboDisciplinary;

        internal ComboBox cboDisciplinary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDisciplinary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDisciplinary != null)
                {
                }

                _cboDisciplinary = value;
                if (_cboDisciplinary != null)
                {
                }
            }
        }

        private Button _btnSaveDisciplinaries;

        internal Button btnSaveDisciplinaries
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveDisciplinaries;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveDisciplinaries != null)
                {
                    _btnSaveDisciplinaries.Click -= btnSaveDisciplinaries_Click;
                }

                _btnSaveDisciplinaries = value;
                if (_btnSaveDisciplinaries != null)
                {
                    _btnSaveDisciplinaries.Click += btnSaveDisciplinaries_Click;
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

        private DateTimePicker _dtpDisciplinaryIssued;

        internal DateTimePicker dtpDisciplinaryIssued
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDisciplinaryIssued;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDisciplinaryIssued != null)
                {
                }

                _dtpDisciplinaryIssued = value;
                if (_dtpDisciplinaryIssued != null)
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

        private TextBox _txtDisciplinary;

        internal TextBox txtDisciplinary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDisciplinary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDisciplinary != null)
                {
                }

                _txtDisciplinary = value;
                if (_txtDisciplinary != null)
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

        private Button _btnRemoveDisciplinaries;

        internal Button btnRemoveDisciplinaries
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveDisciplinaries;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveDisciplinaries != null)
                {
                    _btnRemoveDisciplinaries.Click -= btnRemoveDisciplinaries_Click;
                }

                _btnRemoveDisciplinaries = value;
                if (_btnRemoveDisciplinaries != null)
                {
                    _btnRemoveDisciplinaries.Click += btnRemoveDisciplinaries_Click;
                }
            }
        }

        private Button _btnEditDisciplinaries;

        internal Button btnEditDisciplinaries
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEditDisciplinaries;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEditDisciplinaries != null)
                {
                    _btnEditDisciplinaries.Click -= btnEditDisciplinaries_Click;
                }

                _btnEditDisciplinaries = value;
                if (_btnEditDisciplinaries != null)
                {
                    _btnEditDisciplinaries.Click += btnEditDisciplinaries_Click;
                }
            }
        }

        private DataGrid _dgDisciplinaries;

        internal DataGrid dgDisciplinaries
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgDisciplinaries;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgDisciplinaries != null)
                {
                }

                _dgDisciplinaries = value;
                if (_dgDisciplinaries != null)
                {
                }
            }
        }

        private TabPage _tpDocuments;

        internal TabPage tpDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpDocuments != null)
                {
                }

                _tpDocuments = value;
                if (_tpDocuments != null)
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

        private TabPage _tpHolidayAbsences;

        internal TabPage tpHolidayAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpHolidayAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpHolidayAbsences != null)
                {
                }

                _tpHolidayAbsences = value;
                if (_tpHolidayAbsences != null)
                {
                }
            }
        }

        private GroupBox _grpAbsences;

        internal GroupBox grpAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAbsences != null)
                {
                }

                _grpAbsences = value;
                if (_grpAbsences != null)
                {
                }
            }
        }

        private DataGrid _dgAbsences;

        internal DataGrid dgAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAbsences != null)
                {
                }

                _dgAbsences = value;
                if (_dgAbsences != null)
                {
                }
            }
        }

        private GroupBox _GroupBox7;

        internal GroupBox GroupBox7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox7 != null)
                {
                }

                _GroupBox7 = value;
                if (_GroupBox7 != null)
                {
                }
            }
        }

        private TextBox _txtDaysHolidayAllowed;

        internal TextBox txtDaysHolidayAllowed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDaysHolidayAllowed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDaysHolidayAllowed != null)
                {
                }

                _txtDaysHolidayAllowed = value;
                if (_txtDaysHolidayAllowed != null)
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

        private TextBox _txtHolidayYearEnd;

        internal TextBox txtHolidayYearEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHolidayYearEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHolidayYearEnd != null)
                {
                }

                _txtHolidayYearEnd = value;
                if (_txtHolidayYearEnd != null)
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

        private TextBox _txtHolidayYearStart;

        internal TextBox txtHolidayYearStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHolidayYearStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHolidayYearStart != null)
                {
                }

                _txtHolidayYearStart = value;
                if (_txtHolidayYearStart != null)
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

        private TabPage _tpPostalRegions;

        internal TabPage tpPostalRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpPostalRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpPostalRegions != null)
                {
                }

                _tpPostalRegions = value;
                if (_tpPostalRegions != null)
                {
                }
            }
        }

        private TabPage _tpContact;

        internal TabPage tpContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpContact != null)
                {
                }

                _tpContact = value;
                if (_tpContact != null)
                {
                }
            }
        }

        private TextBox _txtPDAID;

        internal TextBox txtPDAID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPDAID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPDAID != null)
                {
                }

                _txtPDAID = value;
                if (_txtPDAID != null)
                {
                }
            }
        }

        private ComboBox _cboRegion;

        internal ComboBox cboRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegion != null)
                {
                }

                _cboRegion = value;
                if (_cboRegion != null)
                {
                }
            }
        }

        private ComboBox _cboLinkToSupplier;

        internal ComboBox cboLinkToSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLinkToSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLinkToSupplier != null)
                {
                }

                _cboLinkToSupplier = value;
                if (_cboLinkToSupplier != null)
                {
                }
            }
        }

        private Label _lblLinkToSupplier;

        internal Label lblLinkToSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLinkToSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLinkToSupplier != null)
                {
                }

                _lblLinkToSupplier = value;
                if (_lblLinkToSupplier != null)
                {
                }
            }
        }

        private TabPage _tabMaxSor;

        internal TabPage tabMaxSor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabMaxSor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabMaxSor != null)
                {
                }

                _tabMaxSor = value;
                if (_tabMaxSor != null)
                {
                }
            }
        }

        private GroupBox _GroupBox8;

        internal GroupBox GroupBox8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox8 != null)
                {
                }

                _GroupBox8 = value;
                if (_GroupBox8 != null)
                {
                }
            }
        }

        private TextBox _txtDailyServiceLimit;

        internal TextBox txtDailyServiceLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDailyServiceLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDailyServiceLimit != null)
                {
                }

                _txtDailyServiceLimit = value;
                if (_txtDailyServiceLimit != null)
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

        private TextBox _txtSundayValue;

        internal TextBox txtSundayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSundayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSundayValue != null)
                {
                }

                _txtSundayValue = value;
                if (_txtSundayValue != null)
                {
                }
            }
        }

        private TextBox _txtSaturdayValue;

        internal TextBox txtSaturdayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSaturdayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSaturdayValue != null)
                {
                }

                _txtSaturdayValue = value;
                if (_txtSaturdayValue != null)
                {
                }
            }
        }

        private TextBox _txtFridayValue;

        internal TextBox txtFridayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFridayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFridayValue != null)
                {
                }

                _txtFridayValue = value;
                if (_txtFridayValue != null)
                {
                }
            }
        }

        private TextBox _txtThursdayValue;

        internal TextBox txtThursdayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtThursdayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtThursdayValue != null)
                {
                }

                _txtThursdayValue = value;
                if (_txtThursdayValue != null)
                {
                }
            }
        }

        private TextBox _txtWednesdayValue;

        internal TextBox txtWednesdayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWednesdayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWednesdayValue != null)
                {
                }

                _txtWednesdayValue = value;
                if (_txtWednesdayValue != null)
                {
                }
            }
        }

        private TextBox _txtTuesdayValue;

        internal TextBox txtTuesdayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTuesdayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTuesdayValue != null)
                {
                }

                _txtTuesdayValue = value;
                if (_txtTuesdayValue != null)
                {
                }
            }
        }

        private TextBox _txtMondayValue;

        internal TextBox txtMondayValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMondayValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMondayValue != null)
                {
                }

                _txtMondayValue = value;
                if (_txtMondayValue != null)
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

        private Label _Label44;

        internal Label Label44
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label44;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label44 != null)
                {
                }

                _Label44 = value;
                if (_Label44 != null)
                {
                }
            }
        }

        private Label _Label45;

        internal Label Label45
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label45;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label45 != null)
                {
                }

                _Label45 = value;
                if (_Label45 != null)
                {
                }
            }
        }

        private Label _Label46;

        internal Label Label46
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label46;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label46 != null)
                {
                }

                _Label46 = value;
                if (_Label46 != null)
                {
                }
            }
        }

        private Label _Label47;

        internal Label Label47
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label47;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label47 != null)
                {
                }

                _Label47 = value;
                if (_Label47 != null)
                {
                }
            }
        }

        private Label _Label48;

        internal Label Label48
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label48;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label48 != null)
                {
                }

                _Label48 = value;
                if (_Label48 != null)
                {
                }
            }
        }

        private Label _Label49;

        internal Label Label49
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label49;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label49 != null)
                {
                }

                _Label49 = value;
                if (_Label49 != null)
                {
                }
            }
        }

        private ComboBox _cboUser;

        internal ComboBox cboUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUser != null)
                {
                }

                _cboUser = value;
                if (_cboUser != null)
                {
                }
            }
        }

        private TextBox _txtOftecNo;

        internal TextBox txtOftecNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOftecNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOftecNo != null)
                {
                }

                _txtOftecNo = value;
                if (_txtOftecNo != null)
                {
                }
            }
        }

        private TextBox _txtTechnician;

        internal TextBox txtTechnician
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTechnician;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTechnician != null)
                {
                }

                _txtTechnician = value;
                if (_txtTechnician != null)
                {
                }
            }
        }

        private TextBox _txtGasSafeNo;

        internal TextBox txtGasSafeNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGasSafeNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGasSafeNo != null)
                {
                }

                _txtGasSafeNo = value;
                if (_txtGasSafeNo != null)
                {
                }
            }
        }

        private TextBox _txtEngineerID;

        internal TextBox txtEngineerID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerID != null)
                {
                }

                _txtEngineerID = value;
                if (_txtEngineerID != null)
                {
                }
            }
        }

        private Label _lblOftecNo;

        internal Label lblOftecNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOftecNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOftecNo != null)
                {
                }

                _lblOftecNo = value;
                if (_lblOftecNo != null)
                {
                }
            }
        }

        private Label _lblDepartment;

        internal Label lblDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDepartment != null)
                {
                }

                _lblDepartment = value;
                if (_lblDepartment != null)
                {
                }
            }
        }

        private Label _lblManager;

        internal Label lblManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblManager != null)
                {
                }

                _lblManager = value;
                if (_lblManager != null)
                {
                }
            }
        }

        private Label _lblTechnician;

        internal Label lblTechnician
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTechnician;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTechnician != null)
                {
                }

                _lblTechnician = value;
                if (_lblTechnician != null)
                {
                }
            }
        }

        private ComboBox _cboEngineerGroup;

        internal ComboBox cboEngineerGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineerGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineerGroup != null)
                {
                }

                _cboEngineerGroup = value;
                if (_cboEngineerGroup != null)
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

        private Label _lblGasSafeId;

        internal Label lblGasSafeId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGasSafeId;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGasSafeId != null)
                {
                }

                _lblGasSafeId = value;
                if (_lblGasSafeId != null)
                {
                }
            }
        }

        private Label _lblEngID;

        internal Label lblEngID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngID != null)
                {
                }

                _lblEngID = value;
                if (_lblEngID != null)
                {
                }
            }
        }

        private TextBox _txtBreakPri;

        internal TextBox txtBreakPri
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBreakPri;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBreakPri != null)
                {
                }

                _txtBreakPri = value;
                if (_txtBreakPri != null)
                {
                }
            }
        }

        private TextBox _txtServPri;

        internal TextBox txtServPri
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtServPri;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtServPri != null)
                {
                }

                _txtServPri = value;
                if (_txtServPri != null)
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

        private DateTimePicker _dtpQualificationBooked;

        internal DateTimePicker dtpQualificationBooked
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationBooked;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationBooked != null)
                {
                }

                _dtpQualificationBooked = value;
                if (_dtpQualificationBooked != null)
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

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                }
            }
        }

        private TextBox _TextBox1;

        internal TextBox TextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox1 != null)
                {
                }

                _TextBox1 = value;
                if (_TextBox1 != null)
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

        private GroupBox _grpPostalRegions;

        internal GroupBox grpPostalRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPostalRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPostalRegions != null)
                {
                }

                _grpPostalRegions = value;
                if (_grpPostalRegions != null)
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

        private TextBox _txtPCSearch;

        internal TextBox txtPCSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPCSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPCSearch != null)
                {
                    _txtPCSearch.TextChanged -= txtPCSearch_TextChanged;
                }

                _txtPCSearch = value;
                if (_txtPCSearch != null)
                {
                    _txtPCSearch.TextChanged += txtPCSearch_TextChanged;
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

        private DataGrid _dgUnTicked;

        internal DataGrid dgUnTicked
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgUnTicked;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgUnTicked != null)
                {
                    _dgUnTicked.Click -= dgUnTicked_Click;
                }

                _dgUnTicked = value;
                if (_dgUnTicked != null)
                {
                    _dgUnTicked.Click += dgUnTicked_Click;
                }
            }
        }

        private DataGrid _dgPostalRegions;

        internal DataGrid dgPostalRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPostalRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPostalRegions != null)
                {
                    _dgPostalRegions.Click -= dgPostalRegions_Click;
                }

                _dgPostalRegions = value;
                if (_dgPostalRegions != null)
                {
                    _dgPostalRegions.Click += dgPostalRegions_Click;
                }
            }
        }

        private ComboBox _cboQualificationType;

        internal ComboBox cboQualificationType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualificationType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualificationType != null)
                {
                    _cboQualificationType.SelectedIndexChanged -= cboQualificationType_SelectedIndexChanged;
                }

                _cboQualificationType = value;
                if (_cboQualificationType != null)
                {
                    _cboQualificationType.SelectedIndexChanged += cboQualificationType_SelectedIndexChanged;
                }
            }
        }

        private Label _lblQualificationType;

        internal Label lblQualificationType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualificationType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualificationType != null)
                {
                }

                _lblQualificationType = value;
                if (_lblQualificationType != null)
                {
                }
            }
        }

        private ComboBox _cboTaxRate;

        internal ComboBox cboTaxRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTaxRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTaxRate != null)
                {
                }

                _cboTaxRate = value;
                if (_cboTaxRate != null)
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

        private ComboBox _cboDepartment;

        internal ComboBox cboDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDepartment != null)
                {
                }

                _cboDepartment = value;
                if (_cboDepartment != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtName = new TextBox();
            _lblName = new Label();
            _txtAddress1 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress2 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress4 = new TextBox();
            _lblAddress4 = new Label();
            _txtAddress5 = new TextBox();
            _lblAddress5 = new Label();
            _txtPostcode = new TextBox();
            _lblPostcode = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _txtNotes = new TextBox();
            _TabControl1 = new TabControl();
            _tpContact = new TabPage();
            _cboTaxRate = new ComboBox();
            _Label3 = new Label();
            _cboLinkToSupplier = new ComboBox();
            _lblLinkToSupplier = new Label();
            _lblNotes = new Label();
            _tpMain = new TabPage();
            _grpEngineer = new GroupBox();
            _cboUser = new ComboBox();
            _txtOftecNo = new TextBox();
            _txtTechnician = new TextBox();
            _txtGasSafeNo = new TextBox();
            _txtEngineerID = new TextBox();
            _lblOftecNo = new Label();
            _lblDepartment = new Label();
            _lblManager = new Label();
            _lblTechnician = new Label();
            _cboEngineerGroup = new ComboBox();
            _Label37 = new Label();
            _lblGasSafeId = new Label();
            _lblEngID = new Label();
            _dtpDrivingLicenceIssueDate = new DateTimePicker();
            _lblDrivingLicenseDate = new Label();
            _txtDrivingLicenceNo = new TextBox();
            _lblDrivingLicense = new Label();
            _txtStartingDetails = new TextBox();
            _lblStartDetails = new Label();
            _txtNextOfKinContact = new TextBox();
            _lblNextOfKinDetails = new Label();
            _txtNextOfKinName = new TextBox();
            _lblNextOfKin = new Label();
            _btnVanHistory = new Button();
            _btnVanHistory.Click += new EventHandler(btnVanHistory_Click);
            _txtPDAID = new TextBox();
            _cboRegion = new ComboBox();
            _lblRegion = new Label();
            _lblPDAID = new Label();
            _chkApprentice = new CheckBox();
            _tabMaxSor = new TabPage();
            _GroupBox8 = new GroupBox();
            _txtBreakPri = new TextBox();
            _txtServPri = new TextBox();
            _Label40 = new Label();
            _Label39 = new Label();
            _txtDailyServiceLimit = new TextBox();
            _Label42 = new Label();
            _txtSundayValue = new TextBox();
            _txtSaturdayValue = new TextBox();
            _txtFridayValue = new TextBox();
            _txtThursdayValue = new TextBox();
            _txtWednesdayValue = new TextBox();
            _txtTuesdayValue = new TextBox();
            _txtMondayValue = new TextBox();
            _Label43 = new Label();
            _Label44 = new Label();
            _Label45 = new Label();
            _Label46 = new Label();
            _Label47 = new Label();
            _Label48 = new Label();
            _Label49 = new Label();
            _tpWages = new TabPage();
            _GroupBox3 = new GroupBox();
            _Label11 = new Label();
            _txtCostToCompanyDouble = new TextBox();
            _Label12 = new Label();
            _txtCostToCompanyTimeHalf = new TextBox();
            _Label13 = new Label();
            _txtCostToCompanyNormal = new TextBox();
            _GroupBox1 = new GroupBox();
            _txtNINumber = new TextBox();
            _Label14 = new Label();
            _cboPayGrade = new ComboBox();
            _Label15 = new Label();
            _txtAnnualSalary = new TextBox();
            _Label16 = new Label();
            _tpTrainingQualifications = new TabPage();
            _GroupBox5 = new GroupBox();
            _Panel1 = new Panel();
            _cboQualificationType = new ComboBox();
            _cboQualificationType.SelectedIndexChanged += new EventHandler(cboQualificationType_SelectedIndexChanged);
            _lblQualificationType = new Label();
            _dtpQualificationBooked = new DateTimePicker();
            _Label36 = new Label();
            _cboQualification = new ComboBox();
            _Label22 = new Label();
            _txtQualificatioNote = new TextBox();
            _Label17 = new Label();
            _btnSaveQualification = new Button();
            _btnSaveQualification.Click += new EventHandler(btnSaveQualification_Click);
            _dtpQualificationExpires = new DateTimePicker();
            _Label18 = new Label();
            _dtpQualificationPassed = new DateTimePicker();
            _Label19 = new Label();
            _btnRemoveTrainingQualifications = new Button();
            _btnRemoveTrainingQualifications.Click += new EventHandler(btnRemoveTrainingQualifications_Click);
            _dgTrainingQualifications = new DataGrid();
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_CurrentCellChanged);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_CurrentCellChanged);
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_CurrentCellChanged);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_CurrentCellChanged);
            _tpKit = new TabPage();
            _GroupBox4 = new GroupBox();
            _Panel2 = new Panel();
            _txtEquipmentTool = new TextBox();
            _Label20 = new Label();
            _btnSaveEquipment = new Button();
            _btnSaveEquipment.Click += new EventHandler(btnSaveEquipment_Click);
            _btnRemoveEngineerEquipment = new Button();
            _btnRemoveEngineerEquipment.Click += new EventHandler(btnRemoveEngineerEquipment_Click);
            _dgEquipment = new DataGrid();
            _tpDisciplinary = new TabPage();
            _GroupBox6 = new GroupBox();
            _btnAddDisciplinaries = new Button();
            _btnAddDisciplinaries.Click += new EventHandler(btnAddDisciplinaries_Click);
            _Panel3 = new Panel();
            _txtDisciplinaryID = new TextBox();
            _cboDisciplinary = new ComboBox();
            _btnSaveDisciplinaries = new Button();
            _btnSaveDisciplinaries.Click += new EventHandler(btnSaveDisciplinaries_Click);
            _Label21 = new Label();
            _dtpDisciplinaryIssued = new DateTimePicker();
            _Label23 = new Label();
            _txtDisciplinary = new TextBox();
            _Label24 = new Label();
            _btnRemoveDisciplinaries = new Button();
            _btnRemoveDisciplinaries.Click += new EventHandler(btnRemoveDisciplinaries_Click);
            _btnEditDisciplinaries = new Button();
            _btnEditDisciplinaries.Click += new EventHandler(btnEditDisciplinaries_Click);
            _dgDisciplinaries = new DataGrid();
            _tpDocuments = new TabPage();
            _pnlDocuments = new Panel();
            _tpHolidayAbsences = new TabPage();
            _grpAbsences = new GroupBox();
            _dgAbsences = new DataGrid();
            _GroupBox7 = new GroupBox();
            _txtDaysHolidayAllowed = new TextBox();
            _Label25 = new Label();
            _txtHolidayYearEnd = new TextBox();
            _Label26 = new Label();
            _txtHolidayYearStart = new TextBox();
            _Label27 = new Label();
            _tpPostalRegions = new TabPage();
            _GroupBox2 = new GroupBox();
            _Button1 = new Button();
            _TextBox1 = new TextBox();
            _Label1 = new Label();
            _grpPostalRegions = new GroupBox();
            _Label38 = new Label();
            _txtPCSearch = new TextBox();
            _txtPCSearch.TextChanged += new EventHandler(txtPCSearch_TextChanged);
            _Label2 = new Label();
            _dgUnTicked = new DataGrid();
            _dgUnTicked.Click += new EventHandler(dgUnTicked_Click);
            _dgPostalRegions = new DataGrid();
            _dgPostalRegions.Click += new EventHandler(dgPostalRegions_Click);
            _cboDepartment = new ComboBox();
            _TabControl1.SuspendLayout();
            _tpContact.SuspendLayout();
            _tpMain.SuspendLayout();
            _grpEngineer.SuspendLayout();
            _tabMaxSor.SuspendLayout();
            _GroupBox8.SuspendLayout();
            _tpWages.SuspendLayout();
            _GroupBox3.SuspendLayout();
            _GroupBox1.SuspendLayout();
            _tpTrainingQualifications.SuspendLayout();
            _GroupBox5.SuspendLayout();
            _Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTrainingQualifications).BeginInit();
            _tpKit.SuspendLayout();
            _GroupBox4.SuspendLayout();
            _Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).BeginInit();
            _tpDisciplinary.SuspendLayout();
            _GroupBox6.SuspendLayout();
            _Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgDisciplinaries).BeginInit();
            _tpDocuments.SuspendLayout();
            _tpHolidayAbsences.SuspendLayout();
            _grpAbsences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).BeginInit();
            _GroupBox7.SuspendLayout();
            _tpPostalRegions.SuspendLayout();
            _GroupBox2.SuspendLayout();
            _grpPostalRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUnTicked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgPostalRegions).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(112, 16);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(504, 21);
            _txtName.TabIndex = 1;
            _txtName.Tag = "Subcontractor.Name";
            // 
            // lblName
            // 
            _lblName.Location = new Point(8, 16);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(53, 20);
            _lblName.TabIndex = 31;
            _lblName.Text = "Name";
            // 
            // txtAddress1
            // 
            _txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress1.Location = new Point(112, 48);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(504, 21);
            _txtAddress1.TabIndex = 2;
            _txtAddress1.Tag = "Subcontractor.Address1";
            // 
            // lblAddress1
            // 
            _lblAddress1.Location = new Point(8, 48);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(78, 20);
            _lblAddress1.TabIndex = 31;
            _lblAddress1.Text = "Address 1";
            // 
            // txtAddress2
            // 
            _txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress2.Location = new Point(112, 80);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(504, 21);
            _txtAddress2.TabIndex = 3;
            _txtAddress2.Tag = "Subcontractor.Address2";
            // 
            // lblAddress2
            // 
            _lblAddress2.Location = new Point(8, 80);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(73, 20);
            _lblAddress2.TabIndex = 31;
            _lblAddress2.Text = "Address 2";
            // 
            // txtAddress3
            // 
            _txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress3.Location = new Point(112, 112);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(504, 21);
            _txtAddress3.TabIndex = 4;
            _txtAddress3.Tag = "Subcontractor.Address3";
            // 
            // lblAddress3
            // 
            _lblAddress3.Location = new Point(8, 112);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(66, 20);
            _lblAddress3.TabIndex = 31;
            _lblAddress3.Text = "Address 3";
            // 
            // txtAddress4
            // 
            _txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress4.Location = new Point(112, 144);
            _txtAddress4.MaxLength = 255;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.Size = new Size(504, 21);
            _txtAddress4.TabIndex = 5;
            _txtAddress4.Tag = "Subcontractor.Address4";
            // 
            // lblAddress4
            // 
            _lblAddress4.Location = new Point(8, 144);
            _lblAddress4.Name = "lblAddress4";
            _lblAddress4.Size = new Size(67, 20);
            _lblAddress4.TabIndex = 31;
            _lblAddress4.Text = "Address 4";
            // 
            // txtAddress5
            // 
            _txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress5.Location = new Point(112, 176);
            _txtAddress5.MaxLength = 255;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.Size = new Size(504, 21);
            _txtAddress5.TabIndex = 6;
            _txtAddress5.Tag = "Subcontractor.Address5";
            // 
            // lblAddress5
            // 
            _lblAddress5.Location = new Point(8, 176);
            _lblAddress5.Name = "lblAddress5";
            _lblAddress5.Size = new Size(79, 20);
            _lblAddress5.TabIndex = 31;
            _lblAddress5.Text = "Address 5";
            // 
            // txtPostcode
            // 
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Location = new Point(112, 208);
            _txtPostcode.MaxLength = 20;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(504, 21);
            _txtPostcode.TabIndex = 7;
            _txtPostcode.Tag = "Subcontractor.Postcode";
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(8, 208);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(72, 20);
            _lblPostcode.TabIndex = 31;
            _lblPostcode.Text = "Postcode";
            // 
            // txtTelephoneNum
            // 
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(112, 240);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(504, 21);
            _txtTelephoneNum.TabIndex = 8;
            _txtTelephoneNum.Tag = "Subcontractor.TelephoneNum";
            // 
            // lblTelephoneNum
            // 
            _lblTelephoneNum.Location = new Point(8, 240);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(113, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Telephone";
            // 
            // txtFaxNum
            // 
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(112, 272);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(504, 21);
            _txtFaxNum.TabIndex = 9;
            _txtFaxNum.Tag = "Subcontractor.FaxNum";
            // 
            // lblFaxNum
            // 
            _lblFaxNum.Location = new Point(8, 272);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(73, 20);
            _lblFaxNum.TabIndex = 31;
            _lblFaxNum.Text = "Fax";
            // 
            // txtEmailAddress
            // 
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(112, 304);
            _txtEmailAddress.MaxLength = 255;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(504, 21);
            _txtEmailAddress.TabIndex = 10;
            _txtEmailAddress.Tag = "Subcontractor.EmailAddress";
            // 
            // lblEmailAddress
            // 
            _lblEmailAddress.Location = new Point(8, 304);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(103, 20);
            _lblEmailAddress.TabIndex = 31;
            _lblEmailAddress.Text = "Email Address";
            // 
            // txtNotes
            // 
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(112, 409);
            _txtNotes.MaxLength = 0;
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(504, 194);
            _txtNotes.TabIndex = 13;
            _txtNotes.Tag = "Subcontractor.Notes";
            // 
            // TabControl1
            // 
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tpContact);
            _TabControl1.Controls.Add(_tpMain);
            _TabControl1.Controls.Add(_tabMaxSor);
            _TabControl1.Controls.Add(_tpWages);
            _TabControl1.Controls.Add(_tpTrainingQualifications);
            _TabControl1.Controls.Add(_tpKit);
            _TabControl1.Controls.Add(_tpDisciplinary);
            _TabControl1.Controls.Add(_tpDocuments);
            _TabControl1.Controls.Add(_tpHolidayAbsences);
            _TabControl1.Controls.Add(_tpPostalRegions);
            _TabControl1.Location = new Point(0, 0);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(632, 648);
            _TabControl1.TabIndex = 2;
            // 
            // tpContact
            // 
            _tpContact.Controls.Add(_cboTaxRate);
            _tpContact.Controls.Add(_Label3);
            _tpContact.Controls.Add(_cboLinkToSupplier);
            _tpContact.Controls.Add(_lblLinkToSupplier);
            _tpContact.Controls.Add(_lblNotes);
            _tpContact.Controls.Add(_lblFaxNum);
            _tpContact.Controls.Add(_txtEmailAddress);
            _tpContact.Controls.Add(_lblEmailAddress);
            _tpContact.Controls.Add(_txtNotes);
            _tpContact.Controls.Add(_txtName);
            _tpContact.Controls.Add(_lblName);
            _tpContact.Controls.Add(_txtAddress1);
            _tpContact.Controls.Add(_lblAddress1);
            _tpContact.Controls.Add(_txtAddress2);
            _tpContact.Controls.Add(_lblAddress2);
            _tpContact.Controls.Add(_txtAddress3);
            _tpContact.Controls.Add(_lblAddress3);
            _tpContact.Controls.Add(_txtAddress4);
            _tpContact.Controls.Add(_lblAddress4);
            _tpContact.Controls.Add(_txtAddress5);
            _tpContact.Controls.Add(_lblAddress5);
            _tpContact.Controls.Add(_txtPostcode);
            _tpContact.Controls.Add(_lblPostcode);
            _tpContact.Controls.Add(_txtTelephoneNum);
            _tpContact.Controls.Add(_lblTelephoneNum);
            _tpContact.Controls.Add(_txtFaxNum);
            _tpContact.Location = new Point(4, 22);
            _tpContact.Name = "tpContact";
            _tpContact.Size = new Size(624, 622);
            _tpContact.TabIndex = 8;
            _tpContact.Text = "Contact Details";
            // 
            // cboTaxRate
            // 
            _cboTaxRate.FormattingEnabled = true;
            _cboTaxRate.Location = new Point(112, 372);
            _cboTaxRate.Name = "cboTaxRate";
            _cboTaxRate.Size = new Size(504, 21);
            _cboTaxRate.TabIndex = 38;
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 375);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(98, 20);
            _Label3.TabIndex = 37;
            _Label3.Text = "Tax Rate";
            // 
            // cboLinkToSupplier
            // 
            _cboLinkToSupplier.FormattingEnabled = true;
            _cboLinkToSupplier.Location = new Point(112, 338);
            _cboLinkToSupplier.Name = "cboLinkToSupplier";
            _cboLinkToSupplier.Size = new Size(504, 21);
            _cboLinkToSupplier.TabIndex = 36;
            // 
            // lblLinkToSupplier
            // 
            _lblLinkToSupplier.Location = new Point(8, 341);
            _lblLinkToSupplier.Name = "lblLinkToSupplier";
            _lblLinkToSupplier.Size = new Size(103, 20);
            _lblLinkToSupplier.TabIndex = 35;
            _lblLinkToSupplier.Text = "Link To Supplier";
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(8, 412);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(103, 20);
            _lblNotes.TabIndex = 32;
            _lblNotes.Text = "Notes";
            // 
            // tpMain
            // 
            _tpMain.Controls.Add(_grpEngineer);
            _tpMain.Location = new Point(4, 22);
            _tpMain.Name = "tpMain";
            _tpMain.Size = new Size(624, 622);
            _tpMain.TabIndex = 0;
            _tpMain.Text = "Engineer Details";
            // 
            // grpEngineer
            // 
            _grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineer.Controls.Add(_cboDepartment);
            _grpEngineer.Controls.Add(_cboUser);
            _grpEngineer.Controls.Add(_txtOftecNo);
            _grpEngineer.Controls.Add(_txtTechnician);
            _grpEngineer.Controls.Add(_txtGasSafeNo);
            _grpEngineer.Controls.Add(_txtEngineerID);
            _grpEngineer.Controls.Add(_lblOftecNo);
            _grpEngineer.Controls.Add(_lblDepartment);
            _grpEngineer.Controls.Add(_lblManager);
            _grpEngineer.Controls.Add(_lblTechnician);
            _grpEngineer.Controls.Add(_cboEngineerGroup);
            _grpEngineer.Controls.Add(_Label37);
            _grpEngineer.Controls.Add(_lblGasSafeId);
            _grpEngineer.Controls.Add(_lblEngID);
            _grpEngineer.Controls.Add(_dtpDrivingLicenceIssueDate);
            _grpEngineer.Controls.Add(_lblDrivingLicenseDate);
            _grpEngineer.Controls.Add(_txtDrivingLicenceNo);
            _grpEngineer.Controls.Add(_lblDrivingLicense);
            _grpEngineer.Controls.Add(_txtStartingDetails);
            _grpEngineer.Controls.Add(_lblStartDetails);
            _grpEngineer.Controls.Add(_txtNextOfKinContact);
            _grpEngineer.Controls.Add(_lblNextOfKinDetails);
            _grpEngineer.Controls.Add(_txtNextOfKinName);
            _grpEngineer.Controls.Add(_lblNextOfKin);
            _grpEngineer.Controls.Add(_btnVanHistory);
            _grpEngineer.Controls.Add(_txtPDAID);
            _grpEngineer.Controls.Add(_cboRegion);
            _grpEngineer.Controls.Add(_lblRegion);
            _grpEngineer.Controls.Add(_lblPDAID);
            _grpEngineer.Controls.Add(_chkApprentice);
            _grpEngineer.Location = new Point(8, 0);
            _grpEngineer.Name = "grpEngineer";
            _grpEngineer.Size = new Size(608, 616);
            _grpEngineer.TabIndex = 0;
            _grpEngineer.TabStop = false;
            _grpEngineer.Text = "Details";
            // 
            // cboUser
            // 
            _cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUser.Cursor = Cursors.Hand;
            _cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUser.Location = new Point(121, 172);
            _cboUser.Name = "cboUser";
            _cboUser.Size = new Size(470, 21);
            _cboUser.TabIndex = 72;
            _cboUser.Tag = "";
            // 
            // txtOftecNo
            // 
            _txtOftecNo.Location = new Point(512, 18);
            _txtOftecNo.Name = "txtOftecNo";
            _txtOftecNo.Size = new Size(79, 21);
            _txtOftecNo.TabIndex = 70;
            _txtOftecNo.Tag = "Engineer.Name";
            // 
            // txtTechnician
            // 
            _txtTechnician.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTechnician.Location = new Point(121, 134);
            _txtTechnician.Name = "txtTechnician";
            _txtTechnician.Size = new Size(470, 21);
            _txtTechnician.TabIndex = 61;
            _txtTechnician.Tag = "";
            // 
            // txtGasSafeNo
            // 
            _txtGasSafeNo.Location = new Point(333, 18);
            _txtGasSafeNo.Name = "txtGasSafeNo";
            _txtGasSafeNo.Size = new Size(79, 21);
            _txtGasSafeNo.TabIndex = 59;
            _txtGasSafeNo.Tag = "Engineer.Name";
            // 
            // txtEngineerID
            // 
            _txtEngineerID.Location = new Point(121, 20);
            _txtEngineerID.Name = "txtEngineerID";
            _txtEngineerID.ReadOnly = true;
            _txtEngineerID.Size = new Size(79, 21);
            _txtEngineerID.TabIndex = 62;
            _txtEngineerID.TabStop = false;
            // 
            // lblOftecNo
            // 
            _lblOftecNo.Location = new Point(438, 21);
            _lblOftecNo.Name = "lblOftecNo";
            _lblOftecNo.Size = new Size(68, 20);
            _lblOftecNo.TabIndex = 71;
            _lblOftecNo.Text = "Oftec No.";
            // 
            // lblDepartment
            // 
            _lblDepartment.Location = new Point(5, 99);
            _lblDepartment.Name = "lblDepartment";
            _lblDepartment.Size = new Size(104, 20);
            _lblDepartment.TabIndex = 69;
            _lblDepartment.Text = "Department";
            // 
            // lblManager
            // 
            _lblManager.Location = new Point(5, 175);
            _lblManager.Name = "lblManager";
            _lblManager.Size = new Size(104, 20);
            _lblManager.TabIndex = 67;
            _lblManager.Text = "Manager";
            // 
            // lblTechnician
            // 
            _lblTechnician.Location = new Point(6, 137);
            _lblTechnician.Name = "lblTechnician";
            _lblTechnician.Size = new Size(104, 20);
            _lblTechnician.TabIndex = 66;
            _lblTechnician.Text = "Technician";
            // 
            // cboEngineerGroup
            // 
            _cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerGroup.Cursor = Cursors.Hand;
            _cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerGroup.Location = new Point(121, 58);
            _cboEngineerGroup.Name = "cboEngineerGroup";
            _cboEngineerGroup.Size = new Size(470, 21);
            _cboEngineerGroup.TabIndex = 60;
            _cboEngineerGroup.Tag = "";
            // 
            // Label37
            // 
            _Label37.Location = new Point(5, 61);
            _Label37.Name = "Label37";
            _Label37.Size = new Size(105, 20);
            _Label37.TabIndex = 65;
            _Label37.Text = "Engineer Group";
            // 
            // lblGasSafeId
            // 
            _lblGasSafeId.Location = new Point(223, 23);
            _lblGasSafeId.Name = "lblGasSafeId";
            _lblGasSafeId.Size = new Size(90, 20);
            _lblGasSafeId.TabIndex = 64;
            _lblGasSafeId.Text = "Gas Safe No.";
            // 
            // lblEngID
            // 
            _lblEngID.Location = new Point(6, 23);
            _lblEngID.Name = "lblEngID";
            _lblEngID.Size = new Size(94, 20);
            _lblEngID.TabIndex = 63;
            _lblEngID.Text = "Engineer ID";
            // 
            // dtpDrivingLicenceIssueDate
            // 
            _dtpDrivingLicenceIssueDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpDrivingLicenceIssueDate.Checked = false;
            _dtpDrivingLicenceIssueDate.Location = new Point(441, 377);
            _dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate";
            _dtpDrivingLicenceIssueDate.ShowCheckBox = true;
            _dtpDrivingLicenceIssueDate.Size = new Size(150, 21);
            _dtpDrivingLicenceIssueDate.TabIndex = 7;
            // 
            // lblDrivingLicenseDate
            // 
            _lblDrivingLicenseDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblDrivingLicenseDate.Location = new Point(359, 380);
            _lblDrivingLicenseDate.Name = "lblDrivingLicenseDate";
            _lblDrivingLicenseDate.Size = new Size(112, 20);
            _lblDrivingLicenseDate.TabIndex = 41;
            _lblDrivingLicenseDate.Text = "Issued Date";
            // 
            // txtDrivingLicenceNo
            // 
            _txtDrivingLicenceNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDrivingLicenceNo.Location = new Point(121, 377);
            _txtDrivingLicenceNo.Name = "txtDrivingLicenceNo";
            _txtDrivingLicenceNo.Size = new Size(232, 21);
            _txtDrivingLicenceNo.TabIndex = 6;
            // 
            // lblDrivingLicense
            // 
            _lblDrivingLicense.Location = new Point(6, 380);
            _lblDrivingLicense.Name = "lblDrivingLicense";
            _lblDrivingLicense.Size = new Size(112, 20);
            _lblDrivingLicense.TabIndex = 39;
            _lblDrivingLicense.Text = "Driving Licence No";
            // 
            // txtStartingDetails
            // 
            _txtStartingDetails.AcceptsReturn = true;
            _txtStartingDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtStartingDetails.Location = new Point(121, 286);
            _txtStartingDetails.Multiline = true;
            _txtStartingDetails.Name = "txtStartingDetails";
            _txtStartingDetails.ScrollBars = ScrollBars.Vertical;
            _txtStartingDetails.Size = new Size(470, 74);
            _txtStartingDetails.TabIndex = 5;
            // 
            // lblStartDetails
            // 
            _lblStartDetails.Location = new Point(6, 289);
            _lblStartDetails.Name = "lblStartDetails";
            _lblStartDetails.Size = new Size(105, 20);
            _lblStartDetails.TabIndex = 37;
            _lblStartDetails.Text = "Starting Details";
            // 
            // txtNextOfKinContact
            // 
            _txtNextOfKinContact.AcceptsReturn = true;
            _txtNextOfKinContact.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNextOfKinContact.Location = new Point(117, 494);
            _txtNextOfKinContact.Multiline = true;
            _txtNextOfKinContact.Name = "txtNextOfKinContact";
            _txtNextOfKinContact.ScrollBars = ScrollBars.Vertical;
            _txtNextOfKinContact.Size = new Size(474, 63);
            _txtNextOfKinContact.TabIndex = 10;
            // 
            // lblNextOfKinDetails
            // 
            _lblNextOfKinDetails.Location = new Point(5, 497);
            _lblNextOfKinDetails.Name = "lblNextOfKinDetails";
            _lblNextOfKinDetails.Size = new Size(112, 20);
            _lblNextOfKinDetails.TabIndex = 35;
            _lblNextOfKinDetails.Text = "Next of Kin Details";
            // 
            // txtNextOfKinName
            // 
            _txtNextOfKinName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNextOfKinName.Location = new Point(117, 456);
            _txtNextOfKinName.Name = "txtNextOfKinName";
            _txtNextOfKinName.Size = new Size(474, 21);
            _txtNextOfKinName.TabIndex = 9;
            // 
            // lblNextOfKin
            // 
            _lblNextOfKin.Location = new Point(6, 459);
            _lblNextOfKin.Name = "lblNextOfKin";
            _lblNextOfKin.Size = new Size(112, 20);
            _lblNextOfKin.TabIndex = 33;
            _lblNextOfKin.Text = "Next of Kin Name";
            // 
            // btnVanHistory
            // 
            _btnVanHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnVanHistory.Location = new Point(512, 584);
            _btnVanHistory.Name = "btnVanHistory";
            _btnVanHistory.Size = new Size(88, 23);
            _btnVanHistory.TabIndex = 11;
            _btnVanHistory.Text = "Van History";
            // 
            // txtPDAID
            // 
            _txtPDAID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPDAID.Location = new Point(121, 248);
            _txtPDAID.Name = "txtPDAID";
            _txtPDAID.Size = new Size(470, 21);
            _txtPDAID.TabIndex = 4;
            // 
            // cboRegion
            // 
            _cboRegion.Cursor = Cursors.Hand;
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(121, 210);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(470, 21);
            _cboRegion.TabIndex = 1;
            _cboRegion.Tag = "Engineer.RegionID";
            // 
            // lblRegion
            // 
            _lblRegion.Location = new Point(5, 213);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(64, 20);
            _lblRegion.TabIndex = 31;
            _lblRegion.Text = "Region";
            // 
            // lblPDAID
            // 
            _lblPDAID.Location = new Point(6, 251);
            _lblPDAID.Name = "lblPDAID";
            _lblPDAID.Size = new Size(64, 20);
            _lblPDAID.TabIndex = 31;
            _lblPDAID.Text = "PDA ID";
            // 
            // chkApprentice
            // 
            _chkApprentice.Font = new Font("Verdana", 8.0F);
            _chkApprentice.Location = new Point(121, 415);
            _chkApprentice.Name = "chkApprentice";
            _chkApprentice.Size = new Size(112, 24);
            _chkApprentice.TabIndex = 8;
            _chkApprentice.Tag = "Engineer.Apprentice";
            _chkApprentice.Text = "Apprentice";
            // 
            // tabMaxSor
            // 
            _tabMaxSor.Controls.Add(_GroupBox8);
            _tabMaxSor.Location = new Point(4, 22);
            _tabMaxSor.Name = "tabMaxSor";
            _tabMaxSor.Size = new Size(624, 622);
            _tabMaxSor.TabIndex = 10;
            _tabMaxSor.Text = "Max SOR";
            _tabMaxSor.UseVisualStyleBackColor = true;
            // 
            // GroupBox8
            // 
            _GroupBox8.BackColor = SystemColors.Control;
            _GroupBox8.Controls.Add(_txtBreakPri);
            _GroupBox8.Controls.Add(_txtServPri);
            _GroupBox8.Controls.Add(_Label40);
            _GroupBox8.Controls.Add(_Label39);
            _GroupBox8.Controls.Add(_txtDailyServiceLimit);
            _GroupBox8.Controls.Add(_Label42);
            _GroupBox8.Controls.Add(_txtSundayValue);
            _GroupBox8.Controls.Add(_txtSaturdayValue);
            _GroupBox8.Controls.Add(_txtFridayValue);
            _GroupBox8.Controls.Add(_txtThursdayValue);
            _GroupBox8.Controls.Add(_txtWednesdayValue);
            _GroupBox8.Controls.Add(_txtTuesdayValue);
            _GroupBox8.Controls.Add(_txtMondayValue);
            _GroupBox8.Controls.Add(_Label43);
            _GroupBox8.Controls.Add(_Label44);
            _GroupBox8.Controls.Add(_Label45);
            _GroupBox8.Controls.Add(_Label46);
            _GroupBox8.Controls.Add(_Label47);
            _GroupBox8.Controls.Add(_Label48);
            _GroupBox8.Controls.Add(_Label49);
            _GroupBox8.Dock = DockStyle.Fill;
            _GroupBox8.Location = new Point(0, 0);
            _GroupBox8.Name = "GroupBox8";
            _GroupBox8.Size = new Size(624, 622);
            _GroupBox8.TabIndex = 1;
            _GroupBox8.TabStop = false;
            _GroupBox8.Text = "Max Schedule Of Rate Times Per Day (In minutes)";
            // 
            // txtBreakPri
            // 
            _txtBreakPri.Location = new Point(193, 262);
            _txtBreakPri.Name = "txtBreakPri";
            _txtBreakPri.Size = new Size(41, 21);
            _txtBreakPri.TabIndex = 80;
            // 
            // txtServPri
            // 
            _txtServPri.Location = new Point(193, 235);
            _txtServPri.Name = "txtServPri";
            _txtServPri.Size = new Size(41, 21);
            _txtServPri.TabIndex = 78;
            // 
            // Label40
            // 
            _Label40.Location = new Point(28, 265);
            _Label40.Name = "Label40";
            _Label40.Size = new Size(167, 29);
            _Label40.TabIndex = 79;
            _Label40.Text = "Breakdown Priority (1-10)";
            // 
            // Label39
            // 
            _Label39.Location = new Point(28, 238);
            _Label39.Name = "Label39";
            _Label39.Size = new Size(159, 29);
            _Label39.TabIndex = 77;
            _Label39.Text = "Service Priority (1-10)";
            // 
            // txtDailyServiceLimit
            // 
            _txtDailyServiceLimit.Location = new Point(193, 209);
            _txtDailyServiceLimit.Name = "txtDailyServiceLimit";
            _txtDailyServiceLimit.Size = new Size(131, 21);
            _txtDailyServiceLimit.TabIndex = 15;
            // 
            // Label42
            // 
            _Label42.AutoSize = true;
            _Label42.Location = new Point(28, 212);
            _Label42.Name = "Label42";
            _Label42.Size = new Size(114, 13);
            _Label42.TabIndex = 14;
            _Label42.Text = "Daily Service Limit";
            // 
            // txtSundayValue
            // 
            _txtSundayValue.Location = new Point(193, 183);
            _txtSundayValue.Name = "txtSundayValue";
            _txtSundayValue.Size = new Size(131, 21);
            _txtSundayValue.TabIndex = 13;
            // 
            // txtSaturdayValue
            // 
            _txtSaturdayValue.Location = new Point(193, 157);
            _txtSaturdayValue.Name = "txtSaturdayValue";
            _txtSaturdayValue.Size = new Size(131, 21);
            _txtSaturdayValue.TabIndex = 12;
            // 
            // txtFridayValue
            // 
            _txtFridayValue.Location = new Point(193, 131);
            _txtFridayValue.Name = "txtFridayValue";
            _txtFridayValue.Size = new Size(131, 21);
            _txtFridayValue.TabIndex = 11;
            // 
            // txtThursdayValue
            // 
            _txtThursdayValue.Location = new Point(193, 105);
            _txtThursdayValue.Name = "txtThursdayValue";
            _txtThursdayValue.Size = new Size(131, 21);
            _txtThursdayValue.TabIndex = 10;
            // 
            // txtWednesdayValue
            // 
            _txtWednesdayValue.Location = new Point(193, 79);
            _txtWednesdayValue.Name = "txtWednesdayValue";
            _txtWednesdayValue.Size = new Size(131, 21);
            _txtWednesdayValue.TabIndex = 9;
            // 
            // txtTuesdayValue
            // 
            _txtTuesdayValue.Location = new Point(193, 53);
            _txtTuesdayValue.Name = "txtTuesdayValue";
            _txtTuesdayValue.Size = new Size(131, 21);
            _txtTuesdayValue.TabIndex = 8;
            // 
            // txtMondayValue
            // 
            _txtMondayValue.Location = new Point(193, 27);
            _txtMondayValue.Name = "txtMondayValue";
            _txtMondayValue.Size = new Size(131, 21);
            _txtMondayValue.TabIndex = 7;
            // 
            // Label43
            // 
            _Label43.AutoSize = true;
            _Label43.Location = new Point(28, 186);
            _Label43.Name = "Label43";
            _Label43.Size = new Size(50, 13);
            _Label43.TabIndex = 6;
            _Label43.Text = "Sunday";
            // 
            // Label44
            // 
            _Label44.AutoSize = true;
            _Label44.Location = new Point(28, 160);
            _Label44.Name = "Label44";
            _Label44.Size = new Size(59, 13);
            _Label44.TabIndex = 5;
            _Label44.Text = "Saturday";
            // 
            // Label45
            // 
            _Label45.AutoSize = true;
            _Label45.Location = new Point(28, 134);
            _Label45.Name = "Label45";
            _Label45.Size = new Size(42, 13);
            _Label45.TabIndex = 4;
            _Label45.Text = "Friday";
            // 
            // Label46
            // 
            _Label46.AutoSize = true;
            _Label46.Location = new Point(28, 108);
            _Label46.Name = "Label46";
            _Label46.Size = new Size(60, 13);
            _Label46.TabIndex = 3;
            _Label46.Text = "Thursday";
            // 
            // Label47
            // 
            _Label47.AutoSize = true;
            _Label47.Location = new Point(28, 82);
            _Label47.Name = "Label47";
            _Label47.Size = new Size(72, 13);
            _Label47.TabIndex = 2;
            _Label47.Text = "Wednesday";
            // 
            // Label48
            // 
            _Label48.AutoSize = true;
            _Label48.Location = new Point(28, 56);
            _Label48.Name = "Label48";
            _Label48.Size = new Size(54, 13);
            _Label48.TabIndex = 1;
            _Label48.Text = "Tuesday";
            // 
            // Label49
            // 
            _Label49.AutoSize = true;
            _Label49.Location = new Point(28, 30);
            _Label49.Name = "Label49";
            _Label49.Size = new Size(51, 13);
            _Label49.TabIndex = 0;
            _Label49.Text = "Monday";
            // 
            // tpWages
            // 
            _tpWages.Controls.Add(_GroupBox3);
            _tpWages.Controls.Add(_GroupBox1);
            _tpWages.Location = new Point(4, 22);
            _tpWages.Name = "tpWages";
            _tpWages.Size = new Size(624, 622);
            _tpWages.TabIndex = 1;
            _tpWages.Text = "Wages";
            _tpWages.Visible = false;
            // 
            // GroupBox3
            // 
            _GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox3.Controls.Add(_Label11);
            _GroupBox3.Controls.Add(_txtCostToCompanyDouble);
            _GroupBox3.Controls.Add(_Label12);
            _GroupBox3.Controls.Add(_txtCostToCompanyTimeHalf);
            _GroupBox3.Controls.Add(_Label13);
            _GroupBox3.Controls.Add(_txtCostToCompanyNormal);
            _GroupBox3.Location = new Point(8, 136);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(608, 120);
            _GroupBox3.TabIndex = 1;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "Cost to Company";
            // 
            // Label11
            // 
            _Label11.Location = new Point(16, 24);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(88, 20);
            _Label11.TabIndex = 55;
            _Label11.Text = "Normal";
            // 
            // txtCostToCompanyDouble
            // 
            _txtCostToCompanyDouble.Location = new Point(120, 88);
            _txtCostToCompanyDouble.Name = "txtCostToCompanyDouble";
            _txtCostToCompanyDouble.Size = new Size(144, 21);
            _txtCostToCompanyDouble.TabIndex = 6;
            // 
            // Label12
            // 
            _Label12.Location = new Point(16, 88);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(88, 20);
            _Label12.TabIndex = 54;
            _Label12.Text = "Double";
            // 
            // txtCostToCompanyTimeHalf
            // 
            _txtCostToCompanyTimeHalf.Location = new Point(120, 56);
            _txtCostToCompanyTimeHalf.Name = "txtCostToCompanyTimeHalf";
            _txtCostToCompanyTimeHalf.Size = new Size(144, 21);
            _txtCostToCompanyTimeHalf.TabIndex = 5;
            // 
            // Label13
            // 
            _Label13.Location = new Point(16, 56);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(88, 20);
            _Label13.TabIndex = 53;
            _Label13.Text = "Time && Half";
            // 
            // txtCostToCompanyNormal
            // 
            _txtCostToCompanyNormal.Location = new Point(120, 24);
            _txtCostToCompanyNormal.Name = "txtCostToCompanyNormal";
            _txtCostToCompanyNormal.Size = new Size(144, 21);
            _txtCostToCompanyNormal.TabIndex = 4;
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_txtNINumber);
            _GroupBox1.Controls.Add(_Label14);
            _GroupBox1.Controls.Add(_cboPayGrade);
            _GroupBox1.Controls.Add(_Label15);
            _GroupBox1.Controls.Add(_txtAnnualSalary);
            _GroupBox1.Controls.Add(_Label16);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(608, 120);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Wages Information";
            // 
            // txtNINumber
            // 
            _txtNINumber.Location = new Point(120, 88);
            _txtNINumber.Name = "txtNINumber";
            _txtNINumber.Size = new Size(144, 21);
            _txtNINumber.TabIndex = 3;
            _txtNINumber.Tag = "Engineer.Name";
            // 
            // Label14
            // 
            _Label14.Location = new Point(8, 88);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(87, 20);
            _Label14.TabIndex = 54;
            _Label14.Text = "NI Number";
            // 
            // cboPayGrade
            // 
            _cboPayGrade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboPayGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPayGrade.Location = new Point(120, 28);
            _cboPayGrade.Name = "cboPayGrade";
            _cboPayGrade.Size = new Size(480, 21);
            _cboPayGrade.TabIndex = 1;
            // 
            // Label15
            // 
            _Label15.Location = new Point(8, 24);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(100, 23);
            _Label15.TabIndex = 51;
            _Label15.Text = "Pay Grade";
            // 
            // txtAnnualSalary
            // 
            _txtAnnualSalary.Location = new Point(120, 56);
            _txtAnnualSalary.Name = "txtAnnualSalary";
            _txtAnnualSalary.Size = new Size(143, 21);
            _txtAnnualSalary.TabIndex = 2;
            _txtAnnualSalary.Tag = "Engineer.Name";
            // 
            // Label16
            // 
            _Label16.Location = new Point(9, 56);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(87, 20);
            _Label16.TabIndex = 50;
            _Label16.Text = "Annual Salary";
            // 
            // tpTrainingQualifications
            // 
            _tpTrainingQualifications.Controls.Add(_GroupBox5);
            _tpTrainingQualifications.Location = new Point(4, 22);
            _tpTrainingQualifications.Name = "tpTrainingQualifications";
            _tpTrainingQualifications.Size = new Size(624, 622);
            _tpTrainingQualifications.TabIndex = 3;
            _tpTrainingQualifications.Text = "Training & Qualifications";
            _tpTrainingQualifications.Visible = false;
            // 
            // GroupBox5
            // 
            _GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox5.Controls.Add(_Panel1);
            _GroupBox5.Controls.Add(_btnRemoveTrainingQualifications);
            _GroupBox5.Controls.Add(_dgTrainingQualifications);
            _GroupBox5.Location = new Point(8, 8);
            _GroupBox5.Name = "GroupBox5";
            _GroupBox5.Size = new Size(608, 608);
            _GroupBox5.TabIndex = 13;
            _GroupBox5.TabStop = false;
            _GroupBox5.Text = "Training && Qualifications";
            // 
            // Panel1
            // 
            _Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Panel1.Controls.Add(_cboQualificationType);
            _Panel1.Controls.Add(_lblQualificationType);
            _Panel1.Controls.Add(_dtpQualificationBooked);
            _Panel1.Controls.Add(_Label36);
            _Panel1.Controls.Add(_cboQualification);
            _Panel1.Controls.Add(_Label22);
            _Panel1.Controls.Add(_txtQualificatioNote);
            _Panel1.Controls.Add(_Label17);
            _Panel1.Controls.Add(_btnSaveQualification);
            _Panel1.Controls.Add(_dtpQualificationExpires);
            _Panel1.Controls.Add(_Label18);
            _Panel1.Controls.Add(_dtpQualificationPassed);
            _Panel1.Controls.Add(_Label19);
            _Panel1.Location = new Point(5, 17);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(595, 225);
            _Panel1.TabIndex = 42;
            // 
            // cboQualificationType
            // 
            _cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualificationType.Location = new Point(139, 8);
            _cboQualificationType.Name = "cboQualificationType";
            _cboQualificationType.Size = new Size(445, 21);
            _cboQualificationType.TabIndex = 54;
            _cboQualificationType.Text = "ComboBox1";
            // 
            // lblQualificationType
            // 
            _lblQualificationType.Location = new Point(7, 8);
            _lblQualificationType.Name = "lblQualificationType";
            _lblQualificationType.Size = new Size(126, 23);
            _lblQualificationType.TabIndex = 55;
            _lblQualificationType.Text = "Qualification Type";
            // 
            // dtpQualificationBooked
            // 
            _dtpQualificationBooked.Checked = false;
            _dtpQualificationBooked.Location = new Point(332, 68);
            _dtpQualificationBooked.Name = "dtpQualificationBooked";
            _dtpQualificationBooked.ShowCheckBox = true;
            _dtpQualificationBooked.Size = new Size(152, 21);
            _dtpQualificationBooked.TabIndex = 52;
            // 
            // Label36
            // 
            _Label36.Location = new Point(269, 74);
            _Label36.Name = "Label36";
            _Label36.Size = new Size(57, 23);
            _Label36.TabIndex = 53;
            _Label36.Text = "Booked";
            // 
            // cboQualification
            // 
            _cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualification.Location = new Point(96, 38);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(488, 21);
            _cboQualification.TabIndex = 1;
            _cboQualification.Text = "ComboBox1";
            // 
            // Label22
            // 
            _Label22.Location = new Point(8, 38);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(100, 23);
            _Label22.TabIndex = 48;
            _Label22.Text = "Qualification";
            // 
            // txtQualificatioNote
            // 
            _txtQualificatioNote.AcceptsReturn = true;
            _txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtQualificatioNote.Location = new Point(96, 132);
            _txtQualificatioNote.Multiline = true;
            _txtQualificatioNote.Name = "txtQualificatioNote";
            _txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
            _txtQualificatioNote.Size = new Size(488, 61);
            _txtQualificatioNote.TabIndex = 4;
            // 
            // Label17
            // 
            _Label17.Location = new Point(8, 132);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(67, 20);
            _Label17.TabIndex = 47;
            _Label17.Text = "Note";
            // 
            // btnSaveQualification
            // 
            _btnSaveQualification.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveQualification.Location = new Point(496, 199);
            _btnSaveQualification.Name = "btnSaveQualification";
            _btnSaveQualification.Size = new Size(88, 23);
            _btnSaveQualification.TabIndex = 5;
            _btnSaveQualification.Text = "Save";
            // 
            // dtpQualificationExpires
            // 
            _dtpQualificationExpires.Checked = false;
            _dtpQualificationExpires.Location = new Point(96, 99);
            _dtpQualificationExpires.Name = "dtpQualificationExpires";
            _dtpQualificationExpires.ShowCheckBox = true;
            _dtpQualificationExpires.Size = new Size(152, 21);
            _dtpQualificationExpires.TabIndex = 3;
            // 
            // Label18
            // 
            _Label18.Location = new Point(8, 105);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(80, 23);
            _Label18.TabIndex = 43;
            _Label18.Text = "Expires";
            // 
            // dtpQualificationPassed
            // 
            _dtpQualificationPassed.Checked = false;
            _dtpQualificationPassed.Location = new Point(96, 68);
            _dtpQualificationPassed.Name = "dtpQualificationPassed";
            _dtpQualificationPassed.ShowCheckBox = true;
            _dtpQualificationPassed.Size = new Size(152, 21);
            _dtpQualificationPassed.TabIndex = 2;
            // 
            // Label19
            // 
            _Label19.Location = new Point(8, 74);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(80, 23);
            _Label19.TabIndex = 41;
            _Label19.Text = "Date Passed";
            // 
            // btnRemoveTrainingQualifications
            // 
            _btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveTrainingQualifications.Location = new Point(10, 576);
            _btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications";
            _btnRemoveTrainingQualifications.Size = new Size(75, 21);
            _btnRemoveTrainingQualifications.TabIndex = 7;
            _btnRemoveTrainingQualifications.Text = "Delete";
            // 
            // dgTrainingQualifications
            // 
            _dgTrainingQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTrainingQualifications.DataMember = "";
            _dgTrainingQualifications.HeaderForeColor = SystemColors.ControlText;
            _dgTrainingQualifications.Location = new Point(8, 248);
            _dgTrainingQualifications.Name = "dgTrainingQualifications";
            _dgTrainingQualifications.Size = new Size(592, 320);
            _dgTrainingQualifications.TabIndex = 6;
            // 
            // tpKit
            // 
            _tpKit.Controls.Add(_GroupBox4);
            _tpKit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _tpKit.Location = new Point(4, 22);
            _tpKit.Name = "tpKit";
            _tpKit.Size = new Size(624, 622);
            _tpKit.TabIndex = 4;
            _tpKit.Text = "Equipment";
            _tpKit.Visible = false;
            // 
            // GroupBox4
            // 
            _GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox4.Controls.Add(_Panel2);
            _GroupBox4.Controls.Add(_btnRemoveEngineerEquipment);
            _GroupBox4.Controls.Add(_dgEquipment);
            _GroupBox4.Location = new Point(8, 8);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(608, 608);
            _GroupBox4.TabIndex = 13;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Specialised Equipment and Tools Issued";
            // 
            // Panel2
            // 
            _Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Panel2.Controls.Add(_txtEquipmentTool);
            _Panel2.Controls.Add(_Label20);
            _Panel2.Controls.Add(_btnSaveEquipment);
            _Panel2.Location = new Point(8, 16);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(592, 80);
            _Panel2.TabIndex = 2;
            // 
            // txtEquipmentTool
            // 
            _txtEquipmentTool.AcceptsReturn = true;
            _txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtEquipmentTool.Location = new Point(115, 4);
            _txtEquipmentTool.MaxLength = 255;
            _txtEquipmentTool.Multiline = true;
            _txtEquipmentTool.Name = "txtEquipmentTool";
            _txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
            _txtEquipmentTool.Size = new Size(376, 68);
            _txtEquipmentTool.TabIndex = 1;
            _txtEquipmentTool.Tag = "Engineer.Name";
            // 
            // Label20
            // 
            _Label20.Location = new Point(3, 4);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(112, 20);
            _Label20.TabIndex = 55;
            _Label20.Text = @"Equipment\Tool";
            // 
            // btnSaveEquipment
            // 
            _btnSaveEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveEquipment.Location = new Point(504, 48);
            _btnSaveEquipment.Name = "btnSaveEquipment";
            _btnSaveEquipment.Size = new Size(75, 23);
            _btnSaveEquipment.TabIndex = 2;
            _btnSaveEquipment.Text = "Save";
            // 
            // btnRemoveEngineerEquipment
            // 
            _btnRemoveEngineerEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveEngineerEquipment.Location = new Point(8, 576);
            _btnRemoveEngineerEquipment.Name = "btnRemoveEngineerEquipment";
            _btnRemoveEngineerEquipment.Size = new Size(75, 23);
            _btnRemoveEngineerEquipment.TabIndex = 4;
            _btnRemoveEngineerEquipment.Text = "Delete";
            // 
            // dgEquipment
            // 
            _dgEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgEquipment.DataMember = "";
            _dgEquipment.HeaderForeColor = SystemColors.ControlText;
            _dgEquipment.Location = new Point(8, 106);
            _dgEquipment.Name = "dgEquipment";
            _dgEquipment.Size = new Size(592, 462);
            _dgEquipment.TabIndex = 3;
            // 
            // tpDisciplinary
            // 
            _tpDisciplinary.Controls.Add(_GroupBox6);
            _tpDisciplinary.Location = new Point(4, 22);
            _tpDisciplinary.Name = "tpDisciplinary";
            _tpDisciplinary.Size = new Size(624, 622);
            _tpDisciplinary.TabIndex = 2;
            _tpDisciplinary.Text = "Disciplinary";
            _tpDisciplinary.Visible = false;
            // 
            // GroupBox6
            // 
            _GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox6.Controls.Add(_btnAddDisciplinaries);
            _GroupBox6.Controls.Add(_Panel3);
            _GroupBox6.Controls.Add(_btnRemoveDisciplinaries);
            _GroupBox6.Controls.Add(_btnEditDisciplinaries);
            _GroupBox6.Controls.Add(_dgDisciplinaries);
            _GroupBox6.Location = new Point(8, 8);
            _GroupBox6.Name = "GroupBox6";
            _GroupBox6.Size = new Size(608, 608);
            _GroupBox6.TabIndex = 14;
            _GroupBox6.TabStop = false;
            _GroupBox6.Text = "Disciplinary Records";
            // 
            // btnAddDisciplinaries
            // 
            _btnAddDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddDisciplinaries.Location = new Point(8, 576);
            _btnAddDisciplinaries.Name = "btnAddDisciplinaries";
            _btnAddDisciplinaries.Size = new Size(75, 21);
            _btnAddDisciplinaries.TabIndex = 6;
            _btnAddDisciplinaries.Text = "Add";
            // 
            // Panel3
            // 
            _Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Panel3.Controls.Add(_txtDisciplinaryID);
            _Panel3.Controls.Add(_cboDisciplinary);
            _Panel3.Controls.Add(_btnSaveDisciplinaries);
            _Panel3.Controls.Add(_Label21);
            _Panel3.Controls.Add(_dtpDisciplinaryIssued);
            _Panel3.Controls.Add(_Label23);
            _Panel3.Controls.Add(_txtDisciplinary);
            _Panel3.Controls.Add(_Label24);
            _Panel3.Location = new Point(5, 28);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(595, 80);
            _Panel3.TabIndex = 42;
            // 
            // txtDisciplinaryID
            // 
            _txtDisciplinaryID.Location = new Point(352, 31);
            _txtDisciplinaryID.Name = "txtDisciplinaryID";
            _txtDisciplinaryID.Size = new Size(100, 21);
            _txtDisciplinaryID.TabIndex = 47;
            _txtDisciplinaryID.TabStop = false;
            _txtDisciplinaryID.Visible = false;
            // 
            // cboDisciplinary
            // 
            _cboDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDisciplinary.Location = new Point(96, 53);
            _cboDisciplinary.Name = "cboDisciplinary";
            _cboDisciplinary.Size = new Size(392, 21);
            _cboDisciplinary.TabIndex = 3;
            _cboDisciplinary.Text = "ComboBox2";
            // 
            // btnSaveDisciplinaries
            // 
            _btnSaveDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveDisciplinaries.Location = new Point(496, 53);
            _btnSaveDisciplinaries.Name = "btnSaveDisciplinaries";
            _btnSaveDisciplinaries.Size = new Size(88, 21);
            _btnSaveDisciplinaries.TabIndex = 4;
            _btnSaveDisciplinaries.Text = "Save";
            // 
            // Label21
            // 
            _Label21.Location = new Point(8, 53);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(80, 23);
            _Label21.TabIndex = 43;
            _Label21.Text = "Status";
            // 
            // dtpDisciplinaryIssued
            // 
            _dtpDisciplinaryIssued.Checked = false;
            _dtpDisciplinaryIssued.Location = new Point(96, 29);
            _dtpDisciplinaryIssued.Name = "dtpDisciplinaryIssued";
            _dtpDisciplinaryIssued.ShowCheckBox = true;
            _dtpDisciplinaryIssued.Size = new Size(152, 21);
            _dtpDisciplinaryIssued.TabIndex = 2;
            // 
            // Label23
            // 
            _Label23.Location = new Point(8, 29);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(80, 23);
            _Label23.TabIndex = 41;
            _Label23.Text = "Issued";
            // 
            // txtDisciplinary
            // 
            _txtDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDisciplinary.Location = new Point(96, 5);
            _txtDisciplinary.Name = "txtDisciplinary";
            _txtDisciplinary.Size = new Size(496, 21);
            _txtDisciplinary.TabIndex = 1;
            // 
            // Label24
            // 
            _Label24.Location = new Point(8, 5);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(80, 20);
            _Label24.TabIndex = 40;
            _Label24.Text = "Disciplinary";
            // 
            // btnRemoveDisciplinaries
            // 
            _btnRemoveDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveDisciplinaries.Location = new Point(168, 576);
            _btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries";
            _btnRemoveDisciplinaries.Size = new Size(75, 21);
            _btnRemoveDisciplinaries.TabIndex = 7;
            _btnRemoveDisciplinaries.Text = "Delete";
            // 
            // btnEditDisciplinaries
            // 
            _btnEditDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnEditDisciplinaries.Location = new Point(88, 576);
            _btnEditDisciplinaries.Name = "btnEditDisciplinaries";
            _btnEditDisciplinaries.Size = new Size(75, 21);
            _btnEditDisciplinaries.TabIndex = 6;
            _btnEditDisciplinaries.Text = "Edit";
            // 
            // dgDisciplinaries
            // 
            _dgDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgDisciplinaries.DataMember = "";
            _dgDisciplinaries.HeaderForeColor = SystemColors.ControlText;
            _dgDisciplinaries.Location = new Point(8, 116);
            _dgDisciplinaries.Name = "dgDisciplinaries";
            _dgDisciplinaries.Size = new Size(592, 452);
            _dgDisciplinaries.TabIndex = 5;
            // 
            // tpDocuments
            // 
            _tpDocuments.Controls.Add(_pnlDocuments);
            _tpDocuments.Location = new Point(4, 22);
            _tpDocuments.Name = "tpDocuments";
            _tpDocuments.Size = new Size(624, 622);
            _tpDocuments.TabIndex = 6;
            _tpDocuments.Text = "Documents";
            _tpDocuments.Visible = false;
            // 
            // pnlDocuments
            // 
            _pnlDocuments.Dock = DockStyle.Fill;
            _pnlDocuments.Location = new Point(0, 0);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(624, 622);
            _pnlDocuments.TabIndex = 0;
            // 
            // tpHolidayAbsences
            // 
            _tpHolidayAbsences.Controls.Add(_grpAbsences);
            _tpHolidayAbsences.Controls.Add(_GroupBox7);
            _tpHolidayAbsences.Location = new Point(4, 22);
            _tpHolidayAbsences.Name = "tpHolidayAbsences";
            _tpHolidayAbsences.Size = new Size(624, 622);
            _tpHolidayAbsences.TabIndex = 5;
            _tpHolidayAbsences.Text = "Holidays & Absences";
            _tpHolidayAbsences.Visible = false;
            // 
            // grpAbsences
            // 
            _grpAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAbsences.Controls.Add(_dgAbsences);
            _grpAbsences.Location = new Point(8, 112);
            _grpAbsences.Name = "grpAbsences";
            _grpAbsences.Size = new Size(608, 504);
            _grpAbsences.TabIndex = 4;
            _grpAbsences.TabStop = false;
            _grpAbsences.Text = "Absences";
            // 
            // dgAbsences
            // 
            _dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAbsences.DataMember = "";
            _dgAbsences.HeaderForeColor = SystemColors.ControlText;
            _dgAbsences.Location = new Point(8, 24);
            _dgAbsences.Name = "dgAbsences";
            _dgAbsences.Size = new Size(592, 472);
            _dgAbsences.TabIndex = 4;
            // 
            // GroupBox7
            // 
            _GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox7.Controls.Add(_txtDaysHolidayAllowed);
            _GroupBox7.Controls.Add(_Label25);
            _GroupBox7.Controls.Add(_txtHolidayYearEnd);
            _GroupBox7.Controls.Add(_Label26);
            _GroupBox7.Controls.Add(_txtHolidayYearStart);
            _GroupBox7.Controls.Add(_Label27);
            _GroupBox7.Location = new Point(8, 8);
            _GroupBox7.Name = "GroupBox7";
            _GroupBox7.Size = new Size(608, 104);
            _GroupBox7.TabIndex = 0;
            _GroupBox7.TabStop = false;
            _GroupBox7.Text = "Holiday Entitlement";
            // 
            // txtDaysHolidayAllowed
            // 
            _txtDaysHolidayAllowed.Location = new Point(144, 72);
            _txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed";
            _txtDaysHolidayAllowed.Size = new Size(176, 21);
            _txtDaysHolidayAllowed.TabIndex = 3;
            // 
            // Label25
            // 
            _Label25.Location = new Point(16, 72);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(128, 23);
            _Label25.TabIndex = 4;
            _Label25.Text = "Holiday Entitlement";
            // 
            // txtHolidayYearEnd
            // 
            _txtHolidayYearEnd.Location = new Point(144, 48);
            _txtHolidayYearEnd.Name = "txtHolidayYearEnd";
            _txtHolidayYearEnd.Size = new Size(176, 21);
            _txtHolidayYearEnd.TabIndex = 2;
            // 
            // Label26
            // 
            _Label26.Location = new Point(16, 48);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(128, 23);
            _Label26.TabIndex = 2;
            _Label26.Text = "End Period (dd/mm)";
            // 
            // txtHolidayYearStart
            // 
            _txtHolidayYearStart.Location = new Point(144, 24);
            _txtHolidayYearStart.Name = "txtHolidayYearStart";
            _txtHolidayYearStart.Size = new Size(176, 21);
            _txtHolidayYearStart.TabIndex = 1;
            // 
            // Label27
            // 
            _Label27.Location = new Point(16, 24);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(128, 23);
            _Label27.TabIndex = 0;
            _Label27.Text = "Start Period (dd/mm)";
            // 
            // tpPostalRegions
            // 
            _tpPostalRegions.Controls.Add(_GroupBox2);
            _tpPostalRegions.Controls.Add(_grpPostalRegions);
            _tpPostalRegions.Location = new Point(4, 22);
            _tpPostalRegions.Name = "tpPostalRegions";
            _tpPostalRegions.Size = new Size(624, 622);
            _tpPostalRegions.TabIndex = 7;
            _tpPostalRegions.Text = "Postal Regions";
            _tpPostalRegions.Visible = false;
            // 
            // GroupBox2
            // 
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_Button1);
            _GroupBox2.Controls.Add(_TextBox1);
            _GroupBox2.Controls.Add(_Label1);
            _GroupBox2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _GroupBox2.Location = new Point(3, 3);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(605, 80);
            _GroupBox2.TabIndex = 15;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Home ";
            // 
            // Button1
            // 
            _Button1.Location = new Point(288, 24);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 43;
            _Button1.Text = "Button1";
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Visible = false;
            // 
            // TextBox1
            // 
            _TextBox1.Location = new Point(132, 25);
            _TextBox1.Name = "TextBox1";
            _TextBox1.Size = new Size(123, 21);
            _TextBox1.TabIndex = 41;
            // 
            // Label1
            // 
            _Label1.Location = new Point(29, 28);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(97, 20);
            _Label1.TabIndex = 42;
            _Label1.Text = "Home Postcode";
            // 
            // grpPostalRegions
            // 
            _grpPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpPostalRegions.Controls.Add(_Label38);
            _grpPostalRegions.Controls.Add(_txtPCSearch);
            _grpPostalRegions.Controls.Add(_Label2);
            _grpPostalRegions.Controls.Add(_dgUnTicked);
            _grpPostalRegions.Controls.Add(_dgPostalRegions);
            _grpPostalRegions.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpPostalRegions.Location = new Point(3, 89);
            _grpPostalRegions.Name = "grpPostalRegions";
            _grpPostalRegions.Size = new Size(618, 530);
            _grpPostalRegions.TabIndex = 14;
            _grpPostalRegions.TabStop = false;
            _grpPostalRegions.Text = "Postal Regions";
            // 
            // Label38
            // 
            _Label38.Font = new Font("Verdana", 10.25F);
            _Label38.Location = new Point(15, 26);
            _Label38.Name = "Label38";
            _Label38.Size = new Size(143, 20);
            _Label38.TabIndex = 43;
            _Label38.Text = "Assigned Areas";
            _Label38.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPCSearch
            // 
            _txtPCSearch.Location = new Point(369, 28);
            _txtPCSearch.Name = "txtPCSearch";
            _txtPCSearch.Size = new Size(123, 21);
            _txtPCSearch.TabIndex = 41;
            // 
            // Label2
            // 
            _Label2.Location = new Point(304, 26);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(59, 20);
            _Label2.TabIndex = 42;
            _Label2.Text = "Search";
            // 
            // dgUnTicked
            // 
            _dgUnTicked.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgUnTicked.CaptionFont = new Font("Verdana", 8.25F, FontStyle.Bold);
            _dgUnTicked.DataMember = "";
            _dgUnTicked.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgUnTicked.HeaderForeColor = SystemColors.ControlText;
            _dgUnTicked.Location = new Point(310, 62);
            _dgUnTicked.Name = "dgUnTicked";
            _dgUnTicked.Size = new Size(284, 450);
            _dgUnTicked.TabIndex = 1;
            // 
            // dgPostalRegions
            // 
            _dgPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgPostalRegions.CaptionFont = new Font("Verdana", 8.25F, FontStyle.Bold);
            _dgPostalRegions.DataMember = "";
            _dgPostalRegions.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgPostalRegions.HeaderForeColor = SystemColors.ControlText;
            _dgPostalRegions.Location = new Point(7, 62);
            _dgPostalRegions.Name = "dgPostalRegions";
            _dgPostalRegions.Size = new Size(284, 450);
            _dgPostalRegions.TabIndex = 0;
            // 
            // cboDepartment
            // 
            _cboDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDepartment.Cursor = Cursors.Hand;
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(121, 99);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(470, 21);
            _cboDepartment.TabIndex = 73;
            _cboDepartment.Tag = "Engineer.Department";
            // 
            // UCSubcontractor
            // 
            Controls.Add(_TabControl1);
            Name = "UCSubcontractor";
            Size = new Size(640, 652);
            _TabControl1.ResumeLayout(false);
            _tpContact.ResumeLayout(false);
            _tpContact.PerformLayout();
            _tpMain.ResumeLayout(false);
            _grpEngineer.ResumeLayout(false);
            _grpEngineer.PerformLayout();
            _tabMaxSor.ResumeLayout(false);
            _GroupBox8.ResumeLayout(false);
            _GroupBox8.PerformLayout();
            _tpWages.ResumeLayout(false);
            _GroupBox3.ResumeLayout(false);
            _GroupBox3.PerformLayout();
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _tpTrainingQualifications.ResumeLayout(false);
            _GroupBox5.ResumeLayout(false);
            _Panel1.ResumeLayout(false);
            _Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTrainingQualifications).EndInit();
            _tpKit.ResumeLayout(false);
            _GroupBox4.ResumeLayout(false);
            _Panel2.ResumeLayout(false);
            _Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).EndInit();
            _tpDisciplinary.ResumeLayout(false);
            _GroupBox6.ResumeLayout(false);
            _Panel3.ResumeLayout(false);
            _Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgDisciplinaries).EndInit();
            _tpDocuments.ResumeLayout(false);
            _tpHolidayAbsences.ResumeLayout(false);
            _grpAbsences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).EndInit();
            _GroupBox7.ResumeLayout(false);
            _GroupBox7.PerformLayout();
            _tpPostalRegions.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
            _grpPostalRegions.ResumeLayout(false);
            _grpPostalRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUnTicked).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgPostalRegions).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPostalRegionsDataGrid();
            SetupPostalRegionsDataGridUnTicked();
            SetupTrainingQualificationsDataGrid();
            SetupEngineerEquipmentDataGrid();
            SetupDisciplinariesDataGrid();
            SetupAbsenceDataGridGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentSubcontractor;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private UCDocumentsList DocumentsControl;
        private Entity.Subcontractors.Subcontractor _currentSubcontractor;

        public Entity.Subcontractors.Subcontractor CurrentSubcontractor
        {
            get
            {
                return _currentSubcontractor;
            }

            set
            {
                _currentSubcontractor = value;
                if (_currentSubcontractor is null)
                {
                    _currentSubcontractor = new Entity.Subcontractors.Subcontractor();
                    _currentSubcontractor.Engineer = new Entity.Engineers.Engineer();
                    _currentSubcontractor.Engineer.Exists = false;
                    _currentSubcontractor.Exists = false;
                }

                txtHolidayYearStart.Text = CurrentSubcontractor.Engineer.HolidayYearStart;
                txtHolidayYearEnd.Text = CurrentSubcontractor.Engineer.HolidayYearEnd;
                if (CurrentSubcontractor.Exists)
                {
                    Populate();
                    btnVanHistory.Enabled = true;
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblEngineer, CurrentSubcontractor.EngineerID);
                    pnlDocuments.Controls.Add(DocumentsControl);
                }
                else
                {
                    btnVanHistory.Enabled = false;
                }

                PopulatePostalRegions();
                PopulateTrainingQualifications();
                PopulateEngineerEquipment();
                PopulateDisciplinaries();
                PopulateAbsences();
            }
        }

        private Entity.MaxEngineerTimes.MaxEngineerTime _MaxTimes;

        public Entity.MaxEngineerTimes.MaxEngineerTime MaxTimes
        {
            get
            {
                return _MaxTimes;
            }

            set
            {
                _MaxTimes = value;
            }
        }

        public DataView PostalRegionsDataView
        {
            get
            {
                return postalRegionsDV;
            }

            set
            {
                postalRegionsDV = value;
                postalRegionsDV.Table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
                postalRegionsDV.AllowNew = false;
                postalRegionsDV.AllowEdit = false;
                postalRegionsDV.AllowDelete = false;
                dgPostalRegions.DataSource = PostalRegionsDataView;
            }
        }

        private DataView postalRegionsDV = null;

        private DataRow SelectedPostalRegionDataRow
        {
            get
            {
                if (!(dgPostalRegions.CurrentRowIndex == -1))
                {
                    return PostalRegionsDataView[dgPostalRegions.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataView PostalRegionsDataViewUT
        {
            get
            {
                return postalRegionsDVUT;
            }

            set
            {
                postalRegionsDVUT = value;
                postalRegionsDVUT.Table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
                postalRegionsDVUT.AllowNew = false;
                postalRegionsDVUT.AllowEdit = false;
                postalRegionsDVUT.AllowDelete = false;
                dgUnTicked.DataSource = PostalRegionsDataViewUT;
            }
        }

        private DataView postalRegionsDVUT = null;

        private DataRow SelectedPostalRegionDataRowUT
        {
            get
            {
                if (!(dgUnTicked.CurrentRowIndex == -1))
                {
                    return PostalRegionsDataViewUT[dgUnTicked.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupPostalRegionsDataGridUnTicked()
        {
            Helper.SetUpDataGrid(dgUnTicked);
            var tStyle = dgUnTicked.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgPostalRegions.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Postcode";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.MappingName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            dgUnTicked.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgUnTicked);
        }

        private void UCSubcontractor_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgPostalRegions_Clicks(object sender, EventArgs e)
        {
            try
            {
                if (SelectedPostalRegionDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgPostalRegions[dgPostalRegions.CurrentRowIndex, 0]);
                dgPostalRegions[dgPostalRegions.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVanHistory_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMVanHistory), true, new object[] { CurrentSubcontractor.EngineerID });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentSubcontractor = App.DB.SubContractor.Subcontractor_Get(ID);
            }

            txtName.Text = CurrentSubcontractor.Name;
            txtAddress1.Text = CurrentSubcontractor.Address1;
            txtAddress2.Text = CurrentSubcontractor.Address2;
            txtAddress3.Text = CurrentSubcontractor.Address3;
            txtAddress4.Text = CurrentSubcontractor.Address4;
            txtAddress5.Text = CurrentSubcontractor.Address5;
            txtPostcode.Text = CurrentSubcontractor.Postcode;
            txtTelephoneNum.Text = CurrentSubcontractor.TelephoneNum;
            txtFaxNum.Text = CurrentSubcontractor.FaxNum;
            txtEmailAddress.Text = CurrentSubcontractor.EmailAddress;
            txtNotes.Text = CurrentSubcontractor.Notes;
            var argcombo = cboLinkToSupplier;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentSubcontractor.LinkToSupplierID.ToString());
            var argcombo1 = cboTaxRate;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentSubcontractor.TaxRate.ToString());

            // engineer details
            txtEngineerID.Text = CurrentSubcontractor.Engineer.EngineerID.ToString();
            txtGasSafeNo.Text = CurrentSubcontractor.Engineer.GasSafeNo;
            txtOftecNo.Text = CurrentSubcontractor.Engineer.OftecNo;
            var argcombo2 = cboEngineerGroup;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentSubcontractor.Engineer.EngineerGroupID.ToString());
            var argcombo3 = cboDepartment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentSubcontractor.Engineer.Department.Trim());
            txtTechnician.Text = CurrentSubcontractor.Engineer.Technician;
            var argcombo4 = cboUser;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentSubcontractor.Engineer.ManagerUserID.ToString());
            var argcombo5 = cboRegion;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, CurrentSubcontractor.Engineer.RegionID.ToString());
            if (!CurrentSubcontractor.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
            {
                cboRegion.Enabled = false;
            }

            if (CurrentSubcontractor.Engineer.PDAID == 0)
            {
                txtPDAID.Text = string.Empty;
            }
            else
            {
                txtPDAID.Text = CurrentSubcontractor.Engineer.PDAID.ToString();
            }

            txtStartingDetails.Text = CurrentSubcontractor.Engineer.StartingDetails;
            txtDrivingLicenceNo.Text = CurrentSubcontractor.Engineer.DrivingLicenceNo;
            if (CurrentSubcontractor.Engineer.DrivingLicenceIssueDate != default)
            {
                dtpDrivingLicenceIssueDate.Value = CurrentSubcontractor.Engineer.DrivingLicenceIssueDate;
                dtpDrivingLicenceIssueDate.Checked = true;
            }
            else
            {
                dtpDrivingLicenceIssueDate.Value = DateAndTime.Now.Date;
                dtpDrivingLicenceIssueDate.Checked = false;
            }

            chkApprentice.Checked = CurrentSubcontractor.Engineer.Apprentice;
            txtNextOfKinName.Text = CurrentSubcontractor.Engineer.NextOfKinName;
            txtNextOfKinContact.Text = CurrentSubcontractor.Engineer.NextOfKinContact;

            // sors
            MaxTimes = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(CurrentSubcontractor.Engineer.EngineerID);
            if (MaxTimes is object)
            {
                txtMondayValue.Text = MaxTimes.MondayValue.ToString();
                txtTuesdayValue.Text = MaxTimes.TuesdayValue.ToString();
                txtWednesdayValue.Text = MaxTimes.WednesdayValue.ToString();
                txtThursdayValue.Text = MaxTimes.ThursdayValue.ToString();
                txtFridayValue.Text = MaxTimes.FridayValue.ToString();
                txtSaturdayValue.Text = MaxTimes.SaturdayValue.ToString();
                txtSundayValue.Text = MaxTimes.SundayValue.ToString();
            }
            else
            {
                MaxTimes = new Entity.MaxEngineerTimes.MaxEngineerTime();
            }

            txtDailyServiceLimit.Text = CurrentSubcontractor.Engineer.DailyServiceLimit.ToString();
            txtServPri.Text = CurrentSubcontractor.Engineer.ServPri.ToString();
            txtBreakPri.Text = CurrentSubcontractor.Engineer.BreakPri.ToString();

            // wages
            var argcombo6 = cboPayGrade;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, CurrentSubcontractor.Engineer.PayGradeID.ToString());
            txtAnnualSalary.Text = CurrentSubcontractor.Engineer.AnnualSalary.ToString();
            txtNINumber.Text = CurrentSubcontractor.Engineer.NINumber;
            txtCostToCompanyNormal.Text = Strings.Format(CurrentSubcontractor.Engineer.CostToCompanyNormal, "C");
            txtCostToCompanyTimeHalf.Text = Strings.Format(CurrentSubcontractor.Engineer.CostToCompanyTimeAndHalf, "C");
            txtCostToCompanyDouble.Text = Strings.Format(CurrentSubcontractor.Engineer.CostToCompanyDouble, "C");

            // holiday
            txtHolidayYearStart.Text = CurrentSubcontractor.Engineer.HolidayYearStart;
            txtHolidayYearEnd.Text = CurrentSubcontractor.Engineer.HolidayYearEnd;
            txtDaysHolidayAllowed.Text = CurrentSubcontractor.Engineer.DaysHolidayAllowed.ToString();
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        private void PopulatePostalRegions()
        {
            PostalRegionsDataView = App.DB.EngineerPostalRegion.Get(CurrentSubcontractor.EngineerID);
            PostalRegionsDataViewUT = App.DB.EngineerPostalRegion.GetUnTicked(CurrentSubcontractor.EngineerID);
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentSubcontractor.IgnoreExceptionsOnSetMethods = true;
                CurrentSubcontractor.SetName = txtName.Text.Trim();
                CurrentSubcontractor.SetAddress1 = txtAddress1.Text.Trim();
                CurrentSubcontractor.SetAddress2 = txtAddress2.Text.Trim();
                CurrentSubcontractor.SetAddress3 = txtAddress3.Text.Trim();
                CurrentSubcontractor.SetAddress4 = txtAddress4.Text.Trim();
                CurrentSubcontractor.SetAddress5 = txtAddress5.Text.Trim();
                CurrentSubcontractor.SetPostcode = txtPostcode.Text.Trim();
                CurrentSubcontractor.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentSubcontractor.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentSubcontractor.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentSubcontractor.SetNotes = txtNotes.Text.Trim();
                CurrentSubcontractor.Engineer.IgnoreExceptionsOnSetMethods = true;
                if (!CurrentSubcontractor.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
                {
                    CurrentSubcontractor.Engineer.SetRegionID = Combo.get_GetSelectedItemValue(cboRegion);
                }

                CurrentSubcontractor.Engineer.SetEngineerGroupID = Combo.get_GetSelectedItemValue(cboEngineerGroup);
                CurrentSubcontractor.Engineer.SetGasSafeNo = txtGasSafeNo.Text.Trim();
                CurrentSubcontractor.Engineer.SetOftecNo = txtOftecNo.Text.Trim();
                CurrentSubcontractor.Engineer.SetName = "SUBCONTRACTOR : " + txtName.Text.Trim();
                CurrentSubcontractor.Engineer.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                if (txtPDAID.Text.Trim().Length == 0)
                {
                    CurrentSubcontractor.Engineer.SetPDAID = 0;
                }
                else
                {
                    CurrentSubcontractor.Engineer.SetPDAID = txtPDAID.Text.Trim();
                }

                CurrentSubcontractor.Engineer.SetApprentice = chkApprentice.Checked;
                CurrentSubcontractor.Engineer.SetCostToCompanyNormal = Strings.Replace(txtCostToCompanyNormal.Text.Trim(), "£", "");
                CurrentSubcontractor.Engineer.SetCostToCompanyTimeAndHalf = Strings.Replace(txtCostToCompanyTimeHalf.Text.Trim(), "£", "");
                CurrentSubcontractor.Engineer.SetCostToCompanyDouble = Strings.Replace(txtCostToCompanyDouble.Text.Trim(), "£", "");
                CurrentSubcontractor.Engineer.SetNextOfKinName = txtNextOfKinName.Text;
                CurrentSubcontractor.Engineer.SetNextOfKinContact = txtNextOfKinContact.Text;
                CurrentSubcontractor.Engineer.SetStartingDetails = txtStartingDetails.Text;
                CurrentSubcontractor.Engineer.SetDrivingLicenceNo = txtDrivingLicenceNo.Text;
                if (dtpDrivingLicenceIssueDate.Checked)
                {
                    CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = dtpDrivingLicenceIssueDate.Value;
                }
                else
                {
                    CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = default;
                }

                CurrentSubcontractor.Engineer.SetPayGradeID = Combo.get_GetSelectedItemValue(cboPayGrade);
                if (txtAnnualSalary.Text.Trim().Length > 0)
                {
                    CurrentSubcontractor.Engineer.SetAnnualSalary = txtAnnualSalary.Text;
                }

                CurrentSubcontractor.Engineer.SetNINumber = txtNINumber.Text;
                CurrentSubcontractor.Engineer.SetHolidayYearStart = txtHolidayYearStart.Text;
                CurrentSubcontractor.Engineer.SetHolidayYearEnd = txtHolidayYearEnd.Text;
                if (txtDaysHolidayAllowed.Text.Trim().Length > 0)
                {
                    CurrentSubcontractor.Engineer.SetDaysHolidayAllowed = txtDaysHolidayAllowed.Text;
                }

                string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
                if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
                {
                    CurrentSubcontractor.Engineer.SetDepartment = department;
                }
                else if (!Information.IsNumeric(department))
                {
                    CurrentSubcontractor.Engineer.SetDepartment = department;
                }

                CurrentSubcontractor.Engineer.SetServPri = txtServPri.Text;
                CurrentSubcontractor.Engineer.SetBreakPri = txtBreakPri.Text;
                CurrentSubcontractor.Engineer.SetDailyServiceLimit = txtDailyServiceLimit.Text;
                CurrentSubcontractor.Engineer.SetHomePostcode = txtPostcode.Text;
                var cV = new Entity.Subcontractors.SubcontractorValidator();
                cV.Validate(CurrentSubcontractor);
                CurrentSubcontractor.SetLinkToSupplierID = Combo.get_GetSelectedItemValue(cboLinkToSupplier);
                CurrentSubcontractor.SetTaxRate = Combo.get_GetSelectedItemValue(cboTaxRate);
                if (CurrentSubcontractor.Exists)
                {
                    App.DB.SubContractor.Update(CurrentSubcontractor);
                    App.DB.Engineer.Update(CurrentSubcontractor.Engineer);
                    App.DB.EngineerPostalRegion.Delete(CurrentSubcontractor.EngineerID);
                    foreach (DataRow row in PostalRegionsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(row["Tick"]))
                        {
                            App.DB.EngineerPostalRegion.Insert(CurrentSubcontractor.EngineerID, Conversions.ToInteger(row["ManagerID"]));
                        }
                    }

                    App.DB.EngineerLevel.Insert(CurrentSubcontractor.EngineerID, TrainingQualificationsDataView.Table);
                    App.DB.Engineer.SaveEquipmentRecords(CurrentSubcontractor.EngineerID, EngineerEquipmentDataView.Table);
                    App.DB.Engineer.SaveDisciplinaryRecords(CurrentSubcontractor.EngineerID, DisciplinariesDataView.Table);
                }
                else
                {
                    var tempEng = App.DB.Engineer.Insert(CurrentSubcontractor.Engineer);
                    App.DB.EngineerPostalRegion.Delete(tempEng.EngineerID);
                    foreach (DataRow row in PostalRegionsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(row["Tick"]))
                        {
                            App.DB.EngineerPostalRegion.Insert(tempEng.EngineerID, Conversions.ToInteger(row["ManagerID"]));
                        }
                    }

                    App.DB.EngineerLevel.Insert(tempEng.EngineerID, TrainingQualificationsDataView.Table);
                    App.DB.Engineer.SaveEquipmentRecords(tempEng.EngineerID, EngineerEquipmentDataView.Table);
                    App.DB.Engineer.SaveDisciplinaryRecords(tempEng.EngineerID, DisciplinariesDataView.Table);
                    CurrentSubcontractor.Engineer = tempEng;
                    CurrentSubcontractor.SetEngineerID = tempEng.EngineerID;
                    CurrentSubcontractor = App.DB.SubContractor.Insert(CurrentSubcontractor);
                }

                if (MaxTimes is null)
                {
                    MaxTimes = new Entity.MaxEngineerTimes.MaxEngineerTime();
                }

                MaxTimes.SetEngineerID = CurrentSubcontractor.Engineer.EngineerID;
                MaxTimes.SetMondayValue = Helper.MakeIntegerValid(txtMondayValue.Text.Trim());
                MaxTimes.SetTuesdayValue = Helper.MakeIntegerValid(txtTuesdayValue.Text.Trim());
                MaxTimes.SetWednesdayValue = Helper.MakeIntegerValid(txtWednesdayValue.Text.Trim());
                MaxTimes.SetThursdayValue = Helper.MakeIntegerValid(txtThursdayValue.Text.Trim());
                MaxTimes.SetFridayValue = Helper.MakeIntegerValid(txtFridayValue.Text.Trim());
                MaxTimes.SetSaturdayValue = Helper.MakeIntegerValid(txtSaturdayValue.Text.Trim());
                MaxTimes.SetSundayValue = Helper.MakeIntegerValid(txtSundayValue.Text.Trim());
                var mTV = new Entity.MaxEngineerTimes.MaxEngineerTimeValidator();
                mTV.Validate(MaxTimes);
                if (MaxTimes.Exists)
                {
                    App.DB.MaxEngineerTime.Update(MaxTimes);
                }
                else
                {
                    App.DB.MaxEngineerTime.Insert(MaxTimes);
                }

                RecordsChanged?.Invoke(App.DB.SubContractor.Subcontractor_GetAll(), Enums.PageViewing.Subcontractor, true, false, "");
                StateChanged?.Invoke(CurrentSubcontractor.SubcontractorID);
                App.MainForm.RefreshEntity(CurrentSubcontractor.SubcontractorID);
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

        public void SetupPostalRegionsDataGrid()
        {
            Helper.SetUpDataGrid(dgPostalRegions);
            var tStyle = dgPostalRegions.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgPostalRegions.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.MappingName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            dgPostalRegions.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgPostalRegions);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupTrainingQualificationsDataGrid()
        {
            try
            {
                dgTrainingQualifications.TableStyles.Add(new DataGridTableStyle());
                Helper.SetUpDataGrid(dgTrainingQualifications);
                var tStyle = dgTrainingQualifications.TableStyles[0];

                // , DateExpires

                var Qualification = new DataGridTextBoxColumn();
                Qualification.HeaderText = @"Level\Qualification";
                Qualification.MappingName = "Level";
                Qualification.NullText = "";
                Qualification.Width = 150;
                tStyle.GridColumnStyles.Add(Qualification);
                var Description = new DataGridTextBoxColumn();
                Description.HeaderText = "Description";
                Description.MappingName = "Description";
                Description.NullText = "";
                Description.Width = 200;
                tStyle.GridColumnStyles.Add(Description);
                var Notes = new DataGridTextBoxColumn();
                Notes.HeaderText = "Notes";
                Notes.MappingName = "Notes";
                Notes.NullText = "";
                Notes.Width = 400;
                tStyle.GridColumnStyles.Add(Notes);
                var DatePassed = new DataGridTextBoxColumn();
                DatePassed.HeaderText = "Passed";
                DatePassed.MappingName = "DatePassed";
                DatePassed.Format = "dd/MM/yyyy";
                DatePassed.NullText = "";
                DatePassed.Width = 80;
                tStyle.GridColumnStyles.Add(DatePassed);
                var DateExpires = new DataGridTextBoxColumn();
                DateExpires.HeaderText = "Expires";
                DateExpires.MappingName = "DateExpires";
                DateExpires.Format = "dd/MM/yyyy";
                DateExpires.NullText = "";
                DateExpires.Width = 80;
                tStyle.GridColumnStyles.Add(DateExpires);
                var DateBooked = new DataGridTextBoxColumn();
                DateBooked.HeaderText = "Booked";
                DateBooked.MappingName = "DateBooked";
                DateBooked.Format = "dd/MM/yyyy";
                DateBooked.NullText = "";
                DateBooked.Width = 80;
                tStyle.GridColumnStyles.Add(DateBooked);
                tStyle.MappingName = Enums.TableNames.tblEngineerLevel.ToString();
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataView _trainingQualificationsDataView;

        private DataView TrainingQualificationsDataView
        {
            get
            {
                return _trainingQualificationsDataView;
            }

            set
            {
                if (value is object)
                {
                    _trainingQualificationsDataView = value;
                    _trainingQualificationsDataView.Table.TableName = Enums.TableNames.tblEngineerLevel.ToString();
                }

                dgTrainingQualifications.DataSource = _trainingQualificationsDataView;
            }
        }

        public DataRow SelectedTrainingQualificationsRow
        {
            get
            {
                if (TrainingQualificationsDataView is object)
                {
                    if (TrainingQualificationsDataView.Table.Rows.Count > 0)
                    {
                        return TrainingQualificationsDataView[dgTrainingQualifications.CurrentRowIndex].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return default;
            }
        }

        private void PopulateTrainingQualifications()
        {
            try
            {
                TrainingQualificationsDataView = App.DB.EngineerLevel.GetForSetup(CurrentSubcontractor.EngineerID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearQualificationDetailPanel()
        {
            var argcombo = cboQualification;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            txtQualificatioNote.Text = "";
            dtpQualificationPassed.Checked = false;
            dtpQualificationExpires.Checked = false;
        }

        private void btnSaveQualification_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Qualifications))
                App.ShowSecurityError();
            try
            {
                var UpdateFlag = default(bool);
                DataRow r;
                r = TrainingQualificationsDataView.Table.NewRow();
                var v = new BaseValidator();
                var check = TrainingQualificationsDataView.Table.Select("LevelID = " + Combo.get_GetSelectedItemValue(cboQualification)).FirstOrDefault();
                if (check is object)
                {
                    string msg = "This will update the qualification. ";
                    msg += "Do you wish to Procceed.";
                    if (App.ShowMessage(msg, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        UpdateFlag = true;
                    }
                }

                if (cboQualification.SelectedIndex == 0)
                {
                    v.AddCriticalMessage("'Qualification' is required");
                }

                if (dtpQualificationPassed.Checked == false)
                {
                    v.AddCriticalMessage("'Date Passed' must be specified.");
                }

                if (v.ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(v);
                }

                r["LevelID"] = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQualification));
                r["Level"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[1].Trim();
                r["Description"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[0].Trim();
                r["Notes"] = txtQualificatioNote.Text;
                if (dtpQualificationPassed.Checked)
                {
                    r["DatePassed"] = dtpQualificationPassed.Value;
                }

                if (dtpQualificationExpires.Checked)
                {
                    r["DateExpires"] = dtpQualificationExpires.Value;
                }

                if (dtpQualificationBooked.Checked)
                {
                    r["DateBooked"] = dtpQualificationBooked.Value;
                }

                if (UpdateFlag)
                {
                    foreach (DataColumn dc in check.Table.Columns)
                        check[dc] = r[dc];
                }
                else
                {
                    TrainingQualificationsDataView.Table.Rows.Add(r);
                }

                ClearQualificationDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTrainingQualifications_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Qualifications))
                App.ShowSecurityError();
            try
            {
                var r = SelectedTrainingQualificationsRow;
                if (r is object)
                {
                    if (MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        TrainingQualificationsDataView.Table.Rows.Remove(r);
                    }
                }

                ClearQualificationDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupEngineerEquipmentDataGrid()
        {
            try
            {
                dgEquipment.TableStyles.Add(new DataGridTableStyle());
                Helper.SetUpDataGrid(dgEquipment);
                var tStyle = dgEquipment.TableStyles[0];
                var Equipment = new DataGridTextBoxColumn();
                Equipment.HeaderText = "Equipment";
                Equipment.MappingName = "Equipment";
                Equipment.NullText = "";
                Equipment.Width = 250;
                tStyle.GridColumnStyles.Add(Equipment);
                tStyle.MappingName = "tblEngineerEquipment";
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataView _engineerEquipmentDataView;

        private DataView EngineerEquipmentDataView
        {
            get
            {
                return _engineerEquipmentDataView;
            }

            set
            {
                if (value is object)
                {
                    _engineerEquipmentDataView = value;
                    _engineerEquipmentDataView.Table.TableName = "tblEngineerEquipment";
                }

                dgEquipment.DataSource = _engineerEquipmentDataView;
            }
        }

        public DataRow SelectedEngineerEquipmentRow
        {
            get
            {
                if (EngineerEquipmentDataView is object)
                {
                    if (EngineerEquipmentDataView.Table.Rows.Count > 0)
                    {
                        return EngineerEquipmentDataView[dgEquipment.CurrentRowIndex].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return default;
            }
        }

        private void PopulateEngineerEquipment()
        {
            try
            {
                EngineerEquipmentDataView = new DataView(App.DB.Engineer.GetEquipmentRecords(CurrentSubcontractor.EngineerID));
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearEquipmentDetailPanel()
        {
            txtEquipmentTool.Text = "";
        }

        private void btnSaveEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r;
                r = EngineerEquipmentDataView.Table.NewRow();
                var v = new BaseValidator();
                if (txtEquipmentTool.Text.Length == 0)
                {
                    v.AddCriticalMessage(@"'Equipment\Tool' cannot be empty.");
                }

                if (v.ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(v);
                }

                r["Equipment"] = txtEquipmentTool.Text;
                EngineerEquipmentDataView.Table.Rows.Add(r);
                ClearEquipmentDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveEngineerEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                var r = SelectedEngineerEquipmentRow;
                if (r is object)
                {
                    if (MessageBox.Show("Are you sure you want to delete this equipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        EngineerEquipmentDataView.Table.Rows.Remove(r);
                    }
                }

                ClearEquipmentDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupDisciplinariesDataGrid()
        {
            try
            {
                dgDisciplinaries.TableStyles.Add(new DataGridTableStyle());
                Helper.SetUpDataGrid(dgDisciplinaries);
                var tStyle = dgDisciplinaries.TableStyles[0];
                var Disciplinary = new DataGridTextBoxColumn();
                Disciplinary.HeaderText = "Disciplinary";
                Disciplinary.MappingName = "Disciplinary";
                Disciplinary.NullText = "";
                Disciplinary.Width = 150;
                tStyle.GridColumnStyles.Add(Disciplinary);
                var DisciplinaryStatus = new DataGridTextBoxColumn();
                DisciplinaryStatus.HeaderText = "Status";
                DisciplinaryStatus.MappingName = "DisciplinaryStatus";
                DisciplinaryStatus.NullText = "";
                DisciplinaryStatus.Width = 150;
                tStyle.GridColumnStyles.Add(DisciplinaryStatus);
                var DateIssued = new DataGridTextBoxColumn();
                DateIssued.HeaderText = "Date Issued";
                DateIssued.MappingName = "DateIssued";
                DateIssued.NullText = "";
                DateIssued.Width = 80;
                tStyle.GridColumnStyles.Add(DateIssued);
                tStyle.MappingName = "tblDisciplinaries";
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataView _disciplinariesDataView;

        private DataView DisciplinariesDataView
        {
            get
            {
                return _disciplinariesDataView;
            }

            set
            {
                if (value is object)
                {
                    _disciplinariesDataView = value;
                    _disciplinariesDataView.Table.TableName = "tblDisciplinaries";
                }

                dgDisciplinaries.DataSource = _disciplinariesDataView;
            }
        }

        public DataRow SelectedDisciplinariesRow
        {
            get
            {
                if (DisciplinariesDataView is object)
                {
                    if (DisciplinariesDataView.Table.Rows.Count > 0)
                    {
                        return DisciplinariesDataView[dgDisciplinaries.CurrentRowIndex].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return default;
            }
        }

        private void ClearDisciplinaryDetailPanel()
        {
            txtDisciplinaryID.Text = "";
            txtDisciplinary.Text = "";
            dtpDisciplinaryIssued.Checked = false;
            cboDisciplinary.SelectedIndex = 0;
        }

        private void PopulateDisciplinaries()
        {
            try
            {
                DisciplinariesDataView = new DataView(App.DB.Engineer.GetDisciplinaryRecords(CurrentSubcontractor.EngineerID));
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDisciplinaries_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r;
                if (txtDisciplinaryID.Text.Length == 0)
                {
                    r = DisciplinariesDataView.Table.NewRow();
                    r["DisciplinaryID"] = DisciplinariesDataView.Table.Rows.Count + 1;
                }
                else
                {
                    r = SelectedDisciplinariesRow;
                }

                var v = new BaseValidator();
                if (txtDisciplinary.Text.Length == 0)
                {
                    v.AddCriticalMessage("'Disciplinary' cannot be empty.");
                }

                if (dtpDisciplinaryIssued.Checked == false)
                {
                    v.AddCriticalMessage("'Issued' must have a date.");
                }

                if (cboDisciplinary.SelectedIndex == 0)
                {
                    v.AddCriticalMessage("'Disciplinary Status' required.");
                }

                if (v.ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(v);
                }

                if (r is object)
                {
                    r["Disciplinary"] = txtDisciplinary.Text;
                    r["DateIssued"] = dtpDisciplinaryIssued.Value;
                    r["DisciplinaryStatusID"] = Combo.get_GetSelectedItemValue(cboDisciplinary);
                    r["DisciplinaryStatus"] = Combo.get_GetSelectedItemDescription(cboDisciplinary);
                }

                if (txtDisciplinaryID.Text.Length == 0)
                {
                    DisciplinariesDataView.Table.Rows.Add(r);
                }
                else
                {
                    r.AcceptChanges();
                }

                ClearDisciplinaryDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDisciplinaries_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDisciplinaryDetailPanel();
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDisciplinaries_Click(object sender, EventArgs e)
        {
            try
            {
                var r = SelectedDisciplinariesRow;
                if (r is object)
                {
                    txtDisciplinaryID.Text = Conversions.ToString(r["DisciplinaryID"]);
                    txtDisciplinary.Text = Conversions.ToString(r["Disciplinary"]);
                    dtpDisciplinaryIssued.Value = Conversions.ToDate(r["DateIssued"]);
                    var argcombo = cboDisciplinary;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(r["DisciplinaryStatusID"]));
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
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDisciplinaries_Click(object sender, EventArgs e)
        {
            try
            {
                var r = SelectedDisciplinariesRow;
                if (r is object)
                {
                    if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DisciplinariesDataView.Table.Rows.Remove(r);
                    }
                }

                ClearDisciplinaryDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupAbsenceDataGridGrid()
        {
            SuspendLayout();
            Helper.SetUpDataGrid(dgAbsences);
            var tbStyle = dgAbsences.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            dgAbsences.ReadOnly = true;
            var UnavailableType = new DataGridLabelColumn();
            UnavailableType.MappingName = "Description";
            UnavailableType.HeaderText = "Type";
            UnavailableType.Width = 110;
            UnavailableType.NullText = "";
            UnavailableType.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(UnavailableType);
            var DateFrom = new DataGridLabelColumn();
            DateFrom.MappingName = "DateFrom";
            DateFrom.HeaderText = "Date From";
            DateFrom.Format = "dd/MM/yyyy HH:mm";
            DateFrom.Width = 100;
            DateFrom.NullText = "";
            DateFrom.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(DateFrom);
            var DateTo = new DataGridLabelColumn();
            DateTo.MappingName = "DateTo";
            DateTo.HeaderText = "Date To";
            DateTo.Format = "dd/MM/yyyy HH:mm";
            DateTo.NullText = "";
            DateTo.Width = 100;
            DateTo.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(DateTo);
            var Comments = new DataGridLabelColumn();
            Comments.MappingName = "Comments";
            Comments.HeaderText = "Comments";
            Comments.NullText = "";
            Comments.Width = 200;
            Comments.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(Comments);
            tbStyle.MappingName = "tblEngineerAbsence";
            dgAbsences.TableStyles.Add(tbStyle);
            ResumeLayout();
        }

        private DataView _dvAbsences = new DataView();

        public DataView AbsencesDataView
        {
            get
            {
                return _dvAbsences;
            }

            set
            {
                _dvAbsences = value;
                _dvAbsences.Table.TableName = "tblEngineerAbsence";
                dgAbsences.DataSource = _dvAbsences;
                _dvAbsences.AllowNew = false;
                _dvAbsences.AllowEdit = false;
                _dvAbsences.AllowDelete = false;
            }
        }

        private void PopulateAbsences()
        {
            try
            {
                AbsencesDataView = new DataView(App.DB.EngineerAbsence.GetAbsencesForEngineer(CurrentSubcontractor.EngineerID));
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgTrainingQualifications_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                var argc = cboQualificationType;
                Combo.SetUpCombo(ref argc, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
                var argcombo = cboQualification;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, SelectedTrainingQualificationsRow[0].ToString());
                txtQualificatioNote.Text = Helper.MakeStringValid(SelectedTrainingQualificationsRow[3]);
                dtpQualificationPassed.Value = Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow[4]);
                dtpQualificationExpires.Value = Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow[5]);
                dtpQualificationBooked.Value = Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow[6]);
            }
            catch
            {
            }
        }

        private void dgPostalRegions_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedPostalRegionDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgPostalRegions[dgPostalRegions.CurrentRowIndex, 0]);
                SelectedPostalRegionDataRow[0] = selected;
                PostalRegionsDataViewUT.Table.ImportRow(SelectedPostalRegionDataRow);
                PostalRegionsDataView.Table.Rows.RemoveAt(dgPostalRegions.CurrentRowIndex);
                PostalRegionsDataViewUT.Table.Select("", "Name ASC");
                dgUnTicked.DataSource = PostalRegionsDataViewUT;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgUnTicked_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedPostalRegionDataRowUT is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgUnTicked[dgUnTicked.CurrentRowIndex, 0]);
                SelectedPostalRegionDataRowUT[0] = selected;
                PostalRegionsDataView.Table.ImportRow(SelectedPostalRegionDataRowUT);
                PostalRegionsDataViewUT.Table.Rows.Remove(SelectedPostalRegionDataRowUT);
                PostalRegionsDataView.Table.Select("", "Name ASC");
                dgPostalRegions.DataSource = PostalRegionsDataView;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPCSearch_TextChanged(object sender, EventArgs e)
        {
            string whereClause = "Name Like '%" + txtPCSearch.Text + "%'";
            PostalRegionsDataViewUT.RowFilter = whereClause;
        }

        private void cboQualificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int skillTypeId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboQualificationType));
                if (skillTypeId > 0)
                {
                    var argc = cboQualification;
                    Combo.SetUpCombo(ref argc, App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Enums.ComboValues.Please_Select);
                }
                else
                {
                    var argc1 = cboQualification;
                    Combo.SetUpComboQual(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}