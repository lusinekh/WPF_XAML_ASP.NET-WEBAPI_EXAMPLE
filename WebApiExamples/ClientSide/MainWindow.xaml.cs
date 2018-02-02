using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> filesList = new List<string>();
        private static string rootPath = @"C:\Users\HP\Desktop\Test\Server files";
        private static string pageAddress = @"http://localhost:60731/";
        public MainWindow()
        {
            InitializeComponent();
        }
        //show all
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listOfFiles.Visibility = Visibility.Visible;
            var responseString = string.Empty;
            //listOfFiles.ItemsSource = Directory.GetFiles(rootPath);
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(pageAddress + "api/Files").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }
            responseString = responseString.Replace(",", Environment.NewLine);
            ContentBlock.Text = responseString;
        }
        //get by id
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CheckIdTextBox();
            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetAsync(pageAddress + $"api/files/{IdTextBox.Text}").Result;
                ContentBlock.Text = httpResponse.Content.ReadAsStringAsync().Result;
            }
        }
        //add file
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var fileName = $"{Path.GetRandomFileName()}.txt";
                var content = new StringContent(JsonConvert.SerializeObject(fileName), Encoding.UTF8, "application/json");
                var response = client.PostAsync(pageAddress + "api/files", content).Result;
                ContentBlock.Text = response.Content.ReadAsStringAsync().Result;
            }
        }
        //put / update
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CheckIdTextBox();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(ContentBlock.Text), Encoding.UTF8, "application/json");
                var response = client.PutAsync(pageAddress + $"api/files/{IdTextBox.Text}", content).Result;
                ContentBlock.Text = response.Content.ReadAsStringAsync().Result;
            }
        }
        //remove / delete
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CheckIdTextBox();
            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.DeleteAsync(pageAddress + $"api/files/{IdTextBox.Text}").Result;
                var response = httpResponse.Content.ReadAsStringAsync().Result;
                ContentBlock.Text = response;
            }
        }

        private void CheckIdTextBox()
        {
            int number;
            if (!int.TryParse(IdTextBox.Text, out number))
            {
                MessageBox.Show("Please specify an id");
                return;
            }
        }
    }
}
