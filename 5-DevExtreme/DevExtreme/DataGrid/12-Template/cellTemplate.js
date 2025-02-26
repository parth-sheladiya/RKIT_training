$(document).ready(function(){
    console.log("doc is ready");

    const productData = new DevExpress.data.CustomStore({
        key:"id",
        loadMode:"row",
        load:()=>{
            return $.ajax({
                url:"https://dummyjson.com/products",
                dataType:"json",
                method:"GET"
            }).then((res)=>{
                return res.products;
            })
        }
    })

    $("#cellContainer").dxDataGrid({
        dataSource:productData,
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        columnAutoWidth:true,
        onCellPrepared(options){
            if(options.column.dataField === "rating"){
                // if rating > 4 then color is green
                if(options.value >4){
                    $(options.cellElement).css("color", "green");
                   
                   
                }
                else if (options.value >=2.74 && options.value <4){
                    $(options.cellElement).css("color","orange")
                    
                }
                else if(options.value<2.74){
                    $(options.cellElement).css("color","red")
                }
                
               
            }
        },
        columns:[
            {
                dataField:"id",
                dataType:"string",
                caption:"Product ID"
            },
            {
                dataField:"title",
                dataType:"string",
                caption:"Product Title"
            },
            {
                dataField:"category",
                dataType:"string",
                caption:"Product Category"
            },
            {
                dataField:"rating",
                dataType:"number",
                caption:"Product rating"
            },
            {
                dataField:"price",
                dataType:"number",
                caption:"Product price"
            },
        ],
        paging:{
            pageSize:5
        }
    })
})