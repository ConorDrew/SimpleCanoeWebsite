// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobLocks
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
  public class FRMJobLocks : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _Locks;

    public FRMJobLocks()
    {
      this.Load += new EventHandler(this.FRMJobLocks_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpLocks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgLocks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnUnlock
    {
      get
      {
        return this._btnUnlock;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnlock_Click);
        Button btnUnlock1 = this._btnUnlock;
        if (btnUnlock1 != null)
          btnUnlock1.Click -= eventHandler;
        this._btnUnlock = value;
        Button btnUnlock2 = this._btnUnlock;
        if (btnUnlock2 == null)
          return;
        btnUnlock2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpLocks = new GroupBox();
      this.dgLocks = new DataGrid();
      this.btnUnlock = new Button();
      this.btnClose = new Button();
      this.grpLocks.SuspendLayout();
      this.dgLocks.BeginInit();
      this.SuspendLayout();
      this.grpLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpLocks.Controls.Add((Control) this.dgLocks);
      this.grpLocks.Location = new System.Drawing.Point(8, 40);
      this.grpLocks.Name = "grpLocks";
      this.grpLocks.Size = new Size(769, 405);
      this.grpLocks.TabIndex = 1;
      this.grpLocks.TabStop = false;
      this.grpLocks.Text = "Highlight job to release and click 'Unlock'";
      this.dgLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgLocks.DataMember = "";
      this.dgLocks.HeaderForeColor = SystemColors.ControlText;
      this.dgLocks.Location = new System.Drawing.Point(8, 20);
      this.dgLocks.Name = "dgLocks";
      this.dgLocks.Size = new Size(753, 377);
      this.dgLocks.TabIndex = 1;
      this.btnUnlock.AccessibleDescription = "Save item";
      this.btnUnlock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUnlock.Cursor = Cursors.Hand;
      this.btnUnlock.UseVisualStyleBackColor = true;
      this.btnUnlock.ImageIndex = 1;
      this.btnUnlock.Location = new System.Drawing.Point(721, 451);
      this.btnUnlock.Name = "btnUnlock";
      this.btnUnlock.Size = new Size(56, 23);
      this.btnUnlock.TabIndex = 2;
      this.btnUnlock.Text = "Unlock";
      this.btnClose.AccessibleDescription = "Save item";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Cursor = Cursors.Hand;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.ImageIndex = 1;
      this.btnClose.Location = new System.Drawing.Point(8, 451);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(785, 486);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpLocks);
      this.Controls.Add((Control) this.btnUnlock);
      this.MinimumSize = new Size(793, 520);
      this.Name = nameof (FRMJobLocks);
      this.Text = "Job Locks";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnUnlock, 0);
      this.Controls.SetChildIndex((Control) this.grpLocks, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.grpLocks.ResumeLayout(false);
      this.dgLocks.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
      this.Locks = App.DB.JobLock.GetAll();
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

    private DataView Locks
    {
      get
      {
        return this._Locks;
      }
      set
      {
        this._Locks = value;
        this._Locks.AllowNew = false;
        this._Locks.AllowEdit = false;
        this._Locks.AllowDelete = false;
        this._Locks.Table.TableName = Enums.TableNames.tblJobLock.ToString();
        this.dgLocks.DataSource = (object) this.Locks;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgLocks.CurrentRowIndex != -1 ? this.Locks[this.dgLocks.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      Helper.SetUpDataGrid(this.dgLocks, false);
      DataGridTableStyle tableStyle = this.dgLocks.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Job";
      dataGridLabelColumn1.MappingName = "JobNumber";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Locked By";
      dataGridLabelColumn2.MappingName = "FullName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dddd dd MMMM yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Locked On";
      dataGridLabelColumn3.MappingName = "DateLock";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJobLock.ToString();
      this.dgLocks.TableStyles.Add(tableStyle);
    }

    private void FRMJobLocks_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnUnlock_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select job to unlock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
      {
        if (App.ShowMessage("Are you sure you wish to unlock this job? The next user to access this record, will relock it.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.JobLock.Delete(Conversions.ToInteger(this.SelectedDataRow["JobLockID"]));
          this.Locks = App.DB.JobLock.GetAll();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error unlocking job : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }
  }
}
