var index = function(){
    var init = function(){
        document.querySelector("form .btn.btn-danger").addEventListener("click", eliminar)
    }
    var eliminar = async function(){
        event.preventDefault();
        var form = document.querySelector("form");
        var response = await fetch(form.action, { method: 'post' });
        var json = await response.json();
        if(json.isValid){
            mostrarOk("Se elimino correctamente");
            return obtenerEmpresas();
        }
        mostrarError("Ocurrío un error");
    }
    var obtenerEmpresas = async function(){
        document.getElementById("divEmpresas").innerHTML = "<h5>Actualizando</h5>";
        var response = await fetch(urlObtenerEmpresas, {method: 'get'});
        var html = await response.text();
        document.getElementById("divEmpresas").innerHTML = html;
        init();
    }
    return {
        init: init
    }
}();

document.addEventListener("DOMContentLoaded", function(){
    index.init();
});