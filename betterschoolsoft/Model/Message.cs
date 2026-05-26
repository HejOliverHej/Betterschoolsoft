using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    public class Message
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;

        public Guid SenderId { get; set; }
        public List<Guid> RecipientIds { get; set; } = new();
    }
}
