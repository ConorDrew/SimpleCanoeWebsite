using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitNCCGSRs
    {
        public class EngineerVisitNCCGSR
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitNCCGSR()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            
            

            private int _EngineerVisitNCCGSRID = 0;

            public int EngineerVisitNCCGSRID
            {
                get
                {
                    return _EngineerVisitNCCGSRID;
                }
            }

            public object SetEngineerVisitNCCGSRID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitNCCGSRID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _CorrectMaterialsUsedID = 0;

            public int CorrectMaterialsUsedID
            {
                get
                {
                    return _CorrectMaterialsUsedID;
                }
            }

            public object SetCorrectMaterialsUsedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CorrectMaterialsUsedID", value);
                }
            }

            private int _InstallationPipeWorkCorrectID = 0;

            public int InstallationPipeWorkCorrectID
            {
                get
                {
                    return _InstallationPipeWorkCorrectID;
                }
            }

            public object SetInstallationPipeWorkCorrectID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InstallationPipeWorkCorrectID", value);
                }
            }

            private int _InstallationSafeToUseID = 0;

            public int InstallationSafeToUseID
            {
                get
                {
                    return _InstallationSafeToUseID;
                }
            }

            public object SetInstallationSafeToUseID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InstallationSafeToUseID", value);
                }
            }

            private int _StrainerFittedID = 0;

            public int StrainerFittedID
            {
                get
                {
                    return _StrainerFittedID;
                }
            }

            public object SetStrainerFittedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StrainerFittedID", value);
                }
            }

            private int _StrainerInspectedID = 0;

            public int StrainerInspectedID
            {
                get
                {
                    return _StrainerInspectedID;
                }
            }

            public object SetStrainerInspectedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StrainerInspectedID", value);
                }
            }

            private int _HeatingSystemTypeID = 0;

            public int HeatingSystemTypeID
            {
                get
                {
                    return _HeatingSystemTypeID;
                }
            }

            public object SetHeatingSystemTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HeatingSystemTypeID", value);
                }
            }

            private int _PartialHeatingID = 0;

            public int PartialHeatingID
            {
                get
                {
                    return _PartialHeatingID;
                }
            }

            public object SetPartialHeatingID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartialHeatingID", value);
                }
            }

            private int _CylinderTypeID = 0;

            public int CylinderTypeID
            {
                get
                {
                    return _CylinderTypeID;
                }
            }

            public object SetCylinderTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CylinderTypeID", value);
                }
            }

            private int _JacketID = 0;

            public int JacketID
            {
                get
                {
                    return _JacketID;
                }
            }

            public object SetJacketID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JacketID", value);
                }
            }

            private int _ImmersionID = 0;

            public int ImmersionID
            {
                get
                {
                    return _ImmersionID;
                }
            }

            public object SetImmersionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ImmersionID", value);
                }
            }

            private int _Radiators = 0;

            public int Radiators
            {
                get
                {
                    return _Radiators;
                }
            }

            public object SetRadiators
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Radiators", value);
                }
            }

            private int _CODetectorFittedID = 0;

            public int CODetectorFittedID
            {
                get
                {
                    return _CODetectorFittedID;
                }
            }

            public object SetCODetectorFittedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CODetectorFittedID", value);
                }
            }

            private int _ApproxAgeOfBoiler = 0;

            public int ApproxAgeOfBoiler
            {
                get
                {
                    return _ApproxAgeOfBoiler;
                }
            }

            public object SetApproxAgeOfBoiler
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApproxAgeOfBoiler", value);
                }
            }

            private int _CertificateTypeID = 0;

            public int CertificateTypeID
            {
                get
                {
                    return _CertificateTypeID;
                }
            }

            public object SetCertificateTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CertificateTypeID", value);
                }
            }

            private int _VisualInspectionSatisfactoryID = 0;

            public int VisualInspectionSatisfactoryID
            {
                get
                {
                    return _VisualInspectionSatisfactoryID;
                }
            }

            public object SetVisualInspectionSatisfactoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisualInspectionSatisfactoryID", value);
                }
            }

            private int _SITimerID = 0;

            public int SITimerID
            {
                get
                {
                    return _SITimerID;
                }
            }

            public object SetSITimerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SITimerID", value);
                }
            }

            private int _FillDiscID = 0;

            public int FillDiscID
            {
                get
                {
                    return _FillDiscID;
                }
            }

            public object SetFillDiscID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FillDiscID", value);
                }
            }

            private string _VisualInspectionReason = string.Empty;

            public string VisualInspectionReason
            {
                get
                {
                    return _VisualInspectionReason;
                }
            }

            public object SetVisualInspectionReason
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisualInspectionReason", value);
                }
            }



            
        }
    }
}