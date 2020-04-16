// Decompiled with JetBrains decompiler
// Type: FSM.FRMOrderCharges
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderCharges;
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
  public class FRMOrderCharges : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _OrderID;
    private Enums.FormState _PageState;
    private DataView _ChargesDataView;

    public FRMOrderCharges()
    {
      this.Load += new EventHandler(this.FRMOrderCharges_Load);
      this._PageState = Enums.FormState.Insert;
      this._ChargesDataView = (DataView) null;
      this.InitializeComponent();
      ComboBox cboChargeType = this.cboChargeType;
      Combo.SetUpCombo(ref cboChargeType, App.DB.Picklists.GetAll(Enums.PickListTypes.OrderChargeTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboChargeType = cboChargeType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCharges
    {
      get
      {
        return this._dgCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgCharges_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgCharges_Click);
        DataGrid dgCharges1 = this._dgCharges;
        if (dgCharges1 != null)
        {
          dgCharges1.Click -= eventHandler1;
          dgCharges1.CurrentCellChanged -= eventHandler2;
        }
        this._dgCharges = value;
        DataGrid dgCharges2 = this._dgCharges;
        if (dgCharges2 == null)
          return;
        dgCharges2.Click += eventHandler1;
        dgCharges2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboChargeType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpCharges = new GroupBox();
      this.btnDelete = new Button();
      this.btnSave = new Button();
      this.txtAmount = new TextBox();
      this.Label2 = new Label();
      this.cboChargeType = new ComboBox();
      this.Label1 = new Label();
      this.dgCharges = new DataGrid();
      this.grpCharges.SuspendLayout();
      this.dgCharges.BeginInit();
      this.SuspendLayout();
      this.grpCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCharges.Controls.Add((Control) this.btnDelete);
      this.grpCharges.Controls.Add((Control) this.btnSave);
      this.grpCharges.Controls.Add((Control) this.txtAmount);
      this.grpCharges.Controls.Add((Control) this.Label2);
      this.grpCharges.Controls.Add((Control) this.cboChargeType);
      this.grpCharges.Controls.Add((Control) this.Label1);
      this.grpCharges.Controls.Add((Control) this.dgCharges);
      this.grpCharges.Location = new System.Drawing.Point(8, 40);
      this.grpCharges.Name = "grpCharges";
      this.grpCharges.Size = new Size(552, 272);
      this.grpCharges.TabIndex = 2;
      this.grpCharges.TabStop = false;
      this.grpCharges.Text = "Charges";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(480, 208);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(64, 23);
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "Remove";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(480, 240);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(64, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Add";
      this.txtAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtAmount.Location = new System.Drawing.Point(400, 240);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new Size(72, 21);
      this.txtAmount.TabIndex = 3;
      this.txtAmount.Text = "";
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label2.Location = new System.Drawing.Point(336, 240);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(56, 23);
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Amount:";
      this.cboChargeType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cboChargeType.Location = new System.Drawing.Point(96, 240);
      this.cboChargeType.Name = "cboChargeType";
      this.cboChargeType.Size = new Size(232, 21);
      this.cboChargeType.TabIndex = 2;
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.Location = new System.Drawing.Point(8, 240);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 23);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Charge Type:";
      this.dgCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCharges.DataMember = "";
      this.dgCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgCharges.Location = new System.Drawing.Point(8, 25);
      this.dgCharges.Name = "dgCharges";
      this.dgCharges.Size = new Size(536, 175);
      this.dgCharges.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(568, 318);
      this.Controls.Add((Control) this.grpCharges);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(576, 352);
      this.Name = nameof (FRMOrderCharges);
      this.Text = "Order Charges";
      this.Controls.SetChildIndex((Control) this.grpCharges, 0);
      this.grpCharges.ResumeLayout(false);
      this.dgCharges.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.OrderID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupChargesDatagrid();
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
      this.OrderID = newID;
    }

    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
      set
      {
        this._OrderID = value;
        this.RefreshDatagrid();
      }
    }

    public Enums.FormState PageState
    {
      get
      {
        return this._PageState;
      }
      set
      {
        this._PageState = value;
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            this.btnSave.Text = "Add";
            break;
          case Enums.FormState.Update:
            this.btnSave.Text = "Update";
            break;
        }
        this.txtAmount.Text = "";
        ComboBox cboChargeType = this.cboChargeType;
        Combo.SetSelectedComboItem_By_Value(ref cboChargeType, Conversions.ToString(0));
        this.cboChargeType = cboChargeType;
      }
    }

    public DataView ChargesDataView
    {
      get
      {
        return this._ChargesDataView;
      }
      set
      {
        this._ChargesDataView = value;
        this._ChargesDataView.Table.TableName = Enums.TableNames.tblOrderCharge.ToString();
        this._ChargesDataView.AllowNew = false;
        this._ChargesDataView.AllowEdit = false;
        this._ChargesDataView.AllowDelete = false;
        this.dgCharges.DataSource = (object) this.ChargesDataView;
      }
    }

    private DataRow SelectedChargeDataRow
    {
      get
      {
        return this.dgCharges.CurrentRowIndex != -1 ? this.ChargesDataView[this.dgCharges.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupChargesDatagrid()
    {
      Helper.SetUpDataGrid(this.dgCharges, false);
      DataGridTableStyle tableStyle = this.dgCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "ChargeType";
      dataGridLabelColumn1.MappingName = "ChargeType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Amount";
      dataGridLabelColumn2.MappingName = "Amount";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblOrderCharge.ToString();
      this.dgCharges.TableStyles.Add(tableStyle);
    }

    private void FRMOrderCharges_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgCharges_Click(object sender, EventArgs e)
    {
      if (this.SelectedChargeDataRow == null)
      {
        this.PageState = Enums.FormState.Insert;
      }
      else
      {
        this.PageState = Enums.FormState.Update;
        this.txtAmount.Text = Conversions.ToString(this.SelectedChargeDataRow["Amount"]);
        ComboBox cboChargeType = this.cboChargeType;
        Combo.SetSelectedComboItem_By_Value(ref cboChargeType, Conversions.ToString(this.SelectedChargeDataRow["OrderChargeTypeID"]));
        this.cboChargeType = cboChargeType;
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        OrderCharge oOrderCharge = new OrderCharge();
        oOrderCharge.IgnoreExceptionsOnSetMethods = true;
        oOrderCharge.SetAmount = (object) this.txtAmount.Text.Trim();
        oOrderCharge.SetOrderChargeTypeID = (object) Combo.get_GetSelectedItemValue(this.cboChargeType);
        oOrderCharge.SetOrderID = (object) this.OrderID;
        new OrderChargeValidator().Validate(oOrderCharge);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.OrderCharge.Insert(oOrderCharge);
            break;
          case Enums.FormState.Update:
            oOrderCharge.SetOrderChargeID = RuntimeHelpers.GetObjectValue(this.SelectedChargeDataRow["OrderChargeID"]);
            App.DB.OrderCharge.Update(oOrderCharge);
            break;
        }
        this.RefreshDatagrid();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedChargeDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.PageState = Enums.FormState.Insert;
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.OrderCharge.Delete(Conversions.ToInteger(this.SelectedChargeDataRow["OrderChargeID"]));
        this.RefreshDatagrid();
      }
    }

    public void RefreshDatagrid()
    {
      this.ChargesDataView = App.DB.OrderCharge.OrderCharge_GetForOrder(this.OrderID);
      this.PageState = Enums.FormState.Insert;
    }
  }
}
