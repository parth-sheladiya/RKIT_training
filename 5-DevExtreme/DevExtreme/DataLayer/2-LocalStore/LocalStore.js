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

    let localStore = new DevExpress.data.LocalStore({
        key:"id", 
        data:products,
        name:"parthstore",
        onLoad:function(){
            console.log("success load");
        },
        immediate: false,
        flushInterval: 15000,
        onInserting:function(values){
            if(!values.id ||!values.name || !values.price){
                throw new Error ("id name and price are required")
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
     console.log("new product add ");

     // apply changes and then show in localstore 
     // just flushInterval immediate purpose 
     localStore.insert({id: 11, name: "parth", price: 70})
 
     // onloading options
     console.log("onloading data is");
     localStore.load();
 
     // update m,ethod 
     console.log("update method");
     localStore.update(2,{name: "new update Product ", price: 500})
 
     // remove 
     console.log("removing and removed");
     localStore.remove(4);
 
     // push
     console.log("push changes ");
     localStore.push([
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
     console.log("array of product is" , localStore);
 
 
     // simple grid 
     $("#GridContainer").dxDataGrid({
         dataSource: products,
         columns: ["id", "name", "price"]
     });
 
 
     // method
 
     // by key
     localStore.byKey(3)
                 .done(function(productDataByKey){
                     console.log("by key method ",productDataByKey)
                 })
                 .fail(function(error){
                     console.log("error while bykey",error)
                 });
 
     // clear comment
     //console.log("before clear " , arraydataSource);
     //arraydataSource.clear();
     //console.log("after clear " , arraydataSource);
 
     // key 
     console.log("key method",localStore.key());
 
     // keyof(obj)
     console.log(localStore.keyOf({ id: 3, name: "parth" }));
 
     //load()
     localStore.load()
                 .done(function(dataLoad){
                     console.log("loaded data is",dataLoad);
                 })
     // totalCount()
     localStore.totalCount()
                     .done(function(productCount){
                         console.log("product count is",productCount);
                     })
 
    localStore.load();
})