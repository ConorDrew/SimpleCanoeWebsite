// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerTimesheets
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEngineerTimesheets : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvTimesheets;
    private Engineer _oEngineer;

    public FRMEngineerTimesheets()
    {
      this.Load += new EventHandler(this.FRMOrderManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDateCreated
    {
      get
      {
        return this._chkDateCreated;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDateCreated_CheckedChanged);
        CheckBox chkDateCreated1 = this._chkDateCreated;
        if (chkDateCreated1 != null)
          chkDateCreated1.CheckedChanged -= eventHandler;
        this._chkDateCreated = value;
        CheckBox chkDateCreated2 = this._chkDateCreated;
        if (chkDateCreated2 == null)
          return;
        chkDateCreated2.CheckedChanged += eventHandler;
      }
    }

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

    internal virtual DataGrid dgTimesheets
    {
      get
      {
        return this._dgTimesheets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgTimesheets_DoubleClick);
        DataGrid dgTimesheets1 = this._dgTimesheets;
        if (dgTimesheets1 != null)
          dgTimesheets1.DoubleClick -= eventHandler;
        this._dgTimesheets = value;
        DataGrid dgTimesheets2 = this._dgTimesheets;
        if (dgTimesheets2 == null)
          return;
        dgTimesheets2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label lblSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindRecord
    {
      get
      {
        return this._btnFindRecord;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindRecord_Click);
        Button btnFindRecord1 = this._btnFindRecord;
        if (btnFindRecord1 != null)
          btnFindRecord1.Click -= eventHandler;
        this._btnFindRecord = value;
        Button btnFindRecord2 = this._btnFindRecord;
        if (btnFindRecord2 == null)
          return;
        btnFindRecord2.Click += eventHandler;
      }
    }

    internal virtual Button btnFind
    {
      get
      {
        return this._btnFind;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFind_Click);
        Button btnFind1 = this._btnFind;
        if (btnFind1 != null)
          btnFind1.Click -= eventHandler;
        this._btnFind = value;
        Button btnFind2 = this._btnFind;
        if (btnFind2 == null)
          return;
        btnFind2.Click += eventHandler;
      }
    }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtaddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgTimesheets = new DataGrid();
      this.grpFilter = new GroupBox();
      this.Label1 = new Label();
      this.txtJobNumber = new TextBox();
      this.btnFind = new Button();
      this.btnFindRecord = new Button();
      this.txtSearch = new TextBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkDateCreated = new CheckBox();
      this.lblSearch = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.btnReset = new Button();
      this.btnAdd = new Button();
      this.btnDelete = new Button();
      this.Label2 = new Label();
      this.txtaddress = new TextBox();
      this.grpJobs.SuspendLayout();
      this.dgTimesheets.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgTimesheets);
      this.grpJobs.Location = new System.Drawing.Point(8, 217);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(828, 303);
      this.grpJobs.TabIndex = 2;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Double Click To View / Edit";
      this.dgTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTimesheets.DataMember = "";
      this.dgTimesheets.HeaderForeColor = SystemColors.ControlText;
      this.dgTimesheets.Location = new System.Drawing.Point(8, 30);
      this.dgTimesheets.Name = "dgTimesheets";
      this.dgTimesheets.Size = new Size(812, 265);
      this.dgTimesheets.TabIndex = 11;
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.txtaddress);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.btnFind);
      this.grpFilter.Controls.Add((Control) this.btnFindRecord);
      this.grpFilter.Controls.Add((Control) this.txtSearch);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkDateCreated);
      this.grpFilter.Controls.Add((Control) this.lblSearch);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Location = new System.Drawing.Point(8, 40);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(828, 171);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label1.Location = new System.Drawing.Point(518, 111);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(112, 20);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Job Number";
      this.txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtJobNumber.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtJobNumber.Location = new System.Drawing.Point(636, 110);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(184, 21);
      this.txtJobNumber.TabIndex = 19;
      this.btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFind.BackColor = Color.White;
      this.btnFind.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFind.Location = new System.Drawing.Point(728, 140);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new Size(92, 23);
      this.btnFind.TabIndex = 18;
      this.btnFind.Text = "Find";
      this.btnFind.UseVisualStyleBackColor = false;
      this.btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindRecord.BackColor = Color.White;
      this.btnFindRecord.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindRecord.Location = new System.Drawing.Point(788, 51);
      this.btnFindRecord.Name = "btnFindRecord";
      this.btnFindRecord.Size = new Size(32, 23);
      this.btnFindRecord.TabIndex = 17;
      this.btnFindRecord.Text = "...";
      this.btnFindRecord.UseVisualStyleBackColor = false;
      this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSearch.Location = new System.Drawing.Point(136, 53);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.ReadOnly = true;
      this.txtSearch.Size = new Size(644, 21);
      this.txtSearch.TabIndex = 16;
      this.dtpTo.Location = new System.Drawing.Point(184, 118);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(224, 21);
      this.dtpTo.TabIndex = 10;
      this.dtpFrom.Location = new System.Drawing.Point(184, 86);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(224, 21);
      this.dtpFrom.TabIndex = 9;
      this.Label9.Location = new System.Drawing.Point(136, 115);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(136, 83);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkDateCreated.Cursor = Cursors.Hand;
      this.chkDateCreated.UseVisualStyleBackColor = true;
      this.chkDateCreated.Location = new System.Drawing.Point(17, 86);
      this.chkDateCreated.Name = "chkDateCreated";
      this.chkDateCreated.Size = new Size(104, 24);
      this.chkDateCreated.TabIndex = 8;
      this.chkDateCreated.Text = "Date Between";
      this.lblSearch.Location = new System.Drawing.Point(16, 53);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new Size(112, 20);
      this.lblSearch.TabIndex = 2;
      this.lblSearch.Text = "Engineer";
      this.Label10.Location = new System.Drawing.Point(16, 25);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 20);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(136, 22);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(684, 21);
      this.cboType.TabIndex = 1;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(8, 526);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 13;
      this.btnReset.Text = "Reset";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAdd.Location = new System.Drawing.Point(772, 526);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(56, 23);
      this.btnAdd.TabIndex = 14;
      this.btnAdd.Text = "Add";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDelete.Location = new System.Drawing.Point(70, 526);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(56, 23);
      this.btnDelete.TabIndex = 15;
      this.btnDelete.Text = "Delete";
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label2.Location = new System.Drawing.Point(518, 84);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 20);
      this.Label2.TabIndex = 22;
      this.Label2.Text = "Address";
      this.txtaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtaddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtaddress.Location = new System.Drawing.Point(636, 83);
      this.txtaddress.Name = "txtaddress";
      this.txtaddress.Size = new Size(184, 21);
      this.txtaddress.TabIndex = 21;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(844, 558);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(852, 592);
      this.Name = nameof (FRMEngineerTimesheets);
      this.Text = "Engineer General Timesheets Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnAdd, 0);
      this.Controls.SetChildIndex((Control) this.btnDelete, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgTimesheets.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupTimesheetsDataGrid();
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      this.ResetFilters();
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

    private DataView TimesheetsDataview
    {
      get
      {
        return this._dvTimesheets;
      }
      set
      {
        this._dvTimesheets = value;
        this._dvTimesheets.AllowNew = false;
        this._dvTimesheets.AllowEdit = false;
        this._dvTimesheets.AllowDelete = false;
        this._dvTimesheets.Table.TableName = Enums.TableNames.tblEngineerTimesheet.ToString();
        this.dgTimesheets.DataSource = (object) this.TimesheetsDataview;
      }
    }

    private DataRow SelectedTimesheetDataRow
    {
      get
      {
        return this.dgTimesheets.CurrentRowIndex != -1 ? this.TimesheetsDataview[this.dgTimesheets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Engineer oEngineer
    {
      get
      {
        return this._oEngineer;
      }
      set
      {
        this._oEngineer = value;
        if (this._oEngineer != null)
          this.txtSearch.Text = this.oEngineer.Name;
        else
          this.txtSearch.Text = "";
      }
    }

    private void SetupTimesheetsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgTimesheets.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Engineer";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Type";
      dataGridLabelColumn2.MappingName = "Type";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Comments";
      dataGridLabelColumn3.MappingName = "Comments";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 300;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Start Date/Time";
      dataGridLabelColumn4.MappingName = "StartDateTime";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "End Date/Time";
      dataGridLabelColumn5.MappingName = "EndDateTime";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address";
      dataGridLabelColumn6.MappingName = "Address";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 300;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Job Number";
      dataGridLabelColumn7.MappingName = "JobNumber";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 300;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerTimesheet.ToString();
      this.dgTimesheets.TableStyles.Add(tableStyle);
    }

    private void FRMOrderManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void chkDateCreated_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkDateCreated.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today;
        this.dtpTo.Value = DateAndTime.Today;
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void dgTimesheets_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedTimesheetDataRow == null)
        return;
      App.ShowForm(typeof (FRMEngineerTimesheet), true, new object[2]
      {
        this.SelectedTimesheetDataRow["EngineerTimeSheetID"],
        this.SelectedTimesheetDataRow["Source"]
      }, false);
      this.RunFilter();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMEngineerTimesheet), true, new object[1]
      {
        (object) 0
      }, false);
      this.RunFilter();
    }

    private void btnFindRecord_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.oEngineer = App.DB.Engineer.Engineer_Get(integer);
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedTimesheetDataRow == null)
        return;
      if (App.ShowMessage("Are you sure you want to delete this timesheet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        App.DB.EngineerTimesheets.Delete(Conversions.ToInteger(this.SelectedTimesheetDataRow["EngineerTimeSheetID"]));
      this.RunFilter();
    }

    private void ResetFilters()
    {
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
      this.cboType = cboType;
      this.chkDateCreated.Checked = false;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = false;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpTo.Enabled = false;
      this.grpFilter.Enabled = true;
      this.txtSearch.Text = "";
    }

    private void RunFilter()
    {
      string Where = " WHERE 1=1 ";
      string Where2 = "";
      if (this.oEngineer != null)
        Where += " AND tblEngineer.EngineerID = " + Conversions.ToString(this.oEngineer.EngineerID);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
        Where += " AND TimeSheetTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
      if ((uint) this.txtJobNumber.Text.Length > 0U)
        Where2 = Where2 + " AND jobNumber = '" + this.txtJobNumber.Text + "'";
      if ((uint) this.txtaddress.Text.Length > 0U)
        Where2 = Where2 + " AND Address1 LIKE '%" + this.txtaddress.Text + "%'";
      if (this.chkDateCreated.Checked)
        Where = Where + " AND TS.StartDateTime >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND TS.EndDateTime <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
      this.TimesheetsDataview = App.DB.EngineerTimesheets.GetAll(Where, Where2);
    }
  }
}
