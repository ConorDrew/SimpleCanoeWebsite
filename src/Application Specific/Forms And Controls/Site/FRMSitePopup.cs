using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSitePopup : FRMBaseForm, IForm
    {
        

        public FRMSitePopup() : base()
        {
            
            
            this.Load += FRMSitePopup_Load;

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

        private Button _btnSendEmailToSite;

        internal Button btnSendEmailToSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSendEmailToSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSendEmailToSite != null)
                {
                    _btnSendEmailToSite.Click -= btnSendEmailToSite_Click;
                }

                _btnSendEmailToSite = value;
                if (_btnSendEmailToSite != null)
                {
                    _btnSendEmailToSite.Click += btnSendEmailToSite_Click;
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
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

        private TextBox _txtAddress4;

        internal TextBox txtAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress4 != null)
                {
                }

                _txtAddress4 = value;
                if (_txtAddress4 != null)
                {
                }
            }
        }

        private Label _lblTown;

        internal Label lblTown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTown != null)
                {
                }

                _lblTown = value;
                if (_lblTown != null)
                {
                }
            }
        }

        private TextBox _txtAddress5;

        internal TextBox txtAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress5 != null)
                {
                }

                _txtAddress5 = value;
                if (_txtAddress5 != null)
                {
                }
            }
        }

        private Label _lblCounty;

        internal Label lblCounty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCounty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCounty != null)
                {
                }

                _lblCounty = value;
                if (_lblCounty != null)
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

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnSendEmailToSite = new Button();
            _btnSendEmailToSite.Click += new EventHandler(btnSendEmailToSite_Click);
            _txtName = new TextBox();
            _Label3 = new Label();
            _txtAddress1 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress2 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress4 = new TextBox();
            _lblTown = new Label();
            _txtAddress5 = new TextBox();
            _lblCounty = new Label();
            _txtPostcode = new TextBox();
            _lblPostcode = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(10, 290);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 25);
            _btnClose.TabIndex = 12;
            _btnClose.Text = "Close";
            //
            // btnSendEmailToSite
            //
            _btnSendEmailToSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSendEmailToSite.Location = new Point(541, 264);
            _btnSendEmailToSite.Name = "btnSendEmailToSite";
            _btnSendEmailToSite.Size = new Size(75, 23);
            _btnSendEmailToSite.TabIndex = 11;
            _btnSendEmailToSite.Text = "Email";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(105, 45);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(511, 21);
            _txtName.TabIndex = 1;
            _txtName.Tag = "";
            //
            // Label3
            //
            _Label3.Location = new Point(7, 45);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 20);
            _Label3.TabIndex = 23;
            _Label3.Text = "Name";
            //
            // txtAddress1
            //
            _txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress1.Location = new Point(105, 69);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.ReadOnly = true;
            _txtAddress1.Size = new Size(511, 21);
            _txtAddress1.TabIndex = 2;
            _txtAddress1.Tag = "Site.Address1";
            //
            // lblAddress1
            //
            _lblAddress1.Location = new Point(7, 69);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(67, 20);
            _lblAddress1.TabIndex = 26;
            _lblAddress1.Text = "Address 1";
            //
            // txtAddress2
            //
            _txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress2.Location = new Point(105, 93);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.ReadOnly = true;
            _txtAddress2.Size = new Size(511, 21);
            _txtAddress2.TabIndex = 3;
            _txtAddress2.Tag = "Site.Address2";
            //
            // lblAddress2
            //
            _lblAddress2.Location = new Point(7, 93);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(72, 20);
            _lblAddress2.TabIndex = 28;
            _lblAddress2.Text = "Address 2";
            //
            // txtAddress3
            //
            _txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress3.Location = new Point(105, 117);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.ReadOnly = true;
            _txtAddress3.Size = new Size(511, 21);
            _txtAddress3.TabIndex = 4;
            _txtAddress3.Tag = "Site.Address3";
            //
            // lblAddress3
            //
            _lblAddress3.Location = new Point(7, 117);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(64, 20);
            _lblAddress3.TabIndex = 32;
            _lblAddress3.Text = "Address 3";
            //
            // txtAddress4
            //
            _txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress4.Location = new Point(105, 141);
            _txtAddress4.MaxLength = 100;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.ReadOnly = true;
            _txtAddress4.Size = new Size(511, 21);
            _txtAddress4.TabIndex = 5;
            _txtAddress4.Tag = "Site.Town";
            //
            // lblTown
            //
            _lblTown.Location = new Point(7, 141);
            _lblTown.Name = "lblTown";
            _lblTown.Size = new Size(67, 20);
            _lblTown.TabIndex = 35;
            _lblTown.Text = "Address 4";
            //
            // txtAddress5
            //
            _txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress5.Location = new Point(105, 165);
            _txtAddress5.MaxLength = 100;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.ReadOnly = true;
            _txtAddress5.Size = new Size(511, 21);
            _txtAddress5.TabIndex = 6;
            _txtAddress5.Tag = "Site.County";
            //
            // lblCounty
            //
            _lblCounty.Location = new Point(7, 165);
            _lblCounty.Name = "lblCounty";
            _lblCounty.Size = new Size(64, 20);
            _lblCounty.TabIndex = 37;
            _lblCounty.Text = "Address 5";
            //
            // txtPostcode
            //
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Location = new Point(105, 189);
            _txtPostcode.MaxLength = 10;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.ReadOnly = true;
            _txtPostcode.Size = new Size(511, 21);
            _txtPostcode.TabIndex = 7;
            _txtPostcode.Tag = "Site.Postcode";
            //
            // lblPostcode
            //
            _lblPostcode.Location = new Point(7, 189);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(67, 20);
            _lblPostcode.TabIndex = 40;
            _lblPostcode.Text = "Postcode";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(105, 213);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.ReadOnly = true;
            _txtTelephoneNum.Size = new Size(511, 21);
            _txtTelephoneNum.TabIndex = 8;
            _txtTelephoneNum.Tag = "Site.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(7, 213);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(107, 20);
            _lblTelephoneNum.TabIndex = 41;
            _lblTelephoneNum.Text = "Tel";
            //
            // txtFaxNum
            //
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(105, 237);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.ReadOnly = true;
            _txtFaxNum.Size = new Size(511, 21);
            _txtFaxNum.TabIndex = 9;
            _txtFaxNum.Tag = "Site.FaxNum";
            //
            // lblFaxNum
            //
            _lblFaxNum.Location = new Point(7, 237);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(72, 20);
            _lblFaxNum.TabIndex = 42;
            _lblFaxNum.Text = "Fax";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(105, 263);
            _txtEmailAddress.MaxLength = 100;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.ReadOnly = true;
            _txtEmailAddress.Size = new Size(430, 21);
            _txtEmailAddress.TabIndex = 10;
            _txtEmailAddress.Tag = "Site.EmailAddress";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(7, 261);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(99, 20);
            _lblEmailAddress.TabIndex = 43;
            _lblEmailAddress.Text = "Email Address";
            //
            // frmCandidateAssessment
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(628, 327);
            Controls.Add(_btnSendEmailToSite);
            Controls.Add(_txtName);
            Controls.Add(_Label3);
            Controls.Add(_txtAddress1);
            Controls.Add(_lblAddress1);
            Controls.Add(_txtAddress2);
            Controls.Add(_lblAddress2);
            Controls.Add(_txtAddress3);
            Controls.Add(_lblAddress3);
            Controls.Add(_txtAddress4);
            Controls.Add(_lblTown);
            Controls.Add(_txtAddress5);
            Controls.Add(_lblCounty);
            Controls.Add(_txtPostcode);
            Controls.Add(_lblPostcode);
            Controls.Add(_txtTelephoneNum);
            Controls.Add(_lblTelephoneNum);
            Controls.Add(_txtFaxNum);
            Controls.Add(_lblFaxNum);
            Controls.Add(_txtEmailAddress);
            Controls.Add(_lblEmailAddress);
            Controls.Add(_btnClose);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(636, 361);
            Name = "frmCandidateAssessment";
            Text = "Property : ID {0}";
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_lblEmailAddress, 0);
            Controls.SetChildIndex(_txtEmailAddress, 0);
            Controls.SetChildIndex(_lblFaxNum, 0);
            Controls.SetChildIndex(_txtFaxNum, 0);
            Controls.SetChildIndex(_lblTelephoneNum, 0);
            Controls.SetChildIndex(_txtTelephoneNum, 0);
            Controls.SetChildIndex(_lblPostcode, 0);
            Controls.SetChildIndex(_txtPostcode, 0);
            Controls.SetChildIndex(_lblCounty, 0);
            Controls.SetChildIndex(_txtAddress5, 0);
            Controls.SetChildIndex(_lblTown, 0);
            Controls.SetChildIndex(_txtAddress4, 0);
            Controls.SetChildIndex(_lblAddress3, 0);
            Controls.SetChildIndex(_txtAddress3, 0);
            Controls.SetChildIndex(_lblAddress2, 0);
            Controls.SetChildIndex(_txtAddress2, 0);
            Controls.SetChildIndex(_lblAddress1, 0);
            Controls.SetChildIndex(_txtAddress1, 0);
            Controls.SetChildIndex(_Label3, 0);
            Controls.SetChildIndex(_txtName, 0);
            Controls.SetChildIndex(_btnSendEmailToSite, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            CurrentSite = App.DB.Sites.Get(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0)));
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
            // DO NOTHING
        }

        
        
        private Entity.Sites.Site _currentSite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _currentSite;
            }

            set
            {
                _currentSite = value;
                Populate();
            }
        }

        private void FRMSitePopup_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSendEmailToSite_Click(object sender, EventArgs e)
        {
            var myProcess = new Process();
            myProcess.StartInfo.FileName = "mailto:" + CurrentSite.EmailAddress;
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.RedirectStandardOutput = false;
            myProcess.Start();
            myProcess.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        
        

        private void Populate()
        {
            Text = "Property : ID " + CurrentSite.SiteID;
            txtName.Text = CurrentSite.Name;
            txtAddress1.Text = CurrentSite.Address1;
            txtAddress2.Text = CurrentSite.Address2;
            txtAddress3.Text = CurrentSite.Address3;
            txtAddress4.Text = CurrentSite.Address4;
            txtAddress5.Text = CurrentSite.Address5;
            txtPostcode.Text = CurrentSite.Postcode;
            txtTelephoneNum.Text = CurrentSite.TelephoneNum;
            txtFaxNum.Text = CurrentSite.FaxNum;
            txtEmailAddress.Text = CurrentSite.EmailAddress;
        }

        
    }
}