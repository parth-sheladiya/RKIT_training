$(document).ready(function () {



    $("#dateBox").dxDateBox({
        //type time
        type: "date",
        value: new Date(),
        displayFormat: "yyyy/MM/dd",
        invalidDateMessage: "Invalid Date formate please try yyyy/MM/dd format",
        // user enter or not 
        acceptCustomValue: true,
        // keyboard specific
        accessKey: "t",
        // active state 
        // real world example hotel booking system check in check out date
        // activeStateEnabled: true,
        // changes button value content
        applyButtonText: "🤣",
        cancelButtonText: "😎",
        applyValueMode: 'useButtons',
        height: "55px",
        width: "300px",
       // maxLength:3,


    });



    $("#datetimeBox").dxDateBox({
        //type time
        type: "datetime",
        disabledDates: [
            new Date("11/20/2024")
        ],
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
        placeholder: "20/11/2003",
       readonly:true

    });


})