using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMPostcodeManager : FRMBaseForm, IForm
    {
        

        public FRMPostcodeManager() : base()
        {
            
            
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
            this._grpEngineers = new System.Windows.Forms.GroupBox();
            this._dgEngineers = new System.Windows.Forms.DataGrid();
            this._btnSave = new System.Windows.Forms.Button();
            this._grpEngineers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpEngineers
            // 
            this._grpEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpEngineers.Controls.Add(this._dgEngineers);
            this._grpEngineers.Location = new System.Drawing.Point(8, 12);
            this._grpEngineers.Name = "_grpEngineers";
            this._grpEngineers.Size = new System.Drawing.Size(344, 436);
            this._grpEngineers.TabIndex = 1;
            this._grpEngineers.TabStop = false;
            this._grpEngineers.Text = "Tick those engineers associated to this new postcode";
            // 
            // _dgEngineers
            // 
            this._dgEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgEngineers.DataMember = "";
            this._dgEngineers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgEngineers.Location = new System.Drawing.Point(8, 25);
            this._dgEngineers.Name = "_dgEngineers";
            this._dgEngineers.Size = new System.Drawing.Size(328, 403);
            this._dgEngineers.TabIndex = 0;
            this._dgEngineers.Click += new System.EventHandler(this.dgEngineers_Clicks);
            this._dgEngineers.DoubleClick += new System.EventHandler(this.dgEngineers_Clicks);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 456);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 23);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMPostcodeManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(352, 481);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._grpEngineers);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(368, 520);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(368, 520);
            this.Name = "FRMPostcodeManager";
            this.Text = "Postcode Manager";
            this._grpEngineers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
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

        public void ResetMe(int newID)
        {
        }

        
        
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

        
    }
}