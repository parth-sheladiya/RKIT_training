$(document).ready(function(){
    // debug purpose
    console.log("docs is ready");

    // ajax request 
    const storeProductData = new DevExpress.data.CustomStore({
        key:"id",
        loadMode:"processed",
        load(){
            return $.ajax({
                url:"https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi",
                dataType:"json",
                method:"GET"
            })
            // .then((result)=>{
            //     return {                               
            //         data:result.productapi,
            //         totalCount:result.total,
            //     };
            // })
            // .fail(()=>{
            //     throw new Error("error generate while load products")
            // })
        }
    });

    $("#dataGrid").dxDataGrid({
        dataSource:storeProductData,
        
        columns:[
            {
                dataField:"id",
                // sort not properly working
                //dataType:"number"
            },
            {
                dataField:"name",
                dataType:"string"
            },
            {
                dataField:"price",
                dataType:"number"
            }
        ]
    })


   
})