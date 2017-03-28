using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{

    public class Rental
    {
        public int RentalId { get; set; }
        public string RentalType { get; set; }
        public decimal RentalPrice { get; set; }
        public int ItemId { get; set; }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryId { get; set; }

    }
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public int OrderedBy { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int RentalId { get; set; }
        public int ItemId { get; set; }
        public DateTime? ReserveDate { get; set; }
        public string PickupTimeSlot { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
