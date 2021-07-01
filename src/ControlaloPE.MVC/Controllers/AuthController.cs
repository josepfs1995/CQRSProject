using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ControlaloPE.Application.ViewModels;
using ControlaloPE.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ControlaloPE.Application.Interfaces;

namespace ControlaloPE.MVC.Controllers{
    public class AuthController : Controller{
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPersonaAppService _personaAppService;
        public AuthController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IPersonaAppService personaAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _personaAppService = personaAppService;
        }
        public IActionResult Login( ){
            return View();
        }
        public IActionResult Registrar(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioViewModel request){
            if(!ModelState.IsValid) 
                return View(request);
            var response = await _signInManager.PasswordSignInAsync(request.Email, request.Contrasena, false, false);
            if(response.Succeeded){
                var identityUser = await _userManager.FindByEmailAsync(request.Email);
                await AddClaims(identityUser);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrecto");
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel request){
            if(!ModelState.IsValid) return View(request);

            var identityUser = new IdentityUser(request.Email){
                Email = request.Email,
                EmailConfirmed = true
            };

            var response = await _userManager.CreateAsync(identityUser, request.Contrasena);
            if(response.Succeeded){
                if(await AgregarRoles(identityUser)){
                    await AddClaims(identityUser);
                    return RedirectToAction("Index", "Home");
                }
                await _userManager.DeleteAsync(identityUser);
            }
            ModelState.AddModelError(string.Empty, "Ocurrío un error");
            return View(request);
        }
        private async Task<bool> AgregarRoles(IdentityUser identityUser){
            var response = await _userManager.AddToRoleAsync(identityUser, RolesConst.USUARIO);
            return response.Succeeded;
        }

        private async Task AddClaims(IdentityUser identityUser){
            var claims = await _userManager.GetClaimsAsync(identityUser);
            await AgregarRolesEnClaims(identityUser, claims);

            var persona = await _personaAppService.Obtener( new Guid(identityUser.Id));

            string name = persona?.Nombre ?? identityUser.Email;
            claims.Add(new Claim(ClaimTypes.NameIdentifier, identityUser.Id));
            claims.Add(new Claim(ClaimTypes.Email, identityUser.Email));
            claims.Add(new Claim(ClaimTypes.Name, name));
            
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties{
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            });
        }
        private async Task AgregarRolesEnClaims(IdentityUser identityUser, ICollection<Claim> claims){
            var roles = await _userManager.GetRolesAsync(identityUser);
            foreach(var rol in roles){
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
        }
    }
}