$(document).ready(function(){
    console.log("doc is ready");

    const cartsData = new DevExpress.data.CustomStore({
        key:"id",
        loadMode:"row",
        load:()=>{
            return $.ajax({
                url:"https://dummyjson.com/carts",
                method:"GET",
                dataType: "json"
            }).then((result)=>{
                return result.carts
            })
        }
    })
    $("#ColumnTemplate").dxDataGrid({
        dataSource: cartsData,
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        columnAutoWidth:true,
        columns:[
            {
                dataField:"id",
                caption:"cart ID",
                dataType:"string",
                alignment:"center"
            },
            {
                dataField:"userId",
                caption:"user ID",
                dataType:"string",
                alignment:"center",
            },
            {
                dataField: "total",
                caption: "Total",
                format: "currency",
                alignment:"center" 
            },
            {
                dataField: "discountedTotal",
                caption: "Discounted Total",
                format: "currency",
                alignment:"center"
            },
            {
                dataField:"products",
                caption:"Products",

                cellTemplate: function(container , options){
                    console.log("container",container);
                    console.log("options",options);
                    const product = options.value;
                    let productOtherData = '';
                    product.forEach(product =>{
                        productOtherData+=`
                        <div style="margin-bottom: 10px;">
                            <img src="${product.thumbnail}" alt="${product.title}" width="80" height="80" style="margin-right: 10px;">
     
                        </div>
                        `
                    })
                    container.append(productOtherData);
                }
            },
            {
                dataField:"total",
                caption:"Total Products Price",
                dataType:"number"
            },
            {
                dataField:"discountedTotal",
                caption:"all Product Discount",
                dataType:"number"
            },
            {
                dataField:"totalProducts",
                dataType:"number",
                caption:"Total Products"
            },
            {
                dataField:"totalQuantity",
                dataType:"number",
                caption:"Total Products Quantity"
            }
            
        ]
    })
})