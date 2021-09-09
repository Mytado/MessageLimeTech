using AutoMapper;
using Lime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Models
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MailMessage, MessageDTO>();
        }
    }
}
