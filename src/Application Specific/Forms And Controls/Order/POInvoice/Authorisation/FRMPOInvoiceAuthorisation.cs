using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMPOInvoiceAuthorisation : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMPOInvoiceAuthorisation() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboValidateType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.POInvoiceAuthorisation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc1 = cboDepartment;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc2 = cboDepartment;
                        Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

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

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
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
                    _cboValidateType.SelectionChangeCommitted -= SelectionChangeCommitted;
                }

                _cboValidateType = value;
                if (_cboValidateType != null)
                {
                    _cboValidateType.SelectionChangeCommitted += SelectionChangeCommitted;
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
                    _cboDepartment.SelectionChangeCommitted -= SelectionChangeCommitted;
                }

                _cboDepartment = value;
                if (_cboDepartment != null)
                {
                    _cboDepartment.SelectionChangeCommitted += SelectionChangeCommitted;
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
            _btnExportResults = new Button();
            _btnExportResults.Click += new EventHandler(btnExportResults_Click);
            _tcData = new TabControl();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pbStatus = new ProgressBar();
            _lblProgress = new Label();
            _lblMessages = new Label();
            _cboValidateType = new ComboBox();
            _cboValidateType.SelectionChangeCommitted += new EventHandler(SelectionChangeCommitted);
            _grpCatImport = new GroupBox();
            _Label1 = new Label();
            _cboDepartment = new ComboBox();
            _cboDepartment.SelectionChangeCommitted += new EventHandler(SelectionChangeCommitted);
            _grpExcelFile.SuspendLayout();
            _grpCatImport.SuspendLayout();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Controls.Add(_btnExportResults);
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(231, 57);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Initial Import";
            //
            // btnExportResults
            //
            _btnExportResults.Location = new Point(6, 19);
            _btnExportResults.Name = "btnExportResults";
            _btnExportResults.Size = new Size(106, 23);
            _btnExportResults.TabIndex = 5;
            _btnExportResults.Text = "Export Results";
            _btnExportResults.UseVisualStyleBackColor = true;
            //
            // tcData
            //
            _tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcData.Location = new Point(8, 103);
            _tcData.Name = "tcData";
            _tcData.SelectedIndex = 0;
            _tcData.Size = new Size(1053, 483);
            _tcData.TabIndex = 8;
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClose.Location = new Point(1005, 621);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 9;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(8, 621);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(941, 23);
            _pbStatus.Step = 1;
            _pbStatus.TabIndex = 10;
            //
            // lblProgress
            //
            _lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblProgress.Location = new Point(957, 624);
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
            _lblMessages.Location = new Point(5, 594);
            _lblMessages.Name = "lblMessages";
            _lblMessages.Size = new Size(1057, 19);
            _lblMessages.TabIndex = 12;
            _lblMessages.TextAlign = ContentAlignment.MiddleLeft;
            _lblMessages.Visible = false;
            //
            // cboValidateType
            //
            _cboValidateType.FormattingEnabled = true;
            _cboValidateType.Location = new Point(6, 21);
            _cboValidateType.Name = "cboValidateType";
            _cboValidateType.Size = new Size(365, 21);
            _cboValidateType.TabIndex = 1;
            //
            // grpCatImport
            //
            _grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCatImport.Controls.Add(_Label1);
            _grpCatImport.Controls.Add(_cboDepartment);
            _grpCatImport.Controls.Add(_cboValidateType);
            _grpCatImport.Location = new Point(245, 40);
            _grpCatImport.Name = "grpCatImport";
            _grpCatImport.Size = new Size(816, 57);
            _grpCatImport.TabIndex = 6;
            _grpCatImport.TabStop = false;
            _grpCatImport.Text = "Category Processing";
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(377, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(85, 13);
            _Label1.TabIndex = 3;
            _Label1.Text = "Cost Centre :";
            _Label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // cboDepartment
            //
            _cboDepartment.FormattingEnabled = true;
            _cboDepartment.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            _cboDepartment.Location = new Point(467, 21);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(199, 21);
            _cboDepartment.TabIndex = 2;
            //
            // FRMPOInvoiceAuthorisation
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1101, 654);
            Controls.Add(_grpCatImport);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_btnClose);
            Controls.Add(_tcData);
            Controls.Add(_grpExcelFile);
            MinimumSize = new Size(920, 688);
            Name = "FRMPOInvoiceAuthorisation";
            Text = "PO Invoice Authorisation";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpExcelFile, 0);
            Controls.SetChildIndex(_tcData, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_grpCatImport, 0);
            _grpExcelFile.ResumeLayout(false);
            _grpCatImport.ResumeLayout(false);
            _grpCatImport.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
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
                if (string.IsNullOrEmpty(Combo.get_GetSelectedItemDescription(cboDepartment)))
                {
                    sql = "EXEC POInvoiceImport_ExportResultsAuthorisation " + Combo.get_GetSelectedItemValue(cboValidateType);
                }
                else
                {
                    sql = "EXEC POInvoiceImport_ExportResultsAuthorisation " + Combo.get_GetSelectedItemValue(cboValidateType) + ", " + Combo.get_GetSelectedItemValue(cboDepartment);
                }

                data = new DataView(App.DB.ExecuteWithReturn(sql));
                if (data.Count == 0)
                {
                    App.ShowMessage("No Data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (DataColumn col in data.Table.Columns)
                {
                    if (col.DataType == Type.GetType("System.String"))
                    {
                        foreach (DataRow row in data.Table.Rows)
                            row[col.ColumnName] = "'" + row[col.ColumnName];
                    }
                }

                sheetName = "POInvoiceAuthExport" + Conversions.ToString(DateAndTime.Today).Replace("/", "");
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

        private void SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Department;
            if (string.IsNullOrEmpty(Combo.get_GetSelectedItemDescription(cboDepartment)))
            {
                Department = "%";
            }
            else if (App.IsGasway)
            {
                Department = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboDepartment)).ToString();
            }
            else
            {
                Department = Combo.get_GetSelectedItemValue(cboDepartment);
            }

            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)), Department);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void ShowData(int ValidateType = 0, string Department = null)
        {
            tcData.TabPages.Clear();
            var tp = new TabPage();
            var data = new UCDataPOInvoiceAuthorisation();
            data.Dock = DockStyle.Fill;
            data.Data = App.DB.POInvoice.POInvoiceImport_RefreshData(ValidateType, Department);
            data.ValidateType = Combo.get_GetSelectedItemValue(cboValidateType);
            data.Department = Combo.get_GetSelectedItemValue(cboDepartment);
            tp.Text = "PO Invoice Authorisation Data (" + data.Data.Count + " Records)";
            tp.Controls.Add(data);
            tcData.TabPages.Add(tp);
            tcData.SelectedIndex = 0;
            MoveProgressOn(true);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}