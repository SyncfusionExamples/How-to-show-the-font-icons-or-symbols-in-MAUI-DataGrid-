
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, "Jack Parker", "Germany", "ALFKI", "Berlin",13000, "triangle"));
            orderInfo.Add(new OrderInfo(1002, "Maria Anders", "Mexico", "ANATR", "Mexico D.F.",6000, "square"));
            orderInfo.Add(new OrderInfo(1003, "Alice Johnson", "Mexico", "ANTON", "Mexico D.F.",15000, "triangle"));
            orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London",8000, "square"));    
            orderInfo.Add(new OrderInfo(1005, "Emily Davis", "Sweden", "BERGS", "London",7000, "circle"));
        }
    }
}
