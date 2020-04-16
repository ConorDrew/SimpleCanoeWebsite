// Decompiled with JetBrains decompiler
// Type: FSM.pnlUnscheduledCalls
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class pnlUnscheduledCalls : UserControl
  {
    private DataView _dvunsched;
    private DataTable _dtUnscheduledCalls;
    private int TEXTSIZE;
    private bool isLoading;
    private int mousePosDownX;

    internal virtual Splitter splitForm
    {
      get
      {
        return this._splitForm;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.splitForm_MouseDown);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.splitForm_MouseMove);
        MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.splitForm_MouseUp);
        Splitter splitForm1 = this._splitForm;
        if (splitForm1 != null)
        {
          splitForm1.MouseDown -= mouseEventHandler1;
          splitForm1.MouseMove -= mouseEventHandler2;
          splitForm1.MouseUp -= mouseEventHandler3;
        }
        this._splitForm = value;
        Splitter splitForm2 = this._splitForm;
        if (splitForm2 == null)
          return;
        splitForm2.MouseDown += mouseEventHandler1;
        splitForm2.MouseMove += mouseEventHandler2;
        splitForm2.MouseUp += mouseEventHandler3;
      }
    }

    internal virtual Panel pnlHeader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType
    {
      get
      {
        return this._cboType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboType_SelectedIndexChanged);
        ComboBox cboType1 = this._cboType;
        if (cboType1 != null)
          cboType1.SelectedIndexChanged -= eventHandler;
        this._cboType = value;
        ComboBox cboType2 = this._cboType;
        if (cboType2 == null)
          return;
        cboType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkHasPartsToFit
    {
      get
      {
        return this._chkHasPartsToFit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkHasPartsToFit_CheckedChanged);
        CheckBox chkHasPartsToFit1 = this._chkHasPartsToFit;
        if (chkHasPartsToFit1 != null)
          chkHasPartsToFit1.CheckedChanged -= eventHandler;
        this._chkHasPartsToFit = value;
        CheckBox chkHasPartsToFit2 = this._chkHasPartsToFit;
        if (chkHasPartsToFit2 == null)
          return;
        chkHasPartsToFit2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkEstimatedVisitDate
    {
      get
      {
        return this._chkEstimatedVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkEstimatedVisitDate_CheckedChanged);
        CheckBox estimatedVisitDate1 = this._chkEstimatedVisitDate;
        if (estimatedVisitDate1 != null)
          estimatedVisitDate1.CheckedChanged -= eventHandler;
        this._chkEstimatedVisitDate = value;
        CheckBox estimatedVisitDate2 = this._chkEstimatedVisitDate;
        if (estimatedVisitDate2 == null)
          return;
        estimatedVisitDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpTo
    {
      get
      {
        return this._dtpTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpTo_ValueChanged);
        DateTimePicker dtpTo1 = this._dtpTo;
        if (dtpTo1 != null)
          dtpTo1.ValueChanged -= eventHandler;
        this._dtpTo = value;
        DateTimePicker dtpTo2 = this._dtpTo;
        if (dtpTo2 == null)
          return;
        dtpTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFrom
    {
      get
      {
        return this._dtpFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFrom_ValueChanged);
        DateTimePicker dtpFrom1 = this._dtpFrom;
        if (dtpFrom1 != null)
          dtpFrom1.ValueChanged -= eventHandler;
        this._dtpFrom = value;
        DateTimePicker dtpFrom2 = this._dtpFrom;
        if (dtpFrom2 == null)
          return;
        dtpFrom2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDeclined
    {
      get
      {
        return this._chkDeclined;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDeclined_CheckedChanged);
        CheckBox chkDeclined1 = this._chkDeclined;
        if (chkDeclined1 != null)
          chkDeclined1.CheckedChanged -= eventHandler;
        this._chkDeclined = value;
        CheckBox chkDeclined2 = this._chkDeclined;
        if (chkDeclined2 == null)
          return;
        chkDeclined2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSiteFuel
    {
      get
      {
        return this._cboSiteFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSiteFuel_SelectedIndexChanged);
        ComboBox cboSiteFuel1 = this._cboSiteFuel;
        if (cboSiteFuel1 != null)
          cboSiteFuel1.SelectedIndexChanged -= eventHandler;
        this._cboSiteFuel = value;
        ComboBox cboSiteFuel2 = this._cboSiteFuel;
        if (cboSiteFuel2 == null)
          return;
        cboSiteFuel2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion
    {
      get
      {
        return this._cboRegion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboRegion_SelectedIndexChanged);
        ComboBox cboRegion1 = this._cboRegion;
        if (cboRegion1 != null)
          cboRegion1.SelectedIndexChanged -= eventHandler;
        this._cboRegion = value;
        ComboBox cboRegion2 = this._cboRegion;
        if (cboRegion2 == null)
          return;
        cboRegion2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox TextBox1
    {
      get
      {
        return this._TextBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox1_TextChanged);
        TextBox textBox1_1 = this._TextBox1;
        if (textBox1_1 != null)
          textBox1_1.TextChanged -= eventHandler;
        this._TextBox1 = value;
        TextBox textBox1_2 = this._TextBox1;
        if (textBox1_2 == null)
          return;
        textBox1_2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkPNO
    {
      get
      {
        return this._chkPNO;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkPNO_CheckedChanged);
        CheckBox chkPno1 = this._chkPNO;
        if (chkPno1 != null)
          chkPno1.CheckedChanged -= eventHandler;
        this._chkPNO = value;
        CheckBox chkPno2 = this._chkPNO;
        if (chkPno2 == null)
          return;
        chkPno2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkWaitingParts
    {
      get
      {
        return this._chkWaitingParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkWaitingParts_CheckedChanged);
        CheckBox chkWaitingParts1 = this._chkWaitingParts;
        if (chkWaitingParts1 != null)
          chkWaitingParts1.CheckedChanged -= eventHandler;
        this._chkWaitingParts = value;
        CheckBox chkWaitingParts2 = this._chkWaitingParts;
        if (chkWaitingParts2 == null)
          return;
        chkWaitingParts2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification
    {
      get
      {
        return this._cboQualification;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQualification_SelectedIndexChanged);
        ComboBox cboQualification1 = this._cboQualification;
        if (cboQualification1 != null)
          cboQualification1.SelectedIndexChanged -= eventHandler;
        this._cboQualification = value;
        ComboBox cboQualification2 = this._cboQualification;
        if (cboQualification2 == null)
          return;
        cboQualification2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkViewAll
    {
      get
      {
        return this._chkViewAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkViewAll_Click);
        CheckBox chkViewAll1 = this._chkViewAll;
        if (chkViewAll1 != null)
          chkViewAll1.Click -= eventHandler;
        this._chkViewAll = value;
        CheckBox chkViewAll2 = this._chkViewAll;
        if (chkViewAll2 == null)
          return;
        chkViewAll2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlControls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public pnlUnscheduledCalls(
      MouseEventHandler gridMouseDown,
      MouseEventHandler gridMouseMove,
      DragEventHandler gridDragOver,
      DragEventHandler gridDragDrop,
      MouseEventHandler gridMouseUp,
      int TEXTSIZEs)
    {
      this.Load += new EventHandler(this.pnlUnscheduledCalls_Load);
      this.Resize += new EventHandler(this.pnlUnscheduledCalls_Resize);
      this.TEXTSIZE = 7;
      this.isLoading = false;
      this.mousePosDownX = -1;
      this.TEXTSIZE = TEXTSIZEs;
      this.InitializeComponent();
      this.dgCalls.MouseDown += gridMouseDown;
      this.dgCalls.MouseMove += gridMouseMove;
      this.dgCalls.DragOver += gridDragOver;
      this.dgCalls.DragDrop += gridDragDrop;
      this.dgCalls.MouseUp += gridMouseUp;
    }

    internal virtual Panel pnlTop { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenu mnuVisitAction { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuView { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlLegend { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearchPostcode
    {
      get
      {
        return this._txtSearchPostcode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox_Filter);
        TextBox txtSearchPostcode1 = this._txtSearchPostcode;
        if (txtSearchPostcode1 != null)
          txtSearchPostcode1.TextChanged -= eventHandler;
        this._txtSearchPostcode = value;
        TextBox txtSearchPostcode2 = this._txtSearchPostcode;
        if (txtSearchPostcode2 == null)
          return;
        txtSearchPostcode2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtSearchJobNo
    {
      get
      {
        return this._txtSearchJobNo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox_Filter);
        TextBox txtSearchJobNo1 = this._txtSearchJobNo;
        if (txtSearchJobNo1 != null)
          txtSearchJobNo1.TextChanged -= eventHandler;
        this._txtSearchJobNo = value;
        TextBox txtSearchJobNo2 = this._txtSearchJobNo;
        if (txtSearchJobNo2 == null)
          return;
        txtSearchJobNo2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCalls
    {
      get
      {
        return this._dgCalls;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgCalls_DoubleClick);
        DataGrid dgCalls1 = this._dgCalls;
        if (dgCalls1 != null)
          dgCalls1.DoubleClick -= eventHandler;
        this._dgCalls = value;
        DataGrid dgCalls2 = this._dgCalls;
        if (dgCalls2 == null)
          return;
        dgCalls2.DoubleClick += eventHandler;
      }
    }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearchAddress1
    {
      get
      {
        return this._txtSearchAddress1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox_Filter);
        TextBox txtSearchAddress1_1 = this._txtSearchAddress1;
        if (txtSearchAddress1_1 != null)
          txtSearchAddress1_1.TextChanged -= eventHandler;
        this._txtSearchAddress1 = value;
        TextBox txtSearchAddress1_2 = this._txtSearchAddress1;
        if (txtSearchAddress1_2 == null)
          return;
        txtSearchAddress1_2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtSearchCustomerName
    {
      get
      {
        return this._txtSearchCustomerName;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox_Filter);
        TextBox searchCustomerName1 = this._txtSearchCustomerName;
        if (searchCustomerName1 != null)
          searchCustomerName1.TextChanged -= eventHandler;
        this._txtSearchCustomerName = value;
        TextBox searchCustomerName2 = this._txtSearchCustomerName;
        if (searchCustomerName2 == null)
          return;
        searchCustomerName2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblOverdue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picLevels { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (pnlUnscheduledCalls));
      this.splitForm = new Splitter();
      this.mnuVisitAction = new ContextMenu();
      this.mnuView = new MenuItem();
      this.pnlHeader = new Panel();
      this.lblTitle = new Label();
      this.pnlControls = new Panel();
      this.pnlTop = new Panel();
      this.dgCalls = new DataGrid();
      this.GroupBox1 = new GroupBox();
      this.lblQualification = new Label();
      this.cboQualification = new ComboBox();
      this.chkWaitingParts = new CheckBox();
      this.chkPNO = new CheckBox();
      this.TextBox1 = new TextBox();
      this.Label10 = new Label();
      this.Label9 = new Label();
      this.cboRegion = new ComboBox();
      this.Label18 = new Label();
      this.cboSiteFuel = new ComboBox();
      this.chkDeclined = new CheckBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label17 = new Label();
      this.Label16 = new Label();
      this.chkEstimatedVisitDate = new CheckBox();
      this.chkHasPartsToFit = new CheckBox();
      this.cboType = new ComboBox();
      this.Label15 = new Label();
      this.txtSearchAddress1 = new TextBox();
      this.Label4 = new Label();
      this.txtSearchPostcode = new TextBox();
      this.txtSearchCustomerName = new TextBox();
      this.txtSearchJobNo = new TextBox();
      this.Label1 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.pnlLegend = new Panel();
      this.Label20 = new Label();
      this.Panel7 = new Panel();
      this.Panel6 = new Panel();
      this.Label19 = new Label();
      this.Label14 = new Label();
      this.Label13 = new Label();
      this.Label12 = new Label();
      this.picLevels = new PictureBox();
      this.picPostalRegions = new PictureBox();
      this.picRegion = new PictureBox();
      this.lblOverdue = new Label();
      this.Label7 = new Label();
      this.Label8 = new Label();
      this.Panel3 = new Panel();
      this.Panel4 = new Panel();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.Panel2 = new Panel();
      this.Panel1 = new Panel();
      this.chkViewAll = new CheckBox();
      this.pnlHeader.SuspendLayout();
      this.pnlControls.SuspendLayout();
      this.pnlTop.SuspendLayout();
      this.dgCalls.BeginInit();
      this.GroupBox1.SuspendLayout();
      this.pnlLegend.SuspendLayout();
      ((ISupportInitialize) this.picLevels).BeginInit();
      ((ISupportInitialize) this.picPostalRegions).BeginInit();
      ((ISupportInitialize) this.picRegion).BeginInit();
      this.SuspendLayout();
      this.splitForm.Dock = DockStyle.Right;
      this.splitForm.Location = new System.Drawing.Point(545, 0);
      this.splitForm.Name = "splitForm";
      this.splitForm.Size = new Size(3, 536);
      this.splitForm.TabIndex = 1;
      this.splitForm.TabStop = false;
      this.mnuVisitAction.MenuItems.AddRange(new MenuItem[1]
      {
        this.mnuView
      });
      this.mnuView.Index = 0;
      this.mnuView.Text = "&View";
      this.pnlHeader.BackColor = Color.SteelBlue;
      this.pnlHeader.Controls.Add((Control) this.lblTitle);
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new Size(205, 20);
      this.pnlHeader.TabIndex = 6;
      this.lblTitle.Dock = DockStyle.Fill;
      this.lblTitle.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = Color.White;
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(205, 20);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Unscheduled Calls";
      this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
      this.pnlControls.Controls.Add((Control) this.pnlTop);
      this.pnlControls.Controls.Add((Control) this.pnlHeader);
      this.pnlControls.Dock = DockStyle.Fill;
      this.pnlControls.Location = new System.Drawing.Point(0, 0);
      this.pnlControls.Name = "pnlControls";
      this.pnlControls.Size = new Size(545, 536);
      this.pnlControls.TabIndex = 0;
      this.pnlTop.Controls.Add((Control) this.dgCalls);
      this.pnlTop.Controls.Add((Control) this.GroupBox1);
      this.pnlTop.Controls.Add((Control) this.pnlLegend);
      this.pnlTop.Dock = DockStyle.Fill;
      this.pnlTop.Location = new System.Drawing.Point(0, 0);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Padding = new Padding(0, 0, 0, 5);
      this.pnlTop.Size = new Size(545, 536);
      this.pnlTop.TabIndex = 12;
      this.dgCalls.AllowDrop = true;
      this.dgCalls.CaptionText = "Holding Area";
      this.dgCalls.ContextMenu = this.mnuVisitAction;
      this.dgCalls.DataMember = "";
      this.dgCalls.Dock = DockStyle.Fill;
      this.dgCalls.HeaderForeColor = SystemColors.ControlText;
      this.dgCalls.Location = new System.Drawing.Point(0, 0);
      this.dgCalls.Name = "dgCalls";
      this.dgCalls.Size = new Size(545, 175);
      this.dgCalls.TabIndex = 1;
      this.GroupBox1.BackColor = Color.White;
      this.GroupBox1.Controls.Add((Control) this.chkViewAll);
      this.GroupBox1.Controls.Add((Control) this.lblQualification);
      this.GroupBox1.Controls.Add((Control) this.cboQualification);
      this.GroupBox1.Controls.Add((Control) this.chkWaitingParts);
      this.GroupBox1.Controls.Add((Control) this.chkPNO);
      this.GroupBox1.Controls.Add((Control) this.TextBox1);
      this.GroupBox1.Controls.Add((Control) this.Label10);
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.cboRegion);
      this.GroupBox1.Controls.Add((Control) this.Label18);
      this.GroupBox1.Controls.Add((Control) this.cboSiteFuel);
      this.GroupBox1.Controls.Add((Control) this.chkDeclined);
      this.GroupBox1.Controls.Add((Control) this.dtpTo);
      this.GroupBox1.Controls.Add((Control) this.dtpFrom);
      this.GroupBox1.Controls.Add((Control) this.Label17);
      this.GroupBox1.Controls.Add((Control) this.Label16);
      this.GroupBox1.Controls.Add((Control) this.chkEstimatedVisitDate);
      this.GroupBox1.Controls.Add((Control) this.chkHasPartsToFit);
      this.GroupBox1.Controls.Add((Control) this.cboType);
      this.GroupBox1.Controls.Add((Control) this.Label15);
      this.GroupBox1.Controls.Add((Control) this.txtSearchAddress1);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.txtSearchPostcode);
      this.GroupBox1.Controls.Add((Control) this.txtSearchCustomerName);
      this.GroupBox1.Controls.Add((Control) this.txtSearchJobNo);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Dock = DockStyle.Bottom;
      this.GroupBox1.Location = new System.Drawing.Point(0, 175);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(545, 229);
      this.GroupBox1.TabIndex = 25;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Filters";
      this.lblQualification.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblQualification.Location = new System.Drawing.Point(216, 140);
      this.lblQualification.Name = "lblQualification";
      this.lblQualification.Size = new Size(81, 18);
      this.lblQualification.TabIndex = 42;
      this.lblQualification.Text = "Qualification";
      this.cboQualification.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboQualification.FormattingEnabled = true;
      this.cboQualification.Location = new System.Drawing.Point(321, 137);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(214, 21);
      this.cboQualification.TabIndex = 41;
      this.chkWaitingParts.Location = new System.Drawing.Point(280, 202);
      this.chkWaitingParts.Name = "chkWaitingParts";
      this.chkWaitingParts.RightToLeft = RightToLeft.No;
      this.chkWaitingParts.Size = new Size((int) byte.MaxValue, 21);
      this.chkWaitingParts.TabIndex = 40;
      this.chkWaitingParts.Text = "Include Waiting For Parts";
      this.chkWaitingParts.UseVisualStyleBackColor = true;
      this.chkPNO.Location = new System.Drawing.Point(280, 180);
      this.chkPNO.Name = "chkPNO";
      this.chkPNO.RightToLeft = RightToLeft.No;
      this.chkPNO.Size = new Size((int) byte.MaxValue, 21);
      this.chkPNO.TabIndex = 39;
      this.chkPNO.Text = "Include Parts Need Ordering";
      this.chkPNO.UseVisualStyleBackColor = true;
      this.TextBox1.Location = new System.Drawing.Point(321, 110);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(214, 21);
      this.TextBox1.TabIndex = 37;
      this.Label10.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label10.Location = new System.Drawing.Point(217, 114);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(80, 16);
      this.Label10.TabIndex = 38;
      this.Label10.Text = "Summary";
      this.Label9.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label9.Location = new System.Drawing.Point(216, 88);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(58, 16);
      this.Label9.TabIndex = 36;
      this.Label9.Text = "Region";
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.FormattingEnabled = true;
      this.cboRegion.Location = new System.Drawing.Point(321, 85);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(214, 21);
      this.cboRegion.TabIndex = 35;
      this.Label18.AutoSize = true;
      this.Label18.Location = new System.Drawing.Point(218, 63);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(56, 13);
      this.Label18.TabIndex = 34;
      this.Label18.Text = "Site Fuel";
      this.cboSiteFuel.FormattingEnabled = true;
      this.cboSiteFuel.Location = new System.Drawing.Point(321, 60);
      this.cboSiteFuel.Name = "cboSiteFuel";
      this.cboSiteFuel.Size = new Size(214, 21);
      this.cboSiteFuel.TabIndex = 33;
      this.chkDeclined.Location = new System.Drawing.Point(6, 201);
      this.chkDeclined.Name = "chkDeclined";
      this.chkDeclined.RightToLeft = RightToLeft.No;
      this.chkDeclined.Size = new Size(249, 23);
      this.chkDeclined.TabIndex = 31;
      this.chkDeclined.Text = "Only Declined jobs - Red Highlight";
      this.chkDeclined.UseVisualStyleBackColor = true;
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpTo.CustomFormat = "dd/MM/yyyy";
      this.dtpTo.Format = DateTimePickerFormat.Custom;
      this.dtpTo.Location = new System.Drawing.Point(399, 35);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(136, 21);
      this.dtpTo.TabIndex = 30;
      this.dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpFrom.CustomFormat = "dd/MM/yyyy";
      this.dtpFrom.Format = DateTimePickerFormat.Custom;
      this.dtpFrom.Location = new System.Drawing.Point(399, 11);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(136, 21);
      this.dtpFrom.TabIndex = 29;
      this.Label17.AutoSize = true;
      this.Label17.Location = new System.Drawing.Point(357, 38);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(20, 13);
      this.Label17.TabIndex = 28;
      this.Label17.Text = "To";
      this.Label16.AutoSize = true;
      this.Label16.Location = new System.Drawing.Point(357, 14);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(36, 13);
      this.Label16.TabIndex = 27;
      this.Label16.Text = "From";
      this.chkEstimatedVisitDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.chkEstimatedVisitDate.Location = new System.Drawing.Point(221, 16);
      this.chkEstimatedVisitDate.Name = "chkEstimatedVisitDate";
      this.chkEstimatedVisitDate.Size = new Size(119, 19);
      this.chkEstimatedVisitDate.TabIndex = 26;
      this.chkEstimatedVisitDate.Text = "Estimated Visit Date";
      this.chkEstimatedVisitDate.UseVisualStyleBackColor = true;
      this.chkHasPartsToFit.Location = new System.Drawing.Point(6, 180);
      this.chkHasPartsToFit.Name = "chkHasPartsToFit";
      this.chkHasPartsToFit.RightToLeft = RightToLeft.No;
      this.chkHasPartsToFit.Size = new Size(268, 20);
      this.chkHasPartsToFit.TabIndex = 6;
      this.chkHasPartsToFit.Text = "Only parts to fit jobs - Orange Highlight";
      this.chkHasPartsToFit.UseVisualStyleBackColor = true;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.FormattingEnabled = true;
      this.cboType.Location = new System.Drawing.Point(111, 110);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(94, 21);
      this.cboType.TabIndex = 5;
      this.Label15.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label15.Location = new System.Drawing.Point(7, 114);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(80, 16);
      this.Label15.TabIndex = 25;
      this.Label15.Text = "Job Type";
      this.txtSearchAddress1.Location = new System.Drawing.Point(111, 86);
      this.txtSearchAddress1.Name = "txtSearchAddress1";
      this.txtSearchAddress1.Size = new Size(94, 21);
      this.txtSearchAddress1.TabIndex = 4;
      this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(7, 90);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(80, 16);
      this.Label4.TabIndex = 24;
      this.Label4.Text = "Address 1";
      this.txtSearchPostcode.Location = new System.Drawing.Point(111, 62);
      this.txtSearchPostcode.Name = "txtSearchPostcode";
      this.txtSearchPostcode.Size = new Size(94, 21);
      this.txtSearchPostcode.TabIndex = 3;
      this.txtSearchCustomerName.Location = new System.Drawing.Point(111, 38);
      this.txtSearchCustomerName.Name = "txtSearchCustomerName";
      this.txtSearchCustomerName.Size = new Size(94, 21);
      this.txtSearchCustomerName.TabIndex = 2;
      this.txtSearchJobNo.Location = new System.Drawing.Point(111, 15);
      this.txtSearchJobNo.Name = "txtSearchJobNo";
      this.txtSearchJobNo.Size = new Size(94, 21);
      this.txtSearchJobNo.TabIndex = 1;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(7, 66);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 21);
      this.Label1.TabIndex = 22;
      this.Label1.Text = "Postcode";
      this.Label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(7, 17);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 16);
      this.Label3.TabIndex = 20;
      this.Label3.Text = "Job No";
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(7, 40);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(104, 21);
      this.Label2.TabIndex = 19;
      this.Label2.Text = "Customer Name";
      this.pnlLegend.BackColor = Color.White;
      this.pnlLegend.Controls.Add((Control) this.Label20);
      this.pnlLegend.Controls.Add((Control) this.Panel7);
      this.pnlLegend.Controls.Add((Control) this.Panel6);
      this.pnlLegend.Controls.Add((Control) this.Label19);
      this.pnlLegend.Controls.Add((Control) this.Label14);
      this.pnlLegend.Controls.Add((Control) this.Label13);
      this.pnlLegend.Controls.Add((Control) this.Label12);
      this.pnlLegend.Controls.Add((Control) this.picLevels);
      this.pnlLegend.Controls.Add((Control) this.picPostalRegions);
      this.pnlLegend.Controls.Add((Control) this.picRegion);
      this.pnlLegend.Controls.Add((Control) this.lblOverdue);
      this.pnlLegend.Controls.Add((Control) this.Label7);
      this.pnlLegend.Controls.Add((Control) this.Label8);
      this.pnlLegend.Controls.Add((Control) this.Panel3);
      this.pnlLegend.Controls.Add((Control) this.Panel4);
      this.pnlLegend.Controls.Add((Control) this.Label6);
      this.pnlLegend.Controls.Add((Control) this.Label5);
      this.pnlLegend.Controls.Add((Control) this.Panel2);
      this.pnlLegend.Controls.Add((Control) this.Panel1);
      this.pnlLegend.Dock = DockStyle.Bottom;
      this.pnlLegend.Location = new System.Drawing.Point(0, 404);
      this.pnlLegend.Name = "pnlLegend";
      this.pnlLegend.Size = new Size(545, (int) sbyte.MaxValue);
      this.pnlLegend.TabIndex = 24;
      this.Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label20.Font = new Font("Verdana", 8f);
      this.Label20.Location = new System.Drawing.Point(328, 103);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(192, 16);
      this.Label20.TabIndex = 23;
      this.Label20.Text = "Service overdue on site";
      this.Panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel7.BackColor = Color.Orange;
      this.Panel7.Location = new System.Drawing.Point(304, 101);
      this.Panel7.Name = "Panel7";
      this.Panel7.Size = new Size(16, 16);
      this.Panel7.TabIndex = 22;
      this.Panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel6.BackColor = Color.Red;
      this.Panel6.Location = new System.Drawing.Point(8, 101);
      this.Panel6.Name = "Panel6";
      this.Panel6.Size = new Size(16, 16);
      this.Panel6.TabIndex = 21;
      this.Label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label19.Font = new Font("Verdana", 8f);
      this.Label19.Location = new System.Drawing.Point(32, 101);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(192, 16);
      this.Label19.TabIndex = 22;
      this.Label19.Text = "Visit is extremely late";
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label14.Font = new Font("Verdana", 8f);
      this.Label14.Location = new System.Drawing.Point(328, 85);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(192, 16);
      this.Label14.TabIndex = 18;
      this.Label14.Text = "Qualification check passed";
      this.Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label13.Font = new Font("Verdana", 8f);
      this.Label13.Location = new System.Drawing.Point(328, 69);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(216, 16);
      this.Label13.TabIndex = 17;
      this.Label13.Text = "Postal region check passed";
      this.Label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label12.Font = new Font("Verdana", 8f);
      this.Label12.Location = new System.Drawing.Point(328, 53);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(192, 16);
      this.Label12.TabIndex = 16;
      this.Label12.Text = "Region check passed";
      this.picLevels.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.picLevels.BackColor = Color.Transparent;
      this.picLevels.Image = (Image) componentResourceManager.GetObject("picLevels.Image");
      this.picLevels.Location = new System.Drawing.Point(304, 85);
      this.picLevels.Name = "picLevels";
      this.picLevels.Size = new Size(16, 16);
      this.picLevels.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picLevels.TabIndex = 14;
      this.picLevels.TabStop = false;
      this.picPostalRegions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.picPostalRegions.BackColor = Color.Transparent;
      this.picPostalRegions.Image = (Image) componentResourceManager.GetObject("picPostalRegions.Image");
      this.picPostalRegions.Location = new System.Drawing.Point(304, 69);
      this.picPostalRegions.Name = "picPostalRegions";
      this.picPostalRegions.Size = new Size(16, 16);
      this.picPostalRegions.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picPostalRegions.TabIndex = 13;
      this.picPostalRegions.TabStop = false;
      this.picRegion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.picRegion.BackColor = Color.Transparent;
      this.picRegion.Image = (Image) componentResourceManager.GetObject("picRegion.Image");
      this.picRegion.Location = new System.Drawing.Point(304, 53);
      this.picRegion.Name = "picRegion";
      this.picRegion.Size = new Size(16, 16);
      this.picRegion.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picRegion.TabIndex = 12;
      this.picRegion.TabStop = false;
      this.lblOverdue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblOverdue.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOverdue.ForeColor = Color.Black;
      this.lblOverdue.Location = new System.Drawing.Point(0, 3);
      this.lblOverdue.Name = "lblOverdue";
      this.lblOverdue.Size = new Size(545, 32);
      this.lblOverdue.TabIndex = 11;
      this.lblOverdue.Text = "There are no contract jobs overdue.";
      this.lblOverdue.TextAlign = ContentAlignment.MiddleCenter;
      this.Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label7.Font = new Font("Verdana", 8f);
      this.Label7.Location = new System.Drawing.Point(32, 85);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(192, 16);
      this.Label7.TabIndex = 7;
      this.Label7.Text = "Booked Schedule Period";
      this.Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label8.Font = new Font("Verdana", 8f);
      this.Label8.Location = new System.Drawing.Point(32, 69);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(192, 16);
      this.Label8.TabIndex = 6;
      this.Label8.Text = "Free Schedule Period";
      this.Panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel3.BackColor = Color.LightSteelBlue;
      this.Panel3.Location = new System.Drawing.Point(8, 85);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(16, 16);
      this.Panel3.TabIndex = 5;
      this.Panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel4.BackColor = Color.FromArgb(224, 224, 224);
      this.Panel4.Location = new System.Drawing.Point(8, 69);
      this.Panel4.Name = "Panel4";
      this.Panel4.Size = new Size(16, 16);
      this.Panel4.TabIndex = 4;
      this.Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label6.Font = new Font("Verdana", 8f);
      this.Label6.Location = new System.Drawing.Point(32, 53);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(192, 16);
      this.Label6.TabIndex = 3;
      this.Label6.Text = "Some job tests failed";
      this.Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label5.Font = new Font("Verdana", 8f);
      this.Label5.Location = new System.Drawing.Point(32, 37);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(192, 16);
      this.Label5.TabIndex = 2;
      this.Label5.Text = "All job tests passed";
      this.Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel2.BackColor = Color.Coral;
      this.Panel2.Location = new System.Drawing.Point(8, 53);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(16, 16);
      this.Panel2.TabIndex = 1;
      this.Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel1.BackColor = Color.LightGreen;
      this.Panel1.Location = new System.Drawing.Point(8, 37);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(16, 16);
      this.Panel1.TabIndex = 0;
      this.chkViewAll.AutoCheck = false;
      this.chkViewAll.Location = new System.Drawing.Point(10, 140);
      this.chkViewAll.Name = "chkViewAll";
      this.chkViewAll.RightToLeft = RightToLeft.No;
      this.chkViewAll.Size = new Size(195, 20);
      this.chkViewAll.TabIndex = 43;
      this.chkViewAll.Text = "View All Visits";
      this.chkViewAll.UseVisualStyleBackColor = true;
      this.BackColor = Color.WhiteSmoke;
      this.Controls.Add((Control) this.pnlControls);
      this.Controls.Add((Control) this.splitForm);
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (pnlUnscheduledCalls);
      this.Size = new Size(548, 536);
      this.pnlHeader.ResumeLayout(false);
      this.pnlControls.ResumeLayout(false);
      this.pnlTop.ResumeLayout(false);
      this.dgCalls.EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.pnlLegend.ResumeLayout(false);
      ((ISupportInitialize) this.picLevels).EndInit();
      ((ISupportInitialize) this.picPostalRegions).EndInit();
      ((ISupportInitialize) this.picRegion).EndInit();
      this.ResumeLayout(false);
    }

    public DataView CallsDataview
    {
      get
      {
        return this._dvunsched;
      }
      set
      {
        this._dvunsched = value;
      }
    }

    public DataTable unscheduledCalls
    {
      get
      {
        return this._dtUnscheduledCalls;
      }
      set
      {
        this._dtUnscheduledCalls = value;
        this.CallsDataview = new DataView(this._dtUnscheduledCalls);
        this.dgCalls.DataSource = (object) this.CallsDataview;
        this.setOverdueLabel();
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgCalls.CurrentRowIndex != -1 ? this.CallsDataview[this.dgCalls.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public new Size MinimumSize
    {
      get
      {
        return new Size(208, 536);
      }
    }

    public void setOverdueLabel()
    {
      try
      {
        short count = checked ((short) new DataView(this._dtUnscheduledCalls)
        {
          RowFilter = string.Format("EstimatedVisitDate <= '{0}'", (object) Strings.Format((object) DateAndTime.Now, "yyyy/MM/dd"))
        }.Count);
        if (count > (short) 1)
        {
          this.lblOverdue.Text = string.Format("There are {0} contract jobs overdue.", (object) count);
          this.lblOverdue.ForeColor = Color.Red;
        }
        else if (count == (short) 1)
        {
          this.lblOverdue.Text = string.Format("There is 1 contract job overdue.", (object) count);
          this.lblOverdue.ForeColor = Color.Red;
        }
        else
        {
          if (count != (short) 0)
            return;
          this.lblOverdue.Text = "There are no contract job overdue.";
          this.lblOverdue.ForeColor = Color.Black;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.lblOverdue.Text = "There are no contract job overdue.";
        this.lblOverdue.ForeColor = Color.Black;
        ProjectData.ClearProjectError();
      }
    }

    private void pnlUnscheduledCalls_Load(object sender, EventArgs e)
    {
      this.SetUpCallsDataGrid();
      this.isLoading = true;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboSiteFuel = this.cboSiteFuel;
      Combo.SetUpCombo(ref cboSiteFuel, App.DB.Picklists.GetAll(Enums.PickListTypes.GasTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSiteFuel = cboSiteFuel;
      ComboBox c;
      if (App.loggedInUser.UserRegions.Count > 0)
      {
        c = this.cboRegion;
        Combo.SetUpCombo(ref c, App.loggedInUser.UserRegions.Table, "RegionID", "Name", Enums.ComboValues.No_Filter);
        this.cboRegion = c;
      }
      else
      {
        ComboBox cboRegion = this.cboRegion;
        Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
        this.cboRegion = cboRegion;
      }
      this.chkHasPartsToFit.Checked = false;
      this.chkEstimatedVisitDate.Checked = true;
      this.chkPNO.Checked = true;
      this.dtpTo.Value = DateAndTime.Now.AddDays(14.0);
      this.dtpFrom.Value = DateAndTime.Now.AddYears(-2);
      c = this.cboQualification;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = c;
      if (true == App.IsRFT)
      {
        this.lblQualification.Text = "Trade";
      }
      else
      {
        this.lblQualification.Text = "Qualification";
        this.lblQualification.Visible = false;
        this.cboQualification.Visible = false;
      }
      this.isLoading = false;
    }

    private void SetUpCallsDataGrid()
    {
      double num = 1.0;
      switch (this.TEXTSIZE)
      {
        case 8:
          num = 1.1;
          break;
        case 9:
          num = 1.15;
          break;
        case 10:
          num = 1.2;
          break;
        case 11:
          num = 1.25;
          break;
        case 12:
          num = 1.3;
          break;
      }
      ModScheduler.SetUpSchedulerDataGrid(this.dgCalls, true);
      DataGridTableStyle tableStyle = this.dgCalls.TableStyles[0];
      tableStyle.DataGrid.Font = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      tableStyle.DataGrid.HeaderFont = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ColourColumn colourColumn = new ColourColumn();
      colourColumn.Format = "";
      colourColumn.FormatInfo = (IFormatProvider) null;
      colourColumn.HeaderText = "";
      colourColumn.MappingName = "PartsToFit";
      colourColumn.ReadOnly = true;
      colourColumn.Width = checked ((int) Math.Round(unchecked (10.0 * num)));
      colourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) colourColumn);
      UnscheduledCallsColumn unscheduledCallsColumn1 = new UnscheduledCallsColumn();
      unscheduledCallsColumn1.Format = "";
      unscheduledCallsColumn1.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn1.HeaderText = "Job No";
      unscheduledCallsColumn1.MappingName = "JobNumber";
      unscheduledCallsColumn1.ReadOnly = true;
      unscheduledCallsColumn1.Width = checked ((int) Math.Round(unchecked (55.0 * num)));
      unscheduledCallsColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn1);
      UnscheduledCallsColumn unscheduledCallsColumn2 = new UnscheduledCallsColumn();
      unscheduledCallsColumn2.Format = "";
      unscheduledCallsColumn2.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn2.HeaderText = "Address";
      unscheduledCallsColumn2.MappingName = "Address1";
      unscheduledCallsColumn2.ReadOnly = true;
      unscheduledCallsColumn2.Width = checked ((int) Math.Round(unchecked (95.0 * num)));
      unscheduledCallsColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn2);
      UnscheduledCallsColumn unscheduledCallsColumn3 = new UnscheduledCallsColumn();
      unscheduledCallsColumn3.Format = "";
      unscheduledCallsColumn3.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn3.HeaderText = "Postcode";
      unscheduledCallsColumn3.MappingName = "PostCode";
      unscheduledCallsColumn3.ReadOnly = true;
      unscheduledCallsColumn3.Width = checked ((int) Math.Round(unchecked (65.0 * num)));
      unscheduledCallsColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn3);
      UnscheduledCallsColumn unscheduledCallsColumn4 = new UnscheduledCallsColumn();
      unscheduledCallsColumn4.Format = "";
      unscheduledCallsColumn4.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn4.HeaderText = "Job Summary";
      unscheduledCallsColumn4.MappingName = "JobItems";
      unscheduledCallsColumn4.ReadOnly = true;
      unscheduledCallsColumn4.Width = checked ((int) Math.Round(unchecked (100.0 * num)));
      unscheduledCallsColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn4);
      UnscheduledCallsColumn unscheduledCallsColumn5 = new UnscheduledCallsColumn();
      unscheduledCallsColumn5.Format = "";
      unscheduledCallsColumn5.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn5.HeaderText = "Fuel";
      unscheduledCallsColumn5.MappingName = "SiteFuel";
      unscheduledCallsColumn5.ReadOnly = true;
      unscheduledCallsColumn5.Width = checked ((int) Math.Round(unchecked (30.0 * num)));
      unscheduledCallsColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn5);
      UnscheduledCallsColumn unscheduledCallsColumn6 = new UnscheduledCallsColumn();
      unscheduledCallsColumn6.Format = "";
      unscheduledCallsColumn6.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn6.HeaderText = "Notes";
      unscheduledCallsColumn6.MappingName = "NotesToEngineer";
      unscheduledCallsColumn6.ReadOnly = true;
      unscheduledCallsColumn6.Width = checked ((int) Math.Round(unchecked (200.0 * num)));
      unscheduledCallsColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn6);
      UnscheduledCallsColumn unscheduledCallsColumn7 = new UnscheduledCallsColumn();
      unscheduledCallsColumn7.Format = "";
      unscheduledCallsColumn7.FormatInfo = (IFormatProvider) null;
      if (true == App.IsRFT)
        unscheduledCallsColumn7.HeaderText = "Trade";
      else
        unscheduledCallsColumn7.HeaderText = "Qualification";
      unscheduledCallsColumn7.MappingName = "Qualification";
      unscheduledCallsColumn7.ReadOnly = true;
      unscheduledCallsColumn7.Width = checked ((int) Math.Round(unchecked (75.0 * num)));
      unscheduledCallsColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn7);
      UnscheduledCallsColumn unscheduledCallsColumn8 = new UnscheduledCallsColumn();
      unscheduledCallsColumn8.Format = "";
      unscheduledCallsColumn8.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn8.HeaderText = "Due Date";
      unscheduledCallsColumn8.MappingName = "DueDate";
      unscheduledCallsColumn8.ReadOnly = true;
      unscheduledCallsColumn8.Width = checked ((int) Math.Round(unchecked (75.0 * num)));
      unscheduledCallsColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn8);
      UnscheduledCallsColumn unscheduledCallsColumn9 = new UnscheduledCallsColumn();
      unscheduledCallsColumn9.Format = "";
      unscheduledCallsColumn9.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn9.HeaderText = "";
      unscheduledCallsColumn9.MappingName = "AMPM";
      unscheduledCallsColumn9.ReadOnly = true;
      unscheduledCallsColumn9.Width = checked ((int) Math.Round(unchecked (25.0 * num)));
      unscheduledCallsColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn9);
      UnscheduledCallsColumn unscheduledCallsColumn10 = new UnscheduledCallsColumn();
      unscheduledCallsColumn10.Format = "";
      unscheduledCallsColumn10.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn10.HeaderText = "Customer";
      unscheduledCallsColumn10.MappingName = "customername";
      unscheduledCallsColumn10.ReadOnly = true;
      unscheduledCallsColumn10.Width = checked ((int) Math.Round(unchecked (100.0 * num)));
      unscheduledCallsColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn10);
      DataGridJobTypeColumn gridJobTypeColumn = new DataGridJobTypeColumn();
      gridJobTypeColumn.Format = "";
      gridJobTypeColumn.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn.HeaderText = "Type";
      gridJobTypeColumn.MappingName = "Type";
      gridJobTypeColumn.ReadOnly = true;
      gridJobTypeColumn.Width = checked ((int) Math.Round(unchecked (75.0 * num)));
      gridJobTypeColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn);
      UnscheduledCallsColumn unscheduledCallsColumn11 = new UnscheduledCallsColumn();
      unscheduledCallsColumn11.Format = "";
      unscheduledCallsColumn11.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn11.HeaderText = "SOR Time";
      unscheduledCallsColumn11.MappingName = "SummedSOR";
      unscheduledCallsColumn11.ReadOnly = true;
      unscheduledCallsColumn11.Width = checked ((int) Math.Round(unchecked (50.0 * num)));
      unscheduledCallsColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn11);
      UnscheduledCallsColumn unscheduledCallsColumn12 = new UnscheduledCallsColumn();
      unscheduledCallsColumn12.Format = "dd/MM/yyyy";
      unscheduledCallsColumn12.FormatInfo = (IFormatProvider) null;
      unscheduledCallsColumn12.HeaderText = "Est Date";
      unscheduledCallsColumn12.MappingName = "EstimatedVisitDate";
      unscheduledCallsColumn12.ReadOnly = true;
      unscheduledCallsColumn12.Width = checked ((int) Math.Round(unchecked (75.0 * num)));
      unscheduledCallsColumn12.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unscheduledCallsColumn12);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "UnscheduledWork";
      this.dgCalls.TableStyles.Add(tableStyle);
    }

    public void clearSelections()
    {
      try
      {
        int num = checked (((DataView) this.dgCalls.DataSource).Count - 1);
        int row = 0;
        while (row <= num)
        {
          this.dgCalls.UnSelect(row);
          checked { ++row; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void TextBox_Filter(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void chkHasPartsToFit_CheckedChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    public void ApplyFilters()
    {
      if (this.isLoading)
        return;
      string str = "postcode like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(this.txtSearchPostcode.Text)) + "%' AND " + "Address1 like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(this.txtSearchAddress1.Text)) + "%' AND " + "JobNumber like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(this.txtSearchJobNo.Text)) + "%' AND " + "customername like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(this.txtSearchCustomerName.Text)) + "%' AND " + "JobItems like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(this.TextBox1.Text)) + "%' ";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
        str = str + "AND JobTypeID = " + Combo.get_GetSelectedItemValue(this.cboType) + " ";
      if (this.chkHasPartsToFit.Checked)
        str += "AND PartsToFit <> 0 ";
      if (this.chkDeclined.Checked)
        str += "AND FollowUpDeclined <> 0 ";
      if (!this.chkPNO.Checked)
        str += "AND PartsNeedOrdering = 0 ";
      if (!this.chkWaitingParts.Checked)
        str += "AND WaitingForParts = 0 ";
      if (!this.chkHasPartsToFit.Checked)
      {
        if (this.chkEstimatedVisitDate.Checked)
        {
          this.dtpFrom.Enabled = true;
          this.dtpTo.Enabled = true;
          string[] strArray = new string[6]
          {
            str,
            " AND ((EstimatedVisitDate >= '",
            null,
            null,
            null,
            null
          };
          DateTime dateTime = this.dtpFrom.Value;
          strArray[2] = Strings.Format((object) dateTime.Date, "dd-MMM-yyyy 00:00:00");
          strArray[3] = "' AND EstimatedVisitDate <= '";
          dateTime = this.dtpTo.Value;
          strArray[4] = Strings.Format((object) dateTime.Date, "dd-MMM-yyyy 23:59:59");
          strArray[5] = "') OR (EstimatedVisitDate IS NULL))";
          str = string.Concat(strArray);
        }
        else
        {
          this.dtpFrom.Enabled = false;
          this.dtpTo.Enabled = false;
          this.dtpFrom.Value = DateAndTime.Now;
          this.dtpTo.Value = DateAndTime.Now;
        }
      }
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSiteFuel), "0", false) > 0U)
        str = str + " AND FuelID = '" + Combo.get_GetSelectedItemValue(this.cboSiteFuel) + "' ";
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboRegion), "0", false) > 0U)
        str = str + " AND RegionID = " + Combo.get_GetSelectedItemValue(this.cboRegion) + " ";
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboQualification), "0", false) > 0U)
        str = str + " AND QualificationID = " + Combo.get_GetSelectedItemValue(this.cboQualification) + " ";
      if (this.CallsDataview != null)
        this.CallsDataview.RowFilter = str;
    }

    private void pnlUnscheduledCalls_Resize(object sender, EventArgs e)
    {
      Size minimumSize;
      if (this.Height < this.MinimumSize.Height)
      {
        minimumSize = this.MinimumSize;
        this.Height = minimumSize.Height;
      }
      int width1 = this.Width;
      minimumSize = this.MinimumSize;
      int width2 = minimumSize.Width;
      if (width1 < width2)
      {
        minimumSize = this.MinimumSize;
        this.Width = minimumSize.Width;
      }
      this.pnlTop.Height = checked ((int) Math.Round(unchecked ((double) this.Height * 0.7)));
    }

    private void splitForm_MouseDown(object sender, MouseEventArgs e)
    {
      this.mousePosDownX = e.X;
    }

    private void splitForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.mousePosDownX == -1)
        return;
      checked { this.Width += e.X - this.mousePosDownX; }
    }

    private void splitForm_MouseUp(object sender, MouseEventArgs e)
    {
      this.mousePosDownX = -1;
    }

    private void dgCalls_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        try
        {
          App.ShowForm(typeof (FRMLogCallout), true, new object[5]
          {
            this.SelectedDataRow["JobID"],
            this.SelectedDataRow["SiteID"],
            (object) this,
            null,
            this.SelectedDataRow["EngineerVisitID"]
          }, false);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void chkEstimatedVisitDate_CheckedChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void dtpTo_ValueChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void chkDeclined_CheckedChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void cboSiteFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void chkPNO_CheckedChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void chkWaitingParts_CheckedChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void cboQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ApplyFilters();
    }

    private void chkViewAll_Click(object sender, EventArgs e)
    {
      this.chkViewAll.Checked = !this.chkViewAll.Checked;
    }

    public class createdTypeColour : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        string Left = Conversions.ToString(((DataRow) source.List[rowNum])["createdType"]);
        Brush brush;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "manual", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "recent", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "generated", false) == 0)
              brush = (Brush) new SolidBrush(Color.LightYellow);
          }
          else
            brush = (Brush) new SolidBrush(Color.LightGreen);
        }
        else
          brush = (Brush) new SolidBrush(Color.LightBlue);
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
      }
    }
  }
}
