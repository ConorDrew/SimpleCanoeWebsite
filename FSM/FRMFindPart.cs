// Decompiled with JetBrains decompiler
// Type: FSM.FRMFindPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMFindPart : FRMBaseForm, IForm
  {
    private IContainer components;
    private SqlTransaction _Trans;
    public DataRow[] Datarows;
    private Enums.TableNames _TableToSearch;
    private int _foreignKeyFilter;
    private string _PartNumber;
    private bool _ForMassPartEntry;
    private DataView _dvRecords;
    private int _ID;
    private int _2ndID;
    private ArrayList _PartsToAdd;
    private int _PartID;
    private int _PartSupplierID;
    private DataGridViewSelectedRowCollection old;

    public FRMFindPart()
    {
      this.Load += new EventHandler(this.DLGFindRecord_Load);
      this.Datarows = (DataRow[]) null;
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this._ForMassPartEntry = false;
      this._ID = 0;
      this._2ndID = 0;
      this._PartsToAdd = (ArrayList) null;
      this._PartID = 0;
      this._PartSupplierID = 0;
      this.InitializeComponent();
    }

    public FRMFindPart(SqlTransaction trans)
    {
      this.Load += new EventHandler(this.DLGFindRecord_Load);
      this.Datarows = (DataRow[]) null;
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this._ForMassPartEntry = false;
      this._ID = 0;
      this._2ndID = 0;
      this._PartsToAdd = (ArrayList) null;
      this._PartID = 0;
      this._PartSupplierID = 0;
      this.Trans = trans;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label lblFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFilter
    {
      get
      {
        return this._txtFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtFilter_TextChanged);
        TextBox txtFilter1 = this._txtFilter;
        if (txtFilter1 != null)
          txtFilter1.TextChanged -= eventHandler;
        this._txtFilter = value;
        TextBox txtFilter2 = this._txtFilter;
        if (txtFilter2 == null)
          return;
        txtFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpResults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
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

    internal virtual Label lblPreferredSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlGreen { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblFilter = new Label();
      this.txtFilter = new TextBox();
      this.grpResults = new GroupBox();
      this.dgvParts = new DataGridView();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.lblPreferredSupplier = new Label();
      this.pnlGreen = new Panel();
      this.btnSearch = new Button();
      this.grpResults.SuspendLayout();
      ((ISupportInitialize) this.dgvParts).BeginInit();
      this.SuspendLayout();
      this.lblFilter.Location = new System.Drawing.Point(8, 40);
      this.lblFilter.Name = "lblFilter";
      this.lblFilter.Size = new Size(100, 24);
      this.lblFilter.TabIndex = 2;
      this.lblFilter.Text = "Filter By Name";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(104, 40);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(562, 21);
      this.txtFilter.TabIndex = 1;
      this.grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpResults.Controls.Add((Control) this.dgvParts);
      this.grpResults.Location = new System.Drawing.Point(8, 68);
      this.grpResults.Name = "grpResults";
      this.grpResults.Size = new Size(793, 377);
      this.grpResults.TabIndex = 4;
      this.grpResults.TabStop = false;
      this.grpResults.Text = "Select record and click OK";
      this.dgvParts.AllowUserToAddRows = false;
      this.dgvParts.AllowUserToDeleteRows = false;
      this.dgvParts.AllowUserToOrderColumns = true;
      this.dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvParts.Location = new System.Drawing.Point(8, 20);
      this.dgvParts.Name = "dgvParts";
      this.dgvParts.ReadOnly = true;
      this.dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvParts.Size = new Size(777, 351);
      this.dgvParts.TabIndex = 0;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(745, 451);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(56, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 451);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.lblPreferredSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPreferredSupplier.Location = new System.Drawing.Point(95, 456);
      this.lblPreferredSupplier.Name = "lblPreferredSupplier";
      this.lblPreferredSupplier.Size = new Size(175, 24);
      this.lblPreferredSupplier.TabIndex = 7;
      this.lblPreferredSupplier.Text = "Preferred Supplier";
      this.pnlGreen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pnlGreen.BackColor = Color.LightGreen;
      this.pnlGreen.Location = new System.Drawing.Point(70, 454);
      this.pnlGreen.Name = "pnlGreen";
      this.pnlGreen.Size = new Size(19, 20);
      this.pnlGreen.TabIndex = 8;
      this.btnSearch.Location = new System.Drawing.Point(673, 39);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(128, 23);
      this.btnSearch.TabIndex = 9;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(809, 481);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnSearch);
      this.Controls.Add((Control) this.pnlGreen);
      this.Controls.Add((Control) this.lblPreferredSupplier);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.grpResults);
      this.Controls.Add((Control) this.txtFilter);
      this.Controls.Add((Control) this.lblFilter);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(704, 392);
      this.Name = nameof (FRMFindPart);
      this.Text = "Find {0}";
      this.Controls.SetChildIndex((Control) this.lblFilter, 0);
      this.Controls.SetChildIndex((Control) this.txtFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpResults, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.lblPreferredSupplier, 0);
      this.Controls.SetChildIndex((Control) this.pnlGreen, 0);
      this.Controls.SetChildIndex((Control) this.btnSearch, 0);
      this.grpResults.ResumeLayout(false);
      ((ISupportInitialize) this.dgvParts).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ActiveControl = (Control) this.txtFilter;
      this.txtFilter.Focus();
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

    public SqlTransaction Trans
    {
      get
      {
        return this._Trans;
      }
      set
      {
        this._Trans = value;
      }
    }

    public Enums.TableNames TableToSearch
    {
      get
      {
        return this._TableToSearch;
      }
      set
      {
        this.MinimumSize = new Size(new System.Drawing.Point(704, 392));
        this._TableToSearch = value;
        if (this.TableToSearch == Enums.TableNames.tblPart)
        {
          Helper.SetUpDataGridView(this.dgvParts, false);
          this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          this.dgvParts.AutoGenerateColumns = false;
          this.dgvParts.Columns.Clear();
          this.dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
          DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn1.HeaderText = "Qty";
          viewTextBoxColumn1.DataPropertyName = "Qty";
          viewTextBoxColumn1.FillWeight = 30f;
          viewTextBoxColumn1.ReadOnly = false;
          viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
          DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn2.FillWeight = 60f;
          viewTextBoxColumn2.HeaderText = "Part Name";
          viewTextBoxColumn2.DataPropertyName = "Name";
          viewTextBoxColumn2.ReadOnly = true;
          viewTextBoxColumn2.Visible = true;
          viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
          DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn3.HeaderText = "Part Number";
          viewTextBoxColumn3.DataPropertyName = "Number";
          viewTextBoxColumn3.FillWeight = 50f;
          viewTextBoxColumn3.ReadOnly = true;
          viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
          DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn4.HeaderText = "Reference";
          viewTextBoxColumn4.DataPropertyName = "Reference";
          viewTextBoxColumn4.FillWeight = 50f;
          viewTextBoxColumn4.ReadOnly = true;
          viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
          this.Records = App.DB.Part.Part_Search(this.txtFilter.Text, "");
        }
        else if (this.TableToSearch == Enums.TableNames.NOT_IN_Database_tblPartSupplierQty)
        {
          Helper.SetUpDataGridView(this.dgvParts, false);
          this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          this.dgvParts.AutoGenerateColumns = false;
          this.dgvParts.Columns.Clear();
          this.dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
          DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn1.HeaderText = "Qty";
          viewTextBoxColumn1.DataPropertyName = "Qty";
          viewTextBoxColumn1.FillWeight = 30f;
          viewTextBoxColumn1.ReadOnly = false;
          viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
          DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn2.FillWeight = 60f;
          viewTextBoxColumn2.HeaderText = "Part Name";
          viewTextBoxColumn2.DataPropertyName = "PartName";
          viewTextBoxColumn2.ReadOnly = true;
          viewTextBoxColumn2.Visible = true;
          viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
          DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn3.HeaderText = "Part Number";
          viewTextBoxColumn3.DataPropertyName = "PartNumber";
          viewTextBoxColumn3.FillWeight = 50f;
          viewTextBoxColumn3.ReadOnly = true;
          viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
          DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn4.HeaderText = "Reference";
          viewTextBoxColumn4.DataPropertyName = "Reference";
          viewTextBoxColumn4.FillWeight = 50f;
          viewTextBoxColumn4.ReadOnly = true;
          viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Automatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
          DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn5.HeaderText = "SPN";
          viewTextBoxColumn5.DataPropertyName = "PartCode";
          viewTextBoxColumn5.FillWeight = 50f;
          viewTextBoxColumn5.ReadOnly = true;
          viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
          DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn6.HeaderText = "Supplier Name";
          viewTextBoxColumn6.DataPropertyName = "SupplierName";
          viewTextBoxColumn6.FillWeight = 60f;
          viewTextBoxColumn6.ReadOnly = true;
          viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Automatic;
          viewTextBoxColumn6.Visible = true;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
          DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn7.HeaderText = "Price";
          viewTextBoxColumn7.DataPropertyName = "Price";
          viewTextBoxColumn7.FillWeight = 60f;
          viewTextBoxColumn7.ReadOnly = true;
          viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Automatic;
          viewTextBoxColumn7.Visible = true;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
          this.Records = (DataView) App.DB.PartSupplier.PartSupplier_Search(this.txtFilter.Text, 0, false);
        }
        else
        {
          Helper.SetUpDataGridView(this.dgvParts, false);
          this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          this.dgvParts.AutoGenerateColumns = false;
          this.dgvParts.Columns.Clear();
          this.dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
          DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
          viewCheckBoxColumn.FillWeight = 30f;
          viewCheckBoxColumn.HeaderText = "Include";
          viewCheckBoxColumn.DataPropertyName = "Tick";
          viewCheckBoxColumn.ReadOnly = false;
          viewCheckBoxColumn.Visible = true;
          viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
          DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn1.FillWeight = 60f;
          viewTextBoxColumn1.HeaderText = "Part Name";
          viewTextBoxColumn1.DataPropertyName = "PartName";
          viewTextBoxColumn1.ReadOnly = true;
          viewTextBoxColumn1.Visible = true;
          viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
          DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn2.HeaderText = "Part Number";
          viewTextBoxColumn2.DataPropertyName = "PartNumber";
          viewTextBoxColumn2.FillWeight = 50f;
          viewTextBoxColumn2.ReadOnly = true;
          viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
          DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn3.HeaderText = "SPN";
          viewTextBoxColumn3.DataPropertyName = "PartCode";
          viewTextBoxColumn3.FillWeight = 50f;
          viewTextBoxColumn3.ReadOnly = true;
          viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
          DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn4.HeaderText = "Supplier Name";
          viewTextBoxColumn4.DataPropertyName = "SupplierName";
          viewTextBoxColumn4.FillWeight = 60f;
          viewTextBoxColumn4.ReadOnly = true;
          viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
          viewTextBoxColumn4.Visible = true;
          this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
          this.dgvParts.Sort((DataGridViewColumn) viewTextBoxColumn4, ListSortDirection.Descending);
          this.Records = (DataView) App.DB.PartSupplier.PartSupplier_Search(this.txtFilter.Text, 0, false);
        }
      }
    }

    public int ForeignKeyFilter
    {
      get
      {
        return this._foreignKeyFilter;
      }
      set
      {
        this._foreignKeyFilter = value;
      }
    }

    public string PartNumber
    {
      get
      {
        return this._PartNumber;
      }
      set
      {
        this._PartNumber = value;
      }
    }

    public bool ForMassPartEntry
    {
      get
      {
        return this._ForMassPartEntry;
      }
      set
      {
        this._ForMassPartEntry = value;
      }
    }

    private DataView Records
    {
      get
      {
        return this._dvRecords;
      }
      set
      {
        this._dvRecords = value;
        this.dgvParts.DataSource = (object) this.Records;
      }
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    public int SecondID
    {
      get
      {
        return this._2ndID;
      }
      set
      {
        this._2ndID = value;
      }
    }

    public ArrayList PartsToAdd
    {
      get
      {
        return this._PartsToAdd;
      }
      set
      {
        this._PartsToAdd = value;
      }
    }

    public int PartID
    {
      get
      {
        return this._PartID;
      }
      set
      {
        this._PartID = value;
      }
    }

    public int PartSupplierID
    {
      get
      {
        return this._PartSupplierID;
      }
      set
      {
        this._PartSupplierID = value;
      }
    }

    private void DLGFindRecord_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    public void DBParts()
    {
      this.Records = (DataView) App.DB.PartSupplier.PartSupplier_Search(this.txtFilter.Text, 0, false);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.SelectItem();
    }

    private void SelectItem()
    {
      if (this.dgvParts.SelectedRows == null)
      {
        int num = (int) App.ShowMessage("No records selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        this.Datarows = !(this.TableToSearch == Enums.TableNames.tblPart | this.TableToSearch == Enums.TableNames.NOT_IN_Database_tblPartSupplierQty) ? ((DataView) this.dgvParts.DataSource).Table.Select("Tick = 1") : ((DataView) this.dgvParts.DataSource).Table.Select("Qty > 0");
        this.DialogResult = DialogResult.OK;
      }
    }

    private void RunFilter()
    {
      string str = "0 = 0";
      if ((uint) this.txtFilter.Text.Trim().Length > 0U)
      {
        switch (this.TableToSearch)
        {
          case Enums.TableNames.tblPart:
            str = str + " AND Name LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblProduct:
            str = str + " AND typemakemodel LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblSite:
            str = str + " AND (Name LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Address1 LIKE '%" + this.txtFilter.Text.Trim() + "%')";
            break;
          case Enums.TableNames.tblContact:
            str = str + " AND (Firstname LIKE '%" + this.txtFilter.Text.Trim() + "%') OR (Surname LIKE '%" + this.txtFilter.Text.Trim() + "%')";
            break;
          case Enums.TableNames.tblPartSupplier:
            str = str + " AND PartName LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PartCode LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PartNumber LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblOrder:
            str = str + " AND OrderReference LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          case Enums.TableNames.tblJob:
            str = str + " AND JobNumber LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
          default:
            str = str + " AND PartName LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PartCode LIKE '%" + this.txtFilter.Text.Trim() + "%' OR PartNumber LIKE '%" + this.txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%'";
            break;
        }
      }
      this.Records.RowFilter = str;
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (this.TableToSearch == Enums.TableNames.tblPart)
        this.Records = App.DB.Part.Part_Search(this.txtFilter.Text, "");
      else
        this.Records = (DataView) App.DB.PartSupplier.PartSupplier_Search(this.txtFilter.Text, 0, false);
    }

    public class ColourColumn : DataGridLabelColumn
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
        Brush brush = Brushes.White;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "Preferred"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))))
          brush = Brushes.LightGreen;
        this.TextBox.Text = "";
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
        g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }
  }
}
