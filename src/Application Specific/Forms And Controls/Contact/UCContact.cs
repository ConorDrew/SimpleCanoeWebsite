using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCContact : UCBase, IUserControl
    {
        

        public UCContact() : base()
        {
            
            
            base.Load += UCContact_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboSalutation;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            // Add any initialization after the InitializeComponent() call
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

        private GroupBox _grpContact;

        internal GroupBox grpContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContact != null)
                {
                }

                _grpContact = value;
                if (_grpContact != null)
                {
                }
            }
        }

        private TextBox _txtFirstName;

        internal TextBox txtFirstName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFirstName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFirstName != null)
                {
                }

                _txtFirstName = value;
                if (_txtFirstName != null)
                {
                }
            }
        }

        private Label _lblFirstName;

        internal Label lblFirstName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstName != null)
                {
                }

                _lblFirstName = value;
                if (_lblFirstName != null)
                {
                }
            }
        }

        private TextBox _txtSurname;

        internal TextBox txtSurname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSurname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSurname != null)
                {
                }

                _txtSurname = value;
                if (_txtSurname != null)
                {
                }
            }
        }

        private Label _lblSurname;

        internal Label lblSurname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSurname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSurname != null)
                {
                }

                _lblSurname = value;
                if (_lblSurname != null)
                {
                }
            }
        }

        private TextBox _txtTelephoneNum;

        internal TextBox txtTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTelephoneNum != null)
                {
                }

                _txtTelephoneNum = value;
                if (_txtTelephoneNum != null)
                {
                }
            }
        }

        private Label _lblTelephoneNum;

        internal Label lblTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTelephoneNum != null)
                {
                }

                _lblTelephoneNum = value;
                if (_lblTelephoneNum != null)
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

        private Label _lblEmailAddress;

        internal Label lblEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmailAddress != null)
                {
                }

                _lblEmailAddress = value;
                if (_lblEmailAddress != null)
                {
                }
            }
        }

        private TextBox _txtFaxNum;

        internal TextBox txtFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaxNum != null)
                {
                }

                _txtFaxNum = value;
                if (_txtFaxNum != null)
                {
                }
            }
        }

        private Label _lblFaxNum;

        internal Label lblFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaxNum != null)
                {
                }

                _lblFaxNum = value;
                if (_lblFaxNum != null)
                {
                }
            }
        }

        private TextBox _txtMobileNo;

        internal TextBox txtMobileNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMobileNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMobileNo != null)
                {
                }

                _txtMobileNo = value;
                if (_txtMobileNo != null)
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

        private TextBox _txtPortalUsername;

        internal TextBox txtPortalUsername
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPortalUsername;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPortalUsername != null)
                {
                }

                _txtPortalUsername = value;
                if (_txtPortalUsername != null)
                {
                }
            }
        }

        private TextBox _txtPortalPassword;

        internal TextBox txtPortalPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPortalPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPortalPassword != null)
                {
                }

                _txtPortalPassword = value;
                if (_txtPortalPassword != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _btnDeleteNote;

        internal Button btnDeleteNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click -= btnDeleteNote_Click;
                }

                _btnDeleteNote = value;
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click += btnDeleteNote_Click;
                }
            }
        }

        private Button _btnAddNote;

        internal Button btnAddNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click -= btnAddNote_Click;
                }

                _btnAddNote = value;
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click += btnAddNote_Click;
                }
            }
        }

        private DataGrid _dgNotes;

        internal DataGrid dgNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgNotes != null)
                {
                    _dgNotes.DoubleClick -= dgNotes_DoubleClick;
                }

                _dgNotes = value;
                if (_dgNotes != null)
                {
                    _dgNotes.DoubleClick += dgNotes_DoubleClick;
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

        private CheckBox _chkPortalGSRPrint;

        internal CheckBox chkPortalGSRPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPortalGSRPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPortalGSRPrint != null)
                {
                }

                _chkPortalGSRPrint = value;
                if (_chkPortalGSRPrint != null)
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

        private ComboBox _cboSalutation;

        internal ComboBox cboSalutation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSalutation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSalutation != null)
                {
                }

                _cboSalutation = value;
                if (_cboSalutation != null)
                {
                }
            }
        }

        private TextBox _txtEID;

        internal TextBox txtEID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEID != null)
                {
                }

                _txtEID = value;
                if (_txtEID != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContact = new GroupBox();
            _cboSalutation = new ComboBox();
            _Label6 = new Label();
            _chkPortalGSRPrint = new CheckBox();
            _txtPortalPassword = new TextBox();
            _txtPortalUsername = new TextBox();
            _Label3 = new Label();
            _Label2 = new Label();
            _txtMobileNo = new TextBox();
            _Label1 = new Label();
            _txtFirstName = new TextBox();
            _lblFirstName = new Label();
            _txtSurname = new TextBox();
            _lblSurname = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _GroupBox1 = new GroupBox();
            _Label5 = new Label();
            _Label4 = new Label();
            _btnDeleteNote = new Button();
            _btnDeleteNote.Click += new EventHandler(btnDeleteNote_Click);
            _btnAddNote = new Button();
            _btnAddNote.Click += new EventHandler(btnAddNote_Click);
            _dgNotes = new DataGrid();
            _dgNotes.DoubleClick += new EventHandler(dgNotes_DoubleClick);
            _txtEID = new TextBox();
            _Label7 = new Label();
            _grpContact.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgNotes).BeginInit();
            SuspendLayout();
            //
            // grpContact
            //
            _grpContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpContact.Controls.Add(_txtEID);
            _grpContact.Controls.Add(_Label7);
            _grpContact.Controls.Add(_cboSalutation);
            _grpContact.Controls.Add(_Label6);
            _grpContact.Controls.Add(_chkPortalGSRPrint);
            _grpContact.Controls.Add(_txtPortalPassword);
            _grpContact.Controls.Add(_txtPortalUsername);
            _grpContact.Controls.Add(_Label3);
            _grpContact.Controls.Add(_Label2);
            _grpContact.Controls.Add(_txtMobileNo);
            _grpContact.Controls.Add(_Label1);
            _grpContact.Controls.Add(_txtFirstName);
            _grpContact.Controls.Add(_lblFirstName);
            _grpContact.Controls.Add(_txtSurname);
            _grpContact.Controls.Add(_lblSurname);
            _grpContact.Controls.Add(_txtTelephoneNum);
            _grpContact.Controls.Add(_lblTelephoneNum);
            _grpContact.Controls.Add(_txtEmailAddress);
            _grpContact.Controls.Add(_lblEmailAddress);
            _grpContact.Controls.Add(_txtFaxNum);
            _grpContact.Controls.Add(_lblFaxNum);
            _grpContact.Location = new Point(7, 7);
            _grpContact.Name = "grpContact";
            _grpContact.Size = new Size(655, 367);
            _grpContact.TabIndex = 1;
            _grpContact.TabStop = false;
            _grpContact.Text = "Main Details";
            //
            // cboSalutation
            //
            _cboSalutation.Cursor = Cursors.Hand;
            _cboSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSalutation.Location = new Point(112, 29);
            _cboSalutation.Name = "cboSalutation";
            _cboSalutation.Size = new Size(83, 21);
            _cboSalutation.TabIndex = 55;
            _cboSalutation.Tag = "Site.RegionID";
            //
            // Label6
            //
            _Label6.Location = new Point(8, 32);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(100, 20);
            _Label6.TabIndex = 38;
            _Label6.Text = "Salutation";
            //
            // chkPortalGSRPrint
            //
            _chkPortalGSRPrint.AutoSize = true;
            _chkPortalGSRPrint.CheckAlign = ContentAlignment.MiddleRight;
            _chkPortalGSRPrint.Location = new Point(9, 337);
            _chkPortalGSRPrint.Name = "chkPortalGSRPrint";
            _chkPortalGSRPrint.Size = new Size(118, 17);
            _chkPortalGSRPrint.TabIndex = 37;
            _chkPortalGSRPrint.Text = "Portal GSR Print";
            _chkPortalGSRPrint.UseVisualStyleBackColor = true;
            //
            // txtPortalPassword
            //
            _txtPortalPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPortalPassword.Location = new Point(112, 279);
            _txtPortalPassword.MaxLength = 20;
            _txtPortalPassword.Name = "txtPortalPassword";
            _txtPortalPassword.Size = new Size(529, 21);
            _txtPortalPassword.TabIndex = 8;
            _txtPortalPassword.Tag = "";
            //
            // txtPortalUsername
            //
            _txtPortalUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPortalUsername.Location = new Point(112, 250);
            _txtPortalUsername.MaxLength = 20;
            _txtPortalUsername.Name = "txtPortalUsername";
            _txtPortalUsername.Size = new Size(529, 21);
            _txtPortalUsername.TabIndex = 7;
            _txtPortalUsername.Tag = "";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 278);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(100, 23);
            _Label3.TabIndex = 35;
            _Label3.Text = "Portal Password";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 247);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(104, 23);
            _Label2.TabIndex = 34;
            _Label2.Text = "Portal Username";
            //
            // txtMobileNo
            //
            _txtMobileNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtMobileNo.Location = new Point(112, 157);
            _txtMobileNo.MaxLength = 20;
            _txtMobileNo.Name = "txtMobileNo";
            _txtMobileNo.Size = new Size(529, 21);
            _txtMobileNo.TabIndex = 4;
            _txtMobileNo.Tag = "Contact.MobileNo";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 155);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(109, 20);
            _Label1.TabIndex = 33;
            _Label1.Text = "Mobile No";
            //
            // txtFirstName
            //
            _txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFirstName.Location = new Point(112, 64);
            _txtFirstName.MaxLength = 255;
            _txtFirstName.Name = "txtFirstName";
            _txtFirstName.Size = new Size(529, 21);
            _txtFirstName.TabIndex = 1;
            _txtFirstName.Tag = "Contact.FirstName";
            //
            // lblFirstName
            //
            _lblFirstName.Location = new Point(8, 62);
            _lblFirstName.Name = "lblFirstName";
            _lblFirstName.Size = new Size(109, 20);
            _lblFirstName.TabIndex = 31;
            _lblFirstName.Text = "First Name";
            //
            // txtSurname
            //
            _txtSurname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSurname.Location = new Point(112, 95);
            _txtSurname.MaxLength = 255;
            _txtSurname.Name = "txtSurname";
            _txtSurname.Size = new Size(529, 21);
            _txtSurname.TabIndex = 2;
            _txtSurname.Tag = "Contact.Surname";
            //
            // lblSurname
            //
            _lblSurname.Location = new Point(8, 93);
            _lblSurname.Name = "lblSurname";
            _lblSurname.Size = new Size(109, 20);
            _lblSurname.TabIndex = 31;
            _lblSurname.Text = "Surname";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(112, 126);
            _txtTelephoneNum.MaxLength = 20;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(529, 21);
            _txtTelephoneNum.TabIndex = 3;
            _txtTelephoneNum.Tag = "Contact.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(8, 124);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(109, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Tel";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(112, 188);
            _txtEmailAddress.MaxLength = 50;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(529, 21);
            _txtEmailAddress.TabIndex = 5;
            _txtEmailAddress.Tag = "Contact.EmailAddress";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(8, 186);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(109, 20);
            _lblEmailAddress.TabIndex = 31;
            _lblEmailAddress.Text = "Email Address";
            //
            // txtFaxNum
            //
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(112, 219);
            _txtFaxNum.MaxLength = 20;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(529, 21);
            _txtFaxNum.TabIndex = 6;
            _txtFaxNum.Tag = "Contact.FaxNum";
            //
            // lblFaxNum
            //
            _lblFaxNum.Location = new Point(8, 217);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(109, 20);
            _lblFaxNum.TabIndex = 31;
            _lblFaxNum.Text = "Fax";
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_btnDeleteNote);
            _GroupBox1.Controls.Add(_btnAddNote);
            _GroupBox1.Controls.Add(_dgNotes);
            _GroupBox1.Location = new Point(8, 387);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(653, 231);
            _GroupBox1.TabIndex = 38;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Notes";
            //
            // Label5
            //
            _Label5.Location = new Point(32, 16);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(160, 16);
            _Label5.TabIndex = 13;
            _Label5.Text = "=Active Reminder Set";
            //
            // Label4
            //
            _Label4.BackColor = Color.LightGreen;
            _Label4.BorderStyle = BorderStyle.FixedSingle;
            _Label4.Location = new Point(8, 16);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(20, 17);
            _Label4.TabIndex = 12;
            //
            // btnDeleteNote
            //
            _btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteNote.Location = new Point(584, 196);
            _btnDeleteNote.Name = "btnDeleteNote";
            _btnDeleteNote.Size = new Size(56, 23);
            _btnDeleteNote.TabIndex = 11;
            _btnDeleteNote.Text = "Delete";
            //
            // btnAddNote
            //
            _btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddNote.Location = new Point(10, 196);
            _btnAddNote.Name = "btnAddNote";
            _btnAddNote.Size = new Size(54, 23);
            _btnAddNote.TabIndex = 10;
            _btnAddNote.Text = "Add";
            //
            // dgNotes
            //
            _dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgNotes.DataMember = "";
            _dgNotes.HeaderForeColor = SystemColors.ControlText;
            _dgNotes.Location = new Point(8, 32);
            _dgNotes.Name = "dgNotes";
            _dgNotes.Size = new Size(637, 164);
            _dgNotes.TabIndex = 9;
            //
            // txtEID
            //
            _txtEID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEID.Location = new Point(112, 308);
            _txtEID.MaxLength = 20;
            _txtEID.Name = "txtEID";
            _txtEID.Size = new Size(529, 21);
            _txtEID.TabIndex = 56;
            _txtEID.Tag = "";
            //
            // Label7
            //
            _Label7.Location = new Point(8, 312);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(100, 23);
            _Label7.TabIndex = 57;
            _Label7.Text = "Portal EID ";
            //
            // UCContact
            //
            Controls.Add(_GroupBox1);
            Controls.Add(_grpContact);
            Name = "UCContact";
            Size = new Size(667, 624);
            _grpContact.ResumeLayout(false);
            _grpContact.PerformLayout();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgNotes).EndInit();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupNotesDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentContact;
            }
        }

        
        
        private int _SiteID = 0;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Contacts.Contact _currentContact;

        public Entity.Contacts.Contact CurrentContact
        {
            get
            {
                return _currentContact;
            }

            set
            {
                _currentContact = value;
                if (CurrentContact is null)
                {
                    CurrentContact = new Entity.Contacts.Contact();
                    CurrentContact.Exists = false;
                }

                if (CurrentContact.Exists)
                {
                    btnAddNote.Enabled = true;
                    btnDeleteNote.Enabled = true;
                    Populate();
                }
                else
                {
                    btnAddNote.Enabled = false;
                    btnDeleteNote.Enabled = false;
                }
            }
        }

        private DataView _NotesTable = null;

        public DataView NotesDataView
        {
            get
            {
                return _NotesTable;
            }

            set
            {
                _NotesTable = value;
                _NotesTable.Table.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString();
                _NotesTable.AllowNew = false;
                _NotesTable.AllowEdit = false;
                _NotesTable.AllowDelete = false;
                dgNotes.DataSource = NotesDataView;
            }
        }

        private DataRow SelectedNoteDataRow
        {
            get
            {
                if (!(dgNotes.CurrentRowIndex == -1))
                {
                    return NotesDataView[dgNotes.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        public void SetupNotesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgNotes);
            var tStyle = dgNotes.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ReminderSet = new ActiveReminderColourColumn();
            ReminderSet.HeaderText = "";
            ReminderSet.MappingName = "ReminderStatusID";
            ReminderSet.ReadOnly = true;
            ReminderSet.Width = 20;
            ReminderSet.NullText = "";
            tStyle.GridColumnStyles.Add(ReminderSet);
            var NoteDate = new DataGridLabelColumn();
            NoteDate.Format = "dd/MM/yyyy HH:mm";
            NoteDate.FormatInfo = null;
            NoteDate.HeaderText = "Date";
            NoteDate.MappingName = "NoteDate";
            NoteDate.ReadOnly = true;
            NoteDate.Width = 110;
            NoteDate.NullText = "";
            tStyle.GridColumnStyles.Add(NoteDate);
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 120;
            Category.NullText = "";
            tStyle.GridColumnStyles.Add(Category);
            var Note = new DataGridLabelColumn();
            Note.Format = "";
            Note.FormatInfo = null;
            Note.HeaderText = "Note";
            Note.MappingName = "Note";
            Note.ReadOnly = true;
            Note.Width = 130;
            Note.NullText = "";
            tStyle.GridColumnStyles.Add(Note);
            var EnteredBy = new DataGridLabelColumn();
            EnteredBy.Format = "";
            EnteredBy.FormatInfo = null;
            EnteredBy.HeaderText = "Entered By";
            EnteredBy.MappingName = "EnteredBy";
            EnteredBy.ReadOnly = true;
            EnteredBy.Width = 150;
            EnteredBy.NullText = "";
            tStyle.GridColumnStyles.Add(EnteredBy);
            var EnteredOn = new DataGridLabelColumn();
            EnteredOn.Format = "dd/MM/yyyy HH:mm";
            EnteredOn.FormatInfo = null;
            EnteredOn.HeaderText = "Entered On";
            EnteredOn.MappingName = "DateCreated";
            EnteredOn.ReadOnly = true;
            EnteredOn.Width = 110;
            EnteredOn.NullText = "";
            tStyle.GridColumnStyles.Add(EnteredOn);
            var UserFor = new DataGridLabelColumn();
            UserFor.Format = "";
            UserFor.FormatInfo = null;
            UserFor.HeaderText = "For User";
            UserFor.MappingName = "UserFor";
            UserFor.ReadOnly = true;
            UserFor.Width = 150;
            UserFor.NullText = "";
            tStyle.GridColumnStyles.Add(UserFor);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblNotes.ToString();
            dgNotes.TableStyles.Add(tStyle);
        }

        private void UCContact_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgNotes_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedNoteDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMNotes), true, new object[] { SelectedNoteDataRow["NoteID"], CurrentContact.ContactID, this });
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMNotes), true, new object[] { 0, CurrentContact.ContactID, this });
            NotesDataView = App.DB.Notes.NotesForContact(CurrentContact.ContactID);
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            if (SelectedNoteDataRow is null)
            {
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.Notes.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedNoteDataRow["NoteID"]));
            NotesDataView = App.DB.Notes.NotesForContact(CurrentContact.ContactID);
        }

        
        

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentContact = App.DB.Contact.Contact_Get(ID);
            }

            var argcombo = cboSalutation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContact.Salutation);
            txtFirstName.Text = CurrentContact.FirstName;
            txtSurname.Text = CurrentContact.Surname;
            txtTelephoneNum.Text = CurrentContact.TelephoneNum;
            txtEmailAddress.Text = CurrentContact.EmailAddress;
            txtFaxNum.Text = CurrentContact.FaxNum;
            txtMobileNo.Text = CurrentContact.MobileNo;
            txtPortalUsername.Text = CurrentContact.PortalUserName;
            txtPortalPassword.Text = CurrentContact.PortalPassword;
            chkPortalGSRPrint.Checked = CurrentContact.PortalGSRPrint;
            txtEID.Text = CurrentContact.EID.ToString();
            NotesDataView = App.DB.Notes.NotesForContact(CurrentContact.ContactID);
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentContact.IgnoreExceptionsOnSetMethods = true;
                CurrentContact.SetPropertyID = SiteID;
                CurrentContact.SetSalutation = Combo.get_GetSelectedItemValue(cboSalutation);
                CurrentContact.SetFirstName = txtFirstName.Text.Trim();
                CurrentContact.SetSurname = txtSurname.Text.Trim();
                CurrentContact.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentContact.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentContact.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentContact.SetMobileNo = txtMobileNo.Text.Trim();
                CurrentContact.SetPortalPassword = txtPortalPassword.Text.Trim();
                CurrentContact.SetPortalUserName = txtPortalUsername.Text.Trim();
                CurrentContact.SetPortalGSRPrint = chkPortalGSRPrint.Checked;
                if (string.IsNullOrEmpty(txtEID.Text) | !Information.IsNumeric(txtEID.Text))
                    txtEID.Text = 0.ToString();
                CurrentContact.SetEID = txtEID.Text;
                if (CurrentContact.Exists)
                {
                    App.DB.Contact.Update(CurrentContact);
                }
                else
                {
                    CurrentContact = App.DB.Contact.Insert(CurrentContact);
                }

                StateChanged?.Invoke(CurrentContact.ContactID);
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