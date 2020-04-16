// Decompiled with JetBrains decompiler
// Type: FSM.FRMTypeMakeModel
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Management;
using FSM.Entity.PickLists;
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
  public class FRMTypeMakeModel : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvManager;
    private Settings _settings;

    public FRMTypeMakeModel()
    {
      this.Load += new EventHandler(this.FRMManager_Load);
      this._settings = (Settings) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgManager
    {
      get
      {
        return this._dgManager;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgManager_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgManager_Click);
        DataGrid dgManager1 = this._dgManager;
        if (dgManager1 != null)
        {
          dgManager1.Click -= eventHandler1;
          dgManager1.CurrentCellChanged -= eventHandler2;
        }
        this._dgManager = value;
        DataGrid dgManager2 = this._dgManager;
        if (dgManager2 == null)
          return;
        dgManager2.Click += eventHandler1;
        dgManager2.CurrentCellChanged += eventHandler2;
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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType
    {
      get
      {
        return this._cboType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboType_SelectedIndexChanged);
        ComboBox cboType1 = this._cboType;
        if (cboType1 != null)
          cboType1.SelectedIndexChanged -= eventHandler;
        this._cboType = value;
        ComboBox cboType2 = this._cboType;
        if (cboType2 == null)
          return;
        cboType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtPercentageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPercentageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxShowOnJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpItems = new GroupBox();
      this.dgManager = new DataGrid();
      this.btnAddNew = new Button();
      this.Label1 = new Label();
      this.cboType = new ComboBox();
      this.grpDetails = new GroupBox();
      this.cbxShowOnJob = new CheckBox();
      this.txtPercentageRate = new TextBox();
      this.lblPercentageRate = new Label();
      this.Label3 = new Label();
      this.txtName = new TextBox();
      this.txtDescription = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.grpItems.SuspendLayout();
      this.dgManager.BeginInit();
      this.grpDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpItems.Controls.Add((Control) this.dgManager);
      this.grpItems.Controls.Add((Control) this.btnAddNew);
      this.grpItems.Location = new System.Drawing.Point(8, 72);
      this.grpItems.Name = "grpItems";
      this.grpItems.Size = new Size(368, 416);
      this.grpItems.TabIndex = 5;
      this.grpItems.TabStop = false;
      this.grpItems.Text = "Items";
      this.dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgManager.DataMember = "";
      this.dgManager.HeaderForeColor = SystemColors.ControlText;
      this.dgManager.Location = new System.Drawing.Point(8, 53);
      this.dgManager.Name = "dgManager";
      this.dgManager.Size = new Size(352, 355);
      this.dgManager.TabIndex = 3;
      this.btnAddNew.AccessibleDescription = "Add new item";
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnAddNew.Location = new System.Drawing.Point(8, 24);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(48, 23);
      this.btnAddNew.TabIndex = 2;
      this.btnAddNew.Text = "New";
      this.Label1.Location = new System.Drawing.Point(8, 45);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 23);
      this.Label1.TabIndex = 4;
      this.Label1.Text = "Select Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.Cursor = Cursors.Hand;
      this.cboType.DisplayMember = "Description";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(88, 45);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(288, 21);
      this.cboType.TabIndex = 1;
      this.cboType.ValueMember = "Value";
      this.grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.cbxShowOnJob);
      this.grpDetails.Controls.Add((Control) this.txtPercentageRate);
      this.grpDetails.Controls.Add((Control) this.lblPercentageRate);
      this.grpDetails.Controls.Add((Control) this.Label3);
      this.grpDetails.Controls.Add((Control) this.txtName);
      this.grpDetails.Controls.Add((Control) this.txtDescription);
      this.grpDetails.Controls.Add((Control) this.Label2);
      this.grpDetails.Controls.Add((Control) this.btnSave);
      this.grpDetails.Location = new System.Drawing.Point(384, 40);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(392, 216);
      this.grpDetails.TabIndex = 7;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.cbxShowOnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbxShowOnJob.AutoSize = true;
      this.cbxShowOnJob.Location = new System.Drawing.Point(208, 188);
      this.cbxShowOnJob.Name = "cbxShowOnJob";
      this.cbxShowOnJob.Size = new Size(98, 17);
      this.cbxShowOnJob.TabIndex = 10;
      this.cbxShowOnJob.Text = "Show on Job";
      this.cbxShowOnJob.TextAlign = ContentAlignment.MiddleRight;
      this.cbxShowOnJob.UseVisualStyleBackColor = true;
      this.txtPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPercentageRate.Location = new System.Drawing.Point(104, 184);
      this.txtPercentageRate.MaxLength = (int) byte.MaxValue;
      this.txtPercentageRate.Name = "txtPercentageRate";
      this.txtPercentageRate.Size = new Size(87, 21);
      this.txtPercentageRate.TabIndex = 9;
      this.txtPercentageRate.Visible = false;
      this.lblPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPercentageRate.Location = new System.Drawing.Point(6, 184);
      this.lblPercentageRate.Name = "lblPercentageRate";
      this.lblPercentageRate.Size = new Size(72, 21);
      this.lblPercentageRate.TabIndex = 8;
      this.lblPercentageRate.Text = "Rate (%)";
      this.lblPercentageRate.Visible = false;
      this.Label3.Location = new System.Drawing.Point(8, 56);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 23);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Description";
      this.txtName.Location = new System.Drawing.Point(104, 24);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(280, 21);
      this.txtName.TabIndex = 5;
      this.txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtDescription.Location = new System.Drawing.Point(104, 56);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(280, 120);
      this.txtDescription.TabIndex = 6;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(48, 23);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Name";
      this.btnSave.AccessibleDescription = "Save item";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.ImageIndex = 1;
      this.btnSave.Location = new System.Drawing.Point(336, 184);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 7;
      this.btnSave.Text = "Save";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(784, 494);
      this.Controls.Add((Control) this.grpDetails);
      this.Controls.Add((Control) this.grpItems);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.cboType);
      this.MinimumSize = new Size(792, 528);
      this.Name = nameof (FRMTypeMakeModel);
      this.Text = "Picklists / Settings";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.cboType, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.grpItems, 0);
      this.Controls.SetChildIndex((Control) this.grpDetails, 0);
      this.grpItems.ResumeLayout(false);
      this.dgManager.EndInit();
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupManagerDataGrid();
      this.Settings = App.DB.Manager.Get();
      ComboBox cboType1 = this.cboType;
      Combo.SetUpCombo(ref cboType1, App.DB.Picklists.PickListTypesLimited().Table, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboType = cboType1;
      this.PopulateDatagrid(Enums.FormState.Load);
      ComboBox cboType2 = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType2, Conversions.ToString(0));
      this.cboType = cboType2;
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
        this._dvManager.Table.TableName = Enums.TableNames.tblPickLists.ToString();
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

    public Settings Settings
    {
      get
      {
        return this._settings;
      }
      set
      {
        this._settings = value;
      }
    }

    private void SetupManagerDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgManager.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 177;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "Description";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 177;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPickLists.ToString();
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
          this.btnSave.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.grpDetails.Enabled = true;
          this.btnAddNew.Enabled = true;
          this.btnSave.Enabled = true;
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.grpDetails.Enabled = true;
          this.btnSave.Enabled = true;
          break;
      }
      this.PageState = state;
    }

    private void FRMManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cboType.SelectedIndex == 0)
        this.PopulateDatagrid(Enums.FormState.Load);
      else
        this.PopulateDatagrid(Enums.FormState.Insert);
      if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 7)
        this.cbxShowOnJob.Visible = true;
      else
        this.cbxShowOnJob.Visible = false;
    }

    private void dgManager_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedManagerDataRow != null)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Name"])), "RC - Recall", false) == 0)
          {
            int num = (int) App.ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.SetUpPageState(Enums.FormState.Insert);
          }
          else
          {
            this.txtName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Name"]));
            this.txtDescription.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Description"]));
            this.cbxShowOnJob.Checked = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["PercentageRate"])) != 0.0;
          }
        }
        else if (this.cboType.SelectedIndex == 0)
          this.SetUpPageState(Enums.FormState.Load);
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
      try
      {
        this.lblPercentageRate.Visible = false;
        this.txtPercentageRate.Visible = false;
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 0)
        {
          this.ManagerDataview = new DataView(new DataTable()
          {
            TableName = Enums.TableNames.tblPickLists.ToString()
          });
        }
        else
        {
          this.ManagerDataview = App.DB.Picklists.GetAll((Enums.PickListTypes) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)), false);
          switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)))
          {
            case 21:
            case 41:
              this.lblPercentageRate.Visible = true;
              this.txtPercentageRate.Visible = true;
              break;
          }
        }
        this.SetUpPageState(state);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Save()
    {
      PickList pickList = new PickList();
      pickList.IgnoreExceptionsOnSetMethods = true;
      pickList.SetName = (object) this.txtName.Text.Trim();
      pickList.SetDescription = (object) this.txtDescription.Text.Trim();
      pickList.SetEnumTypeID = (object) Combo.get_GetSelectedItemValue(this.cboType);
      switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)))
      {
        case 21:
        case 41:
          pickList.SetPercentageRate = (object) this.txtPercentageRate.Text.Trim();
          break;
        default:
          pickList.SetPercentageRate = (object) 0.0;
          if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 7)
          {
            pickList.SetPercentageRate = (object) (double) -(this.cbxShowOnJob.Checked ? 1 : 0);
            break;
          }
          break;
      }
      if (this.PageState == Enums.FormState.Update)
        pickList.SetManagerID = RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["ManagerID"]);
      PickListValidator pickListValidator = new PickListValidator();
      try
      {
        pickListValidator.Validate(pickList);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.Picklists.Insert(pickList);
            break;
          case Enums.FormState.Update:
            App.DB.Picklists.Update(pickList);
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 21)
            {
              App.DB.Picklists.UpdateSellPrices(pickList);
              break;
            }
            break;
        }
        this.PopulateDatagrid(Enums.FormState.Insert);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(pickListValidator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
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
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to delete \"", this.SelectedManagerDataRow["Name"]), (object) "\" from \""), (object) Combo.get_GetSelectedItemDescription(this.cboType)), (object) "\"?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 3)
            {
              DataView dataView = App.DB.Picklists.Region_Usage(Conversions.ToInteger(this.SelectedManagerDataRow["ManagerID"]));
              if (dataView.Table.Rows.Count > 0)
              {
                string text = "The region you are trying to delete is still allocated to the following records:\r\n";
                IEnumerator enumerator;
                try
                {
                  enumerator = dataView.Table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) text, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "* ", current["type"]), (object) " - "), current["Name"]), (object) "\r\n")));
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
                int num = (int) MessageBox.Show(text, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
              }
            }
            App.DB.Picklists.Delete(Conversions.ToInteger(this.SelectedManagerDataRow["ManagerID"]));
            this.PopulateDatagrid(Enums.FormState.Insert);
          }
        }
        else
        {
          int num1 = (int) App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
