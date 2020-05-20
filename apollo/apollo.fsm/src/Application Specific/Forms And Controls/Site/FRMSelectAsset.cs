using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSelectAsset : FRMBaseForm, IForm
    {
        public FRMSelectAsset() : base()
        {
            base.Load += FRMChooseAsset_Load;

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

        private DataGrid _dgAssets;

        internal DataGrid dgAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssets != null)
                {
                    _dgAssets.DoubleClick -= dgAssets_DoubleClick;
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                    _dgAssets.DoubleClick += dgAssets_DoubleClick;
                }
            }
        }

        private CheckBox _chkCERT2;

        internal CheckBox chkCERT2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCERT2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCERT2 != null)
                {
                }

                _chkCERT2 = value;
                if (_chkCERT2 != null)
                {
                }
            }
        }

        private Button _btnNoAsset;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._Label1 = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._dgAssets = new System.Windows.Forms.DataGrid();
            this._btnNoAsset = new System.Windows.Forms.Button();
            this._chkCERT2 = new System.Windows.Forms.CheckBox();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgAssets)).BeginInit();
            this.SuspendLayout();
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(16, 13);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(320, 39);
            this._Label1.TabIndex = 2;
            this._Label1.Text = "Please select an Appliance to be serviced";
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(480, 312);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dgAssets);
            this._GroupBox1.Location = new System.Drawing.Point(8, 37);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(544, 270);
            this._GroupBox1.TabIndex = 5;
            this._GroupBox1.TabStop = false;
            // 
            // _dgAssets
            // 
            this._dgAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgAssets.DataMember = "";
            this._dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAssets.Location = new System.Drawing.Point(8, 18);
            this._dgAssets.Name = "_dgAssets";
            this._dgAssets.Size = new System.Drawing.Size(528, 244);
            this._dgAssets.TabIndex = 0;
            this._dgAssets.DoubleClick += new System.EventHandler(this.dgAssets_DoubleClick);
            // 
            // _btnNoAsset
            // 
            this._btnNoAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnNoAsset.Location = new System.Drawing.Point(8, 312);
            this._btnNoAsset.Name = "_btnNoAsset";
            this._btnNoAsset.Size = new System.Drawing.Size(94, 23);
            this._btnNoAsset.TabIndex = 6;
            this._btnNoAsset.Text = "No Appliance";
            this._btnNoAsset.Visible = false;
            this._btnNoAsset.Click += new System.EventHandler(this.btnNoAsset_Click);
            // 
            // _chkCERT2
            // 
            this._chkCERT2.AutoSize = true;
            this._chkCERT2.Checked = true;
            this._chkCERT2.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkCERT2.Location = new System.Drawing.Point(229, 316);
            this._chkCERT2.Name = "_chkCERT2";
            this._chkCERT2.Size = new System.Drawing.Size(91, 17);
            this._chkCERT2.TabIndex = 7;
            this._chkCERT2.Text = "Certificate?";
            this._chkCERT2.UseVisualStyleBackColor = true;
            // 
            // FRMSelectAsset
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(560, 342);
            this.ControlBox = false;
            this.Controls.Add(this._chkCERT2);
            this.Controls.Add(this._btnNoAsset);
            this.Controls.Add(this._GroupBox1);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._Label1);
            this.MinimumSize = new System.Drawing.Size(568, 376);
            this.Name = "FRMSelectAsset";
            this.Text = "Select an Appliance";
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgAssets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupAssetDataGrid();
            AssetsDataview = App.DB.Asset.Asset_GetForSite(SiteID);
            AssetsDataview.AllowNew = true;
            var newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Boiler - Unknown";
            newrow["AssetID"] = 2;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Storage Boiler - Unknown";
            newrow["AssetID"] = 3;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Oil Boiler - Unknown";
            newrow["AssetID"] = 4;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Gas Fire - Unknown";
            newrow["AssetID"] = 5;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Unit Heater - Unknown";
            newrow["AssetID"] = 6;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Large Unit Heater - Unknown";
            newrow["AssetID"] = 7;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Water Heater - Unknown";
            newrow["AssetID"] = 8;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Unvented Cylinder - Unknown";
            newrow["AssetID"] = 9;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Unvented Cylinder - Unknown";
            newrow["AssetID"] = 9;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Cooker - Unknown";
            newrow["AssetID"] = 10;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Hob - Unknown";
            newrow["AssetID"] = 11;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Warm Air Unit - Unknown";
            newrow["AssetID"] = 12;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Air Source - Unknown";
            newrow["AssetID"] = 13;
            newrow.EndEdit();
            newrow = AssetsDataview.AddNew();
            newrow["Product"] = "Range Cooker - Unknown";
            newrow["AssetID"] = 14;
            newrow.EndEdit();
            dgAssets.DataSource = AssetsDataview;
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

        private int _SiteID;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        private DataView _dvAssets;

        private DataView AssetsDataview
        {
            get
            {
                return _dvAssets;
            }

            set
            {
                _dvAssets = value;
                _dvAssets.AllowNew = false;
                _dvAssets.AllowEdit = false;
                _dvAssets.AllowDelete = false;
                _dvAssets.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
                dgAssets.DataSource = AssetsDataview;
            }
        }

        public DataRow SelectedAssetDataRow
        {
            get
            {
                if (!(dgAssets.CurrentRowIndex == -1))
                {
                    return AssetsDataview[dgAssets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupAssetDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var AssetID = new DataGridLabelColumn();
            AssetID.Format = "";
            AssetID.FormatInfo = null;
            AssetID.HeaderText = "AssetID";
            AssetID.MappingName = "AssetID";
            AssetID.ReadOnly = true;
            AssetID.Width = 0;
            AssetID.NullText = "";
            tStyle.GridColumnStyles.Add(AssetID);
            var AssetDescription = new DataGridLabelColumn();
            AssetDescription.Format = "";
            AssetDescription.FormatInfo = null;
            AssetDescription.HeaderText = "Product";
            AssetDescription.MappingName = "Product";
            AssetDescription.ReadOnly = true;
            AssetDescription.Width = 250;
            AssetDescription.NullText = "";
            tStyle.GridColumnStyles.Add(AssetDescription);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);

            // Dim SerialNumber As New DataGridLabelColumn
            // SerialNumber.Format = ""
            // SerialNumber.FormatInfo = Nothing
            // SerialNumber.HeaderText = "SerialNumber"
            // SerialNumber.MappingName = "SerialNum"
            // SerialNumber.ReadOnly = True
            // SerialNumber.Width = 120
            // SerialNumber.NullText = ""
            // tStyle.GridColumnStyles.Add(SerialNumber)

            // Dim BoughtFrom As New DataGridLabelColumn
            // BoughtFrom.Format = ""
            // BoughtFrom.FormatInfo = Nothing
            // BoughtFrom.HeaderText = "Bought From"
            // BoughtFrom.MappingName = "BoughtFrom"
            // BoughtFrom.ReadOnly = True
            // BoughtFrom.Width = 100
            // BoughtFrom.NullText = ""
            // tStyle.GridColumnStyles.Add(BoughtFrom)

            // Dim SuppliedBy As New DataGridLabelColumn
            // SuppliedBy.Format = ""
            // SuppliedBy.FormatInfo = Nothing
            // SuppliedBy.HeaderText = "Supplied By"
            // SuppliedBy.MappingName = "SuppliedBy"
            // SuppliedBy.ReadOnly = True
            // SuppliedBy.Width = 100
            // SuppliedBy.NullText = ""
            // tStyle.GridColumnStyles.Add(SuppliedBy)

            // Dim DateFitted As New DataGridLabelColumn
            // DateFitted.Format = "dd/MMM/yyyy"
            // DateFitted.FormatInfo = Nothing
            // DateFitted.HeaderText = "Date Fitted"
            // DateFitted.MappingName = "DateFitted"
            // DateFitted.ReadOnly = True
            // DateFitted.Width = 100
            // DateFitted.NullText = ""
            // tStyle.GridColumnStyles.Add(DateFitted)

            // Dim LastServicedDate As New DataGridLabelColumn
            // LastServicedDate.Format = "dd/MMM/yyyy"
            // LastServicedDate.FormatInfo = Nothing
            // LastServicedDate.HeaderText = "Last Serviced Date"
            // LastServicedDate.MappingName = "LastServicedDate"
            // LastServicedDate.ReadOnly = True
            // LastServicedDate.Width = 100
            // LastServicedDate.NullText = ""
            // tStyle.GridColumnStyles.Add(LastServicedDate)

            // Dim CertLastIssued As New DataGridLabelColumn
            // CertLastIssued.Format = "dd/MMM/yyyy"
            // CertLastIssued.FormatInfo = Nothing
            // CertLastIssued.HeaderText = "Certificate Last Issued"
            // CertLastIssued.MappingName = "CertificateLastIssued"
            // CertLastIssued.ReadOnly = True
            // CertLastIssued.Width = 100
            // CertLastIssued.NullText = ""
            // tStyle.GridColumnStyles.Add(CertLastIssued)

            // Dim Notes As New DataGridLabelColumn
            // Notes.Format = "dd/MMM/yyyy"
            // Notes.FormatInfo = Nothing
            // Notes.HeaderText = "Notes"
            // Notes.MappingName = "Notes"
            // Notes.ReadOnly = True
            // Notes.Width = 100
            // Notes.NullText = ""
            // tStyle.GridColumnStyles.Add(Notes)

            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedAssetDataRow is null)
            {
                App.ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void dgAssets_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedAssetDataRow is null)
            {
                App.ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void FRMChooseAsset_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnNoAsset_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}