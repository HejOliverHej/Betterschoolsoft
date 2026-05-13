using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Absence
    {
        [JsonConstructor]
        public Absence(DateTime date, string reason)
        {
            Date = date;
            Reason = reason;
        }

        public DateTime Date { get; set; }

        public string Reason { get; set; }
    }
}
