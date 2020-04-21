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
    public class UCHIUWorksheet : UCBase, IUserControl
    {
        public UCHIUWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
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
        private TextBox _txtResults;

        internal TextBox txtResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _txtResults = value;
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

        private ComboBox _cboSystemOperation;

        internal ComboBox cboSystemOperation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSystemOperation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSystemOperation = value;
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

        private ComboBox _cboInspectPumps;

        internal ComboBox cboInspectPumps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInspectPumps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboInspectPumps = value;
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

        private ComboBox _cboCleanStrainers;

        internal ComboBox cboCleanStrainers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCleanStrainers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboCleanStrainers = value;
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

        private ComboBox _cboCleanPortValue;

        internal ComboBox cboCleanPortValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCleanPortValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboCleanPortValue = value;
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

        private ComboBox _cboLeaksPressure;

        internal ComboBox cboLeaksPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLeaksPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboLeaksPressure = value;
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtResults = new TextBox();
            _cboSafety = new ComboBox();
            _Label18 = new Label();
            _cboServiced = new ComboBox();
            _Label19 = new Label();
            _Label15 = new Label();
            _cboSystemOperation = new ComboBox();
            _Label8 = new Label();
            _cboInspectPumps = new ComboBox();
            _Label9 = new Label();
            _cboCleanStrainers = new ComboBox();
            _Label10 = new Label();
            _cboCleanPortValue = new ComboBox();
            _Label3 = new Label();
            _cboLeaksPressure = new ComboBox();
            _Label4 = new Label();
            _cboLLAppliance = new ComboBox();
            _Label2 = new Label();
            _cboAppliance = new ComboBox();
            _Label1 = new Label();
            _lblNotTested1 = new Label();
            _lblNotTested2 = new Label();
            _lblNotTested3 = new Label();
            _lblNotTested5 = new Label();
            _lblNotTested4 = new Label();
            _lblNotTested10 = new Label();
            _lblNotTested18 = new Label();
            SuspendLayout();
            //
            // txtResults
            //
            _txtResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtResults.Location = new Point(601, 259);
            _txtResults.Name = "txtResults";
            _txtResults.Size = new Size(188, 21);
            _txtResults.TabIndex = 13;
            //
            // cboSafety
            //
            _cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSafety.Location = new Point(601, 330);
            _cboSafety.Name = "cboSafety";
            _cboSafety.Size = new Size(188, 21);
            _cboSafety.TabIndex = 22;
            //
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Location = new Point(3, 333);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(101, 13);
            _Label18.TabIndex = 365;
            _Label18.Text = "Appliance safety";
            //
            // cboServiced
            //
            _cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboServiced.Location = new Point(601, 294);
            _cboServiced.Name = "cboServiced";
            _cboServiced.Size = new Size(188, 21);
            _cboServiced.TabIndex = 21;
            //
            // Label19
            //
            _Label19.AutoSize = true;
            _Label19.Location = new Point(3, 297);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(181, 13);
            _Label19.TabIndex = 363;
            _Label19.Text = "Appliance service or inspected";
            //
            // Label15
            //
            _Label15.AutoSize = true;
            _Label15.Location = new Point(3, 263);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(103, 13);
            _Label15.TabIndex = 354;
            _Label15.Text = "Recorded results";
            //
            // cboSystemOperation
            //
            _cboSystemOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSystemOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSystemOperation.Location = new Point(601, 222);
            _cboSystemOperation.Name = "cboSystemOperation";
            _cboSystemOperation.Size = new Size(188, 21);
            _cboSystemOperation.TabIndex = 8;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(3, 225);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(376, 13);
            _Label8.TabIndex = 348;
            _Label8.Text = "Check the system operation parameters and record your results";
            //
            // cboInspectPumps
            //
            _cboInspectPumps.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboInspectPumps.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInspectPumps.Location = new Point(601, 187);
            _cboInspectPumps.Name = "cboInspectPumps";
            _cboInspectPumps.Size = new Size(188, 21);
            _cboInspectPumps.TabIndex = 7;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(3, 190);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(223, 13);
            _Label9.TabIndex = 346;
            _Label9.Text = "Inspect the functionality of the pumps";
            //
            // cboCleanStrainers
            //
            _cboCleanStrainers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCleanStrainers.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCleanStrainers.Location = new Point(601, 152);
            _cboCleanStrainers.Name = "cboCleanStrainers";
            _cboCleanStrainers.Size = new Size(188, 21);
            _cboCleanStrainers.TabIndex = 6;
            //
            // Label10
            //
            _Label10.AutoSize = true;
            _Label10.Location = new Point(3, 155);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(178, 13);
            _Label10.TabIndex = 344;
            _Label10.Text = "Check and clean the strainers";
            //
            // cboCleanPortValue
            //
            _cboCleanPortValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCleanPortValue.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCleanPortValue.Location = new Point(601, 117);
            _cboCleanPortValue.Name = "cboCleanPortValue";
            _cboCleanPortValue.Size = new Size(188, 21);
            _cboCleanPortValue.TabIndex = 5;
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(3, 120);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(192, 13);
            _Label3.TabIndex = 342;
            _Label3.Text = "Check and clean the port valves";
            //
            // cboLeaksPressure
            //
            _cboLeaksPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboLeaksPressure.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLeaksPressure.Location = new Point(601, 82);
            _cboLeaksPressure.Name = "cboLeaksPressure";
            _cboLeaksPressure.Size = new Size(188, 21);
            _cboLeaksPressure.TabIndex = 4;
            //
            // Label4
            //
            _Label4.Location = new Point(3, 85);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(492, 30);
            _Label4.TabIndex = 340;
            _Label4.Text = "Check for leaks and pressure drops in both the primary and secondary sides of the" + " heading exchanger";
            //
            // cboLLAppliance
            //
            _cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLLAppliance.Location = new Point(601, 45);
            _cboLLAppliance.Name = "cboLLAppliance";
            _cboLLAppliance.Size = new Size(188, 21);
            _cboLLAppliance.TabIndex = 2;
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(3, 48);
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
            _lblNotTested1.Location = new Point(661, 85);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 379;
            _lblNotTested1.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(661, 120);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 380;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(661, 155);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 381;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(661, 226);
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
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(661, 262);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 388;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested18
            //
            _lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested18.AutoSize = true;
            _lblNotTested18.Location = new Point(661, 297);
            _lblNotTested18.Name = "lblNotTested18";
            _lblNotTested18.Size = new Size(67, 13);
            _lblNotTested18.TabIndex = 396;
            _lblNotTested18.Text = "Not Tested";
            //
            // UCHIUWorksheet
            //
            Controls.Add(_txtResults);
            Controls.Add(_cboSafety);
            Controls.Add(_Label18);
            Controls.Add(_cboServiced);
            Controls.Add(_Label19);
            Controls.Add(_Label15);
            Controls.Add(_cboSystemOperation);
            Controls.Add(_Label8);
            Controls.Add(_cboInspectPumps);
            Controls.Add(_Label9);
            Controls.Add(_cboCleanStrainers);
            Controls.Add(_Label10);
            Controls.Add(_cboCleanPortValue);
            Controls.Add(_Label3);
            Controls.Add(_cboLeaksPressure);
            Controls.Add(_Label4);
            Controls.Add(_cboLLAppliance);
            Controls.Add(_Label2);
            Controls.Add(_cboAppliance);
            Controls.Add(_Label1);
            Controls.Add(_lblNotTested18);
            Controls.Add(_lblNotTested10);
            Controls.Add(_lblNotTested5);
            Controls.Add(_lblNotTested4);
            Controls.Add(_lblNotTested3);
            Controls.Add(_lblNotTested2);
            Controls.Add(_lblNotTested1);
            Name = "UCHIUWorksheet";
            Size = new Size(789, 382);
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
            var argc2 = cboLeaksPressure;
            Combo.SetUpCombo(ref argc2, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboCleanPortValue;
            Combo.SetUpCombo(ref argc3, DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboCleanStrainers;
            Combo.SetUpCombo(ref argc4, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboInspectPumps;
            Combo.SetUpCombo(ref argc5, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboSystemOperation;
            Combo.SetUpCombo(ref argc6, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboServiced;
            Combo.SetUpCombo(ref argc7, DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboSafety;
            Combo.SetUpCombo(ref argc8, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboSafety.Items.Add(new Combo("Visually Passed", "999999999"));
        }

        public void Populate(int ID = 0)
        {
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboLLAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.LandlordsApplianceID.ToString());
            var argcombo2 = cboLeaksPressure;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.FlueFlowTestID.ToString());
            var argcombo3 = cboCleanPortValue;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.SpillageTestID.ToString());
            var argcombo4 = cboCleanStrainers;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo5 = cboInspectPumps;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo6 = cboSystemOperation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            txtResults.Text = Worksheet.Nozzle;
            var argcombo7 = cboServiced;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo8 = cboSafety;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.ApplianceSafeID.ToString());
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.HIU);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboLLAppliance);
                Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboLeaksPressure);
                Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboCleanPortValue);
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboCleanStrainers);
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboInspectPumps);
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboSystemOperation);
                Worksheet.SetNozzle = txtResults.Text;
                Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboServiced);
                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboSafety);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorHIU();
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