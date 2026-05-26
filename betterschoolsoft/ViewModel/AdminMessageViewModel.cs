using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminMessageViewModel : BaseViewModel
    {
        private readonly IUserStorageService _userStorage;
        private readonly MessageService _messageService;

        public string Title { get; set; }
        public string Body { get; set; }

        public ObservableCollection<string> RecipientGroups { get; } =
            new ObservableCollection<string> { "Alla", "Elever", "Lärare" };

        public string SelectedRecipientGroup { get; set; }

        public ICommand SendCommand { get; }

        public AdminMessageViewModel()
        {
            _userStorage = new JsonUserStorageService();
            _messageService = new MessageService(new JsonMessageStorageService());

            SendCommand = new Command(async () => await SendMessage());
        }

        private async Task SendMessage()
        {
            var users = await _userStorage.LoadAsync();

            List<Guid> recipients = SelectedRecipientGroup switch
            {
                "Alla" => users.Select(u => u.Id).ToList(),
                "Elever" => users.OfType<Students>().Select(s => s.Id).ToList(),
                "Lärare" => users.OfType<Teachers>().Select(t => t.Id).ToList(),
                _ => new List<Guid>()
            };

            var message = new Message
            {
                Title = Title,
                Body = Body,
                SenderId = Guid.Empty,
                RecipientIds = recipients
            };

            await _messageService.SendMessageAsync(message);

            await Application.Current.MainPage.DisplayAlert("Skickat", "Meddelandet har skickats!", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }

}
