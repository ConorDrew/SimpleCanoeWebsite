// Decompiled with JetBrains decompiler
// Type: FSM.FSMDataSet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FSM
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("FSMDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class FSMDataSet : DataSet
  {
    private FSMDataSet.Customer_Get_ForSiteIDDataTable tableCustomer_Get_ForSiteID;
    private FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable tableEngineerVisitAssetWorkSheet_GetForVisit;
    private FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable tableEngineerVisitDefects_GetForEngineerVisit;
    private FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID;
    private FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable tableEngineerVisitTimeSheet_Get_For_EngineerVisitID;
    private FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID;
    private FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable tableInvoiceAddress_Get_EngineerVisitID;
    private FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable tableJob_Get_For_An_EngineerVisit_ID;
    private FSMDataSet.JobItems_Get_For_JobDataTable tableJobItems_Get_For_Job;
    private FSMDataSet.Site_Get_ForEngineerVisitIDDataTable tableSite_Get_ForEngineerVisitID;
    private SchemaSerializationMode _schemaSerializationMode;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public FSMDataSet()
    {
      this._schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected FSMDataSet(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      this._schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = Conversions.ToString(info.GetValue("XmlSchema", typeof (string)));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (Customer_Get_ForSiteID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.Customer_Get_ForSiteIDDataTable(dataSet.Tables[nameof (Customer_Get_ForSiteID)]));
          if (dataSet.Tables[nameof (EngineerVisitAssetWorkSheet_GetForVisit)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable(dataSet.Tables[nameof (EngineerVisitAssetWorkSheet_GetForVisit)]));
          if (dataSet.Tables[nameof (EngineerVisitDefects_GetForEngineerVisit)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable(dataSet.Tables[nameof (EngineerVisitDefects_GetForEngineerVisit)]));
          if (dataSet.Tables[nameof (EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable(dataSet.Tables[nameof (EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID)]));
          if (dataSet.Tables[nameof (EngineerVisitTimeSheet_Get_For_EngineerVisitID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable(dataSet.Tables[nameof (EngineerVisitTimeSheet_Get_For_EngineerVisitID)]));
          if (dataSet.Tables[nameof (EngineerVisitUnitsUsed_Get_For_EngineerVisitID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable(dataSet.Tables[nameof (EngineerVisitUnitsUsed_Get_For_EngineerVisitID)]));
          if (dataSet.Tables[nameof (InvoiceAddress_Get_EngineerVisitID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable(dataSet.Tables[nameof (InvoiceAddress_Get_EngineerVisitID)]));
          if (dataSet.Tables[nameof (Job_Get_For_An_EngineerVisit_ID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable(dataSet.Tables[nameof (Job_Get_For_An_EngineerVisit_ID)]));
          if (dataSet.Tables[nameof (JobItems_Get_For_Job)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.JobItems_Get_For_JobDataTable(dataSet.Tables[nameof (JobItems_Get_For_Job)]));
          if (dataSet.Tables[nameof (Site_Get_ForEngineerVisitID)] != null)
            base.Tables.Add((DataTable) new FSMDataSet.Site_Get_ForEngineerVisitIDDataTable(dataSet.Tables[nameof (Site_Get_ForEngineerVisitID)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.Customer_Get_ForSiteIDDataTable Customer_Get_ForSiteID
    {
      get
      {
        return this.tableCustomer_Get_ForSiteID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable EngineerVisitAssetWorkSheet_GetForVisit
    {
      get
      {
        return this.tableEngineerVisitAssetWorkSheet_GetForVisit;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable EngineerVisitDefects_GetForEngineerVisit
    {
      get
      {
        return this.tableEngineerVisitDefects_GetForEngineerVisit;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID
    {
      get
      {
        return this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable EngineerVisitTimeSheet_Get_For_EngineerVisitID
    {
      get
      {
        return this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable EngineerVisitUnitsUsed_Get_For_EngineerVisitID
    {
      get
      {
        return this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable InvoiceAddress_Get_EngineerVisitID
    {
      get
      {
        return this.tableInvoiceAddress_Get_EngineerVisitID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable Job_Get_For_An_EngineerVisit_ID
    {
      get
      {
        return this.tableJob_Get_For_An_EngineerVisit_ID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.JobItems_Get_For_JobDataTable JobItems_Get_For_Job
    {
      get
      {
        return this.tableJobItems_Get_For_Job;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FSMDataSet.Site_Get_ForEngineerVisitIDDataTable Site_Get_ForEngineerVisitID
    {
      get
      {
        return this.tableSite_Get_ForEngineerVisitID;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get
      {
        return this._schemaSerializationMode;
      }
      set
      {
        this._schemaSerializationMode = value;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables
    {
      get
      {
        return base.Tables;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
      get
      {
        return base.Relations;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public override DataSet Clone()
    {
      FSMDataSet fsmDataSet = (FSMDataSet) base.Clone();
      fsmDataSet.InitVars();
      fsmDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) fsmDataSet;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected override bool ShouldSerializeTables()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected override bool ShouldSerializeRelations()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["Customer_Get_ForSiteID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.Customer_Get_ForSiteIDDataTable(dataSet.Tables["Customer_Get_ForSiteID"]));
        if (dataSet.Tables["EngineerVisitAssetWorkSheet_GetForVisit"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable(dataSet.Tables["EngineerVisitAssetWorkSheet_GetForVisit"]));
        if (dataSet.Tables["EngineerVisitDefects_GetForEngineerVisit"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable(dataSet.Tables["EngineerVisitDefects_GetForEngineerVisit"]));
        if (dataSet.Tables["EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable(dataSet.Tables["EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID"]));
        if (dataSet.Tables["EngineerVisitTimeSheet_Get_For_EngineerVisitID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable(dataSet.Tables["EngineerVisitTimeSheet_Get_For_EngineerVisitID"]));
        if (dataSet.Tables["EngineerVisitUnitsUsed_Get_For_EngineerVisitID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable(dataSet.Tables["EngineerVisitUnitsUsed_Get_For_EngineerVisitID"]));
        if (dataSet.Tables["InvoiceAddress_Get_EngineerVisitID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable(dataSet.Tables["InvoiceAddress_Get_EngineerVisitID"]));
        if (dataSet.Tables["Job_Get_For_An_EngineerVisit_ID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable(dataSet.Tables["Job_Get_For_An_EngineerVisit_ID"]));
        if (dataSet.Tables["JobItems_Get_For_Job"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.JobItems_Get_For_JobDataTable(dataSet.Tables["JobItems_Get_For_Job"]));
        if (dataSet.Tables["Site_Get_ForEngineerVisitID"] != null)
          base.Tables.Add((DataTable) new FSMDataSet.Site_Get_ForEngineerVisitIDDataTable(dataSet.Tables["Site_Get_ForEngineerVisitID"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    internal void InitVars()
    {
      this.InitVars(true);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    internal void InitVars(bool initTable)
    {
      this.tableCustomer_Get_ForSiteID = (FSMDataSet.Customer_Get_ForSiteIDDataTable) base.Tables["Customer_Get_ForSiteID"];
      if (initTable && this.tableCustomer_Get_ForSiteID != null)
        this.tableCustomer_Get_ForSiteID.InitVars();
      this.tableEngineerVisitAssetWorkSheet_GetForVisit = (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable) base.Tables["EngineerVisitAssetWorkSheet_GetForVisit"];
      if (initTable && this.tableEngineerVisitAssetWorkSheet_GetForVisit != null)
        this.tableEngineerVisitAssetWorkSheet_GetForVisit.InitVars();
      this.tableEngineerVisitDefects_GetForEngineerVisit = (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable) base.Tables["EngineerVisitDefects_GetForEngineerVisit"];
      if (initTable && this.tableEngineerVisitDefects_GetForEngineerVisit != null)
        this.tableEngineerVisitDefects_GetForEngineerVisit.InitVars();
      this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable) base.Tables["EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID"];
      if (initTable && this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID != null)
        this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.InitVars();
      this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable) base.Tables["EngineerVisitTimeSheet_Get_For_EngineerVisitID"];
      if (initTable && this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID != null)
        this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.InitVars();
      this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable) base.Tables["EngineerVisitUnitsUsed_Get_For_EngineerVisitID"];
      if (initTable && this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID != null)
        this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.InitVars();
      this.tableInvoiceAddress_Get_EngineerVisitID = (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable) base.Tables["InvoiceAddress_Get_EngineerVisitID"];
      if (initTable && this.tableInvoiceAddress_Get_EngineerVisitID != null)
        this.tableInvoiceAddress_Get_EngineerVisitID.InitVars();
      this.tableJob_Get_For_An_EngineerVisit_ID = (FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable) base.Tables["Job_Get_For_An_EngineerVisit_ID"];
      if (initTable && this.tableJob_Get_For_An_EngineerVisit_ID != null)
        this.tableJob_Get_For_An_EngineerVisit_ID.InitVars();
      this.tableJobItems_Get_For_Job = (FSMDataSet.JobItems_Get_For_JobDataTable) base.Tables["JobItems_Get_For_Job"];
      if (initTable && this.tableJobItems_Get_For_Job != null)
        this.tableJobItems_Get_For_Job.InitVars();
      this.tableSite_Get_ForEngineerVisitID = (FSMDataSet.Site_Get_ForEngineerVisitIDDataTable) base.Tables["Site_Get_ForEngineerVisitID"];
      if (!initTable || this.tableSite_Get_ForEngineerVisitID == null)
        return;
      this.tableSite_Get_ForEngineerVisitID.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (FSMDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/FSMDataSet1.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableCustomer_Get_ForSiteID = new FSMDataSet.Customer_Get_ForSiteIDDataTable();
      base.Tables.Add((DataTable) this.tableCustomer_Get_ForSiteID);
      this.tableEngineerVisitAssetWorkSheet_GetForVisit = new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable();
      base.Tables.Add((DataTable) this.tableEngineerVisitAssetWorkSheet_GetForVisit);
      this.tableEngineerVisitDefects_GetForEngineerVisit = new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable();
      base.Tables.Add((DataTable) this.tableEngineerVisitDefects_GetForEngineerVisit);
      this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID = new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable();
      base.Tables.Add((DataTable) this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID);
      this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID = new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable();
      base.Tables.Add((DataTable) this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID);
      this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID = new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable();
      base.Tables.Add((DataTable) this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID);
      this.tableInvoiceAddress_Get_EngineerVisitID = new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable();
      base.Tables.Add((DataTable) this.tableInvoiceAddress_Get_EngineerVisitID);
      this.tableJob_Get_For_An_EngineerVisit_ID = new FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable();
      base.Tables.Add((DataTable) this.tableJob_Get_For_An_EngineerVisit_ID);
      this.tableJobItems_Get_For_Job = new FSMDataSet.JobItems_Get_For_JobDataTable();
      base.Tables.Add((DataTable) this.tableJobItems_Get_For_Job);
      this.tableSite_Get_ForEngineerVisitID = new FSMDataSet.Site_Get_ForEngineerVisitIDDataTable();
      base.Tables.Add((DataTable) this.tableSite_Get_ForEngineerVisitID);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeCustomer_Get_ForSiteID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeEngineerVisitAssetWorkSheet_GetForVisit()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeEngineerVisitDefects_GetForEngineerVisit()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeEngineerVisitTimeSheet_Get_For_EngineerVisitID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeEngineerVisitUnitsUsed_Get_For_EngineerVisitID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeInvoiceAddress_Get_EngineerVisitID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeJob_Get_For_An_EngineerVisit_ID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeJobItems_Get_For_Job()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private bool ShouldSerializeSite_Get_ForEngineerVisitID()
    {
      return false;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      FSMDataSet fsmDataSet = new FSMDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      schemaComplexType.Particle = (XmlSchemaParticle) new XmlSchemaSequence()
      {
        Items = {
          (XmlSchemaObject) new XmlSchemaAny()
          {
            Namespace = fsmDataSet.Namespace
          }
        }
      };
      XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return schemaComplexType;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return schemaComplexType;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void Customer_Get_ForSiteIDRowChangeEventHandler(
      object sender,
      FSMDataSet.Customer_Get_ForSiteIDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler(
      object sender,
      FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler(
      object sender,
      FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler(
      object sender,
      FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler(
      object sender,
      FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler(
      object sender,
      FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler(
      object sender,
      FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler(
      object sender,
      FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void JobItems_Get_For_JobRowChangeEventHandler(
      object sender,
      FSMDataSet.JobItems_Get_For_JobRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public delegate void Site_Get_ForEngineerVisitIDRowChangeEventHandler(
      object sender,
      FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class Customer_Get_ForSiteIDDataTable : TypedTableBase<FSMDataSet.Customer_Get_ForSiteIDRow>
    {
      private DataColumn columnCustomerID;
      private DataColumn columnName;
      private DataColumn columnCustomerTypeID;
      private DataColumn columnRegionID;
      private DataColumn columnNotes;
      private DataColumn columnAccountNumber;
      private DataColumn columnStatus;
      private DataColumn columnAcceptChargesChanges;
      private DataColumn columnDeleted;
      private DataColumn columnMainContractorDiscount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Customer_Get_ForSiteIDDataTable()
      {
        this.TableName = "Customer_Get_ForSiteID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Customer_Get_ForSiteIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected Customer_Get_ForSiteIDDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CustomerIDColumn
      {
        get
        {
          return this.columnCustomerID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NameColumn
      {
        get
        {
          return this.columnName;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CustomerTypeIDColumn
      {
        get
        {
          return this.columnCustomerTypeID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn RegionIDColumn
      {
        get
        {
          return this.columnRegionID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NotesColumn
      {
        get
        {
          return this.columnNotes;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AccountNumberColumn
      {
        get
        {
          return this.columnAccountNumber;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn StatusColumn
      {
        get
        {
          return this.columnStatus;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AcceptChargesChangesColumn
      {
        get
        {
          return this.columnAcceptChargesChanges;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DeletedColumn
      {
        get
        {
          return this.columnDeleted;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn MainContractorDiscountColumn
      {
        get
        {
          return this.columnMainContractorDiscount;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Customer_Get_ForSiteIDRow this[int index]
      {
        get
        {
          return (FSMDataSet.Customer_Get_ForSiteIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler Customer_Get_ForSiteIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler Customer_Get_ForSiteIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler Customer_Get_ForSiteIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler Customer_Get_ForSiteIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddCustomer_Get_ForSiteIDRow(FSMDataSet.Customer_Get_ForSiteIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Customer_Get_ForSiteIDRow AddCustomer_Get_ForSiteIDRow(
        string Name,
        int CustomerTypeID,
        int RegionID,
        string Notes,
        string AccountNumber,
        int Status,
        bool AcceptChargesChanges,
        bool Deleted,
        Decimal MainContractorDiscount)
      {
        FSMDataSet.Customer_Get_ForSiteIDRow customerGetForSiteIdRow = (FSMDataSet.Customer_Get_ForSiteIDRow) this.NewRow();
        object[] objArray = new object[10]
        {
          null,
          (object) Name,
          (object) CustomerTypeID,
          (object) RegionID,
          (object) Notes,
          (object) AccountNumber,
          (object) Status,
          (object) AcceptChargesChanges,
          (object) Deleted,
          (object) MainContractorDiscount
        };
        customerGetForSiteIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) customerGetForSiteIdRow);
        return customerGetForSiteIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Customer_Get_ForSiteIDRow FindByCustomerID(int CustomerID)
      {
        return (FSMDataSet.Customer_Get_ForSiteIDRow) this.Rows.Find(new object[1]
        {
          (object) CustomerID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.Customer_Get_ForSiteIDDataTable forSiteIdDataTable = (FSMDataSet.Customer_Get_ForSiteIDDataTable) base.Clone();
        forSiteIdDataTable.InitVars();
        return (DataTable) forSiteIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.Customer_Get_ForSiteIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnCustomerID = this.Columns["CustomerID"];
        this.columnName = this.Columns["Name"];
        this.columnCustomerTypeID = this.Columns["CustomerTypeID"];
        this.columnRegionID = this.Columns["RegionID"];
        this.columnNotes = this.Columns["Notes"];
        this.columnAccountNumber = this.Columns["AccountNumber"];
        this.columnStatus = this.Columns["Status"];
        this.columnAcceptChargesChanges = this.Columns["AcceptChargesChanges"];
        this.columnDeleted = this.Columns["Deleted"];
        this.columnMainContractorDiscount = this.Columns["MainContractorDiscount"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnCustomerID = new DataColumn("CustomerID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCustomerID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnCustomerTypeID = new DataColumn("CustomerTypeID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCustomerTypeID);
        this.columnRegionID = new DataColumn("RegionID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRegionID);
        this.columnNotes = new DataColumn("Notes", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNotes);
        this.columnAccountNumber = new DataColumn("AccountNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAccountNumber);
        this.columnStatus = new DataColumn("Status", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnStatus);
        this.columnAcceptChargesChanges = new DataColumn("AcceptChargesChanges", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAcceptChargesChanges);
        this.columnDeleted = new DataColumn("Deleted", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDeleted);
        this.columnMainContractorDiscount = new DataColumn("MainContractorDiscount", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMainContractorDiscount);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnCustomerID
        }, true));
        this.columnCustomerID.AutoIncrement = true;
        this.columnCustomerID.AllowDBNull = false;
        this.columnCustomerID.ReadOnly = true;
        this.columnCustomerID.Unique = true;
        this.columnName.AllowDBNull = false;
        this.columnName.MaxLength = (int) byte.MaxValue;
        this.columnCustomerTypeID.AllowDBNull = false;
        this.columnRegionID.AllowDBNull = false;
        this.columnNotes.AllowDBNull = false;
        this.columnNotes.MaxLength = 4000;
        this.columnAccountNumber.AllowDBNull = false;
        this.columnAccountNumber.MaxLength = 50;
        this.columnStatus.AllowDBNull = false;
        this.columnAcceptChargesChanges.AllowDBNull = false;
        this.columnDeleted.AllowDBNull = false;
        this.columnMainContractorDiscount.AllowDBNull = false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Customer_Get_ForSiteIDRow NewCustomer_Get_ForSiteIDRow()
      {
        return (FSMDataSet.Customer_Get_ForSiteIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.Customer_Get_ForSiteIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.Customer_Get_ForSiteIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Customer_Get_ForSiteIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler idRowChangedEvent = this.Customer_Get_ForSiteIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.Customer_Get_ForSiteIDRowChangeEvent((FSMDataSet.Customer_Get_ForSiteIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Customer_Get_ForSiteIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler rowChangingEvent = this.Customer_Get_ForSiteIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.Customer_Get_ForSiteIDRowChangeEvent((FSMDataSet.Customer_Get_ForSiteIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Customer_Get_ForSiteIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler idRowDeletedEvent = this.Customer_Get_ForSiteIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.Customer_Get_ForSiteIDRowChangeEvent((FSMDataSet.Customer_Get_ForSiteIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Customer_Get_ForSiteIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Customer_Get_ForSiteIDRowChangeEventHandler rowDeletingEvent = this.Customer_Get_ForSiteIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.Customer_Get_ForSiteIDRowChangeEvent((FSMDataSet.Customer_Get_ForSiteIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveCustomer_Get_ForSiteIDRow(FSMDataSet.Customer_Get_ForSiteIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Customer_Get_ForSiteIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class EngineerVisitAssetWorkSheet_GetForVisitDataTable : TypedTableBase<FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow>
    {
      private DataColumn columnEngineerVisitAssetWorkSheetID;
      private DataColumn columnEngineerVisitID;
      private DataColumn columnAssetID;
      private DataColumn columnFlueTerminationSatisfactoryID;
      private DataColumn columnFlueFlowTestID;
      private DataColumn columnSpillageTestID;
      private DataColumn columnVentilationProvisionSatisfactoryID;
      private DataColumn columnSafetyDeviceOperationID;
      private DataColumn columnDHWFlowRate;
      private DataColumn columnColdWaterTemp;
      private DataColumn columnDHWTemp;
      private DataColumn columnInletStaticPressure;
      private DataColumn columnInletWorkingPressure;
      private DataColumn columnMinBurnerPressure;
      private DataColumn columnMaxBurnerPressure;
      private DataColumn columnCO2;
      private DataColumn columnCO2CORatio;
      private DataColumn columnLandlordsApplianceID;
      private DataColumn columnApplianceServiceOrInspectedID;
      private DataColumn columnApplianceSafeID;
      private DataColumn columnVisualConditionOfFlueSatisfactoryID;
      private DataColumn columnDeleted;
      private DataColumn columnLocation;
      private DataColumn columnSerialNum;
      private DataColumn columntypemakemodel;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitAssetWorkSheet_GetForVisitDataTable()
      {
        this.TableName = "EngineerVisitAssetWorkSheet_GetForVisit";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitAssetWorkSheet_GetForVisitDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected EngineerVisitAssetWorkSheet_GetForVisitDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitAssetWorkSheetIDColumn
      {
        get
        {
          return this.columnEngineerVisitAssetWorkSheetID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitIDColumn
      {
        get
        {
          return this.columnEngineerVisitID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AssetIDColumn
      {
        get
        {
          return this.columnAssetID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn FlueTerminationSatisfactoryIDColumn
      {
        get
        {
          return this.columnFlueTerminationSatisfactoryID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn FlueFlowTestIDColumn
      {
        get
        {
          return this.columnFlueFlowTestID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SpillageTestIDColumn
      {
        get
        {
          return this.columnSpillageTestID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn VentilationProvisionSatisfactoryIDColumn
      {
        get
        {
          return this.columnVentilationProvisionSatisfactoryID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SafetyDeviceOperationIDColumn
      {
        get
        {
          return this.columnSafetyDeviceOperationID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DHWFlowRateColumn
      {
        get
        {
          return this.columnDHWFlowRate;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ColdWaterTempColumn
      {
        get
        {
          return this.columnColdWaterTemp;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DHWTempColumn
      {
        get
        {
          return this.columnDHWTemp;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn InletStaticPressureColumn
      {
        get
        {
          return this.columnInletStaticPressure;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn InletWorkingPressureColumn
      {
        get
        {
          return this.columnInletWorkingPressure;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn MinBurnerPressureColumn
      {
        get
        {
          return this.columnMinBurnerPressure;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn MaxBurnerPressureColumn
      {
        get
        {
          return this.columnMaxBurnerPressure;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CO2Column
      {
        get
        {
          return this.columnCO2;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CO2CORatioColumn
      {
        get
        {
          return this.columnCO2CORatio;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn LandlordsApplianceIDColumn
      {
        get
        {
          return this.columnLandlordsApplianceID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ApplianceServiceOrInspectedIDColumn
      {
        get
        {
          return this.columnApplianceServiceOrInspectedID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ApplianceSafeIDColumn
      {
        get
        {
          return this.columnApplianceSafeID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn VisualConditionOfFlueSatisfactoryIDColumn
      {
        get
        {
          return this.columnVisualConditionOfFlueSatisfactoryID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DeletedColumn
      {
        get
        {
          return this.columnDeleted;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn LocationColumn
      {
        get
        {
          return this.columnLocation;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SerialNumColumn
      {
        get
        {
          return this.columnSerialNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn typemakemodelColumn
      {
        get
        {
          return this.columntypemakemodel;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow this[int index]
      {
        get
        {
          return (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler EngineerVisitAssetWorkSheet_GetForVisitRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler EngineerVisitAssetWorkSheet_GetForVisitRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler EngineerVisitAssetWorkSheet_GetForVisitRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler EngineerVisitAssetWorkSheet_GetForVisitRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddEngineerVisitAssetWorkSheet_GetForVisitRow(
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow AddEngineerVisitAssetWorkSheet_GetForVisitRow(
        int EngineerVisitID,
        int AssetID,
        int FlueTerminationSatisfactoryID,
        int FlueFlowTestID,
        int SpillageTestID,
        int VentilationProvisionSatisfactoryID,
        int SafetyDeviceOperationID,
        Decimal DHWFlowRate,
        Decimal ColdWaterTemp,
        Decimal DHWTemp,
        Decimal InletStaticPressure,
        Decimal InletWorkingPressure,
        Decimal MinBurnerPressure,
        Decimal MaxBurnerPressure,
        Decimal CO2,
        Decimal CO2CORatio,
        int LandlordsApplianceID,
        int ApplianceServiceOrInspectedID,
        int ApplianceSafeID,
        int VisualConditionOfFlueSatisfactoryID,
        bool Deleted,
        string Location,
        string SerialNum,
        string typemakemodel)
      {
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow sheetGetForVisitRow = (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) this.NewRow();
        object[] objArray = new object[25]
        {
          null,
          (object) EngineerVisitID,
          (object) AssetID,
          (object) FlueTerminationSatisfactoryID,
          (object) FlueFlowTestID,
          (object) SpillageTestID,
          (object) VentilationProvisionSatisfactoryID,
          (object) SafetyDeviceOperationID,
          (object) DHWFlowRate,
          (object) ColdWaterTemp,
          (object) DHWTemp,
          (object) InletStaticPressure,
          (object) InletWorkingPressure,
          (object) MinBurnerPressure,
          (object) MaxBurnerPressure,
          (object) CO2,
          (object) CO2CORatio,
          (object) LandlordsApplianceID,
          (object) ApplianceServiceOrInspectedID,
          (object) ApplianceSafeID,
          (object) VisualConditionOfFlueSatisfactoryID,
          (object) Deleted,
          (object) Location,
          (object) SerialNum,
          (object) typemakemodel
        };
        sheetGetForVisitRow.ItemArray = objArray;
        this.Rows.Add((DataRow) sheetGetForVisitRow);
        return sheetGetForVisitRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow FindByEngineerVisitAssetWorkSheetID(
        int EngineerVisitAssetWorkSheetID)
      {
        return (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) this.Rows.Find(new object[1]
        {
          (object) EngineerVisitAssetWorkSheetID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable forVisitDataTable = (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable) base.Clone();
        forVisitDataTable.InitVars();
        return (DataTable) forVisitDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnEngineerVisitAssetWorkSheetID = this.Columns["EngineerVisitAssetWorkSheetID"];
        this.columnEngineerVisitID = this.Columns["EngineerVisitID"];
        this.columnAssetID = this.Columns["AssetID"];
        this.columnFlueTerminationSatisfactoryID = this.Columns["FlueTerminationSatisfactoryID"];
        this.columnFlueFlowTestID = this.Columns["FlueFlowTestID"];
        this.columnSpillageTestID = this.Columns["SpillageTestID"];
        this.columnVentilationProvisionSatisfactoryID = this.Columns["VentilationProvisionSatisfactoryID"];
        this.columnSafetyDeviceOperationID = this.Columns["SafetyDeviceOperationID"];
        this.columnDHWFlowRate = this.Columns["DHWFlowRate"];
        this.columnColdWaterTemp = this.Columns["ColdWaterTemp"];
        this.columnDHWTemp = this.Columns["DHWTemp"];
        this.columnInletStaticPressure = this.Columns["InletStaticPressure"];
        this.columnInletWorkingPressure = this.Columns["InletWorkingPressure"];
        this.columnMinBurnerPressure = this.Columns["MinBurnerPressure"];
        this.columnMaxBurnerPressure = this.Columns["MaxBurnerPressure"];
        this.columnCO2 = this.Columns["CO2"];
        this.columnCO2CORatio = this.Columns["CO2CORatio"];
        this.columnLandlordsApplianceID = this.Columns["LandlordsApplianceID"];
        this.columnApplianceServiceOrInspectedID = this.Columns["ApplianceServiceOrInspectedID"];
        this.columnApplianceSafeID = this.Columns["ApplianceSafeID"];
        this.columnVisualConditionOfFlueSatisfactoryID = this.Columns["VisualConditionOfFlueSatisfactoryID"];
        this.columnDeleted = this.Columns["Deleted"];
        this.columnLocation = this.Columns["Location"];
        this.columnSerialNum = this.Columns["SerialNum"];
        this.columntypemakemodel = this.Columns["typemakemodel"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnEngineerVisitAssetWorkSheetID = new DataColumn("EngineerVisitAssetWorkSheetID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitAssetWorkSheetID);
        this.columnEngineerVisitID = new DataColumn("EngineerVisitID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitID);
        this.columnAssetID = new DataColumn("AssetID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAssetID);
        this.columnFlueTerminationSatisfactoryID = new DataColumn("FlueTerminationSatisfactoryID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlueTerminationSatisfactoryID);
        this.columnFlueFlowTestID = new DataColumn("FlueFlowTestID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlueFlowTestID);
        this.columnSpillageTestID = new DataColumn("SpillageTestID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSpillageTestID);
        this.columnVentilationProvisionSatisfactoryID = new DataColumn("VentilationProvisionSatisfactoryID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVentilationProvisionSatisfactoryID);
        this.columnSafetyDeviceOperationID = new DataColumn("SafetyDeviceOperationID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSafetyDeviceOperationID);
        this.columnDHWFlowRate = new DataColumn("DHWFlowRate", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDHWFlowRate);
        this.columnColdWaterTemp = new DataColumn("ColdWaterTemp", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnColdWaterTemp);
        this.columnDHWTemp = new DataColumn("DHWTemp", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDHWTemp);
        this.columnInletStaticPressure = new DataColumn("InletStaticPressure", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnInletStaticPressure);
        this.columnInletWorkingPressure = new DataColumn("InletWorkingPressure", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnInletWorkingPressure);
        this.columnMinBurnerPressure = new DataColumn("MinBurnerPressure", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMinBurnerPressure);
        this.columnMaxBurnerPressure = new DataColumn("MaxBurnerPressure", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxBurnerPressure);
        this.columnCO2 = new DataColumn("CO2", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCO2);
        this.columnCO2CORatio = new DataColumn("CO2CORatio", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCO2CORatio);
        this.columnLandlordsApplianceID = new DataColumn("LandlordsApplianceID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLandlordsApplianceID);
        this.columnApplianceServiceOrInspectedID = new DataColumn("ApplianceServiceOrInspectedID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnApplianceServiceOrInspectedID);
        this.columnApplianceSafeID = new DataColumn("ApplianceSafeID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnApplianceSafeID);
        this.columnVisualConditionOfFlueSatisfactoryID = new DataColumn("VisualConditionOfFlueSatisfactoryID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVisualConditionOfFlueSatisfactoryID);
        this.columnDeleted = new DataColumn("Deleted", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDeleted);
        this.columnLocation = new DataColumn("Location", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLocation);
        this.columnSerialNum = new DataColumn("SerialNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerialNum);
        this.columntypemakemodel = new DataColumn("typemakemodel", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columntypemakemodel);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnEngineerVisitAssetWorkSheetID
        }, true));
        this.columnEngineerVisitAssetWorkSheetID.AutoIncrement = true;
        this.columnEngineerVisitAssetWorkSheetID.AllowDBNull = false;
        this.columnEngineerVisitAssetWorkSheetID.ReadOnly = true;
        this.columnEngineerVisitAssetWorkSheetID.Unique = true;
        this.columnEngineerVisitID.AllowDBNull = false;
        this.columnAssetID.AllowDBNull = false;
        this.columnFlueTerminationSatisfactoryID.AllowDBNull = false;
        this.columnFlueFlowTestID.AllowDBNull = false;
        this.columnSpillageTestID.AllowDBNull = false;
        this.columnVentilationProvisionSatisfactoryID.AllowDBNull = false;
        this.columnSafetyDeviceOperationID.AllowDBNull = false;
        this.columnDHWFlowRate.AllowDBNull = false;
        this.columnColdWaterTemp.AllowDBNull = false;
        this.columnDHWTemp.AllowDBNull = false;
        this.columnInletStaticPressure.AllowDBNull = false;
        this.columnInletWorkingPressure.AllowDBNull = false;
        this.columnMinBurnerPressure.AllowDBNull = false;
        this.columnMaxBurnerPressure.AllowDBNull = false;
        this.columnCO2.AllowDBNull = false;
        this.columnCO2CORatio.AllowDBNull = false;
        this.columnLandlordsApplianceID.AllowDBNull = false;
        this.columnApplianceServiceOrInspectedID.AllowDBNull = false;
        this.columnApplianceSafeID.AllowDBNull = false;
        this.columnVisualConditionOfFlueSatisfactoryID.AllowDBNull = false;
        this.columnDeleted.AllowDBNull = false;
        this.columnLocation.ReadOnly = true;
        this.columnLocation.MaxLength = (int) byte.MaxValue;
        this.columnSerialNum.ReadOnly = true;
        this.columnSerialNum.MaxLength = 50;
        this.columntypemakemodel.ReadOnly = true;
        this.columntypemakemodel.MaxLength = 771;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow NewEngineerVisitAssetWorkSheet_GetForVisitRow()
      {
        return (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitAssetWorkSheet_GetForVisitRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler visitRowChangedEvent = this.EngineerVisitAssetWorkSheet_GetForVisitRowChangedEvent;
        if (visitRowChangedEvent != null)
          visitRowChangedEvent((object) this, new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent((FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitAssetWorkSheet_GetForVisitRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler rowChangingEvent = this.EngineerVisitAssetWorkSheet_GetForVisitRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent((FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitAssetWorkSheet_GetForVisitRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler visitRowDeletedEvent = this.EngineerVisitAssetWorkSheet_GetForVisitRowDeletedEvent;
        if (visitRowDeletedEvent != null)
          visitRowDeletedEvent((object) this, new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent((FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitAssetWorkSheet_GetForVisitRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEventHandler rowDeletingEvent = this.EngineerVisitAssetWorkSheet_GetForVisitRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent((FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveEngineerVisitAssetWorkSheet_GetForVisitRow(
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (EngineerVisitAssetWorkSheet_GetForVisitDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class EngineerVisitDefects_GetForEngineerVisitDataTable : TypedTableBase<FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow>
    {
      private DataColumn columnEngineerVisitDefectID;
      private DataColumn columnCategoryID;
      private DataColumn columnReason;
      private DataColumn columnActionTaken;
      private DataColumn columnWarningNoticeIssued;
      private DataColumn columnDisconnected;
      private DataColumn columnDisconnected1;
      private DataColumn columnComments;
      private DataColumn columnAssetID;
      private DataColumn columnCategory;
      private DataColumn columnLocation;
      private DataColumn columnSerialNum;
      private DataColumn columntypemakemodel;
      private DataColumn columnEngineerVisitID;
      private DataColumn columnDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitDefects_GetForEngineerVisitDataTable()
      {
        this.TableName = "EngineerVisitDefects_GetForEngineerVisit";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitDefects_GetForEngineerVisitDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected EngineerVisitDefects_GetForEngineerVisitDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitDefectIDColumn
      {
        get
        {
          return this.columnEngineerVisitDefectID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CategoryIDColumn
      {
        get
        {
          return this.columnCategoryID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ReasonColumn
      {
        get
        {
          return this.columnReason;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ActionTakenColumn
      {
        get
        {
          return this.columnActionTaken;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn WarningNoticeIssuedColumn
      {
        get
        {
          return this.columnWarningNoticeIssued;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DisconnectedColumn
      {
        get
        {
          return this.columnDisconnected;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Disconnected1Column
      {
        get
        {
          return this.columnDisconnected1;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CommentsColumn
      {
        get
        {
          return this.columnComments;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AssetIDColumn
      {
        get
        {
          return this.columnAssetID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CategoryColumn
      {
        get
        {
          return this.columnCategory;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn LocationColumn
      {
        get
        {
          return this.columnLocation;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SerialNumColumn
      {
        get
        {
          return this.columnSerialNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn typemakemodelColumn
      {
        get
        {
          return this.columntypemakemodel;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitIDColumn
      {
        get
        {
          return this.columnEngineerVisitID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DeletedColumn
      {
        get
        {
          return this.columnDeleted;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow this[int index]
      {
        get
        {
          return (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler EngineerVisitDefects_GetForEngineerVisitRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler EngineerVisitDefects_GetForEngineerVisitRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler EngineerVisitDefects_GetForEngineerVisitRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler EngineerVisitDefects_GetForEngineerVisitRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddEngineerVisitDefects_GetForEngineerVisitRow(
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow AddEngineerVisitDefects_GetForEngineerVisitRow(
        int CategoryID,
        string Reason,
        string ActionTaken,
        string WarningNoticeIssued,
        string Disconnected,
        bool Disconnected1,
        string Comments,
        int AssetID,
        string Category,
        string Location,
        string SerialNum,
        string typemakemodel,
        int EngineerVisitID,
        bool Deleted)
      {
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow engineerVisitRow = (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) this.NewRow();
        object[] objArray = new object[15]
        {
          null,
          (object) CategoryID,
          (object) Reason,
          (object) ActionTaken,
          (object) WarningNoticeIssued,
          (object) Disconnected,
          (object) Disconnected1,
          (object) Comments,
          (object) AssetID,
          (object) Category,
          (object) Location,
          (object) SerialNum,
          (object) typemakemodel,
          (object) EngineerVisitID,
          (object) Deleted
        };
        engineerVisitRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitRow);
        return engineerVisitRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow FindByEngineerVisitDefectID(
        int EngineerVisitDefectID)
      {
        return (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) this.Rows.Find(new object[1]
        {
          (object) EngineerVisitDefectID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable engineerVisitDataTable = (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable) base.Clone();
        engineerVisitDataTable.InitVars();
        return (DataTable) engineerVisitDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnEngineerVisitDefectID = this.Columns["EngineerVisitDefectID"];
        this.columnCategoryID = this.Columns["CategoryID"];
        this.columnReason = this.Columns["Reason"];
        this.columnActionTaken = this.Columns["ActionTaken"];
        this.columnWarningNoticeIssued = this.Columns["WarningNoticeIssued"];
        this.columnDisconnected = this.Columns["Disconnected"];
        this.columnDisconnected1 = this.Columns["Disconnected1"];
        this.columnComments = this.Columns["Comments"];
        this.columnAssetID = this.Columns["AssetID"];
        this.columnCategory = this.Columns["Category"];
        this.columnLocation = this.Columns["Location"];
        this.columnSerialNum = this.Columns["SerialNum"];
        this.columntypemakemodel = this.Columns["typemakemodel"];
        this.columnEngineerVisitID = this.Columns["EngineerVisitID"];
        this.columnDeleted = this.Columns["Deleted"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnEngineerVisitDefectID = new DataColumn("EngineerVisitDefectID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitDefectID);
        this.columnCategoryID = new DataColumn("CategoryID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCategoryID);
        this.columnReason = new DataColumn("Reason", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReason);
        this.columnActionTaken = new DataColumn("ActionTaken", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnActionTaken);
        this.columnWarningNoticeIssued = new DataColumn("WarningNoticeIssued", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWarningNoticeIssued);
        this.columnDisconnected = new DataColumn("Disconnected", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDisconnected);
        this.columnDisconnected1 = new DataColumn("Disconnected1", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDisconnected1);
        this.columnComments = new DataColumn("Comments", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnComments);
        this.columnAssetID = new DataColumn("AssetID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAssetID);
        this.columnCategory = new DataColumn("Category", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCategory);
        this.columnLocation = new DataColumn("Location", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLocation);
        this.columnSerialNum = new DataColumn("SerialNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerialNum);
        this.columntypemakemodel = new DataColumn("typemakemodel", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columntypemakemodel);
        this.columnEngineerVisitID = new DataColumn("EngineerVisitID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitID);
        this.columnDeleted = new DataColumn("Deleted", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDeleted);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnEngineerVisitDefectID
        }, true));
        this.columnEngineerVisitDefectID.AutoIncrement = true;
        this.columnEngineerVisitDefectID.AllowDBNull = false;
        this.columnEngineerVisitDefectID.ReadOnly = true;
        this.columnEngineerVisitDefectID.Unique = true;
        this.columnCategoryID.AllowDBNull = false;
        this.columnReason.MaxLength = 4000;
        this.columnActionTaken.MaxLength = 4000;
        this.columnWarningNoticeIssued.ReadOnly = true;
        this.columnWarningNoticeIssued.MaxLength = 3;
        this.columnDisconnected.ReadOnly = true;
        this.columnDisconnected.MaxLength = 3;
        this.columnDisconnected1.AllowDBNull = false;
        this.columnComments.MaxLength = 4000;
        this.columnAssetID.ReadOnly = true;
        this.columnCategory.AllowDBNull = false;
        this.columnCategory.MaxLength = (int) byte.MaxValue;
        this.columnLocation.ReadOnly = true;
        this.columnLocation.MaxLength = (int) byte.MaxValue;
        this.columnSerialNum.ReadOnly = true;
        this.columnSerialNum.MaxLength = 50;
        this.columntypemakemodel.ReadOnly = true;
        this.columntypemakemodel.MaxLength = 771;
        this.columnEngineerVisitID.AllowDBNull = false;
        this.columnDeleted.AllowDBNull = false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow NewEngineerVisitDefects_GetForEngineerVisitRow()
      {
        return (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitDefects_GetForEngineerVisitRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler visitRowChangedEvent = this.EngineerVisitDefects_GetForEngineerVisitRowChangedEvent;
        if (visitRowChangedEvent != null)
          visitRowChangedEvent((object) this, new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEvent((FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitDefects_GetForEngineerVisitRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler rowChangingEvent = this.EngineerVisitDefects_GetForEngineerVisitRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEvent((FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitDefects_GetForEngineerVisitRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler visitRowDeletedEvent = this.EngineerVisitDefects_GetForEngineerVisitRowDeletedEvent;
        if (visitRowDeletedEvent != null)
          visitRowDeletedEvent((object) this, new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEvent((FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitDefects_GetForEngineerVisitRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEventHandler rowDeletingEvent = this.EngineerVisitDefects_GetForEngineerVisitRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRowChangeEvent((FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveEngineerVisitDefects_GetForEngineerVisitRow(
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (EngineerVisitDefects_GetForEngineerVisitDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable : TypedTableBase<FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow>
    {
      private DataColumn columntick;
      private DataColumn columnEngineerVisitScheduleOfRateChargesID;
      private DataColumn columnJobItemID;
      private DataColumn columnCode;
      private DataColumn columncategory;
      private DataColumn columnSummary;
      private DataColumn columnNumUnitsUsed;
      private DataColumn columnPrice;
      private DataColumn columnTotal;
      private DataColumn columntick1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable()
      {
        this.TableName = "EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn tickColumn
      {
        get
        {
          return this.columntick;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitScheduleOfRateChargesIDColumn
      {
        get
        {
          return this.columnEngineerVisitScheduleOfRateChargesID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobItemIDColumn
      {
        get
        {
          return this.columnJobItemID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CodeColumn
      {
        get
        {
          return this.columnCode;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn categoryColumn
      {
        get
        {
          return this.columncategory;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SummaryColumn
      {
        get
        {
          return this.columnSummary;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NumUnitsUsedColumn
      {
        get
        {
          return this.columnNumUnitsUsed;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PriceColumn
      {
        get
        {
          return this.columnPrice;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn TotalColumn
      {
        get
        {
          return this.columnTotal;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn tick1Column
      {
        get
        {
          return this.columntick1;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow this[
        int index]
      {
        get
        {
          return (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow AddEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow(
        bool tick,
        string Code,
        string category,
        string Summary,
        Decimal NumUnitsUsed,
        Decimal Price,
        Decimal Total,
        bool tick1)
      {
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow engineerVisitIdRow = (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) this.NewRow();
        object[] objArray = new object[10]
        {
          (object) tick,
          null,
          null,
          (object) Code,
          (object) category,
          (object) Summary,
          (object) NumUnitsUsed,
          (object) Price,
          (object) Total,
          (object) tick1
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable visitIdDataTable = (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columntick = this.Columns["tick"];
        this.columnEngineerVisitScheduleOfRateChargesID = this.Columns["EngineerVisitScheduleOfRateChargesID"];
        this.columnJobItemID = this.Columns["JobItemID"];
        this.columnCode = this.Columns["Code"];
        this.columncategory = this.Columns["category"];
        this.columnSummary = this.Columns["Summary"];
        this.columnNumUnitsUsed = this.Columns["NumUnitsUsed"];
        this.columnPrice = this.Columns["Price"];
        this.columnTotal = this.Columns["Total"];
        this.columntick1 = this.Columns["tick1"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columntick = new DataColumn("tick", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columntick);
        this.columnEngineerVisitScheduleOfRateChargesID = new DataColumn("EngineerVisitScheduleOfRateChargesID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitScheduleOfRateChargesID);
        this.columnJobItemID = new DataColumn("JobItemID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobItemID);
        this.columnCode = new DataColumn("Code", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCode);
        this.columncategory = new DataColumn("category", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columncategory);
        this.columnSummary = new DataColumn("Summary", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSummary);
        this.columnNumUnitsUsed = new DataColumn("NumUnitsUsed", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumUnitsUsed);
        this.columnPrice = new DataColumn("Price", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrice);
        this.columnTotal = new DataColumn("Total", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotal);
        this.columntick1 = new DataColumn("tick1", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columntick1);
        this.columntick.ReadOnly = true;
        this.columnEngineerVisitScheduleOfRateChargesID.AutoIncrement = true;
        this.columnEngineerVisitScheduleOfRateChargesID.ReadOnly = true;
        this.columnJobItemID.AutoIncrement = true;
        this.columnJobItemID.AllowDBNull = false;
        this.columnJobItemID.ReadOnly = true;
        this.columnCode.MaxLength = 50;
        this.columncategory.MaxLength = (int) byte.MaxValue;
        this.columnSummary.AllowDBNull = false;
        this.columnSummary.MaxLength = 4000;
        this.columnPrice.ReadOnly = true;
        this.columnTotal.ReadOnly = true;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow NewEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow()
      {
        return (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler idRowChangedEvent = this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler rowChangingEvent = this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler idRowDeletedEvent = this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEventHandler rowDeletingEvent = this.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable : TypedTableBase<FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow>
    {
      private DataColumn columnEngineerVisitTimeSheetID;
      private DataColumn columnEngineerVisitID;
      private DataColumn columnStartDateTime;
      private DataColumn columnEndDateTime;
      private DataColumn columnComments;
      private DataColumn columnTimeSheetType;
      private DataColumn columnTimesheetTypeID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable()
      {
        this.TableName = "EngineerVisitTimeSheet_Get_For_EngineerVisitID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitTimeSheetIDColumn
      {
        get
        {
          return this.columnEngineerVisitTimeSheetID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerVisitIDColumn
      {
        get
        {
          return this.columnEngineerVisitID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn StartDateTimeColumn
      {
        get
        {
          return this.columnStartDateTime;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EndDateTimeColumn
      {
        get
        {
          return this.columnEndDateTime;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CommentsColumn
      {
        get
        {
          return this.columnComments;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn TimeSheetTypeColumn
      {
        get
        {
          return this.columnTimeSheetType;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn TimesheetTypeIDColumn
      {
        get
        {
          return this.columnTimesheetTypeID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow this[int index]
      {
        get
        {
          return (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddEngineerVisitTimeSheet_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow AddEngineerVisitTimeSheet_Get_For_EngineerVisitIDRow(
        int EngineerVisitID,
        DateTime StartDateTime,
        DateTime EndDateTime,
        string Comments,
        string TimeSheetType,
        int TimesheetTypeID)
      {
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow engineerVisitIdRow = (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) this.NewRow();
        object[] objArray = new object[7]
        {
          null,
          (object) EngineerVisitID,
          (object) StartDateTime,
          (object) EndDateTime,
          (object) Comments,
          (object) TimeSheetType,
          (object) TimesheetTypeID
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow FindByEngineerVisitTimeSheetID(
        int EngineerVisitTimeSheetID)
      {
        return (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) this.Rows.Find(new object[1]
        {
          (object) EngineerVisitTimeSheetID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable visitIdDataTable = (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnEngineerVisitTimeSheetID = this.Columns["EngineerVisitTimeSheetID"];
        this.columnEngineerVisitID = this.Columns["EngineerVisitID"];
        this.columnStartDateTime = this.Columns["StartDateTime"];
        this.columnEndDateTime = this.Columns["EndDateTime"];
        this.columnComments = this.Columns["Comments"];
        this.columnTimeSheetType = this.Columns["TimeSheetType"];
        this.columnTimesheetTypeID = this.Columns["TimesheetTypeID"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnEngineerVisitTimeSheetID = new DataColumn("EngineerVisitTimeSheetID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitTimeSheetID);
        this.columnEngineerVisitID = new DataColumn("EngineerVisitID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerVisitID);
        this.columnStartDateTime = new DataColumn("StartDateTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnStartDateTime);
        this.columnEndDateTime = new DataColumn("EndDateTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEndDateTime);
        this.columnComments = new DataColumn("Comments", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnComments);
        this.columnTimeSheetType = new DataColumn("TimeSheetType", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeSheetType);
        this.columnTimesheetTypeID = new DataColumn("TimesheetTypeID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimesheetTypeID);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnEngineerVisitTimeSheetID
        }, true));
        this.columnEngineerVisitTimeSheetID.AutoIncrement = true;
        this.columnEngineerVisitTimeSheetID.AllowDBNull = false;
        this.columnEngineerVisitTimeSheetID.ReadOnly = true;
        this.columnEngineerVisitTimeSheetID.Unique = true;
        this.columnEngineerVisitID.AllowDBNull = false;
        this.columnStartDateTime.AllowDBNull = false;
        this.columnEndDateTime.AllowDBNull = false;
        this.columnComments.AllowDBNull = false;
        this.columnComments.MaxLength = 4000;
        this.columnTimeSheetType.AllowDBNull = false;
        this.columnTimeSheetType.MaxLength = (int) byte.MaxValue;
        this.columnTimesheetTypeID.AllowDBNull = false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow NewEngineerVisitTimeSheet_Get_For_EngineerVisitIDRow()
      {
        return (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler idRowChangedEvent = this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler rowChangingEvent = this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler idRowDeletedEvent = this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEventHandler rowDeletingEvent = this.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveEngineerVisitTimeSheet_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable : TypedTableBase<FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow>
    {
      private DataColumn columnJobItemID;
      private DataColumn columnSummary;
      private DataColumn columnNumAllocated;
      private DataColumn columnNumUnitsUsed;
      private DataColumn columnPrice;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable()
      {
        this.TableName = "EngineerVisitUnitsUsed_Get_For_EngineerVisitID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobItemIDColumn
      {
        get
        {
          return this.columnJobItemID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SummaryColumn
      {
        get
        {
          return this.columnSummary;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NumAllocatedColumn
      {
        get
        {
          return this.columnNumAllocated;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NumUnitsUsedColumn
      {
        get
        {
          return this.columnNumUnitsUsed;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PriceColumn
      {
        get
        {
          return this.columnPrice;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow this[int index]
      {
        get
        {
          return (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddEngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow AddEngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow(
        string Summary,
        Decimal NumAllocated,
        Decimal NumUnitsUsed,
        Decimal Price)
      {
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow engineerVisitIdRow = (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Summary,
          (object) NumAllocated,
          (object) NumUnitsUsed,
          (object) Price
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow FindByJobItemID(
        int JobItemID)
      {
        return (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) this.Rows.Find(new object[1]
        {
          (object) JobItemID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable visitIdDataTable = (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnJobItemID = this.Columns["JobItemID"];
        this.columnSummary = this.Columns["Summary"];
        this.columnNumAllocated = this.Columns["NumAllocated"];
        this.columnNumUnitsUsed = this.Columns["NumUnitsUsed"];
        this.columnPrice = this.Columns["Price"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnJobItemID = new DataColumn("JobItemID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobItemID);
        this.columnSummary = new DataColumn("Summary", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSummary);
        this.columnNumAllocated = new DataColumn("NumAllocated", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumAllocated);
        this.columnNumUnitsUsed = new DataColumn("NumUnitsUsed", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumUnitsUsed);
        this.columnPrice = new DataColumn("Price", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrice);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnJobItemID
        }, true));
        this.columnJobItemID.AutoIncrement = true;
        this.columnJobItemID.AllowDBNull = false;
        this.columnJobItemID.ReadOnly = true;
        this.columnJobItemID.Unique = true;
        this.columnSummary.AllowDBNull = false;
        this.columnSummary.MaxLength = 4000;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow NewEngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow()
      {
        return (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler idRowChangedEvent = this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler rowChangingEvent = this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler idRowDeletedEvent = this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEventHandler rowDeletingEvent = this.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent((FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveEngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow(
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class InvoiceAddress_Get_EngineerVisitIDDataTable : TypedTableBase<FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow>
    {
      private DataColumn columnAddressTypeID;
      private DataColumn columnAddressType;
      private DataColumn columnAddressID;
      private DataColumn columnAddress1;
      private DataColumn columnAddress2;
      private DataColumn columnAddress3;
      private DataColumn columnAddress4;
      private DataColumn columnAddress5;
      private DataColumn columnPostcode;
      private DataColumn columnTelephoneNum;
      private DataColumn columnFaxNum;
      private DataColumn columnEmailAddress;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public InvoiceAddress_Get_EngineerVisitIDDataTable()
      {
        this.TableName = "InvoiceAddress_Get_EngineerVisitID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal InvoiceAddress_Get_EngineerVisitIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected InvoiceAddress_Get_EngineerVisitIDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AddressTypeIDColumn
      {
        get
        {
          return this.columnAddressTypeID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AddressTypeColumn
      {
        get
        {
          return this.columnAddressType;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AddressIDColumn
      {
        get
        {
          return this.columnAddressID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address1Column
      {
        get
        {
          return this.columnAddress1;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address2Column
      {
        get
        {
          return this.columnAddress2;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address3Column
      {
        get
        {
          return this.columnAddress3;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address4Column
      {
        get
        {
          return this.columnAddress4;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address5Column
      {
        get
        {
          return this.columnAddress5;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PostcodeColumn
      {
        get
        {
          return this.columnPostcode;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn TelephoneNumColumn
      {
        get
        {
          return this.columnTelephoneNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn FaxNumColumn
      {
        get
        {
          return this.columnFaxNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EmailAddressColumn
      {
        get
        {
          return this.columnEmailAddress;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow this[int index]
      {
        get
        {
          return (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler InvoiceAddress_Get_EngineerVisitIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler InvoiceAddress_Get_EngineerVisitIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler InvoiceAddress_Get_EngineerVisitIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler InvoiceAddress_Get_EngineerVisitIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddInvoiceAddress_Get_EngineerVisitIDRow(
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow AddInvoiceAddress_Get_EngineerVisitIDRow(
        int AddressTypeID,
        string AddressType,
        string Address1,
        string Address2,
        string Address3,
        string Address4,
        string Address5,
        string Postcode,
        string TelephoneNum,
        string FaxNum,
        string EmailAddress)
      {
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow engineerVisitIdRow = (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) this.NewRow();
        object[] objArray = new object[12]
        {
          (object) AddressTypeID,
          (object) AddressType,
          null,
          (object) Address1,
          (object) Address2,
          (object) Address3,
          (object) Address4,
          (object) Address5,
          (object) Postcode,
          (object) TelephoneNum,
          (object) FaxNum,
          (object) EmailAddress
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable visitIdDataTable = (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnAddressTypeID = this.Columns["AddressTypeID"];
        this.columnAddressType = this.Columns["AddressType"];
        this.columnAddressID = this.Columns["AddressID"];
        this.columnAddress1 = this.Columns["Address1"];
        this.columnAddress2 = this.Columns["Address2"];
        this.columnAddress3 = this.Columns["Address3"];
        this.columnAddress4 = this.Columns["Address4"];
        this.columnAddress5 = this.Columns["Address5"];
        this.columnPostcode = this.Columns["Postcode"];
        this.columnTelephoneNum = this.Columns["TelephoneNum"];
        this.columnFaxNum = this.Columns["FaxNum"];
        this.columnEmailAddress = this.Columns["EmailAddress"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnAddressTypeID = new DataColumn("AddressTypeID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddressTypeID);
        this.columnAddressType = new DataColumn("AddressType", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddressType);
        this.columnAddressID = new DataColumn("AddressID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddressID);
        this.columnAddress1 = new DataColumn("Address1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress1);
        this.columnAddress2 = new DataColumn("Address2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress2);
        this.columnAddress3 = new DataColumn("Address3", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress3);
        this.columnAddress4 = new DataColumn("Address4", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress4);
        this.columnAddress5 = new DataColumn("Address5", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress5);
        this.columnPostcode = new DataColumn("Postcode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPostcode);
        this.columnTelephoneNum = new DataColumn("TelephoneNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelephoneNum);
        this.columnFaxNum = new DataColumn("FaxNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFaxNum);
        this.columnEmailAddress = new DataColumn("EmailAddress", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmailAddress);
        this.columnAddressTypeID.ReadOnly = true;
        this.columnAddressType.ReadOnly = true;
        this.columnAddressType.MaxLength = 11;
        this.columnAddressID.AutoIncrement = true;
        this.columnAddressID.AllowDBNull = false;
        this.columnAddressID.ReadOnly = true;
        this.columnAddress1.MaxLength = (int) byte.MaxValue;
        this.columnAddress2.MaxLength = (int) byte.MaxValue;
        this.columnAddress3.MaxLength = (int) byte.MaxValue;
        this.columnAddress4.MaxLength = (int) byte.MaxValue;
        this.columnAddress5.MaxLength = (int) byte.MaxValue;
        this.columnPostcode.ReadOnly = true;
        this.columnPostcode.MaxLength = (int) byte.MaxValue;
        this.columnTelephoneNum.ReadOnly = true;
        this.columnTelephoneNum.MaxLength = (int) byte.MaxValue;
        this.columnFaxNum.ReadOnly = true;
        this.columnFaxNum.MaxLength = (int) byte.MaxValue;
        this.columnEmailAddress.ReadOnly = true;
        this.columnEmailAddress.MaxLength = (int) byte.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow NewInvoiceAddress_Get_EngineerVisitIDRow()
      {
        return (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.InvoiceAddress_Get_EngineerVisitIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler idRowChangedEvent = this.InvoiceAddress_Get_EngineerVisitIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEvent((FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.InvoiceAddress_Get_EngineerVisitIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler rowChangingEvent = this.InvoiceAddress_Get_EngineerVisitIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEvent((FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.InvoiceAddress_Get_EngineerVisitIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler idRowDeletedEvent = this.InvoiceAddress_Get_EngineerVisitIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEvent((FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.InvoiceAddress_Get_EngineerVisitIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEventHandler rowDeletingEvent = this.InvoiceAddress_Get_EngineerVisitIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRowChangeEvent((FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveInvoiceAddress_Get_EngineerVisitIDRow(
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (InvoiceAddress_Get_EngineerVisitIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class Job_Get_For_An_EngineerVisit_IDDataTable : TypedTableBase<FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow>
    {
      private DataColumn columnJobID;
      private DataColumn columnSiteID;
      private DataColumn columnJobDefinitionEnumID;
      private DataColumn columnJobTypeID;
      private DataColumn columnStatusEnumID;
      private DataColumn columnDateCreated;
      private DataColumn columnCreatedByUserID;
      private DataColumn columnJobNumber;
      private DataColumn columnPONumber;
      private DataColumn columnQuoteID;
      private DataColumn columnContractID;
      private DataColumn columnToBePartPaid;
      private DataColumn columnRetention;
      private DataColumn columnDeleted;
      private DataColumn columnCollectPayment;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Job_Get_For_An_EngineerVisit_IDDataTable()
      {
        this.TableName = "Job_Get_For_An_EngineerVisit_ID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Job_Get_For_An_EngineerVisit_IDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected Job_Get_For_An_EngineerVisit_IDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobIDColumn
      {
        get
        {
          return this.columnJobID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SiteIDColumn
      {
        get
        {
          return this.columnSiteID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobDefinitionEnumIDColumn
      {
        get
        {
          return this.columnJobDefinitionEnumID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobTypeIDColumn
      {
        get
        {
          return this.columnJobTypeID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn StatusEnumIDColumn
      {
        get
        {
          return this.columnStatusEnumID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DateCreatedColumn
      {
        get
        {
          return this.columnDateCreated;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CreatedByUserIDColumn
      {
        get
        {
          return this.columnCreatedByUserID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn JobNumberColumn
      {
        get
        {
          return this.columnJobNumber;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PONumberColumn
      {
        get
        {
          return this.columnPONumber;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn QuoteIDColumn
      {
        get
        {
          return this.columnQuoteID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ContractIDColumn
      {
        get
        {
          return this.columnContractID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn ToBePartPaidColumn
      {
        get
        {
          return this.columnToBePartPaid;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn RetentionColumn
      {
        get
        {
          return this.columnRetention;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DeletedColumn
      {
        get
        {
          return this.columnDeleted;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CollectPaymentColumn
      {
        get
        {
          return this.columnCollectPayment;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow this[int index]
      {
        get
        {
          return (FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler Job_Get_For_An_EngineerVisit_IDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler Job_Get_For_An_EngineerVisit_IDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler Job_Get_For_An_EngineerVisit_IDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler Job_Get_For_An_EngineerVisit_IDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddJob_Get_For_An_EngineerVisit_IDRow(
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow AddJob_Get_For_An_EngineerVisit_IDRow(
        int SiteID,
        int JobDefinitionEnumID,
        int JobTypeID,
        int StatusEnumID,
        DateTime DateCreated,
        int CreatedByUserID,
        string JobNumber,
        string PONumber,
        int QuoteID,
        int ContractID,
        bool ToBePartPaid,
        Decimal Retention,
        bool Deleted,
        bool CollectPayment)
      {
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow engineerVisitIdRow = (FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) this.NewRow();
        object[] objArray = new object[15]
        {
          null,
          (object) SiteID,
          (object) JobDefinitionEnumID,
          (object) JobTypeID,
          (object) StatusEnumID,
          (object) DateCreated,
          (object) CreatedByUserID,
          (object) JobNumber,
          (object) PONumber,
          (object) QuoteID,
          (object) ContractID,
          (object) ToBePartPaid,
          (object) Retention,
          (object) Deleted,
          (object) CollectPayment
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow FindByJobID(int JobID)
      {
        return (FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) this.Rows.Find(new object[1]
        {
          (object) JobID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable visitIdDataTable = (FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnJobID = this.Columns["JobID"];
        this.columnSiteID = this.Columns["SiteID"];
        this.columnJobDefinitionEnumID = this.Columns["JobDefinitionEnumID"];
        this.columnJobTypeID = this.Columns["JobTypeID"];
        this.columnStatusEnumID = this.Columns["StatusEnumID"];
        this.columnDateCreated = this.Columns["DateCreated"];
        this.columnCreatedByUserID = this.Columns["CreatedByUserID"];
        this.columnJobNumber = this.Columns["JobNumber"];
        this.columnPONumber = this.Columns["PONumber"];
        this.columnQuoteID = this.Columns["QuoteID"];
        this.columnContractID = this.Columns["ContractID"];
        this.columnToBePartPaid = this.Columns["ToBePartPaid"];
        this.columnRetention = this.Columns["Retention"];
        this.columnDeleted = this.Columns["Deleted"];
        this.columnCollectPayment = this.Columns["CollectPayment"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnJobID = new DataColumn("JobID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobID);
        this.columnSiteID = new DataColumn("SiteID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSiteID);
        this.columnJobDefinitionEnumID = new DataColumn("JobDefinitionEnumID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobDefinitionEnumID);
        this.columnJobTypeID = new DataColumn("JobTypeID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobTypeID);
        this.columnStatusEnumID = new DataColumn("StatusEnumID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnStatusEnumID);
        this.columnDateCreated = new DataColumn("DateCreated", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDateCreated);
        this.columnCreatedByUserID = new DataColumn("CreatedByUserID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCreatedByUserID);
        this.columnJobNumber = new DataColumn("JobNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnJobNumber);
        this.columnPONumber = new DataColumn("PONumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPONumber);
        this.columnQuoteID = new DataColumn("QuoteID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnQuoteID);
        this.columnContractID = new DataColumn("ContractID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnContractID);
        this.columnToBePartPaid = new DataColumn("ToBePartPaid", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnToBePartPaid);
        this.columnRetention = new DataColumn("Retention", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRetention);
        this.columnDeleted = new DataColumn("Deleted", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDeleted);
        this.columnCollectPayment = new DataColumn("CollectPayment", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCollectPayment);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnJobID
        }, true));
        this.columnJobID.AutoIncrement = true;
        this.columnJobID.AllowDBNull = false;
        this.columnJobID.ReadOnly = true;
        this.columnJobID.Unique = true;
        this.columnSiteID.AllowDBNull = false;
        this.columnJobDefinitionEnumID.AllowDBNull = false;
        this.columnJobTypeID.AllowDBNull = false;
        this.columnStatusEnumID.AllowDBNull = false;
        this.columnDateCreated.AllowDBNull = false;
        this.columnCreatedByUserID.AllowDBNull = false;
        this.columnJobNumber.AllowDBNull = false;
        this.columnJobNumber.MaxLength = 20;
        this.columnPONumber.MaxLength = 20;
        this.columnQuoteID.AllowDBNull = false;
        this.columnContractID.AllowDBNull = false;
        this.columnToBePartPaid.AllowDBNull = false;
        this.columnRetention.AllowDBNull = false;
        this.columnDeleted.AllowDBNull = false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow NewJob_Get_For_An_EngineerVisit_IDRow()
      {
        return (FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Job_Get_For_An_EngineerVisit_IDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler idRowChangedEvent = this.Job_Get_For_An_EngineerVisit_IDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEvent((FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Job_Get_For_An_EngineerVisit_IDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler rowChangingEvent = this.Job_Get_For_An_EngineerVisit_IDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEvent((FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Job_Get_For_An_EngineerVisit_IDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler idRowDeletedEvent = this.Job_Get_For_An_EngineerVisit_IDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEvent((FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Job_Get_For_An_EngineerVisit_IDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEventHandler rowDeletingEvent = this.Job_Get_For_An_EngineerVisit_IDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.Job_Get_For_An_EngineerVisit_IDRowChangeEvent((FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveJob_Get_For_An_EngineerVisit_IDRow(
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Job_Get_For_An_EngineerVisit_IDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class JobItems_Get_For_JobDataTable : TypedTableBase<FSMDataSet.JobItems_Get_For_JobRow>
    {
      private DataColumn columnSummary;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public JobItems_Get_For_JobDataTable()
      {
        this.TableName = "JobItems_Get_For_Job";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal JobItems_Get_For_JobDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected JobItems_Get_For_JobDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SummaryColumn
      {
        get
        {
          return this.columnSummary;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.JobItems_Get_For_JobRow this[int index]
      {
        get
        {
          return (FSMDataSet.JobItems_Get_For_JobRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler JobItems_Get_For_JobRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler JobItems_Get_For_JobRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler JobItems_Get_For_JobRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler JobItems_Get_For_JobRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddJobItems_Get_For_JobRow(FSMDataSet.JobItems_Get_For_JobRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.JobItems_Get_For_JobRow AddJobItems_Get_For_JobRow(string Summary)
      {
        FSMDataSet.JobItems_Get_For_JobRow itemsGetForJobRow = (FSMDataSet.JobItems_Get_For_JobRow) this.NewRow();
        object[] objArray = new object[1]
        {
          (object) Summary
        };
        itemsGetForJobRow.ItemArray = objArray;
        this.Rows.Add((DataRow) itemsGetForJobRow);
        return itemsGetForJobRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.JobItems_Get_For_JobDataTable getForJobDataTable = (FSMDataSet.JobItems_Get_For_JobDataTable) base.Clone();
        getForJobDataTable.InitVars();
        return (DataTable) getForJobDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.JobItems_Get_For_JobDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnSummary = this.Columns["Summary"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnSummary = new DataColumn("Summary", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSummary);
        this.columnSummary.AllowDBNull = false;
        this.columnSummary.MaxLength = 4000;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.JobItems_Get_For_JobRow NewJobItems_Get_For_JobRow()
      {
        return (FSMDataSet.JobItems_Get_For_JobRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.JobItems_Get_For_JobRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.JobItems_Get_For_JobRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.JobItems_Get_For_JobRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler jobRowChangedEvent = this.JobItems_Get_For_JobRowChangedEvent;
        if (jobRowChangedEvent != null)
          jobRowChangedEvent((object) this, new FSMDataSet.JobItems_Get_For_JobRowChangeEvent((FSMDataSet.JobItems_Get_For_JobRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.JobItems_Get_For_JobRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler rowChangingEvent = this.JobItems_Get_For_JobRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.JobItems_Get_For_JobRowChangeEvent((FSMDataSet.JobItems_Get_For_JobRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.JobItems_Get_For_JobRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler jobRowDeletedEvent = this.JobItems_Get_For_JobRowDeletedEvent;
        if (jobRowDeletedEvent != null)
          jobRowDeletedEvent((object) this, new FSMDataSet.JobItems_Get_For_JobRowChangeEvent((FSMDataSet.JobItems_Get_For_JobRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.JobItems_Get_For_JobRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.JobItems_Get_For_JobRowChangeEventHandler rowDeletingEvent = this.JobItems_Get_For_JobRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.JobItems_Get_For_JobRowChangeEvent((FSMDataSet.JobItems_Get_For_JobRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveJobItems_Get_For_JobRow(FSMDataSet.JobItems_Get_For_JobRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (JobItems_Get_For_JobDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class Site_Get_ForEngineerVisitIDDataTable : TypedTableBase<FSMDataSet.Site_Get_ForEngineerVisitIDRow>
    {
      private DataColumn columnSiteID;
      private DataColumn columnName;
      private DataColumn columnCustomerID;
      private DataColumn columnRegionID;
      private DataColumn columnHeadOffice;
      private DataColumn columnHeadOfficeResult;
      private DataColumn columnNotes;
      private DataColumn columnAddress1;
      private DataColumn columnAddress2;
      private DataColumn columnAddress3;
      private DataColumn columnAddress4;
      private DataColumn columnAddress5;
      private DataColumn columnPostcode;
      private DataColumn columnTelephoneNum;
      private DataColumn columnFaxNum;
      private DataColumn columnEmailAddress;
      private DataColumn columnEngineerID;
      private DataColumn columnPoNumReqd;
      private DataColumn columnAcceptChargesChanges;
      private DataColumn columnDeleted;
      private DataColumn columnSourceOfCustomer;
      private DataColumn columnPolicyNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Site_Get_ForEngineerVisitIDDataTable()
      {
        this.TableName = "Site_Get_ForEngineerVisitID";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Site_Get_ForEngineerVisitIDDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) > 0U)
          this.Locale = table.Locale;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Namespace, table.DataSet.Namespace, false) > 0U)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected Site_Get_ForEngineerVisitIDDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SiteIDColumn
      {
        get
        {
          return this.columnSiteID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NameColumn
      {
        get
        {
          return this.columnName;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn CustomerIDColumn
      {
        get
        {
          return this.columnCustomerID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn RegionIDColumn
      {
        get
        {
          return this.columnRegionID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn HeadOfficeColumn
      {
        get
        {
          return this.columnHeadOffice;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn HeadOfficeResultColumn
      {
        get
        {
          return this.columnHeadOfficeResult;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn NotesColumn
      {
        get
        {
          return this.columnNotes;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address1Column
      {
        get
        {
          return this.columnAddress1;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address2Column
      {
        get
        {
          return this.columnAddress2;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address3Column
      {
        get
        {
          return this.columnAddress3;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address4Column
      {
        get
        {
          return this.columnAddress4;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn Address5Column
      {
        get
        {
          return this.columnAddress5;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PostcodeColumn
      {
        get
        {
          return this.columnPostcode;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn TelephoneNumColumn
      {
        get
        {
          return this.columnTelephoneNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn FaxNumColumn
      {
        get
        {
          return this.columnFaxNum;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EmailAddressColumn
      {
        get
        {
          return this.columnEmailAddress;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn EngineerIDColumn
      {
        get
        {
          return this.columnEngineerID;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PoNumReqdColumn
      {
        get
        {
          return this.columnPoNumReqd;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn AcceptChargesChangesColumn
      {
        get
        {
          return this.columnAcceptChargesChanges;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn DeletedColumn
      {
        get
        {
          return this.columnDeleted;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn SourceOfCustomerColumn
      {
        get
        {
          return this.columnSourceOfCustomer;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataColumn PolicyNumberColumn
      {
        get
        {
          return this.columnPolicyNumber;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Site_Get_ForEngineerVisitIDRow this[int index]
      {
        get
        {
          return (FSMDataSet.Site_Get_ForEngineerVisitIDRow) this.Rows[index];
        }
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler Site_Get_ForEngineerVisitIDRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler Site_Get_ForEngineerVisitIDRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler Site_Get_ForEngineerVisitIDRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public event FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler Site_Get_ForEngineerVisitIDRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void AddSite_Get_ForEngineerVisitIDRow(FSMDataSet.Site_Get_ForEngineerVisitIDRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Site_Get_ForEngineerVisitIDRow AddSite_Get_ForEngineerVisitIDRow(
        string Name,
        int CustomerID,
        int RegionID,
        bool HeadOffice,
        string HeadOfficeResult,
        string Notes,
        string Address1,
        string Address2,
        string Address3,
        string Address4,
        string Address5,
        string Postcode,
        string TelephoneNum,
        string FaxNum,
        string EmailAddress,
        int EngineerID,
        bool PoNumReqd,
        bool AcceptChargesChanges,
        bool Deleted,
        string SourceOfCustomer,
        string PolicyNumber)
      {
        FSMDataSet.Site_Get_ForEngineerVisitIDRow engineerVisitIdRow = (FSMDataSet.Site_Get_ForEngineerVisitIDRow) this.NewRow();
        object[] objArray = new object[22]
        {
          null,
          (object) Name,
          (object) CustomerID,
          (object) RegionID,
          (object) HeadOffice,
          (object) HeadOfficeResult,
          (object) Notes,
          (object) Address1,
          (object) Address2,
          (object) Address3,
          (object) Address4,
          (object) Address5,
          (object) Postcode,
          (object) TelephoneNum,
          (object) FaxNum,
          (object) EmailAddress,
          (object) EngineerID,
          (object) PoNumReqd,
          (object) AcceptChargesChanges,
          (object) Deleted,
          (object) SourceOfCustomer,
          (object) PolicyNumber
        };
        engineerVisitIdRow.ItemArray = objArray;
        this.Rows.Add((DataRow) engineerVisitIdRow);
        return engineerVisitIdRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Site_Get_ForEngineerVisitIDRow FindBySiteID(int SiteID)
      {
        return (FSMDataSet.Site_Get_ForEngineerVisitIDRow) this.Rows.Find(new object[1]
        {
          (object) SiteID
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public override DataTable Clone()
      {
        FSMDataSet.Site_Get_ForEngineerVisitIDDataTable visitIdDataTable = (FSMDataSet.Site_Get_ForEngineerVisitIDDataTable) base.Clone();
        visitIdDataTable.InitVars();
        return (DataTable) visitIdDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new FSMDataSet.Site_Get_ForEngineerVisitIDDataTable();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal void InitVars()
      {
        this.columnSiteID = this.Columns["SiteID"];
        this.columnName = this.Columns["Name"];
        this.columnCustomerID = this.Columns["CustomerID"];
        this.columnRegionID = this.Columns["RegionID"];
        this.columnHeadOffice = this.Columns["HeadOffice"];
        this.columnHeadOfficeResult = this.Columns["HeadOfficeResult"];
        this.columnNotes = this.Columns["Notes"];
        this.columnAddress1 = this.Columns["Address1"];
        this.columnAddress2 = this.Columns["Address2"];
        this.columnAddress3 = this.Columns["Address3"];
        this.columnAddress4 = this.Columns["Address4"];
        this.columnAddress5 = this.Columns["Address5"];
        this.columnPostcode = this.Columns["Postcode"];
        this.columnTelephoneNum = this.Columns["TelephoneNum"];
        this.columnFaxNum = this.Columns["FaxNum"];
        this.columnEmailAddress = this.Columns["EmailAddress"];
        this.columnEngineerID = this.Columns["EngineerID"];
        this.columnPoNumReqd = this.Columns["PoNumReqd"];
        this.columnAcceptChargesChanges = this.Columns["AcceptChargesChanges"];
        this.columnDeleted = this.Columns["Deleted"];
        this.columnSourceOfCustomer = this.Columns["SourceOfCustomer"];
        this.columnPolicyNumber = this.Columns["PolicyNumber"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private void InitClass()
      {
        this.columnSiteID = new DataColumn("SiteID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSiteID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnCustomerID = new DataColumn("CustomerID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCustomerID);
        this.columnRegionID = new DataColumn("RegionID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRegionID);
        this.columnHeadOffice = new DataColumn("HeadOffice", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnHeadOffice);
        this.columnHeadOfficeResult = new DataColumn("HeadOfficeResult", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnHeadOfficeResult);
        this.columnNotes = new DataColumn("Notes", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNotes);
        this.columnAddress1 = new DataColumn("Address1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress1);
        this.columnAddress2 = new DataColumn("Address2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress2);
        this.columnAddress3 = new DataColumn("Address3", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress3);
        this.columnAddress4 = new DataColumn("Address4", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress4);
        this.columnAddress5 = new DataColumn("Address5", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress5);
        this.columnPostcode = new DataColumn("Postcode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPostcode);
        this.columnTelephoneNum = new DataColumn("TelephoneNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelephoneNum);
        this.columnFaxNum = new DataColumn("FaxNum", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFaxNum);
        this.columnEmailAddress = new DataColumn("EmailAddress", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmailAddress);
        this.columnEngineerID = new DataColumn("EngineerID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEngineerID);
        this.columnPoNumReqd = new DataColumn("PoNumReqd", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPoNumReqd);
        this.columnAcceptChargesChanges = new DataColumn("AcceptChargesChanges", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAcceptChargesChanges);
        this.columnDeleted = new DataColumn("Deleted", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDeleted);
        this.columnSourceOfCustomer = new DataColumn("SourceOfCustomer", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSourceOfCustomer);
        this.columnPolicyNumber = new DataColumn("PolicyNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPolicyNumber);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnSiteID
        }, true));
        this.columnSiteID.AutoIncrement = true;
        this.columnSiteID.AllowDBNull = false;
        this.columnSiteID.ReadOnly = true;
        this.columnSiteID.Unique = true;
        this.columnName.MaxLength = (int) byte.MaxValue;
        this.columnCustomerID.AllowDBNull = false;
        this.columnRegionID.AllowDBNull = false;
        this.columnHeadOffice.AllowDBNull = false;
        this.columnHeadOfficeResult.ReadOnly = true;
        this.columnHeadOfficeResult.MaxLength = 3;
        this.columnNotes.MaxLength = 4000;
        this.columnAddress1.MaxLength = (int) byte.MaxValue;
        this.columnAddress2.MaxLength = (int) byte.MaxValue;
        this.columnAddress3.MaxLength = (int) byte.MaxValue;
        this.columnAddress4.MaxLength = (int) byte.MaxValue;
        this.columnAddress5.MaxLength = (int) byte.MaxValue;
        this.columnPostcode.MaxLength = 10;
        this.columnTelephoneNum.MaxLength = 50;
        this.columnFaxNum.MaxLength = 50;
        this.columnEmailAddress.MaxLength = 100;
        this.columnPoNumReqd.AllowDBNull = false;
        this.columnDeleted.AllowDBNull = false;
        this.columnSourceOfCustomer.MaxLength = (int) byte.MaxValue;
        this.columnPolicyNumber.MaxLength = (int) byte.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Site_Get_ForEngineerVisitIDRow NewSite_Get_ForEngineerVisitIDRow()
      {
        return (FSMDataSet.Site_Get_ForEngineerVisitIDRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new FSMDataSet.Site_Get_ForEngineerVisitIDRow(builder);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override Type GetRowType()
      {
        return typeof (FSMDataSet.Site_Get_ForEngineerVisitIDRow);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Site_Get_ForEngineerVisitIDRowChangedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler idRowChangedEvent = this.Site_Get_ForEngineerVisitIDRowChangedEvent;
        if (idRowChangedEvent != null)
          idRowChangedEvent((object) this, new FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEvent((FSMDataSet.Site_Get_ForEngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Site_Get_ForEngineerVisitIDRowChangingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler rowChangingEvent = this.Site_Get_ForEngineerVisitIDRowChangingEvent;
        if (rowChangingEvent != null)
          rowChangingEvent((object) this, new FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEvent((FSMDataSet.Site_Get_ForEngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Site_Get_ForEngineerVisitIDRowDeletedEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler idRowDeletedEvent = this.Site_Get_ForEngineerVisitIDRowDeletedEvent;
        if (idRowDeletedEvent != null)
          idRowDeletedEvent((object) this, new FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEvent((FSMDataSet.Site_Get_ForEngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        // ISSUE: reference to a compiler-generated field
        if (this.Site_Get_ForEngineerVisitIDRowDeletingEvent == null)
          return;
        // ISSUE: reference to a compiler-generated field
        FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEventHandler rowDeletingEvent = this.Site_Get_ForEngineerVisitIDRowDeletingEvent;
        if (rowDeletingEvent != null)
          rowDeletingEvent((object) this, new FSMDataSet.Site_Get_ForEngineerVisitIDRowChangeEvent((FSMDataSet.Site_Get_ForEngineerVisitIDRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void RemoveSite_Get_ForEngineerVisitIDRow(FSMDataSet.Site_Get_ForEngineerVisitIDRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        FSMDataSet fsmDataSet = new FSMDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = fsmDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Site_Get_ForEngineerVisitIDDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = fsmDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    public class Customer_Get_ForSiteIDRow : DataRow
    {
      private FSMDataSet.Customer_Get_ForSiteIDDataTable tableCustomer_Get_ForSiteID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Customer_Get_ForSiteIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableCustomer_Get_ForSiteID = (FSMDataSet.Customer_Get_ForSiteIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int CustomerID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableCustomer_Get_ForSiteID.CustomerIDColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.CustomerIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Name
      {
        get
        {
          return Conversions.ToString(this[this.tableCustomer_Get_ForSiteID.NameColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.NameColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int CustomerTypeID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableCustomer_Get_ForSiteID.CustomerTypeIDColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.CustomerTypeIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int RegionID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableCustomer_Get_ForSiteID.RegionIDColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.RegionIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Notes
      {
        get
        {
          return Conversions.ToString(this[this.tableCustomer_Get_ForSiteID.NotesColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.NotesColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string AccountNumber
      {
        get
        {
          return Conversions.ToString(this[this.tableCustomer_Get_ForSiteID.AccountNumberColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.AccountNumberColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int Status
      {
        get
        {
          return Conversions.ToInteger(this[this.tableCustomer_Get_ForSiteID.StatusColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.StatusColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool AcceptChargesChanges
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableCustomer_Get_ForSiteID.AcceptChargesChangesColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.AcceptChargesChangesColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Deleted
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableCustomer_Get_ForSiteID.DeletedColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.DeletedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal MainContractorDiscount
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableCustomer_Get_ForSiteID.MainContractorDiscountColumn]);
        }
        set
        {
          this[this.tableCustomer_Get_ForSiteID.MainContractorDiscountColumn] = (object) value;
        }
      }
    }

    public class EngineerVisitAssetWorkSheet_GetForVisitRow : DataRow
    {
      private FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable tableEngineerVisitAssetWorkSheet_GetForVisit;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitAssetWorkSheet_GetForVisitRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableEngineerVisitAssetWorkSheet_GetForVisit = (FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitAssetWorkSheetID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.EngineerVisitAssetWorkSheetIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.EngineerVisitAssetWorkSheetIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.EngineerVisitIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.EngineerVisitIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int AssetID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.AssetIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.AssetIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int FlueTerminationSatisfactoryID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.FlueTerminationSatisfactoryIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.FlueTerminationSatisfactoryIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int FlueFlowTestID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.FlueFlowTestIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.FlueFlowTestIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int SpillageTestID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SpillageTestIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SpillageTestIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int VentilationProvisionSatisfactoryID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.VentilationProvisionSatisfactoryIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.VentilationProvisionSatisfactoryIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int SafetyDeviceOperationID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SafetyDeviceOperationIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SafetyDeviceOperationIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal DHWFlowRate
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DHWFlowRateColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DHWFlowRateColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal ColdWaterTemp
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ColdWaterTempColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ColdWaterTempColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal DHWTemp
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DHWTempColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DHWTempColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal InletStaticPressure
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.InletStaticPressureColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.InletStaticPressureColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal InletWorkingPressure
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.InletWorkingPressureColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.InletWorkingPressureColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal MinBurnerPressure
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.MinBurnerPressureColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.MinBurnerPressureColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal MaxBurnerPressure
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.MaxBurnerPressureColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.MaxBurnerPressureColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal CO2
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.CO2Column]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.CO2Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal CO2CORatio
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.CO2CORatioColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.CO2CORatioColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int LandlordsApplianceID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.LandlordsApplianceIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.LandlordsApplianceIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int ApplianceServiceOrInspectedID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ApplianceServiceOrInspectedIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ApplianceServiceOrInspectedIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int ApplianceSafeID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ApplianceSafeIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.ApplianceSafeIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int VisualConditionOfFlueSatisfactoryID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.VisualConditionOfFlueSatisfactoryIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.VisualConditionOfFlueSatisfactoryIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Deleted
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DeletedColumn]);
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.DeletedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Location
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.LocationColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Location' in table 'EngineerVisitAssetWorkSheet_GetForVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.LocationColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string SerialNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SerialNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'SerialNum' in table 'EngineerVisitAssetWorkSheet_GetForVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SerialNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string typemakemodel
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.typemakemodelColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'typemakemodel' in table 'EngineerVisitAssetWorkSheet_GetForVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.typemakemodelColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsLocationNull()
      {
        return this.IsNull(this.tableEngineerVisitAssetWorkSheet_GetForVisit.LocationColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetLocationNull()
      {
        this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.LocationColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsSerialNumNull()
      {
        return this.IsNull(this.tableEngineerVisitAssetWorkSheet_GetForVisit.SerialNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetSerialNumNull()
      {
        this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.SerialNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IstypemakemodelNull()
      {
        return this.IsNull(this.tableEngineerVisitAssetWorkSheet_GetForVisit.typemakemodelColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SettypemakemodelNull()
      {
        this[this.tableEngineerVisitAssetWorkSheet_GetForVisit.typemakemodelColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class EngineerVisitDefects_GetForEngineerVisitRow : DataRow
    {
      private FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable tableEngineerVisitDefects_GetForEngineerVisit;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitDefects_GetForEngineerVisitRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableEngineerVisitDefects_GetForEngineerVisit = (FSMDataSet.EngineerVisitDefects_GetForEngineerVisitDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitDefectID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitDefects_GetForEngineerVisit.EngineerVisitDefectIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.EngineerVisitDefectIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int CategoryID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitDefects_GetForEngineerVisit.CategoryIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.CategoryIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Reason
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.ReasonColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Reason' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.ReasonColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string ActionTaken
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.ActionTakenColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'ActionTaken' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.ActionTakenColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string WarningNoticeIssued
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.WarningNoticeIssuedColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'WarningNoticeIssued' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.WarningNoticeIssuedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Disconnected
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.DisconnectedColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Disconnected' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.DisconnectedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Disconnected1
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableEngineerVisitDefects_GetForEngineerVisit.Disconnected1Column]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.Disconnected1Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Comments
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.CommentsColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Comments' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.CommentsColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int AssetID
      {
        get
        {
          try
          {
            return Conversions.ToInteger(this[this.tableEngineerVisitDefects_GetForEngineerVisit.AssetIDColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'AssetID' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.AssetIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Category
      {
        get
        {
          return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.CategoryColumn]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.CategoryColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Location
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.LocationColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Location' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.LocationColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string SerialNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.SerialNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'SerialNum' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.SerialNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string typemakemodel
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitDefects_GetForEngineerVisit.typemakemodelColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'typemakemodel' in table 'EngineerVisitDefects_GetForEngineerVisit' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.typemakemodelColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitDefects_GetForEngineerVisit.EngineerVisitIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.EngineerVisitIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Deleted
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableEngineerVisitDefects_GetForEngineerVisit.DeletedColumn]);
        }
        set
        {
          this[this.tableEngineerVisitDefects_GetForEngineerVisit.DeletedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsReasonNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.ReasonColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetReasonNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.ReasonColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsActionTakenNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.ActionTakenColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetActionTakenNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.ActionTakenColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsWarningNoticeIssuedNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.WarningNoticeIssuedColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetWarningNoticeIssuedNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.WarningNoticeIssuedColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsDisconnectedNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.DisconnectedColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetDisconnectedNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.DisconnectedColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsCommentsNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.CommentsColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetCommentsNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.CommentsColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAssetIDNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.AssetIDColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAssetIDNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.AssetIDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsLocationNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.LocationColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetLocationNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.LocationColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsSerialNumNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.SerialNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetSerialNumNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.SerialNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IstypemakemodelNull()
      {
        return this.IsNull(this.tableEngineerVisitDefects_GetForEngineerVisit.typemakemodelColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SettypemakemodelNull()
      {
        this[this.tableEngineerVisitDefects_GetForEngineerVisit.typemakemodelColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow : DataRow
    {
      private FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool tick
      {
        get
        {
          try
          {
            return Conversions.ToBoolean(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tickColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'tick' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tickColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitScheduleOfRateChargesID
      {
        get
        {
          try
          {
            return Conversions.ToInteger(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.EngineerVisitScheduleOfRateChargesIDColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'EngineerVisitScheduleOfRateChargesID' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.EngineerVisitScheduleOfRateChargesIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int JobItemID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.JobItemIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.JobItemIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Code
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.CodeColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Code' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.CodeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string category
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.categoryColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'category' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.categoryColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Summary
      {
        get
        {
          return Conversions.ToString(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.SummaryColumn]);
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.SummaryColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal NumUnitsUsed
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.NumUnitsUsedColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'NumUnitsUsed' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.NumUnitsUsedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal Price
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.PriceColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Price' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.PriceColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal Total
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.TotalColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Total' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.TotalColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool tick1
      {
        get
        {
          try
          {
            return Conversions.ToBoolean(this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tick1Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'tick1' in table 'EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tick1Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IstickNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tickColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SettickNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tickColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsEngineerVisitScheduleOfRateChargesIDNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.EngineerVisitScheduleOfRateChargesIDColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetEngineerVisitScheduleOfRateChargesIDNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.EngineerVisitScheduleOfRateChargesIDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsCodeNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.CodeColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetCodeNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.CodeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IscategoryNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.categoryColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetcategoryNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.categoryColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsNumUnitsUsedNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.NumUnitsUsedColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetNumUnitsUsedNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.NumUnitsUsedColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPriceNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.PriceColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPriceNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.PriceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsTotalNull()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.TotalColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetTotalNull()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.TotalColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Istick1Null()
      {
        return this.IsNull(this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tick1Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void Settick1Null()
      {
        this[this.tableEngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID.tick1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow : DataRow
    {
      private FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable tableEngineerVisitTimeSheet_Get_For_EngineerVisitID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitTimeSheetID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EngineerVisitTimeSheetIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EngineerVisitTimeSheetIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerVisitID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EngineerVisitIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EngineerVisitIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DateTime StartDateTime
      {
        get
        {
          return Conversions.ToDate(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.StartDateTimeColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.StartDateTimeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DateTime EndDateTime
      {
        get
        {
          return Conversions.ToDate(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EndDateTimeColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.EndDateTimeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Comments
      {
        get
        {
          return Conversions.ToString(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.CommentsColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.CommentsColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string TimeSheetType
      {
        get
        {
          return Conversions.ToString(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.TimeSheetTypeColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.TimeSheetTypeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int TimesheetTypeID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.TimesheetTypeIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitTimeSheet_Get_For_EngineerVisitID.TimesheetTypeIDColumn] = (object) value;
        }
      }
    }

    public class EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow : DataRow
    {
      private FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID = (FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int JobItemID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.JobItemIDColumn]);
        }
        set
        {
          this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.JobItemIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Summary
      {
        get
        {
          return Conversions.ToString(this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.SummaryColumn]);
        }
        set
        {
          this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.SummaryColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal NumAllocated
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumAllocatedColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'NumAllocated' in table 'EngineerVisitUnitsUsed_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumAllocatedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal NumUnitsUsed
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumUnitsUsedColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'NumUnitsUsed' in table 'EngineerVisitUnitsUsed_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumUnitsUsedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal Price
      {
        get
        {
          try
          {
            return Conversions.ToDecimal(this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.PriceColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Price' in table 'EngineerVisitUnitsUsed_Get_For_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.PriceColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsNumAllocatedNull()
      {
        return this.IsNull(this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumAllocatedColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetNumAllocatedNull()
      {
        this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumAllocatedColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsNumUnitsUsedNull()
      {
        return this.IsNull(this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumUnitsUsedColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetNumUnitsUsedNull()
      {
        this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.NumUnitsUsedColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPriceNull()
      {
        return this.IsNull(this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.PriceColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPriceNull()
      {
        this[this.tableEngineerVisitUnitsUsed_Get_For_EngineerVisitID.PriceColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class InvoiceAddress_Get_EngineerVisitIDRow : DataRow
    {
      private FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable tableInvoiceAddress_Get_EngineerVisitID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal InvoiceAddress_Get_EngineerVisitIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableInvoiceAddress_Get_EngineerVisitID = (FSMDataSet.InvoiceAddress_Get_EngineerVisitIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int AddressTypeID
      {
        get
        {
          try
          {
            return Conversions.ToInteger(this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeIDColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'AddressTypeID' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string AddressType
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'AddressType' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int AddressID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressIDColumn]);
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address1
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.Address1Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address1' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.Address1Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address2
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.Address2Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address2' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.Address2Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address3
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.Address3Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address3' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.Address3Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address4
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.Address4Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address4' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.Address4Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address5
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.Address5Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address5' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.Address5Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Postcode
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.PostcodeColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Postcode' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.PostcodeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string TelephoneNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.TelephoneNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'TelephoneNum' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.TelephoneNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string FaxNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.FaxNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'FaxNum' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.FaxNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string EmailAddress
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableInvoiceAddress_Get_EngineerVisitID.EmailAddressColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'EmailAddress' in table 'InvoiceAddress_Get_EngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableInvoiceAddress_Get_EngineerVisitID.EmailAddressColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddressTypeIDNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeIDColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddressTypeIDNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeIDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddressTypeNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddressTypeNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.AddressTypeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress1Null()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.Address1Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress1Null()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.Address1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress2Null()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.Address2Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress2Null()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.Address2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress3Null()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.Address3Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress3Null()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.Address3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress4Null()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.Address4Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress4Null()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.Address4Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress5Null()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.Address5Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress5Null()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.Address5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPostcodeNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.PostcodeColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPostcodeNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.PostcodeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsTelephoneNumNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.TelephoneNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetTelephoneNumNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.TelephoneNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsFaxNumNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.FaxNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetFaxNumNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.FaxNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsEmailAddressNull()
      {
        return this.IsNull(this.tableInvoiceAddress_Get_EngineerVisitID.EmailAddressColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetEmailAddressNull()
      {
        this[this.tableInvoiceAddress_Get_EngineerVisitID.EmailAddressColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class Job_Get_For_An_EngineerVisit_IDRow : DataRow
    {
      private FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable tableJob_Get_For_An_EngineerVisit_ID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Job_Get_For_An_EngineerVisit_IDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableJob_Get_For_An_EngineerVisit_ID = (FSMDataSet.Job_Get_For_An_EngineerVisit_IDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int JobID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.JobIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.JobIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int SiteID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.SiteIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.SiteIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int JobDefinitionEnumID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.JobDefinitionEnumIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.JobDefinitionEnumIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int JobTypeID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.JobTypeIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.JobTypeIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int StatusEnumID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.StatusEnumIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.StatusEnumIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DateTime DateCreated
      {
        get
        {
          return Conversions.ToDate(this[this.tableJob_Get_For_An_EngineerVisit_ID.DateCreatedColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.DateCreatedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int CreatedByUserID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.CreatedByUserIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.CreatedByUserIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string JobNumber
      {
        get
        {
          return Conversions.ToString(this[this.tableJob_Get_For_An_EngineerVisit_ID.JobNumberColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.JobNumberColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string PONumber
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableJob_Get_For_An_EngineerVisit_ID.PONumberColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'PONumber' in table 'Job_Get_For_An_EngineerVisit_ID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.PONumberColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int QuoteID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.QuoteIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.QuoteIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int ContractID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableJob_Get_For_An_EngineerVisit_ID.ContractIDColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.ContractIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool ToBePartPaid
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableJob_Get_For_An_EngineerVisit_ID.ToBePartPaidColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.ToBePartPaidColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Decimal Retention
      {
        get
        {
          return Conversions.ToDecimal(this[this.tableJob_Get_For_An_EngineerVisit_ID.RetentionColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.RetentionColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Deleted
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableJob_Get_For_An_EngineerVisit_ID.DeletedColumn]);
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.DeletedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool CollectPayment
      {
        get
        {
          try
          {
            return Conversions.ToBoolean(this[this.tableJob_Get_For_An_EngineerVisit_ID.CollectPaymentColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'CollectPayment' in table 'Job_Get_For_An_EngineerVisit_ID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableJob_Get_For_An_EngineerVisit_ID.CollectPaymentColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPONumberNull()
      {
        return this.IsNull(this.tableJob_Get_For_An_EngineerVisit_ID.PONumberColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPONumberNull()
      {
        this[this.tableJob_Get_For_An_EngineerVisit_ID.PONumberColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsCollectPaymentNull()
      {
        return this.IsNull(this.tableJob_Get_For_An_EngineerVisit_ID.CollectPaymentColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetCollectPaymentNull()
      {
        this[this.tableJob_Get_For_An_EngineerVisit_ID.CollectPaymentColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    public class JobItems_Get_For_JobRow : DataRow
    {
      private FSMDataSet.JobItems_Get_For_JobDataTable tableJobItems_Get_For_Job;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal JobItems_Get_For_JobRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableJobItems_Get_For_Job = (FSMDataSet.JobItems_Get_For_JobDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Summary
      {
        get
        {
          return Conversions.ToString(this[this.tableJobItems_Get_For_Job.SummaryColumn]);
        }
        set
        {
          this[this.tableJobItems_Get_For_Job.SummaryColumn] = (object) value;
        }
      }
    }

    public class Site_Get_ForEngineerVisitIDRow : DataRow
    {
      private FSMDataSet.Site_Get_ForEngineerVisitIDDataTable tableSite_Get_ForEngineerVisitID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal Site_Get_ForEngineerVisitIDRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tableSite_Get_ForEngineerVisitID = (FSMDataSet.Site_Get_ForEngineerVisitIDDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int SiteID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableSite_Get_ForEngineerVisitID.SiteIDColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.SiteIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Name
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.NameColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Name' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.NameColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int CustomerID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableSite_Get_ForEngineerVisitID.CustomerIDColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.CustomerIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int RegionID
      {
        get
        {
          return Conversions.ToInteger(this[this.tableSite_Get_ForEngineerVisitID.RegionIDColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.RegionIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool HeadOffice
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableSite_Get_ForEngineerVisitID.HeadOfficeColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.HeadOfficeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string HeadOfficeResult
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.HeadOfficeResultColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'HeadOfficeResult' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.HeadOfficeResultColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Notes
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.NotesColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Notes' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.NotesColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address1
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.Address1Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address1' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.Address1Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address2
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.Address2Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address2' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.Address2Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address3
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.Address3Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address3' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.Address3Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address4
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.Address4Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address4' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.Address4Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Address5
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.Address5Column]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Address5' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.Address5Column] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string Postcode
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.PostcodeColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'Postcode' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.PostcodeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string TelephoneNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.TelephoneNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'TelephoneNum' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.TelephoneNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string FaxNum
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.FaxNumColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'FaxNum' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.FaxNumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string EmailAddress
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.EmailAddressColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'EmailAddress' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.EmailAddressColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int EngineerID
      {
        get
        {
          try
          {
            return Conversions.ToInteger(this[this.tableSite_Get_ForEngineerVisitID.EngineerIDColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'EngineerID' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.EngineerIDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool PoNumReqd
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableSite_Get_ForEngineerVisitID.PoNumReqdColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.PoNumReqdColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool AcceptChargesChanges
      {
        get
        {
          try
          {
            return Conversions.ToBoolean(this[this.tableSite_Get_ForEngineerVisitID.AcceptChargesChangesColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'AcceptChargesChanges' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.AcceptChargesChangesColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool Deleted
      {
        get
        {
          return Conversions.ToBoolean(this[this.tableSite_Get_ForEngineerVisitID.DeletedColumn]);
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.DeletedColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string SourceOfCustomer
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.SourceOfCustomerColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'SourceOfCustomer' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.SourceOfCustomerColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public string PolicyNumber
      {
        get
        {
          try
          {
            return Conversions.ToString(this[this.tableSite_Get_ForEngineerVisitID.PolicyNumberColumn]);
          }
          catch (InvalidCastException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            throw new StrongTypingException("The value for column 'PolicyNumber' in table 'Site_Get_ForEngineerVisitID' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tableSite_Get_ForEngineerVisitID.PolicyNumberColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsNameNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.NameColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetNameNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.NameColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsHeadOfficeResultNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.HeadOfficeResultColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetHeadOfficeResultNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.HeadOfficeResultColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsNotesNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.NotesColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetNotesNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.NotesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress1Null()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.Address1Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress1Null()
      {
        this[this.tableSite_Get_ForEngineerVisitID.Address1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress2Null()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.Address2Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress2Null()
      {
        this[this.tableSite_Get_ForEngineerVisitID.Address2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress3Null()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.Address3Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress3Null()
      {
        this[this.tableSite_Get_ForEngineerVisitID.Address3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress4Null()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.Address4Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress4Null()
      {
        this[this.tableSite_Get_ForEngineerVisitID.Address4Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAddress5Null()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.Address5Column);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAddress5Null()
      {
        this[this.tableSite_Get_ForEngineerVisitID.Address5Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPostcodeNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.PostcodeColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPostcodeNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.PostcodeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsTelephoneNumNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.TelephoneNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetTelephoneNumNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.TelephoneNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsFaxNumNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.FaxNumColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetFaxNumNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.FaxNumColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsEmailAddressNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.EmailAddressColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetEmailAddressNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.EmailAddressColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsEngineerIDNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.EngineerIDColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetEngineerIDNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.EngineerIDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsAcceptChargesChangesNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.AcceptChargesChangesColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetAcceptChargesChangesNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.AcceptChargesChangesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsSourceOfCustomerNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.SourceOfCustomerColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetSourceOfCustomerNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.SourceOfCustomerColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public bool IsPolicyNumberNull()
      {
        return this.IsNull(this.tableSite_Get_ForEngineerVisitID.PolicyNumberColumn);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public void SetPolicyNumberNull()
      {
        this[this.tableSite_Get_ForEngineerVisitID.PolicyNumberColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class Customer_Get_ForSiteIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.Customer_Get_ForSiteIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Customer_Get_ForSiteIDRowChangeEvent(
        FSMDataSet.Customer_Get_ForSiteIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Customer_Get_ForSiteIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent : EventArgs
    {
      private FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitAssetWorkSheet_GetForVisitRowChangeEvent(
        FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitAssetWorkSheet_GetForVisitRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class EngineerVisitDefects_GetForEngineerVisitRowChangeEvent : EventArgs
    {
      private FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitDefects_GetForEngineerVisitRowChangeEvent(
        FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitDefects_GetForEngineerVisitRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRowChangeEvent(
        FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitTimeSheet_Get_For_EngineerVisitIDRowChangeEvent(
        FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRowChangeEvent(
        FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.EngineerVisitUnitsUsed_Get_For_EngineerVisitIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class InvoiceAddress_Get_EngineerVisitIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public InvoiceAddress_Get_EngineerVisitIDRowChangeEvent(
        FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.InvoiceAddress_Get_EngineerVisitIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class Job_Get_For_An_EngineerVisit_IDRowChangeEvent : EventArgs
    {
      private FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Job_Get_For_An_EngineerVisit_IDRowChangeEvent(
        FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Job_Get_For_An_EngineerVisit_IDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class JobItems_Get_For_JobRowChangeEvent : EventArgs
    {
      private FSMDataSet.JobItems_Get_For_JobRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public JobItems_Get_For_JobRowChangeEvent(
        FSMDataSet.JobItems_Get_For_JobRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.JobItems_Get_For_JobRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public class Site_Get_ForEngineerVisitIDRowChangeEvent : EventArgs
    {
      private FSMDataSet.Site_Get_ForEngineerVisitIDRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public Site_Get_ForEngineerVisitIDRowChangeEvent(
        FSMDataSet.Site_Get_ForEngineerVisitIDRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public FSMDataSet.Site_Get_ForEngineerVisitIDRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }
  }
}
