// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocationProduct.OrderLocationProductValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FSM.Entity.OrderLocationProduct
{
  public class OrderLocationProductValidator : BaseValidator
  {
    public void Validate(FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct)
    {
      if (oOrderLocationProduct.Errors.Count > 0)
      {
        foreach (object error in oOrderLocationProduct.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oOrderLocationProduct.Quantity <= 0)
      {
        this.AddCriticalMessage("Quantity must be greater than 0");
      }
      else
      {
        int num = App.DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID);
        if (num < oOrderLocationProduct.Quantity)
        {
          if (App.ShowMessage("You have asked for a quantity of " + Conversions.ToString(oOrderLocationProduct.Quantity) + ", " + Conversions.ToString(num) + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            this.AddCriticalMessage("Not enough stock");
        }
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }

    public void Validate(FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct, SqlTransaction trans)
    {
      if (oOrderLocationProduct.Errors.Count > 0)
      {
        foreach (object error in oOrderLocationProduct.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oOrderLocationProduct.Quantity <= 0)
      {
        this.AddCriticalMessage("Quantity must be greater than 0");
      }
      else
      {
        int num = App.DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID, trans);
        if (num < oOrderLocationProduct.Quantity)
        {
          if (App.ShowMessage("You have asked for a quantity of " + Conversions.ToString(oOrderLocationProduct.Quantity) + ", " + Conversions.ToString(num) + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            this.AddCriticalMessage("Not enough stock");
        }
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
