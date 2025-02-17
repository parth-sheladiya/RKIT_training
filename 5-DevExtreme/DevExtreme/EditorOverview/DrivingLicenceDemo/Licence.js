$(document).ready(function () {

    // Initialize form controls as you've already set up
    $("#fullName").dxTextBox({
        // hint 
        hint: "Full name",
        // place holder
        placeholder: "enter your full name",
        // check speeling if wrong then red underline
        spellcheck: true,
        // style
        stylingMode: "filled",
        // message
        validationMessageMode: "always",
    }).dxValidator({
        name: "fullname",
        // arr
        validationRules: [
            {
                type: "required",
                message: "full name is required"
            },
            {
                type: "stringLength",
                min: 1,
                max: 22,
                message: "First Name must be between 1 and 22 characters!"
            }
        ]
    });

    $("#dob").dxDateBox({
        // type time,dattime
        type: "date",
        // hint
        hint: "date box",
        // place holder
        placeholder: "select your date of birth",
        displayFormat: "yyyy-MM-dd",
        // min date
        min: new Date(1975, 0, 1),
        // today is max day
        max: new Date(),
        // clear button
        showClearButton: true,
    }).dxValidator({
        name: "BirthDate",
        validationRules: [
            {
                type: "required",
                message: "Birth Date is required"
            },
            {
                // type for custom error for validation
                type: "custom",
                validationCallback: function (e) {
                    let birthDate = new Date(e.value);
                    let age = new Date().getFullYear() - birthDate.getFullYear();
                    return age >= 18;
                },
                message: "You must be at least 18 years old"
            }
        ]
    });

    $("#gender").dxRadioGroup({
        // it is for data.js
        items: GenderData,
        // vertical and horizontal
        layout: "horizontal",
        // value 
        value: "Male",
    }).dxValidator({
        name: "Gender",
        validationRules: [
            { 
                type: "required", 
                message: "Gender is required" 
            }
        ]
    });

    $("#bloodGroup").dxSelectBox({
        // it is for data.js
        items: BloodGroup,
        // placeholder
        placeholder: "select your blood group",
        // dropdown option
        // if user click outside of box then automatic close select box
        dropDownOptions: 
                { 
                    closeOnOutsideClick: true 
                }
    }).dxValidator({
        name: "BloodGroup",
        validationRules: [
            { 
                type: "required", 
                message: "BloodGroup is required" 
            }
        ]
    });
    // disabled checkboxes
    $("#disease1").dxCheckBox({
        text: "Hypertension"
    });
    $("#disease2").dxCheckBox({
        text: "Diabetes"
    });
    $("#disease3").dxCheckBox({
        text: "Asthma"
    });
    $("#disease4").dxCheckBox({
        text: "Heart Disease"
    });
    $("#disease5").dxCheckBox({
        text: "Cancer"
    });



    $("#mobile").dxTextBox({
        // hint
        hint: "mobile number",
        // placeholder
        placeholder: "enter your mobile number",
        // mask 
        mask: "+91 XXXXXXXXXX",
        // rules for only number
        maskRules: { "X": /[0-9]/ },
        // message
        maskInvalidMessage: "Enter a valid phone number",
        // format related
        useMaskedValue: true,
        // when show mask?
        showMaskMode: "onFocus",
    }).dxValidator({
        name: "mobile",
        validationRules: [
            { 
                type: "required", 
                message: "mobile number is required" 
            }
        ]
    });

    $("#state").dxSelectBox({
        // data.js 
        items: Object.keys(StatesSelect),
        onValueChanged: function (e) {
            $("#district").dxSelectBox("instance").option("items", StatesSelect[e.value] || []);
            // reset district value
           // $("#district").dxSelectBox("instance").reset(); 
        }
    }).dxValidator({
        name: "State",
        validationRules: [
            { 
                type: "required", 
                message: "State is required" 
            }
        ]
    });

    $("#district").dxSelectBox({
        // item is emtpy bcz if user can select state then state wises district show
        items: [],
    }).dxValidator({
        name: "District",
        validationRules: [
            { 
                type: "required", 
                message: "District is required" 
            }
        ]
    });

    $("#vehicleType").dxDropDownBox({
        // place holder
        placeholder: "Select vehicle type",
        // content template
        contentTemplate(e) {
            const list = $("<div>").dxList({
                // data source data.js
                dataSource: TypeOfVehicle,
                //we can choose multiple option
                selectionMode: "single",
                onItemClick: function (args) {
                    e.component.option("value", args.itemData);
                    e.component.close();
                },
            });
            return list;
        }
    }).dxValidator({
        validationRules: [
            { 
                type: "required", 
                message: "Vehicle type is required" 
            }
        ]
    });

    $("#licenseType").dxSelectBox({
        // data source
        items: TypeOfLicence,
        // place holder
        placeholder: "select licence type",
    }).dxValidator({
        name: "licencetype",
        validationRules: [
            { 
                type: "required", 
                message: "Licence type is required" 
            }
        ]
    });

    $("#examDate").dxDateBox({
        // type date time , datetime
        type: "date",
        // hint
        hint: "exam date",
        // place holder 
        placeholder: "select your exam date",
        // min date
        min: new Date(),
        // max date
        max: new Date(2025, 3, 1),
        // clear button
        showClearButton: true,
    }).dxValidator({
        type: "required",
        message: "Exam Date is required"
    });

    $("#idProof").dxFileUploader({
        // file uploder
        labelText: "Upload ID Proof",
        // accept only image
        accept: "image/*",
        // max sixe of file
        maxFileSize: 1000000,
        // min size of file
        minFileSize: 1000,
        // fake url it is resource for deveextreme website
        uploadUrl:"https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload",
    }).dxValidator({
        name: "idproof",
        validationRules: [
            { 
                type: "required", 
                message: "ID proof is required" 
            }
        ]
    });

    $("#declaration").dxCheckBox({
        // checkk box text
        text: "I Agree to Terms & Conditions",
    }).dxValidator({
        validationRules: [
            {
                type: "compare",
                comparisonTarget: () => true,
                message: "You must agree to the Terms and Conditions",
            },
        ]
    });

    $("#submitBtn").dxButton({
        // show on ui
        text: "Register",
        // type
        type: "success",
        // behavior
        useSubmitBehavior: true,
        onClick: () => {
            // validate form group
            const result = DevExpress.validationEngine.validateGroup();
            // isvalid is return bool value and it is check all value is valid or not 
            if (result.isValid) {
                // Save data to sessionstorage
                saveToSessionStorage(); 
                DevExpress.ui.notify("form submitted successfully", "success", 5000);
            } else {
                DevExpress.ui.notify("error generate", "error", 5000);
            }
        },
    });

    // save data to session storage
    function saveToSessionStorage() {
        const formData = {
            // full name
            fullName: $("#fullName").dxTextBox("instance").option("value"),
            // date of birth 
            dob: $("#dob").dxDateBox("instance").option("value"),
            // male female
            gender: $("#gender").dxRadioGroup("instance").option("value"),
            // blood group
            bloodGroup: $("#bloodGroup").dxSelectBox("instance").option("value"),
            // phone number
            mobile: $("#mobile").dxTextBox("instance").option("value"),
            // select state
            state: $("#state").dxSelectBox("instance").option("value"),
            // state wise district
            district: $("#district").dxSelectBox("instance").option("value"),
            // vehicle type
            vehicleType: $("#vehicleType").dxDropDownBox("instance").option("value"),
            // licence type
            licenseType: $("#licenseType").dxSelectBox("instance").option("value"),
            // exam date set
            examDate: $("#examDate").dxDateBox("instance").option("value"),
            // valid id proof only image format
            idProof: $("#idProof").dxFileUploader("instance").option("value"),
            // check box 
            declaration: $("#declaration").dxCheckBox("instance").option("value"),
            // if any diseases
            diseases: [
                $("#disease1").dxCheckBox("instance").option("value") ? "Hypertension" : null,
                $("#disease2").dxCheckBox("instance").option("value") ? "Diabetes" : null,
                $("#disease3").dxCheckBox("instance").option("value") ? "Asthma" : null,
                $("#disease4").dxCheckBox("instance").option("value") ? "Heart Disease" : null,
                $("#disease5").dxCheckBox("instance").option("value") ? "Cancer" : null
            ].filter(Boolean)
        };

        // Save the form data to sessionStorage
        sessionStorage.setItem("formData", JSON.stringify(formData));

        // Log the form data to the console
        console.log("Form Data Saved to sessionStorage:", formData); 
    }
});
