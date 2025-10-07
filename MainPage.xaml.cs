using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BlackJackApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);   
        }

        private void OnPlayClicked(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new MainScreen());
        }
        
    }

}
