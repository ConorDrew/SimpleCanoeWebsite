// Decompiled with JetBrains decompiler
// Type: FSM.DataGridComboBoxColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridComboBoxColumn : DataGridColumnStyle
  {
    private bool _getFrom;
    private int _theID;
    private string _type;
    private string _searchingFor;
    private int _returnID;
    private SqlTransaction trans;
    private int myPreviouslyEditedCellRow;

    private virtual ComboBox myComboBox
    {
      get
      {
        return this._myComboBox;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.myComboBox_SelectedIndexChanged);
        ComboBox comboBox1 = this._myComboBox;
        if (comboBox1 != null)
          comboBox1.SelectedIndexChanged -= eventHandler;
        this._myComboBox = value;
        ComboBox comboBox2 = this._myComboBox;
        if (comboBox2 == null)
          return;
        comboBox2.SelectedIndexChanged += eventHandler;
      }
    }

    public event DataGridComboBoxColumn.itemSelectedEventHandler itemSelected;

    public DataGridComboBoxColumn(bool isGetFrom = false)
    {
      this.WidthChanged += new EventHandler(this.NewComboBoxColumn_WidthChanged);
      this._getFrom = false;
      this._theID = 0;
      this._type = "";
      this._returnID = 0;
      this._getFrom = isGetFrom;
      this.myComboBox = new ComboBox();
      this.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.myComboBox.Cursor = Cursors.Hand;
      this.myComboBox.Visible = false;
    }

    public DataGridComboBoxColumn(SqlTransaction trans, bool isGetFrom = false)
    {
      this.WidthChanged += new EventHandler(this.NewComboBoxColumn_WidthChanged);
      this._getFrom = false;
      this._theID = 0;
      this._type = "";
      this._returnID = 0;
      this._getFrom = isGetFrom;
      this.myComboBox = new ComboBox();
      this.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.myComboBox.Cursor = Cursors.Hand;
      this.myComboBox.Visible = false;
      this.trans = trans;
    }

    private void myComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._getFrom)
      {
        switch (Conversions.ToInteger(this.myComboBox.SelectedValue))
        {
          case 1:
            this.SearchingFor = "Supplier";
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.Type, "Product", false) == 0)
            {
              int num = this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, this.trans, this.TheID, "");
              if (num == 0)
                break;
              FRMChooseSupplierPacks chooseSupplierPacks = (FRMChooseSupplierPacks) App.ShowForm(typeof (FRMChooseSupplierPacks), true, new object[4]
              {
                (object) num,
                (object) this.TheID,
                (object) 0,
                (object) this.trans
              }, false);
              if (chooseSupplierPacks.DialogResult == DialogResult.OK)
                this.ReturnID = chooseSupplierPacks.ProductSupplierID;
            }
            else
            {
              int num = this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, this.trans, this.TheID, "");
              if (num == 0)
                break;
              FRMChooseSupplierPacks chooseSupplierPacks = (FRMChooseSupplierPacks) App.ShowForm(typeof (FRMChooseSupplierPacks), true, new object[4]
              {
                (object) num,
                (object) 0,
                (object) this.TheID,
                (object) this.trans
              }, false);
              if (chooseSupplierPacks.DialogResult == DialogResult.OK)
                this.ReturnID = chooseSupplierPacks.PartSupplierID;
            }
            // ISSUE: reference to a compiler-generated field
            DataGridComboBoxColumn.itemSelectedEventHandler itemSelectedEvent1 = this.itemSelectedEvent;
            if (itemSelectedEvent1 != null)
            {
              itemSelectedEvent1();
              break;
            }
            break;
          case 2:
            this.SearchingFor = "Van";
            this.ReturnID = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.Type, "Product", false) != 0 ? (this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_VansForPart, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_VansForPart, this.trans, this.TheID, "")) : (this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_VansForProduct, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_VansForProduct, this.trans, this.TheID, ""));
            // ISSUE: reference to a compiler-generated field
            DataGridComboBoxColumn.itemSelectedEventHandler itemSelectedEvent2 = this.itemSelectedEvent;
            if (itemSelectedEvent2 != null)
            {
              itemSelectedEvent2();
              break;
            }
            break;
          case 3:
            this.SearchingFor = "Warehouse";
            this.ReturnID = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.Type, "Product", false) != 0 ? (this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, this.trans, this.TheID, "")) : (this.trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, this.TheID, "", false)) : App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, this.trans, this.TheID, ""));
            // ISSUE: reference to a compiler-generated field
            DataGridComboBoxColumn.itemSelectedEventHandler itemSelectedEvent3 = this.itemSelectedEvent;
            if (itemSelectedEvent3 != null)
            {
              itemSelectedEvent3();
              break;
            }
            break;
        }
      }
    }

    public int ReturnID
    {
      get
      {
        return this._returnID;
      }
      set
      {
        this._returnID = value;
      }
    }

    public int TheID
    {
      get
      {
        return this._theID;
      }
      set
      {
        this._theID = value;
      }
    }

    public string SearchingFor
    {
      get
      {
        return this._searchingFor;
      }
      set
      {
        this._searchingFor = value;
      }
    }

    public string Type
    {
      get
      {
        return this._type;
      }
      set
      {
        this._type = value;
      }
    }

    public ComboBox ComboBox
    {
      get
      {
        return this.myComboBox;
      }
    }

    private DataGrid parentGrid
    {
      get
      {
        return (DataGrid) this.Container;
      }
    }

    protected override void Abort(int rowNum)
    {
      this.myComboBox.Visible = false;
    }

    protected override bool Commit(CurrencyManager dataSource, int rowNum)
    {
      try
      {
        if (this.myPreviouslyEditedCellRow == rowNum)
          this.SetColumnValueAtRow(dataSource, rowNum, RuntimeHelpers.GetObjectValue(this.myComboBox.SelectedValue));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.myComboBox.Visible = false;
      return true;
    }

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly,
      string instantText,
      bool cellIsVisible)
    {
      Debug.WriteLine(string.Format("ComboBox Edit; current Height: {0}", (object) this.myComboBox.Height));
      object objectValue = RuntimeHelpers.GetObjectValue(this.GetColumnValueAtRow(source, rowNum));
      if (objectValue == null)
        this.myComboBox.SelectedItem = (object) null;
      else
        this.myComboBox.SelectedIndex = this.myComboBox.FindStringExact(Conversions.ToString(objectValue));
      this.myComboBox.BackColor = !this.IsOdd(rowNum) ? this.DataGridTableStyle.BackColor : this.DataGridTableStyle.AlternatingBackColor;
      this.myComboBox.Location = new System.Drawing.Point(bounds.X, bounds.Y);
      this.myComboBox.Visible = true;
      if (objectValue != null)
      {
        try
        {
          this.myComboBox.SelectionStart = 0;
          this.myComboBox.SelectionLength = objectValue.ToString().Length;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      Debug.WriteLine("SelectedItem: " + this.myComboBox.SelectedIndex.ToString());
      this.myPreviouslyEditedCellRow = rowNum;
    }

    private bool IsOdd(int number)
    {
      return (uint) (number % 2) > 0U;
    }

    protected override object GetColumnValueAtRow(CurrencyManager source, int rowNum)
    {
      return RuntimeHelpers.GetObjectValue(this.getItem(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(base.GetColumnValueAtRow(source, rowNum))), true));
    }

    private object getItem(object findByValue, bool findByValueMember)
    {
      string displayMember = this.myComboBox.DisplayMember;
      string valueMember = this.myComboBox.ValueMember;
      string name1;
      string name2;
      if (findByValueMember)
      {
        name1 = this.myComboBox.DisplayMember;
        name2 = this.myComboBox.ValueMember;
      }
      else
      {
        name1 = this.myComboBox.ValueMember;
        name2 = this.myComboBox.DisplayMember;
      }
      CurrencyManager currencyManager = (CurrencyManager) this.DataGridTableStyle.DataGrid.BindingContext[RuntimeHelpers.GetObjectValue(this.myComboBox.DataSource)];
      object obj;
      if (currencyManager.List is DataView)
      {
        DataView list = (DataView) currencyManager.List;
        int num = checked (list.Count - 1);
        int index = 0;
        while (index <= num && !findByValue.Equals(RuntimeHelpers.GetObjectValue(list[index][name2])))
          checked { ++index; }
        obj = index >= list.Count ? (object) null : list[index][name1];
      }
      else if (currencyManager.List is BindableCollection)
      {
        BindableCollection list = (BindableCollection) currencyManager.List;
        bool flag = false;
        IEnumerator enumerator;
        BindableItem current;
        try
        {
          enumerator = list.GetEnumerator();
          while (enumerator.MoveNext())
          {
            current = (BindableItem) enumerator.Current;
            if (findByValue.Equals(RuntimeHelpers.GetObjectValue(current.get_PropertyValue(name2))))
            {
              flag = true;
              break;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        obj = !flag ? (object) null : current.get_PropertyValue(name1);
      }
      return obj;
    }

    private void NewComboBoxColumn_WidthChanged(object sender, EventArgs e)
    {
      this.myComboBox.Width = this.Width;
      this.Invalidate();
    }

    protected override int GetMinimumHeight()
    {
      this.myComboBox.SelectedText = "something";
      return this.GetPreferredHeight((Graphics) null, (object) null);
    }

    protected override int GetPreferredHeight(Graphics g, object value)
    {
      return this.myComboBox.Height;
    }

    protected override Size GetPreferredSize(Graphics g, object value)
    {
      return new Size(this.myComboBox.Width, this.GetPreferredHeight(g, RuntimeHelpers.GetObjectValue(value)));
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum)
    {
      this.Paint(g, bounds, source, rowNum, false);
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      bool alignToRight)
    {
      base.Paint(g, bounds, source, rowNum, Brushes.White, Brushes.Black, false);
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      Brush backBrush,
      Brush foreBrush,
      bool alignToRight)
    {
      string s = Conversions.ToString(this.GetColumnValueAtRow(source, rowNum));
      if (source.Position != -1)
      {
        if (rowNum == source.Position)
          g.FillRectangle((Brush) new SolidBrush(Color.LightSteelBlue), bounds);
        else
          g.FillRectangle(backBrush, bounds);
      }
      RectangleF layoutRectangle = new RectangleF((float) checked (bounds.X + 1), (float) checked (bounds.Y + 2), (float) checked (bounds.Width - 3), (float) this.FontHeight);
      g.DrawString(s, this.myComboBox.Font, foreBrush, layoutRectangle);
    }

    protected override void SetDataGridInColumn(DataGrid value)
    {
      base.SetDataGridInColumn(value);
      if (value.Controls.Contains((Control) this.myComboBox))
        return;
      value.Controls.Add((Control) this.myComboBox);
    }

    public delegate void itemSelectedEventHandler();
  }
}
