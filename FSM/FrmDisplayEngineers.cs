// Decompiled with JetBrains decompiler
// Type: FSM.FrmDisplayEngineers
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FrmDisplayEngineers : FRMBaseForm
  {
    private IContainer components;
    private string engineersPostcodes;
    private List<string> engineersPostcodesList;
    private string engineersQualifications;
    private List<string> engineersQualificationsList;
    private DataView _dvEngineer;

    public FrmDisplayEngineers()
    {
      this.Load += new EventHandler(this.FrmDisplayEngineers_Load);
      this.InitializeComponent();
      ComboBox cboEngineerGroup = this.cboEngineerGroup;
      Combo.SetUpCombo(ref cboEngineerGroup, App.DB.Picklists.GetAll(Enums.PickListTypes.EngineerGroup, true).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineerGroup = cboEngineerGroup;
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetUpCombo(ref cboRegionId, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, true).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboRegionID = cboRegionId;
      if (App.IsGasway)
      {
        this.lblQualification.Text = "Qualifications";
      }
      else
      {
        if (!App.IsRFT)
          return;
        this.lblQualification.Text = "Trades";
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineers
    {
      get
      {
        return this._dgEngineers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgEngineers_Click);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgEngineers_MouseDoubleClick);
        DataGrid dgEngineers1 = this._dgEngineers;
        if (dgEngineers1 != null)
        {
          dgEngineers1.Click -= eventHandler;
          dgEngineers1.MouseDoubleClick -= mouseEventHandler;
        }
        this._dgEngineers = value;
        DataGrid dgEngineers2 = this._dgEngineers;
        if (dgEngineers2 == null)
          return;
        dgEngineers2.Click += eventHandler;
        dgEngineers2.MouseDoubleClick += mouseEventHandler;
      }
    }

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

    internal virtual ComboBox cboEngineerGroup
    {
      get
      {
        return this._cboEngineerGroup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboEngineerGroup_SelectedIndexChanged);
        ComboBox cboEngineerGroup1 = this._cboEngineerGroup;
        if (cboEngineerGroup1 != null)
          cboEngineerGroup1.SelectedIndexChanged -= eventHandler;
        this._cboEngineerGroup = value;
        ComboBox cboEngineerGroup2 = this._cboEngineerGroup;
        if (cboEngineerGroup2 == null)
          return;
        cboEngineerGroup2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNameFilter
    {
      get
      {
        return this._txtNameFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.filterChange);
        TextBox txtNameFilter1 = this._txtNameFilter;
        if (txtNameFilter1 != null)
          txtNameFilter1.TextChanged -= eventHandler;
        this._txtNameFilter = value;
        TextBox txtNameFilter2 = this._txtNameFilter;
        if (txtNameFilter2 == null)
          return;
        txtNameFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboRegionID
    {
      get
      {
        return this._cboRegionID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.filterChange);
        ComboBox cboRegionId1 = this._cboRegionID;
        if (cboRegionId1 != null)
          cboRegionId1.SelectedIndexChanged -= eventHandler;
        this._cboRegionID = value;
        ComboBox cboRegionId2 = this._cboRegionID;
        if (cboRegionId2 == null)
          return;
        cboRegionId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcodeFilter
    {
      get
      {
        return this._txtPostcodeFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.filterChange);
        TextBox txtPostcodeFilter1 = this._txtPostcodeFilter;
        if (txtPostcodeFilter1 != null)
          txtPostcodeFilter1.TextChanged -= eventHandler;
        this._txtPostcodeFilter = value;
        TextBox txtPostcodeFilter2 = this._txtPostcodeFilter;
        if (txtPostcodeFilter2 == null)
          return;
        txtPostcodeFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClearFilters
    {
      get
      {
        return this._btnClearFilters;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearFilters_Click);
        Button btnClearFilters1 = this._btnClearFilters;
        if (btnClearFilters1 != null)
          btnClearFilters1.Click -= eventHandler;
        this._btnClearFilters = value;
        Button btnClearFilters2 = this._btnClearFilters;
        if (btnClearFilters2 == null)
          return;
        btnClearFilters2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtQualificationFilter
    {
      get
      {
        return this._txtQualificationFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.filterChange);
        TextBox qualificationFilter1 = this._txtQualificationFilter;
        if (qualificationFilter1 != null)
          qualificationFilter1.TextChanged -= eventHandler;
        this._txtQualificationFilter = value;
        TextBox qualificationFilter2 = this._txtQualificationFilter;
        if (qualificationFilter2 == null)
          return;
        qualificationFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOk
    {
      get
      {
        return this._btnOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOk_Click);
        Button btnOk1 = this._btnOk;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOk = value;
        Button btnOk2 = this._btnOk;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpMain = new GroupBox();
      this.txtQualificationFilter = new TextBox();
      this.lblQualification = new Label();
      this.btnClearFilters = new Button();
      this.cboRegionID = new ComboBox();
      this.lblRegion = new Label();
      this.txtPostcodeFilter = new TextBox();
      this.lblPostcode = new Label();
      this.txtNameFilter = new TextBox();
      this.lblEngineerName = new Label();
      this.cboEngineerGroup = new ComboBox();
      this.Label24 = new Label();
      this.btnOk = new Button();
      this.btnClearAll = new Button();
      this.btnSelectAll = new Button();
      this.dgEngineers = new DataGrid();
      this.grpMain.SuspendLayout();
      this.dgEngineers.BeginInit();
      this.SuspendLayout();
      this.grpMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpMain.Controls.Add((Control) this.txtQualificationFilter);
      this.grpMain.Controls.Add((Control) this.lblQualification);
      this.grpMain.Controls.Add((Control) this.btnClearFilters);
      this.grpMain.Controls.Add((Control) this.cboRegionID);
      this.grpMain.Controls.Add((Control) this.lblRegion);
      this.grpMain.Controls.Add((Control) this.txtPostcodeFilter);
      this.grpMain.Controls.Add((Control) this.lblPostcode);
      this.grpMain.Controls.Add((Control) this.txtNameFilter);
      this.grpMain.Controls.Add((Control) this.lblEngineerName);
      this.grpMain.Controls.Add((Control) this.cboEngineerGroup);
      this.grpMain.Controls.Add((Control) this.Label24);
      this.grpMain.Controls.Add((Control) this.btnOk);
      this.grpMain.Controls.Add((Control) this.btnClearAll);
      this.grpMain.Controls.Add((Control) this.btnSelectAll);
      this.grpMain.Controls.Add((Control) this.dgEngineers);
      this.grpMain.Font = new Font("Verdana", 8f);
      this.grpMain.Location = new System.Drawing.Point(8, 32);
      this.grpMain.Name = "grpMain";
      this.grpMain.Size = new Size(661, 529);
      this.grpMain.TabIndex = 10;
      this.grpMain.TabStop = false;
      this.grpMain.Text = "Engineers to Display";
      this.txtQualificationFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQualificationFilter.Location = new System.Drawing.Point(121, 93);
      this.txtQualificationFilter.Name = "txtQualificationFilter";
      this.txtQualificationFilter.Size = new Size(426, 20);
      this.txtQualificationFilter.TabIndex = 5;
      this.lblQualification.Location = new System.Drawing.Point(9, 93);
      this.lblQualification.Name = "lblQualification";
      this.lblQualification.Size = new Size(93, 20);
      this.lblQualification.TabIndex = 57;
      this.lblQualification.Text = "Qualification";
      this.btnClearFilters.Location = new System.Drawing.Point(553, 93);
      this.btnClearFilters.Name = "btnClearFilters";
      this.btnClearFilters.Size = new Size(99, 23);
      this.btnClearFilters.TabIndex = 6;
      this.btnClearFilters.Text = "Clear Filters";
      this.btnClearFilters.UseVisualStyleBackColor = true;
      this.cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRegionID.Cursor = Cursors.Hand;
      this.cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegionID.Location = new System.Drawing.Point(121, 62);
      this.cboRegionID.Name = "cboRegionID";
      this.cboRegionID.Size = new Size(188, 21);
      this.cboRegionID.TabIndex = 3;
      this.cboRegionID.Tag = (object) "";
      this.lblRegion.Location = new System.Drawing.Point(9, 64);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(105, 20);
      this.lblRegion.TabIndex = 54;
      this.lblRegion.Text = "Region";
      this.txtPostcodeFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcodeFilter.Location = new System.Drawing.Point(433, 62);
      this.txtPostcodeFilter.Name = "txtPostcodeFilter";
      this.txtPostcodeFilter.Size = new Size(219, 20);
      this.txtPostcodeFilter.TabIndex = 4;
      this.lblPostcode.Location = new System.Drawing.Point(327, 62);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(93, 20);
      this.lblPostcode.TabIndex = 52;
      this.lblPostcode.Text = "Postcode";
      this.txtNameFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNameFilter.Location = new System.Drawing.Point(433, 34);
      this.txtNameFilter.Name = "txtNameFilter";
      this.txtNameFilter.Size = new Size(219, 20);
      this.txtNameFilter.TabIndex = 2;
      this.lblEngineerName.Location = new System.Drawing.Point(327, 34);
      this.lblEngineerName.Name = "lblEngineerName";
      this.lblEngineerName.Size = new Size(105, 20);
      this.lblEngineerName.TabIndex = 48;
      this.lblEngineerName.Text = "Engineer Name";
      this.cboEngineerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerGroup.Cursor = Cursors.Hand;
      this.cboEngineerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerGroup.Location = new System.Drawing.Point(121, 32);
      this.cboEngineerGroup.Name = "cboEngineerGroup";
      this.cboEngineerGroup.Size = new Size(188, 21);
      this.cboEngineerGroup.TabIndex = 1;
      this.cboEngineerGroup.Tag = (object) "";
      this.Label24.Location = new System.Drawing.Point(9, 34);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(105, 20);
      this.Label24.TabIndex = 47;
      this.Label24.Text = "Engineer Group";
      this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOk.Font = new Font("Verdana", 8f);
      this.btnOk.Location = new System.Drawing.Point(588, 495);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(64, 23);
      this.btnOk.TabIndex = 9;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClearAll.Font = new Font("Verdana", 8f);
      this.btnClearAll.Location = new System.Drawing.Point(80, 495);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new Size(64, 23);
      this.btnClearAll.TabIndex = 8;
      this.btnClearAll.Text = "Clear All";
      this.btnClearAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.Font = new Font("Verdana", 8f);
      this.btnSelectAll.Location = new System.Drawing.Point(10, 495);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(64, 23);
      this.btnSelectAll.TabIndex = 7;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.dgEngineers.DataMember = "";
      this.dgEngineers.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineers.Location = new System.Drawing.Point(10, 128);
      this.dgEngineers.Name = "dgEngineers";
      this.dgEngineers.Size = new Size(645, 353);
      this.dgEngineers.TabIndex = 50;
      this.dgEngineers.TabStop = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(672, 562);
      this.Controls.Add((Control) this.grpMain);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(688, 601);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(688, 601);
      this.Name = nameof (FrmDisplayEngineers);
      this.Text = "Display Engineers";
      this.Controls.SetChildIndex((Control) this.grpMain, 0);
      this.grpMain.ResumeLayout(false);
      this.grpMain.PerformLayout();
      this.dgEngineers.EndInit();
      this.ResumeLayout(false);
    }

    public DataView EngineersDataView
    {
      get
      {
        return this._dvEngineer;
      }
      set
      {
        this._dvEngineer = value;
        if (this.EngineersDataView != null)
        {
          this._dvEngineer.AllowNew = false;
          this._dvEngineer.AllowEdit = true;
          this._dvEngineer.AllowDelete = false;
          this._dvEngineer.Table.TableName = "tblEngineers";
        }
        this.dgEngineers.DataSource = (object) this.EngineersDataView;
      }
    }

    private DataRow SelectedEngineerDataRow
    {
      get
      {
        return this.EngineersDataView == null || this.dgEngineers.CurrentRowIndex == -1 ? (DataRow) null : this.EngineersDataView[this.dgEngineers.CurrentRowIndex].Row;
      }
    }

    private void SetUpDataGrid()
    {
      this.SuspendLayout();
      DataGridTableStyle tableStyle = this.dgEngineers.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Include";
      dataGridBoolColumn.MappingName = "Include";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.AllowNull = false;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Engineer ID";
      dataGridLabelColumn1.MappingName = "EngineerID";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Engineer Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Department";
      dataGridLabelColumn3.MappingName = "Department";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Region";
      dataGridLabelColumn4.MappingName = "Region";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 200;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "tblEngineers";
      this.dgEngineers.TableStyles.Add(tableStyle);
    }

    private void dgEngineers_Click(object sender, EventArgs e)
    {
      if (this.SelectedEngineerDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a engineer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.SelectedEngineerDataRow["Include"] = (object) !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedEngineerDataRow["Include"], (object) true, false);
    }

    private void dgEngineers_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (((DataGrid) sender).HitTest(e.X, e.Y).Type == DataGrid.HitTestType.ColumnHeader || this.SelectedEngineerDataRow == null)
        return;
      DataTable dtEngineer = this.SelectedEngineerDataRow.Table.Clone();
      dtEngineer.Rows.Add(this.SelectedEngineerDataRow.ItemArray);
      using (FRMViewEngineer frmViewEngineer = new FRMViewEngineer(dtEngineer))
      {
        int num = (int) frmViewEngineer.ShowDialog();
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      this.SelectAllTicks();
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
      this.ClearTicks();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FrmDisplayEngineers_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.SetUpDataGrid();
      this.txtNameFilter.Select();
      this.Populate();
    }

    private void cboEngineerGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (App.IsRFT)
        {
          this.Filter();
        }
        else
        {
          this.ClearTicks();
          int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboEngineerGroup));
          if (integer > 0 && this.EngineersDataView != null && this.EngineersDataView.Table != null)
          {
            this.Filter();
            IEnumerator enumerator;
            try
            {
              enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (Conversions.ToInteger(current["EngineerGroupID"]) == integer)
                  current["Include"] = (object) true;
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void filterChange(object sender, EventArgs e)
    {
      if (this.EngineersDataView == null || this.EngineersDataView.Table == null)
        return;
      this.Filter();
    }

    private void btnClearFilters_Click(object sender, EventArgs e)
    {
      this.Reset_filters();
      this.ClearTicks();
    }

    private void Reset_filters()
    {
      this.txtPostcodeFilter.Text = "";
      this.txtNameFilter.Text = "";
      this.txtQualificationFilter.Text = "";
      ComboBox cboEngineerGroup = this.cboEngineerGroup;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineerGroup, Conversions.ToString(0));
      this.cboEngineerGroup = cboEngineerGroup;
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetSelectedComboItem_By_Value(ref cboRegionId, Conversions.ToString(0));
      this.cboRegionID = cboRegionId;
    }

    private void ClearTicks()
    {
      if (this.EngineersDataView == null)
        return;
      IEnumerator enumerator;
      if (this.EngineersDataView.Table != null)
      {
        try
        {
          enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
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

    private void SelectAllTicks()
    {
      if (this.EngineersDataView == null)
        return;
      IEnumerator enumerator;
      if (this.EngineersDataView.Table != null)
      {
        try
        {
          enumerator = this.EngineersDataView.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRowView current = (DataRowView) enumerator.Current;
            current.BeginEdit();
            current["Include"] = (object) true;
            current.EndEdit();
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    private void Populate()
    {
      EnumerableRowCollection<DataRow> source1 = this.EngineersDataView.Table.AsEnumerable();
      Func<DataRow, object> selector1;
      // ISSUE: reference to a compiler-generated field
      if (FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector1 = FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D0 = selector1 = (Func<DataRow, object>) (x => x["PostCodes"]);
      }
      this.engineersPostcodes = string.Join(",", source1.Select<DataRow, object>(selector1).ToArray<object>());
      string[] strArray1 = this.engineersPostcodes.ToLower().Split(',');
      Func<string, string> selector2;
      // ISSUE: reference to a compiler-generated field
      if (FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector2 = FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D1 = selector2 = (Func<string, string>) (x => x.Trim());
      }
      this.engineersPostcodesList = ((IEnumerable<string>) strArray1).Select<string, string>(selector2).Distinct<string>().ToList<string>();
      EnumerableRowCollection<DataRow> source2 = this.EngineersDataView.Table.AsEnumerable();
      Func<DataRow, object> selector3;
      // ISSUE: reference to a compiler-generated field
      if (FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector3 = FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D2;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D2 = selector3 = (Func<DataRow, object>) (x => x["Qualifications"]);
      }
      this.engineersQualifications = string.Join(",", source2.Select<DataRow, object>(selector3).ToArray<object>());
      string[] strArray2 = this.engineersQualifications.ToLower().Split(',');
      Func<string, string> selector4;
      // ISSUE: reference to a compiler-generated field
      if (FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D3 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector4 = FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D3;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FrmDisplayEngineers._Closure\u0024__.\u0024I91\u002D3 = selector4 = (Func<string, string>) (x => x.Trim());
      }
      this.engineersQualificationsList = ((IEnumerable<string>) strArray2).Select<string, string>(selector4).Distinct<string>().ToList<string>();
    }

    private void Filter()
    {
      string str1 = string.Empty;
      int num1 = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboRegionID));
      if (num1 > 0)
        str1 = " AND RegionID = " + Conversions.ToString(num1);
      string str2 = string.Empty;
      List<int> intList1 = new List<int>();
      if (!Helper.IsStringEmpty((object) this.txtPostcodeFilter.Text))
      {
        string[] strArray1 = this.txtPostcodeFilter.Text.ToLower().Split(',');
        Func<string, string> selector1;
        // ISSUE: reference to a compiler-generated field
        if (FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector1 = FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D0 = selector1 = (Func<string, string>) (x => x.Trim());
        }
        List<string> list1 = ((IEnumerable<string>) strArray1).Select<string, string>(selector1).ToList<string>();
        int num2 = 0;
        try
        {
          foreach (string str3 in list1)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            FrmDisplayEngineers._Closure\u0024__92\u002D0 closure920 = new FrmDisplayEngineers._Closure\u0024__92\u002D0(closure920);
            // ISSUE: reference to a compiler-generated field
            closure920.\u0024VB\u0024Local_postcode = str3;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated field
            if (this.engineersPostcodesList.Where<string>(new Func<string, bool>(closure920._Lambda\u0024__1)).Any<string>() && !Helper.IsStringEmpty((object) closure920.\u0024VB\u0024Local_postcode))
              checked { ++num2; }
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.EngineersDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            string[] strArray2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PostCodes"])).ToLower().Split(',');
            Func<string, string> selector2;
            // ISSUE: reference to a compiler-generated field
            if (FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector2 = FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D2;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D2 = selector2 = (Func<string, string>) (x => x.Trim());
            }
            List<string> list2 = ((IEnumerable<string>) strArray2).Select<string, string>(selector2).Distinct<string>().ToList<string>();
            int num3 = 0;
            try
            {
              foreach (string str3 in list1)
              {
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                FrmDisplayEngineers._Closure\u0024__92\u002D1 closure921 = new FrmDisplayEngineers._Closure\u0024__92\u002D1(closure921);
                // ISSUE: reference to a compiler-generated field
                closure921.\u0024VB\u0024Local_postcode = str3;
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated field
                if (list2.Where<string>(new Func<string, bool>(closure921._Lambda\u0024__3)).Any<string>() && !Helper.IsStringEmpty((object) closure921.\u0024VB\u0024Local_postcode))
                  checked { ++num3; }
              }
            }
            finally
            {
              List<string>.Enumerator enumerator2;
              enumerator2.Dispose();
            }
            if (num3 > 0 && num3 == num2)
              intList1.Add(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EngineerID"])));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (intList1.Count > 0)
          str2 = " AND EngineerID IN (" + string.Join<int>(",", (IEnumerable<int>) intList1.ToArray()) + ")";
      }
      string str4 = string.Empty;
      List<int> intList2 = new List<int>();
      if (!Helper.IsStringEmpty((object) this.txtQualificationFilter.Text))
      {
        string[] strArray1 = this.txtQualificationFilter.Text.ToLower().Split(',');
        Func<string, string> selector1;
        // ISSUE: reference to a compiler-generated field
        if (FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D4 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector1 = FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D4;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D4 = selector1 = (Func<string, string>) (x => x.Trim());
        }
        List<string> list1 = ((IEnumerable<string>) strArray1).Select<string, string>(selector1).ToList<string>();
        int num2 = 0;
        try
        {
          foreach (string str3 in list1)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            FrmDisplayEngineers._Closure\u0024__92\u002D2 closure922 = new FrmDisplayEngineers._Closure\u0024__92\u002D2(closure922);
            // ISSUE: reference to a compiler-generated field
            closure922.\u0024VB\u0024Local_Qualifications = str3;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated field
            if (this.engineersQualificationsList.Where<string>(new Func<string, bool>(closure922._Lambda\u0024__5)).Any<string>() && !Helper.IsStringEmpty((object) closure922.\u0024VB\u0024Local_Qualifications))
              checked { ++num2; }
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.EngineersDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            string[] strArray2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Qualifications"])).ToLower().Split(',');
            Func<string, string> selector2;
            // ISSUE: reference to a compiler-generated field
            if (FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D6 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector2 = FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D6;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              FrmDisplayEngineers._Closure\u0024__.\u0024I92\u002D6 = selector2 = (Func<string, string>) (x => x.Trim());
            }
            List<string> list2 = ((IEnumerable<string>) strArray2).Select<string, string>(selector2).Distinct<string>().ToList<string>();
            int num3 = 0;
            try
            {
              foreach (string str3 in list1)
              {
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                FrmDisplayEngineers._Closure\u0024__92\u002D3 closure923 = new FrmDisplayEngineers._Closure\u0024__92\u002D3(closure923);
                // ISSUE: reference to a compiler-generated field
                closure923.\u0024VB\u0024Local_Qual = str3;
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated field
                if (list2.Where<string>(new Func<string, bool>(closure923._Lambda\u0024__7)).Any<string>() && !Helper.IsStringEmpty((object) closure923.\u0024VB\u0024Local_Qual))
                  checked { ++num3; }
              }
            }
            finally
            {
              List<string>.Enumerator enumerator2;
              enumerator2.Dispose();
            }
            if (num3 > 0 && num3 == num2)
              intList2.Add(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EngineerID"])));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (intList2.Count > 0)
          str4 = " AND EngineerID IN (" + string.Join<int>(",", (IEnumerable<int>) intList2.ToArray()) + ")";
      }
      string str5 = string.Empty;
      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboEngineerGroup));
      if (App.IsRFT | App.IsBlueflame && integer > 0)
        str5 = " AND EngineerGroupID = " + Combo.get_GetSelectedItemValue(this.cboEngineerGroup);
      this.EngineersDataView.RowFilter = "Name LIKE '%" + Helper.RemoveSpecialCharacters(this.txtNameFilter.Text) + "%'" + str1 + str2 + str4 + str5;
      this.grpMain.Text = "Engineers to Display (" + Conversions.ToString(this.EngineersDataView.Count) + ")";
    }
  }
}
