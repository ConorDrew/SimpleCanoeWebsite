// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CostCentres.CostCentre
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.CostCentres
{
  public class CostCentre
  {
    public int Id { get; set; }

    public int CostCentre { get; set; }

    public int JobTypeId { get; set; }

    public int LinkId { get; set; }

    public int LinkTypeId { get; set; }

    public Decimal JobSpendLimit { get; set; }
  }
}
