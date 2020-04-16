// Decompiled with JetBrains decompiler
// Type: FSM.FRMUsers
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FRMUsers : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvUsers;
    private DataView _userModules;
    private DataView _userRegions;

    public FRMUsers()
    {
      this.Load += new EventHandler(this.FRMUsers_Load);
      this._userModules = (DataView) null;
      this._userRegions = (DataView) null;
      this.InitializeComponent();
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.loggedInUser.Fullname, "Hayleigh Mann", false) == 0)
        this.btnPopulateNewSecurityModules.Visible = true;
      else
        this.btnPopulateNewSecurityModules.Visible = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnAddNew
    {
      get
      {
        return this._btnAddNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNew_Click);
        Button btnAddNew1 = this._btnAddNew;
        if (btnAddNew1 != null)
          btnAddNew1.Click -= eventHandler;
        this._btnAddNew = value;
        Button btnAddNew2 = this._btnAddNew;
        if (btnAddNew2 == null)
          return;
        btnAddNew2.Click += eventHandler;
      }
    }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFullName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkEnabled { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtUserName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtConfirm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        Button btnReset1 = this._btnReset;
        if (btnReset1 != null)
          btnReset1.Click -= eventHandler;
        this._btnReset = value;
        Button btnReset2 = this._btnReset;
        if (btnReset2 == null)
          return;
        btnReset2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpUsers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgUsers
    {
      get
      {
        return this._dgUsers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgUsers_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgUsers_Click);
        DataGrid dgUsers1 = this._dgUsers;
        if (dgUsers1 != null)
        {
          dgUsers1.Click -= eventHandler1;
          dgUsers1.CurrentCellChanged -= eventHandler2;
        }
        this._dgUsers = value;
        DataGrid dgUsers2 = this._dgUsers;
        if (dgUsers2 == null)
          return;
        dgUsers2.Click += eventHandler1;
        dgUsers2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSecurityUserModules
    {
      get
      {
        return this._dgSecurityUserModules;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSecurityUserModules_Click);
        DataGrid securityUserModules1 = this._dgSecurityUserModules;
        if (securityUserModules1 != null)
          securityUserModules1.Click -= eventHandler;
        this._dgSecurityUserModules = value;
        DataGrid securityUserModules2 = this._dgSecurityUserModules;
        if (securityUserModules2 == null)
          return;
        securityUserModules2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkAdmin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPopulateNewSecurityModules
    {
      get
      {
        return this._btnPopulateNewSecurityModules;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPopulateNewSecurityModules_Click);
        Button newSecurityModules1 = this._btnPopulateNewSecurityModules;
        if (newSecurityModules1 != null)
          newSecurityModules1.Click -= eventHandler;
        this._btnPopulateNewSecurityModules = value;
        Button newSecurityModules2 = this._btnPopulateNewSecurityModules;
        if (newSecurityModules2 == null)
          return;
        newSecurityModules2.Click += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSDV { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDEG { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpUserRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgUserRegions
    {
      get
      {
        return this._dgUserRegions;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgUserRegions_Click);
        DataGrid dgUserRegions1 = this._dgUserRegions;
        if (dgUserRegions1 != null)
          dgUserRegions1.Click -= eventHandler;
        this._dgUserRegions = value;
        DataGrid dgUserRegions2 = this._dgUserRegions;
        if (dgUserRegions2 == null)
          return;
        dgUserRegions2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpUsers = new GroupBox();
      this.dgUsers = new DataGrid();
      this.btnAddNew = new Button();
      this.btnDelete = new Button();
      this.grpDetails = new GroupBox();
      this.cboDEG = new ComboBox();
      this.Label7 = new Label();
      this.chkSDV = new CheckBox();
      this.Label6 = new Label();
      this.txtEmailAddress = new TextBox();
      this.chkAdmin = new CheckBox();
      this.btnReset = new Button();
      this.txtConfirm = new TextBox();
      this.txtPassword = new TextBox();
      this.txtUserName = new TextBox();
      this.chkEnabled = new CheckBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label1 = new Label();
      this.txtFullName = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.GroupBox1 = new GroupBox();
      this.dgSecurityUserModules = new DataGrid();
      this.btnPopulateNewSecurityModules = new Button();
      this.grpUserRegions = new GroupBox();
      this.dgUserRegions = new DataGrid();
      this.grpUsers.SuspendLayout();
      this.dgUsers.BeginInit();
      this.grpDetails.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgSecurityUserModules.BeginInit();
      this.grpUserRegions.SuspendLayout();
      this.dgUserRegions.BeginInit();
      this.SuspendLayout();
      this.grpUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpUsers.Controls.Add((Control) this.dgUsers);
      this.grpUsers.Controls.Add((Control) this.btnAddNew);
      this.grpUsers.Controls.Add((Control) this.btnDelete);
      this.grpUsers.FlatStyle = FlatStyle.System;
      this.grpUsers.Location = new System.Drawing.Point(8, 40);
      this.grpUsers.Name = "grpUsers";
      this.grpUsers.Size = new Size(312, 547);
      this.grpUsers.TabIndex = 6;
      this.grpUsers.TabStop = false;
      this.grpUsers.Text = "Users";
      this.dgUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgUsers.DataMember = "";
      this.dgUsers.HeaderForeColor = SystemColors.ControlText;
      this.dgUsers.Location = new System.Drawing.Point(8, 57);
      this.dgUsers.Name = "dgUsers";
      this.dgUsers.Size = new Size(296, 482);
      this.dgUsers.TabIndex = 2;
      this.btnAddNew.AccessibleDescription = "Add new user";
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.Location = new System.Drawing.Point(8, 24);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(48, 23);
      this.btnAddNew.TabIndex = 1;
      this.btnAddNew.Text = "New";
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnDelete.AccessibleDescription = "Delete user";
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.Location = new System.Drawing.Point(62, 24);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(59, 23);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.cboDEG);
      this.grpDetails.Controls.Add((Control) this.Label7);
      this.grpDetails.Controls.Add((Control) this.chkSDV);
      this.grpDetails.Controls.Add((Control) this.Label6);
      this.grpDetails.Controls.Add((Control) this.txtEmailAddress);
      this.grpDetails.Controls.Add((Control) this.chkAdmin);
      this.grpDetails.Controls.Add((Control) this.btnReset);
      this.grpDetails.Controls.Add((Control) this.txtConfirm);
      this.grpDetails.Controls.Add((Control) this.txtPassword);
      this.grpDetails.Controls.Add((Control) this.txtUserName);
      this.grpDetails.Controls.Add((Control) this.chkEnabled);
      this.grpDetails.Controls.Add((Control) this.Label4);
      this.grpDetails.Controls.Add((Control) this.Label3);
      this.grpDetails.Controls.Add((Control) this.Label1);
      this.grpDetails.Controls.Add((Control) this.txtFullName);
      this.grpDetails.Controls.Add((Control) this.Label2);
      this.grpDetails.FlatStyle = FlatStyle.System;
      this.grpDetails.Location = new System.Drawing.Point(328, 40);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(457, 244);
      this.grpDetails.TabIndex = 8;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.cboDEG.Cursor = Cursors.Hand;
      this.cboDEG.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDEG.Location = new System.Drawing.Point((int) sbyte.MaxValue, 208);
      this.cboDEG.Name = "cboDEG";
      this.cboDEG.Size = new Size(324, 21);
      this.cboDEG.TabIndex = 20;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(9, 211);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(112, 13);
      this.Label7.TabIndex = 19;
      this.Label7.Text = "Default Eng Group";
      this.chkSDV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkSDV.Location = new System.Drawing.Point(300, 150);
      this.chkSDV.Name = "chkSDV";
      this.chkSDV.Size = new Size(149, 24);
      this.chkSDV.TabIndex = 17;
      this.chkSDV.Text = "Scheduler Day View";
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(9, 184);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(38, 13);
      this.Label6.TabIndex = 16;
      this.Label6.Text = "Email";
      this.txtEmailAddress.Location = new System.Drawing.Point((int) sbyte.MaxValue, 181);
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(322, 21);
      this.txtEmailAddress.TabIndex = 15;
      this.chkAdmin.Location = new System.Drawing.Point(182, 151);
      this.chkAdmin.Name = "chkAdmin";
      this.chkAdmin.Size = new Size(63, 24);
      this.chkAdmin.TabIndex = 14;
      this.chkAdmin.Text = "Admin";
      this.btnReset.AccessibleDescription = "Reset the users password";
      this.btnReset.Cursor = Cursors.Hand;
      this.btnReset.Location = new System.Drawing.Point(399, 86);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(48, 23);
      this.btnReset.TabIndex = 7;
      this.btnReset.Text = "Reset";
      this.btnReset.UseVisualStyleBackColor = true;
      this.txtConfirm.Location = new System.Drawing.Point((int) sbyte.MaxValue, 120);
      this.txtConfirm.MaxLength = 50;
      this.txtConfirm.Name = "txtConfirm";
      this.txtConfirm.PasswordChar = '*';
      this.txtConfirm.Size = new Size(322, 21);
      this.txtConfirm.TabIndex = 8;
      this.txtPassword.Location = new System.Drawing.Point((int) sbyte.MaxValue, 88);
      this.txtPassword.MaxLength = 50;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(266, 21);
      this.txtPassword.TabIndex = 6;
      this.txtUserName.Location = new System.Drawing.Point((int) sbyte.MaxValue, 56);
      this.txtUserName.MaxLength = 50;
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new Size(322, 21);
      this.txtUserName.TabIndex = 5;
      this.chkEnabled.Checked = true;
      this.chkEnabled.CheckState = CheckState.Checked;
      this.chkEnabled.Location = new System.Drawing.Point(12, 150);
      this.chkEnabled.Name = "chkEnabled";
      this.chkEnabled.Size = new Size(113, 24);
      this.chkEnabled.TabIndex = 10;
      this.chkEnabled.Text = "Logon Enabled";
      this.Label4.Location = new System.Drawing.Point(8, 120);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 10;
      this.Label4.Text = "Confirm";
      this.Label3.Location = new System.Drawing.Point(8, 88);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 16);
      this.Label3.TabIndex = 9;
      this.Label3.Text = "Password";
      this.Label1.Location = new System.Drawing.Point(8, 56);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(74, 16);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "Username";
      this.txtFullName.Location = new System.Drawing.Point((int) sbyte.MaxValue, 24);
      this.txtFullName.MaxLength = (int) byte.MaxValue;
      this.txtFullName.Name = "txtFullName";
      this.txtFullName.Size = new Size(322, 21);
      this.txtFullName.TabIndex = 4;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Full Name";
      this.btnSave.AccessibleDescription = "Save user details";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.Location = new System.Drawing.Point(737, 564);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 11;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgSecurityUserModules);
      this.GroupBox1.FlatStyle = FlatStyle.System;
      this.GroupBox1.Location = new System.Drawing.Point(326, 504);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(459, 54);
      this.GroupBox1.TabIndex = 12;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Module Access";
      this.dgSecurityUserModules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSecurityUserModules.DataMember = "";
      this.dgSecurityUserModules.HeaderForeColor = SystemColors.ControlText;
      this.dgSecurityUserModules.Location = new System.Drawing.Point(8, 20);
      this.dgSecurityUserModules.Name = "dgSecurityUserModules";
      this.dgSecurityUserModules.Size = new Size(443, 26);
      this.dgSecurityUserModules.TabIndex = 2;
      this.btnPopulateNewSecurityModules.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPopulateNewSecurityModules.Location = new System.Drawing.Point(536, 564);
      this.btnPopulateNewSecurityModules.Name = "btnPopulateNewSecurityModules";
      this.btnPopulateNewSecurityModules.Size = new Size(195, 23);
      this.btnPopulateNewSecurityModules.TabIndex = 13;
      this.btnPopulateNewSecurityModules.Text = "Populate New Security Modules";
      this.btnPopulateNewSecurityModules.UseVisualStyleBackColor = true;
      this.grpUserRegions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpUserRegions.Controls.Add((Control) this.dgUserRegions);
      this.grpUserRegions.FlatStyle = FlatStyle.System;
      this.grpUserRegions.Location = new System.Drawing.Point(328, 290);
      this.grpUserRegions.Name = "grpUserRegions";
      this.grpUserRegions.Size = new Size(459, 208);
      this.grpUserRegions.TabIndex = 13;
      this.grpUserRegions.TabStop = false;
      this.grpUserRegions.Text = "User Regions";
      this.dgUserRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgUserRegions.DataMember = "";
      this.dgUserRegions.HeaderForeColor = SystemColors.ControlText;
      this.dgUserRegions.Location = new System.Drawing.Point(8, 20);
      this.dgUserRegions.Name = "dgUserRegions";
      this.dgUserRegions.Size = new Size(443, 180);
      this.dgUserRegions.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(793, 593);
      this.Controls.Add((Control) this.grpUserRegions);
      this.Controls.Add((Control) this.btnPopulateNewSecurityModules);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.grpDetails);
      this.Controls.Add((Control) this.grpUsers);
      this.Controls.Add((Control) this.btnSave);
      this.MinimumSize = new Size(800, 576);
      this.Name = nameof (FRMUsers);
      this.Text = "Users";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.grpUsers, 0);
      this.Controls.SetChildIndex((Control) this.grpDetails, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnPopulateNewSecurityModules, 0);
      this.Controls.SetChildIndex((Control) this.grpUserRegions, 0);
      this.grpUsers.ResumeLayout(false);
      this.dgUsers.EndInit();
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.GroupBox1.ResumeLayout(false);
      this.dgSecurityUserModules.EndInit();
      this.grpUserRegions.ResumeLayout(false);
      this.dgUserRegions.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.Users = Conversions.ToString(this.get_GetParameter(0)).Trim().Length <= 0 ? App.DB.User.GetAll() : App.DB.User.User_Search(Conversions.ToString(this.get_GetParameter(0)));
      this.SetupUsersAndEngineersDataGrid();
      this.SetupUserModulesDatagrid();
      this.SetupUserRegionsDatagrid();
      ComboBox cboDeg = this.cboDEG;
      Combo.SetUpCombo(ref cboDeg, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboDEG = cboDeg;
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

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private DataView Users
    {
      get
      {
        return this._dvUsers;
      }
      set
      {
        this._dvUsers = value;
        this._dvUsers.Table.TableName = Enums.TableNames.tblUser.ToString();
        this._dvUsers.AllowNew = false;
        this._dvUsers.AllowEdit = false;
        this._dvUsers.AllowDelete = false;
        this.dgUsers.DataSource = (object) this.Users;
        this.SetUpPageState(Enums.FormState.Load);
        this.UserModules = (DataView) null;
        this.UserRegions = (DataView) null;
      }
    }

    private DataRow SelectedUserDataRow
    {
      get
      {
        return this.dgUsers.CurrentRowIndex != -1 ? this.Users[this.dgUsers.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupUsersAndEngineersDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgUsers.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "FullName";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 125;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Username";
      dataGridLabelColumn2.MappingName = "UserName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 125;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "PDA";
      dataGridLabelColumn3.MappingName = "PDAID";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 55;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblUser.ToString();
      this.dgUsers.TableStyles.Add(tableStyle);
    }

    public void SetupUserRegionsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgUserRegions, false);
      DataGridTableStyle tableStyle = this.dgUserRegions.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgUserRegions.ReadOnly = false;
      this.dgUserRegions.AllowSorting = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 300;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "";
      dataGridLabelColumn2.MappingName = "ManagerID";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 1;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.MappingName = Enums.TableNames.tblRegion.ToString();
      this.dgUserRegions.TableStyles.Add(tableStyle);
    }

    private void FRMUsers_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.SetUpPageState(Enums.FormState.Insert);
    }

    private void dgUsers_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedUserDataRow != null)
          return;
        this.SetUpPageState(Enums.FormState.Load);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Details cannot load : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetPassword();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.Delete();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnPopulateNewSecurityModules_Click(object sender, EventArgs e)
    {
      this.PopulateNewSecurityModules();
    }

    private void SetUpPageState(Enums.FormState state)
    {
      Helper.ClearGroupBox(this.grpDetails);
      switch (state)
      {
        case Enums.FormState.Load:
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = false;
          this.btnReset.Enabled = false;
          this.grpDetails.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = false;
          this.btnReset.Enabled = false;
          this.grpDetails.Enabled = true;
          this.txtPassword.ReadOnly = false;
          this.txtConfirm.ReadOnly = false;
          this.chkEnabled.Checked = true;
          this.chkAdmin.Checked = false;
          this.UserModules = App.DB.User.GetSecurityUserModulesDefaults();
          this.UserRegions = App.DB.User.GetUserRegionsDefaults();
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = true;
          this.btnReset.Enabled = true;
          this.grpDetails.Enabled = true;
          this.txtPassword.ReadOnly = true;
          this.txtConfirm.ReadOnly = true;
          this.PopulateDetails();
          break;
      }
      this.PageState = state;
    }

    private void PopulateDetails()
    {
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedUserDataRow["UserID"], (object) App.TheSystem.Configuration.SuperAdminID, false), (object) (App.loggedInUser.UserID != App.TheSystem.Configuration.SuperAdminID))))
      {
        int num = (int) App.ShowMessage("You may not view this data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.SetUpPageState(Enums.FormState.Load);
      }
      else
      {
        this.txtFullName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["Fullname"]));
        this.txtUserName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["UserName"]));
        this.txtPassword.Text = "**********";
        this.txtConfirm.Text = "**********";
        this.chkEnabled.Checked = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["Enabled"]));
        this.chkAdmin.Checked = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["Admin"]));
        this.chkSDV.Checked = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["SchedulerDayView"]));
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["DefaultSchedulerEngineerGroup"])))
        {
          ComboBox cboDeg = this.cboDEG;
          Combo.SetSelectedComboItem_By_Value(ref cboDeg, Conversions.ToString(this.SelectedUserDataRow["DefaultSchedulerEngineerGroup"]));
          this.cboDEG = cboDeg;
        }
        ComboBox cboDeg1 = this.cboDEG;
        Combo.SetSelectedComboItem_By_Value(ref cboDeg1, Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["DefaultSchedulerEngineerGroup"]))));
        this.cboDEG = cboDeg1;
        this.txtEmailAddress.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["EmailAddress"]));
        this.UserModules = App.DB.User.Get(Conversions.ToInteger(this.SelectedUserDataRow["UserID"]), false).SecurityUserModules;
        this.UserRegions = App.DB.User.GetUserRegions(Conversions.ToInteger(this.SelectedUserDataRow["UserID"]));
      }
    }

    private void Save()
    {
      User userAndEngineer = new User();
      userAndEngineer.IgnoreExceptionsOnSetMethods = true;
      userAndEngineer.SetFullname = (object) this.txtFullName.Text.Trim();
      userAndEngineer.SetUsername = (object) this.txtUserName.Text.Trim();
      userAndEngineer.SetPassword = (object) this.txtPassword.Text.Trim();
      userAndEngineer.SetEnabled = this.chkEnabled.Checked;
      userAndEngineer.SetAdmin = this.chkAdmin.Checked;
      userAndEngineer.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
      userAndEngineer.SetSchedulerDayView = this.chkSDV.Checked;
      userAndEngineer.SetDefaultEngineerGroup = (object) Combo.get_GetSelectedItemValue(this.cboDEG);
      if (this.PageState == Enums.FormState.Update)
        userAndEngineer.SetUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedUserDataRow["UserID"]));
      userAndEngineer.SecurityUserModules = this.UserModules;
      UserValidator userValidator = new UserValidator();
      try
      {
        userValidator.Validate(userAndEngineer);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            userAndEngineer.SetUserID = (object) App.DB.User.Insert(userAndEngineer);
            break;
          case Enums.FormState.Update:
            App.DB.User.Update(userAndEngineer);
            break;
        }
        DataTable changes = this.UserRegions.Table.GetChanges();
        if (changes != null)
        {
          string actionChange = string.Empty;
          bool flag = false;
          IEnumerator enumerator;
          try
          {
            enumerator = changes.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (flag)
                actionChange += " and ";
              actionChange = actionChange + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Name"])) + " set to " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Tick"]));
              flag = true;
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (!string.IsNullOrEmpty(actionChange))
            App.DB.User.UserAccessAudit_Insert(userAndEngineer.UserID, actionChange);
        }
        App.DB.User.UserRegions_Delete(userAndEngineer.UserID);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.UserRegions.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
              App.DB.User.UserRegions_Insert(userAndEngineer.UserID, Conversions.ToInteger(current["ManagerID"]));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this.Users = App.DB.User.GetAll();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(userValidator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetPassword()
    {
      try
      {
        if (this.SelectedUserDataRow != null)
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to reset the password for \"", this.SelectedUserDataRow["FullName"]), (object) "\"?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          App.DB.User.UpdatePassword(Conversions.ToInteger(this.SelectedUserDataRow["UserID"]), "password", true);
          int num = (int) App.ShowMessage("Password has been reset to 'password'.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.Users = App.DB.User.GetAll();
        }
        else
        {
          int num1 = (int) App.ShowMessage("Please select a user to reset password for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error resetting password : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Delete()
    {
      try
      {
        if (this.SelectedUserDataRow != null)
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to delete \"", this.SelectedUserDataRow["FullName"]), (object) "\"?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          App.DB.User.Delete(Conversions.ToInteger(this.SelectedUserDataRow["UserID"]));
          this.Users = App.DB.User.GetAll();
        }
        else
        {
          int num = (int) App.ShowMessage("Please select a user to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error deleting : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateNewSecurityModules()
    {
      try
      {
        this.Users = App.DB.User.GetAll();
        int num1 = checked (this.Users.Count - 1);
        int index1 = 0;
        while (index1 <= num1)
        {
          DataView userModulesDefaults = App.DB.User.GetSecurityUserModulesDefaults();
          int num2 = checked (userModulesDefaults.Count - 1);
          int index2 = 0;
          while (index2 <= num2)
          {
            if (App.DB.User.GetSecurityUserModules(Conversions.ToInteger(this.Users.Table.Rows[index1][0].ToString())).Table.Select(string.Format("SystemModuleID = {0}", (object) Conversions.ToInteger(userModulesDefaults.Table.Rows[index2][1].ToString()))).Length != 1)
              App.DB.User.InsertNewSecurityUserModules(Conversions.ToInteger(this.Users.Table.Rows[index1][0].ToString()), Conversions.ToInteger(userModulesDefaults.Table.Rows[index2][1].ToString()), false);
            checked { ++index2; }
          }
          checked { ++index1; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error creating security module : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void SetupUserModulesDatagrid()
    {
      Helper.SetUpDataGrid(this.dgSecurityUserModules, false);
      DataGridTableStyle tableStyle = this.dgSecurityUserModules.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgSecurityUserModules.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Module";
      dataGridLabelColumn.MappingName = "ModuleName";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 250;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Allow";
      dataGridBoolColumn.MappingName = "AccessPermitted";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 55;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSecurityUserModules.ToString();
      this.dgSecurityUserModules.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgSecurityUserModules);
    }

    public DataView UserModules
    {
      get
      {
        return this._userModules;
      }
      set
      {
        this._userModules = value;
        if (this._userModules != null)
        {
          this._userModules.Table.TableName = Enums.TableNames.tblSecurityUserModules.ToString();
          this._userModules.AllowNew = false;
          this._userModules.AllowEdit = false;
          this._userModules.AllowDelete = false;
        }
        this.dgSecurityUserModules.DataSource = (object) this._userModules;
      }
    }

    private DataRow SelectedUserModuleDataRow
    {
      get
      {
        return this.dgSecurityUserModules.CurrentRowIndex != -1 ? this.UserModules[this.dgSecurityUserModules.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView UserRegions
    {
      get
      {
        return this._userRegions;
      }
      set
      {
        this._userRegions = value;
        if (this._userRegions != null)
        {
          this._userRegions.Table.TableName = Enums.TableNames.tblRegion.ToString();
          this._userRegions.AllowNew = false;
          this._userRegions.AllowEdit = false;
          this._userRegions.AllowDelete = false;
        }
        this.dgUserRegions.DataSource = (object) this._userRegions;
      }
    }

    private DataRow SelectedUserRegionDataRow
    {
      get
      {
        return this.dgUserRegions.CurrentRowIndex != -1 ? this.UserRegions[this.dgUserRegions.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void dgSecurityUserModules_Click(object sender, EventArgs e)
    {
      if (this.SelectedUserModuleDataRow == null)
        return;
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
        throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      int index = 1;
      bool flag = !Conversions.ToBoolean(this.dgSecurityUserModules[this.dgSecurityUserModules.CurrentRowIndex, index]);
      this.dgSecurityUserModules[this.dgSecurityUserModules.CurrentRowIndex, index] = (object) flag;
    }

    private void dgUserRegions_Click(object sender, EventArgs e)
    {
      if (this.SelectedUserRegionDataRow == null)
        return;
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
        throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      this.dgUserRegions[this.dgUserRegions.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgUserRegions[this.dgUserRegions.CurrentRowIndex, 0]);
    }
  }
}
