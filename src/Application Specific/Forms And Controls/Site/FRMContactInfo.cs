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

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

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

        internal GroupBox grpSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSite != null)
                {
                }

                _grpSite = value;
                if (_grpSite != null)
                {
                }
            }
        }

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
            _btnOK = new Button();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _txtHeadOffice = new TextBox();
            _Label9 = new Label();
            _txtCustomerName = new TextBox();
            _Label2 = new Label();
            _txtSiteName = new TextBox();
            _Label1 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _grpSite = new GroupBox();
            SuspendLayout();
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(595, 236);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 4;
            _btnOK.Text = "OK";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Location = new Point(125, 152);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(132, 21);
            _txtTelephoneNum.TabIndex = 101;
            _txtTelephoneNum.Tag = "Site.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(24, 155);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(48, 20);
            _lblTelephoneNum.TabIndex = 107;
            _lblTelephoneNum.Text = "Tel";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Location = new Point(125, 182);
            _txtEmailAddress.MaxLength = 100;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(223, 21);
            _txtEmailAddress.TabIndex = 103;
            _txtEmailAddress.Tag = "Site.EmailAddress";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(24, 185);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(98, 20);
            _lblEmailAddress.TabIndex = 106;
            _lblEmailAddress.Text = "Email Address";
            //
            // txtFaxNum
            //
            _txtFaxNum.Location = new Point(362, 154);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(145, 21);
            _txtFaxNum.TabIndex = 102;
            _txtFaxNum.Tag = "Site.FaxNum";
            //
            // lblFaxNum
            //
            _lblFaxNum.Location = new Point(288, 155);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(50, 20);
            _lblFaxNum.TabIndex = 104;
            _lblFaxNum.Text = "Mobile";
            //
            // txtHeadOffice
            //
            _txtHeadOffice.Location = new Point(125, 91);
            _txtHeadOffice.Name = "txtHeadOffice";
            _txtHeadOffice.ReadOnly = true;
            _txtHeadOffice.Size = new Size(382, 21);
            _txtHeadOffice.TabIndex = 109;
            //
            // Label9
            //
            _Label9.Location = new Point(24, 89);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(80, 23);
            _Label9.TabIndex = 113;
            _Label9.Text = "Head Office:";
            //
            // txtCustomerName
            //
            _txtCustomerName.Location = new Point(125, 62);
            _txtCustomerName.Name = "txtCustomerName";
            _txtCustomerName.ReadOnly = true;
            _txtCustomerName.Size = new Size(382, 21);
            _txtCustomerName.TabIndex = 108;
            //
            // Label2
            //
            _Label2.Location = new Point(24, 122);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(80, 23);
            _Label2.TabIndex = 112;
            _Label2.Text = "Property:";
            //
            // txtSiteName
            //
            _txtSiteName.Location = new Point(125, 120);
            _txtSiteName.Name = "txtSiteName";
            _txtSiteName.ReadOnly = true;
            _txtSiteName.Size = new Size(382, 21);
            _txtSiteName.TabIndex = 110;
            //
            // Label1
            //
            _Label1.Location = new Point(24, 62);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(80, 23);
            _Label1.TabIndex = 111;
            _Label1.Text = "Customer:";
            //
            // btnSave
            //
            _btnSave.Location = new Point(426, 243);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(109, 30);
            _btnSave.TabIndex = 105;
            _btnSave.Text = "Save";
            //
            // grpSite
            //
            _grpSite.Location = new Point(6, 38);
            _grpSite.Name = "grpSite";
            _grpSite.Size = new Size(529, 188);
            _grpSite.TabIndex = 114;
            _grpSite.TabStop = false;
            _grpSite.Text = "Site ";
            //
            // FRMContactInfo
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(547, 288);
            Controls.Add(_txtHeadOffice);
            Controls.Add(_Label9);
            Controls.Add(_txtCustomerName);
            Controls.Add(_Label2);
            Controls.Add(_txtSiteName);
            Controls.Add(_Label1);
            Controls.Add(_txtTelephoneNum);
            Controls.Add(_lblTelephoneNum);
            Controls.Add(_txtEmailAddress);
            Controls.Add(_lblEmailAddress);
            Controls.Add(_btnSave);
            Controls.Add(_txtFaxNum);
            Controls.Add(_lblFaxNum);
            Controls.Add(_btnOK);
            Controls.Add(_grpSite);
            MinimumSize = new Size(1, 1);
            Name = "FRMContactInfo";
            Text = "Site Contact Information";
            Controls.SetChildIndex(_grpSite, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_lblFaxNum, 0);
            Controls.SetChildIndex(_txtFaxNum, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_lblEmailAddress, 0);
            Controls.SetChildIndex(_txtEmailAddress, 0);
            Controls.SetChildIndex(_lblTelephoneNum, 0);
            Controls.SetChildIndex(_txtTelephoneNum, 0);
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_txtSiteName, 0);
            Controls.SetChildIndex(_Label2, 0);
            Controls.SetChildIndex(_txtCustomerName, 0);
            Controls.SetChildIndex(_Label9, 0);
            Controls.SetChildIndex(_txtHeadOffice, 0);
            ResumeLayout(false);
            PerformLayout();
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