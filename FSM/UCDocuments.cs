// Decompiled with JetBrains decompiler
// Type: FSM.UCDocuments
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Documentss;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCDocuments : UCBase, IUserControl
  {
    private IContainer components;
    private Documents _currentDocuments;
    private Enums.TableNames _EntityToLinkTo;
    private int _IDToLinkTo;

    public UCDocuments()
    {
      this.Load += new EventHandler(this.UCDocuments_Load);
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      ComboBox cboDocumentTypeId = this.cboDocumentTypeID;
      Combo.SetUpCombo(ref cboDocumentTypeId, App.DB.Picklists.GetAll(Enums.PickListTypes.DocumentTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDocumentTypeID = cboDocumentTypeId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTableEnumID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDocumentTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDocumentTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnBrowse
    {
      get
      {
        return this._btnBrowse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnBrowse_Click);
        Button btnBrowse1 = this._btnBrowse;
        if (btnBrowse1 != null)
          btnBrowse1.Click -= eventHandler;
        this._btnBrowse = value;
        Button btnBrowse2 = this._btnBrowse;
        if (btnBrowse2 == null)
          return;
        btnBrowse2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtDocumentName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastUpdated { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOpen
    {
      get
      {
        return this._btnOpen;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOpen_Click);
        Button btnOpen1 = this._btnOpen;
        if (btnOpen1 != null)
          btnOpen1.Click -= eventHandler;
        this._btnOpen = value;
        Button btnOpen2 = this._btnOpen;
        if (btnOpen2 == null)
          return;
        btnOpen2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpDocuments = new GroupBox();
      this.btnOpen = new Button();
      this.lblLastUpdated = new Label();
      this.lblAddedBy = new Label();
      this.txtDocumentName = new TextBox();
      this.btnBrowse = new Button();
      this.lblTableEnumID = new Label();
      this.cboDocumentTypeID = new ComboBox();
      this.lblDocumentTypeID = new Label();
      this.txtName = new TextBox();
      this.lblName = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.txtLocation = new TextBox();
      this.lblLocation = new Label();
      this.grpDocuments.SuspendLayout();
      this.SuspendLayout();
      this.grpDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDocuments.Controls.Add((Control) this.btnOpen);
      this.grpDocuments.Controls.Add((Control) this.lblLastUpdated);
      this.grpDocuments.Controls.Add((Control) this.lblAddedBy);
      this.grpDocuments.Controls.Add((Control) this.txtDocumentName);
      this.grpDocuments.Controls.Add((Control) this.btnBrowse);
      this.grpDocuments.Controls.Add((Control) this.lblTableEnumID);
      this.grpDocuments.Controls.Add((Control) this.cboDocumentTypeID);
      this.grpDocuments.Controls.Add((Control) this.lblDocumentTypeID);
      this.grpDocuments.Controls.Add((Control) this.txtName);
      this.grpDocuments.Controls.Add((Control) this.lblName);
      this.grpDocuments.Controls.Add((Control) this.txtNotes);
      this.grpDocuments.Controls.Add((Control) this.lblNotes);
      this.grpDocuments.Controls.Add((Control) this.txtLocation);
      this.grpDocuments.Controls.Add((Control) this.lblLocation);
      this.grpDocuments.Location = new System.Drawing.Point(8, 8);
      this.grpDocuments.Name = "grpDocuments";
      this.grpDocuments.Size = new Size(636, 533);
      this.grpDocuments.TabIndex = 1;
      this.grpDocuments.TabStop = false;
      this.grpDocuments.Text = "Main Details";
      this.btnOpen.AccessibleDescription = "Open Document";
      this.btnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOpen.Location = new System.Drawing.Point(539, 417);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new Size(88, 23);
      this.btnOpen.TabIndex = 8;
      this.btnOpen.Text = "Open";
      this.lblLastUpdated.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblLastUpdated.ForeColor = Color.Blue;
      this.lblLastUpdated.Location = new System.Drawing.Point(128, 499);
      this.lblLastUpdated.Name = "lblLastUpdated";
      this.lblLastUpdated.Size = new Size(499, 24);
      this.lblLastUpdated.TabIndex = 33;
      this.lblAddedBy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblAddedBy.ForeColor = Color.Blue;
      this.lblAddedBy.Location = new System.Drawing.Point(128, 459);
      this.lblAddedBy.Name = "lblAddedBy";
      this.lblAddedBy.Size = new Size(499, 24);
      this.lblAddedBy.TabIndex = 32;
      this.txtDocumentName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDocumentName.Location = new System.Drawing.Point(128, 418);
      this.txtDocumentName.Name = "txtDocumentName";
      this.txtDocumentName.ReadOnly = true;
      this.txtDocumentName.Size = new Size(403, 21);
      this.txtDocumentName.TabIndex = 7;
      this.txtDocumentName.Tag = (object) "";
      this.btnBrowse.AccessibleDescription = "Find Document To Upload";
      this.btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnBrowse.Location = new System.Drawing.Point(539, 386);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new Size(88, 23);
      this.btnBrowse.TabIndex = 6;
      this.btnBrowse.Text = "Browse";
      this.lblTableEnumID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblTableEnumID.ForeColor = Color.Blue;
      this.lblTableEnumID.Location = new System.Drawing.Point(8, 28);
      this.lblTableEnumID.Name = "lblTableEnumID";
      this.lblTableEnumID.Size = new Size(616, 20);
      this.lblTableEnumID.TabIndex = 31;
      this.cboDocumentTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDocumentTypeID.Cursor = Cursors.Hand;
      this.cboDocumentTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDocumentTypeID.Location = new System.Drawing.Point(128, 59);
      this.cboDocumentTypeID.Name = "cboDocumentTypeID";
      this.cboDocumentTypeID.Size = new Size(499, 21);
      this.cboDocumentTypeID.TabIndex = 2;
      this.cboDocumentTypeID.Tag = (object) "Documents.DocumentTypeID";
      this.lblDocumentTypeID.Location = new System.Drawing.Point(8, 59);
      this.lblDocumentTypeID.Name = "lblDocumentTypeID";
      this.lblDocumentTypeID.Size = new Size(112, 20);
      this.lblDocumentTypeID.TabIndex = 31;
      this.lblDocumentTypeID.Text = "Document Type";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(128, 90);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(499, 21);
      this.txtName.TabIndex = 3;
      this.txtName.Tag = (object) "Documents.Name";
      this.lblName.Location = new System.Drawing.Point(8, 90);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(96, 20);
      this.lblName.TabIndex = 31;
      this.lblName.Text = "Reference";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(128, 121);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Both;
      this.txtNotes.Size = new Size(499, 256);
      this.txtNotes.TabIndex = 4;
      this.txtNotes.Tag = (object) "Documents.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 121);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(112, 20);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.txtLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtLocation.Location = new System.Drawing.Point(128, 387);
      this.txtLocation.MaxLength = 16;
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.ReadOnly = true;
      this.txtLocation.Size = new Size(403, 21);
      this.txtLocation.TabIndex = 5;
      this.txtLocation.Tag = (object) "Documents.Location";
      this.lblLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblLocation.Location = new System.Drawing.Point(8, 387);
      this.lblLocation.Name = "lblLocation";
      this.lblLocation.Size = new Size(104, 20);
      this.lblLocation.TabIndex = 31;
      this.lblLocation.Text = "Document";
      this.Controls.Add((Control) this.grpDocuments);
      this.Name = nameof (UCDocuments);
      this.Size = new Size(651, 555);
      this.grpDocuments.ResumeLayout(false);
      this.grpDocuments.PerformLayout();
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
        return (object) this.CurrentDocuments;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Documents CurrentDocuments
    {
      get
      {
        return this._currentDocuments;
      }
      set
      {
        this._currentDocuments = value;
        if (this.CurrentDocuments == null)
        {
          this.CurrentDocuments = new Documents();
          this.CurrentDocuments.Exists = false;
        }
        if (this.CurrentDocuments.Exists)
        {
          this.Populate(0);
        }
        else
        {
          this.lblAddedBy.Text = "Added By : NOT SAVED";
          this.lblLastUpdated.Text = "Last Updated By : NOT SAVED";
          this.btnBrowse.Enabled = true;
          this.btnOpen.Enabled = false;
        }
        this.lblTableEnumID.Text = "This document is linked to record ID '" + Conversions.ToString(this.IDToLinkTo) + "' for the entity of '" + this.EntityToLinkTo.ToString().Replace("TBL", "") + "'";
      }
    }

    public Enums.TableNames EntityToLinkTo
    {
      get
      {
        return this._EntityToLinkTo;
      }
      set
      {
        this._EntityToLinkTo = value;
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
      }
    }

    private void UCDocuments_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      int num = (int) openFileDialog.ShowDialog();
      if (openFileDialog.FileName.Trim().Length <= 0)
        return;
      this.txtLocation.Text = openFileDialog.FileName.Trim();
      this.txtDocumentName.Text = new FileInfo(openFileDialog.FileName.Trim()).Name;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      Helper.StartProcess(this.txtLocation.Text.Trim());
      App.DB.Documents.Opened(this.CurrentDocuments.DocumentID);
      this.CurrentDocuments = App.DB.Documents.Documents_Get(this.CurrentDocuments.DocumentID);
      this.Populate(0);
      // ISSUE: reference to a compiler-generated field
      IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
      if (stateChangedEvent == null)
        return;
      stateChangedEvent(this.CurrentDocuments.DocumentID);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentDocuments = App.DB.Documents.Documents_Get(ID);
      ComboBox cboDocumentTypeId = this.cboDocumentTypeID;
      Combo.SetSelectedComboItem_By_Value(ref cboDocumentTypeId, Conversions.ToString(this.CurrentDocuments.DocumentTypeID));
      this.cboDocumentTypeID = cboDocumentTypeId;
      this.txtName.Text = this.CurrentDocuments.Name;
      this.txtNotes.Text = this.CurrentDocuments.Notes;
      this.txtLocation.Text = this.CurrentDocuments.Location;
      this.txtDocumentName.Text = new FileInfo(this.CurrentDocuments.Location).Name;
      this.lblAddedBy.Text = "Added By : " + this.CurrentDocuments.AddedByUserName + " at " + Strings.Format((object) this.CurrentDocuments.AddedOn, "dddd dd MMMM yyyy HH:mm:ss") + ".";
      this.lblLastUpdated.Text = "Last Updated By : " + this.CurrentDocuments.LastUpdatedByUserName + " at " + Strings.Format((object) this.CurrentDocuments.LastUpdatedOn, "dddd dd MMMM yyyy HH:mm:ss") + ".";
      this.btnBrowse.Enabled = false;
      this.btnOpen.Enabled = true;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentDocuments.IgnoreExceptionsOnSetMethods = true;
        this.CurrentDocuments.SetTableEnumID = (object) (int) this.EntityToLinkTo;
        this.CurrentDocuments.SetRecordID = (object) this.IDToLinkTo;
        this.CurrentDocuments.SetDocumentTypeID = (object) Combo.get_GetSelectedItemValue(this.cboDocumentTypeID);
        this.CurrentDocuments.SetName = (object) this.txtName.Text.Trim();
        this.CurrentDocuments.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentDocuments.SetLocation = (object) this.txtLocation.Text.Trim();
        new DocumentsValidator().Validate(this.CurrentDocuments);
        if (this.CurrentDocuments.Exists)
          App.DB.Documents.Update(this.CurrentDocuments);
        else
          this.CurrentDocuments = App.DB.Documents.Insert(this.CurrentDocuments, true);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentDocuments.DocumentID);
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
