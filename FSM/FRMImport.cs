// Decompiled with JetBrains decompiler
// Type: FSM.FRMImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMImport : FRMBaseForm
  {
    private IContainer components;
    private FileInfo _file;
    private DataTable _failedImports;
    private FSM.Entity.Customers.Customer _customer;

    public FRMImport()
    {
      this.Load += new EventHandler(this.FRMImport_Load);
      this._failedImports = new DataTable();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpImporter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFileLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindFile
    {
      get
      {
        return this._btnFindFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindFile_Click);
        Button btnFindFile1 = this._btnFindFile;
        if (btnFindFile1 != null)
          btnFindFile1.Click -= eventHandler;
        this._btnFindFile = value;
        Button btnFindFile2 = this._btnFindFile;
        if (btnFindFile2 == null)
          return;
        btnFindFile2.Click += eventHandler;
      }
    }

    internal virtual LinkLabel btnTemplateFile
    {
      get
      {
        return this._btnTemplateFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.btnTemplateFile_LinkClicked);
        LinkLabel btnTemplateFile1 = this._btnTemplateFile;
        if (btnTemplateFile1 != null)
          btnTemplateFile1.LinkClicked -= clickedEventHandler;
        this._btnTemplateFile = value;
        LinkLabel btnTemplateFile2 = this._btnTemplateFile;
        if (btnTemplateFile2 == null)
          return;
        btnTemplateFile2.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual Button btnImport
    {
      get
      {
        return this._btnImport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnImport_Click);
        Button btnImport1 = this._btnImport;
        if (btnImport1 != null)
          btnImport1.Click -= eventHandler;
        this._btnImport = value;
        Button btnImport2 = this._btnImport;
        if (btnImport2 == null)
          return;
        btnImport2.Click += eventHandler;
      }
    }

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnExport1 = this._btnExport;
        if (btnExport1 != null)
          btnExport1.Click -= eventHandler;
        this._btnExport = value;
        Button btnExport2 = this._btnExport;
        if (btnExport2 == null)
          return;
        btnExport2.Click += eventHandler;
      }
    }

    internal virtual ProgressBar pbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSupplier_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual Label lblMessages { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpErrors { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgErrors { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpImporter = new GroupBox();
      this.lblFile = new Label();
      this.txtCustomer = new TextBox();
      this.btnFindCustomer = new Button();
      this.lblCustomer = new Label();
      this.btnImport = new Button();
      this.btnFindFile = new Button();
      this.txtFileLocation = new TextBox();
      this.btnTemplateFile = new LinkLabel();
      this.btnExport = new Button();
      this.pbStatus = new ProgressBar();
      this.lblProgress = new Label();
      this.lblMessages = new Label();
      this.grpErrors = new GroupBox();
      this.dgErrors = new DataGrid();
      this.grpImporter.SuspendLayout();
      this.grpErrors.SuspendLayout();
      this.dgErrors.BeginInit();
      this.SuspendLayout();
      this.grpImporter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpImporter.Controls.Add((Control) this.lblFile);
      this.grpImporter.Controls.Add((Control) this.txtCustomer);
      this.grpImporter.Controls.Add((Control) this.btnFindCustomer);
      this.grpImporter.Controls.Add((Control) this.lblCustomer);
      this.grpImporter.Controls.Add((Control) this.btnImport);
      this.grpImporter.Controls.Add((Control) this.btnFindFile);
      this.grpImporter.Controls.Add((Control) this.txtFileLocation);
      this.grpImporter.Location = new System.Drawing.Point(8, 40);
      this.grpImporter.Name = "grpImporter";
      this.grpImporter.Size = new Size(896, 115);
      this.grpImporter.TabIndex = 3;
      this.grpImporter.TabStop = false;
      this.grpImporter.Text = "Import";
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(6, 52);
      this.lblFile.Name = "lblFile";
      this.lblFile.Size = new Size(31, 13);
      this.lblFile.TabIndex = 13;
      this.lblFile.Text = "File:";
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Location = new System.Drawing.Point(86, 20);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(766, 21);
      this.txtCustomer.TabIndex = 12;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.Location = new System.Drawing.Point(858, 20);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 11;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = true;
      this.lblCustomer.AutoSize = true;
      this.lblCustomer.Location = new System.Drawing.Point(6, 23);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(68, 13);
      this.lblCustomer.TabIndex = 9;
      this.lblCustomer.Text = "Customer:";
      this.btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnImport.Enabled = false;
      this.btnImport.Location = new System.Drawing.Point(826, 84);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new Size(64, 23);
      this.btnImport.TabIndex = 7;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnFindFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindFile.Location = new System.Drawing.Point(858, 49);
      this.btnFindFile.Name = "btnFindFile";
      this.btnFindFile.Size = new Size(32, 23);
      this.btnFindFile.TabIndex = 5;
      this.btnFindFile.Text = "...";
      this.btnFindFile.UseVisualStyleBackColor = true;
      this.txtFileLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFileLocation.Location = new System.Drawing.Point(86, 49);
      this.txtFileLocation.Name = "txtFileLocation";
      this.txtFileLocation.ReadOnly = true;
      this.txtFileLocation.Size = new Size(766, 21);
      this.txtFileLocation.TabIndex = 4;
      this.btnTemplateFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnTemplateFile.Location = new System.Drawing.Point(816, 8);
      this.btnTemplateFile.Name = "btnTemplateFile";
      this.btnTemplateFile.Size = new Size(88, 23);
      this.btnTemplateFile.TabIndex = 1;
      this.btnTemplateFile.TabStop = true;
      this.btnTemplateFile.Text = "Template File";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExport.Location = new System.Drawing.Point(848, 624);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 9;
      this.btnExport.Text = "Export";
      this.btnExport.UseVisualStyleBackColor = true;
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(8, 624);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(784, 23);
      this.pbStatus.Step = 1;
      this.pbStatus.TabIndex = 10;
      this.lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblProgress.Location = new System.Drawing.Point(800, 627);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new Size(40, 16);
      this.lblProgress.TabIndex = 11;
      this.lblProgress.Text = "0%";
      this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
      this.lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessages.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessages.ForeColor = Color.Red;
      this.lblMessages.Location = new System.Drawing.Point(5, 595);
      this.lblMessages.Name = "lblMessages";
      this.lblMessages.Size = new Size(900, 19);
      this.lblMessages.TabIndex = 12;
      this.lblMessages.TextAlign = ContentAlignment.MiddleLeft;
      this.lblMessages.Visible = false;
      this.grpErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpErrors.Controls.Add((Control) this.dgErrors);
      this.grpErrors.Location = new System.Drawing.Point(8, 161);
      this.grpErrors.Name = "grpErrors";
      this.grpErrors.Size = new Size(896, 453);
      this.grpErrors.TabIndex = 14;
      this.grpErrors.TabStop = false;
      this.grpErrors.Text = "Errors";
      this.dgErrors.DataMember = "";
      this.dgErrors.Dock = DockStyle.Fill;
      this.dgErrors.HeaderForeColor = SystemColors.ControlText;
      this.dgErrors.Location = new System.Drawing.Point(3, 17);
      this.dgErrors.Name = "dgErrors";
      this.dgErrors.Size = new Size(890, 433);
      this.dgErrors.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(912, 654);
      this.Controls.Add((Control) this.grpErrors);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.btnTemplateFile);
      this.Controls.Add((Control) this.grpImporter);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMImport);
      this.Text = "Site Importer";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpImporter, 0);
      this.Controls.SetChildIndex((Control) this.btnTemplateFile, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.grpErrors, 0);
      this.grpImporter.ResumeLayout(false);
      this.grpImporter.PerformLayout();
      this.grpErrors.ResumeLayout(false);
      this.dgErrors.EndInit();
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public FileInfo File
    {
      get
      {
        return this._file;
      }
      set
      {
        this._file = value;
      }
    }

    private DataTable FailedImports
    {
      get
      {
        return this._failedImports;
      }
      set
      {
        this._failedImports = value;
      }
    }

    private FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._customer;
      }
      set
      {
        this._customer = value;
        if (this.Customer != null)
          this.txtCustomer.Text = this.Customer.Name;
        else
          this.txtCustomer.Text = string.Empty;
      }
    }

    private void FRMImport_Load(object sender, EventArgs e)
    {
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnTemplateFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog;
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated method
        instance.Workbooks.Add((object) (System.Windows.Forms.Application.StartupPath + "\\Templates\\SiteImporter.xlsx"));
        if (System.IO.File.Exists(folderBrowserDialog.SelectedPath + "\\SiteImporter.xlsx"))
          System.IO.File.Delete(folderBrowserDialog.SelectedPath + "\\SiteImporter.xlsx");
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        instance.Workbooks.get_Item((object) 1).SaveAs((object) (folderBrowserDialog.SelectedPath + "\\SiteImporter.xlsx"), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
        int num = (int) App.ShowMessage("File downloaded to " + folderBrowserDialog.SelectedPath + "\\SiteImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Template could not be saved : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        folderBrowserDialog.Dispose();
        this.KillInstances(instance);
        Cursor.Current = Cursors.Default;
      }
    }

    private void btnFindFile_Click(object sender, EventArgs e)
    {
      this.LoadData();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.Import();
    }

    private void btnSupplier_Click(object sender, EventArgs e)
    {
      this.FindCustomer();
    }

    private void LoadData()
    {
      OpenFileDialog openFileDialog;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.btnFindFile.Enabled = false;
        this.btnImport.Enabled = false;
        this.txtFileLocation.Text = "";
        openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xls", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xlsx", false) == 0)
        {
          this.File = fileInfo;
          this.txtFileLocation.Text = this.File.FullName;
          this.btnImport.Enabled = true;
        }
        else
        {
          int num = (int) App.ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        this.txtFileLocation.Text = "";
        this.btnImport.Enabled = false;
        int num = (int) App.ShowMessage("File data could not be loaded : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        openFileDialog.Dispose();
        this.btnFindFile.Enabled = true;
        Cursor.Current = Cursors.Default;
      }
    }

    private void Import()
    {
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance;
      if (this.Customer == null)
      {
        int num1 = (int) App.ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          this.btnFindFile.Enabled = false;
          this.btnImport.Enabled = false;
          this.pbStatus.Value = 0;
          instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
          instance.DisplayAlerts = false;
          // ISSUE: reference to a compiler-generated method
          instance.Workbooks.Add((object) this.File.FullName);
          // ISSUE: variable of a compiler-generated type
          Worksheet worksheet = (Worksheet) instance.Worksheets[(object) 1];
          string cmdText = " SELECT * FROM [" + worksheet.Name + "$]";
          string connectionString = "";
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.File.Extension.Trim().ToLower(), ".xls".ToLower(), false) == 0)
            connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + this.File.FullName + " ; Extended Properties=Excel 8.0; ";
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.File.Extension.Trim().ToLower(), ".xlsx".ToLower(), false) == 0)
            connectionString = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + this.File.FullName + " ; Extended Properties=Excel 12.0; ";
          OleDbConnection connection = new OleDbConnection(connectionString);
          OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
          DataSet dataSet = new DataSet();
          oleDbDataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
          dataSet.Clear();
          oleDbDataAdapter.Fill(dataSet);
          dataSet.Tables[0].Columns.Add("Failure Reason");
          this.FailedImports = dataSet.Tables[0].Clone();
          this.pbStatus.Maximum = dataSet.Tables[0].Rows.Count;
          int num2 = checked (dataSet.Tables[0].Rows.Count - 1);
          int index = 0;
          while (index <= num2)
          {
            DataRow row = dataSet.Tables[0].Rows[index];
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;
            DateTime minValue1 = DateTime.MinValue;
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string empty10 = string.Empty;
            string empty11 = string.Empty;
            DateTime minValue2 = DateTime.MinValue;
            string str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["UPRN"]));
            if (row["Address1"] == DBNull.Value)
            {
              row["Failure Reason"] = (object) "No address 1";
              this.FailedImports.ImportRow(row);
            }
            else
            {
              string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Address1"]));
              string str3 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Address2"]));
              string str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Address3"]));
              if (row["Postcode"] == DBNull.Value)
              {
                row["Failure Reason"] = (object) "No postcode";
                this.FailedImports.ImportRow(row);
              }
              else
              {
                string postcode = Helper.ConvertToPostcode(RuntimeHelpers.GetObjectValue(row["Postcode"]));
                if (!postcode.Contains("-") | postcode.Length > 9)
                {
                  row["Failure Reason"] = (object) "Invalid postocde format";
                  this.FailedImports.ImportRow(row);
                }
                else
                {
                  DateTime dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["LastServiceDate"]));
                  string str5 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Fuel"]));
                  string str6 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["FirstName"]));
                  string str7 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["LastName"]));
                  string str8 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["TelNo"]));
                  string str9 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["MobNo"]));
                  string str10 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Email"]));
                  DateTime t1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["BuildDate"]));
                  int num3 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["WarrantyPeriodInMonths"]));
                  string str11 = string.Empty;
                  if (!string.IsNullOrWhiteSpace(str6))
                    str11 = str6 + " ";
                  if (!string.IsNullOrWhiteSpace(str7))
                    str11 += str7;
                  if (App.DB.Sites.Get((object) str1, SiteSQL.GetBy.Uprn, (object) this.Customer.CustomerID) == null)
                  {
                    FSM.Entity.Sites.Site oSite = new FSM.Entity.Sites.Site();
                    FSM.Entity.Sites.Site site1 = oSite;
                    site1.IgnoreExceptionsOnSetMethods = true;
                    site1.SetPolicyNumber = (object) str1;
                    site1.SetAddress1 = (object) str2;
                    site1.SetAddress2 = (object) str3;
                    site1.SetAddress3 = (object) str4;
                    site1.SetPostcode = (object) postcode;
                    site1.LastServiceDate = dateTime;
                    site1.SetSiteFuel = (object) str5;
                    site1.SetCustomerID = (object) this.Customer.CustomerID;
                    site1.SetRegionID = (object) this.Customer.RegionID;
                    site1.SetCommercialDistrict = (object) 0;
                    site1.SetEngineerID = (object) 0;
                    site1.SetHeadOffice = (object) false;
                    site1.SetNoMarketing = (object) false;
                    site1.SetNoService = (object) false;
                    site1.SetOnStop = (object) false;
                    site1.SetPoNumReqd = (object) false;
                    site1.SetSolidFuel = (object) false;
                    site1.SetFirstName = (object) str6;
                    site1.SetSurname = (object) str7;
                    site1.SetTelephoneNum = (object) str8;
                    site1.SetFaxNum = (object) str9;
                    site1.SetEmailAddress = (object) str10;
                    if (!string.IsNullOrWhiteSpace(str11))
                      site1.SetName = (object) str11;
                    if ((uint) DateTime.Compare(t1, DateTime.MinValue) > 0U)
                      site1.BuildDate = t1;
                    site1.SetWarrantyPeriodInMonths = (object) num3;
                    FSM.Entity.Sites.Site site2 = App.DB.Sites.Insert(oSite);
                    if (DateTime.Compare(dateTime, DateTime.MinValue) != 0)
                    {
                      App.DB.Sites.Site_UpdateLastServiceDate(site2.SiteID, dateTime, dateTime, true);
                      SiteFuel siteFuel1 = new SiteFuel();
                      SiteFuel siteFuel2 = siteFuel1;
                      siteFuel2.SetSiteID = (object) site2.SiteID;
                      siteFuel2.LastServiceDate = dateTime;
                      siteFuel2.ActualServiceDate = dateTime;
                      if (!string.IsNullOrWhiteSpace(str5))
                      {
                        bool flag = true;
                        if (flag == str5.ToLower().Contains("gas"))
                          siteFuel1.SetFuelID = (object) 377;
                        else if (flag == str5.ToLower().Contains("solid"))
                          siteFuel1.SetFuelID = (object) 69497;
                        else if (flag == str5.ToLower().Contains("oil"))
                          siteFuel1.SetFuelID = (object) 6027;
                        else if (flag == str5.ToLower().Contains("eletric"))
                          siteFuel1.SetFuelID = (object) 486;
                      }
                      siteFuel1.SetSiteFuelChargeID = (object) 0;
                      App.DB.Sites.SiteFuel_Update(siteFuel1);
                    }
                  }
                  else
                    goto label_35;
                }
              }
            }
            this.MoveProgressOn(false);
