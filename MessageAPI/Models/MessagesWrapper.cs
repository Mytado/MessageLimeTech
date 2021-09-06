using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lime.Domain;
using MessageAPI.Controllers;

namespace MessageAPI.Models
{
    public class MessagesWrapper
    {
        public List<MailMessage> mailMessages { get; set; }
    }
}
