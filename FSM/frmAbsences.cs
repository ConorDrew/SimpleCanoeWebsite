// Decompiled with JetBrains decompiler
// Type: FSM.frmAbsences
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
  public class frmAbsences : FRMBaseForm
  {
    private IContainer components;
    private DataView _dvAbsences;

    public frmAbsences()
    {
      this.Load += new EventHandler(this.frmHolidays_Load);
      this._dvAbsences = new DataView();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox Search { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnShowResults
    {
      get
      {
        return this._btnShowResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowResults_Click);
        Button btnShowResults1 = this._btnShowResults;
        if (btnShowResults1 != null)
          btnShowResults1.Click -= eventHandler;
        this._btnShowResults = value;
        Button btnShowResults2 = this._btnShowResults;
        if (btnShowResults2 == null)
          return;
        btnShowResults2.Click += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAbsences
    {
      get
      {
        return this._dgAbsences;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgAbsences_DoubleClick);
        DataGrid dgAbsences1 = this._dgAbsences;
        if (dgAbsences1 != null)
          dgAbsences1.DoubleClick -= eventHandler;
        this._dgAbsences = value;
        DataGrid dgAbsences2 = this._dgAbsences;
        if (dgAbsences2 == null)
          return;
        dgAbsences2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnNew
    {
      get
      {
        return this._btnNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNew_Click);
        Button btnNew1 = this._btnNew;
        if (btnNew1 != null)
          btnNew1.Click -= eventHandler;
        this._btnNew = value;
        Button btnNew2 = this._btnNew;
        if (btnNew2 == null)
          return;
        btnNew2.Click += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUsers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenu mnuAbsenceType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuEngineerAbsence
    {
      get
      {
        return this._mnuEngineerAbsence;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuEngineerAbsence_Click);
        MenuItem mnuEngineerAbsence1 = this._mnuEngineerAbsence;
        if (mnuEngineerAbsence1 != null)
          mnuEngineerAbsence1.Click -= eventHandler;
        this._mnuEngineerAbsence = value;
        MenuItem mnuEngineerAbsence2 = this._mnuEngineerAbsence;
        if (mnuEngineerAbsence2 == null)
          return;
        mnuEngineerAbsence2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuUserAbsence
    {
      get
      {
        return this._mnuUserAbsence;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuUserAbsence_Click);
        MenuItem mnuUserAbsence1 = this._mnuUserAbsence;
        if (mnuUserAbsence1 != null)
          mnuUserAbsence1.Click -= eventHandler;
        this._mnuUserAbsence = value;
        MenuItem mnuUserAbsence2 = this._mnuUserAbsence;
        if (mnuUserAbsence2 == null)
          return;
        mnuUserAbsence2.Click += eventHandler;
      }
    }

    internal virtual MenuItem MenuItem2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuBlockOfAbsences
    {
      get
      {
        return this._mnuBlockOfAbsences;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuBlockOfAbsences_Click);
        MenuItem mnuBlockOfAbsences1 = this._mnuBlockOfAbsences;
        if (mnuBlockOfAbsences1 != null)
          mnuBlockOfAbsences1.Click -= eventHandler;
        this._mnuBlockOfAbsences = value;
        MenuItem mnuBlockOfAbsences2 = this._mnuBlockOfAbsences;
        if (mnuBlockOfAbsences2 == null)
          return;
        mnuBlockOfAbsences2.Click += eventHandler;
      }
    }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.dgAbsences = new DataGrid();
      this.Search = new GroupBox();
      this.Label5 = new Label();
      this.cboUsers = new ComboBox();
      this.Label2 = new Label();
      this.dtTo = new DateTimePicker();
      this.dtFrom = new DateTimePicker();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.cboType = new ComboBox();
      this.btnShowResults = new Button();
      this.Label1 = new Label();
      this.cboEngineers = new ComboBox();
      this.btnNew = new Button();
      this.mnuAbsenceType = new ContextMenu();
      this.mnuEngineerAbsence = new MenuItem();
      this.mnuUserAbsence = new MenuItem();
      this.btnDelete = new Button();
      this.mnuBlockOfAbsences = new MenuItem();
      this.MenuItem2 = new MenuItem();
      this.GroupBox1.SuspendLayout();
      this.dgAbsences.BeginInit();
      this.Search.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgAbsences);
      this.GroupBox1.Font = new Font("Verdana", 8f);
      this.GroupBox1.Location = new System.Drawing.Point(8, 192);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(741, 216);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Double click to edit";
      this.dgAbsences.AllowNavigation = false;
      this.dgAbsences.AlternatingBackColor = Color.GhostWhite;
      this.dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAbsences.BackgroundColor = Color.White;
      this.dgAbsences.BorderStyle = BorderStyle.FixedSingle;
      this.dgAbsences.CaptionBackColor = Color.RoyalBlue;
      this.dgAbsences.CaptionForeColor = Color.White;
      this.dgAbsences.CaptionVisible = false;
      this.dgAbsences.DataMember = "";
      this.dgAbsences.Font = new Font("Verdana", 8f);
      this.dgAbsences.ForeColor = Color.MidnightBlue;
      this.dgAbsences.GridLineColor = Color.RoyalBlue;
      this.dgAbsences.HeaderBackColor = Color.MidnightBlue;
      this.dgAbsences.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
      this.dgAbsences.HeaderForeColor = Color.Lavender;
      this.dgAbsences.LinkColor = Color.Teal;
      this.dgAbsences.Location = new System.Drawing.Point(10, 17);
      this.dgAbsences.Name = "dgAbsences";
      this.dgAbsences.ParentRowsBackColor = Color.Lavender;
      this.dgAbsences.ParentRowsForeColor = Color.MidnightBlue;
      this.dgAbsences.ParentRowsVisible = false;
      this.dgAbsences.RowHeadersVisible = false;
      this.dgAbsences.SelectionBackColor = Color.Teal;
      this.dgAbsences.SelectionForeColor = Color.PaleGreen;
      this.dgAbsences.Size = new Size(722, 190);
      this.dgAbsences.TabIndex = 7;
      this.Search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Search.Controls.Add((Control) this.Label5);
      this.Search.Controls.Add((Control) this.cboUsers);
      this.Search.Controls.Add((Control) this.Label2);
      this.Search.Controls.Add((Control) this.dtTo);
      this.Search.Controls.Add((Control) this.dtFrom);
      this.Search.Controls.Add((Control) this.Label4);
      this.Search.Controls.Add((Control) this.Label3);
      this.Search.Controls.Add((Control) this.cboType);
      this.Search.Controls.Add((Control) this.btnShowResults);
      this.Search.Controls.Add((Control) this.Label1);
      this.Search.Controls.Add((Control) this.cboEngineers);
      this.Search.Font = new Font("Verdana", 8f);
      this.Search.Location = new System.Drawing.Point(8, 40);
      this.Search.Name = "Search";
      this.Search.Size = new Size(741, 144);
      this.Search.TabIndex = 1;
      this.Search.TabStop = false;
      this.Search.Text = "Search";
      this.Label5.Font = new Font("Verdana", 8f);
      this.Label5.Location = new System.Drawing.Point(16, 52);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(96, 17);
      this.Label5.TabIndex = 24;
      this.Label5.Text = "User:";
      this.cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUsers.Font = new Font("Verdana", 8f);
      this.cboUsers.Location = new System.Drawing.Point(112, 48);
      this.cboUsers.Name = "cboUsers";
      this.cboUsers.Size = new Size(624, 21);
      this.cboUsers.TabIndex = 2;
      this.Label2.Font = new Font("Verdana", 8f);
      this.Label2.Location = new System.Drawing.Point(16, 112);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(80, 18);
      this.Label2.TabIndex = 22;
      this.Label2.Text = "Absent From";
      this.dtTo.Font = new Font("Verdana", 8f);
      this.dtTo.Format = DateTimePickerFormat.Short;
      this.dtTo.Location = new System.Drawing.Point(304, 112);
      this.dtTo.Name = "dtTo";
      this.dtTo.Size = new Size(152, 20);
      this.dtTo.TabIndex = 5;
      this.dtFrom.Font = new Font("Verdana", 8f);
      this.dtFrom.Format = DateTimePickerFormat.Short;
      this.dtFrom.Location = new System.Drawing.Point(112, 112);
      this.dtFrom.Name = "dtFrom";
      this.dtFrom.Size = new Size(152, 20);
      this.dtFrom.TabIndex = 4;
      this.dtFrom.Value = new DateTime(2007, 9, 14, 0, 0, 0, 0);
      this.Label4.Font = new Font("Verdana", 8f);
      this.Label4.Location = new System.Drawing.Point(272, 112);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(32, 18);
      this.Label4.TabIndex = 19;
      this.Label4.Text = "To";
      this.Label3.Font = new Font("Verdana", 8f);
      this.Label3.Location = new System.Drawing.Point(16, 80);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(96, 17);
      this.Label3.TabIndex = 18;
      this.Label3.Text = "Absence Type:";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Font = new Font("Verdana", 8f);
      this.cboType.Location = new System.Drawing.Point(112, 80);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(624, 21);
      this.cboType.TabIndex = 3;
      this.btnShowResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnShowResults.UseVisualStyleBackColor = true;
      this.btnShowResults.Font = new Font("Verdana", 8f);
      this.btnShowResults.Location = new System.Drawing.Point(670, 112);
      this.btnShowResults.Name = "btnShowResults";
      this.btnShowResults.Size = new Size(64, 23);
      this.btnShowResults.TabIndex = 6;
      this.btnShowResults.Text = "Show";
      this.Label1.Font = new Font("Verdana", 8f);
      this.Label1.Location = new System.Drawing.Point(16, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(96, 17);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Engineer:";
      this.cboEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineers.Font = new Font("Verdana", 8f);
      this.cboEngineers.Location = new System.Drawing.Point(112, 19);
      this.cboEngineers.Name = "cboEngineers";
      this.cboEngineers.Size = new Size(624, 21);
      this.cboEngineers.TabIndex = 1;
      this.btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnNew.ContextMenu = this.mnuAbsenceType;
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Font = new Font("Verdana", 8f);
      this.btnNew.Location = new System.Drawing.Point(8, 416);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new Size(64, 23);
      this.btnNew.TabIndex = 8;
      this.btnNew.Text = "Add New";
      this.mnuAbsenceType.MenuItems.AddRange(new MenuItem[4]
      {
        this.mnuEngineerAbsence,
        this.mnuUserAbsence,
        this.MenuItem2,
        this.mnuBlockOfAbsences
      });
      this.mnuEngineerAbsence.Index = 0;
      this.mnuEngineerAbsence.Text = "Engineer Absence";
      this.mnuUserAbsence.Index = 1;
      this.mnuUserAbsence.Text = "User Absence";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Font = new Font("Verdana", 8f);
      this.btnDelete.Location = new System.Drawing.Point(688, 416);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(64, 23);
      this.btnDelete.TabIndex = 9;
      this.btnDelete.Text = "Delete";
      this.mnuBlockOfAbsences.Index = 3;
      this.mnuBlockOfAbsences.Text = "Block of Absences";
      this.MenuItem2.Index = 2;
      this.MenuItem2.Text = "-";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(760, 446);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnNew);
      this.Controls.Add((Control) this.Search);
      this.Controls.Add((Control) this.GroupBox1);
      this.MinimumSize = new Size(768, 480);
      this.Name = nameof (frmAbsences);
      this.Text = "Absences";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.Search, 0);
      this.Controls.SetChildIndex((Control) this.btnNew, 0);
      this.Controls.SetChildIndex((Control) this.btnDelete, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgAbsences.EndInit();
      this.Search.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public DataView AbsencesDataView
    {
      get
      {
        return this._dvAbsences;
      }
      set
      {
        this._dvAbsences = value;
        this._dvAbsences.Table.TableName = "tblEngineerAbsence";
        this.dgAbsences.DataSource = (object) this._dvAbsences;
        this._dvAbsences.AllowNew = false;
        this._dvAbsences.AllowEdit = false;
        this._dvAbsences.AllowDelete = false;
      }
    }

    public DataRow SelectedAbsenceRow
    {
      get
      {
        return this.dgAbsences.CurrentRowIndex > -1 ? this.AbsencesDataView[this.dgAbsences.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public event frmAbsences.RefreshEngineerAbsencesEventHandler RefreshEngineerAbsences;

    private void frmHolidays_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.SetupAbsenceDataGridGrid();
      this.LoadEngineerComboBox();
      this.LoadUserComboBox();
      this.LoadAbsencestypeComboBox();
    }

    private void btnShowResults_Click(object sender, EventArgs e)
    {
      this.SearchAbsences();
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
      this.EditAbsence();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      this.mnuAbsenceType.Show((Control) this.btnNew, new System.Drawing.Point(0, 0));
    }

    private void dgAbsences_DoubleClick(object sender, EventArgs e)
    {
      this.EditAbsence();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.DeleteAbsence();
    }

    private void mnuEngineerAbsence_Click(object sender, EventArgs e)
    {
      int num = (int) new FrmEngineerAbsence(0).ShowDialog();
    }

    private void mnuUserAbsence_Click(object sender, EventArgs e)
    {
      int num = (int) new FrmUserAbsence(0).ShowDialog();
    }

    private void mnuBlockOfAbsences_Click(object sender, EventArgs e)
    {
      FrmBlockAbsence frmBlockAbsence = new FrmBlockAbsence();
      frmBlockAbsence.UserAbsenceChanged += new FrmBlockAbsence.UserAbsenceChangedEventHandler(this.SearchAbsences);
      int num = (int) frmBlockAbsence.ShowDialog();
    }

    private void SetupAbsenceDataGridGrid()
    {
      this.SuspendLayout();
      Helper.SetUpDataGrid(this.dgAbsences, false);
      DataGridTableStyle tableStyle = this.dgAbsences.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAbsences.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      dataGridLabelColumn1.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.MappingName = "PersonnelType";
      dataGridLabelColumn2.HeaderText = "Personnel Type";
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      dataGridLabelColumn2.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.Width = 110;
      dataGridLabelColumn3.NullText = "";
      dataGridLabelColumn3.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.MappingName = "DateFrom";
      dataGridLabelColumn4.HeaderText = "Date From";
      dataGridLabelColumn4.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      dataGridLabelColumn4.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.MappingName = "DateTo";
      dataGridLabelColumn5.HeaderText = "Date To";
      dataGridLabelColumn5.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn5.NullText = "";
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.MappingName = "tblEngineerAbsence";
      this.dgAbsences.TableStyles.Add(tableStyle);
      this.ResumeLayout();
    }

    private void LoadAbsencestypeComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable all = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
      DataRow row = all.NewRow();
      row["Description"] = (object) "All";
      row["EngineerAbsenceTypeID"] = (object) 0;
      all.Rows.InsertAt(row, 0);
      all.AcceptChanges();
      this.cboType.DataSource = (object) all;
      this.cboType.DisplayMember = "Description";
      this.cboType.ValueMember = "EngineerAbsenceTypeID";
    }

    private void LoadEngineerComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable table = App.DB.Engineer.Engineer_GetAll().Table;
      DataRow row = table.NewRow();
      row["Name"] = (object) "All";
      row["EngineerID"] = (object) 0;
      table.Rows.InsertAt(row, 0);
      table.AcceptChanges();
      this.cboEngineers.DataSource = (object) table;
      this.cboEngineers.DisplayMember = "Name";
      this.cboEngineers.ValueMember = "EngineerID";
    }

    private void LoadUserComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable table = App.DB.User.GetAll().Table;
      DataRow row = table.NewRow();
      row["Fullname"] = (object) "All";
      row["UserID"] = (object) 0;
      table.Rows.InsertAt(row, 0);
      table.AcceptChanges();
      this.cboUsers.DataSource = (object) table;
      this.cboUsers.DisplayMember = "Fullname";
      this.cboUsers.ValueMember = "UserID";
    }

    public void EditAbsence()
    {
      if (this.dgAbsences.CurrentRowIndex <= -1 || this.SelectedAbsenceRow == null)
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedAbsenceRow["PersonnelType"], (object) "Engineer", false))
      {
        int num1 = (int) new FrmEngineerAbsence(Conversions.ToInteger(this.SelectedAbsenceRow["ID"])).ShowDialog();
      }
      else
      {
        int num2 = (int) new FrmUserAbsence(Conversions.ToInteger(this.SelectedAbsenceRow["ID"])).ShowDialog();
      }
    }

    public void NewAbsence()
    {
      int num = (int) new FrmEngineerAbsence(0).ShowDialog();
    }

    private void SearchAbsences()
    {
      ArrayList arrayList1 = new ArrayList();
      string str1 = "SELECT EngineerAbsenceID AS ID,'Engineer' as PersonnelType , tblEngineer.Name as [Name], DateTo, DateFrom, AbsenceTypeID, Description" + " FROM tblEngineerAbsence" + " INNER JOIN tblEngineer ON tblEngineer.EngineerID = tblEngineerAbsence.EngineerID" + " LEFT JOIN tblEngineerAbsenceTypes ON tblEngineerAbsenceTypes.EngineerAbsenceTypeID = tblEngineerAbsence.AbsenceTypeID";
      string str2 = "";
      string str3 = " (('{0}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR  ('{1}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR  (tblEngineerAbsence.DateFrom Between '{0}' AND '{1}' AND tblEngineerAbsence.DateTo Between '{0}' AND '{1}') ) ";
      ArrayList arrayList2 = arrayList1;
      string format1 = str3;
      DateTime dateTime = this.dtFrom.Value;
      string str4 = dateTime.ToString("yyyy-MM-dd") + " 00:00:00";
      dateTime = this.dtTo.Value;
      string str5 = dateTime.ToString("yyyy-MM-dd") + " 23:59:59";
      string str6 = string.Format(format1, (object) str4, (object) str5);
      arrayList2.Add((object) str6);
      if (this.cboEngineers.SelectedIndex > 0)
        arrayList1.Add((object) string.Format(" tblEngineerAbsence.EngineerID = '{0}'", RuntimeHelpers.GetObjectValue(this.cboEngineers.SelectedValue)));
      if (this.cboType.SelectedIndex > 0)
        arrayList1.Add((object) string.Format("tblEngineerAbsenceTypes.EngineerAbsenceTypeID = {0}", RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue)));
      arrayList1.Add((object) " tblEngineerAbsence.Deleted = 0");
      arrayList1.Add((object) " tblEngineer.Deleted = 0");
      arrayList1.Add((object) " tblEngineerAbsenceTypes.Deleted = 0");
      if (arrayList1.Count > 0)
      {
        str1 += "  WHERE";
        int num = checked (arrayList1.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (index > 0)
            str1 += " AND";
          str1 = str1 + " " + Conversions.ToString(arrayList1[index]);
          checked { ++index; }
        }
      }
      arrayList1.Clear();
      string sql = str1 + " UNION " + "SELECT UserAbsenceID AS ID, 'User' as PersonnelType ,tblUser.Fullname AS [Name] , DateTo, DateFrom, AbsenceTypeID, Description" + " FROM tblUserAbsence" + " INNER JOIN tblUser ON tblUser.UserID = tblUserAbsence.UserID" + " LEFT JOIN tblUserAbsenceTypes ON tblUserAbsenceTypes.UserAbsenceTypeID = tblUserAbsence.AbsenceTypeID";
      str2 = "";
      string format2 = " (('{0}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR  ('{1}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR  (tblUserAbsence.DateFrom Between '{0}' AND '{1}' AND tblUserAbsence.DateTo Between '{0}' AND '{1}') ) ";
      arrayList1.Add((object) string.Format(format2, (object) (this.dtFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"), (object) (this.dtTo.Value.ToString("yyyy-MM-dd") + " 23:59:59")));
      if (this.cboUsers.SelectedIndex > 0)
        arrayList1.Add((object) string.Format(" tblUserAbsence.UserID = '{0}'", RuntimeHelpers.GetObjectValue(this.cboUsers.SelectedValue)));
      if (this.cboType.SelectedIndex > 0)
        arrayList1.Add((object) string.Format("tblUserAbsenceTypes.UserAbsenceTypeID = {0}", RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue)));
      arrayList1.Add((object) " tblUserAbsence.Deleted = 0");
      arrayList1.Add((object) " tblUser.Deleted = 0");
      arrayList1.Add((object) " tblUserAbsenceTypes.Deleted = 0");
      if (arrayList1.Count > 0)
      {
        sql += "  WHERE";
        int num = checked (arrayList1.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (index > 0)
            sql += " AND";
          sql = sql + " " + Conversions.ToString(arrayList1[index]);
          checked { ++index; }
        }
      }
      DataTable table = App.DB.EngineerAbsence.AbsenceSearch(sql);
      this.AbsencesDataView = new DataView(table);
      if (table.Rows.Count > 0)
        this.dgAbsences.Select(0);
      this.ActiveControl = (Control) this.cboEngineers;
      this.cboEngineers.Focus();
    }

    private void DeleteAbsence()
    {
      if (this.dgAbsences.CurrentRowIndex > -1)
      {
        if (this.SelectedAbsenceRow == null)
          return;
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedAbsenceRow["PersonnelType"], (object) "Engineer", false))
        {
          if (MessageBox.Show(string.Format("Are you sure you want to delete engineer {0}'s absence from {1} to {2}?", RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["Name"]), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["DateFrom"]), "dd/MM/yy"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["DateTo"]), "dd/MM/yy")), "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          {
            App.DB.EngineerAbsence.Delete(Conversions.ToInteger(this.SelectedAbsenceRow["ID"]));
            this.SearchAbsences();
          }
        }
        else if (MessageBox.Show(string.Format("Are you sure you want to delete user {0}'s absence from {1} to {2}?", RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["Name"]), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["DateFrom"]), "dd/MM/yy"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedAbsenceRow["DateTo"]), "dd/MM/yy")), "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
          App.DB.UserAbsence.Delete(Conversions.ToInteger(this.SelectedAbsenceRow["ID"]));
          this.SearchAbsences();
        }
      }
      else
      {
        int num = (int) App.ShowMessage("Please select an absence to delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    public delegate void RefreshEngineerAbsencesEventHandler();
  }
}
