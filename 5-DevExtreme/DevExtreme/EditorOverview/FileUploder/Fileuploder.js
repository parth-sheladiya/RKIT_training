$(document).ready(function () {
    $("#fileUploder").dxFileUploader({
        uploadUrl: "https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload", 
        // abort process cancels the file upload
        abortUpload: () => { },
        accept: "image/*",// accept only image files
        accessKey: "h", 
        allowCanceling:true, // user can cancle file upload default true
        allowedFileExtensions: [".jpg", ".jpeg" , ".png"] , // default value empty arr of str
        hint: "this is file content",
        selectButtonText:"upload file",  // btn text
        invalidFileExtensionMessage: "this extension is invalid",
        invalidMaxFileSizeMessage: "your file size is greater than maxsize",
        invalidMinFileSizeMessage: "your file size is less than min size",
        uploadFailedMessage:"upload failed ",
        labelText: "file upload here",
        maxFileSize: 1048576,
        minFileSize: 1024,
        multiple: true, // default false
        showFileList:true, // default true below lisat file
        onProgress: function (e) {
            console.log("Upload progress:", e.bytesLoaded / e.bytesTotal * 100, "%");
        },
        readyToUploadMessage: "file is ready to upload", 
        uploadMethod:"POST",
        uploadMode: "useButtons", //intantly

        onBeforeSend: (e) => {
            console.log("onBeforeSend",e);
        },
        onUploadStarted: (e) => {
            console.log("onUploadStarted");
        },
        onUploaded: (e) => {
            console.log("onUploaded", e);
        },
        onUploadError: (e) => {
            console.log("onUploadError",e);
        },
        onFilesUploaded: (e) => {
            console.log("onFilesUploaded",e);
        },
        onUploadAborted: (e) => {
            console.log("onUploadAborted",e);
        },


    })

    $("#fileUploader").dxFileUploader({
        uploadUrl: "https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload", 
        multiple: true,
        uploadMode: "useButtons",
        dropZone: "#drop-area"
    });

})



    