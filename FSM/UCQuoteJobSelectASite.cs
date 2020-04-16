// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteJobSelectASite
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
  public class UCQuoteJobSelectASite : UCBase, IUserControl
  {
    private IContainer components;
    private DataView _Sites;

    public UCQuoteJobSelectASite()
    {
      this.Load += new EventHandler(this.UCQuoteJob_Load);
      this._Sites = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSites = new GroupBox();
      this.dgSites = new DataGrid();
      this.grpSites.SuspendLayout();
      this.dgSites.BeginInit();
      this.SuspendLayout();
      this.grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSites.Controls.Add((Control) this.dgSites);
      this.grpSites.Location = new System.Drawing.Point(8, 0);
      this.grpSites.Name = "grpSites";
      this.grpSites.Size = new Size(608, 288);
      this.grpSites.TabIndex = 28;
      this.grpSites.TabStop = false;
      this.grpSites.Text = "Select A Property For The Quote:";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(8, 26);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(592, 254);
      this.dgSites.TabIndex = 1;
      this.Controls.Add((Control) this.grpSites);
      this.Name = nameof (UCQuoteJobSelectASite);
      this.Size = new Size(624, 296);
      this.grpSites.ResumeLayout(false);
      this.dgSites.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupSiteDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.SelectedSiteDataRow;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCQuoteJobSelectASite.SiteSelectedEventHandler SiteSelected;

    public DataView Sites
    {
      get
      {
        return this._Sites;
      }
      set
      {
        this._Sites = value;
        this._Sites.Table.TableName = Enums.TableNames.tblSite.ToString();
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

    private void UCQuoteJob_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void SetupSiteDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSites, false);
      DataGridTableStyle tableStyle = this.dgSites.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address 1";
      dataGridLabelColumn1.MappingName = "Address1";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 2";
      dataGridLabelColumn2.MappingName = "Address2";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Postcode";
      dataGridLabelColumn3.MappingName = "Postcode";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "HO";
      dataGridLabelColumn4.MappingName = "HeadOfficeResult";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Region";
      dataGridLabelColumn5.MappingName = "Region";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSite.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
    }

    public void Populate(int ID = 0)
    {
      this.Sites = App.DB.Sites.GetForCustomer_Light(ID, App.loggedInUser.UserID);
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.SelectedSiteDataRow == null)
        {
          // ISSUE: reference to a compiler-generated field
          UCQuoteJobSelectASite.SiteSelectedEventHandler siteSelectedEvent = this.SiteSelectedEvent;
          if (siteSelectedEvent != null)
            siteSelectedEvent(0);
          flag = false;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          UCQuoteJobSelectASite.SiteSelectedEventHandler siteSelectedEvent = this.SiteSelectedEvent;
          if (siteSelectedEvent != null)
            siteSelectedEvent(Conversions.ToInteger(this.SelectedSiteDataRow["SiteID"]));
          flag = true;
        }
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

    public delegate void SiteSelectedEventHandler(int SiteID);
  }
}
