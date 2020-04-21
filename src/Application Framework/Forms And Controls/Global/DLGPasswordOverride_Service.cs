using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGPasswordOverride_Service : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DLGPasswordOverride_Service() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += DLGPasswordOverride_Load;

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

        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
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

        private TextBox _txtPassword;

        internal TextBox txtPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPassword != null)
                {
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                }
            }
        }

        private Button _btnOk;

        internal Button btnOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOk != null)
                {
                    _btnOk.Click -= btnOk_Click;
                }

                _btnOk = value;
                if (_btnOk != null)
                {
                    _btnOk.Click += btnOk_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _txtPassword = new TextBox();
            _btnOk = new Button();
            _btnOk.Click += new EventHandler(btnOk_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Controls.Add(_btnCancel);
            _GroupBox1.Controls.Add(_txtPassword);
            _GroupBox1.Controls.Add(_btnOk);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(304, 64);
            _GroupBox1.TabIndex = 4;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Please enter override password to continue";
            //
            // btnCancel
            //
            _btnCancel.AccessibleDescription = "Cancel entry";
            _btnCancel.Cursor = Cursors.Hand;
            _btnCancel.DialogResult = DialogResult.Cancel;
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Location = new Point(248, 24);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(48, 23);
            _btnCancel.TabIndex = 3;
            _btnCancel.Text = "Cancel";
            //
            // txtPassword
            //
            _txtPassword.Location = new Point(8, 24);
            _txtPassword.MaxLength = 50;
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(176, 21);
            _txtPassword.TabIndex = 1;
            _txtPassword.Text = "";
            //
            // btnOk
            //
            _btnOk.AccessibleDescription = "Try password";
            _btnOk.Cursor = Cursors.Hand;
            _btnOk.UseVisualStyleBackColor = true;
            _btnOk.Location = new Point(192, 24);
            _btnOk.Name = "btnOk";
            _btnOk.Size = new Size(48, 23);
            _btnOk.TabIndex = 2;
            _btnOk.Text = "OK";
            //
            // DLGPasswordOverride
            //
            AcceptButton = _btnOk;
            AutoScaleBaseSize = new Size(6, 14);
            CancelButton = _btnCancel;
            ClientSize = new Size(320, 110);
            Controls.Add(_GroupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(328, 144);
            MinimizeBox = false;
            MinimumSize = new Size(328, 144);
            Name = "DLGPasswordOverride";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        private void DLGPasswordOverride_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword_Service ?? ""))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}