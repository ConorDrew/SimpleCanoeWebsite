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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._dgAuditTrail = new System.Windows.Forms.DataGrid();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgAuditTrail)).BeginInit();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dgAuditTrail);
            this._GroupBox1.Location = new System.Drawing.Point(10, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(477, 364);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            // 
            // _dgAuditTrail
            // 
            this._dgAuditTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgAuditTrail.DataMember = "";
            this._dgAuditTrail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAuditTrail.Location = new System.Drawing.Point(10, 19);
            this._dgAuditTrail.Name = "_dgAuditTrail";
            this._dgAuditTrail.Size = new System.Drawing.Size(458, 337);
            this._dgAuditTrail.TabIndex = 0;
            // 
            // FRMSiteCustomerAudit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(496, 385);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMSiteCustomerAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Site Customer Audit";
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgAuditTrail)).EndInit();
            this.ResumeLayout(false);

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