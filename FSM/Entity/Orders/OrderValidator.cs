// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.OrderValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.Orders
{
    public class OrderValidator : BaseValidator
    {
        public void Validate(Order oOrder)
        {
            if (oOrder.Errors.Count > 0)
            {
                foreach (object error in oOrder.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oOrder.OrderTypeID <= 0)
                this.AddCriticalMessage("Order Type Missing");
            if (oOrder.OrderReference.Trim().Length <= 0)
                this.AddCriticalMessage("Order Reference Missing");
            if (oOrder.OrderID == 0 && App.DB.Order.Order_CheckReference(oOrder.OrderReference).Table.Rows.Count > 0)
                this.AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.");
            if (oOrder.OrderStatusID > 1 && oOrder.DepartmentRef.Trim().Length == 0)
                this.AddCriticalMessage("Department Reference Missing");
            if (oOrder.ReadyToSendToSage)
            {
                if (oOrder.SupplierInvoiceReference.Trim().Length == 0)
                    this.AddCriticalMessage("Supplier Invoice Reference Missing");
                if (DateTime.Compare(oOrder.SupplierInvoiceDate, DateTime.MinValue) == 0)
                    this.AddCriticalMessage("Supplier Invoice Date Missing");
                if (oOrder.NominalCode.Trim().Length == 0)
                    this.AddCriticalMessage("Nominal Code Missing");
                if (oOrder.DepartmentRef.Trim().Length == 0)
                    this.AddCriticalMessage("Department Reference Missing");
                if (oOrder.ExtraRef.Trim().Length == 0)
                    this.AddCriticalMessage("Extra Reference Missing");
                if (oOrder.TaxCodeID == 0)
                    this.AddCriticalMessage("Tax Code Missing");
            }
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}