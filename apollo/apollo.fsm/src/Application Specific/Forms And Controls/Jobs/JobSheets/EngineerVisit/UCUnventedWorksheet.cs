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
    public class UCUnventedWorksheet : UCBase, IUserControl
    {
        public UCUnventedWorksheet(EngineerVisitAssetWorkSheet worksheet, int jobID, Entity.EngineerVisits.EngineerVisit EngineerVisit) : base()
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

        private ComboBox _cboServiceRecord;

        internal ComboBox cboServiceRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboServiceRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboServiceRecord = value;
            }
        }

        private ComboBox _cboWaterPressure;

        internal ComboBox cboWaterPressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboWaterPressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboWaterPressure = value;
            }
        }

        private ComboBox _cboScaledUp;

        internal ComboBox cboScaledUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboScaledUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboScaledUp = value;
            }
        }

        private ComboBox _cboTundish;

        internal ComboBox cboTundish
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTundish;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboTundish = value;
            }
        }

        private ComboBox _cboExpansionGap;

        internal ComboBox cboExpansionGap
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExpansionGap;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboExpansionGap = value;
            }
        }

        private ComboBox _cboSacrificialAnode;

        internal ComboBox cboSacrificialAnode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSacrificialAnode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboSacrificialAnode = value;
            }
        }

        private ComboBox _cboFilterStrainerCheck;

        internal ComboBox cboFilterStrainerCheck
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFilterStrainerCheck;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboFilterStrainerCheck = value;
            }
        }

        private ComboBox _cboPrechargePressure;

        internal ComboBox cboPrechargePressure
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPrechargePressure;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboPrechargePressure = value;
            }
        }

        private ComboBox _cboIntegrity;

        internal ComboBox cboIntegrity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboIntegrity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboIntegrity = value;
            }
        }

        private ComboBox _cboPressureDownstream;

        internal ComboBox cboPressureDownstream
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPressureDownstream;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboPressureDownstream = value;
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

        private Label _Label47;

        private Label _Label55;

        private Label _Label56;

        private Label _Label57;

        private Label _Label58;

        private Label _Label59;

        private Label _Label60;

        private Label _Label61;

        private Label _Label62;

        private Label _Label63;

        private Label _Label64;

        private Label _Label65;

        private Label _Label66;

        private ComboBox _cboExpansionReliefValve;

        internal ComboBox cboExpansionReliefValve
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExpansionReliefValve;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboExpansionReliefValve = value;
            }
        }

        private ComboBox _cboPressureReliefValve;

        internal ComboBox cboPressureReliefValve
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPressureReliefValve;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboPressureReliefValve = value;
            }
        }

        private ComboBox _cboDischargePipes;

        internal ComboBox cboDischargePipes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDischargePipes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _cboDischargePipes = value;
            }
        }

        private Label _lblNotTested10;

        private Label _lblNotTested9;

        private Label _lblNotTested8;

        private Label _lblNotTested7;

        private Label _lblNotTested6;

        private Label _lblNotTested5;

        private Label _lblNotTested4;

        private Label _lblNotTested3;

        private Label _lblNotTested2;

        private Label _lblNotTested1;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _cboServiceRecord = new ComboBox();
            _cboWaterPressure = new ComboBox();
            _cboScaledUp = new ComboBox();
            _cboTundish = new ComboBox();
            _cboExpansionGap = new ComboBox();
            _cboSacrificialAnode = new ComboBox();
            _cboFilterStrainerCheck = new ComboBox();
            _cboPrechargePressure = new ComboBox();
            _cboIntegrity = new ComboBox();
            _cboPressureDownstream = new ComboBox();
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
            _Label64 = new Label();
            _Label65 = new Label();
            _Label66 = new Label();
            _cboExpansionReliefValve = new ComboBox();
            _cboPressureReliefValve = new ComboBox();
            _cboDischargePipes = new ComboBox();
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
            // cboServiceRecord
            //
            _cboServiceRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboServiceRecord.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboServiceRecord.Location = new Point(601, 463);
            _cboServiceRecord.Name = "cboServiceRecord";
            _cboServiceRecord.Size = new Size(188, 21);
            _cboServiceRecord.TabIndex = 14;
            //
            // cboWaterPressure
            //
            _cboWaterPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboWaterPressure.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboWaterPressure.Location = new Point(601, 428);
            _cboWaterPressure.Name = "cboWaterPressure";
            _cboWaterPressure.Size = new Size(188, 21);
            _cboWaterPressure.TabIndex = 13;
            //
            // cboScaledUp
            //
            _cboScaledUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboScaledUp.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScaledUp.Location = new Point(601, 287);
            _cboScaledUp.Name = "cboScaledUp";
            _cboScaledUp.Size = new Size(188, 21);
            _cboScaledUp.TabIndex = 9;
            //
            // cboTundish
            //
            _cboTundish.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboTundish.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTundish.Location = new Point(601, 252);
            _cboTundish.Name = "cboTundish";
            _cboTundish.Size = new Size(188, 21);
            _cboTundish.TabIndex = 8;
            //
            // cboExpansionGap
            //
            _cboExpansionGap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboExpansionGap.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExpansionGap.Location = new Point(601, 218);
            _cboExpansionGap.Name = "cboExpansionGap";
            _cboExpansionGap.Size = new Size(188, 21);
            _cboExpansionGap.TabIndex = 7;
            //
            // cboSacrificialAnode
            //
            _cboSacrificialAnode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSacrificialAnode.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSacrificialAnode.Location = new Point(601, 183);
            _cboSacrificialAnode.Name = "cboSacrificialAnode";
            _cboSacrificialAnode.Size = new Size(188, 21);
            _cboSacrificialAnode.TabIndex = 6;
            //
            // cboFilterStrainerCheck
            //
            _cboFilterStrainerCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboFilterStrainerCheck.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFilterStrainerCheck.Location = new Point(601, 148);
            _cboFilterStrainerCheck.Name = "cboFilterStrainerCheck";
            _cboFilterStrainerCheck.Size = new Size(188, 21);
            _cboFilterStrainerCheck.TabIndex = 5;
            //
            // cboPrechargePressure
            //
            _cboPrechargePressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboPrechargePressure.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPrechargePressure.Location = new Point(601, 113);
            _cboPrechargePressure.Name = "cboPrechargePressure";
            _cboPrechargePressure.Size = new Size(188, 21);
            _cboPrechargePressure.TabIndex = 4;
            //
            // cboIntegrity
            //
            _cboIntegrity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboIntegrity.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboIntegrity.Location = new Point(601, 79);
            _cboIntegrity.Name = "cboIntegrity";
            _cboIntegrity.Size = new Size(188, 21);
            _cboIntegrity.TabIndex = 3;
            //
            // cboPressureDownstream
            //
            _cboPressureDownstream.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboPressureDownstream.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPressureDownstream.Location = new Point(601, 45);
            _cboPressureDownstream.Name = "cboPressureDownstream";
            _cboPressureDownstream.Size = new Size(188, 21);
            _cboPressureDownstream.TabIndex = 2;
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
            _Label46.Location = new Point(3, 466);
            _Label46.Name = "Label46";
            _Label46.Size = new Size(306, 13);
            _Label46.TabIndex = 348;
            _Label46.Text = "Complete service record/Benchmark log if Available";
            //
            // Label47
            //
            _Label47.AutoSize = true;
            _Label47.Location = new Point(3, 431);
            _Label47.Name = "Label47";
            _Label47.Size = new Size(326, 13);
            _Label47.TabIndex = 347;
            _Label47.Text = "Check water pressure and flow rates at terminal fittings";
            //
            // Label55
            //
            _Label55.Location = new Point(3, 396);
            _Label55.Name = "Label55";
            _Label55.Size = new Size(568, 30);
            _Label55.TabIndex = 346;
            _Label55.Text = "Manually lift the lever to operate the expansion relief valve. Check that it open" + "s, water discharges satisfactorily then closes and reseals correctly. If there i" + "s any doubt, replace the valve";
            //
            // Label56
            //
            _Label56.Location = new Point(3, 361);
            _Label56.Name = "Label56";
            _Label56.Size = new Size(546, 30);
            _Label56.TabIndex = 345;
            _Label56.Text = "Manually Lift the lever to operate the temperature and pressure relief valve. Che" + "ck that it opens, water discharges satisfactory then close and reseals correctly" + ". if there is any doubt replace valves";
            //
            // Label57
            //
            _Label57.Location = new Point(3, 325);
            _Label57.Name = "Label57";
            _Label57.Size = new Size(546, 31);
            _Label57.TabIndex = 344;
            _Label57.Text = "Check discharge pipes D1 and D2 for blockages or obstructions. Check water discha" + "rges from termination point and the termination is correctly positioned";
            //
            // Label58
            //
            _Label58.AutoSize = true;
            _Label58.Location = new Point(3, 290);
            _Label58.Name = "Label58";
            _Label58.Size = new Size(226, 13);
            _Label58.TabIndex = 343;
            _Label58.Text = "Ensure the connection is not scaled up";
            //
            // Label59
            //
            _Label59.AutoSize = true;
            _Label59.Location = new Point(3, 255);
            _Label59.Name = "Label59";
            _Label59.Size = new Size(408, 13);
            _Label59.TabIndex = 342;
            _Label59.Text = "Check tundish is visible and no water passing from the safety controls";
            //
            // Label60
            //
            _Label60.Location = new Point(3, 221);
            _Label60.Name = "Label60";
            _Label60.Size = new Size(546, 29);
            _Label60.TabIndex = 341;
            _Label60.Text = "If system has internal type expansion facility, re-set expansion gap whilst testi" + "ng the temperature/pressure relief valve";
            //
            // Label61
            //
            _Label61.AutoSize = true;
            _Label61.Location = new Point(3, 186);
            _Label61.Name = "Label61";
            _Label61.Size = new Size(400, 13);
            _Label61.TabIndex = 340;
            _Label61.Text = "Visually inspect sacrificial anode if applicable and renew if necessary";
            //
            // Label62
            //
            _Label62.AutoSize = true;
            _Label62.Location = new Point(3, 151);
            _Label62.Name = "Label62";
            _Label62.Size = new Size(458, 13);
            _Label62.TabIndex = 339;
            _Label62.Text = "Remove and Visibly inspect the filter/strainer and thoroughly clean as required";
            //
            // Label63
            //
            _Label63.Location = new Point(3, 116);
            _Label63.Name = "Label63";
            _Label63.Size = new Size(546, 30);
            _Label63.TabIndex = 338;
            _Label63.Text = "Check pre-charge pressure in expansion vessel and top up as necessary or if water" + " is leaking from schrader valve, replace expansion vessel";
            //
            // Label64
            //
            _Label64.AutoSize = true;
            _Label64.Location = new Point(3, 82);
            _Label64.Name = "Label64";
            _Label64.Size = new Size(303, 13);
            _Label64.TabIndex = 337;
            _Label64.Text = "Check integrity of cylinder for leaks or damage etc.";
            //
            // Label65
            //
            _Label65.Location = new Point(3, 48);
            _Label65.Name = "Label65";
            _Label65.Size = new Size(546, 29);
            _Label65.TabIndex = 336;
            _Label65.Text = "Check water pressure downstream of pressure reducing/limiting valve, adjust or re" + "palace the valve if pressure is too high";
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
            // cboExpansionReliefValve
            //
            _cboExpansionReliefValve.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboExpansionReliefValve.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExpansionReliefValve.Location = new Point(601, 391);
            _cboExpansionReliefValve.Name = "cboExpansionReliefValve";
            _cboExpansionReliefValve.Size = new Size(188, 21);
            _cboExpansionReliefValve.TabIndex = 12;
            //
            // cboPressureReliefValve
            //
            _cboPressureReliefValve.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboPressureReliefValve.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPressureReliefValve.Location = new Point(601, 356);
            _cboPressureReliefValve.Name = "cboPressureReliefValve";
            _cboPressureReliefValve.Size = new Size(188, 21);
            _cboPressureReliefValve.TabIndex = 11;
            //
            // cboDischargePipes
            //
            _cboDischargePipes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboDischargePipes.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDischargePipes.Location = new Point(601, 322);
            _cboDischargePipes.Name = "cboDischargePipes";
            _cboDischargePipes.Size = new Size(188, 21);
            _cboDischargePipes.TabIndex = 10;
            //
            // lblNotTested10
            //
            _lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested10.AutoSize = true;
            _lblNotTested10.Location = new Point(656, 430);
            _lblNotTested10.Name = "lblNotTested10";
            _lblNotTested10.Size = new Size(67, 13);
            _lblNotTested10.TabIndex = 416;
            _lblNotTested10.Text = "Not Tested";
            //
            // lblNotTested9
            //
            _lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested9.AutoSize = true;
            _lblNotTested9.Location = new Point(656, 395);
            _lblNotTested9.Name = "lblNotTested9";
            _lblNotTested9.Size = new Size(67, 13);
            _lblNotTested9.TabIndex = 415;
            _lblNotTested9.Text = "Not Tested";
            //
            // lblNotTested8
            //
            _lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested8.AutoSize = true;
            _lblNotTested8.Location = new Point(656, 360);
            _lblNotTested8.Name = "lblNotTested8";
            _lblNotTested8.Size = new Size(67, 13);
            _lblNotTested8.TabIndex = 414;
            _lblNotTested8.Text = "Not Tested";
            //
            // lblNotTested7
            //
            _lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested7.AutoSize = true;
            _lblNotTested7.Location = new Point(656, 325);
            _lblNotTested7.Name = "lblNotTested7";
            _lblNotTested7.Size = new Size(67, 13);
            _lblNotTested7.TabIndex = 413;
            _lblNotTested7.Text = "Not Tested";
            //
            // lblNotTested6
            //
            _lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested6.AutoSize = true;
            _lblNotTested6.Location = new Point(656, 291);
            _lblNotTested6.Name = "lblNotTested6";
            _lblNotTested6.Size = new Size(67, 13);
            _lblNotTested6.TabIndex = 412;
            _lblNotTested6.Text = "Not Tested";
            //
            // lblNotTested5
            //
            _lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested5.AutoSize = true;
            _lblNotTested5.Location = new Point(656, 256);
            _lblNotTested5.Name = "lblNotTested5";
            _lblNotTested5.Size = new Size(67, 13);
            _lblNotTested5.TabIndex = 411;
            _lblNotTested5.Text = "Not Tested";
            //
            // lblNotTested4
            //
            _lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested4.AutoSize = true;
            _lblNotTested4.Location = new Point(656, 221);
            _lblNotTested4.Name = "lblNotTested4";
            _lblNotTested4.Size = new Size(67, 13);
            _lblNotTested4.TabIndex = 410;
            _lblNotTested4.Text = "Not Tested";
            //
            // lblNotTested3
            //
            _lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested3.AutoSize = true;
            _lblNotTested3.Location = new Point(656, 186);
            _lblNotTested3.Name = "lblNotTested3";
            _lblNotTested3.Size = new Size(67, 13);
            _lblNotTested3.TabIndex = 409;
            _lblNotTested3.Text = "Not Tested";
            //
            // lblNotTested2
            //
            _lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested2.AutoSize = true;
            _lblNotTested2.Location = new Point(656, 151);
            _lblNotTested2.Name = "lblNotTested2";
            _lblNotTested2.Size = new Size(67, 13);
            _lblNotTested2.TabIndex = 408;
            _lblNotTested2.Text = "Not Tested";
            //
            // lblNotTested1
            //
            _lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblNotTested1.AutoSize = true;
            _lblNotTested1.Location = new Point(656, 116);
            _lblNotTested1.Name = "lblNotTested1";
            _lblNotTested1.Size = new Size(67, 13);
            _lblNotTested1.TabIndex = 407;
            _lblNotTested1.Text = "Not Tested";
            //
            // UCUnventedWorksheet
            //
            Controls.Add(_cboExpansionReliefValve);
            Controls.Add(_cboPressureReliefValve);
            Controls.Add(_cboDischargePipes);
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
            Controls.Add(_Label64);
            Controls.Add(_Label65);
            Controls.Add(_Label66);
            Controls.Add(_cboServiceRecord);
            Controls.Add(_cboWaterPressure);
            Controls.Add(_cboScaledUp);
            Controls.Add(_cboTundish);
            Controls.Add(_cboExpansionGap);
            Controls.Add(_cboSacrificialAnode);
            Controls.Add(_cboFilterStrainerCheck);
            Controls.Add(_cboPrechargePressure);
            Controls.Add(_cboIntegrity);
            Controls.Add(_cboPressureDownstream);
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
            Name = "UCUnventedWorksheet";
            Size = new Size(789, 511);
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
            var argc = cboExpansionReliefValve;
            Combo.SetUpCombo(ref argc, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cboAppliance;
            Combo.SetUpCombo(ref argc1, App.DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
            var argc2 = cboPressureDownstream;
            Combo.SetUpCombo(ref argc2, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboIntegrity;
            Combo.SetUpCombo(ref argc3, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboPrechargePressure;
            Combo.SetUpCombo(ref argc4, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboFilterStrainerCheck;
            Combo.SetUpCombo(ref argc5, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboSacrificialAnode;
            Combo.SetUpCombo(ref argc6, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboExpansionGap;
            Combo.SetUpCombo(ref argc7, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboTundish;
            Combo.SetUpCombo(ref argc8, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboScaledUp;
            Combo.SetUpCombo(ref argc9, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc10 = cboWaterPressure;
            Combo.SetUpCombo(ref argc10, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc11 = cboServiceRecord;
            Combo.SetUpCombo(ref argc11, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            cboServiceRecord.Items.Add(new Combo("Visually Passed", "999999999"));
            var argc12 = cboDischargePipes;
            Combo.SetUpCombo(ref argc12, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc13 = cboPressureReliefValve;
            Combo.SetUpCombo(ref argc13, DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
        }

        public void Populate(int ID = 0)
        {
            var argcombo = cboAppliance;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.AssetID.ToString());
            var argcombo1 = cboPrechargePressure;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Worksheet.SpillageTestID.ToString());
            var argcombo2 = cboFilterStrainerCheck;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Worksheet.FlueTerminationSatisfactoryID.ToString());
            var argcombo3 = cboSacrificialAnode;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, Worksheet.VisualConditionOfFlueSatisfactoryID.ToString());
            var argcombo4 = cboExpansionGap;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, Worksheet.VentilationProvisionSatisfactoryID.ToString());
            var argcombo5 = cboTundish;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, Worksheet.SafetyDeviceOperationID.ToString());
            var argcombo6 = cboScaledUp;
            Combo.SetSelectedComboItem_By_Value(ref argcombo6, Worksheet.SweepOutcomeID.ToString());
            var argcombo7 = cboWaterPressure;
            Combo.SetSelectedComboItem_By_Value(ref argcombo7, Worksheet.ApplianceServiceOrInspectedID.ToString());
            var argcombo8 = cboServiceRecord;
            Combo.SetSelectedComboItem_By_Value(ref argcombo8, Worksheet.ApplianceSafeID.ToString());
            var argcombo9 = cboPressureDownstream;
            Combo.SetSelectedComboItem_By_Value(ref argcombo9, Worksheet.LandlordsApplianceID.ToString());
            var argcombo10 = cboIntegrity;
            Combo.SetSelectedComboItem_By_Value(ref argcombo10, Worksheet.FlueFlowTestID.ToString());
            var argcombo11 = cboExpansionReliefValve;
            Combo.SetSelectedComboItem_By_Value(ref argcombo11, Worksheet.TankID.ToString()); // setddtank
            var argcombo12 = cboDischargePipes;
            Combo.SetSelectedComboItem_By_Value(ref argcombo12, Worksheet.OverallID.ToString());
            var argcombo13 = cboPressureReliefValve;
            Combo.SetSelectedComboItem_By_Value(ref argcombo13, Worksheet.DischargeID.ToString());
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Worksheet.SetReading = Conversions.ToInteger(Enums.WorksheetFuelTypes.Unvented);
                Worksheet.SetAssetID = Combo.get_GetSelectedItemValue(cboAppliance);
                Worksheet.SetLandlordsApplianceID = Combo.get_GetSelectedItemValue(cboPressureDownstream);
                Worksheet.SetFlueFlowTestID = Combo.get_GetSelectedItemValue(cboIntegrity);
                Worksheet.SetSpillageTestID = Combo.get_GetSelectedItemValue(cboPrechargePressure);
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.get_GetSelectedItemValue(cboFilterStrainerCheck);
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.get_GetSelectedItemValue(cboSacrificialAnode);
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.get_GetSelectedItemValue(cboExpansionGap);
                Worksheet.SetSafetyDeviceOperationID = Combo.get_GetSelectedItemValue(cboTundish);
                Worksheet.SetSweepOutcomeID = Combo.get_GetSelectedItemValue(cboScaledUp);
                Worksheet.SetOverallID = Combo.get_GetSelectedItemValue(cboDischargePipes);
                Worksheet.SetDischargeID = Combo.get_GetSelectedItemValue(cboPressureReliefValve);
                Worksheet.SetTankID = Combo.get_GetSelectedItemValue(cboExpansionReliefValve); // setddtank
                Worksheet.SetApplianceServiceOrInspectedID = Combo.get_GetSelectedItemValue(cboWaterPressure);
                Worksheet.SetApplianceSafeID = Combo.get_GetSelectedItemValue(cboServiceRecord);
                Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new EngineerVisitAssetWorkSheetValidatorUnvented();
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