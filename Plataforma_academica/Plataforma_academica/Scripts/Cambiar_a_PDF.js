function ocultar() {
    document.getElementById('obj1').style.display = 'none';
    document.getElementById('boton_pdf').style.display = 'none';
    document.getElementById('obj2').style.display = 'block';
    document.getElementById('boton_plataforma').style.display = 'block';
}
function mostrar_boton() {
    document.getElementById('obj1').style.display = 'block';
    document.getElementById('obj2').style.display = 'none';
    document.getElementById('boton_plataforma').style.display = 'none';
    document.getElementById('boton_pdf').style.display = 'block';
}