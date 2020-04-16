// Decompiled with JetBrains decompiler
// Type: FSM.FRMPostcodeManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class FRMPostcodeManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _PostcodeID;
    private DataView _dvEngineers;

    public FRMPostcodeManager()
    {
      this.Load += new EventHandler(this.FRMPostcodeManager_Load);
      this._PostcodeID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineers
    {
      get
      {
        return this._dgEngineers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgEngineers_Clicks);
        EventHandler eventHandler2 = new EventHandler(this.dgEngineers_Clicks);
        DataGrid dgEngineers1 = this._dgEngineers;
        if (dgEngineers1 != null)
        {
          dgEngineers1.Click -= eventHandler1;
          dgEngineers1.DoubleClick -= eventHandler2;
        }
        this._dgEngineers = value;
        DataGrid dgEngineers2 = this._dgEngineers;
        if (dgEngineers2 == null)
          return;
        dgEngineers2.Click += eventHandler1;
        dgEngineers2.DoubleClick += eventHandler2;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineers = new GroupBox();
      this.dgEngineers = new DataGrid();
      this.btnSave = new Button();
      this.grpEngineers.SuspendLayout();
      this.dgEngineers.BeginInit();
      this.SuspendLayout();
      this.grpEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineers.Controls.Add((Control) this.dgEngineers);
      this.grpEngineers.Location = new System.Drawing.Point(8, 40);
      this.grpEngineers.Name = "grpEngineers";
      this.grpEngineers.Size = new Size(344, 408);
      this.grpEngineers.TabIndex = 1;
      this.grpEngineers.TabStop = false;
      this.grpEngineers.Text = "Tick those engineers associated to this new postcode";
      this.dgEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEngineers.DataMember = "";
      this.dgEngineers.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineers.Location = new System.Drawing.Point(8, 25);
      this.dgEngineers.Name = "dgEngineers";
      this.dgEngineers.Size = new Size(328, 375);
      this.dgEngineers.TabIndex = 0;
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 456);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(360, 486);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.grpEngineers);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(368, 520);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(368, 520);
      this.Name = nameof (FRMPostcodeManager);
      this.Text = "Postcode Manager";
      this.Controls.SetChildIndex((Control) this.grpEngineers, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.grpEngineers.ResumeLayout(false);
      this.dgEngineers.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupEngineersDataGrid();
      this.PostcodeID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
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

    public int PostcodeID
    {
      get
      {
        return this._PostcodeID;
      }
      set
      {
        this._PostcodeID = value;
        this.Engineers = App.DB.Engineer.Engineer_GetAll();
      }
    }

    private DataView Engineers
    {
      get
      {
        return this._dvEngineers;
      }
      set
      {
        this._dvEngineers = value;
        this._dvEngineers.Table.TableName = Enums.TableNames.tblEngineer.ToString();
        this._dvEngineers.AllowNew = false;
        this._dvEngineers.AllowEdit = false;
        this._dvEngineers.AllowDelete = false;
        this.dgEngineers.DataSource = (object) this.Engineers;
      }
    }

    private DataRow SelectedEngineerDataRow
    {
      get
      {
        return this.dgEngineers.CurrentRowIndex != -1 ? this.Engineers[this.dgEngineers.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void FRMPostcodeManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgEngineers_Clicks(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedEngineerDataRow == null)
          return;
        this.dgEngineers[this.dgEngineers.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgEngineers[this.dgEngineers.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void SetupEngineersDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgEngineers.TableStyles[0];
      this.dgEngineers.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.AllowNull = false;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Name";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 200;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = Enums.TableNames.tblEngineer.ToString();
      this.dgEngineers.TableStyles.Add(tableStyle);
    }

    private void Save()
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        IEnumerator enumerator;
        try
        {
          enumerator = this.Engineers.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(current["Tick"]))
              App.DB.EngineerPostalRegion.Insert(Conversions.ToInteger(current["EngineerID"]), this.PostcodeID);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }
  }
}
