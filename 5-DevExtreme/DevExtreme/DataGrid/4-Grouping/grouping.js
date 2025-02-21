$(document).ready(function(){
    console.log("docs is ready");

    $("#GroupContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
       
        // user can rearrange column
        allowColumnReordering:false,
        columns:[
          {  
            dataField:"productId",
            dataType:"number",
            allowGrouping: false,
          },
          {  
            dataField:"productName",
            dataType:"string",
            allowGrouping: false,
          },
          {  
            dataField:"productCategory",
            dataType:"number",
            groupIndex: 0,
          },
          {
            dataField:"productPrice",
            dataType:"number",
            //groupIndex: 0,
          }
        ],
        paging: {
            pageSize: 200,
          },
        grouping:{
            // expand data
            autoExpandAll: false,
            // user can not expand data only show category
            allowCollapsing:false,
            expandMode: "buttonClick", //  buttonclick rowclick
        }
    })

})