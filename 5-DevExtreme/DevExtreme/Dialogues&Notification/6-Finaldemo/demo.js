// $(document).ready(function(){
//     console.log("doc is ready");

//     // menu 
//     $("#MenuContainer").dxMenu({
//         items: [
//             {
//                 text: "Add Food",
//             },
//             {
//                 text: "Show Food Item",
//             },
           
//         ],
//         onItemClick: function(e) {
//             if (e.itemData.text === "Add Food") {
//                 openAddFoodPopup();
//             }
//             else if (e.itemData.text === "Show Food Item") {
//                 showFoodItems();
//             }
//         }
//     });

//     // Function to open the "Add Food" popup and handle the form
//     function openAddFoodPopup() {
//         let foodpopup = $("#PopUpContainer").dxPopup({
//             width: 400,
//             height: 300,
//             visible: false,
//             showCloseButton: true,
//             fullScreen: false,
//             contentTemplate: function (contentElement) {
//                 contentElement.append(
//                     '<div class="form-container">' +
//                     '<div id="form"></div>' +
//                     '</div>'
//                 )
            

//                 // Initialize dxForm with the fields for name and price
//                 $("#form").dxForm({
//                     formData: {
//                         name: "",
//                         price: "",
//                     },
//                     items: [
//                         {
//                             dataField: "name",
//                             validationRules: [
//                                 {
//                                     type: "required",
//                                     message: "Food name is required",
//                                 }
//                             ]
//                         },
//                         {
//                             dataField: "price",
//                             validationRules: [
//                                 {
//                                     type: "required",
//                                     message: "Food price is required",
//                                 }
//                             ]
//                         },
//                         {
//                             itemType: "button",
//                             buttonOptions: {
//                                 text: "Add",
//                                 onClick: function() {
//                                     var formInstance = $("#form").dxForm("instance");
//                                     var formData = formInstance.option("formData");

//                                     // Validate form
//                                     if (formInstance.validate().isValid) {
//                                         // Save data to localStorage
//                                         var foodData = {
//                                             name: formData.name,
//                                             price: formData.price
//                                         };

//                                         // Save food data in localStorage
//                                         let storedData = localStorage.getItem("foodItems");
//                                         if (storedData) {
//                                             storedData = JSON.parse(storedData);
//                                         } else {
//                                             storedData = [];
//                                         }
//                                         storedData.push(foodData);
//                                         localStorage.setItem("foodItems", JSON.stringify(storedData));

//                                         // Close popup after adding food
//                                         foodpopup.hide();  // Use the correct method for hiding the popup
//                                         toast.option("message", "food item add success fully");
//                                         toast.show();
//                                     }
                                   
//                                 }
//                             }
//                         },
                        
//                     ]
//                 });
//             },
//             toolbarItems:[
//                 {
//                     location:"before",
//                     widget:"dxButton",
//                     options:{
//                         text:"Clear Data",
//                         icon:"close",
//                         onClick: function() {
//                             localStorage.removeItem("foodItems")
//                             DevExpress.ui.notify("clear storage","success",2000)
//                         }
//                     }
//                 },
//             ]
//         }).dxPopup("instance");

//         // Show the popup
//         foodpopup.show();
//     }

//     // Function to show food items stored in localStorage
//     function showFoodItems() {
//         // let storedData = localStorage.getItem("foodItems");
//         // if (storedData) {
//         //     storedData = JSON.parse(storedData);
//         //     let foodList = "Stored Food Items:\n";
//         //     storedData.forEach((item, index) => {
//         //         foodList += `${index + 1}. ${item.name} - $${item.price}\n`;
//         //     });
//         //     alert(foodList);
//         // } else {
//         //     alert("No food items stored yet.");
//         // }

//         let storedData = localStorage.getItem("foodItems");
//         if (storedData) {
//             storedData = JSON.parse(storedData);

//             // Format food items into a tree structure for dxTreeView
//             let foodItems = storedData.map(function (item, index) {
//                 return {
//                     id: index + 1,
//                     text: `${item.name} - $${item.price}`,
//                     expanded: false,
//                 };
//             });

//             // Initialize dxTreeView to display food items
//             $("#PopUpContainer").dxPopup({
//                 width: 400,
//                 height: 300,
//                 visible: false,
//                 showCloseButton: true,
//                 fullScreen: false,
//                 contentTemplate: function (contentElement) {
//                     contentElement.append('<div id="treeview"></div>');

//                     // Initialize dxTreeView with food items
//                     $("#treeview").dxTreeView({
//                         dataSource: foodData,
//                         displayExpr: "name", // Specify the field to display
//                         idField: "id", // Specify the field for the unique ID
//                         parentIdField: "parentId", // For nested items
//                         showCheckBoxesMode: "none", // Remove checkboxes if not needed
//                     });
//                 }
//             }).dxPopup("instance").show();
//         } else {
//             DevExpress.ui.notify("No food items stored yet.", "warning", 2000);
//         }
//     }

