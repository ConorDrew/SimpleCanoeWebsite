using FSM.Entity.Orders;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.Sys;
using FSM.Importer;
using LinqToExcel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSupplierInvoiceImporter : FRMBaseForm
    {
        

        public FRMSupplierInvoiceImporter() : base()
        {
            
            
            this.Load += FRMSupplierInvoiceImporter_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboValidateType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);

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
        private GroupBox _grpExcelFile;

        internal GroupBox grpExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpExcelFile != null)
                {
                }

                _grpExcelFile = value;
                if (_grpExcelFile != null)
                {
                }
            }
        }

        private TabControl _tcData;

        internal TabControl tcData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcData != null)
                {
                }

                _tcData = value;
                if (_tcData != null)
                {
                }
            }
        }

        private ProgressBar _pbStatus;

        internal ProgressBar pbStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStatus != null)
                {
                }

                _pbStatus = value;
                if (_pbStatus != null)
                {
                }
            }
        }

        private Label _lblMessages;

        internal Label lblMessages
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMessages;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMessages != null)
                {
                }

                _lblMessages = value;
                if (_lblMessages != null)
                {
                }
            }
        }

        private Button _btnExportResults;

        internal Button btnExportResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportResults != null)
                {
                    _btnExportResults.Click -= btnExportResults_Click;
                }

                _btnExportResults = value;
                if (_btnExportResults != null)
                {
                    _btnExportResults.Click += btnExportResults_Click;
                }
            }
        }

        private ComboBox _cboValidateType;

        internal ComboBox cboValidateType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboValidateType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboValidateType != null)
                {
                    _cboValidateType.SelectedIndexChanged -= cboValidateType_SelectedIndexChanged;
                }

                _cboValidateType = value;
                if (_cboValidateType != null)
                {
                    _cboValidateType.SelectedIndexChanged += cboValidateType_SelectedIndexChanged;
                }
            }
        }

        private Button _btnProcessIndiv;

        internal Button btnProcessIndiv
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnProcessIndiv;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnProcessIndiv != null)
                {
                    _btnProcessIndiv.Click -= btnProcessIndiv_Click;
                }

                _btnProcessIndiv = value;
                if (_btnProcessIndiv != null)
                {
                    _btnProcessIndiv.Click += btnProcessIndiv_Click;
                }
            }
        }

        private GroupBox _grpCatImport;

        internal GroupBox grpCatImport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCatImport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCatImport != null)
                {
                }

                _grpCatImport = value;
                if (_grpCatImport != null)
                {
                }
            }
        }

        private Label _lbl_Stats;

        internal Label lbl_Stats
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbl_Stats;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbl_Stats != null)
                {
                }

                _lbl_Stats = value;
                if (_lbl_Stats != null)
                {
                }
            }
        }

        private Label _lblFile;

        internal Label lblFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFile != null)
                {
                }

                _lblFile = value;
                if (_lblFile != null)
                {
                }
            }
        }

        private TextBox _txtExcelFile;

        internal TextBox txtExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExcelFile != null)
                {
                }

                _txtExcelFile = value;
                if (_txtExcelFile != null)
                {
                }
            }
        }

        private Button _btnFindSupplier;

        internal Button btnFindSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSupplier != null)
                {
                    _btnFindSupplier.Click -= btnFindSupplier_Click;
                }

                _btnFindSupplier = value;
                if (_btnFindSupplier != null)
                {
                    _btnFindSupplier.Click += btnFindSupplier_Click;
                }
            }
        }

        private Button _btnImport;

        internal Button btnImport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnImport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnImport != null)
                {
                    _btnImport.Click -= btnImport_Click;
                }

                _btnImport = value;
                if (_btnImport != null)
                {
                    _btnImport.Click += btnImport_Click;
                }
            }
        }

        private Button _btnFindExcelFile;

        internal Button btnFindExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindExcelFile != null)
                {
                    _btnFindExcelFile.Click -= btnFindExcelFile_Click;
                }

                _btnFindExcelFile = value;
                if (_btnFindExcelFile != null)
                {
                    _btnFindExcelFile.Click += btnFindExcelFile_Click;
                }
            }
        }

        private TextBox _txtSupplier;

        internal TextBox txtSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplier != null)
                {
                }

                _txtSupplier = value;
                if (_txtSupplier != null)
                {
                }
            }
        }

        private Label _lblSupplier;

        internal Label lblSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplier != null)
                {
                }

                _lblSupplier = value;
                if (_lblSupplier != null)
                {
                }
            }
        }

        private LinkLabel _lblDownloadTemplate;

        internal LinkLabel lblDownloadTemplate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDownloadTemplate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDownloadTemplate != null)
                {
                    _lblDownloadTemplate.LinkClicked -= lblDownloadTemplate_LinkClicked;
                }

                _lblDownloadTemplate = value;
                if (_lblDownloadTemplate != null)
                {
                    _lblDownloadTemplate.LinkClicked += lblDownloadTemplate_LinkClicked;
                }
            }
        }

        private TextBox _txtNominal;

        internal TextBox txtNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominal != null)
                {
                }

                _txtNominal = value;
                if (_txtNominal != null)
                {
                }
            }
        }

        private Label _lblNominal;

        internal Label lblNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNominal != null)
                {
                }

                _lblNominal = value;
                if (_lblNominal != null)
                {
                }
            }
        }

        private Button _btnValidateResults;

        internal Button btnValidateResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnValidateResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnValidateResults != null)
                {
                    _btnValidateResults.Click -= btnValidateResults_Click;
                }

                _btnValidateResults = value;
                if (_btnValidateResults != null)
                {
                    _btnValidateResults.Click += btnValidateResults_Click;
                }
            }
        }

        private Label _lblProgress;

        internal Label lblProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProgress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProgress != null)
                {
                }

                _lblProgress = value;
                if (_lblProgress != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpExcelFile = new GroupBox();
            _txtNominal = new TextBox();
            _lblNominal = new Label();
            _btnFindExcelFile = new Button();
            _btnFindExcelFile.Click += new EventHandler(btnFindExcelFile_Click);
            _txtSupplier = new TextBox();
            _lblSupplier = new Label();
            _btnImport = new Button();
            _btnImport.Click += new EventHandler(btnImport_Click);
            _btnFindSupplier = new Button();
            _btnFindSupplier.Click += new EventHandler(btnFindSupplier_Click);
            _txtExcelFile = new TextBox();
            _lblFile = new Label();
            _btnExportResults = new Button();
            _btnExportResults.Click += new EventHandler(btnExportResults_Click);
            _tcData = new TabControl();
            _pbStatus = new ProgressBar();
            _lblProgress = new Label();
            _lblMessages = new Label();
            _cboValidateType = new ComboBox();
            _cboValidateType.SelectedIndexChanged += new EventHandler(cboValidateType_SelectedIndexChanged);
            _btnProcessIndiv = new Button();
            _btnProcessIndiv.Click += new EventHandler(btnProcessIndiv_Click);
            _grpCatImport = new GroupBox();
            _btnValidateResults = new Button();
            _btnValidateResults.Click += new EventHandler(btnValidateResults_Click);
            _lbl_Stats = new Label();
            _lblDownloadTemplate = new LinkLabel();
            _lblDownloadTemplate.LinkClicked += new LinkLabelLinkClickedEventHandler(lblDownloadTemplate_LinkClicked);
            _grpExcelFile.SuspendLayout();
            _grpCatImport.SuspendLayout();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Controls.Add(_txtNominal);
            _grpExcelFile.Controls.Add(_lblNominal);
            _grpExcelFile.Controls.Add(_btnFindExcelFile);
            _grpExcelFile.Controls.Add(_txtSupplier);
            _grpExcelFile.Controls.Add(_lblSupplier);
            _grpExcelFile.Controls.Add(_btnImport);
            _grpExcelFile.Controls.Add(_btnFindSupplier);
            _grpExcelFile.Controls.Add(_txtExcelFile);
            _grpExcelFile.Controls.Add(_lblFile);
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(515, 123);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Initial Import";
            //
            // txtNominal
            //
            _txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNominal.Location = new Point(71, 51);
            _txtNominal.Name = "txtNominal";
            _txtNominal.Size = new Size(336, 21);
            _txtNominal.TabIndex = 22;
            //
            // lblNominal
            //
            _lblNominal.AutoSize = true;
            _lblNominal.Location = new Point(6, 54);
            _lblNominal.Name = "lblNominal";
            _lblNominal.Size = new Size(58, 13);
            _lblNominal.TabIndex = 21;
            _lblNominal.Text = "Nominal:";
            //
            // btnFindExcelFile
            //
            _btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindExcelFile.FlatStyle = FlatStyle.System;
            _btnFindExcelFile.Location = new Point(413, 85);
            _btnFindExcelFile.Name = "btnFindExcelFile";
            _btnFindExcelFile.Size = new Size(32, 23);
            _btnFindExcelFile.TabIndex = 20;
            _btnFindExcelFile.Text = "...";
            //
            // txtSupplier
            //
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Location = new Point(71, 19);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(336, 21);
            _txtSupplier.TabIndex = 19;
            //
            // lblSupplier
            //
            _lblSupplier.AutoSize = true;
            _lblSupplier.Location = new Point(6, 22);
            _lblSupplier.Name = "lblSupplier";
            _lblSupplier.Size = new Size(59, 13);
            _lblSupplier.TabIndex = 18;
            _lblSupplier.Text = "Supplier:";
            //
            // btnImport
            //
            _btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnImport.Enabled = false;
            _btnImport.FlatStyle = FlatStyle.System;
            _btnImport.Location = new Point(451, 85);
            _btnImport.Name = "btnImport";
            _btnImport.Size = new Size(58, 23);
            _btnImport.TabIndex = 17;
            _btnImport.Text = "Import";
            //
            // btnFindSupplier
            //
            _btnFindSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSupplier.FlatStyle = FlatStyle.System;
            _btnFindSupplier.Location = new Point(413, 17);
            _btnFindSupplier.Name = "btnFindSupplier";
            _btnFindSupplier.Size = new Size(32, 23);
            _btnFindSupplier.TabIndex = 16;
            _btnFindSupplier.Text = "...";
            //
            // txtExcelFile
            //
            _txtExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtExcelFile.Location = new Point(43, 87);
            _txtExcelFile.Name = "txtExcelFile";
            _txtExcelFile.ReadOnly = true;
            _txtExcelFile.Size = new Size(364, 21);
            _txtExcelFile.TabIndex = 15;
            //
            // lblFile
            //
            _lblFile.AutoSize = true;
            _lblFile.Location = new Point(6, 90);
            _lblFile.Name = "lblFile";
            _lblFile.Size = new Size(31, 13);
            _lblFile.TabIndex = 14;
            _lblFile.Text = "File:";
            //
            // btnExportResults
            //
            _btnExportResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnExportResults.Location = new Point(860, 641);
            _btnExportResults.Name = "btnExportResults";
            _btnExportResults.Size = new Size(68, 27);
            _btnExportResults.TabIndex = 5;
            _btnExportResults.Text = "Export";
            _btnExportResults.UseVisualStyleBackColor = true;
            //
            // tcData
            //
            _tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcData.Location = new Point(8, 169);
            _tcData.Name = "tcData";
            _tcData.SelectedIndex = 0;
            _tcData.Size = new Size(920, 449);
            _tcData.TabIndex = 8;
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(17, 645);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(780, 23);
            _pbStatus.Step = 1;
            _pbStatus.TabIndex = 10;
            //
            // lblProgress
            //
            _lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblProgress.Location = new Point(796, 652);
            _lblProgress.Name = "lblProgress";
            _lblProgress.Size = new Size(40, 16);
            _lblProgress.TabIndex = 11;
            _lblProgress.Text = "0%";
            _lblProgress.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblMessages
            //
            _lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblMessages.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMessages.ForeColor = Color.Red;
            _lblMessages.Location = new Point(7, 621);
            _lblMessages.Name = "lblMessages";
            _lblMessages.Size = new Size(921, 19);
            _lblMessages.TabIndex = 12;
            _lblMessages.TextAlign = ContentAlignment.MiddleLeft;
            _lblMessages.Visible = false;
            //
            // cboValidateType
            //
            _cboValidateType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboValidateType.FormattingEnabled = true;
            _cboValidateType.Location = new Point(6, 19);
            _cboValidateType.Name = "cboValidateType";
            _cboValidateType.Size = new Size(387, 21);
            _cboValidateType.TabIndex = 1;
            //
            // btnProcessIndiv
            //
            _btnProcessIndiv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnProcessIndiv.Location = new Point(157, 54);
            _btnProcessIndiv.Name = "btnProcessIndiv";
            _btnProcessIndiv.Size = new Size(236, 23);
            _btnProcessIndiv.TabIndex = 4;
            _btnProcessIndiv.Text = "Process -->";
            _btnProcessIndiv.UseVisualStyleBackColor = true;
            //
            // grpCatImport
            //
            _grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCatImport.Controls.Add(_btnValidateResults);
            _grpCatImport.Controls.Add(_btnProcessIndiv);
            _grpCatImport.Controls.Add(_cboValidateType);
            _grpCatImport.Location = new Point(529, 40);
            _grpCatImport.Name = "grpCatImport";
            _grpCatImport.Size = new Size(399, 123);
            _grpCatImport.TabIndex = 6;
            _grpCatImport.TabStop = false;
            _grpCatImport.Text = "Category Processing";
            //
            // btnValidateResults
            //
            _btnValidateResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnValidateResults.Location = new Point(6, 54);
            _btnValidateResults.Name = "btnValidateResults";
            _btnValidateResults.Size = new Size(145, 23);
            _btnValidateResults.TabIndex = 7;
            _btnValidateResults.Text = "Revalidate Results";
            _btnValidateResults.UseVisualStyleBackColor = true;
            //
            // lbl_Stats
            //
            _lbl_Stats.AutoSize = true;
            _lbl_Stats.Location = new Point(126, 8);
            _lbl_Stats.Name = "lbl_Stats";
            _lbl_Stats.Size = new Size(0, 13);
            _lbl_Stats.TabIndex = 15;
            //
            // lblDownloadTemplate
            //
            _lblDownloadTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblDownloadTemplate.Location = new Point(800, 8);
            _lblDownloadTemplate.Name = "lblDownloadTemplate";
            _lblDownloadTemplate.Size = new Size(128, 23);
            _lblDownloadTemplate.TabIndex = 16;
            _lblDownloadTemplate.TabStop = true;
            _lblDownloadTemplate.Text = "Download Template";
            //
            // FRMSupplierInvoiceImporter
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(940, 680);
            Controls.Add(_lblDownloadTemplate);
            Controls.Add(_grpExcelFile);
            Controls.Add(_btnExportResults);
            Controls.Add(_lbl_Stats);
            Controls.Add(_grpCatImport);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_tcData);
            MinimumSize = new Size(920, 688);
            Name = "FRMSupplierInvoiceImporter";
            Text = "Supplier Invoice Importer";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_tcData, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_grpCatImport, 0);
            Controls.SetChildIndex(_lbl_Stats, 0);
            Controls.SetChildIndex(_btnExportResults, 0);
            Controls.SetChildIndex(_grpExcelFile, 0);
            Controls.SetChildIndex(_lblDownloadTemplate, 0);
            _grpExcelFile.ResumeLayout(false);
            _grpExcelFile.PerformLayout();
            _grpCatImport.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        
        

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        
        
        public FileInfo File { get; set; }
        private List<DuplicateInvoice> DuplicateInvoices { get; set; } = new List<DuplicateInvoice>();

        private Entity.Suppliers.Supplier _supplier;

        public Entity.Suppliers.Supplier Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
                if (_supplier is null)
                {
                    _supplier = new Entity.Suppliers.Supplier();
                    _supplier.Exists = false;
                    txtSupplier.Text = "";
                }
                else
                {
                    txtSupplier.Text = _supplier.Name;
                    txtNominal.Text = _supplier.DefaultNominal.Trim();
                }
            }
        }

        private string _nominalCode;

        public string NominalCode
        {
            get
            {
                return _nominalCode;
            }

            set
            {
                _nominalCode = value;
            }
        }

        private void FRMSupplierInvoiceImporter_Load(object sender, EventArgs e)
        {
            DataTable StatsTable;
            StatsTable = App.DB.ImportValidation.Parts_PreImportStats();
            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(StatsTable.Rows[0][2], "0", false)))
            {
                lbl_Stats.Text = Conversions.ToString("Import started on " + Strings.FormatDateTime(Conversions.ToDate(StatsTable.Rows[0][0]), DateFormat.ShortDate) + " at " + Strings.FormatDateTime(Conversions.ToDate(StatsTable.Rows[0][0]), DateFormat.ShortTime) + " finishing at " + Strings.FormatDateTime(Conversions.ToDate(StatsTable.Rows[0][1]), DateFormat.ShortTime) + " and contains " + StatsTable.Rows[0][2] + " records.");
            }
        }

        private void cboValidateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            var switchExpr = Combo.get_GetSelectedItemValue(cboValidateType);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.Unverified):
                case var case1 when case1 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.Replenishment):
                case var case2 when case2 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.UnableToLocatePO):
                case var case3 when case3 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.JobIncomplete):
                case var case4 when case4 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch):
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }

                case var case5 when case5 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect):
                case var case6 when case6 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove):
                case var case7 when case7 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow):
                case var case8 when case8 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.PurchaseCredit):
                    {
                        btnProcessIndiv.Visible = true;
                        btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
                        break;
                    }

                case var case9 when case9 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated):
                case var case10 when case10 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage):
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Remove Records -->";
                        break;
                    }

                case var case11 when case11 == Conversions.ToString(Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded): // Matched PO no parts added so no cost
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->";
                        break;
                    }
            }
        }

        private void btnProcessIndiv_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int validationResult = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboValidateType));
            switch (validationResult)
            {
                case (int)Enums.PartsInvoiceImportValidationResults.UnableToLocatePO:
                    {
                        ValidateOrder(validationResult);
                        MoveProgressOn(true);
                        ShowData(validationResult);
                        break;
                    }

                case (int)Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect:
                case (int)Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove:
                case (int)Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow:
                case (int)Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded:
                    {
                        CreateSupplierInvoice(validationResult);
                        ValidateAllRecords();
                        ShowData(validationResult);
                        break;
                    }

                case (int)Enums.PartsInvoiceImportValidationResults.PurchaseCredit:
                    {
                        CreatePurchaseCredit(validationResult);
                        ShowData(validationResult);
                        break;
                    }

                case (int)Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated:  // Supplier Invoice Created
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Remove Records -->";
                        break;
                    }

                case (int)Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage:
                    {
                        break;
                    }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Enabled = false;
                DataView data;
                string sheetName = "";
                string sql = "";
                sql = "EXEC Parts_GetPreImport " + Combo.get_GetSelectedItemValue(cboValidateType);
                data = new DataView(App.DB.ExecuteWithReturn(sql));
                foreach (DataColumn col in data.Table.Columns)
                {
                    if (col.DataType == Type.GetType("System.String"))
                    {
                        foreach (DataRow row in data.Table.Rows)
                            row[col.ColumnName] = "'" + row[col.ColumnName];
                    }
                }

                sheetName = Combo.get_GetSelectedItemDescription(cboValidateType);
                ExportHelper.Export(data.Table, sheetName, Enums.ExportType.XLS);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error exporting : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnFindExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            FindSupplier();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void btnValidateResults_Click(object sender, EventArgs e)
        {
            ValidateAllRecords();
        }

        
        

        private void CreateSupplierInvoice(int validationResult)
        {
            var dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(validationResult);
            pbStatus.Value = 0;
            pbStatus.Maximum = dvProcessData.Count + 1;
            foreach (DataRow dr in dvProcessData.Table.Rows)
            {
                bool insertDb = true;
                int orderId = Helper.MakeIntegerValid(dr["OrderID"]);
                bool requiresAuth = Helper.MakeBooleanValid(dr["RequiresAuthorisation"]);
                if (orderId == 0)
                {
                    insertDb = false;
                    App.ShowMessage(Conversions.ToString("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dr["PurchaseOrderNo"] + ", please contact your administrator"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MoveProgressOn(false);
                }
                else if (Helper.MakeBooleanValid(dr["Exclude"]))
                {
                    insertDb = false;
                }

                int orderStatusId = Helper.MakeIntegerValid(App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(orderId));
                if (orderStatusId == 1)
                {
                    insertDb = false;
                    App.ShowMessage(Conversions.ToString("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dr["PurchaseOrderNo"] + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MoveProgressOn(false);
                }

                if (insertDb)
                {
                    var order = App.DB.Order.Order_Get(orderId);
                    int nominal = Helper.MakeIntegerValid(dr["NominalCode"]);
                    if (nominal == 0)
                        nominal = 5300;
                    bool isSubby = Helper.MakeBooleanValid(dr["SubContractor"]);
                    int vatCodeId;
                    if (isSubby && Helper.MakeDoubleValid(dr["TotalVatAmount"]) == 0)
                    {
                        vatCodeId = Conversions.ToInteger(Enums.PlVatRates.T9);
                    }
                    else if (Helper.MakeDoubleValid(dr["TotalVatAmount"]) > 0)
                    {
                        vatCodeId = Conversions.ToInteger(Enums.PlVatRates.T1);
                    }
                    else
                    {
                        vatCodeId = Conversions.ToInteger(Enums.PlVatRates.T0);
                    }

                    var supplierInvoice = new SupplierInvoice()
                    {
                        SetOrderID = orderId,
                        SetInvoiceReference = dr["InvoiceNo"],
                        SetInvoiceDate = Helper.MakeDateTimeValid(dr["InvoiceDate"]),
                        SetGoodsAmount = Helper.MakeDoubleValid(dr["TotalGrossAmount"]),
                        SetVATAmount = Helper.MakeDoubleValid(dr["TotalVatAmount"]),
                        SetTotalAmount = Helper.MakeDoubleValid(dr["TotalNetAmount"]),
                        SetTaxCodeID = vatCodeId,
                        SetNominalCode = nominal,
                        SetSentToSage = 0,
                        SetOldSystemInvoice = 0,
                        SetDateExported = null,
                        SetKeyedBy = App.loggedInUser.UserID,
                        SetExtraRef = ".",
                        SetReadyToSendToSage = true
                    };
                    switch (true)
                    {
                        case object _ when App.IsGasway:
                            {
                                break;
                            }

                        default:
                            {
                                if (requiresAuth)
                                {
                                    supplierInvoice.SetReadyToSendToSage = false;
                                }

                                break;
                            }
                    }

                    if (order?.OrderTypeID == (int?)Enums.OrderType.Job == true)
                    {
                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(orderId);
                        if (dtCharge.Rows.Count > 0)
                        {
                            string chargeNominal = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                            if (Conversions.ToDouble(chargeNominal) > 0)
                            {
                                supplierInvoice.SetExtraRef = chargeNominal;
                            }
                        }
                    }

                    try
                    {
                        App.DB.SupplierInvoices.Insert(supplierInvoice);
                        App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dr["ID"]), true);
                        if (requiresAuth)
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dr["ID"]), requiresAuth);
                        }
                        else
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dr["ID"].ToString()), 7);
                        }
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MoveProgressOn(false);
                }
            }
        }

        private void CreatePurchaseCredit(int validationResult)
        {
            var dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(validationResult);
            pbStatus.Value = 0;
            pbStatus.Maximum = dvProcessData.Count + 1;
            foreach (DataRow dr in dvProcessData.Table.Rows)
            {
                bool insertDb = true;
                int orderId = Helper.MakeIntegerValid(dr["OrderID"]);
                bool requiresAuth = Helper.MakeBooleanValid(dr["RequiresAuthorisation"]);
                if (orderId == 0)
                {
                    insertDb = false;
                    if (requiresAuth)
                    {
                        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dr["ID"]), requiresAuth);
                    }

                    App.ShowMessage(Conversions.ToString("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dr["PurchaseOrderNo"] + ", please contact your administrator"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MoveProgressOn(false);
                }
                else if (Helper.MakeBooleanValid(dr["Exclude"]))
                {
                    insertDb = false;
                }

                int orderStatusId = Helper.MakeIntegerValid(App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(orderId));
                if (orderStatusId == 1)
                {
                    insertDb = false;
                    App.ShowMessage(Conversions.ToString("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dr["PurchaseOrderNo"] + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MoveProgressOn(false);
                }

                if (insertDb)
                {
                    var order = App.DB.Order.Order_Get(orderId);
                    int taxCodeId;
                    bool isSubby = Helper.MakeBooleanValid(dr["SubContractor"]);
                    if (isSubby && Helper.MakeDoubleValid(dr["TotalVatAmount"]) == 0)
                    {
                        taxCodeId = Conversions.ToInteger(Enums.PlVatRates.T9);
                    }
                    else if (Helper.MakeDoubleValid(dr["TotalVatAmount"]) > 0)
                    {
                        taxCodeId = Conversions.ToInteger(Enums.PlVatRates.T1);
                    }
                    else
                    {
                        taxCodeId = Conversions.ToInteger(Enums.PlVatRates.T0);
                    }

                    var purchaseCredit = new PartsToBeCredited()
                    {
                        SetOrderID = orderId,
                        SetOrderReference = order.OrderReference,
                        SetSupplierID = Helper.MakeIntegerValid(dr["SupplierID"]),
                        SetStatusID = 3
                    };
                    string chargeNominal = "";
                    if (order?.OrderTypeID == (int?)Enums.OrderType.Job == true)
                    {
                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(orderId);
                        if (dtCharge.Rows.Count > 0)
                        {
                            chargeNominal = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                        }
                    }

                    var dtPartsToCredit = new DataTable();
                    var dtInvoicedParts = App.DB.ExecuteWithReturn(Conversions.ToString("Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '" + dr["InvoiceNo"] + "'"));
                    bool failed = true;
                    foreach (DataRow row in dtInvoicedParts.Rows)
                    {
                        // insert the parts to be credited
                        var part = App.DB.Part.Part_Get_For_Code_And_Supplier(Conversions.ToString(row["SupplierPartCode"]), Conversions.ToInteger(dr["SupplierID"]));
                        int supplierPartId = -1;
                        if (part is object)
                        {
                            supplierPartId = part.SPartID;
                        }

                        var dtOrderPart = App.DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " + orderId + " AND PartSupplierID = " + supplierPartId);
                        if (dtOrderPart.Rows.Count > 0)
                        {
                            failed = false;
                            purchaseCredit.SetPartID = part.PartID;
                            purchaseCredit.SetQty = row["Quantity"];
                            purchaseCredit.SetCreditReceived = Conversions.ToDouble(row["NetAmount"].ToString().Replace("-", ""));
                            purchaseCredit.SetPartOrderID = dtOrderPart.Rows[0]["OrderPartID"];
                            dtPartsToCredit = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(dtOrderPart.Rows[0]["OrderPartID"])).Table;
                            if (dtPartsToCredit.Rows.Count > 0) // Update
                            {
                                purchaseCredit.SetPartsToBeCreditedID = dtPartsToCredit.Rows[0]["PartsToBeCreditedID"];
                                App.DB.PartsToBeCredited.Update(purchaseCredit);
                            }
                            else
                            {
                                purchaseCredit = App.DB.PartsToBeCredited.Insert(purchaseCredit);
                            }
                        }
                    }  // parts for invoice loop

                    if (failed == true)  // we couldnt match any parts it was a disaster so only option is add the credit against first part in order
                    {
                        var dtOrderPart = App.DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " + orderId);
                        int partid = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("Select Top (1) PartID From tblPartSupplier Where PartSupplierID = " + dtOrderPart.Rows[0]["PartSupplierID"])));
                        purchaseCredit.SetPartID = partid;
                        purchaseCredit.SetQty = 1;
                        purchaseCredit.SetCreditReceived = Conversions.ToDouble(dr["TotalNetAmount"].ToString().Replace("-", ""));
                        purchaseCredit.SetPartOrderID = dtOrderPart.Rows[0]["OrderPartID"];
                        dtPartsToCredit = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(dtOrderPart.Rows[0]["OrderPartID"])).Table;  // table containing the part in question
                        if (dtPartsToCredit.Rows.Count > 0) // Update
                        {
                            purchaseCredit.SetPartsToBeCreditedID = dtPartsToCredit.Rows[0]["PartsToBeCreditedID"];
                            App.DB.PartsToBeCredited.Update(purchaseCredit);
                        }
                        else // Insert
                        {
                            purchaseCredit = App.DB.PartsToBeCredited.Insert(purchaseCredit);
                        }
                    }

                    if (dtPartsToCredit.Rows.Count == 0)
                    {
                        int partcreditsID = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dr["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dr["InvoiceDate"]), DateTime.MinValue, taxCodeId, "5300", order.DepartmentRef, chargeNominal, Conversions.ToString(dr["InvoiceNo"]));
                        App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + partcreditsID + "," + purchaseCredit.PartsToBeCreditedID + ")");
                    }
                    else if (Information.IsDBNull(dtPartsToCredit.Rows[0]["PartCreditsID"]))
                    {
                        int partcreditsID = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dr["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dr["InvoiceDate"].ToString()), DateTime.MinValue, taxCodeId, "5300", order.DepartmentRef, chargeNominal, Conversions.ToString(dr["InvoiceNo"]));
                        App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + partcreditsID + "," + purchaseCredit.PartsToBeCreditedID + ")");
                    }
                    else
                    {
                        App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dtPartsToCredit.Rows[0]["PartCreditsID"]), Conversions.ToDouble(dr["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dr["InvoiceDate"].ToString()), DateTime.MinValue, taxCodeId, "5300", order.DepartmentRef, chargeNominal, Conversions.ToString(dr["InvoiceNo"]));
                    }

                    App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dr["ID"]), true);
                    MoveProgressOn(false);
                }
            }
        }

        public void ShowData(int ValidateType = 0)
        {
            tcData.TabPages.Clear();
            var tp = new TabPage();
            var data = new UCDataPartsInvoiceImport();
            data.Dock = DockStyle.Fill;
            data.Data = App.DB.ImportValidation.POInvoiceImport_ShowData(ValidateType);
            data.ValidateType = Combo.get_GetSelectedItemValue(cboValidateType);
            tp.Text = "Supplier Invoice Import Data (" + data.Data.Count + " Records)";
            tp.Controls.Add(data);
            tcData.TabPages.Add(tp);
            tcData.SelectedIndex = 0;
            MoveProgressOn(true);
        }

        private void LoadData()
        {
            OpenFileDialog dlg = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnFindSupplier.Enabled = false;
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var tempfile = new FileInfo(dlg.FileName);

                    // Is it an excel file?
                    if ((tempfile.Extension ?? "") == ".xls" | (tempfile.Extension ?? "") == ".xlsx")
                    {
                        File = tempfile;
                        // Is an Excel file
                        txtExcelFile.Text = File.FullName;
                        btnImport.Enabled = true;
                    }
                    else
                    {
                        App.ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                App.ShowMessage("File data could not be loaded : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dlg is object)
                    dlg.Dispose();
                btnFindSupplier.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        public void MoveProgressOn(bool toMaximum = false)
        {
            if (toMaximum)
            {
                pbStatus.Value = pbStatus.Maximum;
                lblProgress.Text = "100%";
            }
            else
            {
                pbStatus.Value += 1;
                lblProgress.Text = Math.Floor(pbStatus.Value / (double)pbStatus.Maximum * 100) + "%";
            }

            Application.DoEvents();
        }

        private bool IsFormValid()
        {
            if (Helper.MakeIntegerValid(Supplier?.SupplierID) == 0)
            {
                App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Helper.MakeIntegerValid(txtNominal.Text.Trim()) <= 0)
            {
                App.ShowMessage("Please enter a numeric nominal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Import()
        {
            if (!IsFormValid())
                return;
            NominalCode = txtNominal.Text.Trim();
            bool success = false;
            lblMessages.Text = "Starting import...";
            lblMessages.Visible = true;
            DuplicateInvoices.Clear();
            pbStatus.Value = 0;
            pbStatus.Maximum = 1;
            if (PreImportData())
            {
                var argcombo = cboValidateType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                // once import is completed show data imported
                ShowData();
                lblMessages.Text = "Import complete.";
                lblMessages.Visible = true;
                if (DuplicateInvoices.Count > 0)
                {
                    var duplicates = new List<string>();
                    foreach (DuplicateInvoice duplicate in DuplicateInvoices)
                        duplicates.Add("Invovice: " + duplicate.InvoiceNo + " InvoiceDate: " + duplicate.InvoiceDate + " PartCode:  " + duplicate.SupplierPartCode);
                    if (App.ShowMessageWithDetails("Import Complete", "The following invoices are duplicates and have not been imported.", duplicates) == DialogResult.OK)
                    {
                        var frmDuplicateInvoices = new FRMDuplicateInvoices(DuplicateInvoices);
                        frmDuplicateInvoices.ShowDialog();
                    }
                }
                else
                {
                    App.ShowMessage("Import Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string filePath = App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\" + Supplier.Name.Replace("/", "").Replace(@"\", "") + @"\Proccessed\";
                Directory.CreateDirectory(filePath);
                string fileType = Path.GetExtension(File.Name);
                System.IO.File.Move(File.FullName, filePath + File.Name.Replace(fileType, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + fileType));
                File = null;
                txtExcelFile.Text = "";
                txtNominal.Text = "";
                Supplier = null;
                NominalCode = null;
                pbStatus.Value = pbStatus.Maximum;
                btnFindExcelFile.Enabled = true;
                btnImport.Enabled = true;
                pbStatus.Value = 0;

                // clear duplicate list
                DuplicateInvoices.Clear();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                App.ShowMessage("Error uploading excel document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PreImportData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessages.Visible = true;
                lblMessages.Text = "Downloading data from file...";
                btnFindExcelFile.Enabled = false;
                btnImport.Enabled = false;
                pbStatus.Value = 0;
                Application.DoEvents();
                var excel = new ExcelQueryFactory(File.FullName);
                List<string> worksheets = excel.GetWorksheetNames().ToList();
                string firstWorksheet = worksheets.FirstOrDefault();
                var obj = (from a in excel.Worksheet(firstWorksheet) select a);
                List<string> columnNames = excel.GetColumnNames(firstWorksheet).ToList();
                var data = new DataTable();
                foreach (string columnName in columnNames)
                    data.Columns.Add(columnName);
                foreach (Row rr in (IEnumerable)obj)
                {
                    var dr = data.NewRow();
                    foreach (string columnName in columnNames)
                        dr[columnName] = rr[columnName];
                    data.Rows.Add(dr);
                }

                pbStatus.Maximum += data.Rows.Count;
                var dt = new DataTable();
                dt.Columns.Add("InvoiceNo");
                dt.Columns.Add("InvoiceDate");
                dt.Columns.Add("PurchaseOrderNo");
                dt.Columns.Add("SupplierPartCode");
                dt.Columns.Add("Description");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("UnitPrice");
                dt.Columns.Add("NetAmount");
                dt.Columns.Add("VATAmount");
                dt.Columns.Add("GrossAmount");
                dt.Columns.Add("InsertDB");
                foreach (DataRow row in data.Rows)
                {
                    var dr = dt.NewRow();
                    if (row["Invoice Number"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["InvoiceNo"] = Helper.MakeStringValid(row["Invoice Number"]).Trim();
                    }

                    if (row["Invoice Date"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["InvoiceDate"] = Helper.MakeStringValid(row["Invoice Date"]);
                    }

                    if (row["Purchase Order Reference"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["PurchaseOrderNo"] = Helper.MakeStringValid(row["Purchase Order Reference"]).Trim();
                    }

                    if (row.Table.Columns.Contains("Product Code"))
                        dr["SupplierPartCode"] = Helper.MakeStringValid(row["Product Code"]);
                    if (row.Table.Columns.Contains("Product Description"))
                        dr["Description"] = Helper.MakeStringValid(row["Product Description"]);
                    if (row.Table.Columns.Contains("Quantity"))
                        dr["Quantity"] = Helper.MakeStringValid(row["Quantity"]);
                    if (row["Unit Price"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["UnitPrice"] = Helper.MakeStringValid(row["Unit Price"]).Trim();
                    }

                    if (row["Net Amount"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["NetAmount"] = Helper.MakeStringValid(row["Net Amount"]).Trim();
                    }

                    if (row["VAT Amount"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["VATAmount"] = Helper.MakeStringValid(row["VAT Amount"]).Trim();
                    }

                    if (row["Gross Amount"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        dr["GrossAmount"] = Helper.MakeStringValid(row["Gross Amount"]).Trim();
                    }

                    dr["InsertDB"] = true;
                    dt.Rows.Add(dr);
                }

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string invoiceNo = Helper.MakeStringValid(row["InvoiceNo"]);
                        var invoiceDate = Helper.MakeDateTimeValid(row["InvoiceDate"]);
                        string purchaseOrderNo = Helper.MakeStringValid(row["PurchaseOrderNo"]);
                        string supplierPartCode = Helper.MakeStringValid(row["SupplierPartCode"]);
                        string description = Helper.MakeStringValid(row["Description"]);
                        int quantity = Helper.MakeIntegerValid(row["Quantity"]);
                        double unitPrice = Helper.MakeDoubleValid(row["UnitPrice"]);
                        double netAmount = Helper.MakeDoubleValid(row["NetAmount"]);
                        double vatAmount = Helper.MakeDoubleValid(row["VATAmount"]);
                        double grossAmount = Helper.MakeDoubleValid(row["GrossAmount"]);
                        int hasOrderBeenSent = App.DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(invoiceNo, invoiceDate, supplierPartCode);
                        if (hasOrderBeenSent > 0)
                        {
                            row["InsertDB"] = false;
                            MoveProgressOn();
                            continue;
                        }

                        int importExists = App.DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(invoiceNo, invoiceDate, supplierPartCode);
                        if (importExists > 0)
                        {
                            var duplicate = new DuplicateInvoice()
                            {
                                PurchaseOrderNo = purchaseOrderNo,
                                SupplierPartCode = supplierPartCode,
                                Description = description,
                                Quantity = quantity,
                                UnitPrice = unitPrice,
                                NetAmount = netAmount,
                                VATAmount = vatAmount,
                                GrossAmount = grossAmount,
                                InvoiceNo = invoiceNo,
                                InvoiceDate = Conversions.ToString(invoiceDate),
                                SupplierID = Supplier.SupplierID,
                                TotalQtyOfParts = quantity
                            };
                            DuplicateInvoices.Add(duplicate);
                            row["InsertDB"] = false;
                        }

                        if (Helper.MakeBooleanValid(row["InsertDB"]))
                        {
                            int orderId = App.DB.ImportValidation.Orders_GetID(purchaseOrderNo, Supplier.SupplierID.ToString(), invoiceNo);
                            if (orderId == 0)
                            {
                                orderId = App.DB.ImportValidation.POInvoiceImport_InsertOrder(invoiceNo, invoiceDate, purchaseOrderNo, Supplier.SupplierID, "Unspecified", NominalCode);
                            }

                            App.DB.ImportValidation.POInvoiceImport_InsertPart(purchaseOrderNo, supplierPartCode, description, quantity, unitPrice, netAmount, vatAmount, grossAmount, invoiceNo);
                            App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(purchaseOrderNo, quantity, unitPrice, netAmount, vatAmount, grossAmount, quantity, invoiceNo);
                            if (orderId > 0)
                            {
                                App.DB.ImportValidation.POInvoiceImport_ValidateOrder(orderId);
                            }
                        }
                        MoveProgressOn();
                    }

                    MoveProgressOn(true);
                    return true;
                }
                catch (Exception ex)
                {
                    lblMessages.Visible = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                lblMessages.Visible = false;
                return false;
            }
        }

        private void FindSupplier()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 1));
            if (!(ID == 0))
            {
                Supplier = App.DB.Supplier.Supplier_Get(ID);
            }
        }

        private void lblDownloadTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dlg = null;
            Microsoft.Office.Interop.Excel.Application oExcel = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    oExcel = new Microsoft.Office.Interop.Excel.Application();
                    oExcel.Workbooks.Add(Application.StartupPath + @"\GenericDocuments\SupplierInvoiceImportTemplate.xlsx");
                    if (System.IO.File.Exists(dlg.SelectedPath + @"\SupplierInvoiceImporter.xlsx"))
                    {
                        System.IO.File.Delete(dlg.SelectedPath + @"\SupplierInvoiceImporter.xlsx");
                    }

                    oExcel.Workbooks.get_Item(1).SaveAs(dlg.SelectedPath + @"\SupplierInvoiceImporter.xlsx");
                    App.ShowMessage("File downloaded to " + dlg.SelectedPath + @"\SupplierInvoiceImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Template could not be saved : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                KillInstances(oExcel);
                dlg.Dispose();
                Cursor.Current = Cursors.Default;
            }
        }

        private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
        {
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            GC.Collect();
            var mp = Process.GetProcessesByName("EXCEL");
            foreach (var p in mp)
            {
                try
                {
                    if (p.Responding)
                    {
                        if (string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            p.Kill();
                        }
                    }
                    else
                    {
                        p.Kill();
                    }
                }
                catch
                {
                }
            };
        }

        public void ValidateOrder(int ValidateType)
        {
            lblMessages.Text = "Now validating orders, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            App.DB.ImportValidation.POInvoiceImport_ValidateOrders(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            lblMessages.Text = "Validation complete.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        public void ValidateAllRecords()
        {
            lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            var dvAllData = App.DB.ImportValidation.POInvoiceImport_ShowData_Mk1();
            int Steps = dvAllData.Count;
            pbStatus.Value = 0;
            pbStatus.Maximum = Steps + 1;
            foreach (DataRow dr in dvAllData.Table.Rows)
            {
                int id = Helper.MakeIntegerValid(dr["ID"]);
                App.DB.ImportValidation.POInvoiceImport_ValidateOrder(id);
                MoveProgressOn();
            }

            var argcombo = cboValidateType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            ShowData();
            lblMessages.Text = "Validation complete.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        
    }
}