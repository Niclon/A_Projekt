using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace A_projekt
{
    public class WeatherData
    {
        public string City { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }

    }


}