//     const toast = $("#ToastContainer").dxToast({
//         //use in mobile
//         //closeOnSwipe: true,
//         displayTime: 5000,
//         closeOnOutsideClick:true,
//         type: "success", //  'custom' | 'error' | 'info' | 'success' | 'warning'
//         message: "", 
//         position: { my: "top center" },
        
//     }).dxToast("instance"); 
// });


$(document).ready(function () {
    console.log("doc is ready");


    
        localStorage.setItem("foodData", JSON.stringify(foodData));
    

    // Menu 
    $("#MenuContainer").dxMenu({
        items: [
            { text: "Add Food" },
            { text: "Show Food Item" },
        ],
        onItemClick: function (e) {
            if (e.itemData.text === "Add Food") {
                openAddFoodPopup();
            } else if (e.itemData.text === "Show Food Item") {
                showFoodItems();
            }
        }
    });

    // Function to open the "Add Food" popup and handle the form
    function openAddFoodPopup() {
        let foodpopup = $("#PopUpContainer").dxPopup({
            width: 400,
            height: 300,
            visible: false,
            showCloseButton: true,
            fullScreen: false,
            contentTemplate: function (contentElement) {
                contentElement.append('<div class="form-container"><div id="form"></div></div>');

                // Initialize dxForm with the fields for name and price
                $("#form").dxForm({
                    formData: { name: "", price: "" },
                    items: [
                        {
                            dataField: "name",
                            validationRules: [
                                { type: "required", message: "Food name is required" },
                            ],
                        },
                        {
                            dataField: "price",
                            validationRules: [
                                { type: "required", message: "Food price is required" },
                            ],
                        },
                        {
                            itemType: "button",
                            buttonOptions: {
                                text: "Add",
                                onClick: function () {
                                    var formInstance = $("#form").dxForm("instance");
                                    var formData = formInstance.option("formData");

                                    // Validate form
                                    if (formInstance.validate().isValid) {
                                        // Save new food item to localStorage
                                        let newFoodData = {
                                            name: formData.name,
                                            price: formData.price,
                                        };

                                        // Fetch current data from localStorage
                                        let storedData = JSON.parse(localStorage.getItem("foodData"));
                                        // Add the new item to the existing data
                                        storedData.push(newFoodData);

                                        // Store the updated data back to localStorage
                                        localStorage.setItem("foodData", JSON.stringify(storedData));

                                        // Close popup after adding food
                                        foodpopup.hide();
                                        toast.option("message", "Food item added successfully!");
                                        toast.show();
                                    }
                                }
                            }
                        },
                    ]
                });
            },
            toolbarItems: [
                {
                    location: "before",
                    widget: "dxButton",
                    options: {
                        text: "Clear Data",
                        icon: "close",
                        onClick: function () {
                            localStorage.removeItem("foodData");
                            DevExpress.ui.notify("Storage cleared", "success", 2000);
                        }
                    }
                },
            ]
        }).dxPopup("instance");

        // Show the popup
        foodpopup.show();
    }

    // Function to show food items stored in localStorage
    function showFoodItems() {
        let storedData = JSON.parse(localStorage.getItem("foodData"));
        if (storedData) {
            // Format food items into a tree structure for dxTreeView
            let foodItems = storedData.map(function (item, index) {
                return {
                    id: item.id,
                    text: `${item.name} - $${item.price}`,
                    expanded: false,
                    items: item.items ? item.items.map(function (subItem) {
                        return {
                            id: subItem.id,
                            text: `${subItem.name} - $${subItem.price}`,
                            disabled: subItem.disabled || false,
                            icon: subItem.icon,
                        };
                    }) : []
                };
            });

            // Initialize dxTreeView to display all food items
            $("#PopUpContainer").dxPopup({
                width: 400,
                height: 300,
                visible: false,
                showCloseButton: true,
                fullScreen: false,
                contentTemplate: function (contentElement) {
                    contentElement.append('<div id="treeview"></div>');

                    // Initialize dxTreeView with the combined food items
                    $("#treeview").dxTreeView({
                        dataSource: foodItems,
                        displayExpr: "text", // Specify the field to display
                        idField: "id", // Specify the field for the unique ID
                        parentIdField: "parentId", // For nested items
                        showCheckBoxesMode: "none", // Remove checkboxes if not needed
                    });
                }
            }).dxPopup("instance").show();
        } else {
            DevExpress.ui.notify("No food items stored yet.", "warning", 2000);
        }
    }

    const toast = $("#ToastContainer").dxToast({
        displayTime: 5000,
        closeOnOutsideClick: true,
        type: "success", // 'custom' | 'error' | 'info' | 'success' | 'warning'
        message: "",
        position: { my: "top center" },
    }).dxToast("instance");
});
