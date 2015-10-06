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

            SuperString = "Your City Data " + myCityState_Data + "\n";
            SuperString = SuperString + "Your Long / Lat: " + myLongLat_Data + "\n";
            SuperString = SuperString + "Your Current Weather: " + myCurrentWeather_Data + "\n";
            SuperString = SuperString + "Your Current Temperature: " + myTemperature_Data + "\n";
            SuperString = SuperString + "Your Weather Feels like: " + myFeelsLike_Data + "\n";
            SuperString = SuperString + "Your Wind Type is: " + myWindType_Data + "\n";
            SuperString = SuperString + "Your Wind Speed is: " + myWindSpeed_Data + "\n";
            SuperString = SuperString + "Your Wind Direction is: " + myWindDirection_Data + "\n";
            SuperString = SuperString + "Your Elevation is: " + myElevation_Data + "\n";
            SuperString = SuperString + "Your Humidity Percent is: " + myHumidity_Data + "\n";
            SuperString = SuperString + "Your Visibility is: " + myVisibility_Data + "\n";
            SuperString = SuperString + "Your UV Index is: " +myUV_Data +"\n";
            SuperString = SuperString + "Your Percipitation is: "+myPercipitation+"\n";


            //Create a directory to write in
                string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path = path + "\\Your New Folder";
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
    }
}
