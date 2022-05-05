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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        public Update()
        {
            InitializeComponent();
        }

        List<ProductForm> products;
        private async void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Product p = new Product();
          //  await p.LoadDataAsync();
            this.Visibility = Visibility.Collapsed;
           // Product p=new Product();
           //await p.LoadDataAsync();  
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var products = new ProductForm
            {
                Id =Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Description = txtDesc.Text,
                Price =Convert.ToDouble(txtPrice.Text),
                Count =Convert.ToInt32(txtCount.Text),
                Status =Convert.ToBoolean(txtStatus.IsChecked),
                CreatedDate =Convert.ToDateTime(txtDate.Text),
                TaxRate =Convert.ToDecimal(txtRate.Text),
            };

            var json = JsonConvert.SerializeObject(products);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7070/");

            var result = await client.PutAsync($"api/Product/{txtId.Text}", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {
                var result2 = await client.GetAsync("api/Product");
                string resultContent2 = await result2.Content.ReadAsStringAsync();
                var info = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent2);
                //Window parrentWindow = (Window)this.Parent;
                //parrentWindow.Close();
            }

            else
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
