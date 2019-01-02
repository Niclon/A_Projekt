using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_projekt
{
    public interface IWeatherPlugin
    {
        WeatherData GetWeatherDataForCityName(string cityName);

    }
}
