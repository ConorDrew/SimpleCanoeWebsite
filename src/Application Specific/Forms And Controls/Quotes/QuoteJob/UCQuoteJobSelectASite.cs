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
    public class UCQuoteJobSelectASite : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCQuoteJobSelectASite() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteJob_Load;

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
                }

                _dgSites = value;
                if (_dgSites != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSites = new GroupBox();
            _dgSites = new DataGrid();
            _grpSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            SuspendLayout();
            //
            // grpSites
            //
            _grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSites.Controls.Add(_dgSites);
            _grpSites.Location = new Point(8, 0);
            _grpSites.Name = "grpSites";
            _grpSites.Size = new Size(608, 288);
            _grpSites.TabIndex = 28;
            _grpSites.TabStop = false;
            _grpSites.Text = "Select A Property For The Quote:";
            //
            // dgSites
            //
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(8, 26);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(592, 254);
            _dgSites.TabIndex = 1;
            //
            // UCQuoteJobSelectASite
            //
            Controls.Add(_grpSites);
            Name = "UCQuoteJobSelectASite";
            Size = new Size(624, 296);
            _grpSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSites).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupSiteDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return SelectedSiteDataRow;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event SiteSelectedEventHandler SiteSelected;

        public delegate void SiteSelectedEventHandler(int SiteID);

        private DataView _Sites = null;

        public DataView Sites
        {
            get
            {
                return _Sites;
            }

            set
            {
                _Sites = value;
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString();
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

        private void UCQuoteJob_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupSiteDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSites);
            var tStyle = dgSites.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 100;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 100;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            var HeadOffice = new DataGridLabelColumn();
            HeadOffice.Format = "";
            HeadOffice.FormatInfo = null;
            HeadOffice.HeaderText = "HO";
            HeadOffice.MappingName = "HeadOfficeResult";
            HeadOffice.ReadOnly = true;
            HeadOffice.Width = 75;
            HeadOffice.NullText = "";
            tStyle.GridColumnStyles.Add(HeadOffice);
            var Region = new DataGridLabelColumn();
            Region.Format = "";
            Region.FormatInfo = null;
            Region.HeaderText = "Region";
            Region.MappingName = "Region";
            Region.ReadOnly = true;
            Region.Width = 100;
            Region.NullText = "";
            tStyle.GridColumnStyles.Add(Region);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSite.ToString();
            dgSites.TableStyles.Add(tStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            Sites = App.DB.Sites.GetForCustomer_Light(ID, App.loggedInUser.UserID);
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (SelectedSiteDataRow is null)
                {
                    SiteSelected?.Invoke(0);
                    return false;
                }
                else
                {
                    SiteSelected?.Invoke(Conversions.ToInteger(SelectedSiteDataRow["SiteID"]));
                    return true;
                }
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