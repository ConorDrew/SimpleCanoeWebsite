// Decompiled with JetBrains decompiler
// Type: FSM.CollectionProperty
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.ComponentModel;

namespace FSM
{
  public class CollectionProperty : Property
  {
    public bool DoListChangedOnPropertyChange;
    public bool DoPropertyChangeOnListChanged;
    internal SimpleStringArray childTriggers;

    internal CollectionProperty(CollectionProperties container, string name)
      : base((Properties) container, name)
    {
      this.DoListChangedOnPropertyChange = true;
      this.DoPropertyChangeOnListChanged = true;
      this.childTriggers = new SimpleStringArray();
    }

    internal CollectionProperties Container
    {
      get
      {
        return (CollectionProperties) base.Container;
      }
      set
      {
        this.Container = (Properties) value;
      }
    }

    internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      BindableCollection parent = this.Container.Parent;
      if (!this.childTriggers.get_Exists(e.PropertyName))
        return;
      parent.onPropertyChanged(e.PropertyName);
      if (this.DoListChangedOnPropertyChange)
        parent.onInternalListChanged(ListChangedType.ItemChanged, parent.IndexOf((BindableChildItem) sender));
    }

    internal void onListChanged()
    {
      BindableCollection parent = this.Container.Parent;
      if (!this.DoPropertyChangeOnListChanged)
        return;
      parent.onPropertyChanged(this.name);
    }
  }
}
