using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractsAlternative
    {
        // make sure that contact object is valid
        public class ContractAlternativeValidator : BaseValidator
        {
            public void Validate(ContractAlternative oContract)
            {
                // make sure that contact object is valid
                if (oContract.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContract.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContract.ContractReference.Trim().Length == 0)
                {
                    AddCriticalMessage("* Contract Referenece is required");
                }
                else
                {
                    // DEAL WITH FORMATTING
                    string fmtStr = "* Contract Reference must be of the format :" + Constants.vbCrLf + " ALPHA/NUMERIC " + Constants.vbCrLf + " NUMERIC/ALPHA " + Constants.vbCrLf + " ALPHA/NUMERIC/ALPHA " + Constants.vbCrLf + " or a standard alphanumeric with no /( forward slash)";

                    if ((Strings.Left(oContract.ContractReference, 1) ?? "") == "/" | (Strings.Right(oContract.ContractReference, 1) ?? "") == "/")
                    {
                        AddCriticalMessage(fmtStr);
                    }
                    else
                    {
                        string[] spArr;
                        spArr = oContract.ContractReference.Split('/');
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
                    }
                }

                if (oContract.ContractStatusID == 0)
                {
                    AddCriticalMessage("Contract Status Missing");
                }

                if (oContract.ContractEndDate <= oContract.ContractStartDate)
                {
                    AddCriticalMessage("Contract End Date must be greater than Contract Start Date");
                }

                if (oContract.InvoiceFrequencyID == 0)
                {
                    AddCriticalMessage("Invoice Frequency Missing");
                }

                if (oContract.InvoiceAddressID == 0)
                {
                    AddCriticalMessage("Invoice Address Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}