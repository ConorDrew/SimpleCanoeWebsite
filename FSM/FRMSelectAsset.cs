// Decompiled with JetBrains decompiler
// Type: FSM.FRMSelectAsset
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
  public class FRMSelectAsset : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _SiteID;
    private DataView _dvAssets;

    public FRMSelectAsset()
    {
      this.Load += new EventHandler(this.FRMChooseAsset_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets
    {
      get
      {
        return this._dgAssets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgAssets_DoubleClick);
        DataGrid dgAssets1 = this._dgAssets;
        if (dgAssets1 != null)
          dgAssets1.DoubleClick -= eventHandler;
        this._dgAssets = value;
        DataGrid dgAssets2 = this._dgAssets;
        if (dgAssets2 == null)
          return;
        dgAssets2.DoubleClick += eventHandler;
      }
    }

    internal virtual CheckBox chkCERT2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnNoAsset
    {
      get
      {
        return this._btnNoAsset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNoAsset_Click);
        Button btnNoAsset1 = this._btnNoAsset;
        if (btnNoAsset1 != null)
          btnNoAsset1.Click -= eventHandler;
        this._btnNoAsset = value;
        Button btnNoAsset2 = this._btnNoAsset;
        if (btnNoAsset2 == null)
          return;
        btnNoAsset2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.btnOK = new Button();
      this.GroupBox1 = new GroupBox();
      this.dgAssets = new DataGrid();
      this.btnNoAsset = new Button();
      this.chkCERT2 = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.dgAssets.BeginInit();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(16, 40);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(320, 24);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Please select an Appliance to be serviced";
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(480, 312);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgAssets);
      this.GroupBox1.Location = new System.Drawing.Point(8, 64);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(544, 243);
      this.GroupBox1.TabIndex = 5;
      this.GroupBox1.TabStop = false;
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(8, 18);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(528, 217);
      this.dgAssets.TabIndex = 0;
      this.btnNoAsset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnNoAsset.Location = new System.Drawing.Point(8, 312);
      this.btnNoAsset.Name = "btnNoAsset";
      this.btnNoAsset.Size = new Size(94, 23);
      this.btnNoAsset.TabIndex = 6;
      this.btnNoAsset.Text = "No Appliance";
      this.btnNoAsset.Visible = false;
      this.chkCERT2.AutoSize = true;
      this.chkCERT2.Location = new System.Drawing.Point(229, 316);
      this.chkCERT2.Name = "chkCERT2";
      this.chkCERT2.Size = new Size(91, 17);
      this.chkCERT2.TabIndex = 7;
      this.chkCERT2.Text = "Certificate?";
      this.chkCERT2.UseVisualStyleBackColor = true;
      this.chkCERT2.Checked = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(560, 342);
      this.ControlBox = false;
      this.Controls.Add((Control) this.chkCERT2);
      this.Controls.Add((Control) this.btnNoAsset);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.Label1);
      this.MinimumSize = new Size(568, 376);
      this.Name = nameof (FRMSelectAsset);
      this.Text = "Select an Appliance";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnNoAsset, 0);
      this.Controls.SetChildIndex((Control) this.chkCERT2, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupAssetDataGrid();
      this.AssetsDataview = App.DB.Asset.Asset_GetForSite(this.SiteID);
      this.AssetsDataview.AllowNew = true;
      DataRowView dataRowView1 = this.AssetsDataview.AddNew();
      dataRowView1["Product"] = (object) "Boiler - Unknown";
      dataRowView1["AssetID"] = (object) 2;
      dataRowView1.EndEdit();
      DataRowView dataRowView2 = this.AssetsDataview.AddNew();
      dataRowView2["Product"] = (object) "Storage Boiler - Unknown";
      dataRowView2["AssetID"] = (object) 3;
      dataRowView2.EndEdit();
      DataRowView dataRowView3 = this.AssetsDataview.AddNew();
      dataRowView3["Product"] = (object) "Oil Boiler - Unknown";
      dataRowView3["AssetID"] = (object) 4;
      dataRowView3.EndEdit();
      DataRowView dataRowView4 = this.AssetsDataview.AddNew();
      dataRowView4["Product"] = (object) "Gas Fire - Unknown";
      dataRowView4["AssetID"] = (object) 5;
      dataRowView4.EndEdit();
      DataRowView dataRowView5 = this.AssetsDataview.AddNew();
      dataRowView5["Product"] = (object) "Unit Heater - Unknown";
      dataRowView5["AssetID"] = (object) 6;
      dataRowView5.EndEdit();
      DataRowView dataRowView6 = this.AssetsDataview.AddNew();
      dataRowView6["Product"] = (object) "Large Unit Heater - Unknown";
      dataRowView6["AssetID"] = (object) 7;
      dataRowView6.EndEdit();
      DataRowView dataRowView7 = this.AssetsDataview.AddNew();
      dataRowView7["Product"] = (object) "Water Heater - Unknown";
      dataRowView7["AssetID"] = (object) 8;
      dataRowView7.EndEdit();
      DataRowView dataRowView8 = this.AssetsDataview.AddNew();
      dataRowView8["Product"] = (object) "Unvented Cylinder - Unknown";
      dataRowView8["AssetID"] = (object) 9;
      dataRowView8.EndEdit();
      DataRowView dataRowView9 = this.AssetsDataview.AddNew();
      dataRowView9["Product"] = (object) "Unvented Cylinder - Unknown";
      dataRowView9["AssetID"] = (object) 9;
      dataRowView9.EndEdit();
      DataRowView dataRowView10 = this.AssetsDataview.AddNew();
      dataRowView10["Product"] = (object) "Cooker - Unknown";
      dataRowView10["AssetID"] = (object) 10;
      dataRowView10.EndEdit();
      DataRowView dataRowView11 = this.AssetsDataview.AddNew();
      dataRowView11["Product"] = (object) "Hob - Unknown";
      dataRowView11["AssetID"] = (object) 11;
      dataRowView11.EndEdit();
      DataRowView dataRowView12 = this.AssetsDataview.AddNew();
      dataRowView12["Product"] = (object) "Warm Air Unit - Unknown";
      dataRowView12["AssetID"] = (object) 12;
      dataRowView12.EndEdit();
      DataRowView dataRowView13 = this.AssetsDataview.AddNew();
      dataRowView13["Product"] = (object) "Air Source - Unknown";
      dataRowView13["AssetID"] = (object) 13;
      dataRowView13.EndEdit();
      DataRowView dataRowView14 = this.AssetsDataview.AddNew();
      dataRowView14["Product"] = (object) "Range Cooker - Unknown";
      dataRowView14["AssetID"] = (object) 14;
      dataRowView14.EndEdit();
      this.dgAssets.DataSource = (object) this.AssetsDataview;
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

    private DataView AssetsDataview
    {
      get
      {
        return this._dvAssets;
      }
      set
      {
        this._dvAssets = value;
        this._dvAssets.AllowNew = false;
        this._dvAssets.AllowEdit = false;
        this._dvAssets.AllowDelete = false;
        this._dvAssets.Table.TableName = Enums.TableNames.tblAsset.ToString();
        this.dgAssets.DataSource = (object) this.AssetsDataview;
      }
    }

    public DataRow SelectedAssetDataRow
    {
      get
      {
        return this.dgAssets.CurrentRowIndex != -1 ? this.AssetsDataview[this.dgAssets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupAssetDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "AssetID";
      dataGridLabelColumn1.MappingName = "AssetID";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 0;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Product";
      dataGridLabelColumn2.MappingName = "Product";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 250;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Location";
      dataGridLabelColumn3.MappingName = "Location";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.SelectedAssetDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.DialogResult = DialogResult.OK;
    }

    private void dgAssets_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedAssetDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.DialogResult = DialogResult.OK;
    }

    private void FRMChooseAsset_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnNoAsset_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Yes;
    }
  }
}
