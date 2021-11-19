using System;
using System.Collections.Generic;
using System.Text;

namespace MessageRetreiverPractice.Entities
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public bool WasSeen { get; set; }
        public string Message { get; set; }
    }
}
