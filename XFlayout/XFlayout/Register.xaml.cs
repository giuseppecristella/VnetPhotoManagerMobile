using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFlayout
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        void OnRegisterClicked(object sender, EventArgs args)
        {
            // Validate Form
            if (String.IsNullOrEmpty(entryName.Text) || string.IsNullOrEmpty(entrySurname.Text) || string.IsNullOrEmpty(entryEmail.Text)||
                String.IsNullOrEmpty(entryPsw.Text) || string.IsNullOrEmpty(entryPswConfirm.Text) || string.IsNullOrEmpty(entryClientCode.Text))
            {
                DisplayAlert("Alert", "Compilare tutti i campi", "OK", "");
                return;
            }

            if (!entryPsw.Text.Equals(entryPswConfirm.Text))
            {
                DisplayAlert("Alert", "Le password inserite non coincidono", "OK", "");
                return;
            }

            AuthServiceProxy.AuthenticationServiceClient auth = new AuthServiceProxy.AuthenticationServiceClient();
            // Verifica se il codice cliente esiste
            // TODO: Verificare perchè non riesco a generare metodi con un valore di ritorno!!
            if (!entryClientCode.Text.Equals("0001"))
            {
                DisplayAlert("Alert", "Il Codice Cliente non esiste.", "OK", "");
                return;
            }
            var clientCodeId = 1; //  auth.GetClientCodeAsync(entryClientCode.Text);
            // Crea User su Tabelle ASP.net 
            auth.CreateUserAsync(entryEmail.Text, entryPsw.Text, entryEmail.Text, "psw qst", "psw asw", true);
            // Crea User su tabella UserClient
            auth.CreateUserClientAsync(1, entryClientCode.Text, entryName.Text, entrySurname.Text, "", "", "", "", "", entryPhone.Text, entryPhone.Text, entryEmail.Text,
                entryPsw.Text, DateTime.Now, true);
            DisplayAlert("Alert", "Utente registrato con successo", "OK", "");
        }
    }
}
