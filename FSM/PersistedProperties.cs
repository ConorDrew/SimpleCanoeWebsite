// Decompiled with JetBrains decompiler
// Type: FSM.PersistedProperties
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;

namespace FSM
{
  public class PersistedProperties : Properties
  {
    internal PersistedProperties(BindableItem parent)
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

    public PersistedProperty AddNew(string name, object value)
    {
      PersistedProperty persistedProperty = new PersistedProperty(this, name, RuntimeHelpers.GetObjectValue(value));
      this.AddNew((Property) persistedProperty);
      return persistedProperty;
    }

    public object AddNew(string name, object value, bool required)
    {
      this.AddNew(name, RuntimeHelpers.GetObjectValue(value));
      this[name].Required = required;
      object obj;
      return obj;
    }

    public PersistedProperty this[int Index]
    {
      get
      {
        return (PersistedProperty) base[Index];
      }
    }

    public PersistedProperty this[string name]
    {
      get
      {
        return (PersistedProperty) base[name];
      }
    }

    internal void BeginEdit()
    {
      int num = checked (this.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this[index].BeginEdit();
        checked { ++index; }
      }
    }

    internal void CancelEdit()
    {
      int num = checked (this.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this[index].CancelEdit();
        checked { ++index; }
      }
    }

    internal string Error
    {
      get
      {
        int num = checked (this.Count - 1);
        int index = 0;
        string error;
        while (index <= num)
        {
          error = this[index].Error;
          if (error.Length <= 0)
            checked { ++index; }
          else
            break;
        }
        return error;
      }
    }
  }
}
