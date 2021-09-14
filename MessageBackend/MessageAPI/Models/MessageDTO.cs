using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Models
{
    public class MessageDTO
    {
        public string Id { get; set; }
        public string IsSent { get; set; }
        public string PublicationId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
