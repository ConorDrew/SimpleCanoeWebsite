using System;

namespace FSM
{
    // Imports SolutionsNET.Persistence

    internal class RootObject
    {
        // native member declarations
        [System.Xml.Serialization.XmlIgnore()]
        internal FullyQualifiedFileName Filename = new FullyQualifiedFileName();

        [System.Xml.Serialization.XmlIgnore()]
        internal bool HasBeenPersisted = false;

        public RootObject()
        {
            CurrentLocation = DefaultPersistFolder;
        }

        [System.Xml.Serialization.XmlIgnore()]
        internal string CurrentLocation
        {
            get
            {
                return Filename.Folder;
            }

            set
            {
                Filename.Folder = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore()]
        internal string PersistName
        {
            get
            {
                return Filename.Text;
            }

            set
            {
                Filename.Text = value;
            }
        }

        internal static string DefaultPersistFolder
        {
            get
            {
                return XmlPersister.DefaultFolder;
            }

            set
            {
                XmlPersister.DefaultFolder = value;
            }
        }

        internal static Interfaces.IPersistable Read(string filename, Type itemType)
        {
            return XmlPersister.Read(filename, itemType);
        }

        internal static void Write(Interfaces.IPersistable item)
        {
            XmlPersister.Write(item);
        }
    }
}