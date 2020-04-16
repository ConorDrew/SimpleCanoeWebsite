// Decompiled with JetBrains decompiler
// Type: FSM.CollectionProperties
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class CollectionProperties : Properties
  {
    internal CollectionProperties(BindableCollection parent)
      : base((object) parent)
    {
    }

    internal BindableCollection Parent
    {
      get
      {
        return (BindableCollection) this.Parent;
      }
      set
      {
        this.Parent = (object) value;
      }
    }

    public CollectionProperty AddNew(string name)
    {
      CollectionProperty collectionProperty = new CollectionProperty(this, name);
      this.AddNew((Property) collectionProperty);
      return collectionProperty;
    }

    public CollectionProperty AddNew(string name, string childTriggers)
    {
      string str1 = childTriggers;
      CollectionProperty collectionProperty1 = this.AddNew(name);
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
        collectionProperty1.childTriggers.AddNew(str2);
      }
      while (length != -1);
      CollectionProperty collectionProperty2;
      return collectionProperty2;
    }

    public CollectionProperty this[int Index]
    {
      get
      {
        return (CollectionProperty) base[Index];
      }
    }

    public CollectionProperty this[string name]
    {
      get
      {
        return (CollectionProperty) base[name];
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

    internal void onListChanged()
    {
      int num = checked (this.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this[index].onListChanged();
        checked { ++index; }
      }
    }
  }
}
