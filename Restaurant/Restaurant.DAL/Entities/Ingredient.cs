﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Ingredient
    {
        public int  Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
        public Ingredient()
        {
            Dishes = new List<Dish>();
        }
    }
}
