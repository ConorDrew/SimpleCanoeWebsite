using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCFleetVanType : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCFleetVanType() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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

        private GroupBox _grpVan;

        internal GroupBox grpVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVan != null)
                {
                }

                _grpVan = value;
                if (_grpVan != null)
                {
                }
            }
        }

        private TextBox _txtDateIntervals;

        internal TextBox txtDateIntervals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDateIntervals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDateIntervals != null)
                {
                }

                _txtDateIntervals = value;
                if (_txtDateIntervals != null)
                {
                }
            }
        }

        private Label _lblDateIntervals;

        internal Label lblDateIntervals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDateIntervals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDateIntervals != null)
                {
                }

                _lblDateIntervals = value;
                if (_lblDateIntervals != null)
                {
                }
            }
        }

        private TextBox _txtModel;

        internal TextBox txtModel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtModel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtModel != null)
                {
                }

                _txtModel = value;
                if (_txtModel != null)
                {
                }
            }
        }

        private Label _lblModel;

        internal Label lblModel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblModel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblModel != null)
                {
                }

                _lblModel = value;
                if (_lblModel != null)
                {
                }
            }
        }

        private TextBox _txtMake;

        internal TextBox txtMake
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMake;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMake != null)
                {
                }

                _txtMake = value;
                if (_txtMake != null)
                {
                }
            }
        }

        private Label _lblMake;

        internal Label lblMake
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMake;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMake != null)
                {
                }

                _lblMake = value;
                if (_lblMake != null)
                {
                }
            }
        }

        private TextBox _txtMileageIntervals;

        internal TextBox txtMileageIntervals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMileageIntervals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMileageIntervals != null)
                {
                }

                _txtMileageIntervals = value;
                if (_txtMileageIntervals != null)
                {
                }
            }
        }

        private Label _lblMileageService;

        internal Label lblMileageService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMileageService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMileageService != null)
                {
                }

                _lblMileageService = value;
                if (_lblMileageService != null)
                {
                }
            }
        }

        private TextBox _txtPayload;

        internal TextBox txtPayload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPayload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPayload != null)
                {
                }

                _txtPayload = value;
                if (_txtPayload != null)
                {
                }
            }
        }

        private Label _lblPayLoad;

        internal Label lblPayLoad
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPayLoad;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPayLoad != null)
                {
                }

                _lblPayLoad = value;
                if (_lblPayLoad != null)
                {
                }
            }
        }

        private TextBox _txtGrossVehicleWeight;

        internal TextBox txtGrossVehicleWeight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGrossVehicleWeight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGrossVehicleWeight != null)
                {
                }

                _txtGrossVehicleWeight = value;
                if (_txtGrossVehicleWeight != null)
                {
                }
            }
        }

        private Label _lblGrossVehicleWeight;

        internal Label lblGrossVehicleWeight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGrossVehicleWeight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGrossVehicleWeight != null)
                {
                }

                _lblGrossVehicleWeight = value;
                if (_lblGrossVehicleWeight != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpVan = new GroupBox();
            _txtDateIntervals = new TextBox();
            _lblDateIntervals = new Label();
            _txtModel = new TextBox();
            _lblModel = new Label();
            _txtMake = new TextBox();
            _lblMake = new Label();
            _txtMileageIntervals = new TextBox();
            _lblMileageService = new Label();
            _txtPayload = new TextBox();
            _lblPayLoad = new Label();
            _txtGrossVehicleWeight = new TextBox();
            _lblGrossVehicleWeight = new Label();
            _grpVan.SuspendLayout();
            SuspendLayout();
            //
            // grpVan
            //
            _grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVan.Controls.Add(_txtPayload);
            _grpVan.Controls.Add(_lblPayLoad);
            _grpVan.Controls.Add(_txtGrossVehicleWeight);
            _grpVan.Controls.Add(_lblGrossVehicleWeight);
            _grpVan.Controls.Add(_txtDateIntervals);
            _grpVan.Controls.Add(_lblDateIntervals);
            _grpVan.Controls.Add(_txtModel);
            _grpVan.Controls.Add(_lblModel);
            _grpVan.Controls.Add(_txtMake);
            _grpVan.Controls.Add(_lblMake);
            _grpVan.Controls.Add(_txtMileageIntervals);
            _grpVan.Controls.Add(_lblMileageService);
            _grpVan.Location = new Point(12, 13);
            _grpVan.Name = "grpVan";
            _grpVan.Size = new Size(554, 146);
            _grpVan.TabIndex = 3;
            _grpVan.TabStop = false;
            _grpVan.Text = "Details";
            //
            // txtDateIntervals
            //
            _txtDateIntervals.Location = new Point(457, 68);
            _txtDateIntervals.MaxLength = 10;
            _txtDateIntervals.Name = "txtDateIntervals";
            _txtDateIntervals.Size = new Size(77, 21);
            _txtDateIntervals.TabIndex = 4;
            //
            // lblDateIntervals
            //
            _lblDateIntervals.Location = new Point(260, 68);
            _lblDateIntervals.Name = "lblDateIntervals";
            _lblDateIntervals.Size = new Size(191, 20);
            _lblDateIntervals.TabIndex = 51;
            _lblDateIntervals.Text = "Date Service Intervals (Months)";
            //
            // txtModel
            //
            _txtModel.Location = new Point(76, 68);
            _txtModel.MaxLength = 20;
            _txtModel.Name = "txtModel";
            _txtModel.Size = new Size(167, 21);
            _txtModel.TabIndex = 2;
            //
            // lblModel
            //
            _lblModel.Location = new Point(12, 71);
            _lblModel.Name = "lblModel";
            _lblModel.Size = new Size(58, 20);
            _lblModel.TabIndex = 49;
            _lblModel.Text = "Model";
            //
            // txtMake
            //
            _txtMake.Location = new Point(76, 30);
            _txtMake.MaxLength = 20;
            _txtMake.Name = "txtMake";
            _txtMake.Size = new Size(167, 21);
            _txtMake.TabIndex = 1;
            //
            // lblMake
            //
            _lblMake.Location = new Point(12, 33);
            _lblMake.Name = "lblMake";
            _lblMake.Size = new Size(58, 20);
            _lblMake.TabIndex = 47;
            _lblMake.Text = "Make";
            //
            // txtMileageIntervals
            //
            _txtMileageIntervals.Location = new Point(457, 30);
            _txtMileageIntervals.MaxLength = 10;
            _txtMileageIntervals.Name = "txtMileageIntervals";
            _txtMileageIntervals.Size = new Size(77, 21);
            _txtMileageIntervals.TabIndex = 3;
            //
            // lblMileageService
            //
            _lblMileageService.Location = new Point(260, 33);
            _lblMileageService.Name = "lblMileageService";
            _lblMileageService.Size = new Size(160, 20);
            _lblMileageService.TabIndex = 45;
            _lblMileageService.Text = "Mileage Service Intervals";
            //
            // txtPayload
            //
            _txtPayload.Location = new Point(457, 106);
            _txtPayload.MaxLength = 10;
            _txtPayload.Name = "txtPayload";
            _txtPayload.Size = new Size(77, 21);
            _txtPayload.TabIndex = 53;
            //
            // lblPayLoad
            //
            _lblPayLoad.Location = new Point(387, 106);
            _lblPayLoad.Name = "lblPayLoad";
            _lblPayLoad.Size = new Size(55, 20);
            _lblPayLoad.TabIndex = 55;
            _lblPayLoad.Text = "Payload";
            //
            // txtGrossVehicleWeight
            //
            _txtGrossVehicleWeight.Location = new Point(158, 106);
            _txtGrossVehicleWeight.MaxLength = 20;
            _txtGrossVehicleWeight.Name = "txtGrossVehicleWeight";
            _txtGrossVehicleWeight.Size = new Size(85, 21);
            _txtGrossVehicleWeight.TabIndex = 52;
            //
            // lblGrossVehicleWeight
            //
            _lblGrossVehicleWeight.Location = new Point(12, 109);
            _lblGrossVehicleWeight.Name = "lblGrossVehicleWeight";
            _lblGrossVehicleWeight.Size = new Size(140, 20);
            _lblGrossVehicleWeight.TabIndex = 54;
            _lblGrossVehicleWeight.Text = "Gross Vehicle Weight";
            //
            // UCFleetVanType
            //
            BackColor = Color.White;
            Controls.Add(_grpVan);
            Name = "UCFleetVanType";
            Size = new Size(580, 171);
            _grpVan.ResumeLayout(false);
            _grpVan.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentVanType;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private int oldDepartment = 0;
        private Entity.FleetVans.FleetVanType _currentVanType;

        public Entity.FleetVans.FleetVanType CurrentVanType
        {
            get
            {
                return _currentVanType;
            }

            set
            {
                _currentVanType = value;
                if (_currentVanType is null)
                {
                    _currentVanType = new Entity.FleetVans.FleetVanType();
                    _currentVanType.Exists = false;
                }
            }
        }

        private void UCVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // Public Sub PopulateQuantities(ByVal VanID As Integer)
        // PartQuantitiesDataview = DB.Part.PartLocations_GetForVanHM(VanID)
        // End Sub

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentVanType = App.DB.FleetVanType.Get(ID);
            }

            txtMake.Text = CurrentVanType.Make;
            txtModel.Text = CurrentVanType.Model;
            txtMileageIntervals.Text = CurrentVanType.MileageServiceInterval.ToString();
            txtDateIntervals.Text = CurrentVanType.DateServiceInterval.ToString();
            txtGrossVehicleWeight.Text = CurrentVanType.GrossVehicleWeight.ToString();
            txtPayload.Text = CurrentVanType.Payload.ToString();
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentVanType.IgnoreExceptionsOnSetMethods = true;
                CurrentVanType.SetMake = txtMake.Text.Trim();
                CurrentVanType.SetModel = txtModel.Text.Trim();
                CurrentVanType.SetMileageServiceInterval = txtMileageIntervals.Text.Trim();
                CurrentVanType.SetDateServiceInterval = txtDateIntervals.Text.Trim();
                CurrentVanType.SetGrossVehicleWeight = Math.Round(Entity.Sys.Helper.MakeDoubleValid(txtGrossVehicleWeight.Text), 2);
                CurrentVanType.SetPayload = Math.Round(Entity.Sys.Helper.MakeDoubleValid(txtPayload.Text), 2);
                var cV = new Entity.FleetVans.FleetVanTypeValidator();
                cV.Validate(CurrentVanType);
                if (CurrentVanType.Exists)
                {
                    App.DB.FleetVanType.Update(CurrentVanType);
                }
                else
                {
                    CurrentVanType = App.DB.FleetVanType.Insert(CurrentVanType);
                }

                App.MainForm.RefreshEntity(CurrentVanType.VanTypeID);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}