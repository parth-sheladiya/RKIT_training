// function openAddFoodPopup() {
//     let foodpopup = $("#PopUpContainer").dxPopup({
//         width: 400,
//         height: 350,
//         visible: false,
//         showCloseButton: true,
//         fullScreen: false,
//         contentTemplate: function (contentElement) {
//             contentElement.append('<div class="form-container"><div id="form"></div></div>');

//             // Fetch existing categories from localStorage
//             let storedData = JSON.parse(localStorage.getItem("foodData")) || [];
//             let categoryList = storedData.map(category => category.name);

//             $("#form").dxForm({
//                 formData: { category: "", name: "", price: "" },
//                 items: [
//                     {
//                         dataField: "category",
//                         editorType: "dxSelectBox",
//                         editorOptions: {
//                             dataSource: categoryList,
//                             placeholder: "Select Category",
//                             searchEnabled: true
//                         },
//                         validationRules: [
//                             { type: "required", message: "Category is required" },
//                         ],
//                     },
//                     {
//                         dataField: "name",
//                         validationRules: [
//                             { type: "required", message: "Food name is required" },
//                         ],
//                     },
//                     {
//                         dataField: "price",
//                         validationRules: [
//                             { type: "required", message: "Food price is required" },
//                         ],
//                     },
//                     {
//                         itemType: "button",
//                         buttonOptions: {
//                             text: "Add",
//                             onClick: function () {
//                                 var formInstance = $("#form").dxForm("instance");
//                                 var formData = formInstance.option("formData");

//                                 // Validate form
//                                 if (formInstance.validate().isValid) {
//                                     let storedData = JSON.parse(localStorage.getItem("foodData")) || [];

//                                     let categoryObj = storedData.find(c => c.name === formData.category);

//                                     if (categoryObj) {
//                                         // Add new food item to selected category
//                                         categoryObj.items.push({ name: formData.name, price: formData.price });
//                                     } else {
//                                         DevExpress.ui.notify("Selected category does not exist!", "error", 2000);
//                                         return;
//                                     }

//                                     // Store updated data back to localStorage
//                                     localStorage.setItem("foodData", JSON.stringify(storedData));

//                                     // Close popup and show success message
//                                     foodpopup.hide();
//                                     DevExpress.ui.notify("Food item added successfully!", "success", 2000);
//                                     showFoodItems();
//                                 }
//                             }
//                         }
//                     },
//                 ]
//             });
//         }
//     }).dxPopup("instance");

//     foodpopup.show();
// }





// $(document).ready(function () {
//     console.log("doc is ready");

//     if (!localStorage.getItem("foodData")) {
//         localStorage.setItem("foodData", JSON.stringify([]));
//     }

//     // Menu 
//     $("#MenuContainer").dxMenu({
//         items: [
//             { text: "Add Category" }, 
//             { text: "Add Food" },
//             { text: "Show Food Item" },
//         ],
//         onItemClick: function (e) {
//             if (e.itemData.text === "Add Category") {
//                 openAddCategoryPopup();
//             } else if (e.itemData.text === "Add Food") {
//                 openAddFoodPopup();
//             } else if (e.itemData.text === "Show Food Item") {
//                 showFoodItems();
//             }
//         }
//     });

    
//     function openAddCategoryPopup() {
//         let categoryPopup = $("#PopUpContainer").dxPopup({
//             width: 400,
//             height: 250,
//             visible: false,
//             showCloseButton: true,
//             contentTemplate: function (contentElement) {
//                 contentElement.append('<div class="form-container"><div id="categoryForm"></div></div>');

//                 $("#categoryForm").dxForm({
//                     formData: { categoryName: "" },
//                     items: [
//                         {
//                             dataField: "categoryName",
//                             validationRules: [{ type: "required", message: "Category Name is required" }]
//                         },
//                         {
//                             itemType: "button",
//                             buttonOptions: {
//                                 text: "Add Category",
//                                 onClick: function () {
//                                     let formInstance = $("#categoryForm").dxForm("instance");
//                                     let formData = formInstance.option("formData");

//                                     if (formInstance.validate().isValid) {
//                                         let storedData = JSON.parse(localStorage.getItem("foodData")) || [];

//                                         let newCategory = {
//                                             id: Date.now(), 
//                                             name: formData.categoryName,
//                                             items: [] 
//                                         };

//                                         storedData.push(newCategory);
//                                         localStorage.setItem("foodData", JSON.stringify(storedData));

