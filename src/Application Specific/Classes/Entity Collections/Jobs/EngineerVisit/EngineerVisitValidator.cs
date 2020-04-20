using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisits
    {
        // make sure that contact object is valid
        public class EngineerVisitValidator : BaseValidator
        {
            public void Validate(EngineerVisit oEngineerVisit, int CustomerID)
            {

                // make sure that contact object is valid
                if (oEngineerVisit.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisit.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                var switchExpr = oEngineerVisit.OutcomeEnumID;
                switch (switchExpr)
                {
                    case Conversions.ToInteger(Sys.Enums.EngineerVisitOutcomes.NOT_SET):
                        {
                            AddCriticalMessage("Outcome Missing");
                            break;
                        }
                    // OK
                    case Conversions.ToInteger(Sys.Enums.EngineerVisitOutcomes.Complete):
                        {
                            break;
                        }

                    default:
                        {
                            if (oEngineerVisit.OutcomeDetails.Trim().Length == 0)
                            {
                                AddCriticalMessage("Outcome Details Missing");
                            }

                            break;
                        }
                }

                // If oEngineerVisit.VisitLocked And oEngineerVisit.CostsTo = String.Empty Then
                // Me.AddCriticalMessage("Costs To Details Missing")
                // End If
                // If oEngineerVisit.CustomerName.Trim.Length = 0 Then
                // Me.AddCriticalMessage("Customer Name Missing")
                // End If

                // If CustomerID = Entity.Sys.Enums.Customer.NCC Then
                // If oEngineerVisit.PropertyRented = 0 Then
                // Me.AddCriticalMessage("Property Rented Missing")
                // End If

                // If oEngineerVisit.GasInstallationTightnessTestID = 0 Then
                // Me.AddCriticalMessage("Gas Installation Tightness Test Missing")
                // End If

                // If oEngineerVisit.EmergencyControlAccessibleID = 0 Then
                // Me.AddCriticalMessage("Emergency Control Accessible Missing")
                // End If

                // If oEngineerVisit.BondingID = 0 Then
                // Me.AddCriticalMessage("Bonding Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.CorrectMaterialsUsedID = 0 Then
                // Me.AddCriticalMessage("Correct Materials Used Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.InstallationPipeWorkCorrectID = 0 Then
                // Me.AddCriticalMessage("Installation Pipe Work Correct Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.InstallationSafeToUseID = 0 Then
                // Me.AddCriticalMessage("Installation Safe To Use Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.StrainerFittedID = 0 Then
                // Me.AddCriticalMessage("Strainer Fitted Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.StrainerInspectedID = 0 Then
                // Me.AddCriticalMessage("Strainer Inspected Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.HeatingSystemTypeID = 0 Then
                // Me.AddCriticalMessage("Heating System Type Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.CylinderTypeID = 0 Then
                // Me.AddCriticalMessage("Cylinder Type Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.JacketID = 0 Then
                // Me.AddCriticalMessage("Jacket Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.ImmersionID = 0 Then
                // Me.AddCriticalMessage("Immersion Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.CODetectorFittedID = 0 Then
                // Me.AddCriticalMessage("CO Detector Fitted Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.CertificateTypeID = 0 Then
                // Me.AddCriticalMessage("Certificate Type Missing")
                // End If

                // If oEngineerVisit.EngineerVisitNCCGSR.VisualInspectionSatisfactoryID = 0 Then
                // Me.AddCriticalMessage("Visual Inspection Satisfactory Missing")
                // End If

                // End If

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}