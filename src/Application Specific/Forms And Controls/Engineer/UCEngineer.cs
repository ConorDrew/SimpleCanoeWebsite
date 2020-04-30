using FSM.Entity.Engineers;
using FSM.Entity.Engineers.SiteSafetyAudits;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCEngineer : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCEngineer() : base()
        {
            base.Load += UCEngineer_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            TabControl1.TabPages.Clear();
            TabControl1.TabPages.Add(tpMain);
            TabControl1.TabPages.Add(tpPostalRegions);
            TabControl1.TabPages.Add(tpMaxTimes);
            TabControl1.TabPages.Add(tpTrainingQualifications);
            // 'TabControl1.TabPages.Add(tpWages)
            TabControl1.TabPages.Add(tpHolidayAbsences);
            TabControl1.TabPages.Add(tpDisciplinary);
            TabControl1.TabPages.Add(tpKit);
            TabControl1.TabPages.Add(tpDocuments);
            TabControl1.TabPages.Add(tpSiteSafetyAudits);

            // Add any initialization after the InitializeComponent() call
            var argc = cboRegionID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboEngineerGroup;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            // 'Combo.SetUpCombo(Me.cboPayGrade, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            var argc2 = cboDisciplinary;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboQualificationType;
            Combo.SetUpCombo(ref argc3, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboQualification;
            Combo.SetUpComboQual(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboUser;
            Combo.SetUpCombo(ref argc5, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Not_Applicable);
            var argc6 = cboRagRating;
            Combo.SetUpCombo(ref argc6, App.DB.RagRating.Get_All().Table, "Id", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboLinkToUser;
            Combo.SetUpCombo(ref argc7, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Please_Select);
            var argc8 = cboEngineerRoleId;
            Combo.SetUpCombo(ref argc8, App.DB.EngineerRole.GetLookupData().Table, "Id", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc9 = cboDepartment;
                        Combo.SetUpCombo(ref argc9, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc10 = cboDepartment;
                        Combo.SetUpCombo(ref argc10, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
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

        private Label _lblEngineerID;

        internal Label lblEngineerID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerID != null)
                {
                }

                _lblEngineerID = value;
                if (_lblEngineerID != null)
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
                    _dgPostalRegions.Click -= dgPostalRegions_Clicks;
                }

                _dgPostalRegions = value;
                if (_dgPostalRegions != null)
                {
                    _dgPostalRegions.Click += dgPostalRegions_Clicks;
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
                    _dgTrainingQualifications.Click -= dgTrainingQualifications_Click;
                    _dgTrainingQualifications.CurrentCellChanged -= dgTrainingQualifications_Click;
                }

                _dgTrainingQualifications = value;
                if (_dgTrainingQualifications != null)
                {
                    _dgTrainingQualifications.Click += dgTrainingQualifications_Click;
                    _dgTrainingQualifications.CurrentCellChanged += dgTrainingQualifications_Click;
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

        private TabPage _tpMaxTimes;

        internal TabPage tpMaxTimes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpMaxTimes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpMaxTimes != null)
                {
                }

                _tpMaxTimes = value;
                if (_tpMaxTimes != null)
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

        private TextBox _TxtOftec;

        internal TextBox TxtOftec
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TxtOftec;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TxtOftec != null)
                {
                }

                _TxtOftec = value;
                if (_TxtOftec != null)
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

        private CheckBox _cbxShowOnJob;

        internal CheckBox cbxShowOnJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxShowOnJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxShowOnJob != null)
                {
                }

                _cbxShowOnJob = value;
                if (_cbxShowOnJob != null)
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _txtPCSearch.TextChanged -= txtFilter_TextChanged;
                }

                _txtPCSearch = value;
                if (_txtPCSearch != null)
                {
                    _txtPCSearch.TextChanged += txtFilter_TextChanged;
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
                    _dgUnTicked.Click -= dgPostalRegionsUnticked_Clicks;
                }

                _dgUnTicked = value;
                if (_dgUnTicked != null)
                {
                    _dgUnTicked.Click += dgPostalRegionsUnticked_Clicks;
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

        private TextBox _txtWebAppPassword;

        internal TextBox txtWebAppPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWebAppPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWebAppPassword != null)
                {
                    _txtWebAppPassword.TextChanged -= TextBox1_TextChanged;
                }

                _txtWebAppPassword = value;
                if (_txtWebAppPassword != null)
                {
                    _txtWebAppPassword.TextChanged += TextBox1_TextChanged;
                }
            }
        }

        private Label _lbllWebAppPassword;

        internal Label lbllWebAppPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbllWebAppPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbllWebAppPassword != null)
                {
                    _lbllWebAppPassword.Click -= Label43_Click;
                }

                _lbllWebAppPassword = value;
                if (_lbllWebAppPassword != null)
                {
                    _lbllWebAppPassword.Click += Label43_Click;
                }
            }
        }

        private ComboBox _cboRagRating;

        internal ComboBox cboRagRating
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRagRating;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRagRating != null)
                {
                }

                _cboRagRating = value;
                if (_cboRagRating != null)
                {
                }
            }
        }

        private Label _lblRagDate;

        internal Label lblRagDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRagDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRagDate != null)
                {
                }

                _lblRagDate = value;
                if (_lblRagDate != null)
                {
                }
            }
        }

        private Label _lblRagRating;

        internal Label lblRagRating
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRagRating;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRagRating != null)
                {
                }

                _lblRagRating = value;
                if (_lblRagRating != null)
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

        private DateTimePicker _dtpRagDate;

        internal DateTimePicker dtpRagDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRagDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRagDate != null)
                {
                }

                _dtpRagDate = value;
                if (_dtpRagDate != null)
                {
                }
            }
        }

        private TabPage _tpSiteSafetyAudits;

        internal TabPage tpSiteSafetyAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpSiteSafetyAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpSiteSafetyAudits != null)
                {
                }

                _tpSiteSafetyAudits = value;
                if (_tpSiteSafetyAudits != null)
                {
                }
            }
        }

        private GroupBox _grpSiteSafetyAudits;

        internal GroupBox grpSiteSafetyAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteSafetyAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteSafetyAudits != null)
                {
                }

                _grpSiteSafetyAudits = value;
                if (_grpSiteSafetyAudits != null)
                {
                }
            }
        }

        private GroupBox _grpSiteSafetyAudit;

        internal GroupBox grpSiteSafetyAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteSafetyAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteSafetyAudit != null)
                {
                }

                _grpSiteSafetyAudit = value;
                if (_grpSiteSafetyAudit != null)
                {
                }
            }
        }

        private Button _btnSaveAudit;

        internal Button btnSaveAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveAudit != null)
                {
                    _btnSaveAudit.Click -= btnSaveAudit_Click;
                }

                _btnSaveAudit = value;
                if (_btnSaveAudit != null)
                {
                    _btnSaveAudit.Click += btnSaveAudit_Click;
                }
            }
        }

        private System.ComponentModel.BackgroundWorker _BackgroundWorker1;

        internal System.ComponentModel.BackgroundWorker BackgroundWorker1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BackgroundWorker1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BackgroundWorker1 != null)
                {
                }

                _BackgroundWorker1 = value;
                if (_BackgroundWorker1 != null)
                {
                }
            }
        }

        private DataGrid _dgSiteSafetyAudits;

        internal DataGrid dgSiteSafetyAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteSafetyAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteSafetyAudits != null)
                {
                    _dgSiteSafetyAudits.Click -= dgSiteSafetyAudits_Click;
                }

                _dgSiteSafetyAudits = value;
                if (_dgSiteSafetyAudits != null)
                {
                    _dgSiteSafetyAudits.Click += dgSiteSafetyAudits_Click;
                }
            }
        }

        private Button _btnNewAudit;

        internal Button btnNewAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNewAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNewAudit != null)
                {
                    _btnNewAudit.Click -= btnNewAudit_Click;
                }

                _btnNewAudit = value;
                if (_btnNewAudit != null)
                {
                    _btnNewAudit.Click += btnNewAudit_Click;
                }
            }
        }

        private DateTimePicker _dtpAuditDate;

        internal DateTimePicker dtpAuditDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpAuditDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpAuditDate != null)
                {
                }

                _dtpAuditDate = value;
                if (_dtpAuditDate != null)
                {
                }
            }
        }

        private Label _lblAuditDate;

        internal Label lblAuditDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAuditDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAuditDate != null)
                {
                }

                _lblAuditDate = value;
                if (_lblAuditDate != null)
                {
                }
            }
        }

        private TextBox _txtVehicleSafetyCondition;

        internal TextBox txtVehicleSafetyCondition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVehicleSafetyCondition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVehicleSafetyCondition != null)
                {
                }

                _txtVehicleSafetyCondition = value;
                if (_txtVehicleSafetyCondition != null)
                {
                }
            }
        }

        private Label _lblVehicleCheck;

        internal Label lblVehicleCheck
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVehicleCheck;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVehicleCheck != null)
                {
                }

                _lblVehicleCheck = value;
                if (_lblVehicleCheck != null)
                {
                }
            }
        }

        private Label _lblLine;

        internal Label lblLine
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLine;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLine != null)
                {
                }

                _lblLine = value;
                if (_lblLine != null)
                {
                }
            }
        }

        private TextBox _txtTotal;

        internal TextBox txtTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotal != null)
                {
                }

                _txtTotal = value;
                if (_txtTotal != null)
                {
                }
            }
        }

        private Label _lblTotal;

        internal Label lblTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotal != null)
                {
                }

                _lblTotal = value;
                if (_lblTotal != null)
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

        private Label _lblAsbestos;

        internal Label lblAsbestos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAsbestos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAsbestos != null)
                {
                }

                _lblAsbestos = value;
                if (_lblAsbestos != null)
                {
                }
            }
        }

        private TextBox _txtCOSSH;

        internal TextBox txtCOSSH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCOSSH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCOSSH != null)
                {
                }

                _txtCOSSH = value;
                if (_txtCOSSH != null)
                {
                }
            }
        }

        private Label _lblCOSSH;

        internal Label lblCOSSH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCOSSH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCOSSH != null)
                {
                }

                _lblCOSSH = value;
                if (_lblCOSSH != null)
                {
                }
            }
        }

        private TextBox _txtFirstAidWelfare;

        internal TextBox txtFirstAidWelfare
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFirstAidWelfare;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFirstAidWelfare != null)
                {
                }

                _txtFirstAidWelfare = value;
                if (_txtFirstAidWelfare != null)
                {
                }
            }
        }

        private Label _lblFirstAidWelfare;

        internal Label lblFirstAidWelfare
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstAidWelfare;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstAidWelfare != null)
                {
                }

                _lblFirstAidWelfare = value;
                if (_lblFirstAidWelfare != null)
                {
                }
            }
        }

        private TextBox _txtWorkingAtHeight;

        internal TextBox txtWorkingAtHeight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWorkingAtHeight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWorkingAtHeight != null)
                {
                }

                _txtWorkingAtHeight = value;
                if (_txtWorkingAtHeight != null)
                {
                }
            }
        }

        private Label _lblWorkingAtHeight;

        internal Label lblWorkingAtHeight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWorkingAtHeight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWorkingAtHeight != null)
                {
                }

                _lblWorkingAtHeight = value;
                if (_lblWorkingAtHeight != null)
                {
                }
            }
        }

        private TextBox _txtManualHandling;

        internal TextBox txtManualHandling
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtManualHandling;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtManualHandling != null)
                {
                }

                _txtManualHandling = value;
                if (_txtManualHandling != null)
                {
                }
            }
        }

        private Label _lblManualHandling;

        internal Label lblManualHandling
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblManualHandling;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblManualHandling != null)
                {
                }

                _lblManualHandling = value;
                if (_lblManualHandling != null)
                {
                }
            }
        }

        private TextBox _txtMachineryEquipment;

        internal TextBox txtMachineryEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMachineryEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMachineryEquipment != null)
                {
                }

                _txtMachineryEquipment = value;
                if (_txtMachineryEquipment != null)
                {
                }
            }
        }

        private Label _lblMachineryEquipment;

        internal Label lblMachineryEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMachineryEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMachineryEquipment != null)
                {
                }

                _lblMachineryEquipment = value;
                if (_lblMachineryEquipment != null)
                {
                }
            }
        }

        private TextBox _txtHousekeeping;

        internal TextBox txtHousekeeping
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHousekeeping;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHousekeeping != null)
                {
                }

                _txtHousekeeping = value;
                if (_txtHousekeeping != null)
                {
                }
            }
        }

        private Label _lblHousekeeping;

        internal Label lblHousekeeping
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHousekeeping;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHousekeeping != null)
                {
                }

                _lblHousekeeping = value;
                if (_lblHousekeeping != null)
                {
                }
            }
        }

        private TextBox _txtEnvironmentalConditions;

        internal TextBox txtEnvironmentalConditions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEnvironmentalConditions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEnvironmentalConditions != null)
                {
                }

                _txtEnvironmentalConditions = value;
                if (_txtEnvironmentalConditions != null)
                {
                }
            }
        }

        private Label _lblEnvironmentalConditions;

        internal Label lblEnvironmentalConditions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEnvironmentalConditions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEnvironmentalConditions != null)
                {
                }

                _lblEnvironmentalConditions = value;
                if (_lblEnvironmentalConditions != null)
                {
                }
            }
        }

        private TextBox _txtUniformPPE;

        internal TextBox txtUniformPPE
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtUniformPPE;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtUniformPPE != null)
                {
                }

                _txtUniformPPE = value;
                if (_txtUniformPPE != null)
                {
                }
            }
        }

        private Label _lblUniformPPE;

        internal Label lblUniformPPE
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblUniformPPE;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblUniformPPE != null)
                {
                }

                _lblUniformPPE = value;
                if (_lblUniformPPE != null)
                {
                }
            }
        }

        private TextBox _txtDocumentProcedures;

        internal TextBox txtDocumentProcedures
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDocumentProcedures;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDocumentProcedures != null)
                {
                }

                _txtDocumentProcedures = value;
                if (_txtDocumentProcedures != null)
                {
                }
            }
        }

        private Label _lblDocumentationProcedures;

        internal Label lblDocumentationProcedures
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDocumentationProcedures;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDocumentationProcedures != null)
                {
                }

                _lblDocumentationProcedures = value;
                if (_lblDocumentationProcedures != null)
                {
                }
            }
        }

        private Button _btnDeleteAudit;

        internal Button btnDeleteAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteAudit != null)
                {
                    _btnDeleteAudit.Click -= btnDeleteAudit_Click;
                }

                _btnDeleteAudit = value;
                if (_btnDeleteAudit != null)
                {
                    _btnDeleteAudit.Click += btnDeleteAudit_Click;
                }
            }
        }

        private Label _lblAuditor;

        internal Label lblAuditor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAuditor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAuditor != null)
                {
                }

                _lblAuditor = value;
                if (_lblAuditor != null)
                {
                }
            }
        }

        private Button _btnfindEngineer;

        internal Button btnfindEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnfindEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click -= btnfindEngineer_Click;
                }

                _btnfindEngineer = value;
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click += btnfindEngineer_Click;
                }
            }
        }

        private TextBox _txtAuditor;

        internal TextBox txtAuditor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAuditor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAuditor != null)
                {
                }

                _txtAuditor = value;
                if (_txtAuditor != null)
                {
                }
            }
        }

        private TextBox _txtVisitSpendLimit;

        internal TextBox txtVisitSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVisitSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVisitSpendLimit != null)
                {
                }

                _txtVisitSpendLimit = value;
                if (_txtVisitSpendLimit != null)
                {
                }
            }
        }

        private Label _lblVisitSpendLimit;

        internal Label lblVisitSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitSpendLimit != null)
                {
                }

                _lblVisitSpendLimit = value;
                if (_lblVisitSpendLimit != null)
                {
                }
            }
        }

        private Label _lblSiteSafetyAuditInfo;

        internal Label lblSiteSafetyAuditInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSiteSafetyAuditInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSiteSafetyAuditInfo != null)
                {
                }

                _lblSiteSafetyAuditInfo = value;
                if (_lblSiteSafetyAuditInfo != null)
                {
                }
            }
        }

        private ComboBox _cboLinkToUser;

        internal ComboBox cboLinkToUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLinkToUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLinkToUser != null)
                {
                    _cboLinkToUser.SelectionChangeCommitted -= cboLinkToUser_SelectionChangeCommitted;
                }

                _cboLinkToUser = value;
                if (_cboLinkToUser != null)
                {
                    _cboLinkToUser.SelectionChangeCommitted += cboLinkToUser_SelectionChangeCommitted;
                }
            }
        }

        private Label _lblLinkToUser;

        internal Label lblLinkToUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLinkToUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLinkToUser != null)
                {
                }

                _lblLinkToUser = value;
                if (_lblLinkToUser != null)
                {
                }
            }
        }

        private Label _lblAssignEngineerRole;

        internal Label lblAssignEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAssignEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAssignEngineerRole != null)
                {
                }

                _lblAssignEngineerRole = value;
                if (_lblAssignEngineerRole != null)
                {
                }
            }
        }

        private ComboBox _cboEngineerRoleId;

        internal ComboBox cboEngineerRoleId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineerRoleId;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineerRoleId != null)
                {
                }

                _cboEngineerRoleId = value;
                if (_cboEngineerRoleId != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _TabControl1 = new TabControl();
            _tpMain = new TabPage();
            _grpEngineer = new GroupBox();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _lblAssignEngineerRole = new Label();
            _cboEngineerRoleId = new ComboBox();
            _txtVisitSpendLimit = new TextBox();
            _lblVisitSpendLimit = new Label();
            _cboLinkToUser = new ComboBox();
            _cboLinkToUser.SelectionChangeCommitted += new EventHandler(cboLinkToUser_SelectionChangeCommitted);
            _lblLinkToUser = new Label();
            _dtpRagDate = new DateTimePicker();
            _cboRagRating = new ComboBox();
            _lblRagDate = new Label();
            _lblRagRating = new Label();
            _txtWebAppPassword = new TextBox();
            _txtWebAppPassword.TextChanged += new EventHandler(TextBox1_TextChanged);
            _lbllWebAppPassword = new Label();
            _lbllWebAppPassword.Click += new EventHandler(Label43_Click);
            _cboDepartment = new ComboBox();
            _cboUser = new ComboBox();
            _txtBreakPri = new TextBox();
            _Label40 = new Label();
            _txtServPri = new TextBox();
            _Label39 = new Label();
            _TxtOftec = new TextBox();
            _Label35 = new Label();
            _Label34 = new Label();
            _Label26 = new Label();
            _txtTechnician = new TextBox();
            _Label25 = new Label();
            _cboEngineerGroup = new ComboBox();
            _Label24 = new Label();
            _txtGasSafeNo = new TextBox();
            _Label23 = new Label();
            _dtpDrivingLicenceIssueDate = new DateTimePicker();
            _Label9 = new Label();
            _txtDrivingLicenceNo = new TextBox();
            _Label8 = new Label();
            _txtStartingDetails = new TextBox();
            _Label7 = new Label();
            _txtNextOfKinContact = new TextBox();
            _Label6 = new Label();
            _txtNextOfKinName = new TextBox();
            _Label5 = new Label();
            _btnVanHistory = new Button();
            _btnVanHistory.Click += new EventHandler(btnVanHistory_Click);
            _txtEngineerID = new TextBox();
            _cboRegionID = new ComboBox();
            _lblRegionID = new Label();
            _txtName = new TextBox();
            _lblName = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _lblEngineerID = new Label();
            _chkApprentice = new CheckBox();
            _tpMaxTimes = new TabPage();
            _GroupBox2 = new GroupBox();
            _txtDailyServiceLimit = new TextBox();
            _Label41 = new Label();
            _txtSundayValue = new TextBox();
            _txtSaturdayValue = new TextBox();
            _txtFridayValue = new TextBox();
            _txtThursdayValue = new TextBox();
            _txtWednesdayValue = new TextBox();
            _txtTuesdayValue = new TextBox();
            _txtMondayValue = new TextBox();
            _Label33 = new Label();
            _Label32 = new Label();
            _Label31 = new Label();
            _Label30 = new Label();
            _Label29 = new Label();
            _Label28 = new Label();
            _Label27 = new Label();
            _tpTrainingQualifications = new TabPage();
            _GroupBox5 = new GroupBox();
            _Panel1 = new Panel();
            _cboQualificationType = new ComboBox();
            _cboQualificationType.SelectedIndexChanged += new EventHandler(cboQualificationType_SelectedIndexChanged);
            _lblQualificationType = new Label();
            _dtpQualificationBooked = new DateTimePicker();
            _Label36 = new Label();
            _cbxShowOnJob = new CheckBox();
            _cboQualification = new ComboBox();
            _Label22 = new Label();
            _txtQualificatioNote = new TextBox();
            _Label13 = new Label();
            _btnSaveQualification = new Button();
            _btnSaveQualification.Click += new EventHandler(btnSaveQualification_Click);
            _dtpQualificationExpires = new DateTimePicker();
            _Label15 = new Label();
            _dtpQualificationPassed = new DateTimePicker();
            _Label14 = new Label();
            _btnRemoveTrainingQualifications = new Button();
            _btnRemoveTrainingQualifications.Click += new EventHandler(btnRemoveTrainingQualifications_Click);
            _dgTrainingQualifications = new DataGrid();
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_Click);
            _tpKit = new TabPage();
            _GroupBox4 = new GroupBox();
            _Panel2 = new Panel();
            _txtEquipmentTool = new TextBox();
            _Label1 = new Label();
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
            _Label16 = new Label();
            _dtpDisciplinaryIssued = new DateTimePicker();
            _Label17 = new Label();
            _txtDisciplinary = new TextBox();
            _Label18 = new Label();
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
            _Label21 = new Label();
            _txtHolidayYearEnd = new TextBox();
            _Label20 = new Label();
            _txtHolidayYearStart = new TextBox();
            _Label19 = new Label();
            _tpPostalRegions = new TabPage();
            _GroupBox8 = new GroupBox();
            _Button1 = new Button();
            _txtPostcode = new TextBox();
            _Label42 = new Label();
            _grpPostalRegions = new GroupBox();
            _Label38 = new Label();
            _txtPCSearch = new TextBox();
            _txtPCSearch.TextChanged += new EventHandler(txtFilter_TextChanged);
            _Label37 = new Label();
            _dgUnTicked = new DataGrid();
            _dgUnTicked.Click += new EventHandler(dgPostalRegionsUnticked_Clicks);
            _dgPostalRegions = new DataGrid();
            _dgPostalRegions.Click += new EventHandler(dgPostalRegions_Clicks);
            _tpSiteSafetyAudits = new TabPage();
            _grpSiteSafetyAudits = new GroupBox();
            _dgSiteSafetyAudits = new DataGrid();
            _dgSiteSafetyAudits.Click += new EventHandler(dgSiteSafetyAudits_Click);
            _grpSiteSafetyAudit = new GroupBox();
            _lblSiteSafetyAuditInfo = new Label();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtAuditor = new TextBox();
            _lblAuditor = new Label();
            _btnDeleteAudit = new Button();
            _btnDeleteAudit.Click += new EventHandler(btnDeleteAudit_Click);
            _lblLine = new Label();
            _txtTotal = new TextBox();
            _lblTotal = new Label();
            _txtAsbestos = new TextBox();
            _lblAsbestos = new Label();
            _txtCOSSH = new TextBox();
            _lblCOSSH = new Label();
            _txtFirstAidWelfare = new TextBox();
            _lblFirstAidWelfare = new Label();
            _txtWorkingAtHeight = new TextBox();
            _lblWorkingAtHeight = new Label();
            _txtManualHandling = new TextBox();
            _lblManualHandling = new Label();
            _txtMachineryEquipment = new TextBox();
            _lblMachineryEquipment = new Label();
            _txtHousekeeping = new TextBox();
            _lblHousekeeping = new Label();
            _txtEnvironmentalConditions = new TextBox();
            _lblEnvironmentalConditions = new Label();
            _txtUniformPPE = new TextBox();
            _lblUniformPPE = new Label();
            _txtDocumentProcedures = new TextBox();
            _lblDocumentationProcedures = new Label();
            _txtVehicleSafetyCondition = new TextBox();
            _lblVehicleCheck = new Label();
            _dtpAuditDate = new DateTimePicker();
            _lblAuditDate = new Label();
            _btnNewAudit = new Button();
            _btnNewAudit.Click += new EventHandler(btnNewAudit_Click);
            _btnSaveAudit = new Button();
            _btnSaveAudit.Click += new EventHandler(btnSaveAudit_Click);
            _BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            _TabControl1.SuspendLayout();
            _tpMain.SuspendLayout();
            _grpEngineer.SuspendLayout();
            _tpMaxTimes.SuspendLayout();
            _GroupBox2.SuspendLayout();
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
            _GroupBox8.SuspendLayout();
            _grpPostalRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUnTicked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgPostalRegions).BeginInit();
            _tpSiteSafetyAudits.SuspendLayout();
            _grpSiteSafetyAudits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteSafetyAudits).BeginInit();
            _grpSiteSafetyAudit.SuspendLayout();
            SuspendLayout();
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tpMain);
            _TabControl1.Controls.Add(_tpMaxTimes);
            _TabControl1.Controls.Add(_tpTrainingQualifications);
            _TabControl1.Controls.Add(_tpKit);
            _TabControl1.Controls.Add(_tpDisciplinary);
            _TabControl1.Controls.Add(_tpDocuments);
            _TabControl1.Controls.Add(_tpHolidayAbsences);
            _TabControl1.Controls.Add(_tpPostalRegions);
            _TabControl1.Controls.Add(_tpSiteSafetyAudits);
            _TabControl1.Location = new Point(0, 0);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(512, 663);
            _TabControl1.TabIndex = 1;
            //
            // tpMain
            //
            _tpMain.Controls.Add(_grpEngineer);
            _tpMain.Location = new Point(4, 22);
            _tpMain.Name = "tpMain";
            _tpMain.Size = new Size(504, 637);
            _tpMain.TabIndex = 0;
            _tpMain.Text = "Main";
            _tpMain.UseVisualStyleBackColor = true;
            //
            // grpEngineer
            //
            _grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineer.Controls.Add(_txtEmailAddress);
            _grpEngineer.Controls.Add(_lblEmailAddress);
            _grpEngineer.Controls.Add(_lblAssignEngineerRole);
            _grpEngineer.Controls.Add(_cboEngineerRoleId);
            _grpEngineer.Controls.Add(_txtVisitSpendLimit);
            _grpEngineer.Controls.Add(_lblVisitSpendLimit);
            _grpEngineer.Controls.Add(_cboLinkToUser);
            _grpEngineer.Controls.Add(_lblLinkToUser);
            _grpEngineer.Controls.Add(_dtpRagDate);
            _grpEngineer.Controls.Add(_cboRagRating);
            _grpEngineer.Controls.Add(_lblRagDate);
            _grpEngineer.Controls.Add(_lblRagRating);
            _grpEngineer.Controls.Add(_txtWebAppPassword);
            _grpEngineer.Controls.Add(_lbllWebAppPassword);
            _grpEngineer.Controls.Add(_cboDepartment);
            _grpEngineer.Controls.Add(_cboUser);
            _grpEngineer.Controls.Add(_txtBreakPri);
            _grpEngineer.Controls.Add(_Label40);
            _grpEngineer.Controls.Add(_txtServPri);
            _grpEngineer.Controls.Add(_Label39);
            _grpEngineer.Controls.Add(_TxtOftec);
            _grpEngineer.Controls.Add(_Label35);
            _grpEngineer.Controls.Add(_Label34);
            _grpEngineer.Controls.Add(_Label26);
            _grpEngineer.Controls.Add(_txtTechnician);
            _grpEngineer.Controls.Add(_Label25);
            _grpEngineer.Controls.Add(_cboEngineerGroup);
            _grpEngineer.Controls.Add(_Label24);
            _grpEngineer.Controls.Add(_txtGasSafeNo);
            _grpEngineer.Controls.Add(_Label23);
            _grpEngineer.Controls.Add(_dtpDrivingLicenceIssueDate);
            _grpEngineer.Controls.Add(_Label9);
            _grpEngineer.Controls.Add(_txtDrivingLicenceNo);
            _grpEngineer.Controls.Add(_Label8);
            _grpEngineer.Controls.Add(_txtStartingDetails);
            _grpEngineer.Controls.Add(_Label7);
            _grpEngineer.Controls.Add(_txtNextOfKinContact);
            _grpEngineer.Controls.Add(_Label6);
            _grpEngineer.Controls.Add(_txtNextOfKinName);
            _grpEngineer.Controls.Add(_Label5);
            _grpEngineer.Controls.Add(_btnVanHistory);
            _grpEngineer.Controls.Add(_txtEngineerID);
            _grpEngineer.Controls.Add(_cboRegionID);
            _grpEngineer.Controls.Add(_lblRegionID);
            _grpEngineer.Controls.Add(_txtName);
            _grpEngineer.Controls.Add(_lblName);
            _grpEngineer.Controls.Add(_txtTelephoneNum);
            _grpEngineer.Controls.Add(_lblTelephoneNum);
            _grpEngineer.Controls.Add(_lblEngineerID);
            _grpEngineer.Controls.Add(_chkApprentice);
            _grpEngineer.Location = new Point(8, 0);
            _grpEngineer.Name = "grpEngineer";
            _grpEngineer.Size = new Size(488, 631);
            _grpEngineer.TabIndex = 0;
            _grpEngineer.TabStop = false;
            _grpEngineer.Text = "Details";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(120, 277);
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(359, 21);
            _txtEmailAddress.TabIndex = 83;
            _txtEmailAddress.Tag = "";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(4, 280);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(104, 20);
            _lblEmailAddress.TabIndex = 84;
            _lblEmailAddress.Text = "Email Address";
            //
            // lblAssignEngineerRole
            //
            _lblAssignEngineerRole.AutoSize = true;
            _lblAssignEngineerRole.Location = new Point(4, 573);
            _lblAssignEngineerRole.Name = "lblAssignEngineerRole";
            _lblAssignEngineerRole.Size = new Size(73, 13);
            _lblAssignEngineerRole.TabIndex = 82;
            _lblAssignEngineerRole.Text = "Assign Role";
            //
            // cboEngineerRoleId
            //
            _cboEngineerRoleId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerRoleId.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerRoleId.FormattingEnabled = true;
            _cboEngineerRoleId.Location = new Point(117, 566);
            _cboEngineerRoleId.Name = "cboEngineerRoleId";
            _cboEngineerRoleId.Size = new Size(362, 21);
            _cboEngineerRoleId.TabIndex = 81;
            //
            // txtVisitSpendLimit
            //
            _txtVisitSpendLimit.Location = new Point(120, 539);
            _txtVisitSpendLimit.Name = "txtVisitSpendLimit";
            _txtVisitSpendLimit.Size = new Size(64, 21);
            _txtVisitSpendLimit.TabIndex = 80;
            //
            // lblVisitSpendLimit
            //
            _lblVisitSpendLimit.AutoSize = true;
            _lblVisitSpendLimit.Location = new Point(4, 542);
            _lblVisitSpendLimit.Name = "lblVisitSpendLimit";
            _lblVisitSpendLimit.Size = new Size(113, 13);
            _lblVisitSpendLimit.TabIndex = 79;
            _lblVisitSpendLimit.Text = "Visit Spend Limit £";
            //
            // cboLinkToUser
            //
            _cboLinkToUser.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLinkToUser.FormattingEnabled = true;
            _cboLinkToUser.Location = new Point(120, 512);
            _cboLinkToUser.Name = "cboLinkToUser";
            _cboLinkToUser.Size = new Size(359, 21);
            _cboLinkToUser.TabIndex = 69;
            //
            // lblLinkToUser
            //
            _lblLinkToUser.AutoSize = true;
            _lblLinkToUser.Location = new Point(4, 521);
            _lblLinkToUser.Name = "lblLinkToUser";
            _lblLinkToUser.Size = new Size(77, 13);
            _lblLinkToUser.TabIndex = 68;
            _lblLinkToUser.Text = "Link To User";
            //
            // dtpRagDate
            //
            _dtpRagDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpRagDate.Location = new Point(341, 481);
            _dtpRagDate.Name = "dtpRagDate";
            _dtpRagDate.Size = new Size(138, 21);
            _dtpRagDate.TabIndex = 67;
            _dtpRagDate.Tag = "Van.InsuranceDue";
            //
            // cboRagRating
            //
            _cboRagRating.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRagRating.Cursor = Cursors.Hand;
            _cboRagRating.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRagRating.Location = new Point(120, 481);
            _cboRagRating.Name = "cboRagRating";
            _cboRagRating.Size = new Size(112, 21);
            _cboRagRating.TabIndex = 66;
            _cboRagRating.Tag = "";
            //
            // lblRagDate
            //
            _lblRagDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblRagDate.Location = new Point(245, 484);
            _lblRagDate.Name = "lblRagDate";
            _lblRagDate.Size = new Size(68, 20);
            _lblRagDate.TabIndex = 65;
            _lblRagDate.Text = "Rag Date";
            //
            // lblRagRating
            //
            _lblRagRating.Location = new Point(4, 480);
            _lblRagRating.Name = "lblRagRating";
            _lblRagRating.Size = new Size(112, 20);
            _lblRagRating.TabIndex = 64;
            _lblRagRating.Text = "Rag Rating";
            //
            // txtWebAppPassword
            //
            _txtWebAppPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtWebAppPassword.Location = new Point(120, 449);
            _txtWebAppPassword.Name = "txtWebAppPassword";
            _txtWebAppPassword.PasswordChar = (char)42;
            _txtWebAppPassword.Size = new Size(359, 21);
            _txtWebAppPassword.TabIndex = 60;
            _txtWebAppPassword.Tag = "Engineer.TelephoneNum";
            _txtWebAppPassword.UseSystemPasswordChar = true;
            //
            // lbllWebAppPassword
            //
            _lbllWebAppPassword.Location = new Point(4, 452);
            _lbllWebAppPassword.Name = "lbllWebAppPassword";
            _lbllWebAppPassword.Size = new Size(114, 20);
            _lbllWebAppPassword.TabIndex = 61;
            _lbllWebAppPassword.Text = "WebApp Password";
            //
            // cboDepartment
            //
            _cboDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDepartment.Cursor = Cursors.Hand;
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(120, 151);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(359, 21);
            _cboDepartment.TabIndex = 59;
            _cboDepartment.Tag = "";
            //
            // cboUser
            //
            _cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUser.Cursor = Cursors.Hand;
            _cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUser.Location = new Point(120, 202);
            _cboUser.Name = "cboUser";
            _cboUser.Size = new Size(359, 21);
            _cboUser.TabIndex = 58;
            _cboUser.Tag = "";
            //
            // txtBreakPri
            //
            _txtBreakPri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtBreakPri.Location = new Point(292, 605);
            _txtBreakPri.Name = "txtBreakPri";
            _txtBreakPri.Size = new Size(41, 21);
            _txtBreakPri.TabIndex = 57;
            _txtBreakPri.Text = "1";
            //
            // Label40
            //
            _Label40.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label40.Location = new Point(186, 597);
            _Label40.Name = "Label40";
            _Label40.Size = new Size(95, 29);
            _Label40.TabIndex = 56;
            _Label40.Text = "Breakdown Priority (1-10)";
            //
            // txtServPri
            //
            _txtServPri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtServPri.Location = new Point(117, 605);
            _txtServPri.Name = "txtServPri";
            _txtServPri.Size = new Size(41, 21);
            _txtServPri.TabIndex = 55;
            _txtServPri.Text = "1";
            //
            // Label39
            //
            _Label39.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label39.Location = new Point(5, 597);
            _Label39.Name = "Label39";
            _Label39.Size = new Size(112, 29);
            _Label39.TabIndex = 54;
            _Label39.Text = "Service Priority (1-10)";
            //
            // TxtOftec
            //
            _TxtOftec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _TxtOftec.Location = new Point(120, 97);
            _TxtOftec.Name = "TxtOftec";
            _TxtOftec.Size = new Size(359, 21);
            _TxtOftec.TabIndex = 52;
            _TxtOftec.Tag = "Engineer.Name";
            //
            // Label35
            //
            _Label35.Location = new Point(4, 97);
            _Label35.Name = "Label35";
            _Label35.Size = new Size(104, 20);
            _Label35.TabIndex = 53;
            _Label35.Text = "Oftec No.";
            //
            // Label34
            //
            _Label34.Location = new Point(4, 151);
            _Label34.Name = "Label34";
            _Label34.Size = new Size(104, 20);
            _Label34.TabIndex = 51;
            _Label34.Text = "Department";
            //
            // Label26
            //
            _Label26.Location = new Point(4, 205);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(104, 20);
            _Label26.TabIndex = 49;
            _Label26.Text = "Manager";
            //
            // txtTechnician
            //
            _txtTechnician.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTechnician.Location = new Point(120, 178);
            _txtTechnician.Name = "txtTechnician";
            _txtTechnician.Size = new Size(359, 21);
            _txtTechnician.TabIndex = 5;
            _txtTechnician.Tag = "";
            //
            // Label25
            //
            _Label25.Location = new Point(4, 181);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(104, 20);
            _Label25.TabIndex = 47;
            _Label25.Text = "Technician";
            //
            // cboEngineerGroup
            //
            _cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerGroup.Cursor = Cursors.Hand;
            _cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerGroup.Location = new Point(120, 124);
            _cboEngineerGroup.Name = "cboEngineerGroup";
            _cboEngineerGroup.Size = new Size(359, 21);
            _cboEngineerGroup.TabIndex = 4;
            _cboEngineerGroup.Tag = "";
            //
            // Label24
            //
            _Label24.Location = new Point(4, 126);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(105, 20);
            _Label24.TabIndex = 45;
            _Label24.Text = "Engineer Group";
            //
            // txtGasSafeNo
            //
            _txtGasSafeNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtGasSafeNo.Location = new Point(120, 72);
            _txtGasSafeNo.Name = "txtGasSafeNo";
            _txtGasSafeNo.Size = new Size(359, 21);
            _txtGasSafeNo.TabIndex = 3;
            _txtGasSafeNo.Tag = "Engineer.Name";
            //
            // Label23
            //
            _Label23.Location = new Point(4, 72);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(104, 20);
            _Label23.TabIndex = 43;
            _Label23.Text = "Gas Safe No.";
            //
            // dtpDrivingLicenceIssueDate
            //
            _dtpDrivingLicenceIssueDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpDrivingLicenceIssueDate.Checked = false;
            _dtpDrivingLicenceIssueDate.Location = new Point(319, 347);
            _dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate";
            _dtpDrivingLicenceIssueDate.ShowCheckBox = true;
            _dtpDrivingLicenceIssueDate.Size = new Size(160, 21);
            _dtpDrivingLicenceIssueDate.TabIndex = 11;
            //
            // Label9
            //
            _Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label9.Location = new Point(240, 352);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(112, 20);
            _Label9.TabIndex = 41;
            _Label9.Text = "Issued Date";
            //
            // txtDrivingLicenceNo
            //
            _txtDrivingLicenceNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDrivingLicenceNo.Location = new Point(120, 348);
            _txtDrivingLicenceNo.Name = "txtDrivingLicenceNo";
            _txtDrivingLicenceNo.Size = new Size(112, 21);
            _txtDrivingLicenceNo.TabIndex = 10;
            //
            // Label8
            //
            _Label8.Location = new Point(4, 347);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(112, 20);
            _Label8.TabIndex = 39;
            _Label8.Text = "Driving Licence No";
            //
            // txtStartingDetails
            //
            _txtStartingDetails.AcceptsReturn = true;
            _txtStartingDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtStartingDetails.Location = new Point(120, 312);
            _txtStartingDetails.Multiline = true;
            _txtStartingDetails.Name = "txtStartingDetails";
            _txtStartingDetails.ScrollBars = ScrollBars.Vertical;
            _txtStartingDetails.Size = new Size(359, 32);
            _txtStartingDetails.TabIndex = 9;
            //
            // Label7
            //
            _Label7.Location = new Point(4, 315);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(112, 20);
            _Label7.TabIndex = 37;
            _Label7.Text = "Starting Details";
            //
            // txtNextOfKinContact
            //
            _txtNextOfKinContact.AcceptsReturn = true;
            _txtNextOfKinContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNextOfKinContact.Location = new Point(120, 412);
            _txtNextOfKinContact.Multiline = true;
            _txtNextOfKinContact.Name = "txtNextOfKinContact";
            _txtNextOfKinContact.ScrollBars = ScrollBars.Vertical;
            _txtNextOfKinContact.Size = new Size(359, 30);
            _txtNextOfKinContact.TabIndex = 14;
            //
            // Label6
            //
            _Label6.Location = new Point(4, 408);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(112, 20);
            _Label6.TabIndex = 35;
            _Label6.Text = "Next of Kin Details";
            //
            // txtNextOfKinName
            //
            _txtNextOfKinName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNextOfKinName.Location = new Point(120, 388);
            _txtNextOfKinName.Name = "txtNextOfKinName";
            _txtNextOfKinName.Size = new Size(359, 21);
            _txtNextOfKinName.TabIndex = 13;
            //
            // Label5
            //
            _Label5.Location = new Point(4, 384);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(112, 20);
            _Label5.TabIndex = 33;
            _Label5.Text = "Next of Kin Name";
            //
            // btnVanHistory
            //
            _btnVanHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnVanHistory.Location = new Point(341, 603);
            _btnVanHistory.Name = "btnVanHistory";
            _btnVanHistory.Size = new Size(139, 23);
            _btnVanHistory.TabIndex = 15;
            _btnVanHistory.Text = "Stock Profile History";
            //
            // txtEngineerID
            //
            _txtEngineerID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineerID.Location = new Point(120, 250);
            _txtEngineerID.Name = "txtEngineerID";
            _txtEngineerID.ReadOnly = true;
            _txtEngineerID.Size = new Size(359, 21);
            _txtEngineerID.TabIndex = 8;
            _txtEngineerID.TabStop = false;
            //
            // cboRegionID
            //
            _cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRegionID.Cursor = Cursors.Hand;
            _cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegionID.Location = new Point(120, 24);
            _cboRegionID.Name = "cboRegionID";
            _cboRegionID.Size = new Size(359, 21);
            _cboRegionID.TabIndex = 1;
            _cboRegionID.Tag = "Engineer.RegionID";
            //
            // lblRegionID
            //
            _lblRegionID.Location = new Point(4, 28);
            _lblRegionID.Name = "lblRegionID";
            _lblRegionID.Size = new Size(64, 20);
            _lblRegionID.TabIndex = 31;
            _lblRegionID.Text = "Region";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(120, 48);
            _txtName.Name = "txtName";
            _txtName.Size = new Size(359, 21);
            _txtName.TabIndex = 2;
            _txtName.Tag = "Engineer.Name";
            //
            // lblName
            //
            _lblName.Location = new Point(4, 48);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(48, 20);
            _lblName.TabIndex = 31;
            _lblName.Text = "Name";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(120, 226);
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(359, 21);
            _txtTelephoneNum.TabIndex = 7;
            _txtTelephoneNum.Tag = "Engineer.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(4, 229);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(104, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Telephone";
            //
            // lblEngineerID
            //
            _lblEngineerID.Location = new Point(4, 253);
            _lblEngineerID.Name = "lblEngineerID";
            _lblEngineerID.Size = new Size(94, 20);
            _lblEngineerID.TabIndex = 31;
            _lblEngineerID.Text = "Engineer ID";
            //
            // chkApprentice
            //
            _chkApprentice.Font = new Font("Verdana", 8.0F);
            _chkApprentice.Location = new Point(120, 366);
            _chkApprentice.Name = "chkApprentice";
            _chkApprentice.Size = new Size(112, 24);
            _chkApprentice.TabIndex = 12;
            _chkApprentice.Tag = "Engineer.Apprentice";
            _chkApprentice.Text = "Apprentice";
            //
            // tpMaxTimes
            //
            _tpMaxTimes.Controls.Add(_GroupBox2);
            _tpMaxTimes.Location = new Point(4, 22);
            _tpMaxTimes.Name = "tpMaxTimes";
            _tpMaxTimes.Size = new Size(504, 637);
            _tpMaxTimes.TabIndex = 8;
            _tpMaxTimes.Text = "Max SOR Times";
            _tpMaxTimes.UseVisualStyleBackColor = true;
            //
            // GroupBox2
            //
            _GroupBox2.Controls.Add(_txtDailyServiceLimit);
            _GroupBox2.Controls.Add(_Label41);
            _GroupBox2.Controls.Add(_txtSundayValue);
            _GroupBox2.Controls.Add(_txtSaturdayValue);
            _GroupBox2.Controls.Add(_txtFridayValue);
            _GroupBox2.Controls.Add(_txtThursdayValue);
            _GroupBox2.Controls.Add(_txtWednesdayValue);
            _GroupBox2.Controls.Add(_txtTuesdayValue);
            _GroupBox2.Controls.Add(_txtMondayValue);
            _GroupBox2.Controls.Add(_Label33);
            _GroupBox2.Controls.Add(_Label32);
            _GroupBox2.Controls.Add(_Label31);
            _GroupBox2.Controls.Add(_Label30);
            _GroupBox2.Controls.Add(_Label29);
            _GroupBox2.Controls.Add(_Label28);
            _GroupBox2.Controls.Add(_Label27);
            _GroupBox2.Location = new Point(3, 3);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(498, 253);
            _GroupBox2.TabIndex = 0;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Max Schedule Of Rate Times Per Day (In minutes)";
            //
            // txtDailyServiceLimit
            //
            _txtDailyServiceLimit.Location = new Point(163, 226);
            _txtDailyServiceLimit.Name = "txtDailyServiceLimit";
            _txtDailyServiceLimit.Size = new Size(131, 21);
            _txtDailyServiceLimit.TabIndex = 15;
            _txtDailyServiceLimit.Text = "0";
            //
            // Label41
            //
            _Label41.AutoSize = true;
            _Label41.Location = new Point(29, 229);
            _Label41.Name = "Label41";
            _Label41.Size = new Size(114, 13);
            _Label41.TabIndex = 14;
            _Label41.Text = "Daily Service Limit";
            //
            // txtSundayValue
            //
            _txtSundayValue.Location = new Point(163, 175);
            _txtSundayValue.Name = "txtSundayValue";
            _txtSundayValue.Size = new Size(131, 21);
            _txtSundayValue.TabIndex = 13;
            _txtSundayValue.Text = "0";
            //
            // txtSaturdayValue
            //
            _txtSaturdayValue.Location = new Point(163, 150);
            _txtSaturdayValue.Name = "txtSaturdayValue";
            _txtSaturdayValue.Size = new Size(131, 21);
            _txtSaturdayValue.TabIndex = 12;
            _txtSaturdayValue.Text = "0";
            //
            // txtFridayValue
            //
            _txtFridayValue.Location = new Point(163, 125);
            _txtFridayValue.Name = "txtFridayValue";
            _txtFridayValue.Size = new Size(131, 21);
            _txtFridayValue.TabIndex = 11;
            _txtFridayValue.Text = "0";
            //
            // txtThursdayValue
            //
            _txtThursdayValue.Location = new Point(163, 101);
            _txtThursdayValue.Name = "txtThursdayValue";
            _txtThursdayValue.Size = new Size(131, 21);
            _txtThursdayValue.TabIndex = 10;
            _txtThursdayValue.Text = "0";
            //
            // txtWednesdayValue
            //
            _txtWednesdayValue.Location = new Point(163, 77);
            _txtWednesdayValue.Name = "txtWednesdayValue";
            _txtWednesdayValue.Size = new Size(131, 21);
            _txtWednesdayValue.TabIndex = 9;
            _txtWednesdayValue.Text = "0";
            //
            // txtTuesdayValue
            //
            _txtTuesdayValue.Location = new Point(163, 54);
            _txtTuesdayValue.Name = "txtTuesdayValue";
            _txtTuesdayValue.Size = new Size(131, 21);
            _txtTuesdayValue.TabIndex = 8;
            _txtTuesdayValue.Text = "0";
            //
            // txtMondayValue
            //
            _txtMondayValue.Location = new Point(163, 30);
            _txtMondayValue.Name = "txtMondayValue";
            _txtMondayValue.Size = new Size(131, 21);
            _txtMondayValue.TabIndex = 7;
            _txtMondayValue.Text = "0";
            //
            // Label33
            //
            _Label33.AutoSize = true;
            _Label33.Location = new Point(29, 178);
            _Label33.Name = "Label33";
            _Label33.Size = new Size(50, 13);
            _Label33.TabIndex = 6;
            _Label33.Text = "Sunday";
            //
            // Label32
            //
            _Label32.AutoSize = true;
            _Label32.Location = new Point(28, 153);
            _Label32.Name = "Label32";
            _Label32.Size = new Size(59, 13);
            _Label32.TabIndex = 5;
            _Label32.Text = "Saturday";
            //
            // Label31
            //
            _Label31.AutoSize = true;
            _Label31.Location = new Point(28, 128);
            _Label31.Name = "Label31";
            _Label31.Size = new Size(42, 13);
            _Label31.TabIndex = 4;
            _Label31.Text = "Friday";
            //
            // Label30
            //
            _Label30.AutoSize = true;
            _Label30.Location = new Point(28, 104);
            _Label30.Name = "Label30";
            _Label30.Size = new Size(60, 13);
            _Label30.TabIndex = 3;
            _Label30.Text = "Thursday";
            //
            // Label29
            //
            _Label29.AutoSize = true;
            _Label29.Location = new Point(28, 80);
            _Label29.Name = "Label29";
            _Label29.Size = new Size(72, 13);
            _Label29.TabIndex = 2;
            _Label29.Text = "Wednesday";
            //
            // Label28
            //
            _Label28.AutoSize = true;
            _Label28.Location = new Point(28, 57);
            _Label28.Name = "Label28";
            _Label28.Size = new Size(54, 13);
            _Label28.TabIndex = 1;
            _Label28.Text = "Tuesday";
            //
            // Label27
            //
            _Label27.AutoSize = true;
            _Label27.Location = new Point(28, 33);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(51, 13);
            _Label27.TabIndex = 0;
            _Label27.Text = "Monday";
            //
            // tpTrainingQualifications
            //
            _tpTrainingQualifications.Controls.Add(_GroupBox5);
            _tpTrainingQualifications.Location = new Point(4, 22);
            _tpTrainingQualifications.Name = "tpTrainingQualifications";
            _tpTrainingQualifications.Size = new Size(504, 637);
            _tpTrainingQualifications.TabIndex = 3;
            _tpTrainingQualifications.Text = "Training & Qualifications";
            _tpTrainingQualifications.UseVisualStyleBackColor = true;
            //
            // GroupBox5
            //
            _GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox5.Controls.Add(_Panel1);
            _GroupBox5.Controls.Add(_btnRemoveTrainingQualifications);
            _GroupBox5.Controls.Add(_dgTrainingQualifications);
            _GroupBox5.Location = new Point(8, 8);
            _GroupBox5.Name = "GroupBox5";
            _GroupBox5.Size = new Size(488, 623);
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
            _Panel1.Controls.Add(_cbxShowOnJob);
            _Panel1.Controls.Add(_cboQualification);
            _Panel1.Controls.Add(_Label22);
            _Panel1.Controls.Add(_txtQualificatioNote);
            _Panel1.Controls.Add(_Label13);
            _Panel1.Controls.Add(_btnSaveQualification);
            _Panel1.Controls.Add(_dtpQualificationExpires);
            _Panel1.Controls.Add(_Label15);
            _Panel1.Controls.Add(_dtpQualificationPassed);
            _Panel1.Controls.Add(_Label14);
            _Panel1.Location = new Point(5, 17);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(475, 212);
            _Panel1.TabIndex = 42;
            //
            // cboQualificationType
            //
            _cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualificationType.Location = new Point(140, 4);
            _cboQualificationType.Name = "cboQualificationType";
            _cboQualificationType.Size = new Size(324, 21);
            _cboQualificationType.TabIndex = 52;
            _cboQualificationType.Text = "ComboBox1";
            //
            // lblQualificationType
            //
            _lblQualificationType.Location = new Point(8, 4);
            _lblQualificationType.Name = "lblQualificationType";
            _lblQualificationType.Size = new Size(126, 23);
            _lblQualificationType.TabIndex = 53;
            _lblQualificationType.Text = "Qualification Type";
            //
            // dtpQualificationBooked
            //
            _dtpQualificationBooked.Checked = false;
            _dtpQualificationBooked.Location = new Point(96, 107);
            _dtpQualificationBooked.Name = "dtpQualificationBooked";
            _dtpQualificationBooked.ShowCheckBox = true;
            _dtpQualificationBooked.Size = new Size(152, 21);
            _dtpQualificationBooked.TabIndex = 50;
            //
            // Label36
            //
            _Label36.Location = new Point(8, 107);
            _Label36.Name = "Label36";
            _Label36.Size = new Size(80, 23);
            _Label36.TabIndex = 51;
            _Label36.Text = "Booked";
            //
            // cbxShowOnJob
            //
            _cbxShowOnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cbxShowOnJob.AutoSize = true;
            _cbxShowOnJob.Enabled = false;
            _cbxShowOnJob.Location = new Point(96, 181);
            _cbxShowOnJob.Name = "cbxShowOnJob";
            _cbxShowOnJob.Size = new Size(98, 17);
            _cbxShowOnJob.TabIndex = 49;
            _cbxShowOnJob.Text = "Show on Job";
            _cbxShowOnJob.TextAlign = ContentAlignment.MiddleRight;
            _cbxShowOnJob.UseVisualStyleBackColor = true;
            _cbxShowOnJob.Visible = false;
            //
            // cboQualification
            //
            _cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualification.Location = new Point(96, 30);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(368, 21);
            _cboQualification.TabIndex = 1;
            _cboQualification.Text = "ComboBox1";
            //
            // Label22
            //
            _Label22.Location = new Point(8, 30);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(100, 23);
            _Label22.TabIndex = 48;
            _Label22.Text = "Qualification";
            //
            // txtQualificatioNote
            //
            _txtQualificatioNote.AcceptsReturn = true;
            _txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQualificatioNote.Location = new Point(96, 133);
            _txtQualificatioNote.Multiline = true;
            _txtQualificatioNote.Name = "txtQualificatioNote";
            _txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
            _txtQualificatioNote.Size = new Size(368, 42);
            _txtQualificatioNote.TabIndex = 4;
            //
            // Label13
            //
            _Label13.Location = new Point(8, 136);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(67, 20);
            _Label13.TabIndex = 47;
            _Label13.Text = "Note";
            //
            // btnSaveQualification
            //
            _btnSaveQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveQualification.Location = new Point(327, 181);
            _btnSaveQualification.Name = "btnSaveQualification";
            _btnSaveQualification.Size = new Size(137, 23);
            _btnSaveQualification.TabIndex = 5;
            _btnSaveQualification.Text = "Add / Update";
            //
            // dtpQualificationExpires
            //
            _dtpQualificationExpires.Checked = false;
            _dtpQualificationExpires.Location = new Point(96, 80);
            _dtpQualificationExpires.Name = "dtpQualificationExpires";
            _dtpQualificationExpires.ShowCheckBox = true;
            _dtpQualificationExpires.Size = new Size(152, 21);
            _dtpQualificationExpires.TabIndex = 3;
            //
            // Label15
            //
            _Label15.Location = new Point(8, 80);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(80, 23);
            _Label15.TabIndex = 43;
            _Label15.Text = "Expires";
            //
            // dtpQualificationPassed
            //
            _dtpQualificationPassed.Checked = false;
            _dtpQualificationPassed.Location = new Point(96, 56);
            _dtpQualificationPassed.Name = "dtpQualificationPassed";
            _dtpQualificationPassed.ShowCheckBox = true;
            _dtpQualificationPassed.Size = new Size(152, 21);
            _dtpQualificationPassed.TabIndex = 2;
            //
            // Label14
            //
            _Label14.Location = new Point(8, 56);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(80, 23);
            _Label14.TabIndex = 41;
            _Label14.Text = "Date Passed";
            //
            // btnRemoveTrainingQualifications
            //
            _btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveTrainingQualifications.Location = new Point(10, 591);
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
            _dgTrainingQualifications.Location = new Point(8, 235);
            _dgTrainingQualifications.Name = "dgTrainingQualifications";
            _dgTrainingQualifications.Size = new Size(472, 348);
            _dgTrainingQualifications.TabIndex = 6;
            //
            // tpKit
            //
            _tpKit.Controls.Add(_GroupBox4);
            _tpKit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _tpKit.Location = new Point(4, 22);
            _tpKit.Name = "tpKit";
            _tpKit.Size = new Size(504, 637);
            _tpKit.TabIndex = 4;
            _tpKit.Text = "Equipment";
            _tpKit.UseVisualStyleBackColor = true;
            //
            // GroupBox4
            //
            _GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox4.Controls.Add(_Panel2);
            _GroupBox4.Controls.Add(_btnRemoveEngineerEquipment);
            _GroupBox4.Controls.Add(_dgEquipment);
            _GroupBox4.Location = new Point(8, 8);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(488, 623);
            _GroupBox4.TabIndex = 13;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Specialised Equipment and Tools Issued";
            //
            // Panel2
            //
            _Panel2.Controls.Add(_txtEquipmentTool);
            _Panel2.Controls.Add(_Label1);
            _Panel2.Controls.Add(_btnSaveEquipment);
            _Panel2.Location = new Point(8, 16);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(472, 64);
            _Panel2.TabIndex = 2;
            //
            // txtEquipmentTool
            //
            _txtEquipmentTool.AcceptsReturn = true;
            _txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEquipmentTool.Location = new Point(115, 4);
            _txtEquipmentTool.MaxLength = 255;
            _txtEquipmentTool.Multiline = true;
            _txtEquipmentTool.Name = "txtEquipmentTool";
            _txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
            _txtEquipmentTool.Size = new Size(256, 56);
            _txtEquipmentTool.TabIndex = 1;
            _txtEquipmentTool.Tag = "Engineer.Name";
            //
            // Label1
            //
            _Label1.Location = new Point(3, 4);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(112, 20);
            _Label1.TabIndex = 55;
            _Label1.Text = @"Equipment\Tool";
            //
            // btnSaveEquipment
            //
            _btnSaveEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveEquipment.Location = new Point(384, 36);
            _btnSaveEquipment.Name = "btnSaveEquipment";
            _btnSaveEquipment.Size = new Size(75, 23);
            _btnSaveEquipment.TabIndex = 2;
            _btnSaveEquipment.Text = "Save";
            //
            // btnRemoveEngineerEquipment
            //
            _btnRemoveEngineerEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveEngineerEquipment.Location = new Point(8, 591);
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
            _dgEquipment.Location = new Point(8, 103);
            _dgEquipment.Name = "dgEquipment";
            _dgEquipment.Size = new Size(472, 480);
            _dgEquipment.TabIndex = 3;
            //
            // tpDisciplinary
            //
            _tpDisciplinary.Controls.Add(_GroupBox6);
            _tpDisciplinary.Location = new Point(4, 22);
            _tpDisciplinary.Name = "tpDisciplinary";
            _tpDisciplinary.Size = new Size(504, 637);
            _tpDisciplinary.TabIndex = 2;
            _tpDisciplinary.Text = "Disciplinary";
            _tpDisciplinary.UseVisualStyleBackColor = true;
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
            _GroupBox6.Size = new Size(488, 519);
            _GroupBox6.TabIndex = 14;
            _GroupBox6.TabStop = false;
            _GroupBox6.Text = "Disciplinary Records";
            //
            // btnAddDisciplinaries
            //
            _btnAddDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddDisciplinaries.Location = new Point(8, 487);
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
            _Panel3.Controls.Add(_Label16);
            _Panel3.Controls.Add(_dtpDisciplinaryIssued);
            _Panel3.Controls.Add(_Label17);
            _Panel3.Controls.Add(_txtDisciplinary);
            _Panel3.Controls.Add(_Label18);
            _Panel3.Location = new Point(5, 25);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(475, 80);
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
            _cboDisciplinary.Size = new Size(272, 21);
            _cboDisciplinary.TabIndex = 3;
            _cboDisciplinary.Text = "ComboBox2";
            //
            // btnSaveDisciplinaries
            //
            _btnSaveDisciplinaries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveDisciplinaries.Location = new Point(376, 53);
            _btnSaveDisciplinaries.Name = "btnSaveDisciplinaries";
            _btnSaveDisciplinaries.Size = new Size(88, 21);
            _btnSaveDisciplinaries.TabIndex = 4;
            _btnSaveDisciplinaries.Text = "Save";
            //
            // Label16
            //
            _Label16.Location = new Point(8, 53);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(80, 23);
            _Label16.TabIndex = 43;
            _Label16.Text = "Status";
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
            // Label17
            //
            _Label17.Location = new Point(8, 29);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(80, 23);
            _Label17.TabIndex = 41;
            _Label17.Text = "Issued";
            //
            // txtDisciplinary
            //
            _txtDisciplinary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDisciplinary.Location = new Point(96, 5);
            _txtDisciplinary.Name = "txtDisciplinary";
            _txtDisciplinary.Size = new Size(376, 21);
            _txtDisciplinary.TabIndex = 1;
            //
            // Label18
            //
            _Label18.Location = new Point(8, 5);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(80, 20);
            _Label18.TabIndex = 40;
            _Label18.Text = "Disciplinary";
            //
            // btnRemoveDisciplinaries
            //
            _btnRemoveDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveDisciplinaries.Location = new Point(168, 487);
            _btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries";
            _btnRemoveDisciplinaries.Size = new Size(75, 21);
            _btnRemoveDisciplinaries.TabIndex = 7;
            _btnRemoveDisciplinaries.Text = "Delete";
            //
            // btnEditDisciplinaries
            //
            _btnEditDisciplinaries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnEditDisciplinaries.Location = new Point(88, 487);
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
            _dgDisciplinaries.Location = new Point(8, 113);
            _dgDisciplinaries.Name = "dgDisciplinaries";
            _dgDisciplinaries.Size = new Size(472, 366);
            _dgDisciplinaries.TabIndex = 5;
            //
            // tpDocuments
            //
            _tpDocuments.Controls.Add(_pnlDocuments);
            _tpDocuments.Location = new Point(4, 22);
            _tpDocuments.Name = "tpDocuments";
            _tpDocuments.Size = new Size(504, 637);
            _tpDocuments.TabIndex = 6;
            _tpDocuments.Text = "Documents";
            _tpDocuments.UseVisualStyleBackColor = true;
            //
            // pnlDocuments
            //
            _pnlDocuments.Dock = DockStyle.Fill;
            _pnlDocuments.Location = new Point(0, 0);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(504, 637);
            _pnlDocuments.TabIndex = 0;
            //
            // tpHolidayAbsences
            //
            _tpHolidayAbsences.Controls.Add(_grpAbsences);
            _tpHolidayAbsences.Controls.Add(_GroupBox7);
            _tpHolidayAbsences.Location = new Point(4, 22);
            _tpHolidayAbsences.Name = "tpHolidayAbsences";
            _tpHolidayAbsences.Size = new Size(504, 637);
            _tpHolidayAbsences.TabIndex = 5;
            _tpHolidayAbsences.Text = "Holidays & Absences";
            _tpHolidayAbsences.UseVisualStyleBackColor = true;
            //
            // grpAbsences
            //
            _grpAbsences.Controls.Add(_dgAbsences);
            _grpAbsences.Location = new Point(8, 112);
            _grpAbsences.Name = "grpAbsences";
            _grpAbsences.Size = new Size(488, 328);
            _grpAbsences.TabIndex = 4;
            _grpAbsences.TabStop = false;
            _grpAbsences.Text = "Absences";
            //
            // dgAbsences
            //
            _dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAbsences.DataMember = "";
            _dgAbsences.HeaderForeColor = SystemColors.ControlText;
            _dgAbsences.Location = new Point(8, 21);
            _dgAbsences.Name = "dgAbsences";
            _dgAbsences.Size = new Size(472, 299);
            _dgAbsences.TabIndex = 4;
            //
            // GroupBox7
            //
            _GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox7.Controls.Add(_txtDaysHolidayAllowed);
            _GroupBox7.Controls.Add(_Label21);
            _GroupBox7.Controls.Add(_txtHolidayYearEnd);
            _GroupBox7.Controls.Add(_Label20);
            _GroupBox7.Controls.Add(_txtHolidayYearStart);
            _GroupBox7.Controls.Add(_Label19);
            _GroupBox7.Location = new Point(8, 8);
            _GroupBox7.Name = "GroupBox7";
            _GroupBox7.Size = new Size(488, 104);
            _GroupBox7.TabIndex = 0;
            _GroupBox7.TabStop = false;
            _GroupBox7.Text = "Holiday Entitlement";
            //
            // txtDaysHolidayAllowed
            //
            _txtDaysHolidayAllowed.Location = new Point(144, 72);
            _txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed";
            _txtDaysHolidayAllowed.Size = new Size(100, 21);
            _txtDaysHolidayAllowed.TabIndex = 3;
            //
            // Label21
            //
            _Label21.Location = new Point(16, 72);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(128, 23);
            _Label21.TabIndex = 4;
            _Label21.Text = "Holiday Entitlement";
            //
            // txtHolidayYearEnd
            //
            _txtHolidayYearEnd.Location = new Point(144, 48);
            _txtHolidayYearEnd.Name = "txtHolidayYearEnd";
            _txtHolidayYearEnd.Size = new Size(100, 21);
            _txtHolidayYearEnd.TabIndex = 2;
            //
            // Label20
            //
            _Label20.Location = new Point(16, 48);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(128, 23);
            _Label20.TabIndex = 2;
            _Label20.Text = "End Period (dd/mm)";
            //
            // txtHolidayYearStart
            //
            _txtHolidayYearStart.Location = new Point(144, 24);
            _txtHolidayYearStart.Name = "txtHolidayYearStart";
            _txtHolidayYearStart.Size = new Size(100, 21);
            _txtHolidayYearStart.TabIndex = 1;
            //
            // Label19
            //
            _Label19.Location = new Point(16, 24);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(128, 23);
            _Label19.TabIndex = 0;
            _Label19.Text = "Start Period (dd/mm)";
            //
            // tpPostalRegions
            //
            _tpPostalRegions.Controls.Add(_GroupBox8);
            _tpPostalRegions.Controls.Add(_grpPostalRegions);
            _tpPostalRegions.Location = new Point(4, 22);
            _tpPostalRegions.Name = "tpPostalRegions";
            _tpPostalRegions.Size = new Size(504, 637);
            _tpPostalRegions.TabIndex = 7;
            _tpPostalRegions.Text = "Postal Regions";
            _tpPostalRegions.UseVisualStyleBackColor = true;
            //
            // GroupBox8
            //
            _GroupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox8.Controls.Add(_Button1);
            _GroupBox8.Controls.Add(_txtPostcode);
            _GroupBox8.Controls.Add(_Label42);
            _GroupBox8.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _GroupBox8.Location = new Point(8, 34);
            _GroupBox8.Name = "GroupBox8";
            _GroupBox8.Size = new Size(488, 70);
            _GroupBox8.TabIndex = 13;
            _GroupBox8.TabStop = false;
            _GroupBox8.Text = "Home ";
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
            // txtPostcode
            //
            _txtPostcode.Location = new Point(132, 25);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(123, 21);
            _txtPostcode.TabIndex = 41;
            //
            // Label42
            //
            _Label42.Location = new Point(29, 28);
            _Label42.Name = "Label42";
            _Label42.Size = new Size(97, 20);
            _Label42.TabIndex = 42;
            _Label42.Text = "Home Postcode";
            //
            // grpPostalRegions
            //
            _grpPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpPostalRegions.Controls.Add(_Label38);
            _grpPostalRegions.Controls.Add(_txtPCSearch);
            _grpPostalRegions.Controls.Add(_Label37);
            _grpPostalRegions.Controls.Add(_dgUnTicked);
            _grpPostalRegions.Controls.Add(_dgPostalRegions);
            _grpPostalRegions.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpPostalRegions.Location = new Point(8, 110);
            _grpPostalRegions.Name = "grpPostalRegions";
            _grpPostalRegions.Size = new Size(488, 524);
            _grpPostalRegions.TabIndex = 12;
            _grpPostalRegions.TabStop = false;
            _grpPostalRegions.Text = "Postal Regions";
            //
            // Label38
            //
            _Label38.Font = new Font("Verdana", 10.25F);
            _Label38.Location = new Point(8, 56);
            _Label38.Name = "Label38";
            _Label38.Size = new Size(235, 20);
            _Label38.TabIndex = 43;
            _Label38.Text = "Assigned Areas";
            _Label38.TextAlign = ContentAlignment.MiddleCenter;
            //
            // txtPCSearch
            //
            _txtPCSearch.Location = new Point(341, 55);
            _txtPCSearch.Name = "txtPCSearch";
            _txtPCSearch.Size = new Size(123, 21);
            _txtPCSearch.TabIndex = 41;
            //
            // Label37
            //
            _Label37.Location = new Point(258, 58);
            _Label37.Name = "Label37";
            _Label37.Size = new Size(59, 20);
            _Label37.TabIndex = 42;
            _Label37.Text = "Search";
            //
            // dgUnTicked
            //
            _dgUnTicked.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgUnTicked.CaptionFont = new Font("Verdana", 8.25F, FontStyle.Bold);
            _dgUnTicked.DataMember = "";
            _dgUnTicked.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgUnTicked.HeaderForeColor = SystemColors.ControlText;
            _dgUnTicked.Location = new Point(249, 85);
            _dgUnTicked.Name = "dgUnTicked";
            _dgUnTicked.Size = new Size(233, 433);
            _dgUnTicked.TabIndex = 1;
            //
            // dgPostalRegions
            //
            _dgPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgPostalRegions.CaptionFont = new Font("Verdana", 8.25F, FontStyle.Bold);
            _dgPostalRegions.DataMember = "";
            _dgPostalRegions.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgPostalRegions.HeaderForeColor = SystemColors.ControlText;
            _dgPostalRegions.Location = new Point(8, 85);
            _dgPostalRegions.Name = "dgPostalRegions";
            _dgPostalRegions.Size = new Size(235, 433);
            _dgPostalRegions.TabIndex = 0;
            //
            // tpSiteSafetyAudits
            //
            _tpSiteSafetyAudits.AccessibleRole = AccessibleRole.None;
            _tpSiteSafetyAudits.Controls.Add(_grpSiteSafetyAudits);
            _tpSiteSafetyAudits.Controls.Add(_grpSiteSafetyAudit);
            _tpSiteSafetyAudits.Location = new Point(4, 22);
            _tpSiteSafetyAudits.Name = "tpSiteSafetyAudits";
            _tpSiteSafetyAudits.Size = new Size(504, 637);
            _tpSiteSafetyAudits.TabIndex = 9;
            _tpSiteSafetyAudits.Text = "Site Safety Audits";
            _tpSiteSafetyAudits.UseVisualStyleBackColor = true;
            //
            // grpSiteSafetyAudits
            //
            _grpSiteSafetyAudits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSiteSafetyAudits.Controls.Add(_dgSiteSafetyAudits);
            _grpSiteSafetyAudits.Location = new Point(3, 442);
            _grpSiteSafetyAudits.Name = "grpSiteSafetyAudits";
            _grpSiteSafetyAudits.Size = new Size(498, 192);
            _grpSiteSafetyAudits.TabIndex = 1;
            _grpSiteSafetyAudits.TabStop = false;
            _grpSiteSafetyAudits.Text = "Site Safety Audits";
            //
            // dgSiteSafetyAudits
            //
            _dgSiteSafetyAudits.DataMember = "";
            _dgSiteSafetyAudits.Dock = DockStyle.Fill;
            _dgSiteSafetyAudits.HeaderForeColor = SystemColors.ControlText;
            _dgSiteSafetyAudits.Location = new Point(3, 17);
            _dgSiteSafetyAudits.Name = "dgSiteSafetyAudits";
            _dgSiteSafetyAudits.Size = new Size(492, 172);
            _dgSiteSafetyAudits.TabIndex = 16;
            //
            // grpSiteSafetyAudit
            //
            _grpSiteSafetyAudit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpSiteSafetyAudit.Controls.Add(_lblSiteSafetyAuditInfo);
            _grpSiteSafetyAudit.Controls.Add(_btnfindEngineer);
            _grpSiteSafetyAudit.Controls.Add(_txtAuditor);
            _grpSiteSafetyAudit.Controls.Add(_lblAuditor);
            _grpSiteSafetyAudit.Controls.Add(_btnDeleteAudit);
            _grpSiteSafetyAudit.Controls.Add(_lblLine);
            _grpSiteSafetyAudit.Controls.Add(_txtTotal);
            _grpSiteSafetyAudit.Controls.Add(_lblTotal);
            _grpSiteSafetyAudit.Controls.Add(_txtAsbestos);
            _grpSiteSafetyAudit.Controls.Add(_lblAsbestos);
            _grpSiteSafetyAudit.Controls.Add(_txtCOSSH);
            _grpSiteSafetyAudit.Controls.Add(_lblCOSSH);
            _grpSiteSafetyAudit.Controls.Add(_txtFirstAidWelfare);
            _grpSiteSafetyAudit.Controls.Add(_lblFirstAidWelfare);
            _grpSiteSafetyAudit.Controls.Add(_txtWorkingAtHeight);
            _grpSiteSafetyAudit.Controls.Add(_lblWorkingAtHeight);
            _grpSiteSafetyAudit.Controls.Add(_txtManualHandling);
            _grpSiteSafetyAudit.Controls.Add(_lblManualHandling);
            _grpSiteSafetyAudit.Controls.Add(_txtMachineryEquipment);
            _grpSiteSafetyAudit.Controls.Add(_lblMachineryEquipment);
            _grpSiteSafetyAudit.Controls.Add(_txtHousekeeping);
            _grpSiteSafetyAudit.Controls.Add(_lblHousekeeping);
            _grpSiteSafetyAudit.Controls.Add(_txtEnvironmentalConditions);
            _grpSiteSafetyAudit.Controls.Add(_lblEnvironmentalConditions);
            _grpSiteSafetyAudit.Controls.Add(_txtUniformPPE);
            _grpSiteSafetyAudit.Controls.Add(_lblUniformPPE);
            _grpSiteSafetyAudit.Controls.Add(_txtDocumentProcedures);
            _grpSiteSafetyAudit.Controls.Add(_lblDocumentationProcedures);
            _grpSiteSafetyAudit.Controls.Add(_txtVehicleSafetyCondition);
            _grpSiteSafetyAudit.Controls.Add(_lblVehicleCheck);
            _grpSiteSafetyAudit.Controls.Add(_dtpAuditDate);
            _grpSiteSafetyAudit.Controls.Add(_lblAuditDate);
            _grpSiteSafetyAudit.Controls.Add(_btnNewAudit);
            _grpSiteSafetyAudit.Controls.Add(_btnSaveAudit);
            _grpSiteSafetyAudit.Location = new Point(3, 3);
            _grpSiteSafetyAudit.Name = "grpSiteSafetyAudit";
            _grpSiteSafetyAudit.Size = new Size(498, 433);
            _grpSiteSafetyAudit.TabIndex = 0;
            _grpSiteSafetyAudit.TabStop = false;
            _grpSiteSafetyAudit.Text = "Site Safety Audit";
            //
            // lblSiteSafetyAuditInfo
            //
            _lblSiteSafetyAuditInfo.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblSiteSafetyAuditInfo.Location = new Point(6, 18);
            _lblSiteSafetyAuditInfo.Name = "lblSiteSafetyAuditInfo";
            _lblSiteSafetyAuditInfo.Size = new Size(486, 20);
            _lblSiteSafetyAuditInfo.TabIndex = 98;
            _lblSiteSafetyAuditInfo.Text = "Please Key In -1 For N/A sections";
            //
            // btnfindEngineer
            //
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(460, 362);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 97;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtAuditor
            //
            _txtAuditor.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtAuditor.Location = new Point(66, 362);
            _txtAuditor.Name = "txtAuditor";
            _txtAuditor.ReadOnly = true;
            _txtAuditor.Size = new Size(388, 21);
            _txtAuditor.TabIndex = 96;
            //
            // lblAuditor
            //
            _lblAuditor.Location = new Point(6, 366);
            _lblAuditor.Name = "lblAuditor";
            _lblAuditor.Size = new Size(64, 21);
            _lblAuditor.TabIndex = 95;
            _lblAuditor.Text = "Auditor";
            //
            // btnDeleteAudit
            //
            _btnDeleteAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeleteAudit.Location = new Point(93, 404);
            _btnDeleteAudit.Name = "btnDeleteAudit";
            _btnDeleteAudit.Size = new Size(75, 23);
            _btnDeleteAudit.TabIndex = 94;
            _btnDeleteAudit.Text = "Delete";
            _btnDeleteAudit.UseVisualStyleBackColor = true;
            //
            // lblLine
            //
            _lblLine.Location = new Point(9, 299);
            _lblLine.Name = "lblLine";
            _lblLine.Size = new Size(496, 15);
            _lblLine.TabIndex = 93;
            _lblLine.Text = "---------------------------------------------------------------------------------" + "--------------------------------------";
            //
            // txtTotal
            //
            _txtTotal.Location = new Point(185, 326);
            _txtTotal.Name = "txtTotal";
            _txtTotal.Size = new Size(51, 21);
            _txtTotal.TabIndex = 92;
            //
            // lblTotal
            //
            _lblTotal.Location = new Point(6, 329);
            _lblTotal.Name = "lblTotal";
            _lblTotal.Size = new Size(162, 20);
            _lblTotal.TabIndex = 91;
            _lblTotal.Text = "Total";
            //
            // txtAsbestos
            //
            _txtAsbestos.Location = new Point(185, 263);
            _txtAsbestos.Name = "txtAsbestos";
            _txtAsbestos.Size = new Size(51, 21);
            _txtAsbestos.TabIndex = 90;
            //
            // lblAsbestos
            //
            _lblAsbestos.Location = new Point(6, 266);
            _lblAsbestos.Name = "lblAsbestos";
            _lblAsbestos.Size = new Size(162, 20);
            _lblAsbestos.TabIndex = 89;
            _lblAsbestos.Text = "Asbestos";
            //
            // txtCOSSH
            //
            _txtCOSSH.Location = new Point(185, 220);
            _txtCOSSH.Name = "txtCOSSH";
            _txtCOSSH.Size = new Size(51, 21);
            _txtCOSSH.TabIndex = 88;
            //
            // lblCOSSH
            //
            _lblCOSSH.Location = new Point(6, 223);
            _lblCOSSH.Name = "lblCOSSH";
            _lblCOSSH.Size = new Size(162, 20);
            _lblCOSSH.TabIndex = 87;
            _lblCOSSH.Text = "COSSH";
            //
            // txtFirstAidWelfare
            //
            _txtFirstAidWelfare.Location = new Point(185, 177);
            _txtFirstAidWelfare.Name = "txtFirstAidWelfare";
            _txtFirstAidWelfare.Size = new Size(51, 21);
            _txtFirstAidWelfare.TabIndex = 86;
            //
            // lblFirstAidWelfare
            //
            _lblFirstAidWelfare.Location = new Point(6, 180);
            _lblFirstAidWelfare.Name = "lblFirstAidWelfare";
            _lblFirstAidWelfare.Size = new Size(162, 20);
            _lblFirstAidWelfare.TabIndex = 85;
            _lblFirstAidWelfare.Text = "First Aid && Welfare";
            //
            // txtWorkingAtHeight
            //
            _txtWorkingAtHeight.Location = new Point(441, 220);
            _txtWorkingAtHeight.Name = "txtWorkingAtHeight";
            _txtWorkingAtHeight.Size = new Size(51, 21);
            _txtWorkingAtHeight.TabIndex = 84;
            //
            // lblWorkingAtHeight
            //
            _lblWorkingAtHeight.Location = new Point(255, 223);
            _lblWorkingAtHeight.Name = "lblWorkingAtHeight";
            _lblWorkingAtHeight.Size = new Size(162, 20);
            _lblWorkingAtHeight.TabIndex = 83;
            _lblWorkingAtHeight.Text = "Working At Height";
            //
            // txtManualHandling
            //
            _txtManualHandling.Location = new Point(441, 177);
            _txtManualHandling.Name = "txtManualHandling";
            _txtManualHandling.Size = new Size(51, 21);
            _txtManualHandling.TabIndex = 82;
            //
            // lblManualHandling
            //
            _lblManualHandling.Location = new Point(255, 180);
            _lblManualHandling.Name = "lblManualHandling";
            _lblManualHandling.Size = new Size(162, 20);
            _lblManualHandling.TabIndex = 81;
            _lblManualHandling.Text = "Manual Handling";
            //
            // txtMachineryEquipment
            //
            _txtMachineryEquipment.Location = new Point(441, 134);
            _txtMachineryEquipment.Name = "txtMachineryEquipment";
            _txtMachineryEquipment.Size = new Size(51, 21);
            _txtMachineryEquipment.TabIndex = 80;
            //
            // lblMachineryEquipment
            //
            _lblMachineryEquipment.Location = new Point(255, 137);
            _lblMachineryEquipment.Name = "lblMachineryEquipment";
            _lblMachineryEquipment.Size = new Size(162, 20);
            _lblMachineryEquipment.TabIndex = 79;
            _lblMachineryEquipment.Text = "Machinery && Equipment";
            //
            // txtHousekeeping
            //
            _txtHousekeeping.Location = new Point(185, 134);
            _txtHousekeeping.Name = "txtHousekeeping";
            _txtHousekeeping.Size = new Size(51, 21);
            _txtHousekeeping.TabIndex = 78;
            //
            // lblHousekeeping
            //
            _lblHousekeeping.Location = new Point(6, 137);
            _lblHousekeeping.Name = "lblHousekeeping";
            _lblHousekeeping.Size = new Size(162, 20);
            _lblHousekeeping.TabIndex = 77;
            _lblHousekeeping.Text = "Housekeeping";
            //
            // txtEnvironmentalConditions
            //
            _txtEnvironmentalConditions.Location = new Point(441, 91);
            _txtEnvironmentalConditions.Name = "txtEnvironmentalConditions";
            _txtEnvironmentalConditions.Size = new Size(51, 21);
            _txtEnvironmentalConditions.TabIndex = 76;
            //
            // lblEnvironmentalConditions
            //
            _lblEnvironmentalConditions.Location = new Point(255, 94);
            _lblEnvironmentalConditions.Name = "lblEnvironmentalConditions";
            _lblEnvironmentalConditions.Size = new Size(162, 20);
            _lblEnvironmentalConditions.TabIndex = 75;
            _lblEnvironmentalConditions.Text = "Environmental Conditions";
            //
            // txtUniformPPE
            //
            _txtUniformPPE.Location = new Point(185, 91);
            _txtUniformPPE.Name = "txtUniformPPE";
            _txtUniformPPE.Size = new Size(51, 21);
            _txtUniformPPE.TabIndex = 74;
            //
            // lblUniformPPE
            //
            _lblUniformPPE.Location = new Point(6, 94);
            _lblUniformPPE.Name = "lblUniformPPE";
            _lblUniformPPE.Size = new Size(162, 20);
            _lblUniformPPE.TabIndex = 73;
            _lblUniformPPE.Text = "Uniform && PPE";
            //
            // txtDocumentProcedures
            //
            _txtDocumentProcedures.Location = new Point(441, 48);
            _txtDocumentProcedures.Name = "txtDocumentProcedures";
            _txtDocumentProcedures.Size = new Size(51, 21);
            _txtDocumentProcedures.TabIndex = 72;
            //
            // lblDocumentationProcedures
            //
            _lblDocumentationProcedures.Location = new Point(255, 51);
            _lblDocumentationProcedures.Name = "lblDocumentationProcedures";
            _lblDocumentationProcedures.Size = new Size(162, 20);
            _lblDocumentationProcedures.TabIndex = 71;
            _lblDocumentationProcedures.Text = "Document && Procedures";
            //
            // txtVehicleSafetyCondition
            //
            _txtVehicleSafetyCondition.Location = new Point(185, 46);
            _txtVehicleSafetyCondition.Name = "txtVehicleSafetyCondition";
            _txtVehicleSafetyCondition.Size = new Size(51, 21);
            _txtVehicleSafetyCondition.TabIndex = 70;
            //
            // lblVehicleCheck
            //
            _lblVehicleCheck.Location = new Point(6, 49);
            _lblVehicleCheck.Name = "lblVehicleCheck";
            _lblVehicleCheck.Size = new Size(162, 20);
            _lblVehicleCheck.TabIndex = 69;
            _lblVehicleCheck.Text = "Vehicle Safety && Condition";
            //
            // dtpAuditDate
            //
            _dtpAuditDate.Location = new Point(346, 326);
            _dtpAuditDate.Name = "dtpAuditDate";
            _dtpAuditDate.Size = new Size(146, 21);
            _dtpAuditDate.TabIndex = 66;
            _dtpAuditDate.Tag = "";
            //
            // lblAuditDate
            //
            _lblAuditDate.Location = new Point(255, 329);
            _lblAuditDate.Name = "lblAuditDate";
            _lblAuditDate.Size = new Size(85, 13);
            _lblAuditDate.TabIndex = 67;
            _lblAuditDate.Text = "Audit Date";
            //
            // btnNewAudit
            //
            _btnNewAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnNewAudit.Location = new Point(3, 404);
            _btnNewAudit.Name = "btnNewAudit";
            _btnNewAudit.Size = new Size(75, 23);
            _btnNewAudit.TabIndex = 8;
            _btnNewAudit.Text = "New";
            _btnNewAudit.UseVisualStyleBackColor = true;
            //
            // btnSaveAudit
            //
            _btnSaveAudit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveAudit.Location = new Point(417, 404);
            _btnSaveAudit.Name = "btnSaveAudit";
            _btnSaveAudit.Size = new Size(75, 23);
            _btnSaveAudit.TabIndex = 3;
            _btnSaveAudit.Text = "Save";
            //
            // UCEngineer
            //
            Controls.Add(_TabControl1);
            Name = "UCEngineer";
            Size = new Size(520, 679);
            _TabControl1.ResumeLayout(false);
            _tpMain.ResumeLayout(false);
            _grpEngineer.ResumeLayout(false);
            _grpEngineer.PerformLayout();
            _tpMaxTimes.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
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
            _GroupBox8.ResumeLayout(false);
            _GroupBox8.PerformLayout();
            _grpPostalRegions.ResumeLayout(false);
            _grpPostalRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUnTicked).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgPostalRegions).EndInit();
            _tpSiteSafetyAudits.ResumeLayout(false);
            _grpSiteSafetyAudits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSiteSafetyAudits).EndInit();
            _grpSiteSafetyAudit.ResumeLayout(false);
            _grpSiteSafetyAudit.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            // SetupLevelsDataGrid()
            SetupPostalRegionsDataGrid();
            SetupPostalRegionsDataGridUnTicked();
            SetupTrainingQualificationsDataGrid();
            SetupEngineerEquipmentDataGrid();
            SetupDisciplinariesDataGrid();
            SetupAbsenceDataGridGrid();
            SetupDgSiteSafetyAudit();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentEngineer;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private UCDocumentsList DocumentsControl;
        private string oldDepartment = string.Empty;
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

        private Engineer _currentEngineer;

        public Engineer CurrentEngineer
        {
            get
            {
                return _currentEngineer;
            }

            set
            {
                _currentEngineer = value;
                if (_currentEngineer is null)
                {
                    _currentEngineer = new Engineer();
                    _currentEngineer.Exists = false;
                }

                txtHolidayYearStart.Text = _currentEngineer.HolidayYearStart;
                txtHolidayYearEnd.Text = _currentEngineer.HolidayYearEnd;
                if (_currentEngineer.Exists)
                {
                    Populate();
                    btnVanHistory.Enabled = true;
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblEngineer, _currentEngineer.EngineerID);
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
                PopulateSiteSafetyAuditDataGrid();
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void RunFilter()
        {
            string whereClause = "Name Like '%" + txtPCSearch.Text + "%'";
            PostalRegionsDataViewUT.RowFilter = whereClause;
        }

        private void UCEngineer_Load(object sender, EventArgs e)
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

        private void dgPostalRegionsUnticked_Clicks(object sender, EventArgs e)
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

        private void btnVanHistory_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMVanHistory), true, new object[] { CurrentEngineer.EngineerID });
        }

        private void dgTrainingQualifications_Click(object sender, EventArgs e)
        {
            try
            {
                var argc = cboQualificationType;
                Combo.SetUpCombo(ref argc, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
                var argcombo = cboQualification;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, SelectedTrainingQualificationsRow[0].ToString());
                txtQualificatioNote.Text = Conversions.ToString(SelectedTrainingQualificationsRow[3]);
                dtpQualificationPassed.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[4]);
                dtpQualificationExpires.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[5]);
                dtpQualificationBooked.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[6]);
            }
            catch
            {
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentEngineer = App.DB.Engineer.Engineer_Get(ID);
            }

            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Qualifications))
            {
                txtGasSafeNo.ReadOnly = true;
                TxtOftec.ReadOnly = true;
            }

            // fix for blank departments , this should never of been a string anyhow..

            if (string.IsNullOrEmpty(CurrentEngineer.Department))
                CurrentEngineer.SetDepartment = "0";
            oldDepartment = CurrentEngineer.Department;
            var argcombo = cboRegionID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentEngineer.RegionID.ToString());
            if (!CurrentEngineer.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
            {
                cboRegionID.Enabled = false;
            }

            var argcombo1 = cboEngineerGroup;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentEngineer.EngineerGroupID.ToString());
            var argcombo2 = cboLinkToUser;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentEngineer.UserID.ToString());
            var argcombo3 = cboEngineerRoleId;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentEngineer.EngineerRoleId.ToString());
            var argcombo4 = cboDepartment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentEngineer.Department.Trim());
            txtGasSafeNo.Text = CurrentEngineer.GasSafeNo;
            TxtOftec.Text = CurrentEngineer.OftecNo;
            txtName.Text = CurrentEngineer.Name;
            txtTelephoneNum.Text = CurrentEngineer.TelephoneNum;
            txtEmailAddress.Text = CurrentEngineer.EmailAddress;
            if (CurrentEngineer.EngineerID == 0)
            {
                txtEngineerID.Text = "<Not Set>";
            }
            else
            {
                txtEngineerID.Text = CurrentEngineer.EngineerID.ToString();
            }

            chkApprentice.Checked = CurrentEngineer.Apprentice;
            // Me.txtCostToCompanyNormal.Text = Format(CurrentEngineer.CostToCompanyNormal, "C")
            // Me.txtCostToCompanyTimeHalf.Text = Format(CurrentEngineer.CostToCompanyTimeAndHalf, "C")
            // Me.txtCostToCompanyDouble.Text = Format(CurrentEngineer.CostToCompanyDouble, "C")

            MaxTimes = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(CurrentEngineer.EngineerID);
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

            txtTechnician.Text = CurrentEngineer.Technician;
            var argcombo5 = cboUser;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, CurrentEngineer.ManagerUserID.ToString());
            // txtSupervisor.Text = CurrentEngineer.Supervisor

            txtNextOfKinName.Text = CurrentEngineer.NextOfKinName;
            txtNextOfKinContact.Text = CurrentEngineer.NextOfKinContact;
            txtStartingDetails.Text = CurrentEngineer.StartingDetails;
            txtDrivingLicenceNo.Text = CurrentEngineer.DrivingLicenceNo;
            if (CurrentEngineer.DrivingLicenceIssueDate != default)
            {
                dtpDrivingLicenceIssueDate.Value = CurrentEngineer.DrivingLicenceIssueDate;
                dtpDrivingLicenceIssueDate.Checked = true;
            }
            else
            {
                dtpDrivingLicenceIssueDate.Value = DateAndTime.Now.Date;
                dtpDrivingLicenceIssueDate.Checked = false;
            }

            // 'Combo.SetSelectedComboItem_By_Value(Me.cboPayGrade, CurrentEngineer.PayGradeID)
            // 'txtAnnualSalary.Text = CurrentEngineer.AnnualSalary
            // 'txtNINumber.Text = CurrentEngineer.NINumber
            txtHolidayYearStart.Text = CurrentEngineer.HolidayYearStart;
            txtHolidayYearEnd.Text = CurrentEngineer.HolidayYearEnd;
            txtDaysHolidayAllowed.Text = CurrentEngineer.DaysHolidayAllowed.ToString();
            if (CurrentEngineer.Name.Trim().StartsWith("SUBCONTRACTOR : "))
            {
                txtName.ReadOnly = true;
                txtTelephoneNum.ReadOnly = true;
            }

            txtServPri.Text = CurrentEngineer.ServPri.ToString();
            txtBreakPri.Text = CurrentEngineer.BreakPri.ToString();
            txtPostcode.Text = CurrentEngineer.HomePostcode;
            txtDailyServiceLimit.Text = CurrentEngineer.DailyServiceLimit.ToString();
            var argcombo6 = cboRagRating;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, CurrentEngineer.RagRating.ToString());
            dtpRagDate.Value = CurrentEngineer.RagDate;
            txtVisitSpendLimit.Text = CurrentEngineer.VisitSpendLimit.ToString();
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        private void PopulatePostalRegions()
        {
            PostalRegionsDataView = App.DB.EngineerPostalRegion.GetOnlyTicked(CurrentEngineer.EngineerID);
            PostalRegionsDataViewUT = App.DB.EngineerPostalRegion.GetUnTicked(CurrentEngineer.EngineerID);
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentEngineer.IgnoreExceptionsOnSetMethods = true;
                if (!CurrentEngineer.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
                {
                    CurrentEngineer.SetRegionID = Combo.get_GetSelectedItemValue(cboRegionID);
                }

                CurrentEngineer.SetUserID = Combo.get_GetSelectedItemValue(cboLinkToUser);
                CurrentEngineer.SetEngineerGroupID = Combo.get_GetSelectedItemValue(cboEngineerGroup);
                CurrentEngineer.SetGasSafeNo = txtGasSafeNo.Text.Trim();
                CurrentEngineer.SetOftecNo = TxtOftec.Text.Trim();
                CurrentEngineer.SetName = txtName.Text.Trim();
                CurrentEngineer.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentEngineer.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentEngineer.SetPDAID = 0;
                CurrentEngineer.SetTechnician = txtTechnician.Text.Trim();
                CurrentEngineer.SetSupervisor = Combo.get_GetSelectedItemDescription(cboUser);
                CurrentEngineer.SetManagerUserID = Combo.get_GetSelectedItemValue(cboUser);
                CurrentEngineer.SetNextOfKinName = txtNextOfKinName.Text;
                CurrentEngineer.SetNextOfKinContact = txtNextOfKinContact.Text;
                CurrentEngineer.SetStartingDetails = txtStartingDetails.Text;
                CurrentEngineer.SetDrivingLicenceNo = txtDrivingLicenceNo.Text;
                if (dtpDrivingLicenceIssueDate.Checked)
                {
                    CurrentEngineer.DrivingLicenceIssueDate = dtpDrivingLicenceIssueDate.Value;
                }
                else
                {
                    CurrentEngineer.DrivingLicenceIssueDate = default;
                }

                CurrentEngineer.SetHolidayYearStart = txtHolidayYearStart.Text;
                CurrentEngineer.SetHolidayYearEnd = txtHolidayYearEnd.Text;
                if (txtDaysHolidayAllowed.Text.Trim().Length > 0)
                {
                    CurrentEngineer.SetDaysHolidayAllowed = txtDaysHolidayAllowed.Text;
                }

                string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
                if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
                {
                    CurrentEngineer.SetDepartment = department;
                }
                else if (!Information.IsNumeric(department))
                {
                    CurrentEngineer.SetDepartment = department;
                }

                CurrentEngineer.SetServPri = txtServPri.Text;
                CurrentEngineer.SetBreakPri = txtBreakPri.Text;
                CurrentEngineer.SetDailyServiceLimit = txtDailyServiceLimit.Text;
                CurrentEngineer.SetHomePostcode = txtPostcode.Text;
                if (txtWebAppPassword.Text.Trim().Length > 0)
                    CurrentEngineer.SetWebAppPassword = txtWebAppPassword.Text.Trim();
                if (CurrentEngineer.Exists)
                {
                    CurrentEngineer.SetRagRating = Combo.get_GetSelectedItemValue(cboRagRating);
                    CurrentEngineer.RagDate = dtpRagDate.Value;
                }
                else
                {
                    CurrentEngineer.SetRagRating = 2;
                    CurrentEngineer.RagDate = DateAndTime.Now;
                }

                if (txtVisitSpendLimit.Text.Trim().Length > 0)
                    CurrentEngineer.SetVisitSpendLimit = Helper.MakeDoubleValid(txtVisitSpendLimit.Text.Trim());
                CurrentEngineer.SetEngineerRoleId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboEngineerRoleId));
                var cV = new EngineerValidator();
                cV.Validate(CurrentEngineer);
                if (CurrentEngineer.Exists)
                {
                    App.DB.Engineer.Update(CurrentEngineer);
                    App.DB.EngineerPostalRegion.Delete(CurrentEngineer.EngineerID);
                    foreach (DataRow row in PostalRegionsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(row["Tick"]))
                        {
                            App.DB.EngineerPostalRegion.Insert(CurrentEngineer.EngineerID, Conversions.ToInteger(row["ManagerID"]));
                        }
                    }

                    if (MaxTimes is null)
                    {
                        MaxTimes = new Entity.MaxEngineerTimes.MaxEngineerTime();
                    }

                    MaxTimes.SetEngineerID = CurrentEngineer.EngineerID;
                    MaxTimes.SetMondayValue = txtMondayValue.Text;
                    MaxTimes.SetTuesdayValue = txtTuesdayValue.Text;
                    MaxTimes.SetWednesdayValue = txtWednesdayValue.Text;
                    MaxTimes.SetThursdayValue = txtThursdayValue.Text;
                    MaxTimes.SetFridayValue = txtFridayValue.Text;
                    MaxTimes.SetSaturdayValue = txtSaturdayValue.Text;
                    MaxTimes.SetSundayValue = txtSundayValue.Text;
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

                    App.DB.EngineerLevel.Insert(CurrentEngineer.EngineerID, TrainingQualificationsDataView.Table);
                    App.DB.Engineer.SaveEquipmentRecords(CurrentEngineer.EngineerID, EngineerEquipmentDataView.Table);
                    App.DB.Engineer.SaveDisciplinaryRecords(CurrentEngineer.EngineerID, DisciplinariesDataView.Table);

                    // send another email
                    if ((CurrentEngineer.Department ?? "") != (oldDepartment ?? ""))
                    {
                        if (App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser)))?.EmailAddress.Length > 2 == true)
                        {
                            string message1 = "";
                            message1 = "The engineer " + CurrentEngineer.Name + " has been Ammended. They have been moved from department " + oldDepartment + " to department " + CurrentEngineer.Department + " you have been marked as his line manager. Please ensure all necessary records are updated.";
                            Email2(App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser))).EmailAddress, message1, App.loggedInUser.Fullname, EmailAddress.StockFinancials);
                        }
                        else
                        {
                            string message1 = "";
                            message1 = "The engineer " + CurrentEngineer.Name + " has been Ammended. They have been moved from department " + oldDepartment + " to department " + CurrentEngineer.Department + ". Please ensure all necessary records are updated.";
                            Email2(EmailAddress.StockFinancials, message1, App.loggedInUser.Fullname, "");
                        }
                    }
                }
                else
                {
                    var tempEng = App.DB.Engineer.Insert(CurrentEngineer);
                    App.DB.EngineerPostalRegion.Delete(tempEng.EngineerID);
                    foreach (DataRow row in PostalRegionsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(row["Tick"]))
                        {
                            App.DB.EngineerPostalRegion.Insert(tempEng.EngineerID, Conversions.ToInteger(row["ManagerID"]));
                        }
                    }

                    if (MaxTimes is null)
                    {
                        MaxTimes = new Entity.MaxEngineerTimes.MaxEngineerTime();
                    }

                    MaxTimes.SetEngineerID = tempEng.EngineerID;
                    MaxTimes.SetMondayValue = txtMondayValue.Text;
                    MaxTimes.SetTuesdayValue = txtTuesdayValue.Text;
                    MaxTimes.SetWednesdayValue = txtWednesdayValue.Text;
                    MaxTimes.SetThursdayValue = txtThursdayValue.Text;
                    MaxTimes.SetFridayValue = txtFridayValue.Text;
                    MaxTimes.SetSaturdayValue = txtSaturdayValue.Text;
                    MaxTimes.SetSundayValue = txtSundayValue.Text;
                    var mTV = new Entity.MaxEngineerTimes.MaxEngineerTimeValidator();
                    mTV.Validate(MaxTimes);
                    App.DB.MaxEngineerTime.Insert(MaxTimes);
                    App.DB.EngineerLevel.Insert(tempEng.EngineerID, TrainingQualificationsDataView.Table);
                    App.DB.Engineer.SaveEquipmentRecords(tempEng.EngineerID, EngineerEquipmentDataView.Table);
                    App.DB.Engineer.SaveDisciplinaryRecords(tempEng.EngineerID, DisciplinariesDataView.Table);
                    CurrentEngineer = tempEng;

                    // SEND AN EMAIL

                    string message = "";
                    bool gassafe = false;
                    bool Oftec = false;
                    if (TxtOftec.Text.Length > 0 & !((TxtOftec.Text ?? "") == "tbc"))
                        Oftec = true;
                    if (txtGasSafeNo.Text.Length > 0 & !((txtGasSafeNo.Text ?? "") == "tbc"))
                        gassafe = true;
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboUser)) > 0 && App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser))).EmailAddress.Length > 3)
                    {
                        message = "The engineer " + CurrentEngineer.Name + " has been added for department " + CurrentEngineer.Department + " you have been marked as his line manager." + "<br/><br/>" + "Please ensure all necessary records are updated.";
                        if (!Oftec)
                            message += "<br/>No oftec registered reference has been added.";
                        if (!gassafe)
                            message += "<br/>No Gas Safe registered reference has been added.";
                        if (!Oftec | !gassafe)
                            message += "<br/>Engineer CANNOT work on gas or oil until the GSR or OFTEC number has been filled in!";
                        Email(App.DB.User.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser))).EmailAddress, message, App.loggedInUser.Fullname, EmailAddress.HR + ", " + EmailAddress.Compliance);
                    }
                    else
                    {
                        message = "The engineer " + CurrentEngineer.Name + " has been added for department " + CurrentEngineer.Department + "." + "<br/><br/>" + "Please ensure all necessary records are updated.";
                        if (!Oftec)
                            message += "<br/>No oftec registered reference has been added.";
                        if (!gassafe)
                            message += "<br/>No Gas Safe registered reference has been added.";
                        if (!Oftec | !gassafe)
                            message += "<br/>Engineer CANNOT work on gas Or oil until the GSR Or OFTEC number has been filled in!";
                        Email(EmailAddress.HR + ", " + EmailAddress.Compliance, message, App.loggedInUser.Fullname, "");
                    }
                }

                RecordsChanged?.Invoke(App.DB.Engineer.Engineer_GetAll_NoSub(), Enums.PageViewing.Engineer, true, false, "");
                StateChanged?.Invoke(CurrentEngineer.EngineerID);
                App.MainForm.RefreshEntity(CurrentEngineer.EngineerID);
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

        private void Email(string emailadd, string message, string addinguser, string cc)
        {
            string PersonName = null;
            string GreetingPart = null;
            var FeedbackEmail = new Emails();
            FeedbackEmail.From = EmailAddress.Gabriel;
            FeedbackEmail.To = emailadd;
            FeedbackEmail.CC = cc;
            FeedbackEmail.Subject = "A New Engineer Has been added";
            FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" + "<p>Hi</p>" + "<p>User : " + addinguser + " has added a new engineer</p>" + "<p>" + message + "</p>" + "<p>King Regards</p>" + "<p>" + App.TheSystem.Configuration.CompanyName + "</p>" + "</span>";
            FeedbackEmail.SendMe = true;
            if (FeedbackEmail.Send())
            {
            }
        }

        private void Email2(string emailadd, string message, string addinguser, string cc)
        {
            string PersonName = null;
            string GreetingPart = null;
            var FeedbackEmail = new Emails();
            FeedbackEmail.From = EmailAddress.Gabriel;
            FeedbackEmail.To = emailadd;
            FeedbackEmail.CC = cc;
            FeedbackEmail.Subject = "An Engineers department has changed";
            FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" + "<p>Hi</p>" + "<p>User : " + addinguser + " has ammended an engineer</p>" + "<p>" + message + "</p>" + "<p>King Regards</p>" + "<p>" + App.TheSystem.Configuration.CompanyName + "</p>" + "</span>";
            FeedbackEmail.SendMe = true;
            if (FeedbackEmail.Send())
            {
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
            Name.HeaderText = "Postcode";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.MappingName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            dgPostalRegions.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgPostalRegions);
        }

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
                }
                else
                {
                    return null;
                }
            }
        }

        private void PopulateTrainingQualifications()
        {
            try
            {
                TrainingQualificationsDataView = App.DB.EngineerLevel.GetForSetup(CurrentEngineer.EngineerID);
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
                r["Description"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[0].Trim();
                r["Level"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[1].Trim();
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
                }
                else
                {
                    return null;
                }
            }
        }

        private void PopulateEngineerEquipment()
        {
            try
            {
                EngineerEquipmentDataView = new DataView(App.DB.Engineer.GetEquipmentRecords(CurrentEngineer.EngineerID));
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
                }
                else
                {
                    return null;
                }
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
                DisciplinariesDataView = new DataView(App.DB.Engineer.GetDisciplinaryRecords(CurrentEngineer.EngineerID));
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
                AbsencesDataView = new DataView(App.DB.EngineerAbsence.GetAbsencesForEngineer(CurrentEngineer.EngineerID));
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Label43_Click(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Engineer _auditor;

        public Engineer Auditor
        {
            get
            {
                return _auditor;
            }

            set
            {
                _auditor = value;
                if (_auditor is object)
                {
                    txtAuditor.Text = Auditor.Name;
                }
                else
                {
                    txtAuditor.Text = "<Not Set>";
                }
            }
        }

        private SiteSafetyAudit SiteSafetyAudit;
        private DataView _dvSiteSafetyAudits;

        private DataView DvSiteSafetyAudits
        {
            get
            {
                return _dvSiteSafetyAudits;
            }

            set
            {
                _dvSiteSafetyAudits = value;
                _dvSiteSafetyAudits.AllowNew = false;
                _dvSiteSafetyAudits.AllowEdit = false;
                _dvSiteSafetyAudits.AllowDelete = false;
                _dvSiteSafetyAudits.Table.TableName = Enums.TableNames.tblEngineer.ToString();
                dgSiteSafetyAudits.DataSource = DvSiteSafetyAudits;
            }
        }

        private DataRow DrSelectedSiteSafetyAudit
        {
            get
            {
                if (!(dgSiteSafetyAudits.CurrentRowIndex == -1))
                {
                    return DvSiteSafetyAudits[dgSiteSafetyAudits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupDgSiteSafetyAudit()
        {
            Helper.SetUpDataGrid(dgSiteSafetyAudits);
            var tStyle = dgSiteSafetyAudits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var auditDate = new DataGridSiteSafetyAuditColumn();
            auditDate.Format = "dd/MM/yyyy";
            auditDate.FormatInfo = null;
            auditDate.HeaderText = "Audit Date";
            auditDate.MappingName = "AuditDate";
            auditDate.ReadOnly = true;
            auditDate.Width = 100;
            auditDate.NullText = "";
            tStyle.GridColumnStyles.Add(auditDate);
            var auditor = new DataGridSiteSafetyAuditColumn();
            auditor.Format = "";
            auditor.FormatInfo = null;
            auditor.HeaderText = "Auditor";
            auditor.MappingName = "Auditor";
            auditor.ReadOnly = true;
            auditor.Width = 120;
            auditor.NullText = "";
            tStyle.GridColumnStyles.Add(auditor);
            var question1 = new DataGridSiteSafetyAuditColumn();
            question1.Format = "";
            question1.FormatInfo = null;
            question1.HeaderText = "Vehicle Safety & Condition";
            question1.MappingName = "Question1";
            question1.ReadOnly = true;
            question1.Width = 120;
            question1.NullText = "";
            tStyle.GridColumnStyles.Add(question1);
            var question2 = new DataGridSiteSafetyAuditColumn();
            question2.Format = "";
            question2.FormatInfo = null;
            question2.HeaderText = "Document & Procedures";
            question2.MappingName = "Question2";
            question2.ReadOnly = true;
            question2.Width = 120;
            question2.NullText = "";
            tStyle.GridColumnStyles.Add(question2);
            var question3 = new DataGridSiteSafetyAuditColumn();
            question3.Format = "";
            question3.FormatInfo = null;
            question3.HeaderText = "Uniform & PPE";
            question3.MappingName = "question3";
            question3.ReadOnly = true;
            question3.Width = 120;
            question3.NullText = "";
            tStyle.GridColumnStyles.Add(question3);
            var question4 = new DataGridSiteSafetyAuditColumn();
            question4.Format = "";
            question4.FormatInfo = null;
            question4.HeaderText = "Environmental Conditions";
            question4.MappingName = "question4";
            question4.ReadOnly = true;
            question4.Width = 120;
            question4.NullText = "";
            tStyle.GridColumnStyles.Add(question4);
            var question5 = new DataGridSiteSafetyAuditColumn();
            question5.Format = "";
            question5.FormatInfo = null;
            question5.HeaderText = "Housekeeping";
            question5.MappingName = "question5";
            question5.ReadOnly = true;
            question5.Width = 120;
            question5.NullText = "";
            tStyle.GridColumnStyles.Add(question5);
            var question6 = new DataGridSiteSafetyAuditColumn();
            question6.Format = "";
            question6.FormatInfo = null;
            question6.HeaderText = "Machinery & Equipment";
            question6.MappingName = "question6";
            question6.ReadOnly = true;
            question6.Width = 120;
            question6.NullText = "";
            tStyle.GridColumnStyles.Add(question6);
            var question7 = new DataGridSiteSafetyAuditColumn();
            question7.Format = "";
            question7.FormatInfo = null;
            question7.HeaderText = "First Aid & Welfare";
            question7.MappingName = "question7";
            question7.ReadOnly = true;
            question7.Width = 120;
            question7.NullText = "";
            tStyle.GridColumnStyles.Add(question7);
            var question8 = new DataGridSiteSafetyAuditColumn();
            question8.Format = "";
            question8.FormatInfo = null;
            question8.HeaderText = "Manual Handling";
            question8.MappingName = "question8";
            question8.ReadOnly = true;
            question8.Width = 120;
            question8.NullText = "";
            tStyle.GridColumnStyles.Add(question8);
            var question9 = new DataGridSiteSafetyAuditColumn();
            question9.Format = "";
            question9.FormatInfo = null;
            question9.HeaderText = "COSSH";
            question9.MappingName = "question9";
            question9.ReadOnly = true;
            question9.Width = 120;
            question9.NullText = "";
            tStyle.GridColumnStyles.Add(question9);
            var question10 = new DataGridSiteSafetyAuditColumn();
            question10.Format = "";
            question10.FormatInfo = null;
            question10.HeaderText = "Working At Height";
            question10.MappingName = "question10";
            question10.ReadOnly = true;
            question10.Width = 120;
            question10.NullText = "";
            tStyle.GridColumnStyles.Add(question10);
            var question11 = new DataGridSiteSafetyAuditColumn();
            question11.Format = "";
            question11.FormatInfo = null;
            question11.HeaderText = "Asbestos";
            question11.MappingName = "question11";
            question11.ReadOnly = true;
            question11.Width = 120;
            question11.NullText = "";
            tStyle.GridColumnStyles.Add(question11);
            var result = new DataGridSiteSafetyAuditColumn();
            result.Format = "";
            result.FormatInfo = null;
            result.HeaderText = "Total";
            result.MappingName = "result";
            result.ReadOnly = true;
            result.Width = 120;
            result.NullText = "";
            tStyle.GridColumnStyles.Add(result);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblEngineer.ToString();
            dgSiteSafetyAudits.TableStyles.Add(tStyle);
        }

        public void PopulateSiteSafetyAuditDataGrid()
        {
            try
            {
                DvSiteSafetyAudits = App.DB.SiteSafteyAudit.Get_As_DataView(CurrentEngineer.EngineerID, Entity.Engineers.SiteSafetyAudits.Enums.GetBy.EngineerId);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot load datagrid: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAudit_Click(object sender, EventArgs e)
        {
            if (CurrentEngineer is null)
                return;
            if (!(App.ShowMessage("Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                return;
            }

            if (SiteSafetyAudit is null)
            {
                SiteSafetyAudit = new SiteSafetyAudit();
            }

            {
                var withBlock = SiteSafetyAudit;
                withBlock.EngineerId = CurrentEngineer.EngineerID;
                withBlock.Department = CurrentEngineer.Department;
                withBlock.AuditDate = dtpAuditDate.Value;
                withBlock.Question1 = Helper.MakeDoubleValid(txtVehicleSafetyCondition.Text);
                withBlock.Question2 = Helper.MakeDoubleValid(txtDocumentProcedures.Text);
                withBlock.Question3 = Helper.MakeDoubleValid(txtUniformPPE.Text);
                withBlock.Question4 = Helper.MakeDoubleValid(txtEnvironmentalConditions.Text);
                withBlock.Question5 = Helper.MakeDoubleValid(txtHousekeeping.Text);
                withBlock.Question6 = Helper.MakeDoubleValid(txtMachineryEquipment.Text);
                withBlock.Question7 = Helper.MakeDoubleValid(txtFirstAidWelfare.Text);
                withBlock.Question8 = Helper.MakeDoubleValid(txtManualHandling.Text);
                withBlock.Question9 = Helper.MakeDoubleValid(txtCOSSH.Text);
                withBlock.Question10 = Helper.MakeDoubleValid(txtWorkingAtHeight.Text);
                withBlock.Question11 = Helper.MakeDoubleValid(txtAsbestos.Text);
                withBlock.Result = Helper.MakeDoubleValid(txtTotal.Text);
                withBlock.AuditorId = Helper.MakeIntegerValid(Auditor?.EngineerID);
            }

            bool isValid = true;
            var props = SiteSafetyAudit.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if ((prop.PropertyType.Name ?? "") == (typeof(double).Name ?? ""))
                {
                    double score = Conversions.ToDouble(prop.GetValue(SiteSafetyAudit, null));
                    if (score < -1 | score > 100)
                    {
                        isValid = false;
                    }
                }
            }

            if (!isValid)
            {
                App.ShowMessage("Please ensure values are between 0 & 100!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SiteSafetyAudit.AuditDate > DateAndTime.Now)
            {
                App.ShowMessage("Audit date cannot be in the future!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SiteSafetyAudit.Id > 0)
            {
                App.DB.SiteSafteyAudit.Update(SiteSafetyAudit);
            }
            else
            {
                SiteSafetyAudit = App.DB.SiteSafteyAudit.Insert(SiteSafetyAudit);
            }

            PopulateSiteSafetyAuditDataGrid();
            ClearAuditForm();
        }

        private void btnNewAudit_Click(object sender, EventArgs e)
        {
            ClearAuditForm();
        }

        private void ClearAuditForm()
        {
            SiteSafetyAudit = null;
            dtpAuditDate.Value = DateAndTime.Now;
            txtVehicleSafetyCondition.Text = "";
            txtDocumentProcedures.Text = "";
            txtUniformPPE.Text = "";
            txtEnvironmentalConditions.Text = "";
            txtHousekeeping.Text = "";
            txtMachineryEquipment.Text = "";
            txtFirstAidWelfare.Text = "";
            txtManualHandling.Text = "";
            txtCOSSH.Text = "";
            txtWorkingAtHeight.Text = "";
            txtAsbestos.Text = "";
            txtTotal.Text = "";
            Auditor = null;
        }

        private void btnDeleteAudit_Click(object sender, EventArgs e)
        {
            if (DrSelectedSiteSafetyAudit is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                App.DB.SiteSafteyAudit.Delete(Conversions.ToInteger(DrSelectedSiteSafetyAudit["Id"]));
                PopulateSiteSafetyAuditDataGrid();
                ClearAuditForm();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgSiteSafetyAudits_Click(object sender, EventArgs e)
        {
            if (DrSelectedSiteSafetyAudit is null)
            {
                return;
            }

            SiteSafetyAudit = App.DB.SiteSafteyAudit.Get_As_Entity(DrSelectedSiteSafetyAudit["Id"], Entity.Engineers.SiteSafetyAudits.Enums.GetBy.Id)?.FirstOrDefault();
            if (SiteSafetyAudit is object)
            {
                {
                    var withBlock = SiteSafetyAudit;
                    dtpAuditDate.Value = withBlock.AuditDate;
                    txtVehicleSafetyCondition.Text = withBlock.Question1.ToString();
                    txtDocumentProcedures.Text = withBlock.Question2.ToString();
                    txtUniformPPE.Text = withBlock.Question3.ToString();
                    txtEnvironmentalConditions.Text = withBlock.Question4.ToString();
                    txtHousekeeping.Text = withBlock.Question5.ToString();
                    txtMachineryEquipment.Text = withBlock.Question6.ToString();
                    txtFirstAidWelfare.Text = withBlock.Question7.ToString();
                    txtManualHandling.Text = withBlock.Question8.ToString();
                    txtCOSSH.Text = withBlock.Question9.ToString();
                    txtWorkingAtHeight.Text = withBlock.Question10.ToString();
                    txtAsbestos.Text = withBlock.Question11.ToString();
                    txtTotal.Text = withBlock.Result.ToString();
                    Auditor = App.DB.Engineer.Engineer_Get(withBlock.AuditorId);
                }
            }
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Auditor = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private void cboLinkToUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboLinkToUser.SelectedValue is null)
            {
                int userId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLinkToUser));
                if (App.DB.Engineer.UserIsLinkedToEngineer(userId))
                {
                    App.ShowMessage("This user is already linked to an engineer. Please try another user.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboLinkToUser.SelectedIndex = 0;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}