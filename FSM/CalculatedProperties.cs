// Decompiled with JetBrains decompiler
// Type: FSM.CalculatedProperties
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class CalculatedProperties : Properties
  {
    internal CalculatedProperties(BindableItem parent)
      : base((object) parent)
    {
    }

    internal BindableItem Parent
    {
      get
      {
        return (BindableItem) this.Parent;
      }
      set
      {
        this.Parent = (object) value;
      }
    }

    public CalculatedProperty AddNew(string name)
    {
      CalculatedProperty calculatedProperty = new CalculatedProperty(this, name);
      this.AddNew((Property) calculatedProperty);
      return calculatedProperty;
    }

    public CalculatedProperty AddNew(string name, string triggers)
    {
      string str1 = triggers;
      CalculatedProperty calculatedProperty1 = this.AddNew(name);
      int length;
      do
      {
        length = str1.IndexOf(",");
        string str2;
        if (length > 0)
        {
          str2 = str1.Substring(0, length);
          str1 = str1.Substring(checked (length + 1));
        }
        else
          str2 = str1;
        calculatedProperty1.triggers.AddNew(str2);
      }
      while (length != -1);
      CalculatedProperty calculatedProperty2;
      return calculatedProperty2;
    }

    public CalculatedProperty this[int Index]
    {
      get
      {
        return (CalculatedProperty) base[Index];
      }
    }

    public CalculatedProperty this[string name]
    {
      get
      {
        return (CalculatedProperty) base[name];
      }
    }

    internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      int num = checked (this.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this[index].onChildPropertyChanged(RuntimeHelpers.GetObjectValue(sender), e);
        checked { ++index; }
      }
    }
  }
}
