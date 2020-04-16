// Decompiled with JetBrains decompiler
// Type: FSM.FrmRaiseInvoiceDetails
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class FrmRaiseInvoiceDetails : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _InvoiceAddresses;
    private int _OrderID;

    public FrmRaiseInvoiceDetails()
    {
      this.Load += new EventHandler(this.FrmRaiseInvoiceDetails_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual DataGrid dgInvoiceAddresses
    {
      get
      {
        return this._dgInvoiceAddresses;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgInvoiceAddresses_Click);
        DataGrid invoiceAddresses1 = this._dgInvoiceAddresses;
        if (invoiceAddresses1 != null)
          invoiceAddresses1.Click -= eventHandler;
        this._dgInvoiceAddresses = value;
        DataGrid invoiceAddresses2 = this._dgInvoiceAddresses;
        if (invoiceAddresses2 == null)
          return;
        invoiceAddresses2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpRaiseInvoiceOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRaiseInvoiceOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox gpbRaiseInvoice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbRaiseInvoice = new GroupBox();
      this.dgInvoiceAddresses = new DataGrid();
      this.dtpRaiseInvoiceOn = new DateTimePicker();
      this.lblRaiseInvoiceOn = new Label();
      this.lblInvoiceAddress = new Label();
      this.btnOK = new Button();
      this.gpbRaiseInvoice.SuspendLayout();
      this.dgInvoiceAddresses.BeginInit();
      this.SuspendLayout();
      this.gpbRaiseInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbRaiseInvoice.Controls.Add((Control) this.dgInvoiceAddresses);
      this.gpbRaiseInvoice.Controls.Add((Control) this.dtpRaiseInvoiceOn);
      this.gpbRaiseInvoice.Controls.Add((Control) this.lblRaiseInvoiceOn);
      this.gpbRaiseInvoice.Controls.Add((Control) this.lblInvoiceAddress);
      this.gpbRaiseInvoice.Controls.Add((Control) this.btnOK);
      this.gpbRaiseInvoice.Location = new System.Drawing.Point(8, 32);
      this.gpbRaiseInvoice.Name = "gpbRaiseInvoice";
      this.gpbRaiseInvoice.Size = new Size(512, 240);
      this.gpbRaiseInvoice.TabIndex = 2;
      this.gpbRaiseInvoice.TabStop = false;
      this.gpbRaiseInvoice.Text = "Raise Invoice";
      this.dgInvoiceAddresses.DataMember = "";
      this.dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddresses.Location = new System.Drawing.Point(16, 64);
      this.dgInvoiceAddresses.Name = "dgInvoiceAddresses";
      this.dgInvoiceAddresses.Size = new Size(488, 136);
      this.dgInvoiceAddresses.TabIndex = 7;
      this.dtpRaiseInvoiceOn.Format = DateTimePickerFormat.Short;
      this.dtpRaiseInvoiceOn.Location = new System.Drawing.Point(136, 24);
      this.dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn";
      this.dtpRaiseInvoiceOn.Size = new Size(120, 21);
      this.dtpRaiseInvoiceOn.TabIndex = 6;
      this.lblRaiseInvoiceOn.Location = new System.Drawing.Point(16, 24);
      this.lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn";
      this.lblRaiseInvoiceOn.Size = new Size(112, 23);
      this.lblRaiseInvoiceOn.TabIndex = 5;
      this.lblRaiseInvoiceOn.Text = "Raise Invoice On:";
      this.lblRaiseInvoiceOn.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInvoiceAddress.Location = new System.Drawing.Point(16, 48);
      this.lblInvoiceAddress.Name = "lblInvoiceAddress";
      this.lblInvoiceAddress.TabIndex = 8;
      this.lblInvoiceAddress.Text = "Invoice Address";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(216, 208);
      this.btnOK.Name = "btnOK";
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(528, 278);
      this.ControlBox = false;
      this.Controls.Add((Control) this.gpbRaiseInvoice);
      this.Name = nameof (FrmRaiseInvoiceDetails);
      this.Text = "Raise Invoice";
      this.Controls.SetChildIndex((Control) this.gpbRaiseInvoice, 0);
      this.gpbRaiseInvoice.ResumeLayout(false);
      this.dgInvoiceAddresses.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.OrderID = Conversions.ToInteger(this.get_GetParameter(0));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      int num1 = 0;
      try
      {
        num1 = Conversions.ToInteger(this.get_GetParameter(1));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.SetupInvoiceAddressDataGrid();
      this.dtpRaiseInvoiceOn.Value = DateAndTime.Now;
      this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_OrderID(this.OrderID);
      if (this.InvoiceAddresses.Table.Rows.Count > 0)
      {
        this.dgInvoiceAddresses.CurrentRowIndex = 0;
        this.dgInvoiceAddresses.Select(this.dgInvoiceAddresses.CurrentRowIndex);
      }
      if (num1 <= 0)
        return;
      int num2 = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.InvoiceAddresses.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressType"], (object) Enums.InvoiceAddressType.Invoice.ToString(), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressID"], (object) num1, false))))
          {
            if (this.InvoiceAddresses.Table.Rows.Count > 0)
              this.dgInvoiceAddresses.UnSelect(this.dgInvoiceAddresses.CurrentRowIndex);
            this.dgInvoiceAddresses.CurrentRowIndex = num2;
            this.dgInvoiceAddresses.Select(this.dgInvoiceAddresses.CurrentRowIndex);
            break;
          }
          checked { ++num2; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
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

    private void FrmRaiseInvoiceDetails_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.SelectedInvoiceAddressesDataRow == null & this.InvoiceAddresses.Table.Rows.Count > 0)
        return;
      InvoiceToBeRaised oInvoiceToBeRaised = new InvoiceToBeRaised();
      oInvoiceToBeRaised.RaiseDate = this.dtpRaiseInvoiceOn.Value;
      oInvoiceToBeRaised.SetInvoiceTypeID = (object) 261;
      oInvoiceToBeRaised.SetLinkID = (object) this.OrderID;
      if (this.SelectedInvoiceAddressesDataRow == null & this.InvoiceAddresses.Table.Rows.Count == 0)
      {
        int num = (int) MessageBox.Show("There is no invoice addresses to select. You will need to select an address at invoice generation", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        oInvoiceToBeRaised.SetAddressLinkID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
        oInvoiceToBeRaised.SetAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
      }
      App.DB.InvoiceToBeRaised.Insert(oInvoiceToBeRaised);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void dgInvoiceAddresses_Click(object sender, EventArgs e)
    {
      if (this.InvoiceAddresses.Table.Rows.Count <= 0)
        return;
      this.dgInvoiceAddresses.Select(this.dgInvoiceAddresses.CurrentRowIndex);
    }
  }
}
