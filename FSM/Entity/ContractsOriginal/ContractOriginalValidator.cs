// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractsOriginal.ContractOriginalValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractsOriginal
{
    public class ContractOriginalValidator : BaseValidator
    {
        public void Validate(ContractOriginal oContract)
        {
            if (oContract.Errors.Count > 0)
            {
                foreach (object error in oContract.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oContract.ContractReference.Trim().Length == 0)
            {
                this.AddCriticalMessage("* Contract Referenece is required");
            }
            else
            {
                string message = "* Contract Reference must be of the format :\r\n ALPHA/NUMERIC \r\n NUMERIC/ALPHA \r\n ALPHA/NUMERIC/ALPHA \r\n or a standard alphanumeric with no /( forward slash)";
                if (Operators.CompareString(Strings.Left(oContract.ContractReference, 1), "/", false) == 0 | Operators.CompareString(Strings.Right(oContract.ContractReference, 1), "/", false) == 0)
                {
                    this.AddCriticalMessage(message);
                }
                else
                {
                    Array array = (Array)oContract.ContractReference.Split('/');
                    if (array.Length != 1)
                    {
                        if (array.Length == 2)
                        {
                            if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                            {
                (object) 0
                            }, (string[])null))))
                            {
                                if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                                {
                  (object) 1
                                }, (string[])null))))
                                    this.AddCriticalMessage(message);
                            }
                            else if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                            {
                (object) 1
                            }, (string[])null))))
                                this.AddCriticalMessage(message);
                        }
                        else if (array.Length == 3)
                        {
                            if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                            {
                (object) 0
                            }, (string[])null))))
                            {
                                if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                                {
                  (object) 1
                                }, (string[])null))))
                                {
                                    if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet((object)array, new object[1]
                                    {
                    (object) 2
                                    }, (string[])null))))
                                        this.AddCriticalMessage(message);
                                }
                                else
                                    this.AddCriticalMessage(message);
                            }
                            else
                                this.AddCriticalMessage(message);
                        }
                        else
                            this.AddCriticalMessage(message);
                    }
                    if (oContract.ContractID == 0 && !App.DB.ContractOption3.ContractReference_CheckUnique(oContract.ContractReference, oContract.CustomerID))
                        this.AddCriticalMessage("* Contract Reference must be unqiue");
                }
            }
            if (oContract.ContractTypeID == 0)
                this.AddCriticalMessage("Contract Type Missing");
            if (oContract.ContractStatusID == 0)
                this.AddCriticalMessage("Contract Status Missing");
            if (DateTime.Compare(oContract.ContractEndDate, oContract.ContractStartDate) <= 0)
                this.AddCriticalMessage("Contract End Date must be greater than Contract Start Date");
            if (oContract.InvoiceFrequencyID == 0)
                this.AddCriticalMessage("Invoice Frequency Missing");
            if (oContract.InvoiceAddressID == 0)
                this.AddCriticalMessage("Invoice Address Missing");
            if (oContract.ContractStatusID == 5 && oContract.ReasonID == 0)
                this.AddCriticalMessage("Enter a reason");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}