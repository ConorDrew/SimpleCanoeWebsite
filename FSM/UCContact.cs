// Decompiled with JetBrains decompiler
// Type: FSM.UCContact
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Contacts;
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
  public class UCContact : UCBase, IUserControl
  {
    private IContainer components;
    private int _SiteID;
    private Contact _currentContact;
    private DataView _NotesTable;

    public UCContact()
    {
      this.Load += new EventHandler(this.UCContact_Load);
      this._SiteID = 0;
      this._NotesTable = (DataView) null;
      this.InitializeComponent();
      ComboBox cboSalutation = this.cboSalutation;
      Combo.SetUpCombo(ref cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSalutation = cboSalutation;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFirstName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFirstName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSurname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSurname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMobileNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPortalUsername { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPortalPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteNote
    {
      get
      {
        return this._btnDeleteNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteNote_Click);
        Button btnDeleteNote1 = this._btnDeleteNote;
        if (btnDeleteNote1 != null)
          btnDeleteNote1.Click -= eventHandler;
        this._btnDeleteNote = value;
        Button btnDeleteNote2 = this._btnDeleteNote;
        if (btnDeleteNote2 == null)
          return;
        btnDeleteNote2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddNote
    {
      get
      {
        return this._btnAddNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNote_Click);
        Button btnAddNote1 = this._btnAddNote;
        if (btnAddNote1 != null)
          btnAddNote1.Click -= eventHandler;
        this._btnAddNote = value;
        Button btnAddNote2 = this._btnAddNote;
        if (btnAddNote2 == null)
          return;
        btnAddNote2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgNotes
    {
      get
      {
        return this._dgNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgNotes_DoubleClick);
        DataGrid dgNotes1 = this._dgNotes;
        if (dgNotes1 != null)
          dgNotes1.DoubleClick -= eventHandler;
        this._dgNotes = value;
        DataGrid dgNotes2 = this._dgNotes;
        if (dgNotes2 == null)
          return;
        dgNotes2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkPortalGSRPrint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSalutation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContact = new GroupBox();
      this.cboSalutation = new ComboBox();
      this.Label6 = new Label();
      this.chkPortalGSRPrint = new CheckBox();
      this.txtPortalPassword = new TextBox();
      this.txtPortalUsername = new TextBox();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.txtMobileNo = new TextBox();
      this.Label1 = new Label();
      this.txtFirstName = new TextBox();
      this.lblFirstName = new Label();
      this.txtSurname = new TextBox();
      this.lblSurname = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.GroupBox1 = new GroupBox();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.btnDeleteNote = new Button();
      this.btnAddNote = new Button();
      this.dgNotes = new DataGrid();
      this.txtEID = new TextBox();
      this.Label7 = new Label();
      this.grpContact.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgNotes.BeginInit();
      this.SuspendLayout();
      this.grpContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContact.Controls.Add((Control) this.txtEID);
      this.grpContact.Controls.Add((Control) this.Label7);
      this.grpContact.Controls.Add((Control) this.cboSalutation);
      this.grpContact.Controls.Add((Control) this.Label6);
      this.grpContact.Controls.Add((Control) this.chkPortalGSRPrint);
      this.grpContact.Controls.Add((Control) this.txtPortalPassword);
      this.grpContact.Controls.Add((Control) this.txtPortalUsername);
      this.grpContact.Controls.Add((Control) this.Label3);
      this.grpContact.Controls.Add((Control) this.Label2);
      this.grpContact.Controls.Add((Control) this.txtMobileNo);
      this.grpContact.Controls.Add((Control) this.Label1);
      this.grpContact.Controls.Add((Control) this.txtFirstName);
      this.grpContact.Controls.Add((Control) this.lblFirstName);
      this.grpContact.Controls.Add((Control) this.txtSurname);
      this.grpContact.Controls.Add((Control) this.lblSurname);
      this.grpContact.Controls.Add((Control) this.txtTelephoneNum);
      this.grpContact.Controls.Add((Control) this.lblTelephoneNum);
      this.grpContact.Controls.Add((Control) this.txtEmailAddress);
      this.grpContact.Controls.Add((Control) this.lblEmailAddress);
      this.grpContact.Controls.Add((Control) this.txtFaxNum);
      this.grpContact.Controls.Add((Control) this.lblFaxNum);
      this.grpContact.Location = new System.Drawing.Point(7, 7);
      this.grpContact.Name = "grpContact";
      this.grpContact.Size = new Size(655, 367);
      this.grpContact.TabIndex = 1;
      this.grpContact.TabStop = false;
      this.grpContact.Text = "Main Details";
      this.cboSalutation.Cursor = Cursors.Hand;
      this.cboSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSalutation.Location = new System.Drawing.Point(112, 29);
      this.cboSalutation.Name = "cboSalutation";
      this.cboSalutation.Size = new Size(83, 21);
      this.cboSalutation.TabIndex = 55;
      this.cboSalutation.Tag = (object) "Site.RegionID";
      this.Label6.Location = new System.Drawing.Point(8, 32);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(100, 20);
      this.Label6.TabIndex = 38;
      this.Label6.Text = "Salutation";
      this.chkPortalGSRPrint.AutoSize = true;
      this.chkPortalGSRPrint.CheckAlign = ContentAlignment.MiddleRight;
      this.chkPortalGSRPrint.Location = new System.Drawing.Point(9, 337);
      this.chkPortalGSRPrint.Name = "chkPortalGSRPrint";
      this.chkPortalGSRPrint.Size = new Size(118, 17);
      this.chkPortalGSRPrint.TabIndex = 37;
      this.chkPortalGSRPrint.Text = "Portal GSR Print";
      this.chkPortalGSRPrint.UseVisualStyleBackColor = true;
      this.txtPortalPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPortalPassword.Location = new System.Drawing.Point(112, 279);
      this.txtPortalPassword.MaxLength = 20;
      this.txtPortalPassword.Name = "txtPortalPassword";
      this.txtPortalPassword.Size = new Size(529, 21);
      this.txtPortalPassword.TabIndex = 8;
      this.txtPortalPassword.Tag = (object) "";
      this.txtPortalUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPortalUsername.Location = new System.Drawing.Point(112, 250);
      this.txtPortalUsername.MaxLength = 20;
      this.txtPortalUsername.Name = "txtPortalUsername";
      this.txtPortalUsername.Size = new Size(529, 21);
      this.txtPortalUsername.TabIndex = 7;
      this.txtPortalUsername.Tag = (object) "";
      this.Label3.Location = new System.Drawing.Point(8, 278);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(100, 23);
      this.Label3.TabIndex = 35;
      this.Label3.Text = "Portal Password";
      this.Label2.Location = new System.Drawing.Point(8, 247);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(104, 23);
      this.Label2.TabIndex = 34;
      this.Label2.Text = "Portal Username";
      this.txtMobileNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtMobileNo.Location = new System.Drawing.Point(112, 157);
      this.txtMobileNo.MaxLength = 20;
      this.txtMobileNo.Name = "txtMobileNo";
      this.txtMobileNo.Size = new Size(529, 21);
      this.txtMobileNo.TabIndex = 4;
      this.txtMobileNo.Tag = (object) "Contact.MobileNo";
      this.Label1.Location = new System.Drawing.Point(8, 155);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(109, 20);
      this.Label1.TabIndex = 33;
      this.Label1.Text = "Mobile No";
      this.txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFirstName.Location = new System.Drawing.Point(112, 64);
      this.txtFirstName.MaxLength = (int) byte.MaxValue;
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new Size(529, 21);
      this.txtFirstName.TabIndex = 1;
      this.txtFirstName.Tag = (object) "Contact.FirstName";
      this.lblFirstName.Location = new System.Drawing.Point(8, 62);
      this.lblFirstName.Name = "lblFirstName";
      this.lblFirstName.Size = new Size(109, 20);
      this.lblFirstName.TabIndex = 31;
      this.lblFirstName.Text = "First Name";
      this.txtSurname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSurname.Location = new System.Drawing.Point(112, 95);
      this.txtSurname.MaxLength = (int) byte.MaxValue;
      this.txtSurname.Name = "txtSurname";
      this.txtSurname.Size = new Size(529, 21);
      this.txtSurname.TabIndex = 2;
      this.txtSurname.Tag = (object) "Contact.Surname";
      this.lblSurname.Location = new System.Drawing.Point(8, 93);
      this.lblSurname.Name = "lblSurname";
      this.lblSurname.Size = new Size(109, 20);
      this.lblSurname.TabIndex = 31;
      this.lblSurname.Text = "Surname";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(112, 126);
      this.txtTelephoneNum.MaxLength = 20;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(529, 21);
      this.txtTelephoneNum.TabIndex = 3;
      this.txtTelephoneNum.Tag = (object) "Contact.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(8, 124);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(109, 20);
      this.lblTelephoneNum.TabIndex = 31;
      this.lblTelephoneNum.Text = "Tel";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(112, 188);
      this.txtEmailAddress.MaxLength = 50;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(529, 21);
      this.txtEmailAddress.TabIndex = 5;
      this.txtEmailAddress.Tag = (object) "Contact.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(8, 186);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(109, 20);
      this.lblEmailAddress.TabIndex = 31;
      this.lblEmailAddress.Text = "Email Address";
      this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaxNum.Location = new System.Drawing.Point(112, 219);
      this.txtFaxNum.MaxLength = 20;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(529, 21);
      this.txtFaxNum.TabIndex = 6;
      this.txtFaxNum.Tag = (object) "Contact.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(8, 217);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(109, 20);
      this.lblFaxNum.TabIndex = 31;
      this.lblFaxNum.Text = "Fax";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.btnDeleteNote);
      this.GroupBox1.Controls.Add((Control) this.btnAddNote);
      this.GroupBox1.Controls.Add((Control) this.dgNotes);
      this.GroupBox1.Location = new System.Drawing.Point(8, 387);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(653, 231);
      this.GroupBox1.TabIndex = 38;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Notes";
      this.Label5.Location = new System.Drawing.Point(32, 16);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(160, 16);
      this.Label5.TabIndex = 13;
      this.Label5.Text = "=Active Reminder Set";
      this.Label4.BackColor = Color.LightGreen;
      this.Label4.BorderStyle = BorderStyle.FixedSingle;
      this.Label4.Location = new System.Drawing.Point(8, 16);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(20, 17);
      this.Label4.TabIndex = 12;
      this.btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteNote.Location = new System.Drawing.Point(584, 196);
      this.btnDeleteNote.Name = "btnDeleteNote";
      this.btnDeleteNote.Size = new Size(56, 23);
      this.btnDeleteNote.TabIndex = 11;
      this.btnDeleteNote.Text = "Delete";
      this.btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddNote.Location = new System.Drawing.Point(10, 196);
      this.btnAddNote.Name = "btnAddNote";
      this.btnAddNote.Size = new Size(54, 23);
      this.btnAddNote.TabIndex = 10;
      this.btnAddNote.Text = "Add";
      this.dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgNotes.DataMember = "";
      this.dgNotes.HeaderForeColor = SystemColors.ControlText;
      this.dgNotes.Location = new System.Drawing.Point(8, 32);
      this.dgNotes.Name = "dgNotes";
      this.dgNotes.Size = new Size(637, 164);
      this.dgNotes.TabIndex = 9;
      this.txtEID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEID.Location = new System.Drawing.Point(112, 308);
      this.txtEID.MaxLength = 20;
      this.txtEID.Name = "txtEID";
      this.txtEID.Size = new Size(529, 21);
      this.txtEID.TabIndex = 56;
      this.txtEID.Tag = (object) "";
      this.Label7.Location = new System.Drawing.Point(8, 312);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(100, 23);
      this.Label7.TabIndex = 57;
      this.Label7.Text = "Portal EID ";
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.grpContact);
      this.Name = nameof (UCContact);
      this.Size = new Size(667, 624);
      this.grpContact.ResumeLayout(false);
      this.grpContact.PerformLayout();
      this.GroupBox1.ResumeLayout(false);
      this.dgNotes.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupNotesDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentContact;
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

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Contact CurrentContact
    {
      get
      {
        return this._currentContact;
      }
      set
      {
        this._currentContact = value;
        if (this.CurrentContact == null)
        {
          this.CurrentContact = new Contact();
          this.CurrentContact.Exists = false;
        }
        if (this.CurrentContact.Exists)
        {
          this.btnAddNote.Enabled = true;
          this.btnDeleteNote.Enabled = true;
          this.Populate(0);
        }
        else
        {
          this.btnAddNote.Enabled = false;
          this.btnDeleteNote.Enabled = false;
        }
      }
    }

    public DataView NotesDataView
    {
      get
      {
        return this._NotesTable;
      }
      set
      {
        this._NotesTable = value;
        this._NotesTable.Table.TableName = Enums.TableNames.tblNotes.ToString();
        this._NotesTable.AllowNew = false;
        this._NotesTable.AllowEdit = false;
        this._NotesTable.AllowDelete = false;
        this.dgNotes.DataSource = (object) this.NotesDataView;
      }
    }

    private DataRow SelectedNoteDataRow
    {
      get
      {
        return this.dgNotes.CurrentRowIndex != -1 ? this.NotesDataView[this.dgNotes.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupNotesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgNotes, false);
      DataGridTableStyle tableStyle = this.dgNotes.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      ActiveReminderColourColumn reminderColourColumn = new ActiveReminderColourColumn();
      reminderColourColumn.HeaderText = "";
      reminderColourColumn.MappingName = "ReminderStatusID";
      reminderColourColumn.ReadOnly = true;
      reminderColourColumn.Width = 20;
      reminderColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) reminderColourColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Date";
      dataGridLabelColumn1.MappingName = "NoteDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 110;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Category";
      dataGridLabelColumn2.MappingName = "Category";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Note";
      dataGridLabelColumn3.MappingName = "Note";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 130;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Entered By";
      dataGridLabelColumn4.MappingName = "EnteredBy";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy HH:mm";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Entered On";
      dataGridLabelColumn5.MappingName = "DateCreated";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 110;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "For User";
      dataGridLabelColumn6.MappingName = "UserFor";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblNotes.ToString();
      this.dgNotes.TableStyles.Add(tableStyle);
    }

    private void UCContact_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgNotes_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedNoteDataRow == null)
        return;
      App.ShowForm(typeof (FRMNotes), true, new object[3]
      {
        this.SelectedNoteDataRow["NoteID"],
        (object) this.CurrentContact.ContactID,
        (object) this
      }, false);
    }

    private void btnAddNote_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMNotes), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentContact.ContactID,
        (object) this
      }, false);
      this.NotesDataView = App.DB.Notes.NotesForContact(this.CurrentContact.ContactID);
    }

    private void btnDeleteNote_Click(object sender, EventArgs e)
    {
      if (this.SelectedNoteDataRow == null || App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      App.DB.Notes.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedNoteDataRow["NoteID"])));
      this.NotesDataView = App.DB.Notes.NotesForContact(this.CurrentContact.ContactID);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentContact = App.DB.Contact.Contact_Get(ID);
      ComboBox cboSalutation = this.cboSalutation;
      Combo.SetSelectedComboItem_By_Value(ref cboSalutation, this.CurrentContact.Salutation);
      this.cboSalutation = cboSalutation;
      this.txtFirstName.Text = this.CurrentContact.FirstName;
      this.txtSurname.Text = this.CurrentContact.Surname;
      this.txtTelephoneNum.Text = this.CurrentContact.TelephoneNum;
      this.txtEmailAddress.Text = this.CurrentContact.EmailAddress;
      this.txtFaxNum.Text = this.CurrentContact.FaxNum;
      this.txtMobileNo.Text = this.CurrentContact.MobileNo;
      this.txtPortalUsername.Text = this.CurrentContact.PortalUserName;
      this.txtPortalPassword.Text = this.CurrentContact.PortalPassword;
      this.chkPortalGSRPrint.Checked = this.CurrentContact.PortalGSRPrint;
      this.txtEID.Text = Conversions.ToString(this.CurrentContact.EID);
      this.NotesDataView = App.DB.Notes.NotesForContact(this.CurrentContact.ContactID);
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentContact.IgnoreExceptionsOnSetMethods = true;
        this.CurrentContact.SetPropertyID = (object) this.SiteID;
        this.CurrentContact.SetSalutation = (object) Combo.get_GetSelectedItemValue(this.cboSalutation);
        this.CurrentContact.SetFirstName = (object) this.txtFirstName.Text.Trim();
        this.CurrentContact.SetSurname = (object) this.txtSurname.Text.Trim();
        this.CurrentContact.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentContact.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentContact.SetFaxNum = (object) this.txtFaxNum.Text.Trim();
        this.CurrentContact.SetMobileNo = (object) this.txtMobileNo.Text.Trim();
        this.CurrentContact.SetPortalPassword = (object) this.txtPortalPassword.Text.Trim();
        this.CurrentContact.SetPortalUserName = (object) this.txtPortalUsername.Text.Trim();
        this.CurrentContact.SetPortalGSRPrint = (object) this.chkPortalGSRPrint.Checked;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtEID.Text, "", false) == 0 | !Versioned.IsNumeric((object) this.txtEID.Text))
          this.txtEID.Text = Conversions.ToString(0);
        this.CurrentContact.SetEID = (object) this.txtEID.Text;
        if (this.CurrentContact.Exists)
          App.DB.Contact.Update(this.CurrentContact);
        else
          this.CurrentContact = App.DB.Contact.Insert(this.CurrentContact);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentContact.ContactID);
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
  }
}
