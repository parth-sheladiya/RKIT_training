$(document).ready(function(){
    console.log("document is ready");

    $("#ApperanceContainer").dxDataGrid({
        dataSource:products,
        showBorders: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
      
        columns: [
            {
                dataField: "productId",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productName",
                dataType: "string",
                alignment: "right"
            },
            {
                dataField: "productCategory",
                dataType: "string",
                alignment: "right"
            },
            {
                dataField: "productPrice",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productRating",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productStock",
                dataType: "number",
                alignment: "center"
            }
        ],
        paging: {
            pageSize: 5,
          },
    })
})