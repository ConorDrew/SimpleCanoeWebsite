using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEngineerHistory : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMEngineerHistory() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMEngineerHistory_Load;

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
        private GroupBox _grpHistory;

        internal GroupBox grpHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpHistory != null)
                {
                }

                _grpHistory = value;
                if (_grpHistory != null)
                {
                }
            }
        }

        private DataGrid _dgHistory;

        internal DataGrid dgHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgHistory != null)
                {
                    _dgHistory.DoubleClick -= dgHistory_DoubleClick;
                }

                _dgHistory = value;
                if (_dgHistory != null)
                {
                    _dgHistory.DoubleClick += dgHistory_DoubleClick;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpHistory = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgHistory = new DataGrid();
            _dgHistory.DoubleClick += new EventHandler(dgHistory_DoubleClick);
            _grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgHistory).BeginInit();
            SuspendLayout();
            //
            // grpHistory
            //
            _grpHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpHistory.Controls.Add(_btnAdd);
            _grpHistory.Controls.Add(_dgHistory);
            _grpHistory.Location = new Point(8, 40);
            _grpHistory.Name = "grpHistory";
            _grpHistory.Size = new Size(856, 440);
            _grpHistory.TabIndex = 1;
            _grpHistory.TabStop = false;
            _grpHistory.Text = "Double Click To View / Edit";
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(8, 408);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(64, 23);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            //
            // dgHistory
            //
            _dgHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgHistory.DataMember = "";
            _dgHistory.HeaderForeColor = SystemColors.ControlText;
            _dgHistory.Location = new Point(8, 26);
            _dgHistory.Name = "dgHistory";
            _dgHistory.Size = new Size(840, 374);
            _dgHistory.TabIndex = 1;
            //
            // FRMEngineerHistory
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(872, 486);
            Controls.Add(_grpHistory);
            MinimumSize = new Size(880, 520);
            Name = "FRMEngineerHistory";
            Text = "Engineer History For Profile : {0}";
            Controls.SetChildIndex(_grpHistory, 0);
            _grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgHistory).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            LoadForm(sender, e, this);
            SetupDataGrid();
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
        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                Van = App.DB.Van.Van_Get(ID);
            }
        }

        private Entity.Vans.Van _Van = null;

        public Entity.Vans.Van Van
        {
            get
            {
                return _Van;
            }

            set
            {
                _Van = value;
                Text = "Engineer History For Profile : " + Van.Registration;
                VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
            }
        }

        private DataView _VanHistory;

        public DataView VanHistory
        {
            get
            {
                return _VanHistory;
            }

            set
            {
                _VanHistory = value;
                _VanHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString();
                _VanHistory.AllowNew = false;
                _VanHistory.AllowEdit = false;
                _VanHistory.AllowDelete = false;
                dgHistory.DataSource = VanHistory;
            }
        }

        private DataRow SelectedHistoryDataRow
        {
            get
            {
                if (!(dgHistory.CurrentRowIndex == -1))
                {
                    return VanHistory[dgHistory.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgHistory);
            var tStyle = dgHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 330;
            Engineer.NullText = "";
            tStyle.GridColumnStyles.Add(Engineer);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dddd dd MMMM yyyy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "From";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 250;
            StartDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dddd dd MMMM yyyy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "To";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 250;
            EndDateTime.NullText = "Until Further Notice";
            tStyle.GridColumnStyles.Add(EndDateTime);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString();
            dgHistory.TableStyles.Add(tStyle);
        }

        private void FRMEngineerHistory_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerVan), true, new object[] { 0, Van.VanID, this });
            VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
        }

        private void dgHistory_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedHistoryDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMEngineerVan), true, new object[] { SelectedHistoryDataRow["EngineerVanID"], Van.VanID, this });
            VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
        }

        // Private Sub frmProgramma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        // If MessageBox.Show("Are you sur to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        // Else
        // e.Cancel = True
        // End If
        // End Sub

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}