// over view admin dashboard 
// admin can handle user data 
// admin handle product data 
// admin can handle order data 
$(document).ready(function () {
    console.log("admin dashboard is ready");

    // cvustom store for profile 
    var customStore = new DevExpress.data.CustomStore({
        key: "r01F01",

        // Load data from the server
        load: function (loadOptions) {
            // log
            console.log("load options", loadOptions)
            // token
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/GetProfile",
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                success: function (res) {
                    console.log("Profile data:", res.data);
                    // global handle
                    window.existingProfileData = res.data;
                    return res.data;
                },
                error: function (err) {
                    console.log("Error loading data:", err);
                    DevExpress.ui.notify("Error loading data while fetching admin profile", "error", 3000);
                }
            });
        },

        // Update data on the server
        update: function (key, values) {
            console.log("valuesm", values)
            // asp .net core by default validation on 
            // please validatation false in program.cs 
            // new learning in this topic
            // pass data from getprofile to updateprofile
            let ExistingProfile = window.existingProfileData;
            let token = localStorage.getItem("Token");
            let objData = {
                r01F01: key,
                r01F02: values.r01F02 ?? ExistingProfile.r01F02,
                r01F03: values.r01F03 ?? ExistingProfile.r01F03,
                r01F04: values.r01F04 ?? ExistingProfile.r01F04,
                r01F05: values.r01F05 ?? ExistingProfile.r01F05,
                r01F06: values.r01F06 ?? ExistingProfile.r01F06,
                r01F07: values.r01F07 ?? ExistingProfile.r01F07
            };
            console.log("Sending data:", objData);
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/updateUser",
                method: "PUT",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",
                data: JSON.stringify(objData),
                success: function (res) {
                    console.log("updated admin profile", res.data)
                    DevExpress.ui.notify("User profile updated successfully", "success", 3000);
                },
                error: function (err) {
                    console.log("Error updating data:", err);
                    DevExpress.ui.notify("Error updating data", "error", 3000);
                }
            });
        }
    });
    // Initialize the DataGrid 
    $("#ProfileContainer").dxDataGrid({
        dataSource: customStore,
        showBorders: true,
        wordWrapEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        allowColumnResizing: true,
        allowColumnReordering: true,
        columns: [
            {
                dataField: "r01F01",
                dataType: "number",
                caption: "User ID",
                allowEditing: false
            },
            {
                dataField: "r01F02",
                dataType: "string",
                caption: "User Name",
            },
            {
                dataField: "r01F03",
                dataType: "string",
                caption: "User Email",
            },
            {
                dataField: "r01F04",
                dataType: "string",
                caption: "Password",
                validationRules: [
                    {
                        type: "pattern",
                        pattern: /^\d{6}$/,
                        message: "Password must be exactly 6 digits"
                    }
                ],
            },
            {
                dataField: "r01F05",
                dataType: "string",
                caption: "Phone number",
                validationRules: [
                    {
                        type: "pattern",
                        pattern: /^\d{10}$/,
                        message: "Phone number must be exactly 10 digits"
                    }
                ],
            },
            {
                dataField: "r01F06",
                dataType: "string",
                caption: "Address",
            },
            {
                dataField: "r01F07",
                dataType: "string",
                caption: "Role",
                allowEditing: false,
                cellTemplate: function (container, options) {
                    const roleEnum = {
                        0: "Admin",
                        1: "User"
                    };
                    const roleValue = options.value;
                    const roleText = roleEnum[roleValue] || "Unknown";
                    console.log("role text ", roleText)
                    $("<div>")
                        .text(roleText)
                        .appendTo(container);
                }
            },
            {
                dataField: "r01F08",
                dataType: "datetime",
                caption: "Created Time",
                allowEditing: false
            },
            {
                dataField: "r01F09",
                dataType: "datetime",
                caption: "Updated Time",
                allowEditing: false
            },
        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
        },
    });
    // CustomStore for User Data
    var userStore = new DevExpress.data.CustomStore({
        load: function (loadOptions) {
            // log
            console.log("load options for get user record", loadOptions)
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/getAllUserResords",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                method: "GET",
                success: function (res) {
                    if (res.data === null) {
                        DevExpress.ui.notify("user record not found", "warning", 2000)
                    }
                    console.log("user records fetch successfully", res.data)
                    return res.data;
                },
                error: function (err) {
                    console.log("Error fetching user data", err);
                    DevExpress.ui.notify("Error fetching user data", "error", 3000);
                }
            });
        }
    });
    // CustomStore for Product Data (Get, Add, Update, Delete)
    var productStore = new DevExpress.data.CustomStore({
        // Load 
        load: function (loadOptions) {
            // log 
            console.log("load options fetching product", loadOptions)
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLPDT01/getAllProducts",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                method: "GET",
                success: function (res) {
                    if (res.data === null) {
                        DevExpress.ui.notify("product not fount", "warning", 2000)
                    }
                    DevExpress.ui.notify("product fetch successfully", "success", 2000)
                    return res.data;
                },
                error: function (err) {
                    console.log("Error fetching product data", err);
                    DevExpress.ui.notify("Error fetching product data", "error", 3000);
                }
            });
        },

        // insert 
        insert: function (values) {
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLPDT01/addProduct",
                method: "POST",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",
                data: JSON.stringify(values),
                success: function (res) {
                    console.log("add product", res.data)
                    DevExpress.ui.notify("Product added successfully", "success", 3000);
                },
                error: function (err) {
                    console.log("Error adding product", err);
                    DevExpress.ui.notify("Error adding product", "error", 3000);
                }
            });
        },
        // update 
        update: function (key, values) {
            console.log("key", key);
            console.log("values", values);
            // get token
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: `http://localhost:5021/api/CLPDT01/getProductById?id=${key.t01F01}`,
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",

            }).then((res) => {
                console.log(res)
                let ExistingProductData = res.data;
                console.log("ExistingProductData is", ExistingProductData);

                let updateProductData = {
                    t01F01: ExistingProductData.t01F01,
                    t01F02: values.t01F01 !== undefined ? values.t01F02 : ExistingProductData.t01F02,
                    t01F03: values.t01F03 !== undefined ? values.t01F03 : ExistingProductData.t01F03,
                    t01F04: values.t01F04 !== undefined ? values.t01F04 : ExistingProductData.t01F04,
                    t01F05: values.t01F05 !== undefined ? values.t01F05 : ExistingProductData.t01F05,
                    t01F06: values.t01F06 !== undefined ? values.t01F06 : ExistingProductData.t01F06,
                    t01F07: values.t01F07 !== undefined ? values.t01F07 : ExistingProductData.t01F07,
                    t01F08: values.t01F08 !== undefined ? values.t01F08 : ExistingProductData.t01F08,

                }
                console.log("update product is", updateProductData);

                return $.ajax({
                    url: "http://localhost:5021/api/CLPDT01/updateProduct",
                    method: "PUT",
                    headers: {
                        "Authorization": `Bearer ${token}`
                    },
                    contentType: "application/json",
                    data: JSON.stringify(updateProductData)
                }).done(() => {
                    DevExpress.ui.notify("update success", "success", 3000)
                }).fail(() => {
                    DevExpress.ui.notify("fail", "error", 2000)
                })
            })
        },

        // Remove (Delete Product)
        remove: function (key) {
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: `http://localhost:5021/api/CLPDT01/deleteProduct?id=${key}`,
                method: "DELETE",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                success: function (res) {
                    if (res.isError) {
                        DevExpress.ui.notify("Error while deleting product", "error", 3000);
                    } else {
                        DevExpress.ui.notify("Product deleted successfully", "success", 3000);
                    }
                },
                error: function (err) {
                    console.log("Error deleting product", err);
                    DevExpress.ui.notify("Error deleting product", "error", 3000);
                }
            });
        }
    });

    // CustomStore for Orders (Get Orders)
    var orderStore = new DevExpress.data.CustomStore({
        // Load (Get Orders)
        load: function (loadOptions) {
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLORD01/getAllOrders",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                method: "GET",
                success: function (res) {
                    return res.data;  // Return the fetched order data
                },
                error: function (err) {
                    console.log("Error fetching order data", err);
                    DevExpress.ui.notify("Error fetching order data", "error", 3000);
                }
            });
        },
        update: function (key, values) {
            let token = localStorage.getItem("Token");
            let orderId = key;
            let orderStatus = values;
            console.log("order id is ", orderId.d01F01);
            console.log("orderstatis is", orderStatus.d01F06)
            // Assuming you are updating the status field for an order
            return $.ajax({
                url: `http://localhost:5021/api/CLORD01/OrderStatusChanges?id=${key.d01F01}&newStatus=${values.d01F06}`,
                method: "PUT",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",
                data: JSON.stringify(values),
                success: function (res) {
                    if (res.isError) {
                        console.log("Error updating status: ", res.isError);
                        DevExpress.ui.notify("Error while updating status", "error", 3000);
                    } else {
                        console.log("Order status updated successfully.");
                        DevExpress.ui.notify("Order status updated successfully", "success", 3000);
                    }
                },
                error: function (err) {
                    console.log("Error while updating order status: ", err);
                    DevExpress.ui.notify("Error", "error", 3000);
                }
            });
        }
    });

    // User Data Button and Grid
    $("#UserData").dxButton({
        text: "User Record",
        type: "default",
        onClick: function () {
            DevExpress.ui.notify("Fetching User Data", "info", 3000);

            $("#UserContainer").dxDataGrid({
                dataSource: userStore,
                showBorders: true,
                wordWrapEnabled: true,
                showColumnLines: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                allowColumnReordering: true,
                columns: [
                    {
                        dataField: "r01F01",
                        dataType: "string",
                        caption: "User ID",
                        allowHeaderFiltering: false,
                        allowSearch: false,
                    },
                    {
                        dataField: "r01F02",
                        dataType: "string",
                        caption: "User Name"
                    },
                    {
                        dataField: "r01F03",
                        dataType: "string",
                        caption: "User Email"
                    },
                    {
                        dataField: "r01F06",
                        dataType: "string",
                        caption: "Address"
                    },
                    {
                        dataField: "r01F08",
                        dataType: "date",
                        caption: "Create DateTime"
                    },
                    {
                        dataField: "r01F09",
                        dataType: "date",
                        caption: "Update DateTime"
                    },
                ],
                masterDetail: {
                    enabled: true,
                    //autoExpandAll:true,

                    //Specifies a custom template for detail sections.
                    template(container, options) {
                        const currentUserData = options.data;
                        console.log("current user data", currentUserData)
                        $("<div>")
                            .addClass("master-detail-caption")
                            .text(`${currentUserData.r01F01} ${currentUserData.r01F02} Desciption`)
                            .appendTo(container);
                        $("<div>")
                            .dxDataGrid({
                                // master details must be allow arr data
                                dataSource: [currentUserData],
                                // dataSource:[
                                //     {
                                //   }
                                // ],

                                columnAutoWidth: true,
                                showBorders: true,
                                columns: [
                                    {
                                        dataField: "r01F04",
                                        dataType: "string",
                                        caption: "User Password",
                                        allowHeaderFiltering: false,
                                        allowSearch: false,
                                    },
                                    {
                                        dataField: "r01F05",
                                        dataType: "string",
                                        caption: "Phone Number"
                                    },
                                    {
                                        dataField: "r01F07",
                                        dataType: "string",
                                        caption: "Role",
                                        cellTemplate: function (container, options) {
                                            const roleEnum = {
                                                0: "Admin",
                                                1: "User"
                                            };
                                            const roleValue = options.value;
                                            const roleText = roleEnum[roleValue] || "Unknown";
                                            console.log("role text ", roleText)
                                            $("<div>")
                                                .text(roleText)
                                                .appendTo(container);
                                        }
                                    },


                                ],

                            }).appendTo(container)

                    }
                },
                paging: {
                    pageSize: 10
                },
                sorting: {
                    mode: "multiple"
                },
                filterRow: {
                    visible: true
                },
                searchPanel: {
                    visible: true
                },
                grouping: {
                    // expand data
                    autoExpandAll: true,
                    // user can not expand data only show category
                    allowCollapsing: true,
                    expandMode: "rowClick", //  buttonclick rowclick
                    // user can right click then show group by this column
                    contextMenuEnabled: true,
                    texts: {
                        ungroup: "ungroup please",
                        ungroupAll: "please ungroup all"
                    },
                },
                groupPanel: {
                    // show on ui
                    visible: true,
                    allowColumnDragging: true,
                    emptyPanelText: "Drag a column header here to group by that column"
                },
                headerFilter: {
                    visible: true
                },
                filterPanel: {
                    visible: true,
                    texts: {
                        createFilter: "please create filter",
                        clearFilter: "please remove filter"
                    },
                    filterEnabled: true // default true
                },
                filterRow: {
                    // show on ui with search iconm
                    visible: true,
                    applyFilter: "onClick",    // auto   onclick
                    // green color btn
                    applyFilterText: "apply filter show on ui ",
                    // if user click search icon in column then click between then show text
                    betweenEndText: "ends enter",
                    betweenStartText: "starts enter",
                    // operationDescriptions it is for user special
                    showOperationChooser: true, // default true       
                },
                sorting: {
                    mode: "single",  // 'multiple' | 'none' | 'single'
                    showSortIndexes: true,
                },
                selection: {
                    mode: 'multiple', // single , multiple , none
                    allowSelectAll: true, // default
                    showCheckBoxesMode: "onLongTap", // onclick , onlongtap,always,none
                    selectAllMode: "page" //allPages , page
                },
                columnChooser: {
                    enabled: true,
                    allowSearch: true,
                    emptyPanelText: "drag karo column",
                    height: 260,
                    mode: "dragAndDrop", // dragAndDrop and select 
                    // seaqrch time out
                    searchTimeout: 500,
                    // title 
                    title: "column chooser",
                    width: 600,
                },

            });
        }
    });
    // product button

    $("#ProductData").dxButton({
        text: "Product Record",
        type: "default",
        onClick: function () {
            DevExpress.ui.notify("Fetching Product Data", "info", 3000);

            $("#ProductContainer").dxDataGrid({
                dataSource: productStore,
                showBorders: true,
                wordWrapEnabled: true,
                showColumnLines: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                allowColumnReordering: true,
                columns: [
                    {
                        dataField: "t01F01",
                        dataType: "number",
                        caption: "Product ID",
                        allowEditing: false
                    },
                    {
                        dataField: "t01F02",
                        dataType: "string",
                        caption: "Product Name"
                    },
                    {
                        dataField: "t01F03",
                        dataType: "string",
                        caption: "Product Description"
                    },
                    {
                        dataField: "t01F04",
                        dataType: "string",
                        caption: "Product Category"
                    },
                    {
                        dataField: "t01F05",
                        dataType: "number",
                        caption: "Product Quantity"
                    },
                    {
                        dataField: "t01F06",
                        dataType: "number",
                        caption: "Product Price"
                    },
                    {
                        dataField: "t01F07",
                        dataType: "date",
                        caption: "Create DateTime"
                    },
                    {
                        dataField: "t01F08",
                        dataType: "date",
                        caption: "Update DateTime"
                    },
                ],
                paging: {
                    pageSize: 10
                },
                sorting: {
                    mode: "multiple"
                },
                filterRow: {
                    visible: true
                },
                searchPanel: {
                    visible: true
                },
                editing: {
                    mode: "popup",
                    allowUpdating: true,
                    allowDeleting: true,
                    allowAdding: true,
                    texts: {
                        addRow: "Add Product",
                        editRow: "Update Product"
                    }
                },
            });
        }
    });

    $("#OrdersData").dxButton({
        text: "Orders Record",
        type: "default",
        onClick: function () {
            DevExpress.ui.notify("Fetching Order Data", "info", 3000);

            $("#OrdersContainer").dxDataGrid({
                dataSource: orderStore,
                showBorders: true,
                wordWrapEnabled: true,
                showColumnLines: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                allowColumnReordering: true,
                columns: [
                    {
                        dataField: "d01F01",
                        dataType: "number",
                        caption: "Order ID",
                    },
                    {
                        dataField: "r01F01",
                        dataType: "number",
                        caption: "User ID",
                        allowEditing: false
                    },
                    {
                        dataField: "t01F01",
                        dataType: "number",
                        caption: "Product ID",
                        allowEditing: false
                    },
                    {
                        dataField: "d01F04",
                        dataType: "number",
                        caption: "Product Quantity",
                        allowEditing: false
                    },
                    {
                        dataField: "d01F05",
                        dataType: "number",
                        caption: "Total Amount",
                        allowEditing: false
                    },
                    {
                        dataField: "d01F06",
                        dataType: "string",
                        caption: "Status"
                    },
                    {
                        dataField: "d01F07",
                        dataType: "datetime",
                        caption: "Created Datetime",
                        allowEditing: false
                    },
                    {
                        dataField: "d01F08",
                        dataType: "datetime",
                        caption: "Updated Datetime"
                    }
                ],
                paging: {
                    pageSize: 10
                },
                sorting: {
                    mode: "multiple"
                },
                filterRow: {
                    visible: true
                },
                searchPanel: {
                    visible: true
                },
                editing: {

                    allowUpdating: true,

                },
            });
        }
    });

    $("#Logout").dxButton({
        text: "Logout",
        type: "danger",
        icon: "remove",
        onClick: function () {
            // two proccess
            // 1 clear token
            // 2 login.html

            // Clear the token from localStorage
            //localStorage.removeItem("Token");

            // Redirect to login page
            window.location.href = "login.html";
        }
    })
});
