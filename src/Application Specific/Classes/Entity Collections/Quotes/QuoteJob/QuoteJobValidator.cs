using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteJobs
    {
        // make sure that contact object is valid
        public class QuoteJobValidator : BaseValidator
        {
            public void Validate(QuoteJob qJob, DataView JobItems)
            {
                // make sure that contact object is valid
                if (qJob.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in qJob.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (qJob.SiteID == 0)
                {
                    AddCriticalMessage("* Property not set");
                }

                if (qJob.Reference.Trim().Length == 0)
                {
                    AddCriticalMessage("*Reference Missing");
                }

                if (!qJob.Exists)
                {
                    qJob.SetStatusEnumID = Conversions.ToInteger(Sys.Enums.QuoteContractStatus.Generated);
                }
                else if (qJob.StatusEnumID == 0)
                {
                    AddCriticalMessage("*Status Missing");
                }

                // If Not IsNumeric(qJob.MileageRate) Then
                // Me.AddCriticalMessage("*Mileage Rate must be Numeric")
                // End If

                // If Not IsNumeric(qJob.EstimatedMileage) Then
                // Me.AddCriticalMessage("*Estimated Mileage must be Numeric")
                // End If

                if (!Information.IsNumeric(qJob.PartsAndProductsMarkup))
                {
                    AddCriticalMessage("*Parts And Products Markup must be Numeric");
                }

                if (!Information.IsNumeric(qJob.ScheduleOfRatesMarkup))
                {
                    AddCriticalMessage("*Schedule Of Rates Markup must be Numeric");
                }

                // Dim jobOfWorkIndex As Integer = 1
                // For Each jobOfWork As Entity.QuoteJobOfWorks.QuoteJobOfWork In qJob.QuoteJobOfWorks
                // Dim jobOfItemIndex As Integer = 1
                // For Each jobItem As Entity.QuoteJobItems.QuoteJobItem In jobOfWork.QuoteJobItems
                // If jobItem.Summary.Trim.Length = 0 Then
                // Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Job Item #" & jobOfItemIndex & " Summary Missing")
                // End If
                // jobOfItemIndex += 1
                // Next

                // Dim engineerVisitIndex As Integer = 1
                // For Each engineerVisit As Entity.QuoteEngineerVisits.QuoteEngineerVisit In jobOfWork.QuoteEngineerVisits
                // If engineerVisit.StatusEnumID = 0 Then
                // Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Status Not Selected")
                // End If
                // If engineerVisit.NotesToEngineer.Trim.Length = 0 Then
                // Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Notes To Engineer Missing")
                // End If
                // engineerVisitIndex += 1
                // Next

                // jobOfWorkIndex += 1
                // Next

                // If JobItems.Table.Rows.Count = 0 Then
                // Me.AddCriticalMessage("*Quote Items Missing")
                // End If

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}