
namespace web {
    export class MainController{
        private menuCollapse: any;
        private pathTop: any;
        private pathMiddle: any;
        private pathBottom: any;
        constructor() {
            this.initMenu();
        }
        
        public initMenu() {
            let menuToggler = document.getElementById("menu-toggler");
            
            this.menuCollapse = document.getElementById("menu-nav");
            //#path-top, #path-middle, #path-bottom
            this.pathTop = document.getElementById("path-top");
            this.pathMiddle = document.getElementById("path-middle");
            this.pathBottom = document.getElementById("path-bottom");

            menuToggler.addEventListener('click', this.showHideMenu.bind(this), false);
        }
        
        public showHideMenu() {
            this.menuCollapse.classList.toggle("nav__list--hide");
            this.pathTop.classList.toggle("path-top-active");
            this.pathMiddle.classList.toggle("path-middle-active");
            this.pathBottom.classList.toggle("path-bottom-active");
        }
    }
}