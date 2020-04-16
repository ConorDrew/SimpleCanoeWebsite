// Decompiled with JetBrains decompiler
// Type: FSM.FRMPOInvoiceAuthorisation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMPOInvoiceAuthorisation : FRMBaseForm
  {
    private IContainer components;

    public FRMPOInvoiceAuthorisation()
    {
      this.InitializeComponent();
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetUpCombo(ref cboValidateType, DynamicDataTables.POInvoiceAuthorisation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboValidateType = cboValidateType;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tcData { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

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
        EventHandler eventHandler = new EventHandler(this.SelectedIndexChanged);
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

    internal virtual GroupBox grpCatImport { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment
    {
      get
      {
        return this._cboDepartment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.SelectedIndexChanged);
        ComboBox cboDepartment1 = this._cboDepartment;
        if (cboDepartment1 != null)
          cboDepartment1.SelectedIndexChanged -= eventHandler;
        this._cboDepartment = value;
        ComboBox cboDepartment2 = this._cboDepartment;
        if (cboDepartment2 == null)
          return;
        cboDepartment2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.btnExportResults = new Button();
      this.tcData = new TabControl();
      this.btnClose = new Button();
      this.pbStatus = new ProgressBar();
      this.lblProgress = new Label();
      this.lblMessages = new Label();
      this.cboValidateType = new ComboBox();
      this.grpCatImport = new GroupBox();
      this.Label1 = new Label();
      this.cboDepartment = new ComboBox();
      this.grpExcelFile.SuspendLayout();
      this.grpCatImport.SuspendLayout();
      this.SuspendLayout();
      this.grpExcelFile.Controls.Add((Control) this.btnExportResults);
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(231, 57);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Initial Import";
      this.btnExportResults.Location = new System.Drawing.Point(6, 19);
      this.btnExportResults.Name = "btnExportResults";
      this.btnExportResults.Size = new Size(106, 23);
      this.btnExportResults.TabIndex = 5;
      this.btnExportResults.Text = "Export Results";
      this.btnExportResults.UseVisualStyleBackColor = true;
      this.tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcData.Location = new System.Drawing.Point(8, 103);
      this.tcData.Name = "tcData";
      this.tcData.SelectedIndex = 0;
      this.tcData.Size = new Size(1053, 483);
      this.tcData.TabIndex = 8;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.Location = new System.Drawing.Point(1005, 621);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 9;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(8, 621);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(941, 23);
      this.pbStatus.Step = 1;
      this.pbStatus.TabIndex = 10;
      this.lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblProgress.Location = new System.Drawing.Point(957, 624);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new Size(40, 16);
      this.lblProgress.TabIndex = 11;
      this.lblProgress.Text = "0%";
      this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
      this.lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessages.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessages.ForeColor = Color.Red;
      this.lblMessages.Location = new System.Drawing.Point(5, 594);
      this.lblMessages.Name = "lblMessages";
      this.lblMessages.Size = new Size(1057, 19);
      this.lblMessages.TabIndex = 12;
      this.lblMessages.TextAlign = ContentAlignment.MiddleLeft;
      this.lblMessages.Visible = false;
      this.cboValidateType.FormattingEnabled = true;
      this.cboValidateType.Location = new System.Drawing.Point(6, 21);
      this.cboValidateType.Name = "cboValidateType";
      this.cboValidateType.Size = new Size(365, 21);
      this.cboValidateType.TabIndex = 1;
      this.grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCatImport.Controls.Add((Control) this.Label1);
      this.grpCatImport.Controls.Add((Control) this.cboDepartment);
      this.grpCatImport.Controls.Add((Control) this.cboValidateType);
      this.grpCatImport.Location = new System.Drawing.Point(245, 40);
      this.grpCatImport.Name = "grpCatImport";
      this.grpCatImport.Size = new Size(816, 57);
      this.grpCatImport.TabIndex = 6;
      this.grpCatImport.TabStop = false;
      this.grpCatImport.Text = "Category Processing";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(377, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(85, 13);
      this.Label1.TabIndex = 3;
      this.Label1.Text = "Cost Centre :";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.cboDepartment.FormattingEnabled = true;
      this.cboDepartment.Items.AddRange(new object[5]
      {
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5"
      });
      this.cboDepartment.Location = new System.Drawing.Point(467, 21);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(199, 21);
      this.cboDepartment.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1101, 654);
      this.Controls.Add((Control) this.grpCatImport);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.tcData);
      this.Controls.Add((Control) this.grpExcelFile);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMPOInvoiceAuthorisation);
      this.Text = "PO Invoice Authorisation";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.tcData, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.grpCatImport, 0);
      this.grpExcelFile.ResumeLayout(false);
      this.grpCatImport.ResumeLayout(false);
      this.grpCatImport.PerformLayout();
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnExportResults_Click(object sender, EventArgs e)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.Enabled = false;
        string sql = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboDepartment), "", false) != 0 ? "EXEC POInvoiceImport_ExportResultsAuthorisation " + Combo.get_GetSelectedItemValue(this.cboValidateType) + ", " + Combo.get_GetSelectedItemValue(this.cboDepartment) : "EXEC POInvoiceImport_ExportResultsAuthorisation " + Combo.get_GetSelectedItemValue(this.cboValidateType);
        DataView dataView = new DataView(App.DB.ExecuteWithReturn(sql, true));
        if (dataView.Count == 0)
        {
          int num = (int) App.ShowMessage("No Data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
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
          string workSheetNameIn = "POInvoiceAuthExport" + Conversions.ToString(DateAndTime.Today).Replace("/", "");
          Exporting exporting = new Exporting(dataView.Table, workSheetNameIn, "", "", (DataSet) null);
        }
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

    private void SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)), Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboDepartment), "", false) != 0 ? (!App.IsGasway ? Combo.get_GetSelectedItemValue(this.cboDepartment) : Conversions.ToString(Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment)))) : "%");
    }

    public void ShowData(int ValidateType = 0, string Department = null)
    {
      this.tcData.TabPages.Clear();
      TabPage tabPage = new TabPage();
      UCDataPOInvoiceAuthorisation invoiceAuthorisation = new UCDataPOInvoiceAuthorisation();
      invoiceAuthorisation.Dock = DockStyle.Fill;
      invoiceAuthorisation.Data = App.DB.POInvoice.POInvoiceImport_RefreshData(ValidateType, Department);
      invoiceAuthorisation.ValidateType = Combo.get_GetSelectedItemValue(this.cboValidateType);
      invoiceAuthorisation.Department = Combo.get_GetSelectedItemValue(this.cboDepartment);
      tabPage.Text = "PO Invoice Authorisation Data (" + Conversions.ToString(invoiceAuthorisation.Data.Count) + " Records)";
      tabPage.Controls.Add((Control) invoiceAuthorisation);
      this.tcData.TabPages.Add(tabPage);
      this.tcData.SelectedIndex = 0;
      this.MoveProgressOn(true);
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
      Application.DoEvents();
    }
  }
}
