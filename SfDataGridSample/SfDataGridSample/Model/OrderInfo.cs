using System;
using System.Collections.Generic;
using System.Text;

namespace SfDataGridSample
{
    public class OrderInfo
    {
        private string orderID;
        private DateTime orderDate;
        private string customer;
        private string customerName;
        private string shipCity;
        private string shipCountry;

        public string OrderID
        {
            get { return orderID; }
            set { this.orderID = value; }
        }

        public string CustomerName
        {
            get { return this.customerName; }
            set { this.customerName = value; }
        }

        public string ShipCountry
        {
            get { return shipCountry; }
            set { this.shipCountry = value; }
        }

        public DateTime OrderDate
        {
            get { return this.orderDate; }
            set { this.orderDate = value; }
        }

        public string ShipCity
        {
            get { return shipCity; }
            set { this.shipCity = value; }
        }

        public OrderInfo(string orderId, string customerName, string country, DateTime orderDate, string shipCity)
        {
            this.OrderID = orderId;
            this.customerName = customerName;
            this.OrderDate = orderDate;
            this.ShipCountry = country;
            this.ShipCity = shipCity;
        }
    }
}
