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
    public partial class StarView : ContentView
    {
        public StarView()
        {
            InitializeComponent();
            rotateStar(star1, 4000);
            rotateStar(star2, 4000);
            rotateStar(star3, 4000);
        }


        private async Task rotateStar(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.RotateTo(360, length);
                view.Rotation = 0;
            }
        }

    }
}