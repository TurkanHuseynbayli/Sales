using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        ObservableCollection<Type> MyCollection { get; set; }
        List<ProductForm> products;
        public Product()
        {
            InitializeComponent();
        }

        string testFOrm1 = "!!!!!!";

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //ProductForm product = (ProductForm)dataGridView.SelectedItem;
            //FrmChangeProduct f = new FrmChangeProduct();
            //f.Show();
            //f.txtId.Text =Convert.ToString( product.Id);
            //f.txtName.Text =product.Name;
            //f.txtDesc.Text =product.Description;
            //f.txtPrice.Text =Convert.ToString( product.Price);
            //f.txtCount.Text =Convert.ToString( product.Count);
            //f.txtStatus.IsChecked =product.Status;
            //f.txtDate.Text = Convert.ToString(product.CreatedDate);
            //f.txtRate.Text = Convert.ToString(product.TaxRate);
            //f.txtCode.Text = Convert.ToString(product.Code);


         
            //AddProduct product = new AddProduct();

            //product.ShowDialog();
            // await LoadDataAsync();
            //  await LoadDataAsync();
            //  MessageBox.Show(Convert.ToString( product.Id));

            //FrmChangeProduct update = new FrmChangeProduct();
            ////var result = NewForm.ShowDialog();
            ////if (result.Value == true)
            ////{
            ////    testFOrm1 = NewForm.DataFOrTest;
            ////    await LoadDataAsync();
            ////}

            ////MessageBox.Show(testFOrm1);

           Update update = new Update();

         //  update.sh


           MainGrid.Children.Add(update);

           ProductForm product = (ProductForm)dataGridView.SelectedItem;
            var id = product.Id;
            var name = product.Name;
            var description = product.Description;
            var price = product.Price;
            var count = product.Count;
            var status = product.Status;
            var createdDate = product.CreatedDate;
            var taxRate = product.TaxRate;
            var code = product.Code;

            ////  FrmChangeProduct f=new FrmChangeProduct();

            //update.txtId.Text = Convert.ToString(product.Id);
            //update.txtName.Text = product.Name;
            //update.txtDesc.Text = product.Description;
            //update.txtPrice.Text = Convert.ToString(product.Price);
            //update.txtCount.Text = Convert.ToString((int)product.Count);
            //update.txtStatus.IsChecked = product.Status;
            //update.txtDate.Text = Convert.ToString(product.CreatedDate);
            //update.txtRate.Text = Convert.ToString(product.TaxRate);
            //update.txtCode.Text = Convert.ToString(product.Code);

            update.txtId.Text = Convert.ToString(id);
            update.txtName.Text = name;
            update.txtDesc.Text = description;
            update.txtPrice.Text = Convert.ToString(price);
            update.txtCount.Text = Convert.ToString((int)count);
            update.txtStatus.IsChecked = status;
            update.txtDate.Text = Convert.ToString(createdDate);
            update.txtRate.Text = Convert.ToString(taxRate);
            update.txtCode.Text = Convert.ToString(code);


         //   await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {

            if (dataGridView.Items.Count != 0)
            {
                dataGridView.Items.Clear();
            }
           
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Product");
            string resultContent = await result.Content.ReadAsStringAsync();
            products = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent);

            foreach (var item in products)
            {
                dataGridView.Items.Add(item);
            }

             //dataGridView.ItemsSource = info;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            await LoadDataAsync();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           AddProduct product = new AddProduct();

            product.ShowDialog();
           // ADDxaml aDDxaml = new ADDxaml();

            //  update.sh


           // MainGrid.Children.Add(aDDxaml);
            await LoadDataAsync();
        }

        private async void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("ok");
        }

        private void dataGridView_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //MessageBox.Show("ok");
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


            ProductForm product = (ProductForm)dataGridView.SelectedItem;
            var result = await client.DeleteAsync($"api/Product/{product.Id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {
                await LoadDataAsync();
            }

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
        }
    }
}
