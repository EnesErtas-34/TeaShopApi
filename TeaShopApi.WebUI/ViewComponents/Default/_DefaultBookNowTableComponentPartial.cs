using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _DefaultBookNowTableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
