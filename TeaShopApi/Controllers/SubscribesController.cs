using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.AboutDtos;
using TeaShopApi.DtoLayer.SubscribeDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribesController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            Subscribe subscribe = new Subscribe()
            {
               Mail = createSubscribeDto.Mail
            };
            _subscribeService.TInsert(subscribe);
            return Ok("Abone  Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _subscribeService.TGetById(id);
            _subscribeService.TDelete(value);
            return Ok("Abone  Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var value = _subscribeService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            Subscribe subscribe = new Subscribe()
            {
                SubscribeID=updateSubscribeDto.SubscribeID,
                Mail=updateSubscribeDto.Mail
            };
            _subscribeService.TUpdate(subscribe);
            return Ok("Abone Güncellendi");
        }
    }
}
