
namespace FSM.Entity
{
    namespace EngineerVisitQCs
    {
        public class EngineerVisitQCSQL
        {
            private Sys.Database _database;

            public EngineerVisitQCSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public EngineerVisitQC EngineerVisitQC_Get_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitQC_Get_EngineerVisitID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitQC = new EngineerVisitQC();
                        oEngineerVisitQC.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitQC.SetEngineerVisitQCID = dt.Rows[0]["EngineerVisitQCID"];
                        oEngineerVisitQC.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitQC.SetFTFCode = dt.Rows[0]["FTFCode"];
                        oEngineerVisitQC.SetRecall = dt.Rows[0]["Recall"];
                        oEngineerVisitQC.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oEngineerVisitQC.SetJobTypeIncorrect = dt.Rows[0]["JobTypeIncorrect"];
                        oEngineerVisitQC.SetCustomerDetailsIncorrect = dt.Rows[0]["CustomerDetailsIncorrect"];
                        oEngineerVisitQC.SetSorIncorrect = dt.Rows[0]["SorIncorrect"];
                        oEngineerVisitQC.SetOrderNumberAttached = dt.Rows[0]["OrderNumberAttached"];
                        oEngineerVisitQC.SetPaymentMethodDetailed = dt.Rows[0]["PaymentMethodDetailed"];
                        oEngineerVisitQC.SetLabourTimeMissing = dt.Rows[0]["LabourTimeMissing"];
                        oEngineerVisitQC.SetLGSRMissing = dt.Rows[0]["LGSRMissing"];
                        oEngineerVisitQC.SetPartsConfirmation = dt.Rows[0]["PartsConfirmation"];
                        oEngineerVisitQC.SetApplianceRecorded = dt.Rows[0]["ApplianceRecorded"];
                        oEngineerVisitQC.SetJobUploadInTimeScale = dt.Rows[0]["JobUploadInTimeScale"];
                        oEngineerVisitQC.SetPaymentMethodSelectionIncorrect = dt.Rows[0]["PaymentMethodSelectionIncorrect"];
                        oEngineerVisitQC.SetPaymentCollection = dt.Rows[0]["PaymentCollection"];
                        oEngineerVisitQC.SetEngineerPaymentReceived = dt.Rows[0]["EngineerPaymentReceived"];
                        oEngineerVisitQC.SetPoorJobNotes = dt.Rows[0]["PoorJobNotes"];
                        oEngineerVisitQC.SetDocumentsRecieved = Sys.Helper.MakeBooleanValid(dt.Rows[0]["DocumentsRecieved"]);
                        oEngineerVisitQC.DateDocumentsRecieved = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateDocumentsRecieved"]);
                        if (dt.Columns.Contains("CustomerSigned"))
                            oEngineerVisitQC.SetCustomerSigned = dt.Rows[0]["CustomerSigned"];
                        oEngineerVisitQC.Exists = true;
                        return oEngineerVisitQC;
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

            public EngineerVisitQC Insert(EngineerVisitQC oEngineerVisitQC)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref oEngineerVisitQC);
                oEngineerVisitQC.SetEngineerVisitQCID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitQC_Insert"));
                oEngineerVisitQC.Exists = true;
                return oEngineerVisitQC;
            }

            public void Update(EngineerVisitQC oEngineerVisitQC)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitQCID", oEngineerVisitQC.EngineerVisitQCID, true);
                AddParametersToCommand(ref oEngineerVisitQC);
                _database.ExecuteSP_NO_Return("EngineerVisitQC_Update");
            }

            private void AddParametersToCommand(ref EngineerVisitQC oEngineerVisitQC)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitQC.EngineerVisitID, true);
                    withBlock.AddParameter("@FTFCode", oEngineerVisitQC.FTFCode, true);
                    withBlock.AddParameter("@Recall", oEngineerVisitQC.Recall, true);
                    withBlock.AddParameter("@EngineerID", oEngineerVisitQC.EngineerID, true);
                    withBlock.AddParameter("@JobTypeIncorrect", oEngineerVisitQC.JobTypeIncorrect, true);
                    withBlock.AddParameter("@CustomerDetailsIncorrect", oEngineerVisitQC.CustomerDetailsIncorrect, true);
                    withBlock.AddParameter("@SorIncorrect", oEngineerVisitQC.SorIncorrect, true);
                    withBlock.AddParameter("@OrderNumberAttached", oEngineerVisitQC.OrderNumberAttached, true);
                    withBlock.AddParameter("@PaymentMethodDetailed", oEngineerVisitQC.PaymentMethodDetailed, true);
                    withBlock.AddParameter("@LabourTimeMissing", oEngineerVisitQC.LabourTimeMissing, true);
                    withBlock.AddParameter("@LGSRMissing", oEngineerVisitQC.LGSRMissing, true);
                    withBlock.AddParameter("@PartsConfirmation", oEngineerVisitQC.PartsConfirmation, true);
                    withBlock.AddParameter("@ApplianceRecorded", oEngineerVisitQC.ApplianceRecorded, true);
                    withBlock.AddParameter("@JobUploadInTimeScale", oEngineerVisitQC.JobUploadInTimeScale, true);
                    withBlock.AddParameter("@PaymentMethodSelectionIncorrect", oEngineerVisitQC.PaymentMethodSelectionIncorrect, true);
                    withBlock.AddParameter("@PaymentCollection", oEngineerVisitQC.PaymentCollection, true);
                    withBlock.AddParameter("@EngineerPaymentReceived", oEngineerVisitQC.EngineerPaymentReceived, true);
                    withBlock.AddParameter("@PoorJobNotes", oEngineerVisitQC.PoorJobNotes, true);
                    withBlock.AddParameter("@DocumentsRecieved", oEngineerVisitQC.DocumentsRecieved, true);
                    if (oEngineerVisitQC.DateDocumentsRecieved != default)
                    {
                        withBlock.AddParameter("@DateDocumentsRecieved", oEngineerVisitQC.DateDocumentsRecieved, true);
                    }

                    withBlock.AddParameter("@CustomerSigned", oEngineerVisitQC.CustomerSigned, true);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}