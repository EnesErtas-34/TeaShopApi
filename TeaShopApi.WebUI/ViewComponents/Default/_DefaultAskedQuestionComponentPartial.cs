using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TeaShopApi.WebUI.Dtos.AboutDtos;
using TeaShopApi.WebUI.Dtos.QuestionDtos;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _DefaultAskedQuestionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAskedQuestionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7086/api/Questions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultQuestionDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
