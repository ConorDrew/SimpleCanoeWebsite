// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerRolesDeleteMe
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerRoles;
using FSM.Entity.Sys;
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
  [DesignerGenerated]
  public class FRMEngineerRolesDeleteMe
  {
    private IContainer components;
    private DataView _dvEngineerRole;

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tabEngineerRole = new TabControl();
      this.tabPgCreateEngineerRole = new TabPage();
      this.txtHourlyCostToCompany = new TextBox();
      this.txtName = new TextBox();
      this.lblHrlyCostToCompany = new Label();
      this.lblName = new Label();
      this.tabPgAssignEngineerRole = new TabPage();
      this.lblDescription = new Label();
      this.txtDescription = new TextBox();
      this.cmdSave = new Button();
      this.lblEngineerName = new Label();
      this.lblRoleToAssign = new Label();
      this.cboEngineer = new ComboBox();
      this.cboRoleToAssign = new ComboBox();
      this.cmdApply = new Button();
      this.dgrdEngineerRoles = new DataGrid();
      this.tabEngineerRole.SuspendLayout();
      this.tabPgCreateEngineerRole.SuspendLayout();
      this.tabPgAssignEngineerRole.SuspendLayout();
      this.dgrdEngineerRoles.BeginInit();
      this.tabEngineerRole.Controls.Add((Control) this.tabPgCreateEngineerRole);
      this.tabEngineerRole.Controls.Add((Control) this.tabPgAssignEngineerRole);
      this.tabEngineerRole.Location = new System.Drawing.Point(12, 12);
      this.tabEngineerRole.Name = "tabEngineerRole";
      this.tabEngineerRole.SelectedIndex = 0;
      this.tabEngineerRole.Size = new Size(691, 547);
      this.tabEngineerRole.TabIndex = 0;
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.dgrdEngineerRoles);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.cmdSave);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.txtDescription);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.lblDescription);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.txtHourlyCostToCompany);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.txtName);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.lblHrlyCostToCompany);
      this.tabPgCreateEngineerRole.Controls.Add((Control) this.lblName);
      this.tabPgCreateEngineerRole.Location = new System.Drawing.Point(4, 22);
      this.tabPgCreateEngineerRole.Name = "tabPgCreateEngineerRole";
      this.tabPgCreateEngineerRole.Padding = new Padding(3);
      this.tabPgCreateEngineerRole.Size = new Size(683, 521);
      this.tabPgCreateEngineerRole.TabIndex = 0;
      this.tabPgCreateEngineerRole.Text = "Create Engineer Role";
      this.tabPgCreateEngineerRole.UseVisualStyleBackColor = true;
      this.txtHourlyCostToCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtHourlyCostToCompany.Location = new System.Drawing.Point(92, 52);
      this.txtHourlyCostToCompany.Name = "txtHourlyCostToCompany";
      this.txtHourlyCostToCompany.Size = new Size(162, 20);
      this.txtHourlyCostToCompany.TabIndex = 4;
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(92, 26);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(494, 20);
      this.txtName.TabIndex = 3;
      this.lblHrlyCostToCompany.AutoSize = true;
      this.lblHrlyCostToCompany.Location = new System.Drawing.Point(22, 56);
      this.lblHrlyCostToCompany.Name = "lblHrlyCostToCompany";
      this.lblHrlyCostToCompany.Size = new Size(61, 13);
      this.lblHrlyCostToCompany.TabIndex = 1;
      this.lblHrlyCostToCompany.Text = "Hourly Cost";
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(22, 29);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(60, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Role Name";
      this.tabPgAssignEngineerRole.Controls.Add((Control) this.cmdApply);
      this.tabPgAssignEngineerRole.Controls.Add((Control) this.cboRoleToAssign);
      this.tabPgAssignEngineerRole.Controls.Add((Control) this.cboEngineer);
      this.tabPgAssignEngineerRole.Controls.Add((Control) this.lblRoleToAssign);
      this.tabPgAssignEngineerRole.Controls.Add((Control) this.lblEngineerName);
      this.tabPgAssignEngineerRole.Location = new System.Drawing.Point(4, 22);
      this.tabPgAssignEngineerRole.Name = "tabPgAssignEngineerRole";
      this.tabPgAssignEngineerRole.Padding = new Padding(3);
      this.tabPgAssignEngineerRole.Size = new Size(683, 521);
      this.tabPgAssignEngineerRole.TabIndex = 1;
      this.tabPgAssignEngineerRole.Text = "Assign Engineer Role";
      this.tabPgAssignEngineerRole.UseVisualStyleBackColor = true;
      this.lblDescription.AutoSize = true;
      this.lblDescription.Location = new System.Drawing.Point(22, 78);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(60, 13);
      this.lblDescription.TabIndex = 5;
      this.lblDescription.Text = "Description";
      this.txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDescription.Location = new System.Drawing.Point(91, 78);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(495, 88);
      this.txtDescription.TabIndex = 6;
      this.cmdSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cmdSave.Location = new System.Drawing.Point(600, 143);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new Size(67, 23);
      this.cmdSave.TabIndex = 7;
      this.cmdSave.Text = "Save";
      this.cmdSave.UseVisualStyleBackColor = true;
      this.lblEngineerName.AutoSize = true;
      this.lblEngineerName.Location = new System.Drawing.Point(28, 25);
      this.lblEngineerName.Name = "lblEngineerName";
      this.lblEngineerName.Size = new Size(80, 13);
      this.lblEngineerName.TabIndex = 0;
      this.lblEngineerName.Text = "Engineer Name";
      this.lblRoleToAssign.AutoSize = true;
      this.lblRoleToAssign.Location = new System.Drawing.Point(31, 55);
      this.lblRoleToAssign.Name = "lblRoleToAssign";
      this.lblRoleToAssign.Size = new Size(79, 13);
      this.lblRoleToAssign.TabIndex = 1;
      this.lblRoleToAssign.Text = "Role To Assign";
      this.cboEngineer.FormattingEnabled = true;
      this.cboEngineer.Location = new System.Drawing.Point(110, 25);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(302, 21);
      this.cboEngineer.TabIndex = 2;
      this.cboRoleToAssign.FormattingEnabled = true;
      this.cboRoleToAssign.Location = new System.Drawing.Point(110, 55);
      this.cboRoleToAssign.Name = "cboRoleToAssign";
      this.cboRoleToAssign.Size = new Size(302, 21);
      this.cboRoleToAssign.TabIndex = 3;
      this.cmdApply.Location = new System.Drawing.Point(337, 82);
      this.cmdApply.Name = "cmdApply";
      this.cmdApply.Size = new Size(75, 23);
      this.cmdApply.TabIndex = 4;
      this.cmdApply.Text = "Apply";
      this.cmdApply.UseVisualStyleBackColor = true;
      this.dgrdEngineerRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgrdEngineerRoles.DataMember = "";
      this.dgrdEngineerRoles.HeaderForeColor = SystemColors.ControlText;
      this.dgrdEngineerRoles.Location = new System.Drawing.Point(25, 185);
      this.dgrdEngineerRoles.Name = "dgrdEngineerRoles";
      this.dgrdEngineerRoles.Size = new Size(642, 316);
      this.dgrdEngineerRoles.TabIndex = 9;
    }

    internal virtual TabControl tabEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPgCreateEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblHrlyCostToCompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPgAssignEngineerRole { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHourlyCostToCompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button cmdSave
    {
      get
      {
        return this._cmdSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdSave_Click);
        Button cmdSave1 = this._cmdSave;
        if (cmdSave1 != null)
          cmdSave1.Click -= eventHandler;
        this._cmdSave = value;
        Button cmdSave2 = this._cmdSave;
        if (cmdSave2 == null)
          return;
        cmdSave2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button cmdApply { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRoleToAssign { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRoleToAssign { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgrdEngineerRoles { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public FRMEngineerRolesDeleteMe()
    {
      this.InitializeComponent();
      this.PopulateEngineerRole();
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

    private void PopulateEngineerRole()
    {
      this.SetupDgrdEngineerRoles();
      this.DvEngineerRole = new DataView(Helper.ToDataTable<EngineerRole>((IList<EngineerRole>) App.DB.EngineerRole.GetAll()));
    }

    public void SaveEngineerRole()
    {
      try
      {
        if (App.DB.EngineerRole.Insert(new EngineerRole()
        {
          Name = this.txtName.ToString().Trim(),
          HourlyCostToCompany = new Decimal(Helper.MakeDoubleValid((object) this.txtHourlyCostToCompany)),
          Description = this.txtDescription.ToString().Trim()
        }).Id > 0)
        {
          this.PopulateEngineerRole();
        }
        else
        {
          int num = (int) App.ShowMessage("The operation failed. Please change name and try again!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The operation. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
      gridJobTypeColumn1.HeaderText = "Role Name";
      gridJobTypeColumn1.MappingName = "Name";
      gridJobTypeColumn1.ReadOnly = true;
      gridJobTypeColumn1.Width = 145;
      gridJobTypeColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn1);
      DataGridJobTypeColumn gridJobTypeColumn2 = new DataGridJobTypeColumn();
      gridJobTypeColumn2.Format = "";
      gridJobTypeColumn2.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn2.HeaderText = "Hourly Cost";
      gridJobTypeColumn2.MappingName = "HourlyCostToCompany";
      gridJobTypeColumn2.ReadOnly = true;
      gridJobTypeColumn2.Width = 100;
      gridJobTypeColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn2);
      DataGridJobTypeColumn gridJobTypeColumn3 = new DataGridJobTypeColumn();
      gridJobTypeColumn3.Format = "";
      gridJobTypeColumn3.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn3.HeaderText = "Description";
      gridJobTypeColumn3.MappingName = "Desctription";
      gridJobTypeColumn3.ReadOnly = true;
      gridJobTypeColumn3.Width = 100;
      gridJobTypeColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "EngineerRole";
      this.dgrdEngineerRoles.TableStyles.Add(tableStyle);
    }

    private void cmdSave_Click(object sender, EventArgs e)
    {
    }
  }
}
