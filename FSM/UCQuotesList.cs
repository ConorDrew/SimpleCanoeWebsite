// Decompiled with JetBrains decompiler
// Type: FSM.UCQuotesList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class UCQuotesList : UCBase
  {
    private IContainer components;
    private Enums.TableNames _EntityToLinkTo;
    private int _CustomerID;
    private int _SiteID;
    private DataView _dvQuotes;
    private int _SelectedSiteID;

    public UCQuotesList(Enums.TableNames EntityToLinkToIn, int CustomerIDIn, int SiteIDIn)
    {
      this.Load += new EventHandler(this.UCQuotesList_Load);
      this._CustomerID = 0;
      this._SiteID = 0;
      this._SelectedSiteID = 0;
      this.InitializeComponent();
      this.EntityToLinkTo = EntityToLinkToIn;
      this.CustomerID = CustomerIDIn;
      this.SiteID = SiteIDIn;
      if (this.CustomerID == 0)
      {
        this.btnAdd.Enabled = false;
        this.btnDelete.Enabled = false;
      }
      else
      {
        this.Populate();
        this.btnAdd.Enabled = true;
        this.btnDelete.Enabled = true;
      }
      this.Dock = DockStyle.Fill;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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

    internal virtual GroupBox grpQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgQuotes
    {
      get
      {
        return this._dgQuotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgQuotes_DoubleClick);
        DataGrid dgQuotes1 = this._dgQuotes;
        if (dgQuotes1 != null)
          dgQuotes1.DoubleClick -= eventHandler;
        this._dgQuotes = value;
        DataGrid dgQuotes2 = this._dgQuotes;
        if (dgQuotes2 == null)
          return;
        dgQuotes2.DoubleClick += eventHandler;
      }
    }

    internal virtual ContextMenu ctxtMnuQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuJobQuote
    {
      get
      {
        return this._mnuJobQuote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuJobQuote_Click);
        MenuItem mnuJobQuote1 = this._mnuJobQuote;
        if (mnuJobQuote1 != null)
          mnuJobQuote1.Click -= eventHandler;
        this._mnuJobQuote = value;
        MenuItem mnuJobQuote2 = this._mnuJobQuote;
        if (mnuJobQuote2 == null)
          return;
        mnuJobQuote2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpQuotes = new GroupBox();
      this.dgQuotes = new DataGrid();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.ctxtMnuQuotes = new ContextMenu();
      this.mnuJobQuote = new MenuItem();
      this.grpQuotes.SuspendLayout();
      this.dgQuotes.BeginInit();
      this.SuspendLayout();
      this.grpQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpQuotes.Controls.Add((Control) this.dgQuotes);
      this.grpQuotes.Location = new System.Drawing.Point(8, 8);
      this.grpQuotes.Name = "grpQuotes";
      this.grpQuotes.Size = new Size(488, 512);
      this.grpQuotes.TabIndex = 0;
      this.grpQuotes.TabStop = false;
      this.grpQuotes.Text = "Double Click To View / Edit";
      this.dgQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgQuotes.DataMember = "";
      this.dgQuotes.HeaderForeColor = SystemColors.ControlText;
      this.dgQuotes.Location = new System.Drawing.Point(8, 27);
      this.dgQuotes.Name = "dgQuotes";
      this.dgQuotes.Size = new Size(472, 477);
      this.dgQuotes.TabIndex = 1;
      this.btnDelete.AccessibleDescription = "Delete Contract";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(440, 528);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(56, 25);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete";
      this.btnAdd.AccessibleDescription = "Add New Contract";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new System.Drawing.Point(8, 528);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(56, 25);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.ctxtMnuQuotes.MenuItems.AddRange(new MenuItem[1]
      {
        this.mnuJobQuote
      });
      this.mnuJobQuote.Index = 0;
      this.mnuJobQuote.Text = "Job Quote";
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.grpQuotes);
      this.Name = nameof (UCQuotesList);
      this.Size = new Size(504, 560);
      this.grpQuotes.ResumeLayout(false);
      this.dgQuotes.EndInit();
      this.ResumeLayout(false);
    }

    public event UCQuotesList.RefreshContractsEventHandler RefreshContracts;

    public event UCQuotesList.RefreshJobsEventHandler RefreshJobs;

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

    public int CustomerID
    {
      get
      {
        return this._CustomerID;
      }
      set
      {
        this._CustomerID = value;
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

    public DataView Quotes
    {
      get
      {
        return this._dvQuotes;
      }
      set
      {
        this._dvQuotes = value;
        this._dvQuotes.Table.TableName = Enums.TableNames.tblQuotes.ToString();
        this._dvQuotes.AllowNew = false;
        this._dvQuotes.AllowEdit = false;
        this._dvQuotes.AllowDelete = false;
        this.dgQuotes.DataSource = (object) this.Quotes;
      }
    }

    private DataRow SelectedQuoteDataRow
    {
      get
      {
        return this.dgQuotes.CurrentRowIndex != -1 ? this.Quotes[this.dgQuotes.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public int SelectedSiteID
    {
      get
      {
        return this._SelectedSiteID;
      }
      set
      {
        this._SelectedSiteID = value;
      }
    }

    private void SetupContractsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgQuotes.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Quote Type";
      dataGridLabelColumn1.MappingName = "QuoteType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Reference";
      dataGridLabelColumn2.MappingName = "Reference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Quote Date";
      dataGridLabelColumn3.MappingName = "QuoteDate";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 85;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Status";
      dataGridLabelColumn5.MappingName = "Status";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblQuotes.ToString();
      this.dgQuotes.TableStyles.Add(tableStyle);
    }

    private void UCQuotesList_Load(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupContractsDataGrid();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      this.ctxtMnuQuotes.Show((Control) this.btnAdd, new System.Drawing.Point(0, -30));
    }

    private void mnuJobQuote_Click(object sender, EventArgs e)
    {
      if ((uint) this.SiteID > 0U)
      {
        App.ShowForm(typeof (FRMQuoteJob), true, new object[2]
        {
          (object) 0,
          (object) this.SiteID
        }, false);
      }
      else
      {
        App.ShowForm(typeof (FRMQuoteJobSelectASite), true, new object[2]
        {
          (object) this.CustomerID,
          (object) this
        }, false);
        if ((uint) this.SelectedSiteID > 0U)
          App.ShowForm(typeof (FRMQuoteJob), true, new object[2]
          {
            (object) 0,
            (object) this.SelectedSiteID
          }, false);
      }
      this.Populate();
    }

    private void dgQuotes_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedQuoteDataRow == null)
        return;
      object Left1 = this.SelectedQuoteDataRow["QuoteType"];
      Enums.QuoteType quoteType = Enums.QuoteType.Contract_Opt_3;
      string str1 = quoteType.ToString();
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left1, (object) str1, false))
      {
        App.ShowForm(typeof (FRMQuoteContractOption3), true, new object[2]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])),
          (object) Helper.MakeIntegerValid((object) this.CustomerID)
        }, false);
      }
      else
      {
        object Left2 = this.SelectedQuoteDataRow["QuoteType"];
        quoteType = Enums.QuoteType.Job;
        string str2 = quoteType.ToString();
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, (object) str2, false))
          App.ShowForm(typeof (FRMQuoteJob), true, new object[2]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])),
            this.SelectedQuoteDataRow["IDToLinkTo"]
          }, false);
      }
      this.Populate();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedQuoteDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select quote to delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete this quote?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        object Left1 = this.SelectedQuoteDataRow["QuoteType"];
        Enums.QuoteType quoteType = Enums.QuoteType.Contract_Opt_1;
        string str1 = quoteType.ToString();
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left1, (object) str1, false))
        {
          DataView dataView = new DataView();
          DataView allQuoteContractId = App.DB.QuoteContractOriginalSite.GetAll_QuoteContractID(Conversions.ToInteger(this.SelectedQuoteDataRow["QuoteID"]), this.CustomerID);
          IEnumerator enumerator;
          try
          {
            enumerator = allQuoteContractId.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              App.DB.QuoteContractOriginalSite.Delete(Conversions.ToInteger(current["QuoteContractSiteID"]));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.DB.QuoteContractOriginal.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])));
        }
        else
        {
          object Left2 = this.SelectedQuoteDataRow["QuoteType"];
          quoteType = Enums.QuoteType.Contract_Opt_2;
          string str2 = quoteType.ToString();
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, (object) str2, false))
          {
            DataView dataView = new DataView();
            DataView allQuoteContractId = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(Conversions.ToInteger(this.SelectedQuoteDataRow["QuoteID"]), this.CustomerID);
            IEnumerator enumerator;
            try
            {
              enumerator = allQuoteContractId.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                App.DB.QuoteContractAlternativeSite.Delete(Conversions.ToInteger(current["QuoteContractSiteID"]));
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            App.DB.QuoteContractAlternative.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])));
          }
          else
          {
            object Left3 = this.SelectedQuoteDataRow["QuoteType"];
            quoteType = Enums.QuoteType.Job;
            string str3 = quoteType.ToString();
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left3, (object) str3, false))
            {
              App.DB.QuoteJob.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])));
            }
            else
            {
              object Left4 = this.SelectedQuoteDataRow["QuoteType"];
              quoteType = Enums.QuoteType.Contract_Opt_3;
              string str4 = quoteType.ToString();
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left4, (object) str4, false))
              {
                DataView dataView = new DataView();
                DataView forQuoteContract = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(Conversions.ToInteger(this.SelectedQuoteDataRow["QuoteID"]), this.CustomerID);
                IEnumerator enumerator;
                try
                {
                  enumerator = forQuoteContract.Table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    App.DB.QuoteContractOption3Site.Delete(Conversions.ToInteger(current["QuoteContractSiteID"]));
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
                App.DB.QuoteContractOption3.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedQuoteDataRow["QuoteID"])));
              }
            }
          }
        }
        this.Populate();
      }
    }

    private void Populate()
    {
      this.Quotes = this.EntityToLinkTo != Enums.TableNames.tblCustomer ? (this.EntityToLinkTo != Enums.TableNames.tblSite ? App.DB.Quotes.QuotesGet_All() : App.DB.Quotes.QuotesGet_All_For_SiteID(this.SiteID)) : App.DB.Quotes.QuotesGet_All_For_CustomerID(this.CustomerID);
      // ISSUE: reference to a compiler-generated field
      UCQuotesList.RefreshContractsEventHandler refreshContractsEvent = this.RefreshContractsEvent;
      if (refreshContractsEvent != null)
        refreshContractsEvent();
      // ISSUE: reference to a compiler-generated field
      UCQuotesList.RefreshJobsEventHandler refreshJobsEvent = this.RefreshJobsEvent;
      if (refreshJobsEvent == null)
        return;
      refreshJobsEvent();
    }

    public delegate void RefreshContractsEventHandler();

    public delegate void RefreshJobsEventHandler();
  }
}
