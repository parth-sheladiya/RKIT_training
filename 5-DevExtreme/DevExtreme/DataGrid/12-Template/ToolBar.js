$(document).ready(function(){
    console.log("docs is ready");

      $("#ToolbarContainer").dxDataGrid({
        dataSource:orders,
        keyExpr:"ID",
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        columnAutoWidth:true,
        loadPanel:{
            enabled:true
        },
        columns:[
            {
                dataField:"OrderNumber",
                dataType:"number",
                caption:"Order number"
            },
            {
                dataField:"OrderDate",
               // dataType:"date",
                caption:"Order date"
            }, 
            {
                dataField:"Employee",
                dataType:"string",
                caption:"Employee Name"
            }, 
            {
                dataField:"TotalAmount",
                dataType:"number",
                caption:"Total Amount"
            },
            {
                dataField:"SaleAmount",
                dataType:"number",
                caption:"Sale Amount"
            }
        ],
        // toolbar:{
        //     items:[
        //        {
        //         location:"before",
        //         template:()=>{
        //             return $('<div>')
        //             .addClass('informer')
        //             .append(
        //               $('<div>')
        //                 .addClass('count')
        //                 .text(getGroupCount('CustomerStoreState')),
        //               $('<span>')
        //                 .text('Total Count'),
        //             );
        //         }
        //        },
        //     ]
        // }
        
      })  

})