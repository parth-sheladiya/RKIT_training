$(document).ready(function(){
    console.log("docs is ready");

    $("#FilterContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
        columnsAutoWidth:true,
        allowColumnReordering: true,
        paging: {
            pageSize: 7,
          },
          groupPanel: {
            visible: true,
          },
        columns:[
            {
                dataField:"productId",
                dataType:"number"
            },
            {
                dataField:"productName",
                dataType:"string"
            },
            {
                dataField:"productCategory",
                dataType:"string"
            },
            {
                dataField:"productCompany",
                dataType:"string"
            },
            {
                dataField:"productPrice",
                dataType:"number"
            },
            {
                dataField:"productRating",
                dataType:"number"
            },
            {
                dataField:"productStock",
                dataType:"number"
            }
        ],
        filterRow:{
            // show on ui with search iconm
            visible:true, // false
            applyFilter: "onClick" ,    // auto   onclick
            // green color btn
            applyFilterText :"apply filter show on ui ",
            // if user click search icon in column then click between then show text
            betweenEndText:"ends enter" ,
            betweenStartText:"starts enter",
            // operationDescriptions it is for user special
            // contains staert with end with between 
            operationDescriptions:{
                between:" Between hai"
            },
            showOperationChooser:true, // default true
            

        },
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: 'Search...',
          },
        // filterBuilderPopup: {
        //     position: {
        //       of: window, at: 'top', my: 'top', offset: { y: 100 },
        //     },
        //   },
        // show on ui after grid template
        // if you can add filter value then filtervalue show in filter panel
        // just example purpose 
        filterPanel:{
            visible:true,
            texts:{
                createFilter:"please create filter",
                clearFilter:"please remove filter"
            },
            filterEnabled: false // default true
        },
        headerFilter:{
            // col name after symbol 
            visible:true,
        },
        filterValue:[
            [['productName','=','Refrigerator'], 'and',['productCategory','=','Home Appliances']]
        ]
    })


})