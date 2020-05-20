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
            this._btnClose = new System.Windows.Forms.Button();
            this._btnSendEmailToSite = new System.Windows.Forms.Button();
            this._txtName = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtAddress1 = new System.Windows.Forms.TextBox();
            this._lblAddress1 = new System.Windows.Forms.Label();
            this._txtAddress2 = new System.Windows.Forms.TextBox();
            this._lblAddress2 = new System.Windows.Forms.Label();
            this._txtAddress3 = new System.Windows.Forms.TextBox();
            this._lblAddress3 = new System.Windows.Forms.Label();
            this._txtAddress4 = new System.Windows.Forms.TextBox();
            this._lblTown = new System.Windows.Forms.Label();
            this._txtAddress5 = new System.Windows.Forms.TextBox();
            this._lblCounty = new System.Windows.Forms.Label();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._lblPostcode = new System.Windows.Forms.Label();
            this._txtTelephoneNum = new System.Windows.Forms.TextBox();
            this._lblTelephoneNum = new System.Windows.Forms.Label();
            this._txtFaxNum = new System.Windows.Forms.TextBox();
            this._lblFaxNum = new System.Windows.Forms.Label();
            this._txtEmailAddress = new System.Windows.Forms.TextBox();
            this._lblEmailAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(10, 285);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
            this._btnClose.TabIndex = 12;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnSendEmailToSite
            // 
            this._btnSendEmailToSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSendEmailToSite.Location = new System.Drawing.Point(541, 232);
            this._btnSendEmailToSite.Name = "_btnSendEmailToSite";
            this._btnSendEmailToSite.Size = new System.Drawing.Size(75, 23);
            this._btnSendEmailToSite.TabIndex = 11;
            this._btnSendEmailToSite.Text = "Email";
            this._btnSendEmailToSite.Click += new System.EventHandler(this.btnSendEmailToSite_Click);
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(105, 13);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.ReadOnly = true;
            this._txtName.Size = new System.Drawing.Size(511, 21);
            this._txtName.TabIndex = 1;
            this._txtName.Tag = "";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(7, 13);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(64, 20);
            this._Label3.TabIndex = 23;
            this._Label3.Text = "Name";
            // 
            // _txtAddress1
            // 
            this._txtAddress1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress1.Location = new System.Drawing.Point(105, 37);
            this._txtAddress1.MaxLength = 255;
            this._txtAddress1.Name = "_txtAddress1";
            this._txtAddress1.ReadOnly = true;
            this._txtAddress1.Size = new System.Drawing.Size(511, 21);
            this._txtAddress1.TabIndex = 2;
            this._txtAddress1.Tag = "Site.Address1";
            // 
            // _lblAddress1
            // 
            this._lblAddress1.Location = new System.Drawing.Point(7, 37);
            this._lblAddress1.Name = "_lblAddress1";
            this._lblAddress1.Size = new System.Drawing.Size(67, 20);
            this._lblAddress1.TabIndex = 26;
            this._lblAddress1.Text = "Address 1";
            // 
            // _txtAddress2
            // 
            this._txtAddress2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress2.Location = new System.Drawing.Point(105, 61);
            this._txtAddress2.MaxLength = 255;
            this._txtAddress2.Name = "_txtAddress2";
            this._txtAddress2.ReadOnly = true;
            this._txtAddress2.Size = new System.Drawing.Size(511, 21);
            this._txtAddress2.TabIndex = 3;
            this._txtAddress2.Tag = "Site.Address2";
            // 
            // _lblAddress2
            // 
            this._lblAddress2.Location = new System.Drawing.Point(7, 61);
            this._lblAddress2.Name = "_lblAddress2";
            this._lblAddress2.Size = new System.Drawing.Size(72, 20);
            this._lblAddress2.TabIndex = 28;
            this._lblAddress2.Text = "Address 2";
            // 
            // _txtAddress3
            // 
            this._txtAddress3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress3.Location = new System.Drawing.Point(105, 85);
            this._txtAddress3.MaxLength = 255;
            this._txtAddress3.Name = "_txtAddress3";
            this._txtAddress3.ReadOnly = true;
            this._txtAddress3.Size = new System.Drawing.Size(511, 21);
            this._txtAddress3.TabIndex = 4;
            this._txtAddress3.Tag = "Site.Address3";
            // 
            // _lblAddress3
            // 
            this._lblAddress3.Location = new System.Drawing.Point(7, 85);
            this._lblAddress3.Name = "_lblAddress3";
            this._lblAddress3.Size = new System.Drawing.Size(64, 20);
            this._lblAddress3.TabIndex = 32;
            this._lblAddress3.Text = "Address 3";
            // 
            // _txtAddress4
            // 
            this._txtAddress4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress4.Location = new System.Drawing.Point(105, 109);
            this._txtAddress4.MaxLength = 100;
            this._txtAddress4.Name = "_txtAddress4";
            this._txtAddress4.ReadOnly = true;
            this._txtAddress4.Size = new System.Drawing.Size(511, 21);
            this._txtAddress4.TabIndex = 5;
            this._txtAddress4.Tag = "Site.Town";
            // 
            // _lblTown
            // 
            this._lblTown.Location = new System.Drawing.Point(7, 109);
            this._lblTown.Name = "_lblTown";
            this._lblTown.Size = new System.Drawing.Size(67, 20);
            this._lblTown.TabIndex = 35;
            this._lblTown.Text = "Address 4";
            // 
            // _txtAddress5
            // 
            this._txtAddress5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress5.Location = new System.Drawing.Point(105, 133);
            this._txtAddress5.MaxLength = 100;
            this._txtAddress5.Name = "_txtAddress5";
            this._txtAddress5.ReadOnly = true;
            this._txtAddress5.Size = new System.Drawing.Size(511, 21);
            this._txtAddress5.TabIndex = 6;
            this._txtAddress5.Tag = "Site.County";
            // 
            // _lblCounty
            // 
            this._lblCounty.Location = new System.Drawing.Point(7, 133);
            this._lblCounty.Name = "_lblCounty";
            this._lblCounty.Size = new System.Drawing.Size(64, 20);
            this._lblCounty.TabIndex = 37;
            this._lblCounty.Text = "Address 5";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPostcode.Location = new System.Drawing.Point(105, 157);
            this._txtPostcode.MaxLength = 10;
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.ReadOnly = true;
            this._txtPostcode.Size = new System.Drawing.Size(511, 21);
            this._txtPostcode.TabIndex = 7;
            this._txtPostcode.Tag = "Site.Postcode";
            // 
            // _lblPostcode
            // 
            this._lblPostcode.Location = new System.Drawing.Point(7, 157);
            this._lblPostcode.Name = "_lblPostcode";
            this._lblPostcode.Size = new System.Drawing.Size(67, 20);
            this._lblPostcode.TabIndex = 40;
            this._lblPostcode.Text = "Postcode";
            // 
            // _txtTelephoneNum
            // 
            this._txtTelephoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTelephoneNum.Location = new System.Drawing.Point(105, 181);
            this._txtTelephoneNum.MaxLength = 50;
            this._txtTelephoneNum.Name = "_txtTelephoneNum";
            this._txtTelephoneNum.ReadOnly = true;
            this._txtTelephoneNum.Size = new System.Drawing.Size(511, 21);
            this._txtTelephoneNum.TabIndex = 8;
            this._txtTelephoneNum.Tag = "Site.TelephoneNum";
            // 
            // _lblTelephoneNum
            // 
            this._lblTelephoneNum.Location = new System.Drawing.Point(7, 181);
            this._lblTelephoneNum.Name = "_lblTelephoneNum";
            this._lblTelephoneNum.Size = new System.Drawing.Size(107, 20);
            this._lblTelephoneNum.TabIndex = 41;
            this._lblTelephoneNum.Text = "Tel";
            // 
            // _txtFaxNum
            // 
            this._txtFaxNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFaxNum.Location = new System.Drawing.Point(105, 205);
            this._txtFaxNum.MaxLength = 50;
            this._txtFaxNum.Name = "_txtFaxNum";
            this._txtFaxNum.ReadOnly = true;
            this._txtFaxNum.Size = new System.Drawing.Size(511, 21);
            this._txtFaxNum.TabIndex = 9;
            this._txtFaxNum.Tag = "Site.FaxNum";
            // 
            // _lblFaxNum
            // 
            this._lblFaxNum.Location = new System.Drawing.Point(7, 205);
            this._lblFaxNum.Name = "_lblFaxNum";
            this._lblFaxNum.Size = new System.Drawing.Size(72, 20);
            this._lblFaxNum.TabIndex = 42;
            this._lblFaxNum.Text = "Fax";
            // 
            // _txtEmailAddress
            // 
            this._txtEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEmailAddress.Location = new System.Drawing.Point(105, 231);
            this._txtEmailAddress.MaxLength = 100;
            this._txtEmailAddress.Name = "_txtEmailAddress";
            this._txtEmailAddress.ReadOnly = true;
            this._txtEmailAddress.Size = new System.Drawing.Size(430, 21);
            this._txtEmailAddress.TabIndex = 10;
            this._txtEmailAddress.Tag = "Site.EmailAddress";
            // 
            // _lblEmailAddress
            // 
            this._lblEmailAddress.Location = new System.Drawing.Point(7, 229);
            this._lblEmailAddress.Name = "_lblEmailAddress";
            this._lblEmailAddress.Size = new System.Drawing.Size(99, 20);
            this._lblEmailAddress.TabIndex = 43;
            this._lblEmailAddress.Text = "Email Address";
            // 
            // FRMSitePopup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(628, 322);
            this.Controls.Add(this._btnSendEmailToSite);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this._Label3);
            this.Controls.Add(this._txtAddress1);
            this.Controls.Add(this._lblAddress1);
            this.Controls.Add(this._txtAddress2);
            this.Controls.Add(this._lblAddress2);
            this.Controls.Add(this._txtAddress3);
            this.Controls.Add(this._lblAddress3);
            this.Controls.Add(this._txtAddress4);
            this.Controls.Add(this._lblTown);
            this.Controls.Add(this._txtAddress5);
            this.Controls.Add(this._lblCounty);
            this.Controls.Add(this._txtPostcode);
            this.Controls.Add(this._lblPostcode);
            this.Controls.Add(this._txtTelephoneNum);
            this.Controls.Add(this._lblTelephoneNum);
            this.Controls.Add(this._txtFaxNum);
            this.Controls.Add(this._lblFaxNum);
            this.Controls.Add(this._txtEmailAddress);
            this.Controls.Add(this._lblEmailAddress);
            this.Controls.Add(this._btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(636, 361);
            this.Name = "FRMSitePopup";
            this.Text = "Property : ID {0}";
            this.ResumeLayout(false);
            this.PerformLayout();

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