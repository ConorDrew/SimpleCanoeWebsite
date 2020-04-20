using System;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractsOriginal
    {
        // make sure that contact object is valid
        public class ContractOriginalValidator : BaseValidator
        {
            public void Validate(ContractOriginal oContract)
            {

                // make sure that contact object is valid
                if (oContract.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContract.Errors)
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
                        Array spArr;
                        spArr = oContract.ContractReference.Split('/');
                        if (spArr.Length == 1)
                        {
                        }
                        // do nothing
                        else if (spArr.Length == 2)
                        {
                            // MUST BE NUMBER / CHAR 
                            if (Information.IsNumeric(spArr(0)))
                            {
                                if (Information.IsNumeric(spArr(1)))
                                {
                                    AddCriticalMessage(fmtStr);
                                }
                            }
                            // OR 
                            // MUST BE CHAR / NUMBER
                            else if (!Information.IsNumeric(spArr(1)))
                            {
                                AddCriticalMessage(fmtStr);
                            }
                        }
                        else if (spArr.Length == 3)
                        {
                            // MUST BE CHAR / NUMBER /CHAR
                            if (!Information.IsNumeric(spArr(0)))
                            {
                                if (Information.IsNumeric(spArr(1)))
                                {
                                    if (Information.IsNumeric(spArr(2)))
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
                        if (oContract.ContractID == 0)
                        {
                            if (!App.DB.ContractOption3.ContractReference_CheckUnique(oContract.ContractReference, oContract.CustomerID))
                            {
                                AddCriticalMessage("* Contract Reference must be unqiue");
                            }
                        }
                    }
                }

                if (oContract.ContractTypeID == 0)
                {
                    AddCriticalMessage("Contract Type Missing");
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

                if (oContract.ContractStatusID == (int)Sys.Enums.ContractStatus.Cancelled)
                {
                    if (oContract.ReasonID == 0)
                    {
                        AddCriticalMessage("Enter a reason");
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}