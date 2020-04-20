using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Customers;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMImport : FRMBaseForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMImport() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            this.Load += FRMImport_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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
        private GroupBox _grpImporter;

        internal GroupBox grpImporter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpImporter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpImporter != null)
                {
                }

                _grpImporter = value;
                if (_grpImporter != null)
                {
                }
            }
        }

        private TextBox _txtFileLocation;

        internal TextBox txtFileLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFileLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFileLocation != null)
                {
                }

                _txtFileLocation = value;
                if (_txtFileLocation != null)
                {
                }
            }
        }

        private Button _btnFindFile;

        internal Button btnFindFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindFile != null)
                {
                    _btnFindFile.Click -= btnFindFile_Click;
                }

                _btnFindFile = value;
                if (_btnFindFile != null)
                {
                    _btnFindFile.Click += btnFindFile_Click;
                }
            }
        }

        private LinkLabel _btnTemplateFile;

        internal LinkLabel btnTemplateFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTemplateFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTemplateFile != null)
                {
                    _btnTemplateFile.LinkClicked -= btnTemplateFile_LinkClicked;
                }

                _btnTemplateFile = value;
                if (_btnTemplateFile != null)
                {
                    _btnTemplateFile.LinkClicked += btnTemplateFile_LinkClicked;
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
                    _btnExport.Click -= btnClose_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnClose_Click;
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

        private Label _lblCustomer;

        internal Label lblCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomer != null)
                {
                }

                _lblCustomer = value;
                if (_lblCustomer != null)
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
                    _btnFindCustomer.Click -= btnSupplier_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnSupplier_Click;
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

        private GroupBox _grpErrors;

        internal GroupBox grpErrors
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpErrors;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpErrors != null)
                {
                }

                _grpErrors = value;
                if (_grpErrors != null)
                {
                }
            }
        }

        private DataGrid _dgErrors;

        internal DataGrid dgErrors
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgErrors;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgErrors != null)
                {
                }

                _dgErrors = value;
                if (_dgErrors != null)
                {
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
            _grpImporter = new GroupBox();
            _lblFile = new Label();
            _txtCustomer = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnSupplier_Click);
            _lblCustomer = new Label();
            _btnImport = new Button();
            _btnImport.Click += new EventHandler(btnImport_Click);
            _btnFindFile = new Button();
            _btnFindFile.Click += new EventHandler(btnFindFile_Click);
            _txtFileLocation = new TextBox();
            _btnTemplateFile = new LinkLabel();
            _btnTemplateFile.LinkClicked += new LinkLabelLinkClickedEventHandler(btnTemplateFile_LinkClicked);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnClose_Click);
            _pbStatus = new ProgressBar();
            _lblProgress = new Label();
            _lblMessages = new Label();
            _grpErrors = new GroupBox();
            _dgErrors = new DataGrid();
            _grpImporter.SuspendLayout();
            _grpErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgErrors).BeginInit();
            SuspendLayout();
            // 
            // grpImporter
            // 
            _grpImporter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpImporter.Controls.Add(_lblFile);
            _grpImporter.Controls.Add(_txtCustomer);
            _grpImporter.Controls.Add(_btnFindCustomer);
            _grpImporter.Controls.Add(_lblCustomer);
            _grpImporter.Controls.Add(_btnImport);
            _grpImporter.Controls.Add(_btnFindFile);
            _grpImporter.Controls.Add(_txtFileLocation);
            _grpImporter.Location = new Point(8, 40);
            _grpImporter.Name = "grpImporter";
            _grpImporter.Size = new Size(896, 115);
            _grpImporter.TabIndex = 3;
            _grpImporter.TabStop = false;
            _grpImporter.Text = "Import";
            // 
            // lblFile
            // 
            _lblFile.AutoSize = true;
            _lblFile.Location = new Point(6, 52);
            _lblFile.Name = "lblFile";
            _lblFile.Size = new Size(31, 13);
            _lblFile.TabIndex = 13;
            _lblFile.Text = "File:";
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Location = new Point(86, 20);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(766, 21);
            _txtCustomer.TabIndex = 12;
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.Location = new Point(858, 20);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 11;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = true;
            // 
            // lblCustomer
            // 
            _lblCustomer.AutoSize = true;
            _lblCustomer.Location = new Point(6, 23);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(68, 13);
            _lblCustomer.TabIndex = 9;
            _lblCustomer.Text = "Customer:";
            // 
            // btnImport
            // 
            _btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnImport.Enabled = false;
            _btnImport.Location = new Point(826, 84);
            _btnImport.Name = "btnImport";
            _btnImport.Size = new Size(64, 23);
            _btnImport.TabIndex = 7;
            _btnImport.Text = "Import";
            _btnImport.UseVisualStyleBackColor = true;
            // 
            // btnFindFile
            // 
            _btnFindFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindFile.Location = new Point(858, 49);
            _btnFindFile.Name = "btnFindFile";
            _btnFindFile.Size = new Size(32, 23);
            _btnFindFile.TabIndex = 5;
            _btnFindFile.Text = "...";
            _btnFindFile.UseVisualStyleBackColor = true;
            // 
            // txtFileLocation
            // 
            _txtFileLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFileLocation.Location = new Point(86, 49);
            _txtFileLocation.Name = "txtFileLocation";
            _txtFileLocation.ReadOnly = true;
            _txtFileLocation.Size = new Size(766, 21);
            _txtFileLocation.TabIndex = 4;
            // 
            // btnTemplateFile
            // 
            _btnTemplateFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnTemplateFile.Location = new Point(816, 8);
            _btnTemplateFile.Name = "btnTemplateFile";
            _btnTemplateFile.Size = new Size(88, 23);
            _btnTemplateFile.TabIndex = 1;
            _btnTemplateFile.TabStop = true;
            _btnTemplateFile.Text = "Template File";
            // 
            // btnExport
            // 
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnExport.Location = new Point(848, 624);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 9;
            _btnExport.Text = "Export";
            _btnExport.UseVisualStyleBackColor = true;
            // 
            // pbStatus
            // 
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(8, 624);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(784, 23);
            _pbStatus.Step = 1;
            _pbStatus.TabIndex = 10;
            // 
            // lblProgress
            // 
            _lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblProgress.Location = new Point(800, 627);
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
            _lblMessages.Location = new Point(5, 595);
            _lblMessages.Name = "lblMessages";
            _lblMessages.Size = new Size(900, 19);
            _lblMessages.TabIndex = 12;
            _lblMessages.TextAlign = ContentAlignment.MiddleLeft;
            _lblMessages.Visible = false;
            // 
            // grpErrors
            // 
            _grpErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpErrors.Controls.Add(_dgErrors);
            _grpErrors.Location = new Point(8, 161);
            _grpErrors.Name = "grpErrors";
            _grpErrors.Size = new Size(896, 453);
            _grpErrors.TabIndex = 14;
            _grpErrors.TabStop = false;
            _grpErrors.Text = "Errors";
            // 
            // dgErrors
            // 
            _dgErrors.DataMember = "";
            _dgErrors.Dock = DockStyle.Fill;
            _dgErrors.HeaderForeColor = SystemColors.ControlText;
            _dgErrors.Location = new Point(3, 17);
            _dgErrors.Name = "dgErrors";
            _dgErrors.Size = new Size(890, 433);
            _dgErrors.TabIndex = 2;
            // 
            // FRMImport
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(912, 654);
            Controls.Add(_grpErrors);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_btnExport);
            Controls.Add(_btnTemplateFile);
            Controls.Add(_grpImporter);
            MinimumSize = new Size(920, 688);
            Name = "FRMImport";
            Text = "Site Importer";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpImporter, 0);
            Controls.SetChildIndex(_btnTemplateFile, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_grpErrors, 0);
            _grpImporter.ResumeLayout(false);
            _grpImporter.PerformLayout();
            _grpErrors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgErrors).EndInit();
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private System.IO.FileInfo _file;

        public System.IO.FileInfo File
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

        private DataTable _failedImports = new DataTable();

        private DataTable FailedImports
        {
            get
            {
                return _failedImports;
            }

            set
            {
                _failedImports = value;
            }
        }

        private Customer _customer;

        private Customer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
                if (Customer is object)
                {
                    txtCustomer.Text = Customer.Name;
                }
                else
                {
                    txtCustomer.Text = string.Empty;
                }
            }
        }

        private void FRMImport_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnTemplateFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dlg = default(FolderBrowserDialog);
            var oExcel = default(Microsoft.Office.Interop.Excel.Application);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    oExcel = new Microsoft.Office.Interop.Excel.Application();
                    oExcel.Workbooks.Add(Application.StartupPath + @"\Templates\SiteImporter.xlsx");
                    if (System.IO.File.Exists(dlg.SelectedPath + @"\SiteImporter.xlsx"))
                    {
                        System.IO.File.Delete(dlg.SelectedPath + @"\SiteImporter.xlsx");
                    }

                    oExcel.Workbooks.get_Item(1).SaveAs(dlg.SelectedPath + @"\SiteImporter.xlsx");
                    App.ShowMessage("File downloaded to " + dlg.SelectedPath + @"\SiteImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Template could not be saved : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dlg.Dispose();
                KillInstances(oExcel);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FindCustomer();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadData()
        {
            var dlg = default(OpenFileDialog);
            Microsoft.Office.Interop.Excel.Application oExcel;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnFindFile.Enabled = false;
                btnImport.Enabled = false;
                txtFileLocation.Text = "";
                dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var tempfile = new System.IO.FileInfo(dlg.FileName);

                    // Is it an excel file?
                    if ((tempfile.Extension ?? "") == ".xls" | (tempfile.Extension ?? "") == ".xlsx")
                    {
                        File = tempfile;
                        // Is an Excel file
                        txtFileLocation.Text = File.FullName;
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
                txtFileLocation.Text = "";
                btnImport.Enabled = false;
                App.ShowMessage("File data could not be loaded : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dlg.Dispose();
                btnFindFile.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void Import()
        {
            if (Customer is null)
            {
                App.ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var oExcel = default(Microsoft.Office.Interop.Excel.Application);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnFindFile.Enabled = false;
                btnImport.Enabled = false;
                pbStatus.Value = 0;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                oExcel.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Worksheet oWorksheet;
                oExcel.Workbooks.Add(File.FullName);
                oWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.Worksheets[1];
                string strCom = " SELECT * FROM [" + oWorksheet.Name + "$]";
                string strCon = "";
                if ((File.Extension.Trim().ToLower() ?? "") == (".xls".ToLower() ?? ""))
                {
                    strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + File.FullName + " ; Extended Properties=Excel 8.0; ";
                }
                else if ((File.Extension.Trim().ToLower() ?? "") == (".xlsx".ToLower() ?? ""))
                {
                    strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + File.FullName + " ; Extended Properties=Excel 12.0; ";
                }

                var conn = new System.Data.OleDb.OleDbConnection(strCon);
                var adapter = new System.Data.OleDb.OleDbDataAdapter();
                var data = new DataSet();
                adapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strCom, conn);
                data.Clear();
                adapter.Fill(data);
                data.Tables[0].Columns.Add("Failure Reason");
                FailedImports = data.Tables[0].Clone();
                pbStatus.Maximum = data.Tables[0].Rows.Count;
                for (int i = 0, loopTo = data.Tables[0].Rows.Count - 1; i <= loopTo; i++)
                {
                    var row = data.Tables[0].Rows[i];
                    string uprn = string.Empty;
                    string address1 = string.Empty;
                    string address2 = string.Empty;
                    string address3 = string.Empty;
                    string postcode = string.Empty;
                    string fuel = string.Empty;
                    DateTime lsd = default;
                    string firstName = string.Empty;
                    string lastName = string.Empty;
                    string telNo = string.Empty;
                    string mobNo = string.Empty;
                    string email = string.Empty;
                    DateTime buildDate = default;
                    int warrantyPeriodInMonths = 0;
                    uprn = Helper.MakeStringValid(row["UPRN"]);
                    if (row["Address1"] == DBNull.Value)
                    {
                        row["Failure Reason"] = "No address 1";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                    else
                    {
                        address1 = Helper.MakeStringValid(row["Address1"]);
                    }

                    address2 = Helper.MakeStringValid(row["Address2"]);
                    address3 = Helper.MakeStringValid(row["Address3"]);
                    if (row["Postcode"] == DBNull.Value)
                    {
                        row["Failure Reason"] = "No postcode";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                    else
                    {
                        postcode = Helper.ConvertToPostcode(row["Postcode"]);
                        if (!postcode.Contains("-") | postcode.Length > 9)
                        {
                            row["Failure Reason"] = "Invalid postocde format";
                            FailedImports.ImportRow(row);
                            goto nextrow;
                        }
                    }

                    lsd = Helper.MakeDateTimeValid(row["LastServiceDate"]);
                    fuel = Helper.MakeStringValid(row["Fuel"]);
                    firstName = Helper.MakeStringValid(row["FirstName"]);
                    lastName = Helper.MakeStringValid(row["LastName"]);
                    telNo = Helper.MakeStringValid(row["TelNo"]);
                    mobNo = Helper.MakeStringValid(row["MobNo"]);
                    email = Helper.MakeStringValid(row["Email"]);
                    buildDate = Helper.MakeDateTimeValid(row["BuildDate"]);
                    warrantyPeriodInMonths = Helper.MakeIntegerValid(row["WarrantyPeriodInMonths"]);
                    string name = string.Empty;
                    if (!string.IsNullOrWhiteSpace(firstName))
                        name = firstName + " ";
                    if (!string.IsNullOrWhiteSpace(lastName))
                        name += lastName;
                    var site = App.DB.Sites.Get(uprn, SiteSQL.GetBy.Uprn, Customer.CustomerID);
                    if (site is object)
                        continue;
                    site = new Site();
                    {
                        var withBlock = site;
                        withBlock.IgnoreExceptionsOnSetMethods = true;
                        withBlock.SetPolicyNumber = uprn;
                        withBlock.SetAddress1 = address1;
                        withBlock.SetAddress2 = address2;
                        withBlock.SetAddress3 = address3;
                        withBlock.SetPostcode = postcode;
                        withBlock.LastServiceDate = lsd;
                        withBlock.SetSiteFuel = fuel;
                        withBlock.SetCustomerID = Customer.CustomerID;
                        withBlock.SetRegionID = Customer.RegionID;
                        withBlock.SetCommercialDistrict = 0;
                        withBlock.SetEngineerID = 0;
                        withBlock.SetHeadOffice = false;
                        withBlock.SetNoMarketing = false;
                        withBlock.SetNoService = false;
                        withBlock.SetOnStop = false;
                        withBlock.SetPoNumReqd = false;
                        withBlock.SetSolidFuel = false;
                        withBlock.SetFirstName = firstName;
                        withBlock.SetSurname = lastName;
                        withBlock.SetTelephoneNum = telNo;
                        withBlock.SetFaxNum = mobNo;
                        withBlock.SetEmailAddress = email;
                        if (!string.IsNullOrWhiteSpace(name))
                            withBlock.SetName = name;
                        if (buildDate != default)
                            withBlock.BuildDate = buildDate;
                        withBlock.SetWarrantyPeriodInMonths = warrantyPeriodInMonths;
                    }

                    site = App.DB.Sites.Insert(site);
                    if (lsd == default)
                        goto nextrow;
                    App.DB.Sites.Site_UpdateLastServiceDate(site.SiteID, lsd, lsd, true);
                    var siteFuel = new SiteFuel();
                    siteFuel.SetSiteID = site.SiteID;
                    siteFuel.LastServiceDate = lsd;
                    siteFuel.ActualServiceDate = lsd;
                    if (!string.IsNullOrWhiteSpace(fuel))
                    {
                        switch (true)
                        {
                            case object _ when fuel.ToLower().Contains("gas"):
                                {
                                    siteFuel.SetFuelID = Conversions.ToInteger(Enums.FuelTypes.NatGas);
                                    break;
                                }

                            case object _ when fuel.ToLower().Contains("solid"):
                                {
                                    siteFuel.SetFuelID = Conversions.ToInteger(Enums.FuelTypes.SolidFuel);
                                    break;
                                }

                            case object _ when fuel.ToLower().Contains("oil"):
                                {
                                    siteFuel.SetFuelID = Conversions.ToInteger(Enums.FuelTypes.Oil);
                                    break;
                                }

                            case object _ when fuel.ToLower().Contains("eletric"):
                                {
                                    siteFuel.SetFuelID = Conversions.ToInteger(Enums.FuelTypes.Electric);
                                    break;
                                }
                        }
                    }

                    siteFuel.SetSiteFuelChargeID = 0;
                    App.DB.Sites.SiteFuel_Update(siteFuel);
                nextrow:
                    ;
                    MoveProgressOn();
                }

                MoveProgressOn(true);
                App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMessages.Visible = false;
                if (FailedImports.Rows.Count > 0)
                {
                    dgErrors.DataSource = FailedImports;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("File data could not be imported : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                KillInstances(oExcel);
                File = null;
                txtFileLocation.Text = "";
                if (FailedImports.Rows.Count > 0)
                {
                    btnExport.Visible = true;
                }

                pbStatus.Value = pbStatus.Maximum;
                btnFindFile.Enabled = true;
                btnImport.Enabled = true;
                pbStatus.Value = 0;
                Cursor.Current = Cursors.Default;
            }
        }

        private void Export()
        {
            if (FailedImports.Rows.Count > 0)
            {
                ExportHelper.Export(FailedImports, "Failed Sites", Enums.ExportType.XLS);
                FailedImports.Clear();
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

        private void FindCustomer()
        {
            int id = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (id > 0)
            {
                Customer = App.DB.Customer.Customer_Get(id);
            }
        }

        private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
        {
            ;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
            /* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 30053


            Input:
                    On Error Resume Next

             */
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            GC.Collect();
            var mp = Process.GetProcessesByName("EXCEL");
            Process p;
            foreach (var p in mp)
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
            };
#error Cannot convert OnErrorGoToStatementSyntax - see comment for details
            /* Cannot convert OnErrorGoToStatementSyntax, CONVERSION ERROR: Conversion for OnErrorGoToMinusOneStatement not implemented, please report this issue in 'On Error GoTo - 1' at character 30658


            Input:

                    On Error GoTo - 1

             */
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}