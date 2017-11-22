using ApplicationCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Data
{
    public static class HistoryAPIDataProvider
    {

        static HttpClient client = new HttpClient();

        public static async Task Initialize()
        {
            client.BaseAddress = new Uri($"http://localhost:60165/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task SaveDataInHistory(WeatherDataEntry dataEntry)
        {
            string jsonInString = JsonConvert.SerializeObject(dataEntry);
            await client.PostAsync("http://localhost:60165/api/values", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
        }


        public static async Task<List<WeatherDataEntry>> GetHistoryData()
        {
            string path = "api/values";

            HttpResponseMessage responseMessage = await client.GetAsync(path);

            if (responseMessage.IsSuccessStatusCode)
            {
                string response = await responseMessage.Content.ReadAsStringAsync();
                
                List<WeatherDataEntry> data = (List<WeatherDataEntry>)JsonConvert.DeserializeObject(response, typeof(List<WeatherDataEntry>));

                return data;
            }
            else
            {
                throw new Exception($"Response message failed with code: {responseMessage.StatusCode}.");
            }
        }


        public static async Task<bool> DeleteDataFromHistory(int id)
        {
            string path = "api/values/" + id.ToString();
            HttpResponseMessage responseMessage = await client.DeleteAsync(path);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}
