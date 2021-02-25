var buscar = document.getElementById("bus");
var contenedor = document.getElementById("contenedor");
var oculto = document.getElementById("ocultar");

oculto.addEventListener("click", function () {
    contenedor.classList.toggle('active');

    if (contenedor.classList.contains('active')) {
        //Se guarda en Local Storage la configuracion c
        localStorage.setItem('menu', 'true');
    } else {
        localStorage.setItem('menu', 'false');
    }
});

if (localStorage.getItem('menu') === 'true') {
    if (contenedor.classList.contains('active')) {
        contenedor.classList.remove('active');
    } else {
        contenedor.classList.add('active');
    }

} else {
    if (contenedor.classList.contains('active')) {
        contenedor.classList.add('active');
    } else {
        contenedor.classList.remove('active');
    }
}