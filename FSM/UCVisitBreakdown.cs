// Decompiled with JetBrains decompiler
// Type: FSM.UCVisitBreakdown
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCVisitBreakdown : UCBase, IUserControl
  {
    private IContainer components;
    private UCCalloutBreakdown _onControl;
    private EngineerVisit _engineerVisit;
    private DataView _PartsAndProducts;
    private int _PartProductID;
    private string _Type;
    private ArrayList _PartsProductsToRemoveFromOrder;
    private ArrayList _PartsProductsToReallocated;
    private bool _change;

    public UCVisitBreakdown()
    {
      this.Load += new EventHandler(this.UCVisitBreakdown_Load);
      this._onControl = (UCCalloutBreakdown) null;
      this._engineerVisit = (EngineerVisit) null;
      this._PartsAndProducts = (DataView) null;
      this._PartProductID = 0;
      this._Type = string.Empty;
      this._PartsProductsToRemoveFromOrder = new ArrayList();
      this._PartsProductsToReallocated = new ArrayList();
      this._change = false;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotesToEngineer
    {
      get
      {
        return this._txtNotesToEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtNotesToEngineer_TextChanged);
        TextBox txtNotesToEngineer1 = this._txtNotesToEngineer;
        if (txtNotesToEngineer1 != null)
          txtNotesToEngineer1.TextChanged -= eventHandler;
        this._txtNotesToEngineer = value;
        TextBox txtNotesToEngineer2 = this._txtNotesToEngineer;
        if (txtNotesToEngineer2 == null)
          return;
        txtNotesToEngineer2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnView
    {
      get
      {
        return this._btnView;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnView_Click);
        Button btnView1 = this._btnView;
        if (btnView1 != null)
          btnView1.Click -= eventHandler;
        this._btnView = value;
        Button btnView2 = this._btnView;
        if (btnView2 == null)
          return;
        btnView2.Click += eventHandler;
      }
    }

    internal virtual Label lblDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpVisitDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsAndProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxPartsToFit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboExpected { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkRecharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGetOrderRef
    {
      get
      {
        return this._btnGetOrderRef;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGetOrderRef_Click);
        Button btnGetOrderRef1 = this._btnGetOrderRef;
        if (btnGetOrderRef1 != null)
          btnGetOrderRef1.Click -= eventHandler;
        this._btnGetOrderRef = value;
        Button btnGetOrderRef2 = this._btnGetOrderRef;
        if (btnGetOrderRef2 == null)
          return;
        btnGetOrderRef2.Click += eventHandler;
      }
    }

    internal virtual TabPage EstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button BtnEstSave
    {
      get
      {
        return this._BtnEstSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEstSave_Click);
        Button btnEstSave1 = this._BtnEstSave;
        if (btnEstSave1 != null)
          btnEstSave1.Click -= eventHandler;
        this._BtnEstSave = value;
        Button btnEstSave2 = this._BtnEstSave;
        if (btnEstSave2 == null)
          return;
        btnEstSave2.Click += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEstimateVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPassword
    {
      get
      {
        return this._txtPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPassword_TextChanged);
        TextBox txtPassword1 = this._txtPassword;
        if (txtPassword1 != null)
          txtPassword1.TextChanged -= eventHandler;
        this._txtPassword = value;
        TextBox txtPassword2 = this._txtPassword;
        if (txtPassword2 == null)
          return;
        txtPassword2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnMoveParts
    {
      get
      {
        return this._btnMoveParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveParts_Click);
        Button btnMoveParts1 = this._btnMoveParts;
        if (btnMoveParts1 != null)
          btnMoveParts1.Click -= eventHandler;
        this._btnMoveParts = value;
        Button btnMoveParts2 = this._btnMoveParts;
        if (btnMoveParts2 == null)
          return;
        btnMoveParts2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip cmsPrint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem EngineerJobSheetToolStripMenuItem
    {
      get
      {
        return this._EngineerJobSheetToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PrintEngjob);
        ToolStripMenuItem toolStripMenuItem1 = this._EngineerJobSheetToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._EngineerJobSheetToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._EngineerJobSheetToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ProForrmaToolStripMenuItem
    {
      get
      {
        return this._ProForrmaToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ProForrmaToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ProForrmaToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ProForrmaToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ProForrmaToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem btnPrintInstall
    {
      get
      {
        return this._btnPrintInstall;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintInstall_Click);
        ToolStripMenuItem btnPrintInstall1 = this._btnPrintInstall;
        if (btnPrintInstall1 != null)
          btnPrintInstall1.Click -= eventHandler;
        this._btnPrintInstall = value;
        ToolStripMenuItem btnPrintInstall2 = this._btnPrintInstall;
        if (btnPrintInstall2 == null)
          return;
        btnPrintInstall2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem BtnPrintServiceLetter
    {
      get
      {
        return this._BtnPrintServiceLetter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnPrintServiceLetter_Click);
        ToolStripMenuItem printServiceLetter1 = this._BtnPrintServiceLetter;
        if (printServiceLetter1 != null)
          printServiceLetter1.Click -= eventHandler;
        this._BtnPrintServiceLetter = value;
        ToolStripMenuItem printServiceLetter2 = this._BtnPrintServiceLetter;
        if (printServiceLetter2 == null)
          return;
        printServiceLetter2.Click += eventHandler;
      }
    }

    internal virtual Label lblAuthCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGenerateAuthCode
    {
      get
      {
        return this._btnGenerateAuthCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenerateAuthCode_Click);
        Button generateAuthCode1 = this._btnGenerateAuthCode;
        if (generateAuthCode1 != null)
          generateAuthCode1.Click -= eventHandler;
        this._btnGenerateAuthCode = value;
        Button generateAuthCode2 = this._btnGenerateAuthCode;
        if (generateAuthCode2 == null)
          return;
        generateAuthCode2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem btnPrintJobLetter
    {
      get
      {
        return this._btnPrintJobLetter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintJobLetter_Click);
        ToolStripMenuItem btnPrintJobLetter1 = this._btnPrintJobLetter;
        if (btnPrintJobLetter1 != null)
          btnPrintJobLetter1.Click -= eventHandler;
        this._btnPrintJobLetter = value;
        ToolStripMenuItem btnPrintJobLetter2 = this._btnPrintJobLetter;
        if (btnPrintJobLetter2 == null)
          return;
        btnPrintJobLetter2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkSendText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUploadVisit
    {
      get
      {
        return this._btnUploadVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUploadVisit_Click);
        Button btnUploadVisit1 = this._btnUploadVisit;
        if (btnUploadVisit1 != null)
          btnUploadVisit1.Click -= eventHandler;
        this._btnUploadVisit = value;
        Button btnUploadVisit2 = this._btnUploadVisit;
        if (btnUploadVisit2 == null)
          return;
        btnUploadVisit2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem PrintSolarInstall
    {
      get
      {
        return this._PrintSolarInstall;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PrintSolarInstall_Click);
        ToolStripMenuItem printSolarInstall1 = this._PrintSolarInstall;
        if (printSolarInstall1 != null)
          printSolarInstall1.Click -= eventHandler;
        this._PrintSolarInstall = value;
        ToolStripMenuItem printSolarInstall2 = this._PrintSolarInstall;
        if (printSolarInstall2 == null)
          return;
        printSolarInstall2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem PrintElectricalAppointment
    {
      get
      {
        return this._PrintElectricalAppointment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PrintElectricalAppointment_Click);
        ToolStripMenuItem electricalAppointment1 = this._PrintElectricalAppointment;
        if (electricalAppointment1 != null)
          electricalAppointment1.Click -= eventHandler;
        this._PrintElectricalAppointment = value;
        ToolStripMenuItem electricalAppointment2 = this._PrintElectricalAppointment;
        if (electricalAppointment2 == null)
          return;
        electricalAppointment2.Click += eventHandler;
      }
    }

    internal virtual Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        Button btnPrint1 = this._btnPrint;
        if (btnPrint1 != null)
          btnPrint1.Click -= eventHandler;
        this._btnPrint = value;
        Button btnPrint2 = this._btnPrint;
        if (btnPrint2 == null)
          return;
        btnPrint2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.txtNotesToEngineer = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.lblDate = new Label();
      this.lblOutcome = new Label();
      this.txtDate = new TextBox();
      this.txtOutcome = new TextBox();
      this.cboStatus = new ComboBox();
      this.btnView = new Button();
      this.TabControl1 = new TabControl();
      this.tpVisitDetails = new TabPage();
      this.btnUploadVisit = new Button();
      this.chkSendText = new CheckBox();
      this.chkRecharge = new CheckBox();
      this.btnPrint = new Button();
      this.cbxPartsToFit = new CheckBox();
      this.cboExpected = new ComboBox();
      this.tpParts = new TabPage();
      this.lblAuthCode = new Label();
      this.btnGenerateAuthCode = new Button();
      this.btnMoveParts = new Button();
      this.btnGetOrderRef = new Button();
      this.dgPartsAndProducts = new DataGrid();
      this.EstVisitDate = new TabPage();
      this.Label6 = new Label();
      this.dtpEstimateVisitDate = new DateTimePicker();
      this.txtPassword = new TextBox();
      this.Label7 = new Label();
      this.BtnEstSave = new Button();
      this.cmsPrint = new ContextMenuStrip(this.components);
      this.EngineerJobSheetToolStripMenuItem = new ToolStripMenuItem();
      this.ProForrmaToolStripMenuItem = new ToolStripMenuItem();
      this.btnPrintInstall = new ToolStripMenuItem();
      this.BtnPrintServiceLetter = new ToolStripMenuItem();
      this.btnPrintJobLetter = new ToolStripMenuItem();
      this.PrintSolarInstall = new ToolStripMenuItem();
      this.PrintElectricalAppointment = new ToolStripMenuItem();
      this.TabControl1.SuspendLayout();
      this.tpVisitDetails.SuspendLayout();
      this.tpParts.SuspendLayout();
      this.dgPartsAndProducts.BeginInit();
      this.EstVisitDate.SuspendLayout();
      this.cmsPrint.SuspendLayout();
      this.SuspendLayout();
      this.txtNotesToEngineer.AcceptsReturn = true;
      this.txtNotesToEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotesToEngineer.Location = new System.Drawing.Point(78, 8);
      this.txtNotesToEngineer.Multiline = true;
      this.txtNotesToEngineer.Name = "txtNotesToEngineer";
      this.txtNotesToEngineer.ScrollBars = ScrollBars.Vertical;
      this.txtNotesToEngineer.Size = new Size(406, 89);
      this.txtNotesToEngineer.TabIndex = 0;
      this.Label1.Location = new System.Drawing.Point(8, 8);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 51);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Notes To Engineer";
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.Location = new System.Drawing.Point(8, 103);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(56, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Status";
      this.lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblDate.Location = new System.Drawing.Point(8, 128);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(56, 16);
      this.lblDate.TabIndex = 3;
      this.lblDate.Text = "Date";
      this.lblOutcome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblOutcome.Location = new System.Drawing.Point(8, 157);
      this.lblOutcome.Name = "lblOutcome";
      this.lblOutcome.Size = new Size(64, 16);
      this.lblOutcome.TabIndex = 4;
      this.lblOutcome.Text = "Outcome";
      this.txtDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtDate.Location = new System.Drawing.Point(78, 128);
      this.txtDate.Name = "txtDate";
      this.txtDate.ReadOnly = true;
      this.txtDate.Size = new Size(283, 21);
      this.txtDate.TabIndex = 4;
      this.txtOutcome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtOutcome.Location = new System.Drawing.Point(78, 152);
      this.txtOutcome.Name = "txtOutcome";
      this.txtOutcome.ReadOnly = true;
      this.txtOutcome.Size = new Size(207, 21);
      this.txtOutcome.TabIndex = 5;
      this.cboStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(78, 101);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(283, 21);
      this.cboStatus.TabIndex = 1;
      this.btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnView.Location = new System.Drawing.Point(388, 184);
      this.btnView.Name = "btnView";
      this.btnView.Size = new Size(96, 23);
      this.btnView.TabIndex = 8;
      this.btnView.Text = "View Results";
      this.TabControl1.Controls.Add((Control) this.tpVisitDetails);
      this.TabControl1.Controls.Add((Control) this.tpParts);
      this.TabControl1.Controls.Add((Control) this.EstVisitDate);
      this.TabControl1.Dock = DockStyle.Fill;
      this.TabControl1.Location = new System.Drawing.Point(0, 0);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(500, 240);
      this.TabControl1.TabIndex = 7;
      this.tpVisitDetails.Controls.Add((Control) this.btnUploadVisit);
      this.tpVisitDetails.Controls.Add((Control) this.chkSendText);
      this.tpVisitDetails.Controls.Add((Control) this.chkRecharge);
      this.tpVisitDetails.Controls.Add((Control) this.btnPrint);
      this.tpVisitDetails.Controls.Add((Control) this.Label1);
      this.tpVisitDetails.Controls.Add((Control) this.Label2);
      this.tpVisitDetails.Controls.Add((Control) this.lblDate);
      this.tpVisitDetails.Controls.Add((Control) this.txtDate);
      this.tpVisitDetails.Controls.Add((Control) this.txtOutcome);
      this.tpVisitDetails.Controls.Add((Control) this.cboStatus);
      this.tpVisitDetails.Controls.Add((Control) this.btnView);
      this.tpVisitDetails.Controls.Add((Control) this.txtNotesToEngineer);
      this.tpVisitDetails.Controls.Add((Control) this.cbxPartsToFit);
      this.tpVisitDetails.Controls.Add((Control) this.cboExpected);
      this.tpVisitDetails.Controls.Add((Control) this.lblOutcome);
      this.tpVisitDetails.Location = new System.Drawing.Point(4, 22);
      this.tpVisitDetails.Name = "tpVisitDetails";
      this.tpVisitDetails.Size = new Size(492, 214);
      this.tpVisitDetails.TabIndex = 0;
      this.tpVisitDetails.Text = "Visit Details";
      this.btnUploadVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUploadVisit.Location = new System.Drawing.Point(11, 184);
      this.btnUploadVisit.Name = "btnUploadVisit";
      this.btnUploadVisit.Size = new Size(104, 23);
      this.btnUploadVisit.TabIndex = 13;
      this.btnUploadVisit.Text = "Upload Visit";
      this.chkSendText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkSendText.AutoSize = true;
      this.chkSendText.Location = new System.Drawing.Point(297, 156);
      this.chkSendText.Name = "chkSendText";
      this.chkSendText.Size = new Size(187, 17);
      this.chkSendText.TabIndex = 12;
      this.chkSendText.Text = "Exclude From Auto-Message";
      this.chkSendText.UseVisualStyleBackColor = true;
      this.chkRecharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkRecharge.AutoSize = true;
      this.chkRecharge.Location = new System.Drawing.Point(395, 130);
      this.chkRecharge.Name = "chkRecharge";
      this.chkRecharge.Size = new Size(80, 17);
      this.chkRecharge.TabIndex = 11;
      this.chkRecharge.Text = "Recharge";
      this.chkRecharge.UseVisualStyleBackColor = true;
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(288, 184);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(96, 23);
      this.btnPrint.TabIndex = 7;
      this.btnPrint.Text = "Print...";
      this.cbxPartsToFit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cbxPartsToFit.AutoSize = true;
      this.cbxPartsToFit.Location = new System.Drawing.Point(395, 105);
      this.cbxPartsToFit.Name = "cbxPartsToFit";
      this.cbxPartsToFit.Size = new Size(89, 17);
      this.cbxPartsToFit.TabIndex = 2;
      this.cbxPartsToFit.Text = "Parts To Fit";
      this.cbxPartsToFit.UseVisualStyleBackColor = true;
      this.cboExpected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cboExpected.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboExpected.Location = new System.Drawing.Point(78, 64);
      this.cboExpected.Name = "cboExpected";
      this.cboExpected.Size = new Size(364, 21);
      this.cboExpected.TabIndex = 3;
      this.cboExpected.Visible = false;
      this.tpParts.Controls.Add((Control) this.lblAuthCode);
      this.tpParts.Controls.Add((Control) this.btnGenerateAuthCode);
      this.tpParts.Controls.Add((Control) this.btnMoveParts);
      this.tpParts.Controls.Add((Control) this.btnGetOrderRef);
      this.tpParts.Controls.Add((Control) this.dgPartsAndProducts);
      this.tpParts.Location = new System.Drawing.Point(4, 22);
      this.tpParts.Name = "tpParts";
      this.tpParts.Size = new Size(492, 214);
      this.tpParts.TabIndex = 1;
      this.tpParts.Text = "Parts && Products Allocated";
      this.lblAuthCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblAuthCode.AutoSize = true;
      this.lblAuthCode.Location = new System.Drawing.Point(111, 187);
      this.lblAuthCode.Name = "lblAuthCode";
      this.lblAuthCode.Size = new Size(0, 13);
      this.lblAuthCode.TabIndex = 28;
      this.btnGenerateAuthCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnGenerateAuthCode.Location = new System.Drawing.Point(12, 182);
      this.btnGenerateAuthCode.Name = "btnGenerateAuthCode";
      this.btnGenerateAuthCode.Size = new Size(93, 23);
      this.btnGenerateAuthCode.TabIndex = 27;
      this.btnGenerateAuthCode.Text = "Auth Code";
      this.btnGenerateAuthCode.UseVisualStyleBackColor = true;
      this.btnMoveParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnMoveParts.Location = new System.Drawing.Point(340, 6);
      this.btnMoveParts.Name = "btnMoveParts";
      this.btnMoveParts.Size = new Size(144, 23);
      this.btnMoveParts.TabIndex = 26;
      this.btnMoveParts.Text = "Reallocate Parts";
      this.btnMoveParts.UseVisualStyleBackColor = true;
      this.btnGetOrderRef.Location = new System.Drawing.Point(9, 6);
      this.btnGetOrderRef.Name = "btnGetOrderRef";
      this.btnGetOrderRef.Size = new Size(145, 23);
      this.btnGetOrderRef.TabIndex = 25;
      this.btnGetOrderRef.Text = "Create Quick PO";
      this.btnGetOrderRef.UseVisualStyleBackColor = true;
      this.dgPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsAndProducts.DataMember = "";
      this.dgPartsAndProducts.Font = new Font("Verdana", 8.25f);
      this.dgPartsAndProducts.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsAndProducts.Location = new System.Drawing.Point(8, 33);
      this.dgPartsAndProducts.Name = "dgPartsAndProducts";
      this.dgPartsAndProducts.Size = new Size(476, 143);
      this.dgPartsAndProducts.TabIndex = 1;
      this.EstVisitDate.Controls.Add((Control) this.Label6);
      this.EstVisitDate.Controls.Add((Control) this.dtpEstimateVisitDate);
      this.EstVisitDate.Controls.Add((Control) this.txtPassword);
      this.EstVisitDate.Controls.Add((Control) this.Label7);
      this.EstVisitDate.Controls.Add((Control) this.BtnEstSave);
      this.EstVisitDate.Location = new System.Drawing.Point(4, 22);
      this.EstVisitDate.Name = "EstVisitDate";
      this.EstVisitDate.Size = new Size(492, 214);
      this.EstVisitDate.TabIndex = 2;
      this.EstVisitDate.Text = "Est Visit Date";
      this.EstVisitDate.UseVisualStyleBackColor = true;
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(11, 56);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(122, 13);
      this.Label6.TabIndex = 12;
      this.Label6.Text = "Estimated Visit Date";
      this.dtpEstimateVisitDate.Enabled = false;
      this.dtpEstimateVisitDate.Location = new System.Drawing.Point(199, 50);
      this.dtpEstimateVisitDate.Name = "dtpEstimateVisitDate";
      this.dtpEstimateVisitDate.Size = new Size(176, 21);
      this.dtpEstimateVisitDate.TabIndex = 11;
      this.txtPassword.Location = new System.Drawing.Point(199, 22);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(176, 21);
      this.txtPassword.TabIndex = 10;
      this.txtPassword.UseSystemPasswordChar = true;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(11, 25);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(169, 13);
      this.Label7.TabIndex = 9;
      this.Label7.Text = "Enter the override password";
      this.BtnEstSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.BtnEstSave.Location = new System.Drawing.Point(98, 84);
      this.BtnEstSave.Name = "BtnEstSave";
      this.BtnEstSave.Size = new Size(96, 23);
      this.BtnEstSave.TabIndex = 8;
      this.BtnEstSave.Text = "Save";
      this.cmsPrint.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.EngineerJobSheetToolStripMenuItem,
        (ToolStripItem) this.ProForrmaToolStripMenuItem,
        (ToolStripItem) this.btnPrintInstall,
        (ToolStripItem) this.BtnPrintServiceLetter,
        (ToolStripItem) this.btnPrintJobLetter,
        (ToolStripItem) this.PrintSolarInstall,
        (ToolStripItem) this.PrintElectricalAppointment
      });
      this.cmsPrint.Name = "cmsPrint";
      this.cmsPrint.Size = new Size(224, 158);
      this.EngineerJobSheetToolStripMenuItem.Name = "EngineerJobSheetToolStripMenuItem";
      this.EngineerJobSheetToolStripMenuItem.Size = new Size(223, 22);
      this.EngineerJobSheetToolStripMenuItem.Text = "Engineer Job Sheet";
      this.ProForrmaToolStripMenuItem.Name = "ProForrmaToolStripMenuItem";
      this.ProForrmaToolStripMenuItem.Size = new Size(223, 22);
      this.ProForrmaToolStripMenuItem.Text = "Pro-Forma";
      this.btnPrintInstall.Name = "btnPrintInstall";
      this.btnPrintInstall.Size = new Size(223, 22);
      this.btnPrintInstall.Text = "Print Install Sheet";
      this.BtnPrintServiceLetter.Name = "BtnPrintServiceLetter";
      this.BtnPrintServiceLetter.Size = new Size(223, 22);
      this.BtnPrintServiceLetter.Text = "Print Service Letter";
      this.BtnPrintServiceLetter.Visible = false;
      this.btnPrintJobLetter.Name = "btnPrintJobLetter";
      this.btnPrintJobLetter.Size = new Size(223, 22);
      this.btnPrintJobLetter.Text = "Print Appointment Letter";
      this.PrintSolarInstall.Name = "PrintSolarInstall";
      this.PrintSolarInstall.Size = new Size(223, 22);
      this.PrintSolarInstall.Text = "Print Solar Installation ";
      this.PrintSolarInstall.Visible = false;
      this.PrintElectricalAppointment.Name = "PrintElectricalAppointment";
      this.PrintElectricalAppointment.Size = new Size(223, 22);
      this.PrintElectricalAppointment.Text = "Print Electrical Appointment";
      this.PrintElectricalAppointment.Visible = false;
      this.AutoScroll = false;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCVisitBreakdown);
      this.Size = new Size(500, 240);
      this.TabControl1.ResumeLayout(false);
      this.tpVisitDetails.ResumeLayout(false);
      this.tpVisitDetails.PerformLayout();
      this.tpParts.ResumeLayout(false);
      this.tpParts.PerformLayout();
      this.dgPartsAndProducts.EndInit();
      this.EstVisitDate.ResumeLayout(false);
      this.EstVisitDate.PerformLayout();
      this.cmsPrint.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupDG();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.EngineerVisit;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public UCCalloutBreakdown OnControl
    {
      get
      {
        return this._onControl;
      }
      set
      {
        this._onControl = value;
      }
    }

    public EngineerVisit EngineerVisit
    {
      get
      {
        return this._engineerVisit;
      }
      set
      {
        this._engineerVisit = value;
        if (this._engineerVisit != null)
          return;
        this._engineerVisit = new EngineerVisit();
      }
    }

    public DataView PartsAndProducts
    {
      get
      {
        return this._PartsAndProducts;
      }
      set
      {
        this._PartsAndProducts = value;
        this._PartsAndProducts.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
        this._PartsAndProducts.AllowNew = false;
        this._PartsAndProducts.AllowEdit = false;
        this._PartsAndProducts.AllowDelete = false;
        this.dgPartsAndProducts.DataSource = (object) this.PartsAndProducts;
      }
    }

    private DataRow SelectedPartProductDataRow
    {
      get
      {
        return this.dgPartsAndProducts.CurrentRowIndex != -1 ? this.PartsAndProducts[this.dgPartsAndProducts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public int PartProductID
    {
      get
      {
        return this._PartProductID;
      }
      set
      {
        this._PartProductID = value;
      }
    }

    public string Type
    {
      get
      {
        return this._Type;
      }
      set
      {
        this._Type = value;
      }
    }

    public ArrayList PartsProductsToRemoveFromOrder
    {
      get
      {
        return this._PartsProductsToRemoveFromOrder;
      }
      set
      {
        this._PartsProductsToRemoveFromOrder = value;
      }
    }

    public ArrayList PartsProductsToReallocated
    {
      get
      {
        return this._PartsProductsToReallocated;
      }
      set
      {
        this._PartsProductsToReallocated = value;
      }
    }

    public bool change
    {
      get
      {
        return this._change;
      }
      set
      {
        this._change = value;
      }
    }

    private void UCVisitBreakdown_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnGetOrderRef_Click(object sender, EventArgs e)
    {
      if (this.EngineerVisit.EngineerVisitID == 0)
      {
        int num1 = (int) App.ShowMessage("Please save visit before creating order!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        TabletOrder tabletOrder = (TabletOrder) App.checkIfExists(typeof (TabletOrder).Name, true) ?? (TabletOrder) Activator.CreateInstance(typeof (TabletOrder));
        tabletOrder.EngineerID = this.EngineerVisit.EngineerID;
        tabletOrder.EngineerVisitID = this.EngineerVisit.EngineerVisitID;
        tabletOrder.ShowInTaskbar = false;
        int num2 = (int) tabletOrder.ShowDialog();
        if (this.OnControl.OnContol.ParentForm != null)
          this.OnControl.OnContol.Populate(0);
      }
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      bool flag = false;
      switch (this.EngineerVisit.StatusEnumID)
      {
        case 0:
          int num1 = (int) App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case 1:
          int num2 = (int) App.ShowMessage("Parts Need Ordering for this visit, once ordered and received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case 2:
          int num3 = (int) App.ShowMessage("This visit is waiting for parts, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case 3:
          int num4 = (int) App.ShowMessage("This visit is waiting for parts to be received by engineer, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case 4:
          if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            flag = true;
            break;
          }
          break;
        case 5:
          if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            flag = true;
            break;
          }
          break;
        case 6:
          int num5 = (int) App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        default:
          flag = true;
          break;
      }
      if (!flag)
        return;
      App.ShowForm(typeof (FRMEngineerVisit), true, new object[2]
      {
        (object) this.EngineerVisit.EngineerVisitID,
        (object) this
      }, false);
      if (this.OnControl.OnContol.ParentForm != null)
        this.OnControl.OnContol.Populate(0);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      this.cmsPrint.Show((Control) this.btnPrint, new System.Drawing.Point(0, 0));
    }

    private void PrintEngjob(object sender, EventArgs e)
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Engineer Jobsheet ", Enums.SystemDocumentType.SVR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void btnPrintInstall_Click(object sender, EventArgs e)
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.EngineerVisit
      }, "Install ", Enums.SystemDocumentType.Install, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    public void SetupDG()
    {
      Helper.SetUpDataGrid(this.dgPartsAndProducts, false);
      DataGridTableStyle tableStyle = this.dgPartsAndProducts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Supplier";
      dataGridLabelColumn1.MappingName = "Supplier";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 80;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Type";
      dataGridLabelColumn2.MappingName = "type";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 60;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Number";
      dataGridLabelColumn3.MappingName = "number";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Name";
      dataGridLabelColumn4.MappingName = "Name";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 140;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Qty";
      dataGridLabelColumn5.MappingName = "quantity";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 50;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Buy Price";
      dataGridLabelColumn6.MappingName = "sellPrice";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Order Ref.";
      dataGridLabelColumn7.MappingName = "OrderReference";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Order Status";
      dataGridLabelColumn8.MappingName = "OrderStatus";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Qty Ordered";
      dataGridLabelColumn9.MappingName = "QuantityOrdered";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Order Qty Received";
      dataGridLabelColumn10.MappingName = "QuantityReceived";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Qty Credit";
      dataGridLabelColumn11.MappingName = "CreditQty";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 75;
      dataGridLabelColumn11.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      this.dgPartsAndProducts.TableStyles.Add(tableStyle);
    }

    public void Populate(int ID = 0)
    {
      ComboBox cboExpected1 = this.cboExpected;
      Combo.SetUpCombo(ref cboExpected1, this.OnControl.OnContol.DvEngineers.Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboExpected = cboExpected1;
      ComboBox cboExpected2 = this.cboExpected;
      Combo.SetSelectedComboItem_By_Value(ref cboExpected2, Conversions.ToString(this.EngineerVisit.ExpectedEngineerID));
      this.cboExpected = cboExpected2;
      this.dtpEstimateVisitDate.Value = !Information.IsDBNull((object) this.EngineerVisit.EstimatedDate) ? this.EngineerVisit.EstimatedDate : DateAndTime.Today;
      if (this.EngineerVisit.ExpectedEngineerID == 0)
        this.cboExpected.Enabled = true;
      else
        this.cboExpected.Enabled = false;
      switch (this.EngineerVisit.StatusEnumID)
      {
        case 0:
        case 1:
        case 2:
        case 3:
          ComboBox cboStatus1 = this.cboStatus;
          Combo.SetUpCombo(ref cboStatus1, DynamicDataTables.VisitStatus_For_Selection, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
          this.cboStatus = cboStatus1;
          ComboBox cboStatus2 = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus2, Conversions.ToString(this.EngineerVisit.StatusEnumID));
          this.cboStatus = cboStatus2;
          this.cbxPartsToFit.Checked = this.EngineerVisit.PartsToFit;
          this.chkRecharge.Checked = false;
          this.cboStatus.Enabled = true;
          this.cbxPartsToFit.Enabled = true;
          this.chkRecharge.Enabled = true;
          this.btnMoveParts.Enabled = true;
          this.txtNotesToEngineer.ReadOnly = false;
          this.txtDate.Text = "Not Set";
          this.txtOutcome.Text = "Not Set";
          this.txtDate.Visible = false;
          this.txtOutcome.Visible = false;
          this.btnView.Visible = false;
          this.btnPrintInstall.Visible = false;
          this.lblDate.Visible = false;
          this.lblOutcome.Visible = false;
          break;
        case 4:
          ComboBox cboStatus3 = this.cboStatus;
          Combo.SetUpCombo(ref cboStatus3, DynamicDataTables.VisitStatus_For_Selection, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
          this.cboStatus = cboStatus3;
          ComboBox cboStatus4 = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus4, Conversions.ToString(this.EngineerVisit.StatusEnumID));
          this.cboStatus = cboStatus4;
          this.cbxPartsToFit.Checked = this.EngineerVisit.PartsToFit;
          this.cboStatus.Enabled = true;
          this.cbxPartsToFit.Enabled = true;
          this.chkRecharge.Enabled = true;
          this.btnMoveParts.Enabled = true;
          this.cboExpected.Enabled = false;
          this.txtNotesToEngineer.ReadOnly = false;
          this.txtDate.Text = "Not Set";
          this.txtOutcome.Text = "Not Set";
          this.txtDate.Visible = false;
          this.lblDate.Visible = false;
          this.lblOutcome.Visible = false;
          this.txtOutcome.Visible = false;
          this.btnView.Visible = true;
          this.btnPrintInstall.Visible = true;
          break;
        case 5:
        case 6:
          ComboBox cboStatus5 = this.cboStatus;
          Combo.SetUpCombo(ref cboStatus5, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
          this.cboStatus = cboStatus5;
          ComboBox cboStatus6 = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus6, Conversions.ToString(this.EngineerVisit.StatusEnumID));
          this.cboStatus = cboStatus6;
          this.cbxPartsToFit.Checked = this.EngineerVisit.PartsToFit;
          this.cboStatus.Enabled = false;
          this.cbxPartsToFit.Enabled = false;
          this.chkRecharge.Enabled = false;
          this.btnMoveParts.Enabled = false;
          this.cboExpected.Enabled = false;
          this.txtOutcome.Text = "Not Set";
          this.txtNotesToEngineer.ReadOnly = false;
          this.txtDate.Visible = true;
          this.lblDate.Visible = true;
          this.lblOutcome.Visible = false;
          this.txtOutcome.Visible = false;
          this.btnView.Visible = true;
          this.btnPrintInstall.Visible = true;
          if (DateHelper.GetDays(this.EngineerVisit.StartDateTime, this.EngineerVisit.EndDateTime) > 0)
            this.txtDate.Text = this.EngineerVisit.StartDateTime.ToShortDateString() + " - " + this.EngineerVisit.EndDateTime.ToShortDateString() + " - " + App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID)?.Name;
          else if ((uint) DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) > 0U)
            this.txtDate.Text = this.EngineerVisit.StartDateTime.ToShortDateString() + " - " + App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID)?.Name;
          Job job1 = this.OnControl.OnContol.Job;
          bool? nullable1 = job1 != null ? new bool?(job1.JobTypeID == 4702) : new bool?();
          bool? nullable2 = this.EngineerVisit.VisitNumber > 0 ? new bool?(true) : nullable1;
          Job job2 = this.OnControl.OnContol.Job;
          bool? nullable3 = job2 != null ? new bool?(job2.JobTypeID == 519) : new bool?();
          nullable3 = !nullable2.HasValue || !nullable2.GetValueOrDefault() ? (nullable3.HasValue ? (nullable3.GetValueOrDefault() ? new bool?(true) : nullable2) : new bool?()) : new bool?(true);
          if (nullable3.GetValueOrDefault())
            this.BtnPrintServiceLetter.Visible = true;
          this.PrintSolarInstall.Visible = true;
          this.PrintElectricalAppointment.Visible = true;
          break;
        case 7:
        case 8:
        case 9:
        case 10:
          ComboBox cboStatus7 = this.cboStatus;
          Combo.SetUpCombo(ref cboStatus7, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
          this.cboStatus = cboStatus7;
          ComboBox cboStatus8 = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus8, Conversions.ToString(this.EngineerVisit.StatusEnumID));
          this.cboStatus = cboStatus8;
          this.cbxPartsToFit.Checked = this.EngineerVisit.PartsToFit;
          this.cboStatus.Enabled = false;
          this.cbxPartsToFit.Enabled = false;
          this.chkRecharge.Enabled = false;
          this.btnMoveParts.Enabled = true;
          this.btnView.Enabled = true;
          this.cboExpected.Enabled = false;
          this.chkSendText.Visible = false;
          this.txtNotesToEngineer.ReadOnly = true;
          this.txtDate.Visible = true;
          this.txtOutcome.Visible = true;
          this.lblDate.Visible = true;
          this.lblOutcome.Visible = true;
          this.btnPrintInstall.Visible = false;
          int days = DateHelper.GetDays(this.EngineerVisit.StartDateTime, this.EngineerVisit.EndDateTime);
          if (DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) == 0)
          {
            this.txtDate.Text = Strings.Format((object) this.EngineerVisit.ManualEntryOn, "dd/MMM/yyyy") + " (Manually Completed)";
            if (days > 0)
            {
              TextBox txtDate = this.txtDate;
              DateTime dateTime = this.EngineerVisit.StartDateTime;
              string shortDateString1 = dateTime.ToShortDateString();
              dateTime = this.EngineerVisit.EndDateTime;
              string shortDateString2 = dateTime.ToShortDateString();
              string str = shortDateString1 + " - " + shortDateString2 + " - (Manually Completed)";
              txtDate.Text = str;
            }
          }
          else
          {
            Engineer engineer = App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID);
            if (engineer == null)
            {
              this.txtDate.Text = Strings.Format((object) this.EngineerVisit.StartDateTime, "dd/MMM/yyyy");
              if (days > 0)
              {
                TextBox txtDate = this.txtDate;
                DateTime dateTime = this.EngineerVisit.StartDateTime;
                string shortDateString1 = dateTime.ToShortDateString();
                dateTime = this.EngineerVisit.EndDateTime;
                string shortDateString2 = dateTime.ToShortDateString();
                string str = shortDateString1 + " - " + shortDateString2;
                txtDate.Text = str;
              }
            }
            else
            {
              this.txtDate.Text = Strings.Format((object) this.EngineerVisit.StartDateTime, "dd/MMM/yyyy") + " - " + engineer.Name;
              if (days > 0)
                this.txtDate.Text = this.EngineerVisit.StartDateTime.ToShortDateString() + " - " + this.EngineerVisit.EndDateTime.ToShortDateString() + " - " + engineer.Name;
            }
          }
          Job job3 = this.OnControl.OnContol.Job;
          bool? nullable4 = job3 != null ? new bool?(job3.JobTypeID == 4702) : new bool?();
          bool? nullable5 = this.EngineerVisit.VisitNumber > 0 ? new bool?(true) : nullable4;
          Job job4 = this.OnControl.OnContol.Job;
          bool? nullable6 = job4 != null ? new bool?(job4.JobTypeID == 519) : new bool?();
          nullable6 = !nullable5.HasValue || !nullable5.GetValueOrDefault() ? (nullable6.HasValue ? (nullable6.GetValueOrDefault() ? new bool?(true) : nullable5) : new bool?()) : new bool?(true);
          if (nullable6.GetValueOrDefault())
            this.BtnPrintServiceLetter.Visible = true;
          this.PrintSolarInstall.Visible = true;
          this.PrintElectricalAppointment.Visible = true;
          switch (this.EngineerVisit.OutcomeEnumID)
          {
            case 0:
              this.txtOutcome.Text = "Not Set";
              break;
            case 1:
              this.txtOutcome.Text = "Complete";
              break;
            case 2:
              this.txtOutcome.Text = "Carded";
              break;
            case 3:
              this.txtOutcome.Text = "Could Not Start";
              break;
            case 4:
              this.txtOutcome.Text = "Declined";
              break;
            case 5:
              this.txtOutcome.Text = "Further Works";
              break;
            case 6:
              this.txtOutcome.Text = "Visit Not Required";
              break;
          }
          break;
      }
      if (this.EngineerVisit.StatusEnumID == 6)
      {
        this.btnGenerateAuthCode.Visible = true;
        this.lblAuthCode.Visible = true;
        this.btnUploadVisit.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT);
      }
      else
      {
        this.btnGenerateAuthCode.Visible = false;
        this.lblAuthCode.Visible = false;
        this.btnUploadVisit.Visible = false;
      }
      this.chkRecharge.Checked = this.EngineerVisit.Recharge;
      this.chkSendText.Checked = this.EngineerVisit.ExcludeFromTextMessage;
      this.txtNotesToEngineer.Text = this.EngineerVisit.NotesToEngineer;
      this.cbxPartsToFit.Visible = true;
      if (this.OnControl.OnContol.Job.StatusEnumID >= 2)
      {
        this.cboStatus.Enabled = false;
        this.txtNotesToEngineer.Enabled = false;
        this.cboExpected.Enabled = false;
      }
      DataRow[] dataRowArray = this.OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Select("EngineerVisitId = " + Conversions.ToString(this.EngineerVisit.EngineerVisitID));
      DataTable table = this.OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Clone();
      if (dataRowArray.Length > 0)
        table = ((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>();
      this.PartsAndProducts = new DataView(table);
      this.change = false;
    }

    public bool Save()
    {
      bool flag;
      return flag;
    }

    public void SendToPrint(string fileName = "")
    {
      DataView dataView = App.DB.LetterManager.MakeServiceLetter(this.EngineerVisit.EngineerVisitID);
      dataView.Table.Columns.Add("FileName");
      DataRow row1;
      if (dataView.Count > 0 & string.IsNullOrEmpty(fileName))
      {
        row1 = dataView.Table.Rows[0];
      }
      else
      {
        FSM.Entity.Sites.Site site = this.OnControl.OnContol.Site;
        DataTable dataTable = dataView.Table.Clone();
        DataRow row2 = dataTable.NewRow();
        row2["Name"] = (object) site.Name;
        row2["Address1"] = (object) site.Address1;
        row2["Address2"] = (object) site.Address2;
        row2["Address3"] = (object) site.Address3;
        row2["Address4"] = (object) site.Address4;
        row2["Address5"] = (object) site.Address5;
        row2["Postcode"] = (object) site.Postcode;
        row2["SiteID"] = (object) site.SiteID;
        row2["CustomerID"] = (object) site.CustomerID;
        row2["SolidFuel"] = (object) site.SolidFuel;
        row2["PropertyVoid"] = (object) site.PropertyVoid;
        row2["LastServiceDate"] = (object) site.LastServiceDate;
        row2["CommercialDistrict"] = (object) site.CommercialDistrict;
        row2["SiteFuel"] = (object) site.SiteFuel;
        row2["Type"] = (object) "Generic";
        row2["NextVisitDate"] = (object) this.EngineerVisit.StartDateTime;
        row2["StartDateTime"] = (object) this.EngineerVisit.StartDateTime;
        row2["AMPM"] = (object) "";
        row2["JobID"] = (object) this.OnControl.OnContol.Job.JobID;
        row2["JobNumber"] = (object) this.OnControl.OnContol.Job.JobNumber;
        row2["FileName"] = (object) fileName;
        dataTable.Rows.Add(row2);
        row1 = dataTable.Rows[0];
      }
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) row1);
      Printing printing = new Printing((object) arrayList, "Service Letter", Enums.SystemDocumentType.ServiceLetters, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row1["Type"], (object) "Letter 2", false))
      {
        row1["Type"] = (object) "Letter 2 HAND";
        arrayList.Clear();
        arrayList.Add((object) row1);
        printing = new Printing((object) arrayList, "Service Letter", Enums.SystemDocumentType.ServiceLetters, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
      if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row1["Type"], (object) "Letter 3", false))
        return;
      row1["Type"] = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row1["CommercialDistrict"], (object) "1", false) ? (object) "Letter 3 HAND" : (object) "Letter 3 COM HAND";
      arrayList.Clear();
      arrayList.Add((object) row1);
      printing = new Printing((object) arrayList, "Service Letter", Enums.SystemDocumentType.ServiceLetters, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void btnEstSave_Click(object sender, EventArgs e)
    {
      App.DB.EngineerVisits.AlterEstimatedDate(this.EngineerVisit.JobOfWorkID, this.dtpEstimateVisitDate.Value);
      this.dtpEstimateVisitDate.Enabled = false;
      this.txtPassword.Text = "";
      this.BtnEstSave.Enabled = false;
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.DB.Manager.Get().OverridePassword, false) == 0)
      {
        this.dtpEstimateVisitDate.Enabled = true;
        this.BtnEstSave.Enabled = true;
      }
      else
      {
        this.dtpEstimateVisitDate.Enabled = false;
        this.BtnEstSave.Enabled = false;
      }
    }

    private void btnMoveParts_Click(object sender, EventArgs e)
    {
      if (this.EngineerVisit == null || this.EngineerVisit.EngineerVisitID == 0)
        return;
      FRMMoveParts frmMoveParts = new FRMMoveParts();
      frmMoveParts.EngineerVisitId = this.EngineerVisit.EngineerVisitID;
      frmMoveParts.JobNumber = this.OnControl.OnContol.Job.JobNumber;
      int num1 = (int) frmMoveParts.ShowDialog();
      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmMoveParts.cboVisit));
      if (integer > 0)
      {
        if (App.DB.EngineerVisits.MoveParts(this.EngineerVisit.EngineerVisitID, integer))
        {
          int num2 = (int) App.ShowMessage("Parts have been moved, please refresh window!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          int num3 = (int) App.ShowMessage("No parts have been moved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    private void txtNotesToEngineer_TextChanged(object sender, EventArgs e)
    {
      this.change = true;
    }

    private void BtnPrintServiceLetter_Click(object sender, EventArgs e)
    {
      this.SendToPrint("");
    }

    private void ProForrmaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ArrayList arrayList = new ArrayList();
      Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisit.EngineerVisitID);
      arrayList.Add((object) "JOB");
      arrayList.Add((object) anEngineerVisitId);
      FRMInvoiceExtraDetail invoiceExtraDetail = new FRMInvoiceExtraDetail();
      int num = (int) invoiceExtraDetail.ShowDialog();
      arrayList.Add((object) invoiceExtraDetail.txtNotes.Text);
      arrayList.Add((object) Conversions.ToDouble(invoiceExtraDetail.txtCharge.Text));
      arrayList.Add((object) App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(invoiceExtraDetail.cbo))).VATRate);
      Printing printing = new Printing((object) arrayList, "ProFormaFromVisit", Enums.SystemDocumentType.ProFormaFromVisit, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void btnGenerateAuthCode_Click(object sender, EventArgs e)
    {
      int num;
      if (this.EngineerVisit.EngineerVisitID > 0 | this.EngineerVisit.EngineerID > 0)
        num = checked ((int) Math.Ceiling(unchecked ((double) checked (this.EngineerVisit.EngineerVisitID + this.EngineerVisit.EngineerID) / (double) DateAndTime.Now.Hour)));
      this.lblAuthCode.Text = Conversions.ToString(num);
    }

    private void btnPrintJobLetter_Click(object sender, EventArgs e)
    {
      if (this.EngineerVisit != null & this.EngineerVisit.EngineerVisitID > 0)
      {
        Job job = this.OnControl.OnContol.Job;
        DataView byJobNumber = App.DB.JobImports.JobImport_Get_ByJobNumber(job.JobNumber);
        if (byJobNumber.Count > 0)
        {
          Cursor.Current = Cursors.WaitCursor;
          Process.Start(new Printing((object) new ArrayList()
          {
            (object) byJobNumber.Table
          }, Conversions.ToString(byJobNumber.Table.Rows[0]["Type"]), Enums.SystemDocumentType.JobImportLetters, false, 0, true, 13, 0, DateTime.MinValue, (DataTable) null).EmailWP());
          Cursor.Current = Cursors.Default;
        }
        else
        {
          FSM.Entity.Sites.Site site = this.OnControl.OnContol.Site;
          if (site != null && job.JobTypeID == 484)
          {
            switch (site.CustomerID)
            {
              case 2846:
              case 4703:
              case 5338:
              case 5872:
                Cursor.Current = Cursors.WaitCursor;
                DataTable dataTable = byJobNumber.Table.Clone();
                DataRow row = dataTable.NewRow();
                row["Name"] = (object) site.Name;
                row["Address1"] = (object) site.Address1.Trim();
                row["Address2"] = (object) site.Address2.Trim();
                row["Address3"] = (object) site.Address3.Trim();
                row["Postcode"] = (object) site.Postcode.Trim();
                row["TelNo"] = (object) site.TelephoneNum.Trim();
                row["JobImportID"] = (object) 0;
                row["SiteID"] = (object) site.SiteID;
                row["UPRN"] = (object) site.PolicyNumber.Trim();
                row["JobImportTypeID"] = (object) 0;
                switch (site.CustomerID)
                {
                  case 2846:
                    row["Type"] = (object) "NCC-REMEDIAL";
                    break;
                  case 4703:
                    row["Type"] = (object) "SHS-REMEDIAL";
                    break;
                  case 5338:
                    row["Type"] = (object) "FHG-REMEDIAL";
                    break;
                  case 5872:
                    row["Type"] = (object) "VHT-REMEDIAL";
                    break;
                }
                row["Dateadded"] = (object) DateAndTime.Now;
                row["JobID"] = (object) job.JobID;
                row["JobNumber"] = (object) job.JobNumber;
                row["Status"] = (object) 0;
                DateTime dateTime = DateTime.Compare(this.EngineerVisit.StartDateTime, DateTime.MinValue) != 0 ? this.EngineerVisit.StartDateTime : job.DateCreated;
                row["BookedVisit"] = (object) dateTime;
                row["Letter1"] = (object) dateTime;
                row["Letter2"] = (object) dateTime;
                row["Report"] = (object) 0;
                row["Deleted"] = (object) 0;
                dataTable.Rows.Add(row);
                Process.Start(new Printing((object) new ArrayList()
                {
                  (object) dataTable,
                  (object) this.EngineerVisit
                }, Conversions.ToString(dataTable.Rows[0]["Type"]), Enums.SystemDocumentType.JobImportLetters, false, 0, true, 13, 0, DateTime.MinValue, (DataTable) null).EmailWP());
                Cursor.Current = Cursors.Default;
                break;
            }
          }
        }
      }
    }

    private void btnUploadVisit_Click(object sender, EventArgs e)
    {
      if (this.EngineerVisit == null)
        return;
      this.EngineerVisit.SetStatusEnumID = (object) 7;
      this.EngineerVisit.SetOutcomeEnumID = (object) 6;
      this.EngineerVisit.SetNotesFromEngineer = (object) ("Manually Uploaded by " + App.loggedInUser.Fullname);
      App.DB.EngineerVisits.EngineerVisit_ManualUpload(this.EngineerVisit);
      this.Populate(0);
    }

    private void PrintSolarInstall_Click(object sender, EventArgs e)
    {
      this.SendToPrint("\\ServiceLetters\\SolarAppointment.docx");
    }

    private void PrintElectricalAppointment_Click(object sender, EventArgs e)
    {
      this.SendToPrint("\\ServiceLetters\\ElectricalTestingLetter.docx");
    }
  }
}
