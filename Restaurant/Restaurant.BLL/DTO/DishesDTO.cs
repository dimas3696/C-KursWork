using System;
using System.Collections.Generic;
using Restaurant.DAL.Entities;

namespace Restaurant.BLL.DTO
{
    public class DishesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PrepareTime { get; set; }
        //public List<IngredientsDTO> IngredientsInDish { get; set; } 

        public virtual ICollection<IngredientsDTO> Ingredients { get; set; }
        public virtual ICollection<OrdersDTO> Orders { get; set; }
        public DishesDTO()
        {
            Ingredients = new List<IngredientsDTO>();
            Orders = new List<OrdersDTO>();
        }
    }
}
