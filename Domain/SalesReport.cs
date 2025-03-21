using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace Domain
{
    public class SalesReport
    {
        public DateTime reportDate { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public List<SalesListing> salesListing { get; private set; }
        public List<NetSalesByPeriod> netSalesByPeriod { get; private set; }
        public double totalNetSales { get; private set; }

        public void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.getSalesOrder(fromDate, toDate);

            salesListing = new List<SalesListing>();
            totalNetSales = 0;

            foreach (DataRow row in result.Rows)
            {
                var salesModel = new SalesListing()
                {
                    orderId = Convert.ToInt32(row["TransID"]),
                    orderDate = Convert.ToDateTime(row["TransDateTime"]),
                    customer = Convert.ToString(row["ClientName"]),
                    products = Convert.ToString(row["ServiceName"]),
                    totalAmount = Convert.ToDouble(row["TransSubTotal"])
                };
                salesListing.Add(salesModel);
                totalNetSales += salesModel.totalAmount;
            }

            // Inicializamos netSalesByPeriod a una lista vacía para evitar que sea null.
            netSalesByPeriod = new List<NetSalesByPeriod>();

            // Opcional: Agrega aquí tu lógica para agrupar ventas por período
            // Ejemplo: Agrupar por día (si el rango es corto)
            /*
            int totalDays = (toDate - fromDate).Days;
            if (totalDays <= 7)
            {
                netSalesByPeriod = (from sales in salesListing
                                    group sales by sales.orderDate.Date into groupSales
                                    select new NetSalesByPeriod
                                    {
                                        period = groupSales.Key.ToString("dd-MMM-yyyy"),
                                        netSales = groupSales.Sum(s => s.totalAmount)
                                    }).ToList();
            }
            */
        }
    }
}
