﻿using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSelectAsset : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Button btnNoAsset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNoAsset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNoAsset != null)
                {
                    _btnNoAsset.Click -= btnNoAsset_Click;
                }

                _btnNoAsset = value;
                if (_btnNoAsset != null)
                {
                    _btnNoAsset.Click += btnNoAsset_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _Label1 = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1 = new GroupBox();
            _dgAssets = new DataGrid();
            _dgAssets.DoubleClick += new EventHandler(dgAssets_DoubleClick);
            _btnNoAsset = new Button();
            _btnNoAsset.Click += new EventHandler(btnNoAsset_Click);
            _chkCERT2 = new CheckBox();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            SuspendLayout();
            // 
            // Label1
            // 
            _Label1.Location = new Point(16, 40);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(320, 24);
            _Label1.TabIndex = 2;
            _Label1.Text = "Please select an Appliance to be serviced";
            // 
            // btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(480, 312);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 4;
            _btnOK.Text = "OK";
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgAssets);
            _GroupBox1.Location = new Point(8, 64);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(544, 243);
            _GroupBox1.TabIndex = 5;
            _GroupBox1.TabStop = false;
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(8, 18);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(528, 217);
            _dgAssets.TabIndex = 0;
            // 
            // btnNoAsset
            // 
            _btnNoAsset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnNoAsset.Location = new Point(8, 312);
            _btnNoAsset.Name = "btnNoAsset";
            _btnNoAsset.Size = new Size(94, 23);
            _btnNoAsset.TabIndex = 6;
            _btnNoAsset.Text = "No Appliance";
            _btnNoAsset.Visible = false;
            // 
            // chkCERT2
            // 
            _chkCERT2.AutoSize = true;
            _chkCERT2.Location = new Point(229, 316);
            _chkCERT2.Name = "chkCERT2";
            _chkCERT2.Size = new Size(91, 17);
            _chkCERT2.TabIndex = 7;
            _chkCERT2.Text = "Certificate?";
            _chkCERT2.UseVisualStyleBackColor = true;
            _chkCERT2.Checked = true;
            // 
            // FRMSelectAsset
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(560, 342);
            ControlBox = false;
            Controls.Add(_chkCERT2);
            Controls.Add(_btnNoAsset);
            Controls.Add(_GroupBox1);
            Controls.Add(_btnOK);
            Controls.Add(_Label1);
            MinimumSize = new Size(568, 376);
            Name = "FRMSelectAsset";
            Text = "Select an Appliance";
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnNoAsset, 0);
            Controls.SetChildIndex(_chkCERT2, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}