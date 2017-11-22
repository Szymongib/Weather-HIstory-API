using ApplicationCore.Models;
using ClientWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebsite.Controllers
{
    [Route("")]
    public class DataController : Controller
    {

        public DataController()
        {

        }

        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [Route("/GetAndSaveData")]
        public async Task<IActionResult> GetAndSaveData()
        {
            WeatherDataEntry dataEntry = await ExternalDataProvider.GetCurrentWeatherData();
            await HistoryAPIDataProvider.SaveDataInHistory(dataEntry);
            return View(dataEntry);
        }

        [Route("/GetDataFromHistoryApi")]
        public async Task<IActionResult> GetDataFromHistoryApi()
        {
            List<WeatherDataEntry> data = await HistoryAPIDataProvider.GetHistoryData();
            return View(data);
        }

        [Route("/DeleteDataFromHistoryApi")]
        public async Task<IActionResult> DeleteDataFromHistoryApi(int id)
        {
            await HistoryAPIDataProvider.DeleteDataFromHistory(id);
            return RedirectToAction("GetDataFromHistoryApi");
        }


    }
}
