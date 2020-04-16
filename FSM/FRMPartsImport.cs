// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartsImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Suppliers;
using FSM.Entity.Sys;
using LinqToExcel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMPartsImport : FRMBaseForm
  {
    private IContainer components;
    private FileInfo _file;
    private Supplier _supplier;

    public FRMPartsImport()
    {
      this.Load += new EventHandler(this.FRMPartsImport_Load);
      this.InitializeComponent();
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetUpCombo(ref cboValidateType, DynamicDataTables.PartValidationTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
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

    internal virtual LinkLabel btnExportParts
    {
      get
      {
        return this._btnExportParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.btnExportParts_LinkClicked);
        LinkLabel btnExportParts1 = this._btnExportParts;
        if (btnExportParts1 != null)
          btnExportParts1.LinkClicked -= clickedEventHandler;
        this._btnExportParts = value;
        LinkLabel btnExportParts2 = this._btnExportParts;
        if (btnExportParts2 == null)
          return;
        btnExportParts2.LinkClicked += clickedEventHandler;
      }
    }

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

    internal virtual CheckBox chkPFH { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual LinkLabel llOpenFolder
    {
      get
      {
        return this._llOpenFolder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.llOpenFolder_LinkClicked);
        LinkLabel llOpenFolder1 = this._llOpenFolder;
        if (llOpenFolder1 != null)
          llOpenFolder1.LinkClicked -= clickedEventHandler;
        this._llOpenFolder = value;
        LinkLabel llOpenFolder2 = this._llOpenFolder;
        if (llOpenFolder2 == null)
          return;
        llOpenFolder2.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.chkPFH = new CheckBox();
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
      this.btnExportParts = new LinkLabel();
      this.cboValidateType = new ComboBox();
      this.btnProcessIndiv = new Button();
      this.grpCatImport = new GroupBox();
      this.lbl_Stats = new Label();
      this.llOpenFolder = new LinkLabel();
      this.grpExcelFile.SuspendLayout();
      this.grpCatImport.SuspendLayout();
      this.SuspendLayout();
      this.grpExcelFile.Controls.Add((Control) this.chkPFH);
      this.grpExcelFile.Controls.Add((Control) this.btnFindExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.txtSupplier);
      this.grpExcelFile.Controls.Add((Control) this.lblSupplier);
      this.grpExcelFile.Controls.Add((Control) this.btnImport);
      this.grpExcelFile.Controls.Add((Control) this.btnFindSupplier);
      this.grpExcelFile.Controls.Add((Control) this.txtExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.lblFile);
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(515, 85);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Initial Import";
      this.chkPFH.AutoSize = true;
      this.chkPFH.Location = new System.Drawing.Point(452, 22);
      this.chkPFH.Name = "chkPFH";
      this.chkPFH.Size = new Size(47, 17);
      this.chkPFH.TabIndex = 21;
      this.chkPFH.Text = "PFH";
      this.chkPFH.UseVisualStyleBackColor = true;
      this.btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindExcelFile.FlatStyle = FlatStyle.System;
      this.btnFindExcelFile.Location = new System.Drawing.Point(413, 51);
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
      this.btnImport.Location = new System.Drawing.Point(451, 51);
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
      this.txtExcelFile.Location = new System.Drawing.Point(43, 53);
      this.txtExcelFile.Name = "txtExcelFile";
      this.txtExcelFile.ReadOnly = true;
      this.txtExcelFile.Size = new Size(364, 21);
      this.txtExcelFile.TabIndex = 15;
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(6, 56);
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
      this.tcData.Location = new System.Drawing.Point(8, 131);
      this.tcData.Name = "tcData";
      this.tcData.SelectedIndex = 0;
      this.tcData.Size = new Size(920, 487);
      this.tcData.TabIndex = 8;
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(10, 645);
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
      this.btnExportParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExportParts.Location = new System.Drawing.Point(840, 8);
      this.btnExportParts.Name = "btnExportParts";
      this.btnExportParts.Size = new Size(88, 23);
      this.btnExportParts.TabIndex = 13;
      this.btnExportParts.TabStop = true;
      this.btnExportParts.Text = "Export Parts";
      this.cboValidateType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboValidateType.FormattingEnabled = true;
      this.cboValidateType.Location = new System.Drawing.Point(6, 19);
      this.cboValidateType.Name = "cboValidateType";
      this.cboValidateType.Size = new Size(387, 21);
      this.cboValidateType.TabIndex = 1;
      this.btnProcessIndiv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnProcessIndiv.Location = new System.Drawing.Point(178, 51);
      this.btnProcessIndiv.Name = "btnProcessIndiv";
      this.btnProcessIndiv.Size = new Size(215, 23);
      this.btnProcessIndiv.TabIndex = 4;
      this.btnProcessIndiv.Text = "Process -->";
      this.btnProcessIndiv.UseVisualStyleBackColor = true;
      this.grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCatImport.Controls.Add((Control) this.btnProcessIndiv);
      this.grpCatImport.Controls.Add((Control) this.cboValidateType);
      this.grpCatImport.Location = new System.Drawing.Point(529, 40);
      this.grpCatImport.Name = "grpCatImport";
      this.grpCatImport.Size = new Size(399, 85);
      this.grpCatImport.TabIndex = 6;
      this.grpCatImport.TabStop = false;
      this.grpCatImport.Text = "Category Processing";
      this.lbl_Stats.AutoSize = true;
      this.lbl_Stats.Location = new System.Drawing.Point(126, 8);
      this.lbl_Stats.Name = "lbl_Stats";
      this.lbl_Stats.Size = new Size(0, 13);
      this.lbl_Stats.TabIndex = 15;
      this.llOpenFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.llOpenFolder.Location = new System.Drawing.Point(707, 8);
      this.llOpenFolder.Name = "llOpenFolder";
      this.llOpenFolder.Size = new Size(111, 23);
      this.llOpenFolder.TabIndex = 16;
      this.llOpenFolder.TabStop = true;
      this.llOpenFolder.Text = "View Parts Files";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(940, 680);
      this.Controls.Add((Control) this.llOpenFolder);
      this.Controls.Add((Control) this.grpExcelFile);
      this.Controls.Add((Control) this.btnExportResults);
      this.Controls.Add((Control) this.lbl_Stats);
      this.Controls.Add((Control) this.grpCatImport);
      this.Controls.Add((Control) this.btnExportParts);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.tcData);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMPartsImport);
      this.Text = "Parts Import";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.tcData, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.btnExportParts, 0);
      this.Controls.SetChildIndex((Control) this.grpCatImport, 0);
      this.Controls.SetChildIndex((Control) this.lbl_Stats, 0);
      this.Controls.SetChildIndex((Control) this.btnExportResults, 0);
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.llOpenFolder, 0);
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
        }
        else
          this.txtSupplier.Text = this._supplier.Name;
      }
    }

    private void FRMPartsImport_Load(object sender, EventArgs e)
    {
      DataTable dataTable = App.DB.ImportValidation.Parts_PreImportStats();
      if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataTable.Rows[0][2], (object) "0", false))))
        return;
      this.lbl_Stats.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Import started on " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][0]), DateFormat.ShortDate) + " at " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][0]), DateFormat.ShortTime) + " finishing at " + Microsoft.VisualBasic.Strings.FormatDateTime(Conversions.ToDate(dataTable.Rows[0][1]), DateFormat.ShortTime) + " and contains "), dataTable.Rows[0][2]), (object) " records."));
    }

    private void cboValidateType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowData();
      string Left = Combo.get_GetSelectedItemValue(this.cboValidateType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0 || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(7), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(8), false) == 0) || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(9), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(12), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(13), false) == 0) || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(14), false) == 0)
        this.btnProcessIndiv.Text = "Revalidate Results -->";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        this.btnProcessIndiv.Text = "Apply No Change -->";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        this.btnProcessIndiv.Text = "Apply Price Change -->";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
      {
        this.btnProcessIndiv.Text = "Add Parts -->";
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(6), false) != 0)
          return;
        this.btnProcessIndiv.Text = "Add Parts -->";
      }
    }

    private void btnProcessIndiv_Click(object sender, EventArgs e)
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboValidateType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0 || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(7), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(8), false) == 0) || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(9), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(12), false) == 0) || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(14), false) == 0)
      {
        if (App.ShowMessage("This action will revalidate the pre-import data, no changes will be made to live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = (int) Enum.GetValues(typeof (Enums.PartValidationResults)).Cast<Enums.PartValidationResults>().Max<Enums.PartValidationResults>();
        Cursor.Current = Cursors.WaitCursor;
        this.ValidateAllRecords();
        this.ShowData();
        this.MoveProgressOn(true);
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        if (App.ShowMessage("This action will remove these parts from the pre-import data, no changes will be made to live parts other than the date update.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = 1;
        Cursor.Current = Cursors.WaitCursor;
        App.DB.ImportValidation.Parts_PreImportNoChangeRemove(!this.chkPFH.Checked);
        this.ShowData();
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        if (App.ShowMessage("This action will update PRICES ONLY on live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = 1;
        Cursor.Current = Cursors.WaitCursor;
        App.DB.ImportValidation.Parts_ImportApplyPriceChange(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.ShowData();
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
      {
        if (App.ShowMessage("This action will attach the supplier (SPN) as a seller of this part, if the 'swap SPN' flag has been ticked then the supplier SPN will only be updated.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = 1;
        Cursor.Current = Cursors.WaitCursor;
        App.DB.ImportValidation.Parts_ImportAddPartSuppliers(0);
        this.ShowData();
        Cursor.Current = Cursors.Default;
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(6), false) != 0 || App.ShowMessage("This action will add the part (MPN) as a complete new part and attach the supplier (SPN) as a seller of this part.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
          return;
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = 1;
        Cursor.Current = Cursors.WaitCursor;
        App.DB.ImportValidation.Parts_ImportAddParts(0);
        this.ShowData();
        Cursor.Current = Cursors.Default;
      }
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

    private void btnExportParts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.Enabled = false;
        string sql = "SELECT tblPart.PartID, tblPart.Name, tblPart.Number, tblPart.Reference, tblPart.Notes, tblPart.UnitTypeID, tblPart.Deleted, tblPart.SellPrice, tblPart.MinimumQuantity, tblPart.RecommendedQuantity, tblPicklists.Name AS Category, tblPart.LastChanged, tblPart.BinID, tblPart.ShelfID, tblPart.WarehouseID, tblPart.BinIDAlternative, tblPart.ShelfIDAlternative, tblPart.WarehouseIDAlternative, tblPart.EndFlagged, tblPart.Equipment, tblSupplier.Name AS Supplier, tblPartSupplier.PartCode AS [Supplier Part Number],  tblPartSupplier.Price AS [Supplier Price]  FROM tblPart INNER JOIN  tblPicklists ON tblPart.CategoryID = tblPicklists.ManagerID INNER JOIN  tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID INNER JOIN  tblSupplier ON tblPartSupplier.SupplierID = tblSupplier.SupplierID  WHERE tblPart.Deleted = 0";
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
        ExportHelper.Export(dataView.Table, "Parts", Enums.ExportType.XLS);
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

    public void ShowData()
    {
      this.tcData.TabPages.Clear();
      Cursor.Current = Cursors.WaitCursor;
      TabPage tabPage = new TabPage();
      UCData ucData = new UCData();
      ucData.SetupDG();
      ucData.dgvData.Columns["SwapSPN"].Visible = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboValidateType)) == 5.0;
      ucData.dgvData.Columns["Category"].ReadOnly = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboValidateType)) != 7.0;
      ucData.Dock = DockStyle.Fill;
      ucData.Data = App.DB.ImportValidation.Parts_GetPreImportData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      tabPage.Text = "Parts Pre-Import (" + Conversions.ToString(ucData.Data.Count) + " Records)";
      tabPage.Controls.Add((Control) ucData);
      this.tcData.TabPages.Add(tabPage);
      this.tcData.SelectedIndex = 0;
      Cursor.Current = Cursors.Default;
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

    public void SetLastPartAttempted(string PartCode)
    {
      this.lblMessages.Visible = true;
      this.lblMessages.Text = PartCode;
    }

    private void Import()
    {
      if (this.Supplier == null || !this.Supplier.Exists)
      {
        int num1 = (int) App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        bool flag = false;
        if (App.DB.ImportValidation.Parts_CheckPreImportCount() > 0)
        {
          if (App.ShowMessage("There are already parts in the pre-import table.  You should process or clear them before importing more data.  Clear Now?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            return;
          App.DB.ImportValidation.Parts_ClearPreImport();
        }
        if (App.ShowMessage("You are about to load data from the parts files, to the temporary holding table, do you wish to continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) != DialogResult.Yes)
          return;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Excel.Application app = (Microsoft.Office.Interop.Excel.Application) null;
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
          object obj1 = (object) excelQueryFactory.Worksheet("Upload Template").Select<Row, Row>((Expression<Func<Row, Row>>) (a => a));
          object columnNames = (object) excelQueryFactory.GetColumnNames("Upload Template");
          DataTable dataTable = new DataTable();
          IEnumerator enumerator1;
          try
          {
            enumerator1 = ((IEnumerable) columnNames).GetEnumerator();
            while (enumerator1.MoveNext())
            {
              object objectValue = RuntimeHelpers.GetObjectValue(enumerator1.Current);
              object[] objArray;
              bool[] flagArray;
              NewLateBinding.LateCall((object) dataTable.Columns, (System.Type) null, "Add", objArray = new object[1]
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
              DataRow row = dataTable.NewRow();
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
              dataTable.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          ProgressBar pbStatus;
          int num2 = checked ((pbStatus = this.pbStatus).Maximum + dataTable.Rows.Count);
          pbStatus.Maximum = num2;
          DataTable dt = new DataTable();
          dt.Columns.Add("SupplierID");
          dt.Columns.Add("Partcode");
          dt.Columns.Add("Description");
          dt.Columns.Add("SupplierPartCode");
          dt.Columns.Add("SupplierPrice");
          dt.Columns.Add("SupplierSecondaryPrice");
          dt.Columns.Add("Category");
          int num3 = checked (dataTable.Rows.Count - 1);
          int index = 0;
          while (index <= num3)
          {
            DataRow row = dataTable.Rows[index];
            int supplierId = this.Supplier.SupplierID;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            double num4 = 0.0;
            double num5 = 0.0;
            if (row["SPN"] != DBNull.Value)
            {
              string str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["SPN"]));
              if (row["MPN"] != DBNull.Value)
              {
                string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["MPN"]));
                string str3 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Description"]));
                if (row["Net Price"] != DBNull.Value)
                {
                  if (this.chkPFH.Checked)
                    num5 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["Net Price"]));
                  else
                    num4 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["Net Price"]));
                  string str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["Category"]));
                  this.lblMessages.Text = "Adding part " + Conversions.ToString(checked (index + 1)) + " of " + Conversions.ToString(dataTable.Rows.Count) + " from file.";
                  this.lblMessages.Visible = true;
                  dt.Rows.Add((object) supplierId, (object) str2, (object) str3, (object) str1, (object) num4, (object) num5, (object) str4);
                }
              }
            }
            this.MoveProgressOn(false);
            checked { ++index; }
          }
          App.DB.ImportValidation.BulkInsert(dt);
          this.ValidateAllRecords();
          flag = true;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          this.lblMessages.Text = "Error!";
          int num2 = (int) App.ShowMessage("File data could not be imported : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.MoveProgressOn(true);
          this.KillInstances(app);
          if (flag)
          {
            try
            {
              string str = this.chkPFH.Checked ? this.Supplier.Name + "_PFH" : this.Supplier.Name;
              string path = App.TheSystem.Configuration.DocumentsLocation + "PartsFiles\\" + str + "\\";
              Directory.CreateDirectory(path);
              string extension = Path.GetExtension(this.File.Name);
              System.IO.File.Move(this.File.FullName, path + this.File.Name.Replace(extension, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + extension));
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("Data imported and validated but file has not been moved to archive as ... \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
          }
          this.File = (FileInfo) null;
          this.txtExcelFile.Text = "";
          this.pbStatus.Value = this.pbStatus.Maximum;
          this.btnFindExcelFile.Enabled = true;
          this.btnImport.Enabled = true;
          this.pbStatus.Value = 0;
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void FindSupplier()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Supplier = App.DB.Supplier.Supplier_Get(integer);
    }

    private void ValidateAllRecords()
    {
      this.lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.WaitCursor;
      int num = (int) Enum.GetValues(typeof (Enums.PartValidationResults)).Cast<Enums.PartValidationResults>().Max<Enums.PartValidationResults>();
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (num + 1);
      App.DB.ImportValidation.Parts_ValidatePreImportData(0, this.chkPFH.Checked);
      this.MoveProgressOn(false);
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetSelectedComboItem_By_Value(ref cboValidateType, "0");
      this.cboValidateType = cboValidateType;
      this.ShowData();
      Cursor.Current = Cursors.Default;
      this.lblMessages.Text = "Validation Complete!";
      this.lblMessages.Visible = true;
    }

    private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("explorer.exe", App.TheSystem.Configuration.DocumentsLocation + "PartsFiles");
    }
  }
}
