using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsTalk.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

		private async void RegistrButton_Clicked(object sender, EventArgs e)
		{
			string UserName = NameField.Text;
			string UserLogin = LoginField.Text;
			string UserPhone = PhoneField.Text;
			string UserMail = MailField.Text;
			string UserPass = PassField.Text;
			/* string UserTopics = NameField.Text;*/
			string UserScore = "1";

            int NumberForTryParse;
            if (int.TryParse(UserPhone, out NumberForTryParse) == false)
            {/*сделать ограничение ввода в форме*/
                PhoneField.Placeholder = Convert.ToString("В номере не должно быть букв. Людей еще не так много 8)");
                PhoneField.PlaceholderColor = Color.Red;
                PhoneField.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(UserLogin) || string.IsNullOrEmpty(UserPass) || string.IsNullOrEmpty(UserName))
			{
				/*Возможно вынести стринг.изНалОрЭмптив отдельный метод*/
				if (string.IsNullOrEmpty(UserPhone) && string.IsNullOrEmpty(UserMail))
				{
                    
                    
					PhoneField.PlaceholderColor = Color.Red;
					MailField.PlaceholderColor = Color.Red;
					PhoneField.Placeholder = Convert.ToString("Или введите здесь номер");
					MailField.Placeholder = Convert.ToString("Или введите здесь почту");/*сделать проверку на вводимый текст*/
				}
				LoginField.PlaceholderColor = Color.Red;/*возможно подобрать более красивый красный*/
				PassField.PlaceholderColor = Color.Red;
				NameField.PlaceholderColor = Color.Red;
				LoginField.Placeholder = Convert.ToString("Введите логин. Тут пустенько :(");
				PassField.Placeholder = Convert.ToString("Введите пароль. Я пока что не умею читать мысли :D");
				NameField.Placeholder = Convert.ToString("Введите имя. Не стесняйся :3");
			}
			else
			{

				DB db = new DB();
                //var DBConnected = db.Connection();
                try
                {
                    db.Connection().Open();     
                }
                catch
                {
                    await DisplayAlert("Ой! что то случилось с сервером :/", "Ошибка 505. Что то случилось с сервером(. Попробуйте чуть позже. Бежим решать проблему", "Ок, буду чуть позже");
                

                }

                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`name`, `topics`, `login`, `score`, `phone`, `mail`, `pass`) VALUES (@UN, '@UT', @UL, @US, @UP, @UM, @UPASS);", db.Connection());
				


					command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName;
					//command.Parameters.Add("@UT", MySqlDbType.VarChar).Value = UserTopics;
					command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = UserLogin;
					command.Parameters.Add("@US", MySqlDbType.VarChar).Value = UserScore;
					command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = UserPhone;
					command.Parameters.Add("@UM", MySqlDbType.VarChar).Value = UserMail;
					command.Parameters.Add("@UPASS", MySqlDbType.VarChar).Value = UserPass;

					db.OpenConnection();
                try
                {
                    if (command.ExecuteNonQuery() == 1)
                        RegistrButton.Text = Convert.ToString("Регистраця прошла успешно!");
                    else
                        RegistrButton.Text = Convert.ToString("ошибка регистрации(");
                    db.CloseConnection();

                }
                catch
                {

                }

				
				
			}
		}

		/*private async void RegButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync( new RegistrationPage());
		}*/
	}
}