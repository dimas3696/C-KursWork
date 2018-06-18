using System;
using System.Collections.Generic;
using Restaurant.DAL.Entities;

namespace Restaurant.BLL.DTO
{
    public class IngredientsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DishesDTO> Dishes { get; set; }
        public IngredientsDTO()
        {
            Dishes = new List<DishesDTO>();
        }
    }
}
