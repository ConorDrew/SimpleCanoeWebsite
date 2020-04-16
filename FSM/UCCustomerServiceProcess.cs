// Decompiled with JetBrains decompiler
// Type: FSM.UCCustomerServiceProcess
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Customers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCCustomerServiceProcess : UCBase, IUserControl
  {
    private IContainer components;
    private int _customerId;
    private CustomerServiceProcess _serviceProcess;

    public UCCustomerServiceProcess(int _customerId)
    {
      this.InitializeComponent();
      this.CustomerId = _customerId;
      this.Populate(0);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpBxServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual LinkLabel lnkDownloadExampleTemplate
    {
      get
      {
        return this._lnkDownloadExampleTemplate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.lnkDownloadExampleTemplate_LinkClicked);
        LinkLabel downloadExampleTemplate1 = this._lnkDownloadExampleTemplate;
        if (downloadExampleTemplate1 != null)
          downloadExampleTemplate1.LinkClicked -= clickedEventHandler;
        this._lnkDownloadExampleTemplate = value;
        LinkLabel downloadExampleTemplate2 = this._lnkDownloadExampleTemplate;
        if (downloadExampleTemplate2 == null)
          return;
        downloadExampleTemplate2.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual GroupBox grpTemplate3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDownloadTemplate3
    {
      get
      {
        return this._btnDownloadTemplate3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDownloadTemplate3_Click);
        Button downloadTemplate3_1 = this._btnDownloadTemplate3;
        if (downloadTemplate3_1 != null)
          downloadTemplate3_1.Click -= eventHandler;
        this._btnDownloadTemplate3 = value;
        Button downloadTemplate3_2 = this._btnDownloadTemplate3;
        if (downloadTemplate3_2 == null)
          return;
        downloadTemplate3_2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddTemplate3
    {
      get
      {
        return this._btnAddTemplate3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddTemplate3_Click);
        Button btnAddTemplate3_1 = this._btnAddTemplate3;
        if (btnAddTemplate3_1 != null)
          btnAddTemplate3_1.Click -= eventHandler;
        this._btnAddTemplate3 = value;
        Button btnAddTemplate3_2 = this._btnAddTemplate3;
        if (btnAddTemplate3_2 == null)
          return;
        btnAddTemplate3_2.Click += eventHandler;
      }
    }

    internal virtual Button btnTestTemplate3
    {
      get
      {
        return this._btnTestTemplate3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTestTemplate3_Click);
        Button btnTestTemplate3_1 = this._btnTestTemplate3;
        if (btnTestTemplate3_1 != null)
          btnTestTemplate3_1.Click -= eventHandler;
        this._btnTestTemplate3 = value;
        Button btnTestTemplate3_2 = this._btnTestTemplate3;
        if (btnTestTemplate3_2 == null)
          return;
        btnTestTemplate3_2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpTemplate2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDownloadTemplate2
    {
      get
      {
        return this._btnDownloadTemplate2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDownloadTemplate2_Click);
        Button downloadTemplate2_1 = this._btnDownloadTemplate2;
        if (downloadTemplate2_1 != null)
          downloadTemplate2_1.Click -= eventHandler;
        this._btnDownloadTemplate2 = value;
        Button downloadTemplate2_2 = this._btnDownloadTemplate2;
        if (downloadTemplate2_2 == null)
          return;
        downloadTemplate2_2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddTemplate2
    {
      get
      {
        return this._btnAddTemplate2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddTemplate2_Click);
        Button btnAddTemplate2_1 = this._btnAddTemplate2;
        if (btnAddTemplate2_1 != null)
          btnAddTemplate2_1.Click -= eventHandler;
        this._btnAddTemplate2 = value;
        Button btnAddTemplate2_2 = this._btnAddTemplate2;
        if (btnAddTemplate2_2 == null)
          return;
        btnAddTemplate2_2.Click += eventHandler;
      }
    }

    internal virtual Button btnTestTemplate2
    {
      get
      {
        return this._btnTestTemplate2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTestTemplate2_Click);
        Button btnTestTemplate2_1 = this._btnTestTemplate2;
        if (btnTestTemplate2_1 != null)
          btnTestTemplate2_1.Click -= eventHandler;
        this._btnTestTemplate2 = value;
        Button btnTestTemplate2_2 = this._btnTestTemplate2;
        if (btnTestTemplate2_2 == null)
          return;
        btnTestTemplate2_2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpTemplate1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDownloadTemplate1
    {
      get
      {
        return this._btnDownloadTemplate1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDownloadTemplate1_Click);
        Button downloadTemplate1_1 = this._btnDownloadTemplate1;
        if (downloadTemplate1_1 != null)
          downloadTemplate1_1.Click -= eventHandler;
        this._btnDownloadTemplate1 = value;
        Button downloadTemplate1_2 = this._btnDownloadTemplate1;
        if (downloadTemplate1_2 == null)
          return;
        downloadTemplate1_2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddTemplate1
    {
      get
      {
        return this._btnAddTemplate1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddTemplate1_Click);
        Button btnAddTemplate1_1 = this._btnAddTemplate1;
        if (btnAddTemplate1_1 != null)
          btnAddTemplate1_1.Click -= eventHandler;
        this._btnAddTemplate1 = value;
        Button btnAddTemplate1_2 = this._btnAddTemplate1;
        if (btnAddTemplate1_2 == null)
          return;
        btnAddTemplate1_2.Click += eventHandler;
      }
    }

    internal virtual Button btnTestTemplate1
    {
      get
      {
        return this._btnTestTemplate1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTestTemplate1_Click);
        Button btnTestTemplate1_1 = this._btnTestTemplate1;
        if (btnTestTemplate1_1 != null)
          btnTestTemplate1_1.Click -= eventHandler;
        this._btnTestTemplate1 = value;
        Button btnTestTemplate1_2 = this._btnTestTemplate1;
        if (btnTestTemplate1_2 == null)
          return;
        btnTestTemplate1_2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteProcess
    {
      get
      {
        return this._btnDeleteProcess;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteProcess_Click);
        Button btnDeleteProcess1 = this._btnDeleteProcess;
        if (btnDeleteProcess1 != null)
          btnDeleteProcess1.Click -= eventHandler;
        this._btnDeleteProcess = value;
        Button btnDeleteProcess2 = this._btnDeleteProcess;
        if (btnDeleteProcess2 == null)
          return;
        btnDeleteProcess2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtAppointment3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppointment3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAppointment2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppointment2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAppointment1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppointment1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLetter3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLetter3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLetter2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLetter2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLetter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLetter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveServiceProcess
    {
      get
      {
        return this._btnSaveServiceProcess;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveServiceProcess_Click);
        Button saveServiceProcess1 = this._btnSaveServiceProcess;
        if (saveServiceProcess1 != null)
          saveServiceProcess1.Click -= eventHandler;
        this._btnSaveServiceProcess = value;
        Button saveServiceProcess2 = this._btnSaveServiceProcess;
        if (saveServiceProcess2 == null)
          return;
        saveServiceProcess2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpPatchCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDownloadPatchCheckTemplate
    {
      get
      {
        return this._btnDownloadPatchCheckTemplate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDownloadPatchCheckTemplate_Click);
        Button patchCheckTemplate1 = this._btnDownloadPatchCheckTemplate;
        if (patchCheckTemplate1 != null)
          patchCheckTemplate1.Click -= eventHandler;
        this._btnDownloadPatchCheckTemplate = value;
        Button patchCheckTemplate2 = this._btnDownloadPatchCheckTemplate;
        if (patchCheckTemplate2 == null)
          return;
        patchCheckTemplate2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddPatchCheckTemplate
    {
      get
      {
        return this._btnAddPatchCheckTemplate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPatchCheckTemplate_Click);
        Button patchCheckTemplate1 = this._btnAddPatchCheckTemplate;
        if (patchCheckTemplate1 != null)
          patchCheckTemplate1.Click -= eventHandler;
        this._btnAddPatchCheckTemplate = value;
        Button patchCheckTemplate2 = this._btnAddPatchCheckTemplate;
        if (patchCheckTemplate2 == null)
          return;
        patchCheckTemplate2.Click += eventHandler;
      }
    }

    internal virtual Button btnTestPatchCheckTemplate
    {
      get
      {
        return this._btnTestPatchCheckTemplate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTestPatchCheckTemplate_Click);
        Button patchCheckTemplate1 = this._btnTestPatchCheckTemplate;
        if (patchCheckTemplate1 != null)
          patchCheckTemplate1.Click -= eventHandler;
        this._btnTestPatchCheckTemplate = value;
        Button patchCheckTemplate2 = this._btnTestPatchCheckTemplate;
        if (patchCheckTemplate2 == null)
          return;
        patchCheckTemplate2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpBxServiceDate = new GroupBox();
      this.grpPatchCheck = new GroupBox();
      this.btnDownloadPatchCheckTemplate = new Button();
      this.btnAddPatchCheckTemplate = new Button();
      this.btnTestPatchCheckTemplate = new Button();
      this.lnkDownloadExampleTemplate = new LinkLabel();
      this.grpTemplate3 = new GroupBox();
      this.btnDownloadTemplate3 = new Button();
      this.btnAddTemplate3 = new Button();
      this.btnTestTemplate3 = new Button();
      this.grpTemplate2 = new GroupBox();
      this.btnDownloadTemplate2 = new Button();
      this.btnAddTemplate2 = new Button();
      this.btnTestTemplate2 = new Button();
      this.grpTemplate1 = new GroupBox();
      this.btnDownloadTemplate1 = new Button();
      this.btnAddTemplate1 = new Button();
      this.btnTestTemplate1 = new Button();
      this.btnDeleteProcess = new Button();
      this.txtAppointment3 = new TextBox();
      this.lblAppointment3 = new Label();
      this.txtAppointment2 = new TextBox();
      this.lblAppointment2 = new Label();
      this.txtAppointment1 = new TextBox();
      this.lblAppointment1 = new Label();
      this.txtLetter3 = new TextBox();
      this.lblLetter3 = new Label();
      this.txtLetter2 = new TextBox();
      this.lblLetter2 = new Label();
      this.txtLetter1 = new TextBox();
      this.lblLetter1 = new Label();
      this.btnSaveServiceProcess = new Button();
      this.grpBxServiceDate.SuspendLayout();
      this.grpPatchCheck.SuspendLayout();
      this.grpTemplate3.SuspendLayout();
      this.grpTemplate2.SuspendLayout();
      this.grpTemplate1.SuspendLayout();
      this.SuspendLayout();
      this.grpBxServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpBxServiceDate.Controls.Add((Control) this.grpPatchCheck);
      this.grpBxServiceDate.Controls.Add((Control) this.lnkDownloadExampleTemplate);
      this.grpBxServiceDate.Controls.Add((Control) this.grpTemplate3);
      this.grpBxServiceDate.Controls.Add((Control) this.grpTemplate2);
      this.grpBxServiceDate.Controls.Add((Control) this.grpTemplate1);
      this.grpBxServiceDate.Controls.Add((Control) this.btnDeleteProcess);
      this.grpBxServiceDate.Controls.Add((Control) this.txtAppointment3);
      this.grpBxServiceDate.Controls.Add((Control) this.lblAppointment3);
      this.grpBxServiceDate.Controls.Add((Control) this.txtAppointment2);
      this.grpBxServiceDate.Controls.Add((Control) this.lblAppointment2);
      this.grpBxServiceDate.Controls.Add((Control) this.txtAppointment1);
      this.grpBxServiceDate.Controls.Add((Control) this.lblAppointment1);
      this.grpBxServiceDate.Controls.Add((Control) this.txtLetter3);
      this.grpBxServiceDate.Controls.Add((Control) this.lblLetter3);
      this.grpBxServiceDate.Controls.Add((Control) this.txtLetter2);
      this.grpBxServiceDate.Controls.Add((Control) this.lblLetter2);
      this.grpBxServiceDate.Controls.Add((Control) this.txtLetter1);
      this.grpBxServiceDate.Controls.Add((Control) this.lblLetter1);
      this.grpBxServiceDate.Controls.Add((Control) this.btnSaveServiceProcess);
      this.grpBxServiceDate.FlatStyle = FlatStyle.System;
      this.grpBxServiceDate.Location = new System.Drawing.Point(3, 3);
      this.grpBxServiceDate.Name = "grpBxServiceDate";
      this.grpBxServiceDate.Size = new Size(621, 550);
      this.grpBxServiceDate.TabIndex = 3;
      this.grpBxServiceDate.TabStop = false;
      this.grpBxServiceDate.Text = "Service Process";
      this.grpPatchCheck.Controls.Add((Control) this.btnDownloadPatchCheckTemplate);
      this.grpPatchCheck.Controls.Add((Control) this.btnAddPatchCheckTemplate);
      this.grpPatchCheck.Controls.Add((Control) this.btnTestPatchCheckTemplate);
      this.grpPatchCheck.Location = new System.Drawing.Point(13, 371);
      this.grpPatchCheck.Name = "grpPatchCheck";
      this.grpPatchCheck.Size = new Size(358, 61);
      this.grpPatchCheck.TabIndex = 165;
      this.grpPatchCheck.TabStop = false;
      this.grpPatchCheck.Text = "Patch Check";
      this.btnDownloadPatchCheckTemplate.Location = new System.Drawing.Point((int) sbyte.MaxValue, 22);
      this.btnDownloadPatchCheckTemplate.Name = "btnDownloadPatchCheckTemplate";
      this.btnDownloadPatchCheckTemplate.Size = new Size(86, 25);
      this.btnDownloadPatchCheckTemplate.TabIndex = 157;
      this.btnDownloadPatchCheckTemplate.Text = "Download";
      this.btnDownloadPatchCheckTemplate.Visible = false;
      this.btnAddPatchCheckTemplate.Location = new System.Drawing.Point(10, 22);
      this.btnAddPatchCheckTemplate.Name = "btnAddPatchCheckTemplate";
      this.btnAddPatchCheckTemplate.Size = new Size(70, 25);
      this.btnAddPatchCheckTemplate.TabIndex = 148;
      this.btnAddPatchCheckTemplate.Text = "Add";
      this.btnTestPatchCheckTemplate.Location = new System.Drawing.Point(260, 22);
      this.btnTestPatchCheckTemplate.Name = "btnTestPatchCheckTemplate";
      this.btnTestPatchCheckTemplate.Size = new Size(70, 25);
      this.btnTestPatchCheckTemplate.TabIndex = 156;
      this.btnTestPatchCheckTemplate.Text = "Test";
      this.btnTestPatchCheckTemplate.Visible = false;
      this.lnkDownloadExampleTemplate.AutoSize = true;
      this.lnkDownloadExampleTemplate.Location = new System.Drawing.Point(433, 28);
      this.lnkDownloadExampleTemplate.Name = "lnkDownloadExampleTemplate";
      this.lnkDownloadExampleTemplate.Size = new Size(172, 13);
      this.lnkDownloadExampleTemplate.TabIndex = 164;
      this.lnkDownloadExampleTemplate.TabStop = true;
      this.lnkDownloadExampleTemplate.Text = "Download Example Template";
      this.grpTemplate3.Controls.Add((Control) this.btnDownloadTemplate3);
      this.grpTemplate3.Controls.Add((Control) this.btnAddTemplate3);
      this.grpTemplate3.Controls.Add((Control) this.btnTestTemplate3);
      this.grpTemplate3.Location = new System.Drawing.Point(13, 283);
      this.grpTemplate3.Name = "grpTemplate3";
      this.grpTemplate3.Size = new Size(358, 61);
      this.grpTemplate3.TabIndex = 163;
      this.grpTemplate3.TabStop = false;
      this.grpTemplate3.Text = "Template";
      this.btnDownloadTemplate3.Location = new System.Drawing.Point((int) sbyte.MaxValue, 22);
      this.btnDownloadTemplate3.Name = "btnDownloadTemplate3";
      this.btnDownloadTemplate3.Size = new Size(86, 25);
      this.btnDownloadTemplate3.TabIndex = 157;
      this.btnDownloadTemplate3.Text = "Download";
      this.btnDownloadTemplate3.Visible = false;
      this.btnAddTemplate3.Location = new System.Drawing.Point(10, 22);
      this.btnAddTemplate3.Name = "btnAddTemplate3";
      this.btnAddTemplate3.Size = new Size(70, 25);
      this.btnAddTemplate3.TabIndex = 148;
      this.btnAddTemplate3.Text = "Add";
      this.btnTestTemplate3.Location = new System.Drawing.Point(260, 22);
      this.btnTestTemplate3.Name = "btnTestTemplate3";
      this.btnTestTemplate3.Size = new Size(70, 25);
      this.btnTestTemplate3.TabIndex = 156;
      this.btnTestTemplate3.Text = "Test";
      this.btnTestTemplate3.Visible = false;
      this.grpTemplate2.Controls.Add((Control) this.btnDownloadTemplate2);
      this.grpTemplate2.Controls.Add((Control) this.btnAddTemplate2);
      this.grpTemplate2.Controls.Add((Control) this.btnTestTemplate2);
      this.grpTemplate2.Location = new System.Drawing.Point(13, 170);
      this.grpTemplate2.Name = "grpTemplate2";
      this.grpTemplate2.Size = new Size(358, 61);
      this.grpTemplate2.TabIndex = 162;
      this.grpTemplate2.TabStop = false;
      this.grpTemplate2.Text = "Template";
      this.btnDownloadTemplate2.Location = new System.Drawing.Point((int) sbyte.MaxValue, 22);
      this.btnDownloadTemplate2.Name = "btnDownloadTemplate2";
      this.btnDownloadTemplate2.Size = new Size(86, 25);
      this.btnDownloadTemplate2.TabIndex = 157;
      this.btnDownloadTemplate2.Text = "Download";
      this.btnDownloadTemplate2.Visible = false;
      this.btnAddTemplate2.Location = new System.Drawing.Point(10, 22);
      this.btnAddTemplate2.Name = "btnAddTemplate2";
      this.btnAddTemplate2.Size = new Size(70, 25);
      this.btnAddTemplate2.TabIndex = 148;
      this.btnAddTemplate2.Text = "Add";
      this.btnTestTemplate2.Location = new System.Drawing.Point(260, 22);
      this.btnTestTemplate2.Name = "btnTestTemplate2";
      this.btnTestTemplate2.Size = new Size(70, 25);
      this.btnTestTemplate2.TabIndex = 156;
      this.btnTestTemplate2.Text = "Test";
      this.btnTestTemplate2.Visible = false;
      this.grpTemplate1.Controls.Add((Control) this.btnDownloadTemplate1);
      this.grpTemplate1.Controls.Add((Control) this.btnAddTemplate1);
      this.grpTemplate1.Controls.Add((Control) this.btnTestTemplate1);
      this.grpTemplate1.Location = new System.Drawing.Point(13, 55);
      this.grpTemplate1.Name = "grpTemplate1";
      this.grpTemplate1.Size = new Size(358, 61);
      this.grpTemplate1.TabIndex = 161;
      this.grpTemplate1.TabStop = false;
      this.grpTemplate1.Text = "Template";
      this.btnDownloadTemplate1.Location = new System.Drawing.Point((int) sbyte.MaxValue, 22);
      this.btnDownloadTemplate1.Name = "btnDownloadTemplate1";
      this.btnDownloadTemplate1.Size = new Size(86, 25);
      this.btnDownloadTemplate1.TabIndex = 157;
      this.btnDownloadTemplate1.Text = "Download";
      this.btnDownloadTemplate1.Visible = false;
      this.btnAddTemplate1.Location = new System.Drawing.Point(10, 22);
      this.btnAddTemplate1.Name = "btnAddTemplate1";
      this.btnAddTemplate1.Size = new Size(70, 25);
      this.btnAddTemplate1.TabIndex = 148;
      this.btnAddTemplate1.Text = "Add";
      this.btnTestTemplate1.Location = new System.Drawing.Point(260, 22);
      this.btnTestTemplate1.Name = "btnTestTemplate1";
      this.btnTestTemplate1.Size = new Size(70, 25);
      this.btnTestTemplate1.TabIndex = 156;
      this.btnTestTemplate1.Text = "Test";
      this.btnTestTemplate1.Visible = false;
      this.btnDeleteProcess.Location = new System.Drawing.Point(13, 508);
      this.btnDeleteProcess.Name = "btnDeleteProcess";
      this.btnDeleteProcess.Size = new Size(90, 23);
      this.btnDeleteProcess.TabIndex = 146;
      this.btnDeleteProcess.Text = "Delete";
      this.txtAppointment3.Location = new System.Drawing.Point(274, 256);
      this.txtAppointment3.Name = "txtAppointment3";
      this.txtAppointment3.Size = new Size(57, 21);
      this.txtAppointment3.TabIndex = 145;
      this.lblAppointment3.AutoSize = true;
      this.lblAppointment3.Location = new System.Drawing.Point(169, 259);
      this.lblAppointment3.Name = "lblAppointment3";
      this.lblAppointment3.Size = new Size(90, 13);
      this.lblAppointment3.TabIndex = 144;
      this.lblAppointment3.Text = "Appointment 3";
      this.txtAppointment2.Location = new System.Drawing.Point(274, 143);
      this.txtAppointment2.Name = "txtAppointment2";
      this.txtAppointment2.Size = new Size(57, 21);
      this.txtAppointment2.TabIndex = 143;
      this.lblAppointment2.AutoSize = true;
      this.lblAppointment2.Location = new System.Drawing.Point(169, 146);
      this.lblAppointment2.Name = "lblAppointment2";
      this.lblAppointment2.Size = new Size(90, 13);
      this.lblAppointment2.TabIndex = 142;
      this.lblAppointment2.Text = "Appointment 2";
      this.txtAppointment1.Location = new System.Drawing.Point(274, 28);
      this.txtAppointment1.Name = "txtAppointment1";
      this.txtAppointment1.Size = new Size(57, 21);
      this.txtAppointment1.TabIndex = 141;
      this.lblAppointment1.AutoSize = true;
      this.lblAppointment1.Location = new System.Drawing.Point(169, 31);
      this.lblAppointment1.Name = "lblAppointment1";
      this.lblAppointment1.Size = new Size(90, 13);
      this.lblAppointment1.TabIndex = 140;
      this.lblAppointment1.Text = "Appointment 1";
      this.txtLetter3.Location = new System.Drawing.Point(88, 256);
      this.txtLetter3.Name = "txtLetter3";
      this.txtLetter3.Size = new Size(57, 21);
      this.txtLetter3.TabIndex = 139;
      this.lblLetter3.AutoSize = true;
      this.lblLetter3.Location = new System.Drawing.Point(20, 259);
      this.lblLetter3.Name = "lblLetter3";
      this.lblLetter3.Size = new Size(51, 13);
      this.lblLetter3.TabIndex = 138;
      this.lblLetter3.Text = "Letter 3";
      this.txtLetter2.Location = new System.Drawing.Point(88, 143);
      this.txtLetter2.Name = "txtLetter2";
      this.txtLetter2.Size = new Size(57, 21);
      this.txtLetter2.TabIndex = 137;
      this.lblLetter2.AutoSize = true;
      this.lblLetter2.Location = new System.Drawing.Point(20, 146);
      this.lblLetter2.Name = "lblLetter2";
      this.lblLetter2.Size = new Size(51, 13);
      this.lblLetter2.TabIndex = 136;
      this.lblLetter2.Text = "Letter 2";
      this.txtLetter1.Location = new System.Drawing.Point(88, 28);
      this.txtLetter1.Name = "txtLetter1";
      this.txtLetter1.Size = new Size(57, 21);
      this.txtLetter1.TabIndex = 135;
      this.lblLetter1.AutoSize = true;
      this.lblLetter1.Location = new System.Drawing.Point(20, 31);
      this.lblLetter1.Name = "lblLetter1";
      this.lblLetter1.Size = new Size(51, 13);
      this.lblLetter1.TabIndex = 134;
      this.lblLetter1.Text = "Letter 1";
      this.btnSaveServiceProcess.Location = new System.Drawing.Point(515, 508);
      this.btnSaveServiceProcess.Name = "btnSaveServiceProcess";
      this.btnSaveServiceProcess.Size = new Size(90, 23);
      this.btnSaveServiceProcess.TabIndex = 61;
      this.btnSaveServiceProcess.Text = "Save";
      this.Controls.Add((Control) this.grpBxServiceDate);
      this.Name = nameof (UCCustomerServiceProcess);
      this.Size = new Size(640, 569);
      this.grpBxServiceDate.ResumeLayout(false);
      this.grpBxServiceDate.PerformLayout();
      this.grpPatchCheck.ResumeLayout(false);
      this.grpTemplate3.ResumeLayout(false);
      this.grpTemplate2.ResumeLayout(false);
      this.grpTemplate1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public int CustomerId
    {
      get
      {
        return this._customerId;
      }
      set
      {
        this._customerId = value;
      }
    }

    public CustomerServiceProcess ServiceProcess
    {
      get
      {
        return this._serviceProcess;
      }
      set
      {
        this._serviceProcess = value;
        if (this._serviceProcess != null)
          return;
        this._serviceProcess = new CustomerServiceProcess();
        this._serviceProcess.Exists = false;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public object LoadedItem
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public void LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    private void btnSaveServiceProcess_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnDeleteProcess_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
        throw new SecurityException("You do not have the necessary security permissions to edit this information.");
      if (Helper.MakeIntegerValid((object) this.ServiceProcess?.CustomerServiceProcessID) == 0)
        return;
      try
      {
        if (!App.DB.Customer.CustomerServiceProcess_Delete(this.ServiceProcess.CustomerServiceProcessID))
          throw new Exception("Failed to delete!");
        this.Populate(0);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddTemplate1_Click(object sender, EventArgs e)
    {
      byte[] numArray = TemplateHelper.AddTemplate();
      if (numArray != null)
      {
        this.ServiceProcess.Template1 = numArray;
        this.btnAddTemplate1.Text = "Change";
        this.btnTestTemplate1.Visible = true;
        this.btnDownloadTemplate1.Visible = true;
      }
      else if (this.ServiceProcess.Template1 != null)
      {
        this.btnAddTemplate1.Text = "Change";
        this.btnTestTemplate1.Visible = true;
        this.btnDownloadTemplate1.Visible = true;
      }
      else
      {
        this.btnAddTemplate1.Text = "Add";
        this.btnTestTemplate1.Visible = false;
        this.btnDownloadTemplate1.Visible = false;
      }
    }

    private void btnAddTemplate2_Click(object sender, EventArgs e)
    {
      byte[] numArray = TemplateHelper.AddTemplate();
      if (numArray != null)
      {
        this.ServiceProcess.Template2 = numArray;
        this.btnAddTemplate2.Text = "Change";
        this.btnTestTemplate2.Visible = true;
        this.btnDownloadTemplate2.Visible = true;
      }
      else if (this.ServiceProcess.Template2 != null)
      {
        this.btnAddTemplate2.Text = "Change";
        this.btnTestTemplate2.Visible = true;
        this.btnDownloadTemplate2.Visible = true;
      }
      else
      {
        this.btnAddTemplate2.Text = "Add";
        this.btnTestTemplate2.Visible = false;
        this.btnDownloadTemplate2.Visible = false;
      }
    }

    private void btnAddTemplate3_Click(object sender, EventArgs e)
    {
      byte[] numArray = TemplateHelper.AddTemplate();
      if (numArray != null)
      {
        this.ServiceProcess.Template3 = numArray;
        this.btnAddTemplate3.Text = "Change";
        this.btnTestTemplate3.Visible = true;
        this.btnDownloadTemplate3.Visible = true;
      }
      else if (this.ServiceProcess.Template3 != null)
      {
        this.btnAddTemplate3.Text = "Change";
        this.btnTestTemplate3.Visible = true;
        this.btnDownloadTemplate3.Visible = true;
      }
      else
      {
        this.btnAddTemplate3.Text = "Add";
        this.btnTestTemplate3.Visible = false;
        this.btnDownloadTemplate3.Visible = false;
      }
    }

    private void btnAddPatchCheckTemplate_Click(object sender, EventArgs e)
    {
      byte[] numArray = TemplateHelper.AddTemplate();
      if (numArray != null)
      {
        this.ServiceProcess.PatchCheckTemplate = numArray;
        this.btnAddPatchCheckTemplate.Text = "Change";
        this.btnTestPatchCheckTemplate.Visible = true;
        this.btnDownloadPatchCheckTemplate.Visible = true;
      }
      else if (this.ServiceProcess.PatchCheckTemplate != null)
      {
        this.btnAddPatchCheckTemplate.Text = "Change";
        this.btnTestPatchCheckTemplate.Visible = true;
        this.btnDownloadPatchCheckTemplate.Visible = true;
      }
      else
      {
        this.btnAddPatchCheckTemplate.Text = "Add";
        this.btnTestPatchCheckTemplate.Visible = false;
        this.btnDownloadPatchCheckTemplate.Visible = false;
      }
    }

    private void btnTestTemplate1_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template1 == null)
        return;
      TemplateHelper.TestTemplate(this.ServiceProcess.Template1, Enums.TemplateType.ServiceLetter);
    }

    private void btnTestTemplate2_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template2 == null)
        return;
      TemplateHelper.TestTemplate(this.ServiceProcess.Template2, Enums.TemplateType.ServiceLetter);
    }

    private void btnTestTemplate3_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template3 == null)
        return;
      TemplateHelper.TestTemplate(this.ServiceProcess.Template3, Enums.TemplateType.ServiceLetter);
    }

    private void btnTestPatchCheckTemplate_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.PatchCheckTemplate == null)
        return;
      TemplateHelper.TestTemplate(this.ServiceProcess.PatchCheckTemplate, Enums.TemplateType.ServiceLetter);
    }

    private void btnDownloadTemplate1_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template1 == null)
        return;
      TemplateHelper.DownloadTemplate(this.ServiceProcess.Template1);
    }

    private void btnDownloadTemplate2_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template2 == null)
        return;
      TemplateHelper.DownloadTemplate(this.ServiceProcess.Template2);
    }

    private void btnDownloadTemplate3_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.Template3 == null)
        return;
      TemplateHelper.DownloadTemplate(this.ServiceProcess.Template3);
    }

    private void btnDownloadPatchCheckTemplate_Click(object sender, EventArgs e)
    {
      if (this.ServiceProcess.PatchCheckTemplate == null)
        return;
      TemplateHelper.DownloadTemplate(this.ServiceProcess.PatchCheckTemplate);
    }

    private void lnkDownloadExampleTemplate_LinkClicked(
      object sender,
      LinkLabelLinkClickedEventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        string destFileName = folderBrowserDialog.SelectedPath + "\\ServiceLetterTemplate.docx";
        File.Copy(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetters\\ServiceLetterExample.docx", destFileName);
        int num = (int) App.ShowMessage("File downloaded to " + folderBrowserDialog.SelectedPath + "\\ServiceLetterTemplate.docx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        Cursor.Current = Cursors.Default;
      }
    }

    public void Populate(int ID = 0)
    {
      this.ServiceProcess = App.DB.Customer.CustomerServiceProcess_Get_ForCustomer(this.CustomerId);
      this.txtLetter1.Text = Conversions.ToString(this.ServiceProcess.Letter1);
      this.txtLetter2.Text = Conversions.ToString(this.ServiceProcess.Letter2);
      this.txtLetter3.Text = Conversions.ToString(this.ServiceProcess.Letter3);
      this.txtAppointment1.Text = Conversions.ToString(this.ServiceProcess.Appointment1);
      this.txtAppointment2.Text = Conversions.ToString(this.ServiceProcess.Appointment2);
      this.txtAppointment3.Text = Conversions.ToString(this.ServiceProcess.Appointment3);
      this.btnAddTemplate1.Text = this.ServiceProcess.Template1 != null ? "Change" : "Add";
      this.btnTestTemplate1.Visible = this.ServiceProcess.Template1 != null;
      this.btnDownloadTemplate1.Visible = this.ServiceProcess.Template1 != null;
      this.btnAddTemplate2.Text = this.ServiceProcess.Template2 != null ? "Change" : "Add";
      this.btnTestTemplate2.Visible = this.ServiceProcess.Template2 != null;
      this.btnDownloadTemplate2.Visible = this.ServiceProcess.Template2 != null;
      this.btnAddTemplate3.Text = this.ServiceProcess.Template3 != null ? "Change" : "Add";
      this.btnTestTemplate3.Visible = this.ServiceProcess.Template3 != null;
      this.btnDownloadTemplate3.Visible = this.ServiceProcess.Template3 != null;
      this.btnAddPatchCheckTemplate.Text = this.ServiceProcess.PatchCheckTemplate != null ? "Change" : "Add";
      this.btnTestPatchCheckTemplate.Visible = this.ServiceProcess.PatchCheckTemplate != null;
      this.btnDownloadPatchCheckTemplate.Visible = this.ServiceProcess.PatchCheckTemplate != null;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.SocialHousingSecurity))
          throw new SecurityException("You do not have the necessary security permissions to edit this information.");
        if (App.ShowMessage("Save service process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          this.Cursor = Cursors.WaitCursor;
          CustomerServiceProcess serviceProcess = this.ServiceProcess;
          serviceProcess.SetCustomerID = (object) this.CustomerId;
          serviceProcess.SetLetter1 = (object) Helper.MakeIntegerValid((object) this.txtLetter1.Text);
          serviceProcess.SetLetter2 = (object) Helper.MakeIntegerValid((object) this.txtLetter2.Text);
          serviceProcess.SetLetter3 = (object) Helper.MakeIntegerValid((object) this.txtLetter3.Text);
          serviceProcess.SetAppointment1 = (object) Helper.MakeIntegerValid((object) this.txtAppointment1.Text);
          serviceProcess.SetAppointment2 = (object) Helper.MakeIntegerValid((object) this.txtAppointment2.Text);
          serviceProcess.SetAppointment3 = (object) Helper.MakeIntegerValid((object) this.txtAppointment3.Text);
          if (!App.DB.Customer.CustomerServiceProcess_Update(this.ServiceProcess))
            throw new Exception("Failed to save!");
          int num = (int) App.ShowMessage("Process saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = true;
        }
        else
          flag = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving details : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
