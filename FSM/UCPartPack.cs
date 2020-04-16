// Decompiled with JetBrains decompiler
// Type: FSM.UCPartPack
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
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCPartPack : UCBase, IUserControl
  {
    private IContainer components;
    public int PackID;
    private string PartPackName;
    private DataView _PartPackDataView;
    private DataView _dvPackSuppliers;

    public UCPartPack()
    {
      this.Load += new EventHandler(this.UCPart_Load);
      this.PackID = 0;
      this._PartPackDataView = (DataView) null;
      this._dvPackSuppliers = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual DataGridView dgvPartPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgPackSuppliers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPackSuppliers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tabDetails = new TabPage();
      this.grpPart = new GroupBox();
      this.lblPackSuppliers = new Label();
      this.dgPackSuppliers = new DataGridView();
      this.btnRemove = new Button();
      this.btnAdd = new Button();
      this.dgvPartPack = new DataGridView();
      this.Label2 = new Label();
      this.txtName = new TextBox();
      this.TabControl1 = new TabControl();
      this.tabDetails.SuspendLayout();
      this.grpPart.SuspendLayout();
      ((ISupportInitialize) this.dgPackSuppliers).BeginInit();
      ((ISupportInitialize) this.dgvPartPack).BeginInit();
      this.TabControl1.SuspendLayout();
      this.SuspendLayout();
      this.tabDetails.Controls.Add((Control) this.grpPart);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(624, 612);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPart.Controls.Add((Control) this.lblPackSuppliers);
      this.grpPart.Controls.Add((Control) this.dgPackSuppliers);
      this.grpPart.Controls.Add((Control) this.btnRemove);
      this.grpPart.Controls.Add((Control) this.btnAdd);
      this.grpPart.Controls.Add((Control) this.dgvPartPack);
      this.grpPart.Controls.Add((Control) this.Label2);
      this.grpPart.Controls.Add((Control) this.txtName);
      this.grpPart.Location = new System.Drawing.Point(8, 8);
      this.grpPart.Name = "grpPart";
      this.grpPart.Size = new Size(609, 595);
      this.grpPart.TabIndex = 0;
      this.grpPart.TabStop = false;
      this.grpPart.Text = "Main Details";
      this.lblPackSuppliers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPackSuppliers.Location = new System.Drawing.Point(8, 400);
      this.lblPackSuppliers.Name = "lblPackSuppliers";
      this.lblPackSuppliers.Size = new Size(117, 21);
      this.lblPackSuppliers.TabIndex = 63;
      this.lblPackSuppliers.Text = "Pack Suppliers";
      this.dgPackSuppliers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgPackSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgPackSuppliers.Location = new System.Drawing.Point(11, 424);
      this.dgPackSuppliers.Name = "dgPackSuppliers";
      this.dgPackSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgPackSuppliers.Size = new Size(585, 160);
      this.dgPackSuppliers.TabIndex = 62;
      this.btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemove.Location = new System.Drawing.Point(11, 358);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(75, 23);
      this.btnRemove.TabIndex = 61;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(521, 358);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(75, 23);
      this.btnAdd.TabIndex = 60;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.dgvPartPack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgvPartPack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPartPack.Location = new System.Drawing.Point(11, 64);
      this.dgvPartPack.Name = "dgvPartPack";
      this.dgvPartPack.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvPartPack.Size = new Size(585, 279);
      this.dgvPartPack.TabIndex = 59;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(57, 21);
      this.Label2.TabIndex = 33;
      this.Label2.Text = "Name";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(160, 26);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(436, 21);
      this.txtName.TabIndex = 0;
      this.txtName.Tag = (object) "Part.Name";
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tabDetails);
      this.TabControl1.Location = new System.Drawing.Point(1, 5);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(632, 638);
      this.TabControl1.TabIndex = 0;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCPartPack);
      this.Size = new Size(640, 648);
      this.tabDetails.ResumeLayout(false);
      this.grpPart.ResumeLayout(false);
      this.grpPart.PerformLayout();
      ((ISupportInitialize) this.dgPackSuppliers).EndInit();
      ((ISupportInitialize) this.dgvPartPack).EndInit();
      this.TabControl1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupPartPackDatagrid();
      this.SetupPackSuppliersDatagrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.PackID;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    private DataRow DrSelectedPartPack
    {
      get
      {
        return this.dgvPartPack.CurrentCell.RowIndex != -1 ? this.PartPackDataview[this.dgvPartPack.CurrentCell.RowIndex].Row : (DataRow) null;
      }
    }

    public DataView PartPackDataview
    {
      get
      {
        return this._PartPackDataView;
      }
      set
      {
        this._PartPackDataView = value;
        this._PartPackDataView.Table.TableName = Enums.TableNames.tblPartLocations.ToString();
        this._PartPackDataView.AllowNew = false;
        this._PartPackDataView.AllowEdit = true;
        this._PartPackDataView.AllowDelete = false;
        this.dgvPartPack.DataSource = (object) this.PartPackDataview;
      }
    }

    public DataView DvPackSuppliers
    {
      get
      {
        return this._dvPackSuppliers;
      }
      set
      {
        this._dvPackSuppliers = value;
        this._dvPackSuppliers.Table.TableName = Enums.TableNames.tblPartLocations.ToString();
        this._dvPackSuppliers.AllowNew = false;
        this._dvPackSuppliers.AllowEdit = true;
        this._dvPackSuppliers.AllowDelete = false;
        this.dgPackSuppliers.DataSource = (object) this.DvPackSuppliers;
      }
    }

    private void SetupPartPackDatagrid()
    {
      Helper.SetUpDataGridView(this.dgvPartPack, false);
      this.dgvPartPack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPartPack.AutoGenerateColumns = false;
      this.dgvPartPack.Columns.Clear();
      this.dgvPartPack.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 70f;
      viewTextBoxColumn1.HeaderText = "Part Name";
      viewTextBoxColumn1.DataPropertyName = "PartName";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgvPartPack.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Part Number";
      viewTextBoxColumn2.DataPropertyName = "PartNumber";
      viewTextBoxColumn2.FillWeight = 70f;
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgvPartPack.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Qty";
      viewTextBoxColumn3.DataPropertyName = "Qty";
      viewTextBoxColumn3.FillWeight = 70f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgvPartPack.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      this.dgvPartPack.Sort((DataGridViewColumn) viewTextBoxColumn1, ListSortDirection.Descending);
    }

    private void SetupPackSuppliersDatagrid()
    {
      Helper.SetUpDataGridView(this.dgPackSuppliers, false);
      this.dgPackSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgPackSuppliers.AutoGenerateColumns = false;
      this.dgPackSuppliers.Columns.Clear();
      this.dgPackSuppliers.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Supplier";
      viewTextBoxColumn1.DataPropertyName = "SupplierName";
      viewTextBoxColumn1.FillWeight = 100f;
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgPackSuppliers.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 70f;
      viewTextBoxColumn2.HeaderText = "Qty Of Parts In Pack";
      viewTextBoxColumn2.DataPropertyName = "QuantityOfPartsInPack";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgPackSuppliers.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Cost";
      viewTextBoxColumn3.DataPropertyName = "Price";
      viewTextBoxColumn3.FillWeight = 70f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgPackSuppliers.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      this.dgPackSuppliers.Sort((DataGridViewColumn) viewTextBoxColumn2, ListSortDirection.Descending);
    }

    private void UCPart_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void Populate(int ID = 0)
    {
      this.PackID = ID;
      this.PartPackName = Conversions.ToString(App.DB.ExecuteScalar("Select PackName From tblPartPack where PackID  = " + Conversions.ToString(this.PackID), true, false));
      this.txtName.Text = this.PartPackName;
      this.PartPackDataview = App.DB.Part.PartPack_Get(this.PackID);
      this.DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(this.PackID);
    }

    public bool Save()
    {
      bool flag1;
      try
      {
        if (this.txtName.Text.Length == 0)
        {
          int num1 = (int) App.ShowMessage("Enter a Pack Name!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          bool flag2 = true;
          bool flag3 = false;
          DataView all = App.DB.Part.PartPack_GetAll();
          if (all.Count > 0 && this.PackID == 0)
          {
            IEnumerable<DataRow> source = all.Table.Rows.OfType<DataRow>();
            Func<DataRow, string> selector;
            // ISSUE: reference to a compiler-generated field
            if (UCPartPack._Closure\u0024__.\u0024I71\u002D0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector = UCPartPack._Closure\u0024__.\u0024I71\u002D0;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              UCPartPack._Closure\u0024__.\u0024I71\u002D0 = selector = (Func<DataRow, string>) (dr => dr.Field<string>("PackName"));
            }
            flag2 = !source.Select<DataRow, string>(selector).ToList<string>().Contains(this.txtName.Text.Trim());
          }
          if (!flag2)
          {
            int num2 = (int) App.ShowMessage("A pack with this name already exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag1 = false;
          }
          else
          {
            if (!(App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.EditParts) | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreateParts)))
              throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
            if (this.PartPackDataview != null && this.PartPackDataview.Count > 0)
            {
              if (this.PackID == 0)
              {
                this.PackID = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(App.DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack", true, false), (object) 1));
                flag3 = true;
              }
              this.PartPackName = this.txtName.Text;
              App.DB.ExecuteScalar("Delete from tblPartPAck WHERE PackID = " + Conversions.ToString(this.PackID), true, false);
              IEnumerator enumerator;
              try
              {
                enumerator = this.PartPackDataview.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("INSERT INTO tblPartPack (PackName,PackID,Qty,PartID) VALUES ('" + this.txtName.Text + "'," + Conversions.ToString(this.PackID) + ","), current["qty"]), (object) ","), current["PartID"]), (object) ")")), true, false);
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              int num2 = (int) App.ShowMessage("Save successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              // ISSUE: reference to a compiler-generated field
              IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
              if (recordsChangedEvent != null)
                recordsChangedEvent(App.DB.Part.PartPack_GetAll(), Enums.PageViewing.PartPack, true, false, "");
              // ISSUE: reference to a compiler-generated field
              IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
              if (stateChangedEvent != null)
                stateChangedEvent(this.PackID);
              App.MainForm.RefreshEntity(this.PackID, "PackID");
            }
            flag1 = true;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag1;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      FRMFindPart frmFindPart = (FRMFindPart) App.checkIfExists(typeof (FRMFindPart).Name, true) ?? (FRMFindPart) Activator.CreateInstance(typeof (FRMFindPart));
      frmFindPart.TableToSearch = Enums.TableNames.tblPart;
      frmFindPart.ShowInTaskbar = false;
      int num = (int) frmFindPart.ShowDialog();
      if (frmFindPart.DialogResult != DialogResult.OK)
        return;
      DataRow[] datarows = frmFindPart.Datarows;
      if (!this.Save())
        return;
      if (this.PackID == 0)
      {
        this.PartPackName = this.txtName.Text;
        this.PackID = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(App.DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack", true, false), (object) 1));
      }
      DataRow[] dataRowArray = datarows;
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("INSERT INTO tblPartPack (PackName,PackID,PartID,Qty) VALUES ('" + this.PartPackName + "'," + Conversions.ToString(this.PackID) + ","), dataRow["PartID"]), (object) ","), dataRow["Qty"]), (object) " )")), true, false);
        checked { ++index; }
      }
      this.PartPackDataview = App.DB.Part.PartPack_Get(this.PackID);
      this.DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(this.PackID);
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.DrSelectedPartPack == null)
        return;
      int integer = Conversions.ToInteger(this.DrSelectedPartPack["PartPackID"]);
      if (integer > 0)
      {
        App.DB.ExecuteScalar("Delete From tblpartPack where PartPackID = " + Conversions.ToString(integer), true, false);
        this.PartPackDataview = App.DB.Part.PartPack_Get(this.PackID);
        this.DvPackSuppliers = App.DB.Part.PartPack_Get_Suppliers(this.PackID);
      }
    }
  }
}
