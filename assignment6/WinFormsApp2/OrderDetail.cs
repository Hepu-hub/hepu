using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2 {
    public class OrderDetail {

        public string ProductName { get; set; }
        
        public int Price { get; set; }
        public int Quantity { get; set; }

        public float TotalPrice {
            get => Price * Quantity;
        }

        public OrderDetail() {}

        public OrderDetail(string productName, int price,int quantity) {
            this.ProductName = productName;
            this.Price = price;
            this.Quantity = quantity;
        }

        public override bool Equals(object obj) {
            var detail = obj as OrderDetail;
            return detail != null &&Price == detail.Price && detail.ProductName == ProductName&&detail.Quantity == Quantity;
        }

        public override int GetHashCode() {
            return 785010553 + Price.GetHashCode() + ProductName.GetHashCode() + Quantity.GetHashCode();
        }

        public override string ToString() {
            return $"OrderDetail:{Price},{ProductName},{Quantity}";
        }
    }
}