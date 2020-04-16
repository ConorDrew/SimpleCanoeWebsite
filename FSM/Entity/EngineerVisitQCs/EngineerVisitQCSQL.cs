// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitQCs.EngineerVisitQCSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitQCs
{
    public class EngineerVisitQCSQL
    {
        private Database _database;

        public EngineerVisitQCSQL(Database database)
        {
            this._database = database;
        }

        public EngineerVisitQC EngineerVisitQC_Get_EngineerVisitID(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitQC_Get_EngineerVisitID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitQC)null;
            EngineerVisitQC engineerVisitQc1 = new EngineerVisitQC();
            EngineerVisitQC engineerVisitQc2 = engineerVisitQc1;
            engineerVisitQc2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitQc2.SetEngineerVisitQCID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitQCID"]);
            engineerVisitQc2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVisitID)]);
            engineerVisitQc2.SetFTFCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FTFCode"]);
            engineerVisitQc2.SetRecall = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Recall"]);
            engineerVisitQc2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
            engineerVisitQc2.SetJobTypeIncorrect = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeIncorrect"]);
            engineerVisitQc2.SetCustomerDetailsIncorrect = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerDetailsIncorrect"]);
            engineerVisitQc2.SetSorIncorrect = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SorIncorrect"]);
            engineerVisitQc2.SetOrderNumberAttached = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderNumberAttached"]);
            engineerVisitQc2.SetPaymentMethodDetailed = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaymentMethodDetailed"]);
            engineerVisitQc2.SetLabourTimeMissing = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LabourTimeMissing"]);
            engineerVisitQc2.SetLGSRMissing = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LGSRMissing"]);
            engineerVisitQc2.SetPartsConfirmation = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsConfirmation"]);
            engineerVisitQc2.SetApplianceRecorded = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApplianceRecorded"]);
            engineerVisitQc2.SetJobUploadInTimeScale = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobUploadInTimeScale"]);
            engineerVisitQc2.SetPaymentMethodSelectionIncorrect = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaymentMethodSelectionIncorrect"]);
            engineerVisitQc2.SetPaymentCollection = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaymentCollection"]);
            engineerVisitQc2.SetEngineerPaymentReceived = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerPaymentReceived"]);
            engineerVisitQc2.SetPoorJobNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PoorJobNotes"]);
            engineerVisitQc2.SetDocumentsRecieved = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DocumentsRecieved"]));
            engineerVisitQc2.DateDocumentsRecieved = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateDocumentsRecieved"]));
            if (dataTable.Columns.Contains("CustomerSigned"))
                engineerVisitQc2.SetCustomerSigned = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerSigned"]);
            engineerVisitQc1.Exists = true;
            return engineerVisitQc1;
        }

        public EngineerVisitQC Insert(EngineerVisitQC oEngineerVisitQC)
        {
            this._database.ClearParameter();
            this.AddParametersToCommand(ref oEngineerVisitQC);
            oEngineerVisitQC.SetEngineerVisitQCID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitQC_Insert", true)));
            oEngineerVisitQC.Exists = true;
            return oEngineerVisitQC;
        }

        public void Update(EngineerVisitQC oEngineerVisitQC)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitQCID", (object)oEngineerVisitQC.EngineerVisitQCID, true);
            this.AddParametersToCommand(ref oEngineerVisitQC);
            this._database.ExecuteSP_NO_Return("EngineerVisitQC_Update", true);
        }

        private void AddParametersToCommand(ref EngineerVisitQC oEngineerVisitQC)
        {
            Database database = this._database;
            database.AddParameter("@EngineerVisitID", (object)oEngineerVisitQC.EngineerVisitID, true);
            database.AddParameter("@FTFCode", (object)oEngineerVisitQC.FTFCode, true);
            database.AddParameter("@Recall", (object)oEngineerVisitQC.Recall, true);
            database.AddParameter("@EngineerID", (object)oEngineerVisitQC.EngineerID, true);
            database.AddParameter("@JobTypeIncorrect", (object)oEngineerVisitQC.JobTypeIncorrect, true);
            database.AddParameter("@CustomerDetailsIncorrect", (object)oEngineerVisitQC.CustomerDetailsIncorrect, true);
            database.AddParameter("@SorIncorrect", (object)oEngineerVisitQC.SorIncorrect, true);
            database.AddParameter("@OrderNumberAttached", (object)oEngineerVisitQC.OrderNumberAttached, true);
            database.AddParameter("@PaymentMethodDetailed", (object)oEngineerVisitQC.PaymentMethodDetailed, true);
            database.AddParameter("@LabourTimeMissing", (object)oEngineerVisitQC.LabourTimeMissing, true);
            database.AddParameter("@LGSRMissing", (object)oEngineerVisitQC.LGSRMissing, true);
            database.AddParameter("@PartsConfirmation", (object)oEngineerVisitQC.PartsConfirmation, true);
            database.AddParameter("@ApplianceRecorded", (object)oEngineerVisitQC.ApplianceRecorded, true);
            database.AddParameter("@JobUploadInTimeScale", (object)oEngineerVisitQC.JobUploadInTimeScale, true);
            database.AddParameter("@PaymentMethodSelectionIncorrect", (object)oEngineerVisitQC.PaymentMethodSelectionIncorrect, true);
            database.AddParameter("@PaymentCollection", (object)oEngineerVisitQC.PaymentCollection, true);
            database.AddParameter("@EngineerPaymentReceived", (object)oEngineerVisitQC.EngineerPaymentReceived, true);
            database.AddParameter("@PoorJobNotes", (object)oEngineerVisitQC.PoorJobNotes, true);
            database.AddParameter("@DocumentsRecieved", (object)oEngineerVisitQC.DocumentsRecieved, true);
            if ((uint)DateTime.Compare(oEngineerVisitQC.DateDocumentsRecieved, DateTime.MinValue) > 0U)
                database.AddParameter("@DateDocumentsRecieved", (object)oEngineerVisitQC.DateDocumentsRecieved, true);
            database.AddParameter("@CustomerSigned", (object)oEngineerVisitQC.CustomerSigned, true);
        }
    }
}