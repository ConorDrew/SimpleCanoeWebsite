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
    public class FRMDistributeAllocated : FRMBaseForm, IForm
    {
        public FRMDistributeAllocated()
        {
            
            
            base.Load += FRMDistributeAllocated_Load;
        }

        

        public FRMDistributeAllocated(bool UsedIn, int QuantityIn, string PartProductNameIn, string TypeIn, int IDIn, ArrayList AllocatedIn) : base()
        {
            base.Load += FRMDistributeAllocated_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            Used = UsedIn;
            Quantity = QuantityIn;
            PartProductName = PartProductNameIn;
            Type = TypeIn;
            ID = IDIn;
            Allocated = AllocatedIn;
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

        private GroupBox _grpOptions;

        internal GroupBox grpOptions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOptions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOptions != null)
                {
                }

                _grpOptions = value;
                if (_grpOptions != null)
                {
                }
            }
        }

        private Label _lblDetails;

        internal Label lblDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDetails != null)
                {
                }

                _lblDetails = value;
                if (_lblDetails != null)
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
                }

                _dgLocations = value;
                if (_dgLocations != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grpOptions = new System.Windows.Forms.GroupBox();
            this._dgLocations = new System.Windows.Forms.DataGrid();
            this._lblDetails = new System.Windows.Forms.Label();
            this._grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(480, 512);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 512);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _grpOptions
            // 
            this._grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpOptions.Controls.Add(this._dgLocations);
            this._grpOptions.Location = new System.Drawing.Point(8, 36);
            this._grpOptions.Name = "_grpOptions";
            this._grpOptions.Size = new System.Drawing.Size(544, 468);
            this._grpOptions.TabIndex = 7;
            this._grpOptions.TabStop = false;
            this._grpOptions.Text = "Enter amount to distribute to each location";
            // 
            // _dgLocations
            // 
            this._dgLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgLocations.DataMember = "";
            this._dgLocations.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgLocations.Location = new System.Drawing.Point(8, 24);
            this._dgLocations.Name = "_dgLocations";
            this._dgLocations.Size = new System.Drawing.Size(528, 436);
            this._dgLocations.TabIndex = 2;
            // 
            // _lblDetails
            // 
            this._lblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblDetails.Location = new System.Drawing.Point(8, 9);
            this._lblDetails.Name = "_lblDetails";
            this._lblDetails.Size = new System.Drawing.Size(544, 24);
            this._lblDetails.TabIndex = 8;
            this._lblDetails.Text = "PARTPRODUCTDETAILS";
            // 
            // FRMDistributeAllocated
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(560, 542);
            this.ControlBox = false;
            this.Controls.Add(this._lblDetails);
            this.Controls.Add(this._grpOptions);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.MinimumSize = new System.Drawing.Size(568, 576);
            this.Name = "FRMDistributeAllocated";
            this.Text = "Part / Product Manager";
            this._grpOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgLocations)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDG();
            Locations = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution2(ID);
            if (!Used)
            {
                lblDetails.Text = "You must declare where these " + Quantity + " " + PartProductName + "'s have been returned to:";
                grpOptions.Text = "Enter quantity to distribute to each location";
            }
            else
            {
                lblDetails.Text = "You must declare where you got these " + Quantity + " " + PartProductName + "'s from:";
                grpOptions.Text = "Enter quantity for each location";
            }
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

        
        
        private bool _Used;

        public bool Used
        {
            get
            {
                return _Used;
            }

            set
            {
                _Used = value;
            }
        }

        private string _PartProductName;

        public string PartProductName
        {
            get
            {
                return _PartProductName;
            }

            set
            {
                _PartProductName = value;
            }
        }

        private string _Type;

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        private int _ID;

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

        private int _Quantity;

        public int Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }

        private ArrayList _Allocated = null;

        public ArrayList Allocated
        {
            get
            {
                return _Allocated;
            }

            set
            {
                _Allocated = value;
            }
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
                if (Used)
                {
                    value.Table.AcceptChanges();
                    // Value.Table.Columns.Add(New DataColumn("Available"))
                    value.Table.Columns.Add(new DataColumn("StockTransactionType", System.Type.GetType("System.Int32")));
                    value.Table.Columns.Add(new DataColumn("OrderPartProductID", System.Type.GetType("System.Int32")));
                    foreach (DataRow row in value.Table.Rows)
                    {
                        // Try
                        row["StockTransactionType"] = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut);
                        row["OrderPartProductID"] = 0;

                        // Select Case Type
                        // Case "Part"
                        // Select Case row.Item("Location")
                        // Case "Van"
                        // row.Item("Available") = CStr(DB.PartTransaction.GetByVan(row.Item("ID")).Table.Select("PartID = " & ID)(0).Item("Amount"))
                        // Case "Warehouse"
                        // row.Item("Available") = CStr(DB.PartTransaction.GetByWarehouse(row.Item("ID")).Table.Select("PartID = " & ID)(0).Item("Amount"))
                        // End Select
                        // Case "Product"
                        // Select Case row.Item("Location")
                        // Case "Van"
                        // row.Item("Available") = CStr(DB.ProductTransaction.GetByVan(row.Item("ID")).Table.Select("ProductID = " & ID)(0).Item("Amount"))
                        // Case "Warehouse"
                        // row.Item("Available") = CStr(DB.ProductTransaction.GetByWarehouse(row.Item("ID")).Table.Select("ProductID = " & ID)(0).Item("Amount"))
                        // End Select
                        // End Select
                        // Catch ex As Exception
                        // row.Item("Available") = "Unknown"
                        // End Try
                    }

                    foreach (ArrayList allocatedItem in Allocated)
                    {
                        var AllocatedLocation = value.Table.NewRow();
                        AllocatedLocation["Location"] = "**ORDER**";
                        AllocatedLocation["Name"] = "**ORDER**";
                        AllocatedLocation["AdditionalDetails"] = "**AN ORDER ALLOCATION**";
                        AllocatedLocation["ID"] = 0;
                        AllocatedLocation["AllocatedID"] = allocatedItem[0];
                        AllocatedLocation["LocationID"] = 0;
                        AllocatedLocation["Quantity"] = 0;
                        AllocatedLocation["Available"] = allocatedItem[1];
                        AllocatedLocation["StockTransactionType"] = 0;
                        AllocatedLocation["OrderPartProductID"] = allocatedItem[2];
                        value.Table.Rows.Add(AllocatedLocation);
                    }

                    var OtherLocation = value.Table.NewRow();
                    OtherLocation["Location"] = "**OTHER**";
                    OtherLocation["Name"] = "**OTHER**";
                    OtherLocation["AdditionalDetails"] = "**OTHER**";
                    OtherLocation["ID"] = 0;
                    OtherLocation["AllocatedID"] = 0;
                    OtherLocation["LocationID"] = 0;
                    OtherLocation["Quantity"] = 0;
                    OtherLocation["Available"] = "N/A";
                    OtherLocation["StockTransactionType"] = 0;
                    OtherLocation["OrderPartProductID"] = 0;
                    value.Table.Rows.Add(OtherLocation);
                }

                _Locations = value;
                _Locations.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
                _Locations.AllowNew = false;
                _Locations.AllowEdit = true;
                _Locations.AllowDelete = false;
                dgLocations.DataSource = Locations;
            }
        }

        private DataRow SelectedLocationDataRow
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

        
        

        private void SetupDG()
        {
            var tStyle = dgLocations.TableStyles[0];
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgLocations.ReadOnly = false;
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 150;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Quantity = new DataGridTextBoxColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Qty";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = false;
            Quantity.Width = 50;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            if (Used)
            {
                var Available = new DataGridTextBoxColumn();
                Available.Format = "";
                Available.FormatInfo = null;
                Available.HeaderText = "Available";
                Available.MappingName = "Available";
                Available.ReadOnly = false;
                Available.Width = 50;
                Available.NullText = "";
                tStyle.GridColumnStyles.Add(Available);
            }

            var AdditionalDetails = new DataGridLabelColumn();
            AdditionalDetails.Format = "";
            AdditionalDetails.FormatInfo = null;
            AdditionalDetails.HeaderText = "Additional Details";
            AdditionalDetails.MappingName = "AdditionalDetails";
            AdditionalDetails.ReadOnly = true;
            AdditionalDetails.Width = 300;
            AdditionalDetails.NullText = "";
            tStyle.GridColumnStyles.Add(AdditionalDetails);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
            dgLocations.TableStyles.Add(tStyle);
        }

        private void FRMDistributeAllocated_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int totalDistributed = 0;
            foreach (DataRow row in Locations.Table.Rows)
            {
                if (Conversions.ToBoolean((int)row["Quantity"] > 0))
                {
                    totalDistributed += (int)row["Quantity"];
                }
            }

            if (totalDistributed == Quantity)
            {
                if (!Used)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    var errors = new ArrayList();
                    foreach (DataRow row in Locations.Table.Rows)
                    {
                        if (Conversions.ToBoolean((int)row["Quantity"] > 0))
                        {
                            var switchExpr = row["Available"];
                            switch (switchExpr)
                            {
                                case var @case when @case == "Unknown":
                                    {
                                        errors.Add(Conversions.ToString("Stock check could not take place for " + row["Location"] + " - ") + row["Name"]);
                                        break;
                                    }

                                case var case1 when case1 == "N/A":
                                    {
                                        errors.Add("Stock has been marked as being collected from an unknown location");
                                        break;
                                    }

                                default:
                                    {
                                        if (Conversions.ToInteger(row["Quantity"]) > Conversions.ToInteger(row["Available"]))
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Location"], "**ORDER**", false)))
                                            {
                                                App.ShowMessage("Using a quantity higher than what is allocated for an item is not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                return;
                                            }
                                            else
                                            {
                                                errors.Add(Conversions.ToString("More stock than is currently known as available is being collected from " + row["Location"] + " - ") + row["Name"] + ". This will cause negative stock amounts");
                                            }
                                        }

                                        break;
                                    }
                            }
                        }
                    }

                    if (errors.Count == 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        string str = "Please note the following:" + Constants.vbCrLf + Constants.vbCrLf;
                        foreach (string err in errors)
                            str += err + Constants.vbCrLf;
                        if (App.ShowMessage(str + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            else
            {
                App.ShowMessage("A total of " + Quantity + " need to be distributed. So far " + totalDistributed + " have been", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
    }
}