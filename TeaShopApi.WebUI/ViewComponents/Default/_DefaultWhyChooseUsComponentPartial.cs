using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _DefaultWhyChooseUsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
