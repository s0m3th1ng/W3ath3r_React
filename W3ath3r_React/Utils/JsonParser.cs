using System;
using Newtonsoft.Json.Linq;

namespace W3ath3r_React.Utils
{
    public class JsonParser
    {
        public JToken getTemperature(JObject jsonWeather)
        {
            return jsonWeather.SelectToken("main.temp");
        }
        public JToken getCityName(JObject jsonWeather)
        {
            return jsonWeather.SelectToken("name");
        }
        public string getTimestamp(JObject jsonWeather)
        {
            return (string) jsonWeather.SelectToken("dt");
        }
        public string getLat(JObject jsonWeather)
        {
            return (string) jsonWeather.SelectToken("coord.lat");
        }
        public string getLon(JObject jsonWeather)
        {
            return (string) jsonWeather.SelectToken("coord.lon");
        }
        public JToken getTimezoneName(JObject jsonTimezone)
        {
            return jsonTimezone.SelectToken("timeZoneName");
        }
        public string createJSON(JToken temp, JToken cityName, JToken timezoneName, DateTime dateTime)
        {
            JObject data = new JObject
            {
                {"dateTime", dateTime.ToString("MM'/'dd HH:mm:ss")},
                {"temp", temp},
                {"cityName", cityName},
                {"timezoneName", timezoneName}
            };

            return data.ToString();
        }
    }
}