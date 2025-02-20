$(document).ready(function(){
    console.log("docs is ready");

    const dataPosts = new DevExpress.data.CustomStore({
        key:"id",
        loadMode: "raw",
        load : ()=> {
            return $.ajax({
                url: "https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi",
                dataType: "json",
                method: "GET"
            }).then(result => {
                return result; 
            });
        },

        update : (key ,postdata) =>{
            return $.ajax({
                url:`https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi/${key}`,
                data:postdata,
                method:"PUT",
                dataType:"json"
            }).then(result => {
                return result;
            });
        },

        insert : (dataInsert)=>{
            return $.ajax({
                url: "https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi",
                method:"POST",
                dataType:"json",
                data:dataInsert,
            }).then(result => {
                return result; 
            });
        },

        remove :(key)=>{
            return $.ajax({
                url:`https://67b3100abc0165def8cfc105.mockapi.io/productapi/productapi/${key}`,
                method:"DELETE",
                dataType:"json"
            }).then(result => {
                return result; 
            });
        }
    })

    $("#EditingContainer").dxDataGrid({
        dataSource:dataPosts,
        showBorders:true,
        height:500,
        columns: [
            {
                dataField: "id",
                dataType: "number"
            },
            {
                dataField: "name",
                dataType: "string",
            },
            {
                dataField: "price",
                dataType: "number"
            },
        ],
        pager: {
            visible: true,
          },
        editing:{
            mode:"row", // cell , batch , row , form , popup
            // updateting 
            allowUpdating:true,
            // icons show by vdefault falase
            useIcons:true,
            // adding true
            allowAdding:true,
            // delete true
            allowDeleting:true,
            //select all text when you click by default false
            selectTextOnEditStart:true,
            // are you sure ? by default true
            confirmDelete:true,
           
        },
        // ddata event
        onEditingStart: function() {
            //  editing starts then shoe columnm name 
            console.log("Editing started in column: ",); 
        },
        // onEditCanceled call after cancelling
        onEditCanceled: function() {
            console.log("Changes discarded");
        },
        // first call
        onEditCanceling:function(){
            console.log("canceling start");
        },
        // it is count toatal column then prepare edit process. check console.log
        onEditorPrepared:function(){
            console.log("edit prepared");
        },
        // first call before prepared call
        onEditorPreparing:function(){
            console.log("preparing ");
        },
        // if you click add butoon then trigger
        onInitNewRow:function(){
            console.log("new row")
        },
        // if fill details then save changes then event trigger
        onRowInserting:function(){
            console.log("on row inserting")
        },
        // after trigger inserting row
        onRowInserted:function(){
            console.log("row inserted");
        },
        // first trigger befre updated starting phase
        onRowUpdating:function(){
            console.log("row updating");
        },
        // after trigger updating
        onRowUpdated:function(){
            console.log("row updaaed successfully");
        },
        // row deleting
        onRowRemoving:function(){
            console.log("row removing");
        },
        // row deleted
        onRowRemoved:function(){
            console.log("row removed");
        },
        // first trigger
        onSaving:function(){
            console.log("row saving");
        },
        // after trigger on saving
        onSaved:function(){
            console.log("row saved successfully");
        },
        // edit canceling
        onEditCanceling:function(){
            console.log("edit canceling");
        },
        // edit cancelled
        onEditCanceled:function(){
            console.log("edit canceled");
        },
        // option   please check how to work rowfocus columnfocus
        onOptionChanged:function(data){
            console.log("option changed" , data)
        }
    })
})