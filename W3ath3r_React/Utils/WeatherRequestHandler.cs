using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace W3ath3r_React.Utils
{
    public class WeatherRequestHandler
    {
        public string getDataFromApis(string zipcode)
        {
            UrlCreator urlCreator = new UrlCreator();
            JsonParser parser = new JsonParser();

            JObject jsonWeather;
            try
            {
                jsonWeather = getJsonWeather(urlCreator, zipcode);
            }
            catch (WebException)
            {
                return "null";
            }

            JToken temp = parser.getTemperature(jsonWeather);
            JToken cityName = parser.getCityName(jsonWeather);

            JObject jsonTimezone = getJsonTimezone(urlCreator, parser, jsonWeather);
            JToken timezoneName = parser.getTimezoneName(jsonTimezone);
            
            DateTime dateTime = DateTime.Now;

            return parser.createJSON(temp, cityName, timezoneName, dateTime);
        }

        private JObject getJsonWeather(UrlCreator urlCreator, string zipcode)
        {
            string weatherUrlTemplate = urlCreator.getWeatherUrlTemplate(zipcode);
            WebRequest req = WebRequest.Create(weatherUrlTemplate);
            using Stream response = req.GetResponse().GetResponseStream();
            using StreamReader reader = new StreamReader(response);
            var json = reader.ReadToEnd();
            return JObject.Parse(json);
        }

        private JObject getJsonTimezone(UrlCreator urlCreator, JsonParser parser, JObject jsonWeather)
        {
            string location = $"{parser.getLat(jsonWeather)},{parser.getLon(jsonWeather)}";
            string timestamp = parser.getTimestamp(jsonWeather);
            string timezoneUrlTemplate = urlCreator.getTimezoneUrlTemplate(location, timestamp);
            WebRequest req = WebRequest.Create(timezoneUrlTemplate);
            using Stream response = req.GetResponse().GetResponseStream();
            using StreamReader reader = new StreamReader(response);
            var json = reader.ReadToEnd();
            return JObject.Parse(json);
        }
    }
}