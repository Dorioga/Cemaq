class Accordion {
    constructor(selector, multiple = true) {
        this.accordion = document.querySelector(selector);
        this.bindEvents();
        this.multiple = multiple;

    }

    bindEvents() {
        this.accordion.querySelectorAll(".items .progress").forEach(itemsprog => {
            var i = 0;
            console.log(i++);
            itemsprog.addEventListener("click", () => {
                let item = itemsprog.parentNode;
               // this.validateMultiple(item);
               item.classList.toggle("active");
                console.log(item.className);
                window.onclick = e => {
                    console.log(e.target);
                }
             
             
            })

        });
    }
    
}
(function () {
    new Accordion(".accordion")
})()