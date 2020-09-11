function validarInformacion() {
    var envia = true;
    var expRegUsuario = /^[a-záéíóúñ\s]+$/i;
    var expRegContraseña = /^[a-záéíóúñ\s]+$/i;
    if (!usuario.value) {
        alert("Digite su Usuario");
        usuario.focus();
    }
    else if (!contraseña.value) {
        alert("Digite su contraseña");
        envia = false;
        apellido.focus()
    }
}

window.onload = function () {
    var botonEnviar = document.getElementById("envia");
    botonEnviar.onclick = validarInformacion;
}