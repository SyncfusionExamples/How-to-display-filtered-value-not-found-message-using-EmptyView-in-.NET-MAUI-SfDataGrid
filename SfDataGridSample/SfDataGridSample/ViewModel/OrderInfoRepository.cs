using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SfDataGridSample
{
    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public ICommand DeleteRecord { get; }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
            DeleteRecord = new Command<object>(OnDeleteRecord);
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo("1001", "Maria Anders", "Germany", new DateTime(2021, 1, 15), "Berlin"));
            orderInfo.Add(new OrderInfo("1002", "Ana Trujillo", "Mexico", new DateTime(2021, 2, 3), "Mexico D.F."));
            orderInfo.Add(new OrderInfo("1003", "Ant Fuller", "Mexico", new DateTime(2021, 2, 18), "Mexico D.F."));
            orderInfo.Add(new OrderInfo("1004", "Thomas Hardy", "UK", new DateTime(2021, 3, 5), "London"));
            orderInfo.Add(new OrderInfo("1005", "Tim Adams", "Sweden", new DateTime(2021, 4, 22), "London"));
            orderInfo.Add(new OrderInfo("1006", "Hanna Moos", "Germany", new DateTime(2021, 5, 11), "Mannheim"));
            orderInfo.Add(new OrderInfo("1007", "Andrew Fuller", "France", new DateTime(2021, 6, 9), "Strasbourg"));
            orderInfo.Add(new OrderInfo("1008", "Martin King", "Spain", new DateTime(2021, 7, 30), "Madrid"));
            //orderInfo.Add(new OrderInfo("1009", "Lenny Lin", "France", new DateTime(2021, 8, 14), "Marsiella"));
            //orderInfo.Add(new OrderInfo("1010", "John Carter", "Canada", new DateTime(2021, 9, 2), "Lenny Lin"));
            //orderInfo.Add(new OrderInfo("1011", "Laura King", "UK", new DateTime(2021, 10, 19), "London"));
            //orderInfo.Add(new OrderInfo("1012", "Anne Wilson", "Germany", new DateTime(2021, 11, 6), "Mannheim"));
            //orderInfo.Add(new OrderInfo("1013", "Martin King", "France", new DateTime(2021, 12, 25), "Strasbourg"));
            //orderInfo.Add(new OrderInfo("1014", "Gina Irene", "UK", new DateTime(2022, 1, 8), "London"));
            //orderInfo.Add(new OrderInfo("1015", "Maria Anders", "Germany", new DateTime(2022, 2, 14), "Berlin"));
            //orderInfo.Add(new OrderInfo("1016", "Anabella", "Mexico", new DateTime(2022, 3, 21), "Mexico D.F."));
            //orderInfo.Add(new OrderInfo("1017", "Ant louis", "Mexico", new DateTime(2022, 4, 12), "Mexico D.F."));
            //orderInfo.Add(new OrderInfo("1018", "Michael Scofield", "UK", new DateTime(2022, 5, 7), "London"));
            //orderInfo.Add(new OrderInfo("1019", "Tom cook", "Sweden", new DateTime(2022, 6, 16), "London"));
            //orderInfo.Add(new OrderInfo("1020", "Jack Wilson", "Germany", new DateTime(2022, 7, 29), "Mannheim"));
        }

        private void OnDeleteRecord(object? parameter)
        {
            if (parameter is not OrderInfo record)
                return;
                
            // Remove the record from the collection if it exists
            if (orderInfo != null && orderInfo.Contains(record))
            {
                orderInfo.Remove(record);
            }
        }
    }
}
