// Decompiled with JetBrains decompiler
// Type: FSM.BindableItem
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FSM
{
  public abstract class BindableItem : IEditableObject, IDataErrorInfo
  {
    protected readonly PersistedProperties PersistedProperties;
    protected readonly CalculatedProperties CalculatedProperties;
    private bool _editing;
    protected bool _isNew;

    protected BindableItem()
    {
      this.PersistedProperties = new PersistedProperties(this);
      this.CalculatedProperties = new CalculatedProperties(this);
      this._editing = false;
      this._isNew = true;
    }

    internal event PropertyChangedEventHandler internalPropertyChanged;

    protected internal event PropertyChangedEventHandler propertyChanged;

    public object get_PropertyValue(string name)
    {
      object obj;
      if (this.PersistedProperties.get_Exists(name))
        obj = this.PersistedProperties[name].Value;
      else if (this.CalculatedProperties.get_Exists(name))
        obj = (object) null;
      return obj;
    }

    internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.CalculatedProperties.onChildPropertyChanged(RuntimeHelpers.GetObjectValue(sender), e);
    }

    internal void onInternalPropertyChanged(string name)
    {
      // ISSUE: reference to a compiler-generated field
      PropertyChangedEventHandler propertyChangedEvent = this.internalPropertyChangedEvent;
      if (propertyChangedEvent == null)
        return;
      propertyChangedEvent((object) this, new PropertyChangedEventArgs(name));
    }

    internal void onPropertyChanged(string name)
    {
      // ISSUE: reference to a compiler-generated field
      PropertyChangedEventHandler propertyChangedEvent = this.propertyChangedEvent;
      if (propertyChangedEvent != null)
        propertyChangedEvent((object) this, new PropertyChangedEventArgs(name));
      Type type = this.GetType();
      EventInfo[] events = type.GetEvents();
      int index = 0;
      while (index < events.Length)
      {
        if (events[index].Name.StartsWith(name))
        {
          string name1 = string.Format("On{0}Changed", (object) name);
          MethodInfo method = type.GetMethod(name1);
          if (method != null)
          {
            object[] parameters = new object[1]
            {
              (object) new PropertyChangedEventArgs(name)
            };
            method.Invoke((object) this, parameters);
          }
        }
        checked { ++index; }
      }
    }

    void IEditableObject.BeginEdit()
    {
      if (this._editing)
        return;
      this._editing = true;
      this.PersistedProperties.BeginEdit();
    }

    void IEditableObject.CancelEdit()
    {
      if (this._editing)
        this._editing = false;
      this.PersistedProperties.CancelEdit();
    }

    void IEditableObject.EndEdit()
    {
      this._editing = false;
      this._isNew = false;
    }

    string IDataErrorInfo.Error
    {
      get
      {
        return this.PersistedProperties.Error;
      }
    }

    string IDataErrorInfo.get_ErrorInfoItem(string columnName)
    {
      return string.Empty;
    }
  }
}
