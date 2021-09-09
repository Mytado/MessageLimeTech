using AutoMapper;
using Lime.Domain;
using MessageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageAPI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMailMessageRepository _messageRepository;
        private readonly IMapper _mapper;


        public MessageController(IMailMessageRepository messageRepository, IMapper mapper)
        {
            this._messageRepository = messageRepository;
            this._mapper = mapper;

        }

        // GET: api/<MessageController>
        [HttpGet]
        public ActionResult<IEnumerable<MessageDTO>> GetAllMessages()
        {
            var allMessages = _messageRepository.GetAll();
            return Ok(_mapper.Map<List<MessageDTO>>(allMessages));
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDTO>> GetMessageById(int id)
        {
            var message = _messageRepository.GetById(id);
            return Ok(_mapper.Map<MessageDTO>(message));
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message =  _messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            if (_messageRepository.Delete(id))
            {
                return NoContent();
            } else
            {
                return BadRequest();
            }
           
        }
    }
}
