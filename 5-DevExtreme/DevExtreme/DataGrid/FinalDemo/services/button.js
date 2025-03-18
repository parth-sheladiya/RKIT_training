export const createDxButton = (selector, text, type, icon, onClickFunction) => {
    $(selector).dxButton({
        text,
        type,
        icon,
        onClick: onClickFunction
    });
};
