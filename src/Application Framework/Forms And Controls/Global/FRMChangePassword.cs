using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMChangePassword : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMChangePassword() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpNewDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpNewDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpNewDetails != null)
                {
                }

                _grpNewDetails = value;
                if (_grpNewDetails != null)
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

        internal GroupBox grpCurrentDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCurrentDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCurrentDetails != null)
                {
                }

                _grpCurrentDetails = value;
                if (_grpCurrentDetails != null)
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

        private Button _btnUpdate;

        internal Button btnUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click -= btnUpdate_Click;
                }

                _btnUpdate = value;
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click += btnUpdate_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpNewDetails = new GroupBox();
            _Label2 = new Label();
            _Label3 = new Label();
            _txtNewPassword = new TextBox();
            _txtNewPassword.KeyDown += new KeyEventHandler(TxtNewPassword_KeyDown);
            _txtConfirm = new TextBox();
            _txtConfirm.KeyDown += new KeyEventHandler(TxtConfirm_KeyDown);
            _btnUpdate = new Button();
            _btnUpdate.Click += new EventHandler(btnUpdate_Click);
            _grpCurrentDetails = new GroupBox();
            _txtPassword = new TextBox();
            _txtPassword.KeyDown += new KeyEventHandler(TxtPassword_KeyDown);
            _Label1 = new Label();
            _grpNewDetails.SuspendLayout();
            _grpCurrentDetails.SuspendLayout();
            SuspendLayout();
            // 
            // grpNewDetails
            // 
            _grpNewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpNewDetails.Controls.Add(_Label2);
            _grpNewDetails.Controls.Add(_Label3);
            _grpNewDetails.Controls.Add(_txtNewPassword);
            _grpNewDetails.Controls.Add(_txtConfirm);
            _grpNewDetails.Controls.Add(_btnUpdate);
            _grpNewDetails.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpNewDetails.Location = new Point(9, 104);
            _grpNewDetails.Name = "grpNewDetails";
            _grpNewDetails.Size = new Size(391, 128);
            _grpNewDetails.TabIndex = 36;
            _grpNewDetails.TabStop = false;
            _grpNewDetails.Text = "New Details";
            // 
            // Label2
            // 
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(16, 32);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 17;
            _Label2.Text = "Password ";
            // 
            // Label3
            // 
            _Label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(16, 64);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 16);
            _Label3.TabIndex = 19;
            _Label3.Text = "Confirm ";
            // 
            // txtNewPassword
            // 
            _txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNewPassword.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtNewPassword.Location = new Point(112, 32);
            _txtNewPassword.MaxLength = 50;
            _txtNewPassword.Name = "txtNewPassword";
            _txtNewPassword.PasswordChar = (char)42;
            _txtNewPassword.Size = new Size(272, 21);
            _txtNewPassword.TabIndex = 2;
            // 
            // txtConfirm
            // 
            _txtConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtConfirm.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtConfirm.Location = new Point(112, 64);
            _txtConfirm.MaxLength = 50;
            _txtConfirm.Name = "txtConfirm";
            _txtConfirm.PasswordChar = (char)42;
            _txtConfirm.Size = new Size(272, 21);
            _txtConfirm.TabIndex = 3;
            // 
            // btnUpdate
            // 
            _btnUpdate.AccessibleDescription = "Update your password";
            _btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdate.Cursor = Cursors.Hand;
            _btnUpdate.Location = new Point(327, 96);
            _btnUpdate.Name = "btnUpdate";
            _btnUpdate.Size = new Size(56, 23);
            _btnUpdate.TabIndex = 4;
            _btnUpdate.Text = "Update";
            _btnUpdate.UseVisualStyleBackColor = true;
            // 
            // grpCurrentDetails
            // 
            _grpCurrentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCurrentDetails.Controls.Add(_txtPassword);
            _grpCurrentDetails.Controls.Add(_Label1);
            _grpCurrentDetails.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpCurrentDetails.Location = new Point(9, 40);
            _grpCurrentDetails.Name = "grpCurrentDetails";
            _grpCurrentDetails.Size = new Size(391, 61);
            _grpCurrentDetails.TabIndex = 35;
            _grpCurrentDetails.TabStop = false;
            _grpCurrentDetails.Text = "Current Details";
            // 
            // txtPassword
            // 
            _txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPassword.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPassword.Location = new Point(112, 24);
            _txtPassword.MaxLength = 50;
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(271, 21);
            _txtPassword.TabIndex = 1;
            // 
            // Label1
            // 
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(16, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 20;
            _Label1.Text = "Password ";
            // 
            // FRMChangePassword
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(412, 242);
            Controls.Add(_grpNewDetails);
            Controls.Add(_grpCurrentDetails);
            MaximizeBox = false;
            MaximumSize = new Size(428, 281);
            MinimizeBox = false;
            MinimumSize = new Size(428, 281);
            Name = "FRMChangePassword";
            Text = "Your Password";
            Controls.SetChildIndex(_grpCurrentDetails, 0);
            Controls.SetChildIndex(_grpNewDetails, 0);
            _grpNewDetails.ResumeLayout(false);
            _grpNewDetails.PerformLayout();
            _grpCurrentDetails.ResumeLayout(false);
            _grpCurrentDetails.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}