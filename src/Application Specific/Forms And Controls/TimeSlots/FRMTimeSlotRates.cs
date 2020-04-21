using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMTimeSlotRates : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMTimeSlotRates() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMTimeSlotRates_Load;

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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private DataGrid _dgTimeslots;

        internal DataGrid dgTimeslots
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTimeslots;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTimeslots != null)
                {
                }

                _dgTimeslots = value;
                if (_dgTimeslots != null)
                {
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

        private GroupBox _gpbTimeslots;

        internal GroupBox gpbTimeslots
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbTimeslots;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbTimeslots != null)
                {
                }

                _gpbTimeslots = value;
                if (_gpbTimeslots != null)
                {
                }
            }
        }

        private TabPage _tabTimeSlots;

        internal TabPage tabTimeSlots
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabTimeSlots;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabTimeSlots != null)
                {
                }

                _tabTimeSlots = value;
                if (_tabTimeSlots != null)
                {
                }
            }
        }

        private TabPage _tabBankHolidays;

        internal TabPage tabBankHolidays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabBankHolidays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabBankHolidays != null)
                {
                }

                _tabBankHolidays = value;
                if (_tabBankHolidays != null)
                {
                }
            }
        }

        private GroupBox _gpbBankHolidays;

        internal GroupBox gpbBankHolidays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbBankHolidays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbBankHolidays != null)
                {
                }

                _gpbBankHolidays = value;
                if (_gpbBankHolidays != null)
                {
                }
            }
        }

        private DataGrid _dgBankHolidays;

        internal DataGrid dgBankHolidays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgBankHolidays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgBankHolidays != null)
                {
                }

                _dgBankHolidays = value;
                if (_dgBankHolidays != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _gpbTimeslots = new GroupBox();
            _dgTimeslots = new DataGrid();
            _TabControl1 = new TabControl();
            _tabTimeSlots = new TabPage();
            _tabBankHolidays = new TabPage();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _gpbBankHolidays = new GroupBox();
            _dgBankHolidays = new DataGrid();
            _gpbTimeslots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimeslots).BeginInit();
            _TabControl1.SuspendLayout();
            _tabTimeSlots.SuspendLayout();
            _tabBankHolidays.SuspendLayout();
            _gpbBankHolidays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgBankHolidays).BeginInit();
            SuspendLayout();
            //
            // gpbTimeslots
            //
            _gpbTimeslots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbTimeslots.Controls.Add(_dgTimeslots);
            _gpbTimeslots.Location = new Point(8, 8);
            _gpbTimeslots.Name = "gpbTimeslots";
            _gpbTimeslots.Size = new Size(680, 256);
            _gpbTimeslots.TabIndex = 0;
            _gpbTimeslots.TabStop = false;
            _gpbTimeslots.Text = "Time Slot Charge Rates";
            //
            // dgTimeslots
            //
            _dgTimeslots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTimeslots.DataMember = "";
            _dgTimeslots.HeaderForeColor = SystemColors.ControlText;
            _dgTimeslots.Location = new Point(10, 21);
            _dgTimeslots.Name = "dgTimeslots";
            _dgTimeslots.Size = new Size(661, 227);
            _dgTimeslots.TabIndex = 0;
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tabTimeSlots);
            _TabControl1.Controls.Add(_tabBankHolidays);
            _TabControl1.Location = new Point(0, 48);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(704, 296);
            _TabControl1.TabIndex = 1;
            //
            // tabTimeSlots
            //
            _tabTimeSlots.Controls.Add(_gpbTimeslots);
            _tabTimeSlots.Location = new Point(4, 22);
            _tabTimeSlots.Name = "tabTimeSlots";
            _tabTimeSlots.Size = new Size(696, 270);
            _tabTimeSlots.TabIndex = 0;
            _tabTimeSlots.Text = "Time Slot Charge Rates";
            //
            // tabBankHolidays
            //
            _tabBankHolidays.Controls.Add(_gpbBankHolidays);
            _tabBankHolidays.Location = new Point(4, 22);
            _tabBankHolidays.Name = "tabBankHolidays";
            _tabBankHolidays.Size = new Size(696, 270);
            _tabBankHolidays.TabIndex = 1;
            _tabBankHolidays.Text = "Bank Holidays";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(616, 352);
            _btnSave.Name = "btnSave";
            _btnSave.TabIndex = 2;
            _btnSave.Text = "&Save";
            //
            // gpbBankHolidays
            //
            _gpbBankHolidays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbBankHolidays.Controls.Add(_dgBankHolidays);
            _gpbBankHolidays.Location = new Point(8, 7);
            _gpbBankHolidays.Name = "gpbBankHolidays";
            _gpbBankHolidays.Size = new Size(680, 256);
            _gpbBankHolidays.TabIndex = 1;
            _gpbBankHolidays.TabStop = false;
            _gpbBankHolidays.Text = "Bank Holiday Rates";
            //
            // dgBankHolidays
            //
            _dgBankHolidays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgBankHolidays.DataMember = "";
            _dgBankHolidays.HeaderForeColor = SystemColors.ControlText;
            _dgBankHolidays.Location = new Point(10, 22);
            _dgBankHolidays.Name = "dgBankHolidays";
            _dgBankHolidays.Size = new Size(661, 226);
            _dgBankHolidays.TabIndex = 0;
            //
            // FRMTimeSlotRates
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(704, 390);
            Controls.Add(_btnSave);
            Controls.Add(_TabControl1);
            Name = "FRMTimeSlotRates";
            Text = "Time Slot Rates";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_TabControl1, 0);
            Controls.SetChildIndex(_btnSave, 0);
            _gpbTimeslots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgTimeslots).EndInit();
            _TabControl1.ResumeLayout(false);
            _tabTimeSlots.ResumeLayout(false);
            _tabBankHolidays.ResumeLayout(false);
            _gpbBankHolidays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgBankHolidays).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            LabourTypesDataview = App.DB.TimeSlotRates.LabourTypes_Get();
            SetupBankHolidayDataGrid();
            SetupRatesDataGrid();
            Populate();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvRates;

        private DataView RatesDataview
        {
            get
            {
                return _dvRates;
            }

            set
            {
                _dvRates = value;
                _dvRates.AllowNew = false;
                _dvRates.AllowEdit = true;
                _dvRates.AllowDelete = false;
                _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString();
                dgTimeslots.DataSource = RatesDataview;
            }
        }

        private DataView _dvBankHoliday;

        private DataView BankHolidayDataview
        {
            get
            {
                return _dvBankHoliday;
            }

            set
            {
                _dvBankHoliday = value;
                _dvBankHoliday.AllowNew = true;
                _dvBankHoliday.AllowEdit = true;
                _dvBankHoliday.AllowDelete = false;
                _dvBankHoliday.Table.TableName = Entity.Sys.Enums.TableNames.tblBankHolidays.ToString();
                dgBankHolidays.DataSource = BankHolidayDataview;
            }
        }

        private DataView _dvLabourTypes;

        private DataView LabourTypesDataview
        {
            get
            {
                return _dvLabourTypes;
            }

            set
            {
                _dvLabourTypes = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupRatesDataGrid()
        {
            var tbStyle = dgTimeslots.TableStyles[0];
            var Timeslot = new DataGridLabelColumn();
            Timeslot.Format = "HH:mm";
            Timeslot.FormatInfo = null;
            Timeslot.HeaderText = "Timeslot";
            Timeslot.MappingName = "Timeslot";
            Timeslot.ReadOnly = false;
            Timeslot.Width = 75;
            Timeslot.NullText = "";
            tbStyle.GridColumnStyles.Add(Timeslot);
            var Monday = new DataGridComboBoxColumn();
            Monday.HeaderText = "Monday";
            Monday.MappingName = "Monday";
            Monday.ReadOnly = false;
            Monday.Width = 90;
            Monday.ComboBox.DataSource = LabourTypesDataview;
            Monday.ComboBox.DisplayMember = "LabourType";
            Monday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Monday);
            var Tuesday = new DataGridComboBoxColumn();
            Tuesday.HeaderText = "Tuesday";
            Tuesday.MappingName = "Tuesday";
            Tuesday.ReadOnly = false;
            Tuesday.Width = 90;
            Tuesday.ComboBox.DataSource = LabourTypesDataview;
            Tuesday.ComboBox.DisplayMember = "LabourType";
            Tuesday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Tuesday);
            var Wednesday = new DataGridComboBoxColumn();
            Wednesday.HeaderText = "Wednesday";
            Wednesday.MappingName = "Wednesday";
            Wednesday.ReadOnly = false;
            Wednesday.Width = 90;
            Wednesday.ComboBox.DataSource = LabourTypesDataview;
            Wednesday.ComboBox.DisplayMember = "LabourType";
            Wednesday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Wednesday);
            var Thursday = new DataGridComboBoxColumn();
            Thursday.HeaderText = "Thursday";
            Thursday.MappingName = "Thursday";
            Thursday.ReadOnly = false;
            Thursday.Width = 90;
            Thursday.ComboBox.DataSource = LabourTypesDataview;
            Thursday.ComboBox.DisplayMember = "LabourType";
            Thursday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Thursday);
            var Friday = new DataGridComboBoxColumn();
            Friday.HeaderText = "Friday";
            Friday.MappingName = "Friday";
            Friday.ReadOnly = false;
            Friday.Width = 90;
            Friday.ComboBox.DataSource = LabourTypesDataview;
            Friday.ComboBox.DisplayMember = "LabourType";
            Friday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Friday);
            var Saturday = new DataGridComboBoxColumn();
            Saturday.HeaderText = "Saturday";
            Saturday.MappingName = "Saturday";
            Saturday.ReadOnly = false;
            Saturday.Width = 90;
            Saturday.ComboBox.DataSource = LabourTypesDataview;
            Saturday.ComboBox.DisplayMember = "LabourType";
            Saturday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Saturday);
            var Sunday = new DataGridComboBoxColumn();
            Sunday.HeaderText = "Sunday";
            Sunday.MappingName = "Sunday";
            Sunday.ReadOnly = false;
            Sunday.Width = 90;
            Sunday.ComboBox.DataSource = LabourTypesDataview;
            Sunday.ComboBox.DisplayMember = "LabourType";
            Sunday.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(Sunday);
            tbStyle.AllowSorting = false;
            tbStyle.ReadOnly = false;
            dgTimeslots.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString();
            dgTimeslots.TableStyles.Add(tbStyle);
        }

        public void SetupBankHolidayDataGrid()
        {
            var tbStyle = dgBankHolidays.TableStyles[0];
            var BankHolidayDate = new DataGridEditableTextBoxColumn();
            BankHolidayDate.Format = "dd/MM/yyyy";
            BankHolidayDate.FormatInfo = null;
            BankHolidayDate.HeaderText = "Bank Holiday Date";
            BankHolidayDate.MappingName = "BankHolidayDate";
            BankHolidayDate.ReadOnly = false;
            BankHolidayDate.Width = 150;
            BankHolidayDate.NullText = "";
            tbStyle.GridColumnStyles.Add(BankHolidayDate);
            var LabourRateID = new DataGridComboBoxColumn();
            LabourRateID.HeaderText = "Labour Rate";
            LabourRateID.MappingName = "LabourRateID";
            LabourRateID.ReadOnly = false;
            LabourRateID.Width = 150;
            LabourRateID.ComboBox.DataSource = LabourTypesDataview;
            LabourRateID.ComboBox.DisplayMember = "LabourType";
            LabourRateID.ComboBox.ValueMember = "LabourTypeID";
            tbStyle.GridColumnStyles.Add(LabourRateID);
            tbStyle.AllowSorting = false;
            tbStyle.ReadOnly = false;
            dgBankHolidays.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblBankHolidays.ToString();
            dgBankHolidays.TableStyles.Add(tbStyle);
        }

        private void FRMTimeSlotRates_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void Populate()
        {
            RatesDataview = App.DB.TimeSlotRates.GetAll();
            BankHolidayDataview = App.DB.TimeSlotRates.BankHolidays_GetAll();
        }

        private void Save()
        {
            foreach (DataRow dr in RatesDataview.Table.Rows)
                App.DB.TimeSlotRates.Update(Conversions.ToInteger(dr["UniqueID"]), Conversions.ToInteger(dr["Monday"]), Conversions.ToInteger(dr["Tuesday"]), Conversions.ToInteger(dr["Wednesday"]), Conversions.ToInteger(dr["Thursday"]), Conversions.ToInteger(dr["Friday"]), Conversions.ToInteger(dr["Saturday"]), Conversions.ToInteger(dr["Sunday"]));

            foreach (DataRow bankHoliday in BankHolidayDataview.Table.Rows)
            {
                if (Entity.Sys.Helper.MakeIntegerValid(bankHoliday["LabourRateID"]) == 0)
                {
                    bankHoliday["LabourRateID"] = Entity.Sys.Enums.LabourTypes.Double;
                }

                if (Entity.Sys.Helper.MakeIntegerValid(bankHoliday["bankHolidayID"]) == 0)
                {
                    App.DB.TimeSlotRates.BankHolidays_Insert(Conversions.ToDate(bankHoliday["bankHolidayDate"]), Conversions.ToInteger(bankHoliday["LabourRateID"]));
                }
                else
                {
                    App.DB.TimeSlotRates.BankHolidays_Update(Conversions.ToDate(bankHoliday["bankHolidayDate"]), Conversions.ToInteger(bankHoliday["LabourRateID"]), Conversions.ToInteger(bankHoliday["bankHolidayID"]));
                }
            }

            Populate();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}