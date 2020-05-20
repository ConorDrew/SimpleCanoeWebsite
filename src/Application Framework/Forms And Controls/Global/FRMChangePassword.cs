using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSM
{
    public class FRMChangePassword : FRMBaseForm, IForm
    {
        public FRMChangePassword() : base()
        {
            base.Load += FRMChangePassword_Load;

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
        private GroupBox _grpNewDetails;

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

        private TextBox _txtNewPassword;

        internal TextBox txtNewPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNewPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNewPassword != null)
                {
                    _txtNewPassword.KeyDown -= TxtNewPassword_KeyDown;
                }

                _txtNewPassword = value;
                if (_txtNewPassword != null)
                {
                    _txtNewPassword.KeyDown += TxtNewPassword_KeyDown;
                }
            }
        }

        private TextBox _txtConfirm;

        internal TextBox txtConfirm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtConfirm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtConfirm != null)
                {
                    _txtConfirm.KeyDown -= TxtConfirm_KeyDown;
                }

                _txtConfirm = value;
                if (_txtConfirm != null)
                {
                    _txtConfirm.KeyDown += TxtConfirm_KeyDown;
                }
            }
        }

        private GroupBox _grpCurrentDetails;

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
                    _txtPassword.KeyDown -= TxtPassword_KeyDown;
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                    _txtPassword.KeyDown += TxtPassword_KeyDown;
                }
            }
        }

        private Label _Label1;

        private Button _btnUpdate;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpNewDetails = new System.Windows.Forms.GroupBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtNewPassword = new System.Windows.Forms.TextBox();
            this._txtConfirm = new System.Windows.Forms.TextBox();
            this._btnUpdate = new System.Windows.Forms.Button();
            this._grpCurrentDetails = new System.Windows.Forms.GroupBox();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._grpNewDetails.SuspendLayout();
            this._grpCurrentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpNewDetails
            // 
            this._grpNewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpNewDetails.Controls.Add(this._Label2);
            this._grpNewDetails.Controls.Add(this._Label3);
            this._grpNewDetails.Controls.Add(this._txtNewPassword);
            this._grpNewDetails.Controls.Add(this._txtConfirm);
            this._grpNewDetails.Controls.Add(this._btnUpdate);
            this._grpNewDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpNewDetails.Location = new System.Drawing.Point(9, 79);
            this._grpNewDetails.Name = "_grpNewDetails";
            this._grpNewDetails.Size = new System.Drawing.Size(391, 128);
            this._grpNewDetails.TabIndex = 36;
            this._grpNewDetails.TabStop = false;
            this._grpNewDetails.Text = "New Details";
            // 
            // _Label2
            // 
            this._Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label2.Location = new System.Drawing.Point(16, 32);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 17;
            this._Label2.Text = "Password ";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(16, 64);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(64, 16);
            this._Label3.TabIndex = 19;
            this._Label3.Text = "Confirm ";
            // 
            // _txtNewPassword
            // 
            this._txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNewPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNewPassword.Location = new System.Drawing.Point(112, 32);
            this._txtNewPassword.MaxLength = 50;
            this._txtNewPassword.Name = "_txtNewPassword";
            this._txtNewPassword.PasswordChar = '*';
            this._txtNewPassword.Size = new System.Drawing.Size(272, 21);
            this._txtNewPassword.TabIndex = 2;
            this._txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNewPassword_KeyDown);
            // 
            // _txtConfirm
            // 
            this._txtConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtConfirm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtConfirm.Location = new System.Drawing.Point(112, 64);
            this._txtConfirm.MaxLength = 50;
            this._txtConfirm.Name = "_txtConfirm";
            this._txtConfirm.PasswordChar = '*';
            this._txtConfirm.Size = new System.Drawing.Size(272, 21);
            this._txtConfirm.TabIndex = 3;
            this._txtConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtConfirm_KeyDown);
            // 
            // _btnUpdate
            // 
            this._btnUpdate.AccessibleDescription = "Update your password";
            this._btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnUpdate.Location = new System.Drawing.Point(327, 96);
            this._btnUpdate.Name = "_btnUpdate";
            this._btnUpdate.Size = new System.Drawing.Size(56, 23);
            this._btnUpdate.TabIndex = 4;
            this._btnUpdate.Text = "Update";
            this._btnUpdate.UseVisualStyleBackColor = true;
            this._btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // _grpCurrentDetails
            // 
            this._grpCurrentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCurrentDetails.Controls.Add(this._txtPassword);
            this._grpCurrentDetails.Controls.Add(this._Label1);
            this._grpCurrentDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpCurrentDetails.Location = new System.Drawing.Point(9, 12);
            this._grpCurrentDetails.Name = "_grpCurrentDetails";
            this._grpCurrentDetails.Size = new System.Drawing.Size(391, 61);
            this._grpCurrentDetails.TabIndex = 35;
            this._grpCurrentDetails.TabStop = false;
            this._grpCurrentDetails.Text = "Current Details";
            // 
            // _txtPassword
            // 
            this._txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPassword.Location = new System.Drawing.Point(112, 24);
            this._txtPassword.MaxLength = 50;
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '*';
            this._txtPassword.Size = new System.Drawing.Size(271, 21);
            this._txtPassword.TabIndex = 1;
            this._txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // _Label1
            // 
            this._Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1.Location = new System.Drawing.Point(16, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 20;
            this._Label1.Text = "Password ";
            // 
            // FRMChangePassword
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(412, 209);
            this.Controls.Add(this._grpNewDetails);
            this.Controls.Add(this._grpCurrentDetails);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(428, 248);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(428, 248);
            this.Name = "FRMChangePassword";
            this.Text = "Your Password";
            this._grpNewDetails.ResumeLayout(false);
            this._grpNewDetails.PerformLayout();
            this._grpCurrentDetails.ResumeLayout(false);
            this._grpCurrentDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ActiveControl = txtPassword;
            txtPassword.Focus();
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

        private bool isLoading = true;

        private void FRMChangePassword_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadMe(sender, e);
            isLoading = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Please correct the following errors : " + Constants.vbCrLf + Constants.vbCrLf;
                int errorCount = 1;
                bool valid = true;
                if (txtPassword.Text.Trim().Length == 0)
                {
                    msg += errorCount + ". Current password not entered" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (txtNewPassword.Text.Trim().Length == 0)
                {
                    msg += errorCount + ". New password not entered" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (txtConfirm.Text.Trim().Length == 0)
                {
                    msg += errorCount + ". Confirmation password not entered" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (!((txtNewPassword.Text.Trim() ?? "") == (txtConfirm.Text.Trim() ?? "")))
                {
                    msg += errorCount + ". Confirmation does not match new password" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (!string.IsNullOrEmpty(App.loggedInUser.Password) && !((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.loggedInUser.Password ?? "")))
                {
                    msg += errorCount + ". Incorrect current password entered" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                int minLength = 8;
                var upper = new Regex("[A-Z]");
                var lower = new Regex("[a-z]");
                var number = new Regex("[0-9]");
                var special = new Regex("[^a-zA-Z0-9]");
                string pwd = txtNewPassword.Text;
                if (Strings.Len(pwd) < minLength)
                {
                    msg += errorCount + ". Password must have a minimum length of 8 characters" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (upper.Matches(pwd).Count < 1)
                {
                    msg += errorCount + ". Password must contain a upper case character" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (lower.Matches(pwd).Count < 1)
                {
                    msg += errorCount + ". Password must contain a lower case character" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (number.Matches(pwd).Count < 1 & special.Matches(pwd).Count < 1)
                {
                    msg += errorCount + ". Password must contain a number and/or a special character" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (App.loggedInUser.UserID == App.TheSystem.Configuration.SuperAdminID)
                {
                    msg += errorCount + ". System Administrator's details cannot be changed" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                var fullName = App.loggedInUser.Fullname.Split(new char[] { ' ' });
                if (fullName.Length > 0 && pwd.ToLower().Contains(fullName[0].ToLower()))
                {
                    msg += errorCount + ". Password cannot contain your name" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (pwd.ToLower().Contains("password"))
                {
                    msg += errorCount + ". Password cannot contain 'password'" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                var dtPasswords = App.DB.User.Get_Passwords(App.loggedInUser.UserID).Table;
                foreach (DataRow row in dtPasswords.Rows)
                {
                    string pass = Entity.Sys.Helper.HashPassword(pwd);
                    if (Conversions.ToBoolean((!Information.IsDBNull(row["CurrentPassword"]) && Operators.ConditionalCompareObjectEqual(pass, row["CurrentPassword"], false)) | (!Information.IsDBNull(row["LastPassword"]) && Operators.ConditionalCompareObjectEqual(pass, row["LastPassword"], false)) | (!Information.IsDBNull(row["EarliestPassword"]) && Operators.ConditionalCompareObjectEqual(pass, row["EarliestPassword"], false))))
                    {
                        msg += errorCount + ". Password does not match historic requirement" + Constants.vbCrLf;
                        errorCount += 1;
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    App.DB.User.UpdatePassword(App.loggedInUser.UserID, txtNewPassword.Text.Trim());
                    App.loggedInUser.SetPassword = Entity.Sys.Helper.HashPassword(txtNewPassword.Text.Trim());
                    App.ShowMessage("Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNewPassword.Text = string.Empty;
                    txtConfirm.Text = string.Empty;
                    txtNewPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Unable to save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ActiveControl = txtPassword;
                txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPassword.Focus();
            }
        }

        private void TxtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirm.Focus();
            }
        }

        private void TxtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdate_Click(sender, e);
            }
        }
    }
}