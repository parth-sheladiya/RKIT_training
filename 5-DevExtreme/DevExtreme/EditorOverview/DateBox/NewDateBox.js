import {
    option
} from "../AllMethodEvent/Method.js";


$(document).ready(function () {

    console.log("document is ready ");

    $("#dateBox").dxDateBox({
        //type time
        type: "date",
        // show on field
        value: new Date(),
        // show on format in field
        displayFormat: "MMM dd, yyyy",
        dateSerializationFormat: "yyyy-MM-ddTHH:mm:ssZ",
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
        applyValueMode: 'useButtons',
        /// height
        height: "55px",
        // width
        width: "300px",
       maxLength:3,
       // hover then set enable to true
        hoverStateEnabled:true,
        // user only enter format date 
        useMaskBehavior: true,
        

    });

    // create date box instance
    var fDateBoxInstance = $("#dateBox").dxDateBox("instance");
    
    fDateBoxInstance.on("valueChanged", function (e) {
        console.log("Disaplay value is ", e.value);
        console.log("serialize value is ", e.component.option("value"));
    })


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
        pickerType: "calendar",  
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
        readonly: true,
        // mask behavior by default flase
        // user can not enter any char  it is only enter format date
        useMaskBehavior: true,
        //validationMessageMode: "always",
        //isValid:false,
        visible: true,
        // not open calaender
        opened: false
        
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
    option(timeBoxInstance, "type", "time");
    option(timeBoxInstance, "interval", 50);
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
        

        //multiple changes to the DateTimeBox instance
        //dateTimeBoxInstance.option("value", new Date("2025-01-01T12:00:00"));
        //dateTimeBoxInstance.option("min", new Date("2020-01-01"));
        dateTimeBoxInstance.option("readOnly", true);
        dateTimeBoxInstance.open();
        dateBoxInstance.reset();
        
        
    }, 5000)
    dateTimeBoxInstance.endUpdate();

    dateBoxInstance.on("optionChanged", function (e) {
        console.log("value is ", e.value); 
    })


   // dateBoxInstance.dispose();
})