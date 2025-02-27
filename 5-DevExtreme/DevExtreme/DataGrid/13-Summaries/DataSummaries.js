$(document).ready(function(){
    console.log("doc is ready");

    $("#DataSummariesContainer").dxDataGrid({
        dataSource:productData,
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        paging:{
            pageSize:5
        },
        // dont break string if true
        wordWrapEnabled: true,
        columns:[
            {
                dataField:"ID",
                caption:"Product ID",
                dataType:"number",
                alignment:"center"
            },
            {
                dataField:"Name",
                dataType:"string",
                caption:"Product Name",
                alignment:"center"
            },
            {
                dataField:"Category",
                dataType:"string",
                caption:"Product Category",
                alignment:"center"
            },
            {
                dataField:"Rating",
                dataType:"number",
                caption:"Product Rating",
                alignment:"center",
                
            },
            {
                dataField:"Price",
                dataType:"number",
                caption:"Product Price",
                alignment:"center"
            },
            {
                dataField:"Date",
                dataType:"date",
                caption:"Manufacturing Date",
                alignment:"center"
            },
        ],
        summary:{
            /// use global level
            // texts:{
            //     sum:"total sum"
            // },
            totalItems:[
                {
                    column:"ID",
                    summaryType:"count",
                    displayFormat:"Total Product : {0}"
                },
                {
                    column:"Name",
                    summaryType:"sum",
                    //skipEmptyValue:false
                },
                {
                    column:"Rating",
                    summaryType:"avg",
                    customizeText(CustomName) {
                        return `Avg Rating : ${CustomName.value}`;
                    },
                    
                },
                {
                    column:"Price",
                    summaryType:"sum",
                    customizeText: function (data) {
                        return `Total Product Price: ${data.value.toFixed(2)}`; // Showing average price with 2 decimal places
                    }
                },
                {
                    column:"Price",
                    summaryType:"avg",
                    customizeText: function (data) {
                        return `Avg Price: ${data.value.toFixed(2)}`; // Showing average price with 2 decimal places
                    }
                },
                {
                    column:"Price",
                    summaryType:"max",
                    
                },
                {
                    column:"Price",
                    summaryType:"min"
                },
                {
                    column:"Date",
                    summaryType:"max"
                }

            ]
        },
        
    })

})