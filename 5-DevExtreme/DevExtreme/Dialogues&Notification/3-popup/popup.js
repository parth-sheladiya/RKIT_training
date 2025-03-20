// var product = products;
// console.log(product)
// var temp=`
//         <div>                
//             <h1>${product.productCategory}</h1>
//             <p><strong>Company:</strong> ${product.productCompany}</p>
//             <p><strong>Price:</strong> ${product.productPrice}</p>
//             <p><strong>Ratng:</strong> ${product.productRating}</p>
//             <p><strong>Stock </strong> ${product.productStock}</p>
//             <h1>${product.productCategory}</h1>
//             <p><strong>Company:</strong> ${product.productCompany}</p>
//             <p><strong>Price:</strong> ${product.productPrice}</p>
//             <p><strong>Ratng:</strong> ${product.productRating}</p>
//             <p><strong>Stock </strong> ${product.productStock}</p>
//             <h1>${product.productCategory}</h1>
//             <p><strong>Company:</strong> ${product.productCompany}</p>
//             <p><strong>Price:</strong> ${product.productPrice}</p>
//             <p><strong>Ratng:</strong> ${product.productRating}</p>
//             <p><strong>Stock </strong> ${product.productStock}</p>
//             <h1>${product.productCategory}</h1>
//             <p><strong>Company:</strong> ${product.productCompany}</p>
//             <p><strong>Price:</strong> ${product.productPrice}</p>
//             <p><strong>Ratng:</strong> ${product.productRating}</p>
//             <p><strong>Stock </strong> ${product.productStock}</p>
//             <h1>${product.productCategory}</h1>
//             <p><strong>Company:</strong> ${product.productCompany}</p>
//             <p><strong>Price:</strong> ${product.productPrice}</p>
//             <p><strong>Ratng:</strong> ${product.productRating}</p>
//             <p><strong>Stock </strong> ${product.productStock}</p>                        
//         </div>
//     `;
$(document).ready(function(){
    console.log("doc is ready");
    // create data grid
    $("#DataGridContainer").dxDataGrid({
        // data
        dataSource: products,
        // columns
        columns: [
            { dataField: "productId", caption: "productId" },
            { dataField: "productName", caption: "productName" },
            {
                caption: "Actions",
                // custom 
                cellTemplate: function(container, options) {
                    $("<button>")
                        .text("View Details")
                        .on("click", function() {
                            var product = options.data;
                            // showPopup(product);
                            window.content = `
                                    <div>                
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>
                                        <h1>${product.productCategory}</h1>
                                        <p><strong>Company:</strong> ${product.productCompany}</p>
                                        <p><strong>Price:</strong> ${product.productPrice}</p>
                                        <p><strong>Ratng:</strong> ${product.productRating}</p>
                                        <p><strong>Stock </strong> ${product.productStock}</p>                        
                                    </div>
                                `;
                          
                            dxpopUpInstance.show();
                        })
                        .appendTo(container);
                }
            }
        ]
    });

    // Initialize Popup (Initially Hidden)
  let dxpopUpInstance =   $("#PopContainer").dxPopup({
        closeOnOutsideClick:true,
        visible: false,
        disabled:false,
        dragEnabled:false ,
        fullScreen:false,
        hint:"SHOW PRODUCT DETAIILS",
        showCloseButton:false,
       // showTitle:false,
        // width: 400,
        // height: 300,
       
        title: "Product Details",
        titleTemplate: ()=>{
                        return $(`<div>`).html(`<img  src="download.jpg" height="50px" >`)
                    },
        contentTemplate: function() {
            // Create a div container for the ScrollView
            let scrollView = $("<div/>");

            // Append the content inside the ScrollView
            scrollView.html(window.content);

            // Initialize the ScrollView inside the div
            scrollView.dxScrollView({

                // width 
                width: "100%",  

                // height
                height: "100%"  

            });
            return scrollView;
           
        },
       
        container: "#PopContainer",
        toolbarItems:[
            {
                location:"before",
                widget:"dxButton",
                toolbar:"bottom",
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
                    text:"cancel order",
                    onClick:function(){
                        DevExpress.ui.notify("order cancel successfully","error",3000);
                    }
                }
            }
        ] 
    }).dxPopup("instance");

   
})