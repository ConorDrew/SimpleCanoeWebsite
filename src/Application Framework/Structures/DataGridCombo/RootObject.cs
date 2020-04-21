﻿using System;

namespace FSM
{
    // Imports SolutionsNET.Persistence

    internal class RootObject
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // native member declarations
        [System.Xml.Serialization.XmlIgnore()]
        internal FullyQualifiedFileName Filename = new FullyQualifiedFileName();

        [System.Xml.Serialization.XmlIgnore()]
        internal bool HasBeenPersisted = false;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public RootObject()
        {
            CurrentLocation = DefaultPersistFolder;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        internal static Interfaces.IPersistable CreateDefaultList(Interfaces.IPersistable item)
        {
            XmlPersister.Write(item);
            return item;
        }

        internal static bool DefaultListExits(Type objectType)
        {
            return XmlPersister.DefaultListExits(objectType);
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

        internal static Interfaces.IPersistable GetDefaultList(Type itemType)
        {
            return XmlPersister.GetDefaultList(itemType);
        }

        internal static Interfaces.IPersistable Read(string filename, Type itemType)
        {
            return XmlPersister.Read(filename, itemType);
        }

        internal static void Write(Interfaces.IPersistable item)
        {
            XmlPersister.Write(item);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}