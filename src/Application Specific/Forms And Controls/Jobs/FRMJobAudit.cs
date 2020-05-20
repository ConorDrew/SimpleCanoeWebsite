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
    public class FRMJobAudit : FRMBaseForm, IForm
    {
        

        public FRMJobAudit() : base()
        {
            base.Load += FRMJobAudit_Load;

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
        private GroupBox _grpJobAudit;

        internal GroupBox grpJobAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobAudit != null)
                {
                }

                _grpJobAudit = value;
                if (_grpJobAudit != null)
                {
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    
                    
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private DataGrid _dgJobAudits;

        internal DataGrid dgJobAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobAudits != null)
                {
                }

                _dgJobAudits = value;
                if (_dgJobAudits != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJobAudit = new System.Windows.Forms.GroupBox();
            this._dgJobAudits = new System.Windows.Forms.DataGrid();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpJobAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgJobAudits)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpJobAudit
            // 
            this._grpJobAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobAudit.Controls.Add(this._dgJobAudits);
            this._grpJobAudit.Location = new System.Drawing.Point(10, 12);
            this._grpJobAudit.Name = "_grpJobAudit";
            this._grpJobAudit.Size = new System.Drawing.Size(837, 428);
            this._grpJobAudit.TabIndex = 3;
            this._grpJobAudit.TabStop = false;
            this._grpJobAudit.Text = "Job Audit Trail";
            // 
            // _dgJobAudits
            // 
            this._dgJobAudits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgJobAudits.DataMember = "";
            this._dgJobAudits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgJobAudits.Location = new System.Drawing.Point(10, 18);
            this._dgJobAudits.Name = "_dgJobAudits";
            this._dgJobAudits.Size = new System.Drawing.Size(817, 402);
            this._dgJobAudits.TabIndex = 14;
            // 
            // _btnClose
            // 
            this._btnClose.AccessibleDescription = "Export Job List To Excel";
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(10, 454);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(67, 25);
            this._btnClose.TabIndex = 16;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMJobAudit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 481);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpJobAudit);
            this.MaximumSize = new System.Drawing.Size(864, 520);
            this.MinimumSize = new System.Drawing.Size(864, 520);
            this.Name = "FRMJobAudit";
            this.Text = "Job Audit";
            this._grpJobAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgJobAudits)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupJobAuditDataGrid();
            PopulateDatagrid();
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

        
        
        private DataView _dvJobAudits;

        private DataView JobAuditsDataview
        {
            get
            {
                return _dvJobAudits;
            }

            set
            {
                _dvJobAudits = value;
                _dvJobAudits.AllowNew = false;
                _dvJobAudits.AllowEdit = false;
                _dvJobAudits.AllowDelete = false;
                _dvJobAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString();
                dgJobAudits.DataSource = JobAuditsDataview;
            }
        }

        private DataRow SelectedJobAuditDataRow
        {
            get
            {
                if (!(dgJobAudits.CurrentRowIndex == -1))
                {
                    return JobAuditsDataview[dgJobAudits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        private void SetupJobAuditDataGrid()
        {
            var tbStyle = dgJobAudits.TableStyles[0];
            var ActionDateTime = new DataGridLabelColumn();
            ActionDateTime.Format = "dddd dd MMMM yyyy HH:mm:ss";
            ActionDateTime.FormatInfo = null;
            ActionDateTime.HeaderText = "Action Date Time";
            ActionDateTime.MappingName = "ActionDateTime";
            ActionDateTime.ReadOnly = true;
            ActionDateTime.Width = 250;
            ActionDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(ActionDateTime);
            var Fullname = new DataGridLabelColumn();
            Fullname.Format = "";
            Fullname.FormatInfo = null;
            Fullname.HeaderText = "User";
            Fullname.MappingName = "Fullname";
            Fullname.ReadOnly = true;
            Fullname.Width = 175;
            Fullname.NullText = "";
            tbStyle.GridColumnStyles.Add(Fullname);
            var ActionChange = new DataGridLabelColumn();
            ActionChange.Format = "";
            ActionChange.FormatInfo = null;
            ActionChange.HeaderText = "Action";
            ActionChange.MappingName = "ActionChange";
            ActionChange.ReadOnly = true;
            ActionChange.Width = 1000;
            ActionChange.NullText = "";
            tbStyle.GridColumnStyles.Add(ActionChange);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString();
            dgJobAudits.TableStyles.Add(tbStyle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMJobAudit_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        
        

        public void PopulateDatagrid()
        {
            try
            {
                JobAuditsDataview = App.DB.JobAudit.Get_For_Job(Conversions.ToInteger(get_GetParameter(0)));
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}