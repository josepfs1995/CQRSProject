using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControlaloPE.MVC.Components{
    public class ErrorViewComponent: ViewComponent{
        public async Task<IViewComponentResult> InvokeAsync(){

            return View();
        }
    }
}