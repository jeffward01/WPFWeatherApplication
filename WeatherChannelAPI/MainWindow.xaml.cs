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



        /// ////////////////////////////////


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

        //Clear Search TextBox on Focus
        private void mainWindow_textBox_search_GotFocus(object sender, RoutedEventArgs e)
        {
            mainWindow_textBox_search.Text = "";
        }

        //add text to Search TextBox on LOSS of focus
        private void mainWindow_textBox_search_LostFocus(object sender, RoutedEventArgs e)
        {
            if(mainWindow_textBox_search.Text == "")
            {
                mainWindow_textBox_search.Text = "Enter Search Zip Code Here";
            }
        }
    }
}
