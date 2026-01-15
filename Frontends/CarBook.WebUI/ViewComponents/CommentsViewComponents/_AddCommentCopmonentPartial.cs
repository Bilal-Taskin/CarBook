using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentsViewComponents
{
    public class _AddCommentCopmonentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
