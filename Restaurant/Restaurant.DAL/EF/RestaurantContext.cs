using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Restaurant.DAL.Entities;

namespace Restaurant.DAL.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }

        static RestaurantContext()
        {
            Database.SetInitializer<RestaurantContext>(new StoreDbInitializer());
        }

        public RestaurantContext(string connectionString):base(connectionString)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                        .HasMany(i => i.Dishes).WithMany(d => d.Ingredients)
                        .Map(t => t.MapLeftKey("Ingredient_Id")
                        .MapRightKey("Dish_Id")
                        .ToTable("IngredientDishes"));

            modelBuilder.Entity<Dish>()
                        .HasMany(d => d.Orders).WithMany(o => o.Dishes)
                        .Map(t => t.MapLeftKey("Dish_Id")
                        .MapRightKey("Order_Id")
                        .ToTable("OrderDishes"));
        }

    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext db)
        {
            Ingredient ingredient1 = new Ingredient { Name = "Молоко" };
            Ingredient ingredient2 = new Ingredient { Name = "Яйца" };
            Ingredient ingredient3 = new Ingredient { Name = "Мука" };
            Ingredient ingredient4 = new Ingredient { Name = "Растительное масло" };
            Ingredient ingredient5 = new Ingredient { Name = "Сахар" };
            Ingredient ingredient6 = new Ingredient { Name = "Соль" };

            List<Ingredient> ingredientsDish1 = new List<Ingredient>() { ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6 };

            db.Ingredients.AddRange(ingredientsDish1);
            db.SaveChanges();

            Ingredient ingredient7 = new Ingredient { Name = "Картофель" };
            Ingredient ingredient8 = new Ingredient { Name = "Лук" };
            Ingredient ingredient9 = new Ingredient { Name = "Капуста" };
            Ingredient ingredient10 = new Ingredient { Name = "Зелень" };
            Ingredient ingredient11 = new Ingredient { Name = "Вода" };

            db.Ingredients.Add(ingredient7);
            db.Ingredients.Add(ingredient8);
            db.Ingredients.Add(ingredient9);
            db.Ingredients.Add(ingredient10);
            db.Ingredients.Add(ingredient11);
            db.SaveChanges();

            Ingredient ingredient12 = new Ingredient { Name = "Перец" };
            Ingredient ingredient13 = new Ingredient { Name = "Морковь" };

            db.Ingredients.Add(ingredient12);
            db.Ingredients.Add(ingredient13);
            db.SaveChanges();

            Dish dish1 = new Dish
            {
                Name = "Блинчики",
                Ingredients = ingredientsDish1,
                PrepareTime = 30,
                Price = 50
            };
            Dish dish2 = new Dish
            {
                Name = "Суп",
                Ingredients = new List<Ingredient>() { ingredient7, ingredient8, ingredient9, ingredient10, ingredient4, ingredient6 },
                PrepareTime = 40,
                Price = 65
            };
            Dish dish3 = new Dish
            {
                Name = "Молодой картофель",
                Ingredients = new List<Ingredient>() { ingredient7, ingredient11, ingredient10, ingredient4, ingredient6 },
                PrepareTime = 40,
                Price = 48
            };
            Dish dish4 = new Dish
            {
                Name = "Яичный рол",
                Ingredients = new List<Ingredient>() { ingredient2, ingredient6, ingredient12, ingredient8, ingredient13, },
                PrepareTime = 10,
                Price = 35
            };

            db.Dishes.Add(dish1);
            db.Dishes.Add(dish2);
            db.Dishes.Add(dish3);
            db.Dishes.Add(dish4);
            db.SaveChanges();

            Order order1 = new Order
            {
                Dishes = new List<Dish>() { dish2, dish1 },
                DishesCount = 2,
                ResultOrderPrice = dish1.Price + dish2.Price,
                OrderTableNumber = 1,
                Date = new DateTime(2018, 5, 20, 12, 30, 0) { }
            };
            Order order2 = new Order
            {
                Dishes = new List<Dish>() { dish2, dish3, dish4 },
                DishesCount = 3,
                ResultOrderPrice = dish2.Price + dish3.Price + dish4.Price,
                Date = new DateTime(2018, 5, 20, 14, 50, 30) { }
            };

            db.Orders.Add(order1);
            db.Orders.Add(order2);
            db.SaveChanges();


        }
    }
}
