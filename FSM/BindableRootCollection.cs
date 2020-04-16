// Decompiled with JetBrains decompiler
// Type: FSM.BindableRootCollection
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Xml.Serialization;

namespace FSM
{
  public abstract class BindableRootCollection : BindableCollection, Interfaces.IPersistable
  {
    private RootObject myRoot;

    protected BindableRootCollection()
    {
      this.myRoot = new RootObject();
    }

    [XmlIgnore]
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

    protected static string defaultPersistFolder
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

    protected static object Read(string fileName, Type itemType)
    {
      return (object) RootObject.Read(fileName, itemType);
    }

    protected static void Write(object item)
    {
      RootObject.Write((Interfaces.IPersistable) item);
    }
  }
}
