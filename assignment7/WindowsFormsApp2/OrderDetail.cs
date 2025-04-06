using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    [Table("order_details")]
    public class OrderDetail : INotifyPropertyChanged
    {
        private string _productName;
        private decimal _unitPrice;
        private int _quantity;

        [Key]
        [Column("detail_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("product_name")]
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
                OnPropertyChanged(nameof(Amount));
            }
        }

        [Column("unit_price")]
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
                OnPropertyChanged(nameof(Amount));
            }
        }

        [Column("quantity")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Amount));
            }
        }

        [NotMapped]
        public decimal Amount => UnitPrice * Quantity;

        [ForeignKey("Order")]
        [Column("order_id")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}