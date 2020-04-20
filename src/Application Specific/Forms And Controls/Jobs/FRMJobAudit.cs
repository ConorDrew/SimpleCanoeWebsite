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
    public class FRMJobAudit : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            _grpJobAudit = new GroupBox();
            _dgJobAudits = new DataGrid();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpJobAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobAudits).BeginInit();
            SuspendLayout();
            // 
            // grpJobAudit
            // 
            _grpJobAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobAudit.Controls.Add(_dgJobAudits);
            _grpJobAudit.Location = new Point(10, 40);
            _grpJobAudit.Name = "grpJobAudit";
            _grpJobAudit.Size = new Size(837, 400);
            _grpJobAudit.TabIndex = 3;
            _grpJobAudit.TabStop = false;
            _grpJobAudit.Text = "Job Audit Trail";
            // 
            // dgJobAudits
            // 
            _dgJobAudits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobAudits.DataMember = "";
            _dgJobAudits.HeaderForeColor = SystemColors.ControlText;
            _dgJobAudits.Location = new Point(10, 18);
            _dgJobAudits.Name = "dgJobAudits";
            _dgJobAudits.Size = new Size(817, 374);
            _dgJobAudits.TabIndex = 14;
            // 
            // btnClose
            // 
            _btnClose.AccessibleDescription = "Export Job List To Excel";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.UseVisualStyleBackColor = true;
            _btnClose.Location = new Point(10, 454);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(67, 25);
            _btnClose.TabIndex = 16;
            _btnClose.Text = "Close";
            // 
            // FRMJobAudit
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(856, 486);
            Controls.Add(_btnClose);
            Controls.Add(_grpJobAudit);
            MaximumSize = new Size(864, 520);
            MinimumSize = new Size(864, 520);
            Name = "FRMJobAudit";
            Text = "Job Audit";
            Controls.SetChildIndex(_grpJobAudit, 0);
            Controls.SetChildIndex(_btnClose, 0);
            _grpJobAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgJobAudits).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}