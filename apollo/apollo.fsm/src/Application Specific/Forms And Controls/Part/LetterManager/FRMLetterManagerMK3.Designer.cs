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
            this._grpServices = new System.Windows.Forms.GroupBox();
            this._dgServicesDue = new System.Windows.Forms.DataGrid();
            this._btnResetFilters = new System.Windows.Forms.Button();
            this._grpFilters = new System.Windows.Forms.GroupBox();
            this._chkIncludePatchChecks = new System.Windows.Forms.CheckBox();
            this._chkVoidProperty = new System.Windows.Forms.CheckBox();
            this._chkLastService = new System.Windows.Forms.CheckBox();
            this._txtTravelBetween = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtMaxTravel = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._chkLettersOnly = new System.Windows.Forms.CheckBox();
            this._tbMinsPerDay = new System.Windows.Forms.TextBox();
            this._cboLetterNumber = new System.Windows.Forms.ComboBox();
            this._lbMinsPerDay = new System.Windows.Forms.Label();
            this._Label14 = new System.Windows.Forms.Label();
            this._btnFilter = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._dtpLetterCreateDate = new System.Windows.Forms.DateTimePicker();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnUnselect = new System.Windows.Forms.Button();
            this._btnGenerateLetters = new System.Windows.Forms.Button();
            this._btnReleaseLockedSites = new System.Windows.Forms.Button();
            this._btnFindSite = new System.Windows.Forms.Button();
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
            this._grpServices.Location = new System.Drawing.Point(12, 155);
            this._grpServices.Name = "_grpServices";
            this._grpServices.Size = new System.Drawing.Size(1264, 408);
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
            this._dgServicesDue.Location = new System.Drawing.Point(16, 20);
            this._dgServicesDue.Name = "_dgServicesDue";
            this._dgServicesDue.Size = new System.Drawing.Size(1248, 380);
            this._dgServicesDue.TabIndex = 14;
            this._dgServicesDue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgServicesDue_MouseClick);
            // 
            // _btnResetFilters
            // 
            this._btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnResetFilters.Location = new System.Drawing.Point(20, 569);
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
            this._grpFilters.Controls.Add(this._chkIncludePatchChecks);
            this._grpFilters.Controls.Add(this._chkVoidProperty);
            this._grpFilters.Controls.Add(this._chkLastService);
            this._grpFilters.Controls.Add(this._txtTravelBetween);
            this._grpFilters.Controls.Add(this._Label3);
            this._grpFilters.Controls.Add(this._txtMaxTravel);
            this._grpFilters.Controls.Add(this._Label2);
            this._grpFilters.Controls.Add(this._chkLettersOnly);
            this._grpFilters.Controls.Add(this._tbMinsPerDay);
            this._grpFilters.Controls.Add(this._cboLetterNumber);
            this._grpFilters.Controls.Add(this._lbMinsPerDay);
            this._grpFilters.Controls.Add(this._Label14);
            this._grpFilters.Controls.Add(this._btnFilter);
            this._grpFilters.Controls.Add(this._Label1);
            this._grpFilters.Controls.Add(this._dtpLetterCreateDate);
            this._grpFilters.Controls.Add(this._btnFindCustomer);
            this._grpFilters.Controls.Add(this._txtCustomer);
            this._grpFilters.Controls.Add(this._Label4);
            this._grpFilters.Location = new System.Drawing.Point(12, 12);
            this._grpFilters.Name = "_grpFilters";
            this._grpFilters.Size = new System.Drawing.Size(1264, 107);
            this._grpFilters.TabIndex = 5;
            this._grpFilters.TabStop = false;
            this._grpFilters.Text = "Filters";
            // 
            // _chkIncludePatchChecks
            // 
            this._chkIncludePatchChecks.AutoSize = true;
            this._chkIncludePatchChecks.Location = new System.Drawing.Point(911, 78);
            this._chkIncludePatchChecks.Name = "_chkIncludePatchChecks";
            this._chkIncludePatchChecks.Size = new System.Drawing.Size(149, 17);
            this._chkIncludePatchChecks.TabIndex = 50;
            this._chkIncludePatchChecks.Text = "Include Patch Checks";
            this._chkIncludePatchChecks.UseVisualStyleBackColor = true;
            // 
            // _chkVoidProperty
            // 
            this._chkVoidProperty.AutoSize = true;
            this._chkVoidProperty.Checked = true;
            this._chkVoidProperty.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkVoidProperty.Location = new System.Drawing.Point(755, 78);
            this._chkVoidProperty.Name = "_chkVoidProperty";
            this._chkVoidProperty.Size = new System.Drawing.Size(147, 17);
            this._chkVoidProperty.TabIndex = 49;
            this._chkVoidProperty.Text = "Show Void Properties";
            this._chkVoidProperty.UseVisualStyleBackColor = true;
            // 
            // _chkLastService
            // 
            this._chkLastService.AutoSize = true;
            this._chkLastService.Location = new System.Drawing.Point(755, 51);
            this._chkLastService.Name = "_chkLastService";
            this._chkLastService.Size = new System.Drawing.Size(150, 17);
            this._chkLastService.TabIndex = 48;
            this._chkLastService.Text = "Prioritise Last Service";
            this._chkLastService.UseVisualStyleBackColor = true;
            // 
            // _txtTravelBetween
            // 
            this._txtTravelBetween.Cursor = System.Windows.Forms.Cursors.Default;
            this._txtTravelBetween.Location = new System.Drawing.Point(686, 76);
            this._txtTravelBetween.Name = "_txtTravelBetween";
            this._txtTravelBetween.Size = new System.Drawing.Size(53, 21);
            this._txtTravelBetween.TabIndex = 46;
            this._txtTravelBetween.Text = "10";
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(465, 79);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(206, 13);
            this._Label3.TabIndex = 45;
            this._Label3.Text = "Max Travel Between AM/PM (Miles)";
            // 
            // _txtMaxTravel
            // 
            this._txtMaxTravel.Location = new System.Drawing.Point(390, 76);
            this._txtMaxTravel.Name = "_txtMaxTravel";
            this._txtMaxTravel.Size = new System.Drawing.Size(53, 21);
            this._txtMaxTravel.TabIndex = 44;
            this._txtMaxTravel.Text = "5";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(210, 79);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(174, 13);
            this._Label2.TabIndex = 43;
            this._Label2.Text = "Max Travel Per Period (Miles)";
            // 
            // _chkLettersOnly
            // 
            this._chkLettersOnly.AutoSize = true;
            this._chkLettersOnly.Location = new System.Drawing.Point(911, 51);
            this._chkLettersOnly.Name = "_chkLettersOnly";
            this._chkLettersOnly.Size = new System.Drawing.Size(161, 17);
            this._chkLettersOnly.TabIndex = 42;
            this._chkLettersOnly.Text = "Print Booked Visits only";
            this._chkLettersOnly.UseVisualStyleBackColor = true;
            this._chkLettersOnly.CheckedChanged += new System.EventHandler(this.chkLettersOnly_CheckedChanged);
            // 
            // _tbMinsPerDay
            // 
            this._tbMinsPerDay.Location = new System.Drawing.Point(142, 76);
            this._tbMinsPerDay.Name = "_tbMinsPerDay";
            this._tbMinsPerDay.Size = new System.Drawing.Size(53, 21);
            this._tbMinsPerDay.TabIndex = 5;
            this._tbMinsPerDay.Text = "275";
            // 
            // _cboLetterNumber
            // 
            this._cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLetterNumber.Location = new System.Drawing.Point(368, 50);
            this._cboLetterNumber.Name = "_cboLetterNumber";
            this._cboLetterNumber.Size = new System.Drawing.Size(371, 21);
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
            this._Label14.Location = new System.Drawing.Point(296, 52);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(75, 16);
            this._Label14.TabIndex = 40;
            this._Label14.Text = "Letter No.";
            // 
            // _btnFilter
            // 
            this._btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFilter.Location = new System.Drawing.Point(1181, 74);
            this._btnFilter.Name = "_btnFilter";
            this._btnFilter.Size = new System.Drawing.Size(75, 23);
            this._btnFilter.TabIndex = 30;
            this._btnFilter.Text = "Filter";
            this._btnFilter.UseVisualStyleBackColor = true;
            this._btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(6, 52);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(130, 16);
            this._Label1.TabIndex = 29;
            this._Label1.Text = "Letter Create Date";
            // 
            // _dtpLetterCreateDate
            // 
            this._dtpLetterCreateDate.Location = new System.Drawing.Point(142, 50);
            this._dtpLetterCreateDate.Name = "_dtpLetterCreateDate";
            this._dtpLetterCreateDate.Size = new System.Drawing.Size(138, 21);
            this._dtpLetterCreateDate.TabIndex = 28;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(1224, 20);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 26;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(142, 22);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(1076, 21);
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
            this._btnSelectAll.Location = new System.Drawing.Point(12, 126);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(119, 23);
            this._btnSelectAll.TabIndex = 6;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnUnselect
            // 
            this._btnUnselect.Location = new System.Drawing.Point(154, 126);
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
            this._btnGenerateLetters.Location = new System.Drawing.Point(1110, 569);
            this._btnGenerateLetters.Name = "_btnGenerateLetters";
            this._btnGenerateLetters.Size = new System.Drawing.Size(158, 23);
            this._btnGenerateLetters.TabIndex = 8;
            this._btnGenerateLetters.Text = "Generate Letters";
            this._btnGenerateLetters.UseVisualStyleBackColor = true;
            this._btnGenerateLetters.Click += new System.EventHandler(this.btnGenerateLetters_Click);
            // 
            // _btnReleaseLockedSites
            // 
            this._btnReleaseLockedSites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReleaseLockedSites.Location = new System.Drawing.Point(137, 569);
            this._btnReleaseLockedSites.Name = "_btnReleaseLockedSites";
            this._btnReleaseLockedSites.Size = new System.Drawing.Size(139, 23);
            this._btnReleaseLockedSites.TabIndex = 9;
            this._btnReleaseLockedSites.Text = "Release Locked Sites";
            this._btnReleaseLockedSites.UseVisualStyleBackColor = true;
            this._btnReleaseLockedSites.Click += new System.EventHandler(this.btnReleaseLockedSites_Click);
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnFindSite.Location = new System.Drawing.Point(285, 569);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(111, 23);
            this._btnFindSite.TabIndex = 47;
            this._btnFindSite.Text = "Find Site";
            this._btnFindSite.UseVisualStyleBackColor = true;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            // 
            // FRMLetterManagerMK3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 604);
            this.Controls.Add(this._btnFindSite);
            this.Controls.Add(this._btnReleaseLockedSites);
            this.Controls.Add(this._btnGenerateLetters);
            this.Controls.Add(this._btnUnselect);
            this.Controls.Add(this._btnSelectAll);
            this.Controls.Add(this._grpFilters);
            this.Controls.Add(this._btnResetFilters);
            this.Controls.Add(this._grpServices);
            this.Name = "FRMLetterManagerMK3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Letter Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMLetterManagerMK3_Load);
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