// Decompiled with JetBrains decompiler
// Type: FSM.JobNumber
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
  public class JobNumber
  {
    private int _jobNumber;
    private string _prefix;
    private string _OrderNumber;

    public int JobNumber
    {
      get
      {
        return this._jobNumber;
      }
      set
      {
        this._jobNumber = value;
      }
    }

    public string Prefix
    {
      get
      {
        return this._prefix;
      }
      set
      {
        this._prefix = value;
      }
    }

    public string OrderNumber
    {
      get
      {
        return this._OrderNumber;
      }
      set
      {
        this._OrderNumber = value;
      }
    }

    public JobNumber()
    {
      this._jobNumber = 0;
      this._prefix = Conversions.ToString(0);
      this._OrderNumber = "";
    }

    public JobNumber(int jobNumberIn, string PrefixIn)
    {
      this._jobNumber = 0;
      this._prefix = Conversions.ToString(0);
      this._OrderNumber = "";
      this.JobNumber = jobNumberIn;
      this.Prefix = PrefixIn;
    }
  }
}
