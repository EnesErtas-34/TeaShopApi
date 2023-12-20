using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _DefaultOurTeaShopComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
