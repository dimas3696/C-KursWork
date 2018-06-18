using System;
using System.Collections.Generic;
using Restaurant.BLL.DTO;

namespace Restaurant.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrdersDTO ordersDTO);
        DishesDTO GetDishes(int? id);
        IEnumerable<DishesDTO> GetDishes();
        IEnumerable<DishesDTO> GetDishesInOrder(int? id);
        void Update(DishesDTO dishesDTO);
        IEnumerable<DishesDTO> GetListDishesForName(string Name);
        void Dispose();
        void DeleteRefer(int idWhere, int idWhat);
        void AddRefer(int idWhere, IngredientsDTO ingredientsDTO);
        IngredientsDTO GetIngredient(string Name);
        int GetLastIdIngredient();
    }
}
