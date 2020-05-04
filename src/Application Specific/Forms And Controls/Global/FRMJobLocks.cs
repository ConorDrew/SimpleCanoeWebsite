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
            _grpLocks = new GroupBox();
            _dgLocks = new DataGrid();
            _btnUnlock = new Button();
            _btnUnlock.Click += new EventHandler(btnUnlock_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpLocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgLocks).BeginInit();
            SuspendLayout();
            //
            // grpLocks
            //
            _grpLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpLocks.Controls.Add(_dgLocks);
            _grpLocks.Location = new Point(8, 40);
            _grpLocks.Name = "grpLocks";
            _grpLocks.Size = new Size(769, 405);
            _grpLocks.TabIndex = 1;
            _grpLocks.TabStop = false;
            _grpLocks.Text = "Highlight job to release and click 'Unlock'";
            //
            // dgLocks
            //
            _dgLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgLocks.DataMember = "";
            _dgLocks.HeaderForeColor = SystemColors.ControlText;
            _dgLocks.Location = new Point(8, 20);
            _dgLocks.Name = "dgLocks";
            _dgLocks.Size = new Size(753, 377);
            _dgLocks.TabIndex = 1;
            //
            // btnUnlock
            //
            _btnUnlock.AccessibleDescription = "Save item";
            _btnUnlock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUnlock.Cursor = Cursors.Hand;
            _btnUnlock.UseVisualStyleBackColor = true;
            _btnUnlock.ImageIndex = 1;
            _btnUnlock.Location = new Point(721, 451);
            _btnUnlock.Name = "btnUnlock";
            _btnUnlock.Size = new Size(56, 23);
            _btnUnlock.TabIndex = 2;
            _btnUnlock.Text = "Unlock";
            //
            // btnClose
            //
            _btnClose.AccessibleDescription = "Save item";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.UseVisualStyleBackColor = true;
            _btnClose.ImageIndex = 1;
            _btnClose.Location = new Point(8, 451);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            //
            // FRMJobLocks
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(785, 486);
            Controls.Add(_btnClose);
            Controls.Add(_grpLocks);
            Controls.Add(_btnUnlock);
            MinimumSize = new Size(793, 520);
            Name = "FRMJobLocks";
            Text = "Job Locks";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnUnlock, 0);
            Controls.SetChildIndex(_grpLocks, 0);
            Controls.SetChildIndex(_btnClose, 0);
            _grpLocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgLocks).EndInit();
            ResumeLayout(false);
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