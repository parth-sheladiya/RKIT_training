$(document).ready(function(){
    console.log("docs is ready");

    
    

    $("#ColumnContainer").dxDataGrid({
        dataSource:products,
        allowColumnReordering: true,
        allowColumnResizing: true,
        showBorders:true,
        paging: {
            pageSize: 6,
        },
        showBorders:true,


        // auto width if you can test then go to chrome inspect 
        columnAutoWidth:true,
        // it is object 
       columnChooser:{
        enabled:true,
        allowSearch:true,
        emptyPanelText:"drag karo column",
        height:260,
        mode:"dragAndDrop", // dragAndDrop and select 
        // seaqrch time out
        searchTimeout:500,
        // title 
        title:"column chooser", 
        width:600 ,
       },
       columnFixing:{
        enabled:true , // false
        // right click col then show fix and unfix
        texts:{
            fix:"Fix",
            leftPosition:"To the left",
            rightPosition:"To the right",
            unfix:"Unfix"
        }
       },
       // if below is true then columnautowidth not working
      // columnHidingEnabled:true,
       columnMinWidth:40,
       // check resize and test it
       columnResizingMode:"nextColumn", // widget nextColumn
       // only example purpose 
       export: {
        enabled: true
    },
       columns:[
        {
            dataField:"productId",
            caption:"id",
            dataType:"number",
            alignment:"center", // center undefined  left right
            allowExporting:true,
            allowFiltering:true,
            allowGrouping:false,
            allowHeaderFiltering:false,
            allowSearch:false,
            headerFilter: {               
                allowSearch: true,                  
            },

        },
        {
            dataField:"productName",
            dataType:"string",
            alignment:"center",
            allowSearch:false,
            headerFilter: {               
                allowSearch: true,                  
            },
        },
        {
            dataField:"productCategory",
            dataType:"string",
            alignment:"center"
        },
        {
            dataField:"productPrice",
            dataType:"number",
            alignment:"center"
        },
        {
            dataField:"productRating",
            dataType:"number",
            alignment:"center"
        },
        {
            dataField:"productStock",
            dataType:"number",
            alignment:"center"
        }
    ],

    editing:{
        allowEditing:true,
        allowDeleting:true,
        mode:"row"
    },
    filterRow: {
        visible: true,
    },
    searchPanel:{
        visible:true
    },
    grouping: {
        contextMenuEnabled: true,
      },
       
    })
})