$(document).ready(function(){
    console.log("docs is ready");



  let selInst =  $("#SelectionContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
        paging: {
            pageSize: 7,
        },
        columns:[
            {
                dataField:"productId",
                dataType:"number",
            },
            {
                dataField:"productName",
                dataType:"string",
            },
            {
                dataField:"productCategory",
                dataType:"string",
            },
            {
                dataField:"productPrice",
                dataType:"number",
            },
            {
                dataField:"productRating",
                dataType:"number",
            },
            {
                dataField:"productStock",
                dataType:"number",
            }
        ],
        selection: {
            mode: 'multiple', // single , multiple , none
            allowSelectAll:true, // default
            showCheckBoxesMode:"always", // onclick , onlongtap,always,none
            selectAllMode:"allPages", //allPages , page
             deferred: true
        },
        editing:{
            allowUpdating:true,
            allowDeleting:true,
        },
        onSelectionChanged(e) {
            
            console.log("Selected Products: ", selInst.getSelectedRowsData().done((data) => {
                console.log("Selected Products defered:", data);
            })
        );
            console.log("Selected Products: ", e.selectedRowsData);
        }
    }).dxDataGrid("instance");

   
})