// Decompiled with JetBrains decompiler
// Type: FSM.FRMViewEngineer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.FSMDataSetTableAdapters;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMViewEngineer : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataTable _engineer;

    public FRMViewEngineer(DataTable dtEngineer)
    {
      this.Load += new EventHandler(this.FRMEngineer_Load);
      this._engineer = (DataTable) null;
      this.Engineer = dtEngineer;
      this.InitializeComponent();
    }

    internal virtual GroupBox grpEngineerInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPhone { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngGroup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblManName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Customer_Get_ForSiteIDTableAdapter Customer_Get_ForSiteIDTableAdapter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPostcodes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpQualifications { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQual { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtManager { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineerGroup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerInfo = new GroupBox();
      this.txtManager = new TextBox();
      this.txtDepartment = new TextBox();
      this.txtEngineerGroup = new TextBox();
      this.txtRegion = new TextBox();
      this.txtPhone = new TextBox();
      this.txtName = new TextBox();
      this.lblEngGroup = new Label();
      this.lblRegion = new Label();
      this.lblDepartment = new Label();
      this.lblTelNum = new Label();
      this.lblManName = new Label();
      this.lblName = new Label();
      this.Customer_Get_ForSiteIDTableAdapter1 = new Customer_Get_ForSiteIDTableAdapter();
      this.grpPostcodes = new GroupBox();
      this.txtPostcode = new TextBox();
      this.grpQualifications = new GroupBox();
      this.txtQual = new TextBox();
      this.btnClose = new Button();
      this.grpEngineerInfo.SuspendLayout();
      this.grpPostcodes.SuspendLayout();
      this.grpQualifications.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerInfo.Controls.Add((Control) this.txtManager);
      this.grpEngineerInfo.Controls.Add((Control) this.txtDepartment);
      this.grpEngineerInfo.Controls.Add((Control) this.txtEngineerGroup);
      this.grpEngineerInfo.Controls.Add((Control) this.txtRegion);
      this.grpEngineerInfo.Controls.Add((Control) this.txtPhone);
      this.grpEngineerInfo.Controls.Add((Control) this.txtName);
      this.grpEngineerInfo.Controls.Add((Control) this.lblEngGroup);
      this.grpEngineerInfo.Controls.Add((Control) this.lblRegion);
      this.grpEngineerInfo.Controls.Add((Control) this.lblDepartment);
      this.grpEngineerInfo.Controls.Add((Control) this.lblTelNum);
      this.grpEngineerInfo.Controls.Add((Control) this.lblManName);
      this.grpEngineerInfo.Controls.Add((Control) this.lblName);
      this.grpEngineerInfo.Enabled = false;
      this.grpEngineerInfo.Location = new System.Drawing.Point(0, 53);
      this.grpEngineerInfo.Name = "grpEngineerInfo";
      this.grpEngineerInfo.Size = new Size(829, 146);
      this.grpEngineerInfo.TabIndex = 1;
      this.grpEngineerInfo.TabStop = false;
      this.grpEngineerInfo.Text = "Engineer Information";
      this.txtManager.Enabled = false;
      this.txtManager.Location = new System.Drawing.Point(560, 31);
      this.txtManager.Name = "txtManager";
      this.txtManager.Size = new Size(247, 21);
      this.txtManager.TabIndex = 64;
      this.txtDepartment.Enabled = false;
      this.txtDepartment.Location = new System.Drawing.Point(560, 60);
      this.txtDepartment.Name = "txtDepartment";
      this.txtDepartment.Size = new Size(247, 21);
      this.txtDepartment.TabIndex = 63;
      this.txtEngineerGroup.Enabled = false;
      this.txtEngineerGroup.Location = new System.Drawing.Point(560, 90);
      this.txtEngineerGroup.Name = "txtEngineerGroup";
      this.txtEngineerGroup.Size = new Size(247, 21);
      this.txtEngineerGroup.TabIndex = 62;
      this.txtRegion.Enabled = false;
      this.txtRegion.Location = new System.Drawing.Point(120, 90);
      this.txtRegion.Name = "txtRegion";
      this.txtRegion.Size = new Size(247, 21);
      this.txtRegion.TabIndex = 61;
      this.txtPhone.Enabled = false;
      this.txtPhone.Location = new System.Drawing.Point(120, 60);
      this.txtPhone.Name = "txtPhone";
      this.txtPhone.Size = new Size(247, 21);
      this.txtPhone.TabIndex = 8;
      this.txtName.Enabled = false;
      this.txtName.Location = new System.Drawing.Point(120, 31);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(247, 21);
      this.txtName.TabIndex = 6;
      this.lblEngGroup.AutoSize = true;
      this.lblEngGroup.Location = new System.Drawing.Point(453, 93);
      this.lblEngGroup.Name = "lblEngGroup";
      this.lblEngGroup.Size = new Size(101, 13);
      this.lblEngGroup.TabIndex = 5;
      this.lblEngGroup.Text = "Engineer Group:";
      this.lblRegion.AutoSize = true;
      this.lblRegion.Location = new System.Drawing.Point(12, 93);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(51, 13);
      this.lblRegion.TabIndex = 4;
      this.lblRegion.Text = "Region:";
      this.lblDepartment.AutoSize = true;
      this.lblDepartment.Location = new System.Drawing.Point(453, 63);
      this.lblDepartment.Name = "lblDepartment";
      this.lblDepartment.Size = new Size(80, 13);
      this.lblDepartment.TabIndex = 3;
      this.lblDepartment.Text = "Department:";
      this.lblTelNum.AutoSize = true;
      this.lblTelNum.Location = new System.Drawing.Point(12, 63);
      this.lblTelNum.Name = "lblTelNum";
      this.lblTelNum.Size = new Size(96, 13);
      this.lblTelNum.TabIndex = 2;
      this.lblTelNum.Text = "Phone Number:";
      this.lblManName.AutoSize = true;
      this.lblManName.Location = new System.Drawing.Point(453, 34);
      this.lblManName.Name = "lblManName";
      this.lblManName.Size = new Size(61, 13);
      this.lblManName.TabIndex = 1;
      this.lblManName.Text = "Manager:";
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(12, 34);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(45, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name:";
      this.Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = true;
      this.grpPostcodes.Controls.Add((Control) this.txtPostcode);
      this.grpPostcodes.Location = new System.Drawing.Point(0, 205);
      this.grpPostcodes.Name = "grpPostcodes";
      this.grpPostcodes.Size = new Size(829, 159);
      this.grpPostcodes.TabIndex = 2;
      this.grpPostcodes.TabStop = false;
      this.grpPostcodes.Text = "Postcodes";
      this.txtPostcode.Location = new System.Drawing.Point(15, 25);
      this.txtPostcode.Multiline = true;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.ReadOnly = true;
      this.txtPostcode.ScrollBars = ScrollBars.Vertical;
      this.txtPostcode.Size = new Size(792, 116);
      this.txtPostcode.TabIndex = 0;
      this.grpQualifications.Controls.Add((Control) this.txtQual);
      this.grpQualifications.Location = new System.Drawing.Point(0, 370);
      this.grpQualifications.Name = "grpQualifications";
      this.grpQualifications.Size = new Size(829, 159);
      this.grpQualifications.TabIndex = 3;
      this.grpQualifications.TabStop = false;
      this.grpQualifications.Text = "Qualifications";
      this.txtQual.Location = new System.Drawing.Point(15, 25);
      this.txtQual.Multiline = true;
      this.txtQual.Name = "txtQual";
      this.txtQual.ReadOnly = true;
      this.txtQual.ScrollBars = ScrollBars.Vertical;
      this.txtQual.Size = new Size(792, 116);
      this.txtQual.TabIndex = 0;
      this.btnClose.Location = new System.Drawing.Point(15, 532);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(829, 561);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpQualifications);
      this.Controls.Add((Control) this.grpPostcodes);
      this.Controls.Add((Control) this.grpEngineerInfo);
      this.MaximumSize = new Size(845, 600);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(845, 600);
      this.Name = nameof (FRMViewEngineer);
      this.Text = "Viewing Engineer : ";
      this.Controls.SetChildIndex((Control) this.grpEngineerInfo, 0);
      this.Controls.SetChildIndex((Control) this.grpPostcodes, 0);
      this.Controls.SetChildIndex((Control) this.grpQualifications, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.grpEngineerInfo.ResumeLayout(false);
      this.grpEngineerInfo.PerformLayout();
      this.grpPostcodes.ResumeLayout(false);
      this.grpPostcodes.PerformLayout();
      this.grpQualifications.ResumeLayout(false);
      this.grpQualifications.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.Populate();
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public DataTable Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
      }
    }

    private void FRMEngineer_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void Populate()
    {
      this.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Viewing Engineer : ", this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Name"]));
      this.txtName.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Name"])) ? "<<No Name set>>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Name"]);
      this.txtPhone.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["TelephoneNum"])) ? Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["TelephoneNum"]) : "<<No Phone Number Set>>";
      this.txtRegion.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Region"])) ? "<<No Region set>>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Region"]);
      this.txtManager.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Manager"])) ? "<<No Manager set>>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Manager"]);
      this.txtDepartment.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Department"])) ? "<<No Department set>>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Department"]);
      this.txtEngineerGroup.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["EngineerGroup"])) ? "<<No Engineer Group set>>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["EngineerGroup"]);
      this.txtPostcode.Text = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["PostCodes"])) ? "<<No PostCodes set >>" : Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["PostCodes"]);
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Qualifications"])))
        this.txtQual.Text = Conversions.ToString(this.Engineer.AsEnumerable().ElementAtOrDefault<DataRow>(0)["Qualifications"]);
      else
        this.txtQual.Text = "<<No Qualifications set>>";
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
