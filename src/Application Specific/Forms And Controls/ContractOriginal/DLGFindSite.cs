using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGFindSite : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DLGFindSite() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        public DLGFindSite(System.Data.SqlClient.SqlTransaction trans) : base()
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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private ComboBox _cboPayer;

        internal ComboBox cboPayer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPayer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPayer != null)
                {
                    _cboPayer.SelectedIndexChanged -= cboPayer_SelectedIndexChanged;
                }

                _cboPayer = value;
                if (_cboPayer != null)
                {
                    _cboPayer.SelectedIndexChanged += cboPayer_SelectedIndexChanged;
                }
            }
        }

        private Panel _grpDD;

        internal Panel grpDD
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDD;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDD != null)
                {
                }

                _grpDD = value;
                if (_grpDD != null)
                {
                }
            }
        }

        private TextBox _txtAccName;

        internal TextBox txtAccName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccName != null)
                {
                }

                _txtAccName = value;
                if (_txtAccName != null)
                {
                }
            }
        }

        private Label _lbl3;

        internal Label lbl3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbl3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbl3 != null)
                {
                }

                _lbl3 = value;
                if (_lbl3 != null)
                {
                }
            }
        }

        private TextBox _txtBankName;

        internal TextBox txtBankName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBankName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBankName != null)
                {
                }

                _txtBankName = value;
                if (_txtBankName != null)
                {
                }
            }
        }

        private TextBox _txtAccNumber;

        internal TextBox txtAccNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccNumber != null)
                {
                }

                _txtAccNumber = value;
                if (_txtAccNumber != null)
                {
                }
            }
        }

        private Label _lblBankName;

        internal Label lblBankName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBankName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBankName != null)
                {
                }

                _lblBankName = value;
                if (_lblBankName != null)
                {
                }
            }
        }

        private Label _lblAccNumber;

        internal Label lblAccNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccNumber != null)
                {
                }

                _lblAccNumber = value;
                if (_lblAccNumber != null)
                {
                }
            }
        }

        private TextBox _txtSortCode;

        internal TextBox txtSortCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSortCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSortCode != null)
                {
                }

                _txtSortCode = value;
                if (_txtSortCode != null)
                {
                }
            }
        }

        private Label _lblSortCode;

        internal Label lblSortCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSortCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSortCode != null)
                {
                }

                _lblSortCode = value;
                if (_lblSortCode != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private DateTimePicker _dtpEffDate;

        internal DateTimePicker dtpEffDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEffDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEffDate != null)
                {
                }

                _dtpEffDate = value;
                if (_dtpEffDate != null)
                {
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
            _grpDD = new Panel();
            _txtAccName = new TextBox();
            _lbl3 = new Label();
            _txtBankName = new TextBox();
            _txtAccNumber = new TextBox();
            _lblBankName = new Label();
            _lblAccNumber = new Label();
            _txtSortCode = new TextBox();
            _lblSortCode = new Label();
            _Label3 = new Label();
            _cboPayer = new ComboBox();
            _cboPayer.SelectedIndexChanged += new EventHandler(cboPayer_SelectedIndexChanged);
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
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _Label2 = new Label();
            _Panel1 = new Panel();
            _dtpEffDate = new DateTimePicker();
            _Label4 = new Label();
            _grpResults.SuspendLayout();
            _grpDD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgResults).BeginInit();
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
            _txtFilter.Location = new Point(109, 40);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(547, 21);
            _txtFilter.TabIndex = 1;
            //
            // grpResults
            //
            _grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpResults.Controls.Add(_Label4);
            _grpResults.Controls.Add(_dtpEffDate);
            _grpResults.Controls.Add(_grpDD);
            _grpResults.Controls.Add(_Label3);
            _grpResults.Controls.Add(_cboPayer);
            _grpResults.Controls.Add(_dgResults);
            _grpResults.Location = new Point(8, 68);
            _grpResults.Name = "grpResults";
            _grpResults.Size = new Size(793, 377);
            _grpResults.TabIndex = 4;
            _grpResults.TabStop = false;
            _grpResults.Text = "Select record and click OK";
            //
            // grpDD
            //
            _grpDD.Controls.Add(_txtAccName);
            _grpDD.Controls.Add(_lbl3);
            _grpDD.Controls.Add(_txtBankName);
            _grpDD.Controls.Add(_txtAccNumber);
            _grpDD.Controls.Add(_lblBankName);
            _grpDD.Controls.Add(_lblAccNumber);
            _grpDD.Controls.Add(_txtSortCode);
            _grpDD.Controls.Add(_lblSortCode);
            _grpDD.Location = new Point(3, 279);
            _grpDD.Name = "grpDD";
            _grpDD.Size = new Size(782, 63);
            _grpDD.TabIndex = 5;
            _grpDD.Visible = false;
            //
            // txtAccName
            //
            _txtAccName.Location = new Point(111, 19);
            _txtAccName.Name = "txtAccName";
            _txtAccName.Size = new Size(137, 21);
            _txtAccName.TabIndex = 120;
            //
            // lbl3
            //
            _lbl3.Location = new Point(20, 23);
            _lbl3.Name = "lbl3";
            _lbl3.Size = new Size(89, 20);
            _lbl3.TabIndex = 128;
            _lbl3.Text = "Account Name";
            //
            // txtBankName
            //
            _txtBankName.Location = new Point(654, 19);
            _txtBankName.Name = "txtBankName";
            _txtBankName.Size = new Size(104, 21);
            _txtBankName.TabIndex = 123;
            //
            // txtAccNumber
            //
            _txtAccNumber.Location = new Point(497, 19);
            _txtAccNumber.Name = "txtAccNumber";
            _txtAccNumber.Size = new Size(84, 21);
            _txtAccNumber.TabIndex = 122;
            //
            // lblBankName
            //
            _lblBankName.Location = new Point(582, 22);
            _lblBankName.Name = "lblBankName";
            _lblBankName.Size = new Size(78, 20);
            _lblBankName.TabIndex = 127;
            _lblBankName.Text = "Bank Name";
            //
            // lblAccNumber
            //
            _lblAccNumber.Location = new Point(396, 22);
            _lblAccNumber.Name = "lblAccNumber";
            _lblAccNumber.Size = new Size(108, 20);
            _lblAccNumber.TabIndex = 126;
            _lblAccNumber.Text = "Account Number";
            //
            // txtSortCode
            //
            _txtSortCode.Location = new Point(315, 19);
            _txtSortCode.Name = "txtSortCode";
            _txtSortCode.Size = new Size(77, 21);
            _txtSortCode.TabIndex = 121;
            //
            // lblSortCode
            //
            _lblSortCode.Location = new Point(251, 23);
            _lblSortCode.Name = "lblSortCode";
            _lblSortCode.Size = new Size(73, 20);
            _lblSortCode.TabIndex = 125;
            _lblSortCode.Text = "Sort Code";
            //
            // Label3
            //
            _Label3.Location = new Point(6, 205);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(100, 24);
            _Label3.TabIndex = 4;
            _Label3.Text = "Payer";
            //
            // cboPayer
            //
            _cboPayer.FormattingEnabled = true;
            _cboPayer.Location = new Point(8, 231);
            _cboPayer.Name = "cboPayer";
            _cboPayer.Size = new Size(271, 21);
            _cboPayer.TabIndex = 3;
            //
            // dgResults
            //
            _dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgResults.DataMember = "";
            _dgResults.HeaderForeColor = SystemColors.ControlText;
            _dgResults.Location = new Point(8, 27);
            _dgResults.Name = "dgResults";
            _dgResults.Size = new Size(777, 150);
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
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdd.Location = new Point(664, 35);
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
            // dtpEffDate
            //
            _dtpEffDate.Location = new Point(585, 228);
            _dtpEffDate.Name = "dtpEffDate";
            _dtpEffDate.Size = new Size(200, 21);
            _dtpEffDate.TabIndex = 6;
            //
            // Label4
            //
            _Label4.Location = new Point(582, 201);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(100, 24);
            _Label4.TabIndex = 7;
            _Label4.Text = "Effective From";
            //
            // DLGFindSite
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(809, 481);
            ControlBox = false;
            Controls.Add(_Panel1);
            Controls.Add(_Label2);
            Controls.Add(_btnAdd);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_grpResults);
            Controls.Add(_txtFilter);
            Controls.Add(_Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(704, 392);
            Name = "DLGFindSite";
            Text = "Find {0}";
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_txtFilter, 0);
            Controls.SetChildIndex(_grpResults, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_btnAdd, 0);
            Controls.SetChildIndex(_Label2, 0);
            Controls.SetChildIndex(_Panel1, 0);
            _grpResults.ResumeLayout(false);
            _grpDD.ResumeLayout(false);
            _grpDD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgResults).EndInit();
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

                    case Entity.Sys.Enums.TableNames.tblSite:
                        {
                            if (ForeignKeyFilter > 0)
                            {
                                Text = "Find Property For Customer";
                                Records = App.DB.Sites.GetForCustomer_Light(ForeignKeyFilter, App.loggedInUser.UserID);
                            }
                            else
                            {
                                Text = "Find Property";
                                Records = App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID);
                            }

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
                            Records = App.DB.Job.Job_Get_All("Where tblJob.Deleted =0 ");
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
                            Text = "Find Van";
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

        private string _2ndID = 0.ToString();

        public string SecondID
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

        private string _AddressID = 0.ToString();

        public string AddressID
        {
            get
            {
                return _AddressID;
            }

            set
            {
                _AddressID = value;
            }
        }

        private string _InvoiceFrequencyID = 0.ToString();

        public string InvoiceFrequencyID
        {
            get
            {
                return _InvoiceFrequencyID;
            }

            set
            {
                _InvoiceFrequencyID = value;
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

        private DateTime _EffDate = DateTime.MinValue;

        public DateTime EffDate
        {
            get
            {
                return _EffDate;
            }

            set
            {
                _EffDate = value;
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
                        Name.Width = 160;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var AccountNumber = new DataGridLabelColumn();
                        AccountNumber.Format = "";
                        AccountNumber.FormatInfo = null;
                        AccountNumber.HeaderText = "Account Number";
                        AccountNumber.MappingName = "AccountNumber";
                        AccountNumber.ReadOnly = true;
                        AccountNumber.Width = 160;
                        AccountNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(AccountNumber);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 160;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var Type = new DataGridLabelColumn();
                        Type.Format = "";
                        Type.FormatInfo = null;
                        Type.HeaderText = "Type";
                        Type.MappingName = "Type";
                        Type.ReadOnly = true;
                        Type.Width = 160;
                        Type.NullText = "";
                        tStyle.GridColumnStyles.Add(Type);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblSite:
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
                        Registration.HeaderText = "Registration";
                        Registration.MappingName = "Registration";
                        Registration.ReadOnly = true;
                        Registration.Width = 100;
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
                        Name.Width = 160;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var TelephoneNum = new DataGridLabelColumn();
                        TelephoneNum.Format = "";
                        TelephoneNum.FormatInfo = null;
                        TelephoneNum.HeaderText = "Telephone Number";
                        TelephoneNum.MappingName = "TelephoneNum";
                        TelephoneNum.ReadOnly = true;
                        TelephoneNum.Width = 100;
                        TelephoneNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelephoneNum);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 100;
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
            }

            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
            dgResults.TableStyles.Add(tStyle);
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
            // If Not TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
            // Exit Sub
            // End If
            if (SelectedDataRow is null)
            {
                StockDataview = null;
            }
            else
            {
                SelectItem();
                var dt = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(ID).Table;
                cboPayer.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                    cboPayer.Items.Add(new Combo(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["Address1"] + ",") + dr["Address2"] + ",") + dr["Postcode"]), Conversions.ToString(Conversions.ToString(dr["AddressID"] + "`") + dr["AddressTypeID"])));
                cboPayer.Items.Add(new Combo("-- Please Select --", 0.ToString()));
                cboPayer.DisplayMember = "Description";
                cboPayer.ValueMember = "Value";
                var argcombo = cboPayer;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
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
            if ((Combo.get_GetSelectedItemValue(cboPayer) ?? "") == "0")
            {
                return;
            }
            else
            {
                // If grpDD.Visible = True And Not (txtBankName.Text.Length > 0 And txtAccName.Text.Length > 2 And txtSortCode.Text.Length > 5 And txtAccNumber.Text.Length > 7) Then
                // ShowMessage("You must enter Bank name ,Account name, sortcode and account code correctly for Direct Debit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                // Exit Sub
                // End If
                EffDate = dtpEffDate.Value;
                DialogResult = DialogResult.OK;
            }
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
                        SecondID = Conversions.ToString(SelectedDataRow["PartID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProductSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["ProductSupplierID"]);
                        SecondID = Conversions.ToString(SelectedDataRow["ProductID"]);
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
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["EngineerID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblOrder:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["OrderID"]);
                        break;
                    }
            }

            // Me.DialogResult = DialogResult.OK
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

                    case Entity.Sys.Enums.TableNames.tblContact:
                        {
                            whereClause += " AND (Firstname LIKE '%" + txtFilter.Text.Trim() + "%') OR (Surname LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSite:
                        {
                            whereClause += " AND (Name LIKE '%" + txtFilter.Text.Trim() + "%' OR Address1 LIKE '%" + txtFilter.Text.Trim() + "%')";
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
                        {
                            whereClause += " AND Registration LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    default:
                        {
                            whereClause += " AND Name LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }
                }
            }

            Records.RowFilter = whereClause;
            StockDataview = null;
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
                DataRowView dr = (DataRowView)source.List[rowNum];
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

        private void cboPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo.get_GetSelectedItemValue(cboPayer) ?? "") != "0")
            {
                SecondID = Combo.get_GetSelectedItemValue(cboPayer);

                // If SecondID.Split("`")(0) <> AddressID Then

                // grpDD.Visible = True

                // End If
            }
        }
    }
}