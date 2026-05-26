using System;
using System.Collections.Generic;
using System.Text;
using betterschoolsoft.Model;


namespace betterschoolsoft.Service
{
    public interface IMessageStorageService
    {
        Task<List<Message>> LoadAsync();
        Task SaveAsync(List<Message> messages);
    }

}
