$(document).ready(function() {
    console.log("docs is ready");

    $("#LookupContainer").dxDataGrid({
        dataSource: cities,
        showBorders: true,
        editing: {
            allowUpdating: true,
            allowAdding: true,
            mode: "row",
        },
        onEditorPreparing(e) {
            // Disable City when State is not selected
            if (e.parentType === "dataRow" && e.dataField === "CityID") {
                const ifNotSetState = e.row.data.StateID === undefined ;
                e.editorOptions.disabled = ifNotSetState;
            }

            // Disable State when Country is not selected
            if (e.parentType === "dataRow" && e.dataField === "StateID") {
                const ifNotSetCountry = e.row.data.CountryID === undefined || e.row.data.CountryID === null;
                e.editorOptions.disabled = ifNotSetCountry;

                // Filter State based on Country selection
                if (e.row.data.CountryID) {
                    e.editorOptions.dataSource = states.filter(
                        (state) => state.CountryID === e.row.data.CountryID
                    );
                } else {
                    e.editorOptions.dataSource = states;
                }
            }
        },
        columns: [
            {
                dataField: "CountryID",
                caption: "Country",
                setCellValue(rowData, value) {
                    rowData.CountryID = value;
                    rowData.StateID = null;
                    rowData.CityID = null;
                },
                lookup: {
                    dataSource: countries,
                    valueExpr: "CountryID",
                    displayExpr: "CountryName"
                }
            },
            {
                dataField: "StateID",
                caption: "States",
                setCellValue(rowData, value) {
                    rowData.StateID = value;
                    rowData.CityID = null;
                },
                lookup: {
                    dataSource: states,
                    valueExpr: "StateID",
                    displayExpr: "StateName"
                }
            },
            {
                dataField: "CityID",
                caption: "Cities",
                lookup: {
                    dataSource(options) {
                        if (!options.data || !options.data.StateID) {
                            return cities;
                        }
                        return {
                            store: cities,
                            filter: ["StateID", "=", options.data.StateID],
                        };
                    },
                    valueExpr: "CityID",
                    displayExpr: "CityName",
                },
            }
        ],

        // Success Notification when a new row is added
        onRowInserted() {
            DevExpress.ui.notify("Data successfully added!", "success", 3000);
        },

        // Success Notification when an existing row is updated
        onRowUpdated() {
            DevExpress.ui.notify("Data successfully updated!", "success", 3000);
        }
    });
});

