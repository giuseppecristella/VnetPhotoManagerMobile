using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFlayout
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        void OnRegisterClicked(object sender, EventArgs args)
        {
            // Validate Form
            if (String.IsNullOrEmpty(entryUserName.Text) || String.IsNullOrEmpty(entryPsw.Text))
            {
                DisplayAlert("Alert", "Compilare tutti i campi", "OK", "");
                return;
            }

            AuthServiceProxy.AuthenticationServiceClient auth = new AuthServiceProxy.AuthenticationServiceClient();
            auth.CustomValidateUserAsync(entryUserName.Text, entryPsw.Text);
        }
    }
}
