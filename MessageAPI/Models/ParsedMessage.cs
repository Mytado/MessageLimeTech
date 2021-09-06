using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Controllers
{
    public class ParsedMessage
    {
   
        public int mailMessageId { get; set; }


        public int isSent { get; set; }


        public int publicationId { get; set; }


        public string name { get; set; }


        public DateTime modifiedDate { get; set; }
    }
}
