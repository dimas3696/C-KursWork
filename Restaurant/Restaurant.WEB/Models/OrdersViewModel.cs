using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.BLL.DTO;

namespace Restaurant.WEB.Models
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public int DishesCount { get; set; }
        public decimal ResultPrice { get; set; }
        public int OrderTableNumber { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<DishesDTO> Dishes { get; set; }
    }
}