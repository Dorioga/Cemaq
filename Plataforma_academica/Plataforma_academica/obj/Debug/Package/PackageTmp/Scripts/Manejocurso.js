const ddiplomado = document.getElementById('diplomado');
const dmodulo = document.getElementById('modulo');
const dactividad = document.getElementById('actividad');
const bdiplomado = document.getElementById('bdiplomado');
const bmodulo = document.getElementById('bmodulo');
const bactividad = document.getElementById('bactividad');
//console.log(dmodulo.className + " - " + ddiplomado.className + " - " + dactividad.className);
bdiplomado.addEventListener('click', function () {
    ddiplomado.classList.toggle('active');
    })
bmodulo.addEventListener('click', function () {
    dmodulo.classList.toggle('active');
})
bactividad.addEventListener('click', function () {
    dactividad.classList.toggle('active');
})