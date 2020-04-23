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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMStockReplenishment() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Button btnToMinimum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnToMinimum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnToMinimum != null)
                {
                    _btnToMinimum.Click -= btnToMinimum_Click;
                }

                _btnToMinimum = value;
                if (_btnToMinimum != null)
                {
                    _btnToMinimum.Click += btnToMinimum_Click;
                }
            }
        }

        private Button _btnToRecommended;

        internal Button btnToRecommended
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnToRecommended;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnToRecommended != null)
                {
                    _btnToRecommended.Click -= btnToRecommended_Click;
                }

                _btnToRecommended = value;
                if (_btnToRecommended != null)
                {
                    _btnToRecommended.Click += btnToRecommended_Click;
                }
            }
        }

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

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private Panel _Panel3;

        internal Panel Panel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel3 != null)
                {
                }

                _Panel3 = value;
                if (_Panel3 != null)
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

        internal Panel Panel4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel4 != null)
                {
                }

                _Panel4 = value;
                if (_Panel4 != null)
                {
                }
            }
        }

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

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox3;

        internal GroupBox GroupBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox3 != null)
                {
                }

                _GroupBox3 = value;
                if (_GroupBox3 != null)
                {
                }
            }
        }

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

        internal Button btnRunFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRunFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRunFilter != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnRunFilter.Click -= btnRunFilter_Click;
                }

                _btnRunFilter = value;
                if (_btnRunFilter != null)
                {
                    _btnRunFilter.Click += btnRunFilter_Click;
                }
            }
        }

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
            _GroupBox1 = new GroupBox();
            _dgStockReplenishment = new DataGrid();
            _dgStockReplenishment.MouseUp += new MouseEventHandler(dgStockReplenishment_MouseUp);
            _btnToMinimum = new Button();
            _btnToMinimum.Click += new EventHandler(btnToMinimum_Click);
            _btnToRecommended = new Button();
            _btnToRecommended.Click += new EventHandler(btnToRecommended_Click);
            _chkRecommended = new CheckBox();
            _chkMinimum = new CheckBox();
            _lblNumberOfItems = new Label();
            _Label2 = new Label();
            _Panel1 = new Panel();
            _Panel2 = new Panel();
            _Panel3 = new Panel();
            _Label3 = new Label();
            _Label4 = new Label();
            _Panel4 = new Panel();
            _Label5 = new Label();
            _GroupBox2 = new GroupBox();
            _btnRunFilter = new Button();
            _btnRunFilter.Click += new EventHandler(btnRunFilter_Click);
            _chkIncludeVans = new CheckBox();
            _txtItem = new TextBox();
            _txtLocation = new TextBox();
            _Label6 = new Label();
            _Label8 = new Label();
            _GroupBox3 = new GroupBox();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgStockReplenishment).BeginInit();
            _GroupBox2.SuspendLayout();
            _GroupBox3.SuspendLayout();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgStockReplenishment);
            _GroupBox1.Location = new Point(8, 204);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(992, 488);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Tick those combinations you wish to update";
            //
            // dgStockReplenishment
            //
            _dgStockReplenishment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgStockReplenishment.DataMember = "";
            _dgStockReplenishment.HeaderForeColor = SystemColors.ControlText;
            _dgStockReplenishment.Location = new Point(8, 25);
            _dgStockReplenishment.Name = "dgStockReplenishment";
            _dgStockReplenishment.Size = new Size(976, 455);
            _dgStockReplenishment.TabIndex = 7;
            //
            // btnToMinimum
            //
            _btnToMinimum.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnToMinimum.Location = new Point(432, 700);
            _btnToMinimum.Name = "btnToMinimum";
            _btnToMinimum.Size = new Size(280, 23);
            _btnToMinimum.TabIndex = 3;
            _btnToMinimum.Text = "Bring amounts up to minimum quantities";
            //
            // btnToRecommended
            //
            _btnToRecommended.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnToRecommended.Location = new Point(720, 700);
            _btnToRecommended.Name = "btnToRecommended";
            _btnToRecommended.Size = new Size(280, 23);
            _btnToRecommended.TabIndex = 4;
            _btnToRecommended.Text = "Bring amounts up to maximum quantities";
            //
            // chkRecommended
            //
            _chkRecommended.Location = new Point(10, 76);
            _chkRecommended.Name = "chkRecommended";
            _chkRecommended.Size = new Size(271, 24);
            _chkRecommended.TabIndex = 2;
            _chkRecommended.Text = "Items where amount is below maximum";
            //
            // chkMinimum
            //
            _chkMinimum.Checked = true;
            _chkMinimum.CheckState = CheckState.Checked;
            _chkMinimum.Location = new Point(10, 103);
            _chkMinimum.Name = "chkMinimum";
            _chkMinimum.Size = new Size(256, 24);
            _chkMinimum.TabIndex = 3;
            _chkMinimum.Text = "Items where amount is below minimum";
            //
            // lblNumberOfItems
            //
            _lblNumberOfItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblNumberOfItems.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblNumberOfItems.Font = new Font("Verdana", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblNumberOfItems.Location = new Point(85, 700);
            _lblNumberOfItems.Name = "lblNumberOfItems";
            _lblNumberOfItems.Size = new Size(341, 24);
            _lblNumberOfItems.TabIndex = 7;
            _lblNumberOfItems.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Label2
            //
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(32, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(425, 16);
            _Label2.TabIndex = 9;
            _Label2.Text = "Amount ABOVE or EQUAL to both minimum and the maximum quantities";
            //
            // Panel1
            //
            _Panel1.BackColor = Color.Yellow;
            _Panel1.Location = new Point(8, 54);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(16, 16);
            _Panel1.TabIndex = 10;
            //
            // Panel2
            //
            _Panel2.BackColor = Color.Salmon;
            _Panel2.Location = new Point(8, 82);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(16, 16);
            _Panel2.TabIndex = 11;
            //
            // Panel3
            //
            _Panel3.BackColor = Color.LightGreen;
            _Panel3.Location = new Point(8, 24);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(16, 16);
            _Panel3.TabIndex = 12;
            //
            // Label3
            //
            _Label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(32, 54);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(425, 16);
            _Label3.TabIndex = 13;
            _Label3.Text = "Amount ABOVE or EQUAL to minimum but BELOW maximum quantities";
            //
            // Label4
            //
            _Label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(32, 82);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(376, 16);
            _Label4.TabIndex = 14;
            _Label4.Text = "Amount BELOW both minimum and the maximum quantities";
            //
            // Panel4
            //
            _Panel4.BackColor = Color.LightBlue;
            _Panel4.Location = new Point(8, 109);
            _Panel4.Name = "Panel4";
            _Panel4.Size = new Size(16, 16);
            _Panel4.TabIndex = 15;
            //
            // Label5
            //
            _Label5.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label5.Location = new Point(32, 109);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(376, 16);
            _Label5.TabIndex = 16;
            _Label5.Text = "A quantity is on order to replenish stock";
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_btnRunFilter);
            _GroupBox2.Controls.Add(_chkIncludeVans);
            _GroupBox2.Controls.Add(_txtItem);
            _GroupBox2.Controls.Add(_txtLocation);
            _GroupBox2.Controls.Add(_Label6);
            _GroupBox2.Controls.Add(_Label8);
            _GroupBox2.Controls.Add(_chkRecommended);
            _GroupBox2.Controls.Add(_chkMinimum);
            _GroupBox2.Location = new Point(8, 40);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(479, 158);
            _GroupBox2.TabIndex = 0;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Filters";
            //
            // btnRunFilter
            //
            _btnRunFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRunFilter.Location = new Point(388, 128);
            _btnRunFilter.Name = "btnRunFilter";
            _btnRunFilter.Size = new Size(85, 23);
            _btnRunFilter.TabIndex = 12;
            _btnRunFilter.Text = "Filter";
            _btnRunFilter.UseVisualStyleBackColor = true;
            //
            // chkIncludeVans
            //
            _chkIncludeVans.Location = new Point(10, 128);
            _chkIncludeVans.Name = "chkIncludeVans";
            _chkIncludeVans.Size = new Size(256, 24);
            _chkIncludeVans.TabIndex = 11;
            _chkIncludeVans.Text = "Include Vans";
            //
            // txtItem
            //
            _txtItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtItem.Location = new Point(80, 49);
            _txtItem.Name = "txtItem";
            _txtItem.Size = new Size(393, 21);
            _txtItem.TabIndex = 1;
            //
            // txtLocation
            //
            _txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtLocation.Location = new Point(80, 21);
            _txtLocation.Name = "txtLocation";
            _txtLocation.Size = new Size(393, 21);
            _txtLocation.TabIndex = 0;
            //
            // Label6
            //
            _Label6.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label6.Location = new Point(10, 49);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 23);
            _Label6.TabIndex = 10;
            _Label6.Text = "Item";
            //
            // Label8
            //
            _Label8.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label8.Location = new Point(10, 23);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(88, 23);
            _Label8.TabIndex = 7;
            _Label8.Text = "Location";
            //
            // GroupBox3
            //
            _GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _GroupBox3.Controls.Add(_Panel1);
            _GroupBox3.Controls.Add(_Panel3);
            _GroupBox3.Controls.Add(_Panel4);
            _GroupBox3.Controls.Add(_Panel2);
            _GroupBox3.Controls.Add(_Label2);
            _GroupBox3.Controls.Add(_Label3);
            _GroupBox3.Controls.Add(_Label4);
            _GroupBox3.Controls.Add(_Label5);
            _GroupBox3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _GroupBox3.Location = new Point(493, 40);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(507, 158);
            _GroupBox3.TabIndex = 1;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "KEY";
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(8, 700);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(64, 23);
            _btnClose.TabIndex = 5;
            _btnClose.Text = "Close";
            //
            // FRMStockReplenishment
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1008, 730);
            Controls.Add(_btnClose);
            Controls.Add(_GroupBox3);
            Controls.Add(_GroupBox2);
            Controls.Add(_lblNumberOfItems);
            Controls.Add(_btnToRecommended);
            Controls.Add(_btnToMinimum);
            Controls.Add(_GroupBox1);
            MinimumSize = new Size(832, 544);
            Name = "FRMStockReplenishment";
            Text = "Stock Replenishment";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnToMinimum, 0);
            Controls.SetChildIndex(_btnToRecommended, 0);
            Controls.SetChildIndex(_lblNumberOfItems, 0);
            Controls.SetChildIndex(_GroupBox2, 0);
            Controls.SetChildIndex(_GroupBox3, 0);
            Controls.SetChildIndex(_btnClose, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgStockReplenishment).EndInit();
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
            _GroupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
                    quantityNeeded = Conversions.ToInteger(Math.Ceiling(((int)row["MinimumQuantity"] - (double)row["Amount"] - (int)row["PacksOnOrder"]) / QuantityInPack));
                }
                else if ((MinimumOrRecommended ?? "") == "RecommendedQuantity")
                {
                    quantityNeeded = Conversions.ToInteger(Math.Ceiling(((int)row["RecommendedQuantity"] - (double)row["Amount"] - (int)row["PacksOnOrder"]) / QuantityInPack));
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}