label_35:
            checked { ++index; }
          }
          this.MoveProgressOn(true);
          int num4 = (int) App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.lblMessages.Visible = false;
          if (this.FailedImports.Rows.Count > 0)
            this.dgErrors.DataSource = (object) this.FailedImports;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("File data could not be imported : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.KillInstances(instance);
          this.File = (FileInfo) null;
          this.txtFileLocation.Text = "";
          if (this.FailedImports.Rows.Count > 0)
            this.btnExport.Visible = true;
          this.pbStatus.Value = this.pbStatus.Maximum;
          this.btnFindFile.Enabled = true;
          this.btnImport.Enabled = true;
          this.pbStatus.Value = 0;
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void Export()
    {
      if (this.FailedImports.Rows.Count <= 0)
        return;
      ExportHelper.Export(this.FailedImports, "Failed Sites", Enums.ExportType.XLS);
      this.FailedImports.Clear();
    }

    public void MoveProgressOn(bool toMaximum = false)
    {
      if (toMaximum)
      {
        this.pbStatus.Value = this.pbStatus.Maximum;
        this.lblProgress.Text = "100%";
      }
      else
      {
        ProgressBar pbStatus;
        int num = checked ((pbStatus = this.pbStatus).Value + 1);
        pbStatus.Value = num;
        this.lblProgress.Text = Conversions.ToString(Math.Floor((double) this.pbStatus.Value / (double) this.pbStatus.Maximum * 100.0)) + "%";
      }
      System.Windows.Forms.Application.DoEvents();
    }

    private void FindCustomer()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if (integer <= 0)
        return;
      this.Customer = App.DB.Customer.Customer_Get(integer);
    }

    private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
    {
      int num1;
      int num2;
      try
      {
label_2:
        ProjectData.ClearProjectError();
        num1 = -2;
label_3:
        int num3 = 2;
        // ISSUE: reference to a compiler-generated method
        app.Quit();
label_4:
        num3 = 3;
        Marshal.ReleaseComObject((object) app);
label_5:
        num3 = 4;
        app = (Microsoft.Office.Interop.Excel.Application) null;
label_6:
        num3 = 5;
        GC.Collect();
label_7:
        num3 = 6;
        Process[] processesByName = Process.GetProcessesByName("EXCEL");
label_8:
        num3 = 7;
        Process[] processArray = processesByName;
        int index = 0;
        goto label_18;
label_10:
        num3 = 8;
        Process process;
        if (!process.Responding)
          goto label_15;
label_11:
        num3 = 9;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(process.MainWindowTitle, "", false) != 0)
          goto label_14;
label_12:
        num3 = 10;
        process.Kill();
label_13:
label_14:
        goto label_17;
label_15:
        num3 = 13;
        process.Kill();
label_16:
label_17:
        num3 = 15;
        checked { ++index; }
label_18:
        if (index < processArray.Length)
        {
          process = processArray[index];
          goto label_10;
        }
label_19:
        ProjectData.ClearProjectError();
        num2 = 0;
        goto label_26;
label_21:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num4 = num2 + 1;
            num2 = 0;
            switch (num4)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_7;
              case 7:
                goto label_8;
              case 8:
                goto label_10;
              case 9:
                goto label_11;
              case 10:
                goto label_12;
              case 11:
                goto label_13;
              case 12:
              case 15:
                goto label_17;
              case 13:
                goto label_15;
              case 14:
                goto label_16;
              case 16:
                goto label_19;
              case 17:
                goto label_26;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & (uint) num1 > 0U & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_21;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_26:
      if (num2 == 0)
        return;
      ProjectData.ClearProjectError();
    }
  }
}
