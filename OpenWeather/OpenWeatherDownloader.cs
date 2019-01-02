using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using A_projekt;

namespace OpenWeather
{
    public class OpenWeatherDownloader : IWeatherPlugin
    {
        private string baseUrl =
            "http://api.openweathermap.org/data/2.5/weather?q=";
        private string apiKeyPrefix = "&APPID=";
        private string apiKey = "e09fa52b9d3dd89871061e362bfa84a9";
        private string others = "&mode=xml&units=metric";



        public WeatherData GetWeatherDataForCityName(string cityName)
        {
            string requestUrl = baseUrl + cityName + others + apiKeyPrefix + apiKey;

            XmlDocument data = DownloadDataInXML(requestUrl);

            if (data == null)
            {
                return null;
            }

            return parseDataToWeatherData(data);
        }

        private static XmlDocument DownloadDataInXML(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string xmlContent = client.DownloadString(url);
                    if (checkIfReturnError(xmlContent))
                    {
                        return null;
                    }
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(xmlContent);
                    return xmlDocument;
                }
                catch (WebException wex)
                {
                    if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        Debug.WriteLine("Město nebylo nalezeno");
                    }

                    Trace.WriteLine("Chyba při navazování komunikace se serverem");
                    return null;
                }

            }
        }

        private static WeatherData parseDataToWeatherData(XmlDocument data)
        {
            WeatherData resultData = new WeatherData();

            resultData.City = getCityName(data);
            resultData.Temperature = getTemperature(data);
            resultData.Humidity = getHumidity(data);
            resultData.WindSpeed = getWindSpeed(data);


            return resultData;
        }

        private static string getCityName(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//city");
            XmlAttribute name = node.Attributes["name"];
            return  name.Value;
        }

        private static float getTemperature(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//temperature");
            XmlAttribute value = node.Attributes["value"];
            // its in kelvin 
            return float.Parse(value.Value, CultureInfo.InvariantCulture);
        }

        private static int getHumidity(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//humidity");
            XmlAttribute value = node.Attributes["value"]; 
            return int.Parse(value.Value, CultureInfo.InvariantCulture);
        }

        private static float getWindSpeed(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//wind/speed");
            XmlAttribute value = node.Attributes["value"];
            return float.Parse(value.Value, CultureInfo.InvariantCulture);
        }
        private static bool checkIfReturnError(string xmlString)
        {
            if (xmlString.Contains("ClientError"))
            {
                return true;
            }

            return false;
        }
    }
}
