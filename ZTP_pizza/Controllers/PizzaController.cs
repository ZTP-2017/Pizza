using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZTP_pizza.Services;
using ZTP_pizza.Data.Model;
using MongoDB.Bson;

namespace ZTP_pizza.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IDataService dataService;
        private static string selectedLang = "pl";

        public PizzaController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IActionResult Index()
        {
            var tuple = new Tuple<IEnumerable<Pizza>, string>(dataService.GetAll(), selectedLang);
            return View(tuple);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            dataService.AddPizza(pizza);

            var tuple = new Tuple<IEnumerable<Pizza>, string>(dataService.GetAll(), selectedLang);
            return RedirectToAction("Index", tuple);
        }

        [HttpGet]
        public IActionResult Details(string objectId)
        {
            var pizza = dataService.GetAll().FirstOrDefault(x => x.Id == new ObjectId(objectId));
            var content = dataService.GetPizzaContentByLang(pizza, selectedLang);

            return View(content);
        }

        [HttpGet]
        public IActionResult ChangeLang(string lang)
        {
            selectedLang = lang;
            var tuple = new Tuple<IEnumerable<Pizza>, string>(dataService.GetAll(), selectedLang);
            return RedirectToAction("Index", tuple);
        }
    }
}