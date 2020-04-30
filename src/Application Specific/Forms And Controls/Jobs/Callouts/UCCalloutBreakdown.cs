using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCCalloutBreakdown : UCBase, IUserControl
    {
        

        public UCCalloutBreakdown() : base()
        {
            
            
            base.Load += UCCalloutBreakdown_Load;

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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private GroupBox _grpJobItemsAdded;

        internal GroupBox grpJobItemsAdded
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobItemsAdded;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobItemsAdded != null)
                {
                }

                _grpJobItemsAdded = value;
                if (_grpJobItemsAdded != null)
                {
                }
            }
        }

        private DataGrid _dgJobItemsAdded;

        internal DataGrid dgJobItemsAdded
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobItemsAdded;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobItemsAdded != null)
                {
                    _dgJobItemsAdded.Click -= dgJobItemsAdded_Click;
                    _dgJobItemsAdded.CurrentCellChanged -= dgJobItemsAdded_Click;
                }

                _dgJobItemsAdded = value;
                if (_dgJobItemsAdded != null)
                {
                    _dgJobItemsAdded.Click += dgJobItemsAdded_Click;
                    _dgJobItemsAdded.CurrentCellChanged += dgJobItemsAdded_Click;
                }
            }
        }

        private TabControl _tcEngineerVisits;

        internal TabControl tcEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcEngineerVisits != null)
                {
                }

                _tcEngineerVisits = value;
                if (_tcEngineerVisits != null)
                {
                }
            }
        }

        private Button _btnRemoveEngineerVisit;

        internal Button btnRemoveEngineerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveEngineerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveEngineerVisit != null)
                {
                    _btnRemoveEngineerVisit.Click -= btnRemoveEngineerVisit_Click;
                }

                _btnRemoveEngineerVisit = value;
                if (_btnRemoveEngineerVisit != null)
                {
                    _btnRemoveEngineerVisit.Click += btnRemoveEngineerVisit_Click;
                }
            }
        }

        private Button _btnAddEngineerVisit;

        internal Button btnAddEngineerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddEngineerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddEngineerVisit != null)
                {
                    _btnAddEngineerVisit.Click -= btnAddEngineerVisit_Click;
                }

                _btnAddEngineerVisit = value;
                if (_btnAddEngineerVisit != null)
                {
                    _btnAddEngineerVisit.Click += btnAddEngineerVisit_Click;
                }
            }
        }

        private TextBox _txtJobItemSummary;

        internal TextBox txtJobItemSummary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobItemSummary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobItemSummary != null)
                {
                }

                _txtJobItemSummary = value;
                if (_txtJobItemSummary != null)
                {
                }
            }
        }

        private Button _btnSaveItem;

        internal Button btnSaveItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveItem != null)
                {
                    _btnSaveItem.Click -= btnSaveItem_Click;
                }

                _btnSaveItem = value;
                if (_btnSaveItem != null)
                {
                    _btnSaveItem.Click += btnSaveItem_Click;
                }
            }
        }

        private Button _btnRemoveItem;

        internal Button btnRemoveItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveItem != null)
                {
                    _btnRemoveItem.Click -= btnRemoveItem_Click;
                }

                _btnRemoveItem = value;
                if (_btnRemoveItem != null)
                {
                    _btnRemoveItem.Click += btnRemoveItem_Click;
                }
            }
        }

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

        private TextBox _txtPONumber;

        internal TextBox txtPONumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPONumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPONumber != null)
                {
                }

                _txtPONumber = value;
                if (_txtPONumber != null)
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

        private ComboBox _cboQualification;

        internal ComboBox cboQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualification != null)
                {
                }

                _cboQualification = value;
                if (_cboQualification != null)
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

        private ComboBox _cboPriority;

        internal ComboBox cboPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPriority != null)
                {
                }

                _cboPriority = value;
                if (_cboPriority != null)
                {
                }
            }
        }

        private Button _btnAddRate;

        internal Button btnAddRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddRate != null)
                {
                    _btnAddRate.Click -= btnAddRate_Click;
                }

                _btnAddRate = value;
                if (_btnAddRate != null)
                {
                    _btnAddRate.Click += btnAddRate_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobItemsAdded = new GroupBox();
            _lblQualification = new Label();
            _cboQualification = new ComboBox();
            _Label4 = new Label();
            _cboPriority = new ComboBox();
            _txtPONumber = new TextBox();
            _Label3 = new Label();
            _btnAddRate = new Button();
            _btnAddRate.Click += new EventHandler(btnAddRate_Click);
            _Label1 = new Label();
            _txtJobItemSummary = new TextBox();
            _btnSaveItem = new Button();
            _btnSaveItem.Click += new EventHandler(btnSaveItem_Click);
            _btnRemoveItem = new Button();
            _btnRemoveItem.Click += new EventHandler(btnRemoveItem_Click);
            _btnRemoveEngineerVisit = new Button();
            _btnRemoveEngineerVisit.Click += new EventHandler(btnRemoveEngineerVisit_Click);
            _btnAddEngineerVisit = new Button();
            _btnAddEngineerVisit.Click += new EventHandler(btnAddEngineerVisit_Click);
            _tcEngineerVisits = new TabControl();
            _dgJobItemsAdded = new DataGrid();
            _dgJobItemsAdded.Click += new EventHandler(dgJobItemsAdded_Click);
            _dgJobItemsAdded.CurrentCellChanged += new EventHandler(dgJobItemsAdded_Click);
            _dgJobItemsAdded.Click += new EventHandler(dgJobItemsAdded_Click);
            _dgJobItemsAdded.CurrentCellChanged += new EventHandler(dgJobItemsAdded_Click);
            _grpJobItemsAdded.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobItemsAdded).BeginInit();
            SuspendLayout();
            //
            // grpJobItemsAdded
            //
            _grpJobItemsAdded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobItemsAdded.Controls.Add(_lblQualification);
            _grpJobItemsAdded.Controls.Add(_cboQualification);
            _grpJobItemsAdded.Controls.Add(_Label4);
            _grpJobItemsAdded.Controls.Add(_cboPriority);
            _grpJobItemsAdded.Controls.Add(_txtPONumber);
            _grpJobItemsAdded.Controls.Add(_Label3);
            _grpJobItemsAdded.Controls.Add(_btnAddRate);
            _grpJobItemsAdded.Controls.Add(_Label1);
            _grpJobItemsAdded.Controls.Add(_txtJobItemSummary);
            _grpJobItemsAdded.Controls.Add(_btnSaveItem);
            _grpJobItemsAdded.Controls.Add(_btnRemoveItem);
            _grpJobItemsAdded.Controls.Add(_btnRemoveEngineerVisit);
            _grpJobItemsAdded.Controls.Add(_btnAddEngineerVisit);
            _grpJobItemsAdded.Controls.Add(_tcEngineerVisits);
            _grpJobItemsAdded.Controls.Add(_dgJobItemsAdded);
            _grpJobItemsAdded.Location = new Point(8, 8);
            _grpJobItemsAdded.Name = "grpJobItemsAdded";
            _grpJobItemsAdded.Size = new Size(864, 280);
            _grpJobItemsAdded.TabIndex = 0;
            _grpJobItemsAdded.TabStop = false;
            _grpJobItemsAdded.Text = "Job Items";
            //
            // lblQualification
            //
            _lblQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblQualification.AutoSize = true;
            _lblQualification.Location = new Point(277, 22);
            _lblQualification.Name = "lblQualification";
            _lblQualification.Size = new Size(77, 13);
            _lblQualification.TabIndex = 26;
            _lblQualification.Text = "Qualification";
            //
            // cboQualification
            //
            _cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboQualification.FormattingEnabled = true;
            _cboQualification.Location = new Point(369, 18);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(223, 21);
            _cboQualification.TabIndex = 25;
            //
            // Label4
            //
            _Label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label4.AutoSize = true;
            _Label4.Location = new Point(598, 20);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(48, 13);
            _Label4.TabIndex = 24;
            _Label4.Text = "Priority";
            //
            // cboPriority
            //
            _cboPriority.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboPriority.FormattingEnabled = true;
            _cboPriority.Location = new Point(652, 18);
            _cboPriority.Name = "cboPriority";
            _cboPriority.Size = new Size(142, 21);
            _cboPriority.TabIndex = 23;
            //
            // txtPONumber
            //
            _txtPONumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPONumber.Location = new Point(84, 20);
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(185, 21);
            _txtPONumber.TabIndex = 22;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 21);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(81, 20);
            _Label3.TabIndex = 21;
            _Label3.Text = "PO Number";
            //
            // btnAddRate
            //
            _btnAddRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddRate.Location = new Point(6, 248);
            _btnAddRate.Name = "btnAddRate";
            _btnAddRate.Size = new Size(354, 23);
            _btnAddRate.TabIndex = 20;
            _btnAddRate.Text = "Add Description From A Property Schedule Of Rates List";
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label1.Location = new Point(6, 172);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(104, 16);
            _Label1.TabIndex = 18;
            _Label1.Text = "Enter Summary";
            //
            // txtJobItemSummary
            //
            _txtJobItemSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtJobItemSummary.Location = new Point(8, 191);
            _txtJobItemSummary.Multiline = true;
            _txtJobItemSummary.Name = "txtJobItemSummary";
            _txtJobItemSummary.ScrollBars = ScrollBars.Both;
            _txtJobItemSummary.Size = new Size(261, 49);
            _txtJobItemSummary.TabIndex = 15;
            //
            // btnSaveItem
            //
            _btnSaveItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveItem.Location = new Point(296, 220);
            _btnSaveItem.Name = "btnSaveItem";
            _btnSaveItem.Size = new Size(64, 23);
            _btnSaveItem.TabIndex = 16;
            _btnSaveItem.Text = "Save";
            //
            // btnRemoveItem
            //
            _btnRemoveItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveItem.Location = new Point(296, 191);
            _btnRemoveItem.Name = "btnRemoveItem";
            _btnRemoveItem.Size = new Size(62, 23);
            _btnRemoveItem.TabIndex = 17;
            _btnRemoveItem.Text = "Remove";
            //
            // btnRemoveEngineerVisit
            //
            _btnRemoveEngineerVisit.AccessibleDescription = "Remove Engineer Visit";
            _btnRemoveEngineerVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRemoveEngineerVisit.Location = new Point(832, 25);
            _btnRemoveEngineerVisit.Name = "btnRemoveEngineerVisit";
            _btnRemoveEngineerVisit.Size = new Size(24, 23);
            _btnRemoveEngineerVisit.TabIndex = 4;
            _btnRemoveEngineerVisit.Text = "_";
            //
            // btnAddEngineerVisit
            //
            _btnAddEngineerVisit.AccessibleDescription = "Add Engineer Visit";
            _btnAddEngineerVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddEngineerVisit.Location = new Point(800, 25);
            _btnAddEngineerVisit.Name = "btnAddEngineerVisit";
            _btnAddEngineerVisit.Size = new Size(24, 23);
            _btnAddEngineerVisit.TabIndex = 3;
            _btnAddEngineerVisit.Text = "+";
            //
            // tcEngineerVisits
            //
            _tcEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _tcEngineerVisits.Location = new Point(369, 48);
            _tcEngineerVisits.Name = "tcEngineerVisits";
            _tcEngineerVisits.SelectedIndex = 0;
            _tcEngineerVisits.Size = new Size(487, 224);
            _tcEngineerVisits.TabIndex = 5;
            //
            // dgJobItemsAdded
            //
            _dgJobItemsAdded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobItemsAdded.DataMember = "";
            _dgJobItemsAdded.HeaderForeColor = SystemColors.ControlText;
            _dgJobItemsAdded.Location = new Point(8, 48);
            _dgJobItemsAdded.Name = "dgJobItemsAdded";
            _dgJobItemsAdded.Size = new Size(352, 121);
            _dgJobItemsAdded.TabIndex = 1;
            //
            // UCCalloutBreakdown
            //
            Controls.Add(_grpJobItemsAdded);
            Name = "UCCalloutBreakdown";
            Size = new Size(880, 296);
            _grpJobItemsAdded.ResumeLayout(false);
            _grpJobItemsAdded.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobItemsAdded).EndInit();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupJobItemsAddedDataGrid();
            foreach (TabPage CalloutBreakdown in tcEngineerVisits.TabPages)
                ((UCVisitBreakdown)CalloutBreakdown.Controls[0]).SetupDG();
        }

        public object LoadedItem
        {
            get
            {
                return JobOfWork;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private UCLogCallout _onContol = null;

        public UCLogCallout OnContol
        {
            get
            {
                return _onContol;
            }

            set
            {
                _onContol = value;
            }
        }

        private Entity.JobOfWorks.JobOfWork _jobOfWork;

        public Entity.JobOfWorks.JobOfWork JobOfWork
        {
            get
            {
                return _jobOfWork;
            }

            set
            {
                _jobOfWork = value;
                if (_jobOfWork is null)
                {
                    _jobOfWork = new Entity.JobOfWorks.JobOfWork();
                }
            }
        }

        public DataView JobItemsAddedDataView
        {
            get
            {
                return m_dJobItemsAddedTable;
            }

            set
            {
                m_dJobItemsAddedTable = value;
                m_dJobItemsAddedTable.Table.TableName = "JOB_ITEMS_ADDED";
                m_dJobItemsAddedTable.AllowNew = false;
                m_dJobItemsAddedTable.AllowEdit = false;
                m_dJobItemsAddedTable.AllowDelete = false;
                dgJobItemsAdded.DataSource = JobItemsAddedDataView;
            }
        }

        private DataView m_dJobItemsAddedTable = null;

        private DataRow SelectedItemAddedDataRow
        {
            get
            {
                if (!(dgJobItemsAdded.CurrentRowIndex == -1))
                {
                    return JobItemsAddedDataView[dgJobItemsAdded.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Sys.Enums.FormState _JobItemState = Entity.Sys.Enums.FormState.Insert;

        public Entity.Sys.Enums.FormState JobItemState
        {
            get
            {
                return _JobItemState;
            }

            set
            {
                _JobItemState = value;
                if (value == Entity.Sys.Enums.FormState.Insert)
                {
                    btnSaveItem.Text = "Add";
                }
                else if (value == Entity.Sys.Enums.FormState.Update)
                {
                    btnSaveItem.Text = "Update";
                }
                else
                {
                    btnSaveItem.Text = "Save";
                }
            }
        }

        private void UCCalloutBreakdown_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        lblQualification.Text = "Trade";
                        break;
                    }

                default:
                    {
                        lblQualification.Text = "Qualification";
                        break;
                    }
            }
        }

        private void dgJobItemsAdded_Click(object sender, EventArgs e)
        {
            if (SelectedItemAddedDataRow is null)
            {
                JobItemState = Entity.Sys.Enums.FormState.Insert;
                return;
            }

            txtJobItemSummary.Text = Conversions.ToString(SelectedItemAddedDataRow["Summary"]);
            JobItemState = Entity.Sys.Enums.FormState.Update;
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            if (txtJobItemSummary.Text.Trim().Length == 0)
            {
                App.ShowMessage("Job Item Summary Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (JobItemState == Entity.Sys.Enums.FormState.Insert)
            {
                JobItemsAddedDataView.Table.AcceptChanges();
                var newRow = JobItemsAddedDataView.Table.NewRow();
                newRow["Summary"] = txtJobItemSummary.Text.Trim();
                newRow["RateID"] = 0;
                JobItemsAddedDataView.Table.Rows.Add(newRow);
            }
            else if (JobItemState == Entity.Sys.Enums.FormState.Update)
            {
                JobItemsAddedDataView.Table.AcceptChanges();
                SelectedItemAddedDataRow["Summary"] = txtJobItemSummary.Text.Trim();
            }

            JobItemsAddedDataView.Sort = "Summary";
            txtJobItemSummary.Text = "";
            JobItemState = Entity.Sys.Enums.FormState.Insert;
            ActiveControl = txtJobItemSummary;
            txtJobItemSummary.Focus();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedItemAddedDataRow is null)
            {
                App.ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (TabPage tp in tcEngineerVisits.TabPages)
            {
                if (((UCVisitBreakdown)tp.Controls[0]).EngineerVisit.StatusEnumID >= Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                {
                    App.ShowMessage("This item cannot be removed as it is related to a visit that has progressed to 'scheduled' or further.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtJobItemSummary.Text = "";
                    JobItemState = Entity.Sys.Enums.FormState.Insert;
                    return;
                }
            }

            if (App.ShowMessage("Are you sure you want to remove this item of work?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            JobItemsAddedDataView.Table.AcceptChanges();
            JobItemsAddedDataView.Table.Rows.Remove(SelectedItemAddedDataRow);
            JobItemsAddedDataView.Sort = "Summary";
            txtJobItemSummary.Text = "";
            JobItemState = Entity.Sys.Enums.FormState.Insert;
            ActiveControl = txtJobItemSummary;
            txtJobItemSummary.Focus();
        }

        private void btnAddEngineerVisit_Click(object sender, EventArgs e)
        {
            AddEngineerVisit(null);
        }

        private void btnRemoveEngineerVisit_Click(object sender, EventArgs e)
        {
            RemoveEngineerVisit();
        }

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            var argDataviewToLinkToIn = JobItemsAddedDataView;
            using (var f = new FRMSiteScheduleOfRateList(OnContol.Site.SiteID, ref argDataviewToLinkToIn, false, true))
            {
                f.ShowDialog();
            }
        }

        
        

        public void SetupJobItemsAddedDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgJobItemsAdded);
            var tStyle = dgJobItemsAdded.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Summary = new DataGridLabelColumn();
            Summary.Format = "";
            Summary.FormatInfo = null;
            Summary.HeaderText = "Summary";
            Summary.MappingName = "Summary";
            Summary.ReadOnly = true;
            Summary.Width = 375;
            Summary.NullText = "";
            tStyle.GridColumnStyles.Add(Summary);
            var Qty = new DataGridLabelColumn();
            Qty.Format = "";
            Qty.FormatInfo = null;
            Qty.HeaderText = "Qty";
            Qty.MappingName = "Qty";
            Qty.ReadOnly = true;
            Qty.Width = 50;
            Qty.NullText = "";
            tStyle.GridColumnStyles.Add(Qty);
            tStyle.ReadOnly = true;
            tStyle.MappingName = "JOB_ITEMS_ADDED";
            dgJobItemsAdded.TableStyles.Add(tStyle);
        }

        
        

        public void Populate(int ID = 0)
        {
            var argc = cboQualification;
            Combo.SetUpCombo(ref argc, OnContol.DvEngineerLevels.Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            if (OnContol.Site.SiteID > 0)
            {
                var argc1 = cboPriority;
                Combo.SetUpCombo(ref argc1, OnContol.DvCustomerPriorities.Table, "PriorityID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            }

            var dtAdded = new DataTable();
            dtAdded.Columns.Add(new DataColumn("JobItemID", typeof(int)));
            dtAdded.Columns.Add(new DataColumn("Summary", typeof(string)));
            dtAdded.Columns.Add(new DataColumn("RateID", typeof(int)));
            dtAdded.Columns.Add(new DataColumn("Qty", typeof(decimal)));
            dtAdded.Columns.Add(new DataColumn("SystemLinkID", typeof(int)));
            JobItemsAddedDataView = new DataView(dtAdded);
            if (JobOfWork.JobOfWorkID == 0)
            {
                AddEngineerVisit(null);
                cboPriority.Enabled = true;
                var argcombo = cboPriority;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, JobOfWork.Priority.ToString());
            }
            else
            {
                tcEngineerVisits.TabPages.Clear();
                txtPONumber.Text = JobOfWork.PONumber;
                var argcombo1 = cboPriority;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, JobOfWork.Priority.ToString());
                var argcombo2 = cboQualification;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, JobOfWork.QualificationID.ToString());
                foreach (Entity.EngineerVisits.EngineerVisit visit in OnContol.EngineerVisits.Where(x => x.JobOfWorkID == JobOfWork.JobOfWorkID).ToList())
                {
                    AddEngineerVisit(visit);
                    if (visit.StatusEnumID > Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                    {
                        OnContol.cboJobType.Enabled = false;
                    }

                    if (visit.StatusEnumID > Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule))
                    {
                        if (JobOfWork.Priority > 0)
                        {
                            cboPriority.Enabled = false;
                        }
                        else
                        {
                            cboPriority.Enabled = true;
                        }
                    }

                    if (visit.StatusEnumID >= Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Downloaded))
                    {
                        btnSaveItem.Enabled = false;
                        btnRemoveItem.Enabled = false;
                        btnAddRate.Enabled = false;
                    }
                    else
                    {
                        btnSaveItem.Enabled = true;
                        btnRemoveItem.Enabled = true;
                        btnAddRate.Enabled = true;
                    }
                }

                if (OnContol.Job.StatusEnumID >= Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Complete))
                {
                    btnAddEngineerVisit.Enabled = false;
                    btnRemoveEngineerVisit.Enabled = false;
                }
            }

            if (OnContol.DvJobItems.Table.Rows.Count > 0)
            {
                foreach (DataRow dr in OnContol.DvJobItems.Table.Select("JobOfWorkID = " + JobOfWork.JobOfWorkID))
                {
                    var newRow = JobItemsAddedDataView.Table.NewRow();
                    newRow["JobItemID"] = dr["JobItemID"];
                    newRow["RateID"] = dr["RateID"];
                    newRow["Summary"] = dr["Summary"];
                    newRow["Qty"] = dr["Qty"];
                    newRow["SystemLinkID"] = dr["SystemLinkID"];
                    JobItemsAddedDataView.Table.Rows.Add(newRow);
                }
            }

            JobItemsAddedDataView.Sort = "Summary";
            JobItemState = Entity.Sys.Enums.FormState.Insert;
        }

        public bool Save()
        {
            return default;
            // DO NOTHING
        }

        public void AddEngineerVisit(Entity.EngineerVisits.EngineerVisit engineerVisit)
        {
            var tp = new TabPage();
            tp.BackColor = Color.White;
            var ctrl = new UCVisitBreakdown();
            ctrl.OnControl = this;
            ctrl.EngineerVisit = engineerVisit;
            ctrl.Populate();
            if (engineerVisit is null)
            {
                var argcombo = ctrl.cboStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            }

            ctrl.Dock = DockStyle.Fill;
            tp.Controls.Add(ctrl);
            tcEngineerVisits.TabPages.Add(tp);
            CheckTabs();
            tcEngineerVisits.SelectedTab = tp;
        }

        private void RemoveEngineerVisit()
        {
            if (((UCVisitBreakdown)tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.StatusEnumID > (int)Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
            {
                App.ShowMessage("This visit is either scheduled, on a PDA or completed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var OrderIDs = new ArrayList();
            if (((UCVisitBreakdown)tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID > 0)
            {
                // ARE THERE ANY ORDERS FOR THIS VISIT?
                bool ordered = false;
                var engOrders = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(((UCVisitBreakdown)tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID);
                if (engOrders.Table.Rows.Count > 0)
                {
                    foreach (DataRow dr in engOrders.Table.Rows)
                        // WHAT STATUS ARE THEY?
                        ordered = true;
                }

                // IF ANYTHING ELSE DON'T DELETE THE VISIT
                if (ordered)
                {
                    App.ShowMessage("This visit has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    foreach (int OrderID in OrderIDs)
                        OnContol.EngineerVisitsOrdersRemoved.Add(OrderID);
                    OnContol.EngineerVisitsRemoved.Add(((UCVisitBreakdown)tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID);
                }
            }

            tcEngineerVisits.TabPages.Remove(tcEngineerVisits.SelectedTab);
            CheckTabs();
        }

        private void CheckTabs()
        {
            if (tcEngineerVisits.TabPages.Count == 1)
            {
                btnRemoveEngineerVisit.Enabled = false;
            }
            else
            {
                btnRemoveEngineerVisit.Enabled = true;
            }

            int i = 1;
            foreach (TabPage tab in tcEngineerVisits.TabPages)
            {
                tab.Text = "Visit #" + i;
                i += 1;
            }

            if (((UCVisitBreakdown)tcEngineerVisits.TabPages[tcEngineerVisits.TabPages.Count - 1].Controls[0]).EngineerVisit.StatusEnumID == (int)Entity.Sys.Enums.VisitStatus.Uploaded)
            {
                btnAddEngineerVisit.Enabled = true;
            }
            else
            {
                btnAddEngineerVisit.Enabled = false;
            }
        }

        
    }
}