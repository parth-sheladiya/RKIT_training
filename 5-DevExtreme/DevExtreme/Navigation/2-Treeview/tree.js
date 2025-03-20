$(document).ready(function(){
    console.log("doc is ready");

    var basicData = [
        {
            id: 1, 
            parentId: 0, 
            name: "Root Node", 
            //expanded: true,
            items: [
                { 
                    id: 2, 
                    parentId: 1, 
                    name: "Child Node 1",
                    //expanded:true,
                    items:[
                       {
                        id:21,
                        parentId:12,
                        name:"grand chaild 1",
                        expanded:true,
                       },
                       {
                        id:22,
                        parentId:13,
                        name:"grand chaild 1",
                        disabled:true
                       }

                    ] 
                },
                { id: 3, parentId: 1, name: "Child Node 2" ,}//expanded: false
            ]
        },
        {
            id:211,
            name:"root node 2"
        }
    ];

    // create tree view 
    $("#BasicTreeContainer").dxTreeView({
        dataSource:peripheralData,
        displayExpr:"name", //id  parentId name
        parentIdExpr:"parentId",
        expandAll:false,
        //collapsing and expand 
        animationEnabled:true,
        // check ui
        // default tree 
        dataStructure:"tree" ,  //  'plain' | 'tree'
        disabled:false,
        elementAttr: {
            id: "treeViewElement",  
            class: "custom-class"  
        },
        // hot key * press and hove then check it 
        expandAllEnabled: true,
        //expandedExpr: "expanded",
        expandEvent: "dblClick",  // 'dblclick' | 'click'
        // please go to data source and exapanded true or not then check recursive 
        // id:21,
        // parentId:12,
        // name:"grand chaild 1",
        // expanded:true,
        // doubt clear 
        expandNodesRecursive:true,
        height: "5000px",
        hint: "Select node",
        itemHoldTimeout:12000,
        noDataText:"no entry",
        
        onContentReady:() =>{
            DevExpress.ui.notify(`content is ready`,"info",4000)
        },
        onInitialized:()=>{
            console.log("tree initialized")
        },
        onItemClick:(e)=>{
            console.log("e item click ", e.itemData);
            DevExpress.ui.notify(`you click ${e.itemData.name}`,"info",4000)
        },
        onItemCollapsed:(e)=>{
            console.log("e", e.itemData.name);
            DevExpress.ui.notify(`collapse ${e.itemData.name}`,"info",4000)
        },
        // right click
        onItemContextMenu:(e)=>{
            console.log("e context", e.itemData.name);
            DevExpress.ui.notify(`context menu ${e.itemData.name}`,"info",4000)
        },
        onItemExpanded:(e)=>{
            console.log("e expand", e.itemData.name);
            DevExpress.ui.notify(`expand menu ${e.itemData.name}`,"success",4000)
        },
        onItemHold:(e)=>{
            console.log("e hold", e.itemData.name);
            DevExpress.ui.notify(`hold item ${e.itemData.name}`,"success",4000)
        },
        onItemRendered:(e)=>{
            console.log("e rendered", e.itemData.name);
        },
        onItemSelectionChanged: (e) =>{
            console.log(`Selection changed: ${e.itemData.name}`)
        },
        onSelectAllValueChanged: (e) =>
        {
            // console.log(`Select All value changed: ${e.value}`)
            alert("hii")
        },
        onSelectionChanged:(e)=>{
            console.log(e);
            // alert("hi");
            let a = e.component.getSelectedNodes();
            console.log(a);
        },
        
        scrollDirection :"horizontal", //'both' | 'horizontal' | 'vertical'
        searchEnabled: true,
        searchEditorOptions: { placeholder: "Search..." , width:"100px"},
        searchMode:"startswith" , //  'contains' | 'startswith' | 'equals'
        searchExpr: "name",
        searchTimeout:3000,
       // searchValue:"search ",
       selectAllText:"select all",
       selectByClick:true,
       showCheckBoxesMode:"selectAll", // : 'none' | 'normal' | 'selectAll'
       selectNodesRecursive:true,
       virtualModeEnabled: true, 
       visible:true,
        selectionMode: "single"  // 'multiple' | 'single'
    })

    // $("#practice").dxTreeView({
    //     dataSource:treeData,
    //     displayExpr:"text",
    //     parentIdExpr:"parentId",
    //     dataStructure: "plain",
    //     // keyExpr: "id",
    // })

})


// ++ accessKey
// + activeStateEnabled
// + animationEnabled
//  createChildren - if user can expand node then call create children fun and load child data 
// data source : datatype array,url,store,object


