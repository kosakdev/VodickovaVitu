
namespace web {
    export class MainController{
        private menuCollapse: any;
        private pathTop: any;
        private pathMiddle: any;
        private pathBottom: any;
        
        private menuBlock: any;
        private headerText: any;
        private activeMenu = false;
        constructor() {
            this.initMenu();
            this.initScrollMenu();
            
            this.hideErrorMessage();
        }
        
        private initMenu() {
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
        
        private initScrollMenu() {
            this.menuBlock = document.getElementById("menu");
            this.headerText = document.getElementsByClassName('header__content')[0];
            document.addEventListener('scroll', this.scrollMenu.bind(this), false);
        }
        
        public scrollMenu() {
            if (window.scrollY >= 100 && this.activeMenu == false) {
                this.activeMenu = true;
                this.menuBlock.classList.toggle("nav--active");
                // this.headerText.classList.toggle('header__content--scrolled');
            }
            else if (window.scrollY < 100 &&this.activeMenu == true) {
                this.activeMenu = false;
                this.menuBlock.classList.toggle("nav--active");
                // this.headerText.classList.toggle('header__content--scrolled');
            }
        }
        
        private hideErrorMessage() {
            let item = document.getElementsByClassName("error");
            
            if (item.length > 0) {
                setTimeout(this.hideElement, 3000, item[0]);
            }
        }
        
        private hideElement(element:any) {
            element.style.display = "none";
        }
    }
}