using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMEquipmentUsed : FRMBaseForm, IForm
    {


        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._Button1 = new System.Windows.Forms.Button();
            this._cboDepartment = new System.Windows.Forms.ComboBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboEngineer = new System.Windows.Forms.ComboBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._txtPartNameOrNumber = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtJobPONo = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgPartsUsed = new System.Windows.Forms.DataGrid();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._grpFilter.SuspendLayout();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsUsed)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpFilter
            // 
            this._grpFilter.Controls.Add(this._Button1);
            this._grpFilter.Controls.Add(this._cboDepartment);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._cboEngineer);
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._txtPartNameOrNumber);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._txtJobPONo);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Location = new System.Drawing.Point(3, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(898, 158);
            this._grpFilter.TabIndex = 4;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _Button1
            // 
            this._Button1.AccessibleDescription = "Export Job List To Excel";
            this._Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Button1.Location = new System.Drawing.Point(815, 127);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(68, 23);
            this._Button1.TabIndex = 19;
            this._Button1.Text = "Filter";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _cboDepartment
            // 
            this._cboDepartment.FormattingEnabled = true;
            this._cboDepartment.Location = new System.Drawing.Point(328, 127);
            this._cboDepartment.Name = "_cboDepartment";
            this._cboDepartment.Size = new System.Drawing.Size(144, 21);
            this._cboDepartment.TabIndex = 18;
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(235, 130);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(75, 13);
            this._Label6.TabIndex = 17;
            this._Label6.Text = "Department";
            // 
            // _cboEngineer
            // 
            this._cboEngineer.FormattingEnabled = true;
            this._cboEngineer.Location = new System.Drawing.Point(85, 127);
            this._cboEngineer.Name = "_cboEngineer";
            this._cboEngineer.Size = new System.Drawing.Size(144, 21);
            this._cboEngineer.TabIndex = 16;
            this._cboEngineer.SelectedIndexChanged += new System.EventHandler(this.cboEngineer_SelectedIndexChanged);
            // 
            // _Label5
            // 
            this._Label5.AutoSize = true;
            this._Label5.Location = new System.Drawing.Point(8, 130);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(57, 13);
            this._Label5.TabIndex = 15;
            this._Label5.Text = "Engineer";
            // 
            // _txtPartNameOrNumber
            // 
            this._txtPartNameOrNumber.Location = new System.Drawing.Point(328, 102);
            this._txtPartNameOrNumber.Name = "_txtPartNameOrNumber";
            this._txtPartNameOrNumber.Size = new System.Drawing.Size(144, 21);
            this._txtPartNameOrNumber.TabIndex = 14;
            this._txtPartNameOrNumber.TextChanged += new System.EventHandler(this.txtPartNameOrNumber_TextChanged);
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(235, 105);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(87, 13);
            this._Label3.TabIndex = 13;
            this._Label3.Text = "Part Name/No";
            // 
            // _txtJobPONo
            // 
            this._txtJobPONo.Location = new System.Drawing.Point(85, 100);
            this._txtJobPONo.Name = "_txtJobPONo";
            this._txtJobPONo.Size = new System.Drawing.Size(144, 21);
            this._txtJobPONo.TabIndex = 12;
            this._txtJobPONo.TextChanged += new System.EventHandler(this.txtJobPONo_TextChanged);
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(8, 105);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(71, 13);
            this._Label2.TabIndex = 11;
            this._Label2.Text = "Job P.O. No";
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindSite.BackColor = System.Drawing.Color.White;
            this._btnFindSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindSite.Location = new System.Drawing.Point(851, 71);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(32, 23);
            this._btnFindSite.TabIndex = 10;
            this._btnFindSite.Text = "...";
            this._btnFindSite.UseVisualStyleBackColor = false;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            // 
            // _txtSite
            // 
            this._txtSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSite.Location = new System.Drawing.Point(85, 73);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(760, 21);
            this._txtSite.TabIndex = 9;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 76);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 8;
            this._Label1.Text = "Site";
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(851, 44);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 7;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(85, 46);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(760, 21);
            this._txtCustomer.TabIndex = 6;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 49);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 5;
            this._Label4.Text = "Customer";
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(328, 20);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(144, 21);
            this._dtpTo.TabIndex = 3;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(85, 20);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(144, 21);
            this._dtpFrom.TabIndex = 1;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(298, 24);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(24, 16);
            this._Label9.TabIndex = 2;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(8, 22);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(88, 16);
            this._Label8.TabIndex = 0;
            this._Label8.Text = "Date From";
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(3, 591);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 6;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgPartsUsed);
            this._grpJobs.Location = new System.Drawing.Point(3, 176);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(898, 407);
            this._grpJobs.TabIndex = 5;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Double Click To View / Edit";
            // 
            // _dgPartsUsed
            // 
            this._dgPartsUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgPartsUsed.DataMember = "";
            this._dgPartsUsed.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsUsed.Location = new System.Drawing.Point(8, 19);
            this._dgPartsUsed.Name = "_dgPartsUsed";
            this._dgPartsUsed.Size = new System.Drawing.Size(882, 380);
            this._dgPartsUsed.TabIndex = 0;
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(67, 591);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 7;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Export Job List To Excel";
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Location = new System.Drawing.Point(818, 591);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(68, 23);
            this._btnDelete.TabIndex = 20;
            this._btnDelete.Text = "Delete";
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FRMEquipmentUsed
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(913, 616);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.Name = "FRMEquipmentUsed";
            this.Text = "Equipment Used";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMEngineerTimesheetReport_Load);
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsUsed)).EndInit();
            this.ResumeLayout(false);

        }

        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private Button _btnFindCustomer;

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

        private GroupBox _grpJobs;

        internal GroupBox grpJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobs != null)
                {
                }

                _grpJobs = value;
                if (_grpJobs != null)
                {
                }
            }
        }

        private DataGrid _dgPartsUsed;

        internal DataGrid dgPartsUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsUsed != null)
                {
                }

                _dgPartsUsed = value;
                if (_dgPartsUsed != null)
                {
                }
            }
        }

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }

        private ComboBox _cboEngineer;

        internal ComboBox cboEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineer != null)
                {
                    _cboEngineer.SelectedIndexChanged -= cboEngineer_SelectedIndexChanged;
                }

                _cboEngineer = value;
                if (_cboEngineer != null)
                {
                    _cboEngineer.SelectedIndexChanged += cboEngineer_SelectedIndexChanged;
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private TextBox _txtPartNameOrNumber;

        internal TextBox txtPartNameOrNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartNameOrNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartNameOrNumber != null)
                {
                    _txtPartNameOrNumber.TextChanged -= txtPartNameOrNumber_TextChanged;
                }

                _txtPartNameOrNumber = value;
                if (_txtPartNameOrNumber != null)
                {
                    _txtPartNameOrNumber.TextChanged += txtPartNameOrNumber_TextChanged;
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private TextBox _txtJobPONo;

        internal TextBox txtJobPONo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobPONo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobPONo != null)
                {
                    _txtJobPONo.TextChanged -= txtJobPONo_TextChanged;
                }

                _txtJobPONo = value;
                if (_txtJobPONo != null)
                {
                    _txtJobPONo.TextChanged += txtJobPONo_TextChanged;
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private ComboBox _cboDepartment;

        internal ComboBox cboDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDepartment != null)
                {
                }

                _cboDepartment = value;
                if (_cboDepartment != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }
    }
}