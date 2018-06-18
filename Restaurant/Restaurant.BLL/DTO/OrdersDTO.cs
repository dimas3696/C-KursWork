using System;
using System.Collections.Generic;
using Restaurant.DAL.Entities;

namespace Restaurant.BLL.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public int DishesCount { get; set; }
        public decimal ResultPrice { get; set; }
        public int OrderTableNumber { get; set; }

        public DateTime? Date { get; set; }
        public virtual ICollection<DishesDTO> Dishes { get; set; }
        public OrdersDTO()
        {
            Dishes = new List<DishesDTO>();
        }
    }
}
