using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FrmDisplayEngineers : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Button btnClearAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click -= btnClearAll_Click;
                }

                _btnClearAll = value;
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click += btnClearAll_Click;
                }
            }
        }

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

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

        internal Label Label24
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label24;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label24 != null)
                {
                }

                _Label24 = value;
                if (_Label24 != null)
                {
                }
            }
        }

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

        internal Label lblRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegion != null)
                {
                }

                _lblRegion = value;
                if (_lblRegion != null)
                {
                }
            }
        }

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

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
                {
                }
            }
        }

        private Button _btnClearFilters;

        internal Button btnClearFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearFilters != null)
                {
                    _btnClearFilters.Click -= btnClearFilters_Click;
                }

                _btnClearFilters = value;
                if (_btnClearFilters != null)
                {
                    _btnClearFilters.Click += btnClearFilters_Click;
                }
            }
        }

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
            _grpMain = new GroupBox();
            _txtQualificationFilter = new TextBox();
            _txtQualificationFilter.TextChanged += new EventHandler(filterChange);
            _lblQualification = new Label();
            _btnClearFilters = new Button();
            _btnClearFilters.Click += new EventHandler(btnClearFilters_Click);
            _cboRegionID = new ComboBox();
            _cboRegionID.SelectedIndexChanged += new EventHandler(filterChange);
            _lblRegion = new Label();
            _txtPostcodeFilter = new TextBox();
            _txtPostcodeFilter.TextChanged += new EventHandler(filterChange);
            _lblPostcode = new Label();
            _txtNameFilter = new TextBox();
            _txtNameFilter.TextChanged += new EventHandler(filterChange);
            _lblEngineerName = new Label();
            _cboEngineerGroup = new ComboBox();
            _cboEngineerGroup.SelectedIndexChanged += new EventHandler(cboEngineerGroup_SelectedIndexChanged);
            _Label24 = new Label();
            _btnOk = new Button();
            _btnOk.Click += new EventHandler(btnOk_Click);
            _btnClearAll = new Button();
            _btnClearAll.Click += new EventHandler(btnClearAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _dgEngineers = new DataGrid();
            _dgEngineers.Click += new EventHandler(dgEngineers_Click);
            _dgEngineers.MouseDoubleClick += new MouseEventHandler(dgEngineers_MouseDoubleClick);
            _grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).BeginInit();
            SuspendLayout();
            //
            // grpMain
            //
            _grpMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpMain.Controls.Add(_txtQualificationFilter);
            _grpMain.Controls.Add(_lblQualification);
            _grpMain.Controls.Add(_btnClearFilters);
            _grpMain.Controls.Add(_cboRegionID);
            _grpMain.Controls.Add(_lblRegion);
            _grpMain.Controls.Add(_txtPostcodeFilter);
            _grpMain.Controls.Add(_lblPostcode);
            _grpMain.Controls.Add(_txtNameFilter);
            _grpMain.Controls.Add(_lblEngineerName);
            _grpMain.Controls.Add(_cboEngineerGroup);
            _grpMain.Controls.Add(_Label24);
            _grpMain.Controls.Add(_btnOk);
            _grpMain.Controls.Add(_btnClearAll);
            _grpMain.Controls.Add(_btnSelectAll);
            _grpMain.Controls.Add(_dgEngineers);
            _grpMain.Font = new Font("Verdana", 8.0F);
            _grpMain.Location = new Point(8, 32);
            _grpMain.Name = "grpMain";
            _grpMain.Size = new Size(661, 529);
            _grpMain.TabIndex = 10;
            _grpMain.TabStop = false;
            _grpMain.Text = "Engineers to Display";
            //
            // txtQualificationFilter
            //
            _txtQualificationFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQualificationFilter.Location = new Point(121, 93);
            _txtQualificationFilter.Name = "txtQualificationFilter";
            _txtQualificationFilter.Size = new Size(426, 20);
            _txtQualificationFilter.TabIndex = 5;
            //
            // lblQualification
            //
            _lblQualification.Location = new Point(9, 93);
            _lblQualification.Name = "lblQualification";
            _lblQualification.Size = new Size(93, 20);
            _lblQualification.TabIndex = 57;
            _lblQualification.Text = "Qualification";
            //
            // btnClearFilters
            //
            _btnClearFilters.Location = new Point(553, 93);
            _btnClearFilters.Name = "btnClearFilters";
            _btnClearFilters.Size = new Size(99, 23);
            _btnClearFilters.TabIndex = 6;
            _btnClearFilters.Text = "Clear Filters";
            _btnClearFilters.UseVisualStyleBackColor = true;
            //
            // cboRegionID
            //
            _cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRegionID.Cursor = Cursors.Hand;
            _cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegionID.Location = new Point(121, 62);
            _cboRegionID.Name = "cboRegionID";
            _cboRegionID.Size = new Size(188, 21);
            _cboRegionID.TabIndex = 3;
            _cboRegionID.Tag = "";
            //
            // lblRegion
            //
            _lblRegion.Location = new Point(9, 64);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(105, 20);
            _lblRegion.TabIndex = 54;
            _lblRegion.Text = "Region";
            //
            // txtPostcodeFilter
            //
            _txtPostcodeFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcodeFilter.Location = new Point(433, 62);
            _txtPostcodeFilter.Name = "txtPostcodeFilter";
            _txtPostcodeFilter.Size = new Size(219, 20);
            _txtPostcodeFilter.TabIndex = 4;
            //
            // lblPostcode
            //
            _lblPostcode.Location = new Point(327, 62);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(93, 20);
            _lblPostcode.TabIndex = 52;
            _lblPostcode.Text = "Postcode";
            //
            // txtNameFilter
            //
            _txtNameFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNameFilter.Location = new Point(433, 34);
            _txtNameFilter.Name = "txtNameFilter";
            _txtNameFilter.Size = new Size(219, 20);
            _txtNameFilter.TabIndex = 2;
            //
            // lblEngineerName
            //
            _lblEngineerName.Location = new Point(327, 34);
            _lblEngineerName.Name = "lblEngineerName";
            _lblEngineerName.Size = new Size(105, 20);
            _lblEngineerName.TabIndex = 48;
            _lblEngineerName.Text = "Engineer Name";
            //
            // cboEngineerGroup
            //
            _cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerGroup.Cursor = Cursors.Hand;
            _cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerGroup.Location = new Point(121, 32);
            _cboEngineerGroup.Name = "cboEngineerGroup";
            _cboEngineerGroup.Size = new Size(188, 21);
            _cboEngineerGroup.TabIndex = 1;
            _cboEngineerGroup.Tag = "";
            //
            // Label24
            //
            _Label24.Location = new Point(9, 34);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(105, 20);
            _Label24.TabIndex = 47;
            _Label24.Text = "Engineer Group";
            //
            // btnOk
            //
            _btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOk.Font = new Font("Verdana", 8.0F);
            _btnOk.Location = new Point(588, 495);
            _btnOk.Name = "btnOk";
            _btnOk.Size = new Size(64, 23);
            _btnOk.TabIndex = 9;
            _btnOk.Text = "Ok";
            _btnOk.UseVisualStyleBackColor = true;
            //
            // btnClearAll
            //
            _btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClearAll.Font = new Font("Verdana", 8.0F);
            _btnClearAll.Location = new Point(80, 495);
            _btnClearAll.Name = "btnClearAll";
            _btnClearAll.Size = new Size(64, 23);
            _btnClearAll.TabIndex = 8;
            _btnClearAll.Text = "Clear All";
            _btnClearAll.UseVisualStyleBackColor = true;
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Font = new Font("Verdana", 8.0F);
            _btnSelectAll.Location = new Point(10, 495);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(64, 23);
            _btnSelectAll.TabIndex = 7;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            //
            // dgEngineers
            //
            _dgEngineers.DataMember = "";
            _dgEngineers.HeaderForeColor = SystemColors.ControlText;
            _dgEngineers.Location = new Point(10, 128);
            _dgEngineers.Name = "dgEngineers";
            _dgEngineers.Size = new Size(645, 353);
            _dgEngineers.TabIndex = 50;
            _dgEngineers.TabStop = false;
            //
            // FrmDisplayEngineers
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(672, 562);
            Controls.Add(_grpMain);
            MaximizeBox = false;
            MaximumSize = new Size(688, 601);
            MinimizeBox = false;
            MinimumSize = new Size(688, 601);
            Name = "FrmDisplayEngineers";
            Text = "Display Engineers";
            Controls.SetChildIndex(_grpMain, 0);
            _grpMain.ResumeLayout(false);
            _grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
            LoadForm(this);
            SetUpDataGrid();
            txtNameFilter.Select();
            Populate();
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
            engineersPostcodes = string.Join(",", (from x in EngineersDataView.Table.AsEnumerable()
                                                   select x["PostCodes"]).ToArray());
            engineersPostcodesList = engineersPostcodes.ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
            engineersQualifications = string.Join(",", (from x in EngineersDataView.Table.AsEnumerable()
                                                        select x["Qualifications"]).ToArray());
            engineersQualificationsList = engineersQualifications.ToLower().Split(',').Select(x => x.Trim()).Distinct().ToList();
        }

        private void Filter()
        {
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}