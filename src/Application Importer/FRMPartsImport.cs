using FSM.Entity.Sys;
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
    public class FRMPartsImport : FRMBaseForm
    {
        public FRMPartsImport() : base()
        {
            this.Load += FRMPartsImport_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboValidateType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.PartValidationTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);

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

        private LinkLabel _btnExportParts;

        private Button _btnExportResults;

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

        private CheckBox _chkPFH;

        internal CheckBox chkPFH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPFH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPFH != null)
                {
                }

                _chkPFH = value;
                if (_chkPFH != null)
                {
                }
            }
        }

        private LinkLabel _llOpenFolder;

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
            _chkPFH = new CheckBox();
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
            _btnExportParts = new LinkLabel();
            _btnExportParts.LinkClicked += new LinkLabelLinkClickedEventHandler(btnExportParts_LinkClicked);
            _cboValidateType = new ComboBox();
            _cboValidateType.SelectedIndexChanged += new EventHandler(cboValidateType_SelectedIndexChanged);
            _btnProcessIndiv = new Button();
            _btnProcessIndiv.Click += new EventHandler(btnProcessIndiv_Click);
            _grpCatImport = new GroupBox();
            _lbl_Stats = new Label();
            _llOpenFolder = new LinkLabel();
            _llOpenFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(llOpenFolder_LinkClicked);
            _grpExcelFile.SuspendLayout();
            _grpCatImport.SuspendLayout();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Controls.Add(_chkPFH);
            _grpExcelFile.Controls.Add(_btnFindExcelFile);
            _grpExcelFile.Controls.Add(_txtSupplier);
            _grpExcelFile.Controls.Add(_lblSupplier);
            _grpExcelFile.Controls.Add(_btnImport);
            _grpExcelFile.Controls.Add(_btnFindSupplier);
            _grpExcelFile.Controls.Add(_txtExcelFile);
            _grpExcelFile.Controls.Add(_lblFile);
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(515, 85);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Initial Import";
            //
            // chkPFH
            //
            _chkPFH.AutoSize = true;
            _chkPFH.Location = new Point(452, 22);
            _chkPFH.Name = "chkPFH";
            _chkPFH.Size = new Size(47, 17);
            _chkPFH.TabIndex = 21;
            _chkPFH.Text = "PFH";
            _chkPFH.UseVisualStyleBackColor = true;
            //
            // btnFindExcelFile
            //
            _btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindExcelFile.FlatStyle = FlatStyle.System;
            _btnFindExcelFile.Location = new Point(413, 51);
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
            _btnImport.Location = new Point(451, 51);
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
            _txtExcelFile.Location = new Point(43, 53);
            _txtExcelFile.Name = "txtExcelFile";
            _txtExcelFile.ReadOnly = true;
            _txtExcelFile.Size = new Size(364, 21);
            _txtExcelFile.TabIndex = 15;
            //
            // lblFile
            //
            _lblFile.AutoSize = true;
            _lblFile.Location = new Point(6, 56);
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

            _tcData.Location = new Point(8, 131);
            _tcData.Name = "tcData";
            _tcData.SelectedIndex = 0;
            _tcData.Size = new Size(920, 487);
            _tcData.TabIndex = 8;
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(10, 645);
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
            // btnExportParts
            //
            _btnExportParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnExportParts.Location = new Point(840, 8);
            _btnExportParts.Name = "btnExportParts";
            _btnExportParts.Size = new Size(88, 23);
            _btnExportParts.TabIndex = 13;
            _btnExportParts.TabStop = true;
            _btnExportParts.Text = "Export Parts";
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
            _btnProcessIndiv.Location = new Point(178, 51);
            _btnProcessIndiv.Name = "btnProcessIndiv";
            _btnProcessIndiv.Size = new Size(215, 23);
            _btnProcessIndiv.TabIndex = 4;
            _btnProcessIndiv.Text = "Process -->";
            _btnProcessIndiv.UseVisualStyleBackColor = true;
            //
            // grpCatImport
            //
            _grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCatImport.Controls.Add(_btnProcessIndiv);
            _grpCatImport.Controls.Add(_cboValidateType);
            _grpCatImport.Location = new Point(529, 40);
            _grpCatImport.Name = "grpCatImport";
            _grpCatImport.Size = new Size(399, 85);
            _grpCatImport.TabIndex = 6;
            _grpCatImport.TabStop = false;
            _grpCatImport.Text = "Category Processing";
            //
            // lbl_Stats
            //
            _lbl_Stats.AutoSize = true;
            _lbl_Stats.Location = new Point(126, 8);
            _lbl_Stats.Name = "lbl_Stats";
            _lbl_Stats.Size = new Size(0, 13);
            _lbl_Stats.TabIndex = 15;
            //
            // llOpenFolder
            //
            _llOpenFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _llOpenFolder.Location = new Point(707, 8);
            _llOpenFolder.Name = "llOpenFolder";
            _llOpenFolder.Size = new Size(111, 23);
            _llOpenFolder.TabIndex = 16;
            _llOpenFolder.TabStop = true;
            _llOpenFolder.Text = "View Parts Files";
            //
            // FRMPartsImport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(940, 680);
            Controls.Add(_llOpenFolder);
            Controls.Add(_grpExcelFile);
            Controls.Add(_btnExportResults);
            Controls.Add(_lbl_Stats);
            Controls.Add(_grpCatImport);
            Controls.Add(_btnExportParts);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_tcData);
            MinimumSize = new Size(920, 688);
            Name = "FRMPartsImport";
            Text = "Parts Import";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_tcData, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_btnExportParts, 0);
            Controls.SetChildIndex(_grpCatImport, 0);
            Controls.SetChildIndex(_lbl_Stats, 0);
            Controls.SetChildIndex(_btnExportResults, 0);
            Controls.SetChildIndex(_grpExcelFile, 0);
            Controls.SetChildIndex(_llOpenFolder, 0);
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

        private FileInfo _file;

        public FileInfo File
        {
            get
            {
                return _file;
            }

            set
            {
                _file = value;
            }
        }

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
                }
                else
                {
                    txtSupplier.Text = _supplier.Name;
                }
            }
        }

        private void FRMPartsImport_Load(object sender, EventArgs e)
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
            ShowData();
            var switchExpr = Combo.get_GetSelectedItemValue(cboValidateType);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                case var case1 when case1 == 4.ToString():
                case var case2 when case2 == 7.ToString():
                case var case3 when case3 == 8.ToString():
                case var case4 when case4 == 9.ToString():
                case var case5 when case5 == 12.ToString():
                case var case6 when case6 == 13.ToString():
                case var case7 when case7 == 14.ToString():
                    {
                        btnProcessIndiv.Text = "Revalidate Results -->";
                        break;
                    }

                case var case8 when case8 == 1.ToString():
                    {
                        btnProcessIndiv.Text = "Apply No Change -->";
                        break;
                    }

                case var case9 when case9 == 2.ToString():
                case var case10 when case10 == 3.ToString():
                    {
                        btnProcessIndiv.Text = "Apply Price Change -->";
                        break;
                    }

                case var case11 when case11 == 5.ToString():
                    {
                        btnProcessIndiv.Text = "Add Parts -->";
                        break;
                    }

                case var case12 when case12 == 6.ToString():
                    {
                        btnProcessIndiv.Text = "Add Parts -->";
                        break;
                    }
            }
        }

        private void btnProcessIndiv_Click(object sender, EventArgs e)
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboValidateType);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                case var case1 when case1 == 4.ToString():
                case var case2 when case2 == 7.ToString():
                case var case3 when case3 == 8.ToString():
                case var case4 when case4 == 9.ToString():
                case var case5 when case5 == 12.ToString():
                case var case6 when case6 == 14.ToString():
                    {
                        if (App.ShowMessage("This action will revalidate the pre-import data, no changes will be made to live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pbStatus.Value = 0;
                            pbStatus.Maximum = (int)Enum.GetValues(typeof(Enums.PartValidationResults)).Cast<Enums.PartValidationResults>().Max();
                            Cursor.Current = Cursors.WaitCursor;
                            ValidateAllRecords();
                            ShowData();
                            MoveProgressOn(true);
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }

                case var case7 when case7 == 1.ToString():
                    {
                        if (App.ShowMessage("This action will remove these parts from the pre-import data, no changes will be made to live parts other than the date update.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pbStatus.Value = 0;
                            pbStatus.Maximum = 1;
                            Cursor.Current = Cursors.WaitCursor;
                            App.DB.ImportValidation.Parts_PreImportNoChangeRemove(!chkPFH.Checked);
                            ShowData();
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }

                case var case8 when case8 == 2.ToString():
                case var case9 when case9 == 3.ToString():
                    {
                        if (App.ShowMessage("This action will update PRICES ONLY on live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pbStatus.Value = 0;
                            pbStatus.Maximum = 1;
                            Cursor.Current = Cursors.WaitCursor;
                            App.DB.ImportValidation.Parts_ImportApplyPriceChange(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                            ShowData();
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }

                case var case10 when case10 == 5.ToString():
                    {
                        if (App.ShowMessage("This action will attach the supplier (SPN) as a seller of this part, if the 'swap SPN' flag has been ticked then the supplier SPN will only be updated.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pbStatus.Value = 0;
                            pbStatus.Maximum = 1;
                            Cursor.Current = Cursors.WaitCursor;
                            App.DB.ImportValidation.Parts_ImportAddPartSuppliers();
                            ShowData();
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }

                case var case11 when case11 == 6.ToString():
                    {
                        if (App.ShowMessage("This action will add the part (MPN) as a complete new part and attach the supplier (SPN) as a seller of this part.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pbStatus.Value = 0;
                            pbStatus.Maximum = 1;
                            Cursor.Current = Cursors.WaitCursor;
                            App.DB.ImportValidation.Parts_ImportAddParts();
                            ShowData();
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }
            }
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

        private void btnExportParts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Enabled = false;
                DataView data;
                string sql = "";
                sql = "SELECT tblPart.PartID, tblPart.Name, tblPart.Number, tblPart.Reference, tblPart.Notes, tblPart.UnitTypeID, tblPart.Deleted, tblPart.SellPrice, tblPart.MinimumQuantity, " + "tblPart.RecommendedQuantity, tblPicklists.Name AS Category, tblPart.LastChanged, tblPart.BinID, tblPart.ShelfID, tblPart.WarehouseID, tblPart.BinIDAlternative, " + "tblPart.ShelfIDAlternative, tblPart.WarehouseIDAlternative, tblPart.EndFlagged, tblPart.Equipment, tblSupplier.Name AS Supplier, tblPartSupplier.PartCode AS [Supplier Part Number],  " + "tblPartSupplier.Price AS [Supplier Price] " + " FROM tblPart INNER JOIN " + " tblPicklists ON tblPart.CategoryID = tblPicklists.ManagerID INNER JOIN " + " tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID INNER JOIN " + " tblSupplier ON tblPartSupplier.SupplierID = tblSupplier.SupplierID " + " WHERE tblPart.Deleted = 0";
                data = new DataView(App.DB.ExecuteWithReturn(sql));
                foreach (DataColumn col in data.Table.Columns)
                {
                    if (col.DataType == Type.GetType("System.String"))
                    {
                        foreach (DataRow row in data.Table.Rows)
                            row[col.ColumnName] = "'" + row[col.ColumnName];
                    }
                }

                ExportHelper.Export(data.Table, "Parts", Enums.ExportType.XLS);
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

        public void ShowData()
        {
            tcData.TabPages.Clear();
            Cursor.Current = Cursors.WaitCursor;
            var tp = new TabPage();
            var data = new UCData();
            data.SetupDG();
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboValidateType)) == (double)Enums.PartValidationResults.NewForThisSupplier) // 5  Then
            {
                data.dgvData.Columns["SwapSPN"].Visible = true;
            }
            else
            {
                data.dgvData.Columns["SwapSPN"].Visible = false;
            }

            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboValidateType)) == (double)Enums.PartValidationResults.CategoryNotFound)
            {
                data.dgvData.Columns["Category"].ReadOnly = false;
            }
            else
            {
                data.dgvData.Columns["Category"].ReadOnly = true;
            }

            data.Dock = DockStyle.Fill;
            data.Data = App.DB.ImportValidation.Parts_GetPreImportData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            tp.Text = "Parts Pre-Import (" + data.Data.Count + " Records)";
            tp.Controls.Add(data);
            tcData.TabPages.Add(tp);
            tcData.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;
        }

        private void LoadData()
        {
            OpenFileDialog dlg = null;
            Microsoft.Office.Interop.Excel.Application oExcel = null;
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

        private void Import()
        {
            if (Supplier is null || !Supplier.Exists)
            {
                App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = false;
            int existingRecords = App.DB.ImportValidation.Parts_CheckPreImportCount();
            if (existingRecords > 0)
            {
                if (App.ShowMessage("There are already parts in the pre-import table.  You should process or clear them before importing more data.  Clear Now?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    App.DB.ImportValidation.Parts_ClearPreImport();
                }
                else
                {
                    return;
                }
            }

            if (App.ShowMessage("You are about to load data from the parts files, to the temporary holding table, do you wish to continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

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
                object obj = from a in excel.Worksheet("Upload Template")
                             select a;
                List<string> columnNames = excel.GetColumnNames("Upload Template").ToList();
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
                dt.Columns.Add("SupplierID");
                dt.Columns.Add("Partcode");
                dt.Columns.Add("Description");
                dt.Columns.Add("SupplierPartCode");
                dt.Columns.Add("SupplierPrice");
                dt.Columns.Add("SupplierSecondaryPrice");
                dt.Columns.Add("Category");
                for (int i = 0, loopTo = data.Rows.Count - 1; i <= loopTo; i++)
                {
                    var row = data.Rows[i];
                    int supplierId = Supplier.SupplierID;
                    string mpn = string.Empty;
                    string description = string.Empty;
                    string spn = string.Empty;
                    string category = string.Empty;
                    double netPrice = 0;
                    double pfhPrice = 0;
                    if (row["SPN"] == DBNull.Value)
                    {
                        goto nextrow;
                    }
                    else
                    {
                        spn = Helper.MakeStringValid(row["SPN"]);
                    }

                    if (row["MPN"] == DBNull.Value)
                    {
                        goto nextrow;
                    }
                    else
                    {
                        mpn = Helper.MakeStringValid(row["MPN"]);
                    }

                    description = Helper.MakeStringValid(row["Description"]);
                    if (row["Net Price"] == DBNull.Value)
                    {
                        goto nextrow;
                    }
                    else if (chkPFH.Checked)
                    {
                        pfhPrice = Helper.MakeDoubleValid(row["Net Price"]);
                    }
                    else
                    {
                        netPrice = Helper.MakeDoubleValid(row["Net Price"]);
                    }

                    category = Helper.MakeStringValid(row["Category"]);
                    lblMessages.Text = "Adding part " + (i + 1) + " of " + data.Rows.Count + " from file.";
                    lblMessages.Visible = true;
                    dt.Rows.Add(new object[] { supplierId, mpn, description, spn, netPrice, pfhPrice, category });
                nextrow:
                    ;
                    MoveProgressOn();
                }

                App.DB.ImportValidation.BulkInsert(dt);
                ValidateAllRecords();
                success = true;
            }
            catch (Exception ex)
            {
                lblMessages.Text = "Error!";
                App.ShowMessage("File data could not be imported : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MoveProgressOn(true);
                if (success)
                {
                    try
                    {
                        string sup = chkPFH.Checked ? Supplier.Name + "_PFH" : Supplier.Name;
                        string filePath = App.TheSystem.Configuration.DocumentsLocation + @"PartsFiles\" + sup + @"\";
                        Directory.CreateDirectory(filePath);
                        string fileType = Path.GetExtension(File.Name);
                        System.IO.File.Move(File.FullName, filePath + File.Name.Replace(fileType, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + fileType));
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Data imported and validated but file has not been moved to archive as ... " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                File = null;
                txtExcelFile.Text = "";
                pbStatus.Value = pbStatus.Maximum;
                btnFindExcelFile.Enabled = true;
                btnImport.Enabled = true;
                pbStatus.Value = 0;
                Cursor.Current = Cursors.Default;
            }
        }

        private void FindSupplier()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier));
            if (!(ID == 0))
            {
                Supplier = App.DB.Supplier.Supplier_Get(ID);
            }
        }

        private void ValidateAllRecords()
        {
            lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            int Steps = (int)Enum.GetValues(typeof(Enums.PartValidationResults)).Cast<Enums.PartValidationResults>().Max();
            pbStatus.Value = 0;
            pbStatus.Maximum = Steps + 1;

            // For i As Integer = Steps To 0 Step -1
            App.DB.ImportValidation.Parts_ValidatePreImportData(0, chkPFH.Checked); // i
            MoveProgressOn();
            // Next

            var argcombo = cboValidateType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            ShowData();
            Cursor.Current = Cursors.Default;
            // ShowMessage("Validation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblMessages.Text = "Validation Complete!";
            lblMessages.Visible = true;
        }

        private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", App.TheSystem.Configuration.DocumentsLocation + "PartsFiles");
        }
    }
}