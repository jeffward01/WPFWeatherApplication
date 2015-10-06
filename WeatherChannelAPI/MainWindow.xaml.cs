using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Net;

namespace WeatherChannelAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        //  CLEAR BUTTON
        //
        //
        //Main window Clear Button
        private void mainWindow_button_ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearLabels();
        }

        //Clear Data Labels Code
        public void ClearLabels()
        {

            //Clear Labels
            //Text Box
            mainWindow_textBox_search.Text = "Enter Search Zip Code Here";
            //Column One
            mainWindow_label_cityState.Content = "";
            mainWindow_label_Latlong.Content = "";
            mainWindow_label_CurrentWeather.Content = "";
            mainWindow_label_Temperature_Data.Content = "";
            mainWindow_label_FeelsLike_Data.Content = "";
            mainWindow_label_Wind_Data.Content = "";
            mainWindow_label_WindSpeed_Data.Content = "";
            mainWindow_label_WindDirection_Data.Content = "";
            mainWindow_label_Latlong_Copy.Content = "";

            //Column Two
            mainWindow_label_Elevation_Data.Content = "";
            mainWindow_label_LastUpdated_Data.Content = "";
            mainWindow_label_Humidity_Data.Content = "";
            mainWindow_label_UV_Data.Content = "";
            mainWindow_label_Visibility_Data.Content = "";
            mainWindow_label_Percipitation_Data.Content = "";
        }



        ////////////////////////////////////


        //OPEN BUTTON
        //
        //
        public void writeFile()
        {
            //Assign Content in Labels to Strings
            string myCityState_Data = mainWindow_label_cityState.Content.ToString();
            string myLongLat_Data = mainWindow_label_Latlong.Content.ToString();
            string myCurrentWeather_Data = mainWindow_label_CurrentWeather.Content.ToString();
            string myTemperature_Data = mainWindow_label_Temperature_Data.Content.ToString();
            string myFeelsLike_Data = mainWindow_label_FeelsLike_Data.Content.ToString();
            string myWindType_Data = mainWindow_label_Wind_Data.Content.ToString();
            string myWindSpeed_Data = mainWindow_label_WindSpeed_Data.Content.ToString();
            string myWindDirection_Data = mainWindow_label_WindSpeed_Data.Content.ToString();
            string myElevation_Data = mainWindow_label_Elevation_Data.Content.ToString();
            string myLastUpdated_Data = mainWindow_label_LastUpdated_Data.Content.ToString();
            string myHumidity_Data = mainWindow_label_Humidity_Data.Content.ToString();
            string myVisibility_Data = mainWindow_label_Visibility_Data.Content.ToString();
            string myUV_Data = mainWindow_label_UV_Data.Content.ToString();
            string myPercipitation = mainWindow_label_Percipitation_Data.Content.ToString();

            //Write Contents in Strings to a 'Super String'
            string SuperString;

            SuperString = "Your City Data " + myCityState_Data + Environment.NewLine;
            SuperString = SuperString + "Your Long / Lat: " + myLongLat_Data + Environment.NewLine;
            SuperString = SuperString + "Your Current Weather: " + myCurrentWeather_Data + Environment.NewLine;
            SuperString = SuperString + "Your Current Temperature: " + myTemperature_Data + Environment.NewLine;
            SuperString = SuperString + "Your Weather Feels like: " + myFeelsLike_Data + Environment.NewLine;
            SuperString = SuperString + "Your Wind Type is: " + myWindType_Data + Environment.NewLine;
            SuperString = SuperString + "Your Wind Speed is: " + myWindSpeed_Data + Environment.NewLine;
            SuperString = SuperString + "Your Wind Direction is: " + myWindDirection_Data + Environment.NewLine;
            SuperString = SuperString + "Your Elevation is: " + myElevation_Data + Environment.NewLine;
            SuperString = SuperString + "Your Humidity Percent is: " + myHumidity_Data + Environment.NewLine;
            SuperString = SuperString + "Your Visibility is: " + myVisibility_Data + Environment.NewLine;
            SuperString = SuperString + "Your UV Index is: " + myUV_Data + Environment.NewLine;
            SuperString = SuperString + "Your Precipitation is: " + myPercipitation + Environment.NewLine;


            //Create a directory to write in

            string path = "\\Your New Folder";
            Directory.CreateDirectory(path);

            //Write files to Directory
            string newSavePath = path + "\\File.txt";
            File.WriteAllText(newSavePath, SuperString);
        }




        //SAVE BUTTON
        //
        //


        //EXIT BUTTONS
        //
        //
        //Main Window Exit Button
        private void mainWindow_button_ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            exitPrompt();
        }

        //File DropDown Exit Button
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            exitPrompt();
        }


        //Exit Prompt Code
        public void exitPrompt()
        {

            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to Exit? Please ensure you have saved any data before exiting.", "Exit Prompt", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }


        //CLEAR TEXTBOX
        //
        //
        //Clear Search TextBox on Focus
        private void mainWindow_textBox_search_GotFocus(object sender, RoutedEventArgs e)
        {
            mainWindow_textBox_search.Text = "";
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            writeFile();
        }


        //Initiate Search
        private void mainWindow_button_SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string MySearch = mainWindow_textBox_search.Text;

            //Call Weather Channel Service Method, and save the result in a Weather Result Object
            WeatherResult result = WeatherChannelService.GetWeatherFor(MySearch);

            //Clear Labels
            ClearLabels();

            //Wire it up
            mainWindow_label_cityState.Content = result.CityState;
            mainWindow_label_Latlong.Content = result.Longitude;
            mainWindow_label_Latlong_Copy.Content = result.Latitude;
            mainWindow_label_CurrentWeather.Content = result.CurrentWeather;
            mainWindow_label_Temperature_Data.Content = result.Temperature;
            mainWindow_label_FeelsLike_Data.Content = result.FeelsLike;
            mainWindow_label_Wind_Data.Content = result.Wind;
            mainWindow_label_WindSpeed_Data.Content = result.WindSpeed;
            mainWindow_label_WindDirection_Data.Content = result.WindDirection;
            mainWindow_label_Elevation_Data.Content = result.Elevation;
            mainWindow_label_LastUpdated_Data.Content = result.LastUpdated;
            mainWindow_label_Humidity_Data.Content = result.Humidity;
            mainWindow_label_Visibility_Data.Content = result.Visibility;
            mainWindow_label_UV_Data.Content = result.UV;
            mainWindow_label_Percipitation_Data.Content = result.Precipitation;


            //Set image
            setImage(result);
        }
        public void setImage(WeatherResult result)
        {
            //Download the image from the url given to us by the API
            using (var webClient = new WebClient())
            {
                string imageFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, result.Icon + ".gif");
                if (File.Exists(result.Icon + ".gif") == false)
                {
                    webClient.DownloadFile(result.WeatherIconURL, imageFilePath);
                }
                //Change the source of the image in XAML to be the image we just downloaded
                var uri = new Uri(imageFilePath);

                mainWindow_Image.Source = new BitmapImage(uri);
            }
        }
    }
}

