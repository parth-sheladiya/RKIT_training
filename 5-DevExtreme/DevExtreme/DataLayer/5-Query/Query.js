$(document).ready(function () {
    // starting phase
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

    // avarage 
    DevExpress.data.query(products)
        .avg("price")
        .done(function (priceAvg) {
            console.log("Avarage price is ", priceAvg)
        })

    // count

    DevExpress.data
        .query(products)
        .count()
        .done(function (totalProduct) {
            console.log("total product  is ", totalProduct)
        })

    // enumeratew()
    DevExpress.data
        .query(products)
        .enumerate()
        .done(function (result) {
            console.log(result);
        });

    // filter 
    var priceFilter = DevExpress.data
        .query(products)
        .filter(["price", ">", 500])
        .toArray();
    console.log("500 above price is", priceFilter)

    var categoryFilter = DevExpress.data
        .query(products)
        .filter(function (item) {
            return item.category === "Entertainment"
        })
        .toArray();
    console.log("category filter data is ", categoryFilter)

    // groupby
    var groupByCategory = DevExpress.data
        .query(products)
        .groupBy("category")
        .toArray();
    console.log("category wise product is ", groupByCategory);

    // max 
    DevExpress.data
        .query(products)
        .max("price")
        .done(function (res) {
            console.log("max price is ", res)
        })
    // min 
    DevExpress.data
        .query(products)
        .min("price")
        .done(function (res) {
            console.log("min price is ", res)
        })

    // select 
    var selectColumn = DevExpress.data
        .query(products)
        //( skip, take)
        .select("id", "name")
        .toArray()
    console.log("selected col is ", selectColumn)

    // slice product

    var sliceProduct = DevExpress.data
        .query(products)
        .slice(2, 4)
        .toArray()
    console.log("slice product 2 to 4", sliceProduct)

    // sort by  
    // add desc bool
    var sortByPrice = DevExpress.data
        .query(products)
        .sortBy("price")
        .toArray()
    console.log("sortby price", sortByPrice)

    // sum 
    DevExpress.data
        .query(products)
        .sum("price")
        .done(function (res) {
            console.log("sum of total price ", res)
        })

    // then by 

    var productData = DevExpress.data
        .query(products)
        .sortBy("category")
        .thenBy("price", true)
        .toArray()
    console.log(" using thenby :  product data", productData)

})