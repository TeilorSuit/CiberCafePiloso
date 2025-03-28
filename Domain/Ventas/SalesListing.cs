using System;

namespace Domain
{
    public class SalesListing
    {
        public int orderId { get; set; }              // TransID
        public int IdCaja { get; set; }               // IdCaja (si lo usas)
        public string TransType { get; set; }         // Tipo de transacción (TransType)
        public string customer { get; set; }          // ClientName (por JOIN)
        public string products { get; set; }          // ServiceName (por JOIN)
        public DateTime orderDate { get; set; }       // TransDateTime
        public double totalAmount { get; set; }       // TransSUBTOTAL (o TransTOTAL, según decidas)
        public string username { get; set; }          // TransUserID (convertido a string)
        public double discount { get; set; }          // TransDiscount
        public int quantity { get; set; }             // TransQuantity
        public double servicePrice { get; set; }      // TransServicePrice
    }
}