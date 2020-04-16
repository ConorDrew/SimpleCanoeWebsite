// Decompiled with JetBrains decompiler
// Type: FSM.Importer.DuplicateInvoice
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM.Importer
{
  public class DuplicateInvoice
  {
    public int SupplierID { get; set; }

    public string InvoiceNo { get; set; }

    public string InvoiceDate { get; set; }

    public string PurchaseOrderNo { get; set; }

    public string SupplierPartCode { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double NetAmount { get; set; }

    public double VATAmount { get; set; }

    public double GrossAmount { get; set; }

    public int TotalQtyOfParts { get; set; }
  }
}
