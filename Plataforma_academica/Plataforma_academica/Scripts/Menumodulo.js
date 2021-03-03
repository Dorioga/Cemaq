
var mod = document.getElementsByClassName("modulo");


function mostrarmodulo(value_elemento, eleccion) {
    console.log("la eleccion es : " + eleccion);
    var cod = value_elemento;
    var ele = eleccion;
    for (var i = 0; i < mod.length; i++) {
        if (cod == mod[i].value) {
            if (ele == 'titulo') {
                mod[i].classList.toggle('active');
            } else {
                if (ele == 'modulo') {
                    mod[i].classList.add('active');
                }
            }            
            localStorage.setItem('valor', mod[i].value);
        } else {
            mod[i].classList.remove('active');
        }
    }
}

//Cargar la Funcion Guardada
var aux = localStorage.getItem('valor');

    for (var j = 0; j < mod.length; j++) {
        if (mod[j].value == aux) {
            if (!mod[j].classList.contains('active')) {
                mod[j].classList.add('active');
            }
        }
    }