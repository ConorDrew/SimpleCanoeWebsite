using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMLogin : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMLogin() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMLogin_Load;
            base.Closing += FRMLogin_Closing;
            base.KeyDown += FRMLogin_KeyDown;

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
        private GroupBox _grpLoginDetails;

        internal GroupBox grpLoginDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpLoginDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpLoginDetails != null)
                {
                }

                _grpLoginDetails = value;
                if (_grpLoginDetails != null)
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

        private TextBox _txtUserName;

        internal TextBox txtUserName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtUserName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtUserName != null)
                {
                }

                _txtUserName = value;
                if (_txtUserName != null)
                {
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

        private Button _btnLogin;

        internal Button btnLogin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnLogin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnLogin != null)
                {
                    _btnLogin.Click -= btnLogin_Click;
                }

                _btnLogin = value;
                if (_btnLogin != null)
                {
                    _btnLogin.Click += btnLogin_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMLogin));
            _grpLoginDetails = new GroupBox();
            _btnLogin = new Button();
            _btnLogin.Click += new EventHandler(btnLogin_Click);
            _Label2 = new Label();
            _Label3 = new Label();
            _txtUserName = new TextBox();
            _txtPassword = new TextBox();
            _grpLoginDetails.SuspendLayout();
            SuspendLayout();
            //
            // grpLoginDetails
            //
            _grpLoginDetails.Controls.Add(_btnLogin);
            _grpLoginDetails.Controls.Add(_Label2);
            _grpLoginDetails.Controls.Add(_Label3);
            _grpLoginDetails.Controls.Add(_txtUserName);
            _grpLoginDetails.Controls.Add(_txtPassword);
            _grpLoginDetails.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpLoginDetails.Location = new Point(8, 40);
            _grpLoginDetails.Name = "grpLoginDetails";
            _grpLoginDetails.Size = new Size(392, 128);
            _grpLoginDetails.TabIndex = 12;
            _grpLoginDetails.TabStop = false;
            _grpLoginDetails.Text = "Enter Login Details";
            //
            // btnLogin
            //
            _btnLogin.AccessibleDescription = "Login to application";
            _btnLogin.Cursor = Cursors.Hand;
            _btnLogin.Location = new Point(96, 96);
            _btnLogin.Name = "btnLogin";
            _btnLogin.Size = new Size(56, 23);
            _btnLogin.TabIndex = 3;
            _btnLogin.Text = "Login";
            _btnLogin.UseVisualStyleBackColor = true;
            //
            // Label2
            //
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(16, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(80, 16);
            _Label2.TabIndex = 1;
            _Label2.Text = "Username";
            //
            // Label3
            //
            _Label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(16, 64);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(80, 23);
            _Label3.TabIndex = 2;
            _Label3.Text = "Password";
            //
            // txtUserName
            //
            _txtUserName.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtUserName.Location = new Point(96, 22);
            _txtUserName.MaxLength = 50;
            _txtUserName.Name = "txtUserName";
            _txtUserName.Size = new Size(288, 21);
            _txtUserName.TabIndex = 1;
            //
            // txtPassword
            //
            _txtPassword.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPassword.Location = new Point(96, 62);
            _txtPassword.MaxLength = 50;
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(288, 21);
            _txtPassword.TabIndex = 2;
            //
            // FRMLogin
            //
            AcceptButton = _btnLogin;
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(400, 169);
            Controls.Add(_grpLoginDetails);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(416, 208);
            MinimizeBox = false;
            MinimumSize = new Size(416, 208);
            Name = "FRMLogin";
            Controls.SetChildIndex(_grpLoginDetails, 0);
            _grpLoginDetails.ResumeLayout(false);
            _grpLoginDetails.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);

            /* TODO ERROR: Skipped IfDirectiveTrivia */
            txtUserName.Text = "admin";
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        txtPassword.Text = "Gabriel_!";
                        break;
                    }

                case object _ when App.IsRFT:
                    {
                        txtPassword.Text = "RftAdm!n57";
                        break;
                    }

                case object _ when App.IsBlueflame:
                    {
                        txtPassword.Text = "Blu3Adm!n57";
                        break;
                    }
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
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

        private void FRMLogin_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void FRMLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            App.CloseApplication();
        }

        private void FRMLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    App.CloseApplication();
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Action cannot be completed : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogMeIn();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void LogMeIn()
        {
            if (txtUserName.Text.Trim().Length == 0 | txtPassword.Text.Trim().Length == 0)
            {
                App.ShowMessage("Missing Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (!App.DB.User.Authenticate(txtUserName.Text, txtPassword.Text))
                    {
                        App.DB.User.IsUserActive(txtUserName.Text, 0, true);
                        if (!string.IsNullOrEmpty(App.loggedInUser?.Password))
                        {
                            App.loggedInUser = null;
                        }
                    }

                    txtPassword.Text = "";
                    ActiveControl = txtUserName;
                    txtUserName.Focus();
                    if (App.loggedInUser is null)
                    {
                        App.ShowMessage("Invalid login details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (App.loggedInUser.UpdateAtLogon | App.loggedInUser.PasswordExpiryDate < DateAndTime.Now.AddDays(-1))
                    {
                        var frm = new FRMChangePassword();
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.Yes)
                        {
                            VersionChecker.Unlock();
                            App.Login();
                        }
                        else
                        {
                            App.ShowMessage("New password needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        VersionChecker.Unlock();
                        App.Login();
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Application cannot load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}