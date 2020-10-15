using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeNombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            scaleButton(playButton, 1000);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }




        private async Task scaleButton(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.2, length);
                await view.ScaleTo(1.0, length);
            }
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
    }
}