using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TeaShopApi.WebUI.Dtos.MessageDtos;
using TeaShopApi.WebUI.Dtos.SubscribeDtos;

namespace TeaShopApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {

            
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(createMessageDto), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7086/api/Messages", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            return View();

        }

        [HttpGet]
        public PartialViewResult SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createSubscribeDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7086/api/Subscribes", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }

    }
}
