
namespace web {
    export class TabsController {
        private tabs: HTMLCollection;
        private menuLinks: any;
        constructor() {
            this.initTabs();
            this.initLinks();
        }

        public initTabs() {
            this.tabs = document.getElementsByClassName("section__photos__block__list__item");
        }
        
        public initLinks() {
            // get list of links
            this.menuLinks = document.getElementsByClassName("section__photos__block__navigation__list__item");

            for (let i = 0; i < this.menuLinks.length; i++) {
                // @ts-ignore
                this.menuLinks[i].addEventListener('click', this.showTab.bind(this, this.menuLinks[i], this.menuLinks[i].dataset.tabId), false);
            }
        }
        
        public showTab(textElement: any, tabId: string) {
            // remove active class
            for (let i = 0; i < this.tabs.length; i++) {
                this.tabs[i].classList.remove('section__photos__block__list__item--active');
            }

            for (let i = 0; i < this.menuLinks.length; i++) {
                this.menuLinks[i].classList.remove('section__photos__block__navigation__list__item--active');
            }
            
            textElement.classList.add('section__photos__block__navigation__list__item--active');
            
            // add active class
            let element = document.getElementById(tabId);
            element.classList.add('section__photos__block__list__item--active')
        }
    }
}