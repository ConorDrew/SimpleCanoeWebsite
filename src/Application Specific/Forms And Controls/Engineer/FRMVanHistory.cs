using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMVanHistory : FRMBaseForm, IForm
    {
        

        public FRMVanHistory() : base()
        {
            
            
            base.Load += FRMVanHistory_Load;

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
                }

                _dgHistory = value;
                if (_dgHistory != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpHistory = new GroupBox();
            _dgHistory = new DataGrid();
            _grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgHistory).BeginInit();
            SuspendLayout();
            //
            // grpHistory
            //
            _grpHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpHistory.Controls.Add(_dgHistory);
            _grpHistory.Location = new Point(8, 40);
            _grpHistory.Name = "grpHistory";
            _grpHistory.Size = new Size(856, 440);
            _grpHistory.TabIndex = 1;
            _grpHistory.TabStop = false;
            _grpHistory.Text = "History";
            //
            // dgHistory
            //
            _dgHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgHistory.DataMember = "";
            _dgHistory.HeaderForeColor = SystemColors.ControlText;
            _dgHistory.Location = new Point(8, 24);
            _dgHistory.Name = "dgHistory";
            _dgHistory.Size = new Size(840, 405);
            _dgHistory.TabIndex = 1;
            //
            // FRMVanHistory
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(872, 486);
            Controls.Add(_grpHistory);
            MinimumSize = new Size(880, 520);
            Name = "FRMVanHistory";
            Text = "Stock Profile History For Engineer : {0}";
            Controls.SetChildIndex(_grpHistory, 0);
            _grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgHistory).EndInit();
            ResumeLayout(false);
        }

        
        

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
                Engineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private Entity.Engineers.Engineer _Engineer = null;

        public Entity.Engineers.Engineer Engineer
        {
            get
            {
                return _Engineer;
            }

            set
            {
                _Engineer = value;
                Text = "Stock Profile History For Engineer : " + Engineer.Name;
                VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Engineer(Engineer.EngineerID, true);
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

        
        

        public void SetupDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgHistory);
            var tStyle = dgHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Van = new DataGridLabelColumn();
            Van.Format = "";
            Van.FormatInfo = null;
            Van.HeaderText = "Stock Profile Name";
            Van.MappingName = "Van";
            Van.ReadOnly = true;
            Van.Width = 330;
            Van.NullText = "";
            tStyle.GridColumnStyles.Add(Van);
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

        private void FRMVanHistory_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        
    }
}