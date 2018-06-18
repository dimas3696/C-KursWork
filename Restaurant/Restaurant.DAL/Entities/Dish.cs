using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PrepareTime { get; set; }
        //public List<Ingredient> IngredientsInDish { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Dish()
        {
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
        }
    }
}
