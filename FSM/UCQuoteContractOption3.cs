// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteContractOption3
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.QuoteContractOption3s;
using FSM.Entity.QuoteContractOption3Sites;
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
  public class UCQuoteContractOption3 : UCBase, IUserControl
  {
    private IContainer components;
    private QuoteContractOption3 _currentQuoteContractOption3;
    private int _IDToLinkTo;
    private DataView _Sites;
    private bool _loading;

    public UCQuoteContractOption3()
    {
      this.Load += new EventHandler(this.UCQuoteContractOption3_Load);
      this._IDToLinkTo = 0;
      this._loading = false;
      this.InitializeComponent();
      ComboBox cboContractStatus = this.cboContractStatus;
      Combo.SetUpCombo(ref cboContractStatus, DynamicDataTables.QuoteContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboContractStatus = cboContractStatus;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpQuoteContractOption3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQuoteContractDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuoteContractDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtContractPrice
    {
      get
      {
        return this._txtContractPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtQuoteContractPrice_LostFocus);
        TextBox txtContractPrice1 = this._txtContractPrice;
        if (txtContractPrice1 != null)
          txtContractPrice1.LostFocus -= eventHandler;
        this._txtContractPrice = value;
        TextBox txtContractPrice2 = this._txtContractPrice;
        if (txtContractPrice2 == null)
          return;
        txtContractPrice2.LostFocus += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractStatus
    {
      get
      {
        return this._cboContractStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQuoteContractStatusID_SelectedIndexChanged);
        ComboBox cboContractStatus1 = this._cboContractStatus;
        if (cboContractStatus1 != null)
          cboContractStatus1.SelectedIndexChanged -= eventHandler;
        this._cboContractStatus = value;
        ComboBox cboContractStatus2 = this._cboContractStatus;
        if (cboContractStatus2 == null)
          return;
        cboContractStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblContractStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpQuoteContractOption3 = new GroupBox();
      this.btnCalculatePrice = new Button();
      this.txtContractPrice = new TextBox();
      this.Label1 = new Label();
      this.lblMsg = new Label();
      this.gpbSite = new GroupBox();
      this.dgSites = new DataGrid();
      this.txtContractReference = new TextBox();
      this.lblContractReference = new Label();
      this.cboContractStatus = new ComboBox();
      this.lblContractStatus = new Label();
      this.dtpQuoteContractDate = new DateTimePicker();
      this.lblQuoteContractDate = new Label();
      this.grpQuoteContractOption3.SuspendLayout();
      this.gpbSite.SuspendLayout();
      this.dgSites.BeginInit();
      this.SuspendLayout();
      this.grpQuoteContractOption3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpQuoteContractOption3.Controls.Add((Control) this.btnCalculatePrice);
      this.grpQuoteContractOption3.Controls.Add((Control) this.txtContractPrice);
      this.grpQuoteContractOption3.Controls.Add((Control) this.Label1);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblMsg);
      this.grpQuoteContractOption3.Controls.Add((Control) this.gpbSite);
      this.grpQuoteContractOption3.Controls.Add((Control) this.txtContractReference);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblContractReference);
      this.grpQuoteContractOption3.Controls.Add((Control) this.cboContractStatus);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblContractStatus);
      this.grpQuoteContractOption3.Controls.Add((Control) this.dtpQuoteContractDate);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblQuoteContractDate);
      this.grpQuoteContractOption3.Location = new System.Drawing.Point(8, 8);
      this.grpQuoteContractOption3.Name = "grpQuoteContractOption3";
      this.grpQuoteContractOption3.Size = new Size(625, 594);
      this.grpQuoteContractOption3.TabIndex = 1;
      this.grpQuoteContractOption3.TabStop = false;
      this.grpQuoteContractOption3.Text = "Main Details";
      this.btnCalculatePrice.UseVisualStyleBackColor = true;
      this.btnCalculatePrice.Location = new System.Drawing.Point(348, 77);
      this.btnCalculatePrice.Name = "btnCalculatePrice";
      this.btnCalculatePrice.Size = new Size(266, 23);
      this.btnCalculatePrice.TabIndex = 57;
      this.btnCalculatePrice.Text = "Calculate Price From Property Price";
      this.txtContractPrice.Location = new System.Drawing.Point(136, 52);
      this.txtContractPrice.MaxLength = 100;
      this.txtContractPrice.Name = "txtContractPrice";
      this.txtContractPrice.Size = new Size(200, 21);
      this.txtContractPrice.TabIndex = 55;
      this.txtContractPrice.Tag = (object) "ContractOption3.ContractPrice";
      this.txtContractPrice.Text = "";
      this.Label1.Location = new System.Drawing.Point(14, 52);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(99, 20);
      this.Label1.TabIndex = 56;
      this.Label1.Text = "Quote Price";
      this.lblMsg.BackColor = Color.LightGoldenrodYellow;
      this.lblMsg.BorderStyle = BorderStyle.FixedSingle;
      this.lblMsg.Location = new System.Drawing.Point(16, 77);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(280, 23);
      this.lblMsg.TabIndex = 54;
      this.lblMsg.Text = "Please save before adding properties";
      this.lblMsg.TextAlign = ContentAlignment.MiddleLeft;
      this.gpbSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbSite.Controls.Add((Control) this.dgSites);
      this.gpbSite.Location = new System.Drawing.Point(10, 104);
      this.gpbSite.Name = "gpbSite";
      this.gpbSite.Size = new Size(603, 483);
      this.gpbSite.TabIndex = 53;
      this.gpbSite.TabStop = false;
      this.gpbSite.Text = "Properties";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(10, 27);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(584, 447);
      this.dgSites.TabIndex = 0;
      this.txtContractReference.Location = new System.Drawing.Point(136, 28);
      this.txtContractReference.MaxLength = 100;
      this.txtContractReference.Name = "txtContractReference";
      this.txtContractReference.Size = new Size(200, 21);
      this.txtContractReference.TabIndex = 49;
      this.txtContractReference.Tag = (object) "ContractOption3.ContractReference";
      this.txtContractReference.Text = "";
      this.lblContractReference.Location = new System.Drawing.Point(14, 29);
      this.lblContractReference.Name = "lblContractReference";
      this.lblContractReference.Size = new Size(118, 20);
      this.lblContractReference.TabIndex = 52;
      this.lblContractReference.Text = "Quote Reference";
      this.cboContractStatus.Cursor = Cursors.Hand;
      this.cboContractStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractStatus.Location = new System.Drawing.Point(455, 28);
      this.cboContractStatus.Name = "cboContractStatus";
      this.cboContractStatus.Size = new Size(158, 21);
      this.cboContractStatus.TabIndex = 50;
      this.cboContractStatus.Tag = (object) "ContractOption3.ContractStatus";
      this.lblContractStatus.Location = new System.Drawing.Point(348, 29);
      this.lblContractStatus.Name = "lblContractStatus";
      this.lblContractStatus.Size = new Size(99, 20);
      this.lblContractStatus.TabIndex = 51;
      this.lblContractStatus.Text = "Quote Status";
      this.dtpQuoteContractDate.Location = new System.Drawing.Point(455, 52);
      this.dtpQuoteContractDate.Name = "dtpQuoteContractDate";
      this.dtpQuoteContractDate.Size = new Size(158, 21);
      this.dtpQuoteContractDate.TabIndex = 5;
      this.dtpQuoteContractDate.Tag = (object) "QuoteContractOption3.QuoteContractDate";
      this.lblQuoteContractDate.Location = new System.Drawing.Point(348, 52);
      this.lblQuoteContractDate.Name = "lblQuoteContractDate";
      this.lblQuoteContractDate.Size = new Size(99, 20);
      this.lblQuoteContractDate.TabIndex = 31;
      this.lblQuoteContractDate.Text = "Quote Date";
      this.Controls.Add((Control) this.grpQuoteContractOption3);
      this.Name = nameof (UCQuoteContractOption3);
      this.Size = new Size(640, 616);
      this.grpQuoteContractOption3.ResumeLayout(false);
      this.gpbSite.ResumeLayout(false);
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
        return (object) this.CurrentQuoteContractOption3;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCQuoteContractOption3.RefreshButtonEventHandler RefreshButton;

    public QuoteContractOption3 CurrentQuoteContractOption3
    {
      get
      {
        return this._currentQuoteContractOption3;
      }
      set
      {
        this._currentQuoteContractOption3 = value;
        if (this._currentQuoteContractOption3 == null)
        {
          this._currentQuoteContractOption3 = new QuoteContractOption3();
          this._currentQuoteContractOption3.Exists = false;
        }
        if (this._currentQuoteContractOption3.Exists)
        {
          this.Loading = true;
          this.Populate(0);
          this.gpbSite.Enabled = true;
          this.lblMsg.Visible = false;
          this.Loading = false;
        }
        else
        {
          this.gpbSite.Enabled = false;
          this.lblMsg.Visible = true;
          this.txtContractPrice.Text = Strings.Format((object) 0.0, "C");
        }
        this.Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(this._currentQuoteContractOption3.QuoteContractID, this.IDToLinkTo);
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
        this._Sites.Table.TableName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
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
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property Reference";
      dataGridLabelColumn2.MappingName = "QuoteContractSiteReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Start Date";
      dataGridLabelColumn3.MappingName = "StartDate";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "End Date";
      dataGridLabelColumn4.MappingName = "EndDate";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Property Price";
      dataGridLabelColumn5.MappingName = "SitePrice";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgSites);
    }

    private void UCQuoteContractOption3_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupSitesDataGrid();
    }

    private void cboQuoteContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading | this.CurrentQuoteContractOption3 == null)
        return;
      if (!this.CurrentQuoteContractOption3.Exists & (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatus)) == 2 | Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatus)) == 3))
      {
        int num = (int) App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ComboBox cboContractStatus = this.cboContractStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboContractStatus, Conversions.ToString(1));
        this.cboContractStatus = cboContractStatus;
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatus)) == 2)
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
        App.ShowForm(typeof (FRMQuoteContractOption3Convert), true, new object[1]
        {
          (object) this.CurrentQuoteContractOption3.QuoteContractID
        }, false);
        if (App.DB.ContractOption3.ContractOption3_Get_For_Quote_ID(this.CurrentQuoteContractOption3.QuoteContractID) != null)
        {
          this.Loading = true;
          ComboBox cboContractStatus = this.cboContractStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboContractStatus, Conversions.ToString(2));
          this.cboContractStatus = cboContractStatus;
          this.Loading = false;
          this.Save();
          this.Populate(this.CurrentQuoteContractOption3.QuoteContractID);
        }
        else
        {
          ComboBox cboContractStatus = this.cboContractStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboContractStatus, Conversions.ToString(1));
          this.cboContractStatus = cboContractStatus;
          this.Save();
        }
      }
      else
      {
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatus)) != 3)
          return;
        App.ShowForm(typeof (FRMQuoteRejection), true, new object[2]
        {
          (object) this,
          (object) ""
        }, false);
        this.Populate(this.CurrentQuoteContractOption3.QuoteContractID);
      }
    }

    private void dgSites_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgSites.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgSites.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedSiteDataRow == null)
          return;
        if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0])))
        {
          this.Save();
          App.ShowForm(typeof (FRMQuoteContractOption3Site), true, new object[2]
          {
            (object) App.DB.QuoteContractOption3Site.Insert(new QuoteContractOption3Site()
            {
              SetQuoteContractID = (object) this.CurrentQuoteContractOption3.QuoteContractID,
              SetSiteID = RuntimeHelpers.GetObjectValue(this.SelectedSiteDataRow["SiteID"]),
              SetQuoteContractSiteReference = (object) App.DB.QuoteContractOption3Site.GetNextSiteReference(this.CurrentQuoteContractOption3.QuoteContractID)
            }).QuoteContractSiteID,
            (object) this
          }, false);
        }
        else if (App.ShowMessage("You are about to remove this property from the quote.\r\nDo you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && App.DB.QuoteContractOption3Site.Delete(Conversions.ToInteger(this.SelectedSiteDataRow["QuoteContractSiteID"])) > 0)
        {
          int num = (int) App.ShowMessage("Could not remove property from quote as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(this.CurrentQuoteContractOption3.QuoteContractID, this.IDToLinkTo);
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
        {
          App.ShowForm(typeof (FRMQuoteContractOption3Site), true, new object[2]
          {
            this.SelectedSiteDataRow["QuoteContractSiteID"],
            (object) this
          }, false);
        }
        else
        {
          this.Save();
          App.ShowForm(typeof (FRMQuoteContractOption3Site), true, new object[2]
          {
            (object) App.DB.QuoteContractOption3Site.Insert(new QuoteContractOption3Site()
            {
              SetQuoteContractID = (object) this.CurrentQuoteContractOption3.QuoteContractID,
              SetSiteID = RuntimeHelpers.GetObjectValue(this.SelectedSiteDataRow["SiteID"]),
              SetQuoteContractSiteReference = (object) App.DB.QuoteContractOption3Site.GetNextSiteReference(this.CurrentQuoteContractOption3.QuoteContractID)
            }).QuoteContractSiteID,
            (object) this
          }, false);
        }
        this.Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(this.CurrentQuoteContractOption3.QuoteContractID, this.IDToLinkTo);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
    {
      this.txtContractPrice.Text = this.txtContractPrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtContractPrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtContractPrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    public void RejectReasonChanged(string Reason, int ReasonID)
    {
      this.CurrentQuoteContractOption3.SetReasonForReject = (object) Reason;
      this.CurrentQuoteContractOption3.SetReasonForRejectID = (object) ReasonID;
      this.Save();
    }

    private void btnCalculatePrice_Click(object sender, EventArgs e)
    {
      if (this.CurrentQuoteContractOption3.QuoteContractID <= 0)
        return;
      this.txtContractPrice.Text = Strings.Format((object) App.DB.QuoteContractOption3.QuoteContractCalculatedTotal(this.CurrentQuoteContractOption3.QuoteContractID), "C");
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
      if (this.CurrentQuoteContractOption3.QuoteContractStatusID != 1)
        Helper.MakeReadOnly(this.grpQuoteContractOption3, true);
      else
        Helper.MakeReadOnly(this.grpQuoteContractOption3, false);
      this.txtContractReference.Text = this.CurrentQuoteContractOption3.QuoteContractReference;
      ComboBox cboContractStatus = this.cboContractStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboContractStatus, Conversions.ToString(this.CurrentQuoteContractOption3.QuoteContractStatusID));
      this.cboContractStatus = cboContractStatus;
      this.dtpQuoteContractDate.Value = this.CurrentQuoteContractOption3.QuoteContractDate;
      this.txtContractPrice.Text = Strings.Format((object) this.CurrentQuoteContractOption3.QuoteContractPrice, "C");
      // ISSUE: reference to a compiler-generated field
      UCQuoteContractOption3.RefreshButtonEventHandler refreshButtonEvent = this.RefreshButtonEvent;
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
        this.CurrentQuoteContractOption3.IgnoreExceptionsOnSetMethods = true;
        this.CurrentQuoteContractOption3.SetCustomerID = (object) this.IDToLinkTo;
        this.CurrentQuoteContractOption3.SetQuoteContractReference = (object) this.txtContractReference.Text.Trim();
        this.CurrentQuoteContractOption3.SetQuoteContractStatusID = (object) Combo.get_GetSelectedItemValue(this.cboContractStatus);
        this.CurrentQuoteContractOption3.QuoteContractDate = this.dtpQuoteContractDate.Value;
        this.CurrentQuoteContractOption3.SetQuoteContractPrice = (object) this.txtContractPrice.Text.Trim().Replace("£", "");
        new QuoteContractOption3Validator().Validate(this.CurrentQuoteContractOption3);
        if (this.CurrentQuoteContractOption3.Exists)
          App.DB.QuoteContractOption3.Update(this.CurrentQuoteContractOption3);
        else
          this.CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.Insert(this.CurrentQuoteContractOption3);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteContractOption3.QuoteContractID);
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
