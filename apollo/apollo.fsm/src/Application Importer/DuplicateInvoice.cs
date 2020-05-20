using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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