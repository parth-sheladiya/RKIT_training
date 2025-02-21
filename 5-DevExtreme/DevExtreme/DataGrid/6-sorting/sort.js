$(document).ready(function(){
    console.log("docs is ready");


    $("#SortContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
        columns:[
            {
                dataField:"productId",
                caption:"id",
                dataType:"number",
            },
            {
                dataField:"productName",
                caption:"name",
                dataType:"string",
            },
            {
                dataField:"productCategory",
                caption:"category",
                dataType:"string",
                sortIndex: 1,
                sortOrder: "desc",
            },
            {
                dataField:"productCompany",
                caption:"company",
                dataType:"string",
                sortIndex:2,
                sortOrder:"asc"
            },
            {
                dataField:"productPrice",
                caption:"price",
                dataType:"number",
                sortIndex: 0,
                sortOrder: "desc",
            },
            {
                dataField:"productRating",
                caption:"rating",
                dataType:"number",
            },
            {
                dataField:"productStock",
                caption:"quantity",
                dataType:"number",
            }
        ],
        sorting: {
            mode: "multiple",  // 'multiple' | 'none' | 'single'
            showSortIndexes: true,
          },
    })
})