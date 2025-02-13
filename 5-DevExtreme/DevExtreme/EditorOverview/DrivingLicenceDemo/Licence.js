$(document).ready(function () {
    $("#fullName").dxTextBox({
        hint: "Full name",
        placeholder: "enter your full name",
        spellcheck: true,
        stylingMode: "filled",
        //maxLength: 15,
        //minLength:4,
        validationMessageMode: "always",
    }).dxValidator({
        name: "fullname",
        validationRules: [
            {
                type: "required",
                message: "full name  is required"
            },
            {
                // that'why difference between maxlength and max
                type: "stringLength",
                min: 1,
                max: 22,
                message: "First Name must be between 1 and 22 characters!",
            }
        ],
    })



    $("#dob").dxDateBox({
        type: "date",
        hint: "date box",
        placeholder: "select your date of birth",
        acceptCustomValue: false,
        dateSerializationFormat: "yyyy-MM-dd",
        invalidDateMessage: "Invalid Date formate please try yyyy/MM/dd format",
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
        ],
    })



    $("#gender").dxRadioGroup({
        items: GenderData,
        layout: "horizontal",
        value: null,
    }).dxValidator({
        name: "Gender",
        validationRules: [
            {
                type: "required",
                message: "Gender is required"
            }
        ],
    })


    $("#bloodGroup").dxSelectBox({
        items: BloodGroup,
        placeholder: "select your blood group",
        dropDownOptions: {
            closeOnOutsideClick: true
        },

    }).dxValidator({
        name: "BloodGroup",
        validationRules: [
            {
                type: "required",
                message: "BloodGroup is required"
            },
        ],
    })


    $("#mobile").dxTextBox({
        hint: "mobile number",
        placeholder: "enter your mobile number",
        mask: "+91 XXXXXXXXXX",  
        maskRules: {
            "X": /[0-9]/
        }, 
        maskInvalidMessage: "Enter a valid phone number",
        useMaskedValue: true,
        showMaskMode: "onFocus",
    }).dxValidator({
        name: "mobile",
        validationRules: [
            {
                type: "required",
                message: "mobile number is required"
            },
        ],
    });



    $("#state").dxDropDownBox({
        acceptCustomValue: false,
        placeholder:"select state"
    }).dxValidator({

    })


    $("#district").dxDropDownBox({
        acceptCustomValue: false,
        placeholder:"select district"
    }).dxValidator({

    })


    $("#vehicleType").dxSelectBox({
        items: TypeOfVehicle,
        placeholder: "select vehicle type",
        hint: "this is select box",
    }).dxValidator({
        name: "vehicletype",
        validationRules: [
            {
                type: "required",
                message: "vehicle type is required"
            },
        ],
    })


    $("#licenseType").dxSelectBox({
        items: TypeOfLicence,
        placeholder: "select licence type",
        hint: "this is select box",
    }).dxValidator({
        name: "licencetype",
        validationRules: [
            {
                type: "required",
                message: "licence type is required"
            },
        ],
    })


    $("#examDate").dxDateBox({
        type: "date",
        hint: "date box",
        placeholder: "select your exam date",
        acceptCustomValue: false,
        dateSerializationFormat: "yyyy-MM-dd",
        invalidDateMessage: "Invalid Date formate please try yyyy/MM/dd format",
        min: new Date(),
        max: new Date(2025,3,1),
        showClearButton: true,
    }).dxValidator({
        type: "required",
        message: "exam Date is required"
    })


    $("#idProof").dxFileUploader({
        labelText: "id proof",
        accept: "image/*",
        allowCanceling: true,
        uploadUrl: "https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload",
        maxFileSize: 1000000,
        minFileSize: 1000,
        uploadMode: "useButtons",
        invalidFileExtensionMessage: "this extension is invalid",
        invalidMaxFileSizeMessage: "your id proof size is greater than maxsize",
        invalidMinFileSizeMessage: "your id proof size is less than min size",
        onProgress: function (e) {
            alert("Upload progress:", e.bytesLoaded / e.bytesTotal * 100, "%");
        }, 
    }).dxValidator({
        name: "idproof",
        validationRules: [
            {
                type: "required",
                message: "id proof is required"
            },
        ],
    })


    $("#declaration").dxCheckBox({
        text: "I Agree to Terms & Conditions",
    }).dxValidator({
        validationRules: [
            {
                type: "compare",
                comparisonTarget: () => true,
                message: "You must agree to the Terms and Conditions",
            },
        ],
    })


    $("#submitBtn").dxButton({
        text: "Register",
        type: "success",
        useSubmitBehavior: true,
        stylingMode: "contained",
        onClick: () => {
            const result = DevExpress.validationEngine.validateGroup();
            if (result.isValid) {
                DevExpress.ui.notify("success", "success", 5000)
               
            } else {
                DevExpress.ui.notify("Please fix the validation errors", "error", 5000);
            }
        },
    })




});