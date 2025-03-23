$(document).ready(function(){
    console.log("docs is ready");

    var dataGrid = $("#StateContainer").dxDataGrid({
        dataSource: products,
        showBorders: true,
        allowColumnReordering: true,
        allowColumnResizing: true,
        rowAlternationEnabled: true,
        selection: {
            mode: 'single',
        },
        filterRow: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
        stateStoring: {
            enabled: false,
            type: "sessionStorage", // 'custom' | 'localStorage' | 'sessionStorage'
            storageKey: "statepersistanceKey",
            savingTimeout: 3000
        },
        columns: [
            {
                dataField: "productId",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productName",
                dataType: "string",
                alignment: "right"
            },
            {
                dataField: "productCategory",
                dataType: "string",
                alignment: "right"
            },
            {
                dataField: "productPrice",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productRating",
                dataType: "number",
                alignment: "right"
            },
            {
                dataField: "productStock",
                dataType: "number",
                alignment: "center"
            }
        ],
    }).dxDataGrid("instance");

    // Save the grid state to 
    $("#saveState").dxButton({
        text: "save state",
        onClick: function(){
            const stateData = dataGrid.state();
            localStorage.setItem("statepersistanceKey", JSON.stringify(stateData)); 
            DevExpress.ui.notify("State Saved", "success", 2000);
        }
    });

    // Load the grid state from 
    $("#loadState").dxButton({
        text: "load state",
        onClick: function(){
            const stateData = localStorage.getItem("statepersistanceKey");
            if (stateData) {
                dataGrid.state(JSON.parse(stateData));
                DevExpress.ui.notify("State Loaded", "default", 2000);
            } else {
                DevExpress.ui.notify("No saved state found", "error", 2000);
            }
        }
    });
});
