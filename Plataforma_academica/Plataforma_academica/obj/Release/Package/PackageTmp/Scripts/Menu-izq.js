var buscar = document.getElementById("bus");
var contenedor = document.getElementById("contenedor");
var oculto = document.getElementById("ocultar");
var icono = document.getElementById("iconos");

oculto.addEventListener("click", function () {
    contenedor.classList.toggle('active');

    if (icono.classList.contains('fa-times')) {
        icono.classList.remove('fa-times');
        icono.classList.add('fa-bars');
    } else {
        icono.classList.add('fa-times');
        icono.classList.remove('fa-bars');
    }
    

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
        if (icono.classList.contains('fa-times')) {
            icono.classList.remove('fa-times');
            icono.classList.add('fa-bars');
        } else {
            icono.classList.add('fa-times');
            icono.classList.remove('fa-bars');
        }

    } else {
        contenedor.classList.add('active');
        if (icono.classList.contains('fa-times')) {
            icono.classList.remove('fa-times');
            icono.classList.add('fa-bars');
        } else {
            icono.classList.add('fa-times');
            icono.classList.remove('fa-bars');
        }
    }
} else {
    if (contenedor.classList.contains('active')) {
        contenedor.classList.add('active');
    } else {
        contenedor.classList.remove('active');
    }
}