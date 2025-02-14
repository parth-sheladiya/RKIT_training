$(document).ready(function () {

    // Initialize form controls as you've already set up
    $("#fullName").dxTextBox({
        hint: "Full name",
        placeholder: "enter your full name",
        spellcheck: true,
        stylingMode: "filled",
        validationMessageMode: "always",
    }).dxValidator({
        name: "fullname",
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
        type: "date",
        hint: "date box",
        placeholder: "select your date of birth",
        dateSerializationFormat: "yyyy-MM-dd",
        min: new Date(1975, 0, 1),
        max: new Date(),
        showClearButton: true,
    }).dxValidator({
        name: "BirthDate",
        validationRules: [
            {
                type: "required",
                message: "Birth Date is required"
            },
            {
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
        items: GenderData,
        layout: "horizontal",
        value: null,
    }).dxValidator({
        name: "Gender",
        validationRules: [
            { type: "required", message: "Gender is required" }
        ]
    });

    $("#bloodGroup").dxSelectBox({
        items: BloodGroup,
        placeholder: "select your blood group",
        dropDownOptions: { closeOnOutsideClick: true }
    }).dxValidator({
        name: "BloodGroup",
        validationRules: [
            { type: "required", message: "BloodGroup is required" }
        ]
    });
    // Disease checkboxes
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
        hint: "mobile number",
        placeholder: "enter your mobile number",
        mask: "+91 XXXXXXXXXX",
        maskRules: { "X": /[0-9]/ },
        maskInvalidMessage: "Enter a valid phone number",
        useMaskedValue: true,
        showMaskMode: "onFocus",
    }).dxValidator({
        name: "mobile",
        validationRules: [
            { type: "required", message: "mobile number is required" }
        ]
    });

    $("#state").dxSelectBox({
        items: Object.keys(StatesSelect),
        onValueChanged: function (e) {
            $("#district").dxSelectBox("instance").option("items", StatesSelect[e.value] || []);
            $("#district").dxSelectBox("instance").reset(); // Reset district selection
        }
    }).dxValidator({
        name: "State",
        validationRules: [{ type: "required", message: "State is required" }]
    });

    $("#district").dxSelectBox({
        items: [],
    }).dxValidator({
        name: "District",
        validationRules: [{ type: "required", message: "District is required" }]
    });

    $("#vehicleType").dxDropDownBox({
        placeholder: "Select vehicle type",
        contentTemplate(e) {
            const list = $("<div>").dxList({
                dataSource: TypeOfVehicle,
                selectionMode: "single",
                onItemClick: function (args) {
                    e.component.option("value", args.itemData);
                    e.component.close();
                },
            });
            return list;
        }
    }).dxValidator({
        validationRules: [{ type: "required", message: "Vehicle type is required" }]
    });

    $("#licenseType").dxSelectBox({
        items: TypeOfLicence,
        placeholder: "select licence type",
    }).dxValidator({
        name: "licencetype",
        validationRules: [{ type: "required", message: "Licence type is required" }]
    });

    $("#examDate").dxDateBox({
        type: "date",
        hint: "exam date",
        placeholder: "select your exam date",
        min: new Date(),
        max: new Date(2025, 3, 1),
        showClearButton: true,
    }).dxValidator({
        type: "required",
        message: "Exam Date is required"
    });

    $("#idProof").dxFileUploader({
        labelText: "Upload ID Proof",
        accept: "image/*",
        maxFileSize: 1000000,
        minFileSize: 1000,
    }).dxValidator({
        name: "idproof",
        validationRules: [
            { type: "required", message: "ID proof is required" }
        ]
    });

    $("#declaration").dxCheckBox({
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
        text: "Register",
        type: "success",
        useSubmitBehavior: true,
        onClick: () => {
            const result = DevExpress.validationEngine.validateGroup();
            if (result.isValid) {
                saveToSessionStorage(); // Save data to sessionStorage
                DevExpress.ui.notify("Form submitted successfully", "success", 5000);
            } else {
                DevExpress.ui.notify("Please fix the validation errors", "error", 5000);
            }
        },
    });

    // Function to save form data to sessionStorage
    function saveToSessionStorage() {
        const formData = {
            fullName: $("#fullName").dxTextBox("instance").option("value"),
            dob: $("#dob").dxDateBox("instance").option("value"),
            gender: $("#gender").dxRadioGroup("instance").option("value"),
            bloodGroup: $("#bloodGroup").dxSelectBox("instance").option("value"),
            mobile: $("#mobile").dxTextBox("instance").option("value"),
            state: $("#state").dxSelectBox("instance").option("value"),
            district: $("#district").dxSelectBox("instance").option("value"),
            vehicleType: $("#vehicleType").dxDropDownBox("instance").option("value"),
            licenseType: $("#licenseType").dxSelectBox("instance").option("value"),
            examDate: $("#examDate").dxDateBox("instance").option("value"),
            idProof: $("#idProof").dxFileUploader("instance").option("value"),
            declaration: $("#declaration").dxCheckBox("instance").option("value"),
            diseases: [
                $("#disease1").dxCheckBox("instance").option("value") ? "Hypertension" : null,
                $("#disease2").dxCheckBox("instance").option("value") ? "Diabetes" : null,
                $("#disease3").dxCheckBox("instance").option("value") ? "Asthma" : null,
                $("#disease4").dxCheckBox("instance").option("value") ? "Heart Disease" : null,
                $("#disease5").dxCheckBox("instance").option("value") ? "Cancer" : null
            ].filter(Boolean), // Remove null values
        };

        // Save the form data to sessionStorage
        sessionStorage.setItem("formData", JSON.stringify(formData));

        console.log("Form Data Saved to sessionStorage:", formData); 
    }
});
