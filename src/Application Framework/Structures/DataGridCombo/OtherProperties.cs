using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSM
{
    public class CalculatedProperties : Properties
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal CalculatedProperties(BindableItem parent) : base(parent)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal new BindableItem Parent
        {
            get
            {
                return (BindableItem)base.Parent;
            }

            set
            {
                base.Parent = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public new CalculatedProperty AddNew(string name)
        {
            var newItem = new CalculatedProperty(this, name);
            AddNew(newItem);
            return newItem;
        }

        public new CalculatedProperty AddNew(string name, string triggers)
        {
            // triggers is a comma delimited string of property names that when
            // have a change, trigger a change to this calculated value as well.
            int pos;
            string propName;
            string newStr = triggers;
            {
                var withBlock = AddNew(name);
                do
                {
                    pos = newStr.IndexOf(",");
                    if (pos > 0)
                    {
                        propName = newStr.Substring(0, pos);
                        newStr = newStr.Substring(pos + 1);
                    }
                    else
                    {
                        propName = newStr;
                    }

                    withBlock.triggers.AddNew(propName);
                }
                while (pos != -1);
            }

            return default;
        }

        public new CalculatedProperty this[int Index]
        {
            get
            {
                return (CalculatedProperty)base[Index];
            }
        }

        public new CalculatedProperty this[string name]
        {
            get
            {
                return (CalculatedProperty)base[name];
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                this[x].onChildPropertyChanged(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class CalculatedProperty : Property
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private BindableItem _Parent;

        private BindableItem Parent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Parent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Parent != null)
                {
                    _Parent.internalPropertyChanged -= triggerChangedHandler;
                }

                _Parent = value;
                if (_Parent != null)
                {
                    _Parent.internalPropertyChanged += triggerChangedHandler;
                }
            }
        }

        internal SimpleStringArray triggers = new SimpleStringArray();
        private object _value;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal CalculatedProperty(CalculatedProperties container, string name) : base(container, name)
        {
            Parent = container.Parent;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal new CalculatedProperties Container
        {
            get
            {
                return (CalculatedProperties)base.Container;
            }

            set
            {
                base.Container = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public object Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            // Whenever a child property is changed, we hear it here.  If its a trigger for an
            // property of the collection, thne raise the property changed event.  Happens to be the
            // exact code as 'triggerChangedHandler' method, so call it.
            triggerChangedHandler(sender, e);
        }

        internal void triggerChangedHandler(object sender, PropertyChangedEventArgs e)

        {
            // Listen to all persisted property changed events.

            // if the property just changed is a trigger then raise this
            // property change event.
            if (triggers.get_Exists(e.PropertyName))
            {
                Parent.onPropertyChanged(name);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class CollectionProperties : Properties
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal CollectionProperties(BindableCollection parent) : base(parent)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal new BindableCollection Parent
        {
            get
            {
                return (BindableCollection)base.Parent;
            }

            set
            {
                base.Parent = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public new CollectionProperty AddNew(string name)
        {
            var newItem = new CollectionProperty(this, name);
            AddNew(newItem);
            return newItem;
        }

        public new CollectionProperty AddNew(string name, string childTriggers)
        {
            // triggers is a comma delimited string of child property names that when
            // have a change, trigger a change to this value as well.
            int pos;
            string propName;
            string newStr = childTriggers;
            {
                var withBlock = AddNew(name);
                do
                {
                    pos = newStr.IndexOf(",");
                    if (pos > 0)
                    {
                        propName = newStr.Substring(0, pos);
                        newStr = newStr.Substring(pos + 1);
                    }
                    else
                    {
                        propName = newStr;
                    }

                    withBlock.childTriggers.AddNew(propName);
                }
                while (pos != -1);
            }

            return default;
        }

        public new CollectionProperty this[int Index]
        {
            get
            {
                return (CollectionProperty)base[Index];
            }
        }

        public new CollectionProperty this[string name]
        {
            get
            {
                return (CollectionProperty)base[name];
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                this[x].onChildPropertyChanged(sender, e);
        }

        internal void onListChanged()
        {
            for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                this[x].onListChanged();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class CollectionProperty : Property
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // Indicates to raise the ListChanged event after the PropertyChanged event
        public bool DoListChangedOnPropertyChange = true;
        // Indicates to raise the PropertyChanged event after the ListChanged event
        public bool DoPropertyChangeOnListChanged = true;

        // Contains the list of child property changed names that trigger a change
        // in this calculated collection property.
        internal SimpleStringArray childTriggers = new SimpleStringArray();

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal CollectionProperty(CollectionProperties container, string name) : base(container, name)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal new CollectionProperties Container
        {
            get
            {
                return (CollectionProperties)base.Container;
            }

            set
            {
                base.Container = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void onChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var myParent = Container.Parent;
            if (childTriggers.get_Exists(e.PropertyName))
            {
                // this property is triggered by this child property change.  IOW, we have a change in
                // this property, so call the event.
                myParent.onPropertyChanged(e.PropertyName);
                if (DoListChangedOnPropertyChange)
                {
                    // And since we need to also raise a listChanged event when this property changes...
                    myParent.onInternalListChanged(ListChangedType.ItemChanged, myParent.IndexOf((BindableChildItem)sender));
                }
            }
        }

        internal void onListChanged()
        {
            var myParent = Container.Parent;
            if (DoPropertyChangeOnListChanged)
            {
                myParent.onPropertyChanged(name);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}