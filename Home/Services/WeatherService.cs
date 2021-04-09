using Home.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Home.Services
{
    public class WeatherService
    {
        private string address = "http://dataservice.accuweather.com";
        private string url = "/forecasts/v1/daily/1day/299493?apikey=PPx92FHyCGEkYjjJQp9qvJX0Q2SsEuAW&metric=true";
        public async Task<Weather> GetWeatherForecast()
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(address);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET

                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    var jsonString = JsonConvert.DeserializeObject<Weather>(response);
                    return jsonString;
                }
            }
            throw new Exception();
        }
    }
}
