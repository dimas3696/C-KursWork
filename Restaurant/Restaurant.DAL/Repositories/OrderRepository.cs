using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;

namespace Restaurant.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private RestaurantContext db;
        public OrderRepository(RestaurantContext db)
        {
            this.db = db;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
        }
        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if(order != null)
            {
                db.Orders.Remove(order);
            }
        }
        public List<Order> GetListFromId(int idOrder)
        {
            throw new NotImplementedException();
        }

        public void DeleteRefer(int id,int id2)
        {
            throw new NotImplementedException();
        }

        public void AddRefer(int idWhere, int idWhat)
        {
            throw new NotImplementedException();
        }

        public Order GetForName(string Name)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            return db.Orders.LastOrDefault().Id;
        }

        public void Create(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetListForName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
