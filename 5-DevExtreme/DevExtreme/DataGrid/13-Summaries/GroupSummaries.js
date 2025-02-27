$(document).ready(function(){
    console.log("docs is ready");


    $("#GroupContainer").dxDataGrid({
        dataSource:productData,
        showBorders:true,
        paging:{
            enabled: true,
            pageSize:15
        },
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        allowColumnReordering: true,
        selection: {
            mode: 'single',
          },
        groupPanel: {
            visible: true,
          },
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
        grouping: {
            allowCollapsing: true,
            autoExpandAll: true,
            contextMenuEnabled: true,
            expandMode: "rowClick", // button click
          },
          sortByGroupSummaryInfo: [{
            summaryItem: 'count',
          }],
          summary:{
            groupItems:[
                {
                    column:"Category",
                    summaryType:"count",
                    showInGroupFooter:true,
                    alignByColumn: true,
                    displayFormat:"{0}",
                    customizeText(itemInfo) {
                        return `Total Category : ${itemInfo.value}`;
                      },
                },
                {
                    column:"Rating",
                    summaryType:"avg",
                 //showInGroupFooter:true,
                    displayFormat:"avg rating {0}",
                    customizeText: function (data) {
                        return `Total Product Rating: ${data.value.toFixed(2)}`; 
                    }
                },
                {
                    column:"Price",
                    summaryType:"sum",
                    showInGroupFooter:true,
                    displayFormat:" Total Price {0}"
                },
                {
                    column:"Price",
                    summaryType:"avg",
                    showInGroupFooter:true,
                    displayFormat:" avg Price {0}",
                    customizeText: function (data) {
                        return `Total Product Price: ${data.value.toFixed(2)}`; 
                    }
                },
                {
                    column:"Price",
                    summaryType:"max",
                    showInGroupFooter:true,
                    displayFormat:" max Price {0}"
                },
                {
                    column:"Price",
                    summaryType:"min",
                    showInGroupFooter:true,
                    displayFormat:" min Price {0}"
                }
            ]
          }
    })
})