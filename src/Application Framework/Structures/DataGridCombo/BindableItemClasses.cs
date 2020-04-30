using System;
using System.ComponentModel;
using System.Reflection;

namespace FSM
{
    // Imports SolutionsNET.Persistence

    public abstract class BindableItem : IEditableObject, IDataErrorInfo
    {
        

        public BindableItem()
        {
            PersistedProperties = new PersistedProperties(this);
            CalculatedProperties = new CalculatedProperties(this);
        }

        // these hold and handle contained properties
        protected readonly PersistedProperties PersistedProperties;

        protected readonly CalculatedProperties CalculatedProperties;

        // events
        internal event PropertyChangedEventHandler internalPropertyChanged;

        protected internal event PropertyChangedEventHandler propertyChanged;

        // for IEditableObject members
        private bool _editing = false;

        protected bool _isNew = true;

        // Public MustOverride ReadOnly Property IsRootObject()

        
        

        public object get_PropertyValue(string name)
        {
            if (PersistedProperties.get_Exists(name))
            {
                return PersistedProperties[name].Value;
            }
            else if (CalculatedProperties.get_Exists(name))
            {
                // Return CalculatedProperties(name).value
                return null;
            }

            return default;
        }

        
        

        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculatedProperties.onChildPropertyChanged(sender, e);
        }

        internal void onInternalPropertyChanged(string name)
        {
            internalPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void onPropertyChanged(string name)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            var myType = GetType();
            foreach (EventInfo thisEvent in myType.GetEvents())
            {
                if (thisEvent.Name.StartsWith(name))
                {
                    string myMethodName = string.Format("On{0}Changed", name);
                    var thisRaiseMethod = myType.GetMethod(myMethodName);
                    if (thisRaiseMethod is object)
                    {
                        var myArguments = new[] { new PropertyChangedEventArgs(name) };
                        thisRaiseMethod.Invoke(this, myArguments);
                    }
                    else
                    {
                        MethodInfo newMethod;
                    }
                }
            }
        }

        
        

        private void BeginEdit()
        {
            if (!_editing)
            {
                _editing = true;
                PersistedProperties.BeginEdit();
            }
        }

        protected virtual void CancelEdit()
        {
            if (_editing)
            {
                _editing = false;
            }

            PersistedProperties.CancelEdit();
        }

        private void EndEdit()
        {
            _editing = false;
            _isNew = false;
        }

        
        

        private string Error
        {
            get
            {
                return PersistedProperties.Error;
            }
        }

        string IDataErrorInfo.Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        private string get_ErrorInfoItem(string columnName)
        {
            return string.Empty;
        }

        void IEditableObject.BeginEdit()
        {
            throw new NotImplementedException();
        }

        void IEditableObject.EndEdit()
        {
            throw new NotImplementedException();
        }

        void IEditableObject.CancelEdit()
        {
            throw new NotImplementedException();
        }

        
    }

    public abstract class BindableChildItem : BindableItem
    {
        

        public event RemoveMeEventHandler RemoveMe;

        public delegate void RemoveMeEventHandler(BindableChildItem item);

        
        

        private void onRemoveMe()
        {
            RemoveMe?.Invoke(this);
        }

        
        

        protected override void CancelEdit()
        {
            base.CancelEdit();
            if (_isNew)
            {
                onRemoveMe();
            }
        }

        
    }

    public abstract class BindableRootItem : BindableItem, Interfaces.IPersistable
    {
        

        // native member declarations
        private RootObject myRoot = new RootObject();

        // must overrides
        public string DefaultFileNameAndExt => DefaultName;

        public string DefaultName { get; }

        
        

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

        
        

        public static object CreateDefaultList(object item)
        {
            return RootObject.CreateDefaultList((Interfaces.IPersistable)item);
        }

        public static bool DefaultListExits(Type objectType)
        {
            return RootObject.DefaultListExits(objectType);
        }

        public static string defaultPersistFolder
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

        public static object GetDefaultList(Type itemType)
        {
            return RootObject.GetDefaultList(itemType);
        }

        public static object Read(string fileName, Type itemType)
        {
            return RootObject.Read(fileName, itemType);
        }

        public static void Write(object item)
        {
            RootObject.Write((Interfaces.IPersistable)item);
        }

        
    }
}