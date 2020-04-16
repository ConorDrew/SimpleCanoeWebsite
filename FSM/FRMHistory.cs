// Decompiled with JetBrains decompiler
// Type: FSM.FRMHistory
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
  public class FRMHistory : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvHistory;

    public FRMHistory()
    {
      this.Load += new EventHandler(this.FRMHistory_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual DataGrid dgHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClear
    {
      get
      {
        return this._btnClear;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClear_Click);
        Button btnClear1 = this._btnClear;
        if (btnClear1 != null)
          btnClear1.Click -= eventHandler;
        this._btnClear = value;
        Button btnClear2 = this._btnClear;
        if (btnClear2 == null)
          return;
        btnClear2.Click += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFilter
    {
      get
      {
        return this._cboFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboFilter_SelectedIndexChanged);
        ComboBox cboFilter1 = this._cboFilter;
        if (cboFilter1 != null)
          cboFilter1.SelectedIndexChanged -= eventHandler;
        this._cboFilter = value;
        ComboBox cboFilter2 = this._cboFilter;
        if (cboFilter2 == null)
          return;
        cboFilter2.SelectedIndexChanged += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.dgHistory = new DataGrid();
      this.Panel1 = new Panel();
      this.Label1 = new Label();
      this.btnClear = new Button();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.cboFilter = new ComboBox();
      this.dgHistory.BeginInit();
      this.SuspendLayout();
      this.dgHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgHistory.DataMember = "";
      this.dgHistory.HeaderForeColor = SystemColors.ControlText;
      this.dgHistory.Location = new System.Drawing.Point(8, 40);
      this.dgHistory.Name = "dgHistory";
      this.dgHistory.Size = new Size(752, 432);
      this.dgHistory.TabIndex = 1;
      this.Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel1.BackColor = Color.Red;
      this.Panel1.Location = new System.Drawing.Point(8, 488);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(16, 16);
      this.Panel1.TabIndex = 19;
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.Location = new System.Drawing.Point(32, 488);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(168, 16);
      this.Label1.TabIndex = 18;
      this.Label1.Text = "Out of hours login recorded.";
      this.btnClear.AccessibleDescription = "Clear system interaction history";
      this.btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClear.Cursor = Cursors.Hand;
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Location = new System.Drawing.Point(712, 480);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new Size(48, 23);
      this.btnClear.TabIndex = 3;
      this.btnClear.Text = "Clear";
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.Location = new System.Drawing.Point(216, 488);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 20;
      this.Label2.Text = "Show last ";
      this.Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label3.Location = new System.Drawing.Point(360, 488);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 16);
      this.Label3.TabIndex = 21;
      this.Label3.Text = "Records";
      this.cboFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cboFilter.Location = new System.Drawing.Point(280, 484);
      this.cboFilter.Name = "cboFilter";
      this.cboFilter.Size = new Size(80, 21);
      this.cboFilter.TabIndex = 2;
      this.cboFilter.Text = "ComboBox1";
      this.AcceptButton = (IButtonControl) this.btnClear;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(768, 510);
      this.Controls.Add((Control) this.cboFilter);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.btnClear);
      this.Controls.Add((Control) this.Panel1);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.dgHistory);
      this.MinimumSize = new Size(776, 544);
      this.Name = nameof (FRMHistory);
      this.Text = "System History";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.dgHistory, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.Panel1, 0);
      this.Controls.SetChildIndex((Control) this.btnClear, 0);
      this.Controls.SetChildIndex((Control) this.Label2, 0);
      this.Controls.SetChildIndex((Control) this.Label3, 0);
      this.Controls.SetChildIndex((Control) this.cboFilter, 0);
      this.dgHistory.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupHistoryDataGrid();
      DataTable DT = new DataTable();
      DT.Columns.Add(new DataColumn("ValueMember"));
      int num = 100;
      do
      {
        DataRow row = DT.NewRow();
        row["ValueMember"] = (object) num;
        DT.Rows.Add(row);
        checked { num += 100; }
      }
      while (num <= 10000);
      ComboBox cboFilter1 = this.cboFilter;
      Combo.SetUpCombo(ref cboFilter1, DT, "ValueMember", "ValueMember", Enums.ComboValues.None);
      this.cboFilter = cboFilter1;
      ComboBox cboFilter2 = this.cboFilter;
      Combo.SetSelectedComboItem_By_Value(ref cboFilter2, Conversions.ToString(100));
      this.cboFilter = cboFilter2;
      this.PopulatePage();
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

    private DataView HistoryDataview
    {
      get
      {
        return this._dvHistory;
      }
      set
      {
        this._dvHistory = value;
        this._dvHistory.AllowNew = false;
        this._dvHistory.AllowEdit = false;
        this._dvHistory.AllowDelete = false;
        this._dvHistory.Table.TableName = Enums.TableNames.tblHistory.ToString();
        this.dgHistory.DataSource = (object) this.HistoryDataview;
      }
    }

    private void SetupHistoryDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgHistory.TableStyles[0];
      OutOfHoursColourColumn hoursColourColumn = new OutOfHoursColourColumn();
      hoursColourColumn.Format = "";
      hoursColourColumn.FormatInfo = (IFormatProvider) null;
      hoursColourColumn.HeaderText = "";
      hoursColourColumn.MappingName = "OutOfHours";
      hoursColourColumn.ReadOnly = true;
      hoursColourColumn.Width = 25;
      hoursColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) hoursColourColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Date";
      dataGridLabelColumn1.MappingName = "AccessDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 125;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "User";
      dataGridLabelColumn2.MappingName = "Fullname";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 85;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Page ; Action";
      dataGridLabelColumn3.MappingName = "FormTitle";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 185;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Type";
      dataGridLabelColumn4.MappingName = "AccessType";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 65;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Statement";
      dataGridLabelColumn5.MappingName = "Statement";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 800;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblHistory.ToString();
      this.dgHistory.TableStyles.Add(tableStyle);
    }

    private void FRMHistory_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.PopulatePage();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin) || App.ShowMessage("Are you sure you want to delete all records?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      App.DB.Manager.DeleteHistory();
      this.PopulatePage();
    }

    private void PopulatePage()
    {
      try
      {
        this.HistoryDataview = App.DB.Manager.GetHistory(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboFilter)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }
  }
}
