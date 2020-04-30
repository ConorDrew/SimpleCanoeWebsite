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
    public class UCASHPWorksheet : UCBase, IUserControl
    {
        public UCASHPWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
            DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA).Table;
            DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced).Table;
            DtYesNoNa = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table;
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
                _cboServiced = value;
            }
        }

        private ComboBox _cboSafetyDeviceOperation;

        internal ComboBox cboSafetyDeviceOperation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSafetyDeviceOperation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSafetyDeviceOperation = value;
            }
        }

        private ComboBox _cboVentilation;

        internal ComboBox cboVentilation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVentilation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboVentilation = value;
            }
        }

        private ComboBox _cboStability;

        internal ComboBox cboStability
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStability;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboStability = value;
            }
        }

        private ComboBox _cboSafetyDevices;

        internal ComboBox cboSafetyDevices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSafetyDevices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSafetyDevices = value;
            }
        }

        private ComboBox _cboOperation;

        internal ComboBox cboOperation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOperation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboOperation = value;
            }
        }

        private ComboBox _cboPressureTest;

        internal ComboBox cboPressureTest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPressureTest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboPressureTest = value;
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
                _cboLLAppliance = value;
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
                _Label46 = value;
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
                _Label47 = value;
            }
        }

        private Label _Label55;

        internal Label Label55
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label55;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label55 = value;
            }
        }

        private Label _Label56;

        internal Label Label56
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label56;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label56 = value;
            }
        }

        private Label _Label57;

        internal Label Label57
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label57;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label57 = value;
            }
        }

        private Label _Label58;

        internal Label Label58
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label58;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label58 = value;
            }
        }

        private Label _Label59;

        internal Label Label59
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label59;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label59 = value;
            }
        }

        private Label _Label60;

        internal Label Label60
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label60;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label60 = value;
            }
        }

        private Label _Label61;

        internal Label Label61
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label61;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label61 = value;
            }
        }

        private Label _Label62;

        internal Label Label62
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label62;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label62 = value;
            }
        }

        private Label _Label63;

        internal Label Label63
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label63;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label63 = value;
            }
        }

        private Label _Label65;

        internal Label Label65
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label65;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label65 = value;
            }
        }

        private Label _Label66;

        internal Label Label66
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label66;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label66 = value;
            }
        }

        private ComboBox _cboGlycol;

        internal ComboBox cboGlycol
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGlycol;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboGlycol = value;
            }
        }

        private ComboBox _cboCondition;

        internal ComboBox cboCondition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCondition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboCondition = value;
            }
        }

        private ComboBox _cboLegionella;

        internal ComboBox cboLegionella
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLegionella;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboLegionella = value;
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _cboSafety = new ComboBox();
            _cboServiced = new ComboBox();
            _cboSafetyDeviceOperation = new ComboBox();
            _cboVentilation = new ComboBox();
            _cboStability = new ComboBox();
            _cboSafetyDevices = new ComboBox();
            _cboOperation = new ComboBox();
            _cboPressureTest = new ComboBox();
            _cboLLAppliance = new ComboBox();
            _cboAppliance = new ComboBox();
            _Label46 = new Label();
            _Label47 = new Label();
            _Label55 = new Label();
            _Label56 = new Label();
            _Label57 = new Label();
            _Label58 = new Label();
            _Label59 = new Label();
            _Label60 = new Label();
            _Label61 = new Label();
            _Label62 = new Label();
            _Label63 = new Label();
            _Label65 = new Label();
            _Label66 = new Label();
            _cboGlycol = new ComboBox();
            _cboCondition = new ComboBox();
            _cboLegionella = new ComboBox();
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
            // cboSafety
            //
            _cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafety.Location = new Point(601, 369);
            _cboSafety.Name = "cboSafety";
            _cboSafety.Size = new Size(188, 21);
            _cboSafety.TabIndex = 14;
            //
            // cboServiced
            //
            _cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboServiced.Location = new Point(601, 339);
            _cboServiced.Name = "cboServiced";
            _cboServiced.Size = new Size(188, 21);
            _cboServiced.TabIndex = 13;
            //
            // cboSafetyDeviceOperation
            //
            _cboSafetyDeviceOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafetyDeviceOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafetyDeviceOperation.Location = new Point(601, 218);
            _cboSafetyDeviceOperation.Name = "cboSafetyDeviceOperation";
            _cboSafetyDeviceOperation.Size = new Size(188, 21);
            _cboSafetyDeviceOperation.TabIndex = 9;
            //
            // cboVentilation
            //
            _cboVentilation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboVentilation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVentilation.Location = new Point(601, 188);
            _cboVentilation.Name = "cboVentilation";
            _cboVentilation.Size = new Size(188, 21);
            _cboVentilation.TabIndex = 8;
            //
            // cboStability
            //
            _cboStability.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboStability.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStability.Location = new Point(601, 159);
            _cboStability.Name = "cboStability";
            _cboStability.Size = new Size(188, 21);
            _cboStability.TabIndex = 7;
            //
            // cboSafetyDevices
            //
            _cboSafetyDevices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafetyDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafetyDevices.Location = new Point(601, 129);
            _cboSafetyDevices.Name = "cboSafetyDevices";
            _cboSafetyDevices.Size = new Size(188, 21);
            _cboSafetyDevices.TabIndex = 6;
            //
            // cboOperation
            //
            _cboOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOperation.Location = new Point(601, 99);
            _cboOperation.Name = "cboOperation";
            _cboOperation.Size = new Size(188, 21);
            _cboOperation.TabIndex = 5;
            //
            // cboPressureTest
            //
            _cboPressureTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboPressureTest.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPressureTest.Location = new Point(601, 69);
            _cboPressureTest.Name = "cboPressureTest";
            _cboPressureTest.Size = new Size(188, 21);
            _cboPressureTest.TabIndex = 4;
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
            // Label46
            //
            _Label46.AutoSize = true;
            _Label46.Location = new Point(3, 372);
            _Label46.Name = "Label46";
            _Label46.Size = new Size(101, 13);
            _Label46.TabIndex = 348;
            _Label46.Text = "Appliance safety";
            //
            // Label47
            //
            _Label47.AutoSize = true;
            _Label47.Location = new Point(3, 342);
            _Label47.Name = "Label47";
            _Label47.Size = new Size(181, 13);
            _Label47.TabIndex = 347;
            _Label47.Text = "Appliance service or inspected";
            //
            // Label55
            //
            _Label55.AutoSize = true;
            _Label55.Location = new Point(3, 312);
            _Label55.Name = "Label55";
            _Label55.Size = new Size(42, 13);
            _Label55.TabIndex = 346;
            _Label55.Text = "Glycol";
            //
            // Label56
            //
            _Label56.AutoSize = true;
            _Label56.Location = new Point(3, 282);
            _Label56.Name = "Label56";
            _Label56.Size = new Size(106, 13);
            _Label56.TabIndex = 345;
            _Label56.Text = "Overall Condition";
            //
            // Label57
            //
            _Label57.AutoSize = true;
            _Label57.Location = new Point(3, 251);
            _Label57.Name = "Label57";
            _Label57.Size = new Size(102, 13);
            _Label57.TabIndex = 344;
            _Label57.Text = "Legionella active";
            //
            // Label58
            //
            _Label58.AutoSize = true;
            _Label58.Location = new Point(3, 221);
            _Label58.Name = "Label58";
            _Label58.Size = new Size(143, 13);
            _Label58.TabIndex = 343;
            _Label58.Text = "Safety device operation";
            //
            // Label59
            //
            _Label59.AutoSize = true;
            _Label59.Location = new Point(3, 191);
            _Label59.Name = "Label59";
            _Label59.Size = new Size(52, 13);
            _Label59.TabIndex = 342;
            _Label59.Text = "Free Air";
            //
            // Label60
            //
            _Label60.AutoSize = true;
            _Label60.Location = new Point(3, 162);
            _Label60.Name = "Label60";
            _Label60.Size = new Size(53, 13);
            _Label60.TabIndex = 341;
            _Label60.Text = "Stability";
            //
            // Label61
            //
            _Label61.AutoSize = true;
            _Label61.Location = new Point(3, 132);
            _Label61.Name = "Label61";
            _Label61.Size = new Size(91, 13);
            _Label61.TabIndex = 340;
            _Label61.Text = "Safety devices";
            //
            // Label62
            //
            _Label62.AutoSize = true;
            _Label62.Location = new Point(3, 102);
            _Label62.Name = "Label62";
            _Label62.Size = new Size(63, 13);
            _Label62.TabIndex = 339;
            _Label62.Text = "Operation";
            //
            // Label63
            //
            _Label63.AutoSize = true;
            _Label63.Location = new Point(3, 72);
            _Label63.Name = "Label63";
            _Label63.Size = new Size(84, 13);
            _Label63.TabIndex = 338;
            _Label63.Text = "Pressure Test";
            //
            // Label65
            //
            _Label65.AutoSize = true;
            _Label65.Location = new Point(3, 43);
            _Label65.Name = "Label65";
            _Label65.Size = new Size(125, 13);
            _Label65.TabIndex = 336;
            _Label65.Text = "Landlords Appliance ";
            //
            // Label66
            //
            _Label66.AutoSize = true;
            _Label66.Location = new Point(3, 13);
            _Label66.Name = "Label66";
            _Label66.Size = new Size(62, 13);
            _Label66.TabIndex = 335;
            _Label66.Text = "Appliance";
            //
            // cboGlycol
            //
            _cboGlycol.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboGlycol.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGlycol.Location = new Point(601, 307);
            _cboGlycol.Name = "cboGlycol";
            _cboGlycol.Size = new Size(188, 21);
            _cboGlycol.TabIndex = 12;
            //
            // cboCondition
            //
            _cboCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCondition.Location = new Point(601, 277);
            _cboCondition.Name = "cboCondition";
            _cboCondition.Size = new Size(188, 21);
            _cboCondition.TabIndex = 11;
            //
            // cboLegionella
            //
            _cboLegionella.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboLegionella.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLegionella.Location = new Point(601, 248);
            _cboLegionella.Name = "cboLegionella";
            _cboLegionella.Size = new Size(188, 21);
            _cboLegionella.TabIndex = 10;
            //
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(660, 341);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 406;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested9
            //
            _lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested9.AutoSize = true;
            _lblNotTested9.Location = new Point(660, 311);
            _lblNotTested9.Name = "lblNotTested9";
            _lblNotTested9.Size = new Size(67, 13);
            _lblNotTested9.TabIndex = 405;
            _lblNotTested9.Text = "Not Tested";
            //
            // lblNotTested8
            //
            _lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested8.AutoSize = true;
            _lblNotTested8.Location = new Point(660, 281);
            _lblNotTested8.Name = "lblNotTested8";
            _lblNotTested8.Size = new Size(67, 13);
            _lblNotTested8.TabIndex = 404;
            _lblNotTested8.Text = "Not Tested";
            //
            // lblNotTested7
            //
            _lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested7.AutoSize = true;
            _lblNotTested7.Location = new Point(660, 251);
            _lblNotTested7.Name = "lblNotTested7";
            _lblNotTested7.Size = new Size(67, 13);
            _lblNotTested7.TabIndex = 403;
            _lblNotTested7.Text = "Not Tested";
            //
            // lblNotTested6
            //
            _lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested6.AutoSize = true;
            _lblNotTested6.Location = new Point(660, 222);
            _lblNotTested6.Name = "lblNotTested6";
            _lblNotTested6.Size = new Size(67, 13);
            _lblNotTested6.TabIndex = 402;
            _lblNotTested6.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(660, 192);
            _lblNotTested5.Name = "lblNotTested5";
            _lblNotTested5.Size = new Size(67, 13);
            _lblNotTested5.TabIndex = 401;
            _lblNotTested5.Text = "Not Tested";
            //
            // lblNotTested4
            //
            _lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested4.AutoSize = true;
            _lblNotTested4.Location = new Point(660, 162);
            _lblNotTested4.Name = "lblNotTested4";
            _lblNotTested4.Size = new Size(67, 13);
            _lblNotTested4.TabIndex = 400;
            _lblNotTested4.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(660, 132);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 399;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(660, 102);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 398;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested1
            //
            _lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested1.AutoSize = true;
            _lblNotTested1.Location = new Point(660, 72);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 397;
            _lblNotTested1.Text = "Not Tested";
            //
            // UCASHPWorksheet
            //
            Controls.Add(_cboGlycol);
            Controls.Add(_cboCondition);
            Controls.Add(_cboLegionella);
            Controls.Add(_Label46);
            Controls.Add(_Label47);
            Controls.Add(_Label55);
            Controls.Add(_Label56);
            Controls.Add(_Label57);
            Controls.Add(_Label58);
            Controls.Add(_Label59);
            Controls.Add(_Label60);
            Controls.Add(_Label61);
            Controls.Add(_Label62);
            Controls.Add(_Label63);
            Controls.Add(_Label65);
            Controls.Add(_Label66);
            Controls.Add(_cboSafety);
            Controls.Add(_cboServiced);
            Controls.Add(_cboSafetyDeviceOperation);
            Controls.Add(_cboVentilation);
            Controls.Add(_cboStability);
            Controls.Add(_cboSafetyDevices);
            Controls.Add(_cboOperation);
            Controls.Add(_cboPressureTest);
            Controls.Add(_cboLLAppliance);
            Controls.Add(_cboAppliance);
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
            Name = "UCASHPWorksheet";
            Size = new Size(789, 407);
            ResumeLayout(false);
            PerformLayout();
        }

        
        
        private DataTable DtPassFailNa = null;
        private DataTable DtNotTestedPassFail = null;
        private DataTable DtApplianceServiced = null;
        private DataTable DtYesNo = null;
        private DataTable DtPassFail = null;
        private DataTable DtYesNoNa = null;
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
            var argc2 = cboPressureTest;
            Combo.SetUpCombo(ref argc2, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboOperation;
            Combo.SetUpCombo(ref argc3, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboSafetyDevices;
            Combo.SetUpCombo(ref argc4, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboStability;
            Combo.SetUpCombo(ref argc5, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboVentilation;
            Combo.SetUpCombo(ref argc6, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboSafetyDeviceOperation;
            Combo.SetUpCombo(ref argc7, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboServiced;
            Combo.SetUpCombo(ref argc8, DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboSafety;
            Combo.SetUpCombo(ref argc9, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboSafety.Items.Add(new Combo("Visually Passed", "999999999"));
            var argc10 = cboGlycol;
            Combo.SetUpCombo(ref argc10, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc11 = cboLegionella;
            Combo.SetUpCombo(ref argc11, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc12 = cboCondition;
            Combo.SetUpCombo(ref argc12, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
        }

        public void Populate(int ID = 0)
        {
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboPressureTest;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.FlueFlowTestID.ToString());
            var argcombo2 = cboOperation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.SpillageTestID.ToString());
            var argcombo3 = cboSafetyDevices;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo4 = cboStability;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo5 = cboVentilation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo6 = cboSafetyDeviceOperation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.SafetyDeviceOperationID.ToString());
            var argcombo7 = cboServiced;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo8 = cboSafety;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.ApplianceSafeID.ToString());
            var argcombo9 = cboLLAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo9, Worksheet.LandlordsApplianceID.ToString());
            var argcombo10 = cboGlycol;
            Combo.SetSelectedComboItem_By_Value(ref argcombo10, Worksheet.DischargeID.ToString());
            var argcombo11 = cboLegionella;
            Combo.SetSelectedComboItem_By_Value(ref argcombo11, Worksheet.SweepOutcomeID.ToString());
            var argcombo12 = cboCondition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo12, Worksheet.OverallID.ToString());
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.ASHP);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboLLAppliance);
                Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboPressureTest);
                Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboOperation);
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboSafetyDevices);
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboStability);
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboVentilation);
                Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboSafetyDeviceOperation);
                Worksheet.SetSweepOutcomeID = Combo.get_GetSelectedItemValue(cboLegionella);
                Worksheet.SetOverallID = Combo.get_GetSelectedItemValue(cboCondition);
                Worksheet.SetDischargeID = Combo.get_GetSelectedItemValue(cboGlycol);
                Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboServiced);
                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorASHP();
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