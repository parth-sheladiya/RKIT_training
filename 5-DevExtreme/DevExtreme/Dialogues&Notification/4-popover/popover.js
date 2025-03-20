$(document).ready(function () {
    console.log("doc is ready");
    // popover 
    $("#popOverContainer").dxPopover({
        // out click
        closeOnOutsideClick: true,
        contentTemplate: function () {
            return $("<div>").html("<h1>This is a popover content! More info here.</h1>");
        },
        target: "#popoverBtn",
        showEvent: "mouseenter",
        hideEvent: "mouseleave"
    });


    $("#pop1").dxPopover({
        closeOnOutsideClick: true,
        target: '#popOver1',
        contentTemplate: function (contentElement) {
            contentElement.append('<div>Popover 1 Content: Lorem ipsum dolor sit amet.</div>');
            contentElement.append('<div>Popover 1 Content: Lorem ipsum dolor sit amet.</div>');
        },
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'top',
        width: 300,
        height:500,
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
        //title: 'Details:',
        titleTemplate:()=>{
            return $(`<div>`).html(`<img  src="download.jpg" height="50px" >`)
        }
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
                to: { scale: 5 },
            },
            hide: {
                type: 'fade',
                from: 20,
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
        // we can use multiple evensts
        //showEvent: 'dblclick click',
        showEvent:{
            name:"mouseenter",
            delay:3000
        },
        hideEvent: 'mouseleave',
        position: 'right',
        width: 300,
        shading: true,
        shadingColor: 'rgba(0, 0, 0, 0.5)',
    });


})