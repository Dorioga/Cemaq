function enviarvariable(valor) {
    console.log(valor);    
    var v = document.getElementById("irarchivo").value = valor;
    $("#mostrarmodal3").modal("show");
}