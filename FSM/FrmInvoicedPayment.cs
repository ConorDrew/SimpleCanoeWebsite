// Decompiled with JetBrains decompiler
// Type: FSM.FrmInvoicedPayment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.Jobs;
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
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FrmInvoicedPayment : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool _changingAmount;
    private int _InvoicedID;
    private double _InvoiceTotal;
    private int _EngineerVisitID;

    public FrmInvoicedPayment()
    {
      this.Load += new EventHandler(this.FRMInvoiceManager_Load);
      this._changingAmount = false;
      this._InvoicedID = 0;
      this._InvoiceTotal = 0.0;
      this._EngineerVisitID = 0;
      this.InitializeComponent();
      ComboBox cboPaymentTerm = this.cboPaymentTerm;
      Combo.SetUpCombo(ref cboPaymentTerm, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTerms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaymentTerm = cboPaymentTerm;
      ComboBox cboPaidBy = this.cboPaidBy;
      Combo.SetUpCombo(ref cboPaidBy, App.DB.Picklists.GetAll(Enums.PickListTypes.Locations | Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaidBy = cboPaidBy;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox gpbPayment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPay
    {
      get
      {
        return this._btnPay;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPayment_Click);
        Button btnPay1 = this._btnPay;
        if (btnPay1 != null)
          btnPay1.Click -= eventHandler;
        this._btnPay = value;
        Button btnPay2 = this._btnPay;
        if (btnPay2 == null)
          return;
        btnPay2.Click += eventHandler;
      }
    }

    internal virtual GroupBox gpbInvoiceInformation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRaisedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRaisedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRaisedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaymentTerm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaymentTerm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRaisedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbPayment = new GroupBox();
      this.lblAccountNumber = new Label();
      this.txtAccountNumber = new TextBox();
      this.cboPaidBy = new ComboBox();
      this.lblPaidBy = new Label();
      this.cboPaymentTerm = new ComboBox();
      this.lblPaymentTerm = new Label();
      this.btnPay = new Button();
      this.gpbInvoiceInformation = new GroupBox();
      this.txtRaisedBy = new TextBox();
      this.txtRaisedDate = new TextBox();
      this.lblRaisedBy = new Label();
      this.lblRaisedDate = new Label();
      this.txtInvAmount = new TextBox();
      this.txtInvNumber = new TextBox();
      this.lblInvoiceTotal = new Label();
      this.lblInvoice = new Label();
      this.txtInvoiceAddress = new TextBox();
      this.txtCustomer = new TextBox();
      this.lblInvoiceAddress = new Label();
      this.lblCustomer = new Label();
      this.gpbPayment.SuspendLayout();
      this.gpbInvoiceInformation.SuspendLayout();
      this.SuspendLayout();
      this.gpbPayment.Controls.Add((Control) this.lblAccountNumber);
      this.gpbPayment.Controls.Add((Control) this.txtAccountNumber);
      this.gpbPayment.Controls.Add((Control) this.cboPaidBy);
      this.gpbPayment.Controls.Add((Control) this.lblPaidBy);
      this.gpbPayment.Controls.Add((Control) this.cboPaymentTerm);
      this.gpbPayment.Controls.Add((Control) this.lblPaymentTerm);
      this.gpbPayment.Controls.Add((Control) this.btnPay);
      this.gpbPayment.Location = new System.Drawing.Point(8, 170);
      this.gpbPayment.Name = "gpbPayment";
      this.gpbPayment.Size = new Size(436, 153);
      this.gpbPayment.TabIndex = 1;
      this.gpbPayment.TabStop = false;
      this.gpbPayment.Text = "Payment";
      this.lblAccountNumber.Location = new System.Drawing.Point(8, 84);
      this.lblAccountNumber.Name = "lblAccountNumber";
      this.lblAccountNumber.Size = new Size(136, 23);
      this.lblAccountNumber.TabIndex = 16;
      this.lblAccountNumber.Text = "Account Number";
      this.txtAccountNumber.Location = new System.Drawing.Point(145, 81);
      this.txtAccountNumber.Name = "txtAccountNumber";
      this.txtAccountNumber.Size = new Size(279, 21);
      this.txtAccountNumber.TabIndex = 15;
      this.cboPaidBy.FormattingEnabled = true;
      this.cboPaidBy.Location = new System.Drawing.Point(145, 54);
      this.cboPaidBy.Name = "cboPaidBy";
      this.cboPaidBy.Size = new Size(279, 21);
      this.cboPaidBy.TabIndex = 14;
      this.lblPaidBy.AutoSize = true;
      this.lblPaidBy.Location = new System.Drawing.Point(9, 54);
      this.lblPaidBy.Name = "lblPaidBy";
      this.lblPaidBy.Size = new Size(50, 13);
      this.lblPaidBy.TabIndex = 13;
      this.lblPaidBy.Text = "Paid By";
      this.cboPaymentTerm.FormattingEnabled = true;
      this.cboPaymentTerm.Location = new System.Drawing.Point(145, 24);
      this.cboPaymentTerm.Name = "cboPaymentTerm";
      this.cboPaymentTerm.Size = new Size(279, 21);
      this.cboPaymentTerm.TabIndex = 12;
      this.lblPaymentTerm.AutoSize = true;
      this.lblPaymentTerm.Location = new System.Drawing.Point(8, 24);
      this.lblPaymentTerm.Name = "lblPaymentTerm";
      this.lblPaymentTerm.Size = new Size(90, 13);
      this.lblPaymentTerm.TabIndex = 11;
      this.lblPaymentTerm.Text = "Payment Term";
      this.btnPay.Location = new System.Drawing.Point(349, 114);
      this.btnPay.Name = "btnPay";
      this.btnPay.Size = new Size(75, 23);
      this.btnPay.TabIndex = 6;
      this.btnPay.Text = "Pay";
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtRaisedBy);
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtRaisedDate);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblRaisedBy);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblRaisedDate);
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtInvAmount);
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtInvNumber);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblInvoiceTotal);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblInvoice);
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtInvoiceAddress);
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtCustomer);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblInvoiceAddress);
      this.gpbInvoiceInformation.Controls.Add((Control) this.lblCustomer);
      this.gpbInvoiceInformation.Location = new System.Drawing.Point(8, 32);
      this.gpbInvoiceInformation.Name = "gpbInvoiceInformation";
      this.gpbInvoiceInformation.Size = new Size(436, 132);
      this.gpbInvoiceInformation.TabIndex = 2;
      this.gpbInvoiceInformation.TabStop = false;
      this.gpbInvoiceInformation.Text = "Invoice Information";
      this.txtRaisedBy.Location = new System.Drawing.Point(312, 94);
      this.txtRaisedBy.Name = "txtRaisedBy";
      this.txtRaisedBy.ReadOnly = true;
      this.txtRaisedBy.Size = new Size(112, 21);
      this.txtRaisedBy.TabIndex = 11;
      this.txtRaisedDate.Location = new System.Drawing.Point(312, 70);
      this.txtRaisedDate.Name = "txtRaisedDate";
      this.txtRaisedDate.ReadOnly = true;
      this.txtRaisedDate.Size = new Size(112, 21);
      this.txtRaisedDate.TabIndex = 10;
      this.lblRaisedBy.Location = new System.Drawing.Point(232, 94);
      this.lblRaisedBy.Name = "lblRaisedBy";
      this.lblRaisedBy.Size = new Size(80, 23);
      this.lblRaisedBy.TabIndex = 9;
      this.lblRaisedBy.Text = "Raised By";
      this.lblRaisedDate.Location = new System.Drawing.Point(232, 70);
      this.lblRaisedDate.Name = "lblRaisedDate";
      this.lblRaisedDate.Size = new Size(80, 23);
      this.lblRaisedDate.TabIndex = 8;
      this.lblRaisedDate.Text = "Raised Date";
      this.txtInvAmount.Location = new System.Drawing.Point(112, 94);
      this.txtInvAmount.Name = "txtInvAmount";
      this.txtInvAmount.ReadOnly = true;
      this.txtInvAmount.Size = new Size(112, 21);
      this.txtInvAmount.TabIndex = 7;
      this.txtInvNumber.Location = new System.Drawing.Point(112, 70);
      this.txtInvNumber.Name = "txtInvNumber";
      this.txtInvNumber.ReadOnly = true;
      this.txtInvNumber.Size = new Size(112, 21);
      this.txtInvNumber.TabIndex = 6;
      this.lblInvoiceTotal.Location = new System.Drawing.Point(8, 94);
      this.lblInvoiceTotal.Name = "lblInvoiceTotal";
      this.lblInvoiceTotal.Size = new Size(96, 23);
      this.lblInvoiceTotal.TabIndex = 5;
      this.lblInvoiceTotal.Text = "Invoice Total";
      this.lblInvoice.Location = new System.Drawing.Point(8, 70);
      this.lblInvoice.Name = "lblInvoice";
      this.lblInvoice.Size = new Size(101, 23);
      this.lblInvoice.TabIndex = 4;
      this.lblInvoice.Text = "Invoice Number";
      this.txtInvoiceAddress.Location = new System.Drawing.Point(112, 40);
      this.txtInvoiceAddress.Name = "txtInvoiceAddress";
      this.txtInvoiceAddress.ReadOnly = true;
      this.txtInvoiceAddress.Size = new Size(312, 21);
      this.txtInvoiceAddress.TabIndex = 3;
      this.txtCustomer.Location = new System.Drawing.Point(112, 16);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(312, 21);
      this.txtCustomer.TabIndex = 2;
      this.lblInvoiceAddress.Location = new System.Drawing.Point(8, 40);
      this.lblInvoiceAddress.Name = "lblInvoiceAddress";
      this.lblInvoiceAddress.Size = new Size(100, 23);
      this.lblInvoiceAddress.TabIndex = 1;
      this.lblInvoiceAddress.Text = "Invoice Address";
      this.lblCustomer.Location = new System.Drawing.Point(8, 16);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(100, 23);
      this.lblCustomer.TabIndex = 0;
      this.lblCustomer.Text = "Customer";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(451, 334);
      this.Controls.Add((Control) this.gpbInvoiceInformation);
      this.Controls.Add((Control) this.gpbPayment);
      this.Name = nameof (FrmInvoicedPayment);
      this.Text = "Invoice Payment";
      this.Controls.SetChildIndex((Control) this.gpbPayment, 0);
      this.Controls.SetChildIndex((Control) this.gpbInvoiceInformation, 0);
      this.gpbPayment.ResumeLayout(false);
      this.gpbPayment.PerformLayout();
      this.gpbInvoiceInformation.ResumeLayout(false);
      this.gpbInvoiceInformation.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.InvoicedID = Conversions.ToInteger(this.get_GetParameter(0));
      this.EngineerVisitID = Conversions.ToInteger(this.get_GetParameter(6));
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

    private int InvoicedID
    {
      get
      {
        return this._InvoicedID;
      }
      set
      {
        this._InvoicedID = value;
        this.Populate();
      }
    }

    private double InvoiceTotal
    {
      get
      {
        return this._InvoiceTotal;
      }
      set
      {
        this._InvoiceTotal = value;
      }
    }

    private int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
      set
      {
        this._EngineerVisitID = value;
      }
    }

    private void FRMInvoiceManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnAddPayment_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      this.MakePayment();
    }

    private void Populate()
    {
      this.txtCustomer.Text = Conversions.ToString(this.get_GetParameter(1));
      this.txtInvoiceAddress.Text = Conversions.ToString(this.get_GetParameter(2));
      this.txtInvNumber.Text = Conversions.ToString(this.get_GetParameter(3));
      this.txtRaisedDate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(this.get_GetParameter(4)), "dd/MM/yyyy");
      this.txtRaisedBy.Text = Conversions.ToString(this.get_GetParameter(5));
      IEnumerator enumerator;
      try
      {
        enumerator = App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(this.InvoicedID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          this.InvoiceTotal += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(((DataRow) enumerator.Current)["Amount"]));
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtInvAmount.Text = Strings.Format((object) (this.InvoiceTotal + Math.Round(this.InvoiceTotal * (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(7))) / 100.0), 2, MidpointRounding.ToEven)), "C");
    }

    private void MakePayment()
    {
      try
      {
        int PaidBy = 0;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaidBy)) > 0.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)) == 69491.0)
          PaidBy = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaidBy));
        App.DB.InvoicedLines.Invoiced_ChangeTerm(this.InvoicedID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)), PaidBy);
        EngineerVisitCharge oEngineerVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(this.EngineerVisitID);
        oEngineerVisitCharge.SetForSageAccountCode = (object) this.txtAccountNumber.Text.Trim();
        App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(oEngineerVisitCharge, (Job) null);
        if (App.ShowMessage("Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        Printing printing = new Printing((object) this.InvoicedID, "Receipt", Enums.SystemDocumentType.PaymentReceipt, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error processing payment\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
