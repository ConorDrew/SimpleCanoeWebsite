// Decompiled with JetBrains decompiler
// Type: FSM.FRMSiteCustomerAudit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSiteCustomerAudit : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;
    private DataView _AuditTrail;

    public FRMSiteCustomerAudit()
    {
      this.Load += new EventHandler(this.FRMSiteCustomerAudit_Load);
      this._ID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAuditTrail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.dgAuditTrail = new DataGrid();
      this.GroupBox1.SuspendLayout();
      this.dgAuditTrail.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgAuditTrail);
      this.GroupBox1.Location = new System.Drawing.Point(10, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(477, 336);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.dgAuditTrail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAuditTrail.DataMember = "";
      this.dgAuditTrail.HeaderForeColor = SystemColors.ControlText;
      this.dgAuditTrail.Location = new System.Drawing.Point(10, 19);
      this.dgAuditTrail.Name = "dgAuditTrail";
      this.dgAuditTrail.Size = new Size(458, 309);
      this.dgAuditTrail.TabIndex = 0;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(496, 385);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMSiteCustomerAudit);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Site Customer Audit";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgAuditTrail.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.AuditTrail = App.DB.SiteCustomerAudit.SiteCustomerAudit_GetAll(this.ID);
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupAuditDataGrid();
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

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    private DataView AuditTrail
    {
      get
      {
        return this._AuditTrail;
      }
      set
      {
        this._AuditTrail = value;
        this._AuditTrail.AllowDelete = false;
        this._AuditTrail.AllowEdit = false;
        this._AuditTrail.AllowNew = false;
        this._AuditTrail.Table.TableName = "Audit";
        this.dgAuditTrail.DataSource = (object) this.AuditTrail;
      }
    }

    public void SetupAuditDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAuditTrail, false);
      DataGridTableStyle tableStyle = this.dgAuditTrail.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Previous Customer";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy HH:mm:ss";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date Changed";
      dataGridLabelColumn2.MappingName = "DateChanged";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 110;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "User";
      dataGridLabelColumn3.MappingName = "UserFullName";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "Audit";
      this.dgAuditTrail.TableStyles.Add(tableStyle);
    }

    private void FRMSiteCustomerAudit_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }
  }
}
