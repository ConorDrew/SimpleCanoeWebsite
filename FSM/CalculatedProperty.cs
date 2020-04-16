// Decompiled with JetBrains decompiler
// Type: FSM.CalculatedProperty
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class CalculatedProperty : Property
  {
    internal SimpleStringArray triggers;
    private object _value;

    private virtual BindableItem Parent
    {
      get
      {
        return this._Parent;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        PropertyChangedEventHandler changedEventHandler = new PropertyChangedEventHandler(this.triggerChangedHandler);
        BindableItem parent1 = this._Parent;
        if (parent1 != null)
          parent1.internalPropertyChanged -= changedEventHandler;
        this._Parent = value;
        BindableItem parent2 = this._Parent;
        if (parent2 == null)
          return;
        parent2.internalPropertyChanged += changedEventHandler;
      }
    }

    internal CalculatedProperty(CalculatedProperties container, string name)
      : base((Properties) container, name)
    {
      this.triggers = new SimpleStringArray();
      this.Parent = container.Parent;
    }

    internal CalculatedProperties Container
    {
      get
      {
        return (CalculatedProperties) base.Container;
      }
      set
      {
        this.Container = (Properties) value;
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
        this._value = RuntimeHelpers.GetObjectValue(value);
      }
    }

    internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.triggerChangedHandler(RuntimeHelpers.GetObjectValue(sender), e);
    }

    internal void triggerChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      if (!this.triggers.get_Exists(e.PropertyName))
        return;
      this.Parent.onPropertyChanged(this.name);
    }
  }
}
