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
    public class UCOilWorksheet : UCBase, IUserControl
    {
        public UCOilWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
            DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA).Table;
            DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced).Table;
            DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table;
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
        private TextBox _txtSmokeNo;

        internal TextBox txtSmokeNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSmokeNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSmokeNo != null)
                {
                }

                _txtSmokeNo = value;
                if (_txtSmokeNo != null)
                {
                }
            }
        }

        private TextBox _txtEFFNet;

        internal TextBox txtEFFNet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEFFNet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEFFNet != null)
                {
                }

                _txtEFFNet = value;
                if (_txtEFFNet != null)
                {
                }
            }
        }

        private TextBox _txtGasTemp;

        internal TextBox txtGasTemp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGasTemp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGasTemp != null)
                {
                }

                _txtGasTemp = value;
                if (_txtGasTemp != null)
                {
                }
            }
        }

        private TextBox _txtEFFGross;

        internal TextBox txtEFFGross
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEFFGross;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEFFGross != null)
                {
                }

                _txtEFFGross = value;
                if (_txtEFFGross != null)
                {
                }
            }
        }

        private TextBox _txtInletPressure;

        internal TextBox txtInletPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInletPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInletPressure != null)
                {
                }

                _txtInletPressure = value;
                if (_txtInletPressure != null)
                {
                }
            }
        }

        private TextBox _txtNozzleSize;

        internal TextBox txtNozzleSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNozzleSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNozzleSize != null)
                {
                }

                _txtNozzleSize = value;
                if (_txtNozzleSize != null)
                {
                }
            }
        }

        private TextBox _txtCO2;

        internal TextBox txtCO2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCO2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCO2 != null)
                {
                }

                _txtCO2 = value;
                if (_txtCO2 != null)
                {
                }
            }
        }

        private TextBox _txtCO2Ration;

        internal TextBox txtCO2Ration
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCO2Ration;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCO2Ration != null)
                {
                }

                _txtCO2Ration = value;
                if (_txtCO2Ration != null)
                {
                }
            }
        }

        private TextBox _txtCO2Min;

        internal TextBox txtCO2Min
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCO2Min;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCO2Min != null)
                {
                }

                _txtCO2Min = value;
                if (_txtCO2Min != null)
                {
                }
            }
        }

        private TextBox _txtCO2Max;

        internal TextBox txtCO2Max
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCO2Max;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCO2Max != null)
                {
                }

                _txtCO2Max = value;
                if (_txtCO2Max != null)
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

        private ComboBox _cboDevice;

        internal ComboBox cboDevice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDevice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDevice != null)
                {
                }

                _cboDevice = value;
                if (_cboDevice != null)
                {
                }
            }
        }

        private ComboBox _cboAirSupply;

        internal ComboBox cboAirSupply
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAirSupply;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAirSupply != null)
                {
                }

                _cboAirSupply = value;
                if (_cboAirSupply != null)
                {
                }
            }
        }

        private ComboBox _cboOilPipework;

        internal ComboBox cboOilPipework
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOilPipework;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOilPipework != null)
                {
                }

                _cboOilPipework = value;
                if (_cboOilPipework != null)
                {
                }
            }
        }

        private ComboBox _cboOilStorage;

        internal ComboBox cboOilStorage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOilStorage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOilStorage != null)
                {
                }

                _cboOilStorage = value;
                if (_cboOilStorage != null)
                {
                }
            }
        }

        private ComboBox _cboBurner;

        internal ComboBox cboBurner
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBurner;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBurner != null)
                {
                }

                _cboBurner = value;
                if (_cboBurner != null)
                {
                }
            }
        }

        private ComboBox _cboFlueFlow;

        internal ComboBox cboFlueFlow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFlueFlow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFlueFlow != null)
                {
                }

                _cboFlueFlow = value;
                if (_cboFlueFlow != null)
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

        private ComboBox _cboTankType;

        internal ComboBox cboTankType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTankType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTankType != null)
                {
                }

                _cboTankType = value;
                if (_cboTankType != null)
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
                if (_lblNotTested17 != null)
                {
                }

                _lblNotTested17 = value;
                if (_lblNotTested17 != null)
                {
                }
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
                if (_lblNotTested16 != null)
                {
                }

                _lblNotTested16 = value;
                if (_lblNotTested16 != null)
                {
                }
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
                if (_lblNotTested15 != null)
                {
                }

                _lblNotTested15 = value;
                if (_lblNotTested15 != null)
                {
                }
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
                if (_lblNotTested14 != null)
                {
                }

                _lblNotTested14 = value;
                if (_lblNotTested14 != null)
                {
                }
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
                if (_lblNotTested13 != null)
                {
                }

                _lblNotTested13 = value;
                if (_lblNotTested13 != null)
                {
                }
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
                if (_lblNotTested12 != null)
                {
                }

                _lblNotTested12 = value;
                if (_lblNotTested12 != null)
                {
                }
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
                if (_lblNotTested11 != null)
                {
                }

                _lblNotTested11 = value;
                if (_lblNotTested11 != null)
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtSmokeNo = new TextBox();
            _txtEFFNet = new TextBox();
            _txtGasTemp = new TextBox();
            _txtEFFGross = new TextBox();
            _txtInletPressure = new TextBox();
            _txtNozzleSize = new TextBox();
            _txtCO2 = new TextBox();
            _txtCO2Ration = new TextBox();
            _txtCO2Min = new TextBox();
            _txtCO2Max = new TextBox();
            _cboSafety = new ComboBox();
            _cboServiced = new ComboBox();
            _cboDevice = new ComboBox();
            _cboAirSupply = new ComboBox();
            _cboOilPipework = new ComboBox();
            _cboOilStorage = new ComboBox();
            _cboBurner = new ComboBox();
            _cboFlueFlow = new ComboBox();
            _cboTested = new ComboBox();
            _cboTested.SelectionChangeCommitted += new EventHandler(cboTested_SelectionChangeCommitted);
            _cboLLAppliance = new ComboBox();
            _cboAppliance = new ComboBox();
            _Label44 = new Label();
            _Label24 = new Label();
            _Label25 = new Label();
            _Label26 = new Label();
            _Label27 = new Label();
            _Label28 = new Label();
            _Label29 = new Label();
            _Label30 = new Label();
            _Label31 = new Label();
            _Label32 = new Label();
            _Label33 = new Label();
            _Label34 = new Label();
            _Label35 = new Label();
            _Label36 = new Label();
            _Label37 = new Label();
            _Label38 = new Label();
            _Label39 = new Label();
            _Label40 = new Label();
            _Label41 = new Label();
            _Label42 = new Label();
            _Label43 = new Label();
            _Label2 = new Label();
            _cboTankType = new ComboBox();
            _lblNotTested18 = new Label();
            _lblNotTested17 = new Label();
            _lblNotTested16 = new Label();
            _lblNotTested15 = new Label();
            _lblNotTested14 = new Label();
            _lblNotTested13 = new Label();
            _lblNotTested12 = new Label();
            _lblNotTested11 = new Label();
            _lblNotTested10 = new Label();
            _lblNotTested9 = new Label();
            _lblNotTested8 = new Label();
            _lblNotTested7 = new Label();
            _lblNotTested6 = new Label();
            _lblNotTested5 = new Label();
            _lblNotTested4 = new Label();
            _lblNotTested3 = new Label();
            _lblNotTested2 = new Label();
            _lblNotTested1 = new Label();
            SuspendLayout();
            //
            // txtSmokeNo
            //
            _txtSmokeNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtSmokeNo.Location = new Point(601, 278);
            _txtSmokeNo.Name = "txtSmokeNo";
            _txtSmokeNo.Size = new Size(188, 21);
            _txtSmokeNo.TabIndex = 10;
            //
            // txtEFFNet
            //
            _txtEFFNet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtEFFNet.Location = new Point(601, 309);
            _txtEFFNet.Name = "txtEFFNet";
            _txtEFFNet.Size = new Size(188, 21);
            _txtEFFNet.TabIndex = 11;
            //
            // txtGasTemp
            //
            _txtGasTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtGasTemp.Location = new Point(601, 339);
            _txtGasTemp.Name = "txtGasTemp";
            _txtGasTemp.Size = new Size(188, 21);
            _txtGasTemp.TabIndex = 12;
            //
            // txtEFFGross
            //
            _txtEFFGross.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtEFFGross.Location = new Point(601, 368);
            _txtEFFGross.Name = "txtEFFGross";
            _txtEFFGross.Size = new Size(188, 21);
            _txtEFFGross.TabIndex = 13;
            //
            // txtInletPressure
            //
            _txtInletPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtInletPressure.Location = new Point(601, 399);
            _txtInletPressure.Name = "txtInletPressure";
            _txtInletPressure.Size = new Size(188, 21);
            _txtInletPressure.TabIndex = 14;
            //
            // txtNozzleSize
            //
            _txtNozzleSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtNozzleSize.Location = new Point(601, 429);
            _txtNozzleSize.Name = "txtNozzleSize";
            _txtNozzleSize.Size = new Size(188, 21);
            _txtNozzleSize.TabIndex = 15;
            //
            // txtCO2
            //
            _txtCO2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCO2.Location = new Point(601, 488);
            _txtCO2.Name = "txtCO2";
            _txtCO2.Size = new Size(188, 21);
            _txtCO2.TabIndex = 17;
            //
            // txtCO2Ration
            //
            _txtCO2Ration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCO2Ration.Location = new Point(601, 519);
            _txtCO2Ration.Name = "txtCO2Ration";
            _txtCO2Ration.Size = new Size(188, 21);
            _txtCO2Ration.TabIndex = 18;
            //
            // txtCO2Min
            //
            _txtCO2Min.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCO2Min.Location = new Point(601, 549);
            _txtCO2Min.Name = "txtCO2Min";
            _txtCO2Min.Size = new Size(188, 21);
            _txtCO2Min.TabIndex = 19;
            //
            // txtCO2Max
            //
            _txtCO2Max.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtCO2Max.Location = new Point(601, 578);
            _txtCO2Max.Name = "txtCO2Max";
            _txtCO2Max.Size = new Size(188, 21);
            _txtCO2Max.TabIndex = 20;
            //
            // cboSafety
            //
            _cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafety.Location = new Point(601, 638);
            _cboSafety.Name = "cboSafety";
            _cboSafety.Size = new Size(188, 21);
            _cboSafety.TabIndex = 22;
            //
            // cboServiced
            //
            _cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboServiced.Location = new Point(601, 608);
            _cboServiced.Name = "cboServiced";
            _cboServiced.Size = new Size(188, 21);
            _cboServiced.TabIndex = 21;
            //
            // cboDevice
            //
            _cboDevice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDevice.Location = new Point(601, 248);
            _cboDevice.Name = "cboDevice";
            _cboDevice.Size = new Size(188, 21);
            _cboDevice.TabIndex = 9;
            //
            // cboAirSupply
            //
            _cboAirSupply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboAirSupply.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAirSupply.Location = new Point(601, 218);
            _cboAirSupply.Name = "cboAirSupply";
            _cboAirSupply.Size = new Size(188, 21);
            _cboAirSupply.TabIndex = 8;
            //
            // cboOilPipework
            //
            _cboOilPipework.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboOilPipework.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOilPipework.Location = new Point(601, 189);
            _cboOilPipework.Name = "cboOilPipework";
            _cboOilPipework.Size = new Size(188, 21);
            _cboOilPipework.TabIndex = 7;
            //
            // cboOilStorage
            //
            _cboOilStorage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboOilStorage.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOilStorage.Location = new Point(601, 159);
            _cboOilStorage.Name = "cboOilStorage";
            _cboOilStorage.Size = new Size(188, 21);
            _cboOilStorage.TabIndex = 6;
            //
            // cboBurner
            //
            _cboBurner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboBurner.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboBurner.Location = new Point(601, 129);
            _cboBurner.Name = "cboBurner";
            _cboBurner.Size = new Size(188, 21);
            _cboBurner.TabIndex = 5;
            //
            // cboFlueFlow
            //
            _cboFlueFlow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFlueFlow.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFlueFlow.Location = new Point(601, 99);
            _cboFlueFlow.Name = "cboFlueFlow";
            _cboFlueFlow.Size = new Size(188, 21);
            _cboFlueFlow.TabIndex = 4;
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
            // cboLLAppliance
            //
            _cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLLAppliance.Location = new Point(601, 40);
            _cboLLAppliance.Name = "cboLLAppliance";
            _cboLLAppliance.Size = new Size(188, 21);
            _cboLLAppliance.TabIndex = 2;
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
            // Label44
            //
            _Label44.AutoSize = true;
            _Label44.Location = new Point(3, 491);
            _Label44.Name = "Label44";
            _Label44.Size = new Size(48, 13);
            _Label44.TabIndex = 443;
            _Label44.Text = "CO2 %";
            //
            // Label24
            //
            _Label24.AutoSize = true;
            _Label24.Location = new Point(3, 641);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(101, 13);
            _Label24.TabIndex = 442;
            _Label24.Text = "Appliance safety";
            //
            // Label25
            //
            _Label25.AutoSize = true;
            _Label25.Location = new Point(3, 611);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(181, 13);
            _Label25.TabIndex = 441;
            _Label25.Text = "Appliance service or inspected";
            //
            // Label26
            //
            _Label26.AutoSize = true;
            _Label26.Location = new Point(3, 581);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(61, 13);
            _Label26.TabIndex = 440;
            _Label26.Text = "CO2 max";
            //
            // Label27
            //
            _Label27.AutoSize = true;
            _Label27.Location = new Point(3, 552);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(57, 13);
            _Label27.TabIndex = 439;
            _Label27.Text = "CO2 min";
            //
            // Label28
            //
            _Label28.AutoSize = true;
            _Label28.Location = new Point(3, 522);
            _Label28.Name = "Label28";
            _Label28.Size = new Size(54, 13);
            _Label28.TabIndex = 438;
            _Label28.Text = "CO ppm";
            //
            // Label29
            //
            _Label29.AutoSize = true;
            _Label29.Location = new Point(3, 461);
            _Label29.Name = "Label29";
            _Label29.Size = new Size(63, 13);
            _Label29.TabIndex = 437;
            _Label29.Text = "Tank type";
            //
            // Label30
            //
            _Label30.AutoSize = true;
            _Label30.Location = new Point(3, 431);
            _Label30.Name = "Label30";
            _Label30.Size = new Size(70, 13);
            _Label30.TabIndex = 436;
            _Label30.Text = "Nozzle size";
            //
            // Label31
            //
            _Label31.AutoSize = true;
            _Label31.Location = new Point(3, 402);
            _Label31.Name = "Label31";
            _Label31.Size = new Size(117, 13);
            _Label31.TabIndex = 435;
            _Label31.Text = "Pump pressure PSI";
            //
            // Label32
            //
            _Label32.AutoSize = true;
            _Label32.Location = new Point(3, 372);
            _Label32.Name = "Label32";
            _Label32.Size = new Size(75, 13);
            _Label32.TabIndex = 434;
            _Label32.Text = "Eff Gross %";
            //
            // Label33
            //
            _Label33.AutoSize = true;
            _Label33.Location = new Point(3, 342);
            _Label33.Name = "Label33";
            _Label33.Size = new Size(117, 13);
            _Label33.TabIndex = 433;
            _Label33.Text = "Flue Gas temp cent";
            //
            // Label34
            //
            _Label34.AutoSize = true;
            _Label34.Location = new Point(3, 312);
            _Label34.Name = "Label34";
            _Label34.Size = new Size(65, 13);
            _Label34.TabIndex = 432;
            _Label34.Text = "EFF Net %";
            //
            // Label35
            //
            _Label35.AutoSize = true;
            _Label35.Location = new Point(3, 281);
            _Label35.Name = "Label35";
            _Label35.Size = new Size(70, 13);
            _Label35.TabIndex = 431;
            _Label35.Text = "Smoke No ";
            //
            // Label36
            //
            _Label36.AutoSize = true;
            _Label36.Location = new Point(3, 251);
            _Label36.Name = "Label36";
            _Label36.Size = new Size(143, 13);
            _Label36.TabIndex = 430;
            _Label36.Text = "Safety device operation";
            //
            // Label37
            //
            _Label37.AutoSize = true;
            _Label37.Location = new Point(3, 221);
            _Label37.Name = "Label37";
            _Label37.Size = new Size(64, 13);
            _Label37.TabIndex = 429;
            _Label37.Text = "Air supply";
            //
            // Label38
            //
            _Label38.AutoSize = true;
            _Label38.Location = new Point(3, 192);
            _Label38.Name = "Label38";
            _Label38.Size = new Size(119, 13);
            _Label38.TabIndex = 428;
            _Label38.Text = "Oil supply pipework";
            //
            // Label39
            //
            _Label39.AutoSize = true;
            _Label39.Location = new Point(3, 162);
            _Label39.Name = "Label39";
            _Label39.Size = new Size(69, 13);
            _Label39.TabIndex = 427;
            _Label39.Text = "Oil storage";
            //
            // Label40
            //
            _Label40.AutoSize = true;
            _Label40.Location = new Point(3, 132);
            _Label40.Name = "Label40";
            _Label40.Size = new Size(116, 13);
            _Label40.TabIndex = 426;
            _Label40.Text = "Burner satisfactory";
            //
            // Label41
            //
            _Label41.AutoSize = true;
            _Label41.Location = new Point(3, 102);
            _Label41.Name = "Label41";
            _Label41.Size = new Size(94, 13);
            _Label41.TabIndex = 425;
            _Label41.Text = "Chimney / Flue";
            //
            // Label42
            //
            _Label42.AutoSize = true;
            _Label42.Location = new Point(3, 72);
            _Label42.Name = "Label42";
            _Label42.Size = new Size(101, 13);
            _Label42.TabIndex = 424;
            _Label42.Text = "Appliance tested";
            //
            // Label43
            //
            _Label43.AutoSize = true;
            _Label43.Location = new Point(3, 43);
            _Label43.Name = "Label43";
            _Label43.Size = new Size(125, 13);
            _Label43.TabIndex = 423;
            _Label43.Text = "Landlords Appliance ";
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(3, 13);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(62, 13);
            _Label2.TabIndex = 422;
            _Label2.Text = "Appliance";
            //
            // cboTankType
            //
            _cboTankType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTankType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTankType.Location = new Point(601, 458);
            _cboTankType.Name = "cboTankType";
            _cboTankType.Size = new Size(188, 21);
            _cboTankType.TabIndex = 16;
            //
            // lblNotTested18
            //
            _lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested18.AutoSize = true;
            _lblNotTested18.Location = new Point(662, 581);
            _lblNotTested18.Name = "lblNotTested18";
            _lblNotTested18.Size = new Size(67, 13);
            _lblNotTested18.TabIndex = 462;
            _lblNotTested18.Text = "Not Tested";
            //
            // lblNotTested17
            //
            _lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested17.AutoSize = true;
            _lblNotTested17.Location = new Point(662, 551);
            _lblNotTested17.Name = "lblNotTested17";
            _lblNotTested17.Size = new Size(67, 13);
            _lblNotTested17.TabIndex = 461;
            _lblNotTested17.Text = "Not Tested";
            //
            // lblNotTested16
            //
            _lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested16.AutoSize = true;
            _lblNotTested16.Location = new Point(662, 521);
            _lblNotTested16.Name = "lblNotTested16";
            _lblNotTested16.Size = new Size(67, 13);
            _lblNotTested16.TabIndex = 460;
            _lblNotTested16.Text = "Not Tested";
            //
            // lblNotTested15
            //
            _lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested15.AutoSize = true;
            _lblNotTested15.Location = new Point(662, 491);
            _lblNotTested15.Name = "lblNotTested15";
            _lblNotTested15.Size = new Size(67, 13);
            _lblNotTested15.TabIndex = 459;
            _lblNotTested15.Text = "Not Tested";
            //
            // lblNotTested14
            //
            _lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested14.AutoSize = true;
            _lblNotTested14.Location = new Point(662, 461);
            _lblNotTested14.Name = "lblNotTested14";
            _lblNotTested14.Size = new Size(67, 13);
            _lblNotTested14.TabIndex = 458;
            _lblNotTested14.Text = "Not Tested";
            //
            // lblNotTested13
            //
            _lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested13.AutoSize = true;
            _lblNotTested13.Location = new Point(662, 431);
            _lblNotTested13.Name = "lblNotTested13";
            _lblNotTested13.Size = new Size(67, 13);
            _lblNotTested13.TabIndex = 457;
            _lblNotTested13.Text = "Not Tested";
            //
            // lblNotTested12
            //
            _lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested12.AutoSize = true;
            _lblNotTested12.Location = new Point(662, 401);
            _lblNotTested12.Name = "lblNotTested12";
            _lblNotTested12.Size = new Size(67, 13);
            _lblNotTested12.TabIndex = 456;
            _lblNotTested12.Text = "Not Tested";
            //
            // lblNotTested11
            //
            _lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested11.AutoSize = true;
            _lblNotTested11.Location = new Point(662, 371);
            _lblNotTested11.Name = "lblNotTested11";
            _lblNotTested11.Size = new Size(67, 13);
            _lblNotTested11.TabIndex = 455;
            _lblNotTested11.Text = "Not Tested";
            //
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(662, 341);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 454;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested9
            //
            _lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested9.AutoSize = true;
            _lblNotTested9.Location = new Point(662, 311);
            _lblNotTested9.Name = "lblNotTested9";
            _lblNotTested9.Size = new Size(67, 13);
            _lblNotTested9.TabIndex = 453;
            _lblNotTested9.Text = "Not Tested";
            //
            // lblNotTested8
            //
            _lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested8.AutoSize = true;
            _lblNotTested8.Location = new Point(662, 281);
            _lblNotTested8.Name = "lblNotTested8";
            _lblNotTested8.Size = new Size(67, 13);
            _lblNotTested8.TabIndex = 452;
            _lblNotTested8.Text = "Not Tested";
            //
            // lblNotTested7
            //
            _lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested7.AutoSize = true;
            _lblNotTested7.Location = new Point(662, 251);
            _lblNotTested7.Name = "lblNotTested7";
            _lblNotTested7.Size = new Size(67, 13);
            _lblNotTested7.TabIndex = 451;
            _lblNotTested7.Text = "Not Tested";
            //
            // lblNotTested6
            //
            _lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested6.AutoSize = true;
            _lblNotTested6.Location = new Point(662, 222);
            _lblNotTested6.Name = "lblNotTested6";
            _lblNotTested6.Size = new Size(67, 13);
            _lblNotTested6.TabIndex = 450;
            _lblNotTested6.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(662, 192);
            _lblNotTested5.Name = "lblNotTested5";
            _lblNotTested5.Size = new Size(67, 13);
            _lblNotTested5.TabIndex = 449;
            _lblNotTested5.Text = "Not Tested";
            //
            // lblNotTested4
            //
            _lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested4.AutoSize = true;
            _lblNotTested4.Location = new Point(662, 162);
            _lblNotTested4.Name = "lblNotTested4";
            _lblNotTested4.Size = new Size(67, 13);
            _lblNotTested4.TabIndex = 448;
            _lblNotTested4.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(662, 132);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 447;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(662, 102);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 446;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested1
            //
            _lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested1.AutoSize = true;
            _lblNotTested1.Location = new Point(662, 72);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 445;
            _lblNotTested1.Text = "Not Tested";
            //
            // UCOilWorksheet
            //
            Controls.Add(_cboTankType);
            Controls.Add(_Label44);
            Controls.Add(_Label24);
            Controls.Add(_Label25);
            Controls.Add(_Label26);
            Controls.Add(_Label27);
            Controls.Add(_Label28);
            Controls.Add(_Label29);
            Controls.Add(_Label30);
            Controls.Add(_Label31);
            Controls.Add(_Label32);
            Controls.Add(_Label33);
            Controls.Add(_Label34);
            Controls.Add(_Label35);
            Controls.Add(_Label36);
            Controls.Add(_Label37);
            Controls.Add(_Label38);
            Controls.Add(_Label39);
            Controls.Add(_Label40);
            Controls.Add(_Label41);
            Controls.Add(_Label42);
            Controls.Add(_Label43);
            Controls.Add(_Label2);
            Controls.Add(_txtSmokeNo);
            Controls.Add(_txtEFFNet);
            Controls.Add(_txtGasTemp);
            Controls.Add(_txtEFFGross);
            Controls.Add(_txtInletPressure);
            Controls.Add(_txtNozzleSize);
            Controls.Add(_txtCO2);
            Controls.Add(_txtCO2Ration);
            Controls.Add(_txtCO2Min);
            Controls.Add(_txtCO2Max);
            Controls.Add(_cboSafety);
            Controls.Add(_cboServiced);
            Controls.Add(_cboDevice);
            Controls.Add(_cboAirSupply);
            Controls.Add(_cboOilPipework);
            Controls.Add(_cboOilStorage);
            Controls.Add(_cboBurner);
            Controls.Add(_cboFlueFlow);
            Controls.Add(_cboTested);
            Controls.Add(_cboLLAppliance);
            Controls.Add(_cboAppliance);
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
            Name = "UCOilWorksheet";
            Size = new Size(789, 666);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable DtPassFailNa = null;
        private DataTable DtNotTestedPassFail = null;
        private DataTable DtApplianceServiced = null;
        private DataTable DtYesNo = null;
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
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNATab).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboFlueFlow;
            Combo.SetUpCombo(ref argc3, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboBurner;
            Combo.SetUpCombo(ref argc4, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboOilStorage;
            Combo.SetUpCombo(ref argc5, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboOilPipework;
            Combo.SetUpCombo(ref argc6, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboAirSupply;
            Combo.SetUpCombo(ref argc7, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboDevice;
            Combo.SetUpCombo(ref argc8, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboServiced;
            Combo.SetUpCombo(ref argc9, DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboSafety;
            Combo.SetUpCombo(ref argc10, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboSafety.Items.Add(new Combo("Visually Passed", "999999999"));
            var argc11 = cboTankType;
            Combo.SetUpCombo(ref argc11, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
        }

        public void Populate(int ID = 0)
        {
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboLLAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.LandlordsApplianceID.ToString());
            var argcombo2 = cboTested;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.ApplianceTestedID.ToString());
            var argcombo3 = cboFlueFlow;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.FlueFlowTestID.ToString());
            var argcombo4 = cboBurner;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.SpillageTestID.ToString());
            var argcombo5 = cboOilStorage;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo6 = cboOilPipework;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo7 = cboAirSupply;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo8 = cboDevice;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.SafetyDeviceOperationID.ToString());
            txtSmokeNo.Text = Worksheet.DHWFlowRate.ToString();
            txtEFFNet.Text = Worksheet.ColdWaterTemp.ToString();
            txtGasTemp.Text = Worksheet.DHWTemp.ToString();
            txtEFFGross.Text = Worksheet.InletStaticPressure.ToString();
            txtInletPressure.Text = Worksheet.InletWorkingPressure.ToString();
            txtNozzleSize.Text = Worksheet.Nozzle;
            var argcombo9 = cboTankType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo9, Worksheet.TankID.ToString());
            txtCO2.Text = Worksheet.CO2.ToString();
            txtCO2Ration.Text = Worksheet.CO2CORatio.ToString();
            txtCO2Min.Text = Worksheet.BMake;
            txtCO2Max.Text = Worksheet.BModel;
            var argcombo10 = cboServiced;
            Combo.SetSelectedComboItem_By_Value(ref argcombo10, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo11 = cboSafety;
            Combo.SetSelectedComboItem_By_Value(ref argcombo11, Worksheet.ApplianceSafeID.ToString());
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
            cboFlueFlow.Visible = false;
            cboBurner.Visible = false;
            cboOilStorage.Visible = false;
            cboOilPipework.Visible = false;
            cboAirSupply.Visible = false;
            cboDevice.Visible = false;
            cboServiced.Visible = false;
            cboTankType.Visible = false;
            txtSmokeNo.Visible = false;
            txtEFFNet.Visible = false;
            txtGasTemp.Visible = false;
            txtEFFGross.Visible = false;
            txtInletPressure.Visible = false;
            txtNozzleSize.Visible = false;
            txtCO2.Visible = false;
            txtCO2Ration.Visible = false;
            txtCO2Min.Visible = false;
            txtCO2Max.Visible = false;
        }

        private void Tested()
        {
            cboFlueFlow.Visible = true;
            cboBurner.Visible = true;
            cboOilStorage.Visible = true;
            cboOilPipework.Visible = true;
            cboAirSupply.Visible = true;
            cboDevice.Visible = true;
            cboServiced.Visible = true;
            cboTankType.Visible = true;
            txtSmokeNo.Visible = true;
            txtEFFNet.Visible = true;
            txtGasTemp.Visible = true;
            txtEFFGross.Visible = true;
            txtInletPressure.Visible = true;
            txtNozzleSize.Visible = true;
            txtCO2.Visible = true;
            txtCO2Ration.Visible = true;
            txtCO2Min.Visible = true;
            txtCO2Max.Visible = true;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.Oil);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboLLAppliance);
                Worksheet.SetApplianceTestedID = Combo.get_GetSelectedItemValue(cboTested);
                if ((Combo.get_GetSelectedItemDescription(cboTested) ?? "") != "No")
                {
                    Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboFlueFlow);
                    Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboBurner);
                    Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboOilStorage);
                    Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboOilPipework);
                    Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboAirSupply);
                    Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboDevice);
                    Worksheet.SetTankID = Combo.get_GetSelectedItemValue(cboTankType);
                    Worksheet.SetNozzle = txtNozzleSize.Text;
                    Worksheet.SetDHWFlowRate = txtSmokeNo.Text;
                    Worksheet.SetColdWaterTemp = txtEFFNet.Text;
                    Worksheet.SetDHWTemp = txtGasTemp.Text;
                    Worksheet.SetInletStaticPressure = txtEFFGross.Text;
                    Worksheet.SetInletWorkingPressure = txtInletPressure.Text;
                    Worksheet.SetCO2 = txtCO2.Text;
                    Worksheet.SetCO2CORatio = txtCO2Ration.Text;
                    Worksheet.SetBMake = txtCO2Min.Text;
                    Worksheet.SetBModel = txtCO2Max.Text;
                    Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboServiced);
                }

                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorOil();
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