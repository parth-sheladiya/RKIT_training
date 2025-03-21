$(document).ready(function () {
   let fileInst = $("#fileUploder").dxFileUploader({
        uploadUrl: "https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload", 
        // abort process cancels the file upload
        abortUpload: (e) => {
            console.log("abort upload",e);
            setTimeout(function(){
                $("#fileUploder").dxFileUploader("dispose")
            },3000)
         },
        accept: "image/*",// accept only image files
        accessKey: "h", 
        // if user can value false then not work abort upload
        allowCanceling:true, // user can cancle file upload default true
        allowedFileExtensions: [".jpg", ".jpeg" , ".png"] , // default value empty arr of str
        hint: "this is file content",
        dialogTrigger:"#drop-area",
        selectButtonText:"upload file",  // btn text
        invalidFileExtensionMessage: "this extension is invalid",
        invalidMaxFileSizeMessage: "your file size is greater than maxsize",
        invalidMinFileSizeMessage: "your file size is less than min size",
        uploadFailedMessage:"upload failed ",
        labelText: "file upload here",
        // show in lg
        maxFileSize: 4194304,
        minFileSize: 1024,
        multiple: true, // default false
        showFileList:true, // default true below lisat file
        uploadChunk: true, 
        chunkSize: 1048576, 
        onProgress: function (e) {
            console.log("Upload progress:", e.bytesLoaded / e.bytesTotal * 100, "%");
        },
        readyToUploadMessage: "file is ready to upload", // only usebuttons
        uploadMethod:"POST",
        uploadMode: "useButtons", //intantly useForm

        onBeforeSend: (e) => {
            console.log("onBeforeSend",e);
            fileInst.css("background-color", "green");
        },
        onUploadStarted: (e) => {
            console.log("onUploadStarted");
            // fileInst.css("background-color", "green");
        },
        onUploaded: (e) => {
            console.log("onUploaded", e);
           
        },
        onUploadError: (e) => {
            console.log("onUploadError",e);
            fileInst.css("background-color", "red");
        },
        onFilesUploaded: (e) => {
            console.log("onFilesUploaded",e);
        },
        onUploadAborted: (e) => {
            console.log("onUploadAborted",e);
            fileInst.css("background-color", "red");
        },
        onValueChanged:(e)=>{
            console.log("e",e.value)
        },
        onOptionChanged:(e)=>{
            console.log("e name", e.name ,"new val", e.value)
        }


    })

    $("#fileUploader").dxFileUploader({
        uploadUrl: "https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload", 
        multiple: true,
        uploadMode: "useButtons",
        dropZone: "#drop-area"
    }).dxFileUploader("instance");

})

// uploadfile manuallly file upload
// uploadCustomData : custom data
// uploadHeaders set request header
// uploadMethod 

    