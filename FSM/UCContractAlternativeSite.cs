// Decompiled with JetBrains decompiler
// Type: FSM.UCContractAlternativeSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractAlternativePPMVisits;
using FSM.Entity.ContractAlternativeSiteAssets;
using FSM.Entity.ContractAlternativeSiteJobItems;
using FSM.Entity.ContractAlternativeSiteJobOfWorks;
using FSM.Entity.ContractAlternativeSites;
using FSM.Entity.ContractsAlternative;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class UCContractAlternativeSite : UCBase, IUserControl
  {
    private IContainer components;
    private ContractAlternativeSite _currentContractSite;
    private int _SiteID;
    private ContractAlternative _CurrentContract;
    private DataView _Assets;
    private DataView _JobItems;

    public UCContractAlternativeSite()
    {
      this.Load += new EventHandler(this.UCContractSite_Load);
      this._SiteID = 0;
      this.InitializeComponent();
      this.SetupAssetsDataGrid();
      this.SetupJobItemsDataGrid();
      ComboBox visitFrequencyId = this.cboVisitFrequencyID;
      Combo.SetUpCombo(ref visitFrequencyId, DynamicDataTables.VisitFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboVisitFrequencyID = visitFrequencyId;
      ComboBox cboVisitDuration = this.cboVisitDuration;
      Combo.SetUpCombo(ref cboVisitDuration, DynamicDataTables.VisitDuration, "VisitDuration", "DisplayMember", Enums.ComboValues.None);
      this.cboVisitDuration = cboVisitDuration;
      this.cboVisitDuration.SelectedIndex = 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContractSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets
    {
      get
      {
        return this._dgAssets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgAssets_MouseUp);
        DataGrid dgAssets1 = this._dgAssets;
        if (dgAssets1 != null)
          dgAssets1.MouseUp -= mouseEventHandler;
        this._dgAssets = value;
        DataGrid dgAssets2 = this._dgAssets;
        if (dgAssets2 == null)
          return;
        dgAssets2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual GroupBox grpVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPricePerVisit
    {
      get
      {
        return this._txtPricePerVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPricePerVisit_LostFocus);
        TextBox txtPricePerVisit1 = this._txtPricePerVisit;
        if (txtPricePerVisit1 != null)
          txtPricePerVisit1.LostFocus -= eventHandler;
        this._txtPricePerVisit = value;
        TextBox txtPricePerVisit2 = this._txtPricePerVisit;
        if (txtPricePerVisit2 == null)
          return;
        txtPricePerVisit2.LostFocus += eventHandler;
      }
    }

    internal virtual ComboBox cboVisitDuration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPricePerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgJobItems
    {
      get
      {
        return this._dgJobItems;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgJobItems_MouseUp);
        DataGrid dgJobItems1 = this._dgJobItems;
        if (dgJobItems1 != null)
          dgJobItems1.MouseUp -= mouseEventHandler;
        this._dgJobItems = value;
        DataGrid dgJobItems2 = this._dgJobItems;
        if (dgJobItems2 == null)
          return;
        dgJobItems2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Button btnAddToJobOfWork
    {
      get
      {
        return this._btnAddToJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddToJobOfWork_Click);
        Button btnAddToJobOfWork1 = this._btnAddToJobOfWork;
        if (btnAddToJobOfWork1 != null)
          btnAddToJobOfWork1.Click -= eventHandler;
        this._btnAddToJobOfWork = value;
        Button btnAddToJobOfWork2 = this._btnAddToJobOfWork;
        if (btnAddToJobOfWork2 == null)
          return;
        btnAddToJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual TabControl TCJobsOfWork { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveJobOfWork
    {
      get
      {
        return this._btnRemoveJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveJobOfWork_Click);
        Button btnRemoveJobOfWork1 = this._btnRemoveJobOfWork;
        if (btnRemoveJobOfWork1 != null)
          btnRemoveJobOfWork1.Click -= eventHandler;
        this._btnRemoveJobOfWork = value;
        Button btnRemoveJobOfWork2 = this._btnRemoveJobOfWork;
        if (btnRemoveJobOfWork2 == null)
          return;
        btnRemoveJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddJobOfWork
    {
      get
      {
        return this._btnAddJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddJobOfWork_Click);
        Button btnAddJobOfWork1 = this._btnAddJobOfWork;
        if (btnAddJobOfWork1 != null)
          btnAddJobOfWork1.Click -= eventHandler;
        this._btnAddJobOfWork = value;
        Button btnAddJobOfWork2 = this._btnAddJobOfWork;
        if (btnAddJobOfWork2 == null)
          return;
        btnAddJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtDescriptionItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpJobItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobItemAdd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContractSite = new GroupBox();
      this.gpJobItems = new GroupBox();
      this.dgJobItems = new DataGrid();
      this.btnAddToJobOfWork = new Button();
      this.btnRemove = new Button();
      this.txtSite = new TextBox();
      this.lblSite = new Label();
      this.grpVisits = new GroupBox();
      this.btnRemoveJobOfWork = new Button();
      this.btnAddJobOfWork = new Button();
      this.TCJobsOfWork = new TabControl();
      this.grpJobItemAdd = new GroupBox();
      this.cboVisitDuration = new ComboBox();
      this.cboVisitFrequencyID = new ComboBox();
      this.lblPricePerVisit = new Label();
      this.Label2 = new Label();
      this.txtDescriptionItem = new TextBox();
      this.lblVisitFrequencyID = new Label();
      this.btnAdd = new Button();
      this.txtPricePerVisit = new TextBox();
      this.Label1 = new Label();
      this.dgAssets = new DataGrid();
      this.grpJobItems = new GroupBox();
      this.grpContractSite.SuspendLayout();
      this.gpJobItems.SuspendLayout();
      this.dgJobItems.BeginInit();
      this.grpVisits.SuspendLayout();
      this.grpJobItemAdd.SuspendLayout();
      this.dgAssets.BeginInit();
      this.SuspendLayout();
      this.grpContractSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContractSite.Controls.Add((Control) this.gpJobItems);
      this.grpContractSite.Controls.Add((Control) this.txtSite);
      this.grpContractSite.Controls.Add((Control) this.lblSite);
      this.grpContractSite.Controls.Add((Control) this.grpVisits);
      this.grpContractSite.Controls.Add((Control) this.grpJobItemAdd);
      this.grpContractSite.Location = new System.Drawing.Point(7, 3);
      this.grpContractSite.Name = "grpContractSite";
      this.grpContractSite.Size = new Size(971, 664);
      this.grpContractSite.TabIndex = 1;
      this.grpContractSite.TabStop = false;
      this.grpContractSite.Text = "Main Details";
      this.gpJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpJobItems.Controls.Add((Control) this.dgJobItems);
      this.gpJobItems.Controls.Add((Control) this.btnAddToJobOfWork);
      this.gpJobItems.Controls.Add((Control) this.btnRemove);
      this.gpJobItems.Location = new System.Drawing.Point(10, 146);
      this.gpJobItems.Name = "gpJobItems";
      this.gpJobItems.Size = new Size(949, 107);
      this.gpJobItems.TabIndex = 3;
      this.gpJobItems.TabStop = false;
      this.gpJobItems.Text = "Job Items ";
      this.dgJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgJobItems.DataMember = "";
      this.dgJobItems.HeaderForeColor = SystemColors.ControlText;
      this.dgJobItems.Location = new System.Drawing.Point(8, 17);
      this.dgJobItems.Name = "dgJobItems";
      this.dgJobItems.Size = new Size(809, 85);
      this.dgJobItems.TabIndex = 1;
      this.btnAddToJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddToJobOfWork.UseVisualStyleBackColor = true;
      this.btnAddToJobOfWork.Location = new System.Drawing.Point(820, 77);
      this.btnAddToJobOfWork.Name = "btnAddToJobOfWork";
      this.btnAddToJobOfWork.Size = new Size(124, 23);
      this.btnAddToJobOfWork.TabIndex = 2;
      this.btnAddToJobOfWork.Text = "Add To Job Of Work";
      this.btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Location = new System.Drawing.Point(820, 17);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(124, 23);
      this.btnRemove.TabIndex = 0;
      this.btnRemove.Text = "Remove";
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Location = new System.Drawing.Point(70, 18);
      this.txtSite.Multiline = true;
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.ScrollBars = ScrollBars.Vertical;
      this.txtSite.Size = new Size(887, 21);
      this.txtSite.TabIndex = 0;
      this.txtSite.Text = "";
      this.lblSite.Location = new System.Drawing.Point(15, 21);
      this.lblSite.Name = "lblSite";
      this.lblSite.Size = new Size(52, 19);
      this.lblSite.TabIndex = 33;
      this.lblSite.Text = "Property";
      this.grpVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVisits.Controls.Add((Control) this.btnRemoveJobOfWork);
      this.grpVisits.Controls.Add((Control) this.btnAddJobOfWork);
      this.grpVisits.Controls.Add((Control) this.TCJobsOfWork);
      this.grpVisits.Location = new System.Drawing.Point(10, 254);
      this.grpVisits.Name = "grpVisits";
      this.grpVisits.Size = new Size(949, 403);
      this.grpVisits.TabIndex = 4;
      this.grpVisits.TabStop = false;
      this.grpVisits.Text = "Jobs Of Work";
      this.btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work";
      this.btnRemoveJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRemoveJobOfWork.UseVisualStyleBackColor = true;
      this.btnRemoveJobOfWork.Location = new System.Drawing.Point(914, 16);
      this.btnRemoveJobOfWork.Name = "btnRemoveJobOfWork";
      this.btnRemoveJobOfWork.Size = new Size(24, 23);
      this.btnRemoveJobOfWork.TabIndex = 2;
      this.btnRemoveJobOfWork.Text = "-";
      this.btnAddJobOfWork.AccessibleDescription = "Add Job Of Work";
      this.btnAddJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddJobOfWork.UseVisualStyleBackColor = true;
      this.btnAddJobOfWork.Location = new System.Drawing.Point(882, 16);
      this.btnAddJobOfWork.Name = "btnAddJobOfWork";
      this.btnAddJobOfWork.Size = new Size(24, 23);
      this.btnAddJobOfWork.TabIndex = 1;
      this.btnAddJobOfWork.Text = "+";
      this.TCJobsOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TCJobsOfWork.Location = new System.Drawing.Point(8, 17);
      this.TCJobsOfWork.Name = "TCJobsOfWork";
      this.TCJobsOfWork.SelectedIndex = 0;
      this.TCJobsOfWork.Size = new Size(933, 381);
      this.TCJobsOfWork.TabIndex = 0;
      this.grpJobItemAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobItemAdd.Controls.Add((Control) this.cboVisitDuration);
      this.grpJobItemAdd.Controls.Add((Control) this.cboVisitFrequencyID);
      this.grpJobItemAdd.Controls.Add((Control) this.lblPricePerVisit);
      this.grpJobItemAdd.Controls.Add((Control) this.Label2);
      this.grpJobItemAdd.Controls.Add((Control) this.txtDescriptionItem);
      this.grpJobItemAdd.Controls.Add((Control) this.lblVisitFrequencyID);
      this.grpJobItemAdd.Controls.Add((Control) this.btnAdd);
      this.grpJobItemAdd.Controls.Add((Control) this.txtPricePerVisit);
      this.grpJobItemAdd.Controls.Add((Control) this.Label1);
      this.grpJobItemAdd.Controls.Add((Control) this.dgAssets);
      this.grpJobItemAdd.Location = new System.Drawing.Point(10, 41);
      this.grpJobItemAdd.Name = "grpJobItemAdd";
      this.grpJobItemAdd.Size = new Size(949, 106);
      this.grpJobItemAdd.TabIndex = 2;
      this.grpJobItemAdd.TabStop = false;
      this.grpJobItemAdd.Text = "Add Job Items";
      this.cboVisitDuration.Cursor = Cursors.Hand;
      this.cboVisitDuration.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitDuration.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cboVisitDuration.ItemHeight = 13;
      this.cboVisitDuration.Location = new System.Drawing.Point(360, 52);
      this.cboVisitDuration.Name = "cboVisitDuration";
      this.cboVisitDuration.Size = new Size(95, 21);
      this.cboVisitDuration.TabIndex = 2;
      this.cboVisitDuration.Tag = (object) "ContractSite.VisitDuration";
      this.cboVisitFrequencyID.Cursor = Cursors.Hand;
      this.cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitFrequencyID.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cboVisitFrequencyID.ItemHeight = 13;
      this.cboVisitFrequencyID.Location = new System.Drawing.Point((int) sbyte.MaxValue, 52);
      this.cboVisitFrequencyID.Name = "cboVisitFrequencyID";
      this.cboVisitFrequencyID.Size = new Size(136, 21);
      this.cboVisitFrequencyID.TabIndex = 1;
      this.cboVisitFrequencyID.Tag = (object) "ContractSite.VisitFrequencyID";
      this.lblPricePerVisit.BackColor = Color.White;
      this.lblPricePerVisit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPricePerVisit.Location = new System.Drawing.Point(9, 82);
      this.lblPricePerVisit.Name = "lblPricePerVisit";
      this.lblPricePerVisit.Size = new Size(118, 20);
      this.lblPricePerVisit.TabIndex = 31;
      this.lblPricePerVisit.Text = "Item Price Per Visit";
      this.lblPricePerVisit.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.BackColor = Color.White;
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(9, 19);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(71, 20);
      this.Label2.TabIndex = 39;
      this.Label2.Text = "Description";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.txtDescriptionItem.Location = new System.Drawing.Point((int) sbyte.MaxValue, 19);
      this.txtDescriptionItem.Multiline = true;
      this.txtDescriptionItem.Name = "txtDescriptionItem";
      this.txtDescriptionItem.ScrollBars = ScrollBars.Vertical;
      this.txtDescriptionItem.Size = new Size(328, 25);
      this.txtDescriptionItem.TabIndex = 0;
      this.txtDescriptionItem.Text = "";
      this.lblVisitFrequencyID.BackColor = Color.White;
      this.lblVisitFrequencyID.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVisitFrequencyID.Location = new System.Drawing.Point(9, 52);
      this.lblVisitFrequencyID.Name = "lblVisitFrequencyID";
      this.lblVisitFrequencyID.Size = new Size(94, 20);
      this.lblVisitFrequencyID.TabIndex = 31;
      this.lblVisitFrequencyID.Text = "Visit Frequency";
      this.lblVisitFrequencyID.TextAlign = ContentAlignment.MiddleLeft;
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Location = new System.Drawing.Point(887, 76);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(53, 23);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "Add";
      this.txtPricePerVisit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPricePerVisit.Location = new System.Drawing.Point((int) sbyte.MaxValue, 82);
      this.txtPricePerVisit.MaxLength = 9;
      this.txtPricePerVisit.Name = "txtPricePerVisit";
      this.txtPricePerVisit.Size = new Size(136, 21);
      this.txtPricePerVisit.TabIndex = 3;
      this.txtPricePerVisit.Tag = (object) "ContractSite.PricePerVisit";
      this.txtPricePerVisit.Text = "";
      this.Label1.BackColor = Color.White;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(273, 52);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(82, 20);
      this.Label1.TabIndex = 37;
      this.Label1.Text = "Visit Duration";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(458, 13);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(427, 86);
      this.dgAssets.TabIndex = 4;
      this.grpJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobItems.Location = new System.Drawing.Point(10, 88);
      this.grpJobItems.Name = "grpJobItems";
      this.grpJobItems.Size = new Size(603, 230);
      this.grpJobItems.TabIndex = 35;
      this.grpJobItems.TabStop = false;
      this.grpJobItems.Text = "Job Items";
      this.Controls.Add((Control) this.grpContractSite);
      this.Name = nameof (UCContractAlternativeSite);
      this.Size = new Size(983, 675);
      this.grpContractSite.ResumeLayout(false);
      this.gpJobItems.ResumeLayout(false);
      this.dgJobItems.EndInit();
      this.grpVisits.ResumeLayout(false);
      this.grpJobItemAdd.ResumeLayout(false);
      this.dgAssets.EndInit();
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
        return (object) this.CurrentContractSite;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public ContractAlternativeSite CurrentContractSite
    {
      get
      {
        return this._currentContractSite;
      }
      set
      {
        this._currentContractSite = value;
        this.txtPricePerVisit.Text = "£0.00";
        if (this.CurrentContractSite == null)
        {
          this.CurrentContractSite = new ContractAlternativeSite();
          this.CurrentContractSite.Exists = false;
        }
        if (this.CurrentContractSite.Exists)
          this.Populate(0);
        else
          this.AddJobOfWork((ContractAlternativeSiteJobOfWork) null);
        FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
        FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) this.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        this.txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site2.Address1 + ", " + site2.Address2 + ", " + site2.Address3 + ", " + site2.Address4 + ", " + site2.Address5 + ", " + site2.Postcode + ".", ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary);
        this.JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
      }
    }

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
      }
    }

    public ContractAlternative CurrentContract
    {
      get
      {
        return this._CurrentContract;
      }
      set
      {
        this._CurrentContract = value;
      }
    }

    private DataView Assets
    {
      get
      {
        return this._Assets;
      }
      set
      {
        this._Assets = value;
        this._Assets.Table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
        this._Assets.AllowNew = false;
        this._Assets.AllowEdit = true;
        this._Assets.AllowDelete = false;
        this.dgAssets.DataSource = (object) this.Assets;
      }
    }

    private DataRow SelectedAssetDataRow
    {
      get
      {
        return this.dgAssets.CurrentRowIndex != -1 ? this.Assets[this.dgAssets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView JobItems
    {
      get
      {
        return this._JobItems;
      }
      set
      {
        this._JobItems = value;
        this._JobItems.AllowDelete = false;
        this._JobItems.AllowEdit = false;
        this._JobItems.AllowNew = false;
        this.dgJobItems.DataSource = (object) this.JobItems;
      }
    }

    private DataRow SelectedJobItemDataRow
    {
      get
      {
        return this.dgJobItems.CurrentRowIndex != -1 ? this.JobItems[this.dgJobItems.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupAssetsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAssets.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 90;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial Number";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 90;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractSiteAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    public void SetupJobItemsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobItems, false);
      DataGridTableStyle tableStyle = this.dgJobItems.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Description";
      dataGridLabelColumn1.MappingName = "Description";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Item Price Per Visit";
      dataGridLabelColumn2.MappingName = "ItemPricePerVisit";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Visit Frequency";
      dataGridLabelColumn3.MappingName = "VisitFrequency";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 110;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Visit Duration";
      dataGridLabelColumn4.MappingName = "VisitDuration";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 90;
      dataGridLabelColumn4.NullText = "";
      dataGridLabelColumn4.Alignment = HorizontalAlignment.Center;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Appliances";
      dataGridLabelColumn5.MappingName = "Assets";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 130;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
      this.dgJobItems.TableStyles.Add(tableStyle);
    }

    private void UCContractSite_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgAssets_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgAssets.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
        this.dgAssets.CurrentRowIndex = hitTestInfo.Row;
      if (hitTestInfo.Column != 0)
        return;
      this.Assets.Table.Rows[this.dgAssets.CurrentRowIndex]["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgAssets[this.dgAssets.CurrentRowIndex, 0]));
    }

    private void txtPricePerVisit_LostFocus(object sender, EventArgs e)
    {
      this.txtPricePerVisit.Text = this.txtPricePerVisit.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtPricePerVisit.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtPricePerVisit.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems = new FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems();
        oContractAlternativeSiteJobItems.SetDescription = (object) this.txtDescriptionItem.Text.Trim().Trim();
        oContractAlternativeSiteJobItems.SetItemPricePerVisit = (object) this.txtPricePerVisit.Text.Trim().Replace("£", "");
        oContractAlternativeSiteJobItems.SetVisitFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID);
        oContractAlternativeSiteJobItems.SetVisitDuration = (object) Combo.get_GetSelectedItemValue(this.cboVisitDuration);
        oContractAlternativeSiteJobItems.SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID;
        new ContractAlternativeSiteJobItemsValidator().Validate(oContractAlternativeSiteJobItems);
        FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems alternativeSiteJobItems = App.DB.ContractAlternativeSiteJobItems.Insert(oContractAlternativeSiteJobItems);
        App.DB.ContractAlternativeSiteAsset.Delete(this.CurrentContractSite.ContractSiteID);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.Assets.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
              App.DB.ContractAlternativeSiteAsset.Insert(new ContractAlternativeSiteAsset()
              {
                SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
                SetContractSiteJobItemID = (object) alternativeSiteJobItems.ContractSiteJobItemID
              });
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this.JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
        this.txtDescriptionItem.Text = "";
        ComboBox cboVisitDuration = this.cboVisitDuration;
        Combo.SetSelectedComboItem_By_Value(ref cboVisitDuration, Conversions.ToString(1));
        this.cboVisitDuration = cboVisitDuration;
        ComboBox visitFrequencyId = this.cboVisitFrequencyID;
        Combo.SetSelectedComboItem_By_Value(ref visitFrequencyId, Conversions.ToString(0));
        this.cboVisitFrequencyID = visitFrequencyId;
        this.txtPricePerVisit.Text = "£0.00";
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.Assets.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
            ((DataRow) enumerator2.Current)["Tick"] = (object) false;
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void dgJobItems_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgJobItems.HitTest(e.X, e.Y);
      if (this.SelectedJobItemDataRow == null || hitTestInfo.Column != 4)
        return;
      App.ShowForm(typeof (FRMJobItemAssets), true, new object[1]
      {
        this.SelectedJobItemDataRow["ContractSiteJobItemID"]
      }, false);
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobItemDataRow == null)
        return;
      App.DB.ContractAlternativeSiteJobItems.Delete(Conversions.ToInteger(this.SelectedJobItemDataRow["ContractSiteJobItemID"]));
      this.JobItems.Table.Rows.Remove(this.SelectedJobItemDataRow);
    }

    private void btnAddJobOfWork_Click(object sender, EventArgs e)
    {
      this.AddJobOfWork((ContractAlternativeSiteJobOfWork) null);
    }

    private void btnRemoveJobOfWork_Click(object sender, EventArgs e)
    {
      this.RemoveJobOfWork();
    }

    private void btnAddToJobOfWork_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobItemDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select an item to add.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.TCJobsOfWork.TabPages.Count == 0)
      {
        int num2 = (int) App.ShowMessage("Please add a 'Job Of Work' tab page first.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).Visits.Table.Rows.Count > 0)
      {
        int num3 = (int) App.ShowMessage("Work has been scheduled so no more items can be added.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows[0]["VisitFrequencyID"], this.SelectedJobItemDataRow["VisitFrequencyID"], false))
      {
        int num4 = (int) App.ShowMessage("All 'Job Items' on a 'Job Of Work' must have the same visit frequency", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.ContractAlternativeSiteJobItems.Update(Conversions.ToInteger(this.SelectedJobItemDataRow["ContractSiteJobitemID"]), ((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
        this.JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
        ((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView = App.DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
        ((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CalculateItemTotal();
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
      {
        this.CurrentContractSite = App.DB.ContractAlternativeSite.Get(ID);
        this.SiteID = this.CurrentContractSite.PropertyID;
        this.CurrentContract.SetContractID = (object) this.CurrentContractSite.ContractID;
      }
      if (this.CurrentContractSite.JobOfWorks.Count <= 0)
        return;
      this.TCJobsOfWork.TabPages.Clear();
      IEnumerator enumerator;
      try
      {
        enumerator = this.CurrentContractSite.JobOfWorks.GetEnumerator();
        while (enumerator.MoveNext())
          this.AddJobOfWork((ContractAlternativeSiteJobOfWork) enumerator.Current);
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.TCJobsOfWork.SelectedTab = this.TCJobsOfWork.TabPages[0];
    }

    public void PopAssets()
    {
      this.Assets = App.DB.ContractAlternativeSiteAsset.GetAll_SiteID(this.SiteID);
      if (this.CurrentContractSite.Exists)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.Assets.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public bool Save()
    {
      bool flag1;
      try
      {
        if (this.TCJobsOfWork.TabPages.Count > 0)
        {
          bool flag2 = false;
          IEnumerator enumerator;
          try
          {
            enumerator = this.TCJobsOfWork.TabPages.GetEnumerator();
            while (enumerator.MoveNext())
            {
              TabPage current = (TabPage) enumerator.Current;
              if (((UCJobOfWork) current.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 & ((UCJobOfWork) current.Controls[0]).Visits.Table.Rows.Count == 0)
                flag2 = true;
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (flag2 && App.ShowMessage("Are you sure? Any 'Jobs Of Work' not scheduled will now be scheduled and you will not be able to added anymore job items.", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
          {
            flag1 = false;
            goto label_29;
          }
        }
        this.Cursor = Cursors.WaitCursor;
        this.CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
        this.CurrentContractSite.SetPropertyID = (object) this.SiteID;
        this.CurrentContractSite.SetContractID = (object) this.CurrentContract.ContractID;
        new ContractAlternativeSiteValidator().Validate(this.CurrentContractSite, this.CurrentContract);
        if (this.CurrentContractSite.Exists)
        {
          App.DB.ContractAlternativeSite.Update(this.CurrentContractSite);
          IEnumerator enumerator;
          try
          {
            enumerator = this.TCJobsOfWork.TabPages.GetEnumerator();
            while (enumerator.MoveNext())
            {
              TabPage current = (TabPage) enumerator.Current;
              App.DB.ContractAlternativeSiteJobOfWork.Update(((UCJobOfWork) current.Controls[0]).CurrentJobOfWork, ((UCJobOfWork) current.Controls[0]).ScheduleOfRatesDataview);
              if (((UCJobOfWork) current.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 & ((UCJobOfWork) current.Controls[0]).Visits.Table.Rows.Count == 0)
                this.ScheduleJob(((UCJobOfWork) current.Controls[0]).JobItemsAddedDataView, ((UCJobOfWork) current.Controls[0]).CurrentJobOfWork.FirstVisitDate, ((UCJobOfWork) current.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentContractSite.ContractSiteID);
        flag1 = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
label_29:
      return flag1;
    }

    private void ScheduleJob(
      DataView JobItemDV,
      DateTime FirstVisitDate,
      int ContractSiteJobOfWorkID)
    {
      try
      {
        int days = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractEndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00").Subtract(Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00")).Days;
        int num1 = 0;
        switch (Conversions.ToInteger(JobItemDV.Table.Rows[0]["VisitFrequencyID"]))
        {
          case 3:
            num1 = 7;
            break;
          case 4:
            num1 = 30;
            break;
          case 5:
            num1 = 91;
            break;
          case 6:
            num1 = 182;
            break;
          case 7:
            num1 = 365;
            break;
        }
        int num2 = checked ((int) Math.Floor(unchecked ((double) days / (double) num1)));
        if (num2 == 0)
          num2 = 1;
        DateTime dateTime1 = Conversions.ToDate(Conversions.ToString(FirstVisitDate.Date) + " 09:00:00");
        int num3 = num2;
        int num4 = 1;
        while (num4 <= num3)
        {
          if (DateTime.Compare(dateTime1, this.CurrentContract.ContractStartDate) >= 0 & DateTime.Compare(dateTime1, this.CurrentContract.ContractEndDate) <= 0)
          {
            if (dateTime1.DayOfWeek == DayOfWeek.Saturday)
              dateTime1 = dateTime1.AddDays(2.0);
            else if (dateTime1.DayOfWeek == DayOfWeek.Sunday)
              dateTime1 = dateTime1.AddDays(1.0);
            Job job1 = new Job();
            job1.SetPropertyID = (object) this.CurrentContractSite.PropertyID;
            job1.SetJobDefinitionEnumID = (object) 2;
            job1.SetJobTypeID = RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service'")[0]["ManagerID"]);
            job1.SetStatusEnumID = (object) 1;
            job1.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            JobNumber jobNumber = new JobNumber();
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
            job1.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            job1.SetPONumber = (object) "";
            job1.SetQuoteID = (object) 0;
            job1.SetFOC = (object) true;
            job1.SetContractID = (object) this.CurrentContract.ContractID;
            if (this.CurrentContract.ContractStatusID == 4)
              job1.SetDeleted = true;
            JobOfWork jobOfWork = new JobOfWork();
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            jobOfWork.SetPONumber = (object) "";
            if (this.CurrentContract.ContractStatusID == 4)
              jobOfWork.SetDeleted = true;
            int visitDuration = 0;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = JobItemDV.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current1 = (DataRow) enumerator1.Current;
                JobItem jobItem = new JobItem();
                jobItem.IgnoreExceptionsOnSetMethods = true;
                jobItem.SetSummary = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) Helper.MakeStringValid((object) "PPM Contract Visit: "), current1["Description"]);
                visitDuration = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) visitDuration, current1["VisitDuration"]));
                DataView allJobItemId = App.DB.ContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(current1["ContractSiteJobItemID"]));
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = allJobItemId.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    job1.Assets.Add((object) new JobAsset()
                    {
                      SetAssetID = RuntimeHelpers.GetObjectValue(current2["AssetID"])
                    });
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                jobOfWork.JobItems.Add((object) jobItem);
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            ArrayList arrayList1 = new ArrayList();
            int num5 = 0;
            DateTime dateTime2 = DateTime.MinValue;
            ArrayList arrayList2 = this.MatchingEngineer(job1, dateTime1, visitDuration);
            if (arrayList2 != null && arrayList2.Count > 0)
            {
              dateTime2 = Conversions.ToDate(arrayList2[0]);
              num5 = Conversions.ToInteger(arrayList2[1]);
            }
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = (object) num5;
            engineerVisit.SetNotesToEngineer = (object) "PPM Contract Visit";
            engineerVisit.StartDateTime = DateTime.MinValue;
            engineerVisit.EndDateTime = DateTime.MinValue;
            engineerVisit.SetStatusEnumID = (object) 4;
            if (this.CurrentContract.ContractStatusID == 4)
              engineerVisit.SetDeleted = true;
            jobOfWork.EngineerVisits.Add((object) engineerVisit);
            job1.JobOfWorks.Add((object) jobOfWork);
            Job job2 = App.DB.Job.Insert(job1);
            App.DB.ContractAlternativePPMVisit.Insert(new ContractAlternativePPMVisit()
            {
              SetContractSiteJobOfWorkID = (object) ContractSiteJobOfWorkID,
              EstimatedVisitDate = dateTime1,
              SetJobID = (object) job2.JobID
            });
            dateTime1 = dateTime1.AddDays((double) num1);
          }
          checked { ++num4; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private TabPage AddJobOfWork(ContractAlternativeSiteJobOfWork jobOfWork)
    {
      TabPage tabPage = new TabPage();
      tabPage.BackColor = Color.White;
      UCJobOfWork ucJobOfWork = new UCJobOfWork();
      ucJobOfWork.OnControl = this;
      if (jobOfWork == null)
      {
        jobOfWork = new ContractAlternativeSiteJobOfWork();
        jobOfWork.SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID;
        jobOfWork.FirstVisitDate = this.CurrentContract.ContractStartDate.AddDays(1.0);
        jobOfWork.SetPricePerMile = (object) Helper.MakeDoubleValid((object) App.DB.Manager.Get()?.MileageRate);
        jobOfWork = App.DB.ContractAlternativeSiteJobOfWork.Insert(jobOfWork);
      }
      ucJobOfWork.CurrentJobOfWork = jobOfWork;
      ucJobOfWork.RemovedItem += new UCJobOfWork.RemovedItemEventHandler(this.ItemRemovedFromJobOfWork);
      ucJobOfWork.Dock = DockStyle.Fill;
      tabPage.Controls.Add((Control) ucJobOfWork);
      this.TCJobsOfWork.TabPages.Add(tabPage);
      this.CheckTabs();
      this.TCJobsOfWork.SelectedTab = tabPage;
      return tabPage;
    }

    private void CheckTabs()
    {
      int num = 1;
      IEnumerator enumerator;
      try
      {
        enumerator = this.TCJobsOfWork.TabPages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((TabPage) enumerator.Current).Text = "Job Of Work #" + Conversions.ToString(num);
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void RemoveJobOfWork()
    {
      if (((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0)
      {
        int num1 = (int) App.ShowMessage("Items of work has been added to this Job Of Work.\r\nYou must remove all the items first.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).Visits.Table.Rows.Count > 0)
      {
        int num2 = (int) App.ShowMessage("Work has been scheduled.\r\nCannot remove this Job of Work.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        App.DB.ContractAlternativeSiteJobOfWork.Delete(((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
        this.TCJobsOfWork.TabPages.Remove(this.TCJobsOfWork.SelectedTab);
        this.CheckTabs();
      }
    }

    public void ItemRemovedFromJobOfWork()
    {
      this.JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
      ((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork = ((UCJobOfWork) this.TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork;
    }

    private ArrayList MatchingEngineer(Job job, DateTime estVisitDate, int visitDuration)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      int numOfSlotsNeeded = 0;
      ArrayList arrayList1 = new ArrayList();
      int timeSlot = App.DB.Manager.Get().TimeSlot;
      if (visitDuration > 0)
        numOfSlotsNeeded = checked ((int) Math.Round(unchecked ((double) visitDuration / (double) timeSlot)));
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList1 = this.CheckAvailability(estVisitDate, site2.EngineerID, numOfSlotsNeeded);
      ArrayList arrayList2;
      if (arrayList1.Count > 0)
      {
        arrayList2 = arrayList1;
      }
      else
      {
        string str = site2.Postcode.Replace("-", "").Replace(" ", "");
        string Postcode = str.Substring(0, checked (str.Length - 3));
        DataView forPostcode = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(Postcode);
        int count = forPostcode.Table.Rows.Count;
        if (count > 0)
        {
          int num1 = checked (count - 1);
          int num2 = 0;
          while (num2 <= num1)
          {
            VBMath.Randomize();
            int index = checked ((int) Conversion.Int((float) unchecked ((double) forPostcode.Table.Rows.Count * (double) VBMath.Rnd() + 1.0)) - 1);
            ArrayList arrayList3 = this.CheckAvailability(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfSlotsNeeded);
            if (arrayList3.Count > 0)
            {
              arrayList2 = arrayList3;
              goto label_13;
            }
            else
            {
              forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
              checked { ++num2; }
            }
          }
        }
      }
label_13:
      return arrayList2;
    }

    private ArrayList CheckAvailability(
      DateTime estimatedVisitDate,
      int engineerID,
      int numOfSlotsNeeded)
    {
      ArrayList arrayList1 = new ArrayList();
      DateTime day = estimatedVisitDate;
      ArrayList arrayList2 = new ArrayList();
      int num1 = 0;
      do
      {
        arrayList1.Clear();
        if ((uint) num1 > 0U)
          day = day.AddDays(1.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(2.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(1.0);
        DataTable dataTable = App.DB.Scheduler.Scheduler_DayTimeSlots(day, Conversions.ToString(engineerID));
        if (dataTable.Rows.Count > 0)
        {
          int num2 = checked (dataTable.Columns.Count - 1);
          int index = 0;
          while (index <= num2)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0][index], (object) 0, false))
            {
              arrayList1.Add((object) dataTable.Columns[index].ColumnName);
              if (arrayList1.Count == numOfSlotsNeeded)
                break;
            }
            else
              arrayList1.Clear();
            checked { ++index; }
          }
        }
        else
          arrayList1.Add((object) App.DB.Manager.Get().WorkingHoursStart);
        if (arrayList1.Count > 0 && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (arrayList1.Count == numOfSlotsNeeded), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false))))
        {
          string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false) ? Strings.Replace(Conversions.ToString(arrayList1[0]), "T", "", 1, -1, CompareMethod.Binary).Insert(2, ":") : Conversions.ToString(arrayList1[0]);
          day = Conversions.ToDate(Strings.Format((object) day, "dd/MM/yyyy") + " " + str);
          arrayList2.Add((object) day);
          arrayList2.Add((object) engineerID);
          return arrayList2;
        }
        checked { ++num1; }
      }
      while (num1 <= 4);
      return arrayList2;
    }
  }
}
