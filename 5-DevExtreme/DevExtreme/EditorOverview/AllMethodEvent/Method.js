// Starts a batch update operation, preventing UI updates until `endUpdate()` is called
const beginUpdate = (widgetInstance) => widgetInstance.beginUpdate();

// Removes focus from the widget
const blur = (widgetInstance) => widgetInstance.blur();

// Closes the widget's dropdown
const close = (widgetInstance) => widgetInstance.close();

// Disposes of the widget, freeing up memory
const dispose = (widgetInstance) => widgetInstance.dispose();

// Returns the root HTML element of the widget
const element = (widgetInstance) => widgetInstance.element();

// Ends a batch update operation and applies UI updates
const endUpdate = (widgetInstance) => widgetInstance.endUpdate();

// Returns the input field element inside the widget
const field = (widgetInstance) => widgetInstance.field();

// Sets focus to the widget
const focus = (widgetInstance) => widgetInstance.focus();

// Returns the instance of the widget itself
const instance = (widgetInstance) => widgetInstance.instance();


// Opens the widget's dropdown (if applicable)
const open = (widgetInstance) => widgetInstance.open();

// Gets or sets an option for the widget
const option = (widgetInstance, optionNameOrObject, optionValue = null) =>
    optionValue !== null
        ? widgetInstance.option(optionNameOrObject, optionValue) // Sets an option
        : widgetInstance.option(optionNameOrObject); // Gets an option

// Registers a custom key handler for specific key events
const registerKeyHandler = (widgetInstance, key, handler) =>
    widgetInstance.registerKeyHandler(key, handler);

// Resets the widget to its default state
const reset = (widgetInstance) => widgetInstance.reset();



export {
    beginUpdate,
    blur,
    close,
    dispose,
    element,
    endUpdate,
    field,
    focus,
    instance,
    open,
    option,
    registerKeyHandler,
    reset,
};