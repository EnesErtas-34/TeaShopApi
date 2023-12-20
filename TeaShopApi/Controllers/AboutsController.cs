using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.AboutDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };
            _aboutService.TInsert(about);
            return Ok("Hakkımızda Yazısı Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımızda Yazısı Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda Yazısı Güncellendi");
        }

    }
}
