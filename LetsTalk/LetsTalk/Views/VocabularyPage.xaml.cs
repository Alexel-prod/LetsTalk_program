using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsTalk.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VocabularyPage : ContentPage
    {
        Entry EnterNewWord = new Entry();



        public VocabularyPage()
        {
            InitializeComponent();


            stackLayout.Children.Add(EnterNewWord);

        }



        private async void AddNewWordButton_Clicked(object sender, EventArgs e)

        {

            Label NewWordLabel = new Label();
            var NewWord = NewWordLabel.Text = EnterNewWord.Text;
            NewWordLabel.TextColor = Color.White;
            NewWordLabel.FontSize = 48;
            stackLayout.Children.Add(NewWordLabel);

            // сохранение данных

            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "UserVoc.json");

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            using (StreamWriter jsonStream = new StreamWriter(fs))
            {
                var jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                jsonSerializer.Serialize(jsonStream, NewWord);

             }

            // чтение данных
            using (FileStream fs = new FileStream("UserVoc.json", FileMode.OpenOrCreate))
            using (StreamReader jsonStream = new StreamReader(fs))
            {
                var jsonDeserializer = new JsonTextReader(jsonStream);
               var testing =  jsonDeserializer.Read();
                if (testing != null)
                {
                    await DisplayAlert("Десериализация", "Опа ","Ок");

                }

            }

         }

       


        /*protected void AddNewWord()
        {
            Label NewWordLabel = new Label();
            Button AddNewWordButton = new Button();
            NewWordLabel.Text = Convert.ToString("Новое слово");
           NewWordLabel.TextColor = Color.White;
           NewWordLabel.FontSize = 70;
           //NewWordLabel.HorizontalOptions = ;

           Content = new StackLayout()
            {

                Children = { NewWordLabel }
            };

        }*/



    }

   
}