// Decompiled with JetBrains decompiler
// Type: FSM.XmlPersister
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace FSM
{
  public class XmlPersister
  {
    private static string _defaultfolder = string.Empty;

    public static string DefaultFolder
    {
      get
      {
        return XmlPersister._defaultfolder;
      }
      set
      {
        if (value.EndsWith("\\bin"))
          value = value.Remove(checked (value.Length - 3), 3);
        if (!value.EndsWith("\\"))
          value += "\\";
        XmlPersister._defaultfolder = value;
      }
    }

    public static bool DefaultListExits(Type objectType)
    {
      return Conversions.ToBoolean(XmlPersister.Exists(string.Format("{0}{1}.xml", (object) XmlPersister.DefaultFolder, (object) objectType.Name)));
    }

    public static object Exists(string persistName)
    {
      object obj;
      try
      {
        new FileStream(persistName, FileMode.Open).Close();
        obj = (object) true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        if (Operators.CompareString(ex.GetType().Name, "FileNotFoundException", false) == 0)
        {
          obj = (object) false;
          ProjectData.ClearProjectError();
        }
        else
          ProjectData.ClearProjectError();
      }
      return obj;
    }

    public static Interfaces.IPersistable GetDefaultList(Type objectType)
    {
      return XmlPersister.Read(string.Format("{0}{1}.xml", (object) XmlPersister.DefaultFolder, (object) objectType.Name), objectType);
    }

    public static Interfaces.IPersistable Read(string persistName, Type objectType)
    {
      Interfaces.IPersistable persistable;
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(objectType);
        FileStream fileStream = new FileStream(persistName, FileMode.Open);
        try
        {
          persistable = (Interfaces.IPersistable) xmlSerializer.Deserialize((Stream) fileStream);
          fileStream.Close();
          persistable.HasBeenPersisted = true;
          persistable.PersistName = persistName;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Debug.Assert(false, ex.Message);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Debug.Assert(false, ex.Message);
        ProjectData.ClearProjectError();
      }
      return persistable;
    }

    public static object Write(Interfaces.IPersistable persistableObject)
    {
      object obj1 = (object) persistableObject;
      if (Operators.CompareString(persistableObject.PersistName, persistableObject.CurrentLocation, false) == 0)
        persistableObject.PersistName = persistableObject.CurrentLocation + persistableObject.DefaultName;
      XmlSerializer xmlSerializer = new XmlSerializer(obj1.GetType());
      StreamWriter streamWriter = new StreamWriter(persistableObject.PersistName);
      try
      {
        xmlSerializer.Serialize((TextWriter) streamWriter, RuntimeHelpers.GetObjectValue(obj1));
        persistableObject.HasBeenPersisted = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Debug.Assert(false, ex.Message);
        ProjectData.ClearProjectError();
      }
      streamWriter.Close();
      object obj2;
      return obj2;
    }
  }
}
