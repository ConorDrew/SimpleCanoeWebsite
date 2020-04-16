// Decompiled with JetBrains decompiler
// Type: FSM.FRMAddInvoiceAddress
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoiceToBeRaiseds;
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
  public class FRMAddInvoiceAddress : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _InvoiceAddresses;
    private int _OrderID;
    private InvoiceToBeRaised _InvoiceToBeRaised;

    public FRMAddInvoiceAddress()
    {
      this.Load += new EventHandler(this.FRMAddInvoiceAddress_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox gpbSelectInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddresses { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbSelectInvoiceAddress = new GroupBox();
      this.dgInvoiceAddresses = new DataGrid();
      this.lblInvoiceAddress = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.gpbSelectInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddresses.BeginInit();
      this.SuspendLayout();
      this.gpbSelectInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbSelectInvoiceAddress.Controls.Add((Control) this.btnCancel);
      this.gpbSelectInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddresses);
      this.gpbSelectInvoiceAddress.Controls.Add((Control) this.lblInvoiceAddress);
      this.gpbSelectInvoiceAddress.Controls.Add((Control) this.btnOK);
      this.gpbSelectInvoiceAddress.Location = new System.Drawing.Point(8, 40);
      this.gpbSelectInvoiceAddress.Name = "gpbSelectInvoiceAddress";
      this.gpbSelectInvoiceAddress.Size = new Size(512, 328);
      this.gpbSelectInvoiceAddress.TabIndex = 3;
      this.gpbSelectInvoiceAddress.TabStop = false;
      this.gpbSelectInvoiceAddress.Text = "Select Invoice Address";
      this.dgInvoiceAddresses.DataMember = "";
      this.dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddresses.Location = new System.Drawing.Point(16, 48);
      this.dgInvoiceAddresses.Name = "dgInvoiceAddresses";
      this.dgInvoiceAddresses.Size = new Size(488, 240);
      this.dgInvoiceAddresses.TabIndex = 7;
      this.lblInvoiceAddress.Location = new System.Drawing.Point(16, 24);
      this.lblInvoiceAddress.Name = "lblInvoiceAddress";
      this.lblInvoiceAddress.TabIndex = 8;
      this.lblInvoiceAddress.Text = "Invoice Address";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(424, 296);
      this.btnOK.Name = "btnOK";
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(16, 296);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "Cancel";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(528, 382);
      this.ControlBox = false;
      this.Controls.Add((Control) this.gpbSelectInvoiceAddress);
      this.MaximumSize = new Size(536, 416);
      this.MinimumSize = new Size(536, 416);
      this.Name = nameof (FRMAddInvoiceAddress);
      this.Text = "Select Invoice Address";
      this.Controls.SetChildIndex((Control) this.gpbSelectInvoiceAddress, 0);
      this.gpbSelectInvoiceAddress.ResumeLayout(false);
      this.dgInvoiceAddresses.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.OrderID = Conversions.ToInteger(this.get_GetParameter(0));
      this.SetupInvoiceAddressDataGrid();
      this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_OrderID(this.OrderID);
      if (this.InvoiceAddresses.Table.Rows.Count > 0)
      {
        this.dgInvoiceAddresses.CurrentRowIndex = 0;
        this.dgInvoiceAddresses.Select(this.dgInvoiceAddresses.CurrentRowIndex);
      }
      this.InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(Conversions.ToInteger(this.get_GetParameter(1)));
      this.AddressSelected += new FRMAddInvoiceAddress.AddressSelectedEventHandler(((FRMInvoiceManager) this.get_GetParameter(2)).PopulateDatagrid);
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

    public void SetupInvoiceAddressDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddresses, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddresses.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgInvoiceAddresses.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address Type";
      dataGridLabelColumn1.MappingName = "AddressType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "Address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 2";
      dataGridLabelColumn3.MappingName = "Address2";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 3";
      dataGridLabelColumn4.MappingName = "Address3";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address 4";
      dataGridLabelColumn5.MappingName = "Address4";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address 5";
      dataGridLabelColumn6.MappingName = "Address5";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Postcode";
      dataGridLabelColumn7.MappingName = "Postcode";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
      this.dgInvoiceAddresses.TableStyles.Add(tableStyle);
    }

    private DataView InvoiceAddresses
    {
      get
      {
        return this._InvoiceAddresses;
      }
      set
      {
        this._InvoiceAddresses = value;
        this._InvoiceAddresses.AllowDelete = false;
        this._InvoiceAddresses.AllowEdit = false;
        this._InvoiceAddresses.AllowNew = false;
        this._InvoiceAddresses.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this.dgInvoiceAddresses.DataSource = (object) this.InvoiceAddresses;
      }
    }

    private DataRow SelectedInvoiceAddressesDataRow
    {
      get
      {
        return this.dgInvoiceAddresses.CurrentRowIndex != -1 ? this.InvoiceAddresses[this.dgInvoiceAddresses.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private int OrderID
    {
      get
      {
        return this._OrderID;
      }
      set
      {
        this._OrderID = value;
      }
    }

    private InvoiceToBeRaised InvoiceToBeRaised
    {
      get
      {
        return this._InvoiceToBeRaised;
      }
      set
      {
        this._InvoiceToBeRaised = value;
      }
    }

    private event FRMAddInvoiceAddress.AddressSelectedEventHandler AddressSelected;

    private void FRMAddInvoiceAddress_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.SelectedInvoiceAddressesDataRow == null)
        return;
      this.InvoiceToBeRaised.SetAddressLinkID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
      this.InvoiceToBeRaised.SetAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
      App.DB.InvoiceToBeRaised.Update(this.InvoiceToBeRaised);
      // ISSUE: reference to a compiler-generated field
      FRMAddInvoiceAddress.AddressSelectedEventHandler addressSelectedEvent = this.AddressSelectedEvent;
      if (addressSelectedEvent != null)
        addressSelectedEvent();
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private delegate void AddressSelectedEventHandler();
  }
}
