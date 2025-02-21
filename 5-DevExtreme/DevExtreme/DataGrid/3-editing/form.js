$(document).ready(function(){
    console.log("docs is ready");

    const dataAgriculture = new DevExpress.data.CustomStore({
        key:"id",
        loadMode: "raw",
        load : ()=> {
           return $.ajax({
                url: "https://67b706ff2bddacfb270d5737.mockapi.io/agriculter/dataagri",
                type: "GET",
                dataType: "json",
                success: function(result) {
                    console.log("Data Loaded: ", result); 
                },
                error: function(xhr, status, error) {
                    console.error("Error loading data:", error); 
                }
            });
            
        },

        update : (key ,dataAgriculture) =>{
            return $.ajax({
                url:`https://67b706ff2bddacfb270d5737.mockapi.io/agriculter/dataagri/${key}`,
                data:dataAgriculture,
                method:"PUT",
                dataType:"json"
            }).then(result => {
                DevExpress.ui.notify("Data successfully update!", "success", 3000);
                return result;
            });
        },

        insert : (dataInsert)=>{
            return $.ajax({
                url: "https://67b706ff2bddacfb270d5737.mockapi.io/agriculter/dataagri",
                data:dataInsert,
                method:"POST",
                dataType:"json"
            }).then(result => {
                DevExpress.ui.notify("Data successfully inserted!", "success", 3000);

                return result; 
            });
        },

        remove :(key)=>{
            return $.ajax({
                url:`https://67b706ff2bddacfb270d5737.mockapi.io/agriculter/dataagri/${key}`,
                method:"DELETE",
                dataType:"json"
            }).then(result => {
                DevExpress.ui.notify("Data successfully Deleted!", "success", 3000);
                return result; 
            });
        }
    });


    $("#FormContainer").dxDataGrid({
        dataSource:dataAgriculture,
        showBorders:true,
        height:600,
        columns:[
            {
                allowEditing:false,
                dataField:"id",
                dataType:"string"
            },
            {
                dataField:"crop_type",
                dataType:"string"
            },
            {
                dataField:"planting_date",
                dataType:"date"
            },
            {
                dataField:"growth_stage",
                dataType:"string"
            },
            {
                dataField:"expected_yield",
                dataType:"number"
            },
            {
                dataField:"crop_health_status",
                dataType:"string"
            }
        ],
        pager: {
            visible: true,
          },
          editing:{
            mode:"popup", // cell , batch , row , form , popup
            // updateting 
            allowUpdating:true,
            // icons show by vdefault falase
            useIcons:true,
            // adding true
            allowAdding:true,
            // delete true
            allowDeleting:true,
            //select all text when you click by default false
            // it is not work for form and popup
            selectTextOnEditStart:true,
            // are you sure ? by default true
            confirmDelete:true,
            // click dbl click
            startEditAction:"dblClick",


            form:{
                items:[
                    {
                        itemType:"group",
                        caption:"crop_health",
                        validationRules: [
                            {
                                type: "required",
                                message: "crop_health_status is required"
                            }
                        ],
                        items:[
                            {
                                dataField:"id"
                            },
                            {
                                dataField:"crop_type"
                            },
                            {
                                dataField:"planting_date"
                            },
                            {
                                dataField:"growth_stage"
                            },
                            {
                                dataField:"expected_yield"
                            },
                            {
                                dataField:"crop_health_status",
                                editorType:"dxSelectBox",
                                editorOptions:{
                                    items:[
                                        "Healthy",
                                        "Diseased",
                                        "Stressed",
                                        "Damaged"
                                    ],
                                    // not working 
                                    value:"Healthy"
                                },
                            }
                        ]
                    }
                ]
            }
        },
    })

})