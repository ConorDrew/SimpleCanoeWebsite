// Decompiled with JetBrains decompiler
// Type: FSM.DLGAdvancedItemSearch
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartSupplierPriceRequests;
using FSM.Entity.ProductSupplierPriceRequests;
using FSM.Entity.Suppliers;
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
  public class DLGAdvancedItemSearch : FRMBaseForm
  {
    private IContainer components;
    private int _quoteID;
    private Supplier _supplier;
    private DataView m_dTable2;

    public DLGAdvancedItemSearch()
    {
      this.m_dTable2 = (DataView) null;
      this.InitializeComponent();
      this.SetupPartsResultsDataGrid();
      ComboBox cboSearchFor = this.cboSearchFor;
      Combo.SetUpCombo(ref cboSearchFor, DynamicDataTables.Setup_Advanced_Search_Options(Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSearchFor = cboSearchFor;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtCriteria { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSearchOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSearchFor
    {
      get
      {
        return this._cboSearchFor;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSearchFor_SelectedIndexChanged);
        ComboBox cboSearchFor1 = this._cboSearchFor;
        if (cboSearchFor1 != null)
          cboSearchFor1.SelectedIndexChanged -= eventHandler;
        this._cboSearchFor = value;
        ComboBox cboSearchFor2 = this._cboSearchFor;
        if (cboSearchFor2 == null)
          return;
        cboSearchFor2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnFindSupplier
    {
      get
      {
        return this._btnFindSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSupplier_Click);
        Button btnFindSupplier1 = this._btnFindSupplier;
        if (btnFindSupplier1 != null)
          btnFindSupplier1.Click -= eventHandler;
        this._btnFindSupplier = value;
        Button btnFindSupplier2 = this._btnFindSupplier;
        if (btnFindSupplier2 == null)
          return;
        btnFindSupplier2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgResults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRequest
    {
      get
      {
        return this._btnRequest;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRequest_Click);
        Button btnRequest1 = this._btnRequest;
        if (btnRequest1 != null)
          btnRequest1.Click -= eventHandler;
        this._btnRequest = value;
        Button btnRequest2 = this._btnRequest;
        if (btnRequest2 == null)
          return;
        btnRequest2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnFindSupplier = new Button();
      this.txtSupplier = new TextBox();
      this.Label7 = new Label();
      this.dgResults = new DataGrid();
      this.btnSearch = new Button();
      this.txtCriteria = new TextBox();
      this.Label18 = new Label();
      this.cboSearchOn = new ComboBox();
      this.label17 = new Label();
      this.cboSearchFor = new ComboBox();
      this.Label5 = new Label();
      this.btnCancel = new Button();
      this.btnRequest = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgResults.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnFindSupplier);
      this.GroupBox1.Controls.Add((Control) this.txtSupplier);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.dgResults);
      this.GroupBox1.Controls.Add((Control) this.btnSearch);
      this.GroupBox1.Controls.Add((Control) this.txtCriteria);
      this.GroupBox1.Controls.Add((Control) this.Label18);
      this.GroupBox1.Controls.Add((Control) this.cboSearchOn);
      this.GroupBox1.Controls.Add((Control) this.label17);
      this.GroupBox1.Controls.Add((Control) this.cboSearchFor);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Location = new System.Drawing.Point(8, 48);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(608, 408);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Search";
      this.btnFindSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSupplier.BackColor = Color.White;
      this.btnFindSupplier.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSupplier.Location = new System.Drawing.Point(560, 379);
      this.btnFindSupplier.Name = "btnFindSupplier";
      this.btnFindSupplier.Size = new Size(32, 24);
      this.btnFindSupplier.TabIndex = 95;
      this.btnFindSupplier.Text = "...";
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSupplier.Location = new System.Drawing.Point(88, 379);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(464, 21);
      this.txtSupplier.TabIndex = 94;
      this.txtSupplier.Text = "";
      this.Label7.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label7.Location = new System.Drawing.Point(16, 376);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(64, 24);
      this.Label7.TabIndex = 96;
      this.Label7.Text = "Supplier";
      this.dgResults.DataMember = "";
      this.dgResults.HeaderForeColor = SystemColors.ControlText;
      this.dgResults.Location = new System.Drawing.Point(8, 88);
      this.dgResults.Name = "dgResults";
      this.dgResults.Size = new Size(592, 280);
      this.dgResults.TabIndex = 8;
      this.btnSearch.Location = new System.Drawing.Point(520, 56);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.TabIndex = 6;
      this.btnSearch.Text = "Search";
      this.txtCriteria.Location = new System.Drawing.Point(104, 56);
      this.txtCriteria.Name = "txtCriteria";
      this.txtCriteria.Size = new Size(400, 21);
      this.txtCriteria.TabIndex = 5;
      this.txtCriteria.Text = "";
      this.Label18.Location = new System.Drawing.Point(8, 56);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(80, 23);
      this.Label18.TabIndex = 4;
      this.Label18.Text = "Criteria:";
      this.cboSearchOn.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSearchOn.Location = new System.Drawing.Point(400, 24);
      this.cboSearchOn.Name = "cboSearchOn";
      this.cboSearchOn.Size = new Size(200, 21);
      this.cboSearchOn.TabIndex = 3;
      this.label17.Location = new System.Drawing.Point(312, 24);
      this.label17.Name = "label17";
      this.label17.Size = new Size(80, 23);
      this.label17.TabIndex = 2;
      this.label17.Text = "Search On:";
      this.cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSearchFor.Items.AddRange(new object[2]
      {
        (object) "Products",
        (object) "Parts"
      });
      this.cboSearchFor.Location = new System.Drawing.Point(104, 24);
      this.cboSearchFor.Name = "cboSearchFor";
      this.cboSearchFor.Size = new Size(200, 21);
      this.cboSearchFor.TabIndex = 1;
      this.Label5.Location = new System.Drawing.Point(8, 24);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(88, 23);
      this.Label5.TabIndex = 0;
      this.Label5.Text = "Search For:";
      this.btnCancel.Location = new System.Drawing.Point(120, 464);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnRequest.Location = new System.Drawing.Point(8, 464);
      this.btnRequest.Name = "btnRequest";
      this.btnRequest.Size = new Size(104, 23);
      this.btnRequest.TabIndex = 8;
      this.btnRequest.Text = "Request Prices";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(624, 494);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnRequest);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.MaximumSize = new Size(632, 528);
      this.MinimumSize = new Size(632, 528);
      this.Name = nameof (DLGAdvancedItemSearch);
      this.Text = "Advanced Search";
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnRequest, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgResults.EndInit();
      this.ResumeLayout(false);
    }

    public int QuoteID
    {
      get
      {
        return this._quoteID;
      }
      set
      {
        this._quoteID = value;
      }
    }

    public Supplier Supplier
    {
      get
      {
        return this._supplier;
      }
      set
      {
        this._supplier = value;
        if (this._supplier == null)
          return;
        this.txtSupplier.Text = this._supplier.Name + " (" + this._supplier.AccountNumber + ")";
      }
    }

    public DataView ItemDataView
    {
      get
      {
        return this.m_dTable2;
      }
      set
      {
        this.m_dTable2 = value;
        this.m_dTable2.Table.TableName = "tblItem";
        this.m_dTable2.AllowNew = false;
        this.m_dTable2.AllowEdit = false;
        this.m_dTable2.AllowDelete = false;
        this.dgResults.DataSource = (object) this.ItemDataView;
      }
    }

    private DataRow SelectedItemDataRow
    {
      get
      {
        return this.dgResults.CurrentRowIndex != -1 ? this.ItemDataView[this.dgResults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void btnFindSupplier_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Supplier = App.DB.Supplier.Supplier_Get(integer);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void cboSearchFor_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cboSearchOn = this.cboSearchOn;
      Combo.SetUpCombo(ref cboSearchOn, DynamicDataTables.Setup_Search_On_Options(Enums.MenuTypes.Spares, (Enums.TableNames) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboSearchFor))), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSearchOn = cboSearchOn;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) == 13.0)
      {
        this.SetupPartsResultsDataGrid();
      }
      else
      {
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) != 14.0)
          return;
        this.SetupProductsResultsDataGrid();
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) == 13.0)
      {
        this.ItemDataView = App.DB.Part.Part_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn));
      }
      else
      {
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) != 14.0)
          return;
        this.ItemDataView = App.DB.Product.Product_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn));
      }
    }

    private void btnRequest_Click(object sender, EventArgs e)
    {
      this.SaveRequests();
    }

    public object SetupPartsResultsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      this.dgResults.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridCheckBox dataGridCheckBox = new DataGridCheckBox();
      dataGridCheckBox.HeaderText = "Selected";
      dataGridCheckBox.MappingName = "Selected";
      dataGridCheckBox.ReadOnly = true;
      dataGridCheckBox.Width = 50;
      dataGridCheckBox.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridCheckBox);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 120;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "Number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 110;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part Reference";
      dataGridLabelColumn3.MappingName = "Reference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 170;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridOrderTextBoxColumn orderTextBoxColumn = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn.Format = "F";
      orderTextBoxColumn.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn.HeaderText = "Quantity";
      orderTextBoxColumn.MappingName = "QuantityHolder";
      orderTextBoxColumn.ReadOnly = false;
      orderTextBoxColumn.Width = 90;
      orderTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = "tblItem";
      this.dgResults.TableStyles.Add(tableStyle);
      object obj;
      return obj;
    }

    public object SetupProductsResultsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      this.dgResults.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridCheckBox dataGridCheckBox = new DataGridCheckBox();
      dataGridCheckBox.HeaderText = "Selected";
      dataGridCheckBox.MappingName = "Selected";
      dataGridCheckBox.ReadOnly = true;
      dataGridCheckBox.Width = 50;
      dataGridCheckBox.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridCheckBox);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "typemakemodel";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "Number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Product Reference";
      dataGridLabelColumn3.MappingName = "Reference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridOrderTextBoxColumn orderTextBoxColumn = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn.Format = "F";
      orderTextBoxColumn.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn.HeaderText = "Quantity";
      orderTextBoxColumn.MappingName = "QuantityHolder";
      orderTextBoxColumn.ReadOnly = false;
      orderTextBoxColumn.Width = 90;
      orderTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = "tblItem";
      this.dgResults.TableStyles.Add(tableStyle);
      object obj;
      return obj;
    }

    private object SaveRequests()
    {
      if (this.Supplier == null)
      {
        int num1 = (int) App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        DataRow[] dataRowArray1 = this.ItemDataView.Table.Select("Selected = 1");
        int index1 = 0;
        while (index1 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index1];
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["QuantityHolder"])) | !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataRow["QuantityHolder"])))
          {
            int num2 = (int) App.ShowMessage("Please enter a quantity for each Item you have checked", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            goto label_18;
          }
          else
            checked { ++index1; }
        }
        if (this.QuoteID > 0)
        {
          DataRow[] dataRowArray2 = this.ItemDataView.Table.Select("Selected = 1");
          int index2 = 0;
          while (index2 < dataRowArray2.Length)
          {
            DataRow dataRow = dataRowArray2[index2];
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) == 13.0)
              App.DB.PartPriceRequest.InsertForQuote(new PartSupplierPriceRequest()
              {
                SetQuoteID = (object) this.QuoteID,
                SetPartID = RuntimeHelpers.GetObjectValue(dataRow["partID"]),
                SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataRow["QuantityHolder"]),
                SetSupplierID = (object) this.Supplier.SupplierID,
                SetComplete = (object) 0
              });
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSearchFor)) == 14.0)
              App.DB.ProductPriceRequest.InsertForQuote(new ProductSupplierPriceRequest()
              {
                SetQuoteID = (object) this.QuoteID,
                SetProductID = RuntimeHelpers.GetObjectValue(dataRow["productID"]),
                SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataRow["QuantityHolder"]),
                SetSupplierID = (object) this.Supplier.SupplierID,
                SetComplete = (object) 0
              });
            checked { ++index2; }
          }
        }
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
label_18:
      object obj;
      return obj;
    }
  }
}
