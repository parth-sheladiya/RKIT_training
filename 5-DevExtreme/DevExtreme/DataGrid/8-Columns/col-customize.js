$(document).ready(function(){
    console.log("docs is ready");

    
    

    $("#ColumnContainer").dxDataGrid({
        dataSource:products,
        allowColumnReordering: true,
        allowColumnResizing: true,
        showBorders:true,
        showRowLines:true,
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
        enabled: true,
    },
    // false text , true text it is only use in bool column 
    // replace bool to custom text 
    // falseText:"not available"
       columns:[
        {
            
            width:200,
            caption:"buttons",
            type:"buttons",
            buttons:[
                {
                    name:"edit",
                    icon:"edit",
                    hint: "this is edit button",
                    visible:true,
                    onClick:(e)=>{
                        e.component.editRow(e.row.rowIndex);
                        DevExpress.ui.notify("edit","success",5000)
                    }
                },
                {
                    name:"delete",
                    icon:"deleterow",
                    visible:true,
                    onClick:(e)=>{
                        e.component.getDataSource().remove(e.row.data);
                        DevExpress.ui.notify("delete","success",6000)
                    }
                }
            ]
        },
        {
            caption:"Address",
            columns:["city","street","flat"],
          
        },
        // it is purpose for calculatecellvalue
        // and reordering
        {
            caption: "Sales Amount",
            //minWidth:10,
            //Specifies the column's unique identifier. 
            //If not set in code, this value is inherited from the dataField.
            name:"amount",
            alignment:"center",
            calculateCellValue: function(rowData) {
                return rowData.productPrice * rowData.productStock;
            }
        },
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
           // hidingPriority:0

        },
        {
            dataField:"productName",
            caption:"name",
            dataType:"string",
            alignment:"center",
            filterOperations:["startswith"], // < > <= >= |--|  = contains , not contains , startwith , endswith
           // hidingPriority:1,
            allowSearch:false,
            
            
        },
        {
            dataField:"productCategory",
           // fixed:true,
           // fixedPosition:"right", // only applicable if fixed is true
            dataType:"string",
            alignment:"center",
            // it is onbly work when mode is form or popup 
            // formItem: {
            //     colSpan: 2,
            //     label: {
            //         location: "top"
            //     }
            // },
            allowHeaderFiltering: true,
            headerFilter: {               
                allowSearch: true,  
            }, 
            filterType:"include",   // include exclude    
          //  filterValues: ["Electronics", "Clothing"] 
          // if column is fixed then it will be ignored
          //hidingPriority:2   
          // combine two column
        //   isBand:true,
        //   columns: [
        //     {
        //         dataField: "productName",
        //         caption: "Product Name"
        //     },
        //     {
        //         dataField: "productCategory",
        //         caption: "Category"
        //     }
        // ]      
        },
        {
            dataField:"productPrice",
            format: {
                type: "fixedPoint",  // Use fixed-point format for numbers
                precision: 2          // Display 2 decimal places
            },
            dataType:"number",
            alignment:"center",
          //  filterValue: 100,
            // customize text for rs 
            customizeText: function(info){
                return  info.value + " ₹";
            },
            headerFilter:{
                visible: true,
               
            },
            // col not show in chooser
            showInColumnChooser:false
            
            
        },
        {
            dataField:"productRating",
            formItem: {
                colSpan: 2,    // This item will also take 2 columns
                label: {
                    location: "top"  // Label will be placed on top of the input field
                }
            },
            dataType:"number",
            alignment:"center"
        },
        {
            dataField:"productStock",
            
            dataType:"number",
            selectedFilterOperation: "between", //: '<' | '<=' | '<>' | '=' | '>' | '>=' | 'between' | 'contains' | 'endswith' | 'notcontains' | 'startswith'
            alignment:"center",
            

        }
    ],
    // filterexpression
    // filterValue:[100],
    // calculateFilterExpression:(filterValue,field)=>{
    //     if(field.dataField === "productPrice"){
    //         return ["productPrice",">=",filterValue[0]];
    //     }
    //     return filterValue;
    // },
    editing:{
        allowEditing:true,
        allowDeleting:true,
        allowAdding:true,
        mode:"form"
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
    headerFilter: {    
        visible:true,           
        allowSearch: true,  
        height:500,
        width:500,                     
    },   
    })
})