using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Documentss
    {
        // make sure that contact object is valid
        public class DocumentsValidator : BaseValidator
        {
            public void Validate(Documents oDocuments)
            {

                // make sure that contact object is valid
                if (oDocuments.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oDocuments.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oDocuments.TableEnumID == Conversions.ToInteger(Sys.Enums.TableNames.NO_TABLE))
                {
                    AddCriticalMessage("Document Entity Missing");
                }

                if (oDocuments.RecordID == 0)
                {
                    AddCriticalMessage("Document Record ID Missing");
                }

                if (oDocuments.DocumentTypeID == 0)
                {
                    AddCriticalMessage("Document Type Missing");
                }

                if (oDocuments.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Document Reference Missing");
                }

                if (oDocuments.Location.Trim().Length == 0)
                {
                    AddCriticalMessage("Document Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}