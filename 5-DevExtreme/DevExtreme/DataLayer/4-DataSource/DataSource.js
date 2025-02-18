// apply filter 
// remove filter line no 176

$(document).ready(function () {
    console.log("document is ready");
    // data source
    let products = [
        { id: 1, name: "Smartphone X", price: 199, category: "Electronics", company: "TechCorp" },
        { id: 2, name: "Laptop Pro", price: 1200, category: "Electronics", company: "CompuTech" },
        { id: 3, name: "Wireless Earbuds", price: 99, category: "Accessories", company: "SoundWave" },
        { id: 4, name: "4K Smart TV", price: 499, category: "Electronics", company: "VisionTech" },
        { id: 5, name: "Gaming Console", price: 350, category: "Entertainment", company: "GameX" },
        { id: 6, name: "Smartwatch Ultra", price: 249, category: "Wearables", company: "TimeTech" },
        { id: 7, name: "Bluetooth Speaker", price: 129, category: "Accessories", company: "SoundWave" },
        { id: 8, name: "Tablet Plus", price: 349, category: "Electronics", company: "CompuTech" },
        { id: 9, name: "Digital Camera", price: 599, category: "Electronics", company: "CapturePro" },
        { id: 10, name: "Portable Charger", price: 39, category: "Accessories", company: "PowerUp" },
        { id: 11, name: "Gaming Mouse", price: 89, category: "Accessories", company: "GameX" },
        { id: 12, name: "Smartphone Stand", price: 25, category: "Accessories", company: "TechGear" },
        { id: 13, name: "Laptop Bag", price: 45, category: "Accessories", company: "TechGear" },
        { id: 14, name: "LED Desk Lamp", price: 59, category: "Furniture", company: "BrightLight" },
        { id: 15, name: "Wireless Keyboard", price: 75, category: "Accessories", company: "TechGear" },
        { id: 16, name: "Noise-Canceling Headphones", price: 199, category: "Accessories", company: "SoundWave" },
        { id: 17, name: "Electric Toothbrush", price: 120, category: "Health", company: "CleanTech" },
        { id: 18, name: "Action Camera", price: 199, category: "Electronics", company: "CapturePro" },
        { id: 19, name: "Fitness Tracker", price: 99, category: "Wearables", company: "HealthFit" },
        { id: 20, name: "VR Headset", price: 399, category: "Entertainment", company: "VirtualWorld" },
        { id: 21, name: "Laptop Cooling Pad", price: 40, category: "Accessories", company: "CoolTech" },
        { id: 22, name: "Smart Home Speaker", price: 150, category: "Home", company: "SmartTech" },
        { id: 23, name: "Robot Vacuum", price: 250, category: "Home", company: "HomeTech" },
        { id: 24, name: "Electric Kettle", price: 45, category: "Home", company: "HomeTech" },
        { id: 25, name: "Instant Camera", price: 129, category: "Electronics", company: "CapturePro" },
        { id: 26, name: "Bluetooth Headset", price: 65, category: "Accessories", company: "SoundWave" },
        { id: 27, name: "Fitness Mat", price: 30, category: "Health", company: "HealthFit" },
        { id: 28, name: "Portable Speaker", price: 79, category: "Accessories", company: "SoundWave" },
        { id: 29, name: "Smart Light Bulb", price: 35, category: "Home", company: "SmartTech" },
        { id: 30, name: "Electric Blanket", price: 120, category: "Home", company: "ComfortTech" },
        { id: 31, name: "Wireless Charging Pad", price: 49, category: "Accessories", company: "PowerTech" },
        { id: 32, name: "Smart Mirror", price: 349, category: "Home", company: "HomeTech" },
        { id: 33, name: "4K Projector", price: 799, category: "Electronics", company: "VisionTech" },
        { id: 34, name: "Air Purifier", price: 199, category: "Home", company: "CleanAir" },
        { id: 35, name: "Electric Scooter", price: 799, category: "Electronics", company: "SpeedTech" },
        { id: 36, name: "Drone Camera", price: 499, category: "Electronics", company: "SkyVision" },
        { id: 37, name: "Smart Thermostat", price: 129, category: "Home", company: "ClimateControl" },
        { id: 38, name: "Portable Air Conditioner", price: 299, category: "Home", company: "CoolBreeze" },
        { id: 39, name: "Smart Lock", price: 199, category: "Home", company: "SecureTech" },
        { id: 40, name: "Cordless Vacuum", price: 149, category: "Home", company: "CleanSweep" },
        { id: 41, name: "Electric Skateboard", price: 399, category: "Entertainment", company: "RideTech" },
        { id: 42, name: "Smart Scale", price: 89, category: "Health", company: "FitTech" },
        { id: 43, name: "Fitness Tracker Watch", price: 119, category: "Wearables", company: "FitLife" },
        { id: 44, name: "Smart Mug", price: 59, category: "Home", company: "SmartGear" },
        { id: 45, name: "Electric Grill", price: 179, category: "Home", company: "GrillMaster" },
        { id: 46, name: "Smartphone Cleaner", price: 19, category: "Accessories", company: "TechCare" },
        { id: 47, name: "Home Theater System", price: 399, category: "Entertainment", company: "SoundVision" },
        { id: 48, name: "Smart LED Bulb", price: 25, category: "Home", company: "TechLight" },
        { id: 49, name: "Electric Heater", price: 129, category: "Home", company: "WarmTech" },
        { id: 50, name: "Smart Fridge", price: 899, category: "Home", company: "CoolTech" },
        { id: 51, name: "Smart Speaker", price: 120, category: "Home", company: "VoiceTech" },
        { id: 52, name: "Robot Vacuum Cleaner", price: 249, category: "Home", company: "SmartClean" },
        { id: 53, name: "Smart Home Hub", price: 199, category: "Home", company: "SmartTech" },
        { id: 54, name: "Wireless Router", price: 79, category: "Electronics", company: "NetTech" },
        { id: 55, name: "Smart Coffee Maker", price: 149, category: "Home", company: "BrewTech" },
        { id: 56, name: "Smart Doorbell", price: 99, category: "Home", company: "SecureHome" },
        { id: 57, name: "Portable Blender", price: 49, category: "Home", company: "BlendTech" },
        { id: 58, name: "Electric Fan", price: 79, category: "Home", company: "CoolBreeze" },
        { id: 59, name: "Gaming Chair", price: 250, category: "Furniture", company: "GameGear" },
        { id: 60, name: "Smart Projection Clock", price: 59, category: "Home", company: "TimeTech" }
    ];


    // create data source 

    var myDataSource = new DevExpress.data.DataSource({
        // we use array store data
        // store data
        // type : arr , local , odata , custom store
        store: new DevExpress.data.ArrayStore({
            // data source name
            data: products,
            // it is for uniquely identify
            key: "id",
        }),

        // filter
        // binary filter , complex filter , = <> <= >= startwith endswith contains notcontains 
        // filter: ["price", ">", 120],

        // group section 

        // group : group of specif data 
        // string , object , array , function 
        // for string  group:"company"
        // if you want to multiple field then we use arr group : ['company' , {selector: 'name', desc:true}] ,
        // for object (uncomment)
        // group: { selector: "category", desc: true },
        // function 
        // group: function(i){
        //     return i.price>250 ? "above 250" : "below 250"
        // }
        // sort 
        // string
        // sort:"price",
        // object 
        //sort:{selector:"price",desc:false},
        // arr 
        //    sort:[
        //         {selector:"name",desc:true},
        //         {selector:"category",desc:false},
        //    ],

        // map 
        map: function (dataItem) {
            dataItem.priceWithTax = dataItem.price * 1.10;
            dataItem.name = dataItem.name.toUpperCase();
            // multiple handle
            return dataItem;
            //return dataItem;
        },
        // pageSize it is only working when paginate is true other wise not working
        paginate: true,
        pageSize: 10,

        requireTotalCount: true,
        // collect of changes then it will oush to store 
        pushAggregationTimeout: 500,
        // if new data add then automatic apply changes
        reshapeOnPush: true,
        // on changed
        onChanged: function (e) {
            console.log("Data has changed:", e);
        },
        // on error
        onLoadError: function (error) {
            console.error("Data loading failed:", error.message);
        },
        onLoadingChanged: function (isLoading) {
            if (isLoading) {
                console.log("Data is being loaded...");
            } else {
                console.log("Data loading is complete.");
            }
        }
    })
    // default comment
    // myDataSource.dispose();
    // Initialize the DataGrid
    $("#dataGridContainer").dxDataGrid({
        dataSource: myDataSource,
        columns: [
            { dataField: "id", caption: "Product ID" },
            { dataField: "name", caption: "Product Name" },
            { dataField: "price", caption: "Price" },
            { dataField: "category", caption: "Category" },
            { dataField: "company", caption: "Company" },
            { dataField: "priceWithTax", caption: "Price with Tax" }
        ],
        paging: {
            pageSize: 10
        },
    });

    console.log("Initialized DataSource:", myDataSource);

    myDataSource.load();




    // it is ofr example purpose 
    // apply only second filter due to overwrite issue
    // solve combine filter
    var myFilter = myDataSource.filter();
    // myDataSource.filter(["category", "=", "Accessories"]);
    // myDataSource.filter(["price",">",120])
    myDataSource.filter([["category", "=", "Accessories"], ["price", ">", 120]]);
    console.log("my filter expression ", myFilter);


    // Check if the last page is reached
    console.log("Is Last Page:", myDataSource.isLastPage());

    // Check if the data is loaded
    console.log("Is Data Loaded:", myDataSource.isLoaded());

    // Check if data is currently loading
    console.log("Is Loading:", myDataSource.isLoading());

    // Retrieve all items from data source
    var dataItems = myDataSource.items();
    console.log("Data Items:", dataItems);

    // Get the key property of the data store
    var keyProps = myDataSource.key();
    console.log("Key Property:", keyProps);

    // Enable or disable total count requirement
    console.log("Require Total Count:", myDataSource.requireTotalCount());
    myDataSource.requireTotalCount(true);
    myDataSource.load();

    // Retrieve data store
    var store = myDataSource.store();
    console.log("Data Store:", store);

    // Get total number of records
    var itemCount = myDataSource.totalCount();
    console.log("Total Item Count:", itemCount);
    myDataSource.load();

})