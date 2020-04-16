// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteContractAlternative
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.QuoteContractAlternatives;
using FSM.Entity.QuoteContractAlternativeSites;
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
  public class UCQuoteContractAlternative : UCBase, IUserControl
  {
    private IContainer components;
    private QuoteContractAlternative _currentQuoteContract;
    private int _IDToLinkTo;
    private DataView _Sites;
    private bool _loading;

    public UCQuoteContractAlternative()
    {
      this.Load += new EventHandler(this.UCQuoteContract_Load);
      this._IDToLinkTo = 0;
      this._loading = false;
      this.InitializeComponent();
      ComboBox contractStatusId = this.cboQuoteContractStatusID;
      Combo.SetUpCombo(ref contractStatusId, DynamicDataTables.QuoteContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboQuoteContractStatusID = contractStatusId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpQuoteContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuoteContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuoteContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQuoteContractDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuoteContractDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQuoteContractStatusID
    {
      get
      {
        return this._cboQuoteContractStatusID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQuoteContractStatusID_SelectedIndexChanged);
        ComboBox contractStatusId1 = this._cboQuoteContractStatusID;
        if (contractStatusId1 != null)
          contractStatusId1.SelectedIndexChanged -= eventHandler;
        this._cboQuoteContractStatusID = value;
        ComboBox contractStatusId2 = this._cboQuoteContractStatusID;
        if (contractStatusId2 == null)
          return;
        contractStatusId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblQuoteContractStatusID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSites
    {
      get
      {
        return this._dgSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSites_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgSites_DoubleClick);
        DataGrid dgSites1 = this._dgSites;
        if (dgSites1 != null)
        {
          dgSites1.MouseUp -= mouseEventHandler;
          dgSites1.DoubleClick -= eventHandler;
        }
        this._dgSites = value;
        DataGrid dgSites2 = this._dgSites;
        if (dgSites2 == null)
          return;
        dgSites2.MouseUp += mouseEventHandler;
        dgSites2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label lblContractPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuoteContractPrice
    {
      get
      {
        return this._txtQuoteContractPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtQuoteContractPrice_LostFocus);
        TextBox quoteContractPrice1 = this._txtQuoteContractPrice;
        if (quoteContractPrice1 != null)
          quoteContractPrice1.LostFocus -= eventHandler;
        this._txtQuoteContractPrice = value;
        TextBox quoteContractPrice2 = this._txtQuoteContractPrice;
        if (quoteContractPrice2 == null)
          return;
        quoteContractPrice2.LostFocus += eventHandler;
      }
    }

    internal virtual Button btnCalculatePrice
    {
      get
      {
        return this._btnCalculatePrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCalculatePrice_Click);
        Button btnCalculatePrice1 = this._btnCalculatePrice;
        if (btnCalculatePrice1 != null)
          btnCalculatePrice1.Click -= eventHandler;
        this._btnCalculatePrice = value;
        Button btnCalculatePrice2 = this._btnCalculatePrice;
        if (btnCalculatePrice2 == null)
          return;
        btnCalculatePrice2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpQuoteContract = new GroupBox();
      this.btnCalculatePrice = new Button();
      this.txtQuoteContractPrice = new TextBox();
      this.lblContractPrice = new Label();
      this.lblMsg = new Label();
      this.grpSites = new GroupBox();
      this.dgSites = new DataGrid();
      this.txtQuoteContractReference = new TextBox();
      this.lblQuoteContractReference = new Label();
      this.dtpQuoteContractDate = new DateTimePicker();
      this.lblQuoteContractDate = new Label();
      this.dtpContractStart = new DateTimePicker();
      this.lblContractStart = new Label();
      this.dtpContractEnd = new DateTimePicker();
      this.lblContractEnd = new Label();
      this.cboQuoteContractStatusID = new ComboBox();
      this.lblQuoteContractStatusID = new Label();
      this.grpQuoteContract.SuspendLayout();
      this.grpSites.SuspendLayout();
      this.dgSites.BeginInit();
      this.SuspendLayout();
      this.grpQuoteContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpQuoteContract.Controls.Add((Control) this.btnCalculatePrice);
      this.grpQuoteContract.Controls.Add((Control) this.txtQuoteContractPrice);
      this.grpQuoteContract.Controls.Add((Control) this.lblContractPrice);
      this.grpQuoteContract.Controls.Add((Control) this.lblMsg);
      this.grpQuoteContract.Controls.Add((Control) this.grpSites);
      this.grpQuoteContract.Controls.Add((Control) this.txtQuoteContractReference);
      this.grpQuoteContract.Controls.Add((Control) this.lblQuoteContractReference);
      this.grpQuoteContract.Controls.Add((Control) this.dtpQuoteContractDate);
      this.grpQuoteContract.Controls.Add((Control) this.lblQuoteContractDate);
      this.grpQuoteContract.Controls.Add((Control) this.dtpContractStart);
      this.grpQuoteContract.Controls.Add((Control) this.lblContractStart);
      this.grpQuoteContract.Controls.Add((Control) this.dtpContractEnd);
      this.grpQuoteContract.Controls.Add((Control) this.lblContractEnd);
      this.grpQuoteContract.Controls.Add((Control) this.cboQuoteContractStatusID);
      this.grpQuoteContract.Controls.Add((Control) this.lblQuoteContractStatusID);
      this.grpQuoteContract.Location = new System.Drawing.Point(8, 8);
      this.grpQuoteContract.Name = "grpQuoteContract";
      this.grpQuoteContract.Size = new Size(739, 594);
      this.grpQuoteContract.TabIndex = 1;
      this.grpQuoteContract.TabStop = false;
      this.grpQuoteContract.Text = "Main Details";
      this.btnCalculatePrice.UseVisualStyleBackColor = true;
      this.btnCalculatePrice.Location = new System.Drawing.Point(476, 104);
      this.btnCalculatePrice.Name = "btnCalculatePrice";
      this.btnCalculatePrice.Size = new Size(195, 23);
      this.btnCalculatePrice.TabIndex = 7;
      this.btnCalculatePrice.Text = "Calculate Price From Property Price";
      this.txtQuoteContractPrice.Location = new System.Drawing.Point(476, 76);
      this.txtQuoteContractPrice.MaxLength = 9;
      this.txtQuoteContractPrice.Name = "txtQuoteContractPrice";
      this.txtQuoteContractPrice.Size = new Size(195, 21);
      this.txtQuoteContractPrice.TabIndex = 6;
      this.txtQuoteContractPrice.Tag = (object) "Contract.ContractPrice";
      this.txtQuoteContractPrice.Text = "";
      this.lblContractPrice.Location = new System.Drawing.Point(344, 76);
      this.lblContractPrice.Name = "lblContractPrice";
      this.lblContractPrice.Size = new Size(122, 21);
      this.lblContractPrice.TabIndex = 51;
      this.lblContractPrice.Text = "Total Contract Price";
      this.lblMsg.BackColor = Color.LightGoldenrodYellow;
      this.lblMsg.BorderStyle = BorderStyle.FixedSingle;
      this.lblMsg.Location = new System.Drawing.Point(16, 104);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(280, 23);
      this.lblMsg.TabIndex = 35;
      this.lblMsg.Text = "Please save before adding properties";
      this.lblMsg.TextAlign = ContentAlignment.MiddleLeft;
      this.grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSites.Controls.Add((Control) this.dgSites);
      this.grpSites.Location = new System.Drawing.Point(10, 134);
      this.grpSites.Name = "grpSites";
      this.grpSites.Size = new Size(712, 450);
      this.grpSites.TabIndex = 34;
      this.grpSites.TabStop = false;
      this.grpSites.Text = "Properties";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(11, 26);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(692, 404);
      this.dgSites.TabIndex = 2;
      this.txtQuoteContractReference.Location = new System.Drawing.Point(144, 25);
      this.txtQuoteContractReference.MaxLength = 100;
      this.txtQuoteContractReference.Name = "txtQuoteContractReference";
      this.txtQuoteContractReference.Size = new Size(177, 21);
      this.txtQuoteContractReference.TabIndex = 0;
      this.txtQuoteContractReference.Tag = (object) "QuoteContract.QuoteContractReference";
      this.txtQuoteContractReference.Text = "";
      this.lblQuoteContractReference.Location = new System.Drawing.Point(14, 25);
      this.lblQuoteContractReference.Name = "lblQuoteContractReference";
      this.lblQuoteContractReference.Size = new Size(134, 21);
      this.lblQuoteContractReference.TabIndex = 31;
      this.lblQuoteContractReference.Text = "Quote Contract Ref.";
      this.dtpQuoteContractDate.Location = new System.Drawing.Point(144, 49);
      this.dtpQuoteContractDate.Name = "dtpQuoteContractDate";
      this.dtpQuoteContractDate.Size = new Size(177, 21);
      this.dtpQuoteContractDate.TabIndex = 2;
      this.dtpQuoteContractDate.Tag = (object) "QuoteContract.QuoteContractDate";
      this.lblQuoteContractDate.Location = new System.Drawing.Point(14, 49);
      this.lblQuoteContractDate.Name = "lblQuoteContractDate";
      this.lblQuoteContractDate.Size = new Size(134, 21);
      this.lblQuoteContractDate.TabIndex = 31;
      this.lblQuoteContractDate.Text = "Quote Contract Date";
      this.dtpContractStart.Location = new System.Drawing.Point(476, 25);
      this.dtpContractStart.Name = "dtpContractStart";
      this.dtpContractStart.Size = new Size(195, 21);
      this.dtpContractStart.TabIndex = 4;
      this.dtpContractStart.Tag = (object) "QuoteContract.ContractStart";
      this.lblContractStart.Location = new System.Drawing.Point(344, 25);
      this.lblContractStart.Name = "lblContractStart";
      this.lblContractStart.Size = new Size(103, 21);
      this.lblContractStart.TabIndex = 31;
      this.lblContractStart.Text = "Contract Start";
      this.dtpContractEnd.Location = new System.Drawing.Point(476, 49);
      this.dtpContractEnd.Name = "dtpContractEnd";
      this.dtpContractEnd.Size = new Size(195, 21);
      this.dtpContractEnd.TabIndex = 5;
      this.dtpContractEnd.Tag = (object) "QuoteContract.ContractEnd";
      this.lblContractEnd.Location = new System.Drawing.Point(344, 49);
      this.lblContractEnd.Name = "lblContractEnd";
      this.lblContractEnd.Size = new Size(103, 21);
      this.lblContractEnd.TabIndex = 31;
      this.lblContractEnd.Text = "Contract End";
      this.cboQuoteContractStatusID.Cursor = Cursors.Hand;
      this.cboQuoteContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboQuoteContractStatusID.Location = new System.Drawing.Point(144, 76);
      this.cboQuoteContractStatusID.Name = "cboQuoteContractStatusID";
      this.cboQuoteContractStatusID.Size = new Size(177, 21);
      this.cboQuoteContractStatusID.TabIndex = 3;
      this.cboQuoteContractStatusID.Tag = (object) "QuoteContract.QuoteContractStatusID";
      this.lblQuoteContractStatusID.Location = new System.Drawing.Point(14, 76);
      this.lblQuoteContractStatusID.Name = "lblQuoteContractStatusID";
      this.lblQuoteContractStatusID.Size = new Size(134, 21);
      this.lblQuoteContractStatusID.TabIndex = 31;
      this.lblQuoteContractStatusID.Text = "Quote Contract Status";
      this.Controls.Add((Control) this.grpQuoteContract);
      this.Name = nameof (UCQuoteContractAlternative);
      this.Size = new Size(754, 616);
      this.grpQuoteContract.ResumeLayout(false);
      this.grpSites.ResumeLayout(false);
      this.dgSites.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentQuoteContract;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCQuoteContractAlternative.RefreshButtonEventHandler RefreshButton;

    public QuoteContractAlternative CurrentQuoteContract
    {
      get
      {
        return this._currentQuoteContract;
      }
      set
      {
        this._currentQuoteContract = value;
        if (this._currentQuoteContract == null)
        {
          this._currentQuoteContract = new QuoteContractAlternative();
          this._currentQuoteContract.Exists = false;
        }
        if (this._currentQuoteContract.Exists)
        {
          this.Loading = true;
          this.Populate(0);
          this.lblMsg.Visible = false;
          this.Loading = false;
        }
        else
        {
          this.lblMsg.Visible = true;
          this.txtQuoteContractPrice.Text = Strings.Format((object) 0.0, "C");
        }
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
        this.Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(this.CurrentQuoteContract.QuoteContractID, this.IDToLinkTo);
      }
    }

    private DataView Sites
    {
      get
      {
        return this._Sites;
      }
      set
      {
        this._Sites = value;
        this._Sites.Table.TableName = Enums.TableNames.tblQuoteContractSite.ToString();
        this._Sites.AllowNew = false;
        this._Sites.AllowEdit = false;
        this._Sites.AllowDelete = false;
        this.dgSites.DataSource = (object) this.Sites;
      }
    }

    private DataRow SelectedSiteDataRow
    {
      get
      {
        return this.dgSites.CurrentRowIndex != -1 ? this.Sites[this.dgSites.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private bool Loading
    {
      get
      {
        return this._loading;
      }
      set
      {
        this._loading = value;
      }
    }

    public void SetupSitesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSites, false);
      DataGridTableStyle tableStyle = this.dgSites.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgSites.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Property";
      dataGridLabelColumn1.MappingName = "Site";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 500;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property Price";
      dataGridLabelColumn2.MappingName = "SitePrice";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblQuoteContractSite.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgSites);
    }

    private void UCQuoteContract_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgSites_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if (this.CurrentQuoteContract.QuoteContractStatusID != 1)
          return;
        DataGrid.HitTestInfo hitTestInfo = this.dgSites.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgSites.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedSiteDataRow == null)
          return;
        if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0])))
        {
          this.Save();
          App.ShowForm(typeof (FRMQuoteContractAlternativeSite), true, new object[4]
          {
            (object) App.DB.QuoteContractAlternativeSite.Insert(new QuoteContractAlternativeSite()
            {
              SetQuoteContractID = (object) this.CurrentQuoteContract.QuoteContractID,
              SetSiteID = RuntimeHelpers.GetObjectValue(this.SelectedSiteDataRow["SiteID"])
            }).QuoteContractSiteID,
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentQuoteContract,
            (object) this
          }, false);
        }
        else if (App.ShowMessage("Are you sure you want to remove this property from the quote.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          App.DB.QuoteContractAlternativeSite.Delete(Conversions.ToInteger(this.SelectedSiteDataRow["QuoteContractSiteID"]));
        this.Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(this.CurrentQuoteContract.QuoteContractID, this.IDToLinkTo);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSites_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedSiteDataRow == null)
          return;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0])))
          App.ShowForm(typeof (FRMQuoteContractAlternativeSite), true, new object[4]
          {
            this.SelectedSiteDataRow["QuoteContractSiteID"],
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentQuoteContract,
            (object) this
          }, false);
        else if (this.CurrentQuoteContract.QuoteContractStatusID == 1)
          App.ShowForm(typeof (FRMQuoteContractAlternativeSite), true, new object[4]
          {
            (object) 0,
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentQuoteContract,
            (object) this
          }, false);
        this.Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(this.CurrentQuoteContract.QuoteContractID, this.IDToLinkTo);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void cboQuoteContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading | this.CurrentQuoteContract == null)
        return;
      if (!this.CurrentQuoteContract.Exists & (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteContractStatusID)) == 2 | Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteContractStatusID)) == 3))
      {
        int num = (int) App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ComboBox contractStatusId = this.cboQuoteContractStatusID;
        Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(1));
        this.cboQuoteContractStatusID = contractStatusId;
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteContractStatusID)) == 2)
      {
        switch ((MsgBoxResult) App.ShowMessage("You are converting this quote to a live contract.\r\nDo you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
        {
          case MsgBoxResult.Cancel:
            return;
          case MsgBoxResult.Yes:
            if (!this.Save())
              return;
            break;
        }
        App.ShowForm(typeof (FRMQuoteContractAlternativeConvert), true, new object[1]
        {
          (object) this.CurrentQuoteContract.QuoteContractID
        }, false);
        if (App.DB.ContractAlternative.Get_For_Quote_ID(this.CurrentQuoteContract.QuoteContractID) != null)
        {
          this.Loading = true;
          ComboBox contractStatusId = this.cboQuoteContractStatusID;
          Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(2));
          this.cboQuoteContractStatusID = contractStatusId;
          this.Loading = false;
          this.Save();
          this.Populate(this.CurrentQuoteContract.QuoteContractID);
        }
        else
        {
          ComboBox contractStatusId = this.cboQuoteContractStatusID;
          Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(1));
          this.cboQuoteContractStatusID = contractStatusId;
          this.Save();
        }
      }
      else
      {
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQuoteContractStatusID)) != 3)
          return;
        App.ShowForm(typeof (FRMQuoteRejection), true, new object[2]
        {
          (object) this,
          (object) ""
        }, false);
        this.Populate(this.CurrentQuoteContract.QuoteContractID);
      }
    }

    private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
    {
      this.txtQuoteContractPrice.Text = this.txtQuoteContractPrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtQuoteContractPrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtQuoteContractPrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    public void RejectReasonChanged(string Reason, int ReasonID)
    {
      this.CurrentQuoteContract.SetReasonForReject = (object) Reason;
      this.CurrentQuoteContract.SetReasonForRejectID = (object) ReasonID;
      this.Save();
    }

    private void btnCalculatePrice_Click(object sender, EventArgs e)
    {
      if (this.CurrentQuoteContract.QuoteContractID <= 0)
        return;
      this.txtQuoteContractPrice.Text = Strings.Format((object) App.DB.QuoteContractAlternative.CalculatedTotal(this.CurrentQuoteContract.QuoteContractID), "C");
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteContract = App.DB.QuoteContractAlternative.Get(ID);
      if (this.CurrentQuoteContract.QuoteContractStatusID != 1)
        Helper.MakeReadOnly(this.grpQuoteContract, true);
      else
        Helper.MakeReadOnly(this.grpQuoteContract, false);
      this.txtQuoteContractReference.Text = this.CurrentQuoteContract.QuoteContractReference;
      this.dtpQuoteContractDate.Value = this.CurrentQuoteContract.QuoteContractDate;
      this.dtpContractStart.Value = this.CurrentQuoteContract.ContractStart;
      this.dtpContractEnd.Value = this.CurrentQuoteContract.ContractEnd;
      ComboBox contractStatusId = this.cboQuoteContractStatusID;
      Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(this.CurrentQuoteContract.QuoteContractStatusID));
      this.cboQuoteContractStatusID = contractStatusId;
      this.txtQuoteContractPrice.Text = Strings.Format((object) this.CurrentQuoteContract.QuoteContractPrice, "C");
      this.txtQuoteContractPrice.Text = Strings.Format((object) this.CurrentQuoteContract.QuoteContractPrice, "C");
      // ISSUE: reference to a compiler-generated field
      UCQuoteContractAlternative.RefreshButtonEventHandler refreshButtonEvent = this.RefreshButtonEvent;
      if (refreshButtonEvent == null)
        return;
      refreshButtonEvent();
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentQuoteContract.IgnoreExceptionsOnSetMethods = true;
        this.CurrentQuoteContract.SetCustomerID = (object) this.IDToLinkTo;
        this.CurrentQuoteContract.SetQuoteContractReference = (object) this.txtQuoteContractReference.Text.Trim();
        this.CurrentQuoteContract.QuoteContractDate = this.dtpQuoteContractDate.Value;
        this.CurrentQuoteContract.ContractStart = this.dtpContractStart.Value;
        this.CurrentQuoteContract.ContractEnd = this.dtpContractEnd.Value;
        this.CurrentQuoteContract.SetQuoteContractStatusID = (object) Combo.get_GetSelectedItemValue(this.cboQuoteContractStatusID);
        this.CurrentQuoteContract.SetQuoteContractPrice = (object) this.txtQuoteContractPrice.Text.Trim().Replace("£", "");
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.CurrentQuoteContract.ReasonForReject, "", false) == 0 & this.CurrentQuoteContract.QuoteContractStatusID == 3)
          this.CurrentQuoteContract.SetQuoteContractStatusID = (object) 1;
        if (this.CurrentQuoteContract.QuoteContractStatusID == 2 & App.DB.ContractAlternative.Get_For_Quote_ID(this.CurrentQuoteContract.QuoteContractID) == null)
          this.CurrentQuoteContract.SetQuoteContractStatusID = (object) 1;
        new QuoteContractAlternativeValidator().Validate(this.CurrentQuoteContract);
        if (this.CurrentQuoteContract.Exists)
          App.DB.QuoteContractAlternative.Update(this.CurrentQuoteContract);
        else
          this.CurrentQuoteContract = App.DB.QuoteContractAlternative.Insert(this.CurrentQuoteContract);
        this.Populate(0);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteContract.QuoteContractID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    public delegate void RefreshButtonEventHandler();
  }
}
