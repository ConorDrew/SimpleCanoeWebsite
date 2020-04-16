// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartSelectLocation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class FRMPartSelectLocation : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataTable m_dTable5;
    private int _LocationID;
    private int _PartSupplierID;
    private int _SupplierID;
    private int _InPack;
    private double _Price;
    private bool _Loading;

    public FRMPartSelectLocation()
    {
      this.Load += new EventHandler(this.FRMSelectLocation_Load);
      this.m_dTable5 = (DataTable) null;
      this._LocationID = 0;
      this._PartSupplierID = 0;
      this._SupplierID = 0;
      this._InPack = 0;
      this._Price = 0.0;
      this._Loading = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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

    internal virtual GroupBox grpLocations { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvLocations
    {
      get
      {
        return this._dgvLocations;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgvLocations_SelectionChanged);
        DataGridView dgvLocations1 = this._dgvLocations;
        if (dgvLocations1 != null)
          dgvLocations1.SelectionChanged -= eventHandler;
        this._dgvLocations = value;
        DataGridView dgvLocations2 = this._dgvLocations;
        if (dgvLocations2 == null)
          return;
        dgvLocations2.SelectionChanged += eventHandler;
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
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.grpLocations = new GroupBox();
      this.dgvLocations = new DataGridView();
      this.grpLocations.SuspendLayout();
      ((ISupportInitialize) this.dgvLocations).BeginInit();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(856, 444);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(60, 25);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(12, 444);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 25);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.grpLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpLocations.Controls.Add((Control) this.dgvLocations);
      this.grpLocations.Location = new System.Drawing.Point(12, 38);
      this.grpLocations.Name = "grpLocations";
      this.grpLocations.Size = new Size(904, 400);
      this.grpLocations.TabIndex = 3;
      this.grpLocations.TabStop = false;
      this.grpLocations.Text = "Select location to add to : {0}";
      this.dgvLocations.AllowUserToAddRows = false;
      this.dgvLocations.AllowUserToDeleteRows = false;
      this.dgvLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLocations.Location = new System.Drawing.Point(7, 21);
      this.dgvLocations.Name = "dgvLocations";
      this.dgvLocations.ReadOnly = true;
      this.dgvLocations.Size = new Size(891, 373);
      this.dgvLocations.TabIndex = 0;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(928, 481);
      this.ControlBox = false;
      this.Controls.Add((Control) this.grpLocations);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.MinimumSize = new Size(825, 420);
      this.Name = nameof (FRMPartSelectLocation);
      this.Text = "Add Van Stock Part to ...";
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grpLocations, 0);
      this.grpLocations.ResumeLayout(false);
      ((ISupportInitialize) this.dgvLocations).EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupLocationsDataGridView();
      this.grpLocations.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Please select where you would like to get ", this.get_GetParameter(3)), (object) " of item '"), this.get_GetParameter(1)), (object) "' for location '"), this.get_GetParameter(2)), (object) "' from"));
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public void SetupLocationsDataGridView()
    {
      Helper.SetUpDataGridView(this.dgvLocations, false);
      this.dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvLocations.AutoGenerateColumns = false;
      this.dgvLocations.Columns.Clear();
      this.dgvLocations.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "LocationID";
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "LocationID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvLocations.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 60f;
      viewTextBoxColumn2.HeaderText = "Registration";
      viewTextBoxColumn2.DataPropertyName = "Registration";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvLocations.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
    }

    public DataTable LocationsDataGridView
    {
      get
      {
        return this.m_dTable5;
      }
      set
      {
        this.m_dTable5 = value;
        this.dgvLocations.DataSource = (object) value;
      }
    }

    private DataGridViewRow SelecteddgvLocationsDataRow
    {
      get
      {
        return this.dgvLocations.CurrentRow.Index != -1 ? this.dgvLocations.CurrentRow : (DataGridViewRow) null;
      }
    }

    public int LocationID
    {
      get
      {
        return this._LocationID;
      }
      set
      {
        this._LocationID = value;
      }
    }

    public int PartSupplierID
    {
      get
      {
        return this._PartSupplierID;
      }
    }

    public int SupplierID
    {
      get
      {
        return this._SupplierID;
      }
    }

    public int InPack
    {
      get
      {
        return this._InPack;
      }
    }

    public double Price
    {
      get
      {
        return this._Price;
      }
    }

    public bool Loading
    {
      get
      {
        return this._Loading;
      }
      set
      {
        this._Loading = value;
      }
    }

    private void FRMSelectLocation_Load(object sender, EventArgs e)
    {
      this.Loading = true;
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.Loading = false;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void dgvLocations_SelectionChanged(object sender, EventArgs e)
    {
      if (!this.Loading && this.SelecteddgvLocationsDataRow != null)
        this.LocationID = Conversions.ToInteger(this.SelecteddgvLocationsDataRow.Cells[0].Value);
    }
  }
}
