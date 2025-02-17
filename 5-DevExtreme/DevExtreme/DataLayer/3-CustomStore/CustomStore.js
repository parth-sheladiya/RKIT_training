$(document).ready(function() {
    const mockApiUrl = "https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi";

    // Initialize CustomStore
    var customStore = new DevExpress.data.CustomStore({
        key: "id", 
        load: function (loadOptions) {
            console.log("Load Options:", loadOptions);
            let params = {};

            // Handling Sorting
            if (loadOptions.sort) {
                params._sort = loadOptions.sort[0].selector;
                params._order = loadOptions.sort[0].desc ? "desc" : "asc";
            }

            // Handling Filtering
            if (loadOptions.filter) {
                params._filter = JSON.stringify(loadOptions.filter);
            }

            // Handling Pagination
            if (loadOptions.skip !== undefined) {
                params._start = loadOptions.skip;
            }
            if (loadOptions.take !== undefined) {
                params._limit = loadOptions.take;
            }

            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                data: params,
                dataType: "json"
            });
        },
        loadMode: 'raw', 

        byKey: function (key) {
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "GET",
                dataType: "json"
            });
        },

        // Insert a new record
        insert: function (values) {
            console.log("Inserting:", values);
            return $.ajax({
                url: mockApiUrl,
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        // Update an existing record
        update: function (key, values) {
            console.log("Updating:", key, values);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "PUT",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        remove: function (key) {
            console.log("Removing:", key);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "DELETE"
            });
        },

        totalCount: function (loadOptions) {
            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                dataType: "json"
            }).then(data => data.length);
        },

        errorHandler: function (error) {
            console.error("CustomStore Error:", error);
            alert("An error occurred while processing the request.");
        },
        useDefaultSearch: true
    });

    // Function to fetch and render the data
    function fetchData() {
        customStore.load({
            skip: 0, 
            take: 5,
            sort: [{ selector: "productPrice", desc: true }],
        }).done(function (data) {
            renderTable(data);
        }).fail(function (error) {
            console.error("Load Error:", error);
        });
    }

    // Function to render the table
    function renderTable(data) {
        console.log("Rendering data:", data);
        var tableBody = $("#dataTable tbody");
        tableBody.empty(); // Clear existing rows
        
        if (data.length > 0) {
            data.forEach(function (item) {
                var row = $("<tr>")
                    .append($("<td>").text(item.id))
                    .append($("<td>").text(item.name))
                    .append($("<td>").text(item.price))
                    .append($("<td>").html(`
                        <button class="editButton" data-id="${item.id}">Edit</button>
                        <button class="deleteButton" data-id="${item.id}">Delete</button>
                    `));
                tableBody.append(row);
            });
        } else {
            tableBody.append('<tr><td colspan="4">No data available</td></tr>');
        }
    }

    // Show form for adding new data
    $("#addButton").click(function () {
        $("#formContainer").show();
        $("#saveButton").data("action", "add"); // Add action for save
        $("#productId").val(""); // Clear the inputs
        $("#productName").val("");
        $("#productPrice").val("");
    });

    // Handle save button click (both Add and Update)
    $("#saveButton").click(function () {
        var productId = $("#productId").val();
        var productName = $("#productName").val();
        var productPrice = $("#productPrice").val();
        var action = $(this).data("action");

        if (productName && productPrice) {
            var data = { name: productName, price: parseFloat(productPrice) };

            if (action === "add") {
                // Add new record (no id needed if API generates one)
                customStore.insert(data).done(function (newRecord) {
                    // Add the new record to the table directly without refreshing everything
                    renderTable([newRecord]);  // Insert new record directly
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error adding record");
                });
            } else if (action === "update") {
                var id = $(this).data("id");
                // Update existing product
                customStore.update(id, data).done(function () {
                    fetchData(); // Fetch and update the table after update
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error updating record");
                });
            }
        } else {
            alert("Please fill in all fields.");
        }
    });

    // Handle cancel button click
    $("#cancelButton").click(function () {
        $("#formContainer").hide();
    });

    // Edit record
    $(document).on("click", ".editButton", function () {
        var id = $(this).data("id");
        customStore.byKey(id).done(function (data) {
            $("#productId").val(data.id);
            $("#productName").val(data.name);
            $("#productPrice").val(data.price);
            $("#formContainer").show();
            $("#saveButton").data("action", "update").data("id", id);
        }).fail(function () {
            alert("Error fetching record");
        });
    });

    // Delete record
    $(document).on("click", ".deleteButton", function () {
        var id = $(this).data("id");
        customStore.remove(id).done(function () {
            fetchData(); // Fetch and update the table after deletion
        }).fail(function () {
            alert("Error deleting record");
        });
    });

    // Load initial data
    fetchData();
});
