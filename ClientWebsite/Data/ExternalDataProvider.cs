using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ClientWebsite.Data
{
    public static class ExternalDataProvider
    {
        static string APIkey = "55e7441735e0ed84af376919784e7759";
        static string CityId = "7530857";   // Gliwice

        static HttpClient client = new HttpClient();

        //         "id": 7530857,
        //         "name": "Gliwice",
        //         "country": "PL",

        public static async Task Initialize()
        {
            client.BaseAddress = new Uri($"http://api.openweathermap.org/data/2.5/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public static async Task<WeatherDataEntry> GetCurrentWeatherData()
        {
            string path = "weather?id=" + CityId + "&APPID=" + APIkey;

            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var respone = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(respone);

                WeatherDataEntry dataEntry = new WeatherDataEntry();

                dataEntry.MeasurementDate = UnixTimeStampToDateTime((double)jsonResponse["dt"]);
                dataEntry.Sunrise = UnixTimeStampToDateTime((double)jsonResponse["sys"]["sunrise"]);
                dataEntry.Sunset = UnixTimeStampToDateTime((double)jsonResponse["sys"]["sunset"]);
                dataEntry.CityId = (int)jsonResponse["id"];
                dataEntry.CityName = (string)jsonResponse["name"];
                dataEntry.MainWeather = (string)jsonResponse["weather"][0]["main"];
                dataEntry.WeatherDescription = (string)jsonResponse["weather"][0]["description"];
                dataEntry.Temperature = ((double)jsonResponse["main"]["temp"]).KelvinToCelsius();
                dataEntry.Pressure = (int)jsonResponse["main"]["pressure"];
                dataEntry.Humidity = (int)jsonResponse["main"]["humidity"];
                dataEntry.MinTemperature = ((double)jsonResponse["main"]["temp_min"]).KelvinToCelsius();
                dataEntry.MaxTemperature = ((double)jsonResponse["main"]["temp_max"]).KelvinToCelsius();
                dataEntry.WindSpeed = (double)jsonResponse["wind"]["speed"];
                dataEntry.Cloudiness = (int)jsonResponse["clouds"]["all"];
                dataEntry.RainVolume = (int?)jsonResponse["rain"]?["rain.3h"] ?? null;
                dataEntry.SnowVolume = (int?)jsonResponse["snow"]?["snow.3h"];

                return dataEntry;
            }
            else
            {
                throw new Exception();
            }
        }

        
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private static double KelvinToCelsius(this double temp)
        {
            return temp - 272.15;
        }


        
    }
}
