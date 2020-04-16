// Decompiled with JetBrains decompiler
// Type: FSM.PersistedProperty
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class PersistedProperty : Property
  {
    private bool _beingConstructed;
    private object _oldValue;
    private object _value;
    internal bool Required;

    internal PersistedProperty(PersistedProperties container, string name, object value)
      : base((Properties) container, name)
    {
      this.Required = true;
      this._beingConstructed = true;
      this.Value = RuntimeHelpers.GetObjectValue(value);
      this._beingConstructed = false;
    }

    internal PersistedProperties Container
    {
      get
      {
        return (PersistedProperties) base.Container;
      }
      set
      {
        this.Container = (Properties) value;
      }
    }

    internal string Error
    {
      get
      {
        if (!this.Required)
          return string.Empty;
        if (this.isString && Conversions.ToString(this.Value).Length == 0)
          return this.name + " required";
        if (this.isNumeric && Operators.ConditionalCompareObjectEqual(this.Value, (object) 0, false))
          return this.name + " required";
        if (this.isDate && DateTime.Equals(Conversions.ToDate(this.Value), DateTime.MinValue))
          return this.name + " required";
        return this.isTimeSpan && object.Equals(RuntimeHelpers.GetObjectValue(this.Value), (object) TimeSpan.Zero) ? this.name + " required" : string.Empty;
      }
    }

    public object Value
    {
      get
      {
        return this._value;
      }
      set
      {
        bool flag1 = true;
        bool flag2 = false;
        if (value == null)
          flag1 = false;
        else if (PersistedProperty.get_isElemental(RuntimeHelpers.GetObjectValue(value)))
        {
          if (PersistedProperty.get_isElemental(RuntimeHelpers.GetObjectValue(this._value)) && Operators.ConditionalCompareObjectEqual(this._value, value, false))
            flag1 = false;
        }
        else if (PersistedProperty.get_isTimeSpan(RuntimeHelpers.GetObjectValue(value)))
        {
          if (PersistedProperty.get_isTimeSpan(RuntimeHelpers.GetObjectValue(this._value)))
          {
            object obj = this._value;
            if ((obj != null ? (TimeSpan) obj : new TimeSpan()).CompareTo(RuntimeHelpers.GetObjectValue(value)) == 0)
              flag1 = false;
          }
        }
        else if (PersistedProperty.get_isBusinessClass(RuntimeHelpers.GetObjectValue(value)))
          flag2 = true;
        if (!flag1)
          return;
        this._value = RuntimeHelpers.GetObjectValue(value);
        if (flag2)
          ((BindableCollection) value).propertyChanged += new PropertyChangedEventHandler(this.Container.Parent.onChildPropertyChanged);
        else if (!this._beingConstructed)
        {
          this.Container.Parent.onPropertyChanged(this.name);
          this.Container.Parent.onInternalPropertyChanged(this.name);
        }
      }
    }

    private static bool get_isBoolean(object myValue)
    {
      return PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(myValue)) && Operators.CompareString(myValue.GetType().Name.ToLower(), "boolean", false) == 0;
    }

    private static bool get_isBusinessClass(object myValue)
    {
      return myValue != null && !PersistedProperty.get_isElemental(RuntimeHelpers.GetObjectValue(myValue)) && !PersistedProperty.get_isTimeSpan(RuntimeHelpers.GetObjectValue(myValue));
    }

    private static bool get_isDate(object myValue)
    {
      if (myValue == null)
        return false;
      string lower = myValue.GetType().Name.ToLower();
      return Operators.CompareString(lower, "datetime", false) == 0 || Operators.CompareString(lower, "date", false) == 0;
    }

    private static bool get_isElemental(object myValue)
    {
      return PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(myValue)) || PersistedProperty.get_isString(RuntimeHelpers.GetObjectValue(myValue)) || PersistedProperty.get_isDate(RuntimeHelpers.GetObjectValue(myValue));
    }

    private static bool get_isIntegral(object myValue)
    {
      if (!PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(myValue)))
        return false;
      string lower = myValue.GetType().Name.ToLower();
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(lower))
      {
        case 64103268:
          if (Operators.CompareString(lower, "int64", false) == 0)
            break;
          goto default;
        case 132346577:
          if (Operators.CompareString(lower, "int16", false) == 0)
            break;
          goto default;
        case 848563180:
          if (Operators.CompareString(lower, "uint32", false) == 0)
            break;
          goto default;
        case 1683620383:
          if (Operators.CompareString(lower, "byte", false) == 0)
            break;
          goto default;
        case 2928590578:
          if (Operators.CompareString(lower, "uint16", false) == 0)
            break;
          goto default;
        case 2929723411:
          if (Operators.CompareString(lower, "uint64", false) == 0)
            break;
          goto default;
        case 3122818005:
          if (Operators.CompareString(lower, "short", false) == 0)
            goto label_15;
          else
            goto default;
        case 3218261061:
          if (Operators.CompareString(lower, "integer", false) == 0)
            goto label_15;
          else
            goto default;
        case 3270303571:
          if (Operators.CompareString(lower, "long", false) == 0)
            goto label_15;
          else
            goto default;
        case 4088464520:
          if (Operators.CompareString(lower, "sbyte", false) == 0)
            break;
          goto default;
        case 4225688255:
          if (Operators.CompareString(lower, "int32", false) == 0)
            break;
          goto default;
        default:
          return false;
      }
      return true;
