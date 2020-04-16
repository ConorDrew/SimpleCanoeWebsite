// Decompiled with JetBrains decompiler
// Type: FSM.Property
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM
{
  public class Property
  {
    protected internal string name;
    private Properties _container;

    internal Properties Container
    {
      get
      {
        return this._container;
      }
      set
      {
        this._container = value;
      }
    }

    internal Property(Properties container, string name)
    {
      this.Container = container;
      this.name = name;
    }
  }
}
