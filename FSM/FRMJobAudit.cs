// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobAudit
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
  public class FRMJobAudit : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvJobAudits;

    public FRMJobAudit()
    {
      this.Load += new EventHandler(this.FRMJobAudit_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJobAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgJobAudits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobAudit = new GroupBox();
      this.dgJobAudits = new DataGrid();
      this.btnClose = new Button();
      this.grpJobAudit.SuspendLayout();
      this.dgJobAudits.BeginInit();
      this.SuspendLayout();
      this.grpJobAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobAudit.Controls.Add((Control) this.dgJobAudits);
      this.grpJobAudit.Location = new System.Drawing.Point(10, 40);
      this.grpJobAudit.Name = "grpJobAudit";
      this.grpJobAudit.Size = new Size(837, 400);
      this.grpJobAudit.TabIndex = 3;
      this.grpJobAudit.TabStop = false;
      this.grpJobAudit.Text = "Job Audit Trail";
      this.dgJobAudits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobAudits.DataMember = "";
      this.dgJobAudits.HeaderForeColor = SystemColors.ControlText;
      this.dgJobAudits.Location = new System.Drawing.Point(10, 18);
      this.dgJobAudits.Name = "dgJobAudits";
      this.dgJobAudits.Size = new Size(817, 374);
      this.dgJobAudits.TabIndex = 14;
      this.btnClose.AccessibleDescription = "Export Job List To Excel";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Location = new System.Drawing.Point(10, 454);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(67, 25);
      this.btnClose.TabIndex = 16;
      this.btnClose.Text = "Close";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(856, 486);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpJobAudit);
      this.MaximumSize = new Size(864, 520);
      this.MinimumSize = new Size(864, 520);
      this.Name = nameof (FRMJobAudit);
      this.Text = "Job Audit";
      this.Controls.SetChildIndex((Control) this.grpJobAudit, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.grpJobAudit.ResumeLayout(false);
      this.dgJobAudits.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupJobAuditDataGrid();
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

    private DataView JobAuditsDataview
    {
      get
      {
        return this._dvJobAudits;
      }
      set
      {
        this._dvJobAudits = value;
        this._dvJobAudits.AllowNew = false;
        this._dvJobAudits.AllowEdit = false;
        this._dvJobAudits.AllowDelete = false;
        this._dvJobAudits.Table.TableName = Enums.TableNames.tblJobAudit.ToString();
        this.dgJobAudits.DataSource = (object) this.JobAuditsDataview;
      }
    }

    private DataRow SelectedJobAuditDataRow
    {
      get
      {
        return this.dgJobAudits.CurrentRowIndex != -1 ? this.JobAuditsDataview[this.dgJobAudits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupJobAuditDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgJobAudits.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dddd dd MMMM yyyy HH:mm:ss";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Action Date Time";
      dataGridLabelColumn1.MappingName = "ActionDateTime";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "User";
      dataGridLabelColumn2.MappingName = "Fullname";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 175;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Action";
      dataGridLabelColumn3.MappingName = "ActionChange";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 1000;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJobAudit.ToString();
      this.dgJobAudits.TableStyles.Add(tableStyle);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMJobAudit_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.JobAuditsDataview = App.DB.JobAudit.Get_For_Job(Conversions.ToInteger(this.get_GetParameter(0)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
