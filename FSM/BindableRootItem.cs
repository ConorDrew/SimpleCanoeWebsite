// Decompiled with JetBrains decompiler
// Type: FSM.BindableRootItem
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Xml.Serialization;

namespace FSM
{
  public abstract class BindableRootItem : BindableItem, Interfaces.IPersistable
  {
    private RootObject myRoot;

    protected BindableRootItem()
    {
      this.myRoot = new RootObject();
    }

    public abstract string DefaultFileNameAndExt { get; }

    [XmlIgnore]
    public string CurrentLocation
    {
      get
      {
        return this.myRoot.CurrentLocation;
      }
      set
      {
        this.myRoot.CurrentLocation = value;
      }
    }

    [XmlIgnore]
    public bool HasBeenPersisted
    {
      get
      {
        return this.myRoot.HasBeenPersisted;
      }
      set
      {
        this.myRoot.HasBeenPersisted = value;
      }
    }

    [XmlIgnore]
    public string PersistName
    {
      get
      {
        return this.myRoot.PersistName;
      }
      set
      {
        this.myRoot.PersistName = value;
      }
    }

    public static object CreateDefaultList(object item)
    {
      return (object) RootObject.CreateDefaultList((Interfaces.IPersistable) item);
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
      return (object) RootObject.GetDefaultList(itemType);
    }

    public static object Read(string fileName, Type itemType)
    {
      return (object) RootObject.Read(fileName, itemType);
    }

    public static void Write(object item)
    {
      RootObject.Write((Interfaces.IPersistable) item);
    }
  }
}
