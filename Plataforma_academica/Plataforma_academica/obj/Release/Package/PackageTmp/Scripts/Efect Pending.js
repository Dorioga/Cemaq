const botones = document.getElementsByClassName('msjem');
window.onmousemove = function (e) {
    var x = e.clientX,
        y = e.clientY;
    for (var i = 0; i < botones.length;i++) {
        botones[i].style.top = (y + 20) + 'px';
        botones[i].style.left = (x + 20) + 'px';
    }

};