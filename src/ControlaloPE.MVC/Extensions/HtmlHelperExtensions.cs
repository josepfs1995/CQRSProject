using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlaloPE.MVC.Extensions{
    public static class HtmlHelperExtension{
        public static IHtmlContent MostrarEstado(this IHtmlHelper html, bool estado){
            string @class = estado ? "bg-success": "bg-danger";
            string text = estado ? "Activo": "Inactivo";
            return new HtmlString($"<span class='badge {@class}'>{text}</span>");
        }
    }
}