$(document).ready(function(){
    console.log("doc is ready");


    const loadPanel = $("#PanelContainer").dxLoadPanel({
        message: "Loading data, please wait...", 
        visible: false,                        
        showIndicator: true,                    
        width: 500,                             
        height: 500,                            
        position: { my: "center", at: "center", },  
        animation: { show: { type: "fade",}, hide: { type: "fade",  } } ,
        showPane:true,
        //shadingColor:"rgba(255, 99, 71, 0.5)",
    }).dxLoadPanel("instance");

    // On Button Click
    $("#loadButton").dxButton({
        text: "Load Data",
        onClick: function () {
            loadPanel.option("visible", true);  
            setTimeout(function () {
                //loadPanel.option("visible", false); 
                loadPanel.hide()
                dataProductGrid.option("visible",true)
               //dataProductGrid.show()
            }, 3000);
            
        }
    });

 const dataProductGrid =   $("#ProductContainer").dxDataGrid({
        dataSource:products,
        // starting false after true set in button click
        visible:false
    }).dxDataGrid("instance")
})