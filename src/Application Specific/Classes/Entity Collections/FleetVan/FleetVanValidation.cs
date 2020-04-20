using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace FleetVans
    {
        // make sure that contact object is valid
        public class FleetVanValidator : BaseValidator
        {
            public void Validate(FleetVan oFleetVan)
            {

                // make sure that contact object is valid
                if (oFleetVan.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVan.VanTypeID == 0)
                {
                    AddCriticalMessage("Van type missing");
                }

                if (oFleetVan.Registration.Trim().Length == 0)
                {
                    AddCriticalMessage("Registration missing");
                }

                if (oFleetVan.Mileage == 0)
                {
                    AddCriticalMessage("Current mileage missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetVanTypeValidator : BaseValidator
        {
            public void Validate(FleetVanType oFleetVanType)
            {

                // make sure that contact object is valid
                if (oFleetVanType.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVanType.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVanType.Make.Trim().Length == 0)
                {
                    AddCriticalMessage("Make Missing");
                }

                if (oFleetVanType.Model.Trim().Length == 0)
                {
                    AddCriticalMessage("Model Missing");
                }

                if (oFleetVanType.MileageServiceInterval < 0)
                {
                    AddCriticalMessage("The mileage service intervals cannot be less than 0");
                }

                if (oFleetVanType.DateServiceInterval < 0)
                {
                    AddCriticalMessage("The date service intervals cannot be less than 0");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetVanEngineerValidator : BaseValidator
        {
            public void Validate(FleetVanEngineer oFleetVan)
            {

                // make sure that contact object is valid
                if (oFleetVan.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVan.VanID == 0)
                {
                    AddCriticalMessage("Van type missing");
                }

                if (oFleetVan.StartDate == default)
                {
                    AddCriticalMessage("Start date missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetVanMaintenanceValidator : BaseValidator
        {
            public void Validate(FleetVanMaintenance oFleetVan)
            {

                // make sure that contact object is valid
                if (oFleetVan.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVan.LastServiceMileage == 0)
                {
                    AddCriticalMessage("Van last service mileage missing");
                }

                if (oFleetVan.MOTExpiry < DateTime.Now)
                {
                    AddCriticalMessage("MOT has expired");
                }

                if (oFleetVan.RoadTaxExpiry < DateTime.Now)
                {
                    AddCriticalMessage("Road tax has expired");
                }

                if (oFleetVan.Breakdown.Trim().Length == 0)
                {
                    AddCriticalMessage("Please add breakdown company");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetVanFaultValidator : BaseValidator
        {
            public void Validate(FleetVanFault oFleetVan)
            {

                // make sure that contact object is valid
                if (oFleetVan.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVan.FaultTypeID == 0)
                {
                    AddCriticalMessage("Fault type missing");
                }

                if (oFleetVan.Notes.Trim().Length == 0)
                {
                    AddCriticalMessage("Notes are missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetVanContractValidator : BaseValidator
        {
            public void Validate(FleetVanContract oFleetVan)
            {

                // make sure that contact object is valid
                if (oFleetVan.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetVan.VanID == 0)
                {
                    AddCriticalMessage("Van missing");
                }

                if (oFleetVan.Lessor.Trim().Length == 0)
                {
                    AddCriticalMessage("Lessor missing");
                }

                if (oFleetVan.ProcurementMethod == 0)
                {
                    AddCriticalMessage("Procurement method missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
        // make sure that contact object is valid
        public class FleetEquipmentValidator : BaseValidator
        {
            public void Validate(FleetEquipment oFleetEquipment)
            {

                // make sure that contact object is valid
                if (oFleetEquipment.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oFleetEquipment.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oFleetEquipment.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name missing");
                }

                if (oFleetEquipment.Cost == 0)
                {
                    AddCriticalMessage("Cost missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}