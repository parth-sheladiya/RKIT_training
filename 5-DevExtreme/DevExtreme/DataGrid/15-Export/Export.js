$(document).ready(function(){
    console.log("doc is ready");

    $("#ExportContainer").dxDataGrid({
        dataSource:productData,
        paging:{
            pageSize:7
        },
        showBorders: true,
        wordWrapEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        selection: {
            mode: 'multiple',
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
        export:{
            enabled:true,
            allowExportSelectedData:true
        },
        onExporting(e){
            // it is create new workbook using exceljs library
            const workbook = new ExcelJS.Workbook();
            // then add worksheet in workbook
            // productData is data source name
            const worksheet=workbook.addWorksheet("productData");

            // call export data grid and data export inexcel sheet
            DevExpress.excelExporter.exportDataGrid({
                // data grid component
                component:e.component,
                // data add in worksheet
                worksheet,
                // automatic filter in excel sheet
                autoFilterEnabled:true,
            }).then(()=>{
                // workbook data store in buffer memory 
                // convert workbook to buffer
                workbook.xlsx.writeBuffer().then((buffer)=>{
                    // buffer convert to blob binary large object
                    saveAs(new Blob([buffer],{
                        type: 'application/octet-stream'
                    }),
                    // file name 
                    "productData.xlsx")
                })
            })
        }

    })

})