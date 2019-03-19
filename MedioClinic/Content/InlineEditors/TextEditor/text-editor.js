(function () {
    window.kentico.pageBuilder.registerInlineEditor("text-editor", {
        init: function (options) {
            var editor = options.editor;
            var config = {
                toolbar: {
                    buttons: [
                        "bold",
                        "italic",
                        "underline",
                        "orderedlist",
                        "unorderedlist",
                        "h1",
                        "h2",
                        "h3",
                        "customHtml"
                    ]
                },
                imageDragging: false,
                extensions: {
                  imageDragging: {}
                }
            };

            var mediumEditor = new MediumEditor(editor, config);

            mediumEditor.subscribe("editableInput", function () {
                var event = new CustomEvent("updateProperty", {
                    detail: {
                        name: options.propertyName,
                        value: mediumEditor.getContent(),
                        refreshMarkup: false
                    }
                });

                editor.dispatchEvent(event);
            });
        },

        destroy: function (options) {
            var mediumEditor = MediumEditor.getEditorFromElement(options.editor);
            if (mediumEditor) {
                mediumEditor.destroy();
            }
        }
    });
})();

div.medium-editor-anchor-preview, div.medium-editor-toolbar {
    z-index: 100000;
}

.medium-editor-element:focus {
    outline: 0;
}

.medium-editor-element:not([data-medium-focused]):hover {
    background-color: rgba(155, 155, 155, 0.17);
}

.medium-editor-placeholder:after {
    position: relative !important;
}

.medium-editor-placeholder *:only-child br:only-child {
    display: none;
}