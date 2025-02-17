$(document).ready(function(){
    // just debugging purpose
    console.log("document ready");


    let products = [
        { 
            id: 1, 
            name: "Smartphone X", 
            price: 199 
        },
        { 
            id: 2, 
            name: "Laptop Pro", 
            price: 1200 
        },
        { 
            id: 3, 
            name: "Wireless Earbuds", 
            price: 99 
        },
        { 
            id: 4, 
            name: "4K Smart TV", 
            price: 499 
        },
        { 
            id: 5, 
            name: "Gaming Console", 
            price: 350 
        },
        { 
            id: 6, 
            name: "Smartwatch Ultra", 
            price: 249 
        },
        { 
            id: 7, 
            name: "Bluetooth Speaker", 
            price: 129 
        },
        { 
            id: 8, 
            name: "Tablet Plus", 
            price: 349 
        },
        { 
            id: 9, 
            name: "Digital Camera", 
            price: 599 
        },
        { 
            id: 10, 
            name: "Portable Charger", 
            price: 39 
        }
    ];
    
    
    let arraydataSource = new DevExpress.data.ArrayStore({
        data : products,
        // it is for unique identifieer
        key:"id",
        errorHandler: function(error){
            console.log(error.message);
        },
        onInserting:function(values){
            if(!values.id ||!values.name || !values.price){
                throw new Error ("id name and price are required")
             }
             if(values.price<=0){
                 throw new Error ("price is only posotive");
             }
             console.log("inserting data is",values);
        },
        onInserted:function(values){
            console.log("inserted data is ",values);
        },
        onLoading:function(load){
            console.log("onloding data",load);
        },
        onLoaded:function(loadedData){
            console.log("onloaded data is",loadedData)
        },
        onUpdating:function(key,dataValues){
            console.log("key ",key , "new updating data values is ",dataValues)
        },
        onUpdated:function(key,dataValues){
            console.log("key ",key , "new updated data values is ",dataValues)
        },
        onRemoving:function(key){
            console.log("removing item with key ",key);
        },
        onRemoved:function(key){
            console.log("removed data is ",key);
        },
        onPush:function(changes){
            console.log("push changes is" , changes);
        }
    })
    //inserting and inserted options 
    arraydataSource.insert({id: -20,name:"tshirt" , price: 80})
    //console.log("new product add ");
   // arraydataSource.insert({id: 11, name: "soket", price: 70})

    // onloading options
    console.log("onloading data is");
    arraydataSource.load();

    // update m,ethod 
    console.log("update method");
    arraydataSource.update(2,{name: "new update Product ", price: 500})

    // remove 
    console.log("removing and removed");
    arraydataSource.remove(4);

    // push
    console.log("push changes ");
    arraydataSource.push([
        {
            type:"insert",
            data:
                {
                    id:15,
                    name:"mouse",
                    price:4000
                }
        },
        {
            type:"update", 
            key : 7 ,
            data:
                { 
                    name:"wireless speaker",
                    price:139
                }
        },
        {
            type:"remove",
            key:9
        }
    ]);
    console.log("array of product is" , arraydataSource);


    // simple grid 
    $("#GridContainer").dxDataGrid({
        dataSource: products,
        columns: ["id", "name", "price"]
    });


    // method

    // by key
    arraydataSource.byKey(3)
                .done(function(productDataByKey){
                    console.log("by key method ",productDataByKey)
                })
                .fail(function(error){
                    console.log("error while bykey",error)
                });

    // clear
    //console.log("before clear " , arraydataSource);
    //arraydataSource.clear();
    //console.log("after clear " , arraydataSource);

    // create query 
    // var query = arraydataSource.createQuery();
    // query.filter("price",">",500).toArray()
    //             .done(function(dataQuery){
    //                 console.log("price 500 up data is ",dataQuery);
    //             })
    //             .fail(function(error) {
    //                 console.error("Error loading data", error);
    //             });

    // key 
    console.log("key method",arraydataSource.key());

    // keyof(obj)
    console.log(arraydataSource.keyOf({ id: 3, name: "parth" }));

    //load()
    arraydataSource.load()
                .done(function(dataLoad){
                    console.log("loaded data is",dataLoad);
                })
    // totalCount()
    arraydataSource.totalCount()
                    .done(function(productCount){
                        console.log("product count is",productCount);
                    })

   
    
})

