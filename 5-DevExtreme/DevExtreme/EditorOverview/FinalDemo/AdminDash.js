$(document).ready(function(){
    console.log("admin dashboard is ready");

    $("#UserData").dxButton({
        text: "User Record",
        type:"default",
        onClick:function(){
            DevExpress.ui.notify("Fetch User Data","info",3000);
            let token = localStorage.getItem("Token")
            $.ajax({
                url:"http://localhost:5021/api/CLUSR01/getAllUserResords",
                headers:{
                    "Authorization":`Bearer ${token}`,

                },
                method:"GET",
                success:function(res){
                    // fetch data 
                    // const dataUser = new DevExpress.data.ArrayStore({
                    //     data: res.data
                    // });
                    console.log("Res",res.data)
                    $("#UserContainer").dxDataGrid({
                        dataSource:res.data,
                        showBorders: true,
                        wordWrapEnabled: true,
                        showColumnLines: true,
                        showRowLines: true,
                        rowAlternationEnabled: true,
                        allowColumnResizing:true,
                        allowColumnReordering:true,
                        columns:[
                            {
                                dataField:"r01F01",
                                dataType:"string",
                                caption:"User ID"
                            },
                            {
                                dataField:"r01F02",
                                dataType:"string",
                                caption:"User Name"
                            },
                            {
                                dataField:"r01F03",
                                dataType:"string",
                                caption:"User Email"
                            },
                            {
                                dataField:"r01F04",
                                dataType:"string",
                                caption:"User Password"
                            },
                            {
                                dataField:"r01F05",
                                dataType:"string",
                                caption:"Phone Number"
                            },
                            {
                                dataField:"r01F06",
                                dataType:"string",
                                caption:"Address"
                            },
                            {
                                dataField:"r01F07",
                                dataType:"string",
                                caption:"Role"
                            },
                            {
                                dataField:"r01F08",
                                dataType:"date",
                                caption:"Create DateTime"
                            },
                            {
                                dataField:"r01F09",
                                dataType:"date",
                                caption:"Update Datetime"
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
                        // editing: {
                        //     allowUpdating: true,
                        //     allowDeleting: true,
                        //     allowAdding: true
                        // }
                    })
                },
                error: function (err) {
                    console.log("eror",err);
                    DevExpress.ui.notify("Error fetching data", "error", 3000);
                }
            })
        }
    })

    $("#ProductData").dxButton({
        text: "Product Record",
        type:"default",
        onClick:function(){
            DevExpress.ui.notify("Fetch Product Data","info",3000)

            let token = localStorage.getItem("Token")
            console.log("token",token);
            $.ajax({
                url:"http://localhost:5021/api/CLPDT01/getAllProducts",
                headers:{
                    "Authorization":`Bearer ${token}`,

                },
                method:"GET",
                success:function(res){
                    console.log("product res is ", res.data);
                    $("#ProductContainer").dxDataGrid({
                        dataSource:res.data,
                        showBorders: true,
                        wordWrapEnabled: true,
                        showColumnLines: true,
                        showRowLines: true,
                        rowAlternationEnabled: true,
                        allowColumnResizing:true,
                        allowColumnReordering:true,
                        columns:[
                            {
                                dataField:"t01F01",
                                dataType:"number",
                                caption:"Product ID",
                                allowEditing:false
                            },
                            {
                                dataField:"t01F02",
                                dataType:"string",
                                caption:"Product Name "
                            },
                            {
                                dataField:"t01F03",
                                dataType:"string",
                                caption:"Product Description "
                            },
                            {
                                dataField:"t01F04",
                                dataType:"string",
                                caption:"Product CateGory "
                            },
                            {
                                dataField:"t01F05",
                                dataType:"number",
                                caption:"Product Quantity "
                            },
                            {
                                dataField:"t01F06",
                                dataType:"number",
                                caption:"Product Price "
                            },
                            {
                                dataField:"t01F07",
                                dataType:"date",
                                caption:"Create Product Datetime"
                            },
                            {
                                dataField:"t01F08",
                                dataType:"date",
                                caption:"Update Product Datetime"
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
                            allowUpdating: true,
                            allowDeleting: true,
                            allowAdding: true,
                            texts:{
                                addRow:"Add Product",
                                editRow:"UpdateProduct"
                            }
                        },
                        // live use oninserted()
                        onRowInserted:function(e){
                            let newProductData = e.data;
                            console.log("new product data is " , newProductData);

                            $.ajax({
                                url:"http://localhost:5021/api/CLPDT01/addProduct",
                                method:"POST",
                                headers: {
                                    "Authorization": `Bearer ${token}`,
                                },
                                contentType: "application/json",
                                data:JSON.stringify(newProductData),
                                success:function(res){
                                    if(res.isError){
                                        console.log(res.isError)
                                        DevExpress.ui.notify("error while add product","danger",3000)
                                    }else{
                                        DevExpress.ui.notify("product add successfully","success",3000)
                                    }
                                },
                                error:function(err){
                                    console.log("error add product", err);
                                    DevExpress.ui.notify("error","danger",3000)
                                }
                            })
                        },
                        onRowUpdated:function(e){
                            let updateProductData = e.data;
                            console.log("updated product data is" , updateProductData);

                            $.ajax({
                                url:"http://localhost:5021/api/CLPDT01/updateProduct",
                                method:"PUT",
                                headers: {
                                    "Authorization": `Bearer ${token}`,
                                },
                                contentType: "application/json",
                                data:JSON.stringify(updateProductData),
                                success:function(res){
                                    if(res.isError){
                                        console.log(res.isError)
                                        DevExpress.ui.notify("error while update product","error",3000)
                                    }else{
                                        DevExpress.ui.notify("product updated successfully","success",3000)
                                    }
                                },
                                error:function(err){
                                    console.log("error update product", err);
                                    DevExpress.ui.notify("error","error",3000)
                                }
                            })
                        },
                        onRowRemoved:function(e){
                            let removeData =  e.data;
                            console.log("deleted data is ", removeData);

                            $.ajax({
                                url:`http://localhost:5021/api/CLPDT01/deleteProduct?id=${removeData.t01F01}`,
                                method:"DELETE",
                                headers: {
                                    "Authorization": `Bearer ${token}`,
                                },
                                // contentType: "application/json",
                                success:function(res){
                                    if(res.isError){
                                        console.log(res.isError)
                                        DevExpress.ui.notify("error while Delete product","error",3000)
                                    }else{
                                        DevExpress.ui.notify("product Deleted successfully","success",3000)
                                    }
                                },
                                error:function(err){
                                    console.log("error delete product", err);
                                    DevExpress.ui.notify("error","error",3000)
                                }
                            })
                        }
                    })
                },
                error:function(err){
                    console.log("eror",err);
                    DevExpress.ui.notify("Error fetching data", "error", 3000);
                }
            })


        }
    })

    $("#AdminProfile").dxButton({
        text:"Profile",
        type:"success",
        icon:"card",
        onClick:function(){
            DevExpress.ui.notify("Fetch Admin Profile","info",3000);
            let token = localStorage.getItem("Token");
            $.ajax({
                url:"http://localhost:5021/api/CLUSR01/GetProfile",
                headers:{
                    "Authorization":`Bearer ${token}`
                },
                method:"GET",
                
                success:function(res){
                    console.log("res",res.data)
                    DevExpress.ui.notify("admin profile fatch successfully","success",3000);
                    // thigdu
                    let info = [] ;    
                        
                        info.push(res.data)
                        console.log("store obj in array then push",info)
                    
                    $("#ProfileContainer").dxDataGrid({
                        dataSource:info,
                        showBorders: true,
                        wordWrapEnabled: true,
                        showColumnLines: true,
                        showRowLines: true,
                        rowAlternationEnabled: true,
                        allowColumnResizing:true,
                        allowColumnReordering:true,
                        columns:[
                            {
                                dataField:"r01F01",
                                dataType:"number",
                                caption:"User ID", 
                                allowEditing:false                              
                            },
                            {
                                dataField:"r01F02",
                                dataType:"string",
                                caption:"User Name",                               
                            },
                            {
                                dataField:"r01F03",
                                dataType:"string",
                                caption:"User Email",                               
                            },
                            {
                                dataField:"r01F04",
                                dataType:"string",
                                caption:"Password",                               
                            },
                            {
                                dataField:"r01F05",
                                dataType:"string",
                                caption:"Phone number",                               
                            },
                            {
                                dataField:"r01F06",
                                dataType:"string",
                                caption:"Address",                               
                            },
                            {
                                dataField:"r01F07",
                                dataType:"string",
                                caption:"Role",
                                allowEditing:false                               
                            },
                            {
                                dataField:"r01F08",
                                dataType:"datetime",
                                caption:"Created Time",
                                allowEditing:false                               
                            },
                            {
                                dataField:"r01F09",
                                dataType:"datetime",
                                caption:"Updated Time",                               
                            },

                        ],
                        editing:{
                            allowUpdating:true,
                        },
                        onRowUpdated:function(e){
                            const updateProfile = e.data;
                            console.log("updated prifle data is" , updateProfile);

                            $.ajax({
                                url:"http://localhost:5021/api/CLUSR01/updateUser",
                                method:"PUT",
                                headers:{
                                    "Authorization":`Bearer ${token}`
                                },
                                contentType: "application/json",
                                data:JSON.stringify(updateProfile),
                                success:function(res){
                                    if(res.isError){
                                        console.log(res.isError)
                                        DevExpress.ui.notify("error while update user","error",3000)
                                    }else{
                                        DevExpress.ui.notify("user profile update successfully","success",3000)
                                    }
                                },
                                error:function(err){
                                    console.log("error update profile", err);
                                    DevExpress.ui.notify("error","error",3000)
                                }
                            })

                        }

                    })
                },
                error:function(err){
                    console.log("error while fatching profile", err);
                    DevExpress.ui.notify("error in faching profile","error",3000)
                }
            })
        }
    })

    $("#Logout").dxButton({
        text:"Logout",
        type:"danger",
        icon:"remove",
        onClick: function() {
            // two proccess
            // 1 clear token
            // 2 login.html
            
            // Clear the token from localStorage
            localStorage.removeItem("Token");
            
            // Redirect to login page
            window.location.href = "login.html"; 
        }
    })

})