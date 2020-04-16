// Decompiled with JetBrains decompiler
// Type: FSM.FrmBlockAbsence
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  [DesignerGenerated]
  public class FrmBlockAbsence : FRMBaseForm
  {
    private IContainer components;
    private DataView _dvEmployees;

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.txtEndTimeMinutes = new TextBox();
      this.txtEndTimeHours = new TextBox();
      this.txtStartTimeMinutes = new TextBox();
      this.txtStartTimeHours = new TextBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.lblType = new Label();
      this.cboType = new ComboBox();
      this.dtTo = new DateTimePicker();
      this.dtFrom = new DateTimePicker();
      this.txtComments = new TextBox();
      this.lblToDate = new Label();
      this.lblFromDate = new Label();
      this.lblComments = new Label();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.gbEmployees = new GroupBox();
      this.cboEmployeeGroup = new ComboBox();
      this.Label24 = new Label();
      this.btnClearAll = new Button();
      this.btnSelectAll = new Button();
      this.dgEmployees = new DataGrid();
      this.GroupBox1.SuspendLayout();
      this.gbEmployees.SuspendLayout();
      this.dgEmployees.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtEndTimeMinutes);
      this.GroupBox1.Controls.Add((Control) this.txtEndTimeHours);
      this.GroupBox1.Controls.Add((Control) this.txtStartTimeMinutes);
      this.GroupBox1.Controls.Add((Control) this.txtStartTimeHours);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.lblType);
      this.GroupBox1.Controls.Add((Control) this.cboType);
      this.GroupBox1.Controls.Add((Control) this.dtTo);
      this.GroupBox1.Controls.Add((Control) this.dtFrom);
      this.GroupBox1.Controls.Add((Control) this.txtComments);
      this.GroupBox1.Controls.Add((Control) this.lblToDate);
      this.GroupBox1.Controls.Add((Control) this.lblFromDate);
      this.GroupBox1.Controls.Add((Control) this.lblComments);
      this.GroupBox1.Font = new Font("Verdana", 8f);
      this.GroupBox1.Location = new System.Drawing.Point(12, 371);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(624, 153);
      this.GroupBox1.TabIndex = 26;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Absence Details";
      this.txtEndTimeMinutes.Location = new System.Drawing.Point(288, 88);
      this.txtEndTimeMinutes.Name = "txtEndTimeMinutes";
      this.txtEndTimeMinutes.Size = new Size(24, 20);
      this.txtEndTimeMinutes.TabIndex = 53;
      this.txtEndTimeHours.Location = new System.Drawing.Point(256, 88);
      this.txtEndTimeHours.Name = "txtEndTimeHours";
      this.txtEndTimeHours.Size = new Size(24, 20);
      this.txtEndTimeHours.TabIndex = 52;
      this.txtStartTimeMinutes.Location = new System.Drawing.Point(288, 56);
      this.txtStartTimeMinutes.Name = "txtStartTimeMinutes";
      this.txtStartTimeMinutes.Size = new Size(24, 20);
      this.txtStartTimeMinutes.TabIndex = 51;
      this.txtStartTimeHours.Location = new System.Drawing.Point(256, 56);
      this.txtStartTimeHours.Name = "txtStartTimeHours";
      this.txtStartTimeHours.Size = new Size(24, 20);
      this.txtStartTimeHours.TabIndex = 50;
      this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(280, 88);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(8, 17);
      this.Label4.TabIndex = 49;
      this.Label4.Text = ":";
      this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(280, 56);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(8, 17);
      this.Label3.TabIndex = 48;
      this.Label3.Text = ":";
      this.lblType.Font = new Font("Verdana", 8f);
      this.lblType.Location = new System.Drawing.Point(8, 24);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(70, 17);
      this.lblType.TabIndex = 37;
      this.lblType.Text = "Type";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Font = new Font("Verdana", 8f);
      this.cboType.ItemHeight = 13;
      this.cboType.Items.AddRange(new object[3]
      {
        (object) "Holiday",
        (object) "Sickness",
        (object) "Other"
      });
      this.cboType.Location = new System.Drawing.Point(80, 24);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(232, 21);
      this.cboType.TabIndex = 2;
      this.dtTo.Font = new Font("Verdana", 8f);
      this.dtTo.Location = new System.Drawing.Point(80, 88);
      this.dtTo.Name = "dtTo";
      this.dtTo.Size = new Size(173, 20);
      this.dtTo.TabIndex = 6;
      this.dtFrom.Font = new Font("Verdana", 8f);
      this.dtFrom.Location = new System.Drawing.Point(80, 56);
      this.dtFrom.Name = "dtFrom";
      this.dtFrom.Size = new Size(172, 20);
      this.dtFrom.TabIndex = 3;
      this.txtComments.Font = new Font("Verdana", 8f);
      this.txtComments.Location = new System.Drawing.Point(320, 43);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Both;
      this.txtComments.Size = new Size(296, 96);
      this.txtComments.TabIndex = 9;
      this.lblToDate.Font = new Font("Verdana", 8f);
      this.lblToDate.Location = new System.Drawing.Point(8, 88);
      this.lblToDate.Name = "lblToDate";
      this.lblToDate.Size = new Size(46, 18);
      this.lblToDate.TabIndex = 20;
      this.lblToDate.Text = "To";
      this.lblFromDate.Font = new Font("Verdana", 8f);
      this.lblFromDate.Location = new System.Drawing.Point(8, 56);
      this.lblFromDate.Name = "lblFromDate";
      this.lblFromDate.Size = new Size(69, 18);
      this.lblFromDate.TabIndex = 19;
      this.lblFromDate.Text = "From";
      this.lblComments.Font = new Font("Verdana", 8f);
      this.lblComments.Location = new System.Drawing.Point(320, 22);
      this.lblComments.Name = "lblComments";
      this.lblComments.Size = new Size(72, 17);
      this.lblComments.TabIndex = 23;
      this.lblComments.Text = "Comments";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Font = new Font("Verdana", 8f);
      this.btnSave.Location = new System.Drawing.Point(572, 529);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(64, 23);
      this.btnSave.TabIndex = 27;
      this.btnSave.Text = "Save";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Font = new Font("Verdana", 8f);
      this.btnCancel.Location = new System.Drawing.Point(4, 529);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(64, 23);
      this.btnCancel.TabIndex = 28;
      this.btnCancel.Text = "Cancel";
      this.gbEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gbEmployees.Controls.Add((Control) this.cboEmployeeGroup);
      this.gbEmployees.Controls.Add((Control) this.Label24);
      this.gbEmployees.Controls.Add((Control) this.btnClearAll);
      this.gbEmployees.Controls.Add((Control) this.btnSelectAll);
      this.gbEmployees.Controls.Add((Control) this.dgEmployees);
      this.gbEmployees.Font = new Font("Verdana", 8f);
      this.gbEmployees.Location = new System.Drawing.Point(12, 38);
      this.gbEmployees.Name = "gbEmployees";
      this.gbEmployees.Size = new Size(624, 327);
      this.gbEmployees.TabIndex = 29;
      this.gbEmployees.TabStop = false;
      this.gbEmployees.Text = "Employees";
      this.cboEmployeeGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEmployeeGroup.Cursor = Cursors.Hand;
      this.cboEmployeeGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEmployeeGroup.Items.AddRange(new object[2]
      {
        (object) "Engineers",
        (object) "Users"
      });
      this.cboEmployeeGroup.Location = new System.Drawing.Point(118, 14);
      this.cboEmployeeGroup.Name = "cboEmployeeGroup";
      this.cboEmployeeGroup.Size = new Size(322, 21);
      this.cboEmployeeGroup.TabIndex = 46;
      this.cboEmployeeGroup.Tag = (object) "";
      this.Label24.Location = new System.Drawing.Point(6, 16);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(105, 20);
      this.Label24.TabIndex = 47;
      this.Label24.Text = "Employee Group";
      this.btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClearAll.UseVisualStyleBackColor = true;
      this.btnClearAll.Font = new Font("Verdana", 8f);
      this.btnClearAll.Location = new System.Drawing.Point(80, 293);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new Size(64, 23);
      this.btnClearAll.TabIndex = 3;
      this.btnClearAll.Text = "Clear All";
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Font = new Font("Verdana", 8f);
      this.btnSelectAll.Location = new System.Drawing.Point(10, 293);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(64, 23);
      this.btnSelectAll.TabIndex = 2;
      this.btnSelectAll.Text = "Select All";
      this.dgEmployees.AllowNavigation = false;
      this.dgEmployees.AlternatingBackColor = Color.GhostWhite;
      this.dgEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEmployees.BackgroundColor = Color.White;
      this.dgEmployees.BorderStyle = BorderStyle.FixedSingle;
      this.dgEmployees.CaptionBackColor = Color.RoyalBlue;
      this.dgEmployees.CaptionForeColor = Color.White;
      this.dgEmployees.CaptionText = "Engineers";
      this.dgEmployees.CaptionVisible = false;
      this.dgEmployees.DataMember = "";
      this.dgEmployees.Font = new Font("Verdana", 8f);
      this.dgEmployees.ForeColor = Color.MidnightBlue;
      this.dgEmployees.GridLineColor = Color.RoyalBlue;
      this.dgEmployees.HeaderBackColor = Color.MidnightBlue;
      this.dgEmployees.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
      this.dgEmployees.HeaderForeColor = Color.Lavender;
      this.dgEmployees.LinkColor = Color.Teal;
      this.dgEmployees.Location = new System.Drawing.Point(10, 41);
      this.dgEmployees.Name = "dgEmployees";
      this.dgEmployees.ParentRowsBackColor = Color.Lavender;
      this.dgEmployees.ParentRowsForeColor = Color.MidnightBlue;
      this.dgEmployees.ParentRowsVisible = false;
      this.dgEmployees.RowHeadersVisible = false;
      this.dgEmployees.SelectionBackColor = Color.Teal;
      this.dgEmployees.SelectionForeColor = Color.PaleGreen;
      this.dgEmployees.Size = new Size(605, 243);
      this.dgEmployees.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(648, 558);
      this.Controls.Add((Control) this.gbEmployees);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.GroupBox1);
      this.MaximizeBox = false;
      this.MinimumSize = new Size(656, 592);
      this.Name = nameof (FrmBlockAbsence);
      this.Text = "Block Absences";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.gbEmployees, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.gbEmployees.ResumeLayout(false);
      this.dgEmployees.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEndTimeMinutes
    {
      get
      {
        return this._txtEndTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox txtEndTimeMinutes1 = this._txtEndTimeMinutes;
        if (txtEndTimeMinutes1 != null)
          txtEndTimeMinutes1.TextChanged -= eventHandler;
        this._txtEndTimeMinutes = value;
        TextBox txtEndTimeMinutes2 = this._txtEndTimeMinutes;
        if (txtEndTimeMinutes2 == null)
          return;
        txtEndTimeMinutes2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtEndTimeHours
    {
      get
      {
        return this._txtEndTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox txtEndTimeHours1 = this._txtEndTimeHours;
        if (txtEndTimeHours1 != null)
          txtEndTimeHours1.TextChanged -= eventHandler;
        this._txtEndTimeHours = value;
        TextBox txtEndTimeHours2 = this._txtEndTimeHours;
        if (txtEndTimeHours2 == null)
          return;
        txtEndTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeMinutes
    {
      get
      {
        return this._txtStartTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox startTimeMinutes1 = this._txtStartTimeMinutes;
        if (startTimeMinutes1 != null)
          startTimeMinutes1.TextChanged -= eventHandler;
        this._txtStartTimeMinutes = value;
        TextBox startTimeMinutes2 = this._txtStartTimeMinutes;
        if (startTimeMinutes2 == null)
          return;
        startTimeMinutes2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeHours
    {
      get
      {
        return this._txtStartTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox txtStartTimeHours1 = this._txtStartTimeHours;
        if (txtStartTimeHours1 != null)
          txtStartTimeHours1.TextChanged -= eventHandler;
        this._txtStartTimeHours = value;
        TextBox txtStartTimeHours2 = this._txtStartTimeHours;
        if (txtStartTimeHours2 == null)
          return;
        txtStartTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblToDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFromDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual GroupBox gbEmployees { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEmployeeGroup
    {
      get
      {
        return this._cboEmployeeGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboEmployeeGroup_SelectedIndexChanged);
        ComboBox cboEmployeeGroup1 = this._cboEmployeeGroup;
        if (cboEmployeeGroup1 != null)
          cboEmployeeGroup1.SelectedIndexChanged -= eventHandler;
        this._cboEmployeeGroup = value;
        ComboBox cboEmployeeGroup2 = this._cboEmployeeGroup;
        if (cboEmployeeGroup2 == null)
          return;
        cboEmployeeGroup2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClearAll
    {
      get
      {
        return this._btnClearAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearAll_Click);
        Button btnClearAll1 = this._btnClearAll;
        if (btnClearAll1 != null)
          btnClearAll1.Click -= eventHandler;
        this._btnClearAll = value;
        Button btnClearAll2 = this._btnClearAll;
        if (btnClearAll2 == null)
          return;
        btnClearAll2.Click += eventHandler;
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

    internal virtual DataGrid dgEmployees
    {
      get
      {
        return this._dgEmployees;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgEmployees_Clicks);
        EventHandler eventHandler2 = new EventHandler(this.dgEmployees_Clicks);
        DataGrid dgEmployees1 = this._dgEmployees;
        if (dgEmployees1 != null)
        {
          dgEmployees1.Click -= eventHandler1;
          dgEmployees1.DoubleClick -= eventHandler2;
        }
        this._dgEmployees = value;
        DataGrid dgEmployees2 = this._dgEmployees;
        if (dgEmployees2 == null)
          return;
        dgEmployees2.Click += eventHandler1;
        dgEmployees2.DoubleClick += eventHandler2;
      }
    }

    public FrmBlockAbsence()
    {
      this.Load += new EventHandler(this.FrmBlockAbsence_Load);
      this.InitializeComponent();
      this.LoadAbsencestypeComboBox();
    }

    public event FrmBlockAbsence.UserAbsenceChangedEventHandler UserAbsenceChanged;

    public DataView EmployeesDataView
    {
      get
      {
        return this._dvEmployees;
      }
      set
      {
        this._dvEmployees = value;
        if (this.EmployeesDataView != null && this.EmployeesDataView.Table != null)
        {
          this._dvEmployees.Table.TableName = "tblEmployees";
          this._dvEmployees.AllowNew = false;
        }
        this.dgEmployees.DataSource = (object) this.EmployeesDataView;
      }
    }

    private void setUpDataGrid()
    {
      this.SuspendLayout();
      Helper.SetUpDataGrid(this.dgEmployees, false);
      DataGridTableStyle tableStyle = this.dgEmployees.TableStyles[0];
      tableStyle.ReadOnly = false;
      this.dgEmployees.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Include";
      dataGridBoolColumn.MappingName = "Include";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.AllowNull = false;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Name";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 200;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = "tblEmployees";
      this.dgEmployees.TableStyles.Add(tableStyle);
      this.ResumeLayout(true);
    }

    private void LoadAbsencestypeComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable all = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
      DataRow row = all.NewRow();
      row["Description"] = (object) "-- Please Select --";
      row["EngineerAbsenceTypeID"] = (object) 0;
      all.Rows.InsertAt(row, 0);
      all.AcceptChanges();
      this.cboType.DataSource = (object) all;
      this.cboType.DisplayMember = "Description";
      this.cboType.ValueMember = "EngineerAbsenceTypeID";
    }

    private void Save()
    {
      try
      {
        if (!Versioned.IsNumeric((object) this.txtStartTimeHours.Text) || Conversions.ToDouble(this.txtStartTimeHours.Text) < 0.0 || Conversions.ToDouble(this.txtStartTimeHours.Text) > 23.0 || (!Versioned.IsNumeric((object) this.txtStartTimeMinutes.Text) || Conversions.ToDouble(this.txtStartTimeMinutes.Text) < 0.0 || Conversions.ToDouble(this.txtStartTimeMinutes.Text) > 59.0))
        {
          int num1 = (int) MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        }
        else if (!Versioned.IsNumeric((object) this.txtEndTimeHours.Text) || Conversions.ToDouble(this.txtEndTimeHours.Text) < 0.0 || Conversions.ToDouble(this.txtEndTimeHours.Text) > 23.0 || (!Versioned.IsNumeric((object) this.txtEndTimeMinutes.Text) || Conversions.ToDouble(this.txtEndTimeMinutes.Text) < 0.0 || Conversions.ToDouble(this.txtEndTimeMinutes.Text) > 59.0))
        {
          int num2 = (int) MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        }
        else
        {
          DateTime t1 = new DateTime(this.dtFrom.Value.Year, this.dtFrom.Value.Month, this.dtFrom.Value.Day, Conversions.ToInteger(this.txtStartTimeHours.Text), Conversions.ToInteger(this.txtStartTimeMinutes.Text), 0);
          int year = this.dtTo.Value.Year;
          DateTime dateTime = this.dtTo.Value;
          int month = dateTime.Month;
          dateTime = this.dtTo.Value;
          int day = dateTime.Day;
          int integer1 = Conversions.ToInteger(this.txtEndTimeHours.Text);
          int integer2 = Conversions.ToInteger(this.txtEndTimeMinutes.Text);
          DateTime t2 = new DateTime(year, month, day, integer1, integer2, 0);
          if (DateTime.Compare(t1, t2) > 0)
          {
            int num3 = (int) MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboType.SelectedValue, (object) 0, false))
          {
            int num4 = (int) MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
          }
          else
          {
            IEnumerator enumerator;
            try
            {
              enumerator = this.EmployeesDataView.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRowView current = (DataRowView) enumerator.Current;
                if (Conversions.ToBoolean(current["Include"]))
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboEmployeeGroup.Text, "Engineers", false) == 0)
                    App.DB.EngineerAbsence.Insert(new FSM.Entity.EngineerAbsence.EngineerAbsence()
                    {
                      IgnoreExceptionsOnSetMethods = false,
                      SetComments = (object) this.txtComments.Text,
                      SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue),
                      SetEngineerID = (object) Conversions.ToString(current["ID"]),
                      DateFrom = t1,
                      DateTo = t2
                    });
                  else
                    App.DB.UserAbsence.Insert(new FSM.Entity.UserAbsence.UserAbsence()
                    {
                      IgnoreExceptionsOnSetMethods = false,
                      SetComments = (object) this.txtComments.Text,
                      SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue),
                      SetUserID = (object) Conversions.ToString(current["ID"]),
                      DateFrom = t1,
                      DateTo = t2
                    });
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            // ISSUE: reference to a compiler-generated field
            FrmBlockAbsence.UserAbsenceChangedEventHandler absenceChangedEvent = this.UserAbsenceChangedEvent;
            if (absenceChangedEvent != null)
              absenceChangedEvent();
            if (this.Modal)
              this.Close();
            else
              this.Dispose();
          }
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) MessageBox.Show(string.Format("Please correct the following errors:{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void FrmBlockAbsence_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.setUpDataGrid();
      this.cboEmployeeGroup.SelectedIndex = 0;
      this.ActiveControl = (Control) this.cboEmployeeGroup;
      this.cboEmployeeGroup.Focus();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgEmployees_Clicks(object sender, EventArgs e)
    {
      try
      {
        int index = 0;
        DataGrid.HitTestInfo hitTestInfo = this.dgEmployees.HitTest(this.dgEmployees.PointToClient(Control.MousePosition));
        BindingManagerBase bindingManagerBase = this.BindingContext[RuntimeHelpers.GetObjectValue(this.dgEmployees.DataSource), this.dgEmployees.DataMember];
        if (hitTestInfo.Row >= bindingManagerBase.Count || hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != index)
          return;
        bool flag = !Conversions.ToBoolean(this.dgEmployees[hitTestInfo.Row, index]);
        this.dgEmployees[hitTestInfo.Row, index] = (object) flag;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ex.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.EmployeesDataView == null)
          return;
        IEnumerator enumerator;
        if (this.EmployeesDataView.Table != null)
        {
          try
          {
            enumerator = this.EmployeesDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
              ((DataRow) enumerator.Current)["Include"] = (object) true;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.EmployeesDataView == null)
          return;
        IEnumerator enumerator;
        if (this.EmployeesDataView.Table != null)
        {
          try
          {
            enumerator = this.EmployeesDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
              ((DataRow) enumerator.Current)["Include"] = (object) false;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void cboEmployeeGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        DataTable dataTable = new DataTable();
        DataTable table;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboEmployeeGroup.Text, "Engineers", false) == 0)
        {
          table = App.DB.Engineer.Engineer_GetAll().Table;
          table.Columns["EngineerID"].ColumnName = "ID";
          this.gbEmployees.Text = "Engineers";
        }
        else
        {
          table = App.DB.User.GetAll().Table;
          table.Columns["Fullname"].ColumnName = "Name";
          table.Columns["UserID"].ColumnName = "ID";
          this.gbEmployees.Text = "Users";
        }
        table.Columns.Add(new DataColumn()
        {
          DataType = typeof (bool),
          DefaultValue = (object) false,
          ColumnName = "Include",
          ReadOnly = false
        });
        table.TableName = "tblEmployees";
        table.AcceptChanges();
        this.EmployeesDataView = new DataView(table);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
    {
      TextBox[] array = new TextBox[4]
      {
        this.txtStartTimeHours,
        this.txtStartTimeMinutes,
        this.txtEndTimeHours,
        this.txtEndTimeMinutes
      };
      TextBox textBox = (TextBox) sender;
      if (textBox.Text.Length >= 2 && Array.IndexOf<TextBox>(array, textBox) < checked (array.Length - 1))
      {
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].Focus();
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].SelectAll();
      }
      else
      {
        if (textBox.Text.Length != 0 || checked (Array.IndexOf<TextBox>(array, textBox) - 1) < 0)
          return;
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].Focus();
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].SelectAll();
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        bool flag = false;
        IEnumerator enumerator;
        if (this.EmployeesDataView != null)
        {
          if (this.EmployeesDataView.Table != null)
          {
            try
            {
              enumerator = this.EmployeesDataView.GetEnumerator();
              while (enumerator.MoveNext())
              {
                if (Conversions.ToBoolean(((DataRowView) enumerator.Current)["Include"]))
                  flag = true;
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
        }
        if (!flag)
        {
          int num = (int) MessageBox.Show("You must select at least one employee from the list", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
        else
          this.Save();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public delegate void UserAbsenceChangedEventHandler();
  }
}
