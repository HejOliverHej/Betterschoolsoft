using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Service
{
    public interface IUserStorageService
    {
        Task SaveAsync(IEnumerable<Users> users);
        Task<IList<Users>> LoadAsync();
    }
}
