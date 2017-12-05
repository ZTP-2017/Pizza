using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using ZTP_pizza.Services.Interfaces;

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

            foreach (var pizza in _dataService.GetAll())
            {
                var content = _dataService.GetPizzaContentByLang(pizza, lang);
                result.Add(content.ToJson());
            }
            
            return Json(result);
        }
    }
}