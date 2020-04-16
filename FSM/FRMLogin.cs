// Decompiled with JetBrains decompiler
// Type: FSM.FRMLogin
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMLogin : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMLogin()
    {
      this.Load += new EventHandler(this.FRMLogin_Load);
      this.Closing += new CancelEventHandler(this.FRMLogin_Closing);
      this.KeyDown += new KeyEventHandler(this.FRMLogin_KeyDown);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpLoginDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtUserName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnLogin
    {
      get
      {
        return this._btnLogin;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnLogin_Click);
        Button btnLogin1 = this._btnLogin;
        if (btnLogin1 != null)
          btnLogin1.Click -= eventHandler;
        this._btnLogin = value;
        Button btnLogin2 = this._btnLogin;
        if (btnLogin2 == null)
          return;
        btnLogin2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMLogin));
      this.grpLoginDetails = new GroupBox();
      this.btnLogin = new Button();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.txtUserName = new TextBox();
      this.txtPassword = new TextBox();
      this.grpLoginDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpLoginDetails.Controls.Add((Control) this.btnLogin);
      this.grpLoginDetails.Controls.Add((Control) this.Label2);
      this.grpLoginDetails.Controls.Add((Control) this.Label3);
      this.grpLoginDetails.Controls.Add((Control) this.txtUserName);
      this.grpLoginDetails.Controls.Add((Control) this.txtPassword);
      this.grpLoginDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpLoginDetails.Location = new System.Drawing.Point(8, 40);
      this.grpLoginDetails.Name = "grpLoginDetails";
      this.grpLoginDetails.Size = new Size(392, 128);
      this.grpLoginDetails.TabIndex = 12;
      this.grpLoginDetails.TabStop = false;
      this.grpLoginDetails.Text = "Enter Login Details";
      this.btnLogin.AccessibleDescription = "Login to application";
      this.btnLogin.Cursor = Cursors.Hand;
      this.btnLogin.Location = new System.Drawing.Point(96, 96);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new Size(56, 23);
      this.btnLogin.TabIndex = 3;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(16, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(80, 16);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Username";
      this.Label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(16, 64);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(80, 23);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Password";
      this.txtUserName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtUserName.Location = new System.Drawing.Point(96, 22);
      this.txtUserName.MaxLength = 50;
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new Size(288, 21);
      this.txtUserName.TabIndex = 1;
      this.txtPassword.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPassword.Location = new System.Drawing.Point(96, 62);
      this.txtPassword.MaxLength = 50;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(288, 21);
      this.txtPassword.TabIndex = 2;
      this.AcceptButton = (IButtonControl) this.btnLogin;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(400, 169);
      this.Controls.Add((Control) this.grpLoginDetails);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(416, 208);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(416, 208);
      this.Name = nameof (FRMLogin);
      this.Controls.SetChildIndex((Control) this.grpLoginDetails, 0);
      this.grpLoginDetails.ResumeLayout(false);
      this.grpLoginDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.txtUserName.Text = "admin";
      bool flag = true;
      if (flag == App.IsGasway)
        this.txtPassword.Text = "Gabriel_!";
      else if (flag == App.IsRFT)
      {
        this.txtPassword.Text = "RftAdm!n57";
      }
      else
      {
        if (flag != App.IsBlueflame)
          return;
        this.txtPassword.Text = "Blu3Adm!n57";
      }
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

    private void FRMLogin_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void FRMLogin_Closing(object sender, CancelEventArgs e)
    {
      e.Cancel = true;
      App.CloseApplication();
    }

    private void FRMLogin_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Escape)
          return;
        App.CloseApplication();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Action cannot be completed : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      this.LogMeIn();
    }

    private void LogMeIn()
    {
      if (this.txtUserName.Text.Trim().Length == 0 | this.txtPassword.Text.Trim().Length == 0)
      {
        int num1 = (int) App.ShowMessage("Missing Login Details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        try
        {
          if (!App.DB.User.Authenticate(this.txtUserName.Text, this.txtPassword.Text))
          {
            App.DB.User.IsUserActive(this.txtUserName.Text, 0, true);
            if (!string.IsNullOrEmpty(App.loggedInUser?.Password))
              App.loggedInUser = (User) null;
          }
          this.txtPassword.Text = "";
          this.ActiveControl = (Control) this.txtUserName;
          this.txtUserName.Focus();
          if (App.loggedInUser == null)
          {
            int num2 = (int) App.ShowMessage("Invalid login details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else if (App.loggedInUser.UpdateAtLogon | DateTime.Compare(App.loggedInUser.PasswordExpiryDate, DateAndTime.Now.AddDays(-1.0)) < 0)
          {
            FRMChangePassword frmChangePassword = new FRMChangePassword();
            int num3 = (int) frmChangePassword.ShowDialog();
            if (frmChangePassword.DialogResult == DialogResult.Yes)
            {
              VersionChecker.Unlock();
              App.Login();
            }
            else
            {
              int num4 = (int) App.ShowMessage("New password needed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Application cannot load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          Application.Exit();
          ProjectData.ClearProjectError();
        }
      }
    }
  }
}
