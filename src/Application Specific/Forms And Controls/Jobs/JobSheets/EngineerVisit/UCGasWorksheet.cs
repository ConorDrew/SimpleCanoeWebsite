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
    public class UCGasWorksheet : UCBase, IUserControl
    {
        public UCGasWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
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

        
        private TextBox _txtDHWFlow;

        internal TextBox txtDHWFlow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDHWFlow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDHWFlow != null)
                {
                }

                _txtDHWFlow = value;
                if (_txtDHWFlow != null)
                {
                }
            }
        }

        private TextBox _txtColdTemp;

        internal TextBox txtColdTemp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtColdTemp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtColdTemp != null)
                {
                }

                _txtColdTemp = value;
                if (_txtColdTemp != null)
                {
                }
            }
        }

        private TextBox _txtDHWTemp;

        internal TextBox txtDHWTemp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDHWTemp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDHWTemp != null)
                {
                }

                _txtDHWTemp = value;
                if (_txtDHWTemp != null)
                {
                }
            }
        }

        private TextBox _txtHeadInput;

        internal TextBox txtHeadInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHeadInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHeadInput != null)
                {
                }

                _txtHeadInput = value;
                if (_txtHeadInput != null)
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

        private TextBox _txtMinBurnerPressure;

        internal TextBox txtMinBurnerPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMinBurnerPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMinBurnerPressure != null)
                {
                }

                _txtMinBurnerPressure = value;
                if (_txtMinBurnerPressure != null)
                {
                }
            }
        }

        private TextBox _txtMaxBurnerPressure;

        internal TextBox txtMaxBurnerPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMaxBurnerPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMaxBurnerPressure != null)
                {
                }

                _txtMaxBurnerPressure = value;
                if (_txtMaxBurnerPressure != null)
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

        private ComboBox _cboProvisions;

        internal ComboBox cboProvisions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboProvisions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboProvisions != null)
                {
                }

                _cboProvisions = value;
                if (_cboProvisions != null)
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
                if (_cboVisualCondition != null)
                {
                }

                _cboVisualCondition = value;
                if (_cboVisualCondition != null)
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

        private ComboBox _cboFlueTermination;

        internal ComboBox cboFlueTermination
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFlueTermination;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFlueTermination != null)
                {
                }

                _cboFlueTermination = value;
                if (_cboFlueTermination != null)
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

        private ComboBox _cboFlueSpil;

        internal ComboBox cboFlueSpil
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFlueSpil;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFlueSpil != null)
                {
                }

                _cboFlueSpil = value;
                if (_cboFlueSpil != null)
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtDHWFlow = new TextBox();
            _txtColdTemp = new TextBox();
            _txtDHWTemp = new TextBox();
            _txtHeadInput = new TextBox();
            _txtInletPressure = new TextBox();
            _txtMinBurnerPressure = new TextBox();
            _txtMaxBurnerPressure = new TextBox();
            _txtCO2 = new TextBox();
            _txtCO2Ration = new TextBox();
            _txtCO2Min = new TextBox();
            _txtCO2Max = new TextBox();
            _cboSafety = new ComboBox();
            _Label18 = new Label();
            _cboServiced = new ComboBox();
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
            _cboDevice = new ComboBox();
            _Label7 = new Label();
            _cboProvisions = new ComboBox();
            _Label8 = new Label();
            _cboVisualCondition = new ComboBox();
            _Label9 = new Label();
            _cboFlueTermination = new ComboBox();
            _Label10 = new Label();
            _cboFlueSpil = new ComboBox();
            _Label3 = new Label();
            _cboFlueFlow = new ComboBox();
            _Label4 = new Label();
            _cboTested = new ComboBox();
            _cboTested.SelectionChangeCommitted += new EventHandler(cboTested_SelectionChangeCommitted);
            _Label5 = new Label();
            _cboLLAppliance = new ComboBox();
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
            SuspendLayout();
            //
            // txtDHWFlow
            //
            _txtDHWFlow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtDHWFlow.Location = new Point(601, 278);
            _txtDHWFlow.Name = "txtDHWFlow";
            _txtDHWFlow.Size = new Size(188, 21);
            _txtDHWFlow.TabIndex = 10;
            //
            // txtColdTemp
            //
            _txtColdTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtColdTemp.Location = new Point(601, 309);
            _txtColdTemp.Name = "txtColdTemp";
            _txtColdTemp.Size = new Size(188, 21);
            _txtColdTemp.TabIndex = 11;
            //
            // txtDHWTemp
            //
            _txtDHWTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtDHWTemp.Location = new Point(601, 339);
            _txtDHWTemp.Name = "txtDHWTemp";
            _txtDHWTemp.Size = new Size(188, 21);
            _txtDHWTemp.TabIndex = 12;
            //
            // txtHeadInput
            //
            _txtHeadInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtHeadInput.Location = new Point(601, 368);
            _txtHeadInput.Name = "txtHeadInput";
            _txtHeadInput.Size = new Size(188, 21);
            _txtHeadInput.TabIndex = 13;
            //
            // txtInletPressure
            //
            _txtInletPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtInletPressure.Location = new Point(601, 399);
            _txtInletPressure.Name = "txtInletPressure";
            _txtInletPressure.Size = new Size(188, 21);
            _txtInletPressure.TabIndex = 14;
            //
            // txtMinBurnerPressure
            //
            _txtMinBurnerPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtMinBurnerPressure.Location = new Point(601, 429);
            _txtMinBurnerPressure.Name = "txtMinBurnerPressure";
            _txtMinBurnerPressure.Size = new Size(188, 21);
            _txtMinBurnerPressure.TabIndex = 15;
            //
            // txtMaxBurnerPressure
            //
            _txtMaxBurnerPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtMaxBurnerPressure.Location = new Point(601, 458);
            _txtMaxBurnerPressure.Name = "txtMaxBurnerPressure";
            _txtMaxBurnerPressure.Size = new Size(188, 21);
            _txtMaxBurnerPressure.TabIndex = 16;
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
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Location = new Point(3, 641);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(101, 13);
            _Label18.TabIndex = 365;
            _Label18.Text = "Appliance safety";
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
            // Label19
            //
            _Label19.AutoSize = true;
            _Label19.Location = new Point(3, 611);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(181, 13);
            _Label19.TabIndex = 363;
            _Label19.Text = "Appliance service or inspected";
            //
            // Label20
            //
            _Label20.AutoSize = true;
            _Label20.Location = new Point(3, 581);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(61, 13);
            _Label20.TabIndex = 361;
            _Label20.Text = "CO2 max";
            //
            // Label21
            //
            _Label21.AutoSize = true;
            _Label21.Location = new Point(3, 552);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(57, 13);
            _Label21.TabIndex = 360;
            _Label21.Text = "CO2 min";
            //
            // Label22
            //
            _Label22.AutoSize = true;
            _Label22.Location = new Point(3, 522);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(123, 13);
            _Label22.TabIndex = 359;
            _Label22.Text = "CO2 / co ration high";
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
            _Label12.Size = new Size(126, 13);
            _Label12.TabIndex = 357;
            _Label12.Text = "Max burner pressure";
            //
            // Label13
            //
            _Label13.AutoSize = true;
            _Label13.Location = new Point(3, 431);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(122, 13);
            _Label13.TabIndex = 356;
            _Label13.Text = "Min burner pressure";
            //
            // Label14
            //
            _Label14.AutoSize = true;
            _Label14.Location = new Point(3, 402);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(136, 13);
            _Label14.TabIndex = 355;
            _Label14.Text = "Inlet working pressure";
            //
            // Label15
            //
            _Label15.AutoSize = true;
            _Label15.Location = new Point(3, 372);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(68, 13);
            _Label15.TabIndex = 354;
            _Label15.Text = "Head input";
            //
            // Label16
            //
            _Label16.AutoSize = true;
            _Label16.Location = new Point(3, 342);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(68, 13);
            _Label16.TabIndex = 353;
            _Label16.Text = "DHW temp";
            //
            // Label17
            //
            _Label17.AutoSize = true;
            _Label17.Location = new Point(3, 312);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(102, 13);
            _Label17.TabIndex = 352;
            _Label17.Text = "Cold water temp";
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(3, 281);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(89, 13);
            _Label6.TabIndex = 351;
            _Label6.Text = "DHW flow rate";
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
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(3, 251);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(143, 13);
            _Label7.TabIndex = 350;
            _Label7.Text = "Safety device operation";
            //
            // cboProvisions
            //
            _cboProvisions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboProvisions.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboProvisions.Location = new Point(601, 218);
            _cboProvisions.Name = "cboProvisions";
            _cboProvisions.Size = new Size(188, 21);
            _cboProvisions.TabIndex = 8;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(3, 221);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(192, 13);
            _Label8.TabIndex = 348;
            _Label8.Text = "Ventilation provision satisfactory";
            //
            // cboVisualCondition
            //
            _cboVisualCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboVisualCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisualCondition.Location = new Point(601, 189);
            _cboVisualCondition.Name = "cboVisualCondition";
            _cboVisualCondition.Size = new Size(188, 21);
            _cboVisualCondition.TabIndex = 7;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(3, 192);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(141, 13);
            _Label9.TabIndex = 346;
            _Label9.Text = "Visual Condition of Flue";
            //
            // cboFlueTermination
            //
            _cboFlueTermination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFlueTermination.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFlueTermination.Location = new Point(601, 159);
            _cboFlueTermination.Name = "cboFlueTermination";
            _cboFlueTermination.Size = new Size(188, 21);
            _cboFlueTermination.TabIndex = 6;
            //
            // Label10
            //
            _Label10.AutoSize = true;
            _Label10.Location = new Point(3, 162);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(171, 13);
            _Label10.TabIndex = 344;
            _Label10.Text = "Flue Termination satisfactory";
            //
            // cboFlueSpil
            //
            _cboFlueSpil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFlueSpil.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFlueSpil.Location = new Point(601, 129);
            _cboFlueSpil.Name = "cboFlueSpil";
            _cboFlueSpil.Size = new Size(188, 21);
            _cboFlueSpil.TabIndex = 5;
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(3, 132);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(99, 13);
            _Label3.TabIndex = 342;
            _Label3.Text = "Flue spilage test";
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
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(3, 102);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(84, 13);
            _Label4.TabIndex = 340;
            _Label4.Text = "Flue Flow test";
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
            // Label23
            //
            _Label23.AutoSize = true;
            _Label23.Location = new Point(3, 491);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(32, 13);
            _Label23.TabIndex = 378;
            _Label23.Text = "CO2";
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
            // lblNotTested12
            //
            _lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested12.AutoSize = true;
            _lblNotTested12.Location = new Point(661, 431);
            _lblNotTested12.Name = "lblNotTested12";
            _lblNotTested12.Size = new Size(67, 13);
            _lblNotTested12.TabIndex = 390;
            _lblNotTested12.Text = "Not Tested";
            //
            // lblNotTested11
            //
            _lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested11.AutoSize = true;
            _lblNotTested11.Location = new Point(661, 401);
            _lblNotTested11.Name = "lblNotTested11";
            _lblNotTested11.Size = new Size(67, 13);
            _lblNotTested11.TabIndex = 389;
            _lblNotTested11.Text = "Not Tested";
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
            _lblNotTested18.Location = new Point(661, 611);
            _lblNotTested18.Name = "lblNotTested18";
            _lblNotTested18.Size = new Size(67, 13);
            _lblNotTested18.TabIndex = 396;
            _lblNotTested18.Text = "Not Tested";
            //
            // lblNotTested17
            //
            _lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested17.AutoSize = true;
            _lblNotTested17.Location = new Point(661, 581);
            _lblNotTested17.Name = "lblNotTested17";
            _lblNotTested17.Size = new Size(67, 13);
            _lblNotTested17.TabIndex = 395;
            _lblNotTested17.Text = "Not Tested";
            //
            // lblNotTested16
            //
            _lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested16.AutoSize = true;
            _lblNotTested16.Location = new Point(661, 551);
            _lblNotTested16.Name = "lblNotTested16";
            _lblNotTested16.Size = new Size(67, 13);
            _lblNotTested16.TabIndex = 394;
            _lblNotTested16.Text = "Not Tested";
            //
            // lblNotTested15
            //
            _lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested15.AutoSize = true;
            _lblNotTested15.Location = new Point(661, 521);
            _lblNotTested15.Name = "lblNotTested15";
            _lblNotTested15.Size = new Size(67, 13);
            _lblNotTested15.TabIndex = 393;
            _lblNotTested15.Text = "Not Tested";
            //
            // lblNotTested14
            //
            _lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested14.AutoSize = true;
            _lblNotTested14.Location = new Point(661, 491);
            _lblNotTested14.Name = "lblNotTested14";
            _lblNotTested14.Size = new Size(67, 13);
            _lblNotTested14.TabIndex = 392;
            _lblNotTested14.Text = "Not Tested";
            //
            // lblNotTested13
            //
            _lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested13.AutoSize = true;
            _lblNotTested13.Location = new Point(661, 461);
            _lblNotTested13.Name = "lblNotTested13";
            _lblNotTested13.Size = new Size(67, 13);
            _lblNotTested13.TabIndex = 391;
            _lblNotTested13.Text = "Not Tested";
            //
            // UCGasWorksheet
            //
            Controls.Add(_Label23);
            Controls.Add(_txtDHWFlow);
            Controls.Add(_txtColdTemp);
            Controls.Add(_txtDHWTemp);
            Controls.Add(_txtHeadInput);
            Controls.Add(_txtInletPressure);
            Controls.Add(_txtMinBurnerPressure);
            Controls.Add(_txtMaxBurnerPressure);
            Controls.Add(_txtCO2);
            Controls.Add(_txtCO2Ration);
            Controls.Add(_txtCO2Min);
            Controls.Add(_txtCO2Max);
            Controls.Add(_cboSafety);
            Controls.Add(_Label18);
            Controls.Add(_cboServiced);
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
            Controls.Add(_cboDevice);
            Controls.Add(_Label7);
            Controls.Add(_cboProvisions);
            Controls.Add(_Label8);
            Controls.Add(_cboVisualCondition);
            Controls.Add(_Label9);
            Controls.Add(_cboFlueTermination);
            Controls.Add(_Label10);
            Controls.Add(_cboFlueSpil);
            Controls.Add(_Label3);
            Controls.Add(_cboFlueFlow);
            Controls.Add(_Label4);
            Controls.Add(_cboTested);
            Controls.Add(_Label5);
            Controls.Add(_cboLLAppliance);
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
            Name = "UCGasWorksheet";
            Size = new Size(789, 666);
            ResumeLayout(false);
            PerformLayout();
        }

        
        
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
            var argc4 = cboFlueSpil;
            Combo.SetUpCombo(ref argc4, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboFlueTermination;
            Combo.SetUpCombo(ref argc5, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboVisualCondition;
            Combo.SetUpCombo(ref argc6, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboProvisions;
            Combo.SetUpCombo(ref argc7, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboDevice;
            Combo.SetUpCombo(ref argc8, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboServiced;
            Combo.SetUpCombo(ref argc9, DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboSafety;
            Combo.SetUpCombo(ref argc10, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboSafety.Items.Add(new Combo("Visually Passed", "999999999"));
        }

        public void Populate(int ID = 0)
        {
            txtDHWFlow.Text = Worksheet.DHWFlowRate.ToString();
            txtColdTemp.Text = Worksheet.ColdWaterTemp.ToString();
            txtDHWTemp.Text = Worksheet.DHWTemp.ToString();
            txtHeadInput.Text = Worksheet.InletStaticPressure.ToString();
            txtInletPressure.Text = Worksheet.InletWorkingPressure.ToString();
            txtMinBurnerPressure.Text = Worksheet.MinBurnerPressure.ToString();
            txtMaxBurnerPressure.Text = Worksheet.MaxBurnerPressure.ToString();
            txtCO2.Text = Worksheet.CO2.ToString();
            txtCO2Ration.Text = Worksheet.CO2CORatio.ToString();
            txtCO2Min.Text = Worksheet.BMake;
            txtCO2Max.Text = Worksheet.BModel;
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboFlueFlow;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.FlueFlowTestID.ToString());
            var argcombo2 = cboFlueSpil;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.SpillageTestID.ToString());
            var argcombo3 = cboFlueTermination;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo4 = cboVisualCondition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo5 = cboProvisions;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo6 = cboDevice;
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
            cboFlueFlow.Visible = false;
            cboFlueSpil.Visible = false;
            cboFlueTermination.Visible = false;
            cboVisualCondition.Visible = false;
            cboProvisions.Visible = false;
            cboDevice.Visible = false;
            cboServiced.Visible = false;
            txtDHWFlow.Visible = false;
            txtColdTemp.Visible = false;
            txtDHWTemp.Visible = false;
            txtHeadInput.Visible = false;
            txtInletPressure.Visible = false;
            txtMinBurnerPressure.Visible = false;
            txtMaxBurnerPressure.Visible = false;
            txtCO2.Visible = false;
            txtCO2Ration.Visible = false;
            txtCO2Min.Visible = false;
            txtCO2Max.Visible = false;
        }

        private void Tested()
        {
            cboFlueFlow.Visible = true;
            cboFlueSpil.Visible = true;
            cboFlueTermination.Visible = true;
            cboVisualCondition.Visible = true;
            cboProvisions.Visible = true;
            cboDevice.Visible = true;
            cboServiced.Visible = true;
            txtDHWFlow.Visible = true;
            txtColdTemp.Visible = true;
            txtDHWTemp.Visible = true;
            txtHeadInput.Visible = true;
            txtInletPressure.Visible = true;
            txtMinBurnerPressure.Visible = true;
            txtMaxBurnerPressure.Visible = true;
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
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.Gas);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboLLAppliance);
                Worksheet.SetApplianceTestedID = Combo.get_GetSelectedItemValue(cboTested);
                if ((Combo.get_GetSelectedItemDescription(cboTested) ?? "") != "No")
                {
                    Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboFlueFlow);
                    Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboFlueSpil);
                    Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboFlueTermination);
                    Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboVisualCondition);
                    Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboProvisions);
                    Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboDevice);
                    Worksheet.SetDHWFlowRate = txtDHWFlow.Text;
                    Worksheet.SetColdWaterTemp = txtColdTemp.Text;
                    Worksheet.SetDHWTemp = txtDHWTemp.Text;
                    Worksheet.SetInletStaticPressure = txtHeadInput.Text;
                    Worksheet.SetInletWorkingPressure = txtInletPressure.Text;
                    Worksheet.SetMinBurnerPressure = txtMinBurnerPressure.Text;
                    Worksheet.SetMaxBurnerPressure = txtMaxBurnerPressure.Text;
                    Worksheet.SetCO2 = txtCO2.Text;
                    Worksheet.SetCO2CORatio = txtCO2Ration.Text;
                    Worksheet.SetBMake = txtCO2Min.Text;
                    Worksheet.SetBModel = txtCO2Max.Text;
                    Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboServiced);
                }

                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorGas();
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