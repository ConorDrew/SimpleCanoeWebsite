using FSM.Entity.ContactAttempts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContactAttempt : Form
    {
        public FRMContactAttempt(Enums.TableNames linkTable, int linkId) : base()
        {
            InitializeComponent();
            LinkTable = linkTable;
            LinkID = linkId;
            var argc = cboMethod;
            Combo.SetUpCombo(ref argc, App.DB.ContactAttempts.ContactMethod_GetAll().Table, "ContactMethodID", "Name", Enums.ComboValues.Please_Select);
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

        private Label _lblContactMethod;

        private ComboBox _cboMethod;

        internal ComboBox cboMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMethod != null)
                {
                }

                _cboMethod = value;
                if (_cboMethod != null)
                {
                }
            }
        }

        private Label _lblDate;

        private DateTimePicker _dtpDate;

        internal DateTimePicker dtpDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDate != null)
                {
                }

                _dtpDate = value;
                if (_dtpDate != null)
                {
                }
            }
        }

        private Label _lblTime;

        private DateTimePicker _dtpTime;

        internal DateTimePicker dtpTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTime != null)
                {
                }

                _dtpTime = value;
                if (_dtpTime != null)
                {
                }
            }
        }

        private Label _lblNote;

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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _lblContactMethod = new Label();
            _cboMethod = new ComboBox();
            _lblDate = new Label();
            _dtpDate = new DateTimePicker();
            _lblTime = new Label();
            _dtpTime = new DateTimePicker();
            _lblNote = new Label();
            _txtNote = new TextBox();
            SuspendLayout();
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(341, 242);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(77, 23);
            _btnSave.TabIndex = 48;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // lblContactMethod
            //
            _lblContactMethod.AutoSize = true;
            _lblContactMethod.Location = new Point(12, 18);
            _lblContactMethod.Name = "lblContactMethod";
            _lblContactMethod.Size = new Size(46, 13);
            _lblContactMethod.TabIndex = 49;
            _lblContactMethod.Text = "Method:";
            //
            // cboMethod
            //
            _cboMethod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboMethod.FormattingEnabled = true;
            _cboMethod.Location = new Point(74, 15);
            _cboMethod.Name = "cboMethod";
            _cboMethod.Size = new Size(344, 21);
            _cboMethod.TabIndex = 50;
            //
            // lblDate
            //
            _lblDate.AutoSize = true;
            _lblDate.Location = new Point(12, 61);
            _lblDate.Name = "lblDate";
            _lblDate.Size = new Size(33, 13);
            _lblDate.TabIndex = 51;
            _lblDate.Text = "Date:";
            //
            // dtpDate
            //
            _dtpDate.Location = new Point(74, 58);
            _dtpDate.Name = "dtpDate";
            _dtpDate.Size = new Size(156, 20);
            _dtpDate.TabIndex = 52;
            //
            // lblTime
            //
            _lblTime.AutoSize = true;
            _lblTime.Location = new Point(251, 61);
            _lblTime.Name = "lblTime";
            _lblTime.Size = new Size(33, 13);
            _lblTime.TabIndex = 53;
            _lblTime.Text = "Time:";
            //
            // dtpTime
            //
            _dtpTime.Format = DateTimePickerFormat.Time;
            _dtpTime.Location = new Point(290, 58);
            _dtpTime.Name = "dtpTime";
            _dtpTime.Size = new Size(69, 20);
            _dtpTime.TabIndex = 54;
            //
            // lblNote
            //
            _lblNote.AutoSize = true;
            _lblNote.Location = new Point(12, 105);
            _lblNote.Name = "lblNote";
            _lblNote.Size = new Size(33, 13);
            _lblNote.TabIndex = 55;
            _lblNote.Text = "Note:";
            //
            // txtNote
            //
            _txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtNote.Location = new Point(74, 105);
            _txtNote.Multiline = true;
            _txtNote.Name = "txtNote";
            _txtNote.ScrollBars = ScrollBars.Vertical;
            _txtNote.Size = new Size(344, 112);
            _txtNote.TabIndex = 56;
            //
            // FRMContactAttempt
            //
            AutoScaleBaseSize = new Size(5, 13);
            BackColor = Color.White;
            ClientSize = new Size(430, 277);
            Controls.Add(_txtNote);
            Controls.Add(_lblNote);
            Controls.Add(_dtpTime);
            Controls.Add(_lblTime);
            Controls.Add(_dtpDate);
            Controls.Add(_lblDate);
            Controls.Add(_cboMethod);
            Controls.Add(_lblContactMethod);
            Controls.Add(_btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            Name = "FRMContactAttempt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contact Attempt";
            ResumeLayout(false);
            PerformLayout();
        }

        private Enums.TableNames LinkTable;
        private int LinkID;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool IsFormValid()
        {
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboMethod)) == 0)
            {
                App.ShowMessage("Please select a contact method!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNote.Text.Trim().Length == 0)
            {
                App.ShowMessage("Please add a note!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Save()
        {
            try
            {
                if (!IsFormValid())
                    return;
                var contactAttempt = new ContactAttempt();
                {
                    var withBlock = contactAttempt;
                    withBlock.ContactMethedID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboMethod));
                    withBlock.LinkID = Conversions.ToInteger(LinkTable);
                    withBlock.LinkRef = LinkID;
                    withBlock.ContactMade = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second);
                    withBlock.Notes = txtNote.Text.Trim();
                    withBlock.ContactMadeByUserId = App.loggedInUser.UserID;
                }

                contactAttempt = App.DB.ContactAttempts.Insert(contactAttempt);
                if (contactAttempt.ContactAttemptID > 0)
                {
                    App.ShowMessage("Contact attempt saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.OK;
                    if (Modal)
                    {
                        Close();
                    }
                    else
                    {
                        Dispose();
                    }
                }
                else
                {
                    App.ShowMessage("Could not save Contact attempt!, please try re-enter the details.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message + " - " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}