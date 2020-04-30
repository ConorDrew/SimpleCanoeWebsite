using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSiteCustomerAudit : FRMBaseForm, IForm
    {
        

        public FRMSiteCustomerAudit() : base()
        {
            
            
            base.Load += FRMSiteCustomerAudit_Load;

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
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private DataGrid _dgAuditTrail;

        internal DataGrid dgAuditTrail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAuditTrail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAuditTrail != null)
                {
                }

                _dgAuditTrail = value;
                if (_dgAuditTrail != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _dgAuditTrail = new DataGrid();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAuditTrail).BeginInit();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgAuditTrail);
            _GroupBox1.Location = new Point(10, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(477, 336);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            //
            // dgAuditTrail
            //
            _dgAuditTrail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAuditTrail.DataMember = "";
            _dgAuditTrail.HeaderForeColor = SystemColors.ControlText;
            _dgAuditTrail.Location = new Point(10, 19);
            _dgAuditTrail.Name = "dgAuditTrail";
            _dgAuditTrail.Size = new Size(458, 309);
            _dgAuditTrail.TabIndex = 0;
            //
            // FRMSiteCustomerAudit
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(496, 385);
            Controls.Add(_GroupBox1);
            Name = "FRMSiteCustomerAudit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Site Customer Audit";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAuditTrail).EndInit();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            AuditTrail = App.DB.SiteCustomerAudit.SiteCustomerAudit_GetAll(ID);
            LoadForm(sender, e, this);
            SetupAuditDataGrid();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
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
            }
        }

        private DataView _AuditTrail;

        private DataView AuditTrail
        {
            get
            {
                return _AuditTrail;
            }

            set
            {
                _AuditTrail = value;
                _AuditTrail.AllowDelete = false;
                _AuditTrail.AllowEdit = false;
                _AuditTrail.AllowNew = false;
                _AuditTrail.Table.TableName = "Audit";
                dgAuditTrail.DataSource = AuditTrail;
            }
        }

        
        

        public void SetupAuditDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAuditTrail);
            var tStyle = dgAuditTrail.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var PreviousCustomer = new DataGridLabelColumn();
            PreviousCustomer.Format = "";
            PreviousCustomer.FormatInfo = null;
            PreviousCustomer.HeaderText = "Previous Customer";
            PreviousCustomer.MappingName = "Name";
            PreviousCustomer.ReadOnly = true;
            PreviousCustomer.Width = 250;
            PreviousCustomer.NullText = "";
            tStyle.GridColumnStyles.Add(PreviousCustomer);
            var DateChanged = new DataGridLabelColumn();
            DateChanged.Format = "dd/MM/yyyy HH:mm:ss";
            DateChanged.FormatInfo = null;
            DateChanged.HeaderText = "Date Changed";
            DateChanged.MappingName = "DateChanged";
            DateChanged.ReadOnly = true;
            DateChanged.Width = 110;
            DateChanged.NullText = "";
            tStyle.GridColumnStyles.Add(DateChanged);
            var userFullName = new DataGridLabelColumn();
            userFullName.Format = "";
            userFullName.FormatInfo = null;
            userFullName.HeaderText = "User";
            userFullName.MappingName = "UserFullName";
            userFullName.ReadOnly = true;
            userFullName.Width = 250;
            userFullName.NullText = "";
            tStyle.GridColumnStyles.Add(userFullName);
            tStyle.ReadOnly = true;
            tStyle.MappingName = "Audit";
            dgAuditTrail.TableStyles.Add(tStyle);
        }

        private void FRMSiteCustomerAudit_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        
    }
}