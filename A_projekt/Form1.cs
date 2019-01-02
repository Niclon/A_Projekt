using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using A_projekt.Resources;

namespace A_projekt
{
    public partial class Form1 : Form
    {
        private WeatherData currentData;
        private IWeatherPlugin curreWeatherPlugin; 

        public Form1()
        {
            InitializeComponent();
            ChangeCultureLanguageAndShow("en-US");
            fillComboboxWithPlugins();
            initializeFileWatcher();
        }

        private void ChangeCultureLanguageAndShow(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            ChangeLabelsText();

        }

        private void ChangeLabelsText()
        {
            cityNameLabel.Text = Res.cityName;
            cityLabel.Text = Res.cityName;
            temperatureLabel.Text = Res.temperature;
            humidityLabel.Text = Res.humidity;
            windSpeedLabel.Text = Res.windSpeed;
            findButton.Text = Res.find;
            loadButton.Text = Res.load;
            saveButton.Text = Res.save;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pluginSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            object variable;
            string selected = pluginSelector.Items[pluginSelector.SelectedIndex].ToString();
            Debug.WriteLine("Uživatel vybral plugin " + selected);

            try
            {
                string pathPrefix = "./Plugins//";
                string nameOfClass = selected.Split('.')[0] + "Downloader";
                

                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(pathPrefix + selected));

                Type type = assembly.GetType(selected.Split('.')[0] + '.' + nameOfClass);
                if (type != null)
                {
                    variable = Activator.CreateInstance(type);
                    if (variable is IWeatherPlugin)
                    {
                        curreWeatherPlugin = (IWeatherPlugin)variable;
                        Debug.WriteLine("Asembly " + selected + " byla načtena");
                    }
                    else
                    {
                        Trace.WriteLine("Nelze načíst assembly: " + selected);
                        Debug.WriteLine("Nelze načíst assembly: " + selected);
                        throw new InterfaceException("Tento plugin neimplementuje požadované rozhraní " + selected);
                    }
                }
            }
            catch (PluginException ex) { throw new PluginException("Nelze načíst dll soubor pluginu " + ex.Message); }
        }

        private void fillComboboxWithPlugins()
        {
            Debug.WriteLine("Plnění plugin combo boxu.");
            // todo rewrite in lambda
            foreach (string file in Directory.EnumerateFiles("./Plugins", "*.dll"))
            {
                //  ./Plugins\\OpenWeather.dll
                pluginSelector.Items.Add(file.Split('\\')[1]);
            }
        }

        private void initializeFileWatcher()
        {
            FileSystemWatcher w = new FileSystemWatcher("./Plugins", "*.dll");
            w.Created += WOnCreated;
            w.Deleted += WOnDeleted;
            w.EnableRaisingEvents = true;
        }

        private void WOnDeleted(object sender, FileSystemEventArgs e)
        {
            string text = Res.pluginDeleted;
            MessageBox.Show(text);
        }

        private static void WOnCreated(object sender, FileSystemEventArgs e)
        {
            string text = Res.pluginAdded;
            MessageBox.Show(text);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (this.curreWeatherPlugin == null)
            {
                string text = Res.sourceNotChosen;
                MessageBox.Show(text);
                return;
            }
            else
            {
                if (cityName.Text.Length < 2)
                {
                    string text = Res.typeCityNameCorrectly;
                    MessageBox.Show(text);
                    return;
                }
                Debug.WriteLine("Hledání města jménem " + cityName.Text);
                currentData = curreWeatherPlugin.GetWeatherDataForCityName(cityName.Text);

                if (currentData==null)
                {
                    Debug.WriteLine("Město nebylo nalezeno");
                    Trace.WriteLine("Město nebylo nalezeno");
                    MessageBox.Show(Res.cityNotFound);
                    return;
                }

                fillLabelsWithData(currentData);

            }
        }

        private void fillLabelsWithData(WeatherData data)
        {
            Debug.WriteLine("Plnění dat do UI");
            cityNameData.Text = data.City;
            humidityData.Text = data.Humidity.ToString() + " %";
            temperatureData.Text = data.Temperature.ToString() + " C°";
            windSpeedData.Text = data.WindSpeed.ToString() + " m/s";
            Debug.WriteLine("Plnění dat do UI dokončeno");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.curreWeatherPlugin == null)
            {
                string text = Res.sourceNotChosen;
                MessageBox.Show(text);
                return;
            }

            if (currentData == null)
            {
                Debug.WriteLine("Nemůžeme uložit nic");

                string text = Res.cantSaveNothing;
                MessageBox.Show(text);
                return;
            }
            Debug.WriteLine("Ukládání dat");

            string selected = pluginSelector.Items[pluginSelector.SelectedIndex].ToString();
            saveDataToDisk(selected.Split('.')[0], currentData);

            string text1 = Res.saved;
            MessageBox.Show(text1);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (this.curreWeatherPlugin == null)
            {
                string text = Res.sourceNotChosen;
                MessageBox.Show(text);
                return;
            }

            string selected = pluginSelector.Items[pluginSelector.SelectedIndex].ToString();

            currentData = loadDataFromDisk(selected.Split('.')[0]);

            fillLabelsWithData(currentData);

            string text1 = Res.load;
            MessageBox.Show(text1);
        }

        private WeatherData loadDataFromDisk(string pluginName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

                StreamReader reader = new StreamReader(pluginName);
                WeatherData data = (WeatherData)serializer.Deserialize(reader);
                reader.Close();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("XmlDeserialization", ex);
            }
        }

        public void saveDataToDisk(string pluginName, WeatherData data)
        {
            try
            {
                var xmlserializer = new XmlSerializer(typeof(WeatherData));

                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, data);
                    File.WriteAllText(pluginName, stringWriter.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Neco se serializaci");
                Trace.WriteLine("Neco se serializaci");

                throw new Exception("XmlSerialization", ex);
            }
        }

        private void enToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCultureLanguageAndShow("en-US");
        }

        private void csCzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCultureLanguageAndShow("cs-CZ");
        }
    }
}
