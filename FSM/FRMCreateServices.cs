// Decompiled with JetBrains decompiler
// Type: FSM.FRMCreateServices
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
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
  public class FRMCreateServices : Form
  {
    private IContainer components;
    public int SiteID;

    public FRMCreateServices()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMCreateServices));
      this.GroupBox1 = new GroupBox();
      this.chxCert = new CheckBox();
      this.Label2 = new Label();
      this.txtAmount = new TextBox();
      this.Label1 = new Label();
      this.btnOK = new Button();
      this.btnclose = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnclose);
      this.GroupBox1.Controls.Add((Control) this.chxCert);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.txtAmount);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(277, 86);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Select Qty to Create";
      this.chxCert.AutoSize = true;
      this.chxCert.Location = new System.Drawing.Point(240, 20);
      this.chxCert.Name = "chxCert";
      this.chxCert.Size = new Size(15, 14);
      this.chxCert.TabIndex = 5;
      this.chxCert.UseVisualStyleBackColor = true;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(153, 20);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(78, 13);
      this.Label2.TabIndex = 4;
      this.Label2.Text = "Cert Required?";
      this.txtAmount.Location = new System.Drawing.Point(101, 17);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new Size(42, 20);
      this.txtAmount.TabIndex = 3;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(9, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 13);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Amount to create";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(196, 57);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Create";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnclose.UseVisualStyleBackColor = true;
      this.btnclose.Location = new System.Drawing.Point(6, 57);
      this.btnclose.Name = "btnclose";
      this.btnclose.Size = new Size(75, 23);
      this.btnclose.TabIndex = 6;
      this.btnclose.Text = "Close";
      this.btnclose.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(284, 99);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMCreateServices);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Create Services";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox chxCert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnclose
    {
      get
      {
        return this._btnclose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnclose_Click);
        Button btnclose1 = this._btnclose;
        if (btnclose1 != null)
          btnclose1.Click -= eventHandler;
        this._btnclose = value;
        Button btnclose2 = this._btnclose;
        if (btnclose2 == null)
          return;
        btnclose2.Click += eventHandler;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try
      {
        if (Versioned.IsNumeric((object) this.txtAmount.Text) && Conversions.ToDouble(this.txtAmount.Text) > 0.0)
        {
          this.CreateServices();
          int num = (int) Interaction.MsgBox((object) (this.txtAmount.Text + " Services created!"), MsgBoxStyle.Information, (object) null);
          if (this.Modal)
            this.Close();
          else
            this.Dispose();
        }
        else
        {
          int num1 = (int) App.ShowMessage("Please select an Amount to create", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) "Somthing went terribly wrong , best speak to Rob", MsgBoxStyle.Critical, (object) "Ooooppss");
        ProjectData.ClearProjectError();
      }
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
    }

    private void CreateServices()
    {
      int integer = Conversions.ToInteger(this.txtAmount.Text);
      int num = 1;
      while (num <= integer)
      {
        Job oJob = new Job();
        oJob.SetPropertyID = (object) this.SiteID;
        oJob.SetJobDefinitionEnumID = (object) 2;
        oJob.SetJobTypeID = !this.chxCert.Checked ? RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service'")[0]["ManagerID"]) : RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"]);
        oJob.SetStatusEnumID = (object) 1;
        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
        oJob.SetFOC = (object) true;
        JobNumber jobNumber = new JobNumber();
        JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
        oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
        oJob.SetPONumber = (object) "";
        oJob.SetQuoteID = (object) 0;
        JobOfWork jobOfWork = new JobOfWork();
        jobOfWork.SetPONumber = (object) "";
        jobOfWork.IgnoreExceptionsOnSetMethods = true;
        FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(4693, "Hassle Free Service", "HF1", site.CustomerID);
        int CustomerScheduleOfRateID = 0;
        if (dataTable.Rows.Count > 0)
          CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
        if (CustomerScheduleOfRateID <= 0)
        {
          CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
          {
            SetCode = (object) "HF1",
            SetDescription = (object) "Hassle Free Service",
            SetPrice = (object) 0.0,
            SetScheduleOfRatesCategoryID = (object) 4693,
            SetTimeInMins = (object) 45,
            SetCustomerID = (object) site.CustomerID
          };
          CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
          App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
        }
        jobOfWork.JobItems.Add((object) new JobItem()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetSummary = (object) "Hassle Free Service",
          SetQty = (object) 1,
          SetRateID = (object) CustomerScheduleOfRateID,
          SetSystemLinkID = (object) 95
        });
        jobOfWork.EngineerVisits.Add((object) new EngineerVisit()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetEngineerID = (object) 0,
          SetNotesToEngineer = (!this.chxCert.Checked ? (object) "Service Appliance Covered by Hassle Free Heating" : (object) "Service and Cert Appliance Covered by Hassle Free Heating"),
          StartDateTime = DateTime.MinValue,
          EndDateTime = DateTime.MinValue,
          SetStatusEnumID = (object) 4
        });
        oJob.JobOfWorks.Add((object) jobOfWork);
        App.DB.Job.Insert(oJob);
        checked { ++num; }
      }
    }

    private void btnclose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
