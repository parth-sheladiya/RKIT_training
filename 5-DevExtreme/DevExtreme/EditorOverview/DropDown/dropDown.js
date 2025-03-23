$(document).ready(function () {
    var productName = ["AC", "Led tv", "watch", "shoes", "laptop" , "mobile" ];

  let dropdowninst=   $("#dropDownBox").dxDropDownBox({
        // value: "names", 
        placeholder: "Select a value",
        acceptCustomValue: true,   
        disabled: false,
        readonly: false,
        hint: "This is a dropdown box",
        height: "100px",
        width: "1000px",
        
        buttons:[
            {
                // use is imp
                name:"hello",
                location:"before",
                
                options:{
                    text:"Reset",
                    onClick:()=>{
                        dropdowninst.reset();
                        // dropdowninst.option("value",false)
                    }
                }
            }
        ],
        stylingMode: "outlined",
       
        // when it is use then must be use dx text box
        fieldTemplate:function(value,container){
            let textBox = $("<div>").dxTextBox({
                value: value || "Select an option",
                readOnly: true, 
                stylingMode: "outlined",
                
            });
            textBox.appendTo(container);

            // setTimeout(function(){
            //     dropdowninst.option("visible",false)
            // },5000)
        },
        dropDownButtonTemplate: function() {
            return $("<div>").append(
                $("<img>", {
                    src: "download.jpg", 
                    width: 30, 
                    height: 80  
                })
            );
        },
        contentTemplate: function (e) {
           var list = $("<div>").dxList({
               // data
               items: productName,
               selectionMode: "multiple", // single multiple
               showSelectionControls: true,
               
               onSelectionChanged: function (args) {
                   var selectedItems = args.component.option("selectedItems");
                   console.log("select value is ", selectedItems)

                   // selected items are displayed in the dropdownbox
                   dropdowninst.option("value", selectedItems.join(", "));
               }
           });
           return list;
        },
        //// ?????????
        // not working
        // items:names,
        //dataSource: productName,

        onClosed: function () {
            console.log("Dropdown closed");
        },
        // doubt
        //valueChangeEvent: "input",
        onValueChanged: function (e) {
            
            console.log("Previous value: ", e.previousValue); // Before selection change
            console.log("New value: ", e.value);
        },

        hoverStateEnabled: true,
        showClearButton: false,
        // custom buton comment then work it
        showDropDownButton: true
    }).dxDropDownBox("instance");
    // check button name above 
    // plaease chek and after process
    let mycustBtn = dropdowninst.getButton("hello")
    console.log("mybtn",mycustBtn);
    // mycustBtn.dispose();
    mycustBtn.option("disabled",true);

    console.log("simple inst",dropdowninst.instance())
    console.log("all option", dropdowninst.option())
    console.log("hello get inst",dropdowninst.getDataSource())
});
