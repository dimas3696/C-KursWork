using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.WEB.Models
{
    public class DishesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PrepareTime { get; set; }
        //public List<IngredientsViewModel> IngredientsInDish { get; set; }

        public virtual ICollection<IngredientsViewModel> Ingredients { get; set; }
        public virtual ICollection<DishesViewModel> Dishes { get; set; }
    }
}