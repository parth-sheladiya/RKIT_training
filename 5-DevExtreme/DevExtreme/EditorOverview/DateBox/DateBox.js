$(document).ready(function () {


    $("#datetimeBox").dxDateBox({
        //type time
        type: "date",
        value: new date(),
        // user enter or not 
        acceptCustomValue: false,
        // keyboard specific
        accessKey: "t",
        // active state 
        // real world example hotel booking system check in check out date
        // activeStateEnabled: true,
        // changes button value content
        applyButtonText: "🤣",
        cancelButtonText: "hello",
        applyValueMode: 'useButtons'

    });

    $("#dateBox").dxDateBox({
        //type time
        type: "date",
        value:new date(),
        // user enter or not 
        acceptCustomValue: false,
        // keyboard specific
        accessKey: "t",
        // active state 
        // real world example hotel booking system check in check out date
       // activeStateEnabled: true,
        // changes button value content
        applyButtonText: "🤣",
        cancelButtonText:"hello",
       applyValueMode:'useButtons'

    });

   
})