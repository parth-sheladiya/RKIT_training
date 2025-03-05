$(document).ready(function(){
    console.log("doc is ready");

    $("#MenuContainer").dxMenu({
        dataSource:foodData,
        accessKey:"k",
        activeStateEnabled:true,
        adaptivityEnabled:true,
        //width: 10,
        displayExpr:"name",
        animation: {
            hide:{ type: 'fade', from: 1, to: 0, duration: 4000 },
            show:{ type: 'fade', from: 0, to: 1, duration: 3000 }
        },
        
        // we can disabled specific menu
        // go to data and then data disabled
        disabled:false,
        disabledExpr:function(e){
            console.log("e" ,e);
            return this.price<3
        },
        elementAttr:{
            id:"MenuID",
            class:"MenuClass"
        },
        //height:"800px"
        hideSubmenuOnMouseLeave:true,
        orientation:"horizontal",  // 'horizontal' | 'vertical'
        showFirstSubmenuMode:"onClick", //onClick
        showSubmenuMode:"onClick", //  'onClick' | 'onHover'
        submenuDirection:"rightOrBottom", // 'auto' | 'leftOrTop' | 'rightOrBottom'
        // itemTemplate: function(itemData, itemIndex, itemElement){
        //     console.log("hi",itemData);
        //     itemElement.append(`${itemData.id} and ${itemData.name}`)
        // }
        onItemClick:function(e){
            console.log("e", e.itemData.name);
            DevExpress.ui.notify(`you click ${e.itemData.name}`,"info",4000)
        },
        onItemContextMenu:function(e){
            console.log("you right  click on", e.itemData.name);
            DevExpress.ui.notify(`you right  click on ${e.itemData.name}`,"info",4000)
        },
        onItemRendered: (e) => {
            console.log("item render",e);
            
            console.log("item render" , e.itemData)
            
        },
        onSelectionChanged: function(e) {
            // Check selected item info
            console.log("Selected Item: ", e.itemData);
            DevExpress.ui.notify(`Selected item: ${e.selectedItem ? e.selectedItem.name : "None"}`, "info", 4000);
        },
            onSubmenuHidden: () => {
            console.log("Sub Menu Is Hidden");
          },
          onSubmenuHiding: () => {
            console.log("Sub Menu Is Hiding");
          },
          onSubmenuShowing: () => {
            console.log("Sub Menu Is Showing");
          },
          onSubmenuShown: () => {
            console.log("Sub Menu Is Shown");
          },
          selectByClick:false,
          selectionMode :"single"    //'none' | 'single'
    })
})