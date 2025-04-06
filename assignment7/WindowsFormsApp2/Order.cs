using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WindowsFormsApp2
{
    [Table("orders")]
    public class Order : INotifyPropertyChanged
    {
        private string _customerName;

        [Key]
        [Column("order_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("customer_name")]
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }

        [Column("order_date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual ICollection<OrderDetail> Details { get; set; } = new BindingList<OrderDetail>();

        [NotMapped]
        public decimal TotalAmount => Details?.Sum(d => d.Amount) ?? 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}