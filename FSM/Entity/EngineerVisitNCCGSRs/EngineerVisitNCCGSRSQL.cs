// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSRSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitNCCGSRs
{
  public class EngineerVisitNCCGSRSQL
  {
    private Database _database;

    public EngineerVisitNCCGSRSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerVisitNCCGSRID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitNCCGSRID", (object) EngineerVisitNCCGSRID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Delete", true);
    }

    public EngineerVisitNCCGSR EngineerVisitNCCGSR_Get(int EngineerVisitNCCGSRID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitNCCGSRID", (object) EngineerVisitNCCGSRID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (EngineerVisitNCCGSR_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (EngineerVisitNCCGSR) null;
      EngineerVisitNCCGSR engineerVisitNccgsr1 = new EngineerVisitNCCGSR();
      EngineerVisitNCCGSR engineerVisitNccgsr2 = engineerVisitNccgsr1;
      engineerVisitNccgsr2.IgnoreExceptionsOnSetMethods = true;
      engineerVisitNccgsr2.SetEngineerVisitNCCGSRID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerVisitNCCGSRID)]);
      engineerVisitNccgsr2.SetCorrectMaterialsUsedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CorrectMaterialsUsedID"]);
      engineerVisitNccgsr2.SetInstallationPipeWorkCorrectID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InstallationPipeWorkCorrectID"]);
      engineerVisitNccgsr2.SetInstallationSafeToUseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InstallationSafeToUseID"]);
      engineerVisitNccgsr2.SetStrainerFittedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StrainerFittedID"]);
      engineerVisitNccgsr2.SetStrainerInspectedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StrainerInspectedID"]);
      engineerVisitNccgsr2.SetHeatingSystemTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HeatingSystemTypeID"]);
      engineerVisitNccgsr2.SetPartialHeatingID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartialHeatingID"]);
      engineerVisitNccgsr2.SetCylinderTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CylinderTypeID"]);
      engineerVisitNccgsr2.SetJacketID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JacketID"]);
      engineerVisitNccgsr2.SetImmersionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ImmersionID"]);
      engineerVisitNccgsr2.SetRadiators = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Radiators"]);
      engineerVisitNccgsr2.SetCODetectorFittedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CODetectorFittedID"]);
      engineerVisitNccgsr2.SetApproxAgeOfBoiler = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApproxAgeOfBoiler"]);
      engineerVisitNccgsr2.SetCertificateTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CertificateTypeID"]);
      engineerVisitNccgsr2.SetVisualInspectionSatisfactoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisualInspectionSatisfactoryID"]);
      engineerVisitNccgsr2.SetVisualInspectionReason = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisualInspectionReason"]);
      engineerVisitNccgsr2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
      engineerVisitNccgsr2.SetSITimerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SITimerID"]);
      engineerVisitNccgsr2.SetFillDiscID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FillDiscID"]);
      engineerVisitNccgsr2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      engineerVisitNccgsr1.Exists = true;
      return engineerVisitNccgsr1;
    }

    public EngineerVisitNCCGSR EngineerVisitNCCGSR_GetForEngineerVisit(
      int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (EngineerVisitNCCGSR_GetForEngineerVisit), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (EngineerVisitNCCGSR) null;
      EngineerVisitNCCGSR engineerVisitNccgsr1 = new EngineerVisitNCCGSR();
      EngineerVisitNCCGSR engineerVisitNccgsr2 = engineerVisitNccgsr1;
      engineerVisitNccgsr2.IgnoreExceptionsOnSetMethods = true;
      engineerVisitNccgsr2.SetEngineerVisitNCCGSRID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitNCCGSRID"]);
      engineerVisitNccgsr2.SetCorrectMaterialsUsedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CorrectMaterialsUsedID"]);
      engineerVisitNccgsr2.SetInstallationPipeWorkCorrectID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InstallationPipeWorkCorrectID"]);
      engineerVisitNccgsr2.SetInstallationSafeToUseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InstallationSafeToUseID"]);
      engineerVisitNccgsr2.SetStrainerFittedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StrainerFittedID"]);
      engineerVisitNccgsr2.SetStrainerInspectedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StrainerInspectedID"]);
      engineerVisitNccgsr2.SetHeatingSystemTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HeatingSystemTypeID"]);
      engineerVisitNccgsr2.SetPartialHeatingID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartialHeatingID"]);
      engineerVisitNccgsr2.SetCylinderTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CylinderTypeID"]);
      engineerVisitNccgsr2.SetJacketID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JacketID"]);
      engineerVisitNccgsr2.SetImmersionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ImmersionID"]);
      engineerVisitNccgsr2.SetRadiators = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Radiators"]);
      engineerVisitNccgsr2.SetCODetectorFittedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CODetectorFittedID"]);
      engineerVisitNccgsr2.SetApproxAgeOfBoiler = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApproxAgeOfBoiler"]);
      engineerVisitNccgsr2.SetCertificateTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CertificateTypeID"]);
      engineerVisitNccgsr2.SetVisualInspectionSatisfactoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisualInspectionSatisfactoryID"]);
      engineerVisitNccgsr2.SetVisualInspectionReason = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisualInspectionReason"]);
      engineerVisitNccgsr2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerVisitID)]);
      engineerVisitNccgsr2.SetSITimerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SITimerID"]);
      engineerVisitNccgsr2.SetFillDiscID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FillDiscID"]);
      engineerVisitNccgsr2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      engineerVisitNccgsr1.Exists = true;
      return engineerVisitNccgsr1;
    }

    public DataView EngineerVisitNCCGSR_Get_Friendly(int engineerVisitNccGsrId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitNCCGSRID", (object) engineerVisitNccGsrId, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitNCCGSR_Get_Friendly), true);
      table.TableName = Enums.TableNames.tblEngineerVisitNCCGSR.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitNCCGSR_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitNCCGSR_GetAll), true);
      table.TableName = Enums.TableNames.tblEngineerVisitNCCGSR.ToString();
      return new DataView(table);
    }

    public EngineerVisitNCCGSR Insert(EngineerVisitNCCGSR oEngineerVisitNCCGSR)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitNCCGSRParametersToCommand(ref oEngineerVisitNCCGSR);
      oEngineerVisitNCCGSR.SetEngineerVisitNCCGSRID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitNCCGSR_Insert", true)));
      oEngineerVisitNCCGSR.Exists = true;
      return oEngineerVisitNCCGSR;
    }

    public void Update(EngineerVisitNCCGSR oEngineerVisitNCCGSR)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitNCCGSRID", (object) oEngineerVisitNCCGSR.EngineerVisitNCCGSRID, true);
      this.AddEngineerVisitNCCGSRParametersToCommand(ref oEngineerVisitNCCGSR);
      this._database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Update", true);
    }

    private void AddEngineerVisitNCCGSRParametersToCommand(
      ref EngineerVisitNCCGSR oEngineerVisitNCCGSR)
    {
      Database database = this._database;
      database.AddParameter("@CorrectMaterialsUsedID", (object) oEngineerVisitNCCGSR.CorrectMaterialsUsedID, true);
      database.AddParameter("@InstallationPipeWorkCorrectID", (object) oEngineerVisitNCCGSR.InstallationPipeWorkCorrectID, true);
      database.AddParameter("@InstallationSafeToUseID", (object) oEngineerVisitNCCGSR.InstallationSafeToUseID, true);
      database.AddParameter("@StrainerFittedID", (object) oEngineerVisitNCCGSR.StrainerFittedID, true);
      database.AddParameter("@StrainerInspectedID", (object) oEngineerVisitNCCGSR.StrainerInspectedID, true);
      database.AddParameter("@HeatingSystemTypeID", (object) oEngineerVisitNCCGSR.HeatingSystemTypeID, true);
      database.AddParameter("@PartialHeatingID", (object) oEngineerVisitNCCGSR.PartialHeatingID, true);
      database.AddParameter("@CylinderTypeID", (object) oEngineerVisitNCCGSR.CylinderTypeID, true);
      database.AddParameter("@JacketID", (object) oEngineerVisitNCCGSR.JacketID, true);
      database.AddParameter("@ImmersionID", (object) oEngineerVisitNCCGSR.ImmersionID, true);
      database.AddParameter("@Radiators", (object) oEngineerVisitNCCGSR.Radiators, true);
      database.AddParameter("@CODetectorFittedID", (object) oEngineerVisitNCCGSR.CODetectorFittedID, true);
      database.AddParameter("@ApproxAgeOfBoiler", (object) oEngineerVisitNCCGSR.ApproxAgeOfBoiler, true);
      database.AddParameter("@CertificateTypeID", (object) oEngineerVisitNCCGSR.CertificateTypeID, true);
      database.AddParameter("@VisualInspectionSatisfactoryID", (object) oEngineerVisitNCCGSR.VisualInspectionSatisfactoryID, true);
      database.AddParameter("@VisualInspectionReason", (object) oEngineerVisitNCCGSR.VisualInspectionReason, true);
      database.AddParameter("@EngineerVisitID", (object) oEngineerVisitNCCGSR.EngineerVisitID, true);
      database.AddParameter("@FillDiscID", (object) oEngineerVisitNCCGSR.FillDiscID, true);
      database.AddParameter("@SITimerID", (object) oEngineerVisitNCCGSR.SITimerID, true);
    }
  }
}
