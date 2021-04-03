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


        //{
        //    TranslateTo(100, 0, 500, Easing.CubicIn);
        //    TranslateTo(0, 0);


        async private void InButton_Clicked(object sender, EventArgs e)
        {
            string UserLogin = LoginField.Text;
            string UserPass = PassField.Text;



            if (string.IsNullOrEmpty(UserLogin) || string.IsNullOrEmpty(UserPass))
            {
                LoginField.PlaceholderColor = Color.Red;/*возможно подобрать более красивый красный*/
                PassField.PlaceholderColor = Color.Red;
                LoginField.Placeholder = Convert.ToString("Введите логин. Тут пустенько :(");
                PassField.Placeholder = Convert.ToString("Введите Пароль. Я пока что не умею читать мысли :D");
            }
            else
            {

                DB db = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UL AND `pass` = @UPASS ", db.Connection());
               


                    //SqlConnection.CreateCommand()
                    command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = UserLogin;
                    command.Parameters.Add("@UPASS", MySqlDbType.VarChar).Value = UserPass;
                var ForServerFall = table.Rows.Count;
                try
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    ForServerFall = table.Rows.Count;
                }
                catch
                {
                    ForServerFall = table.Rows.Count + 10;
                    await DisplayAlert("Ой! что то случилось с сервером :/", "Ошибка 505. Что то случилось с сервером(. Попробуйте чуть позже. Бежим решать проблему", "Ок, буду чуть позже");
                }
                

                if (ForServerFall == 10)
                {
                       
                }
                else if (ForServerFall > 0)
                {
                    await Navigation.PushAsync(new HomePage());
                }
                else 
                await DisplayAlert("Такого пользователя не существует(((", "Зарегистрируйтесь или проверьте правильность введенных данных ", "Ок");



            }

        }
        private async void RegButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegistrationPage());
        }


    }

}

   


