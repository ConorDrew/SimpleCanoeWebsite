// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerHistory
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Vans;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEngineerHistory : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;
    private Van _Van;
    private DataView _VanHistory;

    public FRMEngineerHistory()
    {
      this.Load += new EventHandler(this.FRMEngineerHistory_Load);
      this._ID = 0;
      this._Van = (Van) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgHistory
    {
      get
      {
        return this._dgHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgHistory_DoubleClick);
        DataGrid dgHistory1 = this._dgHistory;
        if (dgHistory1 != null)
          dgHistory1.DoubleClick -= eventHandler;
        this._dgHistory = value;
        DataGrid dgHistory2 = this._dgHistory;
        if (dgHistory2 == null)
          return;
        dgHistory2.DoubleClick += eventHandler;
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpHistory = new GroupBox();
      this.btnAdd = new Button();
      this.dgHistory = new DataGrid();
      this.grpHistory.SuspendLayout();
      this.dgHistory.BeginInit();
      this.SuspendLayout();
      this.grpHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpHistory.Controls.Add((Control) this.btnAdd);
      this.grpHistory.Controls.Add((Control) this.dgHistory);
      this.grpHistory.Location = new System.Drawing.Point(8, 40);
      this.grpHistory.Name = "grpHistory";
      this.grpHistory.Size = new Size(856, 440);
      this.grpHistory.TabIndex = 1;
      this.grpHistory.TabStop = false;
      this.grpHistory.Text = "Double Click To View / Edit";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(8, 408);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(64, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.dgHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgHistory.DataMember = "";
      this.dgHistory.HeaderForeColor = SystemColors.ControlText;
      this.dgHistory.Location = new System.Drawing.Point(8, 26);
      this.dgHistory.Name = "dgHistory";
      this.dgHistory.Size = new Size(840, 374);
      this.dgHistory.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(872, 486);
      this.Controls.Add((Control) this.grpHistory);
      this.MinimumSize = new Size(880, 520);
      this.Name = nameof (FRMEngineerHistory);
      this.Text = "Engineer History For Profile : {0}";
      this.Controls.SetChildIndex((Control) this.grpHistory, 0);
      this.grpHistory.ResumeLayout(false);
      this.dgHistory.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
        this.Van = App.DB.Van.Van_Get(this.ID);
      }
    }

    public Van Van
    {
      get
      {
        return this._Van;
      }
      set
      {
        this._Van = value;
        this.Text = "Engineer History For Profile : " + this.Van.Registration;
        this.VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(this.Van.VanID);
      }
    }

    public DataView VanHistory
    {
      get
      {
        return this._VanHistory;
      }
      set
      {
        this._VanHistory = value;
        this._VanHistory.Table.TableName = Enums.TableNames.tblEngineerVan.ToString();
        this._VanHistory.AllowNew = false;
        this._VanHistory.AllowEdit = false;
        this._VanHistory.AllowDelete = false;
        this.dgHistory.DataSource = (object) this.VanHistory;
      }
    }

    private DataRow SelectedHistoryDataRow
    {
      get
      {
        return this.dgHistory.CurrentRowIndex != -1 ? this.VanHistory[this.dgHistory.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupDataGrid()
    {
      Helper.SetUpDataGrid(this.dgHistory, false);
      DataGridTableStyle tableStyle = this.dgHistory.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Engineer";
      dataGridLabelColumn1.MappingName = "Engineer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 330;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dddd dd MMMM yyyy HH:mm";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "From";
      dataGridLabelColumn2.MappingName = "StartDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 250;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dddd dd MMMM yyyy HH:mm";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "To";
      dataGridLabelColumn3.MappingName = "EndDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "Until Further Notice";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVan.ToString();
      this.dgHistory.TableStyles.Add(tableStyle);
    }

    private void FRMEngineerHistory_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMEngineerVan), true, new object[3]
      {
        (object) 0,
        (object) this.Van.VanID,
        (object) this
      }, false);
      this.VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(this.Van.VanID);
    }

    private void dgHistory_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedHistoryDataRow == null)
        return;
      App.ShowForm(typeof (FRMEngineerVan), true, new object[3]
      {
        this.SelectedHistoryDataRow["EngineerVanID"],
        (object) this.Van.VanID,
        (object) this
      }, false);
      this.VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(this.Van.VanID);
    }
  }
}
