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

    $("#popOver1").dxPopover({
        closeOnOutsideClick: true,
        target: '#pop1',
        contentTemplate: function (contentElement) {
            contentElement.append('<div>Popover 1 Content: Lorem ipsum dolor sit amet.</div>');
        },
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'top',
        width: 300,
    });

    $("#popOver2").dxPopover({
        closeOnOutsideClick: true,
        target: '#pop2',
        contentTemplate: function (contentElement) {
            contentElement.append('<div>Popover 2 Content: Lorem ipsum dolor sit amet.</div>');
        },
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'bottom',
        width: 300,
        showTitle: true,
        title: 'Details:',
    });

    $("#popOver3").dxPopover({
        closeOnOutsideClick: true,
        target: '#pop3',
        contentTemplate: function (contentElement) {
            contentElement.append('<div>Popover 3 Content: Lorem ipsum dolor sit amet.</div>');
        },
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'top',
        width: 300,
        animation: {
            show: {
                type: 'pop',
                from: { scale: 0 },
                to: { scale: 1 },
            },
            hide: {
                type: 'fade',
                from: 1,
                to: 0,
            },
        },
    });

    $("#popOver4").dxPopover({
        closeOnOutsideClick: true,
        target: '#pop4',
        contentTemplate: function (contentElement) {
            contentElement.append('<div>Popover 4 Content: Lorem ipsum dolor sit amet.</div>');
        },
        showEvent: 'dxclick',
        hideEvent: 'mouseleave',
        position: 'top',
        width: 300,
        shading: true,
        shadingColor: 'rgba(0, 0, 0, 0.5)',
    });


})