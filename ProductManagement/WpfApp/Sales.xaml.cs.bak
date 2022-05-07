using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        List<ProductForm> products;
        public Sales()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
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

            //  dataGridView.ItemsSource = info;

        }

        public async Task LoadDataAsync2()
        {
           
            if (BasketDataGrid.Items.Count != 0)
            {
                BasketDataGrid.Items.Clear();
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
                BasketDataGrid.Items.Add(item);
                
            }
        }


        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
            ProductForm product = (ProductForm)dataGridView.SelectedItem;
            BindData(product);
            
        }

        private void BindData(ProductForm product)
        {

          //  Baskets baskets = (Baskets)BasketDataGrid.SelectedItem;
            //   ProductForm form = new ProductForm();
            //  ProductForm product = (ProductForm)dataGridView.SelectedItem;
        //    txtId.Text = baskets.Id.ToString();
            // txtName.Text = product.Name.Trim();
       //    txtPrice.Text = product.Price.ToString();
            //  txtDescription.Text = product.Description.Trim();
            // txtPrice.Text=form.Price.ToString().Where(b=>b).ToList();   
        //   txtCount.Text = baskets.Count.ToString();

            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name.Trim();
            txtPrice.Text = product.Price.ToString();
            txtDescription.Text = product.Description.Trim();
            txtCount.Text = product.Count.ToString();
            txtRate.Text = product.TaxRate.ToString();
            txtCode.Text = product.Code.ToString();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
            await LoadDataAsync2();
        }

        private async void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Product");
            string resultContent = await result.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent);

            decimal subtotal = 0;
            decimal total = 0;
            decimal taxRate = 0;

            

            double prices =Convert.ToDouble( txtPrice.Text);
            int counts =Convert.ToInt32( txtPrice.Text);

            foreach (var item in info)
            {
                var product = products.FirstOrDefault(x => x.Code == Convert.ToInt32(txtBarcode.Text));
                BindData(product);
                subtotal =Math.Round( Convert.ToDecimal(product.Price * product.Count),2);
                taxRate =Math.Round( Convert.ToDecimal(product.Price) / product.TaxRate,2);
                total = Math.Round( Convert.ToDecimal(product.Price * product.Count) + taxRate,2);


                
            }
            txtTotal.Text = total.ToString();
            txtTax.Text = taxRate.ToString();
            txtSubTotal.Text = subtotal.ToString();

           
        }

        public async void totalprice()
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Product");
            string resultContent = await result.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ProductForm>>(resultContent);


            double pricee;
            int quantityy;
            foreach (var row in info)
            {
                int pro_id = Convert.ToInt32(row.Id);
                pricee =Convert.ToDouble(row.Price);
                quantityy = row.Count;
                double totalprice =Convert.ToDouble( quantityy * pricee);
                MessageBox.Show(totalprice.ToString());
             //   lbltprice.Text = totalprice.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (txtBarcode.Text.Length > 0)
            {
                txtBarcode.Text = txtBarcode.Text.Substring(0, txtBarcode.Text.Length - 1);
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            txtBarcode.Text = "";
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = products.FirstOrDefault(x => x.Code == Convert.ToInt32(txtBarcode.Text));
                BindData(product);

            }
            catch (Exception exc)
            {

                txtBarcode.Text = "Product NotFound!!!";
            }
        }



        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtBarcode.Text += b.Content.ToString();
        }

      
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtBarcode.Text += b.Content.ToString();
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtBarcode.Text += b.Content.ToString();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtBarcode.Text += b.Content.ToString();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtBarcode.Text += b.Content.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                try
                {
                    var product = products.FirstOrDefault(x => x.Code == Convert.ToInt32(txtBarcode.Text));
                    BindData(product);
                }
                catch (Exception exc)
                {

                    txtBarcode.Text = "Product NotFound!!!";
                }
            }


            if (e.Key == Key.Delete)
            {
                txtBarcode.Text = "";
            }

            //if (e.Key == Key.Delete)
            //{
            //    MessageBox.Show("delete pressed");
            //    e.Handled = true;
            //}

            //if (e.Key ==Key.Clear)
            //{
            //    try
            //    {
            //        MessageBox.Show("ok");
            //       // txtBarcode.Text = "";
            //    }
            //    catch (Exception )
            //    {

            //        txtBarcode.Text = "ERROR!!!";
            //    }
            //}
        }

       
        private  async void btnBasket_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            var jti = tokenS.Claims.Where(x => x.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").First().Value;

            var basketVM = new BasketVM
            {
                UserId = jti,
                ProductId = Convert.ToInt32(txtId.Text),
            };

            var json = JsonConvert.SerializeObject(basketVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("api/Basket/AddToBasket/", content);
            string resultContent = await result.Content.ReadAsStringAsync();



            if (((int)result.StatusCode) == 200)
            {
               
                await LoadDataAsync2();

               
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private async void btnBasketView_Click(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync2();
        }
      

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            Baskets baskets = (Baskets)BasketDataGrid.SelectedItem;
            var result = await client.DeleteAsync($"api/Basket/{baskets.Id}");
            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {
                //  MessageBox.Show("ok");
                await LoadDataAsync2();
            }
        }

        private void BasketDataGrid_Selected(object sender, RoutedEventArgs e)
        {
            Baskets baskets = (Baskets)BasketDataGrid.SelectedItem;
         //   ProductForm form = new ProductForm();
          //  ProductForm product = (ProductForm)dataGridView.SelectedItem;
            txtId.Text = baskets.Id.ToString();
          // txtName.Text = product.Name.Trim();
       //txtPrice.Text = product.Price.ToString();
         //  txtDescription.Text = product.Description.Trim();
        // txtPrice.Text=form.Price.ToString().Where(b=>b).ToList();   
            txtCount.Text = baskets.Count.ToString();
          //  txtRate.Text = product.TaxRate.ToString();
          //  txtCode.Text = product.Code.ToString();
        }

        private async void basketPurchase_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7070/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            
            var result = await client.GetAsync("api/Basket/Purchase");
            string resultContent = await result.Content.ReadAsStringAsync();
            // var info = JsonConvert.DeserializeObject<List<Baskets>>(resultContent);
          
            txtBasketTotal.Text = resultContent;
            SendEmail();
         }
       
        private void SendEmail()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("turkanhuseynbayli98@gmail.com");
                message.To.Add(new MailAddress("turkannh@code.edu.az"));
                message.Subject = "Basket";
                message.IsBodyHtml = true; 
                message.Body = "<h2>Hello, Thanks For Order </h2> <bold> Turkan!!! </bold>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("turkanhuseynbayli98@gmail.com", "TurkanSah1998@");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
