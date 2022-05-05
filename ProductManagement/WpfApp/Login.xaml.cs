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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "Banu";
            txtPassword.Password = "12345@Bb";
            var UserLogin = new UserLogin
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Password,
            };

            var json = JsonConvert.SerializeObject(UserLogin);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

           // string databasePath = DevelopmentEnvironmentManager.WPF.Properties.Settings.Default.SqliteDbFilePath;

            client.BaseAddress = new Uri("https://localhost:7070/");
            var result = await client.PostAsync("api/Authenticate/login", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            string r = resultContent.Remove(0, 10);

            string res = r.Remove(r.Length - 2);

            if (((int)result.StatusCode) == 200)
            {
                this.Hide();
                Product product = new Product();

                ProtectToken.DateProtection(res);
                product.ShowDialog();
                this.Close();


                // MessageBox.Show(res); 
            }

            else
            {
                MessageBox.Show("Password or username wrong");
            }

        }
    }
}
