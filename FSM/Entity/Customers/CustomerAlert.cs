// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.CustomerAlert
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.Customers
{
  public class CustomerAlert
  {
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int AlertTypeId { get; set; }

    public string EmailAddress { get; set; }

    public DateTime Created { get; set; }

    public string AlertType { get; set; }
  }
}
