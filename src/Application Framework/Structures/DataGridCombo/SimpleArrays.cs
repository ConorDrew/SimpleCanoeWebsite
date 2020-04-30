using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace FSM
{
    public class SimpleBooleanArray
    {
        internal bool[] array;

        public int Count
        {
            get
            {
                if (Information.IsNothing(array))
                {
                    return 0;
                }
                else
                {
                    return UpperBound + 1;
                }
            }
        }

        public virtual string this[bool index]
        {
            get
            {
                if (Conversions.ToInteger(index) < 0 | Conversions.ToInteger(index) > UpperBound)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return Conversions.ToString(array[Conversions.ToInteger(index)]);
                }
            }
        }

        private int UpperBound
        {
            get
            {
                if (array is object)
                {
                    return array.GetUpperBound(0);
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    // An array of objects.  You can retrieve an item by either index or key
    // It also automatically expands as you add items.
    public class SimpleObjectArrayByKey : SimpleObjectArray
    {
        private SimpleStringArray myKeys = new SimpleStringArray();

        public virtual new void AddNew(string Key, object item)
        {
            myKeys.AddNew(Key);
            base.AddNew(item);
        }

        public virtual new bool get_Exists(string key)
        {
            return myKeys.get_Exists(key);
        }

        public new object this[string key]
        {
            get
            {
                return base[Array.IndexOf(myKeys.array, key)];
            }
        }
    }

    public class SimpleObjectArray
    {
        internal object[] array;

        public virtual void AddNew(object item)
        {
            int redimNumber;
            if (Information.IsNothing(array))
            {
                redimNumber = 0;
            }
            else
            {
                redimNumber = array.GetUpperBound(0) + 1;
            }

            var oldArray = array;
            array = new object[redimNumber + 1];
            if (oldArray is object)
                Array.Copy(oldArray, array, Math.Min(redimNumber + 1, oldArray.Length));
            array[redimNumber] = item;
        }

        public int Count
        {
            get
            {
                if (Information.IsNothing(array))
                {
                    return 0;
                }
                else
                {
                    return UpperBound + 1;
                }
            }
        }

        public virtual object this[int index]
        {
            get
            {
                if (index < 0 | index > UpperBound)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return array[index];
                }
            }
        }

        private int UpperBound
        {
            get
            {
                if (array is object)
                {
                    return array.GetUpperBound(0);
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class SimpleStringArray
    {
        internal string[] array;

        public virtual void AddNew(string item)
        {
            int redimNumber;
            if (Information.IsNothing(array))
            {
                redimNumber = 0;
            }
            else
            {
                redimNumber = array.GetUpperBound(0) + 1;
            }

            var oldArray = array;
            array = new string[redimNumber + 1];
            if (oldArray is object)
                Array.Copy(oldArray, array, Math.Min(redimNumber + 1, oldArray.Length));
            array[redimNumber] = item;
        }

        public bool get_Exists(string item)
        {
            if (array is object)
            {
                if (Array.IndexOf(array, item) > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                if (Information.IsNothing(array))
                {
                    return 0;
                }
                else
                {
                    return UpperBound + 1;
                }
            }
        }

        public virtual string this[int index]
        {
            get
            {
                if (index < 0 | index > UpperBound)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return array[index];
                }
            }
        }

        private int UpperBound
        {
            get
            {
                if (array is object)
                {
                    return array.GetUpperBound(0);
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class SimpleStringArrayOld : SimpleObjectArray
    {
        public virtual new string this[int index]
        {
            get
            {
                return Conversions.ToString(base[index]);
            }
        }
    }
}