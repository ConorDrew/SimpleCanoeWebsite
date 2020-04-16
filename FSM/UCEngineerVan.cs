// Decompiled with JetBrains decompiler
// Type: FSM.UCEngineerVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVans;
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
  public class UCEngineerVan : UCBase, IUserControl
  {
    private IContainer components;
    private int _VanID;
    private EngineerVan _currentEngineerVan;

    public UCEngineerVan()
    {
      this.Load += new EventHandler(this.UCEngineerVan_Load);
      this._VanID = 0;
      this.InitializeComponent();
      ComboBox cboEngineerId = this.cboEngineerID;
      Combo.SetUpCombo(ref cboEngineerId, App.DB.Engineer.Engineer_GetAll_IncludeDeleted().Table, "EngineerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineerID = cboEngineerId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpEngineerVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineerID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpStartDateTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStartDateTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEndDateTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEndDateTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkUntilFurtherNotice
    {
      get
      {
        return this._chkUntilFurtherNotice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkUntilFurtherNotice_CheckedChanged);
        CheckBox untilFurtherNotice1 = this._chkUntilFurtherNotice;
        if (untilFurtherNotice1 != null)
          untilFurtherNotice1.CheckedChanged -= eventHandler;
        this._chkUntilFurtherNotice = value;
        CheckBox untilFurtherNotice2 = this._chkUntilFurtherNotice;
        if (untilFurtherNotice2 == null)
          return;
        untilFurtherNotice2.CheckedChanged += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerVan = new GroupBox();
      this.chkUntilFurtherNotice = new CheckBox();
      this.cboEngineerID = new ComboBox();
      this.lblEngineerID = new Label();
      this.dtpStartDateTime = new DateTimePicker();
      this.lblStartDateTime = new Label();
      this.dtpEndDateTime = new DateTimePicker();
      this.lblEndDateTime = new Label();
      this.grpEngineerVan.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerVan.Controls.Add((Control) this.chkUntilFurtherNotice);
      this.grpEngineerVan.Controls.Add((Control) this.cboEngineerID);
      this.grpEngineerVan.Controls.Add((Control) this.lblEngineerID);
      this.grpEngineerVan.Controls.Add((Control) this.dtpStartDateTime);
      this.grpEngineerVan.Controls.Add((Control) this.lblStartDateTime);
      this.grpEngineerVan.Controls.Add((Control) this.dtpEndDateTime);
      this.grpEngineerVan.Controls.Add((Control) this.lblEndDateTime);
      this.grpEngineerVan.Location = new System.Drawing.Point(8, 8);
      this.grpEngineerVan.Name = "grpEngineerVan";
      this.grpEngineerVan.Size = new Size(601, 114);
      this.grpEngineerVan.TabIndex = 1;
      this.grpEngineerVan.TabStop = false;
      this.grpEngineerVan.Text = "Main Details";
      this.chkUntilFurtherNotice.Location = new System.Drawing.Point(408, 88);
      this.chkUntilFurtherNotice.Name = "chkUntilFurtherNotice";
      this.chkUntilFurtherNotice.Size = new Size(136, 24);
      this.chkUntilFurtherNotice.TabIndex = 5;
      this.chkUntilFurtherNotice.Text = "Until Further Notice";
      this.cboEngineerID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboEngineerID.Cursor = Cursors.Hand;
      this.cboEngineerID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEngineerID.Location = new System.Drawing.Point(112, 24);
      this.cboEngineerID.Name = "cboEngineerID";
      this.cboEngineerID.Size = new Size(480, 21);
      this.cboEngineerID.TabIndex = 2;
      this.cboEngineerID.Tag = (object) "EngineerVan.EngineerID";
      this.lblEngineerID.Location = new System.Drawing.Point(8, 24);
      this.lblEngineerID.Name = "lblEngineerID";
      this.lblEngineerID.Size = new Size(71, 20);
      this.lblEngineerID.TabIndex = 31;
      this.lblEngineerID.Text = "Engineer";
      this.dtpStartDateTime.CustomFormat = "dd MMMM yyyy HH:mm";
      this.dtpStartDateTime.Format = DateTimePickerFormat.Custom;
      this.dtpStartDateTime.Location = new System.Drawing.Point(112, 56);
      this.dtpStartDateTime.Name = "dtpStartDateTime";
      this.dtpStartDateTime.Size = new Size(184, 21);
      this.dtpStartDateTime.TabIndex = 3;
      this.dtpStartDateTime.Tag = (object) "EngineerVan.StartDateTime";
      this.lblStartDateTime.Location = new System.Drawing.Point(8, 56);
      this.lblStartDateTime.Name = "lblStartDateTime";
      this.lblStartDateTime.Size = new Size(104, 20);
      this.lblStartDateTime.TabIndex = 31;
      this.lblStartDateTime.Text = "Start Date Time";
      this.dtpEndDateTime.CustomFormat = "dd MMMM yyyy HH:mm";
      this.dtpEndDateTime.Format = DateTimePickerFormat.Custom;
      this.dtpEndDateTime.Location = new System.Drawing.Point(408, 56);
      this.dtpEndDateTime.Name = "dtpEndDateTime";
      this.dtpEndDateTime.Size = new Size(184, 21);
      this.dtpEndDateTime.TabIndex = 4;
      this.dtpEndDateTime.Tag = (object) "EngineerVan.EndDateTime";
      this.lblEndDateTime.Location = new System.Drawing.Point(304, 56);
      this.lblEndDateTime.Name = "lblEndDateTime";
      this.lblEndDateTime.Size = new Size(96, 20);
      this.lblEndDateTime.TabIndex = 31;
      this.lblEndDateTime.Text = "End Date Time";
      this.Controls.Add((Control) this.grpEngineerVan);
      this.Name = nameof (UCEngineerVan);
      this.Size = new Size(616, 136);
      this.grpEngineerVan.ResumeLayout(false);
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
        return (object) this.CurrentEngineerVan;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public int VanID
    {
      get
      {
        return this._VanID;
      }
      set
      {
        this._VanID = value;
      }
    }

    public EngineerVan CurrentEngineerVan
    {
      get
      {
        return this._currentEngineerVan;
      }
      set
      {
        this._currentEngineerVan = value;
        if (this.CurrentEngineerVan == null)
        {
          this.CurrentEngineerVan = new EngineerVan();
          this.CurrentEngineerVan.Exists = false;
        }
        if (!this.CurrentEngineerVan.Exists)
          return;
        this.Populate(0);
      }
    }

    private void UCEngineerVan_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void chkUntilFurtherNotice_CheckedChanged(object sender, EventArgs e)
    {
      this.dtpEndDateTime.Enabled = !this.chkUntilFurtherNotice.Checked;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentEngineerVan = App.DB.EngineerVan.EngineerVan_Get(ID);
      ComboBox cboEngineerId = this.cboEngineerID;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineerId, Conversions.ToString(this.CurrentEngineerVan.EngineerID));
      this.cboEngineerID = cboEngineerId;
      this.dtpStartDateTime.Value = this.CurrentEngineerVan.StartDateTime;
      if (DateTime.Compare(this.CurrentEngineerVan.EndDateTime, DateTime.MinValue) == 0)
      {
        this.chkUntilFurtherNotice.Checked = true;
        this.dtpEndDateTime.Value = DateAndTime.Now;
      }
      else
      {
        this.chkUntilFurtherNotice.Checked = false;
        this.dtpEndDateTime.Value = this.CurrentEngineerVan.EndDateTime;
      }
      this.dtpEndDateTime.Enabled = !this.chkUntilFurtherNotice.Checked;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentEngineerVan.IgnoreExceptionsOnSetMethods = true;
        this.CurrentEngineerVan.SetEngineerID = (object) Combo.get_GetSelectedItemValue(this.cboEngineerID);
        this.CurrentEngineerVan.SetVanID = (object) this.VanID;
        this.CurrentEngineerVan.StartDateTime = this.dtpStartDateTime.Value;
        if (this.chkUntilFurtherNotice.Checked | DateTime.Compare(this.dtpEndDateTime.Value, DateTime.Now) > 0)
        {
          this.CurrentEngineerVan.EndDateTime = !this.chkUntilFurtherNotice.Checked ? this.dtpEndDateTime.Value : DateTime.MinValue;
          DataRow[] dataRowArray1 = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(this.VanID).Table.Select("EnddateTime > '" + Conversions.ToString(DateTime.Now) + "' Or EnddateTime Is null");
          if (dataRowArray1.Length > 0)
          {
            if (App.ShowMessage("There is currently an engineer assigned to this profile, by adding this engineer you will be removing the current engineer assigned, would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
              flag = false;
              goto label_27;
            }
            else
            {
              DataRow[] dataRowArray2 = dataRowArray1;
              int index = 0;
              while (index < dataRowArray2.Length)
              {
                int EngineerVanID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray2[index]["EngineerVanID"]));
                if (EngineerVanID > 0)
                {
                  EngineerVan oEngineerVan = App.DB.EngineerVan.EngineerVan_Get(EngineerVanID);
                  oEngineerVan.EndDateTime = DateTime.Now;
                  App.DB.EngineerVan.Update(oEngineerVan);
                }
                checked { ++index; }
              }
            }
          }
        }
        else
          this.CurrentEngineerVan.EndDateTime = this.dtpEndDateTime.Value;
        new EngineerVanValidator().Validate(this.CurrentEngineerVan);
        if (this.CurrentEngineerVan.Exists)
        {
          App.DB.EngineerVan.Update(this.CurrentEngineerVan);
          if (DateTime.Compare(this.CurrentEngineerVan.StartDateTime, DateTime.Now.AddDays(2.0)) < 0)
          {
            if (App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID > 0 && App.DB.User.Get(App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID, false).EmailAddress.Length > 2)
              this.Email(EmailAddress.StockFinancials, "The engineer (" + App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).Name + ") has been deactivated On the van " + App.DB.Van.Van_Get(this.CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, App.DB.User.Get(App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID, false).EmailAddress);
            else
              this.Email(EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).Name + ") has been deactivated On the van " + App.DB.Van.Van_Get(this.CurrentEngineerVan.VanID).Registration ?? "", App.loggedInUser.Fullname, "");
          }
        }
        else
        {
          this.CurrentEngineerVan = App.DB.EngineerVan.Insert(this.CurrentEngineerVan);
          if (App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID > 0 && App.DB.User.Get(App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID, false).EmailAddress.Length > 2)
            this.Email(EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).Name + ") has been added To van " + App.DB.Van.Van_Get(this.CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, App.DB.User.Get(App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).ManagerUserID, false).EmailAddress);
          else
            this.Email(EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(this.CurrentEngineerVan.EngineerID).Name + ") has been added To van " + App.DB.Van.Van_Get(this.CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, "");
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentEngineerVan.EngineerVanID);
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
label_27:
      return flag;
    }

    private void Email(string emailadd, string message, string addinguser, string cc)
    {
      if (!new Emails()
      {
        From = EmailAddress.Gabriel,
        To = emailadd,
        CC = cc,
        Subject = "An Engineer to van link has been modified",
        Body = ("<span style='font-family: Calibri, Sans-Serif'><p>Hi</p><p>User : " + addinguser + " has modified an engineer to van link</p><p>" + message + "</p><p>King Regards,</p><p>" + App.TheSystem.Configuration.CompanyName + "</p></span>"),
        SendMe = true
      }.Send())
        ;
    }
  }
}
