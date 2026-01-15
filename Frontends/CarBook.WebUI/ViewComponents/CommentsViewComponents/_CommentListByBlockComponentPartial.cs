using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentsViewComponents
{
    public class _CommentListByBlockComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
