window.jsPDF = window.jspdf.jsPDF;

$(document).ready(function () {
    console.log("doc is ready");

    // Create a custom store to handle data for the DataGrid
    var customStore = new DevExpress.data.CustomStore({
        key: "r01F01",  // Assuming "r01F01" is the unique ID for the records

        // Load data from the server
        load: function (loadOptions) {
            console.log("load options", loadOptions)
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/GetProfile", // Replace with your actual API URL
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                success: function (res) {
                    console.log("Profile data:", res.data);
                    // global handle
                    window.existingProfileData = res.data;
                    return res.data; // Return the data to the grid
                },
                error: function (err) {
                    console.log("Error loading data:", err);
                    DevExpress.ui.notify("Error loading data", "error", 3000);
                }
            });
        },

        // Update data on the server
        update: function (key, values) {
            console.log("valuesm",values)
            // asp .net core by default validation on 
            // please validatation false in program.cs 
            // new learning topic
            // pass data from getprofile to updateprofile
            let ExistingProfile = window.existingProfileData;
            let token = localStorage.getItem("Token");
            let objData = {
                r01F01: key,  // You can map values to the field names as required
                r01F02: values.r01F02 ?? ExistingProfile.r01F02,
                r01F03: values.r01F03 ?? ExistingProfile.r01F03,
                r01F04: values.r01F04 ?? ExistingProfile.r01F04,
                r01F05: values.r01F05 ?? ExistingProfile.r01F05,
                r01F06: values.r01F06 ?? ExistingProfile.r01F06,
                r01F07: values.r01F07 ?? ExistingProfile.r01F07
            };
            console.log("Sending data:", objData); 
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/updateUser", // Replace with your actual update API URL
                method: "PUT",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",
                data: JSON.stringify(objData),
                success: function (res) {
                    if (res.isError) {
                        console.log("Error updating user profile:", res.isError);
                        DevExpress.ui.notify("Error updating user profile", "error", 3000);
                    } else {
                        DevExpress.ui.notify("User profile updated successfully", "success", 3000);
                    }
                },
                error: function (err) {
                    console.log("Error updating data:", err);
                    DevExpress.ui.notify("Error updating data", "error", 3000);
                }
            });
        }
    });

    // CustomStore for CreateOrder
var createOrderStore = new DevExpress.data.CustomStore({
    //key: "r01F01", // Unique identifier for the order
    load: function (loadOptions) {

        let token = localStorage.getItem("Token");
        
        return $.ajax({
            url: "http://localhost:5021/GetMyorders", // API endpoint for fetching orders
            method: "GET",
            headers: {
                "Authorization": `Bearer ${token}`,
            },
            success: function (res) {
                console.log("Orders data fetched:", res.data);
                return res.data; // Return the fetched data
            },
            error: function (err) {
                console.log("Error fetching orders:", err);
                DevExpress.ui.notify("Error fetching orders", "error", 3000);
                return []; // Return empty array on error
            }
        });
    },
    insert: function (values) {
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
                if (res.isError) {
                    console.log("Error adding order:", res.isError);
                    DevExpress.ui.notify("Error while adding order", "error", 3000);
                } else {
                    DevExpress.ui.notify("Order added successfully", "success", 3000);
                }
            },
            error: function (err) {
                let a = err.responseJSON.message;

                console.log("Error adding order", err);
                DevExpress.ui.notify(`error :${a}`, "error", 3000);
            }
        });
    }
});

