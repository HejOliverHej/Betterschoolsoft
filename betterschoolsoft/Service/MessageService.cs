using System;
using System.Collections.Generic;
using System.Text;
using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    /// <summary>
    /// Enkla logik i methoder för att sicka medelanden men hjälp writealltext sparning. 
    /// </summary>
    public class MessageService
    {
        private readonly IMessageStorageService _storage;

        public MessageService(IMessageStorageService storage)
        {
            _storage = storage;
        }

        public async Task SendMessageAsync(Message message)
        {
            var messages = await _storage.LoadAsync();
            messages.Add(message);
            await _storage.SaveAsync(messages);
        }

        public async Task<List<Message>> GetMessagesForUserAsync(Guid userId)
        {
            var messages = await _storage.LoadAsync();
            return messages.Where(m => m.RecipientIds.Contains(userId)).ToList();
        }

        public async Task<List<Message>> LoadAllMessagesAsync()
        {
            return await _storage.LoadAsync();
        }

    }

}
