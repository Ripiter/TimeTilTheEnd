using MyOpenWeatherApi;

namespace TimeTilTheEnd
{
    class WeatherTemperature
    {
        public string Temperature(string uCity = "Roskilde")
        {
            string message;
            try
            {
                var client = new WeatherApi("7b14dbf4bb8322258a8b3e5e43ba0d3e");

                var results = client.Query(uCity);

                message = "The temperature in " + uCity + " is " + results.TemperatureCel.CelsiusCurrent + "C.";
            }
            catch (System.Exception e)
            {
                message = e.Message;
            }

            return message;
        }
    }
}
