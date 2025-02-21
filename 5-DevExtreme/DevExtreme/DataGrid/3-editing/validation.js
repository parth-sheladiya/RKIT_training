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
    })

    $("#ValidationContainer").dxDataGrid({
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
                validationRules: [
                    {
                        type: "required",
                        message: "crop_type is required"
                    }
                ],
                dataType:"string"
            },
            {
                dataField:"planting_date",
                validationRules: [
                    {
                        type: "required",
                        message: "planting_date is required"
                    },
                    {
                        type: "custom",
                        validationCallback: function (e) {
                        // Get today's date in YYYY-MM-DD format
                        const currentDate = new Date();
                        const inputDate = new Date(e.value);

                        // Compare the entered date with current date
                            if (inputDate > currentDate) {
                                return false;
                            }
                            return true;
                        },
                         message: "Planting date cannot be in the future"
                    }
                ],
                dataType:"date"
            },
            {
                dataField:"growth_stage",
                validationRules: [
                    {
                        type: "required",
                        message: "growth_stage is required"
                    },
                    {
                        type: "stringLength",
                        min: 3,
                        message: "growth_stage at least have 3 letters",
                    }
                ],
                dataType:"string"
            },
            {
                dataField:"expected_yield",
                dataType:"number",
                validationRules: [
                    {
                        type: "required",
                        message: "expected_yield is required"
                    }
                ],
                
            },
            {
                dataField:"crop_health_status",
                validationRules: [
                    {
                        type: "required",
                        message: "crop_health_status is required"
                    }
                ],
                dataType:"string"
            }
        ],
        pager: {
            visible: true,
          },
          editing:{
            mode:"form", // cell , batch , row , form , popup
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
            startEditAction:"dblClick"
        },
    })
})