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
            this._btnUpdate = new System.Windows.Forms.Button();
            this._grpNewDetails = new System.Windows.Forms.GroupBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtNewPassword = new System.Windows.Forms.TextBox();
            this._txtConfirm = new System.Windows.Forms.TextBox();
            this._grpCurrentDetails = new System.Windows.Forms.GroupBox();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._grpNewDetails.SuspendLayout();
            this._grpCurrentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnUpdate
            // 
            this._btnUpdate.AccessibleDescription = "Update the override password";
            this._btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnUpdate.Location = new System.Drawing.Point(332, 180);
            this._btnUpdate.Name = "_btnUpdate";
            this._btnUpdate.Size = new System.Drawing.Size(56, 23);
            this._btnUpdate.TabIndex = 37;
            this._btnUpdate.Text = "Update";
            this._btnUpdate.UseVisualStyleBackColor = true;
            this._btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // _grpNewDetails
            // 
            this._grpNewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpNewDetails.Controls.Add(this._Label2);
            this._grpNewDetails.Controls.Add(this._Label3);
            this._grpNewDetails.Controls.Add(this._txtNewPassword);
            this._grpNewDetails.Controls.Add(this._txtConfirm);
            this._grpNewDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpNewDetails.Location = new System.Drawing.Point(4, 76);
            this._grpNewDetails.Name = "_grpNewDetails";
            this._grpNewDetails.Size = new System.Drawing.Size(380, 94);
            this._grpNewDetails.TabIndex = 39;
            this._grpNewDetails.TabStop = false;
            this._grpNewDetails.Text = "New Details";
            // 
            // _Label2
            // 
            this._Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label2.Location = new System.Drawing.Point(20, 32);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 17;
            this._Label2.Text = "Password ";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(20, 64);
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
            this._txtNewPassword.Location = new System.Drawing.Point(116, 32);
            this._txtNewPassword.MaxLength = 50;
            this._txtNewPassword.Name = "_txtNewPassword";
            this._txtNewPassword.PasswordChar = '*';
            this._txtNewPassword.Size = new System.Drawing.Size(258, 21);
            this._txtNewPassword.TabIndex = 2;
            // 
            // _txtConfirm
            // 
            this._txtConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtConfirm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtConfirm.Location = new System.Drawing.Point(116, 64);
            this._txtConfirm.MaxLength = 50;
            this._txtConfirm.Name = "_txtConfirm";
            this._txtConfirm.PasswordChar = '*';
            this._txtConfirm.Size = new System.Drawing.Size(258, 21);
            this._txtConfirm.TabIndex = 3;
            // 
            // _grpCurrentDetails
            // 
            this._grpCurrentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCurrentDetails.Controls.Add(this._txtPassword);
            this._grpCurrentDetails.Controls.Add(this._Label1);
            this._grpCurrentDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpCurrentDetails.Location = new System.Drawing.Point(4, 12);
            this._grpCurrentDetails.Name = "_grpCurrentDetails";
            this._grpCurrentDetails.Size = new System.Drawing.Size(380, 54);
            this._grpCurrentDetails.TabIndex = 38;
            this._grpCurrentDetails.TabStop = false;
            this._grpCurrentDetails.Text = "Current Details";
            // 
            // _txtPassword
            // 
            this._txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPassword.Location = new System.Drawing.Point(116, 24);
            this._txtPassword.MaxLength = 50;
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '*';
            this._txtPassword.Size = new System.Drawing.Size(258, 21);
            this._txtPassword.TabIndex = 1;
            // 
            // _Label1
            // 
            this._Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1.Location = new System.Drawing.Point(20, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 20;
            this._Label1.Text = "Password ";
            // 
            // FRMChangeOverridePassword_Service
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(392, 214);
            this.Controls.Add(this._btnUpdate);
            this.Controls.Add(this._grpNewDetails);
            this.Controls.Add(this._grpCurrentDetails);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMChangeOverridePassword_Service";
            this.Text = "Service Override Password";
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