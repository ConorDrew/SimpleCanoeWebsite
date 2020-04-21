using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGVisitAssetWorkSheet : FRMBaseForm
    {
        public DLGVisitAssetWorkSheet() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += DLGVisitAssetWorkSheet_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
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

        /* TODO ERROR: Skipped RegionDirectiveTrivia */    // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private ComboBox _ddReading;

        internal ComboBox ddReading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ddReading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ddReading != null)
                {
                    _ddReading.SelectedIndexChanged -= ddReading_SelectedIndexChanged;
                }

                _ddReading = value;
                if (_ddReading != null)
                {
                    _ddReading.SelectedIndexChanged += ddReading_SelectedIndexChanged;
                }
            }
        }

        private Label _lblReading;

        internal Label lblReading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblReading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblReading != null)
                {
                }

                _lblReading = value;
                if (_lblReading != null)
                {
                }
            }
        }

        private Panel _pnlUCView;

        internal Panel pnlUCView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlUCView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlUCView != null)
                {
                }

                _pnlUCView = value;
                if (_pnlUCView != null)
                {
                }
            }
        }

        private FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter _Customer_Get_ForSiteIDTableAdapter1;

        internal FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter Customer_Get_ForSiteIDTableAdapter1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Customer_Get_ForSiteIDTableAdapter1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Customer_Get_ForSiteIDTableAdapter1 != null)
                {
                }

                _Customer_Get_ForSiteIDTableAdapter1 = value;
                if (_Customer_Get_ForSiteIDTableAdapter1 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _Customer_Get_ForSiteIDTableAdapter1 = new FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter();
            _ddReading = new ComboBox();
            _ddReading.SelectedIndexChanged += new EventHandler(ddReading_SelectedIndexChanged);
            _lblReading = new Label();
            _pnlUCView = new Panel();
            SuspendLayout();
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom;
            _btnCancel.Location = new Point(193, 922);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 38;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom;
            _btnSave.Location = new Point(546, 922);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 39;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // Customer_Get_ForSiteIDTableAdapter1
            //
            _Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = true;
            //
            // ddReading
            //
            _ddReading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ddReading.DropDownStyle = ComboBoxStyle.DropDownList;
            _ddReading.Location = new Point(613, 47);
            _ddReading.Name = "ddReading";
            _ddReading.Size = new Size(188, 21);
            _ddReading.TabIndex = 47;
            //
            // lblReading
            //
            _lblReading.AutoSize = true;
            _lblReading.Location = new Point(16, 50);
            _lblReading.Name = "lblReading";
            _lblReading.Size = new Size(30, 13);
            _lblReading.TabIndex = 48;
            _lblReading.Text = "Fuel";
            //
            // pnlUCView
            //
            _pnlUCView.AutoSize = true;
            _pnlUCView.Location = new Point(12, 77);
            _pnlUCView.Name = "pnlUCView";
            _pnlUCView.Size = new Size(789, 100);
            _pnlUCView.TabIndex = 256;
            //
            // DLGVisitAssetWorkSheet
            //
            AutoScaleBaseSize = new Size(6, 14);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(813, 957);
            ControlBox = false;
            Controls.Add(_pnlUCView);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            Controls.Add(_ddReading);
            Controls.Add(_lblReading);
            Name = "DLGVisitAssetWorkSheet";
            Text = "Appliance Work Sheet";
            Controls.SetChildIndex(_lblReading, 0);
            Controls.SetChildIndex(_ddReading, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_pnlUCView, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool StopChangeTestedDD = false;
        private object ChildUserInterface = null;
        private bool _updating = true;

        public bool Updating
        {
            get
            {
                return _updating;
            }

            set
            {
                _updating = value;
            }
        }

        private Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet _Worksheet;

        public Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet Worksheet
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

        private void DLGVisitAssetWorkSheet_Load(object sender, EventArgs e)
        {
            App.ControlLoading = true;
            var argc = ddReading;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ReadingType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select_Negative);
            if (App.loggedInUser.Admin == false)
            {
                btnSave.Enabled = false;
                ddReading.Enabled = false;
                pnlUCView.Enabled = false;
            }

            if (Worksheet is object && !(Worksheet.EngineerVisitAssetWorkSheetID == 0))
            {
                var argcombo = ddReading;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Worksheet.Reading.ToString());
            }

            ShowForm();
            App.ControlLoading = false;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            var saved = default(bool);
            var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(ddReading));
            switch (switchExpr)
            {
                case (int)Enums.WorksheetFuelTypes.Gas:
                    {
                        saved = ((UCGasWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Oil:
                    {
                        saved = ((UCOilWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Solar:
                    {
                        saved = ((UCSolarWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Other:
                    {
                        saved = ((UCOtherWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.ASHP:
                    {
                        saved = ((UCASHPWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.GSHP:
                    {
                        saved = ((UCGSHPWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.SolidFuel:
                    {
                        saved = ((UCSolidWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Unvented:
                    {
                        saved = ((UCUnventedWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.ComCat:
                    {
                        saved = ((UCComercialWorksheet)ChildUserInterface).Save();
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.HIU:
                    {
                        saved = ((UCHIUWorksheet)ChildUserInterface).Save();
                        break;
                    }
            }

            if (saved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboApplianceTested_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ddReading_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowForm();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ShowForm()
        {
            var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(ddReading));
            switch (switchExpr)
            {
                case (int)Enums.WorksheetFuelTypes.Gas:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCGasWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Oil:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCOilWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Solar:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCSolarWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Other:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCOtherWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.ASHP:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCASHPWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.GSHP:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCGSHPWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.SolidFuel:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCSolidWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.Unvented:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCUnventedWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.ComCat:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCComercialWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }

                case (int)Enums.WorksheetFuelTypes.HIU:
                    {
                        pnlUCView.Controls.Clear();
                        ChildUserInterface = new UCHIUWorksheet(_Worksheet, _jobID, _EngineerVisit);
                        pnlUCView.Controls.Add((Control)ChildUserInterface);
                        break;
                    }
            }

            App.ControlLoading = false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}