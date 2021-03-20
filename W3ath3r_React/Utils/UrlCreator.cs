namespace W3ath3r_React.Utils
{
    public class UrlCreator
    {
        private readonly string weatherApiKey = "9bc1c99e6f6bdaaaa24fc7d5eb962fe4";
        private string weatherUnits = "metric"; //Units of temperature measurement. Details: https://openweathermap.org/current#data
        private readonly string timezoneApiKey = "AIzaSyCJPgm55DqUJ1KqQPqcTH4608MCSlKjyUY";

        public string getWeatherUrlTemplate(string zipcode)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?zip={zipcode}&units={weatherUnits}&appid={weatherApiKey}";
        }

        public string getTimezoneUrlTemplate(string location, string timestamp)
        {
            return $"https://maps.googleapis.com/maps/api/timezone/json?location={location}&timestamp={timestamp}&key={timezoneApiKey}";
        }
    }
}