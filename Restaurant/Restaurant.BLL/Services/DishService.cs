using System;
using System.Collections.Generic;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.DTO;
using Restaurant.BLL.BusinessModels;
using Restaurant.BLL.Infrastructure;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using AutoMapper;

namespace Restaurant.BLL.Services
{
    public class DishService : IDishService
    {
        IUnitOfWork Databese { get; set; }

        public DishService(IUnitOfWork uow)
        {
            Databese = uow;
        }
        public IEnumerable<IngredientsDTO> GetIngredients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ingredient, IngredientsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ingredient>, List<IngredientsDTO>>(Databese.Ingredients.GetAll());
        }
        public IEnumerable<IngredientsDTO> GetIngredientsFromId(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ingredient, IngredientsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ingredient>, List<IngredientsDTO>>(Databese.Ingredients.GetListFromId(id.Value));
        }
        public void Dispose()
        {
            Databese.Dispose();
        }
    }
}
