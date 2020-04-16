// Decompiled with JetBrains decompiler
// Type: FSM.Combo
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class Combo
  {
    private string _description;
    private string _value;
    private object _additionalItem;

    public string Description
    {
      get
      {
        return this._description;
      }
      set
      {
        this._description = value;
      }
    }

    public string Value
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = value;
      }
    }

    public object AdditionalItem
    {
      get
      {
        return this._additionalItem;
      }
      set
      {
        this._additionalItem = RuntimeHelpers.GetObjectValue(value);
      }
    }

    public Combo(string descriptionIn, string valueIn, object additionalItemIn = null)
    {
      this._description = "";
      this._value = "";
      this._additionalItem = (object) null;
      this.Description = descriptionIn;
      this.Value = valueIn;
      this.AdditionalItem = RuntimeHelpers.GetObjectValue(additionalItemIn);
    }

    public static void SetSelectedComboItem_By_Value(ref ComboBox combo, string value)
    {
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = combo.Items.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((Combo) enumerator.Current).Value, value, false) == 0)
          {
            combo.SelectedIndex = num;
            break;
          }
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public static void SetSelectedComboItem_By_Description(ref ComboBox combo, string description)
    {
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = combo.Items.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((Combo) enumerator.Current).Description, description, false) == 0)
          {
            combo.SelectedIndex = num;
            break;
          }
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public static string get_GetSelectedItemValue(ComboBox comboIn)
    {
      string str;
      try
      {
        str = ((Combo) comboIn.SelectedItem).Value;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str = Conversions.ToString(0);
        ProjectData.ClearProjectError();
      }
      return str;
    }

    public static string get_GetSelectedItemDescription(ComboBox comboIn)
    {
      string str;
      try
      {
        str = !Combo.get_IsAnInitialItem(comboIn) ? ((Combo) comboIn.SelectedItem).Description : "";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str = "";
        ProjectData.ClearProjectError();
      }
      return str;
    }

    private static bool get_IsAnInitialItem(ComboBox comboIn)
    {
      bool flag;
      try
      {
        flag = ((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- Please Select --".ToLower()) || (((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- Add New --".ToLower()) || (((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- Other --".ToLower()) || (((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- No Filter --".ToLower()) || (((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- Off The Road --".ToLower()) || (((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("-- Not Applicable --".ToLower()) || ((Combo) comboIn.SelectedItem).Description.ToLower().StartsWith("--".ToLower()))))));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = true;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public static void SetUpCombo(
      ref ComboBox c,
      DataTable DT,
      string ValueMember,
      string DisplayMember,
      Enums.ComboValues InitialItemText = Enums.ComboValues.None)
    {
      c.Items.Clear();
      if ((uint) InitialItemText > 0U)
      {
        switch (InitialItemText)
        {
          case Enums.ComboValues.Please_Select:
            c.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Add_New:
            c.Items.Add((object) new Combo("-- Add New --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Other:
            c.Items.Add((object) new Combo("-- Other --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.No_Filter:
            c.Items.Add((object) new Combo("-- No Filter --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Off_The_Road:
            c.Items.Add((object) new Combo("-- Off The Road --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Not_Applicable:
            c.Items.Add((object) new Combo("-- Not Applicable --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Dashes:
            c.Items.Add((object) new Combo("--", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.All_Appointments:
            c.Items.Add((object) new Combo("-- All Appointments --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Please_Select_Negative:
            c.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(-1), (object) null));
            break;
        }
      }
      IEnumerator enumerator;
      if (DT != null)
      {
        try
        {
          enumerator = DT.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            c.Items.Add((object) new Combo(Combo.SetComboDeletedPostfix(current, DisplayMember), Conversions.ToString(current[ValueMember]), (object) null));
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      c.DisplayMember = "Description";
      c.ValueMember = "Value";
      if (InitialItemText == Enums.ComboValues.Please_Select_Negative)
        Combo.SetSelectedComboItem_By_Value(ref c, "-1");
      else
        Combo.SetSelectedComboItem_By_Value(ref c, "0");
    }

    public static void SetUpComboQual(
      ref ComboBox c,
      DataTable DT,
      string ValueMember,
      string DisplayMember,
      Enums.ComboValues InitialItemText = Enums.ComboValues.None)
    {
      c.Items.Clear();
      if ((uint) InitialItemText > 0U)
      {
        switch (InitialItemText)
        {
          case Enums.ComboValues.Please_Select:
            c.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Add_New:
            c.Items.Add((object) new Combo("-- Add New --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Other:
            c.Items.Add((object) new Combo("-- Other --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.No_Filter:
            c.Items.Add((object) new Combo("-- No Filter --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Off_The_Road:
            c.Items.Add((object) new Combo("-- Off The Road --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Not_Applicable:
            c.Items.Add((object) new Combo("-- Not Applicable --", Conversions.ToString(0), (object) null));
            break;
          case Enums.ComboValues.Dashes:
            c.Items.Add((object) new Combo("--", Conversions.ToString(0), (object) null));
            break;
        }
      }
      IEnumerator enumerator;
      if (DT != null)
      {
        try
        {
          enumerator = DT.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            c.Items.Add((object) new Combo(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["Description"], (object) " * "), (object) Combo.SetComboDeletedPostfix(current, DisplayMember))), Conversions.ToString(current[ValueMember]), (object) null));
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      c.DisplayMember = "Description";
      c.ValueMember = "Value";
      Combo.SetSelectedComboItem_By_Value(ref c, "0");
    }

    private static string SetComboDeletedPostfix(DataRow DR, string DisplayMember)
    {
      string str;
      try
      {
        str = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(DR["Deleted"])) ? Conversions.ToString(DR[DisplayMember]) : Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(DR[DisplayMember], (object) App.TheSystem.DeletedPostfix));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str = Conversions.ToString(DR[DisplayMember]);
        ProjectData.ClearProjectError();
      }
      return str;
    }
  }
}
