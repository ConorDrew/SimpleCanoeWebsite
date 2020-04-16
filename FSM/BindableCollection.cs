// Decompiled with JetBrains decompiler
// Type: FSM.BindableCollection
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
  public abstract class BindableCollection : CollectionBase, IBindingList
  {
    private bool _allowEdit;
    private bool _allowNew;
    private bool _allowRemove;
    private bool _isSorted;
    private ListSortDirection _sortDirection;
    private bool _supportsChangeNotification;
    private bool _supportsSearching;
    private bool _supportsSorting;
    protected readonly CollectionProperties Properties;

    protected BindableCollection()
    {
      this._allowEdit = true;
      this._allowNew = true;
      this._allowRemove = true;
      this._isSorted = false;
      this._supportsChangeNotification = true;
      this._supportsSearching = false;
      this._supportsSorting = false;
      this.Properties = new CollectionProperties(this);
    }

    protected internal event PropertyChangedEventHandler propertyChanged;

    public void Add(BindableChildItem item)
    {
      this.List.Add((object) item);
    }

    internal int IndexOf(BindableChildItem item)
    {
      return this.List.IndexOf((object) item);
    }

    public void Remove(BindableChildItem item)
    {
      this.List.Remove((object) item);
    }

    public BindableChildItem this[int index]
    {
      get
      {
        return (BindableChildItem) this.List[index];
      }
    }

    internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.Properties.onChildPropertyChanged(RuntimeHelpers.GetObjectValue(sender), e);
    }

    internal void onPropertyChanged(string name)
    {
      // ISSUE: reference to a compiler-generated field
      PropertyChangedEventHandler propertyChangedEvent = this.propertyChangedEvent;
      if (propertyChangedEvent == null)
        return;
      propertyChangedEvent((object) this, new PropertyChangedEventArgs(name));
    }

    public bool AllowEdit
    {
      get
      {
        return this._allowEdit;
      }
    }

    public bool AllowNew
    {
      get
      {
        return this._allowNew;
      }
    }

    public bool AllowRemove
    {
      get
      {
        return this._allowRemove;
      }
    }

    public bool IsSorted
    {
      get
      {
        return this._isSorted;
      }
    }

    public ListSortDirection SortDirection
    {
      get
      {
        return this._sortDirection;
      }
    }

    public PropertyDescriptor SortProperty
    {
      get
      {
        throw new NotSupportedException();
      }
    }

    public bool SupportsChangeNotification
    {
      get
      {
        return this._supportsChangeNotification;
      }
    }

    public bool SupportsSearching
    {
      get
      {
        return this._supportsSearching;
      }
    }

    public bool SupportsSorting
    {
      get
      {
        return this._supportsSorting;
      }
    }

    public abstract object AddNew();

    public void AddIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException();
    }

    public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
    {
      throw new NotSupportedException();
    }

    public int Find(PropertyDescriptor property, object key)
    {
      throw new NotSupportedException();
    }

    public void RemoveIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException();
    }

    public void RemoveSort()
    {
      throw new NotSupportedException();
    }

    public event ListChangedEventHandler ListChanged;

    internal void onInternalListChanged(ListChangedType type, int index)
    {
      // ISSUE: reference to a compiler-generated field
      ListChangedEventHandler listChangedEvent = this.ListChangedEvent;
      if (listChangedEvent == null)
        return;
      listChangedEvent((object) this, new ListChangedEventArgs(type, index));
    }

    protected internal virtual void onListChanged(ListChangedType type, int index)
    {
      this.onInternalListChanged(type, index);
      this.Properties.onListChanged();
    }

    protected override void OnClearComplete()
    {
      this.onListChanged(ListChangedType.Reset, 0);
    }

    protected override void OnInsert(int index, object value)
    {
      BindableChildItem bindableChildItem = (BindableChildItem) value;
      bindableChildItem.RemoveMe += new BindableChildItem.RemoveMeEventHandler(this.Remove);
      bindableChildItem.propertyChanged += new PropertyChangedEventHandler(this.onChildPropertyChanged);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      this.onListChanged(ListChangedType.ItemAdded, index);
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      this.onListChanged(ListChangedType.ItemDeleted, index);
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      this.onListChanged(ListChangedType.ItemChanged, index);
    }
  }
}
