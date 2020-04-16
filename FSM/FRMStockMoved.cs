// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockMoved
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
  public class FRMStockMoved : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _AuditDataview;

    public FRMStockMoved()
    {
      this.Load += new EventHandler(this.FRMStockMoved_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radBoth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radFromVan
    {
      get
      {
        return this._radFromVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radFromVan_CheckedChanged);
        RadioButton radFromVan1 = this._radFromVan;
        if (radFromVan1 != null)
          radFromVan1.CheckedChanged -= eventHandler;
        this._radFromVan = value;
        RadioButton radFromVan2 = this._radFromVan;
        if (radFromVan2 == null)
          return;
        radFromVan2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radFromWarehouse
    {
      get
      {
        return this._radFromWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radFromWarehouse_CheckedChanged);
        RadioButton radFromWarehouse1 = this._radFromWarehouse;
        if (radFromWarehouse1 != null)
          radFromWarehouse1.CheckedChanged -= eventHandler;
        this._radFromWarehouse = value;
        RadioButton radFromWarehouse2 = this._radFromWarehouse;
        if (radFromWarehouse2 == null)
          return;
        radFromWarehouse2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRun
    {
      get
      {
        return this._btnRun;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRun_Click);
        Button btnRun1 = this._btnRun;
        if (btnRun1 != null)
          btnRun1.Click -= eventHandler;
        this._btnRun = value;
        Button btnRun2 = this._btnRun;
        if (btnRun2 == null)
          return;
        btnRun2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radToVan
    {
      get
      {
        return this._radToVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radToVan_CheckedChanged);
        RadioButton radToVan1 = this._radToVan;
        if (radToVan1 != null)
          radToVan1.CheckedChanged -= eventHandler;
        this._radToVan = value;
        RadioButton radToVan2 = this._radToVan;
        if (radToVan2 == null)
          return;
        radToVan2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radToWarehouse
    {
      get
      {
        return this._radToWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radToWarehouse_CheckedChanged);
        RadioButton radToWarehouse1 = this._radToWarehouse;
        if (radToWarehouse1 != null)
          radToWarehouse1.CheckedChanged -= eventHandler;
        this._radToWarehouse = value;
        RadioButton radToWarehouse2 = this._radToWarehouse;
        if (radToWarehouse2 == null)
          return;
        radToWarehouse2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgIPTAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpAudit = new GroupBox();
      this.dgIPTAudit = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.Panel3 = new Panel();
      this.radToWarehouse = new RadioButton();
      this.radToVan = new RadioButton();
      this.Panel2 = new Panel();
      this.radFromWarehouse = new RadioButton();
      this.radFromVan = new RadioButton();
      this.Panel1 = new Panel();
      this.radParts = new RadioButton();
      this.radProducts = new RadioButton();
      this.radBoth = new RadioButton();
      this.btnRun = new Button();
      this.cboTo = new ComboBox();
      this.Label4 = new Label();
      this.cboFrom = new ComboBox();
      this.Label3 = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtReference = new TextBox();
      this.Label6 = new Label();
      this.grpAudit.SuspendLayout();
      this.dgIPTAudit.BeginInit();
      this.grpFilter.SuspendLayout();
      this.Panel3.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.SuspendLayout();
      this.grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAudit.Controls.Add((Control) this.dgIPTAudit);
      this.grpAudit.Location = new System.Drawing.Point(8, 152);
      this.grpAudit.Name = "grpAudit";
      this.grpAudit.Size = new Size(841, 278);
      this.grpAudit.TabIndex = 1;
      this.grpAudit.TabStop = false;
      this.grpAudit.Text = "IPT Audit";
      this.dgIPTAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgIPTAudit.DataMember = "";
      this.dgIPTAudit.HeaderForeColor = SystemColors.ControlText;
      this.dgIPTAudit.Location = new System.Drawing.Point(8, 19);
      this.dgIPTAudit.Name = "dgIPTAudit";
      this.dgIPTAudit.Size = new Size(825, 251);
      this.dgIPTAudit.TabIndex = 0;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 438);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.Panel3);
      this.grpFilter.Controls.Add((Control) this.Panel2);
      this.grpFilter.Controls.Add((Control) this.Panel1);
      this.grpFilter.Controls.Add((Control) this.btnRun);
      this.grpFilter.Controls.Add((Control) this.cboTo);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.cboFrom);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.txtName);
      this.grpFilter.Controls.Add((Control) this.txtNumber);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.txtReference);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Location = new System.Drawing.Point(8, 38);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(841, 108);
      this.grpFilter.TabIndex = 0;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Panel3.Controls.Add((Control) this.radToWarehouse);
      this.Panel3.Controls.Add((Control) this.radToVan);
      this.Panel3.Location = new System.Drawing.Point(442, 50);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(196, 28);
      this.Panel3.TabIndex = 27;
      this.radToWarehouse.AutoSize = true;
      this.radToWarehouse.Checked = true;
      this.radToWarehouse.Location = new System.Drawing.Point(3, 3);
      this.radToWarehouse.Name = "radToWarehouse";
      this.radToWarehouse.Size = new Size(88, 17);
      this.radToWarehouse.TabIndex = 9;
      this.radToWarehouse.TabStop = true;
      this.radToWarehouse.Text = "Warehouse";
      this.radToWarehouse.UseVisualStyleBackColor = true;
      this.radToVan.AutoSize = true;
      this.radToVan.Location = new System.Drawing.Point(98, 3);
      this.radToVan.Name = "radToVan";
      this.radToVan.Size = new Size(97, 17);
      this.radToVan.TabIndex = 10;
      this.radToVan.Text = "Stock Profile";
      this.radToVan.UseVisualStyleBackColor = true;
      this.Panel2.Controls.Add((Control) this.radFromWarehouse);
      this.Panel2.Controls.Add((Control) this.radFromVan);
      this.Panel2.Location = new System.Drawing.Point(441, 19);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(197, 26);
      this.Panel2.TabIndex = 26;
      this.radFromWarehouse.AutoSize = true;
      this.radFromWarehouse.Checked = true;
      this.radFromWarehouse.Location = new System.Drawing.Point(3, 3);
      this.radFromWarehouse.Name = "radFromWarehouse";
      this.radFromWarehouse.Size = new Size(88, 17);
      this.radFromWarehouse.TabIndex = 6;
      this.radFromWarehouse.TabStop = true;
      this.radFromWarehouse.Text = "Warehouse";
      this.radFromWarehouse.UseVisualStyleBackColor = true;
      this.radFromVan.AutoSize = true;
      this.radFromVan.Location = new System.Drawing.Point(100, 3);
      this.radFromVan.Name = "radFromVan";
      this.radFromVan.Size = new Size(97, 17);
      this.radFromVan.TabIndex = 7;
      this.radFromVan.Text = "Stock Profile";
      this.radFromVan.UseVisualStyleBackColor = true;
      this.Panel1.Controls.Add((Control) this.radParts);
      this.Panel1.Controls.Add((Control) this.radProducts);
      this.Panel1.Controls.Add((Control) this.radBoth);
      this.Panel1.Location = new System.Drawing.Point(5, 17);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(82, 82);
      this.Panel1.TabIndex = 25;
      this.radParts.AutoSize = true;
      this.radParts.Location = new System.Drawing.Point(3, 3);
      this.radParts.Name = "radParts";
      this.radParts.Size = new Size(54, 17);
      this.radParts.TabIndex = 0;
      this.radParts.Text = "Parts";
      this.radParts.UseVisualStyleBackColor = true;
      this.radProducts.AutoSize = true;
      this.radProducts.Location = new System.Drawing.Point(3, 33);
      this.radProducts.Name = "radProducts";
      this.radProducts.Size = new Size(74, 17);
      this.radProducts.TabIndex = 1;
      this.radProducts.Text = "Products";
      this.radProducts.UseVisualStyleBackColor = true;
      this.radBoth.AutoSize = true;
      this.radBoth.Checked = true;
      this.radBoth.Location = new System.Drawing.Point(3, 60);
      this.radBoth.Name = "radBoth";
      this.radBoth.Size = new Size(51, 17);
      this.radBoth.TabIndex = 2;
      this.radBoth.TabStop = true;
      this.radBoth.Text = "Both";
      this.radBoth.UseVisualStyleBackColor = true;
      this.btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRun.Location = new System.Drawing.Point(781, 78);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new Size(52, 23);
      this.btnRun.TabIndex = 12;
      this.btnRun.Text = "Run";
      this.btnRun.UseVisualStyleBackColor = true;
      this.cboTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboTo.FormattingEnabled = true;
      this.cboTo.Location = new System.Drawing.Point(644, 49);
      this.cboTo.Name = "cboTo";
      this.cboTo.Size = new Size(189, 21);
      this.cboTo.TabIndex = 11;
      this.Label4.Location = new System.Drawing.Point(358, 52);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(84, 18);
      this.Label4.TabIndex = 24;
      this.Label4.Text = "Moved To";
      this.cboFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboFrom.FormattingEnabled = true;
      this.cboFrom.Location = new System.Drawing.Point(644, 22);
      this.cboFrom.Name = "cboFrom";
      this.cboFrom.Size = new Size(189, 21);
      this.cboFrom.TabIndex = 8;
      this.Label3.Location = new System.Drawing.Point(358, 25);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(84, 18);
      this.Label3.TabIndex = 20;
      this.Label3.Text = "Moved From";
      this.txtName.Location = new System.Drawing.Point(158, 49);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(194, 21);
      this.txtName.TabIndex = 4;
      this.txtNumber.Location = new System.Drawing.Point(158, 22);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new Size(194, 21);
      this.txtNumber.TabIndex = 3;
      this.Label2.Location = new System.Drawing.Point(87, 79);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(67, 18);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Reference";
      this.Label1.Location = new System.Drawing.Point(87, 52);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Name";
      this.txtReference.Location = new System.Drawing.Point(158, 76);
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(194, 21);
      this.txtReference.TabIndex = 5;
      this.Label6.Location = new System.Drawing.Point(87, 22);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Number";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(857, 468);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpAudit);
      this.MinimumSize = new Size(873, 506);
      this.Name = nameof (FRMStockMoved);
      this.Text = "Stock Moved Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpAudit, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpAudit.ResumeLayout(false);
      this.dgIPTAudit.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.Panel3.ResumeLayout(false);
      this.Panel3.PerformLayout();
      this.Panel2.ResumeLayout(false);
      this.Panel2.PerformLayout();
      this.Panel1.ResumeLayout(false);
      this.Panel1.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
      ComboBox cboFrom = this.cboFrom;
      Combo.SetUpCombo(ref cboFrom, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Enums.ComboValues.No_Filter);
      this.cboFrom = cboFrom;
      this.cboFrom.SelectedIndex = 0;
      ComboBox cboTo = this.cboTo;
      Combo.SetUpCombo(ref cboTo, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Enums.ComboValues.No_Filter);
      this.cboTo = cboTo;
      this.cboTo.SelectedIndex = 0;
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

    private DataView AuditDataview
    {
      get
      {
        return this._AuditDataview;
      }
      set
      {
        this._AuditDataview = value;
        this._AuditDataview.AllowNew = false;
        this._AuditDataview.AllowEdit = false;
        this._AuditDataview.AllowDelete = false;
        this._AuditDataview.Table.TableName = Enums.TableNames.tblIPTAudit.ToString();
        this.dgIPTAudit.DataSource = (object) this.AuditDataview;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgIPTAudit.CurrentRowIndex != -1 ? this.AuditDataview[this.dgIPTAudit.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgIPTAudit.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 50;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Number";
      dataGridLabelColumn3.MappingName = "Number";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Reference";
      dataGridLabelColumn4.MappingName = "Reference";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Moved";
      dataGridLabelColumn5.MappingName = "Quantity";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 50;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "From";
      dataGridLabelColumn6.MappingName = "MovedFrom";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "To";
      dataGridLabelColumn7.MappingName = "MovedTo";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "By";
      dataGridLabelColumn8.MappingName = "MovedBy";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "On";
      dataGridLabelColumn9.MappingName = "MovedOn";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblIPTAudit.ToString();
      this.dgIPTAudit.TableStyles.Add(tableStyle);
    }

    private void FRMStockMoved_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void radFromWarehouse_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radFromWarehouse.Checked)
        return;
      ComboBox cboFrom = this.cboFrom;
      Combo.SetUpCombo(ref cboFrom, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Enums.ComboValues.No_Filter);
      this.cboFrom = cboFrom;
      this.cboFrom.SelectedIndex = 0;
    }

    private void radFromVan_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radFromVan.Checked)
        return;
      ComboBox cboFrom = this.cboFrom;
      Combo.SetUpCombo(ref cboFrom, App.DB.Van.Van_GetAll(false).Table, "LocationID", "Registration", Enums.ComboValues.No_Filter);
      this.cboFrom = cboFrom;
      this.cboFrom.SelectedIndex = 0;
    }

    private void radToWarehouse_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radToWarehouse.Checked)
        return;
      ComboBox cboTo = this.cboTo;
      Combo.SetUpCombo(ref cboTo, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Enums.ComboValues.No_Filter);
      this.cboTo = cboTo;
      this.cboTo.SelectedIndex = 0;
    }

    private void radToVan_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radToVan.Checked)
        return;
      ComboBox cboTo = this.cboTo;
      Combo.SetUpCombo(ref cboTo, App.DB.Van.Van_GetAll(false).Table, "LocationID", "Registration", Enums.ComboValues.No_Filter);
      this.cboTo = cboTo;
      this.cboTo.SelectedIndex = 0;
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void PopulateDatagrid()
    {
      try
      {
        string Type = "Both";
        if (this.radParts.Checked)
          Type = "Part";
        else if (this.radProducts.Checked)
          Type = "Product";
        this.AuditDataview = App.DB.Location.IPT_Audit_Get(Type, this.txtName.Text.Trim(), this.txtNumber.Text.Trim(), this.txtReference.Text.Trim(), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboFrom)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboTo)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void Export()
    {
      if (this.AuditDataview == null)
      {
        int num1 = (int) App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.AuditDataview.Table == null)
      {
        int num2 = (int) App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.AuditDataview.Table.Rows.Count == 0)
      {
        int num3 = (int) App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataTable datatableIn = new DataTable();
        datatableIn.Columns.Add("Type");
        datatableIn.Columns.Add("Name");
        datatableIn.Columns.Add("Number");
        datatableIn.Columns.Add("Reference");
        datatableIn.Columns.Add("Moved");
        datatableIn.Columns.Add("From");
        datatableIn.Columns.Add("To");
        datatableIn.Columns.Add("By");
        datatableIn.Columns.Add("On");
        int num4 = checked (((DataView) this.dgIPTAudit.DataSource).Count - 1);
        int row1 = 0;
        while (row1 <= num4)
        {
          this.dgIPTAudit.CurrentRowIndex = row1;
          DataRow row2 = datatableIn.NewRow();
          row2["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Type"]);
          row2["Name"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Name"]);
          row2["Number"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Number"]);
          row2["Reference"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Reference"]);
          row2["Moved"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Quantity"]);
          row2["From"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["MovedFrom"]);
          row2["To"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["MovedTo"]);
          row2["By"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["MovedBy"]);
          row2["On"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["MovedOn"]);
          datatableIn.Rows.Add(row2);
          this.dgIPTAudit.UnSelect(row1);
          checked { ++row1; }
        }
        Exporting exporting = new Exporting(datatableIn, "Stock Moved Report", "", "", (DataSet) null);
        exporting = (Exporting) null;
      }
    }
  }
}
