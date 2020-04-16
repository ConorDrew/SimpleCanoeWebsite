// Decompiled with JetBrains decompiler
// Type: FSM.UCOrderForJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Warehouses;
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
  public class UCOrderForJob : UCBase, IUserControl
  {
    private IContainer components;
    private DataView m_dTable;
    private Warehouse _Warehouse;

    public UCOrderForJob()
    {
      this.Load += new EventHandler(this.UCOrderForJob_Load);
      this.m_dTable = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineerVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtJobSearch
    {
      get
      {
        return this._txtJobSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobSearch_KeyUp);
        TextBox txtJobSearch1 = this._txtJobSearch;
        if (txtJobSearch1 != null)
          txtJobSearch1.KeyUp -= keyEventHandler;
        this._txtJobSearch = value;
        TextBox txtJobSearch2 = this._txtJobSearch;
        if (txtJobSearch2 == null)
          return;
        txtJobSearch2.KeyUp += keyEventHandler;
      }
    }

    internal virtual GroupBox grpWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindWarehouse
    {
      get
      {
        return this._btnFindWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindWarehouse_Click);
        Button btnFindWarehouse1 = this._btnFindWarehouse;
        if (btnFindWarehouse1 != null)
          btnFindWarehouse1.Click -= eventHandler;
        this._btnFindWarehouse = value;
        Button btnFindWarehouse2 = this._btnFindWarehouse;
        if (btnFindWarehouse2 == null)
          return;
        btnFindWarehouse2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpCustomerSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJob = new GroupBox();
      this.dgEngineerVisits = new DataGrid();
      this.btnSearch = new Button();
      this.txtJobSearch = new TextBox();
      this.grpCustomerSearch = new GroupBox();
      this.grpWarehouse = new GroupBox();
      this.btnFindWarehouse = new Button();
      this.txtWarehouse = new TextBox();
      this.grpJob.SuspendLayout();
      this.dgEngineerVisits.BeginInit();
      this.grpCustomerSearch.SuspendLayout();
      this.grpWarehouse.SuspendLayout();
      this.SuspendLayout();
      this.grpJob.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJob.Controls.Add((Control) this.dgEngineerVisits);
      this.grpJob.Location = new System.Drawing.Point(8, 128);
      this.grpJob.Name = "grpJob";
      this.grpJob.Size = new Size(696, 248);
      this.grpJob.TabIndex = 10;
      this.grpJob.TabStop = false;
      this.grpJob.Text = "Select a Visit to assign this Order to:";
      this.dgEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEngineerVisits.DataMember = "";
      this.dgEngineerVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineerVisits.Location = new System.Drawing.Point(8, 26);
      this.dgEngineerVisits.Name = "dgEngineerVisits";
      this.dgEngineerVisits.Size = new Size(680, 214);
      this.dgEngineerVisits.TabIndex = 3;
      this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSearch.ForeColor = SystemColors.ControlText;
      this.btnSearch.Location = new System.Drawing.Point(640, 25);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(48, 23);
      this.btnSearch.TabIndex = 2;
      this.btnSearch.Text = "Find";
      this.txtJobSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtJobSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtJobSearch.Location = new System.Drawing.Point(8, 24);
      this.txtJobSearch.Name = "txtJobSearch";
      this.txtJobSearch.Size = new Size(624, 21);
      this.txtJobSearch.TabIndex = 1;
      this.grpCustomerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomerSearch.BackColor = Color.White;
      this.grpCustomerSearch.Controls.Add((Control) this.btnSearch);
      this.grpCustomerSearch.Controls.Add((Control) this.txtJobSearch);
      this.grpCustomerSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpCustomerSearch.ForeColor = SystemColors.ControlText;
      this.grpCustomerSearch.Location = new System.Drawing.Point(8, 8);
      this.grpCustomerSearch.Name = "grpCustomerSearch";
      this.grpCustomerSearch.Size = new Size(696, 56);
      this.grpCustomerSearch.TabIndex = 9;
      this.grpCustomerSearch.TabStop = false;
      this.grpCustomerSearch.Text = "Job Number / Address";
      this.grpWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpWarehouse.Controls.Add((Control) this.btnFindWarehouse);
      this.grpWarehouse.Controls.Add((Control) this.txtWarehouse);
      this.grpWarehouse.Location = new System.Drawing.Point(8, 70);
      this.grpWarehouse.Name = "grpWarehouse";
      this.grpWarehouse.Size = new Size(696, 52);
      this.grpWarehouse.TabIndex = 11;
      this.grpWarehouse.TabStop = false;
      this.grpWarehouse.Text = "Warehouse";
      this.btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindWarehouse.ForeColor = SystemColors.ControlText;
      this.btnFindWarehouse.Location = new System.Drawing.Point(640, 18);
      this.btnFindWarehouse.Name = "btnFindWarehouse";
      this.btnFindWarehouse.Size = new Size(48, 23);
      this.btnFindWarehouse.TabIndex = 3;
      this.btnFindWarehouse.Text = "...";
      this.txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWarehouse.Location = new System.Drawing.Point(8, 20);
      this.txtWarehouse.Name = "txtWarehouse";
      this.txtWarehouse.ReadOnly = true;
      this.txtWarehouse.Size = new Size(624, 21);
      this.txtWarehouse.TabIndex = 0;
      this.Controls.Add((Control) this.grpWarehouse);
      this.Controls.Add((Control) this.grpCustomerSearch);
      this.Controls.Add((Control) this.grpJob);
      this.Name = nameof (UCOrderForJob);
      this.Size = new Size(712, 377);
      this.grpJob.ResumeLayout(false);
      this.dgEngineerVisits.EndInit();
      this.grpCustomerSearch.ResumeLayout(false);
      this.grpCustomerSearch.PerformLayout();
      this.grpWarehouse.ResumeLayout(false);
      this.grpWarehouse.PerformLayout();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupVisitsDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) null;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public DataView EngineerVisitsDataView
    {
      get
      {
        return this.m_dTable;
      }
      set
      {
        this.m_dTable = value;
        this.m_dTable.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
        this.m_dTable.AllowNew = false;
        this.m_dTable.AllowEdit = false;
        this.m_dTable.AllowDelete = false;
        this.dgEngineerVisits.DataSource = (object) this.EngineerVisitsDataView;
      }
    }

    public DataRow SelectedEngineerVisitDataRow
    {
      get
      {
        return this.dgEngineerVisits.CurrentRowIndex != -1 ? this.EngineerVisitsDataView[this.dgEngineerVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Warehouse Warehouse
    {
      get
      {
        return this._Warehouse;
      }
      set
      {
        this._Warehouse = value;
        if (this._Warehouse == null)
          return;
        string str1 = this._Warehouse.Name + ". " + this._Warehouse.Address1;
        if (this._Warehouse.Postcode.Length > 0)
        {
          string str2 = str1 + ", " + this._Warehouse.Postcode;
        }
      }
    }

    public void SetupVisitsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgEngineerVisits, false);
      DataGridTableStyle tableStyle = this.dgEngineerVisits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Customer";
      dataGridLabelColumn1.MappingName = "Customer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Job Number";
      dataGridLabelColumn3.MappingName = "JobNumber";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "PO Number";
      dataGridLabelColumn4.MappingName = "PONumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Definition";
      dataGridLabelColumn5.MappingName = "JobDefinition";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Type";
      dataGridLabelColumn6.MappingName = "Type";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Status";
      dataGridLabelColumn7.MappingName = "VisitStatus";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "dd/MMM/yyyy";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Date";
      dataGridLabelColumn8.MappingName = "startdatetime";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Engineer";
      dataGridLabelColumn9.MappingName = "Engineer";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Job Of Work";
      dataGridLabelColumn10.MappingName = "JOWNo";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 100;
      dataGridLabelColumn10.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Visit";
      dataGridLabelColumn11.MappingName = "VisitNo";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 100;
      dataGridLabelColumn11.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgEngineerVisits.TableStyles.Add(tableStyle);
    }

    private void btnFindWarehouse_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Warehouse = App.DB.Warehouse.Warehouse_Get(integer);
    }

    private void UCOrderForJob_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.txtJobSearch.Text))
        return;
      this.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Search(this.txtJobSearch.Text, true);
    }

    private void txtJobSearch_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || string.IsNullOrEmpty(this.txtJobSearch.Text))
        return;
      this.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Search(this.txtJobSearch.Text, true);
    }

    void IUserControl.Populate(int ID = 0)
    {
    }

    public bool Save()
    {
      bool flag;
      return flag;
    }
  }
}
