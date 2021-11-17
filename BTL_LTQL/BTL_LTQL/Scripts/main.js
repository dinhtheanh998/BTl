const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);

const menu = $$(".menu-item");
menu.forEach(function (course, index) {
    course.onclick = function () {
        $(".menu-item.active").classList.remove("active");
        console.log(menu)

        this.classList.add("active");
    };
});