using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEnterEmailAddress : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMEnterEmailAddress() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMEnterEmailAddress_Load;

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

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private TextBox _txtAddress;

        internal TextBox txtAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress != null)
                {
                }

                _txtAddress = value;
                if (_txtAddress != null)
                {
                }
            }
        }

        private Button _btnEmail;

        internal Button btnEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmail != null)
                {
                    _btnEmail.Click -= btnEmail_Click;
                }

                _btnEmail = value;
                if (_btnEmail != null)
                {
                    _btnEmail.Click += btnEmail_Click;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtAddress = new TextBox();
            _btnEmail = new Button();
            _btnEmail.Click += new EventHandler(btnEmail_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _GroupBox1 = new GroupBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtAddress
            // 
            _txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress.Location = new Point(8, 24);
            _txtAddress.Name = "txtAddress";
            _txtAddress.Size = new Size(288, 21);
            _txtAddress.TabIndex = 1;
            _txtAddress.Text = "";
            // 
            // btnEmail
            // 
            _btnEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnEmail.Location = new Point(256, 104);
            _btnEmail.Name = "btnEmail";
            _btnEmail.Size = new Size(56, 23);
            _btnEmail.TabIndex = 2;
            _btnEmail.Text = "Send";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 104);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 3;
            _btnCancel.Text = "Cancel";
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_txtAddress);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(304, 56);
            _GroupBox1.TabIndex = 6;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Email Address";
            // 
            // FRMEnterEmailAddress
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(320, 134);
            Controls.Add(_GroupBox1);
            Controls.Add(_btnCancel);
            Controls.Add(_btnEmail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(326, 166);
            MinimizeBox = false;
            MinimumSize = new Size(326, 166);
            Name = "FRMEnterEmailAddress";
            Text = "Enter Email Address";
            Controls.SetChildIndex(_btnEmail, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Entity.Sys.Emails _email;

        public Entity.Sys.Emails Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            Email = (Entity.Sys.Emails)get_GetParameter(0);
            txtAddress.Text = Email.To;
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        private void FRMEnterEmailAddress_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Email.To = txtAddress.Text;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}