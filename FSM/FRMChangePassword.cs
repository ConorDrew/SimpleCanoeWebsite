// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangePassword
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
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
    private IContainer components;
    private bool isLoading;

    public FRMChangePassword()
    {
      this.Load += new EventHandler(this.FRMChangePassword_Load);
      this.isLoading = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpNewDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNewPassword
    {
      get
      {
        return this._txtNewPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.TxtNewPassword_KeyDown);
        TextBox txtNewPassword1 = this._txtNewPassword;
        if (txtNewPassword1 != null)
          txtNewPassword1.KeyDown -= keyEventHandler;
        this._txtNewPassword = value;
        TextBox txtNewPassword2 = this._txtNewPassword;
        if (txtNewPassword2 == null)
          return;
        txtNewPassword2.KeyDown += keyEventHandler;
      }
    }

    internal virtual TextBox txtConfirm
    {
      get
      {
        return this._txtConfirm;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.TxtConfirm_KeyDown);
        TextBox txtConfirm1 = this._txtConfirm;
        if (txtConfirm1 != null)
          txtConfirm1.KeyDown -= keyEventHandler;
        this._txtConfirm = value;
        TextBox txtConfirm2 = this._txtConfirm;
        if (txtConfirm2 == null)
          return;
        txtConfirm2.KeyDown += keyEventHandler;
      }
    }

    internal virtual GroupBox grpCurrentDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPassword
    {
      get
      {
        return this._txtPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.TxtPassword_KeyDown);
        TextBox txtPassword1 = this._txtPassword;
        if (txtPassword1 != null)
          txtPassword1.KeyDown -= keyEventHandler;
        this._txtPassword = value;
        TextBox txtPassword2 = this._txtPassword;
        if (txtPassword2 == null)
          return;
        txtPassword2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpNewDetails = new GroupBox();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.txtNewPassword = new TextBox();
      this.txtConfirm = new TextBox();
      this.btnUpdate = new Button();
      this.grpCurrentDetails = new GroupBox();
      this.txtPassword = new TextBox();
      this.Label1 = new Label();
      this.grpNewDetails.SuspendLayout();
      this.grpCurrentDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpNewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpNewDetails.Controls.Add((Control) this.Label2);
      this.grpNewDetails.Controls.Add((Control) this.Label3);
      this.grpNewDetails.Controls.Add((Control) this.txtNewPassword);
      this.grpNewDetails.Controls.Add((Control) this.txtConfirm);
      this.grpNewDetails.Controls.Add((Control) this.btnUpdate);
      this.grpNewDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpNewDetails.Location = new System.Drawing.Point(9, 104);
      this.grpNewDetails.Name = "grpNewDetails";
      this.grpNewDetails.Size = new Size(391, 128);
      this.grpNewDetails.TabIndex = 36;
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
      this.txtNewPassword.Size = new Size(272, 21);
      this.txtNewPassword.TabIndex = 2;
      this.txtConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtConfirm.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtConfirm.Location = new System.Drawing.Point(112, 64);
      this.txtConfirm.MaxLength = 50;
      this.txtConfirm.Name = "txtConfirm";
      this.txtConfirm.PasswordChar = '*';
      this.txtConfirm.Size = new Size(272, 21);
      this.txtConfirm.TabIndex = 3;
      this.btnUpdate.AccessibleDescription = "Update your password";
      this.btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdate.Cursor = Cursors.Hand;
      this.btnUpdate.Location = new System.Drawing.Point(327, 96);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new Size(56, 23);
      this.btnUpdate.TabIndex = 4;
      this.btnUpdate.Text = "Update";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.grpCurrentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCurrentDetails.Controls.Add((Control) this.txtPassword);
      this.grpCurrentDetails.Controls.Add((Control) this.Label1);
      this.grpCurrentDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpCurrentDetails.Location = new System.Drawing.Point(9, 40);
      this.grpCurrentDetails.Name = "grpCurrentDetails";
      this.grpCurrentDetails.Size = new Size(391, 61);
      this.grpCurrentDetails.TabIndex = 35;
      this.grpCurrentDetails.TabStop = false;
      this.grpCurrentDetails.Text = "Current Details";
      this.txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPassword.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPassword.Location = new System.Drawing.Point(112, 24);
      this.txtPassword.MaxLength = 50;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(271, 21);
      this.txtPassword.TabIndex = 1;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(16, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Password ";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(412, 242);
      this.Controls.Add((Control) this.grpNewDetails);
      this.Controls.Add((Control) this.grpCurrentDetails);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(428, 281);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(428, 281);
      this.Name = nameof (FRMChangePassword);
      this.Text = "Your Password";
      this.Controls.SetChildIndex((Control) this.grpCurrentDetails, 0);
      this.Controls.SetChildIndex((Control) this.grpNewDetails, 0);
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

    private void FRMChangePassword_Load(object sender, EventArgs e)
    {
      this.isLoading = true;
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.isLoading = false;
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
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtNewPassword.Text.Trim(), this.txtConfirm.Text.Trim(), false) > 0U)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Confirmation does not match new password\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (!string.IsNullOrEmpty(App.loggedInUser.Password) && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.loggedInUser.Password, false) > 0U)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Incorrect current password entered\r\n";
          checked { ++num1; }
          flag = false;
        }
        int num2 = 8;
        Regex regex1 = new Regex("[A-Z]");
        Regex regex2 = new Regex("[a-z]");
        Regex regex3 = new Regex("[0-9]");
        Regex regex4 = new Regex("[^a-zA-Z0-9]");
        string text = this.txtNewPassword.Text;
        if (Strings.Len(text) < num2)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password must have a minimum length of 8 characters\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (regex1.Matches(text).Count < 1)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password must contain a upper case character\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (regex2.Matches(text).Count < 1)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password must contain a lower case character\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (regex3.Matches(text).Count < 1 & regex4.Matches(text).Count < 1)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password must contain a number and/or a special character\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (App.loggedInUser.UserID == App.TheSystem.Configuration.SuperAdminID)
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". System Administrator's details cannot be changed\r\n";
          checked { ++num1; }
          flag = false;
        }
        string[] strArray = App.loggedInUser.Fullname.Split(' ');
        if (strArray.Length > 0 && text.ToLower().Contains(strArray[0].ToLower()))
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password cannot contain your name\r\n";
          checked { ++num1; }
          flag = false;
        }
        if (text.ToLower().Contains("password"))
        {
          MessageText = MessageText + Conversions.ToString(num1) + ". Password cannot contain 'password'\r\n";
          checked { ++num1; }
          flag = false;
        }
        DataTable table = App.DB.User.Get_Passwords(App.loggedInUser.UserID).Table;
        IEnumerator enumerator;
        try
        {
          enumerator = table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            string str = Helper.HashPassword(text);
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (bool) (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["CurrentPassword"])) ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual((object) str, current["CurrentPassword"], false)) ? 1 : 0)), (object) (bool) (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["LastPassword"])) ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual((object) str, current["LastPassword"], false)) ? 1 : 0))), (object) (bool) (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["EarliestPassword"])) ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual((object) str, current["EarliestPassword"], false)) ? 1 : 0)))))
            {
              MessageText = MessageText + Conversions.ToString(num1) + ". Password does not match historic requirement\r\n";
              int num3 = checked (num1 + 1);
              flag = false;
              break;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (flag)
        {
          App.DB.User.UpdatePassword(App.loggedInUser.UserID, this.txtNewPassword.Text.Trim(), false);
          App.loggedInUser.SetPassword = (object) Helper.HashPassword(this.txtNewPassword.Text.Trim());
          int num3 = (int) App.ShowMessage("Password changed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.DialogResult = DialogResult.Yes;
          if (this.Modal)
            this.Close();
          else
            this.Dispose();
        }
        else
        {
          int num3 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.txtNewPassword.Text = string.Empty;
          this.txtConfirm.Text = string.Empty;
          this.txtNewPassword.Focus();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Unable to save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.ActiveControl = (Control) this.txtPassword;
        this.txtPassword.Focus();
      }
    }

    private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.txtNewPassword.Focus();
    }

    private void TxtNewPassword_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.txtConfirm.Focus();
    }

    private void TxtConfirm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnUpdate_Click(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
    }
  }
}
