// Decompiled with JetBrains decompiler
// Type: FSM.FRMChooseAsset
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
  public class FRMChooseAsset : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _JobID;
    private string _part;
    private DataView _dvAssets;

    public FRMChooseAsset()
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
      this.GroupBox1.SuspendLayout();
      this.dgAssets.BeginInit();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(16, 40);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(320, 24);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Please select an Appliance for which the parts were used:";
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
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(560, 342);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnNoAsset);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.Label1);
      this.MinimumSize = new Size(568, 376);
      this.Name = nameof (FRMChooseAsset);
      this.Text = "Select an Appliance";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnNoAsset, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupAssetDataGrid();
      this.AssetsDataview = App.DB.JobAsset.JobAsset_Get_For_Job(this.JobID);
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

    public int JobID
    {
      get
      {
        return this._JobID;
      }
      set
      {
        this._JobID = value;
      }
    }

    public string Part
    {
      get
      {
        return this._part;
      }
      set
      {
        this._part = value;
        if (string.IsNullOrEmpty(this.Part))
          return;
        Label label1;
        string str = (label1 = this.Label1).Text + " " + this.Part;
        label1.Text = str;
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
      dataGridLabelColumn1.HeaderText = "Appliance";
      dataGridLabelColumn1.MappingName = "AssetDescription";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 160;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 160;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Seria lNumber";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 120;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Bought From";
      dataGridLabelColumn4.MappingName = "BoughtFrom";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Supplied By";
      dataGridLabelColumn5.MappingName = "SuppliedBy";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MMM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Date Fitted";
      dataGridLabelColumn6.MappingName = "DateFitted";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "dd/MMM/yyyy";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Last Serviced Date";
      dataGridLabelColumn7.MappingName = "LastServicedDate";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "dd/MMM/yyyy";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Certificate Last Issued";
      dataGridLabelColumn8.MappingName = "CertificateLastIssued";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "dd/MMM/yyyy";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Notes";
      dataGridLabelColumn9.MappingName = "Notes";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
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
