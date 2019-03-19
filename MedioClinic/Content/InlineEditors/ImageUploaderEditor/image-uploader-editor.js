(function () {
    window.kentico.pageBuilder.registerInlineEditor("image-uploader-editor", {
        init: function (options) {
            var editor = options.editor;
            var zone = editor.querySelector(".dz-uploader");
            var clickable = editor.querySelector(".dz-clickable");

            var dropzone = new Dropzone(zone, {
                acceptedFiles: ".bmp, .gif, .ico, .png, .wmf, .jpg, .jpeg, .tiff, .tif",
                maxFiles: 1,
                url: editor.getAttribute("data-upload-url"),
                createImageThumbnails: false,
                clickable: clickable,
                dictInvalidFileType: "Unsupported file type. Please upload files of the following types: .bmp, .gif, .ico, .png, .wmf, .jpg, .jpeg, .tiff, .tif"
            });

            var processErrors = function (statusCode) {
                var errorFlag = "error";

                if (statusCode >= 500) {
                    showMessage("The upload of the image failed. Please contact the system administrator."), errorFlag);
                } else if (statusCode === 422) {
                    showMessage("The uploaded image could not be processed. Please contact the system administrator."), errorFlag);
                } else {
                    showMessage("An unknown error happened. Please contact the system administrator."), errorFlag);
                }
            };

            var showMessage = function (message, type) {
                var messageElement = document.querySelector(".kn-system-messages");

                if (message && type) {
                    if (type === "info") {
                        messageElement.appendChild(buildMessageMarkup(message, "light-blue lighten-5"));
                        console.info(message);
                    } else if (type === "warning") {
                        messageElement.appendChild(buildMessageMarkup(message, "yellow lighten-3"));
                        console.warn(message);
                    } else if (type === "error") {
                        messageElement.appendChild(buildMessageMarkup(message, "red lighten-3"));
                        console.error(message);
                    }
                }
            };

            var buildMessageMarkup = function (message, cssClasses) {
                var paragraph = document.createElement("p");
                paragraph.classList = cssClasses;
                paragraph.innerText = message;

                return paragraph;
            };

            dropzone.on("success",
                function (e) {
                    var content = JSON.parse(e.xhr.response);

                    var event = new CustomEvent("updateProperty",
                        {
                            detail: {
                                value: content.guid,
                                name: options.propertyName
                            }
                        });

                    editor.dispatchEvent(event);
                });

            dropzone.on("error",
                function (e) {
                    document.querySelector(".dz-preview").style.display = "none";
                    processErrors(e.xhr.status, options.localizationService);
                });

            destroy: function (options) {
                var dropZone = options.editor.querySelector(".dz-uploader").dropzone;

                if (dropZone) {
                    dropZone.destroy();
                }
            }
        }
    });
})();