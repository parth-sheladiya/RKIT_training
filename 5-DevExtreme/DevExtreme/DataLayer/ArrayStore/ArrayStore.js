$(document).ready(function(){
    // just debugging purpose
    console.log("document ready");


    let products = [
        { id: 1, name: "Product A", price: 30 },
        { id: 2, name: "Product B", price: 50 },
        { id: 3, name: "Product C", price: 70 }
    ];
    
    let arraydataSource = new DevExpress.data.ArrayStore({
        data : products,
        // it is for unique identifieer
        key:"id",
    })

    console.log("array of product is" , arraydataSource);


    // simple grid 
    $("#GridContainer").dxDataGrid({
        dataSource: products,
        columns: ["id", "name", "price"]
    });

    //insert method 
    console.log("new product add ");
    arraydataSource.insert({id: 5, name: "Product D", price: 70})


    // update m,ethod 
    console.log("update method");
    arraydataSource.update(2,{name: "new Product B", price: 500})
})

