using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitNCCGSRs
    {
        public class EngineerVisitNCCGSRSQL
        {
            private Sys.Database _database;

            public EngineerVisitNCCGSRSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int EngineerVisitNCCGSRID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitNCCGSRID", EngineerVisitNCCGSRID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Delete");
            }

            public EngineerVisitNCCGSR EngineerVisitNCCGSR_Get(int EngineerVisitNCCGSRID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitNCCGSRID", EngineerVisitNCCGSRID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitNCCGSR = new EngineerVisitNCCGSR();
                        oEngineerVisitNCCGSR.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitNCCGSR.SetEngineerVisitNCCGSRID = dt.Rows[0]["EngineerVisitNCCGSRID"];
                        oEngineerVisitNCCGSR.SetCorrectMaterialsUsedID = dt.Rows[0]["CorrectMaterialsUsedID"];
                        oEngineerVisitNCCGSR.SetInstallationPipeWorkCorrectID = dt.Rows[0]["InstallationPipeWorkCorrectID"];
                        oEngineerVisitNCCGSR.SetInstallationSafeToUseID = dt.Rows[0]["InstallationSafeToUseID"];
                        oEngineerVisitNCCGSR.SetStrainerFittedID = dt.Rows[0]["StrainerFittedID"];
                        oEngineerVisitNCCGSR.SetStrainerInspectedID = dt.Rows[0]["StrainerInspectedID"];
                        oEngineerVisitNCCGSR.SetHeatingSystemTypeID = dt.Rows[0]["HeatingSystemTypeID"];
                        oEngineerVisitNCCGSR.SetPartialHeatingID = dt.Rows[0]["PartialHeatingID"];
                        oEngineerVisitNCCGSR.SetCylinderTypeID = dt.Rows[0]["CylinderTypeID"];
                        oEngineerVisitNCCGSR.SetJacketID = dt.Rows[0]["JacketID"];
                        oEngineerVisitNCCGSR.SetImmersionID = dt.Rows[0]["ImmersionID"];
                        oEngineerVisitNCCGSR.SetRadiators = dt.Rows[0]["Radiators"];
                        oEngineerVisitNCCGSR.SetCODetectorFittedID = dt.Rows[0]["CODetectorFittedID"];
                        oEngineerVisitNCCGSR.SetApproxAgeOfBoiler = dt.Rows[0]["ApproxAgeOfBoiler"];
                        oEngineerVisitNCCGSR.SetCertificateTypeID = dt.Rows[0]["CertificateTypeID"];
                        oEngineerVisitNCCGSR.SetVisualInspectionSatisfactoryID = dt.Rows[0]["VisualInspectionSatisfactoryID"];
                        oEngineerVisitNCCGSR.SetVisualInspectionReason = dt.Rows[0]["VisualInspectionReason"];
                        oEngineerVisitNCCGSR.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitNCCGSR.SetSITimerID = dt.Rows[0]["SITimerID"];
                        oEngineerVisitNCCGSR.SetFillDiscID = dt.Rows[0]["FillDiscID"];
                        oEngineerVisitNCCGSR.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVisitNCCGSR.Exists = true;
                        return oEngineerVisitNCCGSR;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public EngineerVisitNCCGSR EngineerVisitNCCGSR_GetForEngineerVisit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_GetForEngineerVisit");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitNCCGSR = new EngineerVisitNCCGSR();
                        oEngineerVisitNCCGSR.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitNCCGSR.SetEngineerVisitNCCGSRID = dt.Rows[0]["EngineerVisitNCCGSRID"];
                        oEngineerVisitNCCGSR.SetCorrectMaterialsUsedID = dt.Rows[0]["CorrectMaterialsUsedID"];
                        oEngineerVisitNCCGSR.SetInstallationPipeWorkCorrectID = dt.Rows[0]["InstallationPipeWorkCorrectID"];
                        oEngineerVisitNCCGSR.SetInstallationSafeToUseID = dt.Rows[0]["InstallationSafeToUseID"];
                        oEngineerVisitNCCGSR.SetStrainerFittedID = dt.Rows[0]["StrainerFittedID"];
                        oEngineerVisitNCCGSR.SetStrainerInspectedID = dt.Rows[0]["StrainerInspectedID"];
                        oEngineerVisitNCCGSR.SetHeatingSystemTypeID = dt.Rows[0]["HeatingSystemTypeID"];
                        oEngineerVisitNCCGSR.SetPartialHeatingID = dt.Rows[0]["PartialHeatingID"];
                        oEngineerVisitNCCGSR.SetCylinderTypeID = dt.Rows[0]["CylinderTypeID"];
                        oEngineerVisitNCCGSR.SetJacketID = dt.Rows[0]["JacketID"];
                        oEngineerVisitNCCGSR.SetImmersionID = dt.Rows[0]["ImmersionID"];
                        oEngineerVisitNCCGSR.SetRadiators = dt.Rows[0]["Radiators"];
                        oEngineerVisitNCCGSR.SetCODetectorFittedID = dt.Rows[0]["CODetectorFittedID"];
                        oEngineerVisitNCCGSR.SetApproxAgeOfBoiler = dt.Rows[0]["ApproxAgeOfBoiler"];
                        oEngineerVisitNCCGSR.SetCertificateTypeID = dt.Rows[0]["CertificateTypeID"];
                        oEngineerVisitNCCGSR.SetVisualInspectionSatisfactoryID = dt.Rows[0]["VisualInspectionSatisfactoryID"];
                        oEngineerVisitNCCGSR.SetVisualInspectionReason = dt.Rows[0]["VisualInspectionReason"];
                        oEngineerVisitNCCGSR.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitNCCGSR.SetSITimerID = dt.Rows[0]["SITimerID"];
                        oEngineerVisitNCCGSR.SetFillDiscID = dt.Rows[0]["FillDiscID"];
                        oEngineerVisitNCCGSR.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVisitNCCGSR.Exists = true;
                        return oEngineerVisitNCCGSR;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView EngineerVisitNCCGSR_Get_Friendly(int engineerVisitNccGsrId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitNCCGSRID", engineerVisitNccGsrId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_Get_Friendly");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitNCCGSR.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitNCCGSR_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitNCCGSR.ToString();
                return new DataView(dt);
            }

            public EngineerVisitNCCGSR Insert(EngineerVisitNCCGSR oEngineerVisitNCCGSR)
            {
                _database.ClearParameter();
                AddEngineerVisitNCCGSRParametersToCommand(ref oEngineerVisitNCCGSR);
                oEngineerVisitNCCGSR.SetEngineerVisitNCCGSRID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitNCCGSR_Insert"));
                oEngineerVisitNCCGSR.Exists = true;
                return oEngineerVisitNCCGSR;
            }

            public void Update(EngineerVisitNCCGSR oEngineerVisitNCCGSR)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitNCCGSRID", oEngineerVisitNCCGSR.EngineerVisitNCCGSRID, true);
                AddEngineerVisitNCCGSRParametersToCommand(ref oEngineerVisitNCCGSR);
                _database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Update");
            }

            private void AddEngineerVisitNCCGSRParametersToCommand(ref EngineerVisitNCCGSR oEngineerVisitNCCGSR)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CorrectMaterialsUsedID", oEngineerVisitNCCGSR.CorrectMaterialsUsedID, true);
                    withBlock.AddParameter("@InstallationPipeWorkCorrectID", oEngineerVisitNCCGSR.InstallationPipeWorkCorrectID, true);
                    withBlock.AddParameter("@InstallationSafeToUseID", oEngineerVisitNCCGSR.InstallationSafeToUseID, true);
                    withBlock.AddParameter("@StrainerFittedID", oEngineerVisitNCCGSR.StrainerFittedID, true);
                    withBlock.AddParameter("@StrainerInspectedID", oEngineerVisitNCCGSR.StrainerInspectedID, true);
                    withBlock.AddParameter("@HeatingSystemTypeID", oEngineerVisitNCCGSR.HeatingSystemTypeID, true);
                    withBlock.AddParameter("@PartialHeatingID", oEngineerVisitNCCGSR.PartialHeatingID, true);
                    withBlock.AddParameter("@CylinderTypeID", oEngineerVisitNCCGSR.CylinderTypeID, true);
                    withBlock.AddParameter("@JacketID", oEngineerVisitNCCGSR.JacketID, true);
                    withBlock.AddParameter("@ImmersionID", oEngineerVisitNCCGSR.ImmersionID, true);
                    withBlock.AddParameter("@Radiators", oEngineerVisitNCCGSR.Radiators, true);
                    withBlock.AddParameter("@CODetectorFittedID", oEngineerVisitNCCGSR.CODetectorFittedID, true);
                    withBlock.AddParameter("@ApproxAgeOfBoiler", oEngineerVisitNCCGSR.ApproxAgeOfBoiler, true);
                    withBlock.AddParameter("@CertificateTypeID", oEngineerVisitNCCGSR.CertificateTypeID, true);
                    withBlock.AddParameter("@VisualInspectionSatisfactoryID", oEngineerVisitNCCGSR.VisualInspectionSatisfactoryID, true);
                    withBlock.AddParameter("@VisualInspectionReason", oEngineerVisitNCCGSR.VisualInspectionReason, true);
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitNCCGSR.EngineerVisitID, true);
                    withBlock.AddParameter("@FillDiscID", oEngineerVisitNCCGSR.FillDiscID, true);
                    withBlock.AddParameter("@SITimerID", oEngineerVisitNCCGSR.SITimerID, true);
                }
            }

            
        }
    }
}