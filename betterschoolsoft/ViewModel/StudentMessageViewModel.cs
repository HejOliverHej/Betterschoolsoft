using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace betterschoolsoft.ViewModel
{
    public class StudentMessagesViewModel : BaseViewModel
    {
        private readonly MessageService _messageService;
        private readonly IUserStorageService _userStorage;

        public ObservableCollection<Message> Messages { get; set; }

        public StudentMessagesViewModel()
        {
            _messageService = new MessageService(new JsonMessageStorageService());
            _userStorage = new JsonUserStorageService();

            LoadMessages();
        }

        private async void LoadMessages()
        {
            var users = await _userStorage.LoadAsync();
            var students = users.OfType<Students>().Select(s => s.Id).ToList();

            var allMessages = await _messageService.LoadAllMessagesAsync();

            var filtered = allMessages
                .Where(m => m.RecipientIds.Any(id => students.Contains(id)))
                .ToList();

            Messages = new ObservableCollection<Message>(filtered);
            OnPropertyChanged(nameof(Messages));
        }
    }

}
