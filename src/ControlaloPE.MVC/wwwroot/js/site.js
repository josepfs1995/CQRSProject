var mostrarOk = function(msg){
    var toastDiv = document.querySelector('.toast.bg-primary');
    var toast = new bootstrap.Toast(document.querySelector('.toast.bg-primary'));
    toastDiv.querySelector(".toast-body").innerHTML = msg;
    toast.show();
}

var mostrarError = function(msg){
    var toastDiv = document.querySelector('.toast.bg-danger');
    var toast = new bootstrap.Toast(toastDiv);
    var body =  toastDiv.querySelector(".toast-body");
    body.innerHTML = "";

    if(typeof msg === "object") crearErrorList(body, msg);
    if(typeof msg === "string") body.innerHTML = msg;
    
    
    toast.show();
}
var crearErrorList = function(body, msg){
    var ul = document.createElement("UL");
    ul.className = "mb-0";
    msg.map(item => {
        console.log(item);
        var li = document.createElement("LI");
        li.className = "";
        li.innerHTML = item.errorMessage;
        ul.appendChild(li);
    })
    body.appendChild(ul);
}