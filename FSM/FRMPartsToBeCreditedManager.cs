// Decompiled with JetBrains decompiler
// Type: FSM.FRMPartsToBeCreditedManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartTransactions;
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
  [DesignerGenerated]
  public class FRMPartsToBeCreditedManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvCredits;
    private DataView _PartsDistribution;

    public FRMPartsToBeCreditedManager()
    {
      this.Load += new EventHandler(this.FRMOrderManager_Load);
      this._PartsDistribution = (DataView) null;
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
      this.grpFilter = new GroupBox();
      this.Label5 = new Label();
      this.cboStatus = new ComboBox();
      this.txtCreditReference = new TextBox();
      this.Label4 = new Label();
      this.txtPart = new TextBox();
      this.Label3 = new Label();
      this.txtSupplier = new TextBox();
      this.Label2 = new Label();
      this.txtOrderReference = new TextBox();
      this.Label1 = new Label();
      this.grpJobs = new GroupBox();
      this.dgCredits = new DataGrid();
      this.btnReset = new Button();
      this.btnAddNew = new Button();
      this.btnGenerateCreditDocument = new Button();
      this.btnCreditAmount = new Button();
      this.grpFilter.SuspendLayout();
      this.grpJobs.SuspendLayout();
      this.dgCredits.BeginInit();
      this.SuspendLayout();
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.txtCreditReference);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.txtPart);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.txtSupplier);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.txtOrderReference);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Location = new System.Drawing.Point(12, 38);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(859, 101);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(329, 44);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(43, 13);
      this.Label5.TabIndex = 9;
      this.Label5.Text = "Status";
      this.cboStatus.FormattingEnabled = true;
      this.cboStatus.Location = new System.Drawing.Point(439, 41);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(329, 21);
      this.cboStatus.TabIndex = 0;
      this.txtCreditReference.Location = new System.Drawing.Point(439, 14);
      this.txtCreditReference.Name = "txtCreditReference";
      this.txtCreditReference.Size = new Size(206, 21);
      this.txtCreditReference.TabIndex = 8;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(329, 17);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(104, 13);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Credit Reference";
      this.txtPart.Location = new System.Drawing.Point(114, 68);
      this.txtPart.Name = "txtPart";
      this.txtPart.Size = new Size(206, 21);
      this.txtPart.TabIndex = 6;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(6, 71);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(30, 13);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Part";
      this.txtSupplier.Location = new System.Drawing.Point(114, 41);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.Size = new Size(206, 21);
      this.txtSupplier.TabIndex = 3;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 44);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(54, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Supplier";
      this.txtOrderReference.Location = new System.Drawing.Point(114, 14);
      this.txtOrderReference.Name = "txtOrderReference";
      this.txtOrderReference.Size = new Size(206, 21);
      this.txtOrderReference.TabIndex = 1;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(102, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Order Reference";
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgCredits);
      this.grpJobs.Location = new System.Drawing.Point(12, 145);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(859, 309);
      this.grpJobs.TabIndex = 2;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Double Click To View / Edit";
      this.dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCredits.DataMember = "";
      this.dgCredits.HeaderForeColor = SystemColors.ControlText;
      this.dgCredits.Location = new System.Drawing.Point(8, 20);
      this.dgCredits.Name = "dgCredits";
      this.dgCredits.Size = new Size(843, 281);
      this.dgCredits.TabIndex = 0;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(12, 460);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 3;
      this.btnReset.Text = "Reset";
      this.btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddNew.Location = new System.Drawing.Point(379, 460);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(162, 23);
      this.btnAddNew.TabIndex = 4;
      this.btnAddNew.Text = "Add New Part To Credit";
      this.btnGenerateCreditDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnGenerateCreditDocument.Location = new System.Drawing.Point(547, 460);
      this.btnGenerateCreditDocument.Name = "btnGenerateCreditDocument";
      this.btnGenerateCreditDocument.Size = new Size(176, 23);
      this.btnGenerateCreditDocument.TabIndex = 5;
      this.btnGenerateCreditDocument.Text = "Generate Credit Document";
      this.btnCreditAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreditAmount.Location = new System.Drawing.Point(729, 460);
      this.btnCreditAmount.Name = "btnCreditAmount";
      this.btnCreditAmount.Size = new Size(134, 23);
      this.btnCreditAmount.TabIndex = 0;
      this.btnCreditAmount.Text = "Add Credit Amount";
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ClientSize = new Size(883, 485);
      this.Controls.Add((Control) this.btnCreditAmount);
      this.Controls.Add((Control) this.btnGenerateCreditDocument);
      this.Controls.Add((Control) this.btnAddNew);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.Name = nameof (FRMPartsToBeCreditedManager);
      this.Text = "Parts To Be Credited Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnAddNew, 0);
      this.Controls.SetChildIndex((Control) this.btnGenerateCreditDocument, 0);
      this.Controls.SetChildIndex((Control) this.btnCreditAmount, 0);
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.grpJobs.ResumeLayout(false);
      this.dgCredits.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCredits
    {
      get
      {
        return this._dgCredits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgCredits_DoubleClick);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgCredits_MouseUp);
        DataGrid dgCredits1 = this._dgCredits;
        if (dgCredits1 != null)
        {
          dgCredits1.DoubleClick -= eventHandler;
          dgCredits1.MouseUp -= mouseEventHandler;
        }
        this._dgCredits = value;
        DataGrid dgCredits2 = this._dgCredits;
        if (dgCredits2 == null)
          return;
        dgCredits2.DoubleClick += eventHandler;
        dgCredits2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        Button btnReset1 = this._btnReset;
        if (btnReset1 != null)
          btnReset1.Click -= eventHandler;
        this._btnReset = value;
        Button btnReset2 = this._btnReset;
        if (btnReset2 == null)
          return;
        btnReset2.Click += eventHandler;
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

    internal virtual Button btnGenerateCreditDocument
    {
      get
      {
        return this._btnGenerateCreditDocument;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenerateCreditDocument_Click);
        Button generateCreditDocument1 = this._btnGenerateCreditDocument;
        if (generateCreditDocument1 != null)
          generateCreditDocument1.Click -= eventHandler;
        this._btnGenerateCreditDocument = value;
        Button generateCreditDocument2 = this._btnGenerateCreditDocument;
        if (generateCreditDocument2 == null)
          return;
        generateCreditDocument2.Click += eventHandler;
      }
    }

    internal virtual Button btnCreditAmount
    {
      get
      {
        return this._btnCreditAmount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreditAmount_Click);
        Button btnCreditAmount1 = this._btnCreditAmount;
        if (btnCreditAmount1 != null)
          btnCreditAmount1.Click -= eventHandler;
        this._btnCreditAmount = value;
        Button btnCreditAmount2 = this._btnCreditAmount;
        if (btnCreditAmount2 == null)
          return;
        btnCreditAmount2.Click += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus
    {
      get
      {
        return this._cboStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboStatus_SelectedIndexChanged);
        ComboBox cboStatus1 = this._cboStatus;
        if (cboStatus1 != null)
          cboStatus1.SelectedIndexChanged -= eventHandler;
        this._cboStatus = value;
        ComboBox cboStatus2 = this._cboStatus;
        if (cboStatus2 == null)
          return;
        cboStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtCreditReference
    {
      get
      {
        return this._txtCreditReference;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtCreditReference_TextChanged);
        TextBox txtCreditReference1 = this._txtCreditReference;
        if (txtCreditReference1 != null)
          txtCreditReference1.TextChanged -= eventHandler;
        this._txtCreditReference = value;
        TextBox txtCreditReference2 = this._txtCreditReference;
        if (txtCreditReference2 == null)
          return;
        txtCreditReference2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPart
    {
      get
      {
        return this._txtPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPart_TextChanged);
        TextBox txtPart1 = this._txtPart;
        if (txtPart1 != null)
          txtPart1.TextChanged -= eventHandler;
        this._txtPart = value;
        TextBox txtPart2 = this._txtPart;
        if (txtPart2 == null)
          return;
        txtPart2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplier
    {
      get
      {
        return this._txtSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtSupplier_TextChanged);
        TextBox txtSupplier1 = this._txtSupplier;
        if (txtSupplier1 != null)
          txtSupplier1.TextChanged -= eventHandler;
        this._txtSupplier = value;
        TextBox txtSupplier2 = this._txtSupplier;
        if (txtSupplier2 == null)
          return;
        txtSupplier2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOrderReference
    {
      get
      {
        return this._txtOrderReference;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtOrderReference_TextChanged);
        TextBox txtOrderReference1 = this._txtOrderReference;
        if (txtOrderReference1 != null)
          txtOrderReference1.TextChanged -= eventHandler;
        this._txtOrderReference = value;
        TextBox txtOrderReference2 = this._txtOrderReference;
        if (txtOrderReference2 == null)
          return;
        txtOrderReference2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.CreatePartsAndProductsDistribution();
      this.SetupCreditDataGrid();
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.CreditStatus, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      this.ResetFilters();
      this.PopulateDatagrid();
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
        this._dvCredits.AllowEdit = false;
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

    public DataView PartsDistribution
    {
      get
      {
        return this._PartsDistribution;
      }
      set
      {
        this._PartsDistribution = value;
      }
    }

    private void SetupCreditDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgCredits.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Supplier";
      dataGridLabelColumn1.MappingName = "Supplier";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 180;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Order Ref";
      dataGridLabelColumn2.MappingName = "OrderReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 90;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part";
      dataGridLabelColumn3.MappingName = "Part";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 270;
      dataGridLabelColumn3.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Qty";
      dataGridLabelColumn4.MappingName = "Qty";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 40;
      dataGridLabelColumn4.NullText = "";
      dataGridLabelColumn4.Alignment = HorizontalAlignment.Center;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Status";
      dataGridLabelColumn5.MappingName = "Status";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 200;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Manually Added";
      dataGridLabelColumn6.MappingName = "ManuallyAdded";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 60;
      dataGridLabelColumn6.NullText = "";
      dataGridLabelColumn6.Alignment = HorizontalAlignment.Center;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Credit Ref";
      dataGridLabelColumn7.MappingName = "CreditReference";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 90;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Date Created";
      dataGridLabelColumn8.MappingName = "DateCreated";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 120;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPartsToBeCredited.ToString();
      this.dgCredits.TableStyles.Add(tableStyle);
    }

    private void FRMOrderManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnGenerateCreditDocument_Click(object sender, EventArgs e)
    {
      try
      {
        int num1 = 0;
        string str = "";
        int num2 = 0;
        int num3 = 0;
        ArrayList arrayList = new ArrayList();
        string MessageText = "The following credits could not be generated as incorrect status<br>";
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.CreditsDataview.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRowView current1 = (DataRowView) enumerator1.Current;
            if (Conversions.ToBoolean(current1["Tick"]) & Conversions.ToInteger(current1["StatusID"]) == 2)
            {
              checked { ++num2; }
              if (num1 == 0)
                num1 = Conversions.ToInteger(current1["SupplierID"]);
              int PartCreditID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["PartCreditsID"]));
              str = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["creditReference"]));
              if (PartCreditID == 0)
              {
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = this.CreditsDataview.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRowView current2 = (DataRowView) enumerator2.Current;
                    if (Conversions.ToBoolean(current2["Tick"]) && Conversions.ToBoolean(current2["ManuallyAdded"]) && !this.PartLocation(current2.Row))
                    {
                      int num4 = (int) App.ShowMessage("Generation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                      return;
                    }
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                IEnumerator enumerator3;
                try
                {
                  enumerator3 = this.PartsDistribution.Table.Rows.GetEnumerator();
                  while (enumerator3.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator3.Current;
                    App.DB.PartTransaction.Insert(new PartTransaction()
                    {
                      SetLocationID = RuntimeHelpers.GetObjectValue(current2["LocationID"]),
                      SetPartID = RuntimeHelpers.GetObjectValue(current2["PartProductID"]),
                      SetOrderPartID = RuntimeHelpers.GetObjectValue(current2["OrderPartProductID"]),
                      SetAmount = Conversions.ToInteger(current2["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(current2["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current2["Quantity"], (object) -1),
                      SetTransactionTypeID = RuntimeHelpers.GetObjectValue(current2["StockTransactionType"])
                    });
                  }
                }
                finally
                {
                  if (enumerator3 is IDisposable)
                    (enumerator3 as IDisposable).Dispose();
                }
                switch (Conversions.ToString(PartCreditID).Length)
                {
                  case 1:
                    str = "000000" + Conversions.ToString(PartCreditID);
                    break;
                  case 2:
                    str = "00000" + Conversions.ToString(PartCreditID);
                    break;
                  case 3:
                    str = "0000" + Conversions.ToString(PartCreditID);
                    break;
                  case 4:
                    str = "000" + Conversions.ToString(PartCreditID);
                    break;
                  case 5:
                    str = "00" + Conversions.ToString(PartCreditID);
                    break;
                  case 6:
                    str = "0" + Conversions.ToString(PartCreditID);
                    break;
                  default:
                    str = Conversions.ToString(PartCreditID);
                    break;
                }
              }
              else
                arrayList.Add((object) App.DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(PartCreditID).Table);
            }
            else if (Conversions.ToBoolean(current1["Tick"]) & Conversions.ToInteger(current1["StatusID"]) != 2)
            {
              checked { ++num3; }
              MessageText = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) MessageText, current1["CreditReference"]), (object) "<br>"));
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (num2 == 0)
        {
          int num5 = (int) App.ShowMessage("No items selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          if (num1 == 24)
          {
            Printing printing1 = new Printing((object) arrayList, "Alpha Part Credit", Enums.SystemDocumentType.AlphaPartCredit, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
          else
          {
            Printing printing2 = new Printing((object) arrayList, "Part Credit", Enums.SystemDocumentType.PartCredit, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
          if (App.ShowMessage("Do you want to update these to 'Credit Req Sent to Supplier' Status?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.CreditsDataview.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator2.Current;
              if (Conversions.ToBoolean(current["Tick"]))
              {
                PartsToBeCredited beCreditedGet = App.DB.PartsToBeCredited.PartsToBeCredited_Get(Conversions.ToInteger(current["PartsToBeCreditedID"]));
                beCreditedGet.SetStatusID = (object) 3;
                App.DB.PartsToBeCredited.Update(beCreditedGet);
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          this.PopulateDatagrid();
        }
        if (num3 > 1)
        {
          int num6 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnCreditAmount_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        IEnumerator enumerator;
        if (this.CreditsDataview != null)
        {
          try
          {
            enumerator = this.CreditsDataview.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
              ((DataRow) enumerator.Current)["Tick"] = (object) false;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        if (this.SelectedCreditDataRow != null)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedCreditDataRow["StatusID"], (object) 1, false))
          {
            int num1 = (int) App.ShowMessage("Parts must be returned before credit can be received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedCreditDataRow["StatusID"], (object) 4, false))
          {
            int num2 = (int) App.ShowMessage("Credit Details sent to Sage.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else
            App.ShowForm(typeof (FRMCreditReceived), true, new object[7]
            {
              this.SelectedCreditDataRow["PartCreditsID"],
              (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["NominalCode"])),
              (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["DepartmentRef"])),
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["TaxCodeID"])),
              (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["ExtraRef"])),
              (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["DateReceived"])),
              (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["SupplierCreditRef"]))
            }, false);
        }
        this.PopulateDatagrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMPartsToBeCredited), true, new object[1]
      {
        (object) 0
      }, false);
      this.PopulateDatagrid();
    }

    private void dgCredits_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedCreditDataRow == null)
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedCreditDataRow["ManuallyAdded"], (object) true, false))
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(this.SelectedCreditDataRow["StatusID"], (object) 2, false))
        {
          App.ShowForm(typeof (FRMPartsToBeCredited), true, new object[1]
          {
            this.SelectedCreditDataRow["PartsToBeCreditedID"]
          }, false);
        }
        else
        {
          int num1 = (int) App.ShowMessage("This part has been returned and cannot be edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        int num2 = (int) App.ShowMessage("Only manually added parts can be edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void dgCredits_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgCredits.HitTest(e.X, e.Y);
      if (hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != 0)
        return;
      this.SelectedCreditDataRow["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedCreditDataRow["tick"]));
    }

    private void txtOrderReference_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtSupplier_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtPart_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtCreditReference_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.CreditsDataview = App.DB.PartsToBeCredited.PartsToBeCredited_GetAll();
        this.RunFilter();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetFilters()
    {
      IEnumerator enumerator;
      if (this.CreditsDataview != null)
      {
        try
        {
          enumerator = this.CreditsDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
            ((DataRow) enumerator.Current)["Tick"] = (object) false;
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this.txtOrderReference.Text = "";
      this.txtSupplier.Text = "";
      this.txtPart.Text = "";
      this.txtCreditReference.Text = "";
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
    }

    private void RunFilter()
    {
      if (this.CreditsDataview == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.CreditsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      string str = " 1 = 1 ";
      if (this.txtOrderReference.Text.Length > 0)
        str = str + " AND OrderReference LIKE '%" + this.txtOrderReference.Text + "%'";
      if (this.txtSupplier.Text.Length > 0)
        str = str + " AND Supplier LIKE '" + this.txtSupplier.Text + "%'";
      if (this.txtCreditReference.Text.Length > 0)
        str = str + " AND CreditReference LIKE '" + this.txtCreditReference.Text + "%'";
      if (this.txtPart.Text.Length > 0)
        str = str + " AND Part LIKE '%" + this.txtPart.Text + "%'";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) > 0.0)
        str = str + " AND StatusID = " + Combo.get_GetSelectedItemValue(this.cboStatus);
      this.CreditsDataview.RowFilter = str;
    }

    private void CreatePartsAndProductsDistribution()
    {
      this.PartsDistribution = new DataView(new DataTable()
      {
        Columns = {
          "Type",
          "DistributedID",
          "LocationID",
          "AllocatedID",
          "Other",
          "Quantity",
          "PartProductID",
          "OrderPartProductID",
          "StockTransactionType"
        }
      });
    }

    private bool PartLocation(DataRow dr)
    {
      FRMDistributeAllocated distributeAllocated = new FRMDistributeAllocated(true, Conversions.ToInteger(dr["Qty"]), Conversions.ToString(dr["Part"]), "Part", Conversions.ToInteger(dr["PartID"]), new ArrayList());
      if (distributeAllocated.ShowDialog() != DialogResult.OK)
        return false;
      IEnumerator enumerator;
      try
      {
        enumerator = distributeAllocated.Locations.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Quantity"], (object) 0, false))
          {
            DataRow row = this.PartsDistribution.Table.NewRow();
            row["Type"] = (object) "Part";
            row["DistributedID"] = (object) 0;
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["AllocatedID"] = RuntimeHelpers.GetObjectValue(current["AllocatedID"]);
            row["Other"] = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["LocationID"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AllocatedID"], (object) 0, false))) ? (object) false : (object) true;
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(dr["PartID"]);
            row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]);
            row["StockTransactionType"] = RuntimeHelpers.GetObjectValue(current["StockTransactionType"]);
            this.PartsDistribution.Table.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return true;
    }
  }
}
