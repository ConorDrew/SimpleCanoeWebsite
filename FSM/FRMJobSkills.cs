// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobSkills
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Skills;
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
  public class FRMJobSkills : FRMBaseForm, IForm
  {
    private IContainer components;
    private SkillType _skillType;
    private DataView _JobSkills;
    private DataView _SkillsMatrix;

    public FRMJobSkills()
    {
      this.Load += new EventHandler(this.FRMJobLocks_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJobSkills { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSkills { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboJobSkill { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobSkill { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSkillMatrix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddTypeSkill
    {
      get
      {
        return this._btnAddTypeSkill;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddTypeSkill_Click);
        Button btnAddTypeSkill1 = this._btnAddTypeSkill;
        if (btnAddTypeSkill1 != null)
          btnAddTypeSkill1.Click -= eventHandler;
        this._btnAddTypeSkill = value;
        Button btnAddTypeSkill2 = this._btnAddTypeSkill;
        if (btnAddTypeSkill2 == null)
          return;
        btnAddTypeSkill2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboTypeSkill { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTypeSkill { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSkillType
    {
      get
      {
        return this._cboSkillType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSkillType_SelectedIndexChanged);
        ComboBox cboSkillType1 = this._cboSkillType;
        if (cboSkillType1 != null)
          cboSkillType1.SelectedIndexChanged -= eventHandler;
        this._cboSkillType = value;
        ComboBox cboSkillType2 = this._cboSkillType;
        if (cboSkillType2 == null)
          return;
        cboSkillType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Button btnDeleteTypeSkill
    {
      get
      {
        return this._btnDeleteTypeSkill;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteTypeSkill_Click);
        Button btnDeleteTypeSkill1 = this._btnDeleteTypeSkill;
        if (btnDeleteTypeSkill1 != null)
          btnDeleteTypeSkill1.Click -= eventHandler;
        this._btnDeleteTypeSkill = value;
        Button btnDeleteTypeSkill2 = this._btnDeleteTypeSkill;
        if (btnDeleteTypeSkill2 == null)
          return;
        btnDeleteTypeSkill2.Click += eventHandler;
      }
    }

    internal virtual Label lblSkillType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSkillMatrix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobImportType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSkillTypeName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSkillTypeName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSkillType1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSkillType1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveSkillType
    {
      get
      {
        return this._btnSaveSkillType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveSkillType_Click);
        Button btnSaveSkillType1 = this._btnSaveSkillType;
        if (btnSaveSkillType1 != null)
          btnSaveSkillType1.Click -= eventHandler;
        this._btnSaveSkillType = value;
        Button btnSaveSkillType2 = this._btnSaveSkillType;
        if (btnSaveSkillType2 == null)
          return;
        btnSaveSkillType2.Click += eventHandler;
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobSkills = new GroupBox();
      this.btnAdd = new Button();
      this.cboJobSkill = new ComboBox();
      this.lblJobSkill = new Label();
      this.cboJobType = new ComboBox();
      this.btnDelete = new Button();
      this.lblJobType = new Label();
      this.dgSkills = new DataGrid();
      this.btnClose = new Button();
      this.grpSkillMatrix = new GroupBox();
      this.btnAddTypeSkill = new Button();
      this.cboTypeSkill = new ComboBox();
      this.lblTypeSkill = new Label();
      this.cboSkillType = new ComboBox();
      this.btnDeleteTypeSkill = new Button();
      this.lblSkillType = new Label();
      this.dgSkillMatrix = new DataGrid();
      this.grpJobImportType = new GroupBox();
      this.txtSkillTypeName = new TextBox();
      this.lblSkillTypeName = new Label();
      this.cboSkillType1 = new ComboBox();
      this.lblSkillType1 = new Label();
      this.btnSaveSkillType = new Button();
      this.grpJobSkills.SuspendLayout();
      this.dgSkills.BeginInit();
      this.grpSkillMatrix.SuspendLayout();
      this.dgSkillMatrix.BeginInit();
      this.grpJobImportType.SuspendLayout();
      this.SuspendLayout();
      this.grpJobSkills.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobSkills.Controls.Add((Control) this.btnAdd);
      this.grpJobSkills.Controls.Add((Control) this.cboJobSkill);
      this.grpJobSkills.Controls.Add((Control) this.lblJobSkill);
      this.grpJobSkills.Controls.Add((Control) this.cboJobType);
      this.grpJobSkills.Controls.Add((Control) this.btnDelete);
      this.grpJobSkills.Controls.Add((Control) this.lblJobType);
      this.grpJobSkills.Controls.Add((Control) this.dgSkills);
      this.grpJobSkills.Location = new System.Drawing.Point(8, 53);
      this.grpJobSkills.Name = "grpJobSkills";
      this.grpJobSkills.Size = new Size(1042, 321);
      this.grpJobSkills.TabIndex = 1;
      this.grpJobSkills.TabStop = false;
      this.grpJobSkills.Text = "Job Skills";
      this.btnAdd.AccessibleDescription = "Save item";
      this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.Cursor = Cursors.Hand;
      this.btnAdd.ImageIndex = 1;
      this.btnAdd.Location = new System.Drawing.Point(880, 18);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(154, 23);
      this.btnAdd.TabIndex = 33;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.cboJobSkill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboJobSkill.FormattingEnabled = true;
      this.cboJobSkill.Location = new System.Drawing.Point(333, 20);
      this.cboJobSkill.Name = "cboJobSkill";
      this.cboJobSkill.Size = new Size(541, 21);
      this.cboJobSkill.TabIndex = 32;
      this.lblJobSkill.AutoSize = true;
      this.lblJobSkill.Location = new System.Drawing.Point(296, 23);
      this.lblJobSkill.Name = "lblJobSkill";
      this.lblJobSkill.Size = new Size(31, 13);
      this.lblJobSkill.TabIndex = 31;
      this.lblJobSkill.Text = "Skill";
      this.cboJobType.FormattingEnabled = true;
      this.cboJobType.Location = new System.Drawing.Point(73, 20);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(204, 21);
      this.cboJobType.TabIndex = 3;
      this.btnDelete.AccessibleDescription = "Save item";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.ImageIndex = 1;
      this.btnDelete.Location = new System.Drawing.Point(880, 292);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(154, 23);
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.lblJobType.AutoSize = true;
      this.lblJobType.Location = new System.Drawing.Point(12, 23);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(57, 13);
      this.lblJobType.TabIndex = 2;
      this.lblJobType.Text = "Job Type";
      this.dgSkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSkills.DataMember = "";
      this.dgSkills.HeaderForeColor = SystemColors.ControlText;
      this.dgSkills.Location = new System.Drawing.Point(8, 47);
      this.dgSkills.Name = "dgSkills";
      this.dgSkills.Size = new Size(1026, 239);
      this.dgSkills.TabIndex = 1;
      this.btnClose.AccessibleDescription = "Save item";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Cursor = Cursors.Hand;
      this.btnClose.ImageIndex = 1;
      this.btnClose.Location = new System.Drawing.Point(8, 621);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.grpSkillMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSkillMatrix.Controls.Add((Control) this.btnAddTypeSkill);
      this.grpSkillMatrix.Controls.Add((Control) this.cboTypeSkill);
      this.grpSkillMatrix.Controls.Add((Control) this.lblTypeSkill);
      this.grpSkillMatrix.Controls.Add((Control) this.cboSkillType);
      this.grpSkillMatrix.Controls.Add((Control) this.btnDeleteTypeSkill);
      this.grpSkillMatrix.Controls.Add((Control) this.lblSkillType);
      this.grpSkillMatrix.Controls.Add((Control) this.dgSkillMatrix);
      this.grpSkillMatrix.Location = new System.Drawing.Point(8, 391);
      this.grpSkillMatrix.Name = "grpSkillMatrix";
      this.grpSkillMatrix.Size = new Size(741, 224);
      this.grpSkillMatrix.TabIndex = 34;
      this.grpSkillMatrix.TabStop = false;
      this.grpSkillMatrix.Text = "Skills Matrix";
      this.btnAddTypeSkill.AccessibleDescription = "Save item";
      this.btnAddTypeSkill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddTypeSkill.Cursor = Cursors.Hand;
      this.btnAddTypeSkill.ImageIndex = 1;
      this.btnAddTypeSkill.Location = new System.Drawing.Point(579, 18);
      this.btnAddTypeSkill.Name = "btnAddTypeSkill";
      this.btnAddTypeSkill.Size = new Size(154, 23);
      this.btnAddTypeSkill.TabIndex = 33;
      this.btnAddTypeSkill.Text = "Add";
      this.btnAddTypeSkill.UseVisualStyleBackColor = true;
      this.cboTypeSkill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboTypeSkill.FormattingEnabled = true;
      this.cboTypeSkill.Location = new System.Drawing.Point(333, 20);
      this.cboTypeSkill.Name = "cboTypeSkill";
      this.cboTypeSkill.Size = new Size(240, 21);
      this.cboTypeSkill.TabIndex = 32;
      this.lblTypeSkill.AutoSize = true;
      this.lblTypeSkill.Location = new System.Drawing.Point(296, 23);
      this.lblTypeSkill.Name = "lblTypeSkill";
      this.lblTypeSkill.Size = new Size(31, 13);
      this.lblTypeSkill.TabIndex = 31;
      this.lblTypeSkill.Text = "Skill";
      this.cboSkillType.FormattingEnabled = true;
      this.cboSkillType.Location = new System.Drawing.Point(73, 20);
      this.cboSkillType.Name = "cboSkillType";
      this.cboSkillType.Size = new Size(204, 21);
      this.cboSkillType.TabIndex = 3;
      this.btnDeleteTypeSkill.AccessibleDescription = "Save item";
      this.btnDeleteTypeSkill.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteTypeSkill.Cursor = Cursors.Hand;
      this.btnDeleteTypeSkill.ImageIndex = 1;
      this.btnDeleteTypeSkill.Location = new System.Drawing.Point(579, 195);
      this.btnDeleteTypeSkill.Name = "btnDeleteTypeSkill";
      this.btnDeleteTypeSkill.Size = new Size(154, 23);
      this.btnDeleteTypeSkill.TabIndex = 2;
      this.btnDeleteTypeSkill.Text = "Delete";
      this.btnDeleteTypeSkill.UseVisualStyleBackColor = true;
      this.lblSkillType.AutoSize = true;
      this.lblSkillType.Location = new System.Drawing.Point(7, 23);
      this.lblSkillType.Name = "lblSkillType";
      this.lblSkillType.Size = new Size(62, 13);
      this.lblSkillType.TabIndex = 2;
      this.lblSkillType.Text = "Skill Type";
      this.dgSkillMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSkillMatrix.DataMember = "";
      this.dgSkillMatrix.HeaderForeColor = SystemColors.ControlText;
      this.dgSkillMatrix.Location = new System.Drawing.Point(8, 47);
      this.dgSkillMatrix.Name = "dgSkillMatrix";
      this.dgSkillMatrix.Size = new Size(725, 142);
      this.dgSkillMatrix.TabIndex = 1;
      this.grpJobImportType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpJobImportType.Controls.Add((Control) this.txtSkillTypeName);
      this.grpJobImportType.Controls.Add((Control) this.lblSkillTypeName);
      this.grpJobImportType.Controls.Add((Control) this.cboSkillType1);
      this.grpJobImportType.Controls.Add((Control) this.lblSkillType1);
      this.grpJobImportType.Controls.Add((Control) this.btnSaveSkillType);
      this.grpJobImportType.Location = new System.Drawing.Point(755, 391);
      this.grpJobImportType.Name = "grpJobImportType";
      this.grpJobImportType.Size = new Size(287, 126);
      this.grpJobImportType.TabIndex = 35;
      this.grpJobImportType.TabStop = false;
      this.grpJobImportType.Text = "Skill Types";
      this.txtSkillTypeName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSkillTypeName.Location = new System.Drawing.Point(138, 60);
      this.txtSkillTypeName.MaxLength = 50;
      this.txtSkillTypeName.Name = "txtSkillTypeName";
      this.txtSkillTypeName.Size = new Size(142, 21);
      this.txtSkillTypeName.TabIndex = 18;
      this.txtSkillTypeName.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblSkillTypeName.Location = new System.Drawing.Point(11, 63);
      this.lblSkillTypeName.Name = "lblSkillTypeName";
      this.lblSkillTypeName.Size = new Size(100, 20);
      this.lblSkillTypeName.TabIndex = 17;
      this.lblSkillTypeName.Text = "Skill Type Name";
      this.cboSkillType1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSkillType1.Cursor = Cursors.Hand;
      this.cboSkillType1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSkillType1.Location = new System.Drawing.Point(138, 26);
      this.cboSkillType1.Name = "cboSkillType1";
      this.cboSkillType1.Size = new Size(142, 21);
      this.cboSkillType1.TabIndex = 16;
      this.cboSkillType1.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblSkillType1.Location = new System.Drawing.Point(11, 29);
      this.lblSkillType1.Name = "lblSkillType1";
      this.lblSkillType1.Size = new Size(118, 20);
      this.lblSkillType1.TabIndex = 15;
      this.lblSkillType1.Text = "Skill Type";
      this.btnSaveSkillType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveSkillType.Location = new System.Drawing.Point(179, 97);
      this.btnSaveSkillType.Name = "btnSaveSkillType";
      this.btnSaveSkillType.Size = new Size(101, 23);
      this.btnSaveSkillType.TabIndex = 11;
      this.btnSaveSkillType.Text = "Save";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1058, 656);
      this.Controls.Add((Control) this.grpJobImportType);
      this.Controls.Add((Control) this.grpSkillMatrix);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpJobSkills);
      this.MinimumSize = new Size(793, 520);
      this.Name = nameof (FRMJobSkills);
      this.Text = "Skills";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpJobSkills, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.grpSkillMatrix, 0);
      this.Controls.SetChildIndex((Control) this.grpJobImportType, 0);
      this.grpJobSkills.ResumeLayout(false);
      this.grpJobSkills.PerformLayout();
      this.dgSkills.EndInit();
      this.grpSkillMatrix.ResumeLayout(false);
      this.grpSkillMatrix.PerformLayout();
      this.dgSkillMatrix.EndInit();
      this.grpJobImportType.ResumeLayout(false);
      this.grpJobImportType.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
      this.SetupSkillMatrixDataGrid();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      ComboBox cboSkillType = this.cboSkillType;
      Combo.SetUpCombo(ref cboSkillType, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboSkillType = cboSkillType;
      ComboBox cboSkillType1 = this.cboSkillType1;
      Combo.SetUpCombo(ref cboSkillType1, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboSkillType1 = cboSkillType1;
      ComboBox cboJobSkill = this.cboJobSkill;
      Combo.SetUpCombo(ref cboJobSkill, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobSkill = cboJobSkill;
      this.UpdateSkillsDropDown();
      this.JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
      this.SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll();
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

    public SkillType CurrentSkillType
    {
      get
      {
        return this._skillType;
      }
      set
      {
        this._skillType = value;
        if (this.CurrentSkillType != null)
          return;
        this.CurrentSkillType = new SkillType();
        this.CurrentSkillType.Exists = false;
      }
    }

    private DataView JobSkills
    {
      get
      {
        return this._JobSkills;
      }
      set
      {
        this._JobSkills = value;
        this._JobSkills.AllowNew = false;
        this._JobSkills.AllowEdit = false;
        this._JobSkills.AllowDelete = false;
        this._JobSkills.Table.TableName = nameof (JobSkills);
        this.dgSkills.DataSource = (object) this.JobSkills;
      }
    }

    private DataView SkillsMatrix
    {
      get
      {
        return this._SkillsMatrix;
      }
      set
      {
        this._SkillsMatrix = value;
        this._SkillsMatrix.AllowNew = false;
        this._SkillsMatrix.AllowEdit = false;
        this._SkillsMatrix.AllowDelete = false;
        this._SkillsMatrix.Table.TableName = nameof (SkillsMatrix);
        this.dgSkillMatrix.DataSource = (object) this.SkillsMatrix;
      }
    }

    private DataRow SelectedJobSkillDataRow
    {
      get
      {
        return this.dgSkills.CurrentRowIndex != -1 ? this.JobSkills[this.dgSkills.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedSkillMatrixDataRow
    {
      get
      {
        return this.dgSkillMatrix.CurrentRowIndex != -1 ? this.SkillsMatrix[this.dgSkillMatrix.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSkills, false);
      DataGridTableStyle tableStyle = this.dgSkills.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "JobTypeID";
      dataGridLabelColumn1.MappingName = "JobTypeID";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 5;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "SkillID";
      dataGridLabelColumn2.MappingName = "SkillID";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 5;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Job Type";
      dataGridLabelColumn3.MappingName = "JobType";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Skill";
      dataGridLabelColumn4.MappingName = "Skill";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "JobSkills";
      this.dgSkills.TableStyles.Add(tableStyle);
    }

    private void SetupSkillMatrixDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSkillMatrix, false);
      DataGridTableStyle tableStyle = this.dgSkillMatrix.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Skill";
      dataGridLabelColumn1.MappingName = "Skill";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 400;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Skill Type";
      dataGridLabelColumn2.MappingName = "SkillType";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "SkillsMatrix";
      this.dgSkillMatrix.TableStyles.Add(tableStyle);
    }

    private void FRMJobLocks_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobSkillDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (App.EnterOverridePassword())
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.EngineerLevel.EngineerLevel_Delete_For_JobType(Conversions.ToInteger(this.SelectedJobSkillDataRow["JobTypeID"]), Conversions.ToInteger(this.SelectedJobSkillDataRow["SkillID"]));
          this.JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error unlocking job : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobSkill)) > 0.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) > 0.0))
        return;
      App.DB.EngineerLevel.EngineerLevel_Insert_For_JobType(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobSkill)));
      this.JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
    }

    private void btnSaveSkillType_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.CurrentSkillType == null)
          this.CurrentSkillType = new SkillType();
        this.CurrentSkillType.SetName = (object) this.txtSkillTypeName.Text;
        if (this.CurrentSkillType.Exists)
          App.DB.Skills.SkillType_Update(this.CurrentSkillType);
        else
          this.CurrentSkillType = App.DB.Skills.SkillType_Insert(this.CurrentSkillType);
        int num = (int) App.ShowMessage("Skill Type Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.CurrentSkillType = (SkillType) null;
        this.txtSkillTypeName.Text = string.Empty;
        this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnAddTypeSkill_Click(object sender, EventArgs e)
    {
      int skillTypeId = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboSkillType));
      int skillId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.cboTypeSkill.SelectedValue));
      if (skillTypeId == 0 || skillId == 0)
        return;
      DataView bySkill = App.DB.Skills.SkillType_Get_BySkill(skillId);
      if (bySkill.Count > 0)
      {
        int num1 = (int) App.ShowMessage(Combo.get_GetSelectedItemDescription(this.cboTypeSkill) + " is linked to " + bySkill.Table.Rows[0]["Name"].ToString() + "!\r\n\r\nPlease deleted this link", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        try
        {
          App.DB.Skills.SkillMatrix_Insert(skillId, skillTypeId);
          if (skillTypeId == 0)
            throw new Exception("Data cannot save");
          this.SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId);
          this.UpdateSkillsDropDown();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void btnDeleteTypeSkill_Click(object sender, EventArgs e)
    {
      if (this.SelectedSkillMatrixDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (App.loggedInUser.HasAccessToMulitpleModules(new List<Enums.SecuritySystemModules>()
      {
        Enums.SecuritySystemModules.IT,
        Enums.SecuritySystemModules.Compliance
      }))
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.Skills.SkillMatrix_Delete(Conversions.ToInteger(this.SelectedSkillMatrixDataRow["SkillMatrixID"]));
          ComboBox cboSkillType = this.cboSkillType;
          Combo.SetSelectedComboItem_By_Value(ref cboSkillType, "0");
          this.cboSkillType = cboSkillType;
          this.UpdateSkillsDropDown();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error deleting: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void cboSkillType_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        int skillTypeId = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboSkillType));
        if (skillTypeId > 0)
          this.SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId);
        else
          this.SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void UpdateSkillsDropDown()
    {
      this.cboTypeSkill.DataSource = (object) App.DB.Skills.Skills_GetAllNotAssignedType().Table;
      this.cboTypeSkill.DisplayMember = "Skill";
      this.cboTypeSkill.ValueMember = "SkillID";
    }
  }
}
