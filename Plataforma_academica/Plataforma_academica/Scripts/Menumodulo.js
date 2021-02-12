/*var li = document.getElementsByClassName("titulo");
var li2;

var cod = 0;
for (var i = 0; i < li.length; i++){
  //var a =  li.childNodes[i].nodeValue;
    li[i].addEventListener('click', mostrar(li[i].), false);
}*/
var mod = document.getElementsByClassName("modulo");
function mostrarmodulo(value_elemento) {
    var cod = value_elemento;
    
    for (var i = 0; i < mod.length; i++) {
        if (cod == mod[i].value) {
            mod[i].classList.toggle('active');
        }
    }
}