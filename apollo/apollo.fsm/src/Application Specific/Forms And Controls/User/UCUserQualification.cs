using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCUserQualification : UCBase, IUserControl
    {
        public UCUserQualification() : base()
        {
            base.Load += UCUserQualification_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboQualificationType;
            Combo.SetUpCombo(ref argc, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboQualification;
            Combo.SetUpComboQual(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpDetails;

        private Label _lblEmail;

        internal Label lblEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmail != null)
                {
                }

                _lblEmail = value;
                if (_lblEmail != null)
                {
                }
            }
        }

        private TextBox _txtEmailAddress;

        internal TextBox txtEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmailAddress != null)
                {
                }

                _txtEmailAddress = value;
                if (_txtEmailAddress != null)
                {
                }
            }
        }

        private TextBox _txtFullName;

        internal TextBox txtFullName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFullName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFullName != null)
                {
                }

                _txtFullName = value;
                if (_txtFullName != null)
                {
                }
            }
        }

        private Label _lblFullName;

        internal Label lblFullName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFullName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFullName != null)
                {
                }

                _lblFullName = value;
                if (_lblFullName != null)
                {
                }
            }
        }

        private GroupBox _grpUserQualifications;

        internal GroupBox grpUserQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpUserQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpUserQualifications != null)
                {
                }

                _grpUserQualifications = value;
                if (_grpUserQualifications != null)
                {
                }
            }
        }

        private Panel _pnlQualifications;

        internal Panel pnlQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlQualifications != null)
                {
                }

                _pnlQualifications = value;
                if (_pnlQualifications != null)
                {
                }
            }
        }

        private ComboBox _cboQualificationType;

        internal ComboBox cboQualificationType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualificationType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualificationType != null)
                {
                    _cboQualificationType.SelectedIndexChanged -= cboQualificationType_SelectedIndexChanged;
                }

                _cboQualificationType = value;
                if (_cboQualificationType != null)
                {
                    _cboQualificationType.SelectedIndexChanged += cboQualificationType_SelectedIndexChanged;
                }
            }
        }

        private Label _lblQualificationType;

        internal Label lblQualificationType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualificationType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualificationType != null)
                {
                }

                _lblQualificationType = value;
                if (_lblQualificationType != null)
                {
                }
            }
        }

        private DateTimePicker _dtpQualificationBooked;

        internal DateTimePicker dtpQualificationBooked
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationBooked;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationBooked != null)
                {
                }

                _dtpQualificationBooked = value;
                if (_dtpQualificationBooked != null)
                {
                }
            }
        }

        private Label _lblBooked;

        internal Label lblBooked
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBooked;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBooked != null)
                {
                }

                _lblBooked = value;
                if (_lblBooked != null)
                {
                }
            }
        }

        private ComboBox _cboQualification;

        internal ComboBox cboQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualification != null)
                {
                }

                _cboQualification = value;
                if (_cboQualification != null)
                {
                }
            }
        }

        private Label _lblQualification;

        internal Label lblQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualification != null)
                {
                }

                _lblQualification = value;
                if (_lblQualification != null)
                {
                }
            }
        }

        private TextBox _txtQualificatioNote;

        internal TextBox txtQualificatioNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQualificatioNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQualificatioNote != null)
                {
                }

                _txtQualificatioNote = value;
                if (_txtQualificatioNote != null)
                {
                }
            }
        }

        private Label _lblNote;

        internal Label lblNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNote != null)
                {
                }

                _lblNote = value;
                if (_lblNote != null)
                {
                }
            }
        }

        private DateTimePicker _dtpQualificationExpires;

        internal DateTimePicker dtpQualificationExpires
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationExpires;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationExpires != null)
                {
                }

                _dtpQualificationExpires = value;
                if (_dtpQualificationExpires != null)
                {
                }
            }
        }

        private Label _lblExpiry;

        internal Label lblExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblExpiry != null)
                {
                }

                _lblExpiry = value;
                if (_lblExpiry != null)
                {
                }
            }
        }

        private DateTimePicker _dtpQualificationPassed;

        internal DateTimePicker dtpQualificationPassed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQualificationPassed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQualificationPassed != null)
                {
                }

                _dtpQualificationPassed = value;
                if (_dtpQualificationPassed != null)
                {
                }
            }
        }

        private Label _lblPassed;

        internal Label lblPassed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPassed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPassed != null)
                {
                }

                _lblPassed = value;
                if (_lblPassed != null)
                {
                }
            }
        }

        private Button _btnRemoveTrainingQualifications;

        internal Button btnRemoveTrainingQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveTrainingQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveTrainingQualifications != null)
                {
                    _btnRemoveTrainingQualifications.Click -= btnRemoveTrainingQualifications_Click;
                }

                _btnRemoveTrainingQualifications = value;
                if (_btnRemoveTrainingQualifications != null)
                {
                    _btnRemoveTrainingQualifications.Click += btnRemoveTrainingQualifications_Click;
                }
            }
        }

        private DataGrid _dgTrainingQualifications;

        internal DataGrid dgTrainingQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTrainingQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTrainingQualifications != null)
                {
                    _dgTrainingQualifications.Click -= dgTrainingQualifications_Click;
                    _dgTrainingQualifications.CurrentCellChanged -= dgTrainingQualifications_Click;
                }

                _dgTrainingQualifications = value;
                if (_dgTrainingQualifications != null)
                {
                    _dgTrainingQualifications.Click += dgTrainingQualifications_Click;
                    _dgTrainingQualifications.CurrentCellChanged += dgTrainingQualifications_Click;
                }
            }
        }

        private Button _btnSaveQualification;

        internal Button btnSaveQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveQualification != null)
                {
                    _btnSaveQualification.Click -= btnSaveQualification_Click;
                }

                _btnSaveQualification = value;
                if (_btnSaveQualification != null)
                {
                    _btnSaveQualification.Click += btnSaveQualification_Click;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpDetails = new GroupBox();
            _lblEmail = new Label();
            _txtEmailAddress = new TextBox();
            _txtFullName = new TextBox();
            _lblFullName = new Label();
            _grpUserQualifications = new GroupBox();
            _pnlQualifications = new Panel();
            _btnSaveQualification = new Button();
            _btnSaveQualification.Click += new EventHandler(btnSaveQualification_Click);
            _cboQualificationType = new ComboBox();
            _cboQualificationType.SelectedIndexChanged += new EventHandler(cboQualificationType_SelectedIndexChanged);
            _lblQualificationType = new Label();
            _dtpQualificationBooked = new DateTimePicker();
            _lblBooked = new Label();
            _cboQualification = new ComboBox();
            _lblQualification = new Label();
            _txtQualificatioNote = new TextBox();
            _lblNote = new Label();
            _dtpQualificationExpires = new DateTimePicker();
            _lblExpiry = new Label();
            _dtpQualificationPassed = new DateTimePicker();
            _lblPassed = new Label();
            _btnRemoveTrainingQualifications = new Button();
            _btnRemoveTrainingQualifications.Click += new EventHandler(btnRemoveTrainingQualifications_Click);
            _dgTrainingQualifications = new DataGrid();
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.Click += new EventHandler(dgTrainingQualifications_Click);
            _dgTrainingQualifications.CurrentCellChanged += new EventHandler(dgTrainingQualifications_Click);
            _grpDetails.SuspendLayout();
            _grpUserQualifications.SuspendLayout();
            _pnlQualifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTrainingQualifications).BeginInit();
            SuspendLayout();
            //
            // grpDetails
            //
            _grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpDetails.Controls.Add(_lblEmail);
            _grpDetails.Controls.Add(_txtEmailAddress);
            _grpDetails.Controls.Add(_txtFullName);
            _grpDetails.Controls.Add(_lblFullName);
            _grpDetails.FlatStyle = FlatStyle.System;
            _grpDetails.Location = new Point(12, 19);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(606, 95);
            _grpDetails.TabIndex = 37;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            //
            // lblEmail
            //
            _lblEmail.AutoSize = true;
            _lblEmail.Location = new Point(9, 54);
            _lblEmail.Name = "lblEmail";
            _lblEmail.Size = new Size(38, 13);
            _lblEmail.TabIndex = 16;
            _lblEmail.Text = "Email";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(127, 51);
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(454, 21);
            _txtEmailAddress.TabIndex = 15;
            //
            // txtFullName
            //
            _txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFullName.Location = new Point(127, 24);
            _txtFullName.MaxLength = 255;
            _txtFullName.Name = "txtFullName";
            _txtFullName.Size = new Size(454, 21);
            _txtFullName.TabIndex = 4;
            //
            // lblFullName
            //
            _lblFullName.Location = new Point(8, 24);
            _lblFullName.Name = "lblFullName";
            _lblFullName.Size = new Size(64, 16);
            _lblFullName.TabIndex = 5;
            _lblFullName.Text = "Full Name";
            //
            // grpUserQualifications
            //
            _grpUserQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpUserQualifications.Controls.Add(_pnlQualifications);
            _grpUserQualifications.Controls.Add(_btnRemoveTrainingQualifications);
            _grpUserQualifications.Controls.Add(_dgTrainingQualifications);
            _grpUserQualifications.Location = new Point(12, 128);
            _grpUserQualifications.Name = "grpUserQualifications";
            _grpUserQualifications.Size = new Size(606, 538);
            _grpUserQualifications.TabIndex = 38;
            _grpUserQualifications.TabStop = false;
            _grpUserQualifications.Text = "Training && Qualifications";
            //
            // pnlQualifications
            //
            _pnlQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pnlQualifications.Controls.Add(_btnSaveQualification);
            _pnlQualifications.Controls.Add(_cboQualificationType);
            _pnlQualifications.Controls.Add(_lblQualificationType);
            _pnlQualifications.Controls.Add(_dtpQualificationBooked);
            _pnlQualifications.Controls.Add(_lblBooked);
            _pnlQualifications.Controls.Add(_cboQualification);
            _pnlQualifications.Controls.Add(_lblQualification);
            _pnlQualifications.Controls.Add(_txtQualificatioNote);
            _pnlQualifications.Controls.Add(_lblNote);
            _pnlQualifications.Controls.Add(_dtpQualificationExpires);
            _pnlQualifications.Controls.Add(_lblExpiry);
            _pnlQualifications.Controls.Add(_dtpQualificationPassed);
            _pnlQualifications.Controls.Add(_lblPassed);
            _pnlQualifications.Location = new Point(5, 20);
            _pnlQualifications.Name = "pnlQualifications";
            _pnlQualifications.Size = new Size(593, 222);
            _pnlQualifications.TabIndex = 42;
            //
            // btnSaveQualification
            //
            _btnSaveQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveQualification.Location = new Point(445, 196);
            _btnSaveQualification.Name = "btnSaveQualification";
            _btnSaveQualification.Size = new Size(137, 23);
            _btnSaveQualification.TabIndex = 56;
            _btnSaveQualification.Text = "Add / Update";
            //
            // cboQualificationType
            //
            _cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualificationType.Location = new Point(139, 5);
            _cboQualificationType.Name = "cboQualificationType";
            _cboQualificationType.Size = new Size(443, 21);
            _cboQualificationType.TabIndex = 54;
            _cboQualificationType.Text = "ComboBox1";
            //
            // lblQualificationType
            //
            _lblQualificationType.Location = new Point(7, 5);
            _lblQualificationType.Name = "lblQualificationType";
            _lblQualificationType.Size = new Size(126, 23);
            _lblQualificationType.TabIndex = 55;
            _lblQualificationType.Text = "Qualification Type";
            //
            // dtpQualificationBooked
            //
            _dtpQualificationBooked.Checked = false;
            _dtpQualificationBooked.Location = new Point(332, 68);
            _dtpQualificationBooked.Name = "dtpQualificationBooked";
            _dtpQualificationBooked.ShowCheckBox = true;
            _dtpQualificationBooked.Size = new Size(152, 21);
            _dtpQualificationBooked.TabIndex = 52;
            //
            // lblBooked
            //
            _lblBooked.Location = new Point(269, 74);
            _lblBooked.Name = "lblBooked";
            _lblBooked.Size = new Size(57, 23);
            _lblBooked.TabIndex = 53;
            _lblBooked.Text = "Booked";
            //
            // cboQualification
            //
            _cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboQualification.Location = new Point(96, 36);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(486, 21);
            _cboQualification.TabIndex = 1;
            _cboQualification.Text = "ComboBox1";
            //
            // lblQualification
            //
            _lblQualification.Location = new Point(8, 36);
            _lblQualification.Name = "lblQualification";
            _lblQualification.Size = new Size(100, 23);
            _lblQualification.TabIndex = 48;
            _lblQualification.Text = "Qualification";
            //
            // txtQualificatioNote
            //
            _txtQualificatioNote.AcceptsReturn = true;
            _txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtQualificatioNote.Location = new Point(96, 132);
            _txtQualificatioNote.Multiline = true;
            _txtQualificatioNote.Name = "txtQualificatioNote";
            _txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
            _txtQualificatioNote.Size = new Size(486, 55);
            _txtQualificatioNote.TabIndex = 4;
            //
            // lblNote
            //
            _lblNote.Location = new Point(8, 132);
            _lblNote.Name = "lblNote";
            _lblNote.Size = new Size(67, 20);
            _lblNote.TabIndex = 47;
            _lblNote.Text = "Note";
            //
            // dtpQualificationExpires
            //
            _dtpQualificationExpires.Checked = false;
            _dtpQualificationExpires.Location = new Point(96, 99);
            _dtpQualificationExpires.Name = "dtpQualificationExpires";
            _dtpQualificationExpires.ShowCheckBox = true;
            _dtpQualificationExpires.Size = new Size(152, 21);
            _dtpQualificationExpires.TabIndex = 3;
            //
            // lblExpiry
            //
            _lblExpiry.Location = new Point(8, 105);
            _lblExpiry.Name = "lblExpiry";
            _lblExpiry.Size = new Size(80, 23);
            _lblExpiry.TabIndex = 43;
            _lblExpiry.Text = "Expires";
            //
            // dtpQualificationPassed
            //
            _dtpQualificationPassed.Checked = false;
            _dtpQualificationPassed.Location = new Point(96, 68);
            _dtpQualificationPassed.Name = "dtpQualificationPassed";
            _dtpQualificationPassed.ShowCheckBox = true;
            _dtpQualificationPassed.Size = new Size(152, 21);
            _dtpQualificationPassed.TabIndex = 2;
            //
            // lblPassed
            //
            _lblPassed.Location = new Point(8, 74);
            _lblPassed.Name = "lblPassed";
            _lblPassed.Size = new Size(80, 23);
            _lblPassed.TabIndex = 41;
            _lblPassed.Text = "Date Passed";
            //
            // btnRemoveTrainingQualifications
            //
            _btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveTrainingQualifications.Location = new Point(10, 506);
            _btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications";
            _btnRemoveTrainingQualifications.Size = new Size(75, 21);
            _btnRemoveTrainingQualifications.TabIndex = 7;
            _btnRemoveTrainingQualifications.Text = "Delete";
            //
            // dgTrainingQualifications
            //
            _dgTrainingQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTrainingQualifications.DataMember = "";
            _dgTrainingQualifications.HeaderForeColor = SystemColors.ControlText;
            _dgTrainingQualifications.Location = new Point(8, 248);
            _dgTrainingQualifications.Name = "dgTrainingQualifications";
            _dgTrainingQualifications.Size = new Size(590, 250);
            _dgTrainingQualifications.TabIndex = 6;
            //
            // UCUserQualification
            //
            Controls.Add(_grpUserQualifications);
            Controls.Add(_grpDetails);
            Name = "UCUserQualification";
            Size = new Size(630, 679);
            _grpDetails.ResumeLayout(false);
            _grpDetails.PerformLayout();
            _grpUserQualifications.ResumeLayout(false);
            _pnlQualifications.ResumeLayout(false);
            _pnlQualifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTrainingQualifications).EndInit();
            ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupTrainingQualificationsDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentUser;
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Users.User _currentUser;

        public Entity.Users.User CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                _currentUser = value;
                if (CurrentUser is null)
                {
                    CurrentUser = new Entity.Users.User() { Exists = false };
                }

                if (CurrentUser.Exists)
                {
                    Populate();
                    PopulateTrainingQualifications();
                }
            }
        }

        private DataView _dvTrainingQualifications;

        private DataView TrainingQualificationsDataView
        {
            get
            {
                return _dvTrainingQualifications;
            }

            set
            {
                if (value is object)
                {
                    _dvTrainingQualifications = value;
                    _dvTrainingQualifications.Table.TableName = Entity.Sys.Enums.TableNames.tblUserQualification.ToString();
                }

                dgTrainingQualifications.DataSource = _dvTrainingQualifications;
            }
        }

        public DataRow SelectedTrainingQualificationsRow
        {
            get
            {
                if (TrainingQualificationsDataView is object)
                {
                    if (TrainingQualificationsDataView.Table.Rows.Count > 0)
                    {
                        return TrainingQualificationsDataView[dgTrainingQualifications.CurrentRowIndex].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return default;
            }
        }

        public void SetupTrainingQualificationsDataGrid()
        {
            try
            {
                dgTrainingQualifications.TableStyles.Add(new DataGridTableStyle());
                Entity.Sys.Helper.SetUpDataGrid(dgTrainingQualifications);
                var tStyle = dgTrainingQualifications.TableStyles[0];
                var Qualification = new DataGridTextBoxColumn();
                Qualification.HeaderText = @"Level\Qualification";
                Qualification.MappingName = "Level";
                Qualification.NullText = "";
                Qualification.Width = 150;
                tStyle.GridColumnStyles.Add(Qualification);
                var Description = new DataGridTextBoxColumn();
                Description.HeaderText = "Description";
                Description.MappingName = "Description";
                Description.NullText = "";
                Description.Width = 200;
                tStyle.GridColumnStyles.Add(Description);
                var Notes = new DataGridTextBoxColumn();
                Notes.HeaderText = "Notes";
                Notes.MappingName = "Notes";
                Notes.NullText = "";
                Notes.Width = 400;
                tStyle.GridColumnStyles.Add(Notes);
                var DatePassed = new DataGridTextBoxColumn();
                DatePassed.HeaderText = "Passed";
                DatePassed.MappingName = "DatePassed";
                DatePassed.Format = "dd/MM/yyyy";
                DatePassed.NullText = "";
                DatePassed.Width = 80;
                tStyle.GridColumnStyles.Add(DatePassed);
                var DateExpires = new DataGridTextBoxColumn();
                DateExpires.HeaderText = "Expires";
                DateExpires.MappingName = "DateExpires";
                DateExpires.Format = "dd/MM/yyyy";
                DateExpires.NullText = "";
                DateExpires.Width = 80;
                tStyle.GridColumnStyles.Add(DateExpires);
                var DateBooked = new DataGridTextBoxColumn();
                DateBooked.HeaderText = "Booked";
                DateBooked.MappingName = "DateBooked";
                DateBooked.Format = "dd/MM/yyyy";
                DateBooked.NullText = "";
                DateBooked.Width = 80;
                tStyle.GridColumnStyles.Add(DateBooked);
                tStyle.MappingName = Entity.Sys.Enums.TableNames.tblUserQualification.ToString();
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCUserQualification_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnSaveQualification_Click(object sender, EventArgs e)
        {
            try
            {
                var UpdateFlag = default(bool);
                DataRow r;
                r = TrainingQualificationsDataView.Table.NewRow();
                var v = new BaseValidator();
                var check = TrainingQualificationsDataView.Table.Select("LevelID = " + Combo.get_GetSelectedItemValue(cboQualification));
                if (check.Length > 0)
                {
                    string msg = "This will update the qualification. ";
                    msg += "Do you wish to Procceed.";
                    if (App.ShowMessage(msg, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        UpdateFlag = true;
                    }
                }

                if (cboQualification.SelectedIndex == 0)
                {
                    v.AddCriticalMessage("'Qualification' is required");
                }

                if (dtpQualificationPassed.Checked == false)
                {
                    v.AddCriticalMessage("'Date Passed' must be specified.");
                }

                if (v.ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(v);
                }

                string hasDescription = Conversions.ToString(false);
                hasDescription = Conversions.ToString(Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*').Length > 1);
                r["LevelID"] = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQualification));
                r["Level"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[1].Trim();
                if (Conversions.ToBoolean(hasDescription))
                    r["Description"] = Combo.get_GetSelectedItemDescription(cboQualification).ToString().Split('*')[0].Trim();
                r["Notes"] = txtQualificatioNote.Text;
                if (dtpQualificationPassed.Checked)
                {
                    r["DatePassed"] = dtpQualificationPassed.Value;
                }

                if (dtpQualificationExpires.Checked)
                {
                    r["DateExpires"] = dtpQualificationExpires.Value;
                }

                if (dtpQualificationBooked.Checked)
                {
                    r["DateBooked"] = dtpQualificationBooked.Value;
                }

                if (UpdateFlag)
                {
                    var dr = TrainingQualificationsDataView.Table.Rows[dgTrainingQualifications.CurrentRowIndex];
                    foreach (DataColumn dc in dr.Table.Columns)
                        dr[dc] = r[dc];
                }
                else
                {
                    TrainingQualificationsDataView.Table.Rows.Add(r);
                }

                ClearQualificationDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTrainingQualifications_Click(object sender, EventArgs e)
        {
            try
            {
                var r = SelectedTrainingQualificationsRow;
                if (r is object)
                {
                    if (MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        TrainingQualificationsDataView.Table.Rows.Remove(r);
                    }
                }

                ClearQualificationDetailPanel();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboQualificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int skillTypeId = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboQualificationType));
                if (skillTypeId > 0)
                {
                    var argc = cboQualification;
                    Combo.SetUpCombo(ref argc, App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Entity.Sys.Enums.ComboValues.Please_Select);
                }
                else
                {
                    var argc1 = cboQualification;
                    Combo.SetUpComboQual(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentUser = App.DB.User.Get(ID);
            }

            txtFullName.Text = CurrentUser.Fullname;
            txtEmailAddress.Text = CurrentUser.EmailAddress;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!CurrentUser.Exists)
                    return false;
                App.DB.UserLevels.Insert(CurrentUser.UserID, TrainingQualificationsDataView.Table);
                return true;
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

        private void PopulateTrainingQualifications()
        {
            try
            {
                // TODO - ADD USER QUALIFICATION SQL
                TrainingQualificationsDataView = App.DB.UserLevels.GetForSetup(CurrentUser.UserID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("The following error occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearQualificationDetailPanel()
        {
            var argcombo = cboQualification;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            txtQualificatioNote.Text = "";
            dtpQualificationPassed.Checked = false;
            dtpQualificationExpires.Checked = false;
        }

        private void dgTrainingQualifications_Click(object sender, EventArgs e)
        {
            try
            {
                var argc = cboQualificationType;
                Combo.SetUpCombo(ref argc, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
                var argcombo = cboQualification;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, SelectedTrainingQualificationsRow[0].ToString());
                txtQualificatioNote.Text = Conversions.ToString(SelectedTrainingQualificationsRow[3]);
                dtpQualificationPassed.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[4]);
                dtpQualificationExpires.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[5]);
                dtpQualificationBooked.Value = Conversions.ToDate(SelectedTrainingQualificationsRow[6]);
            }
            catch
            {
            }
        }
    }
}