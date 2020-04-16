// Decompiled with JetBrains decompiler
// Type: FSM.FRMFindCustomers
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
  public class FRMFindCustomers : FRMBaseForm
  {
    private IContainer components;
    private DataView _dvCustomers;

    public FRMFindCustomers()
    {
      this.Load += new EventHandler(this.FrmDisplayEngineers_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpCustomers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCustomers
    {
      get
      {
        return this._dgCustomers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.DgCustomers_Click);
        EventHandler eventHandler2 = new EventHandler(this.DgCustomers_Click);
        DataGrid dgCustomers1 = this._dgCustomers;
        if (dgCustomers1 != null)
        {
          dgCustomers1.Click -= eventHandler1;
          dgCustomers1.DoubleClick -= eventHandler2;
        }
        this._dgCustomers = value;
        DataGrid dgCustomers2 = this._dgCustomers;
        if (dgCustomers2 == null)
          return;
        dgCustomers2.Click += eventHandler1;
        dgCustomers2.DoubleClick += eventHandler2;
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
        EventHandler eventHandler = new EventHandler(this.BtnClearAll_Click);
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
        EventHandler eventHandler = new EventHandler(this.BtnSelectAll_Click);
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

    internal virtual Label lblCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFilter
    {
      get
      {
        return this._txtFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TxtFilter_TextChanged);
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

    internal virtual Button btnOk
    {
      get
      {
        return this._btnOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnOk_Click);
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
      this.grpCustomers = new GroupBox();
      this.txtFilter = new TextBox();
      this.lblCustomerName = new Label();
      this.btnOk = new Button();
      this.btnClearAll = new Button();
      this.btnSelectAll = new Button();
      this.dgCustomers = new DataGrid();
      this.grpCustomers.SuspendLayout();
      this.dgCustomers.BeginInit();
      this.SuspendLayout();
      this.grpCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomers.Controls.Add((Control) this.txtFilter);
      this.grpCustomers.Controls.Add((Control) this.lblCustomerName);
      this.grpCustomers.Controls.Add((Control) this.btnOk);
      this.grpCustomers.Controls.Add((Control) this.btnClearAll);
      this.grpCustomers.Controls.Add((Control) this.btnSelectAll);
      this.grpCustomers.Controls.Add((Control) this.dgCustomers);
      this.grpCustomers.Font = new Font("Verdana", 8f);
      this.grpCustomers.Location = new System.Drawing.Point(8, 32);
      this.grpCustomers.Name = "grpCustomers";
      this.grpCustomers.Size = new Size(661, 428);
      this.grpCustomers.TabIndex = 10;
      this.grpCustomers.TabStop = false;
      this.grpCustomers.Text = "Customer to Add";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(118, 31);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(219, 20);
      this.txtFilter.TabIndex = 49;
      this.lblCustomerName.Location = new System.Drawing.Point(7, 34);
      this.lblCustomerName.Name = "lblCustomerName";
      this.lblCustomerName.Size = new Size(105, 20);
      this.lblCustomerName.TabIndex = 48;
      this.lblCustomerName.Text = "Customer Name";
      this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOk.Font = new Font("Verdana", 8f);
      this.btnOk.Location = new System.Drawing.Point(588, 394);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(64, 23);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClearAll.Font = new Font("Verdana", 8f);
      this.btnClearAll.Location = new System.Drawing.Point(80, 394);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new Size(64, 23);
      this.btnClearAll.TabIndex = 3;
      this.btnClearAll.Text = "Clear All";
      this.btnClearAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.Font = new Font("Verdana", 8f);
      this.btnSelectAll.Location = new System.Drawing.Point(10, 394);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(64, 23);
      this.btnSelectAll.TabIndex = 2;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.dgCustomers.AllowNavigation = false;
      this.dgCustomers.AlternatingBackColor = Color.GhostWhite;
      this.dgCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCustomers.BackgroundColor = Color.White;
      this.dgCustomers.BorderStyle = BorderStyle.FixedSingle;
      this.dgCustomers.CaptionBackColor = Color.RoyalBlue;
      this.dgCustomers.CaptionForeColor = Color.White;
      this.dgCustomers.CaptionText = "Engineers";
      this.dgCustomers.CaptionVisible = false;
      this.dgCustomers.DataMember = "";
      this.dgCustomers.Font = new Font("Verdana", 8f);
      this.dgCustomers.ForeColor = Color.MidnightBlue;
      this.dgCustomers.GridLineColor = Color.RoyalBlue;
      this.dgCustomers.HeaderBackColor = Color.MidnightBlue;
      this.dgCustomers.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
      this.dgCustomers.HeaderForeColor = Color.Lavender;
      this.dgCustomers.LinkColor = Color.Teal;
      this.dgCustomers.Location = new System.Drawing.Point(10, 72);
      this.dgCustomers.Name = "dgCustomers";
      this.dgCustomers.ParentRowsBackColor = Color.Lavender;
      this.dgCustomers.ParentRowsForeColor = Color.MidnightBlue;
      this.dgCustomers.ParentRowsVisible = false;
      this.dgCustomers.RowHeadersVisible = false;
      this.dgCustomers.SelectionBackColor = Color.Teal;
      this.dgCustomers.SelectionForeColor = Color.PaleGreen;
      this.dgCustomers.Size = new Size(642, 313);
      this.dgCustomers.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(672, 461);
      this.Controls.Add((Control) this.grpCustomers);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(688, 500);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(688, 400);
      this.Name = nameof (FRMFindCustomers);
      this.Text = "Customers";
      this.Controls.SetChildIndex((Control) this.grpCustomers, 0);
      this.grpCustomers.ResumeLayout(false);
      this.grpCustomers.PerformLayout();
      this.dgCustomers.EndInit();
      this.ResumeLayout(false);
    }

    public DataView CustomerDataView
    {
      get
      {
        return this._dvCustomers;
      }
      set
      {
        this._dvCustomers = value;
        if (this.CustomerDataView != null && this.CustomerDataView.Table != null)
        {
          this._dvCustomers.Table.TableName = Conversions.ToString(12);
          this._dvCustomers.AllowNew = false;
        }
        this.dgCustomers.DataSource = (object) this.CustomerDataView;
      }
    }

    private void SetUpDataGrid()
    {
      this.SuspendLayout();
      Helper.SetUpDataGrid(this.dgCustomers, false);
      DataGridTableStyle tableStyle = this.dgCustomers.TableStyles[0];
      tableStyle.ReadOnly = false;
      this.dgCustomers.ReadOnly = false;
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
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 170;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Account Number";
      dataGridLabelColumn2.MappingName = "AccountNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Region";
      dataGridLabelColumn3.MappingName = "Region";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Type";
      dataGridLabelColumn4.MappingName = "Type";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 140;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Head Office";
      dataGridLabelColumn5.MappingName = "ho";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 250;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.MappingName = Conversions.ToString(12);
      this.dgCustomers.TableStyles.Add(tableStyle);
      this.ResumeLayout(true);
    }

    private void DgCustomers_Click(object sender, EventArgs e)
    {
      try
      {
        int index = 0;
        DataGrid.HitTestInfo hitTestInfo = this.dgCustomers.HitTest(this.dgCustomers.PointToClient(Control.MousePosition));
        BindingManagerBase bindingManagerBase = this.BindingContext[RuntimeHelpers.GetObjectValue(this.dgCustomers.DataSource), this.dgCustomers.DataMember];
        if (hitTestInfo.Row >= bindingManagerBase.Count || hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != index)
          return;
        bool flag = !Conversions.ToBoolean(this.dgCustomers[hitTestInfo.Row, index]);
        this.dgCustomers[hitTestInfo.Row, index] = (object) flag;
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

    private void BtnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.CustomerDataView == null)
        return;
      IEnumerator enumerator;
      if (this.CustomerDataView.Table != null)
      {
        try
        {
          enumerator = this.CustomerDataView.Table.Rows.GetEnumerator();
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

    private void BtnClearAll_Click(object sender, EventArgs e)
    {
      if (this.CustomerDataView == null)
        return;
      IEnumerator enumerator;
      if (this.CustomerDataView.Table != null)
      {
        try
        {
          enumerator = this.CustomerDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
            ((DataRow) enumerator.Current)["Include"] = (object) false;
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this.txtFilter.Text = string.Empty;
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FrmDisplayEngineers_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.SetUpDataGrid();
      this.Populate();
    }

    private void Populate()
    {
      this.CustomerDataView = App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID);
      if (this.CustomerDataView == null)
        return;
      DataTable table = this.CustomerDataView.Table;
      table.Columns.Add("Include", typeof (bool));
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Include"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.CustomerDataView = new DataView(table);
    }

    private void TxtFilter_TextChanged(object sender, EventArgs e)
    {
      if (this.CustomerDataView == null || this.CustomerDataView.Table == null)
        return;
      this.CustomerDataView.RowFilter = "Name LIKE '%" + this.txtFilter.Text + "%'";
    }
  }
}
