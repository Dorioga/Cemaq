const btnswitch = document.querySelector('#switch');

btnswitch.addEventListener('click', function(){
    //Agregar/quitar Modo oscuro 
    document.body.classList.toggle('dark');
    btnswitch.classList.toggle('active');

    //Guardamos el modo en localstorage
        //Preguntar si tiene la clase Dark
    if (document.body.classList.contains('dark')) {
        //Se guarda en Local Storage la configuracion con nombre Darkmode
        localStorage.setItem('dark-mode', 'true');
    } else {
        localStorage.setItem('dark-mode', 'false');
    }
});
   
    //Obtener El modo actual
    if (localStorage.getItem('dark-mode') === 'true') {
        document.body.classList.add('dark');
        btnswitch.classList.add('active');
    } else {
        document.body.classList.remove('dark');
        btnswitch.classList.remove('active');
    }

