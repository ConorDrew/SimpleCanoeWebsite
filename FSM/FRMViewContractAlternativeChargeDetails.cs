// Decompiled with JetBrains decompiler
// Type: FSM.FRMViewContractAlternativeChargeDetails
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class FRMViewContractAlternativeChargeDetails : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _ScheduleOfRatesDataview;

    public FRMViewContractAlternativeChargeDetails()
    {
      this.Load += new EventHandler(this.FRMViewContractAlternativeChargeDetails_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageCostPerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAverageMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCostPerMile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkIncludeMileage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRatesTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDone
    {
      get
      {
        return this._btnDone;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDone_Click);
        Button btnDone1 = this._btnDone;
        if (btnDone1 != null)
          btnDone1.Click -= eventHandler;
        this._btnDone = value;
        Button btnDone2 = this._btnDone;
        if (btnDone2 == null)
          return;
        btnDone2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.Label1 = new Label();
      this.dgScheduleOfRates = new DataGrid();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.txtMileageCostPerVisit = new TextBox();
      this.txtAverageMileage = new TextBox();
      this.txtCostPerMile = new TextBox();
      this.Label8 = new Label();
      this.txtRatesTotal = new TextBox();
      this.chkRates = new CheckBox();
      this.chkIncludeMileage = new CheckBox();
      this.btnDone = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgScheduleOfRates.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.dgScheduleOfRates);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.txtMileageCostPerVisit);
      this.GroupBox1.Controls.Add((Control) this.txtAverageMileage);
      this.GroupBox1.Controls.Add((Control) this.txtCostPerMile);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.txtRatesTotal);
      this.GroupBox1.Controls.Add((Control) this.chkRates);
      this.GroupBox1.Controls.Add((Control) this.chkIncludeMileage);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(688, 240);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Charge Information";
      this.Label1.Location = new System.Drawing.Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(144, 24);
      this.Label1.TabIndex = 80;
      this.Label1.Text = "Schedule Of Rates";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgScheduleOfRates.DataMember = "";
      this.dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRates.Location = new System.Drawing.Point(8, 44);
      this.dgScheduleOfRates.Name = "dgScheduleOfRates";
      this.dgScheduleOfRates.Size = new Size(672, 113);
      this.dgScheduleOfRates.TabIndex = 79;
      this.Label5.Enabled = false;
      this.Label5.Location = new System.Drawing.Point(112, 208);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(104, 23);
      this.Label5.TabIndex = 78;
      this.Label5.Text = "Mileage Per Visit";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.Label4.Enabled = false;
      this.Label4.Location = new System.Drawing.Point(296, 208);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(98, 23);
      this.Label4.TabIndex = 77;
      this.Label4.Text = "Price Per Mile";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.Enabled = false;
      this.Label3.Location = new System.Drawing.Point(464, 208);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(144, 23);
      this.Label3.TabIndex = 76;
      this.Label3.Text = "= Mileage Price Per Visit";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMileageCostPerVisit.Enabled = false;
      this.txtMileageCostPerVisit.Location = new System.Drawing.Point(608, 208);
      this.txtMileageCostPerVisit.Name = "txtMileageCostPerVisit";
      this.txtMileageCostPerVisit.Size = new Size(72, 21);
      this.txtMileageCostPerVisit.TabIndex = 74;
      this.txtAverageMileage.Enabled = false;
      this.txtAverageMileage.Location = new System.Drawing.Point(232, 208);
      this.txtAverageMileage.Name = "txtAverageMileage";
      this.txtAverageMileage.Size = new Size(58, 21);
      this.txtAverageMileage.TabIndex = 73;
      this.txtAverageMileage.Text = "0";
      this.txtCostPerMile.Enabled = false;
      this.txtCostPerMile.Location = new System.Drawing.Point(400, 208);
      this.txtCostPerMile.Name = "txtCostPerMile";
      this.txtCostPerMile.Size = new Size(58, 21);
      this.txtCostPerMile.TabIndex = 72;
      this.txtCostPerMile.Text = "£0.00";
      this.Label8.Enabled = false;
      this.Label8.Location = new System.Drawing.Point(520, 160);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(87, 24);
      this.Label8.TabIndex = 71;
      this.Label8.Text = "Rate Total:";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      this.txtRatesTotal.Enabled = false;
      this.txtRatesTotal.Location = new System.Drawing.Point(608, 162);
      this.txtRatesTotal.MaxLength = 50;
      this.txtRatesTotal.Name = "txtRatesTotal";
      this.txtRatesTotal.Size = new Size(72, 21);
      this.txtRatesTotal.TabIndex = 70;
      this.txtRatesTotal.Tag = (object) "SystemScheduleOfRate.Code";
      this.chkRates.Enabled = false;
      this.chkRates.Location = new System.Drawing.Point(8, 158);
      this.chkRates.Name = "chkRates";
      this.chkRates.Size = new Size(176, 25);
      this.chkRates.TabIndex = 69;
      this.chkRates.Text = "Include Rates in Visit Total";
      this.chkIncludeMileage.Enabled = false;
      this.chkIncludeMileage.Location = new System.Drawing.Point(8, 184);
      this.chkIncludeMileage.Name = "chkIncludeMileage";
      this.chkIncludeMileage.Size = new Size(192, 23);
      this.chkIncludeMileage.TabIndex = 75;
      this.chkIncludeMileage.Text = "Include Mileage in Visit Total";
      this.btnDone.UseVisualStyleBackColor = true;
      this.btnDone.Location = new System.Drawing.Point(600, 288);
      this.btnDone.Name = "btnDone";
      this.btnDone.Size = new Size(90, 25);
      this.btnDone.TabIndex = 1;
      this.btnDone.Text = "Done";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(704, 318);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnDone);
      this.Name = nameof (FRMViewContractAlternativeChargeDetails);
      this.Text = "Job Item Charges";
      this.Controls.SetChildIndex((Control) this.btnDone, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.dgScheduleOfRates.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupScheduleOfRatesDataGrid();
      this.ScheduleOfRatesDataview = App.DB.ContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))));
      this.chkIncludeMileage.Checked = Conversions.ToBoolean(this.get_GetParameter(1));
      this.chkRates.Checked = Conversions.ToBoolean(this.get_GetParameter(2));
      this.txtAverageMileage.Text = Conversions.ToString(this.get_GetParameter(3));
      this.txtCostPerMile.Text = Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(4))), "C");
      this.CalculateRates();
      this.CalculateMileageTotal();
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

    private DataView ScheduleOfRatesDataview
    {
      get
      {
        return this._ScheduleOfRatesDataview;
      }
      set
      {
        this._ScheduleOfRatesDataview = value;
        this._ScheduleOfRatesDataview.Table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
        this._ScheduleOfRatesDataview.AllowNew = false;
        this._ScheduleOfRatesDataview.AllowEdit = true;
        this._ScheduleOfRatesDataview.AllowDelete = false;
        this.dgScheduleOfRates.DataSource = (object) this.ScheduleOfRatesDataview;
      }
    }

    public void SetupScheduleOfRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRates, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRates.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Qty Per Visit";
      dataGridLabelColumn5.MappingName = "QtyPerVisit";
      dataGridLabelColumn5.ReadOnly = false;
      dataGridLabelColumn5.Width = 85;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
      this.dgScheduleOfRates.TableStyles.Add(tableStyle);
    }

    private void FRMViewContractAlternativeChargeDetails_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnDone_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void CalculateRates()
    {
      Decimal num = new Decimal();
      IEnumerator enumerator;
      try
      {
        enumerator = this.ScheduleOfRatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Price"], current["QtyPerVisit"])));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtRatesTotal.Text = Strings.Format((object) num, "C");
    }

    private void CalculateMileageTotal()
    {
      this.txtMileageCostPerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtAverageMileage.Text) * Helper.MakeDoubleValid((object) this.txtCostPerMile.Text.Replace("£", ""))), "C");
    }
  }
}
