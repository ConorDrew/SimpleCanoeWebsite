using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class UCInvoiceAddress : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCInvoiceAddress() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCInvoiceAddress_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        private GroupBox _grpInvoiceAddress;

        internal GroupBox grpInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpInvoiceAddress != null)
                {
                }

                _grpInvoiceAddress = value;
                if (_grpInvoiceAddress != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpInvoiceAddress = new GroupBox();
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
            _grpInvoiceAddress.SuspendLayout();
            SuspendLayout();
            // 
            // grpInvoiceAddress
            // 
            _grpInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpInvoiceAddress.Controls.Add(_txtAddress1);
            _grpInvoiceAddress.Controls.Add(_lblAddress1);
            _grpInvoiceAddress.Controls.Add(_txtAddress2);
            _grpInvoiceAddress.Controls.Add(_lblAddress2);
            _grpInvoiceAddress.Controls.Add(_txtAddress3);
            _grpInvoiceAddress.Controls.Add(_lblAddress3);
            _grpInvoiceAddress.Controls.Add(_txtAddress4);
            _grpInvoiceAddress.Controls.Add(_lblTown);
            _grpInvoiceAddress.Controls.Add(_txtAddress5);
            _grpInvoiceAddress.Controls.Add(_lblCounty);
            _grpInvoiceAddress.Controls.Add(_txtPostcode);
            _grpInvoiceAddress.Controls.Add(_lblPostcode);
            _grpInvoiceAddress.Controls.Add(_txtTelephoneNum);
            _grpInvoiceAddress.Controls.Add(_lblTelephoneNum);
            _grpInvoiceAddress.Controls.Add(_txtFaxNum);
            _grpInvoiceAddress.Controls.Add(_lblFaxNum);
            _grpInvoiceAddress.Controls.Add(_txtEmailAddress);
            _grpInvoiceAddress.Controls.Add(_lblEmailAddress);
            _grpInvoiceAddress.Location = new Point(8, 8);
            _grpInvoiceAddress.Name = "grpInvoiceAddress";
            _grpInvoiceAddress.Size = new Size(625, 313);
            _grpInvoiceAddress.TabIndex = 1;
            _grpInvoiceAddress.TabStop = false;
            _grpInvoiceAddress.Text = "Main Details";
            // 
            // txtAddress1
            // 
            _txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress1.Location = new Point(141, 24);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(474, 21);
            _txtAddress1.TabIndex = 2;
            _txtAddress1.Tag = "InvoiceAddress.Address1";
            _txtAddress1.Text = "";
            // 
            // lblAddress1
            // 
            _lblAddress1.Location = new Point(14, 24);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(73, 20);
            _lblAddress1.TabIndex = 31;
            _lblAddress1.Text = "Address 1";
            // 
            // txtAddress2
            // 
            _txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress2.Location = new Point(141, 56);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(474, 21);
            _txtAddress2.TabIndex = 3;
            _txtAddress2.Tag = "InvoiceAddress.Address2";
            _txtAddress2.Text = "";
            // 
            // lblAddress2
            // 
            _lblAddress2.Location = new Point(14, 56);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(71, 20);
            _lblAddress2.TabIndex = 31;
            _lblAddress2.Text = "Address 2";
            // 
            // txtAddress3
            // 
            _txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress3.Location = new Point(141, 88);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(473, 21);
            _txtAddress3.TabIndex = 4;
            _txtAddress3.Tag = "InvoiceAddress.Address3";
            _txtAddress3.Text = "";
            // 
            // lblAddress3
            // 
            _lblAddress3.Location = new Point(14, 88);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(73, 20);
            _lblAddress3.TabIndex = 31;
            _lblAddress3.Text = "Address 3";
            // 
            // txtAddress4
            // 
            _txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress4.Location = new Point(141, 120);
            _txtAddress4.MaxLength = 255;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.Size = new Size(472, 21);
            _txtAddress4.TabIndex = 5;
            _txtAddress4.Tag = "InvoiceAddress.Town";
            _txtAddress4.Text = "";
            // 
            // lblTown
            // 
            _lblTown.Location = new Point(14, 120);
            _lblTown.Name = "lblTown";
            _lblTown.Size = new Size(64, 20);
            _lblTown.TabIndex = 31;
            _lblTown.Text = "Address 4";
            // 
            // txtAddress5
            // 
            _txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress5.Location = new Point(141, 152);
            _txtAddress5.MaxLength = 255;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.Size = new Size(473, 21);
            _txtAddress5.TabIndex = 6;
            _txtAddress5.Tag = "InvoiceAddress.County";
            _txtAddress5.Text = "";
            // 
            // lblCounty
            // 
            _lblCounty.Location = new Point(14, 152);
            _lblCounty.Name = "lblCounty";
            _lblCounty.Size = new Size(61, 20);
            _lblCounty.TabIndex = 31;
            _lblCounty.Text = "Address 5";
            // 
            // txtPostcode
            // 
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Location = new Point(141, 184);
            _txtPostcode.MaxLength = 255;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(473, 21);
            _txtPostcode.TabIndex = 7;
            _txtPostcode.Tag = "InvoiceAddress.Postcode";
            _txtPostcode.Text = "";
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(14, 184);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(66, 20);
            _lblPostcode.TabIndex = 31;
            _lblPostcode.Text = "Postcode";
            // 
            // txtTelephoneNum
            // 
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(141, 216);
            _txtTelephoneNum.MaxLength = 255;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(473, 21);
            _txtTelephoneNum.TabIndex = 8;
            _txtTelephoneNum.Tag = "InvoiceAddress.TelephoneNum";
            _txtTelephoneNum.Text = "";
            // 
            // lblTelephoneNum
            // 
            _lblTelephoneNum.Location = new Point(14, 216);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(108, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Telephone";
            // 
            // txtFaxNum
            // 
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(141, 248);
            _txtFaxNum.MaxLength = 255;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(473, 21);
            _txtFaxNum.TabIndex = 9;
            _txtFaxNum.Tag = "InvoiceAddress.FaxNum";
            _txtFaxNum.Text = "";
            // 
            // lblFaxNum
            // 
            _lblFaxNum.Location = new Point(14, 248);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(70, 20);
            _lblFaxNum.TabIndex = 31;
            _lblFaxNum.Text = "Fax";
            // 
            // txtEmailAddress
            // 
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(141, 280);
            _txtEmailAddress.MaxLength = 255;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(473, 21);
            _txtEmailAddress.TabIndex = 10;
            _txtEmailAddress.Tag = "InvoiceAddress.EmailAddress";
            _txtEmailAddress.Text = "";
            // 
            // lblEmailAddress
            // 
            _lblEmailAddress.Location = new Point(14, 280);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(97, 20);
            _lblEmailAddress.TabIndex = 31;
            _lblEmailAddress.Text = "Email Address";
            // 
            // UCInvoiceAddress
            // 
            Controls.Add(_grpInvoiceAddress);
            Name = "UCInvoiceAddress";
            Size = new Size(640, 329);
            _grpInvoiceAddress.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentInvoiceAddress;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.InvoiceAddresss.InvoiceAddress _currentInvoiceAddress;

        public Entity.InvoiceAddresss.InvoiceAddress CurrentInvoiceAddress
        {
            get
            {
                return _currentInvoiceAddress;
            }

            set
            {
                _currentInvoiceAddress = value;
                if (CurrentInvoiceAddress is null)
                {
                    CurrentInvoiceAddress = new Entity.InvoiceAddresss.InvoiceAddress();
                    CurrentInvoiceAddress.Exists = false;
                }

                if (CurrentInvoiceAddress.Exists)
                {
                    Populate();
                }
            }
        }

        private void UCInvoiceAddress_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentInvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(ID);
            }

            txtAddress1.Text = CurrentInvoiceAddress.Address1;
            txtAddress2.Text = CurrentInvoiceAddress.Address2;
            txtAddress3.Text = CurrentInvoiceAddress.Address3;
            txtAddress4.Text = CurrentInvoiceAddress.Address4;
            txtAddress5.Text = CurrentInvoiceAddress.Address5;
            txtPostcode.Text = CurrentInvoiceAddress.Postcode;
            txtTelephoneNum.Text = CurrentInvoiceAddress.TelephoneNum;
            txtFaxNum.Text = CurrentInvoiceAddress.FaxNum;
            txtEmailAddress.Text = CurrentInvoiceAddress.EmailAddress;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentInvoiceAddress.IgnoreExceptionsOnSetMethods = true;
                CurrentInvoiceAddress.SetAddress1 = txtAddress1.Text.Trim();
                CurrentInvoiceAddress.SetAddress2 = txtAddress2.Text.Trim();
                CurrentInvoiceAddress.SetAddress3 = txtAddress3.Text.Trim();
                CurrentInvoiceAddress.SetAddress4 = txtAddress4.Text.Trim();
                CurrentInvoiceAddress.SetAddress5 = txtAddress5.Text.Trim();
                CurrentInvoiceAddress.SetPostcode = txtPostcode.Text.Trim();
                CurrentInvoiceAddress.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentInvoiceAddress.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentInvoiceAddress.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentInvoiceAddress.SetSiteID = SiteID;
                var cV = new Entity.InvoiceAddresss.InvoiceAddressValidator();
                cV.Validate(CurrentInvoiceAddress);
                if (CurrentInvoiceAddress.Exists)
                {
                    App.DB.InvoiceAddress.Update(CurrentInvoiceAddress);
                }
                else
                {
                    CurrentInvoiceAddress = App.DB.InvoiceAddress.Insert(CurrentInvoiceAddress);
                }

                StateChanged?.Invoke(CurrentInvoiceAddress.InvoiceAddressID);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}