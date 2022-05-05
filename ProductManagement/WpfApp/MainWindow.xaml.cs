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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public   MainWindow()
        {
            InitializeComponent();

            //var btn1 = new Button { Content = "ADD" };
            //btn1.Click += ClickHandler1;



        }

        private void ClickHandler1(object sender, RoutedEventArgs e)
        {
            //do something
        }
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var productForm = new ProductForm
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Price = Convert.ToInt32(txtPrice.Text),
                Description=txtDesc.Text,   
                Count=Convert.ToInt32(txtCount.Text),   
               // Status=Convert.ToInt32(txtStatus.Text),   
               
            };

            var json = JsonConvert.SerializeObject(productForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
           
            client.BaseAddress = new Uri("https://localhost:7070/");
            var result = await client.PutAsync($"api/Product/{txtId.Text}", content);

            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {
                await LoadDataAsync();  
            }

            else
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var product = new
            {
                Name = txtName.Text,
                Price = txtPrice.Text,
                Description = txtDesc.Text,
                Count = txtCount.Text,
                Status = txtStatus.Text,
            };
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7070/");
            var result = await client.PostAsync("api/Product", content);

            string resultContent = await result.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<PostResponse>(resultContent);
            dataGridView.Items.Add(info);

            if (((int)result.StatusCode) == 200)
            {
               await LoadDataAsync();
            }

            else
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7070/");
            var result = await client.DeleteAsync($"api/Product/{txtId.Text}");
            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {

                await LoadDataAsync();

            }

            else
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await LoadDataAsync();
           
        }

        private async Task LoadDataAsync()
        {
            if (dataGridView.Items.Count != 0)
            {
                dataGridView.Items.Clear(); 
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7070/");
           
            var result = await client.GetAsync("api/Product");
            string resultContent = await result.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent);
            foreach (var item in info)
            {
                dataGridView.Items.Add(item);
            }


        }

        private void dataGridView_Selected(object sender, RoutedEventArgs e)
        {
            ProductForm product = (ProductForm)dataGridView.SelectedItem;
            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name.Trim();
            txtPrice.Text = product.Price.ToString();
            txtDesc.Text = product.Description.Trim();
            txtCount.Text = product.Count.ToString();
            txtStatus.Text = product.Status.ToString();

        }
    }
}
