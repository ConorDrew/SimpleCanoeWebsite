using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCQuotesList : UCBase
    {
        public UCQuotesList()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuotesList_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCQuotesList(Entity.Sys.Enums.TableNames EntityToLinkToIn, int CustomerIDIn, int SiteIDIn) : base()
        {
            base.Load += UCQuotesList_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            EntityToLinkTo = EntityToLinkToIn;
            CustomerID = CustomerIDIn;
            SiteID = SiteIDIn;
            if (CustomerID == 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                Populate();
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }

            Dock = DockStyle.Fill;
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
        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private GroupBox _grpQuotes;

        internal GroupBox grpQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQuotes != null)
                {
                }

                _grpQuotes = value;
                if (_grpQuotes != null)
                {
                }
            }
        }

        private DataGrid _dgQuotes;

        internal DataGrid dgQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgQuotes != null)
                {
                    _dgQuotes.DoubleClick -= dgQuotes_DoubleClick;
                }

                _dgQuotes = value;
                if (_dgQuotes != null)
                {
                    _dgQuotes.DoubleClick += dgQuotes_DoubleClick;
                }
            }
        }

        private ContextMenu _ctxtMnuQuotes;

        internal ContextMenu ctxtMnuQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ctxtMnuQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ctxtMnuQuotes != null)
                {
                }

                _ctxtMnuQuotes = value;
                if (_ctxtMnuQuotes != null)
                {
                }
            }
        }

        private MenuItem _mnuJobQuote;

        internal MenuItem mnuJobQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuJobQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuJobQuote != null)
                {
                    _mnuJobQuote.Click -= mnuJobQuote_Click;
                }

                _mnuJobQuote = value;
                if (_mnuJobQuote != null)
                {
                    _mnuJobQuote.Click += mnuJobQuote_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpQuotes = new GroupBox();
            _dgQuotes = new DataGrid();
            _dgQuotes.DoubleClick += new EventHandler(dgQuotes_DoubleClick);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _ctxtMnuQuotes = new ContextMenu();
            _mnuJobQuote = new MenuItem();
            _mnuJobQuote.Click += new EventHandler(mnuJobQuote_Click);
            _grpQuotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgQuotes).BeginInit();
            SuspendLayout();
            //
            // grpQuotes
            //
            _grpQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpQuotes.Controls.Add(_dgQuotes);
            _grpQuotes.Location = new Point(8, 8);
            _grpQuotes.Name = "grpQuotes";
            _grpQuotes.Size = new Size(488, 512);
            _grpQuotes.TabIndex = 0;
            _grpQuotes.TabStop = false;
            _grpQuotes.Text = "Double Click To View / Edit";
            //
            // dgQuotes
            //
            _dgQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgQuotes.DataMember = "";
            _dgQuotes.HeaderForeColor = SystemColors.ControlText;
            _dgQuotes.Location = new Point(8, 27);
            _dgQuotes.Name = "dgQuotes";
            _dgQuotes.Size = new Size(472, 477);
            _dgQuotes.TabIndex = 1;
            //
            // btnDelete
            //
            _btnDelete.AccessibleDescription = "Delete Contract";
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(440, 528);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(56, 25);
            _btnDelete.TabIndex = 3;
            _btnDelete.Text = "Delete";
            //
            // btnAdd
            //
            _btnAdd.AccessibleDescription = "Add New Contract";
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(8, 528);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(56, 25);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            //
            // ctxtMnuQuotes
            //
            _ctxtMnuQuotes.MenuItems.AddRange(new MenuItem[] { _mnuJobQuote });
            //
            // mnuJobQuote
            //
            _mnuJobQuote.Index = 0;
            _mnuJobQuote.Text = "Job Quote";
            //
            // UCQuotesList
            //
            Controls.Add(_btnDelete);
            Controls.Add(_btnAdd);
            Controls.Add(_grpQuotes);
            Name = "UCQuotesList";
            Size = new Size(504, 560);
            _grpQuotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgQuotes).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event RefreshContractsEventHandler RefreshContracts;

        public delegate void RefreshContractsEventHandler();

        public event RefreshJobsEventHandler RefreshJobs;

        public delegate void RefreshJobsEventHandler();

        private Entity.Sys.Enums.TableNames _EntityToLinkTo;

        public Entity.Sys.Enums.TableNames EntityToLinkTo
        {
            get
            {
                return _EntityToLinkTo;
            }

            set
            {
                _EntityToLinkTo = value;
            }
        }

        private int _CustomerID = 0;

        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }

            set
            {
                _CustomerID = value;
            }
        }

        private int _SiteID = 0;

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

        private DataView _dvQuotes;

        public DataView Quotes
        {
            get
            {
                return _dvQuotes;
            }

            set
            {
                _dvQuotes = value;
                _dvQuotes.Table.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString();
                _dvQuotes.AllowNew = false;
                _dvQuotes.AllowEdit = false;
                _dvQuotes.AllowDelete = false;
                dgQuotes.DataSource = Quotes;
            }
        }

        private DataRow SelectedQuoteDataRow
        {
            get
            {
                if (!(dgQuotes.CurrentRowIndex == -1))
                {
                    return Quotes[dgQuotes.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _SelectedSiteID = 0;

        public int SelectedSiteID
        {
            get
            {
                return _SelectedSiteID;
            }

            set
            {
                _SelectedSiteID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupContractsDataGrid()
        {
            var tStyle = dgQuotes.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var QuoteType = new DataGridLabelColumn();
            QuoteType.Format = "";
            QuoteType.FormatInfo = null;
            QuoteType.HeaderText = "Quote Type";
            QuoteType.MappingName = "QuoteType";
            QuoteType.ReadOnly = true;
            QuoteType.Width = 100;
            QuoteType.NullText = "";
            tStyle.GridColumnStyles.Add(QuoteType);
            var QuoteReference = new DataGridLabelColumn();
            QuoteReference.Format = "";
            QuoteReference.FormatInfo = null;
            QuoteReference.HeaderText = "Reference";
            QuoteReference.MappingName = "Reference";
            QuoteReference.ReadOnly = true;
            QuoteReference.Width = 100;
            QuoteReference.NullText = "";
            tStyle.GridColumnStyles.Add(QuoteReference);
            var QuoteDate = new DataGridLabelColumn();
            QuoteDate.Format = "dd/MM/yyyy";
            QuoteDate.FormatInfo = null;
            QuoteDate.HeaderText = "Quote Date";
            QuoteDate.MappingName = "QuoteDate";
            QuoteDate.ReadOnly = true;
            QuoteDate.Width = 80;
            QuoteDate.NullText = "";
            tStyle.GridColumnStyles.Add(QuoteDate);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QuoteStatus = new DataGridLabelColumn();
            QuoteStatus.Format = "";
            QuoteStatus.FormatInfo = null;
            QuoteStatus.HeaderText = "Status";
            QuoteStatus.MappingName = "Status";
            QuoteStatus.ReadOnly = true;
            QuoteStatus.Width = 100;
            QuoteStatus.NullText = "";
            tStyle.GridColumnStyles.Add(QuoteStatus);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuotes.ToString();
            dgQuotes.TableStyles.Add(tStyle);
        }

        private void UCQuotesList_Load(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupContractsDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ctxtMnuQuotes.Show(btnAdd, new Point(0, -30));
        }

        private void mnuJobQuote_Click(object sender, EventArgs e)
        {
            if (!(SiteID == 0))
            {
                App.ShowForm(typeof(FRMQuoteJob), true, new object[] { 0, SiteID });
            }
            else
            {
                // pick site from site list for customer
                App.ShowForm(typeof(FRMQuoteJobSelectASite), true, new object[] { CustomerID, this });
                if (SelectedSiteID != 0)
                {
                    App.ShowForm(typeof(FRMQuoteJob), true, new object[] { 0, SelectedSiteID });
                }
            }

            Populate();
        }

        private void dgQuotes_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedQuoteDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Job.ToString(), false)))
            {
                App.ShowForm(typeof(FRMQuoteJob), true, new object[] { Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]), SelectedQuoteDataRow["IDToLinkTo"] });
            }

            Populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedQuoteDataRow is null)
            {
                App.ShowMessage("Please select quote to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete this quote?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString(), false)))
            {
                // DELETE  PPM Visits, Quote Contract Site Assets, Quote Contract Sites
                var sites = new DataView();
                sites = App.DB.QuoteContractOriginalSite.GetAll_QuoteContractID(Conversions.ToInteger(SelectedQuoteDataRow["QuoteID"]), CustomerID);
                foreach (DataRow r in sites.Table.Rows)
                    App.DB.QuoteContractOriginalSite.Delete(Conversions.ToInteger(r["QuoteContractSiteID"]));
                App.DB.QuoteContractOriginal.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]));
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Contract_Opt_2.ToString(), false)))
            {
                // DELETE  PPM Visits, Quote Contract Site Assets, Quote Contract Sites
                var sites = new DataView();
                sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(Conversions.ToInteger(SelectedQuoteDataRow["QuoteID"]), CustomerID);
                foreach (DataRow r in sites.Table.Rows)
                    App.DB.QuoteContractAlternativeSite.Delete(Conversions.ToInteger(r["QuoteContractSiteID"]));
                App.DB.QuoteContractAlternative.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]));
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Job.ToString(), false)))
            {
                App.DB.QuoteJob.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]));
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString(), false)))
            {
                // DELETE   Quote Contract Site Assets, Quote Contract Sites
                var sites = new DataView();
                sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(Conversions.ToInteger(SelectedQuoteDataRow["QuoteID"]), CustomerID);
                foreach (DataRow r in sites.Table.Rows)
                    App.DB.QuoteContractOption3Site.Delete(Conversions.ToInteger(r["QuoteContractSiteID"]));
                App.DB.QuoteContractOption3.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]));
            }

            Populate();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void Populate()
        {
            if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblCustomer)
            {
                Quotes = App.DB.Quotes.QuotesGet_All_For_CustomerID(CustomerID);
            }
            else if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblSite)
            {
                Quotes = App.DB.Quotes.QuotesGet_All_For_SiteID(SiteID);
            }
            else
            {
                Quotes = App.DB.Quotes.QuotesGet_All();
            }

            RefreshContracts?.Invoke();
            RefreshJobs?.Invoke();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}