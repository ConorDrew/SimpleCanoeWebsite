using Microsoft.VisualBasic;
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
    public class FRMStockReplenishment : FRMBaseForm, IForm
    {
        public FRMStockReplenishment() : base()
        {
            base.Load += FRMStockReplenishment_Load;

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
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private DataGrid _dgStockReplenishment;

        internal DataGrid dgStockReplenishment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgStockReplenishment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgStockReplenishment != null)
                {
                    _dgStockReplenishment.MouseUp -= dgStockReplenishment_MouseUp;
                }

                _dgStockReplenishment = value;
                if (_dgStockReplenishment != null)
                {
                    _dgStockReplenishment.MouseUp += dgStockReplenishment_MouseUp;
                }
            }
        }

        private Button _btnToMinimum;

        private Button _btnToRecommended;

        private CheckBox _chkRecommended;

        internal CheckBox chkRecommended
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRecommended;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRecommended != null)
                {
                }

                _chkRecommended = value;
                if (_chkRecommended != null)
                {
                }
            }
        }

        private CheckBox _chkMinimum;

        internal CheckBox chkMinimum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMinimum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMinimum != null)
                {
                }

                _chkMinimum = value;
                if (_chkMinimum != null)
                {
                }
            }
        }

        private Label _lblNumberOfItems;

        internal Label lblNumberOfItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNumberOfItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNumberOfItems != null)
                {
                }

                _lblNumberOfItems = value;
                if (_lblNumberOfItems != null)
                {
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

        private Panel _Panel2;

        private Panel _Panel3;

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

        private Panel _Panel4;

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        private Label _Label8;

        private GroupBox _GroupBox3;

        private TextBox _txtItem;

        internal TextBox txtItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtItem != null)
                {
                }

                _txtItem = value;
                if (_txtItem != null)
                {
                }
            }
        }

        private TextBox _txtLocation;

        internal TextBox txtLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocation != null)
                {
                }

                _txtLocation = value;
                if (_txtLocation != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private Button _btnRunFilter;

        private CheckBox _chkIncludeVans;

        internal CheckBox chkIncludeVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIncludeVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIncludeVans != null)
                {
                }

                _chkIncludeVans = value;
                if (_chkIncludeVans != null)
                {
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._dgStockReplenishment = new System.Windows.Forms.DataGrid();
            this._btnToMinimum = new System.Windows.Forms.Button();
            this._btnToRecommended = new System.Windows.Forms.Button();
            this._chkRecommended = new System.Windows.Forms.CheckBox();
            this._chkMinimum = new System.Windows.Forms.CheckBox();
            this._lblNumberOfItems = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._Panel3 = new System.Windows.Forms.Panel();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._Panel4 = new System.Windows.Forms.Panel();
            this._Label5 = new System.Windows.Forms.Label();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._btnRunFilter = new System.Windows.Forms.Button();
            this._chkIncludeVans = new System.Windows.Forms.CheckBox();
            this._txtItem = new System.Windows.Forms.TextBox();
            this._txtLocation = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._GroupBox3 = new System.Windows.Forms.GroupBox();
            this._btnClose = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgStockReplenishment)).BeginInit();
            this._GroupBox2.SuspendLayout();
            this._GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dgStockReplenishment);
            this._GroupBox1.Location = new System.Drawing.Point(8, 170);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(992, 522);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Tick those combinations you wish to update";
            // 
            // _dgStockReplenishment
            // 
            this._dgStockReplenishment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgStockReplenishment.DataMember = "";
            this._dgStockReplenishment.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgStockReplenishment.Location = new System.Drawing.Point(8, 25);
            this._dgStockReplenishment.Name = "_dgStockReplenishment";
            this._dgStockReplenishment.Size = new System.Drawing.Size(976, 489);
            this._dgStockReplenishment.TabIndex = 7;
            this._dgStockReplenishment.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgStockReplenishment_MouseUp);
            // 
            // _btnToMinimum
            // 
            this._btnToMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnToMinimum.Location = new System.Drawing.Point(432, 700);
            this._btnToMinimum.Name = "_btnToMinimum";
            this._btnToMinimum.Size = new System.Drawing.Size(280, 23);
            this._btnToMinimum.TabIndex = 3;
            this._btnToMinimum.Text = "Bring amounts up to minimum quantities";
            this._btnToMinimum.Click += new System.EventHandler(this.btnToMinimum_Click);
            // 
            // _btnToRecommended
            // 
            this._btnToRecommended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnToRecommended.Location = new System.Drawing.Point(720, 700);
            this._btnToRecommended.Name = "_btnToRecommended";
            this._btnToRecommended.Size = new System.Drawing.Size(280, 23);
            this._btnToRecommended.TabIndex = 4;
            this._btnToRecommended.Text = "Bring amounts up to maximum quantities";
            this._btnToRecommended.Click += new System.EventHandler(this.btnToRecommended_Click);
            // 
            // _chkRecommended
            // 
            this._chkRecommended.Location = new System.Drawing.Point(10, 76);
            this._chkRecommended.Name = "_chkRecommended";
            this._chkRecommended.Size = new System.Drawing.Size(271, 24);
            this._chkRecommended.TabIndex = 2;
            this._chkRecommended.Text = "Items where amount is below maximum";
            // 
            // _chkMinimum
            // 
            this._chkMinimum.Checked = true;
            this._chkMinimum.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkMinimum.Location = new System.Drawing.Point(10, 103);
            this._chkMinimum.Name = "_chkMinimum";
            this._chkMinimum.Size = new System.Drawing.Size(256, 24);
            this._chkMinimum.TabIndex = 3;
            this._chkMinimum.Text = "Items where amount is below minimum";
            // 
            // _lblNumberOfItems
            // 
            this._lblNumberOfItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblNumberOfItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._lblNumberOfItems.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblNumberOfItems.Location = new System.Drawing.Point(85, 700);
            this._lblNumberOfItems.Name = "_lblNumberOfItems";
            this._lblNumberOfItems.Size = new System.Drawing.Size(341, 24);
            this._lblNumberOfItems.TabIndex = 7;
            this._lblNumberOfItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Label2
            // 
            this._Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label2.Location = new System.Drawing.Point(32, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(425, 16);
            this._Label2.TabIndex = 9;
            this._Label2.Text = "Amount ABOVE or EQUAL to both minimum and the maximum quantities";
            // 
            // _Panel1
            // 
            this._Panel1.BackColor = System.Drawing.Color.Yellow;
            this._Panel1.Location = new System.Drawing.Point(8, 54);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(16, 16);
            this._Panel1.TabIndex = 10;
            // 
            // _Panel2
            // 
            this._Panel2.BackColor = System.Drawing.Color.Salmon;
            this._Panel2.Location = new System.Drawing.Point(8, 82);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(16, 16);
            this._Panel2.TabIndex = 11;
            // 
            // _Panel3
            // 
            this._Panel3.BackColor = System.Drawing.Color.LightGreen;
            this._Panel3.Location = new System.Drawing.Point(8, 24);
            this._Panel3.Name = "_Panel3";
            this._Panel3.Size = new System.Drawing.Size(16, 16);
            this._Panel3.TabIndex = 12;
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(32, 54);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(425, 16);
            this._Label3.TabIndex = 13;
            this._Label3.Text = "Amount ABOVE or EQUAL to minimum but BELOW maximum quantities";
            // 
            // _Label4
            // 
            this._Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(32, 82);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(376, 16);
            this._Label4.TabIndex = 14;
            this._Label4.Text = "Amount BELOW both minimum and the maximum quantities";
            // 
            // _Panel4
            // 
            this._Panel4.BackColor = System.Drawing.Color.LightBlue;
            this._Panel4.Location = new System.Drawing.Point(8, 109);
            this._Panel4.Name = "_Panel4";
            this._Panel4.Size = new System.Drawing.Size(16, 16);
            this._Panel4.TabIndex = 15;
            // 
            // _Label5
            // 
            this._Label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label5.Location = new System.Drawing.Point(32, 109);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(376, 16);
            this._Label5.TabIndex = 16;
            this._Label5.Text = "A quantity is on order to replenish stock";
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._btnRunFilter);
            this._GroupBox2.Controls.Add(this._chkIncludeVans);
            this._GroupBox2.Controls.Add(this._txtItem);
            this._GroupBox2.Controls.Add(this._txtLocation);
            this._GroupBox2.Controls.Add(this._Label6);
            this._GroupBox2.Controls.Add(this._Label8);
            this._GroupBox2.Controls.Add(this._chkRecommended);
            this._GroupBox2.Controls.Add(this._chkMinimum);
            this._GroupBox2.Location = new System.Drawing.Point(8, 12);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(479, 152);
            this._GroupBox2.TabIndex = 0;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Filters";
            // 
            // _btnRunFilter
            // 
            this._btnRunFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRunFilter.Location = new System.Drawing.Point(388, 122);
            this._btnRunFilter.Name = "_btnRunFilter";
            this._btnRunFilter.Size = new System.Drawing.Size(85, 23);
            this._btnRunFilter.TabIndex = 12;
            this._btnRunFilter.Text = "Filter";
            this._btnRunFilter.UseVisualStyleBackColor = true;
            this._btnRunFilter.Click += new System.EventHandler(this.btnRunFilter_Click);
            // 
            // _chkIncludeVans
            // 
            this._chkIncludeVans.Location = new System.Drawing.Point(10, 128);
            this._chkIncludeVans.Name = "_chkIncludeVans";
            this._chkIncludeVans.Size = new System.Drawing.Size(256, 24);
            this._chkIncludeVans.TabIndex = 11;
            this._chkIncludeVans.Text = "Include Vans";
            // 
            // _txtItem
            // 
            this._txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtItem.Location = new System.Drawing.Point(80, 49);
            this._txtItem.Name = "_txtItem";
            this._txtItem.Size = new System.Drawing.Size(393, 21);
            this._txtItem.TabIndex = 1;
            // 
            // _txtLocation
            // 
            this._txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLocation.Location = new System.Drawing.Point(80, 21);
            this._txtLocation.Name = "_txtLocation";
            this._txtLocation.Size = new System.Drawing.Size(393, 21);
            this._txtLocation.TabIndex = 0;
            // 
            // _Label6
            // 
            this._Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label6.Location = new System.Drawing.Point(10, 49);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 23);
            this._Label6.TabIndex = 10;
            this._Label6.Text = "Item";
            // 
            // _Label8
            // 
            this._Label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label8.Location = new System.Drawing.Point(10, 23);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(88, 23);
            this._Label8.TabIndex = 7;
            this._Label8.Text = "Location";
            // 
            // _GroupBox3
            // 
            this._GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox3.Controls.Add(this._Panel1);
            this._GroupBox3.Controls.Add(this._Panel3);
            this._GroupBox3.Controls.Add(this._Panel4);
            this._GroupBox3.Controls.Add(this._Panel2);
            this._GroupBox3.Controls.Add(this._Label2);
            this._GroupBox3.Controls.Add(this._Label3);
            this._GroupBox3.Controls.Add(this._Label4);
            this._GroupBox3.Controls.Add(this._Label5);
            this._GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._GroupBox3.Location = new System.Drawing.Point(493, 12);
            this._GroupBox3.Name = "_GroupBox3";
            this._GroupBox3.Size = new System.Drawing.Size(507, 152);
            this._GroupBox3.TabIndex = 1;
            this._GroupBox3.TabStop = false;
            this._GroupBox3.Text = "KEY";
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(8, 700);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(64, 23);
            this._btnClose.TabIndex = 5;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMStockReplenishment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._GroupBox3);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._lblNumberOfItems);
            this.Controls.Add(this._btnToRecommended);
            this.Controls.Add(this._btnToMinimum);
            this.Controls.Add(this._GroupBox1);
            this.MinimumSize = new System.Drawing.Size(832, 544);
            this.Name = "FRMStockReplenishment";
            this.Text = "Stock Replenishment";
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgStockReplenishment)).EndInit();
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this._GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            if (Conversions.ToBoolean(get_GetParameter(0)))
            {
                WindowState = FormWindowState.Maximized;
            }

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
            // DO NOTHING
        }

        private string lastSelectedType = "";
        private int lastSelectedID = 0;
        private ArrayList warehouses = new ArrayList();
        private ArrayList vans = new ArrayList();
        private DataView _StockDataView = null;

        public DataView StockDataView
        {
            get
            {
                return _StockDataView;
            }

            set
            {
                _StockDataView = value;
                _StockDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
                _StockDataView.AllowNew = false;
                _StockDataView.AllowEdit = false;
                _StockDataView.AllowDelete = false;
                dgStockReplenishment.DataSource = StockDataView;
            }
        }

        private DataRow SelectedStockDataRow
        {
            get
            {
                if (!(dgStockReplenishment.CurrentRowIndex == -1))
                {
                    return StockDataView[dgStockReplenishment.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupStockDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgStockReplenishment);
            var tStyle = dgStockReplenishment.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgStockReplenishment.ReadOnly = false;
            tStyle.AllowSorting = true;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 150;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var Item = new DataGridLabelColumn();
            Item.Format = "";
            Item.FormatInfo = null;
            Item.HeaderText = "Item";
            Item.MappingName = "Item";
            Item.ReadOnly = true;
            Item.Width = 150;
            Item.NullText = "";
            tStyle.GridColumnStyles.Add(Item);
            var MinimumQuantity = new DataGridLabelColumn();
            MinimumQuantity.Format = "";
            MinimumQuantity.FormatInfo = null;
            MinimumQuantity.HeaderText = "Minimum Quantity";
            MinimumQuantity.MappingName = "MinimumQuantity";
            MinimumQuantity.ReadOnly = true;
            MinimumQuantity.Width = 150;
            MinimumQuantity.NullText = "";
            tStyle.GridColumnStyles.Add(MinimumQuantity);
            var RecommendedQuantity = new DataGridLabelColumn();
            RecommendedQuantity.Format = "";
            RecommendedQuantity.FormatInfo = null;
            RecommendedQuantity.HeaderText = "Maximum Quantity";
            RecommendedQuantity.MappingName = "RecommendedQuantity";
            RecommendedQuantity.ReadOnly = true;
            RecommendedQuantity.Width = 150;
            RecommendedQuantity.NullText = "";
            tStyle.GridColumnStyles.Add(RecommendedQuantity);
            var Amount = new StockReplenishmentColourColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 75;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            var PacksOnOrder = new DataGridLabelColumn();
            PacksOnOrder.Format = "";
            PacksOnOrder.FormatInfo = null;
            PacksOnOrder.HeaderText = "Packs On Order";
            PacksOnOrder.MappingName = "PacksOnOrder";
            PacksOnOrder.ReadOnly = true;
            PacksOnOrder.Width = 120;
            PacksOnOrder.NullText = "";
            tStyle.GridColumnStyles.Add(PacksOnOrder);
            var UnitsOnOrder = new DataGridLabelColumn();
            UnitsOnOrder.Format = "";
            UnitsOnOrder.FormatInfo = null;
            UnitsOnOrder.HeaderText = "Units On Order";
            UnitsOnOrder.MappingName = "UnitsOnOrder";
            UnitsOnOrder.ReadOnly = true;
            UnitsOnOrder.Width = 120;
            UnitsOnOrder.NullText = "";
            tStyle.GridColumnStyles.Add(UnitsOnOrder);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dgStockReplenishment.TableStyles.Add(tStyle);
            Entity.Sys.Helper.RemoveEventHandlers(dgStockReplenishment);
        }

        private void FRMStockReplenishment_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgStockReplenishment_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (SelectedStockDataRow is null)
                {
                    return;
                }

                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgStockReplenishment.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    if (HitTestInfo.Column == 0)
                    {
                        bool selected = !Conversions.ToBoolean(dgStockReplenishment[dgStockReplenishment.CurrentRowIndex, 0]);
                        dgStockReplenishment[dgStockReplenishment.CurrentRowIndex, 0] = selected;
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnToMinimum_Click(object sender, EventArgs e)
        {
            try
            {
                lastSelectedType = "";
                lastSelectedID = 0;
                if (App.ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                warehouses.Clear();
                vans.Clear();
                foreach (DataRow row in StockDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["WarehouseID"], 0, false)))
                        {
                            AddPlaceToGetFrom(row, "MinimumQuantity", CheckAndAddVan(Conversions.ToInteger(row["VanID"]), Conversions.ToString(row["Location"])), true);
                        }
                        else
                        {
                            AddPlaceToGetFrom(row, "MinimumQuantity", CheckAndAddWarehouse(Conversions.ToInteger(row["WarehouseID"]), Conversions.ToString(row["Location"])), false);
                        }
                    }
                }

                CreateOrders();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating orders : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void btnToRecommended_Click(object sender, EventArgs e)
        {
            try
            {
                lastSelectedType = "";
                lastSelectedID = 0;
                if (App.ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                warehouses.Clear();
                vans.Clear();
                foreach (DataRow row in StockDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["WarehouseID"], 0, false)))
                        {
                            AddPlaceToGetFrom(row, "RecommendedQuantity", CheckAndAddVan(Conversions.ToInteger(row["VanID"]), Conversions.ToString(row["Location"])), true);
                        }
                        else
                        {
                            AddPlaceToGetFrom(row, "RecommendedQuantity", CheckAndAddWarehouse(Conversions.ToInteger(row["WarehouseID"]), Conversions.ToString(row["Location"])), false);
                        }
                    }
                }

                CreateOrders();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating orders : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void btnRunFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            StockDataView = App.DB.Location.StockTake_Replenishment_Filtered(txtLocation.Text, txtItem.Text, chkIncludeVans.Checked, chkMinimum.Checked, chkRecommended.Checked);
            lblNumberOfItems.Text = StockDataView.Count + " Items";
        }

        private int CheckAndAddWarehouse(int WarehouseID, string Warehouse)
        {
            bool found = false;
            int index = 0;
            foreach (ArrayList item in warehouses)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(item[0], WarehouseID, false)))
                {
                    found = true;
                    break;
                }

                index += 1;
            }

            if (!found)
            {
                var newWarehouse = new ArrayList();
                newWarehouse.Add(WarehouseID);
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("PartID"));
                dt.Columns.Add(new DataColumn("PartSupplierID"));
                dt.Columns.Add(new DataColumn("LocationID"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("BuyPrice"));
                dt.Columns.Add(new DataColumn("SupplierID"));
                dt.Columns.Add(new DataColumn("Deleted"));
                newWarehouse.Add(dt);
                newWarehouse.Add(Warehouse);
                warehouses.Add(newWarehouse);
            }

            return index;
        }

        private int CheckAndAddVan(int VanID, string Van)
        {
            bool found = false;
            int index = 0;
            foreach (ArrayList item in vans)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(item[0], VanID, false)))
                {
                    found = true;
                    break;
                }

                index += 1;
            }

            if (!found)
            {
                var newVan = new ArrayList();
                newVan.Add(VanID);
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("PartID"));
                dt.Columns.Add(new DataColumn("PartSupplierID"));
                dt.Columns.Add(new DataColumn("LocationID"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("BuyPrice"));
                dt.Columns.Add(new DataColumn("SupplierID"));
                dt.Columns.Add(new DataColumn("Deleted"));
                newVan.Add(dt);
                newVan.Add(Van);
                vans.Add(newVan);
            }

            return index;
        }

        private void AddPlaceToGetFrom(DataRow row, string MinimumOrRecommended, int Index, bool ForVan)
        {
            int quantityFromLocation = 0;
            if ((MinimumOrRecommended ?? "") == "MinimumQuantity")
            {
                quantityFromLocation = Conversions.ToInteger((int)row["MinimumQuantity"] - (int)row["Amount"] - (int)row["PacksOnOrder"]);
            }
            else if ((MinimumOrRecommended ?? "") == "RecommendedQuantity")
            {
                quantityFromLocation = Conversions.ToInteger((int)row["RecommendedQuantity"] - (int)row["Amount"] - (int)row["PacksOnOrder"]);
            }

            if (quantityFromLocation <= 0)
            {
                return;
            }

            int LocationID = 0;
            int PartSupplierID = 0;
            int QuantityInPack = 0;
            int SupplierID = 0;
            double Price = 0.0;
            FRMSelectLocation oFRMSelectLocation = (FRMSelectLocation)App.ShowForm(typeof(FRMSelectLocation), true, new object[] { row["PartID"], row["Item"], row["Location"], quantityFromLocation, warehouses, vans, lastSelectedType, lastSelectedID, "" });
            if (oFRMSelectLocation is null)
            {
                return;
            }
            else
            {
                if (oFRMSelectLocation.DialogResult == DialogResult.OK)
                {
                    LocationID = oFRMSelectLocation.LocationID;
                    PartSupplierID = oFRMSelectLocation.PartSupplierID;
                    QuantityInPack = oFRMSelectLocation.InPack;
                    SupplierID = oFRMSelectLocation.SupplierID;
                    Price = oFRMSelectLocation.Price;
                }

                oFRMSelectLocation.Dispose();
            }

            if (LocationID == 0 & PartSupplierID == 0)
            {
                App.ShowMessage(Conversions.ToString(Conversions.ToString("No location selected for the item : " + row["Item"] + " at ") + row["Location"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (LocationID == 0)
            {
                int quantityNeeded = 0;
                if ((MinimumOrRecommended ?? "") == "MinimumQuantity")
                {
                    quantityNeeded = Conversions.ToInteger(Math.Ceiling(((int)row["MinimumQuantity"] - (decimal)row["Amount"] - (int)row["PacksOnOrder"]) / QuantityInPack));
                }
                else if ((MinimumOrRecommended ?? "") == "RecommendedQuantity")
                {
                    quantityNeeded = Conversions.ToInteger(Math.Ceiling(((int)row["RecommendedQuantity"] - (decimal)row["Amount"] - (int)row["PacksOnOrder"]) / QuantityInPack));
                }

                if (quantityNeeded <= 0)
                {
                    App.ShowMessage(Conversions.ToString(Conversions.ToString("No order needed for the item : " + row["Item"] + " at ") + row["Location"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataRow newRow;
                    if (ForVan)
                    {
                        newRow = ((DataTable)((ArrayList)vans[Index])[1]).NewRow();
                    }
                    else
                    {
                        newRow = ((DataTable)((ArrayList)warehouses[Index])[1]).NewRow();
                    }

                    newRow["PartID"] = row["PartID"];
                    newRow["PartSupplierID"] = PartSupplierID;
                    newRow["LocationID"] = 0;
                    newRow["Quantity"] = quantityNeeded;
                    newRow["BuyPrice"] = Price;
                    newRow["SupplierID"] = SupplierID;
                    if (ForVan)
                    {
                        ((DataTable)((ArrayList)vans[Index])[1]).Rows.Add(newRow);
                    }
                    else
                    {
                        ((DataTable)((ArrayList)warehouses[Index])[1]).Rows.Add(newRow);
                    }

                    lastSelectedType = "Supplier";
                    lastSelectedID = PartSupplierID;
                }
            }
            else
            {
                DataRow newRow;
                if (ForVan)
                {
                    newRow = ((DataTable)((ArrayList)vans[Index])[1]).NewRow();
                }
                else
                {
                    newRow = ((DataTable)((ArrayList)warehouses[Index])[1]).NewRow();
                }

                newRow["PartID"] = row["PartID"];
                newRow["PartSupplierID"] = 0;
                newRow["LocationID"] = LocationID;
                newRow["Quantity"] = quantityFromLocation;
                newRow["BuyPrice"] = 0.0;
                newRow["SupplierID"] = 0;
                if (ForVan)
                {
                    ((DataTable)((ArrayList)vans[Index])[1]).Rows.Add(newRow);
                }
                else
                {
                    ((DataTable)((ArrayList)warehouses[Index])[1]).Rows.Add(newRow);
                }

                lastSelectedType = "Warehouse";
                lastSelectedID = LocationID;
            }
        }

        // THIS WAS THE ORIGINAL METHOD UNTIL TONY B SPOKE TO ROB AND MADE THE ALTERATIONS AS PER ABOVE METHOD
        // Private Sub AddPlaceToGetFrom(ByVal row As DataRow, ByVal MinimumOrRecommended As String, ByVal Index As Integer, ByVal ForVan As Boolean)
        // Dim quantityFromLocation As Integer = 0
        // If MinimumOrRecommended = "MinimumQuantity" Then
        // quantityFromLocation = ((row.Item("MinimumQuantity") - row.Item("Amount")) - row.Item("OnOrder"))
        // ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
        // quantityFromLocation = ((row.Item("RecommendedQuantity") - row.Item("Amount")) - row.Item("OnOrder"))
        // End If

        // If quantityFromLocation = 0 Then
        // Exit Sub
        // End If

        // Dim locationID As Integer = 0

        // For Each orderRow As DataRow In DB.Part.Stock_Get_Locations(row.Item("PartID"), row.Item("WarehouseID")).Table.Rows
        // If orderRow.Item("Type") = "WAREHOUSE" Then
        // If orderRow.Item("Quantity") >= quantityFromLocation Then
        // If ShowMessage("There is enough stock for the item '" & row.Item("Item") & "' in the '" & orderRow.Item("Location") & "' warehouse" & vbCrLf & "Replenish using this stock?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
        // locationID = orderRow.Item("LocationID")
        // Exit For
        // End If
        // Else
        // If ShowMessage("There is not enough stock for the item '" & row.Item("Item") & "' in the '" & orderRow.Item("Location") & "' warehouse" & vbCrLf & "Replenish using this location and await stock arrival?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
        // locationID = orderRow.Item("LocationID")
        // Exit For
        // End If
        // End If
        // End If
        // Next

        // If locationID = 0 Then
        // Dim PartSupplierID As Integer = 0
        // Dim PartSuppliers As DataTable = DB.PartSupplier.Get_ByPartID(row.Item("PartID")).Table
        // If PartSuppliers.Rows.Count = 0 Then
        // PartSupplierID = 0
        // ShowMessage("There are no suppliers for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        // ElseIf PartSuppliers.Rows.Count = 1 Then
        // PartSupplierID = PartSuppliers.Rows(0).Item("PartSupplierID")
        // Else
        // PartSupplierID = PickPartProductSupplier(Entity.Sys.Enums.TableNames.tblPartSupplier, row.Item("PartID"))
        // If PartSupplierID = 0 Then
        // ShowMessage("No supplier selected for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        // End If
        // End If

        // If Not PartSupplierID = 0 Then
        // Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(PartSupplierID)

        // Dim quantityNeeded As Integer = 0
        // If MinimumOrRecommended = "MinimumQuantity" Then
        // quantityNeeded = Math.Ceiling((row.Item("MinimumQuantity") - row.Item("Amount")) / oPartSupplier.QuantityInPack)
        // ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
        // quantityNeeded = Math.Ceiling((row.Item("RecommendedQuantity") - row.Item("Amount")) / oPartSupplier.QuantityInPack)
        // End If

        // If quantityNeeded <= 0 Then
        // ShowMessage("No order needed for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        // Else
        // Dim newRow As DataRow

        // If ForVan Then
        // newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
        // Else
        // newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
        // End If

        // newRow("PartID") = row.Item("PartID")
        // newRow("PartSupplierID") = oPartSupplier.PartSupplierID
        // newRow("LocationID") = 0
        // newRow("Quantity") = quantityNeeded
        // newRow("BuyPrice") = oPartSupplier.Price
        // newRow("SupplierID") = oPartSupplier.SupplierID

        // If ForVan Then
        // CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
        // Else
        // CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
        // End If
        // End If
        // End If
        // Else
        // Dim newRow As DataRow

        // If ForVan Then
        // newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
        // Else
        // newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
        // End If

        // newRow("PartID") = row.Item("PartID")
        // newRow("PartSupplierID") = 0
        // newRow("LocationID") = locationID
        // newRow("Quantity") = quantityFromLocation
        // newRow("BuyPrice") = 0.0
        // newRow("SupplierID") = 0

        // If ForVan Then
        // CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
        // Else
        // CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
        // End If
        // End If
        // End Sub

        private string GetOrderReference(Entity.Sys.Enums.OrderType oOrderType)
        {
            var OrderNumber = new JobNumber();
            OrderNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.ORDER);
            OrderNumber.OrderNumber = OrderNumber.Number.ToString();
            while (OrderNumber.OrderNumber.Length < 5)
                OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
            string typePrefix = "";
            switch (oOrderType)
            {
                case Entity.Sys.Enums.OrderType.Customer:
                    {
                        typePrefix = "W";
                        break;
                    }

                case Entity.Sys.Enums.OrderType.StockProfile:
                    {
                        typePrefix = "V";
                        break;
                    }

                case Entity.Sys.Enums.OrderType.Warehouse:
                    {
                        typePrefix = "W";
                        break;
                    }
            }

            string userPrefix = "";
            var username = App.loggedInUser.Fullname.Split(' ');
            foreach (string s in username)
                userPrefix += s.Substring(0, 1);
            return userPrefix + typePrefix + OrderNumber.OrderNumber;
        }

        private void CreateOrders()
        {
            int orderCreated = 0;
            if (warehouses.Count == 0 & vans.Count == 0)
            {
                App.ShowMessage("No orders were needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = warehouses.Count - 1; i >= 0; i -= 1)
                {
                    if (((DataTable)((ArrayList)warehouses[i])[1]).Rows.Count == 0)
                    {
                        warehouses.RemoveAt(i);
                    }
                    else
                    {
                        // COUNT SUPPLIER
                        var suppliers = new ArrayList();
                        foreach (DataRow drItm in ((DataTable)((ArrayList)warehouses[i])[1]).Rows)
                        {
                            if (!(Conversions.ToInteger(drItm["SupplierID"]) == 0))
                            {
                                if (suppliers.Contains(Conversions.ToInteger(drItm["SupplierID"])) == false)
                                {
                                    suppliers.Add(Conversions.ToInteger(drItm["SupplierID"]));
                                }
                            }
                        }

                        // FOR EACH SUPPLIER
                        for (int j = 0, loopTo = suppliers.Count - 1; j <= loopTo; j++)
                        {
                            var oOrder = new Entity.Orders.Order();
                            oOrder.IgnoreExceptionsOnSetMethods = true;
                            oOrder.DatePlaced = DateAndTime.Now;
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Warehouse);
                            oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.Warehouse); // "REP : " & CType(warehouses.Item(i), ArrayList).Item(2) & ":" & suppliers(j)
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            oOrder.DeliveryDeadline = default;
                            oOrder.SetDoNotConsolidated = true;
                            oOrder = App.DB.Order.Insert(oOrder);
                            orderCreated += 1;
                            var oOrderLocation = new Entity.OrderLocations.OrderLocation();
                            oOrderLocation.SetOrderID = oOrder.OrderID;
                            oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(Conversions.ToInteger(((ArrayList)warehouses[i])[0])).Table.Rows[0]["LocationID"];
                            oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                            var drSelect = ((DataTable)((ArrayList)warehouses[i])[1]).Select("SupplierID='" + Conversions.ToInteger(suppliers[j]) + "'");
                            for (int k = 0, loopTo1 = drSelect.Length - 1; k <= loopTo1; k++)
                            {
                                var row = drSelect[k];
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                {
                                    var oOrderPart = new Entity.OrderParts.OrderPart();
                                    oOrderPart.IgnoreExceptionsOnSetMethods = true;
                                    oOrderPart.SetOrderID = oOrder.OrderID;
                                    oOrderPart.SetPartSupplierID = row["PartSupplierID"];
                                    oOrderPart.SetQuantity = row["Quantity"];
                                    oOrderPart.SetBuyPrice = row["BuyPrice"];
                                    oOrderPart.SetSellPrice = 0.0;
                                    oOrderPart.SetQuantityReceived = 0;
                                    App.DB.OrderPart.Insert(oOrderPart, !oOrder.DoNotConsolidated);
                                }
                            }
                        }

                        // COUNT LOCATIONS
                        var locations = new ArrayList();
                        foreach (DataRow drItm in ((DataTable)((ArrayList)warehouses[i])[1]).Rows)
                        {
                            if (!(Conversions.ToInteger(drItm["LocationID"]) == 0))
                            {
                                if (locations.Contains(Conversions.ToInteger(drItm["LocationID"])) == false)
                                {
                                    locations.Add(Conversions.ToInteger(drItm["LocationID"]));
                                }
                            }
                        }

                        // FOR EACH LOCATION
                        for (int j = 0, loopTo2 = locations.Count - 1; j <= loopTo2; j++)
                        {
                            var oOrder = new Entity.Orders.Order();
                            oOrder.IgnoreExceptionsOnSetMethods = true;
                            oOrder.DatePlaced = DateAndTime.Now;
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Warehouse);
                            oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.Warehouse); // "REP : " & CType(warehouses.Item(i), ArrayList).Item(2) & ":" & locations(j)
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            oOrder.DeliveryDeadline = default;
                            oOrder = App.DB.Order.Insert(oOrder);
                            orderCreated += 1;
                            var oOrderLocation = new Entity.OrderLocations.OrderLocation();
                            oOrderLocation.SetOrderID = oOrder.OrderID;
                            oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(Conversions.ToInteger(((ArrayList)warehouses[i])[0])).Table.Rows[0]["LocationID"];
                            oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                            var drSelect = ((DataTable)((ArrayList)warehouses[i])[1]).Select("LocationID='" + Conversions.ToInteger(locations[j]) + "'");
                            for (int k = 0, loopTo3 = drSelect.Length - 1; k <= loopTo3; k++)
                            {
                                var row = drSelect[k];
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                {
                                    var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                    oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                                    oOrderLocationPart.SetOrderID = oOrder.OrderID;
                                    oOrderLocationPart.SetPartID = row["PartID"];
                                    oOrderLocationPart.SetLocationID = row["LocationID"];
                                    oOrderLocationPart.SetQuantity = row["Quantity"];
                                    oOrderLocationPart.SetSellPrice = 0.0;
                                    oOrderLocationPart.SetQuantityReceived = 0;
                                    oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
                                    var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                    oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                    oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                    oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                    oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                    oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                    oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                    oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                                }
                            }
                        }
                    }
                }

                for (int i = vans.Count - 1; i >= 0; i -= 1)
                {
                    if (((DataTable)((ArrayList)vans[i])[1]).Rows.Count == 0)
                    {
                        vans.RemoveAt(i);
                    }
                    else
                    {
                        // COUNT SUPPLIER
                        var suppliers = new ArrayList();
                        foreach (DataRow drItm in ((DataTable)((ArrayList)vans[i])[1]).Rows)
                        {
                            if (!(Conversions.ToInteger(drItm["SupplierID"]) == 0))
                            {
                                if (suppliers.Contains(Conversions.ToInteger(drItm["SupplierID"])) == false)
                                {
                                    suppliers.Add(Conversions.ToInteger(drItm["SupplierID"]));
                                }
                            }
                        }

                        // FOR EACH SUPPLIER
                        for (int j = 0, loopTo4 = suppliers.Count - 1; j <= loopTo4; j++)
                        {
                            var oOrder = new Entity.Orders.Order();
                            oOrder.IgnoreExceptionsOnSetMethods = true;
                            oOrder.DatePlaced = DateAndTime.Now;
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.StockProfile);
                            oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.StockProfile); // "REP : " & CType(vans.Item(i), ArrayList).Item(2) & ":" & suppliers(j)
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            oOrder.DeliveryDeadline = default;
                            oOrder = App.DB.Order.Insert(oOrder);
                            orderCreated += 1;
                            var oOrderLocation = new Entity.OrderLocations.OrderLocation();
                            oOrderLocation.SetOrderID = oOrder.OrderID;
                            oOrderLocation.SetLocationID = App.DB.Van.Van_GetDV(Conversions.ToInteger(((ArrayList)vans[i])[0])).Table.Rows[0]["LocationID"];
                            oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                            var drSelect = ((DataTable)((ArrayList)vans[i])[1]).Select("SupplierID='" + Conversions.ToInteger(suppliers[j]) + "'");
                            for (int k = 0, loopTo5 = drSelect.Length - 1; k <= loopTo5; k++)
                            {
                                var row = drSelect[k];
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                {
                                    var oOrderPart = new Entity.OrderParts.OrderPart();
                                    oOrderPart.IgnoreExceptionsOnSetMethods = true;
                                    oOrderPart.SetOrderID = oOrder.OrderID;
                                    oOrderPart.SetPartSupplierID = row["PartSupplierID"];
                                    oOrderPart.SetQuantity = row["Quantity"];
                                    oOrderPart.SetBuyPrice = row["BuyPrice"];
                                    oOrderPart.SetSellPrice = 0.0;
                                    oOrderPart.SetQuantityReceived = 0;
                                    App.DB.OrderPart.Insert(oOrderPart, !oOrder.DoNotConsolidated);
                                }
                            }
                        }

                        // COUNT LOCATIONS
                        var locations = new ArrayList();
                        foreach (DataRow drItm in ((DataTable)((ArrayList)vans[i])[1]).Rows)
                        {
                            if (!(Conversions.ToInteger(drItm["LocationID"]) == 0))
                            {
                                if (locations.Contains(Conversions.ToInteger(drItm["LocationID"])) == false)
                                {
                                    locations.Add(Conversions.ToInteger(drItm["LocationID"]));
                                }
                            }
                        }

                        // FOR EACH LOCATION
                        for (int j = 0, loopTo6 = locations.Count - 1; j <= loopTo6; j++)
                        {
                            var oOrder = new Entity.Orders.Order();
                            oOrder.IgnoreExceptionsOnSetMethods = true;
                            oOrder.DatePlaced = DateAndTime.Now;
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.StockProfile);
                            oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.StockProfile); // "REP : " & CType(vans.Item(i), ArrayList).Item(2) & ":" & locations(j)
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            oOrder.DeliveryDeadline = default;
                            oOrder = App.DB.Order.Insert(oOrder);
                            orderCreated += 1;
                            var oOrderLocation = new Entity.OrderLocations.OrderLocation();
                            oOrderLocation.SetOrderID = oOrder.OrderID;
                            oOrderLocation.SetLocationID = App.DB.Van.Van_GetDV(Conversions.ToInteger(((ArrayList)vans[i])[0])).Table.Rows[0]["LocationID"];
                            oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                            var drSelect = ((DataTable)((ArrayList)vans[i])[1]).Select("LocationID='" + Conversions.ToInteger(locations[j]) + "'");
                            for (int k = 0, loopTo7 = drSelect.Length - 1; k <= loopTo7; k++)
                            {
                                var row = drSelect[k];
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                                {
                                    var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                    oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                                    oOrderLocationPart.SetOrderID = oOrder.OrderID;
                                    oOrderLocationPart.SetPartID = row["PartID"];
                                    oOrderLocationPart.SetLocationID = row["LocationID"];
                                    oOrderLocationPart.SetQuantity = row["Quantity"];
                                    oOrderLocationPart.SetSellPrice = 0.0;
                                    oOrderLocationPart.SetQuantityReceived = 0;
                                    oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
                                    var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                    oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                    oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                    oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                    oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                    oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                    oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                    oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                                }
                            }
                        }
                    }
                }

                App.ShowMessage(orderCreated + " orders created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (orderCreated > 0)
                {
                    Filter();
                }
            }
        }
    }
}