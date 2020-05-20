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
        

        public FRMSelectLocation() : base()
        {
            
            
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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grpLocations = new System.Windows.Forms.GroupBox();
            this._dgLocations = new System.Windows.Forms.DataGrid();
            this._grpLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(856, 444);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(60, 25);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(12, 444);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 25);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _grpLocations
            // 
            this._grpLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpLocations.Controls.Add(this._dgLocations);
            this._grpLocations.Location = new System.Drawing.Point(12, 12);
            this._grpLocations.Name = "_grpLocations";
            this._grpLocations.Size = new System.Drawing.Size(904, 426);
            this._grpLocations.TabIndex = 3;
            this._grpLocations.TabStop = false;
            this._grpLocations.Text = "Select location to replenish from : {0}";
            // 
            // _dgLocations
            // 
            this._dgLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgLocations.DataMember = "";
            this._dgLocations.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgLocations.Location = new System.Drawing.Point(9, 20);
            this._dgLocations.Name = "_dgLocations";
            this._dgLocations.Size = new System.Drawing.Size(889, 400);
            this._dgLocations.TabIndex = 1;
            this._dgLocations.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgLocations_MouseUp);
            // 
            // FRMSelectLocation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 481);
            this.ControlBox = false;
            this.Controls.Add(this._grpLocations);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.MinimumSize = new System.Drawing.Size(825, 420);
            this.Name = "FRMSelectLocation";
            this.Text = "Replenish from...";
            this._grpLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgLocations)).EndInit();
            this.ResumeLayout(false);

        }

        
        

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

        
    }
}