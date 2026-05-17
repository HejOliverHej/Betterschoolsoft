using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Admin : Users
    {
        [JsonConstructor]
        public Admin(Guid id, string username, string password)
            : base(id, username, password)
        {
        }

        public Admin(string username, string password)
            : base(username, password)
        {
        }

        public override string GetDashboardRoute()
        {
            return "//AdminSection/AdminView";
        }
    }
}
