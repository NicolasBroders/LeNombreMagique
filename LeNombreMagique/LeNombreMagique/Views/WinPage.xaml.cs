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
    public partial class WinPage : ContentPage
    {
        public WinPage(int nombreMagique)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            mainLayout.Scale = 0.7;
            mainLayout.ScaleTo(1.0, 1500, Easing.BounceIn);

            NavigateBackToWelcomePage();
            magicNumberLabel.Text = "Le nombre magique était " + nombreMagique;

        }

        private async Task NavigateBackToWelcomePage()
        {
            await Task.Delay(3000);
            await Navigation.PopToRootAsync();
        }
    }
}