// Decompiled with JetBrains decompiler
// Type: FSM.FRMSelectLocation
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
  public class FRMSelectLocation : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _Locations;
    private int _LocationID;
    private int _PartSupplierID;
    private int _SupplierID;
    private int _InPack;
    private double _Price;

    public FRMSelectLocation()
    {
      this.Load += new EventHandler(this.FRMSelectLocation_Load);
      this._Locations = (DataView) null;
      this._LocationID = 0;
      this._PartSupplierID = 0;
      this._SupplierID = 0;
      this._InPack = 0;
      this._Price = 0.0;
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
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
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

    internal virtual DataGrid dgLocations
    {
      get
      {
        return this._dgLocations;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgLocations_MouseUp);
        DataGrid dgLocations1 = this._dgLocations;
        if (dgLocations1 != null)
          dgLocations1.MouseUp -= mouseEventHandler;
        this._dgLocations = value;
        DataGrid dgLocations2 = this._dgLocations;
        if (dgLocations2 == null)
          return;
        dgLocations2.MouseUp += mouseEventHandler;
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
      this.dgLocations = new DataGrid();
      this.grpLocations.SuspendLayout();
      this.dgLocations.BeginInit();
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
      this.grpLocations.Controls.Add((Control) this.dgLocations);
      this.grpLocations.Location = new System.Drawing.Point(12, 38);
      this.grpLocations.Name = "grpLocations";
      this.grpLocations.Size = new Size(904, 400);
      this.grpLocations.TabIndex = 3;
      this.grpLocations.TabStop = false;
      this.grpLocations.Text = "Select location to replenish from : {0}";
      this.dgLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgLocations.DataMember = "";
      this.dgLocations.HeaderForeColor = SystemColors.ControlText;
      this.dgLocations.Location = new System.Drawing.Point(9, 20);
      this.dgLocations.Name = "dgLocations";
      this.dgLocations.Size = new Size(889, 374);
      this.dgLocations.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(928, 481);
      this.ControlBox = false;
      this.Controls.Add((Control) this.grpLocations);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.MinimumSize = new Size(825, 420);
      this.Name = nameof (FRMSelectLocation);
      this.Text = "Replenish from...";
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grpLocations, 0);
      this.grpLocations.ResumeLayout(false);
      this.dgLocations.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDG();
      DataView dataView = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.get_GetParameter(8), (object) "DailyStockReplen", false) ? App.DB.Part.Part_Locations_Get_For_Replenishment(Conversions.ToInteger(this.get_GetParameter(0))) : App.DB.Part.Part_Locations_Get_For_Replenishment_Suppliers_Only(Conversions.ToInteger(this.get_GetParameter(0)));
      IEnumerator enumerator1;
      try
      {
        enumerator1 = ((ArrayList) this.get_GetParameter(4)).GetEnumerator();
        while (enumerator1.MoveNext())
        {
          ArrayList current1 = (ArrayList) enumerator1.Current;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((DataTable) current1[1]).Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current2 = (DataRow) enumerator2.Current;
              IEnumerator enumerator3;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2["PartID"], this.get_GetParameter(0), false))
              {
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current2["LocationID"], (object) 0, false))))
                {
                  try
                  {
                    enumerator3 = dataView.Table.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current3 = (DataRow) enumerator3.Current;
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.get_GetParameter(8), (object) "", false))
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["Type"], (object) "Warehouse", false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["ID"], current2["LocationID"], false))
                          current3["InStock"] = (object) checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current3["InStock"])) - Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current2["Quantity"])));
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["Type"], (object) "Warehouse", false))
                        current3.Delete();
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                }
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator4;
      try
      {
        enumerator4 = ((ArrayList) this.get_GetParameter(5)).GetEnumerator();
        while (enumerator4.MoveNext())
        {
          ArrayList current1 = (ArrayList) enumerator4.Current;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((DataTable) current1[1]).Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current2 = (DataRow) enumerator2.Current;
              IEnumerator enumerator3;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2["PartID"], this.get_GetParameter(0), false))
              {
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current2["LocationID"], (object) 0, false))))
                {
                  try
                  {
                    enumerator3 = dataView.Table.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current3 = (DataRow) enumerator3.Current;
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.get_GetParameter(8), (object) "", false))
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["Type"], (object) "Warehouse", false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["ID"], current2["LocationID"], false))
                          current3["InStock"] = (object) checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current3["InStock"])) - Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current2["Quantity"])));
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["Type"], (object) "Warehouse", false))
                        current3.Delete();
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                }
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      IEnumerator enumerator5;
      if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(7))) > 0U)
      {
        try
        {
          enumerator5 = dataView.Table.Rows.GetEnumerator();
          while (enumerator5.MoveNext())
          {
            DataRow current = (DataRow) enumerator5.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Type"], (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(6))), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["ID"], (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(7))), false))))
            {
              current["Tick"] = (object) true;
              break;
            }
          }
        }
        finally
        {
          if (enumerator5 is IDisposable)
            (enumerator5 as IDisposable).Dispose();
        }
      }
      this.Locations = dataView;
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

    private void SetupDG()
    {
      Helper.SetUpDataGrid(this.dgLocations, false);
      DataGridTableStyle tableStyle = this.dgLocations.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      this.dgLocations.ReadOnly = false;
      tableStyle.AllowSorting = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Stock";
      dataGridLabelColumn3.MappingName = "InStock";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "In Pack";
      dataGridLabelColumn4.MappingName = "InPack";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Deleted";
      dataGridLabelColumn6.MappingName = "Deleted";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.MappingName = Enums.TableNames.tblLocations.ToString();
      this.dgLocations.TableStyles.Add(tableStyle);
    }

    public DataView Locations
    {
      get
      {
        return this._Locations;
      }
      set
      {
        this._Locations = value;
        this._Locations.Table.TableName = Enums.TableNames.tblLocations.ToString();
        this._Locations.AllowNew = false;
        this._Locations.AllowEdit = true;
        this._Locations.AllowDelete = false;
        this.dgLocations.DataSource = (object) this.Locations;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgLocations.CurrentRowIndex != -1 ? this.Locations[this.dgLocations.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public int LocationID
    {
      get
      {
        return this._LocationID;
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

    private void FRMSelectLocation_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgLocations_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        try
        {
          DataGrid.HitTestInfo hitTestInfo = this.dgLocations.HitTest(e.X, e.Y);
          if (this.Locations.Table.Rows[hitTestInfo.Row] == null)
            return;
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.Locations.Table.Columns[hitTestInfo.Column].ColumnName.Trim().ToLower(), "Tick".ToLower(), false) > 0U)
            return;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
          return;
        }
        if (this.SelectedDataRow == null)
          return;
        this.dgLocations[this.dgLocations.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgLocations[this.dgLocations.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (this.Locations.Table.Select("Tick=1").Length != 1)
      {
        int num = (int) App.ShowMessage("Please ensure only one location has been selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataRow dataRow = this.Locations.Table.Select("Tick=1")[0];
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Warehouse", false))
        {
          this._LocationID = Conversions.ToInteger(dataRow["ID"]);
          this._PartSupplierID = 0;
          this._SupplierID = 0;
        }
        else
        {
          this._LocationID = 0;
          this._PartSupplierID = Conversions.ToInteger(dataRow["ID"]);
          this._SupplierID = Conversions.ToInteger(dataRow["OtherID"]);
        }
        this._InPack = Conversions.ToInteger(dataRow["InPack"]);
        this._Price = Conversions.ToDouble(dataRow["Price"]);
        this.DialogResult = DialogResult.OK;
      }
    }
  }
}
