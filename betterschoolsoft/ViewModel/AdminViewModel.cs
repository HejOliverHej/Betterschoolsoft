using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    internal class AdminViewModel
    {

        public ICommand LogoutCommand { get; }



        public AdminViewModel()
        {
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            await Shell.Current.GoToAsync("//LoginView");
        }
    }
}
