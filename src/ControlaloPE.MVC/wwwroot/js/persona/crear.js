var crear = function(){
    var init = function(){
        document.querySelector(".card-footer .btn.btn-success").addEventListener("click", crear)
    }
    var crear = async function(){
        event.preventDefault();
        var form = document.querySelector("form");
        var formData = new FormData(form);
        var response = await fetch(form.action, { method: 'post', body: formData});
        var json = await response.json();
        console.log(json);
    }
    return {
        init: init
    }
}();

document.addEventListener("DOMContentLoaded", function(){
    crear.init();
});