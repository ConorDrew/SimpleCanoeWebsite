// Decompiled with JetBrains decompiler
// Type: FSM.UCCalloutBreakdown
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCCalloutBreakdown : UCBase, IUserControl
  {
    private IContainer components;
    private UCLogCallout _onContol;
    private JobOfWork _jobOfWork;
    private DataView m_dJobItemsAddedTable;
    private Enums.FormState _JobItemState;

    public UCCalloutBreakdown()
    {
      this.Load += new EventHandler(this.UCCalloutBreakdown_Load);
      this._onContol = (UCLogCallout) null;
      this.m_dJobItemsAddedTable = (DataView) null;
      this._JobItemState = Enums.FormState.Insert;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJobItemsAdded { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobItemsAdded
    {
      get
      {
        return this._dgJobItemsAdded;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgJobItemsAdded_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgJobItemsAdded_Click);
        DataGrid dgJobItemsAdded1 = this._dgJobItemsAdded;
        if (dgJobItemsAdded1 != null)
        {
          dgJobItemsAdded1.Click -= eventHandler1;
          dgJobItemsAdded1.CurrentCellChanged -= eventHandler2;
        }
        this._dgJobItemsAdded = value;
        DataGrid dgJobItemsAdded2 = this._dgJobItemsAdded;
        if (dgJobItemsAdded2 == null)
          return;
        dgJobItemsAdded2.Click += eventHandler1;
        dgJobItemsAdded2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual TabControl tcEngineerVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveEngineerVisit
    {
      get
      {
        return this._btnRemoveEngineerVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveEngineerVisit_Click);
        Button removeEngineerVisit1 = this._btnRemoveEngineerVisit;
        if (removeEngineerVisit1 != null)
          removeEngineerVisit1.Click -= eventHandler;
        this._btnRemoveEngineerVisit = value;
        Button removeEngineerVisit2 = this._btnRemoveEngineerVisit;
        if (removeEngineerVisit2 == null)
          return;
        removeEngineerVisit2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddEngineerVisit
    {
      get
      {
        return this._btnAddEngineerVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddEngineerVisit_Click);
        Button addEngineerVisit1 = this._btnAddEngineerVisit;
        if (addEngineerVisit1 != null)
          addEngineerVisit1.Click -= eventHandler;
        this._btnAddEngineerVisit = value;
        Button addEngineerVisit2 = this._btnAddEngineerVisit;
        if (addEngineerVisit2 == null)
          return;
        addEngineerVisit2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtJobItemSummary { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveItem
    {
      get
      {
        return this._btnSaveItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveItem_Click);
        Button btnSaveItem1 = this._btnSaveItem;
        if (btnSaveItem1 != null)
          btnSaveItem1.Click -= eventHandler;
        this._btnSaveItem = value;
        Button btnSaveItem2 = this._btnSaveItem;
        if (btnSaveItem2 == null)
          return;
        btnSaveItem2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveItem
    {
      get
      {
        return this._btnRemoveItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveItem_Click);
        Button btnRemoveItem1 = this._btnRemoveItem;
        if (btnRemoveItem1 != null)
          btnRemoveItem1.Click -= eventHandler;
        this._btnRemoveItem = value;
        Button btnRemoveItem2 = this._btnRemoveItem;
        if (btnRemoveItem2 == null)
          return;
        btnRemoveItem2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPriority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddRate
    {
      get
      {
        return this._btnAddRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddRate_Click);
        Button btnAddRate1 = this._btnAddRate;
        if (btnAddRate1 != null)
          btnAddRate1.Click -= eventHandler;
        this._btnAddRate = value;
        Button btnAddRate2 = this._btnAddRate;
        if (btnAddRate2 == null)
          return;
        btnAddRate2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobItemsAdded = new GroupBox();
      this.lblQualification = new Label();
      this.cboQualification = new ComboBox();
      this.Label4 = new Label();
      this.cboPriority = new ComboBox();
      this.txtPONumber = new TextBox();
      this.Label3 = new Label();
      this.btnAddRate = new Button();
      this.Label1 = new Label();
      this.txtJobItemSummary = new TextBox();
      this.btnSaveItem = new Button();
      this.btnRemoveItem = new Button();
      this.btnRemoveEngineerVisit = new Button();
      this.btnAddEngineerVisit = new Button();
      this.tcEngineerVisits = new TabControl();
      this.dgJobItemsAdded = new DataGrid();
      this.grpJobItemsAdded.SuspendLayout();
      this.dgJobItemsAdded.BeginInit();
      this.SuspendLayout();
      this.grpJobItemsAdded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobItemsAdded.Controls.Add((Control) this.lblQualification);
      this.grpJobItemsAdded.Controls.Add((Control) this.cboQualification);
      this.grpJobItemsAdded.Controls.Add((Control) this.Label4);
      this.grpJobItemsAdded.Controls.Add((Control) this.cboPriority);
      this.grpJobItemsAdded.Controls.Add((Control) this.txtPONumber);
      this.grpJobItemsAdded.Controls.Add((Control) this.Label3);
      this.grpJobItemsAdded.Controls.Add((Control) this.btnAddRate);
      this.grpJobItemsAdded.Controls.Add((Control) this.Label1);
      this.grpJobItemsAdded.Controls.Add((Control) this.txtJobItemSummary);
      this.grpJobItemsAdded.Controls.Add((Control) this.btnSaveItem);
      this.grpJobItemsAdded.Controls.Add((Control) this.btnRemoveItem);
      this.grpJobItemsAdded.Controls.Add((Control) this.btnRemoveEngineerVisit);
      this.grpJobItemsAdded.Controls.Add((Control) this.btnAddEngineerVisit);
      this.grpJobItemsAdded.Controls.Add((Control) this.tcEngineerVisits);
      this.grpJobItemsAdded.Controls.Add((Control) this.dgJobItemsAdded);
      this.grpJobItemsAdded.Location = new System.Drawing.Point(8, 8);
      this.grpJobItemsAdded.Name = "grpJobItemsAdded";
      this.grpJobItemsAdded.Size = new Size(864, 280);
      this.grpJobItemsAdded.TabIndex = 0;
      this.grpJobItemsAdded.TabStop = false;
      this.grpJobItemsAdded.Text = "Job Items";
      this.lblQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblQualification.AutoSize = true;
      this.lblQualification.Location = new System.Drawing.Point(277, 22);
      this.lblQualification.Name = "lblQualification";
      this.lblQualification.Size = new Size(77, 13);
      this.lblQualification.TabIndex = 26;
      this.lblQualification.Text = "Qualification";
      this.cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboQualification.FormattingEnabled = true;
      this.cboQualification.Location = new System.Drawing.Point(369, 18);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(223, 21);
      this.cboQualification.TabIndex = 25;
      this.Label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(598, 20);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(48, 13);
      this.Label4.TabIndex = 24;
      this.Label4.Text = "Priority";
      this.cboPriority.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboPriority.FormattingEnabled = true;
      this.cboPriority.Location = new System.Drawing.Point(652, 18);
      this.cboPriority.Name = "cboPriority";
      this.cboPriority.Size = new Size(142, 21);
      this.cboPriority.TabIndex = 23;
      this.txtPONumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPONumber.Location = new System.Drawing.Point(84, 20);
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(185, 21);
      this.txtPONumber.TabIndex = 22;
      this.Label3.Location = new System.Drawing.Point(8, 21);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(81, 20);
      this.Label3.TabIndex = 21;
      this.Label3.Text = "PO Number";
      this.btnAddRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddRate.Location = new System.Drawing.Point(6, 248);
      this.btnAddRate.Name = "btnAddRate";
      this.btnAddRate.Size = new Size(354, 23);
      this.btnAddRate.TabIndex = 20;
      this.btnAddRate.Text = "Add Description From A Property Schedule Of Rates List";
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.Location = new System.Drawing.Point(6, 172);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(104, 16);
      this.Label1.TabIndex = 18;
      this.Label1.Text = "Enter Summary";
      this.txtJobItemSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtJobItemSummary.Location = new System.Drawing.Point(8, 191);
      this.txtJobItemSummary.Multiline = true;
      this.txtJobItemSummary.Name = "txtJobItemSummary";
      this.txtJobItemSummary.ScrollBars = ScrollBars.Both;
      this.txtJobItemSummary.Size = new Size(261, 49);
      this.txtJobItemSummary.TabIndex = 15;
      this.btnSaveItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveItem.Location = new System.Drawing.Point(296, 220);
      this.btnSaveItem.Name = "btnSaveItem";
      this.btnSaveItem.Size = new Size(64, 23);
      this.btnSaveItem.TabIndex = 16;
      this.btnSaveItem.Text = "Save";
      this.btnRemoveItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveItem.Location = new System.Drawing.Point(296, 191);
      this.btnRemoveItem.Name = "btnRemoveItem";
      this.btnRemoveItem.Size = new Size(62, 23);
      this.btnRemoveItem.TabIndex = 17;
      this.btnRemoveItem.Text = "Remove";
      this.btnRemoveEngineerVisit.AccessibleDescription = "Remove Engineer Visit";
      this.btnRemoveEngineerVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRemoveEngineerVisit.Location = new System.Drawing.Point(832, 25);
      this.btnRemoveEngineerVisit.Name = "btnRemoveEngineerVisit";
      this.btnRemoveEngineerVisit.Size = new Size(24, 23);
      this.btnRemoveEngineerVisit.TabIndex = 4;
      this.btnRemoveEngineerVisit.Text = "_";
      this.btnAddEngineerVisit.AccessibleDescription = "Add Engineer Visit";
      this.btnAddEngineerVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddEngineerVisit.Location = new System.Drawing.Point(800, 25);
      this.btnAddEngineerVisit.Name = "btnAddEngineerVisit";
      this.btnAddEngineerVisit.Size = new Size(24, 23);
      this.btnAddEngineerVisit.TabIndex = 3;
      this.btnAddEngineerVisit.Text = "+";
      this.tcEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.tcEngineerVisits.Location = new System.Drawing.Point(369, 48);
      this.tcEngineerVisits.Name = "tcEngineerVisits";
      this.tcEngineerVisits.SelectedIndex = 0;
      this.tcEngineerVisits.Size = new Size(487, 224);
      this.tcEngineerVisits.TabIndex = 5;
      this.dgJobItemsAdded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobItemsAdded.DataMember = "";
      this.dgJobItemsAdded.HeaderForeColor = SystemColors.ControlText;
      this.dgJobItemsAdded.Location = new System.Drawing.Point(8, 48);
      this.dgJobItemsAdded.Name = "dgJobItemsAdded";
      this.dgJobItemsAdded.Size = new Size(352, 121);
      this.dgJobItemsAdded.TabIndex = 1;
      this.Controls.Add((Control) this.grpJobItemsAdded);
      this.Name = nameof (UCCalloutBreakdown);
      this.Size = new Size(880, 296);
      this.grpJobItemsAdded.ResumeLayout(false);
      this.grpJobItemsAdded.PerformLayout();
      this.dgJobItemsAdded.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupJobItemsAddedDataGrid();
      IEnumerator enumerator;
      try
      {
        enumerator = this.tcEngineerVisits.TabPages.GetEnumerator();
        while (enumerator.MoveNext())
          ((UCVisitBreakdown) ((Control) enumerator.Current).Controls[0]).SetupDG();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.JobOfWork;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public UCLogCallout OnContol
    {
      get
      {
        return this._onContol;
      }
      set
      {
        this._onContol = value;
      }
    }

    public JobOfWork JobOfWork
    {
      get
      {
        return this._jobOfWork;
      }
      set
      {
        this._jobOfWork = value;
        if (this._jobOfWork != null)
          return;
        this._jobOfWork = new JobOfWork();
      }
    }

    public DataView JobItemsAddedDataView
    {
      get
      {
        return this.m_dJobItemsAddedTable;
      }
      set
      {
        this.m_dJobItemsAddedTable = value;
        this.m_dJobItemsAddedTable.Table.TableName = "JOB_ITEMS_ADDED";
        this.m_dJobItemsAddedTable.AllowNew = false;
        this.m_dJobItemsAddedTable.AllowEdit = false;
        this.m_dJobItemsAddedTable.AllowDelete = false;
        this.dgJobItemsAdded.DataSource = (object) this.JobItemsAddedDataView;
      }
    }

    private DataRow SelectedItemAddedDataRow
    {
      get
      {
        return this.dgJobItemsAdded.CurrentRowIndex != -1 ? this.JobItemsAddedDataView[this.dgJobItemsAdded.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Enums.FormState JobItemState
    {
      get
      {
        return this._JobItemState;
      }
      set
      {
        this._JobItemState = value;
        if (value == Enums.FormState.Insert)
          this.btnSaveItem.Text = "Add";
        else if (value == Enums.FormState.Update)
          this.btnSaveItem.Text = "Update";
        else
          this.btnSaveItem.Text = "Save";
      }
    }

    private void UCCalloutBreakdown_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      if (true == App.IsRFT)
        this.lblQualification.Text = "Trade";
      else
        this.lblQualification.Text = "Qualification";
    }

    private void dgJobItemsAdded_Click(object sender, EventArgs e)
    {
      if (this.SelectedItemAddedDataRow == null)
      {
        this.JobItemState = Enums.FormState.Insert;
      }
      else
      {
        this.txtJobItemSummary.Text = Conversions.ToString(this.SelectedItemAddedDataRow["Summary"]);
        this.JobItemState = Enums.FormState.Update;
      }
    }

    private void btnSaveItem_Click(object sender, EventArgs e)
    {
      if (this.txtJobItemSummary.Text.Trim().Length == 0)
      {
        int num = (int) App.ShowMessage("Job Item Summary Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (this.JobItemState == Enums.FormState.Insert)
        {
          this.JobItemsAddedDataView.Table.AcceptChanges();
          DataRow row = this.JobItemsAddedDataView.Table.NewRow();
          row["Summary"] = (object) this.txtJobItemSummary.Text.Trim();
          row["RateID"] = (object) 0;
          this.JobItemsAddedDataView.Table.Rows.Add(row);
        }
        else if (this.JobItemState == Enums.FormState.Update)
        {
          this.JobItemsAddedDataView.Table.AcceptChanges();
          this.SelectedItemAddedDataRow["Summary"] = (object) this.txtJobItemSummary.Text.Trim();
        }
        this.JobItemsAddedDataView.Sort = "Summary";
        this.txtJobItemSummary.Text = "";
        this.JobItemState = Enums.FormState.Insert;
        this.ActiveControl = (Control) this.txtJobItemSummary;
        this.txtJobItemSummary.Focus();
      }
    }

    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
      if (this.SelectedItemAddedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this.tcEngineerVisits.TabPages.GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (((UCVisitBreakdown) ((Control) enumerator.Current).Controls[0]).EngineerVisit.StatusEnumID >= 5)
            {
              int num2 = (int) App.ShowMessage("This item cannot be removed as it is related to a visit that has progressed to 'scheduled' or further.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              this.txtJobItemSummary.Text = "";
              this.JobItemState = Enums.FormState.Insert;
              return;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (App.ShowMessage("Are you sure you want to remove this item of work?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        this.JobItemsAddedDataView.Table.AcceptChanges();
        this.JobItemsAddedDataView.Table.Rows.Remove(this.SelectedItemAddedDataRow);
        this.JobItemsAddedDataView.Sort = "Summary";
        this.txtJobItemSummary.Text = "";
        this.JobItemState = Enums.FormState.Insert;
        this.ActiveControl = (Control) this.txtJobItemSummary;
        this.txtJobItemSummary.Focus();
      }
    }

    private void btnAddEngineerVisit_Click(object sender, EventArgs e)
    {
      this.AddEngineerVisit((EngineerVisit) null);
    }

    private void btnRemoveEngineerVisit_Click(object sender, EventArgs e)
    {
      this.RemoveEngineerVisit();
    }

    private void btnAddRate_Click(object sender, EventArgs e)
    {
      int siteId = this.OnContol.Site.SiteID;
      DataView itemsAddedDataView = this.JobItemsAddedDataView;
      ref DataView local = ref itemsAddedDataView;
      FRMSiteScheduleOfRateList scheduleOfRateList1 = new FRMSiteScheduleOfRateList(siteId, ref local, false, true);
      this.JobItemsAddedDataView = itemsAddedDataView;
      using (FRMSiteScheduleOfRateList scheduleOfRateList2 = scheduleOfRateList1)
      {
        int num = (int) scheduleOfRateList2.ShowDialog();
      }
    }

    public void SetupJobItemsAddedDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobItemsAdded, false);
      DataGridTableStyle tableStyle = this.dgJobItemsAdded.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Summary";
      dataGridLabelColumn1.MappingName = "Summary";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 375;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Qty";
      dataGridLabelColumn2.MappingName = "Qty";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 50;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "JOB_ITEMS_ADDED";
      this.dgJobItemsAdded.TableStyles.Add(tableStyle);
    }

    public void Populate(int ID = 0)
    {
      ComboBox cboQualification = this.cboQualification;
      Combo.SetUpCombo(ref cboQualification, this.OnContol.DvEngineerLevels.Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification;
      ComboBox comboBox;
      if (this.OnContol.Site.SiteID > 0)
      {
        comboBox = this.cboPriority;
        Combo.SetUpCombo(ref comboBox, this.OnContol.DvCustomerPriorities.Table, "PriorityID", "Name", Enums.ComboValues.Please_Select);
        this.cboPriority = comboBox;
      }
      this.JobItemsAddedDataView = new DataView(new DataTable()
      {
        Columns = {
          new DataColumn("JobItemID"),
          new DataColumn("Summary"),
          new DataColumn("RateID"),
          new DataColumn("Qty"),
          new DataColumn("SystemLinkID")
        }
      });
      if (this.JobOfWork.JobOfWorkID == 0)
      {
        this.AddEngineerVisit((EngineerVisit) null);
        this.cboPriority.Enabled = true;
        comboBox = this.cboPriority;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(this.JobOfWork.Priority));
        this.cboPriority = comboBox;
      }
      else
      {
        this.tcEngineerVisits.TabPages.Clear();
        this.txtPONumber.Text = this.JobOfWork.PONumber;
        comboBox = this.cboPriority;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(this.JobOfWork.Priority));
        this.cboPriority = comboBox;
        comboBox = this.cboQualification;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(this.JobOfWork.QualificationID));
        this.cboQualification = comboBox;
        try
        {
          foreach (EngineerVisit engineerVisit in this.OnContol.EngineerVisits.Where<EngineerVisit>((Func<EngineerVisit, bool>) (x => x.JobOfWorkID == this.JobOfWork.JobOfWorkID)).ToList<EngineerVisit>())
          {
            this.AddEngineerVisit(engineerVisit);
            if (engineerVisit.StatusEnumID > 5)
              this.OnContol.cboJobType.Enabled = false;
            if (engineerVisit.StatusEnumID > 4)
            {
              if (this.JobOfWork.Priority > 0)
                this.cboPriority.Enabled = false;
              else
                this.cboPriority.Enabled = true;
            }
            if (engineerVisit.StatusEnumID >= 6)
            {
              this.btnSaveItem.Enabled = false;
              this.btnRemoveItem.Enabled = false;
              this.btnAddRate.Enabled = false;
            }
            else
            {
              this.btnSaveItem.Enabled = true;
              this.btnRemoveItem.Enabled = true;
              this.btnAddRate.Enabled = true;
            }
          }
        }
        finally
        {
          List<EngineerVisit>.Enumerator enumerator;
          enumerator.Dispose();
        }
        if (this.OnContol.Job.StatusEnumID >= 2)
        {
          this.btnAddEngineerVisit.Enabled = false;
          this.btnRemoveEngineerVisit.Enabled = false;
        }
      }
      if (this.OnContol.DvJobItems.Table.Rows.Count > 0)
      {
        DataRow[] dataRowArray = this.OnContol.DvJobItems.Table.Select("JobOfWorkID = " + Conversions.ToString(this.JobOfWork.JobOfWorkID));
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          DataRow row = this.JobItemsAddedDataView.Table.NewRow();
          row["JobItemID"] = RuntimeHelpers.GetObjectValue(dataRow["JobItemID"]);
          row["RateID"] = RuntimeHelpers.GetObjectValue(dataRow["RateID"]);
          row["Summary"] = RuntimeHelpers.GetObjectValue(dataRow["Summary"]);
          row["Qty"] = RuntimeHelpers.GetObjectValue(dataRow["Qty"]);
          row["SystemLinkID"] = RuntimeHelpers.GetObjectValue(dataRow["SystemLinkID"]);
          this.JobItemsAddedDataView.Table.Rows.Add(row);
          checked { ++index; }
        }
      }
      this.JobItemsAddedDataView.Sort = "Summary";
      this.JobItemState = Enums.FormState.Insert;
    }

    public bool Save()
    {
      bool flag;
      return flag;
    }

    public void AddEngineerVisit(EngineerVisit engineerVisit)
    {
      TabPage tabPage = new TabPage();
      tabPage.BackColor = Color.White;
      UCVisitBreakdown ucVisitBreakdown1 = new UCVisitBreakdown();
      ucVisitBreakdown1.OnControl = this;
      ucVisitBreakdown1.EngineerVisit = engineerVisit;
      ucVisitBreakdown1.Populate(0);
      if (engineerVisit == null)
      {
        UCVisitBreakdown ucVisitBreakdown2 = ucVisitBreakdown1;
        ComboBox cboStatus = ucVisitBreakdown2.cboStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
        ucVisitBreakdown2.cboStatus = cboStatus;
      }
      ucVisitBreakdown1.Dock = DockStyle.Fill;
      tabPage.Controls.Add((Control) ucVisitBreakdown1);
      this.tcEngineerVisits.TabPages.Add(tabPage);
      this.CheckTabs();
      this.tcEngineerVisits.SelectedTab = tabPage;
    }

    private void RemoveEngineerVisit()
    {
      if (((UCVisitBreakdown) this.tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.StatusEnumID > 4)
      {
        int num1 = (int) App.ShowMessage("This visit is either scheduled, on a PDA or completed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        ArrayList arrayList = new ArrayList();
        if (((UCVisitBreakdown) this.tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID > 0)
        {
          bool flag = false;
          DataView forEngineerVisit = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(((UCVisitBreakdown) this.tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID);
          IEnumerator enumerator1;
          if (forEngineerVisit.Table.Rows.Count > 0)
          {
            try
            {
              enumerator1 = forEngineerVisit.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                flag = true;
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          }
          if (flag)
          {
            int num2 = (int) App.ShowMessage("This visit has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          IEnumerator enumerator2;
          try
          {
            enumerator2 = arrayList.GetEnumerator();
            while (enumerator2.MoveNext())
              this.OnContol.EngineerVisitsOrdersRemoved.Add((object) Conversions.ToInteger(enumerator2.Current));
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          this.OnContol.EngineerVisitsRemoved.Add((object) ((UCVisitBreakdown) this.tcEngineerVisits.SelectedTab.Controls[0]).EngineerVisit.EngineerVisitID);
        }
        this.tcEngineerVisits.TabPages.Remove(this.tcEngineerVisits.SelectedTab);
        this.CheckTabs();
      }
    }

    private void CheckTabs()
    {
      if (this.tcEngineerVisits.TabPages.Count == 1)
        this.btnRemoveEngineerVisit.Enabled = false;
      else
        this.btnRemoveEngineerVisit.Enabled = true;
      int num = 1;
      IEnumerator enumerator;
      try
      {
        enumerator = this.tcEngineerVisits.TabPages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((TabPage) enumerator.Current).Text = "Visit #" + Conversions.ToString(num);
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (((UCVisitBreakdown) this.tcEngineerVisits.TabPages[checked (this.tcEngineerVisits.TabPages.Count - 1)].Controls[0]).EngineerVisit.StatusEnumID == 7)
        this.btnAddEngineerVisit.Enabled = true;
      else
        this.btnAddEngineerVisit.Enabled = false;
    }
  }
}
