$(document).ready(function () {
    console.log("docs is ready");

    // $("#GridContainer").dxDataGrid({
    //     dataSource: new DevExpress.data.CustomStore({
    //         key: "id",
    //         loadMode: "raw",
    //         load: () => {
    //             return $.ajax({
    //                 url: "https://dummyjson.com/posts",
    //                 method:"GET",
    //             })
    //             .then((res)=>{
    //                 console.log("scroll result",res)
    //                 return res.posts
    //             })
    //         }
    //     })
    // })

    const postData = new DevExpress.data.CustomStore({
        key: "id",
        loadMode: "raw",
        load() {
            return $.ajax({
                url: "https://dummyjson.com/posts?limit=251",
                dataType: "json",
                method: "GET"
            })
                .then((result) => {
                    return result.posts
                })
        }
    })

    $("#GridContainer").dxDataGrid({
        dataSource:postData,
        showBorders:true,
        height:400,
        
        scrolling:{
            // pagination is not  show all are render in one frame
            mode:"infinite", // bydefault standred , virtual ,infinite
            // show scroll bar
            useNative:false,
            preloadEnabled:false,
            scrollByContent:true,
            showScrollbar:"onScroll" , // onScroll onHover always
            // scroll by content false you can not scroll using mous click
            scrollByThumb:false,
        },
        paging:{enabled:true},
        columns: [
            {
                dataField: "id",
                dataType: "number"
            },
            {
                dataField: "title",
                dataType: "string",
            },
            {
                dataField: "body",
                dataType: "string"
            },
            {
                dataField: "views",
                dataType: "number",
            },
            {
                dataField: "userId",
                dataType: "number"
            }
        ]
    })
})