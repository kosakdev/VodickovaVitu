
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
            this.InitElements();
        }
        
        private InitElements() {
            this.comingList = document.getElementById('coming-data');
            this.comingButton = document.getElementById('coming-show-more');
            this.previousList = document.getElementById('previous-data');
            this.previousButton = document.getElementById('previous-show-more');

            this.comingButton.addEventListener('click', this.ComingData.bind(this), false);
            this.previousButton.addEventListener('click', this.PreviousData.bind(this), false);
        }
        
        private ComingData() {
            let url = './calendar/GetNext?skip=' + (this.coming * this.skip).toString();
            this.GetNext(url, this.comingList, this.comingButton);
            this.coming = this.coming + 1;
        }
        
        private PreviousData(){
            let url = './calendar/GetPrevious?skip=' + (this.previous * this.skip).toString();
            this.GetNext(url, this.previousList, this.previousButton);
            this.previous = this.previous + 1;
        }
        
        private GetNext(url: string, list: HTMLDivElement, button: HTMLButtonElement) {
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.jsonData = [];
                    for (let i = 0; i < data.length; i++) {
                        this.jsonData.push(data[i]);
                    }
                    if (data.length <= this.skip) {
                        this.HideButton(button);
                    }
                })
                .then(() => {
                    this.ShowHtml(list);
                });
        }
        
        private HideButton(buttonElement: HTMLButtonElement) {
            buttonElement.style.display = 'none';
        }
        
        private ShowHtml(listElement: HTMLDivElement) {
            for (let i = 0; i < this.jsonData.length; i++) {
                let row = this.jsonData[i];
                
                let date = new Date(row.DateTime.toString())
                
                let node = document.createElement('div');
                node.classList.add('section__calendar__block__list__item');
                
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

                node.appendChild(cel1);
                node.appendChild(cel2);
                node.appendChild(cel3);
                node.appendChild(cel4);
                
                listElement.appendChild(node);
            }
        }
    }
}