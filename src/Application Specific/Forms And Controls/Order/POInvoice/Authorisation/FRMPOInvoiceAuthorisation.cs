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
            this._grpExcelFile = new System.Windows.Forms.GroupBox();
            this._btnExportResults = new System.Windows.Forms.Button();
            this._tcData = new System.Windows.Forms.TabControl();
            this._btnClose = new System.Windows.Forms.Button();
            this._pbStatus = new System.Windows.Forms.ProgressBar();
            this._lblProgress = new System.Windows.Forms.Label();
            this._lblMessages = new System.Windows.Forms.Label();
            this._cboValidateType = new System.Windows.Forms.ComboBox();
            this._grpCatImport = new System.Windows.Forms.GroupBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._cboDepartment = new System.Windows.Forms.ComboBox();
            this._grpExcelFile.SuspendLayout();
            this._grpCatImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpExcelFile
            // 
            this._grpExcelFile.Controls.Add(this._btnExportResults);
            this._grpExcelFile.Location = new System.Drawing.Point(8, 11);
            this._grpExcelFile.Name = "_grpExcelFile";
            this._grpExcelFile.Size = new System.Drawing.Size(259, 57);
            this._grpExcelFile.TabIndex = 3;
            this._grpExcelFile.TabStop = false;
            this._grpExcelFile.Text = "Initial Import";
            // 
            // _btnExportResults
            // 
            this._btnExportResults.Location = new System.Drawing.Point(6, 19);
            this._btnExportResults.Name = "_btnExportResults";
            this._btnExportResults.Size = new System.Drawing.Size(106, 23);
            this._btnExportResults.TabIndex = 5;
            this._btnExportResults.Text = "Export Results";
            this._btnExportResults.UseVisualStyleBackColor = true;
            this._btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // _tcData
            // 
            this._tcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tcData.Location = new System.Drawing.Point(8, 74);
            this._tcData.Name = "_tcData";
            this._tcData.SelectedIndex = 0;
            this._tcData.Size = new System.Drawing.Size(1081, 517);
            this._tcData.TabIndex = 8;
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.Location = new System.Drawing.Point(1005, 621);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 9;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pbStatus
            // 
            this._pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbStatus.Location = new System.Drawing.Point(8, 621);
            this._pbStatus.Name = "_pbStatus";
            this._pbStatus.Size = new System.Drawing.Size(941, 23);
            this._pbStatus.Step = 1;
            this._pbStatus.TabIndex = 10;
            // 
            // _lblProgress
            // 
            this._lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblProgress.Location = new System.Drawing.Point(957, 624);
            this._lblProgress.Name = "_lblProgress";
            this._lblProgress.Size = new System.Drawing.Size(40, 16);
            this._lblProgress.TabIndex = 11;
            this._lblProgress.Text = "0%";
            this._lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblMessages
            // 
            this._lblMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblMessages.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblMessages.ForeColor = System.Drawing.Color.Red;
            this._lblMessages.Location = new System.Drawing.Point(5, 594);
            this._lblMessages.Name = "_lblMessages";
            this._lblMessages.Size = new System.Drawing.Size(1057, 19);
            this._lblMessages.TabIndex = 12;
            this._lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblMessages.Visible = false;
            // 
            // _cboValidateType
            // 
            this._cboValidateType.FormattingEnabled = true;
            this._cboValidateType.Location = new System.Drawing.Point(6, 21);
            this._cboValidateType.Name = "_cboValidateType";
            this._cboValidateType.Size = new System.Drawing.Size(365, 21);
            this._cboValidateType.TabIndex = 1;
            this._cboValidateType.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted);
            // 
            // _grpCatImport
            // 
            this._grpCatImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCatImport.Controls.Add(this._Label1);
            this._grpCatImport.Controls.Add(this._cboDepartment);
            this._grpCatImport.Controls.Add(this._cboValidateType);
            this._grpCatImport.Location = new System.Drawing.Point(245, 11);
            this._grpCatImport.Name = "_grpCatImport";
            this._grpCatImport.Size = new System.Drawing.Size(844, 57);
            this._grpCatImport.TabIndex = 6;
            this._grpCatImport.TabStop = false;
            this._grpCatImport.Text = "Category Processing";
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(377, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(85, 13);
            this._Label1.TabIndex = 3;
            this._Label1.Text = "Cost Centre :";
            this._Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cboDepartment
            // 
            this._cboDepartment.FormattingEnabled = true;
            this._cboDepartment.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this._cboDepartment.Location = new System.Drawing.Point(467, 21);
            this._cboDepartment.Name = "_cboDepartment";
            this._cboDepartment.Size = new System.Drawing.Size(199, 21);
            this._cboDepartment.TabIndex = 2;
            this._cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted);
            // 
            // FRMPOInvoiceAuthorisation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1101, 654);
            this.Controls.Add(this._grpCatImport);
            this.Controls.Add(this._lblMessages);
            this.Controls.Add(this._lblProgress);
            this.Controls.Add(this._pbStatus);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._tcData);
            this.Controls.Add(this._grpExcelFile);
            this.MinimumSize = new System.Drawing.Size(920, 688);
            this.Name = "FRMPOInvoiceAuthorisation";
            this.Text = "PO Invoice Authorisation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpExcelFile.ResumeLayout(false);
            this._grpCatImport.ResumeLayout(false);
            this._grpCatImport.PerformLayout();
            this.ResumeLayout(false);

        }

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
                lblProgress.Text = Math.Floor(pbStatus.Value / (decimal)pbStatus.Maximum * 100) + "%";
            }

            Application.DoEvents();
        }
    }
}