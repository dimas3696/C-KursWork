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
    public class FindDishController : Controller
    {
        IOrderService orderService;
        public FindDishController(IOrderService serv)
        {
            orderService = serv;
        }
        // GET: FindDish
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindDish(string name)
        {
            var FoundDishes = orderService.GetListDishesForName(name).ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DishesDTO, DishesViewModel>().MaxDepth(3)).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishesDTO>, List<DishesViewModel>>(FoundDishes);
            if (dishes.Count <= 0)
            {
                ViewBag.Error = "Такого блюда у нас нет ¯\\_(ツ)_/¯";
                return PartialView("_FindDish", new List<DishesViewModel>());
            }
            return PartialView("_FindDish", dishes);
        }
    }
}