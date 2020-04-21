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
    public class UCQuoteContractOption3 : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCQuoteContractOption3() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteContractOption3_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboContractStatus;
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

        private GroupBox _grpQuoteContractOption3;

        internal GroupBox grpQuoteContractOption3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQuoteContractOption3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQuoteContractOption3 != null)
                {
                }

                _grpQuoteContractOption3 = value;
                if (_grpQuoteContractOption3 != null)
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

        private TextBox _txtContractPrice;

        internal TextBox txtContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus -= txtQuoteContractPrice_LostFocus;
                }

                _txtContractPrice = value;
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus += txtQuoteContractPrice_LostFocus;
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

        private GroupBox _gpbSite;

        internal GroupBox gpbSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbSite != null)
                {
                }

                _gpbSite = value;
                if (_gpbSite != null)
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

        private TextBox _txtContractReference;

        internal TextBox txtContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractReference != null)
                {
                }

                _txtContractReference = value;
                if (_txtContractReference != null)
                {
                }
            }
        }

        private Label _lblContractReference;

        internal Label lblContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractReference != null)
                {
                }

                _lblContractReference = value;
                if (_lblContractReference != null)
                {
                }
            }
        }

        private ComboBox _cboContractStatus;

        internal ComboBox cboContractStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractStatus != null)
                {
                    _cboContractStatus.SelectedIndexChanged -= cboQuoteContractStatusID_SelectedIndexChanged;
                }

                _cboContractStatus = value;
                if (_cboContractStatus != null)
                {
                    _cboContractStatus.SelectedIndexChanged += cboQuoteContractStatusID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblContractStatus;

        internal Label lblContractStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStatus != null)
                {
                }

                _lblContractStatus = value;
                if (_lblContractStatus != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpQuoteContractOption3 = new GroupBox();
            _btnCalculatePrice = new Button();
            _btnCalculatePrice.Click += new EventHandler(btnCalculatePrice_Click);
            _txtContractPrice = new TextBox();
            _txtContractPrice.LostFocus += new EventHandler(txtQuoteContractPrice_LostFocus);
            _Label1 = new Label();
            _lblMsg = new Label();
            _gpbSite = new GroupBox();
            _dgSites = new DataGrid();
            _dgSites.MouseUp += new MouseEventHandler(dgSites_MouseUp);
            _dgSites.DoubleClick += new EventHandler(dgSites_DoubleClick);
            _txtContractReference = new TextBox();
            _lblContractReference = new Label();
            _cboContractStatus = new ComboBox();
            _cboContractStatus.SelectedIndexChanged += new EventHandler(cboQuoteContractStatusID_SelectedIndexChanged);
            _lblContractStatus = new Label();
            _dtpQuoteContractDate = new DateTimePicker();
            _lblQuoteContractDate = new Label();
            _grpQuoteContractOption3.SuspendLayout();
            _gpbSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            SuspendLayout();
            // 
            // grpQuoteContractOption3
            // 
            _grpQuoteContractOption3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpQuoteContractOption3.Controls.Add(_btnCalculatePrice);
            _grpQuoteContractOption3.Controls.Add(_txtContractPrice);
            _grpQuoteContractOption3.Controls.Add(_Label1);
            _grpQuoteContractOption3.Controls.Add(_lblMsg);
            _grpQuoteContractOption3.Controls.Add(_gpbSite);
            _grpQuoteContractOption3.Controls.Add(_txtContractReference);
            _grpQuoteContractOption3.Controls.Add(_lblContractReference);
            _grpQuoteContractOption3.Controls.Add(_cboContractStatus);
            _grpQuoteContractOption3.Controls.Add(_lblContractStatus);
            _grpQuoteContractOption3.Controls.Add(_dtpQuoteContractDate);
            _grpQuoteContractOption3.Controls.Add(_lblQuoteContractDate);
            _grpQuoteContractOption3.Location = new Point(8, 8);
            _grpQuoteContractOption3.Name = "grpQuoteContractOption3";
            _grpQuoteContractOption3.Size = new Size(625, 594);
            _grpQuoteContractOption3.TabIndex = 1;
            _grpQuoteContractOption3.TabStop = false;
            _grpQuoteContractOption3.Text = "Main Details";
            // 
            // btnCalculatePrice
            // 
            _btnCalculatePrice.UseVisualStyleBackColor = true;
            _btnCalculatePrice.Location = new Point(348, 77);
            _btnCalculatePrice.Name = "btnCalculatePrice";
            _btnCalculatePrice.Size = new Size(266, 23);
            _btnCalculatePrice.TabIndex = 57;
            _btnCalculatePrice.Text = "Calculate Price From Property Price";
            // 
            // txtContractPrice
            // 
            _txtContractPrice.Location = new Point(136, 52);
            _txtContractPrice.MaxLength = 100;
            _txtContractPrice.Name = "txtContractPrice";
            _txtContractPrice.Size = new Size(200, 21);
            _txtContractPrice.TabIndex = 55;
            _txtContractPrice.Tag = "ContractOption3.ContractPrice";
            _txtContractPrice.Text = "";
            // 
            // Label1
            // 
            _Label1.Location = new Point(14, 52);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(99, 20);
            _Label1.TabIndex = 56;
            _Label1.Text = "Quote Price";
            // 
            // lblMsg
            // 
            _lblMsg.BackColor = Color.LightGoldenrodYellow;
            _lblMsg.BorderStyle = BorderStyle.FixedSingle;
            _lblMsg.Location = new Point(16, 77);
            _lblMsg.Name = "lblMsg";
            _lblMsg.Size = new Size(280, 23);
            _lblMsg.TabIndex = 54;
            _lblMsg.Text = "Please save before adding properties";
            _lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpbSite
            // 
            _gpbSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbSite.Controls.Add(_dgSites);
            _gpbSite.Location = new Point(10, 104);
            _gpbSite.Name = "gpbSite";
            _gpbSite.Size = new Size(603, 483);
            _gpbSite.TabIndex = 53;
            _gpbSite.TabStop = false;
            _gpbSite.Text = "Properties";
            // 
            // dgSites
            // 
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(10, 27);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(584, 447);
            _dgSites.TabIndex = 0;
            // 
            // txtContractReference
            // 
            _txtContractReference.Location = new Point(136, 28);
            _txtContractReference.MaxLength = 100;
            _txtContractReference.Name = "txtContractReference";
            _txtContractReference.Size = new Size(200, 21);
            _txtContractReference.TabIndex = 49;
            _txtContractReference.Tag = "ContractOption3.ContractReference";
            _txtContractReference.Text = "";
            // 
            // lblContractReference
            // 
            _lblContractReference.Location = new Point(14, 29);
            _lblContractReference.Name = "lblContractReference";
            _lblContractReference.Size = new Size(118, 20);
            _lblContractReference.TabIndex = 52;
            _lblContractReference.Text = "Quote Reference";
            // 
            // cboContractStatus
            // 
            _cboContractStatus.Cursor = Cursors.Hand;
            _cboContractStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractStatus.Location = new Point(455, 28);
            _cboContractStatus.Name = "cboContractStatus";
            _cboContractStatus.Size = new Size(158, 21);
            _cboContractStatus.TabIndex = 50;
            _cboContractStatus.Tag = "ContractOption3.ContractStatus";
            // 
            // lblContractStatus
            // 
            _lblContractStatus.Location = new Point(348, 29);
            _lblContractStatus.Name = "lblContractStatus";
            _lblContractStatus.Size = new Size(99, 20);
            _lblContractStatus.TabIndex = 51;
            _lblContractStatus.Text = "Quote Status";
            // 
            // dtpQuoteContractDate
            // 
            _dtpQuoteContractDate.Location = new Point(455, 52);
            _dtpQuoteContractDate.Name = "dtpQuoteContractDate";
            _dtpQuoteContractDate.Size = new Size(158, 21);
            _dtpQuoteContractDate.TabIndex = 5;
            _dtpQuoteContractDate.Tag = "QuoteContractOption3.QuoteContractDate";
            // 
            // lblQuoteContractDate
            // 
            _lblQuoteContractDate.Location = new Point(348, 52);
            _lblQuoteContractDate.Name = "lblQuoteContractDate";
            _lblQuoteContractDate.Size = new Size(99, 20);
            _lblQuoteContractDate.TabIndex = 31;
            _lblQuoteContractDate.Text = "Quote Date";
            // 
            // UCQuoteContractOption3
            // 
            Controls.Add(_grpQuoteContractOption3);
            Name = "UCQuoteContractOption3";
            Size = new Size(640, 616);
            _grpQuoteContractOption3.ResumeLayout(false);
            _gpbSite.ResumeLayout(false);
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
                return CurrentQuoteContractOption3;
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

        private Entity.QuoteContractOption3s.QuoteContractOption3 _currentQuoteContractOption3;

        public Entity.QuoteContractOption3s.QuoteContractOption3 CurrentQuoteContractOption3
        {
            get
            {
                return _currentQuoteContractOption3;
            }

            set
            {
                _currentQuoteContractOption3 = value;
                if (_currentQuoteContractOption3 is null)
                {
                    _currentQuoteContractOption3 = new Entity.QuoteContractOption3s.QuoteContractOption3();
                    _currentQuoteContractOption3.Exists = false;
                }

                if (_currentQuoteContractOption3.Exists)
                {
                    Loading = true;
                    Populate();
                    gpbSite.Enabled = true;
                    lblMsg.Visible = false;
                    Loading = false;
                }
                else
                {
                    gpbSite.Enabled = false;
                    lblMsg.Visible = true;
                    txtContractPrice.Text = Strings.Format(Conversions.ToDouble(0.0), "C");
                }

                Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(_currentQuoteContractOption3.QuoteContractID, IDToLinkTo);
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
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
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
            Site.Width = 250;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var ContractSiteReference = new DataGridLabelColumn();
            ContractSiteReference.Format = "";
            ContractSiteReference.FormatInfo = null;
            ContractSiteReference.HeaderText = "Property Reference";
            ContractSiteReference.MappingName = "QuoteContractSiteReference";
            ContractSiteReference.ReadOnly = true;
            ContractSiteReference.Width = 100;
            ContractSiteReference.NullText = "";
            tStyle.GridColumnStyles.Add(ContractSiteReference);
            var StartDate = new DataGridLabelColumn();
            StartDate.Format = "dd/MM/yyyy";
            StartDate.FormatInfo = null;
            StartDate.HeaderText = "Start Date";
            StartDate.MappingName = "StartDate";
            StartDate.ReadOnly = true;
            StartDate.Width = 75;
            StartDate.NullText = "";
            tStyle.GridColumnStyles.Add(StartDate);
            var EndDate = new DataGridLabelColumn();
            EndDate.Format = "dd/MM/yyyy";
            EndDate.FormatInfo = null;
            EndDate.HeaderText = "End Date";
            EndDate.MappingName = "EndDate";
            EndDate.ReadOnly = true;
            EndDate.Width = 75;
            EndDate.NullText = "";
            tStyle.GridColumnStyles.Add(EndDate);
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
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
            dgSites.TableStyles.Add(tStyle);
            Entity.Sys.Helper.RemoveEventHandlers(dgSites);
        }

        private void UCQuoteContractOption3_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupSitesDataGrid();
        }

        private void cboQuoteContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IS THE FORM LOADING
            if (Loading | CurrentQuoteContractOption3 is null)
            {
                return;
            }

            // IF ADDING NEW CANNOT ACCEPT OR REJECT
            if (!CurrentQuoteContractOption3.Exists & ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatus)) == Entity.Sys.Enums.QuoteContractStatus.Accepted | (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatus)) == Entity.Sys.Enums.QuoteContractStatus.Rejected))
            {
                App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var argcombo = cboContractStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated).ToString());
                return;
            }

            // ACCEPTING
            if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatus)) == Entity.Sys.Enums.QuoteContractStatus.Accepted)
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

                App.ShowForm(typeof(FRMQuoteContractOption3Convert), true, new object[] { CurrentQuoteContractOption3.QuoteContractID });
                var Contract = App.DB.ContractOption3.ContractOption3_Get_For_Quote_ID(CurrentQuoteContractOption3.QuoteContractID);
                if (Contract is object)
                {
                    Loading = true;
                    var argcombo1 = cboContractStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(Entity.Sys.Enums.QuoteContractStatus.Accepted));
                    Loading = false;
                    Save();
                    Populate(CurrentQuoteContractOption3.QuoteContractID);
                }
                else
                {
                    var argcombo2 = cboContractStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo2, Conversions.ToString(Entity.Sys.Enums.QuoteContractStatus.Generated));
                    Save();
                }
            }

            // REJECTING
            else if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatus)) == Entity.Sys.Enums.QuoteContractStatus.Rejected)
            {
                App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { this, "" });
                Populate(CurrentQuoteContractOption3.QuoteContractID);
            }
        }

        private void dgSites_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
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
                    var site = new Entity.QuoteContractOption3Sites.QuoteContractOption3Site();
                    site.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID;
                    site.SetSiteID = SelectedSiteDataRow["SiteID"];
                    site.SetQuoteContractSiteReference = App.DB.QuoteContractOption3Site.GetNextSiteReference(CurrentQuoteContractOption3.QuoteContractID);
                    site = App.DB.QuoteContractOption3Site.Insert(site);
                    App.ShowForm(typeof(FRMQuoteContractOption3Site), true, new object[] { site.QuoteContractSiteID, this });
                }
                else if (App.ShowMessage("You are about to remove this property from the quote." + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (App.DB.QuoteContractOption3Site.Delete(Conversions.ToInteger(SelectedSiteDataRow["QuoteContractSiteID"])) > 0)
                    {
                        App.ShowMessage("Could not remove property from quote as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID, IDToLinkTo);
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
                    App.ShowForm(typeof(FRMQuoteContractOption3Site), true, new object[] { SelectedSiteDataRow["QuoteContractSiteID"], this });
                }
                else
                {
                    Save();
                    var site = new Entity.QuoteContractOption3Sites.QuoteContractOption3Site();
                    site.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID;
                    site.SetSiteID = SelectedSiteDataRow["SiteID"];
                    site.SetQuoteContractSiteReference = App.DB.QuoteContractOption3Site.GetNextSiteReference(CurrentQuoteContractOption3.QuoteContractID);
                    site = App.DB.QuoteContractOption3Site.Insert(site);
                    App.ShowForm(typeof(FRMQuoteContractOption3Site), true, new object[] { site.QuoteContractSiteID, this });
                }

                Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID, IDToLinkTo);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtContractPrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtContractPrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtContractPrice.Text.Replace("£", "")), "C");
            }

            txtContractPrice.Text = price;
        }

        public void RejectReasonChanged(string Reason, int ReasonID)
        {
            CurrentQuoteContractOption3.SetReasonForReject = Reason;
            CurrentQuoteContractOption3.SetReasonForRejectID = ReasonID;
            Save();
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            if (CurrentQuoteContractOption3.QuoteContractID > 0)
            {
                txtContractPrice.Text = Strings.Format(App.DB.QuoteContractOption3.QuoteContractCalculatedTotal(CurrentQuoteContractOption3.QuoteContractID), "C");
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
            }

            if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(CurrentQuoteContractOption3.QuoteContractStatusID) != Entity.Sys.Enums.QuoteContractStatus.Generated)
            {
                Entity.Sys.Helper.MakeReadOnly(grpQuoteContractOption3, true);
            }
            else
            {
                Entity.Sys.Helper.MakeReadOnly(grpQuoteContractOption3, false);
            }

            txtContractReference.Text = CurrentQuoteContractOption3.QuoteContractReference;
            var argcombo = cboContractStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteContractOption3.QuoteContractStatusID.ToString());
            dtpQuoteContractDate.Value = CurrentQuoteContractOption3.QuoteContractDate;
            txtContractPrice.Text = Strings.Format(CurrentQuoteContractOption3.QuoteContractPrice, "C");
            RefreshButton?.Invoke();
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentQuoteContractOption3.IgnoreExceptionsOnSetMethods = true;
                CurrentQuoteContractOption3.SetCustomerID = IDToLinkTo;
                CurrentQuoteContractOption3.SetQuoteContractReference = txtContractReference.Text.Trim();
                CurrentQuoteContractOption3.SetQuoteContractStatusID = Combo.get_GetSelectedItemValue(cboContractStatus);
                CurrentQuoteContractOption3.QuoteContractDate = dtpQuoteContractDate.Value;
                CurrentQuoteContractOption3.SetQuoteContractPrice = txtContractPrice.Text.Trim().Replace("£", "");
                var cV = new Entity.QuoteContractOption3s.QuoteContractOption3Validator();
                cV.Validate(CurrentQuoteContractOption3);
                if (CurrentQuoteContractOption3.Exists)
                {
                    App.DB.QuoteContractOption3.Update(CurrentQuoteContractOption3);
                }
                else
                {
                    CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.Insert(CurrentQuoteContractOption3);
                }

                StateChanged?.Invoke(CurrentQuoteContractOption3.QuoteContractID);
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