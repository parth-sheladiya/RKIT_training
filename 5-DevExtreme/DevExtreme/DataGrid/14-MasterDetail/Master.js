$(document).ready(function(){
    console.log("doc is ready");

    $("#MasterContainer").dxDataGrid({
        dataSource:productData,
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        paging:{
            pageSize:6
        },
        columns:[
            {
                dataField:"ID",
                dataType:"number",
                caption:"Product ID",
                alignment:"center"
            },
            {
                dataField:"Name",
                dataType:"string",
                caption:"Product Name",
                alignment:"center"
            },
            {
                dataField:"Category",
                dataType:"string",
                caption:"Product Category",
                alignment:"center"
            }
        ],
        masterDetail:{
            enabled:true,
            template(container,options){
                const currentProductData = options.data;
                $("<div>")
                        .addClass("master-detail-caption")
                        .text(`${currentProductData.ID} ${currentProductData.Name} Desciption`)
                        .appendTo(container);
                $("<div>")
                        .dxDataGrid({
                            
                            columnAutoWidth:true,
                            showBorders:true,
                            columns:[
                                {
                                    dataField:"Rating",
                                    dataType:"",
                                    caption:"",
                                },
                                {
                                    dataField:"Price",
                                    dataType:"",
                                    caption:"",
                                },
                                {
                                    dataField:"Date",
                                    dataType:"",
                                    caption:"",
                                },

                                {
                                    dataField:"StockQuantity",
                                    dataType:"",
                                    caption:"",
                                },
                                {
                                    dataField:"Discount",
                                    dataType:"",
                                    caption:"",
                                },
                                {
                                    dataField:"Supplier",
                                    dataType:"",
                                    caption:"",
                                },
                            ],
                            
                        })
                        
            }
        }
    })
})