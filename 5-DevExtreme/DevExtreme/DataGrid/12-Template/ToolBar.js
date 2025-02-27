$(document).ready(function () {
    console.log("docs is ready");

    var gridInstance = $("#ToolbarContainer").dxDataGrid({
        dataSource: orders,
        keyExpr: "ID",
        showBorders: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        columnAutoWidth: true,
        loadPanel: {
            enabled: true
        },
        columns: [
            {
                dataField: "OrderNumber",
                dataType: "number",
                caption: "Order number"
            },
            {
                dataField: "OrderDate",
                // dataType:"date",
                caption: "Order date"
            },
            {
                dataField: "Employee",
                dataType: "string",
                caption: "Employee Name"
            },
            {
                dataField: "TotalAmount",
                dataType: "number",
                caption: "Total Amount"
            },
            {
                dataField: "SaleAmount",
                dataType: "number",
                caption: "Sale Amount"
            }
        ],
        // filterPanel: {
        //     visible: true,
        // },
        onToolbarPreparing: function (e) {
            console.log("e is", e);
            console.log("e.component is ", e.component);
            console.log("component name is ", e.component.NAME)
            var toolItems = e.toolbarOptions.items;
            var dataGrid = e.component;
            console.log(toolItems);

            toolItems.push(
                {
                    widget: "dxButton",
                    location: "after",
                    options:{
                        text:"order 2013",
                        onClick: function () {
                            // Find the latest order based on the OrderDate
                            var orders2013 = orders.filter(function (order) {
                                var orderDate = new Date(order.OrderDate);
                                DevExpress.ui.notify("2013 order", "success", 500);
                                return orderDate.getFullYear() === 2013;
                                
                            });
    
                            // Update the grid to show only the filtered orders
                            dataGrid.option("dataSource", orders2013);
    
                        },
                    },
                    
                }
            );
            toolItems.push(
                {
                    widget: "dxButton",
                    options: {
                        text: "popup",
                        onClick: function () {
                            gridInstance.option("editing.mode", "popup");
                            DevExpress.ui.notify("success", "success", 500);
                        },
                    },
                    location: "before",
                }
            );
            toolItems.push(
                {
                    widget: "dxButton",
                    options: {
                        text: "Higest Total Amount",
                        onClick: function () {
                            var highestOrder = orders.reduce(function(prev, current) {
                                DevExpress.ui.notify("highest total amount fetch successfully", "success", 500);
                                return (prev.TotalAmount > current.TotalAmount) ? prev : current;
                            });
    
                            // Update the grid to only show the order with the highest TotalAmount
                            dataGrid.option("dataSource", [highestOrder]);
                        },
                    },
                    //location: "before",
                }
            )


        }



    }).dxDataGrid("instance");

})