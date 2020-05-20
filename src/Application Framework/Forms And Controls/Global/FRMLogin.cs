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
        public FRMLogin() : base()
        {
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

        private Label _Label2;

        private Label _Label3;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMLogin));
            this._grpLoginDetails = new System.Windows.Forms.GroupBox();
            this._btnLogin = new System.Windows.Forms.Button();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtUserName = new System.Windows.Forms.TextBox();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._grpLoginDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpLoginDetails
            // 
            this._grpLoginDetails.Controls.Add(this._btnLogin);
            this._grpLoginDetails.Controls.Add(this._Label2);
            this._grpLoginDetails.Controls.Add(this._Label3);
            this._grpLoginDetails.Controls.Add(this._txtUserName);
            this._grpLoginDetails.Controls.Add(this._txtPassword);
            this._grpLoginDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpLoginDetails.Location = new System.Drawing.Point(8, 12);
            this._grpLoginDetails.Name = "_grpLoginDetails";
            this._grpLoginDetails.Size = new System.Drawing.Size(392, 129);
            this._grpLoginDetails.TabIndex = 12;
            this._grpLoginDetails.TabStop = false;
            this._grpLoginDetails.Text = "Enter Login Details";
            // 
            // _btnLogin
            // 
            this._btnLogin.AccessibleDescription = "Login to application";
            this._btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnLogin.Location = new System.Drawing.Point(168, 95);
            this._btnLogin.Name = "_btnLogin";
            this._btnLogin.Size = new System.Drawing.Size(56, 23);
            this._btnLogin.TabIndex = 3;
            this._btnLogin.Text = "Login";
            this._btnLogin.UseVisualStyleBackColor = true;
            this._btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // _Label2
            // 
            this._Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label2.Location = new System.Drawing.Point(16, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(80, 16);
            this._Label2.TabIndex = 1;
            this._Label2.Text = "Username";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(16, 64);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(80, 23);
            this._Label3.TabIndex = 2;
            this._Label3.Text = "Password";
            // 
            // _txtUserName
            // 
            this._txtUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtUserName.Location = new System.Drawing.Point(96, 22);
            this._txtUserName.MaxLength = 50;
            this._txtUserName.Name = "_txtUserName";
            this._txtUserName.Size = new System.Drawing.Size(288, 21);
            this._txtUserName.TabIndex = 1;
            // 
            // _txtPassword
            // 
            this._txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPassword.Location = new System.Drawing.Point(96, 62);
            this._txtPassword.MaxLength = 50;
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '*';
            this._txtPassword.Size = new System.Drawing.Size(288, 21);
            this._txtPassword.TabIndex = 2;
            // 
            // FRMLogin
            // 
            this.AcceptButton = this._btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(400, 144);
            this.Controls.Add(this._grpLoginDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 183);
            this.Name = "FRMLogin";
            this._grpLoginDetails.ResumeLayout(false);
            this._grpLoginDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);

#if Debug
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
#endif
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
                            App.Login();
                        }
                        else
                        {
                            App.ShowMessage("New password needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
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
    }
}