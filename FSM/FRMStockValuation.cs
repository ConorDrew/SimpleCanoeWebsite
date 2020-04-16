// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockValuation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class FRMStockValuation : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvParts;

    public FRMStockValuation()
    {
      this.Load += new EventHandler(this.FRMStockValuation_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference
    {
      get
      {
        return this._txtReference;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtReference_TextChanged);
        TextBox txtReference1 = this._txtReference;
        if (txtReference1 != null)
          txtReference1.TextChanged -= eventHandler;
        this._txtReference = value;
        TextBox txtReference2 = this._txtReference;
        if (txtReference2 == null)
          return;
        txtReference2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExport_Click);
        Button btnExport1 = this._btnExport;
        if (btnExport1 != null)
          btnExport1.Click -= eventHandler;
        this._btnExport = value;
        Button btnExport2 = this._btnExport;
        if (btnExport2 == null)
          return;
        btnExport2.Click += eventHandler;
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

    internal virtual TextBox txtName
    {
      get
      {
        return this._txtName;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
        TextBox txtName1 = this._txtName;
        if (txtName1 != null)
          txtName1.TextChanged -= eventHandler;
        this._txtName = value;
        TextBox txtName2 = this._txtName;
        if (txtName2 == null)
          return;
        txtName2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtNumber
    {
      get
      {
        return this._txtNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtNumber_TextChanged);
        TextBox txtNumber1 = this._txtNumber;
        if (txtNumber1 != null)
          txtNumber1.TextChanged -= eventHandler;
        this._txtNumber = value;
        TextBox txtNumber2 = this._txtNumber;
        if (txtNumber2 == null)
          return;
        txtNumber2.TextChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboCategory
    {
      get
      {
        return this._cboCategory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboCategory_SelectedIndexChanged);
        ComboBox cboCategory1 = this._cboCategory;
        if (cboCategory1 != null)
          cboCategory1.SelectedIndexChanged -= eventHandler;
        this._cboCategory = value;
        ComboBox cboCategory2 = this._cboCategory;
        if (cboCategory2 == null)
          return;
        cboCategory2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLocation
    {
      get
      {
        return this._cboLocation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboLocation_SelectedIndexChanged);
        ComboBox cboLocation1 = this._cboLocation;
        if (cboLocation1 != null)
          cboLocation1.SelectedIndexChanged -= eventHandler;
        this._cboLocation = value;
        ComboBox cboLocation2 = this._cboLocation;
        if (cboLocation2 == null)
          return;
        cboLocation2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation
    {
      get
      {
        return this._txtLocation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtLocation_TextChanged);
        TextBox txtLocation1 = this._txtLocation;
        if (txtLocation1 != null)
          txtLocation1.TextChanged -= eventHandler;
        this._txtLocation = value;
        TextBox txtLocation2 = this._txtLocation;
        if (txtLocation2 == null)
          return;
        txtLocation2.TextChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkExact
    {
      get
      {
        return this._chkExact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkExact_CheckedChanged);
        CheckBox chkExact1 = this._chkExact;
        if (chkExact1 != null)
          chkExact1.CheckedChanged -= eventHandler;
        this._chkExact = value;
        CheckBox chkExact2 = this._chkExact;
        if (chkExact2 == null)
          return;
        chkExact2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DataGrid dgParts
    {
      get
      {
        return this._dgParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgParts_DoubleClick);
        DataGrid dgParts1 = this._dgParts;
        if (dgParts1 != null)
          dgParts1.DoubleClick -= eventHandler;
        this._dgParts = value;
        DataGrid dgParts2 = this._dgParts;
        if (dgParts2 == null)
          return;
        dgParts2.DoubleClick += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpParts = new GroupBox();
      this.dgParts = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.chkExact = new CheckBox();
      this.txtLocation = new TextBox();
      this.cboLocation = new ComboBox();
      this.Label4 = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.cboCategory = new ComboBox();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtReference = new TextBox();
      this.Label6 = new Label();
      this.btnReset = new Button();
      this.grpParts.SuspendLayout();
      this.dgParts.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpParts.Controls.Add((Control) this.dgParts);
      this.grpParts.Location = new System.Drawing.Point(8, 136);
      this.grpParts.Name = "grpParts";
      this.grpParts.Size = new Size(630, 162);
      this.grpParts.TabIndex = 2;
      this.grpParts.TabStop = false;
      this.grpParts.Text = "Part replacement costs based on supplier";
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(8, 19);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(614, 135);
      this.dgParts.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 306);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 3;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.chkExact);
      this.grpFilter.Controls.Add((Control) this.txtLocation);
      this.grpFilter.Controls.Add((Control) this.cboLocation);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.txtName);
      this.grpFilter.Controls.Add((Control) this.txtNumber);
      this.grpFilter.Controls.Add((Control) this.cboCategory);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.txtReference);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(630, 98);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.chkExact.AutoSize = true;
      this.chkExact.Location = new System.Drawing.Point(52, 41);
      this.chkExact.Name = "chkExact";
      this.chkExact.RightToLeft = RightToLeft.Yes;
      this.chkExact.Size = new Size(237, 17);
      this.chkExact.TabIndex = 17;
      this.chkExact.Text = "Advanced Location Filter Exact Match";
      this.chkExact.UseVisualStyleBackColor = true;
      this.txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtLocation.Location = new System.Drawing.Point(307, 39);
      this.txtLocation.MaxLength = 50;
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.Size = new Size(58, 21);
      this.txtLocation.TabIndex = 16;
      this.cboLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboLocation.FormattingEnabled = true;
      this.cboLocation.Location = new System.Drawing.Point(64, 14);
      this.cboLocation.Name = "cboLocation";
      this.cboLocation.Size = new Size(301, 21);
      this.cboLocation.TabIndex = 14;
      this.Label4.Location = new System.Drawing.Point(6, 17);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(88, 16);
      this.Label4.TabIndex = 13;
      this.Label4.Text = "Location";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(64, 69);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(301, 21);
      this.txtName.TabIndex = 2;
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtNumber.Location = new System.Drawing.Point(445, 69);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new Size(181, 21);
      this.txtNumber.TabIndex = 4;
      this.cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCategory.FormattingEnabled = true;
      this.cboCategory.Location = new System.Drawing.Point(445, 14);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(181, 21);
      this.cboCategory.TabIndex = 1;
      this.Label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label3.Location = new System.Drawing.Point(369, 17);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(88, 16);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "Category";
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label2.Location = new System.Drawing.Point(371, 46);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(67, 18);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Reference";
      this.Label1.Location = new System.Drawing.Point(4, 72);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Name";
      this.txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtReference.Location = new System.Drawing.Point(445, 41);
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(181, 21);
      this.txtReference.TabIndex = 3;
      this.Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label6.Location = new System.Drawing.Point(371, 69);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Number";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 306);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 4;
      this.btnReset.Text = "Reset";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(646, 336);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpParts);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(654, 370);
      this.Name = nameof (FRMStockValuation);
      this.Text = "Stock Valuation Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpParts, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpParts.ResumeLayout(false);
      this.dgParts.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
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

    private DataView PartsDataview
    {
      get
      {
        return this._dvParts;
      }
      set
      {
        this._dvParts = value;
        this._dvParts.AllowNew = false;
        this._dvParts.AllowEdit = false;
        this._dvParts.AllowDelete = false;
        this._dvParts.Table.TableName = Enums.TableNames.tblPart.ToString();
        this.dgParts.DataSource = (object) this.PartsDataview;
      }
    }

    private DataRow SelectedPartDataRow
    {
      get
      {
        return this.dgParts.CurrentRowIndex != -1 ? this.PartsDataview[this.dgParts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Number";
      dataGridLabelColumn3.MappingName = "Number";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Reference";
      dataGridLabelColumn4.MappingName = "Reference";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Cost";
      dataGridLabelColumn5.MappingName = "ReplacementCost";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Undistributed";
      dataGridLabelColumn6.MappingName = "Undistributed";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Supplier";
      dataGridLabelColumn7.MappingName = "Supplier";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 250;
      dataGridLabelColumn7.NullText = "No Supplier";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      this.dgParts.TableStyles.Add(tableStyle);
    }

    private void FRMStockValuation_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtNumber_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtReference_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void txtLocation_TextChanged(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void chkExact_CheckedChanged(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void dgParts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedPartDataRow == null)
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        this.SelectedPartDataRow["PartID"],
        (object) true
      }, false);
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void PopulateDatagrid()
    {
      try
      {
        int WarehouseID = 0;
        int VanID = 0;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboLocation), "0", false) > 0U)
        {
          if (Combo.get_GetSelectedItemValue(this.cboLocation).StartsWith("W"))
            WarehouseID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocation).Replace("W", ""));
          else
            VanID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocation).Replace("V", ""));
        }
        this.PartsDataview = new DataView(App.DB.Part.Stock_Valuation(0, WarehouseID, VanID, this.txtLocation.Text.Trim(), this.chkExact.Checked).Tables[0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetFilters()
    {
      DataTable DT = new DataTable();
      DT.Columns.Add(new DataColumn("Location"));
      DT.Columns.Add(new DataColumn("Name"));
      IEnumerator enumerator1;
      try
      {
        enumerator1 = App.DB.Warehouse.Warehouse_GetAll().Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          DataRow row = DT.NewRow();
          row["Location"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "W", current["WarehouseID"]);
          row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
          DT.Rows.Add(row);
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
        enumerator2 = App.DB.Van.Van_GetAll(false).Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          DataRow row = DT.NewRow();
          row["Location"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "V", current["VanID"]);
          row["Name"] = RuntimeHelpers.GetObjectValue(current["Registration"]);
          DT.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      ComboBox cboLocation1 = this.cboLocation;
      Combo.SetUpCombo(ref cboLocation1, DT, "Location", "Name", Enums.ComboValues.No_Filter);
      this.cboLocation = cboLocation1;
      ComboBox cboLocation2 = this.cboLocation;
      Combo.SetSelectedComboItem_By_Value(ref cboLocation2, Conversions.ToString(0));
      this.cboLocation = cboLocation2;
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboCategory = cboCategory;
      cboCategory = this.cboCategory;
      Combo.SetSelectedComboItem_By_Value(ref cboCategory, Conversions.ToString(0));
      this.cboCategory = cboCategory;
      this.txtName.Text = "";
      this.txtNumber.Text = "";
      this.txtReference.Text = "";
      this.RunFilter();
    }

    private void RunFilter()
    {
      string str = "1 = 1";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboCategory)) != 0.0)
        str += " AND CategoryID = " + Combo.get_GetSelectedItemValue(this.cboCategory);
      if ((uint) this.txtName.Text.Trim().Length > 0U)
        str = str + " AND Name LIKE '%" + this.txtName.Text.Trim() + "%'";
      if ((uint) this.txtNumber.Text.Trim().Length > 0U)
        str = str + " AND Number LIKE '%" + this.txtNumber.Text.Trim() + "%'";
      if ((uint) this.txtReference.Text.Trim().Length > 0U)
        str = str + " AND Reference LIKE '%" + this.txtReference.Text.Trim() + "%'";
      this.PartsDataview.RowFilter = str;
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("Category");
      datatableIn.Columns.Add("Name");
      datatableIn.Columns.Add("Number");
      datatableIn.Columns.Add("Reference");
      datatableIn.Columns.Add("Cost");
      datatableIn.Columns.Add("Undistributed");
      datatableIn.Columns.Add("Supplier");
      int num = checked (((DataView) this.dgParts.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgParts.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["Category"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Category"]);
        row2["Name"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Name"]);
        row2["Number"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Number"]);
        row2["Reference"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Reference"]);
        row2["Cost"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["ReplacementCost"]), "F");
        row2["Undistributed"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Undistributed"]), "F");
        row2["Supplier"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Supplier"]);
        datatableIn.Rows.Add(row2);
        this.dgParts.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Stock Value Report", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