// Button to create order
$("#CreateOrder").dxButton({
    text: "Order",
    type: "default",
    onClick: function () {
        DevExpress.ui.notify("Creating order...", "info", 3000);

        let token = localStorage.getItem("Token");

        // Directly initialize the dxDataGrid
        $("#CreateOrderContainer").dxDataGrid({
            dataSource: createOrderStore,
            showBorders: true,
            wordWrapEnabled: true,
            showColumnLines: true,
            showRowLines: true,
            rowAlternationEnabled: true,
            allowColumnResizing: true,
            allowColumnReordering: true,
            onCellPrepared(options){
                if(options.column.dataField === "d01F06" ){
                    if(options.value == "pending"){
                        $(options.cellElement).css("color", "orange");
                    }
                    else if(options.value == "success"){
                        $(options.cellElement).css("color", "green");
                    }
                    else{
                        $(options.cellElement).css("color", "red");
                    }
                }
            },

            columns: [
                {
                    dataField: "d01F01",
                    dataType: "number",
                    caption: "Order ID",
                    allowEditing:false
                   
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
                    allowEditing:false
                },
                {
                    dataField: "d01F06",
                    dataType: "string",
                    caption: "Order Status",
                    allowEditing:false
                },
            ],

            editing: {
                mode:"popup",
                allowAdding: true,
                allowUpdating:false,
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


    // Initialize the DataGrid with the custom store
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
                allowEditing: false
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
            mode:"popup",
            allowUpdating: true,
        },
        // onRowUpdated: function (e) {
        //     const updatedUserProfile = e.data;
        //     console.log("Updated user profile:", updatedUserProfile);

        //     // Manually call the update method to update the data
        //     customStore.update(updatedUserProfile.r01F01, updatedUserProfile);
        // }
    });

    // Button to fetch and update user profile
    $("#UserProfile").dxButton({
        text: "User Profile",
        type: "default",
        icon: "card",
        onClick: function () {
            DevExpress.ui.notify("Fetch User Profile", "info", 3000);
            let token = localStorage.getItem("Token");

            $.ajax({
                url: "http://localhost:5021/api/CLUSR01/GetProfile", // Replace with your actual API URL
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${token}`
                },

                success: function (res) {
                    console.log("user profile", res.data);
                    let storeObj = [];
                    storeObj.push(res.data);
                    console.log("store obj in arr", storeObj);

                    // Initialize the DataGrid with the user profile data
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
                              
                            },
                            {
                                dataField: "r01F05",
                                dataType: "string",
                                caption: "Phone number",
                                
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
                                allowEditing: false
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
                            },
                        ],
                        editing: {
                            allowUpdating: true,
                        },
                        // onRowUpdated: function (e) {
                        //     const updatedUserProfile = e.data;
                        //     console.log("Updated user profile:", updatedUserProfile);

                        //     // Manually call the update method to update the data
                        //     customStore.update(updatedUserProfile.r01F01, updatedUserProfile);
                        // }
                    });
                },
                error: function (err) {
                    console.log("error while fetching profile", err);
                    DevExpress.ui.notify("error in fetching profile", "error", 3000)
                }
            })
        }
    });

    // Button to fetch and display products
    $("#ProductData").dxButton({
        text: "Product Data",
        type: "success",
        onClick: function () {
            DevExpress.ui.notify("Fetch Product Data", "info", 3000);

            $.ajax({
                url: "http://localhost:5021/api/CLPDT01/getAllProducts", // Replace with your actual API URL
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
                            {
                                dataField: "t01F01",
                                dataType: "number",
                                caption: "Product ID",
                            },
                            {
                                dataField: "t01F02",
                                dataType: "string",
                                caption: "Product Name",
                            },
                            {
                                dataField: "t01F03",
                                dataType: "string",
                                caption: "Product Description",
                            },
                            {
                                dataField: "t01F04",
                                dataType: "string",
                                caption: "Product Category",
                            },
                            // {
                            //     dataField: "t01F05",
                            //     dataType: "number",
                            //     caption: "Product Quantity",
                            // },
                            // {
                            //     dataField: "t01F06",
                            //     dataType: "number",
                            //     caption: "Product Price",
                            // },
                            {
                                caption:"Product Finance",
                                columns:[
                                    {
                                        dataField:"t01F05",
                                        caption:"product Quantity"
                                    },
                                    {
                                        dataField:"t01F06",
                                        caption:"product Price"
                                    }
                                ]
                            }
                        ],
                        summary:{
                            totalItems:[
                                {
                                    column:"t01F06",
                                    summaryType:"sum",
                                    displayFormat:"Total Price : {0}"
                                },
                                {
                                    column:"t01F05",
                                    summaryType:"sum",
                                    displayFormat:"Total Quantity : {0}"
                                }
                            ]
                        },
                        paging: {
                            pageSize: 10
                        },
                        filterRow: {
                            visible: true
                        },
                        searchPanel: {
                            visible: true
                        },
                        grouping:{
                            // expand data
                            autoExpandAll: true,
                            // user can not expand data only show category
                            allowCollapsing:true,
                            expandMode: "rowClick", //  buttonclick rowclick
                            // user can right click then show group by this column
                            contextMenuEnabled:true,
                            texts:{
                              ungroup:"ungroup please",
                              ungroupAll:"please ungroup all"             
                            },
                        },
                        groupPanel:{
                            // show on ui
                               visible:true,
                               allowColumnDragging:true,
                               emptyPanelText:"Drag a column header here to group by that column"
                        },
                        headerFilter:{
                            visible:true
                        },
                        filterPanel:{
                            visible:true,
                            texts:{
                                createFilter:"please create filter",
                                clearFilter:"please remove filter"
                            },
                            filterEnabled: true // default true
                        },
                        filterRow:{
                            // show on ui with search iconm
                            visible:true,
                            applyFilter: "onClick" ,    // auto   onclick
                            // green color btn
                            applyFilterText :"apply filter show on ui ",
                            // if user click search icon in column then click between then show text
                            betweenEndText:"ends enter" ,
                            betweenStartText:"starts enter",
                            // operationDescriptions it is for user special
                            showOperationChooser:true, // default true                
                        },
                        sorting: {
                            mode: "multiple",  // 'multiple' | 'none' | 'single'
                            showSortIndexes: true,
                        },
                        selection: {
                            mode: 'multiple', // single , multiple , none
                            allowSelectAll:true, // default
                            showCheckBoxesMode:"always", // onclick , onlongtap,always,none
                            selectAllMode:"page" //allPages , page
                        },
                        export:{
                            enabled:true,
                            formats: ['pdf'],
                            allowExportSelectedData:true
                        },
                        onExporting(e){
                            const doc = new jsPDF();
                
                            DevExpress.pdfExporter.exportDataGrid({
                                jsPDFDocument:doc,
                                component:e.component,
                                indent:4,
                            }).then(()=>{
                                doc.save("product.pdf")
                            })
                        }
                        
                    })
                },
                error: function (err) {
                    console.log("error fetching product data", err);
                    DevExpress.ui.notify("Error fetching Product data", "error", 3000);
                }
            })
        }
    });

    // Button to logout
    $("#LogOutBtn").dxButton({
        text: "Logout",
        type: "danger",
        icon: "remove",
        onClick: function () {
            // Clear the token from localStorage and redirect to login page
            localStorage.removeItem("Token");
            window.location.href = "login.html";
        }
    });
});
