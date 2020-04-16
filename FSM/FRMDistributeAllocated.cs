// Decompiled with JetBrains decompiler
// Type: FSM.FRMDistributeAllocated
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
  public class FRMDistributeAllocated : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool _Used;
    private string _PartProductName;
    private string _Type;
    private int _ID;
    private int _Quantity;
    private ArrayList _Allocated;
    private DataView _Locations;

    public FRMDistributeAllocated(
      bool UsedIn,
      int QuantityIn,
      string PartProductNameIn,
      string TypeIn,
      int IDIn,
      ArrayList AllocatedIn)
    {
      this.Load += new EventHandler(this.FRMDistributeAllocated_Load);
      this._Allocated = (ArrayList) null;
      this._Locations = (DataView) null;
      this.InitializeComponent();
      this.Used = UsedIn;
      this.Quantity = QuantityIn;
      this.PartProductName = PartProductNameIn;
      this.Type = TypeIn;
      this.ID = IDIn;
      this.Allocated = AllocatedIn;
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

    internal virtual GroupBox grpOptions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgLocations { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.grpOptions = new GroupBox();
      this.lblDetails = new Label();
      this.dgLocations = new DataGrid();
      this.grpOptions.SuspendLayout();
      this.dgLocations.BeginInit();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(480, 512);
      this.btnOK.Name = "btnOK";
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 512);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.grpOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpOptions.Controls.Add((Control) this.dgLocations);
      this.grpOptions.Location = new System.Drawing.Point(8, 64);
      this.grpOptions.Name = "grpOptions";
      this.grpOptions.Size = new Size(544, 440);
      this.grpOptions.TabIndex = 7;
      this.grpOptions.TabStop = false;
      this.grpOptions.Text = "Enter amount to distribute to each location";
      this.lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblDetails.Location = new System.Drawing.Point(8, 40);
      this.lblDetails.Name = "lblDetails";
      this.lblDetails.Size = new Size(544, 23);
      this.lblDetails.TabIndex = 8;
      this.lblDetails.Text = "PARTPRODUCTDETAILS";
      this.dgLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgLocations.DataMember = "";
      this.dgLocations.HeaderForeColor = SystemColors.ControlText;
      this.dgLocations.Location = new System.Drawing.Point(8, 24);
      this.dgLocations.Name = "dgLocations";
      this.dgLocations.Size = new Size(528, 408);
      this.dgLocations.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(560, 542);
      this.ControlBox = false;
      this.Controls.Add((Control) this.lblDetails);
      this.Controls.Add((Control) this.grpOptions);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.MinimumSize = new Size(568, 576);
      this.Name = nameof (FRMDistributeAllocated);
      this.Text = "Part / Product Manager";
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grpOptions, 0);
      this.Controls.SetChildIndex((Control) this.lblDetails, 0);
      this.grpOptions.ResumeLayout(false);
      this.dgLocations.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDG();
      this.Locations = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution2(this.ID);
      if (!this.Used)
      {
        this.lblDetails.Text = "You must declare where these " + Conversions.ToString(this.Quantity) + " " + this.PartProductName + "'s have been returned to:";
        this.grpOptions.Text = "Enter quantity to distribute to each location";
      }
      else
      {
        this.lblDetails.Text = "You must declare where you got these " + Conversions.ToString(this.Quantity) + " " + this.PartProductName + "'s from:";
        this.grpOptions.Text = "Enter quantity for each location";
      }
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

    public bool Used
    {
      get
      {
        return this._Used;
      }
      set
      {
        this._Used = value;
      }
    }

    public string PartProductName
    {
      get
      {
        return this._PartProductName;
      }
      set
      {
        this._PartProductName = value;
      }
    }

    public string Type
    {
      get
      {
        return this._Type;
      }
      set
      {
        this._Type = value;
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

    public int Quantity
    {
      get
      {
        return this._Quantity;
      }
      set
      {
        this._Quantity = value;
      }
    }

    public ArrayList Allocated
    {
      get
      {
        return this._Allocated;
      }
      set
      {
        this._Allocated = value;
      }
    }

    public DataView Locations
    {
      get
      {
        return this._Locations;
      }
      set
      {
        if (this.Used)
        {
          value.Table.AcceptChanges();
          value.Table.Columns.Add(new DataColumn("StockTransactionType", System.Type.GetType("System.Int32")));
          value.Table.Columns.Add(new DataColumn("OrderPartProductID", System.Type.GetType("System.Int32")));
          IEnumerator enumerator1;
          try
          {
            enumerator1 = value.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              current["StockTransactionType"] = (object) 3;
              current["OrderPartProductID"] = (object) 0;
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.Allocated.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              ArrayList current = (ArrayList) enumerator2.Current;
              DataRow row = value.Table.NewRow();
              row["Location"] = (object) "**ORDER**";
              row["Name"] = (object) "**ORDER**";
              row["AdditionalDetails"] = (object) "**AN ORDER ALLOCATION**";
              row["ID"] = (object) 0;
              row["AllocatedID"] = RuntimeHelpers.GetObjectValue(current[0]);
              row["LocationID"] = (object) 0;
              row["Quantity"] = (object) 0;
              row["Available"] = RuntimeHelpers.GetObjectValue(current[1]);
              row["StockTransactionType"] = (object) 0;
              row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(current[2]);
              value.Table.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          DataRow row1 = value.Table.NewRow();
          row1["Location"] = (object) "**OTHER**";
          row1["Name"] = (object) "**OTHER**";
          row1["AdditionalDetails"] = (object) "**OTHER**";
          row1["ID"] = (object) 0;
          row1["AllocatedID"] = (object) 0;
          row1["LocationID"] = (object) 0;
          row1["Quantity"] = (object) 0;
          row1["Available"] = (object) "N/A";
          row1["StockTransactionType"] = (object) 0;
          row1["OrderPartProductID"] = (object) 0;
          value.Table.Rows.Add(row1);
        }
        this._Locations = value;
        this._Locations.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
        this._Locations.AllowNew = false;
        this._Locations.AllowEdit = true;
        this._Locations.AllowDelete = false;
        this.dgLocations.DataSource = (object) this.Locations;
      }
    }

    private DataRow SelectedLocationDataRow
    {
      get
      {
        return this.dgLocations.CurrentRowIndex != -1 ? this.Locations[this.dgLocations.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDG()
    {
      DataGridTableStyle tableStyle = this.dgLocations.TableStyles[0];
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgLocations.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Location";
      dataGridLabelColumn1.MappingName = "Location";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridTextBoxColumn gridTextBoxColumn1 = new DataGridTextBoxColumn();
      gridTextBoxColumn1.Format = "";
      gridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      gridTextBoxColumn1.HeaderText = "Qty";
      gridTextBoxColumn1.MappingName = "Quantity";
      gridTextBoxColumn1.ReadOnly = false;
      gridTextBoxColumn1.Width = 50;
      gridTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn1);
      if (this.Used)
      {
        DataGridTextBoxColumn gridTextBoxColumn2 = new DataGridTextBoxColumn();
        gridTextBoxColumn2.Format = "";
        gridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
        gridTextBoxColumn2.HeaderText = "Available";
        gridTextBoxColumn2.MappingName = "Available";
        gridTextBoxColumn2.ReadOnly = false;
        gridTextBoxColumn2.Width = 50;
        gridTextBoxColumn2.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn2);
      }
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Additional Details";
      dataGridLabelColumn3.MappingName = "AdditionalDetails";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 300;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
      this.dgLocations.TableStyles.Add(tableStyle);
    }

    private void FRMDistributeAllocated_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      int num1 = 0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.Locations.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Quantity"], (object) 0, false))
            num1 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, current["Quantity"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (num1 == this.Quantity)
      {
        if (!this.Used)
        {
          this.DialogResult = DialogResult.OK;
        }
        else
        {
          ArrayList arrayList = new ArrayList();
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.Locations.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Quantity"], (object) 0, false))
              {
                object Left = current["Available"];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "Unknown", false))
                  arrayList.Add(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Stock check could not take place for ", current["Location"]), (object) " - "), current["Name"]));
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "N/A", false))
                  arrayList.Add((object) "Stock has been marked as being collected from an unknown location");
                else if (Conversions.ToInteger(current["Quantity"]) > Conversions.ToInteger(current["Available"]))
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Location"], (object) "**ORDER**", false))
                  {
                    int num2 = (int) App.ShowMessage("Using a quantity higher than what is allocated for an item is not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                  }
                  arrayList.Add(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "More stock than is currently known as available is being collected from ", current["Location"]), (object) " - "), current["Name"]), (object) ". This will cause negative stock amounts"));
                }
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          if (arrayList.Count == 0)
          {
            this.DialogResult = DialogResult.OK;
          }
          else
          {
            string str1 = "Please note the following:\r\n\r\n";
            IEnumerator enumerator3;
            try
            {
              enumerator3 = arrayList.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                string str2 = Conversions.ToString(enumerator3.Current);
                str1 = str1 + str2 + "\r\n";
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            if (App.ShowMessage(str1 + "\r\nDo you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              this.DialogResult = DialogResult.OK;
          }
        }
      }
      else
      {
        int num3 = (int) App.ShowMessage("A total of " + Conversions.ToString(this.Quantity) + " need to be distributed. So far " + Conversions.ToString(num1) + " have been", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
