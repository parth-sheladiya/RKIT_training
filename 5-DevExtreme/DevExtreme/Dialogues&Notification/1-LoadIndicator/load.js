$(document).ready(function () {
    console.log("doc is ready");

    const cartsData = [
        {
            id: 1,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Charger%20SXT%20RWD/thumbnail.png"
        },
        {
            id: 2,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Electric%20Scooter/thumbnail.png"
        },
        {
            id: 3,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Charger%20SXT%20RWD/thumbnail.png"
        },
        {
            id: 4,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Electric%20Scooter/thumbnail.png"
        },
        {
            id: 5,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Charger%20SXT%20RWD/thumbnail.png"
        },
        {
            id: 6,
            thumbnail: "https://cdn.dummyjson.com/products/images/vehicle/Electric%20Scooter/thumbnail.png"
        }
    ];

    // Initialize DataGrid with the carts data
    $("#LoadContainer").dxDataGrid({
        dataSource: cartsData,
        columns: [
            {
                dataField: "id",
                caption: "Cart ID"
            },
            {
                dataField: "thumbnail",
                caption: "Product Thumbnail",
                cellTemplate: function (container, options) {
                    console.log("container", container);
                    console.log("options", options);

                    const thumbnailUrl = options.value;
                    console.log("thumb nail url", thumbnailUrl)
                    // Create a container for LoadIndicator and image
                    const indicatorContainer = $("<div>").appendTo(container);
                    console.log("indicator container", indicatorContainer)

                    const loadIndicator = $("<div>").dxLoadIndicator({
                        visible: true,
                        width: 50,
                        height: 50
                    }).appendTo(indicatorContainer);
                    console.log("loadIndicator", loadIndicator)

                    // Create an image element for the thumbnail
                    const img = $("<img>").attr("src", thumbnailUrl).css({
                        width: "100px",
                        height: "100px",
                        display: "none"
                    }).appendTo(indicatorContainer);
                    console.log("img", img)

                    img.on("load", function () {
                        loadIndicator.dxLoadIndicator("instance").option("visible", false);
                        img.css("display", "block");
                    });
                }
            }
        ],

    });
});