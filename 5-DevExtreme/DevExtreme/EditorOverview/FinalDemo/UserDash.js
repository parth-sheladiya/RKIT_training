// $(document).ready(function () {
//     console.log("doc is ready");

//     $("#UserProfile").dxButton({
//         text: "User Profile",
//         type: "default",
//         icon: "card",
//         onClick: function () {
//             DevExpress.ui.notify("Fetch User Profile", "info", 3000);
//             let token = localStorage.getItem("Token");

//             $.ajax({
//                 url: "http://localhost:5021/api/CLUSR01/GetProfile",
//                 method: "GET",
//                 headers: {
//                     "Authorization": `Bearer ${token}`
//                 },

//                 success: function (res) {
//                     console.log("user profile", res.data);
//                     let storeObj = [];
//                     storeObj.push(res.data);
//                     console.log("store obj in arr", storeObj);

//                     $("#UserProfileContainer").dxDataGrid({
//                         dataSource: storeObj,
//                         showBorders: true,
//                         wordWrapEnabled: true,
//                         showColumnLines: true,
//                         showRowLines: true,
//                         rowAlternationEnabled: true,
//                         allowColumnResizing: true,
//                         allowColumnReordering: true,
//                         columns: [
//                             {
//                                 dataField: "r01F01",
//                                 dataType: "number",
//                                 caption: "User ID",
//                                 allowEditing: false
//                             },
//                             {
//                                 dataField: "r01F02",
//                                 dataType: "string",
//                                 caption: "User Name",
//                             },
//                             {
//                                 dataField: "r01F03",
//                                 dataType: "string",
//                                 caption: "User Email",
//                             },
//                             {
//                                 dataField: "r01F04",
//                                 dataType: "string",
//                                 caption: "Password",
//                             },
//                             {
//                                 dataField: "r01F05",
//                                 dataType: "string",
//                                 caption: "Phone number",
//                             },
//                             {
//                                 dataField: "r01F06",
//                                 dataType: "string",
//                                 caption: "Address",
//                             },
//                             {
//                                 dataField: "r01F07",
//                                 dataType: "string",
//                                 caption: "Role",
//                                 allowEditing: false
//                             },
//                             {
//                                 dataField: "r01F08",
//                                 dataType: "datetime",
//                                 caption: "Created Time",
//                                 allowEditing: false
//                             },
//                             {
//                                 dataField: "r01F09",
//                                 dataType: "datetime",
//                                 caption: "Updated Time",
//                             },
//                         ],
//                         editing: {
//                             allowUpdating: true,
//                         },
//                         onRowUpdated: function (e) {
//                             const updateUserProfile = e.data;
//                             console.log("updated user profile is", updateUserProfile);

//                             $.ajax({
//                                 url: "http://localhost:5021/api/CLUSR01/updateUser",
//                                 method: "PUT",
//                                 headers: {
//                                     "Authorization": `Bearer ${token}`
//                                 },
//                                 contentType: "application/json",
//                                 data: JSON.stringify(updateUserProfile),
//                                 success: function (res) {
//                                     if (res.isError) {
//                                         console.log("error while update user profile", res.isError)
//                                         DevExpress.ui.notify("error while update user", "error", 3000)
//                                     } else {
//                                         DevExpress.ui.notify("User profile update successfully", "success", 3000)
//                                     }
//                                 },
//                                 error: function (err) {
//                                     console.log("go to promise error ", err)
//                                     DevExpress.ui.notify("error while update user", "error", 3000)
//                                 }
//                             })
//                         }
//                     })
//                 },
//                 error: function (err) {
//                     console.log("error while fatching profile", err);
//                     DevExpress.ui.notify("error in faching profile", "error", 3000)
//                 }
//             })
//         }
//     })

//     $("#ProductData").dxButton({
//         text: "Product Data",
//         type: "success",
//         onClick: function () {
//             DevExpress.ui.notify("Fetch Product Data", "info", 3000);

