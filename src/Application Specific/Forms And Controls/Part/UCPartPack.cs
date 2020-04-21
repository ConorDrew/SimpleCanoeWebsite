using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCPartPack : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCPartPack() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCPart_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // UserControl overrides dispose to clean up the component list.
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

        private TabPage _tabDetails;

        internal TabPage tabDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDetails != null)
                {
                }

                _tabDetails = value;
                if (_tabDetails != null)
                {
                }
            }
        }

        private GroupBox _grpPart;

        internal GroupBox grpPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPart != null)
                {
                }

                _grpPart = value;
                if (_grpPart != null)
                {
                }
            }
        }

        private Button _btnRemove;

        internal Button btnRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private DataGridView _dgvPartPack;

        internal DataGridView dgvPartPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvPartPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvPartPack != null)
                {
                }

                _dgvPartPack = value;
                if (_dgvPartPack != null)
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

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
                }
            }
        }

        private DataGridView _dgPackSuppliers;

        internal DataGridView dgPackSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPackSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPackSuppliers != null)
                {
                }

                _dgPackSuppliers = value;
                if (_dgPackSuppliers != null)
                {
                }
            }
        }

        private Label _lblPackSuppliers;

        internal Label lblPackSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPackSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPackSuppliers != null)
                {
                }

                _lblPackSuppliers = value;
                if (_lblPackSuppliers != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tabDetails = new TabPage();
            _grpPart = new GroupBox();
            _lblPackSuppliers = new Label();
            _dgPackSuppliers = new DataGridView();
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgvPartPack = new DataGridView();
            _Label2 = new Label();
            _txtName = new TextBox();
            _TabControl1 = new TabControl();
            _tabDetails.SuspendLayout();
            _grpPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPackSuppliers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgvPartPack).BeginInit();
            _TabControl1.SuspendLayout();
            SuspendLayout();
            //
            // tabDetails
            //
            _tabDetails.Controls.Add(_grpPart);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(624, 612);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            //
            // grpPart
            //
            _grpPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpPart.Controls.Add(_lblPackSuppliers);
            _grpPart.Controls.Add(_dgPackSuppliers);
            _grpPart.Controls.Add(_btnRemove);
            _grpPart.Controls.Add(_btnAdd);
            _grpPart.Controls.Add(_dgvPartPack);
            _grpPart.Controls.Add(_Label2);
            _grpPart.Controls.Add(_txtName);
            _grpPart.Location = new Point(8, 8);
            _grpPart.Name = "grpPart";
            _grpPart.Size = new Size(609, 595);
            _grpPart.TabIndex = 0;
            _grpPart.TabStop = false;
            _grpPart.Text = "Main Details";
            //
            // lblPackSuppliers
            //
            _lblPackSuppliers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPackSuppliers.Location = new Point(8, 400);
            _lblPackSuppliers.Name = "lblPackSuppliers";
            _lblPackSuppliers.Size = new Size(117, 21);
            _lblPackSuppliers.TabIndex = 63;
            _lblPackSuppliers.Text = "Pack Suppliers";
            //
            // dgPackSuppliers
            //
            _dgPackSuppliers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dgPackSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgPackSuppliers.Location = new Point(11, 424);
            _dgPackSuppliers.Name = "dgPackSuppliers";
            _dgPackSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgPackSuppliers.Size = new Size(585, 160);
            _dgPackSuppliers.TabIndex = 62;
            //
            // btnRemove
            //
            _btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemove.Location = new Point(11, 358);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(75, 23);
            _btnRemove.TabIndex = 61;
            _btnRemove.Text = "Remove";
            _btnRemove.UseVisualStyleBackColor = true;
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(521, 358);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(75, 23);
            _btnAdd.TabIndex = 60;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            //
            // dgvPartPack
            //
            _dgvPartPack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgvPartPack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvPartPack.Location = new Point(11, 64);
            _dgvPartPack.Name = "dgvPartPack";
            _dgvPartPack.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvPartPack.Size = new Size(585, 279);
            _dgvPartPack.TabIndex = 59;
            //
            // Label2
            //
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(57, 21);
            _Label2.TabIndex = 33;
            _Label2.Text = "Name";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(160, 26);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(436, 21);
            _txtName.TabIndex = 0;
            _txtName.Tag = "Part.Name";
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tabDetails);
            _TabControl1.Location = new Point(1, 5);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(632, 638);
            _TabControl1.TabIndex = 0;
            //
            // UCPartPack
            //
            Controls.Add(_TabControl1);
            Name = "UCPartPack";
            Size = new Size(640, 648);
            _tabDetails.ResumeLayout(false);
            _grpPart.ResumeLayout(false);
            _grpPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPackSuppliers).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgvPartPack).EndInit();
            _TabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPartPackDatagrid();
            SetupPackSuppliersDatagrid();
        }

        public object LoadedItem
        {
            get
            {
                return PackID;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public int PackID = 0;
        private string PartPackName;

        private DataRow DrSelectedPartPack
        {
            get
            {
                if (!(dgvPartPack.CurrentCell.RowIndex == -1))
                {
                    return PartPackDataview[dgvPartPack.CurrentCell.RowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _PartPackDataView = null;

        public DataView PartPackDataview
        {
            get
            {
                return _PartPackDataView;
            }

            set
            {
                _PartPackDataView = value;
                _PartPackDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString();
                _PartPackDataView.AllowNew = false;
                _PartPackDataView.AllowEdit = true;
                _PartPackDataView.AllowDelete = false;
                dgvPartPack.DataSource = PartPackDataview;
            }
        }

        private DataView _dvPackSuppliers = null;

        public DataView DvPackSuppliers
        {
            get
            {
                return _dvPackSuppliers;
            }

            set
            {
                _dvPackSuppliers = value;
                _dvPackSuppliers.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString();
                _dvPackSuppliers.AllowNew = false;
                _dvPackSuppliers.AllowEdit = true;
                _dvPackSuppliers.AllowDelete = false;
                dgPackSuppliers.DataSource = DvPackSuppliers;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupPartPackDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGridView(dgvPartPack);
            dgvPartPack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartPack.AutoGenerateColumns = false;
            dgvPartPack.Columns.Clear();
            dgvPartPack.EditMode = DataGridViewEditMode.EditOnEnter;
            var PartName = new DataGridViewTextBoxColumn();
            PartName.FillWeight = 70;
            PartName.HeaderText = "Part Name";
            PartName.DataPropertyName = "PartName";
            PartName.ReadOnly = true;
            PartName.Visible = true;
            PartName.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvPartPack.Columns.Add(PartName);
            var PartNumber = new DataGridViewTextBoxColumn();
            PartNumber.HeaderText = "Part Number";
            PartNumber.DataPropertyName = "PartNumber";
            PartNumber.FillWeight = 70;
            PartNumber.ReadOnly = true;
            PartNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvPartPack.Columns.Add(PartNumber);
            var Qty = new DataGridViewTextBoxColumn();
            Qty.HeaderText = "Qty";
            Qty.DataPropertyName = "Qty";
            Qty.FillWeight = 70;
            Qty.ReadOnly = true;
            Qty.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvPartPack.Columns.Add(Qty);
            dgvPartPack.Sort(PartName, System.ComponentModel.ListSortDirection.Descending);
        }

        private void SetupPackSuppliersDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGridView(dgPackSuppliers);
            dgPackSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPackSuppliers.AutoGenerateColumns = false;
            dgPackSuppliers.Columns.Clear();
            dgPackSuppliers.EditMode = DataGridViewEditMode.EditOnEnter;
            var supplier = new DataGridViewTextBoxColumn();
            supplier.HeaderText = "Supplier";
            supplier.DataPropertyName = "SupplierName";
            supplier.FillWeight = 100;
            supplier.ReadOnly = true;
            supplier.Visible = true;
            supplier.SortMode = DataGridViewColumnSortMode.Automatic;
            dgPackSuppliers.Columns.Add(supplier);
            var qtyInPack = new DataGridViewTextBoxColumn();
            qtyInPack.FillWeight = 70;
            qtyInPack.HeaderText = "Qty Of Parts In Pack";
            qtyInPack.DataPropertyName = "QuantityOfPartsInPack";
            qtyInPack.ReadOnly = true;
            qtyInPack.Visible = true;
            qtyInPack.SortMode = DataGridViewColumnSortMode.Automatic;
            dgPackSuppliers.Columns.Add(qtyInPack);
            var cost = new DataGridViewTextBoxColumn();
            cost.HeaderText = "Cost";
            cost.DataPropertyName = "Price";
            cost.FillWeight = 70;
            cost.ReadOnly = true;
            cost.SortMode = DataGridViewColumnSortMode.Automatic;
            dgPackSuppliers.Columns.Add(cost);
            dgPackSuppliers.Sort(qtyInPack, System.ComponentModel.ListSortDirection.Descending);
        }

        private void UCPart_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            PackID = ID;
            PartPackName = Conversions.ToString(App.DB.ExecuteScalar("Select PackName From tblPartPack where PackID  = " + PackID));
            txtName.Text = PartPackName;
            PartPackDataview = App.DB.Part.PartPack_Get(PackID);
            DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(PackID);
        }

        public bool Save()
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    App.ShowMessage("Enter a Pack Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }

                bool PerformSave = false;
                bool isNameUnique = true;
                bool isNewPack = false;
                var dvCurrentPartPacks = App.DB.Part.PartPack_GetAll();
                if (dvCurrentPartPacks.Count > 0 && PackID == 0)
                {
                    var partPacks = dvCurrentPartPacks.Table.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("PackName")).ToList();
                    isNameUnique = !partPacks.Contains(txtName.Text.Trim());
                }

                if (!isNameUnique)
                {
                    string msg = "A pack with this name already exists";
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.EditParts) == true | App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.CreateParts) == true)
                {
                    PerformSave = true;
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                    return false;
                }

                if (PerformSave)
                {
                    if (PartPackDataview is object && PartPackDataview.Count > 0)
                    {
                        if (PackID == 0)
                        {
                            PackID = Conversions.ToInteger(Helper.MakeIntegerValid(App.DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack")) + 1);
                            isNewPack = true;
                        }

                        PartPackName = txtName.Text;
                        App.DB.ExecuteScalar("Delete from tblPartPAck WHERE PackID = " + PackID);
                        foreach (DataRow dr in PartPackDataview.Table.Rows)
                            App.DB.ExecuteScalar(Conversions.ToString(Conversions.ToString("INSERT INTO tblPartPack (PackName,PackID,Qty,PartID) VALUES ('" + txtName.Text + "'," + PackID + "," + dr["qty"] + ",") + dr["PartID"] + ")"));
                        string msg = "Save successful";
                        App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecordsChanged?.Invoke(App.DB.Part.PartPack_GetAll(), Entity.Sys.Enums.PageViewing.PartPack, true, false, "");
                        StateChanged?.Invoke(PackID);
                        App.MainForm.RefreshEntity(PackID, "PackID");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRMFindPart dialogue1;
            dialogue1 = (FRMFindPart)App.checkIfExists(typeof(FRMFindPart).Name, true);
            if (dialogue1 is null)
            {
                dialogue1 = (FRMFindPart)Activator.CreateInstance(typeof(FRMFindPart));
            }

            dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.tblPart;
            dialogue1.ShowInTaskbar = false;
            dialogue1.ShowDialog();
            DataRow[] datarows = null;
            if (dialogue1.DialogResult == DialogResult.OK)
            {
                datarows = dialogue1.Datarows;
                if (Save())
                {
                    if (PackID == 0)
                    {
                        PartPackName = txtName.Text;
                        PackID = Conversions.ToInteger(Helper.MakeIntegerValid(App.DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack")) + 1);
                    }

                    foreach (DataRow dr in datarows)
                        App.DB.ExecuteScalar(Conversions.ToString(Conversions.ToString("INSERT INTO tblPartPack (PackName,PackID,PartID,Qty) VALUES ('" + PartPackName + "'," + PackID + "," + dr["PartID"] + ",") + dr["Qty"] + " )"));
                    PartPackDataview = App.DB.Part.PartPack_Get(PackID);
                    DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(PackID);
                }
            }
            else
            {
                return;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (DrSelectedPartPack is null)
            {
                return;
            }

            int partPackId = Conversions.ToInteger(DrSelectedPartPack["PartPackID"]);
            if (partPackId > 0)
            {
                App.DB.ExecuteScalar("Delete From tblpartPack where PartPackID = " + partPackId);
                PartPackDataview = App.DB.Part.PartPack_Get(PackID);
                DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(PackID);
            }
        }
    }
}