label_15:
      return true;
    }

    private static bool get_isNonIntegral(object myValue)
    {
      if (!PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(myValue)))
        return false;
      string lower = myValue.GetType().Name.ToLower();
      return Operators.CompareString(lower, "decimal", false) == 0 || Operators.CompareString(lower, "single", false) == 0 || Operators.CompareString(lower, "double", false) == 0;
    }

    private static bool get_isNumeric(object myValue)
    {
      return PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(myValue)) && (PersistedProperty.get_isIntegral(RuntimeHelpers.GetObjectValue(myValue)) || PersistedProperty.get_isNonIntegral(RuntimeHelpers.GetObjectValue(myValue)));
    }

    private static bool get_isPrimitive(object myValue)
    {
      return myValue != null && myValue.GetType().IsPrimitive;
    }

    private static bool get_isString(object myValue)
    {
      if (myValue == null)
        return false;
      string lower = myValue.GetType().Name.ToLower();
      return Operators.CompareString(lower, "string", false) == 0 || Operators.CompareString(lower, "char", false) == 0;
    }

    private static bool get_isTimeSpan(object myValue)
    {
      return myValue != null && Operators.CompareString(myValue.GetType().Name.ToLower(), "timespan", false) == 0;
    }

    private bool isBoolean
    {
      get
      {
        return PersistedProperty.get_isBoolean(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isBusinessClass
    {
      get
      {
        return PersistedProperty.get_isBusinessClass(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isDate
    {
      get
      {
        return PersistedProperty.get_isDate(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isElemental
    {
      get
      {
        return PersistedProperty.get_isElemental(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isIntegral
    {
      get
      {
        return PersistedProperty.get_isIntegral(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isNonIntegral
    {
      get
      {
        return PersistedProperty.get_isNonIntegral(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isNumeric
    {
      get
      {
        return PersistedProperty.get_isNumeric(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isPrimitive
    {
      get
      {
        return PersistedProperty.get_isPrimitive(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isString
    {
      get
      {
        return PersistedProperty.get_isString(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    private bool isTimeSpan
    {
      get
      {
        return PersistedProperty.get_isTimeSpan(RuntimeHelpers.GetObjectValue(this.Value));
      }
    }

    internal void BeginEdit()
    {
      this._oldValue = RuntimeHelpers.GetObjectValue(this._value);
    }

    internal void CancelEdit()
    {
      this.Value = RuntimeHelpers.GetObjectValue(this._oldValue);
    }
  }
}
