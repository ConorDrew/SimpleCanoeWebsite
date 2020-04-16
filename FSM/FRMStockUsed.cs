// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockUsed
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class FRMStockUsed : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvParts;

    public FRMStockUsed()
    {
      this.Load += new EventHandler(this.FRMStockUsed_Load);
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

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboMonths
    {
      get
      {
        return this._cboMonths;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboMonths_SelectedIndexChanged);
        ComboBox cboMonths1 = this._cboMonths;
        if (cboMonths1 != null)
          cboMonths1.SelectedIndexChanged -= eventHandler;
        this._cboMonths = value;
        ComboBox cboMonths2 = this._cboMonths;
        if (cboMonths2 == null)
          return;
        cboMonths2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkQty
    {
      get
      {
        return this._chkQty;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkQty_CheckedChanged);
        CheckBox chkQty1 = this._chkQty;
        if (chkQty1 != null)
          chkQty1.CheckedChanged -= eventHandler;
        this._chkQty = value;
        CheckBox chkQty2 = this._chkQty;
        if (chkQty2 == null)
          return;
        chkQty2.CheckedChanged += eventHandler;
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
      this.cboMonths = new ComboBox();
      this.Label5 = new Label();
      this.txtName = new TextBox();
      this.Label4 = new Label();
      this.txtNumber = new TextBox();
      this.cboCategory = new ComboBox();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtReference = new TextBox();
      this.Label6 = new Label();
      this.btnReset = new Button();
      this.chkQty = new CheckBox();
      this.grpParts.SuspendLayout();
      this.dgParts.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpParts.Controls.Add((Control) this.dgParts);
      this.grpParts.Location = new System.Drawing.Point(8, 149);
      this.grpParts.Name = "grpParts";
      this.grpParts.Size = new Size(697, 149);
      this.grpParts.TabIndex = 2;
      this.grpParts.TabStop = false;
      this.grpParts.Text = "Parts used";
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(8, 19);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(681, 122);
      this.dgParts.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 306);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 3;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.chkQty);
      this.grpFilter.Controls.Add((Control) this.cboMonths);
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.txtName);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.txtNumber);
      this.grpFilter.Controls.Add((Control) this.cboCategory);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.txtReference);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Location = new System.Drawing.Point(8, 38);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(697, 105);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.cboMonths.FormattingEnabled = true;
      this.cboMonths.Location = new System.Drawing.Point(386, 72);
      this.cboMonths.Name = "cboMonths";
      this.cboMonths.Size = new Size(82, 21);
      this.cboMonths.TabIndex = 5;
      this.Label5.Location = new System.Drawing.Point(474, 75);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(53, 18);
      this.Label5.TabIndex = 15;
      this.Label5.Text = "Months";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(73, 41);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(395, 21);
      this.txtName.TabIndex = 2;
      this.Label4.Location = new System.Drawing.Point(6, 75);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(381, 18);
      this.Label4.TabIndex = 13;
      this.Label4.Text = "Show all parts not used on any job or customer order in the last";
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtNumber.Location = new System.Drawing.Point(548, 40);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new Size(141, 21);
      this.txtNumber.TabIndex = 4;
      this.cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboCategory.FormattingEnabled = true;
      this.cboCategory.Location = new System.Drawing.Point(73, 14);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(395, 21);
      this.cboCategory.TabIndex = 1;
      this.Label3.Location = new System.Drawing.Point(5, 17);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(88, 16);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "Category";
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label2.Location = new System.Drawing.Point(474, 17);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(67, 18);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Reference";
      this.Label1.Location = new System.Drawing.Point(6, 44);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Name";
      this.txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtReference.Location = new System.Drawing.Point(548, 12);
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(141, 21);
      this.txtReference.TabIndex = 3;
      this.Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label6.Location = new System.Drawing.Point(474, 40);
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
      this.chkQty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkQty.AutoSize = true;
      this.chkQty.Location = new System.Drawing.Point(548, 72);
      this.chkQty.Name = "chkQty";
      this.chkQty.RightToLeft = RightToLeft.Yes;
      this.chkQty.Size = new Size(133, 17);
      this.chkQty.TabIndex = 16;
      this.chkQty.Text = "Show quantity of 0";
      this.chkQty.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(713, 336);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpParts);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(721, 370);
      this.Name = nameof (FRMStockUsed);
      this.Text = "Stock Used Report";
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
      this.PopulateDatagrid();
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
      dataGridLabelColumn1.HeaderText = "Used within the last (Months)";
      dataGridLabelColumn1.MappingName = "Months";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "Not Used";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Category";
      dataGridLabelColumn2.MappingName = "Category";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Number";
      dataGridLabelColumn4.MappingName = "Number";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Reference";
      dataGridLabelColumn5.MappingName = "Reference";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Qty";
      dataGridLabelColumn6.MappingName = "StockLevel";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Warehouse Qty";
      dataGridLabelColumn7.MappingName = "WarehouseStock";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Van Qty";
      dataGridLabelColumn8.MappingName = "VanStock";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "C";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Cost";
      dataGridLabelColumn9.MappingName = "ReplacementCost";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      this.dgParts.TableStyles.Add(tableStyle);
    }

    private void FRMStockUsed_Load(object sender, EventArgs e)
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

    private void cboMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void chkQty_CheckedChanged(object sender, EventArgs e)
    {
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
        this.PartsDataview = App.DB.Part.Stock_Used();
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
      this.PopulateDatagrid();
      ComboBox cboCategory1 = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory1, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboCategory = cboCategory1;
      ComboBox cboCategory2 = this.cboCategory;
      Combo.SetSelectedComboItem_By_Value(ref cboCategory2, Conversions.ToString(0));
      this.cboCategory = cboCategory2;
      this.txtName.Text = "";
      this.txtNumber.Text = "";
      this.txtReference.Text = "";
      ComboBox cboMonths1 = this.cboMonths;
      Combo.SetUpCombo(ref cboMonths1, DynamicDataTables.get_Count(1, 36), "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboMonths = cboMonths1;
      ComboBox cboMonths2 = this.cboMonths;
      Combo.SetSelectedComboItem_By_Value(ref cboMonths2, Conversions.ToString(0));
      this.cboMonths = cboMonths2;
      this.chkQty.Checked = false;
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
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboMonths)) != 0.0)
        str = str + " AND (Months = 0 OR Months > " + Combo.get_GetSelectedItemValue(this.cboMonths) + ")";
      if (!this.chkQty.Checked)
        str += " AND StockLevel > 0";
      this.PartsDataview.RowFilter = str;
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("Used with the last (Months)");
      datatableIn.Columns.Add("Category");
      datatableIn.Columns.Add("Name");
      datatableIn.Columns.Add("Number");
      datatableIn.Columns.Add("Reference");
      datatableIn.Columns.Add("Cost");
      datatableIn.Columns.Add("Total Stock");
      datatableIn.Columns.Add("Warehouse Stock");
      datatableIn.Columns.Add("Van Stock");
      int num = checked (((DataView) this.dgParts.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgParts.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["Used with the last (Months)"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Months"]);
        row2["Category"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Category"]);
        row2["Name"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Name"]);
        row2["Number"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Number"]);
        row2["Reference"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Reference"]);
        row2["Cost"] = this.SelectedPartDataRow["ReplacementCost"] != DBNull.Value ? (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["ReplacementCost"]), "F") : (object) null;
        row2["Total Stock"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["StockLevel"]), "F");
        row2["Warehouse Stock"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["WarehouseStock"]), "F");
        row2["Van Stock"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["VanStock"]), "F");
        datatableIn.Rows.Add(row2);
        this.dgParts.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Stock Used Report", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
