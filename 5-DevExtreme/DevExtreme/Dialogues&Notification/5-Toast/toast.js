$(document).ready(function(){
    console.log("doc is ready");

     // Initialize the toast widget first and store the instance
     const toast = $("#toastContainer").dxToast({
        //use in mobile
        closeOnSwipe: true,
        displayTime: 5000,
        closeOnOutsideClick:true,
        type: "success", //  'custom' | 'error' | 'info' | 'success' | 'warning'
        message: "", 
        position: { my: "top center" },
        
    }).dxToast("instance"); 

    console.log("toast",toast)
    $("#DataGridContainer").dxDataGrid({
        dataSource:products,
        onRowClick(e) {
            const message = `Name: ${e.data.productName} CateGory : ${e.data.productCategory}`;
            let toast = $("#toastContainer").dxToast("instance");
            toast.option("message", message);
            toast.show();
          },
    });

   
})