//             $.ajax({
//                 url: "http://localhost:5021/api/CLPDT01/getAllProducts",
//                 method: "GET",
//                 // headers:{
//                 //     "Authorization":`Bearer ${token}`
//                 // },
//                 success: function (res) {
//                     console.log("res", res.data);
//                     $("#ProductDataContainer").dxDataGrid({
//                         dataSource: res.data,
//                         showBorders: true,
//                         wordWrapEnabled: true,
//                         showColumnLines: true,
//                         showRowLines: true,
//                         rowAlternationEnabled: true,
//                         allowColumnResizing: true,
//                         allowColumnReordering: true,
//                         columns: [
//                             {
//                                 dataField: "t01F01",
//                                 dataType: "number",
//                                 caption: "Product ID",
//                             },
//                             {
//                                 dataField: "t01F02",
//                                 dataType: "string",
//                                 caption: "Product Name",
//                             },
//                             {
//                                 dataField: "t01F03",
//                                 dataType: "string",
//                                 caption: "Product Description",
//                             },
//                             {
//                                 dataField: "t01F04",
//                                 dataType: "string",
//                                 caption: "Product Category",
//                             },
//                             {
//                                 dataField: "t01F05",
//                                 dataType: "number",
//                                 caption: "Product Quantity",
//                             },
//                             {
//                                 dataField: "t01F06",
//                                 dataType: "number",
//                                 caption: "Product Price",
//                             },
//                         ],
//                         paging: {
//                             pageSize: 10
//                         },
//                         filterRow: {
//                             visible: true
//                         },
//                         searchPanel: {
//                             visible: true
//                         },
//                     })
//                 },
//                 error: function (err) {
//                     console.log("eror", err);
//                     DevExpress.ui.notify("Error fetching Product data", "error", 3000);
//                 }

//             })
//         }
//     })

//     // $("#CreateOrder").dxButton({
//     //     text: "Create Order",
//     //     type: "default",
//     //     onClick: function () {
//     //         DevExpress.ui.notify("creating order", "info", 3000)

//     //         let token = localStorage.getItem("Token")
//     //         $.ajax({
//     //             url:"http://localhost:5021/GetMyorders",
//     //             method:"GET",
//     //             headers:{
//     //                 "Authorization":`Bearer ${token}`,

//     //             },
//     //             success: function (res) {
//     //                 console.log(res);
//     //                 $("#CreateOrderContainer").dxDataGrid({
//     //                     dataSource: res.data,
//     //                     showBorders: true,
//     //                     wordWrapEnabled: true,
//     //                     showColumnLines: true,
//     //                     showRowLines: true,
//     //                     rowAlternationEnabled: true,
//     //                     allowColumnResizing: true,
//     //                     allowColumnReordering: true,

//     //                     columns: [
//     //                         {
//     //                             dataField: "r01F01",
//     //                             dataType: "number",
//     //                             caption: "User ID",
//     //                         },
//     //                         {
//     //                             dataField: "t01F01",
//     //                             dataType: "number",
//     //                             caption: "Product ID",
//     //                         },
//     //                         {
//     //                             dataField: "d01F04",
//     //                             dataType: "number",
//     //                             caption: "Product Quantity",
//     //                         },

//     //                     ],

//     //                     editing: {
//     //                         allowAdding: true,
//     //                         texts: {
//     //                             addRow: "Add Product",
//     //                         }
//     //                     },
//     //                     onRowInserted: function (e) {
//     //                         let newOrderData = e.data;
//     //                         console.log("new order data is", newOrderData);
//     //                         $.ajax({
//     //                             url: "http://localhost:5021/api/CLORD01/CreateOrder",
//     //                             method: "POST",
//     //                             headers: {
//     //                                 "Authorization": `Bearer ${token}`
//     //                             },
//     //                             contentType: "application/json",
//     //                             data:JSON.stringify(newOrderData),
//     //                             success:function(res){
//     //                                 if(res.isError){
//     //                                     console.log(res.isError)
//     //                                     DevExpress.ui.notify("error while add order","error",3000)
//     //                                 }else{
//     //                                     DevExpress.ui.notify("order add successfully","success",3000)
//     //                                 }
//     //                             },
//     //                             error:function(err){
//     //                                 console.log("error add order", err);
//     //                                 DevExpress.ui.notify("error","error",3000)
//     //                             }
//     //                         })

//     //                     }
//     //                 })
//     //             }
//     //         })
//     //     }
//     // })

//     $("#CreateOrder").dxButton({
//         text: "Create Order",
//         type: "default",
//         onClick: function () {
//             DevExpress.ui.notify("Creating order...", "info", 3000);
    
//             let token = localStorage.getItem("Token");
    
//             // Fetch orders from the API
//             $.ajax({
//                 url: "http://localhost:5021/GetMyorders",
//                 method: "GET",
//                 headers: {
//                     "Authorization": `Bearer ${token}`,
//                 },
//                 success: function (res) {
//                     console.log(res);
    
//                     // Check if dxDataGrid is already initialized
//                     var gridInstance = $("#CreateOrderContainer").dxDataGrid("instance");
    
