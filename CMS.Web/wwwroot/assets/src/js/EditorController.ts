namespace web {
    export class EditorController{
        private editor: any;
        
        constructor() {
            this.init();

            document.querySelectorAll("input[type=submit]")[0]
                .addEventListener('click', this.handleSubmit.bind(this), false);
        }
        
        private init() {
            if (document.getElementById('editor-value') == null){
                return;
            }
            
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
        
        public handleSubmit() {
            // @ts-ignore
            document.getElementById('editor-value').value = this.editor.root.innerHTML;
        }
    }
}