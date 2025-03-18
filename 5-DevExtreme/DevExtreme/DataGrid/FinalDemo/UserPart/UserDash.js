import {DisplayNotifyMessage} from "../services/utils.js"
import {createDxButton} from "../services/button.js"
// overview of user dashboard
// 4 buttons ->  1. user profile 2. product data 3. order 4 . log out
// in this dashboard 
// 1. user can edit user profile but not change role 
// 2. user can view only product data user can not change product data 
// 3 . user can create order specific to product 

// globally handle pdf 
window.jsPDF = window.jspdf.jsPDF;

$(document).ready(function () {
    // debugging purpose 
    console.log("doc is ready");

    // user api custom store 
    // api  getprofile
    // updateprofile  (imp api learn new difference in asp .net core and framework)
    var customStore = new DevExpress.data.CustomStore({
        key: "r01F01",
        //load 
        load: function (loadOptions) {
            console.log("load options for user api load", loadOptions)
            // get token
            let token = localStorage.getItem("Token");
            // ajax for get 
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/GetProfile",
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                success: function (res) {
                    console.log("Profile data:", res.data);
                    // global handle beacuse it is use to update method 
                    window.existingProfileData = res.data;
                    return res.data;
                },
                error: function (err) {
                    console.log("error detecting while userdata fetching", err);
                    DisplayNotifyMessage("error detecting while userdata fetching", "error", 3000);
                }
            });
        },

        // update
        update: function (key, values) {
            console.log("valuesm", values)
            // asp .net core by default validation on 
            // please validatation false in program.cs 
            // new learning topic
            // pass data from getprofile to updateprofile
            let ExistingProfile = window.existingProfileData;
            // get token
            let token = localStorage.getItem("Token");
            // data object
            // if user can update specific data so user can easly handle update 
            let objData = {
                r01F01: key,
                r01F02: values.r01F02 ?? ExistingProfile.r01F02,
                r01F03: values.r01F03 ?? ExistingProfile.r01F03,
                r01F04: values.r01F04 ?? ExistingProfile.r01F04,
                r01F05: values.r01F05 ?? ExistingProfile.r01F05,
                r01F06: values.r01F06 ?? ExistingProfile.r01F06,
                r01F07: values.r01F07 ?? ExistingProfile.r01F07
            };
            // log 
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
                    // log 
                    console.log("user update success", res.data)
                    DisplayNotifyMessage("User profile updated successfully", "success", 3000);
                },
                error: function (err) {
                    console.log("Error updating data:", err);
                    DisplayNotifyMessage("Error updating data", "error", 3000);
                }
            });
        }
    });

    // order api custom store 
    // api get my orders
    // create order
    var createOrderStore = new DevExpress.data.CustomStore({
        //key: "r01F01", // Unique identifier for the order
        load: function (loadOptions) {
            // log 
            console.log("load options for load while create order", loadOptions);
            // get token
            let token = localStorage.getItem("Token");

            return $.ajax({
                url: "http://localhost:5021/GetMyorders",
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`,
                },
                success: function (res) {
                    // handle null data
                    if (res.data === null) {
                        DisplayNotifyMessage("orders data not fount", "warning", 3000)
                    } else {
                        console.log("Orders data fetched:", res.data);
                        DisplayNotifyMessage("Order data fetch successfully")
                    }

                    return res.data;
                },
                error: function (err) {
                    console.log("Error fetching orders:", err);
                    DisplayNotifyMessage("Error fetching orders", "error", 3000);
                    return [];
                }
            });
        },
        insert: function (values) {
            // get token
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLORD01/CreateOrder", // API endpoint to create an order
                method: "POST",
                headers: {
                    "Authorization": `Bearer ${token}`,
                },
                contentType: "application/json",
                data: JSON.stringify(values),
                success: function (res) {
                    console.log("order generate successfully , please order status check after 1 hour")
                    DisplayNotifyMessage("Order added successfully  , please order status check after 1 hour", "success", 3000);
                },
                error: function (err) {
                    let a = err.responseJSON.message;
                    console.log("Error adding order", err);
                    DisplayNotifyMessage(`error :${a}`, "error", 3000);
                }
            });
        }
    });

    // Button to create order
    $("#CreateOrder").dxButton({
        text: "Order",
        type: "default",
        onClick: function () {
            DevExpress.ui.notify("Creating order", "info", 3000);


            //  initialize the dxDataGrid
            $("#CreateOrderContainer").dxDataGrid({
                dataSource: createOrderStore,
                showBorders: true,
                wordWrapEnabled: true,
                showColumnLines: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                allowColumnReordering: true,
                onCellPrepared(options) {
                    if (options.column.dataField === "d01F06") {
                        if (options.value == "pending") {
                            $(options.cellElement).css("color", "orange");
                        }
                        else if (options.value == "success") {
                            $(options.cellElement).css("color", "green");
                        }
                        else if (options.value == "cancelled") {
                            $(options.cellElement).css("color", "red");
                        }
                    }
                },

                columns: [
                    {
                        dataField: "d01F01",
                        dataType: "number",
                        caption: "Order ID",
                        allowEditing: false

                    },
                    {
                        dataField: "r01F01",
                        dataType: "number",
                        caption: "User ID",
                        // allowEditing:false

                    },
                    {
                        dataField: "t01F01",
                        dataType: "number",
                        caption: "Product ID",
                        // allowEditing:false

                    },
                    {
                        dataField: "d01F04",
                        dataType: "number",
                        caption: "Product Quantity",

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
                        caption: "Order Status",
                        allowEditing: false
                    },
                ],

                editing: {
                    mode: "popup",
                    allowAdding: true,
                    allowUpdating: false,
                    texts: {
                        addRow: "Create Order",
                    }
                },
                // onCellPrepared: function(e) {
                //     console.log("cell prepare" , e)
                //     if (e.rowType === "data" && e.column.dataField === "d01F06") {
                //         // Check if the status is "cancel" or "success"
                //         if (e.data.d01F06 === "cancel" || e.data.d01F06 === "success") {
                //             e.cellElement.attr("disabled", "disabled"); 
                //         }
                //     }
                // }
            });
        }
    });


    // Initialize the DataGrid 
    $("#UserProfileContainer").dxDataGrid({
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
                // data validation 4.3 
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

    createDxButton("#UserProfile", "User Profile", "default", "card", () => {
    DevExpress.ui.notify("Fetching User Profile...", "info", 3000);
    let token = localStorage.getItem("Token");

    if (!token) {
        DisplayNotifyMessage("Token not found. Please log in again.", "error", 3000);
        return;
    }

    $.ajax({
        url: "http://localhost:5021/api/CLUSR01/GetProfile",
        method: "GET",
        headers: { "Authorization": `Bearer ${token}` },

        success: function (res) {
            console.log("User Profile Data:", res.data);
            let storeObj = [res.data]; // Convert single object to array

            $("#UserProfileContainer").dxDataGrid({
                dataSource: storeObj,
                showBorders: true,
                wordWrapEnabled: true,
                showColumnLines: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                allowColumnResizing: true,
                allowColumnReordering: true,
                columns: [
                    { dataField: "r01F01", caption: "User ID", dataType: "number", allowEditing: false },
                    { dataField: "r01F02", caption: "User Name", dataType: "string" },
                    { dataField: "r01F03", caption: "User Email", dataType: "string" },
                    { dataField: "r01F04", caption: "Password", dataType: "string" },
                    { dataField: "r01F05", caption: "Phone Number", dataType: "string" },
                    { dataField: "r01F06", caption: "Address", dataType: "string" },
                    { dataField: "r01F07", caption: "Role", dataType: "string", allowEditing: false },
                    { dataField: "r01F08", caption: "Created Time", dataType: "datetime", allowEditing: false },
                    { dataField: "r01F09", caption: "Updated Time", dataType: "datetime" }
                ],
                editing: { allowUpdating: true }
            });

           DisplayNotifyMessage("User Profile Loaded Successfully!", "success", 3000);
        },
        error: function (err) {
            console.log("Error fetching profile:", err);
            DisplayNotifyMessage("Error fetching user profile.", "error", 3000);
        }
    });
});


    createDxButton("#ProductData", "Product Data", "success", "", () => {
        DevExpress.ui.notify("Fetch Product Data", "info", 3000);
    
        $.ajax({
            url: "http://localhost:5021/api/CLPDT01/getAllProducts",
            method: "GET",
            success: function (res) {
                console.log("Product Data:", res.data);
                $("#ProductDataContainer").dxDataGrid({
                    dataSource: res.data,
                    showBorders: true,
                    wordWrapEnabled: true,
                    showColumnLines: true,
                    showRowLines: true,
                    rowAlternationEnabled: true,
                    allowColumnResizing: true,
                    allowColumnReordering: true,
                    columns: [
                        { dataField: "t01F01", dataType: "number", caption: "Product ID" },
                        { dataField: "t01F02", dataType: "string", caption: "Product Name" },
                        { dataField: "t01F03", dataType: "string", caption: "Product Description" },
                        { dataField: "t01F04", dataType: "string", caption: "Product Category" },
                        {
                            caption: "Product Finance",
                            columns: [
                                { dataField: "t01F05", caption: "Product Quantity" },
                                { dataField: "t01F06", caption: "Product Price" }
                            ]
                        }
                    ],
                    summary: {
                        totalItems: [
                            { column: "t01F06", summaryType: "sum", displayFormat: "Total Price : {0}" },
                            { column: "t01F05", summaryType: "sum", displayFormat: "Total Quantity : {0}" }
                        ]
                    },
                    paging: { pageSize: 10 },
                    filterRow: { visible: true },
                    searchPanel: { visible: true },
                    sorting: { mode: "multiple", showSortIndexes: true },
                    selection: {
                        mode: 'multiple',
                        allowSelectAll: true,
                        showCheckBoxesMode: "always",
                        selectAllMode: "page"
                    },
                    export: {
                        enabled: true,
                        formats: ['pdf'],
                        allowExportSelectedData: true
                    },
                    onExporting(e) {
                        const doc = new jsPDF();
                        DevExpress.pdfExporter.exportDataGrid({
                            jsPDFDocument: doc,
                            component: e.component,
                            indent: 4,
                        }).then(() => {
                            doc.save("product.pdf");
                        });
                    }
                });
            },
            error: function (err) {
                console.log("Error fetching product data", err);
                DevExpress.ui.notify("Error fetching Product data", "error", 3000);
            }
        });
    });

    // Button to logout
    // $("#LogOutBtn").dxButton({
    //     text: "Logout",
    //     type: "danger",
    //     icon: "remove",
    //     onClick: function () {
    //         // Clear the token from localStorage and redirect to login page
    //         localStorage.removeItem("Token");
    //         window.location.href = "login.html";
    //     }
    // });

    createDxButton("#LogOutBtn", "Logout", "danger", "remove", () => {
        localStorage.removeItem("Token");
        window.location.href = "../Auth/Login/login.html";
    });
});
