using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DAL.Entities;

namespace Restaurant.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Dish> Dishes { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
