export const DisplayNotifyMessage = (message, type,displayNotifyTime) =>{
    DevExpress.ui.notify({
        message:message,
        type:type,
        displayNotifyTime:displayNotifyTime
    })
}