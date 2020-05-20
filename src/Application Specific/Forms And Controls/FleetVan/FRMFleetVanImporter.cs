using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMFleetVanImporter : FRMBaseForm
    {
        public FRMFleetVanImporter() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        private GroupBox _grpFailedImports;

        private DataGrid _dgFailedImports;

        internal DataGrid dgFailedImports
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgFailedImports;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgFailedImports != null)
                {
                }

                _dgFailedImports = value;
                if (_dgFailedImports != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpExcelFile = new System.Windows.Forms.GroupBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnImport = new System.Windows.Forms.Button();
            this._btnFindExcelFile = new System.Windows.Forms.Button();
            this._txtExcelFile = new System.Windows.Forms.TextBox();
            this._grpFailedImports = new System.Windows.Forms.GroupBox();
            this._dgFailedImports = new System.Windows.Forms.DataGrid();
            this._grpExcelFile.SuspendLayout();
            this._grpFailedImports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgFailedImports)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpExcelFile
            // 
            this._grpExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpExcelFile.Controls.Add(this._Label2);
            this._grpExcelFile.Controls.Add(this._btnImport);
            this._grpExcelFile.Controls.Add(this._btnFindExcelFile);
            this._grpExcelFile.Controls.Add(this._txtExcelFile);
            this._grpExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpExcelFile.Location = new System.Drawing.Point(8, 12);
            this._grpExcelFile.Name = "_grpExcelFile";
            this._grpExcelFile.Size = new System.Drawing.Size(655, 64);
            this._grpExcelFile.TabIndex = 3;
            this._grpExcelFile.TabStop = false;
            this._grpExcelFile.Text = "Select file to import";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 22);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(31, 13);
            this._Label2.TabIndex = 13;
            this._Label2.Text = "File:";
            // 
            // _btnImport
            // 
            this._btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnImport.Enabled = false;
            this._btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnImport.Location = new System.Drawing.Point(574, 17);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(64, 23);
            this._btnImport.TabIndex = 7;
            this._btnImport.Text = "Import";
            this._btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // _btnFindExcelFile
            // 
            this._btnFindExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnFindExcelFile.Location = new System.Drawing.Point(536, 17);
            this._btnFindExcelFile.Name = "_btnFindExcelFile";
            this._btnFindExcelFile.Size = new System.Drawing.Size(32, 23);
            this._btnFindExcelFile.TabIndex = 5;
            this._btnFindExcelFile.Text = "...";
            this._btnFindExcelFile.Click += new System.EventHandler(this.btnFindExcelFile_Click);
            // 
            // _txtExcelFile
            // 
            this._txtExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtExcelFile.Location = new System.Drawing.Point(50, 19);
            this._txtExcelFile.Name = "_txtExcelFile";
            this._txtExcelFile.ReadOnly = true;
            this._txtExcelFile.Size = new System.Drawing.Size(480, 21);
            this._txtExcelFile.TabIndex = 4;
            // 
            // _grpFailedImports
            // 
            this._grpFailedImports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFailedImports.Controls.Add(this._dgFailedImports);
            this._grpFailedImports.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpFailedImports.Location = new System.Drawing.Point(8, 82);
            this._grpFailedImports.Name = "_grpFailedImports";
            this._grpFailedImports.Size = new System.Drawing.Size(655, 505);
            this._grpFailedImports.TabIndex = 14;
            this._grpFailedImports.TabStop = false;
            this._grpFailedImports.Text = "Failed Imports";
            // 
            // _dgFailedImports
            // 
            this._dgFailedImports.DataMember = "";
            this._dgFailedImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgFailedImports.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgFailedImports.Location = new System.Drawing.Point(3, 17);
            this._dgFailedImports.Name = "_dgFailedImports";
            this._dgFailedImports.Size = new System.Drawing.Size(649, 485);
            this._dgFailedImports.TabIndex = 45;
            // 
            // FRMFleetVanImporter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(671, 599);
            this.Controls.Add(this._grpFailedImports);
            this.Controls.Add(this._grpExcelFile);
            this.Name = "FRMFleetVanImporter";
            this.Text = "Fleet Van Mileage Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpExcelFile.ResumeLayout(false);
            this._grpExcelFile.PerformLayout();
            this._grpFailedImports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgFailedImports)).EndInit();
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

        private Entity.FleetVans.FleetVan _currentVan;

        public Entity.FleetVans.FleetVan CurrentVan
        {
            get
            {
                return _currentVan;
            }

            set
            {
                _currentVan = value;
                if (CurrentVan is null)
                {
                    CurrentVan = new Entity.FleetVans.FleetVan();
                    CurrentVan.Exists = false;
                }
            }
        }

        private Entity.FleetVans.FleetVanMaintenance _currentVanMaintenance;

        public Entity.FleetVans.FleetVanMaintenance CurrentVanMaintenance
        {
            get
            {
                return _currentVanMaintenance;
            }

            set
            {
                _currentVanMaintenance = value;
                if (CurrentVanMaintenance is null)
                {
                    CurrentVanMaintenance = new Entity.FleetVans.FleetVanMaintenance();
                    CurrentVanMaintenance.Exists = false;
                }
            }
        }

        private Entity.FleetVans.FleetVanContract _currentContract;

        public Entity.FleetVans.FleetVanContract CurrentContract
        {
            get
            {
                return _currentContract;
            }

            set
            {
                _currentContract = value;
                if (CurrentContract is null)
                {
                    CurrentContract = new Entity.FleetVans.FleetVanContract();
                    CurrentContract.Exists = false;
                }
            }
        }

        private List<FailedFleetVanImports> _failedVans = new List<FailedFleetVanImports>();

        private List<FailedFleetVanImports> FailedVans
        {
            get
            {
                return _failedVans;
            }

            set
            {
                _failedVans = value;
            }
        }

        public class FailedFleetVanImports
        {
            public string Driver { get; set; }
            public string Registration { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Mileage { get; set; }
        }

        private void btnFindExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void LoadData()
        {
            var dlg = default(OpenFileDialog);
            Microsoft.Office.Interop.Excel.Application oExcel;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnFindExcelFile.Enabled = false;
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var tempfile = new System.IO.FileInfo(dlg.FileName);

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
                dlg.Dispose();
                btnFindExcelFile.Enabled = true;
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

        private void Import()
        {
            var oExcel = default(Microsoft.Office.Interop.Excel.Application);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
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
                for (int i = 0, loopTo = data.Tables[0].Rows.Count - 1; i <= loopTo; i++)
                {
                    var Row = data.Tables[0].Rows[i];
                    string driver = string.Empty;
                    string reg = string.Empty;
                    string make = string.Empty;
                    string model = string.Empty;
                    int mileage = 0;
                    bool insertDB = true;
                    if (Row["Registration"] == DBNull.Value)
                    {
                        insertDB = false;
                    }
                    else
                    {
                        reg = Conversions.ToString(Row["Registration"]);
                        reg = reg.Replace(" ", string.Empty);
                    }

                    if (Row["End Odometer"] == DBNull.Value)
                    {
                        insertDB = false;
                    }
                    else
                    {
                        mileage = Entity.Sys.Helper.MakeIntegerValid(Row["End Odometer"]);
                    }

                    driver = Entity.Sys.Helper.MakeStringValid(Row["Driver Name"]);
                    make = Entity.Sys.Helper.MakeStringValid(Row["Make"]);
                    model = Entity.Sys.Helper.MakeStringValid(Row["Model"]);
                    if (insertDB)
                    {
                        CurrentVan = App.DB.FleetVan.Get_ByRegistration(reg);
                        if (CurrentVan.Exists)
                        {
                            CurrentVanMaintenance = App.DB.FleetVanMaintenance.Get_ByVanID(CurrentVan.VanID);
                            CurrentContract = App.DB.FleetVanContract.Get_ByVanID(CurrentVan.VanID);
                            CurrentVan.SetMileage = mileage;
                            RunEstimateUpdates();
                            App.DB.FleetVan.Update(CurrentVan);
                            var faultsdv = App.DB.FleetVanFault.GetAll_ByVanID(CurrentVan.VanID);
                            if (faultsdv.Table.Rows.Count > 0)
                            {
                                foreach (DataRowView rowView in faultsdv)
                                {
                                    var rowfault = rowView.Row;
                                    Entity.FleetVans.FleetVanFault fault;
                                    fault = App.DB.FleetVanFault.Get(Conversions.ToInteger(rowfault["VanFaultID"]));
                                    if (fault is object)
                                    {
                                        if (fault.FaultTypeID == (int)Entity.Sys.Enums.FleetVanFaultType.InvalidMileage)
                                        {
                                            fault.ResolvedDate = DateTime.Now;
                                            fault.SetNotes = fault.Notes + "-- Fault resolved via import";
                                            App.DB.FleetVanFault.Update(fault);
                                        }
                                    }
                                }
                            }

                            App.DB.FleetVanMaintenance.Update(CurrentVanMaintenance);
                            App.DB.FleetVanContract.Update(CurrentContract);
                        }
                        else
                        {
                            UpdateFailedVans(driver, reg, make, model, mileage.ToString());
                        }
                    }
                    else
                    {
                        UpdateFailedVans(driver, reg, make, model, mileage.ToString());
                    }
                }

                if (FailedVans.Count > 0)
                {
                    var dt = FRMFleetVanImporter.ConvertToDataTable(FailedVans);
                    var dv = new DataView(dt);
                    dgFailedImports.DataSource = dv;
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
                KillInstances(oExcel);
                string filePath = App.TheSystem.Configuration.DocumentsLocation + @"Fleet\VanImports\";
                System.IO.File.Move(File.FullName, filePath + File.Name);
                File = null;
                btnFindExcelFile.Enabled = true;
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                App.ShowMessage("Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor.Current = Cursors.Default;
            }
        }

        private void RunEstimateUpdates()
        {
            // First we need to calculate the average mileage
            // Get the weeks between now and the last service date
            if (!CurrentVanMaintenance.Exists)
            {
                return;
            }

            int weeks = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, CurrentVanMaintenance.LastService, DateTime.Now));
            if (weeks < 1)
            {
                weeks = 1;
            }

            if (CurrentVan.Mileage < 1)
            {
                return;
            }

            int mileageDiff = CurrentVan.Mileage - CurrentVanMaintenance.LastServiceMileage;
            var avgMileages = new List<int>();

            // calculate average mileage based on last service
            int currentContractLength = 0;
            double lastServiceAverageMileage = 0;

            // multiple the average mileage by 4
            lastServiceAverageMileage = Math.Round(mileageDiff / (double)weeks * 4.3, MidpointRounding.AwayFromZero);
            CurrentVan.SetAverageMileage = lastServiceAverageMileage;
            if (CurrentContract.Exists)
            {
                if (CurrentContract.ContractStart < DateTime.Now & CurrentContract.ProcurementMethod != (int)Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned & CurrentContract.ContractLength > 0)
                {
                    avgMileages.Add(Conversions.ToInteger(lastServiceAverageMileage));

                    // calculate the average mileage over the contract period
                    currentContractLength = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, DateTime.Now));
                    int mileageFromContractStart = CurrentVan.Mileage - CurrentContract.StartingMileage;
                    if (currentContractLength > 0)
                    {
                        double currentAverageMileageOverContract = Math.Round(mileageFromContractStart / (double)currentContractLength * 4.3, MidpointRounding.AwayFromZero);
                        avgMileages.Add(Conversions.ToInteger(currentAverageMileageOverContract));
                        CurrentVan.SetAverageMileage = Conversions.ToInteger(avgMileages.Average());
                    }
                }
            }

            var vanType = App.DB.FleetVanType.Get(CurrentVan.VanTypeID);

            // next service based on date
            var nsDate = CurrentVanMaintenance.LastService.AddMonths(vanType.DateServiceInterval);

            // lets see how many months it will take to get to next service mileage
            int avg = (int)(vanType.MileageServiceInterval / (double)CurrentVan.AverageMileage);
            // next service based on mileage
            var nsMileage = CurrentVanMaintenance.LastService.AddMonths(avg);
            if (nsDate < nsMileage)
            {
                CurrentVanMaintenance.NextService = nsDate;
            }
            else
            {
                CurrentVanMaintenance.NextService = nsMileage;
            }

            if (CurrentContract.ContractMileage == 0)
            {
                CurrentContract.SetExcessMileageCost = 0;
                CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost;
                return;
            }

            // calculate the excess mileage cost
            if (CurrentVan.Mileage > CurrentContract.ContractMileage)
            {
                int contractMileageDiff = CurrentVan.Mileage - CurrentContract.ContractMileage;
                double excessMileageCost = CurrentContract.ExcessMileageRate * contractMileageDiff;
                CurrentContract.SetExcessMileageCost = excessMileageCost;
            }
            else
            {
                CurrentContract.SetExcessMileageCost = 0;
            }

            if (CurrentContract.ContractEnd == default)
            {
                return;
            }

            // get contract length
            CurrentContract.SetContractLength = DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStart, CurrentContract.ContractEnd) + 1;
            int remainingLength = Conversions.ToInteger(Math.Round(CurrentContract.ContractLength - currentContractLength / 4.3));
            double estMileageOverRemainingLength = lastServiceAverageMileage * remainingLength;
            int estContractMileage = (int)(estMileageOverRemainingLength + CurrentVan.Mileage);
            if (estContractMileage > CurrentContract.ContractMileage)
            {
                int contractMileageDiff = estContractMileage - CurrentContract.ContractMileage;
                double excessMileageCost = CurrentContract.ExcessMileageRate * contractMileageDiff;
                CurrentContract.SetForecastExcessMileageCost = Math.Round(excessMileageCost, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost;
            }
        }

        private void UpdateFailedVans(string driver, string reg, string make, string model, string mileage)
        {
            var failedVan = new FailedFleetVanImports();
            failedVan.Driver = driver;
            failedVan.Registration = reg;
            failedVan.Make = make;
            failedVan.Model = model;
            failedVan.Mileage = Conversions.ToInteger(mileage);
            FailedVans.Add(failedVan);
        }

        /// <summary>
        /// Converts a list of a class to a datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            // declare new datatable
            var dt = new DataTable();

            // if the list is empty then we return a blank table
            if (!list.Any())
            {
                return dt;
            }
            // get all the class properties
            var fields = list.First().GetType().GetProperties();
            // use the class properties as column name
            foreach (PropertyInfo field in fields)
                dt.Columns.Add(field.Name, field.PropertyType);
            // populate datatable with values
            foreach (T item in list)
            {
                var row = dt.NewRow();
                foreach (PropertyInfo field in fields)
                {
                    row[field.Name] = item.GetType().GetProperty(field.Name);
                }

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}