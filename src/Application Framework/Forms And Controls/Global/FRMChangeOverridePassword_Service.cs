using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMChangeOverridePassword_Service : FRMBaseForm, IForm
    {
        public FRMChangeOverridePassword_Service() : base()
        {
            base.Load += FRMChangeOverridePassword_Load;

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
        private Button _btnUpdate;

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
                }

                _txtNewPassword = value;
                if (_txtNewPassword != null)
                {
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
                }

                _txtConfirm = value;
                if (_txtConfirm != null)
                {
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
                }

                _txtPassword = value;
                if (_txtPassword != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnUpdate = new Button();
            _btnUpdate.Click += new EventHandler(btnUpdate_Click);
            _grpNewDetails = new GroupBox();
            _Label2 = new Label();
            _Label3 = new Label();
            _txtNewPassword = new TextBox();
            _txtConfirm = new TextBox();
            _grpCurrentDetails = new GroupBox();
            _txtPassword = new TextBox();
            _Label1 = new Label();
            _grpNewDetails.SuspendLayout();
            _grpCurrentDetails.SuspendLayout();
            SuspendLayout();
            //
            // btnUpdate
            //
            _btnUpdate.AccessibleDescription = "Update the override password";
            _btnUpdate.Cursor = Cursors.Hand;
            _btnUpdate.UseVisualStyleBackColor = true;
            _btnUpdate.Location = new Point(336, 208);
            _btnUpdate.Name = "btnUpdate";
            _btnUpdate.Size = new Size(56, 23);
            _btnUpdate.TabIndex = 37;
            _btnUpdate.Text = "Update";
            //
            // grpNewDetails
            //
            _grpNewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpNewDetails.Controls.Add(_Label2);
            _grpNewDetails.Controls.Add(_Label3);
            _grpNewDetails.Controls.Add(_txtNewPassword);
            _grpNewDetails.Controls.Add(_txtConfirm);
            _grpNewDetails.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpNewDetails.Location = new Point(8, 104);
            _grpNewDetails.Name = "grpNewDetails";
            _grpNewDetails.Size = new Size(384, 96);
            _grpNewDetails.TabIndex = 39;
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
            _txtNewPassword.Size = new Size(265, 21);
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
            _txtConfirm.Size = new Size(265, 21);
            _txtConfirm.TabIndex = 3;
            //
            // grpCurrentDetails
            //
            _grpCurrentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCurrentDetails.Controls.Add(_txtPassword);
            _grpCurrentDetails.Controls.Add(_Label1);
            _grpCurrentDetails.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpCurrentDetails.Location = new Point(8, 40);
            _grpCurrentDetails.Name = "grpCurrentDetails";
            _grpCurrentDetails.Size = new Size(384, 56);
            _grpCurrentDetails.TabIndex = 38;
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
            _txtPassword.Size = new Size(264, 21);
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
            // FRMChangeOverridePassword_Service
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(392, 233);
            Controls.Add(_btnUpdate);
            Controls.Add(_grpNewDetails);
            Controls.Add(_grpCurrentDetails);
            MaximizeBox = false;
            MaximumSize = new Size(408, 272);
            MinimizeBox = false;
            MinimumSize = new Size(408, 272);
            Name = "FRMChangeOverridePassword_Service";
            Text = "Service Override Password";
            Controls.SetChildIndex(_grpCurrentDetails, 0);
            Controls.SetChildIndex(_grpNewDetails, 0);
            Controls.SetChildIndex(_btnUpdate, 0);
            _grpNewDetails.ResumeLayout(false);
            _grpNewDetails.PerformLayout();
            _grpCurrentDetails.ResumeLayout(false);
            _grpCurrentDetails.PerformLayout();
            ResumeLayout(false);
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

        private void FRMChangeOverridePassword_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
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

                if (!((Entity.Sys.Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword_Service ?? "")))
                {
                    msg += errorCount + ". Current password incorrect" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (!((txtNewPassword.Text.Trim() ?? "") == (txtConfirm.Text.Trim() ?? "")))
                {
                    msg += errorCount + ". New and confirm password do not match" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (txtNewPassword.Text.Trim().Length < 6)
                {
                    msg += errorCount + ". Password too short (6 - 25 characters)" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (txtNewPassword.Text.Trim().Length > 25)
                {
                    msg += errorCount + ". Password too long (6 - 25 characters)" + Constants.vbCrLf;
                    errorCount += 1;
                    valid = false;
                }

                if (valid)
                {
                    App.DB.Manager.UpdateOverridePassword_Service(txtNewPassword.Text.Trim());
                    App.ShowMessage("Service Override Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirm.Text = "";
                }
                else
                {
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving New Password : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ActiveControl = txtPassword;
                txtPassword.Focus();
            }
        }
    }
}