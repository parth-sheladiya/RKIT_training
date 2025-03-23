window.jsPDF = window.jspdf.jsPDF;

$(document).ready(function(){
    console.log("doc is ready");

    $("#PdfContainer").dxDataGrid({
        dataSource:productData,
        showBorders: true,
        wordWrapEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        selection: {
            mode: 'multiple',
        },
        paging:{
            pageSize:5
        },
        pager:{
            visible:true
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
                alignment:"center",
                allowExporting:false

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
            formats: ['pdf'],
            allowExportSelectedData:true
        },
        onExporting(e){
            const doc = new jsPDF();

            DevExpress.pdfExporter.exportDataGrid({
                jsPDFDocument:doc,
                component:e.component,
                indent:4,
            }).then(()=>{
                doc.save("product.pdf")
            })
        }

    })
})