$(document).ready(function () {

    $("#basicDropDownBox").dxDropDownBox({
        name: ["parth", "jay", "deep", "jeel"],
        placeholder: "select a value",
        acceptCustomValue: false,
        disabled: false,
        readonly: false,
        hint: "this is dropdown box",
        displayExpr: "name",
        height: "100px",
        width: "500px",
        showDropDownButton:true
    })








    var names = ["parth", "raj", "deep", "jay", "jeel"]

    $("#dropDownBox").dxDropDownBox({
        contentTemplate: function (e) {
            var $list = $("<div>").dxList({
                dataSource:names
            })
            return $list;
            
           
        },
        displayExpr: "name",
    })
});