$(document).ready(function(){
    console.log("doc is ready");


    $("#AdaptabilityContainer").dxDataGrid({
        dataSource:productData,
        paging:{
            pageSize:7
        },
        showBorders: true,
        wordWrapEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        allowColumnResizing:true,
        allowColumnReordering:true,
        columnAutoWidth:true,
        //rtlEnabled:true,
        columns:[
            {
                dataField:"ID",
                dataType:"number",
                caption:"Product ID",
                hidingPriority:0
            },
            {
                dataField:"Name",
                dataType:"string",
                caption:"Product Name",
                hidingPriority:2
            },
            {
                dataField:"Category",
                dataType:"string",
                caption:"Product Category",
                hidingPriority:1
            },
            {
                dataField:"Rating",
                dataType:"number",
                caption:"Product Rating",
                hidingPriority:2
            },
            {
                dataField:"Price",
                dataType:"number",
                caption:"Product Price"
            },
            {
                dataField:"Date",
                dataType:"date",
                caption:"Manufacture Date"
            }
        ],
        columnHidingEnabled:true
    })

})