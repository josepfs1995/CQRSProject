var editar = function(){
    var init = function(){
        document.querySelector(".card-footer .btn.btn-success").addEventListener("click", editar)
    }
    var editar = async function(){
        event.preventDefault();
        var form = document.querySelector("form");
        var formData = new FormData(form);
        var response = await fetch(form.action, { method: 'post', body: formData});
        var json = await response.json();
        if(!json.isValid) return mostrarError(json.errors);
        
        mostrarOk("Se guardo correctamente!");
    }
    return {
        init: init
    }
}();

document.addEventListener("DOMContentLoaded", function(){
    editar.init();
});