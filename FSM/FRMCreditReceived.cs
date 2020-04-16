// Decompiled with JetBrains decompiler
// Type: FSM.FRMCreditReceived
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartsToBeCrediteds;
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
  [DesignerGenerated]
  public class FRMCreditReceived : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _PartCreditsID;
    private DataView _dvCredits;

    public FRMCreditReceived()
    {
      this.Load += new EventHandler(this.FRMCreditReceived_Load);
      this._PartCreditsID = 0;
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.txtExtraRef = new TextBox();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.dtpDateReceived = new DateTimePicker();
      this.txtDepartment = new TextBox();
      this.txtNominalCode = new TextBox();
      this.Label16 = new Label();
      this.txtVAT = new TextBox();
      this.cboTaxCode = new ComboBox();
      this.Label13 = new Label();
      this.txtnotes = new TextBox();
      this.txtTotalAmount = new TextBox();
      this.txtCreditReference = new TextBox();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.Label14 = new Label();
      this.Label17 = new Label();
      this.grpJobs = new GroupBox();
      this.dgCredits = new DataGrid();
      this.btnSave = new Button();
      this.txtOrignalAmount = new TextBox();
      this.Label6 = new Label();
      this.Label7 = new Label();
      this.txtSupplierCreditRef = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.grpJobs.SuspendLayout();
      this.dgCredits.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtSupplierCreditRef);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.txtExtraRef);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.dtpDateReceived);
      this.GroupBox1.Controls.Add((Control) this.txtDepartment);
      this.GroupBox1.Controls.Add((Control) this.txtNominalCode);
      this.GroupBox1.Controls.Add((Control) this.Label16);
      this.GroupBox1.Controls.Add((Control) this.txtVAT);
      this.GroupBox1.Controls.Add((Control) this.cboTaxCode);
      this.GroupBox1.Controls.Add((Control) this.Label13);
      this.GroupBox1.Controls.Add((Control) this.txtnotes);
      this.GroupBox1.Controls.Add((Control) this.txtTotalAmount);
      this.GroupBox1.Controls.Add((Control) this.txtCreditReference);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.Label14);
      this.GroupBox1.Controls.Add((Control) this.Label17);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(868, 126);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Credit Received";
      this.txtExtraRef.Location = new System.Drawing.Point(329, 95);
      this.txtExtraRef.MaxLength = 100;
      this.txtExtraRef.Name = "txtExtraRef";
      this.txtExtraRef.Size = new Size(195, 21);
      this.txtExtraRef.TabIndex = 8;
      this.txtExtraRef.Tag = (object) " ";
      this.Label5.Location = new System.Drawing.Point(265, 99);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(70, 20);
      this.Label5.TabIndex = 77;
      this.Label5.Text = "Extra Ref";
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(6, 70);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(90, 13);
      this.Label4.TabIndex = 75;
      this.Label4.Text = "Date Received";
      this.dtpDateReceived.Location = new System.Drawing.Point(116, 66);
      this.dtpDateReceived.Name = "dtpDateReceived";
      this.dtpDateReceived.Size = new Size(142, 21);
      this.dtpDateReceived.TabIndex = 2;
      this.txtDepartment.Location = new System.Drawing.Point(437, 43);
      this.txtDepartment.MaxLength = 100;
      this.txtDepartment.Name = "txtDepartment";
      this.txtDepartment.Size = new Size(88, 21);
      this.txtDepartment.TabIndex = 5;
      this.txtDepartment.Tag = (object) "Order.SupplierInvoiceReference";
      this.txtNominalCode.Location = new System.Drawing.Point(329, 43);
      this.txtNominalCode.MaxLength = 100;
      this.txtNominalCode.Name = "txtNominalCode";
      this.txtNominalCode.Size = new Size(58, 21);
      this.txtNominalCode.TabIndex = 4;
      this.txtNominalCode.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label16.Location = new System.Drawing.Point(265, 43);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(70, 20);
      this.Label16.TabIndex = 71;
      this.Label16.Text = "Nominal";
      this.txtVAT.Location = new System.Drawing.Point(437, 69);
      this.txtVAT.MaxLength = 100;
      this.txtVAT.Name = "txtVAT";
      this.txtVAT.ReadOnly = true;
      this.txtVAT.Size = new Size(87, 21);
      this.txtVAT.TabIndex = 7;
      this.txtVAT.Tag = (object) "Order.SupplierInvoiceAmount";
      this.cboTaxCode.Location = new System.Drawing.Point(329, 69);
      this.cboTaxCode.Name = "cboTaxCode";
      this.cboTaxCode.Size = new Size(58, 21);
      this.cboTaxCode.TabIndex = 6;
      this.Label13.Location = new System.Drawing.Point(265, 72);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(70, 20);
      this.Label13.TabIndex = 70;
      this.Label13.Text = "Tax Code";
      this.txtnotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtnotes.Location = new System.Drawing.Point(571, 14);
      this.txtnotes.Multiline = true;
      this.txtnotes.Name = "txtnotes";
      this.txtnotes.ScrollBars = ScrollBars.Vertical;
      this.txtnotes.Size = new Size(290, 102);
      this.txtnotes.TabIndex = 9;
      this.txtTotalAmount.Location = new System.Drawing.Point(116, 40);
      this.txtTotalAmount.Name = "txtTotalAmount";
      this.txtTotalAmount.ReadOnly = true;
      this.txtTotalAmount.Size = new Size(142, 21);
      this.txtTotalAmount.TabIndex = 1;
      this.txtCreditReference.Location = new System.Drawing.Point(116, 14);
      this.txtCreditReference.Name = "txtCreditReference";
      this.txtCreditReference.ReadOnly = true;
      this.txtCreditReference.Size = new Size(142, 21);
      this.txtCreditReference.TabIndex = 0;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(526, 14);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(39, 13);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Notes";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 43);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(83, 13);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Total Amount";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(104, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Credit Reference";
      this.Label14.Location = new System.Drawing.Point(402, 72);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(38, 20);
      this.Label14.TabIndex = 72;
      this.Label14.Text = "VAT";
      this.Label17.Location = new System.Drawing.Point(402, 46);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(38, 20);
      this.Label17.TabIndex = 73;
      this.Label17.Text = "Dept";
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgCredits);
      this.grpJobs.Location = new System.Drawing.Point(12, 170);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(868, 261);
      this.grpJobs.TabIndex = 3;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Parts";
      this.dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCredits.DataMember = "";
      this.dgCredits.HeaderForeColor = SystemColors.ControlText;
      this.dgCredits.Location = new System.Drawing.Point(8, 20);
      this.dgCredits.Name = "dgCredits";
      this.dgCredits.Size = new Size(852, 233);
      this.dgCredits.TabIndex = 0;
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(805, 439);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.txtOrignalAmount.Location = new System.Drawing.Point(117, 439);
      this.txtOrignalAmount.Name = "txtOrignalAmount";
      this.txtOrignalAmount.ReadOnly = true;
      this.txtOrignalAmount.Size = new Size(142, 21);
      this.txtOrignalAmount.TabIndex = 6;
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(12, 442);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(99, 13);
      this.Label6.TabIndex = 5;
      this.Label6.Text = "Original Amount";
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(265, 17);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(116, 13);
      this.Label7.TabIndex = 78;
      this.Label7.Text = "Supplier Credit Ref";
      this.txtSupplierCreditRef.Location = new System.Drawing.Point(387, 14);
      this.txtSupplierCreditRef.MaxLength = 100;
      this.txtSupplierCreditRef.Name = "txtSupplierCreditRef";
      this.txtSupplierCreditRef.Size = new Size(138, 21);
      this.txtSupplierCreditRef.TabIndex = 3;
      this.txtSupplierCreditRef.Tag = (object) " ";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(892, 470);
      this.Controls.Add((Control) this.txtOrignalAmount);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMCreditReceived);
      this.Text = "Credit Received";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.Label6, 0);
      this.Controls.SetChildIndex((Control) this.txtOrignalAmount, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.grpJobs.ResumeLayout(false);
      this.dgCredits.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtnotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotalAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCreditReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCredits
    {
      get
      {
        return this._dgCredits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgCredits_CurrentCellChanged);
        DataGrid dgCredits1 = this._dgCredits;
        if (dgCredits1 != null)
          dgCredits1.CurrentCellChanged -= eventHandler;
        this._dgCredits = value;
        DataGrid dgCredits2 = this._dgCredits;
        if (dgCredits2 == null)
          return;
        dgCredits2.CurrentCellChanged += eventHandler;
      }
    }

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

    internal virtual TextBox txtDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominalCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTaxCode
    {
      get
      {
        return this._cboTaxCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTaxCode_SelectedIndexChanged);
        ComboBox cboTaxCode1 = this._cboTaxCode;
        if (cboTaxCode1 != null)
          cboTaxCode1.SelectedIndexChanged -= eventHandler;
        this._cboTaxCode = value;
        ComboBox cboTaxCode2 = this._cboTaxCode;
        if (cboTaxCode2 == null)
          return;
        cboTaxCode2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExtraRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDateReceived { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOrignalAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierCreditRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboTaxCode = this.cboTaxCode;
      Combo.SetUpCombo(ref cboTaxCode, App.DB.Picklists.GetAll(Enums.PickListTypes.VATCodes, false).Table, "ManagerID", "Name", Enums.ComboValues.Dashes);
      this.cboTaxCode = cboTaxCode;
      this.PartCreditsID = Conversions.ToInteger(this.get_GetParameter(0));
      this.SetupCreditDataGrid();
    }

    public void ResetMe(int newID)
    {
    }

    private int PartCreditsID
    {
      get
      {
        return this._PartCreditsID;
      }
      set
      {
        this._PartCreditsID = value;
        this.Populate();
      }
    }

    private DataView CreditsDataview
    {
      get
      {
        return this._dvCredits;
      }
      set
      {
        this._dvCredits = value;
        this._dvCredits.AllowNew = false;
        this._dvCredits.AllowEdit = true;
        this._dvCredits.AllowDelete = false;
        this._dvCredits.Table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
        this.dgCredits.DataSource = (object) this.CreditsDataview;
      }
    }

    private DataRow SelectedCreditDataRow
    {
      get
      {
        return this.dgCredits.CurrentRowIndex != -1 ? this.CreditsDataview[this.dgCredits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupCreditDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgCredits.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Supplier";
      dataGridLabelColumn1.MappingName = "Supplier";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 140;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Order Reference";
      dataGridLabelColumn2.MappingName = "OrderReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part";
      dataGridLabelColumn3.MappingName = "Part";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 160;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Qty";
      dataGridLabelColumn4.MappingName = "Qty";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 60;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Buy Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 60;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Total Price";
      dataGridLabelColumn6.MappingName = "Total";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 60;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "C";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Credit Received";
      editableTextBoxColumn.MappingName = "CreditReceived";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 120;
      editableTextBoxColumn.NullText = "";
      editableTextBoxColumn.TextBox.TextChanged += new EventHandler(this.CreditReceived_LostFocus);
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      this.dgCredits.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblPartsToBeCredited.ToString();
      this.dgCredits.TableStyles.Add(tableStyle);
    }

    private void FRMCreditReceived_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void dgCredits_CurrentCellChanged(object sender, EventArgs e)
    {
      this.TotalAmount();
    }

    private void CreditReceived_LostFocus(object sender, EventArgs e)
    {
      this.TotalAmount();
    }

    private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Calculate_Tax();
    }

    private void Populate()
    {
      string str;
      switch (Conversions.ToString(this.PartCreditsID).Length)
      {
        case 1:
          str = "000000" + Conversions.ToString(this.PartCreditsID);
          break;
        case 2:
          str = "00000" + Conversions.ToString(this.PartCreditsID);
          break;
        case 3:
          str = "0000" + Conversions.ToString(this.PartCreditsID);
          break;
        case 4:
          str = "000" + Conversions.ToString(this.PartCreditsID);
          break;
        case 5:
          str = "00" + Conversions.ToString(this.PartCreditsID);
          break;
        case 6:
          str = "0" + Conversions.ToString(this.PartCreditsID);
          break;
        default:
          str = Conversions.ToString(this.PartCreditsID);
          break;
      }
      this.txtCreditReference.Text = str;
      this.txtNominalCode.Text = Conversions.ToString(this.get_GetParameter(1));
      this.txtDepartment.Text = Conversions.ToString(this.get_GetParameter(2));
      this.CreditsDataview = App.DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(this.PartCreditsID);
      this.TotalAmount();
      ComboBox cboTaxCode = this.cboTaxCode;
      Combo.SetSelectedComboItem_By_Value(ref cboTaxCode, Conversions.ToString(this.get_GetParameter(3)));
      this.cboTaxCode = cboTaxCode;
      this.txtExtraRef.Text = Conversions.ToString(this.get_GetParameter(4));
      this.dtpDateReceived.Value = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.get_GetParameter(5), (object) null, false) ? Conversions.ToDate(this.get_GetParameter(5)) : DateAndTime.Now;
      this.txtSupplierCreditRef.Text = Conversions.ToString(this.get_GetParameter(6));
    }

    private void TotalAmount()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.CreditsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["CreditReceived"]));
          num2 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtTotalAmount.Text = Strings.Format((object) num1, "C");
      this.txtOrignalAmount.Text = Strings.Format((object) num2, "C");
      this.Calculate_Tax();
    }

    private void Calculate_Tax()
    {
      double num = Helper.MakeDoubleValid((object) this.txtTotalAmount.Text.Replace("£", ""));
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTaxCode)) == 0.0)
      {
        this.txtVAT.Text = Strings.Format((object) 0, "C");
      }
      else
      {
        try
        {
          this.txtVAT.Text = Strings.Format((object) (num * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboTaxCode))).PercentageRate / 100.0)), "C");
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.txtVAT.Text = Strings.Format((object) 0, "C");
          ProjectData.ClearProjectError();
        }
      }
    }

    private void Save()
    {
      try
      {
        string MessageText = "";
        if (this.txtSupplierCreditRef.Text.Length == 0)
          MessageText += "Suppplier Credit Ref Missing\r\n";
        if (this.txtNominalCode.Text.Length == 0)
          MessageText += "Nominal Code Missing\r\n";
        if (this.txtDepartment.Text.Length == 0)
          MessageText += "Department Missing\r\n";
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTaxCode)) == 0.0)
          MessageText += "Tax Code Missing\r\n";
        if (Helper.MakeDoubleValid((object) this.txtTotalAmount.Text.Replace("£", "")) == 0.0)
          MessageText += "Amount must be greater than zero\r\n";
        if (MessageText.Length > 0)
        {
          int num1 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          App.DB.PartsToBeCredited.PartCredits_Update(this.PartCreditsID, Helper.MakeDoubleValid((object) this.txtTotalAmount.Text.Replace("£", "")), this.txtnotes.Text, this.dtpDateReceived.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboTaxCode)), this.txtNominalCode.Text, this.txtDepartment.Text, this.txtExtraRef.Text, this.txtSupplierCreditRef.Text);
          IEnumerator enumerator;
          try
          {
            enumerator = this.CreditsDataview.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              PartsToBeCredited beCreditedGet = App.DB.PartsToBeCredited.PartsToBeCredited_Get(Conversions.ToInteger(current["PartsToBeCreditedID"]));
              beCreditedGet.SetCreditReceived = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["CreditReceived"]));
              beCreditedGet.SetStatusID = (object) 3;
              App.DB.PartsToBeCredited.Update(beCreditedGet);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          int num2 = (int) App.ShowMessage("Credit Saved ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }
  }
}
