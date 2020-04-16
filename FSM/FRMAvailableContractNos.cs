// Decompiled with JetBrains decompiler
// Type: FSM.FRMAvailableContractNos
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMAvailableContractNos : FRMBaseForm, IForm
  {
    private IContainer components;
    public TextBox txtRef;
    private DataView _dvContracts;

    public FRMAvailableContractNos()
    {
      this.Load += new EventHandler(this.FRMAvailableContractNos_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual DataGrid dgAvailableContractNos
    {
      get
      {
        return this._dgAvailableContractNos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgAvailableContractNos_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgAvailableContractNos_Click);
        DataGrid availableContractNos1 = this._dgAvailableContractNos;
        if (availableContractNos1 != null)
        {
          availableContractNos1.Click -= eventHandler1;
          availableContractNos1.CurrentCellChanged -= eventHandler2;
        }
        this._dgAvailableContractNos = value;
        DataGrid availableContractNos2 = this._dgAvailableContractNos;
        if (availableContractNos2 == null)
          return;
        availableContractNos2.Click += eventHandler1;
        availableContractNos2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtPrefix
    {
      get
      {
        return this._txtPrefix;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPrefix_TextChanged);
        TextBox txtPrefix1 = this._txtPrefix;
        if (txtPrefix1 != null)
          txtPrefix1.TextChanged -= eventHandler;
        this._txtPrefix = value;
        TextBox txtPrefix2 = this._txtPrefix;
        if (txtPrefix2 == null)
          return;
        txtPrefix2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPostfix
    {
      get
      {
        return this._txtPostfix;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPostfix_TextChanged);
        TextBox txtPostfix1 = this._txtPostfix;
        if (txtPostfix1 != null)
          txtPostfix1.TextChanged -= eventHandler;
        this._txtPostfix = value;
        TextBox txtPostfix2 = this._txtPostfix;
        if (txtPostfix2 == null)
          return;
        txtPostfix2.TextChanged += eventHandler;
      }
    }

    internal virtual Button btnSelect
    {
      get
      {
        return this._btnSelect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelect_Click);
        Button btnSelect1 = this._btnSelect;
        if (btnSelect1 != null)
          btnSelect1.Click -= eventHandler;
        this._btnSelect = value;
        Button btnSelect2 = this._btnSelect;
        if (btnSelect2 == null)
          return;
        btnSelect2.Click += eventHandler;
      }
    }

    internal virtual Label lblResult { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostfix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbContractNumbers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (FRMAvailableContractNos));
      this.dgAvailableContractNos = new DataGrid();
      this.txtPrefix = new TextBox();
      this.txtPostfix = new TextBox();
      this.lblPrefix = new Label();
      this.lblPostfix = new Label();
      this.gpbContractNumbers = new GroupBox();
      this.lblResult = new Label();
      this.btnSelect = new Button();
      this.dgAvailableContractNos.BeginInit();
      this.gpbContractNumbers.SuspendLayout();
      this.SuspendLayout();
      this.dgAvailableContractNos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAvailableContractNos.DataMember = "";
      this.dgAvailableContractNos.HeaderForeColor = SystemColors.ControlText;
      this.dgAvailableContractNos.Location = new System.Drawing.Point(11, 74);
      this.dgAvailableContractNos.Name = "dgAvailableContractNos";
      this.dgAvailableContractNos.Size = new Size(293, 301);
      this.dgAvailableContractNos.TabIndex = 0;
      this.txtPrefix.Location = new System.Drawing.Point(12, 45);
      this.txtPrefix.Name = "txtPrefix";
      this.txtPrefix.Size = new Size(120, 21);
      this.txtPrefix.TabIndex = 1;
      this.txtPrefix.Text = "";
      this.txtPostfix.Location = new System.Drawing.Point(184, 45);
      this.txtPostfix.Name = "txtPostfix";
      this.txtPostfix.Size = new Size(120, 21);
      this.txtPostfix.TabIndex = 2;
      this.txtPostfix.Text = "";
      this.lblPrefix.Location = new System.Drawing.Point(11, 23);
      this.lblPrefix.Name = "lblPrefix";
      this.lblPrefix.Size = new Size(120, 17);
      this.lblPrefix.TabIndex = 3;
      this.lblPrefix.Text = "Prefix:";
      this.lblPostfix.Location = new System.Drawing.Point(180, 23);
      this.lblPostfix.Name = "lblPostfix";
      this.lblPostfix.Size = new Size(120, 17);
      this.lblPostfix.TabIndex = 4;
      this.lblPostfix.Text = "Postfix";
      this.gpbContractNumbers.Controls.Add((Control) this.lblResult);
      this.gpbContractNumbers.Controls.Add((Control) this.btnSelect);
      this.gpbContractNumbers.Controls.Add((Control) this.lblPrefix);
      this.gpbContractNumbers.Controls.Add((Control) this.txtPrefix);
      this.gpbContractNumbers.Controls.Add((Control) this.lblPostfix);
      this.gpbContractNumbers.Controls.Add((Control) this.txtPostfix);
      this.gpbContractNumbers.Controls.Add((Control) this.dgAvailableContractNos);
      this.gpbContractNumbers.Location = new System.Drawing.Point(11, 39);
      this.gpbContractNumbers.Name = "gpbContractNumbers";
      this.gpbContractNumbers.Size = new Size(319, 414);
      this.gpbContractNumbers.TabIndex = 5;
      this.gpbContractNumbers.TabStop = false;
      this.gpbContractNumbers.Text = "Contract Numbers";
      this.lblResult.Location = new System.Drawing.Point(12, 380);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new Size(197, 25);
      this.lblResult.TabIndex = 6;
      this.lblResult.Text = "Label3";
      this.btnSelect.Cursor = Cursors.Hand;
      this.btnSelect.UseVisualStyleBackColor = true;
      this.btnSelect.Location = new System.Drawing.Point(217, 381);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new Size(90, 25);
      this.btnSelect.TabIndex = 5;
      this.btnSelect.Text = "&Select";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.BackColor = Color.White;
      this.ClientSize = new Size(340, 458);
      this.Controls.Add((Control) this.gpbContractNumbers);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(346, 490);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(346, 490);
      this.Name = nameof (FRMAvailableContractNos);
      this.Text = "Available Contract Nos";
      this.Controls.SetChildIndex((Control) this.gpbContractNumbers, 0);
      this.dgAvailableContractNos.EndInit();
      this.gpbContractNumbers.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.txtRef = (TextBox) this.get_GetParameter(0);
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupContractsDataGrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
    {
    }

    private DataView ContractsDataview
    {
      get
      {
        return this._dvContracts;
      }
      set
      {
        this._dvContracts = value;
        this._dvContracts.AllowNew = false;
        this._dvContracts.AllowEdit = false;
        this._dvContracts.AllowDelete = false;
        this._dvContracts.Table.TableName = Enums.TableNames.tblContractOption3.ToString();
        this.dgAvailableContractNos.DataSource = (object) this.ContractsDataview;
      }
    }

    private void SetupContractsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAvailableContractNos, false);
      DataGridTableStyle tableStyle = this.dgAvailableContractNos.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Reference";
      dataGridLabelColumn.MappingName = "Ref";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 135;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContractOption3.ToString();
      this.dgAvailableContractNos.TableStyles.Add(tableStyle);
    }

    private void PopulatePage()
    {
      try
      {
        this.ContractsDataview = new DataView(App.DB.ContractOption3.ContractReference_Get(this.txtPrefix.Text, this.txtPostfix.Text));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("Available contract numbers cannot be loaded : " + ex.Message), MsgBoxStyle.Exclamation, (object) null);
        ProjectData.ClearProjectError();
      }
      this.PopulateResult();
    }

    private void PopulateResult()
    {
      this.lblResult.Text = "";
      if (this.txtPrefix.Text.Trim().Length > 0)
        this.lblResult.Text = this.txtPrefix.Text + "/";
      Label lblResult1;
      string str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) (lblResult1 = this.lblResult).Text, this.ContractsDataview[this.dgAvailableContractNos.CurrentRowIndex]["REF"]));
      lblResult1.Text = str1;
      if (this.txtPostfix.Text.Trim().Length <= 0)
        return;
      Label lblResult2;
      string str2 = (lblResult2 = this.lblResult).Text + "/" + this.txtPostfix.Text;
      lblResult2.Text = str2;
    }

    private void FRMAvailableContractNos_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupContractsDataGrid();
      this.PopulatePage();
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
      if (this.lblResult.Text.Trim().Length <= 0)
        return;
      this.txtRef.Text = this.lblResult.Text;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void txtPrefix_TextChanged(object sender, EventArgs e)
    {
      if (this.txtPrefix.Text.Length > 0 && Versioned.IsNumeric((object) this.txtPrefix.Text.Substring(checked (this.txtPrefix.Text.Length - 1), 1)) | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtPrefix.Text.Substring(checked (this.txtPrefix.Text.Length - 1), 1), "/", false) == 0)
        this.txtPrefix.Text = this.txtPrefix.Text.Substring(0, checked (this.txtPrefix.Text.Length - 1));
      this.PopulatePage();
      this.txtPrefix.Focus();
    }

    private void txtPostfix_TextChanged(object sender, EventArgs e)
    {
      if (this.txtPostfix.Text.Length > 0 && Versioned.IsNumeric((object) this.txtPostfix.Text.Substring(checked (this.txtPostfix.Text.Length - 1), 1)) | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtPostfix.Text.Substring(checked (this.txtPostfix.Text.Length - 1), 1), "/", false) == 0)
        this.txtPostfix.Text = this.txtPostfix.Text.Substring(0, checked (this.txtPostfix.Text.Length - 1));
      this.PopulatePage();
      this.txtPostfix.Focus();
    }

    private void dgAvailableContractNos_Click(object sender, EventArgs e)
    {
      this.PopulateResult();
    }
  }
}
