using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCOrderForJob : UCBase, IUserControl
    {
        

        public UCOrderForJob() : base()
        {
            base.Load += UCOrderForJob_Load;

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
        private GroupBox _grpJob;

        internal GroupBox grpJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJob != null)
                {
                }

                _grpJob = value;
                if (_grpJob != null)
                {
                }
            }
        }

        private DataGrid _dgEngineerVisits;

        internal DataGrid dgEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineerVisits != null)
                {
                }

                _dgEngineerVisits = value;
                if (_dgEngineerVisits != null)
                {
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private TextBox _txtJobSearch;

        internal TextBox txtJobSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobSearch != null)
                {
                    _txtJobSearch.KeyUp -= txtJobSearch_KeyUp;
                }

                _txtJobSearch = value;
                if (_txtJobSearch != null)
                {
                    _txtJobSearch.KeyUp += txtJobSearch_KeyUp;
                }
            }
        }

        private GroupBox _grpWarehouse;

        internal GroupBox grpWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpWarehouse != null)
                {
                }

                _grpWarehouse = value;
                if (_grpWarehouse != null)
                {
                }
            }
        }

        private TextBox _txtWarehouse;

        internal TextBox txtWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWarehouse != null)
                {
                }

                _txtWarehouse = value;
                if (_txtWarehouse != null)
                {
                }
            }
        }

        private Button _btnFindWarehouse;

        internal Button btnFindWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindWarehouse != null)
                {
                    
                    
                    _btnFindWarehouse.Click -= btnFindWarehouse_Click;
                }

                _btnFindWarehouse = value;
                if (_btnFindWarehouse != null)
                {
                    _btnFindWarehouse.Click += btnFindWarehouse_Click;
                }
            }
        }

        private GroupBox _grpCustomerSearch;

        internal GroupBox grpCustomerSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomerSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomerSearch != null)
                {
                }

                _grpCustomerSearch = value;
                if (_grpCustomerSearch != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJob = new GroupBox();
            _dgEngineerVisits = new DataGrid();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _txtJobSearch = new TextBox();
            _txtJobSearch.KeyUp += new KeyEventHandler(txtJobSearch_KeyUp);
            _grpCustomerSearch = new GroupBox();
            _grpWarehouse = new GroupBox();
            _btnFindWarehouse = new Button();
            _btnFindWarehouse.Click += new EventHandler(btnFindWarehouse_Click);
            _txtWarehouse = new TextBox();
            _grpJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineerVisits).BeginInit();
            _grpCustomerSearch.SuspendLayout();
            _grpWarehouse.SuspendLayout();
            SuspendLayout();
            //
            // grpJob
            //
            _grpJob.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJob.Controls.Add(_dgEngineerVisits);
            _grpJob.Location = new Point(8, 128);
            _grpJob.Name = "grpJob";
            _grpJob.Size = new Size(696, 248);
            _grpJob.TabIndex = 10;
            _grpJob.TabStop = false;
            _grpJob.Text = "Select a Visit to assign this Order to:";
            //
            // dgEngineerVisits
            //
            _dgEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgEngineerVisits.DataMember = "";
            _dgEngineerVisits.HeaderForeColor = SystemColors.ControlText;
            _dgEngineerVisits.Location = new Point(8, 26);
            _dgEngineerVisits.Name = "dgEngineerVisits";
            _dgEngineerVisits.Size = new Size(680, 214);
            _dgEngineerVisits.TabIndex = 3;
            //
            // btnSearch
            //
            _btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSearch.ForeColor = SystemColors.ControlText;
            _btnSearch.Location = new Point(640, 25);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(48, 23);
            _btnSearch.TabIndex = 2;
            _btnSearch.Text = "Find";
            //
            // txtJobSearch
            //
            _txtJobSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtJobSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtJobSearch.Location = new Point(8, 24);
            _txtJobSearch.Name = "txtJobSearch";
            _txtJobSearch.Size = new Size(624, 21);
            _txtJobSearch.TabIndex = 1;
            //
            // grpCustomerSearch
            //
            _grpCustomerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCustomerSearch.BackColor = Color.White;
            _grpCustomerSearch.Controls.Add(_btnSearch);
            _grpCustomerSearch.Controls.Add(_txtJobSearch);
            _grpCustomerSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpCustomerSearch.ForeColor = SystemColors.ControlText;
            _grpCustomerSearch.Location = new Point(8, 8);
            _grpCustomerSearch.Name = "grpCustomerSearch";
            _grpCustomerSearch.Size = new Size(696, 56);
            _grpCustomerSearch.TabIndex = 9;
            _grpCustomerSearch.TabStop = false;
            _grpCustomerSearch.Text = "Job Number / Address";
            //
            // grpWarehouse
            //
            _grpWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpWarehouse.Controls.Add(_btnFindWarehouse);
            _grpWarehouse.Controls.Add(_txtWarehouse);
            _grpWarehouse.Location = new Point(8, 70);
            _grpWarehouse.Name = "grpWarehouse";
            _grpWarehouse.Size = new Size(696, 52);
            _grpWarehouse.TabIndex = 11;
            _grpWarehouse.TabStop = false;
            _grpWarehouse.Text = "Warehouse";
            //
            // btnFindWarehouse
            //
            _btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindWarehouse.ForeColor = SystemColors.ControlText;
            _btnFindWarehouse.Location = new Point(640, 18);
            _btnFindWarehouse.Name = "btnFindWarehouse";
            _btnFindWarehouse.Size = new Size(48, 23);
            _btnFindWarehouse.TabIndex = 3;
            _btnFindWarehouse.Text = "...";
            //
            // txtWarehouse
            //
            _txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtWarehouse.Location = new Point(8, 20);
            _txtWarehouse.Name = "txtWarehouse";
            _txtWarehouse.ReadOnly = true;
            _txtWarehouse.Size = new Size(624, 21);
            _txtWarehouse.TabIndex = 0;
            //
            // UCOrderForJob
            //
            Controls.Add(_grpWarehouse);
            Controls.Add(_grpCustomerSearch);
            Controls.Add(_grpJob);
            Name = "UCOrderForJob";
            Size = new Size(712, 377);
            _grpJob.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEngineerVisits).EndInit();
            _grpCustomerSearch.ResumeLayout(false);
            _grpCustomerSearch.PerformLayout();
            _grpWarehouse.ResumeLayout(false);
            _grpWarehouse.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupVisitsDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return null;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public DataView EngineerVisitsDataView
        {
            get
            {
                return m_dTable;
            }

            set
            {
                m_dTable = value;
                m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
                m_dTable.AllowNew = false;
                m_dTable.AllowEdit = false;
                m_dTable.AllowDelete = false;
                dgEngineerVisits.DataSource = EngineerVisitsDataView;
            }
        }

        private DataView m_dTable = null;

        public DataRow SelectedEngineerVisitDataRow
        {
            get
            {
                if (!(dgEngineerVisits.CurrentRowIndex == -1))
                {
                    return EngineerVisitsDataView[dgEngineerVisits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Warehouses.Warehouse _Warehouse;

        public Entity.Warehouses.Warehouse Warehouse
        {
            get
            {
                return _Warehouse;
            }

            set
            {
                _Warehouse = value;
                if (_Warehouse is object)
                {
                    string strWarehouse = _Warehouse.Name + ". " + _Warehouse.Address1;
                    if (_Warehouse.Postcode.Length > 0)
                    {
                        strWarehouse += ", " + _Warehouse.Postcode;
                    }
                }
            }
        }

        
        

        public void SetupVisitsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgEngineerVisits);
            var tbStyle = dgEngineerVisits.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 150;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 75;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var JobDefinition = new DataGridLabelColumn();
            JobDefinition.Format = "";
            JobDefinition.FormatInfo = null;
            JobDefinition.HeaderText = "Definition";
            JobDefinition.MappingName = "JobDefinition";
            JobDefinition.ReadOnly = true;
            JobDefinition.Width = 75;
            JobDefinition.NullText = "";
            tbStyle.GridColumnStyles.Add(JobDefinition);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 75;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var VisitDate = new DataGridLabelColumn();
            VisitDate.Format = "dd/MMM/yyyy";
            VisitDate.FormatInfo = null;
            VisitDate.HeaderText = "Date";
            VisitDate.MappingName = "startdatetime";
            VisitDate.ReadOnly = true;
            VisitDate.Width = 100;
            VisitDate.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(VisitDate);
            var VisitEngineer = new DataGridLabelColumn();
            VisitEngineer.Format = "";
            VisitEngineer.FormatInfo = null;
            VisitEngineer.HeaderText = "Engineer";
            VisitEngineer.MappingName = "Engineer";
            VisitEngineer.ReadOnly = true;
            VisitEngineer.Width = 100;
            VisitEngineer.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(VisitEngineer);
            var jobOfWork = new DataGridLabelColumn();
            jobOfWork.Format = "";
            jobOfWork.FormatInfo = null;
            jobOfWork.HeaderText = "Job Of Work";
            jobOfWork.MappingName = "JOWNo";
            jobOfWork.ReadOnly = true;
            jobOfWork.Width = 100;
            jobOfWork.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(jobOfWork);
            var visit = new DataGridLabelColumn();
            visit.Format = "";
            visit.FormatInfo = null;
            visit.HeaderText = "Visit";
            visit.MappingName = "VisitNo";
            visit.ReadOnly = true;
            visit.Width = 100;
            visit.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(visit);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
            dgEngineerVisits.TableStyles.Add(tbStyle);
        }

        private void btnFindWarehouse_Click(object sender, EventArgs e)
        {
            int warehouseID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
            if (!(warehouseID == 0))
            {
                Warehouse = App.DB.Warehouse.Warehouse_Get(warehouseID);
            }
        }

        private void UCOrderForJob_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJobSearch.Text))
            {
                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Search(txtJobSearch.Text, true);
            }
        }

        private void txtJobSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtJobSearch.Text))
            {
                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Search(txtJobSearch.Text, true);
            }
        }

        
        

        public void Populate(int ID = 0)
        {
        }

        public bool Save()
        {
            return default;
        }

        
    }
}