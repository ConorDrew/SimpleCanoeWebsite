using System;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3s
    {
        // make sure that contact object is valid
        public class ContractOption3Validator : BaseValidator
        {
            public void Validate(ContractOption3 oContractOption3)
            {
                // make sure that contact object is valid
                if (oContractOption3.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractOption3.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContractOption3.ContractReference.Trim().Length == 0)
                {
                    AddCriticalMessage("* Contract Referenece is required");
                }
                else
                {
                    // DEAL WITH FORMATTING
                    string fmtStr = "* Contract Reference must be of the format :" + Constants.vbCrLf + " ALPHA/NUMERIC " + Constants.vbCrLf + " NUMERIC/ALPHA " + Constants.vbCrLf + " ALPHA/NUMERIC/ALPHA " + Constants.vbCrLf + " or a standard alphanumeric with no /( forward slash)";

                    if ((Strings.Left(oContractOption3.ContractReference, 1) ?? "") == "/" | (Strings.Right(oContractOption3.ContractReference, 1) ?? "") == "/")
                    {
                        AddCriticalMessage(fmtStr);
                    }
                    else
                    {
                        String[] spArr = oContractOption3.ContractReference.Split('/');
                        if (spArr.Length == 1)
                        {
                        }
                        // do nothing
                        else if (spArr.Length == 2)
                        {
                            // MUST BE NUMBER / CHAR
                            if (Information.IsNumeric(spArr[0]))
                            {
                                if (Information.IsNumeric(spArr[1]))
                                {
                                    AddCriticalMessage(fmtStr);
                                }
                            }
                            // OR
                            // MUST BE CHAR / NUMBER
                            else if (!Information.IsNumeric(spArr[1]))
                            {
                                AddCriticalMessage(fmtStr);
                            }
                        }
                        else if (spArr.Length == 3)
                        {
                            // MUST BE CHAR / NUMBER /CHAR
                            if (!Information.IsNumeric(spArr[0]))
                            {
                                if (Information.IsNumeric(spArr[1]))
                                {
                                    if (Information.IsNumeric(spArr[2]))
                                    {
                                        AddCriticalMessage(fmtStr);
                                    }
                                }
                                else
                                {
                                    AddCriticalMessage(fmtStr);
                                }
                            }
                            else
                            {
                                AddCriticalMessage(fmtStr);
                            }
                        }
                        else
                        {
                            // T0O MANY SPLITS
                            AddCriticalMessage(fmtStr);
                        }

                        // IS REF UNIQUE?
                        if (oContractOption3.ContractID == 0)
                        {
                            if (!App.DB.ContractOption3.ContractReference_CheckUnique(oContractOption3.ContractReference, oContractOption3.CustomerID))
                            {
                                AddCriticalMessage("* Contract Reference must be unqiue");
                            }
                        }
                    }
                }

                if (Strings.InStr(oContractOption3.ContractReference, "-") > 0)
                {
                    AddCriticalMessage("* Contract Referenece cannot contain '-'.");
                }

                if (oContractOption3.ContractStatusID == 0)
                {
                    AddCriticalMessage("* Contract Status is required");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}