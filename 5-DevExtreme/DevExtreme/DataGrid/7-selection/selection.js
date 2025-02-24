$(document).ready(function(){
    console.log("docs is ready");



    $("#SelectionContainer").dxDataGrid({
        dataSource:products,
        showBorders:true,
        paging: {
            pageSize: 7,
        },
        columns:[
            {
                dataField:"productId",
                dataType:"number",
            },
            {
                dataField:"productName",
                dataType:"string",
            },
            {
                dataField:"productCategory",
                dataType:"string",
            },
            {
                dataField:"productPrice",
                dataType:"number",
            },
            {
                dataField:"productRating",
                dataType:"number",
            },
            {
                dataField:"productStock",
                dataType:"number",
            }
        ],
        selection: {
            mode: 'multiple', // single , multiple , none
            allowSelectAll:true, // default
            showCheckBoxesMode:"always", // onclick , onlongtap,always,none
            selectAllMode:"page" //allPages , page
        },
        editing:{
            allowUpdating:true,
            allowDeleting:true,
        },
        onSelectionChanged(e) {
            selectedProducts = e.selectedRowsData; // Store all selected rows in selectedProducts
            console.log("Selected Products: ", selectedProducts);
        }
    })

    // Initialize dxButton
    $("#editCategoryButton").dxButton({
        text: "Edit Category", // Button text
        type: "success",
        onClick: function() {
            if (selectedProducts.length > 0) {
                const newCategory = prompt("Enter new product category", selectedProducts[0].productCategory);
                if (newCategory) {
                    // Update the category for all selected products
                    selectedProducts.forEach((product) => {
                        product.productCategory = newCategory;
                    });
                    
                    // Refresh the DataGrid to show updated categories
                    $("#SelectionContainer").dxDataGrid("instance").refresh();
                }
            } else {
                alert("No product selected!");
            }
        }
    });
})