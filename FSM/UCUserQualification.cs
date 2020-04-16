// Decompiled with JetBrains decompiler
// Type: FSM.UCUserQualification
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Users;
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
  public class UCUserQualification : UCBase, IUserControl
  {
    private IContainer components;
    private User _currentUser;
    private DataView _dvTrainingQualifications;

    public UCUserQualification()
    {
      this.Load += new EventHandler(this.UCUserQualification_Load);
      this.InitializeComponent();
      ComboBox qualificationType = this.cboQualificationType;
      Combo.SetUpCombo(ref qualificationType, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualificationType = qualificationType;
      ComboBox cboQualification = this.cboQualification;
      Combo.SetUpComboQual(ref cboQualification, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFullName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFullName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpUserQualifications { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlQualifications { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualificationType
    {
      get
      {
        return this._cboQualificationType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQualificationType_SelectedIndexChanged);
        ComboBox qualificationType1 = this._cboQualificationType;
        if (qualificationType1 != null)
          qualificationType1.SelectedIndexChanged -= eventHandler;
        this._cboQualificationType = value;
        ComboBox qualificationType2 = this._cboQualificationType;
        if (qualificationType2 == null)
          return;
        qualificationType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblQualificationType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationBooked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBooked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQualificatioNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationExpires { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblExpiry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpQualificationPassed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPassed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveTrainingQualifications
    {
      get
      {
        return this._btnRemoveTrainingQualifications;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveTrainingQualifications_Click);
        Button trainingQualifications1 = this._btnRemoveTrainingQualifications;
        if (trainingQualifications1 != null)
          trainingQualifications1.Click -= eventHandler;
        this._btnRemoveTrainingQualifications = value;
        Button trainingQualifications2 = this._btnRemoveTrainingQualifications;
        if (trainingQualifications2 == null)
          return;
        trainingQualifications2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgTrainingQualifications
    {
      get
      {
        return this._dgTrainingQualifications;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgTrainingQualifications_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgTrainingQualifications_Click);
        DataGrid trainingQualifications1 = this._dgTrainingQualifications;
        if (trainingQualifications1 != null)
        {
          trainingQualifications1.Click -= eventHandler1;
          trainingQualifications1.CurrentCellChanged -= eventHandler2;
        }
        this._dgTrainingQualifications = value;
        DataGrid trainingQualifications2 = this._dgTrainingQualifications;
        if (trainingQualifications2 == null)
          return;
        trainingQualifications2.Click += eventHandler1;
        trainingQualifications2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual Button btnSaveQualification
    {
      get
      {
        return this._btnSaveQualification;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveQualification_Click);
        Button saveQualification1 = this._btnSaveQualification;
        if (saveQualification1 != null)
          saveQualification1.Click -= eventHandler;
        this._btnSaveQualification = value;
        Button saveQualification2 = this._btnSaveQualification;
        if (saveQualification2 == null)
          return;
        saveQualification2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpDetails = new GroupBox();
      this.lblEmail = new Label();
      this.txtEmailAddress = new TextBox();
      this.txtFullName = new TextBox();
      this.lblFullName = new Label();
      this.grpUserQualifications = new GroupBox();
      this.pnlQualifications = new Panel();
      this.btnSaveQualification = new Button();
      this.cboQualificationType = new ComboBox();
      this.lblQualificationType = new Label();
      this.dtpQualificationBooked = new DateTimePicker();
      this.lblBooked = new Label();
      this.cboQualification = new ComboBox();
      this.lblQualification = new Label();
      this.txtQualificatioNote = new TextBox();
      this.lblNote = new Label();
      this.dtpQualificationExpires = new DateTimePicker();
      this.lblExpiry = new Label();
      this.dtpQualificationPassed = new DateTimePicker();
      this.lblPassed = new Label();
      this.btnRemoveTrainingQualifications = new Button();
      this.dgTrainingQualifications = new DataGrid();
      this.grpDetails.SuspendLayout();
      this.grpUserQualifications.SuspendLayout();
      this.pnlQualifications.SuspendLayout();
      this.dgTrainingQualifications.BeginInit();
      this.SuspendLayout();
      this.grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.lblEmail);
      this.grpDetails.Controls.Add((Control) this.txtEmailAddress);
      this.grpDetails.Controls.Add((Control) this.txtFullName);
      this.grpDetails.Controls.Add((Control) this.lblFullName);
      this.grpDetails.FlatStyle = FlatStyle.System;
      this.grpDetails.Location = new System.Drawing.Point(12, 19);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(606, 95);
      this.grpDetails.TabIndex = 37;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.lblEmail.AutoSize = true;
      this.lblEmail.Location = new System.Drawing.Point(9, 54);
      this.lblEmail.Name = "lblEmail";
      this.lblEmail.Size = new Size(38, 13);
      this.lblEmail.TabIndex = 16;
      this.lblEmail.Text = "Email";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point((int) sbyte.MaxValue, 51);
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(454, 21);
      this.txtEmailAddress.TabIndex = 15;
      this.txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFullName.Location = new System.Drawing.Point((int) sbyte.MaxValue, 24);
      this.txtFullName.MaxLength = (int) byte.MaxValue;
      this.txtFullName.Name = "txtFullName";
      this.txtFullName.Size = new Size(454, 21);
      this.txtFullName.TabIndex = 4;
      this.lblFullName.Location = new System.Drawing.Point(8, 24);
      this.lblFullName.Name = "lblFullName";
      this.lblFullName.Size = new Size(64, 16);
      this.lblFullName.TabIndex = 5;
      this.lblFullName.Text = "Full Name";
      this.grpUserQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpUserQualifications.Controls.Add((Control) this.pnlQualifications);
      this.grpUserQualifications.Controls.Add((Control) this.btnRemoveTrainingQualifications);
      this.grpUserQualifications.Controls.Add((Control) this.dgTrainingQualifications);
      this.grpUserQualifications.Location = new System.Drawing.Point(12, 128);
      this.grpUserQualifications.Name = "grpUserQualifications";
      this.grpUserQualifications.Size = new Size(606, 538);
      this.grpUserQualifications.TabIndex = 38;
      this.grpUserQualifications.TabStop = false;
      this.grpUserQualifications.Text = "Training && Qualifications";
      this.pnlQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlQualifications.Controls.Add((Control) this.btnSaveQualification);
      this.pnlQualifications.Controls.Add((Control) this.cboQualificationType);
      this.pnlQualifications.Controls.Add((Control) this.lblQualificationType);
      this.pnlQualifications.Controls.Add((Control) this.dtpQualificationBooked);
      this.pnlQualifications.Controls.Add((Control) this.lblBooked);
      this.pnlQualifications.Controls.Add((Control) this.cboQualification);
      this.pnlQualifications.Controls.Add((Control) this.lblQualification);
      this.pnlQualifications.Controls.Add((Control) this.txtQualificatioNote);
      this.pnlQualifications.Controls.Add((Control) this.lblNote);
      this.pnlQualifications.Controls.Add((Control) this.dtpQualificationExpires);
      this.pnlQualifications.Controls.Add((Control) this.lblExpiry);
      this.pnlQualifications.Controls.Add((Control) this.dtpQualificationPassed);
      this.pnlQualifications.Controls.Add((Control) this.lblPassed);
      this.pnlQualifications.Location = new System.Drawing.Point(5, 20);
      this.pnlQualifications.Name = "pnlQualifications";
      this.pnlQualifications.Size = new Size(593, 222);
      this.pnlQualifications.TabIndex = 42;
      this.btnSaveQualification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveQualification.Location = new System.Drawing.Point(445, 196);
      this.btnSaveQualification.Name = "btnSaveQualification";
      this.btnSaveQualification.Size = new Size(137, 23);
      this.btnSaveQualification.TabIndex = 56;
      this.btnSaveQualification.Text = "Add / Update";
      this.cboQualificationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualificationType.Location = new System.Drawing.Point(139, 5);
      this.cboQualificationType.Name = "cboQualificationType";
      this.cboQualificationType.Size = new Size(443, 21);
      this.cboQualificationType.TabIndex = 54;
      this.cboQualificationType.Text = "ComboBox1";
      this.lblQualificationType.Location = new System.Drawing.Point(7, 5);
      this.lblQualificationType.Name = "lblQualificationType";
      this.lblQualificationType.Size = new Size(126, 23);
      this.lblQualificationType.TabIndex = 55;
      this.lblQualificationType.Text = "Qualification Type";
      this.dtpQualificationBooked.Checked = false;
      this.dtpQualificationBooked.Location = new System.Drawing.Point(332, 68);
      this.dtpQualificationBooked.Name = "dtpQualificationBooked";
      this.dtpQualificationBooked.ShowCheckBox = true;
      this.dtpQualificationBooked.Size = new Size(152, 21);
      this.dtpQualificationBooked.TabIndex = 52;
      this.lblBooked.Location = new System.Drawing.Point(269, 74);
      this.lblBooked.Name = "lblBooked";
      this.lblBooked.Size = new Size(57, 23);
      this.lblBooked.TabIndex = 53;
      this.lblBooked.Text = "Booked";
      this.cboQualification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboQualification.Location = new System.Drawing.Point(96, 36);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(486, 21);
      this.cboQualification.TabIndex = 1;
      this.cboQualification.Text = "ComboBox1";
      this.lblQualification.Location = new System.Drawing.Point(8, 36);
      this.lblQualification.Name = "lblQualification";
      this.lblQualification.Size = new Size(100, 23);
      this.lblQualification.TabIndex = 48;
      this.lblQualification.Text = "Qualification";
      this.txtQualificatioNote.AcceptsReturn = true;
      this.txtQualificatioNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQualificatioNote.Location = new System.Drawing.Point(96, 132);
      this.txtQualificatioNote.Multiline = true;
      this.txtQualificatioNote.Name = "txtQualificatioNote";
      this.txtQualificatioNote.ScrollBars = ScrollBars.Vertical;
      this.txtQualificatioNote.Size = new Size(486, 55);
      this.txtQualificatioNote.TabIndex = 4;
      this.lblNote.Location = new System.Drawing.Point(8, 132);
      this.lblNote.Name = "lblNote";
      this.lblNote.Size = new Size(67, 20);
      this.lblNote.TabIndex = 47;
      this.lblNote.Text = "Note";
      this.dtpQualificationExpires.Checked = false;
      this.dtpQualificationExpires.Location = new System.Drawing.Point(96, 99);
      this.dtpQualificationExpires.Name = "dtpQualificationExpires";
      this.dtpQualificationExpires.ShowCheckBox = true;
      this.dtpQualificationExpires.Size = new Size(152, 21);
      this.dtpQualificationExpires.TabIndex = 3;
      this.lblExpiry.Location = new System.Drawing.Point(8, 105);
      this.lblExpiry.Name = "lblExpiry";
      this.lblExpiry.Size = new Size(80, 23);
      this.lblExpiry.TabIndex = 43;
      this.lblExpiry.Text = "Expires";
      this.dtpQualificationPassed.Checked = false;
      this.dtpQualificationPassed.Location = new System.Drawing.Point(96, 68);
      this.dtpQualificationPassed.Name = "dtpQualificationPassed";
      this.dtpQualificationPassed.ShowCheckBox = true;
      this.dtpQualificationPassed.Size = new Size(152, 21);
      this.dtpQualificationPassed.TabIndex = 2;
      this.lblPassed.Location = new System.Drawing.Point(8, 74);
      this.lblPassed.Name = "lblPassed";
      this.lblPassed.Size = new Size(80, 23);
      this.lblPassed.TabIndex = 41;
      this.lblPassed.Text = "Date Passed";
      this.btnRemoveTrainingQualifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRemoveTrainingQualifications.Location = new System.Drawing.Point(10, 506);
      this.btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications";
      this.btnRemoveTrainingQualifications.Size = new Size(75, 21);
      this.btnRemoveTrainingQualifications.TabIndex = 7;
      this.btnRemoveTrainingQualifications.Text = "Delete";
      this.dgTrainingQualifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTrainingQualifications.DataMember = "";
      this.dgTrainingQualifications.HeaderForeColor = SystemColors.ControlText;
      this.dgTrainingQualifications.Location = new System.Drawing.Point(8, 248);
      this.dgTrainingQualifications.Name = "dgTrainingQualifications";
      this.dgTrainingQualifications.Size = new Size(590, 250);
      this.dgTrainingQualifications.TabIndex = 6;
      this.Controls.Add((Control) this.grpUserQualifications);
      this.Controls.Add((Control) this.grpDetails);
      this.Name = nameof (UCUserQualification);
      this.Size = new Size(630, 679);
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.grpUserQualifications.ResumeLayout(false);
      this.pnlQualifications.ResumeLayout(false);
      this.pnlQualifications.PerformLayout();
      this.dgTrainingQualifications.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupTrainingQualificationsDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentUser;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public User CurrentUser
    {
      get
      {
        return this._currentUser;
      }
      set
      {
        this._currentUser = value;
        if (this.CurrentUser == null)
          this.CurrentUser = new User() { Exists = false };
        if (!this.CurrentUser.Exists)
          return;
        this.Populate(0);
        this.PopulateTrainingQualifications();
      }
    }

    private DataView TrainingQualificationsDataView
    {
      get
      {
        return this._dvTrainingQualifications;
      }
      set
      {
        if (value != null)
        {
          this._dvTrainingQualifications = value;
          this._dvTrainingQualifications.Table.TableName = Enums.TableNames.tblUserQualification.ToString();
        }
        this.dgTrainingQualifications.DataSource = (object) this._dvTrainingQualifications;
      }
    }

    public DataRow SelectedTrainingQualificationsRow
    {
      get
      {
        DataRow dataRow;
        if (this.TrainingQualificationsDataView != null)
          dataRow = this.TrainingQualificationsDataView.Table.Rows.Count <= 0 ? (DataRow) null : this.TrainingQualificationsDataView[this.dgTrainingQualifications.CurrentRowIndex].Row;
        return dataRow;
      }
    }

    public void SetupTrainingQualificationsDataGrid()
    {
      try
      {
        this.dgTrainingQualifications.TableStyles.Add(new DataGridTableStyle());
        Helper.SetUpDataGrid(this.dgTrainingQualifications, false);
        DataGridTableStyle tableStyle = this.dgTrainingQualifications.TableStyles[0];
        DataGridTextBoxColumn gridTextBoxColumn1 = new DataGridTextBoxColumn();
        gridTextBoxColumn1.HeaderText = "Level\\Qualification";
        gridTextBoxColumn1.MappingName = "Level";
        gridTextBoxColumn1.NullText = "";
        gridTextBoxColumn1.Width = 150;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn1);
        DataGridTextBoxColumn gridTextBoxColumn2 = new DataGridTextBoxColumn();
        gridTextBoxColumn2.HeaderText = "Description";
        gridTextBoxColumn2.MappingName = "Description";
        gridTextBoxColumn2.NullText = "";
        gridTextBoxColumn2.Width = 200;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn2);
        DataGridTextBoxColumn gridTextBoxColumn3 = new DataGridTextBoxColumn();
        gridTextBoxColumn3.HeaderText = "Notes";
        gridTextBoxColumn3.MappingName = "Notes";
        gridTextBoxColumn3.NullText = "";
        gridTextBoxColumn3.Width = 400;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn3);
        DataGridTextBoxColumn gridTextBoxColumn4 = new DataGridTextBoxColumn();
        gridTextBoxColumn4.HeaderText = "Passed";
        gridTextBoxColumn4.MappingName = "DatePassed";
        gridTextBoxColumn4.Format = "dd/MM/yyyy";
        gridTextBoxColumn4.NullText = "";
        gridTextBoxColumn4.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn4);
        DataGridTextBoxColumn gridTextBoxColumn5 = new DataGridTextBoxColumn();
        gridTextBoxColumn5.HeaderText = "Expires";
        gridTextBoxColumn5.MappingName = "DateExpires";
        gridTextBoxColumn5.Format = "dd/MM/yyyy";
        gridTextBoxColumn5.NullText = "";
        gridTextBoxColumn5.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn5);
        DataGridTextBoxColumn gridTextBoxColumn6 = new DataGridTextBoxColumn();
        gridTextBoxColumn6.HeaderText = "Booked";
        gridTextBoxColumn6.MappingName = "DateBooked";
        gridTextBoxColumn6.Format = "dd/MM/yyyy";
        gridTextBoxColumn6.NullText = "";
        gridTextBoxColumn6.Width = 80;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn6);
        tableStyle.MappingName = Enums.TableNames.tblUserQualification.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void UCUserQualification_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSaveQualification_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow row1 = this.TrainingQualificationsDataView.Table.NewRow();
        BaseValidator inValidator = new BaseValidator();
        bool flag;
        if (this.TrainingQualificationsDataView.Table.Select("LevelID = " + Combo.get_GetSelectedItemValue(this.cboQualification)).Length > 0)
        {
          if (App.ShowMessage("This will update the qualification. " + "Do you wish to Procceed.", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            return;
          flag = true;
        }
        if (this.cboQualification.SelectedIndex == 0)
          inValidator.AddCriticalMessage("'Qualification' is required");
        if (!this.dtpQualificationPassed.Checked)
          inValidator.AddCriticalMessage("'Date Passed' must be specified.");
        if (inValidator.ValidatorMessages.CriticalMessages.Count > 0)
          throw new ValidationException(inValidator);
        Conversions.ToString(false);
        string str = Conversions.ToString(Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*').Length > 1);
        row1["LevelID"] = (object) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboQualification));
        row1["Level"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[1].Trim();
        if (Conversions.ToBoolean(str))
          row1["Description"] = (object) Combo.get_GetSelectedItemDescription(this.cboQualification).ToString().Split('*')[0].Trim();
        row1["Notes"] = (object) this.txtQualificatioNote.Text;
        if (this.dtpQualificationPassed.Checked)
          row1["DatePassed"] = (object) this.dtpQualificationPassed.Value;
        if (this.dtpQualificationExpires.Checked)
          row1["DateExpires"] = (object) this.dtpQualificationExpires.Value;
        if (this.dtpQualificationBooked.Checked)
          row1["DateBooked"] = (object) this.dtpQualificationBooked.Value;
        if (flag)
        {
          DataRow row2 = this.TrainingQualificationsDataView.Table.Rows[this.dgTrainingQualifications.CurrentRowIndex];
          IEnumerator enumerator;
          try
          {
            enumerator = row2.Table.Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataColumn current = (DataColumn) enumerator.Current;
              row2[current] = RuntimeHelpers.GetObjectValue(row1[current]);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else
          this.TrainingQualificationsDataView.Table.Rows.Add(row1);
        this.ClearQualificationDetailPanel();
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
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnRemoveTrainingQualifications_Click(object sender, EventArgs e)
    {
      try
      {
        DataRow qualificationsRow = this.SelectedTrainingQualificationsRow;
        if (qualificationsRow != null && MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          this.TrainingQualificationsDataView.Table.Rows.Remove(qualificationsRow);
        this.ClearQualificationDetailPanel();
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
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void cboQualificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        int skillTypeId = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboQualificationType));
        if (skillTypeId > 0)
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpCombo(ref cboQualification, App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
        else
        {
          ComboBox cboQualification = this.cboQualification;
          Combo.SetUpComboQual(ref cboQualification, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
          this.cboQualification = cboQualification;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentUser = App.DB.User.Get(ID, false);
      this.txtFullName.Text = this.CurrentUser.Fullname;
      this.txtEmailAddress.Text = this.CurrentUser.EmailAddress;
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
        if (!this.CurrentUser.Exists)
        {
          flag = false;
        }
        else
        {
          App.DB.UserLevels.Insert(this.CurrentUser.UserID, this.TrainingQualificationsDataView.Table);
          flag = true;
        }
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

    private void PopulateTrainingQualifications()
    {
      try
      {
        this.TrainingQualificationsDataView = App.DB.UserLevels.GetForSetup(this.CurrentUser.UserID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("The following error occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ClearQualificationDetailPanel()
    {
      ComboBox cboQualification = this.cboQualification;
      Combo.SetSelectedComboItem_By_Value(ref cboQualification, Conversions.ToString(0));
      this.cboQualification = cboQualification;
      this.txtQualificatioNote.Text = "";
      this.dtpQualificationPassed.Checked = false;
      this.dtpQualificationExpires.Checked = false;
    }

    private void dgTrainingQualifications_Click(object sender, EventArgs e)
    {
      try
      {
        ComboBox comboBox = this.cboQualificationType;
        Combo.SetUpCombo(ref comboBox, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Enums.ComboValues.Please_Select);
        this.cboQualificationType = comboBox;
        comboBox = this.cboQualification;
        Combo.SetSelectedComboItem_By_Value(ref comboBox, this.SelectedTrainingQualificationsRow[0].ToString());
        this.cboQualification = comboBox;
        this.txtQualificatioNote.Text = Conversions.ToString(this.SelectedTrainingQualificationsRow[3]);
        this.dtpQualificationPassed.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[4]);
        this.dtpQualificationExpires.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[5]);
        this.dtpQualificationBooked.Value = Conversions.ToDate(this.SelectedTrainingQualificationsRow[6]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }
  }
}
