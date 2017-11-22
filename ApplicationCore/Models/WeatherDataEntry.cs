using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class WeatherDataEntry
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public DateTime MeasurementDate { get; set; }

        public string MainWeather { get; set; }
        public string WeatherDescription { get; set; }

        public double Temperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public double WindSpeed { get; set; }
        public int Cloudiness { get; set; }

        public int? RainVolume { get; set; }
        public int? SnowVolume { get; set; }

        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }

    }
}
