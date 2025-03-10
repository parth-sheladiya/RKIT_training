$(document).ready(() => {
    console.log("Document is Ready");
    
    var customStore = new DevExpress.data.CustomStore({
        key: "id",

        // data
        load: () => {
            return $.getJSON("https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/")
                .then((data) => {
                    console.log("Data Loaded:", data);
                    return data; 
                })
                .fail((error) => {
                    console.error("Error fetching data:", error);
                    return []; 
                });
        },

        //insert daata
        insert: (values) => {
            return $.ajax({
                url: "https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/",
                method: "POST",
                data: values,
            })
                .then((response) => {
                    console.log("Inserted:", response);
                    customStore.load();
                })
                .fail((error) => {
                    console.error("Error inserting data:", error);
                });
        },

        //update method
        update: (key, values) => {
            return $.ajax({
                url: `https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/${key}`,
                method: "PUT",
                data: values,
            })
                .then((response) => {
                    console.log("Updated:", response);
                    customStore.load();
                })
                .fail((error) => {
                    console.error("Error updating data:", error);
                });
        },

        // delete data
        remove: (key) => {
            return $.ajax({
                url: `https://67a70408510789ef0dfcbb1f.mockapi.io/api/users/${key}`,
                method: "DELETE",
            })
                .then((response) => {
                    console.log("Deleted:", response);
                    customStore.load();
                })
                .fail((error) => {
                    console.error("Error deleting data:", error);
                });
        },

       loadMode: "raw", 
        errorHandler: (error) => {
            alert(error.message);
        },

        
    });
    
    // Initialize DataGrid
    const dataGrid =   $("#dataGridContainer").dxDataGrid({
        dataSource: customStore,
        keyExpr: "id", 
        columns: [
            { dataField: "id", caption: "ID" },
            { dataField: "name", caption: "Name" },
            { dataField: "email", caption: "Email" },
            
        ],
        editing:{
            mode:"raw",
            allowUpdating:true,
            allowAdding:true,
            allowDeleting:true,
        },
        paging: {
            pageSize: 5, 
        },
       
    }).dxDataGrid("instance");


    $("#LoadButton").dxButton({
        text: "Apply Load Options",
        onClick: function(){
            const loadOptions = {
                //filter: ["name", "=", "parth"],
                sort: [{ selector: "name", desc: true }], 
                skip: 1,
                take: 2,
            };
            console.log("load options is" , loadOptions);

            customStore.load(loadOptions).then((response) => {
                console.log("Load Options Applied:", response);               
            });
        },
        
    })
    

   
});
