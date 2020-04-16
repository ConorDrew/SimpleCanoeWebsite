// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerRole
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerRoles;
using FSM.Entity.Engineers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEngineerRole : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvEngineerRole;
    private DataView _dvCurrentEngineerRoles;
    private DataView _dvEngineerInRoleList;
    private DataView _dvCurrentEngineerRoleLinks;
    private Engineer _engineer;

    public FRMEngineerRole()
    {
      this.Load += new EventHandler(this.FRMEngineerRole_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tabEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPageNewRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual NumericUpDown nudHourlyCostToCompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click_1);
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

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblHourlyCostToCompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAssignEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgrdEngineerInRoleList
    {
      get
      {
        return this._dgrdEngineerInRoleList;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgrdEngineerInRoleList_Click);
        DataGrid engineerInRoleList1 = this._dgrdEngineerInRoleList;
        if (engineerInRoleList1 != null)
          engineerInRoleList1.Click -= eventHandler;
        this._dgrdEngineerInRoleList = value;
        DataGrid engineerInRoleList2 = this._dgrdEngineerInRoleList;
        if (engineerInRoleList2 == null)
          return;
        engineerInRoleList2.Click += eventHandler;
      }
    }

    internal virtual Button btnAssign
    {
      get
      {
        return this._btnAssign;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAssign_Click);
        Button btnAssign1 = this._btnAssign;
        if (btnAssign1 != null)
          btnAssign1.Click -= eventHandler;
        this._btnAssign = value;
        Button btnAssign2 = this._btnAssign;
        if (btnAssign2 == null)
          return;
        btnAssign2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRoleId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngRoles { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGrid dgrdEngineerRoles
    {
      get
      {
        return this._dgrdEngineerRoles;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgrdEngineerRoles_Click);
        DataGrid dgrdEngineerRoles1 = this._dgrdEngineerRoles;
        if (dgrdEngineerRoles1 != null)
          dgrdEngineerRoles1.Click -= eventHandler;
        this._dgrdEngineerRoles = value;
        DataGrid dgrdEngineerRoles2 = this._dgrdEngineerRoles;
        if (dgrdEngineerRoles2 == null)
          return;
        dgrdEngineerRoles2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineersAssignedToRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUnassign
    {
      get
      {
        return this._btnUnassign;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnassign_Click);
        Button btnUnassign1 = this._btnUnassign;
        if (btnUnassign1 != null)
          btnUnassign1.Click -= eventHandler;
        this._btnUnassign = value;
        Button btnUnassign2 = this._btnUnassign;
        if (btnUnassign2 == null)
          return;
        btnUnassign2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtHourlyCostToCompany
    {
      get
      {
        return this._txtHourlyCostToCompany;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.txtHourlyCostToCompany_KeyPress);
        TextBox hourlyCostToCompany1 = this._txtHourlyCostToCompany;
        if (hourlyCostToCompany1 != null)
          hourlyCostToCompany1.KeyPress -= pressEventHandler;
        this._txtHourlyCostToCompany = value;
        TextBox hourlyCostToCompany2 = this._txtHourlyCostToCompany;
        if (hourlyCostToCompany2 == null)
          return;
        hourlyCostToCompany2.KeyPress += pressEventHandler;
      }
    }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click);
        Button btnfindEngineer1 = this._btnfindEngineer;
        if (btnfindEngineer1 != null)
          btnfindEngineer1.Click -= eventHandler;
        this._btnfindEngineer = value;
        Button btnfindEngineer2 = this._btnfindEngineer;
        if (btnfindEngineer2 == null)
          return;
        btnfindEngineer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPageAssignRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMEngineerRole));
      this.btnClose = new Button();
      this.Panel1 = new Panel();
      this.tabEngineerRole = new TabControl();
      this.tabPageNewRole = new TabPage();
      this.grpEngineerRole = new GroupBox();
      this.txtHourlyCostToCompany = new TextBox();
      this.grpEngRoles = new GroupBox();
      this.btnDelete = new Button();
      this.btnAddNew = new Button();
      this.dgrdEngineerRoles = new DataGrid();
      this.txtRoleId = new TextBox();
      this.nudHourlyCostToCompany = new NumericUpDown();
      this.txtDescription = new TextBox();
      this.lblDescription = new Label();
      this.btnSave = new Button();
      this.lblName = new Label();
      this.lblHourlyCostToCompany = new Label();
      this.txtName = new TextBox();
      this.tabPageAssignRole = new TabPage();
      this.grpAssignEngineerRole = new GroupBox();
      this.grpEngineersAssignedToRole = new GroupBox();
      this.btnUnassign = new Button();
      this.dgrdEngineerInRoleList = new DataGrid();
      this.txtEngineerId = new TextBox();
      this.txtEngineerName = new TextBox();
      this.btnAssign = new Button();
      this.cboEngineerRole = new ComboBox();
      this.lblEngRole = new Label();
      this.lblEngineer = new Label();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.Panel1.SuspendLayout();
      this.tabEngineerRole.SuspendLayout();
      this.tabPageNewRole.SuspendLayout();
      this.grpEngineerRole.SuspendLayout();
      this.grpEngRoles.SuspendLayout();
      this.dgrdEngineerRoles.BeginInit();
      this.nudHourlyCostToCompany.BeginInit();
      this.tabPageAssignRole.SuspendLayout();
      this.grpAssignEngineerRole.SuspendLayout();
      this.grpEngineersAssignedToRole.SuspendLayout();
      this.dgrdEngineerInRoleList.BeginInit();
      this.SuspendLayout();
      this.btnClose.Location = new System.Drawing.Point(8, 10);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 28);
      this.btnClose.TabIndex = 15;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.Panel1.BackColor = Color.WhiteSmoke;
      this.Panel1.Controls.Add((Control) this.btnClose);
      this.Panel1.Dock = DockStyle.Bottom;
      this.Panel1.Location = new System.Drawing.Point(0, 565);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(1462, 50);
      this.Panel1.TabIndex = 16;
      this.tabEngineerRole.Controls.Add((Control) this.tabPageNewRole);
      this.tabEngineerRole.Controls.Add((Control) this.tabPageAssignRole);
      this.tabEngineerRole.Dock = DockStyle.Fill;
      this.tabEngineerRole.Location = new System.Drawing.Point(0, 0);
      this.tabEngineerRole.Name = "tabEngineerRole";
      this.tabEngineerRole.SelectedIndex = 0;
      this.tabEngineerRole.Size = new Size(1462, 565);
      this.tabEngineerRole.TabIndex = 17;
      this.tabPageNewRole.Controls.Add((Control) this.grpEngineerRole);
      this.tabPageNewRole.Location = new System.Drawing.Point(4, 22);
      this.tabPageNewRole.Name = "tabPageNewRole";
      this.tabPageNewRole.Padding = new Padding(3);
      this.tabPageNewRole.Size = new Size(1454, 539);
      this.tabPageNewRole.TabIndex = 0;
      this.tabPageNewRole.Text = "New Engineer Role";
      this.tabPageNewRole.UseVisualStyleBackColor = true;
      this.grpEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerRole.Controls.Add((Control) this.txtHourlyCostToCompany);
      this.grpEngineerRole.Controls.Add((Control) this.grpEngRoles);
      this.grpEngineerRole.Controls.Add((Control) this.txtRoleId);
      this.grpEngineerRole.Controls.Add((Control) this.nudHourlyCostToCompany);
      this.grpEngineerRole.Controls.Add((Control) this.txtDescription);
      this.grpEngineerRole.Controls.Add((Control) this.lblDescription);
      this.grpEngineerRole.Controls.Add((Control) this.btnSave);
      this.grpEngineerRole.Controls.Add((Control) this.lblName);
      this.grpEngineerRole.Controls.Add((Control) this.lblHourlyCostToCompany);
      this.grpEngineerRole.Controls.Add((Control) this.txtName);
      this.grpEngineerRole.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpEngineerRole.Location = new System.Drawing.Point(16, 21);
      this.grpEngineerRole.Name = "grpEngineerRole";
      this.grpEngineerRole.Size = new Size(1430, 512);
      this.grpEngineerRole.TabIndex = 13;
      this.grpEngineerRole.TabStop = false;
      this.grpEngineerRole.Text = "Enter New Role Details";
      this.txtHourlyCostToCompany.Location = new System.Drawing.Point(96, 56);
      this.txtHourlyCostToCompany.Name = "txtHourlyCostToCompany";
      this.txtHourlyCostToCompany.Size = new Size(100, 21);
      this.txtHourlyCostToCompany.TabIndex = 20;
      this.grpEngRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngRoles.Controls.Add((Control) this.btnDelete);
      this.grpEngRoles.Controls.Add((Control) this.btnAddNew);
      this.grpEngRoles.Controls.Add((Control) this.dgrdEngineerRoles);
      this.grpEngRoles.Location = new System.Drawing.Point(96, 180);
      this.grpEngRoles.Name = "grpEngRoles";
      this.grpEngRoles.Size = new Size(1316, 309);
      this.grpEngRoles.TabIndex = 19;
      this.grpEngRoles.TabStop = false;
      this.grpEngRoles.Text = "Engineer Roles";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(1221, 280);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(75, 23);
      this.btnDelete.TabIndex = 21;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddNew.Location = new System.Drawing.Point(1140, 280);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(75, 23);
      this.btnAddNew.TabIndex = 20;
      this.btnAddNew.Text = "Add New";
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.dgrdEngineerRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgrdEngineerRoles.DataMember = "";
      this.dgrdEngineerRoles.HeaderForeColor = SystemColors.ControlText;
      this.dgrdEngineerRoles.Location = new System.Drawing.Point(18, 20);
      this.dgrdEngineerRoles.Name = "dgrdEngineerRoles";
      this.dgrdEngineerRoles.Size = new Size(1277, 254);
      this.dgrdEngineerRoles.TabIndex = 19;
      this.txtRoleId.Location = new System.Drawing.Point(96, 151);
      this.txtRoleId.Name = "txtRoleId";
      this.txtRoleId.Size = new Size(68, 21);
      this.txtRoleId.TabIndex = 16;
      this.txtRoleId.Visible = false;
      this.nudHourlyCostToCompany.DecimalPlaces = 2;
      this.nudHourlyCostToCompany.Location = new System.Drawing.Point(215, 56);
      this.nudHourlyCostToCompany.Maximum = new Decimal(new int[4]
      {
        999999,
        0,
        0,
        0
      });
      this.nudHourlyCostToCompany.Name = "nudHourlyCostToCompany";
      this.nudHourlyCostToCompany.Size = new Size(120, 21);
      this.nudHourlyCostToCompany.TabIndex = 6;
      this.nudHourlyCostToCompany.Visible = false;
      this.txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDescription.Location = new System.Drawing.Point(96, 83);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(1316, 62);
      this.txtDescription.TabIndex = 5;
      this.lblDescription.AutoSize = true;
      this.lblDescription.Location = new System.Drawing.Point(13, 92);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(71, 13);
      this.lblDescription.TabIndex = 4;
      this.lblDescription.Text = "Description";
      this.btnSave.AccessibleDescription = "";
      this.btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.Location = new System.Drawing.Point(1356, 151);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.lblName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblName.Location = new System.Drawing.Point(13, 32);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(80, 16);
      this.lblName.TabIndex = 1;
      this.lblName.Text = "Role Name";
      this.lblHourlyCostToCompany.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHourlyCostToCompany.Location = new System.Drawing.Point(13, 56);
      this.lblHourlyCostToCompany.Name = "lblHourlyCostToCompany";
      this.lblHourlyCostToCompany.Size = new Size(80, 29);
      this.lblHourlyCostToCompany.TabIndex = 2;
      this.lblHourlyCostToCompany.Text = "Hourly Cost To Company";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtName.Location = new System.Drawing.Point(96, 29);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(1316, 21);
      this.txtName.TabIndex = 1;
      this.tabPageAssignRole.Controls.Add((Control) this.grpAssignEngineerRole);
      this.tabPageAssignRole.Location = new System.Drawing.Point(4, 22);
      this.tabPageAssignRole.Name = "tabPageAssignRole";
      this.tabPageAssignRole.Padding = new Padding(3);
      this.tabPageAssignRole.Size = new Size(1454, 539);
      this.tabPageAssignRole.TabIndex = 1;
      this.tabPageAssignRole.Text = "Assign Engineer Role";
      this.tabPageAssignRole.UseVisualStyleBackColor = true;
      this.grpAssignEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAssignEngineerRole.BackColor = Color.White;
      this.grpAssignEngineerRole.Controls.Add((Control) this.btnfindEngineer);
      this.grpAssignEngineerRole.Controls.Add((Control) this.txtEngineer);
      this.grpAssignEngineerRole.Controls.Add((Control) this.grpEngineersAssignedToRole);
      this.grpAssignEngineerRole.Controls.Add((Control) this.txtEngineerId);
      this.grpAssignEngineerRole.Controls.Add((Control) this.txtEngineerName);
      this.grpAssignEngineerRole.Controls.Add((Control) this.btnAssign);
      this.grpAssignEngineerRole.Controls.Add((Control) this.cboEngineerRole);
      this.grpAssignEngineerRole.Controls.Add((Control) this.lblEngRole);
      this.grpAssignEngineerRole.Controls.Add((Control) this.lblEngineer);
      this.grpAssignEngineerRole.Location = new System.Drawing.Point(17, 23);
      this.grpAssignEngineerRole.Name = "grpAssignEngineerRole";
      this.grpAssignEngineerRole.Size = new Size(1421, 510);
      this.grpAssignEngineerRole.TabIndex = 15;
      this.grpAssignEngineerRole.TabStop = false;
      this.grpAssignEngineerRole.Text = "Assign Engineer Role";
      this.grpEngineersAssignedToRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineersAssignedToRole.Controls.Add((Control) this.btnUnassign);
      this.grpEngineersAssignedToRole.Controls.Add((Control) this.dgrdEngineerInRoleList);
      this.grpEngineersAssignedToRole.Location = new System.Drawing.Point(113, 112);
      this.grpEngineersAssignedToRole.Name = "grpEngineersAssignedToRole";
      this.grpEngineersAssignedToRole.Size = new Size(1281, 377);
      this.grpEngineersAssignedToRole.TabIndex = 78;
      this.grpEngineersAssignedToRole.TabStop = false;
      this.grpEngineersAssignedToRole.Text = "Engineers Assigned To Role";
      this.btnUnassign.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUnassign.Location = new System.Drawing.Point(1200, 348);
      this.btnUnassign.Name = "btnUnassign";
      this.btnUnassign.Size = new Size(75, 23);
      this.btnUnassign.TabIndex = 76;
      this.btnUnassign.Text = "Unassign";
      this.btnUnassign.UseVisualStyleBackColor = true;
      this.dgrdEngineerInRoleList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgrdEngineerInRoleList.DataMember = "";
      this.dgrdEngineerInRoleList.HeaderForeColor = SystemColors.ControlText;
      this.dgrdEngineerInRoleList.Location = new System.Drawing.Point(11, 29);
      this.dgrdEngineerInRoleList.Name = "dgrdEngineerInRoleList";
      this.dgrdEngineerInRoleList.Size = new Size(1264, 313);
      this.dgrdEngineerInRoleList.TabIndex = 75;
      this.txtEngineerId.Location = new System.Drawing.Point(113, 83);
      this.txtEngineerId.Name = "txtEngineerId";
      this.txtEngineerId.Size = new Size(100, 21);
      this.txtEngineerId.TabIndex = 77;
      this.txtEngineerId.Visible = false;
      this.txtEngineerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineerName.Location = new System.Drawing.Point(228, 83);
      this.txtEngineerName.Name = "txtEngineerName";
      this.txtEngineerName.Size = new Size(100, 21);
      this.txtEngineerName.TabIndex = 76;
      this.txtEngineerName.Text = "--Please Select--";
      this.txtEngineerName.Visible = false;
      this.btnAssign.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAssign.Location = new System.Drawing.Point(1319, 83);
      this.btnAssign.Name = "btnAssign";
      this.btnAssign.Size = new Size(75, 23);
      this.btnAssign.TabIndex = 74;
      this.btnAssign.Text = "Assign";
      this.btnAssign.UseVisualStyleBackColor = true;
      this.cboEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerRole.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerRole.FormattingEnabled = true;
      this.cboEngineerRole.Location = new System.Drawing.Point(113, 56);
      this.cboEngineerRole.Name = "cboEngineerRole";
      this.cboEngineerRole.Size = new Size(1281, 21);
      this.cboEngineerRole.TabIndex = 73;
      this.lblEngRole.AutoSize = true;
      this.lblEngRole.Location = new System.Drawing.Point(21, 58);
      this.lblEngRole.Name = "lblEngRole";
      this.lblEngRole.Size = new Size(86, 13);
      this.lblEngRole.TabIndex = 72;
      this.lblEngRole.Text = "Engineer Role";
      this.lblEngineer.AutoSize = true;
      this.lblEngineer.Location = new System.Drawing.Point(21, 35);
      this.lblEngineer.Name = "lblEngineer";
      this.lblEngineer.Size = new Size(57, 13);
      this.lblEngineer.TabIndex = 71;
      this.lblEngineer.Text = "Engineer";
      this.btnfindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(1362, 29);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 80;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(113, 29);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(1243, 21);
      this.txtEngineer.TabIndex = 79;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1462, 615);
      this.Controls.Add((Control) this.tabEngineerRole);
      this.Controls.Add((Control) this.Panel1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimumSize = new Size(0, 208);
      this.Name = nameof (FRMEngineerRole);
      this.Text = "Engineer Roles";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.Panel1, 0);
      this.Controls.SetChildIndex((Control) this.tabEngineerRole, 0);
      this.Panel1.ResumeLayout(false);
      this.tabEngineerRole.ResumeLayout(false);
      this.tabPageNewRole.ResumeLayout(false);
      this.grpEngineerRole.ResumeLayout(false);
      this.grpEngineerRole.PerformLayout();
      this.grpEngRoles.ResumeLayout(false);
      this.dgrdEngineerRoles.EndInit();
      this.nudHourlyCostToCompany.EndInit();
      this.tabPageAssignRole.ResumeLayout(false);
      this.grpAssignEngineerRole.ResumeLayout(false);
      this.grpAssignEngineerRole.PerformLayout();
      this.grpEngineersAssignedToRole.ResumeLayout(false);
      this.dgrdEngineerInRoleList.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
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

    private DataView DvEngineerRole
    {
      get
      {
        return this._dvEngineerRole;
      }
      set
      {
        this._dvEngineerRole = value;
        this._dvEngineerRole.Table.TableName = "EngineerRole";
        this.dgrdEngineerRoles.DataSource = (object) this._dvEngineerRole;
      }
    }

    public DataView CurrentEngineerRoles
    {
      get
      {
        return this._dvCurrentEngineerRoles;
      }
      set
      {
        this._dvCurrentEngineerRoles = value;
        this._dvCurrentEngineerRoles.Table.TableName = "EngineerRole";
        this._dvCurrentEngineerRoles.AllowNew = false;
        this._dvCurrentEngineerRoles.AllowEdit = false;
        this._dvCurrentEngineerRoles.AllowDelete = false;
        this.dgrdEngineerRoles.DataSource = (object) this.CurrentEngineerRoles;
      }
    }

    private DataRow SelectedEngineeRoleDataRow
    {
      get
      {
        return this.dgrdEngineerRoles.CurrentRowIndex != -1 ? this.CurrentEngineerRoles[this.dgrdEngineerRoles.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView DvEngineerInRoleList
    {
      get
      {
        return this._dvEngineerInRoleList;
      }
      set
      {
        this._dvEngineerInRoleList = value;
        this._dvEngineerInRoleList.Table.TableName = "EngineerInRoleList";
        this.dgrdEngineerInRoleList.DataSource = (object) this._dvEngineerInRoleList;
      }
    }

    public DataView CurrentEngineerRoleLinks
    {
      get
      {
        return this._dvCurrentEngineerRoleLinks;
      }
      set
      {
        this._dvCurrentEngineerRoleLinks = value;
        this._dvCurrentEngineerRoleLinks.Table.TableName = "EngineerInRoleList";
        this._dvCurrentEngineerRoleLinks.AllowNew = false;
        this._dvCurrentEngineerRoleLinks.AllowEdit = false;
        this._dvCurrentEngineerRoleLinks.AllowDelete = false;
        this.dgrdEngineerInRoleList.DataSource = (object) this.CurrentEngineerRoleLinks;
      }
    }

    private DataRow SelectedEngineerRoleLinkDataRow
    {
      get
      {
        return this.dgrdEngineerInRoleList.CurrentRowIndex != -1 ? this.CurrentEngineerRoleLinks[this.dgrdEngineerInRoleList.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Engineer Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
        if (this._engineer != null)
          this.txtEngineer.Text = this.Engineer.Name;
        else
          this.txtEngineer.Text = "<Not Set>";
      }
    }

    private void FRMEngineerRole_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupDgrdEngineerRoles();
      this.PopulateEngineerRole();
      this.SetupdgrdEngineerInRoleList();
      this.PopulateEngineerInRoleList();
    }

    private void btnSave_Click_1(object sender, EventArgs e)
    {
      if (App.ShowMessage("Are you sure you want to apply changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtRoleId.Text, string.Empty, false) == 0)
        this.SaveEngineerRole();
      else
        this.UpdateEngineerRole();
      this.btnAddNew_Click(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void dgrdEngineerRoles_Click(object sender, EventArgs e)
    {
      if (this.SelectedEngineeRoleDataRow == null)
        return;
      this.txtRoleId.Text = Conversions.ToString(this.SelectedEngineeRoleDataRow["Id"]);
      this.txtName.Text = Conversions.ToString(this.SelectedEngineeRoleDataRow["Name"]);
      this.txtHourlyCostToCompany.Text = Conversions.ToString(this.SelectedEngineeRoleDataRow["HourlyCostToCompany"]);
      this.txtDescription.Text = Conversions.ToString(this.SelectedEngineeRoleDataRow["Description"]);
    }

    private void dgrdEngineerInRoleList_Click(object sender, EventArgs e)
    {
      if (this.SelectedEngineerRoleLinkDataRow == null)
        return;
      int EngineerID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedEngineerRoleLinkDataRow["EngineerID"]));
      int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedEngineerRoleLinkDataRow["RoleId"]));
      string str = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedEngineerRoleLinkDataRow["EngineerName"]));
      App.DB.EngineerRole.GetEngineersNotAssignedToRole().Table.Merge(new DataTable()
      {
        Columns = {
          new DataColumn("EngineerID", typeof (int)),
          new DataColumn("Name", typeof (string))
        },
        Rows = {
          new object[2]{ (object) EngineerID, (object) str }
        }
      });
      ComboBox cboEngineerRole = this.cboEngineerRole;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineerRole, Conversions.ToString(num));
      this.cboEngineerRole = cboEngineerRole;
      this.Engineer = App.DB.Engineer.Engineer_Get(EngineerID);
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.txtRoleId.Text = "";
      this.txtName.Text = "";
      this.txtHourlyCostToCompany.Text = "";
      this.txtDescription.Text = "";
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedEngineeRoleDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select row to be deleted and try again.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete selected engineer role?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          int Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedEngineeRoleDataRow["Id"]));
          if (App.DB.EngineerRole.Delete(Id) > 0)
          {
            this.PopulateEngineerRole();
          }
          else
          {
            int num2 = (int) App.ShowMessage("The role you are trying to delete is assigned to engineer(s) and therefore cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void btnAssign_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Engineer == null)
        {
          int num1 = (int) App.ShowMessage("Please select an engineer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboEngineerRole));
          string Left = Combo.get_GetSelectedItemDescription(this.cboEngineerRole);
          EngineerRole engineerRoleId = App.DB.EngineerRole.GetEngineerRoleId(this.Engineer.EngineerID);
          string MessageText;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, string.Empty, false) == 0)
            MessageText = "Are you sure you want to change current role from " + engineerRoleId.Name + " to not assigned?";
          else
            MessageText = "Are you sure you want to change current role from " + engineerRoleId.Name + " to " + Left + " ?";
          if (engineerRoleId.Id > 0 && App.ShowMessage(MessageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
          if (App.DB.EngineerRole.AssignEngineerToRole(this.Engineer.EngineerID, integer))
          {
            this.PopulateEngineerInRoleList();
          }
          else
          {
            int num2 = (int) App.ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Assign role operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnUnassign_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Engineer == null)
          return;
        int engineerRoleId = 0;
        if (App.ShowMessage("Are you sure you want to change current role from " + App.DB.EngineerRole.GetEngineerRoleId(this.Engineer.EngineerID).Name + " to not assigned?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        if (App.DB.EngineerRole.AssignEngineerToRole(this.Engineer.EngineerID, engineerRoleId))
        {
          this.PopulateEngineerInRoleList();
        }
        else
        {
          int num = (int) App.ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Unssign role operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtHourlyCostToCompany_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (char.IsNumber(e.KeyChar) || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(e.KeyChar), ".", false) == 0 || char.IsControl(e.KeyChar))
        return;
      e.KeyChar = char.MinValue;
    }

    private void PopulateEngineerRole()
    {
      DataView dataView = new DataView(Helper.ToDataTable<EngineerRole>((IList<EngineerRole>) App.DB.EngineerRole.GetAll()));
      this.DvEngineerRole = dataView;
      this.CurrentEngineerRoles = dataView;
    }

    private void PopulateEngineerInRoleList()
    {
      this.Engineer = (Engineer) null;
      ComboBox cboEngineerRole = this.cboEngineerRole;
      Combo.SetUpCombo(ref cboEngineerRole, App.DB.EngineerRole.GetLookupData().Table, "Id", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineerRole = cboEngineerRole;
      DataView dataView = new DataView(Helper.ToDataTable<EngineerAssignedToRole>((IList<EngineerAssignedToRole>) App.DB.EngineerRole.GetEngineersAssignedToRole()));
      this.DvEngineerInRoleList = dataView;
      this.CurrentEngineerRoleLinks = dataView;
    }

    public void SaveEngineerRole()
    {
      try
      {
        EngineerRole engineerRole = App.DB.EngineerRole.Insert(new EngineerRole()
        {
          Name = this.txtName.Text.Trim(),
          HourlyCostToCompany = new Decimal(Helper.MakeDoubleValid((object) new Decimal(Conversion.Val(this.txtHourlyCostToCompany.Text)))),
          Description = this.txtDescription.Text.Trim()
        });
        if (engineerRole.Id > 0)
        {
          this.PopulateEngineerRole();
          this.PopulateEngineerInRoleList();
        }
        else
        {
          int num = (int) App.ShowMessage("Role " + engineerRole.Name + " exists already. Please select role to edit.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void UpdateEngineerRole()
    {
      try
      {
        EngineerRole engineerRole = new EngineerRole();
        engineerRole.Id = Conversions.ToInteger(this.txtRoleId.Text.Trim());
        engineerRole.Name = this.txtName.Text.Trim();
        engineerRole.HourlyCostToCompany = new Decimal(Helper.MakeDoubleValid((object) this.txtHourlyCostToCompany.Text));
        engineerRole.Description = this.txtDescription.Text.Trim();
        if (App.DB.EngineerRole.Update(engineerRole) == engineerRole.Id)
        {
          this.PopulateEngineerRole();
        }
        else
        {
          int num = (int) App.ShowMessage("The operation failed. Please try again later!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void SetupDgrdEngineerRoles()
    {
      Helper.SetUpDataGrid(this.dgrdEngineerRoles, false);
      DataGridTableStyle tableStyle = this.dgrdEngineerRoles.TableStyles[0];
      DataGridJobTypeColumn gridJobTypeColumn1 = new DataGridJobTypeColumn();
      gridJobTypeColumn1.Format = "";
      gridJobTypeColumn1.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn1.HeaderText = "Role Id";
      gridJobTypeColumn1.MappingName = "Id";
      gridJobTypeColumn1.ReadOnly = true;
      gridJobTypeColumn1.Width = 0;
      gridJobTypeColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn1);
      DataGridJobTypeColumn gridJobTypeColumn2 = new DataGridJobTypeColumn();
      gridJobTypeColumn2.Format = "";
      gridJobTypeColumn2.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn2.HeaderText = "Role Name";
      gridJobTypeColumn2.MappingName = "Name";
      gridJobTypeColumn2.ReadOnly = true;
      gridJobTypeColumn2.Width = 300;
      gridJobTypeColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn2);
      DataGridJobTypeColumn gridJobTypeColumn3 = new DataGridJobTypeColumn();
      gridJobTypeColumn3.Format = "C";
      gridJobTypeColumn3.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn3.HeaderText = "Hourly Cost To Company";
      gridJobTypeColumn3.MappingName = "HourlyCostToCompany";
      gridJobTypeColumn3.ReadOnly = true;
      gridJobTypeColumn3.Width = 150;
      gridJobTypeColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn3);
      DataGridJobTypeColumn gridJobTypeColumn4 = new DataGridJobTypeColumn();
      gridJobTypeColumn4.Format = "";
      gridJobTypeColumn4.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn4.HeaderText = "Description";
      gridJobTypeColumn4.MappingName = "Description";
      gridJobTypeColumn4.ReadOnly = true;
      gridJobTypeColumn4.Width = 600;
      gridJobTypeColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "EngineerRole";
      this.dgrdEngineerRoles.TableStyles.Add(tableStyle);
    }

    private void SetupdgrdEngineerInRoleList()
    {
      Helper.SetUpDataGrid(this.dgrdEngineerInRoleList, false);
      DataGridTableStyle tableStyle = this.dgrdEngineerInRoleList.TableStyles[0];
      DataGridJobTypeColumn gridJobTypeColumn1 = new DataGridJobTypeColumn();
      gridJobTypeColumn1.Format = "";
      gridJobTypeColumn1.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn1.HeaderText = "Engineer ID";
      gridJobTypeColumn1.MappingName = "EngineerID";
      gridJobTypeColumn1.ReadOnly = true;
      gridJobTypeColumn1.Width = 1;
      gridJobTypeColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn1);
      DataGridJobTypeColumn gridJobTypeColumn2 = new DataGridJobTypeColumn();
      gridJobTypeColumn2.Format = "";
      gridJobTypeColumn2.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn2.HeaderText = "Role Id";
      gridJobTypeColumn2.MappingName = "RoleId";
      gridJobTypeColumn2.ReadOnly = true;
      gridJobTypeColumn2.Width = 1;
      gridJobTypeColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn2);
      DataGridJobTypeColumn gridJobTypeColumn3 = new DataGridJobTypeColumn();
      gridJobTypeColumn3.Format = "";
      gridJobTypeColumn3.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn3.HeaderText = "Engineer Name";
      gridJobTypeColumn3.MappingName = "EngineerName";
      gridJobTypeColumn3.ReadOnly = true;
      gridJobTypeColumn3.Width = 160;
      gridJobTypeColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn3);
      DataGridJobTypeColumn gridJobTypeColumn4 = new DataGridJobTypeColumn();
      gridJobTypeColumn4.Format = "";
      gridJobTypeColumn4.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn4.HeaderText = "Role Name";
      gridJobTypeColumn4.MappingName = "EngineerRole";
      gridJobTypeColumn4.ReadOnly = true;
      gridJobTypeColumn4.Width = 160;
      gridJobTypeColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn4);
      DataGridJobTypeColumn gridJobTypeColumn5 = new DataGridJobTypeColumn();
      gridJobTypeColumn5.Format = "";
      gridJobTypeColumn5.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn5.HeaderText = "Description";
      gridJobTypeColumn5.MappingName = "Description";
      gridJobTypeColumn5.ReadOnly = true;
      gridJobTypeColumn5.Width = 600;
      gridJobTypeColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "EngineerInRoleList";
      this.dgrdEngineerInRoleList.TableStyles.Add(tableStyle);
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      this.FindEngineer();
    }

    private void FindEngineer()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineerRole, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Engineer = App.DB.Engineer.Engineer_Get(integer);
    }
  }
}
