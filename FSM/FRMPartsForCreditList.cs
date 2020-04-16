// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartsForCreditList
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
  public class FRMPartsForCreditList : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool _fromQuoteJob;
    private bool _fromJob;
    private DataView _DataViewToLinkTo;
    private int _IDToLinkTo;
    private DataView _dvRates;

    public FRMPartsForCreditList(int IDToLinkToIn, bool FromQuoteJobIn = false, bool FromJobIn = false)
    {
      this.Load += new EventHandler(this.FRMSystemScheduleOfRate_Load);
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.FromQuoteJob = FromQuoteJobIn;
      this.FromJob = FromJobIn;
      this.IDToLinkTo = IDToLinkToIn;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSystemScheduleOfRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual Button btnSelectAll
    {
      get
      {
        return this._btnSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAll_Click);
        Button btnSelectAll1 = this._btnSelectAll;
        if (btnSelectAll1 != null)
          btnSelectAll1.Click -= eventHandler;
        this._btnSelectAll = value;
        Button btnSelectAll2 = this._btnSelectAll;
        if (btnSelectAll2 == null)
          return;
        btnSelectAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeselectAll
    {
      get
      {
        return this._btnDeselectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeselectAll_Click);
        Button btnDeselectAll1 = this._btnDeselectAll;
        if (btnDeselectAll1 != null)
          btnDeselectAll1.Click -= eventHandler;
        this._btnDeselectAll = value;
        Button btnDeselectAll2 = this._btnDeselectAll;
        if (btnDeselectAll2 == null)
          return;
        btnDeselectAll2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSystemScheduleOfRate = new GroupBox();
      this.btnDeselectAll = new Button();
      this.btnSelectAll = new Button();
      this.btnCancel = new Button();
      this.btnAdd = new Button();
      this.dgRates = new DataGrid();
      this.grpSystemScheduleOfRate.SuspendLayout();
      this.dgRates.BeginInit();
      this.SuspendLayout();
      this.grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnDeselectAll);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnSelectAll);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnCancel);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnAdd);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.dgRates);
      this.grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 32);
      this.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
      this.grpSystemScheduleOfRate.Size = new Size(632, 432);
      this.grpSystemScheduleOfRate.TabIndex = 2;
      this.grpSystemScheduleOfRate.TabStop = false;
      this.grpSystemScheduleOfRate.Text = "Main Details";
      this.btnDeselectAll.Location = new System.Drawing.Point(112, 360);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(96, 23);
      this.btnDeselectAll.TabIndex = 36;
      this.btnDeselectAll.Text = "Deselect All";
      this.btnSelectAll.Location = new System.Drawing.Point(8, 360);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(96, 23);
      this.btnSelectAll.TabIndex = 35;
      this.btnSelectAll.Text = "Select All";
      this.btnCancel.Location = new System.Drawing.Point(8, 400);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 34;
      this.btnCancel.Text = "Cancel";
      this.btnAdd.Location = new System.Drawing.Point(544, 400);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.TabIndex = 33;
      this.btnAdd.Text = "Add";
      this.dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgRates.DataMember = "";
      this.dgRates.HeaderForeColor = SystemColors.ControlText;
      this.dgRates.Location = new System.Drawing.Point(8, 19);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(618, 333);
      this.dgRates.TabIndex = 32;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(648, 470);
      this.Controls.Add((Control) this.grpSystemScheduleOfRate);
      this.MinimumSize = new Size(656, 504);
      this.Name = "FRMSiteScheduleOfRateList";
      this.Text = "Property Schedule Of Rates List";
      this.Controls.SetChildIndex((Control) this.grpSystemScheduleOfRate, 0);
      this.grpSystemScheduleOfRate.ResumeLayout(false);
      this.dgRates.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
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

    public bool FromQuoteJob
    {
      get
      {
        return this._fromQuoteJob;
      }
      set
      {
        this._fromQuoteJob = value;
      }
    }

    public bool FromJob
    {
      get
      {
        return this._fromJob;
      }
      set
      {
        this._fromJob = value;
      }
    }

    public DataView DataviewToLinkTo
    {
      get
      {
        return this._DataViewToLinkTo;
      }
      set
      {
        this._DataViewToLinkTo = value;
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
      }
    }

    public DataView RatesDataview
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

    public void SetupRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgRates, false);
      DataGridTableStyle tableStyle = this.dgRates.TableStyles[0];
      this.dgRates.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
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
      dataGridLabelColumn1.HeaderText = "Part Number";
      dataGridLabelColumn1.MappingName = "Number";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 65;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 170;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Unit Price";
      dataGridLabelColumn3.MappingName = "BuyPrice";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Qty Received";
      dataGridLabelColumn4.MappingName = "QuantityReceived";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Qty to credit";
      editableTextBoxColumn.MappingName = "QtyToCredit";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 100;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      this.dgRates.TableStyles.Add(tableStyle);
    }

    private void FRMSystemScheduleOfRate_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void dgRates_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedRatesDataRow == null)
          return;
        this.dgRates[this.dgRates.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgRates[this.dgRates.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      this.Add();
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void Populate()
    {
      this.RatesDataview = App.DB.Order.Order_ItemsGetAll(this.IDToLinkTo);
    }

    private void Add()
    {
      bool flag = false;
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["tick"], (object) true, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["QtyToCredit"], (object) 0, false))))
          {
            flag = true;
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
        return;
      int num = (int) App.ShowMessage("You need to select at least 1 qty of a Part", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      this.RatesDataview.Table.Clear();
    }
  }
}
