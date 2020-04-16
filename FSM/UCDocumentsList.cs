// Decompiled with JetBrains decompiler
// Type: FSM.UCDocumentsList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class UCDocumentsList : UCBase
  {
    private IContainer components;
    private Enums.TableNames _EntityToLinkTo;
    private int _IDToLinkTo;
    private DataView _dvDocuments;

    public UCDocumentsList(Enums.TableNames EntityToLinkToIn, int IDToLinkToIn)
    {
      this.Load += new EventHandler(this.UCDocumentsList_Load);
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.EntityToLinkTo = EntityToLinkToIn;
      this.IDToLinkTo = IDToLinkToIn;
      this.Dock = DockStyle.Fill;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgDocuments
    {
      get
      {
        return this._dgDocuments;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgDocuments_DoubleClick);
        DataGrid dgDocuments1 = this._dgDocuments;
        if (dgDocuments1 != null)
          dgDocuments1.DoubleClick -= eventHandler;
        this._dgDocuments = value;
        DataGrid dgDocuments2 = this._dgDocuments;
        if (dgDocuments2 == null)
          return;
        dgDocuments2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpDocuments = new GroupBox();
      this.dgDocuments = new DataGrid();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.grpDocuments.SuspendLayout();
      this.dgDocuments.BeginInit();
      this.SuspendLayout();
      this.grpDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDocuments.Controls.Add((Control) this.dgDocuments);
      this.grpDocuments.Location = new System.Drawing.Point(8, 8);
      this.grpDocuments.Name = "grpDocuments";
      this.grpDocuments.Size = new Size(488, 512);
      this.grpDocuments.TabIndex = 0;
      this.grpDocuments.TabStop = false;
      this.grpDocuments.Text = "Double Click To View / Edit";
      this.dgDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgDocuments.DataMember = "";
      this.dgDocuments.HeaderForeColor = SystemColors.ControlText;
      this.dgDocuments.Location = new System.Drawing.Point(8, 26);
      this.dgDocuments.Name = "dgDocuments";
      this.dgDocuments.Size = new Size(472, 478);
      this.dgDocuments.TabIndex = 1;
      this.btnDelete.AccessibleDescription = "";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(440, 528);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(56, 25);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete";
      this.btnAdd.AccessibleDescription = "";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(8, 528);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(56, 25);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.grpDocuments);
      this.Name = nameof (UCDocumentsList);
      this.Size = new Size(504, 560);
      this.grpDocuments.ResumeLayout(false);
      this.dgDocuments.EndInit();
      this.ResumeLayout(false);
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
        if (this.IDToLinkTo == 0)
        {
          this.btnAdd.Enabled = false;
          this.btnDelete.Enabled = false;
        }
        else
        {
          this.Documents = this.EntityToLinkTo != Enums.TableNames.tblCustomer ? (this.EntityToLinkTo != Enums.TableNames.tblSite ? App.DB.Documents.Documents_GetAll_For_Entity_ID(this.EntityToLinkTo, this.IDToLinkTo) : App.DB.Documents.Documents_GetAll_For_Site_ID(this.EntityToLinkTo, this.IDToLinkTo)) : App.DB.Documents.Documents_GetAll_For_Customer_ID(this.EntityToLinkTo, this.IDToLinkTo);
          this.btnAdd.Enabled = true;
          this.btnDelete.Enabled = true;
        }
      }
    }

    public DataView Documents
    {
      get
      {
        return this._dvDocuments;
      }
      set
      {
        this._dvDocuments = value;
        this._dvDocuments.Table.TableName = Enums.TableNames.tblDocuments.ToString();
        this._dvDocuments.AllowNew = false;
        this._dvDocuments.AllowEdit = false;
        this._dvDocuments.AllowDelete = false;
        this.dgDocuments.DataSource = (object) this.Documents;
      }
    }

    private DataRow SelectedDocumentDataRow
    {
      get
      {
        return this.dgDocuments.CurrentRowIndex != -1 ? this.Documents[this.dgDocuments.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDocumentsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgDocuments.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Reference";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dddd dd MMMM yyyy HH:mm:ss";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Last Updated";
      dataGridLabelColumn4.MappingName = "LastUpdatedOn";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 200;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Updated By";
      dataGridLabelColumn5.MappingName = "LastUpdatedByUserName";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 200;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblDocuments.ToString();
      this.dgDocuments.TableStyles.Add(tableStyle);
    }

    private void UCDocumentsList_Load(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupDocumentsDataGrid();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMDocuments), true, new object[4]
      {
        (object) this.EntityToLinkTo,
        (object) Helper.MakeIntegerValid((object) this.IDToLinkTo),
        (object) 0,
        (object) this
      }, false);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedDocumentDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a document to delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.Documents.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDocumentDataRow["DocumentID"])));
        this.IDToLinkTo = this.IDToLinkTo;
      }
    }

    private void dgDocuments_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedDocumentDataRow == null)
        return;
      App.ShowForm(typeof (FRMDocuments), true, new object[4]
      {
        (object) (Enums.TableNames) Conversions.ToInteger(this.SelectedDocumentDataRow["TableEnumID"]),
        (object) Helper.MakeIntegerValid((object) this.IDToLinkTo),
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDocumentDataRow["DocumentID"])),
        (object) this
      }, false);
    }

    public void Populate()
    {
      if (this.EntityToLinkTo == Enums.TableNames.tblCustomer)
        this.Documents = App.DB.Documents.Documents_GetAll_For_Customer_ID(this.EntityToLinkTo, this.IDToLinkTo);
      else if (this.EntityToLinkTo == Enums.TableNames.tblSite)
        this.Documents = App.DB.Documents.Documents_GetAll_For_Site_ID(this.EntityToLinkTo, this.IDToLinkTo);
      else
        this.Documents = App.DB.Documents.Documents_GetAll_For_Entity_ID(this.EntityToLinkTo, this.IDToLinkTo);
    }
  }
}
