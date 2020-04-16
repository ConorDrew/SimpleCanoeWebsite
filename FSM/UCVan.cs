// Decompiled with JetBrains decompiler
// Type: FSM.UCVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartTransactions;
using FSM.Entity.Sys;
using FSM.Entity.Vans;
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
  public class UCVan : UCBase, IUserControl
  {
    private IContainer components;
    private int oldDepartment;
    private Van _currentVan;
    private DataView m_dTable;
    private DataView m_dTable2;
    private DataView _WarehousesDataView;
    private DataTable m_dTable5;
    private DataView _dvEquipment;

    public UCVan()
    {
      this.Load += new EventHandler(this.UCVan_Load);
      this.oldDepartment = 0;
      this.m_dTable = (DataView) null;
      this.m_dTable2 = (DataView) null;
      this._WarehousesDataView = (DataView) null;
      this.m_dTable5 = (DataTable) null;
      this._dvEquipment = (DataView) null;
      this.InitializeComponent();
      ComboBox preferredSupplierId = this.cboPreferredSupplierID;
      Combo.SetUpCombo(ref preferredSupplierId, DynamicDataTables.SupplierIDList, "SupplierID", "Name", Enums.ComboValues.Please_Select);
      this.cboPreferredSupplierID = preferredSupplierId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProfile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCopyProfile
    {
      get
      {
        return this._btnCopyProfile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCopyVan_Click);
        Button btnCopyProfile1 = this._btnCopyProfile;
        if (btnCopyProfile1 != null)
          btnCopyProfile1.Click -= eventHandler;
        this._btnCopyProfile = value;
        Button btnCopyProfile2 = this._btnCopyProfile;
        if (btnCopyProfile2 == null)
          return;
        btnCopyProfile2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpWarehouses { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpWarehouses { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgWarehouses
    {
      get
      {
        return this._dgWarehouses;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgWarehouses_MouseUp);
        DataGrid dgWarehouses1 = this._dgWarehouses;
        if (dgWarehouses1 != null)
          dgWarehouses1.MouseUp -= mouseEventHandler;
        this._dgWarehouses = value;
        DataGrid dgWarehouses2 = this._dgWarehouses;
        if (dgWarehouses2 == null)
          return;
        dgWarehouses2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPreferredSupplierID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkExcludeFromAutoStockReplen { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvParts
    {
      get
      {
        return this._dgvParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgvParts_DoubleClick);
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgvParts_CellEndEdit);
        DataGridViewCellMouseEventHandler mouseEventHandler = new DataGridViewCellMouseEventHandler(this.dgvParts_ColumnHeaderMouseClick);
        DataGridView dgvParts1 = this._dgvParts;
        if (dgvParts1 != null)
        {
          dgvParts1.DoubleClick -= eventHandler;
          dgvParts1.CellEndEdit -= cellEventHandler;
          dgvParts1.ColumnHeaderMouseClick -= mouseEventHandler;
        }
        this._dgvParts = value;
        DataGridView dgvParts2 = this._dgvParts;
        if (dgvParts2 == null)
          return;
        dgvParts2.DoubleClick += eventHandler;
        dgvParts2.CellEndEdit += cellEventHandler;
        dgvParts2.ColumnHeaderMouseClick += mouseEventHandler;
      }
    }

    internal virtual Button btnAddPartStockProfile
    {
      get
      {
        return this._btnAddPartStockProfile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPartVanStock_Click);
        Button partStockProfile1 = this._btnAddPartStockProfile;
        if (partStockProfile1 != null)
          partStockProfile1.Click -= eventHandler;
        this._btnAddPartStockProfile = value;
        Button partStockProfile2 = this._btnAddPartStockProfile;
        if (partStockProfile2 == null)
          return;
        partStockProfile2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeletePartStockProfile
    {
      get
      {
        return this._btnDeletePartStockProfile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeletePartVanStock_Click);
        Button partStockProfile1 = this._btnDeletePartStockProfile;
        if (partStockProfile1 != null)
          partStockProfile1.Click -= eventHandler;
        this._btnDeletePartStockProfile = value;
        Button partStockProfile2 = this._btnDeletePartStockProfile;
        if (partStockProfile2 == null)
          return;
        partStockProfile2.Click += eventHandler;
      }
    }

    internal virtual Button btnClearVanStockProfile
    {
      get
      {
        return this._btnClearVanStockProfile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearVanStockProfile_Click);
        Button clearVanStockProfile1 = this._btnClearVanStockProfile;
        if (clearVanStockProfile1 != null)
          clearVanStockProfile1.Click -= eventHandler;
        this._btnClearVanStockProfile = value;
        Button clearVanStockProfile2 = this._btnClearVanStockProfile;
        if (clearVanStockProfile2 == null)
          return;
        clearVanStockProfile2.Click += eventHandler;
      }
    }

    internal virtual Button btnExportStockProfile
    {
      get
      {
        return this._btnExportStockProfile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportStockProfile_Click);
        Button exportStockProfile1 = this._btnExportStockProfile;
        if (exportStockProfile1 != null)
          exportStockProfile1.Click -= eventHandler;
        this._btnExportStockProfile = value;
        Button exportStockProfile2 = this._btnExportStockProfile;
        if (exportStockProfile2 == null)
          return;
        exportStockProfile2.Click += eventHandler;
      }
    }

    internal virtual Button btnMerge
    {
      get
      {
        return this._btnMerge;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMergeProfile_Click);
        Button btnMerge1 = this._btnMerge;
        if (btnMerge1 != null)
          btnMerge1.Click -= eventHandler;
        this._btnMerge = value;
        Button btnMerge2 = this._btnMerge;
        if (btnMerge2 == null)
          return;
        btnMerge2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkSecondaryPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkContainer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVanEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEquipmentTool { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveEquipment
    {
      get
      {
        return this._btnSaveEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveEquipment_Click);
        Button btnSaveEquipment1 = this._btnSaveEquipment;
        if (btnSaveEquipment1 != null)
          btnSaveEquipment1.Click -= eventHandler;
        this._btnSaveEquipment = value;
        Button btnSaveEquipment2 = this._btnSaveEquipment;
        if (btnSaveEquipment2 == null)
          return;
        btnSaveEquipment2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteEquipment
    {
      get
      {
        return this._btnDeleteEquipment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteEquipment_Click);
        Button btnDeleteEquipment1 = this._btnDeleteEquipment;
        if (btnDeleteEquipment1 != null)
          btnDeleteEquipment1.Click -= eventHandler;
        this._btnDeleteEquipment = value;
        Button btnDeleteEquipment2 = this._btnDeleteEquipment;
        if (btnDeleteEquipment2 == null)
          return;
        btnDeleteEquipment2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCurEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCurEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCurEngineerFleet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCurEngineerFleet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEngineerHistory
    {
      get
      {
        return this._btnEngineerHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEngineerHistory_Click);
        Button btnEngineerHistory1 = this._btnEngineerHistory;
        if (btnEngineerHistory1 != null)
          btnEngineerHistory1.Click -= eventHandler;
        this._btnEngineerHistory = value;
        Button btnEngineerHistory2 = this._btnEngineerHistory;
        if (btnEngineerHistory2 == null)
          return;
        btnEngineerHistory2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tcVans = new TabControl();
      this.tabDetails = new TabPage();
      this.grpVan = new GroupBox();
      this.txtCurEngineerFleet = new TextBox();
      this.lblCurEngineerFleet = new Label();
      this.txtCurEngineer = new TextBox();
      this.lblCurEngineer = new Label();
      this.btnCopyProfile = new Button();
      this.btnEngineerHistory = new Button();
      this.txtProfile = new TextBox();
      this.lblProfile = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.tabStock = new TabPage();
      this.chkContainer = new CheckBox();
      this.chkSecondaryPrice = new CheckBox();
      this.chkExcludeFromAutoStockReplen = new CheckBox();
      this.dgParts = new DataGrid();
      this.GroupBox3 = new GroupBox();
      this.cboPreferredSupplierID = new ComboBox();
      this.GroupBox2 = new GroupBox();
      this.btnMerge = new Button();
      this.btnExportStockProfile = new Button();
      this.btnClearVanStockProfile = new Button();
      this.btnDeletePartStockProfile = new Button();
      this.btnAddPartStockProfile = new Button();
      this.dgvParts = new DataGridView();
      this.GroupBox1 = new GroupBox();
      this.dgProducts = new DataGrid();
      this.tpWarehouses = new TabPage();
      this.grpWarehouses = new GroupBox();
      this.dgWarehouses = new DataGrid();
      this.tabEquipment = new TabPage();
      this.grpVanEquipment = new GroupBox();
      this.Panel2 = new Panel();
      this.txtEquipmentTool = new TextBox();
      this.Label3 = new Label();
      this.btnSaveEquipment = new Button();
      this.btnDeleteEquipment = new Button();
      this.dgEquipment = new DataGrid();
      this.tcVans.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.grpVan.SuspendLayout();
      this.tabStock.SuspendLayout();
      this.dgParts.BeginInit();
      this.GroupBox3.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      ((ISupportInitialize) this.dgvParts).BeginInit();
      this.GroupBox1.SuspendLayout();
      this.dgProducts.BeginInit();
      this.tpWarehouses.SuspendLayout();
      this.grpWarehouses.SuspendLayout();
      this.dgWarehouses.BeginInit();
      this.tabEquipment.SuspendLayout();
      this.grpVanEquipment.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.dgEquipment.BeginInit();
      this.SuspendLayout();
      this.tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcVans.Controls.Add((Control) this.tabDetails);
      this.tcVans.Controls.Add((Control) this.tabStock);
      this.tcVans.Controls.Add((Control) this.tpWarehouses);
      this.tcVans.Controls.Add((Control) this.tabEquipment);
      this.tcVans.Location = new System.Drawing.Point(4, 7);
      this.tcVans.Name = "tcVans";
      this.tcVans.SelectedIndex = 0;
      this.tcVans.Size = new Size(1206, 798);
      this.tcVans.TabIndex = 0;
      this.tabDetails.Controls.Add((Control) this.grpVan);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(675, 644);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVan.Controls.Add((Control) this.txtCurEngineerFleet);
      this.grpVan.Controls.Add((Control) this.lblCurEngineerFleet);
      this.grpVan.Controls.Add((Control) this.txtCurEngineer);
      this.grpVan.Controls.Add((Control) this.lblCurEngineer);
      this.grpVan.Controls.Add((Control) this.btnCopyProfile);
      this.grpVan.Controls.Add((Control) this.btnEngineerHistory);
      this.grpVan.Controls.Add((Control) this.txtProfile);
      this.grpVan.Controls.Add((Control) this.lblProfile);
      this.grpVan.Controls.Add((Control) this.txtNotes);
      this.grpVan.Controls.Add((Control) this.lblNotes);
      this.grpVan.Location = new System.Drawing.Point(8, 8);
      this.grpVan.Name = "grpVan";
      this.grpVan.Size = new Size(664, 631);
      this.grpVan.TabIndex = 2;
      this.grpVan.TabStop = false;
      this.grpVan.Text = "Details";
      this.txtCurEngineerFleet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCurEngineerFleet.Enabled = false;
      this.txtCurEngineerFleet.Location = new System.Drawing.Point(131, 77);
      this.txtCurEngineerFleet.MaxLength = 20;
      this.txtCurEngineerFleet.Name = "txtCurEngineerFleet";
      this.txtCurEngineerFleet.Size = new Size(380, 21);
      this.txtCurEngineerFleet.TabIndex = 39;
      this.txtCurEngineerFleet.Tag = (object) "Profile.EngineerFleet";
      this.lblCurEngineerFleet.Location = new System.Drawing.Point(8, 80);
      this.lblCurEngineerFleet.Name = "lblCurEngineerFleet";
      this.lblCurEngineerFleet.Size = new Size(117, 20);
      this.lblCurEngineerFleet.TabIndex = 38;
      this.lblCurEngineerFleet.Text = "Engineer Fleet";
      this.txtCurEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCurEngineer.Enabled = false;
      this.txtCurEngineer.Location = new System.Drawing.Point(131, 50);
      this.txtCurEngineer.MaxLength = 20;
      this.txtCurEngineer.Name = "txtCurEngineer";
      this.txtCurEngineer.Size = new Size(380, 21);
      this.txtCurEngineer.TabIndex = 37;
      this.txtCurEngineer.Tag = (object) "Profile.Engineer";
      this.lblCurEngineer.Location = new System.Drawing.Point(8, 53);
      this.lblCurEngineer.Name = "lblCurEngineer";
      this.lblCurEngineer.Size = new Size(117, 20);
      this.lblCurEngineer.TabIndex = 36;
      this.lblCurEngineer.Text = "Current Engineer";
      this.btnCopyProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCopyProfile.Location = new System.Drawing.Point(6, 602);
      this.btnCopyProfile.Name = "btnCopyProfile";
      this.btnCopyProfile.Size = new Size(87, 23);
      this.btnCopyProfile.TabIndex = 35;
      this.btnCopyProfile.Text = "Copy Profile";
      this.btnCopyProfile.UseVisualStyleBackColor = true;
      this.btnEngineerHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEngineerHistory.Location = new System.Drawing.Point(530, 19);
      this.btnEngineerHistory.Name = "btnEngineerHistory";
      this.btnEngineerHistory.Size = new Size(112, 23);
      this.btnEngineerHistory.TabIndex = 2;
      this.btnEngineerHistory.Text = "Engineer History";
      this.txtProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtProfile.Location = new System.Drawing.Point(131, 21);
      this.txtProfile.MaxLength = 20;
      this.txtProfile.Name = "txtProfile";
      this.txtProfile.Size = new Size(380, 21);
      this.txtProfile.TabIndex = 1;
      this.txtProfile.Tag = (object) "Profile.Name";
      this.lblProfile.Location = new System.Drawing.Point(8, 24);
      this.lblProfile.Name = "lblProfile";
      this.lblProfile.Size = new Size(85, 20);
      this.lblProfile.TabIndex = 31;
      this.lblProfile.Text = "Profile Name";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(131, 117);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(511, 473);
      this.txtNotes.TabIndex = 7;
      this.txtNotes.Tag = (object) "Profile.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 117);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(53, 22);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.tabStock.Controls.Add((Control) this.chkContainer);
      this.tabStock.Controls.Add((Control) this.chkSecondaryPrice);
      this.tabStock.Controls.Add((Control) this.chkExcludeFromAutoStockReplen);
      this.tabStock.Controls.Add((Control) this.dgParts);
      this.tabStock.Controls.Add((Control) this.GroupBox3);
      this.tabStock.Controls.Add((Control) this.GroupBox2);
      this.tabStock.Controls.Add((Control) this.GroupBox1);
      this.tabStock.Location = new System.Drawing.Point(4, 22);
      this.tabStock.Name = "tabStock";
      this.tabStock.Size = new Size(1198, 772);
      this.tabStock.TabIndex = 1;
      this.tabStock.Text = "Stock";
      this.chkContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkContainer.AutoSize = true;
      this.chkContainer.Location = new System.Drawing.Point(528, 742);
      this.chkContainer.Name = "chkContainer";
      this.chkContainer.Size = new Size(143, 17);
      this.chkContainer.TabIndex = 5;
      this.chkContainer.Text = "Use Container Stock";
      this.chkContainer.UseVisualStyleBackColor = true;
      this.chkSecondaryPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkSecondaryPrice.AutoSize = true;
      this.chkSecondaryPrice.Location = new System.Drawing.Point(330, 742);
      this.chkSecondaryPrice.Name = "chkSecondaryPrice";
      this.chkSecondaryPrice.Size = new Size(144, 17);
      this.chkSecondaryPrice.TabIndex = 4;
      this.chkSecondaryPrice.Text = "Use Secondary Price";
      this.chkSecondaryPrice.UseVisualStyleBackColor = true;
      this.chkExcludeFromAutoStockReplen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkExcludeFromAutoStockReplen.AutoSize = true;
      this.chkExcludeFromAutoStockReplen.Location = new System.Drawing.Point(16, 742);
      this.chkExcludeFromAutoStockReplen.Name = "chkExcludeFromAutoStockReplen";
      this.chkExcludeFromAutoStockReplen.Size = new Size(288, 17);
      this.chkExcludeFromAutoStockReplen.TabIndex = 3;
      this.chkExcludeFromAutoStockReplen.Text = "Exclude From Automatic Stock Replenishment";
      this.chkExcludeFromAutoStockReplen.UseVisualStyleBackColor = true;
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(637, 259);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(558, 380);
      this.dgParts.TabIndex = 2;
      this.dgParts.Visible = false;
      this.GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.cboPreferredSupplierID);
      this.GroupBox3.Location = new System.Drawing.Point(8, 680);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(1179, 49);
      this.GroupBox3.TabIndex = 2;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Preferred Supplier";
      this.cboPreferredSupplierID.Cursor = Cursors.Hand;
      this.cboPreferredSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPreferredSupplierID.FormattingEnabled = true;
      this.cboPreferredSupplierID.Location = new System.Drawing.Point(8, 20);
      this.cboPreferredSupplierID.Name = "cboPreferredSupplierID";
      this.cboPreferredSupplierID.Size = new Size(616, 21);
      this.cboPreferredSupplierID.TabIndex = 0;
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.btnMerge);
      this.GroupBox2.Controls.Add((Control) this.btnExportStockProfile);
      this.GroupBox2.Controls.Add((Control) this.btnClearVanStockProfile);
      this.GroupBox2.Controls.Add((Control) this.btnDeletePartStockProfile);
      this.GroupBox2.Controls.Add((Control) this.btnAddPartStockProfile);
      this.GroupBox2.Controls.Add((Control) this.dgvParts);
      this.GroupBox2.Location = new System.Drawing.Point(8, 239);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1179, 435);
      this.GroupBox2.TabIndex = 1;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Parts Held On Profile";
      this.btnMerge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnMerge.Location = new System.Drawing.Point(137, 406);
      this.btnMerge.Name = "btnMerge";
      this.btnMerge.Size = new Size(159, 23);
      this.btnMerge.TabIndex = 37;
      this.btnMerge.Text = "Merge Another Profile";
      this.btnMerge.UseVisualStyleBackColor = true;
      this.btnExportStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExportStockProfile.Location = new System.Drawing.Point(557, 406);
      this.btnExportStockProfile.Name = "btnExportStockProfile";
      this.btnExportStockProfile.Size = new Size(200, 23);
      this.btnExportStockProfile.TabIndex = 7;
      this.btnExportStockProfile.Text = "Export Stock Profile";
      this.btnExportStockProfile.UseVisualStyleBackColor = true;
      this.btnClearVanStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClearVanStockProfile.Location = new System.Drawing.Point(8, 406);
      this.btnClearVanStockProfile.MaximumSize = new Size(181, 23);
      this.btnClearVanStockProfile.Name = "btnClearVanStockProfile";
      this.btnClearVanStockProfile.Size = new Size(123, 23);
      this.btnClearVanStockProfile.TabIndex = 6;
      this.btnClearVanStockProfile.Text = "Clear Stock Profile";
      this.btnClearVanStockProfile.UseVisualStyleBackColor = true;
      this.btnDeletePartStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeletePartStockProfile.Location = new System.Drawing.Point(971, 406);
      this.btnDeletePartStockProfile.MaximumSize = new Size(0, 23);
      this.btnDeletePartStockProfile.Name = "btnDeletePartStockProfile";
      this.btnDeletePartStockProfile.Size = new Size(200, 23);
      this.btnDeletePartStockProfile.TabIndex = 5;
      this.btnDeletePartStockProfile.Text = "Remove Part from Stock Profile";
      this.btnDeletePartStockProfile.UseVisualStyleBackColor = true;
      this.btnAddPartStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddPartStockProfile.Location = new System.Drawing.Point(763, 406);
      this.btnAddPartStockProfile.Name = "btnAddPartStockProfile";
      this.btnAddPartStockProfile.Size = new Size(200, 23);
      this.btnAddPartStockProfile.TabIndex = 4;
      this.btnAddPartStockProfile.Text = "Add Part to Stock Profile";
      this.btnAddPartStockProfile.UseVisualStyleBackColor = true;
      this.dgvParts.AllowUserToAddRows = false;
      this.dgvParts.AllowUserToDeleteRows = false;
      this.dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvParts.Location = new System.Drawing.Point(8, 20);
      this.dgvParts.Name = "dgvParts";
      this.dgvParts.Size = new Size(1162, 380);
      this.dgvParts.TabIndex = 3;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgProducts);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(1179, 224);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Products Held On Profile";
      this.dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgProducts.DataMember = "";
      this.dgProducts.HeaderForeColor = SystemColors.ControlText;
      this.dgProducts.Location = new System.Drawing.Point(8, 34);
      this.dgProducts.Name = "dgProducts";
      this.dgProducts.Size = new Size(1163, 184);
      this.dgProducts.TabIndex = 1;
      this.tpWarehouses.Controls.Add((Control) this.grpWarehouses);
      this.tpWarehouses.Location = new System.Drawing.Point(4, 22);
      this.tpWarehouses.Name = "tpWarehouses";
      this.tpWarehouses.Padding = new Padding(3);
      this.tpWarehouses.Size = new Size(675, 644);
      this.tpWarehouses.TabIndex = 2;
      this.tpWarehouses.Text = "Warehouse Locations";
      this.tpWarehouses.UseVisualStyleBackColor = true;
      this.grpWarehouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpWarehouses.Controls.Add((Control) this.dgWarehouses);
      this.grpWarehouses.Location = new System.Drawing.Point(6, 6);
      this.grpWarehouses.Name = "grpWarehouses";
      this.grpWarehouses.Size = new Size(663, 632);
      this.grpWarehouses.TabIndex = 3;
      this.grpWarehouses.TabStop = false;
      this.grpWarehouses.Text = "Tick those warehouses for this profile";
      this.dgWarehouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgWarehouses.DataMember = "";
      this.dgWarehouses.HeaderForeColor = SystemColors.ControlText;
      this.dgWarehouses.Location = new System.Drawing.Point(6, 20);
      this.dgWarehouses.Name = "dgWarehouses";
      this.dgWarehouses.Size = new Size(651, 606);
      this.dgWarehouses.TabIndex = 2;
      this.tabEquipment.BackColor = SystemColors.Control;
      this.tabEquipment.Controls.Add((Control) this.grpVanEquipment);
      this.tabEquipment.Location = new System.Drawing.Point(4, 22);
      this.tabEquipment.Name = "tabEquipment";
      this.tabEquipment.Size = new Size(675, 644);
      this.tabEquipment.TabIndex = 3;
      this.tabEquipment.Text = "Capital Tools";
      this.grpVanEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVanEquipment.Controls.Add((Control) this.Panel2);
      this.grpVanEquipment.Controls.Add((Control) this.btnDeleteEquipment);
      this.grpVanEquipment.Controls.Add((Control) this.dgEquipment);
      this.grpVanEquipment.Location = new System.Drawing.Point(3, 13);
      this.grpVanEquipment.Name = "grpVanEquipment";
      this.grpVanEquipment.Size = new Size(662, 617);
      this.grpVanEquipment.TabIndex = 14;
      this.grpVanEquipment.TabStop = false;
      this.grpVanEquipment.Text = "Capital Tools";
      this.Panel2.Controls.Add((Control) this.txtEquipmentTool);
      this.Panel2.Controls.Add((Control) this.Label3);
      this.Panel2.Controls.Add((Control) this.btnSaveEquipment);
      this.Panel2.Location = new System.Drawing.Point(8, 19);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(648, 69);
      this.Panel2.TabIndex = 2;
      this.txtEquipmentTool.AcceptsReturn = true;
      this.txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEquipmentTool.Location = new System.Drawing.Point(115, 4);
      this.txtEquipmentTool.MaxLength = (int) byte.MaxValue;
      this.txtEquipmentTool.Multiline = true;
      this.txtEquipmentTool.Name = "txtEquipmentTool";
      this.txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
      this.txtEquipmentTool.Size = new Size(432, 56);
      this.txtEquipmentTool.TabIndex = 1;
      this.txtEquipmentTool.Tag = (object) "Engineer.Name";
      this.Label3.Location = new System.Drawing.Point(3, 4);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(112, 20);
      this.Label3.TabIndex = 55;
      this.Label3.Text = "Equipment\\Tool";
      this.btnSaveEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveEquipment.Location = new System.Drawing.Point(560, 36);
      this.btnSaveEquipment.Name = "btnSaveEquipment";
      this.btnSaveEquipment.Size = new Size(75, 23);
      this.btnSaveEquipment.TabIndex = 2;
      this.btnSaveEquipment.Text = "Save";
      this.btnDeleteEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeleteEquipment.Location = new System.Drawing.Point(8, 585);
      this.btnDeleteEquipment.Name = "btnDeleteEquipment";
      this.btnDeleteEquipment.Size = new Size(75, 23);
      this.btnDeleteEquipment.TabIndex = 4;
      this.btnDeleteEquipment.Text = "Delete";
      this.dgEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEquipment.DataMember = "";
      this.dgEquipment.HeaderForeColor = SystemColors.ControlText;
      this.dgEquipment.Location = new System.Drawing.Point(8, 103);
      this.dgEquipment.Name = "dgEquipment";
      this.dgEquipment.Size = new Size(646, 474);
      this.dgEquipment.TabIndex = 3;
      this.Controls.Add((Control) this.tcVans);
      this.Name = nameof (UCVan);
      this.Size = new Size(1216, 808);
      this.tcVans.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.grpVan.ResumeLayout(false);
      this.grpVan.PerformLayout();
      this.tabStock.ResumeLayout(false);
      this.tabStock.PerformLayout();
      this.dgParts.EndInit();
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvParts).EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.dgProducts.EndInit();
      this.tpWarehouses.ResumeLayout(false);
      this.grpWarehouses.ResumeLayout(false);
      this.dgWarehouses.EndInit();
      this.tabEquipment.ResumeLayout(false);
      this.grpVanEquipment.ResumeLayout(false);
      this.Panel2.ResumeLayout(false);
      this.Panel2.PerformLayout();
      this.dgEquipment.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupPartsDatagrid();
      this.SetupProductsDatagrid();
      this.SetupWarehousesDatagrid();
      this.SetupPartsDataGridView();
      this.DgSetupVanEquipment();
      this.dgParts.ReadOnly = false;
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentVan;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Van CurrentVan
    {
      get
      {
        return this._currentVan;
      }
      set
      {
        this._currentVan = value;
        if (this._currentVan == null)
        {
          this._currentVan = new Van();
          this._currentVan.Exists = false;
        }
        if (this._currentVan.Exists)
        {
          this.btnEngineerHistory.Enabled = true;
        }
        else
        {
          this.WarehousesDataView = App.DB.Warehouse.Warehouse_GetAll_For_Van2(0);
          this.btnEngineerHistory.Enabled = false;
        }
      }
    }

    public DataView ProductsDataView
    {
      get
      {
        return this.m_dTable;
      }
      set
      {
        this.m_dTable = value;
        this.m_dTable.Table.TableName = Enums.TableNames.tblProduct.ToString();
        this.m_dTable.AllowNew = false;
        this.m_dTable.AllowEdit = false;
        this.m_dTable.AllowDelete = false;
        this.dgProducts.DataSource = (object) this.ProductsDataView;
      }
    }

    private DataRow SelectedProductDataRow
    {
      get
      {
        return this.dgProducts.CurrentRowIndex != -1 ? this.ProductsDataView[this.dgProducts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PartsDataView
    {
      get
      {
        return this.m_dTable2;
      }
      set
      {
        this.m_dTable2 = value;
        this.m_dTable2.Table.TableName = Enums.TableNames.tblPart.ToString();
        this.m_dTable2.AllowNew = false;
        this.m_dTable2.AllowEdit = true;
        this.m_dTable2.AllowDelete = false;
        this.dgParts.DataSource = (object) this.PartsDataView;
      }
    }

    private DataRow SelectedPartDataRow
    {
      get
      {
        return this.dgParts.CurrentRowIndex != -1 ? this.PartsDataView[this.dgParts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataGridViewRow SelecteddgvPartDataRow
    {
      get
      {
        return this.dgvParts.CurrentRow.Index != -1 ? this.dgvParts.CurrentRow : (DataGridViewRow) null;
      }
    }

    public DataView WarehousesDataView
    {
      get
      {
        return this._WarehousesDataView;
      }
      set
      {
        this._WarehousesDataView = value;
        this._WarehousesDataView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
        this._WarehousesDataView.AllowNew = false;
        this._WarehousesDataView.AllowEdit = false;
        this._WarehousesDataView.AllowDelete = false;
        this.dgWarehouses.DataSource = (object) this.WarehousesDataView;
      }
    }

    private DataRow SelectedWarehouseDataRow
    {
      get
      {
        return this.dgWarehouses.CurrentRowIndex != -1 ? this.WarehousesDataView[this.dgWarehouses.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataTable PartsDataGridView
    {
      get
      {
        return this.m_dTable5;
      }
      set
      {
        this.m_dTable5 = value;
        this.dgvParts.DataSource = (object) value;
      }
    }

    public DataView DvEquipment
    {
      get
      {
        return this._dvEquipment;
      }
      set
      {
        this._dvEquipment = value;
        this._dvEquipment.AllowNew = false;
        this._dvEquipment.AllowEdit = false;
        this._dvEquipment.AllowDelete = false;
        this.dgEquipment.DataSource = (object) this.DvEquipment;
      }
    }

    private DataRow DrSelectedEquipment
    {
      get
      {
        return this.dgEquipment.CurrentRowIndex != -1 ? this.DvEquipment[this.dgEquipment.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void UCVan_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnEngineerHistory_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMEngineerHistory), true, new object[1]
      {
        (object) this.CurrentVan.VanID
      }, false);
      this.Populate(this.CurrentVan.VanID);
    }

    private void dgvParts_DoubleClick(object sender, EventArgs e)
    {
      if (this.dgvParts.CurrentRow == null)
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        this.dgvParts.CurrentRow.Cells[7].Value,
        (object) true
      }, false);
      this.PartsDataGridView = App.DB.PartTransaction.GetByVan2(this.CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID)));
    }

    private void btnCopyVan_Click(object sender, EventArgs e)
    {
      if (this.CurrentVan.Exists)
      {
        try
        {
          Van oVan = new Van();
          this.Cursor = Cursors.WaitCursor;
          oVan.IgnoreExceptionsOnSetMethods = true;
          oVan.SetRegistration = (object) Interaction.InputBox("Please enter new profile name:", "Profile", "", -1, -1);
          oVan.SetNotes = (object) this.txtNotes.Text.Trim();
          oVan.SetPreferredSupplierID = (object) Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID);
          if (DateTime.Compare(this.CurrentVan.InsuranceDue, DateTime.MinValue) == 0)
            this.CurrentVan.InsuranceDue = DateAndTime.Now;
          if (DateTime.Compare(this.CurrentVan.MOTDue, DateTime.MinValue) == 0)
            this.CurrentVan.MOTDue = DateAndTime.Now;
          if (DateTime.Compare(this.CurrentVan.TaxDue, DateTime.MinValue) == 0)
            this.CurrentVan.TaxDue = DateAndTime.Now;
          if (DateTime.Compare(this.CurrentVan.ServiceDue, DateTime.MinValue) == 0)
            this.CurrentVan.ServiceDue = DateAndTime.Now;
          new VanValidator().Validate(oVan);
          App.DB.Van.CopyVan(oVan, this.CurrentVan.Registration, this.WarehousesDataView, false);
          // ISSUE: reference to a compiler-generated field
          IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
          if (recordsChangedEvent != null)
            recordsChangedEvent(App.DB.Van.Van_GetAll(true), Enums.PageViewing.StockProfile, true, false, "");
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentVan.VanID);
          App.MainForm.RefreshEntity(this.CurrentVan.VanID, "");
          int num = (int) App.ShowMessage("Profile Copy Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      else
      {
        int num1 = (int) App.ShowMessage("Save current Profile before continuing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnMergeProfile_Click(object sender, EventArgs e)
    {
      if (this.CurrentVan.Exists)
      {
        try
        {
          Van van = new Van();
          this.Cursor = Cursors.WaitCursor;
          int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblVan, 0, "", false));
          if ((uint) integer <= 0U)
            return;
          Van oVanToMergeFrom = App.DB.Van.Van_Get(integer);
          this.CurrentVan = App.DB.Van.MergeVan(oVanToMergeFrom, this.CurrentVan);
          // ISSUE: reference to a compiler-generated field
          IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
          if (recordsChangedEvent != null)
            recordsChangedEvent(App.DB.Van.Van_GetAll(true), Enums.PageViewing.Van, true, false, "");
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentVan.VanID);
          App.MainForm.RefreshEntity(this.CurrentVan.VanID, "");
          int num = (int) App.ShowMessage("Van Merge Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      else
      {
        int num1 = (int) App.ShowMessage("Save current van before continuing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void dgWarehouses_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgWarehouses.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgWarehouses.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedWarehouseDataRow == null)
          return;
        bool flag = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgWarehouses[this.dgWarehouses.CurrentRowIndex, 0]));
        if (!flag && Conversions.ToBoolean(this.SelectedWarehouseDataRow["IsGasway"]))
        {
          int num = (int) App.ShowMessage("Gasway warehouse cannot be unselected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
          this.dgWarehouses[this.dgWarehouses.CurrentRowIndex, 0] = (object) flag;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentVan = App.DB.Van.Van_Get(ID);
      this.CurrentVan.SetRegistration = (object) this.CurrentVan.Registration.Split('*')[0].Trim();
      DataRow[] dataRowArray = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(ID).Table.Select("EnddateTime > '" + Conversions.ToString(DateTime.Now) + "' Or EnddateTime Is null");
      if (dataRowArray.Length < 1)
      {
        this.txtCurEngineer.Text = "<<No engineer is currently set/active to this profile>>";
        this.txtCurEngineerFleet.Text = "<<Engineer is not currently assigned to a van>>";
      }
      else
      {
        this.txtCurEngineer.Text = Conversions.ToString(dataRowArray[0]["Engineer"]);
        DataView allByEngineerId = App.DB.FleetVanEngineer.GetAll_ByEngineerID(Conversions.ToInteger(dataRowArray[0]["EngineerID"]));
        // ISSUE: explicit non-virtual call
        this.txtCurEngineerFleet.Text = allByEngineerId == null || __nonvirtual (allByEngineerId.Count) <= 0 ? "<<Engineer is not currently assigned to a van>>" : Conversions.ToString(allByEngineerId[0]["Registration"]);
      }
      this.txtProfile.Text = this.CurrentVan.Registration;
      this.txtNotes.Text = this.CurrentVan.Notes;
      ComboBox preferredSupplierId = this.cboPreferredSupplierID;
      Combo.SetSelectedComboItem_By_Value(ref preferredSupplierId, Conversions.ToString(this.CurrentVan.PreferredSupplierID));
      this.cboPreferredSupplierID = preferredSupplierId;
      if (this.CurrentVan.ExcludeFromAutoReplenishment)
        this.chkExcludeFromAutoStockReplen.Checked = true;
      if (this.CurrentVan.UseContainerStock)
        this.chkContainer.Checked = true;
      this.chkSecondaryPrice.Checked = this.CurrentVan.SecondaryPrice;
      this.chkSecondaryPrice.Visible = Conversions.ToBoolean(Interaction.IIf(this.CurrentVan.EngineerVanID > 0, (object) true, (object) false));
      this.PartsDataGridView = App.DB.PartTransaction.GetByVan2(this.CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID)));
      this.WarehousesDataView = App.DB.Warehouse.Warehouse_GetAll_For_Van2(this.CurrentVan.VanID);
      this.DvEquipment = App.DB.VanEquipments.Get(this.CurrentVan.VanID);
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentVan.IgnoreExceptionsOnSetMethods = true;
        this.CurrentVan.SetRegistration = (object) this.txtProfile.Text.Trim();
        this.CurrentVan.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentVan.SetPreferredSupplierID = (object) Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID);
        if (DateTime.Compare(this.CurrentVan.InsuranceDue, DateTime.MinValue) == 0)
          this.CurrentVan.InsuranceDue = DateAndTime.Now;
        if (DateTime.Compare(this.CurrentVan.MOTDue, DateTime.MinValue) == 0)
          this.CurrentVan.MOTDue = DateAndTime.Now;
        if (DateTime.Compare(this.CurrentVan.TaxDue, DateTime.MinValue) == 0)
          this.CurrentVan.TaxDue = DateAndTime.Now;
        if (DateTime.Compare(this.CurrentVan.ServiceDue, DateTime.MinValue) == 0)
          this.CurrentVan.ServiceDue = DateAndTime.Now;
        if (this.CurrentVan.MileageLimit < 1.0)
          this.CurrentVan.SetMileageLimit = (object) 1;
        if (this.CurrentVan.PeriodValue < 1)
          this.CurrentVan.SetPeriodValue = (object) 1;
        if (this.CurrentVan.PeriodType < 1)
          this.CurrentVan.SetPeriodType = (object) 1;
        this.CurrentVan.SetExcludeFromAutoReplenishment = this.chkExcludeFromAutoStockReplen.Checked;
        this.CurrentVan.SetUseContainerStock = this.chkContainer.Checked;
        this.CurrentVan.SecondaryPrice = this.chkSecondaryPrice.Checked;
        new VanValidator().Validate(this.CurrentVan);
        if (this.CurrentVan.Exists)
          App.DB.Van.Update(this.CurrentVan, this.WarehousesDataView, false);
        else
          this.CurrentVan = App.DB.Van.Insert(this.CurrentVan, "", this.WarehousesDataView, false);
        App.MainForm.RefreshEntity(this.CurrentVan.VanID, "");
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
        int num = (int) App.ShowMessage(this.CurrentVan.Registration + " profile has been saved.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    public void SetupProductsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgProducts, false);
      DataGridTableStyle tableStyle = this.dgProducts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Location";
      dataGridLabelColumn1.MappingName = "Location";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "typemakemodel";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 180;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "GC Number";
      dataGridLabelColumn3.MappingName = "ProductNumber";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 140;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Amount";
      dataGridLabelColumn4.MappingName = "Amount";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblProduct.ToString();
      this.dgProducts.TableStyles.Add(tableStyle);
    }

    public void SetupPartsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgParts, false);
      this.dgParts.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Location";
      dataGridLabelColumn1.MappingName = "Location";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Part Name";
      dataGridLabelColumn2.MappingName = "PartName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 180;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part Number";
      dataGridLabelColumn3.MappingName = "PartNumber";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 140;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Amount";
      dataGridLabelColumn4.MappingName = "Amount";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridEditableTextBoxColumn editableTextBoxColumn1 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn1.Format = "";
      editableTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn1.HeaderText = "MinQty";
      editableTextBoxColumn1.MappingName = "Min";
      editableTextBoxColumn1.ReadOnly = false;
      editableTextBoxColumn1.Width = 120;
      editableTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn1);
      DataGridEditableTextBoxColumn editableTextBoxColumn2 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn2.Format = "";
      editableTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn2.HeaderText = "MaxQty";
      editableTextBoxColumn2.MappingName = "Max";
      editableTextBoxColumn2.ReadOnly = false;
      editableTextBoxColumn2.Width = 120;
      editableTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn2);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "MinMaxID";
      dataGridLabelColumn5.MappingName = "MinMaxID";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      this.dgParts.TableStyles.Add(tableStyle);
    }

    public void SetupWarehousesDatagrid()
    {
      Helper.SetUpDataGrid(this.dgWarehouses, false);
      DataGridTableStyle tableStyle = this.dgWarehouses.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgWarehouses.ReadOnly = false;
      this.dgWarehouses.AllowSorting = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Name";
      dataGridLabelColumn.MappingName = "Name";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = Enums.TableNames.tblWarehouse.ToString();
      this.dgWarehouses.TableStyles.Add(tableStyle);
    }

    public void DgSetupVanEquipment()
    {
      Helper.SetUpDataGrid(this.dgEquipment, false);
      DataGridTableStyle tableStyle = this.dgEquipment.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Equipment/Tool";
      dataGridLabelColumn1.MappingName = "Equipment";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 400;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date Added";
      dataGridLabelColumn2.MappingName = "Created";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.MappingName = Enums.TableNames.tblVan.ToString();
      this.dgEquipment.TableStyles.Add(tableStyle);
    }

    public void SetupPartsDataGridView()
    {
      Helper.SetUpDataGridView(this.dgvParts, false);
      this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvParts.AutoGenerateColumns = false;
      this.dgvParts.Columns.Clear();
      this.dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Location";
      viewTextBoxColumn1.FillWeight = 15f;
      viewTextBoxColumn1.DataPropertyName = "Location";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 60f;
      viewTextBoxColumn2.HeaderText = "Part Name";
      viewTextBoxColumn2.DataPropertyName = "PartName";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Part Number";
      viewTextBoxColumn3.DataPropertyName = "PartNumber";
      viewTextBoxColumn3.FillWeight = 25f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Amount";
      viewTextBoxColumn4.DataPropertyName = "Amount";
      viewTextBoxColumn4.FillWeight = 15f;
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Min";
      viewTextBoxColumn5.DataPropertyName = "Min";
      viewTextBoxColumn5.FillWeight = 15f;
      viewTextBoxColumn5.ReadOnly = false;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "Max";
      viewTextBoxColumn6.DataPropertyName = "Max";
      viewTextBoxColumn6.FillWeight = 16f;
      viewTextBoxColumn6.ReadOnly = false;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "MinMaxID";
      viewTextBoxColumn7.DataPropertyName = "MinMaxID";
      viewTextBoxColumn7.FillWeight = 1f;
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn7.Visible = false;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "PartID";
      viewTextBoxColumn8.DataPropertyName = "PartID";
      viewTextBoxColumn8.FillWeight = 1f;
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn8.Visible = false;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "LocationID";
      viewTextBoxColumn9.DataPropertyName = "LocationID";
      viewTextBoxColumn9.FillWeight = 1f;
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn9.Visible = false;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "SPN";
      viewTextBoxColumn10.DataPropertyName = "SPN";
      viewTextBoxColumn10.FillWeight = 25f;
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn10.Visible = true;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      this.dgvParts.Sort((DataGridViewColumn) viewTextBoxColumn7, ListSortDirection.Descending);
    }

    private void dgvParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (this.SelecteddgvPartDataRow == null)
        return;
      int integer1 = Conversions.ToInteger(this.SelecteddgvPartDataRow.Cells[6].Value);
      int integer2 = Conversions.ToInteger(this.SelecteddgvPartDataRow.Cells[4].Value);
      int integer3 = Conversions.ToInteger(this.SelecteddgvPartDataRow.Cells[5].Value);
      int integer4 = Conversions.ToInteger(this.SelecteddgvPartDataRow.Cells[7].Value);
      int integer5 = Conversions.ToInteger(this.SelecteddgvPartDataRow.Cells[8].Value);
      if (integer1 == 0)
        this.SelecteddgvPartDataRow.Cells[6].Value = (object) App.DB.PartTransaction.PartLocations_Insert2(integer4, integer5, integer2, integer3);
      else
        App.DB.PartTransaction.UpdateMinMaxValues(integer1, integer2, integer3);
    }

    private void btnAddPartVanStock_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      int LocationID = 0;
      int MinQty = 1;
      int MaxQty = 1;
      DataView vanRegActiveOnly = App.DB.Location.Locations_Get_ForVanReg_ActiveOnly(this.CurrentVan.Registration);
      FRMFindPart frmFindPart = (FRMFindPart) App.checkIfExists(typeof (FRMFindPart).Name, true) ?? (FRMFindPart) Activator.CreateInstance(typeof (FRMFindPart));
      frmFindPart.ShowInTaskbar = false;
      frmFindPart.TableToSearch = Enums.TableNames.tblPartSupplier;
      int num1 = (int) frmFindPart.ShowDialog();
      if (frmFindPart.DialogResult != DialogResult.OK)
        return;
      DataRow[] datarows = frmFindPart.Datarows;
      frmFindPart.Close();
      if (vanRegActiveOnly.Count > 0)
      {
        FRMPartSelectLocation partSelectLocation = (FRMPartSelectLocation) App.checkIfExists(typeof (FRMPartSelectLocation).Name, true) ?? (FRMPartSelectLocation) Activator.CreateInstance(typeof (FRMPartSelectLocation));
        partSelectLocation.Icon = new Icon(partSelectLocation.GetType(), "Logo.ico");
        partSelectLocation.ShowInTaskbar = false;
        partSelectLocation.LocationsDataGridView = vanRegActiveOnly.ToTable();
        int num2 = (int) partSelectLocation.ShowDialog();
        if (partSelectLocation.DialogResult == DialogResult.OK)
          LocationID = partSelectLocation.LocationID;
        partSelectLocation.Close();
      }
      else if (vanRegActiveOnly.Count == 1)
      {
        LocationID = Conversions.ToInteger(vanRegActiveOnly.Table.Rows[0]["LocationID"]);
      }
      else
      {
        int num2 = (int) App.ShowMessage("No Locations available for this engineer, unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        return;
      }
      if (LocationID == 0)
      {
        int num3 = (int) App.ShowMessage("No Locations selected for this part, unable to proceed, please try again", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        DataRow[] dataRowArray = datarows;
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          int integer = Conversions.ToInteger(dataRow["PartID"]);
          if (this.PartsDataGridView.Select(string.Format("PartID = {0} and LocationID = {1}", RuntimeHelpers.GetObjectValue(dataRow["PartID"]), (object) LocationID)).Length > 0)
          {
            int num2 = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "A part has already been added and therefore cannot be added again. - ", dataRow["PartName"])), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else
          {
            App.DB.PartTransaction.Insert(new PartTransaction()
            {
              SetLocationID = (object) LocationID,
              SetAmount = (object) 0,
              SetPartID = (object) integer,
              SetTransactionTypeID = (object) 1
            });
            App.DB.Part.Part_Locations_Insert(integer, LocationID, MinQty, MaxQty);
          }
          checked { ++index; }
        }
        if (datarows.Length > -1)
        {
          this.PartsDataGridView = App.DB.PartTransaction.GetByVan2(this.CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID)));
          DataGridViewColumn column = this.dgvParts.Columns[6];
          if (column != null)
            this.dgvParts.Sort(column, ListSortDirection.Descending);
          int num2 = (int) App.ShowMessage("Part(s) Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.Cursor = Cursors.Default;
      }
    }

    private void btnDeletePartVanStock_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.dgvParts.SelectedCells.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataGridViewCell current = (DataGridViewCell) enumerator1.Current;
          arrayList.Add((object) current.OwningRow);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      arrayList.Reverse();
      IEnumerator enumerator2;
      try
      {
        enumerator2 = arrayList.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator2.Current;
          if (Conversions.ToInteger(current.Cells[3].Value) > 0)
          {
            int num = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) "The part ", current.Cells[2].Value), (object) " has positive stock, please process an adjustment before deleting")), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Cursor = Cursors.Default;
            return;
          }
          int integer1 = Conversions.ToInteger(current.Cells[7].Value);
          int integer2 = Conversions.ToInteger(current.Cells[8].Value);
          if ((uint) integer1 > 0U & (uint) integer2 > 0U)
          {
            App.DB.PartTransaction.Insert(new PartTransaction()
            {
              SetLocationID = (object) integer2,
              SetAmount = (object) 0,
              SetPartID = (object) integer1,
              SetTransactionTypeID = (object) 1
            });
            App.DB.PartTransaction.DeleteByPartAndLocation(integer1, integer2);
            App.DB.Part.Part_Locations_Delete(integer1, integer2);
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.PartsDataGridView = App.DB.PartTransaction.GetByVan2(this.CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID)));
      int num1 = (int) App.ShowMessage("Part(s) Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.Cursor = Cursors.Default;
    }

    private void dgvParts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewColumn column = this.dgvParts.Columns[e.ColumnIndex];
      DataGridViewColumn sortedColumn = this.dgvParts.SortedColumn;
      ListSortDirection direction;
      if (sortedColumn != null)
      {
        if (sortedColumn == column && this.dgvParts.SortOrder == SortOrder.Ascending)
        {
          direction = ListSortDirection.Descending;
        }
        else
        {
          direction = ListSortDirection.Ascending;
          sortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        }
      }
      else
        direction = ListSortDirection.Ascending;
      this.dgvParts.Sort(column, direction);
      if (direction == ListSortDirection.Ascending)
        column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
      else
        column.HeaderCell.SortGlyphDirection = SortOrder.Descending;
    }

    private void btnClearVanStockProfile_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      Enums.SecuritySystemModules ssm1 = Enums.SecuritySystemModules.IT;
      Enums.SecuritySystemModules ssm2 = Enums.SecuritySystemModules.AllFeatures;
      if (App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2))
      {
        IEnumerator enumerator1;
        IEnumerator enumerator2;
        if (App.ShowMessage("Do you want to clear only the items with 0, 0, 0?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          try
          {
            enumerator1 = ((IEnumerable) this.dgvParts.Rows).GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
              int integer1 = Conversions.ToInteger(current.Cells[3].Value);
              int integer2 = Conversions.ToInteger(current.Cells[7].Value);
              int integer3 = Conversions.ToInteger(current.Cells[8].Value);
              num4 = Conversions.ToInteger(current.Cells[6].Value);
              int integer4 = Conversions.ToInteger(current.Cells[4].Value);
              int integer5 = Conversions.ToInteger(current.Cells[5].Value);
              if (integer1 == 0 & integer4 == 0 & integer5 == 0 && (uint) integer2 > 0U & (uint) integer3 > 0U)
              {
                App.DB.PartTransaction.Insert(new PartTransaction()
                {
                  SetLocationID = (object) integer3,
                  SetAmount = (object) 0,
                  SetPartID = (object) integer2,
                  SetTransactionTypeID = (object) 1
                });
                App.DB.PartTransaction.DeleteByPartAndLocation(integer2, integer3);
                App.DB.Part.Part_Locations_Delete(integer2, integer3);
                checked { ++num5; }
              }
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        else
        {
          try
          {
            enumerator2 = ((IEnumerable) this.dgvParts.Rows).GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataGridViewRow current = (DataGridViewRow) enumerator2.Current;
              num1 = Conversions.ToInteger(current.Cells[3].Value);
              int integer1 = Conversions.ToInteger(current.Cells[7].Value);
              int integer2 = Conversions.ToInteger(current.Cells[8].Value);
              num4 = Conversions.ToInteger(current.Cells[6].Value);
              num2 = Conversions.ToInteger(current.Cells[4].Value);
              num3 = Conversions.ToInteger(current.Cells[5].Value);
              if ((uint) integer1 > 0U & (uint) integer2 > 0U)
              {
                App.DB.PartTransaction.Insert(new PartTransaction()
                {
                  SetLocationID = (object) integer2,
                  SetAmount = (object) 0,
                  SetPartID = (object) integer1,
                  SetTransactionTypeID = (object) 1
                });
                App.DB.PartTransaction.DeleteByPartAndLocation(integer1, integer2);
                App.DB.Part.Part_Locations_Delete(integer1, integer2);
                checked { ++num5; }
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        this.PartsDataGridView = App.DB.PartTransaction.GetByVan2(this.CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPreferredSupplierID)));
        int num6 = (int) App.ShowMessage("Parts Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num7 = (int) App.ShowMessage("This process can only be used by a member of IT or Barry Ellis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      this.Cursor = Cursors.Default;
    }

    public void Export()
    {
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.IT;
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("Location");
      datatableIn.Columns.Add("Part Name");
      datatableIn.Columns.Add("Part Number (MPN)");
      datatableIn.Columns.Add("Amount");
      datatableIn.Columns.Add("Min");
      datatableIn.Columns.Add("Max");
      if (App.loggedInUser.HasAccessToModule(ssm))
        datatableIn.Columns.Add("PartID");
      datatableIn.Columns.Add("SPN");
      int num = checked (this.dgvParts.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        DataGridViewRow row1 = this.dgvParts.Rows[index];
        DataRow row2 = datatableIn.NewRow();
        row2["Location"] = RuntimeHelpers.GetObjectValue(row1.Cells[0].Value);
        row2["Part Name"] = RuntimeHelpers.GetObjectValue(row1.Cells[1].Value);
        row2["Part Number (MPN)"] = RuntimeHelpers.GetObjectValue(row1.Cells[2].Value);
        row2["Amount"] = RuntimeHelpers.GetObjectValue(row1.Cells[3].Value);
        row2["Min"] = RuntimeHelpers.GetObjectValue(row1.Cells[4].Value);
        row2["Max"] = RuntimeHelpers.GetObjectValue(row1.Cells[5].Value);
        if (App.loggedInUser.HasAccessToModule(ssm))
          row2["PartID"] = RuntimeHelpers.GetObjectValue(row1.Cells[7].Value);
        row2["SPN"] = RuntimeHelpers.GetObjectValue(row1.Cells[9].Value);
        datatableIn.Rows.Add(row2);
        checked { ++index; }
      }
      Exporting exporting = new Exporting(datatableIn, "Van Stock Profiles", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    private void btnExportStockProfile_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnSaveEquipment_Click(object sender, EventArgs e)
    {
      string equipment = this.txtEquipmentTool.Text.Trim();
      int num1 = Helper.MakeIntegerValid((object) this.CurrentVan?.VanID);
      if (num1 == 0)
        return;
      if (string.IsNullOrWhiteSpace(equipment))
      {
        int num2 = (int) App.ShowMessage("Tool required!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        App.DB.VanEquipments.Insert(num1, equipment);
        this.DvEquipment = App.DB.VanEquipments.Get(num1);
      }
    }

    private void btnDeleteEquipment_Click(object sender, EventArgs e)
    {
      int vanId = Helper.MakeIntegerValid((object) this.CurrentVan?.VanID);
      if (vanId == 0 || this.DrSelectedEquipment == null)
        return;
      int Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedEquipment["Id"]));
      App.DB.VanEquipments.Delete(Id);
      this.DvEquipment = App.DB.VanEquipments.Get(vanId);
    }
  }
}
