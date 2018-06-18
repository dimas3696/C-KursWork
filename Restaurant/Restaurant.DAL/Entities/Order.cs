using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int DishesCount { get; set; }
        public decimal ResultOrderPrice { get; set; }
        public int OrderTableNumber { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
        public Order()
        {
            Dishes = new List<Dish>();
        }
    }
}
