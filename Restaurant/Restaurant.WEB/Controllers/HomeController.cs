using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BLL.Infrastructure;
using Restaurant.BLL.DTO;
using Restaurant.WEB.Models;
using AutoMapper;
using Restaurant.BLL.Interfaces;

namespace Restaurant.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<DishesDTO> dishesDTOs = orderService.GetDishes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DishesDTO, DishesViewModel>().MaxDepth(3)).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishesDTO>, List<DishesViewModel>>(dishesDTOs);
            return View(dishes);
        }

        public ActionResult Edit(int dishId, string newName, int newPrepareTime, string newPriceString)
        {
            var newPriceDecimal = Convert.ToDecimal(newPriceString);
            var dishOriginal = orderService.GetDishes(dishId);
            dishOriginal.Name = newName;
            dishOriginal.PrepareTime = newPrepareTime;
            dishOriginal.Price = newPriceDecimal;

            if (dishOriginal == null)
            {
                return HttpNotFound();
            }

            orderService.Update(dishOriginal);
            return Redirect("/Home/Index");
        }

        public ActionResult DeleteIngredient(int idDish, int idIngredient)
        {
            orderService.DeleteRefer(idDish, idIngredient);
            return Redirect("/Home/Index");
        }

        public ActionResult AddIngredient(string ingredientName, int idWhere)
        {
            //Get ingredient for name
            var ingredientsDTO = orderService.GetIngredient(ingredientName);
            IngredientsDTO ingredientsDTOFinal = new IngredientsDTO();
            //get dish for link in ingredient.Dishes
            DishesDTO dishesDTO = orderService.GetDishes(idWhere);
            if(ingredientsDTO == null)
            {
                ingredientsDTOFinal.Id = orderService.GetLastIdIngredient() + 1;
                ingredientsDTOFinal.Name = ingredientName;
                ingredientsDTOFinal.Dishes.Add(dishesDTO);
                orderService.AddRefer(idWhere, ingredientsDTOFinal);
            }
            else
            {
                ingredientsDTO.Dishes.Add(dishesDTO);
                orderService.AddRefer(idWhere, ingredientsDTO);
            }

            return Redirect("/Home/Index");
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}