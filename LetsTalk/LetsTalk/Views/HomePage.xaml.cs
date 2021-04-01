using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsTalk.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

		private void ToSettingsButton_Clicked(object sender, EventArgs e)
		{

		}

		private void ToPetButton_Clicked(object sender, EventArgs e)
		{

		}

		private async void ToTalkButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TalkSessionPage());
		}
	}
}