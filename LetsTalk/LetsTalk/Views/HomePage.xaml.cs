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

		private async void ToSettingsButton_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new SettingsPage());
		}

		private async void ToPetButton_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new PetPage());
        }

		private async void ToTalkButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TalkSessionPage());
		}

        private async void ToVocabularyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VocabularyPage());
        }
    }
}