using System;
using System.Collections;
using System.ComponentModel;

namespace FSM
{
    // Imports SolutionsNET.Persistence

    public abstract class BindableCollection : CollectionBase, IBindingList
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // primitives for IBindingList
        private bool _allowEdit = true;

        private bool _allowNew = true;
        private bool _allowRemove = true;
        private bool _isSorted = false;
        private ListSortDirection _sortDirection;
        private bool _supportsChangeNotification = true;
        private bool _supportsSearching = false;
        private bool _supportsSorting = false;

        // for calculated events
        protected internal event PropertyChangedEventHandler propertyChanged;

        // these hold contained properties
        protected readonly CollectionProperties Properties = new CollectionProperties(this);

        event System.ComponentModel.ListChangedEventHandler IBindingList.ListChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Add(BindableChildItem item)
        {
            List.Add(item);
        }

        internal int IndexOf(BindableChildItem item)
        {
            return List.IndexOf(item);
        }

        public void Remove(BindableChildItem item)
        {
            List.Remove(item);
        }

        public BindableChildItem this[int index]
        {
            get
            {
                return (BindableChildItem)List[index];
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Properties.onChildPropertyChanged(sender, e);
        }

        internal void onPropertyChanged(string name)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public bool AllowEdit
        {
            get
            {
                return _allowEdit;
            }
        }

        public bool AllowNew
        {
            get
            {
                return _allowNew;
            }
        }

        public bool AllowRemove
        {
            get
            {
                return _allowRemove;
            }
        }

        public bool IsSorted
        {
            get
            {
                return _isSorted;
            }
        }

        public ListSortDirection SortDirection
        {
            get
            {
                return _sortDirection;
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
                return _supportsChangeNotification;
            }
        }

        public bool SupportsSearching
        {
            get
            {
                return _supportsSearching;
            }
        }

        public bool SupportsSorting
        {
            get
            {
                return _supportsSorting;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event ListChangedEventHandler ListChanged;

        public delegate void ListChangedEventHandler(object sender, ListChangedEventArgs e);

        internal void onInternalListChanged(ListChangedType type, int index)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs(type, index));
        }

        protected internal virtual void onListChanged(ListChangedType type, int index)
        {
            onInternalListChanged(type, index);
            Properties.onListChanged();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void OnClearComplete()
        {
            onListChanged(ListChangedType.Reset, 0);
        }

        protected override void OnInsert(int index, object value)
        {
            BindableChildItem item = (BindableChildItem)value;
            item.RemoveMe += Remove;
            item.propertyChanged += onChildPropertyChanged;
        }

        protected override void OnInsertComplete(int index, object value)
        {
            onListChanged(ListChangedType.ItemAdded, index);
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            onListChanged(ListChangedType.ItemDeleted, index);
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)

        {
            onListChanged(ListChangedType.ItemChanged, index);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public abstract class BindableRootCollection : BindableCollection, Interfaces.IPersistable
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // native member declarations
        private RootObject myRoot = new RootObject();

        // must overrides
        [System.Xml.Serialization.XmlIgnore()]
        public abstract string DefaultFileNameAndExt { get; }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        [System.Xml.Serialization.XmlIgnore()]
        public string CurrentLocation
        {
            get
            {
                return myRoot.CurrentLocation;
            }

            set
            {
                myRoot.CurrentLocation = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore()]
        public bool HasBeenPersisted
        {
            get
            {
                return myRoot.HasBeenPersisted;
            }

            set
            {
                myRoot.HasBeenPersisted = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore()]
        public string PersistName
        {
            get
            {
                return myRoot.PersistName;
            }

            set
            {
                myRoot.PersistName = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected static string defaultPersistFolder
        {
            get
            {
                return RootObject.DefaultPersistFolder;
            }

            set
            {
                RootObject.DefaultPersistFolder = value;
            }
        }

        public string DefaultName => throw new NotImplementedException();

        protected static object Read(string fileName, Type itemType)
        {
            return RootObject.Read(fileName, itemType);
        }

        protected static void Write(object item)
        {
            RootObject.Write((Interfaces.IPersistable)item);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}