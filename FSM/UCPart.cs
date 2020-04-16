// Decompiled with JetBrains decompiler
// Type: FSM.UCPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Parts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCPart : UCBase, IUserControl
  {
    private IContainer components;
    private bool _FromOrder;
    private DataView _partSupplierDataview;
    private DataView _StockDataview;
    private Part _currentPart;
    private DataView _partQuantitiesDataview;

    public UCPart()
    {
      this.Load += new EventHandler(this.UCPart_Load);
      this._partSupplierDataview = (DataView) null;
      this._StockDataview = (DataView) null;
      this._partQuantitiesDataview = (DataView) null;
      this.InitializeComponent();
      ComboBox cboUnitType = this.cboUnitType;
      Combo.SetUpCombo(ref cboUnitType, App.DB.Picklists.GetAll(Enums.PickListTypes.UnitTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboUnitType = cboUnitType;
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCategory = cboCategory;
      ComboBox cboFuel = this.cboFuel;
      Combo.SetUpCombo(ref cboFuel, App.DB.Picklists.GetAll(Enums.PickListTypes.GasTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboFuel = cboFuel;
      ComboBox cboManufacturer = this.cboManufacturer;
      Combo.SetUpCombo(ref cboManufacturer, App.DB.Picklists.GetAll(Enums.PickListTypes.Makes, false).Table, "ManagerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboManufacturer = cboManufacturer;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabSuppliers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSellPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUnitType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartSuppliers
    {
      get
      {
        return this._dgPartSuppliers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgPartSuppliers_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgPartSuppliers_DoubleClick);
        DataGrid dgPartSuppliers1 = this._dgPartSuppliers;
        if (dgPartSuppliers1 != null)
        {
          dgPartSuppliers1.MouseUp -= mouseEventHandler;
          dgPartSuppliers1.DoubleClick -= eventHandler;
        }
        this._dgPartSuppliers = value;
        DataGrid dgPartSuppliers2 = this._dgPartSuppliers;
        if (dgPartSuppliers2 == null)
          return;
        dgPartSuppliers2.MouseUp += mouseEventHandler;
        dgPartSuppliers2.DoubleClick += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkEndFlagged { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpQuantities { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgQuantities { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboManufacturer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.TabControl1 = new TabControl();
      this.tabDetails = new TabPage();
      this.grpPart = new GroupBox();
      this.cboFuel = new ComboBox();
      this.Label5 = new Label();
      this.chkEndFlagged = new CheckBox();
      this.Label14 = new Label();
      this.Label8 = new Label();
      this.cboCategory = new ComboBox();
      this.Label7 = new Label();
      this.txtReference = new TextBox();
      this.txtSellPrice = new TextBox();
      this.Label4 = new Label();
      this.cboUnitType = new ComboBox();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.tabSuppliers = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.dgPartSuppliers = new DataGrid();
      this.tpQuantities = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.dgQuantities = new DataGrid();
      this.tpStock = new TabPage();
      this.grpStock = new GroupBox();
      this.dgStock = new DataGrid();
      this.Label6 = new Label();
      this.cboManufacturer = new ComboBox();
      this.TabControl1.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.grpPart.SuspendLayout();
      this.tabSuppliers.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgPartSuppliers.BeginInit();
      this.tpQuantities.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.dgQuantities.BeginInit();
      this.tpStock.SuspendLayout();
      this.grpStock.SuspendLayout();
      this.dgStock.BeginInit();
      this.SuspendLayout();
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tabDetails);
      this.TabControl1.Controls.Add((Control) this.tabSuppliers);
      this.TabControl1.Controls.Add((Control) this.tpQuantities);
      this.TabControl1.Controls.Add((Control) this.tpStock);
      this.TabControl1.Location = new System.Drawing.Point(1, 5);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(632, 638);
      this.TabControl1.TabIndex = 0;
      this.tabDetails.Controls.Add((Control) this.grpPart);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(624, 612);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPart.Controls.Add((Control) this.cboManufacturer);
      this.grpPart.Controls.Add((Control) this.Label6);
      this.grpPart.Controls.Add((Control) this.cboFuel);
      this.grpPart.Controls.Add((Control) this.Label5);
      this.grpPart.Controls.Add((Control) this.chkEndFlagged);
      this.grpPart.Controls.Add((Control) this.Label14);
      this.grpPart.Controls.Add((Control) this.Label8);
      this.grpPart.Controls.Add((Control) this.cboCategory);
      this.grpPart.Controls.Add((Control) this.Label7);
      this.grpPart.Controls.Add((Control) this.txtReference);
      this.grpPart.Controls.Add((Control) this.txtSellPrice);
      this.grpPart.Controls.Add((Control) this.Label4);
      this.grpPart.Controls.Add((Control) this.cboUnitType);
      this.grpPart.Controls.Add((Control) this.Label3);
      this.grpPart.Controls.Add((Control) this.Label2);
      this.grpPart.Controls.Add((Control) this.Label1);
      this.grpPart.Controls.Add((Control) this.txtName);
      this.grpPart.Controls.Add((Control) this.txtNumber);
      this.grpPart.Controls.Add((Control) this.txtNotes);
      this.grpPart.Controls.Add((Control) this.lblNotes);
      this.grpPart.Location = new System.Drawing.Point(8, 8);
      this.grpPart.Name = "grpPart";
      this.grpPart.Size = new Size(609, 595);
      this.grpPart.TabIndex = 0;
      this.grpPart.TabStop = false;
      this.grpPart.Text = "Main Details";
      this.cboFuel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboFuel.Location = new System.Drawing.Point(160, 213);
      this.cboFuel.Name = "cboFuel";
      this.cboFuel.Size = new Size(436, 21);
      this.cboFuel.TabIndex = 57;
      this.Label5.Location = new System.Drawing.Point(8, 212);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(62, 23);
      this.Label5.TabIndex = 58;
      this.Label5.Text = "Fuel";
      this.chkEndFlagged.Location = new System.Drawing.Point(160, 356);
      this.chkEndFlagged.Name = "chkEndFlagged";
      this.chkEndFlagged.Size = new Size(92, 24);
      this.chkEndFlagged.TabIndex = 17;
      this.chkEndFlagged.UseVisualStyleBackColor = true;
      this.Label14.Location = new System.Drawing.Point(8, 356);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(152, 24);
      this.Label14.TabIndex = 56;
      this.Label14.Text = "End Flagged";
      this.Label8.Location = new System.Drawing.Point(8, 56);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(64, 21);
      this.Label8.TabIndex = 44;
      this.Label8.Text = "Category";
      this.cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboCategory.Location = new System.Drawing.Point(160, 57);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(436, 21);
      this.cboCategory.TabIndex = 1;
      this.Label7.Location = new System.Drawing.Point(8, 120);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(109, 21);
      this.Label7.TabIndex = 42;
      this.Label7.Text = "Reference (GPN)";
      this.txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtReference.Location = new System.Drawing.Point(160, 120);
      this.txtReference.MaxLength = 100;
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(436, 21);
      this.txtReference.TabIndex = 3;
      this.txtReference.Tag = (object) "Part.Reference";
      this.txtSellPrice.Location = new System.Drawing.Point(160, 324);
      this.txtSellPrice.Name = "txtSellPrice";
      this.txtSellPrice.Size = new Size(104, 21);
      this.txtSellPrice.TabIndex = 13;
      this.Label4.Location = new System.Drawing.Point(8, 323);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(63, 23);
      this.Label4.TabIndex = 36;
      this.Label4.Text = "Sell Price";
      this.cboUnitType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUnitType.Location = new System.Drawing.Point(160, 153);
      this.cboUnitType.Name = "cboUnitType";
      this.cboUnitType.Size = new Size(436, 21);
      this.cboUnitType.TabIndex = 4;
      this.Label3.Location = new System.Drawing.Point(8, 152);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(62, 23);
      this.Label3.TabIndex = 34;
      this.Label3.Text = "Unit Type";
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(57, 21);
      this.Label2.TabIndex = 33;
      this.Label2.Text = "Name";
      this.Label1.Location = new System.Drawing.Point(8, 88);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 21);
      this.Label1.TabIndex = 32;
      this.Label1.Text = "Number (MPN)";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(160, 26);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(436, 21);
      this.txtName.TabIndex = 0;
      this.txtName.Tag = (object) "Part.Name";
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNumber.Location = new System.Drawing.Point(160, 89);
      this.txtNumber.MaxLength = 100;
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new Size(436, 21);
      this.txtNumber.TabIndex = 2;
      this.txtNumber.Tag = (object) "Part.Number";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(160, 413);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(436, 176);
      this.txtNotes.TabIndex = 19;
      this.txtNotes.Tag = (object) "Part.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 413);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(57, 21);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.tabSuppliers.Controls.Add((Control) this.GroupBox1);
      this.tabSuppliers.Location = new System.Drawing.Point(4, 22);
      this.tabSuppliers.Name = "tabSuppliers";
      this.tabSuppliers.Size = new Size(624, 612);
      this.tabSuppliers.TabIndex = 1;
      this.tabSuppliers.Text = "Suppliers";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.btnDelete);
      this.GroupBox1.Controls.Add((Control) this.btnAdd);
      this.GroupBox1.Controls.Add((Control) this.dgPartSuppliers);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(609, 595);
      this.GroupBox1.TabIndex = 1;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Suppliers of this part";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(537, 563);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(64, 23);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Remove";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(8, 563);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(64, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.dgPartSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartSuppliers.DataMember = "";
      this.dgPartSuppliers.HeaderForeColor = SystemColors.ControlText;
      this.dgPartSuppliers.Location = new System.Drawing.Point(8, 27);
      this.dgPartSuppliers.Name = "dgPartSuppliers";
      this.dgPartSuppliers.Size = new Size(593, 530);
      this.dgPartSuppliers.TabIndex = 1;
      this.tpQuantities.Controls.Add((Control) this.GroupBox2);
      this.tpQuantities.Location = new System.Drawing.Point(4, 22);
      this.tpQuantities.Name = "tpQuantities";
      this.tpQuantities.Padding = new Padding(3);
      this.tpQuantities.Size = new Size(624, 612);
      this.tpQuantities.TabIndex = 3;
      this.tpQuantities.Text = "Min / Max Quantities";
      this.tpQuantities.UseVisualStyleBackColor = true;
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.dgQuantities);
      this.GroupBox2.Location = new System.Drawing.Point(8, 9);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(609, 595);
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Min /Max quantities held per location";
      this.dgQuantities.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgQuantities.DataMember = "";
      this.dgQuantities.HeaderForeColor = SystemColors.ControlText;
      this.dgQuantities.Location = new System.Drawing.Point(8, 20);
      this.dgQuantities.Name = "dgQuantities";
      this.dgQuantities.Size = new Size(593, 569);
      this.dgQuantities.TabIndex = 1;
      this.tpStock.Controls.Add((Control) this.grpStock);
      this.tpStock.Location = new System.Drawing.Point(4, 22);
      this.tpStock.Name = "tpStock";
      this.tpStock.Padding = new Padding(3);
      this.tpStock.Size = new Size(624, 612);
      this.tpStock.TabIndex = 2;
      this.tpStock.Text = "Stock Locations";
      this.tpStock.UseVisualStyleBackColor = true;
      this.grpStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpStock.Controls.Add((Control) this.dgStock);
      this.grpStock.Location = new System.Drawing.Point(8, 9);
      this.grpStock.Name = "grpStock";
      this.grpStock.Size = new Size(609, 595);
      this.grpStock.TabIndex = 2;
      this.grpStock.TabStop = false;
      this.grpStock.Text = "Locations of this part";
      this.dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStock.DataMember = "";
      this.dgStock.HeaderForeColor = SystemColors.ControlText;
      this.dgStock.Location = new System.Drawing.Point(8, 20);
      this.dgStock.Name = "dgStock";
      this.dgStock.Size = new Size(593, 569);
      this.dgStock.TabIndex = 1;
      this.Label6.Location = new System.Drawing.Point(8, 181);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(121, 21);
      this.Label6.TabIndex = 60;
      this.Label6.Text = "Manufacturer";
      this.cboManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboManufacturer.Location = new System.Drawing.Point(160, 183);
      this.cboManufacturer.Name = "cboManufacturer";
      this.cboManufacturer.Size = new Size(436, 21);
      this.cboManufacturer.TabIndex = 61;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCPart);
      this.Size = new Size(640, 648);
      this.TabControl1.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.grpPart.ResumeLayout(false);
      this.grpPart.PerformLayout();
      this.tabSuppliers.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.dgPartSuppliers.EndInit();
      this.tpQuantities.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.dgQuantities.EndInit();
      this.tpStock.ResumeLayout(false);
      this.grpStock.ResumeLayout(false);
      this.dgStock.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupSuppliersDatagrid();
      this.SetupStockDatagrid();
      this.SetupQuantityDatagrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentPart;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

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

    public DataView PartSuppliersDataView
    {
      get
      {
        return this._partSupplierDataview;
      }
      set
      {
        this._partSupplierDataview = value;
        this._partSupplierDataview.Table.TableName = Enums.TableNames.tblPartSupplier.ToString();
        this._partSupplierDataview.AllowNew = false;
        this._partSupplierDataview.AllowEdit = true;
        this._partSupplierDataview.AllowDelete = false;
        this.dgPartSuppliers.DataSource = (object) this.PartSuppliersDataView;
      }
    }

    private DataRow SelectedPartSupplierDataRow
    {
      get
      {
        return this.dgPartSuppliers.CurrentRowIndex != -1 ? this.PartSuppliersDataView[this.dgPartSuppliers.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView StockDataview
    {
      get
      {
        return this._StockDataview;
      }
      set
      {
        this._StockDataview = value;
        this._StockDataview.Table.TableName = Enums.TableNames.tblStock.ToString();
        this._StockDataview.AllowNew = false;
        this._StockDataview.AllowEdit = true;
        this._StockDataview.AllowDelete = false;
        this.dgStock.DataSource = (object) this.StockDataview;
      }
    }

    public Part CurrentPart
    {
      get
      {
        return this._currentPart;
      }
      set
      {
        this._currentPart = value;
        if (this.CurrentPart == null)
        {
          this.CurrentPart = new Part();
          this.CurrentPart.Exists = false;
          this.btnAdd.Enabled = false;
          this.btnDelete.Enabled = false;
        }
        if (this.CurrentPart.Exists)
        {
          this.Populate(0);
          this.btnAdd.Enabled = true;
          this.btnDelete.Enabled = true;
        }
        this.PopulateSuppliers();
        this.PopulateStock();
        this.PopulateQuantities();
      }
    }

    public DataView PartQuantitiesDataview
    {
      get
      {
        return this._partQuantitiesDataview;
      }
      set
      {
        this._partQuantitiesDataview = value;
        this._partQuantitiesDataview.Table.TableName = Enums.TableNames.tblPartLocations.ToString();
        this._partQuantitiesDataview.AllowNew = false;
        this._partQuantitiesDataview.AllowEdit = true;
        this._partQuantitiesDataview.AllowDelete = false;
        this.dgQuantities.DataSource = (object) this.PartQuantitiesDataview;
      }
    }

    private DataRow SelectedPartQuantityDataRow
    {
      get
      {
        return this.dgQuantities.CurrentRowIndex != -1 ? this.PartQuantitiesDataview[this.dgQuantities.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupSuppliersDatagrid()
    {
      Helper.SetUpDataGrid(this.dgPartSuppliers, false);
      DataGridTableStyle tableStyle = this.dgPartSuppliers.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgPartSuppliers.ReadOnly = false;
      this.dgPartSuppliers.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Preferred";
      dataGridBoolColumn.MappingName = "Preferred";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
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
      dataGridLabelColumn2.HeaderText = "Supplier Part Code (SPN)";
      dataGridLabelColumn2.MappingName = "PartCode";
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
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Updated By";
      dataGridLabelColumn5.MappingName = "UpdatedBy";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy HH:mm:ss";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Updated On";
      dataGridLabelColumn6.MappingName = "UpdatedOn";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "dd/MM/yyyy";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Primary Price Updated On";
      dataGridLabelColumn7.MappingName = "PrimaryPriceUpdateDateTime";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 150;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "dd/MM/yyyy";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Secondary Price Updated On";
      dataGridLabelColumn8.MappingName = "SecondaryPriceUpdateDateTime";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 150;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      tableStyle.MappingName = Enums.TableNames.tblPartSupplier.ToString();
      this.dgPartSuppliers.TableStyles.Add(tableStyle);
    }

    public void SetupStockDatagrid()
    {
      Helper.SetUpDataGrid(this.dgStock, false);
      DataGridTableStyle tableStyle = this.dgStock.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Qty";
      dataGridLabelColumn3.MappingName = "Quantity";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblStock.ToString();
      this.dgStock.TableStyles.Add(tableStyle);
    }

    public void SetupQuantityDatagrid()
    {
      Helper.SetUpDataGrid(this.dgQuantities, false);
      DataGridTableStyle tableStyle = this.dgQuantities.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgQuantities.AllowSorting = false;
      this.dgQuantities.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Location";
      dataGridLabelColumn.MappingName = "Location";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 250;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridEditableTextBoxColumn editableTextBoxColumn1 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn1.Format = "";
      editableTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn1.HeaderText = "Minimum";
      editableTextBoxColumn1.MappingName = "MinQty";
      editableTextBoxColumn1.ReadOnly = false;
      editableTextBoxColumn1.Width = 75;
      editableTextBoxColumn1.NullText = "";
      editableTextBoxColumn1.BackColourBrush = Brushes.LightYellow;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn1);
      DataGridEditableTextBoxColumn editableTextBoxColumn2 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn2.Format = "";
      editableTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn2.HeaderText = "Maximum";
      editableTextBoxColumn2.MappingName = "RecQty";
      editableTextBoxColumn2.ReadOnly = false;
      editableTextBoxColumn2.Width = 75;
      editableTextBoxColumn2.NullText = "";
      editableTextBoxColumn2.BackColourBrush = Brushes.LightYellow;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn2);
      tableStyle.MappingName = Enums.TableNames.tblPartLocations.ToString();
      this.dgQuantities.TableStyles.Add(tableStyle);
    }

    private void UCPart_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgPartSuppliers_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgPartSuppliers.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgPartSuppliers.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedPartSupplierDataRow == null)
          return;
        bool Preferred = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgPartSuppliers[this.dgPartSuppliers.CurrentRowIndex, 0]));
        App.DB.PartSupplier.Update_Preferred(Conversions.ToInteger(this.SelectedPartSupplierDataRow["PartSupplierID"]), Preferred);
        this.PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(this.CurrentPart.PartID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgPartSuppliers_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedPartSupplierDataRow == null)
        return;
      App.ShowForm(typeof (FRMPartSupplier), true, new object[3]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartSupplierDataRow["PartSupplierID"])),
        (object) this.CurrentPart.PartID,
        (object) this
      }, false);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      Enums.SecuritySystemModules ssm1 = Enums.SecuritySystemModules.EditParts;
      Enums.SecuritySystemModules ssm2 = Enums.SecuritySystemModules.CreateParts;
      if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
        return;
      App.ShowForm(typeof (FRMPartSupplier), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentPart.PartID,
        (object) this
      }, false);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedPartSupplierDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        Enums.SecuritySystemModules ssm1 = Enums.SecuritySystemModules.EditParts;
        Enums.SecuritySystemModules ssm2 = Enums.SecuritySystemModules.CreateParts;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "SELECT COUNT(*) AS Expr1 FROM tblOrderPart WHERE (PartSupplierID = ", this.SelectedPartSupplierDataRow["PartSupplierID"]), (object) ") AND (EngineerReceivedOn IS NULL) AND (Deleted = 0)")), true, false));
        if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.PartSupplier.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartSupplierDataRow["PartSupplierID"])));
        this.PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(this.CurrentPart.PartID);
      }
    }

    public void PopulateSuppliers()
    {
      this.PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(this.CurrentPart.PartID);
    }

    public void PopulateStock()
    {
      this.StockDataview = App.DB.Part.Stock_Get_Locations(this.CurrentPart.PartID, 0);
    }

    public void PopulateQuantities()
    {
      this.PartQuantitiesDataview = App.DB.Part.Part_Locations_Get(this.CurrentPart.PartID);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentPart = App.DB.Part.Part_Get(ID);
      this.txtName.Text = this.CurrentPart.Name;
      this.txtNumber.Text = this.CurrentPart.Number;
      this.txtReference.Text = this.CurrentPart.Reference;
      this.txtNotes.Text = this.CurrentPart.Notes;
      this.txtSellPrice.Text = Conversions.ToString(this.CurrentPart.SellPrice);
      ComboBox cboUnitType = this.cboUnitType;
      Combo.SetSelectedComboItem_By_Value(ref cboUnitType, Conversions.ToString(this.CurrentPart.UnitTypeID));
      this.cboUnitType = cboUnitType;
      ComboBox cboCategory = this.cboCategory;
      Combo.SetSelectedComboItem_By_Value(ref cboCategory, Conversions.ToString(this.CurrentPart.CategoryID));
      this.cboCategory = cboCategory;
      ComboBox cboFuel = this.cboFuel;
      Combo.SetSelectedComboItem_By_Value(ref cboFuel, Conversions.ToString(this.CurrentPart.FuelID));
      this.cboFuel = cboFuel;
      ComboBox cboManufacturer = this.cboManufacturer;
      Combo.SetSelectedComboItem_By_Value(ref cboManufacturer, Conversions.ToString(this.CurrentPart.MakeID));
      this.cboManufacturer = cboManufacturer;
      this.chkEndFlagged.Checked = this.CurrentPart.EndFlagged;
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        Enums.SecuritySystemModules ssm1 = Enums.SecuritySystemModules.EditParts;
        Enums.SecuritySystemModules ssm2 = Enums.SecuritySystemModules.CreateParts;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        if (true)
        {
          this.Cursor = Cursors.WaitCursor;
          this.CurrentPart.IgnoreExceptionsOnSetMethods = true;
          this.CurrentPart.SetName = (object) this.txtName.Text.Trim();
          this.CurrentPart.SetNumber = (object) this.txtNumber.Text.Trim();
          this.CurrentPart.SetReference = (object) this.txtReference.Text.Trim();
          this.CurrentPart.SetNotes = (object) this.txtNotes.Text.Trim();
          this.CurrentPart.SetUnitTypeID = (object) Combo.get_GetSelectedItemValue(this.cboUnitType);
          this.CurrentPart.SetSellPrice = (object) this.txtSellPrice.Text.Trim();
          this.CurrentPart.SetCategoryID = (object) Combo.get_GetSelectedItemValue(this.cboCategory);
          this.CurrentPart.SetMakeID = (object) Combo.get_GetSelectedItemValue(this.cboManufacturer);
          this.CurrentPart.SetFuelID = (object) Combo.get_GetSelectedItemValue(this.cboFuel);
          this.CurrentPart.SetEndFlagged = this.chkEndFlagged.Checked;
          new PartValidator().Validate(this.CurrentPart);
          if (this.CurrentPart.Exists)
          {
            App.DB.Part.Update(this.CurrentPart);
            App.DB.Part.Part_Locations_Update(this.CurrentPart.PartID, this.PartQuantitiesDataview);
            App.DB.Picklists.UpdateSellPricesByPart(this.CurrentPart.CategoryID, this.CurrentPart.PartID);
          }
          else
            this.CurrentPart = App.DB.Part.Insert(this.CurrentPart);
          if (this.FromOrder)
            ;
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentPart.PartID);
          flag = true;
        }
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
