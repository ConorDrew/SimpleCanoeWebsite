using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGFindRecord : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DLGFindRecord() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            base.Load += DLGFindRecord_Load;
        }

        public DLGFindRecord(System.Data.SqlClient.SqlTransaction trans) : base()
        {
            Trans = trans;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private TextBox _txtFilter;

        internal TextBox txtFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged -= txtFilter_TextChanged;
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged += txtFilter_TextChanged;
                }
            }
        }

        private GroupBox _grpResults;

        internal GroupBox grpResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpResults != null)
                {
                }

                _grpResults = value;
                if (_grpResults != null)
                {
                }
            }
        }

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private GroupBox _grpStock;

        internal GroupBox grpStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpStock != null)
                {
                }

                _grpStock = value;
                if (_grpStock != null)
                {
                }
            }
        }

        private DataGrid _dgStock;

        internal DataGrid dgStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgStock != null)
                {
                }

                _dgStock = value;
                if (_dgStock != null)
                {
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private CheckBox _cbOffice;

        internal CheckBox cbOffice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbOffice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbOffice != null)
                {
                    _cbOffice.CheckedChanged -= cbOffice_CheckedChanged;
                }

                _cbOffice = value;
                if (_cbOffice != null)
                {
                    _cbOffice.CheckedChanged += cbOffice_CheckedChanged;
                }
            }
        }

        private DataGrid _dgResults;

        internal DataGrid dgResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgResults != null)
                {
                    _dgResults.Click -= dgResults_Select;
                    _dgResults.CurrentCellChanged -= dgResults_Select;
                    _dgResults.DoubleClick -= dgResults_DoubleClick;
                }

                _dgResults = value;
                if (_dgResults != null)
                {
                    _dgResults.Click += dgResults_Select;
                    _dgResults.CurrentCellChanged += dgResults_Select;
                    _dgResults.DoubleClick += dgResults_DoubleClick;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _Label1 = new Label();
            _txtFilter = new TextBox();
            _txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
            _grpResults = new GroupBox();
            _dgResults = new DataGrid();
            _dgResults.Click += new EventHandler(dgResults_Select);
            _dgResults.CurrentCellChanged += new EventHandler(dgResults_Select);
            _dgResults.Click += new EventHandler(dgResults_Select);
            _dgResults.CurrentCellChanged += new EventHandler(dgResults_Select);
            _dgResults.DoubleClick += new EventHandler(dgResults_DoubleClick);
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _grpStock = new GroupBox();
            _dgStock = new DataGrid();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _Label2 = new Label();
            _Panel1 = new Panel();
            _cbOffice = new CheckBox();
            _cbOffice.CheckedChanged += new EventHandler(cbOffice_CheckedChanged);
            _grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgResults).BeginInit();
            _grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgStock).BeginInit();
            SuspendLayout();
            //
            // Label1
            //
            _Label1.Location = new Point(8, 40);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 24);
            _Label1.TabIndex = 2;
            _Label1.Text = "Filter By Name";
            //
            // txtFilter
            //
            _txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFilter.Location = new Point(104, 40);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(548, 21);
            _txtFilter.TabIndex = 1;
            //
            // grpResults
            //
            _grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpResults.Controls.Add(_dgResults);
            _grpResults.Location = new Point(8, 68);
            _grpResults.Name = "grpResults";
            _grpResults.Size = new Size(793, 377);
            _grpResults.TabIndex = 4;
            _grpResults.TabStop = false;
            _grpResults.Text = "Select record and click OK";
            //
            // dgResults
            //
            _dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgResults.DataMember = "";
            _dgResults.HeaderForeColor = SystemColors.ControlText;
            _dgResults.Location = new Point(8, 27);
            _dgResults.Name = "dgResults";
            _dgResults.Size = new Size(779, 342);
            _dgResults.TabIndex = 2;
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(745, 451);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(56, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 451);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            //
            // grpStock
            //
            _grpStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpStock.Controls.Add(_dgStock);
            _grpStock.Location = new Point(8, 280);
            _grpStock.Name = "grpStock";
            _grpStock.Size = new Size(793, 165);
            _grpStock.TabIndex = 5;
            _grpStock.TabStop = false;
            _grpStock.Text = "Stock Locations for : 'No Part Selected'";
            _grpStock.Visible = false;
            //
            // dgStock
            //
            _dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgStock.DataMember = "";
            _dgStock.HeaderForeColor = SystemColors.ControlText;
            _dgStock.Location = new Point(8, 20);
            _dgStock.Name = "dgStock";
            _dgStock.Size = new Size(779, 137);
            _dgStock.TabIndex = 3;
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdd.Location = new Point(672, 39);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(129, 23);
            _btnAdd.TabIndex = 6;
            _btnAdd.Text = "Add";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label2.Location = new Point(95, 456);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(175, 24);
            _Label2.TabIndex = 7;
            _Label2.Text = "Preferred Supplier";
            //
            // Panel1
            //
            _Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel1.BackColor = Color.LightGreen;
            _Panel1.Location = new Point(70, 454);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(19, 20);
            _Panel1.TabIndex = 8;
            //
            // cbOffice
            //
            _cbOffice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cbOffice.AutoSize = true;
            _cbOffice.Location = new Point(665, 42);
            _cbOffice.Name = "cbOffice";
            _cbOffice.Size = new Size(130, 17);
            _cbOffice.TabIndex = 9;
            _cbOffice.Text = "Only Show Offices";
            _cbOffice.UseVisualStyleBackColor = true;
            _cbOffice.Visible = false;
            //
            // DLGFindRecord
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(809, 481);
            ControlBox = false;
            Controls.Add(_cbOffice);
            Controls.Add(_Panel1);
            Controls.Add(_Label2);
            Controls.Add(_btnAdd);
            Controls.Add(_grpStock);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_grpResults);
            Controls.Add(_txtFilter);
            Controls.Add(_Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(704, 392);
            Name = "DLGFindRecord";
            Text = "Find {0}";
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_txtFilter, 0);
            Controls.SetChildIndex(_grpResults, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_grpStock, 0);
            Controls.SetChildIndex(_btnAdd, 0);
            Controls.SetChildIndex(_Label2, 0);
            Controls.SetChildIndex(_Panel1, 0);
            Controls.SetChildIndex(_cbOffice, 0);
            _grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgResults).EndInit();
            _grpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ActiveControl = txtFilter;
            txtFilter.Focus();
            SetupDG();
            SetupStockDatagrid();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private System.Data.SqlClient.SqlTransaction _Trans;

        public System.Data.SqlClient.SqlTransaction Trans
        {
            get
            {
                return _Trans;
            }

            set
            {
                _Trans = value;
            }
        }

        private Entity.Sys.Enums.TableNames _TableToSearch = Entity.Sys.Enums.TableNames.NO_TABLE;

        public Entity.Sys.Enums.TableNames TableToSearch
        {
            get
            {
                return _TableToSearch;
            }

            set
            {
                MinimumSize = new Size(new Point(704, 392));
                _TableToSearch = value;
                btnAdd.Visible = false;
                var switchExpr = TableToSearch;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
                        {
                            Text = "Find Bin Reference";
                            Records = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences);
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblLocations:
                        {
                            Text = "Find Location";
                            Records = App.DB.Location.Locations_GetAll_WithNames();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblCustomer:
                        {
                            Text = "Find Customer";
                            Records = App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID);
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblUser:
                        {
                            Text = "Find User";
                            Records = App.DB.User.GetAll();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSite:
                        {
                            if (ForeignKeyFilters.Count > 0)
                            {
                                Text = "Find Property For Customer";
                                var dtRecords = new DataTable();
                                foreach (int custId in ForeignKeyFilters)
                                {
                                    var dvSites = App.DB.Sites.GetForCustomer_Light(custId, App.loggedInUser.UserID);
                                    if (dvSites.Count > 0)
                                        dtRecords.Merge(dvSites.Table);
                                }

                                Records = new DataView(dtRecords);
                            }
                            else if (ForeignKeyFilter > 0)
                            {
                                Text = "Find Property For Customer";
                                Records = App.DB.Sites.GetForCustomer_Light(ForeignKeyFilter, App.loggedInUser.UserID);
                            }
                            else
                            {
                                Text = "Find Property";
                                Records = App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID);
                            }

                            cbOffice.Visible = true;
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblInvoiceAddress:
                        {
                            if (ForeignKeyFilter > 0)
                            {
                                Text = "Find Invoice Address For Property";
                                Records = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(ForeignKeyFilter);
                            }
                            else
                            {
                                Text = "Find Invoice Address";
                                Records = App.DB.InvoiceAddress.InvoiceAddress_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblContact:
                        {
                            if (ForeignKeyFilter > 0)
                            {
                                Text = "Find Contact For Property";
                                Records = App.DB.Contact.Contact_GetForSite(ForeignKeyFilter);
                            }
                            else
                            {
                                Text = "Find Contact";
                                Records = App.DB.Contact.Contact_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblJob:
                        {
                            Text = "Find Job";
                            Records = App.DB.Job.Job_Get_All("Where tblJob.Deleted = 0");
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblWarehouse:
                        {
                            Text = "Find Warehouse";
                            if (Trans is object)
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblVan:
                        {
                            Text = "Find Stock Profile";
                            Records = App.DB.Van.Van_GetAll(false);
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblProduct:
                        {
                            Text = "Find Product";
                            if (Trans is object)
                            {
                                Records = App.DB.Product.Product_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Product.Product_GetAll();
                            }

                            btnAdd.Visible = true;
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPart:
                        {
                            Text = "Find Part";
                            if (ForeignKeyFilter == 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Part.Part_GetAll(Trans);
                                }
                                else
                                {
                                    Records = App.DB.Part.Part_GetAll(ForMassPartEntry);
                                }

                                Height = 392;
                                grpResults.Height = 79;
                                Height = 600;
                                grpStock.Visible = true;
                                btnAdd.Visible = true;
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Order.OrderPart_GetForOrder(ForeignKeyFilter, Trans);
                            }
                            else
                            {
                                Records = App.DB.Order.OrderPart_GetForOrder(ForeignKeyFilter);
                            }

                            txtFilter.Text = PartNumber;
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPartSupplier:
                        {
                            Text = "Find Part";
                            Records = App.DB.PartSupplier.PartSupplierGet_All();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblProductSupplier:
                        {
                            Text = "Find Product";
                            Records = App.DB.ProductSupplier.ProductSupplierGet_All();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSupplier:
                        {
                            Text = "Find Supplier";
                            Records = App.DB.Supplier.Supplier_GetAll();
                            if (Entity.Sys.Helper.MakeIntegerValid(ForeignKeyFilter) == 1)
                            {
                                Records.RowFilter = "MasterSupplierID = 0";
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart:
                        {
                            Text = "Find Van";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Van.Van_GetWithPart(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Van.Van_GetWithPart(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Van.Van_GetAll(false, Trans);
                            }
                            else
                            {
                                Records = App.DB.Van.Van_GetAll(false);
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
                        {
                            Text = "Find Van";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Van.Van_GetWithProduct(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Van.Van_GetWithProduct(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Van.Van_GetAll(false, Trans);
                            }
                            else
                            {
                                Records = App.DB.Van.Van_GetAll(false);
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
                        {
                            Text = "Find Supplier";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Supplier.Supplier_GetWithProduct(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Supplier.Supplier_GetWithProduct(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Supplier.Supplier_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Supplier.Supplier_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
                        {
                            Text = "Find Supplier";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Supplier.Supplier_GetWithPart(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Supplier.Supplier_GetWithPart(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Supplier.Supplier_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Supplier.Supplier_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
                        {
                            Text = "Find Warehouse";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Warehouse.Warehouse_GetWithProduct(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Warehouse.Warehouse_GetWithProduct(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
                        {
                            Text = "Find Warehouse";
                            if (ForeignKeyFilter > 0)
                            {
                                if (Trans is object)
                                {
                                    Records = App.DB.Warehouse.Warehouse_GetWithPart(ForeignKeyFilter, Trans);
                                }
                                else
                                {
                                    Records = App.DB.Warehouse.Warehouse_GetWithPart(ForeignKeyFilter);
                                }
                            }
                            else if (Trans is object)
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll(Trans);
                            }
                            else
                            {
                                Records = App.DB.Warehouse.Warehouse_GetAll();
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
                        {
                            Text = "Select A Location for the Unallocated Received Job Parts/Products to be placed";
                            if (Trans is null)
                            {
                                Records = App.DB.Location.Locations_GetAll_WithNames();
                            }
                            else
                            {
                                Records = App.DB.Location.Locations_GetAll_WithNames(Trans);
                            }

                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblEngineer:
                        {
                            Text = "Find an Engineer";
                            Records = App.DB.Engineer.Engineer_GetAll();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblOrder:
                        {
                            Text = "Find an Order";
                            Records = App.DB.Order.Order_GetAll("");
                            Records.RowFilter = " SupplierID > 0 AND OrderTypeID <> 1 AND OrderTypeID <> 4 AND DisplayStatusID >= " + Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete);
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblFleetVan:
                        {
                            Text = "Find Van";
                            Records = App.DB.FleetVan.GetAll();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblFleetVanFault:
                        {
                            Text = "Find Fault";
                            Records = App.DB.FleetVanFault.GetAll_Unresolved_WithNoJob();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate:
                        {
                            Text = "Find SOR";
                            Records = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll();
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblEngineerSkills:
                        {
                            Text = "Find Engineer Skill";
                            Records = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels);
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblEngineerRole:
                        {
                            Text = "Find an Engineer";
                            Records = App.DB.EngineerRole.GetEngineersNotAssignedToRole();
                            break;
                        }
                }

                if (TableToSearch == Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans)
                {
                    btnCancel.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = true;
                }

                MinimumSize = Size;
            }
        }

        private int _foreignKeyFilter;

        public int ForeignKeyFilter
        {
            get
            {
                return _foreignKeyFilter;
            }

            set
            {
                _foreignKeyFilter = value;
            }
        }

        private List<int> _foreignKeyFilters = new List<int>();

        public List<int> ForeignKeyFilters
        {
            get
            {
                return _foreignKeyFilters;
            }

            set
            {
                _foreignKeyFilters = value;
            }
        }

        private string _PartNumber;

        public string PartNumber
        {
            get
            {
                return _PartNumber;
            }

            set
            {
                _PartNumber = value;
            }
        }

        private bool _ForMassPartEntry = false;

        public bool ForMassPartEntry
        {
            get
            {
                return _ForMassPartEntry;
            }

            set
            {
                _ForMassPartEntry = value;
            }
        }

        private DataView _dvRecords;

        private DataView Records
        {
            get
            {
                return _dvRecords;
            }

            set
            {
                _dvRecords = value;
                _dvRecords.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
                _dvRecords.AllowNew = false;
                if (ForMassPartEntry)
                {
                    _dvRecords.AllowEdit = true;
                }
                else
                {
                    _dvRecords.AllowEdit = false;
                }

                _dvRecords.AllowDelete = false;
                dgResults.DataSource = Records;
                if (TableToSearch == Entity.Sys.Enums.TableNames.tblPart)
                {
                    if (Records is object)
                    {
                        if (Records.Table is object)
                        {
                            if (Records.Table.Rows.Count > 0)
                            {
                                if (Trans is object)
                                {
                                    StockDataview = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(Records.Table.Rows[0]["PartID"]), Trans);
                                }
                                else
                                {
                                    StockDataview = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(Records.Table.Rows[0]["PartID"]));
                                }

                                grpStock.Text = Conversions.ToString("Stock Locations for : '" + Records.Table.Rows[0]["Name"] + "'");
                            }
                        }
                    }
                }
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgResults.CurrentRowIndex == -1))
                {
                    return Records[dgResults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _StockDataview = null;

        public DataView StockDataview
        {
            get
            {
                return _StockDataview;
            }

            set
            {
                _StockDataview = value;
                if (_StockDataview is object)
                {
                    if (_StockDataview.Table is object)
                    {
                        _StockDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
                        _StockDataview.AllowNew = false;
                        _StockDataview.AllowEdit = true;
                        _StockDataview.AllowDelete = false;
                    }
                }

                dgStock.DataSource = StockDataview;
            }
        }

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private int _2ndID = 0;

        public int SecondID
        {
            get
            {
                return _2ndID;
            }

            set
            {
                _2ndID = value;
            }
        }

        private ArrayList _PartsToAdd = null;

        public ArrayList PartsToAdd
        {
            get
            {
                return _PartsToAdd;
            }

            set
            {
                _PartsToAdd = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupDG()
        {
            var tStyle = dgResults.TableStyles[0];
            tStyle.ReadOnly = true;
            var switchExpr = TableToSearch;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 300;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblLocations:
                    {
                        var LocationType = new DataGridLabelColumn();
                        LocationType.Format = "";
                        LocationType.FormatInfo = null;
                        LocationType.HeaderText = "Type";
                        LocationType.MappingName = "LocationType";
                        LocationType.ReadOnly = true;
                        LocationType.Width = 100;
                        LocationType.NullText = "";
                        tStyle.GridColumnStyles.Add(LocationType);
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 300;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblCustomer:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 170;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var AccountNumber = new DataGridLabelColumn();
                        AccountNumber.Format = "";
                        AccountNumber.FormatInfo = null;
                        AccountNumber.HeaderText = "Account Number";
                        AccountNumber.MappingName = "AccountNumber";
                        AccountNumber.ReadOnly = true;
                        AccountNumber.Width = 100;
                        AccountNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(AccountNumber);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 100;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var Type = new DataGridLabelColumn();
                        Type.Format = "";
                        Type.FormatInfo = null;
                        Type.HeaderText = "Type";
                        Type.MappingName = "Type";
                        Type.ReadOnly = true;
                        Type.Width = 140;
                        Type.NullText = "";
                        tStyle.GridColumnStyles.Add(Type);
                        var HO = new DataGridLabelColumn();
                        HO.Format = "";
                        HO.FormatInfo = null;
                        HO.HeaderText = "Head Office";
                        HO.MappingName = "ho";
                        HO.ReadOnly = true;
                        HO.Width = 250;
                        HO.NullText = "";
                        tStyle.GridColumnStyles.Add(HO);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblUser:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Full Name";
                        Name.MappingName = "FullName";
                        Name.ReadOnly = true;
                        Name.Width = 170;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address = new DataGridLabelColumn();
                        Address.Format = "";
                        Address.FormatInfo = null;
                        Address.HeaderText = "Email Address";
                        Address.MappingName = "EmailAddress";
                        Address.Width = 200;
                        Address.ReadOnly = true;
                        Address.NullText = "";
                        tStyle.GridColumnStyles.Add(Address);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSite:
                    {
                        var customeerName = new DataGridLabelColumn();
                        customeerName.Format = "";
                        customeerName.FormatInfo = null;
                        customeerName.HeaderText = "Customer";
                        customeerName.MappingName = "CustomerName";
                        customeerName.ReadOnly = true;
                        customeerName.Width = 100;
                        customeerName.NullText = "";
                        tStyle.GridColumnStyles.Add(customeerName);
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Town = new DataGridLabelColumn();
                        Town.Format = "";
                        Town.FormatInfo = null;
                        Town.HeaderText = "Address 2";
                        Town.MappingName = "Address2";
                        Town.ReadOnly = true;
                        Town.Width = 100;
                        Town.NullText = "";
                        tStyle.GridColumnStyles.Add(Town);
                        var County = new DataGridLabelColumn();
                        County.Format = "";
                        County.FormatInfo = null;
                        County.HeaderText = "Address 3";
                        County.MappingName = "Address3";
                        County.ReadOnly = true;
                        County.Width = 100;
                        County.NullText = "";
                        tStyle.GridColumnStyles.Add(County);
                        var Address4 = new DataGridLabelColumn();
                        Address4.Format = "";
                        Address4.FormatInfo = null;
                        Address4.HeaderText = "Address 4";
                        Address4.MappingName = "Address4";
                        Address4.ReadOnly = true;
                        Address4.Width = 100;
                        Address4.NullText = "";
                        tStyle.GridColumnStyles.Add(Address4);
                        var Address5 = new DataGridLabelColumn();
                        Address5.Format = "";
                        Address5.FormatInfo = null;
                        Address5.HeaderText = "Address 5";
                        Address5.MappingName = "Address5";
                        Address5.ReadOnly = true;
                        Address5.Width = 100;
                        Address5.NullText = "";
                        tStyle.GridColumnStyles.Add(Address5);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 100;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Tel";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 100;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblWarehouse:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Address2 = new DataGridLabelColumn();
                        Address2.Format = "";
                        Address2.FormatInfo = null;
                        Address2.HeaderText = "Address 2";
                        Address2.MappingName = "Address2";
                        Address2.ReadOnly = true;
                        Address2.Width = 100;
                        Address2.NullText = "";
                        tStyle.GridColumnStyles.Add(Address2);
                        var Address3 = new DataGridLabelColumn();
                        Address3.Format = "";
                        Address3.FormatInfo = null;
                        Address3.HeaderText = "Address 3";
                        Address3.MappingName = "Address3";
                        Address3.ReadOnly = true;
                        Address3.Width = 100;
                        Address3.NullText = "";
                        tStyle.GridColumnStyles.Add(Address3);
                        var Address4 = new DataGridLabelColumn();
                        Address4.Format = "";
                        Address4.FormatInfo = null;
                        Address4.HeaderText = "Address 4";
                        Address4.MappingName = "Address4";
                        Address4.ReadOnly = true;
                        Address4.Width = 100;
                        Address4.NullText = "";
                        tStyle.GridColumnStyles.Add(Address4);
                        var Address5 = new DataGridLabelColumn();
                        Address5.Format = "";
                        Address5.FormatInfo = null;
                        Address5.HeaderText = "Address 5";
                        Address5.MappingName = "Address5";
                        Address5.ReadOnly = true;
                        Address5.Width = 100;
                        Address5.NullText = "";
                        tStyle.GridColumnStyles.Add(Address5);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 100;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Tel";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 100;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblVan:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Engineer Name";
                        Name.MappingName = "EngineerName";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Registration = new DataGridLabelColumn();
                        Registration.Format = "";
                        Registration.FormatInfo = null;
                        Registration.HeaderText = "Stock Profile Name";
                        Registration.MappingName = "Registration";
                        Registration.ReadOnly = true;
                        Registration.Width = 150;
                        Registration.NullText = "";
                        tStyle.GridColumnStyles.Add(Registration);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblPart:
                    {
                        if (ForMassPartEntry)
                        {
                            tStyle.ReadOnly = false;
                            dgResults.ReadOnly = false;
                            var QuantityToAdd = new DataGridEditableTextBoxColumn();
                            QuantityToAdd.BackColourBrush = Brushes.LightYellow;
                            QuantityToAdd.Format = "";
                            QuantityToAdd.FormatInfo = null;
                            QuantityToAdd.HeaderText = "Add";
                            QuantityToAdd.MappingName = "QuantityToAdd";
                            QuantityToAdd.ReadOnly = false;
                            QuantityToAdd.Width = 130;
                            QuantityToAdd.NullText = "";
                            tStyle.GridColumnStyles.Add(QuantityToAdd);
                        }

                        var PartName = new DataGridLabelColumn();
                        PartName.Format = "";
                        PartName.FormatInfo = null;
                        PartName.HeaderText = "Name";
                        PartName.MappingName = "Name";
                        PartName.ReadOnly = true;
                        PartName.Width = 130;
                        PartName.NullText = "";
                        tStyle.GridColumnStyles.Add(PartName);
                        var PartNumber = new DataGridLabelColumn();
                        PartNumber.Format = "";
                        PartNumber.FormatInfo = null;
                        PartNumber.HeaderText = "Number (MPN)";
                        PartNumber.MappingName = "Number";
                        PartNumber.ReadOnly = true;
                        PartNumber.Width = 130;
                        PartNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(PartNumber);
                        var PartReference = new DataGridLabelColumn();
                        PartReference.Format = "";
                        PartReference.FormatInfo = null;
                        PartReference.HeaderText = "Reference";
                        PartReference.MappingName = "Reference";
                        PartReference.ReadOnly = true;
                        PartReference.Width = 200;
                        PartReference.NullText = "";
                        tStyle.GridColumnStyles.Add(PartReference);
                        var Quantity = new DataGridLabelColumn();
                        Quantity.Format = "";
                        Quantity.FormatInfo = null;
                        Quantity.HeaderText = "Qty";
                        Quantity.MappingName = "WarehouseQuantity";
                        Quantity.ReadOnly = true;
                        Quantity.Width = 50;
                        Quantity.NullText = "";
                        tStyle.GridColumnStyles.Add(Quantity);
                        var UnitType = new DataGridLabelColumn();
                        UnitType.Format = "";
                        UnitType.FormatInfo = null;
                        UnitType.HeaderText = "Unit Type";
                        UnitType.MappingName = "UnitType";
                        UnitType.ReadOnly = true;
                        UnitType.Width = 130;
                        UnitType.NullText = "";
                        tStyle.GridColumnStyles.Add(UnitType);
                        var SellPrice = new DataGridLabelColumn();
                        SellPrice.Format = "C";
                        SellPrice.FormatInfo = null;
                        SellPrice.HeaderText = "Sell Price";
                        SellPrice.MappingName = "SellPrice";
                        SellPrice.ReadOnly = true;
                        SellPrice.Width = 120;
                        SellPrice.NullText = "";
                        tStyle.GridColumnStyles.Add(SellPrice);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProduct:
                    {
                        var ProductName = new DataGridLabelColumn();
                        ProductName.Format = "";
                        ProductName.FormatInfo = null;
                        ProductName.HeaderText = "Description";
                        ProductName.MappingName = "typemakemodel";
                        ProductName.ReadOnly = true;
                        ProductName.Width = 200;
                        ProductName.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductName);
                        var ProductNumber = new DataGridLabelColumn();
                        ProductNumber.Format = "";
                        ProductNumber.FormatInfo = null;
                        ProductNumber.HeaderText = "GC Number";
                        ProductNumber.MappingName = "Number";
                        ProductNumber.ReadOnly = true;
                        ProductNumber.Width = 120;
                        ProductNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductNumber);
                        var ProductReference = new DataGridLabelColumn();
                        ProductReference.Format = "";
                        ProductReference.FormatInfo = null;
                        ProductReference.HeaderText = "Product Reference";
                        ProductReference.MappingName = "Reference";
                        ProductReference.ReadOnly = true;
                        ProductReference.Width = 200;
                        ProductReference.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductReference);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblInvoiceAddress:
                    {
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Address2 = new DataGridLabelColumn();
                        Address2.Format = "";
                        Address2.FormatInfo = null;
                        Address2.HeaderText = "Address 2";
                        Address2.MappingName = "Address2";
                        Address2.ReadOnly = true;
                        Address2.Width = 100;
                        Address2.NullText = "";
                        tStyle.GridColumnStyles.Add(Address2);
                        var Address3 = new DataGridLabelColumn();
                        Address3.Format = "";
                        Address3.FormatInfo = null;
                        Address3.HeaderText = "Address 3";
                        Address3.MappingName = "Address3";
                        Address3.ReadOnly = true;
                        Address3.Width = 100;
                        Address3.NullText = "";
                        tStyle.GridColumnStyles.Add(Address3);
                        var Address4 = new DataGridLabelColumn();
                        Address4.Format = "";
                        Address4.FormatInfo = null;
                        Address4.HeaderText = "Address 4";
                        Address4.MappingName = "Address4";
                        Address4.ReadOnly = true;
                        Address4.Width = 100;
                        Address4.NullText = "";
                        tStyle.GridColumnStyles.Add(Address4);
                        var Address5 = new DataGridLabelColumn();
                        Address5.Format = "";
                        Address5.FormatInfo = null;
                        Address5.HeaderText = "Address5";
                        Address5.MappingName = "Address5";
                        Address5.ReadOnly = true;
                        Address5.Width = 100;
                        Address5.NullText = "";
                        tStyle.GridColumnStyles.Add(Address5);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 75;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblContact:
                    {
                        var FirstName = new DataGridLabelColumn();
                        FirstName.Format = "";
                        FirstName.FormatInfo = null;
                        FirstName.HeaderText = "First Name";
                        FirstName.MappingName = "FirstName";
                        FirstName.ReadOnly = true;
                        FirstName.Width = 160;
                        FirstName.NullText = "";
                        tStyle.GridColumnStyles.Add(FirstName);
                        var Surname = new DataGridLabelColumn();
                        Surname.Format = "";
                        Surname.FormatInfo = null;
                        Surname.HeaderText = "Surname";
                        Surname.MappingName = "Surname";
                        Surname.ReadOnly = true;
                        Surname.Width = 160;
                        Surname.NullText = "";
                        tStyle.GridColumnStyles.Add(Surname);
                        var Email = new DataGridLabelColumn();
                        Email.Format = "";
                        Email.FormatInfo = null;
                        Email.HeaderText = "Email";
                        Email.MappingName = "EmailAddress";
                        Email.ReadOnly = true;
                        Email.Width = 120;
                        Email.NullText = "";
                        tStyle.GridColumnStyles.Add(Email);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Telephone Number";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 100;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblPartSupplier:
                    {
                        var Supplier = new DataGridLabelColumn();
                        Supplier.Format = "";
                        Supplier.FormatInfo = null;
                        Supplier.HeaderText = "Supplier";
                        Supplier.MappingName = "Supplier";
                        Supplier.ReadOnly = true;
                        Supplier.Width = 130;
                        Supplier.NullText = "";
                        tStyle.GridColumnStyles.Add(Supplier);
                        var PartName = new DataGridLabelColumn();
                        PartName.Format = "";
                        PartName.FormatInfo = null;
                        PartName.HeaderText = "Name";
                        PartName.MappingName = "Name";
                        PartName.ReadOnly = true;
                        PartName.Width = 130;
                        PartName.NullText = "";
                        tStyle.GridColumnStyles.Add(PartName);
                        var PartNumber = new DataGridLabelColumn();
                        PartNumber.Format = "";
                        PartNumber.FormatInfo = null;
                        PartNumber.HeaderText = "Part Number (MPN)";
                        PartNumber.MappingName = "Number";
                        PartNumber.ReadOnly = true;
                        PartNumber.Width = 130;
                        PartNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(PartNumber);
                        var QuantityInPack = new DataGridLabelColumn();
                        QuantityInPack.Format = "";
                        QuantityInPack.FormatInfo = null;
                        QuantityInPack.HeaderText = "Quantity In Pack";
                        QuantityInPack.MappingName = "QuantityInPack";
                        QuantityInPack.ReadOnly = true;
                        QuantityInPack.Width = 130;
                        QuantityInPack.NullText = "";
                        tStyle.GridColumnStyles.Add(QuantityInPack);
                        var PartCode = new DataGridLabelColumn();
                        PartCode.Format = "";
                        PartCode.FormatInfo = null;
                        PartCode.HeaderText = "Supplier Part Number (SPN)";
                        PartCode.MappingName = "PartCode";
                        PartCode.ReadOnly = true;
                        PartCode.Width = 130;
                        PartCode.NullText = "";
                        tStyle.GridColumnStyles.Add(PartCode);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 130;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProductSupplier:
                    {
                        var Supplier = new DataGridLabelColumn();
                        Supplier.Format = "";
                        Supplier.FormatInfo = null;
                        Supplier.HeaderText = "Supplier";
                        Supplier.MappingName = "Supplier";
                        Supplier.ReadOnly = true;
                        Supplier.Width = 130;
                        Supplier.NullText = "";
                        tStyle.GridColumnStyles.Add(Supplier);
                        var ProductName = new DataGridLabelColumn();
                        ProductName.Format = "";
                        ProductName.FormatInfo = null;
                        ProductName.HeaderText = "Name";
                        ProductName.MappingName = "Name";
                        ProductName.ReadOnly = true;
                        ProductName.Width = 130;
                        ProductName.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductName);
                        var ProductNumber = new DataGridLabelColumn();
                        ProductNumber.Format = "";
                        ProductNumber.FormatInfo = null;
                        ProductNumber.HeaderText = "Product Number";
                        ProductNumber.MappingName = "Number";
                        ProductNumber.ReadOnly = true;
                        ProductNumber.Width = 130;
                        ProductNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductNumber);
                        var QuantityInPack = new DataGridLabelColumn();
                        QuantityInPack.Format = "";
                        QuantityInPack.FormatInfo = null;
                        QuantityInPack.HeaderText = "Quantity In Pack";
                        QuantityInPack.MappingName = "QuantityInPack";
                        QuantityInPack.ReadOnly = true;
                        QuantityInPack.Width = 130;
                        QuantityInPack.NullText = "";
                        tStyle.GridColumnStyles.Add(QuantityInPack);
                        var ProductCode = new DataGridLabelColumn();
                        ProductCode.Format = "";
                        ProductCode.FormatInfo = null;
                        ProductCode.HeaderText = "Supplier Product Number";
                        ProductCode.MappingName = "ProductCode";
                        ProductCode.ReadOnly = true;
                        ProductCode.Width = 130;
                        ProductCode.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductCode);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 130;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSupplier:
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
                    {
                        if (TableToSearch == Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart)
                        {
                            if (ForeignKeyFilter > 0)
                            {
                                var Preferred = new ColourColumn();
                                Preferred.Format = "";
                                Preferred.FormatInfo = null;
                                Preferred.HeaderText = "Preferred";
                                Preferred.MappingName = "Preferred";
                                Preferred.ReadOnly = true;
                                Preferred.Width = 25;
                                Preferred.NullText = "";
                                tStyle.GridColumnStyles.Add(Preferred);
                            }
                        }

                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 130;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 130;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 130;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        var Address2 = new DataGridLabelColumn();
                        Address2.Format = "";
                        Address2.FormatInfo = null;
                        Address2.HeaderText = "Address2";
                        Address2.MappingName = "Address2";
                        Address2.ReadOnly = true;
                        Address2.Width = 130;
                        Address2.NullText = "";
                        tStyle.GridColumnStyles.Add(Address2);
                        var Address3 = new DataGridLabelColumn();
                        Address3.Format = "";
                        Address3.FormatInfo = null;
                        Address3.HeaderText = "Address3";
                        Address3.MappingName = "Address3";
                        Address3.ReadOnly = true;
                        Address3.Width = 130;
                        Address3.NullText = "";
                        tStyle.GridColumnStyles.Add(Address3);
                        var Address4 = new DataGridLabelColumn();
                        Address4.Format = "";
                        Address4.FormatInfo = null;
                        Address4.HeaderText = "Address4";
                        Address4.MappingName = "Address4";
                        Address4.ReadOnly = true;
                        Address4.Width = 130;
                        Address4.NullText = "";
                        tStyle.GridColumnStyles.Add(Address4);
                        var Address5 = new DataGridLabelColumn();
                        Address5.Format = "";
                        Address5.FormatInfo = null;
                        Address5.HeaderText = "Address5";
                        Address5.MappingName = "Address5";
                        Address5.ReadOnly = true;
                        Address5.Width = 130;
                        Address5.NullText = "";
                        tStyle.GridColumnStyles.Add(Address5);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 130;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Telephone";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 130;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart:
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
                    {
                        var EngName = new DataGridLabelColumn();
                        EngName.Format = "";
                        EngName.FormatInfo = null;
                        EngName.HeaderText = "Engineer Name";
                        EngName.MappingName = "EngineerName";
                        EngName.ReadOnly = true;
                        EngName.Width = 100;
                        EngName.NullText = "";
                        tStyle.GridColumnStyles.Add(EngName);
                        var Registration = new DataGridLabelColumn();
                        Registration.Format = "";
                        Registration.FormatInfo = null;
                        Registration.HeaderText = "Registration";
                        Registration.MappingName = "Registration";
                        Registration.ReadOnly = true;
                        Registration.Width = 100;
                        Registration.NullText = "";
                        tStyle.GridColumnStyles.Add(Registration);
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Item Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Number = new DataGridLabelColumn();
                        Number.Format = "";
                        Number.FormatInfo = null;
                        Number.HeaderText = "Item Number";
                        Number.MappingName = "Number";
                        Number.ReadOnly = true;
                        Number.Width = 100;
                        Number.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Amount = new DataGridLabelColumn();
                        Amount.Format = "";
                        Amount.FormatInfo = null;
                        Amount.HeaderText = "Amount";
                        Amount.MappingName = "Amount";
                        Amount.ReadOnly = true;
                        Amount.Width = 100;
                        Amount.NullText = "";
                        tStyle.GridColumnStyles.Add(Amount);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "warehouseName";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 100;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Tel";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 100;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        var Amount = new DataGridLabelColumn();
                        Amount.Format = "";
                        Amount.FormatInfo = null;
                        Amount.HeaderText = "Amount";
                        Amount.MappingName = "Amount";
                        Amount.ReadOnly = true;
                        Amount.Width = 100;
                        Amount.NullText = "";
                        tStyle.GridColumnStyles.Add(Amount);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblJob:
                    {
                        var JobNumber = new DataGridLabelColumn();
                        JobNumber.Format = "";
                        JobNumber.FormatInfo = null;
                        JobNumber.HeaderText = "Job Number";
                        JobNumber.MappingName = "JobNumber";
                        JobNumber.ReadOnly = true;
                        JobNumber.Width = 100;
                        JobNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(JobNumber);

                        // Dim PONumber As New DataGridLabelColumn
                        // PONumber.Format = ""
                        // PONumber.FormatInfo = Nothing
                        // PONumber.HeaderText = "PO Number"
                        // PONumber.MappingName = "PONumber"
                        // PONumber.ReadOnly = True
                        // PONumber.Width = 100
                        // PONumber.NullText = ""
                        // tStyle.GridColumnStyles.Add(PONumber)

                        var DateCreated = new DataGridLabelColumn();
                        DateCreated.Format = "dd/MMM/yyyy";
                        DateCreated.FormatInfo = null;
                        DateCreated.HeaderText = "Date Created";
                        DateCreated.MappingName = "DateCreated";
                        DateCreated.ReadOnly = true;
                        DateCreated.Width = 100;
                        DateCreated.NullText = "";
                        tStyle.GridColumnStyles.Add(DateCreated);
                        var Definition = new DataGridLabelColumn();
                        Definition.Format = "";
                        Definition.FormatInfo = null;
                        Definition.HeaderText = "Definition";
                        Definition.MappingName = "JobDefinition";
                        Definition.ReadOnly = true;
                        Definition.Width = 100;
                        Definition.NullText = "";
                        tStyle.GridColumnStyles.Add(Definition);
                        var Type = new DataGridLabelColumn();
                        Type.Format = "";
                        Type.FormatInfo = null;
                        Type.HeaderText = "Type";
                        Type.MappingName = "Type";
                        Type.ReadOnly = true;
                        Type.Width = 100;
                        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
                        tStyle.GridColumnStyles.Add(Type);
                        var JobStatus = new DataGridLabelColumn();
                        JobStatus.Format = "";
                        JobStatus.FormatInfo = null;
                        JobStatus.HeaderText = "Status";
                        JobStatus.MappingName = "JobStatus";
                        JobStatus.ReadOnly = true;
                        JobStatus.Width = 100;
                        JobStatus.NullText = "";
                        tStyle.GridColumnStyles.Add(JobStatus);
                        var CreatedBy = new DataGridLabelColumn();
                        CreatedBy.Format = "";
                        CreatedBy.FormatInfo = null;
                        CreatedBy.HeaderText = "Created By";
                        CreatedBy.MappingName = "CreatedBy";
                        CreatedBy.ReadOnly = true;
                        CreatedBy.Width = 100;
                        CreatedBy.NullText = "";
                        tStyle.GridColumnStyles.Add(CreatedBy);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
                    {
                        var LocationType = new DataGridLabelColumn();
                        LocationType.Format = "";
                        LocationType.FormatInfo = null;
                        LocationType.HeaderText = "Location Type";
                        LocationType.MappingName = "LocationType";
                        LocationType.ReadOnly = true;
                        LocationType.Width = 100;
                        LocationType.NullText = "";
                        tStyle.GridColumnStyles.Add(LocationType);
                        var Location = new DataGridLabelColumn();
                        Location.Format = "";
                        Location.FormatInfo = null;
                        Location.HeaderText = "Location";
                        Location.MappingName = "Name";
                        Location.ReadOnly = true;
                        Location.Width = 100;
                        Location.NullText = "";
                        tStyle.GridColumnStyles.Add(Location);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblEngineer:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 200;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Telephone Number";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 200;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 200;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblOrder:
                    {
                        var DateCreated = new DataGridLabelColumn();
                        DateCreated.Format = "dd/MMM/yyyy";
                        DateCreated.FormatInfo = null;
                        DateCreated.HeaderText = "Date Placed";
                        DateCreated.MappingName = "DatePlaced";
                        DateCreated.ReadOnly = true;
                        DateCreated.Width = 90;
                        DateCreated.NullText = "";
                        tStyle.GridColumnStyles.Add(DateCreated);
                        var DeliveryDeadline = new DataGridLabelColumn();
                        DeliveryDeadline.Format = "dd/MMM/yyyy";
                        DeliveryDeadline.FormatInfo = null;
                        DeliveryDeadline.HeaderText = "Delivery Deadline";
                        DeliveryDeadline.MappingName = "DeliveryDeadline";
                        DeliveryDeadline.ReadOnly = true;
                        DeliveryDeadline.Width = 90;
                        DeliveryDeadline.NullText = "";
                        tStyle.GridColumnStyles.Add(DeliveryDeadline);
                        var OrderReference = new DataGridLabelColumn();
                        OrderReference.Format = "";
                        OrderReference.FormatInfo = null;
                        OrderReference.HeaderText = "Order Reference";
                        OrderReference.MappingName = "OrderReference";
                        OrderReference.ReadOnly = true;
                        OrderReference.Width = 110;
                        OrderReference.NullText = "";
                        tStyle.GridColumnStyles.Add(OrderReference);
                        var ConsolidationRef = new DataGridLabelColumn();
                        ConsolidationRef.Format = "";
                        ConsolidationRef.FormatInfo = null;
                        ConsolidationRef.HeaderText = "Consol Ref";
                        ConsolidationRef.MappingName = "ConsolidationRef";
                        ConsolidationRef.ReadOnly = true;
                        ConsolidationRef.Width = 110;
                        ConsolidationRef.NullText = "";
                        tStyle.GridColumnStyles.Add(ConsolidationRef);
                        var Type = new DataGridLabelColumn();
                        Type.Format = "";
                        Type.FormatInfo = null;
                        Type.HeaderText = "Type";
                        Type.MappingName = "Type";
                        Type.ReadOnly = true;
                        Type.Width = 75;
                        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
                        tStyle.GridColumnStyles.Add(Type);
                        var Customer = new DataGridLabelColumn();
                        Customer.Format = "";
                        Customer.FormatInfo = null;
                        Customer.HeaderText = "Customer";
                        Customer.MappingName = "Customer";
                        Customer.ReadOnly = true;
                        Customer.Width = 140;
                        Customer.NullText = "N/A";
                        tStyle.GridColumnStyles.Add(Customer);
                        var Site = new DataGridLabelColumn();
                        Site.Format = "";
                        Site.FormatInfo = null;
                        Site.HeaderText = "Property";
                        Site.MappingName = "Site";
                        Site.ReadOnly = true;
                        Site.Width = 140;
                        Site.NullText = "N/A";
                        tStyle.GridColumnStyles.Add(Site);
                        var Supplier = new DataGridLabelColumn();
                        Supplier.Format = "";
                        Supplier.FormatInfo = null;
                        Supplier.HeaderText = "Supplier";
                        Supplier.MappingName = "Supplier";
                        Supplier.ReadOnly = true;
                        Supplier.Width = 100;
                        Supplier.NullText = "N/A";
                        tStyle.GridColumnStyles.Add(Supplier);
                        var JobNumber = new DataGridLabelColumn();
                        JobNumber.Format = "";
                        JobNumber.FormatInfo = null;
                        JobNumber.HeaderText = "Job Number";
                        JobNumber.MappingName = "JobNumber";
                        JobNumber.ReadOnly = true;
                        JobNumber.Width = 100;
                        JobNumber.NullText = "N/A";
                        tStyle.GridColumnStyles.Add(JobNumber);
                        var OrderStatus = new DataGridLabelColumn();
                        OrderStatus.Format = "";
                        OrderStatus.FormatInfo = null;
                        OrderStatus.HeaderText = "Status";
                        OrderStatus.MappingName = "DisplayStatus";
                        OrderStatus.ReadOnly = true;
                        OrderStatus.Width = 120;
                        OrderStatus.NullText = "";
                        tStyle.GridColumnStyles.Add(OrderStatus);
                        var SupplierExported = new DataGridLabelColumn();
                        SupplierExported.Format = "";
                        SupplierExported.FormatInfo = null;
                        SupplierExported.HeaderText = "Sup Inv Sent to Sage";
                        SupplierExported.MappingName = "SupplierExported";
                        SupplierExported.ReadOnly = true;
                        SupplierExported.Width = 50;
                        SupplierExported.NullText = "";
                        tStyle.GridColumnStyles.Add(SupplierExported);
                        var BuyPrice = new DataGridLabelColumn();
                        BuyPrice.Format = "C";
                        BuyPrice.FormatInfo = null;
                        BuyPrice.HeaderText = "Buy Price";
                        BuyPrice.MappingName = "BuyPrice";
                        BuyPrice.ReadOnly = true;
                        BuyPrice.Width = 75;
                        BuyPrice.NullText = "0";
                        tStyle.GridColumnStyles.Add(BuyPrice);
                        var SellPrice = new DataGridLabelColumn();
                        SellPrice.Format = "C";
                        SellPrice.FormatInfo = null;
                        SellPrice.HeaderText = "Sell Price";
                        SellPrice.MappingName = "SellPrice";
                        SellPrice.ReadOnly = true;
                        SellPrice.Width = 75;
                        SellPrice.NullText = "£0.00";
                        tStyle.GridColumnStyles.Add(SellPrice);
                        var CreatedBy = new DataGridLabelColumn();
                        CreatedBy.Format = "";
                        CreatedBy.FormatInfo = null;
                        CreatedBy.HeaderText = "Created By";
                        CreatedBy.MappingName = "CreatedBy";
                        CreatedBy.ReadOnly = true;
                        CreatedBy.Width = 100;
                        CreatedBy.NullText = "";
                        tStyle.GridColumnStyles.Add(CreatedBy);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblFleetVan:
                    {
                        var registration = new DataGridLabelColumn();
                        registration.Format = "";
                        registration.FormatInfo = null;
                        registration.HeaderText = "Registration";
                        registration.MappingName = "Registration";
                        registration.ReadOnly = true;
                        registration.Width = 150;
                        registration.NullText = "";
                        tStyle.GridColumnStyles.Add(registration);
                        var make = new DataGridLabelColumn();
                        make.Format = "";
                        make.FormatInfo = null;
                        make.HeaderText = "Engineer";
                        make.MappingName = "Name";
                        make.ReadOnly = true;
                        make.Width = 350;
                        make.NullText = "";
                        tStyle.GridColumnStyles.Add(make);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblFleetVanFault:
                    {
                        var registration = new DataGridLabelColumn();
                        registration.Format = "";
                        registration.FormatInfo = null;
                        registration.HeaderText = "Registration";
                        registration.MappingName = "Registration";
                        registration.ReadOnly = true;
                        registration.Width = 150;
                        registration.NullText = "";
                        tStyle.GridColumnStyles.Add(registration);
                        var fault = new DataGridLabelColumn();
                        fault.Format = "";
                        fault.FormatInfo = null;
                        fault.HeaderText = "Fault";
                        fault.MappingName = "Name";
                        fault.ReadOnly = true;
                        fault.Width = 150;
                        fault.NullText = "";
                        tStyle.GridColumnStyles.Add(fault);
                        var faultDate = new DataGridLabelColumn();
                        faultDate.Format = "";
                        faultDate.FormatInfo = null;
                        faultDate.HeaderText = "Fault Date";
                        faultDate.MappingName = "FaultDate";
                        faultDate.ReadOnly = true;
                        faultDate.Width = 250;
                        faultDate.NullText = "";
                        tStyle.GridColumnStyles.Add(faultDate);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate:
                    {
                        var Category = new DataGridLabelColumn();
                        Category.Format = "";
                        Category.FormatInfo = null;
                        Category.HeaderText = "Category";
                        Category.MappingName = "Category";
                        Category.ReadOnly = true;
                        Category.Width = 100;
                        Category.NullText = "";
                        tStyle.GridColumnStyles.Add(Category);
                        var Code = new DataGridLabelColumn();
                        Code.Format = "";
                        Code.FormatInfo = null;
                        Code.HeaderText = "Code";
                        Code.MappingName = "Code";
                        Code.ReadOnly = true;
                        Code.Width = 100;
                        Code.NullText = "";
                        tStyle.GridColumnStyles.Add(Code);
                        var Description = new DataGridLabelColumn();
                        Description.Format = "";
                        Description.FormatInfo = null;
                        Description.HeaderText = "Description";
                        Description.MappingName = "Description";
                        Description.ReadOnly = true;
                        Description.Width = 250;
                        Description.NullText = "";
                        tStyle.GridColumnStyles.Add(Description);
                        var TimeInMins = new DataGridLabelColumn();
                        TimeInMins.Format = "";
                        TimeInMins.FormatInfo = null;
                        TimeInMins.HeaderText = "Time (Mins)";
                        TimeInMins.MappingName = "TimeInMins";
                        TimeInMins.ReadOnly = true;
                        TimeInMins.Width = 80;
                        TimeInMins.NullText = "";
                        tStyle.GridColumnStyles.Add(TimeInMins);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "C";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Unit Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 80;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblEngineerSkills:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 300;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Description = new DataGridLabelColumn();
                        Description.Format = "";
                        Description.FormatInfo = null;
                        Description.HeaderText = "Description";
                        Description.MappingName = "Description";
                        Description.ReadOnly = true;
                        Description.Width = 250;
                        Description.NullText = "";
                        tStyle.GridColumnStyles.Add(Description);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblEngineerRole:
                    {
                        var name = new DataGridLabelColumn();
                        name.Format = "";
                        name.FormatInfo = null;
                        name.HeaderText = "Name";
                        name.MappingName = "Name";
                        name.ReadOnly = true;
                        name.Width = 300;
                        name.NullText = "";
                        tStyle.GridColumnStyles.Add(name);
                        var department = new DataGridLabelColumn();
                        department.Format = "";
                        department.FormatInfo = null;
                        department.HeaderText = "Department";
                        department.MappingName = "Department";
                        department.ReadOnly = true;
                        department.Width = 250;
                        department.NullText = "";
                        tStyle.GridColumnStyles.Add(department);
                        break;
                    }
            }

            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
            dgResults.TableStyles.Add(tStyle);
        }

        public void SetupStockDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgStock);
            var tStyle = dgStock.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 100;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 200;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var Shelf = new DataGridLabelColumn();
            Shelf.Format = "";
            Shelf.FormatInfo = null;
            Shelf.HeaderText = "Shelf";
            Shelf.MappingName = "Shelf";
            Shelf.ReadOnly = true;
            Shelf.Width = 100;
            Shelf.NullText = "";
            tStyle.GridColumnStyles.Add(Shelf);
            var Bin = new DataGridLabelColumn();
            Bin.Format = "";
            Bin.FormatInfo = null;
            Bin.HeaderText = "Bin";
            Bin.MappingName = "Bin";
            Bin.ReadOnly = true;
            Bin.Width = 100;
            Bin.NullText = "";
            tStyle.GridColumnStyles.Add(Bin);
            var Qty = new DataGridLabelColumn();
            Qty.Format = "";
            Qty.FormatInfo = null;
            Qty.HeaderText = "Qty";
            Qty.MappingName = "Quantity";
            Qty.ReadOnly = true;
            Qty.Width = 100;
            Qty.NullText = "";
            tStyle.GridColumnStyles.Add(Qty);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dgStock.TableStyles.Add(tStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void DLGFindRecord_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgResults_Select(object sender, EventArgs e)
        {
            if (!(TableToSearch == Entity.Sys.Enums.TableNames.tblPart))
            {
                return;
            }

            if (SelectedDataRow is null)
            {
                StockDataview = null;
                grpStock.Text = "Stock Locations for : 'No Part Selected'";
            }
            else
            {
                if (Trans is object)
                {
                    StockDataview = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(SelectedDataRow["PartID"]), Trans);
                }
                else
                {
                    StockDataview = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(SelectedDataRow["PartID"]));
                }

                grpStock.Text = Conversions.ToString("Stock Locations for : '" + SelectedDataRow["Name"] + "'");
            }
        }

        private void dgResults_DoubleClick(object sender, EventArgs e)
        {
            if (TableToSearch == Entity.Sys.Enums.TableNames.tblPart)
            {
                if (SelectedDataRow is null)
                {
                    return;
                }

                App.ShowForm(typeof(FRMPart), true, new object[] { SelectedDataRow["PartID"], true });
                Records = App.DB.Part.Part_GetAll();
                RunFilter();
            }
            else
            {
                SelectItem();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var switchExpr = TableToSearch;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.tblPart:
                    {
                        App.ShowForm(typeof(FRMPart), true, new object[] { 0, true });
                        TableToSearch = Entity.Sys.Enums.TableNames.tblPart;
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProduct:
                    {
                        App.ShowForm(typeof(FRMProduct), true, new object[] { 0, true });
                        TableToSearch = Entity.Sys.Enums.TableNames.tblProduct;
                        break;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SelectItem()
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("No record selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var switchExpr = TableToSearch;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["ManagerID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblLocations:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblCustomer:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["CustomerID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblUser:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["UserID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSite:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["SiteID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblWarehouse:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["WarehouseID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblVan:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["VanID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProduct:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["ProductID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblPart:
                    {
                        if (ForMassPartEntry)
                        {
                            PartsToAdd = new ArrayList();
                            foreach (DataRow row in Records.Table.Rows)
                            {
                                if (Conversions.ToBoolean((int)row["QuantityToAdd"] > 0))
                                {
                                    var newPart = new ArrayList();
                                    newPart.Add(row["PartID"]);
                                    newPart.Add(row["QuantityToAdd"]);
                                    PartsToAdd.Add(newPart);
                                }
                            }
                        }
                        else
                        {
                            ID = Conversions.ToInteger(SelectedDataRow["PartID"]);
                        }

                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblInvoiceAddress:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["InvoiceAddressID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblContact:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["ContactID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblPartSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["PartSupplierID"]);
                        SecondID = Conversions.ToInteger(SelectedDataRow["PartID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProductSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["ProductSupplierID"]);
                        SecondID = Conversions.ToInteger(SelectedDataRow["ProductID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["SupplierID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["SupplierID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["SupplierID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblJob:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["JobID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["LocationID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblEngineer:
                case Entity.Sys.Enums.TableNames.tblEngineerRole:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["EngineerID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblOrder:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["OrderID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblFleetVan:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["VanID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblFleetVanFault:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["VanFaultID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["SystemScheduleOfRateID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblEngineerSkills:
                    {
                        ID = Conversions.ToInteger(SelectedDataRow["ManagerID"]);
                        break;
                    }
            }

            DialogResult = DialogResult.OK;
        }

        private void RunFilter()
        {
            string whereClause = "Deleted = 0";
            if (!(txtFilter.Text.Trim().Length == 0))
            {
                var switchExpr = TableToSearch;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.TableNames.tblJob:
                        {
                            whereClause += " AND JobNumber LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblUser:
                        {
                            whereClause += " AND FullName LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblContact:
                        {
                            whereClause += " AND (Firstname LIKE '%" + txtFilter.Text.Trim() + "%') OR (Surname LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSite:
                        {
                            whereClause += " AND (Name LIKE '%" + txtFilter.Text.Trim() + "%' OR Address1 LIKE '%" + txtFilter.Text.Trim() + "%' OR Address2 LIKE '%" + txtFilter.Text.Trim() + "%' OR PostCode LIKE '%" + txtFilter.Text.Trim() + "%' OR PolicyNumber LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblProduct:
                        {
                            whereClause += " AND typemakemodel LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'OR Number LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPart:
                        {
                            whereClause += " AND Name LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'OR Number LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPartSupplier:
                        {
                            whereClause += " AND PartCode LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblOrder:
                        {
                            whereClause += " AND OrderReference LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblVan:
                    case Entity.Sys.Enums.TableNames.tblFleetVan:
                        {
                            whereClause += " AND Registration LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblFleetVanFault:
                        {
                            whereClause = "Registration LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate:
                        {
                            whereClause += "AND (Description LIKE '%" + txtFilter.Text.Trim() + "%' OR Code LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblEngineerSkills:
                        {
                            whereClause += "AND (Description LIKE '%" + txtFilter.Text.Trim() + "%' OR Name LIKE '%" + txtFilter.Text.Trim() + "%') AND EnumTypeID = 7";
                            break;
                        }

                    default:
                        {
                            whereClause += " AND Name LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }
                }
            }

            if (cbOffice.Checked)
            {
                whereClause = whereClause + " AND Accommodation = 'Office'";
            }

            if (Entity.Sys.Helper.MakeIntegerValid(ForeignKeyFilter) == 1 && TableToSearch == Entity.Sys.Enums.TableNames.tblSupplier)
            {
                Records.RowFilter = "MasterSupplierID = 0 AND " + whereClause;
            }
            else
            {
                Records.RowFilter = whereClause;
            }

            StockDataview = null;
            grpStock.Text = "Stock Locations for : 'No Part Selected'";
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public class ColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                brush = Brushes.White;
                var dr = (DataRowView)source.List[rowNum];
                if (Entity.Sys.Helper.MakeBooleanValid(dr["Preferred"]))
                {
                    brush = Brushes.LightGreen;
                }

                TextBox.Text = "";
                // color the row cell
                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cbOffice_CheckedChanged(object sender, EventArgs e)
        {
            RunFilter();
        }
    }
}