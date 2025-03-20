export   function addFoodCategory() {

    // create popup and include form 
    let categoryPopup = $("#PopUpContainer").dxPopup({
        // width
        width: 400,
        // height
        height: 250,
        // btn
        showCloseButton: true,
        // out click
        closeOnOutsideClick:true,

        title: "Add Category",
        // template for add category
        contentTemplate: function (contentElement) {
            contentElement.append('<div id="categoryForm">');
            // add form
           let formInstance =  $("#categoryForm").dxForm({
            // form data
                formData: { categoryName: "" },
                items: [
                    {
                        dataField: "categoryName",
                        label: { 
                            text: "Category Name" 
                        },
                        validationRules: [
                            { 
                                type: "required", 
                                message: "Category Name is required" 
                            }
                        ]
                    },
                    {
                        itemType: "button",
                        buttonOptions: {
                            text: "Add Category",
                            onClick: function () {
                                // form instance
                                let formData = formInstance.option("formData");
                                // log purpose
                                console.log("form inst", formInstance)
                                // validate 
                                if (formInstance.validate().isValid) {
                                    let storedData = JSON.parse(localStorage.getItem("foodData"));
                                    // category
                                    let newCategory = {
                                        
                                        name: formData.categoryName,
                                        items: []  
                                    };
                                    // store
                                    storedData.push(newCategory);
                                    localStorage.setItem("foodData", JSON.stringify(storedData));

                                    categoryPopup.hide();
                                    DevExpress.ui.notify("Category added successfully!", "success", 2000);

                                    // Updated category show karne ke liye
                                    showFoodItems();
                                }else{

                                    DevExpress.ui.notify("please fill all details", "error", 2000);
                    
                                }
                            }
                        }
                    }
                ]
            }).dxForm("instance");
            
        }
    }).dxPopup("instance");

    categoryPopup.show();
}

export function showFoodItems() {
    let storedData = JSON.parse(localStorage.getItem("foodData"));
    if (storedData) {
        console.log("store data",storedData)
        // Format food items into a tree structure for dxTreeView
        let foodItems = storedData.map(function (item, index) {
            return {
                // id: item.id,
                text: `${item.name}`,
                expanded: false,
                items: item.items ? item.items.map(function (subItem) {
                    return {
                        id: subItem.id,
                        text: `${subItem.name} - $${subItem.price}`,
                    };
                }) : []
            };
        });

        // Initialize dxTreeView to display all food items
     let treeviewInPopupInst =   $("#PopUpContainer").dxPopup({
            width: 400,
            height: 300,
            visible: false,
            showCloseButton: true,
            fullScreen: false,
            title: "All items",
            contentTemplate: function (contentElement) {
                contentElement.append('<div id="treeview"></div>');

                // Initialize dxTreeView with the combined food items
                $("#treeview").dxTreeView({
                    dataSource: foodItems,
                    displayExpr: "text", // Specify the field to display
                    idField: "id", // Specify the field for the unique ID
                    parentIdField: "parentId", // For nested items
                    showCheckBoxesMode: "selectAll", // Remove checkboxes if not needed
                });
            }
        }).dxPopup("instance")
        treeviewInPopupInst.show();
    } else {
        DevExpress.ui.notify("No food items stored yet.", "warning", 2000);
    }
}


export  function openAddFoodPopup() {
    let foodpopup = $("#PopUpContainer").dxPopup({
        width: 400,
        height: 350,
        visible: false,
        showCloseButton: true,
        fullScreen: false,
        contentTemplate: function (contentElement) {
            contentElement.append('<div class="form-container"><div id="form"></div></div>');

            // Fetch existing categories from localStorage
            let storedData = JSON.parse(localStorage.getItem("foodData"));
            let categoryList = storedData.map(category => category.name);

          let foodFormInst=  $("#form").dxForm({
                formData: { category: "", name: "", price: "" },
                items: [
                    {
                        dataField: "category",
                        editorType: "dxSelectBox",
                        editorOptions: {
                            dataSource: categoryList,
                            placeholder: "Select Category",
                            searchEnabled: true
                        },
                        validationRules: [
                            { type: "required", message: "Category is required" },
                        ],
                    },
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
                               
                                var formData = foodFormInst.option("formData");

                                // Validate form
                                if (foodFormInst.validate().isValid) {
                                    let storedData = JSON.parse(localStorage.getItem("foodData")) || [];

                                    let categoryObj = storedData.find(c => c.name === formData.category);

                                    if (categoryObj) {
                                        // Add new food item to selected category
                                        categoryObj.items.push({ name: formData.name, price: formData.price });
                                    } else {
                                        DevExpress.ui.notify("Selected category does not exist!", "error", 2000);
                                        return;
                                    }

                                    // Store updated data back to localStorage
                                    localStorage.setItem("foodData", JSON.stringify(storedData));

                                    // Close popup and show success message
                                    foodpopup.hide();
                                    DevExpress.ui.notify("Food item added successfully!", "success", 2000);
                                    showFoodItems();
                                }
                            }
                        }
                    },
                ]
            }).dxForm("instance");
        }
    }).dxPopup("instance");

    foodpopup.show();
}



