using Microsoft.AspNetCore.Mvc;
using W3ath3r_React.Utils;

namespace W3ath3r_React.Controllers
{
    public class HomeController : Controller
    {
        public string Weather(string zipcode)
        {
            WeatherRequestHandler handler = new WeatherRequestHandler();
            string data = handler.getDataFromApis(zipcode);
            return data;
        }
    }
}