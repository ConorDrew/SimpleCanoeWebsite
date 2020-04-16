// Decompiled with JetBrains decompiler
// Type: FSM.FRMEquipmentUsed
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
  [DesignerGenerated]
  public class FRMEquipmentUsed : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _PartsDataview;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Sites.Site _oSite;

    public FRMEquipmentUsed()
    {
      this.Load += new EventHandler(this.FRMEngineerTimesheetReport_Load);
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
      this.Button1 = new Button();
      this.cboDepartment = new ComboBox();
      this.Label6 = new Label();
      this.cboEngineer = new ComboBox();
      this.Label5 = new Label();
      this.txtPartNameOrNumber = new TextBox();
      this.Label3 = new Label();
      this.txtJobPONo = new TextBox();
      this.Label2 = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.Label1 = new Label();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.btnExport = new Button();
      this.grpJobs = new GroupBox();
      this.dgPartsUsed = new DataGrid();
      this.btnReset = new Button();
      this.btnDelete = new Button();
      this.grpFilter.SuspendLayout();
      this.grpJobs.SuspendLayout();
      this.dgPartsUsed.BeginInit();
      this.SuspendLayout();
      this.grpFilter.Controls.Add((Control) this.Button1);
      this.grpFilter.Controls.Add((Control) this.cboDepartment);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.cboEngineer);
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.txtPartNameOrNumber);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.txtJobPONo);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Location = new System.Drawing.Point(3, 39);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(898, 158);
      this.grpFilter.TabIndex = 4;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Button1.AccessibleDescription = "Export Job List To Excel";
      this.Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Button1.Location = new System.Drawing.Point(815, (int) sbyte.MaxValue);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(68, 23);
      this.Button1.TabIndex = 19;
      this.Button1.Text = "Filter";
      this.cboDepartment.FormattingEnabled = true;
      this.cboDepartment.Location = new System.Drawing.Point(328, (int) sbyte.MaxValue);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(144, 21);
      this.cboDepartment.TabIndex = 18;
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(235, 130);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(75, 13);
      this.Label6.TabIndex = 17;
      this.Label6.Text = "Department";
      this.cboEngineer.FormattingEnabled = true;
      this.cboEngineer.Location = new System.Drawing.Point(85, (int) sbyte.MaxValue);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(144, 21);
      this.cboEngineer.TabIndex = 16;
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(8, 130);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(57, 13);
      this.Label5.TabIndex = 15;
      this.Label5.Text = "Engineer";
      this.txtPartNameOrNumber.Location = new System.Drawing.Point(328, 102);
      this.txtPartNameOrNumber.Name = "txtPartNameOrNumber";
      this.txtPartNameOrNumber.Size = new Size(144, 21);
      this.txtPartNameOrNumber.TabIndex = 14;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(235, 105);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(87, 13);
      this.Label3.TabIndex = 13;
      this.Label3.Text = "Part Name/No";
      this.txtJobPONo.Location = new System.Drawing.Point(85, 100);
      this.txtJobPONo.Name = "txtJobPONo";
      this.txtJobPONo.Size = new Size(144, 21);
      this.txtJobPONo.TabIndex = 12;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(8, 105);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(71, 13);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Job P.O. No";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(851, 71);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 10;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(85, 73);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(760, 21);
      this.txtSite.TabIndex = 9;
      this.Label1.Location = new System.Drawing.Point(8, 76);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "Site";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(851, 44);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 7;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(85, 46);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(760, 21);
      this.txtCustomer.TabIndex = 6;
      this.Label4.Location = new System.Drawing.Point(8, 49);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 5;
      this.Label4.Text = "Customer";
      this.dtpTo.Location = new System.Drawing.Point(328, 20);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(144, 21);
      this.dtpTo.TabIndex = 3;
      this.dtpFrom.Location = new System.Drawing.Point(85, 20);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(144, 21);
      this.dtpFrom.TabIndex = 1;
      this.Label9.Location = new System.Drawing.Point(298, 24);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(24, 16);
      this.Label9.TabIndex = 2;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(8, 22);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(88, 16);
      this.Label8.TabIndex = 0;
      this.Label8.Text = "Date From";
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(3, 591);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 6;
      this.btnExport.Text = "Export";
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgPartsUsed);
      this.grpJobs.Location = new System.Drawing.Point(3, 197);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(898, 386);
      this.grpJobs.TabIndex = 5;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Double Click To View / Edit";
      this.dgPartsUsed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsUsed.DataMember = "";
      this.dgPartsUsed.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsUsed.Location = new System.Drawing.Point(8, 19);
      this.dgPartsUsed.Name = "dgPartsUsed";
      this.dgPartsUsed.Size = new Size(882, 359);
      this.dgPartsUsed.TabIndex = 0;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(67, 591);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 7;
      this.btnReset.Text = "Reset";
      this.btnDelete.AccessibleDescription = "Export Job List To Excel";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(818, 591);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(68, 23);
      this.btnDelete.TabIndex = 20;
      this.btnDelete.Text = "Delete";
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ClientSize = new Size(913, 616);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.Name = nameof (FRMEquipmentUsed);
      this.Text = "Equipment Used";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnDelete, 0);
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.grpJobs.ResumeLayout(false);
      this.dgPartsUsed.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsUsed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboEngineer
    {
      get
      {
        return this._cboEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboEngineer_SelectedIndexChanged);
        ComboBox cboEngineer1 = this._cboEngineer;
        if (cboEngineer1 != null)
          cboEngineer1.SelectedIndexChanged -= eventHandler;
        this._cboEngineer = value;
        ComboBox cboEngineer2 = this._cboEngineer;
        if (cboEngineer2 == null)
          return;
        cboEngineer2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartNameOrNumber
    {
      get
      {
        return this._txtPartNameOrNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartNameOrNumber_TextChanged);
        TextBox partNameOrNumber1 = this._txtPartNameOrNumber;
        if (partNameOrNumber1 != null)
          partNameOrNumber1.TextChanged -= eventHandler;
        this._txtPartNameOrNumber = value;
        TextBox partNameOrNumber2 = this._txtPartNameOrNumber;
        if (partNameOrNumber2 == null)
          return;
        partNameOrNumber2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobPONo
    {
      get
      {
        return this._txtJobPONo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtJobPONo_TextChanged);
        TextBox txtJobPoNo1 = this._txtJobPONo;
        if (txtJobPoNo1 != null)
          txtJobPoNo1.TextChanged -= eventHandler;
        this._txtJobPONo = value;
        TextBox txtJobPoNo2 = this._txtJobPONo;
        if (txtJobPoNo2 == null)
          return;
        txtJobPoNo2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
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

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboEngineer = this.cboEngineer;
      Combo.SetUpCombo(ref cboEngineer, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.No_Filter);
      this.cboEngineer = cboEngineer;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      this.SetupPartsUsedDataGrid();
      this.ResetFilters();
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

    private DataView PartsDataview
    {
      get
      {
        return this._PartsDataview;
      }
      set
      {
        this._PartsDataview = value;
        this._PartsDataview.AllowNew = false;
        this._PartsDataview.AllowEdit = false;
        this._PartsDataview.AllowDelete = false;
        this._PartsDataview.Table.TableName = Enums.TableNames.tblPart.ToString();
        this.dgPartsUsed.DataSource = (object) this.PartsDataview;
      }
    }

    private DataRow SelectedPartDataRow
    {
      get
      {
        return this.dgPartsUsed.CurrentRowIndex != -1 ? this.PartsDataview[this.dgPartsUsed.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public FSM.Entity.Customers.Customer theCustomer
    {
      get
      {
        return this._theCustomer;
      }
      set
      {
        this._theCustomer = value;
        if (this._theCustomer != null)
        {
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
          this.theSite = (FSM.Entity.Sites.Site) null;
        }
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
          this.txtSite.Text = this.theSite.Name + ", " + this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSite.Text = "";
      }
    }

    private void SetupPartsUsedDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgPartsUsed.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Job No";
      dataGridLabelColumn1.MappingName = "JobNumber";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 60;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "PO No";
      dataGridLabelColumn2.MappingName = "PONumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 70;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Site";
      dataGridLabelColumn3.MappingName = "Site";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Customer";
      dataGridLabelColumn4.MappingName = "Customer";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Engineer";
      dataGridLabelColumn5.MappingName = "Engineer";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 90;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Buy Price";
      dataGridLabelColumn6.MappingName = "BuyPrice";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 70;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Part Name";
      dataGridLabelColumn7.MappingName = "Name";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 70;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "PartNumber";
      dataGridLabelColumn8.MappingName = "Number";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 70;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Qty";
      dataGridLabelColumn9.MappingName = "Quantity";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 35;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Visit Date";
      dataGridLabelColumn10.MappingName = "StartDateTime";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 90;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "dd/MM/yyyy";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Collection Date";
      dataGridLabelColumn11.MappingName = "CollectedOnDate";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 110;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      this.dgPartsUsed.TableStyles.Add(tableStyle);
    }

    private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if (integer > 0)
        this.theCustomer = App.DB.Customer.Customer_Get(integer);
      this.RunFilter();
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int num = this.theCustomer != null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.theCustomer.CustomerID, "", false)) : Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if (num > 0)
        this.theSite = App.DB.Sites.Get((object) num, SiteSQL.GetBy.SiteId, (object) null);
      this.RunFilter();
    }

    private void txtJobPONo_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void txtPartNameOrNumber_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboEngineer_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.PartsDataview = App.DB.EngineerVisitsPartsAndProducts.Equipment_Used_Report(Conversions.ToDate(Strings.Format((object) this.dtpFrom.Value, "dd-MMM-yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format((object) this.dtpTo.Value, "dd-MMM-yyyy") + " 23:59:59"));
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
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      this.dtpFrom.Value = DateAndTime.Today.AddMonths(-1);
      this.dtpTo.Value = DateAndTime.Today;
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      this.theSite = (FSM.Entity.Sites.Site) null;
      this.txtJobPONo.Text = "";
      this.txtPartNameOrNumber.Text = "";
      ComboBox cboEngineer = this.cboEngineer;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineer, Conversions.ToString(0));
      this.cboEngineer = cboEngineer;
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void RunFilter()
    {
      if (this.PartsDataview == null)
        return;
      string str1 = "1=1 ";
      if (this.theCustomer != null)
        str1 += " AND CustomerID = " + Conversions.ToString(this.theCustomer.CustomerID);
      if (this.theSite != null)
        str1 += " AND SiteID = " + Conversions.ToString(this.theSite.SiteID);
      if (this.txtJobPONo.Text.Length > 0)
        str1 = str1 + " AND PONumber LIKE '" + this.txtJobPONo.Text + "%'";
      if (this.txtPartNameOrNumber.Text.Length > 0)
        str1 = str1 + " AND (Name LIKE '" + this.txtPartNameOrNumber.Text + "%' OR Number LIKE'" + this.txtPartNameOrNumber.Text + "%')";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEngineer)) > 0.0)
        str1 = str1 + " AND EngineerID =" + Combo.get_GetSelectedItemValue(this.cboEngineer);
      string str2 = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
      if (Helper.IsValidInteger((object) str2) && Helper.MakeIntegerValid((object) str2) > 0)
        str1 = str1 + " AND Department = '" + str2 + "'";
      else if (!Versioned.IsNumeric((object) str2))
        str1 = str1 + " AND Department = '" + str2 + "'";
      this.PartsDataview.RowFilter = str1;
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add(new DataColumn("OrderReference"));
      datatableIn.Columns.Add(new DataColumn("JobNumber"));
      datatableIn.Columns.Add(new DataColumn("PONumber"));
      datatableIn.Columns.Add(new DataColumn("Site"));
      datatableIn.Columns.Add(new DataColumn("Customer"));
      datatableIn.Columns.Add(new DataColumn("Supplier"));
      datatableIn.Columns.Add(new DataColumn("Engineer"));
      datatableIn.Columns.Add(new DataColumn("BuyPrice"));
      datatableIn.Columns.Add(new DataColumn("SellPrice"));
      datatableIn.Columns.Add(new DataColumn("Name"));
      datatableIn.Columns.Add(new DataColumn("Number"));
      datatableIn.Columns.Add(new DataColumn("Quantity"));
      datatableIn.Columns.Add(new DataColumn("StartDateTime"));
      datatableIn.Columns.Add(new DataColumn("CollectedOnDate"));
      int num = checked (((DataView) this.dgPartsUsed.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgPartsUsed.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["OrderReference"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["OrderReference"]);
        row2["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["JobNumber"]);
        row2["PONumber"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PONumber"]);
        row2["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Site"]);
        row2["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Customer"]);
        row2["Supplier"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Supplier"]);
        row2["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Engineer"]);
        row2["BuyPrice"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["BuyPrice"]);
        row2["SellPrice"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["SellPrice"]);
        row2["Name"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Name"]);
        row2["Number"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Number"]);
        row2["Quantity"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Quantity"]);
        row2["StartDateTime"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["StartDateTime"]);
        row2["CollectedOnDate"] = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["CollectedOnDate"]);
        datatableIn.Rows.Add(row2);
        this.dgPartsUsed.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Parts Used Report", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
      this.RunFilter();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedPartDataRow["OrderReference"] != null)
      {
        try
        {
          App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE tblEquipmentCollected where EquipmentCollectedID = ", this.SelectedPartDataRow["OrderReference"])), true, false);
          int num = (int) App.ShowMessage("Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.PopulateDatagrid();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) App.ShowMessage("Error, See Rob", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        int num1 = (int) App.ShowMessage("Please select a row", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
  }
}
