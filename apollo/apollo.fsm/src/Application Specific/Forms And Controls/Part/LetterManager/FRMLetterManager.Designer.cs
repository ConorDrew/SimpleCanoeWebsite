using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMLetterManager : FRMBaseForm, IForm
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
            this._grpServices = new System.Windows.Forms.GroupBox();
            this._dgServicesDue = new System.Windows.Forms.DataGrid();
            this._btnResetFilters = new System.Windows.Forms.Button();
            this._grpFilters = new System.Windows.Forms.GroupBox();
            this._tbMinsPerDay = new System.Windows.Forms.TextBox();
            this._cboLetterNumber = new System.Windows.Forms.ComboBox();
            this._lbMinsPerDay = new System.Windows.Forms.Label();
            this._Label14 = new System.Windows.Forms.Label();
            this._btnFilter = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._dtpLetterCreateDate = new System.Windows.Forms.DateTimePicker();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnUnselect = new System.Windows.Forms.Button();
            this._btnGenerateLetters = new System.Windows.Forms.Button();
            this._grpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgServicesDue)).BeginInit();
            this._grpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpServices
            // 
            this._grpServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpServices.Controls.Add(this._dgServicesDue);
            this._grpServices.Location = new System.Drawing.Point(12, 154);
            this._grpServices.Name = "_grpServices";
            this._grpServices.Size = new System.Drawing.Size(962, 271);
            this._grpServices.TabIndex = 3;
            this._grpServices.TabStop = false;
            this._grpServices.Text = "Services Due";
            // 
            // _dgServicesDue
            // 
            this._dgServicesDue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgServicesDue.DataMember = "";
            this._dgServicesDue.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgServicesDue.Location = new System.Drawing.Point(8, 20);
            this._dgServicesDue.Name = "_dgServicesDue";
            this._dgServicesDue.Size = new System.Drawing.Size(946, 243);
            this._dgServicesDue.TabIndex = 14;
            this._dgServicesDue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgServicesDue_MouseUp);
            // 
            // _btnResetFilters
            // 
            this._btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnResetFilters.Location = new System.Drawing.Point(20, 431);
            this._btnResetFilters.Name = "_btnResetFilters";
            this._btnResetFilters.Size = new System.Drawing.Size(111, 23);
            this._btnResetFilters.TabIndex = 4;
            this._btnResetFilters.Text = "Reset Filters";
            this._btnResetFilters.UseVisualStyleBackColor = true;
            this._btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // _grpFilters
            // 
            this._grpFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilters.Controls.Add(this._tbMinsPerDay);
            this._grpFilters.Controls.Add(this._cboLetterNumber);
            this._grpFilters.Controls.Add(this._lbMinsPerDay);
            this._grpFilters.Controls.Add(this._Label14);
            this._grpFilters.Controls.Add(this._btnFilter);
            this._grpFilters.Controls.Add(this._Label1);
            this._grpFilters.Controls.Add(this._dtpLetterCreateDate);
            this._grpFilters.Controls.Add(this._txtCustomer);
            this._grpFilters.Controls.Add(this._Label4);
            this._grpFilters.Location = new System.Drawing.Point(12, 12);
            this._grpFilters.Name = "_grpFilters";
            this._grpFilters.Size = new System.Drawing.Size(962, 107);
            this._grpFilters.TabIndex = 5;
            this._grpFilters.TabStop = false;
            this._grpFilters.Text = "Filters";
            // 
            // _tbMinsPerDay
            // 
            this._tbMinsPerDay.Location = new System.Drawing.Point(142, 76);
            this._tbMinsPerDay.Name = "_tbMinsPerDay";
            this._tbMinsPerDay.Size = new System.Drawing.Size(53, 21);
            this._tbMinsPerDay.TabIndex = 5;
            this._tbMinsPerDay.Text = "400";
            // 
            // _cboLetterNumber
            // 
            this._cboLetterNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLetterNumber.Location = new System.Drawing.Point(415, 49);
            this._cboLetterNumber.Name = "_cboLetterNumber";
            this._cboLetterNumber.Size = new System.Drawing.Size(324, 21);
            this._cboLetterNumber.TabIndex = 41;
            // 
            // _lbMinsPerDay
            // 
            this._lbMinsPerDay.AutoSize = true;
            this._lbMinsPerDay.Location = new System.Drawing.Point(6, 79);
            this._lbMinsPerDay.Name = "_lbMinsPerDay";
            this._lbMinsPerDay.Size = new System.Drawing.Size(132, 13);
            this._lbMinsPerDay.TabIndex = 4;
            this._lbMinsPerDay.Text = "Working Mins Per Day";
            // 
            // _Label14
            // 
            this._Label14.Location = new System.Drawing.Point(351, 53);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(96, 16);
            this._Label14.TabIndex = 40;
            this._Label14.Text = "Letter No.";
            // 
            // _btnFilter
            // 
            this._btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFilter.Location = new System.Drawing.Point(879, 74);
            this._btnFilter.Name = "_btnFilter";
            this._btnFilter.Size = new System.Drawing.Size(75, 23);
            this._btnFilter.TabIndex = 30;
            this._btnFilter.Text = "Filter";
            this._btnFilter.UseVisualStyleBackColor = true;
            this._btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(6, 55);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(130, 16);
            this._Label1.TabIndex = 29;
            this._Label1.Text = "Letter Create Date";
            // 
            // _dtpLetterCreateDate
            // 
            this._dtpLetterCreateDate.Location = new System.Drawing.Point(142, 50);
            this._dtpLetterCreateDate.Name = "_dtpLetterCreateDate";
            this._dtpLetterCreateDate.Size = new System.Drawing.Size(200, 21);
            this._dtpLetterCreateDate.TabIndex = 28;
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(142, 22);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(774, 21);
            this._txtCustomer.TabIndex = 25;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(6, 23);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 27;
            this._Label4.Text = "Customer";
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Location = new System.Drawing.Point(12, 125);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this._btnSelectAll.TabIndex = 6;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnUnselect
            // 
            this._btnUnselect.Location = new System.Drawing.Point(93, 125);
            this._btnUnselect.Name = "_btnUnselect";
            this._btnUnselect.Size = new System.Drawing.Size(96, 23);
            this._btnUnselect.TabIndex = 7;
            this._btnUnselect.Text = "Unselect All";
            this._btnUnselect.UseVisualStyleBackColor = true;
            this._btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // _btnGenerateLetters
            // 
            this._btnGenerateLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGenerateLetters.Location = new System.Drawing.Point(808, 431);
            this._btnGenerateLetters.Name = "_btnGenerateLetters";
            this._btnGenerateLetters.Size = new System.Drawing.Size(158, 23);
            this._btnGenerateLetters.TabIndex = 8;
            this._btnGenerateLetters.Text = "Generate Letters";
            this._btnGenerateLetters.UseVisualStyleBackColor = true;
            this._btnGenerateLetters.Click += new System.EventHandler(this.btnGenerateLetters_Click);
            // 
            // FRMLetterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 466);
            this.Controls.Add(this._btnGenerateLetters);
            this.Controls.Add(this._btnUnselect);
            this.Controls.Add(this._btnSelectAll);
            this.Controls.Add(this._grpFilters);
            this.Controls.Add(this._btnResetFilters);
            this.Controls.Add(this._grpServices);
            this.Name = "FRMLetterManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Letter Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMJobManager_Load);
            this._grpServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgServicesDue)).EndInit();
            this._grpFilters.ResumeLayout(false);
            this._grpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        private GroupBox _grpServices;

        internal GroupBox grpServices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpServices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpServices != null)
                {
                }

                _grpServices = value;
                if (_grpServices != null)
                {
                }
            }
        }

        private DataGrid _dgServicesDue;

        internal DataGrid dgServicesDue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgServicesDue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgServicesDue != null)
                {
                    _dgServicesDue.MouseUp -= dgServicesDue_MouseUp;
                }

                _dgServicesDue = value;
                if (_dgServicesDue != null)
                {
                    _dgServicesDue.MouseUp += dgServicesDue_MouseUp;
                }
            }
        }

        private Button _btnResetFilters;

        internal Button btnResetFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnResetFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnResetFilters != null)
                {
                    _btnResetFilters.Click -= btnResetFilters_Click;
                }

                _btnResetFilters = value;
                if (_btnResetFilters != null)
                {
                    _btnResetFilters.Click += btnResetFilters_Click;
                }
            }
        }

        private GroupBox _grpFilters;

        internal GroupBox grpFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilters != null)
                {
                }

                _grpFilters = value;
                if (_grpFilters != null)
                {
                }
            }
        }

        private Button _btnFilter;

        internal Button btnFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFilter != null)
                {
                    _btnFilter.Click -= btnFilter_Click;
                }

                _btnFilter = value;
                if (_btnFilter != null)
                {
                    _btnFilter.Click += btnFilter_Click;
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

        private DateTimePicker _dtpLetterCreateDate;

        internal DateTimePicker dtpLetterCreateDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpLetterCreateDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpLetterCreateDate != null)
                {
                }

                _dtpLetterCreateDate = value;
                if (_dtpLetterCreateDate != null)
                {
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

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private Button _btnUnselect;

        internal Button btnUnselect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUnselect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click -= btnUnselect_Click;
                }

                _btnUnselect = value;
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click += btnUnselect_Click;
                }
            }
        }

        private Button _btnGenerateLetters;

        internal Button btnGenerateLetters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerateLetters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerateLetters != null)
                {
                    _btnGenerateLetters.Click -= btnGenerateLetters_Click;
                }

                _btnGenerateLetters = value;
                if (_btnGenerateLetters != null)
                {
                    _btnGenerateLetters.Click += btnGenerateLetters_Click;
                }
            }
        }

        private ComboBox _cboLetterNumber;

        internal ComboBox cboLetterNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLetterNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLetterNumber != null)
                {
                }

                _cboLetterNumber = value;
                if (_cboLetterNumber != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private TextBox _tbMinsPerDay;

        internal TextBox tbMinsPerDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbMinsPerDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbMinsPerDay != null)
                {
                }

                _tbMinsPerDay = value;
                if (_tbMinsPerDay != null)
                {
                }
            }
        }

        private Label _lbMinsPerDay;

        internal Label lbMinsPerDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbMinsPerDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbMinsPerDay != null)
                {
                }

                _lbMinsPerDay = value;
                if (_lbMinsPerDay != null)
                {
                }
            }
        }
    }
}