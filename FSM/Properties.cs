// Decompiled with JetBrains decompiler
// Type: FSM.Properties
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;

namespace FSM
{
  public class Properties : SimpleObjectArrayByKey
  {
    internal object Parent;

    internal Properties(object parent)
    {
      this.Parent = RuntimeHelpers.GetObjectValue(parent);
    }

    public Property AddNew(string name)
    {
      Property property = new Property(this, name);
      this.AddNew(property);
      return property;
    }

    public object AddNew(Property item)
    {
      this.AddNew(item.name, (object) item);
      object obj;
      return obj;
    }

    public Property this[int Index]
    {
      get
      {
        return (Property) base[Index];
      }
    }

    public Property this[string name]
    {
      get
      {
        return (Property) base[name];
      }
    }
  }
}
