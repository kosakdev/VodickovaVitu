
namespace web {
    export class CalendarController{
        private skip = 5;
        private coming = 1;
        private previous = 1;
        
        private jsonData: any;
        
        private comingList: any;
        private comingButton: any;
        private previousList: any;
        private previousButton: any;
        
        private months = ["Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec"]
        
        constructor() {
            this.initElements();
            
            this.addEventListener();
        }
        
        private initElements() {
            this.comingList = document.getElementById('coming-data');
            this.comingButton = document.getElementById('coming-show-more');
            this.previousList = document.getElementById('previous-data');
            this.previousButton = document.getElementById('previous-show-more');

            if (this.comingButton != null) {
                this.comingButton.addEventListener('click', this.comingData.bind(this), false);
            }
            if (this.previousButton != null) {
                this.previousButton.addEventListener('click', this.previousData.bind(this), false);
            }
        }
        
        private comingData() {
            let url = './calendar/GetNext?skip=' + (this.coming * this.skip).toString();
            this.getNext(url, this.comingList, this.comingButton);
            this.coming = this.coming + 1;
        }
        
        private previousData(){
            let url = './calendar/GetPrevious?skip=' + (this.previous * this.skip).toString();
            this.getNext(url, this.previousList, this.previousButton);
            this.previous = this.previous + 1;
        }
        
        private getNext(url: string, list: HTMLDivElement, button: HTMLButtonElement) {
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.jsonData = [];
                    for (let i = 0; i < data.length; i++) {
                        this.jsonData.push(data[i]);
                    }
                    if (data.length < this.skip) {
                        this.hideButton(button);
                    }
                })
                .then(() => {
                    this.showHtml(list);
                    this.removeEventListener();
                    this.addEventListener();
                });
        }
        
        private hideButton(buttonElement: HTMLButtonElement) {
            buttonElement.style.display = 'none';
        }
        
        private showHtml(listElement: HTMLDivElement) {
            for (let i = 0; i < this.jsonData.length; i++) {
                let row = this.jsonData[i];
                
                let date = new Date(row.DateTime.toString())
                
                let node = document.createElement('div');
                node.classList.add('section__calendar__block__list__item');
                node.setAttribute("data-id", row.Id);

                let rowElement = document.createElement('div');
                rowElement.classList.add('section__calendar__block__list__item__row');
                
                if (row.Description.toString() != "") {
                    rowElement.style.cssText += 'cursor: pointer;';
                }
                
                let cel1 = document.createElement('div');
                cel1.classList.add('section__calendar__block__list__item__cel');
                cel1.innerHTML = date.getDate() + ". " + this.months[date.getMonth()];

                let cel2 = document.createElement('div');
                cel2.classList.add('section__calendar__block__list__item__cel');
                let hour = date.getHours();
                let hourStr = hour < 10 ? '0' + hour : '' + hour;
                
                let minutes = date.getMinutes();
                let minutesStr = minutes < 10 ? '0' + minutes : '' + minutes;
                
                cel2.innerHTML = hourStr + ":" + minutesStr + " hodin";

                let cel3 = document.createElement('div');
                cel3.classList.add('section__calendar__block__list__item__cel');
                cel3.innerHTML = row.Place.toString();

                let cel4 = document.createElement('div');
                cel4.classList.add('section__calendar__block__list__item__cel');
                cel4.innerHTML = row.EventType.Name.toString();

                rowElement.appendChild(cel1);
                rowElement.appendChild(cel2);
                rowElement.appendChild(cel3);
                rowElement.appendChild(cel4);

                let detail = document.createElement('div');
                detail.classList.add('section__calendar__block__list__item__detail');
                detail.setAttribute("id", row.Id);
                detail.innerHTML = row.Description.toString();
                
                node.appendChild(rowElement);
                node.appendChild(detail);
                
                listElement.appendChild(node);
            }
        }
        
        private removeEventListener() {
            let elements = document.getElementsByClassName("section__calendar__block__list__item");

            for (let i = 0; i < elements.length; i++) {
                let new_element = elements[i].cloneNode(true);
                elements[i].parentNode.replaceChild(new_element, elements[i]);
            }
        }

        private addEventListener() {            
            let elements = document.getElementsByClassName("section__calendar__block__list__item");

            for (let i = 0; i < elements.length; i++) {
                // @ts-ignore
                elements[i].addEventListener('click', this.eventHandler.bind(this, elements[i].dataset.id), false);
            }
        }
        
        private eventHandler(id: string) {
            let element = document.getElementById(id);
            if (element != null) {
                element.classList.toggle("section__calendar__block__list__item__detail--show");
            }
        }
    }
}