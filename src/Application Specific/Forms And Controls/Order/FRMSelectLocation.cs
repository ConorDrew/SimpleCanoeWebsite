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
    public class FRMSelectLocation : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMSelectLocation() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSelectLocation_Load;

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
                    _btnOK.Click -= btnSave_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnSave_Click;
                }
            }
        }

        private GroupBox _grpLocations;

        internal GroupBox grpLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpLocations != null)
                {
                }

                _grpLocations = value;
                if (_grpLocations != null)
                {
                }
            }
        }

        private DataGrid _dgLocations;

        internal DataGrid dgLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgLocations != null)
                {
                    _dgLocations.MouseUp -= dgLocations_MouseUp;
                }

                _dgLocations = value;
                if (_dgLocations != null)
                {
                    _dgLocations.MouseUp += dgLocations_MouseUp;
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
                    _btnCancel.Click -= btnClose_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnClose_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnSave_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnClose_Click);
            _grpLocations = new GroupBox();
            _dgLocations = new DataGrid();
            _dgLocations.MouseUp += new MouseEventHandler(dgLocations_MouseUp);
            _grpLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgLocations).BeginInit();
            SuspendLayout();
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(856, 444);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(60, 25);
            _btnOK.TabIndex = 4;
            _btnOK.Text = "OK";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(12, 444);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 25);
            _btnCancel.TabIndex = 7;
            _btnCancel.Text = "Cancel";
            //
            // grpLocations
            //
            _grpLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpLocations.Controls.Add(_dgLocations);
            _grpLocations.Location = new Point(12, 38);
            _grpLocations.Name = "grpLocations";
            _grpLocations.Size = new Size(904, 400);
            _grpLocations.TabIndex = 3;
            _grpLocations.TabStop = false;
            _grpLocations.Text = "Select location to replenish from : {0}";
            //
            // dgLocations
            //
            _dgLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgLocations.DataMember = "";
            _dgLocations.HeaderForeColor = SystemColors.ControlText;
            _dgLocations.Location = new Point(9, 20);
            _dgLocations.Name = "dgLocations";
            _dgLocations.Size = new Size(889, 374);
            _dgLocations.TabIndex = 1;
            //
            // FRMSelectLocation
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(928, 481);
            ControlBox = false;
            Controls.Add(_grpLocations);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            MinimumSize = new Size(825, 420);
            Name = "FRMSelectLocation";
            Text = "Replenish from...";
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_grpLocations, 0);
            _grpLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgLocations).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDG();
            DataView dt;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(8), "DailyStockReplen", false)))
            {
                dt = App.DB.Part.Part_Locations_Get_For_Replenishment_Suppliers_Only(Conversions.ToInteger(get_GetParameter(0)));
            }
            else
            {
                dt = App.DB.Part.Part_Locations_Get_For_Replenishment(Conversions.ToInteger(get_GetParameter(0)));
            }

            foreach (ArrayList warehouse in (ArrayList)get_GetParameter(4))
            {
                foreach (DataRow row in ((DataTable)warehouse[1]).Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["PartID"], get_GetParameter(0), false)))
                    {
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                        {
                            foreach (DataRow location in dt.Table.Rows)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(8), "", false)))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["Type"], "Warehouse", false)))
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["ID"], row["LocationID"], false)))
                                        {
                                            location["InStock"] = Entity.Sys.Helper.MakeIntegerValid(location["InStock"]) - Entity.Sys.Helper.MakeIntegerValid(row["Quantity"]);
                                        }
                                    }
                                }
                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["Type"], "Warehouse", false)))
                                {
                                    location.Delete();
                                }
                            }
                        }
                    }
                }
            }

            foreach (ArrayList van in (ArrayList)get_GetParameter(5))
            {
                foreach (DataRow row in ((DataTable)van[1]).Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["PartID"], get_GetParameter(0), false)))
                    {
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(row["LocationID"], 0, false)))
                        {
                            foreach (DataRow location in dt.Table.Rows)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(8), "", false)))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["Type"], "Warehouse", false)))
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["ID"], row["LocationID"], false)))
                                        {
                                            location["InStock"] = Entity.Sys.Helper.MakeIntegerValid(location["InStock"]) - Entity.Sys.Helper.MakeIntegerValid(row["Quantity"]);
                                        }
                                    }
                                }
                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(location["Type"], "Warehouse", false)))
                                {
                                    location.Delete();
                                }
                            }
                        }
                    }
                }
            }

            if (!(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(7)) == 0))
            {
                foreach (DataRow row in dt.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], Entity.Sys.Helper.MakeStringValid(get_GetParameter(6)), false) & Operators.ConditionalCompareObjectEqual(row["ID"], Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(7)), false)))
                    {
                        row["Tick"] = true;
                        break;
                    }
                }
            }

            Locations = dt;
            grpLocations.Text = Conversions.ToString(Conversions.ToString(Conversions.ToString("Please select where you would like to get " + get_GetParameter(3) + " of item '") + get_GetParameter(1) + "' for location '") + get_GetParameter(2) + "' from");
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

        private void SetupDG()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgLocations);
            var tbStyle = dgLocations.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            tbStyle.ReadOnly = false;
            dgLocations.ReadOnly = false;
            tbStyle.AllowSorting = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = false;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 150;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var InStock = new DataGridLabelColumn();
            InStock.Format = "";
            InStock.FormatInfo = null;
            InStock.HeaderText = "Stock";
            InStock.MappingName = "InStock";
            InStock.ReadOnly = true;
            InStock.Width = 75;
            InStock.NullText = "";
            tbStyle.GridColumnStyles.Add(InStock);
            var InPack = new DataGridLabelColumn();
            InPack.Format = "";
            InPack.FormatInfo = null;
            InPack.HeaderText = "In Pack";
            InPack.MappingName = "InPack";
            InPack.ReadOnly = true;
            InPack.Width = 75;
            InPack.NullText = "";
            tbStyle.GridColumnStyles.Add(InPack);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 100;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
            var Deleted = new DataGridLabelColumn();
            Deleted.Format = "";
            Deleted.FormatInfo = null;
            Deleted.HeaderText = "Deleted";
            Deleted.MappingName = "Deleted";
            Deleted.ReadOnly = true;
            Deleted.Width = 100;
            Deleted.NullText = "";
            tbStyle.GridColumnStyles.Add(Deleted);
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblLocations.ToString();
            dgLocations.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _Locations = null;

        public DataView Locations
        {
            get
            {
                return _Locations;
            }

            set
            {
                _Locations = value;
                _Locations.Table.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString();
                _Locations.AllowNew = false;
                _Locations.AllowEdit = true;
                _Locations.AllowDelete = false;
                dgLocations.DataSource = Locations;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgLocations.CurrentRowIndex == -1))
                {
                    return Locations[dgLocations.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _LocationID = 0;

        public int LocationID
        {
            get
            {
                return _LocationID;
            }
        }

        private int _PartSupplierID = 0;

        public int PartSupplierID
        {
            get
            {
                return _PartSupplierID;
            }
        }

        private int _SupplierID = 0;

        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }
        }

        private int _InPack = 0;

        public int InPack
        {
            get
            {
                return _InPack;
            }
        }

        private double _Price = 0.0;

        public double Price
        {
            get
            {
                return _Price;
            }
        }

        private void FRMSelectLocation_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgLocations_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    var HitTestInfo = dgLocations.HitTest(e.X, e.Y);
                    if (Locations.Table.Rows[HitTestInfo.Row] is null)
                    {
                        return;
                    }

                    if (!((Locations.Table.Columns[HitTestInfo.Column].ColumnName.Trim().ToLower() ?? "") == ("Tick".ToLower() ?? "")))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }

                if (SelectedDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgLocations[dgLocations.CurrentRowIndex, 0]);
                dgLocations[dgLocations.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(Locations.Table.Select("Tick=1").Length == 1))
            {
                App.ShowMessage("Please ensure only one location has been selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            {
                var withBlock = Locations.Table.Select("Tick=1")[0];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock["Type"], "Warehouse", false)))
                {
                    _LocationID = Conversions.ToInteger(withBlock["ID"]);
                    _PartSupplierID = 0;
                    _SupplierID = 0;
                }
                else
                {
                    _LocationID = 0;
                    _PartSupplierID = Conversions.ToInteger(withBlock["ID"]);
                    _SupplierID = Conversions.ToInteger(withBlock["OtherID"]);
                }

                _InPack = Conversions.ToInteger(withBlock["InPack"]);
                _Price = Conversions.ToDouble(withBlock["Price"]);
            }

            DialogResult = DialogResult.OK;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}