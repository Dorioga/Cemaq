
const logo = document.getElementById('arriba');
const menu = document.getElementById('menu');
const pie = document.getElementById('abajo');

logo.addEventListener('click', function () {
    menu.classList.toggle('active');
    logo.classList.toggle('ordenar')
    pie.classList.toggle('ordenar')
    if (menu.classList.contains('active')) {
        //Se guarda en Local Storage la configuracion c
        localStorage.setItem('menu', 'true');
    } else {
        localStorage.setItem('menu', 'false');
    }
});
    //Guardar si esta comprimido o no
 

//Guardar
if (localStorage.getItem('menu') === 'true') {
    if (menu.classList.contains('active')) {
        menu.classList.remove('active');
        logo.classList.remove('ordenar')
        pie.classList.remove('ordenar')
    } else {
        menu.classList.add('active');
        logo.classList.add('ordenar')
        pie.classList.add('ordenar')
    }
    
} else {
    if (menu.classList.contains('active')) {
        menu.classList.add('active');
        logo.classList.add('ordenar')
        pie.classList.add('ordenar')  
    } else {    
        menu.classList.remove('active');
        logo.classList.remove('ordenar')
        pie.classList.remove('ordenar')
    }
}
//Cuando se active la vista responsive
var mediacel = window.matchMedia("(max-width: 700px)");

mediacel.addListener(function (EventoMediaQueryList) {
    if (EventoMediaQueryList.matches) {
        menu.classList.add('active')
        logo.classList.add('ordenar')
        pie.classList.add('ordenar')
        localStorage.setItem('menu', 'true');
    } else {
        menu.classList.remove('active')
        logo.classList.remove('ordenar')
        pie.classList.remove('ordenar')
        localStorage.setItem('menu', 'false');
    }

});


