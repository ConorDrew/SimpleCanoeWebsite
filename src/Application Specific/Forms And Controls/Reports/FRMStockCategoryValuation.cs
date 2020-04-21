using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMStockCategoryValuation : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMStockCategoryValuation() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMStockCategoryValuation_Load;

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
        private GroupBox _grpParts;

        internal GroupBox grpParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpParts != null)
                {
                }

                _grpParts = value;
                if (_grpParts != null)
                {
                }
            }
        }

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

        private DataGrid _dgParts;

        internal DataGrid dgParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick -= dgParts_DoubleClick;
                    _dgParts.MouseUp -= dgParts_MouseUp;
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick += dgParts_DoubleClick;
                    _dgParts.MouseUp += dgParts_MouseUp;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpParts = new GroupBox();
            _dgParts = new DataGrid();
            _dgParts.DoubleClick += new EventHandler(dgParts_DoubleClick);
            _dgParts.MouseUp += new MouseEventHandler(dgParts_MouseUp);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            SuspendLayout();
            //
            // grpParts
            //
            _grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpParts.Controls.Add(_dgParts);
            _grpParts.Location = new Point(8, 38);
            _grpParts.Name = "grpParts";
            _grpParts.Size = new Size(510, 260);
            _grpParts.TabIndex = 2;
            _grpParts.TabStop = false;
            _grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)";
            //
            // dgParts
            //
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(8, 19);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(494, 233);
            _dgParts.TabIndex = 14;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 306);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 3;
            _btnExport.Text = "Export";
            //
            // FRMStockCategoryValuation
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(526, 336);
            Controls.Add(_btnExport);
            Controls.Add(_grpParts);
            MinimumSize = new Size(534, 370);
            Name = "FRMStockCategoryValuation";
            Text = "Stock Category Valuation Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpParts, 0);
            Controls.SetChildIndex(_btnExport, 0);
            _grpParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            Type = Entity.Sys.Enums.TableNames.tblPickLists;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int selectedCateogryID = 0;
        private string selectedCategoryName = "";
        private Entity.Sys.Enums.TableNames _Type = Entity.Sys.Enums.TableNames.tblPickLists;

        private Entity.Sys.Enums.TableNames Type
        {
            get
            {
                return _Type;
            }

            set
            {
                try
                {
                    _Type = value;
                    Cursor.Current = Cursors.WaitCursor;
                    Enabled = false;
                    var switchExpr = Type;
                    switch (switchExpr)
                    {
                        case Entity.Sys.Enums.TableNames.tblPickLists:
                            {
                                PartsDataview = new DataView(App.DB.Part.Stock_Valuation(0, 0, 0, "", false).Tables[1]);
                                grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)";
                                break;
                            }

                        case Entity.Sys.Enums.TableNames.tblPart:
                            {
                                PartsDataview = new DataView(App.DB.Part.Stock_Valuation(selectedCateogryID, 0, 0, "", false).Tables[2]);
                                grpParts.Text = "Part replacement costs based on supplier for category : " + selectedCategoryName.Trim();
                                break;
                            }
                    }

                    SetupDataGrid();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private DataView _dvParts;

        private DataView PartsDataview
        {
            get
            {
                return _dvParts;
            }

            set
            {
                _dvParts = value;
                _dvParts.AllowNew = false;
                _dvParts.AllowEdit = false;
                _dvParts.AllowDelete = false;
                _dvParts.Table.TableName = Type.ToString();
                dgParts.DataSource = PartsDataview;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                if (!(dgParts.CurrentRowIndex == -1))
                {
                    return PartsDataview[dgParts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupDataGrid()
        {
            var tbStyle = dgParts.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            dgParts.AllowSorting = false;
            tbStyle.AllowSorting = false;
            if (Type == Entity.Sys.Enums.TableNames.tblPickLists)
            {
                var Name = new DataGridLabelColumn();
                Name.Format = "";
                Name.FormatInfo = null;
                Name.HeaderText = "Category";
                Name.MappingName = "Name";
                Name.ReadOnly = true;
                Name.Width = 200;
                Name.NullText = "";
                tbStyle.GridColumnStyles.Add(Name);
                var Description = new DataGridLabelColumn();
                Description.Format = "";
                Description.FormatInfo = null;
                Description.HeaderText = "Description";
                Description.MappingName = "Description";
                Description.ReadOnly = true;
                Description.Width = 300;
                Description.NullText = "";
                tbStyle.GridColumnStyles.Add(Description);
                var ReplacementCost = new DataGridLabelColumn();
                ReplacementCost.Format = "C";
                ReplacementCost.FormatInfo = null;
                ReplacementCost.HeaderText = "Cost";
                ReplacementCost.MappingName = "ReplacementCost";
                ReplacementCost.ReadOnly = true;
                ReplacementCost.Width = 100;
                ReplacementCost.NullText = "£0.00";
                tbStyle.GridColumnStyles.Add(ReplacementCost);
                var Undistributed = new DataGridLabelColumn();
                Undistributed.Format = "C";
                Undistributed.FormatInfo = null;
                Undistributed.HeaderText = "Undistributed";
                Undistributed.MappingName = "Undistributed";
                Undistributed.ReadOnly = true;
                Undistributed.Width = 100;
                Undistributed.NullText = "£0.00";
                tbStyle.GridColumnStyles.Add(Undistributed);
                var ClickAction = new DataGridLabelColumn();
                ClickAction.Format = "";
                ClickAction.FormatInfo = null;
                ClickAction.HeaderText = "";
                ClickAction.MappingName = "ClickAction";
                ClickAction.ReadOnly = true;
                ClickAction.Width = 100;
                ClickAction.NullText = "";
                tbStyle.GridColumnStyles.Add(ClickAction);
                tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
            }
            else if (Type == Entity.Sys.Enums.TableNames.tblPart)
            {
                var Name = new DataGridLabelColumn();
                Name.Format = "";
                Name.FormatInfo = null;
                Name.HeaderText = "Name";
                Name.MappingName = "Name";
                Name.ReadOnly = true;
                Name.Width = 150;
                Name.NullText = "";
                tbStyle.GridColumnStyles.Add(Name);
                var Number = new DataGridLabelColumn();
                Number.Format = "";
                Number.FormatInfo = null;
                Number.HeaderText = "Number";
                Number.MappingName = "Number";
                Number.ReadOnly = true;
                Number.Width = 75;
                Number.NullText = "";
                tbStyle.GridColumnStyles.Add(Number);
                var Reference = new DataGridLabelColumn();
                Reference.Format = "";
                Reference.FormatInfo = null;
                Reference.HeaderText = "Reference";
                Reference.MappingName = "Reference";
                Reference.ReadOnly = true;
                Reference.Width = 75;
                Reference.NullText = "";
                tbStyle.GridColumnStyles.Add(Reference);
                var ReplacementCost = new DataGridLabelColumn();
                ReplacementCost.Format = "C";
                ReplacementCost.FormatInfo = null;
                ReplacementCost.HeaderText = "Cost";
                ReplacementCost.MappingName = "ReplacementCost";
                ReplacementCost.ReadOnly = true;
                ReplacementCost.Width = 100;
                ReplacementCost.NullText = "£0.00";
                tbStyle.GridColumnStyles.Add(ReplacementCost);
                var Undistributed = new DataGridLabelColumn();
                Undistributed.Format = "C";
                Undistributed.FormatInfo = null;
                Undistributed.HeaderText = "Undistributed";
                Undistributed.MappingName = "Undistributed";
                Undistributed.ReadOnly = true;
                Undistributed.Width = 100;
                Undistributed.NullText = "£0.00";
                tbStyle.GridColumnStyles.Add(Undistributed);
                var Supplier = new DataGridLabelColumn();
                Supplier.Format = "";
                Supplier.FormatInfo = null;
                Supplier.HeaderText = "Supplier";
                Supplier.MappingName = "Supplier";
                Supplier.ReadOnly = true;
                Supplier.Width = 250;
                Supplier.NullText = "No Supplier";
                tbStyle.GridColumnStyles.Add(Supplier);
                var ClickAction = new DataGridLabelColumn();
                ClickAction.Format = "";
                ClickAction.FormatInfo = null;
                ClickAction.HeaderText = "";
                ClickAction.MappingName = "ClickAction";
                ClickAction.ReadOnly = true;
                ClickAction.Width = 100;
                ClickAction.NullText = "";
                tbStyle.GridColumnStyles.Add(ClickAction);
                tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            }

            tbStyle.ReadOnly = true;
            dgParts.TableStyles.Add(tbStyle);
        }

        private void FRMStockCategoryValuation_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgParts_DoubleClick(object sender, EventArgs e)
        {
            if (Type == Entity.Sys.Enums.TableNames.tblPart)
            {
                if (SelectedPartDataRow is null)
                {
                    return;
                }

                App.ShowForm(typeof(FRMPart), true, new object[] { SelectedPartDataRow["PartID"], true });
                Type = Entity.Sys.Enums.TableNames.tblPart;
            }
        }

        private void dgParts_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgParts.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgParts.CurrentRowIndex = HitTestInfo.Row;
                }

                if (HitTestInfo.Column <= 0)
                {
                    return;
                }

                if (!((dgParts.TableStyles[0].GridColumnStyles[HitTestInfo.Column].MappingName.ToLower() ?? "") == "clickaction"))
                {
                    return;
                }

                if (SelectedPartDataRow is null)
                {
                    return;
                }

                var switchExpr = Type;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.TableNames.tblPickLists:
                        {
                            selectedCategoryName = Conversions.ToString(SelectedPartDataRow["Name"]);
                            selectedCateogryID = Conversions.ToInteger(SelectedPartDataRow["CategoryID"]);
                            Type = Entity.Sys.Enums.TableNames.tblPart;
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPart:
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(SelectedPartDataRow["ClickAction"], "Back...", false)))
                            {
                                return;
                            }

                            Type = Entity.Sys.Enums.TableNames.tblPickLists;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Export()
        {
            var exportData = new DataTable();
            string reportName = "";
            var switchExpr = Type;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.tblPickLists:
                    {
                        exportData.Columns.Add("Category");
                        exportData.Columns.Add("Description");
                        exportData.Columns.Add("Cost");
                        exportData.Columns.Add("Undistributed");
                        for (int itm = 0, loopTo = ((DataView)dgParts.DataSource).Count - 1; itm <= loopTo; itm++)
                        {
                            dgParts.CurrentRowIndex = itm;
                            DataRow newRw;
                            newRw = exportData.NewRow();
                            newRw["Category"] = SelectedPartDataRow["Name"];
                            newRw["Description"] = SelectedPartDataRow["Description"];
                            newRw["Cost"] = Strings.Format(SelectedPartDataRow["ReplacementCost"], "F");
                            newRw["Undistributed"] = Strings.Format(SelectedPartDataRow["Undistributed"], "F");
                            exportData.Rows.Add(newRw);
                            dgParts.UnSelect(itm);
                        }

                        reportName = "Stock Category Value Report";
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblPart:
                    {
                        exportData.Columns.Add("Category");
                        exportData.Columns.Add("Name");
                        exportData.Columns.Add("Number");
                        exportData.Columns.Add("Reference");
                        exportData.Columns.Add("Cost");
                        exportData.Columns.Add("Undistributed");
                        exportData.Columns.Add("Supplier");
                        for (int itm = 0, loopTo1 = ((DataView)dgParts.DataSource).Count - 1; itm <= loopTo1; itm++)
                        {
                            dgParts.CurrentRowIndex = itm;
                            DataRow newRw;
                            newRw = exportData.NewRow();
                            newRw["Category"] = SelectedPartDataRow["Category"];
                            newRw["Name"] = SelectedPartDataRow["Name"];
                            newRw["Number"] = SelectedPartDataRow["Number"];
                            newRw["Reference"] = SelectedPartDataRow["Reference"];
                            newRw["Cost"] = Strings.Format(SelectedPartDataRow["ReplacementCost"], "F");
                            newRw["Undistributed"] = Strings.Format(SelectedPartDataRow["Undistributed"], "F");
                            newRw["Supplier"] = SelectedPartDataRow["Supplier"];
                            exportData.Rows.Add(newRw);
                            dgParts.UnSelect(itm);
                        }

                        reportName = "Stock Value Report";
                        break;
                    }
            }

            ExportHelper.Export(exportData, reportName, Enums.ExportType.XLS);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}