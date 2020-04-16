// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangeVAT
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Invoiceds;
using FSM.Entity.Sys;
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
  public class FRMChangeVAT : Form
  {
    private IContainer components;
    private int _InvoicedID;
    private DataView _dvRates;

    public FRMChangeVAT(int CurrentRateID, int InvoicedIDin, string InvNumber)
    {
      this.InitializeComponent();
      this.SetupRatesDataGrid();
      this.GroupBox1.Text = string.Format(this.GroupBox1.Text, (object) InvNumber);
      this.InvoicedID = InvoicedIDin;
      this.Populate(CurrentRateID);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSetRate
    {
      get
      {
        return this._btnSetRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSetRate_Click);
        Button btnSetRate1 = this._btnSetRate;
        if (btnSetRate1 != null)
          btnSetRate1.Click -= eventHandler;
        this._btnSetRate = value;
        Button btnSetRate2 = this._btnSetRate;
        if (btnSetRate2 == null)
          return;
        btnSetRate2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.dgRates = new DataGrid();
      this.btnSetRate = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgRates.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgRates);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(272, 224);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Select A VAT Rate for {0}";
      this.dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgRates.DataMember = "";
      this.dgRates.HeaderForeColor = SystemColors.ControlText;
      this.dgRates.Location = new System.Drawing.Point(8, 16);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(256, 192);
      this.dgRates.TabIndex = 0;
      this.btnSetRate.UseVisualStyleBackColor = true;
      this.btnSetRate.Location = new System.Drawing.Point(112, 240);
      this.btnSetRate.Name = "btnSetRate";
      this.btnSetRate.TabIndex = 1;
      this.btnSetRate.Text = "Set Rate";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(288, 266);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnSetRate);
      this.Controls.Add((Control) this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximumSize = new Size(294, 298);
      this.MinimumSize = new Size(294, 298);
      this.Name = nameof (FRMChangeVAT);
      this.Text = "Change VAT Rate";
      this.GroupBox1.ResumeLayout(false);
      this.dgRates.EndInit();
      this.ResumeLayout(false);
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
      }
    }

    private DataView RatesDataview
    {
      get
      {
        return this._dvRates;
      }
      set
      {
        this._dvRates = value;
        this._dvRates.AllowNew = false;
        this._dvRates.AllowEdit = false;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblVATRates.ToString();
        this.dgRates.DataSource = (object) this.RatesDataview;
      }
    }

    private DataRow SelectedVATRateDataRow
    {
      get
      {
        return this.dgRates.CurrentRowIndex != -1 ? this.RatesDataview[this.dgRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void btnSetRate_Click(object sender, EventArgs e)
    {
      Invoiced oInvoiced = App.DB.Invoiced.Invoiced_Get(this.InvoicedID);
      oInvoiced.SetVATRateID = RuntimeHelpers.GetObjectValue(this.SelectedVATRateDataRow["VatRateID"]);
      App.DB.Invoiced.Update(oInvoiced);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void SetupRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgRates, false);
      DataGridTableStyle tableStyle = this.dgRates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "VAT Rate";
      dataGridLabelColumn1.MappingName = "VATRate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date Introduced";
      dataGridLabelColumn2.MappingName = "DateIntroduced";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblVATRates.ToString();
      this.dgRates.TableStyles.Add(tableStyle);
    }

    private void Populate(int CurrentRateID)
    {
      this.RatesDataview = App.DB.VATRatesSQL.VATRates_GetAll();
      int row = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator.Current)["VATRateID"], (object) CurrentRateID, false))
          {
            this.dgRates.CurrentRowIndex = row;
            this.dgRates.Select(row);
          }
          checked { ++row; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }
  }
}
