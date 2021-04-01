using LetsTalk.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LetsTalk
{
    public partial class MainPage : ContentPage

    {
        

        public MainPage()
        {
            InitializeComponent();
        }

       async private void InButton_Clicked(object sender, EventArgs e)
        {
            string UserLogin = LoginField.Text;
            string UserPass = PassField.Text;
           
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UL AND `pass` = @UPASS ", db.Connection());
            
            //SqlConnection.CreateCommand()
            command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = UserLogin;
            command.Parameters.Add("@UPASS", MySqlDbType.VarChar).Value = UserPass;
            
             adapter.SelectCommand = command;

            adapter.Fill(table);
     

             if (table.Rows.Count > 0)
            {
                await Navigation.PushAsync(new HomePage());
            }
             else
                 RegButton.Text = Convert.ToString("Такого пользователя не существует(((");
        }

        private async void RegButton_Clicked(object sender, EventArgs e)
        {
               
                await Navigation.PushAsync(new RegistrationPage());
        }
        
    }
}
