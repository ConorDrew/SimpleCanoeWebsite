// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderConsolidations.OrderConsolidationValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderConsolidations
{
    public class OrderConsolidationValidator : BaseValidator
    {
        public void Validate(OrderConsolidation oOrderConsolidation, bool ForLocation)
        {
            if (oOrderConsolidation.Errors.Count > 0)
            {
                foreach (object error in oOrderConsolidation.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (ForLocation)
            {
                if (oOrderConsolidation.LocationID == 0)
                    this.AddCriticalMessage("Location Missing");
            }
            else if (oOrderConsolidation.SupplierID == 0)
                this.AddCriticalMessage("Supplier Missing");
            if (oOrderConsolidation.ConsolidationRef.Trim().Length == 0)
                this.AddCriticalMessage("Reference Missing");
            else if (!oOrderConsolidation.Exists && App.DB.Order.Order_CheckReference(oOrderConsolidation.ConsolidationRef).Table.Rows.Count > 0)
                this.AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system. Please choose a unique Reference.");
            ArrayList arrayList = new ArrayList();

            if (oOrderConsolidation.HasSupplierPO)
            {
                foreach (DataRow current in App.DB.Order.Order_GetAll("").Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderConsolidationID"], (object)oOrderConsolidation.OrderConsolidationID, false) && Conversions.ToBoolean(current["ReadyToSendToSage"]))
                        arrayList.Add(RuntimeHelpers.GetObjectValue(current["OrderReference"]));
                }
            }
            if ((uint)arrayList.Count > 0U)
            {
                string message = "The following orders have been marked as ready to send to sage so this consolidation cannot be marked with a supplier PO:\r\n\r\n";

                foreach (string str in arrayList)
                {
                    message = message + str + "\r\n";
                }

                this.AddCriticalMessage(message);
            }
            if (oOrderConsolidation.ReadyToSendToSage)
            {
                if (oOrderConsolidation.SupplierInvoiceReference.Trim().Length == 0)
                    this.AddCriticalMessage("Supplier Invoice Reference Missing");
                if (DateTime.Compare(oOrderConsolidation.SupplierInvoiceDate, DateTime.MinValue) == 0)
                    this.AddCriticalMessage("Supplier Invoice Date Missing");
                if (oOrderConsolidation.NominalCode.Trim().Length == 0)
                    this.AddCriticalMessage("Nominal Code Missing");
                if (oOrderConsolidation.DepartmentRef.Trim().Length == 0)
                    this.AddCriticalMessage("Department Reference Missing");
                if (oOrderConsolidation.ExtraRef.Trim().Length == 0)
                    this.AddCriticalMessage("Extra Reference Missing");
                if (oOrderConsolidation.TaxCodeID == 0)
                    this.AddCriticalMessage("Tax Code Missing");
            }
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}