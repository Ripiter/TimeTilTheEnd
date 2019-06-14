using MyOpenWeatherApi;

namespace TimeTilTheEnd
{
    class WeatherTemperature
    {

        public string Temperature(string uCity = "Roskilde")
        {
            var client = new WeatherApi("7b14dbf4bb8322258a8b3e5e43ba0d3e");

            var results = client.Query(uCity);

            return "The temperature in " + uCity + " is " + results.TemperatureCel.CelsiusCurrent + "C.";
        }
    }
}
