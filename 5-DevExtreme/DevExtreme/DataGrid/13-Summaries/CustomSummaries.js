$(document).ready(function(){
    console.log("doc is ready");
    
    $("#CustomContainer").dxDataGrid({
        dataSource:productData,
        showBorders:true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        wordWrapEnabled: true,
        keyExpr: 'ID',
        selection: {
            mode: 'multiple',
            showCheckBoxesMode: "always",
        allowSelectAll: false,
         deferred: true,
        },
        paging:{
            pageSize:6
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
        onSelectionChanged(e) {
            e.component.refresh(true);
          },
        summary:{
            totalItems:[
                {
                    name:"TotalProductSumCalculate",
                    showInColumn:"Price",
                    displayFormat:"sum of Selected product :{0}",
                    summaryType:"custom"
                },
                {
                    name:"avgCalculate",
                    showInColumn:"Rating",
                    displayFormat:"avg of selected Rating:{0}",
                    summaryType:"custom"
                }
            ],
            calculateCustomSummary(options){
                if(options.name==="TotalProductSumCalculate"){
                    if(options.summaryProcess ==="start"){
                        options.totalValue=0;
                    }
                    if(options.summaryProcess  === "calculate"){
                        if(options.component.isRowSelected(options.value)){
                            options.totalValue += options.value.Price;
                            console.log("Selected row ID: " + options.value + " Price: " + options.value.Price);
                            console.log("hi")
                        }
                    }
                    if(options.summaryProcess === "finalize"){
                        options.totalValue = options.totalValue.toFixed(2);
                    }

                };
                if(options.name === "avgCalculate"){
                    if(options.summaryProcess === "start"){
                        options.totalValue=0;
                        options.SelectedRowCount=0;
                    }
                    if(options.summaryProcess === "calculate"){
                        if(options.component.isRowSelected(options.value)){
                            options.totalValue += options.value.Rating;
                            options.SelectedRowCount++;
                        }              
                    }
                    if(options.summaryProcess === "finalize"){
                        if(options.SelectedRowCount>0){
                            options.totalValue = (options.totalValue/options.SelectedRowCount);
                            options.totalValue = options.totalValue.toFixed(2);
                        }
                        else{
                            options.SelectedRowCount=0;
                        }
                    }
                }
            },
        

        }
    })
    
})