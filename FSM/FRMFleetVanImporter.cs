// Decompiled with JetBrains decompiler
// Type: FSM.FRMFleetVanImporter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.FleetVans;
using FSM.Entity.Sys;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMFleetVanImporter : FRMBaseForm
  {
    private IContainer components;
    private FileInfo _file;
    private FleetVan _currentVan;
    private FleetVanMaintenance _currentVanMaintenance;
    private FleetVanContract _currentContract;
    private List<FRMFleetVanImporter.FailedFleetVanImports> _failedVans;

    public FRMFleetVanImporter()
    {
      this.Load += new EventHandler(this.FRMImport_Load);
      this._failedVans = new List<FRMFleetVanImporter.FailedFleetVanImports>();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindExcelFile
    {
      get
      {
        return this._btnFindExcelFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindExcelFile_Click);
        Button btnFindExcelFile1 = this._btnFindExcelFile;
        if (btnFindExcelFile1 != null)
          btnFindExcelFile1.Click -= eventHandler;
        this._btnFindExcelFile = value;
        Button btnFindExcelFile2 = this._btnFindExcelFile;
        if (btnFindExcelFile2 == null)
          return;
        btnFindExcelFile2.Click += eventHandler;
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

    internal virtual GroupBox grpFailedImports { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgFailedImports { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.Label2 = new Label();
      this.btnImport = new Button();
      this.btnFindExcelFile = new Button();
      this.txtExcelFile = new TextBox();
      this.grpFailedImports = new GroupBox();
      this.dgFailedImports = new DataGrid();
      this.grpExcelFile.SuspendLayout();
      this.grpFailedImports.SuspendLayout();
      this.dgFailedImports.BeginInit();
      this.SuspendLayout();
      this.grpExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpExcelFile.Controls.Add((Control) this.Label2);
      this.grpExcelFile.Controls.Add((Control) this.btnImport);
      this.grpExcelFile.Controls.Add((Control) this.btnFindExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.txtExcelFile);
      this.grpExcelFile.FlatStyle = FlatStyle.System;
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(655, 64);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Select file to import";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 22);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(31, 13);
      this.Label2.TabIndex = 13;
      this.Label2.Text = "File:";
      this.btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnImport.Enabled = false;
      this.btnImport.FlatStyle = FlatStyle.System;
      this.btnImport.Location = new System.Drawing.Point(574, 17);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new Size(64, 23);
      this.btnImport.TabIndex = 7;
      this.btnImport.Text = "Import";
      this.btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindExcelFile.FlatStyle = FlatStyle.System;
      this.btnFindExcelFile.Location = new System.Drawing.Point(536, 17);
      this.btnFindExcelFile.Name = "btnFindExcelFile";
      this.btnFindExcelFile.Size = new Size(32, 23);
      this.btnFindExcelFile.TabIndex = 5;
      this.btnFindExcelFile.Text = "...";
      this.txtExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtExcelFile.Location = new System.Drawing.Point(50, 19);
      this.txtExcelFile.Name = "txtExcelFile";
      this.txtExcelFile.ReadOnly = true;
      this.txtExcelFile.Size = new Size(480, 21);
      this.txtExcelFile.TabIndex = 4;
      this.grpFailedImports.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFailedImports.Controls.Add((Control) this.dgFailedImports);
      this.grpFailedImports.FlatStyle = FlatStyle.System;
      this.grpFailedImports.Location = new System.Drawing.Point(8, 110);
      this.grpFailedImports.Name = "grpFailedImports";
      this.grpFailedImports.Size = new Size(655, 477);
      this.grpFailedImports.TabIndex = 14;
      this.grpFailedImports.TabStop = false;
      this.grpFailedImports.Text = "Failed Imports";
      this.dgFailedImports.DataMember = "";
      this.dgFailedImports.Dock = DockStyle.Fill;
      this.dgFailedImports.HeaderForeColor = SystemColors.ControlText;
      this.dgFailedImports.Location = new System.Drawing.Point(3, 17);
      this.dgFailedImports.Name = "dgFailedImports";
      this.dgFailedImports.Size = new Size(649, 457);
      this.dgFailedImports.TabIndex = 45;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(671, 599);
      this.Controls.Add((Control) this.grpFailedImports);
      this.Controls.Add((Control) this.grpExcelFile);
      this.Name = nameof (FRMFleetVanImporter);
      this.Text = "Fleet Van Mileage Import";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.grpFailedImports, 0);
      this.grpExcelFile.ResumeLayout(false);
      this.grpExcelFile.PerformLayout();
      this.grpFailedImports.ResumeLayout(false);
      this.dgFailedImports.EndInit();
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

    public FleetVan CurrentVan
    {
      get
      {
        return this._currentVan;
      }
      set
      {
        this._currentVan = value;
        if (this.CurrentVan != null)
          return;
        this.CurrentVan = new FleetVan();
        this.CurrentVan.Exists = false;
      }
    }

    public FleetVanMaintenance CurrentVanMaintenance
    {
      get
      {
        return this._currentVanMaintenance;
      }
      set
      {
        this._currentVanMaintenance = value;
        if (this.CurrentVanMaintenance != null)
          return;
        this.CurrentVanMaintenance = new FleetVanMaintenance();
        this.CurrentVanMaintenance.Exists = false;
      }
    }

    public FleetVanContract CurrentContract
    {
      get
      {
        return this._currentContract;
      }
      set
      {
        this._currentContract = value;
        if (this.CurrentContract != null)
          return;
        this.CurrentContract = new FleetVanContract();
        this.CurrentContract.Exists = false;
      }
    }

    private List<FRMFleetVanImporter.FailedFleetVanImports> FailedVans
    {
      get
      {
        return this._failedVans;
      }
      set
      {
        this._failedVans = value;
      }
    }

    private void FRMImport_Load(object sender, EventArgs e)
    {
    }

    private void btnFindExcelFile_Click(object sender, EventArgs e)
    {
      this.LoadData();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.Import();
    }

    private void LoadData()
    {
      OpenFileDialog openFileDialog;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.btnFindExcelFile.Enabled = false;
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xls", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xlsx", false) == 0)
        {
          this.File = fileInfo;
          this.txtExcelFile.Text = this.File.FullName;
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
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        int num = (int) App.ShowMessage("File data could not be loaded : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        openFileDialog.Dispose();
        this.btnFindExcelFile.Enabled = true;
        Cursor.Current = Cursors.Default;
      }
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

    private void Import()
    {
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
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
        int num1 = checked (dataSet.Tables[0].Rows.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          DataRow row1 = dataSet.Tables[0].Rows[index];
          string empty1 = string.Empty;
          string str = string.Empty;
          string empty2 = string.Empty;
          string empty3 = string.Empty;
          int num2 = 0;
          bool flag = true;
          if (row1["Registration"] == DBNull.Value)
            flag = false;
          else
            str = Conversions.ToString(row1["Registration"]).Replace(" ", string.Empty);
          if (row1["End Odometer"] == DBNull.Value)
            flag = false;
          else
            num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row1["End Odometer"]));
          string driver = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row1["Driver Name"]));
          string make = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row1["Make"]));
          string model = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row1["Model"]));
          if (flag)
          {
            this.CurrentVan = App.DB.FleetVan.Get_ByRegistration(str);
            if (this.CurrentVan.Exists)
            {
              this.CurrentVanMaintenance = App.DB.FleetVanMaintenance.Get_ByVanID(this.CurrentVan.VanID);
              this.CurrentContract = App.DB.FleetVanContract.Get_ByVanID(this.CurrentVan.VanID);
              this.CurrentVan.SetMileage = (object) num2;
              this.RunEstimateUpdates();
              App.DB.FleetVan.Update(this.CurrentVan);
              DataView allByVanId = App.DB.FleetVanFault.GetAll_ByVanID(this.CurrentVan.VanID);
              IEnumerator enumerator;
              if (allByVanId.Table.Rows.Count > 0)
              {
                try
                {
                  enumerator = allByVanId.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow row2 = ((DataRowView) enumerator.Current).Row;
                    FleetVanFault oVan = App.DB.FleetVanFault.Get(Conversions.ToInteger(row2["VanFaultID"]));
                    if (oVan != null && oVan.FaultTypeID == 12)
                    {
                      oVan.ResolvedDate = DateTime.Now;
                      oVan.SetNotes = (object) (oVan.Notes + "-- Fault resolved via import");
                      App.DB.FleetVanFault.Update(oVan);
                    }
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
              }
              App.DB.FleetVanMaintenance.Update(this.CurrentVanMaintenance);
              App.DB.FleetVanContract.Update(this.CurrentContract);
            }
            else
              this.UpdateFailedVans(driver, str, make, model, Conversions.ToString(num2));
          }
          else
            this.UpdateFailedVans(driver, str, make, model, Conversions.ToString(num2));
          checked { ++index; }
        }
        if (this.FailedVans.Count <= 0)
          return;
        this.dgFailedImports.DataSource = (object) new DataView(FRMFleetVanImporter.ConvertToDataTable<FRMFleetVanImporter.FailedFleetVanImports>((IList<FRMFleetVanImporter.FailedFleetVanImports>) this.FailedVans));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        int num = (int) App.ShowMessage("File data could not be loaded : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.KillInstances(instance);
        System.IO.File.Move(this.File.FullName, App.TheSystem.Configuration.DocumentsLocation + "Fleet\\VanImports\\" + this.File.Name);
        this.File = (FileInfo) null;
        this.btnFindExcelFile.Enabled = true;
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        int num = (int) App.ShowMessage("Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        Cursor.Current = Cursors.Default;
      }
    }

    private void RunEstimateUpdates()
    {
      if (!this.CurrentVanMaintenance.Exists)
        return;
      int num1 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, this.CurrentVanMaintenance.LastService, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
      if (num1 < 1)
        num1 = 1;
      if (this.CurrentVan.Mileage < 1)
        return;
      int num2 = checked (this.CurrentVan.Mileage - this.CurrentVanMaintenance.LastServiceMileage);
      List<int> source = new List<int>();
      int num3 = 0;
      double a1 = Math.Round((double) num2 / (double) num1 * 4.3, MidpointRounding.AwayFromZero);
      this.CurrentVan.SetAverageMileage = (object) a1;
      if (this.CurrentContract.Exists && DateTime.Compare(this.CurrentContract.ContractStart, DateTime.Now) < 0 & this.CurrentContract.ProcurementMethod != 4 & this.CurrentContract.ContractLength > 0)
      {
        source.Add(checked ((int) Math.Round(a1)));
        num3 = checked ((int) DateAndTime.DateDiff(DateInterval.WeekOfYear, this.CurrentContract.ContractStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
        int num4 = checked (this.CurrentVan.Mileage - this.CurrentContract.StartingMileage);
        if (num3 > 0)
        {
          double a2 = Math.Round((double) num4 / (double) num3 * 4.3, MidpointRounding.AwayFromZero);
          source.Add(checked ((int) Math.Round(a2)));
          this.CurrentVan.SetAverageMileage = (object) checked ((int) Math.Round(source.Average()));
        }
      }
      FleetVanType fleetVanType = App.DB.FleetVanType.Get(this.CurrentVan.VanTypeID);
      DateTime t1 = this.CurrentVanMaintenance.LastService.AddMonths(fleetVanType.DateServiceInterval);
      DateTime t2 = this.CurrentVanMaintenance.LastService.AddMonths(checked ((int) Math.Round(unchecked ((double) fleetVanType.MileageServiceInterval / (double) this.CurrentVan.AverageMileage))));
      this.CurrentVanMaintenance.NextService = DateTime.Compare(t1, t2) >= 0 ? t2 : t1;
      if (this.CurrentContract.ContractMileage == 0)
      {
        this.CurrentContract.SetExcessMileageCost = (object) 0;
        this.CurrentContract.SetForecastExcessMileageCost = (object) this.CurrentContract.ExcessMileageCost;
      }
      else
      {
        this.CurrentContract.SetExcessMileageCost = this.CurrentVan.Mileage <= this.CurrentContract.ContractMileage ? (object) 0 : (object) (this.CurrentContract.ExcessMileageRate * (double) checked (this.CurrentVan.Mileage - this.CurrentContract.ContractMileage));
        if (DateTime.Compare(this.CurrentContract.ContractEnd, DateTime.MinValue) == 0)
          return;
        this.CurrentContract.SetContractLength = (object) checked (DateAndTime.DateDiff(DateInterval.Month, this.CurrentContract.ContractStart, this.CurrentContract.ContractEnd, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) + 1L);
        int num4 = checked ((int) Math.Round(unchecked ((double) this.CurrentContract.ContractLength - (double) num3 / 4.3)));
        int num5 = checked ((int) Math.Round(unchecked (a1 * (double) num4 + (double) this.CurrentVan.Mileage)));
        if (num5 > this.CurrentContract.ContractMileage)
          this.CurrentContract.SetForecastExcessMileageCost = (object) Math.Round(this.CurrentContract.ExcessMileageRate * (double) checked (num5 - this.CurrentContract.ContractMileage), 2, MidpointRounding.AwayFromZero);
        else
          this.CurrentContract.SetForecastExcessMileageCost = (object) this.CurrentContract.ExcessMileageCost;
      }
    }

    private void UpdateFailedVans(
      string driver,
      string reg,
      string make,
      string model,
      string mileage)
    {
      FRMFleetVanImporter.FailedFleetVanImports failedFleetVanImports1 = new FRMFleetVanImporter.FailedFleetVanImports();
      FRMFleetVanImporter.FailedFleetVanImports failedFleetVanImports2 = failedFleetVanImports1;
      failedFleetVanImports2.Driver = driver;
      failedFleetVanImports2.Registration = reg;
      failedFleetVanImports2.Make = make;
      failedFleetVanImports2.Model = model;
      failedFleetVanImports2.Mileage = Conversions.ToInteger(mileage);
      this.FailedVans.Add(failedFleetVanImports1);
    }

    public static DataTable ConvertToDataTable<T>(IList<T> list)
    {
      DataTable dataTable = new DataTable();
      if (!list.Any<T>())
        return dataTable;
      PropertyInfo[] properties = list.First<T>().GetType().GetProperties();
      PropertyInfo[] propertyInfoArray1 = properties;
      int index1 = 0;
      while (index1 < propertyInfoArray1.Length)
      {
        PropertyInfo propertyInfo = propertyInfoArray1[index1];
        dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
        checked { ++index1; }
      }
      try
      {
        foreach (T obj1 in (IEnumerable<T>) list)
        {
          T obj2 = obj1;
          DataRow row = dataTable.NewRow();
          PropertyInfo[] propertyInfoArray2 = properties;
          int index2 = 0;
          while (index2 < propertyInfoArray2.Length)
          {
            PropertyInfo propertyInfo = propertyInfoArray2[index2];
            object property = (object) obj2.GetType().GetProperty(propertyInfo.Name);
            DataRow dataRow = row;
            string name = propertyInfo.Name;
            object[] objArray;
            bool[] flagArray;
            object obj3 = NewLateBinding.LateGet(property, (System.Type) null, "GetValue", objArray = new object[2]
            {
              (object) obj2,
              null
            }, (string[]) null, (System.Type[]) null, flagArray = new bool[2]
            {
              true,
              false
            });
            if (flagArray[0])
              obj2 = (T) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof (T));
            object objectValue = RuntimeHelpers.GetObjectValue(obj3);
            dataRow[name] = objectValue;
            checked { ++index2; }
          }
          dataTable.Rows.Add(row);
        }
      }
      finally
      {
        IEnumerator<T> enumerator;
        enumerator?.Dispose();
      }
      return dataTable;
    }

    public class FailedFleetVanImports
    {
      public string Driver { get; set; }

      public string Registration { get; set; }

      public string Make { get; set; }

      public string Model { get; set; }

      public int Mileage { get; set; }
    }
  }
}
