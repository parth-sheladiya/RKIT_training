$(document).ready(function () {

    console.log("docs is readfy");

    const postData = new DevExpress.data.CustomStore({
        key: "id",
        // loadMode: "process",
        load() {
            return $.ajax({
                url: "https://dummyjson.com/posts?limit=240",
                dataType: "json",
                method: "GET"
            })
                .then((result) => {
                    return result.posts
                })
        }
    })

    $("#PagingGrid").dxDataGrid({
        dataSource: postData,
        showBorders: true,
        customizeColumns(columns) {
            columns[0].width = 600;
        },
        paging: {
            enabled:true,
            pageIndex:2,
            pageSize: 6,
        },
        pager: {
            visible: true,
            allowedPageSizes: [9, 13, 'all'],
            displayMode:"full", // full , compact , adaptive
           infoText:"hello pager",
            showPageSizeSelector: true,
            // page 1 to 5 
            showInfo: true,
            // < > 
            showNavigationButtons: true,
        },
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
                dataType: "string",
               
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