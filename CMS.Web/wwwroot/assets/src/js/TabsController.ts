
namespace web {
    export class TabsController {
        private tabs: HTMLCollection;
        constructor() {
            this.initTabs();
            this.initLinks();
        }

        public initTabs() {
            this.tabs = document.getElementsByClassName("section__photos__block__list__item");
        }
        
        public initLinks() {
            // get list of links
            const elements = document.getElementsByClassName("section__photos__block__navigation__list__item");

            for (let i = 0; i < elements.length; i++) {
                // @ts-ignore
                elements[i].addEventListener('click', this.showTab.bind(this, elements[i].dataset.tabId), false);
            }
        }
        
        public showTab(tabId: string) {
            // remove active class
            for (let i = 0; i < this.tabs.length; i++) {
                this.tabs[i].classList.remove('section__photos__block__list__item--active');
            }
            
            // add active class
            let element = document.getElementById(tabId);
            element.classList.add('section__photos__block__list__item--active')
        }
    }
}