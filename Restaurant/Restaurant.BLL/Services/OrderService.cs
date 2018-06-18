using System;
using System.Collections.Generic;
using Restaurant.BLL.DTO;
using Restaurant.BLL.BusinessModels;
using Restaurant.BLL.Infrastructure;
using Restaurant.BLL.Interfaces;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using AutoMapper;

namespace Restaurant.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrdersDTO ordersDTO)
        {
            var dish = Database.Dishes.GetListFromId(ordersDTO.Id);
            foreach(var p in dish)
            {
                ordersDTO.ResultPrice = p.Price;
            }

            //validating
            if (dish == null)
            {
                throw new ValidationException("Извините, но такого блюда у нас нет", "");
            }
            //make discount
            decimal sum = new Discount(0.2m).GetDiscountPrice(ordersDTO.ResultPrice);
            Order orders = new Order
            {
                DishesCount = dish.Count,
                ResultOrderPrice = sum,
                OrderTableNumber = ordersDTO.OrderTableNumber,
                Date = DateTime.Now                
            };
            Database.Orders.Create(orders);
            Database.Save();
        }

        public IEnumerable<DishesDTO> GetDishes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishesDTO>().MaxDepth(3)).CreateMapper();
            return mapper.Map<IEnumerable<Dish>, List<DishesDTO>> (Database.Dishes.GetAll());
        }

        public IEnumerable<DishesDTO> GetDishesInOrder(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dish>, List<DishesDTO>>(Database.Dishes.GetListFromId(id.Value));
        }

        public DishesDTO GetDishes(int? id)
        {
            
            if (id == null)
            {
                throw new ValidationException("Не установлено id блюда", "");
            }
            var dish = Database.Dishes.Get(id.Value);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishesDTO>().MaxDepth(3)).CreateMapper();
            var dishDTO = mapper.Map<Dish, DishesDTO>(dish);
            

            return dishDTO;
        }

        public void Update(DishesDTO dishDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DishesDTO, Dish>().MaxDepth(3)).CreateMapper();
            var dishCorrect = mapper.Map<DishesDTO, Dish>(dishDTO);

            Dish dish = new Dish
            {
                Id = dishCorrect.Id,
                Name = dishDTO.Name,
                PrepareTime = dishCorrect.PrepareTime,
                Price = dishCorrect.Price
            };
            Database.Dishes.Update(dish);
            Database.Save();
        }

        public void DeleteRefer(int idWhere, int idWhat)
        {
            Database.Dishes.DeleteRefer(idWhere, idWhat);
            Database.Save();
        }

        public void AddRefer(int idWhere, IngredientsDTO ingredientsDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IngredientsDTO, Ingredient>().MaxDepth(3)).CreateMapper();
            var ingredient = mapper.Map<IngredientsDTO, Ingredient>(ingredientsDTO);

           
            var ingredientFound = Database.Ingredients.Get(ingredient.Id);
            if (ingredientFound == null)
            {
                //проблема тут
                Database.Ingredients.Create(ingredient.Name);
                Database.Save();
                ingredientFound = Database.Ingredients.GetForName(ingredient.Name);
                //Database.Ingredients.Create(ingredientFound);
                //ingredientFound = Database.Ingredients.Get(ingredientFound.Id);//this mast work uncorrect
                //Database.Dishes.AddRefer(idWhere, ingredient.Id);
                Database.Dishes.AddRefer(idWhere, ingredientFound.Id);
                Database.Save();
            }
            else
            {
                Database.Dishes.AddRefer(idWhere, ingredient.Id);
                Database.Save();
            }

        }

        public IngredientsDTO GetIngredient(string Name)
        {
            if (Name == "")
            {
                throw new ValidationException("Не установлено название ингредиента", "");
            }
            var ingredient = Database.Ingredients.GetForName(Name);
            //ingredient.Dishes = null;
            if (ingredient == null)
            {
                //throw new ValidationException("Ингредиент не найден", "");
                return null;
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ingredient, IngredientsDTO>().MaxDepth(0).ForPath(d=>d.Dishes, i=>i.Ignore())).CreateMapper();
            var ingredientsDTO = mapper.Map<IngredientsDTO>(ingredient);

            return ingredientsDTO;
        }

        public int GetLastIdIngredient()
        {
            return Database.Ingredients.GetLastId();
        }

        public IEnumerable<DishesDTO> GetListDishesForName(string Name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishesDTO>().MaxDepth(3)).CreateMapper();
            return mapper.Map<IEnumerable<Dish>, List<DishesDTO>>(Database.Dishes.GetListForName(Name));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