//                                         categoryPopup.hide();
//                                         DevExpress.ui.notify("Category added successfully!", "success", 2000);
//                                     }
//                                 }
//                             }
//                         }
//                     ]
//                 });
//             }
//         }).dxPopup("instance");

//         categoryPopup.show();
//     }

    
//     function openAddFoodPopup() {
//         let storedData = JSON.parse(localStorage.getItem("foodData")) || [];

//         let foodpopup = $("#PopUpContainer").dxPopup({
//             width: 400,
//             height: 350,
//             visible: false,
//             showCloseButton: true,
//             contentTemplate: function (contentElement) {
//                 contentElement.append('<div class="form-container"><div id="form"></div></div>');

//                 $("#form").dxForm({
//                     formData: { category: "", name: "", price: "" },
//                     items: [
//                         {
//                             dataField: "category",
//                             editorType: "dxSelectBox",
//                             editorOptions: {
//                                 dataSource: storedData.map(category => ({
//                                     id: category.id,
//                                     name: category.name
//                                 })),
//                                 displayExpr: "name",
//                                 valueExpr: "id",
//                                 placeholder: "Select Category",
//                                 searchEnabled: true
//                             },
//                             validationRules: [{ type: "required", message: "Category is required" }]
//                         },
//                         {
//                             dataField: "name",
//                             validationRules: [{ type: "required", message: "Food name is required" }]
//                         },
//                         {
//                             dataField: "price",
//                             editorType: "dxNumberBox",
//                             editorOptions: { min: 1 },
//                             validationRules: [{ type: "required", message: "Price is required" }]
//                         },
//                         {
//                             itemType: "button",
//                             buttonOptions: {
//                                 text: "Add",
//                                 onClick: function () {
//                                     let formInstance = $("#form").dxForm("instance");
//                                     let formData = formInstance.option("formData");

//                                     if (formInstance.validate().isValid) {
//                                         let storedData = JSON.parse(localStorage.getItem("foodData")) || [];
//                                         let categoryIndex = storedData.findIndex(c => c.id === formData.category);

//                                         if (categoryIndex !== -1) {
//                                             let newFoodItem = {
//                                                 id: Date.now(),
//                                                 name: formData.name,
//                                                 price: formData.price
//                                             };

//                                             storedData[categoryIndex].items.push(newFoodItem);
//                                             localStorage.setItem("foodData", JSON.stringify(storedData));

//                                             foodpopup.hide();
//                                             DevExpress.ui.notify("Food item added successfully!", "success", 2000);
//                                         }
//                                     }
//                                 }
//                             }
//                         },
//                         {
//                             itemType: "button",
//                             buttonOptions: {
//                                 text: "Clear",
//                                 onClick: function () {
//                                     $("#form").dxForm("instance").resetValues();
//                                 }
//                             }
//                         }
//                     ]
//                 });
//             }
//         }).dxPopup("instance");

//         foodpopup.show();
//     }

//     function showFoodItems() {
//         let storedData = JSON.parse(localStorage.getItem("foodData")) || [];
        
//         if (storedData.length > 0) {
//             let foodItems = storedData.map(category => ({
//                 id: category.id,
//                 text: category.name,
//                 expanded: false,
//                 items: category.items.map(item => ({
//                     id: item.id,
//                     text: `${item.name} - ₹${item.price}`
//                 }))
//             }));
    
//             // Purane popup ko hatao agar pehle se exist karta hai
//             if ($("#PopUpContainer").data("dxPopup")) {
//                 $("#PopUpContainer").dxPopup("dispose");
//             }
    
//             let popupInstance = $("#PopUpContainer").dxPopup({
//                 width: 400,
//                 height: 400,
//                 visible: false,
//                 showCloseButton: true,
//                 dragEnabled: true,
//                 title: "Food Items",
//                 contentTemplate: function (contentElement) {
//                     if (foodItems.length === 0) {
//                         contentElement.append("<p style='text-align:center; font-weight:bold;'>No Food Items Found</p>");
//                     } else {
//                         contentElement.append('<div id="treeview"></div>');
//                         $("#treeview").dxTreeView({
//                             dataSource: foodItems,
//                             displayExpr: "text",
//                             idField: "id",
//                             showCheckBoxesMode: "none",
//                             expandNodesRecursive: false,
//                             searchEnabled: true,
//                             width: "100%",
//                             height: 300,
//                             scrollDirection: "vertical"
//                         });
//                     }
//                 }
//             }).dxPopup("instance");
    
//             popupInstance.show();
//         } else {
//             DevExpress.ui.notify("No food items stored yet.", "warning", 2000);
//         }
//     }
    
    
// });
