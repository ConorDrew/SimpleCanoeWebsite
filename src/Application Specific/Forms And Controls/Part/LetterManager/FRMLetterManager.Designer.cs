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
            _grpServices = new GroupBox();
            _dgServicesDue = new DataGrid();
            _dgServicesDue.MouseUp += new MouseEventHandler(dgServicesDue_MouseUp);
            _btnResetFilters = new Button();
            _btnResetFilters.Click += new EventHandler(btnResetFilters_Click);
            _grpFilters = new GroupBox();
            _tbMinsPerDay = new TextBox();
            _cboLetterNumber = new ComboBox();
            _lbMinsPerDay = new Label();
            _Label14 = new Label();
            _btnFilter = new Button();
            _btnFilter.Click += new EventHandler(btnFilter_Click);
            _Label1 = new Label();
            _dtpLetterCreateDate = new DateTimePicker();
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _btnGenerateLetters = new Button();
            _btnGenerateLetters.Click += new EventHandler(btnGenerateLetters_Click);
            _grpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgServicesDue).BeginInit();
            _grpFilters.SuspendLayout();
            SuspendLayout();
            // 
            // grpServices
            // 
            _grpServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpServices.Controls.Add(_dgServicesDue);
            _grpServices.Location = new Point(12, 180);
            _grpServices.Name = "grpServices";
            _grpServices.Size = new Size(962, 245);
            _grpServices.TabIndex = 3;
            _grpServices.TabStop = false;
            _grpServices.Text = "Services Due";
            // 
            // dgServicesDue
            // 
            _dgServicesDue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgServicesDue.DataMember = "";
            _dgServicesDue.HeaderForeColor = SystemColors.ControlText;
            _dgServicesDue.Location = new Point(8, 20);
            _dgServicesDue.Name = "dgServicesDue";
            _dgServicesDue.Size = new Size(946, 217);
            _dgServicesDue.TabIndex = 14;
            // 
            // btnResetFilters
            // 
            _btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnResetFilters.Location = new Point(20, 431);
            _btnResetFilters.Name = "btnResetFilters";
            _btnResetFilters.Size = new Size(111, 23);
            _btnResetFilters.TabIndex = 4;
            _btnResetFilters.Text = "Reset Filters";
            _btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // grpFilters
            // 
            _grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilters.Controls.Add(_tbMinsPerDay);
            _grpFilters.Controls.Add(_cboLetterNumber);
            _grpFilters.Controls.Add(_lbMinsPerDay);
            _grpFilters.Controls.Add(_Label14);
            _grpFilters.Controls.Add(_btnFilter);
            _grpFilters.Controls.Add(_Label1);
            _grpFilters.Controls.Add(_dtpLetterCreateDate);
            _grpFilters.Controls.Add(_txtCustomer);
            _grpFilters.Controls.Add(_Label4);
            _grpFilters.Location = new Point(12, 38);
            _grpFilters.Name = "grpFilters";
            _grpFilters.Size = new Size(962, 107);
            _grpFilters.TabIndex = 5;
            _grpFilters.TabStop = false;
            _grpFilters.Text = "Filters";
            // 
            // tbMinsPerDay
            // 
            _tbMinsPerDay.Location = new Point(142, 76);
            _tbMinsPerDay.Name = "tbMinsPerDay";
            _tbMinsPerDay.Size = new Size(53, 21);
            _tbMinsPerDay.TabIndex = 5;
            _tbMinsPerDay.Text = "400";
            // 
            // cboLetterNumber
            // 
            _cboLetterNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLetterNumber.Location = new Point(415, 49);
            _cboLetterNumber.Name = "cboLetterNumber";
            _cboLetterNumber.Size = new Size(324, 21);
            _cboLetterNumber.TabIndex = 41;
            // 
            // lbMinsPerDay
            // 
            _lbMinsPerDay.AutoSize = true;
            _lbMinsPerDay.Location = new Point(6, 79);
            _lbMinsPerDay.Name = "lbMinsPerDay";
            _lbMinsPerDay.Size = new Size(132, 13);
            _lbMinsPerDay.TabIndex = 4;
            _lbMinsPerDay.Text = "Working Mins Per Day";
            // 
            // Label14
            // 
            _Label14.Location = new Point(351, 53);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(96, 16);
            _Label14.TabIndex = 40;
            _Label14.Text = "Letter No.";
            // 
            // btnFilter
            // 
            _btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFilter.Location = new Point(879, 74);
            _btnFilter.Name = "btnFilter";
            _btnFilter.Size = new Size(75, 23);
            _btnFilter.TabIndex = 30;
            _btnFilter.Text = "Filter";
            _btnFilter.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            _Label1.Location = new Point(6, 55);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(130, 16);
            _Label1.TabIndex = 29;
            _Label1.Text = "Letter Create Date";
            // 
            // dtpLetterCreateDate
            // 
            _dtpLetterCreateDate.Location = new Point(142, 50);
            _dtpLetterCreateDate.Name = "dtpLetterCreateDate";
            _dtpLetterCreateDate.Size = new Size(200, 21);
            _dtpLetterCreateDate.TabIndex = 28;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(142, 22);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(774, 21);
            _txtCustomer.TabIndex = 25;
            // 
            // Label4
            // 
            _Label4.Location = new Point(6, 23);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 27;
            _Label4.Text = "Customer";
            // 
            // btnSelectAll
            // 
            _btnSelectAll.Location = new Point(12, 151);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(75, 23);
            _btnSelectAll.TabIndex = 6;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnUnselect
            // 
            _btnUnselect.Location = new Point(93, 151);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 7;
            _btnUnselect.Text = "Unselect All";
            _btnUnselect.UseVisualStyleBackColor = true;
            // 
            // btnGenerateLetters
            // 
            _btnGenerateLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnGenerateLetters.Location = new Point(808, 431);
            _btnGenerateLetters.Name = "btnGenerateLetters";
            _btnGenerateLetters.Size = new Size(158, 23);
            _btnGenerateLetters.TabIndex = 8;
            _btnGenerateLetters.Text = "Generate Letters";
            _btnGenerateLetters.UseVisualStyleBackColor = true;
            // 
            // FRMLetterManager
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 466);
            Controls.Add(_btnGenerateLetters);
            Controls.Add(_btnUnselect);
            Controls.Add(_btnSelectAll);
            Controls.Add(_grpFilters);
            Controls.Add(_btnResetFilters);
            Controls.Add(_grpServices);
            Name = "FRMLetterManager";
            StartPosition = FormStartPosition.Manual;
            Text = "Letter Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpServices, 0);
            Controls.SetChildIndex(_btnResetFilters, 0);
            Controls.SetChildIndex(_grpFilters, 0);
            Controls.SetChildIndex(_btnSelectAll, 0);
            Controls.SetChildIndex(_btnUnselect, 0);
            Controls.SetChildIndex(_btnGenerateLetters, 0);
            _grpServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgServicesDue).EndInit();
            _grpFilters.ResumeLayout(false);
            _grpFilters.PerformLayout();
            Load += new EventHandler(FRMJobManager_Load);
            ResumeLayout(false);
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