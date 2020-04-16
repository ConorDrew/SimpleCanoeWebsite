// Decompiled with JetBrains decompiler
// Type: FSM.UCSystemScheduleOfRate
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.JobImport;
using FSM.Entity.PickLists;
using FSM.Entity.Sys;
using FSM.Entity.SystemScheduleOfRates;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCSystemScheduleOfRate : UCBase, IUserControl
  {
    private IContainer components;
    private DataView _dvRates;
    private DataView _dvEngineerQuals;
    private SystemScheduleOfRate _engineerQualSOR;
    private PickList _engineerQual;
    private Enums.FormState _pageState;
    private JobImportType _currentJobImportType;
    private SystemScheduleOfRate _currentSystemScheduleOfRate;

    public UCSystemScheduleOfRate()
    {
      this.Load += new EventHandler(this.UCSystemScheduleOfRate_Load);
      this._currentSystemScheduleOfRate = new SystemScheduleOfRate();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSystemScheduleOfRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgRates
    {
      get
      {
        return this._dgRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgRates_Click);
        DataGrid dgRates1 = this._dgRates;
        if (dgRates1 != null)
          dgRates1.Click -= eventHandler;
        this._dgRates = value;
        DataGrid dgRates2 = this._dgRates;
        if (dgRates2 == null)
          return;
        dgRates2.Click += eventHandler;
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

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtTimeInMins { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobImportType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnRemoveType
    {
      get
      {
        return this._btnRemoveType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveType_Click);
        Button btnRemoveType1 = this._btnRemoveType;
        if (btnRemoveType1 != null)
          btnRemoveType1.Click -= eventHandler;
        this._btnRemoveType = value;
        Button btnRemoveType2 = this._btnRemoveType;
        if (btnRemoveType2 == null)
          return;
        btnRemoveType2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboJobImportType
    {
      get
      {
        return this._cboJobImportType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboJobImportType_SelectedIndexChanged);
        ComboBox cboJobImportType1 = this._cboJobImportType;
        if (cboJobImportType1 != null)
          cboJobImportType1.SelectedIndexChanged -= eventHandler;
        this._cboJobImportType = value;
        ComboBox cboJobImportType2 = this._cboJobImportType;
        if (cboJobImportType2 == null)
          return;
        cboJobImportType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblJobImportType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobTypeName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobTypeName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddNewType
    {
      get
      {
        return this._btnAddNewType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNewType_Click);
        Button btnAddNewType1 = this._btnAddNewType;
        if (btnAddNewType1 != null)
          btnAddNewType1.Click -= eventHandler;
        this._btnAddNewType = value;
        Button btnAddNewType2 = this._btnAddNewType;
        if (btnAddNewType2 == null)
          return;
        btnAddNewType2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCycle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCycle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSORJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineerSkillSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSORName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveEngineerQual
    {
      get
      {
        return this._btnSaveEngineerQual;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveEngineerQual_Click);
        Button saveEngineerQual1 = this._btnSaveEngineerQual;
        if (saveEngineerQual1 != null)
          saveEngineerQual1.Click -= eventHandler;
        this._btnSaveEngineerQual = value;
        Button saveEngineerQual2 = this._btnSaveEngineerQual;
        if (saveEngineerQual2 == null)
          return;
        saveEngineerQual2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineerSkills { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineerQual
    {
      get
      {
        return this._dgEngineerQual;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgEngineerQual_Click);
        DataGrid dgEngineerQual1 = this._dgEngineerQual;
        if (dgEngineerQual1 != null)
          dgEngineerQual1.Click -= eventHandler;
        this._dgEngineerQual = value;
        DataGrid dgEngineerQual2 = this._dgEngineerQual;
        if (dgEngineerQual2 == null)
          return;
        dgEngineerQual2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindSOR
    {
      get
      {
        return this._btnFindSOR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSOR_Click);
        Button btnFindSor1 = this._btnFindSOR;
        if (btnFindSor1 != null)
          btnFindSor1.Click -= eventHandler;
        this._btnFindSOR = value;
        Button btnFindSor2 = this._btnFindSOR;
        if (btnFindSor2 == null)
          return;
        btnFindSor2.Click += eventHandler;
      }
    }

    internal virtual Button btnClearAll
    {
      get
      {
        return this._btnClearAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearAll_Click);
        Button btnClearAll1 = this._btnClearAll;
        if (btnClearAll1 != null)
          btnClearAll1.Click -= eventHandler;
        this._btnClearAll = value;
        Button btnClearAll2 = this._btnClearAll;
        if (btnClearAll2 == null)
          return;
        btnClearAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindEngineerQual
    {
      get
      {
        return this._btnFindEngineerQual;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindEngineerQual_Click);
        Button findEngineerQual1 = this._btnFindEngineerQual;
        if (findEngineerQual1 != null)
          findEngineerQual1.Click -= eventHandler;
        this._btnFindEngineerQual = value;
        Button findEngineerQual2 = this._btnFindEngineerQual;
        if (findEngineerQual2 == null)
          return;
        findEngineerQual2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineerQual { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerQual { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddUpdate
    {
      get
      {
        return this._btnAddUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddUpdate_Click);
        Button btnAddUpdate1 = this._btnAddUpdate;
        if (btnAddUpdate1 != null)
          btnAddUpdate1.Click -= eventHandler;
        this._btnAddUpdate = value;
        Button btnAddUpdate2 = this._btnAddUpdate;
        if (btnAddUpdate2 == null)
          return;
        btnAddUpdate2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSystemScheduleOfRate = new GroupBox();
      this.cboSORJobType = new ComboBox();
      this.Label9 = new Label();
      this.grpSOR = new GroupBox();
      this.dgRates = new DataGrid();
      this.btnAddNew = new Button();
      this.btnRemove = new Button();
      this.txtTimeInMins = new TextBox();
      this.lblTime = new Label();
      this.btnAddUpdate = new Button();
      this.cboScheduleOfRatesCategoryID = new ComboBox();
      this.lblScheduleOfRatesCategoryID = new Label();
      this.txtCode = new TextBox();
      this.lblCode = new Label();
      this.txtDescription = new TextBox();
      this.lblDescription = new Label();
      this.txtPrice = new TextBox();
      this.lblPrice = new Label();
      this.grpJobImportType = new GroupBox();
      this.btnFindEngineerQual = new Button();
      this.txtEngineerQual = new TextBox();
      this.lblEngineerQual = new Label();
      this.txtCycle = new TextBox();
      this.lblCycle = new Label();
      this.btnAddNewType = new Button();
      this.cboJobType = new ComboBox();
      this.lblJobType = new Label();
      this.txtJobTypeName = new TextBox();
      this.lblJobTypeName = new Label();
      this.cboJobImportType = new ComboBox();
      this.lblJobImportType = new Label();
      this.btnSave = new Button();
      this.btnRemoveType = new Button();
      this.grpEngineerSkillSOR = new GroupBox();
      this.btnClearAll = new Button();
      this.grpEngineerSkills = new GroupBox();
      this.dgEngineerQual = new DataGrid();
      this.btnFindSOR = new Button();
      this.txtSOR = new TextBox();
      this.lblSORName = new Label();
      this.btnSaveEngineerQual = new Button();
      this.grpSystemScheduleOfRate.SuspendLayout();
      this.grpSOR.SuspendLayout();
      this.dgRates.BeginInit();
      this.grpJobImportType.SuspendLayout();
      this.grpEngineerSkillSOR.SuspendLayout();
      this.grpEngineerSkills.SuspendLayout();
      this.dgEngineerQual.BeginInit();
      this.SuspendLayout();
      this.grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.cboSORJobType);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label9);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.grpSOR);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnAddNew);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnRemove);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtTimeInMins);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblTime);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnAddUpdate);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.cboScheduleOfRatesCategoryID);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblScheduleOfRatesCategoryID);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtCode);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblCode);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtDescription);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblDescription);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtPrice);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblPrice);
      this.grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 8);
      this.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
      this.grpSystemScheduleOfRate.Size = new Size(746, 713);
      this.grpSystemScheduleOfRate.TabIndex = 0;
      this.grpSystemScheduleOfRate.TabStop = false;
      this.grpSystemScheduleOfRate.Text = "Main Details";
      this.cboSORJobType.Cursor = Cursors.Hand;
      this.cboSORJobType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSORJobType.Location = new System.Drawing.Point(194, 59);
      this.cboSORJobType.Name = "cboSORJobType";
      this.cboSORJobType.Size = new Size(540, 21);
      this.cboSORJobType.TabIndex = 27;
      this.cboSORJobType.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.Label9.Location = new System.Drawing.Point(11, 59);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(118, 20);
      this.Label9.TabIndex = 26;
      this.Label9.Text = "Job Type";
      this.grpSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSOR.Controls.Add((Control) this.dgRates);
      this.grpSOR.Location = new System.Drawing.Point(14, 259);
      this.grpSOR.Name = "grpSOR";
      this.grpSOR.Size = new Size(720, 409);
      this.grpSOR.TabIndex = 14;
      this.grpSOR.TabStop = false;
      this.grpSOR.Text = "Schedule of Rates";
      this.dgRates.DataMember = "";
      this.dgRates.Dock = DockStyle.Fill;
      this.dgRates.HeaderForeColor = SystemColors.ControlText;
      this.dgRates.Location = new System.Drawing.Point(3, 17);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(714, 389);
      this.dgRates.TabIndex = 13;
      this.btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddNew.Location = new System.Drawing.Point(14, 674);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(101, 23);
      this.btnAddNew.TabIndex = 11;
      this.btnAddNew.Text = "Add New";
      this.btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemove.Location = new System.Drawing.Point(633, 674);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(101, 23);
      this.btnRemove.TabIndex = 12;
      this.btnRemove.Text = "Remove";
      this.txtTimeInMins.Location = new System.Drawing.Point(512, 96);
      this.txtTimeInMins.MaxLength = 9;
      this.txtTimeInMins.Name = "txtTimeInMins";
      this.txtTimeInMins.Size = new Size(103, 21);
      this.txtTimeInMins.TabIndex = 7;
      this.txtTimeInMins.Tag = (object) "SystemScheduleOfRate.Price";
      this.lblTime.Location = new System.Drawing.Point(428, 99);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new Size(78, 20);
      this.lblTime.TabIndex = 6;
      this.lblTime.Text = "Time (Mins)";
      this.btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddUpdate.Location = new System.Drawing.Point(633, 232);
      this.btnAddUpdate.Name = "btnAddUpdate";
      this.btnAddUpdate.Size = new Size(101, 23);
      this.btnAddUpdate.TabIndex = 10;
      this.btnAddUpdate.Text = "Add/Update";
      this.cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
      this.cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScheduleOfRatesCategoryID.Location = new System.Drawing.Point(194, 25);
      this.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
      this.cboScheduleOfRatesCategoryID.Size = new Size(540, 21);
      this.cboScheduleOfRatesCategoryID.TabIndex = 1;
      this.cboScheduleOfRatesCategoryID.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Location = new System.Drawing.Point(11, 25);
      this.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
      this.lblScheduleOfRatesCategoryID.TabIndex = 0;
      this.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
      this.txtCode.Location = new System.Drawing.Point(279, 96);
      this.txtCode.MaxLength = 50;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new Size(131, 21);
      this.txtCode.TabIndex = 3;
      this.txtCode.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblCode.Location = new System.Drawing.Point(231, 99);
      this.lblCode.Name = "lblCode";
      this.lblCode.Size = new Size(42, 20);
      this.lblCode.TabIndex = 2;
      this.lblCode.Text = "Code";
      this.txtDescription.Location = new System.Drawing.Point(95, 145);
      this.txtDescription.MaxLength = 0;
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(639, 79);
      this.txtDescription.TabIndex = 5;
      this.txtDescription.Tag = (object) "SystemScheduleOfRate.Description";
      this.lblDescription.Location = new System.Drawing.Point(12, 145);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(77, 20);
      this.lblDescription.TabIndex = 4;
      this.lblDescription.Text = "Description";
      this.txtPrice.Location = new System.Drawing.Point(59, 96);
      this.txtPrice.MaxLength = 9;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(131, 21);
      this.txtPrice.TabIndex = 9;
      this.txtPrice.Tag = (object) "SystemScheduleOfRate.Price";
      this.lblPrice.Location = new System.Drawing.Point(11, 99);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new Size(42, 20);
      this.lblPrice.TabIndex = 8;
      this.lblPrice.Text = "Price";
      this.grpJobImportType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobImportType.Controls.Add((Control) this.btnFindEngineerQual);
      this.grpJobImportType.Controls.Add((Control) this.txtEngineerQual);
      this.grpJobImportType.Controls.Add((Control) this.lblEngineerQual);
      this.grpJobImportType.Controls.Add((Control) this.txtCycle);
      this.grpJobImportType.Controls.Add((Control) this.lblCycle);
      this.grpJobImportType.Controls.Add((Control) this.btnAddNewType);
      this.grpJobImportType.Controls.Add((Control) this.cboJobType);
      this.grpJobImportType.Controls.Add((Control) this.lblJobType);
      this.grpJobImportType.Controls.Add((Control) this.txtJobTypeName);
      this.grpJobImportType.Controls.Add((Control) this.lblJobTypeName);
      this.grpJobImportType.Controls.Add((Control) this.cboJobImportType);
      this.grpJobImportType.Controls.Add((Control) this.lblJobImportType);
      this.grpJobImportType.Controls.Add((Control) this.btnSave);
      this.grpJobImportType.Controls.Add((Control) this.btnRemoveType);
      this.grpJobImportType.Location = new System.Drawing.Point(760, 472);
      this.grpJobImportType.Name = "grpJobImportType";
      this.grpJobImportType.Size = new Size(375, 249);
      this.grpJobImportType.TabIndex = 15;
      this.grpJobImportType.TabStop = false;
      this.grpJobImportType.Text = "Job Import Types";
      this.btnFindEngineerQual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindEngineerQual.BackColor = Color.White;
      this.btnFindEngineerQual.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindEngineerQual.Location = new System.Drawing.Point(336, 126);
      this.btnFindEngineerQual.Name = "btnFindEngineerQual";
      this.btnFindEngineerQual.Size = new Size(32, 23);
      this.btnFindEngineerQual.TabIndex = 41;
      this.btnFindEngineerQual.Text = "...";
      this.btnFindEngineerQual.UseVisualStyleBackColor = false;
      this.txtEngineerQual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineerQual.Location = new System.Drawing.Point(138, 128);
      this.txtEngineerQual.MaxLength = 50;
      this.txtEngineerQual.Name = "txtEngineerQual";
      this.txtEngineerQual.ReadOnly = true;
      this.txtEngineerQual.Size = new Size(183, 21);
      this.txtEngineerQual.TabIndex = 40;
      this.txtEngineerQual.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblEngineerQual.Location = new System.Drawing.Point(11, 131);
      this.lblEngineerQual.Name = "lblEngineerQual";
      this.lblEngineerQual.Size = new Size(163, 20);
      this.lblEngineerQual.TabIndex = 39;
      this.lblEngineerQual.Text = "Engineer Qual";
      this.txtCycle.Location = new System.Drawing.Point(139, 162);
      this.txtCycle.MaxLength = 50;
      this.txtCycle.Name = "txtCycle";
      this.txtCycle.Size = new Size(230, 21);
      this.txtCycle.TabIndex = 25;
      this.txtCycle.Tag = (object) "";
      this.lblCycle.Location = new System.Drawing.Point(11, 165);
      this.lblCycle.Name = "lblCycle";
      this.lblCycle.Size = new Size(100, 20);
      this.lblCycle.TabIndex = 24;
      this.lblCycle.Text = "Cycle (Yrs)";
      this.btnAddNewType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddNewType.Location = new System.Drawing.Point(152, 210);
      this.btnAddNewType.Name = "btnAddNewType";
      this.btnAddNewType.Size = new Size(101, 23);
      this.btnAddNewType.TabIndex = 23;
      this.btnAddNewType.Text = "Add New";
      this.cboJobType.Cursor = Cursors.Hand;
      this.cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJobType.Location = new System.Drawing.Point(138, 94);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(230, 21);
      this.cboJobType.TabIndex = 22;
      this.cboJobType.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblJobType.Location = new System.Drawing.Point(11, 97);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(118, 20);
      this.lblJobType.TabIndex = 21;
      this.lblJobType.Text = "Job Type";
      this.txtJobTypeName.Location = new System.Drawing.Point(138, 60);
      this.txtJobTypeName.MaxLength = 50;
      this.txtJobTypeName.Name = "txtJobTypeName";
      this.txtJobTypeName.Size = new Size(230, 21);
      this.txtJobTypeName.TabIndex = 18;
      this.txtJobTypeName.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblJobTypeName.Location = new System.Drawing.Point(11, 63);
      this.lblJobTypeName.Name = "lblJobTypeName";
      this.lblJobTypeName.Size = new Size(100, 20);
      this.lblJobTypeName.TabIndex = 17;
      this.lblJobTypeName.Text = "Job Type Name";
      this.cboJobImportType.Cursor = Cursors.Hand;
      this.cboJobImportType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJobImportType.Location = new System.Drawing.Point(138, 26);
      this.cboJobImportType.Name = "cboJobImportType";
      this.cboJobImportType.Size = new Size(230, 21);
      this.cboJobImportType.TabIndex = 16;
      this.cboJobImportType.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblJobImportType.Location = new System.Drawing.Point(11, 29);
      this.lblJobImportType.Name = "lblJobImportType";
      this.lblJobImportType.Size = new Size(118, 20);
      this.lblJobImportType.TabIndex = 15;
      this.lblJobImportType.Text = "Job Import Type";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(268, 210);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(101, 23);
      this.btnSave.TabIndex = 11;
      this.btnSave.Text = "Save";
      this.btnRemoveType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveType.Location = new System.Drawing.Point(14, 210);
      this.btnRemoveType.Name = "btnRemoveType";
      this.btnRemoveType.Size = new Size(101, 23);
      this.btnRemoveType.TabIndex = 12;
      this.btnRemoveType.Text = "Remove";
      this.grpEngineerSkillSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerSkillSOR.Controls.Add((Control) this.btnClearAll);
      this.grpEngineerSkillSOR.Controls.Add((Control) this.grpEngineerSkills);
      this.grpEngineerSkillSOR.Controls.Add((Control) this.btnFindSOR);
      this.grpEngineerSkillSOR.Controls.Add((Control) this.txtSOR);
      this.grpEngineerSkillSOR.Controls.Add((Control) this.lblSORName);
      this.grpEngineerSkillSOR.Controls.Add((Control) this.btnSaveEngineerQual);
      this.grpEngineerSkillSOR.Location = new System.Drawing.Point(760, 8);
      this.grpEngineerSkillSOR.Name = "grpEngineerSkillSOR";
      this.grpEngineerSkillSOR.Size = new Size(375, 458);
      this.grpEngineerSkillSOR.TabIndex = 27;
      this.grpEngineerSkillSOR.TabStop = false;
      this.grpEngineerSkillSOR.Text = "Engineer Skills SOR";
      this.btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClearAll.Location = new System.Drawing.Point(14, 419);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new Size(101, 23);
      this.btnClearAll.TabIndex = 39;
      this.btnClearAll.Text = "Clear All";
      this.grpEngineerSkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerSkills.Controls.Add((Control) this.dgEngineerQual);
      this.grpEngineerSkills.Location = new System.Drawing.Point(14, 65);
      this.grpEngineerSkills.Name = "grpEngineerSkills";
      this.grpEngineerSkills.Size = new Size(345, 348);
      this.grpEngineerSkills.TabIndex = 15;
      this.grpEngineerSkills.TabStop = false;
      this.grpEngineerSkills.Text = "Qualifications / Skills";
      this.dgEngineerQual.DataMember = "";
      this.dgEngineerQual.Dock = DockStyle.Fill;
      this.dgEngineerQual.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineerQual.Location = new System.Drawing.Point(3, 17);
      this.dgEngineerQual.Name = "dgEngineerQual";
      this.dgEngineerQual.Size = new Size(339, 328);
      this.dgEngineerQual.TabIndex = 13;
      this.btnFindSOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSOR.BackColor = Color.White;
      this.btnFindSOR.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSOR.Location = new System.Drawing.Point(327, 23);
      this.btnFindSOR.Name = "btnFindSOR";
      this.btnFindSOR.Size = new Size(32, 23);
      this.btnFindSOR.TabIndex = 38;
      this.btnFindSOR.Text = "...";
      this.btnFindSOR.UseVisualStyleBackColor = false;
      this.txtSOR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSOR.Location = new System.Drawing.Point(182, 25);
      this.txtSOR.MaxLength = 50;
      this.txtSOR.Name = "txtSOR";
      this.txtSOR.ReadOnly = true;
      this.txtSOR.Size = new Size(139, 21);
      this.txtSOR.TabIndex = 18;
      this.txtSOR.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblSORName.Location = new System.Drawing.Point(15, 28);
      this.lblSORName.Name = "lblSORName";
      this.lblSORName.Size = new Size(162, 20);
      this.lblSORName.TabIndex = 15;
      this.lblSORName.Text = "System Schedule of Rate";
      this.btnSaveEngineerQual.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveEngineerQual.Location = new System.Drawing.Point(258, 422);
      this.btnSaveEngineerQual.Name = "btnSaveEngineerQual";
      this.btnSaveEngineerQual.Size = new Size(101, 23);
      this.btnSaveEngineerQual.TabIndex = 11;
      this.btnSaveEngineerQual.Text = "Save";
      this.Controls.Add((Control) this.grpEngineerSkillSOR);
      this.Controls.Add((Control) this.grpJobImportType);
      this.Controls.Add((Control) this.grpSystemScheduleOfRate);
      this.Name = nameof (UCSystemScheduleOfRate);
      this.Size = new Size(1144, 735);
      this.grpSystemScheduleOfRate.ResumeLayout(false);
      this.grpSystemScheduleOfRate.PerformLayout();
      this.grpSOR.ResumeLayout(false);
      this.dgRates.EndInit();
      this.grpJobImportType.ResumeLayout(false);
      this.grpJobImportType.PerformLayout();
      this.grpEngineerSkillSOR.ResumeLayout(false);
      this.grpEngineerSkillSOR.PerformLayout();
      this.grpEngineerSkills.ResumeLayout(false);
      this.dgEngineerQual.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
      Combo.SetUpCombo(ref ofRatesCategoryId, App.DB.Picklists.GetAll(Enums.PickListTypes.ScheduleRatesCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      ComboBox cboSorJobType = this.cboSORJobType;
      Combo.SetUpCombo(ref cboSorJobType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSORJobType = cboSorJobType;
      ComboBox cboJobImportType = this.cboJobImportType;
      Combo.SetUpCombo(ref cboJobImportType, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobImportType = cboJobImportType;
    }

    public object LoadedItem
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    private DataView RatesDataview
    {
      get
      {
        return this._dvRates;
      }
      set
      {
        this._dvRates = value;
        this._dvRates.AllowNew = false;
        this._dvRates.AllowEdit = false;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
        this.dgRates.DataSource = (object) this.RatesDataview;
      }
    }

    private DataRow SelectedRatesDataRow
    {
      get
      {
        return this.dgRates.CurrentRowIndex != -1 ? this.RatesDataview[this.dgRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView EngineerQualsDataview
    {
      get
      {
        return this._dvEngineerQuals;
      }
      set
      {
        this._dvEngineerQuals = value;
        this._dvEngineerQuals.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
        this.dgEngineerQual.DataSource = (object) this.EngineerQualsDataview;
      }
    }

    private DataRow SelectedEngineerQualDataRow
    {
      get
      {
        return this.dgEngineerQual.CurrentRowIndex != -1 ? this.EngineerQualsDataview[this.dgEngineerQual.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public SystemScheduleOfRate EngineerQualSOR
    {
      get
      {
        return this._engineerQualSOR;
      }
      set
      {
        this._engineerQualSOR = value;
        if (this._engineerQualSOR == null)
        {
          this._engineerQualSOR = new SystemScheduleOfRate();
          this._engineerQualSOR.Exists = false;
          this.txtSOR.Text = string.Empty;
        }
        else
          this.txtSOR.Text = this._engineerQualSOR.Description;
      }
    }

    public PickList EngineerQual
    {
      get
      {
        return this._engineerQual;
      }
      set
      {
        this._engineerQual = value;
        if (this._engineerQual == null)
        {
          this._engineerQual = new PickList();
          this._engineerQual.Exists = false;
          this.txtEngineerQual.Text = string.Empty;
        }
        else
          this.txtEngineerQual.Text = this._engineerQual.Name;
      }
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
        this.PageSetup();
      }
    }

    public JobImportType CurrentJobImportType
    {
      get
      {
        return this._currentJobImportType;
      }
      set
      {
        this._currentJobImportType = value;
        if (this._currentJobImportType != null)
          return;
        this._currentJobImportType = new JobImportType();
        this._currentJobImportType.Exists = false;
      }
    }

    public SystemScheduleOfRate CurrentSystemScheduleOfRate
    {
      get
      {
        return this._currentSystemScheduleOfRate;
      }
      set
      {
        this._currentSystemScheduleOfRate = value;
      }
    }

    public void SetupRatesDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgRates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Time (Mins)";
      dataGridLabelColumn4.MappingName = "TimeInMins";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 80;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      this.dgRates.TableStyles.Add(tableStyle);
    }

    public void SetupEngineerQualDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgEngineerQual.TableStyles[0];
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
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "Description";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 250;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Percentage";
      dataGridLabelColumn3.MappingName = "Percentage";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      this.dgEngineerQual.TableStyles.Add(tableStyle);
    }

    private void PageSetup()
    {
      if (this.PageState == Enums.FormState.Insert)
      {
        this.btnAddNew.Text = "Cancel Add";
        this.btnAddUpdate.Text = "Add";
        this.dgRates.Enabled = false;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = false;
        this.btnAddUpdate.Enabled = true;
        this.cboScheduleOfRatesCategoryID.Enabled = true;
        this.cboSORJobType.Enabled = true;
        this.txtCode.Enabled = true;
        this.txtDescription.Enabled = true;
        this.txtPrice.Enabled = true;
        this.txtTimeInMins.Enabled = true;
      }
      else if (this.PageState == Enums.FormState.Update)
      {
        this.btnAddNew.Text = "Cancel Update";
        this.btnAddUpdate.Text = "Update";
        this.dgRates.Enabled = true;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = true;
        this.btnAddUpdate.Enabled = true;
        if (!Conversions.ToBoolean(this.SelectedRatesDataRow["AllowDeleted"]))
        {
          ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
          Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, Conversions.ToString(0));
          this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
          ComboBox cboSorJobType = this.cboSORJobType;
          Combo.SetSelectedComboItem_By_Value(ref cboSorJobType, Conversions.ToString(0));
          this.cboSORJobType = cboSorJobType;
          this.cboScheduleOfRatesCategoryID.Enabled = false;
          this.cboSORJobType.Enabled = false;
          this.txtCode.Enabled = false;
          this.txtDescription.Enabled = false;
        }
        else
        {
          this.cboScheduleOfRatesCategoryID.Enabled = true;
          this.cboSORJobType.Enabled = true;
          this.txtCode.Enabled = true;
          this.txtDescription.Enabled = true;
        }
        this.txtPrice.Enabled = true;
        this.txtTimeInMins.Enabled = true;
      }
      else
      {
        this.btnAddNew.Text = "Add New";
        this.dgRates.Enabled = true;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = false;
        this.btnAddUpdate.Enabled = false;
        this.cboScheduleOfRatesCategoryID.Enabled = false;
        this.cboSORJobType.Enabled = false;
        this.txtCode.Enabled = false;
        this.txtDescription.Enabled = false;
        this.txtPrice.Enabled = false;
        this.txtTimeInMins.Enabled = false;
        ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
        Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, Conversions.ToString(0));
        this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
        ComboBox cboSorJobType = this.cboSORJobType;
        Combo.SetSelectedComboItem_By_Value(ref cboSorJobType, Conversions.ToString(0));
        this.cboSORJobType = cboSorJobType;
        this.txtCode.Text = "";
        this.txtDescription.Text = "";
        this.txtPrice.Text = Strings.Format((object) 0, "C");
        this.txtTimeInMins.Text = "";
      }
    }

    private void UCSystemScheduleOfRate_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      if (this.PageState == Enums.FormState.Insert | this.PageState == Enums.FormState.Update)
      {
        this.Populate(0);
        this.PageState = Enums.FormState.Load;
      }
      else
        this.PageState = Enums.FormState.Insert;
    }

    private void btnAddUpdate_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void dgRates_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow != null)
      {
        DataRow selectedRatesDataRow = this.SelectedRatesDataRow;
        ComboBox combo = this.cboScheduleOfRatesCategoryID;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(selectedRatesDataRow["ScheduleOfRatesCategoryID"]));
        this.cboScheduleOfRatesCategoryID = combo;
        combo = this.cboSORJobType;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(selectedRatesDataRow["JobTypeID"]));
        this.cboSORJobType = combo;
        this.txtCode.Text = Conversions.ToString(selectedRatesDataRow["Code"]);
        this.txtDescription.Text = Conversions.ToString(selectedRatesDataRow["Description"]);
        this.txtPrice.Text = Strings.Format(RuntimeHelpers.GetObjectValue(selectedRatesDataRow["Price"]), "C");
        this.txtTimeInMins.Text = Conversions.ToString(selectedRatesDataRow["TimeInMins"]);
        this.PageState = Enums.FormState.Update;
      }
      else
        this.PageState = Enums.FormState.Load;
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow != null)
        this.DeleteRate();
      else
        this.PageState = Enums.FormState.Load;
    }

    private void btnSaveEngineerQual_Click(object sender, EventArgs e)
    {
      App.DB.SystemScheduleOfRate.SOREnginerQual_Delete(this.EngineerQualSOR.SystemScheduleOfRateID);
      IEnumerator enumerator;
      try
      {
        enumerator = this.EngineerQualsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
            App.DB.SystemScheduleOfRate.SOREnginerQual_Insert(this.EngineerQualSOR.SystemScheduleOfRateID, Conversions.ToInteger(current["ManagerID"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnAddNewType_Click(object sender, EventArgs e)
    {
      ComboBox cboJobImportType = this.cboJobImportType;
      Combo.SetUpCombo(ref cboJobImportType, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobImportType = cboJobImportType;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
      this.cboJobType = cboJobType;
      this.txtJobTypeName.Text = string.Empty;
      this.txtEngineerQual.Text = string.Empty;
      this.txtCycle.Text = string.Empty;
    }

    private void btnFindSOR_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSystemScheduleOfRate, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.EngineerQualSOR = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get(integer);
      this.PopulateEngineerQuals(integer);
    }

    private void btnFindEngineerQual_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineerSkills, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.EngineerQual = App.DB.Picklists.Get_One_As_Object(integer);
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
      DataRow[] dataRowArray = this.EngineerQualsDataview.Table.Select(this.EngineerQualsDataview.RowFilter);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        dataRowArray[index]["Tick"] = (object) false;
        checked { ++index; }
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.CurrentJobImportType == null)
          this.CurrentJobImportType = new JobImportType();
        JobImportType currentJobImportType = this.CurrentJobImportType;
        currentJobImportType.SetJobImportTypeID = (object) Combo.get_GetSelectedItemValue(this.cboJobImportType);
        currentJobImportType.SetName = (object) this.txtJobTypeName.Text;
        currentJobImportType.SetJobTypeID = (object) Combo.get_GetSelectedItemValue(this.cboJobType);
        currentJobImportType.SetEngineerQualID = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.EngineerQual != null, (object) this.EngineerQual.ManagerID, (object) 0));
        currentJobImportType.SetCycle = (object) Conversions.ToInteger(this.txtCycle.Text);
        new JobImportTypeValidator().Validate(this.CurrentJobImportType);
        if (this.CurrentJobImportType.Exists)
          App.DB.JobImports.JobImportType_Update(this.CurrentJobImportType);
        else
          this.CurrentJobImportType = App.DB.JobImports.JobImportType_Insert(this.CurrentJobImportType);
        int num = (int) App.ShowMessage("Job Import Type Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ComboBox cboJobImportType = this.cboJobImportType;
        Combo.SetSelectedComboItem_By_Value(ref cboJobImportType, Conversions.ToString(this.CurrentJobImportType.JobImportTypeID));
        this.cboJobImportType = cboJobImportType;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
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

    private void btnRemoveType_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("Are you sure you want to remove this job type?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      App.DB.JobImports.JobImportType_Delete(this.CurrentJobImportType);
      this.btnAddNewType_Click(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgEngineerQual_Click(object sender, EventArgs e)
    {
      if (this.SelectedEngineerQualDataRow == null)
        return;
      this.dgEngineerQual[this.dgEngineerQual.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgEngineerQual[this.dgEngineerQual.CurrentRowIndex, 0]);
    }

    private void cboJobImportType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (App.ControlLoading)
        return;
      this.CurrentJobImportType = App.DB.JobImports.JobImportType_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobImportType)));
      if (this.CurrentJobImportType.Exists)
      {
        this.txtJobTypeName.Text = this.CurrentJobImportType.Name;
        ComboBox cboJobType = this.cboJobType;
        Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(this.CurrentJobImportType.JobTypeID));
        this.cboJobType = cboJobType;
        this.txtEngineerQual.Text = App.DB.Picklists.Get_One_As_Object(this.CurrentJobImportType.EngineerQualID).Name;
        this.txtCycle.Text = Conversions.ToString(this.CurrentJobImportType.Cycle);
      }
      else
      {
        this.txtJobTypeName.Text = string.Empty;
        ComboBox cboJobType = this.cboJobType;
        Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
        this.cboJobType = cboJobType;
        this.txtEngineerQual.Text = string.Empty;
        this.txtCycle.Text = string.Empty;
      }
    }

    public void Populate(int ID = 0)
    {
      this.RatesDataview = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll();
      this.PopulateEngineerQuals(0);
      this.PageState = Enums.FormState.Load;
    }

    public bool Save()
    {
      try
      {
        this.CurrentSystemScheduleOfRate.SetAllowDeleted = this.PageState != Enums.FormState.Update ? (object) 1 : RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["AllowDeleted"]);
        this.CurrentSystemScheduleOfRate.SetCode = (object) this.txtCode.Text.Trim();
        this.CurrentSystemScheduleOfRate.SetDescription = (object) this.txtDescription.Text.Trim();
        this.CurrentSystemScheduleOfRate.SetPrice = (object) Strings.Replace(this.txtPrice.Text.Trim(), "£", "", 1, -1, CompareMethod.Binary);
        this.CurrentSystemScheduleOfRate.SetTimeInMins = (object) this.txtTimeInMins.Text.Trim();
        if (this.CurrentSystemScheduleOfRate.AllowDeleted)
        {
          this.CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = (object) Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID);
          this.CurrentSystemScheduleOfRate.SetJobTypeID = (object) Combo.get_GetSelectedItemValue(this.cboSORJobType);
        }
        else
        {
          this.CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = (object) -1;
          this.CurrentSystemScheduleOfRate.SetJobTypeID = (object) 0;
        }
        new SystemScheduleOfRateValidator().Validate(this.CurrentSystemScheduleOfRate);
        if (this.PageState == Enums.FormState.Update)
        {
          this.CurrentSystemScheduleOfRate.SetSystemScheduleOfRateID = RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["SystemScheduleOfRateID"]);
          App.DB.SystemScheduleOfRate.Update(this.CurrentSystemScheduleOfRate);
          SystemScheduleOfRate systemScheduleOfRate = this.CurrentSystemScheduleOfRate;
          App.DB.CustomerScheduleOfRate.CustomerScheduleOfRates_UpdateForALL(new Decimal(systemScheduleOfRate.Price), systemScheduleOfRate.Description, systemScheduleOfRate.Code, systemScheduleOfRate.ScheduleOfRatesCategoryID, systemScheduleOfRate.TimeInMins);
        }
        else
          this.CurrentSystemScheduleOfRate = App.DB.SystemScheduleOfRate.Insert(this.CurrentSystemScheduleOfRate);
        this.Populate(0);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      bool flag;
      return flag;
    }

    private void DeleteRate()
    {
      try
      {
        DataRow selectedRatesDataRow = this.SelectedRatesDataRow;
        if (Conversions.ToBoolean(selectedRatesDataRow["AllowDeleted"]))
        {
          if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", selectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            App.DB.SystemScheduleOfRate.Delete(Conversions.ToInteger(selectedRatesDataRow["SystemScheduleOfRateID"]));
            this.Populate(0);
          }
        }
        else
        {
          int num = (int) MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    public void PopulateEngineerQuals(int ID = 0)
    {
      this.EngineerQualsDataview = App.DB.SystemScheduleOfRate.SOREnginerQual_Get_ForSOR(ID);
    }
  }
}
