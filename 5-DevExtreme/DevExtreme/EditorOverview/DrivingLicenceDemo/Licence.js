$(document).ready(function () {
    function showSuccessMessage(e) {
        if (e.isValid) {
            console.log(e.validator.option("name") + " is valid.");
        }
    }

    function validateForm() {
        let isValid = true;
        $(".dx-validator").each(function () {
            let validator = $(this).dxValidator("instance");
            let result = validator.validate();
            if (!result.isValid) {
                isValid = false;
            }
        });
        return isValid;
    }

    function saveToSessionStorage() {
        let formData = {
            fullName: $("#fullName-validation").dxTextBox("instance").option("value"),
            dob: $("#dob-validation").dxDateBox("instance").option("value"),
            gender: $("#gender-validation").dxRadioGroup("instance").option("value"),
            bloodGroup: $("#bloodGroup-validation").dxSelectBox("instance").option("value"),
            mobile: $("#mobile-validation").dxNumberBox("instance").option("value"),
            state: $("#state-validation").dxSelectBox("instance").option("value"),
            district: $("#district-validation").dxSelectBox("instance").option("value"),
            vehicleType: $("#vehicleType-validation").dxSelectBox("instance").option("value"),
            licenseType: $("#licenseType-validation").dxSelectBox("instance").option("value"),
            examDate: $("#examDate-validation").dxDateBox("instance").option("value"),
            idProof: $("#idProof-validation").dxFileUploader("instance").option("value"),
            declaration: $("#declaration-validation").dxCheckBox("instance").option("value")
        };
        sessionStorage.setItem("licenseFormData", JSON.stringify(formData));
    }

    function loadFromSessionStorage() {
        let storedData = sessionStorage.getItem("licenseFormData");
        if (storedData) {
            let formData = JSON.parse(storedData);
            $("#fullName-validation").dxTextBox("instance").option("value", formData.fullName);
            $("#dob-validation").dxDateBox("instance").option("value", formData.dob);
            $("#gender-validation").dxRadioGroup("instance").option("value", formData.gender);
            $("#bloodGroup-validation").dxSelectBox("instance").option("value", formData.bloodGroup);
            $("#mobile-validation").dxNumberBox("instance").option("value", formData.mobile);
            $("#state-validation").dxSelectBox("instance").option("value", formData.state);
            $("#district-validation").dxSelectBox("instance").option("value", formData.district);
            $("#vehicleType-validation").dxSelectBox("instance").option("value", formData.vehicleType);
            $("#licenseType-validation").dxSelectBox("instance").option("value", formData.licenseType);
            $("#examDate-validation").dxDateBox("instance").option("value", formData.examDate);
            $("#idProof-validation").dxFileUploader("instance").option("value", formData.idProof);
            $("#declaration-validation").dxCheckBox("instance").option("value", formData.declaration);
        }
    }

    $("#fullName-validation").dxTextBox({
        placeholder: "Enter full name",
       // validationMessageMode: "always",
    }).dxValidator({
        name: "Full Name",
        onValidated: showSuccessMessage,
        validationRules: [
            { type: "required", message: "Full Name is required" },
            {
                type: "stringLength",
                min: 1,
                max: 22,
                message: "First Name must be between 1 and 22 characters!",
            }
        ],
    });

    $("#dob-validation").dxDateBox({
        type: "date",
        validationMessageMode: "always",
    }).dxValidator({
        name: "Date of Birth",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "custom",
                validationCallback: function (e) {
                    let birthDate = new Date(e.value);
                    let age = new Date().getFullYear() - birthDate.getFullYear();
                    return age >= 18;
                },
                message: "You must be at least 18 years old"
            },
        ],
    });

    $("#gender-validation").dxRadioGroup({
        items: RadioData,
        validationMessageMode: "always",
    }).dxValidator({
        name: "Gender",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "Gender is required" }],
    });

    $("#bloodGroup-validation").dxSelectBox({
        items: BloodGroup,
        validationMessageMode: "always",
    }).dxValidator({
        name: "Blood Group",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "Blood Group is required" }],
    });

    $("#mobile-validation").dxNumberBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "Mobile Number",
        onValidated: showSuccessMessage,
        validationRules: [
            { type: "required", message: "Mobile Number is required" },
            { type: "pattern", pattern: "^[0-9]{10}$", message: "Must be a 10-digit number" },
        ],
    });

    $("#state-validation").dxSelectBox({
        items: Object.keys(districts),
        validationMessageMode: "always",
        onValueChanged: function (e) {
            $("#district-validation").dxSelectBox("option", "items", districts[e.value]);
        },
    }).dxValidator({
        name: "State",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "State is required" }],
    });

    $("#district-validation").dxSelectBox({
        items: [],
        validationMessageMode: "always",
    }).dxValidator({
        name: "District",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "District is required" }],
    });

    $("#vehicleType-validation").dxSelectBox({
        items: TypeOfVehicle,
        validationMessageMode: "always",
    }).dxValidator({
        name: "Vehicle Type",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "Vehicle Type is required" }],
    });

    $("#licenseType-validation").dxSelectBox({
        items: TypeOfLicence,
        validationMessageMode: "always",
    }).dxValidator({
        name: "License Type",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "License Type is required" }],
    });

    $("#examDate-validation").dxDateBox({
        type: "date",
        validationMessageMode: "always",
    }).dxValidator({
        name: "Exam Date",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "Exam Date is required" }],
    });

    $("#idProof-validation").dxFileUploader({
        accept: "image/*,application/pdf",
        multiple: false,
        validationMessageMode: "always",
    }).dxValidator({
        name: "ID Proof",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "ID Proof is required" }],
    });

    $("#declaration-validation").dxCheckBox({
        text: "I agree",
        validationMessageMode: "always",
    }).dxValidator({
        name: "Declaration",
        onValidated: showSuccessMessage,
        validationRules: [{ type: "required", message: "You must accept the terms" }],
    });

    $("#submitBtn").dxButton({
        text: "Submit",
        type: "success",
        onClick: function () {
            e.event.preventDefault();
            if (validateForm()) {
                saveToSessionStorage();
                alert("Form Submitted Successfully!");
                sessionStorage.removeItem("licenseFormData"); 
            } else {
                alert("Please fix errors before submitting.");
            }
        },
    });

    loadFromSessionStorage();
});
