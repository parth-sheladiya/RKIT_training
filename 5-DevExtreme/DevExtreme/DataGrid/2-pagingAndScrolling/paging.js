$(document).ready(function () {

    console.log("docs is readfy");

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

    $("#PagingGrid").dxDataGrid({
        dataSource: postData,
        showBorders: true,
        customizeColumns(columns) {
            columns[0].width = 60;
        },
        paging: {
            enabled:true,
            pageIndex:2,
            pageSize: 6,
        },
        pager: {
            visible: true,
            allowedPageSizes: [9, 13, 'all'],
            showPageSizeSelector: true,
            showInfo: false,
            showNavigationButtons: true,
        },
        colums: [
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