using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;

namespace Restaurant.DAL.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private RestaurantContext db;
        public DishRepository(RestaurantContext db)
        {
            this.db = db;
        }
        public IEnumerable<Dish> GetAll()
        {
            var a = db.Dishes.Include(i => i.Ingredients);
            return a;
        }
        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Dishes.Where(predicate).ToList();
        }
        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }
        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);
        }
        public void Update(Dish dish)
        {
            var local = db.Set<Dish>().Local.FirstOrDefault(d => d.Id == dish.Id);
            if (local != null)
            {
                local.Name = dish.Name;
                local.PrepareTime = dish.PrepareTime;
                local.Price = dish.Price;

                db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            //db.Entry(dish).State = EntityState.Modified;
            //db.SaveChanges();
        }
        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if(dish != null)
            {
                db.Dishes.Remove(dish);
            }
        }
        public void DeleteRefer(int idWhere, int idWhat)
        {
            Dish dish = db.Dishes.Find(idWhere);
            Ingredient ingredient = db.Ingredients.Find(idWhat);
            if(dish != null && ingredient != null)
            {
                dish.Ingredients.Remove(ingredient);
            }
        }

        public void AddRefer(int idWhere, int idWhat)
        {
            Dish dish = db.Dishes.Find(idWhere);
            Ingredient ingredient = db.Ingredients.Find(idWhat);
            if(dish != null && ingredient != null)
            {
                dish.Ingredients.Add(ingredient);
            }
        }


        public List<Dish> GetListFromId(int idOrder)
        {
            var query = Find(n => n.Id == idOrder);
            var List = new List<Dish>();
            foreach (var item in query)
            {
                List.Add(item);
            }
            return List;
        }

        public Dish GetForName(string Name)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            return db.Dishes.LastOrDefault().Id;
        }

        public void Create(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetListForName(string Name)
        {
            return db.Dishes.Where(n => n.Name.Contains(Name)).ToList();
        }
    }
}
