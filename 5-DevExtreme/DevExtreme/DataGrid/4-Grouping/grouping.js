$(document).ready(function(){
    console.log("docs is ready");

    $("#GroupContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
        customizeColumns: (columns) => {
          columns[0].width = 100;
        
        },
        // user can rearrange column
        allowColumnReordering:false,
        columns:[
          {  
            dataField:"productId",
            dataType:"number",
          //  allowGrouping: false,
          },
          {  
            dataField:"productName",
            dataType:"string",
           // allowGrouping: false,
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
        pager: {
          allowedPageSizes: [5, 8, 15, 30],
          showInfo: true,
          showNavigationButtons: true,
          showPageSizeSelector: true,
          visible: true,
        },
        paging: {
            pageSize: 5,
          },
        grouping:{
            // expand data
            autoExpandAll: true,
            // user can not expand data only show category
            allowCollapsing:true,
            expandMode: "rowClick", //  buttonclick rowclick
            // user can right click then show group by this column
            contextMenuEnabled:true,
            texts:{
              // default string  check docs
              groupByThisColumn:"please grouping",
              groupContinuedMessage:"continueds",
              groupContinuesMessage:"continue",
              ungroup:"ungroup please",
              ungroupAll:"please ungroup all"             
            },
        },
        groupPanel:{
       // show on ui
          visible:true,
          allowColumnDragging:true,
          emptyPanelText:"Drag a column header here to group by that column"
        }
    })
})