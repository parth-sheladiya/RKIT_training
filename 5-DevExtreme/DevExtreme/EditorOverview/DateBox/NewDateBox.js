

$(document).ready(function () {

    console.log("document is ready ");

  let dateInst =  $("#dateBox").dxDateBox({
        //type time
        type: "date",
        // show on field
         value: new Date(),
        // show on format in field
        displayFormat: "MMM dd, yyyy",
        
        //showDropDownButton: false,
        // invalid mess  if user enter invalid format date
        invalidDateMessage: "Invalid Date formate please try MMM dd, yyyy format",
        // user enter or not 
        acceptCustomValue: true,
        // keyboard specific
        accessKey: "t",
        // ok button text
        applyButtonText: "👍",
        // cancel button text
        cancelButtonText: "😎",
        // use buttos
        applyValueMode: 'useButtons',// instantly  useButtons
        // /// height
        // height: "55px",
        // // width
        // width: "500px",
        inputAttr: {
            placeholder: "Enter date here",
        },
       maxLength:3,
       // hover then set enable to true
        hoverStateEnabled:true,
        // user only enter format date 
        useMaskBehavior: true,
        buttons: ["clear", "dropDown"],
        // custom 
        dropDownButtonTemplate: function() {
            return $("<div>").append(
                $("<img>", {
                    src: "download.jpg", 
                    width: 30, 
                    height: 50  
                })
            );
        },
        validationMessageMode: "popover", // "auto", "always", "popover"
        deferRendering: true,
        onOpened: function() {
            alert("Calendar opened!");
        }
        
    }).dxDateBox("instance");

    console.log("date inst field",dateInst.field());
    // create date box instance
    var fDateBoxInstance = $("#dateBox").dxDateBox("instance");
   
    fDateBoxInstance.on("valueChanged", function (e) {
        console.log("Disaplay value is ", e.value);
        
    })
    // content method 
//    fDateBoxInstance.dispose();
    console.log("fboxinst",fDateBoxInstance)
    console.log("field",fDateBoxInstance.field())
    console.log("option",fDateBoxInstance.option());
    console.log("value",fDateBoxInstance.option("value"));
    console.log("text",fDateBoxInstance.option("text"));
    console.log("date box instance is ", fDateBoxInstance.option());
    console.log("value of option ois ", fDateBoxInstance.option("value"));
    fDateBoxInstance.option("opened", true);

    $("#datetimeBox").dxDateBox({
        //type time
        type: "datetime",
        // click on field then show calendar
        showAnalogClock :true,
        showClearButton:false,
        //id: "elementId",
        // max range
        max: new Date(),
        // min range
        min: new Date("11/11/2000"),
        // date out of range mess
        dateOutOfRangeMessage: "date is out of range please valid date",
        // bydefault false
        disabled: false,
        // picker type 
        // native ,rollers, list use to check it
        pickerType: "rollers",  
        // user for date and datetime not use in time 
        disabledDates: [
            new Date(2025, 1, 2), 
            new Date(2025, 1,4), 
            new Date(2025, 2, 1) 
        ],
        // hove then showhint
        hint: "this is datetimer format ",
        // place holder
        placeholder: "20/11/2003 5:00PM",
        // read only by default false
        readonly: false,
        // mask behavior by default flase
        // user can not enter any char  it is only enter format date
        useMaskBehavior: false,
        //validationMessageMode: "always",
        //isValid:false,
        visible: true,
        // not open calaender
        opened: false,
        hint:"select date and time",
        adaptivityEnabled:false,
        deferRendering: true
        
    });

    $("#timeBox").dxDateBox({
        //type: "time",
        //interval: 45,
        pickerType: "calendar",  // by default list    ,   native  , rollers
        placeholder: "Select time",
    });

    
    // date box instance
    var dateBoxInstance = $("#dateBox").dxDateBox("instance");
    // date time box insatance
    var dateTimeBoxInstance = $("#datetimeBox").dxDateBox("instance");
    // time box instacne
    var timeBoxInstance = $("#timeBox").dxDateBox("instance");

   
    timeBoxInstance.option("placeholder", "enter your important time");
    timeBoxInstance.option("type", "time");
    timeBoxInstance.option("interval",23)
    //option(timeBoxInstance, "type", "time");
    //option(timeBoxInstance, "interval", 50);
    timeBoxInstance.open();

    dateBoxInstance.on("copy", () => {
        console.log("copy")
    });

    dateBoxInstance.on("cut", () => {
        console.log("cut")
    });
    dateBoxInstance.on("paste", () => {
        console.log("paste")
    })

    dateBoxInstance.on("keydown", (e) => {
        console.log(`${e.event.key}`)
    })

    dateTimeBoxInstance.focus();
    dateTimeBoxInstance.blur();
    dateTimeBoxInstance.beginUpdate();
    // set time out
    setTimeout(function () {
        

        //multiple changes to the DateTimeBox instanc
        dateTimeBoxInstance.option("readOnly", true);
        dateTimeBoxInstance.open();
        dateBoxInstance.reset();
        
        
    }, 5000)
    dateTimeBoxInstance.endUpdate();

    dateBoxInstance.on("optionChanged", function (e) {
        console.log("options is ", e.value); 
    })


   // dateBoxInstance.dispose();
})