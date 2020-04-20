using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMPartsUsed : FRMBaseForm, IForm
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
            _grpFilter = new GroupBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _cboDepartment = new ComboBox();
            _Label6 = new Label();
            _cboEngineer = new ComboBox();
            _cboEngineer.SelectedIndexChanged += new EventHandler(cboEngineer_SelectedIndexChanged);
            _Label5 = new Label();
            _txtPartNameOrNumber = new TextBox();
            _txtPartNameOrNumber.TextChanged += new EventHandler(txtPartNameOrNumber_TextChanged);
            _Label3 = new Label();
            _txtJobPONo = new TextBox();
            _txtJobPONo.TextChanged += new EventHandler(txtJobPONo_TextChanged);
            _Label2 = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _Label1 = new Label();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpJobs = new GroupBox();
            _dgPartsUsed = new DataGrid();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpFilter.SuspendLayout();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsUsed).BeginInit();
            SuspendLayout();
            // 
            // grpFilter
            // 
            _grpFilter.Controls.Add(_Button1);
            _grpFilter.Controls.Add(_cboDepartment);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_cboEngineer);
            _grpFilter.Controls.Add(_Label5);
            _grpFilter.Controls.Add(_txtPartNameOrNumber);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_txtJobPONo);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Location = new Point(3, 39);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(898, 158);
            _grpFilter.TabIndex = 4;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            // 
            // Button1
            // 
            _Button1.AccessibleDescription = "Export Job List To Excel";
            _Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Button1.Location = new Point(815, 127);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(68, 23);
            _Button1.TabIndex = 19;
            _Button1.Text = "Filter";
            // 
            // cboDepartment
            // 
            _cboDepartment.FormattingEnabled = true;
            _cboDepartment.Location = new Point(328, 127);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(144, 21);
            _cboDepartment.TabIndex = 18;
            // 
            // Label6
            // 
            _Label6.AutoSize = true;
            _Label6.Location = new Point(235, 130);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(76, 13);
            _Label6.TabIndex = 17;
            _Label6.Text = "Cost Centre";
            // 
            // cboEngineer
            // 
            _cboEngineer.FormattingEnabled = true;
            _cboEngineer.Location = new Point(85, 127);
            _cboEngineer.Name = "cboEngineer";
            _cboEngineer.Size = new Size(144, 21);
            _cboEngineer.TabIndex = 16;
            // 
            // Label5
            // 
            _Label5.AutoSize = true;
            _Label5.Location = new Point(8, 130);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(57, 13);
            _Label5.TabIndex = 15;
            _Label5.Text = "Engineer";
            // 
            // txtPartNameOrNumber
            // 
            _txtPartNameOrNumber.Location = new Point(328, 102);
            _txtPartNameOrNumber.Name = "txtPartNameOrNumber";
            _txtPartNameOrNumber.Size = new Size(144, 21);
            _txtPartNameOrNumber.TabIndex = 14;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(235, 105);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(87, 13);
            _Label3.TabIndex = 13;
            _Label3.Text = "Part Name/No";
            // 
            // txtJobPONo
            // 
            _txtJobPONo.Location = new Point(85, 100);
            _txtJobPONo.Name = "txtJobPONo";
            _txtJobPONo.Size = new Size(144, 21);
            _txtJobPONo.TabIndex = 12;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(8, 105);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(71, 13);
            _Label2.TabIndex = 11;
            _Label2.Text = "Job P.O. No";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(851, 71);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 10;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(85, 73);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(760, 21);
            _txtSite.TabIndex = 9;
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 76);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 8;
            _Label1.Text = "Site";
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(851, 44);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 7;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(85, 46);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(760, 21);
            _txtCustomer.TabIndex = 6;
            // 
            // Label4
            // 
            _Label4.Location = new Point(8, 49);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 5;
            _Label4.Text = "Customer";
            // 
            // dtpTo
            // 
            _dtpTo.Location = new Point(328, 20);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(144, 21);
            _dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            _dtpFrom.Location = new Point(85, 20);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(144, 21);
            _dtpFrom.TabIndex = 1;
            // 
            // Label9
            // 
            _Label9.Location = new Point(298, 24);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(24, 16);
            _Label9.TabIndex = 2;
            _Label9.Text = "To";
            // 
            // Label8
            // 
            _Label8.Location = new Point(8, 22);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(88, 16);
            _Label8.TabIndex = 0;
            _Label8.Text = "Date From";
            // 
            // btnExport
            // 
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(3, 591);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 6;
            _btnExport.Text = "Export";
            // 
            // grpJobs
            // 
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgPartsUsed);
            _grpJobs.Location = new Point(3, 197);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(898, 386);
            _grpJobs.TabIndex = 5;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Double Click To View / Edit";
            // 
            // dgPartsUsed
            // 
            _dgPartsUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsUsed.DataMember = "";
            _dgPartsUsed.HeaderForeColor = SystemColors.ControlText;
            _dgPartsUsed.Location = new Point(8, 19);
            _dgPartsUsed.Name = "dgPartsUsed";
            _dgPartsUsed.Size = new Size(882, 359);
            _dgPartsUsed.TabIndex = 0;
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(67, 591);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 7;
            _btnReset.Text = "Reset";
            // 
            // FRMPartsUsed
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(913, 616);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            Name = "FRMPartsUsed";
            Text = "Parts Used";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPartsUsed).EndInit();
            Load += new EventHandler(FRMEngineerTimesheetReport_Load);
            ResumeLayout(false);
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
                    _dtpTo.ValueChanged -= dtpTo_ValueChanged;
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged += dtpTo_ValueChanged;
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
                    _dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged += dtpFrom_ValueChanged;
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
    }
}