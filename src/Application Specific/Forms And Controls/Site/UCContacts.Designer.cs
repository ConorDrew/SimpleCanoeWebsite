using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class UCContacts
    {


        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSiteContacts = new GroupBox();
            _grpContacts = new GroupBox();
            _dgSiteContacts = new DataGrid();
            _dgSiteContacts.Click += new EventHandler(dgSiteContacts_Click);
            _grpContact = new GroupBox();
            _lblPostcode = new Label();
            _txtPostcode = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress2 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress1 = new TextBox();
            _lblRelationship = new Label();
            _cboRelationship = new ComboBox();
            _chkIsPOC = new CheckBox();
            _chkOnContract = new CheckBox();
            _btnNewContact = new Button();
            _btnNewContact.Click += new EventHandler(btnNewContact_Click);
            _btnDeleteContact = new Button();
            _btnDeleteContact.Click += new EventHandler(btnDeleteContact_Click);
            _btnSaveContact = new Button();
            _btnSaveContact.Click += new EventHandler(btnSaveContact_Click);
            _chkNoMarketing = new CheckBox();
            _lblEmailAddress = new Label();
            _txtEmailAddress = new TextBox();
            _lblMobileNumber = new Label();
            _lblLastName = new Label();
            _lblFirstname = new Label();
            _txtMobileNumber = new TextBox();
            _txtLastname = new TextBox();
            _txtFirstName = new TextBox();
            _lblTitle = new Label();
            _cboTitle = new ComboBox();
            _grpSiteContacts.SuspendLayout();
            _grpContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteContacts).BeginInit();
            _grpContact.SuspendLayout();
            SuspendLayout();
            // 
            // grpSiteContacts
            // 
            _grpSiteContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSiteContacts.AutoSize = true;
            _grpSiteContacts.Controls.Add(_grpContacts);
            _grpSiteContacts.Controls.Add(_grpContact);
            _grpSiteContacts.Location = new Point(0, 0);
            _grpSiteContacts.Margin = new Padding(0);
            _grpSiteContacts.Name = "grpSiteContacts";
            _grpSiteContacts.Padding = new Padding(0);
            _grpSiteContacts.Size = new Size(1401, 670);
            _grpSiteContacts.TabIndex = 15;
            _grpSiteContacts.TabStop = false;
            _grpSiteContacts.Text = "Site Contacts";
            // 
            // grpContacts
            // 
            _grpContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContacts.Controls.Add(_dgSiteContacts);
            _grpContacts.Location = new Point(13, 183);
            _grpContacts.Name = "grpContacts";
            _grpContacts.Size = new Size(1381, 471);
            _grpContacts.TabIndex = 149;
            _grpContacts.TabStop = false;
            _grpContacts.Text = "Contacts";
            // 
            // dgSiteContacts
            // 
            _dgSiteContacts.DataMember = "";
            _dgSiteContacts.Dock = DockStyle.Fill;
            _dgSiteContacts.HeaderForeColor = SystemColors.ControlText;
            _dgSiteContacts.Location = new Point(3, 17);
            _dgSiteContacts.Name = "dgSiteContacts";
            _dgSiteContacts.Size = new Size(1375, 451);
            _dgSiteContacts.TabIndex = 11;
            // 
            // grpContact
            // 
            _grpContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpContact.Controls.Add(_lblPostcode);
            _grpContact.Controls.Add(_txtPostcode);
            _grpContact.Controls.Add(_lblAddress3);
            _grpContact.Controls.Add(_txtAddress3);
            _grpContact.Controls.Add(_lblAddress2);
            _grpContact.Controls.Add(_txtAddress2);
            _grpContact.Controls.Add(_lblAddress1);
            _grpContact.Controls.Add(_txtAddress1);
            _grpContact.Controls.Add(_lblRelationship);
            _grpContact.Controls.Add(_cboRelationship);
            _grpContact.Controls.Add(_chkIsPOC);
            _grpContact.Controls.Add(_chkOnContract);
            _grpContact.Controls.Add(_btnNewContact);
            _grpContact.Controls.Add(_btnDeleteContact);
            _grpContact.Controls.Add(_btnSaveContact);
            _grpContact.Controls.Add(_chkNoMarketing);
            _grpContact.Controls.Add(_lblEmailAddress);
            _grpContact.Controls.Add(_txtEmailAddress);
            _grpContact.Controls.Add(_lblMobileNumber);
            _grpContact.Controls.Add(_lblLastName);
            _grpContact.Controls.Add(_lblFirstname);
            _grpContact.Controls.Add(_txtMobileNumber);
            _grpContact.Controls.Add(_txtLastname);
            _grpContact.Controls.Add(_txtFirstName);
            _grpContact.Controls.Add(_lblTitle);
            _grpContact.Controls.Add(_cboTitle);
            _grpContact.Location = new Point(13, 17);
            _grpContact.Name = "grpContact";
            _grpContact.Size = new Size(1381, 160);
            _grpContact.TabIndex = 115;
            _grpContact.TabStop = false;
            _grpContact.Text = "Contact";
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(545, 93);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(82, 21);
            _lblPostcode.TabIndex = 161;
            _lblPostcode.Text = "Postcode";
            _lblPostcode.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPostcode
            // 
            _txtPostcode.Location = new Point(633, 93);
            _txtPostcode.MaxLength = 255;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(170, 21);
            _txtPostcode.TabIndex = 148;
            _txtPostcode.Tag = "";
            // 
            // lblAddress3
            // 
            _lblAddress3.Location = new Point(545, 58);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(82, 21);
            _lblAddress3.TabIndex = 159;
            _lblAddress3.Text = "Address 3";
            _lblAddress3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddress3
            // 
            _txtAddress3.Location = new Point(633, 58);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(170, 21);
            _txtAddress3.TabIndex = 147;
            _txtAddress3.Tag = "";
            // 
            // lblAddress2
            // 
            _lblAddress2.Location = new Point(545, 22);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(82, 21);
            _lblAddress2.TabIndex = 157;
            _lblAddress2.Text = "Address 2";
            _lblAddress2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddress2
            // 
            _txtAddress2.Location = new Point(633, 22);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(170, 21);
            _txtAddress2.TabIndex = 146;
            _txtAddress2.Tag = "";
            // 
            // lblAddress1
            // 
            _lblAddress1.Location = new Point(265, 93);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(82, 21);
            _lblAddress1.TabIndex = 155;
            _lblAddress1.Text = "Address 1";
            _lblAddress1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddress1
            // 
            _txtAddress1.Location = new Point(353, 93);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(170, 21);
            _txtAddress1.TabIndex = 145;
            _txtAddress1.Tag = "";
            // 
            // lblRelationship
            // 
            _lblRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblRelationship.Location = new Point(823, 23);
            _lblRelationship.Name = "lblRelationship";
            _lblRelationship.Size = new Size(152, 21);
            _lblRelationship.TabIndex = 153;
            _lblRelationship.Text = "Relationship To Tennent";
            _lblRelationship.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboRelationship
            // 
            _cboRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboRelationship.FormattingEnabled = true;
            _cboRelationship.Location = new Point(981, 23);
            _cboRelationship.Name = "cboRelationship";
            _cboRelationship.Size = new Size(170, 21);
            _cboRelationship.TabIndex = 149;
            // 
            // chkIsPOC
            // 
            _chkIsPOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkIsPOC.Location = new Point(1179, 88);
            _chkIsPOC.Name = "chkIsPOC";
            _chkIsPOC.Size = new Size(120, 24);
            _chkIsPOC.TabIndex = 152;
            _chkIsPOC.Text = "Point Of Contact";
            // 
            // chkOnContract
            // 
            _chkOnContract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkOnContract.Location = new Point(1179, 54);
            _chkOnContract.Name = "chkOnContract";
            _chkOnContract.Size = new Size(120, 24);
            _chkOnContract.TabIndex = 151;
            _chkOnContract.Text = "On Contract";
            // 
            // btnNewContact
            // 
            _btnNewContact.Location = new Point(15, 131);
            _btnNewContact.Name = "btnNewContact";
            _btnNewContact.Size = new Size(75, 23);
            _btnNewContact.TabIndex = 149;
            _btnNewContact.Text = "Clear";
            _btnNewContact.UseVisualStyleBackColor = true;
            // 
            // btnDeleteContact
            // 
            _btnDeleteContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDeleteContact.Location = new Point(1179, 131);
            _btnDeleteContact.Name = "btnDeleteContact";
            _btnDeleteContact.Size = new Size(75, 23);
            _btnDeleteContact.TabIndex = 148;
            _btnDeleteContact.Text = "Delete";
            // 
            // btnSaveContact
            // 
            _btnSaveContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveContact.Location = new Point(1300, 131);
            _btnSaveContact.Name = "btnSaveContact";
            _btnSaveContact.Size = new Size(75, 23);
            _btnSaveContact.TabIndex = 147;
            _btnSaveContact.Text = "Save";
            // 
            // chkNoMarketing
            // 
            _chkNoMarketing.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkNoMarketing.Location = new Point(1179, 20);
            _chkNoMarketing.Name = "chkNoMarketing";
            _chkNoMarketing.Size = new Size(120, 24);
            _chkNoMarketing.TabIndex = 150;
            _chkNoMarketing.Text = "No Marketing";
            // 
            // lblEmailAddress
            // 
            _lblEmailAddress.Location = new Point(297, 58);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(50, 21);
            _lblEmailAddress.TabIndex = 145;
            _lblEmailAddress.Text = "Email";
            _lblEmailAddress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEmailAddress
            // 
            _txtEmailAddress.Location = new Point(353, 58);
            _txtEmailAddress.MaxLength = 255;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(170, 21);
            _txtEmailAddress.TabIndex = 144;
            _txtEmailAddress.Tag = "";
            // 
            // lblMobileNumber
            // 
            _lblMobileNumber.Location = new Point(297, 19);
            _lblMobileNumber.Name = "lblMobileNumber";
            _lblMobileNumber.Size = new Size(50, 21);
            _lblMobileNumber.TabIndex = 141;
            _lblMobileNumber.Text = "Mobile";
            _lblMobileNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLastName
            // 
            _lblLastName.Location = new Point(15, 92);
            _lblLastName.Name = "lblLastName";
            _lblLastName.Size = new Size(68, 21);
            _lblLastName.TabIndex = 140;
            _lblLastName.Text = "Last Name";
            _lblLastName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFirstname
            // 
            _lblFirstname.Location = new Point(15, 57);
            _lblFirstname.Name = "lblFirstname";
            _lblFirstname.Size = new Size(68, 21);
            _lblFirstname.TabIndex = 139;
            _lblFirstname.Text = "First Name";
            _lblFirstname.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMobileNumber
            // 
            _txtMobileNumber.Location = new Point(353, 20);
            _txtMobileNumber.MaxLength = 255;
            _txtMobileNumber.Name = "txtMobileNumber";
            _txtMobileNumber.Size = new Size(170, 21);
            _txtMobileNumber.TabIndex = 138;
            _txtMobileNumber.Tag = "";
            // 
            // txtLastname
            // 
            _txtLastname.Location = new Point(89, 92);
            _txtLastname.MaxLength = 255;
            _txtLastname.Name = "txtLastname";
            _txtLastname.Size = new Size(170, 21);
            _txtLastname.TabIndex = 137;
            _txtLastname.Tag = "";
            // 
            // txtFirstName
            // 
            _txtFirstName.Location = new Point(89, 58);
            _txtFirstName.MaxLength = 255;
            _txtFirstName.Name = "txtFirstName";
            _txtFirstName.Size = new Size(170, 21);
            _txtFirstName.TabIndex = 136;
            _txtFirstName.Tag = "";
            // 
            // lblTitle
            // 
            _lblTitle.Location = new Point(15, 21);
            _lblTitle.Name = "lblTitle";
            _lblTitle.Size = new Size(68, 20);
            _lblTitle.TabIndex = 135;
            _lblTitle.Text = "Title";
            _lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboTitle
            // 
            _cboTitle.FormattingEnabled = true;
            _cboTitle.Location = new Point(89, 20);
            _cboTitle.Name = "cboTitle";
            _cboTitle.Size = new Size(170, 21);
            _cboTitle.TabIndex = 134;
            // 
            // UCContacts
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(_grpSiteContacts);
            Name = "UCContacts";
            Size = new Size(1403, 672);
            _grpSiteContacts.ResumeLayout(false);
            _grpContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSiteContacts).EndInit();
            _grpContact.ResumeLayout(false);
            _grpContact.PerformLayout();
            Load += new EventHandler(UCSite_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox _grpSiteContacts;

        internal GroupBox grpSiteContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteContacts != null)
                {
                }

                _grpSiteContacts = value;
                if (_grpSiteContacts != null)
                {
                }
            }
        }

        private GroupBox _grpContacts;

        internal GroupBox grpContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContacts != null)
                {
                }

                _grpContacts = value;
                if (_grpContacts != null)
                {
                }
            }
        }

        private DataGrid _dgSiteContacts;

        internal DataGrid dgSiteContacts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteContacts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteContacts != null)
                {
                    _dgSiteContacts.Click -= dgSiteContacts_Click;
                }

                _dgSiteContacts = value;
                if (_dgSiteContacts != null)
                {
                    _dgSiteContacts.Click += dgSiteContacts_Click;
                }
            }
        }

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

        private CheckBox _chkOnContract;

        internal CheckBox chkOnContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkOnContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkOnContract != null)
                {
                }

                _chkOnContract = value;
                if (_chkOnContract != null)
                {
                }
            }
        }

        private Button _btnNewContact;

        internal Button btnNewContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNewContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNewContact != null)
                {
                    _btnNewContact.Click -= btnNewContact_Click;
                }

                _btnNewContact = value;
                if (_btnNewContact != null)
                {
                    _btnNewContact.Click += btnNewContact_Click;
                }
            }
        }

        private Button _btnDeleteContact;

        internal Button btnDeleteContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteContact != null)
                {
                    _btnDeleteContact.Click -= btnDeleteContact_Click;
                }

                _btnDeleteContact = value;
                if (_btnDeleteContact != null)
                {
                    _btnDeleteContact.Click += btnDeleteContact_Click;
                }
            }
        }

        private Button _btnSaveContact;

        internal Button btnSaveContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveContact != null)
                {
                    _btnSaveContact.Click -= btnSaveContact_Click;
                }

                _btnSaveContact = value;
                if (_btnSaveContact != null)
                {
                    _btnSaveContact.Click += btnSaveContact_Click;
                }
            }
        }

        private CheckBox _chkNoMarketing;

        internal CheckBox chkNoMarketing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNoMarketing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNoMarketing != null)
                {
                }

                _chkNoMarketing = value;
                if (_chkNoMarketing != null)
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

        private Label _lblMobileNumber;

        internal Label lblMobileNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMobileNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMobileNumber != null)
                {
                }

                _lblMobileNumber = value;
                if (_lblMobileNumber != null)
                {
                }
            }
        }

        private Label _lblLastName;

        internal Label lblLastName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLastName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLastName != null)
                {
                }

                _lblLastName = value;
                if (_lblLastName != null)
                {
                }
            }
        }

        private Label _lblFirstname;

        internal Label lblFirstname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstname != null)
                {
                }

                _lblFirstname = value;
                if (_lblFirstname != null)
                {
                }
            }
        }

        private TextBox _txtMobileNumber;

        internal TextBox txtMobileNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMobileNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMobileNumber != null)
                {
                }

                _txtMobileNumber = value;
                if (_txtMobileNumber != null)
                {
                }
            }
        }

        private TextBox _txtLastname;

        internal TextBox txtLastname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLastname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLastname != null)
                {
                }

                _txtLastname = value;
                if (_txtLastname != null)
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

        private Label _lblTitle;

        internal Label lblTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTitle != null)
                {
                }

                _lblTitle = value;
                if (_lblTitle != null)
                {
                }
            }
        }

        private ComboBox _cboTitle;

        internal ComboBox cboTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTitle != null)
                {
                }

                _cboTitle = value;
                if (_cboTitle != null)
                {
                }
            }
        }

        private CheckBox _chkIsPOC;

        internal CheckBox chkIsPOC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIsPOC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIsPOC != null)
                {
                }

                _chkIsPOC = value;
                if (_chkIsPOC != null)
                {
                }
            }
        }

        private Label _lblRelationship;

        internal Label lblRelationship
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRelationship;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRelationship != null)
                {
                }

                _lblRelationship = value;
                if (_lblRelationship != null)
                {
                }
            }
        }

        private ComboBox _cboRelationship;

        internal ComboBox cboRelationship
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRelationship;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRelationship != null)
                {
                }

                _cboRelationship = value;
                if (_cboRelationship != null)
                {
                }
            }
        }

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                }
            }
        }

        private Label _lblAddress3;

        internal Label lblAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress3 != null)
                {
                }

                _lblAddress3 = value;
                if (_lblAddress3 != null)
                {
                }
            }
        }

        private TextBox _txtAddress3;

        internal TextBox txtAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress3 != null)
                {
                }

                _txtAddress3 = value;
                if (_txtAddress3 != null)
                {
                }
            }
        }

        private Label _lblAddress2;

        internal Label lblAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress2 != null)
                {
                }

                _lblAddress2 = value;
                if (_lblAddress2 != null)
                {
                }
            }
        }

        private TextBox _txtAddress2;

        internal TextBox txtAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress2 != null)
                {
                }

                _txtAddress2 = value;
                if (_txtAddress2 != null)
                {
                }
            }
        }

        private Label _lblAddress1;

        internal Label lblAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress1 != null)
                {
                }

                _lblAddress1 = value;
                if (_lblAddress1 != null)
                {
                }
            }
        }

        private TextBox _txtAddress1;

        internal TextBox txtAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress1 != null)
                {
                }

                _txtAddress1 = value;
                if (_txtAddress1 != null)
                {
                }
            }
        }
    }
}