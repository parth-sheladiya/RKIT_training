$(document).ready(function(){
    console.log("doc is ready");
    $("#DataGridContainer").dxDataGrid({
        dataSource: products,
        columns: [
            { dataField: "productId", caption: "productId" },
            { dataField: "productName", caption: "productName" },
            {
                caption: "Actions",
                cellTemplate: function(container, options) {
                    $("<button>")
                        .text("View Details")
                        .on("click", function() {
                            var product = options.data;
                             window.content = `
                                    <div>                
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                    </div>
                                `;
                            
                                dxPopUpInstance.show();
                               
                        })
                        .appendTo(container);
                }
            }
        ]
    });

    // Initialize Popup (Initially Hidden)
   let dxPopUpInstance =  $("#PopContainer").dxPopup({
        closeOnOutsideClick:true,
        visible: false,
        disabled:false,
        dragEnabled:true ,
        fullScreen:false,
        hint:"SHOW PRODUCT DETAIILS",
        showCloseButton:false,
        //showTitle:true,
         width: 400,
         height: 500,
       
        //title: "Product Details",
        titleTemplate: (e)=>{
            return $(`<div>`).html(`<img  src="download.jpg" height="200px" >`)
        },
        
        
        contentTemplate: function () {
            
            // Create a div container for the ScrollView
            let scrollView = $("<div/>");

            // Append the content inside the ScrollView
            scrollView.append($("<div/>").html(window.content));

            // Initialize the ScrollView inside the div
            scrollView.dxScrollView({

                // ScrollView width (can be %, px, etc.)
                width: "100%",  

                // ScrollView height
                height: "100%"  

            });

            return scrollView; // Return the ScrollView container
        },
        container: ".dx-viewport",
        toolbarItems:[
            {
                locateInMenu: 'always',
                location:"after",
                toolbar:"bottom",
                widget:"dxButton",
                options:{
                    text:"close",
                    icon:"close",
                    onClick: function() {
                        var popup = $("#PopContainer").dxPopup("instance");
                        popup.hide();  
                    }
                }
            },
            {
                location:"after",
                widget:"dxButton",
                toolbar:"bottom",
                options:{
                    text:"order",
                    onClick:function(){
                        DevExpress.ui.notify("order add successfully","success",3000);
                    }
                }
            },
            {
                location:"center",
                widget:"dxButton",
                toolbar:"bottom",
                options:{
                    text:"cancel Order",
                    onClick:function(){
                        DevExpress.ui.notify("order cancel successfully","error",3000);
                    }
                }
            }
        ] ,
       
    }).dxPopup("instance");
        

      
         

})