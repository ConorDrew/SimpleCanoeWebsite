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
    public class UCNotes : UCBase, IUserControl
    {
        

        public UCNotes() : base()
        {
            
            
            base.Load += UCNotes_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboCategoryID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.NoteCategory).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboTimeHours;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc2 = cboTimeMinutes;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc3 = cboReminderHours;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc4 = cboReminderMinutes;
            Combo.SetUpCombo(ref argc4, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc5 = cboReminderFrequency;
            Combo.SetUpCombo(ref argc5, DynamicDataTables.ReminderFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argcombo = cboReminderFrequency;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Minutes).ToString());
            var argc6 = cboReminderFrequencyValue;
            Combo.SetUpCombo(ref argc6, DynamicDataTables.NumberSelector, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argcombo1 = cboReminderFrequencyValue;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 1.ToString());
            var argc7 = cboUserFor;
            Combo.SetUpCombo(ref argc7, App.DB.User.GetAll().Table, "UserID", "Fullname", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo2 = cboUserFor;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, App.loggedInUser.UserID.ToString());
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.

        private GroupBox _grpNotes;

        internal GroupBox grpNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpNotes != null)
                {
                }

                _grpNotes = value;
                if (_grpNotes != null)
                {
                }
            }
        }

        private ComboBox _cboCategoryID;

        internal ComboBox cboCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategoryID != null)
                {
                }

                _cboCategoryID = value;
                if (_cboCategoryID != null)
                {
                }
            }
        }

        private Label _lblCategoryID;

        internal Label lblCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCategoryID != null)
                {
                }

                _lblCategoryID = value;
                if (_lblCategoryID != null)
                {
                }
            }
        }

        private DateTimePicker _dtpNoteDate;

        internal DateTimePicker dtpNoteDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpNoteDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpNoteDate != null)
                {
                }

                _dtpNoteDate = value;
                if (_dtpNoteDate != null)
                {
                }
            }
        }

        private Label _lblNoteDate;

        internal Label lblNoteDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNoteDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNoteDate != null)
                {
                }

                _lblNoteDate = value;
                if (_lblNoteDate != null)
                {
                }
            }
        }

        private TextBox _txtNote;

        internal TextBox txtNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNote != null)
                {
                }

                _txtNote = value;
                if (_txtNote != null)
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

        private GroupBox _grpReminderDetails;

        internal GroupBox grpReminderDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpReminderDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpReminderDetails != null)
                {
                }

                _grpReminderDetails = value;
                if (_grpReminderDetails != null)
                {
                }
            }
        }

        private CheckBox _chkReminderRequired;

        internal CheckBox chkReminderRequired
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkReminderRequired;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkReminderRequired != null)
                {
                    _chkReminderRequired.CheckedChanged -= chkReminderRequired_CheckedChanged;
                }

                _chkReminderRequired = value;
                if (_chkReminderRequired != null)
                {
                    _chkReminderRequired.CheckedChanged += chkReminderRequired_CheckedChanged;
                }
            }
        }

        private ComboBox _cboReminderFrequency;

        internal ComboBox cboReminderFrequency
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReminderFrequency;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReminderFrequency != null)
                {
                }

                _cboReminderFrequency = value;
                if (_cboReminderFrequency != null)
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

        private ComboBox _cboTimeHours;

        internal ComboBox cboTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTimeHours != null)
                {
                }

                _cboTimeHours = value;
                if (_cboTimeHours != null)
                {
                }
            }
        }

        private ComboBox _cboTimeMinutes;

        internal ComboBox cboTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTimeMinutes != null)
                {
                }

                _cboTimeMinutes = value;
                if (_cboTimeMinutes != null)
                {
                }
            }
        }

        private Panel _pnlReminderType;

        internal Panel pnlReminderType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlReminderType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlReminderType != null)
                {
                }

                _pnlReminderType = value;
                if (_pnlReminderType != null)
                {
                }
            }
        }

        private RadioButton _radPeriod;

        internal RadioButton radPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radPeriod != null)
                {
                    _radPeriod.CheckedChanged -= radPeriod_CheckedChanged;
                }

                _radPeriod = value;
                if (_radPeriod != null)
                {
                    _radPeriod.CheckedChanged += radPeriod_CheckedChanged;
                }
            }
        }

        private RadioButton _radOther;

        internal RadioButton radOther
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radOther;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radOther != null)
                {
                    _radOther.CheckedChanged -= radOther_CheckedChanged;
                }

                _radOther = value;
                if (_radOther != null)
                {
                    _radOther.CheckedChanged += radOther_CheckedChanged;
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

        private DateTimePicker _dtpReminderDate;

        internal DateTimePicker dtpReminderDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpReminderDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpReminderDate != null)
                {
                }

                _dtpReminderDate = value;
                if (_dtpReminderDate != null)
                {
                }
            }
        }

        private ComboBox _cboReminderHours;

        internal ComboBox cboReminderHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReminderHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReminderHours != null)
                {
                }

                _cboReminderHours = value;
                if (_cboReminderHours != null)
                {
                }
            }
        }

        private ComboBox _cboReminderMinutes;

        internal ComboBox cboReminderMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReminderMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReminderMinutes != null)
                {
                }

                _cboReminderMinutes = value;
                if (_cboReminderMinutes != null)
                {
                }
            }
        }

        private ComboBox _cboReminderFrequencyValue;

        internal ComboBox cboReminderFrequencyValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReminderFrequencyValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReminderFrequencyValue != null)
                {
                }

                _cboReminderFrequencyValue = value;
                if (_cboReminderFrequencyValue != null)
                {
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

        private ComboBox _cboUserFor;

        internal ComboBox cboUserFor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUserFor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUserFor != null)
                {
                }

                _cboUserFor = value;
                if (_cboUserFor != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpNotes = new GroupBox();
            _cboTimeMinutes = new ComboBox();
            _Label2 = new Label();
            _grpReminderDetails = new GroupBox();
            _cboReminderFrequencyValue = new ComboBox();
            _Label4 = new Label();
            _Label3 = new Label();
            _pnlReminderType = new Panel();
            _radOther = new RadioButton();
            _radOther.CheckedChanged += new EventHandler(radOther_CheckedChanged);
            _radPeriod = new RadioButton();
            _radPeriod.CheckedChanged += new EventHandler(radPeriod_CheckedChanged);
            _Label1 = new Label();
            _cboReminderFrequency = new ComboBox();
            _chkReminderRequired = new CheckBox();
            _chkReminderRequired.CheckedChanged += new EventHandler(chkReminderRequired_CheckedChanged);
            _dtpReminderDate = new DateTimePicker();
            _cboReminderHours = new ComboBox();
            _cboReminderMinutes = new ComboBox();
            _cboCategoryID = new ComboBox();
            _lblCategoryID = new Label();
            _dtpNoteDate = new DateTimePicker();
            _lblNoteDate = new Label();
            _txtNote = new TextBox();
            _lblNote = new Label();
            _cboTimeHours = new ComboBox();
            _Label5 = new Label();
            _cboUserFor = new ComboBox();
            _grpNotes.SuspendLayout();
            _grpReminderDetails.SuspendLayout();
            _pnlReminderType.SuspendLayout();
            SuspendLayout();
            //
            // grpNotes
            //
            _grpNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpNotes.Controls.Add(_cboUserFor);
            _grpNotes.Controls.Add(_Label5);
            _grpNotes.Controls.Add(_cboTimeMinutes);
            _grpNotes.Controls.Add(_Label2);
            _grpNotes.Controls.Add(_grpReminderDetails);
            _grpNotes.Controls.Add(_cboCategoryID);
            _grpNotes.Controls.Add(_lblCategoryID);
            _grpNotes.Controls.Add(_dtpNoteDate);
            _grpNotes.Controls.Add(_lblNoteDate);
            _grpNotes.Controls.Add(_txtNote);
            _grpNotes.Controls.Add(_lblNote);
            _grpNotes.Controls.Add(_cboTimeHours);
            _grpNotes.Location = new Point(8, 8);
            _grpNotes.Name = "grpNotes";
            _grpNotes.Size = new Size(732, 308);
            _grpNotes.TabIndex = 1;
            _grpNotes.TabStop = false;
            _grpNotes.Text = "Note Details";
            //
            // cboTimeMinutes
            //
            _cboTimeMinutes.Location = new Point(432, 24);
            _cboTimeMinutes.Name = "cboTimeMinutes";
            _cboTimeMinutes.Size = new Size(104, 21);
            _cboTimeMinutes.TabIndex = 3;
            //
            // Label2
            //
            _Label2.Location = new Point(288, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(40, 21);
            _Label2.TabIndex = 33;
            _Label2.Text = "Time";
            //
            // grpReminderDetails
            //
            _grpReminderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpReminderDetails.Controls.Add(_cboReminderFrequencyValue);
            _grpReminderDetails.Controls.Add(_Label4);
            _grpReminderDetails.Controls.Add(_Label3);
            _grpReminderDetails.Controls.Add(_pnlReminderType);
            _grpReminderDetails.Controls.Add(_Label1);
            _grpReminderDetails.Controls.Add(_cboReminderFrequency);
            _grpReminderDetails.Controls.Add(_chkReminderRequired);
            _grpReminderDetails.Controls.Add(_dtpReminderDate);
            _grpReminderDetails.Controls.Add(_cboReminderHours);
            _grpReminderDetails.Controls.Add(_cboReminderMinutes);
            _grpReminderDetails.Location = new Point(8, 208);
            _grpReminderDetails.Name = "grpReminderDetails";
            _grpReminderDetails.Size = new Size(715, 88);
            _grpReminderDetails.TabIndex = 32;
            _grpReminderDetails.TabStop = false;
            _grpReminderDetails.Text = "Reminder Details";
            //
            // cboReminderFrequencyValue
            //
            _cboReminderFrequencyValue.Location = new Point(176, 25);
            _cboReminderFrequencyValue.Name = "cboReminderFrequencyValue";
            _cboReminderFrequencyValue.Size = new Size(96, 21);
            _cboReminderFrequencyValue.TabIndex = 9;
            //
            // Label4
            //
            _Label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label4.Location = new Point(456, 58);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(40, 20);
            _Label4.TabIndex = 36;
            _Label4.Text = "Time";
            //
            // Label3
            //
            _Label3.Location = new Point(176, 57);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(40, 20);
            _Label3.TabIndex = 34;
            _Label3.Text = "Date";
            //
            // pnlReminderType
            //
            _pnlReminderType.Controls.Add(_radOther);
            _pnlReminderType.Controls.Add(_radPeriod);
            _pnlReminderType.Location = new Point(96, 24);
            _pnlReminderType.Name = "pnlReminderType";
            _pnlReminderType.Size = new Size(72, 56);
            _pnlReminderType.TabIndex = 33;
            //
            // radOther
            //
            _radOther.Location = new Point(8, 27);
            _radOther.Name = "radOther";
            _radOther.Size = new Size(64, 24);
            _radOther.TabIndex = 8;
            _radOther.Text = "Other";
            //
            // radPeriod
            //
            _radPeriod.Location = new Point(8, 2);
            _radPeriod.Name = "radPeriod";
            _radPeriod.Size = new Size(64, 24);
            _radPeriod.TabIndex = 7;
            _radPeriod.Text = "Period";
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label1.Location = new Point(456, 28);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(144, 16);
            _Label1.TabIndex = 32;
            _Label1.Text = "Prior to due date && time";
            //
            // cboReminderFrequency
            //
            _cboReminderFrequency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboReminderFrequency.Location = new Point(272, 26);
            _cboReminderFrequency.Name = "cboReminderFrequency";
            _cboReminderFrequency.Size = new Size(176, 21);
            _cboReminderFrequency.TabIndex = 10;
            //
            // chkReminderRequired
            //
            _chkReminderRequired.Location = new Point(8, 24);
            _chkReminderRequired.Name = "chkReminderRequired";
            _chkReminderRequired.Size = new Size(88, 56);
            _chkReminderRequired.TabIndex = 6;
            _chkReminderRequired.Text = "Reminder Required";
            //
            // dtpReminderDate
            //
            _dtpReminderDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpReminderDate.Location = new Point(216, 57);
            _dtpReminderDate.Name = "dtpReminderDate";
            _dtpReminderDate.Size = new Size(232, 21);
            _dtpReminderDate.TabIndex = 11;
            _dtpReminderDate.Tag = "Notes.NoteDate";
            //
            // cboReminderHours
            //
            _cboReminderHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboReminderHours.Location = new Point(496, 58);
            _cboReminderHours.Name = "cboReminderHours";
            _cboReminderHours.Size = new Size(104, 21);
            _cboReminderHours.TabIndex = 12;
            //
            // cboReminderMinutes
            //
            _cboReminderMinutes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboReminderMinutes.Location = new Point(600, 58);
            _cboReminderMinutes.Name = "cboReminderMinutes";
            _cboReminderMinutes.Size = new Size(104, 21);
            _cboReminderMinutes.TabIndex = 13;
            //
            // cboCategoryID
            //
            _cboCategoryID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboCategoryID.Cursor = Cursors.Hand;
            _cboCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCategoryID.Location = new Point(72, 82);
            _cboCategoryID.Name = "cboCategoryID";
            _cboCategoryID.Size = new Size(651, 21);
            _cboCategoryID.TabIndex = 4;
            _cboCategoryID.Tag = "Notes.CategoryID";
            //
            // lblCategoryID
            //
            _lblCategoryID.Location = new Point(8, 82);
            _lblCategoryID.Name = "lblCategoryID";
            _lblCategoryID.Size = new Size(64, 20);
            _lblCategoryID.TabIndex = 31;
            _lblCategoryID.Text = "Category";
            //
            // dtpNoteDate
            //
            _dtpNoteDate.Location = new Point(72, 24);
            _dtpNoteDate.Name = "dtpNoteDate";
            _dtpNoteDate.Size = new Size(208, 21);
            _dtpNoteDate.TabIndex = 1;
            _dtpNoteDate.Tag = "Notes.NoteDate";
            //
            // lblNoteDate
            //
            _lblNoteDate.Location = new Point(8, 24);
            _lblNoteDate.Name = "lblNoteDate";
            _lblNoteDate.Size = new Size(48, 21);
            _lblNoteDate.TabIndex = 31;
            _lblNoteDate.Text = "Date";
            //
            // txtNote
            //
            _txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNote.Location = new Point(72, 111);
            _txtNote.Multiline = true;
            _txtNote.Name = "txtNote";
            _txtNote.ScrollBars = ScrollBars.Vertical;
            _txtNote.Size = new Size(651, 88);
            _txtNote.TabIndex = 5;
            _txtNote.Tag = "Notes.Note";
            _txtNote.Text = "";
            //
            // lblNote
            //
            _lblNote.Location = new Point(8, 111);
            _lblNote.Name = "lblNote";
            _lblNote.Size = new Size(48, 20);
            _lblNote.TabIndex = 31;
            _lblNote.Text = "Note";
            //
            // cboTimeHours
            //
            _cboTimeHours.Location = new Point(328, 24);
            _cboTimeHours.Name = "cboTimeHours";
            _cboTimeHours.Size = new Size(104, 21);
            _cboTimeHours.TabIndex = 2;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 53);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(64, 20);
            _Label5.TabIndex = 34;
            _Label5.Text = "For User:";
            //
            // cboUserFor
            //
            _cboUserFor.Location = new Point(72, 53);
            _cboUserFor.Name = "cboUserFor";
            _cboUserFor.Size = new Size(208, 21);
            _cboUserFor.TabIndex = 35;
            //
            // UCNotes
            //
            Controls.Add(_grpNotes);
            Name = "UCNotes";
            Size = new Size(747, 325);
            _grpNotes.ResumeLayout(false);
            _grpReminderDetails.ResumeLayout(false);
            _pnlReminderType.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentNote;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Notes.Notes _currentNotes;

        public Entity.Notes.Notes CurrentNote
        {
            get
            {
                return _currentNotes;
            }

            set
            {
                _currentNotes = value;
                if (_currentNotes is null)
                {
                    _currentNotes = new Entity.Notes.Notes();
                    _currentNotes.Exists = false;
                }

                if (CurrentNote.Exists)
                {
                    Populate();
                }
                else
                {
                    chkReminderRequired.Checked = false;
                }

                SetReminderStatus(false);
            }
        }

        private void UCNotes_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void chkReminderRequired_CheckedChanged(object sender, EventArgs e)
        {
            SetReminderStatus(false);
        }

        private void radPeriod_CheckedChanged(object sender, EventArgs e)
        {
            SetReminderStatus(true);
        }

        private void radOther_CheckedChanged(object sender, EventArgs e)
        {
            SetReminderStatus(true);
        }

        
        

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentNote = App.DB.Notes.Notes_Get(ID);
            }

            dtpNoteDate.Value = CurrentNote.NoteDate.Date;
            var argcombo = cboTimeHours;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentNote.NoteDate.Hour.ToString());
            var argcombo1 = cboTimeMinutes;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentNote.NoteDate.Minute.ToString());
            var argcombo2 = cboCategoryID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentNote.CategoryID.ToString());
            txtNote.Text = CurrentNote.Note;
            var argcombo3 = cboUserFor;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentNote.UserIDFor.ToString());
            if (CurrentNote.ReminderStatusID == Conversions.ToInteger(Entity.Sys.Enums.NoteReminderStatus.Active))
            {
                chkReminderRequired.Checked = true;
            }
            else
            {
                chkReminderRequired.Checked = false;
            }
        }

        private void SetReminderStatus(bool fromTick)
        {
            if (chkReminderRequired.Checked == false)
            {
                radPeriod.Enabled = false;
                radOther.Enabled = false;
                cboReminderFrequencyValue.Enabled = false;
                cboReminderFrequency.Enabled = false;
                dtpReminderDate.Enabled = false;
                cboReminderHours.Enabled = false;
                cboReminderMinutes.Enabled = false;
                radOther.Checked = false;
                radOther.Checked = false;
            }
            else
            {
                radPeriod.Enabled = true;
                radOther.Enabled = true;
                if (!fromTick)
                {
                    if (CurrentNote.ReminderStatusID == Conversions.ToInteger(Entity.Sys.Enums.NoteReminderStatus.Active))
                    {
                        radPeriod.Checked = false;
                        radOther.Checked = true;
                        cboReminderFrequencyValue.Enabled = false;
                        cboReminderFrequency.Enabled = false;
                        dtpReminderDate.Enabled = true;
                        cboReminderHours.Enabled = true;
                        cboReminderMinutes.Enabled = true;
                        dtpReminderDate.Value = CurrentNote.DateTimeOfReminder.Date;
                        var argcombo = cboReminderHours;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentNote.DateTimeOfReminder.Hour.ToString());
                        var argcombo1 = cboReminderMinutes;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentNote.DateTimeOfReminder.Minute.ToString());
                    }
                    else if (radPeriod.Checked == false & radOther.Checked == false)
                    {
                        radPeriod.Checked = true;
                    }
                }

                if (radPeriod.Checked == true)
                {
                    cboReminderFrequencyValue.Enabled = true;
                    cboReminderFrequency.Enabled = true;
                    dtpReminderDate.Enabled = false;
                    cboReminderHours.Enabled = false;
                    cboReminderMinutes.Enabled = false;
                }
                else
                {
                    cboReminderFrequencyValue.Enabled = false;
                    cboReminderFrequency.Enabled = false;
                    dtpReminderDate.Enabled = true;
                    cboReminderHours.Enabled = true;
                    cboReminderMinutes.Enabled = true;
                }
            }
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentNote.IgnoreExceptionsOnSetMethods = true;
                CurrentNote.SetCategoryID = Combo.get_GetSelectedItemValue(cboCategoryID);
                CurrentNote.NoteDate = Conversions.ToDate(dtpNoteDate.Value.Date + " " + Combo.get_GetSelectedItemValue(cboTimeHours) + ":" + Combo.get_GetSelectedItemValue(cboTimeMinutes) + ":00");
                CurrentNote.SetNote = txtNote.Text.Trim();
                CurrentNote.SetUserIDFor = Combo.get_GetSelectedItemValue(cboUserFor);
                if (!chkReminderRequired.Checked)
                {
                    CurrentNote.SetReminderStatusID = Conversions.ToInteger(Entity.Sys.Enums.NoteReminderStatus.Cancelled);
                    CurrentNote.DateTimeOfReminder = CurrentNote.NoteDate;
                }
                else
                {
                    CurrentNote.SetReminderStatusID = Conversions.ToInteger(Entity.Sys.Enums.NoteReminderStatus.Active);
                    var reminderDate = new DateTime();
                    if (radOther.Checked)
                    {
                        reminderDate = Conversions.ToDate(dtpReminderDate.Value.Date + " " + Combo.get_GetSelectedItemValue(cboReminderHours) + ":" + Combo.get_GetSelectedItemValue(cboReminderMinutes) + ":00");
                    }
                    else
                    {
                        reminderDate = CurrentNote.NoteDate;
                        var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequency));
                        switch (switchExpr)
                        {
                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Minutes):
                                {
                                    reminderDate = reminderDate.AddMinutes(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)));
                                    break;
                                }

                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Hours):
                                {
                                    reminderDate = reminderDate.AddHours(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)));
                                    break;
                                }

                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Days):
                                {
                                    reminderDate = reminderDate.AddDays(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)));
                                    break;
                                }

                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Weeks):
                                {
                                    reminderDate = reminderDate.AddDays(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)) * 7);
                                    break;
                                }

                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Months):
                                {
                                    reminderDate = reminderDate.AddMonths(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)));
                                    break;
                                }

                            case (int)(Entity.Sys.Enums.ReminderFrequencies.Years):
                                {
                                    reminderDate = reminderDate.AddYears(0 - Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboReminderFrequencyValue)));
                                    break;
                                }
                        }
                    }

                    CurrentNote.DateTimeOfReminder = reminderDate;
                }

                var cV = new Entity.Notes.NotesValidator();
                cV.Validate(CurrentNote);
                if (CurrentNote.Exists)
                {
                    App.DB.Notes.Update(CurrentNote);
                }
                else
                {
                    CurrentNote = App.DB.Notes.Insert(CurrentNote);
                }

                StateChanged?.Invoke(CurrentNote.NoteID);
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

        
    }
}