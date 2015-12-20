using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFlayout
{
    public partial class XFPage1
    {
        public XFPage1()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            //Button button = (Button)sender;
            entryName.Text = "Giuseppe";
            AuthServiceProxy.AuthenticationServiceClient auth = new AuthServiceProxy.AuthenticationServiceClient();
            auth.CreateUserAsync("provaandroid@test.it","peppe", "provaandroid@test.it", "psw qst", "psw asw", true);
           // VnetAuthServiceProxy.IAuthenticationService a;
          
        }
    }
}
