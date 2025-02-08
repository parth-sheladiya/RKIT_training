$(document).ready(function () {
    $("#fileUploder").dxFileUploader({
        // abort process cancels the file upload
        abortUpload: () => { },
        accept: "image/*",
        accessKey: "h", // accept only image files
        allowCanceling:true, // user can cancle file upload default false
        allowedFileExtensions: [".jpg", ".jpeg"] , // default value empty arr of str
        hint: "this is file content",
        selectButtonText:"upload file",  // btn text
        invalidFileExtensionMessage: "this extension is invalid",
        invalidMaxFileSizeMessage: "your file size is greater than maxsize",
        invalidMinFileSizeMessage: "your file size is less than min size",
        labelText: "file upload here",
        maxFileSize: 1048576,
        minFileSize: 1024,
        multiple: true, // default false
        showFileList:true, // default true below lisat file
        onProgress: function (e) {
            console.log("Upload progress:", e.bytesLoaded / e.bytesTotal * 100, "%");
        },
        readyToUploadMessage: "file is ready to upload", 
        
    })

    
})