//                     // If dxDataGrid is not initialized, initialize it
//                     if (!gridInstance) {
//                         $("#CreateOrderContainer").dxDataGrid({
//                             dataSource: res.data,
//                             showBorders: true,
//                             wordWrapEnabled: true,
//                             showColumnLines: true,
//                             showRowLines: true,
//                             rowAlternationEnabled: true,
//                             allowColumnResizing: true,
//                             allowColumnReordering: true,
    
//                             columns: [
//                                 {
//                                     dataField: "r01F01",
//                                     dataType: "number",
//                                     caption: "User ID",
//                                 },
//                                 {
//                                     dataField: "t01F01",
//                                     dataType: "number",
//                                     caption: "Product ID",
//                                 },
//                                 {
//                                     dataField: "d01F04",
//                                     dataType: "number",
//                                     caption: "Product Quantity",
//                                 },
//                             ],
    
//                             editing: {
//                                 allowAdding: true,
//                                 texts: {
//                                     addRow: "Add Product",
//                                 }
//                             },
    
//                             // Handling the new row insert
//                             onRowInserted: function (e) {
//                                 let newOrderData = e.data;
//                                 console.log("New order data:", newOrderData);
    
//                                 // Send the new order data to the API
//                                 $.ajax({
//                                     url: "http://localhost:5021/api/CLORD01/CreateOrder",
//                                     method: "POST",
//                                     headers: {
//                                         "Authorization": `Bearer ${token}`,
//                                     },
//                                     contentType: "application/json",
//                                     data: JSON.stringify(newOrderData),
//                                     success: function (res) {
//                                         if (res.isError) {
//                                             console.log(res.isError);
//                                             DevExpress.ui.notify("Error while adding order", "error", 3000);
//                                         } else {
//                                             DevExpress.ui.notify("Order added successfully", "success", 3000);
//                                         }
//                                     },
//                                     error: function (err) {
//                                         console.log("Error adding order", err);
//                                         DevExpress.ui.notify("Error", "error", 3000);
//                                     }
//                                 });
//                             }
//                         });
//                     } else {
//                         // If dxDataGrid is already initialized, just update the dataSource
//                         gridInstance.option("dataSource", res.data);
//                     }
//                 },
//                 error: function (err) {
//                     console.log("Error fetching orders:", err);
//                     DevExpress.ui.notify("Error fetching orders", "error", 3000);
//                 }
//             });
//         }
//     });
    
    

//     $("#LogOutBtn").dxButton({
//         text: "Logout",
//         type: "danger",
//         icon: "remove",
//         onClick: function () {
//             // two proccess
//             // 1 clear token
//             // 2 login.html

//             // Clear the token from localStorage
//             localStorage.removeItem("Token");

//             // Redirect to login page
//             window.location.href = "login.html";
//         }
//     })
// })



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
            let token = localStorage.getItem("Token");
            return $.ajax({
                url: "http://localhost:5021/api/CLUSR01/updateUser", // Replace with your actual update API URL
                method: "PUT",
                headers: {
                    "Authorization": `Bearer ${token}`
                },
                contentType: "application/json",
                data: JSON.stringify(values),
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
                    allowEditing:false
                    
                },
                {
                    dataField: "t01F01",
                    dataType: "number",
                    caption: "Product ID",
                    allowEditing:false
                    
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
                allowAdding: true,
                allowUpdating:true,
                texts: {
                    addRow: "Create Order",
                }
            },
            onCellPrepared: function(e) {
                console.log("cell prepare" , e)
                if (e.rowType === "data" && e.column.dataField === "d01F06") {
                    // Check if the status is "cancel" or "success"
                    if (e.data.d01F06 === "cancel" || e.data.d01F06 === "success") {
                        e.cellElement.attr("disabled", "disabled"); 
                    }
                }
            }
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
        onRowUpdated: function (e) {
            const updatedUserProfile = e.data;
            console.log("Updated user profile:", updatedUserProfile);

            // Manually call the update method to update the data
            customStore.update(updatedUserProfile.r01F01, updatedUserProfile);
        }
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
                        onRowUpdated: function (e) {
                            const updatedUserProfile = e.data;
                            console.log("Updated user profile:", updatedUserProfile);

                            // Manually call the update method to update the data
                            customStore.update(updatedUserProfile.r01F01, updatedUserProfile);
                        }
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
                            {
                                dataField: "t01F05",
                                dataType: "number",
                                caption: "Product Quantity",
                            },
                            {
                                dataField: "t01F06",
                                dataType: "number",
                                caption: "Product Price",
                            },
                        ],
                        paging: {
                            pageSize: 10
                        },
                        filterRow: {
                            visible: true
                        },
                        searchPanel: {
                            visible: true
                        },
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
