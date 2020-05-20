using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class FRMContactInfo : FRMBaseForm, IForm
    {
        public FRMContactInfo()
        {
            base.Load += FRMContactInfo_Load;
            base.FormClosing += FRMContactInfo_FormClosing;
        }

        public FRMContactInfo(Entity.Sites.Site oSite) : base()
        {
            base.Load += FRMContactInfo_Load;
            base.FormClosing += FRMContactInfo_FormClosing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            CurrentSite = oSite;

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

        private TextBox _txtHeadOffice;

        internal TextBox txtHeadOffice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHeadOffice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHeadOffice != null)
                {
                }

                _txtHeadOffice = value;
                if (_txtHeadOffice != null)
                {
                }
            }
        }

        private Label _Label9;

        private TextBox _txtCustomerName;

        internal TextBox txtCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomerName != null)
                {
                }

                _txtCustomerName = value;
                if (_txtCustomerName != null)
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

        private TextBox _txtSiteName;

        internal TextBox txtSiteName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteName != null)
                {
                }

                _txtSiteName = value;
                if (_txtSiteName != null)
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

        private GroupBox _grpSite;

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnOK = new System.Windows.Forms.Button();
            this._txtTelephoneNum = new System.Windows.Forms.TextBox();
            this._lblTelephoneNum = new System.Windows.Forms.Label();
            this._txtEmailAddress = new System.Windows.Forms.TextBox();
            this._lblEmailAddress = new System.Windows.Forms.Label();
            this._txtFaxNum = new System.Windows.Forms.TextBox();
            this._lblFaxNum = new System.Windows.Forms.Label();
            this._txtHeadOffice = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._txtCustomerName = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._txtSiteName = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._grpSite = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(595, 210);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            // 
            // _txtTelephoneNum
            // 
            this._txtTelephoneNum.Location = new System.Drawing.Point(125, 126);
            this._txtTelephoneNum.MaxLength = 50;
            this._txtTelephoneNum.Name = "_txtTelephoneNum";
            this._txtTelephoneNum.Size = new System.Drawing.Size(132, 21);
            this._txtTelephoneNum.TabIndex = 101;
            this._txtTelephoneNum.Tag = "Site.TelephoneNum";
            // 
            // _lblTelephoneNum
            // 
            this._lblTelephoneNum.Location = new System.Drawing.Point(24, 129);
            this._lblTelephoneNum.Name = "_lblTelephoneNum";
            this._lblTelephoneNum.Size = new System.Drawing.Size(48, 20);
            this._lblTelephoneNum.TabIndex = 107;
            this._lblTelephoneNum.Text = "Tel";
            // 
            // _txtEmailAddress
            // 
            this._txtEmailAddress.Location = new System.Drawing.Point(125, 156);
            this._txtEmailAddress.MaxLength = 100;
            this._txtEmailAddress.Name = "_txtEmailAddress";
            this._txtEmailAddress.Size = new System.Drawing.Size(223, 21);
            this._txtEmailAddress.TabIndex = 103;
            this._txtEmailAddress.Tag = "Site.EmailAddress";
            // 
            // _lblEmailAddress
            // 
            this._lblEmailAddress.Location = new System.Drawing.Point(24, 159);
            this._lblEmailAddress.Name = "_lblEmailAddress";
            this._lblEmailAddress.Size = new System.Drawing.Size(98, 20);
            this._lblEmailAddress.TabIndex = 106;
            this._lblEmailAddress.Text = "Email Address";
            // 
            // _txtFaxNum
            // 
            this._txtFaxNum.Location = new System.Drawing.Point(362, 128);
            this._txtFaxNum.MaxLength = 50;
            this._txtFaxNum.Name = "_txtFaxNum";
            this._txtFaxNum.Size = new System.Drawing.Size(145, 21);
            this._txtFaxNum.TabIndex = 102;
            this._txtFaxNum.Tag = "Site.FaxNum";
            // 
            // _lblFaxNum
            // 
            this._lblFaxNum.Location = new System.Drawing.Point(288, 129);
            this._lblFaxNum.Name = "_lblFaxNum";
            this._lblFaxNum.Size = new System.Drawing.Size(50, 20);
            this._lblFaxNum.TabIndex = 104;
            this._lblFaxNum.Text = "Mobile";
            // 
            // _txtHeadOffice
            // 
            this._txtHeadOffice.Location = new System.Drawing.Point(125, 65);
            this._txtHeadOffice.Name = "_txtHeadOffice";
            this._txtHeadOffice.ReadOnly = true;
            this._txtHeadOffice.Size = new System.Drawing.Size(382, 21);
            this._txtHeadOffice.TabIndex = 109;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(24, 63);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(80, 23);
            this._Label9.TabIndex = 113;
            this._Label9.Text = "Head Office:";
            // 
            // _txtCustomerName
            // 
            this._txtCustomerName.Location = new System.Drawing.Point(125, 36);
            this._txtCustomerName.Name = "_txtCustomerName";
            this._txtCustomerName.ReadOnly = true;
            this._txtCustomerName.Size = new System.Drawing.Size(382, 21);
            this._txtCustomerName.TabIndex = 108;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(24, 96);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(80, 23);
            this._Label2.TabIndex = 112;
            this._Label2.Text = "Property:";
            // 
            // _txtSiteName
            // 
            this._txtSiteName.Location = new System.Drawing.Point(125, 94);
            this._txtSiteName.Name = "_txtSiteName";
            this._txtSiteName.ReadOnly = true;
            this._txtSiteName.Size = new System.Drawing.Size(382, 21);
            this._txtSiteName.TabIndex = 110;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(24, 36);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(80, 23);
            this._Label1.TabIndex = 111;
            this._Label1.Text = "Customer:";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(426, 217);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(109, 30);
            this._btnSave.TabIndex = 105;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _grpSite
            // 
            this._grpSite.Location = new System.Drawing.Point(6, 12);
            this._grpSite.Name = "_grpSite";
            this._grpSite.Size = new System.Drawing.Size(529, 188);
            this._grpSite.TabIndex = 114;
            this._grpSite.TabStop = false;
            this._grpSite.Text = "Site ";
            // 
            // FRMContactInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(547, 288);
            this.Controls.Add(this._txtHeadOffice);
            this.Controls.Add(this._Label9);
            this.Controls.Add(this._txtCustomerName);
            this.Controls.Add(this._Label2);
            this.Controls.Add(this._txtSiteName);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._txtTelephoneNum);
            this.Controls.Add(this._lblTelephoneNum);
            this.Controls.Add(this._txtEmailAddress);
            this.Controls.Add(this._lblEmailAddress);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtFaxNum);
            this.Controls.Add(this._lblFaxNum);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._grpSite);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "FRMContactInfo";
            this.Text = "Site Contact Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
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
        }

        private Entity.Sites.Site _osite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _osite;
            }

            set
            {
                _osite = value;
                txtSiteName.Text = CurrentSite.Address1 + " " + CurrentSite.Address2 + ", " + CurrentSite.Postcode;
                var CurrentCustomer = new Entity.Customers.Customer();
                CurrentCustomer = App.DB.Customer.Customer_Get_Light(CurrentSite.CustomerID);
                txtCustomerName.Text = CurrentCustomer.Name;
                Entity.Sites.Site currentSiteHQ;
                currentSiteHQ = App.DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
                if (currentSiteHQ is object)
                {
                    txtHeadOffice.Text = currentSiteHQ.Address1 + ", " + currentSiteHQ.Address2;
                }
                else
                {
                    txtHeadOffice.Text = "Not Allocated";
                }

                txtTelephoneNum.Text = CurrentSite.TelephoneNum;
                txtFaxNum.Text = CurrentSite.FaxNum;
                txtEmailAddress.Text = CurrentSite.EmailAddress;
            }
        }

        private void FRMContactInfo_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                var withBlock = CurrentSite;
                withBlock.SetTelephoneNum = txtTelephoneNum.Text;
                withBlock.SetFaxNum = txtFaxNum.Text;
                withBlock.SetEmailAddress = txtEmailAddress.Text;
            }

            App.DB.Sites.Update(CurrentSite);
            DialogResult = DialogResult.Yes;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMContactInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // check user wants to close window
                if (e.CloseReason == CloseReason.FormOwnerClosing || e.CloseReason == CloseReason.UserClosing)
                {
                    if (Interaction.MsgBox("Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Form closing") == MsgBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }
    }
}