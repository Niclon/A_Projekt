using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using A_projekt;

namespace WorldWeather
{
    public class WorldWeatherDownloader : IWeatherPlugin
    {
        private string baseUrl =
            "https://api.worldweatheronline.com/premium/v1/weather.ashx?key=";
        private string apiKey = "438cb41fd7884473a9f110145183012";
        private string cityPrefix = "&q=";
        private string format = "&format=xml&num_of_days=0&fx=no&mca=no";
        public WeatherData GetWeatherDataForCityName(string cityName)
        {

            string requestUrl = baseUrl + apiKey + cityPrefix + cityName + format;

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
            XmlNode node = data.SelectSingleNode("//request/query");
            return node.InnerText;
        }

        private static float getTemperature(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//current_condition/temp_C");
            return float.Parse(node.InnerText, CultureInfo.InvariantCulture);
        }

        private static int getHumidity(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//current_condition/humidity");
            return int.Parse(node.InnerText, CultureInfo.InvariantCulture);
        }

        private static float getWindSpeed(XmlDocument data)
        {
            XmlNode node = data.SelectSingleNode("//current_condition/windspeedKmph");
            double toMs = double.Parse(node.InnerText, CultureInfo.InvariantCulture) / 3.6;
            return float.Parse(toMs.ToString());
        }

        private static bool checkIfReturnError(string xmlString)
        {
            if (xmlString.Contains("error"))
            {
                return true;
            }

            return false;
        }
    }
}
