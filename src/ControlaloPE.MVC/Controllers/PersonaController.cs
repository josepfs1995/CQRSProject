using System.Threading.Tasks;
using ControlaloPE.Application.Interfaces;
using ControlaloPE.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControlaloPE.MVC.Controllers{
    public class PersonaController:Controller{
        private readonly IPersonaAppService _personaAppService;
        public PersonaController(IPersonaAppService personaAppService)
        {
            _personaAppService = personaAppService;
        }
        public IActionResult Crear(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CrearPersonaViewModel model){
            var response = await _personaAppService.Crear(model);
            return Json(response);
        }
    }
}