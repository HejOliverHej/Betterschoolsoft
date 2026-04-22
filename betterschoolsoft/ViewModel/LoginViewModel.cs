using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {



        public ICommand Logginbtn_Clicked { get; }
        public ICommand SignInbtn { get; }
        public LoginViewModel()
        {
            Logginbtn_Clicked = new Command(async () => await MakeAccount());

            SignInbtn = new Command(async () => await SendToSigninView());




        }
        private async Task MakeAccount()
        {



        }

        private async Task SendToSigninView()
        {
            await Shell.Current.GoToAsync($"//SigninView?");
        }
    }
}
