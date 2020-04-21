using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCQuoteContractAlternative : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCQuoteContractAlternative() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboQuoteContractStatusID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.QuoteContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpQuoteContract;

        internal GroupBox grpQuoteContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQuoteContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQuoteContract != null)
                {
                }

                _grpQuoteContract = value;
                if (_grpQuoteContract != null)
                {
                }
            }
        }

        private TextBox _txtQuoteContractReference;

        internal TextBox txtQuoteContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuoteContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuoteContractReference != null)
                {
                }

                _txtQuoteContractReference = value;
                if (_txtQuoteContractReference != null)
                {
                }
            }
        }

        private Label _lblQuoteContractReference;

        internal Label lblQuoteContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteContractReference != null)
                {
                }

                _lblQuoteContractReference = value;
                if (_lblQuoteContractReference != null)
                {
                }
            }
        }

        private DateTimePicker _dtpQuoteContractDate;

        internal DateTimePicker dtpQuoteContractDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQuoteContractDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQuoteContractDate != null)
                {
                }

                _dtpQuoteContractDate = value;
                if (_dtpQuoteContractDate != null)
                {
                }
            }
        }

        private Label _lblQuoteContractDate;

        internal Label lblQuoteContractDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteContractDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteContractDate != null)
                {
                }

                _lblQuoteContractDate = value;
                if (_lblQuoteContractDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractStart;

        internal DateTimePicker dtpContractStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractStart != null)
                {
                }

                _dtpContractStart = value;
                if (_dtpContractStart != null)
                {
                }
            }
        }

        private Label _lblContractStart;

        internal Label lblContractStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStart != null)
                {
                }

                _lblContractStart = value;
                if (_lblContractStart != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractEnd;

        internal DateTimePicker dtpContractEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractEnd != null)
                {
                }

                _dtpContractEnd = value;
                if (_dtpContractEnd != null)
                {
                }
            }
        }

        private Label _lblContractEnd;

        internal Label lblContractEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractEnd != null)
                {
                }

                _lblContractEnd = value;
                if (_lblContractEnd != null)
                {
                }
            }
        }

        private ComboBox _cboQuoteContractStatusID;

        internal ComboBox cboQuoteContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQuoteContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQuoteContractStatusID != null)
                {
                    _cboQuoteContractStatusID.SelectedIndexChanged -= cboQuoteContractStatusID_SelectedIndexChanged;
                }

                _cboQuoteContractStatusID = value;
                if (_cboQuoteContractStatusID != null)
                {
                    _cboQuoteContractStatusID.SelectedIndexChanged += cboQuoteContractStatusID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblQuoteContractStatusID;

        internal Label lblQuoteContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteContractStatusID != null)
                {
                }

                _lblQuoteContractStatusID = value;
                if (_lblQuoteContractStatusID != null)
                {
                }
            }
        }

        private Label _lblMsg;

        internal Label lblMsg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMsg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMsg != null)
                {
                }

                _lblMsg = value;
                if (_lblMsg != null)
                {
                }
            }
        }

        private GroupBox _grpSites;

        internal GroupBox grpSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSites != null)
                {
                }

                _grpSites = value;
                if (_grpSites != null)
                {
                }
            }
        }

        private DataGrid _dgSites;

        internal DataGrid dgSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSites != null)
                {
                    _dgSites.MouseUp -= dgSites_MouseUp;
                    _dgSites.DoubleClick -= dgSites_DoubleClick;
                }

                _dgSites = value;
                if (_dgSites != null)
                {
                    _dgSites.MouseUp += dgSites_MouseUp;
                    _dgSites.DoubleClick += dgSites_DoubleClick;
                }
            }
        }

        private Label _lblContractPrice;

        internal Label lblContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractPrice != null)
                {
                }

                _lblContractPrice = value;
                if (_lblContractPrice != null)
                {
                }
            }
        }

        private TextBox _txtQuoteContractPrice;

        internal TextBox txtQuoteContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuoteContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuoteContractPrice != null)
                {
                    _txtQuoteContractPrice.LostFocus -= txtQuoteContractPrice_LostFocus;
                }

                _txtQuoteContractPrice = value;
                if (_txtQuoteContractPrice != null)
                {
                    _txtQuoteContractPrice.LostFocus += txtQuoteContractPrice_LostFocus;
                }
            }
        }

        private Button _btnCalculatePrice;

        internal Button btnCalculatePrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCalculatePrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCalculatePrice != null)
                {
                    _btnCalculatePrice.Click -= btnCalculatePrice_Click;
                }

                _btnCalculatePrice = value;
                if (_btnCalculatePrice != null)
                {
                    _btnCalculatePrice.Click += btnCalculatePrice_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpQuoteContract = new GroupBox();
            _btnCalculatePrice = new Button();
            _btnCalculatePrice.Click += new EventHandler(btnCalculatePrice_Click);
            _txtQuoteContractPrice = new TextBox();
            _txtQuoteContractPrice.LostFocus += new EventHandler(txtQuoteContractPrice_LostFocus);
            _lblContractPrice = new Label();
            _lblMsg = new Label();
            _grpSites = new GroupBox();
            _dgSites = new DataGrid();
            _dgSites.MouseUp += new MouseEventHandler(dgSites_MouseUp);
            _dgSites.DoubleClick += new EventHandler(dgSites_DoubleClick);
            _txtQuoteContractReference = new TextBox();
            _lblQuoteContractReference = new Label();
            _dtpQuoteContractDate = new DateTimePicker();
            _lblQuoteContractDate = new Label();
            _dtpContractStart = new DateTimePicker();
            _lblContractStart = new Label();
            _dtpContractEnd = new DateTimePicker();
            _lblContractEnd = new Label();
            _cboQuoteContractStatusID = new ComboBox();
            _cboQuoteContractStatusID.SelectedIndexChanged += new EventHandler(cboQuoteContractStatusID_SelectedIndexChanged);
            _lblQuoteContractStatusID = new Label();
            _grpQuoteContract.SuspendLayout();
            _grpSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            SuspendLayout();
            //
            // grpQuoteContract
            //
            _grpQuoteContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpQuoteContract.Controls.Add(_btnCalculatePrice);
            _grpQuoteContract.Controls.Add(_txtQuoteContractPrice);
            _grpQuoteContract.Controls.Add(_lblContractPrice);
            _grpQuoteContract.Controls.Add(_lblMsg);
            _grpQuoteContract.Controls.Add(_grpSites);
            _grpQuoteContract.Controls.Add(_txtQuoteContractReference);
            _grpQuoteContract.Controls.Add(_lblQuoteContractReference);
            _grpQuoteContract.Controls.Add(_dtpQuoteContractDate);
            _grpQuoteContract.Controls.Add(_lblQuoteContractDate);
            _grpQuoteContract.Controls.Add(_dtpContractStart);
            _grpQuoteContract.Controls.Add(_lblContractStart);
            _grpQuoteContract.Controls.Add(_dtpContractEnd);
            _grpQuoteContract.Controls.Add(_lblContractEnd);
            _grpQuoteContract.Controls.Add(_cboQuoteContractStatusID);
            _grpQuoteContract.Controls.Add(_lblQuoteContractStatusID);
            _grpQuoteContract.Location = new Point(8, 8);
            _grpQuoteContract.Name = "grpQuoteContract";
            _grpQuoteContract.Size = new Size(739, 594);
            _grpQuoteContract.TabIndex = 1;
            _grpQuoteContract.TabStop = false;
            _grpQuoteContract.Text = "Main Details";
            //
            // btnCalculatePrice
            //
            _btnCalculatePrice.UseVisualStyleBackColor = true;
            _btnCalculatePrice.Location = new Point(476, 104);
            _btnCalculatePrice.Name = "btnCalculatePrice";
            _btnCalculatePrice.Size = new Size(195, 23);
            _btnCalculatePrice.TabIndex = 7;
            _btnCalculatePrice.Text = "Calculate Price From Property Price";
            //
            // txtQuoteContractPrice
            //
            _txtQuoteContractPrice.Location = new Point(476, 76);
            _txtQuoteContractPrice.MaxLength = 9;
            _txtQuoteContractPrice.Name = "txtQuoteContractPrice";
            _txtQuoteContractPrice.Size = new Size(195, 21);
            _txtQuoteContractPrice.TabIndex = 6;
            _txtQuoteContractPrice.Tag = "Contract.ContractPrice";
            _txtQuoteContractPrice.Text = "";
            //
            // lblContractPrice
            //
            _lblContractPrice.Location = new Point(344, 76);
            _lblContractPrice.Name = "lblContractPrice";
            _lblContractPrice.Size = new Size(122, 21);
            _lblContractPrice.TabIndex = 51;
            _lblContractPrice.Text = "Total Contract Price";
            //
            // lblMsg
            //
            _lblMsg.BackColor = Color.LightGoldenrodYellow;
            _lblMsg.BorderStyle = BorderStyle.FixedSingle;
            _lblMsg.Location = new Point(16, 104);
            _lblMsg.Name = "lblMsg";
            _lblMsg.Size = new Size(280, 23);
            _lblMsg.TabIndex = 35;
            _lblMsg.Text = "Please save before adding properties";
            _lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            //
            // grpSites
            //
            _grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSites.Controls.Add(_dgSites);
            _grpSites.Location = new Point(10, 134);
            _grpSites.Name = "grpSites";
            _grpSites.Size = new Size(712, 450);
            _grpSites.TabIndex = 34;
            _grpSites.TabStop = false;
            _grpSites.Text = "Properties";
            //
            // dgSites
            //
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(11, 26);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(692, 404);
            _dgSites.TabIndex = 2;
            //
            // txtQuoteContractReference
            //
            _txtQuoteContractReference.Location = new Point(144, 25);
            _txtQuoteContractReference.MaxLength = 100;
            _txtQuoteContractReference.Name = "txtQuoteContractReference";
            _txtQuoteContractReference.Size = new Size(177, 21);
            _txtQuoteContractReference.TabIndex = 0;
            _txtQuoteContractReference.Tag = "QuoteContract.QuoteContractReference";
            _txtQuoteContractReference.Text = "";
            //
            // lblQuoteContractReference
            //
            _lblQuoteContractReference.Location = new Point(14, 25);
            _lblQuoteContractReference.Name = "lblQuoteContractReference";
            _lblQuoteContractReference.Size = new Size(134, 21);
            _lblQuoteContractReference.TabIndex = 31;
            _lblQuoteContractReference.Text = "Quote Contract Ref.";
            //
            // dtpQuoteContractDate
            //
            _dtpQuoteContractDate.Location = new Point(144, 49);
            _dtpQuoteContractDate.Name = "dtpQuoteContractDate";
            _dtpQuoteContractDate.Size = new Size(177, 21);
            _dtpQuoteContractDate.TabIndex = 2;
            _dtpQuoteContractDate.Tag = "QuoteContract.QuoteContractDate";
            //
            // lblQuoteContractDate
            //
            _lblQuoteContractDate.Location = new Point(14, 49);
            _lblQuoteContractDate.Name = "lblQuoteContractDate";
            _lblQuoteContractDate.Size = new Size(134, 21);
            _lblQuoteContractDate.TabIndex = 31;
            _lblQuoteContractDate.Text = "Quote Contract Date";
            //
            // dtpContractStart
            //
            _dtpContractStart.Location = new Point(476, 25);
            _dtpContractStart.Name = "dtpContractStart";
            _dtpContractStart.Size = new Size(195, 21);
            _dtpContractStart.TabIndex = 4;
            _dtpContractStart.Tag = "QuoteContract.ContractStart";
            //
            // lblContractStart
            //
            _lblContractStart.Location = new Point(344, 25);
            _lblContractStart.Name = "lblContractStart";
            _lblContractStart.Size = new Size(103, 21);
            _lblContractStart.TabIndex = 31;
            _lblContractStart.Text = "Contract Start";
            //
            // dtpContractEnd
            //
            _dtpContractEnd.Location = new Point(476, 49);
            _dtpContractEnd.Name = "dtpContractEnd";
            _dtpContractEnd.Size = new Size(195, 21);
            _dtpContractEnd.TabIndex = 5;
            _dtpContractEnd.Tag = "QuoteContract.ContractEnd";
            //
            // lblContractEnd
            //
            _lblContractEnd.Location = new Point(344, 49);
            _lblContractEnd.Name = "lblContractEnd";
            _lblContractEnd.Size = new Size(103, 21);
            _lblContractEnd.TabIndex = 31;
            _lblContractEnd.Text = "Contract End";
            //
            // cboQuoteContractStatusID
            //
            _cboQuoteContractStatusID.Cursor = Cursors.Hand;
            _cboQuoteContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboQuoteContractStatusID.Location = new Point(144, 76);
            _cboQuoteContractStatusID.Name = "cboQuoteContractStatusID";
            _cboQuoteContractStatusID.Size = new Size(177, 21);
            _cboQuoteContractStatusID.TabIndex = 3;
            _cboQuoteContractStatusID.Tag = "QuoteContract.QuoteContractStatusID";
            //
            // lblQuoteContractStatusID
            //
            _lblQuoteContractStatusID.Location = new Point(14, 76);
            _lblQuoteContractStatusID.Name = "lblQuoteContractStatusID";
            _lblQuoteContractStatusID.Size = new Size(134, 21);
            _lblQuoteContractStatusID.TabIndex = 31;
            _lblQuoteContractStatusID.Text = "Quote Contract Status";
            //
            // UCQuoteContractAlternative
            //
            Controls.Add(_grpQuoteContract);
            Name = "UCQuoteContractAlternative";
            Size = new Size(754, 616);
            _grpQuoteContract.ResumeLayout(false);
            _grpSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSites).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentQuoteContract;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event RefreshButtonEventHandler RefreshButton;

        public delegate void RefreshButtonEventHandler();

        private Entity.QuoteContractAlternatives.QuoteContractAlternative _currentQuoteContract;

        public Entity.QuoteContractAlternatives.QuoteContractAlternative CurrentQuoteContract
        {
            get
            {
                return _currentQuoteContract;
            }

            set
            {
                _currentQuoteContract = value;
                if (_currentQuoteContract is null)
                {
                    _currentQuoteContract = new Entity.QuoteContractAlternatives.QuoteContractAlternative();
                    _currentQuoteContract.Exists = false;
                }

                if (_currentQuoteContract.Exists)
                {
                    Loading = true;
                    Populate();
                    lblMsg.Visible = false;
                    Loading = false;
                }
                else
                {
                    lblMsg.Visible = true;
                    txtQuoteContractPrice.Text = Strings.Format(Conversions.ToDouble(0.0), "C");
                }
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
                Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo);
            }
        }

        private DataView _Sites;

        private DataView Sites
        {
            get
            {
                return _Sites;
            }

            set
            {
                _Sites = value;
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString();
                _Sites.AllowNew = false;
                _Sites.AllowEdit = false;
                _Sites.AllowDelete = false;
                dgSites.DataSource = Sites;
            }
        }

        private DataRow SelectedSiteDataRow
        {
            get
            {
                if (!(dgSites.CurrentRowIndex == -1))
                {
                    return Sites[dgSites.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool _loading = false;

        private bool Loading
        {
            get
            {
                return _loading;
            }

            set
            {
                _loading = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupSitesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSites);
            var tStyle = dgSites.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSites.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 50;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 500;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var SitePrice = new DataGridLabelColumn();
            SitePrice.Format = "C";
            SitePrice.FormatInfo = null;
            SitePrice.HeaderText = "Property Price";
            SitePrice.MappingName = "SitePrice";
            SitePrice.ReadOnly = true;
            SitePrice.Width = 100;
            SitePrice.NullText = "";
            tStyle.GridColumnStyles.Add(SitePrice);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString();
            dgSites.TableStyles.Add(tStyle);
            Entity.Sys.Helper.RemoveEventHandlers(dgSites);
        }

        private void UCQuoteContract_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgSites_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContract.QuoteContractStatusID) != Entity.Sys.Enums.QuoteContractStatus.Generated)
                {
                    return;
                }

                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgSites.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgSites.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedSiteDataRow is null)
                {
                    return;
                }

                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgSites[dgSites.CurrentRowIndex, 0]);
                if (selected == true)
                {
                    Save();
                    var site = new Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite();
                    site.SetQuoteContractID = CurrentQuoteContract.QuoteContractID;
                    site.SetSiteID = SelectedSiteDataRow["SiteID"];
                    site = App.DB.QuoteContractAlternativeSite.Insert(site);
                    App.ShowForm(typeof(FRMQuoteContractAlternativeSite), true, new object[] { site.QuoteContractSiteID, SelectedSiteDataRow["SiteID"], CurrentQuoteContract, this });
                }
                else if (App.ShowMessage("Are you sure you want to remove this property from the quote.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    App.DB.QuoteContractAlternativeSite.Delete(Conversions.ToInteger(SelectedSiteDataRow["QuoteContractSiteID"]));
                }

                Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSites_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectedSiteDataRow is null)
                {
                    return;
                }

                bool Ticked = Entity.Sys.Helper.MakeBooleanValid(dgSites[dgSites.CurrentRowIndex, 0]);
                if (Ticked == true)
                {
                    App.ShowForm(typeof(FRMQuoteContractAlternativeSite), true, new object[] { SelectedSiteDataRow["QuoteContractSiteID"], SelectedSiteDataRow["SiteID"], CurrentQuoteContract, this });
                }
                else if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContract.QuoteContractStatusID) == Entity.Sys.Enums.QuoteContractStatus.Generated)
                {
                    App.ShowForm(typeof(FRMQuoteContractAlternativeSite), true, new object[] { 0, SelectedSiteDataRow["SiteID"], CurrentQuoteContract, this });
                }

                Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboQuoteContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IS THE FORM LOADING
            if (Loading | CurrentQuoteContract is null)
            {
                return;
            }

            // IF ADDING NEW CANNOT ACCEPT OR REJECT
            if (!CurrentQuoteContract.Exists & ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteContractStatusID)) == Entity.Sys.Enums.QuoteContractStatus.Accepted | (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteContractStatusID)) == Entity.Sys.Enums.QuoteContractStatus.Rejected))
            {
                App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var argcombo = cboQuoteContractStatusID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated).ToString());
                return;
            }

            // ACCEPTING
            if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteContractStatusID)) == Entity.Sys.Enums.QuoteContractStatus.Accepted)
            {
                MsgBoxResult msgRes;
                msgRes = (MsgBoxResult)App.ShowMessage("You are converting this quote to a live contract." + Constants.vbCrLf + "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((int)msgRes == (int)DialogResult.Yes)
                {
                    if (Save() == false)
                    {
                        return;
                    }
                }
                else if (msgRes == MsgBoxResult.Cancel)
                {
                    return;
                }

                App.ShowForm(typeof(FRMQuoteContractAlternativeConvert), true, new object[] { CurrentQuoteContract.QuoteContractID });
                var Contract = App.DB.ContractAlternative.Get_For_Quote_ID(CurrentQuoteContract.QuoteContractID);
                if (Contract is object)
                {
                    Loading = true;
                    var argcombo1 = cboQuoteContractStatusID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(Entity.Sys.Enums.QuoteContractStatus.Accepted));
                    Loading = false;
                    Save();
                    Populate(CurrentQuoteContract.QuoteContractID);
                }
                else
                {
                    var argcombo2 = cboQuoteContractStatusID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo2, Conversions.ToString(Entity.Sys.Enums.QuoteContractStatus.Generated));
                    Save();
                }
            }

            // REJECTING
            else if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteContractStatusID)) == Entity.Sys.Enums.QuoteContractStatus.Rejected)
            {
                App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { this, "" });
                Populate(CurrentQuoteContract.QuoteContractID);
            }
        }

        private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtQuoteContractPrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtQuoteContractPrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtQuoteContractPrice.Text.Replace("£", "")), "C");
            }

            txtQuoteContractPrice.Text = price;
        }

        public void RejectReasonChanged(string Reason, int ReasonID)
        {
            CurrentQuoteContract.SetReasonForReject = Reason;
            CurrentQuoteContract.SetReasonForRejectID = ReasonID;
            Save();
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            if (CurrentQuoteContract.QuoteContractID > 0)
            {
                txtQuoteContractPrice.Text = Strings.Format(App.DB.QuoteContractAlternative.CalculatedTotal(CurrentQuoteContract.QuoteContractID), "C");
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteContract = App.DB.QuoteContractAlternative.Get(ID);
            }

            if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContract.QuoteContractStatusID) != Entity.Sys.Enums.QuoteContractStatus.Generated)
            {
                Entity.Sys.Helper.MakeReadOnly(grpQuoteContract, true);
            }
            // Entity.Sys.Helper.MakeReadOnly(Me.grpSites, True)
            else
            {
                Entity.Sys.Helper.MakeReadOnly(grpQuoteContract, false);
                // Entity.Sys.Helper.MakeReadOnly(Me.grpSites, False)
            }

            txtQuoteContractReference.Text = CurrentQuoteContract.QuoteContractReference;
            dtpQuoteContractDate.Value = CurrentQuoteContract.QuoteContractDate;
            dtpContractStart.Value = CurrentQuoteContract.ContractStart;
            dtpContractEnd.Value = CurrentQuoteContract.ContractEnd;
            var argcombo = cboQuoteContractStatusID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteContract.QuoteContractStatusID.ToString());
            txtQuoteContractPrice.Text = Strings.Format(CurrentQuoteContract.QuoteContractPrice, "C");
            txtQuoteContractPrice.Text = Strings.Format(CurrentQuoteContract.QuoteContractPrice, "C");
            RefreshButton?.Invoke();
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentQuoteContract.IgnoreExceptionsOnSetMethods = true;
                CurrentQuoteContract.SetCustomerID = IDToLinkTo;
                CurrentQuoteContract.SetQuoteContractReference = txtQuoteContractReference.Text.Trim();
                CurrentQuoteContract.QuoteContractDate = dtpQuoteContractDate.Value;
                CurrentQuoteContract.ContractStart = dtpContractStart.Value;
                CurrentQuoteContract.ContractEnd = dtpContractEnd.Value;
                CurrentQuoteContract.SetQuoteContractStatusID = Combo.get_GetSelectedItemValue(cboQuoteContractStatusID);
                CurrentQuoteContract.SetQuoteContractPrice = txtQuoteContractPrice.Text.Trim().Replace("£", "");
                if (string.IsNullOrEmpty(CurrentQuoteContract.ReasonForReject) & (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContract.QuoteContractStatusID) == Entity.Sys.Enums.QuoteContractStatus.Rejected)
                {
                    CurrentQuoteContract.SetQuoteContractStatusID = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated);
                }

                if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContract.QuoteContractStatusID) == Entity.Sys.Enums.QuoteContractStatus.Accepted & App.DB.ContractAlternative.Get_For_Quote_ID(CurrentQuoteContract.QuoteContractID) is null)
                {
                    CurrentQuoteContract.SetQuoteContractStatusID = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated);
                }

                var cV = new Entity.QuoteContractAlternatives.QuoteContractAlternativeValidator();
                cV.Validate(CurrentQuoteContract);
                if (CurrentQuoteContract.Exists)
                {
                    App.DB.QuoteContractAlternative.Update(CurrentQuoteContract);
                }
                else
                {
                    CurrentQuoteContract = App.DB.QuoteContractAlternative.Insert(CurrentQuoteContract);
                }

                Populate();
                StateChanged?.Invoke(CurrentQuoteContract.QuoteContractID);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}