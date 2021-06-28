namespace web {
    export class EditorController{
        private editor: any;
        
        constructor() {
            console.log("LOG text");
            this.Init();

            document.querySelectorAll("input[type=submit]")[0]
                .addEventListener('click', this.HandleSubmit.bind(this), false);
        }
        
        private Init() {
            // @ts-ignore
            this.editor = new Quill('#editor', {
                modules: {
                    toolbar: [
                        ['bold', 'italic'],
                        ['link', 'blockquote', 'code-block'],
                        [{ list: 'ordered' }, { list: 'bullet' }]
                    ]
                },
                placeholder: '...',
                theme: 'snow'
            });
        }
        
        public HandleSubmit() {
            console.info('handleSubmit called');
            // @ts-ignore
            document.getElementById('editor-value').value = this.editor.root.innerHTML;
        }
    }
}