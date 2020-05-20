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
        public FRMImport() : base()
        {
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

        private Label _lblFile;

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
            this._grpImporter = new System.Windows.Forms.GroupBox();
            this._lblFile = new System.Windows.Forms.Label();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._lblCustomer = new System.Windows.Forms.Label();
            this._btnImport = new System.Windows.Forms.Button();
            this._btnFindFile = new System.Windows.Forms.Button();
            this._txtFileLocation = new System.Windows.Forms.TextBox();
            this._btnTemplateFile = new System.Windows.Forms.LinkLabel();
            this._btnExport = new System.Windows.Forms.Button();
            this._pbStatus = new System.Windows.Forms.ProgressBar();
            this._lblProgress = new System.Windows.Forms.Label();
            this._lblMessages = new System.Windows.Forms.Label();
            this._grpErrors = new System.Windows.Forms.GroupBox();
            this._dgErrors = new System.Windows.Forms.DataGrid();
            this._grpImporter.SuspendLayout();
            this._grpErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpImporter
            // 
            this._grpImporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpImporter.Controls.Add(this._lblFile);
            this._grpImporter.Controls.Add(this._txtCustomer);
            this._grpImporter.Controls.Add(this._btnFindCustomer);
            this._grpImporter.Controls.Add(this._lblCustomer);
            this._grpImporter.Controls.Add(this._btnImport);
            this._grpImporter.Controls.Add(this._btnTemplateFile);
            this._grpImporter.Controls.Add(this._btnFindFile);
            this._grpImporter.Controls.Add(this._txtFileLocation);
            this._grpImporter.Location = new System.Drawing.Point(8, 12);
            this._grpImporter.Name = "_grpImporter";
            this._grpImporter.Size = new System.Drawing.Size(896, 143);
            this._grpImporter.TabIndex = 3;
            this._grpImporter.TabStop = false;
            this._grpImporter.Text = "Import";
            // 
            // _lblFile
            // 
            this._lblFile.AutoSize = true;
            this._lblFile.Location = new System.Drawing.Point(6, 74);
            this._lblFile.Name = "_lblFile";
            this._lblFile.Size = new System.Drawing.Size(31, 13);
            this._lblFile.TabIndex = 13;
            this._lblFile.Text = "File:";
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Location = new System.Drawing.Point(86, 42);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(766, 21);
            this._txtCustomer.TabIndex = 12;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.Location = new System.Drawing.Point(858, 42);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 11;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = true;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // _lblCustomer
            // 
            this._lblCustomer.AutoSize = true;
            this._lblCustomer.Location = new System.Drawing.Point(6, 45);
            this._lblCustomer.Name = "_lblCustomer";
            this._lblCustomer.Size = new System.Drawing.Size(68, 13);
            this._lblCustomer.TabIndex = 9;
            this._lblCustomer.Text = "Customer:";
            // 
            // _btnImport
            // 
            this._btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnImport.Enabled = false;
            this._btnImport.Location = new System.Drawing.Point(826, 106);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(64, 23);
            this._btnImport.TabIndex = 7;
            this._btnImport.Text = "Import";
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // _btnFindFile
            // 
            this._btnFindFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindFile.Location = new System.Drawing.Point(858, 71);
            this._btnFindFile.Name = "_btnFindFile";
            this._btnFindFile.Size = new System.Drawing.Size(32, 23);
            this._btnFindFile.TabIndex = 5;
            this._btnFindFile.Text = "...";
            this._btnFindFile.UseVisualStyleBackColor = true;
            this._btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // _txtFileLocation
            // 
            this._txtFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFileLocation.Location = new System.Drawing.Point(86, 71);
            this._txtFileLocation.Name = "_txtFileLocation";
            this._txtFileLocation.ReadOnly = true;
            this._txtFileLocation.Size = new System.Drawing.Size(766, 21);
            this._txtFileLocation.TabIndex = 4;
            // 
            // _btnTemplateFile
            // 
            this._btnTemplateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTemplateFile.Location = new System.Drawing.Point(802, 16);
            this._btnTemplateFile.Name = "_btnTemplateFile";
            this._btnTemplateFile.Size = new System.Drawing.Size(88, 23);
            this._btnTemplateFile.TabIndex = 1;
            this._btnTemplateFile.TabStop = true;
            this._btnTemplateFile.Text = "Template File";
            this._btnTemplateFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnTemplateFile_LinkClicked);
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExport.Location = new System.Drawing.Point(848, 624);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 9;
            this._btnExport.Text = "Export";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pbStatus
            // 
            this._pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbStatus.Location = new System.Drawing.Point(8, 624);
            this._pbStatus.Name = "_pbStatus";
            this._pbStatus.Size = new System.Drawing.Size(784, 23);
            this._pbStatus.Step = 1;
            this._pbStatus.TabIndex = 10;
            // 
            // _lblProgress
            // 
            this._lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblProgress.Location = new System.Drawing.Point(800, 627);
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
            this._lblMessages.Location = new System.Drawing.Point(5, 595);
            this._lblMessages.Name = "_lblMessages";
            this._lblMessages.Size = new System.Drawing.Size(900, 19);
            this._lblMessages.TabIndex = 12;
            this._lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblMessages.Visible = false;
            // 
            // _grpErrors
            // 
            this._grpErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpErrors.Controls.Add(this._dgErrors);
            this._grpErrors.Location = new System.Drawing.Point(8, 161);
            this._grpErrors.Name = "_grpErrors";
            this._grpErrors.Size = new System.Drawing.Size(896, 453);
            this._grpErrors.TabIndex = 14;
            this._grpErrors.TabStop = false;
            this._grpErrors.Text = "Errors";
            // 
            // _dgErrors
            // 
            this._dgErrors.DataMember = "";
            this._dgErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgErrors.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgErrors.Location = new System.Drawing.Point(3, 17);
            this._dgErrors.Name = "_dgErrors";
            this._dgErrors.Size = new System.Drawing.Size(890, 433);
            this._dgErrors.TabIndex = 2;
            // 
            // FRMImport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(912, 654);
            this.Controls.Add(this._grpErrors);
            this.Controls.Add(this._lblMessages);
            this.Controls.Add(this._lblProgress);
            this.Controls.Add(this._pbStatus);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpImporter);
            this.MinimumSize = new System.Drawing.Size(920, 688);
            this.Name = "FRMImport";
            this.Text = "Site Importer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpImporter.ResumeLayout(false);
            this._grpImporter.PerformLayout();
            this._grpErrors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgErrors)).EndInit();
            this.ResumeLayout(false);

        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

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
    }
}