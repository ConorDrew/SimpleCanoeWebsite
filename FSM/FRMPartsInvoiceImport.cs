// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartsInvoiceImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitOrders;
using FSM.Entity.OrderParts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.Sys;
using FSM.Importer;
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMPartsInvoiceImport : FRMBaseForm
  {
    private IContainer components;
    private List<DuplicateInvoice> _duplicateInvoices;

    public FRMPartsInvoiceImport()
    {
      this._duplicateInvoices = new List<DuplicateInvoice>();
      this.InitializeComponent();
      ComboBox cboValidateType = this.cboValidateType;
      Combo.SetUpCombo(ref cboValidateType, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboValidateType = cboValidateType;
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.loggedInUser.Fullname, "Hayleigh Mann", false) <= 0U)
        return;
      this.Button1.Visible = false;
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

    internal virtual LinkLabel btnExportParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCheckFiles
    {
      get
      {
        return this._btnCheckFiles;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCheckFiles_Click);
        Button btnCheckFiles1 = this._btnCheckFiles;
        if (btnCheckFiles1 != null)
          btnCheckFiles1.Click -= eventHandler;
        this._btnCheckFiles = value;
        Button btnCheckFiles2 = this._btnCheckFiles;
        if (btnCheckFiles2 == null)
          return;
        btnCheckFiles2.Click += eventHandler;
      }
    }

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

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.btnExportResults = new Button();
      this.btnCheckFiles = new Button();
      this.tcData = new TabControl();
      this.btnClose = new Button();
      this.pbStatus = new ProgressBar();
      this.lblProgress = new Label();
      this.lblMessages = new Label();
      this.btnExportParts = new LinkLabel();
      this.llOpenFolder = new LinkLabel();
      this.cboValidateType = new ComboBox();
      this.btnProcessIndiv = new Button();
      this.grpCatImport = new GroupBox();
      this.btnValidateResults = new Button();
      this.Button1 = new Button();
      this.grpExcelFile.SuspendLayout();
      this.grpCatImport.SuspendLayout();
      this.SuspendLayout();
      this.grpExcelFile.Controls.Add((Control) this.btnExportResults);
      this.grpExcelFile.Controls.Add((Control) this.btnCheckFiles);
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(231, 57);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Initial Import";
      this.btnExportResults.Location = new System.Drawing.Point(118, 19);
      this.btnExportResults.Name = "btnExportResults";
      this.btnExportResults.Size = new Size(106, 23);
      this.btnExportResults.TabIndex = 5;
      this.btnExportResults.Text = "Export Results";
      this.btnExportResults.UseVisualStyleBackColor = true;
      this.btnCheckFiles.Location = new System.Drawing.Point(6, 20);
      this.btnCheckFiles.Name = "btnCheckFiles";
      this.btnCheckFiles.Size = new Size(106, 23);
      this.btnCheckFiles.TabIndex = 0;
      this.btnCheckFiles.Text = "Check Files";
      this.btnCheckFiles.UseVisualStyleBackColor = true;
      this.tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcData.Location = new System.Drawing.Point(8, 103);
      this.tcData.Name = "tcData";
      this.tcData.SelectedIndex = 0;
      this.tcData.Size = new Size(864, 483);
      this.tcData.TabIndex = 8;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Location = new System.Drawing.Point(816, 621);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 9;
      this.btnClose.Text = "Close";
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(8, 621);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(752, 23);
      this.pbStatus.Step = 1;
      this.pbStatus.TabIndex = 10;
      this.lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblProgress.Location = new System.Drawing.Point(768, 624);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new Size(40, 16);
      this.lblProgress.TabIndex = 11;
      this.lblProgress.Text = "0%";
      this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
      this.lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessages.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessages.ForeColor = Color.Red;
      this.lblMessages.Location = new System.Drawing.Point(5, 594);
      this.lblMessages.Name = "lblMessages";
      this.lblMessages.Size = new Size(868, 19);
      this.lblMessages.TabIndex = 12;
      this.lblMessages.TextAlign = ContentAlignment.MiddleLeft;
      this.lblMessages.Visible = false;
      this.btnExportParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExportParts.Location = new System.Drawing.Point(690, 8);
      this.btnExportParts.Name = "btnExportParts";
      this.btnExportParts.Size = new Size(88, 23);
      this.btnExportParts.TabIndex = 13;
      this.btnExportParts.TabStop = true;
      this.btnExportParts.Text = "Export Parts";
      this.llOpenFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.llOpenFolder.Location = new System.Drawing.Point(575, 8);
      this.llOpenFolder.Name = "llOpenFolder";
      this.llOpenFolder.Size = new Size(88, 23);
      this.llOpenFolder.TabIndex = 14;
      this.llOpenFolder.TabStop = true;
      this.llOpenFolder.Text = "Open Folders";
      this.cboValidateType.FormattingEnabled = true;
      this.cboValidateType.Location = new System.Drawing.Point(6, 21);
      this.cboValidateType.Name = "cboValidateType";
      this.cboValidateType.Size = new Size(365, 21);
      this.cboValidateType.TabIndex = 1;
      this.btnProcessIndiv.Location = new System.Drawing.Point(377, 19);
      this.btnProcessIndiv.Name = "btnProcessIndiv";
      this.btnProcessIndiv.Size = new Size(345, 23);
      this.btnProcessIndiv.TabIndex = 4;
      this.btnProcessIndiv.Text = "Process -->";
      this.btnProcessIndiv.TextAlign = ContentAlignment.MiddleLeft;
      this.btnProcessIndiv.UseVisualStyleBackColor = true;
      this.grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCatImport.Controls.Add((Control) this.btnValidateResults);
      this.grpCatImport.Controls.Add((Control) this.btnProcessIndiv);
      this.grpCatImport.Controls.Add((Control) this.cboValidateType);
      this.grpCatImport.Location = new System.Drawing.Point(245, 40);
      this.grpCatImport.Name = "grpCatImport";
      this.grpCatImport.Size = new Size(627, 57);
      this.grpCatImport.TabIndex = 6;
      this.grpCatImport.TabStop = false;
      this.grpCatImport.Text = "Category Processing";
      this.btnValidateResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnValidateResults.Location = new System.Drawing.Point(499, 19);
      this.btnValidateResults.Name = "btnValidateResults";
      this.btnValidateResults.Size = new Size(122, 23);
      this.btnValidateResults.TabIndex = 6;
      this.btnValidateResults.Text = "Revalidate Results";
      this.btnValidateResults.UseVisualStyleBackColor = true;
      this.Button1.Location = new System.Drawing.Point(403, 3);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(152, 23);
      this.Button1.TabIndex = 15;
      this.Button1.Text = "ValidateOrdersNoParts";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(912, 654);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.grpCatImport);
      this.Controls.Add((Control) this.llOpenFolder);
      this.Controls.Add((Control) this.btnExportParts);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.tcData);
      this.Controls.Add((Control) this.grpExcelFile);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMPartsInvoiceImport);
      this.Text = "(PII) Parts Invoice Import";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.tcData, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.btnExportParts, 0);
      this.Controls.SetChildIndex((Control) this.llOpenFolder, 0);
      this.Controls.SetChildIndex((Control) this.grpCatImport, 0);
      this.Controls.SetChildIndex((Control) this.Button1, 0);
      this.grpExcelFile.ResumeLayout(false);
      this.grpCatImport.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    private List<DuplicateInvoice> DuplicateInvoices
    {
      get
      {
        return this._duplicateInvoices;
      }
      set
      {
        this._duplicateInvoices = value;
      }
    }

    private void cboValidateType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      string Left = Combo.get_GetSelectedItemValue(this.cboValidateType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
        this.btnProcessIndiv.Visible = false;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        this.btnProcessIndiv.Visible = false;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        this.btnProcessIndiv.Visible = false;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.btnProcessIndiv.Visible = true;
        this.btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
      {
        this.btnProcessIndiv.Visible = true;
        this.btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
      {
        this.btnProcessIndiv.Visible = true;
        this.btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(6), false) == 0)
      {
        this.btnProcessIndiv.Visible = true;
        this.btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(7), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Remove Records -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(8), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(9), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Remove Records -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(10), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(14), false) != 0)
          return;
        this.btnProcessIndiv.Visible = false;
      }
    }

    private void btnProcessIndiv_Click(object sender, EventArgs e)
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboValidateType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        this.ValidateOrder(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.MoveProgressOn(true);
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = checked (dataView.Count + 1);
        int num1 = checked (dataView.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          bool flag = true;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["OrderID"].ToString(), "", false) == 0)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nUnable to locate the OrderID for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["Exclude"].ToString(), "True", false) == 0)
            flag = false;
          if (App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString())) == 1)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nSupplier Invoice for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag)
          {
            int orderId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["OrderID"]));
            Order order = App.DB.Order.Order_Get(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString()));
            SupplierInvoice oSupplierInvoice = new SupplierInvoice();
            oSupplierInvoice.SetOrderID = (object) dataView.Table.Rows[index]["OrderID"].ToString();
            oSupplierInvoice.SetInvoiceReference = (object) dataView.Table.Rows[index]["InvoiceNo"].ToString();
            oSupplierInvoice.SetInvoiceDate = (object) dataView.Table.Rows[index]["InvoiceDate"].ToString();
            oSupplierInvoice.SetGoodsAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalGrossAmount"].ToString());
            oSupplierInvoice.SetVATAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalVatAmount"].ToString());
            oSupplierInvoice.SetTotalAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString());
            oSupplierInvoice.SetTaxCodeID = (object) 5373;
            oSupplierInvoice.SetNominalCode = (object) this.GetNominalCode(orderId);
            if (order != null)
            {
              if (order.OrderTypeID == 4)
              {
                DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(order.OrderID);
                if (forSupplierInvoice.Rows.Count > 0)
                {
                  string str = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                  oSupplierInvoice.SetExtraRef = Conversions.ToDouble(str) != 0.0 ? (object) str : (object) ".";
                }
                else
                  oSupplierInvoice.SetExtraRef = (object) ".";
              }
              else
                oSupplierInvoice.SetExtraRef = (object) ".";
            }
            else
              oSupplierInvoice.SetExtraRef = (object) ".";
            oSupplierInvoice.SetReadyToSendToSage = (object) true;
            oSupplierInvoice.SetSentToSage = (object) 0;
            oSupplierInvoice.SetOldSystemInvoice = (object) 0;
            oSupplierInvoice.SetDateExported = (object) null;
            oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
            try
            {
              App.DB.SupplierInvoices.Insert(oSupplierInvoice);
              App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), true);
              bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
              if (boolean)
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
              else
                App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), 7);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            this.MoveProgressOn(false);
          }
          checked { ++index; }
        }
        this.ValidateAllRecords();
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = checked (dataView.Count + 1);
        int num1 = checked (dataView.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          bool flag = true;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["OrderID"].ToString(), "", false) == 0)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nUnable to locate the OrderID for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["Exclude"].ToString(), "True", false) == 0)
            flag = false;
          if (App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString())) == 1)
          {
            flag = false;
            bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
            if (boolean)
              App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nSupplier Invoice for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag)
          {
            int orderId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["OrderID"]));
            Order order = App.DB.Order.Order_Get(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString()));
            SupplierInvoice oSupplierInvoice = new SupplierInvoice();
            oSupplierInvoice.SetOrderID = (object) dataView.Table.Rows[index]["OrderID"].ToString();
            oSupplierInvoice.SetInvoiceReference = (object) dataView.Table.Rows[index]["InvoiceNo"].ToString();
            oSupplierInvoice.SetInvoiceDate = (object) dataView.Table.Rows[index]["InvoiceDate"].ToString();
            oSupplierInvoice.SetGoodsAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalGrossAmount"].ToString());
            oSupplierInvoice.SetVATAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalVatAmount"].ToString());
            oSupplierInvoice.SetTotalAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString());
            oSupplierInvoice.SetTaxCodeID = (object) 5373;
            oSupplierInvoice.SetNominalCode = (object) this.GetNominalCode(orderId);
            if (order != null)
            {
              if (order.OrderTypeID == 4)
              {
                DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(order.OrderID);
                if (forSupplierInvoice.Rows.Count > 0)
                {
                  string str = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                  oSupplierInvoice.SetExtraRef = Conversions.ToDouble(str) != 0.0 ? (object) str : (object) ".";
                }
                else
                  oSupplierInvoice.SetExtraRef = (object) ".";
              }
              else
                oSupplierInvoice.SetExtraRef = (object) ".";
            }
            else
              oSupplierInvoice.SetExtraRef = (object) ".";
            oSupplierInvoice.SetReadyToSendToSage = (object) true;
            oSupplierInvoice.SetSentToSage = (object) 0;
            oSupplierInvoice.SetOldSystemInvoice = (object) 0;
            oSupplierInvoice.SetDateExported = (object) null;
            oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
            try
            {
              App.DB.SupplierInvoices.Insert(oSupplierInvoice);
              App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), true);
              bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
              if (boolean)
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
              else
                App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), 7);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            this.MoveProgressOn(false);
          }
          checked { ++index; }
        }
        this.ValidateAllRecords();
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(6), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = checked (dataView.Count + 1);
        int num1 = checked (dataView.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          bool flag1 = true;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["OrderID"].ToString(), "", false) == 0)
          {
            flag1 = false;
            bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
            if (boolean)
              App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nUnable to locate the OrderID for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["Exclude"].ToString(), "True", false) == 0)
            flag1 = false;
          if (App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString())) == 1)
          {
            flag1 = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nSupplier Invoice for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag1)
          {
            Order order = App.DB.Order.Order_Get(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString()));
            int integer1 = Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString());
            dataView.Table.Rows[index]["InvoiceNo"].ToString();
            dataView.Table.Rows[index]["InvoiceDate"].ToString();
            Conversions.ToString(Convert.ToDouble(dataView.Table.Rows[index]["TotalGrossAmount"].ToString()));
            int TaxCodeID = 5373;
            this.GetNominalCode(integer1);
            string ExtraRef = "";
            if (order != null && order.OrderTypeID == 4)
            {
              DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(order.OrderID);
              if (forSupplierInvoice.Rows.Count > 0)
              {
                ExtraRef = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                if (Conversions.ToDouble(ExtraRef) == 0.0)
                  ExtraRef = "";
              }
            }
            PartsToBeCredited partsToBeCredited = new PartsToBeCredited();
            PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited();
            oPartsToBeCredited.SetOrderID = (object) integer1;
            oPartsToBeCredited.SetOrderReference = (object) App.DB.Order.Order_Get(integer1).OrderReference;
            int integer2 = Conversions.ToInteger(App.DB.Order.Order_Get(integer1).DepartmentRef);
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = App.DB.ExecuteWithReturn("Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '" + dataView.Table.Rows[index]["InvoiceNo"].ToString() + "'", true);
            bool flag2 = true;
            IEnumerator enumerator;
            try
            {
              enumerator = dataTable2.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                Part forCodeAndSupplier = App.DB.Part.Part_Get_For_Code_And_Supplier(Conversions.ToString(current["SupplierPartCode"]), Conversions.ToInteger(dataView.Table.Rows[index]["SupplierID"]));
                int num2 = forCodeAndSupplier != null ? forCodeAndSupplier.SPartID : -1;
                DataTable dataTable3 = App.DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " + Conversions.ToString(integer1) + " AND PartSupplierID = " + Conversions.ToString(num2), true);
                if (dataTable3.Rows.Count > 0)
                {
                  flag2 = false;
                  oPartsToBeCredited.SetPartID = (object) forCodeAndSupplier.PartID;
                  oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                  oPartsToBeCredited.SetCreditReceived = (object) Conversions.ToDouble(current["NetAmount"].ToString().Replace("-", ""));
                  oPartsToBeCredited.SetStatusID = (object) 3;
                  oPartsToBeCredited.SetSupplierID = RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["SupplierID"]);
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
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (flag2)
            {
              DataTable dataTable3 = App.DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " + Conversions.ToString(integer1), true);
              int integer3 = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select Top (1) PartID From tblPartSupplier Where PartSupplierID = ", dataTable3.Rows[0]["PartSupplierID"])), true, false));
              oPartsToBeCredited.SetPartID = (object) integer3;
              oPartsToBeCredited.SetQty = (object) 1;
              oPartsToBeCredited.SetCreditReceived = (object) Conversions.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString().Replace("-", ""));
              oPartsToBeCredited.SetStatusID = (object) 3;
              oPartsToBeCredited.SetSupplierID = RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["SupplierID"]);
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
              int num2 = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dataView.Table.Rows[index]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", Conversions.ToString(integer2), ExtraRef, dataView.Table.Rows[index]["InvoiceNo"].ToString());
              App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + Conversions.ToString(num2) + "," + Conversions.ToString(oPartsToBeCredited.PartsToBeCreditedID) + ")", true, false);
            }
            else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PartCreditsID"])))
            {
              int num2 = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dataView.Table.Rows[index]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", Conversions.ToString(integer2), ExtraRef, dataView.Table.Rows[index]["InvoiceNo"].ToString());
              App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + Conversions.ToString(num2) + "," + Conversions.ToString(oPartsToBeCredited.PartsToBeCreditedID) + ")", true, false);
            }
            else
              App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dataTable1.Rows[0]["PartCreditsID"]), Conversions.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dataView.Table.Rows[index]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", Conversions.ToString(integer2), ExtraRef, dataView.Table.Rows[index]["InvoiceNo"].ToString());
            App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), true);
            this.MoveProgressOn(false);
          }
          checked { ++index; }
        }
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = checked (dataView.Count + 1);
        int num1 = checked (dataView.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          bool flag = true;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["OrderID"].ToString(), "", false) == 0)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nUnable to locate the OrderID for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["Exclude"].ToString(), "True", false) == 0)
            flag = false;
          if (App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString())) == 1)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nSupplier Invoice for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag)
          {
            int orderId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["OrderID"]));
            Order order = App.DB.Order.Order_Get(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString()));
            SupplierInvoice oSupplierInvoice = new SupplierInvoice();
            oSupplierInvoice.SetOrderID = (object) dataView.Table.Rows[index]["OrderID"].ToString();
            oSupplierInvoice.SetInvoiceReference = (object) dataView.Table.Rows[index]["InvoiceNo"].ToString();
            oSupplierInvoice.SetInvoiceDate = (object) dataView.Table.Rows[index]["InvoiceDate"].ToString();
            oSupplierInvoice.SetGoodsAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalGrossAmount"].ToString());
            oSupplierInvoice.SetVATAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalVatAmount"].ToString());
            oSupplierInvoice.SetTotalAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString());
            oSupplierInvoice.SetTaxCodeID = (object) 5373;
            oSupplierInvoice.SetNominalCode = (object) this.GetNominalCode(orderId);
            if (order != null)
            {
              if (order.OrderTypeID == 4)
              {
                DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(order.OrderID);
                if (forSupplierInvoice.Rows.Count > 0)
                {
                  string str = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                  oSupplierInvoice.SetExtraRef = Conversions.ToDouble(str) != 0.0 ? (object) str : (object) ".";
                }
                else
                  oSupplierInvoice.SetExtraRef = (object) ".";
              }
              else
                oSupplierInvoice.SetExtraRef = (object) ".";
            }
            else
              oSupplierInvoice.SetExtraRef = (object) ".";
            oSupplierInvoice.SetReadyToSendToSage = (object) true;
            oSupplierInvoice.SetSentToSage = (object) 0;
            oSupplierInvoice.SetOldSystemInvoice = (object) 0;
            oSupplierInvoice.SetDateExported = (object) null;
            oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
            try
            {
              App.DB.SupplierInvoices.Insert(oSupplierInvoice);
              App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), true);
              bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
              if (boolean)
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
              else
                App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), 7);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            this.MoveProgressOn(false);
          }
          checked { ++index; }
        }
        this.ValidateAllRecords();
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(7), false) == 0)
      {
        this.btnProcessIndiv.Visible = false;
        this.btnProcessIndiv.Text = "Remove Records -->";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(8), false) == 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DataView dataView = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        this.pbStatus.Value = 0;
        this.pbStatus.Maximum = checked (dataView.Count + 1);
        int num1 = checked (dataView.Count - 1);
        int index = 0;
        while (index <= num1)
        {
          bool flag = true;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["OrderID"].ToString(), "", false) == 0)
          {
            flag = false;
            bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
            if (boolean)
              App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nUnable to locate the OrderID for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Rows[index]["Exclude"].ToString(), "True", false) == 0)
            flag = false;
          if (App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString())) == 1)
          {
            flag = false;
            int num2 = (int) App.ShowMessage("An error has occurred:\r\nSupplier Invoice for PO " + dataView.Table.Rows[index]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.MoveProgressOn(false);
          }
          if (flag)
          {
            int orderId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataView.Table.Rows[index]["OrderID"]));
            Order order = App.DB.Order.Order_Get(Conversions.ToInteger(dataView.Table.Rows[index]["OrderID"].ToString()));
            SupplierInvoice oSupplierInvoice = new SupplierInvoice();
            oSupplierInvoice.SetOrderID = (object) dataView.Table.Rows[index]["OrderID"].ToString();
            oSupplierInvoice.SetInvoiceReference = (object) dataView.Table.Rows[index]["InvoiceNo"].ToString();
            oSupplierInvoice.SetInvoiceDate = (object) dataView.Table.Rows[index]["InvoiceDate"].ToString();
            oSupplierInvoice.SetGoodsAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalGrossAmount"].ToString());
            oSupplierInvoice.SetVATAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalVatAmount"].ToString());
            oSupplierInvoice.SetTotalAmount = (object) Convert.ToDouble(dataView.Table.Rows[index]["TotalNetAmount"].ToString());
            oSupplierInvoice.SetTaxCodeID = (object) 5373;
            oSupplierInvoice.SetNominalCode = (object) this.GetNominalCode(orderId);
            if (order != null)
            {
              if (order.OrderTypeID == 4)
              {
                DataTable forSupplierInvoice = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(order.OrderID);
                if (forSupplierInvoice.Rows.Count > 0)
                {
                  string str = Conversions.ToString(forSupplierInvoice.Rows[0]["ChargeNominalCode"]);
                  oSupplierInvoice.SetExtraRef = Conversions.ToDouble(str) != 0.0 ? (object) str : (object) ".";
                }
                else
                  oSupplierInvoice.SetExtraRef = (object) ".";
              }
              else
                oSupplierInvoice.SetExtraRef = (object) ".";
            }
            else
              oSupplierInvoice.SetExtraRef = (object) ".";
            oSupplierInvoice.SetReadyToSendToSage = (object) true;
            oSupplierInvoice.SetSentToSage = (object) 0;
            oSupplierInvoice.SetOldSystemInvoice = (object) 0;
            oSupplierInvoice.SetDateExported = (object) null;
            oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
            try
            {
              App.DB.SupplierInvoices.Insert(oSupplierInvoice);
              App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), true);
              bool boolean = Conversions.ToBoolean(dataView.Table.Rows[index]["RequiresAuthorisation"].ToString());
              if (boolean)
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), boolean);
              else
                App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dataView.Table.Rows[index]["ID"].ToString()), 7);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            this.MoveProgressOn(false);
          }
          checked { ++index; }
        }
        this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
        Cursor.Current = Cursors.Default;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(9), false) != 0)
        ;
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

    public void ValidateCurrentlyDisplayedRecords()
    {
      this.lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.WaitCursor;
      App.DB.ImportValidation.POInvoiceImport_ValidateOrders(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      this.ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboValidateType)));
      this.lblMessages.Text = "Validation complete.";
      this.lblMessages.Visible = true;
      Cursor.Current = Cursors.Default;
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

    private void btnCheckFiles_Click(object sender, EventArgs e)
    {
      this.lblMessages.Text = "Starting import...";
      this.lblMessages.Visible = true;
      this.DuplicateInvoices.Clear();
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = 1;
      this.PreImportData();
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
      this.DuplicateInvoices.Clear();
      Cursor.Current = Cursors.Default;
    }

    private void PreImportData()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("FolderPath");
      dataTable.Columns.Add("FriendlyName");
      dataTable.Columns.Add("SupplierID");
      dataTable.Rows.Add((object) (App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\NHC\\"), (object) "NorwichHeatingComponents", (object) "21");
      dataTable.Rows.Add((object) (App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\PTS\\"), (object) "PTS", (object) "20");
      dataTable.Rows.Add((object) (App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\PartsCenter\\"), (object) "PartsCenter", (object) "22");
      dataTable.Rows.Add((object) (App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\Plumbase\\"), (object) "Plumbase", (object) "58");
      dataTable.Rows.Add((object) (App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\CPS\\"), (object) "CPS", (object) "20");
      int num1 = 0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = dataTable.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          FileInfo[] files = new DirectoryInfo(Conversions.ToString(current["FolderPath"])).GetFiles();
          int index = 0;
          while (index < files.Length)
          {
            FileInfo fileInfo = files[index];
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xls", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xlsx", false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
              instance.DisplayAlerts = false;
              // ISSUE: reference to a compiler-generated method
              instance.Workbooks.Add((object) fileInfo.FullName);
              // ISSUE: variable of a compiler-generated type
              Worksheet worksheet = (Worksheet) instance.Worksheets[(object) 1];
              string cmdText = " SELECT * FROM [" + worksheet.Name + "$]";
              string connectionString = "";
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.Trim().ToLower(), ".xls".ToLower(), false) == 0)
                connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileInfo.FullName + " ; Extended Properties=Excel 8.0; ";
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.Trim().ToLower(), ".xlsx".ToLower(), false) == 0)
                connectionString = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + fileInfo.FullName + " ; Extended Properties=Excel 12.0; ";
              OleDbConnection connection = new OleDbConnection(connectionString);
              OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
              DataSet dataSet = new DataSet();
              oleDbDataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
              dataSet.Clear();
              oleDbDataAdapter.Fill(dataSet);
              checked { ++num1; }
              ProgressBar pbStatus;
              int num2 = checked ((pbStatus = this.pbStatus).Maximum + dataSet.Tables[0].Rows.Count);
              pbStatus.Maximum = num2;
            }
            else
              File.Move(fileInfo.FullName, Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["FolderPath"], (object) "\\Failed\\"), (object) fileInfo.Name)));
            checked { ++index; }
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      int num3 = 0;
      IEnumerator enumerator2;
      try
      {
        enumerator2 = dataTable.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          FileInfo[] files = new DirectoryInfo(Conversions.ToString(current["FolderPath"])).GetFiles();
          int index1 = 0;
          while (index1 < files.Length)
          {
            FileInfo fileInfo = files[index1];
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xls", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xlsx", false) == 0)
            {
              checked { ++num3; }
              int num2 = 0;
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
              instance.DisplayAlerts = false;
              // ISSUE: reference to a compiler-generated method
              instance.Workbooks.Add((object) fileInfo.FullName);
              // ISSUE: variable of a compiler-generated type
              Worksheet worksheet = (Worksheet) instance.Worksheets[(object) 1];
              string cmdText = " SELECT * FROM [" + worksheet.Name + "$]";
              string connectionString = "";
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.Trim().ToLower(), ".xls".ToLower(), false) == 0)
                connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileInfo.FullName + " ; Extended Properties=Excel 8.0; ";
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.Trim().ToLower(), ".xlsx".ToLower(), false) == 0)
                connectionString = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + fileInfo.FullName + " ; Extended Properties=Excel 12.0; ";
              OleDbConnection connection = new OleDbConnection(connectionString);
              OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
              DataSet dataSet = new DataSet();
              string Left1 = current["FriendlyName"].ToString();
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "PartsCenter", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "NorwichHeatingComponents", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "CPS", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "PTS", false) == 0)
                {
                  dataSet.Tables.Add();
                  dataSet.Tables[0].Columns.Add(new DataColumn("Keyword")
                  {
                    DataType = System.Type.GetType("System.String")
                  });
                }
                else
                {
                  dataSet.Tables.Add();
                  dataSet.Tables[0].Columns.Add(new DataColumn("Keyword")
                  {
                    DataType = System.Type.GetType("System.String")
                  });
                }
              }
              else
              {
                dataSet.Tables.Add();
                dataSet.Tables[0].Columns.Add(new DataColumn("Product Code")
                {
                  DataType = System.Type.GetType("System.String")
                });
              }
              oleDbDataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
              dataSet.Clear();
              oleDbDataAdapter.Fill(dataSet.Tables[0]);
              DataView dataView = new DataView(dataSet.Tables[0]);
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current["FriendlyName"].ToString(), "PartsCenter", false) == 0)
                dataView.Sort = "Customer Order Number";
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current["FriendlyName"].ToString(), "NorwichHeatingComponents", false) == 0)
                dataView.Sort = "Gasway Order No";
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current["FriendlyName"].ToString(), "PTS", false) == 0)
                dataView.Sort = "Your Order";
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current["FriendlyName"].ToString(), "CPS", false) == 0)
              {
                if (dataView.Table.Columns.Contains("Customer Order Number"))
                  dataView.Sort = "Customer Order Number";
                if (dataView.Table.Columns.Contains("Customer_Order_Number"))
                  dataView.Sort = "Customer_Order_Number";
              }
              else
                dataView.Sort = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current["FriendlyName"].ToString(), "Plumbase", false) != 0 ? "Your Order" : "Customer Order No (Hr)";
              dataSet.Tables.Clear();
              dataSet.Tables.Add(dataView.ToTable());
              string[] var1 = new string[5001];
              string[] var2 = new string[5001];
              int num4 = 0;
              int TotalQtyOfParts = 0;
              double num5 = 0.0;
              double num6 = 0.0;
              double num7 = 0.0;
              double num8 = 0.0;
              bool flag1 = false;
              bool flag2 = false;
              int ImportID = 0;
              int num9 = checked (dataSet.Tables[0].Rows.Count - 1);
              int index2 = 0;
              while (index2 <= num9)
              {
                int integer = Conversions.ToInteger(current["SupplierID"]);
                string str1 = (string) null;
                string str2 = (string) null;
                string str3 = (string) null;
                string str4 = (string) null;
                string str5 = (string) null;
                string OrderType = (string) null;
                string SupplierPartCode = (string) null;
                string Description = "Unspecified";
                int num10 = 0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                bool flag3 = true;
                DataRow row = dataSet.Tables[0].Rows[index2];
                string Left2 = current["FriendlyName"].ToString();
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "NorwichHeatingComponents", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "PartsCenter", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "PTS", false) != 0)
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Plumbase", false) != 0)
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "CPS", false) == 0)
                        {
                          if (row.Table.Columns.Contains("Customer Order Number"))
                          {
                            if (row["Customer Order Number"] == DBNull.Value)
                            {
                              flag3 = false;
                              str3 = "Unspecified";
                            }
                            else
                              str3 = Strings.Trim(Conversions.ToString(row["Customer Order Number"]));
                          }
                          if (row.Table.Columns.Contains("Customer_Order_Number"))
                          {
                            if (row["Customer_Order_Number"] == DBNull.Value)
                            {
                              flag3 = false;
                              str3 = "Unspecified";
                            }
                            else
                              str3 = Strings.Trim(Conversions.ToString(row["Customer_Order_Number"]));
                          }
                          if (row.Table.Columns.Contains("Invoice Number"))
                          {
                            if (row["Invoice Number"] == DBNull.Value)
                            {
                              flag3 = false;
                              str1 = "Unspecified";
                            }
                            else
                              str1 = Strings.Trim(Conversions.ToString(row["Invoice Number"]));
                          }
                          if (row.Table.Columns.Contains("Invoice_Number"))
                          {
                            if (row["Invoice_Number"] == DBNull.Value)
                            {
                              flag3 = false;
                              str1 = "Unspecified";
                            }
                            else
                              str1 = Strings.Trim(Conversions.ToString(row["Invoice_Number"]));
                          }
                          if (row.Table.Columns.Contains("Product Code"))
                          {
                            if (row["Product Code"] == DBNull.Value)
                            {
                              flag3 = false;
                              SupplierPartCode = "Unspecified";
                            }
                            else
                              SupplierPartCode = Strings.Trim(Conversions.ToString(row["Product Code"]));
                          }
                          if (row.Table.Columns.Contains("Product_Code"))
                          {
                            if (row["Product_Code"] == DBNull.Value)
                            {
                              flag3 = false;
                              SupplierPartCode = "Unspecified";
                            }
                            else
                              SupplierPartCode = Strings.Trim(Conversions.ToString(row["Product_Code"]));
                          }
                          if (row.Table.Columns.Contains("Invoice Date"))
                            str2 = row["Invoice Date"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice Date"])) : "Unspecified";
                          if (row.Table.Columns.Contains("Invoice_Date"))
                            str2 = row["Invoice_Date"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice_Date"])) : "Unspecified";
                          if (row.Table.Columns.Contains("Product Description"))
                            Description = row["Product Description"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Product Description"])) : "Unspecified";
                          if (row.Table.Columns.Contains("Product_Description"))
                            Description = row["Product_Description"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Product_Description"])) : "Unspecified";
                          if (flag3)
                          {
                            OrderType = "Unspecified";
                            str4 = "Unspecified";
                            str5 = "Unspecified";
                            if (row.Table.Columns.Contains("Sales Quantity"))
                            {
                              if (row["Sales Quantity"] == DBNull.Value)
                              {
                                num10 = 0;
                              }
                              else
                              {
                                num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Sales Quantity"])));
                                checked { TotalQtyOfParts += num10; }
                              }
                            }
                            if (row.Table.Columns.Contains("Sales_Quantity"))
                            {
                              if (row["Sales_Quantity"] == DBNull.Value)
                              {
                                num10 = 0;
                              }
                              else
                              {
                                num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Sales_Quantity"])));
                                checked { TotalQtyOfParts += num10; }
                              }
                            }
                            if (row.Table.Columns.Contains("Price Per Item"))
                            {
                              if (row["Price Per Item"] == DBNull.Value)
                              {
                                num11 = 0.0;
                              }
                              else
                              {
                                num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Price Per Item"])));
                                num5 += num11;
                              }
                            }
                            if (row.Table.Columns.Contains("Price_Per_Item"))
                            {
                              if (row["Price_Per_Item"] == DBNull.Value)
                              {
                                num11 = 0.0;
                              }
                              else
                              {
                                num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Price_Per_Item"])));
                                num5 += num11;
                              }
                            }
                            if (row.Table.Columns.Contains("Sales Value"))
                            {
                              if (row["Sales Value"] == DBNull.Value)
                              {
                                num12 = 0.0;
                              }
                              else
                              {
                                num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Sales Value"])));
                                num6 += num12;
                              }
                            }
                            if (row.Table.Columns.Contains("Sales_Value"))
                            {
                              if (row["Sales_Value"] == DBNull.Value)
                              {
                                num12 = 0.0;
                              }
                              else
                              {
                                num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Sales_Value"])));
                                num6 += num12;
                              }
                            }
                            if (row.Table.Columns.Contains("Sales VAT Value"))
                            {
                              if (row["Sales VAT Value"] == DBNull.Value)
                              {
                                num13 = 0.0;
                              }
                              else
                              {
                                num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Sales VAT Value"])));
                                num7 += num13;
                              }
                            }
                            if (row.Table.Columns.Contains("Sales_Vat_Value"))
                            {
                              if (row["Sales_Vat_Value"] == DBNull.Value)
                              {
                                num13 = 0.0;
                              }
                              else
                              {
                                num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Sales_Vat_Value"])));
                                num7 += num13;
                              }
                            }
                            num14 = num12 + num13;
                            num8 += num14;
                          }
                        }
                      }
                      else
                      {
                        if (row["Customer Order No (Hr)"] == DBNull.Value)
                          flag3 = false;
                        if (row["Invoice"] == DBNull.Value)
                          flag3 = false;
                        if (row["Part Number (Li)"] == DBNull.Value)
                          flag3 = false;
                        str1 = row["Invoice"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice"])) : "Unspecified";
                        str2 = row["Invoice Date (Li)"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice Date (Li)"])) : "01/01/1900";
                        str3 = row["Customer Order No (Hr)"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Customer Order No (Hr)"])) : "Unspecified";
                        SupplierPartCode = row["Part Number (Li)"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Part Number (Li)"])) : "Unspecified";
                        Description = row["Full Description (Li)"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Full Description (Li)"])) : "Unspecified";
                        if (flag3)
                        {
                          OrderType = "Unspecified";
                          str4 = "Unspecified";
                          str5 = "Unspecified";
                          if (row["Quantity"] == DBNull.Value)
                          {
                            num10 = 0;
                          }
                          else
                          {
                            num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Quantity"])));
                            checked { TotalQtyOfParts += num10; }
                          }
                          if (row["Price"] == DBNull.Value)
                          {
                            num11 = 0.0;
                          }
                          else
                          {
                            num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Price"])));
                            num5 += num11;
                          }
                          if (row["Goods"] == DBNull.Value)
                          {
                            num12 = 0.0;
                          }
                          else
                          {
                            num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Goods"])));
                            num6 += num12;
                          }
                          if (row["VAT"] == DBNull.Value)
                          {
                            num13 = 0.0;
                          }
                          else
                          {
                            num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["VAT"])));
                            num7 += num13;
                          }
                          num14 = num12 + num13;
                          num8 += num14;
                        }
                      }
                    }
                    else
                    {
                      if (row["Your Order"] == DBNull.Value)
                        flag3 = false;
                      if (row["InvNo"] == DBNull.Value)
                        flag3 = false;
                      if (row["Keyword"] == DBNull.Value)
                        flag3 = false;
                      str1 = row["INVNO"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["INVNO"])) : "Unspecified";
                      str2 = row["Date"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Date"])) : "01/01/1900";
                      str3 = row["Your Order"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Your Order"])) : "Unspecified";
                      SupplierPartCode = row["Keyword"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Keyword"])) : "Unspecified";
                      Description = row["Description"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Description"])) : "Unspecified";
                      if (flag3)
                      {
                        OrderType = "Unspecified";
                        str4 = "Unspecified";
                        str5 = "Unspecified";
                        if (row["Invoiced"] == DBNull.Value)
                        {
                          num10 = 0;
                        }
                        else
                        {
                          num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Invoiced"])));
                          checked { TotalQtyOfParts += num10; }
                        }
                        if (row["Cost"] == DBNull.Value)
                        {
                          num11 = 0.0;
                        }
                        else
                        {
                          num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Cost"])));
                          num5 += num11;
                        }
                        if (row["Value"] == DBNull.Value)
                        {
                          num12 = 0.0;
                        }
                        else
                        {
                          num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Value"])));
                          num6 += num12;
                        }
                        if (row["VAT Value"] == DBNull.Value)
                        {
                          num13 = 0.0;
                        }
                        else
                        {
                          num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["VAT Value"])));
                          num7 += num13;
                        }
                        num14 = num12 + num13;
                        num8 += num14;
                      }
                    }
                  }
                  else
                  {
                    if (row["Customer Order Number"] == DBNull.Value)
                      flag3 = false;
                    if (row["Product Code"] == DBNull.Value)
                      flag3 = false;
                    if (row["Invoice Number"] == DBNull.Value)
                      flag3 = false;
                    str1 = row["Invoice Number"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice Number"])) : "Unspecified";
                    str2 = row["Invoice Date"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Invoice Date"])) : "01/01/1900";
                    str3 = row["Customer Order Number"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Customer Order Number"])) : "Unspecified";
                    SupplierPartCode = Strings.Trim(row["Product Code"].ToString());
                    Description = row["Product Description"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Product Description"])) : "Unspecified";
                    if (flag3)
                    {
                      OrderType = "Unspecified";
                      str4 = "Unspecified";
                      str5 = "Unspecified";
                      if (row["Line Qty"] == DBNull.Value)
                      {
                        num10 = 0;
                      }
                      else
                      {
                        num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Line Qty"])));
                        checked { TotalQtyOfParts += num10; }
                      }
                      if (row["Unit Price"] == DBNull.Value)
                      {
                        num11 = 0.0;
                      }
                      else
                      {
                        num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Unit Price"])));
                        num5 += num11;
                      }
                      if (row["Line Nett Value"] == DBNull.Value)
                      {
                        num12 = 0.0;
                      }
                      else
                      {
                        num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Line Nett Value"])));
                        num6 += num12;
                      }
                      if (row["Line VAT Amount"] == DBNull.Value)
                      {
                        num13 = 0.0;
                      }
                      else
                      {
                        num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Line VAT Amount"])));
                        num7 += num13;
                      }
                      if (row["Line Gross Value"] == DBNull.Value)
                      {
                        num14 = 0.0;
                      }
                      else
                      {
                        num14 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Line Gross Value"])));
                        num8 += num14;
                      }
                    }
                  }
                }
                else
                {
                  if (row["Gasway Order No"] == DBNull.Value)
                    flag3 = false;
                  if (row["Number"] == DBNull.Value)
                    flag3 = false;
                  if (row["Product Code"] == DBNull.Value)
                    flag3 = false;
                  str1 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Number"])) ? Strings.Trim(Conversions.ToString(row["Number"])) : "Unspecified";
                  str2 = row["Date"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Date"])) : "01/01/1900";
                  str3 = row["Gasway Order No"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Gasway Order No"])) : "Unspecified";
                  SupplierPartCode = row["Product Code"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Product Code"])) : "Unspecified";
                  Description = row["Description"] != DBNull.Value ? Strings.Trim(Conversions.ToString(row["Description"])) : "Unspecified";
                  if (flag3)
                  {
                    OrderType = "Unspecified";
                    if (row["Quantity"] == DBNull.Value)
                    {
                      num10 = 0;
                    }
                    else
                    {
                      num10 = Conversions.ToInteger(Strings.Trim(Conversions.ToString(row["Quantity"])));
                      checked { TotalQtyOfParts += num10; }
                    }
                    if (row["Net Price"] == DBNull.Value)
                    {
                      num11 = 0.0;
                    }
                    else
                    {
                      num11 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Net Price"])));
                      num5 += num11;
                    }
                    if (row["Net Amount"] == DBNull.Value)
                    {
                      num12 = 0.0;
                    }
                    else
                    {
                      num12 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Net Amount"])));
                      num6 += num12;
                    }
                    if (row["Tax Amount"] == DBNull.Value)
                    {
                      num13 = 0.0;
                    }
                    else
                    {
                      num13 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Tax Amount"])));
                      num7 += num13;
                    }
                    if (row["Gross Amount"] == DBNull.Value)
                    {
                      num14 = 0.0;
                    }
                    else
                    {
                      num14 = Conversions.ToDouble(Strings.Trim(Conversions.ToString(row["Gross Amount"])));
                      num8 += num14;
                    }
                  }
                }
                try
                {
                  if (App.DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(str1, Conversions.ToDate(str2), SupplierPartCode) > 0)
                  {
                    this.MoveProgressOn(false);
                    goto label_230;
                  }
                  else
                  {
                    if (App.DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(str1, Conversions.ToDate(str2), SupplierPartCode) > 0)
                    {
                      flag3 = false;
                      this.DuplicateInvoices.Add(new DuplicateInvoice()
                      {
                        PurchaseOrderNo = str3,
                        SupplierPartCode = SupplierPartCode,
                        Description = Description,
                        Quantity = num10,
                        UnitPrice = num11,
                        NetAmount = num12,
                        VATAmount = num13,
                        GrossAmount = num14,
                        InvoiceNo = str1,
                        InvoiceDate = str2,
                        SupplierID = integer,
                        TotalQtyOfParts = TotalQtyOfParts
                      });
                    }
                    if (flag3)
                    {
                      if (!this.checkArray(var1, str3) | this.checkArray(var1, str3) & !this.checkArray(var2, str1))
                      {
                        num4 = 0;
                        TotalQtyOfParts = 0;
                        num8 = 0.0;
                        num6 = 0.0;
                        num5 = 0.0;
                        num7 = 0.0;
                        ImportID = App.DB.ImportValidation.POInvoiceImport_InsertOrder(str1, Conversions.ToDate(str2), str3, integer, OrderType, (string) null);
                        var1[index2] = str3;
                        var2[index2] = str1;
                        flag1 = false;
                        flag2 = true;
                      }
                      else
                        flag2 = false;
                      checked { ++num4; }
                      App.DB.ImportValidation.POInvoiceImport_InsertPart(str3, SupplierPartCode, Description, num10, num11, num12, num13, num14, str1);
                      App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(str3, num10, num11, num12, num13, num14, TotalQtyOfParts, str1);
                      if (ImportID > 0)
                        App.DB.ImportValidation.POInvoiceImport_ValidateOrder(ImportID);
                    }
                    if (flag3)
                    {
                      checked { ++num2; }
                      this.lblMessages.Text = "Adding part " + Conversions.ToString(num2) + " of " + Conversions.ToString(dataSet.Tables[0].Rows.Count) + " from file " + Conversions.ToString(num3) + " of " + Conversions.ToString(num1) + ".";
                      this.lblMessages.Visible = true;
                    }
                    this.MoveProgressOn(false);
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
label_230:
                checked { ++index2; }
              }
              try
              {
                File.Move(fileInfo.FullName, Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["FolderPath"], (object) "\\Processed\\"), (object) fileInfo.Name)));
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
            }
            checked { ++index1; }
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.MoveProgressOn(true);
    }

    private void ValidateOrdersWithNoParts()
    {
      Cursor.Current = Cursors.WaitCursor;
      DataView ordersWithNoParts = App.DB.ImportValidation.POInvoiceImport_GetOrdersWithNoParts(8);
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (ordersWithNoParts.Count + 1);
      int num1 = checked (ordersWithNoParts.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        DataView poParts = App.DB.ImportValidation.POInvoiceImport_GetPOParts(ordersWithNoParts.Table.Rows[index1][3].ToString(), ordersWithNoParts.Table.Rows[index1][1].ToString());
        if ((uint) poParts.Count > 0U)
        {
          int num2 = 0;
          int num3 = checked (poParts.Count - 1);
          int index2 = 0;
          while (index2 <= num3)
          {
            if (Conversions.ToInteger(poParts.Table.Rows[index2][3].ToString()) < 0)
              App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(poParts.Table.Rows[index2][9].ToString()), true);
            else if (Conversions.ToInteger(poParts.Table.Rows[index2][3].ToString()) == 0)
              App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(poParts.Table.Rows[index2][9].ToString()), true);
            else if (App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][4].ToString()), poParts.Table.Rows[index2][1].ToString()) == 1)
            {
              App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(poParts.Table.Rows[index2][9].ToString()), false);
              checked { ++num2; }
            }
            else if (App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][4].ToString()), poParts.Table.Rows[index2][1].ToString()) == 0 | App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][4].ToString()), poParts.Table.Rows[index2][1].ToString()) > 1)
              App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(poParts.Table.Rows[index2][9].ToString()), true);
            checked { ++index2; }
          }
          if (num2 == poParts.Count)
          {
            Order oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][14].ToString()));
            int num4 = checked (poParts.Count - 1);
            int index3 = 0;
            while (index3 <= num4)
            {
              int partId = App.DB.ImportValidation.POInvoiceImport_GetPartID(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][4].ToString()), poParts.Table.Rows[index3][1].ToString());
              Part part = App.DB.Part.Part_Get(partId);
              DataView partIdAndSupplierId = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(partId, Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][4].ToString()));
              if (partIdAndSupplierId.Count != 0)
              {
                if (partIdAndSupplierId.Count == 1)
                {
                  EngineerVisitOrder forOrder = App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(oOrder.OrderID);
                  OrderPart oOrderPart = new OrderPart();
                  oOrderPart.IgnoreExceptionsOnSetMethods = true;
                  oOrderPart.SetOrderID = (object) oOrder.OrderID;
                  oOrderPart.SetPartSupplierID = (object) partIdAndSupplierId.Table.Rows[0][0].ToString();
                  oOrderPart.SetQuantity = (object) poParts.Table.Rows[index3][3].ToString();
                  oOrderPart.SetBuyPrice = (object) partIdAndSupplierId.Table.Rows[0][4].ToString();
                  oOrderPart.SetSellPrice = (object) part.SellPrice;
                  oOrderPart.SetQuantityReceived = (object) poParts.Table.Rows[index3][3].ToString();
                  new OrderPartValidator().Validate(oOrderPart);
                  OrderPart orderPart = App.DB.OrderPart.Insert(oOrderPart, !oOrder.DoNotConsolidated);
                  if (oOrder.OrderTypeID == 4)
                    App.DB.EngineerVisitPartProductAllocated.InsertOne(forOrder.EngineerVisitID, "Part", orderPart.Quantity, orderPart.OrderPartID, partId, 1);
                  oOrder.SetOrderStatusID = (object) 4;
                  App.DB.Order.Update(oOrder);
                }
                else
                {
                  int num5 = (int) App.ShowMessage("Unable to process Part - Multiple Part Supplier Found for Part : " + poParts.Table.Rows[index3][1].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
              }
              checked { ++index3; }
            }
            App.DB.ImportValidation.POInvoiceImport_ValidateOrders(8);
          }
          else
            App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(ordersWithNoParts.Table.Rows[index1][0].ToString()), 12);
        }
        this.MoveProgressOn(false);
        checked { ++index1; }
      }
      this.MoveProgressOn(true);
      Cursor.Current = Cursors.Default;
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
        DataView dataView;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboValidateType)) == 12.0)
        {
          string sql = "EXEC POInvoiceImport_ExportResultsIncPartDetail " + Combo.get_GetSelectedItemValue(this.cboValidateType);
          dataView = new DataView(App.DB.ExecuteWithReturn(sql, true));
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
        }
        else
        {
          string sql = "EXEC POInvoiceImport_ExportResults " + Combo.get_GetSelectedItemValue(this.cboValidateType);
          dataView = new DataView(App.DB.ExecuteWithReturn(sql, true));
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
        }
        string Expression = Strings.Trim(Combo.get_GetSelectedItemDescription(this.cboValidateType)).Replace("(", "").Replace(")", "").Replace(" ", "");
        if (Strings.Len(Expression) >= 23)
          Expression = Expression.Substring(0, 23);
        string workSheetNameIn = Expression + Conversions.ToString(DateAndTime.Today).Replace("/", "");
        Exporting exporting = new Exporting(dataView.Table, workSheetNameIn, "", "", (DataSet) null);
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

    private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("explorer.exe", App.TheSystem.Configuration.DocumentsLocation + "PartsInvoiceFiles\\");
    }

    private void btnValidateResults_Click(object sender, EventArgs e)
    {
      this.ValidateAllRecords();
    }

    public bool checkArray(string[] var, string Text)
    {
      return Array.IndexOf<string>(var, Text) > -1;
    }

    public void ShowData(int ValidateType = 0)
    {
      this.tcData.TabPages.Clear();
      TabPage tabPage = new TabPage();
      UCDataPartsInvoiceImport partsInvoiceImport = new UCDataPartsInvoiceImport();
      partsInvoiceImport.Dock = DockStyle.Fill;
      partsInvoiceImport.Data = App.DB.ImportValidation.POInvoiceImport_ShowData(ValidateType);
      partsInvoiceImport.ValidateType = Combo.get_GetSelectedItemValue(this.cboValidateType);
      tabPage.Text = "PO Invoice Import Data (" + Conversions.ToString(partsInvoiceImport.Data.Count) + " Records)";
      tabPage.Controls.Add((Control) partsInvoiceImport);
      this.tcData.TabPages.Add(tabPage);
      this.tcData.SelectedIndex = 0;
      this.MoveProgressOn(true);
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

    private void Button1_Click(object sender, EventArgs e)
    {
      this.ValidateOrdersWithNoParts();
    }

    public int GetNominalCode(int orderId)
    {
      int num1 = 5300;
      DataView job = App.DB.Order.Orders_GetJob(orderId);
      DataTable table = App.DB.Picklists.GetAll(Enums.PickListTypes.PurchaseNominal, false).Table;
      if (job.Table.Rows.Count > 0)
      {
        int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(job[0]["RegionID"]));
        try
        {
          if (num2 != 68517)
            throw new Exception();
          if (table.Select("Name='Gasway Commerical'").Length <= 0)
            throw new Exception();
          DataRow dataRow = table.Select("Name='Gasway Commerical'")[0];
          if (!dataRow.IsNull("Name"))
            num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["Description"]));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          if (table.Select("Name='Standard'").Length > 0)
          {
            DataRow dataRow = table.Select("Name='Standard'")[0];
            if (!dataRow.IsNull("Name"))
              num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["Description"]));
          }
          ProjectData.ClearProjectError();
        }
      }
      return num1;
    }
  }
}
