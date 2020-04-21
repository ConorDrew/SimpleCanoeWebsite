using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace FSM
{
    public class XmlPersister
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static string _defaultfolder = string.Empty;

        public static string DefaultFolder
        {
            get
            {
                return _defaultfolder;
            }

            set
            {
                if (value.EndsWith(@"\bin"))
                {
                    value = value.Remove(value.Length - 3, 3);
                }

                if (!value.EndsWith(@"\"))
                    value += @"\";
                _defaultfolder = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public static bool DefaultListExits(Type objectType)
        {
            string myName;
            myName = string.Format("{0}{1}.xml", DefaultFolder, objectType.Name);
            return Conversions.ToBoolean(Exists(myName));
        }

        public static object Exists(string persistName)
        {
            try
            {
                var myIO = new FileStream(persistName, FileMode.Open);
                myIO.Close();
                return true;
            }
            catch (Exception ex)
            {
                if ((ex.GetType().Name ?? "") == "FileNotFoundException")
                {
                    return false;
                }
            }

            return default;
        }

        public static Interfaces.IPersistable GetDefaultList(Type objectType)
        {
            string myName;
            myName = string.Format("{0}{1}.xml", DefaultFolder, objectType.Name);
            return Read(myName, objectType);
        }

        public static Interfaces.IPersistable Read(string persistName, Type objectType)
        {
            var myObject = default(Interfaces.IPersistable);
            try
            {
                var mySerializer = new XmlSerializer(objectType);
                var myStream = new FileStream(persistName, FileMode.Open);
                try
                {
                    myObject = (Interfaces.IPersistable)mySerializer.Deserialize(myStream);
                    myStream.Close();
                    myObject.HasBeenPersisted = true;
                    myObject.PersistName = persistName;
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.Message);
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }

            return myObject;
        }

        public static object Write(Interfaces.IPersistable persistableObject)
        {
            object myObject = persistableObject;
            if ((persistableObject.PersistName ?? "") == (persistableObject.CurrentLocation ?? ""))
            {
                persistableObject.PersistName = persistableObject.CurrentLocation + persistableObject.DefaultName;
            }

            var mySerializer = new XmlSerializer(myObject.GetType());
            var myStream = new StreamWriter(persistableObject.PersistName);
            try
            {
                mySerializer.Serialize(myStream, myObject);
                persistableObject.HasBeenPersisted = true;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }

            myStream.Close();
            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}