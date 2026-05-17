using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Service
{
    public interface IClassStorageService
    {
        Task<List<ClassGroup>> LoadClassesAsync();
        Task SaveClassesAsync(List<ClassGroup> classes);
    }
}
