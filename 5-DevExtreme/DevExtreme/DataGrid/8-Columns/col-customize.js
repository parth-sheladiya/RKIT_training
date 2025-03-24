$(document).ready(function(){
    console.log("docs is ready");

    
    

  let gridinst =  $("#ColumnContainer").dxDataGrid({
        dataSource:products,
        allowColumnReordering: true,
        allowColumnResizing: true,
        showBorders:true,
        showRowLines:true,
        paging: {
            pageSize: 6,
        },
        showBorders:true,
        grouping: {
            autoExpandAll: true,
        },

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
            autoExpandGroup:true,
            calculateCellValue: function(rowData) {
                rowData.amount = rowData.productPrice * rowData.productStock;  
            },
            calculateDisplayValue: function(rowData) {
                console.log("row data",rowData);
                return "₹" + rowData.amount*0.5;
                
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
            showWhenGrouped: true,
           // hidingPriority:0,
           headerCellTemplate: function(container) {
            container.append("<p style='color:green;'>ID</p>");
          },
          calculateDisplayValue: function(rowData) {
            console.log("row data",rowData);
            return "₹" + rowData.productId;
            
        }

        },
        {
            dataField:"productName",
            caption:"name",
            dataType:"string",
            alignment:"center",
            filterOperations:["startswith"], // < > <= >= |--|  = contains , not contains , startwith , endswith
           // hidingPriority:1,
            allowSearch:false,
            // add kari data tyare validation
            formItem: { isRequired: true, label: { text: "Enter name" } },
            // setCellValue: function(newData, value) {
            //     newData.productName = value.toUpperCase();
            //   },
              showEditorAlways: true,
            //   visible:false
            encodeHtml: true
            
        },
        {
            dataField:"productCategory",
           // fixed:true,
           // fixedPosition:"right", // only applicable if fixed is true
            dataType:"string",
            alignment:"center",
            // it is onbly work when mode is form or popup 
            formItem: {
                colSpan: 2,
                label: {
                    location: "top"
                }
            },
            allowHeaderFiltering: true,
            headerFilter: {               
                allowSearch: true,  
            }, 
            editCellTemplate: function(cellElement, cellInfo) {
                console.log("cell element",cellElement);
                console.log("cell info",cellInfo);
                $("<div>").dxSelectBox({
                    dataSource: ["Electronics", "Clothing", "abc"],
                    value: "",
                    // if not set select value then not shown to set category
                    onValueChanged: function(e) {
                        console.log("e.value is in edit cell temp",e.value)
                        cellInfo.setValue(e.value);
                    }
                }).appendTo(cellElement);
            },
            editorOptions: {
                placeholder: "select category",
                editorType: "dxSelectBox",
                required:true
                
            },
            cellTemplate: function(container, options) {
                let color = options.value === "Electronics" ? "green" : "red";
                container.append(`<div style="color: ${color}">${options.value}</div>`);
              },
              filterValues: ["Electronics", "Clothing"],
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
               groupInterval: 100
            },
            // col not show in chooser
            showInColumnChooser:false,
            // by default selecet
            filterOperations: ["<", ">", "between"],
            selectedFilterOperation: ">"
        },
        {
            dataField:"productRating",
            name:"rating",
            formItem: {
                colSpan: 2,    // This item will also take 2 columns
                label: {
                    location: "top"  // Label will be placed on top of the input field
                }
            },
            dataType:"number",
            alignment:"center",
            editorOptions: { placeholder: "Enter rate"},
            // if you can apply filter on and then appluy and after show log
            calculateFilterExpression:function(value,operation){
                console.log("value",value)
                console.log("operation",operation);
                if (operation === "=") {
                    return ["productRating", ">", 4.5]; 
                }
                return null;
            }
        },
        {
            dataField:"productStock",
            dataType:"number",
            selectedFilterOperation: "between", //: '<' | '<=' | '<>' | '=' | '>' | '>=' | 'between' | 'contains' | 'endswith' | 'notcontains' | 'startswith'
            alignment:"center",
            

        }
    ],
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
        enabled:true,
        contextMenuEnabled: true,
      },
    headerFilter: {    
        visible:true,           
        allowSearch: true,  
        height:500,
        width:500,                     
    },   
    }).dxDataGrid("instance")

    // console.log("grid inst",gridinst);
    
    let column = gridinst.columnOption("rating")

    console.log("column",column);
})