// Decompiled with JetBrains decompiler
// Type: FSM.UCProduct
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Products;
using FSM.Entity.Sys;
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
  public class UCProduct : UCBase, IUserControl
  {
    private IContainer components;
    private Product _currentProduct;
    private bool _FromOrder;
    private DataView _ProductSuppliersDataview;
    private DataView _ProductAssociatedPartsDataview;

    public UCProduct()
    {
      this.Load += new EventHandler(this.UCProduct_Load);
      this._ProductSuppliersDataview = (DataView) null;
      this._ProductAssociatedPartsDataview = (DataView) null;
      this.InitializeComponent();
      ComboBox cboMakeId = this.cboMakeID;
      Combo.SetUpCombo(ref cboMakeId, App.DB.Picklists.GetAll(Enums.PickListTypes.Makes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboMakeID = cboMakeId;
      ComboBox cboModelId = this.cboModelID;
      Combo.SetUpCombo(ref cboModelId, App.DB.Picklists.GetAll(Enums.PickListTypes.Models, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboModelID = cboModelId;
      ComboBox cboTypeId = this.cboTypeID;
      Combo.SetUpCombo(ref cboTypeId, App.DB.Picklists.GetAll(Enums.PickListTypes.Types, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTypeID = cboTypeId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabMainDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpProduct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboMakeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMakeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboModelID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblModelID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabSuppliers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGrid dgProductSuppliers
    {
      get
      {
        return this._dgProductSuppliers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgProductSuppliers_DoubleClick);
        DataGrid productSuppliers1 = this._dgProductSuppliers;
        if (productSuppliers1 != null)
          productSuppliers1.DoubleClick -= eventHandler;
        this._dgProductSuppliers = value;
        DataGrid productSuppliers2 = this._dgProductSuppliers;
        if (productSuppliers2 == null)
          return;
        productSuppliers2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSellPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRecommendedQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMinimumQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAssociatedParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAssociatedParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssociatedParts
    {
      get
      {
        return this._dgAssociatedParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgAssociatedParts_DoubleClick);
        EventHandler eventHandler2 = new EventHandler(this.dgAssociatedParts_Clicks);
        DataGrid dgAssociatedParts1 = this._dgAssociatedParts;
        if (dgAssociatedParts1 != null)
        {
          dgAssociatedParts1.DoubleClick -= eventHandler1;
          dgAssociatedParts1.Click -= eventHandler2;
        }
        this._dgAssociatedParts = value;
        DataGrid dgAssociatedParts2 = this._dgAssociatedParts;
        if (dgAssociatedParts2 == null)
          return;
        dgAssociatedParts2.DoubleClick += eventHandler1;
        dgAssociatedParts2.Click += eventHandler2;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.TabControl1 = new TabControl();
      this.tabMainDetails = new TabPage();
      this.grpProduct = new GroupBox();
      this.txtReference = new TextBox();
      this.Label2 = new Label();
      this.txtRecommendedQuantity = new TextBox();
      this.Label6 = new Label();
      this.txtMinimumQuantity = new TextBox();
      this.Label5 = new Label();
      this.txtSellPrice = new TextBox();
      this.Label1 = new Label();
      this.txtNumber = new TextBox();
      this.lblNumber = new Label();
      this.cboTypeID = new ComboBox();
      this.lblTypeID = new Label();
      this.cboMakeID = new ComboBox();
      this.lblMakeID = new Label();
      this.cboModelID = new ComboBox();
      this.lblModelID = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.tabSuppliers = new TabPage();
      this.grpSupplier = new GroupBox();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.dgProductSuppliers = new DataGrid();
      this.tabAssociatedParts = new TabPage();
      this.grpAssociatedParts = new GroupBox();
      this.dgAssociatedParts = new DataGrid();
      this.TabControl1.SuspendLayout();
      this.tabMainDetails.SuspendLayout();
      this.grpProduct.SuspendLayout();
      this.tabSuppliers.SuspendLayout();
      this.grpSupplier.SuspendLayout();
      this.dgProductSuppliers.BeginInit();
      this.tabAssociatedParts.SuspendLayout();
      this.grpAssociatedParts.SuspendLayout();
      this.dgAssociatedParts.BeginInit();
      this.SuspendLayout();
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tabMainDetails);
      this.TabControl1.Controls.Add((Control) this.tabSuppliers);
      this.TabControl1.Controls.Add((Control) this.tabAssociatedParts);
      this.TabControl1.Location = new System.Drawing.Point(2, 7);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(633, 617);
      this.TabControl1.TabIndex = 0;
      this.tabMainDetails.Controls.Add((Control) this.grpProduct);
      this.tabMainDetails.Location = new System.Drawing.Point(4, 22);
      this.tabMainDetails.Name = "tabMainDetails";
      this.tabMainDetails.Size = new Size(625, 591);
      this.tabMainDetails.TabIndex = 0;
      this.tabMainDetails.Text = "Main Details";
      this.grpProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpProduct.Controls.Add((Control) this.txtReference);
      this.grpProduct.Controls.Add((Control) this.Label2);
      this.grpProduct.Controls.Add((Control) this.txtRecommendedQuantity);
      this.grpProduct.Controls.Add((Control) this.Label6);
      this.grpProduct.Controls.Add((Control) this.txtMinimumQuantity);
      this.grpProduct.Controls.Add((Control) this.Label5);
      this.grpProduct.Controls.Add((Control) this.txtSellPrice);
      this.grpProduct.Controls.Add((Control) this.Label1);
      this.grpProduct.Controls.Add((Control) this.txtNumber);
      this.grpProduct.Controls.Add((Control) this.lblNumber);
      this.grpProduct.Controls.Add((Control) this.cboTypeID);
      this.grpProduct.Controls.Add((Control) this.lblTypeID);
      this.grpProduct.Controls.Add((Control) this.cboMakeID);
      this.grpProduct.Controls.Add((Control) this.lblMakeID);
      this.grpProduct.Controls.Add((Control) this.cboModelID);
      this.grpProduct.Controls.Add((Control) this.lblModelID);
      this.grpProduct.Controls.Add((Control) this.txtNotes);
      this.grpProduct.Controls.Add((Control) this.lblNotes);
      this.grpProduct.Location = new System.Drawing.Point(8, 8);
      this.grpProduct.Name = "grpProduct";
      this.grpProduct.Size = new Size(606, 576);
      this.grpProduct.TabIndex = 0;
      this.grpProduct.TabStop = false;
      this.grpProduct.Text = "Details";
      this.txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtReference.Location = new System.Drawing.Point(160, 56);
      this.txtReference.MaxLength = 100;
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(433, 21);
      this.txtReference.TabIndex = 1;
      this.txtReference.Tag = (object) "Product.Reference";
      this.Label2.Location = new System.Drawing.Point(8, 56);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(97, 20);
      this.Label2.TabIndex = 46;
      this.Label2.Text = "Reference";
      this.txtRecommendedQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtRecommendedQuantity.Location = new System.Drawing.Point(160, 248);
      this.txtRecommendedQuantity.Name = "txtRecommendedQuantity";
      this.txtRecommendedQuantity.Size = new Size(433, 21);
      this.txtRecommendedQuantity.TabIndex = 7;
      this.Label6.Location = new System.Drawing.Point(8, 246);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(152, 24);
      this.Label6.TabIndex = 44;
      this.Label6.Text = "Maximum Quantity";
      this.txtMinimumQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtMinimumQuantity.Location = new System.Drawing.Point(160, 216);
      this.txtMinimumQuantity.Name = "txtMinimumQuantity";
      this.txtMinimumQuantity.Size = new Size(433, 21);
      this.txtMinimumQuantity.TabIndex = 6;
      this.Label5.Location = new System.Drawing.Point(8, 218);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(120, 16);
      this.Label5.TabIndex = 42;
      this.Label5.Text = "Minimum Quantity";
      this.txtSellPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSellPrice.Location = new System.Drawing.Point(160, 184);
      this.txtSellPrice.Name = "txtSellPrice";
      this.txtSellPrice.Size = new Size(433, 21);
      this.txtSellPrice.TabIndex = 5;
      this.Label1.Location = new System.Drawing.Point(8, 183);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 23);
      this.Label1.TabIndex = 32;
      this.Label1.Text = "Sell Price";
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNumber.Location = new System.Drawing.Point(160, 24);
      this.txtNumber.MaxLength = 100;
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new Size(433, 21);
      this.txtNumber.TabIndex = 0;
      this.txtNumber.Tag = (object) "Product.Number";
      this.lblNumber.Location = new System.Drawing.Point(8, 24);
      this.lblNumber.Name = "lblNumber";
      this.lblNumber.Size = new Size(120, 20);
      this.lblNumber.TabIndex = 31;
      this.lblNumber.Text = "GC Number";
      this.cboTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboTypeID.Cursor = Cursors.Hand;
      this.cboTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTypeID.Location = new System.Drawing.Point(160, 88);
      this.cboTypeID.Name = "cboTypeID";
      this.cboTypeID.Size = new Size(433, 21);
      this.cboTypeID.TabIndex = 2;
      this.cboTypeID.Tag = (object) "Product.TypeID";
      this.lblTypeID.Location = new System.Drawing.Point(8, 88);
      this.lblTypeID.Name = "lblTypeID";
      this.lblTypeID.Size = new Size(46, 20);
      this.lblTypeID.TabIndex = 31;
      this.lblTypeID.Text = "Type ";
      this.cboMakeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboMakeID.Cursor = Cursors.Hand;
      this.cboMakeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboMakeID.Location = new System.Drawing.Point(160, 120);
      this.cboMakeID.Name = "cboMakeID";
      this.cboMakeID.Size = new Size(433, 21);
      this.cboMakeID.TabIndex = 3;
      this.cboMakeID.Tag = (object) "Product.MakeID";
      this.lblMakeID.Location = new System.Drawing.Point(8, 120);
      this.lblMakeID.Name = "lblMakeID";
      this.lblMakeID.Size = new Size(47, 20);
      this.lblMakeID.TabIndex = 31;
      this.lblMakeID.Text = "Make ";
      this.cboModelID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboModelID.Cursor = Cursors.Hand;
      this.cboModelID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboModelID.Location = new System.Drawing.Point(160, 152);
      this.cboModelID.Name = "cboModelID";
      this.cboModelID.Size = new Size(433, 21);
      this.cboModelID.TabIndex = 4;
      this.cboModelID.Tag = (object) "Product.ModelID";
      this.lblModelID.Location = new System.Drawing.Point(8, 152);
      this.lblModelID.Name = "lblModelID";
      this.lblModelID.Size = new Size(48, 20);
      this.lblModelID.TabIndex = 31;
      this.lblModelID.Text = "Model ";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(160, 280);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(433, 283);
      this.txtNotes.TabIndex = 8;
      this.txtNotes.Tag = (object) "Product.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 280);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(48, 20);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.tabSuppliers.Controls.Add((Control) this.grpSupplier);
      this.tabSuppliers.Location = new System.Drawing.Point(4, 22);
      this.tabSuppliers.Name = "tabSuppliers";
      this.tabSuppliers.Size = new Size(625, 591);
      this.tabSuppliers.TabIndex = 1;
      this.tabSuppliers.Text = "Suppliers";
      this.grpSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSupplier.Controls.Add((Control) this.btnDelete);
      this.grpSupplier.Controls.Add((Control) this.btnAdd);
      this.grpSupplier.Controls.Add((Control) this.dgProductSuppliers);
      this.grpSupplier.Location = new System.Drawing.Point(7, 8);
      this.grpSupplier.Name = "grpSupplier";
      this.grpSupplier.Size = new Size(612, 577);
      this.grpSupplier.TabIndex = 0;
      this.grpSupplier.TabStop = false;
      this.grpSupplier.Text = "Suppliers of this product";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(537, 544);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(64, 23);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Remove";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(8, 543);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(64, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.dgProductSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgProductSuppliers.DataMember = "";
      this.dgProductSuppliers.HeaderForeColor = SystemColors.ControlText;
      this.dgProductSuppliers.Location = new System.Drawing.Point(9, 28);
      this.dgProductSuppliers.Name = "dgProductSuppliers";
      this.dgProductSuppliers.Size = new Size(593, 469);
      this.dgProductSuppliers.TabIndex = 1;
      this.tabAssociatedParts.Controls.Add((Control) this.grpAssociatedParts);
      this.tabAssociatedParts.Location = new System.Drawing.Point(4, 22);
      this.tabAssociatedParts.Name = "tabAssociatedParts";
      this.tabAssociatedParts.Size = new Size(625, 591);
      this.tabAssociatedParts.TabIndex = 2;
      this.tabAssociatedParts.Text = "Associated Parts";
      this.grpAssociatedParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAssociatedParts.Controls.Add((Control) this.dgAssociatedParts);
      this.grpAssociatedParts.Location = new System.Drawing.Point(7, 8);
      this.grpAssociatedParts.Name = "grpAssociatedParts";
      this.grpAssociatedParts.Size = new Size(612, 577);
      this.grpAssociatedParts.TabIndex = 1;
      this.grpAssociatedParts.TabStop = false;
      this.grpAssociatedParts.Text = "Associated parts of this product";
      this.dgAssociatedParts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssociatedParts.DataMember = "";
      this.dgAssociatedParts.HeaderForeColor = SystemColors.ControlText;
      this.dgAssociatedParts.Location = new System.Drawing.Point(9, 28);
      this.dgAssociatedParts.Name = "dgAssociatedParts";
      this.dgAssociatedParts.Size = new Size(593, 542);
      this.dgAssociatedParts.TabIndex = 1;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCProduct);
      this.Size = new Size(640, 628);
      this.TabControl1.ResumeLayout(false);
      this.tabMainDetails.ResumeLayout(false);
      this.grpProduct.ResumeLayout(false);
      this.grpProduct.PerformLayout();
      this.tabSuppliers.ResumeLayout(false);
      this.grpSupplier.ResumeLayout(false);
      this.dgProductSuppliers.EndInit();
      this.tabAssociatedParts.ResumeLayout(false);
      this.grpAssociatedParts.ResumeLayout(false);
      this.dgAssociatedParts.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupSuppliersDatagrid();
      this.SetupAssociateDatagrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentProduct;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Product CurrentProduct
    {
      get
      {
        return this._currentProduct;
      }
      set
      {
        this._currentProduct = value;
        if (this.CurrentProduct == null)
        {
          this.CurrentProduct = new Product();
          this.CurrentProduct.Exists = false;
          this.btnAdd.Enabled = false;
          this.btnDelete.Enabled = false;
        }
        if (this.CurrentProduct.Exists)
        {
          this.Populate(0);
          this.btnAdd.Enabled = true;
          this.btnDelete.Enabled = true;
        }
        this.PopulateSuppliers();
      }
    }

    public bool FromOrder
    {
      get
      {
        return this._FromOrder;
      }
      set
      {
        this._FromOrder = value;
      }
    }

    public DataView ProductSuppliersDataView
    {
      get
      {
        return this._ProductSuppliersDataview;
      }
      set
      {
        this._ProductSuppliersDataview = value;
        this._ProductSuppliersDataview.Table.TableName = Enums.TableNames.tblProductSupplier.ToString();
        this._ProductSuppliersDataview.AllowNew = false;
        this._ProductSuppliersDataview.AllowEdit = false;
        this._ProductSuppliersDataview.AllowDelete = false;
        this.dgProductSuppliers.DataSource = (object) this.ProductSuppliersDataView;
      }
    }

    private DataRow SelectedProductSupplierDataRow
    {
      get
      {
        return this.dgProductSuppliers.CurrentRowIndex != -1 ? this.ProductSuppliersDataView[this.dgProductSuppliers.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ProductAssociatedPartsDataview
    {
      get
      {
        return this._ProductAssociatedPartsDataview;
      }
      set
      {
        this._ProductAssociatedPartsDataview = value;
        if (this._ProductAssociatedPartsDataview != null)
        {
          this._ProductAssociatedPartsDataview.Table.TableName = Enums.TableNames.tblProductAssociatedPart.ToString();
          this._ProductAssociatedPartsDataview.AllowNew = false;
          this._ProductAssociatedPartsDataview.AllowEdit = true;
          this._ProductAssociatedPartsDataview.AllowDelete = false;
        }
        this.dgAssociatedParts.DataSource = (object) this.ProductAssociatedPartsDataview;
      }
    }

    private DataRow SelectedProductAssociatedPartDataRow
    {
      get
      {
        return this.dgAssociatedParts.CurrentRowIndex != -1 ? this.ProductAssociatedPartsDataview[this.dgAssociatedParts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupSuppliersDatagrid()
    {
      Helper.SetUpDataGrid(this.dgProductSuppliers, false);
      DataGridTableStyle tableStyle = this.dgProductSuppliers.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
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
      dataGridLabelColumn2.HeaderText = "Supplier Product Code";
      dataGridLabelColumn2.MappingName = "ProductCode";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Supplier Price";
      dataGridLabelColumn3.MappingName = "Price";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 85;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Quantity In Pack";
      dataGridLabelColumn4.MappingName = "QuantityInPack";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 110;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblProductSupplier.ToString();
      this.dgProductSuppliers.TableStyles.Add(tableStyle);
    }

    public void SetupAssociateDatagrid()
    {
      Helper.SetUpDataGrid(this.dgAssociatedParts, false);
      DataGridTableStyle tableStyle = this.dgAssociatedParts.TableStyles[0];
      this.dgAssociatedParts.ReadOnly = false;
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
      dataGridLabelColumn1.HeaderText = "Part Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Part Number";
      dataGridLabelColumn2.MappingName = "Number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part Reference";
      dataGridLabelColumn3.MappingName = "Reference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 130;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.MappingName = Enums.TableNames.tblProductAssociatedPart.ToString();
      this.dgAssociatedParts.TableStyles.Add(tableStyle);
    }

    private void UCProduct_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgProductSuppliers_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedProductSupplierDataRow == null)
        return;
      App.ShowForm(typeof (FRMProductSupplier), true, new object[3]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductSupplierDataRow["ProductSupplierID"])),
        (object) this.CurrentProduct.ProductID,
        (object) this
      }, false);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMProductSupplier), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentProduct.ProductID,
        (object) this
      }, false);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedProductSupplierDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.ProductSupplier.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductSupplierDataRow["ProductSupplierID"])));
        this.ProductSuppliersDataView = App.DB.ProductSupplier.Get_ByProductID(this.CurrentProduct.ProductID);
      }
    }

    private void dgAssociatedParts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedProductAssociatedPartDataRow == null)
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductAssociatedPartDataRow["PartID"])),
        (object) true
      }, false);
      this.ProductAssociatedPartsDataview = App.DB.ProductAssociatedPart.GetAll_For_ProductID(this.CurrentProduct.ProductID);
    }

    private void dgAssociatedParts_Clicks(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedProductAssociatedPartDataRow == null)
          return;
        this.dgAssociatedParts[this.dgAssociatedParts.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgAssociatedParts[this.dgAssociatedParts.CurrentRowIndex, 0]);
        App.AnythingChanges(RuntimeHelpers.GetObjectValue(sender), e);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void PopulateSuppliers()
    {
      this.ProductSuppliersDataView = App.DB.ProductSupplier.Get_ByProductID(this.CurrentProduct.ProductID);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentProduct = App.DB.Product.Product_Get(ID);
      this.txtNumber.Text = this.CurrentProduct.Number;
      this.txtReference.Text = this.CurrentProduct.Reference;
      this.txtSellPrice.Text = Conversions.ToString(this.CurrentProduct.SellPrice);
      ComboBox cboTypeId = this.cboTypeID;
      Combo.SetSelectedComboItem_By_Value(ref cboTypeId, Conversions.ToString(this.CurrentProduct.TypeID));
      this.cboTypeID = cboTypeId;
      ComboBox cboMakeId = this.cboMakeID;
      Combo.SetSelectedComboItem_By_Value(ref cboMakeId, Conversions.ToString(this.CurrentProduct.MakeID));
      this.cboMakeID = cboMakeId;
      ComboBox cboModelId = this.cboModelID;
      Combo.SetSelectedComboItem_By_Value(ref cboModelId, Conversions.ToString(this.CurrentProduct.ModelID));
      this.cboModelID = cboModelId;
      this.txtNotes.Text = this.CurrentProduct.Notes;
      this.txtMinimumQuantity.Text = Conversions.ToString(this.CurrentProduct.MinimumQuantity);
      this.txtRecommendedQuantity.Text = Conversions.ToString(this.CurrentProduct.RecommendedQuantity);
      this.ProductAssociatedPartsDataview = this.CurrentProduct.AssociatedPart;
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentProduct.IgnoreExceptionsOnSetMethods = true;
        this.CurrentProduct.SetNumber = (object) this.txtNumber.Text.Trim();
        this.CurrentProduct.SetReference = (object) this.txtReference.Text.Trim();
        this.CurrentProduct.SetTypeID = (object) Combo.get_GetSelectedItemValue(this.cboTypeID);
        this.CurrentProduct.SetMakeID = (object) Combo.get_GetSelectedItemValue(this.cboMakeID);
        this.CurrentProduct.SetModelID = (object) Combo.get_GetSelectedItemValue(this.cboModelID);
        this.CurrentProduct.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentProduct.SetSellPrice = (object) this.txtSellPrice.Text.Trim();
        this.CurrentProduct.SetMinimumQuantity = (object) Helper.MakeIntegerValid((object) this.txtMinimumQuantity.Text.Trim());
        this.CurrentProduct.SetRecommendedQuantity = (object) Helper.MakeIntegerValid((object) this.txtRecommendedQuantity.Text.Trim());
        this.CurrentProduct.AssociatedPart = this.ProductAssociatedPartsDataview;
        new ProductValidator().Validate(this.CurrentProduct);
        if (this.CurrentProduct.Exists)
          App.DB.Product.Update(this.CurrentProduct);
        else
          this.CurrentProduct = App.DB.Product.Insert(this.CurrentProduct);
        if (!this.FromOrder)
        {
          // ISSUE: reference to a compiler-generated field
          IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
          if (recordsChangedEvent != null)
            recordsChangedEvent(App.DB.Product.Product_GetAll(), Enums.PageViewing.Product, true, false, "");
          App.MainForm.RefreshEntity(this.CurrentProduct.ProductID, "");
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentProduct.ProductID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
