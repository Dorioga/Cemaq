var buscar = document.getElementById("bus");
var contenedor = document.getElementById("contenedor");
var oculto = document.getElementById("ocultar");

oculto.addEventListener("click", function () {
    contenedor.classList.toggle('active');
});