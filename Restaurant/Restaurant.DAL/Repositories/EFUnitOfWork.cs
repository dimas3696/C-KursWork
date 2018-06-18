using System;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;

namespace Restaurant.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RestaurantContext db;
        private IngredientRepository ingredientRepository;
        private DishRepository dishRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectingString)
        {
            db = new RestaurantContext(connectingString);
        }
        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                {
                    ingredientRepository = new IngredientRepository(db);
                }
                return ingredientRepository;
            }
        }
        public IRepository<Dish> Dishes
        {
            get
            {
                if(dishRepository == null)
                {
                    dishRepository = new DishRepository(db);
                }
                return dishRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
