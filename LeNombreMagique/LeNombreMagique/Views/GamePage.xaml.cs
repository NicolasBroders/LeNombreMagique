using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeNombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {

        const int NB_MIN = 1;
        const int NB_MAX = 11;
        Random random = new Random();
        int magicNumber = 0;
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            magicNumber = random.Next(NB_MIN, NB_MAX);
            labelNumber.Text = "Entre " + NB_MIN + " et " + (NB_MAX - 1);
        }

        private void GuessButton_Clicked(object sender, EventArgs e)
        {
            int guessNumber = 0;
            String resultat = "";
            try
            {
                guessNumber = Int32.Parse(numberEntry.Text);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                DisplayAlert("Mauvaise saisie", "Vous devez saisir un nombre entre "+NB_MIN +" et " +(NB_MAX-1), "Réessayer");
                numberEntry.Text = "";
                return;
            }

            if(guessNumber < 1 || guessNumber > 10)
            {
                DisplayAlert("Mauvaise saisie", "Vous devez saisir un nombre entre "+NB_MIN +" et " +(NB_MAX-1), "Réessayer");
                return;
            }

            if (guessNumber > magicNumber)
            {
                DisplayAlert("Hmmmmm", "Le nombre magique est plus petit", "Réessayer");
                return;
            }
            else if (guessNumber < magicNumber)
            {
                DisplayAlert("Hmmmmm", "Le nombre magique est plus grand", "Réessayer");
                return;
            }
            else
            {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                //WinAction();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                Navigation.PushAsync(new WinPage(magicNumber));
                return;
            }
            
            }

        private void numberEntry_Focused(object sender, FocusEventArgs e)
        { 
            numberEntry.Text = "";
        }

        private async Task WinAction()
        {
           await DisplayAlert("Félicitation !", "Vous avez trouvé le nombre magique !", "Ok");
        }
    }
}