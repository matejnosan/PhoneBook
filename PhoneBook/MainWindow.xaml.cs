using ADRestApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestClient client;
        RestRequest request;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bindData();            
        }

        private void bindData()
        {
            try
            {
                client = new RestClient(Properties.Settings.Default.ADApiUrl);
                request = new RestRequest("Users/{ss}", Method.GET);
                request.AddParameter("searchString", "value", ParameterType.UrlSegment);
                request.AddUrlSegment("ss", txtSearch.Text);
                IRestResponse<List<Person>> response = client.Execute<List<Person>>(request);
                BindingList<Person> blPersons = new BindingList<Person>(response.Data);
                grid.ItemsSource = blPersons;
                grid.Columns[0].Header = "Ime";
                grid.Columns[1].Header = "Priimek";
                grid.Columns[2].Header = "Telefon";
                grid.Columns[3].Header = "Mobitel";
                grid.Columns[4].Header = "eMail";
                grid.Columns[5].Header = "Oddelek";
                grid.Columns[6].Header = "Vloga";
            }
            catch (Exception)
            {
                MessageBox.Show("Napaka pri pridobivanju podatkov!");
            }
            
            
        }
       
    }

    
}
