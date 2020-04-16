// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangeOverridePassword_Service
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMChangeOverridePassword_Service : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMChangeOverridePassword_Service()
    {
      this.Load += new EventHandler(this.FRMChangeOverridePassword_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnUpdate
    {
      get
      {
        return this._btnUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdate_Click);
        Button btnUpdate1 = this._btnUpdate;
        if (btnUpdate1 != null)
          btnUpdate1.Click -= eventHandler;
        this._btnUpdate = value;
        Button btnUpdate2 = this._btnUpdate;
        if (btnUpdate2 == null)
          return;
        btnUpdate2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpNewDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNewPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtConfirm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpCurrentDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnUpdate = new Button();
      this.grpNewDetails = new GroupBox();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.txtNewPassword = new TextBox();
      this.txtConfirm = new TextBox();
      this.grpCurrentDetails = new GroupBox();
      this.txtPassword = new TextBox();
      this.Label1 = new Label();
      this.grpNewDetails.SuspendLayout();
      this.grpCurrentDetails.SuspendLayout();
      this.SuspendLayout();
      this.btnUpdate.AccessibleDescription = "Update the override password";
      this.btnUpdate.Cursor = Cursors.Hand;
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Location = new System.Drawing.Point(336, 208);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new Size(56, 23);
      this.btnUpdate.TabIndex = 37;
      this.btnUpdate.Text = "Update";
      this.grpNewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpNewDetails.Controls.Add((Control) this.Label2);
      this.grpNewDetails.Controls.Add((Control) this.Label3);
      this.grpNewDetails.Controls.Add((Control) this.txtNewPassword);
      this.grpNewDetails.Controls.Add((Control) this.txtConfirm);
      this.grpNewDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpNewDetails.Location = new System.Drawing.Point(8, 104);
      this.grpNewDetails.Name = "grpNewDetails";
      this.grpNewDetails.Size = new Size(384, 96);
      this.grpNewDetails.TabIndex = 39;
      this.grpNewDetails.TabStop = false;
      this.grpNewDetails.Text = "New Details";
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(16, 32);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 17;
      this.Label2.Text = "Password ";
      this.Label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(16, 64);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 16);
      this.Label3.TabIndex = 19;
      this.Label3.Text = "Confirm ";
      this.txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNewPassword.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtNewPassword.Location = new System.Drawing.Point(112, 32);
      this.txtNewPassword.MaxLength = 50;
      this.txtNewPassword.Name = "txtNewPassword";
      this.txtNewPassword.PasswordChar = '*';
      this.txtNewPassword.Size = new Size(265, 21);
      this.txtNewPassword.TabIndex = 2;
      this.txtConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtConfirm.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtConfirm.Location = new System.Drawing.Point(112, 64);
      this.txtConfirm.MaxLength = 50;
      this.txtConfirm.Name = "txtConfirm";
      this.txtConfirm.PasswordChar = '*';
      this.txtConfirm.Size = new Size(265, 21);
      this.txtConfirm.TabIndex = 3;
      this.grpCurrentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCurrentDetails.Controls.Add((Control) this.txtPassword);
      this.grpCurrentDetails.Controls.Add((Control) this.Label1);
      this.grpCurrentDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpCurrentDetails.Location = new System.Drawing.Point(8, 40);
      this.grpCurrentDetails.Name = "grpCurrentDetails";
      this.grpCurrentDetails.Size = new Size(384, 56);
      this.grpCurrentDetails.TabIndex = 38;
      this.grpCurrentDetails.TabStop = false;
      this.grpCurrentDetails.Text = "Current Details";
      this.txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPassword.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPassword.Location = new System.Drawing.Point(112, 24);
      this.txtPassword.MaxLength = 50;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(264, 21);
      this.txtPassword.TabIndex = 1;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(16, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Password ";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(392, 233);
      this.Controls.Add((Control) this.btnUpdate);
      this.Controls.Add((Control) this.grpNewDetails);
      this.Controls.Add((Control) this.grpCurrentDetails);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(408, 272);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(408, 272);
      this.Name = nameof (FRMChangeOverridePassword_Service);
      this.Text = "Service Override Password";
      this.Controls.SetChildIndex((Control) this.grpCurrentDetails, 0);
      this.Controls.SetChildIndex((Control) this.grpNewDetails, 0);
      this.Controls.SetChildIndex((Control) this.btnUpdate, 0);
      this.grpNewDetails.ResumeLayout(false);
      this.grpNewDetails.PerformLayout();
      this.grpCurrentDetails.ResumeLayout(false);
      this.grpCurrentDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ActiveControl = (Control) this.txtPassword;
      this.txtPassword.Focus();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private void FRMChangeOverridePassword_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        string MessageText = "Please correct the following errors : \r\n\r\n";
        int num1 = 1;
        bool flag = true;
        if (this.txtPassword.Text.Trim().Length == 0)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Current password not entered\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (this.txtNewPassword.Text.Trim().Length == 0)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". New password not entered\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (this.txtConfirm.Text.Trim().Length == 0)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Confirmation password not entered\r\n";
          checked { ++num1; }
          flag = false;
        }
        if ((uint) Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.DB.Manager.Get().OverridePassword_Service, false) > 0U)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Current password incorrect\r\n";
          checked { ++num1; }
          flag = false;
        }
        if ((uint) Operators.CompareString(this.txtNewPassword.Text.Trim(), this.txtConfirm.Text.Trim(), false) > 0U)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". New and confirm password do not match\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (this.txtNewPassword.Text.Trim().Length < 6)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password too short (6 - 25 characters)\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (this.txtNewPassword.Text.Trim().Length > 25)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password too long (6 - 25 characters)\r\n";
          int num2 = checked (num1 + 1);
          flag = false;
        }
        if (flag)
        {
          App.DB.Manager.UpdateOverridePassword_Service(this.txtNewPassword.Text.Trim());
          int num2 = (int) App.ShowMessage("Service Override Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.txtPassword.Text = "";
          this.txtNewPassword.Text = "";
          this.txtConfirm.Text = "";
        }
        else
        {
          int num3 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving New Password : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.ActiveControl = (Control) this.txtPassword;
        this.txtPassword.Focus();
      }
    }
  }
}
