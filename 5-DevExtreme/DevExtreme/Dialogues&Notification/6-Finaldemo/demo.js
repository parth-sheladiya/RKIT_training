import { addFoodCategory, openAddFoodPopup, showFoodItems } from "./foodService/service.js";
$(document).ready(function () {
    console.log("doc is ready");

    localStorage.setItem("foodData", JSON.stringify(foodData));


    // Menu 
    $("#MenuContainer").dxMenu({
        items: [
            { text: "Add Food" },
            { text: "Show Food Item" },
            { text: "Add Food Category" }
        ],
        onItemClick: function (e) {
            if (e.itemData.text === "Add Food") {
                openAddFoodPopup();
            } else if (e.itemData.text === "Show Food Item") {
                showFoodItems();
            }
            else if (e.itemData.text === "Add Food Category") {
                addFoodCategory();
            }
        }
    });
    const toast = $("#ToastContainer").dxToast({
        displayTime: 5000,
        closeOnOutsideClick: true,
        type: "success", // 'custom' | 'error' | 'info' | 'success' | 'warning'
        message: "",
        position: { my: "top center" },
    }).dxToast("instance");

    console.log("toast",toast)
});




