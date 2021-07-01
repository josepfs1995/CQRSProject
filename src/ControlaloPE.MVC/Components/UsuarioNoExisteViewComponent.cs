using System.Threading.Tasks;
using ControlaloPE.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlaloPE.MVC.Components{
    public class UsuarioNoExisteViewComponent: ViewComponent{
        private readonly IPersonaAppService _personaAppService;
        public UsuarioNoExisteViewComponent(IPersonaAppService personaAppService)
        {
            _personaAppService = personaAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync(){
            var response = await _personaAppService.Obtener();
            return View(response);
        }
    }
}