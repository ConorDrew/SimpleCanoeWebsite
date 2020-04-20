using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class UCJobItemAssets : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCJobItemAssets() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupAssetsDataGrid();
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
        private GroupBox _grpAssets;

        internal GroupBox grpAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssets != null)
                {
                }

                _grpAssets = value;
                if (_grpAssets != null)
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
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpAssets = new GroupBox();
            _dgAssets = new DataGrid();
            _grpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            SuspendLayout();
            // 
            // grpAssets
            // 
            _grpAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAssets.Controls.Add(_dgAssets);
            _grpAssets.Location = new Point(8, 0);
            _grpAssets.Name = "grpAssets";
            _grpAssets.Size = new Size(632, 248);
            _grpAssets.TabIndex = 0;
            _grpAssets.TabStop = false;
            _grpAssets.Text = "Appliances Included";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(8, 26);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(615, 212);
            _dgAssets.TabIndex = 2;
            // 
            // UCJobItemAssets
            // 
            Controls.Add(_grpAssets);
            Name = "UCJobItemAssets";
            Size = new Size(648, 256);
            _grpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

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
                Assets = App.DB.ContractAlternativeSiteAsset.GetAll_JobItemID(IDToLinkTo);
            }
        }

        private DataView _Assets;

        private DataView Assets
        {
            get
            {
                return _Assets;
            }

            set
            {
                _Assets = value;
                _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                _Assets.AllowNew = false;
                _Assets.AllowEdit = true;
                _Assets.AllowDelete = false;
                dgAssets.DataSource = Assets;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupAssetsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 200;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 90;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Number";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 90;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
        }

        private void UCContract_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
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