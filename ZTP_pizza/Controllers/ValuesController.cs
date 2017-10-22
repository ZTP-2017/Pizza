using Microsoft.AspNetCore.Mvc;
using ZTP_pizza.Services;
using MongoDB.Bson;
using System.Collections.Generic;

namespace ZTP_pizza.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDataService dataService;

        public ValuesController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        // GET api/values
        [HttpGet]
        public string Get(string lang)
        {
            var result = new List<string>();

            foreach (var pizza in dataService.GetAll())
            {
                var content = dataService.GetPizzaContentByLang(pizza, lang);
                result.Add(content.ToJson());
            }
            
            return result.ToJson();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}