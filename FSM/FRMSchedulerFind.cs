// Decompiled with JetBrains decompiler
// Type: FSM.FRMSchedulerFind
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSchedulerFind : Form
  {
    private IContainer components;
    private DataView _dvResults;

    public FRMSchedulerFind()
    {
      this.Load += new EventHandler(this.FRMSchedulerFind_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFind { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbtnOrder
    {
      get
      {
        return this._rbtnOrder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbtn_CheckedChanged);
        RadioButton rbtnOrder1 = this._rbtnOrder;
        if (rbtnOrder1 != null)
          rbtnOrder1.CheckedChanged -= eventHandler;
        this._rbtnOrder = value;
        RadioButton rbtnOrder2 = this._rbtnOrder;
        if (rbtnOrder2 == null)
          return;
        rbtnOrder2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbtnJob
    {
      get
      {
        return this._rbtnJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbtn_CheckedChanged);
        RadioButton rbtnJob1 = this._rbtnJob;
        if (rbtnJob1 != null)
          rbtnJob1.CheckedChanged -= eventHandler;
        this._rbtnJob = value;
        RadioButton rbtnJob2 = this._rbtnJob;
        if (rbtnJob2 == null)
          return;
        rbtnJob2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbtnSite
    {
      get
      {
        return this._rbtnSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbtn_CheckedChanged);
        RadioButton rbtnSite1 = this._rbtnSite;
        if (rbtnSite1 != null)
          rbtnSite1.CheckedChanged -= eventHandler;
        this._rbtnSite = value;
        RadioButton rbtnSite2 = this._rbtnSite;
        if (rbtnSite2 == null)
          return;
        rbtnSite2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnFind
    {
      get
      {
        return this._btnFind;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFind_Click);
        Button btnFind1 = this._btnFind;
        if (btnFind1 != null)
          btnFind1.Click -= eventHandler;
        this._btnFind = value;
        Button btnFind2 = this._btnFind;
        if (btnFind2 == null)
          return;
        btnFind2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtFilter
    {
      get
      {
        return this._txtFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtFilter_KeyUp);
        TextBox txtFilter1 = this._txtFilter;
        if (txtFilter1 != null)
          txtFilter1.KeyUp -= keyEventHandler;
        this._txtFilter = value;
        TextBox txtFilter2 = this._txtFilter;
        if (txtFilter2 == null)
          return;
        txtFilter2.KeyUp += keyEventHandler;
      }
    }

    internal virtual GroupBox grpResult { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgResults
    {
      get
      {
        return this._dgResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgResults_DoubleClick);
        DataGrid dgResults1 = this._dgResults;
        if (dgResults1 != null)
          dgResults1.DoubleClick -= eventHandler;
        this._dgResults = value;
        DataGrid dgResults2 = this._dgResults;
        if (dgResults2 == null)
          return;
        dgResults2.DoubleClick += eventHandler;
      }
    }

    internal virtual RadioButton rbtnCustomer
    {
      get
      {
        return this._rbtnCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbtn_CheckedChanged);
        RadioButton rbtnCustomer1 = this._rbtnCustomer;
        if (rbtnCustomer1 != null)
          rbtnCustomer1.CheckedChanged -= eventHandler;
        this._rbtnCustomer = value;
        RadioButton rbtnCustomer2 = this._rbtnCustomer;
        if (rbtnCustomer2 == null)
          return;
        rbtnCustomer2.CheckedChanged += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpFind = new GroupBox();
      this.rbtnCustomer = new RadioButton();
      this.rbtnOrder = new RadioButton();
      this.rbtnJob = new RadioButton();
      this.rbtnSite = new RadioButton();
      this.btnFind = new Button();
      this.txtFilter = new TextBox();
      this.grpResult = new GroupBox();
      this.dgResults = new DataGrid();
      this.grpFind.SuspendLayout();
      this.grpResult.SuspendLayout();
      this.dgResults.BeginInit();
      this.SuspendLayout();
      this.grpFind.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpFind.Controls.Add((Control) this.rbtnCustomer);
      this.grpFind.Controls.Add((Control) this.rbtnOrder);
      this.grpFind.Controls.Add((Control) this.rbtnJob);
      this.grpFind.Controls.Add((Control) this.rbtnSite);
      this.grpFind.Location = new System.Drawing.Point(12, 12);
      this.grpFind.Name = "grpFind";
      this.grpFind.Size = new Size(97, 400);
      this.grpFind.TabIndex = 0;
      this.grpFind.TabStop = false;
      this.grpFind.Text = "Find";
      this.rbtnCustomer.AutoSize = true;
      this.rbtnCustomer.Location = new System.Drawing.Point(11, 79);
      this.rbtnCustomer.Name = "rbtnCustomer";
      this.rbtnCustomer.Size = new Size(69, 17);
      this.rbtnCustomer.TabIndex = 4;
      this.rbtnCustomer.Text = "Customer";
      this.rbtnCustomer.UseVisualStyleBackColor = true;
      this.rbtnOrder.AutoSize = true;
      this.rbtnOrder.Location = new System.Drawing.Point(11, 109);
      this.rbtnOrder.Name = "rbtnOrder";
      this.rbtnOrder.Size = new Size(51, 17);
      this.rbtnOrder.TabIndex = 3;
      this.rbtnOrder.Text = "Order";
      this.rbtnOrder.UseVisualStyleBackColor = true;
      this.rbtnOrder.Visible = false;
      this.rbtnJob.AutoSize = true;
      this.rbtnJob.Location = new System.Drawing.Point(11, 49);
      this.rbtnJob.Name = "rbtnJob";
      this.rbtnJob.Size = new Size(42, 17);
      this.rbtnJob.TabIndex = 2;
      this.rbtnJob.Text = "Job";
      this.rbtnJob.UseVisualStyleBackColor = true;
      this.rbtnSite.AutoSize = true;
      this.rbtnSite.Checked = true;
      this.rbtnSite.Location = new System.Drawing.Point(10, 19);
      this.rbtnSite.Name = "rbtnSite";
      this.rbtnSite.Size = new Size(43, 17);
      this.rbtnSite.TabIndex = 1;
      this.rbtnSite.TabStop = true;
      this.rbtnSite.Text = "Site";
      this.rbtnSite.UseVisualStyleBackColor = true;
      this.btnFind.AccessibleDescription = "";
      this.btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFind.Cursor = Cursors.Hand;
      this.btnFind.FlatStyle = FlatStyle.System;
      this.btnFind.Location = new System.Drawing.Point(667, 18);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new Size(48, 23);
      this.btnFind.TabIndex = 5;
      this.btnFind.Text = "Find";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(115, 20);
      this.txtFilter.MaxLength = 25;
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(546, 20);
      this.txtFilter.TabIndex = 4;
      this.grpResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpResult.Controls.Add((Control) this.dgResults);
      this.grpResult.Location = new System.Drawing.Point(115, 46);
      this.grpResult.Name = "grpResult";
      this.grpResult.Size = new Size(600, 366);
      this.grpResult.TabIndex = 4;
      this.grpResult.TabStop = false;
      this.grpResult.Text = "Result - Double Click to Open";
      this.dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgResults.DataMember = "";
      this.dgResults.HeaderForeColor = SystemColors.ControlText;
      this.dgResults.Location = new System.Drawing.Point(6, 19);
      this.dgResults.Name = "dgResults";
      this.dgResults.Size = new Size(588, 341);
      this.dgResults.TabIndex = 12;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(727, 424);
      this.Controls.Add((Control) this.grpResult);
      this.Controls.Add((Control) this.btnFind);
      this.Controls.Add((Control) this.txtFilter);
      this.Controls.Add((Control) this.grpFind);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.Name = nameof (FRMSchedulerFind);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Find";
      this.grpFind.ResumeLayout(false);
      this.grpFind.PerformLayout();
      this.grpResult.ResumeLayout(false);
      this.dgResults.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private DataView DvResults
    {
      get
      {
        return this._dvResults;
      }
      set
      {
        this._dvResults = value;
        this._dvResults.Table.TableName = Enums.TableNames.NO_TABLE.ToString();
        this.dgResults.DataSource = (object) this.DvResults;
      }
    }

    private DataRow DrSelectedResult
    {
      get
      {
        return this.dgResults.CurrentRowIndex != -1 ? this.DvResults[this.dgResults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void FRMSchedulerFind_Load(object sender, EventArgs e)
    {
      List<Enums.SecuritySystemModules> ssm = new List<Enums.SecuritySystemModules>()
      {
        Enums.SecuritySystemModules.CreatePO,
        Enums.SecuritySystemModules.EditPO
      };
      this.rbtnOrder.Visible = App.loggedInUser.HasAccessToMulitpleModules(ssm);
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      this.Find();
    }

    private void txtFilter_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.Find();
    }

    private void dgResults_DoubleClick(object sender, EventArgs e)
    {
      this.Open();
    }

    private void rbtn_CheckedChanged(object sender, EventArgs e)
    {
      this.ResetForm();
    }

    private void Find()
    {
      bool flag = true;
      if (flag == this.rbtnSite.Checked)
      {
        this.SetupDgSites();
        this.DvResults = App.DB.Sites.Search(this.txtFilter.Text.Trim(), App.loggedInUser.UserID);
      }
      else if (flag == this.rbtnJob.Checked)
      {
        this.SetupDgJobs();
        this.DvResults = App.DB.Job.Search(this.txtFilter.Text.Trim(), App.loggedInUser.UserID);
      }
      else if (flag == this.rbtnCustomer.Checked)
      {
        this.SetupDgCustomers();
        this.DvResults = App.DB.Customer.Customer_Search(this.txtFilter.Text.Trim(), App.loggedInUser.UserID);
      }
      else if (flag == this.rbtnOrder.Checked)
      {
        this.SetupDgOrders();
        this.DvResults = App.DB.Order.Search(this.txtFilter.Text.Trim(), App.loggedInUser.UserID);
      }
      else
      {
        int num = (int) App.ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void Open()
    {
      if (this.DrSelectedResult == null)
      {
        int num1 = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        bool flag = true;
        if (flag == this.rbtnSite.Checked)
          App.ShowForm(typeof (FRMSite), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["SiteID"]))
          }, false);
        else if (flag == this.rbtnJob.Checked)
          App.ShowForm(typeof (FRMLogCallout), true, new object[3]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["JobID"])),
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["SiteID"])),
            (object) this
          }, false);
        else if (flag == this.rbtnCustomer.Checked)
          App.ShowForm(typeof (FRMCustomer), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["CustomerID"]))
          }, false);
        else if (flag == this.rbtnOrder.Checked)
        {
          switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["OrderTypeID"])))
          {
            case 1:
              App.ShowForm(typeof (FRMOrder), false, new object[4]
              {
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["OrderID"])),
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["SiteID"])),
                (object) 0,
                (object) this
              }, false);
              break;
            case 2:
              App.ShowForm(typeof (FRMOrder), false, new object[4]
              {
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["OrderID"])),
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["VanID"])),
                (object) 0,
                (object) this
              }, false);
              break;
            case 3:
              App.ShowForm(typeof (FRMOrder), false, new object[4]
              {
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["OrderID"])),
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["WarehouseID"])),
                (object) 0,
                (object) this
              }, false);
              break;
            case 4:
              App.ShowForm(typeof (FRMOrder), false, new object[4]
              {
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["OrderID"])),
                (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedResult["EngineerVisitID"])),
                (object) 0,
                (object) this
              }, false);
              break;
          }
        }
        else
        {
          int num2 = (int) App.ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
    }

    private void ResetForm()
    {
      this.DvResults = new DataView(new DataTable());
      this.ClearDg();
    }

    private void SetupDgSites()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "Address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 2";
      dataGridLabelColumn3.MappingName = "Address2";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Postcode";
      dataGridLabelColumn4.MappingName = "Postcode";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Customer";
      dataGridLabelColumn5.MappingName = "CustomerName";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Policy Number / UPRN";
      dataGridLabelColumn6.MappingName = "PolicyNumber";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Last Service Date";
      dataGridLabelColumn7.MappingName = "LastServiceDate";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }

    public void SetupDgJobs()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Created";
      dataGridLabelColumn1.MappingName = "DateCreated";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job No";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Site";
      dataGridLabelColumn4.MappingName = "Site";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 200;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Visit's Date";
      dataGridLabelColumn5.MappingName = "LastVisitDate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }

    public void SetupDgCustomers()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Account Number";
      dataGridLabelColumn2.MappingName = "AccountNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 140;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 140;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Region";
      dataGridLabelColumn4.MappingName = "Region";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 140;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }

    private void SetupDgOrders()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MMM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Date Placed";
      dataGridLabelColumn1.MappingName = "DatePlaced";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 90;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Order Reference";
      dataGridLabelColumn2.MappingName = "OrderReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 110;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Supplier";
      dataGridLabelColumn4.MappingName = "Supplier";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Cost";
      dataGridLabelColumn5.MappingName = "BuyPrice";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Dept";
      dataGridLabelColumn6.MappingName = "DepartmentRef";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 50;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Customer";
      dataGridLabelColumn7.MappingName = "Customer";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 140;
      dataGridLabelColumn7.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Property";
      dataGridLabelColumn8.MappingName = "Site";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 140;
      dataGridLabelColumn8.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Job Number";
      dataGridLabelColumn9.MappingName = "JobNumber";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }

    private void ClearDg()
    {
      Helper.SetUpDataGrid(this.dgResults, false);
      DataGridTableStyle tableStyle = this.dgResults.TableStyles[0];
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgResults.TableStyles.Add(tableStyle);
    }
  }
}
