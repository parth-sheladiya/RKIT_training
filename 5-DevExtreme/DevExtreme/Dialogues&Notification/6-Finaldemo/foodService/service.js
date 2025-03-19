export   function addFoodCategory() {
    let categoryPopup = $("#PopUpContainer").dxPopup({
        width: 400,
        height: 250,
        visible: false,
        showCloseButton: true,
        title: "Add Category",
        contentTemplate: function (contentElement) {
            contentElement.append('<div id="categoryForm">');

            $("#categoryForm").dxForm({
                formData: { categoryName: "" },
                items: [
                    {
                        dataField: "categoryName",
                        label: { text: "Category Name" },
                        validationRules: [{ type: "required", message: "Category Name is required" }]
                    },
                    {
                        itemType: "button",
                        buttonOptions: {
                            text: "Add Category",
                            onClick: function () {
                                let formInstance = $("#categoryForm").dxForm("instance");
                                let formData = formInstance.option("formData");

                                if (formInstance.validate().isValid) {
                                    let storedData = JSON.parse(localStorage.getItem("foodData")) || [];

                                    let newCategory = {
                                        id: Date.now(), 
                                        name: formData.categoryName,
                                        items: []  
                                    };

                                    storedData.push(newCategory);
                                    localStorage.setItem("foodData", JSON.stringify(storedData));

                                    categoryPopup.hide();
                                    DevExpress.ui.notify("Category added successfully!", "success", 2000);

                                    // Updated category show karne ke liye
                                    showFoodItems();
                                }
                            }
                        }
                    }
                ]
            });
        }
    }).dxPopup("instance");

    categoryPopup.show();
}

export function showFoodItems() {
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
            let storedData = JSON.parse(localStorage.getItem("foodData")) || [];
            let categoryList = storedData.map(category => category.name);

            $("#form").dxForm({
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
                                var formInstance = $("#form").dxForm("instance");
                                var formData = formInstance.option("formData");

                                // Validate form
                                if (formInstance.validate().isValid) {
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
            });
        }
    }).dxPopup("instance");

    foodpopup.show();
}



