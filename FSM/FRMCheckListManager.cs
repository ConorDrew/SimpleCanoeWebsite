// Decompiled with JetBrains decompiler
// Type: FSM.FRMCheckListManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Areas;
using FSM.Entity.Sections;
using FSM.Entity.SubTasks;
using FSM.Entity.Sys;
using FSM.Entity.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMCheckListManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool SectionSelected;
    private bool AreaSelected;
    private bool TaskSelected;
    private bool SubTaskSelected;
    private DataView _SectionDataView;
    private DataView _AreaDataView;
    private DataView _TaskDataView;
    private DataView _SubTaskDataView;

    public FRMCheckListManager()
    {
      this.Load += new EventHandler(this.FRMCheckListManager_Load);
      this.SectionSelected = false;
      this.AreaSelected = false;
      this.TaskSelected = false;
      this.SubTaskSelected = false;
      this._SectionDataView = (DataView) null;
      this._AreaDataView = (DataView) null;
      this._TaskDataView = (DataView) null;
      this._SubTaskDataView = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSections { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSection
    {
      get
      {
        return this._dgSection;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSection_Click);
        DataGrid dgSection1 = this._dgSection;
        if (dgSection1 != null)
          dgSection1.Click -= eventHandler;
        this._dgSection = value;
        DataGrid dgSection2 = this._dgSection;
        if (dgSection2 == null)
          return;
        dgSection2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveSection
    {
      get
      {
        return this._btnRemoveSection;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveSection_Click);
        Button btnRemoveSection1 = this._btnRemoveSection;
        if (btnRemoveSection1 != null)
          btnRemoveSection1.Click -= eventHandler;
        this._btnRemoveSection = value;
        Button btnRemoveSection2 = this._btnRemoveSection;
        if (btnRemoveSection2 == null)
          return;
        btnRemoveSection2.Click += eventHandler;
      }
    }

    internal virtual Button btnUpdateSection
    {
      get
      {
        return this._btnUpdateSection;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateSection_Click);
        Button btnUpdateSection1 = this._btnUpdateSection;
        if (btnUpdateSection1 != null)
          btnUpdateSection1.Click -= eventHandler;
        this._btnUpdateSection = value;
        Button btnUpdateSection2 = this._btnUpdateSection;
        if (btnUpdateSection2 == null)
          return;
        btnUpdateSection2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAreas { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdateArea
    {
      get
      {
        return this._btnUpdateArea;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateArea_Click);
        Button btnUpdateArea1 = this._btnUpdateArea;
        if (btnUpdateArea1 != null)
          btnUpdateArea1.Click -= eventHandler;
        this._btnUpdateArea = value;
        Button btnUpdateArea2 = this._btnUpdateArea;
        if (btnUpdateArea2 == null)
          return;
        btnUpdateArea2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveArea
    {
      get
      {
        return this._btnRemoveArea;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveArea_Click);
        Button btnRemoveArea1 = this._btnRemoveArea;
        if (btnRemoveArea1 != null)
          btnRemoveArea1.Click -= eventHandler;
        this._btnRemoveArea = value;
        Button btnRemoveArea2 = this._btnRemoveArea;
        if (btnRemoveArea2 == null)
          return;
        btnRemoveArea2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgArea
    {
      get
      {
        return this._dgArea;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgArea_Click);
        DataGrid dgArea1 = this._dgArea;
        if (dgArea1 != null)
          dgArea1.Click -= eventHandler;
        this._dgArea = value;
        DataGrid dgArea2 = this._dgArea;
        if (dgArea2 == null)
          return;
        dgArea2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgTask
    {
      get
      {
        return this._dgTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgTask_Click);
        DataGrid dgTask1 = this._dgTask;
        if (dgTask1 != null)
          dgTask1.Click -= eventHandler;
        this._dgTask = value;
        DataGrid dgTask2 = this._dgTask;
        if (dgTask2 == null)
          return;
        dgTask2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgSubTask
    {
      get
      {
        return this._dgSubTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSubTask_Click);
        DataGrid dgSubTask1 = this._dgSubTask;
        if (dgSubTask1 != null)
          dgSubTask1.Click -= eventHandler;
        this._dgSubTask = value;
        DataGrid dgSubTask2 = this._dgSubTask;
        if (dgSubTask2 == null)
          return;
        dgSubTask2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpTasks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSubTask { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveTask
    {
      get
      {
        return this._btnRemoveTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveTask_Click);
        Button btnRemoveTask1 = this._btnRemoveTask;
        if (btnRemoveTask1 != null)
          btnRemoveTask1.Click -= eventHandler;
        this._btnRemoveTask = value;
        Button btnRemoveTask2 = this._btnRemoveTask;
        if (btnRemoveTask2 == null)
          return;
        btnRemoveTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveSubTask
    {
      get
      {
        return this._btnRemoveSubTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveSubTask_Click);
        Button btnRemoveSubTask1 = this._btnRemoveSubTask;
        if (btnRemoveSubTask1 != null)
          btnRemoveSubTask1.Click -= eventHandler;
        this._btnRemoveSubTask = value;
        Button btnRemoveSubTask2 = this._btnRemoveSubTask;
        if (btnRemoveSubTask2 == null)
          return;
        btnRemoveSubTask2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtArea { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTasks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSubTasks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdateTask
    {
      get
      {
        return this._btnUpdateTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateTask_Click);
        Button btnUpdateTask1 = this._btnUpdateTask;
        if (btnUpdateTask1 != null)
          btnUpdateTask1.Click -= eventHandler;
        this._btnUpdateTask = value;
        Button btnUpdateTask2 = this._btnUpdateTask;
        if (btnUpdateTask2 == null)
          return;
        btnUpdateTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnUpdateSubTask
    {
      get
      {
        return this._btnUpdateSubTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateSubTask_Click);
        Button btnUpdateSubTask1 = this._btnUpdateSubTask;
        if (btnUpdateSubTask1 != null)
          btnUpdateSubTask1.Click -= eventHandler;
        this._btnUpdateSubTask = value;
        Button btnUpdateSubTask2 = this._btnUpdateSubTask;
        if (btnUpdateSubTask2 == null)
          return;
        btnUpdateSubTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveDownArea
    {
      get
      {
        return this._btnMoveDownArea;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveDownArea_Click);
        Button btnMoveDownArea1 = this._btnMoveDownArea;
        if (btnMoveDownArea1 != null)
          btnMoveDownArea1.Click -= eventHandler;
        this._btnMoveDownArea = value;
        Button btnMoveDownArea2 = this._btnMoveDownArea;
        if (btnMoveDownArea2 == null)
          return;
        btnMoveDownArea2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveUpArea
    {
      get
      {
        return this._btnMoveUpArea;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveUpArea_Click);
        Button btnMoveUpArea1 = this._btnMoveUpArea;
        if (btnMoveUpArea1 != null)
          btnMoveUpArea1.Click -= eventHandler;
        this._btnMoveUpArea = value;
        Button btnMoveUpArea2 = this._btnMoveUpArea;
        if (btnMoveUpArea2 == null)
          return;
        btnMoveUpArea2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveDownTask
    {
      get
      {
        return this._btnMoveDownTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveDownTask_Click);
        Button btnMoveDownTask1 = this._btnMoveDownTask;
        if (btnMoveDownTask1 != null)
          btnMoveDownTask1.Click -= eventHandler;
        this._btnMoveDownTask = value;
        Button btnMoveDownTask2 = this._btnMoveDownTask;
        if (btnMoveDownTask2 == null)
          return;
        btnMoveDownTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveUpTask
    {
      get
      {
        return this._btnMoveUpTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveUpTask_Click);
        Button btnMoveUpTask1 = this._btnMoveUpTask;
        if (btnMoveUpTask1 != null)
          btnMoveUpTask1.Click -= eventHandler;
        this._btnMoveUpTask = value;
        Button btnMoveUpTask2 = this._btnMoveUpTask;
        if (btnMoveUpTask2 == null)
          return;
        btnMoveUpTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveDownSubTask
    {
      get
      {
        return this._btnMoveDownSubTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveDownSubTask_Click);
        Button btnMoveDownSubTask1 = this._btnMoveDownSubTask;
        if (btnMoveDownSubTask1 != null)
          btnMoveDownSubTask1.Click -= eventHandler;
        this._btnMoveDownSubTask = value;
        Button btnMoveDownSubTask2 = this._btnMoveDownSubTask;
        if (btnMoveDownSubTask2 == null)
          return;
        btnMoveDownSubTask2.Click += eventHandler;
      }
    }

    internal virtual Button btnMoveUpSubTask
    {
      get
      {
        return this._btnMoveUpSubTask;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMoveUpSubTask_Click);
        Button btnMoveUpSubTask1 = this._btnMoveUpSubTask;
        if (btnMoveUpSubTask1 != null)
          btnMoveUpSubTask1.Click -= eventHandler;
        this._btnMoveUpSubTask = value;
        Button btnMoveUpSubTask2 = this._btnMoveUpSubTask;
        if (btnMoveUpSubTask2 == null)
          return;
        btnMoveUpSubTask2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSections = new GroupBox();
      this.txtSection = new TextBox();
      this.btnUpdateSection = new Button();
      this.btnRemoveSection = new Button();
      this.dgSection = new DataGrid();
      this.grpAreas = new GroupBox();
      this.btnMoveDownArea = new Button();
      this.btnMoveUpArea = new Button();
      this.txtArea = new TextBox();
      this.btnUpdateArea = new Button();
      this.btnRemoveArea = new Button();
      this.dgArea = new DataGrid();
      this.grpTasks = new GroupBox();
      this.btnMoveDownTask = new Button();
      this.btnMoveUpTask = new Button();
      this.txtTasks = new TextBox();
      this.btnUpdateTask = new Button();
      this.btnRemoveTask = new Button();
      this.dgTask = new DataGrid();
      this.grpSubTask = new GroupBox();
      this.btnMoveDownSubTask = new Button();
      this.btnMoveUpSubTask = new Button();
      this.txtSubTasks = new TextBox();
      this.btnUpdateSubTask = new Button();
      this.btnRemoveSubTask = new Button();
      this.dgSubTask = new DataGrid();
      this.grpSections.SuspendLayout();
      this.dgSection.BeginInit();
      this.grpAreas.SuspendLayout();
      this.dgArea.BeginInit();
      this.grpTasks.SuspendLayout();
      this.dgTask.BeginInit();
      this.grpSubTask.SuspendLayout();
      this.dgSubTask.BeginInit();
      this.SuspendLayout();
      this.grpSections.Controls.Add((Control) this.txtSection);
      this.grpSections.Controls.Add((Control) this.btnUpdateSection);
      this.grpSections.Controls.Add((Control) this.btnRemoveSection);
      this.grpSections.Controls.Add((Control) this.dgSection);
      this.grpSections.Location = new System.Drawing.Point(16, 40);
      this.grpSections.Name = "grpSections";
      this.grpSections.Size = new Size(400, 272);
      this.grpSections.TabIndex = 2;
      this.grpSections.TabStop = false;
      this.grpSections.Text = "Sections";
      this.txtSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSection.Location = new System.Drawing.Point(8, 240);
      this.txtSection.Name = "txtSection";
      this.txtSection.Size = new Size(240, 21);
      this.txtSection.TabIndex = 2;
      this.txtSection.Text = "";
      this.btnUpdateSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdateSection.Location = new System.Drawing.Point(256, 240);
      this.btnUpdateSection.Name = "btnUpdateSection";
      this.btnUpdateSection.Size = new Size(64, 24);
      this.btnUpdateSection.TabIndex = 3;
      this.btnUpdateSection.Text = "Add";
      this.btnRemoveSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveSection.Location = new System.Drawing.Point(328, 240);
      this.btnRemoveSection.Name = "btnRemoveSection";
      this.btnRemoveSection.Size = new Size(64, 24);
      this.btnRemoveSection.TabIndex = 4;
      this.btnRemoveSection.Text = "Remove";
      this.dgSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSection.DataMember = "";
      this.dgSection.HeaderForeColor = SystemColors.ControlText;
      this.dgSection.Location = new System.Drawing.Point(8, 20);
      this.dgSection.Name = "dgSection";
      this.dgSection.Size = new Size(384, 212);
      this.dgSection.TabIndex = 1;
      this.grpAreas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpAreas.Controls.Add((Control) this.btnMoveDownArea);
      this.grpAreas.Controls.Add((Control) this.btnMoveUpArea);
      this.grpAreas.Controls.Add((Control) this.txtArea);
      this.grpAreas.Controls.Add((Control) this.btnUpdateArea);
      this.grpAreas.Controls.Add((Control) this.btnRemoveArea);
      this.grpAreas.Controls.Add((Control) this.dgArea);
      this.grpAreas.Location = new System.Drawing.Point(16, 320);
      this.grpAreas.Name = "grpAreas";
      this.grpAreas.Size = new Size(400, 224);
      this.grpAreas.TabIndex = 3;
      this.grpAreas.TabStop = false;
      this.grpAreas.Text = "Areas For Section ";
      this.btnMoveDownArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveDownArea.Location = new System.Drawing.Point(368, 128);
      this.btnMoveDownArea.Name = "btnMoveDownArea";
      this.btnMoveDownArea.Size = new Size(24, 23);
      this.btnMoveDownArea.TabIndex = 9;
      this.btnMoveDownArea.Text = "/\\";
      this.btnMoveUpArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveUpArea.Location = new System.Drawing.Point(368, 160);
      this.btnMoveUpArea.Name = "btnMoveUpArea";
      this.btnMoveUpArea.Size = new Size(24, 23);
      this.btnMoveUpArea.TabIndex = 10;
      this.btnMoveUpArea.Text = "\\/";
      this.txtArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtArea.Location = new System.Drawing.Point(8, 192);
      this.txtArea.Name = "txtArea";
      this.txtArea.Size = new Size(240, 21);
      this.txtArea.TabIndex = 6;
      this.txtArea.Text = "";
      this.btnUpdateArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdateArea.Location = new System.Drawing.Point(256, 192);
      this.btnUpdateArea.Name = "btnUpdateArea";
      this.btnUpdateArea.Size = new Size(64, 24);
      this.btnUpdateArea.TabIndex = 7;
      this.btnUpdateArea.Text = "Add";
      this.btnRemoveArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveArea.Location = new System.Drawing.Point(328, 193);
      this.btnRemoveArea.Name = "btnRemoveArea";
      this.btnRemoveArea.Size = new Size(64, 24);
      this.btnRemoveArea.TabIndex = 8;
      this.btnRemoveArea.Text = "Remove";
      this.dgArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgArea.DataMember = "";
      this.dgArea.HeaderForeColor = SystemColors.ControlText;
      this.dgArea.Location = new System.Drawing.Point(8, 26);
      this.dgArea.Name = "dgArea";
      this.dgArea.Size = new Size(352, 158);
      this.dgArea.TabIndex = 5;
      this.grpTasks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpTasks.Controls.Add((Control) this.btnMoveDownTask);
      this.grpTasks.Controls.Add((Control) this.btnMoveUpTask);
      this.grpTasks.Controls.Add((Control) this.txtTasks);
      this.grpTasks.Controls.Add((Control) this.btnUpdateTask);
      this.grpTasks.Controls.Add((Control) this.btnRemoveTask);
      this.grpTasks.Controls.Add((Control) this.dgTask);
      this.grpTasks.Location = new System.Drawing.Point(424, 40);
      this.grpTasks.Name = "grpTasks";
      this.grpTasks.Size = new Size(368, 272);
      this.grpTasks.TabIndex = 4;
      this.grpTasks.TabStop = false;
      this.grpTasks.Text = "Tasks For Area";
      this.btnMoveDownTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveDownTask.Location = new System.Drawing.Point(336, 176);
      this.btnMoveDownTask.Name = "btnMoveDownTask";
      this.btnMoveDownTask.Size = new Size(24, 23);
      this.btnMoveDownTask.TabIndex = 15;
      this.btnMoveDownTask.Text = "/\\";
      this.btnMoveUpTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveUpTask.Location = new System.Drawing.Point(336, 208);
      this.btnMoveUpTask.Name = "btnMoveUpTask";
      this.btnMoveUpTask.Size = new Size(24, 23);
      this.btnMoveUpTask.TabIndex = 16;
      this.btnMoveUpTask.Text = "\\/";
      this.txtTasks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTasks.Location = new System.Drawing.Point(8, 240);
      this.txtTasks.Name = "txtTasks";
      this.txtTasks.Size = new Size(208, 21);
      this.txtTasks.TabIndex = 12;
      this.txtTasks.Text = "";
      this.btnUpdateTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdateTask.Location = new System.Drawing.Point(224, 240);
      this.btnUpdateTask.Name = "btnUpdateTask";
      this.btnUpdateTask.Size = new Size(64, 24);
      this.btnUpdateTask.TabIndex = 13;
      this.btnUpdateTask.Text = "Add";
      this.btnRemoveTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveTask.Location = new System.Drawing.Point(296, 241);
      this.btnRemoveTask.Name = "btnRemoveTask";
      this.btnRemoveTask.Size = new Size(64, 24);
      this.btnRemoveTask.TabIndex = 14;
      this.btnRemoveTask.Text = "Remove";
      this.dgTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTask.DataMember = "";
      this.dgTask.HeaderForeColor = SystemColors.ControlText;
      this.dgTask.Location = new System.Drawing.Point(8, 20);
      this.dgTask.Name = "dgTask";
      this.dgTask.Size = new Size(320, 212);
      this.dgTask.TabIndex = 11;
      this.grpSubTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSubTask.Controls.Add((Control) this.btnMoveDownSubTask);
      this.grpSubTask.Controls.Add((Control) this.btnMoveUpSubTask);
      this.grpSubTask.Controls.Add((Control) this.txtSubTasks);
      this.grpSubTask.Controls.Add((Control) this.btnUpdateSubTask);
      this.grpSubTask.Controls.Add((Control) this.btnRemoveSubTask);
      this.grpSubTask.Controls.Add((Control) this.dgSubTask);
      this.grpSubTask.Location = new System.Drawing.Point(424, 320);
      this.grpSubTask.Name = "grpSubTask";
      this.grpSubTask.Size = new Size(368, 224);
      this.grpSubTask.TabIndex = 5;
      this.grpSubTask.TabStop = false;
      this.grpSubTask.Text = "Sub Tasks For Task";
      this.btnMoveDownSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveDownSubTask.Location = new System.Drawing.Point(336, 128);
      this.btnMoveDownSubTask.Name = "btnMoveDownSubTask";
      this.btnMoveDownSubTask.Size = new Size(24, 23);
      this.btnMoveDownSubTask.TabIndex = 21;
      this.btnMoveDownSubTask.Text = "/\\";
      this.btnMoveUpSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMoveUpSubTask.Location = new System.Drawing.Point(336, 160);
      this.btnMoveUpSubTask.Name = "btnMoveUpSubTask";
      this.btnMoveUpSubTask.Size = new Size(24, 23);
      this.btnMoveUpSubTask.TabIndex = 22;
      this.btnMoveUpSubTask.Text = "\\/";
      this.txtSubTasks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSubTasks.Location = new System.Drawing.Point(8, 192);
      this.txtSubTasks.Name = "txtSubTasks";
      this.txtSubTasks.Size = new Size(208, 21);
      this.txtSubTasks.TabIndex = 18;
      this.txtSubTasks.Text = "";
      this.btnUpdateSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdateSubTask.Location = new System.Drawing.Point(224, 192);
      this.btnUpdateSubTask.Name = "btnUpdateSubTask";
      this.btnUpdateSubTask.Size = new Size(64, 24);
      this.btnUpdateSubTask.TabIndex = 19;
      this.btnUpdateSubTask.Text = "Add";
      this.btnRemoveSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveSubTask.Location = new System.Drawing.Point(296, 192);
      this.btnRemoveSubTask.Name = "btnRemoveSubTask";
      this.btnRemoveSubTask.Size = new Size(64, 24);
      this.btnRemoveSubTask.TabIndex = 20;
      this.btnRemoveSubTask.Text = "Remove";
      this.dgSubTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSubTask.DataMember = "";
      this.dgSubTask.HeaderForeColor = SystemColors.ControlText;
      this.dgSubTask.Location = new System.Drawing.Point(8, 26);
      this.dgSubTask.Name = "dgSubTask";
      this.dgSubTask.Size = new Size(320, 158);
      this.dgSubTask.TabIndex = 17;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 558);
      this.Controls.Add((Control) this.grpSubTask);
      this.Controls.Add((Control) this.grpTasks);
      this.Controls.Add((Control) this.grpAreas);
      this.Controls.Add((Control) this.grpSections);
      this.MinimumSize = new Size(808, 592);
      this.Name = nameof (FRMCheckListManager);
      this.Text = "CheckList Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpSections, 0);
      this.Controls.SetChildIndex((Control) this.grpAreas, 0);
      this.Controls.SetChildIndex((Control) this.grpTasks, 0);
      this.Controls.SetChildIndex((Control) this.grpSubTask, 0);
      this.grpSections.ResumeLayout(false);
      this.dgSection.EndInit();
      this.grpAreas.ResumeLayout(false);
      this.dgArea.EndInit();
      this.grpTasks.ResumeLayout(false);
      this.dgTask.EndInit();
      this.grpSubTask.ResumeLayout(false);
      this.dgSubTask.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupSectionsDataGrid();
      this.SetupAreasDataGrid();
      this.SetupTasksDataGrid();
      this.SetupSubTaskDataGrid();
      this.SectionDataView = App.DB.Section.Section_GetAll();
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

    public DataView SectionDataView
    {
      get
      {
        return this._SectionDataView;
      }
      set
      {
        this._SectionDataView = value;
        this._SectionDataView.Table.TableName = Enums.TableNames.tblSection.ToString();
        this._SectionDataView.AllowNew = false;
        this._SectionDataView.AllowEdit = false;
        this._SectionDataView.AllowDelete = false;
        this.dgSection.DataSource = (object) this.SectionDataView;
      }
    }

    private DataRow SelectedSectionDataRow
    {
      get
      {
        return this.dgSection.CurrentRowIndex != -1 ? this.SectionDataView[this.dgSection.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView AreaDataView
    {
      get
      {
        return this._AreaDataView;
      }
      set
      {
        this._AreaDataView = value;
        this._AreaDataView.Table.TableName = Enums.TableNames.tblArea.ToString();
        this._AreaDataView.AllowNew = false;
        this._AreaDataView.AllowEdit = false;
        this._AreaDataView.AllowDelete = false;
        this.dgArea.DataSource = (object) this.AreaDataView;
      }
    }

    private DataRow SelectedAreaDataRow
    {
      get
      {
        return this.dgArea.CurrentRowIndex != -1 ? this.AreaDataView[this.dgArea.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView TaskDataView
    {
      get
      {
        return this._TaskDataView;
      }
      set
      {
        this._TaskDataView = value;
        this._TaskDataView.Table.TableName = Enums.TableNames.tblTask.ToString();
        this._TaskDataView.AllowNew = false;
        this._TaskDataView.AllowEdit = false;
        this._TaskDataView.AllowDelete = false;
        this.dgTask.DataSource = (object) this.TaskDataView;
      }
    }

    private DataRow SelectedTaskDataRow
    {
      get
      {
        return this.dgTask.CurrentRowIndex != -1 ? this.TaskDataView[this.dgTask.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView SubTaskDataView
    {
      get
      {
        return this._SubTaskDataView;
      }
      set
      {
        this._SubTaskDataView = value;
        this._SubTaskDataView.Table.TableName = Enums.TableNames.tblSubTask.ToString();
        this._SubTaskDataView.AllowNew = false;
        this._SubTaskDataView.AllowEdit = false;
        this._SubTaskDataView.AllowDelete = false;
        this.dgSubTask.DataSource = (object) this.SubTaskDataView;
      }
    }

    private DataRow SelectedSubTaskDataRow
    {
      get
      {
        return this.dgSubTask.CurrentRowIndex != -1 ? this.SubTaskDataView[this.dgSubTask.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupSectionsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSection, false);
      DataGridTableStyle tableStyle = this.dgSection.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Description";
      dataGridLabelColumn.MappingName = "Description";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSection.ToString();
      this.dgSection.TableStyles.Add(tableStyle);
    }

    public void SetupAreasDataGrid()
    {
      Helper.SetUpDataGrid(this.dgArea, false);
      DataGridTableStyle tableStyle = this.dgArea.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Description";
      dataGridLabelColumn.MappingName = "Description";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblArea.ToString();
      this.dgArea.TableStyles.Add(tableStyle);
    }

    public void SetupTasksDataGrid()
    {
      Helper.SetUpDataGrid(this.dgTask, false);
      DataGridTableStyle tableStyle = this.dgTask.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Description";
      dataGridLabelColumn.MappingName = "Description";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblTask.ToString();
      this.dgTask.TableStyles.Add(tableStyle);
    }

    public void SetupSubTaskDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSubTask, false);
      DataGridTableStyle tableStyle = this.dgSubTask.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Description";
      dataGridLabelColumn.MappingName = "Description";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSubTask.ToString();
      this.dgSubTask.TableStyles.Add(tableStyle);
    }

    private void FRMCheckListManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgSection_Click(object sender, EventArgs e)
    {
      if (this.SelectedSectionDataRow == null)
      {
        this.btnUpdateSection.Text = "Add";
      }
      else
      {
        this.SectionSelected = true;
        this.txtSection.Text = Conversions.ToString(this.SelectedSectionDataRow["Description"]);
        this.btnUpdateSection.Text = "Update";
        this.AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(this.SelectedSectionDataRow["SectionID"]));
        this.grpAreas.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Areas For Section: ", this.SelectedSectionDataRow["Description"]));
        if (this.TaskDataView != null)
        {
          this.TaskDataView.Table.Rows.Clear();
          this.grpTasks.Text = "Tasks";
        }
        if (this.SubTaskDataView != null)
        {
          this.SubTaskDataView.Table.Rows.Clear();
          this.grpSubTask.Text = "Sub-Tasks";
        }
        this.txtArea.Text = "";
        this.btnUpdateArea.Text = "Add";
        this.txtTasks.Text = "";
        this.btnUpdateTask.Text = "Add";
        this.txtSubTasks.Text = "";
        this.btnUpdateSubTask.Text = "Add";
      }
    }

    private void dgArea_Click(object sender, EventArgs e)
    {
      if (this.SelectedAreaDataRow == null)
      {
        this.btnUpdateArea.Text = "Add";
      }
      else
      {
        this.AreaSelected = true;
        this.txtArea.Text = Conversions.ToString(this.SelectedAreaDataRow["Description"]);
        this.btnUpdateArea.Text = "Update";
        this.TaskDataView = App.DB.Task.Task_Get_For_Area(RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]));
        this.grpTasks.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Tasks For Area: ", this.SelectedAreaDataRow["Description"]));
        if (this.SubTaskDataView != null)
        {
          this.SubTaskDataView.Table.Rows.Clear();
          this.grpSubTask.Text = "Sub-Tasks";
        }
        this.txtTasks.Text = "";
        this.btnUpdateTask.Text = "Add";
        this.txtSubTasks.Text = "";
        this.btnUpdateSubTask.Text = "Add";
      }
    }

    private void dgTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedTaskDataRow == null)
      {
        this.btnUpdateTask.Text = "Add";
      }
      else
      {
        this.TaskSelected = true;
        this.txtTasks.Text = Conversions.ToString(this.SelectedTaskDataRow["Description"]);
        this.btnUpdateTask.Text = "Update";
        this.grpSubTask.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Sub-Tasks For Task: ", this.SelectedTaskDataRow["Description"]));
        this.SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]));
        this.txtSubTasks.Text = "";
        this.btnUpdateSubTask.Text = "Add";
      }
    }

    private void dgSubTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedSubTaskDataRow == null)
      {
        this.btnUpdateSubTask.Text = "Add";
      }
      else
      {
        this.SubTaskSelected = true;
        this.txtSubTasks.Text = Conversions.ToString(this.SelectedSubTaskDataRow["Description"]);
        this.btnUpdateSubTask.Text = "Update";
      }
    }

    private void btnUpdateSection_Click(object sender, EventArgs e)
    {
      bool flag;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnUpdateSection.Text, "Add", false) == 0)
      {
        flag = this.AddSection();
      }
      else
      {
        if (this.SelectedSectionDataRow == null)
        {
          int num = (int) App.ShowMessage("Please select a section to update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        flag = this.UpdateSection();
      }
      if (flag)
      {
        this.btnUpdateSection.Text = "Add";
        this.btnUpdateArea.Text = "Add";
        this.btnUpdateTask.Text = "Add";
        this.btnUpdateSubTask.Text = "Add";
        this.txtSection.Text = "";
        this.txtArea.Text = "";
        this.txtTasks.Text = "";
        this.txtSubTasks.Text = "";
        this.SectionDataView = App.DB.Section.Section_GetAll();
        if (this.AreaDataView != null)
        {
          this.AreaDataView.Table.Rows.Clear();
          this.grpAreas.Text = "Areas";
        }
        if (this.TaskDataView != null)
        {
          this.TaskDataView.Table.Rows.Clear();
          this.grpTasks.Text = "Tasks";
        }
        if (this.SubTaskDataView != null)
        {
          this.SubTaskDataView.Table.Rows.Clear();
          this.grpSubTask.Text = "Sub-Tasks";
        }
      }
    }

    private void btnUpdateArea_Click(object sender, EventArgs e)
    {
      bool flag;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnUpdateArea.Text, "Add", false) == 0)
      {
        if (this.SelectedSectionDataRow == null | !this.SectionSelected)
        {
          int num = (int) App.ShowMessage("Please select a section to link this area to", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        flag = this.AddArea();
      }
      else
      {
        if (this.SelectedAreaDataRow == null)
        {
          int num = (int) App.ShowMessage("Please select an area to update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        flag = this.UpdateArea();
      }
      if (flag)
      {
        this.btnUpdateArea.Text = "Add";
        this.btnUpdateTask.Text = "Add";
        this.btnUpdateSubTask.Text = "Add";
        this.txtArea.Text = "";
        this.txtTasks.Text = "";
        this.txtSubTasks.Text = "";
        this.AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(this.SelectedSectionDataRow["SectionID"]));
        if (this.TaskDataView != null)
        {
          this.TaskDataView.Table.Rows.Clear();
          this.grpTasks.Text = "Tasks";
        }
        if (this.SubTaskDataView != null)
        {
          this.SubTaskDataView.Table.Rows.Clear();
          this.grpSubTask.Text = "Sub-Tasks";
        }
      }
    }

    private void btnUpdateTask_Click(object sender, EventArgs e)
    {
      bool flag;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnUpdateTask.Text, "Add", false) == 0)
      {
        if (this.SelectedAreaDataRow == null | !this.AreaSelected)
        {
          int num = (int) App.ShowMessage("Please select an area to link this task to", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        flag = this.AddTask();
      }
      else
      {
        if (this.SelectedTaskDataRow == null)
        {
          int num = (int) App.ShowMessage("Please select a task to update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        flag = this.UpdateTask();
      }
      if (flag)
      {
        this.btnUpdateTask.Text = "Add";
        this.btnUpdateSubTask.Text = "Add";
        this.txtTasks.Text = "";
        this.txtSubTasks.Text = "";
        this.TaskDataView = App.DB.Task.Task_Get_For_Area(RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]));
        if (this.SubTaskDataView != null)
        {
          this.SubTaskDataView.Table.Rows.Clear();
          this.grpSubTask.Text = "Sub-Tasks";
        }
      }
    }

    private void btnUpdateSubTask_Click(object sender, EventArgs e)
    {
      bool flag;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnUpdateSubTask.Text, "Add", false) == 0)
      {
        if (this.SelectedTaskDataRow == null | !this.TaskSelected)
        {
          int num = (int) App.ShowMessage("Please select a task to link this sub task to", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        flag = this.AddSubTask();
      }
      else
      {
        if (this.SelectedSubTaskDataRow == null)
        {
          int num = (int) App.ShowMessage("Please select a sub task to update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        flag = this.UpdateSubTask();
      }
      if (flag)
      {
        this.btnUpdateSubTask.Text = "Add";
        this.txtSubTasks.Text = "";
        this.SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]));
      }
    }

    private void btnRemoveSection_Click(object sender, EventArgs e)
    {
      if (this.SelectedSectionDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Plase select a section to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this Section? All associated Areas, Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          this.Cursor = Cursors.WaitCursor;
          App.DB.Section.Delete(Conversions.ToInteger(this.SelectedSectionDataRow["SectionID"]));
          this.btnUpdateSection.Text = "Add";
          this.btnUpdateArea.Text = "Add";
          this.btnUpdateTask.Text = "Add";
          this.btnUpdateSubTask.Text = "Add";
          this.txtSection.Text = "";
          this.txtArea.Text = "";
          this.txtTasks.Text = "";
          this.txtSubTasks.Text = "";
          this.SectionDataView = App.DB.Section.Section_GetAll();
          if (this.AreaDataView != null)
          {
            this.AreaDataView.Table.Rows.Clear();
            this.grpAreas.Text = "Areas";
          }
          if (this.TaskDataView != null)
          {
            this.TaskDataView.Table.Rows.Clear();
            this.grpTasks.Text = "Tasks";
          }
          if (this.SubTaskDataView != null)
          {
            this.SubTaskDataView.Table.Rows.Clear();
            this.grpSubTask.Text = "Sub-Tasks";
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Could not delete section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    private void btnRemoveArea_Click(object sender, EventArgs e)
    {
      if (this.SelectedAreaDataRow == null | this.SelectedSectionDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Plase select an area to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this Area? All associated Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          this.Cursor = Cursors.WaitCursor;
          App.DB.Area.Delete(Conversions.ToInteger(this.SelectedAreaDataRow["AreaID"]));
          this.btnUpdateArea.Text = "Add";
          this.btnUpdateTask.Text = "Add";
          this.btnUpdateSubTask.Text = "Add";
          this.txtArea.Text = "";
          this.txtTasks.Text = "";
          this.txtSubTasks.Text = "";
          this.AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(this.SelectedSectionDataRow["SectionID"]));
          if (this.TaskDataView != null)
          {
            this.TaskDataView.Table.Rows.Clear();
            this.grpTasks.Text = "Tasks";
          }
          if (this.SubTaskDataView != null)
          {
            this.SubTaskDataView.Table.Rows.Clear();
            this.grpSubTask.Text = "Sub-Tasks";
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Could not delete area", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    private void btnRemoveTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedTaskDataRow == null | this.SelectedAreaDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Plase select a task to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this Task? All associated Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          this.Cursor = Cursors.WaitCursor;
          App.DB.Task.Delete(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]));
          this.btnUpdateTask.Text = "Add";
          this.btnUpdateSubTask.Text = "Add";
          this.txtTasks.Text = "";
          this.txtSubTasks.Text = "";
          this.TaskDataView = App.DB.Task.Task_Get_For_Area(RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]));
          if (this.SubTaskDataView != null)
          {
            this.SubTaskDataView.Table.Rows.Clear();
            this.grpSubTask.Text = "Sub-Tasks";
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Could not delete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    private void btnRemoveSubTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedSubTaskDataRow == null | this.SelectedTaskDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Plase select a sub task to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this Sub-Task?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          this.Cursor = Cursors.WaitCursor;
          App.DB.SubTask.Delete(Conversions.ToInteger(this.SelectedSubTaskDataRow["SubTaskID"]));
          this.btnUpdateSubTask.Text = "Add";
          this.txtSubTasks.Text = "";
          this.SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Could not delete sub task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    private void btnMoveUpArea_Click(object sender, EventArgs e)
    {
      if (this.SelectedAreaDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select an area to move down", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.Area.Area_AdjustOrderNumber(Conversions.ToInteger(this.SelectedAreaDataRow["AreaID"]), Conversions.ToInteger(this.SelectedAreaDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(this.SelectedAreaDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedAreaDataRow["SectionID"]));
        this.AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(this.SelectedAreaDataRow["SectionID"]));
      }
    }

    private void btnMoveDownArea_Click(object sender, EventArgs e)
    {
      if (this.SelectedAreaDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select an area to move up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.Area.Area_AdjustOrderNumber(Conversions.ToInteger(this.SelectedAreaDataRow["AreaID"]), Conversions.ToInteger(this.SelectedAreaDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedAreaDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedAreaDataRow["SectionID"]));
        this.AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(this.SelectedAreaDataRow["SectionID"]));
      }
    }

    private void btnMoveUpTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedTaskDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select a task to move down", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.Task.Task_AdjustOrderNumber(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]), Conversions.ToInteger(this.SelectedTaskDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(this.SelectedTaskDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedTaskDataRow["AreaID"]));
        this.TaskDataView = App.DB.Task.Task_Get_For_Area(RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["AreaID"]));
      }
    }

    private void btnMoveDownTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedTaskDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select a task to move up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.Task.Task_AdjustOrderNumber(Conversions.ToInteger(this.SelectedTaskDataRow["TaskID"]), Conversions.ToInteger(this.SelectedTaskDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedTaskDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedTaskDataRow["AreaID"]));
        this.TaskDataView = App.DB.Task.Task_Get_For_Area(RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["AreaID"]));
      }
    }

    private void btnMoveUpSubTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedSubTaskDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select a sub task to move down", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.SubTask.SubTask_AdjustOrderNumber(Conversions.ToInteger(this.SelectedSubTaskDataRow["SubTaskID"]), Conversions.ToInteger(this.SelectedSubTaskDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(this.SelectedSubTaskDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedSubTaskDataRow["TaskID"]));
        this.SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(this.SelectedSubTaskDataRow["TaskID"]));
      }
    }

    private void btnMoveDownSubTask_Click(object sender, EventArgs e)
    {
      if (this.SelectedSubTaskDataRow == null)
      {
        int num = (int) App.ShowMessage("Plase select a sub task to move up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.SubTask.SubTask_AdjustOrderNumber(Conversions.ToInteger(this.SelectedSubTaskDataRow["SubTaskID"]), Conversions.ToInteger(this.SelectedSubTaskDataRow["OrderNumber"]), Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.SelectedSubTaskDataRow["OrderNumber"], (object) 1)), Conversions.ToInteger(this.SelectedSubTaskDataRow["TaskID"]));
        this.SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(this.SelectedSubTaskDataRow["TaskID"]));
      }
    }

    private bool AddSection()
    {
      bool flag;
      try
      {
        Section oSection = new Section();
        this.Cursor = Cursors.WaitCursor;
        oSection.IgnoreExceptionsOnSetMethods = true;
        oSection.SetDescription = (object) this.txtSection.Text;
        new SectionValidator().Validate(oSection);
        App.DB.Section.Insert(oSection);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool UpdateSection()
    {
      bool flag;
      try
      {
        Section oSection = new Section();
        this.Cursor = Cursors.WaitCursor;
        oSection.IgnoreExceptionsOnSetMethods = true;
        if (this.SelectedSectionDataRow != null)
        {
          oSection.SetDescription = (object) this.txtSection.Text;
          oSection.SetSectionID = RuntimeHelpers.GetObjectValue(this.SelectedSectionDataRow["SectionID"]);
          new SectionValidator().Validate(oSection);
          App.DB.Section.Update(oSection);
          flag = true;
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool AddArea()
    {
      bool flag;
      try
      {
        Area oArea = new Area();
        this.Cursor = Cursors.WaitCursor;
        oArea.IgnoreExceptionsOnSetMethods = true;
        oArea.SetDescription = (object) this.txtArea.Text;
        oArea.SetSectionID = RuntimeHelpers.GetObjectValue(this.SelectedSectionDataRow["SectionID"]);
        new AreaValidator().Validate(oArea);
        App.DB.Area.Insert(oArea);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool UpdateArea()
    {
      bool flag;
      try
      {
        Area oArea = new Area();
        this.Cursor = Cursors.WaitCursor;
        oArea.IgnoreExceptionsOnSetMethods = true;
        if (!(this.SelectedAreaDataRow == null | this.SelectedSectionDataRow == null))
        {
          oArea.SetDescription = (object) this.txtArea.Text;
          oArea.SetSectionID = RuntimeHelpers.GetObjectValue(this.SelectedSectionDataRow["SectionID"]);
          oArea.SetAreaID = RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]);
          oArea.SetOrderNumber = RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["OrderNumber"]);
          new AreaValidator().Validate(oArea);
          App.DB.Area.Update(oArea);
          flag = true;
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool AddTask()
    {
      bool flag;
      try
      {
        Task oTask = new Task();
        this.Cursor = Cursors.WaitCursor;
        oTask.IgnoreExceptionsOnSetMethods = true;
        oTask.SetDescription = (object) this.txtTasks.Text;
        oTask.SetAreaID = RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]);
        new TaskValidator().Validate(oTask);
        App.DB.Task.Insert(oTask);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool UpdateTask()
    {
      bool flag;
      try
      {
        Task oTask = new Task();
        this.Cursor = Cursors.WaitCursor;
        oTask.IgnoreExceptionsOnSetMethods = true;
        if (!(this.SelectedAreaDataRow == null | this.SelectedTaskDataRow == null))
        {
          oTask.SetDescription = (object) this.txtTasks.Text;
          oTask.SetAreaID = RuntimeHelpers.GetObjectValue(this.SelectedAreaDataRow["AreaID"]);
          oTask.SetOrderNumber = RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["OrderNumber"]);
          oTask.SetTaskID = RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["TaskID"]);
          new TaskValidator().Validate(oTask);
          App.DB.Task.Update(oTask);
          flag = true;
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool AddSubTask()
    {
      bool flag;
      try
      {
        SubTask oSubTask = new SubTask();
        this.Cursor = Cursors.WaitCursor;
        oSubTask.IgnoreExceptionsOnSetMethods = true;
        oSubTask.SetDescription = (object) this.txtSubTasks.Text;
        oSubTask.SetTaskID = RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["TaskID"]);
        new SubTaskValidator().Validate(oSubTask);
        App.DB.SubTask.Insert(oSubTask);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private bool UpdateSubTask()
    {
      bool flag;
      try
      {
        SubTask oSubTask = new SubTask();
        this.Cursor = Cursors.WaitCursor;
        oSubTask.IgnoreExceptionsOnSetMethods = true;
        if (!(this.SelectedTaskDataRow == null | this.SelectedSubTaskDataRow == null))
        {
          oSubTask.SetDescription = (object) this.txtSubTasks.Text;
          oSubTask.SetTaskID = RuntimeHelpers.GetObjectValue(this.SelectedTaskDataRow["TaskID"]);
          oSubTask.SetSubTaskID = RuntimeHelpers.GetObjectValue(this.SelectedSubTaskDataRow["SubTaskID"]);
          oSubTask.SetOrderNumber = RuntimeHelpers.GetObjectValue(this.SelectedSubTaskDataRow["OrderNumber"]);
          new SubTaskValidator().Validate(oSubTask);
          App.DB.SubTask.Update(oSubTask);
          flag = true;
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
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
