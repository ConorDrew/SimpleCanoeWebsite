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
    public class FRMJobLocks : FRMBaseForm, IForm
    {
        public FRMJobLocks() : base()
        {
            base.Load += FRMJobLocks_Load;

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
        private GroupBox _grpLocks;

        private DataGrid _dgLocks;

        internal DataGrid dgLocks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgLocks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgLocks != null)
                {
                }

                _dgLocks = value;
                if (_dgLocks != null)
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

        private Button _btnUnlock;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpLocks = new System.Windows.Forms.GroupBox();
            this._dgLocks = new System.Windows.Forms.DataGrid();
            this._btnUnlock = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpLocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgLocks)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpLocks
            // 
            this._grpLocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpLocks.Controls.Add(this._dgLocks);
            this._grpLocks.Location = new System.Drawing.Point(8, 12);
            this._grpLocks.Name = "_grpLocks";
            this._grpLocks.Size = new System.Drawing.Size(769, 433);
            this._grpLocks.TabIndex = 1;
            this._grpLocks.TabStop = false;
            this._grpLocks.Text = "Highlight job to release and click \'Unlock\'";
            // 
            // _dgLocks
            // 
            this._dgLocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgLocks.DataMember = "";
            this._dgLocks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgLocks.Location = new System.Drawing.Point(8, 20);
            this._dgLocks.Name = "_dgLocks";
            this._dgLocks.Size = new System.Drawing.Size(753, 405);
            this._dgLocks.TabIndex = 1;
            // 
            // _btnUnlock
            // 
            this._btnUnlock.AccessibleDescription = "Save item";
            this._btnUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUnlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnUnlock.ImageIndex = 1;
            this._btnUnlock.Location = new System.Drawing.Point(721, 451);
            this._btnUnlock.Name = "_btnUnlock";
            this._btnUnlock.Size = new System.Drawing.Size(56, 23);
            this._btnUnlock.TabIndex = 2;
            this._btnUnlock.Text = "Unlock";
            this._btnUnlock.UseVisualStyleBackColor = true;
            this._btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // _btnClose
            // 
            this._btnClose.AccessibleDescription = "Save item";
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClose.ImageIndex = 1;
            this._btnClose.Location = new System.Drawing.Point(8, 451);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMJobLocks
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(785, 486);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpLocks);
            this.Controls.Add(this._btnUnlock);
            this.MinimumSize = new System.Drawing.Size(793, 520);
            this.Name = "FRMJobLocks";
            this.Text = "Job Locks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpLocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgLocks)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            Locks = App.DB.JobLock.GetAll();
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

        private DataView _Locks;

        private DataView Locks
        {
            get
            {
                return _Locks;
            }

            set
            {
                _Locks = value;
                _Locks.AllowNew = false;
                _Locks.AllowEdit = false;
                _Locks.AllowDelete = false;
                _Locks.Table.TableName = Entity.Sys.Enums.TableNames.tblJobLock.ToString();
                dgLocks.DataSource = Locks;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgLocks.CurrentRowIndex == -1))
                {
                    return Locks[dgLocks.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetupDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgLocks);
            var tbStyle = dgLocks.TableStyles[0];
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 150;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var FullName = new DataGridLabelColumn();
            FullName.Format = "";
            FullName.FormatInfo = null;
            FullName.HeaderText = "Locked By";
            FullName.MappingName = "FullName";
            FullName.ReadOnly = true;
            FullName.Width = 150;
            FullName.NullText = "";
            tbStyle.GridColumnStyles.Add(FullName);
            var DateLock = new DataGridLabelColumn();
            DateLock.Format = "dddd dd MMMM yyyy";
            DateLock.FormatInfo = null;
            DateLock.HeaderText = "Locked On";
            DateLock.MappingName = "DateLock";
            DateLock.ReadOnly = true;
            DateLock.Width = 250;
            DateLock.NullText = "";
            tbStyle.GridColumnStyles.Add(DateLock);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJobLock.ToString();
            dgLocks.TableStyles.Add(tbStyle);
        }

        private void FRMJobLocks_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
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

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select job to unlock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.loggedInUser.HasAccessToModule() == true)
            {
                if (App.ShowMessage("Are you sure you wish to unlock this job? The next user to access this record, will relock it.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    App.DB.JobLock.Delete(Conversions.ToInteger(SelectedDataRow["JobLockID"]));
                    Locks = App.DB.JobLock.GetAll();
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error unlocking job : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}