using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FrmDisplayEngineers : FRMBaseForm, IForm
    {
        public FrmDisplayEngineers() : base()
        {
            base.Load += FrmDisplayEngineers_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            var argc = cboEngineerGroup;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup, true).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboRegionID;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, true).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            if (App.IsGasway)
            {
                lblQualification.Text = "Qualifications";
            }
            else if (App.IsRFT)
            {
                lblQualification.Text = "Trades";
            }
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
        private GroupBox _grpMain;

        internal GroupBox grpMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpMain != null)
                {
                }

                _grpMain = value;
                if (_grpMain != null)
                {
                }
            }
        }

        private DataGrid _dgEngineers;

        internal DataGrid dgEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click -= dgEngineers_Click;
                    _dgEngineers.MouseDoubleClick -= dgEngineers_MouseDoubleClick;
                }

                _dgEngineers = value;
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click += dgEngineers_Click;
                    _dgEngineers.MouseDoubleClick += dgEngineers_MouseDoubleClick;
                }
            }
        }

        private Button _btnClearAll;

        private Button _btnSelectAll;

        private ComboBox _cboEngineerGroup;

        internal ComboBox cboEngineerGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineerGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineerGroup != null)
                {
                    _cboEngineerGroup.SelectedIndexChanged -= cboEngineerGroup_SelectedIndexChanged;
                }

                _cboEngineerGroup = value;
                if (_cboEngineerGroup != null)
                {
                    _cboEngineerGroup.SelectedIndexChanged += cboEngineerGroup_SelectedIndexChanged;
                }
            }
        }

        private Label _Label24;

        private Label _lblEngineerName;

        internal Label lblEngineerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerName != null)
                {
                }

                _lblEngineerName = value;
                if (_lblEngineerName != null)
                {
                }
            }
        }

        private TextBox _txtNameFilter;

        internal TextBox txtNameFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNameFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNameFilter != null)
                {
                    _txtNameFilter.TextChanged -= filterChange;
                }

                _txtNameFilter = value;
                if (_txtNameFilter != null)
                {
                    _txtNameFilter.TextChanged += filterChange;
                }
            }
        }

        private ComboBox _cboRegionID;

        internal ComboBox cboRegionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegionID != null)
                {
                    _cboRegionID.SelectedIndexChanged -= filterChange;
                }

                _cboRegionID = value;
                if (_cboRegionID != null)
                {
                    _cboRegionID.SelectedIndexChanged += filterChange;
                }
            }
        }

        private Label _lblRegion;

        private TextBox _txtPostcodeFilter;

        internal TextBox txtPostcodeFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcodeFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcodeFilter != null)
                {
                    _txtPostcodeFilter.TextChanged -= filterChange;
                }

                _txtPostcodeFilter = value;
                if (_txtPostcodeFilter != null)
                {
                    _txtPostcodeFilter.TextChanged += filterChange;
                }
            }
        }

        private Label _lblPostcode;

        private Button _btnClearFilters;

        private TextBox _txtQualificationFilter;

        internal TextBox txtQualificationFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQualificationFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQualificationFilter != null)
                {
                    _txtQualificationFilter.TextChanged -= filterChange;
                }

                _txtQualificationFilter = value;
                if (_txtQualificationFilter != null)
                {
                    _txtQualificationFilter.TextChanged += filterChange;
                }
            }
        }

        private Label _lblQualification;

        internal Label lblQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualification != null)
                {
                }

                _lblQualification = value;
                if (_lblQualification != null)
                {
                }
            }
        }

        private Button _btnOk;

        internal Button btnOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOk != null)
                {
                    _btnOk.Click -= btnOk_Click;
                }

                _btnOk = value;
                if (_btnOk != null)
                {
                    _btnOk.Click += btnOk_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpMain = new System.Windows.Forms.GroupBox();
            this._txtQualificationFilter = new System.Windows.Forms.TextBox();
            this._lblQualification = new System.Windows.Forms.Label();
            this._btnClearFilters = new System.Windows.Forms.Button();
            this._cboRegionID = new System.Windows.Forms.ComboBox();
            this._lblRegion = new System.Windows.Forms.Label();
            this._txtPostcodeFilter = new System.Windows.Forms.TextBox();
            this._lblPostcode = new System.Windows.Forms.Label();
            this._txtNameFilter = new System.Windows.Forms.TextBox();
            this._lblEngineerName = new System.Windows.Forms.Label();
            this._cboEngineerGroup = new System.Windows.Forms.ComboBox();
            this._Label24 = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnClearAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._dgEngineers = new System.Windows.Forms.DataGrid();
            this._grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpMain
            // 
            this._grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpMain.Controls.Add(this._txtQualificationFilter);
            this._grpMain.Controls.Add(this._lblQualification);
            this._grpMain.Controls.Add(this._btnClearFilters);
            this._grpMain.Controls.Add(this._cboRegionID);
            this._grpMain.Controls.Add(this._lblRegion);
            this._grpMain.Controls.Add(this._txtPostcodeFilter);
            this._grpMain.Controls.Add(this._lblPostcode);
            this._grpMain.Controls.Add(this._txtNameFilter);
            this._grpMain.Controls.Add(this._lblEngineerName);
            this._grpMain.Controls.Add(this._cboEngineerGroup);
            this._grpMain.Controls.Add(this._Label24);
            this._grpMain.Controls.Add(this._btnOk);
            this._grpMain.Controls.Add(this._btnClearAll);
            this._grpMain.Controls.Add(this._btnSelectAll);
            this._grpMain.Controls.Add(this._dgEngineers);
            this._grpMain.Font = new System.Drawing.Font("Verdana", 8F);
            this._grpMain.Location = new System.Drawing.Point(8, 12);
            this._grpMain.Name = "_grpMain";
            this._grpMain.Size = new System.Drawing.Size(661, 549);
            this._grpMain.TabIndex = 10;
            this._grpMain.TabStop = false;
            this._grpMain.Text = "Engineers to Display";
            // 
            // _txtQualificationFilter
            // 
            this._txtQualificationFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQualificationFilter.Location = new System.Drawing.Point(121, 93);
            this._txtQualificationFilter.Name = "_txtQualificationFilter";
            this._txtQualificationFilter.Size = new System.Drawing.Size(426, 20);
            this._txtQualificationFilter.TabIndex = 5;
            this._txtQualificationFilter.TextChanged += new System.EventHandler(this.filterChange);
            // 
            // _lblQualification
            // 
            this._lblQualification.Location = new System.Drawing.Point(9, 93);
            this._lblQualification.Name = "_lblQualification";
            this._lblQualification.Size = new System.Drawing.Size(93, 20);
            this._lblQualification.TabIndex = 57;
            this._lblQualification.Text = "Qualification";
            // 
            // _btnClearFilters
            // 
            this._btnClearFilters.Location = new System.Drawing.Point(553, 93);
            this._btnClearFilters.Name = "_btnClearFilters";
            this._btnClearFilters.Size = new System.Drawing.Size(99, 23);
            this._btnClearFilters.TabIndex = 6;
            this._btnClearFilters.Text = "Clear Filters";
            this._btnClearFilters.UseVisualStyleBackColor = true;
            this._btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // _cboRegionID
            // 
            this._cboRegionID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegionID.Location = new System.Drawing.Point(121, 62);
            this._cboRegionID.Name = "_cboRegionID";
            this._cboRegionID.Size = new System.Drawing.Size(188, 21);
            this._cboRegionID.TabIndex = 3;
            this._cboRegionID.Tag = "";
            this._cboRegionID.SelectedIndexChanged += new System.EventHandler(this.filterChange);
            // 
            // _lblRegion
            // 
            this._lblRegion.Location = new System.Drawing.Point(9, 64);
            this._lblRegion.Name = "_lblRegion";
            this._lblRegion.Size = new System.Drawing.Size(105, 20);
            this._lblRegion.TabIndex = 54;
            this._lblRegion.Text = "Region";
            // 
            // _txtPostcodeFilter
            // 
            this._txtPostcodeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPostcodeFilter.Location = new System.Drawing.Point(433, 62);
            this._txtPostcodeFilter.Name = "_txtPostcodeFilter";
            this._txtPostcodeFilter.Size = new System.Drawing.Size(219, 20);
            this._txtPostcodeFilter.TabIndex = 4;
            this._txtPostcodeFilter.TextChanged += new System.EventHandler(this.filterChange);
            // 
            // _lblPostcode
            // 
            this._lblPostcode.Location = new System.Drawing.Point(327, 62);
            this._lblPostcode.Name = "_lblPostcode";
            this._lblPostcode.Size = new System.Drawing.Size(93, 20);
            this._lblPostcode.TabIndex = 52;
            this._lblPostcode.Text = "Postcode";
            // 
            // _txtNameFilter
            // 
            this._txtNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNameFilter.Location = new System.Drawing.Point(433, 34);
            this._txtNameFilter.Name = "_txtNameFilter";
            this._txtNameFilter.Size = new System.Drawing.Size(219, 20);
            this._txtNameFilter.TabIndex = 2;
            this._txtNameFilter.TextChanged += new System.EventHandler(this.filterChange);
            // 
            // _lblEngineerName
            // 
            this._lblEngineerName.Location = new System.Drawing.Point(327, 34);
            this._lblEngineerName.Name = "_lblEngineerName";
            this._lblEngineerName.Size = new System.Drawing.Size(105, 20);
            this._lblEngineerName.TabIndex = 48;
            this._lblEngineerName.Text = "Engineer Name";
            // 
            // _cboEngineerGroup
            // 
            this._cboEngineerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboEngineerGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboEngineerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboEngineerGroup.Location = new System.Drawing.Point(121, 32);
            this._cboEngineerGroup.Name = "_cboEngineerGroup";
            this._cboEngineerGroup.Size = new System.Drawing.Size(188, 21);
            this._cboEngineerGroup.TabIndex = 1;
            this._cboEngineerGroup.Tag = "";
            this._cboEngineerGroup.SelectedIndexChanged += new System.EventHandler(this.cboEngineerGroup_SelectedIndexChanged);
            // 
            // _Label24
            // 
            this._Label24.Location = new System.Drawing.Point(9, 34);
            this._Label24.Name = "_Label24";
            this._Label24.Size = new System.Drawing.Size(105, 20);
            this._Label24.TabIndex = 47;
            this._Label24.Text = "Engineer Group";
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnOk.Location = new System.Drawing.Point(588, 515);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(64, 23);
            this._btnOk.TabIndex = 9;
            this._btnOk.Text = "Ok";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // _btnClearAll
            // 
            this._btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClearAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnClearAll.Location = new System.Drawing.Point(80, 515);
            this._btnClearAll.Name = "_btnClearAll";
            this._btnClearAll.Size = new System.Drawing.Size(64, 23);
            this._btnClearAll.TabIndex = 8;
            this._btnClearAll.Text = "Clear All";
            this._btnClearAll.UseVisualStyleBackColor = true;
            this._btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSelectAll.Location = new System.Drawing.Point(10, 515);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(64, 23);
            this._btnSelectAll.TabIndex = 7;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _dgEngineers
            // 
            this._dgEngineers.DataMember = "";
            this._dgEngineers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgEngineers.Location = new System.Drawing.Point(10, 128);
            this._dgEngineers.Name = "_dgEngineers";
            this._dgEngineers.Size = new System.Drawing.Size(645, 381);
            this._dgEngineers.TabIndex = 50;
            this._dgEngineers.TabStop = false;
            this._dgEngineers.Click += new System.EventHandler(this.dgEngineers_Click);
            this._dgEngineers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgEngineers_MouseDoubleClick);
            // 
            // FrmDisplayEngineers
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(672, 562);
            this.Controls.Add(this._grpMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(688, 601);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(688, 601);
            this.Name = "FrmDisplayEngineers";
            this.Text = "Display Engineers";
            this._grpMain.ResumeLayout(false);
            this._grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).EndInit();
            this.ResumeLayout(false);

        }

        private string engineersPostcodes;
        private List<string> engineersPostcodesList;
        private string engineersQualifications;
        private List<string> engineersQualificationsList;
        private DataView _dvEngineer;

        public DataView EngineersDataView
        {
            get
            {
                return _dvEngineer;
            }

            set
            {
                _dvEngineer = value;
                if (EngineersDataView is object)
                {
                    _dvEngineer.AllowNew = false;
                    _dvEngineer.AllowEdit = true;
                    _dvEngineer.AllowDelete = false;
                    _dvEngineer.Table.TableName = "tblEngineers";
                }

                dgEngineers.DataSource = EngineersDataView;
            }
        }

        private DataRow SelectedEngineerDataRow
        {
            get
            {
                if (EngineersDataView is null)
                {
                    return null;
                }

                if (!(dgEngineers.CurrentRowIndex == -1))
                {
                    return EngineersDataView[dgEngineers.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetUpDataGrid()
        {
            SuspendLayout();
            var tsEngineers = dgEngineers.TableStyles[0];
            var include = new DataGridBoolColumn();
            include.HeaderText = "Include";
            include.MappingName = "Include";
            include.ReadOnly = false;
            include.Width = 50;
            include.AllowNull = false;
            tsEngineers.GridColumnStyles.Add(include);
            var engineerID = new DataGridLabelColumn();
            engineerID.Format = "";
            engineerID.FormatInfo = null;
            engineerID.HeaderText = "Engineer ID";
            engineerID.MappingName = "EngineerID";
            engineerID.ReadOnly = true;
            engineerID.Width = 75;
            tsEngineers.GridColumnStyles.Add(engineerID);
            var engineerName = new DataGridLabelColumn();
            engineerName.Format = "";
            engineerName.FormatInfo = null;
            engineerName.HeaderText = "Engineer Name";
            engineerName.MappingName = "Name";
            engineerName.ReadOnly = true;
            engineerName.Width = 200;
            tsEngineers.GridColumnStyles.Add(engineerName);
            var Department = new DataGridLabelColumn();
            Department.Format = "";
            Department.FormatInfo = null;
            Department.HeaderText = "Department";
            Department.MappingName = "Department";
            Department.ReadOnly = true;
            Department.Width = 80;
            tsEngineers.GridColumnStyles.Add(Department);
            var Region = new DataGridLabelColumn();
            Region.Format = "";
            Region.FormatInfo = null;
            Region.HeaderText = "Region";
            Region.MappingName = "Region";
            Region.ReadOnly = true;
            Region.Width = 200;
            tsEngineers.GridColumnStyles.Add(Region);
            tsEngineers.ReadOnly = true;
            tsEngineers.MappingName = "tblEngineers";
            dgEngineers.TableStyles.Add(tsEngineers);
        }

        private void dgEngineers_Click(object sender, EventArgs e)
        {
            if (SelectedEngineerDataRow is null)
            {
                App.ShowMessage("Please select a engineer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedEngineerDataRow["Include"] = Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedEngineerDataRow["Include"], true, false)) ? false : true;
        }

        private void dgEngineers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGrid currentDataGrid = (DataGrid)sender;
            var hitTestInfo = currentDataGrid.HitTest(e.X, e.Y);
            if (hitTestInfo.Type != DataGrid.HitTestType.ColumnHeader)
            {
                if (SelectedEngineerDataRow is object)
                {
                    var dtEngineer = SelectedEngineerDataRow.Table.Clone();
                    dtEngineer.Rows.Add(SelectedEngineerDataRow.ItemArray);
                    using (var frmViewEngineer = new FRMViewEngineer(dtEngineer))
                    {
                        frmViewEngineer.ShowDialog();
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAllTicks();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearTicks();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDisplayEngineers_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void cboEngineerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (App.IsRFT)
                {
                    Filter();
                }
                else
                {
                    ClearTicks();
                    int engineerGroupID = 0;
                    engineerGroupID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboEngineerGroup));
                    if (engineerGroupID > 0)
                    {
                        if (EngineersDataView is object)
                        {
                            if (EngineersDataView.Table is object)
                            {
                                Filter();
                                foreach (DataRow r in EngineersDataView.Table.Rows)
                                {
                                    if (Conversions.ToInteger(r["EngineerGroupID"]) == engineerGroupID)
                                    {
                                        r["Include"] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void filterChange(object sender, EventArgs e)
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    Filter();
                }
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            Reset_filters();
            ClearTicks();
        }

        private void Reset_filters()
        {
            txtPostcodeFilter.Text = "";
            txtNameFilter.Text = "";
            txtQualificationFilter.Text = "";
            var argcombo = cboEngineerGroup;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboRegionID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
        }

        private void ClearTicks()
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRow r in EngineersDataView.Table.Rows)
                        r["Include"] = false;
                }
            }
        }

        private void SelectAllTicks()
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRowView r in EngineersDataView)
                    {
                        r.BeginEdit();
                        r["Include"] = true;
                        r.EndEdit();
                    }
                }
            }
        }

        private void Populate()
        {
            engineersPostcodes = string.Join(",", (from x in EngineersDataView.Table.AsEnumerable() select x["PostCodes"]).ToArray());
            engineersPostcodesList = engineersPostcodes.ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
            engineersQualifications = string.Join(",", (from x in EngineersDataView.Table.AsEnumerable() select x["Qualifications"]).ToArray());
            engineersQualificationsList = engineersQualifications.ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
        }

        private void Filter()
        {
            if (EngineersDataView == null)
            {
                return;
            }
            string regionFilter = string.Empty;
            int regionId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboRegionID));
            if (regionId > 0)
            {
                regionFilter = " AND RegionID = " + regionId;
            }

            string postcodeFilter = string.Empty;
            var engineerIds = new List<int>();
            if (!Helper.IsStringEmpty(txtPostcodeFilter.Text))
            {
                var searchPostcodes = txtPostcodeFilter.Text.ToLower().Split(',').Select(x => x.Trim()).ToList();
                int countOfSearchPostcodes = 0;
                foreach (string postcode in searchPostcodes)
                {
                    bool match = engineersPostcodesList.Where(x => (x.ToString() ?? "") == (postcode ?? "")).Any();
                    if (match && !Helper.IsStringEmpty(postcode))
                    {
                        countOfSearchPostcodes += 1;
                    }
                }

                foreach (DataRow dr in EngineersDataView.Table.Rows)
                {
                    var postcodes = Helper.MakeStringValid(dr["PostCodes"]).ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
                    int countOfMatches = 0;
                    foreach (string postcode in searchPostcodes)
                    {
                        bool match = postcodes.Where(x => (x.ToString() ?? "") == (postcode ?? "")).Any();
                        if (match && !Helper.IsStringEmpty(postcode))
                        {
                            countOfMatches += 1;
                        }
                    }

                    if (countOfMatches > 0 && countOfMatches == countOfSearchPostcodes)
                    {
                        engineerIds.Add(Helper.MakeIntegerValid(dr["EngineerID"]));
                    }
                }

                if (engineerIds.Count > 0)
                {
                    postcodeFilter = " AND EngineerID IN (" + string.Join(",", engineerIds.ToArray()) + ")";
                }
            }

            string qualificationsFilter = string.Empty;
            var engineerQualIds = new List<int>();
            if (!Helper.IsStringEmpty(txtQualificationFilter.Text))
            {
                var searchQualifications = txtQualificationFilter.Text.ToLower().Split(',').Select(x => x.Trim()).ToList();
                int countOfSearchQualifications = 0;
                foreach (string Qualifications in searchQualifications)
                {
                    bool match = engineersQualificationsList.Where(x => (x.ToString() ?? "") == (Qualifications ?? "")).Any();
                    if (match && !Helper.IsStringEmpty(Qualifications))
                    {
                        countOfSearchQualifications += 1;
                    }
                }

                foreach (DataRow dr in EngineersDataView.Table.Rows)
                {
                    var Qualifications = Helper.MakeStringValid(dr["Qualifications"]).ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
                    int countOfMatches = 0;
                    foreach (string Qual in searchQualifications)
                    {
                        bool match = Qualifications.Where(x => (x.ToString() ?? "") == (Qual ?? "")).Any();
                        if (match && !Helper.IsStringEmpty(Qual))
                        {
                            countOfMatches += 1;
                        }
                    }

                    if (countOfMatches > 0 && countOfMatches == countOfSearchQualifications)
                    {
                        engineerQualIds.Add(Helper.MakeIntegerValid(dr["EngineerID"]));
                    }
                }

                if (engineerQualIds.Count > 0)
                {
                    qualificationsFilter = " AND EngineerID IN (" + string.Join(",", engineerQualIds.ToArray()) + ")";
                }
            }

            string engineerGroup = string.Empty;
            int engineerGroupId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboEngineerGroup));
            if (App.IsRFT | App.IsBlueflame && engineerGroupId > 0)
            {
                engineerGroup = " AND EngineerGroupID = " + Combo.get_GetSelectedItemValue(cboEngineerGroup);
            }

            string filter = "Name LIKE '%" + Helper.RemoveSpecialCharacters(txtNameFilter.Text) + "%'" + regionFilter + postcodeFilter + qualificationsFilter + engineerGroup;
            EngineersDataView.RowFilter = filter;
            grpMain.Text = "Engineers to Display (" + EngineersDataView.Count + ")";
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetUpDataGrid();
            txtNameFilter.Select();
            Populate();
        }

        public IUserControl LoadedControl { get; }

        public void ResetMe(int newID)
        {
        }
    }
}