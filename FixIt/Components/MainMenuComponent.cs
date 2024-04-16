using Microsoft.AspNetCore.Mvc;

namespace FixIt.Components
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.IsInRole("Administrator"))
            {
                return await Task.FromResult<IViewComponentResult>(View("Admin"));
            }
            else if (User.IsInRole("Technician"))
            {
                return await Task.FromResult<IViewComponentResult>(View("Technician"));
            }
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
