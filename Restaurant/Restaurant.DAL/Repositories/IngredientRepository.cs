using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System.Data.Entity;

namespace Restaurant.DAL.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private RestaurantContext db;
        public IngredientRepository(RestaurantContext db)
        {
            this.db = db;
        }
        public IEnumerable<Ingredient> GetAll()
        {
            return db.Ingredients;
        }
        public Ingredient Get(int id)
        {
            var a = db.Ingredients.Find(id);
            return a;
        }
        public void Create(Ingredient ing)
        {
            db.Ingredients.Add(ing);
        }
        public void Create(string ingName)
        {
            Ingredient newIng = new Ingredient { Name = ingName };
            db.Ingredients.Add(newIng);
        }
        public void Update(Ingredient ing)
        {
            db.Entry(ing).State = EntityState.Modified;
        }
        public IEnumerable<Ingredient> Find(Func<Ingredient, Boolean> predicate)
        {
            return db.Ingredients.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Ingredient ing = db.Ingredients.Find(id);
            if(ing != null)
            {
                db.Ingredients.Remove(ing);
            }
        }

        public List<Ingredient> GetListFromId(int idDish)
        {
            var query = Find(n => n.Id == idDish);
            var List = new List<Ingredient>();
            foreach (var item in query)
            {
                List.Add(item);
            }
            return List;
        }

        public void DeleteRefer(int id, int id2)
        {
            throw new NotImplementedException();
        }

        public void AddRefer(int idWhere, int idWhat)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetForName(string Name)
        {
            return db.Ingredients.SingleOrDefault(n => n.Name.Equals(Name));
        }

        public int GetLastId()
        {
            //ERROR
            var id = (from m in db.Ingredients select m.Id).ToList().Last();
            return id;
        }

        public IEnumerable<Ingredient> GetListForName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
