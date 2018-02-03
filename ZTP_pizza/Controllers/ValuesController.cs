using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Bson;
using ZTP_pizza.Data.Interfaces;

namespace ZTP_pizza.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDataService _dataService;

        public ValuesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult Get(string lang)
        {
            var result = new List<string>();

            foreach (var pizza in _dataService.GetAllPizza())
            {
                var content = _dataService.GetPizzaContentByLanguageCode(pizza, lang);
                result.Add(content.ToJson());
            }
            
            return Json(result);
        }
    }
}