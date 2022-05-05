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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        List<ProductForm> products;
        private async Task LoadDataAsync()
        {
          

            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Product");
            string resultContent = await result.Content.ReadAsStringAsync();
            products = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent);

            foreach (var item in products)
            {
                //dataGridView.Items.Add(item);
            }

            //  dataGridView.ItemsSource = info;

        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            var product = new ProductForm
            {
                Name = txtName.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                Description = txtDesc.Text,
                Count = Convert.ToInt32(txtCount.Text),
                Status = Convert.ToBoolean(txtStatus.IsChecked),
                Code = Convert.ToInt32(txtCode.Text),
                TaxRate = Convert.ToInt32(txtRate.Text),
                CreatedDate = Convert.ToDateTime(txtDate.Text)
            };

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.PostAsync("api/Product/", content);

            string resultContent = await result.Content.ReadAsStringAsync();
            if (((int)result.StatusCode) == 200)
            {
                var result2 = await client.GetAsync("api/Product");
                string resultContent2 = await result2.Content.ReadAsStringAsync();
                var info = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent2);
            }

            else
            {
                MessageBox.Show("Only the Admin can add it!!!");

            }
        }
    }
}
