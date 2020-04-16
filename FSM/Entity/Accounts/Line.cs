// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Accounts.Line
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FSM.Entity.Accounts
{
  [Serializable]
  public class Line : ICloneable
  {
    public Line()
    {
      this.AccountCode = (string) null;
      this.AccountingPeriod = (string) null;
      this.AnalysisCode1 = "NRS001";
      this.AnalysisCode2 = (string) null;
      this.AnalysisCode3 = (string) null;
      this.AnalysisCode4 = (string) null;
      this.AnalysisCode5 = (string) null;
      this.AnalysisCode6 = (string) null;
      this.AnalysisCode7 = (string) null;
      this.AnalysisCode8 = (string) null;
      this.AnalysisCode9 = (string) null;
      this.DebitCredit = (string) null;
      this.Description = (string) null;
      this.EntryDate = (string) null;
      this.JournalType = (string) null;
      this.TransactionAmount = 0.0;
      this.TransactionAmountDecimalPlaces = Conversions.ToInteger("2");
      this.TransactionDate = (string) null;
      this.TransactionReference = (string) null;
    }

    public string AccountCode { get; set; }

    public string AccountingPeriod { get; set; }

    public string AnalysisCode1 { get; set; }

    public string AnalysisCode2 { get; set; }

    public string AnalysisCode3 { get; set; }

    public string AnalysisCode4 { get; set; }

    public string AnalysisCode5 { get; set; }

    public string AnalysisCode6 { get; set; }

    public string AnalysisCode7 { get; set; }

    public string AnalysisCode8 { get; set; }

    public string AnalysisCode9 { get; set; }

    public string DebitCredit { get; set; }

    public string Description { get; set; }

    public string EntryDate { get; set; }

    public string JournalType { get; set; }

    public double TransactionAmount { get; set; }

    public int TransactionAmountDecimalPlaces { get; set; }

    public string TransactionDate { get; set; }

    public string TransactionReference { get; set; }

    public object Clone()
    {
      MemoryStream memoryStream = new MemoryStream();
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Serialize((Stream) memoryStream, (object) this);
      memoryStream.Seek(0L, SeekOrigin.Begin);
      return binaryFormatter.Deserialize((Stream) memoryStream);
    }
  }
}
