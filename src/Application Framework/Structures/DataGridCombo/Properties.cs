using System;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class Properties : SimpleObjectArrayByKey
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // native member declarations
        internal object Parent;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal Properties(object parent)
        {
            Parent = parent;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public new Property AddNew(string name)
        {
            var newItem = new Property(this, name);
            AddNew(newItem);
            return newItem;
        }

        public new object AddNew(Property item)
        {
            base.AddNew(item.name, item);
            return default;
        }

        public new Property this[int Index]
        {
            get
            {
                return (Property)base[Index];
            }
        }

        public new Property this[string name]
        {
            get
            {
                return (Property)base[name];
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class Property
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // native member declarations
        protected internal string name;
        private Properties _container;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal Properties Container
        {
            get
            {
                return _container;
            }

            set
            {
                _container = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal Property(Properties container, string name)
        {
            // This keeps us from raising property changed events during
            // construction of the object
            Container = container;
            this.name = name;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class PersistedProperties : Properties
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal PersistedProperties(BindableItem parent) : base(parent)
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
        public new PersistedProperty AddNew(string name, object value)
        {
            var newItem = new PersistedProperty(this, name, value);
            AddNew(newItem);
            return newItem;
        }

        public new object AddNew(string name, object value, bool required)
        {
            AddNew(name, value);
            this[name].Required = required;
            return default;
        }

        public new PersistedProperty this[int Index]
        {
            get
            {
                return (PersistedProperty)base[Index];
            }
        }

        public new PersistedProperty this[string name]
        {
            get
            {
                return (PersistedProperty)base[name];
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void BeginEdit()
        {
            for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                this[x].BeginEdit();
        }

        internal void CancelEdit()
        {
            for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                this[x].CancelEdit();
        }

        internal string Error
        {
            get
            {
                var s = default(string);
                for (int x = 0, loopTo = Count - 1; x <= loopTo; x++)
                {
                    s = this[x].Error;
                    if (s.Length > 0)
                    {
                        break;
                    }
                }

                return s;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class PersistedProperty : Property
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // native member declarations
        private bool _beingConstructed;
        private object _oldValue;
        private object _value;
        internal bool Required = true;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal PersistedProperty(PersistedProperties container, string name, object value) : base(container, name)
        {
            _beingConstructed = true;
            Value = value;
            _beingConstructed = false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal new PersistedProperties Container
        {
            get
            {
                return (PersistedProperties)base.Container;
            }

            set
            {
                base.Container = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal string Error
        {
            get
            {
                if (!Required)
                    return string.Empty;
                if (isString)
                {
                    if (Conversions.ToString(Value).Length == 0)
                        return name + " required";
                }

                if (isNumeric)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Value, 0, false)))
                        return name + " required";
                }

                if (isDate)
                {
                    if (DateTime.Equals(Conversions.ToDate(Value), DateTime.MinValue))
                        return name + " required";
                }

                if (isTimeSpan)
                {
                    if (Equals(Value, TimeSpan.Zero))
                        return name + " required";
                }

                return string.Empty;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }

            set
            {
                bool _setValue = true;
                bool _isBusinessClass = false;

                // Assume the value will change and then
                // find all those instances when it should NOT be
                // changed.
                if (value is null)
                {
                    // if the newValue is nothing then of course
                    // leave it alone.  IE, by default values are
                    // non-nullable.
                    _setValue = false;
                }
                else if (get_isElemental(value))
                {
                    if (get_isElemental(_value))
                    {
                        // classic case of elemental value being changed
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_value, value, false)))
                        {
                            _setValue = false;
                        }
                    }
                }
                else if (get_isTimeSpan(value))
                {
                    if (get_isTimeSpan(_value))
                    {
                        // again class case but just must do compare differently with
                        // this object type.
                        if (((TimeSpan)_value).CompareTo(value) == 0)
                        {
                            _setValue = false;
                        }
                    }
                }
                else if (get_isBusinessClass(value))
                {
                    _isBusinessClass = true;
                }

                if (_setValue)
                {
                    _value = value;
                    // For child objects, there is no need to raise any
                    // events that may be called in onValueChange()
                    if (_isBusinessClass)
                    {
                        BindableCollection myChild;
                        BindableItem myParent;
                        myChild = (BindableCollection)value;
                        myParent = Container.Parent;
                        myChild.propertyChanged += myParent.onChildPropertyChanged;
                    }
                    else if (!_beingConstructed)
                    {
                        Container.Parent.onPropertyChanged(name);
                        Container.Parent.onInternalPropertyChanged(name);
                    }
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static bool get_isBoolean(object myValue)
        {
            if (!get_isPrimitive(myValue))
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "boolean":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool get_isBusinessClass(object myValue)
        {
            if (myValue is null)
                return false;
            if (get_isElemental(myValue))
                return false;
            if (get_isTimeSpan(myValue))
                return false;
            return true;
        }

        private static bool get_isDate(object myValue)
        {
            if (myValue is null)
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "datetime":
                    {
                        return true;
                    }

                case "date":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool get_isElemental(object myValue)
        {
            // Elementals are all primitive, string and date types
            if (get_isPrimitive(myValue))
                return true;
            if (get_isString(myValue))
                return true;
            if (get_isDate(myValue))
                return true;
            return false;
        }

        private static bool get_isIntegral(object myValue)
        {
            if (!get_isPrimitive(myValue))
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "byte":
                case "sbyte":
                case "int16":
                case "uint16":
                case "int32":
                case "uint32":
                case "int64":
                case "uint64":
                    {
                        return true;
                    }

                case var @case when @case == "byte":
                case "integer":
                case "short":
                case "long":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool get_isNonIntegral(object myValue)
        {
            if (!get_isPrimitive(myValue))
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "decimal":
                case "single":
                case "double":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool get_isNumeric(object myValue)
        {
            if (!get_isPrimitive(myValue))
                return false;
            if (get_isIntegral(myValue))
                return true;
            if (get_isNonIntegral(myValue))
                return true;
            return false;
        }

        private static bool get_isPrimitive(object myValue)
        {
            if (myValue is null)
                return false;
            if (myValue.GetType().IsPrimitive)
                return true;
            return false;
        }

        private static bool get_isString(object myValue)
        {
            if (myValue is null)
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "string":
                case "char":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool get_isTimeSpan(object myValue)
        {
            if (myValue is null)
                return false;
            var switchExpr = myValue.GetType().Name.ToLower();
            switch (switchExpr)
            {
                case "timespan":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool isBoolean
        {
            get
            {
                return get_isBoolean(Value);
            }
        }

        private bool isBusinessClass
        {
            get
            {
                return get_isBusinessClass(Value);
            }
        }

        private bool isDate
        {
            get
            {
                return get_isDate(Value);
            }
        }

        private bool isElemental
        {
            get
            {
                return get_isElemental(Value);
            }
        }

        private bool isIntegral
        {
            get
            {
                return get_isIntegral(Value);
            }
        }

        private bool isNonIntegral
        {
            get
            {
                return get_isNonIntegral(Value);
            }
        }

        private bool isNumeric
        {
            get
            {
                return get_isNumeric(Value);
            }
        }

        private bool isPrimitive
        {
            get
            {
                return get_isPrimitive(Value);
            }
        }

        private bool isString
        {
            get
            {
                return get_isString(Value);
            }
        }

        private bool isTimeSpan
        {
            get
            {
                return get_isTimeSpan(Value);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void BeginEdit()
        {
            _oldValue = _value;
        }

        internal void CancelEdit()
        {
            // by using the accessor, then other pertinant events will be called
            Value = _oldValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}