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

		private void RegistrButton_Clicked(object sender, EventArgs e)
		{
			string UserName = NameField.Text;
			string UserLogin = LoginField.Text;
			string UserPhone = PhoneField.Text;
			string UserMail = MailField.Text;
			string UserPass = PassField.Text;
			/* string UserTopics = NameField.Text;*/
			string UserScore = "1";

			DB db = new DB();
			MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`name`, `topics`, `login`, `score`, `phone`, `mail`, `pass`) VALUES ('@UN', '@UT', '@UL', '@US', '@UP', '@UM', '@UPASS');", db.Connection());

			command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName;
			//command.Parameters.Add("@UT", MySqlDbType.VarChar).Value = UserTopics;
			command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = UserLogin;
			command.Parameters.Add("@US", MySqlDbType.VarChar).Value = UserScore;
			command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = UserPhone;
			command.Parameters.Add("@UM", MySqlDbType.VarChar).Value = UserMail;
			command.Parameters.Add("@UPASS", MySqlDbType.VarChar).Value = UserPass;

			db.OpenConnection();
			if (command.ExecuteNonQuery() == 1)
				RegistrButton.Text = Convert.ToString("Регистраця прошла успешно!");
			else
				RegistrButton.Text = Convert.ToString("ошибка регистрации(");
			db.CloseConnection();
		   



		}

		/*private async void RegButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync( new RegistrationPage());
		}*/
	}
}