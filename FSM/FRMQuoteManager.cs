// Decompiled with JetBrains decompiler
// Type: FSM.FRMQuoteManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
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
  public class FRMQuoteManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvQuotes;
    private FSM.Entity.Customers.Customer _oCustomer;
    private FSM.Entity.Sites.Site _oSite;

    public FRMQuoteManager()
    {
      this.Load += new EventHandler(this.FRMQuoteManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo
    {
      get
      {
        return this._dtpTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpTo_ValueChanged);
        DateTimePicker dtpTo1 = this._dtpTo;
        if (dtpTo1 != null)
          dtpTo1.ValueChanged -= eventHandler;
        this._dtpTo = value;
        DateTimePicker dtpTo2 = this._dtpTo;
        if (dtpTo2 == null)
          return;
        dtpTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFrom
    {
      get
      {
        return this._dtpFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFrom_ValueChanged);
        DateTimePicker dtpFrom1 = this._dtpFrom;
        if (dtpFrom1 != null)
          dtpFrom1.ValueChanged -= eventHandler;
        this._dtpFrom = value;
        DateTimePicker dtpFrom2 = this._dtpFrom;
        if (dtpFrom2 == null)
          return;
        dtpFrom2.ValueChanged += eventHandler;
      }
    }

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

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGrid dgQuotes
    {
      get
      {
        return this._dgQuotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgQuotes_DoubleClick);
        DataGrid dgQuotes1 = this._dgQuotes;
        if (dgQuotes1 != null)
          dgQuotes1.DoubleClick -= eventHandler;
        this._dgQuotes = value;
        DataGrid dgQuotes2 = this._dgQuotes;
        if (dgQuotes2 == null)
          return;
        dgQuotes2.DoubleClick += eventHandler;
      }
    }

    internal virtual TextBox txtReference
    {
      get
      {
        return this._txtReference;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtReference_TextChanged);
        TextBox txtReference1 = this._txtReference;
        if (txtReference1 != null)
          txtReference1.TextChanged -= eventHandler;
        this._txtReference = value;
        TextBox txtReference2 = this._txtReference;
        if (txtReference2 == null)
          return;
        txtReference2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkQuoteDate
    {
      get
      {
        return this._chkQuoteDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkQuoteDate_CheckedChanged);
        CheckBox chkQuoteDate1 = this._chkQuoteDate;
        if (chkQuoteDate1 != null)
          chkQuoteDate1.CheckedChanged -= eventHandler;
        this._chkQuoteDate = value;
        CheckBox chkQuoteDate2 = this._chkQuoteDate;
        if (chkQuoteDate2 == null)
          return;
        chkQuoteDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgQuotes = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label1 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtReference = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkQuoteDate = new CheckBox();
      this.Label6 = new Label();
      this.Label2 = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboStatus = new ComboBox();
      this.btnReset = new Button();
      this.grpJobs.SuspendLayout();
      this.dgQuotes.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgQuotes);
      this.grpJobs.Location = new System.Drawing.Point(8, 232);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(784, 224);
      this.grpJobs.TabIndex = 2;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Double Click To View / Edit";
      this.dgQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgQuotes.DataMember = "";
      this.dgQuotes.HeaderForeColor = SystemColors.ControlText;
      this.dgQuotes.Location = new System.Drawing.Point(8, 27);
      this.dgQuotes.Name = "dgQuotes";
      this.dgQuotes.Size = new Size(768, 189);
      this.dgQuotes.TabIndex = 9;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 464);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 10;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtReference);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkQuoteDate);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Location = new System.Drawing.Point(8, 40);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(784, 184);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(736, 88);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 15;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(104, 88);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(624, 21);
      this.txtSite.TabIndex = 14;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(736, 56);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 13;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(104, 56);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(624, 21);
      this.txtCustomer.TabIndex = 12;
      this.Label1.Location = new System.Drawing.Point(8, 56);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 11;
      this.Label1.Text = "Customer";
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpTo.Location = new System.Drawing.Point(592, 152);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(184, 21);
      this.dtpTo.TabIndex = 8;
      this.dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFrom.Location = new System.Drawing.Point(592, 121);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(184, 21);
      this.dtpFrom.TabIndex = 7;
      this.txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtReference.Location = new System.Drawing.Point(104, 121);
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(312, 21);
      this.txtReference.TabIndex = 4;
      this.Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label9.Location = new System.Drawing.Point(536, 153);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.Location = new System.Drawing.Point(536, 121);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkQuoteDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkQuoteDate.Cursor = Cursors.Hand;
      this.chkQuoteDate.UseVisualStyleBackColor = true;
      this.chkQuoteDate.Location = new System.Drawing.Point(424, 121);
      this.chkQuoteDate.Name = "chkQuoteDate";
      this.chkQuoteDate.Size = new Size(104, 24);
      this.chkQuoteDate.TabIndex = 6;
      this.chkQuoteDate.Text = "Quote Date";
      this.Label6.Location = new System.Drawing.Point(8, 120);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Reference";
      this.Label2.Location = new System.Drawing.Point(8, 88);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Property";
      this.Label10.Location = new System.Drawing.Point(8, 24);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 16);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(104, 25);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(312, 21);
      this.cboType.TabIndex = 1;
      this.Label11.Location = new System.Drawing.Point(8, 152);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 16);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(104, 153);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(312, 21);
      this.cboStatus.TabIndex = 5;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 464);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 11;
      this.btnReset.Text = "Reset";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 494);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMQuoteManager);
      this.Text = "Quote Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgQuotes.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupQuotesDataGrid();
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

    private DataView QuotesDataview
    {
      get
      {
        return this._dvQuotes;
      }
      set
      {
        this._dvQuotes = value;
        this._dvQuotes.AllowNew = false;
        this._dvQuotes.AllowEdit = false;
        this._dvQuotes.AllowDelete = false;
        this._dvQuotes.Table.TableName = Enums.TableNames.tblQuotes.ToString();
        this.dgQuotes.DataSource = (object) this.QuotesDataview;
      }
    }

    private DataRow SelectedQuoteDataRow
    {
      get
      {
        return this.dgQuotes.CurrentRowIndex != -1 ? this.QuotesDataview[this.dgQuotes.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._oCustomer;
      }
      set
      {
        this._oCustomer = value;
        if (this._oCustomer != null)
          this.txtCustomer.Text = this.Customer.Name + " ( " + this.Customer.AccountNumber + ") ";
        else
          this.txtCustomer.Text = "";
      }
    }

    public FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._oSite;
      }
      set
      {
        this._oSite = value;
        if (this._oSite != null)
          this.txtSite.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSite.Text = "";
      }
    }

    private void SetupQuotesDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgQuotes.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Quote Type";
      dataGridLabelColumn1.MappingName = "QuoteType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 80;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Customer";
      dataGridLabelColumn2.MappingName = "Customer";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Property";
      dataGridLabelColumn3.MappingName = "Site";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Postcode";
      dataGridLabelColumn4.MappingName = "SitePostcode";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Reference";
      dataGridLabelColumn5.MappingName = "Reference";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 120;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Quote Date";
      dataGridLabelColumn6.MappingName = "QuoteDate";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 80;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Price";
      dataGridLabelColumn7.MappingName = "Price";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 85;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Status";
      dataGridLabelColumn8.MappingName = "Status";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Rejected Reason";
      dataGridLabelColumn9.MappingName = "RejectedReason";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 150;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Converted";
      dataGridLabelColumn10.MappingName = "Converted";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 50;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Converted JobNumber";
      dataGridLabelColumn11.MappingName = "ConvertedJN";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 100;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblQuotes.ToString();
      this.dgQuotes.TableStyles.Add(tableStyle);
    }

    private void FRMQuoteManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void chkQuoteDate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkQuoteDate.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today;
        this.dtpTo.Value = DateAndTime.Today;
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
      this.RunFilter();
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 1)
      {
        this.btnFindCustomer.Enabled = true;
        this.btnFindSite.Enabled = false;
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 3)
      {
        this.btnFindSite.Enabled = true;
        this.btnFindCustomer.Enabled = false;
      }
      this.RunFilter();
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Customer = App.DB.Customer.Customer_Get(integer);
      this.RunFilter();
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theSite = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
      this.RunFilter();
    }

    private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtReference_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void dtpTo_ValueChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void dgQuotes_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedQuoteDataRow == null)
        return;
      object Left1 = this.SelectedQuoteDataRow["QuoteType"];
      Enums.QuoteType quoteType = Enums.QuoteType.Contract_Opt_3;
      string str1 = quoteType.ToString();
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left1, (object) str1, false))
      {
        App.ShowForm(typeof (FRMQuoteContractOption3), true, new object[2]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])),
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["IDToLinkTo"]))
        }, false);
      }
      else
      {
        object Left2 = this.SelectedQuoteDataRow["QuoteType"];
        quoteType = Enums.QuoteType.Job;
        string str2 = quoteType.ToString();
        if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, (object) str2, false))
          return;
        App.ShowForm(typeof (FRMQuoteJob), true, new object[2]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])),
          this.SelectedQuoteDataRow["IDToLinkTo"]
        }, false);
      }
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.ResetFilters();
        if (this.get_GetParameter(0) == null)
        {
          this.ResetFilters();
        }
        else
        {
          this.QuotesDataview = (DataView) this.get_GetParameter(0);
          this.grpFilter.Enabled = false;
        }
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
      this.QuotesDataview = App.DB.Quotes.QuotesGet_All();
      this.theSite = (FSM.Entity.Sites.Site) null;
      this.Customer = (FSM.Entity.Customers.Customer) null;
      DataTable DT = new DataTable();
      DT.Columns.Add(new DataColumn("ValueMember"));
      DT.Columns.Add(new DataColumn("DisplayMember"));
      DataRow row1 = DT.NewRow();
      row1["ValueMember"] = (object) 3;
      row1["DisplayMember"] = (object) "Jobs";
      DT.Rows.Add(row1);
      DataRow row2 = DT.NewRow();
      row2["ValueMember"] = (object) 1;
      row2["DisplayMember"] = (object) "Contracts";
      DT.Rows.Add(row2);
      ComboBox cboType1 = this.cboType;
      Combo.SetUpCombo(ref cboType1, DT, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboType = cboType1;
      ComboBox cboType2 = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType2, Conversions.ToString(3));
      this.cboType = cboType2;
      ComboBox cboStatus1 = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus1, App.DB.Picklists.GetAll(Enums.PickListTypes.Quote_Status, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboStatus = cboStatus1;
      ComboBox cboStatus2 = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus2, Conversions.ToString(0));
      this.cboStatus = cboStatus2;
      this.txtReference.Text = "";
      this.chkQuoteDate.Checked = false;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = false;
      this.dtpTo.Enabled = false;
      this.grpFilter.Enabled = true;
    }

    private void RunFilter()
    {
      string str = "";
      if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 1)
      {
        str += " QuoteType <> 'Job'";
        if (this.Customer != null)
          str += " AND CustomerID = " + Conversions.ToString(this.Customer.CustomerID);
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 3)
      {
        str += " QuoteType = 'Job'";
        if (this.theSite != null)
          str += " AND SiteID = " + Conversions.ToString(this.theSite.SiteID);
      }
      if ((uint) this.txtReference.Text.Trim().Length > 0U)
        str = str + " AND Reference LIKE '" + this.txtReference.Text.Trim() + "%'";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
        str += " AND StatusID = " + Combo.get_GetSelectedItemValue(this.cboStatus);
      if (this.chkQuoteDate.Checked)
        str = str + " AND QuoteDate >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND QuoteDate <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      this.QuotesDataview.RowFilter = str;
      this.grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", (object) this.QuotesDataview.Count);
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("QuoteType");
      datatableIn.Columns.Add("Customer");
      datatableIn.Columns.Add("Site");
      datatableIn.Columns.Add("SitePostcode");
      datatableIn.Columns.Add("Reference");
      datatableIn.Columns.Add("QuoteDate");
      datatableIn.Columns.Add("Price", typeof (double));
      datatableIn.Columns.Add("Status");
      datatableIn.Columns.Add("RejectedReason");
      int num = checked (((DataView) this.dgQuotes.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgQuotes.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["QuoteType"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteType"]);
        row2["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["Customer"]);
        row2["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["Site"]);
        row2["SitePostcode"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["SitePostcode"]);
        row2["Reference"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["Reference"]);
        row2["QuoteDate"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteDate"]);
        row2["Price"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["Price"]);
        row2["Status"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["Status"]);
        row2["RejectedReason"] = RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["RejectedReason"]);
        datatableIn.Rows.Add(row2);
        this.dgQuotes.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Quote List", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
