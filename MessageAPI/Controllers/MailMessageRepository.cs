using Lime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using Newtonsoft.Json;

namespace MessageAPI.Controllers
{
    public class MailMessageRepository : IMailMessageRepository
    {
        private List<MailMessage> messages;

        public MailMessageRepository()
        {
            InitMessages();
        }

        private void InitMessages ()
        {
            messages = new List<MailMessage>();
            var jObjMessages = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("mail-messages.json"));

            var tempMessageCollection = jObjMessages["mailMessages"];
            Console.WriteLine(" type: " + tempMessageCollection.Count);
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

            /*
            //double checking values, keep for now
            var foo = messages.FirstOrDefault();
            //alla värden stämmer överens enligt ovan mappning mot filen
            Console.WriteLine(
                "id:" + foo.Id +
                " name:" + foo.Name + 
                " modData:" + foo.ModifiedDate +
                " isSent:" + foo.IsSent + 
                " pubId:" + foo.PublicationId);*/
        }

        public bool Delete(int id)
        {
            try
            {
                messages.RemoveAll(message => message.Id == id);
                return true;
            } catch
            {
                return false;
            }  
        }

        public IEnumerable<MailMessage> Find(Expression<Func<MailMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MailMessage> GetAll()
        {
            return messages;
        }

        public MailMessage GetById(int id)
        {
            var res = messages.Where(message => message.Id == id).ToList();
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
