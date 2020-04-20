using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMLetterManagerMK3 : FRMBaseForm, IForm
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
            _dgServicesDue.MouseClick += new MouseEventHandler(dgServicesDue_MouseClick);
            _btnResetFilters = new Button();
            _btnResetFilters.Click += new EventHandler(btnResetFilters_Click);
            _grpFilters = new GroupBox();
            _chkIncludePatchChecks = new CheckBox();
            _chkVoidProperty = new CheckBox();
            _chkLastService = new CheckBox();
            _txtTravelBetween = new TextBox();
            _Label3 = new Label();
            _txtMaxTravel = new TextBox();
            _Label2 = new Label();
            _chkLettersOnly = new CheckBox();
            _chkLettersOnly.CheckedChanged += new EventHandler(chkLettersOnly_CheckedChanged);
            _tbMinsPerDay = new TextBox();
            _cboLetterNumber = new ComboBox();
            _lbMinsPerDay = new Label();
            _Label14 = new Label();
            _btnFilter = new Button();
            _btnFilter.Click += new EventHandler(btnFilter_Click);
            _Label1 = new Label();
            _dtpLetterCreateDate = new DateTimePicker();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _btnGenerateLetters = new Button();
            _btnGenerateLetters.Click += new EventHandler(btnGenerateLetters_Click);
            _btnReleaseLockedSites = new Button();
            _btnReleaseLockedSites.Click += new EventHandler(btnReleaseLockedSites_Click);
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
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
            _grpServices.Size = new Size(1264, 383);
            _grpServices.TabIndex = 3;
            _grpServices.TabStop = false;
            _grpServices.Text = "Services Due";
            // 
            // dgServicesDue
            // 
            _dgServicesDue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgServicesDue.DataMember = "";
            _dgServicesDue.HeaderForeColor = SystemColors.ControlText;
            _dgServicesDue.Location = new Point(16, 20);
            _dgServicesDue.Name = "dgServicesDue";
            _dgServicesDue.Size = new Size(1248, 355);
            _dgServicesDue.TabIndex = 14;
            // 
            // btnResetFilters
            // 
            _btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnResetFilters.Location = new Point(20, 569);
            _btnResetFilters.Name = "btnResetFilters";
            _btnResetFilters.Size = new Size(111, 23);
            _btnResetFilters.TabIndex = 4;
            _btnResetFilters.Text = "Reset Filters";
            _btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // grpFilters
            // 
            _grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilters.Controls.Add(_chkIncludePatchChecks);
            _grpFilters.Controls.Add(_chkVoidProperty);
            _grpFilters.Controls.Add(_chkLastService);
            _grpFilters.Controls.Add(_txtTravelBetween);
            _grpFilters.Controls.Add(_Label3);
            _grpFilters.Controls.Add(_txtMaxTravel);
            _grpFilters.Controls.Add(_Label2);
            _grpFilters.Controls.Add(_chkLettersOnly);
            _grpFilters.Controls.Add(_tbMinsPerDay);
            _grpFilters.Controls.Add(_cboLetterNumber);
            _grpFilters.Controls.Add(_lbMinsPerDay);
            _grpFilters.Controls.Add(_Label14);
            _grpFilters.Controls.Add(_btnFilter);
            _grpFilters.Controls.Add(_Label1);
            _grpFilters.Controls.Add(_dtpLetterCreateDate);
            _grpFilters.Controls.Add(_btnFindCustomer);
            _grpFilters.Controls.Add(_txtCustomer);
            _grpFilters.Controls.Add(_Label4);
            _grpFilters.Location = new Point(12, 38);
            _grpFilters.Name = "grpFilters";
            _grpFilters.Size = new Size(1264, 107);
            _grpFilters.TabIndex = 5;
            _grpFilters.TabStop = false;
            _grpFilters.Text = "Filters";
            // 
            // chkIncludePatchChecks
            // 
            _chkIncludePatchChecks.AutoSize = true;
            _chkIncludePatchChecks.Location = new Point(911, 78);
            _chkIncludePatchChecks.Name = "chkIncludePatchChecks";
            _chkIncludePatchChecks.Size = new Size(149, 17);
            _chkIncludePatchChecks.TabIndex = 50;
            _chkIncludePatchChecks.Text = "Include Patch Checks";
            _chkIncludePatchChecks.UseVisualStyleBackColor = true;
            // 
            // chkVoidProperty
            // 
            _chkVoidProperty.AutoSize = true;
            _chkVoidProperty.Checked = true;
            _chkVoidProperty.CheckState = CheckState.Checked;
            _chkVoidProperty.Location = new Point(755, 78);
            _chkVoidProperty.Name = "chkVoidProperty";
            _chkVoidProperty.Size = new Size(147, 17);
            _chkVoidProperty.TabIndex = 49;
            _chkVoidProperty.Text = "Show Void Properties";
            _chkVoidProperty.UseVisualStyleBackColor = true;
            // 
            // chkLastService
            // 
            _chkLastService.AutoSize = true;
            _chkLastService.Location = new Point(755, 51);
            _chkLastService.Name = "chkLastService";
            _chkLastService.Size = new Size(150, 17);
            _chkLastService.TabIndex = 48;
            _chkLastService.Text = "Prioritise Last Service";
            _chkLastService.UseVisualStyleBackColor = true;
            // 
            // txtTravelBetween
            // 
            _txtTravelBetween.Cursor = Cursors.Default;
            _txtTravelBetween.Location = new Point(686, 76);
            _txtTravelBetween.Name = "txtTravelBetween";
            _txtTravelBetween.Size = new Size(53, 21);
            _txtTravelBetween.TabIndex = 46;
            _txtTravelBetween.Text = "10";
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(465, 79);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(206, 13);
            _Label3.TabIndex = 45;
            _Label3.Text = "Max Travel Between AM/PM (Miles)";
            // 
            // txtMaxTravel
            // 
            _txtMaxTravel.Location = new Point(390, 76);
            _txtMaxTravel.Name = "txtMaxTravel";
            _txtMaxTravel.Size = new Size(53, 21);
            _txtMaxTravel.TabIndex = 44;
            _txtMaxTravel.Text = "5";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(210, 79);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(174, 13);
            _Label2.TabIndex = 43;
            _Label2.Text = "Max Travel Per Period (Miles)";
            // 
            // chkLettersOnly
            // 
            _chkLettersOnly.AutoSize = true;
            _chkLettersOnly.Location = new Point(911, 51);
            _chkLettersOnly.Name = "chkLettersOnly";
            _chkLettersOnly.Size = new Size(161, 17);
            _chkLettersOnly.TabIndex = 42;
            _chkLettersOnly.Text = "Print Booked Visits only";
            _chkLettersOnly.UseVisualStyleBackColor = true;
            // 
            // tbMinsPerDay
            // 
            _tbMinsPerDay.Location = new Point(142, 76);
            _tbMinsPerDay.Name = "tbMinsPerDay";
            _tbMinsPerDay.Size = new Size(53, 21);
            _tbMinsPerDay.TabIndex = 5;
            _tbMinsPerDay.Text = "275";
            // 
            // cboLetterNumber
            // 
            _cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLetterNumber.Location = new Point(368, 50);
            _cboLetterNumber.Name = "cboLetterNumber";
            _cboLetterNumber.Size = new Size(371, 21);
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
            _Label14.Location = new Point(296, 52);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(75, 16);
            _Label14.TabIndex = 40;
            _Label14.Text = "Letter No.";
            // 
            // btnFilter
            // 
            _btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFilter.Location = new Point(1181, 74);
            _btnFilter.Name = "btnFilter";
            _btnFilter.Size = new Size(75, 23);
            _btnFilter.TabIndex = 30;
            _btnFilter.Text = "Filter";
            _btnFilter.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            _Label1.Location = new Point(6, 52);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(130, 16);
            _Label1.TabIndex = 29;
            _Label1.Text = "Letter Create Date";
            // 
            // dtpLetterCreateDate
            // 
            _dtpLetterCreateDate.Location = new Point(142, 50);
            _dtpLetterCreateDate.Name = "dtpLetterCreateDate";
            _dtpLetterCreateDate.Size = new Size(138, 21);
            _dtpLetterCreateDate.TabIndex = 28;
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(1224, 20);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 26;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(142, 22);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(1076, 21);
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
            _btnSelectAll.Size = new Size(119, 23);
            _btnSelectAll.TabIndex = 6;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnUnselect
            // 
            _btnUnselect.Location = new Point(154, 151);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 7;
            _btnUnselect.Text = "Unselect All";
            _btnUnselect.UseVisualStyleBackColor = true;
            // 
            // btnGenerateLetters
            // 
            _btnGenerateLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnGenerateLetters.Location = new Point(1110, 569);
            _btnGenerateLetters.Name = "btnGenerateLetters";
            _btnGenerateLetters.Size = new Size(158, 23);
            _btnGenerateLetters.TabIndex = 8;
            _btnGenerateLetters.Text = "Generate Letters";
            _btnGenerateLetters.UseVisualStyleBackColor = true;
            // 
            // btnReleaseLockedSites
            // 
            _btnReleaseLockedSites.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReleaseLockedSites.Location = new Point(137, 569);
            _btnReleaseLockedSites.Name = "btnReleaseLockedSites";
            _btnReleaseLockedSites.Size = new Size(139, 23);
            _btnReleaseLockedSites.TabIndex = 9;
            _btnReleaseLockedSites.Text = "Release Locked Sites";
            _btnReleaseLockedSites.UseVisualStyleBackColor = true;
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindSite.Location = new Point(285, 569);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(111, 23);
            _btnFindSite.TabIndex = 47;
            _btnFindSite.Text = "Find Site";
            _btnFindSite.UseVisualStyleBackColor = true;
            // 
            // FRMLetterManagerMK3
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 604);
            Controls.Add(_btnFindSite);
            Controls.Add(_btnReleaseLockedSites);
            Controls.Add(_btnGenerateLetters);
            Controls.Add(_btnUnselect);
            Controls.Add(_btnSelectAll);
            Controls.Add(_grpFilters);
            Controls.Add(_btnResetFilters);
            Controls.Add(_grpServices);
            Name = "FRMLetterManagerMK3";
            StartPosition = FormStartPosition.Manual;
            Text = "Letter Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpServices, 0);
            Controls.SetChildIndex(_btnResetFilters, 0);
            Controls.SetChildIndex(_grpFilters, 0);
            Controls.SetChildIndex(_btnSelectAll, 0);
            Controls.SetChildIndex(_btnUnselect, 0);
            Controls.SetChildIndex(_btnGenerateLetters, 0);
            Controls.SetChildIndex(_btnReleaseLockedSites, 0);
            Controls.SetChildIndex(_btnFindSite, 0);
            _grpServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgServicesDue).EndInit();
            _grpFilters.ResumeLayout(false);
            _grpFilters.PerformLayout();
            Load += new EventHandler(FRMLetterManagerMK3_Load);
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
                    _dgServicesDue.MouseClick -= dgServicesDue_MouseClick;
                }

                _dgServicesDue = value;
                if (_dgServicesDue != null)
                {
                    _dgServicesDue.MouseClick += dgServicesDue_MouseClick;
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

        private CheckBox _chkLettersOnly;

        internal CheckBox chkLettersOnly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLettersOnly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLettersOnly != null)
                {
                    _chkLettersOnly.CheckedChanged -= chkLettersOnly_CheckedChanged;
                }

                _chkLettersOnly = value;
                if (_chkLettersOnly != null)
                {
                    _chkLettersOnly.CheckedChanged += chkLettersOnly_CheckedChanged;
                }
            }
        }

        private Button _btnReleaseLockedSites;

        internal Button btnReleaseLockedSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReleaseLockedSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReleaseLockedSites != null)
                {
                    _btnReleaseLockedSites.Click -= btnReleaseLockedSites_Click;
                }

                _btnReleaseLockedSites = value;
                if (_btnReleaseLockedSites != null)
                {
                    _btnReleaseLockedSites.Click += btnReleaseLockedSites_Click;
                }
            }
        }

        private TextBox _txtMaxTravel;

        internal TextBox txtMaxTravel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMaxTravel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMaxTravel != null)
                {
                }

                _txtMaxTravel = value;
                if (_txtMaxTravel != null)
                {
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

        private TextBox _txtTravelBetween;

        internal TextBox txtTravelBetween
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTravelBetween;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTravelBetween != null)
                {
                }

                _txtTravelBetween = value;
                if (_txtTravelBetween != null)
                {
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

        private CheckBox _chkLastService;

        internal CheckBox chkLastService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLastService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLastService != null)
                {
                }

                _chkLastService = value;
                if (_chkLastService != null)
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

        private CheckBox _chkVoidProperty;

        internal CheckBox chkVoidProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVoidProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVoidProperty != null)
                {
                }

                _chkVoidProperty = value;
                if (_chkVoidProperty != null)
                {
                }
            }
        }

        private CheckBox _chkIncludePatchChecks;

        internal CheckBox chkIncludePatchChecks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIncludePatchChecks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIncludePatchChecks != null)
                {
                }

                _chkIncludePatchChecks = value;
                if (_chkIncludePatchChecks != null)
                {
                }
            }
        }
    }
}