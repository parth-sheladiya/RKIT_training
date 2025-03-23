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
            //autoExpandAll:true,

            //Specifies a custom template for detail sections.
            template(container,options){
                const currentProductData = options.data;
                $("<div>")
                        .dxDataGrid({
                            dataSource:currentProductData.ProductDetails,
                            // dataSource:[
                            //     {
                            //         Rating:currentProductData.Rating,
                            //         Price:currentProductData.Price,
                            //         Date:currentProductData.Date,
                            //         StockQuantity:currentProductData.StockQuantity,
                            //         Discount:currentProductData.Discount,
                            //         Supplier:currentProductData.Supplier
                            //     }
                            // ],
                            
                            columnAutoWidth:true,
                            showBorders:true,
                            columns:[
                                {
                                    dataField:"Rating",
                                    dataType:"number",
                                    caption:"Product Rating",
                                    alignment:"center"
                                },
                                {
                                    dataField:"Price",
                                    dataType:"number",
                                    caption:"Product Price",
                                    alignment:"center"
                                },
                                {
                                    dataField:"Date",
                                    dataType:"date",
                                    caption:"Manufacture Date",
                                    alignment:"center"
                                },

                                {
                                    dataField:"StockQuantity",
                                    dataType:"number",
                                    caption:"Product Quantity",
                                    alignment:"center"
                                },
                                {
                                    dataField:"Discount",
                                    dataType:"number",
                                    caption:"product Discount",
                                    alignment:"center"
                                },
                                {
                                    dataField:"Company",
                                    dataType:"string",
                                    caption:"Product Company",
                                    alignment:"center"
                                },
                            ],
                            paging:{
                                pageSize:2
                            },
                            headerFilter:{
                                visible:true
                            },
                            filterRow:{
                                visible:true
                            },
                            searchPanel:{
                                visible:true
                            },
                            
                            
                        }).appendTo(container)
                        
            }
        }
    })
})