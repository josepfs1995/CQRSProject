using System;
using System.Threading.Tasks;
using ControlaloPE.Application.Interfaces;
using ControlaloPE.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlaloPE.MVC.Controllers
{
    [Authorize]
    public class EmpresaController:Controller{
        private readonly IEmpresaAppService _empresaAppService;
        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }
        public async Task<IActionResult> Index(){
            var response = await _empresaAppService.Obtener();
            return View(response);
        }
        public async Task<IActionResult> ObtenerEmpresas(){
            var response = await _empresaAppService.Obtener();
            return PartialView("_Empresas", response);
        }
        public IActionResult Crear(){
            return View();
        }
        public async Task<IActionResult> Editar(Guid id){
            var response = await _empresaAppService.Obtener(id);
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CrearEmpresaViewModel model){
           var response = await _empresaAppService.Crear(model);
           return Json(response);
        }
        [HttpPost("{id_Empresa}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(EditarEmpresaViewModel model){
           var response = await _empresaAppService.Editar(model);
           return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid id){
           var response = await _empresaAppService.Eliminar(id);
           return Json(response);
        }
    }
}