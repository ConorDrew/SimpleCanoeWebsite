// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartCategories
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
  public class FRMPartCategories : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvManager;

    public FRMPartCategories()
    {
      this.Load += new EventHandler(this.FRMPartCategories_Load);
      this.InitializeComponent();
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCategory = cboCategory;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgManager
    {
      get
      {
        return this._dgManager;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgManager_Click);
        DataGrid dgManager1 = this._dgManager;
        if (dgManager1 != null)
          dgManager1.Click -= eventHandler;
        this._dgManager = value;
        DataGrid dgManager2 = this._dgManager;
        if (dgManager2 == null)
          return;
        dgManager2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddNew
    {
      get
      {
        return this._btnAddNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNew_Click);
        Button btnAddNew1 = this._btnAddNew;
        if (btnAddNew1 != null)
          btnAddNew1.Click -= eventHandler;
        this._btnAddNew = value;
        Button btnAddNew2 = this._btnAddNew;
        if (btnAddNew2 == null)
          return;
        btnAddNew2.Click += eventHandler;
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

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnAddNew = new Button();
      this.btnDelete = new Button();
      this.dgManager = new DataGrid();
      this.grpDetails = new GroupBox();
      this.cboCategory = new ComboBox();
      this.Label1 = new Label();
      this.txtName = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgManager.BeginInit();
      this.grpDetails.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.btnAddNew);
      this.GroupBox1.Controls.Add((Control) this.btnDelete);
      this.GroupBox1.Controls.Add((Control) this.dgManager);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(780, 344);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Part Categories Mapping";
      this.btnAddNew.AccessibleDescription = "Add new item";
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnAddNew.Location = new System.Drawing.Point(8, 16);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(48, 24);
      this.btnAddNew.TabIndex = 5;
      this.btnAddNew.Text = "New";
      this.btnDelete.AccessibleDescription = "Delete item";
      this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Location = new System.Drawing.Point(724, 18);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(48, 24);
      this.btnDelete.TabIndex = 6;
      this.btnDelete.Text = "Delete";
      this.dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgManager.DataMember = "";
      this.dgManager.HeaderForeColor = SystemColors.ControlText;
      this.dgManager.Location = new System.Drawing.Point(8, 49);
      this.dgManager.Name = "dgManager";
      this.dgManager.Size = new Size(764, 287);
      this.dgManager.TabIndex = 0;
      this.grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.cboCategory);
      this.grpDetails.Controls.Add((Control) this.Label1);
      this.grpDetails.Controls.Add((Control) this.txtName);
      this.grpDetails.Controls.Add((Control) this.Label2);
      this.grpDetails.Controls.Add((Control) this.btnSave);
      this.grpDetails.Location = new System.Drawing.Point(8, 384);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(780, 56);
      this.grpDetails.TabIndex = 8;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.cboCategory.Location = new System.Drawing.Point(409, 21);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(306, 21);
      this.cboCategory.TabIndex = 9;
      this.Label1.Location = new System.Drawing.Point(357, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(80, 23);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "Map To";
      this.txtName.Location = new System.Drawing.Point(79, 21);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(265, 21);
      this.txtName.TabIndex = 5;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(80, 23);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Map From";
      this.btnSave.AccessibleDescription = "Save item";
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.ImageIndex = 1;
      this.btnSave.Location = new System.Drawing.Point(721, 19);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 7;
      this.btnSave.Text = "Save";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(796, 454);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.grpDetails);
      this.MinimumSize = new Size(496, 488);
      this.Name = nameof (FRMPartCategories);
      this.Text = "Part Categories";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpDetails, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgManager.EndInit();
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupManagerDataGrid();
      this.PopulateDatagrid(Enums.FormState.Insert);
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

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private DataView ManagerDataview
    {
      get
      {
        return this._dvManager;
      }
      set
      {
        this._dvManager = value;
        this._dvManager.AllowNew = false;
        this._dvManager.AllowEdit = false;
        this._dvManager.AllowDelete = false;
        this._dvManager.Table.TableName = Enums.TableNames.tblPartCategoryMapping.ToString();
        this.dgManager.DataSource = (object) this.ManagerDataview;
      }
    }

    private DataRow SelectedManagerDataRow
    {
      get
      {
        return this.dgManager.CurrentRowIndex != -1 ? this.ManagerDataview[this.dgManager.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupManagerDataGrid()
    {
      Helper.SetUpDataGrid(this.dgManager, false);
      DataGridTableStyle tableStyle = this.dgManager.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.HeaderText = "ID";
      dataGridLabelColumn1.MappingName = "PartMapID";
      dataGridLabelColumn1.ReadOnly = true;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Map To";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 177;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Map From";
      dataGridLabelColumn3.MappingName = "PartMapMatch";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 177;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPartCategoryMapping.ToString();
      this.dgManager.TableStyles.Add(tableStyle);
    }

    private void SetUpPageState(Enums.FormState state)
    {
      Helper.ClearGroupBox(this.grpDetails);
      switch (state)
      {
        case Enums.FormState.Load:
          this.grpDetails.Enabled = false;
          this.btnAddNew.Enabled = false;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.grpDetails.Enabled = true;
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = true;
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.grpDetails.Enabled = true;
          this.btnSave.Enabled = true;
          this.btnDelete.Enabled = true;
          break;
      }
      this.PageState = state;
    }

    private void FRMPartCategories_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgManager_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedManagerDataRow != null)
        {
          this.txtName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["PartMapMatch"]));
          ComboBox cboCategory = this.cboCategory;
          Combo.SetSelectedComboItem_By_Value(ref cboCategory, Conversions.ToString(this.SelectedManagerDataRow["ManagerID"]));
          this.cboCategory = cboCategory;
        }
        else
          this.SetUpPageState(Enums.FormState.Insert);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Item data cannot load : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.SetUpPageState(Enums.FormState.Insert);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.Delete();
    }

    private void PopulateDatagrid(Enums.FormState state)
    {
      this.ManagerDataview = App.DB.Picklists.GetAllPartMappings(Enums.PickListTypes.PartCategories);
      this.SetUpPageState(state);
    }

    private void Save()
    {
      try
      {
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.Picklists.InsertPartCategory(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCategory)), this.txtName.Text);
            break;
          case Enums.FormState.Update:
            App.DB.Picklists.UpdatePartMapping(Conversions.ToInteger(this.SelectedManagerDataRow["PartMapID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCategory)), this.txtName.Text);
            break;
        }
        this.PopulateDatagrid(Enums.FormState.Insert);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Delete()
    {
      try
      {
        if (this.SelectedManagerDataRow != null)
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to delete \"", this.SelectedManagerDataRow["Name"]), (object) "\" from "), (object) " Part Categories "), (object) "?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          App.DB.Picklists.DeletePartMapping(Conversions.ToInteger(this.SelectedManagerDataRow["PartMapID"]));
          this.PopulateDatagrid(Enums.FormState.Insert);
        }
        else
        {
          int num = (int) App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error deleting : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
