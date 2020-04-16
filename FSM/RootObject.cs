// Decompiled with JetBrains decompiler
// Type: FSM.RootObject
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Xml.Serialization;

namespace FSM
{
  internal class RootObject
  {
    [XmlIgnore]
    internal FullyQualifiedFileName Filename;
    [XmlIgnore]
    internal bool HasBeenPersisted;

    public RootObject()
    {
      this.Filename = new FullyQualifiedFileName();
      this.HasBeenPersisted = false;
      this.CurrentLocation = RootObject.DefaultPersistFolder;
    }

    [XmlIgnore]
    internal string CurrentLocation
    {
      get
      {
        return this.Filename.Folder;
      }
      set
      {
        this.Filename.Folder = value;
      }
    }

    [XmlIgnore]
    internal string PersistName
    {
      get
      {
        return this.Filename.Text;
      }
      set
      {
        this.Filename.Text = value;
      }
    }

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
  }
}
