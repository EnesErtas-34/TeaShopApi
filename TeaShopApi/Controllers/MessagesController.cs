using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values=_messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                MessageSenderName = createMessageDto.MessageSenderName,
                MessageDetail = createMessageDto.MessageDetail,
                MessageEmail = createMessageDto.MessageEmail,
                MessageSubject = createMessageDto.MessageSubject,
                MessageSendDate = createMessageDto.MessageSendDate

            };
            _messageService.TInsert(message);
            return Ok("Kaydetme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values=_messageService.TGetById(id);
            _messageService.TDelete(values);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value=_messageService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                MessageDetail = updateMessageDto.MessageDetail,
                MessageEmail = updateMessageDto.MessageEmail,
                MessageSubject = updateMessageDto.MessageSubject,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageSenderName = updateMessageDto.MessageSenderName
            };
            _messageService.TUpdate(message);
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
