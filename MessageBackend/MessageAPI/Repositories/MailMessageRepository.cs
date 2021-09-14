using Lime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
    
    public class MailMessageRepository : IMailMessageRepository
    {
        private List<MailMessage> messages = new();

        public MailMessageRepository()
        {
            InitMessages();
        }

        private void InitMessages ()
        {
            var jObjMessages = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("mail-messages.json"));
            var tempMessageCollection = jObjMessages["mailMessages"];
            //shortcut to handle the typing in currentMessage
            var b = 1;
            foreach (var obj in tempMessageCollection)
            {
                try
                {
                    MailMessage currentMessage = new MailMessage
                    {
                        Id = (int)obj["mailMessageId"],
                        Name = (string)obj["name"],
                        ModifiedDate = (DateTime)obj["modifiedDate"],
                        IsSent = obj["isSent"] == b,
                        PublicationId = (int)obj["publicationId"]
                    };
                    messages.Add(currentMessage);

                } catch (Exception ex)
                {
                    Console.WriteLine("Exception caught: {0}", ex.Message);
                }
            }
        }

        public bool Delete(int id)
        {
            
            try
            {
                //messages.RemoveAll(message => message.Id == id);
                var itemToRemove = messages.Where(m => m.Id == id);
                if (itemToRemove != null)
                {
                    messages.RemoveAll(m => m.Id == id);
                    Console.WriteLine(messages);
                    return true; 
                }
                return false;
                
            } catch
            {
                return false;
            }  
        }

        public IEnumerable<MailMessage> Find(Expression<Func<MailMessage, bool>> filter)
        {
            return messages.Where(filter.Compile());
        }

        public IEnumerable<MailMessage> GetAll()
        {
            return messages.GetRange(0, 100);
        }

        public MailMessage GetById(int id)
        {
            var res = messages.Where(m => m.Id == id).ToList();
            if (res.Count > 0)
            {
                return res.ElementAt(0);
            }
            else
            {
                return null;
            }
        }
    }
}
