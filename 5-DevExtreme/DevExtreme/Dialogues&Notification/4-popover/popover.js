$(document).ready(function () {
    console.log("doc is ready");

    $("#popOverContainer").dxPopover({
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").text("This is a popover content! More info here.");
        },
        target: "#popoverBtn",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });

    // $("#DataGridContainer").dxDataGrid({
    //     dataSource: products,
    //     columns: [
    //         {
    //             dataField: "productId",
    //             caption: "productId"
    //         },
    //         {
    //             dataField: "productName",
    //             caption: "productName"
    //         },
    //         {
    //             dataField: "productCategory",
    //             caption: "category",
    //             cellTemplate(container, options) {
    //                 console.log("container", container);
    //                 console.log("options", options);
    //                 console.log("options", options.value);
    //                 const productNameLink = $("<div>")
    //                     .text(options.value)
    //                     .addClass("product-name-link")
    //                     .attr("id", `product-name-${options.data.id}`);

    //                 container.append(productNameLink);
    //                 let popoverInstance = $(`#popover-${options.data.id}`).data("dxPopover");
    //                 const popOver = $("<div>")
    //                     .attr("id", `popover-${options.data.id}`)
    //                     .dxPopover({
    //                         target: `#product-name-${options.data.id}`,
    //                         contentTemplate: function () {

    //                             return $("<div>").html(`
    //                                 <strong>Category:</strong> ${options.data.productCategory} <br>
    //                                 <strong>Company:</strong> ${options.data.productCompany} <br>
    //                                 <strong>Price:</strong> $${options.data.productPrice} <br>
    //                                 <strong>Rating:</strong> ${options.data.productRating} <br>
    //                                 <strong>Stock:</strong> ${options.data.productStock} <br>
    //                                 `)
    //                         },
    //                         closeOnOutsideClick: true,
    //                         visible: false,
    //                         disabled: false,
    //                         dragEnabled: false,
    //                         fullScreen: false,
    //                         hint: "SHOW PRODUCT DETAIILS",
    //                         showCloseButton: false,
    //                         showEvent: "mouseenter",
    //                         hideEvent: "mouseleave"
    //                     })
    //                     container.append(popOver);
    //                      productNameLink.on("mouseenter", function() {
    //                     $(`#popover-${options.data.id}`).dxPopover("show"); // Show popover
    //                 });

    //                 productNameLink.on("mouseleave", function() {
    //                     $(`#popover-${options.data.id}`).dxPopover("hide"); // Hide popover
    //                 });
    //             },
                
    //         }
            
    //     ],
        
    // })

    $("#popOverContainer1").dxPopover({
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").text("TLorem ipsum dolor sit amet consectetur adipisicing elit. Recusandae atque unde nihil quod fuga est ab quae ipsa dolorem dolor?");
        },
        target: "#popoverBtn1",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });

    $("#popOverContainer1").dxPopover({
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").text("TLorem ipsum dolor sit amet consectetur adipisicing elit. Recusandae atque unde nihil quod fuga est ab quae ipsa dolorem dolor?");
        },
        target: "#popoverBtn1",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });

    $("#popOverContainer2").dxPopover({
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").text("TLorem ipsum dolor sit amet consectetur adipisicing elit. Recusandae atque unde nihil quod fuga est ab quae ipsa dolorem dolor?");
        },
        target: "#popoverBtn2",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });

    $("#popOverContainer3").dxPopover({
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").text("TLorem ipsum dolor sit amet consectetur adipisicing elit. Recusandae atque unde nihil quod fuga est ab quae ipsa dolorem dolor?");
        },
        target: "#popoverBtn3",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });



})