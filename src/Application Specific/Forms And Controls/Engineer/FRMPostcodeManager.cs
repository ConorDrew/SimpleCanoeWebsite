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
    public class FRMPostcodeManager : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMPostcodeManager() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMPostcodeManager_Load;

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
        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private GroupBox _grpEngineers;

        internal GroupBox grpEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineers != null)
                {
                }

                _grpEngineers = value;
                if (_grpEngineers != null)
                {
                }
            }
        }

        private DataGrid _dgEngineers;

        internal DataGrid dgEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click -= dgEngineers_Clicks;
                    _dgEngineers.DoubleClick -= dgEngineers_Clicks;
                }

                _dgEngineers = value;
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click += dgEngineers_Clicks;
                    _dgEngineers.DoubleClick += dgEngineers_Clicks;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineers = new GroupBox();
            _dgEngineers = new DataGrid();
            _dgEngineers.Click += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.DoubleClick += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.Click += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.DoubleClick += new EventHandler(dgEngineers_Clicks);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _grpEngineers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).BeginInit();
            SuspendLayout();
            // 
            // grpEngineers
            // 
            _grpEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineers.Controls.Add(_dgEngineers);
            _grpEngineers.Location = new Point(8, 40);
            _grpEngineers.Name = "grpEngineers";
            _grpEngineers.Size = new Size(344, 408);
            _grpEngineers.TabIndex = 1;
            _grpEngineers.TabStop = false;
            _grpEngineers.Text = "Tick those engineers associated to this new postcode";
            // 
            // dgEngineers
            // 
            _dgEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgEngineers.DataMember = "";
            _dgEngineers.HeaderForeColor = SystemColors.ControlText;
            _dgEngineers.Location = new Point(8, 25);
            _dgEngineers.Name = "dgEngineers";
            _dgEngineers.Size = new Size(328, 375);
            _dgEngineers.TabIndex = 0;
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(8, 456);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 23);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            // 
            // FRMPostcodeManager
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(360, 486);
            Controls.Add(_btnSave);
            Controls.Add(_grpEngineers);
            MaximizeBox = false;
            MaximumSize = new Size(368, 520);
            MinimizeBox = false;
            MinimumSize = new Size(368, 520);
            Name = "FRMPostcodeManager";
            Text = "Postcode Manager";
            Controls.SetChildIndex(_grpEngineers, 0);
            Controls.SetChildIndex(_btnSave, 0);
            _grpEngineers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupEngineersDataGrid();
            PostcodeID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _PostcodeID = 0;

        public int PostcodeID
        {
            get
            {
                return _PostcodeID;
            }

            set
            {
                _PostcodeID = value;
                Engineers = App.DB.Engineer.Engineer_GetAll();
            }
        }

        private DataView _dvEngineers;

        private DataView Engineers
        {
            get
            {
                return _dvEngineers;
            }

            set
            {
                _dvEngineers = value;
                _dvEngineers.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString();
                _dvEngineers.AllowNew = false;
                _dvEngineers.AllowEdit = false;
                _dvEngineers.AllowDelete = false;
                dgEngineers.DataSource = Engineers;
            }
        }

        private DataRow SelectedEngineerDataRow
        {
            get
            {
                if (!(dgEngineers.CurrentRowIndex == -1))
                {
                    return Engineers[dgEngineers.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void FRMPostcodeManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgEngineers_Clicks(object sender, EventArgs e)
        {
            try
            {
                if (SelectedEngineerDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgEngineers[dgEngineers.CurrentRowIndex, 0]);
                dgEngineers[dgEngineers.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupEngineersDataGrid()
        {
            var tStyle = dgEngineers.TableStyles[0];
            dgEngineers.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = false;
            Tick.Width = 25;
            Tick.AllowNull = false;
            tStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineer.ToString();
            dgEngineers.TableStyles.Add(tStyle);
        }

        private void Save()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (DataRow row in Engineers.Table.Rows)
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        App.DB.EngineerPostalRegion.Insert(Conversions.ToInteger(row["EngineerID"]), PostcodeID);
                    }
                }

                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}