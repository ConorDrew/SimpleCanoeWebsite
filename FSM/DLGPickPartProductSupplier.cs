// Decompiled with JetBrains decompiler
// Type: FSM.DLGPickPartProductSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Parts;
using FSM.Entity.Products;
using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DLGPickPartProductSupplier : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;
    private Enums.TableNames _TableToSearch;
    private DataView _dvRecords;

    public DLGPickPartProductSupplier()
    {
      this.Load += new EventHandler(this.DLGPickPartProductSupplier_Load);
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFilter
    {
      get
      {
        return this._txtFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtFilter_TextChanged);
        TextBox txtFilter1 = this._txtFilter;
        if (txtFilter1 != null)
          txtFilter1.TextChanged -= eventHandler;
        this._txtFilter = value;
        TextBox txtFilter2 = this._txtFilter;
        if (txtFilter2 == null)
          return;
        txtFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpResults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
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

    internal virtual DataGrid dgResults
    {
      get
      {
        return this._dgResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgResults_DoubleClick);
        DataGrid dgResults1 = this._dgResults;
        if (dgResults1 != null)
          dgResults1.DoubleClick -= eventHandler;
        this._dgResults = value;
        DataGrid dgResults2 = this._dgResults;
        if (dgResults2 == null)
          return;
        dgResults2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label lblDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.txtFilter = new TextBox();
      this.grpResults = new GroupBox();
      this.dgResults = new DataGrid();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.lblDetails = new Label();
      this.grpResults.SuspendLayout();
      this.dgResults.BeginInit();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(8, 72);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 24);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Filter By Name";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(104, 72);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(584, 21);
      this.txtFilter.TabIndex = 1;
      this.txtFilter.Text = "";
      this.grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpResults.Controls.Add((Control) this.dgResults);
      this.grpResults.Location = new System.Drawing.Point(8, 104);
      this.grpResults.Name = "grpResults";
      this.grpResults.Size = new Size(680, 216);
      this.grpResults.TabIndex = 4;
      this.grpResults.TabStop = false;
      this.grpResults.Text = "Select record and click OK";
      this.dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgResults.DataMember = "";
      this.dgResults.HeaderForeColor = SystemColors.ControlText;
      this.dgResults.Location = new System.Drawing.Point(8, 25);
      this.dgResults.Name = "dgResults";
      this.dgResults.Size = new Size(664, 183);
      this.dgResults.TabIndex = 2;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(632, 328);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(56, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 328);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblDetails.Location = new System.Drawing.Point(8, 40);
      this.lblDetails.Name = "lblDetails";
      this.lblDetails.Size = new Size(680, 24);
      this.lblDetails.TabIndex = 7;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(696, 358);
      this.ControlBox = false;
      this.Controls.Add((Control) this.lblDetails);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.grpResults);
      this.Controls.Add((Control) this.txtFilter);
      this.Controls.Add((Control) this.Label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(704, 392);
      this.Name = nameof (DLGPickPartProductSupplier);
      this.Text = "Find {0}";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.txtFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpResults, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.lblDetails, 0);
      this.grpResults.ResumeLayout(false);
      this.dgResults.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ActiveControl = (Control) this.txtFilter;
      this.txtFilter.Focus();
      this.SetupDG();
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

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    public Enums.TableNames TableToSearch
    {
      get
      {
        return this._TableToSearch;
      }
      set
      {
        this._TableToSearch = value;
        this.Text = "Pick From Available Suppliers";
        switch (this.TableToSearch)
        {
          case Enums.TableNames.tblPartSupplier:
            this.Records = App.DB.PartSupplier.Get_ByPartID(this.ID);
            Part part = App.DB.Part.Part_Get(this.ID);
            this.lblDetails.Text = "Select supplier for part : " + part.Name + " (" + part.Number + ")";
            break;
          case Enums.TableNames.tblProductSupplier:
            this.Records = App.DB.ProductSupplier.Get_ByProductID(this.ID);
            Product product = App.DB.Product.Product_Get(this.ID);
            this.lblDetails.Text = "Select supplier for product : " + product.Name + " (" + product.Number + ")";
            break;
        }
      }
    }

    private DataView Records
    {
      get
      {
        return this._dvRecords;
      }
      set
      {
        this._dvRecords = value;
        this._dvRecords.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
        this._dvRecords.AllowNew = false;
        this._dvRecords.AllowEdit = false;
        this._dvRecords.AllowDelete = false;
        this.dgResults.DataSource = (object) this.Records;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgResults.CurrentRowIndex != -1 ? this.Records[this.dgResults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDG()
    {
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      switch (this.TableToSearch)
      {
        case Enums.TableNames.tblPartSupplier:
          DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
          dataGridLabelColumn1.Format = "";
          dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn1.HeaderText = "Supplier";
          dataGridLabelColumn1.MappingName = "SupplierName";
          dataGridLabelColumn1.ReadOnly = true;
          dataGridLabelColumn1.Width = 130;
          dataGridLabelColumn1.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
          DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
          dataGridLabelColumn2.Format = "";
          dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn2.HeaderText = "Name";
          dataGridLabelColumn2.MappingName = "Name";
          dataGridLabelColumn2.ReadOnly = true;
          dataGridLabelColumn2.Width = 130;
          dataGridLabelColumn2.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
          DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
          dataGridLabelColumn3.Format = "";
          dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn3.HeaderText = "Part Number";
          dataGridLabelColumn3.MappingName = "Number";
          dataGridLabelColumn3.ReadOnly = true;
          dataGridLabelColumn3.Width = 130;
          dataGridLabelColumn3.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
          DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
          dataGridLabelColumn4.Format = "";
          dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn4.HeaderText = "Quantity In Pack";
          dataGridLabelColumn4.MappingName = "QuantityInPack";
          dataGridLabelColumn4.ReadOnly = true;
          dataGridLabelColumn4.Width = 130;
          dataGridLabelColumn4.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
          DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
          dataGridLabelColumn5.Format = "";
          dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn5.HeaderText = "Supplier Part Number";
          dataGridLabelColumn5.MappingName = "PartCode";
          dataGridLabelColumn5.ReadOnly = true;
          dataGridLabelColumn5.Width = 130;
          dataGridLabelColumn5.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
          DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
          dataGridLabelColumn6.Format = "";
          dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn6.HeaderText = "Price";
          dataGridLabelColumn6.MappingName = "Price";
          dataGridLabelColumn6.ReadOnly = true;
          dataGridLabelColumn6.Width = 130;
          dataGridLabelColumn6.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
          break;
        case Enums.TableNames.tblProductSupplier:
          DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
          dataGridLabelColumn7.Format = "";
          dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn7.HeaderText = "Supplier";
          dataGridLabelColumn7.MappingName = "SupplierName";
          dataGridLabelColumn7.ReadOnly = true;
          dataGridLabelColumn7.Width = 130;
          dataGridLabelColumn7.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
          DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
          dataGridLabelColumn8.Format = "";
          dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn8.HeaderText = "Name";
          dataGridLabelColumn8.MappingName = "typemakemodel";
          dataGridLabelColumn8.ReadOnly = true;
          dataGridLabelColumn8.Width = 130;
          dataGridLabelColumn8.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
          DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
          dataGridLabelColumn9.Format = "";
          dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn9.HeaderText = "Product Number";
          dataGridLabelColumn9.MappingName = "Number";
          dataGridLabelColumn9.ReadOnly = true;
          dataGridLabelColumn9.Width = 130;
          dataGridLabelColumn9.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
          DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
          dataGridLabelColumn10.Format = "";
          dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn10.HeaderText = "Quantity In Pack";
          dataGridLabelColumn10.MappingName = "QuantityInPack";
          dataGridLabelColumn10.ReadOnly = true;
          dataGridLabelColumn10.Width = 130;
          dataGridLabelColumn10.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
          DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
          dataGridLabelColumn11.Format = "";
          dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn11.HeaderText = "Supplier Product Number";
          dataGridLabelColumn11.MappingName = "ProductCode";
          dataGridLabelColumn11.ReadOnly = true;
          dataGridLabelColumn11.Width = 130;
          dataGridLabelColumn11.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
          DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
          dataGridLabelColumn12.Format = "";
          dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn12.HeaderText = "Price";
          dataGridLabelColumn12.MappingName = "Price";
          dataGridLabelColumn12.ReadOnly = true;
          dataGridLabelColumn12.Width = 130;
          dataGridLabelColumn12.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
          break;
      }
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }

    private void DLGPickPartProductSupplier_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void dgResults_DoubleClick(object sender, EventArgs e)
    {
      this.SelectItem();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.SelectItem();
    }

    private void SelectItem()
    {
      if (this.SelectedDataRow == null)
      {
        int num = (int) App.ShowMessage("No record selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        switch (this.TableToSearch)
        {
          case Enums.TableNames.tblPartSupplier:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["PartSupplierID"]));
            break;
          case Enums.TableNames.tblProductSupplier:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["ProductSupplierID"]));
            break;
        }
        this.DialogResult = DialogResult.OK;
      }
    }

    private void RunFilter()
    {
      string str = "Deleted = 0";
      if ((uint) this.txtFilter.Text.Trim().Length > 0U)
        str = str + " AND SupplierName LIKE '" + this.txtFilter.Text.Trim() + "%'";
      this.Records.RowFilter = str;
    }
  }
}
