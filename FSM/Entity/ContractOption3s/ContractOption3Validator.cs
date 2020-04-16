// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3s.ContractOption3Validator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3s
{
    public class ContractOption3Validator : BaseValidator
    {
        public void Validate(ContractOption3 oContractOption3)
        {
            if (oContractOption3.Errors.Count > 0)
            {
                foreach (object error in oContractOption3.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oContractOption3.ContractReference.Trim().Length == 0)
            {
                this.AddCriticalMessage("* Contract Referenece is required");
            }
            else
            {
                string message = "* Contract Reference must be of the format :\r\n ALPHA/NUMERIC \r\n NUMERIC/ALPHA \r\n ALPHA/NUMERIC/ALPHA \r\n or a standard alphanumeric with no /( forward slash)";
                if (Operators.CompareString(Strings.Left(oContractOption3.ContractReference, 1), "/", false) == 0 | Operators.CompareString(Strings.Right(oContractOption3.ContractReference, 1), "/", false) == 0)
                {
                    this.AddCriticalMessage(message);
                }
                else
                {
                    Array array = (Array)oContractOption3.ContractReference.Split('/');
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
                    if (oContractOption3.ContractID == 0 && !App.DB.ContractOption3.ContractReference_CheckUnique(oContractOption3.ContractReference, oContractOption3.CustomerID))
                        this.AddCriticalMessage("* Contract Reference must be unqiue");
                }
            }
            if (Strings.InStr(oContractOption3.ContractReference, "-", CompareMethod.Binary) > 0)
                this.AddCriticalMessage("* Contract Referenece cannot contain '-'.");
            if (oContractOption3.ContractStatusID == 0)
                this.AddCriticalMessage("* Contract Status is required");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}