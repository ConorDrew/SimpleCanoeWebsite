using FSM.Entity.EngineerVisitAssetWorkSheets;
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
    public class UCComercialWorksheet : UCBase, IUserControl
    {
        public UCComercialWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
            DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA).Table;
            DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced).Table;
            DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table;
            DtYesNoNa = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table;
            DtPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail).Table;
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

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private TextBox _txtMaxCO;

        internal TextBox txtMaxCO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMaxCO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMaxCO != null)
                {
                }

                _txtMaxCO = value;
                if (_txtMaxCO != null)
                {
                }
            }
        }

        private TextBox _txtMaxCO2;

        internal TextBox txtMaxCO2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMaxCO2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMaxCO2 != null)
                {
                }

                _txtMaxCO2 = value;
                if (_txtMaxCO2 != null)
                {
                }
            }
        }

        private TextBox _txtHeatInput;

        internal TextBox txtHeatInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHeatInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHeatInput != null)
                {
                }

                _txtHeatInput = value;
                if (_txtHeatInput != null)
                {
                }
            }
        }

        private TextBox _txtOperatingPressure;

        internal TextBox txtOperatingPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOperatingPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOperatingPressure != null)
                {
                }

                _txtOperatingPressure = value;
                if (_txtOperatingPressure != null)
                {
                }
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
                if (_cboSafety != null)
                {
                }

                _cboSafety = value;
                if (_cboSafety != null)
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

        private ComboBox _cboServiced;

        internal ComboBox cboServiced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboServiced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboServiced != null)
                {
                }

                _cboServiced = value;
                if (_cboServiced != null)
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

        private ComboBox _cboGastight;

        internal ComboBox cboGastight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGastight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboGastight != null)
                {
                }

                _cboGastight = value;
                if (_cboGastight != null)
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

        private ComboBox _cboFSPFitted;

        internal ComboBox cboFSPFitted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFSPFitted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFSPFitted != null)
                {
                }

                _cboFSPFitted = value;
                if (_cboFSPFitted != null)
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

        private ComboBox _cboGasIsolation;

        internal ComboBox cboGasIsolation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGasIsolation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboGasIsolation != null)
                {
                }

                _cboGasIsolation = value;
                if (_cboGasIsolation != null)
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

        private ComboBox _cboManufactureInfo;

        internal ComboBox cboManufactureInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboManufactureInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboManufactureInfo != null)
                {
                }

                _cboManufactureInfo = value;
                if (_cboManufactureInfo != null)
                {
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

        private ComboBox _cboElectricalIsolator;

        internal ComboBox cboElectricalIsolator
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboElectricalIsolator;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboElectricalIsolator != null)
                {
                }

                _cboElectricalIsolator = value;
                if (_cboElectricalIsolator != null)
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

        private ComboBox _cboGasHose;

        internal ComboBox cboGasHose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGasHose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboGasHose != null)
                {
                }

                _cboGasHose = value;
                if (_cboGasHose != null)
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

        private ComboBox _cboTested;

        internal ComboBox cboTested
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTested;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTested != null)
                {
                    _cboTested.SelectionChangeCommitted -= cboTested_SelectionChangeCommitted;
                }

                _cboTested = value;
                if (_cboTested != null)
                {
                    _cboTested.SelectionChangeCommitted += cboTested_SelectionChangeCommitted;
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

        private ComboBox _cboLLAppliance;

        internal ComboBox cboLLAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLLAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLLAppliance != null)
                {
                }

                _cboLLAppliance = value;
                if (_cboLLAppliance != null)
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
                if (_cboAppliance != null)
                {
                }

                _cboAppliance = value;
                if (_cboAppliance != null)
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
                if (_lblNotTested1 != null)
                {
                }

                _lblNotTested1 = value;
                if (_lblNotTested1 != null)
                {
                }
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
                if (_lblNotTested2 != null)
                {
                }

                _lblNotTested2 = value;
                if (_lblNotTested2 != null)
                {
                }
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
                if (_lblNotTested3 != null)
                {
                }

                _lblNotTested3 = value;
                if (_lblNotTested3 != null)
                {
                }
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
                if (_lblNotTested6 != null)
                {
                }

                _lblNotTested6 = value;
                if (_lblNotTested6 != null)
                {
                }
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
                if (_lblNotTested5 != null)
                {
                }

                _lblNotTested5 = value;
                if (_lblNotTested5 != null)
                {
                }
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
                if (_lblNotTested4 != null)
                {
                }

                _lblNotTested4 = value;
                if (_lblNotTested4 != null)
                {
                }
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
                if (_lblNotTested10 != null)
                {
                }

                _lblNotTested10 = value;
                if (_lblNotTested10 != null)
                {
                }
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
                if (_lblNotTested9 != null)
                {
                }

                _lblNotTested9 = value;
                if (_lblNotTested9 != null)
                {
                }
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
                if (_lblNotTested8 != null)
                {
                }

                _lblNotTested8 = value;
                if (_lblNotTested8 != null)
                {
                }
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
                if (_lblNotTested7 != null)
                {
                }

                _lblNotTested7 = value;
                if (_lblNotTested7 != null)
                {
                }
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
                if (_lblNotTested18 != null)
                {
                }

                _lblNotTested18 = value;
                if (_lblNotTested18 != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtMaxCO = new TextBox();
            _txtMaxCO2 = new TextBox();
            _txtHeatInput = new TextBox();
            _txtOperatingPressure = new TextBox();
            _cboSafety = new ComboBox();
            _Label18 = new Label();
            _cboServiced = new ComboBox();
            _Label19 = new Label();
            _Label15 = new Label();
            _Label16 = new Label();
            _Label17 = new Label();
            _Label6 = new Label();
            _cboGastight = new ComboBox();
            _Label7 = new Label();
            _cboFSPFitted = new ComboBox();
            _Label8 = new Label();
            _cboGasIsolation = new ComboBox();
            _Label9 = new Label();
            _cboManufactureInfo = new ComboBox();
            _Label10 = new Label();
            _cboElectricalIsolator = new ComboBox();
            _Label3 = new Label();
            _cboGasHose = new ComboBox();
            _Label4 = new Label();
            _cboTested = new ComboBox();
            _cboTested.SelectionChangeCommitted += new EventHandler(cboTested_SelectionChangeCommitted);
            _Label5 = new Label();
            _cboLLAppliance = new ComboBox();
            _Label2 = new Label();
            _cboAppliance = new ComboBox();
            _Label1 = new Label();
            _lblNotTested1 = new Label();
            _lblNotTested2 = new Label();
            _lblNotTested3 = new Label();
            _lblNotTested6 = new Label();
            _lblNotTested5 = new Label();
            _lblNotTested4 = new Label();
            _lblNotTested10 = new Label();
            _lblNotTested9 = new Label();
            _lblNotTested8 = new Label();
            _lblNotTested7 = new Label();
            _lblNotTested18 = new Label();
            SuspendLayout();
            //
            // txtMaxCO
            //
            _txtMaxCO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtMaxCO.Location = new Point(601, 278);
            _txtMaxCO.Name = "txtMaxCO";
            _txtMaxCO.Size = new Size(188, 21);
            _txtMaxCO.TabIndex = 10;
            //
            // txtMaxCO2
            //
            _txtMaxCO2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtMaxCO2.Location = new Point(601, 309);
            _txtMaxCO2.Name = "txtMaxCO2";
            _txtMaxCO2.Size = new Size(188, 21);
            _txtMaxCO2.TabIndex = 11;
            //
            // txtHeatInput
            //
            _txtHeatInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtHeatInput.Location = new Point(601, 339);
            _txtHeatInput.Name = "txtHeatInput";
            _txtHeatInput.Size = new Size(188, 21);
            _txtHeatInput.TabIndex = 12;
            //
            // txtOperatingPressure
            //
            _txtOperatingPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtOperatingPressure.Location = new Point(601, 368);
            _txtOperatingPressure.Name = "txtOperatingPressure";
            _txtOperatingPressure.Size = new Size(188, 21);
            _txtOperatingPressure.TabIndex = 13;
            //
            // cboSafety
            //
            _cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafety.Location = new Point(601, 428);
            _cboSafety.Name = "cboSafety";
            _cboSafety.Size = new Size(188, 21);
            _cboSafety.TabIndex = 22;
            //
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Location = new Point(3, 431);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(101, 13);
            _Label18.TabIndex = 365;
            _Label18.Text = "Appliance safety";
            //
            // cboServiced
            //
            _cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboServiced.Location = new Point(601, 398);
            _cboServiced.Name = "cboServiced";
            _cboServiced.Size = new Size(188, 21);
            _cboServiced.TabIndex = 21;
            //
            // Label19
            //
            _Label19.AutoSize = true;
            _Label19.Location = new Point(3, 401);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(181, 13);
            _Label19.TabIndex = 363;
            _Label19.Text = "Appliance service or inspected";
            //
            // Label15
            //
            _Label15.AutoSize = true;
            _Label15.Location = new Point(3, 372);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(161, 13);
            _Label15.TabIndex = 354;
            _Label15.Text = "Operating pressure (mbar)";
            //
            // Label16
            //
            _Label16.AutoSize = true;
            _Label16.Location = new Point(3, 342);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(98, 13);
            _Label16.TabIndex = 353;
            _Label16.Text = "Heat input (KW)";
            //
            // Label17
            //
            _Label17.AutoSize = true;
            _Label17.Location = new Point(3, 312);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(209, 13);
            _Label17.TabIndex = 352;
            _Label17.Text = "Max CO2 reading around Appliance";
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(3, 281);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(202, 13);
            _Label6.TabIndex = 351;
            _Label6.Text = "Max CO reading around Appliance";
            //
            // cboGastight
            //
            _cboGastight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboGastight.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGastight.Location = new Point(601, 248);
            _cboGastight.Name = "cboGastight";
            _cboGastight.Size = new Size(188, 21);
            _cboGastight.TabIndex = 9;
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(3, 251);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(108, 13);
            _Label7.TabIndex = 350;
            _Label7.Text = "Pipework gastight";
            //
            // cboFSPFitted
            //
            _cboFSPFitted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFSPFitted.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFSPFitted.Location = new Point(601, 218);
            _cboFSPFitted.Name = "cboFSPFitted";
            _cboFSPFitted.Size = new Size(188, 21);
            _cboFSPFitted.TabIndex = 8;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(3, 221);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(141, 13);
            _Label8.TabIndex = 348;
            _Label8.Text = "FSP fitted to all burners";
            //
            // cboGasIsolation
            //
            _cboGasIsolation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboGasIsolation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGasIsolation.Location = new Point(601, 189);
            _cboGasIsolation.Name = "cboGasIsolation";
            _cboGasIsolation.Size = new Size(188, 21);
            _cboGasIsolation.TabIndex = 7;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(3, 192);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(148, 13);
            _Label9.TabIndex = 346;
            _Label9.Text = "Gas isolation value fitted";
            //
            // cboManufactureInfo
            //
            _cboManufactureInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboManufactureInfo.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboManufactureInfo.Location = new Point(601, 159);
            _cboManufactureInfo.Name = "cboManufactureInfo";
            _cboManufactureInfo.Size = new Size(188, 21);
            _cboManufactureInfo.TabIndex = 6;
            //
            // Label10
            //
            _Label10.AutoSize = true;
            _Label10.Location = new Point(3, 162);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(208, 13);
            _Label10.TabIndex = 344;
            _Label10.Text = "Manufactures inforamtion Available";
            //
            // cboElectricalIsolator
            //
            _cboElectricalIsolator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboElectricalIsolator.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboElectricalIsolator.Location = new Point(601, 129);
            _cboElectricalIsolator.Name = "cboElectricalIsolator";
            _cboElectricalIsolator.Size = new Size(188, 21);
            _cboElectricalIsolator.TabIndex = 5;
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(3, 132);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(251, 13);
            _Label3.TabIndex = 342;
            _Label3.Text = "Electrical isolator fitten and correctly fused";
            //
            // cboGasHose
            //
            _cboGasHose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboGasHose.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGasHose.Location = new Point(601, 99);
            _cboGasHose.Name = "cboGasHose";
            _cboGasHose.Size = new Size(188, 21);
            _cboGasHose.TabIndex = 4;
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(3, 102);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(276, 13);
            _Label4.TabIndex = 340;
            _Label4.Text = "Gas hose and required restraint fitted correctly";
            //
            // cboTested
            //
            _cboTested.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTested.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTested.Location = new Point(601, 69);
            _cboTested.Name = "cboTested";
            _cboTested.Size = new Size(188, 21);
            _cboTested.TabIndex = 3;
            //
            // Label5
            //
            _Label5.AutoSize = true;
            _Label5.Location = new Point(3, 72);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(101, 13);
            _Label5.TabIndex = 338;
            _Label5.Text = "Appliance tested";
            //
            // cboLLAppliance
            //
            _cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLLAppliance.Location = new Point(601, 40);
            _cboLLAppliance.Name = "cboLLAppliance";
            _cboLLAppliance.Size = new Size(188, 21);
            _cboLLAppliance.TabIndex = 2;
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(3, 43);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(125, 13);
            _Label2.TabIndex = 336;
            _Label2.Text = "Landlords Appliance ";
            //
            // cboAppliance
            //
            _cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAppliance.Location = new Point(601, 10);
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
            // lblNotTested1
            //
            _lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested1.AutoSize = true;
            _lblNotTested1.Location = new Point(661, 102);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 379;
            _lblNotTested1.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(661, 132);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 380;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(661, 162);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 381;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested6
            //
            _lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested6.AutoSize = true;
            _lblNotTested6.Location = new Point(661, 252);
            _lblNotTested6.Name = "lblNotTested6";
            _lblNotTested6.Size = new Size(67, 13);
            _lblNotTested6.TabIndex = 384;
            _lblNotTested6.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(661, 222);
            _lblNotTested5.Name = "lblNotTested5";
            _lblNotTested5.Size = new Size(67, 13);
            _lblNotTested5.TabIndex = 383;
            _lblNotTested5.Text = "Not Tested";
            //
            // lblNotTested4
            //
            _lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested4.AutoSize = true;
            _lblNotTested4.Location = new Point(661, 192);
            _lblNotTested4.Name = "lblNotTested4";
            _lblNotTested4.Size = new Size(67, 13);
            _lblNotTested4.TabIndex = 382;
            _lblNotTested4.Text = "Not Tested";
            //
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(661, 371);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 388;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested9
            //
            _lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested9.AutoSize = true;
            _lblNotTested9.Location = new Point(661, 341);
            _lblNotTested9.Name = "lblNotTested9";
            _lblNotTested9.Size = new Size(67, 13);
            _lblNotTested9.TabIndex = 387;
            _lblNotTested9.Text = "Not Tested";
            //
            // lblNotTested8
            //
            _lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested8.AutoSize = true;
            _lblNotTested8.Location = new Point(661, 311);
            _lblNotTested8.Name = "lblNotTested8";
            _lblNotTested8.Size = new Size(67, 13);
            _lblNotTested8.TabIndex = 386;
            _lblNotTested8.Text = "Not Tested";
            //
            // lblNotTested7
            //
            _lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested7.AutoSize = true;
            _lblNotTested7.Location = new Point(661, 281);
            _lblNotTested7.Name = "lblNotTested7";
            _lblNotTested7.Size = new Size(67, 13);
            _lblNotTested7.TabIndex = 385;
            _lblNotTested7.Text = "Not Tested";
            //
            // lblNotTested18
            //
            _lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested18.AutoSize = true;
            _lblNotTested18.Location = new Point(661, 401);
            _lblNotTested18.Name = "lblNotTested18";
            _lblNotTested18.Size = new Size(67, 13);
            _lblNotTested18.TabIndex = 396;
            _lblNotTested18.Text = "Not Tested";
            //
            // UCComercialWorksheet
            //
            Controls.Add(_txtMaxCO);
            Controls.Add(_txtMaxCO2);
            Controls.Add(_txtHeatInput);
            Controls.Add(_txtOperatingPressure);
            Controls.Add(_cboSafety);
            Controls.Add(_Label18);
            Controls.Add(_cboServiced);
            Controls.Add(_Label19);
            Controls.Add(_Label15);
            Controls.Add(_Label16);
            Controls.Add(_Label17);
            Controls.Add(_Label6);
            Controls.Add(_cboGastight);
            Controls.Add(_Label7);
            Controls.Add(_cboFSPFitted);
            Controls.Add(_Label8);
            Controls.Add(_cboGasIsolation);
            Controls.Add(_Label9);
            Controls.Add(_cboManufactureInfo);
            Controls.Add(_Label10);
            Controls.Add(_cboElectricalIsolator);
            Controls.Add(_Label3);
            Controls.Add(_cboGasHose);
            Controls.Add(_Label4);
            Controls.Add(_cboTested);
            Controls.Add(_Label5);
            Controls.Add(_cboLLAppliance);
            Controls.Add(_Label2);
            Controls.Add(_cboAppliance);
            Controls.Add(_Label1);
            Controls.Add(_lblNotTested18);
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
            Name = "UCComercialWorksheet";
            Size = new Size(789, 462);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable DtPassFailNa = null;
        private DataTable DtNotTestedPassFail = null;
        private DataTable DtApplianceServiced = null;
        private DataTable DtYesNo = null;
        private DataTable DtYesNoNa = null;
        private DataTable DtPassFail = null;
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

        private Entity.EngineerVisits.EngineerVisit _EngineerVisit;

        public Entity.EngineerVisits.EngineerVisit EngineerVisit
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public void SetUpCombos()
        {
            var argc = cboLLAppliance;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.LLTenPriv).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboAppliance;
            Combo.SetUpCombo(ref argc1, App.DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
            var argc2 = cboTested;
            Combo.SetUpCombo(ref argc2, DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboGasHose;
            Combo.SetUpCombo(ref argc3, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboElectricalIsolator;
            Combo.SetUpCombo(ref argc4, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboManufactureInfo;
            Combo.SetUpCombo(ref argc5, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboGasIsolation;
            Combo.SetUpCombo(ref argc6, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboFSPFitted;
            Combo.SetUpCombo(ref argc7, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboGastight;
            Combo.SetUpCombo(ref argc8, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboServiced;
            Combo.SetUpCombo(ref argc9, DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboSafety;
            Combo.SetUpCombo(ref argc10, DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboSafety.Items.Add(new Combo("Visually Passed", "999999999"));
        }

        public void Populate(int ID = 0)
        {
            txtMaxCO.Text = Worksheet.DHWFlowRate.ToString();
            txtMaxCO2.Text = Worksheet.ColdWaterTemp.ToString();
            txtHeatInput.Text = Worksheet.InletStaticPressure.ToString();
            txtOperatingPressure.Text = Worksheet.MaxBurnerPressure.ToString();
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboGasHose;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.FlueFlowTestID.ToString());
            var argcombo2 = cboElectricalIsolator;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.SpillageTestID.ToString());
            var argcombo3 = cboManufactureInfo;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo4 = cboGasIsolation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo5 = cboFSPFitted;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo6 = cboGastight;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.SafetyDeviceOperationID.ToString());
            var argcombo7 = cboServiced;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo8 = cboSafety;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.ApplianceSafeID.ToString());
            var argcombo9 = cboLLAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo9, Worksheet.LandlordsApplianceID.ToString());
            var argcombo10 = cboTested;
            Combo.SetSelectedComboItem_By_Value(ref argcombo10, Worksheet.ApplianceTestedID.ToString());
            if ((Combo.get_GetSelectedItemDescription(cboTested) ?? "") != "No")
            {
            }
            else
            {
                NotTested();
            }
        }

        private void NotTested()
        {
            cboGasHose.Visible = false;
            cboElectricalIsolator.Visible = false;
            cboManufactureInfo.Visible = false;
            cboGasIsolation.Visible = false;
            cboFSPFitted.Visible = false;
            cboGastight.Visible = false;
            cboServiced.Visible = false;
            txtMaxCO.Visible = false;
            txtMaxCO2.Visible = false;
            txtHeatInput.Visible = false;
            txtOperatingPressure.Visible = false;
        }

        private void Tested()
        {
            cboGasHose.Visible = true;
            cboElectricalIsolator.Visible = true;
            cboManufactureInfo.Visible = true;
            cboGasIsolation.Visible = true;
            cboFSPFitted.Visible = true;
            cboGastight.Visible = true;
            cboServiced.Visible = true;
            txtMaxCO.Visible = true;
            txtMaxCO2.Visible = true;
            txtHeatInput.Visible = true;
            txtOperatingPressure.Visible = true;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.ComCat);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboLLAppliance);
                Worksheet.SetApplianceTestedID = Combo.get_GetSelectedItemValue(cboTested);
                if ((Combo.get_GetSelectedItemDescription(cboTested) ?? "") != "No")
                {
                    Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboGasHose);
                    Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboElectricalIsolator);
                    Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboManufactureInfo);
                    Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboGasIsolation);
                    Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboFSPFitted);
                    Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboGastight);
                    Worksheet.SetDHWFlowRate = txtMaxCO.Text;
                    Worksheet.SetColdWaterTemp = txtMaxCO2.Text;
                    Worksheet.SetInletStaticPressure = txtHeatInput.Text;
                    Worksheet.SetMaxBurnerPressure = txtOperatingPressure.Text;
                    Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboServiced);
                }

                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorComCat();
                dValidator.Validate(Worksheet, Combo.get_GetSelectedItemDescription(cboTested));
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

        private void cboTested_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var currentWorksheet = Worksheet;
            Worksheet = new EngineerVisitAssetWorkSheet();
            if (currentWorksheet?.EngineerVisitAssetWorkSheetID > 0 == true)
                Worksheet.SetEngineerVisitAssetWorkSheetID = currentWorksheet.EngineerVisitAssetWorkSheetID;
            if ((Combo.get_GetSelectedItemDescription(cboTested) ?? "") != "No")
            {
                Tested();
            }
            else
            {
                NotTested();
            }
        }
    }
}