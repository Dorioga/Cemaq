var clic = 0;
function divmenu() {
    if (clic == 1) {
        document.getElementById("menu").style.height = "90%";
        document.getElementById("menu").style.display = "inline";
        clic = clic + 1;

    } else {
        document.getElementById("menu").style.height = "0%";
        document.getElementById("menu").style.display = "none";
        clic = 1;

    }
}