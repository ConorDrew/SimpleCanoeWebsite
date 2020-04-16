// Decompiled with JetBrains decompiler
// Type: FSM.FRMSupplierInvoiceImporter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.Suppliers;
using FSM.Entity.Sys;
using FSM.Importer;
using LinqToExcel;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSupplierInvoiceImporter : FRMBaseForm
  {
    private IContainer components;
    private Supplier _supplier;
    private string _nominalCode;

    public FRMSupplierInvoiceImporter()
    {
      this.Load += new EventHandler(this.FRMSupplierInvoiceImporter_Load);
      this.DuplicateInvoices = new List<DuplicateInvoice>();
      this.InitializeComponent();
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetUpCombo(ref cboValidateType, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboValidateType = cboValidateType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tcData { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ProgressBar pbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMessages { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnExportResults
    {
      get
      {
        return this._btnExportResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportResults_Click);
        Button btnExportResults1 = this._btnExportResults;
        if (btnExportResults1 != null)
          btnExportResults1.Click -= eventHandler;
        this._btnExportResults = value;
        Button btnExportResults2 = this._btnExportResults;
        if (btnExportResults2 == null)
          return;
        btnExportResults2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboValidateType
    {
      get
      {
        return this._cboValidateType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboValidateType_SelectedIndexChanged);
        ComboBox cboValidateType1 = this._cboValidateType;
        if (cboValidateType1 != null)
          cboValidateType1.SelectedIndexChanged -= eventHandler;
        this._cboValidateType = value;
        ComboBox cboValidateType2 = this._cboValidateType;
        if (cboValidateType2 == null)
          return;
        cboValidateType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Button btnProcessIndiv
    {
      get
      {
        return this._btnProcessIndiv;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnProcessIndiv_Click);
        Button btnProcessIndiv1 = this._btnProcessIndiv;
        if (btnProcessIndiv1 != null)
          btnProcessIndiv1.Click -= eventHandler;
        this._btnProcessIndiv = value;
        Button btnProcessIndiv2 = this._btnProcessIndiv;
        if (btnProcessIndiv2 == null)
          return;
        btnProcessIndiv2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpCatImport { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbl_Stats { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSupplier
    {
      get
      {
        return this._btnFindSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSupplier_Click);
        Button btnFindSupplier1 = this._btnFindSupplier;
        if (btnFindSupplier1 != null)
          btnFindSupplier1.Click -= eventHandler;
        this._btnFindSupplier = value;
        Button btnFindSupplier2 = this._btnFindSupplier;
        if (btnFindSupplier2 == null)
          return;
        btnFindSupplier2.Click += eventHandler;
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

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual LinkLabel lblDownloadTemplate
    {
      get
      {
        return this._lblDownloadTemplate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.lblDownloadTemplate_LinkClicked);
        LinkLabel downloadTemplate1 = this._lblDownloadTemplate;
        if (downloadTemplate1 != null)
          downloadTemplate1.LinkClicked -= clickedEventHandler;
        this._lblDownloadTemplate = value;
        LinkLabel downloadTemplate2 = this._lblDownloadTemplate;
        if (downloadTemplate2 == null)
          return;
        downloadTemplate2.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual TextBox txtNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnValidateResults
    {
      get
      {
        return this._btnValidateResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnValidateResults_Click);
        Button btnValidateResults1 = this._btnValidateResults;
        if (btnValidateResults1 != null)
          btnValidateResults1.Click -= eventHandler;
        this._btnValidateResults = value;
        Button btnValidateResults2 = this._btnValidateResults;
        if (btnValidateResults2 == null)
          return;
        btnValidateResults2.Click += eventHandler;
      }
    }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.txtNominal = new TextBox();
      this.lblNominal = new Label();
      this.btnFindExcelFile = new Button();
      this.txtSupplier = new TextBox();
      this.lblSupplier = new Label();
      this.btnImport = new Button();
      this.btnFindSupplier = new Button();
      this.txtExcelFile = new TextBox();
      this.lblFile = new Label();
      this.btnExportResults = new Button();
      this.tcData = new TabControl();
      this.pbStatus = new ProgressBar();
      this.lblProgress = new Label();
      this.lblMessages = new Label();
      this.cboValidateType = new ComboBox();
      this.btnProcessIndiv = new Button();
      this.grpCatImport = new GroupBox();
      this.btnValidateResults = new Button();
      this.lbl_Stats = new Label();
      this.lblDownloadTemplate = new LinkLabel();
      this.grpExcelFile.SuspendLayout();
      this.grpCatImport.SuspendLayout();
      this.SuspendLayout();
      this.grpExcelFile.Controls.Add((Control) this.txtNominal);
      this.grpExcelFile.Controls.Add((Control) this.lblNominal);
      this.grpExcelFile.Controls.Add((Control) this.btnFindExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.txtSupplier);
      this.grpExcelFile.Controls.Add((Control) this.lblSupplier);
      this.grpExcelFile.Controls.Add((Control) this.btnImport);
      this.grpExcelFile.Controls.Add((Control) this.btnFindSupplier);
      this.grpExcelFile.Controls.Add((Control) this.txtExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.lblFile);
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(515, 123);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Initial Import";
      this.txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNominal.Location = new System.Drawing.Point(71, 51);
      this.txtNominal.Name = "txtNominal";
      this.txtNominal.Size = new Size(336, 21);
      this.txtNominal.TabIndex = 22;
      this.lblNominal.AutoSize = true;
      this.lblNominal.Location = new System.Drawing.Point(6, 54);
      this.lblNominal.Name = "lblNominal";
      this.lblNominal.Size = new Size(58, 13);
      this.lblNominal.TabIndex = 21;
      this.lblNominal.Text = "Nominal:";
      this.btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindExcelFile.FlatStyle = FlatStyle.System;
      this.btnFindExcelFile.Location = new System.Drawing.Point(413, 85);
      this.btnFindExcelFile.Name = "btnFindExcelFile";
      this.btnFindExcelFile.Size = new Size(32, 23);
      this.btnFindExcelFile.TabIndex = 20;
      this.btnFindExcelFile.Text = "...";
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Location = new System.Drawing.Point(71, 19);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(336, 21);
      this.txtSupplier.TabIndex = 19;
      this.lblSupplier.AutoSize = true;
      this.lblSupplier.Location = new System.Drawing.Point(6, 22);
      this.lblSupplier.Name = "lblSupplier";
      this.lblSupplier.Size = new Size(59, 13);
      this.lblSupplier.TabIndex = 18;
      this.lblSupplier.Text = "Supplier:";
      this.btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnImport.Enabled = false;
      this.btnImport.FlatStyle = FlatStyle.System;
      this.btnImport.Location = new System.Drawing.Point(451, 85);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new Size(58, 23);
      this.btnImport.TabIndex = 17;
      this.btnImport.Text = "Import";
      this.btnFindSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSupplier.FlatStyle = FlatStyle.System;
      this.btnFindSupplier.Location = new System.Drawing.Point(413, 17);
      this.btnFindSupplier.Name = "btnFindSupplier";
      this.btnFindSupplier.Size = new Size(32, 23);
      this.btnFindSupplier.TabIndex = 16;
      this.btnFindSupplier.Text = "...";
      this.txtExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtExcelFile.Location = new System.Drawing.Point(43, 87);
      this.txtExcelFile.Name = "txtExcelFile";
      this.txtExcelFile.ReadOnly = true;
      this.txtExcelFile.Size = new Size(364, 21);
      this.txtExcelFile.TabIndex = 15;
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(6, 90);
      this.lblFile.Name = "lblFile";
      this.lblFile.Size = new Size(31, 13);
      this.lblFile.TabIndex = 14;
      this.lblFile.Text = "File:";
      this.btnExportResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExportResults.Location = new System.Drawing.Point(860, 641);
      this.btnExportResults.Name = "btnExportResults";
      this.btnExportResults.Size = new Size(68, 27);
      this.btnExportResults.TabIndex = 5;
      this.btnExportResults.Text = "Export";
      this.btnExportResults.UseVisualStyleBackColor = true;
      this.tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcData.Location = new System.Drawing.Point(8, 169);
      this.tcData.Name = "tcData";
      this.tcData.SelectedIndex = 0;
      this.tcData.Size = new Size(920, 449);
      this.tcData.TabIndex = 8;
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(17, 645);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(780, 23);
      this.pbStatus.Step = 1;
      this.pbStatus.TabIndex = 10;
      this.lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblProgress.Location = new System.Drawing.Point(796, 652);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new Size(40, 16);
      this.lblProgress.TabIndex = 11;
      this.lblProgress.Text = "0%";
      this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
      this.lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessages.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessages.ForeColor = Color.Red;
      this.lblMessages.Location = new System.Drawing.Point(7, 621);
      this.lblMessages.Name = "lblMessages";
      this.lblMessages.Size = new Size(921, 19);
      this.lblMessages.TabIndex = 12;
      this.lblMessages.TextAlign = ContentAlignment.MiddleLeft;
      this.lblMessages.Visible = false;
      this.cboValidateType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboValidateType.FormattingEnabled = true;
      this.cboValidateType.Location = new System.Drawing.Point(6, 19);
      this.cboValidateType.Name = "cboValidateType";
      this.cboValidateType.Size = new Size(387, 21);
      this.cboValidateType.TabIndex = 1;
      this.btnProcessIndiv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnProcessIndiv.Location = new System.Drawing.Point(157, 54);
      this.btnProcessIndiv.Name = "btnProcessIndiv";
      this.btnProcessIndiv.Size = new Size(236, 23);
      this.btnProcessIndiv.TabIndex = 4;
      this.btnProcessIndiv.Text = "Process -->";
      this.btnProcessIndiv.UseVisualStyleBackColor = true;
      this.grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCatImport.Controls.Add((Control) this.btnValidateResults);
      this.grpCatImport.Controls.Add((Control) this.btnProcessIndiv);
      this.grpCatImport.Controls.Add((Control) this.cboValidateType);
      this.grpCatImport.Location = new System.Drawing.Point(529, 40);
      this.grpCatImport.Name = "grpCatImport";
      this.grpCatImport.Size = new Size(399, 123);
      this.grpCatImport.TabIndex = 6;
      this.grpCatImport.TabStop = false;
      this.grpCatImport.Text = "Category Processing";
      this.btnValidateResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnValidateResults.Location = new System.Drawing.Point(6, 54);
      this.btnValidateResults.Name = "btnValidateResults";
      this.btnValidateResults.Size = new Size(145, 23);
      this.btnValidateResults.TabIndex = 7;
      this.btnValidateResults.Text = "Revalidate Results";
      this.btnValidateResults.UseVisualStyleBackColor = true;
      this.lbl_Stats.AutoSize = true;
      this.lbl_Stats.Location = new System.Drawing.Point(126, 8);
      this.lbl_Stats.Name = "lbl_Stats";
      this.lbl_Stats.Size = new Size(0, 13);
      this.lbl_Stats.TabIndex = 15;
      this.lblDownloadTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblDownloadTemplate.Location = new System.Drawing.Point(800, 8);
      this.lblDownloadTemplate.Name = "lblDownloadTemplate";
      this.lblDownloadTemplate.Size = new Size(128, 23);
      this.lblDownloadTemplate.TabIndex = 16;
      this.lblDownloadTemplate.TabStop = true;
      this.lblDownloadTemplate.Text = "Download Template";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(940, 680);
      this.Controls.Add((Control) this.lblDownloadTemplate);
      this.Controls.Add((Control) this.grpExcelFile);
      this.Controls.Add((Control) this.btnExportResults);
      this.Controls.Add((Control) this.lbl_Stats);
      this.Controls.Add((Control) this.grpCatImport);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.tcData);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMSupplierInvoiceImporter);
      this.Text = "Supplier Invoice Importer";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.tcData, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.grpCatImport, 0);
      this.Controls.SetChildIndex((Control) this.lbl_Stats, 0);
      this.Controls.SetChildIndex((Control) this.btnExportResults, 0);
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.lblDownloadTemplate, 0);
      this.grpExcelFile.ResumeLayout(false);
      this.grpExcelFile.PerformLayout();
      this.grpCatImport.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public FileInfo File { get; set; }

    private List<DuplicateInvoice> DuplicateInvoices { get; set; }

    public Supplier Supplier
    {
      get
      {
        return this._supplier;
      }
      set
      {
        this._supplier = value;
        if (this._supplier == null)
        {
          this._supplier = new Supplier();
          this._supplier.Exists = false;
          this.txtSupplier.Text = "";
        }
        else
        {
          this.txtSupplier.Text = this._supplier.Name;
          this.txtNominal.Text = this._supplier.DefaultNominal.Trim();
        }
      }
    }

    public string NominalCode
    {
      get
      {
        return this._nominalCode;
      }
      set
      {
        this._nominalCode = value;
      }
    }

    private void FRMSupplierInvoiceImporter_Load(object sender, EventArgs e)
    {
      DataTable dataTable = App.DB.ImportValidation.Parts_PreImportStats();
      if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataTable.Rows[0][2], (object) "0", false))))
        return;
      this.lbl_Stats.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Import started on " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][0]), DateFormat.ShortDate) + " at " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][0]), DateFormat.ShortTime) + " finishing at " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][1]), DateFormat.ShortTime) + " and contains "), dataTable.Rows[0][2]), (object) " records."));
    }

    private void cboValidateType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      string Left = Combo.get_GetSelectedItemValue(this.cboValidateType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0 || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(10), false) == 0) || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(14), false) == 0)
        this.btnProcessIndiv.Visible = false;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(6), false) == 0)
      {
        this.btnProcessIndiv.Visible = true;
        this.btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(7), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(9), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Remove Records -->";
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(8), false) != 0)
          return;
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->";
      }
    }

    private void btnProcessIndiv_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      int num = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboValidateType));
      switch (num)
      {
        case 2:
          this.ValidateOrder(num);
          this.MoveProgressOn(true);
          this.ShowData(num);
          break;
        case 3:
        case 4:
        case 5:
        case 8:
          this.CreateSupplierInvoice(num);
          this.ValidateAllRecords();
          this.ShowData(num);
          break;
        case 6:
          this.CreatePurchaseCredit(num);
          this.ShowData(num);
          break;
        case 7:
          this.btnProcessIndiv.Visible = false;
          this.btnProcessIndiv.Text = "Remove Records -->";
          break;
      }
      Cursor.Current = Cursors.Default;
    }

    private void btnExportResults_Click(object sender, EventArgs e)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.Enabled = false;
        string sql = "EXEC Parts_GetPreImport " + Combo.get_GetSelectedItemValue(this.cboValidateType);
        DataView dataView = new DataView(App.DB.ExecuteWithReturn(sql, true));
        IEnumerator enumerator1;
        try
        {
          enumerator1 = dataView.Table.Columns.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataColumn current1 = (DataColumn) enumerator1.Current;
            IEnumerator enumerator2;
            if ((object) current1.DataType == (object) System.Type.GetType("System.String"))
            {
              try
              {
                enumerator2 = dataView.Table.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  DataRow current2 = (DataRow) enumerator2.Current;
                  current2[current1.ColumnName] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "'", current2[current1.ColumnName]);
                }
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        string exportFileName = Combo.get_GetSelectedItemDescription(this.cboValidateType);
        ExportHelper.Export(dataView.Table, exportFileName, Enums.ExportType.XLS);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error exporting : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Enabled = true;
        Cursor.Current = Cursors.Default;
      }
    }

    private void btnFindExcelFile_Click(object sender, EventArgs e)
    {
      this.LoadData();
    }

    private void btnFindSupplier_Click(object sender, EventArgs e)
    {
      this.FindSupplier();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.Import();
    }

    private void btnValidateResults_Click(object sender, EventArgs e)
    {
      this.ValidateAllRecords();
    }

    private void CreateSupplierInvoice(int validationResult)
    {
      DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(validationResult);
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (dataView.Count + 1);
      IEnumerator enumerator;
      try
      {
        enumerator = dataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          bool flag = true;
          int OrderID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderID"]));
          bool RequiresAuth = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["RequiresAuthorisation"]));
          if (OrderID == 0)
          {
            flag = false;
            int num = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "An error has occurred:\r\nUnable to locate the OrderID for PO ", current["PurchaseOrderNo"]), (object) ", please contact your administrator")), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Exclude"])))
            flag = false;
          if (Helper.MakeIntegerValid((object) App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(OrderID)) == 1)
          {
            flag = false;
            int num = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "An error has occurred:\r\nSupplier Invoice for PO ", current["PurchaseOrderNo"]), (object) " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator")), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag)
          {
            Order order = App.DB.Order.Order_Get(OrderID);
            int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["NominalCode"]));
            if (num1 == 0)
              num1 = 5300;
            int num2 = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["SubContractor"])) || Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TotalVatAmount"])) != 0.0 ? (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TotalVatAmount"])) <= 0.0 ? 72060 : 5373) : 66929;
            SupplierInvoice oSupplierInvoice = new SupplierInvoice()
            {
              SetOrderID = (object) OrderID,
              SetInvoiceReference = RuntimeHelpers.GetObjectValue(current["InvoiceNo"]),
              SetInvoiceDate = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["InvoiceDate"])),
              SetGoodsAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TotalGrossAmount"])),
              SetVATAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TotalVatAmount"])),
              SetTotalAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["TotalNetAmount"])),
              SetTaxCodeID = (object) num2,
              SetNominalCode = (object) num1,
              SetSentToSage = (object) 0,
              SetOldSystemInvoice = (object) 0,
              SetDateExported = (object) null,
              SetKeyedBy = (object) App.loggedInUser.UserID,
              SetExtraRef = (object) ".",
              SetReadyToSendToSage = (object) true
            };
            if (true != App.IsGasway && RequiresAuth)
              oSupplierInvoice.SetReadyToSendToSage = (object) false;
            if (order != null && order.OrderTypeID == 4)
            {
              DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(OrderID);
              if (forSupplierInvoice.Rows.Count > 0)
              {
                string str = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                if (Conversions.ToDouble(str) > 0.0)
                  oSupplierInvoice.SetExtraRef = (object) str;
              }
            }
            try
            {
              App.DB.SupplierInvoices.Insert(oSupplierInvoice);
              App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(current["ID"]), true);
              if (RequiresAuth)
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(current["ID"]), RequiresAuth);
              else
                App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(current["ID"].ToString()), 7);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num3 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            this.MoveProgressOn(false);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void CreatePurchaseCredit(int validationResult)
    {
      DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(validationResult);
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (dataView.Count + 1);
      IEnumerator enumerator1;
      try
      {
        enumerator1 = dataView.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current1 = (DataRow) enumerator1.Current;
          bool flag1 = true;
          int OrderID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["OrderID"]));
          bool RequiresAuth = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["RequiresAuthorisation"]));
          if (OrderID == 0)
          {
            flag1 = false;
            if (RequiresAuth)
              App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(current1["ID"]), RequiresAuth);
            int num = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "An error has occurred:\r\nUnable to locate the OrderID for PO ", current1["PurchaseOrderNo"]), (object) ", please contact your administrator")), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["Exclude"])))
            flag1 = false;
          if (Helper.MakeIntegerValid((object) App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(OrderID)) == 1)
          {
            flag1 = false;
            int num = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "An error has occurred:\r\nSupplier Invoice for PO ", current1["PurchaseOrderNo"]), (object) " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator")), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag1)
          {
            Order order = App.DB.Order.Order_Get(OrderID);
            int TaxCodeID = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["SubContractor"])) || Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["TotalVatAmount"])) != 0.0 ? (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["TotalVatAmount"])) <= 0.0 ? 72060 : 5373) : 66929;
            PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited()
            {
              SetOrderID = (object) OrderID,
              SetOrderReference = (object) order.OrderReference,
              SetSupplierID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["SupplierID"])),
              SetStatusID = (object) 3
            };
            string ExtraRef = "";
            if (order != null && order.OrderTypeID == 4)
            {
              DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(OrderID);
              if (forSupplierInvoice.Rows.Count > 0)
                ExtraRef = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
            }
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = App.DB.ExecuteWithReturn(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '", current1["InvoiceNo"]), (object) "'")), true);
            bool flag2 = true;
            IEnumerator enumerator2;
            try
            {
              enumerator2 = dataTable2.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator2.Current;
                Part forCodeAndSupplier = App.DB.Part.Part_Get_For_Code_And_Supplier(Conversions.ToString(current2["SupplierPartCode"]), Conversions.ToInteger(current1["SupplierID"]));
                int num = -1;
                if (forCodeAndSupplier != null)
                  num = forCodeAndSupplier.SPartID;
                DataTable dataTable3 = App.DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " + Conversions.ToString(OrderID) + " AND PartSupplierID = " + Conversions.ToString(num), true);
                if (dataTable3.Rows.Count > 0)
                {
                  flag2 = false;
                  oPartsToBeCredited.SetPartID = (object) forCodeAndSupplier.PartID;
                  oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(current2["Quantity"]);
                  oPartsToBeCredited.SetCreditReceived = (object) Conversions.ToDouble(current2["NetAmount"].ToString().Replace("-", ""));
                  oPartsToBeCredited.SetPartOrderID = RuntimeHelpers.GetObjectValue(dataTable3.Rows[0]["OrderPartID"]);
                  dataTable1 = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(dataTable3.Rows[0]["OrderPartID"])).Table;
                  if (dataTable1.Rows.Count > 0)
                  {
                    oPartsToBeCredited.SetPartsToBeCreditedID = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PartsToBeCreditedID"]);
                    App.DB.PartsToBeCredited.Update(oPartsToBeCredited);
                  }
                  else
                    oPartsToBeCredited = App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            if (flag2)
            {
              DataTable dataTable3 = App.DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " + Conversions.ToString(OrderID), true);
              int integer = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select Top (1) PartID From tblPartSupplier Where PartSupplierID = ", dataTable3.Rows[0]["PartSupplierID"])), true, false));
              oPartsToBeCredited.SetPartID = (object) integer;
              oPartsToBeCredited.SetQty = (object) 1;
              oPartsToBeCredited.SetCreditReceived = (object) Conversions.ToDouble(current1["TotalNetAmount"].ToString().Replace("-", ""));
              oPartsToBeCredited.SetPartOrderID = RuntimeHelpers.GetObjectValue(dataTable3.Rows[0]["OrderPartID"]);
              dataTable1 = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(dataTable3.Rows[0]["OrderPartID"])).Table;
              if (dataTable1.Rows.Count > 0)
              {
                oPartsToBeCredited.SetPartsToBeCreditedID = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PartsToBeCreditedID"]);
                App.DB.PartsToBeCredited.Update(oPartsToBeCredited);
              }
              else
                oPartsToBeCredited = App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
            }
            if (dataTable1.Rows.Count == 0)
            {
              int num = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(current1["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(current1["InvoiceDate"]), DateTime.MinValue, TaxCodeID, "5300", order.DepartmentRef, ExtraRef, Conversions.ToString(current1["InvoiceNo"]));
              App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + Conversions.ToString(num) + "," + Conversions.ToString(oPartsToBeCredited.PartsToBeCreditedID) + ")", true, false);
            }
            else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PartCreditsID"])))
            {
              int num = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(current1["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(current1["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", order.DepartmentRef, ExtraRef, Conversions.ToString(current1["InvoiceNo"]));
              App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + Conversions.ToString(num) + "," + Conversions.ToString(oPartsToBeCredited.PartsToBeCreditedID) + ")", true, false);
            }
            else
              App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dataTable1.Rows[0]["PartCreditsID"]), Conversions.ToDouble(current1["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(current1["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", order.DepartmentRef, ExtraRef, Conversions.ToString(current1["InvoiceNo"]));
            App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(current1["ID"]), true);
            this.MoveProgressOn(false);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
    }

    public void ShowData(int ValidateType = 0)
    {
      this.tcData.TabPages.Clear();
      TabPage tabPage = new TabPage();
      UCDataPartsInvoiceImport partsInvoiceImport = new UCDataPartsInvoiceImport();
      partsInvoiceImport.Dock = DockStyle.Fill;
      partsInvoiceImport.Data = App.DB.ImportValidation.POInvoiceImport_ShowData(ValidateType);
      partsInvoiceImport.ValidateType = Combo.get_GetSelectedItemValue(this.cboValidateType);
      tabPage.Text = "Supplier Invoice Import Data (" + Conversions.ToString(partsInvoiceImport.Data.Count) + " Records)";
      tabPage.Controls.Add((Control) partsInvoiceImport);
      this.tcData.TabPages.Add(tabPage);
      this.tcData.SelectedIndex = 0;
      this.MoveProgressOn(true);
    }

    private void LoadData()
    {
      OpenFileDialog openFileDialog = (OpenFileDialog) null;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.btnFindSupplier.Enabled = false;
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
        openFileDialog?.Dispose();
        this.btnFindSupplier.Enabled = true;
        Cursor.Current = Cursors.Default;
      }
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

    private bool IsFormValid()
    {
      if (Helper.MakeIntegerValid((object) this.Supplier?.SupplierID) == 0)
      {
        int num = (int) App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (Helper.MakeIntegerValid((object) this.txtNominal.Text.Trim()) > 0)
        return true;
      int num1 = (int) App.ShowMessage("Please enter a numeric nominal", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }

    private void Import()
    {
      if (!this.IsFormValid())
        return;
      this.NominalCode = this.txtNominal.Text.Trim();
      this.lblMessages.Text = "Starting import...";
      this.lblMessages.Visible = true;
      this.DuplicateInvoices.Clear();
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = 1;
      if (this.PreImportData())
      {
        ComboBox cboValidateType = this.cboValidateType;
        Combo.SetSelectedComboItem_By_Value(ref cboValidateType, "0");
        this.cboValidateType = cboValidateType;
        this.ShowData(0);
        this.lblMessages.Text = "Import complete.";
        this.lblMessages.Visible = true;
        if (this.DuplicateInvoices.Count > 0)
        {
          List<string> details = new List<string>();
          try
          {
            foreach (DuplicateInvoice duplicateInvoice in this.DuplicateInvoices)
              details.Add("Invovice: " + duplicateInvoice.InvoiceNo + " InvoiceDate: " + duplicateInvoice.InvoiceDate + " PartCode:  " + duplicateInvoice.SupplierPartCode);
          }
          finally
          {
            List<DuplicateInvoice>.Enumerator enumerator;
            enumerator.Dispose();
          }
          if (App.ShowMessageWithDetails("Import Complete", "The following invoices are duplicates and have not been imported.", details) == DialogResult.OK)
          {
            int num = (int) new FRMDuplicateInvoices(this.DuplicateInvoices).ShowDialog();
          }
        }
        else
        {
          int num1 = (int) App.ShowMessage("Import Completed!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        string path = App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\" + this.Supplier.Name.Replace("/", "").Replace("\\", "") + "\\Proccessed\\";
        Directory.CreateDirectory(path);
        string extension = Path.GetExtension(this.File.Name);
        System.IO.File.Move(this.File.FullName, path + this.File.Name.Replace(extension, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + extension));
        this.File = (FileInfo) null;
        this.txtExcelFile.Text = "";
        this.txtNominal.Text = "";
        this.Supplier = (Supplier) null;
        this.NominalCode = (string) null;
        this.pbStatus.Value = this.pbStatus.Maximum;
        this.btnFindExcelFile.Enabled = true;
        this.btnImport.Enabled = true;
        this.pbStatus.Value = 0;
        this.DuplicateInvoices.Clear();
        Cursor.Current = Cursors.Default;
      }
      else
      {
        int num2 = (int) App.ShowMessage("Error uploading excel document", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private bool PreImportData()
    {
      bool flag;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.lblMessages.Visible = true;
        this.lblMessages.Text = "Downloading data from file...";
        this.btnFindExcelFile.Enabled = false;
        this.btnImport.Enabled = false;
        this.pbStatus.Value = 0;
        System.Windows.Forms.Application.DoEvents();
        ExcelQueryFactory excelQueryFactory = new ExcelQueryFactory(this.File.FullName);
        object obj1 = (object) excelQueryFactory.Worksheet().Select<Row, Row>((Expression<Func<Row, Row>>) (a => a));
        object worksheetNames = (object) excelQueryFactory.GetWorksheetNames();
        object columnNames = (object) excelQueryFactory.GetColumnNames("Sheet1");
        DataTable dataTable1 = new DataTable();
        IEnumerator enumerator1;
        try
        {
          enumerator1 = ((IEnumerable) columnNames).GetEnumerator();
          while (enumerator1.MoveNext())
          {
            object objectValue = RuntimeHelpers.GetObjectValue(enumerator1.Current);
            object[] objArray;
            bool[] flagArray;
            NewLateBinding.LateCall((object) dataTable1.Columns, (System.Type) null, "Add", objArray = new object[1]
            {
              objectValue
            }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
            {
              true
            }, true);
            if (flagArray[0])
              RuntimeHelpers.GetObjectValue(objArray[0]);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = ((IEnumerable) obj1).GetEnumerator();
          while (enumerator2.MoveNext())
          {
            Row current = (Row) enumerator2.Current;
            DataRow row = dataTable1.NewRow();
            IEnumerator enumerator3;
            try
            {
              enumerator3 = ((IEnumerable) columnNames).GetEnumerator();
              while (enumerator3.MoveNext())
              {
                object objectValue = RuntimeHelpers.GetObjectValue(enumerator3.Current);
                DataRow dataRow = row;
                object[] Arguments = new object[2]
                {
                  objectValue,
                  null
                };
                object[] objArray;
                bool[] flagArray;
                object obj2 = NewLateBinding.LateGet((object) current, (System.Type) null, "Item", objArray = new object[1]
                {
                  objectValue
                }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
                {
                  true
                });
                if (flagArray[0])
                  RuntimeHelpers.GetObjectValue(objArray[0]);
                Arguments[1] = obj2;
                NewLateBinding.LateSet((object) dataRow, (System.Type) null, "Item", Arguments, (string[]) null, (System.Type[]) null);
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            dataTable1.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        ProgressBar pbStatus;
        int num1 = checked ((pbStatus = this.pbStatus).Maximum + dataTable1.Rows.Count);
        pbStatus.Maximum = num1;
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("InvoiceNo");
        dataTable2.Columns.Add("InvoiceDate");
        dataTable2.Columns.Add("PurchaseOrderNo");
        dataTable2.Columns.Add("SupplierPartCode");
        dataTable2.Columns.Add("Description");
        dataTable2.Columns.Add("Quantity");
        dataTable2.Columns.Add("UnitPrice");
        dataTable2.Columns.Add("NetAmount");
        dataTable2.Columns.Add("VATAmount");
        dataTable2.Columns.Add("GrossAmount");
        dataTable2.Columns.Add("InsertDB");
        IEnumerator enumerator4;
        try
        {
          enumerator4 = dataTable1.Rows.GetEnumerator();
          while (enumerator4.MoveNext())
          {
            DataRow current = (DataRow) enumerator4.Current;
            DataRow row = dataTable2.NewRow();
            if (current["Invoice Number"] != DBNull.Value)
            {
              row["InvoiceNo"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Invoice Number"])).Trim();
              if (current["Invoice Date"] != DBNull.Value)
              {
                row["InvoiceDate"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Invoice Date"]));
                if (current["Purchase Order Reference"] != DBNull.Value)
                {
                  row["PurchaseOrderNo"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Purchase Order Reference"])).Trim();
                  if (current.Table.Columns.Contains("Product Code"))
                    row["SupplierPartCode"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Product Code"]));
                  if (current.Table.Columns.Contains("Product Description"))
                    row["Description"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Product Description"]));
                  if (current.Table.Columns.Contains("Quantity"))
                    row["Quantity"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Quantity"]));
                  if (current["Unit Price"] != DBNull.Value)
                  {
                    row["UnitPrice"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Unit Price"])).Trim();
                    if (current["Net Amount"] != DBNull.Value)
                    {
                      row["NetAmount"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Net Amount"])).Trim();
                      if (current["VAT Amount"] != DBNull.Value)
                      {
                        row["VATAmount"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["VAT Amount"])).Trim();
                        if (current["Gross Amount"] != DBNull.Value)
                        {
                          row["GrossAmount"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Gross Amount"])).Trim();
                          row["InsertDB"] = (object) true;
                          dataTable2.Rows.Add(row);
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        finally
        {
          if (enumerator4 is IDisposable)
            (enumerator4 as IDisposable).Dispose();
        }
        try
        {
          IEnumerator enumerator3;
          try
          {
            enumerator3 = dataTable2.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current = (DataRow) enumerator3.Current;
              string str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["InvoiceNo"]));
              DateTime InvoiceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["InvoiceDate"]));
              string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PurchaseOrderNo"]));
              string SupplierPartCode = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["SupplierPartCode"]));
              string Description = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Description"]));
              int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Quantity"]));
              double num3 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["UnitPrice"]));
              double num4 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["NetAmount"]));
              double num5 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["VATAmount"]));
              double num6 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["GrossAmount"]));
              if (App.DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(str1, InvoiceDate, SupplierPartCode) > 0)
              {
                current["InsertDB"] = (object) false;
                this.MoveProgressOn(false);
              }
              else
              {
                if (App.DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(str1, InvoiceDate, SupplierPartCode) > 0)
                {
                  this.DuplicateInvoices.Add(new DuplicateInvoice()
                  {
                    PurchaseOrderNo = str2,
                    SupplierPartCode = SupplierPartCode,
                    Description = Description,
                    Quantity = num2,
                    UnitPrice = num3,
                    NetAmount = num4,
                    VATAmount = num5,
                    GrossAmount = num6,
                    InvoiceNo = str1,
                    InvoiceDate = Conversions.ToString(InvoiceDate),
                    SupplierID = this.Supplier.SupplierID,
                    TotalQtyOfParts = num2
                  });
                  current["InsertDB"] = (object) false;
                }
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["InsertDB"])))
                {
                  int ImportID = App.DB.ImportValidation.Orders_GetID(str2, Conversions.ToString(this.Supplier.SupplierID), str1);
                  if (ImportID == 0)
                    ImportID = App.DB.ImportValidation.POInvoiceImport_InsertOrder(str1, InvoiceDate, str2, this.Supplier.SupplierID, "Unspecified", this.NominalCode);
                  App.DB.ImportValidation.POInvoiceImport_InsertPart(str2, SupplierPartCode, Description, num2, num3, num4, num5, num6, str1);
                  App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(str2, num2, num3, num4, num5, num6, num2, str1);
                  if (ImportID > 0)
                    App.DB.ImportValidation.POInvoiceImport_ValidateOrder(ImportID);
                }
              }
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          this.MoveProgressOn(true);
          flag = true;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.lblMessages.Visible = false;
          flag = false;
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.lblMessages.Visible = false;
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void FindSupplier()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 1, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Supplier = App.DB.Supplier.Supplier_Get(integer);
    }

    private void lblDownloadTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = (FolderBrowserDialog) null;
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application app = (Microsoft.Office.Interop.Excel.Application) null;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        app = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated method
        app.Workbooks.Add((object) (System.Windows.Forms.Application.StartupPath + "\\GenericDocuments\\SupplierInvoiceImportTemplate.xlsx"));
        if (System.IO.File.Exists(folderBrowserDialog.SelectedPath + "\\SupplierInvoiceImporter.xlsx"))
          System.IO.File.Delete(folderBrowserDialog.SelectedPath + "\\SupplierInvoiceImporter.xlsx");
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        app.Workbooks.get_Item((object) 1).SaveAs((object) (folderBrowserDialog.SelectedPath + "\\SupplierInvoiceImporter.xlsx"), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
        int num = (int) App.ShowMessage("File downloaded to " + folderBrowserDialog.SelectedPath + "\\SupplierInvoiceImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Template could not be saved : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.KillInstances(app);
        folderBrowserDialog.Dispose();
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

    public void ValidateOrder(int ValidateType)
    {
      this.lblMessages.Text = "Now validating orders, this can take up to two minutes. Please be patient.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.WaitCursor;
      App.DB.ImportValidation.POInvoiceImport_ValidateOrders(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      this.lblMessages.Text = "Validation complete.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.Default;
    }

    public void ValidateAllRecords()
    {
      this.lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.WaitCursor;
      DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData_Mk1();
      int count = dataView.Count;
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (count + 1);
      IEnumerator enumerator;
      try
      {
        enumerator = dataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          int ImportID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(((DataRow) enumerator.Current)["ID"]));
          App.DB.ImportValidation.POInvoiceImport_ValidateOrder(ImportID);
          this.MoveProgressOn(false);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetSelectedComboItem_By_Value(ref cboValidateType, "0");
      this.cboValidateType = cboValidateType;
      this.ShowData(0);
      this.lblMessages.Text = "Validation complete.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.Default;
    }
  }
}
