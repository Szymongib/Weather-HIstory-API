using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;
using WeatherHistoryAPI.Data;
using Newtonsoft.Json;

namespace WeatherHistoryAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ApplicationDbContext _context;


        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<WeatherDataEntry> Get()
        {
            _context.Database.EnsureCreated();

            return _context.WeatherDataEntries.AsEnumerable();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public WeatherDataEntry Get(int id)
        {
            return _context.WeatherDataEntries.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]dynamic value)
        {
            WeatherDataEntry dataEntry = (WeatherDataEntry) JsonConvert.DeserializeObject(value.ToString(), typeof(WeatherDataEntry));

            _context.WeatherDataEntries.Add(dataEntry);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            WeatherDataEntry dataEntry = _context.WeatherDataEntries.Find(id);
            _context.WeatherDataEntries.Remove(dataEntry);
            _context.SaveChanges();
        }
    }
}
