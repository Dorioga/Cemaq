class Accordion {
    constructor(selector, multiple = true) {
        this.accordion = document.querySelector(selector);
        this.bindEvents();
        this.multiple = multiple;

    }

    bindEvents() {
        this.accordion.querySelectorAll(".items .progress").forEach(itemsprog => {
            itemsprog.addEventListener("click", () => {

                //curso solo para el primero por el id 
                let item = itemsprog.parentNode;
                var poscurso = item.classList[2];
                var posnivel = item.classList[3];
                var posunidad = item.classList[4];

                var curso = document.getElementsByClassName('curso');
                var nivel = document.getElementsByClassName('nivel');
                var unidad = document.getElementsByClassName('unidad');
                var actividad = document.getElementsByClassName('actividad');
                var examen = document.getElementsByClassName('examen');

                if (hasClass(curso[poscurso], item.className)) {

                    var nnivel = curso[poscurso].getElementsByClassName('nivel').length;
                    var anivel = curso[[poscurso]].getElementsByClassName('nivel');
                    mostrar(nnivel, anivel);
                    //  item.classList.toggle("active");

                } else {
                    var arr = curso[poscurso].children;
                    var padre = item.parentNode;
                    var abuelo = padre.parentNode;
                    for (var j = 0; j < arr.length; j++) {
                        if (arr[j].className == item.className || arr[j].className == padre.className || arr[j].className == abuelo.className) {
                            var p = j;
                        }
                    }
                    console.log("Indice " + p);
                    if (hasClass(curso[poscurso].children[p], item.className)) {
                        var nunidad = curso[poscurso].children[p].getElementsByClassName('unidad').length;
                        var aunidad = curso[poscurso].children[p].getElementsByClassName('unidad');
                        mostrar(nunidad, aunidad);
                        // item.classList.toggle("active");

                    } else {
                        var arr = curso[poscurso].children[p].children;
                        for (var k = 0; k < arr.length; k++) {
                            if (arr[k].className == item.className) {
                                var h = k;
                            }
                        }
                        console.log("Indice 2" + h);

                        if (hasClass(curso[poscurso].children[p].children[h], item.className)) {

                            var nactividad = curso[poscurso].children[p].children[h].getElementsByClassName('actividad').length;
                            var aactividad = curso[poscurso].children[p].children[h].getElementsByClassName('actividad');
                            var nexamen = curso[poscurso].children[p].children[h].getElementsByClassName('examen').length;
                            var aexamen = curso[poscurso].children[p].children[h].getElementsByClassName('examen');
                            mostrar(nactividad, aactividad);
                            mostrar(nexamen, aexamen);
                            //   item.classList.toggle("active");

                        }
                    }
                }


            })

        });
    }



}
function mostrar(tamaño, arreglo) {
    for (var i = 0; i < tamaño; i++) {
        var est = arreglo[i].style.display;
        if (est == "") {
            arreglo[i].style.display = "block";
        } else {
            arreglo[i].style.display = "";
        }
    }
}
function hasClass(elem, className) {
    return new RegExp(' ' + className + ' ').test(' ' + elem.className + ' ');
}
(function () {
    new Accordion(".accordion")
})()