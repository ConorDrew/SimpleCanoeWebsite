// Decompiled with JetBrains decompiler
// Type: FSM.FRMTimeSlotRates
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class FRMTimeSlotRates : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvRates;
    private DataView _dvBankHoliday;
    private DataView _dvLabourTypes;

    public FRMTimeSlotRates()
    {
      this.Load += new EventHandler(this.FRMTimeSlotRates_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual DataGrid dgTimeslots { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox gpbTimeslots { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabTimeSlots { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabBankHolidays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbBankHolidays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgBankHolidays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbTimeslots = new GroupBox();
      this.dgTimeslots = new DataGrid();
      this.TabControl1 = new TabControl();
      this.tabTimeSlots = new TabPage();
      this.tabBankHolidays = new TabPage();
      this.btnSave = new Button();
      this.gpbBankHolidays = new GroupBox();
      this.dgBankHolidays = new DataGrid();
      this.gpbTimeslots.SuspendLayout();
      this.dgTimeslots.BeginInit();
      this.TabControl1.SuspendLayout();
      this.tabTimeSlots.SuspendLayout();
      this.tabBankHolidays.SuspendLayout();
      this.gpbBankHolidays.SuspendLayout();
      this.dgBankHolidays.BeginInit();
      this.SuspendLayout();
      this.gpbTimeslots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbTimeslots.Controls.Add((Control) this.dgTimeslots);
      this.gpbTimeslots.Location = new System.Drawing.Point(8, 8);
      this.gpbTimeslots.Name = "gpbTimeslots";
      this.gpbTimeslots.Size = new Size(680, 256);
      this.gpbTimeslots.TabIndex = 0;
      this.gpbTimeslots.TabStop = false;
      this.gpbTimeslots.Text = "Time Slot Charge Rates";
      this.dgTimeslots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTimeslots.DataMember = "";
      this.dgTimeslots.HeaderForeColor = SystemColors.ControlText;
      this.dgTimeslots.Location = new System.Drawing.Point(10, 21);
      this.dgTimeslots.Name = "dgTimeslots";
      this.dgTimeslots.Size = new Size(661, 227);
      this.dgTimeslots.TabIndex = 0;
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tabTimeSlots);
      this.TabControl1.Controls.Add((Control) this.tabBankHolidays);
      this.TabControl1.Location = new System.Drawing.Point(0, 48);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(704, 296);
      this.TabControl1.TabIndex = 1;
      this.tabTimeSlots.Controls.Add((Control) this.gpbTimeslots);
      this.tabTimeSlots.Location = new System.Drawing.Point(4, 22);
      this.tabTimeSlots.Name = "tabTimeSlots";
      this.tabTimeSlots.Size = new Size(696, 270);
      this.tabTimeSlots.TabIndex = 0;
      this.tabTimeSlots.Text = "Time Slot Charge Rates";
      this.tabBankHolidays.Controls.Add((Control) this.gpbBankHolidays);
      this.tabBankHolidays.Location = new System.Drawing.Point(4, 22);
      this.tabBankHolidays.Name = "tabBankHolidays";
      this.tabBankHolidays.Size = new Size(696, 270);
      this.tabBankHolidays.TabIndex = 1;
      this.tabBankHolidays.Text = "Bank Holidays";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(616, 352);
      this.btnSave.Name = "btnSave";
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "&Save";
      this.gpbBankHolidays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbBankHolidays.Controls.Add((Control) this.dgBankHolidays);
      this.gpbBankHolidays.Location = new System.Drawing.Point(8, 7);
      this.gpbBankHolidays.Name = "gpbBankHolidays";
      this.gpbBankHolidays.Size = new Size(680, 256);
      this.gpbBankHolidays.TabIndex = 1;
      this.gpbBankHolidays.TabStop = false;
      this.gpbBankHolidays.Text = "Bank Holiday Rates";
      this.dgBankHolidays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgBankHolidays.DataMember = "";
      this.dgBankHolidays.HeaderForeColor = SystemColors.ControlText;
      this.dgBankHolidays.Location = new System.Drawing.Point(10, 22);
      this.dgBankHolidays.Name = "dgBankHolidays";
      this.dgBankHolidays.Size = new Size(661, 226);
      this.dgBankHolidays.TabIndex = 0;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(704, 390);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (FRMTimeSlotRates);
      this.Text = "Time Slot Rates";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.TabControl1, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.gpbTimeslots.ResumeLayout(false);
      this.dgTimeslots.EndInit();
      this.TabControl1.ResumeLayout(false);
      this.tabTimeSlots.ResumeLayout(false);
      this.tabBankHolidays.ResumeLayout(false);
      this.gpbBankHolidays.ResumeLayout(false);
      this.dgBankHolidays.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.LabourTypesDataview = App.DB.TimeSlotRates.LabourTypes_Get();
      this.SetupBankHolidayDataGrid();
      this.SetupRatesDataGrid();
      this.Populate();
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
    {
    }

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
        this._dvRates.AllowEdit = true;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblTimeslotRates.ToString();
        this.dgTimeslots.DataSource = (object) this.RatesDataview;
      }
    }

    private DataView BankHolidayDataview
    {
      get
      {
        return this._dvBankHoliday;
      }
      set
      {
        this._dvBankHoliday = value;
        this._dvBankHoliday.AllowNew = true;
        this._dvBankHoliday.AllowEdit = true;
        this._dvBankHoliday.AllowDelete = false;
        this._dvBankHoliday.Table.TableName = Enums.TableNames.tblBankHolidays.ToString();
        this.dgBankHolidays.DataSource = (object) this.BankHolidayDataview;
      }
    }

    private DataView LabourTypesDataview
    {
      get
      {
        return this._dvLabourTypes;
      }
      set
      {
        this._dvLabourTypes = value;
      }
    }

    public void SetupRatesDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgTimeslots.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "HH:mm";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Timeslot";
      dataGridLabelColumn.MappingName = "Timeslot";
      dataGridLabelColumn.ReadOnly = false;
      dataGridLabelColumn.Width = 75;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridComboBoxColumn gridComboBoxColumn1 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn1.HeaderText = "Monday";
      gridComboBoxColumn1.MappingName = "Monday";
      gridComboBoxColumn1.ReadOnly = false;
      gridComboBoxColumn1.Width = 90;
      gridComboBoxColumn1.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn1.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn1.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn1);
      DataGridComboBoxColumn gridComboBoxColumn2 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn2.HeaderText = "Tuesday";
      gridComboBoxColumn2.MappingName = "Tuesday";
      gridComboBoxColumn2.ReadOnly = false;
      gridComboBoxColumn2.Width = 90;
      gridComboBoxColumn2.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn2.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn2.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn2);
      DataGridComboBoxColumn gridComboBoxColumn3 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn3.HeaderText = "Wednesday";
      gridComboBoxColumn3.MappingName = "Wednesday";
      gridComboBoxColumn3.ReadOnly = false;
      gridComboBoxColumn3.Width = 90;
      gridComboBoxColumn3.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn3.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn3.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn3);
      DataGridComboBoxColumn gridComboBoxColumn4 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn4.HeaderText = "Thursday";
      gridComboBoxColumn4.MappingName = "Thursday";
      gridComboBoxColumn4.ReadOnly = false;
      gridComboBoxColumn4.Width = 90;
      gridComboBoxColumn4.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn4.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn4.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn4);
      DataGridComboBoxColumn gridComboBoxColumn5 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn5.HeaderText = "Friday";
      gridComboBoxColumn5.MappingName = "Friday";
      gridComboBoxColumn5.ReadOnly = false;
      gridComboBoxColumn5.Width = 90;
      gridComboBoxColumn5.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn5.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn5.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn5);
      DataGridComboBoxColumn gridComboBoxColumn6 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn6.HeaderText = "Saturday";
      gridComboBoxColumn6.MappingName = "Saturday";
      gridComboBoxColumn6.ReadOnly = false;
      gridComboBoxColumn6.Width = 90;
      gridComboBoxColumn6.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn6.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn6.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn6);
      DataGridComboBoxColumn gridComboBoxColumn7 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn7.HeaderText = "Sunday";
      gridComboBoxColumn7.MappingName = "Sunday";
      gridComboBoxColumn7.ReadOnly = false;
      gridComboBoxColumn7.Width = 90;
      gridComboBoxColumn7.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn7.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn7.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn7);
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgTimeslots.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblTimeslotRates.ToString();
      this.dgTimeslots.TableStyles.Add(tableStyle);
    }

    public void SetupBankHolidayDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgBankHolidays.TableStyles[0];
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "dd/MM/yyyy";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Bank Holiday Date";
      editableTextBoxColumn.MappingName = "BankHolidayDate";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 150;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(false);
      gridComboBoxColumn.HeaderText = "Labour Rate";
      gridComboBoxColumn.MappingName = "LabourRateID";
      gridComboBoxColumn.ReadOnly = false;
      gridComboBoxColumn.Width = 150;
      gridComboBoxColumn.ComboBox.DataSource = (object) this.LabourTypesDataview;
      gridComboBoxColumn.ComboBox.DisplayMember = "LabourType";
      gridComboBoxColumn.ComboBox.ValueMember = "LabourTypeID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgBankHolidays.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblBankHolidays.ToString();
      this.dgBankHolidays.TableStyles.Add(tableStyle);
    }

    private void FRMTimeSlotRates_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void Populate()
    {
      this.RatesDataview = App.DB.TimeSlotRates.GetAll();
      this.BankHolidayDataview = App.DB.TimeSlotRates.BankHolidays_GetAll();
    }

    private void Save()
    {
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          App.DB.TimeSlotRates.Update(Conversions.ToInteger(current["UniqueID"]), Conversions.ToInteger(current["Monday"]), Conversions.ToInteger(current["Tuesday"]), Conversions.ToInteger(current["Wednesday"]), Conversions.ToInteger(current["Thursday"]), Conversions.ToInteger(current["Friday"]), Conversions.ToInteger(current["Saturday"]), Conversions.ToInteger(current["Sunday"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = this.BankHolidayDataview.Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["LabourRateID"])) == 0)
            current["LabourRateID"] = (object) Enums.LabourTypes.Double;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["bankHolidayID"])) == 0)
            App.DB.TimeSlotRates.BankHolidays_Insert(Conversions.ToDate(current["bankHolidayDate"]), Conversions.ToInteger(current["LabourRateID"]));
          else
            App.DB.TimeSlotRates.BankHolidays_Update(Conversions.ToDate(current["bankHolidayDate"]), Conversions.ToInteger(current["LabourRateID"]), Conversions.ToInteger(current["bankHolidayID"]));
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.Populate();
    }
  }
}
