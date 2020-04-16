// Decompiled with JetBrains decompiler
// Type: FSM.DLGFindRecord
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DLGFindRecord : FRMBaseForm, IForm
  {
    private IContainer components;
    private SqlTransaction _Trans;
    private Enums.TableNames _TableToSearch;
    private int _foreignKeyFilter;
    private List<int> _foreignKeyFilters;
    private string _PartNumber;
    private bool _ForMassPartEntry;
    private DataView _dvRecords;
    private DataView _StockDataview;
    private int _ID;
    private int _2ndID;
    private ArrayList _PartsToAdd;

    public DLGFindRecord()
    {
      this.Load += new EventHandler(this.DLGFindRecord_Load);
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this._foreignKeyFilters = new List<int>();
      this._ForMassPartEntry = false;
      this._StockDataview = (DataView) null;
      this._ID = 0;
      this._2ndID = 0;
      this._PartsToAdd = (ArrayList) null;
      this.InitializeComponent();
    }

    public DLGFindRecord(SqlTransaction trans)
    {
      this.Load += new EventHandler(this.DLGFindRecord_Load);
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this._foreignKeyFilters = new List<int>();
      this._ForMassPartEntry = false;
      this._StockDataview = (DataView) null;
      this._ID = 0;
      this._2ndID = 0;
      this._PartsToAdd = (ArrayList) null;
      this.Trans = trans;
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

    internal virtual GroupBox grpStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbOffice
    {
      get
      {
        return this._cbOffice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbOffice_CheckedChanged);
        CheckBox cbOffice1 = this._cbOffice;
        if (cbOffice1 != null)
          cbOffice1.CheckedChanged -= eventHandler;
        this._cbOffice = value;
        CheckBox cbOffice2 = this._cbOffice;
        if (cbOffice2 == null)
          return;
        cbOffice2.CheckedChanged += eventHandler;
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
        EventHandler eventHandler1 = new EventHandler(this.dgResults_Select);
        EventHandler eventHandler2 = new EventHandler(this.dgResults_Select);
        EventHandler eventHandler3 = new EventHandler(this.dgResults_DoubleClick);
        DataGrid dgResults1 = this._dgResults;
        if (dgResults1 != null)
        {
          dgResults1.Click -= eventHandler1;
          dgResults1.CurrentCellChanged -= eventHandler2;
          dgResults1.DoubleClick -= eventHandler3;
        }
        this._dgResults = value;
        DataGrid dgResults2 = this._dgResults;
        if (dgResults2 == null)
          return;
        dgResults2.Click += eventHandler1;
        dgResults2.CurrentCellChanged += eventHandler2;
        dgResults2.DoubleClick += eventHandler3;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.txtFilter = new TextBox();
      this.grpResults = new GroupBox();
      this.dgResults = new DataGrid();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.grpStock = new GroupBox();
      this.dgStock = new DataGrid();
      this.btnAdd = new Button();
      this.Label2 = new Label();
      this.Panel1 = new Panel();
      this.cbOffice = new CheckBox();
      this.grpResults.SuspendLayout();
      this.dgResults.BeginInit();
      this.grpStock.SuspendLayout();
      this.dgStock.BeginInit();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(8, 40);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 24);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Filter By Name";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(104, 40);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(548, 21);
      this.txtFilter.TabIndex = 1;
      this.grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpResults.Controls.Add((Control) this.dgResults);
      this.grpResults.Location = new System.Drawing.Point(8, 68);
      this.grpResults.Name = "grpResults";
      this.grpResults.Size = new Size(793, 377);
      this.grpResults.TabIndex = 4;
      this.grpResults.TabStop = false;
      this.grpResults.Text = "Select record and click OK";
      this.dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgResults.DataMember = "";
      this.dgResults.HeaderForeColor = SystemColors.ControlText;
      this.dgResults.Location = new System.Drawing.Point(8, 27);
      this.dgResults.Name = "dgResults";
      this.dgResults.Size = new Size(779, 342);
      this.dgResults.TabIndex = 2;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(745, 451);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(56, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 451);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.grpStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpStock.Controls.Add((Control) this.dgStock);
      this.grpStock.Location = new System.Drawing.Point(8, 280);
      this.grpStock.Name = "grpStock";
      this.grpStock.Size = new Size(793, 165);
      this.grpStock.TabIndex = 5;
      this.grpStock.TabStop = false;
      this.grpStock.Text = "Stock Locations for : 'No Part Selected'";
      this.grpStock.Visible = false;
      this.dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStock.DataMember = "";
      this.dgStock.HeaderForeColor = SystemColors.ControlText;
      this.dgStock.Location = new System.Drawing.Point(8, 20);
      this.dgStock.Name = "dgStock";
      this.dgStock.Size = new Size(779, 137);
      this.dgStock.TabIndex = 3;
      this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.Location = new System.Drawing.Point(672, 39);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(129, 23);
      this.btnAdd.TabIndex = 6;
      this.btnAdd.Text = "Add";
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.Location = new System.Drawing.Point(95, 456);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(175, 24);
      this.Label2.TabIndex = 7;
      this.Label2.Text = "Preferred Supplier";
      this.Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel1.BackColor = Color.LightGreen;
      this.Panel1.Location = new System.Drawing.Point(70, 454);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(19, 20);
      this.Panel1.TabIndex = 8;
      this.cbOffice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbOffice.AutoSize = true;
      this.cbOffice.Location = new System.Drawing.Point(665, 42);
      this.cbOffice.Name = "cbOffice";
      this.cbOffice.Size = new Size(130, 17);
      this.cbOffice.TabIndex = 9;
      this.cbOffice.Text = "Only Show Offices";
      this.cbOffice.UseVisualStyleBackColor = true;
      this.cbOffice.Visible = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(809, 481);
      this.ControlBox = false;
      this.Controls.Add((Control) this.cbOffice);
      this.Controls.Add((Control) this.Panel1);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.grpStock);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.grpResults);
      this.Controls.Add((Control) this.txtFilter);
      this.Controls.Add((Control) this.Label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(704, 392);
      this.Name = nameof (DLGFindRecord);
      this.Text = "Find {0}";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.txtFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpResults, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grpStock, 0);
      this.Controls.SetChildIndex((Control) this.btnAdd, 0);
      this.Controls.SetChildIndex((Control) this.Label2, 0);
      this.Controls.SetChildIndex((Control) this.Panel1, 0);
      this.Controls.SetChildIndex((Control) this.cbOffice, 0);
      this.grpResults.ResumeLayout(false);
      this.dgResults.EndInit();
      this.grpStock.ResumeLayout(false);
      this.dgStock.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ActiveControl = (Control) this.txtFilter;
      this.txtFilter.Focus();
      this.SetupDG();
      this.SetupStockDatagrid();
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

    public SqlTransaction Trans
    {
      get
      {
        return this._Trans;
      }
      set
      {
        this._Trans = value;
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
        this.MinimumSize = new Size(new System.Drawing.Point(704, 392));
        this._TableToSearch = value;
        this.btnAdd.Visible = false;
        switch (this.TableToSearch)
        {
          case Enums.TableNames.tblUser:
            this.Text = "Find User";
            this.Records = App.DB.User.GetAll();
            break;
          case Enums.TableNames.tblCustomer:
            this.Text = "Find Customer";
            this.Records = App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID);
            break;
          case Enums.TableNames.tblPart:
            this.Text = "Find Part";
            if (this.ForeignKeyFilter == 0)
            {
              this.Records = this.Trans == null ? App.DB.Part.Part_GetAll(this.ForMassPartEntry) : App.DB.Part.Part_GetAll(this.Trans);
              this.Height = 392;
              this.grpResults.Height = 79;
              this.Height = 600;
              this.grpStock.Visible = true;
              this.btnAdd.Visible = true;
            }
            else
              this.Records = this.Trans == null ? App.DB.Order.OrderPart_GetForOrder(this.ForeignKeyFilter) : App.DB.Order.OrderPart_GetForOrder(this.ForeignKeyFilter, this.Trans);
            this.txtFilter.Text = this.PartNumber;
            break;
          case Enums.TableNames.tblProduct:
            this.Text = "Find Product";
            this.Records = this.Trans == null ? App.DB.Product.Product_GetAll() : App.DB.Product.Product_GetAll(this.Trans);
            this.btnAdd.Visible = true;
            break;
          case Enums.TableNames.tblSupplier:
            this.Text = "Find Supplier";
            this.Records = App.DB.Supplier.Supplier_GetAll();
            if (Helper.MakeIntegerValid((object) this.ForeignKeyFilter) == 1)
            {
              this.Records.RowFilter = "MasterSupplierID = 0";
              break;
            }
            break;
          case Enums.TableNames.tblEngineer:
            this.Text = "Find an Engineer";
            this.Records = App.DB.Engineer.Engineer_GetAll();
            break;
          case Enums.TableNames.tblVan:
            this.Text = "Find Stock Profile";
            this.Records = App.DB.Van.Van_GetAll(false);
            break;
          case Enums.TableNames.tblSite:
            if (this.ForeignKeyFilters.Count > 0)
            {
              this.Text = "Find Property For Customer";
              DataTable table = new DataTable();
              try
              {
                foreach (int foreignKeyFilter in this.ForeignKeyFilters)
                {
                  DataView forCustomerLight = App.DB.Sites.GetForCustomer_Light(foreignKeyFilter, App.loggedInUser.UserID);
                  if (forCustomerLight.Count > 0)
                    table.Merge(forCustomerLight.Table);
                }
              }
              finally
              {
                List<int>.Enumerator enumerator;
                enumerator.Dispose();
              }
              this.Records = new DataView(table);
            }
            else if (this.ForeignKeyFilter > 0)
            {
              this.Text = "Find Property For Customer";
              this.Records = App.DB.Sites.GetForCustomer_Light(this.ForeignKeyFilter, App.loggedInUser.UserID);
            }
            else
            {
              this.Text = "Find Property";
              this.Records = App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID);
            }
            this.cbOffice.Visible = true;
            break;
          case Enums.TableNames.tblContact:
            if (this.ForeignKeyFilter > 0)
            {
              this.Text = "Find Contact For Property";
              this.Records = App.DB.Contact.Contact_GetForSite(this.ForeignKeyFilter);
              break;
            }
            this.Text = "Find Contact";
            this.Records = App.DB.Contact.Contact_GetAll();
            break;
          case Enums.TableNames.tblPartSupplier:
            this.Text = "Find Part";
            this.Records = App.DB.PartSupplier.PartSupplierGet_All();
            break;
          case Enums.TableNames.tblProductSupplier:
            this.Text = "Find Product";
            this.Records = App.DB.ProductSupplier.ProductSupplierGet_All();
            break;
          case Enums.TableNames.tblOrder:
            this.Text = "Find an Order";
            this.Records = App.DB.Order.Order_GetAll("");
            this.Records.RowFilter = " SupplierID > 0 AND OrderTypeID <> 1 AND OrderTypeID <> 4 AND DisplayStatusID >= " + Conversions.ToString(4);
            break;
          case Enums.TableNames.tblInvoiceAddress:
            if (this.ForeignKeyFilter > 0)
            {
              this.Text = "Find Invoice Address For Property";
              this.Records = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(this.ForeignKeyFilter);
              break;
            }
            this.Text = "Find Invoice Address";
            this.Records = App.DB.InvoiceAddress.InvoiceAddress_GetAll();
            break;
          case Enums.TableNames.tblJob:
            this.Text = "Find Job";
            this.Records = App.DB.Job.Job_Get_All("Where tblJob.Deleted = 0");
            break;
          case Enums.TableNames.tblWarehouse:
            this.Text = "Find Warehouse";
            this.Records = this.Trans == null ? App.DB.Warehouse.Warehouse_GetAll() : App.DB.Warehouse.Warehouse_GetAll(this.Trans);
            break;
          case Enums.TableNames.tblLocations:
            this.Text = "Find Location";
            this.Records = App.DB.Location.Locations_GetAll_WithNames();
            break;
          case Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
            this.Text = "Find Supplier";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Supplier.Supplier_GetAll() : App.DB.Supplier.Supplier_GetAll(this.Trans)) : (this.Trans == null ? App.DB.Supplier.Supplier_GetWithProduct(this.ForeignKeyFilter) : App.DB.Supplier.Supplier_GetWithProduct(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
            this.Text = "Find Supplier";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Supplier.Supplier_GetAll() : App.DB.Supplier.Supplier_GetAll(this.Trans)) : (this.Trans == null ? App.DB.Supplier.Supplier_GetWithPart(this.ForeignKeyFilter) : App.DB.Supplier.Supplier_GetWithPart(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
            this.Text = "Find Van";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Van.Van_GetAll(false) : App.DB.Van.Van_GetAll(false, this.Trans)) : (this.Trans == null ? App.DB.Van.Van_GetWithProduct(this.ForeignKeyFilter) : App.DB.Van.Van_GetWithProduct(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
            this.Text = "Find Warehouse";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Warehouse.Warehouse_GetAll() : App.DB.Warehouse.Warehouse_GetAll(this.Trans)) : (this.Trans == null ? App.DB.Warehouse.Warehouse_GetWithProduct(this.ForeignKeyFilter) : App.DB.Warehouse.Warehouse_GetWithProduct(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
            this.Text = "Find Warehouse";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Warehouse.Warehouse_GetAll() : App.DB.Warehouse.Warehouse_GetAll(this.Trans)) : (this.Trans == null ? App.DB.Warehouse.Warehouse_GetWithPart(this.ForeignKeyFilter) : App.DB.Warehouse.Warehouse_GetWithPart(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_VansForPart:
            this.Text = "Find Van";
            this.Records = this.ForeignKeyFilter <= 0 ? (this.Trans == null ? App.DB.Van.Van_GetAll(false) : App.DB.Van.Van_GetAll(false, this.Trans)) : (this.Trans == null ? App.DB.Van.Van_GetWithPart(this.ForeignKeyFilter) : App.DB.Van.Van_GetWithPart(this.ForeignKeyFilter, this.Trans));
            break;
          case Enums.TableNames.tblSystemScheduleOfRate:
            this.Text = "Find SOR";
            this.Records = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll();
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
            this.Text = "Select A Location for the Unallocated Received Job Parts/Products to be placed";
            this.Records = this.Trans != null ? App.DB.Location.Locations_GetAll_WithNames(this.Trans) : App.DB.Location.Locations_GetAll_WithNames();
            break;
          case Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
            this.Text = "Find Bin Reference";
            this.Records = App.DB.Picklists.GetAll(Enums.PickListTypes.PartBinReferences, false);
            break;
          case Enums.TableNames.tblFleetVan:
            this.Text = "Find Van";
            this.Records = App.DB.FleetVan.GetAll();
            break;
          case Enums.TableNames.tblFleetVanMaintenance:
            this.Text = "Find Fault";
            this.Records = App.DB.FleetVanFault.GetAll_Unresolved_WithNoJob();
            break;
          case Enums.TableNames.tblEngineerSkills:
            this.Text = "Find Engineer Skill";
            this.Records = App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false);
            break;
          case Enums.TableNames.tblEngineerRole:
            this.Text = "Find an Engineer";
            this.Records = App.DB.EngineerRole.GetEngineersNotAssignedToRole();
            break;
        }
        if (this.TableToSearch == Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans)
          this.btnCancel.Enabled = false;
        else
          this.btnCancel.Enabled = true;
        this.MinimumSize = this.Size;
      }
    }

    public int ForeignKeyFilter
    {
      get
      {
        return this._foreignKeyFilter;
      }
      set
      {
        this._foreignKeyFilter = value;
      }
    }

    public List<int> ForeignKeyFilters
    {
      get
      {
        return this._foreignKeyFilters;
      }
      set
      {
        this._foreignKeyFilters = value;
      }
    }

    public string PartNumber
    {
      get
      {
        return this._PartNumber;
      }
      set
      {
        this._PartNumber = value;
      }
    }

    public bool ForMassPartEntry
    {
      get
      {
        return this._ForMassPartEntry;
      }
      set
      {
        this._ForMassPartEntry = value;
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
        this._dvRecords.AllowEdit = this.ForMassPartEntry;
        this._dvRecords.AllowDelete = false;
        this.dgResults.DataSource = (object) this.Records;
        if (this.TableToSearch != Enums.TableNames.tblPart || this.Records == null || (this.Records.Table == null || this.Records.Table.Rows.Count <= 0))
          return;
        this.StockDataview = this.Trans == null ? App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.Records.Table.Rows[0]["PartID"]), 0) : App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.Records.Table.Rows[0]["PartID"]), this.Trans, 0);
        this.grpStock.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Stock Locations for : '", this.Records.Table.Rows[0]["Name"]), (object) "'"));
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgResults.CurrentRowIndex != -1 ? this.Records[this.dgResults.CurrentRowIndex].Row : (DataRow) null;
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
        if (this._StockDataview != null && this._StockDataview.Table != null)
        {
          this._StockDataview.Table.TableName = Enums.TableNames.tblStock.ToString();
          this._StockDataview.AllowNew = false;
          this._StockDataview.AllowEdit = true;
          this._StockDataview.AllowDelete = false;
        }
        this.dgStock.DataSource = (object) this.StockDataview;
      }
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

    public int SecondID
    {
      get
      {
        return this._2ndID;
      }
      set
      {
        this._2ndID = value;
      }
    }

    public ArrayList PartsToAdd
    {
      get
      {
        return this._PartsToAdd;
      }
      set
      {
        this._PartsToAdd = value;
      }
    }

    private void SetupDG()
    {
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      tableStyle.ReadOnly = true;
      switch (this.TableToSearch)
      {
        case Enums.TableNames.tblUser:
          DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
          dataGridLabelColumn1.Format = "";
          dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn1.HeaderText = "Full Name";
          dataGridLabelColumn1.MappingName = "FullName";
          dataGridLabelColumn1.ReadOnly = true;
          dataGridLabelColumn1.Width = 170;
          dataGridLabelColumn1.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
          DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
          dataGridLabelColumn2.Format = "";
          dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn2.HeaderText = "Email Address";
          dataGridLabelColumn2.MappingName = "EmailAddress";
          dataGridLabelColumn2.Width = 200;
          dataGridLabelColumn2.ReadOnly = true;
          dataGridLabelColumn2.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
          break;
        case Enums.TableNames.tblCustomer:
          DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
          dataGridLabelColumn3.Format = "";
          dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn3.HeaderText = "Name";
          dataGridLabelColumn3.MappingName = "Name";
          dataGridLabelColumn3.ReadOnly = true;
          dataGridLabelColumn3.Width = 170;
          dataGridLabelColumn3.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
          DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
          dataGridLabelColumn4.Format = "";
          dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn4.HeaderText = "Account Number";
          dataGridLabelColumn4.MappingName = "AccountNumber";
          dataGridLabelColumn4.ReadOnly = true;
          dataGridLabelColumn4.Width = 100;
          dataGridLabelColumn4.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
          DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
          dataGridLabelColumn5.Format = "";
          dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn5.HeaderText = "Region";
          dataGridLabelColumn5.MappingName = "Region";
          dataGridLabelColumn5.ReadOnly = true;
          dataGridLabelColumn5.Width = 100;
          dataGridLabelColumn5.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
          DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
          dataGridLabelColumn6.Format = "";
          dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn6.HeaderText = "Type";
          dataGridLabelColumn6.MappingName = "Type";
          dataGridLabelColumn6.ReadOnly = true;
          dataGridLabelColumn6.Width = 140;
          dataGridLabelColumn6.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
          DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
          dataGridLabelColumn7.Format = "";
          dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn7.HeaderText = "Head Office";
          dataGridLabelColumn7.MappingName = "ho";
          dataGridLabelColumn7.ReadOnly = true;
          dataGridLabelColumn7.Width = 250;
          dataGridLabelColumn7.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
          break;
        case Enums.TableNames.tblPart:
          if (this.ForMassPartEntry)
          {
            tableStyle.ReadOnly = false;
            this.dgResults.ReadOnly = false;
            DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
            editableTextBoxColumn.BackColourBrush = Brushes.LightYellow;
            editableTextBoxColumn.Format = "";
            editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
            editableTextBoxColumn.HeaderText = "Add";
            editableTextBoxColumn.MappingName = "QuantityToAdd";
            editableTextBoxColumn.ReadOnly = false;
            editableTextBoxColumn.Width = 130;
            editableTextBoxColumn.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
          }
          DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
          dataGridLabelColumn8.Format = "";
          dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn8.HeaderText = "Name";
          dataGridLabelColumn8.MappingName = "Name";
          dataGridLabelColumn8.ReadOnly = true;
          dataGridLabelColumn8.Width = 130;
          dataGridLabelColumn8.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
          DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
          dataGridLabelColumn9.Format = "";
          dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn9.HeaderText = "Number (MPN)";
          dataGridLabelColumn9.MappingName = "Number";
          dataGridLabelColumn9.ReadOnly = true;
          dataGridLabelColumn9.Width = 130;
          dataGridLabelColumn9.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
          DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
          dataGridLabelColumn10.Format = "";
          dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn10.HeaderText = "Reference";
          dataGridLabelColumn10.MappingName = "Reference";
          dataGridLabelColumn10.ReadOnly = true;
          dataGridLabelColumn10.Width = 200;
          dataGridLabelColumn10.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
          DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
          dataGridLabelColumn11.Format = "";
          dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn11.HeaderText = "Qty";
          dataGridLabelColumn11.MappingName = "WarehouseQuantity";
          dataGridLabelColumn11.ReadOnly = true;
          dataGridLabelColumn11.Width = 50;
          dataGridLabelColumn11.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
          DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
          dataGridLabelColumn12.Format = "";
          dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn12.HeaderText = "Unit Type";
          dataGridLabelColumn12.MappingName = "UnitType";
          dataGridLabelColumn12.ReadOnly = true;
          dataGridLabelColumn12.Width = 130;
          dataGridLabelColumn12.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
          DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
          dataGridLabelColumn13.Format = "C";
          dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn13.HeaderText = "Sell Price";
          dataGridLabelColumn13.MappingName = "SellPrice";
          dataGridLabelColumn13.ReadOnly = true;
          dataGridLabelColumn13.Width = 120;
          dataGridLabelColumn13.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
          break;
        case Enums.TableNames.tblProduct:
          DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
          dataGridLabelColumn14.Format = "";
          dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn14.HeaderText = "Description";
          dataGridLabelColumn14.MappingName = "typemakemodel";
          dataGridLabelColumn14.ReadOnly = true;
          dataGridLabelColumn14.Width = 200;
          dataGridLabelColumn14.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
          DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
          dataGridLabelColumn15.Format = "";
          dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn15.HeaderText = "GC Number";
          dataGridLabelColumn15.MappingName = "Number";
          dataGridLabelColumn15.ReadOnly = true;
          dataGridLabelColumn15.Width = 120;
          dataGridLabelColumn15.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
          DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
          dataGridLabelColumn16.Format = "";
          dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn16.HeaderText = "Product Reference";
          dataGridLabelColumn16.MappingName = "Reference";
          dataGridLabelColumn16.ReadOnly = true;
          dataGridLabelColumn16.Width = 200;
          dataGridLabelColumn16.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
          break;
        case Enums.TableNames.tblSupplier:
        case Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
        case Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
          if (this.TableToSearch == Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart && this.ForeignKeyFilter > 0)
          {
            DLGFindRecord.ColourColumn colourColumn = new DLGFindRecord.ColourColumn();
            colourColumn.Format = "";
            colourColumn.FormatInfo = (IFormatProvider) null;
            colourColumn.HeaderText = "Preferred";
            colourColumn.MappingName = "Preferred";
            colourColumn.ReadOnly = true;
            colourColumn.Width = 25;
            colourColumn.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle) colourColumn);
          }
          DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
          dataGridLabelColumn17.Format = "";
          dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn17.HeaderText = "Name";
          dataGridLabelColumn17.MappingName = "Name";
          dataGridLabelColumn17.ReadOnly = true;
          dataGridLabelColumn17.Width = 130;
          dataGridLabelColumn17.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
          DataGridLabelColumn dataGridLabelColumn18 = new DataGridLabelColumn();
          dataGridLabelColumn18.Format = "";
          dataGridLabelColumn18.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn18.HeaderText = "Address1";
          dataGridLabelColumn18.MappingName = "Address1";
          dataGridLabelColumn18.ReadOnly = true;
          dataGridLabelColumn18.Width = 130;
          dataGridLabelColumn18.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn18);
          DataGridLabelColumn dataGridLabelColumn19 = new DataGridLabelColumn();
          dataGridLabelColumn19.Format = "";
          dataGridLabelColumn19.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn19.HeaderText = "Price";
          dataGridLabelColumn19.MappingName = "Price";
          dataGridLabelColumn19.ReadOnly = true;
          dataGridLabelColumn19.Width = 130;
          dataGridLabelColumn19.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn19);
          DataGridLabelColumn dataGridLabelColumn20 = new DataGridLabelColumn();
          dataGridLabelColumn20.Format = "";
          dataGridLabelColumn20.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn20.HeaderText = "Address2";
          dataGridLabelColumn20.MappingName = "Address2";
          dataGridLabelColumn20.ReadOnly = true;
          dataGridLabelColumn20.Width = 130;
          dataGridLabelColumn20.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn20);
          DataGridLabelColumn dataGridLabelColumn21 = new DataGridLabelColumn();
          dataGridLabelColumn21.Format = "";
          dataGridLabelColumn21.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn21.HeaderText = "Address3";
          dataGridLabelColumn21.MappingName = "Address3";
          dataGridLabelColumn21.ReadOnly = true;
          dataGridLabelColumn21.Width = 130;
          dataGridLabelColumn21.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn21);
          DataGridLabelColumn dataGridLabelColumn22 = new DataGridLabelColumn();
          dataGridLabelColumn22.Format = "";
          dataGridLabelColumn22.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn22.HeaderText = "Address4";
          dataGridLabelColumn22.MappingName = "Address4";
          dataGridLabelColumn22.ReadOnly = true;
          dataGridLabelColumn22.Width = 130;
          dataGridLabelColumn22.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn22);
          DataGridLabelColumn dataGridLabelColumn23 = new DataGridLabelColumn();
          dataGridLabelColumn23.Format = "";
          dataGridLabelColumn23.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn23.HeaderText = "Address5";
          dataGridLabelColumn23.MappingName = "Address5";
          dataGridLabelColumn23.ReadOnly = true;
          dataGridLabelColumn23.Width = 130;
          dataGridLabelColumn23.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn23);
          DataGridLabelColumn dataGridLabelColumn24 = new DataGridLabelColumn();
          dataGridLabelColumn24.Format = "";
          dataGridLabelColumn24.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn24.HeaderText = "Postcode";
          dataGridLabelColumn24.MappingName = "Postcode";
          dataGridLabelColumn24.ReadOnly = true;
          dataGridLabelColumn24.Width = 130;
          dataGridLabelColumn24.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn24);
          DataGridLabelColumn dataGridLabelColumn25 = new DataGridLabelColumn();
          dataGridLabelColumn25.Format = "";
          dataGridLabelColumn25.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn25.HeaderText = "Telephone";
          dataGridLabelColumn25.MappingName = "TelephoneNum";
          dataGridLabelColumn25.ReadOnly = true;
          dataGridLabelColumn25.Width = 130;
          dataGridLabelColumn25.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn25);
          break;
        case Enums.TableNames.tblEngineer:
          DataGridLabelColumn dataGridLabelColumn26 = new DataGridLabelColumn();
          dataGridLabelColumn26.Format = "";
          dataGridLabelColumn26.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn26.HeaderText = "Name";
          dataGridLabelColumn26.MappingName = "Name";
          dataGridLabelColumn26.ReadOnly = true;
          dataGridLabelColumn26.Width = 200;
          dataGridLabelColumn26.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn26);
          DataGridLabelColumn dataGridLabelColumn27 = new DataGridLabelColumn();
          dataGridLabelColumn27.Format = "";
          dataGridLabelColumn27.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn27.HeaderText = "Telephone Number";
          dataGridLabelColumn27.MappingName = "TelephoneNum";
          dataGridLabelColumn27.ReadOnly = true;
          dataGridLabelColumn27.Width = 200;
          dataGridLabelColumn27.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn27);
          DataGridLabelColumn dataGridLabelColumn28 = new DataGridLabelColumn();
          dataGridLabelColumn28.Format = "";
          dataGridLabelColumn28.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn28.HeaderText = "Region";
          dataGridLabelColumn28.MappingName = "Region";
          dataGridLabelColumn28.ReadOnly = true;
          dataGridLabelColumn28.Width = 200;
          dataGridLabelColumn28.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn28);
          break;
        case Enums.TableNames.tblVan:
          DataGridLabelColumn dataGridLabelColumn29 = new DataGridLabelColumn();
          dataGridLabelColumn29.Format = "";
          dataGridLabelColumn29.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn29.HeaderText = "Engineer Name";
          dataGridLabelColumn29.MappingName = "EngineerName";
          dataGridLabelColumn29.ReadOnly = true;
          dataGridLabelColumn29.Width = 100;
          dataGridLabelColumn29.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn29);
          DataGridLabelColumn dataGridLabelColumn30 = new DataGridLabelColumn();
          dataGridLabelColumn30.Format = "";
          dataGridLabelColumn30.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn30.HeaderText = "Stock Profile Name";
          dataGridLabelColumn30.MappingName = "Registration";
          dataGridLabelColumn30.ReadOnly = true;
          dataGridLabelColumn30.Width = 150;
          dataGridLabelColumn30.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn30);
          break;
        case Enums.TableNames.tblSite:
          DataGridLabelColumn dataGridLabelColumn31 = new DataGridLabelColumn();
          dataGridLabelColumn31.Format = "";
          dataGridLabelColumn31.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn31.HeaderText = "Customer";
          dataGridLabelColumn31.MappingName = "CustomerName";
          dataGridLabelColumn31.ReadOnly = true;
          dataGridLabelColumn31.Width = 100;
          dataGridLabelColumn31.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn31);
          DataGridLabelColumn dataGridLabelColumn32 = new DataGridLabelColumn();
          dataGridLabelColumn32.Format = "";
          dataGridLabelColumn32.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn32.HeaderText = "Name";
          dataGridLabelColumn32.MappingName = "Name";
          dataGridLabelColumn32.ReadOnly = true;
          dataGridLabelColumn32.Width = 100;
          dataGridLabelColumn32.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn32);
          DataGridLabelColumn dataGridLabelColumn33 = new DataGridLabelColumn();
          dataGridLabelColumn33.Format = "";
          dataGridLabelColumn33.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn33.HeaderText = "Address 1";
          dataGridLabelColumn33.MappingName = "Address1";
          dataGridLabelColumn33.ReadOnly = true;
          dataGridLabelColumn33.Width = 100;
          dataGridLabelColumn33.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn33);
          DataGridLabelColumn dataGridLabelColumn34 = new DataGridLabelColumn();
          dataGridLabelColumn34.Format = "";
          dataGridLabelColumn34.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn34.HeaderText = "Address 2";
          dataGridLabelColumn34.MappingName = "Address2";
          dataGridLabelColumn34.ReadOnly = true;
          dataGridLabelColumn34.Width = 100;
          dataGridLabelColumn34.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn34);
          DataGridLabelColumn dataGridLabelColumn35 = new DataGridLabelColumn();
          dataGridLabelColumn35.Format = "";
          dataGridLabelColumn35.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn35.HeaderText = "Address 3";
          dataGridLabelColumn35.MappingName = "Address3";
          dataGridLabelColumn35.ReadOnly = true;
          dataGridLabelColumn35.Width = 100;
          dataGridLabelColumn35.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn35);
          DataGridLabelColumn dataGridLabelColumn36 = new DataGridLabelColumn();
          dataGridLabelColumn36.Format = "";
          dataGridLabelColumn36.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn36.HeaderText = "Address 4";
          dataGridLabelColumn36.MappingName = "Address4";
          dataGridLabelColumn36.ReadOnly = true;
          dataGridLabelColumn36.Width = 100;
          dataGridLabelColumn36.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn36);
          DataGridLabelColumn dataGridLabelColumn37 = new DataGridLabelColumn();
          dataGridLabelColumn37.Format = "";
          dataGridLabelColumn37.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn37.HeaderText = "Address 5";
          dataGridLabelColumn37.MappingName = "Address5";
          dataGridLabelColumn37.ReadOnly = true;
          dataGridLabelColumn37.Width = 100;
          dataGridLabelColumn37.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn37);
          DataGridLabelColumn dataGridLabelColumn38 = new DataGridLabelColumn();
          dataGridLabelColumn38.Format = "";
          dataGridLabelColumn38.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn38.HeaderText = "Postcode";
          dataGridLabelColumn38.MappingName = "Postcode";
          dataGridLabelColumn38.ReadOnly = true;
          dataGridLabelColumn38.Width = 100;
          dataGridLabelColumn38.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn38);
          DataGridLabelColumn dataGridLabelColumn39 = new DataGridLabelColumn();
          dataGridLabelColumn39.Format = "";
          dataGridLabelColumn39.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn39.HeaderText = "Tel";
          dataGridLabelColumn39.MappingName = "TelephoneNum";
          dataGridLabelColumn39.ReadOnly = true;
          dataGridLabelColumn39.Width = 100;
          dataGridLabelColumn39.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn39);
          break;
        case Enums.TableNames.tblContact:
          DataGridLabelColumn dataGridLabelColumn40 = new DataGridLabelColumn();
          dataGridLabelColumn40.Format = "";
          dataGridLabelColumn40.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn40.HeaderText = "First Name";
          dataGridLabelColumn40.MappingName = "FirstName";
          dataGridLabelColumn40.ReadOnly = true;
          dataGridLabelColumn40.Width = 160;
          dataGridLabelColumn40.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn40);
          DataGridLabelColumn dataGridLabelColumn41 = new DataGridLabelColumn();
          dataGridLabelColumn41.Format = "";
          dataGridLabelColumn41.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn41.HeaderText = "Surname";
          dataGridLabelColumn41.MappingName = "Surname";
          dataGridLabelColumn41.ReadOnly = true;
          dataGridLabelColumn41.Width = 160;
          dataGridLabelColumn41.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn41);
          DataGridLabelColumn dataGridLabelColumn42 = new DataGridLabelColumn();
          dataGridLabelColumn42.Format = "";
          dataGridLabelColumn42.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn42.HeaderText = "Email";
          dataGridLabelColumn42.MappingName = "EmailAddress";
          dataGridLabelColumn42.ReadOnly = true;
          dataGridLabelColumn42.Width = 120;
          dataGridLabelColumn42.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn42);
          DataGridLabelColumn dataGridLabelColumn43 = new DataGridLabelColumn();
          dataGridLabelColumn43.Format = "";
          dataGridLabelColumn43.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn43.HeaderText = "Telephone Number";
          dataGridLabelColumn43.MappingName = "TelephoneNum";
          dataGridLabelColumn43.ReadOnly = true;
          dataGridLabelColumn43.Width = 100;
          dataGridLabelColumn43.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn43);
          break;
        case Enums.TableNames.tblPartSupplier:
          DataGridLabelColumn dataGridLabelColumn44 = new DataGridLabelColumn();
          dataGridLabelColumn44.Format = "";
          dataGridLabelColumn44.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn44.HeaderText = "Supplier";
          dataGridLabelColumn44.MappingName = "Supplier";
          dataGridLabelColumn44.ReadOnly = true;
          dataGridLabelColumn44.Width = 130;
          dataGridLabelColumn44.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn44);
          DataGridLabelColumn dataGridLabelColumn45 = new DataGridLabelColumn();
          dataGridLabelColumn45.Format = "";
          dataGridLabelColumn45.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn45.HeaderText = "Name";
          dataGridLabelColumn45.MappingName = "Name";
          dataGridLabelColumn45.ReadOnly = true;
          dataGridLabelColumn45.Width = 130;
          dataGridLabelColumn45.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn45);
          DataGridLabelColumn dataGridLabelColumn46 = new DataGridLabelColumn();
          dataGridLabelColumn46.Format = "";
          dataGridLabelColumn46.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn46.HeaderText = "Part Number (MPN)";
          dataGridLabelColumn46.MappingName = "Number";
          dataGridLabelColumn46.ReadOnly = true;
          dataGridLabelColumn46.Width = 130;
          dataGridLabelColumn46.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn46);
          DataGridLabelColumn dataGridLabelColumn47 = new DataGridLabelColumn();
          dataGridLabelColumn47.Format = "";
          dataGridLabelColumn47.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn47.HeaderText = "Quantity In Pack";
          dataGridLabelColumn47.MappingName = "QuantityInPack";
          dataGridLabelColumn47.ReadOnly = true;
          dataGridLabelColumn47.Width = 130;
          dataGridLabelColumn47.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn47);
          DataGridLabelColumn dataGridLabelColumn48 = new DataGridLabelColumn();
          dataGridLabelColumn48.Format = "";
          dataGridLabelColumn48.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn48.HeaderText = "Supplier Part Number (SPN)";
          dataGridLabelColumn48.MappingName = "PartCode";
          dataGridLabelColumn48.ReadOnly = true;
          dataGridLabelColumn48.Width = 130;
          dataGridLabelColumn48.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn48);
          DataGridLabelColumn dataGridLabelColumn49 = new DataGridLabelColumn();
          dataGridLabelColumn49.Format = "";
          dataGridLabelColumn49.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn49.HeaderText = "Price";
          dataGridLabelColumn49.MappingName = "Price";
          dataGridLabelColumn49.ReadOnly = true;
          dataGridLabelColumn49.Width = 130;
          dataGridLabelColumn49.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn49);
          break;
        case Enums.TableNames.tblProductSupplier:
          DataGridLabelColumn dataGridLabelColumn50 = new DataGridLabelColumn();
          dataGridLabelColumn50.Format = "";
          dataGridLabelColumn50.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn50.HeaderText = "Supplier";
          dataGridLabelColumn50.MappingName = "Supplier";
          dataGridLabelColumn50.ReadOnly = true;
          dataGridLabelColumn50.Width = 130;
          dataGridLabelColumn50.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn50);
          DataGridLabelColumn dataGridLabelColumn51 = new DataGridLabelColumn();
          dataGridLabelColumn51.Format = "";
          dataGridLabelColumn51.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn51.HeaderText = "Name";
          dataGridLabelColumn51.MappingName = "Name";
          dataGridLabelColumn51.ReadOnly = true;
          dataGridLabelColumn51.Width = 130;
          dataGridLabelColumn51.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn51);
          DataGridLabelColumn dataGridLabelColumn52 = new DataGridLabelColumn();
          dataGridLabelColumn52.Format = "";
          dataGridLabelColumn52.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn52.HeaderText = "Product Number";
          dataGridLabelColumn52.MappingName = "Number";
          dataGridLabelColumn52.ReadOnly = true;
          dataGridLabelColumn52.Width = 130;
          dataGridLabelColumn52.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn52);
          DataGridLabelColumn dataGridLabelColumn53 = new DataGridLabelColumn();
          dataGridLabelColumn53.Format = "";
          dataGridLabelColumn53.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn53.HeaderText = "Quantity In Pack";
          dataGridLabelColumn53.MappingName = "QuantityInPack";
          dataGridLabelColumn53.ReadOnly = true;
          dataGridLabelColumn53.Width = 130;
          dataGridLabelColumn53.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn53);
          DataGridLabelColumn dataGridLabelColumn54 = new DataGridLabelColumn();
          dataGridLabelColumn54.Format = "";
          dataGridLabelColumn54.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn54.HeaderText = "Supplier Product Number";
          dataGridLabelColumn54.MappingName = "ProductCode";
          dataGridLabelColumn54.ReadOnly = true;
          dataGridLabelColumn54.Width = 130;
          dataGridLabelColumn54.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn54);
          DataGridLabelColumn dataGridLabelColumn55 = new DataGridLabelColumn();
          dataGridLabelColumn55.Format = "";
          dataGridLabelColumn55.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn55.HeaderText = "Price";
          dataGridLabelColumn55.MappingName = "Price";
          dataGridLabelColumn55.ReadOnly = true;
          dataGridLabelColumn55.Width = 130;
          dataGridLabelColumn55.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn55);
          break;
        case Enums.TableNames.tblOrder:
          DataGridLabelColumn dataGridLabelColumn56 = new DataGridLabelColumn();
          dataGridLabelColumn56.Format = "dd/MMM/yyyy";
          dataGridLabelColumn56.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn56.HeaderText = "Date Placed";
          dataGridLabelColumn56.MappingName = "DatePlaced";
          dataGridLabelColumn56.ReadOnly = true;
          dataGridLabelColumn56.Width = 90;
          dataGridLabelColumn56.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn56);
          DataGridLabelColumn dataGridLabelColumn57 = new DataGridLabelColumn();
          dataGridLabelColumn57.Format = "dd/MMM/yyyy";
          dataGridLabelColumn57.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn57.HeaderText = "Delivery Deadline";
          dataGridLabelColumn57.MappingName = "DeliveryDeadline";
          dataGridLabelColumn57.ReadOnly = true;
          dataGridLabelColumn57.Width = 90;
          dataGridLabelColumn57.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn57);
          DataGridLabelColumn dataGridLabelColumn58 = new DataGridLabelColumn();
          dataGridLabelColumn58.Format = "";
          dataGridLabelColumn58.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn58.HeaderText = "Order Reference";
          dataGridLabelColumn58.MappingName = "OrderReference";
          dataGridLabelColumn58.ReadOnly = true;
          dataGridLabelColumn58.Width = 110;
          dataGridLabelColumn58.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn58);
          DataGridLabelColumn dataGridLabelColumn59 = new DataGridLabelColumn();
          dataGridLabelColumn59.Format = "";
          dataGridLabelColumn59.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn59.HeaderText = "Consol Ref";
          dataGridLabelColumn59.MappingName = "ConsolidationRef";
          dataGridLabelColumn59.ReadOnly = true;
          dataGridLabelColumn59.Width = 110;
          dataGridLabelColumn59.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn59);
          DataGridLabelColumn dataGridLabelColumn60 = new DataGridLabelColumn();
          dataGridLabelColumn60.Format = "";
          dataGridLabelColumn60.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn60.HeaderText = "Type";
          dataGridLabelColumn60.MappingName = "Type";
          dataGridLabelColumn60.ReadOnly = true;
          dataGridLabelColumn60.Width = 75;
          dataGridLabelColumn60.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn60);
          DataGridLabelColumn dataGridLabelColumn61 = new DataGridLabelColumn();
          dataGridLabelColumn61.Format = "";
          dataGridLabelColumn61.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn61.HeaderText = "Customer";
          dataGridLabelColumn61.MappingName = "Customer";
          dataGridLabelColumn61.ReadOnly = true;
          dataGridLabelColumn61.Width = 140;
          dataGridLabelColumn61.NullText = "N/A";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn61);
          DataGridLabelColumn dataGridLabelColumn62 = new DataGridLabelColumn();
          dataGridLabelColumn62.Format = "";
          dataGridLabelColumn62.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn62.HeaderText = "Property";
          dataGridLabelColumn62.MappingName = "Site";
          dataGridLabelColumn62.ReadOnly = true;
          dataGridLabelColumn62.Width = 140;
          dataGridLabelColumn62.NullText = "N/A";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn62);
          DataGridLabelColumn dataGridLabelColumn63 = new DataGridLabelColumn();
          dataGridLabelColumn63.Format = "";
          dataGridLabelColumn63.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn63.HeaderText = "Supplier";
          dataGridLabelColumn63.MappingName = "Supplier";
          dataGridLabelColumn63.ReadOnly = true;
          dataGridLabelColumn63.Width = 100;
          dataGridLabelColumn63.NullText = "N/A";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn63);
          DataGridLabelColumn dataGridLabelColumn64 = new DataGridLabelColumn();
          dataGridLabelColumn64.Format = "";
          dataGridLabelColumn64.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn64.HeaderText = "Job Number";
          dataGridLabelColumn64.MappingName = "JobNumber";
          dataGridLabelColumn64.ReadOnly = true;
          dataGridLabelColumn64.Width = 100;
          dataGridLabelColumn64.NullText = "N/A";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn64);
          DataGridLabelColumn dataGridLabelColumn65 = new DataGridLabelColumn();
          dataGridLabelColumn65.Format = "";
          dataGridLabelColumn65.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn65.HeaderText = "Status";
          dataGridLabelColumn65.MappingName = "DisplayStatus";
          dataGridLabelColumn65.ReadOnly = true;
          dataGridLabelColumn65.Width = 120;
          dataGridLabelColumn65.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn65);
          DataGridLabelColumn dataGridLabelColumn66 = new DataGridLabelColumn();
          dataGridLabelColumn66.Format = "";
          dataGridLabelColumn66.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn66.HeaderText = "Sup Inv Sent to Sage";
          dataGridLabelColumn66.MappingName = "SupplierExported";
          dataGridLabelColumn66.ReadOnly = true;
          dataGridLabelColumn66.Width = 50;
          dataGridLabelColumn66.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn66);
          DataGridLabelColumn dataGridLabelColumn67 = new DataGridLabelColumn();
          dataGridLabelColumn67.Format = "C";
          dataGridLabelColumn67.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn67.HeaderText = "Buy Price";
          dataGridLabelColumn67.MappingName = "BuyPrice";
          dataGridLabelColumn67.ReadOnly = true;
          dataGridLabelColumn67.Width = 75;
          dataGridLabelColumn67.NullText = "0";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn67);
          DataGridLabelColumn dataGridLabelColumn68 = new DataGridLabelColumn();
          dataGridLabelColumn68.Format = "C";
          dataGridLabelColumn68.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn68.HeaderText = "Sell Price";
          dataGridLabelColumn68.MappingName = "SellPrice";
          dataGridLabelColumn68.ReadOnly = true;
          dataGridLabelColumn68.Width = 75;
          dataGridLabelColumn68.NullText = "£0.00";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn68);
          DataGridLabelColumn dataGridLabelColumn69 = new DataGridLabelColumn();
          dataGridLabelColumn69.Format = "";
          dataGridLabelColumn69.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn69.HeaderText = "Created By";
          dataGridLabelColumn69.MappingName = "CreatedBy";
          dataGridLabelColumn69.ReadOnly = true;
          dataGridLabelColumn69.Width = 100;
          dataGridLabelColumn69.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn69);
          break;
        case Enums.TableNames.tblInvoiceAddress:
          DataGridLabelColumn dataGridLabelColumn70 = new DataGridLabelColumn();
          dataGridLabelColumn70.Format = "";
          dataGridLabelColumn70.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn70.HeaderText = "Address 1";
          dataGridLabelColumn70.MappingName = "Address1";
          dataGridLabelColumn70.ReadOnly = true;
          dataGridLabelColumn70.Width = 100;
          dataGridLabelColumn70.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn70);
          DataGridLabelColumn dataGridLabelColumn71 = new DataGridLabelColumn();
          dataGridLabelColumn71.Format = "";
          dataGridLabelColumn71.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn71.HeaderText = "Address 2";
          dataGridLabelColumn71.MappingName = "Address2";
          dataGridLabelColumn71.ReadOnly = true;
          dataGridLabelColumn71.Width = 100;
          dataGridLabelColumn71.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn71);
          DataGridLabelColumn dataGridLabelColumn72 = new DataGridLabelColumn();
          dataGridLabelColumn72.Format = "";
          dataGridLabelColumn72.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn72.HeaderText = "Address 3";
          dataGridLabelColumn72.MappingName = "Address3";
          dataGridLabelColumn72.ReadOnly = true;
          dataGridLabelColumn72.Width = 100;
          dataGridLabelColumn72.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn72);
          DataGridLabelColumn dataGridLabelColumn73 = new DataGridLabelColumn();
          dataGridLabelColumn73.Format = "";
          dataGridLabelColumn73.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn73.HeaderText = "Address 4";
          dataGridLabelColumn73.MappingName = "Address4";
          dataGridLabelColumn73.ReadOnly = true;
          dataGridLabelColumn73.Width = 100;
          dataGridLabelColumn73.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn73);
          DataGridLabelColumn dataGridLabelColumn74 = new DataGridLabelColumn();
          dataGridLabelColumn74.Format = "";
          dataGridLabelColumn74.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn74.HeaderText = "Address5";
          dataGridLabelColumn74.MappingName = "Address5";
          dataGridLabelColumn74.ReadOnly = true;
          dataGridLabelColumn74.Width = 100;
          dataGridLabelColumn74.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn74);
          DataGridLabelColumn dataGridLabelColumn75 = new DataGridLabelColumn();
          dataGridLabelColumn75.Format = "";
          dataGridLabelColumn75.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn75.HeaderText = "Postcode";
          dataGridLabelColumn75.MappingName = "Postcode";
          dataGridLabelColumn75.ReadOnly = true;
          dataGridLabelColumn75.Width = 75;
          dataGridLabelColumn75.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn75);
          break;
        case Enums.TableNames.tblJob:
          DataGridLabelColumn dataGridLabelColumn76 = new DataGridLabelColumn();
          dataGridLabelColumn76.Format = "";
          dataGridLabelColumn76.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn76.HeaderText = "Job Number";
          dataGridLabelColumn76.MappingName = "JobNumber";
          dataGridLabelColumn76.ReadOnly = true;
          dataGridLabelColumn76.Width = 100;
          dataGridLabelColumn76.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn76);
          DataGridLabelColumn dataGridLabelColumn77 = new DataGridLabelColumn();
          dataGridLabelColumn77.Format = "dd/MMM/yyyy";
          dataGridLabelColumn77.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn77.HeaderText = "Date Created";
          dataGridLabelColumn77.MappingName = "DateCreated";
          dataGridLabelColumn77.ReadOnly = true;
          dataGridLabelColumn77.Width = 100;
          dataGridLabelColumn77.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn77);
          DataGridLabelColumn dataGridLabelColumn78 = new DataGridLabelColumn();
          dataGridLabelColumn78.Format = "";
          dataGridLabelColumn78.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn78.HeaderText = "Definition";
          dataGridLabelColumn78.MappingName = "JobDefinition";
          dataGridLabelColumn78.ReadOnly = true;
          dataGridLabelColumn78.Width = 100;
          dataGridLabelColumn78.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn78);
          DataGridLabelColumn dataGridLabelColumn79 = new DataGridLabelColumn();
          dataGridLabelColumn79.Format = "";
          dataGridLabelColumn79.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn79.HeaderText = "Type";
          dataGridLabelColumn79.MappingName = "Type";
          dataGridLabelColumn79.ReadOnly = true;
          dataGridLabelColumn79.Width = 100;
          dataGridLabelColumn79.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn79);
          DataGridLabelColumn dataGridLabelColumn80 = new DataGridLabelColumn();
          dataGridLabelColumn80.Format = "";
          dataGridLabelColumn80.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn80.HeaderText = "Status";
          dataGridLabelColumn80.MappingName = "JobStatus";
          dataGridLabelColumn80.ReadOnly = true;
          dataGridLabelColumn80.Width = 100;
          dataGridLabelColumn80.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn80);
          DataGridLabelColumn dataGridLabelColumn81 = new DataGridLabelColumn();
          dataGridLabelColumn81.Format = "";
          dataGridLabelColumn81.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn81.HeaderText = "Created By";
          dataGridLabelColumn81.MappingName = "CreatedBy";
          dataGridLabelColumn81.ReadOnly = true;
          dataGridLabelColumn81.Width = 100;
          dataGridLabelColumn81.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn81);
          break;
        case Enums.TableNames.tblWarehouse:
          DataGridLabelColumn dataGridLabelColumn82 = new DataGridLabelColumn();
          dataGridLabelColumn82.Format = "";
          dataGridLabelColumn82.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn82.HeaderText = "Name";
          dataGridLabelColumn82.MappingName = "Name";
          dataGridLabelColumn82.ReadOnly = true;
          dataGridLabelColumn82.Width = 100;
          dataGridLabelColumn82.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn82);
          DataGridLabelColumn dataGridLabelColumn83 = new DataGridLabelColumn();
          dataGridLabelColumn83.Format = "";
          dataGridLabelColumn83.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn83.HeaderText = "Address 1";
          dataGridLabelColumn83.MappingName = "Address1";
          dataGridLabelColumn83.ReadOnly = true;
          dataGridLabelColumn83.Width = 100;
          dataGridLabelColumn83.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn83);
          DataGridLabelColumn dataGridLabelColumn84 = new DataGridLabelColumn();
          dataGridLabelColumn84.Format = "";
          dataGridLabelColumn84.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn84.HeaderText = "Address 2";
          dataGridLabelColumn84.MappingName = "Address2";
          dataGridLabelColumn84.ReadOnly = true;
          dataGridLabelColumn84.Width = 100;
          dataGridLabelColumn84.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn84);
          DataGridLabelColumn dataGridLabelColumn85 = new DataGridLabelColumn();
          dataGridLabelColumn85.Format = "";
          dataGridLabelColumn85.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn85.HeaderText = "Address 3";
          dataGridLabelColumn85.MappingName = "Address3";
          dataGridLabelColumn85.ReadOnly = true;
          dataGridLabelColumn85.Width = 100;
          dataGridLabelColumn85.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn85);
          DataGridLabelColumn dataGridLabelColumn86 = new DataGridLabelColumn();
          dataGridLabelColumn86.Format = "";
          dataGridLabelColumn86.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn86.HeaderText = "Address 4";
          dataGridLabelColumn86.MappingName = "Address4";
          dataGridLabelColumn86.ReadOnly = true;
          dataGridLabelColumn86.Width = 100;
          dataGridLabelColumn86.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn86);
          DataGridLabelColumn dataGridLabelColumn87 = new DataGridLabelColumn();
          dataGridLabelColumn87.Format = "";
          dataGridLabelColumn87.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn87.HeaderText = "Address 5";
          dataGridLabelColumn87.MappingName = "Address5";
          dataGridLabelColumn87.ReadOnly = true;
          dataGridLabelColumn87.Width = 100;
          dataGridLabelColumn87.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn87);
          DataGridLabelColumn dataGridLabelColumn88 = new DataGridLabelColumn();
          dataGridLabelColumn88.Format = "";
          dataGridLabelColumn88.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn88.HeaderText = "Postcode";
          dataGridLabelColumn88.MappingName = "Postcode";
          dataGridLabelColumn88.ReadOnly = true;
          dataGridLabelColumn88.Width = 100;
          dataGridLabelColumn88.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn88);
          DataGridLabelColumn dataGridLabelColumn89 = new DataGridLabelColumn();
          dataGridLabelColumn89.Format = "";
          dataGridLabelColumn89.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn89.HeaderText = "Tel";
          dataGridLabelColumn89.MappingName = "TelephoneNum";
          dataGridLabelColumn89.ReadOnly = true;
          dataGridLabelColumn89.Width = 100;
          dataGridLabelColumn89.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn89);
          break;
        case Enums.TableNames.tblLocations:
          DataGridLabelColumn dataGridLabelColumn90 = new DataGridLabelColumn();
          dataGridLabelColumn90.Format = "";
          dataGridLabelColumn90.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn90.HeaderText = "Type";
          dataGridLabelColumn90.MappingName = "LocationType";
          dataGridLabelColumn90.ReadOnly = true;
          dataGridLabelColumn90.Width = 100;
          dataGridLabelColumn90.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn90);
          DataGridLabelColumn dataGridLabelColumn91 = new DataGridLabelColumn();
          dataGridLabelColumn91.Format = "";
          dataGridLabelColumn91.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn91.HeaderText = "Name";
          dataGridLabelColumn91.MappingName = "Name";
          dataGridLabelColumn91.ReadOnly = true;
          dataGridLabelColumn91.Width = 300;
          dataGridLabelColumn91.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn91);
          break;
        case Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
        case Enums.TableNames.NOT_IN_DATABASE_VansForPart:
          DataGridLabelColumn dataGridLabelColumn92 = new DataGridLabelColumn();
          dataGridLabelColumn92.Format = "";
          dataGridLabelColumn92.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn92.HeaderText = "Engineer Name";
          dataGridLabelColumn92.MappingName = "EngineerName";
          dataGridLabelColumn92.ReadOnly = true;
          dataGridLabelColumn92.Width = 100;
          dataGridLabelColumn92.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn92);
          DataGridLabelColumn dataGridLabelColumn93 = new DataGridLabelColumn();
          dataGridLabelColumn93.Format = "";
          dataGridLabelColumn93.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn93.HeaderText = "Registration";
          dataGridLabelColumn93.MappingName = "Registration";
          dataGridLabelColumn93.ReadOnly = true;
          dataGridLabelColumn93.Width = 100;
          dataGridLabelColumn93.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn93);
          DataGridLabelColumn dataGridLabelColumn94 = new DataGridLabelColumn();
          dataGridLabelColumn94.Format = "";
          dataGridLabelColumn94.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn94.HeaderText = "Item Name";
          dataGridLabelColumn94.MappingName = "Name";
          dataGridLabelColumn94.ReadOnly = true;
          dataGridLabelColumn94.Width = 100;
          dataGridLabelColumn94.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn94);
          DataGridLabelColumn dataGridLabelColumn95 = new DataGridLabelColumn();
          dataGridLabelColumn95.Format = "";
          dataGridLabelColumn95.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn95.HeaderText = "Item Number";
          dataGridLabelColumn95.MappingName = "Number";
          dataGridLabelColumn95.ReadOnly = true;
          dataGridLabelColumn95.Width = 100;
          dataGridLabelColumn95.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn94);
          DataGridLabelColumn dataGridLabelColumn96 = new DataGridLabelColumn();
          dataGridLabelColumn96.Format = "";
          dataGridLabelColumn96.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn96.HeaderText = "Amount";
          dataGridLabelColumn96.MappingName = "Amount";
          dataGridLabelColumn96.ReadOnly = true;
          dataGridLabelColumn96.Width = 100;
          dataGridLabelColumn96.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn96);
          break;
        case Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
        case Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
          DataGridLabelColumn dataGridLabelColumn97 = new DataGridLabelColumn();
          dataGridLabelColumn97.Format = "";
          dataGridLabelColumn97.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn97.HeaderText = "Name";
          dataGridLabelColumn97.MappingName = "warehouseName";
          dataGridLabelColumn97.ReadOnly = true;
          dataGridLabelColumn97.Width = 100;
          dataGridLabelColumn97.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn97);
          DataGridLabelColumn dataGridLabelColumn98 = new DataGridLabelColumn();
          dataGridLabelColumn98.Format = "";
          dataGridLabelColumn98.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn98.HeaderText = "Address 1";
          dataGridLabelColumn98.MappingName = "Address1";
          dataGridLabelColumn98.ReadOnly = true;
          dataGridLabelColumn98.Width = 100;
          dataGridLabelColumn98.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn98);
          DataGridLabelColumn dataGridLabelColumn99 = new DataGridLabelColumn();
          dataGridLabelColumn99.Format = "";
          dataGridLabelColumn99.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn99.HeaderText = "Postcode";
          dataGridLabelColumn99.MappingName = "Postcode";
          dataGridLabelColumn99.ReadOnly = true;
          dataGridLabelColumn99.Width = 100;
          dataGridLabelColumn99.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn99);
          DataGridLabelColumn dataGridLabelColumn100 = new DataGridLabelColumn();
          dataGridLabelColumn100.Format = "";
          dataGridLabelColumn100.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn100.HeaderText = "Tel";
          dataGridLabelColumn100.MappingName = "TelephoneNum";
          dataGridLabelColumn100.ReadOnly = true;
          dataGridLabelColumn100.Width = 100;
          dataGridLabelColumn100.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn100);
          DataGridLabelColumn dataGridLabelColumn101 = new DataGridLabelColumn();
          dataGridLabelColumn101.Format = "";
          dataGridLabelColumn101.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn101.HeaderText = "Amount";
          dataGridLabelColumn101.MappingName = "Amount";
          dataGridLabelColumn101.ReadOnly = true;
          dataGridLabelColumn101.Width = 100;
          dataGridLabelColumn101.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn101);
          break;
        case Enums.TableNames.tblSystemScheduleOfRate:
          DataGridLabelColumn dataGridLabelColumn102 = new DataGridLabelColumn();
          dataGridLabelColumn102.Format = "";
          dataGridLabelColumn102.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn102.HeaderText = "Category";
          dataGridLabelColumn102.MappingName = "Category";
          dataGridLabelColumn102.ReadOnly = true;
          dataGridLabelColumn102.Width = 100;
          dataGridLabelColumn102.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn102);
          DataGridLabelColumn dataGridLabelColumn103 = new DataGridLabelColumn();
          dataGridLabelColumn103.Format = "";
          dataGridLabelColumn103.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn103.HeaderText = "Code";
          dataGridLabelColumn103.MappingName = "Code";
          dataGridLabelColumn103.ReadOnly = true;
          dataGridLabelColumn103.Width = 100;
          dataGridLabelColumn103.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn103);
          DataGridLabelColumn dataGridLabelColumn104 = new DataGridLabelColumn();
          dataGridLabelColumn104.Format = "";
          dataGridLabelColumn104.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn104.HeaderText = "Description";
          dataGridLabelColumn104.MappingName = "Description";
          dataGridLabelColumn104.ReadOnly = true;
          dataGridLabelColumn104.Width = 250;
          dataGridLabelColumn104.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn104);
          DataGridLabelColumn dataGridLabelColumn105 = new DataGridLabelColumn();
          dataGridLabelColumn105.Format = "";
          dataGridLabelColumn105.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn105.HeaderText = "Time (Mins)";
          dataGridLabelColumn105.MappingName = "TimeInMins";
          dataGridLabelColumn105.ReadOnly = true;
          dataGridLabelColumn105.Width = 80;
          dataGridLabelColumn105.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn105);
          DataGridLabelColumn dataGridLabelColumn106 = new DataGridLabelColumn();
          dataGridLabelColumn106.Format = "C";
          dataGridLabelColumn106.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn106.HeaderText = "Unit Price";
          dataGridLabelColumn106.MappingName = "Price";
          dataGridLabelColumn106.ReadOnly = true;
          dataGridLabelColumn106.Width = 80;
          dataGridLabelColumn106.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn106);
          break;
        case Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
          DataGridLabelColumn dataGridLabelColumn107 = new DataGridLabelColumn();
          dataGridLabelColumn107.Format = "";
          dataGridLabelColumn107.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn107.HeaderText = "Location Type";
          dataGridLabelColumn107.MappingName = "LocationType";
          dataGridLabelColumn107.ReadOnly = true;
          dataGridLabelColumn107.Width = 100;
          dataGridLabelColumn107.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn107);
          DataGridLabelColumn dataGridLabelColumn108 = new DataGridLabelColumn();
          dataGridLabelColumn108.Format = "";
          dataGridLabelColumn108.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn108.HeaderText = "Location";
          dataGridLabelColumn108.MappingName = "Name";
          dataGridLabelColumn108.ReadOnly = true;
          dataGridLabelColumn108.Width = 100;
          dataGridLabelColumn108.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn108);
          break;
        case Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
          DataGridLabelColumn dataGridLabelColumn109 = new DataGridLabelColumn();
          dataGridLabelColumn109.Format = "";
          dataGridLabelColumn109.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn109.HeaderText = "Name";
          dataGridLabelColumn109.MappingName = "Name";
          dataGridLabelColumn109.ReadOnly = true;
          dataGridLabelColumn109.Width = 300;
          dataGridLabelColumn109.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn109);
          break;
        case Enums.TableNames.tblFleetVan:
          DataGridLabelColumn dataGridLabelColumn110 = new DataGridLabelColumn();
          dataGridLabelColumn110.Format = "";
          dataGridLabelColumn110.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn110.HeaderText = "Registration";
          dataGridLabelColumn110.MappingName = "Registration";
          dataGridLabelColumn110.ReadOnly = true;
          dataGridLabelColumn110.Width = 150;
          dataGridLabelColumn110.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn110);
          DataGridLabelColumn dataGridLabelColumn111 = new DataGridLabelColumn();
          dataGridLabelColumn111.Format = "";
          dataGridLabelColumn111.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn111.HeaderText = "Engineer";
          dataGridLabelColumn111.MappingName = "Name";
          dataGridLabelColumn111.ReadOnly = true;
          dataGridLabelColumn111.Width = 350;
          dataGridLabelColumn111.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn111);
          break;
        case Enums.TableNames.tblFleetVanMaintenance:
          DataGridLabelColumn dataGridLabelColumn112 = new DataGridLabelColumn();
          dataGridLabelColumn112.Format = "";
          dataGridLabelColumn112.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn112.HeaderText = "Registration";
          dataGridLabelColumn112.MappingName = "Registration";
          dataGridLabelColumn112.ReadOnly = true;
          dataGridLabelColumn112.Width = 150;
          dataGridLabelColumn112.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn112);
          DataGridLabelColumn dataGridLabelColumn113 = new DataGridLabelColumn();
          dataGridLabelColumn113.Format = "";
          dataGridLabelColumn113.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn113.HeaderText = "Fault";
          dataGridLabelColumn113.MappingName = "Name";
          dataGridLabelColumn113.ReadOnly = true;
          dataGridLabelColumn113.Width = 150;
          dataGridLabelColumn113.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn113);
          DataGridLabelColumn dataGridLabelColumn114 = new DataGridLabelColumn();
          dataGridLabelColumn114.Format = "";
          dataGridLabelColumn114.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn114.HeaderText = "Fault Date";
          dataGridLabelColumn114.MappingName = "FaultDate";
          dataGridLabelColumn114.ReadOnly = true;
          dataGridLabelColumn114.Width = 250;
          dataGridLabelColumn114.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn114);
          break;
        case Enums.TableNames.tblEngineerSkills:
          DataGridLabelColumn dataGridLabelColumn115 = new DataGridLabelColumn();
          dataGridLabelColumn115.Format = "";
          dataGridLabelColumn115.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn115.HeaderText = "Name";
          dataGridLabelColumn115.MappingName = "Name";
          dataGridLabelColumn115.ReadOnly = true;
          dataGridLabelColumn115.Width = 300;
          dataGridLabelColumn115.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn115);
          DataGridLabelColumn dataGridLabelColumn116 = new DataGridLabelColumn();
          dataGridLabelColumn116.Format = "";
          dataGridLabelColumn116.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn116.HeaderText = "Description";
          dataGridLabelColumn116.MappingName = "Description";
          dataGridLabelColumn116.ReadOnly = true;
          dataGridLabelColumn116.Width = 250;
          dataGridLabelColumn116.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn116);
          break;
        case Enums.TableNames.tblEngineerRole:
          DataGridLabelColumn dataGridLabelColumn117 = new DataGridLabelColumn();
          dataGridLabelColumn117.Format = "";
          dataGridLabelColumn117.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn117.HeaderText = "Name";
          dataGridLabelColumn117.MappingName = "Name";
          dataGridLabelColumn117.ReadOnly = true;
          dataGridLabelColumn117.Width = 300;
          dataGridLabelColumn117.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn117);
          DataGridLabelColumn dataGridLabelColumn118 = new DataGridLabelColumn();
          dataGridLabelColumn118.Format = "";
          dataGridLabelColumn118.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn118.HeaderText = "Department";
          dataGridLabelColumn118.MappingName = "Department";
          dataGridLabelColumn118.ReadOnly = true;
          dataGridLabelColumn118.Width = 250;
          dataGridLabelColumn118.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn118);
          break;
      }
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
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
      dataGridLabelColumn3.HeaderText = "Shelf";
      dataGridLabelColumn3.MappingName = "Shelf";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Bin";
      dataGridLabelColumn4.MappingName = "Bin";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Qty";
      dataGridLabelColumn5.MappingName = "Quantity";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblStock.ToString();
      this.dgStock.TableStyles.Add(tableStyle);
    }

    private void DLGFindRecord_Load(object sender, EventArgs e)
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

    private void dgResults_Select(object sender, EventArgs e)
    {
      if (this.TableToSearch != Enums.TableNames.tblPart)
        return;
      if (this.SelectedDataRow == null)
      {
        this.StockDataview = (DataView) null;
        this.grpStock.Text = "Stock Locations for : 'No Part Selected'";
      }
      else
      {
        this.StockDataview = this.Trans == null ? App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.SelectedDataRow["PartID"]), 0) : App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.SelectedDataRow["PartID"]), this.Trans, 0);
        this.grpStock.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Stock Locations for : '", this.SelectedDataRow["Name"]), (object) "'"));
      }
    }

    private void dgResults_DoubleClick(object sender, EventArgs e)
    {
      if (this.TableToSearch == Enums.TableNames.tblPart)
      {
        if (this.SelectedDataRow == null)
          return;
        App.ShowForm(typeof (FRMPart), true, new object[2]
        {
          this.SelectedDataRow["PartID"],
          (object) true
        }, false);
        this.Records = App.DB.Part.Part_GetAll(false);
        this.RunFilter();
      }
      else
        this.SelectItem();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.SelectItem();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      switch (this.TableToSearch)
      {
        case Enums.TableNames.tblPart:
          App.ShowForm(typeof (FRMPart), true, new object[2]
          {
            (object) 0,
            (object) true
          }, false);
          this.TableToSearch = Enums.TableNames.tblPart;
          break;
        case Enums.TableNames.tblProduct:
          App.ShowForm(typeof (FRMProduct), true, new object[2]
          {
            (object) 0,
            (object) true
          }, false);
          this.TableToSearch = Enums.TableNames.tblProduct;
          break;
      }
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
          case Enums.TableNames.tblUser:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["UserID"]);
            break;
          case Enums.TableNames.tblCustomer:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["CustomerID"]);
            break;
          case Enums.TableNames.tblPart:
            if (this.ForMassPartEntry)
            {
              this.PartsToAdd = new ArrayList();
              IEnumerator enumerator;
              try
              {
                enumerator = this.Records.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["QuantityToAdd"], (object) 0, false))
                    this.PartsToAdd.Add((object) new ArrayList()
                    {
                      RuntimeHelpers.GetObjectValue(current["PartID"]),
                      RuntimeHelpers.GetObjectValue(current["QuantityToAdd"])
                    });
                }
                break;
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
            }
            else
            {
              this.ID = Conversions.ToInteger(this.SelectedDataRow["PartID"]);
              break;
            }
          case Enums.TableNames.tblProduct:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["ProductID"]);
            break;
          case Enums.TableNames.tblSupplier:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SupplierID"]));
            break;
          case Enums.TableNames.tblEngineer:
          case Enums.TableNames.tblEngineerRole:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["EngineerID"]));
            break;
          case Enums.TableNames.tblVan:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["VanID"]);
            break;
          case Enums.TableNames.tblSite:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["SiteID"]);
            break;
          case Enums.TableNames.tblContact:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["ContactID"]);
            break;
          case Enums.TableNames.tblPartSupplier:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["PartSupplierID"]));
            this.SecondID = Conversions.ToInteger(this.SelectedDataRow["PartID"]);
            break;
          case Enums.TableNames.tblProductSupplier:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["ProductSupplierID"]));
            this.SecondID = Conversions.ToInteger(this.SelectedDataRow["ProductID"]);
            break;
          case Enums.TableNames.tblOrder:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["OrderID"]));
            break;
          case Enums.TableNames.tblInvoiceAddress:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["InvoiceAddressID"]);
            break;
          case Enums.TableNames.tblJob:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobID"]));
            break;
          case Enums.TableNames.tblWarehouse:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["WarehouseID"]);
            break;
          case Enums.TableNames.tblLocations:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["LocationID"]);
            break;
          case Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SupplierID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SupplierID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["LocationID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["LocationID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["LocationID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_VansForPart:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["LocationID"]));
            break;
          case Enums.TableNames.tblSystemScheduleOfRate:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SystemScheduleOfRateID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["LocationID"]));
            break;
          case Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["ManagerID"]);
            break;
          case Enums.TableNames.tblFleetVan:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["VanID"]));
            break;
          case Enums.TableNames.tblFleetVanMaintenance:
            this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["VanFaultID"]));
            break;
          case Enums.TableNames.tblEngineerSkills:
            this.ID = Conversions.ToInteger(this.SelectedDataRow["ManagerID"]);
            break;
        }
        this.DialogResult = DialogResult.OK;
      }
    }

    private void RunFilter()
    {
      string str = "Deleted = 0";
      if ((uint) this.txtFilter.Text.Trim().Length > 0U)
      {
        switch (this.TableToSearch)
        {
          case Enums.TableNames.tblUser:
            str = str + " AND FullName LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblPart:
            str = str + " AND Name LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblProduct:
            str = str + " AND typemakemodel LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblVan:
          case Enums.TableNames.tblFleetVan:
            str = str + " AND Registration LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblSite:
            str = str + " AND (Name LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Address1 LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Address2 LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PostCode LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PolicyNumber LIKE '%" + this.txtFilter.Text.Trim() + "%')";
            break;
          case Enums.TableNames.tblContact:
            str = str + " AND (Firstname LIKE '%" + this.txtFilter.Text.Trim() + "%') OR (Surname LIKE '%" + this.txtFilter.Text.Trim() + "%')";
            break;
          case Enums.TableNames.tblPartSupplier:
            str = str + " AND PartCode LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblOrder:
            str = str + " AND OrderReference LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblJob:
            str = str + " AND JobNumber LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblSystemScheduleOfRate:
            str = str + "AND (Description LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Code LIKE '%" + this.txtFilter.Text.Trim() + "%')";
            break;
          case Enums.TableNames.tblFleetVanMaintenance:
            str = "Registration LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblEngineerSkills:
            str = str + "AND (Description LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Name LIKE '%" + this.txtFilter.Text.Trim() + "%') AND EnumTypeID = 7";
            break;
          default:
            str = str + " AND Name LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
        }
      }
      if (this.cbOffice.Checked)
        str += " AND Accommodation = 'Office'";
      this.Records.RowFilter = Helper.MakeIntegerValid((object) this.ForeignKeyFilter) != 1 || this.TableToSearch != Enums.TableNames.tblSupplier ? str : "MasterSupplierID = 0 AND " + str;
      this.StockDataview = (DataView) null;
      this.grpStock.Text = "Stock Locations for : 'No Part Selected'";
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cbOffice_CheckedChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    public class ColourColumn : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush brush = Brushes.White;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "Preferred"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))))
          brush = Brushes.LightGreen;
        this.TextBox.Text = "";
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
        g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }
  }
}
