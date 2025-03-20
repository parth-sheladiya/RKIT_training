$(document).ready(function(){
    console.log("doc is ready");
    // create menu
    $("#MenuContainer").dxMenu({
        dataSource:foodData,
        adaptivityEnabled:false,
        width: 40,
        //displayExpr:"name",
        displayExpr: function(res){
            return `${res.id} ${res.name} `
        },
        animation: {
            hide:{ type: 'fade', from: 1, to: 0, duration: 1000 },
            show:{ type: 'fade', from: 0, to: 1, duration: 1000 }
        },
        
        // we can disabled specific menu
        // go to data and then data disabled
        disabled:false,
        // disabledExpr:function(e){
        //     console.log("e" ,e);
        //     return this.price<3
        // },
        elementAttr:{
            id:"MenuID",
            class:"MenuClass"
        },
        hideSubmenuOnMouseLeave:true,
        orientation:"horizontal",  // 'horizontal' | 'vertical'
        showFirstSubmenuMode:"onHover", //onClick 
        showSubmenuMode:"onClick", //  'onClick' | 'onHover'
        submenuDirection:"auto", // 'auto' | 'leftOrTop' | 'rightOrBottom'
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
            console.log("item render che",e);
            
            console.log("item render" , e.itemData)
            
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
         
    })
})