using FSM.Entity.EngineerVisitAssetWorkSheets;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Sys;
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
    public class UCSolidWorksheet : UCBase, IUserControl
    {
        public UCSolidWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, EngineerVisit EngineerVisit) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table;
            DtPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail).Table;
            DtPassFailNA = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
            _Worksheet = worksheet;
            _jobID = jobID;
            _EngineerVisit = EngineerVisit;
            SetUpCombos();
            Populate();
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

        
        private TextBox _txtFlueDraught;

        internal TextBox txtFlueDraught
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFlueDraught;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _txtFlueDraught = value;
            }
        }

        private TextBox _txtNominalOutput;

        internal TextBox txtNominalOutput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominalOutput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _txtNominalOutput = value;
            }
        }

        private TextBox _txtVentilationType;

        internal TextBox txtVentilationType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVentilationType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _txtVentilationType = value;
            }
        }

        private ComboBox _cboSafety;

        internal ComboBox cboSafety
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSafety;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSafety = value;
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
                _Label18 = value;
            }
        }

        private ComboBox _cboExtractorFans;

        internal ComboBox cboExtractorFans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExtractorFans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboExtractorFans = value;
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
                _Label19 = value;
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
                _Label20 = value;
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
                _Label21 = value;
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
                _Label22 = value;
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
                _Label11 = value;
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
                _Label12 = value;
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
                _Label13 = value;
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
                _Label14 = value;
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
                _Label15 = value;
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
                _Label16 = value;
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
                _Label17 = value;
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
                _Label6 = value;
            }
        }

        private ComboBox _cboSweptBrush;

        internal ComboBox cboSweptBrush
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSweptBrush;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSweptBrush = value;
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
                _Label7 = value;
            }
        }

        private ComboBox _cboFlueClear;

        internal ComboBox cboFlueClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFlueClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboFlueClear = value;
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
                _Label8 = value;
            }
        }

        private ComboBox _cboFireGuardFixingPoint;

        internal ComboBox cboFireGuardFixingPoint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFireGuardFixingPoint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboFireGuardFixingPoint = value;
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
                _Label9 = value;
            }
        }

        private ComboBox _cboCorrectHearthSize;

        internal ComboBox cboCorrectHearthSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCorrectHearthSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboCorrectHearthSize = value;
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
                _Label10 = value;
            }
        }

        private ComboBox _cboChimneySwept;

        internal ComboBox cboChimneySwept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboChimneySwept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboChimneySwept = value;
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
                _Label3 = value;
            }
        }

        private ComboBox _cboChimneyStructureSound;

        internal ComboBox cboChimneyStructureSound
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboChimneyStructureSound;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboChimneyStructureSound = value;
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
                _Label4 = value;
            }
        }

        private ComboBox _cboVisualCondition;

        internal ComboBox cboVisualCondition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisualCondition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboVisualCondition = value;
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
                _Label5 = value;
            }
        }

        private ComboBox _cboTerminationSatisfactory;

        internal ComboBox cboTerminationSatisfactory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTerminationSatisfactory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboTerminationSatisfactory = value;
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
                _Label2 = value;
            }
        }

        private ComboBox _cboAppliance;

        internal ComboBox cboAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboAppliance = value;
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
                _Label1 = value;
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
                _Label23 = value;
            }
        }

        private Label _lblNotTested1;

        internal Label lblNotTested1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested1 = value;
            }
        }

        private Label _lblNotTested2;

        internal Label lblNotTested2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested2 = value;
            }
        }

        private Label _lblNotTested3;

        internal Label lblNotTested3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested3 = value;
            }
        }

        private Label _lblNotTested6;

        internal Label lblNotTested6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested6 = value;
            }
        }

        private Label _lblNotTested5;

        internal Label lblNotTested5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested5 = value;
            }
        }

        private Label _lblNotTested4;

        internal Label lblNotTested4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested4 = value;
            }
        }

        private Label _lblNotTested12;

        internal Label lblNotTested12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested12 = value;
            }
        }

        private Label _lblNotTested11;

        internal Label lblNotTested11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested11 = value;
            }
        }

        private Label _lblNotTested10;

        internal Label lblNotTested10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested10 = value;
            }
        }

        private Label _lblNotTested9;

        internal Label lblNotTested9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested9 = value;
            }
        }

        private Label _lblNotTested8;

        internal Label lblNotTested8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested8 = value;
            }
        }

        private Label _lblNotTested7;

        internal Label lblNotTested7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested7 = value;
            }
        }

        private Label _lblNotTested18;

        internal Label lblNotTested18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested18 = value;
            }
        }

        private Label _lblNotTested17;

        internal Label lblNotTested17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested17 = value;
            }
        }

        private Label _lblNotTested16;

        internal Label lblNotTested16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested16 = value;
            }
        }

        private Label _lblNotTested15;

        internal Label lblNotTested15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested15 = value;
            }
        }

        private Label _lblNotTested14;

        internal Label lblNotTested14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested14 = value;
            }
        }

        private Label _lblNotTested13;

        internal Label lblNotTested13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotTested13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblNotTested13 = value;
            }
        }

        private ComboBox _cboCombustionAir;

        internal ComboBox cboCombustionAir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCombustionAir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboCombustionAir = value;
            }
        }

        private ComboBox _cboFluePerformance;

        internal ComboBox cboFluePerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFluePerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboFluePerformance = value;
            }
        }

        private ComboBox _cboSafetyDevice;

        internal ComboBox cboSafetyDevice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSafetyDevice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSafetyDevice = value;
            }
        }

        private ComboBox _cboApplianceServiced;

        internal ComboBox cboApplianceServiced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboApplianceServiced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboApplianceServiced = value;
            }
        }

        private ComboBox _cboTennantKnow;

        internal ComboBox cboTennantKnow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTennantKnow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboTennantKnow = value;
            }
        }

        private ComboBox _cboInstuctions;

        internal ComboBox cboInstuctions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInstuctions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboInstuctions = value;
            }
        }

        private ComboBox _cboTypeOfCylinder;

        internal ComboBox cboTypeOfCylinder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTypeOfCylinder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboTypeOfCylinder = value;
            }
        }

        private ComboBox _cboImmersionHeater;

        internal ComboBox cboImmersionHeater
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboImmersionHeater;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboImmersionHeater = value;
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
                _Label24 = value;
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
                _Label25 = value;
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
                _Label26 = value;
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
                _Label27 = value;
            }
        }

        private ComboBox _cboSmokeDrawTest;

        internal ComboBox cboSmokeDrawTest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSmokeDrawTest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSmokeDrawTest = value;
            }
        }

        private ComboBox _cboUsingApprovedFuel;

        internal ComboBox cboUsingApprovedFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUsingApprovedFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboUsingApprovedFuel = value;
            }
        }

        private ComboBox _cboVentilationAirProvision;

        internal ComboBox cboVentilationAirProvision
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVentilationAirProvision;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboVentilationAirProvision = value;
            }
        }

        private ComboBox _cboSmokePressureTest;

        internal ComboBox cboSmokePressureTest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSmokePressureTest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSmokePressureTest = value;
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtFlueDraught = new TextBox();
            _txtNominalOutput = new TextBox();
            _txtVentilationType = new TextBox();
            _cboSafety = new ComboBox();
            _Label18 = new Label();
            _cboExtractorFans = new ComboBox();
            _Label19 = new Label();
            _Label20 = new Label();
            _Label21 = new Label();
            _Label22 = new Label();
            _Label11 = new Label();
            _Label12 = new Label();
            _Label13 = new Label();
            _Label14 = new Label();
            _Label15 = new Label();
            _Label16 = new Label();
            _Label17 = new Label();
            _Label6 = new Label();
            _cboSweptBrush = new ComboBox();
            _Label7 = new Label();
            _cboFlueClear = new ComboBox();
            _Label8 = new Label();
            _cboFireGuardFixingPoint = new ComboBox();
            _Label9 = new Label();
            _cboCorrectHearthSize = new ComboBox();
            _Label10 = new Label();
            _cboChimneySwept = new ComboBox();
            _Label3 = new Label();
            _cboChimneyStructureSound = new ComboBox();
            _Label4 = new Label();
            _cboVisualCondition = new ComboBox();
            _Label5 = new Label();
            _cboTerminationSatisfactory = new ComboBox();
            _Label2 = new Label();
            _cboAppliance = new ComboBox();
            _Label1 = new Label();
            _Label23 = new Label();
            _lblNotTested1 = new Label();
            _lblNotTested2 = new Label();
            _lblNotTested3 = new Label();
            _lblNotTested6 = new Label();
            _lblNotTested5 = new Label();
            _lblNotTested4 = new Label();
            _lblNotTested12 = new Label();
            _lblNotTested11 = new Label();
            _lblNotTested10 = new Label();
            _lblNotTested9 = new Label();
            _lblNotTested8 = new Label();
            _lblNotTested7 = new Label();
            _lblNotTested18 = new Label();
            _lblNotTested17 = new Label();
            _lblNotTested16 = new Label();
            _lblNotTested15 = new Label();
            _lblNotTested14 = new Label();
            _lblNotTested13 = new Label();
            _cboCombustionAir = new ComboBox();
            _cboFluePerformance = new ComboBox();
            _cboSafetyDevice = new ComboBox();
            _cboApplianceServiced = new ComboBox();
            _cboTennantKnow = new ComboBox();
            _cboInstuctions = new ComboBox();
            _cboTypeOfCylinder = new ComboBox();
            _cboImmersionHeater = new ComboBox();
            _Label24 = new Label();
            _Label25 = new Label();
            _Label26 = new Label();
            _Label27 = new Label();
            _cboSmokeDrawTest = new ComboBox();
            _cboUsingApprovedFuel = new ComboBox();
            _cboVentilationAirProvision = new ComboBox();
            _cboSmokePressureTest = new ComboBox();
            SuspendLayout();
            //
            // txtFlueDraught
            //
            _txtFlueDraught.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtFlueDraught.Location = new Point(601, 276);
            _txtFlueDraught.Name = "txtFlueDraught";
            _txtFlueDraught.Size = new Size(188, 21);
            _txtFlueDraught.TabIndex = 10;
            //
            // txtNominalOutput
            //
            _txtNominalOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtNominalOutput.Location = new Point(601, 366);
            _txtNominalOutput.Name = "txtNominalOutput";
            _txtNominalOutput.Size = new Size(188, 21);
            _txtNominalOutput.TabIndex = 11;
            //
            // txtVentilationType
            //
            _txtVentilationType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtVentilationType.Location = new Point(601, 576);
            _txtVentilationType.Name = "txtVentilationType";
            _txtVentilationType.Size = new Size(188, 21);
            _txtVentilationType.TabIndex = 18;
            //
            // cboSafety
            //
            _cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafety.Location = new Point(601, 636);
            _cboSafety.Name = "cboSafety";
            _cboSafety.Size = new Size(188, 21);
            _cboSafety.TabIndex = 20;
            //
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Location = new Point(3, 641);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(134, 13);
            _Label18.TabIndex = 365;
            _Label18.Text = "Appliance Safe To Use";
            //
            // cboExtractorFans
            //
            _cboExtractorFans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboExtractorFans.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExtractorFans.Location = new Point(601, 606);
            _cboExtractorFans.Name = "cboExtractorFans";
            _cboExtractorFans.Size = new Size(188, 21);
            _cboExtractorFans.TabIndex = 19;
            //
            // Label19
            //
            _Label19.AutoSize = true;
            _Label19.Location = new Point(3, 611);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(129, 13);
            _Label19.TabIndex = 363;
            _Label19.Text = "Extractor Fans In Use";
            //
            // Label20
            //
            _Label20.AutoSize = true;
            _Label20.Location = new Point(3, 581);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(97, 13);
            _Label20.TabIndex = 361;
            _Label20.Text = "Ventilation Type";
            //
            // Label21
            //
            _Label21.AutoSize = true;
            _Label21.Location = new Point(3, 552);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(176, 13);
            _Label21.TabIndex = 360;
            _Label21.Text = "Type Of Cylinder At Location?";
            //
            // Label22
            //
            _Label22.AutoSize = true;
            _Label22.Location = new Point(3, 522);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(181, 13);
            _Label22.TabIndex = 359;
            _Label22.Text = "Operating Instruction Present?";
            //
            // Label11
            //
            _Label11.AutoSize = true;
            _Label11.Location = new Point(30, 608);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(32, 13);
            _Label11.TabIndex = 358;
            _Label11.Text = "CO2";
            //
            // Label12
            //
            _Label12.AutoSize = true;
            _Label12.Location = new Point(3, 461);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(164, 13);
            _Label12.TabIndex = 357;
            _Label12.Text = "Immersion Heater Present?";
            //
            // Label13
            //
            _Label13.AutoSize = true;
            _Label13.Location = new Point(3, 431);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(116, 13);
            _Label13.TabIndex = 356;
            _Label13.Text = "Appliance Serviced";
            //
            // Label14
            //
            _Label14.AutoSize = true;
            _Label14.Location = new Point(3, 402);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(204, 13);
            _Label14.TabIndex = 355;
            _Label14.Text = "Safety Device Operating Correctly";
            //
            // Label15
            //
            _Label15.AutoSize = true;
            _Label15.Location = new Point(3, 372);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(95, 13);
            _Label15.TabIndex = 354;
            _Label15.Text = "Nominal Output";
            //
            // Label16
            //
            _Label16.AutoSize = true;
            _Label16.Location = new Point(3, 342);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(212, 13);
            _Label16.TabIndex = 353;
            _Label16.Text = "Flue Performance Tests Satisfactory";
            //
            // Label17
            //
            _Label17.AutoSize = true;
            _Label17.Location = new Point(3, 312);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(223, 13);
            _Label17.TabIndex = 352;
            _Label17.Text = "Combustion Air Provision Satisfactory";
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(3, 281);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(130, 13);
            _Label6.TabIndex = 351;
            _Label6.Text = "Flue Draught Reading";
            //
            // cboSweptBrush
            //
            _cboSweptBrush.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSweptBrush.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSweptBrush.Location = new Point(601, 246);
            _cboSweptBrush.Name = "cboSweptBrush";
            _cboSweptBrush.Size = new Size(188, 21);
            _cboSweptBrush.TabIndex = 9;
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(3, 251);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(232, 13);
            _Label7.TabIndex = 350;
            _Label7.Text = "Swept Brush Visible At Top Of Chimney";
            //
            // cboFlueClear
            //
            _cboFlueClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFlueClear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFlueClear.Location = new Point(601, 216);
            _cboFlueClear.Name = "cboFlueClear";
            _cboFlueClear.Size = new Size(188, 21);
            _cboFlueClear.TabIndex = 8;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(3, 221);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(146, 13);
            _Label8.TabIndex = 348;
            _Label8.Text = "Flue Clear Of Obstuction";
            //
            // cboFireGuardFixingPoint
            //
            _cboFireGuardFixingPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFireGuardFixingPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFireGuardFixingPoint.Location = new Point(601, 187);
            _cboFireGuardFixingPoint.Name = "cboFireGuardFixingPoint";
            _cboFireGuardFixingPoint.Size = new Size(188, 21);
            _cboFireGuardFixingPoint.TabIndex = 7;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(3, 192);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(136, 13);
            _Label9.TabIndex = 346;
            _Label9.Text = "Fire Guard Fixing Point";
            //
            // cboCorrectHearthSize
            //
            _cboCorrectHearthSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCorrectHearthSize.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCorrectHearthSize.Location = new Point(601, 157);
            _cboCorrectHearthSize.Name = "cboCorrectHearthSize";
            _cboCorrectHearthSize.Size = new Size(188, 21);
            _cboCorrectHearthSize.TabIndex = 6;
            //
            // Label10
            //
            _Label10.AutoSize = true;
            _Label10.Location = new Point(3, 162);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(120, 13);
            _Label10.TabIndex = 344;
            _Label10.Text = "Correct Hearth Size";
            //
            // cboChimneySwept
            //
            _cboChimneySwept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboChimneySwept.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboChimneySwept.Location = new Point(601, 127);
            _cboChimneySwept.Name = "cboChimneySwept";
            _cboChimneySwept.Size = new Size(188, 21);
            _cboChimneySwept.TabIndex = 5;
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(3, 132);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(97, 13);
            _Label3.TabIndex = 342;
            _Label3.Text = "Chimney Swept";
            //
            // cboChimneyStructureSound
            //
            _cboChimneyStructureSound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboChimneyStructureSound.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboChimneyStructureSound.Location = new Point(601, 97);
            _cboChimneyStructureSound.Name = "cboChimneyStructureSound";
            _cboChimneyStructureSound.Size = new Size(188, 21);
            _cboChimneyStructureSound.TabIndex = 4;
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(3, 102);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(155, 13);
            _Label4.TabIndex = 340;
            _Label4.Text = "Chimney Structure Sound";
            //
            // cboVisualCondition
            //
            _cboVisualCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboVisualCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisualCondition.Location = new Point(601, 67);
            _cboVisualCondition.Name = "cboVisualCondition";
            _cboVisualCondition.Size = new Size(188, 21);
            _cboVisualCondition.TabIndex = 3;
            //
            // Label5
            //
            _Label5.AutoSize = true;
            _Label5.Location = new Point(3, 72);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(99, 13);
            _Label5.TabIndex = 338;
            _Label5.Text = "Visual Condition";
            //
            // cboTerminationSatisfactory
            //
            _cboTerminationSatisfactory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTerminationSatisfactory.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerminationSatisfactory.Location = new Point(601, 38);
            _cboTerminationSatisfactory.Name = "cboTerminationSatisfactory";
            _cboTerminationSatisfactory.Size = new Size(188, 21);
            _cboTerminationSatisfactory.TabIndex = 2;
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(3, 43);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(146, 13);
            _Label2.TabIndex = 336;
            _Label2.Text = "Termination Satisfactory";
            //
            // cboAppliance
            //
            _cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAppliance.Location = new Point(601, 8);
            _cboAppliance.Name = "cboAppliance";
            _cboAppliance.Size = new Size(188, 21);
            _cboAppliance.TabIndex = 1;
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(3, 13);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(62, 13);
            _Label1.TabIndex = 334;
            _Label1.Text = "Appliance";
            //
            // Label23
            //
            _Label23.AutoSize = true;
            _Label23.Location = new Point(3, 491);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(271, 13);
            _Label23.TabIndex = 378;
            _Label23.Text = "Does the tenant know how to use the system?";
            //
            // lblNotTested1
            //
            _lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested1.AutoSize = true;
            _lblNotTested1.Location = new Point(661, 100);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 379;
            _lblNotTested1.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(661, 130);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 380;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(661, 160);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 381;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested6
            //
            _lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested6.AutoSize = true;
            _lblNotTested6.Location = new Point(661, 250);
            _lblNotTested6.Name = "lblNotTested6";
            _lblNotTested6.Size = new Size(67, 13);
            _lblNotTested6.TabIndex = 384;
            _lblNotTested6.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(661, 220);
            _lblNotTested5.Name = "lblNotTested5";
            _lblNotTested5.Size = new Size(67, 13);
            _lblNotTested5.TabIndex = 383;
            _lblNotTested5.Text = "Not Tested";
            //
            // lblNotTested4
            //
            _lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested4.AutoSize = true;
            _lblNotTested4.Location = new Point(661, 190);
            _lblNotTested4.Name = "lblNotTested4";
            _lblNotTested4.Size = new Size(67, 13);
            _lblNotTested4.TabIndex = 382;
            _lblNotTested4.Text = "Not Tested";
            //
            // lblNotTested12
            //
            _lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested12.AutoSize = true;
            _lblNotTested12.Location = new Point(661, 429);
            _lblNotTested12.Name = "lblNotTested12";
            _lblNotTested12.Size = new Size(67, 13);
            _lblNotTested12.TabIndex = 390;
            _lblNotTested12.Text = "Not Tested";
            //
            // lblNotTested11
            //
            _lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested11.AutoSize = true;
            _lblNotTested11.Location = new Point(661, 399);
            _lblNotTested11.Name = "lblNotTested11";
            _lblNotTested11.Size = new Size(67, 13);
            _lblNotTested11.TabIndex = 389;
            _lblNotTested11.Text = "Not Tested";
            //
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(661, 369);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 388;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested9
            //
            _lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested9.AutoSize = true;
            _lblNotTested9.Location = new Point(661, 339);
            _lblNotTested9.Name = "lblNotTested9";
            _lblNotTested9.Size = new Size(67, 13);
            _lblNotTested9.TabIndex = 387;
            _lblNotTested9.Text = "Not Tested";
            //
            // lblNotTested8
            //
            _lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested8.AutoSize = true;
            _lblNotTested8.Location = new Point(661, 309);
            _lblNotTested8.Name = "lblNotTested8";
            _lblNotTested8.Size = new Size(67, 13);
            _lblNotTested8.TabIndex = 386;
            _lblNotTested8.Text = "Not Tested";
            //
            // lblNotTested7
            //
            _lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested7.AutoSize = true;
            _lblNotTested7.Location = new Point(661, 279);
            _lblNotTested7.Name = "lblNotTested7";
            _lblNotTested7.Size = new Size(67, 13);
            _lblNotTested7.TabIndex = 385;
            _lblNotTested7.Text = "Not Tested";
            //
            // lblNotTested18
            //
            _lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested18.AutoSize = true;
            _lblNotTested18.Location = new Point(661, 609);
            _lblNotTested18.Name = "lblNotTested18";
            _lblNotTested18.Size = new Size(67, 13);
            _lblNotTested18.TabIndex = 396;
            _lblNotTested18.Text = "Not Tested";
            //
            // lblNotTested17
            //
            _lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested17.AutoSize = true;
            _lblNotTested17.Location = new Point(661, 579);
            _lblNotTested17.Name = "lblNotTested17";
            _lblNotTested17.Size = new Size(67, 13);
            _lblNotTested17.TabIndex = 395;
            _lblNotTested17.Text = "Not Tested";
            //
            // lblNotTested16
            //
            _lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested16.AutoSize = true;
            _lblNotTested16.Location = new Point(661, 549);
            _lblNotTested16.Name = "lblNotTested16";
            _lblNotTested16.Size = new Size(67, 13);
            _lblNotTested16.TabIndex = 394;
            _lblNotTested16.Text = "Not Tested";
            //
            // lblNotTested15
            //
            _lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested15.AutoSize = true;
            _lblNotTested15.Location = new Point(661, 519);
            _lblNotTested15.Name = "lblNotTested15";
            _lblNotTested15.Size = new Size(67, 13);
            _lblNotTested15.TabIndex = 393;
            _lblNotTested15.Text = "Not Tested";
            //
            // lblNotTested14
            //
            _lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested14.AutoSize = true;
            _lblNotTested14.Location = new Point(661, 489);
            _lblNotTested14.Name = "lblNotTested14";
            _lblNotTested14.Size = new Size(67, 13);
            _lblNotTested14.TabIndex = 392;
            _lblNotTested14.Text = "Not Tested";
            //
            // lblNotTested13
            //
            _lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested13.AutoSize = true;
            _lblNotTested13.Location = new Point(661, 459);
            _lblNotTested13.Name = "lblNotTested13";
            _lblNotTested13.Size = new Size(67, 13);
            _lblNotTested13.TabIndex = 391;
            _lblNotTested13.Text = "Not Tested";
            //
            // cboCombustionAir
            //
            _cboCombustionAir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCombustionAir.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCombustionAir.Location = new Point(601, 306);
            _cboCombustionAir.Name = "cboCombustionAir";
            _cboCombustionAir.Size = new Size(188, 21);
            _cboCombustionAir.TabIndex = 397;
            //
            // cboFluePerformance
            //
            _cboFluePerformance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFluePerformance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFluePerformance.Location = new Point(601, 336);
            _cboFluePerformance.Name = "cboFluePerformance";
            _cboFluePerformance.Size = new Size(188, 21);
            _cboFluePerformance.TabIndex = 398;
            //
            // cboSafetyDevice
            //
            _cboSafetyDevice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafetyDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafetyDevice.ItemHeight = 13;
            _cboSafetyDevice.Location = new Point(601, 397);
            _cboSafetyDevice.Name = "cboSafetyDevice";
            _cboSafetyDevice.Size = new Size(188, 21);
            _cboSafetyDevice.TabIndex = 12;
            //
            // cboApplianceServiced
            //
            _cboApplianceServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboApplianceServiced.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboApplianceServiced.Location = new Point(601, 426);
            _cboApplianceServiced.Name = "cboApplianceServiced";
            _cboApplianceServiced.Size = new Size(188, 21);
            _cboApplianceServiced.TabIndex = 13;
            //
            // cboTennantKnow
            //
            _cboTennantKnow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTennantKnow.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTennantKnow.Location = new Point(601, 486);
            _cboTennantKnow.Name = "cboTennantKnow";
            _cboTennantKnow.Size = new Size(188, 21);
            _cboTennantKnow.TabIndex = 15;
            //
            // cboInstuctions
            //
            _cboInstuctions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboInstuctions.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInstuctions.Location = new Point(601, 517);
            _cboInstuctions.Name = "cboInstuctions";
            _cboInstuctions.Size = new Size(188, 21);
            _cboInstuctions.TabIndex = 16;
            //
            // cboTypeOfCylinder
            //
            _cboTypeOfCylinder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTypeOfCylinder.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTypeOfCylinder.Location = new Point(601, 547);
            _cboTypeOfCylinder.Name = "cboTypeOfCylinder";
            _cboTypeOfCylinder.Size = new Size(188, 21);
            _cboTypeOfCylinder.TabIndex = 17;
            //
            // cboImmersionHeater
            //
            _cboImmersionHeater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboImmersionHeater.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboImmersionHeater.Location = new Point(601, 456);
            _cboImmersionHeater.Name = "cboImmersionHeater";
            _cboImmersionHeater.Size = new Size(188, 21);
            _cboImmersionHeater.TabIndex = 14;
            //
            // Label24
            //
            _Label24.AutoSize = true;
            _Label24.Location = new Point(3, 760);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(130, 13);
            _Label24.TabIndex = 409;
            _Label24.Text = "Using Approved Fuel?";
            //
            // Label25
            //
            _Label25.AutoSize = true;
            _Label25.Location = new Point(3, 730);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(214, 13);
            _Label25.TabIndex = 408;
            _Label25.Text = "Ventilation Air Provision Satisfactory";
            //
            // Label26
            //
            _Label26.AutoSize = true;
            _Label26.Location = new Point(3, 700);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(128, 13);
            _Label26.TabIndex = 407;
            _Label26.Text = "Smoke Pressure Test";
            //
            // Label27
            //
            _Label27.AutoSize = true;
            _Label27.Location = new Point(3, 671);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(112, 13);
            _Label27.TabIndex = 406;
            _Label27.Text = "Smoke Draw Test ";
            //
            // cboSmokeDrawTest
            //
            _cboSmokeDrawTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSmokeDrawTest.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSmokeDrawTest.Location = new Point(601, 666);
            _cboSmokeDrawTest.Name = "cboSmokeDrawTest";
            _cboSmokeDrawTest.Size = new Size(188, 21);
            _cboSmokeDrawTest.TabIndex = 21;
            //
            // cboUsingApprovedFuel
            //
            _cboUsingApprovedFuel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboUsingApprovedFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUsingApprovedFuel.Location = new Point(601, 757);
            _cboUsingApprovedFuel.Name = "cboUsingApprovedFuel";
            _cboUsingApprovedFuel.Size = new Size(188, 21);
            _cboUsingApprovedFuel.TabIndex = 24;
            //
            // cboVentilationAirProvision
            //
            _cboVentilationAirProvision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboVentilationAirProvision.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVentilationAirProvision.Location = new Point(601, 727);
            _cboVentilationAirProvision.Name = "cboVentilationAirProvision";
            _cboVentilationAirProvision.Size = new Size(188, 21);
            _cboVentilationAirProvision.TabIndex = 23;
            //
            // cboSmokePressureTest
            //
            _cboSmokePressureTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSmokePressureTest.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSmokePressureTest.Location = new Point(601, 696);
            _cboSmokePressureTest.Name = "cboSmokePressureTest";
            _cboSmokePressureTest.Size = new Size(188, 21);
            _cboSmokePressureTest.TabIndex = 22;
            //
            // UCSolidWorksheet
            //
            Controls.Add(_cboSmokeDrawTest);
            Controls.Add(_cboUsingApprovedFuel);
            Controls.Add(_cboVentilationAirProvision);
            Controls.Add(_cboSmokePressureTest);
            Controls.Add(_Label24);
            Controls.Add(_Label25);
            Controls.Add(_Label26);
            Controls.Add(_Label27);
            Controls.Add(_cboImmersionHeater);
            Controls.Add(_cboTypeOfCylinder);
            Controls.Add(_cboInstuctions);
            Controls.Add(_cboTennantKnow);
            Controls.Add(_cboApplianceServiced);
            Controls.Add(_cboSafetyDevice);
            Controls.Add(_cboFluePerformance);
            Controls.Add(_cboCombustionAir);
            Controls.Add(_Label23);
            Controls.Add(_txtFlueDraught);
            Controls.Add(_txtNominalOutput);
            Controls.Add(_txtVentilationType);
            Controls.Add(_cboSafety);
            Controls.Add(_Label18);
            Controls.Add(_cboExtractorFans);
            Controls.Add(_Label19);
            Controls.Add(_Label20);
            Controls.Add(_Label21);
            Controls.Add(_Label22);
            Controls.Add(_Label11);
            Controls.Add(_Label12);
            Controls.Add(_Label13);
            Controls.Add(_Label14);
            Controls.Add(_Label15);
            Controls.Add(_Label16);
            Controls.Add(_Label17);
            Controls.Add(_Label6);
            Controls.Add(_cboSweptBrush);
            Controls.Add(_Label7);
            Controls.Add(_cboFlueClear);
            Controls.Add(_Label8);
            Controls.Add(_cboFireGuardFixingPoint);
            Controls.Add(_Label9);
            Controls.Add(_cboCorrectHearthSize);
            Controls.Add(_Label10);
            Controls.Add(_cboChimneySwept);
            Controls.Add(_Label3);
            Controls.Add(_cboChimneyStructureSound);
            Controls.Add(_Label4);
            Controls.Add(_cboVisualCondition);
            Controls.Add(_Label5);
            Controls.Add(_cboTerminationSatisfactory);
            Controls.Add(_Label2);
            Controls.Add(_cboAppliance);
            Controls.Add(_Label1);
            Controls.Add(_lblNotTested18);
            Controls.Add(_lblNotTested17);
            Controls.Add(_lblNotTested16);
            Controls.Add(_lblNotTested15);
            Controls.Add(_lblNotTested14);
            Controls.Add(_lblNotTested13);
            Controls.Add(_lblNotTested12);
            Controls.Add(_lblNotTested11);
            Controls.Add(_lblNotTested10);
            Controls.Add(_lblNotTested9);
            Controls.Add(_lblNotTested8);
            Controls.Add(_lblNotTested7);
            Controls.Add(_lblNotTested6);
            Controls.Add(_lblNotTested5);
            Controls.Add(_lblNotTested4);
            Controls.Add(_lblNotTested3);
            Controls.Add(_lblNotTested2);
            Controls.Add(_lblNotTested1);
            Name = "UCSolidWorksheet";
            Size = new Size(789, 795);
            ResumeLayout(false);
            PerformLayout();
        }

        
        
        private DataTable DtYesNo = null;
        private DataTable DtPassFail = null;
        private DataTable DtPassFailNA = null;
        private EngineerVisitAssetWorkSheet _Worksheet;

        public EngineerVisitAssetWorkSheet Worksheet
        {
            get
            {
                return _Worksheet;
            }

            set
            {
                _Worksheet = value;
            }
        }

        private EngineerVisit _EngineerVisit;

        public EngineerVisit EngineerVisit
        {
            get
            {
                return _EngineerVisit;
            }

            set
            {
                _EngineerVisit = value;
            }
        }

        private int _jobID;

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public int JobID
        {
            get
            {
                return _jobID;
            }

            set
            {
                _jobID = value;
            }
        }

        public object LoadedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public void SetUpCombos()
        {
            var argc = cboAppliance;
            Combo.SetUpCombo(ref argc, App.DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
            var argc1 = cboCorrectHearthSize;
            Combo.SetUpCombo(ref argc1, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = cboFireGuardFixingPoint;
            Combo.SetUpCombo(ref argc2, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboChimneyStructureSound;
            Combo.SetUpCombo(ref argc3, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboChimneySwept;
            Combo.SetUpCombo(ref argc4, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboFlueClear;
            Combo.SetUpCombo(ref argc5, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboSweptBrush;
            Combo.SetUpCombo(ref argc6, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboTerminationSatisfactory;
            Combo.SetUpCombo(ref argc7, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboVisualCondition;
            Combo.SetUpCombo(ref argc8, DtPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboExtractorFans;
            Combo.SetUpCombo(ref argc9, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboSmokeDrawTest;
            Combo.SetUpCombo(ref argc10, DtPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc11 = cboSmokePressureTest;
            Combo.SetUpCombo(ref argc11, DtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc12 = cboVentilationAirProvision;
            Combo.SetUpCombo(ref argc12, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc13 = cboCombustionAir;
            Combo.SetUpCombo(ref argc13, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc14 = cboFluePerformance;
            Combo.SetUpCombo(ref argc14, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc15 = cboSafetyDevice;
            Combo.SetUpCombo(ref argc15, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc16 = cboApplianceServiced;
            Combo.SetUpCombo(ref argc16, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc17 = cboSafety;
            Combo.SetUpCombo(ref argc17, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc18 = cboTennantKnow;
            Combo.SetUpCombo(ref argc18, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc19 = cboInstuctions;
            Combo.SetUpCombo(ref argc19, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc20 = cboTypeOfCylinder;
            Combo.SetUpCombo(ref argc20, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc21 = cboImmersionHeater;
            Combo.SetUpCombo(ref argc21, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc22 = cboUsingApprovedFuel;
            Combo.SetUpCombo(ref argc22, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
        }

        public void Populate(int ID = 0)
        {
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboTerminationSatisfactory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.LandlordsApplianceID.ToString());
            var argcombo2 = cboVisualCondition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.ApplianceTestedID.ToString());
            var argcombo3 = cboChimneySwept;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.SpillageTestID.ToString());
            var argcombo4 = cboCorrectHearthSize;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo5 = cboFireGuardFixingPoint;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo6 = cboChimneyStructureSound;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.FlueFlowTestID.ToString());
            var argcombo7 = cboFlueClear;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo8 = cboSweptBrush;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.SafetyDeviceOperationID.ToString());
            txtFlueDraught.Text = Worksheet.DHWFlowRate.ToString();
            var argcombo9 = cboCombustionAir;
            Combo.SetSelectedComboItem_By_Value(ref argcombo9, Worksheet.ColdWaterTemp.ToString());
            var argcombo10 = cboFluePerformance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo10, Worksheet.DHWTemp.ToString());
            txtNominalOutput.Text = Worksheet.InletStaticPressure.ToString();
            var argcombo11 = cboSafetyDevice;
            Combo.SetSelectedComboItem_By_Value(ref argcombo11, Worksheet.InletWorkingPressure.ToString());
            var argcombo12 = cboApplianceServiced;
            Combo.SetSelectedComboItem_By_Value(ref argcombo12, Worksheet.MinBurnerPressure.ToString());
            var argcombo13 = cboImmersionHeater;
            Combo.SetSelectedComboItem_By_Value(ref argcombo13, Worksheet.Nozzle);
            var argcombo14 = cboTennantKnow;
            Combo.SetSelectedComboItem_By_Value(ref argcombo14, Worksheet.CO2.ToString());
            var argcombo15 = cboInstuctions;
            Combo.SetSelectedComboItem_By_Value(ref argcombo15, Worksheet.CO2CORatio.ToString());
            var argcombo16 = cboTypeOfCylinder;
            Combo.SetSelectedComboItem_By_Value(ref argcombo16, Worksheet.BMake);
            txtVentilationType.Text = Worksheet.BModel;
            var argcombo17 = cboExtractorFans;
            Combo.SetSelectedComboItem_By_Value(ref argcombo17, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo18 = cboSafety;
            Combo.SetSelectedComboItem_By_Value(ref argcombo18, Worksheet.ApplianceSafeID.ToString());
            var argcombo19 = cboSmokeDrawTest;
            Combo.SetSelectedComboItem_By_Value(ref argcombo19, Worksheet.DischargeID.ToString());
            var argcombo20 = cboSmokePressureTest;
            Combo.SetSelectedComboItem_By_Value(ref argcombo20, Worksheet.SweepOutcomeID.ToString());
            var argcombo21 = cboVentilationAirProvision;
            Combo.SetSelectedComboItem_By_Value(ref argcombo21, Worksheet.OverallID.ToString());
            var argcombo22 = cboUsingApprovedFuel;
            Combo.SetSelectedComboItem_By_Value(ref argcombo22, Worksheet.TankID.ToString());
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.SolidFuel);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                Worksheet.SetInletStaticPressure = txtNominalOutput.Text;
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboCorrectHearthSize);
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboFireGuardFixingPoint);
                Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboChimneyStructureSound);
                Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboChimneySwept);
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboFlueClear);
                Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboSweptBrush);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboTerminationSatisfactory);
                Worksheet.SetApplianceTestedID = Combo.get_GetSelectedItemValue(cboVisualCondition);
                Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboExtractorFans);
                Worksheet.SetDischargeID = Combo.get_GetSelectedItemValue(cboSmokeDrawTest);
                Worksheet.SetSweepOutcomeID = Combo.get_GetSelectedItemValue(cboSmokePressureTest);
                Worksheet.SetDHWFlowRate = txtFlueDraught.Text;
                Worksheet.SetBModel = txtVentilationType.Text;
                Worksheet.SetOverallID = Combo.get_GetSelectedItemValue(cboVentilationAirProvision);
                Worksheet.SetColdWaterTemp = Combo.get_GetSelectedItemValue(cboCombustionAir);
                Worksheet.SetDHWTemp = Combo.get_GetSelectedItemValue(cboFluePerformance);
                Worksheet.SetInletWorkingPressure = Combo.get_GetSelectedItemValue(cboSafetyDevice);
                Worksheet.SetMinBurnerPressure = Combo.get_GetSelectedItemValue(cboApplianceServiced);
                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetCO2 = Combo.get_GetSelectedItemValue(cboTennantKnow);
                Worksheet.SetCO2CORatio = Combo.get_GetSelectedItemValue(cboInstuctions);
                Worksheet.SetBMake = Combo.get_GetSelectedItemValue(cboTypeOfCylinder);
                Worksheet.SetNozzle = Combo.get_GetSelectedItemValue(cboImmersionHeater);
                Worksheet.SetTankID = Combo.get_GetSelectedItemValue(cboUsingApprovedFuel);
                var dValidator = new EngineerVisitAssetWorkSheetValidatorSolid();
                dValidator.Validate(Worksheet);
                if (Worksheet?.EngineerVisitAssetWorkSheetID > 0 == true)
                {
                    App.DB.EngineerVisitAssetWorkSheet.Update(Worksheet);
                }
                else
                {
                    App.DB.EngineerVisitAssetWorkSheet.Insert(Worksheet);
                }

                if (Worksheet.LandlordsApplianceID == (int)Enums.YesNoNA.No)
                {
                    var oAsset = App.DB.Asset.Asset_Get(Worksheet.AssetID);
                    oAsset.SetTenantsAppliance = true;
                    App.DB.Asset.Update(oAsset);
                }
                else
                {
                    var oAsset = App.DB.Asset.Asset_Get(Worksheet.AssetID);
                    oAsset.SetTenantsAppliance = false;
                    App.DB.Asset.Update(oAsset);
                }

                App.ShowMessage("Your worksheet has been saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return default;
        }
    }
}