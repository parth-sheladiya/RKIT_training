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
                            showPopup(product);  
                        })
                        .appendTo(container);
                }
            }
        ]
    });

    // Initialize Popup (Initially Hidden)
    $("#PopContainer").dxPopup({
        closeOnOutsideClick:true,
        visible: false,
        disabled:false,
        dragEnabled:false ,
        fullScreen:false,
        hint:"SHOW PRODUCT DETAIILS",
        showCloseButton:false,
       // showTitle:false,
        width: 400,
        height: 300,
       
        title: "Product Details",
        contentTemplate: function(contentElement) {
            contentElement.append('<div id="popupContent"></div>');
        },
        container: "#PopContainer",
        toolbarItems:[
            {
                location:"before",
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
                options:{
                    text:"cancel Order",
                    onClick:function(){
                        DevExpress.ui.notify("order cancel successfully","error",3000);
                    }
                }
            }
        ] 
    });

    // Function to show popup with product details
    function showPopup(product) {
        var popup = $("#PopContainer").dxPopup("instance");
        var content = `
            <div>                
                <h1>${product.productCategory}</h1>
                <p><strong>Company:</strong> ${product.productCompany}</p>
                <p><strong>Price:</strong> ${product.productPrice}</p>
                <p><strong>Ratng:</strong> ${product.productRating}</p>
                <p><strong>Stock </strong> ${product.productStock}</p>


            </div>
        `;
        var contentRender = function(contentElement) {
            contentElement.html(content);
        };
        contentRender($("#popupContent"));
        
        popup.show();  
    }
})