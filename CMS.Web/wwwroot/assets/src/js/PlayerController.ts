
namespace web {
    export class PlayerController {
        private readonly playerElement: string;
        private player : any;
        private jsonData : object[];
        private videoIndex : number;
        private playPlayer = false;
        
        constructor(playerElement:string) {
            this.playerElement = playerElement;
            this.videoIndex = 0;
            this.initVideo();
        }
        
        public initVideo() {
            fetch('./Music/VideoList')
                .then(response => response.json())
                .then(data => {
                    this.jsonData = [];
                    for (let i = 0; i < data.length; i++) {
                        this.jsonData.push(data[i]);
                    }
                    
                })
                .then(() => {
                    this.showData();
                    this.initPlayer();
                    this.addEventListener();
                });
        }
        
        public showData() {
            // Remove elements from div
            let element = document.getElementById('player__list');
            while (element.lastElementChild) {
                element.removeChild(element.lastElementChild);
            }
            
            // Show item in list
            for (let i = 0; i < this.jsonData.length; i++) {
                if (i == this.videoIndex) {
                    continue;
                }
                
                let row = this.jsonData[i];
                
                // @ts-ignore
                let node = this.createHtml(row.VideoId, row.Title, i)

                document.getElementById("player__list").appendChild(node);
            }
        }
        
        private createHtml(videoId: string, title: string, index: number): any {
            let node = document.createElement('div');
            node.classList.add('section__video__block__list__item');
            node.setAttribute("data-index", String(index));
            // Image part
            let imageDiv = document.createElement('div');
            imageDiv.classList.add('section__video__block__list__item__image');
            let image = document.createElement('img');
            image.setAttribute("src", "https://img.youtube.com/vi/" + videoId + "/default.jpg");
            image.setAttribute("alt", "");

            imageDiv.appendChild(image);
            node.appendChild(imageDiv);

            // Text part
            let textDiv = document.createElement('div');
            textDiv.classList.add('section__video__block__list__item__text');
            let titleElm = document.createElement('h3');
            titleElm.classList.add('section__video__block__list__item__text__title');
            titleElm.innerHTML = title.slice(0, 20) + "...";

            textDiv.appendChild(titleElm);
            node.appendChild(textDiv);
            
            return node;
        }
        
        private addEventListener() {
            const elements = document.getElementsByClassName("section__video__block__list__item");

            for (let i = 0; i < elements.length; i++) {
                // @ts-ignore
                elements[i].addEventListener('click', this.eventHandler.bind(this, parseInt(elements[i].dataset.index)), false);
            }
        }
        
        private eventHandler(index: number) {
            // this.videoIndex - old index
            // index - new index
            this.videoIndex = index;
            this.preparePlayer();
            this.initPlayer();
            this.showData();
            this.addEventListener();
        }
        
        private preparePlayer() {
            let element = document.getElementById('player__container');
            while (element.lastElementChild) {
                element.removeChild(element.lastElementChild);
            }

            let node = document.createElement('div');
            node.classList.add('section__video__block__player__player');
            node.setAttribute("id", "player");
            
            document.getElementById("player__container").appendChild(node);
        }
        
        private initPlayer() {
            // @ts-ignore
            this.player = new YT.Player(this.playerElement, {
                height: '360',
                width: '640',
                // @ts-ignore
                videoId: this.jsonData[this.videoIndex].VideoId,
                events: {
                    'onReady': this.onPlayerReady.bind(this),
                    'onStateChange': this.onPlayerStateChange.bind(this)
                }
            });
        }
        
        public onPlayerReady(event: any) {
            if (this.playPlayer === false) {
                this.playPlayer = true;
            }
            else {
                event.target.playVideo();
            }
        }
        
        public onPlayerStateChange(event: any) {
            // @ts-ignore
            if (event.data == YT.PlayerState.ENDED) {
                this.videoIndex += 1;
                if (this.videoIndex >= this.jsonData.length) {
                    this.videoIndex = 0;
                }
                this.preparePlayer();
                this.initPlayer();
                this.showData();
                this.addEventListener();
            }
        }
    }
}
