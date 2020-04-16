// Decompiled with JetBrains decompiler
// Type: FSM.FRMBatchGSRPrint
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
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
  public class FRMBatchGSRPrint : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvVisits;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Sites.Site _oSite;

    public FRMBatchGSRPrint()
    {
      this.Load += new EventHandler(this.FRMVisitManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDefinition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkVisitDate
    {
      get
      {
        return this._chkVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkVisitDate_CheckedChanged);
        CheckBox chkVisitDate1 = this._chkVisitDate;
        if (chkVisitDate1 != null)
          chkVisitDate1.CheckedChanged -= eventHandler;
        this._chkVisitDate = value;
        CheckBox chkVisitDate2 = this._chkVisitDate;
        if (chkVisitDate2 == null)
          return;
        chkVisitDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineerVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgVisits
    {
      get
      {
        return this._dgVisits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgVisits_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgVisits_DoubleClick);
        DataGrid dgVisits1 = this._dgVisits;
        if (dgVisits1 != null)
        {
          dgVisits1.MouseUp -= mouseEventHandler;
          dgVisits1.DoubleClick -= eventHandler;
        }
        this._dgVisits = value;
        DataGrid dgVisits2 = this._dgVisits;
        if (dgVisits2 == null)
          return;
        dgVisits2.MouseUp += mouseEventHandler;
        dgVisits2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
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

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUnselect
    {
      get
      {
        return this._btnUnselect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnselect_Click);
        Button btnUnselect1 = this._btnUnselect;
        if (btnUnselect1 != null)
          btnUnselect1.Click -= eventHandler;
        this._btnUnselect = value;
        Button btnUnselect2 = this._btnUnselect;
        if (btnUnselect2 == null)
          return;
        btnUnselect2.Click += eventHandler;
      }
    }

    internal virtual Button btnSelectAll
    {
      get
      {
        return this._btnSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAll_Click);
        Button btnSelectAll1 = this._btnSelectAll;
        if (btnSelectAll1 != null)
          btnSelectAll1.Click -= eventHandler;
        this._btnSelectAll = value;
        Button btnSelectAll2 = this._btnSelectAll;
        if (btnSelectAll2 == null)
          return;
        btnSelectAll2.Click += eventHandler;
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

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExport_Click);
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

    internal virtual CheckBox chkPrintHdr { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkExceptionsOnly { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnShowdata
    {
      get
      {
        return this._btnShowdata;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowdata_Click);
        Button btnShowdata1 = this._btnShowdata;
        if (btnShowdata1 != null)
          btnShowdata1.Click -= eventHandler;
        this._btnShowdata = value;
        Button btnShowdata2 = this._btnShowdata;
        if (btnShowdata2 == null)
          return;
        btnShowdata2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerVisits = new GroupBox();
      this.dgVisits = new DataGrid();
      this.grpFilter = new GroupBox();
      this.chkExceptionsOnly = new CheckBox();
      this.chkPrintHdr = new CheckBox();
      this.btnUnselect = new Button();
      this.btnSelectAll = new Button();
      this.btnShowdata = new Button();
      this.cboOutcome = new ComboBox();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.txtPostcode = new TextBox();
      this.Label1 = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtJobNumber = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkVisitDate = new CheckBox();
      this.Label6 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboDefinition = new ComboBox();
      this.cboStatus = new ComboBox();
      this.Label13 = new Label();
      this.btnPrint = new Button();
      this.btnExport = new Button();
      this.grpEngineerVisits.SuspendLayout();
      this.dgVisits.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerVisits.Controls.Add((Control) this.dgVisits);
      this.grpEngineerVisits.Location = new System.Drawing.Point(8, 256);
      this.grpEngineerVisits.Name = "grpEngineerVisits";
      this.grpEngineerVisits.Size = new Size(784, 205);
      this.grpEngineerVisits.TabIndex = 2;
      this.grpEngineerVisits.TabStop = false;
      this.grpEngineerVisits.Text = "Double Click To View / Edit";
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(8, 18);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(768, 179);
      this.dgVisits.TabIndex = 14;
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.chkExceptionsOnly);
      this.grpFilter.Controls.Add((Control) this.chkPrintHdr);
      this.grpFilter.Controls.Add((Control) this.btnUnselect);
      this.grpFilter.Controls.Add((Control) this.btnSelectAll);
      this.grpFilter.Controls.Add((Control) this.btnShowdata);
      this.grpFilter.Controls.Add((Control) this.cboOutcome);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.txtPostcode);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkVisitDate);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboDefinition);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.Label13);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(784, 224);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.chkExceptionsOnly.AutoSize = true;
      this.chkExceptionsOnly.Location = new System.Drawing.Point(361, 197);
      this.chkExceptionsOnly.Name = "chkExceptionsOnly";
      this.chkExceptionsOnly.Size = new Size(147, 17);
      this.chkExceptionsOnly.TabIndex = 39;
      this.chkExceptionsOnly.Text = "Only Print Exceptions";
      this.chkExceptionsOnly.UseVisualStyleBackColor = true;
      this.chkPrintHdr.AutoSize = true;
      this.chkPrintHdr.Location = new System.Drawing.Point(216, 197);
      this.chkPrintHdr.Name = "chkPrintHdr";
      this.chkPrintHdr.Size = new Size(129, 17);
      this.chkPrintHdr.TabIndex = 38;
      this.chkPrintHdr.Text = "Print Header Page";
      this.chkPrintHdr.UseVisualStyleBackColor = true;
      this.btnUnselect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUnselect.Location = new System.Drawing.Point(113, 192);
      this.btnUnselect.Name = "btnUnselect";
      this.btnUnselect.Size = new Size(96, 23);
      this.btnUnselect.TabIndex = 37;
      this.btnUnselect.Text = "Unselect All";
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.Location = new System.Drawing.Point(11, 192);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(96, 23);
      this.btnSelectAll.TabIndex = 36;
      this.btnSelectAll.Text = "Select All";
      this.btnShowdata.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnShowdata.Location = new System.Drawing.Point(679, 192);
      this.btnShowdata.Name = "btnShowdata";
      this.btnShowdata.Size = new Size(96, 23);
      this.btnShowdata.TabIndex = 35;
      this.btnShowdata.Text = "Show Data";
      this.cboOutcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOutcome.Location = new System.Drawing.Point(600, 115);
      this.cboOutcome.Name = "cboOutcome";
      this.cboOutcome.Size = new Size(176, 21);
      this.cboOutcome.TabIndex = 34;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(736, 19);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(104, 19);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(624, 21);
      this.txtCustomer.TabIndex = 1;
      this.Label4.Location = new System.Drawing.Point(8, 16);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 27;
      this.Label4.Text = "Customer";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPostcode.Location = new System.Drawing.Point(104, 67);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(184, 21);
      this.txtPostcode.TabIndex = 5;
      this.Label1.Location = new System.Drawing.Point(8, 64);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Postcode";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(736, 43);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(104, 43);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(624, 21);
      this.txtSite.TabIndex = 3;
      this.dtpTo.Location = new System.Drawing.Point(144, 163);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(144, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Location = new System.Drawing.Point(144, 139);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(144, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtJobNumber.Location = new System.Drawing.Point(104, 115);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(184, 21);
      this.txtJobNumber.TabIndex = 9;
      this.Label9.Location = new System.Drawing.Point(104, 160);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(104, 136);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkVisitDate.Cursor = Cursors.Hand;
      this.chkVisitDate.Location = new System.Drawing.Point(8, 136);
      this.chkVisitDate.Name = "chkVisitDate";
      this.chkVisitDate.Size = new Size(80, 24);
      this.chkVisitDate.TabIndex = 11;
      this.chkVisitDate.Text = "Visit Date";
      this.chkVisitDate.UseVisualStyleBackColor = true;
      this.Label6.Location = new System.Drawing.Point(8, 112);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Job Number";
      this.Label3.Location = new System.Drawing.Point(8, 88);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 16);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Definition";
      this.Label2.Location = new System.Drawing.Point(8, 40);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Site";
      this.Label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label10.Location = new System.Drawing.Point(296, 92);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 16);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(344, 91);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(184, 21);
      this.cboType.TabIndex = 7;
      this.Label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label11.Location = new System.Drawing.Point(536, 95);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 16);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboDefinition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDefinition.Location = new System.Drawing.Point(104, 92);
      this.cboDefinition.Name = "cboDefinition";
      this.cboDefinition.Size = new Size(184, 21);
      this.cboDefinition.TabIndex = 6;
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(600, 91);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(176, 21);
      this.cboStatus.TabIndex = 8;
      this.Label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label13.Location = new System.Drawing.Point(536, 118);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(64, 16);
      this.Label13.TabIndex = 33;
      this.Label13.Text = "Outcome";
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(692, 467);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(96, 23);
      this.btnPrint.TabIndex = 36;
      this.btnPrint.Text = "Print GSRs";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(16, 467);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(96, 23);
      this.btnExport.TabIndex = 37;
      this.btnExport.Text = "Export";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 494);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.grpEngineerVisits);
      this.Controls.Add((Control) this.grpFilter);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMBatchGSRPrint);
      this.Text = "Batch GSR Print";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerVisits, 0);
      this.Controls.SetChildIndex((Control) this.btnPrint, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.grpEngineerVisits.ResumeLayout(false);
      this.dgVisits.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboDefinition = this.cboDefinition;
      Combo.SetUpCombo(ref cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboDefinition = cboDefinition;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetUpCombo(ref cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboOutcome = cboOutcome;
      this.SetupVisitDataGrid();
      this.PopulateDatagrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private DataView VisitsDataview
    {
      get
      {
        return this._dvVisits;
      }
      set
      {
        this._dvVisits = value;
        this._dvVisits.AllowNew = false;
        this._dvVisits.AllowEdit = false;
        this._dvVisits.AllowDelete = false;
        this._dvVisits.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
        this.dgVisits.DataSource = (object) this.VisitsDataview;
      }
    }

    private DataRow SelectedVisitDataRow
    {
      get
      {
        return this.dgVisits.CurrentRowIndex != -1 ? this.VisitsDataview[this.dgVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public FSM.Entity.Customers.Customer theCustomer
    {
      get
      {
        return this._theCustomer;
      }
      set
      {
        this._theCustomer = value;
        this.theSite = (FSM.Entity.Sites.Site) null;
        if (this._theCustomer != null)
        {
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
          this.btnFindSite.Enabled = true;
        }
        else
        {
          this.txtCustomer.Text = "";
          this.btnFindSite.Enabled = false;
        }
      }
    }

    public FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._oSite;
      }
      set
      {
        this._oSite = value;
        if (this._oSite != null)
          this.txtSite.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSite.Text = "";
      }
    }

    private void SetupVisitDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn1 = new DataGridBoolColumn();
      dataGridBoolColumn1.HeaderText = "";
      dataGridBoolColumn1.MappingName = "tick";
      dataGridBoolColumn1.ReadOnly = true;
      dataGridBoolColumn1.Width = 25;
      dataGridBoolColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn1);
      DataGridBoolColumn dataGridBoolColumn2 = new DataGridBoolColumn();
      dataGridBoolColumn2.HeaderText = "Sending Email";
      dataGridBoolColumn2.MappingName = "EmailSend";
      dataGridBoolColumn2.ReadOnly = true;
      dataGridBoolColumn2.Width = 75;
      dataGridBoolColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn2);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Customer";
      dataGridLabelColumn1.MappingName = "Customer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Site";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Postcode";
      dataGridLabelColumn3.MappingName = "SitePostcode";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Job Number";
      dataGridLabelColumn4.MappingName = "JobNumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "PO Number";
      dataGridLabelColumn5.MappingName = "PONumber";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Definition";
      dataGridLabelColumn6.MappingName = "JobDefinition";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Type";
      dataGridLabelColumn7.MappingName = "Type";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Status";
      dataGridLabelColumn8.MappingName = "VisitStatus";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Outcome";
      dataGridLabelColumn9.MappingName = "VisitOutcome";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MMM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Estimated Visit Date";
      dataGridLabelColumn10.MappingName = "EstimatedVisitDate";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 100;
      dataGridLabelColumn10.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "dd/MMM/yyyy";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Scheduled Date";
      dataGridLabelColumn11.MappingName = "StartDateTime";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 100;
      dataGridLabelColumn11.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Engineer";
      dataGridLabelColumn12.MappingName = "Engineer";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 75;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "C";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Visit Value";
      dataGridLabelColumn13.MappingName = "VisitValue";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 75;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "C";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Visit Charge";
      dataGridLabelColumn14.MappingName = "VisitCharge";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 200;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "C";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "Engineer Cost";
      dataGridLabelColumn15.MappingName = "EngineerCost";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 100;
      dataGridLabelColumn15.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
      dataGridLabelColumn16.Format = "C";
      dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn16.HeaderText = "Part\\Product Cost";
      dataGridLabelColumn16.MappingName = "PartProductCost";
      dataGridLabelColumn16.ReadOnly = true;
      dataGridLabelColumn16.Width = 100;
      dataGridLabelColumn16.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
      DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
      dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn17.HeaderText = "DefectCount";
      dataGridLabelColumn17.MappingName = "DefectCount";
      dataGridLabelColumn17.ReadOnly = true;
      dataGridLabelColumn17.Width = 100;
      dataGridLabelColumn17.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    private void FRMVisitManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.theCustomer.CustomerID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theSite = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void chkVisitDate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkVisitDate.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today;
        this.dtpTo.Value = DateAndTime.Today;
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void btnShowdata_Click(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void dgVisits_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgVisits.HitTest(e.X, e.Y);
      if (hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != 0)
        return;
      this.SelectedVisitDataRow["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["tick"]));
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.VisitsDataview == null || this.VisitsDataview.Count <= 0)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["EmailSend"], (object) 0, false))
            current["tick"] = (object) true;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      if (this.VisitsDataview == null || this.VisitsDataview.Count <= 0)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.VisitsDataview.Table.Select("Tick= true"),
        (object) this.chkPrintHdr.Checked
      }, "GSR Batch", Enums.SystemDocumentType.GSRBatch, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.RunFilter();
      this.Cursor = Cursors.Default;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("Resident Name");
      datatableIn.Columns.Add("Address 1");
      datatableIn.Columns.Add("Postcode");
      datatableIn.Columns.Add("Sub Area");
      datatableIn.Columns.Add("Contact No.");
      datatableIn.Columns.Add("PRI Data");
      datatableIn.Columns.Add("Works");
      datatableIn.Columns.Add("Date Completed");
      datatableIn.Columns.Add("Operative");
      IEnumerator enumerator;
      try
      {
        enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
          {
            DataRow row = datatableIn.NewRow();
            string String1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["SiteName"]));
            if (String1.Contains("T2"))
              String1 = String1.Substring(0, checked (Strings.InStr(String1, "T2", CompareMethod.Binary) - 1));
            string str1 = String1.Replace("T1 ", "").Trim();
            row["Resident Name"] = (object) str1;
            row["Address 1"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address1"]));
            row["Postcode"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Postcode"]));
            row["Sub Area"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address2"]));
            string str2 = "";
            string str3 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["TelephoneNum"]));
            int num = checked (str3.Length - 1);
            int index = 0;
            while (index <= num)
            {
              if (Versioned.IsNumeric((object) str3[index]) | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(str3[index]), " ", false) == 0)
                str2 += Conversions.ToString(str3[index]);
              checked { ++index; }
            }
            row["Contact No."] = (object) ("'" + str2);
            row["PRI Data"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["SiteNotes"]));
            row["Works"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["Date Completed"] = (object) Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"])), "dd/MMM/yyyy");
            row["Operative"] = RuntimeHelpers.GetObjectValue(current["Engineer"]);
            datatableIn.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Exporting exporting = new Exporting(datatableIn, "Gas Summary Spec", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.ResetFilters();
        if (this.get_GetParameter(0) == null)
          return;
        this.VisitsDataview = (DataView) this.get_GetParameter(0);
        this.grpFilter.Enabled = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetFilters()
    {
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      ComboBox cboDefinition = this.cboDefinition;
      Combo.SetSelectedComboItem_By_Value(ref cboDefinition, Conversions.ToString(0));
      this.cboDefinition = cboDefinition;
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(4702));
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetSelectedComboItem_By_Value(ref cboOutcome, Conversions.ToString(1));
      this.cboOutcome = cboOutcome;
      this.txtJobNumber.Text = "";
      this.txtPostcode.Text = "";
      this.chkVisitDate.Checked = true;
      if (DateAndTime.Today.DayOfWeek == DayOfWeek.Monday)
      {
        DateTimePicker dtpFrom = this.dtpFrom;
        DateTime today = DateAndTime.Today;
        DateTime dateTime1 = today.AddDays(-1.0);
        dtpFrom.Value = dateTime1;
        DateTimePicker dtpTo = this.dtpTo;
        today = DateAndTime.Today;
        DateTime dateTime2 = today.AddDays(-3.0);
        dtpTo.Value = dateTime2;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today.AddDays(-1.0);
        this.dtpTo.Value = DateAndTime.Today.AddDays(-1.0);
      }
      this.dtpFrom.Enabled = true;
      this.dtpTo.Enabled = true;
      this.grpFilter.Enabled = true;
    }

    private void RunFilter()
    {
      string Where = "AND tblEngineerVisit.Deleted = 0 ";
      if (this.theCustomer != null)
        Where += " AND tblCustomer.CustomerID = " + Conversions.ToString(this.theCustomer.CustomerID);
      if (this.theSite != null)
        Where += " AND tblSite.SiteID = " + Conversions.ToString(this.theSite.SiteID);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDefinition)) != 0.0)
        Where += " AND JobDefinitionEnumID = " + Combo.get_GetSelectedItemValue(this.cboDefinition);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
        Where += " AND JobTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
        Where = Where + " AND (CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)   WHEN 0 THEN tblEngineerVisit.StatusEnumID   WHEN 1 THEN tblEngineerVisit.StatusEnumID   WHEN 2 THEN   CASE   WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 8  ELSE 7    End  WHEN 3 THEN 6   End) = " + Combo.get_GetSelectedItemValue(this.cboStatus);
      if ((uint) this.txtJobNumber.Text.Trim().Length > 0U)
        Where = Where + " AND JobNumber LIKE '" + this.txtJobNumber.Text.Trim() + "%'";
      if (this.chkVisitDate.Checked)
        Where = Where + " AND StartDateTime >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND StartDateTime <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
      if ((uint) this.txtPostcode.Text.Trim().Length > 0U)
        Where = Where + " AND tblSite.Postcode LIKE '" + this.txtPostcode.Text.Trim() + "%'";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOutcome)) != 0.0)
        Where += " AND OutcomeEnumID = " + Combo.get_GetSelectedItemValue(this.cboOutcome);
      if (this.chkExceptionsOnly.Checked)
        Where += " AND DefectCount > 0";
      this.VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Get_All(Where);
      this.grpEngineerVisits.Text = "Double Click To View / Edit - Visits: " + Conversions.ToString(this.VisitsDataview.Table.Rows.Count);
    }

    public void Export()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("Customer");
      dataTable.Columns.Add("Site");
      dataTable.Columns.Add("SitePostcode");
      dataTable.Columns.Add("JobNumber");
      dataTable.Columns.Add("PONumber");
      dataTable.Columns.Add("JobDefinition");
      dataTable.Columns.Add("Type");
      dataTable.Columns.Add("VisitStatus");
      dataTable.Columns.Add("StartDateTime");
      dataTable.Columns.Add("Engineer");
      dataTable.Columns.Add("VisitValue", typeof (double));
      dataTable.Columns.Add("VisitCharge");
      dataTable.Columns.Add("EngineerCost", typeof (double));
      dataTable.Columns.Add("PartProductCost", typeof (double));
      int num = checked (((DataView) this.dgVisits.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgVisits.CurrentRowIndex = row1;
        DataRow row2 = dataTable.NewRow();
        row2["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Customer"]);
        row2["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Site"]);
        row2["SitePostcode"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["SitePostcode"]);
        row2["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobNumber"]);
        row2["PONumber"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["PONumber"]);
        row2["JobDefinition"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobDefinition"]);
        row2["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Type"]);
        row2["VisitStatus"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitStatus"]);
        row2["StartDateTime"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["StartDateTime"]);
        row2["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Engineer"]);
        row2["VisitValue"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitValue"]);
        row2["VisitCharge"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitCharge"]);
        row2["EngineerCost"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["EngineerCost"]);
        row2["PartProductCost"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["PartProductCost"]);
        dataTable.Rows.Add(row2);
        this.dgVisits.UnSelect(row1);
        checked { ++row1; }
      }
    }

    private void dgVisits_DoubleClick(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMEngineerVisit), true, new object[1]
      {
        this.SelectedVisitDataRow["EngineerVisitID"]
      }, false);
    }
  }
}
