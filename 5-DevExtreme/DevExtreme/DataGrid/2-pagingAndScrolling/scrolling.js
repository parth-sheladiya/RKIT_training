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
                url: "https://dummyjson.com/posts",
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
            mode:"standred", // bydefault standred , virtual ,infinite
            // show scroll bar
            useNative:false,
            preloadEnabled:true,
            scrollByContent:false,
            showScrollbar:"always" , // onScroll onHover always
            // scroll by content false you can not scroll using mous click
            scrollByThumb:false,
        

        },
        paging:{enabled:false},
    })
})