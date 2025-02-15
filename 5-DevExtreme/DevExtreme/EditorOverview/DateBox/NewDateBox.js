import {
    option
} from "../AllMethodEvent/Method.js";


$(document).ready(function () {



    $("#dateBox").dxDateBox({
        //type time
        type: "date",
        value: new Date(),
        // why not working
        displayFormat: "dd-MM-yyyy",
        dateSerializationFormat: "yyyy-MM-ddTHH:mm:ssZ",
        invalidDateMessage: "Invalid Date formate please try yyyy/MM/dd format",
        // user enter or not 
        acceptCustomValue: true,
        // keyboard specific
        accessKey: "t",
        // active state 
        // real world example hotel booking system check in check out date
        // activeStateEnabled: true,
        // changes button value content
        applyButtonText: "👍",
        cancelButtonText: "😎",
        applyValueMode: 'useButtons',
        height: "55px",
        width: "300px",
       // maxLength:3,
        hoverStateEnabled:true


    });

    var fDateBoxInstance = $("#dateBox").dxDateBox("instance");
    
    fDateBoxInstance.on("valueChanged", function (e) {
        console.log("Disaplay value is ", e.value);
        console.log("serialize value is ", e.component.option("value"));
    })


    $("#datetimeBox").dxDateBox({
        //type time
        type: "datetime",
        showAnalogClock :true,
        disabledDates: [
            new Date("11/20/2024")
        ],
        showClearButton:false,
        //id: "elementId",
        max: new Date(),
        min: new Date("11/11/2000"),
        dateOutOfRangeMessage: "date is out of range please valid date",
        // doubt
       // dateSerializationFormat:"yyyy-MM-ddTHH:mm:ssZ"
        disabled: false,
        pickerType: "calendar",
        // user for date and datetime not use in time 
        disabledDates: [
            new Date(2025, 1, 2), 
            new Date(2025, 1,4), 
            new Date(2025, 2, 1) 
        ],
        hint: "this is datetimer format ",
        placeholder: "20/11/2003 5:00PM",
        readonly: true,
        useMaskBehavior: true,
        //validationMessageMode: "always",
        //isValid:false,
        visible: true,
        opened: false
        
    });

    $("#timeBox").dxDateBox({
        //type: "time",
        //interval: 45,
        pickerType: "calendar",  // by default list    ,   native  , rollers
        placeholder: "Select time",
    });

    

    var dateBoxInstance = $("#dateBox").dxDateBox("instance");
    var dateTimeBoxInstance = $("#datetimeBox").dxDateBox("instance");
    var timeBoxInstance = $("#timeBox").dxDateBox("instance");

   
    timeBoxInstance.option("placeholder", "enter your important time");
    option(timeBoxInstance, "type", "time");
    option(timeBoxInstance, "interval", 50);
    option(timeBoxInstance, "pickerType");
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
    setTimeout(function () {
        

        //// Making multiple changes to the DateTimeBox instance
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