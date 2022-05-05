using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
        }
        List<ProductForm> products;
       

        public async Task LoadDataAsync()
        {
            if (BasketView.Items.Count != 0)
            {
                BasketView.Items.Clear();
            }

            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Basket");
            string resultContent = await result.Content.ReadAsStringAsync();
            var baskets = JsonConvert.DeserializeObject<List<Baskets>>(resultContent);

            foreach (var item in baskets)
            {
               BasketView.Items.Add(item);

            }

        }

       

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            Baskets baskets = (Baskets)BasketView.SelectedItem;
            var result = await client.DeleteAsync($"api/Basket/{baskets.Id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {
               //  MessageBox.Show("ok");
                await LoadDataAsync();
            }
        }
    }
}
