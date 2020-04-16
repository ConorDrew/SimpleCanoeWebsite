// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockCategoryValuation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class FRMStockCategoryValuation : FRMBaseForm, IForm
  {
    private IContainer components;
    private int selectedCateogryID;
    private string selectedCategoryName;
    private Enums.TableNames _Type;
    private DataView _dvParts;

    public FRMStockCategoryValuation()
    {
      this.Load += new EventHandler(this.FRMStockCategoryValuation_Load);
      this.selectedCateogryID = 0;
      this.selectedCategoryName = "";
      this._Type = Enums.TableNames.tblPickLists;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExport_Click);
        Button btnExport1 = this._btnExport;
        if (btnExport1 != null)
          btnExport1.Click -= eventHandler;
        this._btnExport = value;
        Button btnExport2 = this._btnExport;
        if (btnExport2 == null)
          return;
        btnExport2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgParts
    {
      get
      {
        return this._dgParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgParts_DoubleClick);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgParts_MouseUp);
        DataGrid dgParts1 = this._dgParts;
        if (dgParts1 != null)
        {
          dgParts1.DoubleClick -= eventHandler;
          dgParts1.MouseUp -= mouseEventHandler;
        }
        this._dgParts = value;
        DataGrid dgParts2 = this._dgParts;
        if (dgParts2 == null)
          return;
        dgParts2.DoubleClick += eventHandler;
        dgParts2.MouseUp += mouseEventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpParts = new GroupBox();
      this.dgParts = new DataGrid();
      this.btnExport = new Button();
      this.grpParts.SuspendLayout();
      this.dgParts.BeginInit();
      this.SuspendLayout();
      this.grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpParts.Controls.Add((Control) this.dgParts);
      this.grpParts.Location = new System.Drawing.Point(8, 38);
      this.grpParts.Name = "grpParts";
      this.grpParts.Size = new Size(510, 260);
      this.grpParts.TabIndex = 2;
      this.grpParts.TabStop = false;
      this.grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)";
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(8, 19);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(494, 233);
      this.dgParts.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 306);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 3;
      this.btnExport.Text = "Export";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(526, 336);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpParts);
      this.MinimumSize = new Size(534, 370);
      this.Name = nameof (FRMStockCategoryValuation);
      this.Text = "Stock Category Valuation Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpParts, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.grpParts.ResumeLayout(false);
      this.dgParts.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.Type = Enums.TableNames.tblPickLists;
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

    private Enums.TableNames Type
    {
      get
      {
        return this._Type;
      }
      set
      {
        try
        {
          this._Type = value;
          Cursor.Current = Cursors.WaitCursor;
          this.Enabled = false;
          switch (this.Type)
          {
            case Enums.TableNames.tblPickLists:
              this.PartsDataview = new DataView(App.DB.Part.Stock_Valuation(0, 0, 0, "", false).Tables[1]);
              this.grpParts.Text = "Category replacement costs based on supplier (Click to drill down to parts)";
              break;
            case Enums.TableNames.tblPart:
              this.PartsDataview = new DataView(App.DB.Part.Stock_Valuation(this.selectedCateogryID, 0, 0, "", false).Tables[2]);
              this.grpParts.Text = "Part replacement costs based on supplier for category : " + this.selectedCategoryName.Trim();
              break;
          }
          this.SetupDataGrid();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          throw ex;
        }
        finally
        {
          this.Enabled = true;
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private DataView PartsDataview
    {
      get
      {
        return this._dvParts;
      }
      set
      {
        this._dvParts = value;
        this._dvParts.AllowNew = false;
        this._dvParts.AllowEdit = false;
        this._dvParts.AllowDelete = false;
        this._dvParts.Table.TableName = this.Type.ToString();
        this.dgParts.DataSource = (object) this.PartsDataview;
      }
    }

    private DataRow SelectedPartDataRow
    {
      get
      {
        return this.dgParts.CurrentRowIndex != -1 ? this.PartsDataview[this.dgParts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgParts.AllowSorting = false;
      tableStyle.AllowSorting = false;
      if (this.Type == Enums.TableNames.tblPickLists)
      {
        DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
        dataGridLabelColumn1.Format = "";
        dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn1.HeaderText = "Category";
        dataGridLabelColumn1.MappingName = "Name";
        dataGridLabelColumn1.ReadOnly = true;
        dataGridLabelColumn1.Width = 200;
        dataGridLabelColumn1.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
        DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
        dataGridLabelColumn2.Format = "";
        dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn2.HeaderText = "Description";
        dataGridLabelColumn2.MappingName = "Description";
        dataGridLabelColumn2.ReadOnly = true;
        dataGridLabelColumn2.Width = 300;
        dataGridLabelColumn2.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
        DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
        dataGridLabelColumn3.Format = "C";
        dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn3.HeaderText = "Cost";
        dataGridLabelColumn3.MappingName = "ReplacementCost";
        dataGridLabelColumn3.ReadOnly = true;
        dataGridLabelColumn3.Width = 100;
        dataGridLabelColumn3.NullText = "£0.00";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
        DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
        dataGridLabelColumn4.Format = "C";
        dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn4.HeaderText = "Undistributed";
        dataGridLabelColumn4.MappingName = "Undistributed";
        dataGridLabelColumn4.ReadOnly = true;
        dataGridLabelColumn4.Width = 100;
        dataGridLabelColumn4.NullText = "£0.00";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
        DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
        dataGridLabelColumn5.Format = "";
        dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn5.HeaderText = "";
        dataGridLabelColumn5.MappingName = "ClickAction";
        dataGridLabelColumn5.ReadOnly = true;
        dataGridLabelColumn5.Width = 100;
        dataGridLabelColumn5.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
        tableStyle.MappingName = Enums.TableNames.tblPickLists.ToString();
      }
      else if (this.Type == Enums.TableNames.tblPart)
      {
        DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
        dataGridLabelColumn1.Format = "";
        dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn1.HeaderText = "Name";
        dataGridLabelColumn1.MappingName = "Name";
        dataGridLabelColumn1.ReadOnly = true;
        dataGridLabelColumn1.Width = 150;
        dataGridLabelColumn1.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
        DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
        dataGridLabelColumn2.Format = "";
        dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn2.HeaderText = "Number";
        dataGridLabelColumn2.MappingName = "Number";
        dataGridLabelColumn2.ReadOnly = true;
        dataGridLabelColumn2.Width = 75;
        dataGridLabelColumn2.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
        DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
        dataGridLabelColumn3.Format = "";
        dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn3.HeaderText = "Reference";
        dataGridLabelColumn3.MappingName = "Reference";
        dataGridLabelColumn3.ReadOnly = true;
        dataGridLabelColumn3.Width = 75;
        dataGridLabelColumn3.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
        DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
        dataGridLabelColumn4.Format = "C";
        dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn4.HeaderText = "Cost";
        dataGridLabelColumn4.MappingName = "ReplacementCost";
        dataGridLabelColumn4.ReadOnly = true;
        dataGridLabelColumn4.Width = 100;
        dataGridLabelColumn4.NullText = "£0.00";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
        DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
        dataGridLabelColumn5.Format = "C";
        dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn5.HeaderText = "Undistributed";
        dataGridLabelColumn5.MappingName = "Undistributed";
        dataGridLabelColumn5.ReadOnly = true;
        dataGridLabelColumn5.Width = 100;
        dataGridLabelColumn5.NullText = "£0.00";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
        DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
        dataGridLabelColumn6.Format = "";
        dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn6.HeaderText = "Supplier";
        dataGridLabelColumn6.MappingName = "Supplier";
        dataGridLabelColumn6.ReadOnly = true;
        dataGridLabelColumn6.Width = 250;
        dataGridLabelColumn6.NullText = "No Supplier";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
        DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
        dataGridLabelColumn7.Format = "";
        dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn7.HeaderText = "";
        dataGridLabelColumn7.MappingName = "ClickAction";
        dataGridLabelColumn7.ReadOnly = true;
        dataGridLabelColumn7.Width = 100;
        dataGridLabelColumn7.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
        tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      }
      tableStyle.ReadOnly = true;
      this.dgParts.TableStyles.Add(tableStyle);
    }

    private void FRMStockCategoryValuation_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgParts_DoubleClick(object sender, EventArgs e)
    {
      if (this.Type == Enums.TableNames.tblPart && this.SelectedPartDataRow != null)
      {
        App.ShowForm(typeof (FRMPart), true, new object[2]
        {
          this.SelectedPartDataRow["PartID"],
          (object) true
        }, false);
        this.Type = Enums.TableNames.tblPart;
      }
    }

    private void dgParts_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgParts.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgParts.CurrentRowIndex = hitTestInfo.Row;
        if (hitTestInfo.Column <= 0 || (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dgParts.TableStyles[0].GridColumnStyles[hitTestInfo.Column].MappingName.ToLower(), "clickaction", false) > 0U || this.SelectedPartDataRow == null)
          return;
        switch (this.Type)
        {
          case Enums.TableNames.tblPickLists:
            this.selectedCategoryName = Conversions.ToString(this.SelectedPartDataRow["Name"]);
            this.selectedCateogryID = Conversions.ToInteger(this.SelectedPartDataRow["CategoryID"]);
            this.Type = Enums.TableNames.tblPart;
            break;
          case Enums.TableNames.tblPart:
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedPartDataRow["ClickAction"], (object) "Back...", false))))
              break;
            this.Type = Enums.TableNames.tblPickLists;
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      string workSheetNameIn = "";
      switch (this.Type)
      {
        case Enums.TableNames.tblPickLists:
          datatableIn.Columns.Add("Category");
          datatableIn.Columns.Add("Description");
          datatableIn.Columns.Add("Cost");
          datatableIn.Columns.Add("Undistributed");
          int num1 = checked (((DataView) this.dgParts.DataSource).Count - 1);
          int row1 = 0;
          while (row1 <= num1)
          {
            this.dgParts.CurrentRowIndex = row1;
            DataRow row2 = datatableIn.NewRow();
            row2["Category"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Name"]);
            row2["Description"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Description"]);
            row2["Cost"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["ReplacementCost"]), "F");
            row2["Undistributed"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Undistributed"]), "F");
            datatableIn.Rows.Add(row2);
            this.dgParts.UnSelect(row1);
            checked { ++row1; }
          }
          workSheetNameIn = "Stock Category Value Report";
          break;
        case Enums.TableNames.tblPart:
          datatableIn.Columns.Add("Category");
          datatableIn.Columns.Add("Name");
          datatableIn.Columns.Add("Number");
          datatableIn.Columns.Add("Reference");
          datatableIn.Columns.Add("Cost");
          datatableIn.Columns.Add("Undistributed");
          datatableIn.Columns.Add("Supplier");
          int num2 = checked (((DataView) this.dgParts.DataSource).Count - 1);
          int row3 = 0;
          while (row3 <= num2)
          {
            this.dgParts.CurrentRowIndex = row3;
            DataRow row2 = datatableIn.NewRow();
            row2["Category"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Category"]);
            row2["Name"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Name"]);
            row2["Number"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Number"]);
            row2["Reference"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Reference"]);
            row2["Cost"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["ReplacementCost"]), "F");
            row2["Undistributed"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Undistributed"]), "F");
            row2["Supplier"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Supplier"]);
            datatableIn.Rows.Add(row2);
            this.dgParts.UnSelect(row3);
            checked { ++row3; }
          }
          workSheetNameIn = "Stock Value Report";
          break;
      }
      Exporting exporting = new Exporting(datatableIn, workSheetNameIn, "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
